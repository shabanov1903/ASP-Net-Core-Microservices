using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsManager.Dto;

namespace MetricsManager.Services
{
    public class DB_Cpu : MetricsManager.DAL.ICpuMetricsRepository
    {
        public List<CpuMetrics> GetByTimePeriod()
        {
            // создаем массив, в который запишем объекты с данными из базы
            // данных
            var returnArray = new List<CpuMetrics>();

            // Создаем строку подключения в виде базы данных
            string connectionString = $"Data Source=c:\\temp\\Metrics.db; Version=3";
            // Создаем соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();
                // Создаем объект через который будут выполняться команды к базе данных
                using (var command = new SQLiteCommand(connection))
                {
                    // создаем строку для выборки данных из базы
                    string readQuery = "SELECT * FROM cpumetrics";
                    // изменяем текст команды на наш запрос чтения
                    command.CommandText = readQuery;
                    // создаем читалку из базы данных
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // цикл будет выполняться до тех пор, пока есть что читать
                        // из базы данных
                        while (reader.Read())
                        {
                            // создаем объект и записываем его
                            returnArray.Add(new CpuMetrics()
                            {
                                // читаем данные полученные из базы данных преобразуя к целочисленному типу
                                Id = reader.GetInt32(0),
                                Value = reader.GetInt32(1),
                                Time = reader.GetInt64(2)
                            });
                        }
                    }
                }
            }
            return returnArray;
        }
    }
}
