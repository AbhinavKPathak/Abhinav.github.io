using System.Windows;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Project Author : Abhinav Pathak
    /// </summary>
    public partial class MainWindow : Window
    {
        public AddPersonWindow AddWindow;
        PersonInformationVM PersonVM = PersonInformationVM.GetInstance;
        Deserialize ds = new Deserialize();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = PersonVM;
            PersonVM.PersonsList = ds.DeserializePerson();
            PersonVM.Singlefetch();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (AddWindow == null)
            {
                AddWindow = new AddPersonWindow(new Person());
                this.Close();
                AddWindow.Show();
            }
            else
            {
                this.Close();
                AddWindow.Show();
            }
        }

        private void MainWindowClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PersonList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PersonVM.ShowPerson(this);
        }

    }
}
