using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using rma.Cobol.Reports;

namespace rma.Cobol
{
    /*
    public class WriteFile
    {
        private StreamWriter _sw;
        private string _fileName;
        
        public  WriteFile(string filename, bool deletExisting = true)
        {
            _fileName = filename;
            if (deletExisting)
            {
                if (File.Exists(filename))
                    File.Delete(filename);
            }
                        
            _sw = new StreamWriter(filename, true, Encoding.Default);
            CloseOutputFile();
        }

        
        public void AppendOutputFile(string value,bool lineFeedCR = true)
        {
            if (_sw == null) {
                _sw = new StreamWriter(_fileName, true, Encoding.Default);
            }
            if (lineFeedCR)
                _sw.WriteLine(value);
            else
                _sw.Write(value);

            CloseOutputFile();
        }

        public void CloseOutputFile()
        {
            if (_sw != null)
            {
                _sw.Close();
            }
            _sw = null;
        }
    } */
    
    public class WriteFile
    {
        private StreamWriter _sw;
        private string _fileName;

        public WriteFile(string filename, bool deletExisting = true)
        {
            _fileName = filename;
            if (deletExisting)
            {
                if (File.Exists(filename))
                    File.Delete(filename);
            }

            _sw = new StreamWriter(filename, true, Encoding.Default);            
        }


        public void AppendOutputFile(string value, bool lineFeedCR = true)
        {           
            if (lineFeedCR)
                _sw.WriteLine(value);
            else
                _sw.Write(value);
            
        }

        public void CloseOutputFile()
        {
            if (_sw != null)
            {
                _sw.Close();
            }
            _sw = null;
        }
    } 
}
