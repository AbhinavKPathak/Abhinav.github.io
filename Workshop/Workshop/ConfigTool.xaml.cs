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

namespace Workshop
{
    /// <summary>
    /// Interaction logic for ConfigTool.xaml
    /// </summary>
    public partial class ConfigTool : Window
    {
        private const string pathWorkshop = @"..\..\Config\Workshops.json";
        private const string pathLocation = @"..\..\Config\Location.json";

        public List<WorkshopEntity> Workshops { get; set; }
        public List<LocationEntity> Location { get; set; }

        public ConfigTool()
        {
            InitializeComponent();

            Deserialize _deserialize = new Deserialize();

            Workshops = _deserialize.DeserializeWorkshop(pathWorkshop);
            Location = _deserialize.DeserializeLocation(pathLocation);

            DataContext = this;
        }

        private void ConfigSave_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Hide();
            string jsonLedgerWorkshop = JsonConvert.SerializeObject(Workshops);
            string jsonLedgerLocation = JsonConvert.SerializeObject(Location);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(pathWorkshop, false))
                {
                    outputFile.Write(jsonLedgerWorkshop);
                }
            }
            catch (Exception entry)
            {
                MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
            }
            try
            {
                using (StreamWriter outputFile = new StreamWriter(pathLocation, false))
                {
                    outputFile.Write(jsonLedgerLocation);
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
