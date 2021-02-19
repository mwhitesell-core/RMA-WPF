using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Diagnostics;



namespace rma.Cobol
{
    public static class Util
    {
        public static byte[] Key = {
                                       23,
                                       22,
                                       86,
                                       33,
                                       11,
                                       3,
                                       67,
                                       21,
                                       21,
                                       53,
                                       8,
                                       98,
                                       249,
                                       43,
                                       98,
                                       103,
                                       38,
                                       104,
                                       105,
                                       43,
                                       222,
                                       34,
                                       45,
                                       89
                                   };

        public static byte[] Iv = {
                                      45,
                                      11,
                                      45,
                                      37,
                                      42,
                                      68,
                                      102,
                                      79
                                  };

        public static string Encrypt(string PlainText)
        {
            // Declare a UTF8Encoding object so we may use the GetByte 
            // method to transform the plainText into a Byte array. 
            var utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(PlainText);

            // Create a new TripleDES service provider 
            var tdesProvider = new TripleDESCryptoServiceProvider();

            // The ICryptTransform interface uses the TripleDES 
            // crypt provider along with encryption key and init vector 
            // information 

            ICryptoTransform cryptoTransform = null;

            cryptoTransform = tdesProvider.CreateEncryptor(Key, Iv);


            // All cryptographic functions need a stream to output the 
            // encrypted information. Here we declare a memory stream 
            // for this purpose. 
            var encryptedStream = new MemoryStream();
            var cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);
            string strResult = null;

            // Write the encrypted information to the stream. Flush the information 
            // when done to ensure everything is out of the buffer. 
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;

            // Read the stream back into a Byte array and return it to the calling 
            // method. 
            var bytResultBytes = new byte[Convert.ToInt16(encryptedStream.Length)];

            encryptedStream.Read(bytResultBytes, 0, Convert.ToInt16(encryptedStream.Length));
            cryptStream.Close();
            encryptedStream.Close();
            strResult = Convert.ToBase64String(bytResultBytes);
            return strResult;
        }

        public static string ConnectionStringDecrypt(string ConnectionString)
        {
            string password = ConnectionString.Substring(ConnectionString.ToUpper().IndexOf("PASSWORD") + 8);
            password = password.Substring(password.IndexOf("=") + 1);
            password = password.Substring(0, password.IndexOf(";"));

            return ConnectionString.Replace(password, Decrypt(password));
        }

        public static string Decrypt(string EncryptedString)
        {
            // UTFEncoding is used to transform the decrypted Byte Array 
            // information back into a string. 
            var utf8encoder = new UTF8Encoding();
            var tdesProvider = new TripleDESCryptoServiceProvider();
            byte[] bytInputBytes = null;
            // As before we must provide the encryption/decryption key along with 
            // the init vector. 
            ICryptoTransform cryptoTransform = null;
            cryptoTransform = tdesProvider.CreateDecryptor(Key, Iv);


            // Provide a memory stream to decrypt information into 
            var decryptedStream = new MemoryStream();
            var cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);

            bytInputBytes = Convert.FromBase64String(EncryptedString);
            cryptStream.Write(bytInputBytes, 0, bytInputBytes.Length);
            cryptStream.FlushFinalBlock();
            decryptedStream.Position = 0;

            // Read the memory stream and convert it back into a string 
            var result = new byte[Convert.ToInt16(decryptedStream.Length)];
            decryptedStream.Read(result, 0, Convert.ToInt16(decryptedStream.Length));
            cryptStream.Close();
            decryptedStream.Close();

