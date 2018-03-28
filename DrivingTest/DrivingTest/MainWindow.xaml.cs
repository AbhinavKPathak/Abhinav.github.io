using System.Windows;

namespace DrivingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Members : Abhinav Pathak, Ashley Gallert
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += DriverLicenceTest_Loaded;
        }

        private void ConfigTool_Form_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ConfigTool openConfigTool = new ConfigTool();
            openConfigTool.Show();
            this.Hide();
        }

        private void DriverLicenceTest_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Test();
        }        
    }
}
