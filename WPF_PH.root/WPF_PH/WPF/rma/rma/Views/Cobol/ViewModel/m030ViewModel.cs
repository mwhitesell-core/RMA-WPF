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
    public delegate void M030ExitCobolScreen();
    public class M030ViewModel : CommonFunctionScr
    {
        public event M030ExitCobolScreen ExitCobol;
        public M030ViewModel()
        {

        }

        #region FD Section
        // FD: audit_file
        private Audit_record objAudit_record = null;
        private ObservableCollection<Audit_record> Audit_record_Collection;

        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private F030_LOCATIONS_MSTR objLoc_mstr_rec = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> Loc_mstr_rec_Collection;

        WriteFile objobjAudit_File = null;


        #endregion

        #region Properties
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

        private int _ctr_audit_rpt_writes;
        public int ctr_audit_rpt_writes
        {
            get
            {
                return _ctr_audit_rpt_writes;
            }
            set
            {
                if (_ctr_audit_rpt_writes != value)
                {
                    _ctr_audit_rpt_writes = value;
                    RaisePropertyChanged("ctr_audit_rpt_writes");
                }
            }
        }

        private int _ctr_loc_mstr_reads;
        public int ctr_loc_mstr_reads
        {
            get
            {
                return _ctr_loc_mstr_reads;
            }
            set
            {
                if (_ctr_loc_mstr_reads != value)
                {
                    _ctr_loc_mstr_reads = value;
                    RaisePropertyChanged("ctr_loc_mstr_reads");
                }
            }
        }

        private int _ctr_loc_mstr_rewrites;
        public int ctr_loc_mstr_rewrites
        {
            get
            {
                return _ctr_loc_mstr_rewrites;
            }
            set
            {
                if (_ctr_loc_mstr_rewrites != value)
                {
                    _ctr_loc_mstr_rewrites = value;
                    RaisePropertyChanged("ctr_loc_mstr_rewrites");
                }
            }
        }

        private int _ctr_loc_mstr_writes;
        public int ctr_loc_mstr_writes
        {
            get
            {
                return _ctr_loc_mstr_writes;
            }
            set
            {
                if (_ctr_loc_mstr_writes != value)
                {
                    _ctr_loc_mstr_writes = value;
                    RaisePropertyChanged("ctr_loc_mstr_writes");
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

        private string _flag;
        public string flag
        {
            get
            {
                return _flag;
            }
            set
            {
                if (_flag != value)
                {
                    _flag = value;
                    _flag = _flag.ToUpper();
                    RaisePropertyChanged("flag");
                }
            }
        }

        private string _loc_active_for_entry;
        public string loc_active_for_entry
        {
            get
            {
                return _loc_active_for_entry;
            }
            set
            {
                if (_loc_active_for_entry != value)
                {
                    _loc_active_for_entry = value;
                    _loc_active_for_entry = _loc_active_for_entry.ToUpper();
                    RaisePropertyChanged("loc_active_for_entry");
                }
            }
        }

        private int _loc_clinic_nbr;
        public int loc_clinic_nbr
        {
            get
            {
                return _loc_clinic_nbr;
            }
            set
            {
                if (_loc_clinic_nbr != value)
                {
                    _loc_clinic_nbr = value;
                    RaisePropertyChanged("loc_clinic_nbr");
                }
            }
        }

        private string _loc_hospital_code;
        public string loc_hospital_code
        {
            get
            {
                return _loc_hospital_code;
            }
            set
            {
                if (_loc_hospital_code != value)
                {
                    _loc_hospital_code = value;
                    _loc_hospital_code = _loc_hospital_code.ToUpper();
                    RaisePropertyChanged("loc_hospital_code");
                }
            }
        }

        private int _loc_hospital_nbr;
        public int loc_hospital_nbr
        {
            get
            {
                return _loc_hospital_nbr;
            }
            set
            {
                if (_loc_hospital_nbr != value)
                {
                    _loc_hospital_nbr = value;
                    RaisePropertyChanged("loc_hospital_nbr");
                }
            }
        }

        private string _loc_in_out_ind;
        public string loc_in_out_ind
        {
            get
            {
                return _loc_in_out_ind;
            }
            set
            {
                if (_loc_in_out_ind != value)
                {
                    _loc_in_out_ind = value;
                    _loc_in_out_ind = _loc_in_out_ind.ToUpper();
                    RaisePropertyChanged("loc_in_out_ind");
                }
            }
        }

        private int _loc_ministry_loc_code;
        public int loc_ministry_loc_code
        {
            get
            {
                return _loc_ministry_loc_code;
            }
            set
            {
                if (_loc_ministry_loc_code != value)
                {
                    _loc_ministry_loc_code = value;
                    RaisePropertyChanged("loc_ministry_loc_code");
                }
            }
        }

        private string _loc_name;
        public string loc_name
        {
            get
            {
                return _loc_name;
            }
            set
            {
                if (_loc_name != value)
                {
                    _loc_name = value;
                    _loc_name = _loc_name.ToUpper();
                    RaisePropertyChanged("loc_name");
                }
            }
        }

        private string _loc_nbr;
        public string loc_nbr
        {
            get
            {
                return _loc_nbr;
            }
            set
            {
                if (_loc_nbr != value)
                {
                    _loc_nbr = value;
                    _loc_nbr = _loc_nbr.ToUpper();
                    RaisePropertyChanged("loc_nbr");
                }
            }
        }

        private string _loc_payroll_flag;
        public string loc_payroll_flag
        {
            get
            {
                return _loc_payroll_flag;
            }
            set
            {
                if (_loc_payroll_flag != value)
                {
                    _loc_payroll_flag = value;
                    _loc_payroll_flag = _loc_payroll_flag.ToUpper();
                    RaisePropertyChanged("loc_payroll_flag");
                }
            }
        }

        private string _loc_service_location_indicator;
        public string loc_service_location_indicator
        {
            get
            {
                return _loc_service_location_indicator;
            }
            set
            {
                if (_loc_service_location_indicator != value)
                {
                    _loc_service_location_indicator = value;
                    _loc_service_location_indicator = _loc_service_location_indicator.ToUpper();
                    RaisePropertyChanged("loc_service_location_indicator");
                }
            }
        }

        private string _option;
        public string option
        {
            get
            {
                return _option;
            }
            set
            {
                if (_option != value)
                {
                    _option = value;
                    _option = _option.ToUpper();
                    RaisePropertyChanged("option");
                }
            }
        }

        private string _print_file_name;
        public string print_file_name
        {
            get
            {
                return _print_file_name = "rm030";
            }
            set
            {
                if (_print_file_name != value)
                {
                    _print_file_name = value;
                    _print_file_name = _print_file_name.ToUpper();
                    RaisePropertyChanged("print_file_name");
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


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        //private string print_file_name = "rm030";
        //private string option;
        private string eof_loc_mstr = "N";
        //private string status_file;
        private string status_cobol_loc_mstr = "0";
        private string status_audit_rpt = "0";
        //private string confirm_space = space;
        //private string flag;
        private string ok = "Y";
        private string not_ok = "N";

        private string counters_grp;
        //private int ctr_loc_mstr_reads;
        //private int ctr_loc_mstr_writes;
        //private int ctr_loc_mstr_rewrites;
        //private int ctr_audit_rpt_writes;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "invalid reply",
                                "LOCATION ALREADY EXISTS",
                                "INVALID Clinic Nbr",
                                "INVALID HOSPITAL NUMBER",
                                "LOCATION NAME MUST NOT BE BLANK",
                                "I/O Indicator must be  'I'n or 'O'ut",
                                "RECORD DOESN'T EXIST",
                                "'Active for entry' flag must be 'Y'es or 'N'o",
                                "PAYROLL FLAG must be 'Y'es or 'N'o",
                                "ERROR MESSAGE # 10 GOES HERE",
                                "ERROR MESSAGE # 11 GOES HERE"};
        private string error_messages_r_grp;
        //private string[] err_msg =  new string[12];
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private string site_id = "RMA";
        private int century_year;
        private int century_date;
        private int default_century_cc = 19;
        private int default_century_cccc = 1900;

        private string sys_date_grp;
        private string sys_date_long;
        private string sys_date_long_r_grp;
        //private int sys_yy;
        private string sys_yy_alpha_grp;
        private int sys_y1;
        private int sys_y2;
        private int sys_y3;
        private int sys_y4;
        //private int sys_mm;
        //private int sys_dd;
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
        //private string filler = "/";
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
        //private string filler = ":";
        private int run_min;
        //private string filler = ":";
        private int run_sec;

        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "M030        LOCATION MASTER MAINTENANCE -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 32,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "option",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 34,Data1 = "(ADD/CHANGE/DELETE/INQUIRY)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-changee-delete-inquiry"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-displays.",Line = "1",Col = 36,Data1 = "ADD                           ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-add"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-displays.",Line = "1",Col = 36,Data1 = "CHANGE                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-chg"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-displays.",Line = "1",Col = 36,Data1 = "DELETE                        ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-del"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-displays.",Line = "1",Col = 36,Data1 = "INQUIRY                       ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-inq"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-loc-nbr.",Line = "03",Col = 10,Data1 = "LOCATION NUMBER:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-acpt-loc-nbr.",Line = "03",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 1,Data1 = "Location Name          -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-loc-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 1,Data1 = "Clinic Number          -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "loc_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 1,Data1 = "Hospital Number        -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "loc_hospital_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hospital-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 1,Data1 = "   ''    Code          -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_hospital_code",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hospital-code"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 1,Data1 = "Ministry Location      -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "loc_ministry_loc_code",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-loc-ministry-loc"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 1,Data1 = "I/O Indicator          -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_in_out_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-in-out-ind"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 1,Data1 = "Payroll Flag           -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_payroll_flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-payroll-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 1,Data1 = "Active for Data Entry? -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_active_for_entry",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-active-for-entry"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 1,Data1 = "service Location Indicator",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 24,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "loc_service_location_indicator",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-serv-loc-ind"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 2,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 12,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(60)",MaxLength = 60,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-add-chg.",Line = "24",Col = 30,Data1 = "ACCEPT (Y/N/M) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-add-chg.",Line = "24",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "verification-screen-add-chg-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-inq.",Line = "24",Col = 29,Data1 = "CONTINUE X",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-inq.",Line = "24",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "verification-screen-inq-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 30,Data1 = "DELETE (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "verification-screen-del-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 20,Data1 = "NUMBER OF LOC-MSTR ACCESSES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_loc_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 20,Data1 = "NUMBER OF LOC-MSTR WRITES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "6",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_loc_mstr_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF LOC-MSTR REWRITES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_loc_mstr_rewrites",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 20,Data1 = "NUMBER OF AUDIT RPT WRITES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(7)",MaxLength = 7,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_audit_rpt_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 20,Data1 = "PROGRAM M030 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "AUDIT REPORT IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_loc_mstr_file_section()
        {

            //     use after standard error procedure on loc-mstr.;
        }

        private async Task err_loc_mstr()
        {

            //     stop "ERROR IN ACCESSING LOCATION MASTER".;
            status_file = status_cobol_loc_mstr;
            //     display file-status-display.;
            //     stop run.;
        }

        private async Task err_audit_rpt_file_section()
        {

            //     use after standard error procedure on audit-file.;
        }

        private async Task err_audit_rpt()
        {

            //     stop "ERROR IN WRITING TO AUDIT REPORT FILE".;
            status_file = status_audit_rpt;
            //     display file-status-display.;
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
            objobjAudit_File = null;
            objobjAudit_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + print_file_name, false);

            objLoc_mstr_rec = new F030_LOCATIONS_MSTR();
            Loc_mstr_rec_Collection = new ObservableCollection<F030_LOCATIONS_MSTR>();
        }

        public async Task mainline()
        {
            try
            {
                await initialize_objects();

               //  perform aa0-initialization		thru aa0-99-exit.;
               await aa0_initialization();
                await aa0_99_exit();

                //  perform ab0-processing		thru	ab0-99-exit.;
 _ab0_processing:
               string retVal =   await ab0_processing();
                if (retVal.ToLower().Equals("ab0_99_exit"))
                {
                    goto _az0_99_exit;
                }

_ab0_01:
                retVal = await ab0_01();
                if (Util.Str(retVal).ToLower().Equals("ab0_processing"))
                {
                    goto _ab0_processing;
                }

 _ab0_05:
                await ab0_05();

                retVal =  await ab0_10();
                if (retVal.ToLower().Equals("ab0_05"))
                {
                    goto _ab0_05;
                }
                else if (retVal.ToLower().Equals("ab0_01"))
                {
                    goto _ab0_01;
                }

                 await ab0_99_exit();

                //   perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();

 _az0_99_exit:
                 await az0_99_exit();

                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    err_msg_comment = " Runtime error : " + e.Message.ToString();
                    Display("err-msg-line.");
                }
            }
            finally
            {
                objobjAudit_File.CloseOutputFile();
                objobjAudit_File = null;
                if (option.Equals("*"))
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

            //     accept sys-date			from date.;
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
            await y2k_default_sysdate();
            await y2k_default_sysdate_exit();

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open i-o loc-mstr.;
            //     open output audit-file.;
        }

        private async Task aa0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> ab0_processing()
        {
            
            option = string.Empty;

            // display scr-title.;
            // accept scr-title.;
            Display("scr-title.");
            await Prompt("option");

            // if option = "A" then            
            if (Util.Str(option).ToUpper() == "A")
            {
                //   	display scr-option-add;
                Display("scr-title.", "scr-add-changee-delete-inquiry", false);
                Display("scr-option-displays.", "scr-option-add");
            }
            //  else if option = "C" then            
            else if (Util.Str(option).ToUpper() == "C")
            {
                //   	    display scr-option-chg;
                Display("scr-title.", "scr-add-changee-delete-inquiry", false);
                Display("scr-option-displays.", "scr-option-chg");
            }
            // else if option = "D" then            
            else if (Util.Str(option).ToUpper() == "D")
            {
                //     	display scr-option-del;
                Display("scr-title.", "scr-add-changee-delete-inquiry", false);
                Display("scr-option-displays.", "scr-option-del");
            }
            // else if option = "I" then            
            else if (Util.Str(option).ToUpper() == "I")
            {
                //      display scr-option-inq;
                Display("scr-title.", "scr-add-changee-delete-inquiry", false);
                Display("scr-option-displays.", "scr-option-inq");
            }
            // else if option = "*" then            
            else if (option == "*")
            {
                // 		go to ab0-99-exit;                
                return "ab0_99_exit";
            }
            else
            {
                err_ind = 1;
                //   	perform za0-common-error thru za0-99-exit            
                await za0_common_error();
                await za0_99_exit();
                //  	go to ab0-processing.;
                await ab0_processing();                
            }
            return string.Empty;
        }

        private async Task<string> ab0_01()
        {

            await initialize_screen_variables();

            //objLoc_mstr_rec.loc_mstr_rec = "";
            objLoc_mstr_rec = null;
            objLoc_mstr_rec = new F030_LOCATIONS_MSTR();

            //     display scr-acpt-loc-nbr.;
            //     accept scr-acpt-loc-nbr.;
            Display("scr-acpt-loc-nbr.");
            await Prompt("loc_nbr");

            //  if   loc-nbr = "*" or loc-nbr = "**" or loc-nbr = "***"  or loc-nbr = "****" then
            if (loc_nbr == "*" || loc_nbr == "**" || loc_nbr == "***" || loc_nbr == "****")
            {
                // 	   go to ab0-processing.;                
                return "ab0_processing";
            }

            flag = "N";
            //     perform ma0-read-loc-mstr		thru ma0-99-exit.;
            await ma0_read_loc_mstr();
            await ma0_99_exit();

            // if  ok and option = "A" then
            if (flag.Equals(ok) && Util.Str(option).ToUpper() == "A")
            {
                err_ind = 2;
                //  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ab0-01.;                
                await  ab0_01();
            }

            //  if not-ok then            
            if (flag.Equals(not_ok))
            {
                // 	    if  option = "I" or option = "C" or option = "D" then            
                if (Util.Str(option).ToUpper() == "I" || Util.Str(option).ToUpper() == "C" || Util.Str(option).ToUpper() == "D")
                {
                    err_ind = 7;
                    //     perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	        go to ab0-01.;                    
                    await ab0_01();
                }
            }

            return string.Empty;
        }

        private async Task ab0_05()
        {

            //     display scr-mask1.;
            Display("scr-mask1.");

            //  if  option = "A" or option = "C" then 
            if (Util.Str(option).ToUpper() == "A" || Util.Str(option).ToUpper() == "C")
            {
                // 	    perform ka0-acpt-loc-name	thru	ka0-99-exit;
                await ka0_acpt_loc_name();
                await ka0_99_exit();
                // 	    perform ia0-acpt-clinic-nbr	thru	ia0-99-exit;
                await ia0_acpt_clinic_nbr();
                await ia0_99_exit();
                // 	    perform ja0-acpt-hospital-nbr	thru	ja0-99-exit;
                await ja0_acpt_hospital_nbr();
                await ja0_99_exit();
                // 	    perform sa0-acpt-hospital-code	thru	sa0-99-exit;
                await sa0_acpt_hospital_code();
                await sa0_99_exit();
                // 	    perform ta0-acpt-ministry-loc	thru	ta0-99-exit;
                await ta0_acpt_ministry_loc();
                await ta0_99_exit();
                // 	    perform la0-acpt-in-out-ind	thru	la0-99-exit;
                await la0_acpt_in_out_ind();
                await la0_99_exit();
                //      perform va0-acpt-payroll-flag   thru    va0-99-exit;
                await va0_acpt_payroll_flag();
                await va0_99_exit();
                // 	    perform ua0-acpt-active-flag	thru	ua0-99-exit.;
                await ua0_acpt_active_flag();
                await ua0_99_exit();
            }
        }

        private async Task<string> ab0_10()
        {


            // if  option = "A"  or option = "C" then            
            if (Util.Str(option).ToUpper() == "A" || Util.Str(option).ToUpper() == "C")
            {
                Display("scr-title.", "scr-add-changee-delete-inquiry",false);
                // 	   display verification-screen-add-chg;
                // 	   accept verification-screen-add-chg;
                Display("verification-screen-add-chg.");
                await Prompt("flag", "verification-screen-add-chg.", "verification-screen-add-chg-flag");
            }
            // else if option = "D"  then            
            else if (Util.Str(option).ToUpper() == "D")
            {
                // 	    display verification-screen-del;
                // 	    accept verification-screen-del;
                Display("verification-screen-del.");
                await Prompt("flag", "verification-screen-del", "verification-screen-del-flag");
            }
            else
            {
                // 	    display verification-screen-inq;
                // 	    accept verification-screen-inq.;
                Display("verification-screen-inq.");
                await Prompt("flag", "verification-screen-inq", "verification-screen-inq-flag");
            }

            // if option not = "I" then 
            if (Util.Str(option).ToUpper() != "I")
            {
                // 	    if flag = "Y" then
                if (Util.Str(flag).ToUpper() == "Y")
                {
                    // 	         if option = "A" then          
                    if (Util.Str(option).ToUpper() == "A")
                    {
                        // 		         perform na0-write-loc-mstr thru	na0-99-exit            
                        await na0_write_loc_mstr();
                        await na0_99_exit();
                        // 		         perform ra0-write-audit-rpt thru	ra0-99-exit;            
                        await ra0_write_audit_rpt();
                        await ra0_99_exit();
                        flag = "";
                        //      display verification-screen-add-chg;
                        Display("verification-screen-add-chg.");
                    }
                    // 	        else if option = "C" then            
                    else if (Util.Str(option).ToUpper() == "C")
                    {
                        // 		         perform pa0-re-write-loc-mstr thru	pa0-99-exit; 
                        await pa0_re_write_loc_mstr();
                        await pa0_99_exit();
                        // 		         perform ra0-write-audit-rpt thru	ra0-99-exit            
                        await ra0_write_audit_rpt();
                        await ra0_99_exit();
                        flag = "";
                        // 		         display verification-screen-add-chg;
                        Display("verification-screen-add-chg.");
                    }
                    else
                    {
                        // 		         perform qa0-delete-loc-mstr thru	qa0-99-exit    
                        await qa0_delete_loc_mstr();
                        await qa0_99_exit();
                        // 		         perform ra0-write-audit-rpt thru	ra0-99-exit            
                        await ra0_write_audit_rpt();
                        await ra0_99_exit();
                        flag = "";
                        // 		         display verification-screen-del;
                        Display("verification-screen-del.");
                    }
                }
                // 	   else if flag = "N" then;            
                else if (Util.Str(flag).ToUpper() == "N")
                {
                    // 		    display scr-reject-entry;
                    Display("scr-reject-entry.");
                    // 		    display confirm;
                    Display("scr-confirm");
                    await Prompt("confirm_space");
                    // 		    stop " ";
                    // 		    display blank-line-24;
                    Display("blank-line-24.");
                }
                // 	   else if flag = "M" then
                else if (Util.Str(flag).ToUpper() == "M")
                {
                    // 		    go to ab0-05;                    
                    return "ab0_05";
                }
                else
                {
                    err_ind = 1;
                    // 		   perform za0-common-error thru za0-99-exit            
                    await za0_common_error();
                    await za0_99_exit();
                    // 		    go to ab0-05;                    
                    return "ab0_05";
                }
            }
            else
            {
                // 	  display verification-screen-inq.;
                Display("verification-screen-inq.");                
            }

            //    objLoc_mstr_rec.loc_mstr_rec = "";            
            await initialize_screen_variables();

            //    display scr-mask1.;
            Display("scr-mask1.");

            //     go to ab0-01.;            
            return "ab0_01";
        }

        private async Task ab0_99_exit()
        {

            //     exit.;
        }

        private async Task ia0_acpt_clinic_nbr()
        {

            //     accept scr-clinic-nbr.;
            Display("scr-mask1.", "scr-clinic-nbr");
            await Prompt("loc_clinic_nbr");

            //  if  (    site-id = "RMA";
            if ((site_id == "RMA"
            //          and ( loc-clinic-nbr =    2215;
                 && (Util.NumInt(loc_clinic_nbr) == 2215
            // 			       or  6008;
                    || Util.NumInt(loc_clinic_nbr) == 6008
            // 			       or  4308;
                   || Util.NumInt(loc_clinic_nbr) == 4308
            // 	     );
                     )
            // 	);
                 )
            //       or;
                  ||
            // 	(    site-id = "HSC";
              (site_id == "HSC"
            //          and ( loc-clinic-nbr =    2215;
                && (loc_clinic_nbr == 2215
            // 			       or  9999;
                || loc_clinic_nbr == 9999
            // 	     );
                     )
            // 	);
            //     then;
            )
            )
            {
                // 	   next sentence;
            }
            else
            {
                err_ind = 3;
                // 	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	go to ia0-acpt-clinic-nbr.;
                await ia0_acpt_clinic_nbr();
                return;
            }
        }

        private async Task ia0_99_exit()
        {

            //     exit.;
        }

        private async Task ja0_acpt_hospital_nbr()
        {
            //     accept scr-hospital-nbr.;
            Display("scr-mask1.", "scr-hospital-nbr");
            await Prompt("loc_hospital_nbr");

            //     perform ja1-read-conmstr		thru ja1-99-exit.;
            await ja1_read_conmstr();
            await ja1_99_exit();
        }

        private async Task ja0_99_exit()
        {

            //     exit.;
        }

        private async Task ja1_read_conmstr()
        {

        }

        private async Task ja1_99_exit()
        {

            //     exit.;
        }

        private async Task ka0_acpt_loc_name()
        {

            //     accept scr-loc-name.;
            Display("scr-mask1.", "scr-loc-name");
            await Prompt("loc_name");

            //  if loc-name = spaces  then            
            if (string.IsNullOrWhiteSpace(loc_name))
            {
                err_ind = 5;
                // 	   perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ka0-acpt-loc-name.;
                await ka0_acpt_loc_name();
                return;
            }
        }

        private async Task ka0_99_exit()
        {

            //     exit.;
        }

        private async Task la0_acpt_in_out_ind()
        {
            //     accept scr-in-out-ind.;
            Display("scr-mask1.", "scr-in-out-ind");
            await Prompt("loc_in_out_ind");

            //  if loc-in-out-ind	=  "I"  or "O" then            
            if (Util.Str(loc_in_out_ind).ToUpper() == "I" || Util.Str(loc_in_out_ind).ToUpper() == "O")
            {
                // 	    next sentence;
            }
            else
            {
                err_ind = 6;
                // 	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	go to la0-acpt-in-out-ind.;
                await la0_acpt_in_out_ind();
                return;
            }
        }

        private async Task la0_99_exit()
        {

            //     exit.;
        }

        private async Task ua0_acpt_active_flag()
        {

            //     accept scr-active-for-entry.;
            Display("scr-mask1.", "scr-active-for-entry");
            await Prompt("loc_active_for_entry");

            //  if loc-active-for-entry =   "Y" or "N" then            
            if (Util.Str(loc_active_for_entry).ToUpper() == "Y" || Util.Str(loc_active_for_entry).ToUpper() == "N")
            {
                // 	    next sentence;
            }
            else
            {
                err_ind = 8;
                // 	  perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ua0-acpt-active-flag.;
                await ua0_acpt_active_flag();
                return;
            }
        }

        private async Task ua0_99_exit()
        {

            //     exit.;
        }

        private async Task ma0_read_loc_mstr()
        {

            //    read loc-mstr;
            // 	invalid key;
            //         flag = "N";
            // 		go to ma0-99-exit.;

            objLoc_mstr_rec = null;
            objLoc_mstr_rec = new F030_LOCATIONS_MSTR
            {
                WhereLoc_nbr = loc_nbr
            }.Collection().FirstOrDefault();

            if (objLoc_mstr_rec == null)
            {
                flag = "N";
                // go to ma0-99-exit.;
                await ma0_99_exit();
                return;
            }

            await assign_location_master_to_variables();
            flag = "Y";
            //     add 1				to ctr-loc-mstr-reads.;
            ctr_loc_mstr_reads++;
        }

        private async Task ma0_99_exit()
        {

            //     exit.;
        }

        private async Task na0_write_loc_mstr()
        {

            //     write loc-mstr-rec;
            // 	invalid key;
            // 	    perform err-loc-mstr.;
            try {
                objLoc_mstr_rec = null;
                objLoc_mstr_rec = new F030_LOCATIONS_MSTR();
                await assign_variables_to_location_master();
                objLoc_mstr_rec.RecordState = State.Added;
                objLoc_mstr_rec.Submit();
            } catch (Exception e)
            {
                await err_loc_mstr();
                throw new Exception(e.Message);
            }

            //     add 1				to ctr-loc-mstr-writes.;
            ctr_loc_mstr_writes++;
        }

        private async Task na0_99_exit()
        {

            //     exit.;
        }

        private async Task pa0_re_write_loc_mstr()
        {

            //     rewrite loc-mstr-rec.;
            await assign_variables_to_location_master();
            objLoc_mstr_rec.RecordState = State.Modified;
            objLoc_mstr_rec.Submit();

            //     add 1				to ctr-loc-mstr-rewrites.;
            ctr_loc_mstr_rewrites++;
        }

        private async Task pa0_99_exit()
        {

            //     exit.;
        }

        private async Task qa0_delete_loc_mstr()
        {

            //     delete loc-mstr record.;
            objLoc_mstr_rec.LOC_NBR = loc_nbr;
            objLoc_mstr_rec.Delete();            
        }

        private async Task qa0_99_exit()
        {

            //     exit.;
        }

        private async Task ra0_write_audit_rpt()
        {

            //objAudit_record				pic.audit_record = objLoc_mstr_rec.loc_mstr_rec;

            string temp = Util.Str(objLoc_mstr_rec.LOC_NBR).PadRight(4) +
                          Util.Str(objLoc_mstr_rec.LOC_CLINIC_NBR).PadLeft(4, '0') +
                          Util.Str(objLoc_mstr_rec.LOC_HOSPITAL_NBR).PadLeft(4, '0') +
                          Util.Str(objLoc_mstr_rec.LOC_HOSPITAL_CODE).PadRight(4) +
                          Util.Str(objLoc_mstr_rec.LOC_CARD_COLOUR).PadRight(1) +
                          Util.Str(objLoc_mstr_rec.LOC_NAME).PadRight(24) +
                          Util.Str(objLoc_mstr_rec.LOC_MINISTRY_LOC_CODE).PadLeft(4, '0') +
                          Util.Str(objLoc_mstr_rec.LOC_PAYROLL_FLAG).PadRight(1) +
                          Util.Str(objLoc_mstr_rec.LOC_ACTIVE_FOR_ENTRY).PadRight(1) +
                          Util.Str(objLoc_mstr_rec.LOC_SERVICE_LOCATION_INDICATOR).PadRight(4) +
                          Util.Str(objLoc_mstr_rec.LOC_FILLER_1).PadRight(9);

            objAudit_record = null;
            objAudit_record = new Audit_record();
            objAudit_record.Audit_record1 = temp;
            //     write audit-record.;
            objobjAudit_File.AppendOutputFile(objAudit_record.Audit_record1, true);

            //     add 1				to ctr-audit-rpt-writes.;
            ctr_audit_rpt_writes++;
        }

        private async Task ra0_99_exit()
        {

            //     exit.;
        }

        private async Task sa0_acpt_hospital_code()
        {

            //     accept scr-hospital-code.;
            Display("scr-mask1.", "scr-hospital-code");
            await Prompt("loc_hospital_code");

        }

        private async Task sa0_99_exit()
        {

            //     exit.;
        }

        private async Task ta0_acpt_ministry_loc()
        {

            //     accept scr-loc-ministry-loc.;
            Display("scr-mask1.", "scr-loc-ministry-loc");
            await Prompt("loc_ministry_loc_code");

            //     accept scr-serv-loc-ind.;
            Display("scr-mask1.", "scr-serv-loc-ind");
            await Prompt("loc_service_location_indicator");
        }

        private async Task ta0_99_exit()
        {

            //     exit.;
        }

        private async Task va0_acpt_payroll_flag()
        {

            //  if site-id <> "HSC" then            
            if (site_id != "HSC")
            {
                // 	    go to va0-99-exit.;
                await va0_99_exit();
                return;
            }

            //     accept scr-payroll-flag.;
            Display("scr-mask1.", "scr-payroll-flag");
            await Prompt("loc_payroll_flag");

            //  if loc-payroll-flag  =   "Y" or "N" then            
            if (Util.Str(loc_payroll_flag).ToUpper() == "Y" || Util.Str(loc_payroll_flag).ToUpper() == "N")
            {
                //         next sentence;
            }
            else
            {
                err_ind = 8;
                //    perform za0-common-error        thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                //       go to va0-acpt-payroll-flag.;
                await va0_acpt_payroll_flag();
                return;
            }
        }

        private async Task va0_99_exit()
        {

            //     exit.;
        }

        private async Task az0_end_of_job()
        {

            //     display blank-screen.;
            Display("blank-screen.");

            //     close  loc-mstr;
            //            audit-file.;

            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            sys_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            sys_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            sys_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;

            //     display scr-closing-screen.;
            Display("scr-closing-screen.");
            //     display confirm.;
            Display("confirm.");

            //     call program "menu".;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private async Task az0_99_exit()
        {

            //     exit.;
        }

        private async Task za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
            Display("blank-line-24.");
            Display("err-msg-line.");
            Display("scr-confirm");
            await Prompt("confirm_space");

            //     display blank-line-24.;
            Display("blank-line-24.");
        }

        private async Task za0_99_exit()
        {

            //     exit.;
        }

        private async Task zb0_dump_file_rec_cntrs()
        {

        }

        private async Task zb0_99_exit()
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

        private async Task initialize_screen_variables()
        {
            loc_nbr = string.Empty;
            loc_name = string.Empty;
            loc_clinic_nbr = 0;
            loc_hospital_nbr = 0;
            loc_hospital_code = string.Empty;
            loc_ministry_loc_code = 0;
            loc_in_out_ind = string.Empty;
            loc_payroll_flag = string.Empty;
            loc_active_for_entry = string.Empty;
            loc_service_location_indicator = string.Empty;
            flag = string.Empty;
            
        }

        private async Task assign_location_master_to_variables() 
        {
            loc_nbr = Util.Str(objLoc_mstr_rec.LOC_NBR);
            loc_name = Util.Str(objLoc_mstr_rec.LOC_NAME);
            loc_clinic_nbr = Util.NumInt(objLoc_mstr_rec.LOC_CLINIC_NBR);
            loc_hospital_nbr = Util.NumInt(objLoc_mstr_rec.LOC_HOSPITAL_NBR);
            loc_hospital_code = Util.Str(objLoc_mstr_rec.LOC_HOSPITAL_CODE);
            loc_ministry_loc_code = Util.NumInt(objLoc_mstr_rec.LOC_MINISTRY_LOC_CODE);
            loc_in_out_ind = Util.Str(objLoc_mstr_rec.LOC_CARD_COLOUR);
            loc_payroll_flag = Util.Str(objLoc_mstr_rec.LOC_PAYROLL_FLAG);
            loc_active_for_entry = Util.Str(objLoc_mstr_rec.LOC_ACTIVE_FOR_ENTRY);
            loc_service_location_indicator = Util.Str(objLoc_mstr_rec.LOC_SERVICE_LOCATION_INDICATOR); 
        }

        private async Task  assign_variables_to_location_master()
        {            
            objLoc_mstr_rec.LOC_NBR = Util.Str(loc_nbr);
            objLoc_mstr_rec.LOC_NAME = Util.Str(loc_name);
            objLoc_mstr_rec.LOC_CLINIC_NBR = Util.NumInt(loc_clinic_nbr);
            objLoc_mstr_rec.LOC_HOSPITAL_NBR = Util.NumInt(loc_hospital_nbr);
            objLoc_mstr_rec.LOC_HOSPITAL_CODE = Util.Str(loc_hospital_code);
            objLoc_mstr_rec.LOC_MINISTRY_LOC_CODE = Util.NumInt(loc_ministry_loc_code);
            objLoc_mstr_rec.LOC_CARD_COLOUR = Util.Str(loc_in_out_ind);
            objLoc_mstr_rec.LOC_PAYROLL_FLAG = Util.Str(loc_payroll_flag);
            objLoc_mstr_rec.LOC_ACTIVE_FOR_ENTRY = Util.Str(loc_active_for_entry);
            objLoc_mstr_rec.LOC_SERVICE_LOCATION_INDICATOR = Util.Str(loc_service_location_indicator);
        }

        #endregion

        public async Task destroy_objects()
        {
            objobjAudit_File = null;
            objLoc_mstr_rec = null;         
        }
    }
}

