using System;
using System.Windows;
using System.Windows.Controls;

namespace Joe_s_Automotive
{
    /// <summary>
    /// Author: Abhinav Pathak
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculations cal = new Calculations();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = cal;
        }

        private void CalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            SubTotalAmount.Content = Math.Round((cal.TotalCharges() - cal.TaxCharges()),2);
            TaxAmount.Content = cal.TaxCharges().ToString("c");
            TotalAmount.Content = "$" + Math.Round((Decimal.Parse(SubTotalAmount.Content.ToString()) + cal.TaxCharges()),2);
            SubTotalAmount.Content = "$" + SubTotalAmount.Content;
            BillList.ItemsSource = cal.Bill;
            CalculateTotal.IsEnabled = false;
        }

        //Checks whether the given input is a Digit or not.
        private void ValidateInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char input = e.Text[0];
            TextBox t = sender as TextBox;
            if (t.Text.Length > 5)
                e.Handled = true;
            if (!char.IsDigit(input))
            {
                if (input == '.')
                {
                    if (t.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled=true;
                }
            }

        }

        //Clears the UI for selecting oil change and lube job.
        private void ClearOilLube()
        {
            OilCheck.IsChecked = false;
            LubeJob.IsChecked = false;
        }

        //Clears the UI for selecting radiator and transmission flush.
        private void ClearFlushes()
        {
            RadiatorFlush.IsChecked = false;
            TransmissionFlush.IsChecked = false;
        }

        //Clears the UI for inspection, muffler replacement, and tire rotation. 
        private void ClearMisc()
        {
            Inspection.IsChecked = false;
            MufflerReplacement.IsChecked = false;
            TireRotation.IsChecked = false;
        }

        //Clears the UI collecting user data for parts and labor .
        private void ClearOther()
        {
            PartsCharge.Clear();
            LabourHours.Clear();
        }

        //clears the tax and total area of the form.
        private void ClearTaxAndTotal()
        {
            SubTotalAmount.Content = "";
            TaxAmount.Content = "";
            TotalAmount.Content = "";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            cal.Bill.Clear();
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearTaxAndTotal();
            CalculateTotal.IsEnabled = true;
            cal.TotalCharge = 0;
        }

        private void PartsCharge_GotFocus(object sender, RoutedEventArgs e)
        {
            PartsCharge.Clear();
        }

        private void LabourHours_GotFocus(object sender, RoutedEventArgs e)
        {
            LabourHours.Clear();
        }

        //Sets value to 0 if user does not input anything.
        private void PartsCharge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PartsCharge.Text == "")
                PartsCharge.Text = "0";
        }

        //Sets value to 0 if user does not input anything.
        private void LabourHours_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LabourHours.Text == "")
                LabourHours.Text = "0";
        }
    }
}
