using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Drawing.Imaging;
using System.Drawing;

namespace AddressBook
{
    class PersonInformationVM : INotifyPropertyChanged
    {
        public PersonsCollection _collect = new PersonsCollection();
        public List<Person> PersonsList { get; set; }
        int NextRecordId;
        public Boolean Flag = false;
        private static PersonInformationVM Instance;
        public static PersonInformationVM GetInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new PersonInformationVM();
                return Instance;
            }
        }
        private string Name;
        public string PersonName
        {
            get { return Name; }
            set
            {
                if (Name != value)
                    Name = value;
                NotifyPropertyChanged();
            }
        }

        private string Address1;
        public string PersonAddress1
        {
            get { return Address1; }
            set
            {
                if (Address1 != value)
                    Address1 = value;
                NotifyPropertyChanged();
            }
        }

        private string Age;
        public string PersonAge
        {
            get { return Age; }
            set
            {
                if (Age != value)
                    Age = value;
                NotifyPropertyChanged();
            }
        }

        private string PhoneNumber;
        public string PersonPhoneNumber
        {
            get { return PhoneNumber; }
            set
            {
                if (PhoneNumber != value)
                    PhoneNumber = value;
                NotifyPropertyChanged();
            }
        }

        private string Image;
        public string PersonImage
        {
            get { return Image; }
            set
            {
                if (Image != value)
                    Image = value;
                NotifyPropertyChanged();
            }
        }

        private string Address2;
        public string PersonAddress2
        {
            get { return Address2; }
            set
            {
                if (Address2 != value)
                    Address2 = value;
                NotifyPropertyChanged();
            }
        }

        private string City;
        public string PersonCity
        {
            get { return City; }
            set
            {
                if (City != value)
                    City = value;
                NotifyPropertyChanged();
            }
        }

        private string Province;
        public string PersonProvince
        {
            get { return Province; }
            set
            {
                if (Province != value)
                    Province = value;
                NotifyPropertyChanged();
            }
        }


        private string PostalCode;
        public string PersonPostalCode
        {
            get { return PostalCode; }
            set
            {
                if (PostalCode != value)
                    PostalCode = value;
                NotifyPropertyChanged();
            }
        }

        private string Country;
        public string PersonCountry
        {
            get { return Country; }
            set
            {
                if (Country != value)
                    Country = value;
                NotifyPropertyChanged();
            }
        }




        public void PersonImageSelect()
        {
            OpenFileDialog od = new OpenFileDialog
            {
                Filter = "Image files (*.jpg) | *.jpg;"
            };
            od.Multiselect = false;
            bool? result = od.ShowDialog();
            if (result == true)
            {
                Bitmap resizedImage;
                string filename = @"..\..\Images\" + NextRecordId + ".jpg";
                using (Image originalImage = System.Drawing.Image.FromFile(od.FileName))
                    resizedImage = new Bitmap(originalImage, 800, 800);

                // Save resized picture
                resizedImage.Save(filename, ImageFormat.Jpeg);
                resizedImage.Dispose();
                PersonImage = AppDomain.CurrentDomain.BaseDirectory + filename;
            }
        }

        private Person Selected_Person;
        public Person SelectedPerson
        {
            get { return Selected_Person; }
            set
            {
                if (Selected_Person != value)
                    Selected_Person = value;
                NotifyPropertyChanged();
            }
        }

        public void ShowPerson(MainWindow mw)
        {
            AddPersonWindow apd = new AddPersonWindow(Selected_Person);
            apd.Show();
            if (mw != null)
                mw.Close();

            mw = new MainWindow();
        }

        public void RemovePerson(int PersonID,string PersonImage)
        {
            _collect.RemoveAll(x => x.ID == PersonID);
            File.Delete(PersonImage);
            SavetoJson();
        }
        public void Singlefetch()
        {
            if (!Flag)
            {
                _collect.Clear();
                if (PersonsList != null && PersonsList.Count != 0)
                {
                    foreach (Person p in PersonsList)
                    {
                        _collect.Add(p);
                    }
                    Flag = true;
                    NextRecordId = PersonsList[PersonsList.Count - 1].ID + 1;
                }
                else
                {
                    NextRecordId = 1;
                }
            }
        }
        public void AddPerson()
        {

            _collect.Add(new Person
            {
                ID = NextRecordId,
                Name = Name,
                Address1 = Address1,
                Address2 = Address2,
                City = City,
                Province = Province,
                PostalCode = PostalCode,
                Country = Country,
                Age = Age,
                PhoneNumber = PhoneNumber,
                Image = Image
            });
            SavetoJson();
            NextRecordId++;
        }
        public void SavetoJson()
        {
            string jsonSavedData = JsonConvert.SerializeObject(_collect);
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Deserialize.PersonFilePath, false))
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
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
