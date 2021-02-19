using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.Windows.UI;
using RmaDAL;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.IO;
using System.Diagnostics;
using rma.Cobol;

namespace rma.Views
{
    public delegate void M070ExitCobolScreen();
    public class M070ViewModel : CommonFunctionScr
    {

        public event M070ExitCobolScreen ExitCobol;

        public M070ViewModel()
        {

        }

        #region FD Section
        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: company_mstr	Copy : f123_company_mstr.fd
        private F123_COMPANY_MSTR objCompany_mstr_rec = null;
        private ObservableCollection<F123_COMPANY_MSTR> Company_mstr_rec_Collection;


        #endregion

        #region Properties
        private string _acc_mod_rej;
        public string acc_mod_rej
        {
            get
            {
                return _acc_mod_rej;
            }
            set
            {
                if (_acc_mod_rej != value)
                {
                    _acc_mod_rej = value;
                    _acc_mod_rej = _acc_mod_rej.ToUpper();
                    RaisePropertyChanged("acc_mod_rej");
                }
            }
        }

        private string _company_name;
        public string company_name
        {
            get
            {
                return _company_name;
            }
            set
            {
                if (_company_name != value)
                {
                    _company_name = value;
                    _company_name = _company_name.ToUpper();
                    RaisePropertyChanged("company_name");
                }
            }
        }

        private string _confirm_space;
        public string confirm_space
        {
            get
            {
                return _confirm_space;
            }
            set
            {
                if (_confirm_space != value)
                {
                    _confirm_space = value;
                    _confirm_space = _confirm_space.ToUpper();
                    RaisePropertyChanged("confirm_space");
                }
            }
        }

        private int _ctr_company_mstr_reads;
        public int ctr_company_mstr_reads
        {
            get
            {
                return _ctr_company_mstr_reads;
            }
            set
            {
                if (_ctr_company_mstr_reads != value)
                {
                    _ctr_company_mstr_reads = value;
                    RaisePropertyChanged("ctr_company_mstr_reads");
                }
            }
        }

        private int _ctr_dept_mstr_adds;
        public int ctr_dept_mstr_adds
        {
            get
            {
                return _ctr_dept_mstr_adds;
            }
            set
            {
                if (_ctr_dept_mstr_adds != value)
                {
                    _ctr_dept_mstr_adds = value;
                    RaisePropertyChanged("ctr_dept_mstr_adds");
                }
            }
        }

        private int _ctr_dept_mstr_changes;
        public int ctr_dept_mstr_changes
        {
            get
            {
                return _ctr_dept_mstr_changes;
            }
            set
            {
                if (_ctr_dept_mstr_changes != value)
                {
                    _ctr_dept_mstr_changes = value;
                    RaisePropertyChanged("ctr_dept_mstr_changes");
                }
            }
        }

        private int _ctr_dept_mstr_deletes;
        public int ctr_dept_mstr_deletes
        {
            get
            {
                return _ctr_dept_mstr_deletes;
            }
            set
            {
                if (_ctr_dept_mstr_deletes != value)
                {
                    _ctr_dept_mstr_deletes = value;
                    RaisePropertyChanged("ctr_dept_mstr_deletes");
                }
            }
        }

        private int _ctr_dept_mstr_reads;
        public int ctr_dept_mstr_reads
        {
            get
            {
                return _ctr_dept_mstr_reads;
            }
            set
            {
                if (_ctr_dept_mstr_reads != value)
                {
                    _ctr_dept_mstr_reads = value;
                    RaisePropertyChanged("ctr_dept_mstr_reads");
                }
            }
        }

        private int _ctr_dept_mstr_writes;
        public int ctr_dept_mstr_writes
        {
            get
            {
                return _ctr_dept_mstr_writes;
            }
            set
            {
                if (_ctr_dept_mstr_writes != value)
                {
                    _ctr_dept_mstr_writes = value;
                    RaisePropertyChanged("ctr_dept_mstr_writes");
                }
            }
        }

        private string _dept_addr1;
        public string dept_addr1
        {
            get
            {
                return _dept_addr1;
            }
            set
            {
                if (_dept_addr1 != value)
                {
                    _dept_addr1 = value;
                    _dept_addr1 = _dept_addr1.ToUpper();
                    RaisePropertyChanged("dept_addr1");
                }
            }
        }

        private string _dept_addr2;
        public string dept_addr2
        {
            get
            {
                return _dept_addr2;
            }
            set
            {
                if (_dept_addr2 != value)
                {
                    _dept_addr2 = value;
                    _dept_addr2 = _dept_addr2.ToUpper();
                    RaisePropertyChanged("dept_addr2");
                }
            }
        }

        private string _dept_addr3;
        public string dept_addr3
        {
            get
            {
                return _dept_addr3;
            }
            set
            {
                if (_dept_addr3 != value)
                {
                    _dept_addr3 = value;
                    _dept_addr3 = _dept_addr3.ToUpper();
                    RaisePropertyChanged("dept_addr3");
                }
            }
        }

