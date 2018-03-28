using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DrivingTest
{
    class Calculations : INotifyPropertyChanged
    {
        private const string PathStudentList = @"..\..\Config\StudentsSubmission.json";
        public const string pathMasterList = @"..\..\Config\MasterSavedList.json";
        public const string pathStudentList = @"..\..\Config\StudentsSubmission.json";
        private const double PASSING_GRADE = 75;
        public const int NUMBER_OF_QUESTIONS = 20;
        private double Score = 0;
        private string Grade;
        private double Total = 0;
        public SaveDataList list = new SaveDataList();
        public List<string> IncorrectAnswers = new List<string>();
        public List<string> CorrectAnswers = new List<string>();
        public List<DrivingTestAnswers> TestAnswersList { get; set; }
        public List<StudentAnswers> StudentAnswersList { get; set; }
        string[] _saveDataList = new string[NUMBER_OF_QUESTIONS];
        string[] parameter = new string[2];

        //Calculations is static and is only loaded once
        //The values does not change when switching between pages
        public static Calculations _instance;
        public static Calculations Instance {
            get
            {
                if (_instance == null)
                    _instance = new Calculations();

                return _instance;
            }
        }

        public DrivingTestAnswers[] TestAnswersArray
        {
            get
            {
                return TestAnswersList.ToArray();
            }
        }
        public StudentAnswers[] StudentAnswersArray
        {
            get
            {
                return StudentAnswersList.ToArray();
            }
        }

        public void SaveAnswers()
        {
            //starts from 0 of the array and continues till NUMBER_OF_QUESTIONS
            for (int i = 0; i < NUMBER_OF_QUESTIONS; i++)
                list.Add(new StudentAnswers { Question = i + 1, Answer = _saveDataList[i] });
            string jsonLedgerWorkshop = JsonConvert.SerializeObject(list);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(PathStudentList, false))
                {
                    outputFile.Write(jsonLedgerWorkshop);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No JSON file found to serialize : {0} \n", ex.Message);
            }
        }

        //the binding on RadioButton converts the value to a string and is added to _saveDataList[] having question number as index
        //On the binding each radiobutton contains a number associated to the question and a letter based upon the option
        //breaks the parameter into a string array
        public string Q1Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
                _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q2Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q3Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q4Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q5Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                 parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q6Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q7Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q8Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q9Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q10Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q11Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q12Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q13Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q14Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q15Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q16Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q17Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q18Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q19Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        public string Q20Answer
        {
            set
            {
                Array.Clear(parameter, 0, parameter.Length);
                parameter = value.Split('-');
               _saveDataList[int.Parse(parameter[0])-1] = parameter[1];
                NotifyPropertyChanged();
            }
        }
        //This method is used in Text.xaml to only allow the Submit button to be activited once all radio buttons
        //are checked
        public int SavedDataCount()
        {
            int counter = 0;
            for(int i = 0; i<_saveDataList.Length; i++)
            {
                
                if(_saveDataList[i] != null)
                {
                    counter++;
                }
                
            }
            return counter;
        }

        public string TxtCorrectAnswer
        {
            get { return Total.ToString(); }
        }

        public string LblPassingGrade
        {
            get { return Score.ToString() + "%"; }
        }
        public string LblFailingGrade
        {
            get { return Score.ToString() + "%"; }
        }
        public string TxtMarkPercentage
        {
            get { return Score.ToString() + "%"; }
        }

        public string TxtPassingMark
        {
            get { return Grade; }
        }
        /// <summary>
        /// Changes image displayed on the RadioButton to a checkmark and
        /// sets remaining RadioButton images to default.
        /// </summary>
        public void SelectAnswer(RadioButton rb_checked, Test TestPageInstance)
        {
            var imgBrushA = new ImageBrush();
            var imgBrushB = new ImageBrush();
            var imgBrushC = new ImageBrush();
            var imgBrushD = new ImageBrush();
            Grid A, B, C, D;
            string choice = rb_checked.Name.ToString();
            string not_selected = choice.Substring(0, choice.Length - 1);
            switch (choice.Substring(choice.Length - 1, 1))
            {
                case "A":
                    A = (Grid)TestPageInstance.FindName(choice + "Grid");
                    imgBrushA.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Checked.png", UriKind.Relative));
                    A.Background = imgBrushA;
                    B = (Grid)TestPageInstance.FindName(not_selected + "BGrid");
                    imgBrushB.ImageSource = new BitmapImage(new Uri(@"..\..\Images\B.png", UriKind.Relative));
                    B.Background = imgBrushB;
                    C = (Grid)TestPageInstance.FindName(not_selected + "CGrid");
                    imgBrushC.ImageSource = new BitmapImage(new Uri(@"..\..\Images\C.png", UriKind.Relative));
                    C.Background = imgBrushC;
                    D = (Grid)TestPageInstance.FindName(not_selected + "DGrid");
                    imgBrushD.ImageSource = new BitmapImage(new Uri(@"..\..\Images\D.png", UriKind.Relative));
                    D.Background = imgBrushD;
                    break;
                case "B":
                    A = (Grid)TestPageInstance.FindName(not_selected + "AGrid");
                    imgBrushA.ImageSource = new BitmapImage(new Uri(@"..\..\Images\A.png", UriKind.Relative));
                    A.Background = imgBrushA;
                    B = (Grid)TestPageInstance.FindName(choice + "Grid");
                    imgBrushB.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Checked.png", UriKind.Relative));
                    B.Background = imgBrushB;
                    C = (Grid)TestPageInstance.FindName(not_selected + "CGrid");
                    imgBrushC.ImageSource = new BitmapImage(new Uri(@"..\..\Images\C.png", UriKind.Relative));
                    C.Background = imgBrushC;
                    D = (Grid)TestPageInstance.FindName(not_selected + "DGrid");
                    imgBrushD.ImageSource = new BitmapImage(new Uri(@"..\..\Images\D.png", UriKind.Relative));
                    D.Background = imgBrushD;
                    break;
                case "C":
                    A = (Grid)TestPageInstance.FindName(not_selected + "AGrid");
                    imgBrushA.ImageSource = new BitmapImage(new Uri(@"..\..\Images\A.png", UriKind.Relative));
                    A.Background = imgBrushA;
                    B = (Grid)TestPageInstance.FindName(not_selected + "BGrid");
                    imgBrushB.ImageSource = new BitmapImage(new Uri(@"..\..\Images\B.png", UriKind.Relative));
                    B.Background = imgBrushB;
                    C = (Grid)TestPageInstance.FindName(choice + "Grid");
                    imgBrushC.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Checked.png", UriKind.Relative));
                    C.Background = imgBrushC;
                    D = (Grid)TestPageInstance.FindName(not_selected + "DGrid");
                    imgBrushD.ImageSource = new BitmapImage(new Uri(@"..\..\Images\D.png", UriKind.Relative));
                    D.Background = imgBrushD;
                    break;
                case "D":
                    A = (Grid)TestPageInstance.FindName(not_selected + "AGrid");
                    imgBrushA.ImageSource = new BitmapImage(new Uri(@"..\..\Images\A.png", UriKind.Relative));
                    A.Background = imgBrushA;
                    B = (Grid)TestPageInstance.FindName(not_selected + "BGrid");
                    imgBrushB.ImageSource = new BitmapImage(new Uri(@"..\..\Images\B.png", UriKind.Relative));
                    B.Background = imgBrushB;
                    C = (Grid)TestPageInstance.FindName(not_selected + "CGrid");
                    imgBrushC.ImageSource = new BitmapImage(new Uri(@"..\..\Images\C.png", UriKind.Relative));
                    C.Background = imgBrushC;
                    D = (Grid)TestPageInstance.FindName(choice + "Grid");
                    imgBrushD.ImageSource = new BitmapImage(new Uri(@"..\..\Images\Checked.png", UriKind.Relative));
                    D.Background = imgBrushD;
                    break;
            }
        }

        //Compares the textAnswerArray that contains the MasterSavedList against the studentAnswersArray from StudentsSubmission
        //The results will be added to the Listbox which is displayed in Pass.xaml and Fail.xaml
        public bool ArraySearch()
        {
            bool result = false;

            Total = 0;
            for (int i = 0; i < NUMBER_OF_QUESTIONS; i++)
            {
                if (TestAnswersArray[i].Answer == StudentAnswersArray[i].Answer)
                {
                    Total += 1;
                    CorrectAnswers.Add("Q:" + (i + 1) + " - " + StudentAnswersArray[i].Answer);
                }
                else 
                {
                    IncorrectAnswers.Add("Q:" + (i + 1) + " - " +  StudentAnswersArray[i].Answer);
                }

            }
            Score = Math.Round((Total / NUMBER_OF_QUESTIONS) * 100);
            if (Score >= PASSING_GRADE)
            {
                result = true;
                Grade = "Pass";
            }
            if (Score <= PASSING_GRADE)
            {
                result = false;
                Grade = "Fail";
            }

            //Tell UI that TxtCorrectAnswer has changed and needs to update it again
            NotifyPropertyChanged("TxtCorrectAnswer");
            NotifyPropertyChanged("TxtMarkPercentage");
            NotifyPropertyChanged("TxtPassingMark");
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
