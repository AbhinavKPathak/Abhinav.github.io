using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DrivingTest
{
    /// <summary>
    /// Interaction logic for Fail.xaml page
    /// </summary>
    public partial class Fail : Page
    {
        public Fail()
        {
            InitializeComponent();
            DataContext = Calculations.Instance;
            LbDisplayIncorrect.ItemsSource = Calculations.Instance.IncorrectAnswers;
            LbDisplayCorrect.ItemsSource = Calculations.Instance.CorrectAnswers;
        }

        private void BtnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Test());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