            return utf8encoder.GetString(result);
        }

        public static string GetDefaultPrinter()
        {
            var settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }

        public static bool IsNumeric(string value)
        {
            //if (value.Trim().Length == 0) return true;
            value = value.Replace(",", "");
            decimal number;
            bool result = decimal.TryParse(value, out number);
            return result;
        }

        public static bool IsNumericValue(string value)
        {
            if (value.IndexOf(" ") > -1) return true;
            value = value.Replace(",", "");
            decimal number;
            bool result = decimal.TryParse(value, out number);
            return result;
        }

        public static int NumInt(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;

            if (value.ToString().IndexOf(".") >= 0)
                value = value.ToString().Substring(0, value.ToString().IndexOf("."));

            if (IsNumeric(value.ToString()))
                return Convert.ToInt32(value);
            else
                return 0;
        }

        public static long NumLongInt(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;

            if (value.ToString().IndexOf(".") >= 0)
                value = value.ToString().Substring(0, value.ToString().IndexOf("."));
            if (IsNumeric(value.ToString()))
                return Convert.ToInt64(value);
            else
                return 0;
        }

        public static void Trakker(int ctr, string method)
        {
            /*if (ctr == 241 || ctr == 288 )
            {
                string breakline = "";
            } */
            Debug.WriteLine(ctr.ToString() + " : " + method);
        }

        public static void Trakker_Value(int ctr, string method, string value)
        {
            Debug.WriteLine(ctr.ToString() + " : " + method + " value : " + value);
        }

        public static decimal AddDecimalPoint(decimal value, int denominator)
        {
            return value / denominator;
        }

        public static string ImpliedIntegerFormat(string format, int value, int length, bool plusNegativeSignRight = true)
        {
            string retValue = "";

            if (Util.NumInt(value) >= 0)
            {
                if (plusNegativeSignRight)
                {
                    retValue = string.Format("{0:" + format + "}", value).PadLeft(length - 1) + " ";
                }
                else
                {
                    retValue = string.Format("{0:" + format + "}", value).PadLeft(length);
                }
            }
            else
            {
                if (plusNegativeSignRight)
                {
                    retValue = string.Format("{0:" + format + "}", value).Replace("-", "").PadLeft(length - 1) + "-";
                }
                else
                {
                    retValue = string.Format("{0:" + format + "}", value).PadLeft(length);
                }
            }
            return retValue;
        }

        public static decimal ImpliedDecimal(string value, int decimalPlaces)
        {
            string retValue = "";

            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!value.Trim().Contains("."))
                {
                    if (value.Trim().Length > decimalPlaces)
                    {
                        if (decimalPlaces > 2)
                        {
                            retValue = value.Substring(0, value.Length - decimalPlaces) + "." + value.Substring(value.Length - decimalPlaces);
                        }
                        else
                        {
                            retValue = value.Substring(0, value.Length - 2) + "." + value.Substring(value.Length - 2);
                        }
                    }
                    else if (value.Trim().Length == decimalPlaces)
                    {
                        if (value.Contains("-"))
                        {
                            if (value.Replace("-", "").Trim().Length <= decimalPlaces)
                            {
                                if (decimalPlaces == 1)
                                {
                                    retValue = Decimal.Divide(NumDec(value), 10).ToString();
                                }
                                else if (decimalPlaces == 2)
                                {
                                    retValue = Decimal.Divide(NumDec(value), 100).ToString();
                                }
                                else if (decimalPlaces == 3)
                                {
                                    retValue = Decimal.Divide(NumDec(value), 1000).ToString();
                                }
                                else if (decimalPlaces == 4)
                                {
                                    retValue = Decimal.Divide(NumDec(value), 10000).ToString();
                                }
                                else
                                {
                                    retValue = value + "." + "0".PadLeft(decimalPlaces, '0');
                                }
                            }
                            else
                            {
                                retValue = value + "." + "0".PadLeft(decimalPlaces, '0');
                            }
                        }
                        else
                        {
                            retValue = "." + value;
                        }
                    }
                    else
                    {
                        retValue = "." + value.PadLeft(decimalPlaces, '0');
                    }
                }
                else
                {
                    retValue = value;
                }
            }
            return Convert.ToDecimal(retValue);
        }
        // String.Format("{0:#,0.00}", r123a_p3_gross_child)
        public static string ImpliedDecimalFormat(string format, decimal value, int decimalPlaces, int length, bool plusNegativeSignRight = true, bool isSingleCommaSeparator = false)
        {
            string retValue = "";

            if (Util.NumDec(value) >= 0)
            {
                if (plusNegativeSignRight)
                {
                    retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces)).PadLeft(length - 1) + " ";

                }
                else
                {
                    retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces)).PadLeft(length);
                }
            }
            else
            {
                if (plusNegativeSignRight)
                {
                    retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces)).Replace("-", "").PadLeft(length - 1) + "-";
                }
                else
                {
                    retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces)).PadLeft(length);
                }
            }

            if (isSingleCommaSeparator)
            {
                if (retValue.Contains(","))
                {
                    string[] tmpSplitValues = retValue.Split(',');
                    if (tmpSplitValues.Length >= 3)
                    {
                        string tmpRetValue = string.Empty;
                        for (int i = 0; i < tmpSplitValues.Length - 1; i++)
                        {
                            tmpRetValue += tmpSplitValues[i];
                        }
                        tmpRetValue = tmpRetValue + "," + tmpSplitValues[tmpSplitValues.Length - 1];
                        retValue = tmpRetValue.PadLeft(length);
                    }
                }
            }

            return retValue;
        }

        public static string ImpliedDecimalSpace(string value, int decimalPlaces)
        {
            string retValue = "";

            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!value.Trim().Contains("."))
                {
                    if (value.Trim().Length > decimalPlaces)
                    {
                        retValue = value.Substring(0, value.Length - 2) + " " + value.Substring(value.Length - 2);
                    }
                    else if (value.Trim().Length == decimalPlaces)
                    {
                        retValue = " " + value;
                    }
                    else
                    {
                        retValue = " " + value.PadLeft(decimalPlaces, '0');
                    }
                }
                else
                {
                    retValue = value;
                }
            }
            return retValue;
        }
        public static string ImpliedDecimalFormatSpace(string format, decimal value, int decimalPlaces, int length, bool spaceBetweenCurrencySign = true)
        {
            string retValue = string.Empty;

            if (spaceBetweenCurrencySign)
            {
                retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces)).Replace("$", "");
                retValue = "$" + retValue.Replace('.', ' ').PadLeft(length - 1, ' ');
            }
            else
            {
                retValue = string.Format("{0:" + format + "}", ImpliedDecimal(value.ToString(), decimalPlaces));
                retValue = retValue.PadLeft(length);
            }
            return retValue;
        }

        public static string StrSignDecimal(int value, int length, bool positiveShowSign = true)
        {
            string retVal = string.Empty;

            if (Util.NumInt(value) > 0)
            {
                if (positiveShowSign)
                {
                    retVal = "+" + Util.Str(value).PadLeft(length - 1, '0');
                }
                else
                {
                    retVal = Util.Str(value).PadLeft(length - 1, '0');
                }
            }
            else if (value == 0)
            {
                retVal = " ".PadRight(length - 1);
            }
            else
            {
                retVal = "-" + Util.Str(value).Replace('-', ' ').Trim().PadLeft(length - 1, '0');
            }
            return retVal;
        }

        public static string BlankWhenZero(int value, int length)
        {
            if (value == 0)
            {
                return new string(' ', length);
            }
            else
            {
                return Util.Str(value).PadLeft(length, '0');
            }
        }

        public static string BlankWhenZero(string value, int length)
        {
            if (value == "0" || NumDec(value) == 0M)
            {
                return new string(' ', length);
            }
            else
            {
                return Str(value).PadRight(length, ' ');
            }
        }


        public static string BlankWhenZero(string format, int value, int length)
        {
            if (value == 0)
            {
                return new string(' ', length);
            }
            else
            {
                return ImpliedIntegerFormat(format, value, length);
            }
        }

        public static string BlankWhenZero(string format, decimal value, int decimalPlaces, int length, bool plusNegativeSignRight = true, bool isSingleCommaSeparator = false)
        {
            if (value == 0)
            {
                return new string(' ', length);
            }
            else
            {
                // return ImpliedIntegerFormat(format, value, length);
                return ImpliedDecimalFormat(format, value, decimalPlaces, length, plusNegativeSignRight, isSingleCommaSeparator);
            }
        }

        public static string ConvertZone(int value, int length, bool leftPadZeroes = false)
        {
            //Ex: Util.ConvertZone(Util.NumInt(obj.Wk_ohip_fee), 9) +   //  s9(6)v99   
            string retVal = string.Empty;

            if (Util.NumInt(value) > 0)
            {
                retVal = Util.Str(value).PadLeft(length - 1, '0');
            }
            else if (value == 0)
            {
                if (leftPadZeroes)
                {
                    retVal = "0".PadRight(length - 1, '0');
                }
                else
                {
                    retVal = " ".PadRight(length - 1);
                }
            }
            else
            {
                string tmpValue = Util.Str(value).Replace('-', ' ').Trim();
                int lastDigit = Util.NumInt(tmpValue.Substring(tmpValue.Length - 1));
                tmpValue = tmpValue.PadLeft(length - 1, '0').Substring(0, length - 2);
                string numericCharValue = string.Empty;

                switch (lastDigit)
                {
                    case 0:
                        numericCharValue = "p";
                        break;
                    case 1:
                        numericCharValue = "q";
                        break;
                    case 2:
                        numericCharValue = "r";
                        break;
                    case 3:
                        numericCharValue = "s";
                        break;
                    case 4:
                        numericCharValue = "t";
                        break;
                    case 5:
                        numericCharValue = "u";
                        break;
                    case 6:
                        numericCharValue = "v";
                        break;
                    case 7:
                        numericCharValue = "w";
                        break;
                    case 8:
                        numericCharValue = "x";
                        break;
                    case 9:
                        numericCharValue = "y";
                        break;
                }

                retVal = Util.Str(Util.Str(tmpValue).Trim() + Util.Str(numericCharValue)).PadLeft(length - 1, '0');
            }

            return retVal;
        }

        public static int ConvertZoneToNumeric(string value)
        {
            // value  ex: s9(5)v99  = 1234567   
            string retVal = string.Empty;

            if (Util.IsNumeric(value.Substring(0, value.Length)))
            {
                return Util.NumInt(value.Substring(0, value.Length));
            }
            else if (string.IsNullOrWhiteSpace(value.Substring(0, value.Length)))
            {
                return 0;
            }
            else
            {
                string lastDigit = value.Substring(value.Length - 1, 1);
                string tmpValue = value.Substring(0, value.Length - 1);
                int numericValue = 0;

                switch (lastDigit)
                {
                    case "p":
                        numericValue = 0;
                        break;
                    case "q":
                        numericValue = 1;
                        break;
                    case "r":
                        numericValue = 2;
                        break;
                    case "s":
                        numericValue = 3;
                        break;
                    case "t":
                        numericValue = 4;
                        break;
                    case "u":
                        numericValue = 5;
                        break;
                    case "v":
                        numericValue = 6;
                        break;
                    case "w":
                        numericValue = 7;
                        break;
                    case "x":
                        numericValue = 8;
                        break;
                    case "y":
                        numericValue = 9;
                        break;
                }
                retVal = "-" + tmpValue + Util.Str(numericValue);
                return Util.NumInt(retVal);
            }
        }

        public static long ConvertZoneToNumericLong(string value)
        {
            // value  ex: s9(5)v99  = 1234567   
            string retVal = string.Empty;

            if (Util.IsNumeric(value.Substring(0, value.Length)))
            {
                return Util.NumLongInt(value.Substring(0, value.Length));
            }
            else if (string.IsNullOrWhiteSpace(value.Substring(0, value.Length)))
            {
                return 0;
            }
            else
            {
                string lastDigit = value.Substring(value.Length - 1, 1);
                string tmpValue = value.Substring(0, value.Length - 1);
                int numericValue = 0;

                switch (lastDigit)
                {
                    case "p":
                        numericValue = 0;
                        break;
                    case "q":
                        numericValue = 1;
                        break;
                    case "r":
                        numericValue = 2;
                        break;
                    case "s":
                        numericValue = 3;
                        break;
                    case "t":
                        numericValue = 4;
                        break;
                    case "u":
                        numericValue = 5;
                        break;
                    case "v":
                        numericValue = 6;
                        break;
                    case "w":
                        numericValue = 7;
                        break;
                    case "x":
                        numericValue = 8;
                        break;
                    case "y":
                        numericValue = 9;
                        break;
                }
                retVal = "-" + tmpValue + Util.Str(numericValue);
                return Util.NumInt(retVal);
            }
        }

        public static string ConvertZoneLong(long value, int length, bool leftPadZeroes = false)
        {
            //Ex: Util.ConvertZone(Util.NumInt(obj.Wk_ohip_fee), 9) +   //  s9(6)v99   
            string retVal = string.Empty;

            if (Util.NumLongInt(value) > 0)
            {
                retVal = Util.Str(value).PadLeft(length - 1, '0');
            }
            else if (value == 0)
            {
                if (leftPadZeroes)
                {
                    retVal = "0".PadRight(length - 1, '0');
                }
                else
                {
                    retVal = " ".PadRight(length - 1);
                }
            }
            else
            {
                string tmpValue = Util.Str(value).Replace('-', ' ').Trim();
                int lastDigit = Util.NumInt(tmpValue.Substring(tmpValue.Length - 1));
                tmpValue = tmpValue.PadLeft(length - 1, '0').Substring(0, length - 2);
                string numericCharValue = string.Empty;

                switch (lastDigit)
                {
                    case 0:
                        numericCharValue = "p";
                        break;
                    case 1:
                        numericCharValue = "q";
                        break;
                    case 2:
                        numericCharValue = "r";
                        break;
                    case 3:
                        numericCharValue = "s";
                        break;
                    case 4:
                        numericCharValue = "t";
                        break;
                    case 5:
                        numericCharValue = "u";
                        break;
                    case 6:
                        numericCharValue = "v";
                        break;
                    case 7:
                        numericCharValue = "w";
                        break;
                    case 8:
                        numericCharValue = "x";
                        break;
                    case 9:
                        numericCharValue = "y";
                        break;
                }

                retVal = Util.Str(Util.Str(tmpValue).Trim() + Util.Str(numericCharValue)).PadLeft(length - 1, '0');
            }

            return retVal;
        }

        public static bool DebugUsingLocalMachine()
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["LocalMachineName"] != null)
                {
                    string machineName = System.Configuration.ConfigurationManager.AppSettings["LocalMachineName"];
                    if (Environment.MachineName.ToString().ToUpper().Equals(machineName.ToUpper()))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public static string ZeroToSpace(int value, int length, bool padZeroes = true)
        {
            if (value == 0)
            {
                return string.Empty.PadRight(length);
            }
            else
            {
                if (padZeroes)
                {
                    return value.ToString().PadLeft(length, '0');
                }
                else
                {
                    return value.ToString().PadLeft(length);
                }
            }
        }

        public static decimal DecimalValuePadZerosRight(decimal value, int decimalPlaces)
        {
            string retValue = string.Empty;
            if (!value.ToString().Contains("."))
            {
                retValue = value.ToString() + "." + "0".PadRight(decimalPlaces, '0');
                return Convert.ToDecimal(retValue);
            }
            else
            {
                return value;
            }
        }


        public static string UpperCaseFirst(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static decimal NumDec(object value)
        {
            if (value == null || value.ToString().Trim() == "")
                return 0;

            if (IsNumeric(value.ToString()))
                return Convert.ToDecimal(value);
            else
                return 0;
        }

        public static int NumDate(DateTime? value)
        {
            if (value == null ||
                (value != null && Convert.ToDateTime(value) == new DateTime(1900, 1, 1) ||
                 Convert.ToDateTime(value) == new DateTime(0001, 1, 1)))
                return 0;
            else
                return
                    Convert.ToInt32(value.Value.Year + value.Value.Month.ToString().PadLeft(2, '0') +
                                    value.Value.Day.ToString().PadLeft(2, '0'));
        }

        public static string NumDateZeroes(DateTime? value)
        {
            if (value == null)
                return "00000000";
            else
                return
                    Convert.ToInt32(value.Value.Year + value.Value.Month.ToString().PadLeft(2, '0') +
                                    value.Value.Day.ToString().PadLeft(2, '0')).ToString();
        }

        public static DateTime? ToDateTime(object value)
        {
            if (value == null)
                return null;

            if (value.ToString() == "" || value.ToString().Trim() == "0" || value.ToString().Trim() == "10101")
                return null;

            if (value.ToString().Length == 17)
                value = new DateTime(NumInt(value.ToString().Substring(0, 4)),
                                     NumInt(value.ToString().Substring(5, 2)),
                                     NumInt(value.ToString().Substring(8, 2)),
                                     NumInt(value.ToString().Substring(11, 2)),
                                     NumInt(value.ToString().Substring(13, 2)),
                                     NumInt(value.ToString().Substring(15, 2)));

            if (value.ToString().Length == 8)
                value = new DateTime(NumInt(value.ToString().Substring(0, 4)),
                                     NumInt(value.ToString().Substring(4, 2)),
                                     NumInt(value.ToString().Substring(6, 2)));


            if (Convert.ToDateTime(value) == new DateTime(1900, 1, 1) ||
                Convert.ToDateTime(value) == new DateTime(0001, 1, 1))
                return null;

            return Convert.ToDateTime(value);
        }

        public static DateTime? CompareDate(DateTime? value)
        {
            if (value == null) return new DateTime();
            return new DateTime(value.Value.Year, value.Value.Month, value.Value.Day);
        }

        public static DateTime? CompareDate(string value)
        {
            DateTime? resultDate = ToDateTime(value);
            if (value == null) return new DateTime();
            return new DateTime(resultDate.Value.Year, resultDate.Value.Month, resultDate.Value.Day);
        }

        public static bool Match(string value, string pattern)
        {
            if (value == null) return false;

            if (pattern.EndsWith("?"))
            {
                pattern = pattern.Substring(0, pattern.Length - 1);
                if (value.StartsWith(pattern)) return true;
                return false;
            }

            string[] patterns = pattern.Split(',');
            foreach (string t in patterns)
            {
                if (t.StartsWith("-") && t.Substring(1) != value)
                {
                    return true;
                }
                if (value == t)
                    return true;
                if (Regex.IsMatch(value, t))
                    return true;
            }
            return false;
        }

        public static string GetFiller(int start, int end, string filler)
        {
            return filler.PadRight(end, ' ').Substring(start - 1, end - start + 1);
        }

        public static bool SetFiller(int start, int end, string value, ref string filler)
        {
            filler = filler.PadRight(end, ' ');

            string parse1 = filler.Substring(0, start - 1);
            string parse2 = filler.Substring(end);

            filler = parse1 + value.PadRight(end - start, ' ') + parse2;

            return true;
        }


        public static string SetPartial(string startValue, int start, int end, string value)
        {
            if (startValue == null) startValue = "";
            if (value == null) value = "";
            string beforeReplace = startValue.PadRight(end, ' ').Substring(0, start - 1);
            string afterReplace = startValue.PadRight(end, ' ').Substring(end);
            value = value.PadRight(end - start + 1, ' ').Substring(0, end - start + 1);
            startValue = beforeReplace + value + afterReplace;

            return startValue;
        }

        public static string ZFI(string value, int length)
        {
            return value.PadLeft(length, '0');
        }

        public static string ZFI(string value)
        {
            int length = value.Length;
            value = value.Trim();
            return value.PadLeft(length, '0');
        }

        public static string ZFI(decimal value, int length)
        {
            return value.ToString().PadLeft(length, '0');
        }

        public static string ZFI(decimal? value, int length)
        {
            return value.ToString().PadLeft(length, '0');
        }


        public static string ZFI(int value, int length)
        {
            return value.ToString().PadLeft(length, '0');
        }

        public static string ZFI(int? value, int length)
        {
            return value.ToString().PadLeft(length, '0');
        }

        public static string Format(object value, string parameter)
        {
            string results = "";
            if ((value.ToString().Trim() == "0" || value.ToString().Trim() == "") &&
                parameter.EndsWith(".ZZ"))
            {
                value = "000";
            }
            else if (value.ToString().IndexOf(".") >= 0)
            {
                //value = value.ToString().Substring(0, value.ToString().IndexOf("."));
                if (value.ToString() != "")
                    value = Math.Round(Convert.ToDouble(value), 0).ToString();
            }

            value = value.ToString().PadLeft(parameter.Replace("$", "").Replace(",", "").Length);
            int dec = 0;
            int decval = 0;
            string replace = "";
            string formatPattern = "";
            string pattern = "";

            char[] parms = (parameter.Replace("$", "")).ToCharArray();
            Array.Reverse(parms);

            foreach (char c in parms)
            {
                if (c == 'Z')
                {
                    dec += 1;
                    decval += 1;
                }
                else if (c == ',')
                {
                    formatPattern = "(\\d{" + dec + "})" + formatPattern;
                    dec = 0;
                    replace += ",";
                }
                else if (c == '.')
                {
                    formatPattern = "(\\d{" + dec + "})" + formatPattern;
                    dec = 0;
                    replace += ".";
                }

                if (decval == value.ToString().Trim().Length) break;
            }

            if (dec > 0)
            {
                formatPattern = "(\\d{" + dec + "})" + formatPattern;
                dec = 0;
            }

            int count = 1;
            for (int i = replace.Length; i >= 0; i--)
            {
                if (i > 0)
                    pattern += "$" + (count) + replace.Substring(i - 1, 1);
                else
                    pattern += "$" + (count);
                count += 1;
            }
            //pattern = pattern.Substring(0, pattern.Length - 1);

            results = Regex.Replace(value.ToString(), @formatPattern, pattern).Trim();
            if (parameter.IndexOf(".") >= 0 && results.IndexOf(".") == -1)
            {
                results = "0." + results;
            }

            if (parameter.IndexOf(".") >= 0)
            {
                int decs = parameter.Substring(parameter.IndexOf(".") + 1).Length;
                if (results.Substring(results.IndexOf(".") + 1).Length < decs)
                {
                    results = results.Substring(0, results.IndexOf(".")) + "." +
                              results.Substring(results.IndexOf(".") + 1).PadLeft(decs, '0');
                }
            }


            if (parameter.StartsWith("$") && results.Trim().Length > 0)
                results = "$" + results;

            return results;
        }

        public static string Substring(string value, int start, int length)
        {
            if (value == null) value = "";
            value = value.PadRight(start + length).Substring(start, length);
            return value;
        }

        public static string StrUpper(decimal? value)
        {
            return value == null
                       ? ""
                       : value.ToString().ToUpper();
        }


        public static string StrUpper(int? value)
        {
            return value == null
                       ? ""
                       : value.ToString().ToUpper();
        }
        public static string StrUpper(string value)
        {
            return value == null
                       ? ""
                       : value.ToString().ToUpper();
        }

        public static string Str(decimal? value)
        {
            return value == null
                       ? ""
                       : value.ToString();
        }

        public static string Str(int? value)
        {
            //return value == null
            //           ? ""
            //           : value.ToString();

            return value + "";
        }

        public static string Str(string value)
        {
            //return value == null
            //           ? ""
            //           : value;

            return string.Concat(value, "");
        }

        public static string Str(decimal value, int length)
        {
            return value.ToString().PadRight(length, ' ').Substring(0, length);
        }

        public static string Str(decimal? value, int length)
        {
            return value == null
                       ? "".PadRight(length, ' ')
                       : value.ToString().PadRight(length, ' ').Substring(0, length);
        }

        public static string Str(string value, int length)
        {
            return value == null ? "".PadRight(length, ' ') : value.PadRight(length, ' ').Substring(0, length);
        }

        public static string Str(decimal value, int start, int end)
        {
            return value.ToString().PadRight(end, ' ').Substring(start - 1, end - (start - 1));
        }

        public static string StrDec(decimal? value, int size, int decimals)
        {
            return value == null
                       ? "".PadRight(size, ' ')
                       : String.Format("{0:0." + "".PadRight(decimals, '0') + "}", value).PadLeft(size, ' ');
        }

        public static string StrDec(string value, int size, int decimals)
        {
            decimal decimalValue = NumDec(value);
            return decimalValue == null
                       ? "".PadRight(size, ' ')
                       : String.Format("{0:0." + "".PadRight(decimals, '0') + "}", decimalValue).PadLeft(size, ' ');
        }

        public static string Str(decimal? value, int start, int end)
        {
            return value == null
                       ? "".PadRight(end - start, ' ')
                       : value.ToString().PadRight(end, ' ').Substring(start - 1, end - (start - 1));
        }

        public static string Str(string value, int start, int end)
        {
            return value == null
                       ? "".PadRight(end - start, ' ')
                       : value.PadRight(end, ' ').Substring(start - 1, end - (start - 1));
        }

        public static decimal NUM(string value)
        {
            if (value == null) return 0;
            return value.Trim().Length == 0 ? 0 : Convert.ToDecimal(value.Replace(" ", ""));
        }

        public static decimal NUM(decimal value)
        {
            return value;
        }

        public static decimal NUM(object value)
        {
            if (value == null) return 0;
            return value.GetType().ToString() == "System.String" ? NUM((string)value) : Convert.ToDecimal(value);
        }

        public static decimal CurrentDateDecimal()
        {
            return
                Convert.ToDecimal(DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                  DateTime.Now.Day.ToString().PadLeft(2, '0'));
        }

        public static Int32 DateInteger(DateTime value)
        {
            return
                Convert.ToInt32(value.Year + value.Month.ToString().PadLeft(2, '0') +
                                value.Day.ToString().PadLeft(2, '0'));
        }

        public static DateTime CurrentDate()
        {
            return DateTime.Now;
        }

        public static string DateTimeToString(DateTime? value)
        {
            return value == null
                       ? ""
                       : String.Format("{0:yyyy-MM-dd-hhmmss}", value);
            ;
        }

        public static string DateTimeToString(DateTime? value, string format)
        {
            return value == null
                       ? "".PadRight(format.Length, ' ')
                       : value.Value.ToString(format);
            ;
        }

        public static string DateWithoutCentury(string value)
        {
            return value.PadRight(10).Substring(2, 2) + "/" + value.PadRight(10).Substring(4, 2) + "/" + value.PadRight(10).Substring(6, 2);
        }

        public static string DateWithCenturyAddSlash(string value)
        {
            return value.PadRight(10).Substring(0, 4) + "/" + value.PadRight(10).Substring(4, 2) + "/" + value.PadRight(10).Substring(6, 2);
        }

        public static bool RoleMatch(string role)
        {
            string[] roles = role.Replace(" ", "").Split(',');
            // return roles.Any(t => ApplicationState.Current.CurrentRoles.Where(a => a.Code == t).Any());
            return true;
        }

        public static string Post(string value)
        {
            if (value.Trim().Length == 0)
                return "";
            value = value.Replace(" ", "").ToUpper();
            if (Match(value, "[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]"))
                return value.Substring(0, 3) + " " + value.Substring(3, 3);
            else
                throw new Exception("Postal Code in not in the Correct Format!");
        }


        public static decimal RoundUp(decimal value, int decimalPlaces)
        {
            decimal nReturn = 0;

            string tempValue = value.ToString();

            decimal subtractValue;

            int decimalIndex = tempValue.IndexOf(".");

            if (decimalIndex >= 0 && decimalPlaces > 0)
            {
                if (tempValue.Length >= decimalIndex + decimalPlaces + 1)
                {
                    subtractValue = Convert.ToDecimal(tempValue.Substring(0, decimalIndex + decimalPlaces + 1));
                }

                else
                {
                    subtractValue = Convert.ToDecimal(tempValue);
                }

                if (value - subtractValue > Convert.ToDecimal(0.000))
                {
                    nReturn = subtractValue + 1 / Convert.ToDecimal(Math.Pow(10, decimalPlaces));
                }

                else
                {
                    nReturn = subtractValue;
                }
            }

            else if (decimalPlaces == 0)
            {
                subtractValue = Convert.ToDecimal(Convert.ToInt32(value));

                if (value - subtractValue > Convert.ToDecimal(0.000))
                {
                    nReturn = subtractValue + 1;
                }

                else
                {
                    nReturn = subtractValue;
                }
            }

            else
            {
                nReturn = value;
            }

            return nReturn;
        }

        public static decimal Round(decimal value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static decimal Round(decimal value, int precision,
                                    MidpointRounding midpointRounding = MidpointRounding.AwayFromZero)
        {
            return Math.Round(value, precision, midpointRounding);
        }

        public static decimal Round(decimal? value)
        {
            if (value == null) return 0;
            return Math.Round((decimal)value, MidpointRounding.AwayFromZero);
        }

        public static decimal Round(decimal? value, int precision)
        {
            if (value == null) return 0;
            return Math.Round((decimal)value, precision, MidpointRounding.AwayFromZero);
        }


        public static decimal? Divide(decimal? value, decimal? dividedby)
        {
            if (dividedby == 0)
                return 0;
            return value / dividedby;
        }

        public static decimal Divide(decimal value, decimal dividedby)
        {
            if (dividedby == 0)
                return 0;
            return value / dividedby;
        }

        public static int? Divide(int? value, int? dividedby)
        {
            if (dividedby == 0)
                return 0;
            return value / dividedby;
        }

        public static int Divide(int value, int dividedby)
        {
            if (dividedby == 0)
                return 0;
            return value / dividedby;
        }


        public static string Clean(string value)
        {
            if (value == null) value = "";
            while (value.IndexOf("  ") >= 0)
            {
                value = value.Replace("  ", " ");
            }
            return value;
        }

        public static void SplitString(string source, ref string[] destination, int splitLength)
        {
            int start = 0;
            string originalSource = source;

            for (int i = 0; i < 10; i++)
            {
                destination[i] = source.Substring(0, splitLength);
                start += splitLength;
                source = originalSource.Substring(start, (originalSource.Length - start));
                if ((source.Length > 0) && (source.Length < 4))
                {
                    i++;
                    destination[i] = source;
                    break;
                }
                else if (source.Length == 0)
                {
                    break;
                }
            }
        }

        public static void SplitString(string source, ref decimal[] destination, int splitLength)
        {
            int start = 0;
            string originalSource = source;

            for (int i = 0; i < destination.Length; i++)
            {
                destination[i] = NumDec(source.Substring(0, splitLength));
                start += splitLength;
                source = originalSource.Substring(start, (originalSource.Length - start));
                if ((source.Length > 0) && (source.Length < 4))
                {
                    i++;
                    destination[i] = NumDec(source);
                    break;
                }
                else if (source.Length == 0)
                {
                    break;
                }
            }
        }

        public static void SplitString(string source, ref int[] destination, int splitLength)
        {
            int start = 0;
            string originalSource = source;

            for (int i = 0; i < destination.Length; i++)
            {
                destination[i] = NumInt(source.Substring(0, splitLength));
                start += splitLength;
                source = originalSource.Substring(start, (originalSource.Length - start));
                if ((source.Length > 0) && (source.Length < 4))
                {
                    i++;
                    destination[i] = NumInt(source);
                    break;
                }
                else if (source.Length == 0)
                {
                    break;
                }
            }
        }

        public static string JoinString(string[] source, int joinLength)
        {
            return source.Aggregate(string.Empty,
                                    (current, sourceItem) => current + sourceItem.PadRight(joinLength, ' '));
        }

        public static string JoinString(decimal[] source, int joinLength)
        {
            return source.Aggregate(string.Empty,
                                    (current, sourceItem) => current + sourceItem.ToString().PadLeft(joinLength, ' '));
        }

        public static string JoinString(int[] source, int joinLength)
        {
            return source.Aggregate(string.Empty,
                                    (current, sourceItem) => current + sourceItem.ToString().PadLeft(joinLength, ' '));
        }

        public static string[] NewString(int size)
        {
            var newString = new string[size];
            for (int i = 0; i < newString.Length; i++)
            {
                newString[i] = string.Empty;
            }

            return newString;
        }

        public static string[,] NewString(int size, int size2)
        {
            var newString = new string[size, size2];
            for (int i = 0; i < newString.GetLength(0); i++)
            {
                for (int j = 0; j < newString.GetLength(1); j++)
                {
                    newString[i, j] = string.Empty;
                }
            }

            return newString;
        }

        public static string LastCharacter(int value)
        {
            return value.ToString().Substring(value.ToString().Length - 1);
        }

        public static string LastCharacter(decimal value)
        {
            return value.ToString().Substring(value.ToString().Length - 1);
        }

        public static string RemoveQuotes(string value)
        {
            return value.Replace("\"", "");
        }

        public static string AddQuotes(string value)
        {
            return "\"" + value + "\"";
        }

        public static bool LineCountLessThan(string fileName, int numberOfLinesToCheck)
        {
            string line;
            int lineCount = 0;

            if (File.Exists(fileName))
                using (var sr = new StreamReader(fileName, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineCount++;

                        if (lineCount == numberOfLinesToCheck)
                            break;
                    }
                }

            return lineCount < numberOfLinesToCheck;
        }

        public static string CreateNewFile(string fileName)
        {
            using (var sw = new StreamWriter(fileName, false, Encoding.Default))
            {
            }

            return fileName;
        }

        public static void AppendFiles(string sourceFile, string destinationFile)
        {
            string line;

            using (var sw = new StreamWriter(destinationFile, true, Encoding.Default))
            {
                using (var sr = new StreamReader(sourceFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        public static void Error_Logfile_Write(string filename, string error_msg)
        {
            using (var sw = new StreamWriter(filename, true, Encoding.Default))
            {
                sw.WriteLine(error_msg);
            }
        }

        public static string FormatPhoneNumber(object value, object parameter)
        {
            if (value == null)
            {
                return null;
            }
            else if (value.ToString() == "0")
                return "";
            else
            {
                string pattern;
                switch (value.ToString().Length)
                {
                    case 10:
                        {
                            if (parameter != null && parameter.ToString() == "-")
                                pattern = "$1-$2-$3";
                            else
                                pattern = "($1) $2-$3";

                            // Remove all non numeric characters
                            value = value.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                            const string formatPattern = @"(\d{3})(\d{3})(\d{4})";
                            string results = Regex.Replace(value.ToString(), formatPattern, pattern);

                            return results;
                        }
                    case 11:
                        {
                            if (parameter != null && parameter.ToString() == "-")
                                pattern = "$1-$2-$3-$4";
                            else
                                pattern = "$1($2) $3-$4";

                            // Remove all non numeric characters
                            value = value.ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                            const string formatPattern = @"(\d{1})(\d{3})(\d{3})(\d{4})";
                            string results = Regex.Replace(value.ToString(), formatPattern, pattern);

                            return results;
                        }
                    default:
                        return value.ToString();
                }
            }
        }

      /*  public static void GeneratePdfFile(string inputFile, string outputFile, string title, bool displayPDF,
                                           bool deleteInputFile = false, bool isText = false, string faxFile = "",
                                           string textFile = "", string printWhere = "P")
        {
            //Each pdf file generated needs a different datatime stamp, and the pair file should have the same datetimestamp.

            string datetimeStamp = DateTimeStamp();
            string line = null;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            string tmpFaxFile = faxFile.Replace(".txt", ".tmp");

            //Save the datetime stamp, so the same datetime is used on the Archive file.
            ApplicationState.Current.DATETIMESTAMP = datetimeStamp;
            outputFile = outputFile.Split('.')[0].Substring(0, outputFile.LastIndexOf("_") + 1) + datetimeStamp + "." +
                         outputFile.Split('.')[1];

            if (printWhere == "F" || printWhere == "E")
            {
                //Backup the faxFile
                if (File.Exists(tmpFaxFile))
                    File.Delete(tmpFaxFile);

                File.Copy(faxFile, tmpFaxFile);

                //Add REMARKS to faxFile

                var sw = new StreamWriter(faxFile, true, Encoding.Default);
                using (var sr = new StreamReader(textFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith(".FAX") || line.Trim().StartsWith(".EMAIL"))
                        {
                            if (line.IndexOf("[REMARKS=") > -1)
                            {
                                if (line.IndexOf("BEGIN") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = true;
                                    else
                                        addFaxRemarks = true;
                                }

                                if (line.IndexOf("END") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = false;
                                    else
                                        addFaxRemarks = false;
                                }

                                sw.WriteLine(line.Trim());
                            }
                        }
                        else
                        {
                            if (addEmailRemarks || addFaxRemarks)
                            {
                                if (line.Trim().StartsWith(".") == false)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                string cmdFileName = inputFile.Split('.')[0].Substring(0, inputFile.LastIndexOf("_") + 1) +
                                     datetimeStamp + "." + inputFile.Split('.')[1];
                CommandFileGenerator.GenerateCommandFile(faxFile, cmdFileName,
                                                         outputFile.Substring(outputFile.LastIndexOf("\\") + 1),
                                                         printWhere);

                //Restore the faxFile
                if (File.Exists(tmpFaxFile))
                {
                    File.Delete(faxFile);
                    File.Copy(tmpFaxFile, faxFile);
                    File.Delete(tmpFaxFile);
                }
            }

            // Generate the PDF file.
            var pdfGenerator = new PdfGenerator(inputFile, outputFile, title, printWhere, displayPDF, deleteInputFile,
                                                isText);
            pdfGenerator.GeneratePdf();
            pdfGenerator.Dispose();
            pdfGenerator = null;
        } */

     /*   public static void GeneratePdfFile(string inputFile, string outputFile, string title, string orientation,
                                           bool displayPDF, bool deleteInputFile = false, bool isText = false,
                                           string faxFile = "", string textFile = "", string printWhere = "P")
        {
            //Each pdf file generated needs a different datatime stamp, and the pair file should have the same datetimestamp.

            string datetimeStamp = DateTimeStamp();
            string line = null;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            string tmpFaxFile = faxFile.Replace(".txt", ".tmp");

            //Save the datetime stamp, so the same datetime is used on the Archive file.
            ApplicationState.Current.DATETIMESTAMP = datetimeStamp;
            outputFile = outputFile.Split('.')[0].Substring(0, outputFile.LastIndexOf("_") + 1) + datetimeStamp + "." +
                         outputFile.Split('.')[1];

            if (printWhere == "F" || printWhere == "E")
            {
                //Backup the faxFile
                if (File.Exists(tmpFaxFile))
                    File.Delete(tmpFaxFile);

                File.Copy(faxFile, tmpFaxFile);

                //Add REMARKS to faxFile

                var sw = new StreamWriter(faxFile, true, Encoding.Default);
                using (var sr = new StreamReader(textFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith(".FAX") || line.Trim().StartsWith(".EMAIL"))
                        {
                            if (line.IndexOf("[REMARKS=") > -1)
                            {
                                if (line.IndexOf("BEGIN") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = true;
                                    else
                                        addFaxRemarks = true;
                                }

                                if (line.IndexOf("END") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = false;
                                    else
                                        addFaxRemarks = false;
                                }

                                sw.WriteLine(line.Trim());
                            }
                        }
                        else
                        {
                            if (addEmailRemarks || addFaxRemarks)
                            {
                                if (line.Trim().StartsWith(".") == false)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                string cmdFileName = inputFile.Split('.')[0].Substring(0, inputFile.LastIndexOf("_") + 1) +
                                     datetimeStamp + "." + inputFile.Split('.')[1];
                CommandFileGenerator.GenerateCommandFile(faxFile, cmdFileName,
                                                         outputFile.Substring(outputFile.LastIndexOf("\\") + 1),
                                                         printWhere);

                //Restore the faxFile
                if (File.Exists(tmpFaxFile))
                {
                    File.Delete(faxFile);
                    File.Copy(tmpFaxFile, faxFile);
                    File.Delete(tmpFaxFile);
                }
            }

            // Generate the PDF file.
            var pdfGenerator = new PdfGenerator(inputFile, outputFile, title, printWhere, displayPDF, deleteInputFile,
                                                isText);
            pdfGenerator.GeneratePdf(orientation);
            pdfGenerator.Dispose();
            pdfGenerator = null;
        } */

        //mack

      /*  public static void GeneratePdfFile(string inputFile, string outputFile, string title, string orientation,
                                           float fontsize, bool displayPDF, float leftMargin, float rightMargin,
                                           bool deleteInputFile = false, bool isText = false, string faxFile = "",
                                           string textFile = "", string printWhere = "P", DateTime? date = null,
                                           bool includeDateTimeStamp = true)
        {
            //Each pdf file generated needs a different datatime stamp, and the pair file should have the same datetimestamp.

            string datetimeStamp = DateTimeStamp();
            if (date != null) datetimeStamp = DateTimeStamp((DateTime)date);
            string line = null;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            string tmpFaxFile = faxFile.Replace(".txt", ".tmp");

            //Save the datetime stamp, so the same datetime is used on the Archive file.
            ApplicationState.Current.DATETIMESTAMP = datetimeStamp;


            if (includeDateTimeStamp)
                outputFile = outputFile.Split('.')[0].Substring(0, outputFile.LastIndexOf("_") + 1) + datetimeStamp +
                             "." + outputFile.Split('.')[1];

            if (printWhere == "F" || printWhere == "E")
            {
                //Backup the faxFile
                if (File.Exists(tmpFaxFile))
                    File.Delete(tmpFaxFile);

                File.Copy(faxFile, tmpFaxFile);

                //Add REMARKS to faxFile

                var sw = new StreamWriter(faxFile, true, Encoding.Default);
                using (var sr = new StreamReader(textFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith(".FAX") || line.Trim().StartsWith(".EMAIL"))
                        {
                            if (line.IndexOf("[REMARKS=") > -1)
                            {
                                if (line.IndexOf("BEGIN") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = true;
                                    else
                                        addFaxRemarks = true;
                                }

                                if (line.IndexOf("END") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = false;
                                    else
                                        addFaxRemarks = false;
                                }

                                sw.WriteLine(line.Trim());
                            }
                        }
                        else
                        {
                            if (addEmailRemarks || addFaxRemarks)
                            {
                                if (line.Trim().StartsWith(".") == false)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                string cmdFileName = inputFile.Split('.')[0].Substring(0, inputFile.LastIndexOf("_") + 1) +
                                     datetimeStamp + "." + inputFile.Split('.')[1];
                CommandFileGenerator.GenerateCommandFile(faxFile, cmdFileName,
                                                         outputFile.Substring(outputFile.LastIndexOf("\\") + 1),
                                                         printWhere);

                //Restore the faxFile
                if (File.Exists(tmpFaxFile))
                {
                    File.Delete(faxFile);
                    File.Copy(tmpFaxFile, faxFile);
                    File.Delete(tmpFaxFile);
                }
            }

            // Generate the PDF file.
            var pdfGenerator = new PdfGenerator(inputFile, outputFile, title, printWhere, displayPDF, deleteInputFile,
                                                isText);
            pdfGenerator.GeneratePdf1(orientation, fontsize, leftMargin, rightMargin);
            pdfGenerator.Dispose();
            pdfGenerator = null;
        } */


      /*  public static void GeneratePdfFile(string inputFile, string outputFile, string title, string orientation,
                                           float fontsize, bool displayPDF, bool deleteInputFile = false,
                                           bool isText = false, string faxFile = "", string textFile = "",
                                           string printWhere = "P", DateTime? date = null,
                                           bool includeDateTimeStamp = true)
        {
            //Each pdf file generated needs a different datatime stamp, and the pair file should have the same datetimestamp.

            string datetimeStamp = DateTimeStamp();
            if (date != null) datetimeStamp = DateTimeStamp((DateTime)date);
            string line = null;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            string tmpFaxFile = faxFile.Replace(".txt", ".tmp");

            //Save the datetime stamp, so the same datetime is used on the Archive file.
            ApplicationState.Current.DATETIMESTAMP = datetimeStamp;

            if (includeDateTimeStamp)
                outputFile = outputFile.Split('.')[0].Substring(0, outputFile.LastIndexOf("_") + 1) + datetimeStamp +
                             "." + outputFile.Split('.')[1];

            if (printWhere == "F" || printWhere == "E")
            {
                //Backup the faxFile
                if (File.Exists(tmpFaxFile))
                    File.Delete(tmpFaxFile);

                File.Copy(faxFile, tmpFaxFile);

                //Add REMARKS to faxFile

                var sw = new StreamWriter(faxFile, true, Encoding.Default);
                using (var sr = new StreamReader(textFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith(".FAX") || line.Trim().StartsWith(".EMAIL"))
                        {
                            if (line.IndexOf("[REMARKS=") > -1)
                            {
                                if (line.IndexOf("BEGIN") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = true;
                                    else
                                        addFaxRemarks = true;
                                }

                                if (line.IndexOf("END") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = false;
                                    else
                                        addFaxRemarks = false;
                                }

                                sw.WriteLine(line.Trim());
                            }
                        }
                        else
                        {
                            if (addEmailRemarks || addFaxRemarks)
                            {
                                if (line.Trim().StartsWith(".") == false)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                string cmdFileName = inputFile.Split('.')[0].Substring(0, inputFile.LastIndexOf("_") + 1) +
                                     datetimeStamp + "." + inputFile.Split('.')[1];
                CommandFileGenerator.GenerateCommandFile(faxFile, cmdFileName,
                                                         outputFile.Substring(outputFile.LastIndexOf("\\") + 1),
                                                         printWhere);

                //Restore the faxFile
                if (File.Exists(tmpFaxFile))
                {
                    File.Delete(faxFile);
                    File.Copy(tmpFaxFile, faxFile);
                    File.Delete(tmpFaxFile);
                }
            }

            // Generate the PDF file.
            var pdfGenerator = new PdfGenerator(inputFile, outputFile, title, printWhere, displayPDF, deleteInputFile,
                                                isText);
            pdfGenerator.GeneratePdf(orientation, fontsize);
            pdfGenerator.Dispose();
            pdfGenerator = null;
        } */

       /* public static void GeneratePdfFile(string inputFile, string outputFile, string title, bool displayPDF,
                                           float marginLeft, float marginRight, bool deleteInputFile = false,
                                           bool isText = false, string faxFile = "", string textFile = "",
                                           string printWhere = "P")
        {
            //Each pdf file generated needs a different datatime stamp, and the pair file should have the same datetimestamp.

            string datetimeStamp = DateTimeStamp();
            string line = null;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            string tmpFaxFile = faxFile.Replace(".txt", ".tmp");

            //Save the datetime stamp, so the same datetime is used on the Archive file.
            ApplicationState.Current.DATETIMESTAMP = datetimeStamp;
            outputFile = outputFile.Split('.')[0].Substring(0, outputFile.LastIndexOf("_") + 1) + datetimeStamp + "." +
                         outputFile.Split('.')[1];

            if (printWhere == "F" || printWhere == "E")
            {
                //Backup the faxFile
                if (File.Exists(tmpFaxFile))
                    File.Delete(tmpFaxFile);

                File.Copy(faxFile, tmpFaxFile);

                //Add REMARKS to faxFile

                var sw = new StreamWriter(faxFile, true, Encoding.Default);
                using (var sr = new StreamReader(textFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith(".FAX") || line.Trim().StartsWith(".EMAIL"))
                        {
                            if (line.IndexOf("[REMARKS=") > -1)
                            {
                                if (line.IndexOf("BEGIN") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = true;
                                    else
                                        addFaxRemarks = true;
                                }

                                if (line.IndexOf("END") > -1)
                                {
                                    if (printWhere == "E")
                                        addEmailRemarks = false;
                                    else
                                        addFaxRemarks = false;
                                }

                                sw.WriteLine(line.Trim());
                            }
                        }
                        else
                        {
                            if (addEmailRemarks || addFaxRemarks)
                            {
                                if (line.Trim().StartsWith(".") == false)
                                {
                                    sw.WriteLine(line);
                                }
                            }
                        }
                    }

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }

                string cmdFileName = inputFile.Split('.')[0].Substring(0, inputFile.LastIndexOf("_") + 1) +
                                     datetimeStamp + "." + inputFile.Split('.')[1];
                CommandFileGenerator.GenerateCommandFile(faxFile, cmdFileName,
                                                         outputFile.Substring(outputFile.LastIndexOf("\\") + 1),
                                                         printWhere);

                //Restore the faxFile
                if (File.Exists(tmpFaxFile))
                {
                    File.Delete(faxFile);
                    File.Copy(tmpFaxFile, faxFile);
                    File.Delete(tmpFaxFile);
                }
            }

            // Generate the PDF file.
            var pdfGenerator = new PdfGenerator(inputFile, outputFile, title, printWhere, displayPDF, deleteInputFile,
                                                isText);
            pdfGenerator.GeneratePdfWithSpecificMargin(marginLeft, marginRight);
            pdfGenerator.Dispose();
            pdfGenerator = null;
        } */

        public static string DateTimeStamp()
        {
            return Util.Str(DateTime.Now.Year) + Util.ZFI(Util.Str(DateTime.Now.Month), 2) +
                   Util.ZFI(Util.Str(DateTime.Now.Day), 2) + Util.ZFI(Util.Str(DateTime.Now.Hour), 2) +
                   Util.ZFI(Util.Str(DateTime.Now.Minute), 2) + Util.ZFI(Util.Str(DateTime.Now.Second), 2) +
                   Util.ZFI(Util.Str(DateTime.Now.Millisecond), 3);
        }

        public static string DateTimeStamp(DateTime date)
        {
            return Str(date.Year) + ZFI(Str(date.Month), 2) + ZFI(Str(date.Day), 2) + ZFI(Str(date.Hour), 2) +
                   ZFI(Str(date.Minute), 2) + ZFI(Str(date.Second), 2) + ZFI(Str(date.Millisecond), 3);
        }

        public static void GeneratePdfFile(string inputFile, string destination, string title, string orientation)
        {
            string outputFile = ConfigurationManager.AppSettings[destination] + "\\" + inputFile.Replace(".txt", ".pdf");
            //GeneratePdfFile(inputFile, outputFile, title, orientation, false);
            return;
        }

        public static void GetLastDayOfTheMonth(DateTime value)
        {
            DateTime tmpDate = value.AddMonths(1);
            var NextMonth = new DateTime(tmpDate.Year, tmpDate.Month, 1);
            DateTime EndofMonth = NextMonth.AddDays(-1);
        }

        public static string PadLeft(string value, int column_width)
        {
            int len = 0;
            int diff = 0;
            string strNew = "";

            len = value.Length;
            diff = column_width - len;
            strNew = Str(" ", 1, diff) + value;

            return strNew;
        }

        public static void RemovePageTAG(string destinationFile, string sourceFile)
        {
            string line;

            using (var sw = new StreamWriter(destinationFile, true, Encoding.Default))
            {
                using (var sr = new StreamReader(sourceFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.Trim().Equals(".PAGE"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        public static string GetBatchJobName(string process_name, string return_type)
        {
            string full_name = "";
            string abbrev_name = "";
            string return_value = "";

            switch (process_name.ToLower())
            {
                case "aigdata":

                    full_name = "AIG Data Feed";
                    abbrev_name = "AIG Data Feed";
                    break;

                case "archhpsx":

                    full_name = "EOD Hpsheet Archive Process";
                    abbrev_name = "HPSHEET";
                    break;

                case "archinvx":

                    full_name = "EOD Invoice Archive Process";
                    abbrev_name = "Invoice";
                    break;

                case "auto45":

                    full_name = "Automatic 45 Day Fax Process";
                    abbrev_name = "Auto45";
                    break;

                case "bankreco":

                    full_name = "LOSS REV. FUND - RECONCILIATION REPORT";
                    abbrev_name = "LRF Reconciliation";
                    break;

                case "bdfor1":

                    full_name = "Bordereaux for One Customer";
                    abbrev_name = "One Customer Bordereaux";
                    break;

                case "bordsrtrm":

                    full_name = "Coins Premium Bordereaux";
                    abbrev_name = "Coins Premium Bordereaux";
                    break;

                case "cljc4000":

                    full_name = "Stream Quarterly and Yearly Bordereau";
                    abbrev_name = "Quarterly Bordereau";
                    break;

                case "clmjcl06":

                    full_name = "Claims on Projects/Policies - Coins.";
                    abbrev_name = "Claims for Coins Projects";
                    break;

                case "clmjcl07":

                    full_name = "Print Multiple Payment Trans Reports";
                    abbrev_name = "Payment Transactions";
                    break;

                case "clmp03":

                    full_name = "Claims Stats File & Rep - Lloyds";
                    abbrev_name = "Claims Stats - Lloyds";
                    break;

                case "clmp05":

                    full_name = "Claims Stats File & Rep - Company";
                    abbrev_name = "Claims Stats - Company";
                    break;

                case "deferred":

                    full_name = "Daily Deferred Spreadsheet";
                    abbrev_name = "Deferred Spreadsheet";
                    break;

                case "eaep90":

                    full_name = "A&E invoice load program ";
                    abbrev_name = "A&E invoice LOad";
                    break;

                case "epcp90":

                    full_name = "Coins invoice load program ";
                    abbrev_name = "Coins invoice Load";
                    break;

                case "exbord":

                    full_name = "Excess Claims Bordereaux";
                    abbrev_name = "Excess Claims Bordereaux";
                    break;

                case "fundrepl":

                    full_name = "FUND REPLENISHMENT REPORT";
                    abbrev_name = "Fund Replenishment";
                    break;

                case "genbords":

                    full_name = "Claim Bordereau for Any Line of Business";
                    abbrev_name = "LOB Claims Bordereaux";
                    break;

                case "hpsheet":

                    full_name = "EOD HP Sheet Process";
                    abbrev_name = "HP Sheet";
                    break;

                case "invoices":

                    full_name = "EOD Invoice Process";
                    abbrev_name = "Invoices";
                    break;

                case "ofacr":

                    full_name = "Office of Foreign Assets Control Reporting";
                    abbrev_name = "OFAC Report";
                    break;

                case "pas213":

                    full_name = "OppenHeim Premium Bordereaux";
                    abbrev_name = "OppenHeim Premium Bordereaux";
                    break;

                case "poolrecs":

                    full_name = "MONTHLY RECEIPTS REPORT";
                    abbrev_name = "Monthly Receipts";
                    break;

                case "register":

                    full_name = "STREAM MONTHLY REGISTER";
                    abbrev_name = "Monthly Register";
                    break;

                case "replfall":

                    full_name = "Monthly Replenishment Report and Files";
                    abbrev_name = "Monthly Replenishment";
                    break;

                case "slecthps":

                    full_name = "Select HP Sheet Process";
                    abbrev_name = "Select HP Sheet";
                    break;

                case "slectinv":

                    full_name = "Select Invoice Process";
                    abbrev_name = "Select Invoice";
                    break;

                case "snewclm":

                    full_name = "Stream Monthly New Claims";
                    abbrev_name = "Monthly New Claims";
                    break;

                case "tmplsum":

                    full_name = "Premium Reporting Report";
                    abbrev_name = "Premium Reporting";
                    break;

                case "volume":

                    full_name = "Daily Volume Report";
                    abbrev_name = "Daily Volume";
                    break;

                case "tmplsumx":

                    full_name = "Temple Summary Extract Job";
                    abbrev_name = "Temple Summary";
                    break;

                default:

                    full_name = "UNKNOWN. Please contact system administration.";
                    abbrev_name = "UNKNOWN";
                    break;
            }

            if (return_type == "full")
                return_value = full_name;

            if (return_type == "abbreviation")
                return_value = abbrev_name;

            return return_value;
        }

        public static bool PrintLabel(int? isn, string line1, string line2, string line3, string line4, string line5,
                                      string line6)
        {
            // Label Printer Commands  (reference to EPL2 Programmer's Manual - www.geksagon.ru/i/2/EPL2_Manual.pdf) 

            var sb = new StringBuilder(String.Empty);
            sb.AppendLine();
            sb.AppendLine("N");
            sb.AppendLine("q215");
            sb.AppendLine("Q812,24");

            sb.AppendLine("A210,102,1,4,1,1,N,\"" + line1 + "\"");
            sb.AppendLine("A180,102,1,4,1,1,N,\"" + line2 + "\"");
            sb.AppendLine("A150,102,1,4,1,1,N,\"" + line3 + "\"");
            sb.AppendLine("A120,102,1,4,1,1,N,\"" + line4 + "\"");
            sb.AppendLine("A90,102,1,4,1,1,N,\"" + line5 + "\"");
            sb.AppendLine("A60,102,1,4,1,1,N,\"" + line6 + "\"");

            if (isn != null)
                sb.AppendLine("A30,102,1,4,1,1,N,\"" + "ISN:" + isn + "\"");

            sb.AppendLine("P1,1");

            // Added by Craig:  Only print if "LabelPrinter" has a value
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["LabelPrinter"]))
                RawPrinterHelper.SendStringToPrinter(ConfigurationManager.AppSettings["LabelPrinter"], sb.ToString(), "Label " + isn.ToString());

            return true;
        }
    }
}