        private string _dept_chairman;
        public string dept_chairman
        {
            get
            {
                return _dept_chairman;
            }
            set
            {
                if (_dept_chairman != value)
                {
                    _dept_chairman = value;
                    _dept_chairman = _dept_chairman.ToUpper();
                    RaisePropertyChanged("dept_chairman");
                }
            }
        }

        private string _dept_co_ordinator;
        public string dept_co_ordinator
        {
            get
            {
                return _dept_co_ordinator;
            }
            set
            {
                if (_dept_co_ordinator != value)
                {
                    _dept_co_ordinator = value;
                    _dept_co_ordinator = _dept_co_ordinator.ToUpper();
                    RaisePropertyChanged("dept_co_ordinator");
                }
            }
        }

        private int _dept_company;
        public int dept_company
        {
            get
            {
                return _dept_company;
            }
            set
            {
                if (_dept_company != value)
                {
                    _dept_company = value;
                    RaisePropertyChanged("dept_company");
                }
            }
        }

        private string _dept_name;
        public string dept_name
        {
            get
            {
                return _dept_name;
            }
            set
            {
                if (_dept_name != value)
                {
                    _dept_name = value;
                    _dept_name = _dept_name.ToUpper();
                    RaisePropertyChanged("dept_name");
                }
            }
        }

        private int _dept_nbr_docs;
        public int dept_nbr_docs
        {
            get
            {
                return _dept_nbr_docs;
            }
            set
            {
                if (_dept_nbr_docs != value)
                {
                    _dept_nbr_docs = value;
                    RaisePropertyChanged("dept_nbr_docs");
                }
            }
        }

        private string _entry_type;
        public string entry_type
        {
            get
            {
                return _entry_type;
            }
            set
            {
                if (_entry_type != value)
                {
                    _entry_type = value;
                    _entry_type = _entry_type.ToUpper();
                    RaisePropertyChanged("entry_type");
                }
            }
        }

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

        private string _status_file;
        public string status_file
        {
            get
            {
                return _status_file;
            }
            set
            {
                if (_status_file != value)
                {
                    _status_file = value;
                    _status_file = _status_file.ToUpper();
                    RaisePropertyChanged("status_file");
                }
            }
        }

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

        private int _sys_hrs;
        public int sys_hrs
        {
            get
            {
                return _sys_hrs;
            }
            set
            {
                if (_sys_hrs != value)
                {
                    _sys_hrs = value;
                    RaisePropertyChanged("sys_hrs");
                }
            }
        }

        private int _sys_min;
        public int sys_min
        {
            get
            {
                return _sys_min;
            }
            set
            {
                if (_sys_min != value)
                {
                    _sys_min = value;
                    RaisePropertyChanged("sys_min");
                }
            }
        }

