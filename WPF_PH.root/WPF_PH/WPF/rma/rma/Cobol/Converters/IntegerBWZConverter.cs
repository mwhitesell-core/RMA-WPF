using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace rma.Cobol
{
    public class IntegerBWZConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retValue = "";
            if (value != null)
            {
                if (Util.NumLongInt(value) > 0)
                {
                    retValue = string.Format("{0:#,#}", value);
                }
                else
                {
                    retValue = string.Empty;
                }

            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return Util.Str(value.ToString()).Replace(",", "").Replace(".", "");
            }
            else
            {
                return 0;
            }
        }
    }

    public class IntegerBWZConverterNoComma : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retValue = "";
            if (value != null)
            {
                if (Util.NumLongInt(value) > 0 )
                {
                    if (parameter.ToString().Contains("9(") && parameter.ToString().Contains(")"))
                    {
                        int firstPos = parameter.ToString().IndexOf("(");
                        string data = parameter.ToString().Substring(firstPos + 1);
                        int lastPos = data.ToString().IndexOf(")");
                        int length = Util.NumInt(data.Substring(0, lastPos));
                        retValue = value.ToString().PadLeft(length, '0');
                    }                    
                    else 
                    {
                        int length = parameter.ToString().Length;
                        retValue = value.ToString().PadLeft(length, '0');
                    }                    
                }
                else
                {
                    retValue = string.Empty;
                }

            }
            return retValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return Util.Str(value.ToString()).Replace(",", "").Replace(".", "");
            }
            else
            {
                return 0;
            }
        }
    }
}
