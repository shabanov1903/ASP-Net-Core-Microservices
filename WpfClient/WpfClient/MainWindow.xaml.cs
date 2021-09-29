using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.DataObjects;
using WpfClient.DataServices;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataService data;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetMetrics(object sender, RoutedEventArgs e)
        {
            switch (MetricsComboBox.Text)
            {
                case "Cpu Metrics":
                    {
                        data = new DataServiseCpu();
                        MFunction(data, MetricsComboBox.SelectedIndex + 1, DateTimeBoxFrom.Text, DateTimeBoxTo.Text);
                    }; break;
            case "DotNet Metrics":
                {
                        data = new DataServiseDotNet();
                        MFunction(data, MetricsComboBox.SelectedIndex + 1, DateTimeBoxFrom.Text, DateTimeBoxTo.Text);
                    }; break;
            case "Hdd Metrics":
                {
                        data = new DataServiseHdd();
                        MFunction(data, MetricsComboBox.SelectedIndex + 1, DateTimeBoxFrom.Text, DateTimeBoxTo.Text);
                    }; break;
            case "Network Metrics":
                {
                        data = new DataServiseNetwork();
                        MFunction(data, MetricsComboBox.SelectedIndex + 1, DateTimeBoxFrom.Text, DateTimeBoxTo.Text);
                    }; break;
            case "Ram Metrics":
                {
                        data = new DataServiseRam();
                        MFunction(data, MetricsComboBox.SelectedIndex + 1, DateTimeBoxFrom.Text, DateTimeBoxTo.Text);
                    }; break;
            default:
                { 
                   MessageBox.Show("Тип метрики не выбран!"); 
                }; break;
            }
        }

        private void MFunction(DataService dObj, int id, string time1, string time2)
        {
            MetricsList.Items.Clear();
            List<Metric> MetricsListObj = new List<Metric>();
            MetricsListObj = Task<List<Metric>>.Run(() => dObj.GetMetrics(id, time1, time2)).Result;
            
            foreach (Metric value in MetricsListObj)
            {
                MetricsList.Items.Add($"ID:{value.Id}, Value:{value.Value}, Time:{value.Time}");
            }
        }
    }
}