        private string _ws_dept_nbr;
        public string ws_dept_nbr
        {
            get
            {
                return _ws_dept_nbr;
            }
            set
            {
                if (_ws_dept_nbr != value)
                {
                    _ws_dept_nbr = value;
                    _ws_dept_nbr = _ws_dept_nbr.ToUpper();
                    RaisePropertyChanged("ws_dept_nbr");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string eof_dept_mstr = "N";
        //private string status_file;
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_company_mstr = "0";
        //private string confirm_space = space;

        //private string ws_dept_nbr_grp;
        private string ws_dept_nbr_1;
        private string ws_dept_nbr_2;
        //private string entry_type;
        private string add_code = "A";
        private string change_code = "C";
        private string delete_code = "D";
        private string inquire_code = "I";
        private string read_flag;
        private string on_file = "Y";
        private string not_on_file = "N";
        private string flag_status;
        private string ok = "Y";
        private string not_ok = "N";
        //private string acc_mod_rej;
        private string accept_screen = "Y";
        private string modify_screen = "M";
        private string reject_screen = "N";

        private string counters_grp;
        //private int ctr_dept_mstr_reads;
        //private int ctr_dept_mstr_writes;
        //private int ctr_dept_mstr_adds;
        //private int ctr_dept_mstr_changes;
        //private int ctr_dept_mstr_deletes;
        //private int ctr_company_mstr_reads;

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "invalid reply";
         private string filler = "DEPT ALREADY EXISTS";
         private string filler = "DEPT NBR NOT ON DEPT MASTER";
         private string filler = "DEPT NUMBER MUST BE NUMERIC";
         private string filler = "INVALID WRITE TO DEPT MASTER";
         private string filler = "INVALID RE-WRITE TO DEPT MASTER";
         private string filler = "INVALID DELETE ON DEPT MASTER";
         private string filler = "COMPANY  NOT ON COMPANY MASTER"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply",
                                         "DEPT ALREADY EXISTS",
                                         "DEPT NBR NOT ON DEPT MASTER",
                                         "DEPT NUMBER MUST BE NUMERIC",
                                         "INVALID WRITE TO DEPT MASTER",
                                         "INVALID RE-WRITE TO DEPT MASTER",
                                         "INVALID DELETE ON DEPT MASTER",
                                         "COMPANY  NOT ON COMPANY MASTER" };
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
        private string filler;

        private string sys_date_y2kfixed_grp;
        private string sys_date_blank;
        private string sys_date_right;
        private string sys_date_temp;

        private string run_date_grp;
        private int run_yy;
        // private string filler = "/";
        private int run_mm;
        //private string filler = "/";
        private int run_dd;

        private string sys_time_grp;
        //private int sys_hrs;
        //private int sys_min;
        private int sys_sec;
        private int sys_hdr;

        private string run_time_grp;
        private int run_hrs;
        // private string filler = ":";
        private int run_min;
        // private string filler = ":";
        private int run_sec;

        private int dept_nbr;

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 1,Data1 = "M070",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 11,Data1 = "DEPARTMENT MASTER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "entry_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option-sel"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 31,Data1 = "(ADD/CHANGE/DELETE/INQUIRY) DEPT NBR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_dept_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "03",Col = 1,Data1 = "NAME:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "05",Col = 1,Data1 = "ADDRESS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "09",Col = 1,Data1 = "CHAIRMAN:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "11",Col = 1,Data1 = "CO-ORDINATOR:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "13",Col = 1,Data1 = "NBR OF DOCTORS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-lit.",Line = "15",Col = 1,Data1 = "COMPANY: ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "03",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "dept_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "05",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "dept_addr1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-addr1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "06",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "dept_addr2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-addr2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "07",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(30)",MaxLength = 30,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "dept_addr3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-addr3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "09",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "dept_chairman",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-chairman"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "11",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "dept_co_ordinator",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dept-co-ordinator"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "13",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "dept_nbr_docs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nbr-of-doctors"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "15",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "dept_company",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-company"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-dept-var.",Line = "15",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(40)",MaxLength = 40,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "company_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-company-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "23",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(55)",MaxLength = 55,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "22",Col = 50,Data1 = "ACCEPT(Y/N/M) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "22",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-verify-add-change-acc-mod-rej"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-inquire.",Line = "22",Col = 50,Data1 = "CONTINUE(Y/N) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-inquire.",Line = "22",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-inquire-acc-mod-rej"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-delete.",Line = "22",Col = 50,Data1 = "DELETE(Y/N) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-delete.",Line = "22",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-delete-acc-mod-rej"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-delete.",Line = "22",Col = 63,Data1 = "  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 20,Data1 = "NUMBER OF DEPT-MSTR READS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_dept_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 20,Data1 = "NUMBER OF DEPT-MSTR WRITES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_dept_mstr_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 20,Data1 = "NUMBER OF DEPTS ADDED  :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_dept_mstr_adds",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "                CHANGED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_dept_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "                DELETED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_dept_mstr_deletes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 20,Data1 = "NUMBER OF COMPANY-MSTR READS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "13",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_company_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 20,Data1 = "PROGRAM M070 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 52,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-22.",Line = "22",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_dept_mstr_file_section()
        {

            //     use after standard error procedure on dept-mstr.;
        }

        private async Task err_dept_mstr()
        {

            status_file = status_cobol_dept_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING DEPT MASTER".;
            //     stop run.;
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task initialize_objects()
        {
            objDept_mstr_rec = null;
            objDept_mstr_rec = new F070_DEPT_MSTR();

            Dept_mstr_rec_Collection = null;
            Dept_mstr_rec_Collection = new ObservableCollection<F070_DEPT_MSTR>();

            objCompany_mstr_rec = null;
            objCompany_mstr_rec = new F123_COMPANY_MSTR();

            Company_mstr_rec_Collection = null;
            Company_mstr_rec_Collection = new ObservableCollection<F123_COMPANY_MSTR>();
        }

        public async Task mainline()
        {

            await initialize_objects();

            //     perform aa0-initialization		thru aa0-99-exit.;
            await aa0_initialization();
            await aa0_99_exit();

            //     perform ab0-processing		thru ab0-99-exit;
            // 		until entry-type = "*".;
            do
            {
                _ab0_processing:
               string retval =   await ab0_processing();
                if (retval.Equals("ab0-95-next-dept"))
                {
                    goto _ab0_95_next_dept;
                }
                else if (retval.Equals("ab0-30-disp-verif"))
                {
                    goto _ab0_30_disp_verif;
                }
                retval = await ab0_10_inquire();
                if (retval.Equals("ab0-90-clear-screen") )
                {
                    goto _ab0_90_clear_screen;
                }
                else if (retval.Equals("ab0-99-exit"))
                {
                    goto _ab0_99_exit;
                }
                retval =  await ab0_20_delete();
                if (retval.Equals("ab0-80-update-rec"))
                {
                    goto _ab0_80_update_rec;
                }
                else if (retval.Equals("ab0-90-clear-screen"))
                {
                    goto _ab0_90_clear_screen;
                }
                _ab0_30_disp_verif:
                await ab0_30_disp_verif();
                retval =  await ab0_40_y_n_m();
                if (retval.Equals("ab0-processing") )
                {
                    goto _ab0_processing;
                }
                else if (retval.Equals("ab0-90-clear-screen"))
                {
                    goto _ab0_90_clear_screen;
                }
                _ab0_80_update_rec:
                await ab0_80_update_rec();
                _ab0_90_clear_screen:
                await ab0_90_clear_screen();
                _ab0_95_next_dept:
                await ab0_95_next_dept();
                _ab0_99_exit:
                await ab0_99_exit();

            } while (!entry_type.Equals("*"));

            //     perform az0-end-of-job		thru az0-99-exit.;
            await az0_end_of_job();
            await az0_99_exit();

            //     stop run.;
        }

        private async Task aa0_initialization()
        {

            //     accept sys-date			from date.;
            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            sys_date_grp = Sysdate();
            sys_date_long_child = sys_date_grp.Substring(0, 4) + sys_date_grp.Substring(4, 2) + sys_date_grp.Substring(6, 2);
            sys_date_long = sys_date_grp.Substring(0, 4) + "/" + sys_date_grp.Substring(4, 2) + "/" + sys_date_grp.Substring(6, 2);
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = Util.NumInt(sys_date_grp.Substring(0, 4));
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(sys_date_grp.Substring(0, 1));
            sys_y2 = Util.NumInt(sys_date_grp.Substring(1, 1));
            sys_y3 = Util.NumInt(sys_date_grp.Substring(2, 1));
            sys_y4 = Util.NumInt(sys_date_grp.Substring(3, 1));
            sys_mm = Util.NumInt(sys_date_grp.Substring(4, 2));
            sys_dd = Util.NumInt(sys_date_grp.Substring(6, 2));

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
            //     accept sys-time			from time.;
            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open i-o	dept-mstr.;
            //     open input company-mstr.;
            ws_dept_nbr = "";
            //     display scr-titles.;
            Display("scr-titles.");

            //     display scr-dept-lit.;
            Display("scr-dept-lit.");

            ws_dept_nbr_1 = "*";
            // objDept_mstr_rec.dept_mstr_rec = "";
            //     perform xd0-acpt-type-dept-read-dept thru xd0-99-exit.;            
            string retval =  await xd0_acpt_type_dept_read_dept();
            if (retval.Equals("xd0-99-exit"))
            {
                goto _xd0_99_exit;
            }
            await xd0_10_acpt_dept();
            _xd0_99_exit:
            await xd0_99_exit();
        }

        private async Task aa0_99_exit()
        {

            //     exit.;
        }

        private async Task az0_end_of_job()
        {

            //     display blank-screen.;
            Display("blank-screen.");
            //     display scr-closing-screen.;
            Display("scr-closing-screen.");
            //     display confirm.;
            //     close dept-mstr.;
            //     call program "menu".;
            //     stop run.;
            if (ExitCobol != null)
            {
                ExitCobol();
            }
        }

        private async Task az0_99_exit()
        {

            //     exit.;
        }

        private async Task<string>  ab0_processing()
        {

            // if add-code then            
            if (entry_type.Equals(add_code)) {
                // 	  if ok then;            
                if (flag_status.Equals(ok)) {
                           err_ind = 2;
                    // 	     perform za0-common-error		thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	     go to ab0-95-next-dept;
                    return "ab0-95-next-dept";
                }
                else {
                    // 	     perform ba0-add-change		thru ba0-99-exit;
                    await ba0_add_change();
                    await ba0_99_exit();
                    // 	     go to ab0-30-disp-verif;                
                    return "ab0-30-disp-verif";
                }
            }
            // else if change-code then          
            else if (entry_type.Equals(change_code)) {
                // 	    if not-ok then   
                if (flag_status.Equals(not_ok))
                {
                             err_ind = 3;
                    // 		   perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 		   go to ab0-95-next-dept;
                    return "ab0-95-next-dept";
                }
                else
                {
                    // 		   perform ba0-add-change		thru ba0-99-exit;
                     await ba0_add_change();
                     await ba0_99_exit();
                    // 		   go to ab0-30-disp-verif;
                    return "ab0-30-disp-verif";
                }
            }
            // else if not-ok then            
            else if (flag_status.Equals(not_ok)) {
                      err_ind = 3;
                // 		perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 		go to ab0-95-next-dept;
                return "ab0-95-next-dept";
            }            
            else {
                //      next sentence.;
            }
            return string.Empty;
        }

        private async Task<string> ab0_10_inquire()
        {

            //  if   inquire-code then
            if (entry_type.Equals(inquire_code)) {
                         acc_mod_rej = "Y";
                Display("blank-line-22.");
                // 	     display scr-inquire;
                Display("scr-inquire.");
                // 	     accept  scr-inquire;
                await Prompt("acc_mod_rej", "scr-inquire.", "scr-inquire-acc-mod-rej");
                // 	     if   accept-screen or reject-screen then      
                if (acc_mod_rej.Equals(accept_screen) || acc_mod_rej.Equals(reject_screen)) {
                    // 	         if accept-screen then            
                    if (acc_mod_rej.Equals(accept_screen)) {
                        // 		        go to ab0-90-clear-screen;
                        return "ab0-90-clear-screen";
                    }
                    else {
                                      entry_type = "*";
                        // 		        go to ab0-99-exit;
                        return "ab0-99-exit";
                    }
                }
                else {
                               err_ind = 1;
                    // 	         perform za0-common-error		thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	        go to ab0-10-inquire;
                    await ab0_10_inquire();
                }
            }
            else {
                //    	next sentence.;
            }
            return string.Empty;
        }

        private async Task<string> ab0_20_delete()
        {

            acc_mod_rej = "Y";
            Display("blank-line-22.");
            //     display scr-delete.;
            Display("scr-delete.");
            //     accept  scr-delete.;
            await Prompt("acc_mod_rej", "scr-delete.", "scr-delete-acc-mod-rej");


            //  if accept-screen or reject-screen then     
            if (acc_mod_rej.Equals(accept_screen) || acc_mod_rej.Equals(reject_screen)) {
                // 	    if accept-screen then            
                if (acc_mod_rej.Equals(accept_screen)) {
                    // 	        go to ab0-80-update-rec;
                    return "ab0-80-update-rec";
                }
                else {
                    // 	        go to ab0-90-clear-screen;
                    return "ab0-90-clear-screen";
                }
            }
            else {
                      err_ind = 1;
                // 	    perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to ab0-20-delete.;
                await ab0_20_delete();
            }
            return string.Empty;
        }

        private async Task ab0_30_disp_verif()
        {

            acc_mod_rej = "Y";
            Display("blank-line-22.");
            //     display scr-verify-add-change.;
            Display("scr-verify-add-change.");
        }

        private async Task<string> ab0_40_y_n_m()
        {
            Display("blank-line-22.");
            //     accept scr-verify-add-change.;
            Display("scr-verify-add-change.");
            await Prompt("acc_mod_rej", "scr-verify-add-change.", "scr-verify-add-change-acc-mod-rej");

            // if accept-screen then;        
            if (acc_mod_rej.Equals(accept_screen)) {
                // 	  next sentence;
            }
            // else if modify-screen then            
            else if (acc_mod_rej.Equals(modify_screen) ) {
                // 	    go to ab0-processing;
                return "ab0-processing";
            }
            // else if reject-screen then            
            else if (acc_mod_rej.Equals(reject_screen)) {
                // 		go to ab0-90-clear-screen;
                return "ab0-90-clear-screen";
            }
            else {
                err_ind = 1;
                // 		perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 		go to ab0-40-y-n-m.;
                await ab0_40_y_n_m();
            }
            return string.Empty;
        }

        private async Task ab0_80_update_rec()
        {

            // if add-code then          
            if (entry_type.Equals(add_code)) {
                // 	  perform ia0-write-new-rec		thru ia0-99-exit;            
                await ia0_write_new_rec();
                await ia0_99_exit();
            }
            // else if change-code then            
            else if (entry_type.Equals(change_code)) {
                // 	    perform ka0-re-write-rec		thru ka0-99-exit;            
                await ka0_re_write_rec();
                await ka0_99_exit();
            }
            // else if delete-code then            
            else if (entry_type.Equals(delete_code)) {
                // 		perform ma0-delete-rec		thru ma0-99-exit;
                await ma0_delete_rec();
                await ma0_99_exit();
            }
            else {
                // 		next sentence.;
            }
        }

        private async Task ab0_90_clear_screen()
        {

            ws_dept_nbr = "";                        
            await initialize_dept_mstr_rec_variable();
            
            //     display scr-dept-nbr.;
            Display("scr-titles.", "scr-dept-nbr");
            //     display scr-dept-var.;
            Display("scr-dept-var.");            
            //     display scr-company.;
            Display("scr-company.");
            //     display scr-company-name.;
            Display("scr-company-name.");
        }

        private async Task ab0_95_next_dept()
        {
            //     perform xd0-acpt-type-dept-read-dept	thru xd0-99-exit.;
            _xd0_acpt_type_dept_read_dept:
            string retval =  await xd0_acpt_type_dept_read_dept();
            if (retval.Equals("xd0-99-exit"))
            {
                goto _xd0_99_exit;
            }
            retval = await xd0_10_acpt_dept();
            if (retval.Equals("xd0-acpt-type-dept-read-dept"))
            {
                goto _xd0_acpt_type_dept_read_dept;
            }
            _xd0_99_exit:
            await xd0_99_exit();
        }

        private async Task ab0_99_exit()
        {
            //     exit.;
        }

        private async Task ba0_add_change()
        {
            Display("scr-dept-var.");
            //     perform xf0-acpt-name			thru xf0-99-exit.;
            await xf0_acpt_name();
            await xf0_99_exit();
            //     perform xh0-acpt-addr			thru xh0-99-exit.;
            await xh0_acpt_addr();
            await xh0_99_exit();
            //     perform xj0-acpt-chairman			thru xj0-99-exit.;
            await xj0_acpt_chairman();
            await xj0_99_exit();
            //     perform xl0-acpt-co-ordinator		thru xl0-99-exit.;
            await xl0_acpt_co_ordinator();
            await xl0_99_exit();
            //     perform xn0-acpt-nbr-of-docs		thru xn0-99-exit.;
            await xn0_acpt_nbr_of_docs();
            await xn0_99_exit();
            //     perform xp0-acpt-company     		thru xp0-99-exit.;
            await xp0_acpt_company();
            await xp0_99_exit();
        }

        private async Task ba0_99_exit()
        {

            //     exit;
        }

        private async Task<string> ia0_write_new_rec()
        {

            //  write dept-mstr-rec;
            //   	invalid key;
            //      err_ind = 5;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            try {
                await asssign_variable_to_dept_mstr_rec();
                objDept_mstr_rec.RecordState = State.Added;
                objDept_mstr_rec.Submit();
            } catch (Exception e)
            {
                     err_ind = 5;
                //   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();
                return string.Empty;
            }

            //  add 1		to	ctr-dept-mstr-writes;
            // 			    	ctr-dept-mstr-adds.;

            ctr_dept_mstr_writes++;
            ctr_dept_mstr_adds++;

            return string.Empty;
        }

        private async Task ia0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> ka0_re_write_rec()
        {
            //  rewrite dept-mstr-rec;
            //   	invalid key;
            //      err_ind = 6;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            //     add 1				to	ctr-dept-mstr-changes;
            // 						ctr-dept-mstr-writes.;

            try {
                await asssign_variable_to_dept_mstr_rec();
                objDept_mstr_rec.RecordState = State.Modified;
                objDept_mstr_rec.Submit();
            } catch (Exception e)
            {
                err_ind = 6;
                // 	    perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();
                return string.Empty;
            }

            ctr_dept_mstr_changes++;
            ctr_dept_mstr_writes++;

            return string.Empty;
        }

        private async Task ka0_99_exit()
        {
            //     exit.;
        }

        private async Task<string> ma0_delete_rec()
        {

            // delete dept-mstr record;
            //   	invalid key;
            //      err_ind = 7;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;

            //     add 1				to	ctr-dept-mstr-deletes.;

            try
            {
                await asssign_variable_to_dept_mstr_rec();
                objDept_mstr_rec.Delete();               
            }catch (Exception e)
            {
                 err_ind = 7;
                // 	    perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	    go to az0-end-of-job.;
                await az0_end_of_job();                
            }

            return string.Empty;
        }

        private async Task ma0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> xa0_acpt_dept_entered()
        {

            //     accept scr-dept-nbr.;
            await Prompt("ws_dept_nbr", "scr-titles.", "scr-dept-nbr");
            ws_dept_nbr_1 = ws_dept_nbr.PadRight(2).Substring(0, 1);
            ws_dept_nbr_2 = ws_dept_nbr.PadRight(2).Substring(1, 1);

            // if ws-dept-nbr-1 = '*'  then            
            if (ws_dept_nbr_1.Equals("*")) {
                // 	  go to xa0-99-exit.;
                return "xa0-99-exit";
            }

            // if ws-dept-nbr-2 = spaces then            
            if (string.IsNullOrWhiteSpace(ws_dept_nbr_2)) {
                ws_dept_nbr_2 = ws_dept_nbr_1;
                ws_dept_nbr_1 = "0";
                // 	   display scr-dept-nbr.;
                Display("scr-titles.", "scr-dept-nbr");
            }

            // if ws-dept-nbr not numeric then      
            ws_dept_nbr = Util.Str(ws_dept_nbr_1) + Util.Str(ws_dept_nbr_2);
            if (!Util.IsNumeric(ws_dept_nbr)) {
                err_ind = 4;
                // 	   perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to xa0-acpt-dept-entered.;
                await xa0_acpt_dept_entered();
            }

            return string.Empty;
        }

        private async Task xa0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> xc0_read_dept_mstr()
        {

            flag_status = "Y";

            // read dept-mstr;
            // 	invalid key;
            //      flag_status = 'N';
            // 	    go to xc0-99-exit.;

            objDept_mstr_rec = new F070_DEPT_MSTR
            {
                WhereDept_nbr = Util.NumInt(ws_dept_nbr)
            }.Collection().FirstOrDefault();

            if (objDept_mstr_rec == null)
            {
                objDept_mstr_rec = new F070_DEPT_MSTR();
                await initialize_dept_mstr_rec_variable();
                  flag_status = "N";
                // 	    go to xc0-99-exit.;
                return "xc0-99-exit";
            }

            await asssign_dept_mstr_rec_to_variable();

            //     add 1	to ctr-dept-mstr-reads.;
            ctr_dept_mstr_reads++;

            return string.Empty;
        }

        private async Task xc0_99_exit()
        {

            //     exit.;
        }

        private async Task<string>  xd0_acpt_type_dept_read_dept()
        {

            // if ws-dept-nbr-1 = '*' then            
            if (ws_dept_nbr_1.Equals("*")) {
                //   	accept scr-option-sel;
                Display("scr-titles.", "scr-option-sel");
                await Prompt("entry_type");
            }
            else {
                //    	go to xd0-10-acpt-dept.;
                return "xd0-10-acpt-dept";
            }

            // if add-code  or change-code or delete-code or inquire-code or entry-type = '*'  then            
            if (entry_type.Equals(add_code) || entry_type.Equals(change_code) || entry_type.Equals(delete_code) || entry_type.Equals(inquire_code) || entry_type.Equals("*")) {
                // 	  next sentence;
            }
            else {
                  err_ind = 1;
                // 	 perform za0-common-error		thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to xd0-acpt-type-dept-read-dept.;
                await xd0_acpt_type_dept_read_dept();                
            }

            // if entry-type = '*' then;            
            if (entry_type.Equals("*")) {
                // 	  go to xd0-99-exit.;
                return "xd0-99-exit";
            }

            return string.Empty;
        }

        private async Task<string> xd0_10_acpt_dept()
        {

            //     perform xa0-acpt-dept-entered		thru xa0-99-exit.;
            await xa0_acpt_dept_entered();
            await xa0_99_exit();

            // if ws-dept-nbr-1 = '*' then            
            if (Util.Str(ws_dept_nbr_1).Equals("*") ) {
                // 	  go to xd0-acpt-type-dept-read-dept.;                
                return "xd0-acpt-type-dept-read-dept";
            }
            
            //     perform xc0-read-dept-mstr			thru xc0-99-exit.;
            await xc0_read_dept_mstr();
            await xc0_99_exit();

            // if ( delete-code or inquire-code or change-code ) and ok  then            
            if ((entry_type.Equals(delete_code) || entry_type.Equals(inquire_code) || entry_type.Equals(change_code)) && flag_status.Equals(ok)) {
                // 	  display scr-dept-var.;
                Display("scr-dept-var.");
            }

            return string.Empty;
        }

        private async Task xd0_99_exit()
        {

            //     exit.;
        }

        private async Task xf0_acpt_name()
        {

            //     accept scr-dept-name.;
            await Prompt("dept_name", "scr-dept-var.", "scr-dept-name");
        }

        private async Task xf0_99_exit()
        {

            //     exit.;
        }

        private async Task xh0_acpt_addr()
        {

            //     accept scr-dept-addr1.;
            await Prompt("dept_addr1", "scr-dept-var.", "scr-dept-addr1");

            // if dept-addr1 not = spaces  then;            
            if (!string.IsNullOrWhiteSpace(dept_addr1) ) {
                // 	   accept scr-dept-addr2;
                       await Prompt("dept_addr2", "scr-dept-var.", "scr-dept-addr2");
                // 	   if dept-addr2 not = spaces then            
                if (!string.IsNullOrWhiteSpace(dept_addr2)) {
                    // 	      accept scr-dept-addr3;
                    await Prompt("dept_addr3", "scr-dept-var.", "scr-dept-addr3");
                }
                else {                    
                    dept_addr3 = "";
                    // 	       display scr-dept-addr3;
                    Display("scr-dept-var.", "scr-dept-addr3");
                }
            }
            else {                
                dept_addr2 = "";
                dept_addr3 = "";
                // 	  display scr-dept-addr2;
                Display("scr-dept-var.", "scr-dept-addr2");
                // 	  display scr-dept-addr3.;
                Display("scr-dept-var.", "scr-dept-addr3");
            }
        }

        private async Task xh0_99_exit()
        {

            //     exit.;
        }

        private async Task xj0_acpt_chairman()
        {

            //     accept scr-dept-chairman.;
            await Prompt("dept_chairman", "scr-dept-var.", "scr-dept-chairman");
        }

        private async Task xj0_99_exit()
        {

            //     exit.;
        }

        private async Task xl0_acpt_co_ordinator()
        {

            //     accept scr-dept-co-ordinator.;
            await Prompt("dept_co_ordinator", "scr-dept-var.", "scr-dept-co-ordinator");
        }

        private async Task xl0_99_exit()
        {

            //     exit.;
        }

        private async Task xn0_acpt_nbr_of_docs()
        {

            //     accept scr-nbr-of-doctors.;
            await Prompt("dept_nbr_docs", "scr-dept-var.", "scr-nbr-of-doctors");
        }

        private async Task xn0_99_exit()
        {

            //     exit.;
        }

        private async Task xp0_acpt_company()
        {

            //     accept scr-company.;
            await Prompt("dept_company", "scr-dept-var.", "scr-company");
            
            //     perform ya0-read-company-mstr		thru ya0-99-exit.;
            await ya0_read_company_mstr();
            await ya0_99_exit();

            // if not-ok then
            if (flag_status.Equals(not_ok) ) {
                //      go to xp0-acpt-company.;
                await xp0_acpt_company();
            }

            // if (add-code or inquire-code or change-code ) and ok then            
            if ((entry_type.Equals(add_code) || entry_type.Equals(inquire_code) || entry_type.Equals(change_code)) && flag_status.Equals(ok) ) {
                // 	   display scr-company-name.;
                Display("scr-dept-var.", "scr-company-name");
            }
        }

        private async Task xp0_99_exit()
        {

            //     exit.;
        }

        private async Task ya0_read_company_mstr()
        {

            flag_status = "Y";

            //  read company-mstr;
            //  	invalid key;
            //        flag_status = "N";
            //        err_ind = 8;
            // 	      perform za0-common-error		thru za0-99-exit;
            // 	      go to ya0-99-exit.;

            objCompany_mstr_rec = new F123_COMPANY_MSTR
            {
                WhereCompany_nbr = dept_company
            }.Collection().FirstOrDefault();

            if (objCompany_mstr_rec == null)
            {
                objCompany_mstr_rec = new F123_COMPANY_MSTR();
            }

            company_name = Util.Str(objCompany_mstr_rec.COMPANY_NAME);

            //     add 1					to ctr-company-mstr-reads.;
            ctr_company_mstr_reads++;
        }

        private async Task ya0_99_exit()
        {

            //     exit.;
        }

        private async Task za0_common_error()
        {

            err_msg_comment = " ERROR -  " +  err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
            Display("err-msg-line");
            await Prompt("err_msg_comment");

            //     display blank-line-24.;
            Display("blank-line-24.");
        }

        private async Task za0_99_exit()
        {

            //     exit.;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate()
        {

            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            //     add 20000000                        to sys-date-numeric.;
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {

            //     exit.;
        }

        private async Task initialize_dept_mstr_rec_variable()
        {
            dept_nbr = 0;
            dept_name = string.Empty;
            dept_addr1 = string.Empty;
            dept_addr2 = string.Empty;
            dept_addr3 = string.Empty;
            dept_chairman = string.Empty;
            dept_co_ordinator = string.Empty;
            dept_nbr_docs = 0;
            dept_company = 0;
            company_name = string.Empty;
        }

        private async Task asssign_dept_mstr_rec_to_variable()
        {
            dept_nbr = Util.NumInt(objDept_mstr_rec.DEPT_NBR);
            dept_name = Util.Str(objDept_mstr_rec.DEPT_NAME);
            dept_addr1 = Util.Str(objDept_mstr_rec.DEPT_ADDR1);
            dept_addr2 = Util.Str(objDept_mstr_rec.DEPT_ADDR2);
            dept_addr3 = Util.Str(objDept_mstr_rec.DEPT_ADDR3);
            dept_chairman = Util.Str(objDept_mstr_rec.DEPT_CHAIRMAN);
            dept_co_ordinator = Util.Str(objDept_mstr_rec.DEPT_CO_ORDINATOR);
            dept_nbr_docs = Util.NumInt(objDept_mstr_rec.DEPT_NBR_DOCS);
            dept_company = Util.NumInt(objDept_mstr_rec.DEPT_COMPANY);
        }

        private async Task asssign_variable_to_dept_mstr_rec()
        {
            objDept_mstr_rec.DEPT_NBR = Util.NumInt(ws_dept_nbr);
            objDept_mstr_rec.DEPT_NAME = Util.Str(dept_name);
            objDept_mstr_rec.DEPT_ADDR1 = Util.Str(dept_addr1);
            objDept_mstr_rec.DEPT_ADDR2 = Util.Str(dept_addr2);
            objDept_mstr_rec.DEPT_ADDR3 = Util.Str(dept_addr3);
            objDept_mstr_rec.DEPT_CHAIRMAN = Util.Str(dept_chairman);
            objDept_mstr_rec.DEPT_CO_ORDINATOR = Util.Str(dept_co_ordinator);
            objDept_mstr_rec.DEPT_NBR_DOCS = Util.NumInt(dept_nbr_docs);
            objDept_mstr_rec.DEPT_COMPANY = Util.NumInt(dept_company);
        }

        public void destroy_objects()
        {
            objDept_mstr_rec = null;
            Dept_mstr_rec_Collection = null;

            objCompany_mstr_rec = null;
            Company_mstr_rec_Collection = null;
        }

        #endregion
    }
}

