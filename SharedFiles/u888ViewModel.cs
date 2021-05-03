using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using rma.Cobol;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;
using System.Diagnostics;

namespace rma.Views
{
    public class U888ViewModel : CommonFunctionScr
    {

        public U888ViewModel()
        {

        }

        #region FD Section
        // FD: input_file
        private Input_rec objInput_rec = null;
        private ObservableCollection<Input_rec> Input_rec_Collection;

	 // FD: output_file
	   private Output_rec objOutput_rec = null;
        private ObservableCollection<Output_rec> Output_rec_Collection;


        #endregion

        #region Properties
        private string _common_f_status;
        public string common_f_status
        {
            get
            {
                return _common_f_status;
            }
            set
            {
                if (_common_f_status != value)
                {
                    _common_f_status = value;
                    _common_f_status = _common_f_status.ToUpper();
                    RaisePropertyChanged("common_f_status");
                }
            }
        }

        private string _common_i_status;
        public string common_i_status
        {
            get
            {
                return _common_i_status;
            }
            set
            {
                if (_common_i_status != value)
                {
                    _common_i_status = value;
                    _common_i_status = _common_i_status.ToUpper();
                    RaisePropertyChanged("common_i_status");
                }
            }
        }

       /* private string _continue_flag;
        public string continue_flag
        {
            get
            {
                return _continue_flag;
            }
            set
            {
                if (_continue_flag != value)
                {
                    _continue_flag = value;
                    _continue_flag = _continue_flag.ToUpper();
                    RaisePropertyChanged("continue_flag");
                }
            }
        } */

        private string _err_msg_comment;
        public string err_msg_comment
        {
            get
            {
                return _err_msg_comment;
            }
            set
            {
                if (_err_msg_comment != value)
                {
                    _err_msg_comment = value;
                    _err_msg_comment = _err_msg_comment.ToUpper();
                    RaisePropertyChanged("err_msg_comment");
                }
            }
        }

       /* private string _input_file_name;
        public string input_file_name
        {
            get
            {
                return _input_file_name;
            }
            set
            {
                if (_input_file_name != value)
                {
                    _input_file_name = value;
                    _input_file_name = _input_file_name.ToUpper();
                    RaisePropertyChanged("input_file_name");
                }
            }
        } */

        private string _sys_date_long;
        public string sys_date_long
        {
            get
            {
                return _sys_date_long;
            }
            set
            {
                if (_sys_date_long != value)
                {
                    _sys_date_long = value;
                    _sys_date_long = _sys_date_long.ToUpper();
                    RaisePropertyChanged("sys_date_long");
                }
            }
        }

      /*  private string _ws_ack;
        public string ws_ack
        {
            get
            {
                return _ws_ack;
            }
            set
            {
                if (_ws_ack != value)
                {
                    _ws_ack = value;
                    _ws_ack = _ws_ack.ToUpper();
                    RaisePropertyChanged("ws_ack");
                }
            }
        } */


        #endregion

        #region Working Storage Section
        private int err_ind;
        private string input_file_name = "u020_tapeout_file";
        private string tape_file_name = "u020_tapeout_file2";
        private string ws_ack = "Y"; //"N";

        private string file_status_grp;
        private string input_fstat;
        private string input_istat;
        private string output_fstat;
        private string output_istat;
        //private string common_f_status;
        //private string common_i_status;
        private string eof_tape_flag;
        private string tape_eof = "Y";
        private string tape_not_eof = "N";
        private string eof_report_flag;
        private string report_eof = "Y";
        private string report_not_eof = "N";
        private string continue_flag;
        private string do_continue = "Y";
        private string dont_continue = "N";

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "invalid reply";
        //private string filler = "TAPE NOT PROPERLY MOUNTED";
        //private string filler = "REPORT NOT AVAILABLE";
        //private string filler = "ERROR MESSAGE #4 GOES HERE";
        private string error_messages_r_grp;
        private string[] err_msg = {"", "invalid reply", "TAPE NOT PROPERLY MOUNTED", "REPORT NOT AVAILABLE", "ERROR MESSAGE #4 GOES HERE" };
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        //private string sys_date_long;
        private string sys_date_long_r_grp;
        private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        private int sys_mm;
        private int sys_dd;
        private int sys_date_numeric;

