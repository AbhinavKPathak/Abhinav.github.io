using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace DrivingTest
{
    class Deserialize
    {
        /// <summary>
        /// Deserializes objects from JSON file and passes to a new list; following the blueprints within the 
        /// DrivingTestAnswers and LocationEntity class
        /// </summary>
        public List<DrivingTestAnswers> DeserializeMasterList(string pathMasterList)
        {
            if (File.Exists(pathMasterList))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(pathMasterList))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<DrivingTestAnswers>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No JSON file found to Deserialize : {0} \n", ex.Message);
                    return new List<DrivingTestAnswers>();
                }
            }
            else
            {
                return new List<DrivingTestAnswers>();
            }
        }

        public List<StudentAnswers> DeserializeStudentList(string pathStudentList)
        {
            if (File.Exists(pathStudentList))
            {
                try
                {
                    using (StreamReader ReadFile = new StreamReader(pathStudentList))
                    {
                        string json = ReadFile.ReadToEnd();
                        ReadFile.Close();
                        return JsonConvert.DeserializeObject<List<StudentAnswers>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No JSON file found to Deserialize : {0} \n", ex.Message);
                    return new List<StudentAnswers>();
                }
            }
            else
            {
                return new List<StudentAnswers>();
            }
        }
    }
}
