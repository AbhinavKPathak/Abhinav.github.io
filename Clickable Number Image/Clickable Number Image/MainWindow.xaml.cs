using System.Windows;


namespace Clickable_Number_Image
{
    /// <summary>
    /// Author : Abhinav Pathak 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnImg1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("One","Message");
        }

        private void btnImg2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Two", "Message");
        }

        private void btnImg3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Three", "Message");
        }

        private void btnImg4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Four", "Message");
        }

        private void btnImg5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Five", "Message");
        }
    }
}
