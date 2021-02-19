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
    public delegate void M095ExitCobolScreen();

    public class M095ViewModel : CommonFunctionScr
    {
        public event M095ExitCobolScreen ExitCobol;

        public M095ViewModel()
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

        private string _ws_msg_sub_key_3;
        public string ws_msg_sub_key_3
        {
            get
            {
                return _ws_msg_sub_key_3;
            }
            set
            {
                if (_ws_msg_sub_key_3 != value)
                {
                    _ws_msg_sub_key_3 = value;
                    _ws_msg_sub_key_3 = _ws_msg_sub_key_3.ToUpper();
                    RaisePropertyChanged("ws_msg_sub_key_3");
                }
            }
        }

        private string _msg_sub_key_3;
        public string msg_sub_key_3
        {
            get
            {
                return _msg_sub_key_3;
            }
            set
            {
                if (_msg_sub_key_3 != value)
                {
                    _msg_sub_key_3 = value;
                    _msg_sub_key_3 = _msg_sub_key_3.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3");
                }
            }
        }

        private string _msg_sub_key_3_2;
        public string msg_sub_key_3_2
        {
            get
            {
                return _msg_sub_key_3_2;
            }
            set
            {
                if (_msg_sub_key_3_2 != value)
                {
                    _msg_sub_key_3_2 = value;
                    _msg_sub_key_3_2 = _msg_sub_key_3_2.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_2");
                }
            }
        }

        private string _msg_sub_key_3_3;
        public string msg_sub_key_3_3
        {
            get
            {
                return _msg_sub_key_3_3;
            }
            set
            {
                if (_msg_sub_key_3_3 != value)
                {
                    _msg_sub_key_3_3 = value;
                    _msg_sub_key_3_3 = _msg_sub_key_3_3.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_3");
                }
            }
        }

        private string _msg_sub_key_3_4;
        public string msg_sub_key_3_4
        {
            get
            {
                return _msg_sub_key_3_4;
            }
            set
            {
                if (_msg_sub_key_3_4 != value)
                {
                    _msg_sub_key_3_4 = value;
                    _msg_sub_key_3_4 = _msg_sub_key_3_4.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_4");
                }
            }
        }

        private string _msg_sub_key_3_5;
        public string msg_sub_key_3_5
        {
            get
            {
                return _msg_sub_key_3_5;
            }
            set
            {
                if (_msg_sub_key_3_5 != value)
                {
                    _msg_sub_key_3_5 = value;
                    _msg_sub_key_3_5 = _msg_sub_key_3_5.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_5");
                }
            }
        }

        private string _msg_sub_key_3_6;
        public string msg_sub_key_3_6
        {
            get
            {
                return _msg_sub_key_3_6;
            }
            set
            {
                if (_msg_sub_key_3_6 != value)
                {
                    _msg_sub_key_3_6 = value;
                    _msg_sub_key_3_6 = _msg_sub_key_3_6.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_6");
                }
            }
        }

        private string _msg_sub_key_3_7;
        public string msg_sub_key_3_7
        {
            get
            {
                return _msg_sub_key_3_7;
            }
            set
            {
                if (_msg_sub_key_3_7 != value)
                {
                    _msg_sub_key_3_7 = value;
                    _msg_sub_key_3_7 = _msg_sub_key_3_7.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_7");
                }
            }
        }

        private string _msg_sub_key_3_8;
        public string msg_sub_key_3_8
        {
            get
            {
                return _msg_sub_key_3_8;
            }
            set
            {
                if (_msg_sub_key_3_8 != value)
                {
                    _msg_sub_key_3_8 = value;
                    _msg_sub_key_3_8 = _msg_sub_key_3_8.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_8");
                }
            }
        }

        private string _msg_sub_key_3_9;
        public string msg_sub_key_3_9
        {
            get
            {
                return _msg_sub_key_3_9;
            }
            set
            {
                if (_msg_sub_key_3_9 != value)
                {
                    _msg_sub_key_3_9 = value;
                    _msg_sub_key_3_9 = _msg_sub_key_3_9.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_9");
                }
            }
        }

        private string _msg_sub_key_3_10;
        public string msg_sub_key_3_10
        {
            get
            {
                return _msg_sub_key_3_10;
            }
            set
            {
                if (_msg_sub_key_3_10 != value)
                {
                    _msg_sub_key_3_10 = value;
                    _msg_sub_key_3_10 = _msg_sub_key_3_10.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_10");
                }
            }
        }

        private string _msg_sub_key_3_11;
        public string msg_sub_key_3_11
        {
            get
            {
                return _msg_sub_key_3_11;
            }
            set
            {
                if (_msg_sub_key_3_11 != value)
                {
                    _msg_sub_key_3_11 = value;
                    _msg_sub_key_3_11 = _msg_sub_key_3_11.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_11");
                }
            }
        }

        private string _msg_sub_key_3_12;
        public string msg_sub_key_3_12
        {
            get
            {
                return _msg_sub_key_3_12;
            }
            set
            {
                if (_msg_sub_key_3_12 != value)
                {
                    _msg_sub_key_3_12 = value;
                    _msg_sub_key_3_12 = _msg_sub_key_3_12.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_12");
                }
            }
        }

        private string _msg_sub_key_3_13;
        public string msg_sub_key_3_13
        {
            get
            {
                return _msg_sub_key_3_13;
            }
            set
            {
                if (_msg_sub_key_3_13 != value)
                {
                    _msg_sub_key_3_13 = value;
                    _msg_sub_key_3_13 = _msg_sub_key_3_13.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_13");
                }
            }
        }

        private string _msg_sub_key_3_14;
        public string msg_sub_key_3_14
        {
            get
            {
                return _msg_sub_key_3_14;
            }
            set
            {
                if (_msg_sub_key_3_14 != value)
                {
                    _msg_sub_key_3_14 = value;
                    _msg_sub_key_3_14 = _msg_sub_key_3_14.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_14");
                }
            }
        }

        private string _msg_sub_key_3_15;
        public string msg_sub_key_3_15
        {
            get
            {
                return _msg_sub_key_3_15;
            }
            set
            {
                if (_msg_sub_key_3_15 != value)
                {
                    _msg_sub_key_3_15 = value;
                    _msg_sub_key_3_15 = _msg_sub_key_3_15.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_15");
                }
            }
        }

        private string _msg_sub_key_3_16;
        public string msg_sub_key_3_16
        {
            get
            {
                return _msg_sub_key_3_16;
            }
            set
            {
                if (_msg_sub_key_3_16 != value)
                {
                    _msg_sub_key_3_16 = value;
                    _msg_sub_key_3_16 = _msg_sub_key_3_16.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_16");
                }
            }
        }

        private string _msg_sub_key_3_17;
        public string msg_sub_key_3_17
        {
            get
            {
                return _msg_sub_key_3_17;
            }
            set
            {
                if (_msg_sub_key_3_17 != value)
                {
                    _msg_sub_key_3_17 = value;
                    _msg_sub_key_3_17 = _msg_sub_key_3_17.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_17");
                }
            }
        }

        private string _msg_sub_key_3_18;
        public string msg_sub_key_3_18
        {
            get
            {
                return _msg_sub_key_3_18;
            }
            set
            {
                if (_msg_sub_key_3_18 != value)
                {
                    _msg_sub_key_3_18 = value;
                    _msg_sub_key_3_18 = _msg_sub_key_3_18.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_18");
                }
            }
        }

        private string _msg_sub_key_3_19;
        public string msg_sub_key_3_19
        {
            get
            {
                return _msg_sub_key_3_19;
            }
            set
            {
                if (_msg_sub_key_3_19 != value)
                {
                    _msg_sub_key_3_19 = value;
                    _msg_sub_key_3_19 = _msg_sub_key_3_19.ToUpper();
                    RaisePropertyChanged("msg_sub_key_3_19");
                }
            }
        }

        private string _sub_fee_complex;
        public string sub_fee_complex
        {
            get
            {
                return _sub_fee_complex;
            }
            set
            {
                if (_sub_fee_complex != value)
                {
                    _sub_fee_complex = value;
                    _sub_fee_complex = _sub_fee_complex.ToUpper();
                    RaisePropertyChanged("sub_fee_complex");
                }
            }
        }

        private string _sub_fee_complex_2;
        public string sub_fee_complex_2
        {
            get
            {
                return _sub_fee_complex_2;
            }
            set
            {
                if (_sub_fee_complex_2 != value)
                {
                    _sub_fee_complex_2 = value;
                    _sub_fee_complex_2 = _sub_fee_complex_2.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_2");
                }
            }
        }

        private string _sub_fee_complex_3;
        public string sub_fee_complex_3
        {
            get
            {
                return _sub_fee_complex_3;
            }
            set
            {
                if (_sub_fee_complex_3 != value)
                {
                    _sub_fee_complex_3 = value;
                    _sub_fee_complex_3 = _sub_fee_complex_3.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_3");
                }
            }
        }

        private string _sub_fee_complex_4;
        public string sub_fee_complex_4
        {
            get
            {
                return _sub_fee_complex_4;
            }
            set
            {
                if (_sub_fee_complex_4 != value)
                {
                    _sub_fee_complex_4 = value;
                    _sub_fee_complex_4 = _sub_fee_complex_4.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_4");
                }
            }
        }

        private string _sub_fee_complex_5;
        public string sub_fee_complex_5
        {
            get
            {
                return _sub_fee_complex_5;
            }
            set
            {
                if (_sub_fee_complex_5 != value)
                {
                    _sub_fee_complex_5 = value;
                    _sub_fee_complex_5 = _sub_fee_complex_5.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_5");
                }
            }
        }

        private string _sub_fee_complex_6;
        public string sub_fee_complex_6
        {
            get
            {
                return _sub_fee_complex_6;
            }
            set
            {
                if (_sub_fee_complex_6 != value)
                {
                    _sub_fee_complex_6 = value;
                    _sub_fee_complex_6 = _sub_fee_complex_6.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_6");
                }
            }
        }

        private string _sub_fee_complex_7;
        public string sub_fee_complex_7
        {
            get
            {
                return _sub_fee_complex_7;
            }
            set
            {
                if (_sub_fee_complex_7 != value)
                {
                    _sub_fee_complex_7 = value;
                    _sub_fee_complex_7 = _sub_fee_complex_7.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_7");
                }
            }
        }

        private string _sub_fee_complex_8;
        public string sub_fee_complex_8
        {
            get
            {
                return _sub_fee_complex_8;
            }
            set
            {
                if (_sub_fee_complex_8 != value)
                {
                    _sub_fee_complex_8 = value;
                    _sub_fee_complex_8 = _sub_fee_complex_8.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_8");
                }
            }
        }

        private string _sub_fee_complex_9;
        public string sub_fee_complex_9
        {
            get
            {
                return _sub_fee_complex_9;
            }
            set
            {
                if (_sub_fee_complex_9 != value)
                {
                    _sub_fee_complex_9 = value;
                    _sub_fee_complex_9 = _sub_fee_complex_9.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_9");
                }
            }
        }

        private string _sub_fee_complex_10;
        public string sub_fee_complex_10
        {
            get
            {
                return _sub_fee_complex_10;
            }
            set
            {
                if (_sub_fee_complex_10 != value)
                {
                    _sub_fee_complex_10 = value;
                    _sub_fee_complex_10 = _sub_fee_complex_10.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_10");
                }
            }
        }

        private string _sub_fee_complex_11;
        public string sub_fee_complex_11
        {
            get
            {
                return _sub_fee_complex_11;
            }
            set
            {
                if (_sub_fee_complex_11 != value)
                {
                    _sub_fee_complex_11 = value;
                    _sub_fee_complex_11 = _sub_fee_complex_11.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_11");
                }
            }
        }

        private string _sub_fee_complex_12;
        public string sub_fee_complex_12
        {
            get
            {
                return _sub_fee_complex_12;
            }
            set
            {
                if (_sub_fee_complex_12 != value)
                {
                    _sub_fee_complex_12 = value;
                    _sub_fee_complex_12 = _sub_fee_complex_12.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_12");
                }
            }
        }

        private string _sub_fee_complex_13;
        public string sub_fee_complex_13
        {
            get
            {
                return _sub_fee_complex_13;
            }
            set
            {
                if (_sub_fee_complex_13 != value)
                {
                    _sub_fee_complex_13 = value;
                    _sub_fee_complex_13 = _sub_fee_complex_13.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_13");
                }
            }
        }

        private string _sub_fee_complex_14;
        public string sub_fee_complex_14
        {
            get
            {
                return _sub_fee_complex_14;
            }
            set
            {
                if (_sub_fee_complex_14 != value)
                {
                    _sub_fee_complex_14 = value;
                    _sub_fee_complex_14 = _sub_fee_complex_14.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_14");
                }
            }
        }

        private string _sub_fee_complex_15;
        public string sub_fee_complex_15
        {
            get
            {
                return _sub_fee_complex_15;
            }
            set
            {
                if (_sub_fee_complex_15 != value)
                {
                    _sub_fee_complex_15 = value;
                    _sub_fee_complex_15 = _sub_fee_complex_15.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_15");
                }
            }
        }

        private string _sub_fee_complex_16;
        public string sub_fee_complex_16
        {
            get
            {
                return _sub_fee_complex_16;
            }
            set
            {
                if (_sub_fee_complex_16 != value)
                {
                    _sub_fee_complex_16 = value;
                    _sub_fee_complex_16 = _sub_fee_complex_16.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_16");
                }
            }
        }

        private string _sub_fee_complex_17;
        public string sub_fee_complex_17
        {
            get
            {
                return _sub_fee_complex_17;
            }
            set
            {
                if (_sub_fee_complex_17 != value)
                {
                    _sub_fee_complex_17 = value;
                    _sub_fee_complex_17 = _sub_fee_complex_17.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_17");
                }
            }
        }

        private string _sub_fee_complex_18;
        public string sub_fee_complex_18
        {
            get
            {
                return _sub_fee_complex_18;
            }
            set
            {
                if (_sub_fee_complex_18 != value)
                {
                    _sub_fee_complex_18 = value;
                    _sub_fee_complex_18 = _sub_fee_complex_18.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_18");
                }
            }
        }

        private string _sub_fee_complex_19;
        public string sub_fee_complex_19
        {
            get
            {
                return _sub_fee_complex_19;
            }
            set
            {
                if (_sub_fee_complex_19 != value)
                {
                    _sub_fee_complex_19 = value;
                    _sub_fee_complex_19 = _sub_fee_complex_19.ToUpper();
                    RaisePropertyChanged("sub_fee_complex_19");
                }
            }
        }

        private string _sub_auto_logout;
        public string sub_auto_logout
        {
            get
            {
                return _sub_auto_logout;
            }
            set
            {
                if (_sub_auto_logout != value)
                {
                    _sub_auto_logout = value;
                    _sub_auto_logout = _sub_auto_logout.ToUpper();
                    RaisePropertyChanged("sub_auto_logout");
                }
            }
        }

        private string _sub_auto_logout_2;
        public string sub_auto_logout_2
        {
            get
            {
                return _sub_auto_logout_2;
            }
            set
            {
                if (_sub_auto_logout_2 != value)
                {
                    _sub_auto_logout_2 = value;
                    _sub_auto_logout_2 = _sub_auto_logout_2.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_2");
                }
            }
        }

        private string _sub_auto_logout_3;
        public string sub_auto_logout_3
        {
            get
            {
                return _sub_auto_logout_3;
            }
            set
            {
                if (_sub_auto_logout_3 != value)
                {
                    _sub_auto_logout_3 = value;
                    _sub_auto_logout_3 = _sub_auto_logout_3.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_3");
                }
            }
        }

        private string _sub_auto_logout_4;
        public string sub_auto_logout_4
        {
            get
            {
                return _sub_auto_logout_4;
            }
            set
            {
                if (_sub_auto_logout_4 != value)
                {
                    _sub_auto_logout_4 = value;
                    _sub_auto_logout_4 = _sub_auto_logout_4.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_4");
                }
            }
        }

        private string _sub_auto_logout_5;
        public string sub_auto_logout_5
        {
            get
            {
                return _sub_auto_logout_5;
            }
            set
            {
                if (_sub_auto_logout_5 != value)
                {
                    _sub_auto_logout_5 = value;
                    _sub_auto_logout_5 = _sub_auto_logout_5.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_5");
                }
            }
        }

        private string _sub_auto_logout_6;
        public string sub_auto_logout_6
        {
            get
            {
                return _sub_auto_logout_6;
            }
            set
            {
                if (_sub_auto_logout_6 != value)
                {
                    _sub_auto_logout_6 = value;
                    _sub_auto_logout_6 = _sub_auto_logout_6.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_6");
                }
            }
        }

        private string _sub_auto_logout_7;
        public string sub_auto_logout_7
        {
            get
            {
                return _sub_auto_logout_7;
            }
            set
            {
                if (_sub_auto_logout_7 != value)
                {
                    _sub_auto_logout_7 = value;
                    _sub_auto_logout_7 = _sub_auto_logout_7.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_7");
                }
            }
        }

        private string _sub_auto_logout_8;
        public string sub_auto_logout_8
        {
            get
            {
                return _sub_auto_logout_8;
            }
            set
            {
                if (_sub_auto_logout_8 != value)
                {
                    _sub_auto_logout_8 = value;
                    _sub_auto_logout_8 = _sub_auto_logout_8.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_8");
                }
            }
        }

        private string _sub_auto_logout_9;
        public string sub_auto_logout_9
        {
            get
            {
                return _sub_auto_logout_9;
            }
            set
            {
                if (_sub_auto_logout_9 != value)
                {
                    _sub_auto_logout_9 = value;
                    _sub_auto_logout_9 = _sub_auto_logout_9.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_9");
                }
            }
        }

        private string _sub_auto_logout_10;
        public string sub_auto_logout_10
        {
            get
            {
                return _sub_auto_logout_10;
            }
            set
            {
                if (_sub_auto_logout_10 != value)
                {
                    _sub_auto_logout_10 = value;
                    _sub_auto_logout_10 = _sub_auto_logout_10.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_10");
                }
            }
        }

        private string _sub_auto_logout_11;
        public string sub_auto_logout_11
        {
            get
            {
                return _sub_auto_logout_11;
            }
            set
            {
                if (_sub_auto_logout_11 != value)
                {
                    _sub_auto_logout_11 = value;
                    _sub_auto_logout_11 = _sub_auto_logout_11.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_11");
                }
            }
        }

        private string _sub_auto_logout_12;
        public string sub_auto_logout_12
        {
            get
            {
                return _sub_auto_logout_12;
            }
            set
            {
                if (_sub_auto_logout_12 != value)
                {
                    _sub_auto_logout_12 = value;
                    _sub_auto_logout_12 = _sub_auto_logout_12.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_12");
                }
            }
        }

        private string _sub_auto_logout_13;
        public string sub_auto_logout_13
        {
            get
            {
                return _sub_auto_logout_13;
            }
            set
            {
                if (_sub_auto_logout_13 != value)
                {
                    _sub_auto_logout_13 = value;
                    _sub_auto_logout_13 = _sub_auto_logout_13.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_13");
                }
            }
        }

        private string _sub_auto_logout_14;
        public string sub_auto_logout_14
        {
            get
            {
                return _sub_auto_logout_14;
            }
            set
            {
                if (_sub_auto_logout_14 != value)
                {
                    _sub_auto_logout_14 = value;
                    _sub_auto_logout_14 = _sub_auto_logout_14.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_14");
                }
            }
        }

        private string _sub_auto_logout_15;
        public string sub_auto_logout_15
        {
            get
            {
                return _sub_auto_logout_15;
            }
            set
            {
                if (_sub_auto_logout_15 != value)
                {
                    _sub_auto_logout_15 = value;
                    _sub_auto_logout_15 = _sub_auto_logout_15.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_15");
                }
            }
        }

        private string _sub_auto_logout_16;
        public string sub_auto_logout_16
        {
            get
            {
                return _sub_auto_logout_16;
            }
            set
            {
                if (_sub_auto_logout_16 != value)
                {
                    _sub_auto_logout_16 = value;
                    _sub_auto_logout_16 = _sub_auto_logout_16.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_16");
                }
            }
        }

        private string _sub_auto_logout_17;
        public string sub_auto_logout_17
        {
            get
            {
                return _sub_auto_logout_17;
            }
            set
            {
                if (_sub_auto_logout_17 != value)
                {
                    _sub_auto_logout_17 = value;
                    _sub_auto_logout_17 = _sub_auto_logout_17.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_17");
                }
            }
        }

        private string _sub_auto_logout_18;
        public string sub_auto_logout_18
        {
            get
            {
                return _sub_auto_logout_18;
            }
            set
            {
                if (_sub_auto_logout_18 != value)
                {
                    _sub_auto_logout_18 = value;
                    _sub_auto_logout_18 = _sub_auto_logout_18.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_18");
                }
            }
        }

        private string _sub_auto_logout_19;
        public string sub_auto_logout_19
        {
            get
            {
                return _sub_auto_logout_19;
            }
            set
            {
                if (_sub_auto_logout_19 != value)
                {
                    _sub_auto_logout_19 = value;
                    _sub_auto_logout_19 = _sub_auto_logout_19.ToUpper();
                    RaisePropertyChanged("sub_auto_logout_19");
                }
            }
        }

        private string _sub_name;
        public string sub_name
        {
            get
            {
                return _sub_name;
            }
            set
            {
                if (_sub_name != value)
                {
                    _sub_name = value;
                    _sub_name = _sub_name.ToUpper();
                    RaisePropertyChanged("sub_name");
                }
            }
        }

        private string _sub_name_2;
        public string sub_name_2
        {
            get
            {
                return _sub_name_2;
            }
            set
            {
                if (_sub_name_2 != value)
                {
                    _sub_name_2 = value;
                    _sub_name_2 = _sub_name_2.ToUpper();
                    RaisePropertyChanged("sub_name_2");
                }
            }
        }

        private string _sub_name_3;
        public string sub_name_3
        {
            get
            {
                return _sub_name_3;
            }
            set
            {
                if (_sub_name_3 != value)
                {
                    _sub_name_3 = value;
                    _sub_name_3 = _sub_name_3.ToUpper();
                    RaisePropertyChanged("sub_name_3");
                }
            }
        }

        private string _sub_name_4;
        public string sub_name_4
        {
            get
            {
                return _sub_name_4;
            }
            set
            {
                if (_sub_name_4 != value)
                {
                    _sub_name_4 = value;
                    _sub_name_4 = _sub_name_4.ToUpper();
                    RaisePropertyChanged("sub_name_4");
                }
            }
        }

        private string _sub_name_5;
        public string sub_name_5
        {
            get
            {
                return _sub_name_5;
            }
            set
            {
                if (_sub_name_5 != value)
                {
                    _sub_name_5 = value;
                    _sub_name_5 = _sub_name_5.ToUpper();
                    RaisePropertyChanged("sub_name_5");
                }
            }
        }

        private string _sub_name_6;
        public string sub_name_6
        {
            get
            {
                return _sub_name_6;
            }
            set
            {
                if (_sub_name_6 != value)
                {
                    _sub_name_6 = value;
                    _sub_name_6 = _sub_name_6.ToUpper();
                    RaisePropertyChanged("sub_name_6");
                }
            }
        }

        private string _sub_name_7;
        public string sub_name_7
        {
            get
            {
                return _sub_name_7;
            }
            set
            {
                if (_sub_name_7 != value)
                {
                    _sub_name_7 = value;
                    _sub_name_7 = _sub_name_7.ToUpper();
                    RaisePropertyChanged("sub_name_7");
                }
            }
        }

        private string _sub_name_8;
        public string sub_name_8
        {
            get
            {
                return _sub_name_8;
            }
            set
            {
                if (_sub_name_8 != value)
                {
                    _sub_name_8 = value;
                    _sub_name_8 = _sub_name_8.ToUpper();
                    RaisePropertyChanged("sub_name_8");
                }
            }
        }

        private string _sub_name_9;
        public string sub_name_9
        {
            get
            {
                return _sub_name_9;
            }
            set
            {
                if (_sub_name_9 != value)
                {
                    _sub_name_9 = value;
                    _sub_name_9 = _sub_name_9.ToUpper();
                    RaisePropertyChanged("sub_name_9");
                }
            }
        }

        private string _sub_name_10;
        public string sub_name_10
        {
            get
            {
                return _sub_name_10;
            }
            set
            {
                if (_sub_name_10 != value)
                {
                    _sub_name_10 = value;
                    _sub_name_10 = _sub_name_10.ToUpper();
                    RaisePropertyChanged("sub_name_10");
                }
            }
        }

        private string _sub_name_11;
        public string sub_name_11
        {
            get
            {
                return _sub_name_11;
            }
            set
            {
                if (_sub_name_11 != value)
                {
                    _sub_name_11 = value;
                    _sub_name_11 = _sub_name_11.ToUpper();
                    RaisePropertyChanged("sub_name_11");
                }
            }
        }

        private string _sub_name_12;
        public string sub_name_12
        {
            get
            {
                return _sub_name_12;
            }
            set
            {
                if (_sub_name_12 != value)
                {
                    _sub_name_12 = value;
                    _sub_name_12 = _sub_name_12.ToUpper();
                    RaisePropertyChanged("sub_name_12");
                }
            }
        }

        private string _sub_name_13;
        public string sub_name_13
        {
            get
            {
                return _sub_name_13;
            }
            set
            {
                if (_sub_name_13 != value)
                {
                    _sub_name_13 = value;
                    _sub_name_13 = _sub_name_13.ToUpper();
                    RaisePropertyChanged("sub_name_13");
                }
            }
        }

        private string _sub_name_14;
        public string sub_name_14
        {
            get
            {
                return _sub_name_14;
            }
            set
            {
                if (_sub_name_14 != value)
                {
                    _sub_name_14 = value;
                    _sub_name_14 = _sub_name_14.ToUpper();
                    RaisePropertyChanged("sub_name_14");
                }
            }
        }

        private string _sub_name_15;
        public string sub_name_15
        {
            get
            {
                return _sub_name_15;
            }
            set
            {
                if (_sub_name_15 != value)
                {
                    _sub_name_15 = value;
                    _sub_name_15 = _sub_name_15.ToUpper();
                    RaisePropertyChanged("sub_name_15");
                }
            }
        }

        private string _sub_name_16;
        public string sub_name_16
        {
            get
            {
                return _sub_name_16;
            }
            set
            {
                if (_sub_name_16 != value)
                {
                    _sub_name_16 = value;
                    _sub_name_16 = _sub_name_16.ToUpper();
                    RaisePropertyChanged("sub_name_16");
                }
            }
        }

        private string _sub_name_17;
        public string sub_name_17
        {
            get
            {
                return _sub_name_17;
            }
            set
            {
                if (_sub_name_17 != value)
                {
                    _sub_name_17 = value;
                    _sub_name_17 = _sub_name_17.ToUpper();
                    RaisePropertyChanged("sub_name_17");
                }
            }
        }

        private string _sub_name_18;
        public string sub_name_18
        {
            get
            {
                return _sub_name_18;
            }
            set
            {
                if (_sub_name_18 != value)
                {
                    _sub_name_18 = value;
                    _sub_name_18 = _sub_name_18.ToUpper();
                    RaisePropertyChanged("sub_name_18");
                }
            }
        }

        private string _sub_name_19;
        public string sub_name_19
        {
            get
            {
                return _sub_name_19;
            }
            set
            {
                if (_sub_name_19 != value)
                {
                    _sub_name_19 = value;
                    _sub_name_19 = _sub_name_19.ToUpper();
                    RaisePropertyChanged("sub_name_19");
                }
            }
        }

        private string _sub_rec;
        public string sub_rec
        {
            get
            {
                return _sub_rec;
            }
            set
            {
                if (_sub_rec != value)
                {
                    _sub_rec = value;
                    _sub_rec = _sub_rec.ToUpper();
                    RaisePropertyChanged("sub_rec");
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
        private string sub_indexer = "S";

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

        private string[] err_msg = {"", "INVALID REPLAY",
            "SUBDIVISION ALREADY EXISTS",
            "SUBDIVISION NBR NOT ON SUBDIVISION MASTER",
            "INVALID RE-WRITE TO SUBDIVISION MASTER",
            "INVALID DELETE ON SUBDIVISION MASTER",
            "NUMERIC SUBDIVISION NUMBER REQUIRED",
            "(H)IGH OR (L)OW FEE COMPLEX REQUIRED",
            "(Y)ES OR (N)O AUTO LOGOUT REQUIRED",
            "SUBDIVISION NAME DETAIL REQUIRED",
            "INVALID WRITE TO SUBDIVISON MASTER"};

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

        private string msg_sub_key_1;
        private string msg_sub_key_2;
        private string endOfJob = "End of Job";

        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection ()
	{
		ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
		{
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 1,Data1 = "M095",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 11,Data1 = "SUBDIVISION MSTR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 29,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "entry_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option-sel"},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 60,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "ws_msg_sub_key_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-msg-id"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "02",Col = 54,Data1 = "SUB NBR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-titles-7."},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9",MaxLength = 1,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 75,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 76,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 78,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 79,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "05",Col = 1,Data1 = "NAME:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "06",Col = 1,Data1 = "FEE COMPLEX:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-lit.",Line = "07",Col = 1,Data1 = "AUTO LOGOUT:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "05",Col = 17,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sub-name."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "06",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sub-fee-complex."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-msg-var.",Line = "07",Col = 17,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-sub-auto-logout."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "add-mode.",Line = "02",Col = 31,Data1 = "ADD MODE                   ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "change-mode.",Line = "02",Col = 31,Data1 = "CHANGE MODE                ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "delete-mode.",Line = "02",Col = 31,Data1 = "DELETE MODE                ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-mode.",Line = "02",Col = 31,Data1 = "INQUIRE MODE               ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "option-mode.",Line = "02",Col = 31,Data1 = "(ADD/CHANGE/DELETE/INQUIRE)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "option-mode-1."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "option-mode.",Line = "03",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "option-mode-2."},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-screen.",Line = "04",Col = 3,Data1 = "        NBR        FEE        AUTO-LOG   NAME",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail.",Line = "5",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail.",Line = "5",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail.",Line = "5",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail.",Line = "5",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-2.",Line = "6",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-2.",Line = "6",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-2.",Line = "6",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-2.",Line = "6",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-3.",Line = "7",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-3.",Line = "7",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-3.",Line = "7",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-3.",Line = "7",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-4.",Line = "8",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-4.",Line = "8",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-4.",Line = "8",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-4.",Line = "8",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-5.",Line = "9",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-5.",Line = "9",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-5.",Line = "9",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-5.",Line = "9",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-6.",Line = "10",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-6.",Line = "10",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-6.",Line = "10",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-6.",Line = "10",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-7.",Line = "11",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-7.",Line = "11",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-7.",Line = "11",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-7.",Line = "11",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-8.",Line = "12",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-8.",Line = "12",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-8.",Line = "12",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-8.",Line = "12",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-9.",Line = "13",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-9.",Line = "13",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-9.",Line = "13",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-9.",Line = "13",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-10.",Line = "14",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-10.",Line = "14",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-10.",Line = "14",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-10.",Line = "14",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-11.",Line = "15",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-11.",Line = "15",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-11.",Line = "15",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-11.",Line = "15",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_11",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-12.",Line = "16",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-12.",Line = "16",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-12.",Line = "16",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-12.",Line = "16",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_12",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-13.",Line = "17",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-13.",Line = "17",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-13.",Line = "17",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-13.",Line = "17",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_13",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-14.",Line = "18",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-14.",Line = "18",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-14.",Line = "18",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-14.",Line = "18",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_14",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-15.",Line = "19",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-15.",Line = "19",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-15.",Line = "19",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-15.",Line = "19",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_15",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-16.",Line = "20",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-16.",Line = "20",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-16.",Line = "20",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-16.",Line = "20",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_16",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-17.",Line = "21",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-17.",Line = "21",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-17.",Line = "21",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-17.",Line = "21",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_17",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-18.",Line = "22",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-18.",Line = "22",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-18.",Line = "22",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-18.",Line = "22",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_18",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-19.",Line = "23",Col = 9,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "msg_sub_key_3_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-19.",Line = "23",Col = 18,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_fee_complex_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-19.",Line = "23",Col = 28,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_auto_logout_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "inquire-detail-19.",Line = "23",Col = 35,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(25)",MaxLength = 25,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sub_name_19",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "clear-inquire-screen.",Line = "12",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "end-of-file.",Line = "24",Col = 64,Data1 = "END OF FILE ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
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
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 20,Data1 = "NUMBER OF SUB-MSTR READS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 20,Data1 = "NUMBER OF SUB-MSTR WRITES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 20,Data1 = "NUMBER OF SUBS ADDED  :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_adds",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "               CHANGED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "               DELETED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_msg_mstr_deletes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
		 new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 20,Data1 = "PROGRAM M095 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},
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
            Msg_mstr_rec_Collection = new ObservableCollection<F094_MSG_MSTR>();
        }

        public async Task mainline()
        {
            try
            {
                await initialize_objects();
                await aa0_initialization();

                do
                {
                    await xd0_acpt_type_sub_read_sub();

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

            ws_msg_sub_key_1 = sub_indexer;
            Display("scr-titles.");
            Display("option-mode.");

            ws_msg_sub_key_3 = "*";
            sub_rec = "";

            await Initialize_Msg_Sub_Mstr_Record_ScreenVariables();
        }

        private async Task az0_end_of_job()
        {
        }

        private async Task ab0_processing()
        {
            do
            {
                if (acc_mod_rej != "M")
                {
                    msg_sub_key_3 = "";
                }

                msg_sub_key_3_2 = "";
                msg_sub_key_3_3 = "";
                msg_sub_key_3_4 = "";
                msg_sub_key_3_5 = "";
                msg_sub_key_3_6 = "";
                msg_sub_key_3_7 = "";
                msg_sub_key_3_8 = "";
                msg_sub_key_3_9 = "";
                msg_sub_key_3_10 = "";
                msg_sub_key_3_11 = "";
                msg_sub_key_3_12 = "";
                msg_sub_key_3_13 = "";
                msg_sub_key_3_14 = "";
                msg_sub_key_3_15 = "";
                msg_sub_key_3_16 = "";
                msg_sub_key_3_17 = "";
                msg_sub_key_3_18 = "";
                msg_sub_key_3_19 = "";
                sub_fee_complex = "";
                sub_fee_complex_2 = "";
                sub_fee_complex_3 = "";
                sub_fee_complex_4 = "";
                sub_fee_complex_5 = "";
                sub_fee_complex_6 = "";
                sub_fee_complex_7 = "";
                sub_fee_complex_8 = "";
                sub_fee_complex_9 = "";
                sub_fee_complex_10 = "";
                sub_fee_complex_11 = "";
                sub_fee_complex_12 = "";
                sub_fee_complex_13 = "";
                sub_fee_complex_14 = "";
                sub_fee_complex_15 = "";
                sub_fee_complex_16 = "";
                sub_fee_complex_17 = "";
                sub_fee_complex_18 = "";
                sub_fee_complex_19 = "";
                sub_auto_logout = "";
                sub_auto_logout_2 = "";
                sub_auto_logout_3 = "";
                sub_auto_logout_4 = "";
                sub_auto_logout_5 = "";
                sub_auto_logout_6 = "";
                sub_auto_logout_7 = "";
                sub_auto_logout_8 = "";
                sub_auto_logout_9 = "";
                sub_auto_logout_10 = "";
                sub_auto_logout_11 = "";
                sub_auto_logout_12 = "";
                sub_auto_logout_13 = "";
                sub_auto_logout_14 = "";
                sub_auto_logout_15 = "";
                sub_auto_logout_16 = "";
                sub_auto_logout_17 = "";
                sub_auto_logout_18 = "";
                sub_auto_logout_19 = "";
                sub_name = "";
                sub_name_2 = "";
                sub_name_3 = "";
                sub_name_4 = "";
                sub_name_5 = "";
                sub_name_6 = "";
                sub_name_7 = "";
                sub_name_8 = "";
                sub_name_9 = "";
                sub_name_10 = "";
                sub_name_11 = "";
                sub_name_12 = "";
                sub_name_13 = "";
                sub_name_14 = "";
                sub_name_15 = "";
                sub_name_16 = "";
                sub_name_17 = "";
                sub_name_18 = "";
                sub_name_19 = "";

                if (entry_type.Equals(add_code))
                {
                    if (acc_mod_rej != "M")
                    {
                        do
                        {
                            await ab0_95_next_msg();
                        } while (flag_status.Equals(ok));
                    }

                    if (!ws_msg_sub_key_3.Equals("*"))
                    {
                        Display("scr-msg-lit.");
                        await ba0_add_change();
                        await ba0_accpt_name();
                        await ba0_accpt_fee_complex();
                        await ba0_accpt_auto_logout();

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

                    if (!ws_msg_sub_key_3.Equals("*"))
                    {
                        //mw

                        Display("scr-msg-var.");
                        await ba0_add_change();
                        await ba0_accpt_name();
                        await ba0_accpt_fee_complex();
                        await ba0_accpt_auto_logout();

                        await ab0_30_disp_verif();
                        await ab0_40_y_n_m();
                        Display("scr-msg-var.", false);
                    }
                }
                else if (entry_type.Equals(inquire_code))
                {
                    Display("inquire-detail.", false);
                    Display("inquire-detail-2.", false);
                    Display("inquire-detail-3.", false);
                    Display("inquire-detail-4.", false);
                    Display("inquire-detail-5.", false);
                    Display("inquire-detail-6.", false);
                    Display("inquire-detail-7.", false);
                    Display("inquire-detail-8.", false);
                    Display("inquire-detail-9.", false);
                    Display("inquire-detail-10.", false);
                    Display("inquire-detail-11.", false);
                    Display("inquire-detail-12.", false);
                    Display("inquire-detail-13.", false);
                    Display("inquire-detail-14.", false);
                    Display("inquire-detail-15.", false);
                    Display("inquire-detail-16.", false);
                    Display("inquire-detail-17.", false);
                    Display("inquire-detail-18.", false);
                    Display("inquire-detail-19.", false);

                    ctr_msg_mstr_reads = 0;

                    do
                    {
                        await ab0_95_next_msg();
                    } while (flag_status.Equals(not_ok));

                    if (!ws_msg_sub_key_3.Equals("*"))
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

                    if (!ws_msg_sub_key_3.Equals("*"))
                    {
                        await ab0_20_delete();
                    }
                }
            } while (ws_msg_sub_key_3 != "*");
        }

        private async Task ab0_10_inquire()
        {
            if (!ws_msg_sub_key_3.Equals("*"))
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
            if (!ws_msg_sub_key_3.Equals("*"))
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
            await xd0_10_acpt_msg();

            if (ws_msg_sub_key_3.Equals("*"))
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
            else if (!Util.IsNumeric(ws_msg_sub_key_3))
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

        private async Task ba0_add_change()
        {
            sub_rec = "";
        }

        private async Task ba0_accpt_name()
        {
            Display("scr-msg-var.", "scr-sub-name.");
            await Prompt("sub_name");
        }

        private async Task ba0_accpt_fee_complex()
        {
            Display("scr-msg-var.", "scr-sub-fee-complex.");
            await Prompt("sub_fee_complex");
        }

        private async Task ba0_accpt_auto_logout()
        {
            Display("scr-msg-var.", "scr-sub-auto-logout.");
            await Prompt("sub_auto_logout");
        }

        private async Task ca0_display_records()
        {
            cur_line = 5;

            do
            {
                switch (cur_line)
                {
                    case 5:
                        msg_sub_key_3 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 6:
                        msg_sub_key_3_2 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_2 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_2 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_2 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 7:
                        msg_sub_key_3_3 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_3 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_3 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_3 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 8:
                        msg_sub_key_3_4 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_4 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_4 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_4 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 9:
                        msg_sub_key_3_5 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_5 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_5 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_5 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 10:
                        msg_sub_key_3_6 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_6 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_6 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_6 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 11:
                        msg_sub_key_3_7 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_7 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_7 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_7 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 12:
                        msg_sub_key_3_8 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_8 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_8 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_8 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 13:
                        msg_sub_key_3_9 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_9 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_9 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_9 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 14:
                        msg_sub_key_3_10 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_10 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_10 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_10 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 15:
                        msg_sub_key_3_11 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_11 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_11 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_11 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 16:
                        msg_sub_key_3_12 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_12 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_12 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_12 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 17:
                        msg_sub_key_3_13 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_13 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_13 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_13 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 18:
                        msg_sub_key_3_14 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_14 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_14 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_14 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 19:
                        msg_sub_key_3_15 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_15 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_15 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_15 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 20:
                        msg_sub_key_3_16 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_16 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_16 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_16 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 21:
                        msg_sub_key_3_17 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_17 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_17 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_17 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 22:
                        msg_sub_key_3_18 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_18 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_18 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_18 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 23:
                        msg_sub_key_3_19 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_19 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_19 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_19 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;
                }

                Display("scr-msg-lit.", false);
                Display("scr-msg-var.", false);
                Display("option-mode.", "option-mode-2.", false);

                await ca2_load_inquire();
            } while ((cur_line <= 19) && !flag_eof_msg_sub_mstr.Equals(eof_msg_sub_mstr) && (Util.Str(msg_sub_key_1).ToUpper() == sub_indexer));

            if (flag_eof_msg_sub_mstr.Equals(eof_msg_sub_mstr) || (Util.Str(msg_sub_key_1).ToUpper() != sub_indexer))
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
                    Display("inquire-detail.", false);
                    Display("inquire-detail-2.", false);
                    Display("inquire-detail-3.", false);
                    Display("inquire-detail-4.", false);
                    Display("inquire-detail-5.", false);
                    Display("inquire-detail-6.", false);
                    Display("inquire-detail-7.", false);
                    Display("inquire-detail-8.", false);
                    Display("inquire-detail-9.", false);
                    Display("inquire-detail-10.", false);
                    Display("inquire-detail-11.", false);
                    Display("inquire-detail-12.", false);
                    Display("inquire-detail-13.", false);
                    Display("inquire-detail-14.", false);
                    Display("inquire-detail-15.", false);
                    Display("inquire-detail-16.", false);
                    Display("inquire-detail-17.", false);
                    Display("inquire-detail-18.", false);
                    Display("inquire-detail-19.", false);

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
                    Display("inquire-detail.");
                    break;

                case 6:
                    Display("inquire-detail-2.");
                    break;

                case 7:
                    Display("inquire-detail-3.");
                    break;

                case 8:
                    Display("inquire-detail-4.");
                    break;

                case 9:
                    Display("inquire-detail-5.");
                    break;

                case 10:
                    Display("inquire-detail-6.");
                    break;

                case 11:
                    Display("inquire-detail-7.");
                    break;

                case 12:
                    Display("inquire-detail-8.");
                    break;

                case 13:
                    Display("inquire-detail-9.");
                    break;

                case 14:
                    Display("inquire-detail-10.");
                    break;

                case 15:
                    Display("inquire-detail-11.");
                    break;

                case 16:
                    Display("inquire-detail-12.");
                    break;

                case 17:
                    Display("inquire-detail-13.");
                    break;

                case 18:
                    Display("inquire-detail-14.");
                    break;

                case 19:
                    Display("inquire-detail-15.");
                    break;

                case 20:
                    Display("inquire-detail-16.");
                    break;

                case 21:
                    Display("inquire-detail-17.");
                    break;

                case 22:
                    Display("inquire-detail-18.");
                    break;

                case 23:
                    Display("inquire-detail-19.");
                    break;
            }

            cur_line += 1;

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
            await Prompt("ws_msg_sub_key_3");

            msg_sub_key_3 = ws_msg_sub_key_3;
        }

        private async Task xc0_read_msg_mstr()
        {
            flag_status = "Y";

            if (entry_type.Equals(add_code))
            {
                Msg_mstr_rec_Collection = new F094_MSG_MSTR
                {
                    WhereMsg_sub_key_1 = ws_msg_sub_key_1,
                    WhereMsg_sub_key_23 = ws_msg_sub_key_3
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
                    WhereMsg_sub_key_23 = ws_msg_sub_key_3
                }.Collection();

                if (Msg_mstr_rec_Collection.Count() > 0)
                {
                    flag_status = "Y";
                    cur_line = 5;

                    Msg_sub_mstr_rec_Collection = new F094_SUB_MSTR
                    {
                        WhereMsg_sub_key_12 = ws_msg_sub_key_1,
                        WhereMsg_sub_key_3 = ws_msg_sub_key_3
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
                Msg_sub_mstr_rec_Collection = new F094_SUB_MSTR
                {
                    WhereMsg_sub_key_12 = ws_msg_sub_key_1,
                    WhereMsg_sub_key_3 = ws_msg_sub_key_3
                }.Collection_GetSubMessages();

                flag_status = "Y";
            }

            objMsg_sub_mstr_rec = Msg_sub_mstr_rec_Collection[0];

            if (entry_type.Equals(change_code) || entry_type.Equals(delete_code))
            {
                objMsg_mstr_rec = Msg_mstr_rec_Collection[0];
                objMsg_sub_mstr_rec = Msg_sub_mstr_rec_Collection[0];
            }

            await Assign_Msg_Sub_Mstr_Rec_to_ScreenVariables();

            ctr_msg_mstr_reads++;
        }

        private async Task xd0_acpt_type_sub_read_sub()
        {
            if (ws_msg_sub_key_3 == "*")
            {
                //Display("scr-titles.", "scr-titles-5.", false);
                Display("add-mode.", false);
                Display("change-mode.", false);
                Display("delete-mode.", false);
                Display("inquire-mode.", false);
                Display("option-mode.");

                entry_type = "";
                ws_msg_sub_key_3 = "";

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

                        cur_line = 5;
                    }
                    else
                    {
                        err_ind = 1;
                        await za0_common_error();
                        ws_msg_sub_key_3 = "*";
                        await xd0_acpt_type_sub_read_sub();
                    }
                }
            }
        }

        private async Task xd0_10_acpt_msg()
        {
            ws_msg_sub_key_3 = "";
            Display("scr-titles.", "scr-msg-id");

            await xa0_acpt_msg_entered();

            if (ws_msg_sub_key_3 == "*")
            {
                Display("scr-msg-lit.", false);
            }
            else if (!Util.IsNumeric(ws_msg_sub_key_3))
            {
                err_ind = 8;
                await za0_common_error();
            }
            else
            {
                ws_msg_sub_key_grp = ws_msg_sub_key_1 + ws_msg_sub_key_3;

                cur_line = 5;

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
            if (ctr_msg_mstr_reads >= Msg_sub_mstr_rec_Collection.Count() || Msg_sub_mstr_rec_Collection.Count() == 0)
            {
                flag_eof_msg_sub_mstr = "Y";
            }
            else
            {
                objMsg_sub_mstr_rec = Msg_sub_mstr_rec_Collection[ctr_msg_mstr_reads];
                await Assign_Msg_Sub_Mstr_Rec_to_ScreenVariables();

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
            msg_sub_key_3 = "";
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

                objMsg_mstr_rec.MSG_SUB_KEY_1 = sub_indexer;
                objMsg_mstr_rec.MSG_SUB_KEY_23 = msg_sub_key_3;
                objMsg_mstr_rec.MSG_REPRINT_FLAG = Util.Substring(sub_name, 0, 1);
                objMsg_mstr_rec.MSG_AUTO_LOGOUT = Util.Substring(sub_name, 1, 1);
                objMsg_mstr_rec.MSG_DTL1 = Util.Substring(sub_name, 2, sub_name.Length - 2);
                objMsg_mstr_rec.RecordState = State.Added;
                objMsg_mstr_rec.Submit();

                F094_SUB_MSTR objMsg_sub_mstr_rec = null;
                objMsg_sub_mstr_rec = new F094_SUB_MSTR();

                objMsg_sub_mstr_rec.MSG_SUB_KEY_12 = sub_indexer;
                objMsg_sub_mstr_rec.MSG_SUB_KEY_3 = msg_sub_key_3;
                objMsg_sub_mstr_rec.SUB_NAME = sub_name;
                objMsg_sub_mstr_rec.SUB_FEE_COMPLEX = sub_fee_complex;
                objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT = sub_auto_logout;

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
                    WhereMsg_sub_key_1 = sub_indexer,
                    WhereMsg_sub_key_23 = (msg_sub_key_2 + msg_sub_key_3).Trim()
                }.Collection().FirstOrDefault();

                objF094_MSG_MSTR.MSG_SUB_KEY_1 = sub_indexer;
                objF094_MSG_MSTR.MSG_SUB_KEY_23 = (msg_sub_key_2 + msg_sub_key_3).Trim();

                objF094_MSG_MSTR.MSG_REPRINT_FLAG = sub_name.Substring(0, 1);
                objF094_MSG_MSTR.MSG_AUTO_LOGOUT = sub_name.Substring(1, 1);
                objF094_MSG_MSTR.MSG_DTL1 = sub_name.Substring(2, sub_name.Trim().Length - 2).PadRight((23 - sub_name.Trim().Length - 2), ' ') + sub_fee_complex + sub_auto_logout;
                objF094_MSG_MSTR.RecordState = State.Modified;
                objF094_MSG_MSTR.Submit();

                F094_SUB_MSTR objF094_SUB_MSTR = new F094_SUB_MSTR
                {
                    WhereMsg_sub_key_12 = sub_indexer,
                    WhereMsg_sub_key_3 = msg_sub_key_3
                }.Collection().FirstOrDefault();

                objF094_SUB_MSTR.MSG_SUB_KEY_12 = sub_indexer;
                objF094_SUB_MSTR.MSG_SUB_KEY_3 = msg_sub_key_3;
                objF094_SUB_MSTR.SUB_NAME = sub_name;
                objF094_SUB_MSTR.SUB_FEE_COMPLEX = sub_fee_complex;
                objF094_SUB_MSTR.SUB_AUTO_LOGOUT = sub_auto_logout;

                objF094_SUB_MSTR.RecordState = State.Modified;
                objF094_SUB_MSTR.Submit();
            }

            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task Assign_Msg_Sub_Mstr_Rec_to_ScreenVariables()
        {
            try
            {
                msg_sub_key_1 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_12);

                switch (cur_line)
                {
                    case 5:
                        msg_sub_key_3 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 6:
                        msg_sub_key_3_2 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_2 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_2 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_2 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 7:
                        msg_sub_key_3_3 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_3 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_3 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_3 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 8:
                        msg_sub_key_3_4 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_4 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_4 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_4 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 9:
                        msg_sub_key_3_5 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_5 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_5 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_5 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 10:
                        msg_sub_key_3_6 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_6 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_6 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_6 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 11:
                        msg_sub_key_3_7 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_7 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_7 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_7 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 12:
                        msg_sub_key_3_8 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_8 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_8 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_8 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 13:
                        msg_sub_key_3_9 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_9 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_9 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_9 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 14:
                        msg_sub_key_3_10 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_10 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_10 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_10 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 15:
                        msg_sub_key_3_11 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_11 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_11 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_11 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 16:
                        msg_sub_key_3_12 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_12 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_12 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_12 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 17:
                        msg_sub_key_3_13 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_13 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_13 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_13 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 18:
                        msg_sub_key_3_14 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_14 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_14 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_14 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;

                    case 19:
                        msg_sub_key_3_15 = Util.Str(objMsg_sub_mstr_rec.MSG_SUB_KEY_3);
                        sub_fee_complex_15 = Util.Str(objMsg_sub_mstr_rec.SUB_FEE_COMPLEX);
                        sub_auto_logout_15 = Util.Str(objMsg_sub_mstr_rec.SUB_AUTO_LOGOUT);
                        sub_name_15 = Util.Str(objMsg_sub_mstr_rec.SUB_NAME);
                        break;
                }
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

