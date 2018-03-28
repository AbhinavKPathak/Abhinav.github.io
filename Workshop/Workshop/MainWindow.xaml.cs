using System.Windows;
using System.Windows.Controls;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Members : Abhinav Pathak, Ashley Gellert
    /// </summary>
    public partial class MainWindow : Window
    {
        Invoice _invoice = new Invoice();
        Deserialize _deserialize = new Deserialize();

        private const string pathWorkshop = @"..\..\Config\Workshops.json";
        private const string pathLocation = @"..\..\Config\Location.json";

        public MainWindow()
        {
            InitializeComponent();

            _invoice.WorkshopsList = _deserialize.DeserializeWorkshop(pathWorkshop);
            //Workshop JSON
            _invoice.LocationList = _deserialize.DeserializeLocation(pathLocation);
            //Location JSON
            DataContext = _invoice;
        }

        //passes the objects of user selection to _invoice to be calculated and set to Total.text
        private void Workshop_Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkshopEntity workshop = (WorkshopEntity)Workshop_Options.SelectedItem;
            _invoice.Workshop = workshop;
        }

        private void Location_Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocationEntity location = (LocationEntity)Location_Options.SelectedItem;
            _invoice.Location = location;
        }

        private void ConfigTool_Form_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ConfigTool openConfigTool = new ConfigTool();
            openConfigTool.Show();
            this.Hide();
        }
    }
}
