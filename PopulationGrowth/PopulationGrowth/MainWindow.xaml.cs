using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace PopulationGrowth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Assignment 5 | Group 2 | Tahira, Ashley, Abhinav, Parmeet, Haoyang
    /// </summary>
    public partial class MainWindow : Window
    {
        GrowthRate _growthRate = new GrowthRate();

        private const string pathSavedData = @"..\..\Config\SavedData.json";

        public MainWindow()
        {
            InitializeComponent();
            _growthRate.LoadListBox(this);
            chartGrid.Visibility = Visibility.Collapsed;
            DataContext = _growthRate;
        }

        //assigning the DataContext to the property of the MainWindow
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            _growthRate.AddToCollection();
            _growthRate.LoadListBox(this);
        }

        private void Saved_Click(object sender, RoutedEventArgs e)
        {
            _growthRate.SavetoJson();

            Label tb = (Label)this.FindName("fadingtext");
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(1));
            tb.BeginAnimation(Label.OpacityProperty, animation);

            // Want to make the label disappear 3 seconds from now
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += new EventHandler(delegate (object s, EventArgs e2)
            {
                animation = new DoubleAnimation(0, TimeSpan.FromSeconds(1));
                tb.BeginAnimation(Label.OpacityProperty, animation);
                timer.Stop();
            });
            timer.Start();
        }

        private void InputText_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            char c = e.Text[0];
            TextBox t = sender as TextBox;
            if (char.IsLetter(c) || t.Text.Length > 5)
                e.Handled = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ValueListBox.Items.Clear();
            DailyGrowth.Clear();
            InitialPopulation.Clear();
            Duration.Clear();
            Organism_Name.Clear();
            _growthRate.ClearChart();
        }

        private void _CustomerService_Loaded(object sender, RoutedEventArgs e)
        {
            DailyGrowth.Clear();
            InitialPopulation.Clear();
            Duration.Clear();
        }

        private void Organism_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Organism_Name.Text.Trim().Length > 0 && Duration.Text.Trim().Length > 0 && InitialPopulation.Text.Trim().Length > 0 && DailyGrowth.Text.Trim().Length > 0)
            {
                CalculateButton.IsEnabled = true;
            }
        }

        private void Duration_TextChanged(object sender, TextChangedEventArgs e)
        {
            Organism_Name_TextChanged(sender, e);
        }

        private void InitialPopulation_TextChanged(object sender, TextChangedEventArgs e)
        {
            Organism_Name_TextChanged(sender, e);
        }

        private void DailyGrowth_TextChanged(object sender, TextChangedEventArgs e)
        {
            Organism_Name_TextChanged(sender, e);
        }
    }

}
