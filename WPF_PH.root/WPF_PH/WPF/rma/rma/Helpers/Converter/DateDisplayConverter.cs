using System;
using System.Globalization;
using System.Windows.Data;

namespace rma.Helpers.Converter
{
    /// <summary>
    /// Converts date for display
    /// </summary>
    public class DateDisplayConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;
            if (parameter != null)
            {
                string formatterString = null;
                switch (parameter as string)
                {
                    case "DateOnly":
                        formatterString = "{0:" +   "}";
                        break;
                }
                if (formatterString != null) result = string.Format(formatterString, value);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            return DateTime.Parse(value.ToString());
        }

        #endregion
    }
}