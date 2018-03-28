using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Workshop
{
    class Deserialize
    {
        /// <summary>
        /// Deserializes objects from JSON file and passes to a new list; following the blueprints within the 
        /// WorkshopEntity and LocationEntity class
        /// </summary>
        public List<WorkshopEntity> DeserializeWorkshop(string pathWorkshop)
        {
            if (File.Exists(pathWorkshop))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(pathWorkshop))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<WorkshopEntity>>(json);
                    }
                }
                catch (Exception entry)
                {
                    MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
                    return new List<WorkshopEntity>();
                }
            }
            else
            {
                return new List<WorkshopEntity>();
            }
        }

        public List<LocationEntity> DeserializeLocation(string pathWorkshop)
        {
            if (File.Exists(pathWorkshop))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(pathWorkshop))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<LocationEntity>>(json);
                    }
                }
                catch (Exception entry)
                {
                    MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
                    return new List<LocationEntity>();
                }
            }
            else
            {
                return new List<LocationEntity>();
            }
        }
    }
}
