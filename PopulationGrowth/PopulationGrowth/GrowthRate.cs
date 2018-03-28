using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace PopulationGrowth
{
    public class GrowthRate : INotifyPropertyChanged
    {
        CollectionofData _collect = new CollectionofData();
        private Boolean calculatePressed = false;
        private string orgasimString;
        private int durationOfGrowth;
        private double initialPopulation = 0;
        private double dailyGrowth;
        public int increment;
        private double totalPopulation;
        private List<double> chartPoints = new List<double>();
        public SeriesCollection seriesCollection = new SeriesCollection();
        public SeriesCollection SeriesCollection
        {
            get
            {
                return seriesCollection;
            }
            set
            {
                seriesCollection = value; propertyChanged();
            }
        }
        private const string pathSavedData = @"..\..\Config\SavedData.json";

        public string OrganismName
        {
            get { return orgasimString; }
            set { orgasimString = value; }
        }
        public int Duration
        {
            get { return durationOfGrowth; }
            set { durationOfGrowth = value; }
        }
        public double InitialPopulation
        {
            get { return initialPopulation; }
            set { initialPopulation = value; }
        }
        public double DailyGrowth
        {
            get { return dailyGrowth; }
            set { dailyGrowth = value; }
        }

        public void AddToCollection()
        {
            List<double> PopulationRecordLocal = new List<double>();
            totalPopulation = initialPopulation;
            for (int x = 0; x < durationOfGrowth; x++)
            {
                totalPopulation = totalPopulation + Math.Round(totalPopulation * (dailyGrowth / 100), 2);
                PopulationRecordLocal.Add(totalPopulation);
            }
            //adds a new list of objects to collection without overwritting previously added list of objects
            //SavedData is an extention of Collection Class
            _collect.Add(new Organism
            {
                PopulationRecord = PopulationRecordLocal,
                Name = OrganismName,
                GrowthDuration = Duration,
                DailyGrowth = DailyGrowth
            });
        }
        //the objects within _collection is passed through a for loop
        //items will be added to listbox till it reaches the end of the count; the length of PopulationRecord
        public void LoadListBox(MainWindow MW)
        {
            MW.ValueListBox.Items.Clear();
            calculatePressed = true;
            MW.chartGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < _collect.Count; x++)
            {
                for (int y = 0; y < _collect[x].PopulationRecord.Count; y++)
                {
                    MW.ValueListBox.Items.Add("Organism: " + _collect[x].Name + " " + "Day: " + (y + 1).ToString() + " " + "Population: " + _collect[x].PopulationRecord[y].ToString());
                }
                MW.ValueListBox.Items.Add(Environment.NewLine);
            }
            DrawChart();
        }
        //the information is temperary stored within the UI and updates itself every time calculation button is clicked
        //since the data is a collection of objects within a list, the data is not overwritten until clear button is pressed
        public void DrawChart()
        {
            if (calculatePressed)
            {
                SeriesCollection = new SeriesCollection
                {
                };
                for (int x = 0; x < _collect.Count; x++)
                {
                    ChartValues<double> values = new ChartValues<double>();
                    for (int y = 0; y < _collect[x].PopulationRecord.Count; y++)
                    {
                        values.Add(Convert.ToDouble(_collect[x].PopulationRecord[y]));
                    }
                    SeriesCollection.Add(new LineSeries
                    {
                        Title = _collect[x].Name + " Series " + (x + 1).ToString(),
                        Values = values
                    });
                }
            }
        }

        public void ClearChart()
        {
            SeriesCollection.Clear();
            _collect.Clear();
        }

        public void SavetoJson()
        {
            string jsonSavedData = JsonConvert.SerializeObject(_collect);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(pathSavedData, false))
                {
                    outputFile.Write(jsonSavedData);
                }
            }
            catch (Exception entry)
            {
                MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

