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

    public delegate void ExitCobolScreen();

    public class M090ViewModel : CommonFunctionScr
    {

        public event ExitCobolScreen ExitCobol;

        public M090ViewModel()
        {
            _const_con_nbr = new ObservableCollection<int>();
            const_con_nbr = new ObservableCollection<int>();

            _const_nx_avail_pat = new ObservableCollection<int>();
            const_nx_avail_pat = new ObservableCollection<int>();
        }

        #region FD Section
        // FD: audit_file
        private Audit_record objAudit_record = null;
        private ObservableCollection<Audit_record> Audit_record_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_1.ws
        private CONSTANTS_MSTR_REC_1 objConstants_mstr_rec_1 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_1> Constants_mstr_rec_1_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_2.ws
        private CONSTANTS_MSTR_REC_2 objConstants_mstr_rec_2 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_2> Constants_mstr_rec_2_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_3.ws
        private CONSTANTS_MSTR_REC_3 objConstants_mstr_rec_3 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_3> Constants_mstr_rec_3_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_4.ws
        private CONSTANTS_MSTR_REC_4 objConstants_mstr_rec_4 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_4> Constants_mstr_rec_4_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_5.ws
        private CONSTANTS_MSTR_REC_5 objConstants_mstr_rec_5 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_5> Constants_mstr_rec_5_Collection;

        private CONSTANTS_MSTR_REC_6 objConstants_mstr_rec_6 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_6> Constants_mstr_rec_6_Collection;

        private CONSTANTS_MSTR_REC_7 objConstants_mstr_rec_7 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_7> Constants_mstr_rec_7_Collection;

        private WriteFile objAudit_File = null;


        #endregion

        #region Properties
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

        private string _ws_const_mstr_ident;
        public string ws_const_mstr_ident
        {
            get
            {
                return _ws_const_mstr_ident;
            }
            set
            {
                if (_ws_const_mstr_ident != value)
                {
                    _ws_const_mstr_ident = value;
                    _ws_const_mstr_ident = _ws_const_mstr_ident.ToUpper();
                    RaisePropertyChanged("ws_const_mstr_ident");
                }
            }
        }

        private string __sys_yy;
        public string sys_yy
        {
            get
            {
                return __sys_yy;
            }
            set
            {
                if (__sys_yy != value)
                {
                    __sys_yy = value;
                    RaisePropertyChanged("sys_yy");
                }
            }
        }

        private string __sys_mm;
        public string sys_mm
        {
            get
            {
                return __sys_mm;
            }
            set
            {
                if (__sys_mm != value)
                {
                    __sys_mm = value;
                    RaisePropertyChanged("sys_mm");
                }
            }
        }

        private string __sys_dd;
        public string sys_dd
        {
            get
            {
                return __sys_dd;
            }
            set
            {
                if (__sys_dd != value)
                {
                    __sys_dd = value;
                    RaisePropertyChanged("sys_dd");
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

        private string __flag;
        public string flag
        {
            get
            {
                return __flag;
            }
            set
            {
                if (__flag != value)
                {
                    __flag = value;
                    __flag = __flag.ToUpper();
                    RaisePropertyChanged("flag");
                }
            }
        }

        private string _ws_entered_password;
        public string ws_entered_password
        {
            get
            {
                return _ws_entered_password;
            }
            set
            {
                if (_ws_entered_password != value)
                {
                    _ws_entered_password = value;
                    _ws_entered_password = _ws_entered_password.ToUpper();
                    RaisePropertyChanged("ws_entered_password");
                }
            }
        }

        private int _ctr_const_mstr_reads;
        public int ctr_const_mstr_reads
        {
            get
            {
                return _ctr_const_mstr_reads;
            }
            set
            {
                if (_ctr_const_mstr_reads != value)
                {
                    _ctr_const_mstr_reads = value;
                    RaisePropertyChanged("ctr_const_mstr_reads");
                }
            }
        }

        private int _ctr_const_mstr_changes;
        public int ctr_const_mstr_changes
        {
            get
            {
                return _ctr_const_mstr_changes;
            }
            set
            {
                if (_ctr_const_mstr_changes != value)
                {
                    _ctr_const_mstr_changes = value;
                    RaisePropertyChanged("ctr_const_mstr_changes");
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

        private string _print_file_name = "rm090";
        public string print_file_name
        {
            get
            {
                return _print_file_name;
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

        private int _const_max_nbr_clinics;
        public int const_max_nbr_clinics
        {
            get
            {
                return _const_max_nbr_clinics;
            }
            set
            {
                if (_const_max_nbr_clinics != value)
                {
                    _const_max_nbr_clinics = value;
                    RaisePropertyChanged("const_max_nbr_clinics");
                }
            }
        }

        private int _const_clinic_1_2_nbr_1;
        public int const_clinic_1_2_nbr_1
        {
            get
            {
                return _const_clinic_1_2_nbr_1;
            }
            set
            {
                if (_const_clinic_1_2_nbr_1 != value)
                {
                    _const_clinic_1_2_nbr_1 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_1");
                }
            }
        }

        private string _const_clinic_nbr_1;
        public string const_clinic_nbr_1
        {
            get
            {
                return _const_clinic_nbr_1;
            }
            set
            {
                if (_const_clinic_nbr_1 != value)
                {
                    _const_clinic_nbr_1 = value;
                    _const_clinic_nbr_1 = _const_clinic_nbr_1.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_1");
                }
            }
        }

        private int _const_clinic_1_2_nbr_2;
        public int const_clinic_1_2_nbr_2
        {
            get
            {
                return _const_clinic_1_2_nbr_2;
            }
            set
            {
                if (_const_clinic_1_2_nbr_2 != value)
                {
                    _const_clinic_1_2_nbr_2 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_2");
                }
            }
        }

        private string _const_clinic_nbr_2;
        public string const_clinic_nbr_2
        {
            get
            {
                return _const_clinic_nbr_2;
            }
            set
            {
                if (_const_clinic_nbr_2 != value)
                {
                    _const_clinic_nbr_2 = value;
                    _const_clinic_nbr_2 = _const_clinic_nbr_2.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_2");
                }
            }
        }

        private int _const_clinic_1_2_nbr_3;
        public int const_clinic_1_2_nbr_3
        {
            get
            {
                return _const_clinic_1_2_nbr_3;
            }
            set
            {
                if (_const_clinic_1_2_nbr_3 != value)
                {
                    _const_clinic_1_2_nbr_3 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_3");
                }
            }
        }

        private string _const_clinic_nbr_3;
        public string const_clinic_nbr_3
        {
            get
            {
                return _const_clinic_nbr_3;
            }
            set
            {
                if (_const_clinic_nbr_3 != value)
                {
                    _const_clinic_nbr_3 = value;
                    _const_clinic_nbr_3 = _const_clinic_nbr_3.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_3");
                }
            }
        }

        private int _const_clinic_1_2_nbr_4;
        public int const_clinic_1_2_nbr_4
        {
            get
            {
                return _const_clinic_1_2_nbr_4;
            }
            set
            {
                if (_const_clinic_1_2_nbr_4 != value)
                {
                    _const_clinic_1_2_nbr_4 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_4");
                }
            }
        }

        private string _const_clinic_nbr_4;
        public string const_clinic_nbr_4
        {
            get
            {
                return _const_clinic_nbr_4;
            }
            set
            {
                if (_const_clinic_nbr_4 != value)
                {
                    _const_clinic_nbr_4 = value;
                    _const_clinic_nbr_4 = _const_clinic_nbr_4.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_4");
                }
            }
        }

        private int _const_clinic_1_2_nbr_5;
        public int const_clinic_1_2_nbr_5
        {
            get
            {
                return _const_clinic_1_2_nbr_5;
            }
            set
            {
                if (_const_clinic_1_2_nbr_5 != value)
                {
                    _const_clinic_1_2_nbr_5 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_5");
                }
            }
        }

        private string _const_clinic_nbr_5;
        public string const_clinic_nbr_5
        {
            get
            {
                return _const_clinic_nbr_5;
            }
            set
            {
                if (_const_clinic_nbr_5 != value)
                {
                    _const_clinic_nbr_5 = value;
                    _const_clinic_nbr_5 = _const_clinic_nbr_5.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_5");
                }
            }
        }

        private int _const_clinic_1_2_nbr_6;
        public int const_clinic_1_2_nbr_6
        {
            get
            {
                return _const_clinic_1_2_nbr_6;
            }
            set
            {
                if (_const_clinic_1_2_nbr_6 != value)
                {
                    _const_clinic_1_2_nbr_6 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_6");
                }
            }
        }

        private string _const_clinic_nbr_6;
        public string const_clinic_nbr_6
        {
            get
            {
                return _const_clinic_nbr_6;
            }
            set
            {
                if (_const_clinic_nbr_6 != value)
                {
                    _const_clinic_nbr_6 = value;
                    _const_clinic_nbr_6 = _const_clinic_nbr_6.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_6");
                }
            }
        }

        private int _const_clinic_1_2_nbr_7;
        public int const_clinic_1_2_nbr_7
        {
            get
            {
                return _const_clinic_1_2_nbr_7;
            }
            set
            {
                if (_const_clinic_1_2_nbr_7 != value)
                {
                    _const_clinic_1_2_nbr_7 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_7");
                }
            }
        }

        private string _const_clinic_nbr_7;
        public string const_clinic_nbr_7
        {
            get
            {
                return _const_clinic_nbr_7;
            }
            set
            {
                if (_const_clinic_nbr_7 != value)
                {
                    _const_clinic_nbr_7 = value;
                    _const_clinic_nbr_7 = _const_clinic_nbr_7.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_7");
                }
            }
        }

        private int _const_clinic_1_2_nbr_8;
        public int const_clinic_1_2_nbr_8
        {
            get
            {
                return _const_clinic_1_2_nbr_8;
            }
            set
            {
                if (_const_clinic_1_2_nbr_8 != value)
                {
                    _const_clinic_1_2_nbr_8 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_8");
                }
            }
        }

        private string _const_clinic_nbr_8;
        public string const_clinic_nbr_8
        {
            get
            {
                return _const_clinic_nbr_8;
            }
            set
            {
                if (_const_clinic_nbr_8 != value)
                {
                    _const_clinic_nbr_8 = value;
                    _const_clinic_nbr_8 = _const_clinic_nbr_8.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_8");
                }
            }
        }

        private int _const_clinic_1_2_nbr_9;
        public int const_clinic_1_2_nbr_9
        {
            get
            {
                return _const_clinic_1_2_nbr_9;
            }
            set
            {
                if (_const_clinic_1_2_nbr_9 != value)
                {
                    _const_clinic_1_2_nbr_9 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_9");
                }
            }
        }

        private string _const_clinic_nbr_9;
        public string const_clinic_nbr_9
        {
            get
            {
                return _const_clinic_nbr_9;
            }
            set
            {
                if (_const_clinic_nbr_9 != value)
                {
                    _const_clinic_nbr_9 = value;
                    _const_clinic_nbr_9 = _const_clinic_nbr_9.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_9");
                }
            }
        }

        private int _const_clinic_1_2_nbr_10;
        public int const_clinic_1_2_nbr_10
        {
            get
            {
                return _const_clinic_1_2_nbr_10;
            }
            set
            {
                if (_const_clinic_1_2_nbr_10 != value)
                {
                    _const_clinic_1_2_nbr_10 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_10");
                }
            }
        }

        private string _const_clinic_nbr_10;
        public string const_clinic_nbr_10
        {
            get
            {
                return _const_clinic_nbr_10;
            }
            set
            {
                if (_const_clinic_nbr_10 != value)
                {
                    _const_clinic_nbr_10 = value;
                    _const_clinic_nbr_10 = _const_clinic_nbr_10.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_10");
                }
            }
        }

        private int _const_clinic_1_2_nbr_11;
        public int const_clinic_1_2_nbr_11
        {
            get
            {
                return _const_clinic_1_2_nbr_11;
            }
            set
            {
                if (_const_clinic_1_2_nbr_11 != value)
                {
                    _const_clinic_1_2_nbr_11 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_11");
                }
            }
        }

        private string _const_clinic_nbr_11;
        public string const_clinic_nbr_11
        {
            get
            {
                return _const_clinic_nbr_11;
            }
            set
            {
                if (_const_clinic_nbr_11 != value)
                {
                    _const_clinic_nbr_11 = value;
                    _const_clinic_nbr_11 = _const_clinic_nbr_11.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_11");
                }
            }
        }

        private int _const_clinic_1_2_nbr_12;
        public int const_clinic_1_2_nbr_12
        {
            get
            {
                return _const_clinic_1_2_nbr_12;
            }
            set
            {
                if (_const_clinic_1_2_nbr_12 != value)
                {
                    _const_clinic_1_2_nbr_12 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_12");
                }
            }
        }

        private string _const_clinic_nbr_12;
        public string const_clinic_nbr_12
        {
            get
            {
                return _const_clinic_nbr_12;
            }
            set
            {
                if (_const_clinic_nbr_12 != value)
                {
                    _const_clinic_nbr_12 = value;
                    _const_clinic_nbr_12 = _const_clinic_nbr_12.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_12");
                }
            }
        }

        private int _const_clinic_1_2_nbr_13;
        public int const_clinic_1_2_nbr_13
        {
            get
            {
                return _const_clinic_1_2_nbr_13;
            }
            set
            {
                if (_const_clinic_1_2_nbr_13 != value)
                {
                    _const_clinic_1_2_nbr_13 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_13");
                }
            }
        }

        private string _const_clinic_nbr_13;
        public string const_clinic_nbr_13
        {
            get
            {
                return _const_clinic_nbr_13;
            }
            set
            {
                if (_const_clinic_nbr_13 != value)
                {
                    _const_clinic_nbr_13 = value;
                    _const_clinic_nbr_13 = _const_clinic_nbr_13.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_13");
                }
            }
        }

        private int _const_clinic_1_2_nbr_14;
        public int const_clinic_1_2_nbr_14
        {
            get
            {
                return _const_clinic_1_2_nbr_14;
            }
            set
            {
                if (_const_clinic_1_2_nbr_14 != value)
                {
                    _const_clinic_1_2_nbr_14 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_14");
                }
            }
        }

        private string _const_clinic_nbr_14;
        public string const_clinic_nbr_14
        {
            get
            {
                return _const_clinic_nbr_14;
            }
            set
            {
                if (_const_clinic_nbr_14 != value)
                {
                    _const_clinic_nbr_14 = value;
                    _const_clinic_nbr_14 = _const_clinic_nbr_14.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_14");
                }
            }
        }

        private int _const_clinic_1_2_nbr_15;
        public int const_clinic_1_2_nbr_15
        {
            get
            {
                return _const_clinic_1_2_nbr_15;
            }
            set
            {
                if (_const_clinic_1_2_nbr_15 != value)
                {
                    _const_clinic_1_2_nbr_15 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_15");
                }
            }
        }

        private string _const_clinic_nbr_15;
        public string const_clinic_nbr_15
        {
            get
            {
                return _const_clinic_nbr_15;
            }
            set
            {
                if (_const_clinic_nbr_15 != value)
                {
                    _const_clinic_nbr_15 = value;
                    _const_clinic_nbr_15 = _const_clinic_nbr_15.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_15");
                }
            }
        }

        private int _const_clinic_1_2_nbr_16;
        public int const_clinic_1_2_nbr_16
        {
            get
            {
                return _const_clinic_1_2_nbr_16;
            }
            set
            {
                if (_const_clinic_1_2_nbr_16 != value)
                {
                    _const_clinic_1_2_nbr_16 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_16");
                }
            }
        }

        private string _const_clinic_nbr_16;
        public string const_clinic_nbr_16
        {
            get
            {
                return _const_clinic_nbr_16;
            }
            set
            {
                if (_const_clinic_nbr_16 != value)
                {
                    _const_clinic_nbr_16 = value;
                    _const_clinic_nbr_16 = _const_clinic_nbr_16.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_16");
                }
            }
        }

        private int _const_clinic_1_2_nbr_17;
        public int const_clinic_1_2_nbr_17
        {
            get
            {
                return _const_clinic_1_2_nbr_17;
            }
            set
            {
                if (_const_clinic_1_2_nbr_17 != value)
                {
                    _const_clinic_1_2_nbr_17 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_17");
                }
            }
        }

        private string _const_clinic_nbr_17;
        public string const_clinic_nbr_17
        {
            get
            {
                return _const_clinic_nbr_17;
            }
            set
            {
                if (_const_clinic_nbr_17 != value)
                {
                    _const_clinic_nbr_17 = value;
                    _const_clinic_nbr_17 = _const_clinic_nbr_17.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_17");
                }
            }
        }

        private int _const_clinic_1_2_nbr_18;
        public int const_clinic_1_2_nbr_18
        {
            get
            {
                return _const_clinic_1_2_nbr_18;
            }
            set
            {
                if (_const_clinic_1_2_nbr_18 != value)
                {
                    _const_clinic_1_2_nbr_18 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_18");
                }
            }
        }

        private string _const_clinic_nbr_18;
        public string const_clinic_nbr_18
        {
            get
            {
                return _const_clinic_nbr_18;
            }
            set
            {
                if (_const_clinic_nbr_18 != value)
                {
                    _const_clinic_nbr_18 = value;
                    _const_clinic_nbr_18 = _const_clinic_nbr_18.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_18");
                }
            }
        }

        private int _const_clinic_1_2_nbr_19;
        public int const_clinic_1_2_nbr_19
        {
            get
            {
                return _const_clinic_1_2_nbr_19;
            }
            set
            {
                if (_const_clinic_1_2_nbr_19 != value)
                {
                    _const_clinic_1_2_nbr_19 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_19");
                }
            }
        }

        private string _const_clinic_nbr_19;
        public string const_clinic_nbr_19
        {
            get
            {
                return _const_clinic_nbr_19;
            }
            set
            {
                if (_const_clinic_nbr_19 != value)
                {
                    _const_clinic_nbr_19 = value;
                    _const_clinic_nbr_19 = _const_clinic_nbr_19.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_19");
                }
            }
        }

        private int _const_clinic_1_2_nbr_20;
        public int const_clinic_1_2_nbr_20
        {
            get
            {
                return _const_clinic_1_2_nbr_20;
            }
            set
            {
                if (_const_clinic_1_2_nbr_20 != value)
                {
                    _const_clinic_1_2_nbr_20 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_20");
                }
            }
        }

        private string _const_clinic_nbr_20;
        public string const_clinic_nbr_20
        {
            get
            {
                return _const_clinic_nbr_20;
            }
            set
            {
                if (_const_clinic_nbr_20 != value)
                {
                    _const_clinic_nbr_20 = value;
                    _const_clinic_nbr_20 = _const_clinic_nbr_20.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_20");
                }
            }
        }

        private int _const_clinic_1_2_nbr_21;
        public int const_clinic_1_2_nbr_21
        {
            get
            {
                return _const_clinic_1_2_nbr_21;
            }
            set
            {
                if (_const_clinic_1_2_nbr_21 != value)
                {
                    _const_clinic_1_2_nbr_21 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_21");
                }
            }
        }

        private string _const_clinic_nbr_21;
        public string const_clinic_nbr_21
        {
            get
            {
                return _const_clinic_nbr_21;
            }
            set
            {
                if (_const_clinic_nbr_21 != value)
                {
                    _const_clinic_nbr_21 = value;
                    _const_clinic_nbr_21 = _const_clinic_nbr_21.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_21");
                }
            }
        }

        private int _const_clinic_1_2_nbr_22;
        public int const_clinic_1_2_nbr_22
        {
            get
            {
                return _const_clinic_1_2_nbr_22;
            }
            set
            {
                if (_const_clinic_1_2_nbr_22 != value)
                {
                    _const_clinic_1_2_nbr_22 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_22");
                }
            }
        }

        private string _const_clinic_nbr_22;
        public string const_clinic_nbr_22
        {
            get
            {
                return _const_clinic_nbr_22;
            }
            set
            {
                if (_const_clinic_nbr_22 != value)
                {
                    _const_clinic_nbr_22 = value;
                    _const_clinic_nbr_22 = _const_clinic_nbr_22.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_22");
                }
            }
        }

        private int _const_clinic_1_2_nbr_23;
        public int const_clinic_1_2_nbr_23
        {
            get
            {
                return _const_clinic_1_2_nbr_23;
            }
            set
            {
                if (_const_clinic_1_2_nbr_23 != value)
                {
                    _const_clinic_1_2_nbr_23 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_23");
                }
            }
        }

        private string _const_clinic_nbr_23;
        public string const_clinic_nbr_23
        {
            get
            {
                return _const_clinic_nbr_23;
            }
            set
            {
                if (_const_clinic_nbr_23 != value)
                {
                    _const_clinic_nbr_23 = value;
                    _const_clinic_nbr_23 = _const_clinic_nbr_23.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_23");
                }
            }
        }

        private int _const_clinic_1_2_nbr_24;
        public int const_clinic_1_2_nbr_24
        {
            get
            {
                return _const_clinic_1_2_nbr_24;
            }
            set
            {
                if (_const_clinic_1_2_nbr_24 != value)
                {
                    _const_clinic_1_2_nbr_24 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_24");
                }
            }
        }

        private string _const_clinic_nbr_24;
        public string const_clinic_nbr_24
        {
            get
            {
                return _const_clinic_nbr_24;
            }
            set
            {
                if (_const_clinic_nbr_24 != value)
                {
                    _const_clinic_nbr_24 = value;
                    _const_clinic_nbr_24 = _const_clinic_nbr_24.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_24");
                }
            }
        }

        private int _const_clinic_1_2_nbr_25;
        public int const_clinic_1_2_nbr_25
        {
            get
            {
                return _const_clinic_1_2_nbr_25;
            }
            set
            {
                if (_const_clinic_1_2_nbr_25 != value)
                {
                    _const_clinic_1_2_nbr_25 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_25");
                }
            }
        }

        private string _const_clinic_nbr_25;
        public string const_clinic_nbr_25
        {
            get
            {
                return _const_clinic_nbr_25;
            }
            set
            {
                if (_const_clinic_nbr_25 != value)
                {
                    _const_clinic_nbr_25 = value;
                    _const_clinic_nbr_25 = _const_clinic_nbr_25.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_25");
                }
            }
        }

        private int _const_clinic_1_2_nbr_26;
        public int const_clinic_1_2_nbr_26
        {
            get
            {
                return _const_clinic_1_2_nbr_26;
            }
            set
            {
                if (_const_clinic_1_2_nbr_26 != value)
                {
                    _const_clinic_1_2_nbr_26 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_26");
                }
            }
        }

        private string _const_clinic_nbr_26;
        public string const_clinic_nbr_26
        {
            get
            {
                return _const_clinic_nbr_26;
            }
            set
            {
                if (_const_clinic_nbr_26 != value)
                {
                    _const_clinic_nbr_26 = value;
                    _const_clinic_nbr_26 = _const_clinic_nbr_26.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_26");
                }
            }
        }

        private int _const_clinic_1_2_nbr_27;
        public int const_clinic_1_2_nbr_27
        {
            get
            {
                return _const_clinic_1_2_nbr_27;
            }
            set
            {
                if (_const_clinic_1_2_nbr_27 != value)
                {
                    _const_clinic_1_2_nbr_27 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_27");
                }
            }
        }

        private string _const_clinic_nbr_27;
        public string const_clinic_nbr_27
        {
            get
            {
                return _const_clinic_nbr_27;
            }
            set
            {
                if (_const_clinic_nbr_27 != value)
                {
                    _const_clinic_nbr_27 = value;
                    _const_clinic_nbr_27 = _const_clinic_nbr_27.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_27");
                }
            }
        }

        private int _const_clinic_1_2_nbr_28;
        public int const_clinic_1_2_nbr_28
        {
            get
            {
                return _const_clinic_1_2_nbr_28;
            }
            set
            {
                if (_const_clinic_1_2_nbr_28 != value)
                {
                    _const_clinic_1_2_nbr_28 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_28");
                }
            }
        }

        private string _const_clinic_nbr_28;
        public string const_clinic_nbr_28
        {
            get
            {
                return _const_clinic_nbr_28;
            }
            set
            {
                if (_const_clinic_nbr_28 != value)
                {
                    _const_clinic_nbr_28 = value;
                    _const_clinic_nbr_28 = _const_clinic_nbr_28.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_28");
                }
            }
        }

        private int _const_clinic_1_2_nbr_29;
        public int const_clinic_1_2_nbr_29
        {
            get
            {
                return _const_clinic_1_2_nbr_29;
            }
            set
            {
                if (_const_clinic_1_2_nbr_29 != value)
                {
                    _const_clinic_1_2_nbr_29 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_29");
                }
            }
        }

        private string _const_clinic_nbr_29;
        public string const_clinic_nbr_29
        {
            get
            {
                return _const_clinic_nbr_29;
            }
            set
            {
                if (_const_clinic_nbr_29 != value)
                {
                    _const_clinic_nbr_29 = value;
                    _const_clinic_nbr_29 = _const_clinic_nbr_29.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_29");
                }
            }
        }

        private int _const_clinic_1_2_nbr_30;
        public int const_clinic_1_2_nbr_30
        {
            get
            {
                return _const_clinic_1_2_nbr_30;
            }
            set
            {
                if (_const_clinic_1_2_nbr_30 != value)
                {
                    _const_clinic_1_2_nbr_30 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_30");
                }
            }
        }

        private string _const_clinic_nbr_30;
        public string const_clinic_nbr_30
        {
            get
            {
                return _const_clinic_nbr_30;
            }
            set
            {
                if (_const_clinic_nbr_30 != value)
                {
                    _const_clinic_nbr_30 = value;
                    _const_clinic_nbr_30 = _const_clinic_nbr_30.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_30");
                }
            }
        }

        private int _const_clinic_1_2_nbr_31;
        public int const_clinic_1_2_nbr_31
        {
            get
            {
                return _const_clinic_1_2_nbr_31;
            }
            set
            {
                if (_const_clinic_1_2_nbr_31 != value)
                {
                    _const_clinic_1_2_nbr_31 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_31");
                }
            }
        }

        private string _const_clinic_nbr_31;
        public string const_clinic_nbr_31
        {
            get
            {
                return _const_clinic_nbr_31;
            }
            set
            {
                if (_const_clinic_nbr_31 != value)
                {
                    _const_clinic_nbr_31 = value;
                    _const_clinic_nbr_31 = _const_clinic_nbr_31.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_31");
                }
            }
        }

        private int _const_clinic_1_2_nbr_32;
        public int const_clinic_1_2_nbr_32
        {
            get
            {
                return _const_clinic_1_2_nbr_32;
            }
            set
            {
                if (_const_clinic_1_2_nbr_32 != value)
                {
                    _const_clinic_1_2_nbr_32 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_32");
                }
            }
        }

        private string _const_clinic_nbr_32;
        public string const_clinic_nbr_32
        {
            get
            {
                return _const_clinic_nbr_32;
            }
            set
            {
                if (_const_clinic_nbr_32 != value)
                {
                    _const_clinic_nbr_32 = value;
                    _const_clinic_nbr_32 = _const_clinic_nbr_32.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_32");
                }
            }
        }

        private int _const_clinic_1_2_nbr_33;
        public int const_clinic_1_2_nbr_33
        {
            get
            {
                return _const_clinic_1_2_nbr_33;
            }
            set
            {
                if (_const_clinic_1_2_nbr_33 != value)
                {
                    _const_clinic_1_2_nbr_33 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_33");
                }
            }
        }

        private string _const_clinic_nbr_33;
        public string const_clinic_nbr_33
        {
            get
            {
                return _const_clinic_nbr_33;
            }
            set
            {
                if (_const_clinic_nbr_33 != value)
                {
                    _const_clinic_nbr_33 = value;
                    _const_clinic_nbr_33 = _const_clinic_nbr_33.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_33");
                }
            }
        }

        private int _const_clinic_1_2_nbr_34;
        public int const_clinic_1_2_nbr_34
        {
            get
            {
                return _const_clinic_1_2_nbr_34;
            }
            set
            {
                if (_const_clinic_1_2_nbr_34 != value)
                {
                    _const_clinic_1_2_nbr_34 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_34");
                }
            }
        }

        private string _const_clinic_nbr_34;
        public string const_clinic_nbr_34
        {
            get
            {
                return _const_clinic_nbr_34;
            }
            set
            {
                if (_const_clinic_nbr_34 != value)
                {
                    _const_clinic_nbr_34 = value;
                    _const_clinic_nbr_34 = _const_clinic_nbr_34.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_34");
                }
            }
        }

        private int _const_clinic_1_2_nbr_35;
        public int const_clinic_1_2_nbr_35
        {
            get
            {
                return _const_clinic_1_2_nbr_35;
            }
            set
            {
                if (_const_clinic_1_2_nbr_35 != value)
                {
                    _const_clinic_1_2_nbr_35 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_35");
                }
            }
        }

        private string _const_clinic_nbr_35;
        public string const_clinic_nbr_35
        {
            get
            {
                return _const_clinic_nbr_35;
            }
            set
            {
                if (_const_clinic_nbr_35 != value)
                {
                    _const_clinic_nbr_35 = value;
                    _const_clinic_nbr_35 = _const_clinic_nbr_35.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_35");
                }
            }
        }

        private int _const_clinic_1_2_nbr_36;
        public int const_clinic_1_2_nbr_36
        {
            get
            {
                return _const_clinic_1_2_nbr_36;
            }
            set
            {
                if (_const_clinic_1_2_nbr_36 != value)
                {
                    _const_clinic_1_2_nbr_36 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_36");
                }
            }
        }

        private string _const_clinic_nbr_36;
        public string const_clinic_nbr_36
        {
            get
            {
                return _const_clinic_nbr_36;
            }
            set
            {
                if (_const_clinic_nbr_36 != value)
                {
                    _const_clinic_nbr_36 = value;
                    _const_clinic_nbr_36 = _const_clinic_nbr_36.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_36");
                }
            }
        }

        private int _const_clinic_1_2_nbr_37;
        public int const_clinic_1_2_nbr_37
        {
            get
            {
                return _const_clinic_1_2_nbr_37;
            }
            set
            {
                if (_const_clinic_1_2_nbr_37 != value)
                {
                    _const_clinic_1_2_nbr_37 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_37");
                }
            }
        }

        private string _const_clinic_nbr_37;
        public string const_clinic_nbr_37
        {
            get
            {
                return _const_clinic_nbr_37;
            }
            set
            {
                if (_const_clinic_nbr_37 != value)
                {
                    _const_clinic_nbr_37 = value;
                    _const_clinic_nbr_37 = _const_clinic_nbr_37.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_37");
                }
            }
        }

        private int _const_clinic_1_2_nbr_38;
        public int const_clinic_1_2_nbr_38
        {
            get
            {
                return _const_clinic_1_2_nbr_38;
            }
            set
            {
                if (_const_clinic_1_2_nbr_38 != value)
                {
                    _const_clinic_1_2_nbr_38 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_38");
                }
            }
        }

        private string _const_clinic_nbr_38;
        public string const_clinic_nbr_38
        {
            get
            {
                return _const_clinic_nbr_38;
            }
            set
            {
                if (_const_clinic_nbr_38 != value)
                {
                    _const_clinic_nbr_38 = value;
                    _const_clinic_nbr_38 = _const_clinic_nbr_38.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_38");
                }
            }
        }

        private int _const_clinic_1_2_nbr_39;
        public int const_clinic_1_2_nbr_39
        {
            get
            {
                return _const_clinic_1_2_nbr_39;
            }
            set
            {
                if (_const_clinic_1_2_nbr_39 != value)
                {
                    _const_clinic_1_2_nbr_39 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_39");
                }
            }
        }

        private string _const_clinic_nbr_39;
        public string const_clinic_nbr_39
        {
            get
            {
                return _const_clinic_nbr_39;
            }
            set
            {
                if (_const_clinic_nbr_39 != value)
                {
                    _const_clinic_nbr_39 = value;
                    _const_clinic_nbr_39 = _const_clinic_nbr_39.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_39");
                }
            }
        }

        private int _const_clinic_1_2_nbr_40;
        public int const_clinic_1_2_nbr_40
        {
            get
            {
                return _const_clinic_1_2_nbr_40;
            }
            set
            {
                if (_const_clinic_1_2_nbr_40 != value)
                {
                    _const_clinic_1_2_nbr_40 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_40");
                }
            }
        }

        private string _const_clinic_nbr_40;
        public string const_clinic_nbr_40
        {
            get
            {
                return _const_clinic_nbr_40;
            }
            set
            {
                if (_const_clinic_nbr_40 != value)
                {
                    _const_clinic_nbr_40 = value;
                    _const_clinic_nbr_40 = _const_clinic_nbr_40.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_40");
                }
            }
        }

        private int _const_clinic_1_2_nbr_41;
        public int const_clinic_1_2_nbr_41
        {
            get
            {
                return _const_clinic_1_2_nbr_41;
            }
            set
            {
                if (_const_clinic_1_2_nbr_41 != value)
                {
                    _const_clinic_1_2_nbr_41 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_41");
                }
            }
        }

        private string _const_clinic_nbr_41;
        public string const_clinic_nbr_41
        {
            get
            {
                return _const_clinic_nbr_41;
            }
            set
            {
                if (_const_clinic_nbr_41 != value)
                {
                    _const_clinic_nbr_41 = value;
                    _const_clinic_nbr_41 = _const_clinic_nbr_41.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_41");
                }
            }
        }

        private int _const_clinic_1_2_nbr_42;
        public int const_clinic_1_2_nbr_42
        {
            get
            {
                return _const_clinic_1_2_nbr_42;
            }
            set
            {
                if (_const_clinic_1_2_nbr_42 != value)
                {
                    _const_clinic_1_2_nbr_42 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_42");
                }
            }
        }

        private string _const_clinic_nbr_42;
        public string const_clinic_nbr_42
        {
            get
            {
                return _const_clinic_nbr_42;
            }
            set
            {
                if (_const_clinic_nbr_42 != value)
                {
                    _const_clinic_nbr_42 = value;
                    _const_clinic_nbr_42 = _const_clinic_nbr_42.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_42");
                }
            }
        }

        private int _const_clinic_1_2_nbr_43;
        public int const_clinic_1_2_nbr_43
        {
            get
            {
                return _const_clinic_1_2_nbr_43;
            }
            set
            {
                if (_const_clinic_1_2_nbr_43 != value)
                {
                    _const_clinic_1_2_nbr_43 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_43");
                }
            }
        }

        private string _const_clinic_nbr_43;
        public string const_clinic_nbr_43
        {
            get
            {
                return _const_clinic_nbr_43;
            }
            set
            {
                if (_const_clinic_nbr_43 != value)
                {
                    _const_clinic_nbr_43 = value;
                    _const_clinic_nbr_43 = _const_clinic_nbr_43.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_43");
                }
            }
        }

        private int _const_clinic_1_2_nbr_44;
        public int const_clinic_1_2_nbr_44
        {
            get
            {
                return _const_clinic_1_2_nbr_44;
            }
            set
            {
                if (_const_clinic_1_2_nbr_44 != value)
                {
                    _const_clinic_1_2_nbr_44 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_44");
                }
            }
        }

        private string _const_clinic_nbr_44;
        public string const_clinic_nbr_44
        {
            get
            {
                return _const_clinic_nbr_44;
            }
            set
            {
                if (_const_clinic_nbr_44 != value)
                {
                    _const_clinic_nbr_44 = value;
                    _const_clinic_nbr_44 = _const_clinic_nbr_44.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_44");
                }
            }
        }

        private int _const_clinic_1_2_nbr_45;
        public int const_clinic_1_2_nbr_45
        {
            get
            {
                return _const_clinic_1_2_nbr_45;
            }
            set
            {
                if (_const_clinic_1_2_nbr_45 != value)
                {
                    _const_clinic_1_2_nbr_45 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_45");
                }
            }
        }

        private string _const_clinic_nbr_45;
        public string const_clinic_nbr_45
        {
            get
            {
                return _const_clinic_nbr_45;
            }
            set
            {
                if (_const_clinic_nbr_45 != value)
                {
                    _const_clinic_nbr_45 = value;
                    _const_clinic_nbr_45 = _const_clinic_nbr_45.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_45");
                }
            }
        }

        private int _const_clinic_1_2_nbr_46;
        public int const_clinic_1_2_nbr_46
        {
            get
            {
                return _const_clinic_1_2_nbr_46;
            }
            set
            {
                if (_const_clinic_1_2_nbr_46 != value)
                {
                    _const_clinic_1_2_nbr_46 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_46");
                }
            }
        }

        private string _const_clinic_nbr_46;
        public string const_clinic_nbr_46
        {
            get
            {
                return _const_clinic_nbr_46;
            }
            set
            {
                if (_const_clinic_nbr_46 != value)
                {
                    _const_clinic_nbr_46 = value;
                    _const_clinic_nbr_46 = _const_clinic_nbr_46.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_46");
                }
            }
        }

        private int _const_clinic_1_2_nbr_47;
        public int const_clinic_1_2_nbr_47
        {
            get
            {
                return _const_clinic_1_2_nbr_47;
            }
            set
            {
                if (_const_clinic_1_2_nbr_47 != value)
                {
                    _const_clinic_1_2_nbr_47 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_47");
                }
            }
        }

        private string _const_clinic_nbr_47;
        public string const_clinic_nbr_47
        {
            get
            {
                return _const_clinic_nbr_47;
            }
            set
            {
                if (_const_clinic_nbr_47 != value)
                {
                    _const_clinic_nbr_47 = value;
                    _const_clinic_nbr_47 = _const_clinic_nbr_47.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_47");
                }
            }
        }

        private int _const_clinic_1_2_nbr_48;
        public int const_clinic_1_2_nbr_48
        {
            get
            {
                return _const_clinic_1_2_nbr_48;
            }
            set
            {
                if (_const_clinic_1_2_nbr_48 != value)
                {
                    _const_clinic_1_2_nbr_48 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_48");
                }
            }
        }

        private string _const_clinic_nbr_48;
        public string const_clinic_nbr_48
        {
            get
            {
                return _const_clinic_nbr_48;
            }
            set
            {
                if (_const_clinic_nbr_48 != value)
                {
                    _const_clinic_nbr_48 = value;
                    _const_clinic_nbr_48 = _const_clinic_nbr_48.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_48");
                }
            }
        }

        private int _const_clinic_1_2_nbr_49;
        public int const_clinic_1_2_nbr_49
        {
            get
            {
                return _const_clinic_1_2_nbr_49;
            }
            set
            {
                if (_const_clinic_1_2_nbr_49 != value)
                {
                    _const_clinic_1_2_nbr_49 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_49");
                }
            }
        }

        private string _const_clinic_nbr_49;
        public string const_clinic_nbr_49
        {
            get
            {
                return _const_clinic_nbr_49;
            }
            set
            {
                if (_const_clinic_nbr_49 != value)
                {
                    _const_clinic_nbr_49 = value;
                    _const_clinic_nbr_49 = _const_clinic_nbr_49.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_49");
                }
            }
        }

        private int _const_clinic_1_2_nbr_50;
        public int const_clinic_1_2_nbr_50
        {
            get
            {
                return _const_clinic_1_2_nbr_50;
            }
            set
            {
                if (_const_clinic_1_2_nbr_50 != value)
                {
                    _const_clinic_1_2_nbr_50 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_50");
                }
            }
        }

        private string _const_clinic_nbr_50;
        public string const_clinic_nbr_50
        {
            get
            {
                return _const_clinic_nbr_50;
            }
            set
            {
                if (_const_clinic_nbr_50 != value)
                {
                    _const_clinic_nbr_50 = value;
                    _const_clinic_nbr_50 = _const_clinic_nbr_50.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_50");
                }
            }
        }

        private int _const_clinic_1_2_nbr_51;
        public int const_clinic_1_2_nbr_51
        {
            get
            {
                return _const_clinic_1_2_nbr_51;
            }
            set
            {
                if (_const_clinic_1_2_nbr_51 != value)
                {
                    _const_clinic_1_2_nbr_51 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_51");
                }
            }
        }

        private string _const_clinic_nbr_51;
        public string const_clinic_nbr_51
        {
            get
            {
                return _const_clinic_nbr_51;
            }
            set
            {
                if (_const_clinic_nbr_51 != value)
                {
                    _const_clinic_nbr_51 = value;
                    _const_clinic_nbr_51 = _const_clinic_nbr_51.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_51");
                }
            }
        }

        private int _const_clinic_1_2_nbr_52;
        public int const_clinic_1_2_nbr_52
        {
            get
            {
                return _const_clinic_1_2_nbr_52;
            }
            set
            {
                if (_const_clinic_1_2_nbr_52 != value)
                {
                    _const_clinic_1_2_nbr_52 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_52");
                }
            }
        }

        private string _const_clinic_nbr_52;
        public string const_clinic_nbr_52
        {
            get
            {
                return _const_clinic_nbr_52;
            }
            set
            {
                if (_const_clinic_nbr_52 != value)
                {
                    _const_clinic_nbr_52 = value;
                    _const_clinic_nbr_52 = _const_clinic_nbr_52.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_52");
                }
            }
        }

        private int _const_clinic_1_2_nbr_53;
        public int const_clinic_1_2_nbr_53
        {
            get
            {
                return _const_clinic_1_2_nbr_53;
            }
            set
            {
                if (_const_clinic_1_2_nbr_53 != value)
                {
                    _const_clinic_1_2_nbr_53 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_53");
                }
            }
        }

        private string _const_clinic_nbr_53;
        public string const_clinic_nbr_53
        {
            get
            {
                return _const_clinic_nbr_53;
            }
            set
            {
                if (_const_clinic_nbr_53 != value)
                {
                    _const_clinic_nbr_53 = value;
                    _const_clinic_nbr_53 = _const_clinic_nbr_53.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_53");
                }
            }
        }

        private int _const_clinic_1_2_nbr_54;
        public int const_clinic_1_2_nbr_54
        {
            get
            {
                return _const_clinic_1_2_nbr_54;
            }
            set
            {
                if (_const_clinic_1_2_nbr_54 != value)
                {
                    _const_clinic_1_2_nbr_54 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_54");
                }
            }
        }

        private string _const_clinic_nbr_54;
        public string const_clinic_nbr_54
        {
            get
            {
                return _const_clinic_nbr_54;
            }
            set
            {
                if (_const_clinic_nbr_54 != value)
                {
                    _const_clinic_nbr_54 = value;
                    _const_clinic_nbr_54 = _const_clinic_nbr_54.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_54");
                }
            }
        }

        private int _const_clinic_1_2_nbr_55;
        public int const_clinic_1_2_nbr_55
        {
            get
            {
                return _const_clinic_1_2_nbr_55;
            }
            set
            {
                if (_const_clinic_1_2_nbr_55 != value)
                {
                    _const_clinic_1_2_nbr_55 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_55");
                }
            }
        }

        private string _const_clinic_nbr_55;
        public string const_clinic_nbr_55
        {
            get
            {
                return _const_clinic_nbr_55;
            }
            set
            {
                if (_const_clinic_nbr_55 != value)
                {
                    _const_clinic_nbr_55 = value;
                    _const_clinic_nbr_55 = _const_clinic_nbr_55.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_55");
                }
            }
        }

        private int _const_clinic_1_2_nbr_56;
        public int const_clinic_1_2_nbr_56
        {
            get
            {
                return _const_clinic_1_2_nbr_56;
            }
            set
            {
                if (_const_clinic_1_2_nbr_56 != value)
                {
                    _const_clinic_1_2_nbr_56 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_56");
                }
            }
        }

        private string _const_clinic_nbr_56;
        public string const_clinic_nbr_56
        {
            get
            {
                return _const_clinic_nbr_56;
            }
            set
            {
                if (_const_clinic_nbr_56 != value)
                {
                    _const_clinic_nbr_56 = value;
                    _const_clinic_nbr_56 = _const_clinic_nbr_56.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_56");
                }
            }
        }

        private int _const_clinic_1_2_nbr_57;
        public int const_clinic_1_2_nbr_57
        {
            get
            {
                return _const_clinic_1_2_nbr_57;
            }
            set
            {
                if (_const_clinic_1_2_nbr_57 != value)
                {
                    _const_clinic_1_2_nbr_57 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_57");
                }
            }
        }

        private string _const_clinic_nbr_57;
        public string const_clinic_nbr_57
        {
            get
            {
                return _const_clinic_nbr_57;
            }
            set
            {
                if (_const_clinic_nbr_57 != value)
                {
                    _const_clinic_nbr_57 = value;
                    _const_clinic_nbr_57 = _const_clinic_nbr_57.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_57");
                }
            }
        }

        private int _const_clinic_1_2_nbr_58;
        public int const_clinic_1_2_nbr_58
        {
            get
            {
                return _const_clinic_1_2_nbr_58;
            }
            set
            {
                if (_const_clinic_1_2_nbr_58 != value)
                {
                    _const_clinic_1_2_nbr_58 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_58");
                }
            }
        }

        private string _const_clinic_nbr_58;
        public string const_clinic_nbr_58
        {
            get
            {
                return _const_clinic_nbr_58;
            }
            set
            {
                if (_const_clinic_nbr_58 != value)
                {
                    _const_clinic_nbr_58 = value;
                    _const_clinic_nbr_58 = _const_clinic_nbr_58.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_58");
                }
            }
        }

        private int _const_clinic_1_2_nbr_59;
        public int const_clinic_1_2_nbr_59
        {
            get
            {
                return _const_clinic_1_2_nbr_59;
            }
            set
            {
                if (_const_clinic_1_2_nbr_59 != value)
                {
                    _const_clinic_1_2_nbr_59 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_59");
                }
            }
        }

        private string _const_clinic_nbr_59;
        public string const_clinic_nbr_59
        {
            get
            {
                return _const_clinic_nbr_59;
            }
            set
            {
                if (_const_clinic_nbr_59 != value)
                {
                    _const_clinic_nbr_59 = value;
                    _const_clinic_nbr_59 = _const_clinic_nbr_59.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_59");
                }
            }
        }

        private int _const_clinic_1_2_nbr_60;
        public int const_clinic_1_2_nbr_60
        {
            get
            {
                return _const_clinic_1_2_nbr_60;
            }
            set
            {
                if (_const_clinic_1_2_nbr_60 != value)
                {
                    _const_clinic_1_2_nbr_60 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_60");
                }
            }
        }

        private string _const_clinic_nbr_60;
        public string const_clinic_nbr_60
        {
            get
            {
                return _const_clinic_nbr_60;
            }
            set
            {
                if (_const_clinic_nbr_60 != value)
                {
                    _const_clinic_nbr_60 = value;
                    _const_clinic_nbr_60 = _const_clinic_nbr_60.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_60");
                }
            }
        }

        private int _const_clinic_1_2_nbr_61;
        public int const_clinic_1_2_nbr_61
        {
            get
            {
                return _const_clinic_1_2_nbr_61;
            }
            set
            {
                if (_const_clinic_1_2_nbr_61 != value)
                {
                    _const_clinic_1_2_nbr_61 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_61");
                }
            }
        }

        private string _const_clinic_nbr_61;
        public string const_clinic_nbr_61
        {
            get
            {
                return _const_clinic_nbr_61;
            }
            set
            {
                if (_const_clinic_nbr_61 != value)
                {
                    _const_clinic_nbr_61 = value;
                    _const_clinic_nbr_61 = _const_clinic_nbr_61.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_61");
                }
            }
        }

        private int _const_clinic_1_2_nbr_62;
        public int const_clinic_1_2_nbr_62
        {
            get
            {
                return _const_clinic_1_2_nbr_62;
            }
            set
            {
                if (_const_clinic_1_2_nbr_62 != value)
                {
                    _const_clinic_1_2_nbr_62 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_62");
                }
            }
        }

        private string _const_clinic_nbr_62;
        public string const_clinic_nbr_62
        {
            get
            {
                return _const_clinic_nbr_62;
            }
            set
            {
                if (_const_clinic_nbr_62 != value)
                {
                    _const_clinic_nbr_62 = value;
                    _const_clinic_nbr_62 = _const_clinic_nbr_62.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_62");
                }
            }
        }

        private int _const_clinic_1_2_nbr_63;
        public int const_clinic_1_2_nbr_63
        {
            get
            {
                return _const_clinic_1_2_nbr_63;
            }
            set
            {
                if (_const_clinic_1_2_nbr_63 != value)
                {
                    _const_clinic_1_2_nbr_63 = value;
                    RaisePropertyChanged("const_clinic_1_2_nbr_63");
                }
            }
        }

        private string _const_clinic_nbr_63;
        public string const_clinic_nbr_63
        {
            get
            {
                return _const_clinic_nbr_63;
            }
            set
            {
                if (_const_clinic_nbr_63 != value)
                {
                    _const_clinic_nbr_63 = value;
                    _const_clinic_nbr_63 = _const_clinic_nbr_63.ToUpper();
                    RaisePropertyChanged("const_clinic_nbr_63");
                }
            }
        }

        private int _const_yy_curr;
        public int const_yy_curr
        {
            get
            {
                return _const_yy_curr;
            }
            set
            {
                if (_const_yy_curr != value)
                {
                    _const_yy_curr = value;
                    RaisePropertyChanged("const_yy_curr");
                }
            }
        }

        private int _const_mm_curr;
        public int const_mm_curr
        {
            get
            {
                return _const_mm_curr;
            }
            set
            {
                if (_const_mm_curr != value)
                {
                    _const_mm_curr = value;
                    RaisePropertyChanged("const_mm_curr");
                }
            }
        }

        private int _const_dd_curr;
        public int const_dd_curr
        {
            get
            {
                return _const_dd_curr;
            }
            set
            {
                if (_const_dd_curr != value)
                {
                    _const_dd_curr = value;
                    RaisePropertyChanged("const_dd_curr");
                }
            }
        }

        private decimal _const_wcb_curr;
        public decimal const_wcb_curr
        {
            get
            {
                return _const_wcb_curr;
            }
            set
            {
                if (_const_wcb_curr != value)
                {
                    _const_wcb_curr = value;
                    RaisePropertyChanged("const_wcb_curr");
                }
            }
        }

        private decimal _const_bilateral_curr;
        public decimal const_bilateral_curr
        {
            get
            {
                return _const_bilateral_curr;
            }
            set
            {
                if (_const_bilateral_curr != value)
                {
                    _const_bilateral_curr = value;
                    RaisePropertyChanged("const_bilateral_curr");
                }
            }
        }

        private decimal _const_ic_curr;
        public decimal const_ic_curr
        {
            get
            {
                return _const_ic_curr;
            }
            set
            {
                if (_const_ic_curr != value)
                {
                    _const_ic_curr = value;
                    RaisePropertyChanged("const_ic_curr");
                }
            }
        }

        private decimal _const_sr_curr;
        public decimal const_sr_curr
        {
            get
            {
                return _const_sr_curr;
            }
            set
            {
                if (_const_sr_curr != value)
                {
                    _const_sr_curr = value;
                    RaisePropertyChanged("const_sr_curr");
                }
            }
        }

        private decimal _const_asst_h_curr;
        public decimal const_asst_h_curr
        {
            get
            {
                return _const_asst_h_curr;
            }
            set
            {
                if (_const_asst_h_curr != value)
                {
                    _const_asst_h_curr = value;
                    RaisePropertyChanged("const_asst_h_curr");
                }
            }
        }

        private decimal _const_reg_h_curr;
        public decimal const_reg_h_curr
        {
            get
            {
                return _const_reg_h_curr;
            }
            set
            {
                if (_const_reg_h_curr != value)
                {
                    _const_reg_h_curr = value;
                    RaisePropertyChanged("const_reg_h_curr");
                }
            }
        }

        private decimal _const_cert_h_curr;
        public decimal const_cert_h_curr
        {
            get
            {
                return _const_cert_h_curr;
            }
            set
            {
                if (_const_cert_h_curr != value)
                {
                    _const_cert_h_curr = value;
                    RaisePropertyChanged("const_cert_h_curr");
                }
            }
        }

        private decimal _const_asst_a_curr;
        public decimal const_asst_a_curr
        {
            get
            {
                return _const_asst_a_curr;
            }
            set
            {
                if (_const_asst_a_curr != value)
                {
                    _const_asst_a_curr = value;
                    RaisePropertyChanged("const_asst_a_curr");
                }
            }
        }

        private decimal _const_reg_a_curr;
        public decimal const_reg_a_curr
        {
            get
            {
                return _const_reg_a_curr;
            }
            set
            {
                if (_const_reg_a_curr != value)
                {
                    _const_reg_a_curr = value;
                    RaisePropertyChanged("const_reg_a_curr");
                }
            }
        }

        private decimal _const_cert_a_curr;
        public decimal const_cert_a_curr
        {
            get
            {
                return _const_cert_a_curr;
            }
            set
            {
                if (_const_cert_a_curr != value)
                {
                    _const_cert_a_curr = value;
                    RaisePropertyChanged("const_cert_a_curr");
                }
            }
        }

        private int _const_max_nbr_rates;
        public int const_max_nbr_rates
        {
            get
            {
                return _const_max_nbr_rates;
            }
            set
            {
                if (_const_max_nbr_rates != value)
                {
                    _const_max_nbr_rates = value;
                    RaisePropertyChanged("const_max_nbr_rates");
                }
            }
        }

        private string _const_sect_1;
        public string const_sect_1
        {
            get
            {
                return _const_sect_1;
            }
            set
            {
                if (_const_sect_1 != value)
                {
                    _const_sect_1 = value;
                    _const_sect_1 = _const_sect_1.ToUpper();
                    RaisePropertyChanged("const_sect_1");
                }
            }
        }

        private int _const_group_1;
        public int const_group_1
        {
            get
            {
                return _const_group_1;
            }
            set
            {
                if (_const_group_1 != value)
                {
                    _const_group_1 = value;
                    RaisePropertyChanged("const_group_1");
                }
            }
        }

        private decimal _const_curr_1;
        public decimal const_curr_1
        {
            get
            {
                return _const_curr_1;
            }
            set
            {
                if (_const_curr_1 != value)
                {
                    _const_curr_1 = value;
                    RaisePropertyChanged("const_curr_1");
                }
            }
        }


        private string _const_sect_2;
        public string const_sect_2
        {
            get
            {
                return _const_sect_2;
            }
            set
            {
                if (_const_sect_2 != value)
                {
                    _const_sect_2 = value;
                    _const_sect_2 = _const_sect_2.ToUpper();
                    RaisePropertyChanged("const_sect_2");
                }
            }
        }

        private int _const_group_2;
        public int const_group_2
        {
            get
            {
                return _const_group_2;
            }
            set
            {
                if (_const_group_2 != value)
                {
                    _const_group_2 = value;
                    RaisePropertyChanged("const_group_2");
                }
            }
        }

        private decimal _const_curr_2;
        public decimal const_curr_2
        {
            get
            {
                return _const_curr_2;
            }
            set
            {
                if (_const_curr_2 != value)
                {
                    _const_curr_2 = value;
                    RaisePropertyChanged("const_curr_2");
                }
            }
        }

        private string _const_sect_3;
        public string const_sect_3
        {
            get
            {
                return _const_sect_3;
            }
            set
            {
                if (_const_sect_3 != value)
                {
                    _const_sect_3 = value;
                    _const_sect_3 = _const_sect_3.ToUpper();
                    RaisePropertyChanged("const_sect_3");
                }
            }
        }

        private int _const_group_3;
        public int const_group_3
        {
            get
            {
                return _const_group_3;
            }
            set
            {
                if (_const_group_3 != value)
                {
                    _const_group_3 = value;
                    RaisePropertyChanged("const_group_3");
                }
            }
        }

        private decimal _const_curr_3;
        public decimal const_curr_3
        {
            get
            {
                return _const_curr_3;
            }
            set
            {
                if (_const_curr_3 != value)
                {
                    _const_curr_3 = value;
                    RaisePropertyChanged("const_curr_3");
                }
            }
        }


        private string _const_sect_4;
        public string const_sect_4
        {
            get
            {
                return _const_sect_4;
            }
            set
            {
                if (_const_sect_4 != value)
                {
                    _const_sect_4 = value;
                    _const_sect_4 = _const_sect_4.ToUpper();
                    RaisePropertyChanged("const_sect_4");
                }
            }
        }

        private int _const_group_4;
        public int const_group_4
        {
            get
            {
                return _const_group_4;
            }
            set
            {
                if (_const_group_4 != value)
                {
                    _const_group_4 = value;
                    RaisePropertyChanged("const_group_4");
                }
            }
        }

        private decimal _const_curr_4;
        public decimal const_curr_4
        {
            get
            {
                return _const_curr_4;
            }
            set
            {
                if (_const_curr_4 != value)
                {
                    _const_curr_4 = value;
                    RaisePropertyChanged("const_curr_4");
                }
            }
        }

        private string _const_sect_5;
        public string const_sect_5
        {
            get
            {
                return _const_sect_5;
            }
            set
            {
                if (_const_sect_5 != value)
                {
                    _const_sect_5 = value;
                    _const_sect_5 = _const_sect_5.ToUpper();
                    RaisePropertyChanged("const_sect_5");
                }
            }
        }

        private int _const_group_5;
        public int const_group_5
        {
            get
            {
                return _const_group_5;
            }
            set
            {
                if (_const_group_5 != value)
                {
                    _const_group_5 = value;
                    RaisePropertyChanged("const_group_5");
                }
            }
        }

        private decimal _const_curr_5;
        public decimal const_curr_5
        {
            get
            {
                return _const_curr_5;
            }
            set
            {
                if (_const_curr_5 != value)
                {
                    _const_curr_5 = value;
                    RaisePropertyChanged("const_curr_5");
                }
            }
        }


        private string _const_sect_6;
        public string const_sect_6
        {
            get
            {
                return _const_sect_6;
            }
            set
            {
                if (_const_sect_6 != value)
                {
                    _const_sect_6 = value;
                    _const_sect_6 = _const_sect_6.ToUpper();
                    RaisePropertyChanged("const_sect_6");
                }
            }
        }

        private int _const_group_6;
        public int const_group_6
        {
            get
            {
                return _const_group_6;
            }
            set
            {
                if (_const_group_6 != value)
                {
                    _const_group_6 = value;
                    RaisePropertyChanged("const_group_6");
                }
            }
        }

        private decimal _const_curr_6;
        public decimal const_curr_6
        {
            get
            {
                return _const_curr_6;
            }
            set
            {
                if (_const_curr_6 != value)
                {
                    _const_curr_6 = value;
                    RaisePropertyChanged("const_curr_6");
                }
            }
        }

        private string _const_sect_7;
        public string const_sect_7
        {
            get
            {
                return _const_sect_7;
            }
            set
            {
                if (_const_sect_7 != value)
                {
                    _const_sect_7 = value;
                    _const_sect_7 = _const_sect_7.ToUpper();
                    RaisePropertyChanged("const_sect_7");
                }
            }
        }

        private int _const_group_7;
        public int const_group_7
        {
            get
            {
                return _const_group_7;
            }
            set
            {
                if (_const_group_7 != value)
                {
                    _const_group_7 = value;
                    RaisePropertyChanged("const_group_7");
                }
            }
        }

        private decimal _const_curr_7;
        public decimal const_curr_7
        {
            get
            {
                return _const_curr_7;
            }
            set
            {
                if (_const_curr_7 != value)
                {
                    _const_curr_7 = value;
                    RaisePropertyChanged("const_curr_7");
                }
            }
        }

        private string _const_sect_8;
        public string const_sect_8
        {
            get
            {
                return _const_sect_8;
            }
            set
            {
                if (_const_sect_8 != value)
                {
                    _const_sect_8 = value;
                    _const_sect_8 = _const_sect_8.ToUpper();
                    RaisePropertyChanged("const_sect_8");
                }
            }
        }

        private int _const_group_8;
        public int const_group_8
        {
            get
            {
                return _const_group_8;
            }
            set
            {
                if (_const_group_8 != value)
                {
                    _const_group_8 = value;
                    RaisePropertyChanged("const_group_8");
                }
            }
        }

        private decimal _const_curr_8;
        public decimal const_curr_8
        {
            get
            {
                return _const_curr_8;
            }
            set
            {
                if (_const_curr_8 != value)
                {
                    _const_curr_8 = value;
                    RaisePropertyChanged("const_curr_8");
                }
            }
        }

        private string _const_sect_9;
        public string const_sect_9
        {
            get
            {
                return _const_sect_9;
            }
            set
            {
                if (_const_sect_9 != value)
                {
                    _const_sect_9 = value;
                    _const_sect_9 = _const_sect_9.ToUpper();
                    RaisePropertyChanged("const_sect_9");
                }
            }
        }

        private int _const_group_9;
        public int const_group_9
        {
            get
            {
                return _const_group_9;
            }
            set
            {
                if (_const_group_9 != value)
                {
                    _const_group_9 = value;
                    RaisePropertyChanged("const_group_9");
                }
            }
        }

        private decimal _const_curr_9;
        public decimal const_curr_9
        {
            get
            {
                return _const_curr_9;
            }
            set
            {
                if (_const_curr_9 != value)
                {
                    _const_curr_9 = value;
                    RaisePropertyChanged("const_curr_9");
                }
            }
        }

        private string _const_sect_10;
        public string const_sect_10
        {
            get
            {
                return _const_sect_10;
            }
            set
            {
                if (_const_sect_10 != value)
                {
                    _const_sect_10 = value;
                    _const_sect_10 = _const_sect_10.ToUpper();
                    RaisePropertyChanged("const_sect_10");
                }
            }
        }

        private int _const_group_10;
        public int const_group_10
        {
            get
            {
                return _const_group_10;
            }
            set
            {
                if (_const_group_10 != value)
                {
                    _const_group_10 = value;
                    RaisePropertyChanged("const_group_10");
                }
            }
        }

        private decimal _const_curr_10;
        public decimal const_curr_10
        {
            get
            {
                return _const_curr_10;
            }
            set
            {
                if (_const_curr_10 != value)
                {
                    _const_curr_10 = value;
                    RaisePropertyChanged("const_curr_10");
                }
            }
        }

        private string _const_sect_11;
        public string const_sect_11
        {
            get
            {
                return _const_sect_11;
            }
            set
            {
                if (_const_sect_11 != value)
                {
                    _const_sect_11 = value;
                    _const_sect_11 = _const_sect_11.ToUpper();
                    RaisePropertyChanged("const_sect_11");
                }
            }
        }

        private int _const_group_11;
        public int const_group_11
        {
            get
            {
                return _const_group_11;
            }
            set
            {
                if (_const_group_11 != value)
                {
                    _const_group_11 = value;
                    RaisePropertyChanged("const_group_11");
                }
            }
        }

        private decimal _const_curr_11;
        public decimal const_curr_11
        {
            get
            {
                return _const_curr_11;
            }
            set
            {
                if (_const_curr_11 != value)
                {
                    _const_curr_11 = value;
                    RaisePropertyChanged("const_curr_11");
                }
            }
        }

        private string _const_sect_12;
        public string const_sect_12
        {
            get
            {
                return _const_sect_12;
            }
            set
            {
                if (_const_sect_12 != value)
                {
                    _const_sect_12 = value;
                    _const_sect_12 = _const_sect_12.ToUpper();
                    RaisePropertyChanged("const_sect_12");
                }
            }
        }

        private int _const_group_12;
        public int const_group_12
        {
            get
            {
                return _const_group_12;
            }
            set
            {
                if (_const_group_12 != value)
                {
                    _const_group_12 = value;
                    RaisePropertyChanged("const_group_12");
                }
            }
        }

        private decimal _const_curr_12;
        public decimal const_curr_12
        {
            get
            {
                return _const_curr_12;
            }
            set
            {
                if (_const_curr_12 != value)
                {
                    _const_curr_12 = value;
                    RaisePropertyChanged("const_curr_12");
                }
            }
        }

        private string _const_sect_13;
        public string const_sect_13
        {
            get
            {
                return _const_sect_13;
            }
            set
            {
                if (_const_sect_13 != value)
                {
                    _const_sect_13 = value;
                    _const_sect_13 = _const_sect_13.ToUpper();
                    RaisePropertyChanged("const_sect_13");
                }
            }
        }

        private int _const_group_13;
        public int const_group_13
        {
            get
            {
                return _const_group_13;
            }
            set
            {
                if (_const_group_13 != value)
                {
                    _const_group_13 = value;
                    RaisePropertyChanged("const_group_13");
                }
            }
        }

        private decimal _const_curr_13;
        public decimal const_curr_13
        {
            get
            {
                return _const_curr_13;
            }
            set
            {
                if (_const_curr_13 != value)
                {
                    _const_curr_13 = value;
                    RaisePropertyChanged("const_curr_13");
                }
            }
        }

        private string _const_sect_14;
        public string const_sect_14
        {
            get
            {
                return _const_sect_14;
            }
            set
            {
                if (_const_sect_14 != value)
                {
                    _const_sect_14 = value;
                    _const_sect_14 = _const_sect_14.ToUpper();
                    RaisePropertyChanged("const_sect_14");
                }
            }
        }

        private int _const_group_14;
        public int const_group_14
        {
            get
            {
                return _const_group_14;
            }
            set
            {
                if (_const_group_14 != value)
                {
                    _const_group_14 = value;
                    RaisePropertyChanged("const_group_14");
                }
            }
        }

        private decimal _const_curr_14;
        public decimal const_curr_14
        {
            get
            {
                return _const_curr_14;
            }
            set
            {
                if (_const_curr_14 != value)
                {
                    _const_curr_14 = value;
                    RaisePropertyChanged("const_curr_14");
                }
            }
        }

        private string _const_sect_15;
        public string const_sect_15
        {
            get
            {
                return _const_sect_15;
            }
            set
            {
                if (_const_sect_15 != value)
                {
                    _const_sect_15 = value;
                    _const_sect_15 = _const_sect_15.ToUpper();
                    RaisePropertyChanged("const_sect_15");
                }
            }
        }

        private int _const_group_15;
        public int const_group_15
        {
            get
            {
                return _const_group_15;
            }
            set
            {
                if (_const_group_15 != value)
                {
                    _const_group_15 = value;
                    RaisePropertyChanged("const_group_15");
                }
            }
        }

        private decimal _const_curr_15;
        public decimal const_curr_15
        {
            get
            {
                return _const_curr_15;
            }
            set
            {
                if (_const_curr_15 != value)
                {
                    _const_curr_15 = value;
                    RaisePropertyChanged("const_curr_15");
                }
            }
        }

        private string _const_sect_16;
        public string const_sect_16
        {
            get
            {
                return _const_sect_16;
            }
            set
            {
                if (_const_sect_16 != value)
                {
                    _const_sect_16 = value;
                    _const_sect_16 = _const_sect_16.ToUpper();
                    RaisePropertyChanged("const_sect_16");
                }
            }
        }

        private int _const_group_16;
        public int const_group_16
        {
            get
            {
                return _const_group_16;
            }
            set
            {
                if (_const_group_16 != value)
                {
                    _const_group_16 = value;
                    RaisePropertyChanged("const_group_16");
                }
            }
        }

        private decimal _const_curr_16;
        public decimal const_curr_16
        {
            get
            {
                return _const_curr_16;
            }
            set
            {
                if (_const_curr_16 != value)
                {
                    _const_curr_16 = value;
                    RaisePropertyChanged("const_curr_16");
                }
            }
        }


        private string _const_sect_17;
        public string const_sect_17
        {
            get
            {
                return _const_sect_17;
            }
            set
            {
                if (_const_sect_17 != value)
                {
                    _const_sect_17 = value;
                    _const_sect_17 = _const_sect_17.ToUpper();
                    RaisePropertyChanged("const_sect_17");
                }
            }
        }

        private int _const_group_17;
        public int const_group_17
        {
            get
            {
                return _const_group_17;
            }
            set
            {
                if (_const_group_17 != value)
                {
                    _const_group_17 = value;
                    RaisePropertyChanged("const_group_17");
                }
            }
        }

        private decimal _const_curr_17;
        public decimal const_curr_17
        {
            get
            {
                return _const_curr_17;
            }
            set
            {
                if (_const_curr_17 != value)
                {
                    _const_curr_17 = value;
                    RaisePropertyChanged("const_curr_17");
                }
            }
        }

        private string _const_sect_18;
        public string const_sect_18
        {
            get
            {
                return _const_sect_18;
            }
            set
            {
                if (_const_sect_18 != value)
                {
                    _const_sect_18 = value;
                    _const_sect_18 = _const_sect_18.ToUpper();
                    RaisePropertyChanged("const_sect_18");
                }
            }
        }

        private int _const_group_18;
        public int const_group_18
        {
            get
            {
                return _const_group_18;
            }
            set
            {
                if (_const_group_18 != value)
                {
                    _const_group_18 = value;
                    RaisePropertyChanged("const_group_18");
                }
            }
        }

        private decimal _const_curr_18;
        public decimal const_curr_18
        {
            get
            {
                return _const_curr_18;
            }
            set
            {
                if (_const_curr_18 != value)
                {
                    _const_curr_18 = value;
                    RaisePropertyChanged("const_curr_18");
                }
            }
        }

        private string _const_sect_19;
        public string const_sect_19
        {
            get
            {
                return _const_sect_19;
            }
            set
            {
                if (_const_sect_19 != value)
                {
                    _const_sect_19 = value;
                    _const_sect_19 = _const_sect_19.ToUpper();
                    RaisePropertyChanged("const_sect_19");
                }
            }
        }

        private int _const_group_19;
        public int const_group_19
        {
            get
            {
                return _const_group_19;
            }
            set
            {
                if (_const_group_19 != value)
                {
                    _const_group_19 = value;
                    RaisePropertyChanged("const_group_19");
                }
            }
        }

        private decimal _const_curr_19;
        public decimal const_curr_19
        {
            get
            {
                return _const_curr_19;
            }
            set
            {
                if (_const_curr_19 != value)
                {
                    _const_curr_19 = value;
                    RaisePropertyChanged("const_curr_19");
                }
            }
        }

        private int _const_yy_prev;
        public int const_yy_prev
        {
            get
            {
                return _const_yy_prev;
            }
            set
            {
                if (_const_yy_prev != value)
                {
                    _const_yy_prev = value;
                    RaisePropertyChanged("const_yy_prev");
                }
            }
        }

        private int _const_mm_prev;
        public int const_mm_prev
        {
            get
            {
                return _const_mm_prev;
            }
            set
            {
                if (_const_mm_prev != value)
                {
                    _const_mm_prev = value;
                    RaisePropertyChanged("const_mm_prev");
                }
            }
        }

        private int _const_dd_prev;
        public int const_dd_prev
        {
            get
            {
                return _const_dd_prev;
            }
            set
            {
                if (_const_dd_prev != value)
                {
                    _const_dd_prev = value;
                    RaisePropertyChanged("const_dd_prev");
                }
            }
        }

        private decimal _const_wcb_prev;
        public decimal const_wcb_prev
        {
            get
            {
                return _const_wcb_prev;
            }
            set
            {
                if (_const_wcb_prev != value)
                {
                    _const_wcb_prev = value;
                    RaisePropertyChanged("const_wcb_prev");
                }
            }
        }

        private decimal _const_bilateral_prev;
        public decimal const_bilateral_prev
        {
            get
            {
                return _const_bilateral_prev;
            }
            set
            {
                if (_const_bilateral_prev != value)
                {
                    _const_bilateral_prev = value;
                    RaisePropertyChanged("const_bilateral_prev");
                }
            }
        }

        private decimal _const_ic_prev;
        public decimal const_ic_prev
        {
            get
            {
                return _const_ic_prev;
            }
            set
            {
                if (_const_ic_prev != value)
                {
                    _const_ic_prev = value;
                    RaisePropertyChanged("const_ic_prev");
                }
            }
        }

        private decimal _const_sr_prev;
        public decimal const_sr_prev
        {
            get
            {
                return _const_sr_prev;
            }
            set
            {
                if (_const_sr_prev != value)
                {
                    _const_sr_prev = value;
                    RaisePropertyChanged("const_sr_prev");
                }
            }
        }

        private decimal _const_asst_h_prev;
        public decimal const_asst_h_prev
        {
            get
            {
                return _const_asst_h_prev;
            }
            set
            {
                if (_const_asst_h_prev != value)
                {
                    _const_asst_h_prev = value;
                    RaisePropertyChanged("const_asst_h_prev");
                }
            }
        }

        private decimal _const_reg_h_prev;
        public decimal const_reg_h_prev
        {
            get
            {
                return _const_reg_h_prev;
            }
            set
            {
                if (_const_reg_h_prev != value)
                {
                    _const_reg_h_prev = value;
                    RaisePropertyChanged("const_reg_h_prev");
                }
            }
        }

        private decimal _const_cert_h_prev;
        public decimal const_cert_h_prev
        {
            get
            {
                return _const_cert_h_prev;
            }
            set
            {
                if (_const_cert_h_prev != value)
                {
                    _const_cert_h_prev = value;
                    RaisePropertyChanged("const_cert_h_prev");
                }
            }
        }

        private decimal _const_asst_a_prev;
        public decimal const_asst_a_prev
        {
            get
            {
                return _const_asst_a_prev;
            }
            set
            {
                if (_const_asst_a_prev != value)
                {
                    _const_asst_a_prev = value;
                    RaisePropertyChanged("const_asst_a_prev");
                }
            }
        }

        private decimal _const_reg_a_prev;
        public decimal const_reg_a_prev
        {
            get
            {
                return _const_reg_a_prev;
            }
            set
            {
                if (_const_reg_a_prev != value)
                {
                    _const_reg_a_prev = value;
                    RaisePropertyChanged("const_reg_a_prev");
                }
            }
        }

        private decimal _const_cert_a_prev;
        public decimal const_cert_a_prev
        {
            get
            {
                return _const_cert_a_prev;
            }
            set
            {
                if (_const_cert_a_prev != value)
                {
                    _const_cert_a_prev = value;
                    RaisePropertyChanged("const_cert_a_prev");
                }
            }
        }

        private decimal _const_prev_1;
        public decimal const_prev_1
        {
            get
            {
                return _const_prev_1;
            }
            set
            {
                if (_const_prev_1 != value)
                {
                    _const_prev_1 = value;
                    RaisePropertyChanged("const_prev_1");
                }
            }
        }

        private decimal _const_prev_2;
        public decimal const_prev_2
        {
            get
            {
                return _const_prev_2;
            }
            set
            {
                if (_const_prev_2 != value)
                {
                    _const_prev_2 = value;
                    RaisePropertyChanged("const_prev_2");
                }
            }
        }

        private decimal _const_prev_3;
        public decimal const_prev_3
        {
            get
            {
                return _const_prev_3;
            }
            set
            {
                if (_const_prev_3 != value)
                {
                    _const_prev_3 = value;
                    RaisePropertyChanged("const_prev_3");
                }
            }
        }

        private decimal _const_prev_4;
        public decimal const_prev_4
        {
            get
            {
                return _const_prev_4;
            }
            set
            {
                if (_const_prev_4 != value)
                {
                    _const_prev_4 = value;
                    RaisePropertyChanged("const_prev_4");
                }
            }
        }

        private decimal _const_prev_5;
        public decimal const_prev_5
        {
            get
            {
                return _const_prev_5;
            }
            set
            {
                if (_const_prev_5 != value)
                {
                    _const_prev_5 = value;
                    RaisePropertyChanged("const_prev_5");
                }
            }
        }

        private decimal _const_prev_6;
        public decimal const_prev_6
        {
            get
            {
                return _const_prev_6;
            }
            set
            {
                if (_const_prev_6 != value)
                {
                    _const_prev_6 = value;
                    RaisePropertyChanged("const_prev_6");
                }
            }
        }

        private decimal _const_prev_7;
        public decimal const_prev_7
        {
            get
            {
                return _const_prev_7;
            }
            set
            {
                if (_const_prev_7 != value)
                {
                    _const_prev_7 = value;
                    RaisePropertyChanged("const_prev_7");
                }
            }
        }

        private decimal _const_prev_8;
        public decimal const_prev_8
        {
            get
            {
                return _const_prev_8;
            }
            set
            {
                if (_const_prev_8 != value)
                {
                    _const_prev_8 = value;
                    RaisePropertyChanged("const_prev_8");
                }
            }
        }

        private decimal _const_prev_9;
        public decimal const_prev_9
        {
            get
            {
                return _const_prev_9;
            }
            set
            {
                if (_const_prev_9 != value)
                {
                    _const_prev_9 = value;
                    RaisePropertyChanged("const_prev_9");
                }
            }
        }

        private decimal _const_prev_10;
        public decimal const_prev_10
        {
            get
            {
                return _const_prev_10;
            }
            set
            {
                if (_const_prev_10 != value)
                {
                    _const_prev_10 = value;
                    RaisePropertyChanged("const_prev_10");
                }
            }
        }

        private decimal _const_prev_11;
        public decimal const_prev_11
        {
            get
            {
                return _const_prev_11;
            }
            set
            {
                if (_const_prev_11 != value)
                {
                    _const_prev_11 = value;
                    RaisePropertyChanged("const_prev_11");
                }
            }
        }

        private decimal _const_prev_12;
        public decimal const_prev_12
        {
            get
            {
                return _const_prev_12;
            }
            set
            {
                if (_const_prev_12 != value)
                {
                    _const_prev_12 = value;
                    RaisePropertyChanged("const_prev_12");
                }
            }
        }

        private decimal _const_prev_13;
        public decimal const_prev_13
        {
            get
            {
                return _const_prev_13;
            }
            set
            {
                if (_const_prev_13 != value)
                {
                    _const_prev_13 = value;
                    RaisePropertyChanged("const_prev_13");
                }
            }
        }

        private decimal _const_prev_14;
        public decimal const_prev_14
        {
            get
            {
                return _const_prev_14;
            }
            set
            {
                if (_const_prev_14 != value)
                {
                    _const_prev_14 = value;
                    RaisePropertyChanged("const_prev_14");
                }
            }
        }

        private decimal _const_prev_15;
        public decimal const_prev_15
        {
            get
            {
                return _const_prev_15;
            }
            set
            {
                if (_const_prev_15 != value)
                {
                    _const_prev_15 = value;
                    RaisePropertyChanged("const_prev_15");
                }
            }
        }

        private decimal _const_prev_16;
        public decimal const_prev_16
        {
            get
            {
                return _const_prev_16;
            }
            set
            {
                if (_const_prev_16 != value)
                {
                    _const_prev_16 = value;
                    RaisePropertyChanged("const_prev_16");
                }
            }
        }

        private decimal _const_prev_17;
        public decimal const_prev_17
        {
            get
            {
                return _const_prev_17;
            }
            set
            {
                if (_const_prev_17 != value)
                {
                    _const_prev_17 = value;
                    RaisePropertyChanged("const_prev_17");
                }
            }
        }

        private decimal _const_prev_18;
        public decimal const_prev_18
        {
            get
            {
                return _const_prev_18;
            }
            set
            {
                if (_const_prev_18 != value)
                {
                    _const_prev_18 = value;
                    RaisePropertyChanged("const_prev_18");
                }
            }
        }

        private decimal _const_prev_19;
        public decimal const_prev_19
        {
            get
            {
                return _const_prev_19;
            }
            set
            {
                if (_const_prev_19 != value)
                {
                    _const_prev_19 = value;
                    RaisePropertyChanged("const_prev_19");
                }
            }
        }

        private string _ws_misc_msg_curr;
        public string ws_misc_msg_curr
        {
            get
            {
                return _ws_misc_msg_curr;
            }
            set
            {
                if (_ws_misc_msg_curr != value)
                {
                    _ws_misc_msg_curr = value;
                    _ws_misc_msg_curr = _ws_misc_msg_curr.ToUpper();
                    RaisePropertyChanged("ws_misc_msg_curr");
                }
            }
        }

        private decimal _save_curr_1;
        public decimal save_curr_1
        {
            get
            {
                return _save_curr_1;
            }
            set
            {
                if (_save_curr_1 != value)
                {
                    _save_curr_1 = value;
                    RaisePropertyChanged("save_curr_1");
                }
            }
        }

        private decimal _save_prev_1;
        public decimal save_prev_1
        {
            get
            {
                return _save_prev_1;
            }
            set
            {
                if (_save_prev_1 != value)
                {
                    _save_prev_1 = value;
                    RaisePropertyChanged("save_prev_1");
                }
            }
        }

        private decimal _save_curr_2;
        public decimal save_curr_2
        {
            get
            {
                return _save_curr_2;
            }
            set
            {
                if (_save_curr_2 != value)
                {
                    _save_curr_2 = value;
                    RaisePropertyChanged("save_curr_2");
                }
            }
        }

        private decimal _save_prev_2;
        public decimal save_prev_2
        {
            get
            {
                return _save_prev_2;
            }
            set
            {
                if (_save_prev_2 != value)
                {
                    _save_prev_2 = value;
                    RaisePropertyChanged("save_prev_2");
                }
            }
        }

        private decimal _save_curr_3;
        public decimal save_curr_3
        {
            get
            {
                return _save_curr_3;
            }
            set
            {
                if (_save_curr_3 != value)
                {
                    _save_curr_3 = value;
                    RaisePropertyChanged("save_curr_3");
                }
            }
        }

        private decimal _save_prev_3;
        public decimal save_prev_3
        {
            get
            {
                return _save_prev_3;
            }
            set
            {
                if (_save_prev_3 != value)
                {
                    _save_prev_3 = value;
                    RaisePropertyChanged("save_prev_3");
                }
            }
        }

        private decimal _save_curr_4;
        public decimal save_curr_4
        {
            get
            {
                return _save_curr_4;
            }
            set
            {
                if (_save_curr_4 != value)
                {
                    _save_curr_4 = value;
                    RaisePropertyChanged("save_curr_4");
                }
            }
        }

        private decimal _save_prev_4;
        public decimal save_prev_4
        {
            get
            {
                return _save_prev_4;
            }
            set
            {
                if (_save_prev_4 != value)
                {
                    _save_prev_4 = value;
                    RaisePropertyChanged("save_prev_4");
                }
            }
        }

        private decimal _save_curr_5;
        public decimal save_curr_5
        {
            get
            {
                return _save_curr_5;
            }
            set
            {
                if (_save_curr_5 != value)
                {
                    _save_curr_5 = value;
                    RaisePropertyChanged("save_curr_5");
                }
            }
        }

        private decimal _save_prev_5;
        public decimal save_prev_5
        {
            get
            {
                return _save_prev_5;
            }
            set
            {
                if (_save_prev_5 != value)
                {
                    _save_prev_5 = value;
                    RaisePropertyChanged("save_prev_5");
                }
            }
        }

        private decimal _save_curr_6;
        public decimal save_curr_6
        {
            get
            {
                return _save_curr_6;
            }
            set
            {
                if (_save_curr_6 != value)
                {
                    _save_curr_6 = value;
                    RaisePropertyChanged("save_curr_6");
                }
            }
        }

        private decimal _save_prev_6;
        public decimal save_prev_6
        {
            get
            {
                return _save_prev_6;
            }
            set
            {
                if (_save_prev_6 != value)
                {
                    _save_prev_6 = value;
                    RaisePropertyChanged("save_prev_6");
                }
            }
        }

        private decimal _save_curr_7;
        public decimal save_curr_7
        {
            get
            {
                return _save_curr_7;
            }
            set
            {
                if (_save_curr_7 != value)
                {
                    _save_curr_7 = value;
                    RaisePropertyChanged("save_curr_7");
                }
            }
        }

        private decimal _save_prev_7;
        public decimal save_prev_7
        {
            get
            {
                return _save_prev_7;
            }
            set
            {
                if (_save_prev_7 != value)
                {
                    _save_prev_7 = value;
                    RaisePropertyChanged("save_prev_7");
                }
            }
        }

        private decimal _save_curr_8;
        public decimal save_curr_8
        {
            get
            {
                return _save_curr_8;
            }
            set
            {
                if (_save_curr_8 != value)
                {
                    _save_curr_8 = value;
                    RaisePropertyChanged("save_curr_8");
                }
            }
        }

        private decimal _save_prev_8;
        public decimal save_prev_8
        {
            get
            {
                return _save_prev_8;
            }
            set
            {
                if (_save_prev_8 != value)
                {
                    _save_prev_8 = value;
                    RaisePropertyChanged("save_prev_8");
                }
            }
        }

        private decimal _save_curr_9;
        public decimal save_curr_9
        {
            get
            {
                return _save_curr_9;
            }
            set
            {
                if (_save_curr_9 != value)
                {
                    _save_curr_9 = value;
                    RaisePropertyChanged("save_curr_9");
                }
            }
        }

        private decimal _save_prev_9;
        public decimal save_prev_9
        {
            get
            {
                return _save_prev_9;
            }
            set
            {
                if (_save_prev_9 != value)
                {
                    _save_prev_9 = value;
                    RaisePropertyChanged("save_prev_9");
                }
            }
        }

        private int _const_nbr_classes;
        public int const_nbr_classes
        {
            get
            {
                return _const_nbr_classes;
            }
            set
            {
                if (_const_nbr_classes != value)
                {
                    _const_nbr_classes = value;
                    RaisePropertyChanged("const_nbr_classes");
                }
            }
        }

        private string _const_class_ltr_1;
        public string const_class_ltr_1
        {
            get
            {
                return _const_class_ltr_1;
            }
            set
            {
                if (_const_class_ltr_1 != value)
                {
                    _const_class_ltr_1 = value;
                    RaisePropertyChanged("const_class_ltr_1");
                }
            }
        }

        private string _const_class_desc_1;
        public string const_class_desc_1
        {
            get
            {
                return _const_class_desc_1;
            }
            set
            {
                if (_const_class_desc_1 != value)
                {
                    _const_class_desc_1 = value;
                    _const_class_desc_1 = _const_class_desc_1.ToUpper();
                    RaisePropertyChanged("const_class_desc_1");
                }
            }
        }

        private string _const_class_ltr_2;
        public string const_class_ltr_2
        {
            get
            {
                return _const_class_ltr_2;
            }
            set
            {
                if (_const_class_ltr_2 != value)
                {
                    _const_class_ltr_2 = value;
                    RaisePropertyChanged("const_class_ltr_2");
                }
            }
        }

        private string _const_class_desc_2;
        public string const_class_desc_2
        {
            get
            {
                return _const_class_desc_2;
            }
            set
            {
                if (_const_class_desc_2 != value)
                {
                    _const_class_desc_2 = value;
                    _const_class_desc_2 = _const_class_desc_2.ToUpper();
                    RaisePropertyChanged("const_class_desc_2");
                }
            }
        }

        private string _const_class_ltr_3;
        public string const_class_ltr_3
        {
            get
            {
                return _const_class_ltr_3;
            }
            set
            {
                if (_const_class_ltr_3 != value)
                {
                    _const_class_ltr_3 = value;
                    RaisePropertyChanged("const_class_ltr_3");
                }
            }
        }

        private string _const_class_desc_3;
        public string const_class_desc_3
        {
            get
            {
                return _const_class_desc_3;
            }
            set
            {
                if (_const_class_desc_3 != value)
                {
                    _const_class_desc_3 = value;
                    _const_class_desc_3 = _const_class_desc_3.ToUpper();
                    RaisePropertyChanged("const_class_desc_3");
                }
            }
        }

        private string _const_class_ltr_4;
        public string const_class_ltr_4
        {
            get
            {
                return _const_class_ltr_4;
            }
            set
            {
                if (_const_class_ltr_4 != value)
                {
                    _const_class_ltr_4 = value;
                    RaisePropertyChanged("const_class_ltr_4");
                }
            }
        }

        private string _const_class_desc_4;
        public string const_class_desc_4
        {
            get
            {
                return _const_class_desc_4;
            }
            set
            {
                if (_const_class_desc_4 != value)
                {
                    _const_class_desc_4 = value;
                    _const_class_desc_4 = _const_class_desc_4.ToUpper();
                    RaisePropertyChanged("const_class_desc_4");
                }
            }
        }

        private string _const_class_ltr_5;
        public string const_class_ltr_5
        {
            get
            {
                return _const_class_ltr_5;
            }
            set
            {
                if (_const_class_ltr_5 != value)
                {
                    _const_class_ltr_5 = value;
                    RaisePropertyChanged("const_class_ltr_5");
                }
            }
        }

        private string _const_class_desc_5;
        public string const_class_desc_5
        {
            get
            {
                return _const_class_desc_5;
            }
            set
            {
                if (_const_class_desc_5 != value)
                {
                    _const_class_desc_5 = value;
                    _const_class_desc_5 = _const_class_desc_5.ToUpper();
                    RaisePropertyChanged("const_class_desc_5");
                }
            }
        }

        private string _const_class_ltr_6;
        public string const_class_ltr_6
        {
            get
            {
                return _const_class_ltr_6;
            }
            set
            {
                if (_const_class_ltr_6 != value)
                {
                    _const_class_ltr_6 = value;
                    RaisePropertyChanged("const_class_ltr_6");
                }
            }
        }

        private string _const_class_desc_6;
        public string const_class_desc_6
        {
            get
            {
                return _const_class_desc_6;
            }
            set
            {
                if (_const_class_desc_6 != value)
                {
                    _const_class_desc_6 = value;
                    _const_class_desc_6 = _const_class_desc_6.ToUpper();
                    RaisePropertyChanged("const_class_desc_6");
                }
            }
        }

        private string _const_class_ltr_7;
        public string const_class_ltr_7
        {
            get
            {
                return _const_class_ltr_7;
            }
            set
            {
                if (_const_class_ltr_7 != value)
                {
                    _const_class_ltr_7 = value;
                    RaisePropertyChanged("const_class_ltr_7");
                }
            }
        }

        private string _const_class_desc_7;
        public string const_class_desc_7
        {
            get
            {
                return _const_class_desc_7;
            }
            set
            {
                if (_const_class_desc_7 != value)
                {
                    _const_class_desc_7 = value;
                    _const_class_desc_7 = _const_class_desc_7.ToUpper();
                    RaisePropertyChanged("const_class_desc_7");
                }
            }
        }

        private string _const_class_ltr_8;
        public string const_class_ltr_8
        {
            get
            {
                return _const_class_ltr_8;
            }
            set
            {
                if (_const_class_ltr_8 != value)
                {
                    _const_class_ltr_8 = value;
                    RaisePropertyChanged("const_class_ltr_8");
                }
            }
        }

        private string _const_class_desc_8;
        public string const_class_desc_8
        {
            get
            {
                return _const_class_desc_8;
            }
            set
            {
                if (_const_class_desc_8 != value)
                {
                    _const_class_desc_8 = value;
                    _const_class_desc_8 = _const_class_desc_8.ToUpper();
                    RaisePropertyChanged("const_class_desc_8");
                }
            }
        }

        private string _const_class_ltr_9;
        public string const_class_ltr_9
        {
            get
            {
                return _const_class_ltr_9;
            }
            set
            {
                if (_const_class_ltr_9 != value)
                {
                    _const_class_ltr_9 = value;
                    RaisePropertyChanged("const_class_ltr_9");
                }
            }
        }

        private string _const_class_desc_9;
        public string const_class_desc_9
        {
            get
            {
                return _const_class_desc_9;
            }
            set
            {
                if (_const_class_desc_9 != value)
                {
                    _const_class_desc_9 = value;
                    _const_class_desc_9 = _const_class_desc_9.ToUpper();
                    RaisePropertyChanged("const_class_desc_9");
                }
            }
        }

        private string _const_class_ltr_10;
        public string const_class_ltr_10
        {
            get
            {
                return _const_class_ltr_10;
            }
            set
            {
                if (_const_class_ltr_10 != value)
                {
                    _const_class_ltr_10 = value;
                    RaisePropertyChanged("const_class_ltr_10");
                }
            }
        }

        private string _const_class_desc_10;
        public string const_class_desc_10
        {
            get
            {
                return _const_class_desc_10;
            }
            set
            {
                if (_const_class_desc_10 != value)
                {
                    _const_class_desc_10 = value;
                    _const_class_desc_10 = _const_class_desc_10.ToUpper();
                    RaisePropertyChanged("const_class_desc_10");
                }
            }
        }

        private string _const_class_ltr_11;
        public string const_class_ltr_11
        {
            get
            {
                return _const_class_ltr_11;
            }
            set
            {
                if (_const_class_ltr_11 != value)
                {
                    _const_class_ltr_11 = value;
                    RaisePropertyChanged("const_class_ltr_11");
                }
            }
        }

        private string _const_class_desc_11;
        public string const_class_desc_11
        {
            get
            {
                return _const_class_desc_11;
            }
            set
            {
                if (_const_class_desc_11 != value)
                {
                    _const_class_desc_11 = value;
                    _const_class_desc_11 = _const_class_desc_11.ToUpper();
                    RaisePropertyChanged("const_class_desc_11");
                }
            }
        }

        private string _const_class_ltr_12;
        public string const_class_ltr_12
        {
            get
            {
                return _const_class_ltr_12;
            }
            set
            {
                if (_const_class_ltr_12 != value)
                {
                    _const_class_ltr_12 = value;
                    RaisePropertyChanged("const_class_ltr_12");
                }
            }
        }

        private string _const_class_desc_12;
        public string const_class_desc_12
        {
            get
            {
                return _const_class_desc_12;
            }
            set
            {
                if (_const_class_desc_12 != value)
                {
                    _const_class_desc_12 = value;
                    _const_class_desc_12 = _const_class_desc_12.ToUpper();
                    RaisePropertyChanged("const_class_desc_12");
                }
            }
        }

        private string _const_class_ltr_13;
        public string const_class_ltr_13
        {
            get
            {
                return _const_class_ltr_13;
            }
            set
            {
                if (_const_class_ltr_13 != value)
                {
                    _const_class_ltr_13 = value;
                    RaisePropertyChanged("const_class_ltr_13");
                }
            }
        }

        private string _const_class_desc_13;
        public string const_class_desc_13
        {
            get
            {
                return _const_class_desc_13;
            }
            set
            {
                if (_const_class_desc_13 != value)
                {
                    _const_class_desc_13 = value;
                    _const_class_desc_13 = _const_class_desc_13.ToUpper();
                    RaisePropertyChanged("const_class_desc_13");
                }
            }
        }

        private string _const_class_ltr_14;
        public string const_class_ltr_14
        {
            get
            {
                return _const_class_ltr_14;
            }
            set
            {
                if (_const_class_ltr_14 != value)
                {
                    _const_class_ltr_14 = value;
                    RaisePropertyChanged("const_class_ltr_14");
                }
            }
        }

        private string _const_class_desc_14;
        public string const_class_desc_14
        {
            get
            {
                return _const_class_desc_14;
            }
            set
            {
                if (_const_class_desc_14 != value)
                {
                    _const_class_desc_14 = value;
                    _const_class_desc_14 = _const_class_desc_14.ToUpper();
                    RaisePropertyChanged("const_class_desc_14");
                }
            }
        }

        private string _const_class_ltr_15;
        public string const_class_ltr_15
        {
            get
            {
                return _const_class_ltr_15;
            }
            set
            {
                if (_const_class_ltr_15 != value)
                {
                    _const_class_ltr_15 = value;
                    RaisePropertyChanged("const_class_ltr_15");
                }
            }
        }

        private string _const_class_desc_15;
        public string const_class_desc_15
        {
            get
            {
                return _const_class_desc_15;
            }
            set
            {
                if (_const_class_desc_15 != value)
                {
                    _const_class_desc_15 = value;
                    _const_class_desc_15 = _const_class_desc_15.ToUpper();
                    RaisePropertyChanged("const_class_desc_15");
                }
            }
        }

        /*   private int[] _const_con_nbr;
           public int[] const_con_nbr
           {
               get
               {               
                   return _const_con_nbr;
               }
               set
               {
                   if (_const_con_nbr != value)
                   {
                       _const_con_nbr = value;               
                       RaisePropertyChanged("const_con_nbr");
                   }
               }
           } */


        private ObservableCollection<int> _const_con_nbr;
        public ObservableCollection<int> const_con_nbr
        {
            get
            {
                return _const_con_nbr;
            }
            set
            {
                if (_const_con_nbr != value)
                {
                    _const_con_nbr = value;
                    RaisePropertyChanged("const_con_nbr");
                }
            }
        }

        /*  private int[] _const_nx_avail_pat;
          public int[] const_nx_avail_pat
          {
              get
              {
                  return _const_nx_avail_pat;
              }
              set
              {
                  if (_const_nx_avail_pat != value)
                  {
                      _const_nx_avail_pat = value;
                      RaisePropertyChanged("const_nx_avail_pat");
                  }
              }
          } */

        private ObservableCollection<int> _const_nx_avail_pat;
        public ObservableCollection<int> const_nx_avail_pat
        {
            get
            {
                return _const_nx_avail_pat;
            }
            set
            {
                if (_const_nx_avail_pat != value)
                {
                    _const_nx_avail_pat = value;
                    RaisePropertyChanged("const_nx_avail_pat");
                }
            }
        }


        private int _iconst_clinic_nbr_1_2;
        public int iconst_clinic_nbr_1_2
        {
            get
            {
                return _iconst_clinic_nbr_1_2;
            }
            set
            {
                if (_iconst_clinic_nbr_1_2 != value)
                {
                    _iconst_clinic_nbr_1_2 = value;
                    RaisePropertyChanged("iconst_clinic_nbr_1_2");
                }
            }
        }

        private string _iconst_clinic_nbr;
        public string iconst_clinic_nbr
        {
            get
            {
                return _iconst_clinic_nbr;
            }
            set
            {
                if (_iconst_clinic_nbr != value)
                {
                    _iconst_clinic_nbr = value;
                    _iconst_clinic_nbr = _iconst_clinic_nbr.ToUpper();
                    RaisePropertyChanged("iconst_clinic_nbr");
                }
            }
        }

        private string _iconst_clinic_name;
        public string iconst_clinic_name
        {
            get
            {
                return _iconst_clinic_name;
            }
            set
            {
                if (_iconst_clinic_name != value)
                {
                    _iconst_clinic_name = value;
                    // _iconst_clinic_name = _iconst_clinic_name.ToUpper();
                    RaisePropertyChanged("iconst_clinic_name");
                }
            }
        }

        private int _iconst_clinic_cycle_nbr;
        public int iconst_clinic_cycle_nbr
        {
            get
            {
                return _iconst_clinic_cycle_nbr;
            }
            set
            {
                if (_iconst_clinic_cycle_nbr != value)
                {
                    _iconst_clinic_cycle_nbr = value;
                    RaisePropertyChanged("iconst_clinic_cycle_nbr");
                }
            }
        }

        private int _iconst_date_period_end_yy;
        public int iconst_date_period_end_yy
        {
            get
            {
                return _iconst_date_period_end_yy;
            }
            set
            {
                if (_iconst_date_period_end_yy != value)
                {
                    _iconst_date_period_end_yy = value;
                    RaisePropertyChanged("iconst_date_period_end_yy");
                }
            }
        }

        private int _iconst_date_period_end_mm;
        public int iconst_date_period_end_mm
        {
            get
            {
                return _iconst_date_period_end_mm;
            }
            set
            {
                if (_iconst_date_period_end_mm != value)
                {
                    _iconst_date_period_end_mm = value;
                    RaisePropertyChanged("iconst_date_period_end_mm");
                }
            }
        }

        private int _iconst_date_period_end_dd;
        public int iconst_date_period_end_dd
        {
            get
            {
                return _iconst_date_period_end_dd;
            }
            set
            {
                if (_iconst_date_period_end_dd != value)
                {
                    _iconst_date_period_end_dd = value;
                    RaisePropertyChanged("iconst_date_period_end_dd");
                }
            }
        }

        private string _iconst_clinic_card_colour;
        public string iconst_clinic_card_colour
        {
            get
            {
                return _iconst_clinic_card_colour;
            }
            set
            {
                if (_iconst_clinic_card_colour != value)
                {
                    _iconst_clinic_card_colour = value;
                    _iconst_clinic_card_colour = _iconst_clinic_card_colour.ToUpper();
                    RaisePropertyChanged("iconst_clinic_card_colour");
                }
            }
        }

        private string _iconst_clinic_addr_l1;
        public string iconst_clinic_addr_l1
        {
            get
            {
                return _iconst_clinic_addr_l1;
            }
            set
            {
                if (_iconst_clinic_addr_l1 != value)
                {
                    _iconst_clinic_addr_l1 = value;
                    // _iconst_clinic_addr_l1 = _iconst_clinic_addr_l1.ToUpper();
                    RaisePropertyChanged("iconst_clinic_addr_l1");
                }
            }
        }

        private string _iconst_clinic_addr_l2;
        public string iconst_clinic_addr_l2
        {
            get
            {
                return _iconst_clinic_addr_l2;
            }
            set
            {
                if (_iconst_clinic_addr_l2 != value)
                {
                    _iconst_clinic_addr_l2 = value;
                    //_iconst_clinic_addr_l2 = _iconst_clinic_addr_l2.ToUpper();
                    RaisePropertyChanged("iconst_clinic_addr_l2");
                }
            }
        }

        private string _iconst_clinic_addr_l3;
        public string iconst_clinic_addr_l3
        {
            get
            {
                return _iconst_clinic_addr_l3;
            }
            set
            {
                if (_iconst_clinic_addr_l3 != value)
                {
                    _iconst_clinic_addr_l3 = value;
                    // _iconst_clinic_addr_l3 = _iconst_clinic_addr_l3.ToUpper();
                    RaisePropertyChanged("iconst_clinic_addr_l3");
                }
            }
        }

        private decimal _iconst_clinic_over_lim1;
        public decimal iconst_clinic_over_lim1
        {
            get
            {
                return _iconst_clinic_over_lim1;
            }
            set
            {
                if (_iconst_clinic_over_lim1 != value)
                {
                    _iconst_clinic_over_lim1 = value;
                    RaisePropertyChanged("iconst_clinic_over_lim1");
                }
            }
        }

        private decimal _iconst_clinic_under_lim2;
        public decimal iconst_clinic_under_lim2
        {
            get
            {
                return _iconst_clinic_under_lim2;
            }
            set
            {
                if (_iconst_clinic_under_lim2 != value)
                {
                    _iconst_clinic_under_lim2 = value;
                    RaisePropertyChanged("iconst_clinic_under_lim2");
                }
            }
        }

        private decimal _iconst_clinic_under_lim3;
        public decimal iconst_clinic_under_lim3
        {
            get
            {
                return _iconst_clinic_under_lim3;
            }
            set
            {
                if (_iconst_clinic_under_lim3 != value)
                {
                    _iconst_clinic_under_lim3 = value;
                    RaisePropertyChanged("iconst_clinic_under_lim3");
                }
            }
        }

        private decimal _iconst_clinic_over_lim4;
        public decimal iconst_clinic_over_lim4
        {
            get
            {
                return _iconst_clinic_over_lim4;
            }
            set
            {
                if (_iconst_clinic_over_lim4 != value)
                {
                    _iconst_clinic_over_lim4 = value;
                    RaisePropertyChanged("iconst_clinic_over_lim4");
                }
            }
        }

        private string _iconst_clinic_pay_batch_nbr;
        public string iconst_clinic_pay_batch_nbr
        {
            get
            {
                return _iconst_clinic_pay_batch_nbr;
            }
            set
            {
                if (_iconst_clinic_pay_batch_nbr != value)
                {
                    _iconst_clinic_pay_batch_nbr = value;
                    _iconst_clinic_pay_batch_nbr = _iconst_clinic_pay_batch_nbr.ToUpper();
                    RaisePropertyChanged("iconst_clinic_pay_batch_nbr");
                }
            }
        }

        private int _iconst_clinic_batch_nbr;
        public int iconst_clinic_batch_nbr
        {
            get
            {
                return _iconst_clinic_batch_nbr;
            }
            set
            {
                if (_iconst_clinic_batch_nbr != value)
                {
                    _iconst_clinic_batch_nbr = value;
                    RaisePropertyChanged("iconst_clinic_batch_nbr");
                }
            }
        }

        private decimal _iconst_reduction_factor;
        public decimal iconst_reduction_factor
        {
            get
            {
                return _iconst_reduction_factor;
            }
            set
            {
                if (_iconst_reduction_factor != value)
                {
                    _iconst_reduction_factor = value;
                    RaisePropertyChanged("iconst_reduction_factor");
                }
            }
        }

        private decimal _iconst_overpay_factor;
        public decimal iconst_overpay_factor
        {
            get
            {
                return _iconst_overpay_factor;
            }
            set
            {
                if (_iconst_overpay_factor != value)
                {
                    _iconst_overpay_factor = value;
                    RaisePropertyChanged("iconst_overpay_factor");
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


        #endregion

        #region Working Storage Section
        private int temp;
        //private string ws_misc_msg_curr = "SEE DOC REC";
        private int i = 0;
        private int pline = 0;
        private int pcol1 = 0;
        private int pcol2 = 0;
        private int err_ind = 0;
        private int ws_class_nbr;
        //private string print_file_name = "rm090";
        //private string option;
        //private string ws_entered_password = "";
        //private string confirm_space = space;
        private string eof_const_mstr = "N";
        //private string status_file;
        private string status_const_mstr = "0";
        private string status_audit_rpt = "0";
        private string feedback_iconst_mstr = "0";
        private int const_mstr_rec_nbr;
        private int ws_const_mstr_rec_ident;
        private int ws_save_max_clinics;
        private int ws_save_max_rates;

        private string status_cobol_iconst_mstr_grp;
        private int status_cobol_iconst_mstr_1 = 0;
        private int status_cobol_iconst_mstr_2 = 0;

        //private string ws_const_mstr_ident_grp;
        private string ws_const_mstr_ident_1 = "";
        private string ws_const_mstr_ident_2 = "";

        private string save_misc_code_values_grp;
        private string save_misc_codes_curr_grp;
        //private decimal save_curr_1;
        //private decimal save_curr_2;
        //private decimal save_curr_3;
        //private decimal save_curr_4;
        //private decimal save_curr_5;
        //private decimal save_curr_6;
        //private decimal save_curr_7;
        //private decimal save_curr_8;
        //private decimal save_curr_9;
        private decimal save_curr_10;
        private string save_misc_codes_curr_r_grp;
        private decimal[] save_curr = new decimal[11];
        private string save_misc_codes_prev_grp;
        //private decimal save_prev_1;
        //private decimal save_prev_2;
        //private decimal save_prev_3;
        //private decimal save_prev_4;
        //private decimal save_prev_5;
        //private decimal save_prev_6;
        //private decimal save_prev_7;
        //private decimal save_prev_8;
        //private decimal save_prev_9;
        private decimal save_prev_10;
        private string save_misc_codes_prev_r_grp;
        private decimal[] save_prev = new decimal[11];
        private string class_flag;
        private string class_ok = "Y";
        private string class_not_ok = "N";
        private string password_flag;
        private string password_ok = "Y";
        private string password_not_ok = "N";
        //private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_lock;
        private string rec_locked = "Y";
        private string rec_not_locked = "N";

        private string counters_grp;
        //private int ctr_const_mstr_reads;
        //private int ctr_const_mstr_changes;
        //private int ctr_audit_rpt_writes;

        private string error_message_table_grp;
        private string error_messages_grp;
        /* private string filler = "invalid reply";
         private string filler = "invalid year";
         private string filler = "invalid month";
         private string filler = "invalid day";
         private string filler = "NO SUCH RECORD ON THE CONSTANTS MASTER";
         private string filler = "invalid password";
         private string filler = "PREVIOUS DATE NOT LESS THAN CURRENT";
         private string filler = "CLASS LETTER ALREADY IN USE";
         private string filler = "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply" , "invalid year", "invalid month", "invalid day", "NO SUCH RECORD ON THE CONSTANTS MASTER", "invalid password",
                                     "PREVIOUS DATE NOT LESS THAN CURRENT", "CLASS LETTER ALREADY IN USE","CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS"};
        //private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
        private string ws_valid_password = "RMAPR";

        private string month_descs_and_max_days_mth_grp;
        private string mth_desc_max_days_grp;
        /*private string filler = '31  january031';
        private string filler = '29 february059';
        private string filler = '31    march090';
        private string filler = '30    april120';
        private string filler = '31      may151';
        private string filler = '30     june181';
        private string filler = '31     july212';
        private string filler = '31   august243';
        private string filler = '30SEPTEMBER273';
        private string filler = '31  october304';
        private string filler = '30 november334';
        private string filler = '31 december365'; */
        private string mth_desc_max_days_r_grp;
        private string[] mth_desc_max_days_occur = new string[13];
        private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] mth_desc = { "", "january", "february", "march", "april", "may", "june", "july", "august", "SEPTEMBER", "october", "november", "december" };
        private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "M090        CONSTANTS MASTER MAINTENANCE -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 40,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "option",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 44,Data1 = "(CHANGE/INQUIRY)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-title-01-44"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 66,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_const_mstr_ident",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

        // new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input, NumericFormat="99",  MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

        // new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99", MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-types.",Line = "01",Col = 42,Data1 = "CHANGE - RECORD NUMBER:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-change-option"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-types.",Line = "01",Col = 42,Data1 = "INQUIRY - RECORD NUMBER:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-inquire-option"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "25",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "25",Col = 11,Data1 = "",RowStatus = rowStatus.DisplayInput,NumericFormat = "x(55)",MaxLength = 55,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-03.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-05.",Line = "05",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 80,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "02",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "04",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "05",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "06",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "07",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "08",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "09",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "10",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "11",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "12",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "13",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "14",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "15",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "16",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "17",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "18",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "19",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "20",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "21",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "22",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "23",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rest-of-page.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-add-chg.",Line = "24",Col = 30,Data1 = "ACCEPT (Y/N/M/P) ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-add-chg.",Line = "24",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 30,Data1 = "DELETE (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 45,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 66,Data1 = "PASSWORD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(5)",MaxLength = 5,RowDataType = rowDataType.AlphaNumericPassword,IsRequired = false,InputVariableName = "ws_entered_password",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 20,Data1 = "NUMBER OF CONST-MSTR READS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_const_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF CONST-MSTR CHANGES",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_const_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 20,Data1 = "NUMBER OF AUDIT RPT WRITES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_audit_rpt_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 18,Data1 = "PROGRAM M090 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 44,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 47,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 48,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 52,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 54,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 55,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 20,Data1 = "AUDIT REPORT IS IN FILE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "23",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(7)",MaxLength = 7,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "print_file_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "02",Col = 34,Data1 = "NBR. OF CLINICS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "02",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_max_nbr_clinics",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 4,Data1 = "CLINIC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 12,Data1 = "GROUP ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 24,Data1 = "CLINIC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 32,Data1 = "GROUP ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 44,Data1 = "CLINIC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 52,Data1 = "GROUP ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 64,Data1 = "CLINIC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "03",Col = 72,Data1 = "GROUP ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_20",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-20"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_20",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-20"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_21",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-21"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_21",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-21"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_22",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-22"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_22",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-22"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-23"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-23"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_24",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-24"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_24",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-24"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_25",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-25"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_25",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-25"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_26",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-26"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_26",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-26"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_27",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-27"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_27",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-27"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_28",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-28"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_28",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-28"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_29",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-29"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_29",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-29"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_30",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-30"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_30",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-30"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_31",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-31"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_31",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-31"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_32",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-32"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_32",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-32"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_33",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-33"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_33",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-33"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_34",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-34"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_34",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-34"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_35",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-35"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_35",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-35"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_36",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-36"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_36",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-36"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_37",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-37"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_37",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-37"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_38",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-38"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_38",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-38"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_39",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-39"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_39",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-39"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_40",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-40"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_40",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-40"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_41",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-41"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_41",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-41"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_42",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-42"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_42",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-42"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_43",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-43"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_43",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-43"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_44",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-44"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_44",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-44"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_45",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-45"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_45",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-45"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_46",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-46"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_46",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-46"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_47",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-47"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_47",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-47"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_48",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-48"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_48",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-48"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_49",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-49"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_49",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-49"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_50",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-50"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_50",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-50"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_51",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-51"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_51",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-51"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_52",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-52"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_52",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-52"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_53",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-53"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_53",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-53"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_54",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-54"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_54",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-54"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_55",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-55"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_55",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-55"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_56",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-56"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_56",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-56"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_57",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-57"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_57",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-57"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_58",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-58"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_58",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-58"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_59",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-59"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_59",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-59"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_60",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-60"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_60",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-60"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_61",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-61"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_61",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-61"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_62",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-62"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_62",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-62"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_63",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-1-2-nbr-63"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_63",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr-63"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 10,Data1 = "IN EFFECT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 25,Data1 = "WCB",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 35,Data1 = "BILATERAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 47,Data1 = "IND.CONSIDERATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 67,Data1 = "SECT.REDUCTION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 1,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 9,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_yy_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-yy-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 13,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_mm_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-mm-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 16,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_dd_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dd-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 21,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.9(5)",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_wcb_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-wcb-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 36,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_bilateral_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-bi-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 53,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_ic_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ic-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 71,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_sr_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sr-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 1,Data1 = "PREV.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 9,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_yy_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 13,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_mm_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 16,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_dd_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.9(5)",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_wcb_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_bilateral_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_ic_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_sr_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "07",Col = 7,Data1 = "-------------OHIP--------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "07",Col = 51,Data1 = "------------OMA---------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 8,Data1 = "ASST.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 17,Data1 = "REG.ANAE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 29,Data1 = "CERT.ANAE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 52,Data1 = "ASST.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 60,Data1 = "REG.ANAE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "08",Col = 72,Data1 = "CERT.ANAE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 1,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_asst_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-asst-h-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_reg_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reg-h-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_cert_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-cert-h-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_asst_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-asst-a-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 61,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_reg_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reg-a-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 74,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_cert_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-cert-a-curr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 1,Data1 = "PREV",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 74,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "12",Col = 18,Data1 = "GROUP REDUCTION RATES (",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "12",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_max_nbr_rates",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nbr-rates"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "12",Col = 44,Data1 = "OUT OF 19 IN USE)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 1,Data1 = "SEC.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 5,Data1 = "GROUP",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 12,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 19,Data1 = "PREV.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 30,Data1 = "SEC.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 35,Data1 = "GROUP",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 42,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 48,Data1 = "PREV.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 59,Data1 = "SEC.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 64,Data1 = "GROUP",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 70,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "13",Col = 76,Data1 = "PREV.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_group_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 65,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 69,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sect-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_group_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-group-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 11,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = true,InputVariableName = "const_curr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.NumericBlankWhenZero,IsRequired = false,InputVariableName = "const_prev_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 9,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_yy_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-yy-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 14,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_mm_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-mm-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_dd_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-dd-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 21,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.9(5)",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_wcb_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-wcb-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 36,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_bilateral_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-bi-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 53,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_ic_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ic-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 71,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_sr_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sr-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 7,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-asst-h-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reg-h-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 31,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-cert-h-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-asst-a-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 61,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reg-a-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 74,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-cert-a-prev"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-16"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 47,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-17"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 75,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-18"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-19"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 20,Data1 = "MISC.CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 35,Data1 = "CURRENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 48,Data1 = "PREVIOUS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "04",Col = 33,Data1 = "FISCAL YEAR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "04",Col = 46,Data1 = "FISCAL YEAR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 24,Data1 = "0",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         //new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 33,Data1 = "SEE DOC REC",RowStatus = rowStatus.Display,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_misc_msg_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 33,Data1 = "SEE DOC REC",RowStatus = rowStatus.Display,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 51,Data1 = "----",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 24,Data1 = "1",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 24,Data1 = "2",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 24,Data1 = "3",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 24,Data1 = "4",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 24,Data1 = "5",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 24,Data1 = "6",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 24,Data1 = "7",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 24,Data1 = "8",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 24,Data1 = "9",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-misc-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rec-3-warning.",Line = "18",Col = 10,Data1 = "***WARNING***",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rec-3-warning.",Line = "18",Col = 33,Data1 = "ONCE ACCEPTED, THESE VALUES CANNOT BE CHANGED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 25,Data1 = "CLASS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 34,Data1 = "DESCRIPTION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 57,Data1 = "NBR.OF CLASSES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nbr_classes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nbr-classes"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "05",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "05",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "06",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "06",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "07",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "07",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "08",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "08",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "09",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "09",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-5"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "10",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "10",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-6"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "11",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "11",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-7"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "12",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "12",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-8"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "13",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "13",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-9"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "14",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "14",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "15",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "15",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-11"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "16",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "16",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-12"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "17",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "17",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-13"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "18",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "18",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-14"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "19",Col = 27,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_ltr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ltr-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "19",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc-15"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "03",Col = 11,Data1 = "CON #",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "03",Col = 20,Data1 = "NX AVAIL PATIENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "03",Col = 48,Data1 = "CON #",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "03",Col = 57,Data1 = "NX AVAIL PATIENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "05",Col = 4,Data1 = "CON01",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "05",Col = 41,Data1 = "CON14",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "06",Col = 4,Data1 = "CON02",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "06",Col = 41,Data1 = "CON15",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "07",Col = 4,Data1 = "CON03",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "07",Col = 41,Data1 = "CON16",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "08",Col = 4,Data1 = "CON04",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "08",Col = 41,Data1 = "CON17",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "09",Col = 4,Data1 = "CON05",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "09",Col = 41,Data1 = "CON18",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "10",Col = 4,Data1 = "CON06",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "10",Col = 41,Data1 = "CON19",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "11",Col = 4,Data1 = "CON07",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "11",Col = 41,Data1 = "CON20",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "12",Col = 4,Data1 = "CON08",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "12",Col = 41,Data1 = "CON21",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "13",Col = 4,Data1 = "CON09",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "13",Col = 41,Data1 = "CON22",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "14",Col = 4,Data1 = "CON10",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "14",Col = 41,Data1 = "CON23",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "15",Col = 4,Data1 = "CON11",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "15",Col = 41,Data1 = "CON24",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "16",Col = 4,Data1 = "CON12",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "16",Col = 41,Data1 = "CON25",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5-lit.",Line = "17",Col = 4,Data1 = "CON13",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         // todo
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "5",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[1]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr613"}, // scr-con-nbr613 where line = 6 and col = 13    // Todo for multiline...???

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "6",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[2]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr713"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "7",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[3]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr813"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "8",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[4]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr913"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "9",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[5]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1013"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "10",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[6]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1113"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "11",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[7]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1213"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[8]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1313"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "13",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[9]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1413"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "14",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[10]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1513"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "15",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[11]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1613"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "16",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[12]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1713"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "17",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[13]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1813"},


         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "5",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[14]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr650"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "6",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[15]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr750"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "7",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[16]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr850"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "8",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[17]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr950"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "9",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[18]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1050"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "10",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[19]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1150"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "11",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[20]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1250"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[21]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1350"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "13",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[22]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1450"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "14",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[23]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1550"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "15",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[24]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1650"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "16",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[25]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1750"},

         //new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "17",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr[26]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-con-nbr1850"},


         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "5",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[1]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat620"},  // scr-nx-avail-pat620 where line = 6 and col = 20  // Todo for multiline...???

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "6",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[2]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat720"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "7",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[3]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat820"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "8",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[4]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat920"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "9",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[5]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1020"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "10",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[6]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1120"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "11",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[7]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1220"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[8]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1320"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "13",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[9]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1420"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "14",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[10]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1520"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "15",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[11]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1620"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "16",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[12]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1720"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "17",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[13]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1820"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "5",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[14]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat657"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "6",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[15]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat757"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "7",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[16]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat857"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "8",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[17]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat957"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "9",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[18]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1057"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "10",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[19]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1157"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "11",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[20]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1257"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[21]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1357"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "13",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[22]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1457"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "14",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[23]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1557"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "15",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[24]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1657"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "16",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat[25]",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-nx-avail-pat1757"},


         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 4,Data1 = "CLINIC IDENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 18,Data1 = "CLINIC",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 30,Data1 = "CLINIC NAME",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 48,Data1 = "CYCLE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 55,Data1 = "PERIOD END DATE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "05",Col = 74,Data1 = "AFP",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "06",Col = 73,Data1 = "FLAG",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "09",Col = 30,Data1 = "CLINIC ADDRESS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "15",Col = 4,Data1 = "OVERPAYMENT WRITEOFF LIMIT  1",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "16",Col = 4,Data1 = "UNDERPAYMENT WRITEOFF LIMIT 2 (NOT IN PAYCODE TABLE)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "17",Col = 4,Data1 = "UNDERPAYMENT WRITEOFF LIMIT 3 (IN PAYCODE TABLE)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "18",Col = 4,Data1 = "OVERPAYMENT WRITEOFF LIMIT  4",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "19",Col = 4,Data1 = "NEXT AVAILABLE PAYMENT BATCH NUMBER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "20",Col = 4,Data1 = "NEXT AVAILABLE BATCH NUMBER",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "21",Col = 4,Data1 = "REDUCTION FACTOR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "22",Col = 4,Data1 = "OVERPAY   FACTOR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-ident"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 19,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)",MaxLength = 20,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-name"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 50,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_cycle_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-cycle"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 58,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-date-period-end-yy"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 62,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 63,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-date-period-end-mm"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 65,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 66,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-date-period-end-dd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 76,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_card_colour",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-card-colour"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-addr-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "12",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-addr-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "13",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-addr-3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "15",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_over_lim1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-over-lim1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "16",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_under_lim2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-under-lim2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "17",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_under_lim3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-under-lim3"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "18",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_over_lim4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-over-lim4"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "19",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_pay_batch_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-pay-batch-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "20",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(6)",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_batch_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-clinic-batch-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "21",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_reduction_factor",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-reduction-factor"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "22",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_overpay_factor",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-overpay-factor"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "23",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         //....
       
        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {
        }

        private async Task err_iconst_mstr_file_section()
        {
            //     use after standard error procedure on iconst-mstr.;
        }

        private async Task err_iconst_mstr()
        {
            //     if status-cobol-iconst-mstr-1 = "9";
            //     then;
            //err_ind = 9;
            // 	perform za0-common-error	thru za0-99-exit;
            //flag_lock = "Y";
            //   else;
            //status_file = status_cobol_iconst_mstr;
            // 	display file-status-display;
            // 	stop "ERROR IN ACCESSING ISAM CONSTANTS MASTER";
            // 	stop run.;

            if (status_cobol_iconst_mstr_1.Equals("9"))
            {
                err_ind = 9;
                za0_common_error();
                za0_99_exit();
                flag_lock = "Y";
            }
            else
            {
                status_file = status_cobol_iconst_mstr_grp;
                Display("file-status-display.");
            }

        }
        private async Task err_audit_rpt_file_section()
        {
            //     use after standard error procedure on audit-file.;
        }
        private async Task err_audit_rpt()
        {
            status_file = status_audit_rpt;
            //     display file-status-display.;
            //     stop "ERROR IN WRITING TO AUDIT REPORT FILE".;
            //     stop run.;
            Display("file-status-display.");
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {
        }

        private async Task initialize_objects()
        {
            objAudit_record = null;
            objAudit_record = new Audit_record();
            ObservableCollection<Audit_record> Audit_record_Collection;

            objAudit_File = null;
            objAudit_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + print_file_name, false);

            objIconst_mstr_rec = null;
            objIconst_mstr_rec = new ICONST_MSTR_REC();
            Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

            objConstants_mstr_rec_1 = null;
            objConstants_mstr_rec_1 = new CONSTANTS_MSTR_REC_1();
            Constants_mstr_rec_1_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();


            objConstants_mstr_rec_2 = null;
            objConstants_mstr_rec_2 = new CONSTANTS_MSTR_REC_2();
            Constants_mstr_rec_2_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();


            objConstants_mstr_rec_3 = null;
            objConstants_mstr_rec_3 = new CONSTANTS_MSTR_REC_3();
            Constants_mstr_rec_3_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_3>();


            objConstants_mstr_rec_4 = null;
            objConstants_mstr_rec_4 = new CONSTANTS_MSTR_REC_4();
            Constants_mstr_rec_4_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_4>();

            objConstants_mstr_rec_5 = null;
            objConstants_mstr_rec_5 = new CONSTANTS_MSTR_REC_5();
            Constants_mstr_rec_5_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();

            objConstants_mstr_rec_6 = null;
            objConstants_mstr_rec_6 = new CONSTANTS_MSTR_REC_6();
            Constants_mstr_rec_6_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_6>();

            objConstants_mstr_rec_7 = null;
            objConstants_mstr_rec_7 = new CONSTANTS_MSTR_REC_7();
            Constants_mstr_rec_7_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_7>();
        }

        public async void mainline()
        {
            try {

                await initialize_objects();
                //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit.;
                while (!Util.Str(option).ToUpper().Equals("*"))
                {
                    if (Util.Str(option).ToUpper().Equals("I") || Util.Str(option).ToUpper().Equals("C"))
                    {
                        // next statement                
                    }
                    else
                    {
                        if (!await ab0_processing())    // break;
                        {
                            await az0_99_exit();
                            return;
                        }
                    }
                    await ab0_10_acpt_rec_nbr();
                    while (!Util.Str(ws_const_mstr_ident_1).Equals("*"))
                    {
                        if (flag.ToUpper() != "M")
                        {
                            await ab0_100_continue();
                        }
                        await ab0_200_verify();
                        await ab0_99_exit();
                    }
                }

                //     perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_99_exit();
            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {

                }
            }

            //     chain "$obj/menu".;
        }

        private async Task aa0_initialization()
        {

            //     accept sys-date			from date.;
            sys_date_grp = DateTime.Now.ToString();
            sys_date_long_child = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            sys_date_long_r_child_redefines = sys_date_long_child;
            sys_yy = DateTime.Now.Year.ToString();
            sys_yy_alpha_child_redefines = sys_yy_child.ToString();
            sys_y1 = Util.NumInt(DateTime.Now.Year.ToString().Substring(0, 1));
            sys_y2 = Util.NumInt(DateTime.Now.Year.ToString().Substring(1, 1));
            sys_y3 = Util.NumInt(DateTime.Now.Year.ToString().Substring(2, 1));
            sys_y4 = Util.NumInt(DateTime.Now.Year.ToString().Substring(3, 1));
            sys_mm = DateTime.Now.Month.ToString().PadLeft(2, '0');
            sys_dd = DateTime.Now.Day.ToString().PadLeft(2, '0');

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            await y2k_default_sysdate();
            await y2k_default_sysdate_exit();

            run_mm = Util.NumInt(sys_mm);
            run_dd = Util.NumInt(sys_dd);
            run_yy = Util.NumInt(sys_yy);

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
            //     open i-o iconst-mstr.;
            //     open output audit-file.;
        }
        private async Task aa0_99_exit()
        {
            //     exit.;
        }
        private async Task<bool> ab0_processing()
        {
            option = "";
            ws_const_mstr_ident = "";

            //     display scr-title.;
            //     accept scr-acpt-option.;
            Display("scr-title.");
            await Prompt("option");

            //     if option = "C";
            //     then;
            // 	display scr-change-option;
            //     else;
            // 	if option = "I";
            // 	then;
            // 	    display scr-inquire-option;
            // 	else;
            // 	    if option = "*";
            // 	    then;
            // 		go to ab0-99-exit;
            // 	    else;
            //  err_ind = 1;
            // 	    	perform za0-common-error;
            // 					thru za0-99-exit;
            // 		go to ab0-processing.;

            if (option.ToUpper().Equals("C"))
            {
                Display("scr-title.", "scr-title-01-44", false);
                Display("scr-types.", "scr-change-option");
            }
            else if (option.ToUpper().Equals("I"))
            {
                Display("scr-title.", "scr-title-01-44", false);
                Display("scr-types.", "scr-inquire-option");
            }
            else if (option.ToUpper().Equals("*"))
            {
                //await ab0_99_exit();
                //return false;               

                if (ExitCobol != null)
                {
                    ExitCobol();
                }
                throw new Exception(endOfJob);
                return true;
            }
            else
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                await ab0_processing();
                return true;
            }
            return true;
        }

        private async Task ab0_10_acpt_rec_nbr()
        {

            ws_const_mstr_ident = "";
            //     display scr-rec-nbr.;
            //     accept scr-rec-nbr.;

            //Display("scr-rec-nbr.");
            await Prompt("ws_const_mstr_ident");

            //     if ws-const-mstr-ident-1 = "*" then;             
            // 	        go to ab0-processing;
            //     else if    ws-const-mstr-ident-1 = spaces  and ws-const-mstr-ident-2   numeric then;            
            //           objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident_2;
            // 	   else if   ws-const-mstr-ident-1   numeric and ws-const-mstr-ident-2 = spaces then;            
            // 		    if ws-const-mstr-ident-1 <> 6 then            
            //             objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident_1;
            // 		    else
            //              err_ind = 1;
            // 		        perform za0-common-error	thru	za0-99-exit;
            // 	    else if    ws-const-mstr-ident numeric and ws-const-mstr-ident <> "06" then            
            //           objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident;
            // 		else;
            //           err_ind = 1;
            // 		     perform za0-common-error	thru	za0-99-exit;
            // 		    go to ab0-10-acpt-rec-nbr.;

            ws_const_mstr_ident_1 = ws_const_mstr_ident.PadRight(2, ' ').Substring(0, 1);
            ws_const_mstr_ident_2 = ws_const_mstr_ident.PadRight(2, ' ').Substring(1, 1);


            if (ws_const_mstr_ident_1.Equals("*"))
            {
                await ab0_processing();
                return;
            }
            else if (string.IsNullOrWhiteSpace(ws_const_mstr_ident_1) && Util.IsNumeric(ws_const_mstr_ident_2))
            {
                //objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2  = Util.NumInt(ws_const_mstr_ident_2);
                iconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident_2);
            }
            else if (Util.IsNumeric(ws_const_mstr_ident_1) && string.IsNullOrWhiteSpace(ws_const_mstr_ident_2))
            {
                if (Util.NumInt(ws_const_mstr_ident_1) != 6)
                {
                    //objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = Util.NumInt(ws_const_mstr_ident_1);
                    iconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident_1);
                }
                else
                {
                    err_ind = 1;
                    await za0_common_error();
                    await za0_99_exit();
                    await ab0_10_acpt_rec_nbr();
                    return;
                }
            }
            else if (Util.IsNumeric(ws_const_mstr_ident) && !ws_const_mstr_ident.Equals("06"))
            {
                //objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = Util.NumInt(ws_const_mstr_ident);
                iconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident);
            }
            else
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                await ab0_10_acpt_rec_nbr();
                return;
            }

            //     display blank-rest-of-page.;
            //     flag = "Y";
            //     perform ma1-read-iconst-mstr		thru	ma1-99-exit.;
            //     if not-ok then;            
            //        err_ind = 5;
            // 	      perform za0-common-error	thru za0-99-exit;
            // 	      go to ab0-10-acpt-rec-nbr.;

            Display("blank-rest-of-page.");
            flag = "Y";
            await ma1_read_iconst_mstr();
            await ma1_99_exit();

            if (flag.Equals(not_ok))
            {
                err_ind = 5;
                await za0_common_error();
                await za0_99_exit();
                await ab0_10_acpt_rec_nbr();
                return;
            }
        }

        private async Task ab0_100_continue()
        {

            //  if iconst-clinic-nbr-1-2 = 1 then            
            // 	     perform ba0-const-mstr-1-routine	thru	ba0-99-exit;
            //  else if iconst-clinic-nbr-1-2 = 2 then;            
            // 	    perform ca0-const-mstr-2-curr   	thru	ca0-99-exit;
            // 	else if iconst-clinic-nbr-1-2 = 3  then            
            // 	 	perform ga0-const-mstr-3-routine thru	ga0-99-exit;
            // 	else if iconst-clinic-nbr-1-2 = 4 then            
            // 	 	  perform ha0-const-mstr-4-routine;
            // 						thru	ha0-99-exit;
            //   else if iconst-clinic-nbr-1-2 = 5  then            
            // 			perform ia0-const-mstr-5-routine;
            // 						thru 	ia0-99-exit;
            //   else;
            // 	      	perform fa0-isam-const-mstr-routine;
            // 						thru	fa0-99-exit.;

            if (iconst_clinic_nbr_1_2 == 1)
            {
                await ba0_const_mstr_1_routine();
                await ba0_10_clear_clinics();
                await ba0_99_exit();
            }
            else if (iconst_clinic_nbr_1_2 == 2)
            {
                await ca0_const_mstr_2_curr();
                await ca0_99_exit();
            }
            else if (iconst_clinic_nbr_1_2 == 3)
            {
                await ga0_const_mstr_3_routine();
                await ga0_99_exit();
            }
            else if (iconst_clinic_nbr_1_2 == 4)
            {
                await ha0_const_mstr_4_routine();
                if (Util.Str(option).ToUpper().Equals("I"))
                {
                    return;
                }
                if (!await ha0_class_2())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_3())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_4())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_5())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_6())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_7())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_8())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_9())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_10())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_11())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_12())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_13())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_14())
                {
                    await ha0_100_continue();
                    return;
                }
                if (!await ha0_class_15())
                {
                    await ha0_100_continue();
                    return;
                }

                await ha0_100_continue();
                await ha0_99_exit();
            }
            else if (iconst_clinic_nbr_1_2 == 5)
            {
                await ia0_const_mstr_5_routine();
                await ia0_99_exit();
            }
            else
            {
                await fa0_isam_const_mstr_routine();
                if (!Util.Str(option).ToUpper().Equals("I"))
                {
                    await fa0_10();
                    await fa0_20();
                    await fa0_30();
                }
                await fa0_99_exit();
            }

        }

        private async Task ab0_200_verify()
        {

            //  if option = "I" then;            
            //    	go to ab0-10-acpt-rec-nbr.;


            if (option.ToUpper().Equals("I"))
            {
                await ab0_10_acpt_rec_nbr();
                return;
            }

            //     display verification-screen-add-chg.;
            //     accept verification-screen-add-chg.;
            flag = "";
            Display("verification-screen-add-chg.");
            await Prompt("flag");

            //  if flag = "Y" then            
            //   	if const-rec-1-rec-nbr = 3 then;            
            // 	        perform ga2-convert-for-conmstr	thru	ga2-99-exit;
            // 		         varying	temp;
            // 			     from 1 by 1;
            // 		        until	temp > 9;
            // 	        perform pa1-re-write-iconst-mstr	thru	pa1-99-exit;
            // 	        perform ra0-write-audit-rpt	thru	ra0-99-exit;
            // 	        go to ab0-10-acpt-rec-nbr;
            //    	else
            // 	        perform pa1-re-write-iconst-mstr	thru	pa1-99-exit;
            // 	        perform ra0-write-audit-rpt		thru	ra0-99-exit;
            // 	        go to ab0-10-acpt-rec-nbr.;



            if (flag.ToUpper().Equals("Y"))
            {
                if (Util.NumInt(ws_const_mstr_ident) == 3)  // if const-rec-1-rec-nbr = 3 then;  // todo...
                {
                    temp = 1;
                    do
                    {
                        await ga2_convert_for_conmstr();
                        await ga2_99_exit();
                        temp++;
                    } while (temp <= 9);
                    await pa1_re_write_iconst_mstr();
                    await pa1_99_exit();

                    await ra0_write_audit_rpt();
                    await ra0_99_exit();

                    await ab0_10_acpt_rec_nbr();
                    return;
                }
                else
                {
                    await pa1_re_write_iconst_mstr();
                    await pa1_99_exit();

                    await ra0_write_audit_rpt();
                    await ra0_99_exit();

                    await ab0_10_acpt_rec_nbr();
                    return;
                }
            }

            //  if flag = "N" then;            
            // 	    display scr-reject-entry;
            // 	    display confirm;
            // 	    stop " ";
            // 	    display blank-line-24;
            // 	    go to ab0-10-acpt-rec-nbr.;

            if (flag.ToUpper().Equals("N"))
            {
                Display("scr-reject-entry.");
                Display("confirm.");
                await Prompt("confirm");
                Display("confirm.", false);

                Display("blank-line-24.");

                await ab0_10_acpt_rec_nbr();
                return;
            }

            //  if flag = "M" then;            
            // 	    go to ab0-100-continue;
            //  else if    flag = "P" and iconst-clinic-nbr-1-2 = 2  then            
            //      flag = "";
            // 	    perform da0-password		thru	da0-99-exit;
            // 	    if password-ok then            
            // 		    perform da1-const-mstr-2-prev	thru	da1-99-exit;
            // 	    	go to ab0-200-verify;
            // 	    else;
            //          err_ind = 6;
            // 	  	    perform za0-common-error	thru	za0-99-exit;
            // 	 	    go to ab0-200-verify;
            // 	else;
            //      err_ind = 1;
            // 	    perform za0-common-error		thru	za0-99-exit;
            // 	    go to ab0-200-verify.;

            if (flag.ToUpper().Equals("M"))
            {
                await ab0_100_continue();
                return;
            }
            else if (flag.ToUpper().Equals("P") && iconst_clinic_nbr_1_2 == 2)  // and iconst-clinic-nbr-1-2 = 2  then  
            {
                flag = "";
                await da0_password();
                await da0_99_exit();
                if (password_flag.Equals(password_ok))
                {
                    await da1_const_mstr_2_prev();
                    await da1_99_exit();
                    await ab0_200_verify();
                    return;
                }
                else
                {
                    err_ind = 6;
                    await za0_common_error();
                    await za0_99_exit();
                    await ab0_200_verify();
                    return;
                }
            }
            else
            {
                err_ind = 1;
                await za0_common_error();
                await za0_99_exit();
                await ab0_200_verify();
                return;
            }
        }

        private async Task ab0_99_exit()
        {
            //     exit.;
        }

        private async Task ba0_const_mstr_1_routine()
        {

            //     if flag not = "M";
            //     then;
            // 	display scr-mask1.;

            if (!flag.ToUpper().Equals("M"))
            {
                Display("scr-mask1.");
            }

            //     if option = "I";
            //     then;
            // 	go to ba0-99-exit.;

            if (option.ToUpper().Equals("I"))
            {
                await ba0_99_exit();
                return;
            }

            //     accept scr-clinic-1-2-nbr-1.;
            await Prompt("const_clinic_1_2_nbr_1");

            // if const-clinic-1-2-nbr-1 = zero then;            
            //     objConstants_mstr_rec_1.const_max_nbr_clinics = 0;
            // 	go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_1 == 0)
            {
                const_max_nbr_clinics = 0;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-1.;
            await Prompt("const_clinic_nbr_1");

            //     accept scr-clinic-1-2-nbr-2.;
            await Prompt("const_clinic_1_2_nbr_2");

            //     if const-clinic-1-2-nbr-2 = zero then;                
            //          objConstants_mstr_rec_1.const_max_nbr_clinics = 1;
            // 	        go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_2 == 0)
            {
                //objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS = 1M;
                const_max_nbr_clinics = 1;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-2.;
            await Prompt("const_clinic_nbr_2");

            //     accept scr-clinic-1-2-nbr-3.;
            await Prompt("const_clinic_1_2_nbr_3");

            //     if const-clinic-1-2-nbr-3 = zero then;            
            //         objConstants_mstr_rec_1.const_max_nbr_clinics = 2;
            // 	       go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_3 == 0)
            {
                const_max_nbr_clinics = 2;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-3.;
            await Prompt("const_clinic_nbr_3");

            //     accept scr-clinic-1-2-nbr-4.;
            await Prompt("const_clinic_1_2_nbr_4");

            //     if const-clinic-1-2-nbr-4 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 3;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_4 == 0)
            {
                const_max_nbr_clinics = 3;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-4.;
            await Prompt("const_clinic_nbr_4");

            //     accept scr-clinic-1-2-nbr-5.;
            await Prompt("const_clinic_1_2_nbr_5");

            //     if const-clinic-1-2-nbr-5 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 4;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_5 == 0)
            {
                const_max_nbr_clinics = 4;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-5.;
            await Prompt("const_clinic_nbr_5");


            //     accept scr-clinic-1-2-nbr-6.;
            await Prompt("const_clinic_1_2_nbr_6");

            //     if const-clinic-1-2-nbr-6 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 5;
            // 	       go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_6 == 0)
            {
                //objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS = 5M;
                const_max_nbr_clinics = 5;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-6.;
            await Prompt("const_clinic_nbr_6");

            //     accept scr-clinic-1-2-nbr-7.;
            await Prompt("const_clinic_1_2_nbr_7");

            //     if const-clinic-1-2-nbr-7 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 6;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_7 == 0)
            {
                const_max_nbr_clinics = 6;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-7.;
            await Prompt("const_clinic_nbr_7");

            //     accept scr-clinic-1-2-nbr-8.;
            await Prompt("const_clinic_1_2_nbr_8");

            //     if const-clinic-1-2-nbr-8 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 7;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_8 == 0)
            {
                const_max_nbr_clinics = 7;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-8.;
            await Prompt("const_clinic_nbr_8");

            //     accept scr-clinic-1-2-nbr-9.;
            await Prompt("const_clinic_1_2_nbr_9");

            //     if const-clinic-1-2-nbr-9 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 8;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_9 == 0)
            {
                const_max_nbr_clinics = 8;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-9.;
            await Prompt("const_clinic_nbr_9");

            //     accept scr-clinic-1-2-nbr-10.;
            await Prompt("const_clinic_1_2_nbr_10");

            //     if const-clinic-1-2-nbr-10 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 9;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_10 == 0)
            {
                const_max_nbr_clinics = 9;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-10.;
            await Prompt("const_clinic_nbr_10");

            //     accept scr-clinic-1-2-nbr-11.;
            await Prompt("const_clinic_1_2_nbr_11");

            //     if const-clinic-1-2-nbr-11 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 10;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_11 == 0)
            {
                const_max_nbr_clinics = 10;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-11.;
            await Prompt("const_clinic_nbr_11");

            //     accept scr-clinic-1-2-nbr-12.;
            await Prompt("const_clinic_1_2_nbr_12");

            //     if const-clinic-1-2-nbr-12 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 11;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_12 == 0)
            {
                const_max_nbr_clinics = 11;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-12.;
            await Prompt("const_clinic_nbr_12");

            //     accept scr-clinic-1-2-nbr-13.;
            await Prompt("const_clinic_1_2_nbr_13");

            //     if const-clinic-1-2-nbr-13 = zero then;            
            //       objConstants_mstr_rec_1.const_max_nbr_clinics = 12;
            // 	     go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_13 == 0)
            {
                const_max_nbr_clinics = 12;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-13.;
            await Prompt("const_clinic_nbr_13");

            //     accept scr-clinic-1-2-nbr-14.;
            await Prompt("const_clinic_1_2_nbr_14");

            //     if const-clinic-1-2-nbr-14 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 13;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_14 == 0)
            {
                const_max_nbr_clinics = 13;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-14.;
            await Prompt("const_clinic_nbr_14");

            //     accept scr-clinic-1-2-nbr-15.;
            await Prompt("const_clinic_1_2_nbr_15");

            //     if const-clinic-1-2-nbr-15 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 14;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_15 == 0)
            {
                const_max_nbr_clinics = 14;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-15.;
            await Prompt("const_clinic_nbr_15");

            //     accept scr-clinic-1-2-nbr-16.;
            await Prompt("const_clinic_1_2_nbr_16");

            //     if const-clinic-1-2-nbr-16 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 15;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_16 == 0)
            {
                const_max_nbr_clinics = 15;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-16.;
            await Prompt("const_clinic_nbr_16");

            //     accept scr-clinic-1-2-nbr-17.;
            await Prompt("const_clinic_1_2_nbr_17");

            //     if const-clinic-1-2-nbr-17 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 16;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_17 == 0)
            {
                const_max_nbr_clinics = 16;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-17.;
            await Prompt("const_clinic_nbr_17");

            //     accept scr-clinic-1-2-nbr-18.;
            await Prompt("const_clinic_1_2_nbr_18");

            //     if const-clinic-1-2-nbr-18 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 17;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_18 == 0)
            {
                const_max_nbr_clinics = 17;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-18.;
            await Prompt("const_clinic_nbr_18");

            //     accept scr-clinic-1-2-nbr-19.;
            await Prompt("const_clinic_1_2_nbr_19");

            //     if const-clinic-1-2-nbr-19 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 18;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_19 == 0)
            {
                const_max_nbr_clinics = 18;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-19.;
            await Prompt("const_clinic_nbr_19");

            //     accept scr-clinic-1-2-nbr-20.;
            await Prompt("const_clinic_1_2_nbr_20");

            //     if const-clinic-1-2-nbr-20 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 19;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_20 == 0)
            {
                const_max_nbr_clinics = 19;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-20.;
            await Prompt("const_clinic_nbr_20");

            //     accept scr-clinic-1-2-nbr-21.;
            await Prompt("const_clinic_1_2_nbr_21");

            //     if const-clinic-1-2-nbr-21 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 20;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_21 == 0)
            {
                const_max_nbr_clinics = 20;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-21.;
            await Prompt("const_clinic_nbr_21");

            //     accept scr-clinic-1-2-nbr-22.;
            await Prompt("const_clinic_1_2_nbr_22");

            //     if const-clinic-1-2-nbr-22 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 21;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_22 == 0)
            {
                const_max_nbr_clinics = 21;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-22.;
            await Prompt("const_clinic_nbr_22");

            //     accept scr-clinic-1-2-nbr-23.;
            await Prompt("const_clinic_1_2_nbr_23");

            //     if const-clinic-1-2-nbr-23 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 22;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_23 == 0)
            {
                const_max_nbr_clinics = 22;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-23.;
            await Prompt("const_clinic_nbr_23");

            //     accept scr-clinic-1-2-nbr-24.;
            await Prompt("const_clinic_1_2_nbr_24");  // ---

            //     if const-clinic-1-2-nbr-24 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 23;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_24 == 0)
            {
                const_max_nbr_clinics = 23;
                await ba0_10_clear_clinics();
                return;
            }


            //     accept scr-clinic-nbr-24.;
            await Prompt("const_clinic_nbr_24");

            //     accept scr-clinic-1-2-nbr-25.;
            await Prompt("const_clinic_1_2_nbr_25");

            //     if const-clinic-1-2-nbr-25 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 24;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_25 == 0)
            {
                const_max_nbr_clinics = 24;
                await ba0_10_clear_clinics();
                return;
            }


            //     accept scr-clinic-nbr-25.;
            await Prompt("const_clinic_nbr_25");

            //     accept scr-clinic-1-2-nbr-26.;
            await Prompt("const_clinic_1_2_nbr_26");

            //     if const-clinic-1-2-nbr-26 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 25;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_26 == 0)
            {
                const_max_nbr_clinics = 25;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-26.;
            await Prompt("const_clinic_nbr_26");

            //     accept scr-clinic-1-2-nbr-27.;
            await Prompt("const_clinic_1_2_nbr_27");

            //     if const-clinic-1-2-nbr-27 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 26;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_27 == 0)
            {
                const_max_nbr_clinics = 26;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-27.;
            await Prompt("const_clinic_nbr_27");

            //     accept scr-clinic-1-2-nbr-28.;
            await Prompt("const_clinic_1_2_nbr_28");

            //     if const-clinic-1-2-nbr-28 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 27;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_28 == 0)
            {
                const_max_nbr_clinics = 27;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-28.;
            await Prompt("const_clinic_nbr_28");

            //     accept scr-clinic-1-2-nbr-29.;
            await Prompt("const_clinic_1_2_nbr_29");

            //     if const-clinic-1-2-nbr-29 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 28;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_29 == 0)
            {
                const_max_nbr_clinics = 28;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-29.;
            await Prompt("const_clinic_nbr_29");

            //     accept scr-clinic-1-2-nbr-30.;
            await Prompt("const_clinic_1_2_nbr_30");

            //     if const-clinic-1-2-nbr-30 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 29;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_30 == 0)
            {
                const_max_nbr_clinics = 29;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-30.;
            await Prompt("const_clinic_nbr_30");

            //     accept scr-clinic-1-2-nbr-31.;
            await Prompt("const_clinic_1_2_nbr_31");

            //     if const-clinic-1-2-nbr-31 = zero then            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 30;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_31 == 0)
            {
                const_max_nbr_clinics = 30;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-31.;
            await Prompt("const_clinic_nbr_31");

            //     accept scr-clinic-1-2-nbr-32.;
            await Prompt("const_clinic_1_2_nbr_32");

            //     if const-clinic-1-2-nbr-32 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 31;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_32 == 0)
            {
                const_max_nbr_clinics = 31;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-32.;
            await Prompt("const_clinic_nbr_32");

            //     accept scr-clinic-1-2-nbr-33.;
            await Prompt("const_clinic_1_2_nbr_33");

            //     if const-clinic-1-2-nbr-33 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 32;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_33 == 0)
            {
                const_max_nbr_clinics = 32;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-33.;
            await Prompt("const_clinic_nbr_33");

            //     accept scr-clinic-1-2-nbr-34.;
            await Prompt("const_clinic_1_2_nbr_34");

            //     if const-clinic-1-2-nbr-34 = zero then;           
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 33;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_34 == 0)
            {
                const_max_nbr_clinics = 33;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-34.;
            await Prompt("const_clinic_nbr_34");

            //     accept scr-clinic-1-2-nbr-35.;
            await Prompt("const_clinic_1_2_nbr_35");

            //     if const-clinic-1-2-nbr-35 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 34;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_35 == 0)
            {
                const_max_nbr_clinics = 34;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-35.;
            await Prompt("const_clinic_nbr_35");

            //     accept scr-clinic-1-2-nbr-36.;
            await Prompt("const_clinic_1_2_nbr_36");

            //     if const-clinic-1-2-nbr-36 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 35;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_36 == 0)
            {
                const_max_nbr_clinics = 35;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-36.;
            await Prompt("const_clinic_nbr_36");

            //     accept scr-clinic-1-2-nbr-37.;
            await Prompt("const_clinic_1_2_nbr_37");

            //     if const-clinic-1-2-nbr-37 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 36;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_37 == 0)
            {
                const_max_nbr_clinics = 36;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-37.;
            await Prompt("const_clinic_nbr_37");

            //     accept scr-clinic-1-2-nbr-38.;
            await Prompt("const_clinic_1_2_nbr_38");

            //     if const-clinic-1-2-nbr-38 = zero then            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 37;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_38 == 0)
            {
                const_max_nbr_clinics = 37;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-38.;
            await Prompt("const_clinic_nbr_38");

            //     accept scr-clinic-1-2-nbr-39.;
            await Prompt("const_clinic_1_2_nbr_39");

            //     if const-clinic-1-2-nbr-39 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 38;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_39 == 0)
            {
                const_max_nbr_clinics = 38;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-39.;
            await Prompt("const_clinic_nbr_39");

            //     accept scr-clinic-1-2-nbr-40.;
            await Prompt("const_clinic_1_2_nbr_40");

            //     if const-clinic-1-2-nbr-40 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 39;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_40 == 0)
            {
                const_max_nbr_clinics = 39;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-40.;
            await Prompt("const_clinic_nbr_40");

            //     accept scr-clinic-1-2-nbr-41.;
            await Prompt("const_clinic_1_2_nbr_41");

            //     if const-clinic-1-2-nbr-41 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 40;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_41 == 0)
            {
                const_max_nbr_clinics = 40;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-41.;
            await Prompt("const_clinic_nbr_41");

            //     accept scr-clinic-1-2-nbr-42.;
            await Prompt("const_clinic_1_2_nbr_42");

            //     if const-clinic-1-2-nbr-42 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 41;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_42 == 0)
            {
                const_max_nbr_clinics = 41;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-42.;
            await Prompt("const_clinic_nbr_42");

            //     accept scr-clinic-1-2-nbr-43.;
            await Prompt("const_clinic_1_2_nbr_43");

            //     if const-clinic-1-2-nbr-43 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 42;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_43 == 0)
            {
                const_max_nbr_clinics = 42;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-43.;
            await Prompt("const_clinic_nbr_43");

            //     accept scr-clinic-1-2-nbr-44.;
            await Prompt("const_clinic_1_2_nbr_44");

            //     if const-clinic-1-2-nbr-44 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 43;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_44 == 0)
            {
                const_max_nbr_clinics = 43;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-44.;
            await Prompt("const_clinic_nbr_44");

            //     accept scr-clinic-1-2-nbr-45.;
            await Prompt("const_clinic_1_2_nbr_45");

            //     if const-clinic-1-2-nbr-45 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 44;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_45 == 0)
            {
                const_max_nbr_clinics = 44;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-45.;
            await Prompt("const_clinic_nbr_45");

            //     accept scr-clinic-1-2-nbr-46.;
            await Prompt("const_clinic_1_2_nbr_46");

            //     if const-clinic-1-2-nbr-46 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 45;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_46 == 0)
            {
                const_max_nbr_clinics = 45;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-46.;
            await Prompt("const_clinic_nbr_46");

            //     accept scr-clinic-1-2-nbr-47.;
            await Prompt("const_clinic_1_2_nbr_47");

            //     if const-clinic-1-2-nbr-47 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 46;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_47 == 0)
            {
                const_max_nbr_clinics = 46;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-47.;
            await Prompt("const_clinic_nbr_47");

            //     accept scr-clinic-1-2-nbr-48.;
            await Prompt("const_clinic_1_2_nbr_48");

            //     if const-clinic-1-2-nbr-48 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 47;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_48 == 0)
            {
                const_max_nbr_clinics = 47;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-48.;
            await Prompt("const_clinic_nbr_48");

            //     accept scr-clinic-1-2-nbr-49.;
            await Prompt("const_clinic_1_2_nbr_49");

            //     if const-clinic-1-2-nbr-49 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 48;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_49 == 0)
            {
                const_max_nbr_clinics = 48;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-49.;
            await Prompt("const_clinic_nbr_49");

            //     accept scr-clinic-1-2-nbr-50.;
            await Prompt("const_clinic_1_2_nbr_50");

            //     if const-clinic-1-2-nbr-50 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 49;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_50 == 0)
            {
                const_max_nbr_clinics = 49;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-50.;
            await Prompt("const_clinic_nbr_50");

            //     accept scr-clinic-1-2-nbr-51.;
            await Prompt("const_clinic_1_2_nbr_51");

            //     if const-clinic-1-2-nbr-51 = zero then;
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 50;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_51 == 0)
            {
                const_max_nbr_clinics = 50;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-51.;
            await Prompt("const_clinic_nbr_51");

            //     accept scr-clinic-1-2-nbr-52.;
            await Prompt("const_clinic_1_2_nbr_52");

            //     if const-clinic-1-2-nbr-52 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 51;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_52 == 0)
            {
                const_max_nbr_clinics = 51;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-52.;
            await Prompt("const_clinic_nbr_52");

            //     accept scr-clinic-1-2-nbr-53.;
            await Prompt("const_clinic_1_2_nbr_53");

            //     if const-clinic-1-2-nbr-53 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 52;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_53 == 0)
            {
                const_max_nbr_clinics = 52;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-53.;
            await Prompt("const_clinic_nbr_53");

            //     accept scr-clinic-1-2-nbr-54.;
            await Prompt("const_clinic_1_2_nbr_54");

            //     if const-clinic-1-2-nbr-54 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 53;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_54 == 0)
            {
                const_max_nbr_clinics = 53;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-54.;
            await Prompt("const_clinic_nbr_54");

            //     accept scr-clinic-1-2-nbr-55.;
            await Prompt("const_clinic_1_2_nbr_55");

            //     if const-clinic-1-2-nbr-55 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 54;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_55 == 0)
            {
                const_max_nbr_clinics = 54;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-55.;
            await Prompt("const_clinic_nbr_55");

            //     accept scr-clinic-1-2-nbr-56.;
            await Prompt("const_clinic_1_2_nbr_56");

            //     if const-clinic-1-2-nbr-56 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 55;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_56 == 0)
            {
                const_max_nbr_clinics = 55;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-56.;
            await Prompt("const_clinic_nbr_56");

            //     accept scr-clinic-1-2-nbr-57.;
            await Prompt("const_clinic_1_2_nbr_57");

            //     if const-clinic-1-2-nbr-57 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 56;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_57 == 0)
            {
                const_max_nbr_clinics = 56;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-57.;
            await Prompt("const_clinic_nbr_57");

            //     accept scr-clinic-1-2-nbr-58.;
            await Prompt("const_clinic_1_2_nbr_58");

            //     if const-clinic-1-2-nbr-58 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 57;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_58 == 0)
            {
                const_max_nbr_clinics = 57;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-58.;
            await Prompt("const_clinic_nbr_58");

            //     accept scr-clinic-1-2-nbr-59.;
            await Prompt("const_clinic_1_2_nbr_59");

            //     if const-clinic-1-2-nbr-59 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 58;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_59 == 0)
            {
                const_max_nbr_clinics = 58;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-59.;
            await Prompt("const_clinic_nbr_59");

            //     accept scr-clinic-1-2-nbr-60.;
            await Prompt("const_clinic_1_2_nbr_60");

            //     if const-clinic-1-2-nbr-60 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 59;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_60 == 0)
            {
                const_max_nbr_clinics = 59;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-60.;
            await Prompt("const_clinic_nbr_60");

            //     accept scr-clinic-1-2-nbr-61.;
            await Prompt("const_clinic_1_2_nbr_61");

            //     if const-clinic-1-2-nbr-61 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 60;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_61 == 0)
            {
                const_max_nbr_clinics = 60;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-61.;
            await Prompt("const_clinic_nbr_61");

            //     accept scr-clinic-1-2-nbr-62.;
            await Prompt("const_clinic_1_2_nbr_62");

            //     if const-clinic-1-2-nbr-62 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 61;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_62 == 0)
            {
                const_max_nbr_clinics = 61;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-62.;
            await Prompt("const_clinic_nbr_62");

            //     accept scr-clinic-1-2-nbr-63.;
            await Prompt("const_clinic_1_2_nbr_63");

            //     if const-clinic-1-2-nbr-63 = zero then;            
            //        objConstants_mstr_rec_1.const_max_nbr_clinics = 62;
            // 	      go to ba0-10-clear-clinics.;

            if (const_clinic_1_2_nbr_63 == 0)
            {
                const_max_nbr_clinics = 62;
                await ba0_10_clear_clinics();
                return;
            }

            //     accept scr-clinic-nbr-63.;
            await Prompt("const_clinic_nbr_63");

            const_max_nbr_clinics = 63;
        }

        private async Task ba0_10_clear_clinics()
        {

            //     add 1    const-max-nbr-clinics 	giving ws-save-max-clinics.;
            ws_save_max_clinics = Util.NumInt(objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS) + 1;

            //     perform ba1-zero-areas		thru ba1-99-exit;
            // 	varying i from ws-save-max-clinics by 1;
            // 	until   i > 63.;

            i = ws_save_max_clinics;
            do
            {
                await ba1_zero_areas();
                await ba1_99_exit();
                i++;
            } while (i <= 63);

            //     display scr-mask1.;

            Display("scr-mask1.");
        }

        private async Task ba0_99_exit()
        {
            //     exit.;
        }

        private async Task ba1_zero_areas()
        {

            //const_clinic_nbr_1_2[i] = 0;
            //CONST_CLINIC_NBR_1_2_SET(objConstants_mstr_rec_1, i, 0);            
            await Const_Clinic_Nbr_1_2_Screen_Variable_SetValue(i, 0);

            //const_clinic_nbr[i] = "";
            //base.CONST_CLINIC_NBR_SET(objConstants_mstr_rec_1, i, string.Empty);
            await Const_Clinic_Nbr_Screen_Variable_SetValue(i, string.Empty);
        }

        private async Task ba1_99_exit()
        {
            //     exit.;
        }

        private async Task ca0_const_mstr_2_curr()
        {

            //  if flag not = "M" then;            
            // 	      display scr-mask2a;
            // 	      display scr-mask2b.;

            if (flag != "M")
            {
                Display("scr-mask2a.");
                Display("scr-mask2b.");
            }

            //  if option = "I" then;            
            // 	   go to ca0-99-exit.;

            if (option == "I")
            {
                await ca0_99_exit();
                return;
            }

            //     perform ca2-acpt-effective-date-curr	thru	ca2-99-exit.;
            await ca2_acpt_effective_date_curr();


            await ca2_100_mth();
            await ca2_200_day();
            await ca2_99_exit();

            //     accept  scr-wcb-curr.;
            //     display scr-wcb-curr.;
            await Prompt("const_wcb_curr");

            //     accept  scr-bi-curr.;
            //     display scr-bi-curr.;
            await Prompt("const_bilateral_curr");

            //     accept  scr-ic-curr.;
            //     display scr-ic-curr.;
            await Prompt("const_ic_curr");

            //     accept  scr-sr-curr.;
            //     display scr-sr-curr.;
            await Prompt("const_sr_curr");

            //     accept  scr-asst-h-curr.;
            //     display scr-asst-h-curr.;
            await Prompt("const_asst_h_curr");

            //     accept  scr-reg-h-curr.;
            //     display scr-reg-h-curr.;
            await Prompt("const_reg_h_curr");

            //     accept  scr-cert-h-curr.;
            //     display scr-cert-h-curr.;
            await Prompt("const_cert_h_curr");

            //     accept  scr-asst-a-curr.;
            //     display scr-asst-a-curr.;
            await Prompt("const_asst_a_curr");

            //     accept  scr-reg-a-curr.;
            //     display scr-reg-a-curr.;
            await Prompt("const_reg_a_curr");

            //     accept  scr-cert-a-curr.;
            //     display scr-cert-a-curr.;
            await Prompt("const_cert_a_curr");

            //     perform ca1-acpt-group-rates-curr		thru	ca1-99-exit.;

            await ca1_acpt_group_rates_curr();
            await ca1_100_nbr_rates();
            await ca1_99_exit();
        }

        private async Task ca0_99_exit()
        {
            //     exit.;
        }

        private async Task ca1_acpt_group_rates_curr()
        {

            //     accept  scr-sect-1.;
            //     display scr-sect-1.;
            await Prompt("const_sect_1");

            //     if const-sect-1 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 0;
            // 	       go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_1))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 0;
                const_max_nbr_rates = 0;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-1.;
            //     display scr-group-1.;
            await Prompt("const_group_1");


            //     accept  scr-curr-1.;
            //     display scr-curr-1.;
            await Prompt("const_curr_1");

            //     accept  scr-sect-2.;
            //     display scr-sect-2.;
            await Prompt("const_sect_2");

            //     if const-sect-2 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 1;
            //        go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_2))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 1;
                const_max_nbr_rates = 1;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-2.;
            //     display scr-group-2.;
            await Prompt("const_group_2");

            //     accept  scr-curr-2.;
            //     display scr-curr-2.;
            await Prompt("const_curr_2");

            //     accept  scr-sect-3.;
            //     display scr-sect-3.;
            await Prompt("const_sect_3");

            //     if const-sect-3 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 2;
            // 	      go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_3))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 2;
                const_max_nbr_rates = 2;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-3.;
            //     display scr-group-3.;
            await Prompt("const_group_3");

            //     accept  scr-curr-3.;
            //     display scr-curr-3.;
            await Prompt("const_curr_3");

            //     accept  scr-sect-4.;
            //     display scr-sect-4.;
            await Prompt("const_sect_4");

            //   if const-sect-4 = spaces then;            
            //      objConstants_mstr_rec_2.const_max_nbr_rates = 3;
            //    	go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_4))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 3;
                const_max_nbr_rates = 3;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-4.;
            //     display scr-group-4.;
            await Prompt("const_group_4");

            //     accept  scr-curr-4.;
            //     display scr-curr-4.;
            await Prompt("const_curr_4");

            //     accept  scr-sect-5.;
            //     display scr-sect-5.;
            await Prompt("const_sect_5");

            //     if const-sect-5 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 4;
            // 	      go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_5))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 4;
                const_max_nbr_rates = 4;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-5.;
            //     display scr-group-5.;
            await Prompt("const_group_5");

            //     accept  scr-curr-5.;
            //     display scr-curr-5.;
            await Prompt("const_curr_5");

            //     accept  scr-sect-6.;
            //     display scr-sect-6.;
            await Prompt("const_sect_6");

            //     if const-sect-6 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 5;
            // 	      go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_6))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 5;
                const_max_nbr_rates = 5;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-6.;
            //     display scr-group-6.;
            await Prompt("const_group_6");

            //     accept  scr-curr-6.;
            //     display scr-curr-6.;
            await Prompt("const_curr_6");

            //     accept  scr-sect-7.;
            //     display scr-sect-7.;
            await Prompt("const_sect_7");

            //     if const-sect-7 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 6;
            // 	      go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_7))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 6;
                const_max_nbr_rates = 6;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-7.;
            //     display scr-group-7.;
            await Prompt("const_group_7");

            //     accept  scr-curr-7.;
            //     display scr-curr-7.;
            await Prompt("const_curr_7");

            //     accept  scr-sect-8.;
            //     display scr-sect-8.;
            await Prompt("const_sect_8");

            //     if const-sect-8 = spaces then;            
            //        objConstants_mstr_rec_2.const_max_nbr_rates = 7;
            // 	      go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_8))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 7;
                const_max_nbr_rates = 7;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-8.;
            //     display scr-group-8.;
            await Prompt("const_group_8");

            //     accept  scr-curr-8.;
            //     display scr-curr-8.;
            await Prompt("const_curr_8");

            //     accept  scr-sect-9.;
            //     display scr-sect-9.;
            await Prompt("const_sect_9");

            //  if const-sect-9 = spaces then;            
            //      objConstants_mstr_rec_2.const_max_nbr_rates = 8;
            //    	go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_9))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 8;
                const_max_nbr_rates = 8;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-9.;
            //     display scr-group-9.;
            await Prompt("const_group_9");

            //     accept  scr-curr-9.;
            //     display scr-curr-9.;
            await Prompt("const_curr_9");

            //     accept  scr-sect-10.;
            //     display scr-sect-10.;
            await Prompt("const_sect_10");

            // if const-sect-10 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 9;
            // 	  go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_10))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 9;
                const_max_nbr_rates = 9;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-10.;
            //     display scr-group-10.;
            await Prompt("const_group_10");

            //     accept  scr-curr-10.;
            //     display scr-curr-10.;
            await Prompt("const_curr_10");

            //     accept  scr-sect-11.;
            //     display scr-sect-11.;
            await Prompt("const_sect_11");

            // if const-sect-11 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 10;
            // 	  go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_11))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 10;
                const_max_nbr_rates = 10;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-11.;
            //     display scr-group-11.;
            await Prompt("const_group_11");

            //     accept  scr-curr-11.;
            //     display scr-curr-11.;
            await Prompt("const_curr_11");

            //     accept  scr-sect-12.;
            //     display scr-sect-12.;
            await Prompt("const_sect_12");

            // if const-sect-12 = spaces then;            
            //     objConstants_mstr_rec_2.const_max_nbr_rates = 11;
            // 	   go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_12))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 11;
                const_max_nbr_rates = 11;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-12.;
            //     display scr-group-12.;
            await Prompt("const_group_12");

            //     accept  scr-curr-12.;
            //     display scr-curr-12.;
            await Prompt("const_curr_12");

            //     accept  scr-sect-13.;
            //     display scr-sect-13.;
            await Prompt("const_sect_13");

            // if const-sect-13 = spaces then;            
            //     objConstants_mstr_rec_2.const_max_nbr_rates = 12;
            // 	   go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_13))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 12;
                const_max_nbr_rates = 12;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-13.;
            //     display scr-group-13.;
            await Prompt("const_group_13");

            //     accept  scr-curr-13.;
            //     display scr-curr-13.;
            await Prompt("const_curr_13");

            //     accept  scr-sect-14.;
            //     display scr-sect-14.;
            await Prompt("const_sect_14");

            // if const-sect-14 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 13;
            // 	   go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_14))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 13;
                const_max_nbr_rates = 13;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-14.;
            //     display scr-group-14.;
            await Prompt("const_group_14");

            //     accept  scr-curr-14.;
            //     display scr-curr-14.;
            await Prompt("const_curr_14");

            //     accept  scr-sect-15.;
            //     display scr-sect-15.;
            await Prompt("const_sect_15");

            // if const-sect-15 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 14;
            // 	  go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_15))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 14;
                const_max_nbr_rates = 14;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-15.;
            //     display scr-group-15.;
            await Prompt("const_group_15");

            //     accept  scr-curr-15.;
            //     display scr-curr-15.;
            await Prompt("const_curr_15");

            //     accept  scr-sect-16.;
            //     display scr-sect-16.;
            await Prompt("const_sect_16");

            //  if const-sect-16 = spaces then;            
            //     objConstants_mstr_rec_2.const_max_nbr_rates = 15;
            // 	    go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_16))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 15;
                const_max_nbr_rates = 15;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-16.;
            //     display scr-group-16.;
            await Prompt("const_group_16");

            //     accept  scr-curr-16.;
            //     display scr-curr-16.;
            await Prompt("const_curr_16");

            //     accept  scr-sect-17.;
            //     display scr-sect-17.;
            await Prompt("const_sect_17");

            // if const-sect-17 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 16;
            // 	   go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_17))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 16;
                const_max_nbr_rates = 16;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-17.;
            //     display scr-group-17.;
            await Prompt("const_group_17");

            //     display scr-group-17.;
            //     display scr-curr-17.;            

            //     accept  scr-curr-17.;
            //     display scr-curr-17.;
            await Prompt("const_curr_17");


            //     accept  scr-sect-18.;
            //     display scr-sect-18.;
            await Prompt("const_sect_18");

            // if const-sect-18 = spaces then;            
            //    objConstants_mstr_rec_2.const_max_nbr_rates = 17;
            // 	   go to ca1-100-nbr-rates.;

            if (string.IsNullOrWhiteSpace(const_sect_18))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 17;
                const_max_nbr_rates = 17;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-18.;
            //     display scr-group-18.;
            await Prompt("const_group_18");

            //     accept  scr-curr-18.;
            //     display scr-curr-18.;
            await Prompt("const_curr_18");

            //     accept  scr-sect-19.;
            //     display scr-sect-19.;
            await Prompt("const_sect_19");

            // if const-sect-19 = spaces then;            
            //     objConstants_mstr_rec_2.const_max_nbr_rates = 18;
            // 	   go to ca1-100-nbr-rates.;
            if (string.IsNullOrWhiteSpace(const_sect_19))
            {
                //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 18;
                const_max_nbr_rates = 18;
                await ca1_100_nbr_rates();
                return;
            }

            //     accept  scr-group-19.;
            //     display scr-group-19.;
            await Prompt("const_group_19");

            //     accept  scr-curr-19.;
            //     display scr-curr-19.;
            await Prompt("const_curr_19");

            //objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = 19;
            const_max_nbr_rates = 19;
        }

        private async Task ca1_100_nbr_rates()
        {

            //     add 1, const-max-nbr-rates	giving	ws-save-max-rates.;
            ws_save_max_rates = const_max_nbr_rates + 1;

            //     perform ca3-zero-areas	thru	ca3-99-exit;
            // 	varying	i;
            // 	from	ws-save-max-rates;
            // 	by  	1;
            // 	until	i > 19.;

            i = ws_save_max_rates;
            do
            {
                await ca3_zero_areas();
                await ca3_99_exit();
                i++;
            } while (i <= 19);


            //     display scr-mask2b.;
            Display("scr-mask2b.");
            //     display scr-nbr-rates.;
            Display("scr-nbr-rates.");
            //await Prompt ("const_max_nbr_rates");
        }

        private async Task ca1_99_exit()
        {
            //     exit.;
        }

        private async Task ca2_acpt_effective_date_curr()
        {

            //     accept  scr-yy-curr.;
            //     display scr-yy-curr.;
            Display("scr-yy-curr.");
            await Prompt("const_yy_curr");

            // if const-yy-curr < 32 then;            
            //   err_ind = 2;
            // 	perform za0-common-error 	thru	za0-99-exit;
            // 	go to ca2-acpt-effective-date-curr.;

            if (const_yy_curr < 32)
            {
                err_ind = 2;
                await za0_common_error();
                await za0_99_exit();
                await ca2_acpt_effective_date_curr();
                return;
            }
        }

        private async Task ca2_100_mth()
        {

            //     accept  scr-mm-curr.;
            //     display scr-mm-curr.;
            Display("scr-mm-curr.");
            await Prompt("const_mm_curr");

            // if  const-mm-curr < 1 or const-mm-curr > 12  then;            
            //     err_ind = 3;
            // 	   perform za0-common-error	thru	za0-99-exit;
            // 	   go to ca2-100-mth.;

            if (const_mm_curr < 1 || const_mm_curr > 12)
            {
                err_ind = 3;
                await za0_common_error();
                await za0_99_exit();
                await ca2_100_mth();
                return;
            }
        }

        private async Task ca2_200_day()
        {

            //     accept  scr-dd-curr.;
            //     display scr-dd-curr.;
            Display("scr-dd-curr.");
            await Prompt("const_dd_curr");

            // if const-dd-curr < 1 or const-dd-curr > max-nbr-days (const-mm-curr) then;            
            //    err_ind = 4;
            // 	  perform za0-common-error	thru	za0-99-exit;
            // 	  go to ca2-200-day.;

            if (const_dd_curr < 1 || const_dd_curr > max_nbr_days[const_mm_curr])
            {
                err_ind = 4;
                await za0_common_error();
                await za0_99_exit();
                await ca2_200_day();
                return;
            }
        }

        private async Task ca2_99_exit()
        {
            //     exit.;
        }

        private async Task ca3_zero_areas()
        {
            //const_group_rates[i] = 0;                 
            //const_section[i] = "";            

            switch (i)
            {
                case 1:
                    const_sect_1 = string.Empty;
                    const_group_1 = 0;
                    const_curr_1 = 0;
                    const_prev_1 = 0;
                    break;
                case 2:
                    const_sect_2 = string.Empty;
                    const_group_2 = 0;
                    const_curr_2 = 0;
                    const_prev_2 = 0;
                    break;
                case 3:
                    const_sect_3 = string.Empty;
                    const_group_3 = 0;
                    const_curr_3 = 0;
                    const_prev_3 = 0;
                    break;
                case 4:
                    const_sect_4 = string.Empty;
                    const_group_4 = 0;
                    const_curr_4 = 0;
                    const_prev_4 = 0;
                    break;
                case 5:
                    const_sect_5 = string.Empty;
                    const_group_5 = 0;
                    const_curr_5 = 0;
                    const_prev_5 = 0;
                    break;
                case 6:
                    const_sect_6 = string.Empty;
                    const_group_6 = 0;
                    const_curr_6 = 0;
                    const_prev_6 = 0;
                    break;
                case 7:
                    const_sect_7 = string.Empty;
                    const_group_7 = 0;
                    const_curr_7 = 0;
                    const_prev_7 = 0;
                    break;
                case 8:
                    const_sect_8 = string.Empty;
                    const_group_8 = 0;
                    const_curr_8 = 0;
                    const_prev_8 = 0;
                    break;
                case 9:
                    const_sect_9 = string.Empty;
                    const_group_9 = 0;
                    const_curr_9 = 0;
                    const_prev_9 = 0;
                    break;
                case 10:
                    const_sect_10 = string.Empty;
                    const_group_10 = 0;
                    const_curr_10 = 0;
                    const_prev_10 = 0;
                    break;
                case 11:
                    const_sect_11 = string.Empty;
                    const_group_11 = 0;
                    const_curr_11 = 0;
                    const_prev_11 = 0;
                    break;
                case 12:
                    const_sect_12 = string.Empty;
                    const_group_12 = 0;
                    const_curr_12 = 0;
                    const_prev_12 = 0;
                    break;
                case 13:
                    const_sect_13 = string.Empty;
                    const_group_13 = 0;
                    const_curr_13 = 0;
                    const_prev_13 = 0;
                    break;
                case 14:
                    const_sect_14 = string.Empty;
                    const_group_14 = 0;
                    const_curr_14 = 0;
                    const_prev_14 = 0;
                    break;
                case 15:
                    const_sect_15 = string.Empty;
                    const_group_15 = 0;
                    const_curr_15 = 0;
                    const_prev_15 = 0;
                    break;
                case 16:
                    const_sect_16 = string.Empty;
                    const_group_16 = 0;
                    const_curr_16 = 0;
                    const_prev_16 = 0;
                    break;
                case 17:
                    const_sect_17 = string.Empty;
                    const_group_17 = 0;
                    const_curr_17 = 0;
                    const_prev_17 = 0;
                    break;
                case 18:
                    const_sect_18 = string.Empty;
                    const_group_18 = 0;
                    const_curr_18 = 0;
                    const_prev_18 = 0;
                    break;
                case 19:
                    const_sect_19 = string.Empty;
                    const_group_19 = 0;
                    const_curr_19 = 0;
                    const_prev_19 = 0;
                    break;
            }

        }

        private async Task ca3_99_exit()
        {
            //     exit.;
        }

        private async Task da0_password()
        {
            password_flag = "N";
            ws_entered_password = "";
            //     display scr-password-prompt.;
            //     accept  scr-password.;
            Display("scr-password-prompt.");
            await Prompt("ws_entered_password");

            //if ws-entered-password = ws-valid-password then;            
            if (ws_entered_password == ws_valid_password)
            {
                password_flag = "Y";
            }
            Display("scr-password-prompt.",false);
        }
        private async Task da0_99_exit()
        {
            //     exit.;
        }
        private async Task da1_const_mstr_2_prev()
        {
            //     perform da3-acpt-effective-date-prev	thru	da3-99-exit.;
            bool isValid = false;
            do
            {
                await da3_acpt_effective_date_prev();
                await da3_100_mth();
                if ( await da3_200_day() == true)
                {
                    isValid = true;
                }
                await da3_99_exit();
            } while (isValid == false);

            //     display scr-wcb-prev.;
            //     accept  scr-wcb-prev.;
            //     display scr-wcb-prev.;
            Display("scr-wcb-prev.");
            await Prompt("const_wcb_prev");

            //     display scr-bi-prev.;
            //     accept  scr-bi-prev.;
            //     display scr-bi-prev.;
            Display("scr-bi-prev.");
            await Prompt("const_bilateral_prev");

            //     display scr-ic-prev.;
            //     accept  scr-ic-prev.;
            //     display scr-ic-prev.;
            Display("scr-ic-prev.");
            await Prompt("const_ic_prev");

            //     display scr-sr-prev.;
            //     accept  scr-sr-prev.;
            //     display scr-sr-prev.;
            Display("scr-sr-prev.");
            await Prompt("const_sr_prev");

            //     display scr-asst-h-prev.;
            //     accept  scr-asst-h-prev.;
            //     display scr-asst-h-prev.;
            Display("scr-asst-h-prev.");
            await Prompt("const_asst_h_prev");

            //     display scr-reg-h-prev.;
            //     accept  scr-reg-h-prev.;
            //     display scr-reg-h-prev.;
            Display("scr-reg-h-prev.");
            await Prompt("const_reg_h_prev");

            //     display scr-cert-h-prev.;
            //     accept  scr-cert-h-prev.;
            //     display scr-cert-h-prev.;
            Display("scr-cert-h-prev.");
            await Prompt("const_cert_h_prev");

            //     display scr-asst-a-prev.;
            //     accept  scr-asst-a-prev.;
            //     display scr-asst-a-prev.;
            Display("scr-asst-a-prev.");
            await Prompt("const_asst_a_prev");

            //     display scr-reg-a-prev.;
            //     accept  scr-reg-a-prev.;
            //     display scr-reg-a-prev.;
            Display("scr-reg-a-prev.");
            await Prompt("const_reg_a_prev");

            //     display scr-cert-a-prev.;
            //     accept  scr-cert-a-prev.;
            //     display scr-cert-a-prev.;
            Display("scr-cert-a-prev.");
            await Prompt("const_cert_a_prev");

            //     perform da2-acpt-group-rates-prev	thru da2-99-exit.;
            await da2_acpt_group_rates_prev();
            await da2_99_exit();
        }
        private async Task da1_99_exit()
        {
            //     exit.;
        }

        private async Task da2_acpt_group_rates_prev()
        {

            // if const-sect-1 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_1))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-1.;
            //     accept  scr-prev-1.;
            //     display scr-prev-1.;
            Display("scr-prev-1.");
            await Prompt("const_prev_1");

            // if const-sect-2 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_2))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-2.;
            //     accept  scr-prev-2.;
            //     display scr-prev-2.;
            Display("scr-prev-2.");
            await Prompt("const_prev_2");

            // if const-sect-3 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_3))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-3.;
            //     accept  scr-prev-3.;
            //     display scr-prev-3.;
            Display("scr-prev-3.");
            await Prompt("const_prev_3");

            // if const-sect-4 = spaces then;            
            // 	   go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_4))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-4.;
            //     accept  scr-prev-4.;
            //     display scr-prev-4.;
            Display("scr-prev-4.");
            await Prompt("const_prev_4");

            // if const-sect-5 = spaces then;            
            // 	go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_5))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-5.;
            //     accept  scr-prev-5.;
            //     display scr-prev-5.;
            Display("scr-prev-5.");
            await Prompt("const_prev_5");

            // if const-sect-6 = spaces then;            
            // 	   go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_6))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-6.;
            //     accept  scr-prev-6.;
            //     display scr-prev-6.;
            Display("scr-prev-6.");
            await Prompt("const_prev_6");

            // if const-sect-7 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_7))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-7.;
            //     accept  scr-prev-7.;
            //     display scr-prev-7.;
            Display("scr-prev-7.");
            await Prompt("const_prev_7");

            // if const-sect-8 = spaces then;            
            //    go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_8))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-8.;
            //     accept  scr-prev-8.;
            //     display scr-prev-8.;
            Display("scr-prev-8.");
            await Prompt("const_prev_8");

            // if const-sect-9 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_9))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-9.;
            //     accept  scr-prev-9.;
            //     display scr-prev-9.;
            Display("scr-prev-9.");
            await Prompt("const_prev_9");

            // if const-sect-10 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_10))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-10.;
            //     accept  scr-prev-10.;
            //     display scr-prev-10.;
            Display("scr-prev-10.");
            await Prompt("const_prev_10");

            // if const-sect-11 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_11))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-11.;
            //     accept  scr-prev-11.;
            //     display scr-prev-11.;
            Display("scr-prev-11.");
            await Prompt("const_prev_11");

            // if const-sect-12 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_12))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-12.;
            //     accept  scr-prev-12.;
            //     display scr-prev-12.;
            Display("scr-prev-12.");
            await Prompt("const_prev_12");

            // if const-sect-13 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_13))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-13.;
            //     accept  scr-prev-13.;
            //     display scr-prev-13.;
            Display("scr-prev-13.");
            await Prompt("const_prev_13");

            // if const-sect-14 = spaces then;            
            // 	go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_14))
            {
                await da2_99_exit();
                return;
            }

            // display scr-prev-14.;
            // accept  scr-prev-14.;
            // display scr-prev-14.;
            Display("scr-prev-14.");
            await Prompt("const_prev_14");

            // if const-sect-15 = spaces then;            
            // 	go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_15))
            {
                await da2_99_exit();
                return;
            }

            //  display scr-prev-15.;
            //  accept  scr-prev-15.;
            //  display scr-prev-15.;
            Display("scr-prev-15.");
            await Prompt("const_prev_15");

            // if const-sect-16 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_16))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-16.;
            //     accept  scr-prev-16.;
            //     display scr-prev-16.;
            Display("scr-prev-16.");
            await Prompt("const_prev_16");

            // if const-sect-17 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_17))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-17.;
            //     accept  scr-prev-17.;
            //     display scr-prev-17.;
            Display("scr-prev-17.");
            await Prompt("const_prev_17");

            // if const-sect-18 = spaces then;           
            //    go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_18))
            {
                await da2_99_exit();
                return;
            }

            //  display scr-prev-18.;
            //  accept  scr-prev-18.;
            //  display scr-prev-18.;
            Display("scr-prev-18.");
            await Prompt("const_prev_18");

            // if const-sect-19 = spaces then;            
            // 	  go to da2-99-exit.;
            if (string.IsNullOrWhiteSpace(const_sect_19))
            {
                await da2_99_exit();
                return;
            }

            //     display scr-prev-19.;
            //     accept  scr-prev-19.;
            //     display scr-prev-19.;
            Display("scr-prev-19.");
            await Prompt("const_prev_19");
        }

        private async Task da2_99_exit()
        {
            //     exit.;
        }

        private async Task da3_acpt_effective_date_prev()
        {
            //     display scr-yy-prev.;
            //     accept  scr-yy-prev.;
            //     display scr-yy-prev.;
            Display("scr-yy-prev.");
            await Prompt("const_yy_prev");

            // if const-yy-prev < 32 then;
            //    err_ind = 2;
            // 	perform za0-common-error 	thru	za0-99-exit;
            // 	go to da3-acpt-effective-date-prev.;

            if (const_yy_prev < 32)
            {
                err_ind = 2;
                await za0_common_error();
                await za0_99_exit();
                await da3_acpt_effective_date_prev();
                return;
            }
        }

        private async Task da3_100_mth()
        {
            //     display scr-mm-prev.;
            //     accept  scr-mm-prev.;
            //     display scr-mm-prev.;
            Display("scr-mm-prev.");
            await Prompt("const_mm_prev");

            // if const-mm-prev < 1 or const-mm-prev > 12 then;            
            //  err_ind = 3;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to da3-100-mth.;
            if (const_mm_prev < 1 || const_mm_prev > 12)
            {
                err_ind = 3;
                await za0_common_error();
                await za0_99_exit();
                await da3_100_mth();
                return;
            }
        }

        private async Task<bool> da3_200_day()
        {

            //     display scr-dd-prev.;
            //     accept  scr-dd-prev.;
            //     display scr-dd-prev.;
            Display("scr-dd-prev.");
            await Prompt("const_dd_prev");

            // if const-dd-prev < 1 or const-dd-prev > max-nbr-days (const-mm-prev) then;            
            //    err_ind = 4;
            // 	  perform za0-common-error	thru	za0-99-exit;
            // 	  go to da3-200-day.;

            if (const_dd_prev < 1 || const_dd_prev > max_nbr_days[const_mm_prev])
            {
                err_ind = 4;
                await za0_common_error();
                await za0_99_exit();
                await da3_200_day();
                return false; 
            }

            // if const-effective-date-prev not < const-effective-date-curr then;            
            //    err_ind = 7;
            // 	  perform za0-common-error thru	za0-99-exit;
            // 	  go to da3-acpt-effective-date-prev.;
          

               if ( new DateTime(Util.NumInt(const_yy_prev), Util.NumInt(const_mm_prev), Util.NumInt(const_dd_prev)).Date.CompareTo( 
                    new DateTime(Util.NumInt(const_yy_curr), Util.NumInt(const_mm_curr), Util.NumInt(const_dd_curr)).Date ) >= 0  )

            {
                err_ind = 7;
                await za0_common_error();
                await za0_99_exit();
                //await da3_acpt_effective_date_prev();
                return false;
            }

            return true;
        }

        private async Task da3_99_exit()
        {

            //     exit.;
        }

        private async Task fa0_isam_const_mstr_routine()
        {

            // if flag not = "M" then;           
            // 	  display scr-const-isam-mask.;

            if (flag != "M")
            {
                Display("scr-const-isam-mask.");
            }

            // if option = "I" then;            
            // 	  go to fa0-99-exit;
            // else;
            // 	next sentence.;

            if (option == "I")
            {
                await fa0_99_exit();

                return;
            }
            else
            {
                // next sentence
            }

            //     accept scr-clinic-nbr.;
            Display("scr-clinic-nbr.");
            await Prompt("iconst_clinic_nbr");

            //Display("scr-clinic-nbr-1.");
            //await Prompt("const_clinic_nbr_1");

            //     accept scr-clinic-name.;
            Display("scr-clinic-name.");
            await Prompt("iconst_clinic_name");

            //     accept scr-clinic-cycle.;
            Display("scr-clinic-cycle.");
            await Prompt("iconst_clinic_cycle_nbr");
        }

        private async Task fa0_10()
        {
            // accept scr-date-period-end-yy.;
            Display("scr-date-period-end-yy.");
            await Prompt("iconst_date_period_end_yy");

            // if iconst-date-period-end-yy < 32 then;            
            //    err_ind = 2;
            // 	  perform za0-common-error	thru za0-99-exit;
            // 	  go to fa0-10.;

            if (iconst_date_period_end_yy < 32)
            {
                err_ind = 2;
                await za0_common_error();
                await za0_99_exit();
                await fa0_10();
                return;
            }
        }

        private async Task fa0_20()
        {
            //     accept scr-date-period-end-mm.;
            Display("scr-date-period-end-mm.");
            await Prompt("iconst_date_period_end_mm");

            // if  iconst-date-period-end-mm < 1 or iconst-date-period-end-mm > 12  then;                       
            //    err_ind = 3;
            // 	  perform za0-common-error	thru za0-99-exit;
            // 	  go to fa0-20.;

            if (iconst_date_period_end_mm < 1 || iconst_date_period_end_mm > 12)
            {
                err_ind = 3;
                await za0_common_error();
                await za0_99_exit();
                await fa0_20();
                return;
            }
        }

        private async Task fa0_30()
        {

            // accept scr-date-period-end-dd.;
            Display("scr-date-period-end-dd.");
            await Prompt("iconst_date_period_end_dd");

            // if iconst-date-period-end-dd < 1 or iconst-date-period-end-dd > max-nbr-days (iconst-date-period-end-mm) then            
            //     err_ind = 4;
            // 	   perform za0-common-error	thru za0-99-exit;
            // 	   go to fa0-30.;

            if (iconst_date_period_end_dd < 1 || iconst_date_period_end_dd > max_nbr_days[iconst_date_period_end_mm])
            {
                err_ind = 4;
                await za0_common_error();
                await za0_99_exit();
                await fa0_30();
                return;
            }

            //     accept scr-clinic-card-colour.;
            //Display("scr-clinic-card-colour.");
            await Prompt("iconst_clinic_card_colour");

            //     accept scr-clinic-addr-1.;
            //Display("scr-clinic-addr-1.");
            await Prompt("iconst_clinic_addr_l1");

            //     accept scr-clinic-addr-2.;
            //Display("scr-clinic-addr-2.");
            await Prompt("iconst_clinic_addr_l2");

            //     accept scr-clinic-addr-3.;
            //Display("scr-clinic-addr-3.");
            await Prompt("iconst_clinic_addr_l3");

            // accept scr-clinic-over-lim1.;
            //Display("scr-clinic-over-lim1.");
            await Prompt("iconst_clinic_over_lim1");

            //     accept scr-clinic-under-lim2.;
            //Display("scr-clinic-under-lim2.");
            await Prompt("iconst_clinic_under_lim2");

            //     accept scr-clinic-under-lim3.;
            //Display("scr-clinic-under-lim3.");
            await Prompt("iconst_clinic_under_lim3");

            //     accept scr-clinic-over-lim4.;
            //Display("scr-clinic-over-lim4.");
            await Prompt("iconst_clinic_over_lim4");

            //     accept scr-clinic-pay-batch-nbr.;
            //Display("scr-clinic-pay-batch-nbr.");
            await Prompt("iconst_clinic_pay_batch_nbr");

            //     accept scr-clinic-batch-nbr.;
            //Display("scr-clinic-batch-nbr.");
            await Prompt("iconst_clinic_batch_nbr");

            //     accept scr-reduction-factor.;
            //Display("scr-reduction-factor.");
            await Prompt("iconst_reduction_factor");

            //     accept scr-overpay-factor.;
            //Display("scr-overpay-factor.");
            await Prompt("iconst_overpay_factor");
        }

        private async Task fa0_99_exit()
        {
            //     exit.;
        }

        private async Task ga0_const_mstr_3_routine()
        {

            //save_misc_code_values = 0;
            save_curr_1 = 0;
            save_curr_2 = 0;
            save_curr_3 = 0;
            save_curr_4 = 0;
            save_curr_5 = 0;
            save_curr_6 = 0;
            save_curr_7 = 0;
            save_curr_8 = 0;
            save_curr_9 = 0;
            save_curr_10 = 0;
            save_curr = new decimal[11];
            save_prev_1 = 0;
            save_prev_2 = 0;
            save_prev_3 = 0;
            save_prev_4 = 0;
            save_prev_5 = 0;
            save_prev_6 = 0;
            save_prev_7 = 0;
            save_prev_8 = 0;
            save_prev_9 = 0;
            save_prev_10 = 0;
            save_prev = new decimal[11];

            // perform ga1-convert-for-screen	thru	ga1-99-exit;
            // 	varying	temp;
            // 		from 1 by 1;
            // 	until	temp > 9.;

            temp = 1;
            do
            {
                await ga1_convert_for_screen();
                await ga1_99_exit();
                temp++;
            } while (temp <= 9);

            save_curr_1 = save_curr[1];
            save_curr_2 = save_curr[2];
            save_curr_3 = save_curr[3];
            save_curr_4 = save_curr[4];
            save_curr_5 = save_curr[5];
            save_curr_6 = save_curr[6];
            save_curr_7 = save_curr[7];
            save_curr_8 = save_curr[8];
            save_curr_9 = save_curr[9];
            save_curr_10 = save_curr[10];

            save_prev_1 = save_prev[1];
            save_prev_2 = save_prev[2];
            save_prev_3 = save_prev[3];
            save_prev_4 = save_prev[4];
            save_prev_5 = save_prev[5];
            save_prev_6 = save_prev[6];
            save_prev_7 = save_prev[7];
            save_prev_8 = save_prev[8];
            save_prev_9 = save_prev[9];
            save_prev_10 = save_prev[10];

            //     display scr-mask3.;
            Display("scr-mask3.");

            // if option = "I" then;             
            // 	  go to ga0-99-exit;
            // else;
            // 	  display scr-rec-3-warning.;

            if (option.ToUpper().Equals("I"))
            {
                await ga0_99_exit();
                return;
            }
            else
            {
                Display("scr-rec-3-warning.");
            }

            // if save-curr-1 = zero then;            
            // 	   accept  scr-misc-1;
            // 	   display scr-misc-1.;

            if (save_curr_1 == 0)
            {
                Display("scr-misc-1.");
                await Prompt("save_curr_1");
            }

            // if save-curr-2 = zero then;            
            // 	  accept  scr-misc-2;
            // 	   display scr-misc-2.;

            if (save_curr_2 == 0)
            {
                Display("scr-misc-2.");
                await Prompt("save_curr_2");
            }

            // if save-curr-3 = zero then;            
            // 	  accept  scr-misc-3;
            // 	  display scr-misc-3.;

            if (save_curr_3 == 0)
            {
                Display("scr-misc-3.");
                await Prompt("save_curr_3");
            }

            // if save-curr-4 = zero then;            
            // 	   accept  scr-misc-4;
            // 	   display scr-misc-4.;

            if (save_curr_4 == 0)
            {
                Display("scr-misc-4.");
                await Prompt("save_curr_4");
            }

            // if save-curr-5 = zero then;            
            // 	  accept  scr-misc-5;
            // 	  display scr-misc-5.;

            if (save_curr_5 == 0)
            {
                Display("scr-misc-5.");
                await Prompt("save_curr_5");
            }

            // if save-curr-6 = zero then;            
            // 	  accept  scr-misc-6;
            // 	   display scr-misc-6.;

            if (save_curr_6 == 0)
            {
                Display("scr-misc-6.");
                await Prompt("save_curr_6");
            }

            // if save-curr-7 = zero then;            
            // 	  accept  scr-misc-7;
            // 	  display scr-misc-7.;

            if (save_curr_7 == 0)
            {
                Display("scr-misc-7.");
                await Prompt("save_curr_7");
            }

            // if save-curr-8 = zero then;            
            // 	  accept  scr-misc-8;
            // 	  display scr-misc-8.;

            if (save_curr_8 == 0)
            {
                Display("scr-mask3.", "scr-misc-8.");
                await Prompt("save_curr_8");
            }

            // if save-curr-9 = zero then;            
            // 	  accept  scr-misc-9;
            // 	  display scr-misc-9.;

            if (save_curr_9 == 0)
            {
                Display("scr-mask3.", "scr-misc-9.");
                await Prompt("save_curr_9");
            }
        }

        private async Task ga0_99_exit()
        {
            //     exit.;
        }

        private async Task ga1_convert_for_screen()
        {

            //     multiply const-misc-curr (temp)	by	100;
            // 					giving	save-curr (temp).;
            save_curr[temp] = CONST_MISC_CURR(objConstants_mstr_rec_3, temp); // * 100;

            //     multiply const-misc-prev (temp)	by	100;
            // 					giving	save-prev (temp).;
            save_prev[temp] = CONST_MISC_PREV(objConstants_mstr_rec_3, temp); // * 100;
        }

        private async Task ga1_99_exit()
        {
            //     exit.;
        }

        private async Task ga2_convert_for_conmstr()
        {
            //     divide save-curr (temp)      	by	100;
            // 					giving	const-misc-curr (temp).;

            CONST_MISC_CURR_SET(objConstants_mstr_rec_3, temp, save_curr[temp]); // / 100);
        }

        private async Task ga2_99_exit()
        {
            //     exit.;
        }

        private async Task ha0_const_mstr_4_routine()
        {

            // if flag not = "M" then;           
            // 	  display scr-mask4.;

            if (!flag.ToUpper().Equals("M"))
            {
                Display("scr-mask4.");
            }

            // if option = "I" then;            
            // 	  go to ha0-99-exit.;

            if (option.ToUpper().Equals("I"))
            {
                await ha0_99_exit();
                return;
            }

            // 	  accept scr-ltr-1.;
            //Display("scr-ltr-1.");
            await Prompt("const_class_ltr_1");

            // if const-class-ltr-1 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 0;
            // 	    go to ha0-100-continue;
            // 	else;
            //     ws_class_nbr = 1;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok then            
            // 	 	   next sentence;
            // 	    else;
            // 	 	   go to ha0-const-mstr-4-routine.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_1))
            {
                const_nbr_classes = 0;
                await ha0_100_continue();
                return;
            }
            else
            {
                ws_class_nbr = 1;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_const_mstr_4_routine();
                    return;
                }
            }

            //     accept scr-desc-1.;
            //Display("scr-desc-1.");
            await Prompt("const_class_desc_1");
        }

        private async Task<bool> ha0_class_2()
        {
            // 	accept scr-ltr-2 .;
            //Display("scr-ltr-2.");
            await Prompt("const_class_ltr_2");

            // if const-class-ltr-2 = spaces then;            
            //     objConstants_mstr_rec_4.const_nbr_classes = 1;
            // 	   go to ha0-100-continue;
            // else;
            //      ws_class_nbr = 2;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok then;
            // 	 	   next sentence;
            // 	    else;
            // 	 	   go to ha0-class-2.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_2))
            {
                const_nbr_classes = 1;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 2;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_2();
                    return true;
                }
            }

            //  accept scr-desc-2.;
            //Display("scr-desc-2.");
            await Prompt("const_class_desc_2");
            return true;
        }

        private async Task<bool> ha0_class_3()
        {
            // 	accept scr-ltr-3.;
            //Display("scr-ltr-3.");
            await Prompt("const_class_ltr_3");

            // if const-class-ltr-3 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 2;
            // 	    go to ha0-100-continue;
            // 	else;
            //      ws_class_nbr = 3;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok then;            
            // 	 	   next sentence;
            // 	    else;
            // 	 	   go to ha0-class-3.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_3))
            {
                const_nbr_classes = 2;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 3;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_3();
                    return true;
                }
            }

            //     accept scr-desc-3.;
            //Display("scr-desc-3.");
            await Prompt("const_class_desc_3");
            return true;
        }

        private async Task<bool> ha0_class_4()
        {
            // 	accept scr-ltr-4.;
            //Display("scr-ltr-4.");
            await Prompt("const_class_ltr_4");

            // if const-class-ltr-4 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 3;
            //    go to ha0-100-continue;
            // 	else;
            //     ws_class_nbr = 4;
            // 	   perform ha2-check-other-classes thru ha2-99-exit;
            // 	   if class-ok then;            
            // 	 	 next sentence;
            // 	   else;
            // 	 	 go to ha0-class-4.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_4))
            {
                const_nbr_classes = 3;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 4;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_4();
                    return true;
                }
            }

            //     accept scr-desc-4.;
            //Display("scr-desc-4.");
            await Prompt("const_class_desc_4");
            return true;
        }

        private async Task<bool> ha0_class_5()
        {
            // 	accept scr-ltr-5.;
            //Display("scr-ltr-5.");
            await Prompt("const_class_ltr_5");

            // if const-class-ltr-5 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 4;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 5;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	next sentence;
            // 	  else;
            // 	 	go to ha0-class-5.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_5))
            {
                const_nbr_classes = 4;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 5;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_5();
                    return true;
                }
            }

            //     accept scr-desc-5.;
            //Display("scr-desc-5.");
            await Prompt("const_class_desc_5");
            return true;
        }

        private async Task<bool> ha0_class_6()
        {
            // 	accept scr-ltr-6.;
            //Display("scr-ltr-6.");
            await Prompt("const_class_ltr_6");

            // if const-class-ltr-6 = spaces then;            
            //     objConstants_mstr_rec_4.const_nbr_classes = 5;
            //     go to ha0-100-continue;
            //	else;
            //     ws_class_nbr = 6;
            // 	   perform ha2-check-other-classes thru ha2-99-exit;
            // 	   if class-ok then;            
            // 	 	  next sentence;
            // 	   else;
            // 	 	go to ha0-class-6.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_6))
            {
                const_nbr_classes = 5;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 6;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_6();
                    return true;
                }
            }

            //     accept scr-desc-6.;
            //Display("scr-desc-6.");
            await Prompt("const_class_desc_6");
            return true;
        }

        private async Task<bool> ha0_class_7()
        {
            // 	accept scr-ltr-7.;
            //Display("scr-ltr-7.");
            await Prompt("const_class_ltr_7");

            // if const-class-ltr-7 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 6;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 7;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	 next sentence;
            // 	  else;
            // 	 	go to ha0-class-7.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_7))
            {
                const_nbr_classes = 6;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 7;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_7();
                    return true;
                }

            }

            //     accept scr-desc-7.;
            //Display("scr-desc-7.");
            await Prompt("const_class_desc_7");
            return true;
        }

        private async Task<bool> ha0_class_8()
        {
            // 	accept scr-ltr-8.;
            //Display("scr-ltr-8.");
            await Prompt("const_class_ltr_8");

            // if const-class-ltr-8 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 7;
            // 	  go to ha0-100-continue;
            // else;
            //      ws_class_nbr = 8;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok then;            
            // 	 	    next sentence;
            // 	    else;
            // 	 	    go to ha0-class-8.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_8))
            {
                const_nbr_classes = 7;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 8;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_8();
                    return true;
                }
            }

            //     accept scr-desc-8.;
            //Display("scr-desc-8.");
            await Prompt("const_class_desc_8");
            return true;
        }

        private async Task<bool> ha0_class_9()
        {

            // 	accept scr-ltr-9.;
            //Display("scr-ltr-9.");
            await Prompt("const_class_ltr_9");

            // if const-class-ltr-9 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 8;
            // 	  go to ha0-100-continue;
            // else;
            //     ws_class_nbr = 9;
            // 	   perform ha2-check-other-classes thru ha2-99-exit;
            // 	   if class-ok then;            
            // 	 	  next sentence;
            // 	   else;
            // 	 	  go to ha0-class-9.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_9))
            {
                const_nbr_classes = 8;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 9;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_9();
                    return true;
                }
            }

            //     accept scr-desc-9.;
            //Display("scr-desc-9.");
            await Prompt("const_class_desc_9");
            return true;
        }

        private async Task<bool> ha0_class_10()
        {
            // 	accept scr-ltr-10.;
            //Display("scr-ltr-10.");
            await Prompt("const_class_ltr_10");

            // if const-class-ltr-10 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 9;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 10;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	next sentence;
            // 	  else;
            // 	 	go to ha0-class-10.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_10))
            {
                const_nbr_classes = 9;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 10;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    //next sentence
                }
                else
                {
                    await ha0_class_10();
                    return true;
                }
            }

            //     accept scr-desc-10.;
            //Display("scr-desc-10.");
            await Prompt("const_class_desc_10");
            return true;
        }

        private async Task<bool> ha0_class_11()
        {
            // 	accept scr-ltr-11.;
            //Display("scr-ltr-11.");
            await Prompt("const_class_ltr_11");

            // if const-class-ltr-11 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 10;
            // 	  go to ha0-100-continue;
            // 	else;
            //      ws_class_nbr = 11;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok then;            
            // 	 	   next sentence;
            // 	    else;
            // 	 	   go to ha0-class-11.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_11))
            {
                const_nbr_classes = 10;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 11;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_11();
                    return true;
                }
            }

            //     accept scr-desc-11.;
            //Display("scr-desc-11.");
            await Prompt("const_class_desc_11");
            return true;
        }

        private async Task<bool> ha0_class_12()
        {
            // 	accept scr-ltr-12.;
            //Display("scr-ltr-12.");
            await Prompt("const_class_ltr_12");

            // if const-class-ltr-12 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 11;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 12;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;           
            // 	 	next sentence;
            // 	  else;
            // 	 	go to ha0-class-12.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_12))
            {
                const_nbr_classes = 11;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 12;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next setence
                }
                else
                {
                    await ha0_class_12();
                    return true;
                }
            }

            //     accept scr-desc-12.;
            //Display("scr-desc-12.");
            await Prompt("const_class_desc_12");
            return true;
        }

        private async Task<bool> ha0_class_13()
        {
            // 	accept scr-ltr-13.;
            //Display("scr-ltr-13.");
            await Prompt("const_class_ltr_13");

            // if const-class-ltr-13 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 12;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 13;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	next sentence;
            // 	  else;
            // 	 	go to ha0-class-13.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_13))
            {
                const_nbr_classes = 12;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 13;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_13();
                    return true;
                }

            }

            //     accept scr-desc-13.;
            //Display("scr-desc-13.");
            await Prompt("const_class_desc_13");
            return true;
        }

        private async Task<bool> ha0_class_14()
        {
            // 	accept scr-ltr-14.;
            //Display("scr-ltr-14.",);
            await Prompt("const_class_ltr_14");

            // if const-class-ltr-14 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 13;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 14;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	 next sentence;
            // 	  else;
            // 	 	go to ha0-class-14.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_14))
            {
                const_nbr_classes = 13;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 14;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_14();
                    return true;
                }
            }

            //     accept scr-desc-14.;
            //Display("scr-desc-14.");
            await Prompt("const_class_desc_14");
            return true;
        }

        private async Task<bool> ha0_class_15()
        {
            // 	accept scr-ltr-15.;
            //Display("scr-ltr-15.");
            await Prompt("const_class_ltr_15");

            // if const-class-ltr-15 = spaces then;            
            //    objConstants_mstr_rec_4.const_nbr_classes = 14;
            // 	  go to ha0-100-continue;
            // else;
            //    ws_class_nbr = 15;
            // 	  perform ha2-check-other-classes thru ha2-99-exit;
            // 	  if class-ok then;            
            // 	 	next sentence;
            // 	  else;
            // 	 	go to ha0-class-15.;

            if (string.IsNullOrWhiteSpace(const_class_ltr_15))
            {
                const_nbr_classes = 14;
                await ha0_100_continue();
                return false;
            }
            else
            {
                ws_class_nbr = 15;
                await ha2_check_other_classes();
                await ha2_99_exit();
                if (class_flag.ToUpper().Equals(class_ok))
                {
                    // next sentence
                }
                else
                {
                    await ha0_class_15();
                    return true;
                }
            }

            //     accept scr-desc-15.;
            //Display("scr-desc-15.");
            await Prompt("const_class_desc_15");

            objConstants_mstr_rec_4.CONST_NBR_CLASSES = 15;
            return true;
        }

        private async Task ha0_100_continue()
        {
            //  add 1, const-nbr-classes giving	ws-class-nbr.;

            ws_class_nbr = const_nbr_classes + 1;

            //  perform ha1-clear-remaining		thru	ha1-99-exit;
            // 	varying temp;
            // 	from    ws-class-nbr;
            // 	by      1;
            // 	until	temp > 15.;

            temp = ws_class_nbr;

            do
            {
                await ha1_clear_remaining();
                await ha1_99_exit();
                temp++;
            } while (temp <= 15);

            //     display scr-mask4.;
            Display("scr-mask4.");
        }

        private async Task ha0_99_exit()
        {
            //     exit.;
        }

        private async Task ha1_clear_remaining()
        {

            //const_class_ltr[temp] = "";
            //const_class_desc[temp] = "";            

            switch (temp)
            {
                case 1:
                    const_class_ltr_1 = "";
                    const_class_desc_1 = "";
                    break;
                case 2:
                    const_class_ltr_2 = "";
                    const_class_desc_2 = "";
                    break;
                case 3:
                    const_class_ltr_3 = "";
                    const_class_desc_3 = "";
                    break;
                case 4:
                    const_class_ltr_4 = "";
                    const_class_desc_4 = "";
                    break;
                case 5:
                    const_class_ltr_5 = "";
                    const_class_desc_5 = "";
                    break;
                case 6:
                    const_class_ltr_6 = "";
                    const_class_desc_6 = "";
                    break;
                case 7:
                    const_class_ltr_7 = "";
                    const_class_desc_7 = "";
                    break;
                case 8:
                    const_class_ltr_8 = "";
                    const_class_desc_8 = "";
                    break;
                case 9:
                    const_class_ltr_9 = "";
                    const_class_desc_9 = "";
                    break;
                case 10:
                    const_class_ltr_10 = "";
                    const_class_desc_10 = "";
                    break;
                case 11:
                    const_class_ltr_11 = "";
                    const_class_desc_11 = "";
                    break;
                case 12:
                    const_class_ltr_12 = "";
                    const_class_desc_12 = "";
                    break;
                case 13:
                    const_class_ltr_13 = "";
                    const_class_desc_13 = "";
                    break;
                case 14:
                    const_class_ltr_14 = "";
                    const_class_desc_14 = "";
                    break;
                case 15:
                    const_class_ltr_15 = "";
                    const_class_desc_15 = "";
                    break;
            }

            //CONST_CLASS_LTR_SET(objConstants_mstr_rec_4, temp, "");
            //CONST_CLASS_DESC_SET(objConstants_mstr_rec_4, temp, "");
        }

        private async Task ha1_99_exit()
        {
            //     exit.;
        }

        private async Task ha2_check_other_classes()
        {
            class_flag = "Y";

            //     perform ha21-compare-ltrs		thru	ha21-99-exit;
            // 	varying temp;
            // 	from    1;
            // 	by      1;
            // 	until	temp > const-nbr-classes;
            // 	     or class-not-ok.;

            temp = 1;

            do
            {
                await ha21_compare_ltrs();
                await ha21_99_exit();
                temp++;
            } while (temp <= const_nbr_classes && class_flag.ToUpper().Equals(class_ok));
        }

        private async Task ha2_99_exit()
        {
            //     exit.;
        }

        private async Task ha21_compare_ltrs()
        {

            // if    const-class-ltr (temp)     = const-class-ltr (ws-class-nbr);
            //       and temp  not = ws-class-nbr then            
            //       class_flag = "N";
            //        err_ind = 8;
            // 	perform za0-common-error	thru	za0-99-exit.;

            if (CONST_CLASS_LTR(objConstants_mstr_rec_4, temp) == CONST_CLASS_LTR(objConstants_mstr_rec_4, ws_class_nbr) && temp != ws_class_nbr)
            {
                class_flag = "N";
                err_ind = 8;
                await za0_common_error();
                await za0_99_exit();
            }
        }

        private async Task ha21_99_exit()
        {
            //     exit.;
        }

        private async Task ia0_const_mstr_5_routine()
        {
            // if flag not = "M" then;            
            // 	   perform ia1-display-screen5   		thru ia1-99-exit.;

            if (!flag.ToUpper().Equals("M"))
            {
                await ia1_display_screen5();
                await ia1_99_exit();
            }

            // if option = "I" then;            
            // 	  go to ia0-99-exit.;

            if (option.ToUpper().Equals("I"))
            {
                await ia0_99_exit();
                return;
            }

            pline = 5;
            pcol1 = 13;
            pcol2 = 20;

            //     perform ia2-accept-nx-avail-pat		thru ia2-99-exit;
            // 		varying i from 1 by 1;
            // 		until   i > 13.;

            i = 1;

            do
            {
                await ia2_accept_nx_avail_pat();
                await ia2_99_exit();
                i++;
            } while (i <= 13);


            pline = 5;
            pcol1 = 50;
            pcol2 = 57;
            //     perform ia2-accept-nx-avail-pat		thru ia2-99-exit;
            // 		varying i from 14 by 1;
            // 		until   i > 24.;

            i = 14;

            do
            {
                await ia2_accept_nx_avail_pat();
                await ia2_99_exit();
                i++;
            } while (i <= 24);

            pline = 16;
            i = 25;

            //     display scr-con-nbr.; // todo: this is a dynamic row.  Check GridAddControlListRowByRow
            //     accept scr-con-nbr.;
            await Prompt("const_con_nbr[" + i.ToString() + "]");

            //     display scr-nx-avail-pat.;   // todo: this is a dynamic row. Check GridAddControlListRowByRow
            //     accept scr-nx-avail-pat.;

            await Prompt("const_nx_avail_pat[" + i.ToString() + "]");
        }

        private async Task ia0_99_exit()
        {
            //     exit.;
        }

        private async Task ia1_display_screen5()
        {

            //     display scr-mask5-lit.;
            Display("scr-mask5-lit.");

            pline = 5;
            pcol1 = 13;
            pcol2 = 20;

            //     perform ia11-display-scr-mask5	thru ia11-99-exit;
            // 		varying i from 1 by 1;
            // 		until   i > 13.;

            i = 1;

            do
            {
                await ia11_display_scr_mask5();
                await ia11_99_exit();
                i++;
            } while (i <= 13);

            pline = 5;
            pcol1 = 50;
            pcol2 = 57;
            //     perform ia11-display-scr-mask5	thru ia11-99-exit;
            // 		varying i from 14 by 1;
            // 		until   i > 25.;

            i = 14;

            do
            {
                await ia11_display_scr_mask5();
                await ia11_99_exit();
                i++;
            } while (i <= 25);

        }

        private async Task ia1_99_exit()
        {
            //     exit.;
        }

        private async Task ia11_display_scr_mask5()
        {

            //     display scr-mask5.;
            Display("scr-mask5.");

            //     add 1					to pline.;
            pline++;
            Debug.WriteLine("Row " + pline + " " + "Col " + pcol2);
        }

        private async Task ia11_99_exit()
        {
            //     exit.;
        }

        private async Task ia2_accept_nx_avail_pat()
        {
            //     display scr-nx-avail-pat.;
            Display("scr-nx-avail-pat.");

            //     accept scr-nx-avail-pat.;
            await Prompt("const_nx_avail_pat[" + i.ToString() + "]");

            //     add 1					to pline.;
            pline++;
        }

        private async Task ia2_99_exit()
        {
            //     exit.;
        }

        private async Task ma1_read_iconst_mstr()
        {

            flag_lock = "N";

            // if option = "I" then;            
            // 	read   iconst-mstr  invalid key;            
            //         flag = "N";
            // 	        go to ma1-99-exit.;

            if (option.ToUpper().Equals("I"))
            {
                await Record_To_ScreenVariables();
            }

            // if option not = "I" then;            
            //    	read   iconst-mstr    lock invalid key;            
            //             flag = "N";
            // 	            go to ma1-99-exit.;

            if (!option.ToUpper().Equals("I"))
            {
                await Record_To_ScreenVariables();
            }

            //  if rec-locked then;            
            // 	    go to ma1-read-iconst-mstr.;

            if (flag_lock.ToUpper().Equals(rec_locked))
            {
                await ma1_read_iconst_mstr();
                return;
            }

            //     add 1				to ctr-const-mstr-reads.;
            ctr_const_mstr_reads++;
        }

        private async Task ma1_99_exit()
        {
            //     exit.;
        }

        private async Task pa1_re_write_iconst_mstr()
        {

            // 	rewrite iconst-mstr-rec.;
            // 	unlock iconst-mstr  record.;
            //     add 1				to ctr-const-mstr-changes.;

            await Rewrite_Iconst_Master(Util.NumInt(ws_const_mstr_ident));
            ctr_const_mstr_changes++;
        }

        private async Task pa1_99_exit()
        {
            //     exit.;
        }

        private async Task ra0_write_audit_rpt()
        {
            // todo: Check the  length: why is it only 132bytes in COBOL???

            if (Util.NumInt(ws_const_mstr_ident) == 1)
            {
                objAudit_record.Audit_record1 = Util.Str(objConstants_mstr_rec_1.CONST_REC_NBR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_21).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR1).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_22).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR2).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_23).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR3).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_24).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR4).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_25).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR5).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_26).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR6).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_27).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR7).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_28).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR8).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_29).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR9).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_210).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR10).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_211).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR11).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_212).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR12).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_23).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR13).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_214).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR14).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_215).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR15).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_216).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR16).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_217).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR17).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_218).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR18).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_219).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR19).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_220).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR20).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_221).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR21).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_222).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR22).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_223).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR23).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_224).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR24).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_225).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR25).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_226).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR26).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_227).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR27).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_228).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR28).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_229).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR29).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_230).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR30).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_231).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR31).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_232).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR32).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_233).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR33).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_234).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR34).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_235).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR35).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_236).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR36).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_237).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR37).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_238).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR38).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_239).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR39).PadRight(4) +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_240).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR40).PadRight(4) +
                                                objConstants_mstr_rec_1.FILLER;
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 2)
            {
                objAudit_record.Audit_record1 = Util.Str(objConstants_mstr_rec_2.CONST_REC_NBR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_YY_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_MM_CURR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_DD_CURR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_BILATERAL_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_IC_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SR_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_WCB_CURR).PadLeft(8, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_ASST_H_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_REG_H_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_CERT_H_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_ASST_A_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_REG_A_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_CERT_A_CURR).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_YY_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_MM_PREV).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_DD_PREV).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_BILATERAL_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_IC_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SR_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_WCB_PREV).PadLeft(8, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_ASST_H_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_REG_H_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_CERT_H_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_ASST_A_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_REG_A_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_CERT_A_PREV).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_MAX_NBR_RATES).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION1).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP1).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR1).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV1).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION2).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP2).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR2).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV2).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION3).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP3).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR3).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV3).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION4).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP4).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR4).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV4).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION5).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP5).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR5).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV5).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION6).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP6).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR6).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV6).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION7).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP7).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR7).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV7).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION8).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP8).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR8).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV8).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION9).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP9).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR9).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV9).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION10).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP10).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR10).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV10).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION11).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP11).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR11).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV11).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION12).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP12).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR12).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV12).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION13).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP13).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR13).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV13).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION14).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP14).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR14).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV14).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION15).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP15).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR15).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV15).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION16).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP16).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR16).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV16).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION17).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP17).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR17).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV17).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION18).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP18).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR18).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV18).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_SECTION19).PadRight(2, ' ') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_GROUP19).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_CURR19).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.CONST_RATE_PREV19).PadLeft(4, '0') +
                                                Util.Str(objConstants_mstr_rec_2.FILLER).PadRight(40, ' ');
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 3)
            {
                objAudit_record.Audit_record1 = Util.Str(objConstants_mstr_rec_3.CONST_REC_NBR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR1).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR2).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR3).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR4).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR5).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR6).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR7).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR8).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_CURR9).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV1).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV2).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV3).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV4).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV5).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV6).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV7).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV8).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.CONST_MISC_PREV9).PadLeft(5, '0') +
                                                Util.Str(objConstants_mstr_rec_3.FILLER).PadRight(292, ' ');
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 4)
            {
                objAudit_record.Audit_record1 = Util.Str(objConstants_mstr_rec_4.CONST_REC_NBR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_NBR_CLASSES).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR1).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC1).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR2).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC2).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR3).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC3).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR4).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC4).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR5).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC5).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR6).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC6).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR7).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC7).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR8).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC8).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR9).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC9).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR10).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC10).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR11).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC11).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR12).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC12).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR13).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC13).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR14).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC14).PadRight(24, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR15).PadRight(1, ' ') +
                                                Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC15).PadRight(24, ' ');
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 5)
            {
                objAudit_record.Audit_record1 = Util.Str(objConstants_mstr_rec_5.CONST_REC_NBR).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR1).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT1).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR2).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT2).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR3).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT3).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR4).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT4).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR5).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT5).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR6).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT6).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR7).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT7).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR8).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT8).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR9).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT9).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR10).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT10).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR11).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT11).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR12).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT12).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR13).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT13).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR14).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT14).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR15).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT15).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR16).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT16).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR17).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT17).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR18).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT18).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR19).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT19).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR20).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT20).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR21).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT21).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR22).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT22).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR23).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT23).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR24).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT24).PadLeft(12, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_CON_NBR25).PadLeft(2, '0') +
                                                Util.Str(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT25).PadLeft(12, '0');
            }
            else
            {
                objAudit_record.Audit_record1 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2).PadLeft(2, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR).PadRight(4, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME).PadRight(20, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR).PadLeft(2, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM).PadLeft(2, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD).PadLeft(2, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L1).PadRight(25, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L2).PadRight(25, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L3).PadRight(25, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR).PadRight(1, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM1).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM2).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM3).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM4).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_BATCH_NBR).PadRight(6, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_REDUCTION_FACTOR).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.ICONST_OVERPAY_FACTOR).PadLeft(4, '0') +
                                                Util.Str(objIconst_mstr_rec.FILLER).PadRight(106, ' ') +
                                                Util.Str(objIconst_mstr_rec.ICONST_CLINIC_PAY_BATCH_NBR).PadRight(6, ' ') +
                                                Util.Str(objIconst_mstr_rec.FILLER).PadRight(130, ' ');

            }
            //     write audit-record.;
            objAudit_File.AppendOutputFile(objAudit_record.Audit_record1, true);

            //     add 1				to ctr-audit-rpt-writes.;
            ctr_audit_rpt_writes++;
        }

        private async Task ra0_99_exit()
        {
            //     exit.;
        }

        private async Task az0_end_of_job()
        {
            //     display blank-screen.;
            EraseRowRange(1, 24);

            //     accept sys-time			from time.;
            sys_time_grp = DateTime.Now.ToString("h:mm:ss tt");

            //move sys-hrs            to run-hrs.
            run_hrs_child = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min_child = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec_child = Convert.ToInt32(DateTime.Now.ToString("ss"));

            //     display scr-closing-screen.;
            Display("scr-closing-screen.");

            //     display confirm.;
            Display("confirm.");

            //     close iconst-mstr.;
            //     close  audit-file.;
            //     chain "$obj/menu".;
            //     stop run.;
        }

        private async Task az0_99_exit()
        {
            //     exit.;
        }

        private async Task za0_common_error()
        {
            err_msg_comment = err_msg[err_ind];

            //     display err-msg-line.;
            Display(false, "err-msg-line.");

            //     accept scr-confirm.;
            //await Prompt("scr-confirm");
            Display("scr-confirm");
            await Prompt("confirm_space");

            //     display blank-line-24.;
            //Display("blank-line-24.");
            Display("scr-confirm", false);
            Display("err-msg-line.",false);
            err_ind = 0;
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
        }

        // y2k_default_sysdate_century.rtn
        private async Task y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        #endregion

        #region Extension

        private async Task Record_To_ScreenVariables()
        {
            if (Util.NumInt(ws_const_mstr_ident) == 1)
            {
                Constants_mstr_rec_1_Collection = new CONSTANTS_MSTR_REC_1
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_1_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_1 = Constants_mstr_rec_1_Collection.FirstOrDefault();
                    const_max_nbr_clinics = Util.NumInt(objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS);
                    const_clinic_1_2_nbr_1 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_21);
                    const_clinic_1_2_nbr_2 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_22);
                    const_clinic_1_2_nbr_3 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_23);
                    const_clinic_1_2_nbr_4 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_24);
                    const_clinic_1_2_nbr_5 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_25);
                    const_clinic_1_2_nbr_6 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_26);
                    const_clinic_1_2_nbr_7 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_27);
                    const_clinic_1_2_nbr_8 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_28);
                    const_clinic_1_2_nbr_9 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_29);
                    const_clinic_1_2_nbr_10 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_210);
                    const_clinic_1_2_nbr_11 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_211);
                    const_clinic_1_2_nbr_12 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_212);
                    const_clinic_1_2_nbr_13 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_213);
                    const_clinic_1_2_nbr_14 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_214);
                    const_clinic_1_2_nbr_15 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_215);
                    const_clinic_1_2_nbr_16 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_216);
                    const_clinic_1_2_nbr_17 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_217);
                    const_clinic_1_2_nbr_18 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_218);
                    const_clinic_1_2_nbr_19 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_219);
                    const_clinic_1_2_nbr_20 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_220);
                    const_clinic_1_2_nbr_21 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_221);
                    const_clinic_1_2_nbr_22 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_222);
                    const_clinic_1_2_nbr_23 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_223);
                    const_clinic_1_2_nbr_24 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_224);
                    const_clinic_1_2_nbr_25 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_225);
                    const_clinic_1_2_nbr_26 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_226);
                    const_clinic_1_2_nbr_27 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_227);
                    const_clinic_1_2_nbr_28 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_228);
                    const_clinic_1_2_nbr_29 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_229);
                    const_clinic_1_2_nbr_30 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_230);
                    const_clinic_1_2_nbr_31 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_231);
                    const_clinic_1_2_nbr_32 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_232);
                    const_clinic_1_2_nbr_33 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_233);
                    const_clinic_1_2_nbr_34 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_234);
                    const_clinic_1_2_nbr_35 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_235);
                    const_clinic_1_2_nbr_36 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_236);
                    const_clinic_1_2_nbr_37 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_237);
                    const_clinic_1_2_nbr_38 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_238);
                    const_clinic_1_2_nbr_39 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_239);
                    const_clinic_1_2_nbr_40 = Util.NumInt(objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_240);

                    const_clinic_nbr_1 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR1);
                    const_clinic_nbr_2 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR2);
                    const_clinic_nbr_3 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR3);
                    const_clinic_nbr_4 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR4);
                    const_clinic_nbr_5 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR5);
                    const_clinic_nbr_6 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR6);
                    const_clinic_nbr_7 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR7);
                    const_clinic_nbr_8 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR8);
                    const_clinic_nbr_9 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR9);
                    const_clinic_nbr_10 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR10);
                    const_clinic_nbr_11 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR11);
                    const_clinic_nbr_12 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR12);
                    const_clinic_nbr_13 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR13);
                    const_clinic_nbr_14 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR14);
                    const_clinic_nbr_15 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR15);
                    const_clinic_nbr_16 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR16);
                    const_clinic_nbr_17 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR17);
                    const_clinic_nbr_18 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR18);
                    const_clinic_nbr_19 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR19);
                    const_clinic_nbr_20 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR20);
                    const_clinic_nbr_21 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR21);
                    const_clinic_nbr_22 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR22);
                    const_clinic_nbr_23 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR23);
                    const_clinic_nbr_24 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR24);
                    const_clinic_nbr_25 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR25);
                    const_clinic_nbr_26 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR26);
                    const_clinic_nbr_27 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR27);
                    const_clinic_nbr_28 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR28);
                    const_clinic_nbr_29 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR29);
                    const_clinic_nbr_30 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR30);
                    const_clinic_nbr_31 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR31);
                    const_clinic_nbr_32 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR32);
                    const_clinic_nbr_33 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR33);
                    const_clinic_nbr_34 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR34);
                    const_clinic_nbr_35 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR35);
                    const_clinic_nbr_36 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR36);
                    const_clinic_nbr_37 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR37);
                    const_clinic_nbr_38 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR38);
                    const_clinic_nbr_39 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR39);
                    const_clinic_nbr_40 = Util.Str(objConstants_mstr_rec_1.CONST_CLINIC_NBR40);

                    const_clinic_1_2_nbr_41 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).Substring(0, 2));
                    const_clinic_nbr_41 = Util.Str(objConstants_mstr_rec_1.FILLER).Substring(2, 4);

                    const_clinic_1_2_nbr_42 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(6, 2));
                    const_clinic_nbr_42 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(8, 4);
                    const_clinic_1_2_nbr_43 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(12, 2));
                    const_clinic_nbr_43 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(14, 4);
                    const_clinic_1_2_nbr_44 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(18, 2));
                    const_clinic_nbr_44 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(20, 4);
                    const_clinic_1_2_nbr_45 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(24, 2));
                    const_clinic_nbr_45 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(26, 4);
                    const_clinic_1_2_nbr_46 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(30, 2));
                    const_clinic_nbr_46 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(32, 4);
                    const_clinic_1_2_nbr_47 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(36, 2));
                    const_clinic_nbr_47 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(38, 4);
                    const_clinic_1_2_nbr_48 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(42, 2));
                    const_clinic_nbr_48 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(44, 4);
                    const_clinic_1_2_nbr_49 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(48, 2));
                    const_clinic_nbr_49 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(50, 4);
                    const_clinic_1_2_nbr_50 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(54, 2));
                    const_clinic_nbr_50 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(56, 4);
                    const_clinic_1_2_nbr_51 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(60, 2));
                    const_clinic_nbr_51 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(62, 4);
                    const_clinic_1_2_nbr_52 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(66, 2));
                    const_clinic_nbr_52 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(68, 4);
                    const_clinic_1_2_nbr_53 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(72, 2));
                    const_clinic_nbr_53 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(74, 4);
                    const_clinic_1_2_nbr_54 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(78, 2));
                    const_clinic_nbr_54 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(80, 4);
                    const_clinic_1_2_nbr_55 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(84, 2));
                    const_clinic_nbr_55 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(86, 4);
                    const_clinic_1_2_nbr_56 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(90, 2));
                    const_clinic_nbr_56 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(92, 4);
                    const_clinic_1_2_nbr_57 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(96, 2));
                    const_clinic_nbr_57 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(98, 4);
                    const_clinic_1_2_nbr_58 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(102, 2));
                    const_clinic_nbr_58 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(104, 4);
                    const_clinic_1_2_nbr_59 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(108, 2));
                    const_clinic_nbr_59 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(110, 4);
                    const_clinic_1_2_nbr_60 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(114, 2));
                    const_clinic_nbr_60 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(116, 4);
                    const_clinic_1_2_nbr_61 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(120, 2));
                    const_clinic_nbr_61 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(122, 4);
                    const_clinic_1_2_nbr_62 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(126, 2));
                    const_clinic_nbr_62 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(128, 4);
                    const_clinic_1_2_nbr_63 = Util.NumInt(Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(132, 2));
                    const_clinic_nbr_63 = Util.Str(objConstants_mstr_rec_1.FILLER).PadRight(138).Substring(134, 4);


                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 2)
            {
                Constants_mstr_rec_2_Collection = new CONSTANTS_MSTR_REC_2
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_2_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_2 = Constants_mstr_rec_2_Collection.FirstOrDefault();
                    const_yy_curr = Util.NumInt(objConstants_mstr_rec_2.CONST_YY_CURR);
                    const_mm_curr = Util.NumInt(objConstants_mstr_rec_2.CONST_MM_CURR);
                    const_dd_curr = Util.NumInt(objConstants_mstr_rec_2.CONST_DD_CURR);
                    const_bilateral_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_BILATERAL_CURR);
                    const_ic_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_IC_CURR);
                    const_sr_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_SR_CURR);
                    const_wcb_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_WCB_CURR);
                    const_asst_h_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_ASST_H_CURR);
                    const_reg_h_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_REG_H_CURR);
                    const_cert_h_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_CERT_H_CURR);
                    const_asst_a_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_ASST_A_CURR);
                    const_reg_a_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_REG_A_CURR);
                    const_cert_a_curr = Util.NumDec(objConstants_mstr_rec_2.CONST_CERT_A_CURR);
                    const_yy_prev = Util.NumInt(objConstants_mstr_rec_2.CONST_YY_PREV);
                    const_mm_prev = Util.NumInt(objConstants_mstr_rec_2.CONST_MM_PREV);
                    const_dd_prev = Util.NumInt(objConstants_mstr_rec_2.CONST_DD_PREV);
                    const_bilateral_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_BILATERAL_PREV);
                    const_ic_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_IC_PREV);
                    const_sr_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_SR_PREV);
                    const_wcb_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_WCB_PREV);
                    const_asst_h_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_ASST_H_PREV);
                    const_reg_h_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_REG_H_PREV);
                    const_cert_h_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_CERT_H_PREV);
                    const_asst_a_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_ASST_A_PREV);
                    const_reg_a_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_REG_A_PREV);
                    const_cert_a_prev = Util.NumDec(objConstants_mstr_rec_2.CONST_CERT_A_PREV);
                    const_max_nbr_rates = Util.NumInt(objConstants_mstr_rec_2.CONST_MAX_NBR_RATES);
                    const_sect_1 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION1);
                    const_sect_2 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION2);
                    const_sect_3 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION3);
                    const_sect_4 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION4);
                    const_sect_5 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION5);
                    const_sect_6 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION6);
                    const_sect_7 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION7);
                    const_sect_8 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION8);
                    const_sect_9 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION9);
                    const_sect_10 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION10);
                    const_sect_11 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION11);
                    const_sect_12 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION12);
                    const_sect_13 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION13);
                    const_sect_14 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION14);
                    const_sect_15 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION15);
                    const_sect_16 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION16);
                    const_sect_17 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION17);
                    const_sect_18 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION18);
                    const_sect_19 = Util.Str(objConstants_mstr_rec_2.CONST_SECTION19);
                    const_group_1 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP1);
                    const_group_2 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP2);
                    const_group_3 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP3);
                    const_group_4 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP4);
                    const_group_5 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP5);
                    const_group_6 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP6);
                    const_group_7 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP7);
                    const_group_8 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP8);
                    const_group_9 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP9);
                    const_group_10 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP10);
                    const_group_11 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP11);
                    const_group_12 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP12);
                    const_group_13 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP13);
                    const_group_14 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP14);
                    const_group_15 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP15);
                    const_group_16 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP16);
                    const_group_17 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP17);
                    const_group_18 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP18);
                    const_group_19 = Util.NumInt(objConstants_mstr_rec_2.CONST_GROUP19);
                    const_curr_1 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR1);
                    const_curr_2 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR2);
                    const_curr_3 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR3);
                    const_curr_4 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR4);
                    const_curr_5 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR5);
                    const_curr_6 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR6);
                    const_curr_7 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR7);
                    const_curr_8 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR8);
                    const_curr_9 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR9);
                    const_curr_10 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR10);
                    const_curr_11 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR11);
                    const_curr_12 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR12);
                    const_curr_13 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR13);
                    const_curr_14 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR14);
                    const_curr_15 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR15);
                    const_curr_16 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR16);
                    const_curr_17 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR17);
                    const_curr_18 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR18);
                    const_curr_19 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_CURR19);
                    const_prev_1 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV1);
                    const_prev_2 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV2);
                    const_prev_3 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV3);
                    const_prev_4 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV4);
                    const_prev_5 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV5);
                    const_prev_6 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV6);
                    const_prev_7 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV7);
                    const_prev_8 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV8);
                    const_prev_9 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV9);
                    const_prev_10 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV10);
                    const_prev_11 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV11);
                    const_prev_12 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV12);
                    const_prev_13 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV13);
                    const_prev_14 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV14);
                    const_prev_15 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV15);
                    const_prev_16 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV16);
                    const_prev_17 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV17);
                    const_prev_18 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV18);
                    const_prev_19 = Util.NumDec(objConstants_mstr_rec_2.CONST_RATE_PREV19);
                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 3)
            {
                Constants_mstr_rec_3_Collection = new CONSTANTS_MSTR_REC_3
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_3_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_3 = Constants_mstr_rec_3_Collection.FirstOrDefault();
                    save_curr_1 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR1);
                    save_curr_2 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR2);
                    save_curr_3 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR3);
                    save_curr_4 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR4);
                    save_curr_5 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR5);
                    save_curr_6 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR6);
                    save_curr_7 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR7);
                    save_curr_8 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR8);
                    save_curr_9 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_CURR9);

                    save_prev_1 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV1);
                    save_prev_2 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV2);
                    save_prev_3 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV3);
                    save_prev_4 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV4);
                    save_prev_5 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV5);
                    save_prev_6 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV6);
                    save_prev_7 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV7);
                    save_prev_8 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV8);
                    save_prev_9 = Util.NumDec(objConstants_mstr_rec_3.CONST_MISC_PREV9);
                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 4)
            {
                Constants_mstr_rec_4_Collection = new CONSTANTS_MSTR_REC_4
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_4_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_4 = Constants_mstr_rec_4_Collection.FirstOrDefault();
                    const_nbr_classes = Util.NumInt(objConstants_mstr_rec_4.CONST_NBR_CLASSES);
                    const_class_ltr_1 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR1);
                    const_class_ltr_2 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR2);
                    const_class_ltr_3 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR3);
                    const_class_ltr_4 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR4);
                    const_class_ltr_5 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR5);
                    const_class_ltr_6 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR6);
                    const_class_ltr_7 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR7);
                    const_class_ltr_8 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR8);
                    const_class_ltr_9 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR9);
                    const_class_ltr_10 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR10);
                    const_class_ltr_11 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR11);
                    const_class_ltr_12 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR12);
                    const_class_ltr_13 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR13);
                    const_class_ltr_14 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR14);
                    const_class_ltr_15 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_LTR15);
                    const_class_desc_1 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC1);
                    const_class_desc_2 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC2);
                    const_class_desc_3 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC3);
                    const_class_desc_4 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC4);
                    const_class_desc_5 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC5);
                    const_class_desc_6 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC6);
                    const_class_desc_7 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC7);
                    const_class_desc_8 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC8);
                    const_class_desc_9 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC9);
                    const_class_desc_10 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC10);
                    const_class_desc_11 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC11);
                    const_class_desc_12 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC12);
                    const_class_desc_13 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC13);
                    const_class_desc_14 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC14);
                    const_class_desc_15 = Util.Str(objConstants_mstr_rec_4.CONST_CLASS_DESC15);
                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 5)
            {
                Constants_mstr_rec_5_Collection = new CONSTANTS_MSTR_REC_5
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_5_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_5 = Constants_mstr_rec_5_Collection.FirstOrDefault();

                    const_con_nbr.Clear();
                    const_con_nbr.Add(0);
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR1));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR2));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR3));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR4));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR5));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR6));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR7));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR8));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR9));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR10));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR11));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR12));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR13));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR14));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR15));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR16));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR17));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR18));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR19));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR20));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR21));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR22));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR23));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR24));
                    const_con_nbr.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_CON_NBR25));

                    const_nx_avail_pat.Clear();
                    const_nx_avail_pat.Add(0);
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT1));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT2));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT3));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT4));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT5));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT6));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT7));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT8));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT9));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT10));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT11));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT12));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT13));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT14));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT15));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT16));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT17));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT18));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT19));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT20));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT21));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT22));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT23));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT24));
                    const_nx_avail_pat.Add(Util.NumInt(objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT25));

                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 6)
            {
                Constants_mstr_rec_6_Collection = new CONSTANTS_MSTR_REC_6
                {
                    WhereConst_rec_nbr = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Constants_mstr_rec_6_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_6 = Constants_mstr_rec_6_Collection.FirstOrDefault();
                    // todo...
                }
            }
            else if (Util.NumInt(ws_const_mstr_ident) == 7)
            {
                /*Constants_mstr_rec_7_Collection = new CONSTANTS_MSTR_REC_7
                {
                    WhereIconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident.PadRight(2, '0'))   // todo... ???? from Record Number 7, not sure what   ICONST_CLINIC_NBR_1_2 values is selected ???
                }.Collection(); */

                Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
                {
                    WhereIconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Iconst_mstr_rec_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    //objConstants_mstr_rec_7 = Constants_mstr_rec_7_Collection.FirstOrDefault();

                    objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();
                    iconst_clinic_nbr_1_2 = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
                    iconst_clinic_nbr = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR);
                    iconst_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);
                    iconst_clinic_cycle_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
                    iconst_date_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
                    iconst_date_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
                    iconst_date_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
                    iconst_clinic_card_colour = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR);
                    iconst_clinic_addr_l1 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L1);
                    iconst_clinic_addr_l2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L2);
                    iconst_clinic_addr_l3 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L3);
                    iconst_clinic_over_lim1 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM1);
                    iconst_clinic_under_lim2 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM2);
                    iconst_clinic_under_lim3 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM3);
                    iconst_clinic_over_lim4 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM4);
                    iconst_clinic_pay_batch_nbr = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_PAY_BATCH_NBR);
                    iconst_clinic_batch_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_BATCH_NBR);
                    iconst_reduction_factor = Util.NumDec(objIconst_mstr_rec.ICONST_REDUCTION_FACTOR);
                    iconst_overpay_factor = Util.NumDec(objIconst_mstr_rec.ICONST_OVERPAY_FACTOR);

                }
            }
            else
            {
                Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
                {
                    WhereIconst_clinic_nbr_1_2 = Util.NumInt(ws_const_mstr_ident)
                }.Collection();

                if (Iconst_mstr_rec_Collection.Count() == 0)
                {
                    flag = "N";
                    await ma1_99_exit();
                    return;
                }
                else
                {
                    objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();
                    iconst_clinic_nbr_1_2 = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2);
                    iconst_clinic_nbr = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR);
                    iconst_clinic_name = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);
                    iconst_clinic_cycle_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR);
                    iconst_date_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
                    iconst_date_period_end_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
                    iconst_date_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
                    iconst_clinic_card_colour = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR);
                    iconst_clinic_addr_l1 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L1);
                    iconst_clinic_addr_l2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L2);
                    iconst_clinic_addr_l3 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_ADDR_L3);
                    iconst_clinic_over_lim1 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM1);
                    iconst_clinic_under_lim2 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM2);
                    iconst_clinic_under_lim3 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM3);
                    iconst_clinic_over_lim4 = Util.NumDec(objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM4);
                    iconst_clinic_pay_batch_nbr = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_PAY_BATCH_NBR);
                    iconst_clinic_batch_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_BATCH_NBR);
                    iconst_reduction_factor = Util.NumDec(objIconst_mstr_rec.ICONST_REDUCTION_FACTOR);
                    iconst_overpay_factor = Util.NumDec(objIconst_mstr_rec.ICONST_OVERPAY_FACTOR);
                }
            }
        }

        private async Task Const_Clinic_Nbr_1_2_Screen_Variable_SetValue(int index, int value)
        {
            switch (index)
            {
                case 1:
                    const_clinic_1_2_nbr_1 = value;
                    break;
                case 2:
                    const_clinic_1_2_nbr_2 = value;
                    break;
                case 3:
                    const_clinic_1_2_nbr_3 = value;
                    break;
                case 4:
                    const_clinic_1_2_nbr_4 = value;
                    break;
                case 5:
                    const_clinic_1_2_nbr_5 = value;
                    break;
                case 6:
                    const_clinic_1_2_nbr_6 = value;
                    break;
                case 7:
                    const_clinic_1_2_nbr_7 = value;
                    break;
                case 8:
                    const_clinic_1_2_nbr_8 = value;
                    break;
                case 9:
                    const_clinic_1_2_nbr_9 = value;
                    break;
                case 10:
                    const_clinic_1_2_nbr_10 = value;
                    break;
                case 11:
                    const_clinic_1_2_nbr_11 = value;
                    break;
                case 12:
                    const_clinic_1_2_nbr_12 = value;
                    break;
                case 13:
                    const_clinic_1_2_nbr_13 = value;
                    break;
                case 14:
                    const_clinic_1_2_nbr_14 = value;
                    break;
                case 15:
                    const_clinic_1_2_nbr_15 = value;
                    break;
                case 16:
                    const_clinic_1_2_nbr_16 = value;
                    break;
                case 17:
                    const_clinic_1_2_nbr_17 = value;
                    break;
                case 18:
                    const_clinic_1_2_nbr_18 = value;
                    break;
                case 19:
                    const_clinic_1_2_nbr_19 = value;
                    break;
                case 20:
                    const_clinic_1_2_nbr_20 = value;
                    break;
                case 21:
                    const_clinic_1_2_nbr_21 = value;
                    break;
                case 22:
                    const_clinic_1_2_nbr_22 = value;
                    break;
                case 23:
                    const_clinic_1_2_nbr_23 = value;
                    break;
                case 24:
                    const_clinic_1_2_nbr_24 = value;
                    break;
                case 25:
                    const_clinic_1_2_nbr_25 = value;
                    break;
                case 26:
                    const_clinic_1_2_nbr_26 = value;
                    break;
                case 27:
                    const_clinic_1_2_nbr_27 = value;
                    break;
                case 28:
                    const_clinic_1_2_nbr_28 = value;
                    break;
                case 29:
                    const_clinic_1_2_nbr_29 = value;
                    break;
                case 30:
                    const_clinic_1_2_nbr_30 = value;
                    break;
                case 31:
                    const_clinic_1_2_nbr_31 = value;
                    break;
                case 32:
                    const_clinic_1_2_nbr_32 = value;
                    break;
                case 33:
                    const_clinic_1_2_nbr_33 = value;
                    break;
                case 34:
                    const_clinic_1_2_nbr_34 = value;
                    break;
                case 35:
                    const_clinic_1_2_nbr_35 = value;
                    break;
                case 36:
                    const_clinic_1_2_nbr_36 = value;
                    break;
                case 37:
                    const_clinic_1_2_nbr_37 = value;
                    break;
                case 38:
                    const_clinic_1_2_nbr_38 = value;
                    break;
                case 39:
                    const_clinic_1_2_nbr_39 = value;
                    break;
                case 40:
                    const_clinic_1_2_nbr_40 = value;
                    break;
                case 41:
                    const_clinic_1_2_nbr_41 = value;
                    break;
                case 42:
                    const_clinic_1_2_nbr_42 = value;
                    break;
                case 43:
                    const_clinic_1_2_nbr_43 = value;
                    break;
                case 44:
                    const_clinic_1_2_nbr_44 = value;
                    break;
                case 45:
                    const_clinic_1_2_nbr_45 = value;
                    break;
                case 46:
                    const_clinic_1_2_nbr_46 = value;
                    break;
                case 47:
                    const_clinic_1_2_nbr_47 = value;
                    break;
                case 48:
                    const_clinic_1_2_nbr_48 = value;
                    break;
                case 49:
                    const_clinic_1_2_nbr_49 = value;
                    break;
                case 50:
                    const_clinic_1_2_nbr_50 = value;
                    break;
                case 51:
                    const_clinic_1_2_nbr_51 = value;
                    break;
                case 52:
                    const_clinic_1_2_nbr_52 = value;
                    break;
                case 53:
                    const_clinic_1_2_nbr_53 = value;
                    break;
                case 54:
                    const_clinic_1_2_nbr_54 = value;
                    break;
                case 55:
                    const_clinic_1_2_nbr_55 = value;
                    break;
                case 56:
                    const_clinic_1_2_nbr_56 = value;
                    break;
                case 57:
                    const_clinic_1_2_nbr_57 = value;
                    break;
                case 58:
                    const_clinic_1_2_nbr_58 = value;
                    break;
                case 59:
                    const_clinic_1_2_nbr_59 = value;
                    break;
                case 60:
                    const_clinic_1_2_nbr_60 = value;
                    break;
                case 61:
                    const_clinic_1_2_nbr_61 = value;
                    break;
                case 62:
                    const_clinic_1_2_nbr_62 = value;
                    break;
                case 63:
                    const_clinic_1_2_nbr_63 = value;
                    break;
            }
        }

        private async Task Const_Clinic_Nbr_Screen_Variable_SetValue(int index, string value)
        {
            switch (index)
            {
                case 1:
                    const_clinic_nbr_1 = value;
                    break;
                case 2:
                    const_clinic_nbr_2 = value;
                    break;
                case 3:
                    const_clinic_nbr_3 = value;
                    break;
                case 4:
                    const_clinic_nbr_4 = value;
                    break;
                case 5:
                    const_clinic_nbr_5 = value;
                    break;
                case 6:
                    const_clinic_nbr_6 = value;
                    break;
                case 7:
                    const_clinic_nbr_7 = value;
                    break;
                case 8:
                    const_clinic_nbr_8 = value;
                    break;
                case 9:
                    const_clinic_nbr_9 = value;
                    break;
                case 10:
                    const_clinic_nbr_10 = value;
                    break;
                case 11:
                    const_clinic_nbr_11 = value;
                    break;
                case 12:
                    const_clinic_nbr_12 = value;
                    break;
                case 13:
                    const_clinic_nbr_13 = value;
                    break;
                case 14:
                    const_clinic_nbr_14 = value;
                    break;
                case 15:
                    const_clinic_nbr_15 = value;
                    break;
                case 16:
                    const_clinic_nbr_16 = value;
                    break;
                case 17:
                    const_clinic_nbr_17 = value;
                    break;
                case 18:
                    const_clinic_nbr_18 = value;
                    break;
                case 19:
                    const_clinic_nbr_19 = value;
                    break;
                case 20:
                    const_clinic_nbr_20 = value;
                    break;
                case 21:
                    const_clinic_nbr_21 = value;
                    break;
                case 22:
                    const_clinic_nbr_22 = value;
                    break;
                case 23:
                    const_clinic_nbr_23 = value;
                    break;
                case 24:
                    const_clinic_nbr_24 = value;
                    break;
                case 25:
                    const_clinic_nbr_25 = value;
                    break;
                case 26:
                    const_clinic_nbr_26 = value;
                    break;
                case 27:
                    const_clinic_nbr_27 = value;
                    break;
                case 28:
                    const_clinic_nbr_28 = value;
                    break;
                case 29:
                    const_clinic_nbr_29 = value;
                    break;
                case 30:
                    const_clinic_nbr_30 = value;
                    break;
                case 31:
                    const_clinic_nbr_31 = value;
                    break;
                case 32:
                    const_clinic_nbr_32 = value;
                    break;
                case 33:
                    const_clinic_nbr_33 = value;
                    break;
                case 34:
                    const_clinic_nbr_34 = value;
                    break;
                case 35:
                    const_clinic_nbr_35 = value;
                    break;
                case 36:
                    const_clinic_nbr_36 = value;
                    break;
                case 37:
                    const_clinic_nbr_37 = value;
                    break;
                case 38:
                    const_clinic_nbr_38 = value;
                    break;
                case 39:
                    const_clinic_nbr_39 = value;
                    break;
                case 40:
                    const_clinic_nbr_40 = value;
                    break;
                case 41:
                    const_clinic_nbr_41 = value;
                    break;
                case 42:
                    const_clinic_nbr_42 = value;
                    break;
                case 43:
                    const_clinic_nbr_43 = value;
                    break;
                case 44:
                    const_clinic_nbr_44 = value;
                    break;
                case 45:
                    const_clinic_nbr_45 = value;
                    break;
                case 46:
                    const_clinic_nbr_46 = value;
                    break;
                case 47:
                    const_clinic_nbr_47 = value;
                    break;
                case 48:
                    const_clinic_nbr_48 = value;
                    break;
                case 49:
                    const_clinic_nbr_49 = value;
                    break;
                case 50:
                    const_clinic_nbr_50 = value;
                    break;
                case 51:
                    const_clinic_nbr_51 = value;
                    break;
                case 52:
                    const_clinic_nbr_52 = value;
                    break;
                case 53:
                    const_clinic_nbr_53 = value;
                    break;
                case 54:
                    const_clinic_nbr_54 = value;
                    break;
                case 55:
                    const_clinic_nbr_55 = value;
                    break;
                case 56:
                    const_clinic_nbr_56 = value;
                    break;
                case 57:
                    const_clinic_nbr_57 = value;
                    break;
                case 58:
                    const_clinic_nbr_58 = value;
                    break;
                case 59:
                    const_clinic_nbr_59 = value;
                    break;
                case 60:
                    const_clinic_nbr_60 = value;
                    break;
                case 61:
                    const_clinic_nbr_61 = value;
                    break;
                case 62:
                    const_clinic_nbr_62 = value;
                    break;
                case 63:
                    const_clinic_nbr_63 = value;
                    break;
            }
        }

        private async Task Rewrite_Iconst_Master(int option)
        {
            switch (option)
            {
                case 1:

                    objConstants_mstr_rec_1.CONST_MAX_NBR_CLINICS = const_max_nbr_clinics;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_21 = const_clinic_1_2_nbr_1;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_22 = const_clinic_1_2_nbr_2;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_23 = const_clinic_1_2_nbr_3;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_24 = const_clinic_1_2_nbr_4;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_25 = const_clinic_1_2_nbr_5;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_26 = const_clinic_1_2_nbr_6;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_27 = const_clinic_1_2_nbr_7;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_28 = const_clinic_1_2_nbr_8;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_29 = const_clinic_1_2_nbr_9;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_210 = const_clinic_1_2_nbr_10;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_211 = const_clinic_1_2_nbr_11;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_212 = const_clinic_1_2_nbr_12;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_213 = const_clinic_1_2_nbr_13;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_214 = const_clinic_1_2_nbr_14;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_215 = const_clinic_1_2_nbr_15;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_216 = const_clinic_1_2_nbr_16;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_217 = const_clinic_1_2_nbr_17;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_218 = const_clinic_1_2_nbr_18;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_219 = const_clinic_1_2_nbr_19;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_220 = const_clinic_1_2_nbr_20;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_221 = const_clinic_1_2_nbr_21;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_222 = const_clinic_1_2_nbr_22;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_223 = const_clinic_1_2_nbr_23;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_224 = const_clinic_1_2_nbr_24;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_225 = const_clinic_1_2_nbr_25;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_226 = const_clinic_1_2_nbr_26;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_227 = const_clinic_1_2_nbr_27;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_228 = const_clinic_1_2_nbr_28;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_229 = const_clinic_1_2_nbr_29;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_230 = const_clinic_1_2_nbr_30;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_231 = const_clinic_1_2_nbr_31;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_232 = const_clinic_1_2_nbr_32;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_233 = const_clinic_1_2_nbr_33;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_234 = const_clinic_1_2_nbr_34;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_235 = const_clinic_1_2_nbr_35;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_236 = const_clinic_1_2_nbr_36;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_237 = const_clinic_1_2_nbr_37;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_238 = const_clinic_1_2_nbr_38;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_239 = const_clinic_1_2_nbr_39;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR_1_240 = const_clinic_1_2_nbr_40;

                    objConstants_mstr_rec_1.CONST_CLINIC_NBR1 = const_clinic_nbr_1;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR2 = const_clinic_nbr_2;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR3 = const_clinic_nbr_3;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR4 = const_clinic_nbr_4;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR5 = const_clinic_nbr_5;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR6 = const_clinic_nbr_6;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR7 = const_clinic_nbr_7;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR8 = const_clinic_nbr_8;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR9 = const_clinic_nbr_9;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR10 = const_clinic_nbr_10;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR11 = const_clinic_nbr_11;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR12 = const_clinic_nbr_12;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR13 = const_clinic_nbr_13;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR14 = const_clinic_nbr_14;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR15 = const_clinic_nbr_15;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR16 = const_clinic_nbr_16;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR17 = const_clinic_nbr_17;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR18 = const_clinic_nbr_18;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR19 = const_clinic_nbr_19;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR20 = const_clinic_nbr_20;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR21 = const_clinic_nbr_21;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR22 = const_clinic_nbr_22;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR23 = const_clinic_nbr_23;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR24 = const_clinic_nbr_24;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR25 = const_clinic_nbr_25;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR26 = const_clinic_nbr_26;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR27 = const_clinic_nbr_27;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR28 = const_clinic_nbr_28;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR29 = const_clinic_nbr_29;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR30 = const_clinic_nbr_30;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR31 = const_clinic_nbr_31;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR32 = const_clinic_nbr_32;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR33 = const_clinic_nbr_33;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR34 = const_clinic_nbr_34;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR35 = const_clinic_nbr_35;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR36 = const_clinic_nbr_36;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR37 = const_clinic_nbr_37;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR38 = const_clinic_nbr_38;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR39 = const_clinic_nbr_39;
                    objConstants_mstr_rec_1.CONST_CLINIC_NBR40 = const_clinic_nbr_40;

                    string tmpValue = Util.Str(const_clinic_1_2_nbr_41).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_41).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_42).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_42).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_43).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_43).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_44).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_44).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_45).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_45).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_46).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_46).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_47).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_47).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_48).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_48).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_49).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_49).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_50).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_50).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_51).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_51).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_52).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_52).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_53).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_53).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_54).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_54).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_55).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_55).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_56).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_56).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_57).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_57).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_58).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_58).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_59).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_59).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_60).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_60).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_61).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_61).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_62).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_62).PadRight(4) +
                                      Util.Str(const_clinic_1_2_nbr_63).PadLeft(2, '0') +
                                      Util.Str(const_clinic_nbr_63).PadRight(4);
                    objConstants_mstr_rec_1.FILLER = tmpValue;
                    objConstants_mstr_rec_1.RecordState = State.Modified;
                    objConstants_mstr_rec_1.Submit();
                    break;
                case 2:

                    objConstants_mstr_rec_2.CONST_YY_CURR = const_yy_curr;
                    objConstants_mstr_rec_2.CONST_MM_CURR = const_mm_curr;
                    objConstants_mstr_rec_2.CONST_DD_CURR = const_dd_curr;
                    objConstants_mstr_rec_2.CONST_BILATERAL_CURR = const_bilateral_curr;
                    objConstants_mstr_rec_2.CONST_IC_CURR = const_ic_curr;
                    objConstants_mstr_rec_2.CONST_SR_CURR = const_sr_curr;
                    objConstants_mstr_rec_2.CONST_WCB_CURR = const_wcb_curr;
                    objConstants_mstr_rec_2.CONST_ASST_H_CURR = const_asst_h_curr;
                    objConstants_mstr_rec_2.CONST_REG_H_CURR = const_reg_h_curr;
                    objConstants_mstr_rec_2.CONST_CERT_H_CURR = const_cert_h_curr;
                    objConstants_mstr_rec_2.CONST_ASST_A_CURR = const_asst_a_curr;
                    objConstants_mstr_rec_2.CONST_REG_A_CURR = const_reg_a_curr;
                    objConstants_mstr_rec_2.CONST_CERT_A_CURR = const_cert_a_curr;
                    objConstants_mstr_rec_2.CONST_YY_PREV = const_yy_prev;
                    objConstants_mstr_rec_2.CONST_MM_PREV = const_mm_prev;
                    objConstants_mstr_rec_2.CONST_DD_PREV = const_dd_prev;
                    objConstants_mstr_rec_2.CONST_BILATERAL_PREV = const_bilateral_prev;
                    objConstants_mstr_rec_2.CONST_IC_PREV = const_ic_prev;
                    objConstants_mstr_rec_2.CONST_SR_PREV = const_sr_prev;
                    objConstants_mstr_rec_2.CONST_WCB_PREV = const_wcb_prev;
                    objConstants_mstr_rec_2.CONST_ASST_H_PREV = const_asst_h_prev;
                    objConstants_mstr_rec_2.CONST_REG_H_PREV = const_reg_h_prev;
                    objConstants_mstr_rec_2.CONST_CERT_H_PREV = const_cert_h_prev;
                    objConstants_mstr_rec_2.CONST_ASST_A_PREV = const_asst_a_prev;
                    objConstants_mstr_rec_2.CONST_REG_A_PREV = const_reg_a_prev;
                    objConstants_mstr_rec_2.CONST_CERT_A_PREV = const_cert_a_prev;
                    objConstants_mstr_rec_2.CONST_MAX_NBR_RATES = const_max_nbr_rates;
                    objConstants_mstr_rec_2.CONST_SECTION1 = const_sect_1;
                    objConstants_mstr_rec_2.CONST_SECTION2 = const_sect_2;
                    objConstants_mstr_rec_2.CONST_SECTION3 = const_sect_3;
                    objConstants_mstr_rec_2.CONST_SECTION4 = const_sect_4;
                    objConstants_mstr_rec_2.CONST_SECTION5 = const_sect_5;
                    objConstants_mstr_rec_2.CONST_SECTION6 = const_sect_6;
                    objConstants_mstr_rec_2.CONST_SECTION7 = const_sect_7;
                    objConstants_mstr_rec_2.CONST_SECTION8 = const_sect_8;
                    objConstants_mstr_rec_2.CONST_SECTION9 = const_sect_9;
                    objConstants_mstr_rec_2.CONST_SECTION10 = const_sect_10;
                    objConstants_mstr_rec_2.CONST_SECTION11 = const_sect_11;
                    objConstants_mstr_rec_2.CONST_SECTION12 = const_sect_12;
                    objConstants_mstr_rec_2.CONST_SECTION13 = const_sect_13;
                    objConstants_mstr_rec_2.CONST_SECTION14 = const_sect_14;
                    objConstants_mstr_rec_2.CONST_SECTION15 = const_sect_15;
                    objConstants_mstr_rec_2.CONST_SECTION16 = const_sect_16;
                    objConstants_mstr_rec_2.CONST_SECTION17 = const_sect_17;
                    objConstants_mstr_rec_2.CONST_SECTION18 = const_sect_18;
                    objConstants_mstr_rec_2.CONST_SECTION19 = const_sect_19;
                    objConstants_mstr_rec_2.CONST_GROUP1 = const_group_1;
                    objConstants_mstr_rec_2.CONST_GROUP2 = const_group_2;
                    objConstants_mstr_rec_2.CONST_GROUP3 = const_group_3;
                    objConstants_mstr_rec_2.CONST_GROUP4 = const_group_4;
                    objConstants_mstr_rec_2.CONST_GROUP5 = const_group_5;
                    objConstants_mstr_rec_2.CONST_GROUP6 = const_group_6;
                    objConstants_mstr_rec_2.CONST_GROUP7 = const_group_7;
                    objConstants_mstr_rec_2.CONST_GROUP8 = const_group_8;
                    objConstants_mstr_rec_2.CONST_GROUP9 = const_group_9;
                    objConstants_mstr_rec_2.CONST_GROUP10 = const_group_10;
                    objConstants_mstr_rec_2.CONST_GROUP11 = const_group_11;
                    objConstants_mstr_rec_2.CONST_GROUP12 = const_group_12;
                    objConstants_mstr_rec_2.CONST_GROUP13 = const_group_13;
                    objConstants_mstr_rec_2.CONST_GROUP14 = const_group_14;
                    objConstants_mstr_rec_2.CONST_GROUP15 = const_group_15;
                    objConstants_mstr_rec_2.CONST_GROUP16 = const_group_16;
                    objConstants_mstr_rec_2.CONST_GROUP17 = const_group_17;
                    objConstants_mstr_rec_2.CONST_GROUP18 = const_group_18;
                    objConstants_mstr_rec_2.CONST_GROUP19 = const_group_19;
                    objConstants_mstr_rec_2.CONST_RATE_CURR1 = const_curr_1;
                    objConstants_mstr_rec_2.CONST_RATE_CURR2 = const_curr_2;
                    objConstants_mstr_rec_2.CONST_RATE_CURR3 = const_curr_3;
                    objConstants_mstr_rec_2.CONST_RATE_CURR4 = const_curr_4;
                    objConstants_mstr_rec_2.CONST_RATE_CURR5 = const_curr_5;
                    objConstants_mstr_rec_2.CONST_RATE_CURR6 = const_curr_6;
                    objConstants_mstr_rec_2.CONST_RATE_CURR7 = const_curr_7;
                    objConstants_mstr_rec_2.CONST_RATE_CURR8 = const_curr_8;
                    objConstants_mstr_rec_2.CONST_RATE_CURR9 = const_curr_9;
                    objConstants_mstr_rec_2.CONST_RATE_CURR10 = const_curr_10;
                    objConstants_mstr_rec_2.CONST_RATE_CURR11 = const_curr_11;
                    objConstants_mstr_rec_2.CONST_RATE_CURR12 = const_curr_12;
                    objConstants_mstr_rec_2.CONST_RATE_CURR13 = const_curr_13;
                    objConstants_mstr_rec_2.CONST_RATE_CURR14 = const_curr_14;
                    objConstants_mstr_rec_2.CONST_RATE_CURR15 = const_curr_15;
                    objConstants_mstr_rec_2.CONST_RATE_CURR16 = const_curr_16;
                    objConstants_mstr_rec_2.CONST_RATE_CURR17 = const_curr_17;
                    objConstants_mstr_rec_2.CONST_RATE_CURR18 = const_curr_18;
                    objConstants_mstr_rec_2.CONST_RATE_CURR19 = const_curr_19;
                    objConstants_mstr_rec_2.CONST_RATE_PREV1 = const_prev_1;
                    objConstants_mstr_rec_2.CONST_RATE_PREV2 = const_prev_2;
                    objConstants_mstr_rec_2.CONST_RATE_PREV3 = const_prev_3;
                    objConstants_mstr_rec_2.CONST_RATE_PREV4 = const_prev_4;
                    objConstants_mstr_rec_2.CONST_RATE_PREV5 = const_prev_5;
                    objConstants_mstr_rec_2.CONST_RATE_PREV6 = const_prev_6;
                    objConstants_mstr_rec_2.CONST_RATE_PREV7 = const_prev_7;
                    objConstants_mstr_rec_2.CONST_RATE_PREV8 = const_prev_8;
                    objConstants_mstr_rec_2.CONST_RATE_PREV9 = const_prev_9;
                    objConstants_mstr_rec_2.CONST_RATE_PREV10 = const_prev_10;
                    objConstants_mstr_rec_2.CONST_RATE_PREV11 = const_prev_11;
                    objConstants_mstr_rec_2.CONST_RATE_PREV12 = const_prev_12;
                    objConstants_mstr_rec_2.CONST_RATE_PREV13 = const_prev_13;
                    objConstants_mstr_rec_2.CONST_RATE_PREV14 = const_prev_14;
                    objConstants_mstr_rec_2.CONST_RATE_PREV15 = const_prev_15;
                    objConstants_mstr_rec_2.CONST_RATE_PREV16 = const_prev_16;
                    objConstants_mstr_rec_2.CONST_RATE_PREV17 = const_prev_17;
                    objConstants_mstr_rec_2.CONST_RATE_PREV18 = const_prev_18;
                    objConstants_mstr_rec_2.CONST_RATE_PREV19 = const_prev_19;

                    objConstants_mstr_rec_2.RecordState = State.Modified;
                    objConstants_mstr_rec_2.Submit();
                    break;
                case 3:

                    objConstants_mstr_rec_3.CONST_MISC_CURR1 = save_curr_1;
                    objConstants_mstr_rec_3.CONST_MISC_CURR2 = save_curr_2;
                    objConstants_mstr_rec_3.CONST_MISC_CURR3 = save_curr_3;
                    objConstants_mstr_rec_3.CONST_MISC_CURR4 = save_curr_4;
                    objConstants_mstr_rec_3.CONST_MISC_CURR5 = save_curr_5;
                    objConstants_mstr_rec_3.CONST_MISC_CURR6 = save_curr_6;
                    objConstants_mstr_rec_3.CONST_MISC_CURR7 = save_curr_7;
                    objConstants_mstr_rec_3.CONST_MISC_CURR8 = save_curr_8;
                    objConstants_mstr_rec_3.CONST_MISC_CURR9 = save_curr_9;

                    objConstants_mstr_rec_3.CONST_MISC_PREV1 = save_prev_1;
                    objConstants_mstr_rec_3.CONST_MISC_PREV2 = save_prev_2;
                    objConstants_mstr_rec_3.CONST_MISC_PREV3 = save_prev_3;
                    objConstants_mstr_rec_3.CONST_MISC_PREV4 = save_prev_4;
                    objConstants_mstr_rec_3.CONST_MISC_PREV5 = save_prev_5;
                    objConstants_mstr_rec_3.CONST_MISC_PREV6 = save_prev_6;
                    objConstants_mstr_rec_3.CONST_MISC_PREV7 = save_prev_7;
                    objConstants_mstr_rec_3.CONST_MISC_PREV8 = save_prev_8;
                    objConstants_mstr_rec_3.CONST_MISC_PREV9 = save_prev_9;

                    objConstants_mstr_rec_3.RecordState = State.Modified;
                    objConstants_mstr_rec_3.Submit();
                    break;
                case 4:

                    objConstants_mstr_rec_4.CONST_NBR_CLASSES = const_nbr_classes;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR1 = const_class_ltr_1;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR2 = const_class_ltr_2;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR3 = const_class_ltr_3;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR4 = const_class_ltr_4;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR5 = const_class_ltr_5;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR6 = const_class_ltr_6;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR7 = const_class_ltr_7;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR8 = const_class_ltr_8;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR9 = const_class_ltr_9;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR10 = const_class_ltr_10;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR11 = const_class_ltr_11;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR12 = const_class_ltr_12;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR13 = const_class_ltr_13;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR14 = const_class_ltr_14;
                    objConstants_mstr_rec_4.CONST_CLASS_LTR15 = const_class_ltr_15;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC1 = const_class_desc_1;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC2 = const_class_desc_2;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC3 = const_class_desc_3;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC4 = const_class_desc_4;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC5 = const_class_desc_5;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC6 = const_class_desc_6;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC7 = const_class_desc_7;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC8 = const_class_desc_8;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC9 = const_class_desc_9;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC10 = const_class_desc_10;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC11 = const_class_desc_11;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC12 = const_class_desc_12;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC13 = const_class_desc_13;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC14 = const_class_desc_14;
                    objConstants_mstr_rec_4.CONST_CLASS_DESC15 = const_class_desc_15;

                    objConstants_mstr_rec_4.RecordState = State.Modified;
                    objConstants_mstr_rec_4.Submit();
                    break;
                case 5:

                    objConstants_mstr_rec_5.CONST_CON_NBR1 = const_con_nbr[1];
                    objConstants_mstr_rec_5.CONST_CON_NBR2 = const_con_nbr[2];
                    objConstants_mstr_rec_5.CONST_CON_NBR3 = const_con_nbr[3];
                    objConstants_mstr_rec_5.CONST_CON_NBR4 = const_con_nbr[4];
                    objConstants_mstr_rec_5.CONST_CON_NBR5 = const_con_nbr[5];
                    objConstants_mstr_rec_5.CONST_CON_NBR6 = const_con_nbr[6];
                    objConstants_mstr_rec_5.CONST_CON_NBR7 = const_con_nbr[7];
                    objConstants_mstr_rec_5.CONST_CON_NBR8 = const_con_nbr[8];
                    objConstants_mstr_rec_5.CONST_CON_NBR9 = const_con_nbr[9];
                    objConstants_mstr_rec_5.CONST_CON_NBR10 = const_con_nbr[10];
                    objConstants_mstr_rec_5.CONST_CON_NBR11 = const_con_nbr[11];
                    objConstants_mstr_rec_5.CONST_CON_NBR12 = const_con_nbr[12];
                    objConstants_mstr_rec_5.CONST_CON_NBR13 = const_con_nbr[13];
                    objConstants_mstr_rec_5.CONST_CON_NBR14 = const_con_nbr[14];
                    objConstants_mstr_rec_5.CONST_CON_NBR15 = const_con_nbr[15];
                    objConstants_mstr_rec_5.CONST_CON_NBR16 = const_con_nbr[16];
                    objConstants_mstr_rec_5.CONST_CON_NBR17 = const_con_nbr[17];
                    objConstants_mstr_rec_5.CONST_CON_NBR18 = const_con_nbr[18];
                    objConstants_mstr_rec_5.CONST_CON_NBR19 = const_con_nbr[19];
                    objConstants_mstr_rec_5.CONST_CON_NBR20 = const_con_nbr[20];
                    objConstants_mstr_rec_5.CONST_CON_NBR21 = const_con_nbr[21];
                    objConstants_mstr_rec_5.CONST_CON_NBR22 = const_con_nbr[22];
                    objConstants_mstr_rec_5.CONST_CON_NBR23 = const_con_nbr[23];
                    objConstants_mstr_rec_5.CONST_CON_NBR24 = const_con_nbr[24];
                    objConstants_mstr_rec_5.CONST_CON_NBR25 = const_con_nbr[25];

                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT1 = const_nx_avail_pat[1];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT2 = const_nx_avail_pat[2];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT3 = const_nx_avail_pat[3];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT4 = const_nx_avail_pat[4];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT5 = const_nx_avail_pat[5];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT6 = const_nx_avail_pat[6];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT7 = const_nx_avail_pat[7];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT8 = const_nx_avail_pat[8];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT9 = const_nx_avail_pat[9];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT10 = const_nx_avail_pat[10];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT11 = const_nx_avail_pat[11];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT12 = const_nx_avail_pat[12];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT13 = const_nx_avail_pat[13];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT14 = const_nx_avail_pat[14];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT15 = const_nx_avail_pat[15];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT16 = const_nx_avail_pat[16];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT17 = const_nx_avail_pat[17];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT18 = const_nx_avail_pat[18];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT19 = const_nx_avail_pat[19];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT20 = const_nx_avail_pat[20];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT21 = const_nx_avail_pat[21];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT22 = const_nx_avail_pat[22];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT23 = const_nx_avail_pat[23];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT24 = const_nx_avail_pat[24];
                    objConstants_mstr_rec_5.CONST_NX_AVAIL_PAT25 = const_nx_avail_pat[25];

                    objConstants_mstr_rec_5.RecordState = State.Modified;
                    objConstants_mstr_rec_5.Submit();

                    break;
                case 6:
                    // todo...
                    break;
                case 7:
                    // todo..
                    break;
                default:

                    objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = iconst_clinic_nbr_1_2;
                    objIconst_mstr_rec.ICONST_CLINIC_NBR = iconst_clinic_nbr;
                    objIconst_mstr_rec.ICONST_CLINIC_NAME = iconst_clinic_name;
                    objIconst_mstr_rec.ICONST_CLINIC_CYCLE_NBR = iconst_clinic_cycle_nbr;
                    objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY = iconst_date_period_end_yy;
                    objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM = iconst_date_period_end_mm;
                    objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD = iconst_date_period_end_dd;
                    objIconst_mstr_rec.ICONST_CLINIC_CARD_COLOUR = iconst_clinic_card_colour;
                    objIconst_mstr_rec.ICONST_CLINIC_ADDR_L1 = iconst_clinic_addr_l1;
                    objIconst_mstr_rec.ICONST_CLINIC_ADDR_L2 = iconst_clinic_addr_l2;
                    objIconst_mstr_rec.ICONST_CLINIC_ADDR_L3 = iconst_clinic_addr_l3;
                    objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM1 = iconst_clinic_over_lim1;
                    objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM2 = iconst_clinic_under_lim2;
                    objIconst_mstr_rec.ICONST_CLINIC_UNDER_LIM3 = iconst_clinic_under_lim3;
                    objIconst_mstr_rec.ICONST_CLINIC_OVER_LIM4 = iconst_clinic_over_lim4;
                    objIconst_mstr_rec.ICONST_CLINIC_PAY_BATCH_NBR = iconst_clinic_pay_batch_nbr;
                    objIconst_mstr_rec.ICONST_CLINIC_BATCH_NBR = iconst_clinic_batch_nbr;
                    objIconst_mstr_rec.ICONST_REDUCTION_FACTOR = iconst_reduction_factor;
                    objIconst_mstr_rec.ICONST_OVERPAY_FACTOR = iconst_overpay_factor;

                    objIconst_mstr_rec.RecordState = State.Modified;
                    objIconst_mstr_rec.Submit();

                    break;
            }
        }

        #endregion

        public async Task destroy_objects()
        {
            objAudit_record = null;            
            ObservableCollection<Audit_record> Audit_record_Collection = null;
            objAudit_File = null;            
            objIconst_mstr_rec = null;
            Iconst_mstr_rec_Collection = null;
            objConstants_mstr_rec_1 = null;
            Constants_mstr_rec_1_Collection = null;
            objConstants_mstr_rec_2 = null;
            Constants_mstr_rec_2_Collection = null;
            objConstants_mstr_rec_3 = null;
            Constants_mstr_rec_3_Collection = null;
            objConstants_mstr_rec_4 = null;
            Constants_mstr_rec_4_Collection = null;
            objConstants_mstr_rec_5 = null;
            Constants_mstr_rec_5_Collection = null;
            objConstants_mstr_rec_6 = null;
            Constants_mstr_rec_6_Collection = null;
            objConstants_mstr_rec_7 = null;
            Constants_mstr_rec_7_Collection = null;
        }

    }
}

