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
    public class M090ViewModel: CommonFunctionScr
    {

        #region FD Section
        // FD: audit_file
        private Audit_record objAudit_record = null;
        private ObservableCollection<Audit_record> Audit_record_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private Iconst_Mstr_Rec objIconst_mstr_rec = null;
        private ObservableCollection<Iconst_Mstr_Rec> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_1.ws
        private Constants_mstr_rec_1 objConstants_mstr_rec_1 = null;
        private ObservableCollection<Constants_mstr_rec_1> Constants_mstr_rec_1_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_2.ws
        private Constants_mstr_rec_2 objConstants_mstr_rec_2 = null;
        private ObservableCollection<Constants_mstr_rec_2> Constants_mstr_rec_2_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_3.ws
        private Constants_Mstr_Rec_3 objConstants_mstr_rec_3 = null;
        private ObservableCollection<Constants_Mstr_Rec_3> Constants_mstr_rec_3_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_4.ws
        private Constants_mstr_rec_4 objConstants_mstr_rec_4 = null;
        private ObservableCollection<Constants_mstr_rec_4> Constants_mstr_rec_4_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_5.ws
        private Constants_mstr_rec_5 objConstants_mstr_rec_5 = null;
        private ObservableCollection<Constants_mstr_rec_5> Constants_mstr_rec_5_Collection;


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

        private int __sys_yy;
        public int sys_yy
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

        private int __sys_mm;
        public int sys_mm
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

        private int __sys_dd;
        public int sys_dd
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

        private string _print_file_name;
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

        private int _const_class_ltr_1;
        public int const_class_ltr_1
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

        private int _const_class_ltr_2;
        public int const_class_ltr_2
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

        private int _const_class_ltr_3;
        public int const_class_ltr_3
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

        private int _const_class_ltr_4;
        public int const_class_ltr_4
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

        private int _const_class_ltr_5;
        public int const_class_ltr_5
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

        private int _const_class_ltr_6;
        public int const_class_ltr_6
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

        private int _const_class_ltr_7;
        public int const_class_ltr_7
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

        private int _const_class_ltr_8;
        public int const_class_ltr_8
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

        private int _const_class_ltr_9;
        public int const_class_ltr_9
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

        private int _const_class_ltr_10;
        public int const_class_ltr_10
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

        private int _const_class_ltr_11;
        public int const_class_ltr_11
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

        private int _const_class_ltr_12;
        public int const_class_ltr_12
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

        private int _const_class_ltr_13;
        public int const_class_ltr_13
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

        private int _const_class_ltr_14;
        public int const_class_ltr_14
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

        private int _const_class_ltr_15;
        public int const_class_ltr_15
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

        /*private int _const_con_nbr(i);
        public int const_con_nbr(i)
        {
            get
            {
                return _const_con_nbr(i);
            }
            set
            {
                if (_const_con_nbr(i) != value)
                {
                    _const_con_nbr(i) = value;
                    RaisePropertyChanged("const_con_nbr(i)");
                }
            }
        } */

       /* private int _const_nx_avail_pat(i);
        public int const_nx_avail_pat(i)
        {
            get
            {
                return _const_nx_avail_pat(i);
            }
            set
            {
                if (_const_nx_avail_pat(i) != value)
                {
                    _const_nx_avail_pat(i) = value;
                    RaisePropertyChanged("const_nx_avail_pat(i)");
                }
            }
        } */

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
                    _iconst_clinic_name = _iconst_clinic_name.ToUpper();
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
                    _iconst_clinic_addr_l1 = _iconst_clinic_addr_l1.ToUpper();
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
                    _iconst_clinic_addr_l2 = _iconst_clinic_addr_l2.ToUpper();
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
                    _iconst_clinic_addr_l3 = _iconst_clinic_addr_l3.ToUpper();
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
        private string class_ok;
        private string class_not_ok;
        private string password_flag;
        private string password_ok;
        private string password_not_ok;
        //private string flag;
        private string ok;
        private string not_ok;
        private string flag_lock;
        private string rec_locked;
        private string rec_not_locked;

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

        #endregion

        #region Screen Section
        private ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 1,Data1 = "M090        CONSTANTS MASTER MAINTENANCE -",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "option",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 44,Data1 = "(CHANGE/INQUIRY)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_const_mstr_ident",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-title.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-types.",Line = "12",Col = 42,Data1 = "CHANGE - RECORD NUMBER:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-types.",Line = "12",Col = 42,Data1 = "INQUIRY - RECORD NUMBER:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 1,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(55)",MaxLength = 55,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-03.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-05.",Line = "05",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-add-chg.",Line = "24",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 30,Data1 = "DELETE (Y/N)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "verification-screen-del.",Line = "24",Col = 45,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "flag",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 59,Data1 = "REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 66,Data1 = "PASSWORD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(5)",MaxLength = 5,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_entered_password",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 20,Data1 = "NUMBER OF CONST-MSTR READS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "5",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_const_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 20,Data1 = "NUMBER OF CONST-MSTR CHANGES",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "7",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_const_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 20,Data1 = "NUMBER OF AUDIT RPT WRITES = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "8",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_audit_rpt_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 18,Data1 = "PROGRAM M090 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "21",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_20",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 13,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_20",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_21",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_21",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_22",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_22",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_23",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_24",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_24",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_25",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_25",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_26",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_26",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_27",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_27",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_28",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_28",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_29",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_29",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_30",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_30",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_31",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_31",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_32",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_32",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_33",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_33",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_34",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_34",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_35",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_35",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_36",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_36",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_37",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_37",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_38",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_38",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_39",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_39",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_40",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_40",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_41",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_41",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_42",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_42",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_43",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_43",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_44",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "07",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_44",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_45",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "08",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_45",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_46",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "09",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_46",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_47",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "10",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_47",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_48",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "11",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_48",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_49",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "12",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_49",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_50",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "13",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_50",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_51",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "14",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_51",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_52",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "15",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_52",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_53",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "16",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_53",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_54",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "17",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_54",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_55",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "18",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_55",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_56",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "19",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_56",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_57",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_57",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_58",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "21",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_58",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_59",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "22",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_59",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_60",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "23",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_60",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_61",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "04",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_61",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_62",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "05",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_62",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_clinic_1_2_nbr_63",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask1.",Line = "06",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_clinic_nbr_63",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 10,Data1 = "IN EFFECT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 25,Data1 = "WCB",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 35,Data1 = "BILATERAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 47,Data1 = "IND.CONSIDERATION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "03",Col = 67,Data1 = "SECT.REDUCTION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 1,Data1 = "CURR.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_yy_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 13,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_mm_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 16,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_dd_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.9(5)",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_wcb_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_bilateral_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_ic_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "04",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_sr_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 1,Data1 = "PREV.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "05",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_yy_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_asst_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_reg_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_cert_h_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_asst_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_reg_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "09",Col = 74,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_cert_a_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 1,Data1 = "PREV",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "10",Col = 74,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "12",Col = 18,Data1 = "GROUP REDUCTION RATES (",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2a.",Line = "12",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_max_nbr_rates",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_group_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "14",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "15",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "16",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "17",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "18",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "19",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_sect_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_group_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = true,InputVariableName = "const_curr_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2b.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_yy_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 14,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_mm_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_dd_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.9(5)",MaxLength = 8,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_wcb_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_bilateral_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_ic_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "05",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_sr_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 7,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_h_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_asst_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 61,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_reg_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "10",Col = 74,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_cert_a_prev",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "14",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "15",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "16",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "17",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "18",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 47,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "19",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask2c.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_prev_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 20,Data1 = "MISC.CODE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 35,Data1 = "CURRENT",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "03",Col = 48,Data1 = "PREVIOUS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "04",Col = 33,Data1 = "FISCAL YEAR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "04",Col = 46,Data1 = "FISCAL YEAR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 24,Data1 = "0",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 33,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(11)",MaxLength = 11,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "ws_misc_msg_curr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "06",Col = 51,Data1 = "----",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 24,Data1 = "1",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "07",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 24,Data1 = "2",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "08",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 24,Data1 = "3",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "09",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 24,Data1 = "4",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "10",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 24,Data1 = "5",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "11",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 24,Data1 = "6",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "12",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 24,Data1 = "7",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "13",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 24,Data1 = "8",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "14",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 24,Data1 = "9",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 37,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_curr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 43,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "zz9.99",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "save_prev_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask3.",Line = "15",Col = 56,Data1 = "%",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rec-3-warning.",Line = "18",Col = 10,Data1 = "***WARNING***",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rec-3-warning.",Line = "18",Col = 33,Data1 = "ONCE ACCEPTED, THESE VALUES CANNOT BE CHANGED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 25,Data1 = "CLASS",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 34,Data1 = "DESCRIPTION",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 57,Data1 = "NBR.OF CLASSES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "03",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nbr_classes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "05",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "05",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "06",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "06",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "07",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "07",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "08",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "08",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "09",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "09",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "10",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "10",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "11",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "11",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "12",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "12",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "13",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "13",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "14",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "14",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "15",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "15",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "16",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "16",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "17",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "17",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "18",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "18",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "19",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "a",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_class_ltr_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask4.",Line = "19",Col = 34,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(24)",MaxLength = 24,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "const_class_desc_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 0,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_con_nbr(i)",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-mask5.",Line = "12",Col = 0,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(11)9",MaxLength = 119,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "const_nx_avail_pat(i)",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

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

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_nbr_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 19,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(4)",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(20)",MaxLength = 20,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_cycle_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 58,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(4)",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 62,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 63,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 65,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_date_period_end_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "07",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_card_colour",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "11",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "12",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "13",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_addr_l3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "15",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_over_lim1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "16",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_under_lim2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "17",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_under_lim3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "18",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_over_lim4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "19",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(6)",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "iconst_clinic_pay_batch_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "20",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "9(6)",MaxLength = 6,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_clinic_batch_nbr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "21",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_reduction_factor",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-const-isam-mask.",Line = "22",Col = 57,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9.99",MaxLength = 5,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "iconst_overpay_factor",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "23",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_iconst_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_iconst_mstr()
        {
            //     if status-cobol-iconst-mstr-1 = "9";
            //     then;
            err_ind = 9;
            // 	perform za0-common-error	thru za0-99-exit;
            flag_lock = "Y";
            //   else;
            //status_file = status_cobol_iconst_mstr;
            // 	display file-status-display;
            // 	stop "ERROR IN ACCESSING ISAM CONSTANTS MASTER";
            // 	stop run.;
        }

        private void err_audit_rpt_file_section()
        {
            //     use after standard error procedure on audit-file.;
        }

        private void err_audit_rpt()
        {
            status_file = status_audit_rpt;
            //     display file-status-display.;
            //     stop "ERROR IN WRITING TO AUDIT REPORT FILE".;
            //     stop run.;
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {
        }

        private void mainline()
        {
            //     perform aa0-initialization		thru aa0-99-exit.;
            //     perform ab0-processing		thru ab0-99-exit.;
            //     perform az0-end-of-job		thru az0-99-exit.;
            //     chain "$obj/menu".;
        }

        private void aa0_initialization()
        {

            //     accept sys-date			from date.;
            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;
            //     accept sys-time			from time.;
            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open i-o iconst-mstr.;
            //     open output audit-file.;
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void ab0_processing()
        {

            option = "";
            ws_const_mstr_ident = "";
            //               					   ws-const-mstr-ident.;
            //     display scr-title.;
            //     accept scr-acpt-option.;
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
            err_ind = 1;
            // 	    	perform za0-common-error;
            // 					thru za0-99-exit;
            // 		go to ab0-processing.;
        }

        private void ab0_10_acpt_rec_nbr()
        {

            ws_const_mstr_ident = "";
            //     display scr-rec-nbr.;
            //     accept scr-rec-nbr.;
            //     if ws-const-mstr-ident-1 = "*";
            //     then;
            // 	go to ab0-processing;
            //     else;
            // 	if    ws-const-mstr-ident-1 = spaces;
            // 	  and ws-const-mstr-ident-2   numeric;
            // 	then;
            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident_2;
            // 	else;
            // 	    if   ws-const-mstr-ident-1   numeric;
            // 	     and ws-const-mstr-ident-2 = spaces;
            // 	    then;
            // 		if ws-const-mstr-ident-1 <> 6;
            // 		then;
            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident_1;
            // 		else;
            err_ind = 1;
            // 		    perform za0-common-error	thru	za0-99-exit;
            // 	    else;
            // 	    	if    ws-const-mstr-ident numeric;
            // 		  and ws-const-mstr-ident <> "06";
            // 		then;
            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_const_mstr_ident;
            // 		else;
            err_ind = 1;
            // 		    perform za0-common-error	thru	za0-99-exit;
            // 		    go to ab0-10-acpt-rec-nbr.;
            //     display blank-rest-of-page.;
            flag = "Y";
            //     perform ma1-read-iconst-mstr		thru	ma1-99-exit.;
            //     if not-ok;
            //     then;
            err_ind = 5;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to ab0-10-acpt-rec-nbr.;
        }

        private void ab0_100_continue()
        {

            //     if iconst-clinic-nbr-1-2 = 1;
            //     then;
            // 	perform ba0-const-mstr-1-routine	thru	ba0-99-exit;
            //     else;
            // 	if iconst-clinic-nbr-1-2 = 2;
            // 	then;
            // 	    perform ca0-const-mstr-2-curr   	thru	ca0-99-exit;
            // 	else;
            // 	    if iconst-clinic-nbr-1-2 = 3;
            // 	    then;
            // 	 	perform ga0-const-mstr-3-routine thru	ga0-99-exit;
            // 	    else;
            // 		if iconst-clinic-nbr-1-2 = 4;
            // 	 	then;
            // 	 	    perform ha0-const-mstr-4-routine;
            // 						thru	ha0-99-exit;
            // 		else;
            // 		    if iconst-clinic-nbr-1-2 = 5;
            // 		    then;
            // 			perform ia0-const-mstr-5-routine;
            // 						thru 	ia0-99-exit;
            // 		    else;
            // 	            	perform fa0-isam-const-mstr-routine;
            // 						thru	fa0-99-exit.;
        }

        private void ab0_200_verify()
        {

            //     if option = "I";
            //     then;
            // 	go to ab0-10-acpt-rec-nbr.;
            //     display verification-screen-add-chg.;
            //     accept verification-screen-add-chg.;
            //     if flag = "Y";
            //     then;
            // 	if const-rec-1-rec-nbr = 3;
            // 	then;
            // 	    perform ga2-convert-for-conmstr	thru	ga2-99-exit;
            // 		varying	temp;
            // 			from 1 by 1;
            // 		until	temp > 9;
            // 	    perform pa1-re-write-iconst-mstr	thru	pa1-99-exit;
            // 	    perform ra0-write-audit-rpt	thru	ra0-99-exit;
            // 	    go to ab0-10-acpt-rec-nbr;
            //    	else;
            // 	    perform pa1-re-write-iconst-mstr	thru	pa1-99-exit;
            // 	    perform ra0-write-audit-rpt		thru	ra0-99-exit;
            // 	    go to ab0-10-acpt-rec-nbr.;
            //     if flag = "N";
            //     then;
            // 	display scr-reject-entry;
            // 	display confirm;
            // 	stop " ";
            // 	display blank-line-24;
            // 	go to ab0-10-acpt-rec-nbr.;
            //     if flag = "M";
            //     then;
            // 	go to ab0-100-continue;
            //     else;
            // 	if    flag = "P";
            // 	  and iconst-clinic-nbr-1-2 = 2;
            // 	then;
            flag = "";
            // 	    perform da0-password		thru	da0-99-exit;
            // 	    if password-ok;
            // 	    then;
            // 		perform da1-const-mstr-2-prev	thru	da1-99-exit;
            // 	    	go to ab0-200-verify;
            // 	    else;
            err_ind = 6;
            // 	  	perform za0-common-error	thru	za0-99-exit;
            // 	 	go to ab0-200-verify;
            // 	else;
            err_ind = 1;
            // 	    perform za0-common-error		thru	za0-99-exit;
            // 	    go to ab0-200-verify.;
        }

        private void ab0_99_exit()
        {

            //     exit.;
        }

        private void ba0_const_mstr_1_routine()
        {

            //     if flag not = "M";
            //     then;
            // 	display scr-mask1.;
            //     if option = "I";
            //     then;
            // 	go to ba0-99-exit.;
            //     accept scr-clinic-1-2-nbr-1.;
            //     if const-clinic-1-2-nbr-1 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 0;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-1.;
            //     accept scr-clinic-1-2-nbr-2.;
            //     if const-clinic-1-2-nbr-2 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 1;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-2.;
            //     accept scr-clinic-1-2-nbr-3.;
            //     if const-clinic-1-2-nbr-3 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 2;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-3.;
            //     accept scr-clinic-1-2-nbr-4.;
            //     if const-clinic-1-2-nbr-4 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 3;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-4.;
            //     accept scr-clinic-1-2-nbr-5.;
            //     if const-clinic-1-2-nbr-5 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 4;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-5.;
            //     accept scr-clinic-1-2-nbr-6.;
            //     if const-clinic-1-2-nbr-6 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 5;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-6.;
            //     accept scr-clinic-1-2-nbr-7.;
            //     if const-clinic-1-2-nbr-7 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 6;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-7.;
            //     accept scr-clinic-1-2-nbr-8.;
            //     if const-clinic-1-2-nbr-8 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 7;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-8.;
            //     accept scr-clinic-1-2-nbr-9.;
            //     if const-clinic-1-2-nbr-9 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 8;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-9.;
            //     accept scr-clinic-1-2-nbr-10.;
            //     if const-clinic-1-2-nbr-10 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 9;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-10.;
            //     accept scr-clinic-1-2-nbr-11.;
            //     if const-clinic-1-2-nbr-11 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 10;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-11.;
            //     accept scr-clinic-1-2-nbr-12.;
            //     if const-clinic-1-2-nbr-12 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 11;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-12.;
            //     accept scr-clinic-1-2-nbr-13.;
            //     if const-clinic-1-2-nbr-13 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 12;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-13.;
            //     accept scr-clinic-1-2-nbr-14.;
            //     if const-clinic-1-2-nbr-14 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 13;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-14.;
            //     accept scr-clinic-1-2-nbr-15.;
            //     if const-clinic-1-2-nbr-15 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 14;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-15.;
            //     accept scr-clinic-1-2-nbr-16.;
            //     if const-clinic-1-2-nbr-16 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 15;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-16.;
            //     accept scr-clinic-1-2-nbr-17.;
            //     if const-clinic-1-2-nbr-17 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 16;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-17.;
            //     accept scr-clinic-1-2-nbr-18.;
            //     if const-clinic-1-2-nbr-18 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 17;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-18.;
            //     accept scr-clinic-1-2-nbr-19.;
            //     if const-clinic-1-2-nbr-19 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 18;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-19.;
            //     accept scr-clinic-1-2-nbr-20.;
            //     if const-clinic-1-2-nbr-20 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 19;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-20.;
            //     accept scr-clinic-1-2-nbr-21.;
            //     if const-clinic-1-2-nbr-21 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 20;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-21.;
            //     accept scr-clinic-1-2-nbr-22.;
            //     if const-clinic-1-2-nbr-22 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 21;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-22.;
            //     accept scr-clinic-1-2-nbr-23.;
            //     if const-clinic-1-2-nbr-23 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 22;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-23.;
            //     accept scr-clinic-1-2-nbr-24.;
            //     if const-clinic-1-2-nbr-24 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 23;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-24.;
            //     accept scr-clinic-1-2-nbr-25.;
            //     if const-clinic-1-2-nbr-25 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 24;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-25.;
            //     accept scr-clinic-1-2-nbr-26.;
            //     if const-clinic-1-2-nbr-26 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 25;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-26.;
            //     accept scr-clinic-1-2-nbr-27.;
            //     if const-clinic-1-2-nbr-27 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 26;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-27.;
            //     accept scr-clinic-1-2-nbr-28.;
            //     if const-clinic-1-2-nbr-28 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 27;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-28.;
            //     accept scr-clinic-1-2-nbr-29.;
            //     if const-clinic-1-2-nbr-29 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 28;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-29.;
            //     accept scr-clinic-1-2-nbr-30.;
            //     if const-clinic-1-2-nbr-30 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 29;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-30.;
            //     accept scr-clinic-1-2-nbr-31.;
            //     if const-clinic-1-2-nbr-31 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 30;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-31.;
            //     accept scr-clinic-1-2-nbr-32.;
            //     if const-clinic-1-2-nbr-32 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 31;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-32.;
            //     accept scr-clinic-1-2-nbr-33.;
            //     if const-clinic-1-2-nbr-33 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 32;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-33.;
            //     accept scr-clinic-1-2-nbr-34.;
            //     if const-clinic-1-2-nbr-34 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 33;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-34.;
            //     accept scr-clinic-1-2-nbr-35.;
            //     if const-clinic-1-2-nbr-35 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 34;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-35.;
            //     accept scr-clinic-1-2-nbr-36.;
            //     if const-clinic-1-2-nbr-36 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 35;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-36.;
            //     accept scr-clinic-1-2-nbr-37.;
            //     if const-clinic-1-2-nbr-37 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 36;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-37.;
            //     accept scr-clinic-1-2-nbr-38.;
            //     if const-clinic-1-2-nbr-38 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 37;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-38.;
            //     accept scr-clinic-1-2-nbr-39.;
            //     if const-clinic-1-2-nbr-39 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 38;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-39.;
            //     accept scr-clinic-1-2-nbr-40.;
            //     if const-clinic-1-2-nbr-40 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 39;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-40.;
            //     accept scr-clinic-1-2-nbr-41.;
            //     if const-clinic-1-2-nbr-41 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 40;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-41.;
            //     accept scr-clinic-1-2-nbr-42.;
            //     if const-clinic-1-2-nbr-42 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 41;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-42.;
            //     accept scr-clinic-1-2-nbr-43.;
            //     if const-clinic-1-2-nbr-43 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 42;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-43.;
            //     accept scr-clinic-1-2-nbr-44.;
            //     if const-clinic-1-2-nbr-44 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 43;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-44.;
            //     accept scr-clinic-1-2-nbr-45.;
            //     if const-clinic-1-2-nbr-45 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 44;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-45.;
            //     accept scr-clinic-1-2-nbr-46.;
            //     if const-clinic-1-2-nbr-46 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 45;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-46.;
            //     accept scr-clinic-1-2-nbr-47.;
            //     if const-clinic-1-2-nbr-47 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 46;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-47.;
            //     accept scr-clinic-1-2-nbr-48.;
            //     if const-clinic-1-2-nbr-48 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 47;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-48.;
            //     accept scr-clinic-1-2-nbr-49.;
            //     if const-clinic-1-2-nbr-49 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 48;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-49.;
            //     accept scr-clinic-1-2-nbr-50.;
            //     if const-clinic-1-2-nbr-50 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 49;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-50.;
            //     accept scr-clinic-1-2-nbr-51.;
            //     if const-clinic-1-2-nbr-51 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 50;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-51.;
            //     accept scr-clinic-1-2-nbr-52.;
            //     if const-clinic-1-2-nbr-52 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 51;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-52.;
            //     accept scr-clinic-1-2-nbr-53.;
            //     if const-clinic-1-2-nbr-53 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 52;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-53.;
            //     accept scr-clinic-1-2-nbr-54.;
            //     if const-clinic-1-2-nbr-54 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 53;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-54.;
            //     accept scr-clinic-1-2-nbr-55.;
            //     if const-clinic-1-2-nbr-55 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 54;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-55.;
            //     accept scr-clinic-1-2-nbr-56.;
            //     if const-clinic-1-2-nbr-56 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 55;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-56.;
            //     accept scr-clinic-1-2-nbr-57.;
            //     if const-clinic-1-2-nbr-57 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 56;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-57.;
            //     accept scr-clinic-1-2-nbr-58.;
            //     if const-clinic-1-2-nbr-58 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 57;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-58.;
            //     accept scr-clinic-1-2-nbr-59.;
            //     if const-clinic-1-2-nbr-59 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 58;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-59.;
            //     accept scr-clinic-1-2-nbr-60.;
            //     if const-clinic-1-2-nbr-60 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 59;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-60.;
            //     accept scr-clinic-1-2-nbr-61.;
            //     if const-clinic-1-2-nbr-61 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 60;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-61.;
            //     accept scr-clinic-1-2-nbr-62.;
            //     if const-clinic-1-2-nbr-62 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 61;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-62.;
            //     accept scr-clinic-1-2-nbr-63.;
            //     if const-clinic-1-2-nbr-63 = zero;
            //     then;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 62;
            // 	go to ba0-10-clear-clinics.;
            //     accept scr-clinic-nbr-63.;
            //objConstants_mstr_rec_1.const_max_nbr_clinics = 63;
        }

        private void ba0_10_clear_clinics()
        {

            //     add 1    const-max-nbr-clinics 	giving ws-save-max-clinics.;
            //     perform ba1-zero-areas		thru ba1-99-exit;
            // 	varying i from ws-save-max-clinics by 1;
            // 	until   i > 63.;
            //     display scr-mask1.;
        }

        private void ba0_99_exit()
        {

            //     exit.;
        }

        private void ba1_zero_areas()
        {

            //const_clinic_nbr_1_2[i] = 0;
            //const_clinic_nbr[i] = "";
        }

        private void ba1_99_exit()
        {

            //     exit.;
        }

        private void ca0_const_mstr_2_curr()
        {

            //     if flag not = "M";
            //     then;
            // 	display scr-mask2a;
            // 	display scr-mask2b.;
            //     if option = "I";
            //     then;
            // 	go to ca0-99-exit.;
            //     perform ca2-acpt-effective-date-curr	thru	ca2-99-exit.;
            //     accept  scr-wcb-curr.;
            //     display scr-wcb-curr.;
            //     accept  scr-bi-curr.;
            //     display scr-bi-curr.;
            //     accept  scr-ic-curr.;
            //     display scr-ic-curr.;
            //     accept  scr-sr-curr.;
            //     display scr-sr-curr.;
            //     accept  scr-asst-h-curr.;
            //     display scr-asst-h-curr.;
            //     accept  scr-reg-h-curr.;
            //     display scr-reg-h-curr.;
            //     accept  scr-cert-h-curr.;
            //     display scr-cert-h-curr.;
            //     accept  scr-asst-a-curr.;
            //     display scr-asst-a-curr.;
            //     accept  scr-reg-a-curr.;
            //     display scr-reg-a-curr.;
            //     accept  scr-cert-a-curr.;
            //     display scr-cert-a-curr.;
            //     perform ca1-acpt-group-rates-curr		thru	ca1-99-exit.;
        }

        private void ca0_99_exit()
        {

            //     exit.;
        }

        private void ca1_acpt_group_rates_curr()
        {

            //     accept  scr-sect-1.;
            //     display scr-sect-1.;
            //     if const-sect-1 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 0;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-1.;
            //     display scr-group-1.;
            //     accept  scr-curr-1.;
            //     display scr-curr-1.;
            //     accept  scr-sect-2.;
            //     display scr-sect-2.;
            //     if const-sect-2 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 1;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-2.;
            //     display scr-group-2.;
            //     accept  scr-curr-2.;
            //     display scr-curr-2.;
            //     accept  scr-sect-3.;
            //     display scr-sect-3.;
            //     if const-sect-3 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 2;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-3.;
            //     display scr-group-3.;
            //     accept  scr-curr-3.;
            //     display scr-curr-3.;
            //     accept  scr-sect-4.;
            //     display scr-sect-4.;
            //     if const-sect-4 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 3;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-4.;
            //     display scr-group-4.;
            //     accept  scr-curr-4.;
            //     display scr-curr-4.;
            //     accept  scr-sect-5.;
            //     display scr-sect-5.;
            //     if const-sect-5 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 4;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-5.;
            //     display scr-group-5.;
            //     accept  scr-curr-5.;
            //     display scr-curr-5.;
            //     accept  scr-sect-6.;
            //     display scr-sect-6.;
            //     if const-sect-6 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 5;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-6.;
            //     display scr-group-6.;
            //     accept  scr-curr-6.;
            //     display scr-curr-6.;
            //     accept  scr-sect-7.;
            //     display scr-sect-7.;
            //     if const-sect-7 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 6;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-7.;
            //     display scr-group-7.;
            //     accept  scr-curr-7.;
            //     display scr-curr-7.;
            //     accept  scr-sect-8.;
            //     display scr-sect-8.;
            //     if const-sect-8 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 7;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-8.;
            //     display scr-group-8.;
            //     accept  scr-curr-8.;
            //     display scr-curr-8.;
            //     accept  scr-sect-9.;
            //     display scr-sect-9.;
            //     if const-sect-9 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 8;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-9.;
            //     display scr-group-9.;
            //     accept  scr-curr-9.;
            //     display scr-curr-9.;
            //     accept  scr-sect-10.;
            //     display scr-sect-10.;
            //     if const-sect-10 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 9;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-10.;
            //     display scr-group-10.;
            //     accept  scr-curr-10.;
            //     display scr-curr-10.;
            //     accept  scr-sect-11.;
            //     display scr-sect-11.;
            //     if const-sect-11 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 10;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-11.;
            //     display scr-group-11.;
            //     accept  scr-curr-11.;
            //     display scr-curr-11.;
            //     accept  scr-sect-12.;
            //     display scr-sect-12.;
            //     if const-sect-12 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 11;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-12.;
            //     display scr-group-12.;
            //     accept  scr-curr-12.;
            //     display scr-curr-12.;
            //     accept  scr-sect-13.;
            //     display scr-sect-13.;
            //     if const-sect-13 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 12;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-13.;
            //     display scr-group-13.;
            //     accept  scr-curr-13.;
            //     display scr-curr-13.;
            //     accept  scr-sect-14.;
            //     display scr-sect-14.;
            //     if const-sect-14 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 13;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-14.;
            //     display scr-group-14.;
            //     accept  scr-curr-14.;
            //     display scr-curr-14.;
            //     accept  scr-sect-15.;
            //     display scr-sect-15.;
            //     if const-sect-15 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 14;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-15.;
            //     display scr-group-15.;
            //     accept  scr-curr-15.;
            //     display scr-curr-15.;
            //     accept  scr-sect-16.;
            //     display scr-sect-16.;
            //     if const-sect-16 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 15;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-16.;
            //     display scr-group-16.;
            //     accept  scr-curr-16.;
            //     display scr-curr-16.;
            //     accept  scr-sect-17.;
            //     display scr-sect-17.;
            //     if const-sect-17 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 16;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-17.;
            //     display scr-group-17.;
            //     display scr-group-17.;
            //     display scr-curr-17.;
            //     accept  scr-curr-17.;
            //     display scr-curr-17.;
            //     accept  scr-sect-18.;
            //     display scr-sect-18.;
            //     if const-sect-18 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 17;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-18.;
            //     display scr-group-18.;
            //     accept  scr-curr-18.;
            //     display scr-curr-18.;
            //     accept  scr-sect-19.;
            //     display scr-sect-19.;
            //     if const-sect-19 = spaces;
            //     then;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 18;
            // 	go to ca1-100-nbr-rates.;
            //     accept  scr-group-19.;
            //     display scr-group-19.;
            //     accept  scr-curr-19.;
            //     display scr-curr-19.;
            //objConstants_mstr_rec_2.const_max_nbr_rates = 19;
        }

        private void ca1_100_nbr_rates()
        {

            //     add 1, const-max-nbr-rates	giving	ws-save-max-rates.;
            //     perform ca3-zero-areas	thru	ca3-99-exit;
            // 	varying	i;
            // 	from	ws-save-max-rates;
            // 	by  	1;
            // 	until	i > 19.;
            //     display scr-mask2b.;
            //     display scr-nbr-rates.;
        }

        private void ca1_99_exit()
        {
            //     exit.;
        }

        private void ca2_acpt_effective_date_curr()
        {

            //     accept  scr-yy-curr.;
            //     display scr-yy-curr.;
            //     if const-yy-curr < 32;
            //     then;
            err_ind = 2;
            // 	perform za0-common-error 	thru	za0-99-exit;
            // 	go to ca2-acpt-effective-date-curr.;
        }

        private void ca2_100_mth()
        {

            //     accept  scr-mm-curr.;
            //     display scr-mm-curr.;
            //     if   const-mm-curr < 1;
            //       or const-mm-curr > 12;
            //     then;
            err_ind = 3;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to ca2-100-mth.;
        }

        private void ca2_200_day()
        {

            //     accept  scr-dd-curr.;
            //     display scr-dd-curr.;
            //     if   const-dd-curr < 1;
            //       or const-dd-curr > max-nbr-days (const-mm-curr);
            //     then;
            err_ind = 4;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to ca2-200-day.;
        }

        private void ca2_99_exit()
        {

            //     exit.;
        }

        private void ca3_zero_areas()
        {

            //const_group_rates[i] = 0;
            //const_group_rates[i] = 0;
            // 					const-group-rates (i).;
            //const_section[i] = "";
            //const_section[i] = "";
            // 					const-section (i).;
        }

        private void ca3_99_exit()
        {

            //     exit.;
        }

        private void da0_password()
        {

            password_flag = "N";
            ws_entered_password = "";
            //     display scr-password-prompt.;
            //     accept  scr-password.;
            //     if ws-entered-password = ws-valid-password;
            //     then;
            password_flag = "Y";
        }

        private void da0_99_exit()
        {

            //     exit.;
        }

        private void da1_const_mstr_2_prev()
        {

            //     perform da3-acpt-effective-date-prev	thru	da3-99-exit.;
            //     display scr-wcb-prev.;
            //     accept  scr-wcb-prev.;
            //     display scr-wcb-prev.;
            //     display scr-bi-prev.;
            //     accept  scr-bi-prev.;
            //     display scr-bi-prev.;
            //     display scr-ic-prev.;
            //     accept  scr-ic-prev.;
            //     display scr-ic-prev.;
            //     display scr-sr-prev.;
            //     accept  scr-sr-prev.;
            //     display scr-sr-prev.;
            //     display scr-asst-h-prev.;
            //     accept  scr-asst-h-prev.;
            //     display scr-asst-h-prev.;
            //     display scr-reg-h-prev.;
            //     accept  scr-reg-h-prev.;
            //     display scr-reg-h-prev.;
            //     display scr-cert-h-prev.;
            //     accept  scr-cert-h-prev.;
            //     display scr-cert-h-prev.;
            //     display scr-asst-a-prev.;
            //     accept  scr-asst-a-prev.;
            //     display scr-asst-a-prev.;
            //     display scr-reg-a-prev.;
            //     accept  scr-reg-a-prev.;
            //     display scr-reg-a-prev.;
            //     display scr-cert-a-prev.;
            //     accept  scr-cert-a-prev.;
            //     display scr-cert-a-prev.;
            //     perform da2-acpt-group-rates-prev	thru da2-99-exit.;
        }

        private void da1_99_exit()
        {

            //     exit.;
        }

        private void da2_acpt_group_rates_prev()
        {

            //     if const-sect-1 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-1.;
            //     accept  scr-prev-1.;
            //     display scr-prev-1.;
            //     if const-sect-2 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-2.;
            //     accept  scr-prev-2.;
            //     display scr-prev-2.;
            //     if const-sect-3 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-3.;
            //     accept  scr-prev-3.;
            //     display scr-prev-3.;
            //     if const-sect-4 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-4.;
            //     accept  scr-prev-4.;
            //     display scr-prev-4.;
            //     if const-sect-5 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-5.;
            //     accept  scr-prev-5.;
            //     display scr-prev-5.;
            //     if const-sect-6 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-6.;
            //     accept  scr-prev-6.;
            //     display scr-prev-6.;
            //     if const-sect-7 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-7.;
            //     accept  scr-prev-7.;
            //     display scr-prev-7.;
            //     if const-sect-8 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-8.;
            //     accept  scr-prev-8.;
            //     display scr-prev-8.;
            //     if const-sect-9 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-9.;
            //     accept  scr-prev-9.;
            //     display scr-prev-9.;
            //     if const-sect-10 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-10.;
            //     accept  scr-prev-10.;
            //     display scr-prev-10.;
            //     if const-sect-11 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-11.;
            //     accept  scr-prev-11.;
            //     display scr-prev-11.;
            //     if const-sect-12 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-12.;
            //     accept  scr-prev-12.;
            //     display scr-prev-12.;
            //     if const-sect-13 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-13.;
            //     accept  scr-prev-13.;
            //     display scr-prev-13.;
            //     if const-sect-14 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-14.;
            //     accept  scr-prev-14.;
            //     display scr-prev-14.;
            //     if const-sect-15 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-15.;
            //     accept  scr-prev-15.;
            //     display scr-prev-15.;
            //     if const-sect-16 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-16.;
            //     accept  scr-prev-16.;
            //     display scr-prev-16.;
            //     if const-sect-17 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-17.;
            //     accept  scr-prev-17.;
            //     display scr-prev-17.;
            //     if const-sect-18 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-18.;
            //     accept  scr-prev-18.;
            //     display scr-prev-18.;
            //     if const-sect-19 = spaces;
            //     then;
            // 	go to da2-99-exit.;
            //     display scr-prev-19.;
            //     accept  scr-prev-19.;
            //     display scr-prev-19.;
        }

        private void da2_99_exit()
        {
            //     exit.;
        }

        private void da3_acpt_effective_date_prev()
        {
            //     display scr-yy-prev.;
            //     accept  scr-yy-prev.;
            //     display scr-yy-prev.;
            //     if const-yy-prev < 32;
            //     then;
            err_ind = 2;
            // 	perform za0-common-error 	thru	za0-99-exit;
            // 	go to da3-acpt-effective-date-prev.;
        }

        private void da3_100_mth()
        {
            //     display scr-mm-prev.;
            //     accept  scr-mm-prev.;
            //     display scr-mm-prev.;
            //     if   const-mm-prev < 1;
            //       or const-mm-prev > 12;
            //     then;
            err_ind = 3;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to da3-100-mth.;
        }

        private void da3_200_day()
        {

            //     display scr-dd-prev.;
            //     accept  scr-dd-prev.;
            //     display scr-dd-prev.;
            //     if   const-dd-prev < 1;
            //       or const-dd-prev > max-nbr-days (const-mm-prev);
            //     then;
            err_ind = 4;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to da3-200-day.;
            //     if const-effective-date-prev not < const-effective-date-curr;
            //     then;
            err_ind = 7;
            // 	perform za0-common-error thru	za0-99-exit;
            // 	go to da3-acpt-effective-date-prev.;
        }

        private void da3_99_exit()
        {

            //     exit.;
        }

        private void fa0_isam_const_mstr_routine()
        {

            //     if flag not = "M";
            //     then;
            // 	display scr-const-isam-mask.;
            //     if option = "I";
            //     then;
            // 	go to fa0-99-exit;
            //     else;
            // 	next sentence.;
            //     accept scr-clinic-nbr.;
            //     accept scr-clinic-name.;
            //     accept scr-clinic-cycle.;
        }

        private void fa0_10()
        {

            //     accept scr-date-period-end-yy.;
            //     if iconst-date-period-end-yy < 32;
            //     then;
            err_ind = 2;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to fa0-10.;
        }

        private void fa0_20()
        {

            //     accept scr-date-period-end-mm.;
            //     if   iconst-date-period-end-mm < 1;
            //       or iconst-date-period-end-mm > 12;
            //     then;
            err_ind = 3;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to fa0-20.;
        }

        private void fa0_30()
        {

            //     accept scr-date-period-end-dd.;
            //     if   iconst-date-period-end-dd < 1;
            //       or iconst-date-period-end-dd > max-nbr-days (iconst-date-period-end-mm);
            //     then;
            err_ind = 4;
            // 	perform za0-common-error	thru za0-99-exit;
            // 	go to fa0-30.;
            //     accept scr-clinic-card-colour.;
            //     accept scr-clinic-addr-1.;
            //     accept scr-clinic-addr-2.;
            //     accept scr-clinic-addr-3.;
            //     accept scr-clinic-over-lim1.;
            //     accept scr-clinic-under-lim2.;
            //     accept scr-clinic-under-lim3.;
            //     accept scr-clinic-over-lim4.;
            //     accept scr-clinic-pay-batch-nbr.;
            //     accept scr-clinic-batch-nbr.;
            //     accept scr-reduction-factor.;
            //     accept scr-overpay-factor.;
        }

        private void fa0_99_exit()
        {

            //     exit.;
        }

        private void ga0_const_mstr_3_routine()
        {

            //save_misc_code_values = 0;
            //     perform ga1-convert-for-screen	thru	ga1-99-exit;
            // 	varying	temp;
            // 		from 1 by 1;
            // 	until	temp > 9.;
            //     display scr-mask3.;
            //     if option = "I";
            //     then;
            // 	go to ga0-99-exit;
            //     else;
            // 	display scr-rec-3-warning.;
            //     if save-curr-1 = zero;
            //     then;
            // 	accept  scr-misc-1;
            // 	display scr-misc-1.;
            //     if save-curr-2 = zero;
            //     then;
            // 	accept  scr-misc-2;
            // 	display scr-misc-2.;
            //     if save-curr-3 = zero;
            //     then;
            // 	accept  scr-misc-3;
            // 	display scr-misc-3.;
            //     if save-curr-4 = zero;
            //     then;
            // 	accept  scr-misc-4;
            // 	display scr-misc-4.;
            //     if save-curr-5 = zero;
            //     then;
            // 	accept  scr-misc-5;
            // 	display scr-misc-5.;
            //     if save-curr-6 = zero;
            //     then;
            // 	accept  scr-misc-6;
            // 	display scr-misc-6.;
            //     if save-curr-7 = zero;
            //     then;
            // 	accept  scr-misc-7;
            // 	display scr-misc-7.;
            //     if save-curr-8 = zero;
            //     then;
            // 	accept  scr-misc-8;
            // 	display scr-misc-8.;
            //     if save-curr-9 = zero;
            //     then;
            // 	accept  scr-misc-9;
            // 	display scr-misc-9.;
        }

        private void ga0_99_exit()
        {

            //     exit.;
        }

        private void ga1_convert_for_screen()
        {

            //     multiply const-misc-curr (temp)	by	100;
            // 					giving	save-curr (temp).;
            //     multiply const-misc-prev (temp)	by	100;
            // 					giving	save-prev (temp).;
        }

        private void ga1_99_exit()
        {

            //     exit.;
        }

        private void ga2_convert_for_conmstr()
        {

            //     divide save-curr (temp)      	by	100;
            // 					giving	const-misc-curr (temp).;
        }

        private void ga2_99_exit()
        {

            //     exit.;
        }

        private void ha0_const_mstr_4_routine()
        {

            //     if flag not = "M";
            //     then;
            // 	display scr-mask4.;
            //     if option = "I";
            //     then;
            // 	go to ha0-99-exit.;
            // 	accept scr-ltr-1.;
            // 	if const-class-ltr-1 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 0;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 1;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-const-mstr-4-routine.;
            //     accept scr-desc-1.;
        }

        private void ha0_class_2()
        {

            // 	accept scr-ltr-2 .;
            // 	if const-class-ltr-2 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 1;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 2;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-2.;
            //     accept scr-desc-2.;
        }

        private void ha0_class_3()
        {

            // 	accept scr-ltr-3.;
            // 	if const-class-ltr-3 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 2;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 3;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-3.;
            //     accept scr-desc-3.;
        }

        private void ha0_class_4()
        {

            // 	accept scr-ltr-4.;
            // 	if const-class-ltr-4 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 3;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 4;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-4.;
            //     accept scr-desc-4.;
        }

        private void ha0_class_5()
        {

            // 	accept scr-ltr-5.;
            // 	if const-class-ltr-5 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 4;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 5;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-5.;
            //     accept scr-desc-5.;
        }

        private void ha0_class_6()
        {

            // 	accept scr-ltr-6.;
            // 	if const-class-ltr-6 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 5;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 6;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-6.;
            //     accept scr-desc-6.;
        }

        private void ha0_class_7()
        {

            // 	accept scr-ltr-7.;
            // 	if const-class-ltr-7 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 6;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 7;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-7.;
            //     accept scr-desc-7.;
        }

        private void ha0_class_8()
        {

            // 	accept scr-ltr-8.;
            // 	if const-class-ltr-8 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 7;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 8;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-8.;
            //     accept scr-desc-8.;
        }

        private void ha0_class_9()
        {

            // 	accept scr-ltr-9.;
            // 	if const-class-ltr-9 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 8;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 9;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-9.;
            //     accept scr-desc-9.;
        }

        private void ha0_class_10()
        {

            // 	accept scr-ltr-10.;
            // 	if const-class-ltr-10 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 9;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 10;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-10.;
            //     accept scr-desc-10.;
        }

        private void ha0_class_11()
        {

            // 	accept scr-ltr-11.;
            // 	if const-class-ltr-11 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 10;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 11;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-11.;
            //     accept scr-desc-11.;
        }

        private void ha0_class_12()
        {

            // 	accept scr-ltr-12.;
            // 	if const-class-ltr-12 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 11;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 12;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-12.;
            //     accept scr-desc-12.;
        }

        private void ha0_class_13()
        {

            // 	accept scr-ltr-13.;
            // 	if const-class-ltr-13 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 12;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 13;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-13.;
            //     accept scr-desc-13.;
        }

        private void ha0_class_14()
        {

            // 	accept scr-ltr-14.;
            // 	if const-class-ltr-14 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 13;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 14;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-14.;
            //     accept scr-desc-14.;
        }

        private void ha0_class_15()
        {

            // 	accept scr-ltr-15.;
            // 	if const-class-ltr-15 = spaces;
            // 	then;
            //objConstants_mstr_rec_4.const_nbr_classes = 14;
            // 	    go to ha0-100-continue;
            // 	else;
            ws_class_nbr = 15;
            // 	    perform ha2-check-other-classes thru ha2-99-exit;
            // 	    if class-ok;
            // 	    then;
            // 	 	next sentence;
            // 	    else;
            // 	 	go to ha0-class-15.;
            //     accept scr-desc-15.;
            //objConstants_mstr_rec_4.const_nbr_classes = 15;
        }

        private void ha0_100_continue()
        {

            //     add 1, const-nbr-classes		giving	ws-class-nbr.;
            //     perform ha1-clear-remaining		thru	ha1-99-exit;
            // 	varying temp;
            // 	from    ws-class-nbr;
            // 	by      1;
            // 	until	temp > 15.;
            //     display scr-mask4.;
        }

        private void ha0_99_exit()
        {

            //     exit.;
        }

        private void ha1_clear_remaining()
        {

            //const_class_ltr[temp] = "";
            //const_class_desc[temp] = "";
            //  						const-class-desc (temp).;
        }

        private void ha1_99_exit()
        {

            //     exit.;
        }

        private void ha2_check_other_classes()
        {

            class_flag = "Y";
            //     perform ha21-compare-ltrs		thru	ha21-99-exit;
            // 	varying temp;
            // 	from    1;
            // 	by      1;
            // 	until	temp > const-nbr-classes;
            // 	     or class-not-ok.;
        }

        private void ha2_99_exit()
        {

            //     exit.;
        }

        private void ha21_compare_ltrs()
        {

            //     if    const-class-ltr (temp)     = const-class-ltr (ws-class-nbr);
            //       and temp                   not = ws-class-nbr;
            //     then;
            class_flag = "N";
            err_ind = 8;
            // 	perform za0-common-error	thru	za0-99-exit.;
        }

        private void ha21_99_exit()
        {

            //     exit.;
        }

        private void ia0_const_mstr_5_routine()
        {

            //     if flag not = "M";
            //     then;
            // 	perform ia1-display-screen5   		thru ia1-99-exit.;
            //     if option = "I";
            //     then;
            // 	go to ia0-99-exit.;
            pline = 5;
            pcol1 = 13;
            pcol2 = 20;
            //     perform ia2-accept-nx-avail-pat		thru ia2-99-exit;
            // 		varying i from 1 by 1;
            // 		until   i > 13.;
            pline = 5;
            pcol1 = 50;
            pcol2 = 57;
            //     perform ia2-accept-nx-avail-pat		thru ia2-99-exit;
            // 		varying i from 14 by 1;
            // 		until   i > 24.;
            pline = 16;
            i = 25;
            //     display scr-con-nbr.;
            //     accept scr-con-nbr.;
            //     display scr-nx-avail-pat.;
            //     accept scr-nx-avail-pat.;
        }

        private void ia0_99_exit()
        {

            //     exit.;
        }

        private void ia1_display_screen5()
        {

            //     display scr-mask5-lit.;
            pline = 5;
            pcol1 = 13;
            pcol2 = 20;
            //     perform ia11-display-scr-mask5	thru ia11-99-exit;
            // 		varying i from 1 by 1;
            // 		until   i > 13.;
            pline = 5;
            pcol1 = 50;
            pcol2 = 57;
            //     perform ia11-display-scr-mask5	thru ia11-99-exit;
            // 		varying i from 14 by 1;
            // 		until   i > 25.;
        }

        private void ia1_99_exit()
        {

            //     exit.;
        }

        private void ia11_display_scr_mask5()
        {

            //     display scr-mask5.;
            //     add 1					to pline.;
        }

        private void ia11_99_exit()
        {

            //     exit.;
        }

        private void ia2_accept_nx_avail_pat()
        {

            //     display scr-nx-avail-pat.;
            //     accept scr-nx-avail-pat.;
            //     add 1					to pline.;
        }

        private void ia2_99_exit()
        {

            //     exit.;
        }

        private void ma1_read_iconst_mstr()
        {

            flag_lock = "N";
            //     if option = "I";
            //     then;
            // 	read   iconst-mstr;
            // 	    invalid key;
            flag = "N";
            // 	        go to ma1-99-exit.;
            //     if option not = "I";
            //     then;
            // 	read   iconst-mstr    lock;
            // 	    invalid key;
            flag = "N";
            // 	        go to ma1-99-exit.;
            //     if rec-locked;
            //     then;
            // 	go to ma1-read-iconst-mstr.;
            //     add 1				to ctr-const-mstr-reads.;
        }

        private void ma1_99_exit()
        {

            //     exit.;
        }

        private void pa1_re_write_iconst_mstr()
        {

            // 	rewrite iconst-mstr-rec.;
            // 	unlock iconst-mstr  record.;
            //     add 1				to ctr-const-mstr-changes.;
        }

        private void pa1_99_exit()
        {

            //     exit.;
        }

        private void ra0_write_audit_rpt()
        {

            //objAudit_record pic.audit_record = objConstants_mstr_rec_1.constants_mstr_rec_1;
            //     write audit-record.;
            //     add 1				to ctr-audit-rpt-writes.;
        }

        private void ra0_99_exit()
        {

            //     exit.;
        }

        private void az0_end_of_job()
        {

            //     display blank-screen.;
            //     accept sys-time			from time.;
            //     display scr-closing-screen.;
            //     display confirm.;
            //     close iconst-mstr.;
            //     close  audit-file.;
            //     chain "$obj/menu".;
            //     stop run.;
        }

        private void az0_99_exit()
        {

            //     exit.;
        }

        private void za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            //     accept scr-confirm.;
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

