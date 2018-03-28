using System.Windows;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public Person person;
        public AddPersonWindow(Person person)
        {
            InitializeComponent();
            this.person = person;
            Loaded += AddPersonWindow_Loaded;
        }

        private void AddPersonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (person.Name == null)
                MainFrame.Content = new AddPage(this);
            else
                MainFrame.Content = new DisplayPage(this);
        }
        public void AddWindowClose_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
    }
}
