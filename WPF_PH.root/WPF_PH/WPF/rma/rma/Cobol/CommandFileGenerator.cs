using System;
using System.Text;
using System.Configuration;
using System.IO;


namespace rma.Cobol
{
    public static class CommandFileGenerator
    {
        #region Variables

        private static string _inputFile;
        private static string _outputFile;
        private static string command;

        private static StreamWriter sw;

        #endregion Variables

        #region Methods

        /// <summary>
        /// Generates the command file for fax, email, or archive.
        /// </summary>
        public static void GenerateCommandFile(string inputFile, string outputFile, string attachment, string printWhere)
        {
            _inputFile = inputFile;
            _outputFile = ConfigurationManager.AppSettings["StrLocation"] + "\\" +
                          outputFile.Replace(ApplicationState.Current.TempDir, "");

            try
            {
                if (File.Exists(_outputFile))
                    File.Delete(_outputFile);

                CreateCommandFile(attachment, printWhere);
            }

            catch (Exception e)
            {
                // Handle exception.
            }
        }


        private static void CreateCommandFile(string attachment, string printWhere)
        {
            sw = new StreamWriter(_outputFile, false, Encoding.Default);
            string keyWord = string.Empty;
            string userdata = string.Empty;
            string subject = string.Empty;
            bool addEmailRemarks = false;
            bool addFaxRemarks = false;
            bool writeLine = true;

            try
            {
                string line = null;

                if (printWhere == "E")
                    keyWord = ".EMAIL";
                else
                    keyWord = ".FAX";

                using (var sr = new StreamReader(_inputFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("."))
                        {
                            line = line.TrimEnd();
                            if (line.IndexOf(" ") > -1)
                            {
                                if (line.Trim().StartsWith(keyWord))
                                {
                                    if (line.IndexOf("[USERDATA1=") > -1)
                                    {
                                        if (keyWord == ".EMAIL")
                                            userdata = line.Substring(18).Replace("]", "").Replace("(s)", "").Trim();
                                        else
                                            userdata = line.Substring(16).Replace("]", "").Replace("(s)", "").Trim();
                                        writeLine = true;
                                    }

                                    if (line.IndexOf("[SUBJECT=") > -1)
                                    {
                                        if (keyWord == ".EMAIL")
                                            subject =
                                                line.Substring(16).Replace("]", "").Replace(".", "").Replace(";", "").
                                                    Replace(":", "").Replace(",", "").Trim();
                                        else
                                            subject =
                                                line.Substring(14).Replace("]", "").Replace(".", "").Replace(";", "").
                                                    Replace(":", "").Replace(",", "").Trim();
                                        writeLine = true;
                                    }

                                    // Id 2394 laurie - subject is blank for coins which uses keyword sub=
                                    if (line.IndexOf("[SUB=") > -1)
                                    {
                                        if (keyWord == ".EMAIL")
                                            subject =
                                                line.Substring(12).Replace("]", "").Replace(".", "").Replace(";", "").
                                                    Replace(":", "").Replace(",", "").Trim();
                                        else
                                            subject =
                                                line.Substring(10).Replace("]", "").Replace(".", "").Replace(";", "").
                                                    Replace(":", "").Replace(",", "").Trim();
                                        writeLine = true;
                                    }

                                    if (line.IndexOf("[REMARKS=") > -1)
                                    {
                                        if (line.IndexOf("BEGIN") > -1)
                                        {
                                            if (keyWord == ".EMAIL")
                                                addEmailRemarks = true;
                                            else
                                                addFaxRemarks = true;
                                        }

                                        if (line.IndexOf("END") > -1)
                                        {
                                            if (keyWord == ".EMAIL")
                                                addEmailRemarks = false;
                                            else
                                                addFaxRemarks = false;
                                        }
                                        writeLine = true;
                                    }

                                    if (line.IndexOf("<SIG") > -1 || line.IndexOf("<LOGO") > -1)
                                        writeLine = false;

                                    if (writeLine)
                                        sw.WriteLine(line.Substring(keyWord.Length).Trim());
                                }
                            }
                        }

                        if (addEmailRemarks || addFaxRemarks)
                        {
                            if (line.Trim().StartsWith(".") == false)
                                sw.WriteLine(line);
                        }
                    }
                }

                //Add the attachement
                sw.WriteLine("[ATTACH=" + attachment.Replace(".txt", ".pdf") + ",,\"" + userdata + "-" + subject +
                             ".pdf\" ]");
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }

            catch (Exception)
            {
            }
        }

        #endregion Methods
    }
}
