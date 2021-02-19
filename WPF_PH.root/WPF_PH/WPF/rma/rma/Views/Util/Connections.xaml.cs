using System.Configuration;
using System.Windows;
using System.Windows.Controls;


namespace rma.Views
{
    /// <summary>
    /// Interaction logic for Connections.xaml
    /// </summary>
    public partial class Connections : Window
    {
        public string rmaDataConnection = "";
        public string FilesDataConnection = "";
        public string LoggingDataConnection = "";

        public Connections()
        {
            InitializeComponent();

            for (int i = 1; i < 11; i++)
            {
                if (ConfigurationManager.AppSettings["ConnectionString" + i] != null)
                    comboBox1.Items.Add((ConfigurationManager.AppSettings["rmaConnectionString" + i]));
            }

            comboBox1.SelectedItem = comboBox1.Items[0];

            for (int i = 1; i < 11; i++)
            {
                if (ConfigurationManager.AppSettings["FileFbConnectionString" + i] != null)
                    comboBox2.Items.Add((ConfigurationManager.AppSettings["FileFbConnectionString" + i]));
            }

            comboBox2.SelectedItem = comboBox2.Items[0];

            for (int i = 1; i < 11; i++)
            {
                if (ConfigurationManager.AppSettings["LoggingConnectionString" + i] != null)
                    comboBox3.Items.Add((ConfigurationManager.AppSettings["LoggingConnectionString" + i]));
            }

            comboBox3.SelectedItem = comboBox3.Items[0];
        }

        private void comboBox1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rmaDataConnection = comboBox1.Text;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            rmaDataConnection = comboBox1.Text;
            FilesDataConnection = comboBox2.Text;
            LoggingDataConnection = comboBox3.Text;

            if (rmaDataConnection.Length > 0 && FilesDataConnection.Length > 0 && LoggingDataConnection.Length > 0)
                Close();
        }

        private void comboBox2SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilesDataConnection = comboBox2.Text;
        }

        private void comboBox3SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoggingDataConnection = comboBox3.Text;
        }
    }
}