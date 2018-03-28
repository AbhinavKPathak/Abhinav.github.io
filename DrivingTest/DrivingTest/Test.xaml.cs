using System.Windows;
using System.Windows.Controls;

namespace DrivingTest
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
            DataContext = Calculations.Instance;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            BtnDetermineGrade.IsEnabled = true;
            BtnSubmit.IsEnabled = false;
            Calculations.Instance.SaveAnswers();
        }

        //depending upon the grade; it will navigate to new page
        public void PassPage()
        {
            NavigationService.Navigate(new Pass());
        }

        public void FailPage()
        {
            NavigationService.Navigate(new Fail());
        }

        private void BtnDetermineGrade_Click(object sender, RoutedEventArgs e)
        {
            //this updates the lists based upon the objects saved to the JSON files
            Deserialize _deserialize = new Deserialize();
            Calculations.Instance.TestAnswersList = _deserialize.DeserializeMasterList(Calculations.pathMasterList);
            Calculations.Instance.StudentAnswersList = _deserialize.DeserializeStudentList(Calculations.pathStudentList);
            bool result = Calculations.Instance.ArraySearch();
            if (result)
            {
                PassPage();
            }
            else
            {
                FailPage();
            }
            BtnDetermineGrade.IsEnabled = false;
            BtnSubmit.IsEnabled = true;
        }
        //passes an instance of Test Page and Checked RadioButton to Calculations for Changing RadioButton Image
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Calculations.Instance.SelectAnswer(rb, this);
        }

        private void EnableSubmit(object sender, RoutedEventArgs e)
        {
            if (Calculations.Instance.SavedDataCount() == Calculations.NUMBER_OF_QUESTIONS)
            {
                BtnSubmit.IsEnabled = true;
                WarningMessage.Opacity = 0;
            }
        }
    }
}