        private string sys_date_y2kfix_grp;
        private string sys_date_left;
        //private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        private string run_date_grp;
        private int run_yy;
        //private string filler = "/";
        private int run_mm;
        //private string filler = "/";
        private int run_dd;

        private string sys_time_grp;
        private int sys_hrs;
        private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;

        private string endOfJob = "End of Job";
        private WriteFile objOutFile = null;
        private int row;

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "U888",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 30,Data1 = "OHIP TAPE 79 to 158 byte copy",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-continue.",Line = "20",Col = 32,Data1 = "CONTINUE (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-continue.",Line = "20",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "continue_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ok-to-continue"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "program-in-progress.",Line = "22",Col = 27,Data1 = "PROGRAM IN PROGRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "22",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "22",Col = 32,Data1 = "COBOL FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "22",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_f_status",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "23",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "23",Col = 32,Data1 = "INFOS FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "23",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "common_i_status",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "input_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-report-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-warning-full-tape.",Line = "19",Col = 20,Data1 = " WARNING !",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-warning-full-tape.",Line = "19",Col = 31,Data1 = "ALL REPORTS NOT PROCESSED---TAPE FULL!!",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acknowledge.",Line = "20",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acknowledge.",Line = "20",Col = 20,Data1 = " ACKNOWLEDGE ERROR BY PRESSING 'Y'",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acknowledge.",Line = "20",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_ack",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ack"}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_input_file_section()
        {

            //     use after standard error procedure on  input-file.;
        }

        private void input_file_proc()
        {

            common_f_status = input_fstat;
            common_i_status = input_istat;
            //     display "ERROR - INPUT FILE".;
            //     display file-status-display.;
            //     if input-fstat = 91;
            //     then;
            err_ind = 3;
            // 	perform za0-common-error	thru	za0-99-exit;
            //     else;
            // 	display confirm;
            // 	stop "HIT NEW-LINE TO CONTINUE".;
            //     stop run.;
        }

        private void err_output_file_section()
        {

            //     use after standard error procedure on  output-file.;
        }

        private void output_file_proc()
        {

            common_f_status = output_fstat;
            common_i_status = output_istat;
            //     display "ERROR - OUTPUT FILE".;
            //     display file-status-display.;
            //     if output-fstat = 10 or 34;
            //     then;
            eof_tape_flag = "Y";
            //     else;
            // 	if output-fstat = 91;
            // 	then;
            err_ind = 2;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    display confirm;
            // 	    stop "HIT NEW-LINE TO CONTINUE";
            // 	    stop run;
            // 	else;
            // 	    display confirm;
            // 	    stop "HIT NEW-LINE TO CONTINUE";
            // 	    stop run.;
        }
      
        public void mainline()
        {
            try {

                objOutput_rec = new Output_rec();

                Input_rec_Collection =  Read_u020_tapeout_file(true);
                objOutFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + tape_file_name );


                //     perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();
                aa0_20_ok_to_continue();
                aa0_99_exit();

                // perform ab0-processing		thru ab0-99-exit;
                // 	   until	     report-eof.;

                do
                {
                    ab0_processing();
                    ab0_99_exit();
                } while (!eof_report_flag.Equals(report_eof));

                //  perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_10_tape_full();
                az0_99_exit();

                //     stop run.;
            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objOutFile != null)
                {
                    objOutFile.CloseOutputFile();
                    objOutFile = null;
                }
            }
        }

        private void aa0_initialization()
        {
            //     accept sys-date			from	date.;
            sys_date_grp = Sysdate();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();
        }

