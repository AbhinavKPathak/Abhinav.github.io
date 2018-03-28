using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DrivingTest
{
    /// <summary>
    /// Interaction logic for Pass.xaml page
    /// </summary>
    public partial class Pass : Page
    {
        public Pass()
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
