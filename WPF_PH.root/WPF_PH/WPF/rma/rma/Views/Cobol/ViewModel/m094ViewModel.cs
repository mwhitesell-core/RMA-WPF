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
    public delegate void M094ExitCobolScreen();

    public class M094ViewModel : CommonFunctionScr
    {
        public event M094ExitCobolScreen ExitCobol;

        public M094ViewModel()
        {

        }

        #region FD Section

        private F094_MSG_MSTR objMsg_mstr_rec = null;
        private F094_SUB_MSTR objMsg_sub_mstr_rec = null;
        private ObservableCollection<F094_MSG_MSTR> Msg_mstr_rec_Collection;
        private ObservableCollection<F094_SUB_MSTR> Msg_sub_mstr_rec_Collection;

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

        private int _ctr_msg_mstr_adds;
        public int ctr_msg_mstr_adds
        {
            get
            {
                return _ctr_msg_mstr_adds;
            }
            set
            {
                if (_ctr_msg_mstr_adds != value)
                {
                    _ctr_msg_mstr_adds = value;
                    RaisePropertyChanged("ctr_msg_mstr_adds");
                }
            }
        }

        private int _ctr_msg_mstr_changes;
        public int ctr_msg_mstr_changes
        {
            get
            {
                return _ctr_msg_mstr_changes;
            }
            set
            {
                if (_ctr_msg_mstr_changes != value)
                {
                    _ctr_msg_mstr_changes = value;
                    RaisePropertyChanged("ctr_msg_mstr_changes");
                }
            }
        }

        private int _ctr_msg_mstr_deletes;
        public int ctr_msg_mstr_deletes
        {
            get
            {
                return _ctr_msg_mstr_deletes;
            }
            set
            {
                if (_ctr_msg_mstr_deletes != value)
                {
                    _ctr_msg_mstr_deletes = value;
                    RaisePropertyChanged("ctr_msg_mstr_deletes");
                }
            }
        }

        private int _ctr_msg_mstr_reads;
        public int ctr_msg_mstr_reads
        {
            get
            {
                return _ctr_msg_mstr_reads;
            }
            set
            {
                if (_ctr_msg_mstr_reads != value)
                {
                    _ctr_msg_mstr_reads = value;
                    RaisePropertyChanged("ctr_msg_mstr_reads");
                }
            }
        }

        private int _ctr_msg_mstr_writes;
        public int ctr_msg_mstr_writes
        {
            get
            {
                return _ctr_msg_mstr_writes;
            }
            set
            {
                if (_ctr_msg_mstr_writes != value)
                {
                    _ctr_msg_mstr_writes = value;
                    RaisePropertyChanged("ctr_msg_mstr_writes");
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

        private string _err_rtn;
        public string err_rtn
        {
            get
            {
                return _err_rtn;
            }
            set
            {
                if (_err_rtn != value)
                {
                    _err_rtn = value;
                    _err_rtn = _err_rtn.ToUpper();
                    RaisePropertyChanged("err_rtn");
                }
            }
        }

        private string _msg_dtl1;
        public string msg_dtl1
        {
            get
            {
                return _msg_dtl1;
            }
            set
            {
                if (_msg_dtl1 != value)
                {
                    _msg_dtl1 = value;
                    _msg_dtl1 = _msg_dtl1;
                    RaisePropertyChanged("msg_dtl1");
                }
            }
        }

        private string _msg_dtl1_2;
        public string msg_dtl1_2
        {
            get
            {
                return _msg_dtl1_2;
            }
            set
            {
                if (_msg_dtl1_2 != value)
                {
                    _msg_dtl1_2 = value;
                    _msg_dtl1_2 = _msg_dtl1_2;
                    RaisePropertyChanged("msg_dtl1_2");
                }
            }
        }

        private string _msg_dtl1_3;
        public string msg_dtl1_3
        {
            get
            {
                return _msg_dtl1_3;
            }
            set
            {
                if (_msg_dtl1_3 != value)
                {
                    _msg_dtl1_3 = value;
                    _msg_dtl1_3 = _msg_dtl1_3;
                    RaisePropertyChanged("msg_dtl1_3");
                }
            }
        }

        private string _msg_dtl1_4;
        public string msg_dtl1_4
        {
            get
            {
                return _msg_dtl1_4;
            }
            set
            {
                if (_msg_dtl1_4 != value)
                {
                    _msg_dtl1_4 = value;
                    _msg_dtl1_4 = _msg_dtl1_4;
                    RaisePropertyChanged("msg_dtl1_4");
                }
            }
        }

        private string _msg_dtl2;
        public string msg_dtl2
        {
            get
            {
                return _msg_dtl2;
            }
            set
            {
                if (_msg_dtl2 != value)
                {
                    _msg_dtl2 = value;
                    _msg_dtl2 = _msg_dtl2;
                    RaisePropertyChanged("msg_dtl2");
                }
            }
        }

        private string _msg_dtl2_2;
        public string msg_dtl2_2
        {
            get
            {
                return _msg_dtl2_2;
            }
            set
            {
                if (_msg_dtl2_2 != value)
                {
                    _msg_dtl2_2 = value;
                    _msg_dtl2_2 = _msg_dtl2_2;
                    RaisePropertyChanged("msg_dtl2_2");
                }
            }
        }

        private string _msg_dtl2_3;
        public string msg_dtl2_3
        {
            get
            {
                return _msg_dtl2_3;
            }
            set
            {
                if (_msg_dtl2_3 != value)
                {
                    _msg_dtl2_3 = value;
                    _msg_dtl2_3 = _msg_dtl2_3;
                    RaisePropertyChanged("msg_dtl2_3");
                }
            }
        }

        private string _msg_dtl2_4;
        public string msg_dtl2_4
        {
            get
            {
                return _msg_dtl2_4;
            }
            set
            {
                if (_msg_dtl2_4 != value)
                {
                    _msg_dtl2_4 = value;
                    _msg_dtl2_4 = _msg_dtl2_4;
                    RaisePropertyChanged("msg_dtl2_4");
                }
            }
        }

        private string _msg_dtl3;
        public string msg_dtl3
        {
            get
            {
                return _msg_dtl3;
            }
            set
            {
                if (_msg_dtl3 != value)
                {
                    _msg_dtl3 = value;
                    _msg_dtl3 = _msg_dtl3;
                    RaisePropertyChanged("msg_dtl3");
                }
            }
        }

        private string _msg_dtl3_2;
        public string msg_dtl3_2
        {
            get
            {
                return _msg_dtl3_2;
            }
            set
            {
                if (_msg_dtl3_2 != value)
                {
                    _msg_dtl3_2 = value;
                    _msg_dtl3_2 = _msg_dtl3_2;
                    RaisePropertyChanged("msg_dtl3_2");
                }
            }
        }

        private string _msg_dtl3_3;
        public string msg_dtl3_3
        {
            get
            {
                return _msg_dtl3_3;
            }
            set
            {
                if (_msg_dtl3_3 != value)
                {
                    _msg_dtl3_3 = value;
                    _msg_dtl3_3 = _msg_dtl3_3;
                    RaisePropertyChanged("msg_dtl3_3");
                }
            }
        }

        private string _msg_dtl3_4;
        public string msg_dtl3_4
        {
            get
            {
                return _msg_dtl3_4;
            }
            set
            {
                if (_msg_dtl3_4 != value)
                {
                    _msg_dtl3_4 = value;
                    _msg_dtl3_4 = _msg_dtl3_4;
                    RaisePropertyChanged("msg_dtl3_4");
                }
            }
        }

        private string _msg_dtl4;
        public string msg_dtl4
        {
            get
            {
                return _msg_dtl4;
            }
            set
            {
                if (_msg_dtl4 != value)
                {
                    _msg_dtl4 = value;
                    _msg_dtl4 = _msg_dtl4;
                    RaisePropertyChanged("msg_dtl4");
                }
            }
        }

        private string _msg_dtl4_2;
        public string msg_dtl4_2
        {
            get
            {
                return _msg_dtl4_2;
            }
            set
            {
                if (_msg_dtl4_2 != value)
                {
                    _msg_dtl4_2 = value;
                    _msg_dtl4_2 = _msg_dtl4_2;
                    RaisePropertyChanged("msg_dtl4_2");
                }
            }
        }

        private string _msg_dtl4_3;
        public string msg_dtl4_3
        {
            get
            {
                return _msg_dtl4_3;
            }
            set
            {
                if (_msg_dtl4_3 != value)
                {
                    _msg_dtl4_3 = value;
                    _msg_dtl4_3 = _msg_dtl4_3;
                    RaisePropertyChanged("msg_dtl4_3");
                }
            }
        }

        private string _msg_dtl4_4;
        public string msg_dtl4_4
        {
            get
            {
                return _msg_dtl4_4;
            }
            set
            {
                if (_msg_dtl4_4 != value)
                {
                    _msg_dtl4_4 = value;
                    _msg_dtl4_4 = _msg_dtl4_4;
                    RaisePropertyChanged("msg_dtl4_4");
                }
            }
        }

        private string _msg_reprint_flag;
        public string msg_reprint_flag
        {
            get
            {
                return _msg_reprint_flag;
            }
            set
            {
                if (_msg_reprint_flag != value)
                {
                    _msg_reprint_flag = value;
                    _msg_reprint_flag = _msg_reprint_flag.ToUpper();
                    RaisePropertyChanged("msg_reprint_flag");
                }
            }
        }

        private string _msg_reprint_flag_2;
        public string msg_reprint_flag_2
        {
            get
            {
                return _msg_reprint_flag_2;
            }
            set
            {
                if (_msg_reprint_flag_2 != value)
                {
                    _msg_reprint_flag_2 = value;
                    _msg_reprint_flag_2 = _msg_reprint_flag_2.ToUpper();
                    RaisePropertyChanged("msg_reprint_flag_2");
                }
            }
        }

        private string _msg_reprint_flag_3;
        public string msg_reprint_flag_3
        {
            get
            {
                return _msg_reprint_flag_3;
            }
            set
            {
                if (_msg_reprint_flag_3 != value)
                {
                    _msg_reprint_flag_3 = value;
                    _msg_reprint_flag_3 = _msg_reprint_flag_3.ToUpper();
                    RaisePropertyChanged("msg_reprint_flag_3");
                }
            }
        }

        private string _msg_reprint_flag_4;
        public string msg_reprint_flag_4
        {
            get
            {
                return _msg_reprint_flag_4;
            }
            set
            {
                if (_msg_reprint_flag_4 != value)
                {
                    _msg_reprint_flag_4 = value;
                    _msg_reprint_flag_4 = _msg_reprint_flag_4.ToUpper();
                    RaisePropertyChanged("msg_reprint_flag_4");
                }
            }
        }

        private string _msg_sub_key_23;
        public string msg_sub_key_23
        {
            get
            {
                return _msg_sub_key_23;
            }
            set
            {
                if (_msg_sub_key_23 != value)
                {
                    _msg_sub_key_23 = value;
                    _msg_sub_key_23 = _msg_sub_key_23.ToUpper();
                    RaisePropertyChanged("msg_sub_key_23");
                }
            }
        }

        private string _msg_sub_key_23_2;
        public string msg_sub_key_23_2
        {
            get
            {
                return _msg_sub_key_23_2;
            }
            set
            {
                if (_msg_sub_key_23_2 != value)
                {
                    _msg_sub_key_23_2 = value;
                    _msg_sub_key_23_2 = _msg_sub_key_23_2.ToUpper();
                    RaisePropertyChanged("msg_sub_key_23_2");
                }
            }
        }

        private string _msg_sub_key_23_3;
        public string msg_sub_key_23_3
        {
            get
            {
                return _msg_sub_key_23_3;
            }
            set
            {
                if (_msg_sub_key_23_3 != value)
                {
                    _msg_sub_key_23_3 = value;
                    _msg_sub_key_23_3 = _msg_sub_key_23_3.ToUpper();
                    RaisePropertyChanged("msg_sub_key_23_3");
                }
            }
        }

        private string _msg_sub_key_23_4;
        public string msg_sub_key_23_4
        {
            get
            {
                return _msg_sub_key_23_4;
            }
            set
            {
                if (_msg_sub_key_23_4 != value)
                {
                    _msg_sub_key_23_4 = value;
                    _msg_sub_key_23_4 = _msg_sub_key_23_4.ToUpper();
                    RaisePropertyChanged("msg_sub_key_23_4");
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

        private string _ws_msg_sub_key_23;
        public string ws_msg_sub_key_23
        {
            get
            {
                return _ws_msg_sub_key_23;
            }
            set
            {
                if (_ws_msg_sub_key_23 != value)
                {
                    _ws_msg_sub_key_23 = value;
                    _ws_msg_sub_key_23 = _ws_msg_sub_key_23.ToUpper();
                    RaisePropertyChanged("ws_msg_sub_key_23");
                }
            }
        }

        private int _sys_mm;
        public int sys_mm
        {
            get
            {
                return _sys_mm;
            }
            set
            {
                if (_sys_mm != value)
                {
                    _sys_mm = value;
                    RaisePropertyChanged("sys_mm");
                }
            }
        }

        private int _sys_yy;
        public int sys_yy
        {
            get
            {
                return _sys_yy;
            }
            set
            {
                if (_sys_yy != value)
                {
                    _sys_yy = value;
                    RaisePropertyChanged("sys_yy");
                }
            }
        }

        private int _sys_dd;
        public int sys_dd
        {
            get
            {
                return _sys_dd;
            }
            set
            {
                if (_sys_dd != value)
                {
                    _sys_dd = value;
                    RaisePropertyChanged("sys_dd");
                }
            }
        }



        #endregion

        #region Working Storage Section

        private string flag_eof_msg_sub_mstr;
        private string eof_msg_sub_mstr = "Y";
        private string msg_indexer = "M";

        private int err_ind = 0;

        private string ws_msg_sub_key_grp;
        private string ws_msg_sub_key_1;
        private string add_code = "A";
        private string change_code = "C";
        private string delete_code = "D";
        private string inquire_code = "I";
        private string flag_status;
        private string ok = "Y";
        private string not_ok = "N";
        private string accept_screen = "Y";
        private string modify_screen = "M";
        private string reject_screen = "N";

        private int cur_line;

        private string[] err_msg = {"", "invalid reply",
   	                            "MESSAGE ALREADY EXISTS",
   	                            "MESSAGE NBR NOT ON MESSAGE MASTER",
   	                            "SECOND MESSAGE DETAIL REQUIRED",
   	                            "INVALID WRITE TO MESSAGE MASTER",
   	                            "INVALID RE-WRITE TO MESSAGE MASTER",
   	                            "INVALID DELETE ON MESSAGE MASTER",
   	                            "NUMERIC MESSAGE NUMBER REQUIRED",
   	                            "(Y)ES OR (N)O PRINT INDICATOR REQUIRED",
   	                            "THIRD MESSAGE DETAIL REQUIRED",
   	                            "FIRST MESSAGE DETAIL REQUIRED"};

	    private int sys_y1;
	    private int sys_y2;
	    private int sys_y3;
	    private int sys_y4;
	    private int sys_date_numeric;

	    private string sys_date_left;
	    private string sys_date_blank;
	    private string sys_date_right;

        private int run_yy;
	    private int run_mm;
	    private int run_dd;
	    private int sys_sec;
	    private int run_hrs;
	    private int run_min;
	    private int run_sec;

        private string msg_sub_key_grp;
        private string msg_sub_key_1;
        private string msg_sub_key_12;
        private string msg_sub_key_23_grp;
        private string msg_sub_key_2;
        private string msg_sub_key_3;
        private string msg_auto_logout;
        private string sub_name;
        private string sub_fee_complex;
        private string sub_auto_logout;
        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection ()
	{
		ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
		{
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 1,Data1 = "M094",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 20,Data1 = "Direct Bills - Message Maintenance",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 29,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "entry_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option-sel"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_msg_sub_key_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-id"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 54,Data1 = "Msg Nbr",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-titles-7."},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9999",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "05",Col = 1,Data1 = "REPRINT FLAG:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "07",Col = 1,Data1 = "MESSAGE 1:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "08",Col = 1,Data1 = "MESSAGE 2:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "09",Col = 1,Data1 = "MESSAGE 3:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "10",Col = 1,Data1 = "MESSAGE 4:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "05",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_reprint_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-reprint-flag"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "07",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-dtl1"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "08",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-dtl2"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "09",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-dtl3"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "10",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-dtl4"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "add-mode.",Line = "02",Col = 31,Data1 = "ADD MODE                   ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "change-mode.",Line = "02",Col = 31,Data1 = "CHANGE MODE                ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "delete-mode.",Line = "02",Col = 31,Data1 = "DELETE MODE                ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-mode.",Line = "02",Col = 31,Data1 = "INQUIRE MODE               ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "option-mode.",Line = "02",Col = 31,Data1 = "(ADD/CHANGE/DELETE/INQUIRE)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "option-mode-1."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "option-mode.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "option-mode-2."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-screen.",Line = "04",Col = 3,Data1 = "NBR   REPRINT              MESSAGES",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one.",Line = "5",Col = 3,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one.",Line = "5",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_reprint_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one.",Line = "5",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-two.",Line = "6",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-three.",Line = "7",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-four.",Line = "8",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-2.",Line = "9",Col = 3,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_23_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-2.",Line = "9",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_reprint_flag_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-2.",Line = "9",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-two-2.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl2_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-three-2.",Line = "11",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl3_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-four-2.",Line = "12",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl4_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-3.",Line = "13",Col = 3,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_23_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-3.",Line = "13",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_reprint_flag_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-3.",Line = "13",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl1_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-two-3.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl2_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-three-3.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl3_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-four-3.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl4_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-4.",Line = "17",Col = 3,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_23_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-4.",Line = "17",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_reprint_flag_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-one-4.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl1_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-two-4.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl2_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-three-4.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl3_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "msg-four-4.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(47)",MaxLength = 47,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_dtl4_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end-of-file.",Line = "24",Col = 64,Data1 = "END OF FILE ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "clear-inquire-screen.",Line = "12",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 3,Data1 = " ERROR - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(45)",MaxLength = 45,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_rtn",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "err-rtn."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "24",Col = 62,Data1 = "ACCEPT(Y/N/M) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "24",Col = 77,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "add-acc-mod-rej."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-inquire.",Line = "24",Col = 62,Data1 = "CONTINUE(Y/N) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-inquire.",Line = "24",Col = 77,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "inq-acc-mod-rej."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-delete.",Line = "24",Col = 64,Data1 = "DELETE(Y/N) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-delete.",Line = "24",Col = 77,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "del-acc-mod-rej."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 58,Data1 = "ENTRY IS REJECTED ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 20,Data1 = "NUMBER OF MSG-MSTR READS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 20,Data1 = "NUMBER OF MSG-MSTR WRITES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 20,Data1 = "NUMBER OF MSGS ADDED  :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_adds",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "               CHANGED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "               DELETED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_deletes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 20,Data1 = "PROGRAM M094 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}
        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion

        private async Task initialize_objects()
        {
            objMsg_mstr_rec = new F094_MSG_MSTR();
            //objMsg_sub_mstr_rec = new F094_MSG_SUB_MSTR();
            Msg_mstr_rec_Collection = new ObservableCollection<F094_MSG_MSTR>();
            //Msg_sub_mstr_rec_Collection = new ObservableCollection<F094_MSG_SUB_MSTR>();
        }

        public async Task mainline()
        {
            try
            {
                await initialize_objects();
                await aa0_initialization();

                do
                {
                    await xd0_acpt_type_msg_read_msg();

                    if (!entry_type.Equals("*"))
                    {
                        await ab0_processing();
                    }
                } while (!entry_type.Equals("*"));
            }

            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                }
            }

            finally
            {
                if (entry_type.Equals("*"))
                {
                    if (ExitCobol != null)
                    {
                        ExitCobol();
                    }
                }
            }
        }

        private async Task aa0_initialization()
        {
            sys_date_grp = DateTime.Now.ToString();
            sys_date_long_child = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = DateTime.Now.Year;
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(DateTime.Now.Year.ToString().Substring(0, 1));
            sys_y2 = Util.NumInt(DateTime.Now.Year.ToString().Substring(1, 1));
            sys_y3 = Util.NumInt(DateTime.Now.Year.ToString().Substring(2, 1));
            sys_y4 = Util.NumInt(DateTime.Now.Year.ToString().Substring(3, 1));
            sys_mm = DateTime.Now.Month;
            sys_dd = DateTime.Now.Day;

            await y2k_default_sysdate();

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;

            ws_msg_sub_key_grp = "";
            ws_msg_sub_key_1 = "";
            //ws_msg_sub_key_2 = "";

            ws_msg_sub_key_1 = msg_indexer;
            Display("scr-titles.");
            Display("option-mode.");

            ws_msg_sub_key_23 = "*";

            await Initialize_Msg_Sub_Mstr_Record_ScreenVariables();
        }

        private async Task az0_end_of_job()
        {
            //Display("blank-screen.");
            //Display("scr-closing-screen.");
        }

        private async Task ab0_processing()
        {
            do
            {
                if (acc_mod_rej != "M")
                {
                    msg_sub_key_23 = "";
                    msg_dtl1 = "";
                    msg_dtl2 = "";
                    msg_dtl3 = "";
                    msg_dtl4 = "";
                }

                msg_sub_key_23_2 = "";
                msg_sub_key_23_3 = "";
                msg_sub_key_23_4 = "";
                msg_dtl1_2 = "";
                msg_dtl1_3 = "";
                msg_dtl1_4 = "";
                msg_dtl2_2 = "";
                msg_dtl2_3 = "";
                msg_dtl2_4 = "";
                msg_dtl3_2 = "";
                msg_dtl3_3 = "";
                msg_dtl3_4 = "";
                msg_dtl4_2 = "";
                msg_dtl4_3 = "";
                msg_dtl4_4 = "";

                if (entry_type.Equals(add_code))
                {
                    if (acc_mod_rej != "M")
                    {
                        do
                        {
                            await ab0_95_next_msg();
                        } while (flag_status.Equals(ok));
                    }

                    if (!ws_msg_sub_key_23.Equals("*"))
                    {
                        Display("scr-msg-lit.");
                        await ba0_acpt_reprint();
                        await ba0_acpt_dtl1();
                        await ba0_acpt_dtl2();
                        await ba0_acpt_dtl3();
                        await ba0_acpt_dtl4();
                        await ab0_30_disp_verif();
                        await ab0_40_y_n_m();
                    }
                }
                else if (entry_type.Equals(change_code))
                {
                    do
                    {
                        await ab0_95_next_msg();
                    } while (flag_status.Equals(not_ok));

                    if (!ws_msg_sub_key_23.Equals("*"))
                    {
                        Display("scr-msg-var.");
                        await ba0_acpt_reprint();
                        await ba0_acpt_dtl1();
                        await ba0_acpt_dtl2();
                        await ba0_acpt_dtl3();
                        await ba0_acpt_dtl4();
                        await ab0_30_disp_verif();
                        await ab0_40_y_n_m();
                        Display("scr-msg-var.", false);
                    }
                }
                else if (entry_type.Equals(inquire_code))
                {
                    Display("msg-one.", false);
                    Display("msg-two.", false);
                    Display("msg-three.", false);
                    Display("msg-four.", false);
                    Display("msg-one-2.", false);
                    Display("msg-two-2.", false);
                    Display("msg-three-2.", false);
                    Display("msg-four-2.", false);
                    Display("msg-one-3.", false);
                    Display("msg-two-3.", false);
                    Display("msg-three-3.", false);
                    Display("msg-four-3.", false);
                    Display("msg-one-4.", false);
                    Display("msg-two-4.", false);
                    Display("msg-three-4.", false);
                    Display("msg-four-4.", false);
                    ctr_msg_mstr_reads = 0;

                    do
                    {
                        await ab0_95_next_msg();
                    } while (flag_status.Equals(not_ok));

                    if (!ws_msg_sub_key_23.Equals("*"))
                    {
                        await ab0_10_inquire();
                    }
                }
                else if (entry_type.Equals(delete_code))
                {
                    Display("scr-msg-var.", false);

                    do
                    {
                        await ab0_95_next_msg();
                    } while (flag_status.Equals(not_ok));

                    if (!ws_msg_sub_key_23.Equals("*"))
                    {
                        await ab0_20_delete();
                    }
                }
            } while (ws_msg_sub_key_23 != "*");
        }

        private async Task ab0_10_inquire()
        {
            if (!ws_msg_sub_key_23.Equals("*"))
            {
                acc_mod_rej = "Y";
                flag_eof_msg_sub_mstr = "N";

                Display("option-mode.", "option-mode-1.", false);
                Display("inquire-mode.");
                Display("inquire-screen.");

                do
                {
                    await ca0_display_records();
                } while (!acc_mod_rej.Equals(reject_screen));
            }
        }

        private async Task ab0_20_delete()
        {
            if (!ws_msg_sub_key_23.Equals("*"))
            {
                acc_mod_rej = "Y";

                Display("scr-msg-var.");
                Display("scr-delete.");
                await Prompt("acc_mod_rej", "scr-delete.", "del-acc-mod-rej.");

                Display("blank-line-24.");

                if (acc_mod_rej.Equals(accept_screen) || acc_mod_rej.Equals(reject_screen))
                {
                    if (acc_mod_rej.Equals(accept_screen))
                    {
                        await ab0_80_update_rec();
                    }
                    else
                    {
                        Display("scr-reject-entry.");
                        err_rtn = "";

                        Display("err-msg-line.", "err-rtn.");
                        await Prompt("err_rtn");

                        Display("blank-line-24.");
                        await ab0_90_clear_screen();
                    }
                }
                else
                {
                    err_ind = 1;
                    await za0_common_error();
                    await ab0_20_delete();
                }
            }
        }

        private async Task ab0_30_disp_verif()
        {
            acc_mod_rej = "Y";
            Display("scr-inquire", false);
            Display("scr-delete", false);
            Display("scr-verify-add-change.");
        }

        private async Task ab0_40_y_n_m()
        {
            if (entry_type.Equals(add_code) || entry_type.Equals(change_code) || entry_type.Equals(delete_code))
            {
                Display("scr-verify-add-change.");
                await Prompt("acc_mod_rej");

                Display("blank-line-24.");

                if (acc_mod_rej.Equals(accept_screen))
                {
                    flag_status = "Y";
                    Display("scr-msg-var.", false);
                    await ab0_80_update_rec();
                }
                else if (acc_mod_rej.Equals(modify_screen))
                {
                    await ab0_processing();
                }
                else if (acc_mod_rej.Equals(reject_screen))
                {
                    Display("scr-reject-entry.");
                    err_rtn = "";

                    Display("err-msg-line.", "err-rtn.");
                    await Prompt("err_rtn");

                    Display("blank-line-24.");
                    await ab0_90_clear_screen();
                }
                else
                {
                    err_ind = 1;
                    await za0_common_error();
                    await ab0_30_disp_verif();
                }
            }
        }

        private async Task ab0_80_update_rec()
        {
            if (entry_type.Equals(add_code))
            {
                await ia0_write_new_rec();
            }
            else if (entry_type.Equals(change_code))
            {
                await ka0_re_write_rec();
            }
            else if (entry_type.Equals(delete_code))
            {
                await ma0_delete_rec();
            }
        }

        private async Task ab0_90_clear_screen()
        {
            ws_msg_sub_key_23 = "";
            
            msg_reprint_flag = "";
            msg_auto_logout = "";
            msg_dtl1 = "";
            msg_dtl2 = "";
            msg_dtl3 = "";
            msg_dtl4 = "";

            sub_name = "";
            sub_fee_complex = "";
            sub_auto_logout = "";

            Display("scr-titles.", "scr-msg-id");

            if (!entry_type.Equals(inquire_code) )
            {
                Display("scr-msg-var.");
            }
        }

        private async Task ab0_95_next_msg()
        {
            //await xd0_acpt_type_msg_read_msg();
            await xd0_10_acpt_msg();

            if (ws_msg_sub_key_23.Equals("*"))
            {
                if (entry_type.Equals(add_code))
                {
                    flag_status = "N";
                }
                else
                {
                    Display("inquire-screen.", false);
                    flag_status = "Y";
                }
            }
            else if (!Util.IsNumeric(ws_msg_sub_key_23))
            {
                if (entry_type.Equals(add_code))
                {
                    flag_status = "Y";
                }
                else
                {
                    flag_status = "N";
                }
            }
        }

        private async Task ba0_acpt_reprint()
        {
            Display("scr-msg-var.", "scr-msg-reprint-flag");
            await Prompt("msg_reprint_flag");

            if (Util.Str(msg_reprint_flag).ToUpper() != "Y" && Util.Str(msg_reprint_flag).ToUpper() != "N")
            {
                err_ind = 9;
                await za0_common_error();
                await ba0_acpt_reprint();
            }
        }

        private async Task ba0_acpt_dtl1()
        {
            Display("scr-msg-var.", "scr-msg-dtl1");
            await Prompt("msg_dtl1");

            if (string.IsNullOrWhiteSpace(msg_dtl1))
            {
                err_ind = 11;
                await za0_common_error();
                await ba0_acpt_dtl1();
            }
        }

        private async Task ba0_acpt_dtl2()
        {
            Display("scr-msg-var.", "scr-msg-dtl2");
            await Prompt("msg_dtl2");
        }

        private async Task ba0_acpt_dtl3()
        {
            Display("scr-msg-var.", "scr-msg-dtl3");
            await Prompt("msg_dtl3");

            if (!string.IsNullOrWhiteSpace(msg_dtl3) && string.IsNullOrWhiteSpace(msg_dtl2))
            {
                err_ind = 4;
                await za0_common_error();
                await ba0_acpt_dtl2();
            }
        }

        private async Task ba0_acpt_dtl4()
        {
            Display("scr-msg-var.", "scr-msg-dtl4");
            await Prompt("msg_dtl4");

            if (!string.IsNullOrWhiteSpace(msg_dtl4) && string.IsNullOrWhiteSpace(msg_dtl3))
            {
                err_ind = 10;
                await za0_common_error();
                await ba0_acpt_dtl3();
            }
        }

        private async Task ca0_display_records()
        {
            cur_line = 5;

            do
            {
                switch (cur_line)
                {
                    case 5:
                        msg_sub_key_23 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23);
                        msg_reprint_flag = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 9:
                        msg_sub_key_23_2 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23);
                        msg_reprint_flag_2 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_2 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_2 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_2 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_2 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 13:
                        msg_sub_key_23_3 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23);
                        msg_reprint_flag_3 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_3 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_3 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_3 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_3 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 17:
                        msg_sub_key_23_4 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23);
                        msg_reprint_flag_4 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_4 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_4 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_4 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_4 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;
                }

                Display("scr-msg-lit.", false);
                Display("scr-msg-var.", false);
                Display("option-mode.", "option-mode-2.", false);

                await ca2_load_inquire();
            } while ((cur_line <= 19) && !flag_eof_msg_sub_mstr.Equals(eof_msg_sub_mstr) && (Util.Str(msg_sub_key_1).ToUpper() == msg_indexer));

            if (flag_eof_msg_sub_mstr.Equals(eof_msg_sub_mstr) || (Util.Str(msg_sub_key_1).ToUpper() != msg_indexer))
            {
                Display("end-of-file.");
                acc_mod_rej = "N";
                err_rtn = "";

                Display("err-msg-line.", "err-rtn.");
                await Prompt("err_rtn");
                Display("blank-line-24.");

                ctr_msg_mstr_reads = 0;
            }
            else
            {
                Display("scr-inquire.");
                await Prompt("acc_mod_rej", "scr-inquire.", "inq-acc-mod-rej.");
                Display("blank-line-24.");

                if (acc_mod_rej == "Y")
                {
                    Display("msg-one.", false);
                    Display("msg-two.", false);
                    Display("msg-three.", false);
                    Display("msg-four.", false);
                    Display("msg-one-2.", false);
                    Display("msg-two-2.", false);
                    Display("msg-three-2.", false);
                    Display("msg-four-2.", false);
                    Display("msg-one-3.", false);
                    Display("msg-two-3.", false);
                    Display("msg-three-3.", false);
                    Display("msg-four-3.", false);
                    Display("msg-one-4.", false);
                    Display("msg-two-4.", false);
                    Display("msg-three-4.", false);
                    Display("msg-four-4.", false);

                    ya0_read_msg_sub_mstr_next();
                }
                else
                {
                    ctr_msg_mstr_reads = 0;
                }

            }
        }

        private async Task ca1_clear_inquire()
        {
            Display("clear-inquire-screen.");
        }

        private async Task ca2_load_inquire()
        {
            switch (cur_line)
            {
                case 5:
                    Display("msg-one.");

                    if (!string.IsNullOrWhiteSpace(msg_dtl2))
                    {
                        Display("msg-two.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl3))
                    {
                        Display("msg-three.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl4))
                    {
                        Display("msg-four.");
                    }
                    break;

                case 9:
                    Display("msg-one-2.");

                    if (!string.IsNullOrWhiteSpace(msg_dtl2_2))
                    {
                        Display("msg-two-2.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl3_2))
                    {
                        Display("msg-three-2.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl4_2))
                    {
                        Display("msg-four-2.");
                    }
                    break;

                case 13:
                    Display("msg-one-3.");

                    if (!string.IsNullOrWhiteSpace(msg_dtl2_3))
                    {
                        Display("msg-two-3.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl3_3))
                    {
                        Display("msg-three-3.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl4_3))
                    {
                        Display("msg-four-3.");
                    }
                    break;

                case 17:
                    Display("msg-one-4.");

                    if (!string.IsNullOrWhiteSpace(msg_dtl2_4))
                    {
                        Display("msg-two-4.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl3_4))
                    {
                        Display("msg-three-4.");
                    }

                    if (!string.IsNullOrWhiteSpace(msg_dtl4_4))
                    {
                        Display("msg-four-4.");
                    }
                    break;
            }

            cur_line += 4;

            if (cur_line < 20)
            {
                await ya0_read_msg_sub_mstr_next();
            }
            else if (ctr_msg_mstr_reads >= Msg_mstr_rec_Collection.Count())
            {
                flag_eof_msg_sub_mstr = "Y";
            }

        }

        private async Task ia0_write_new_rec()
        {
            if (await Write_Msg_Mstr_Rec() == false)
            {
                err_ind = 5;
                await za0_common_error();
                await az0_end_of_job();
            }
            else
            {
                ctr_msg_mstr_writes++;
                ctr_msg_mstr_adds++;
            }

        }

        private async Task ka0_re_write_rec()
        {
            if (await Rewrite_Msg_Mstr_Rec() == false)
            {
                err_ind = 6;
                await za0_common_error();
                await az0_end_of_job();
            }
            else
            {
                ctr_msg_mstr_changes++;
                ctr_msg_mstr_writes++;
            }
        }

        private async Task ma0_delete_rec()
        {
            if (objMsg_mstr_rec.Delete() == false)
            {
                err_ind = 7;
                await za0_common_error();
                await az0_end_of_job();
            }
            else
            {
                objMsg_sub_mstr_rec.Delete();
                ctr_msg_mstr_deletes++;
            }
        }

        private async Task xa0_acpt_msg_entered()
        {
            Display("scr-titles.", "scr-msg-id");
            await Prompt("ws_msg_sub_key_23");

            msg_sub_key_2 = ws_msg_sub_key_23.Substring(0, 1);

            if (ws_msg_sub_key_23.Length == 2)
            {
                msg_sub_key_3 = ws_msg_sub_key_23.Substring(1, 1);
            }
            else
            {
                msg_sub_key_3 = "";
            }
        }

        private async Task xc0_read_msg_mstr()
        {
            flag_status = "Y";

            if (entry_type.Equals(add_code))
            {
                Msg_mstr_rec_Collection = new F094_MSG_MSTR
                {
                    WhereMsg_sub_key_1 = ws_msg_sub_key_1,
                    WhereMsg_sub_key_23 = ws_msg_sub_key_23
                }.Collection();

                if (Msg_mstr_rec_Collection.Count() == 0)
                {
                    flag_status = "N";
                    return;
                }
            }
            else if (entry_type.Equals(change_code) || entry_type.Equals(delete_code))
            {
                Msg_mstr_rec_Collection = new F094_MSG_MSTR
                {
                    WhereMsg_sub_key_1 = ws_msg_sub_key_1,
                    WhereMsg_sub_key_23 = ws_msg_sub_key_23
                }.Collection();

                if (Msg_mstr_rec_Collection.Count() > 0)
                {
                    flag_status = "Y";
                    cur_line = 5;

                    Msg_sub_mstr_rec_Collection = new F094_SUB_MSTR
                    {
                        WhereMsg_sub_key_12 = ws_msg_sub_key_1 + ws_msg_sub_key_23.Substring(0, 1),
                        WhereMsg_sub_key_3 = ws_msg_sub_key_23.Substring(1, 1)
                    }.Collection();
                }
                else
                { 
                    flag_status = "N";
                    return;
                }
            }
            else if (entry_type.Equals(inquire_code))
            {
                Msg_mstr_rec_Collection = new F094_MSG_MSTR
                {
                    WhereMsg_sub_key_1 = ws_msg_sub_key_1,
                    WhereMsg_sub_key_23 = ws_msg_sub_key_23
                }.Collection_GetMessages();

                flag_status = "Y";
            }

            objMsg_mstr_rec = Msg_mstr_rec_Collection[0];

            if (entry_type.Equals(change_code) || entry_type.Equals(delete_code))
            {
                objMsg_mstr_rec = Msg_mstr_rec_Collection[0];
                objMsg_sub_mstr_rec = Msg_sub_mstr_rec_Collection[0];
            }

            cur_line = 5;
            await Assign_Msg_Mstr_Rec_to_ScreenVariables();

            ctr_msg_mstr_reads++;
        }

        private async Task xd0_acpt_type_msg_read_msg()
        {
            //if (Util.Str(ws_msg_sub_key_23).PadRight(2).Substring(0, 1) == "*")
            //{
            //Display("scr-titles.", "scr-titles-5.", false);
            Display("add-mode.", false);
            Display("change-mode.", false);
            Display("delete-mode.", false);
            Display("inquire-mode.", false);
            Display("scr-msg-var.", false);
            Display("option-mode.");

            entry_type = "";
            ws_msg_sub_key_23 = "";

            Display("scr-titles.", "scr-option-sel");
            Display("scr-titles.", "scr-msg-id");
            await Prompt("entry_type");

            if (!entry_type.Equals("*"))
            {
                if (entry_type == add_code || entry_type == change_code || entry_type == inquire_code || entry_type == delete_code)
                {
                    Display("option-mode.", false);

                    switch (entry_type)
                    {
                        case "A":
                            Display("add-mode.");
                            break;
                        case "C":
                            Display("change-mode.");
                            break;
                        case "I":
                            Display("inquire-mode.");
                            break;
                        case "D":
                            Display("delete-mode.");
                            break;
                    }
                }

                if (entry_type.Equals(add_code))
                {
                    Display("option-mode.", "option-mode-1.", false);
                    Display("add-mode.");
                    Display("scr-msg-lit.");
                }
                else if (entry_type.Equals(change_code))
                {
                    Display("option-mode.", "option-mode-1.", false);
                    Display("change-mode.");
                    Display("scr-msg-lit.");
                }
                else if (entry_type.Equals(delete_code))
                {
                    Display("option-mode.", "option-mode-1.", false);
                    Display("delete-mode.");
                    Display("scr-msg-lit.");
                }
                else if (entry_type.Equals(inquire_code))
                {
                    Display("option-mode.", "option-mode-1.", false);
                    Display("inquire-mode.");
                    Display("inquire-screen.");

                    Display("msg-one.", false);
                    Display("msg-two.", false);
                    Display("msg-three.", false);
                    Display("msg-four.", false);
                    Display("msg-one-2.", false);
                    Display("msg-two-2.", false);
                    Display("msg-three-2.", false);
                    Display("msg-four-2.", false);
                    Display("msg-one-3.", false);
                    Display("msg-two-3.", false);
                    Display("msg-three-3.", false);
                    Display("msg-four-3.", false);
                    Display("msg-one-4.", false);
                    Display("msg-two-4.", false);
                    Display("msg-three-4.", false);
                    Display("msg-four-4.", false);
                    cur_line = 5;
                }
                else
                {
                    err_ind = 1;
                    await za0_common_error();
                    ws_msg_sub_key_23 = "*";
                    await xd0_acpt_type_msg_read_msg();
                }
                //}
            }
        }

        private async Task xd0_10_acpt_msg()
        {
            ws_msg_sub_key_23 = "";
            Display("scr-titles.", "scr-msg-id");

            await xa0_acpt_msg_entered();

            if (ws_msg_sub_key_23 == "*")
            {
                Display("scr-msg-lit.", false);
            }
            else if (!Util.IsNumeric(ws_msg_sub_key_23))
            {
                err_ind = 8;
                await za0_common_error();
            }
            else
            {
                ws_msg_sub_key_grp = ws_msg_sub_key_1 + ws_msg_sub_key_23;
                msg_sub_key_grp = ws_msg_sub_key_grp;
                msg_sub_key_1 = Util.Str(msg_sub_key_grp).PadRight(3).Substring(0, 1);
                msg_sub_key_23 = Util.Str(msg_sub_key_grp).PadRight(3).Substring(1, 2);
                msg_sub_key_2 = Util.Str(msg_sub_key_23).Substring(0, 1);
                msg_sub_key_3 = Util.Str(msg_sub_key_23).Substring(1, 1);

                xc0_read_msg_mstr();

                if (flag_status.Equals(ok) && entry_type.Equals(add_code))
                {
                    err_ind = 2;
                    await za0_common_error();
                }
                else if (flag_status.Equals(not_ok) && (entry_type.Equals(delete_code) || entry_type.Equals(change_code)))
                {
                    err_ind = 3;
                    await za0_common_error();
                }
            }
        }

        private async Task ya0_read_msg_sub_mstr_next()
        {
            if (ctr_msg_mstr_reads >= Msg_mstr_rec_Collection.Count() || Msg_mstr_rec_Collection.Count() == 0)
            {
                flag_eof_msg_sub_mstr = "Y";
            }
            else
            {
                objMsg_mstr_rec = Msg_mstr_rec_Collection[ctr_msg_mstr_reads];
                await Assign_Msg_Mstr_Rec_to_ScreenVariables();

                ctr_msg_mstr_reads++;
            }
        }

        private async Task za0_common_error()
        {
            err_msg_comment = err_msg[err_ind];
            err_rtn = "";
            Display("err-msg-line.");
            Display("err-msg-line.", "err-rtn.", false);

            Display("scr-confirm");
            await Prompt("confirm_space");

            Display("err-msg-line.", false);
            Display("scr-confirm", false);
        }

        private async Task y2k_default_sysdate()
        {
            sys_date_temp = sys_date_left;
            sys_date_right = sys_date_temp;
            sys_date_blank = "0";
            sys_date_numeric += 20000000;
        }

        private async Task Initialize_Msg_Sub_Mstr_Record_ScreenVariables()
        {
            msg_sub_key_grp = "";
            msg_sub_key_1 = "";
            msg_sub_key_23_grp = "";
            msg_sub_key_2 = "";
            msg_sub_key_3 = "";

            msg_reprint_flag = "";
            msg_auto_logout = "";
            msg_dtl1 = "";
            msg_dtl2 = "";
            msg_dtl3 = "";
            msg_dtl4 = "";

            sub_name = "";
            sub_fee_complex = "";
            sub_auto_logout = "";
        }

        private async Task<bool> Write_Msg_Mstr_Rec()
        {
            try
            {
                F094_MSG_MSTR objMsg_mstr_rec = null;
                objMsg_mstr_rec = new F094_MSG_MSTR();

                objMsg_mstr_rec.MSG_SUB_KEY_1 = msg_sub_key_1;
                objMsg_mstr_rec.MSG_SUB_KEY_23 = Util.Str(msg_sub_key_2).PadRight(1) + Util.Str(msg_sub_key_3).PadRight(1);
                objMsg_mstr_rec.MSG_REPRINT_FLAG = msg_reprint_flag;
                objMsg_mstr_rec.MSG_AUTO_LOGOUT = msg_auto_logout;
                objMsg_mstr_rec.MSG_DTL1 = msg_dtl1;
                objMsg_mstr_rec.MSG_DTL2 = msg_dtl2;
                objMsg_mstr_rec.MSG_DTL3 = msg_dtl3;
                objMsg_mstr_rec.MSG_DTL4 = msg_dtl4;
                objMsg_mstr_rec.RecordState = State.Added;
                objMsg_mstr_rec.Submit();

                F094_SUB_MSTR objMsg_sub_mstr_rec = null;
                objMsg_sub_mstr_rec = new F094_SUB_MSTR();

                objMsg_sub_mstr_rec.MSG_SUB_KEY_12 = msg_sub_key_1 + msg_sub_key_2;
                objMsg_sub_mstr_rec.MSG_SUB_KEY_3 = msg_sub_key_3;

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length < 23)
                {
                    objMsg_sub_mstr_rec.SUB_NAME = msg_reprint_flag + msg_auto_logout.PadRight(1) + (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4);
                }
                else
                {
                    objMsg_sub_mstr_rec.SUB_NAME = msg_reprint_flag + msg_auto_logout.PadRight(1) + (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(0, 23);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 24)
                {
                    objMsg_sub_mstr_rec.SUB_FEE_COMPLEX = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(23, 1);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 25)
                {
                    objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(24, 1);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 26)
                {
                    objMsg_sub_mstr_rec.FILLER = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(25);
                }

                objMsg_sub_mstr_rec.RecordState = State.Added;
                objMsg_sub_mstr_rec.Submit();
            }

            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> Rewrite_Msg_Mstr_Rec()
        {
            try
            {
                F094_MSG_MSTR objF094_MSG_MSTR = new F094_MSG_MSTR
                {
                    WhereRowid = objMsg_mstr_rec.ROWID
                }.Collection().FirstOrDefault();

                objF094_MSG_MSTR.MSG_SUB_KEY_1 = msg_sub_key_1;
                objF094_MSG_MSTR.MSG_SUB_KEY_23 = Util.Str(msg_sub_key_2).PadRight(1) + Util.Str(msg_sub_key_3).PadRight(1);

                objF094_MSG_MSTR.MSG_REPRINT_FLAG = msg_reprint_flag;
                objF094_MSG_MSTR.MSG_AUTO_LOGOUT = msg_auto_logout;
                objF094_MSG_MSTR.MSG_DTL1 = msg_dtl1;
                objF094_MSG_MSTR.MSG_DTL2 = msg_dtl2;
                objF094_MSG_MSTR.MSG_DTL3 = msg_dtl3;
                objF094_MSG_MSTR.MSG_DTL4 = msg_dtl4;
                objF094_MSG_MSTR.RecordState = State.Modified;
                objF094_MSG_MSTR.Submit();

                F094_SUB_MSTR objF094_SUB_MSTR = new F094_SUB_MSTR
                {
                    WhereRowid = objMsg_sub_mstr_rec.ROWID
                }.Collection().FirstOrDefault();

                objMsg_sub_mstr_rec.MSG_SUB_KEY_12 = msg_sub_key_1 + msg_sub_key_2;
                objMsg_sub_mstr_rec.MSG_SUB_KEY_3 = msg_sub_key_3;

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length < 23)
                {
                    objMsg_sub_mstr_rec.SUB_NAME = msg_reprint_flag + msg_auto_logout.PadRight(1) + (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4);
                }
                else
                {
                    objMsg_sub_mstr_rec.SUB_NAME = msg_reprint_flag + msg_auto_logout.PadRight(1) + (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(0, 23);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 24)
                {
                    objMsg_sub_mstr_rec.SUB_FEE_COMPLEX = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(23, 1);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 25)
                {
                    objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(24, 1);
                }

                if ((msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Length >= 26)
                {
                    objMsg_sub_mstr_rec.FILLER = (msg_dtl1 + msg_dtl2 + msg_dtl3 + msg_dtl4).Substring(25);
                }

                objMsg_sub_mstr_rec.RecordState = State.Modified;
                objMsg_sub_mstr_rec.Submit();
            }

            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task Assign_Msg_Mstr_Rec_to_ScreenVariables()
        {
            try
            {
                msg_sub_key_1 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_1);
                msg_sub_key_2 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23).PadRight(2).Substring(0, 1);
                msg_sub_key_3 = Util.Str(objMsg_mstr_rec.MSG_SUB_KEY_23).PadRight(2).Substring(1, 1);

                msg_auto_logout = Util.Str(objMsg_mstr_rec.MSG_AUTO_LOGOUT);

                switch (cur_line)
                {
                    case 5:
                        msg_reprint_flag = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 9:
                        msg_reprint_flag_2 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_2 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_2 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_2 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_2 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 13:
                        msg_reprint_flag_3 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_3 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_3 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_3 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_3 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;

                    case 17:
                        msg_reprint_flag_4 = Util.Str(objMsg_mstr_rec.MSG_REPRINT_FLAG);
                        msg_dtl1_4 = Util.Str(objMsg_mstr_rec.MSG_DTL1);
                        msg_dtl2_4 = Util.Str(objMsg_mstr_rec.MSG_DTL2);
                        msg_dtl3_4 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                        msg_dtl4_4 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
                        break;
                }
            }

            catch (Exception e)
            {
            }
        }

        private async Task Assign_Msg_Sub_Mstr_Rec_to_ScreenVariables()
        {
            try
            {
                msg_sub_key_12 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_12);
                msg_sub_key_3 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                sub_name = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                sub_fee_complex = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                sub_auto_logout = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                filler = Util.Str(objMsg_sub_mstr_rec.FILLER);
                msg_dtl3 = Util.Str(objMsg_mstr_rec.MSG_DTL3);
                msg_dtl4 = Util.Str(objMsg_mstr_rec.MSG_DTL4);
            }

            catch (Exception e)
            {
            }
        }

        #endregion

        public async Task destroy_objects()
        {
            objMsg_mstr_rec = null;
            Msg_mstr_rec_Collection = null;
            objMsg_sub_mstr_rec = null;
            Msg_sub_mstr_rec_Collection = null;
        }
    }
}