        private void aa0_20_ok_to_continue()
        {

            continue_flag = "Y";
            // if do-continue  then         
            if (continue_flag.Equals(do_continue)) {
                // 	  next sentence;
            }
            //  else if dont-continue then            
            else if (continue_flag.Equals(dont_continue)) {
                // 	    stop run;
                throw new Exception(endOfJob);
            }
            else {
                      err_ind = 1;
                //    perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	    go to aa0-20-ok-to-continue.;
                aa0_20_ok_to_continue();
                return;
            }

            //     open  input input-file.;
            //     open output output-file.;

            eof_tape_flag = "N";
            eof_report_flag = "N";
            continue_flag = "N";

            //  perform da0-read-input-file         thru da0-99-exit.;
            da0_read_input_file();
            da0_99_exit();

            // if report-eof then    
            if (eof_report_flag.Equals(report_eof)) {
                //    next sentence;
            }
            else {
                //   objOutput_rec.output_rec_1 = objInput_rec              pic.input_rec;
                objOutput_rec.Output_rec_1 = objInput_rec.Input_rec1;
            }
        }

        private void aa0_99_exit()
        {

            //     exit.;
        }

        private void ab0_processing()
        {

            // perform da0-read-input-file                   thru da0-99-exit.;
            da0_read_input_file();
            da0_99_exit();

            // if report-eof then      
            if (eof_report_flag.Equals(report_eof)) {
                    objOutput_rec.Output_rec_2 = "";
                   return;
            }
            else {
                // objOutput_rec.output_rec_2 = objInput_rec              pic.input_rec;
                objOutput_rec.Output_rec_2 = objInput_rec.Input_rec1;
            }

            //  write output-rec.;
            objOutFile.AppendOutputFile(objOutput_rec.Output_rec_1 ,false);
            objOutFile.AppendOutputFile(objOutput_rec.Output_rec_2);

            objOutput_rec.Output_rec_1 = "";
            objOutput_rec.Output_rec_2 = "";

            // perform da0-read-input-file                   thru da0-99-exit.;
            da0_read_input_file();
            da0_99_exit();

            // if report-eof then        
            if (eof_report_flag.Equals(report_eof)) {
                //    next sentence;
            }
            else {                
                objOutput_rec.Output_rec_1 = objInput_rec.Input_rec1;
            }
        }

        private void ab0_99_exit()
        {

            //     exit.;
        }

        private void da0_read_input_file()
        {

            //     read input-file;   // todo....
            //          at end;
            //        move "Y"                              to eof-report-flag. 

            if (row >= Input_rec_Collection.Count() || Input_rec_Collection.Count() == 0 )
            {
                eof_report_flag = "Y";
                return;
            }

            objInput_rec = Input_rec_Collection[row];                       
            row++;           
        }

        private void da0_99_exit()
        {

            //     exit.;
        }

        private void az0_end_of_job()
        {

            //     close output-file;
            //            input-file.;
        }

        private void az0_10_tape_full()
        {

            // if tape-eof then         
            if (eof_tape_flag.Equals(tape_eof)) {
                // 	   display scr-warning-full-tape;
                Console.WriteLine(" WARNING !" + "ALL REPORTS NOT PROCESSED---TAPE FULL!!");
                //     display scr-acknowledge;
                Console.WriteLine(" ACKNOWLEDGE ERROR BY PRESSING 'Y'");
                //     accept scr-ack;

                //     if ws-ack not = "Y" then            
                if (!ws_ack.ToUpper().Equals("Y")) {
                    //  go to az0-10-tape-full.;
                    az0_10_tape_full();
                    return;
                }
            }
        }

        private void az0_99_exit()
        {

            //     exit.;
        }

        private void za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Console.WriteLine(" ERROR - " + input_file_name + " " + err_msg_comment);
            //     display confirm.;
            //     stop " ".;
            //     display blank-line-24.;
        }

        private void za0_99_exit()
        {

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate()
        {

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {

            //     exit.;
        }

        #endregion
    }
}

