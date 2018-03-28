using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AddressBook
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        AddPersonWindow addPersonWindow;
        PersonInformationVM PersonVM = PersonInformationVM.GetInstance;
        Color color = (Color)ColorConverter.ConvertFromString("#50000000");
        public AddPage(AddPersonWindow addPersonWindow)
        {
            InitializeComponent();
            this.addPersonWindow = addPersonWindow;
            DataContext = PersonVM;
            PersonVM.PersonName = "Name";
            PersonVM.PersonAddress1 = "Address1";
            PersonVM.PersonAddress2 = "Address2";
            PersonVM.PersonCity = "City";
            PersonVM.PersonProvince = "Province";
            PersonVM.PersonPostalCode = "Postal Code";
            PersonVM.PersonCountry = "Country";
            PersonVM.PersonAge = "Age";
            PersonVM.PersonPhoneNumber = "Phone Number";
            PersonVM.PersonImage = AppDomain.CurrentDomain.BaseDirectory + @"../../Images/Default.png";
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Text = "";
            t.Foreground = Brushes.Black;
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {

            if (Name.Text == "")
            {
                Name.Text = "Name";
                Name.Foreground = new SolidColorBrush(color);
            }
        }

        private void Address1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Address1.Text == "")
            {
                Address1.Text = "Address1";
                Address1.Foreground = new SolidColorBrush(color);
            }
        }

        private void Address2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Address2.Text == "")
            {
                Address2.Text = "Address2";
                Address2.Foreground = new SolidColorBrush(color);
            }
        }

        private void City_LostFocus(object sender, RoutedEventArgs e)
        {
            if (City.Text == "")
            {
                City.Text = "City";
                City.Foreground = new SolidColorBrush(color);
            }
        }

        private void Province_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Province.Text == "")
            {
                Province.Text = "Province";
                Province.Foreground = new SolidColorBrush(color);
            }
        }

        private void PostalCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PostalCode.Text == "")
            {
                PostalCode.Text = "Postal Code";
                PostalCode.Foreground = new SolidColorBrush(color);
            }
        }

        private void Country_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Country.Text == "")
            {
                Country.Text = "Country";
                Country.Foreground = new SolidColorBrush(color);
            }
        }

        private void Age_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Age.Text == "")
            {
                Age.Text = "Age";
                Age.Foreground = new SolidColorBrush(color);
            }
        }

        private void PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneNumber.Text == "")
            {
                PhoneNumber.Text = "Phone Number";
                PhoneNumber.Foreground = new SolidColorBrush(color);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool success = CheckEmptyValues();
                if (success)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Window.GetWindow(this).Close();
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error : " + error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool CheckEmptyValues()
        {
            string Errors = "";
            if (Name.Text == "Name")
                Errors += "Enter Name\n";
            if (Address1.Text == "Address1")
                Errors += "Enter Address1\n";
            if (Address2.Text == "Address2")
                PersonVM.PersonAddress2 = "";
            if (City.Text == "City")
                Errors += "Enter City\n";
            if (Province.Text == "Province")
                Errors += "Enter Province\n";
            if (PostalCode.Text == "Postal Code")
                Errors += "Enter Postal Code\n";
            if (Country.Text == "Country")
                Errors += "Enter Country\n";
            if (Age.Text == "Age")
                Errors += "Enter Age\n";
            if (PhoneNumber.Text == "Phone Number")
                Errors += "Enter Phone Number\n";

            if (Errors != "")
            {
                MessageBox.Show(Errors, "Error", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return false;
            }
            else
            {
                PersonVM.AddPerson();
                return true;
            }
        }

        private void ImageToggle_Click(object sender, RoutedEventArgs e)
        {
            PersonVM.PersonImageSelect();
        }

        private void Validate(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char Input = e.Text[0];
            TextBox t = sender as TextBox;
            switch (t.Name)
            {
                case "Name":
                    if (!Char.IsLetter(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Address1":
                    if (!Char.IsLetterOrDigit(Input)|| Char.IsSymbol(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Address2":
                    if (!Char.IsLetterOrDigit(Input) || Char.IsSymbol(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "City":
                    if (!Char.IsLetter(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Province":
                    if (!Char.IsLetter(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "PostalCode":
                    if (!Char.IsLetterOrDigit(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Country":
                    if (!Char.IsLetter(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Age":
                    if (!Char.IsDigit(Input))
                    {
                        e.Handled = true;
                    }
                    break;
                case "PhoneNumber":
                   if(!(Char.IsDigit(Input) || Input == '(' || Input == ')' || Input == '-'))
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

      
    }
}
