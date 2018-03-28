using System.Windows;
using System.Windows.Controls;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for DisplayPage.xaml
    /// </summary>
    public partial class DisplayPage : Page
    {
        Person person;
        AddPersonWindow addPersonWindow;
        public DisplayPage(AddPersonWindow addPersonWindow)
        {
            InitializeComponent();
            this.addPersonWindow = addPersonWindow;
            this.person = addPersonWindow.person;
            Name.Text = person.Name;
            Age.Text = person.Age;
            PhoneNumber.Text = person.PhoneNumber;
            DataContext = person;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {          
            PersonInformationVM personInstance = PersonInformationVM.GetInstance;
            personInstance.RemovePerson(person.ID,person.Image);
            Window.GetWindow(this).Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
