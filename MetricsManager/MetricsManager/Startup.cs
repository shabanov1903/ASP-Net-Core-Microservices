using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.DB;
using MetricsManager.Services.DTO;
using MetricsManager.DB.Entities;
using AutoMapper;
using MetricsManager.Jobs;
using Quartz;
using Quartz.Spi;
using Quartz.Impl;
using System.Reflection;
using System.IO;

namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ������� ����� ������",
                    Description = "�������� API �������",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shabanov Danil",
                        Email = "shabanov1903@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "��������� ��������",
                        Url = new Uri("https://example.com/license")
                    }
                });
                // ��������� ���� �� �������� ����� ����������� ��� Swagger UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var mapperConfig = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

            services.AddSingleton<IDBRepository<AgentInfo>, DBRepository<AgentInfo>>();

            // ���������� Http
            services.AddSingleton<IQueryManager<CpuMetrics>, QueryManager<CpuMetrics>>();
            services.AddSingleton<IQueryManager<DotNetMetrics>, QueryManager<DotNetMetrics>>();
            services.AddSingleton<IQueryManager<HddMetrics>, QueryManager<HddMetrics>>();
            services.AddSingleton<IQueryManager<NetworkMetrics>, QueryManager<NetworkMetrics>>();
            services.AddSingleton<IQueryManager<RamMetrics>, QueryManager<RamMetrics>>();
            services.AddHttpClient();

            // ���������� ��������
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // ���������� ������
            services.AddSingleton<Job>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(Job),
                cronExpression: "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ������� ����� ������"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}