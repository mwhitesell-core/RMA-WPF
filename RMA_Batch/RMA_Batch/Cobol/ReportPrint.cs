using System;
using System.Text;
using System.IO;


namespace rma.Cobol
{
    /*
    public class ReportPrint
     {
         private  StreamWriter _sw;
         private string _previousValue = "";
         private bool start = true;
         private string _fileName;

         public ReportPrint(string filename ,bool deletExisting = true)
         {
             if (deletExisting)
             {
                 if (File.Exists(filename))
                 {
                     File.Delete(filename);
                 }
             }
             _fileName = filename;
             _sw = new StreamWriter(filename, true, Encoding.Default);

         }

         public ReportPrint(string filename, Encoding encoding, bool deletExisting = true)
         {
             if (deletExisting)
             {
                 if (File.Exists(filename))
                 {
                     File.Delete(filename);
                 }
             }
             _fileName = filename;
             _sw = new StreamWriter(filename, true, encoding);
         }

         private void Reinstantiate()
         {
             try {
                 if (_sw == null)
                 {
                     _sw = new StreamWriter(_fileName, true, Encoding.Default);
                 }
             } catch (Exception ex)
             {

             }
         }

         public string PreviousValue
         {
             get { return _previousValue; }
             set
             {
                 if (_previousValue != value)
                 {
                     _previousValue = value;
                 }
             }
         }

         //#1
         public void print(string value, int begin, int end, bool dot = false)
         {
             Reinstantiate();

             if (dot && value.StartsWith("."))
             {
                 value = "*DOT " + value;
                 int length = end + 5 - begin - 1;
                 _sw.Write(Util.Str(value, length));
             }
             else
             {
                 int length = end - begin - 1;
                 _sw.Write(Util.Str(value, length));
             }
             Close();
             return;
         }

         public void print(bool linebreak = false)
         {
             Reinstantiate();
             if (linebreak)
             {
                 _sw.Write("\r\n");
                 Close();
                 return;
             }            
         }

         //#2
         public void print(string value, int begin, bool linebreak = false)
         {
             Reinstantiate();
             if (value != null)
             {
                 _sw.Write(Util.Str(value, value.Length));
             }
             if (linebreak)
             {
                 _sw.Write("\r\n");
                 Close();
                 return;
             }

             PreviousValue = value;
             start = false;
             Close();
             return;
         }


         //#3
         public void print(string value, int begin, int end, int skip)
         {
             Reinstantiate();
             for (int i = 0; i < skip; i++)
             {
                 _sw.Write("\r\n");
             }

             if (begin == 0 && end == 0)
             {
                 _sw.Write(Util.Str(value, value.Length));
                 _sw.Write("\r\n");
             }
             else
             {
                 int length = end - begin - 1;
                 _sw.Write(Util.Str(value, length));
             }
             Close();
             return;
         }

         //#4
         public void print(int value, int begin, int end, string format, bool linebreak = false)
         {
             Reinstantiate();
             int length = end - begin - 1;
             string formattedvalue = String.Format(format, value);

             formattedvalue = formattedvalue.PadLeft(length, ' ');

             _sw.Write(Util.Str(formattedvalue, length));
             if (linebreak)
             {
                 _sw.Write("\r\n");                
             }
             Close();
             return;
         }


         public void print(decimal value, int begin, int end, string format, bool linebreak = false,
                           bool leftjustified = false)
         {
             Reinstantiate();
             int length = end - begin - 1;
             string formattedvalue = String.Format(format, value);

             if (leftjustified)
                 formattedvalue = formattedvalue.PadRight(length, ' ');
             else
                 formattedvalue = formattedvalue.PadLeft(length, ' ');

             _sw.Write(Util.Str(formattedvalue, length));
             if (linebreak)
             {
                 _sw.Write("\r\n");                
             }
             Close();
             return;
         }


         //#5
         public void print(DateTime value, int begin, int end, string format, bool linebreak = false)
         {
             Reinstantiate();
             int length = end - begin - 1;
             string formattedvalue = String.Format(format, value);
             _sw.Write(Util.Str(formattedvalue, length));
             if (linebreak)
             {
                 _sw.Write("\r\n");                
             }
             Close();
             return;
         }

         //#6
         public void print(DateTime value, int begin, string format, bool linebreak = false)
         {
             Reinstantiate();
             string formattedvalue = String.Format(format, value);
             _sw.Write(Util.Str(formattedvalue, value.ToString().Length));
             if (linebreak)
             {
                 _sw.Write("\r\n");                
             }
             Close();
             return;
         }

         //#7
         public void print(int value, int begin, string format, bool linebreak = false)
         {
             Reinstantiate();
             string formattedvalue = String.Format(format, value);
             _sw.Write(Util.Str(formattedvalue, value.ToString().Length));
             if (linebreak)
             {
                 _sw.Write("\r\n");                
             }
             Close();
             return;
         }

         //#8
         public void print(string value, string nextplus, bool linebreak = false)
         {
             Reinstantiate();
             if (PreviousValue == "" && start)
             {
                 PreviousValue = value;
                 start = false;
                 _sw.Write(Util.Str(value, value.Length + 1));
                 Close();
                 return;
             }

             if (PreviousValue != "")
             {
                 for (int i = 0; i < Util.NumInt(nextplus); i++)
                 {
                     _sw.Write(" ");
                     _previousValue += " ";
                 }
             }
             _sw.Write(Util.Str(value, value.Length));
             if (linebreak)
             {
                 _sw.Write("\r\n");
                 start = true;
                 PreviousValue = "";
             }
             PreviousValue += value;
             Close();
             return;
         }

         public void PageBreak()
         {
             Reinstantiate();
             //_sw.Write(".PAGE");
             //_sw.Write("\r\n");
             _sw.Write("\f");
             Close();
         }

         public void Close()
         {
             if (_sw != null)
             {                
                 _sw.Close();             
             }
             _sw = null;
             return;
         }
     }  
    */
    
