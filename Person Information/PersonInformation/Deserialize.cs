using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace AddressBook
{
    class Deserialize
    {
        public const string PersonFilePath = @"..\..\PersonRecords\PersonInformation.json";
        public List<Person> DeserializePerson()
        {
            if (File.Exists(PersonFilePath))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(PersonFilePath))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<Person>>(json);
                    }
                }
                catch (Exception entry)
                {
                    MessageBox.Show(messageBoxText: "no JSON file found" + entry.Message);
                    return new List<Person>();
                }
            }
            else
            {
                return new List<Person>();
            }
        }
    }
}
