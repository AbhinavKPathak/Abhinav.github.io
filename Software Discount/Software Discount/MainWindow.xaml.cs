using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Software_Discount
{
    ///Abhinav Pathak, Ashley Gellert
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double PackagePrice = 99.00;
        double cashout;
        double TotalPrice, TotalAfterDiscount;
        int AmountSold;
        int SuggestedAmount;
        int ctr = 0;
        int adpurchasedflag;
        int adpurchasedcourse;
        int adTrack = 0, adTrack1 = 0;

        private void CalculatorTheme_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary rd;
            rd = Application.LoadComponent(new Uri("CalculatorTheme.xaml.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            Application.Current.Resources = rd;
        }

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer
            {
                // Specify timer interval.
                Interval = new TimeSpan(0, 0, 5)
            };
            // Specify timer event handler function.
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            suggestion.Visibility = Visibility.Collapsed;
            Txt_Amt_Sold.Focus();
        }

        //timer for second ad to appear
        private void Timer_Tick(object sender, EventArgs e)
        {
            Image tb = (Image)this.FindName("KeyStorage");

            if (ctr == 0)
            {
                tb.Visibility = Visibility.Collapsed;
                ctr = 1;
            }
            else
            {
                tb.Visibility = Visibility.Visible;
                ctr = 0;
            }
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (adpurchasedflag == 1 && adpurchasedcourse == 0)
            {
                MessageBox.Show("Thank you for shopping with us\n Your total for Anima Designer Product with key code storage is : " + "\n" + cashout);
            }
            else if (adpurchasedcourse == 1 && adpurchasedflag == 0)
            {
                MessageBox.Show("Thank you for shopping with us\n Your total for Anima course and Anima Designer Product is : " + cashout);
            }
            else if (adpurchasedflag == 1 && adpurchasedcourse == 1)
            {
                try
                {
                    cashout = (TotalAfterDiscount + 1100);
                    MessageBox.Show("Thank you for shopping with us\n Your total for Anima course, key code storage, and Anima Designer Product is : " + cashout);
                }
                catch (Exception)
                {
                    MessageBox.Show("Not a valid input");
                }
            }
            else
            {
                MessageBox.Show("Thank you for shopping with us\nYour total for Anima Designer is : " + TotalAfterDiscount.ToString());
            }
            //clear boxes
            ClearForm();
        }

        private void ClearForm()
        {
            Txt_Amt_Sold.Clear();
            Ttl_Before_Discount.Clear();
            Discount_Amount.Clear();
            Discount_Percent.Clear();
            Total_Amount.Clear();
            adTrack = 0;
            adTrack1 = 0;
            Txt_Amt_Sold.Focus();
        }

        //prevents user to input anything but a whole number
        private void Txt_Amt_Sold_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char ch = e.Text[0];

            if (!Char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void Txt_Amt_Sold_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Txt_Amt_Sold.Text != "")
                Checkinput(int.Parse(Txt_Amt_Sold.Text));
        }

        //case for checking user input and displaying a suggestion based upon amount of softwar units ordered
        private void Checkinput(int amount)
        {
            switch (amount)
            {
                case int n when (n < 10):
                    suggestion.Visibility = Visibility.Visible;
                    suggestion.IsChecked = false;
                    suggestion.Content = "Do you want to buy 10 packages to get 20% discount?";
                    SuggestedAmount = 10;
                    break;

                case 18:
                case 19:
                    suggestion.Visibility = Visibility.Visible;
                    suggestion.IsChecked = false;
                    suggestion.Content = "Do you want to buy 20 packages to get 30% discount?";
                    SuggestedAmount = 20;
                    break;

                case int n when (n > 45 && n < 50):
                    suggestion.Visibility = Visibility.Visible;
                    suggestion.IsChecked = false;
                    suggestion.Content = "Do you want to buy 50 packages to get 40% discount?";
                    SuggestedAmount = 50;
                    break;

                case int n when (n > 95 && n < 100):

                    suggestion.Visibility = Visibility.Visible;
                    suggestion.IsChecked = false;
                    suggestion.Content = "Do you want to buy 100 packages to get 50% discount?";
                    SuggestedAmount = 100;
                    break;

                default:
                    suggestion.Visibility = Visibility.Collapsed;
                    suggestion.IsChecked = false;
                    break;
            }
        }

        private void Suggestion_Checked(object sender, RoutedEventArgs e)
        {
            Txt_Amt_Sold.Text = SuggestedAmount.ToString();
            Txt_Amt_Sold.Focus();
            Total_Amount.Focus();
        }

        private void TextGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender == Txt_Amt_Sold)
            {
                Txt_Amt_Sold.Text = "";
            }
        }

        private void KeyStorage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (adTrack == 0)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save key codes with Anima?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (Txt_Amt_Sold.Text != "" && Total_Amount.Text != "")
                        {
                            cashout = (TotalAfterDiscount + 100);
                            Total_Amount.Text += " + " + "$" + (10 * 10).ToString();
                            adpurchasedflag = 1;
                            adTrack = 1;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not a valid input");
                    }
                }
            }
        }

        private void CoursePackage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (adTrack1 == 0)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to buy additional courses?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (Txt_Amt_Sold.Text != "" && Total_Amount.Text != "")
                        {
                            cashout = (TotalAfterDiscount + 1000);

                            Total_Amount.Text += " + " + "$" + (100 * 10).ToString();
                            adpurchasedcourse = 1;
                            adTrack1 = 1;
                        }//each course is 100 bucks
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not a valid input");
                    }
                }
            }
        }

        private void Txt_Amt_Sold_LostFocus(object sender, RoutedEventArgs e)
        {
            //Discounts are available, depending on the quantity selected.Here is a list
            //of quantity discounts:
            //course will have same discounts
            //10 - 19       20% discount
            //20 - 49       30% discount
            //50 - 99       40% discount
            //100 or more   50% discount

            // Declare the Variables
            // PackagePrice is the price of 1 package before the discount.
            // AmountSold quantity of the products customer has selected. 
            // TotalPrice is the price of the total.
            // DiscountRate is the weight of discount depending on the total amount sold.
            // TotalAfterDiscount is the TotalPrice with discoun

            string DiscountLabel;

            if (Txt_Amt_Sold.Text != "")
                AmountSold = int.Parse(Txt_Amt_Sold.Text);
           

            //Declare the variables for the calculation
            TotalPrice = AmountSold * PackagePrice;
            TotalAfterDiscount = TotalPrice;
            DiscountLabel = "";

            //If user inputs an ammount less then 10 there is no discount.
            if (AmountSold < 10)
            {
                DiscountLabel = "";
                TotalAfterDiscount = TotalPrice;
                Discount_Amount.Text = "$" + 0.ToString();
            }
            //if user inputs amount between 10-19 they recieve discount of 20%
            else
            if (AmountSold >= 10 && AmountSold <= 19)
            {
                DiscountLabel = "20%";
                TotalAfterDiscount = TotalPrice * (1 - 0.2);
                Discount_Amount.Text = "$" + (TotalPrice * 0.2).ToString();
            }
            //if user inputs amount between 20-49 they recieve discount of 30%
            else
            if (AmountSold >= 20 && AmountSold <= 49)
            {
                DiscountLabel = "30%";
                TotalAfterDiscount = TotalPrice * (1 - 0.3);
                Discount_Amount.Text = "$" + (TotalPrice * 0.3).ToString();
            }
            //if user inputs amount between 50-100 they recieve a discount of 40%
            else
            if (AmountSold >= 50 && AmountSold <= 99)
            {
                DiscountLabel = "40%";
                TotalAfterDiscount = TotalPrice * (1 - 0.4);
                Discount_Amount.Text = "$" + (TotalPrice * 0.4).ToString();
            }
            //if user inputs amount greater then a 100 they recieve discount of 50%
            else
            if (AmountSold >= 100)
            {
                DiscountLabel = "50%";
                TotalAfterDiscount = TotalPrice * (1 - 0.5);
                Discount_Amount.Text = "$" + (TotalPrice * 0.5).ToString();
            }
            //converts the discount from a decimal into a string and inputs it into the specific text boxes
            Ttl_Before_Discount.Text = "$" + TotalPrice.ToString();
            Total_Amount.Text = "$" + TotalAfterDiscount.ToString();
            Discount_Percent.Text = DiscountLabel;
        }
    }
}