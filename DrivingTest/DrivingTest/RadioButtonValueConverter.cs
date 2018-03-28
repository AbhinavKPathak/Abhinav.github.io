using System;
using System.Globalization;
using System.Windows.Data;

namespace DrivingTest
{
    //casting the radio buttons to toString method
    public class RadioButtonValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string s = (string)parameter;
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
