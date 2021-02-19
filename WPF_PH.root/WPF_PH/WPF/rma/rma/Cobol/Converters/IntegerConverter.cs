using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace rma.Cobol
{
    public class IntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retValue = "";
            if (value != null)
            {
                retValue =  string.Format("{0:#,0}", Util.NumInt(value));
            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int retValue = 0;
            if (value != null)
            {
                string tmpValue = Util.Str(value.ToString()).Replace(",", "").Replace(".", "");
                retValue = Util.NumInt(tmpValue);
            }
            return retValue;
        }
    }
}
