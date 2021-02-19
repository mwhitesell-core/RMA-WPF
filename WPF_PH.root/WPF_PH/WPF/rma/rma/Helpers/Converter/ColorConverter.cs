using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace rma.Helpers.Converter
{
    public class ColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            if ((bool)value)
            {
                brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}