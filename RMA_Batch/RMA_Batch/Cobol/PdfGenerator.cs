using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace rma.Cobol
{
    public class PdfGenerator : IDisposable
    {
        #region Variables

        private const float cLineSpacing = 11.365F;
        private const float cPageWidth = 612F;
        private const float cPageHeight = 792F;
        private const float cMarginLeft = 72F;
        private const float cMarginRight = 56F;
        private const float cMarginTop = 32F;
        private const float cMarginBottom = 36F;
        private const float cImageScaleOffset = 10F;
        private const string cImageExtension = ".tiff";

        private readonly bool _deleteInputFile;
        private readonly bool _displayPDF;
        private readonly string _fontPath;
        private readonly bool _isText;
        private readonly string _printWhere;
        private readonly float cFontSize = 10F;
        private string _author;
        private int _currentLineNumber = 1;
        private Document _document;
        private Font _font;
        private string _imagePath;
        private bool _includeInPDF;

        private string _inputFile;
        private string _keywords;
        private bool _marginNotStandard;
        private int _maxLinesPerPage = 64;
        private int _need;
        private string _outputFile;
        private string _outputFileName;
        private int _pageSize = 59;
        private string _subject;
        private string _title;
        private int _top = 6;
        private string[] _usefont;
        private BaseFont baseFont;
        private bool disposed;
        private bool isBold;
        private bool isItalicize;
        private float pageHeight;
        private BaseFont primaryFont;
        private float primaryFontSize;
        private BaseFont secondaryFont;
        private float secondaryFontSize;

        #endregion Variables

        #region Constructor

        public PdfGenerator(string inputFile, string outputFile, string title, string printWhere, bool displayPDF = true,
                            bool deleteInputFile = false, bool isText = false)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
            _isText = isText;
            _imagePath = ConfigurationManager.AppSettings["TiffLocation"];
            _fontPath = ConfigurationManager.AppSettings["FontLocation"];
            _title = title;
            _author = ConfigurationManager.AppSettings["PdfAuthor"];
            _subject = ConfigurationManager.AppSettings["PdfSubject"];
            _keywords = ConfigurationManager.AppSettings["PdfKeywords"];
            _deleteInputFile = deleteInputFile;
            _displayPDF = displayPDF;
            _printWhere = printWhere;
            InitializeFont();


            var where = "";

            var tempDir = Path.GetTempPath() + "Rmaapp\\";

            switch (printWhere)
            {
                case "E":
                    where = "Email";
                    break;
                case "P":
                    where = "Screen";
                    break;
                case "F":
                    where = "Fax";
                    break;
                case "I":
                    where = "Imaging";
                    break;
            }

            try
            {
                if (Directory.Exists("\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug"))
                {
                    if (
                        File.Exists(inputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".txt",
                                                                                                              "_" +
                                                                                                              where +
                                                                                                              ".txt")))
                        File.Delete(inputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".txt",
                                                                                                              "_" +
                                                                                                              where +
                                                                                                              ".txt"));
                    File.Copy(inputFile,
                              inputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".txt",
                                                                                                        "_" + where +
                                                                                                        ".txt"));
                }
            }
            catch
            {
            }
        }

        #endregion Constructor

        #region Properties

        public string InputFile
        {
            get { return _inputFile; }
            set { _inputFile = value; }
        }

        public string OutputFile
        {
            get { return _outputFile; }
            set { _outputFile = value; }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public string Creator
        {
            get { return _author; }
            set { _author = value; }
        }

        #endregion Properties

        #region Methods

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    if (_document != null && _document.IsOpen())
                        _document.Close();
                    _document = null;
                }
            }
            disposed = true;
        }

        private void InitializeFont()
        {
            baseFont = BaseFont.CreateFont(_fontPath + @"\cour.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            _font = new Font(baseFont, cFontSize);
            _font.SetColor(0, 0, 0);
            _usefont = new string[2];
            _usefont[0] = "";
            _usefont[1] = "";
            primaryFont = baseFont;
            secondaryFont = baseFont;
            isBold = false;
            isItalicize = false;
            secondaryFontSize = cFontSize;
        }

        /// <summary>
        /// Reads the file and generates the PDF.
        /// </summary>
        /// 
        public void GeneratePdf1(string orientation = "P", float fontsize = 0, float marginLeft = 72F,
                                 float marginRight = 56F)
        {
            if (orientation == "P")
            {
                _document = new Document(PageSize.LETTER, marginLeft, marginRight, cMarginTop, cMarginBottom);

                _marginNotStandard = false;
                if (marginLeft != cMarginLeft || marginRight != cMarginRight)
                {
                    _marginNotStandard = true;
                }
            }
            else
            {
                if (orientation == "L")
                {
                    _document = new Document(PageSize.LETTER.Rotate(), marginRight, marginRight, cMarginTop,
                                             cMarginBottom);
                }

                if (orientation == "LB")
                {
                    _document = new Document(PageSize.GetRectangle("162 216").Rotate(), 0F, 0F, 36F, 0F);
                }
            }

            if (fontsize > 0)
                primaryFontSize = fontsize;
            else
                primaryFontSize = cFontSize;

            baseFont = BaseFont.CreateFont(_fontPath + @"\cour.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            _font = new Font(baseFont, primaryFontSize);

            if (orientation == "LB")
                _font.SetStyle(Font.BOLD);

            if (File.Exists(_outputFile))
                File.Delete(_outputFile);
            PdfWriter writer = PdfWriter.GetInstance(_document,
                                                     new FileStream(_outputFile, FileMode.CreateNew, FileAccess.Write));

            try
            {
                //writer.SetEncryption(PdfWriter.STRENGTH128BITS, null, "RMA",
                //                     PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_COPY);

                // Add metadata.
                _document.AddTitle(_title);
                _document.AddSubject(_subject);
                _document.AddKeywords(_keywords);
                _document.AddCreator(_author);
                _document.AddAuthor(_author);

                // Write the information.
                _document.Open();

                ReadFile(orientation);
            }
            catch (Exception e)
            {
                // Handle exception.
            }

            try
            {
                _document.Close();
                _document = null;
                writer.Close();

                if (_displayPDF)
                {
                    var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 300) };
                    dt.Tick += displayPDF;
                    dt.Start();
                }
                else
                {
                    //Create the command file for fax and email
                }
            }
            catch (Exception)
            {
            }
        }

        public void GeneratePdf(string orientation = "P", float fontsize = 0)
        {
            if (orientation == "P")
            {
                _document = new Document(PageSize.LETTER, cMarginLeft, cMarginRight, cMarginTop, cMarginBottom);
            }
            else
            {
                if (orientation == "L")
                {
                    _document = new Document(PageSize.LETTER.Rotate(), cMarginLeft, cMarginRight, cMarginTop,
                                             cMarginBottom);
                }

                if (orientation == "LB")
                {
                    _document = new Document(PageSize.GetRectangle("162 216").Rotate(), 0F, 0F, 36F, 0F);
                }
            }

            if (fontsize > 0)
                primaryFontSize = fontsize;
            else
                primaryFontSize = cFontSize;

            baseFont = BaseFont.CreateFont(_fontPath + @"\cour.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            _font = new Font(baseFont, primaryFontSize);

            if (orientation == "LB")
                _font.SetStyle(Font.BOLD);

            if (File.Exists(_outputFile))
                File.Delete(_outputFile);
            PdfWriter writer = PdfWriter.GetInstance(_document,
                                                     new FileStream(_outputFile, FileMode.CreateNew, FileAccess.Write));

            try
            {
                //writer.SetEncryption(PdfWriter.STRENGTH128BITS, null, "RMA",
                //                     PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_COPY);

                // Add metadata.
                _document.AddTitle(_title);
                _document.AddSubject(_subject);
                _document.AddKeywords(_keywords);
                _document.AddCreator(_author);
                _document.AddAuthor(_author);

                // Write the information.
                _document.Open();

                ReadFile(orientation);
            }
            catch (Exception e)
            {
                // Handle exception.
            }

            try
            {
                _document.Close();
                _document = null;
                writer.Close();

                var tempDir = _outputFile.Substring(0, _outputFile.LastIndexOf("\\") + 1);
                var where = "";

                switch (_printWhere)
                {
                    case "E":
                        where = "Email";
                        break;
                    case "P":
                        where = "Screen";
                        break;
                    case "F":
                        where = "Fax";
                        break;
                    case "I":
                        where = "Imaging";
                        break;
                }

                try
                {
                    if (Directory.Exists("\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug"))
                    {
                        if (
                            File.Exists(_outputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".pdf",
                                                                                                                  "_" +
                                                                                                                  where +
                                                                                                                  ".pdf")))
                            File.Delete(_outputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".pdf",
                                                                                                                  "_" +
                                                                                                                  where +
                                                                                                                  ".pdf"));
                        File.Copy(_outputFile,
                                  _outputFile.Replace(tempDir, "\\\\sssot016\\shared\\public\\CORE\\Prod\\Debug\\").Replace(".pdf",
                                                                                                            "_" + where +
                                                                                                            ".pdf"));
                    }
                }
                catch
                {
                }

                if (_displayPDF)
                {
                    var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 300) };
                    dt.Tick += displayPDF;
                    dt.Start();
                }
                else
                {
                    //Create the command file for fax and email
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Reads the file and generates the PDF.
        /// </summary>
        public void GeneratePdfWithSpecificMargin(float marginLeft, float marginRight, string orientation = "P",
                                                  float fontsize = 0)
        {
            if (orientation == "P")
            {
                _document = new Document(PageSize.LETTER, marginLeft, marginRight, cMarginTop, cMarginBottom);
            }
            else
            {
                if (orientation == "L")
                {
                    _document = new Document(PageSize.LETTER.Rotate(), marginLeft, marginRight, cMarginTop,
                                             cMarginBottom);
                }

                if (orientation == "LB")
                {
                    _document = new Document(PageSize.GetRectangle("162 216").Rotate(), 0F, 0F, 36F, 0F);
                }
            }

            if (fontsize > 0)
                primaryFontSize = fontsize;
            else
                primaryFontSize = cFontSize;

            baseFont = BaseFont.CreateFont(_fontPath + @"\cour.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            _font = new Font(baseFont, primaryFontSize);

            if (orientation == "LB")
                _font.SetStyle(Font.BOLD);

            if (File.Exists(_outputFile))
                File.Delete(_outputFile);
            PdfWriter writer = PdfWriter.GetInstance(_document,
                                                     new FileStream(_outputFile, FileMode.CreateNew, FileAccess.Write));

            try
            {
                //writer.SetEncryption(PdfWriter.STRENGTH128BITS, null, "RMA",
                //                     PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_COPY);

                // Add metadata.
                _document.AddTitle(_title);
                _document.AddSubject(_subject);
                _document.AddKeywords(_keywords);
                _document.AddCreator(_author);
                _document.AddAuthor(_author);

                // Write the information.
                _document.Open();

                ReadFile(orientation);
            }
            catch (Exception e)
            {
                // Handle exception.
            }
            _document.Close();
            _document = null;
            writer.Close();

            if (_displayPDF)
            {
                var dt = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 300) };
                dt.Tick += displayPDF;
                dt.Start();
            }
            else
            {
                //Create the command file for fax and email
            }
        }

        private void displayPDF(object sender, EventArgs e)
        {
            var dt = (sender as DispatcherTimer);
            if (dt != null)
                dt.Stop();
            dt = null;

            Process mprocess = Process.Start(_outputFile);
            mprocess = null;
        }

        /// <summary>
        /// Adds a paragraph from the text provided.
        /// </summary>
        /// <param name="text">The text to add.</param>
        private void AddParagraph(string text)
        {
            if (text.Length == 0)
                text = " ";

            //Check Primary USEFONTS
            switch (_usefont[0])
            {
                case "ROM18":
                    primaryFont = BaseFont.CreateFont(_fontPath + @"\times.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    _font = new Font(primaryFont, 18);
                    break;
                case "SAMEFONT":
                    _font = new Font(baseFont, cFontSize);
                    //Check Secondary USEFONTS
                    switch (_usefont[1])
                    {
                        case "BAR39":
                            secondaryFont = BaseFont.CreateFont(_fontPath + @"\IDAutomationXHC39S.ttf", BaseFont.CP1252,
                                                                BaseFont.EMBEDDED);
                            break;
                        case "BOLD":
                            isBold = true;
                            break;
                        case "ITALICS":
                            isItalicize = true;
                            break;
                        case "LINES":
                            break;
                        case "ROMBOLD10":
                            secondaryFont = BaseFont.CreateFont(_fontPath + @"\times.ttf", BaseFont.CP1252,
                                                                BaseFont.EMBEDDED);
                            secondaryFontSize = 10;
                            break;
                        case "ROMBOLD12":
                            secondaryFont = BaseFont.CreateFont(_fontPath + @"\times.ttf", BaseFont.CP1252,
                                                                BaseFont.EMBEDDED);
                            secondaryFontSize = 12;
                            break;
                        case "SIGS":
                            break;
                    }
                    break;
            }

            var paragraph = new Paragraph();

            string[] tmpText = text.Split('{');

            switch (tmpText.Length)
            {
                case 1:
                    tmpText = tmpText[0].Split('}');

                    switch (tmpText.Length)
                    {
                        case 1:
                            paragraph = new Paragraph(cLineSpacing, new Chunk(tmpText[0], _font));

                            if (text.IndexOf("}") > -1)
                            {
                                _font = new Font(primaryFont, primaryFontSize);
                                _font.SetStyle(Font.NORMAL);
                            }
                            break;
                        case 2:
                            paragraph = new Paragraph(cLineSpacing, new Chunk(tmpText[0], _font));
                            _font = new Font(primaryFont, cFontSize);
                            _font.SetStyle(Font.NORMAL);
                            isBold = false;
                            isItalicize = false;
                            paragraph.Add(new Chunk(tmpText[1], _font));
                            break;
                    }
                    break;
                case 2:
                    if (tmpText[0] != string.Empty)
                    {
                        paragraph = new Paragraph(cLineSpacing, new Chunk(tmpText[0], _font));
                    }

                    tmpText = tmpText[1].Split('}');

                    switch (tmpText.Length)
                    {
                        case 1:
                            _font = new Font(secondaryFont, secondaryFontSize);

                            if (isBold)
                                _font.SetStyle(Font.BOLD);

                            if (isItalicize)
                                _font.SetStyle(Font.ITALIC);

                            if (paragraph.Count > 0)
                                paragraph.Add(new Chunk(tmpText[0], _font));
                            else
                                paragraph = new Paragraph(cLineSpacing, new Chunk(tmpText[0], _font));


                            if (text.IndexOf("}") > -1)
                            {
                                _font = new Font(primaryFont, cFontSize);
                                _font.SetStyle(Font.NORMAL);
                                isBold = false;
                                isItalicize = false;
                            }

                            break;
                        case 2:
                            _font = new Font(secondaryFont, secondaryFontSize);

                            if (isBold)
                                _font.SetStyle(Font.BOLD);

                            if (isItalicize)
                                _font.SetStyle(Font.ITALIC);

                            if (paragraph.Count > 0)
                                paragraph.Add(new Chunk(tmpText[0], _font));
                            else
                                paragraph = new Paragraph(cLineSpacing, new Chunk(tmpText[0], _font));

                            _font = new Font(primaryFont, primaryFontSize);
                            _font.SetStyle(Font.NORMAL);
                            isBold = false;
                            isItalicize = false;
                            paragraph.Add(new Chunk(tmpText[1], _font));

                            break;
                    }
                    break;
            }

            _document.Add(paragraph);
        }

        /// <summary>
        /// Adds the image to the document.
        /// </summary>
        /// <param name="name">The name of the image file.</param>
        private void AddImage(string name)
        {
            Image image = Image.GetInstance(Path.Combine(_imagePath, "form" + name + cImageExtension));
            image.ScaleToFit(cPageWidth + cImageScaleOffset, cPageHeight);
            image.SetAbsolutePosition(1, 0);
            _document.Add(image);
        }

        /// <summary>
        /// Adds the Rma footer to the document.
        /// </summary>
        /// <param name="name">The name of the image file.</param>
        private void AddFooter(string name)
        {
            Image image = Image.GetInstance(Path.Combine(_imagePath, "form" + name + cImageExtension));

            image.ScaleAbsoluteHeight(image.Height / (image.Width / cPageWidth));
            image.ScaleAbsoluteWidth(cPageWidth);

            image.SetAbsolutePosition(1, 0);
            _document.Add(image);
        }

        /// <summary>
        /// Adds the Rma logo to the document.
        /// </summary>
        /// <param name="name">The name of the image file.</param>
        private void AddLogo(string name)
        {
            Image image = Image.GetInstance(Path.Combine(_imagePath, "form" + name + cImageExtension));

            image.ScaleToFit(cPageWidth + cImageScaleOffset, cPageHeight);

            image.SetAbsolutePosition(1, 0);
            _document.Add(image);
        }

        /// <summary>
        /// Reads the file from _inputFile.
        /// </summary>
        /// <returns>A boolean indicating success or failure.</returns>
        public bool ReadFile(string orientation)
        {
            try
            {
                bool firstKeyWordHit = false;
                string line = null;
                string command = null;
                string keyWord = null;
                _includeInPDF = true;
                bool remarksStart = false;
                bool blankPage = true;
                string linecommand = "";

                if (_isText) firstKeyWordHit = true;

                using (var sr = new StreamReader(_inputFile, Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace("¶", string.Empty);

                        if (line.StartsWith(".*****"))
                        {
                        }
                        else if (line.Trim().Length == 0)
                        {
                            if (!firstKeyWordHit && line.Trim().Length > 0)
                                firstKeyWordHit = true;

                            if (_includeInPDF && firstKeyWordHit)
                            {
                                CheckAndWriteLine(line, orientation);
                            }
                        }
                        else if (line.Trim().Length != 1 && Regex.IsMatch(line.Substring(0, 2), "\\.[A-Z]+"))
                        {
                            firstKeyWordHit = true;

                            line = line.TrimEnd();
                            if (line.IndexOf(" ") > -1)
                                keyWord = line.Substring(0, line.IndexOf(" "));
                            else if (line.IndexOf("=") > -1)
                                keyWord = line.Substring(0, line.IndexOf("="));
                            else
                                keyWord = line;

                            command = line.Substring(keyWord.Length).Trim();
                            keyWord = keyWord.TrimEnd();

                            switch (keyWord.ToUpper())
                            {
                                case ".APPEND":
                                    InsertAttachment(command);
                                    break;
                                //case ".BOTTOM":    //Handled in GenPrint
                                //    break;
                                //case ".COMMENT":   //Handled in GenPrint
                                //    break;
                                //case ".E-LINE":    //Handled in GenPrint
                                //    break;
                                case ".EMAIL [REMARKS":
                                    if (line.IndexOf("=BEGIN") > -1)
                                    {
                                        _includeInPDF = false;
                                    }

                                    if (line.IndexOf("=END") > -1)
                                    {
                                        _includeInPDF = true;
                                    }
                                    break;
                                case ".FAX [REMARKS":
                                    if (line.IndexOf("=BEGIN") > -1)
                                    {
                                        _includeInPDF = false;
                                    }

                                    if (line.IndexOf("=END") > -1)
                                    {
                                        _includeInPDF = true;
                                    }
                                    break;
                                //case ".F-LINE":     //Handled in GenPrint
                                //    break;
                                case ".FOOTER":
                                    if (_includeInPDF)
                                    {
                                        if (linecommand.Length > 0)
                                        {
                                            SetStartLine(linecommand);
                                            linecommand = "";
                                        }
                                        InsertFooter(command);
                                        blankPage = false;
                                    }
                                    break;
                                case ".FPGSIZE":
                                    //_maxLinesPerPage = Convert.ToInt32(command.Substring(1));  // Seems to be 61 lines...need to fix later.
                                    break;
                                case ".IMAGE":
                                    break;
                                // case ".LASER ACTIVATEPAGE":   //Handled in GenPrint
                                //     break;
                                // case ".LASER DEACTIVATEPAGE":   //Handled in GenPrint
                                //     break;
                                // case ".LASER PAGE":   //Handled in GenPrint
                                //     break;
                                // case ".LASER SIG":   //Handled in GenPrint
                                //     break;
                                case ".LINE":
                                    if (blankPage)
                                    {
                                        linecommand = command;
                                    }
                                    else
                                    {
                                        SetStartLine(command);
                                    }
                                    break;
                                case ".LOGO":
                                    if (_includeInPDF)
                                    {
                                        if (linecommand.Length > 0)
                                        {
                                            SetStartLine(linecommand);
                                            linecommand = "";
                                        }

                                        InsertLogo(command);
                                        blankPage = false;
                                    }
                                    break;
                                // case ".LS":   //Handled in GenPrint
                                //     break;
                                case ".NEED":
                                    _need = Convert.ToInt32(command.Substring(1));
                                    break;
                                case ".PAGE":
                                    if (blankPage)
                                    {
                                        linecommand = "";
                                        _currentLineNumber = 1;
                                    }
                                    else
                                    {
                                        CreatePageBreak();
                                    }

                                    break;
                                // case ".PGSIZE":   //Handled in GenPrint
                                //     break;
                                case ".SIG=":
                                    if (linecommand.Length > 0)
                                    {
                                        SetStartLine(linecommand);
                                        linecommand = "";
                                    }
                                    InsertSignature(line);
                                    blankPage = false;
                                    break;
                                case ".STARTFAXIGNORE":
                                    if (_printWhere == "F" || _printWhere == "E")
                                        _includeInPDF = false;
                                    break;
                                case ".STARTIGNORE":
                                    _includeInPDF = false;
                                    break;
                                case ".STARTIMGIGNORE":
                                    _includeInPDF = false;
                                    break;
                                case ".STARTLSRIGNORE":
                                    _includeInPDF = false;
                                    break;
                                case ".STDFONT":
                                    primaryFont = baseFont;
                                    secondaryFont = baseFont;
                                    _font = new Font(primaryFont, cFontSize);
                                    isBold = false;
                                    isItalicize = false;
                                    _usefont[0] = "";
                                    _usefont[1] = "";
                                    break;
                                case ".STOPFAXIGNORE":
                                    _includeInPDF = true;
                                    break;
                                case ".STOPIGNORE":
                                    _includeInPDF = true;
                                    break;
                                case ".STOPIMGIGNORE":
                                    _includeInPDF = true;
                                    break;
                                case ".STOPLSRIGNORE":
                                    _includeInPDF = true;
                                    break;
                                case ".TOP":
                                    if (_includeInPDF)
                                        CreatePageBreak();
                                    _top = Convert.ToInt32(command.Substring(1));
                                    break;
                                case ".USEFONT":
                                    _usefont = command.Split(' ');
                                    CheckAndWriteLine("", orientation);
                                    break;
                            }
                        }
                        else
                        {
                            //if (line.IndexOf("[REMARKS") > -1 || remarksStart == true)
                            //{
                            //    if (line.IndexOf("=BEGIN") > -1)
                            //        remarksStart = true;

                            //    if (line.IndexOf("=END") > -1)
                            //        remarksStart = false;
                            //}
                            //else
                            //{
                            if (!firstKeyWordHit && line.Trim().Length > 0)
                                firstKeyWordHit = true;

                            if (line.StartsWith("*DOT "))
                                line = line.Substring(5);

                            if (_includeInPDF && firstKeyWordHit)
                            {
                                if (linecommand.Length > 0)
                                {
                                    SetStartLine(linecommand);
                                    linecommand = "";
                                }
                                blankPage = false;
                                CheckAndWriteLine(line, orientation);
                            }
                            //}
                        }
                    }
                }

                if (_deleteInputFile)
                    File.Delete(_inputFile);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CheckAndWriteLine(string line, string orientation)
        {
            // If we have a NEED value > 0, then we have to keep the next n lines together.
            // Since we know the page size, if the number of lines per page less the current line 
            // we're one is less then the need, then start on a new page.  
            if ((_need > 0 && _pageSize - _currentLineNumber + 1 < _need) ||
                (_currentLineNumber > _pageSize && line.Trim().Length > 0) || _currentLineNumber == _maxLinesPerPage)
            {
                double linecount = 0;
                if (line.Trim().Length > 0)
                {
                    CreatePageBreak(true);
                    AddParagraph(line);
                    if (orientation == "P")
                    {
                        if (_marginNotStandard == false)
                        {
                            linecount = Math.Ceiling((double)line.Length / 80);
                        }
                        else
                        {
                            linecount = 1;
                        }
                        _currentLineNumber += Convert.ToInt32(linecount);
                    }
                    else
                    {
                        _currentLineNumber++;
                    }
                }
            }
            else
            {
                //if the currentLineNumber is less than _top, set _top to 1.
                //This if statement is to handle the summary rate sheet.
                double linecount = 0;
                //if (_currentLineNumber == 1)
                //    _top = 1;

                if ((_currentLineNumber != 6) || (_currentLineNumber == 6 && line.Trim().Length > 0) || _top == 1)
                {
                    //Check if the text will fit on the page. If not, do a page break.
                    if (_currentLineNumber + Math.Ceiling((double)line.Length / 80) > _pageSize)
                        CreatePageBreak(true);

                    AddParagraph(line);

                    if (orientation == "P")
                    {
                        if (_marginNotStandard == false)
                        {
                            linecount = Math.Ceiling((double)line.Length / 80);
                        }
                        else
                        {
                            linecount = 1;
                        }

                        if (linecount == 0)
                        {
                            _currentLineNumber++;
                        }
                        else
                        {
                            _currentLineNumber += Convert.ToInt32(linecount);
                        }
                    }
                    else
                    {
                        _currentLineNumber++;
                    }
                }
            }

            // Since we're handling the need above, set the NEED value back to 0.
            _need = 0;
        }

        /// <summary>
        /// Inserts the image based on the APPEND command.
        /// </summary>
        /// <param name="command">The value of the image to insert.</param>
        private void InsertAttachment(string command)
        {
            int position = command.IndexOf("=") + 1;
            string fileName = command.Substring(position).Trim();
            AddImage(fileName);
        }

        /// <summary>
        /// Inserts the image based on the FOOTER command.
        /// </summary>
        /// <param name="command">The value of the image to insert.</param>
        private void InsertFooter(string command)
        {
            int position = command.IndexOf("=") + 1;
            string fileName = command.Substring(position, command.IndexOf(",") - position).Trim();
            AddFooter(fileName);
        }

        /// <summary>
        /// Inserts the image based on the LOGO command.
        /// </summary>
        /// <param name="command">The value of the image to insert.</param>
        private void InsertLogo(string command)
        {
            int position = command.IndexOf("=") + 1;
            string fileName = command.Substring(position, command.IndexOf(",") - position).Trim();
            AddLogo(fileName);
        }

        /// <summary>
        /// Inserts the signature image based on the SIG command.
        /// </summary>
        /// <param name="command">The value of the image to insert.</param>
        private void InsertSignature(string line)
        {
            string command = string.Empty;
            int index = line.IndexOf("<SIG=");

            command = line.Substring(index + 5);
            if (command.EndsWith(">"))
                command = command.Substring(0, command.Length - 1).TrimEnd();

            line = line.Replace(".SIG=", "     ");
            line = line.Substring(0, index);

            var paragraph = new Paragraph(cLineSpacing, new Chunk(line, _font));
            if (command != string.Empty)
            {
                Image image = Image.GetInstance(_imagePath + "\\sign" + command + cImageExtension);
                image.ScaleAbsolute(image.Width / 2.5F, image.Height / 2.5F);
                // Image seems to be two and a half times the size, so divide by 2.5.
                paragraph.Add(new Chunk(image, 0, -(cLineSpacing * 2.5F)));
                // Use 3 instead of 2.5 to get closer to the line.
            }
            _document.Add(paragraph);
        }

        /// <summary>
        /// Sets the start line based on the .LINE command.
        /// </summary>
        /// <param name="command">The value of the .LINE command.</param>
        private void SetStartLine(string command)
        {
            if (command.StartsWith("="))
                command = command.Substring(1);

            for (int count = 1; count < Convert.ToInt32(command); count++)
            {
                AddParagraph(String.Empty);
                _currentLineNumber++;
            }
        }

        /// <summary>
        /// Creates a page break.
        /// </summary>
        /// <param name="startAtTopPosition">A boolean indicating whether the new text should start at the position identified by the .TOP keyword.</param>
        private void CreatePageBreak(bool startAtTopPosition = false)
        {
            _document.NewPage();
            _currentLineNumber = 1;
            if (startAtTopPosition && _top > 5)
                SetStartLine((_top).ToString());
        }

        // Code to create proportional font.
        //bf3 = BaseFont.createFont("c:/windows/fonts/arialbd.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
        //font3 = new Font(bf3, 12);
        //int widths[] = bf3.getWidths();
        //for (int k = 0; k < widths.length; ++k) {
        //if (widths[k] != 0)
        //widths[k] = 600;
        //}

        #endregion Methods
    }
}
