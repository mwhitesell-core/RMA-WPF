using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace rma.Cobol
{
    public class ImpliedDecimalNegSignBack : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retValue = "";
            if (value != null)
            {
                string decimalPlaces = "0".PadRight(Util.NumInt(parameter), '0');                
                string format = "#,0." + decimalPlaces;

                if (Util.NumDec(value) >= 0)
                {
                    retValue = string.Format("{0:" + format + "}", Util.ImpliedDecimal(value.ToString(), Util.NumInt(parameter)));
                }
                else
                {
                    retValue = string.Format("{0:" + format + "}", Util.ImpliedDecimal(value.ToString(), Util.NumInt(parameter))).Replace("-", "") + "-";
                }                
            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal retValue = 0;
            if ( value != null)
            {
                if (Util.Str(value.ToString()).Contains("."))
                {
                    value = value.ToString().Replace(",", "");
                    string decimalPlaces = "0".PadRight(Util.NumInt(parameter), '0');
                    string tmpValue = string.Format("{0:#." + decimalPlaces + "}", Util.ImpliedDecimal(value.ToString(), Util.NumInt(parameter)));
                    tmpValue = tmpValue.Replace(".", "");
                    retValue = Util.NumDec(tmpValue);
                }
                else
                {
                    string tmpValue = Util.Str(value.ToString()).Replace(",", "");
                    retValue = Util.NumDec(tmpValue);
                }
            }
            return retValue;
        }
    }
}
