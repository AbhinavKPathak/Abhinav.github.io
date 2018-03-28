using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace PopulationGrowth
{
    /// <summary>
    /// Interaction logic for ConfigTool.xaml
    /// </summary>
    public partial class ConfigTool : Window
    {
        private const string pathWorkshop = @"..\..\Config\SavedData.json";

        public List<SavedData> PopulationGrowth { get; set; }

        public ConfigTool()
        {
            InitializeComponent();

            Deserialize _deserialize = new Deserialize();

            PopulationGrowth = _deserialize.DeserializeWorkshop(pathWorkshop);

            DataContext = this;
        }

        private void ConfigSave_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Hide();
            string jsonSavedData = JsonConvert.SerializeObject(PopulationGrowth);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(pathWorkshop, false))
                {
                    outputFile.Write(jsonSavedData);
                }
            }
            catch (Exception entry)
            {
                MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
            }

            this.Close();

            //refresh app after saving
            System.Windows.Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }
    }
}