    public class ReportPrint
      {
          private readonly StreamWriter _sw;
          private string _previousValue = "";
          private bool start = true;

          public ReportPrint(string filename ,bool deletExisting = true)
          {
              if (deletExisting) {
                if (File.Exists(filename))
                 {
                  File.Delete(filename);
                 }
              }
              _sw = new StreamWriter(filename, true, Encoding.Default);
          }

          public ReportPrint(string filename, Encoding encoding, bool deletExisting = true)
          {
             if (deletExisting) {
                if (File.Exists(filename))
                {
                  File.Delete(filename);
                }
             }
              _sw = new StreamWriter(filename, true, encoding);
          }

          public string PreviousValue
          {
              get { return _previousValue; }
              set
              {
                  if (_previousValue != value)
                  {
                      _previousValue = value;
                  }
              }
          }

          //#1
          public void print(string value, int begin, int end, bool dot = false)
          {
              if (dot && value.StartsWith("."))
              {
                  value = "*DOT " + value;
                  int length = end + 5 - begin - 1;
                  _sw.Write(Util.Str(value, length));
              }
              else
              {
                  int length = end - begin - 1;
                  _sw.Write(Util.Str(value, length));
              }

              return;
          }

          public void print(bool linebreak = false)
          {
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
          }

          //#2
          public void print(string value, int begin, bool linebreak = false)
          {
              if (value != null)
              {
                  _sw.Write(Util.Str(value, value.Length));
              }
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }

              PreviousValue = value;
              start = false;
              return;
          }


          //#3
          public void print(string value, int begin, int end, int skip)
          {
              for (int i = 0; i < skip; i++)
              {
                  _sw.Write("\r\n");
              }

              if (begin == 0 && end == 0)
              {
                  _sw.Write(Util.Str(value, value.Length));
                  _sw.Write("\r\n");
              }
              else
              {
                  int length = end - begin - 1;
                  _sw.Write(Util.Str(value, length));
              }
              return;
          }

          //#4
          public void print(int value, int begin, int end, string format, bool linebreak = false)
          {
              int length = end - begin - 1;
              string formattedvalue = String.Format(format, value);

              formattedvalue = formattedvalue.PadLeft(length, ' ');

              _sw.Write(Util.Str(formattedvalue, length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
              return;
          }


          public void print(decimal value, int begin, int end, string format, bool linebreak = false,
                            bool leftjustified = false)
          {
              int length = end - begin - 1;
              string formattedvalue = String.Format(format, value);

              if (leftjustified)
                  formattedvalue = formattedvalue.PadRight(length, ' ');
              else
                  formattedvalue = formattedvalue.PadLeft(length, ' ');

              _sw.Write(Util.Str(formattedvalue, length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
              return;
          }


          //#5
          public void print(DateTime value, int begin, int end, string format, bool linebreak = false)
          {
              int length = end - begin - 1;
              string formattedvalue = String.Format(format, value);
              _sw.Write(Util.Str(formattedvalue, length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
              return;
          }

          //#6
          public void print(DateTime value, int begin, string format, bool linebreak = false)
          {
              string formattedvalue = String.Format(format, value);
              _sw.Write(Util.Str(formattedvalue, value.ToString().Length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
              return;
          }

          //#7
          public void print(int value, int begin, string format, bool linebreak = false)
          {
              string formattedvalue = String.Format(format, value);
              _sw.Write(Util.Str(formattedvalue, value.ToString().Length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  return;
              }
              return;
          }

          //#8
          public void print(string value, string nextplus, bool linebreak = false)
          {
              if (PreviousValue == "" && start)
              {
                  PreviousValue = value;
                  start = false;
                  _sw.Write(Util.Str(value, value.Length + 1));
                  return;
              }

              if (PreviousValue != "")
              {
                  for (int i = 0; i < Util.NumInt(nextplus); i++)
                  {
                      _sw.Write(" ");
                      _previousValue += " ";
                  }
              }
              _sw.Write(Util.Str(value, value.Length));
              if (linebreak)
              {
                  _sw.Write("\r\n");
                  start = true;
                  PreviousValue = "";
              }
              PreviousValue += value;
              return;
          }

          public void PageBreak()
          {
            //_sw.Write(".PAGE");
            //_sw.Write("\r\n");
            _sw.Write("\f");            
          }

          public void Close()
          {
              _sw.Flush();
              _sw.Close();
              _sw.Dispose();
              return;
          }
      }    
      
    
    public class PrintLine
    {
        public string Text_Line { get; set; }
    }
}
