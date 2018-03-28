using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace DrivingTest
{
    /// <summary>
    /// Interaction logic for ConfigTool.xaml
    /// Assignment 8 | Group 2 | Tahira, Ashley, Abhinav, Parmeet, Haoyang
    /// </summary>
    public partial class ConfigTool : Window
    {
        public ConfigTool()
        {
            InitializeComponent();
            Deserialize _deserialize = new Deserialize();
            Calculations.Instance.TestAnswersList = _deserialize.DeserializeMasterList(Calculations.pathMasterList);
            Calculations.Instance.StudentAnswersList = _deserialize.DeserializeStudentList(Calculations.pathStudentList);
            DataContext = Calculations.Instance;
        }

        //Only Master JSON can edited in ConfigTool
        private void ConfigSave_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Hide();
            string jsonLedgerWorkshop = JsonConvert.SerializeObject(Calculations.Instance.TestAnswersList);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Calculations.pathMasterList, false))
                {
                    outputFile.Write(jsonLedgerWorkshop);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No JSON file found to serialize : {0} \n", ex.Message);
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            Calculations.Instance.ArraySearch();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //refresh app after saving
            System.Windows.Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
        }

        private void ClearStudentEntert_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Calculations.pathStudentList))
            {
                FileStream fileStream = File.Open(Calculations.pathStudentList, FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();
                DgvStudentAnswers.ItemsSource = null;
            }
        }
    }
}
