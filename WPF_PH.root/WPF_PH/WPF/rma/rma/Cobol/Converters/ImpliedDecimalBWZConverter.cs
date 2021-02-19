using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace rma.Cobol
{
    public class ImpliedDecimalBWZConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retValue = "";
            if (value != null)
            {
                if (Util.NumDec(value) != 0)
                {
                    string decimalPlaces = "0".PadRight(Util.NumInt(parameter), '0');
                    retValue = string.Format("{0:#,0." + decimalPlaces + "}", Util.ImpliedDecimal(value.ToString(), Util.NumInt(parameter)));
                } else
                {
                    retValue = string.Empty;
                }
            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal retValue = 0;
            if (value != null)
            {
                string tmpValue = Util.Str(value.ToString()).Replace(",", "").Replace(".", "");
                retValue = Util.NumDec(tmpValue);
            }
            return retValue;
        }
    }
}
