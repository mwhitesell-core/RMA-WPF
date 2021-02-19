using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace Core.DataAccess.TextFile
{
    [SecuritySafeCritical]
    public class TextHelper
    {
        #region private utility methods & constructors

        /// <summary>
        /// Since this class provides only static methods, make the default constructor private to prevent 
        /// instances from being created with "new TextHelper()".
        /// </summary>
        protected TextHelper()
        {
        }

        #endregion

        [FileIOPermissionAttribute(SecurityAction.Assert)]
        public static DataTable ExecuteDataTable(string strSQL, string filePath, string flatfiledictionary, Hashtable TextFiles)
        {
            return ExecuteDataTable(strSQL, filePath, flatfiledictionary, false, TextFiles);
        }

        public static DataTable ExecuteDataTable(string strSQL, string filePath, Hashtable TextFiles)
        {
            return ExecuteDataTable(strSQL, filePath, "", false, TextFiles);
        }

        public static DataTable ExecuteDataTable(string strSQL, string filePath, bool isPortable, Hashtable TextFiles)
        {
            return ExecuteDataTable(strSQL, filePath, "", isPortable, TextFiles);
        }

        [FileIOPermissionAttribute(SecurityAction.Assert)]
        public static DataTable ExecuteDataTable(string strSQL, string filePath, string flatfiledictionary, bool isPortable, Hashtable TextFiles)
        {
            var permission = new FileIOPermission(PermissionState.Unrestricted);
            // Assert security permission! 
            permission.Assert();

            ArrayList arrColumns = new ArrayList();

            DataColumn dc = new DataColumn();

            DataRow row;

            DataRowCollection rowCollection;

            DataTable dt = new DataTable();
            DataTable dtTemp = new DataTable();

            Hashtable hsLength = new Hashtable();

            int lineLength = 0;
            int placeHolder = 0;

            string columns = string.Empty;
            string file = string.Empty;
            string fileName = string.Empty;
            string fileStructure = string.Empty;
            string line = string.Empty;
            string name = string.Empty;
            string tableName = string.Empty;
            string whereclause = "";
            string orderby = "";
            Hashtable hsColumns = new Hashtable();

            string[] arrStructure;

            StreamReader sr;

            try
            {



                columns = strSQL.ToUpper();
                columns = columns.Substring(0, strSQL.IndexOf("FROM"));
                columns = columns.Replace("SELECT", "");

                for (int i = 0; i <= columns.Split(',').Length - 1; i++)
                {
                    arrColumns.Add(columns.Split(',')[i].ToUpper().Trim());
                }

                fileName = strSQL.ToUpper();
                fileName = fileName.Substring(fileName.LastIndexOf("FROM") + 4).Trim();

                fileName = fileName.Split(' ')[0];



                if (fileName.IndexOf("WHERE") > -1)
                {
                    fileName = fileName.Substring(0, fileName.IndexOf("WHERE")).Trim();
                }

                if (fileName.IndexOf(".") > -1)
                {
                    fileName = fileName.Substring(fileName.IndexOf(".") + 1).Trim();
                }

                if (!TextFiles.Contains(fileName))
                {

                    if (filePath.EndsWith("\\"))
                    {
                        if (isPortable)
                        {
                            file = filePath + fileName + ".ps";
                            fileStructure = filePath + fileName + ".psd";
                        }
                        else
                        {
                            file = filePath + fileName + ".sf";
                            fileStructure = filePath + fileName + ".sfd";
                        }
                    }
                    else
                    {
                        if (isPortable)
                        {
                            file = filePath + "\\" + fileName + ".ps";
                            fileStructure = filePath + "\\" + fileName + ".psd";
                        }
                        else
                        {
                            file = filePath + "\\" + fileName + ".sf";
                            fileStructure = filePath + "\\" + fileName + ".sfd";
                        }
                    }

                    file = file.Replace("UserID", Environment.UserName);
                    fileStructure = fileStructure.Replace("UserID", Environment.UserName);

                    if (!File.Exists(file))
                    {
                        file = file.Replace(".sf", ".ps");
                        fileStructure = fileStructure.Replace(".sfd", ".psd");

                    }

                    if (!File.Exists(file))
                    {
                        file = file.Replace(".ps", ".dat");

                        if (File.Exists(file))
                        {
                            fileStructure = flatfiledictionary + "\\" + fileName + ".dfd";
                        }
                    }

                    if (File.Exists(file))
                    {
                        sr = new StreamReader(fileStructure);
                        line = sr.ReadLine();

                        while (line != null)
                        {
                            arrStructure = line.Split(',');

                            dc = new DataColumn();
                            dc.ColumnName = arrStructure[0];

                            hsColumns.Add(arrStructure[0], arrStructure[1]);

                            switch (arrStructure[1])
                            {
                                case "Numeric":
                                    dc.DataType = System.Type.GetType("System.Decimal");
                                    break;

                                case "Character":
                                    dc.DataType = System.Type.GetType("System.String");
                                    break;

                                case "System.Zoned.Signed":
                                case "System.Zoned.Unsigned":
                                    dc.DataType = System.Type.GetType("System.Decimal");
                                    break;

                                default:
                                    dc.DataType = System.Type.GetType(arrStructure[1]);
                                    break;
                            }

                            hsLength.Add(arrStructure[0].ToString().ToLower(), arrStructure[2]);

                            dt.Columns.Add(dc);

                            lineLength = lineLength + int.Parse(arrStructure[2]);

                            line = sr.ReadLine();
                        }

                        sr.Close();

                        sr = new StreamReader(file);

                        line = sr.ReadLine();

                        List<string> arrlines = new List<string>();

                        if (line != null)
                        {
                            if (line.Length == lineLength)
                            {
                                arrlines.Add(line);
                                line = sr.ReadLine();

                                while (line != null)
                                {
                                    arrlines.Add(line);
                                    line = sr.ReadLine();
                                }
                            }
                            else
                                for (int i = 0; i <= line.Length - 1; i += lineLength)
                                {
                                    arrlines.Add(line.Substring(i, lineLength));
                                }
                        }

                        sr.Close();
                        sr.Dispose();
                        sr = null;

                        //while (line != null)
                        foreach (string l in arrlines)
                        {
                            line = l.PadRight(lineLength);
                            rowCollection = dt.Rows;
                            row = dt.NewRow();
                            placeHolder = 0;

                            int j = int.Parse(hsLength[dt.Columns[0].ColumnName.ToLower()].ToString());

                            for (int i = 0; i <= dt.Columns.Count - 1; i++)
                            {
                                switch (dt.Columns[i].DataType.ToString())
                                {
                                    case "System.Decimal":

                                        if (hsColumns[dt.Columns[i].ColumnName].ToString() == "System.Zoned.Signed")
                                        {
                                            row[dt.Columns[i].ColumnName] = ConvertZoned(line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString())), true);
                                        }
                                        else if (hsColumns[dt.Columns[i].ColumnName].ToString() == "System.Zoned.Unsigned")
                                        {
                                            row[dt.Columns[i].ColumnName] = ConvertZoned(line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString())), false);
                                        }
                                        else
                                        {
                                            row[dt.Columns[i].ColumnName] = long.Parse(line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString())));
                                        }


                                        break;

                                    case "System.Integer":
                                    case "System.Int64":
                                        row[dt.Columns[i].ColumnName] = long.Parse(line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString())));
                                        break;

                                    case "System.DateTime":
                                        string date = line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString()));
                                        DateTime dateTimeInfo = new DateTime();

                                        if (date.Trim().Length == 0)
                                            dateTimeInfo = new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(4, 2)), int.Parse(date.Substring(6, 2)));

                                        row[dt.Columns[i].ColumnName] = dateTimeInfo;
                                        break;

                                    default:
                                        row[dt.Columns[i].ColumnName.ToUpper()] = line.Substring(placeHolder, int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString()));
                                        break;
                                }

                                placeHolder += int.Parse(hsLength[dt.Columns[i].ColumnName.ToLower()].ToString());
                            }

                            dt.Rows.Add(row);


                        }


                    }



                   
                }
                else
                {
                    dt = (DataTable)TextFiles[fileName];
                }


                if (strSQL.ToUpper().IndexOf(" WHERE ") >= 0)
                {
                    whereclause = strSQL.Substring(strSQL.ToUpper().IndexOf(" WHERE ") + 7).TrimStart();
                }

                if (whereclause.ToUpper().IndexOf(" ORDER BY ") >= 0)
                {
                    orderby = whereclause.Substring(whereclause.ToUpper().IndexOf(" ORDER BY ") + 10).TrimStart();
                    whereclause = whereclause.Substring(0, whereclause.ToUpper().IndexOf(" ORDER BY "));
                }

                else if (strSQL.ToUpper().IndexOf(" ORDER BY ") >= 0)
                {
                    orderby = strSQL.Substring(strSQL.ToUpper().IndexOf(" ORDER BY ") + 10).TrimStart();
                }


                if (!TextFiles.Contains(fileName))
                {
                    TextFiles.Add(fileName, dt);
                }

                if (whereclause.Length == 0 && orderby.Length == 0)
                    return dt;


                while ((whereclause.IndexOf("CONVERT(INTEGER, CONVERT(CHAR(8),") >= 0))
                {
                    string strColumn = string.Empty;
                    string strReplace = string.Empty;
                    string strOper = string.Empty;
                    string strDate = string.Empty;
                    string[] arrWhere = whereclause.Split(' ');


                    for (int i = 0; i <= arrWhere.Length - 1; i++)
                    {
                        if (arrWhere[i] == "CONVERT(INTEGER,")
                        {
                            strColumn = arrWhere[i + 2].Replace(",", "");
                            strOper = arrWhere[i + 4];
                            strDate = arrWhere[i + 5];
                            strDate = "'" + strDate.Substring(0, 4) + "/" + strDate.Substring(4, 2) + "/" + strDate.Substring(6, 2) + "'";
                            strReplace = arrWhere[i] + " " + arrWhere[i + 1] + " " + arrWhere[i + 2] + " " + arrWhere[i + 3] + " " + arrWhere[i + 4] + " " + arrWhere[i + 5].Substring(0, 8);
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    whereclause = whereclause.Replace(strReplace, strColumn + " " + strOper + " " + strDate);


                }

                dtTemp = dt.Clone();
                DataRow[] tmpDataRow = dt.Select(whereclause, orderby);



                for (int i = 0; i <= tmpDataRow.Length - 1; i++)
                {

                    dtTemp.Rows.Add(tmpDataRow[i].ItemArray);

                }

                return dtTemp;


            }



            catch (Exception ex)
            {
                return dt;
            }
        }



        private static decimal ConvertZoned(string value, bool signed = false)
        {
            try
            {
                int result = 0;
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    result = int.Parse(value.Substring(value.Length - 1, 1));
                }

                signed = false;
            }
            catch
            {


                signed = true;
            }

            if (signed)
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    value = "0";
                }
                int overpunchDigit = GetOverpunchDigit(value.Substring(value.Length - 1, 1));
                bool isPositive = GetOverpunchSign(value.Substring(value.Length - 1, 1));

                if (value == "0")
                {
                    return 0;
                }


                if (isPositive)
                {
                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit);
                }
                else
                {
                    return Convert.ToDecimal(value.Substring(0, value.Length - 1) + overpunchDigit) * -1;
                }
            }
            else
            {
                if (!IsNumeric(value))
                {
                    decimal decimalValue = 0;

                    if (value.Trim().Length != 0)
                    {
                        for (int i = 0; i <= value.Length - 1; i++)
                        {
                            if (Convert.ToInt32(value.Substring(i, 1)) != 0 && Convert.ToInt32(value.Substring(i, 1)) != 32)
                            {
                                decimalValue = Convert.ToDecimal(value);
                            }
                        }
                    }

                    return decimalValue;
                }
                else
                {
                    return Convert.ToDecimal(value);
                }
            }
        }


        private static bool IsNumeric(string value)
        {
            try
            {
                int result = int.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private static int GetOverpunchDigit(string value)
        {
            switch (value)
            {
                case "{":
                    return 0;
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "}":
                    return 0;
                case "J":
                    return 1;
                case "K":
                    return 2;
                case "L":
                    return 3;
                case "M":
                    return 4;
                case "N":
                    return 5;
                case "O":
                    return 6;
                case "P":
                    return 7;
                case "Q":
                    return 8;
                case "R":
                    return 9;
                case "p":
                    return 0;
                case "q":
                    return 1;
                case "r":
                    return 2;
                case "s":
                    return 3;
                case "t":
                    return 4;
                case "u":
                    return 5;
                case "v":
                    return 6;
                case "w":
                    return 7;
                case "x":
                    return 8;
                case "y":
                    return 9;
                default:
                    return 0;
            }
        }

        private static bool GetOverpunchSign(string value)
        {
            switch (value)
            {
                case "{":
                    return true;
                case "A":
                    return true;
                case "B":
                    return true;
                case "C":
                    return true;
                case "D":
                    return true;
                case "E":
                    return true;
                case "F":
                    return true;
                case "G":
                    return true;
                case "H":
                    return true;
                case "I":
                    return true;
                case "}":
                    return false;
                case "J":
                    return false;
                case "K":
                    return false;
                case "L":
                    return false;
                case "M":
                    return false;
                case "N":
                    return false;
                case "O":
                    return false;
                case "P":
                    return false;
                case "Q":
                    return false;
                case "R":
                    return false;
                case "p":
                    return false;
                case "q":
                    return false;
                case "r":
                    return false;
                case "s":
                    return false;
                case "t":
                    return false;
                case "u":
                    return false;
                case "v":
                    return false;
                case "w":
                    return false;
                case "x":
                    return false;
                case "y":
                    return false;
                default:
                    return false;
            }
        }



    }


}
