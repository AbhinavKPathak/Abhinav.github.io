using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace PopulationGrowth
{
    class Deserialize
    {
        /// <summary>
        /// Deserializes objects from JSON file and passes to a new list; following the blueprints within the 
        /// WorkshopEntity and LocationEntity class
        /// </summary>
        public List<SavedData> DeserializeWorkshop(string pathWorkshop)
        {
            if (File.Exists(pathWorkshop))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(pathWorkshop))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<SavedData>>(json);
                    }
                }
                catch (Exception entry)
                {
                    MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
                    return new List<SavedData>();
                }
            }
            else
            {
                return new List<SavedData>();
            }
        }
    }
}
