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
    public delegate void M040ExitCobolScreen();
    public class M040ViewModel : CommonFunctionScr
    {
        public M040ExitCobolScreen ExitCobol;
        public M040ViewModel()
        {          
        }

        #region FD Section
        // FD: audit_file
        private Audit_record objAudit_record = null;
        private ObservableCollection<Audit_record> Audit_record_Collection;

        // FD: oma_fee_mstr	Copy : f040_oma_fee_mstr.fd
        private F040_OMA_FEE_MSTR objFee_mstr_rec = null;
        private ObservableCollection<F040_OMA_FEE_MSTR> Fee_mstr_rec_Collection;

        private WriteFile objAuditFile = null;


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

        private string _audit_report_msg;
        public string audit_report_msg
        {
            get
            {
                return _audit_report_msg = "AUDIT REPORT IS IN FILENAME RM040";
            }
            set
            {
                if (_audit_report_msg != value)
                {
                    _audit_report_msg = value;
                    _audit_report_msg = _audit_report_msg.ToUpper();
                    RaisePropertyChanged("audit_report_msg");
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

        private int _ctr_fee_mstr_adds;
        public int ctr_fee_mstr_adds
        {
            get
            {
                return _ctr_fee_mstr_adds;
            }
            set
            {
                if (_ctr_fee_mstr_adds != value)
                {
                    _ctr_fee_mstr_adds = value;
                    RaisePropertyChanged("ctr_fee_mstr_adds");
                }
            }
        }

        private int _ctr_fee_mstr_changes;
        public int ctr_fee_mstr_changes
        {
            get
            {
                return _ctr_fee_mstr_changes;
            }
            set
            {
                if (_ctr_fee_mstr_changes != value)
                {
                    _ctr_fee_mstr_changes = value;
                    RaisePropertyChanged("ctr_fee_mstr_changes");
                }
            }
        }

        private int _ctr_fee_mstr_deletes;
        public int ctr_fee_mstr_deletes
        {
            get
            {
                return _ctr_fee_mstr_deletes;
            }
            set
            {
                if (_ctr_fee_mstr_deletes != value)
                {
                    _ctr_fee_mstr_deletes = value;
                    RaisePropertyChanged("ctr_fee_mstr_deletes");
                }
            }
        }

        private int _ctr_fee_mstr_reads;
        public int ctr_fee_mstr_reads
        {
            get
            {
                return _ctr_fee_mstr_reads;
            }
            set
            {
                if (_ctr_fee_mstr_reads != value)
                {
                    _ctr_fee_mstr_reads = value;
                    RaisePropertyChanged("ctr_fee_mstr_reads");
                }
            }
        }

        private int _ctr_fee_mstr_writes;
        public int ctr_fee_mstr_writes
        {
            get
            {
                return _ctr_fee_mstr_writes;
            }
            set
            {
                if (_ctr_fee_mstr_writes != value)
                {
                    _ctr_fee_mstr_writes = value;
                    RaisePropertyChanged("ctr_fee_mstr_writes");
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

        private string _fee_active_for_entry;
        public string fee_active_for_entry
        {
            get
            {
                return _fee_active_for_entry;
            }
            set
            {
                if (_fee_active_for_entry != value)
                {
                    _fee_active_for_entry = value;
                    _fee_active_for_entry = _fee_active_for_entry.ToUpper();
                    RaisePropertyChanged("fee_active_for_entry");
                }
            }
        }
      
        private string _fee_admit_ind;
        public string fee_admit_ind
        {
            get
            {
                return _fee_admit_ind;
            }
            set
            {
                if (_fee_admit_ind != value)
                {
                    _fee_admit_ind = value;
                    _fee_admit_ind = _fee_admit_ind.ToUpper();
                    RaisePropertyChanged("fee_admit_ind");
                }
            }
        }

        private int _fee_curr_a_anae;
        public int fee_curr_a_anae
        {
            get
            {
                return _fee_curr_a_anae;
            }
            set
            {
                if (_fee_curr_a_anae != value)
                {
                    _fee_curr_a_anae = value;
                    RaisePropertyChanged("fee_curr_a_anae");
                }
            }
        }

        private int _fee_curr_a_asst;
        public int fee_curr_a_asst
        {
            get
            {
                return _fee_curr_a_asst;
            }
            set
            {
                if (_fee_curr_a_asst != value)
                {
                    _fee_curr_a_asst = value;
                    RaisePropertyChanged("fee_curr_a_asst");
                }
            }
        }

        private decimal _fee_curr_a_fee_1;
        public decimal fee_curr_a_fee_1
        {
            get
            {
                return _fee_curr_a_fee_1;
            }
            set
            {
                if (_fee_curr_a_fee_1 != value)
                {
                    _fee_curr_a_fee_1 = value;
                    RaisePropertyChanged("fee_curr_a_fee_1");
                }
            }
        }

        private decimal _fee_curr_a_fee_2;
        public decimal fee_curr_a_fee_2
        {
            get
            {
                return _fee_curr_a_fee_2;
            }
            set
            {
                if (_fee_curr_a_fee_2 != value)
                {
                    _fee_curr_a_fee_2 = value;
                    RaisePropertyChanged("fee_curr_a_fee_2");
                }
            }
        }

        private string _fee_curr_add_on_perc_flat_ind;
        public string fee_curr_add_on_perc_flat_ind
        {
            get
            {
                return _fee_curr_add_on_perc_flat_ind;
            }
            set
            {
                if (_fee_curr_add_on_perc_flat_ind != value)
                {
                    _fee_curr_add_on_perc_flat_ind = value;
                    _fee_curr_add_on_perc_flat_ind = _fee_curr_add_on_perc_flat_ind.ToUpper();
                    RaisePropertyChanged("fee_curr_add_on_perc_flat_ind");
                }
            }
        }

        private int _fee_curr_h_anae;
        public int fee_curr_h_anae
        {
            get
            {
                return _fee_curr_h_anae;
            }
            set
            {
                if (_fee_curr_h_anae != value)
                {
                    _fee_curr_h_anae = value;
                    RaisePropertyChanged("fee_curr_h_anae");
                }
            }
        }

        private int _fee_curr_h_asst;
        public int fee_curr_h_asst
        {
            get
            {
                return _fee_curr_h_asst;
            }
            set
            {
                if (_fee_curr_h_asst != value)
                {
                    _fee_curr_h_asst = value;
                    RaisePropertyChanged("fee_curr_h_asst");
                }
            }
        }

        private decimal _fee_curr_h_fee_1;
        public decimal fee_curr_h_fee_1
        {
            get
            {
                return _fee_curr_h_fee_1;
            }
            set
            {
                if (_fee_curr_h_fee_1 != value)
                {
                    _fee_curr_h_fee_1 = value;
                    RaisePropertyChanged("fee_curr_h_fee_1");
                }
            }
        }

        private decimal _fee_curr_h_fee_2;
        public decimal fee_curr_h_fee_2
        {
            get
            {
                return _fee_curr_h_fee_2;
            }
            set
            {
                if (_fee_curr_h_fee_2 != value)
                {
                    _fee_curr_h_fee_2 = value;
                    RaisePropertyChanged("fee_curr_h_fee_2");
                }
            }
        }

        private decimal _fee_curr_h_max;
        public decimal fee_curr_h_max
        {
            get
            {
                return _fee_curr_h_max;
            }
            set
            {
                if (_fee_curr_h_max != value)
                {
                    _fee_curr_h_max = value;
                    RaisePropertyChanged("fee_curr_h_max");
                }
            }
        }

        private decimal _fee_curr_h_min;
        public decimal fee_curr_h_min
        {
            get
            {
                return _fee_curr_h_min;
            }
            set
            {
                if (_fee_curr_h_min != value)
                {
                    _fee_curr_h_min = value;
                    RaisePropertyChanged("fee_curr_h_min");
                }
            }
        }

        private string _fee_curr_page_alpha;
        public string fee_curr_page_alpha
        {
            get
            {
                return _fee_curr_page_alpha;
            }
            set
            {
                if (_fee_curr_page_alpha != value)
                {
                    _fee_curr_page_alpha = value;
                    _fee_curr_page_alpha = _fee_curr_page_alpha.ToUpper();
                    RaisePropertyChanged("fee_curr_page_alpha");
                }
            }
        }

        private int _fee_curr_page_numeric;
        public int fee_curr_page_numeric
        {
            get
            {
                return _fee_curr_page_numeric;
            }
            set
            {
                if (_fee_curr_page_numeric != value)
                {
                    _fee_curr_page_numeric = value;
                    RaisePropertyChanged("fee_curr_page_numeric");
                }
            }
        }

        private int _fee_date_dd;
        public int fee_date_dd
        {
            get
            {
                return _fee_date_dd;
            }
            set
            {
                if (_fee_date_dd != value)
                {
                    _fee_date_dd = value;
                    RaisePropertyChanged("fee_date_dd");
                }
            }
        }

        private int _fee_date_mm;
        public int fee_date_mm
        {
            get
            {
                return _fee_date_mm;
            }
            set
            {
                if (_fee_date_mm != value)
                {
                    _fee_date_mm = value;
                    RaisePropertyChanged("fee_date_mm");
                }
            }
        }

        private int _fee_date_yy;
        public int fee_date_yy
        {
            get
            {
                return _fee_date_yy;
            }
            set
            {
                if (_fee_date_yy != value)
                {
                    _fee_date_yy = value;
                    RaisePropertyChanged("fee_date_yy");
                }
            }
        }

        private string _fee_desc;
        public string fee_desc
        {
            get
            {
                return _fee_desc;
            }
            set
            {
                if (_fee_desc != value)
                {
                    _fee_desc = value;
                    _fee_desc = _fee_desc.ToUpper();
                    RaisePropertyChanged("fee_desc");
                }
            }
        }

        private string _fee_diag_ind;
        public string fee_diag_ind
        {
            get
            {
                return _fee_diag_ind;
            }
            set
            {
                if (_fee_diag_ind != value)
                {
                    _fee_diag_ind = value;
                    _fee_diag_ind = _fee_diag_ind.ToUpper();
                    RaisePropertyChanged("fee_diag_ind");
                }
            }
        }

        private string _fee_global_addon_cd_exclusion;
        public string fee_global_addon_cd_exclusion
        {
            get
            {
                return _fee_global_addon_cd_exclusion;
            }
            set
            {
                if (_fee_global_addon_cd_exclusion != value)
                {
                    _fee_global_addon_cd_exclusion = value;
                    _fee_global_addon_cd_exclusion = _fee_global_addon_cd_exclusion.ToUpper();
                    RaisePropertyChanged("fee_global_addon_cd_exclusion");
                }
            }
        }

        private string _fee_hosp_nbr_ind;
        public string fee_hosp_nbr_ind
        {
            get
            {
                return _fee_hosp_nbr_ind;
            }
            set
            {
                if (_fee_hosp_nbr_ind != value)
                {
                    _fee_hosp_nbr_ind = value;
                    _fee_hosp_nbr_ind = _fee_hosp_nbr_ind.ToUpper();
                    RaisePropertyChanged("fee_hosp_nbr_ind");
                }
            }
        }

        private string _fee_i_o_ind;
        public string fee_i_o_ind
        {
            get
            {
                return _fee_i_o_ind;
            }
            set
            {
                if (_fee_i_o_ind != value)
                {
                    _fee_i_o_ind = value;
                    _fee_i_o_ind = _fee_i_o_ind.ToUpper();
                    RaisePropertyChanged("fee_i_o_ind");
                }
            }
        }

        private string _fee_icc_code;
        public string fee_icc_code
        {
            get
            {
                return _fee_icc_code;
            }
            set
            {
                if (_fee_icc_code != value)
                {
                    _fee_icc_code = value;
                    _fee_icc_code = _fee_icc_code.ToUpper();
                    RaisePropertyChanged("fee_icc_code");
                }
            }
        }

        private string _fee_oma_cd;
        public string fee_oma_cd
        {
            get
            {
                return _fee_oma_cd;
            }
            set
            {
                if (_fee_oma_cd != value)
                {
                    _fee_oma_cd = value;
                    _fee_oma_cd = _fee_oma_cd.ToUpper();
                    RaisePropertyChanged("fee_oma_cd");
                }
            }
        }
      
        private string _fee_phy_ind;
        public string fee_phy_ind
        {
            get
            {
                return _fee_phy_ind;
            }
            set
            {
                if (_fee_phy_ind != value)
                {
                    _fee_phy_ind = value;
                    _fee_phy_ind = _fee_phy_ind.ToUpper();
                    RaisePropertyChanged("fee_phy_ind");
                }
            }
        }

        private int _fee_prev_a_anae;
        public int fee_prev_a_anae
        {
            get
            {
                return _fee_prev_a_anae;
            }
            set
            {
                if (_fee_prev_a_anae != value)
                {
                    _fee_prev_a_anae = value;
                    RaisePropertyChanged("fee_prev_a_anae");
                }
            }
        }

        private int _fee_prev_a_asst;
        public int fee_prev_a_asst
        {
            get
            {
                return _fee_prev_a_asst;
            }
            set
            {
                if (_fee_prev_a_asst != value)
                {
                    _fee_prev_a_asst = value;
                    RaisePropertyChanged("fee_prev_a_asst");
                }
            }
        }

        private decimal _fee_prev_a_fee_1;
        public decimal fee_prev_a_fee_1
        {
            get
            {
                return _fee_prev_a_fee_1;
            }
            set
            {
                if (_fee_prev_a_fee_1 != value)
                {
                    _fee_prev_a_fee_1 = value;
                    RaisePropertyChanged("fee_prev_a_fee_1");
                }
            }
        }

        private decimal _fee_prev_a_fee_2;
        public decimal fee_prev_a_fee_2
        {
            get
            {
                return _fee_prev_a_fee_2;
            }
            set
            {
                if (_fee_prev_a_fee_2 != value)
                {
                    _fee_prev_a_fee_2 = value;
                    RaisePropertyChanged("fee_prev_a_fee_2");
                }
            }
        }

        private string _fee_prev_add_on_perc_flat_ind;
        public string fee_prev_add_on_perc_flat_ind
        {
            get
            {
                return _fee_prev_add_on_perc_flat_ind;
            }
            set
            {
                if (_fee_prev_add_on_perc_flat_ind != value)
                {
                    _fee_prev_add_on_perc_flat_ind = value;
                    _fee_prev_add_on_perc_flat_ind = _fee_prev_add_on_perc_flat_ind.ToUpper();
                    RaisePropertyChanged("fee_prev_add_on_perc_flat_ind");
                }
            }
        }

        private int _fee_prev_h_anae;
        public int fee_prev_h_anae
        {
            get
            {
                return _fee_prev_h_anae;
            }
            set
            {
                if (_fee_prev_h_anae != value)
                {
                    _fee_prev_h_anae = value;
                    RaisePropertyChanged("fee_prev_h_anae");
                }
            }
        }

        private int _fee_prev_h_asst;
        public int fee_prev_h_asst
        {
            get
            {
                return _fee_prev_h_asst;
            }
            set
            {
                if (_fee_prev_h_asst != value)
                {
                    _fee_prev_h_asst = value;
                    RaisePropertyChanged("fee_prev_h_asst");
                }
            }
        }

        private decimal _fee_prev_h_fee_1;
        public decimal fee_prev_h_fee_1
        {
            get
            {
                return _fee_prev_h_fee_1;
            }
            set
            {
                if (_fee_prev_h_fee_1 != value)
                {
                    _fee_prev_h_fee_1 = value;
                    RaisePropertyChanged("fee_prev_h_fee_1");
                }
            }
        }

        private decimal _fee_prev_h_fee_2;
        public decimal fee_prev_h_fee_2
        {
            get
            {
                return _fee_prev_h_fee_2;
            }
            set
            {
                if (_fee_prev_h_fee_2 != value)
                {
                    _fee_prev_h_fee_2 = value;
                    RaisePropertyChanged("fee_prev_h_fee_2");
                }
            }
        }

        private decimal _fee_prev_h_max;
        public decimal fee_prev_h_max
        {
            get
            {
                return _fee_prev_h_max;
            }
            set
            {
                if (_fee_prev_h_max != value)
                {
                    _fee_prev_h_max = value;
                    RaisePropertyChanged("fee_prev_h_max");
                }
            }
        }

        private decimal _fee_prev_h_min;
        public decimal fee_prev_h_min
        {
            get
            {
                return _fee_prev_h_min;
            }
            set
            {
                if (_fee_prev_h_min != value)
                {
                    _fee_prev_h_min = value;
                    RaisePropertyChanged("fee_prev_h_min");
                }
            }
        }

        private string _fee_prev_page_alpha;
        public string fee_prev_page_alpha
        {
            get
            {
                return _fee_prev_page_alpha;
            }
            set
            {
                if (_fee_prev_page_alpha != value)
                {
                    _fee_prev_page_alpha = value;
                    _fee_prev_page_alpha = _fee_prev_page_alpha.ToUpper();
                    RaisePropertyChanged("fee_prev_page_alpha");
                }
            }
        }

        private int _fee_prev_page_numeric;
        public int fee_prev_page_numeric
        {
            get
            {
                return _fee_prev_page_numeric;
            }
            set
            {
                if (_fee_prev_page_numeric != value)
                {
                    _fee_prev_page_numeric = value;
                    RaisePropertyChanged("fee_prev_page_numeric");
                }
            }
        }

        private int _fee_spec_fr;
        public int fee_spec_fr
        {
            get
            {
                return _fee_spec_fr;
            }
            set
            {
                if (_fee_spec_fr != value)
                {
                    _fee_spec_fr = value;
                    RaisePropertyChanged("fee_spec_fr");
                }
            }
        }

        private int _fee_spec_to;
        public int fee_spec_to
        {
            get
            {
                return _fee_spec_to;
            }
            set
            {
                if (_fee_spec_to != value)
                {
                    _fee_spec_to = value;
                    RaisePropertyChanged("fee_spec_to");
                }
            }
        }

        private string _fee_special_m_suffix_ind;
        public string fee_special_m_suffix_ind
        {
            get
            {
                return _fee_special_m_suffix_ind;
            }
            set
            {
                if (_fee_special_m_suffix_ind != value)
                {
                    _fee_special_m_suffix_ind = value;
                    _fee_special_m_suffix_ind = _fee_special_m_suffix_ind.ToUpper();
                    RaisePropertyChanged("fee_special_m_suffix_ind");
                }
            }
        }

        private string _fee_tech_ind;
        public string fee_tech_ind
        {
            get
            {
                return _fee_tech_ind;
            }
            set
            {
                if (_fee_tech_ind != value)
                {
                    _fee_tech_ind = value;
                    _fee_tech_ind = _fee_tech_ind.ToUpper();
                    RaisePropertyChanged("fee_tech_ind");
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

        private string _fee_add_on_cd_1_1;
        public string fee_add_on_cd_1_1
        {
            get {
                return _fee_add_on_cd_1_1;
            }
            set
            {
                if (_fee_add_on_cd_1_1 != value)
                {
                    _fee_add_on_cd_1_1 = value;
                    _fee_add_on_cd_1_1 = _fee_add_on_cd_1_1.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_1");
                }
            }
        }

        private string _fee_add_on_cd_1_2;
        public string fee_add_on_cd_1_2
        {
            get
            {
                return _fee_add_on_cd_1_2;
            }
            set
            {
                if (_fee_add_on_cd_1_2 != value)
                {
                    _fee_add_on_cd_1_2 = value;
                    _fee_add_on_cd_1_2 = _fee_add_on_cd_1_2.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_2");
                }
            }
        }

        private string _fee_add_on_cd_1_3;
        public string fee_add_on_cd_1_3
        {
            get
            {
                return _fee_add_on_cd_1_3;
            }
            set
            {
                if (_fee_add_on_cd_1_3 != value)
                {
                    _fee_add_on_cd_1_3 = value;
                    _fee_add_on_cd_1_3 = _fee_add_on_cd_1_3.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_3");
                }
            }
        }

        private string _fee_add_on_cd_1_4;
        public string fee_add_on_cd_1_4
        {
            get
            {
                return _fee_add_on_cd_1_4;
            }
            set
            {
                if (_fee_add_on_cd_1_4 != value)
                {
                    _fee_add_on_cd_1_4 = value;
                    _fee_add_on_cd_1_4 = _fee_add_on_cd_1_4.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_4");
                }
            }
        }

        private string _fee_add_on_cd_1_5;
        public string fee_add_on_cd_1_5
        {
            get
            {
                return _fee_add_on_cd_1_5;
            }
            set
            {
                if (_fee_add_on_cd_1_5 != value)
                {
                    _fee_add_on_cd_1_5 = value;
                    _fee_add_on_cd_1_5 = _fee_add_on_cd_1_5.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_5");
                }
            }
        }

        private string _fee_add_on_cd_1_6;
        public string fee_add_on_cd_1_6
        {
            get
            {
                return _fee_add_on_cd_1_6;
            }
            set
            {
                if (_fee_add_on_cd_1_6 != value)
                {
                    _fee_add_on_cd_1_6 = value;
                    _fee_add_on_cd_1_6 = _fee_add_on_cd_1_6.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_6");
                }
            }
        }

        private string _fee_add_on_cd_1_7;
        public string fee_add_on_cd_1_7
        {
            get
            {
                return _fee_add_on_cd_1_7;
            }
            set
            {
                if (_fee_add_on_cd_1_7 != value)
                {
                    _fee_add_on_cd_1_7 = value;
                    _fee_add_on_cd_1_7 = _fee_add_on_cd_1_7.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_7");
                }
            }
        }

        private string _fee_add_on_cd_1_8;
        public string fee_add_on_cd_1_8
        {
            get
            {
                return _fee_add_on_cd_1_8;
            }
            set
            {
                if (_fee_add_on_cd_1_8 != value)
                {
                    _fee_add_on_cd_1_8 = value;
                    _fee_add_on_cd_1_8 = _fee_add_on_cd_1_8.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_8");
                }
            }
        }

        private string _fee_add_on_cd_1_9;
        public string fee_add_on_cd_1_9
        {
            get
            {
                return _fee_add_on_cd_1_9;
            }
            set
            {
                if (_fee_add_on_cd_1_9 != value)
                {
                    _fee_add_on_cd_1_9 = value;
                    _fee_add_on_cd_1_9 = _fee_add_on_cd_1_9.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_9");
                }
            }
        }

        private string _fee_add_on_cd_1_10;
        public string fee_add_on_cd_1_10
        {
            get
            {
                return _fee_add_on_cd_1_10;
            }
            set
            {
                if (_fee_add_on_cd_1_10 != value)
                {
                    _fee_add_on_cd_1_10 = value;
                    _fee_add_on_cd_1_10 = _fee_add_on_cd_1_10.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_1_10");
                }
            }
        }

        private string _fee_add_on_cd_2_1;
        public string fee_add_on_cd_2_1
        {
            get
            {
                return _fee_add_on_cd_2_1;
            }
            set
            {
                if (_fee_add_on_cd_2_1 != value)
                {
                    _fee_add_on_cd_2_1 = value;
                    _fee_add_on_cd_2_1 = _fee_add_on_cd_2_1.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_1");
                }
            }
        }

        private string _fee_add_on_cd_2_2;
        public string fee_add_on_cd_2_2
        {
            get
            {
                return _fee_add_on_cd_2_2;
            }
            set
            {
                if (_fee_add_on_cd_2_2 != value)
                {
                    _fee_add_on_cd_2_2 = value;
                    _fee_add_on_cd_2_2 = _fee_add_on_cd_2_2.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_2");
                }
            }
        }

        private string _fee_add_on_cd_2_3;
        public string fee_add_on_cd_2_3
        {
            get
            {
                return _fee_add_on_cd_2_3;
            }
            set
            {
                if (_fee_add_on_cd_2_3 != value)
                {
                    _fee_add_on_cd_2_3 = value;
                    _fee_add_on_cd_2_3 = _fee_add_on_cd_2_3.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_3");
                }
            }
        }

        private string _fee_add_on_cd_2_4;
        public string fee_add_on_cd_2_4
        {
            get
            {
                return _fee_add_on_cd_2_4;
            }
            set
            {
                if (_fee_add_on_cd_2_4 != value)
                {
                    _fee_add_on_cd_2_4 = value;
                    _fee_add_on_cd_2_4 = _fee_add_on_cd_2_4.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_4");
                }
            }
        }

        private string _fee_add_on_cd_2_5;
        public string fee_add_on_cd_2_5
        {
            get
            {
                return _fee_add_on_cd_2_5;
            }
            set
            {
                if (_fee_add_on_cd_2_5 != value)
                {
                    _fee_add_on_cd_2_5 = value;
                    _fee_add_on_cd_2_5 = _fee_add_on_cd_2_5.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_5");
                }
            }
        }

        private string _fee_add_on_cd_2_6;
        public string fee_add_on_cd_2_6
        {
            get
            {
                return _fee_add_on_cd_2_6;
            }
            set
            {
                if (_fee_add_on_cd_2_6 != value)
                {
                    _fee_add_on_cd_2_6 = value;
                    _fee_add_on_cd_2_6 = _fee_add_on_cd_2_6.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_6");
                }
            }
        }

        private string _fee_add_on_cd_2_7;
        public string fee_add_on_cd_2_7
        {
            get
            {
                return _fee_add_on_cd_2_7;
            }
            set
            {
                if (_fee_add_on_cd_2_7 != value)
                {
                    _fee_add_on_cd_2_7 = value;
                    _fee_add_on_cd_2_7 = _fee_add_on_cd_2_7.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_7");
                }
            }
        }

        private string _fee_add_on_cd_2_8;
        public string fee_add_on_cd_2_8
        {
            get
            {
                return _fee_add_on_cd_2_8;
            }
            set
            {
                if (_fee_add_on_cd_2_8 != value)
                {
                    _fee_add_on_cd_2_8 = value;
                    _fee_add_on_cd_2_8 = _fee_add_on_cd_2_8.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_8");
                }
            }
        }

        private string _fee_add_on_cd_2_9;
        public string fee_add_on_cd_2_9
        {
            get
            {
                return _fee_add_on_cd_2_9;
            }
            set
            {
                if (_fee_add_on_cd_2_9 != value)
                {
                    _fee_add_on_cd_2_9 = value;
                    _fee_add_on_cd_2_9 = _fee_add_on_cd_2_9.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_9");
                }
            }
        }

        private string _fee_add_on_cd_2_10;
        public string fee_add_on_cd_2_10
        {
            get
            {
                return _fee_add_on_cd_2_10;
            }
            set
            {
                if (_fee_add_on_cd_2_10 != value)
                {
                    _fee_add_on_cd_2_10 = value;
                    _fee_add_on_cd_2_10 = _fee_add_on_cd_2_10.ToUpper();
                    RaisePropertyChanged("fee_add_on_cd_2_10");
                }
            }
        }

        private string _fee_oma_ind_card_required_1_1;
        public string fee_oma_ind_card_required_1_1
        {
            get
            {
                return _fee_oma_ind_card_required_1_1;
            }
            set
            {
                if (_fee_oma_ind_card_required_1_1 != value)
                {
                    _fee_oma_ind_card_required_1_1 = value;
                    _fee_oma_ind_card_required_1_1 = _fee_oma_ind_card_required_1_1.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_1_1");
                }
            }
        }

        private string _fee_oma_ind_card_required_1_2;
        public string fee_oma_ind_card_required_1_2
        {
            get
            {
                return _fee_oma_ind_card_required_1_2;
            }
            set
            {
                if (_fee_oma_ind_card_required_1_2 != value)
                {
                    _fee_oma_ind_card_required_1_2 = value;
                    _fee_oma_ind_card_required_1_2 = _fee_oma_ind_card_required_1_2.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_1_2");
                }
            }
        }

        private string _fee_oma_ind_card_required_1_3;
        public string fee_oma_ind_card_required_1_3
        {
            get
            {
                return _fee_oma_ind_card_required_1_3;
            }
            set
            {
                if (_fee_oma_ind_card_required_1_3 != value)
                {
                    _fee_oma_ind_card_required_1_3 = value;
                    _fee_oma_ind_card_required_1_3 = _fee_oma_ind_card_required_1_3.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_1_3");
                }
            }
        }


        private string _fee_oma_ind_card_required_2_1;
        public string fee_oma_ind_card_required_2_1
        {
            get
            {
                return _fee_oma_ind_card_required_2_1;
            }
            set
            {
                if (_fee_oma_ind_card_required_2_1 != value)
                {
                    _fee_oma_ind_card_required_2_1 = value;
                    _fee_oma_ind_card_required_2_1 = _fee_oma_ind_card_required_2_1.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_2_1");
                }
            }
        }

        private string _fee_oma_ind_card_required_2_2;
        public string fee_oma_ind_card_required_2_2
        {
            get
            {
                return _fee_oma_ind_card_required_2_2;
            }
            set
            {
                if (_fee_oma_ind_card_required_2_2 != value)
                {
                    _fee_oma_ind_card_required_2_2 = value;
                    _fee_oma_ind_card_required_2_2 = _fee_oma_ind_card_required_2_2.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_2_2");
                }
            }
        }

        private string _fee_oma_ind_card_required_2_3;
        public string fee_oma_ind_card_required_2_3
        {
            get
            {
                return _fee_oma_ind_card_required_2_3;
            }
            set
            {
                if (_fee_oma_ind_card_required_2_3 != value)
                {
                    _fee_oma_ind_card_required_2_3 = value;
                    _fee_oma_ind_card_required_2_3 = _fee_oma_ind_card_required_2_3.ToUpper();
                    RaisePropertyChanged("fee_oma_ind_card_required_2_3");
                }
            }
        }


        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "rm040";
        //private string audit_report_msg = "AUDIT REPORT IS IN FILENAME RM040";
        private string ws_hold_perc_or_flat_ind;
        //private string ws_entered_password = "";
        private string ws_valid_password = "RMAPR";
        private string eof_oma_mstr = "N";
        //private string status_file;
        private string status_cobol_oma_mstr = "0";
        private string status_audit_rpt = "0";
        //private string entry_type;
        private string add_code = "A";
        private string change_code = "C";
        private string delete_code = "D";
        private string inquire_code = "I";
        private string terminate_code = "*";
        private int pc_year;
        private int cntr = 0;
        private int cnum = 0;
        private int lnum = 0;
        //private string confirm_space = space;
        private string flag_mode;
        private string display_mode = "D";
        private string update_mode = "U";
        private string read_flag;
        private string on_file = "Y";
        private string not_on_file = "N";
        private string status_flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string password_flag;
        private string password_ok = "Y";
        private string password_not_ok = "N";
        private string display_type;
        private string gen_title = "GEN";
        private string tec_title = "TEC";
        //private string acc_mod_rej;
        private string accept_screen = "Y";
        private string prev_yr_modify = "P";
        private string modify_screen = "M";
        private string reject_screen = "N";

        private string counters_grp;
        //private int ctr_fee_mstr_reads;
        //private int ctr_fee_mstr_writes;
        //private int ctr_fee_mstr_adds;
        //private int ctr_fee_mstr_changes;
        //private int ctr_fee_mstr_deletes;
        private string feedback_oma_fee_mstr;

        private string error_message_table_grp;
        private string error_messages_grp;
        private string[] err_msg = {"", "invalid reply",
                                   "OMA CODE ALREADY EXISTS",
                                   "ASSOCIATE NBR NOT ON OMA MASTER",
                                   "PAGE MUST BE BETWEEN 1 AND 199 INCLUSIVE",
                                   "M SUFFIX MUST BE 'Y' OR 'N'",
                                   "WARNING ONLY-ZERO FEE",
                                   "ERROR MESSAGE #7 GOES HERE",
                                   "RECORD DOESN'T EXIST",
                                   "INVALID CODE--TYPE MUST BE 'CV,NM,DR,CP,PF,DU,DT,SP'",
                                   "DIAGNOSTIC IND MUST BE 'Y' OR 'N'",
                                   "REF/PHYSICIAN IND MUST BE 'Y' OR 'N'",
                                   "HOSP # IND MUST BE 'Y' OR 'N'",
                                   "IN/OUT IND MUST BE 'I' 'O' OR 'B'",
                                   "ADMIT/DT IND MUST BE 'Y' OR 'N'",
                                   "REDUC-WITH MUST BE 'DT,SP' AND NOT 99 IN NBRS 2 & 3",
                                   "BILATERAL MUST BE 'BI' OR BLANK",
                                   "Must be BLANK or if ADD-ON must be 'P'ercent or 'F'lat",
                                   "PASSWORD NOT ACCEPTABLE",
                                   "GEN. MUST BE < 1.01 AND SPEC. MUST BE > 1.00",
                                   "Value must be 'Y'es or 'N'o",
                                   "'Y','N' OR 'R' SUFFIX REQUIRED",
                                   "THE LAST 4 DIGITS OF ICC-CODE MUST BE NUMERIC"};
        private string error_messages_r_grp;
        //private string[] err_msg = new string[23];
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

        private string fee_mstr_rec_grp;
        private string fee_oma_cd_grp;
        private string fee_oma_cd_ltr1;
        //10  filler pic 999.
        //private string fee_special_m_suffix_ind;
        private string fee_effective_date_grp;
        //private int fee_date_yy;
        //private int fee_date_mm;
        //private int fee_date_dd;
        //private string fee_active_for_entry;

        //private string fee_desc;
        private string fee_current_prev_years_grp;
        //private decimal fee_curr_a_fee_1;
        //private decimal fee_curr_h_fee_1;
        //private decimal fee_curr_a_fee_2;
        //private decimal fee_curr_h_fee_2;
        private decimal fee_curr_a_min;
        //private decimal fee_curr_h_min;
        private decimal fee_curr_a_max;
        //private decimal fee_curr_h_max;

        //private int fee_curr_a_anae;
        //private int fee_curr_h_anae;
        //private int fee_curr_a_asst;
        //private int fee_curr_h_asst;

        private string fee_curr_add_on_codes_grp;
        private string[] fee_curr_add_on_cd = new string[11];
        private string fee_curr_oma_ind_card_reqs_grp;
        private string[] fee_curr_oma_ind_card_required = new string[4];

        private string  fee_curr_page_grp;
        //private string fee_curr_page_alpha;
        //private int fee_curr_page_numeric;

        //private string fee_curr_add_on_perc_flat_ind;
        //private decimal fee_prev_a_fee_1;
        //private decimal fee_prev_h_fee_1;
        //private decimal fee_prev_a_fee_2;
        //private decimal fee_prev_h_fee_2;
        private decimal fee_prev_a_min;
        //private decimal fee_prev_h_min;
        private decimal fee_prev_a_max;
        //private decimal fee_prev_h_max;
        //private int fee_prev_a_anae;
        //private int fee_prev_h_anae;
        //private int fee_prev_a_asst;
        //private int fee_prev_h_asst;

        private string fee_prev_add_on_codes_grp;
        private string[] fee_prev_add_on_cd = new string[11];
        private string fee_prev_oma_ind_card_reqs_grp;
        private string[] fee_prev_oma_ind_card_required = new string[4];

        private string fee_prev_page_grp;
        //private string fee_prev_page_alpha;
        //private int fee_prev_page_numeric;
        //private string fee_prev_add_on_perc_flat_ind;

        private string fee_current_prev_year_r;
        private string[,] fee_years = new string[3,3];
        private decimal[,] fee_1 = new decimal[3,3];
        private decimal[,] fee_2 = new decimal[3,3];
        private decimal[,] fee_min = new decimal[3,3];
        private decimal[,] fee_max = new decimal[3,3];
        private int[,] fee_anae = new int[3,3];
        private int[,] fee_asst = new int[3,3];
        private string fee_add_on_codes_grp;
        private string[,] fee_add_on_cd = new string[3,11];
        private string fee_oma_ind_card_requireds_grp;
        private string[,] fee_oma_ind_card_required = new string[3,4];

        private string fee_page_alpha_numeric_grp;
        private string fee_page_alpha;
        private int fee_page;
        private string fee_add_on_perc_or_flat_ind;

        private string fee_icc_code_grp;
        private string fee_icc_sec;
        private int fee_icc_cat;
        private int fee_icc_grp;
        private int fee_icc_reduc_ind;

        //private string fee_diag_ind;
        //private string fee_phy_ind;
        //private string fee_tech_ind;
        //private string fee_hosp_nbr_ind;
        //private string fee_i_o_ind;
        //private string fee_admit_ind;
        //private int fee_spec_fr;
        //private int fee_spec_to;
        //private string fee_global_addon_cd_exclusion;


        #endregion

        #region Screen Section
        public ObservableCollection<ScreenData> ScreenSection()
        {
            ObservableCollection<ScreenData> ScreenDataCollection = new ObservableCollection<ScreenData>
        {
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 1,Data1 = "M040",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 17,Data1 = "FEE MASTER MAINTENANCE",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-titles-heading"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "01",Col = 71,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "03",Col = 1,Data1 = "ICC Code:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "03",Col = 23,Data1 = "Description:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "04",Col = 1,Data1 = "Technical:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "04",Col = 23,Data1 = "Effective  :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "04",Col = 50,Data1 = "Active for data entry?      :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "05",Col = 50,Data1 = "EXCLUDE from Global Add-on's:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "06",Col = 1,Data1 = "-------------OHIP-------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "06",Col = 51,Data1 = "--------------OMA-------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "07",Col = 33,Data1 = " Min.        Max.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "07",Col = 20,Data1 = "Anae",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "07",Col = 25,Data1 = "Asst",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "07",Col = 72,Data1 = "Anae",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "07",Col = 77,Data1 = "Asst",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "12",Col = 23,Data1 = "* Additional Claim Related Data *",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 1,Data1 = "Page:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 8,Data1 = "-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 12,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 15,Data1 = "-",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 20,Data1 = "'M' Suffix Allowed:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 42,Data1 = "Diagnostic:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "14",Col = 56,Data1 = "Ref/Physician:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "16",Col = 1,Data1 = "Hospital Nbr:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "16",Col = 17,Data1 = "In/Out:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "16",Col = 27,Data1 = "Admit/Dt:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "17",Col = 63,Data1 = "--Card Required--",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "18",Col = 1,Data1 = "--------------- ADD ON Codes -------------------",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "18",Col = 60,Data1 = "Suffix 'A' 'B' 'C'",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "19",Col = 51,Data1 = ".. CURRENT .......",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "20",Col = 51,Data1 = ".. PREVIOUS ......",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "22",Col = 1,Data1 = "ADD ON PERCENTAGE/FLAT RATE:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "22",Col = 26,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "22",Col = 35,Data1 = "Spec:from ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-titles.",Line = "22",Col = 48,Data1 = "to ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-general-title.",Line = "07",Col = 1,Data1 = " GENERAL ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-general-title.",Line = "07",Col = 11,Data1 = " SPECIAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-general-title.",Line = "07",Col = 52,Data1 = " GENERAL ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-general-title.",Line = "07",Col = 62,Data1 = " SPECIAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-technical-title.",Line = "07",Col = 1,Data1 = "TECHNICAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-technical-title.",Line = "07",Col = 11,Data1 = "PROFESS.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-technical-title.",Line = "07",Col = 52,Data1 = "TECHNICAL",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-technical-title.",Line = "07",Col = 62,Data1 = "PROFESS.",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option.",Line = "01",Col = 37,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "entry_type",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option-sel"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option.",Line = "01",Col = 39,Data1 = "(ADD/CHANGE/DELETE/INQUIRY)",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-option-add-change-delete-inq"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-lit-title",Line = "01",Col = 17,Data1 = "             FEE MASTER MAINTENANCE - ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-lit.",Line = "1",Col = 47,Data1 = "ADD             ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-add"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-lit.",Line = "1",Col = 47,Data1 = "CHANGE          ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-chg"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-lit.",Line = "1",Col = 47,Data1 = "DELETE          ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-del"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-option-lit.",Line = "1",Col = 47,Data1 = "INQUIRY         ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-option-inq"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-code.",Line = "01",Col = 8,Data1 = "Oma Code:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-code.",Line = "01",Col = 15,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = true,InputVariableName = "fee_oma_cd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-code-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "03",Col = 10,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx9999",MaxLength = 6,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_icc_code",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-icc-code"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "03",Col = 33,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x(48)",MaxLength = 48,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_desc",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-desc"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 10,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_tech_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-tech-ind"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 33,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "9999",MaxLength = 4,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_date_yy",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-eff-yy"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 37,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-eff-slash-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 38,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_date_mm",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-eff-mm"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 40,Data1 = "/",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "05",GroupNameLevel2 = "scr-eff-slash-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 41,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_date_dd",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-eff-dd"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "04",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_active_for_entry",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-active-flag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-icc-desc-tech.",Line = "05",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_global_addon_cd_exclusion",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-exclude-global-addon"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-confirm",Line = "24",Col = 1,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "confirm_space",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "14",Col = 6,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_curr_page_alpha",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-page-alpha"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "14",Col = 9,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_page_numeric",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-page-numeric"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "14",Col = 35,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_special_m_suffix_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-m-suffix"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "14",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_diag_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-diag"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "14",Col = 67,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_phy_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-ref-phys"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "16",Col = 12,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_hosp_nbr_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-hosp-nbr"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "16",Col = 22,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_i_o_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-in-out"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-info.",Line = "16",Col = 34,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_admit_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-admit-dt"},

         // the same variablename 
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-1"},
         
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-oth"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_fee_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 21,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_anae",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-anae"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 26,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_asst",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-asst"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 29,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-min"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_h_max",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-h-max"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_a_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-a-1"},

         // the same variablename 
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_a_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-a-oth"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_a_fee_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-a-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 73,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_a_anae",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-a-anae"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "09",Col = 78,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_curr_a_asst",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-a-asst"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-h-1"},

         // the same variable
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-h-oth"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_fee_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-h-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_anae",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-h-anae"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_asst",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-h-asst"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 29,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-h-min"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 42,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_h_max",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-h-max"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 51,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_a_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-a-1"},

         // the same variables
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_a_fee_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-a-oth"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 62,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(5)9.999",MaxLength = 9,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_a_fee_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-a-2"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 73,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_a_anae",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-a-anae"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-rate-info.",Line = "10",Col = 78,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_a_asst",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-a-prev-a-asst"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-contd.",Line = "22",Col = 24,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_curr_add_on_perc_flat_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-curr-perc-flat"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-contd.",Line = "22",Col = 45,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_spec_fr",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-from"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-other-contd.",Line = "22",Col = 51,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "z9",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_spec_to",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-to"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-prev-misc.",Line = "22",Col = 27,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_prev_add_on_perc_flat_ind",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-perc-flat"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-prev-misc.",Line = "14",Col = 13,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "xx",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_prev_page_alpha",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-page-alpha"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-prev-misc.",Line = "14",Col = 16,Data1 = "",RowStatus = rowStatus.InputAutoTab,NumericFormat = "999",MaxLength = 3,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "fee_prev_page_numeric",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-prev-page-numeric"},

          // fee_add_on_cd[pc_year,cntr]         
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-1"},  //curr
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-2"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-3"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-4"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-5"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-6"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-7"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-8"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-9"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "19",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_1_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-1-10"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 1,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-1"},  // prev
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 6,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-2"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-3"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 16,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_4",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-4"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 21,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_5",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-5"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 26,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_6",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-6"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 31,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_7",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-7"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 36,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_8",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-8"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 41,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_9",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-9"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-add-on.",Line = "20",Col = 46,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x999",MaxLength = 4,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_add_on_cd_2_10",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-add-on-cd-2-10"}, 
         

         // fee_oma_ind_card_required[pc_year,cntr]        
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "19",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_1_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-1-1"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "19",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_1_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-1-2"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "19",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_1_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-1-3"},
         

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "20",Col = 66,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_2_1",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-2-1"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "20",Col = 69,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_2_2",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-2-2"},
         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-suffixes.",Line = "20",Col = 72,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "fee_oma_ind_card_required_2_3",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-suffix-2-3"},
         

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 56,Data1 = "FILE STATUS = ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "file-status-display.",Line = "24",Col = 70,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(2)",MaxLength = 2,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "status_file",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 2,Data1 = " ERROR -  ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "err-msg-line.",Line = "24",Col = 11,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(55)",MaxLength = 55,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "err_msg_comment",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "confirm.",Line = "23",Col = 1,Data1 = " ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

        // new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rate-lines.",Line = "09",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rate-lines.",Line = "09",Col = 38,Data1 = "CURR",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},        

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rate-lines.",Line = "10",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-rate-lines.",Line = "10",Col = 38,Data1 = "PREV",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-line-24.",Line = "24",Col = 1,Data1 = "blank line",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "blank-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-clear-option.",Line = "23",Col = 50,Data1 = "                            ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "23",Col = 50,Data1 = "ACCEPT(Y/N/M): ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-add-change.",Line = "23",Col = 65,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-verify-add-change-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 66,Data1 = "PASSWORD",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-password-prompt.",Line = "24",Col = 75,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(5)",MaxLength = 5,RowDataType = rowDataType.AlphaNumericPassword,IsRequired = false,InputVariableName = "ws_entered_password",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-password"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-del.",Line = "23",Col = 50,Data1 = "DELETE (Y/N): ",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-del.",Line = "23",Col = 64,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-verify-del-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-continue.",Line = "23",Col = 50,Data1 = "Hit ENTER to Continue",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-verify-continue.",Line = "23",Col = 67,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x",MaxLength = 1,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "acc_mod_rej",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = "scr-verify-continue-1"},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-reject-entry.",Line = "24",Col = 50,Data1 = "ENTRY IS REJECTED",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "1",Col = 1,Data1 = "blank screen",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 20,Data1 = "NUMBER OF FEE-MSTR READS:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "05",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_fee_mstr_reads",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 20,Data1 = "NUMBER OF FEE-MSTR WRITES:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "06",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_fee_mstr_writes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 20,Data1 = "NUMBER OF CODES ADDED  :",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "08",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_fee_mstr_adds",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 20,Data1 = "                CHANGED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "10",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_fee_mstr_changes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 20,Data1 = "                DELETED:",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "12",Col = 60,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "z(6)9",MaxLength = 69,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "ctr_fee_mstr_deletes",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 20,Data1 = "PROGRAM M040 ENDING",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 40,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "xxxx/xx/xx",MaxLength = 10,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "sys_date_long",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 50,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_hrs",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 52,Data1 = ":",RowStatus = rowStatus.Display,NumericFormat = "",MaxLength = 0,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "20",Col = 53,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "99",MaxLength = 2,RowDataType = rowDataType.Numeric,IsRequired = false,InputVariableName = "sys_min",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""},

         new ScreenData {GroupNumberLevel1 = "01",GroupNameLevel1 = "scr-closing-screen.",Line = "22",Col = 20,Data1 = "",RowStatus = rowStatus.Input,NumericFormat = "x(40)",MaxLength = 40,RowDataType = rowDataType.AlphaNumeric,IsRequired = false,InputVariableName = "audit_report_msg",RowClassType = rowClassType.Simple,GroupNumberLevel2 = "",GroupNameLevel2 = ""}

        };
            return ScreenDataCollection;
        }

        #endregion

        #region Procedure Divsion
        private async Task declaratives()
        {

        }

        private async Task err_oma_mstr_file_section()
        {

            //     use after standard error procedure on oma-fee-mstr.;
        }

        private async Task err_oma_fee_mstr()
        {

            status_file = status_cobol_oma_mstr;
            //     display file-status-display.;
            //     stop "ERROR IN ACCESSING OMA FEE MASTER".;
            //     stop run.;
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
        }

        private async Task end_declaratives()
        {

        }

        private async Task main_line_section()
        {

        }

        private async Task initialize_objects()
        {
            objAudit_record = new Audit_record();
            objAuditFile = new WriteFile(Directory.GetCurrentDirectory() + "\\" + print_file_name);

            objFee_mstr_rec = new F040_OMA_FEE_MSTR();
            Fee_mstr_rec_Collection = new ObservableCollection<F040_OMA_FEE_MSTR>();
        }

        public async Task mainline()
        {
            try {

                await initialize_objects();
                //     perform aa0-initialization		thru aa0-99-exit.;
                await aa0_initialization();
                await aa0_99_exit();

                //     perform ab0-processing		thru ab0-99-exit.;
 _ab0_processing:
               string retval =   await ab0_processing();
                if (retval.ToLower().Equals("ab0_99_exit"))
                {
                    goto _ab0_99_exit;
                }
                else if (retval.ToLower().Equals("ab0_processing"))
                {
                    goto _ab0_processing;
                }

 _ab0_150_acpt_code_display_info:
                retval =  await ab0_150_acpt_code_display_info();
                if (retval.ToLower().Equals("ab0_processing"))
                {
                    goto _ab0_processing;
                }

 _ab0_200_modify:
               await ab0_200_modify();

                retval =  await ab0_300_verify();
                if (retval.ToLower().Equals("ab0_200_modify"))
                {
                    goto _ab0_200_modify;
                }                

                retval = await ab0_400_next();
                if (retval.ToLower().Equals("ab0_150_acpt_code_display_info"))
                {
                    goto _ab0_150_acpt_code_display_info;
                }

_ab0_99_exit:
                await ab0_99_exit();

                //  perform az0-end-of-job		thru az0-99-exit.;
                await az0_end_of_job();
                await az0_99_exit();
                //     stop run.;

            } catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    err_msg_comment = " Runtime error : " + e.Message.ToString();
                    Display("err-msg-line.");
                }
            }
            finally {
                objAuditFile.CloseOutputFile();
                objAuditFile = null;

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

            sys_date_long = Util.Str(sys_yy).PadLeft(4, '0') + "/" + Util.Str(sys_mm).PadLeft(2, '0') + "/" + Util.Str(sys_dd).PadLeft(2, '0');

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open i-o	oma-fee-mstr.;
            //     open output audit-file.;
        }

        private async Task aa0_99_exit()
        {
            //     exit.;
        }

        private async Task az0_end_of_job()
        {

            //     display blank-screen.;
            //Display("blank-screen.");

            //     display scr-closing-screen.;
            //Display("scr-closing-screen.");

            //     display confirm.;
            //Display("confirm.");

            //     close oma-fee-mstr;
            // 	  audit-file.;
            //     call program "menu".;
            //     stop run.;
        }

        private async Task az0_99_exit()
        {

            //     exit.;
        }

        private async Task<string> ab0_processing()
        {

            //     display scr-titles.;
            Display("scr-titles.");
            //     display scr-general-title.;
            Display("scr-general-title.");
            Display("scr-technical-title.", false);

            display_type = "GEN";
            entry_type = "";

            //     display scr-option.;
            Display("scr-option.");

            //objFee_mstr_rec.fee_mstr_rec = "";
            objFee_mstr_rec = new F040_OMA_FEE_MSTR();

            //     accept scr-option-sel.;
            Display("scr-option.", "scr-option-sel");
            await Prompt("entry_type");

            Display("scr-option.", false);
            Display("scr-titles.", "scr-titles-heading",false);
            Display("scr-option.", "scr-option-add-change-delete-inq", false);

            //     display scr-option-lit-title.;
            Display("scr-option-lit-title");

            //  if add-code then 
            if (entry_type.Equals(add_code)) {
                // 	    display scr-option-add;                
                Display("scr-option-lit.", "scr-option-add");
            }
            //  else if change-code then
            else if (entry_type.Equals(change_code) ) {
                // 	    display scr-option-chg;                
                Display("scr-option-lit.", "scr-option-chg");
            }
            // 	else if delete-code then            
            else if (entry_type.Equals(delete_code) ) {
                // 		display scr-option-del;                
                Display("scr-option-lit.", "scr-option-del");
            }
            // 	else if inquire-code then            
            else if (entry_type.Equals(inquire_code) ) {
                // 		    display scr-option-inq;                
                Display("scr-option-lit.", "scr-option-inq");
            }
            // 	else if terminate-code then            
            else if (entry_type.Equals(terminate_code) ) {
                // 			go to ab0-99-exit;                
                return "ab0_99_exit";
            }
            else {
                         err_ind = 1;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 		go to ab0-processing.;                
                return "ab0_processing";
            }

            //     display scr-code.;
            Display("scr-code.");
            return string.Empty;
        }

        private async Task<string> ab0_150_acpt_code_display_info()
        {

            //objFee_mstr_rec.fee_mstr_rec = "";
            fee_oma_cd = string.Empty;

            //     accept scr-code-nbr.;
            Display("scr-code.", "scr-code-nbr");
            await Prompt("fee_oma_cd");

            await Initialize_OmaFee_Mstr_Record_ScreenVariables();

            fee_oma_cd_ltr1 = Util.Str(fee_oma_cd).PadRight(4).Substring(0, 1);            
            // if fee-oma-cd-ltr1 = "*" then          
            if (Util.Str(fee_oma_cd_ltr1) == "*" ) {
                //   	go to ab0-processing.;                
                return "ab0_processing";
            }

            //     perform ba0-read-fee-mstr			thru	ba0-99-exit.;
            await ba0_read_fee_mstr();
            await ba0_99_exit();

            //  if not-ok then      
            if (status_flag.Equals(not_ok) ) {
                // 	   go to ab0-150-acpt-code-display-info.;                
                await ab0_150_acpt_code_display_info();
                return string.Empty;                
            }

            //  display scr-icc-desc-tech.;
            Display("scr-icc-desc-tech.");

            //   perform fa0-display-rates		thru	fa0-99-exit.;
            await fa0_display_rates();
            //await display_scr_a_prev_a_asst();
            await fa0_99_exit();

            //  display scr-other-info.;
            Display("scr-other-info.");

            //  perform ga0-display-add-ons		thru 	ga0-99-exit;
            // 	varying pc-year from 1 by 1 until pc-year > 2.;

            pc_year = 1;
            do
            {
                await ga0_display_add_ons();
                await ga0_99_exit();
                pc_year++;
            } while (pc_year <= 2);

            //  perform ia0-display-suffixes	thru 	ia0-99-exit;
            // 	  varying pc-year from 1 by 1 until pc-year > 2.;

            pc_year = 1;
            do
            {
               await ia0_display_suffixes();
               await ia0_99_exit();
                pc_year++;
            } while (pc_year <= 2);

            //     display scr-other-contd.;
            Display("scr-other-contd.");

            //     display scr-prev-misc.;
            Display("scr-prev-misc.");

            return string.Empty;
        }

        private async Task<string> ab0_200_modify()
        {

            //  if add-code  or change-code then
            if (entry_type.Equals(add_code) || entry_type.Equals(change_code) ) {
                // 	   perform da0-enter-icc-code		thru	da0-99-exit;  //
                await da0_enter_icc_code();
                await da0_10_enter_tech();
                await da0_20_enter_eff_date();
                await da0_30_enter_active_flag();
                await da0_40_enter_global_exclusion();
                await da0_99_exit();

                // 	   perform fa0-display-rates		thru	fa0-99-exit.;  //
                await fa0_display_rates();
               // await display_scr_a_prev_a_asst();
                await fa0_99_exit();
            }

            //  if add-code or change-code  then 
            if (entry_type.Equals(add_code) || entry_type.Equals(change_code)) {
                // 	   perform ha0-add-change-rates		thru	ha0-99-exit;
                string retval =  await ha0_add_change_rates(); 
                if (retval.ToLower().Equals("ha0_99_exit"))
                {
                    goto _ha0_99_exit;
                }

                retval =  await ha0_10_add_change_cv();
                if (retval.ToLower().Equals("ha0_99_exit"))
                {
                    goto _ha0_99_exit;
                }

                retval =  await ha0_20_add_change_dr_etc();
                if (retval.ToLower().Equals("ha0_99_exit"))
                {
                    goto _ha0_99_exit;
                }

                retval =  await ha0_30_add_change_dt();
                if (retval.ToLower().Equals("ha0_99_exit"))
                {
                    goto _ha0_99_exit;
                }

                await ha0_40_add_change_sp();                
_ha0_99_exit:
                await ha0_99_exit();

                // 	   perform ja0-add-change-other-info	thru	ja0-99-exit; //
                await ja0_add_change_other_info();

_ja0_05_page:
                retval =  await ja0_05_page();               

                await ja0_10_m_suffix();
                await ja0_15_diag();
                await ja0_20_ref_phys();
                await ja0_25_hosp_nbr();
                await ja0_30_in_out();
                await ja0_35_admit_dt();

 _ja0_99_exit:
               await ja0_99_exit();

                lnum = 19;
                pc_year = 1;
                flag_mode = "U";
                // 	   perform ga1-i-o-add-ons     		thru ga1-99-exit;
                // 	       varying cnum from 1 by 5 until cnum > 46;

                cnum = 1;
                do
                {
                   await ga1_i_o_add_ons();
                   await ga1_99_exit();

                    cnum = cnum + 5;
                } while (cnum <= 46);

                // 	   perform ia1-i-o-suffixes  		thru ia1-99-exit;
                // 	        varying cnum from 71 by 4 until cnum > 79;

                cnum = 71;
                do
                {
                   await ia1_i_o_suffixes();
                   await ia1_99_exit();
                    cnum = cnum + 4;
                } while (cnum <= 79 );

                // 	   perform ka0-add-change-contd-info	thru ka0-99-exit.;  //
               await ka0_add_change_contd_info();
               await ka0_50_perc_flat();
               await ka0_60_both_perc_and_flat();
               await ka0_99_exit();
            }

            return string.Empty;
        }

        private async Task<string> ab0_300_verify()
        {

            //  if  add-code or change-code then
            if (entry_type.Equals(add_code) || entry_type.Equals(change_code)) {
                // 	    display scr-verify-add-change;
                // 	   accept  scr-verify-add-change;
                Display("scr-verify-add-change.");
                await Prompt("acc_mod_rej", "scr-verify-add-change.", "scr-verify-add-change-1");

            }
            //  else if delete-code then            
            else if (entry_type.Equals(delete_code)) {
                // 	    display scr-verify-del;
                // 	    accept  scr-verify-del;
                Display("scr-verify-del.");
                await Prompt("acc_mod_rej", "scr-verify-del.", "scr-verify-del-1");
            }
            // 	else if inquire-code then            
            else if (entry_type.Equals(inquire_code)) {
                // 		display scr-verify-continue;
                // 		accept  scr-verify-continue;
                Display("scr-verify-continue.");
                await Prompt("acc_mod_rej", "scr-verify-continue.", "scr-verify-continue-1");

                // 		go to ab0-400-next.;               
                return "ab0_400_next";
            }

            //  if accept-screen then 
            if (acc_mod_rej.Equals(accept_screen)) {
                // 	    next sentence;
            }
            //  else if reject-screen then 
            else if (acc_mod_rej.Equals(reject_screen)) {
                // 	    display scr-reject-entry;
                Display("scr-reject-entry.");
                // 	    display confirm;
                Display("confirm.");

                // 	    stop " ";
                // 	    display blank-line-24;
                Display("blank-line-24.");
                // 	    go to ab0-400-next;                
                return "ab0_400_next";
            }
            // 	else if  modify-screen and (add-code or change-code)  then  
            else if (acc_mod_rej.Equals(modify_screen) && (entry_type.Equals(add_code) || entry_type.Equals(change_code))) {
                // 	 	go to ab0-200-modify;                
                return "ab0_200_modify";
            }
            // 	else if prev-yr-modify and (add-code or change-code) then        
            else if (acc_mod_rej.Equals(prev_yr_modify) && (entry_type.Equals(add_code) ||  entry_type.Equals(change_code))) {
                           acc_mod_rej = "";
                // 		    display scr-verify-add-change;
                  Display("scr-verify-add-change.");

                // 		    perform sa0-password	thru	sa0-99-exit;
                await sa0_password();
                await sa0_99_exit();

                // 		    if password-ok then 
                if (password_flag.Equals(password_ok)) {
                    // 			    perform ta0-prev-yr-modify thru	ta0-99-exit;  ...
                    string retval =  await ta0_prev_yr_modify();
                    if (retval.ToLower().Equals("ta0_99_exit") )
                    {
                        goto _ta0_99_exit;
                    }

                   retval =  await ta0_10_add_change_cv();
                    if (retval.ToLower().Equals("ta0_99_exit"))
                    {
                        goto _ta0_99_exit;
                    }

                    retval =  await ta0_20_add_change_dr_etc();
                    if (retval.ToLower().Equals("ta0_99_exit"))
                    {
                        goto _ta0_99_exit;
                    }

                   retval =   await ta0_30_add_change_dt();
                    if (retval.ToLower().Equals("ta0_99_exit"))
                    {
                        goto _ta0_99_exit;
                    }

                    await ta0_40_add_change_sp();

_ta0_99_exit:
                    await ta0_99_exit();

                    // 			    accept scr-prev-page-alpha;
                    Display("scr-prev-misc.", "scr-prev-page-alpha");
                    await Prompt("fee_prev_page_alpha");

                    // 			    accept scr-prev-page-numeric;
                    Display("scr-prev-misc.", "scr-prev-page-numeric");
                    await Prompt("fee_prev_page_numeric");

                                  lnum = 20;
                                  flag_mode = "U";
                                  pc_year = 2;
                    // 			    perform ga1-i-o-add-ons		thru ga1-99-exit;
                    // 			       varying cnum from 1 by 5 until cnum > 46;
                    cnum = 1;
                    do
                    {
                        await ga1_i_o_add_ons();
                        await ga1_99_exit();
                        cnum = cnum + 5;
                    } while (cnum <= 46 );

                    // 			   perform ia1-i-o-suffixes	thru ia1-99-exit;
                    // 			       varying cnum from 71 by 4 until cnum > 79;

                    cnum = 71;
                    do
                    {
                       await ia1_i_o_suffixes();
                        await ia1_99_exit();
                        cnum = cnum + 4;
                    } while (cnum <= 79 );

                    // 			   accept scr-prev-perc-flat;
                    Display("scr-prev-misc.", "scr-prev-perc-flat");
                    await Prompt("fee_prev_add_on_perc_flat_ind");

                    // 			   go to ab0-300-verify;
                    await ab0_300_verify();
                    return string.Empty;                    
                }
                else {
                          err_ind = 18;
                    //     perform za0-common-error thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 			   go to ab0-300-verify;
                    await ab0_300_verify();
                    return string.Empty;
                }
            }
            else {
                         err_ind = 1;
                //      perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 		    go to ab0-300-verify.;
                await ab0_300_verify();
                return string.Empty;
            }

            //   display blank-line-24.;
            Display("blank-line-24.");

            //   if add-code then 
            if (entry_type.Equals(add_code) ) {
                // 	    perform la0-write-new-rec		thru	la0-99-exit;
                await la0_write_new_rec();
                await la0_99_exit();
            }
            //   else if change-code then            
            else if (entry_type.Equals(change_code)) {
                // 	    perform na0-re-write-rec		thru	na0-99-exit;
                await na0_re_write_rec();
                await na0_99_exit();
            }
            // 	else if delete-code then            
            else if (entry_type.Equals(delete_code) ) {
                // 		perform pa0-delete-rec		thru	pa0-99-exit;
                await pa0_delete_rec();
                await pa0_99_exit();
            }
            else {
                // 		next sentence.;
            }

            //  if not inquire-code then            
            if (!entry_type.Equals(inquire_code) ) {
                //      perform ra0-print-audit			thru	ra0-99-exit.;
                await ra0_print_audit();
                await ra0_99_exit();
            }

            return string.Empty;
        }

        private async Task<string> ab0_400_next()
        {

            //     display scr-clear-option.;
            Display("scr-clear-option.");

            //     go to ab0-150-acpt-code-display-info.;            
            return "ab0_150_acpt_code_display_info";
        }

        private async Task ab0_99_exit()
        {

            //     exit.;
        }

        private async Task ba0_read_fee_mstr()
        {

            read_flag = "Y";
            status_flag = "Y";

            //     read oma-fee-mstr;
            //      	invalid key;
            //            read_flag = "N";

            Fee_mstr_rec_Collection = null;
            Fee_mstr_rec_Collection = new F040_OMA_FEE_MSTR
            {
                WhereFee_oma_cd_ltr1 = Util.Str(fee_oma_cd).Trim().PadRight(4).Substring(0,1),
                WhereFiller_numeric  = Util.Str(fee_oma_cd).Trim().PadRight(4).Substring(1, 3)
            }.Collection();

            if (Fee_mstr_rec_Collection.Count() == 0)
            {
                read_flag = "N";
                if (Util.Str(fee_oma_cd).Trim().PadRight(4).Substring(0, 1) == "*")
                {
                    return;
                }
            } else
            {
                objFee_mstr_rec = Fee_mstr_rec_Collection[0];
                await OmaFee_Mstr_Record_To_ScreenVariables();
            }             

            //  if not-on-file then    
            if (read_flag.Equals(not_on_file) ) {
                // 	    if add-code then        
                if (entry_type.Equals(add_code) ) {
                    // 	       go to ba0-99-exit;
                    await ba0_99_exit();
                    return; 
                }
                else {
                          status_flag = "N";
                          err_ind = 8;
                    //    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	 go to ba0-99-exit.;
                    await ba0_99_exit();
                    return; 
                }
            }

            //     add 1				to	ctr-fee-mstr-reads.;
            ctr_fee_mstr_reads++;

            // if add-code then  
            if (entry_type.Equals(add_code) ) {
                status_flag = "N";
                err_ind = 2;
                // 	   perform za0-common-error	thru	za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }
        }

        private async Task ba0_99_exit()
        {

            //     exit.;
        }

        private async Task da0_enter_icc_code()
        {

            //     accept scr-icc-code.;
            Display("scr-icc-desc-tech.", "scr-icc-code");
            await Prompt("fee_icc_code");

            fee_icc_sec = Util.Str(fee_icc_code).PadRight(6).Substring(0, 2);
            //  if fee-icc-sec =  "CP";
            if (Util.Str(fee_icc_sec).ToUpper() == "CP"
            // 	  	   or "CV";
               || Util.Str(fee_icc_sec).ToUpper() == "CV"
            // 		   or "DR";
               || Util.Str(fee_icc_sec).ToUpper() == "DR"
            // 		   or "DT";
               || Util.Str(fee_icc_sec).ToUpper() == "DT"
            // 		   or "DU";
               || Util.Str(fee_icc_sec).ToUpper() == "DU"
            // 		   or "NM";
               || Util.Str(fee_icc_sec).ToUpper() == "NM"
            // 		   or "PF";
               || Util.Str(fee_icc_sec).ToUpper() == "PF"
            // 		   or "SP";
               || Util.Str(fee_icc_sec).ToUpper() == "SP"
            //     then;
            )
            {
                // 	     next sentence;
            }
            else {
                 err_ind = 9;
                // 	  perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();

                // 	  go to da0-enter-icc-code.;
                await da0_enter_icc_code();
                return; 
            }


            //  if (fee-icc-cat is numeric and fee-icc-cat not = space)
            if (( !string.IsNullOrWhiteSpace(Util.Str(fee_icc_cat)))
            //        and (fee-icc-grp is numeric and fee-icc-grp not = space);
                 && (!string.IsNullOrWhiteSpace( Util.Str(fee_icc_grp)) )
            //        and (fee-icc-reduc-ind is numeric and fee-icc-reduc-ind not = space);
                 && (!string.IsNullOrWhiteSpace(Util.Str(fee_icc_reduc_ind)))
            //     then;
            )
            {
                // 	       next sentence;
            }
            else {
                 err_ind = 22;
                // 	    perform za0-common-error	thru	za0-99-exit;
               await za0_common_error();
                await za0_99_exit();
                // 	    go to da0-enter-icc-code.;
               await da0_enter_icc_code();
                return; 
            }

            //     accept scr-desc.;
            Display("scr-icc-desc-tech.", "scr-desc");
            await Prompt("fee_desc");

        }

        private async Task da0_10_enter_tech()
        {

            //     accept scr-tech-ind.;
            Display("scr-icc-desc-tech.", "scr-tech-ind");
            await Prompt("fee_tech_ind");

            // if fee-tech-ind not = 'Y' and  fee-tech-ind not = 'N'  then            
            if (Util.Str(fee_tech_ind).ToUpper()  != "Y" && Util.Str(fee_tech_ind).ToUpper() != "N") {
                      err_ind = 20;
                //   	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to da0-10-enter-tech.;
                await da0_10_enter_tech();
                return; 
            }
        }

        private async Task da0_20_enter_eff_date()
        {

            //     accept scr-eff-yy.;
            Display("scr-icc-desc-tech.", "scr-eff-yy");
            await Prompt("fee_date_yy");

            //     accept scr-eff-mm.;
            Display("scr-icc-desc-tech.", "scr-eff-mm");
            await Prompt("fee_date_mm");

            //     accept scr-eff-dd.;
            Display("scr-icc-desc-tech.", "scr-eff-dd");
            await Prompt("fee_date_dd");
        }

        private async Task da0_30_enter_active_flag()
        {

            //     accept scr-active-flag.;
            Display("scr-icc-desc-tech.", "scr-active-flag");
            await Prompt("fee_active_for_entry");

            //  if  fee-active-for-entry not = 'Y' and fee-active-for-entry not = 'N' then
            if (fee_active_for_entry != "Y" && fee_active_for_entry != "N" ) {
                     err_ind = 20;
                //   	perform za0-common-error	thru za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	    go to da0-30-enter-active-flag.;
                await da0_30_enter_active_flag();
                return;
            }
        }

        private async Task da0_40_enter_global_exclusion()
        {

            //     accept scr-exclude-global-addon.;
            Display("scr-icc-desc-tech.", "scr-exclude-global-addon");
            await Prompt("fee_global_addon_cd_exclusion");

            //  if  fee-global-addon-cd-exclusion not = 'Y' and fee-global-addon-cd-exclusion not = 'N' then 
            if (fee_global_addon_cd_exclusion != "Y" && fee_global_addon_cd_exclusion != "N" ) {
                      err_ind = 20;
                //  perform za0-common-error	thru za0-99-exit;
               await za0_common_error();
               await za0_99_exit();
                // 	    go to da0-40-enter-global-exclusion.;
               await da0_40_enter_global_exclusion();
                return; 
            }
        }

        private async Task da0_99_exit()
        {

            //     exit.;
        }

        private async Task fa0_display_rates()
        {

            // if fee-icc-sec =  "DR" or "DU"  or "NM" or "PF"  then            
            if (Util.Str(fee_icc_sec).ToUpper() == "DR" || Util.Str(fee_icc_sec).ToUpper() == "DU"  || Util.Str(fee_icc_sec).ToUpper() == "NM" || Util.Str(fee_icc_sec).ToUpper() == "PF" ) {
                // 	   if tec-title then         
                if (display_type.Equals(tec_title) ) {
                    // 	      next sentence;
                }
                else {
                    //   display scr-technical-title;
                    Display("scr-technical-title.");
                    Display("scr-general-title.", false);
                    display_type = "TEC";
                }
            }
            //else if gen-title then            
            else if (display_type.Equals(gen_title) ) {
                // 	    next sentence;
            }
            else {
                // 	    display scr-general-title;
                Display("scr-general-title.");
                Display("scr-technical-title.", false);
                display_type = "GEN";
            }

            //     display blank-rate-lines.;
            Display("blank-rate-lines.");

            //  if fee-icc-sec = "CP"  then;            
            if (Util.Str(fee_icc_sec).ToUpper() == "CP") {
                // 	display	scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                // 		       scr-curr-h-anae;
                Display("scr-rate-info.", "scr-curr-h-anae");
                // 		       scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");
                // 		       scr-curr-a-anae;
                Display("scr-rate-info.", "scr-curr-a-anae");
                // 		       scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		       scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		       scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		       scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 	           scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                // 		       scr-a-prev-h-anae;
                Display("scr-rate-info.", "scr-a-prev-h-anae");
                // 		       scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");
                // 		       scr-a-prev-a-anae;
                Display("scr-rate-info.", "scr-a-prev-a-anae");
                // 		       go to fa0-99-exit.;
                await fa0_99_exit();
                return; 
            }

            //  if fee-icc-sec = "CV" then            
            if (Util.Str(fee_icc_sec).ToUpper() == "CV") {
                // 	    display scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                // 	       	    scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");
                // 		        scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                // 		        scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");
                // 		        scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		        scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		        scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		        scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 	            go to fa0-99-exit.;
                await fa0_99_exit();
                return; 
            }

            //  if fee-icc-sec =  "DR" or "DU" or "NM" or "PF" then       
            if (Util.Str(fee_icc_sec).ToUpper() == "DR" || Util.Str(fee_icc_sec).ToUpper() == "DU" || Util.Str(fee_icc_sec).ToUpper() == "NM" || Util.Str(fee_icc_sec).ToUpper() == "PF" ) {
                // 	     display scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                // 		         scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                // 		         scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");
                // 		         scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");
                // 		         scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		         scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		         scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		         scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 		         scr-a-prev-h-1;
                Display("scr-rate-info.", "scr-a-prev-h-1");
                // 		         scr-a-prev-h-2;
                Display("scr-rate-info.", "scr-a-prev-h-2");
                // 		         scr-a-prev-a-1;
                Display("scr-rate-info.", "scr-a-prev-a-1");
                // 		         scr-a-prev-a-2;
                Display("scr-rate-info.", "scr-a-prev-a-2");
                // 	      go to fa0-99-exit.;
                await fa0_99_exit();
                return; 
            }

            //  if fee-icc-sec = "DT" then            
            if (Util.Str(fee_icc_sec).ToUpper() == "DT") {
                // 	     display scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                // 		         scr-curr-h-anae;
                Display("scr-rate-info.", "scr-curr-h-anae");
                // 		         scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");
                // 		         scr-curr-a-anae;
                Display("scr-rate-info.", "scr-curr-a-anae");
                // 		         scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		         scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		         scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		         scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 		         scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                // 		         scr-a-prev-h-anae;
                Display("scr-rate-info.", "scr-a-prev-h-anae");
                // 		         scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");
                // 		         scr-a-prev-a-anae;
                Display("scr-rate-info.", "scr-a-prev-a-anae");
                // 	     go to fa0-99-exit.;
                await fa0_99_exit();
                return; 
            }

            //   if fee-curr-add-on-perc-flat-ind = "B" then            
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B") {
                // 	      display scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                // 		          scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                // 		          scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");
                // 		          scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		          scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		          scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		          scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 		          scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");
                // 		          scr-a-prev-h-1;
                Display("scr-rate-info.", "scr-a-prev-h-1");
                // 		          scr-a-prev-h-2;
                Display("scr-rate-info.", "scr-a-prev-h-2");
                // 		          scr-a-prev-a-1;
                Display("scr-rate-info.", "scr-a-prev-a-1");
                // 		          scr-a-prev-a-2;
                Display("scr-rate-info.", "scr-a-prev-a-2");
            }
            else {
                // 	    display	scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                // 		        scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");
                // 		        scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                // 		        scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                // 		        scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                // 		        scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                // 		        scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                // 		       scr-a-prev-a-oth.;
                Display("scr-rate-info.", "scr-a-prev-a-oth");
            }


            //     display	scr-curr-h-anae;
            Display("scr-rate-info.", "scr-curr-h-anae");
            //     display  scr-curr-h-asst;
            Display("scr-rate-info.", "scr-curr-h-asst");
            //    display scr-curr-a-anae;
            Display("scr-rate-info.", "scr-curr-a-anae");

            // display		scr-curr-a-asst;
            Display("scr-rate-info.", "scr-curr-a-asst");
            // 	display	scr-curr-h-min;
            Display("scr-rate-info.", "scr-curr-h-min");
            // 	display	scr-curr-h-max;
            Display("scr-rate-info.", "scr-curr-h-max");
            // 	display	scr-prev-h-min;
            Display("scr-rate-info.", "scr-prev-h-min");
            // display		scr-prev-h-max;
            Display("scr-rate-info.", "scr-prev-h-max");

            // display		scr-a-prev-h-anae;
            Display("scr-rate-info.", "scr-a-prev-h-anae");
            // display		scr-a-prev-h-asst;
            Display("scr-rate-info.", "scr-a-prev-h-asst");
            // display		scr-a-prev-a-anae;
            Display("scr-rate-info.", "scr-a-prev-a-anae");
            // display      scr-a-prev-a-asst.
            Display("scr-rate-info.", "scr-a-prev-a-asst");
        }
      

        private async Task fa0_99_exit()
        {

            //     exit.;
        }

        private async Task ga0_display_add_ons()
        {

            flag_mode = "D";

            // if pc-year = 1 then      
            if (Util.NumInt(pc_year) == 1) {
                  lnum = 19;
            }
            else {
                  lnum = 20;
            }

            //  perform ga1-i-o-add-ons		thru ga1-99-exit;
            //   	varying cnum from 1 by 5 until cnum > 46.;

            cnum = 1;
            do
            {
                await ga1_i_o_add_ons();
                await ga1_99_exit();
                cnum = cnum + 5;
            } while (cnum  <= 46 );
        }

        private async Task ga0_99_exit()
        {

            //     exit.;
        }

        private async Task ga1_i_o_add_ons()
        {

            //     add 4,cnum giving cntr.;
            cntr = cnum + 4;

            //     divide 5 into cntr.;
            cntr = cntr / 5;


            // if display-mode then  
            if (flag_mode.Equals(display_mode) ) {
                // 	   display scr-add-on-cd;                
                await display_fee_add_on_cd(pc_year, cntr);
            }
            // else if update-mode then            
            else if (flag_mode.Equals(update_mode) ) {
                // 	    display scr-add-on-cd;
                // 	    accept scr-add-on-cd;
                Display("scr-add-on.", "scr-add-on-cd");
                //await Prompt("fee_add_on_cd[" + Util.Str(pc_year,cntr) + "]");
                await accept_fee_add_on_cd(pc_year, cntr);
                // 	    if fee-add-on-cd(pc-year,cntr) = spaces then; 
                if (string.IsNullOrWhiteSpace(fee_add_on_cd[pc_year, cntr]))  // todo: WATCH OUT!!!  This is actually 2 dimension array in  FD  under redefines  05  fee-current-prev-year-r redefines fee-current-prev-years. .....???
                {            // if (string.IsNullOrWhiteSpace(fee_add_on_cd[pc_year, cntr])) { 
                    cnum = 50;
                }
            }
        }

        private async Task ga1_99_exit()
        {

            //     exit.;
        }

        private async Task<string> ha0_add_change_rates()
        {

            //  if add-code then 
            if (entry_type.Equals(add_code)) {
                fee_prev_h_fee_1 = 0;
                fee_1[2, 2] = 0;
                fee_prev_h_fee_2 = 0;
                fee_2[2, 2] = 0;
                fee_prev_h_anae = 0;
                fee_anae[2, 2] = 0;
                fee_prev_h_asst = 0;
                fee_asst[2, 2] = 0;
                fee_prev_h_min = 0;
                fee_min[2, 2] = 0;
                fee_prev_h_max = 0;
                fee_max[2, 2] = 0;
                fee_prev_a_fee_1 = 0;
                fee_1[2, 1] = 0;
                fee_prev_a_fee_2 = 0;
                fee_2[2, 1] = 0;
                fee_prev_a_anae = 0;
                fee_anae[2, 1] = 0;
                fee_prev_a_asst = 0;
                fee_asst[2, 1] = 0;
            }


            // if fee-icc-sec = "CP" then 
            if (Util.Str(fee_icc_sec).ToUpper() == "CP") {
                // 	  accept  scr-curr-h-oth;
                // 	  display scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-oth");
                fee_1[1, 2] = fee_curr_h_fee_1;

                // 	  accept  scr-curr-h-anae;
                // 	  display scr-curr-h-anae;
                Display("scr-rate-info.", "scr-curr-h-anae");
                await Prompt("fee_curr_h_anae");
                fee_anae[1, 2] = fee_curr_h_anae;

                  fee_curr_h_fee_2 = 0;
                fee_2[1, 2] = 0;
                  fee_curr_h_asst = 0;
                fee_asst[1, 2] = 0;
                  fee_curr_a_fee_2 = 0;
                fee_2[1, 1] = 0;
                  fee_curr_a_asst = 0;
                fee_asst[1, 1] = 0;


                  fee_curr_a_fee_1 = fee_curr_h_fee_1;
                fee_1[1,1] = fee_curr_h_fee_1;
                fee_curr_a_anae = fee_curr_h_anae;
                fee_anae[1,1] = fee_curr_h_anae;

                // 	display scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");

                // 	display scr-curr-a-anae;
                Display("scr-rate-info.", "scr-curr-a-anae");

                // 	display scr-curr-h-min;
                // 	accept  scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                await Prompt("fee_curr_h_min");
                fee_min[1, 2] = fee_curr_h_min;

                // 	display scr-prev-h-min;
                // 	accept  scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                await Prompt("fee_prev_h_min");
                fee_min[2, 2] = fee_prev_h_min;

                // 	display scr-curr-h-max;
                // 	accept  scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                await Prompt("fee_curr_h_max");
                fee_max[1, 2] = fee_curr_h_max;

                // 	display scr-prev-h-max;
                // 	accept  scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                await Prompt("fee_prev_h_max");
                fee_max[2, 2] = fee_prev_h_max;

                // 	if  fee-curr-h-fee-1 = 0 or fee-curr-h-anae  = 0 then   
                if (fee_curr_h_fee_1 == 0 || fee_curr_h_anae == 0 ) {
                         err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ha0-99-exit;                   
                    return "ha0_99_exit";
                }
                else {
                    // 	    go to ha0-99-exit.;                   
                    return "ha0_99_exit";
                }
            }
            return string.Empty;
        }

        private async Task<string> ha0_10_add_change_cv()
        {

            // if fee-icc-sec = "CV" then; 
            if (Util.Str(fee_icc_sec).ToUpper() == "CV") {
                // 	  accept  scr-curr-h-oth;
                // 	  display scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-oth");
                fee_1[1, 2] = fee_curr_h_fee_1;

                    fee_curr_h_fee_2 = 0;
                fee_2[1, 2] = 0;
                    fee_curr_h_anae = 0;
                fee_anae[1, 2] = 0;
                    fee_curr_h_asst = 0;
                fee_asst[1, 2] = 0;
                    fee_curr_a_fee_2 = 0;
                fee_2[1, 1] = 0;
                    fee_curr_a_anae = 0;
                fee_anae[1, 1] = 0;
                    fee_curr_a_asst = 0;
                fee_asst[1, 1] = 0;

                    fee_curr_a_fee_1 = fee_curr_h_fee_1;
                fee_1[1,1] = fee_curr_h_fee_1;

                //   display scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");

                // 	  display scr-curr-h-min;
                // 	  accept  scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                await Prompt("fee_curr_h_min");
                fee_min[1, 2] = fee_curr_h_min;

                // 	  display scr-prev-h-min;
                // 	  accept  scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                await Prompt("fee_prev_h_min");
                fee_min[2, 2] = fee_prev_h_min;

                // 	 display scr-curr-h-max;
                // 	 accept  scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                await Prompt("fee_curr_h_max");
                fee_max[1, 2] = fee_curr_h_max;

                //   display scr-prev-h-max;
                // 	 accept  scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                await Prompt("fee_prev_h_max");
                fee_max[2, 2] = fee_prev_h_max;

                // 	if  fee-curr-h-fee-1 = 0 then   
                if (fee_curr_h_fee_1 == 0) {
                         err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ha0-99-exit;                    
                    return "ha0_99_exit";
                }
                else {
                    // 	    go to ha0-99-exit.;                    
                    return "ha0_99_exit";
                }
            }
            return string.Empty;
        }

        private async Task<string> ha0_20_add_change_dr_etc()
        {

            //  if  fee-icc-sec =  "DR" or "DU" or "NM"  or "PF"  then  
            if (Util.Str(fee_icc_sec).ToUpper() == "DR" || Util.Str(fee_icc_sec).ToUpper() == "DU" || Util.Str(fee_icc_sec).ToUpper() == "NM"  || Util.Str(fee_icc_sec).ToUpper() == "PF" ) {
                // 	    accept  scr-curr-h-1;
                // 	    display scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-1");
                fee_1[1, 2] = fee_curr_h_fee_1;

                // 	    accept	scr-curr-h-2;
                // 	    display scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                await Prompt("fee_curr_h_fee_2");
                fee_2[1, 2] = fee_curr_h_fee_2;

                     fee_curr_h_anae = 0;
                fee_anae[1, 2] = 0;
                     fee_curr_h_asst = 0;
                fee_asst[1, 2] = 0;
                     fee_curr_a_anae = 0;
                fee_anae[1, 1] = 0;
                     fee_curr_a_asst = 0;
                fee_asst[1, 1] = 0;

                fee_curr_a_fee_1 = fee_curr_h_fee_1;
                fee_1[1,1] = fee_curr_h_fee_1;
                fee_curr_a_fee_2 = fee_curr_h_fee_2;
                fee_2[1,1] = fee_curr_h_fee_2; ;

                // 	display scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");
                // 	display scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");

                // 	display scr-curr-h-min;
                // 	accept  scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                await Prompt("fee_curr_h_min");
                fee_min[1, 2] = fee_curr_h_min;

                // 	display scr-prev-h-min;
                // 	accept  scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                await Prompt("fee_prev_h_min");
                fee_min[2, 2] = fee_prev_h_min;

                // 	display scr-curr-h-max;
                // 	accept  scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                await Prompt("fee_curr_h_max");
                fee_max[1, 2] = fee_curr_h_max;

                // 	display scr-prev-h-max;
                // 	accept  scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                await Prompt("fee_prev_h_max");
                fee_max[2, 2] = fee_prev_h_max;

                // 	if  fee-curr-h-fee-1 = 0 or fee-curr-h-fee-2 = 0  then  
                if (fee_curr_h_fee_1 == 0 || fee_curr_h_fee_2 == 0 ) {
                         err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ha0-99-exit;                    
                    return "ha0_99_exit";
                }
                else {
                    // 	    go to ha0-99-exit.;                    
                    return "ha0_99_exit";
                }
            }

            return string.Empty;
        }

        private async Task<string> ha0_30_add_change_dt()
        {

            // if fee-icc-sec = "DT" then  
            if (fee_icc_sec == "DT") {
                //   accept	 scr-curr-h-oth;
                // 	 display scr-curr-h-oth;
                Display("scr-rate-info.", "scr-curr-h-oth");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-oth");
                fee_1[1, 2] = fee_curr_h_fee_1;

                // 	 accept	 scr-curr-h-anae;
                // 	 display scr-curr-h-anae;
                Display("scr-rate-info.", "scr-curr-h-anae");
                await Prompt("fee_curr_h_anae");
                fee_anae[1, 1] = fee_curr_h_anae;

                fee_curr_h_fee_2 = fee_curr_h_fee_1;
                fee_2[1,2] = fee_curr_h_fee_1;
                fee_curr_a_fee_1 = fee_curr_h_fee_1;
                fee_1[1,1] = fee_curr_h_fee_1; ;
                fee_curr_a_fee_2 = fee_curr_h_fee_1;
                fee_2[1,1] = fee_curr_h_fee_1;

                fee_curr_a_anae = fee_curr_h_anae;
                fee_anae[1,1] = fee_curr_h_anae; 
                fee_curr_h_asst = 0;
                fee_asst[1, 2] = 0;
                fee_curr_a_asst = 0;
                fee_asst[1, 1] = 0;

                // 	display scr-curr-a-oth;
                Display("scr-rate-info.", "scr-curr-a-oth");

                // 	display scr-curr-a-anae;
                Display("scr-rate-info.", "scr-curr-a-anae");

                // 	display scr-curr-h-min;
                // 	accept  scr-curr-h-min;
                Display("scr-rate-info.", "scr-curr-h-min");
                await Prompt("fee_curr_h_min");
                fee_min[1, 2] = fee_curr_h_min;

                // 	display scr-prev-h-min;
                // 	accept  scr-prev-h-min;
                Display("scr-rate-info.", "scr-prev-h-min");
                await Prompt("fee_prev_h_min");
                fee_min[2, 2] = fee_prev_h_min;

                // 	display scr-curr-h-max;
                // 	accept  scr-curr-h-max;
                Display("scr-rate-info.", "scr-curr-h-max");
                await Prompt("fee_curr_h_max");
                fee_max[1, 2] = fee_curr_h_max;

                // 	display scr-prev-h-max;
                // 	accept  scr-prev-h-max;
                Display("scr-rate-info.", "scr-prev-h-max");
                await Prompt("fee_prev_h_max");
                fee_max[2, 2] = fee_prev_h_max;

                // 	if  fee-curr-h-fee-1 = 0 or fee-curr-h-anae  = 0 then  
                if (fee_curr_h_fee_1 == 0 || fee_curr_h_anae == 0 ) {
                        err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ha0-99-exit;                   
                    return "ha0_99_exit";
                }
                else {
                    // 	    go to ha0-99-exit.;                   
                    return "ha0_99_exit";
                }
            }
            return string.Empty;
        }

        private async Task<string> ha0_40_add_change_sp()
        {

            //  if fee-curr-add-on-perc-flat-ind = "B" then  
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B") {
                // 	    accept  scr-curr-h-1;
                // 	    display scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-1");
                fee_1[1, 2] = fee_curr_h_fee_1;

                // 	    accept  scr-curr-h-2;
                // 	    display scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                await Prompt("fee_curr_h_fee_2");
                fee_2[1, 2] = fee_curr_h_fee_2;
            }
            else {
                // 	   accept  scr-curr-h-oth;
                // 	   display scr-curr-h-oth.;
                Display("scr-rate-info.", "scr-curr-h-oth");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-oth");
                fee_1[1, 2] = fee_curr_h_fee_1;
            }


            //   accept  scr-curr-h-anae.;
            //   display scr-curr-h-anae.;
            Display("scr-rate-info.", "scr-curr-h-anae");
            await Prompt("fee_curr_h_anae");
            fee_anae[1, 2] = fee_curr_h_anae;

            //   accept  scr-curr-h-asst.;
            //   display scr-curr-h-asst.;
            Display("scr-rate-info.", "scr-curr-h-asst");
            await Prompt("fee_curr_h_asst");
            fee_asst[1, 2] = fee_curr_h_asst;

            //  if fee-curr-add-on-perc-flat-ind not = "B" then     
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() != "B" ) {
                fee_curr_h_fee_2 = fee_curr_h_fee_1;
                fee_2[1, 2] = fee_curr_h_fee_1;
            }

              fee_curr_a_fee_1 = fee_curr_h_fee_1;
             fee_1[1,1] = fee_curr_h_fee_1;
             fee_curr_a_fee_2 = fee_curr_h_fee_2;
              fee_2[1,1]  = fee_curr_h_fee_2; ;
            fee_curr_a_anae = fee_curr_h_anae;
              fee_anae[1,1] = fee_curr_h_anae;
            fee_curr_a_asst = fee_curr_h_asst;
             fee_asst[1,1] = fee_curr_h_asst; 

            //  if fee-curr-add-on-perc-flat-ind = "B" then           
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B") {
                // 	   display scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");

                // 	   display scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");

            }
            else {
                //    	display scr-curr-a-oth.;
                Display("scr-rate-info.", "scr-curr-a-oth");
            }

            //     display scr-curr-a-asst.;
            Display("scr-rate-info.", "scr-curr-a-asst");
            //     display scr-curr-a-anae.;
            Display("scr-rate-info.", "scr-curr-a-anae");

            //     display scr-curr-h-min.;
            //     accept  scr-curr-h-min.;
            Display("scr-rate-info.", "scr-curr-h-min");
            await Prompt("fee_curr_h_min");
            fee_min[1, 2] = fee_curr_h_min;

            //     display scr-prev-h-min.;
            //     accept  scr-prev-h-min.;
            Display("scr-rate-info.", "scr-prev-h-min");
            await Prompt("fee_prev_h_min");
            fee_min[2, 2] = fee_prev_h_min;

            //     display scr-curr-h-max.;
            //     accept  scr-curr-h-max.;
            Display("scr-rate-info.", "scr-curr-h-max");
            await Prompt("fee_curr_h_max");
            fee_max[1, 2] = fee_curr_h_max;

            //     display scr-prev-h-max.;
            //     accept  scr-prev-h-max.;
            Display("scr-rate-info.", "scr-prev-h-max");
            await Prompt("fee_prev_h_max");
            fee_max[2, 2] = fee_prev_h_max;

            //  if  fee-curr-h-fee-1 = zero  or  fee-curr-h-anae  = zero  or      fee-curr-h-asst  = zero or (    fee-curr-h-fee-2 = zero and fee-curr-add-on-perc-flat-ind = "B")  then    
            if (fee_curr_h_fee_1 == 0  || fee_curr_h_anae == 0  || fee_curr_h_asst == 0 || (fee_curr_h_fee_2 == 0 && fee_curr_add_on_perc_flat_ind == "B")  ) {
                     err_ind = 6;
                //   	perform za0-common-error 	thru	za0-99-exit.;
                await za0_common_error();                
                return "za0_99_exit";
            }
            return string.Empty;
        }

        private async Task ha0_99_exit()
        {

            //     exit.;
        }

        private async Task ia0_display_suffixes()
        {

            flag_mode = "D";

            // if pc-year = 1 then 
            if (Util.NumInt(pc_year) == 1) {
                  lnum = 19;
            }
            else {
                  lnum = 20;
            }

            //  perform ia1-i-o-suffixes		thru ia1-99-exit;
            //         varying cnum from 71 by 4 until cnum > 79.;

            cnum = 71;
            do
            {
                await ia1_i_o_suffixes();
                await ia1_99_exit();
                cnum = cnum + 4;
            } while (cnum <= 79);

        }

        private async Task ia0_99_exit()
        {

            //     exit.;
        }

        private async Task ia1_i_o_suffixes()
        {

            //     subtract 67 from cnum giving cntr.;
            cntr = cnum - 67;

            //     divide 4 into cntr.;
            cntr = cntr / 4;

            // if display-mode then            
            if (flag_mode.Equals(display_mode) ) {
                // 	   display scr-suffix;                
                await display_fee_oma_ind_card_required(pc_year, cntr);
            }
            // else if update-mode then            
            else if (flag_mode.Equals(update_mode)) {
                // 	    display scr-suffix;
                //      accept scr-suffix;
                await display_fee_oma_ind_card_required(pc_year, cntr);
                await accept_fee_oma_ind_card_required(pc_year, cntr);

                //  if fee-oma-ind-card-required(pc-year,cntr) = spaces then  
                if (string.IsNullOrWhiteSpace(fee_oma_ind_card_required[pc_year, cntr])) {
                            cnum = 80;
                }
                // 	    else if fee-oma-ind-card-required(pc-year,cntr) not = 'Y' and not = 'N' and not = 'R' then            
                else if (fee_oma_ind_card_required[pc_year, cntr] != "Y" && fee_oma_ind_card_required[pc_year, cntr] != "N" && fee_oma_ind_card_required[pc_year, cntr] != "R" ) {
                              err_ind = 21;
                    // 		    perform za0-common-error	thru za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    //    go to ia1-i-o-suffixes.;
                    await ia1_i_o_suffixes();
                    return; 
                }
            }
        }

        private async Task ia1_99_exit()
        {

            //     exit.;
        }

        private async Task ja0_add_change_other_info()
        {

        }

        private async Task<string> ja0_05_page()
        {

            //     accept scr-curr-page-alpha.;
            Display("scr-other-info.", "scr-curr-page-alpha");
            await Prompt("fee_curr_page_alpha");
            fee_page_alpha = fee_curr_page_alpha;

            //     accept scr-curr-page-numeric.;
            Display("scr-other-info.", "scr-curr-page-numeric");
            await Prompt("fee_curr_page_numeric");
            fee_page = fee_curr_page_numeric;

            // if fee-curr-page-numeric > 0 and fee-curr-page-numeric < 200   then    
            if (fee_curr_page_numeric > 0 &&  fee_curr_page_numeric < 200 ) {
                // 	   next sentence;
            }
            else {
                     err_ind = 4;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-05-page.;                
                await ja0_05_page();
            }
            return string.Empty;
        }

        private async Task ja0_10_m_suffix()
        {

            //     accept scr-m-suffix.;
            Display("scr-other-info.", "scr-m-suffix");
            await Prompt("fee_special_m_suffix_ind");

            //  if fee-special-m-suffix-ind =  "Y" or "N" then    
            if (Util.Str(fee_special_m_suffix_ind).ToUpper() == "Y" || Util.Str(fee_special_m_suffix_ind).ToUpper() == "N" ) {
                // 	   next sentence;
            }
            else {
                    err_ind = 5;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-10-m-suffix.;
                await ja0_10_m_suffix();
                return; 
            }
        }

        private async Task ja0_15_diag()
        {

            //     accept scr-diag.;
            Display("scr-other-info.", "scr-diag");
            await Prompt("fee_diag_ind");

            // if fee-diag-ind =  "Y" or "N" then            
            if (Util.Str(fee_diag_ind).ToUpper() == "Y" || Util.Str(fee_diag_ind).ToUpper() ==  "N" ) {
                // 	  next sentence;
            }
            else {
                     err_ind = 10;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-15-diag.;
                await ja0_15_diag();
                return; 
            }
        }

        private async Task ja0_20_ref_phys()
        {

            //     accept scr-ref-phys.;
            Display("scr-other-info.", "scr-ref-phys");
            await Prompt("fee_phy_ind");

            //  if fee-phy-ind =  "Y" or "N"  then            
            if (Util.Str(fee_phy_ind).ToUpper() == "Y" || Util.Str(fee_phy_ind).ToUpper() == "N" ) {
                //   	next sentence;
            }
            else {
                     err_ind = 11;
                // 	 perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	  go to ja0-20-ref-phys.;
                await ja0_20_ref_phys();
                return; 
            }
        }

        private async Task ja0_25_hosp_nbr()
        {
            //     accept scr-hosp-nbr.;
            Display("scr-other-info.", "scr-hosp-nbr");
            await Prompt("fee_hosp_nbr_ind");

            //  if fee-hosp-nbr-ind =  "Y" or "N" then            
            if (Util.Str(fee_hosp_nbr_ind).ToUpper() == "Y" || Util.Str(fee_hosp_nbr_ind).ToUpper() == "N" ) {
                // 	    next sentence;
            }
            else {
                    err_ind = 12;
                //   perform za0-common-error	thru	za0-99-exit;
                 await za0_common_error();
                await za0_99_exit();

                //   go to ja0-25-hosp-nbr.;
                await ja0_25_hosp_nbr();
                return; 
            }
        }

        private async Task ja0_30_in_out()
        {

            //     accept scr-in-out.;
            Display("scr-other-info.", "scr-in-out");
            await Prompt("fee_i_o_ind");

            // if fee-i-o-ind =  "B" or "I" or "O" then       
            if (Util.Str(fee_i_o_ind).ToUpper() == "B" || Util.Str(fee_i_o_ind).ToUpper() == "I" || Util.Str(fee_i_o_ind).ToUpper() == "O" ) {
                // 	   next sentence;
            }
            else {
                     err_ind = 13;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-30-in-out.;
                await ja0_30_in_out();
                return; 
            }
        }

        private async Task ja0_35_admit_dt()
        {

            //     accept scr-admit-dt.;
            Display("scr-other-info.", "scr-admit-dt");
            await Prompt("fee_admit_ind");

            // if fee-admit-ind =  "Y"  or "N" then            
            if (Util.Str(fee_admit_ind).ToUpper() == "Y"  || Util.Str(fee_admit_ind).ToUpper() == "N" ) {
                // 	   next sentence;
            }
            else {
                    err_ind = 14;
                // 	   perform za0-common-error	thru	za0-99-exit;
                await za0_common_error();
                await za0_99_exit();
                // 	   go to ja0-35-admit-dt.;
                await ja0_35_admit_dt();
                return; 
            }
        }

        private async Task ja0_99_exit()
        {

            //     exit.;
        }

        private async Task ka0_add_change_contd_info()
        {

            //  if add-code then;  
            if (entry_type.Equals(add_code) ) {
                fee_curr_add_on_perc_flat_ind = "";
            }

            ws_hold_perc_or_flat_ind = fee_curr_add_on_perc_flat_ind;
        }

        private async Task ka0_50_perc_flat()
        {

            // 	accept scr-curr-perc-flat;
            Display("scr-other-contd.", "scr-curr-perc-flat");
            await Prompt("fee_curr_add_on_perc_flat_ind");

            // 	if fee-curr-add-on-perc-flat-ind =    " "  or "F"  or "P"  or "B"  then    
            if (string.IsNullOrWhiteSpace(fee_curr_add_on_perc_flat_ind)  || Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "F"  || Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "P"  || Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B" ) {
                // 	    next sentence;
            }
            else {
                     err_ind = 17;
                // 	 perform za0-common-error		thru	za0-99-exit;
               await za0_common_error();
               await  za0_99_exit();

                // 	go to ka0-50-perc-flat.;
               await ka0_50_perc_flat();
                return; 
            }
        }

        private async Task ka0_60_both_perc_and_flat()
        {

            //  if  fee-curr-add-on-perc-flat-ind = "B" and fee-curr-add-on-perc-flat-ind not = ws-hold-perc-or-flat-ind then  
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B" && fee_curr_add_on_perc_flat_ind != ws_hold_perc_or_flat_ind ) {
                // 	    display	scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                // 		        scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                // 		        scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");
                // 		        scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");
                // 		        scr-a-prev-h-1;
                Display("scr-rate-info.", "scr-a-prev-h-1");
                // 		        scr-a-prev-h-2;
                Display("scr-rate-info.", "scr-a-prev-h-2");
                // 		        scr-a-prev-a-1;
                Display("scr-rate-info.", "scr-a-prev-a-1");
                // 		        scr-a-prev-a-2;
                Display("scr-rate-info.", "scr-a-prev-a-2");

                // 		 accept  scr-curr-h-1;
                // 		 display scr-curr-h-1;
                Display("scr-rate-info.", "scr-curr-h-1");
                await Prompt("fee_curr_h_fee_1", "scr-rate-info.", "scr-curr-h-1");
                fee_1[1, 2] = fee_curr_h_fee_1;

                fee_curr_a_fee_1 = fee_curr_h_fee_1;
                // 		 accept  scr-curr-h-2;
                // 		 display scr-curr-h-2;
                Display("scr-rate-info.", "scr-curr-h-2");
                await Prompt("fee_curr_h_fee_2");
                fee_2[1, 2] = fee_curr_h_fee_2;

                fee_curr_a_fee_2 = fee_curr_h_fee_2;
                fee_2[1,1] = fee_curr_h_fee_2; ;
                // 		 display	scr-curr-a-1;
                Display("scr-rate-info.", "scr-curr-a-1");
                // 		 display scr-curr-a-2;
                Display("scr-rate-info.", "scr-curr-a-2");
                // 	     if   fee-curr-h-fee-1 > 1.01  or fee-curr-h-fee-2 < 1.00 then 
                if (fee_curr_h_fee_1 > 1.01M  ||  fee_curr_h_fee_2 < 1.00M ) {
                               err_ind = 19;
                    //       perform za0-common-error	thru 	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	  go to ka0-60-both-perc-and-flat.;
                    await ka0_60_both_perc_and_flat();
                    return; 
                }
            }

            //     accept scr-from.;
            Display("scr-other-contd.", "scr-from");
            await Prompt("fee_spec_fr");

            //     accept scr-to.;
            Display("scr-other-contd.", "scr-to");
            await Prompt("fee_spec_to");
        }

        private async Task ka0_99_exit()
        {

            //     exit.;
        }

        private async Task la0_write_new_rec()
        {

            //  write fee-mstr-rec;
            if (await Write_OmaFee_Mstr_Record() == false) {
                //   	invalid key;
                // 	       perform err-oma-fee-mstr.;
                await err_oma_fee_mstr();
            }

            //   add 1				to	ctr-fee-mstr-writes;
            // 						ctr-fee-mstr-adds.;

            ctr_fee_mstr_writes++;
            ctr_fee_mstr_adds++;
        }

        private async Task la0_99_exit()
        {

            //     exit.;
        }

        private async Task na0_re_write_rec()
        {

            //     rewrite fee-mstr-rec.;
            await ReWrite_OmaFee_Mstr_Record();

            //     add 1				to	ctr-fee-mstr-writes;
            // 						ctr-fee-mstr-changes.;

            ctr_fee_mstr_writes++;
            ctr_fee_mstr_changes++;
        }

        private async Task na0_99_exit()
        {

            //     exit.;
        }

        private async Task pa0_delete_rec()
        {

            //     delete oma-fee-mstr record.;
            //     add 1				to	ctr-fee-mstr-deletes.;

            objFee_mstr_rec.Delete();
            ctr_fee_mstr_deletes++;
        }

        private async Task pa0_99_exit()
        {

            //     exit.;
        }

        private async Task ra0_print_audit()
        {

            objAudit_record.Audit_record1 = Util.Str(entry_type).PadRight(7) + new string(' ', 1) + await OmaFee_Mster_Rec_To_GroupName();
            //     write audit-record.;
            objAuditFile.AppendOutputFile(objAudit_record.Audit_record1);

        }

        private async Task ra0_99_exit()
        {

            //     exit.;
        }

        private async Task sa0_password()
        {

            password_flag = "N";
            ws_entered_password = "";

            // display scr-password-prompt.;
            // accept scr-password.;
            Display("scr-password-prompt.", "scr-password");
            await Prompt("ws_entered_password");

            // if ws-entered-password = ws-valid-password then 
            if (ws_entered_password == ws_valid_password) {
                  password_flag = "Y";
            }
        }

        private async Task sa0_99_exit()
        {

            //     exit.;
        }

        private async Task<string>  ta0_prev_yr_modify()
        {

            //     perform fa0-display-rates thru fa0-99-exit.;
            await fa0_display_rates();
            await fa0_99_exit();

            //  if fee-icc-sec = "CP"  then 
            if (fee_icc_sec == "CP") {
                // 	    accept	scr-a-prev-h-oth;
                // 	    display scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-oth");
                fee_1[2, 2] = fee_prev_h_fee_1;

                // 	    accept	scr-a-prev-h-anae;
                // 	    display scr-a-prev-h-anae;
                Display("scr-rate-info.", "scr-a-prev-h-anae");
                await Prompt("fee_prev_h_anae");
                fee_anae[2, 2] = fee_prev_h_anae;

                     fee_prev_h_fee_2 = 0;
                fee_2[2, 2] = 0;
                     fee_prev_h_asst = 0;
                fee_asst[2, 2] = 0;
                     fee_prev_a_fee_2 = 0;
                fee_2[2, 1] = 0;
                     fee_prev_a_asst = 0;
                fee_asst[2, 1] = 0;

                     fee_prev_a_fee_1 = fee_prev_h_fee_1;
                fee_1[2,1] = fee_prev_h_fee_1; 
                fee_prev_a_anae = fee_prev_h_anae;
                fee_anae[2,1] = fee_prev_h_anae;
                // 	    display scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");
                await Prompt("fee_prev_a_fee_1", "scr-rate-info.", "scr-a-prev-a-oth");
                fee_1[2, 1] = fee_prev_a_fee_1;

                // 	    display scr-a-prev-a-anae;
                Display("scr-rate-info.", "scr-a-prev-a-anae");
                await Prompt("fee_prev_a_anae");
                fee_anae[2, 1] = fee_prev_a_anae;

                // 	    if    fee-prev-h-fee-1 = 0 or fee-prev-h-anae  = 0  then 
                if (fee_prev_h_fee_1 == 0 || fee_prev_h_anae == 0 ) {
                              err_ind = 6;
                    // 	         perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	         go to ta0-99-exit;                    
                    return "ta0_99_exit";
                }
                else {
                    // 	  go to ta0-99-exit.;                    
                    return "ta0_99_exit";
                }
            }
            return string.Empty;
        }

        private async Task<string> ta0_10_add_change_cv()
        {

            // if fee-icc-sec = "CV" then
            if (fee_icc_sec == "CV") {
                // 	   accept  scr-a-prev-h-oth;
                // 	   display scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-oth");
                fee_1[2, 2] = fee_prev_h_fee_1;

                     fee_prev_h_fee_2 = 0;
                fee_2[2, 2] = 0;
                     fee_prev_h_anae = 0;
                fee_anae[2, 2] = 0;
                     fee_prev_h_asst = 0;
                fee_asst[2, 2] = 0;
                     fee_prev_a_fee_2 = 0;
                fee_2[2, 1] = 0;
                     fee_prev_a_anae = 0;
                fee_anae[2, 1] = 0;
                     fee_prev_a_asst = 0;
                fee_asst[2, 1] = 0;

                fee_prev_a_fee_1 = fee_prev_h_fee_1;
                fee_1[2,1] = fee_prev_h_fee_1;
                // 	display scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");

                // 	if   fee-prev-h-fee-1 = 0 then
                if (fee_prev_h_fee_1 == 0)
                {
                          err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                    await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ta0-99-exit;                    
                    return "ta0_99_exit";
                }
                else {
                    // 	    go to ta0-99-exit.;                   
                    return "ta0_99_exit";
                }
            }

            return string.Empty;
        }

        private async Task<string> ta0_20_add_change_dr_etc()
        {

            //  if fee-icc-sec =  "DR"  or "DU" or "NM"  or "PF" then
            if (Util.Str(fee_icc_sec).ToUpper() == "DR"  || Util.Str(fee_icc_sec).ToUpper() == "DU" || Util.Str(fee_icc_sec).ToUpper() == "NM"  || Util.Str(fee_icc_sec).ToUpper() == "PF") {
                // 	    accept  scr-a-prev-h-1;
                // 	    display scr-a-prev-h-1;
                Display("scr-rate-info.", "scr-a-prev-h-1");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-1");
                fee_1[2, 2] = fee_prev_h_fee_1;

                // 	    accept	scr-a-prev-h-2;
                // 	    display scr-a-prev-h-2;
                Display("scr-rate-info.", "scr-a-prev-h-2");
                await Prompt("fee_prev_h_fee_2");
                fee_2[2, 2] = fee_prev_h_fee_2;

                      fee_prev_h_anae = 0;
                fee_anae[2, 2] = 0;
                      fee_prev_h_asst = 0;
                fee_asst[2, 2] = 0;
                      fee_prev_a_anae = 0;
                fee_anae[2, 1] = 0;
                      fee_prev_a_asst = 0;
                fee_asst[2, 1] = 0;

                fee_prev_a_fee_1 = fee_prev_h_fee_1;
                fee_1[2,1] = fee_prev_h_fee_1;
                fee_prev_a_fee_2 = fee_prev_h_fee_2;
                fee_2[2,1] = fee_prev_h_fee_2;
                // 	display scr-a-prev-a-1;
                Display("scr-rate-info.", "scr-a-prev-a-1");

                // 	display scr-a-prev-a-2;
                Display("scr-rate-info.", "scr-a-prev-a-2");

                // 	if  fee-prev-h-fee-1 = 0 or fee-prev-h-fee-2 = 0  then
                if (fee_prev_h_fee_1 == 0 || fee_prev_h_fee_2 == 0 ) {
                          err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                   await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ta0-99-exit;                   
                    return "ta0_99_exit";
                }
                else {
                    // 	    go to ta0-99-exit.;                    
                    return "ta0_99_exit";
                }
            }

            return string.Empty;
        }

        private async Task<string> ta0_30_add_change_dt()
        {

            //  if fee-icc-sec = "DT" then            
            if (fee_icc_sec == "DT") {
                // 	   accept  scr-a-prev-h-oth;
                // 	   display scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-oth");
                fee_1[2, 2] = fee_prev_h_fee_1;

                // 	   accept  scr-a-prev-h-anae;
                // 	   display scr-a-prev-h-anae;
                Display("scr-rate-info.", "scr-a-prev-h-anae");
                await Prompt("fee_prev_h_anae");
                fee_anae[2, 2] = fee_prev_h_anae;

                fee_prev_h_fee_2 = fee_prev_h_fee_1;
                fee_2[2,2] = fee_prev_h_fee_1;
                fee_prev_a_fee_1 = fee_prev_h_fee_1;
                fee_1[2,1] = fee_prev_h_fee_1;
                fee_prev_a_fee_2 = fee_prev_h_fee_1;
                fee_2[2,1] = fee_prev_h_fee_1;

                fee_prev_a_anae = fee_prev_h_anae;
                fee_anae[2,1] = fee_prev_h_anae;
                fee_prev_h_asst = 0;
                fee_asst[2, 2] = 0;
                 fee_prev_a_asst = 0;
                fee_asst[2, 1] = 0;

                // 	display scr-a-prev-a-oth;
                Display("scr-rate-info.", "scr-a-prev-a-oth");

                // 	display scr-a-prev-a-anae;
                Display("scr-rate-info.", "scr-a-prev-a-anae");

                // 	if  fee-prev-h-fee-1 = 0 or fee-prev-h-anae  = 0  then 
                if (fee_prev_h_fee_1 == 0 || fee_prev_h_anae == 0 ) {
                          err_ind = 6;
                    // 	    perform za0-common-error	thru	za0-99-exit;
                   await za0_common_error();
                    await za0_99_exit();
                    // 	    go to ta0-99-exit;                   
                    return "ta0_99_exit";
                }
                else {
                    // 	    go to ta0-99-exit.;                   
                    return "ta0_99_exit";
                }
            }
            return string.Empty;
        }

        private async Task ta0_40_add_change_sp()
        {

            //  if fee-curr-add-on-perc-flat-ind = "B" then 
            if (Util.Str(fee_curr_add_on_perc_flat_ind).ToUpper() == "B") {
                // 	   accept  scr-a-prev-h-1;
                // 	   display scr-a-prev-h-1;
                Display("scr-rate-info.", "scr-a-prev-h-1");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-1");
                fee_1[2, 2] = fee_prev_h_fee_1;

                // 	   accept  scr-a-prev-h-2;
                //     display scr-a-prev-h-2;
                Display("scr-rate-info.", "scr-a-prev-h-2");
                await Prompt("fee_prev_h_fee_2");
                fee_2[2, 2] = fee_prev_h_fee_2;
            }
            else {
                // 	   accept  scr-a-prev-h-oth;
                // 	   display scr-a-prev-h-oth;
                Display("scr-rate-info.", "scr-a-prev-h-oth");
                await Prompt("fee_prev_h_fee_1", "scr-rate-info.", "scr-a-prev-h-oth");
                fee_1[2, 2] = fee_prev_h_fee_1;
                fee_curr_h_fee_2 = fee_curr_h_fee_1;
            }


            //     accept  scr-a-prev-h-anae.;
            //     display scr-a-prev-h-anae.;
            Display("scr-rate-info.", "scr-a-prev-h-anae");
            await Prompt("fee_prev_h_anae");
            fee_anae[2, 2] = fee_prev_h_anae;

            //     accept  scr-a-prev-h-asst.;
            //     display scr-a-prev-h-asst.;
            Display("scr-rate-info.", "scr-a-prev-h-asst");
            await Prompt("fee_prev_h_asst");
            fee_asst[2, 2] = fee_prev_h_asst;

            fee_prev_a_fee_1 = fee_prev_h_fee_1;
            fee_1[2,1] = fee_prev_h_fee_1;
            fee_prev_a_fee_2 = fee_prev_h_fee_2;
            fee_2[2,1] = fee_prev_h_fee_2;
            fee_prev_a_anae = fee_prev_h_anae;
            fee_anae[2,1] = fee_prev_h_anae;
            fee_prev_a_asst = fee_prev_h_asst;
            fee_asst[2,1] = fee_prev_h_asst;

            //     display scr-a-prev-a-oth.;
            Display("scr-rate-info.", "scr-a-prev-a-oth");

            //     display scr-a-prev-a-asst.;
            Display("scr-rate-info.", "scr-a-prev-a-asst");

            //     display scr-a-prev-a-anae.;
            Display("scr-rate-info.", "scr-a-prev-a-anae");

            // if  fee-prev-h-fee-1 = zero  or fee-prev-h-fee-2 = zero  or fee-prev-h-anae  = zero  or fee-prev-h-asst  = zero  then
            if (fee_prev_h_fee_1 == 0  || fee_prev_h_fee_2 == 0  || fee_prev_h_anae == 0  || fee_prev_h_asst == 0) {
                     err_ind = 6;
                // 	   perform za0-common-error 	thru	za0-99-exit.;
                await za0_common_error();
                await za0_99_exit();
            }
        }

        private async Task ta0_99_exit()
        {

            //     exit.;
        }

        private async Task za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-line.;
            Display("err-msg-line.");

            //     accept scr-confirm.;
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

        private async Task OmaFee_Mstr_Record_To_ScreenVariables_bak()
        {

            fee_oma_cd_ltr1 = Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1);
            fee_special_m_suffix_ind = Util.Str(objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND);

            fee_date_yy = Util.NumInt(objFee_mstr_rec.FEE_DATE_YY);
            fee_date_mm = Util.NumInt(objFee_mstr_rec.FEE_DATE_MM);
            fee_date_dd = Util.NumInt(objFee_mstr_rec.FEE_DATE_DD);
            fee_effective_date_grp = Util.Str(fee_date_yy).PadLeft(4, '0') + Util.Str(fee_date_mm).PadLeft(2, '0') + Util.Str(fee_date_dd).PadLeft(2, '0');

            fee_active_for_entry = Util.Str(objFee_mstr_rec.FEE_ACTIVE_FOR_ENTRY);
            fee_desc = Util.Str(objFee_mstr_rec.FEE_DESC);

            // string fee_current_prev_years_grp
            fee_curr_a_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_1);
            fee_curr_h_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1);
            fee_curr_a_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_2);
            fee_curr_h_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2);
            fee_curr_a_min = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MIN);
            fee_curr_h_min = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MIN);
            fee_curr_a_max = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MAX);
            fee_curr_h_max = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MAX);

            fee_curr_a_anae = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ANAE);
            fee_curr_h_anae = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);
            fee_curr_a_asst = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ASST);
            fee_curr_h_asst = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);

            //fee_curr_add_on_codes_grp
            fee_curr_add_on_cd[1] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD1);
            fee_curr_add_on_cd[2] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD2);
            fee_curr_add_on_cd[3] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD3);
            fee_curr_add_on_cd[4] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD4);
            fee_curr_add_on_cd[5] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD5);
            fee_curr_add_on_cd[6] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD6);
            fee_curr_add_on_cd[7] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD7);
            fee_curr_add_on_cd[8] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD8);
            fee_curr_add_on_cd[9] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD9);
            fee_curr_add_on_cd[10] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD10);

            //fee_curr_oma_ind_card_reqs_grp;
            fee_curr_oma_ind_card_required[1] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1);
            fee_curr_oma_ind_card_required[2] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            fee_curr_oma_ind_card_required[3] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3);

            fee_prev_oma_ind_card_required[1] = objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1;
            fee_prev_oma_ind_card_required[2] = objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2;
            fee_prev_oma_ind_card_required[3] = objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3;

            fee_curr_page_alpha = Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_ALPHA);
            fee_curr_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC);
            fee_curr_page_grp = Util.Str(fee_curr_page_alpha).PadRight(2) + Util.Str(fee_curr_page_numeric).PadLeft(3, '0');

            fee_prev_page_alpha = objFee_mstr_rec.FEE_PREV_PAGE_ALPHA;
            fee_prev_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC);

            fee_curr_add_on_perc_flat_ind = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND);
            fee_prev_a_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_1);
            fee_prev_h_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_1);
            fee_prev_a_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_2);
            fee_prev_h_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_2);
            fee_prev_a_min = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MIN);
            fee_prev_h_min = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MIN);
            fee_prev_a_max = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MAX);
            fee_prev_h_max = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MAX);
            fee_prev_a_anae = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ANAE);
            fee_prev_h_anae = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ANAE);
            fee_prev_a_asst = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ASST);
            fee_prev_h_asst = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ASST);

            //fee_prev_add_on_codes_grp;
            fee_prev_add_on_cd[1] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD1);
            fee_prev_add_on_cd[2] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD2);
            fee_prev_add_on_cd[3] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD3);
            fee_prev_add_on_cd[4] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD4);
            fee_prev_add_on_cd[5] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD5);
            fee_prev_add_on_cd[6] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD6);
            fee_prev_add_on_cd[7] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD7);
            fee_prev_add_on_cd[8] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD8);
            fee_prev_add_on_cd[9] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD9);
            fee_prev_add_on_cd[10] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD10);

            //fee_prev_oma_ind_card_reqs_grp;
            fee_prev_oma_ind_card_required[1] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            fee_prev_oma_ind_card_required[2] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            fee_prev_oma_ind_card_required[3] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3);
            
            fee_prev_page_alpha = Util.Str(objFee_mstr_rec.FEE_PREV_PAGE_ALPHA);
            fee_prev_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC);
            fee_prev_page_grp = Util.Str(fee_prev_page_alpha).PadRight(2) + Util.Str(fee_prev_page_numeric).PadLeft(3, '0');

            fee_prev_add_on_perc_flat_ind = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND);

            //fee_current_prev_year_r;
            // string[] fee_years = new string[3];   //todo...????
            fee_1[1,1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_1);
            fee_1[1,2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1);

            fee_1[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_1);
            fee_1[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_1);

            fee_2[1,1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_2);
            fee_2[1,2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2);

            fee_2[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_2);
            fee_2[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_2);

            fee_min[1,1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MIN);
            fee_min[1,2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MIN);

            fee_min[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MIN);
            fee_min[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MIN);

            fee_max[1,1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MAX);
            fee_max[1,2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MAX);

            fee_max[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MAX);
            fee_max[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MAX);

            fee_anae[1,1] = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ANAE);
            fee_anae[1,2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);

            fee_anae[2, 1] = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ANAE);
            fee_anae[2, 2] = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ANAE);

            fee_asst[1,1] = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ASST);
            fee_asst[1,2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);

            fee_asst[2, 1] = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ASST);
            fee_asst[2, 2] = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ASST);

            //fee_add_on_codes_grp;
            fee_add_on_cd[1,1] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD1);
            fee_add_on_cd[1,2] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD2);
            fee_add_on_cd[1,3] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD3);
            fee_add_on_cd[1,4] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD4);
            fee_add_on_cd[1,5] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD5);
            fee_add_on_cd[1,6] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD6);
            fee_add_on_cd[1,7] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD7);
            fee_add_on_cd[1,8] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD8);
            fee_add_on_cd[1,9] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD9);
            fee_add_on_cd[1,10] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD10);

            fee_add_on_cd[2, 1] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD1);
            fee_add_on_cd[2, 2] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD2);
            fee_add_on_cd[2, 3] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD3);
            fee_add_on_cd[2, 4] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD4);
            fee_add_on_cd[2, 5] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD5);
            fee_add_on_cd[2, 6] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD6);
            fee_add_on_cd[2, 7] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD7);
            fee_add_on_cd[2, 8] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD8);
            fee_add_on_cd[2, 9] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD9);
            fee_add_on_cd[2, 10] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD10);

            // fee_oma_ind_card_requireds_grp;
            fee_oma_ind_card_required[1,1] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1);
            fee_oma_ind_card_required[1,2] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            fee_oma_ind_card_required[1,3] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3);

            fee_oma_ind_card_required[2, 1] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            fee_oma_ind_card_required[2, 2] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            fee_oma_ind_card_required[2, 3] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3);

            fee_page_alpha = Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_ALPHA);
            fee_page = Util.NumInt(objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC);
            fee_page_alpha_numeric_grp = Util.Str(fee_page_alpha).PadRight(2) + Util.Str(fee_page).PadLeft(3, '0');

            fee_add_on_perc_or_flat_ind = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND);
            
            fee_icc_sec = Util.Str(objFee_mstr_rec.FEE_ICC_SEC);
            fee_icc_cat = Util.NumInt(objFee_mstr_rec.FEE_ICC_CAT);
            fee_icc_grp = Util.NumInt(objFee_mstr_rec.FEE_ICC_GRP);
            fee_icc_reduc_ind = Util.NumInt(objFee_mstr_rec.FEE_ICC_REDUC_IND);
            fee_icc_code_grp = Util.Str(fee_icc_sec).PadRight(2) + Util.Str(fee_icc_cat).PadLeft(1, '0') + Util.Str(fee_icc_grp).PadLeft(2, '0') + Util.Str(fee_icc_reduc_ind).PadLeft(1, '0');
            fee_icc_code = fee_icc_code_grp;

            fee_diag_ind = Util.Str(objFee_mstr_rec.FEE_DIAG_IND);
            fee_phy_ind = Util.Str(objFee_mstr_rec.FEE_PHY_IND);
            fee_tech_ind = Util.Str(objFee_mstr_rec.FEE_TECH_IND);
            fee_hosp_nbr_ind = Util.Str(objFee_mstr_rec.FEE_HOSP_NBR_IND);
            fee_i_o_ind = Util.Str(objFee_mstr_rec.FEE_I_O_IND);
            fee_admit_ind = Util.Str(objFee_mstr_rec.FEE_ADMIT_IND);
            fee_spec_fr = Util.NumInt(objFee_mstr_rec.FEE_SPEC_FR);
            fee_spec_to = Util.NumInt(objFee_mstr_rec.FEE_SPEC_TO);
            fee_global_addon_cd_exclusion = Util.Str(objFee_mstr_rec.FEEGLOBALADDONCDEXCLUSIONFLAG);
    }

        private async Task OmaFee_Mstr_Record_To_ScreenVariables()
        {

            fee_oma_cd_ltr1 = Util.Str(objFee_mstr_rec.FEE_OMA_CD_LTR1);
            fee_oma_cd = fee_oma_cd_ltr1 + Util.Str(objFee_mstr_rec.FILLER_NUMERIC);
            fee_special_m_suffix_ind = Util.Str(objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND);

            fee_date_yy = Util.NumInt(objFee_mstr_rec.FEE_DATE_YY);
            fee_date_mm = Util.NumInt(objFee_mstr_rec.FEE_DATE_MM);
            fee_date_dd = Util.NumInt(objFee_mstr_rec.FEE_DATE_DD);
            fee_effective_date_grp = Util.Str(fee_date_yy).PadLeft(4, '0') + Util.Str(fee_date_mm).PadLeft(2, '0') + Util.Str(fee_date_dd).PadLeft(2, '0');

            fee_active_for_entry = Util.Str(objFee_mstr_rec.FEE_ACTIVE_FOR_ENTRY);
            fee_desc = Util.Str(objFee_mstr_rec.FEE_DESC);

            // string fee_current_prev_years_grp
            fee_curr_a_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_1);
            fee_curr_h_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1);
            fee_curr_a_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_2);
            fee_curr_h_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2);
            fee_curr_a_min = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MIN);
            fee_curr_h_min = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MIN);
            fee_curr_a_max = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MAX);
            fee_curr_h_max = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MAX);
            fee_curr_a_anae = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ANAE);
            fee_curr_h_anae = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);
            fee_curr_a_asst = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ASST);
            fee_curr_h_asst = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);

            //fee_curr_add_on_codes_grp
            fee_curr_add_on_cd[1] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD1);
            fee_curr_add_on_cd[2] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD2);
            fee_curr_add_on_cd[3] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD3);
            fee_curr_add_on_cd[4] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD4);
            fee_curr_add_on_cd[5] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD5);
            fee_curr_add_on_cd[6] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD6);
            fee_curr_add_on_cd[7] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD7);
            fee_curr_add_on_cd[8] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD8);
            fee_curr_add_on_cd[9] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD9);
            fee_curr_add_on_cd[10] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD10);

            //fee_curr_oma_ind_card_reqs_grp;
            fee_curr_oma_ind_card_required[1] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1);
            fee_curr_oma_ind_card_required[2] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            fee_curr_oma_ind_card_required[3] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3);

            fee_prev_oma_ind_card_required[1] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            fee_prev_oma_ind_card_required[2] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            fee_prev_oma_ind_card_required[3] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3);

            fee_curr_page_alpha = Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_ALPHA);
            fee_curr_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC);
            fee_curr_page_grp = Util.Str(fee_curr_page_alpha).PadRight(2) + Util.Str(fee_curr_page_numeric).PadLeft(3, '0');

            // fee_prev_page_alpha = objFee_mstr_rec.FEE_PREV_PAGE_ALPHA;
            // fee_prev_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC);

            fee_curr_add_on_perc_flat_ind = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND);
            fee_prev_a_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_1);
            fee_prev_h_fee_1 = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_1);
            fee_prev_a_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_2);
            fee_prev_h_fee_2 = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_2);
            fee_prev_a_min = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MIN);
            fee_prev_h_min = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MIN);
            fee_prev_a_max = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MAX);
            fee_prev_h_max = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MAX);
            fee_prev_a_anae = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ANAE);
            fee_prev_h_anae = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ANAE);
            fee_prev_a_asst = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ASST);
            fee_prev_h_asst = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ASST);

            //fee_prev_add_on_codes_grp;
            fee_prev_add_on_cd[1] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD1);
            fee_prev_add_on_cd[2] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD2);
            fee_prev_add_on_cd[3] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD3);
            fee_prev_add_on_cd[4] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD4);
            fee_prev_add_on_cd[5] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD5);
            fee_prev_add_on_cd[6] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD6);
            fee_prev_add_on_cd[7] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD7);
            fee_prev_add_on_cd[8] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD8);
            fee_prev_add_on_cd[9] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD9);
            fee_prev_add_on_cd[10] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD10);

            //fee_prev_oma_ind_card_reqs_grp;
            fee_prev_oma_ind_card_required[1] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            fee_prev_oma_ind_card_required[2] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            fee_prev_oma_ind_card_required[3] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3);

            fee_prev_page_alpha = Util.Str(objFee_mstr_rec.FEE_PREV_PAGE_ALPHA);
            fee_prev_page_numeric = Util.NumInt(objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC);
            fee_prev_page_grp = Util.Str(fee_prev_page_alpha).PadRight(2) + Util.Str(fee_prev_page_numeric).PadLeft(3, '0');



            //fee_current_prev_year_r;
            // string[] fee_years = new string[3];   //todo...????
            fee_1[1, 1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_1);
            fee_1[1, 2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_1);

            fee_1[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_1);
            fee_1[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_1);

            fee_2[1, 1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_FEE_2);
            fee_2[1, 2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_FEE_2);

            fee_2[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_FEE_2);
            fee_2[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_FEE_2);

            fee_min[1, 1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MIN);
            fee_min[1, 2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MIN);

            fee_min[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MIN);
            fee_min[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MIN);

            fee_max[1, 1] = Util.NumDec(objFee_mstr_rec.FEE_CURR_A_MAX);
            fee_max[1, 2] = Util.NumDec(objFee_mstr_rec.FEE_CURR_H_MAX);

            fee_max[2, 1] = Util.NumDec(objFee_mstr_rec.FEE_PREV_A_MAX);
            fee_max[2, 2] = Util.NumDec(objFee_mstr_rec.FEE_PREV_H_MAX);

            fee_anae[1, 1] = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ANAE);
            fee_anae[1, 2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ANAE);

            fee_anae[2, 1] = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ANAE);
            fee_anae[2, 2] = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ANAE);

            fee_asst[1, 1] = Util.NumInt(objFee_mstr_rec.FEE_CURR_A_ASST);
            fee_asst[1, 2] = Util.NumInt(objFee_mstr_rec.FEE_CURR_H_ASST);

            fee_asst[2, 1] = Util.NumInt(objFee_mstr_rec.FEE_PREV_A_ASST);
            fee_asst[2, 2] = Util.NumInt(objFee_mstr_rec.FEE_PREV_H_ASST);

            //fee_add_on_codes_grp;
            fee_add_on_cd[1, 1] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD1);
            fee_add_on_cd[1, 2] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD2);
            fee_add_on_cd[1, 3] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD3);
            fee_add_on_cd[1, 4] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD4);
            fee_add_on_cd[1, 5] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD5);
            fee_add_on_cd[1, 6] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD6);
            fee_add_on_cd[1, 7] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD7);
            fee_add_on_cd[1, 8] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD8);
            fee_add_on_cd[1, 9] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD9);
            fee_add_on_cd[1, 10] = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_CD10);

            fee_add_on_cd[2, 1] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD1);
            fee_add_on_cd[2, 2] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD2);
            fee_add_on_cd[2, 3] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD3);
            fee_add_on_cd[2, 4] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD4);
            fee_add_on_cd[2, 5] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD5);
            fee_add_on_cd[2, 6] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD6);
            fee_add_on_cd[2, 7] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD7);
            fee_add_on_cd[2, 8] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD8);
            fee_add_on_cd[2, 9] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD9);
            fee_add_on_cd[2, 10] = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_CD10);

            // fee_oma_ind_card_requireds_grp;
            fee_oma_ind_card_required[1, 1] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1);
            fee_oma_ind_card_required[1, 2] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            fee_oma_ind_card_required[1, 3] = Util.Str(objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3);

            fee_oma_ind_card_required[2, 1] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            fee_oma_ind_card_required[2, 2] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            fee_oma_ind_card_required[2, 3] = Util.Str(objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3);

            fee_page_alpha = Util.Str(objFee_mstr_rec.FEE_CURR_PAGE_ALPHA);
            fee_page = Util.NumInt(objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC);
            fee_page_alpha_numeric_grp = Util.Str(fee_page_alpha).PadRight(2) + Util.Str(fee_page).PadLeft(3, '0');

            fee_add_on_perc_or_flat_ind = Util.Str(objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND);
            fee_prev_add_on_perc_flat_ind = Util.Str(objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND);

            fee_icc_sec = Util.Str(objFee_mstr_rec.FEE_ICC_SEC);
            fee_icc_cat = Util.NumInt(objFee_mstr_rec.FEE_ICC_CAT);
            fee_icc_grp = Util.NumInt(objFee_mstr_rec.FEE_ICC_GRP);
            fee_icc_reduc_ind = Util.NumInt(objFee_mstr_rec.FEE_ICC_REDUC_IND);
            fee_icc_code_grp = Util.Str(fee_icc_sec).PadRight(2) + Util.Str(fee_icc_cat).PadLeft(1, '0') + Util.Str(fee_icc_grp).PadLeft(2, '0') + Util.Str(fee_icc_reduc_ind).PadLeft(1, '0');
            fee_icc_code = fee_icc_code_grp;

            fee_diag_ind = Util.Str(objFee_mstr_rec.FEE_DIAG_IND);
            fee_phy_ind = Util.Str(objFee_mstr_rec.FEE_PHY_IND);
            fee_tech_ind = Util.Str(objFee_mstr_rec.FEE_TECH_IND);
            fee_hosp_nbr_ind = Util.Str(objFee_mstr_rec.FEE_HOSP_NBR_IND);
            fee_i_o_ind = Util.Str(objFee_mstr_rec.FEE_I_O_IND);
            fee_admit_ind = Util.Str(objFee_mstr_rec.FEE_ADMIT_IND);
            fee_spec_fr = Util.NumInt(objFee_mstr_rec.FEE_SPEC_FR);
            fee_spec_to = Util.NumInt(objFee_mstr_rec.FEE_SPEC_TO);
            fee_global_addon_cd_exclusion = Util.Str(objFee_mstr_rec.FEEGLOBALADDONCDEXCLUSIONFLAG);
        }


        private async Task Initialize_OmaFee_Mstr_Record_ScreenVariables()
        {
            
            fee_oma_cd_ltr1 = "";
            fee_special_m_suffix_ind = "";

            fee_date_yy = 0;
            fee_date_mm = 0;
            fee_date_dd = 0;

            fee_active_for_entry = "";
            fee_desc = "";

            // string fee_current_prev_years_grp
            fee_curr_a_fee_1 = 0;
            fee_curr_h_fee_1 = 0;
            fee_curr_a_fee_2 = 0;
            fee_curr_h_fee_2 = 0;
            fee_curr_a_min = 0;
            fee_curr_h_min = 0;
            objFee_mstr_rec.FEE_CURR_A_MAX = fee_curr_a_max;
            objFee_mstr_rec.FEE_CURR_H_MAX = fee_curr_h_max;

            fee_curr_a_anae = 0;
            fee_curr_h_anae = 0;
            fee_curr_a_asst = 0;
            fee_curr_h_asst = 0;

            //fee_curr_add_on_codes_grp
            fee_curr_add_on_cd[1] = "";
            fee_curr_add_on_cd[2] = "";
            fee_curr_add_on_cd[3] = "";
            fee_curr_add_on_cd[4] = "";
            fee_curr_add_on_cd[5] = "";
            fee_curr_add_on_cd[6] = "";
            fee_curr_add_on_cd[7] = "";
            fee_curr_add_on_cd[8] = "";
            fee_curr_add_on_cd[9] = "";
            fee_curr_add_on_cd[10] = "";

            //fee_curr_oma_ind_card_reqs_grp;
            fee_curr_oma_ind_card_required[1] = "";
            fee_curr_oma_ind_card_required[2] = "";
            fee_curr_oma_ind_card_required[3] = "";

            fee_curr_page_alpha = "";
            fee_curr_page_numeric = 0;

            fee_curr_add_on_perc_flat_ind = "";
            fee_prev_a_fee_1 = 0;
            fee_prev_h_fee_1 = 0;
            fee_prev_a_fee_2 = 0;
            fee_prev_h_fee_2 = 0;
            fee_prev_a_min = 0;
            fee_prev_h_min = 0;
            fee_prev_a_max = 0;
            fee_prev_h_max = 0;
            fee_prev_a_anae = 0;
            fee_prev_h_anae = 0;
            fee_prev_a_asst = 0;
            fee_prev_h_asst = 0;

            //fee_prev_add_on_codes_grp;
            fee_prev_add_on_cd[1] = "";
            fee_prev_add_on_cd[2] = "";
            fee_prev_add_on_cd[3] = "";
            fee_prev_add_on_cd[4] = "";
            fee_prev_add_on_cd[5] = "";
            fee_prev_add_on_cd[6] = "";
            fee_prev_add_on_cd[7] = "";
            fee_prev_add_on_cd[8] = "";
            fee_prev_add_on_cd[9] = "";
            fee_prev_add_on_cd[10] = "";

            //fee_prev_oma_ind_card_reqs_grp;
            fee_prev_oma_ind_card_required[1] = "";
            fee_prev_oma_ind_card_required[2] = "";
            fee_prev_oma_ind_card_required[3] = "";

            fee_prev_page_alpha = "";
            fee_prev_page_numeric = 0;

            fee_prev_add_on_perc_flat_ind = "";

            //fee_current_prev_year_r;
            // string[] fee_years = new string[3];   //todo...????

            fee_1[1,1] = 0;
            fee_1[1,2] = 0;

            fee_1[2, 1] = 0;
            fee_1[2, 2] = 0;

            fee_2[1,1] = 0;
            fee_2[1,2] = 0;

            fee_2[2, 1] = 0;
            fee_2[2, 2] = 0;

            fee_min[1,1] = 0;
            fee_min[1,2] = 0;

            fee_min[2, 1] = 0;
            fee_min[2, 2] = 0;

            fee_max[1,1] = 0;
            fee_max[1,2] = 0;

            fee_max[2, 1] = 0;
            fee_max[2, 2] = 0;

            fee_anae[1,1] = 0;
            fee_anae[1,2] = 0;

            fee_anae[2, 1] = 0;
            fee_anae[2, 2] = 0;

            fee_asst[1,1] = 0;
            fee_asst[1,2] = 0;

            fee_asst[2, 1] = 0;
            fee_asst[2, 2] = 0;

            //fee_add_on_codes_grp;
            fee_add_on_cd[1,1] = "";
            fee_add_on_cd[1,2] = "";
            fee_add_on_cd[1,3] = "";
            fee_add_on_cd[1,4] = "";
            fee_add_on_cd[1,5] = "";
            fee_add_on_cd[1,6] = "";
            fee_add_on_cd[1,7] = "";
            fee_add_on_cd[1,8] = "";
            fee_add_on_cd[1,9] = "";
            fee_add_on_cd[1,10] = "";

            fee_add_on_cd[2, 1] = "";
            fee_add_on_cd[2, 2] = "";
            fee_add_on_cd[2, 3] = "";
            fee_add_on_cd[2, 4] = "";
            fee_add_on_cd[2, 5] = "";
            fee_add_on_cd[2, 6] = "";
            fee_add_on_cd[2, 7] = "";
            fee_add_on_cd[2, 8] = "";
            fee_add_on_cd[2, 9] = "";
            fee_add_on_cd[2, 10] = "";

            // fee_oma_ind_card_requireds_grp;
            fee_oma_ind_card_required[1,1] = "";
            fee_oma_ind_card_required[1,2] = "";
            fee_oma_ind_card_required[1,3] = "";

            fee_oma_ind_card_required[2, 1] = "";
            fee_oma_ind_card_required[2, 2] = "";
            fee_oma_ind_card_required[2, 3] = "";

            fee_page_alpha = "";
            fee_page = 0;

            fee_add_on_perc_or_flat_ind = "";

            fee_icc_sec = "";
            fee_icc_cat = 0;
            fee_icc_grp = 0;
            fee_icc_reduc_ind = 0;

            fee_diag_ind = "";
            fee_phy_ind = "";
            fee_tech_ind = "";
            fee_hosp_nbr_ind = "";
            fee_i_o_ind = "";
            fee_admit_ind = "";
            fee_spec_fr = 0;
            fee_spec_to = 0;
            fee_global_addon_cd_exclusion = "";
            
        }

        private async Task<string> OmaFee_Mster_Rec_To_GroupName()
        {

            fee_mstr_rec_grp = Util.Str(fee_oma_cd_ltr1).PadRight(1) +
                               "000" +
                               Util.Str(fee_special_m_suffix_ind).PadRight(1) +
                               Util.Str(fee_date_yy).PadLeft(4, '0') +
                               Util.Str(fee_date_mm).PadLeft(2, '0') +
                               Util.Str(fee_date_dd).PadLeft(2, '0') +
                               Util.Str(fee_active_for_entry).PadRight(1) +
                               Util.Str(fee_desc).PadRight(48) +
                               // string fee_current_prev_years_grp
                               Util.Str(fee_curr_a_fee_1).PadLeft(7, '0') +
                               Util.Str(fee_curr_h_fee_1).PadLeft(7, '0') +
                               Util.Str(fee_curr_a_fee_2).PadLeft(7, '0') +
                               Util.Str(fee_curr_h_fee_2).PadLeft(7, '0') +
                               Util.Str(fee_curr_a_min).PadLeft(7, '0') +
                               Util.Str(fee_curr_h_min).PadLeft(7, '0') +
                               Util.Str(fee_curr_a_max).PadLeft(7, '0') +
                               Util.Str(fee_curr_h_max).PadLeft(7, '0') +
                               Util.Str(fee_curr_a_anae).PadLeft(2, '0') +
                               Util.Str(fee_curr_h_anae).PadLeft(2, '0') +
                               Util.Str(fee_curr_a_asst).PadLeft(2, '0') +
                               Util.Str(fee_curr_h_asst).PadLeft(2, '0') +
                              //fee_curr_add_on_codes_grp
                              Util.Str(fee_curr_add_on_cd[1]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[2]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[3]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[4]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[5]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[6]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[7]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[8]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[9]).PadRight(4) +
                              Util.Str(fee_curr_add_on_cd[10]).PadRight(4) +

                             //fee_curr_oma_ind_card_reqs_grp;
                             Util.Str(fee_curr_oma_ind_card_required[1]).PadRight(1) +
                             Util.Str(fee_curr_oma_ind_card_required[2]).PadRight(1) +
                             Util.Str(fee_curr_oma_ind_card_required[3]).PadRight(1) +

                            Util.Str(fee_curr_page_alpha).PadRight(2) +
                             Util.Str(fee_curr_page_numeric).PadRight(3, '0') +

                             Util.Str(fee_curr_add_on_perc_flat_ind).PadRight(1) +
                            Util.Str(fee_prev_a_fee_1).PadLeft(7, '0') +
                            Util.Str(fee_prev_h_fee_1).PadLeft(7, '0') +
                            Util.Str(fee_prev_a_fee_2).PadLeft(7, '0') +
                            Util.Str(fee_prev_h_fee_2).PadLeft(7, '0') +
                            Util.Str(fee_prev_a_min).PadLeft(7, '0') +
                            Util.Str(fee_prev_h_min).PadLeft(7, '0') +
                            Util.Str(fee_prev_a_max).PadLeft(7, '0') +
                            Util.Str(fee_prev_h_max).PadLeft(7, '0') +
                            Util.Str(fee_prev_a_anae).PadLeft(2, '0') +
                            Util.Str(fee_prev_h_anae).PadLeft(2, '0') +
                            Util.Str(fee_prev_a_asst).PadLeft(2, '0') +
                            Util.Str(fee_prev_h_asst).PadLeft(2, '0') +

                           //fee_prev_add_on_codes_grp;
                           Util.Str(fee_prev_add_on_cd[1]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[2]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[3]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[4]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[5]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[6]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[7]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[8]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[9]).PadRight(4) +
                           Util.Str(fee_prev_add_on_cd[10]).PadRight(4) +

                          //fee_prev_oma_ind_card_reqs_grp;
                          Util.Str(fee_prev_oma_ind_card_required[1]).PadRight(1) +
                          Util.Str(fee_prev_oma_ind_card_required[2]).PadRight(1) +
                          Util.Str(fee_prev_oma_ind_card_required[3]).PadRight(1) +

                          Util.Str(fee_prev_page_alpha).PadRight(2) +
                          Util.Str(fee_prev_page_numeric).PadLeft(3, '0') +
                          Util.Str(fee_prev_add_on_perc_flat_ind).PadRight(1) +

                         Util.Str(fee_icc_sec).PadRight(2) +
                         Util.Str(fee_icc_cat).PadLeft(1, '0') +
                         Util.Str(fee_icc_grp).PadLeft(2, '0') +
                        Util.Str(fee_icc_reduc_ind).PadLeft(1, '0') +

                        Util.Str(fee_diag_ind).PadRight(1) +
                        Util.Str(fee_phy_ind).PadRight(1) +
                        Util.Str(fee_tech_ind).PadRight(1) +
                        Util.Str(fee_hosp_nbr_ind).PadRight(1) +
                        Util.Str(fee_i_o_ind).PadRight(1) +
                        Util.Str(fee_admit_ind).PadRight(1) +
                        Util.Str(fee_spec_fr).PadLeft(2, '0') +
                        Util.Str(fee_spec_to).PadLeft(2, '0') +
                        Util.Str(fee_global_addon_cd_exclusion).PadLeft(2, '0') +
                        new string(' ', 38);

            return fee_mstr_rec_grp;
        }

        private async Task<bool> Write_OmaFee_Mstr_Record()
        {
            try {

                F040_OMA_FEE_MSTR objFee_mstr_rec = null;
                objFee_mstr_rec = new F040_OMA_FEE_MSTR();

                objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(fee_oma_cd).PadRight(4).Substring(0, 1);
                objFee_mstr_rec.FILLER_NUMERIC = Util.Str(fee_oma_cd).PadRight(4).Substring(1, 3);
                objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND = Util.Str(fee_special_m_suffix_ind);

                objFee_mstr_rec.FEE_DATE_YY = Util.NumInt(fee_date_yy);
                objFee_mstr_rec.FEE_DATE_MM = Util.NumInt(fee_date_mm);
                objFee_mstr_rec.FEE_DATE_DD = Util.NumInt(fee_date_dd);

                objFee_mstr_rec.FEE_ACTIVE_FOR_ENTRY = Util.Str(fee_active_for_entry);
                objFee_mstr_rec.FEE_DESC = Util.Str(fee_desc);

                // string fee_current_prev_years_grp
                objFee_mstr_rec.FEE_CURR_A_FEE_1 =  Util.NumDec(fee_curr_a_fee_1);
                objFee_mstr_rec.FEE_CURR_H_FEE_1 = Util.NumDec(fee_curr_h_fee_1);
                objFee_mstr_rec.FEE_CURR_A_FEE_2 = Util.NumDec(fee_curr_a_fee_2);
                objFee_mstr_rec.FEE_CURR_H_FEE_2 = Util.NumDec(fee_curr_h_fee_2);
                objFee_mstr_rec.FEE_CURR_A_MIN = Util.NumDec(fee_curr_a_min);
                objFee_mstr_rec.FEE_CURR_H_MIN = Util.NumDec(fee_curr_h_min);
                objFee_mstr_rec.FEE_CURR_A_MAX = Util.NumDec(fee_curr_a_max);
                objFee_mstr_rec.FEE_CURR_H_MAX = Util.NumDec(fee_curr_h_max);

                objFee_mstr_rec.FEE_CURR_A_ANAE = Util.NumDec(fee_curr_a_anae);
                objFee_mstr_rec.FEE_CURR_H_ANAE = Util.NumDec(fee_curr_h_anae);
                objFee_mstr_rec.FEE_CURR_A_ASST = Util.NumDec(fee_curr_a_asst);
                objFee_mstr_rec.FEE_CURR_H_ASST = Util.NumDec(fee_curr_h_asst);

                //fee_curr_add_on_codes_grp
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD1 = Util.Str(fee_curr_add_on_cd[1]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD2 = Util.Str(fee_curr_add_on_cd[2]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD3 = Util.Str(fee_curr_add_on_cd[3]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD4 = Util.Str(fee_curr_add_on_cd[4]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD5 = Util.Str(fee_curr_add_on_cd[5]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD6 = Util.Str(fee_curr_add_on_cd[6]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD7 = Util.Str(fee_curr_add_on_cd[7]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD8 = Util.Str(fee_curr_add_on_cd[8]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD9 = Util.Str(fee_curr_add_on_cd[9]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD10 = Util.Str(fee_curr_add_on_cd[10]);

                //fee_curr_oma_ind_card_reqs_grp;
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_curr_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_curr_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_curr_oma_ind_card_required[3]);

                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_prev_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_prev_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_prev_oma_ind_card_required[3]);

                objFee_mstr_rec.FEE_CURR_PAGE_ALPHA = Util.Str(fee_curr_page_alpha);
                objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC = Util.NumDec(fee_curr_page_numeric);

                objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_curr_add_on_perc_flat_ind);
                objFee_mstr_rec.FEE_PREV_A_FEE_1 = Util.NumDec(fee_prev_a_fee_1);
                objFee_mstr_rec.FEE_PREV_H_FEE_1 = Util.NumDec(fee_prev_h_fee_1);
                objFee_mstr_rec.FEE_PREV_A_FEE_2 = Util.NumDec(fee_prev_a_fee_2);
                objFee_mstr_rec.FEE_PREV_H_FEE_2 = Util.NumDec(fee_prev_h_fee_2);
                objFee_mstr_rec.FEE_PREV_A_MIN = Util.NumDec(fee_prev_a_min);
                objFee_mstr_rec.FEE_PREV_H_MIN = Util.NumDec(fee_prev_h_min);
                objFee_mstr_rec.FEE_PREV_A_MAX = Util.NumDec(fee_prev_a_max);
                objFee_mstr_rec.FEE_PREV_H_MAX = Util.NumDec(fee_prev_h_max);
                objFee_mstr_rec.FEE_PREV_A_ANAE = Util.NumDec(fee_prev_a_anae);
                objFee_mstr_rec.FEE_PREV_H_ANAE = Util.NumDec(fee_prev_h_anae);
                objFee_mstr_rec.FEE_PREV_A_ASST = Util.NumDec(fee_prev_a_asst);
                objFee_mstr_rec.FEE_PREV_H_ASST = Util.NumDec(fee_prev_h_asst);

                //fee_prev_add_on_codes_grp;
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD1 = Util.Str(fee_prev_add_on_cd[1]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD2 = Util.Str(fee_prev_add_on_cd[2]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD3 = Util.Str(fee_prev_add_on_cd[3]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD4 = Util.Str(fee_prev_add_on_cd[4]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD5 = Util.Str(fee_prev_add_on_cd[5]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD6 = Util.Str(fee_prev_add_on_cd[6]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD7 = Util.Str(fee_prev_add_on_cd[7]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD8 = Util.Str(fee_prev_add_on_cd[8]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD9 = Util.Str(fee_prev_add_on_cd[9]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD10 = Util.Str(fee_prev_add_on_cd[10]);

                //fee_prev_oma_ind_card_reqs_grp;
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_prev_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_prev_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_prev_oma_ind_card_required[3]);

                objFee_mstr_rec.FEE_PREV_PAGE_ALPHA = Util.Str(fee_prev_page_alpha);
                objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC = Util.NumDec(fee_prev_page_numeric);

                objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_prev_add_on_perc_flat_ind);

                //fee_current_prev_year_r;
                // string[] fee_years = new string[3];   

                objFee_mstr_rec.FEE_CURR_A_FEE_1 = Util.NumDec(fee_1[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_FEE_1 = Util.NumDec(fee_1[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_FEE_1 = Util.NumDec(fee_1[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_FEE_1 = Util.NumDec(fee_1[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_FEE_2 = Util.NumDec(fee_2[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_FEE_2 = Util.NumDec(fee_2[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_FEE_2 = Util.NumDec(fee_2[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_FEE_2 = Util.NumDec(fee_2[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_MIN = Util.NumDec(fee_min[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_MIN = Util.NumDec(fee_min[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_MIN = Util.NumDec(fee_min[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_MIN = Util.NumDec(fee_min[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_MAX = Util.NumDec(fee_max[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_MAX = Util.NumDec(fee_max[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_MAX = Util.NumDec(fee_max[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_MAX = Util.NumDec(fee_max[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_ANAE = Util.NumDec(fee_anae[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_ANAE = Util.NumDec(fee_anae[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_ANAE = Util.NumDec(fee_anae[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_ANAE = Util.NumDec(fee_anae[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_ASST = Util.NumDec(fee_asst[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_ASST = Util.NumDec(fee_asst[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_ASST = Util.NumDec(fee_asst[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_ASST = Util.NumDec(fee_asst[2, 2]);

                //fee_add_on_codes_grp;
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD1 = Util.Str(fee_add_on_cd[1, 1]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD2 = Util.Str(fee_add_on_cd[1, 2]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD3 = Util.Str(fee_add_on_cd[1, 3]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD4 = Util.Str(fee_add_on_cd[1, 4]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD5 = Util.Str(fee_add_on_cd[1, 5]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD6 = Util.Str(fee_add_on_cd[1, 6]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD7 = Util.Str(fee_add_on_cd[1, 7]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD8 = Util.Str(fee_add_on_cd[1, 8]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD9 = Util.Str(fee_add_on_cd[1, 9]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD10 = Util.Str(fee_add_on_cd[1, 10]);

                objFee_mstr_rec.FEE_PREV_ADD_ON_CD1 = Util.Str(fee_add_on_cd[2, 1]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD2 = Util.Str(fee_add_on_cd[2, 2]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD3 = Util.Str(fee_add_on_cd[2, 3]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD4 = Util.Str(fee_add_on_cd[2, 4]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD5 = Util.Str(fee_add_on_cd[2, 5]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD6 = Util.Str(fee_add_on_cd[2, 6]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD7 = Util.Str(fee_add_on_cd[2, 7]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD8 = Util.Str(fee_add_on_cd[2, 8]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD9 = Util.Str(fee_add_on_cd[2, 9]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD10 = Util.Str(fee_add_on_cd[2, 10]);

                // fee_oma_ind_card_requireds_grp;
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_oma_ind_card_required[1, 1]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_oma_ind_card_required[1, 2]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_oma_ind_card_required[1, 3]);

                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_oma_ind_card_required[2, 1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_oma_ind_card_required[2, 2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_oma_ind_card_required[2, 3]);

                objFee_mstr_rec.FEE_CURR_PAGE_ALPHA = Util.Str(fee_page_alpha);
                objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC = Util.NumDec(fee_page);

                objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_add_on_perc_or_flat_ind);
                objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_prev_add_on_perc_flat_ind);

                objFee_mstr_rec.FEE_ICC_SEC = Util.Str(fee_icc_sec);
                objFee_mstr_rec.FEE_ICC_CAT = Util.NumDec(fee_icc_cat);
                objFee_mstr_rec.FEE_ICC_GRP = Util.NumDec(fee_icc_grp);
                objFee_mstr_rec.FEE_ICC_REDUC_IND = Util.NumDec(fee_icc_reduc_ind);

                objFee_mstr_rec.FEE_DIAG_IND = Util.Str(fee_diag_ind);
                objFee_mstr_rec.FEE_PHY_IND = Util.Str(fee_phy_ind);
                objFee_mstr_rec.FEE_TECH_IND = Util.Str(fee_tech_ind);
                objFee_mstr_rec.FEE_HOSP_NBR_IND = Util.Str(fee_hosp_nbr_ind);
                objFee_mstr_rec.FEE_I_O_IND = Util.Str(fee_i_o_ind);
                objFee_mstr_rec.FEE_ADMIT_IND = Util.Str(fee_admit_ind);
                objFee_mstr_rec.FEE_SPEC_FR = Util.NumDec(fee_spec_fr);
                objFee_mstr_rec.FEE_SPEC_TO = Util.NumDec(fee_spec_to);
                objFee_mstr_rec.FEEGLOBALADDONCDEXCLUSIONFLAG = Util.Str(fee_global_addon_cd_exclusion);

                objFee_mstr_rec.RecordState = State.Added;
                objFee_mstr_rec.Submit();
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> ReWrite_OmaFee_Mstr_Record()
        {
            try {
               
                objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(fee_oma_cd_ltr1);

                objFee_mstr_rec.FEE_OMA_CD_LTR1 = Util.Str(fee_oma_cd).PadRight(4).Substring(0, 1);
                objFee_mstr_rec.FILLER_NUMERIC = Util.Str(fee_oma_cd).PadRight(4).Substring(1, 3);

                objFee_mstr_rec.FEE_SPECIAL_M_SUFFIX_IND = Util.Str(fee_special_m_suffix_ind);

                objFee_mstr_rec.FEE_DATE_YY = Util.NumInt(fee_date_yy);
                objFee_mstr_rec.FEE_DATE_MM = Util.NumInt(fee_date_mm);
                objFee_mstr_rec.FEE_DATE_DD = Util.NumInt(fee_date_dd);

                objFee_mstr_rec.FEE_ACTIVE_FOR_ENTRY = Util.Str(fee_active_for_entry);
                objFee_mstr_rec.FEE_DESC = Util.Str(fee_desc);

                // string fee_current_prev_years_grp
                objFee_mstr_rec.FEE_CURR_A_FEE_1 = Util.NumDec(fee_curr_a_fee_1);
                objFee_mstr_rec.FEE_CURR_H_FEE_1 = Util.NumDec(fee_curr_h_fee_1);
                objFee_mstr_rec.FEE_CURR_A_FEE_2 = Util.NumDec(fee_curr_a_fee_2);
                objFee_mstr_rec.FEE_CURR_H_FEE_2 = Util.NumDec(fee_curr_h_fee_2);
                objFee_mstr_rec.FEE_CURR_A_MIN = Util.NumDec(fee_curr_a_min);
                objFee_mstr_rec.FEE_CURR_H_MIN = Util.NumDec(fee_curr_h_min);
                objFee_mstr_rec.FEE_CURR_A_MAX = Util.NumDec(fee_curr_a_max);
                objFee_mstr_rec.FEE_CURR_H_MAX = Util.NumDec(fee_curr_h_max);

                objFee_mstr_rec.FEE_CURR_A_ANAE = Util.NumDec(fee_curr_a_anae);
                objFee_mstr_rec.FEE_CURR_H_ANAE = Util.NumDec(fee_curr_h_anae);
                objFee_mstr_rec.FEE_CURR_A_ASST = Util.NumDec(fee_curr_a_asst);
                objFee_mstr_rec.FEE_CURR_H_ASST = Util.NumDec(fee_curr_h_asst);

                //fee_curr_add_on_codes_grp            
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD1 = Util.Str(fee_curr_add_on_cd[1]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD2 = Util.Str(fee_curr_add_on_cd[2]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD3 = Util.Str(fee_curr_add_on_cd[3]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD4 = Util.Str(fee_curr_add_on_cd[4]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD5 = Util.Str(fee_curr_add_on_cd[5]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD6 = Util.Str(fee_curr_add_on_cd[6]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD7 = Util.Str(fee_curr_add_on_cd[7]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD8 = Util.Str(fee_curr_add_on_cd[8]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD9 = Util.Str(fee_curr_add_on_cd[9]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD10 = Util.Str(fee_curr_add_on_cd[10]);

                //fee_curr_oma_ind_card_reqs_grp;
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_curr_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_curr_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_curr_oma_ind_card_required[3]);

                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_prev_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_prev_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_prev_oma_ind_card_required[3]);


                objFee_mstr_rec.FEE_CURR_PAGE_ALPHA = Util.Str(fee_curr_page_alpha);
                objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC = Util.NumDec(fee_curr_page_numeric);

                objFee_mstr_rec.FEE_PREV_PAGE_ALPHA = Util.Str(fee_prev_page_alpha);
                objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC = Util.NumDec(fee_prev_page_numeric);

                objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_curr_add_on_perc_flat_ind);
                objFee_mstr_rec.FEE_PREV_A_FEE_1 = Util.NumDec(fee_prev_a_fee_1);
                objFee_mstr_rec.FEE_PREV_H_FEE_1 = Util.NumDec(fee_prev_h_fee_1);
                objFee_mstr_rec.FEE_PREV_A_FEE_2 = Util.NumDec(fee_prev_a_fee_2);
                objFee_mstr_rec.FEE_PREV_H_FEE_2 = Util.NumDec(fee_prev_h_fee_2);
                objFee_mstr_rec.FEE_PREV_A_MIN = Util.NumDec(fee_prev_a_min);
                objFee_mstr_rec.FEE_PREV_H_MIN = Util.NumDec(fee_prev_h_min);
                objFee_mstr_rec.FEE_PREV_A_MAX = Util.NumDec(fee_prev_a_max);
                objFee_mstr_rec.FEE_PREV_H_MAX = Util.NumDec(fee_prev_h_max);
                objFee_mstr_rec.FEE_PREV_A_ANAE = Util.NumDec(fee_prev_a_anae);
                objFee_mstr_rec.FEE_PREV_H_ANAE = Util.NumDec(fee_prev_h_anae);
                objFee_mstr_rec.FEE_PREV_A_ASST = Util.NumDec(fee_prev_a_asst);
                objFee_mstr_rec.FEE_PREV_H_ASST = Util.NumDec(fee_prev_h_asst);

                //fee_prev_add_on_codes_grp;
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD1 = Util.Str(fee_prev_add_on_cd[1]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD2 = Util.Str(fee_prev_add_on_cd[2]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD3 = Util.Str(fee_prev_add_on_cd[3]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD4 = Util.Str(fee_prev_add_on_cd[4]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD5 = Util.Str(fee_prev_add_on_cd[5]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD6 = Util.Str(fee_prev_add_on_cd[6]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD7 = Util.Str(fee_prev_add_on_cd[7]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD8 = Util.Str(fee_prev_add_on_cd[8]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD9 = Util.Str(fee_prev_add_on_cd[9]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD10 = Util.Str(fee_prev_add_on_cd[10]);

                //fee_prev_oma_ind_card_reqs_grp;
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_prev_oma_ind_card_required[1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_prev_oma_ind_card_required[2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_prev_oma_ind_card_required[3]);

                objFee_mstr_rec.FEE_PREV_PAGE_ALPHA = Util.Str(fee_prev_page_alpha);
                objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC =  Util.NumDec(fee_prev_page_numeric);

                objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_prev_add_on_perc_flat_ind);

                //fee_current_prev_year_r;
                // string[] fee_years = new string[3];   //todo...????


                // todo....  2 dimensional array
                objFee_mstr_rec.FEE_CURR_A_FEE_1 = Util.NumDec(fee_1[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_FEE_1 = Util.NumDec(fee_1[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_FEE_1 = Util.NumDec(fee_1[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_FEE_1 = Util.NumDec(fee_1[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_FEE_2 = Util.NumDec(fee_2[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_FEE_2 = Util.NumDec(fee_2[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_FEE_2 = Util.NumDec(fee_2[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_FEE_2 = Util.NumDec(fee_2[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_MIN = Util.NumDec(fee_min[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_MIN = Util.NumDec(fee_min[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_MIN = Util.NumDec(fee_min[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_MIN = Util.NumDec(fee_min[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_MAX = Util.NumDec(fee_max[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_MAX = Util.NumDec(fee_max[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_MAX = Util.NumDec(fee_max[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_MAX = Util.NumDec(fee_max[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_ANAE = Util.NumDec(fee_anae[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_ANAE = Util.NumDec(fee_anae[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_ANAE = Util.NumDec(fee_anae[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_ANAE = Util.NumDec(fee_anae[2, 2]);

                objFee_mstr_rec.FEE_CURR_A_ASST = Util.NumDec(fee_asst[1, 1]);
                objFee_mstr_rec.FEE_CURR_H_ASST = Util.NumDec(fee_asst[1, 2]);

                objFee_mstr_rec.FEE_PREV_A_ASST = Util.NumDec(fee_asst[2, 1]);
                objFee_mstr_rec.FEE_PREV_H_ASST = Util.NumDec(fee_asst[2, 2]);

                //fee_add_on_codes_grp;
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD1 = Util.Str(fee_add_on_cd[1, 1]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD2 = Util.Str(fee_add_on_cd[1, 2]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD3 = Util.Str(fee_add_on_cd[1, 3]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD4 = Util.Str(fee_add_on_cd[1, 4]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD5 = Util.Str(fee_add_on_cd[1, 5]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD6 = Util.Str(fee_add_on_cd[1, 6]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD7 = Util.Str(fee_add_on_cd[1, 7]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD8 = Util.Str(fee_add_on_cd[1, 8]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD9 = Util.Str(fee_add_on_cd[1, 9]);
                objFee_mstr_rec.FEE_CURR_ADD_ON_CD10 = Util.Str(fee_add_on_cd[1, 10]);

                objFee_mstr_rec.FEE_PREV_ADD_ON_CD1 = Util.Str(fee_add_on_cd[2, 1]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD2 = Util.Str(fee_add_on_cd[2, 2]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD3 = Util.Str(fee_add_on_cd[2, 3]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD4 = Util.Str(fee_add_on_cd[2, 4]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD5 = Util.Str(fee_add_on_cd[2, 5]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD6 = Util.Str(fee_add_on_cd[2, 6]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD7 = Util.Str(fee_add_on_cd[2, 7]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD8 = Util.Str(fee_add_on_cd[2, 8]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD9 = Util.Str(fee_add_on_cd[2, 9]);
                objFee_mstr_rec.FEE_PREV_ADD_ON_CD10 = Util.Str(fee_add_on_cd[2, 10]);

                // fee_oma_ind_card_requireds_grp;
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_oma_ind_card_required[1, 1]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_oma_ind_card_required[1, 2]);
                objFee_mstr_rec.FEE_CURR_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_oma_ind_card_required[1, 3]);

                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED1 = Util.Str(fee_oma_ind_card_required[2, 1]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED2 = Util.Str(fee_oma_ind_card_required[2, 2]);
                objFee_mstr_rec.FEE_PREV_OMA_IND_CARD_REQUIRED3 = Util.Str(fee_oma_ind_card_required[2, 3]);

                objFee_mstr_rec.FEE_CURR_PAGE_ALPHA = Util.Str(fee_curr_page_alpha);
                objFee_mstr_rec.FEE_CURR_PAGE_NUMERIC = Util.NumDec(fee_curr_page_numeric);

                objFee_mstr_rec.FEE_PREV_PAGE_ALPHA = Util.Str(fee_prev_page_alpha);
                objFee_mstr_rec.FEE_PREV_PAGE_NUMERIC = Util.NumDec(fee_prev_page_numeric); 

                objFee_mstr_rec.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_add_on_perc_or_flat_ind);
                objFee_mstr_rec.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Util.Str(fee_prev_add_on_perc_flat_ind);

                objFee_mstr_rec.FEE_ICC_SEC = Util.Str(fee_icc_sec);
                objFee_mstr_rec.FEE_ICC_CAT = Util.NumDec(fee_icc_cat);
                objFee_mstr_rec.FEE_ICC_GRP = Util.NumDec(fee_icc_grp);
                objFee_mstr_rec.FEE_ICC_REDUC_IND = Util.NumDec(fee_icc_reduc_ind);

                objFee_mstr_rec.FEE_DIAG_IND = Util.Str(fee_diag_ind);
                objFee_mstr_rec.FEE_PHY_IND = Util.Str(fee_phy_ind);
                objFee_mstr_rec.FEE_TECH_IND = Util.Str(fee_tech_ind);
                objFee_mstr_rec.FEE_HOSP_NBR_IND = Util.Str(fee_hosp_nbr_ind);
                objFee_mstr_rec.FEE_I_O_IND = Util.Str(fee_i_o_ind);
                objFee_mstr_rec.FEE_ADMIT_IND = Util.Str(fee_admit_ind);
                objFee_mstr_rec.FEE_SPEC_FR = Util.NumDec(fee_spec_fr);
                objFee_mstr_rec.FEE_SPEC_TO = Util.NumDec(fee_spec_to);
                objFee_mstr_rec.FEEGLOBALADDONCDEXCLUSIONFLAG = Util.Str(fee_global_addon_cd_exclusion);

                objFee_mstr_rec.RecordState = State.Modified;
                objFee_mstr_rec.Submit();
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region fee_add_on_curr_prev

        private async Task display_fee_add_on_cd(int year , int col)
        {
            if (year == 1) {
                switch (col)
                {
                    case 1:
                        fee_add_on_cd_1_1 =  Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-1");
                        break;
                    case 2:
                        fee_add_on_cd_1_2 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-2");
                        break;
                    case 3:
                        fee_add_on_cd_1_3 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-3");
                        break;
                    case 4:
                        fee_add_on_cd_1_4 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-4");
                        break;
                    case 5:
                        fee_add_on_cd_1_5 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-5");
                        break;
                    case 6:
                        fee_add_on_cd_1_6 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-6");
                        break;
                    case 7:
                        fee_add_on_cd_1_7 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-7");
                        break;
                    case 8:
                        fee_add_on_cd_1_8 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-8");
                        break;
                    case 9:
                        fee_add_on_cd_1_9 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-9");
                        break;
                    case 10:
                        fee_add_on_cd_1_10 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-1-10");
                        break;
                }
            } else if ( year == 2)
            {
               switch (col)
                {
                    case 1:
                        fee_add_on_cd_2_1 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-1");
                        break;
                    case 2:
                        fee_add_on_cd_2_2 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-2");
                        break;
                    case 3:
                        fee_add_on_cd_2_3 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-3");
                        break;
                    case 4:
                        fee_add_on_cd_2_4 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-4");
                        break;
                    case 5:
                        fee_add_on_cd_2_5 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-5");
                        break;
                    case 6:
                        fee_add_on_cd_2_6 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-6");
                        break;
                    case 7:
                        fee_add_on_cd_2_7 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-7");
                        break;
                    case 8:
                        fee_add_on_cd_2_8 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-8");
                        break;
                    case 9:
                        fee_add_on_cd_2_9 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-9");
                        break;
                    case 10:
                        fee_add_on_cd_2_10 = Util.Str(fee_add_on_cd[year, col]);
                        Display("scr-add-on.", "scr-add-on-cd-2-10");
                        break;
                }
            }
        }

        private async Task accept_fee_add_on_cd(int year, int col)
        {
            if (year == 1)
            {
                switch (col)
                {
                    case 1:
                        await Prompt("fee_add_on_cd_1_1");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_1;
                        break;
                    case 2:
                        await Prompt("fee_add_on_cd_1_2");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_2;
                        break;
                    case 3:
                        await Prompt("fee_add_on_cd_1_3");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_3;
                        break;
                    case 4:
                        await Prompt("fee_add_on_cd_1_4");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_4;
                        break;
                    case 5:
                        await Prompt("fee_add_on_cd_1_5");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_5;
                        break;
                    case 6:
                        await Prompt("fee_add_on_cd_1_6");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_6;
                        break;
                    case 7:
                        await Prompt("fee_add_on_cd_1_7");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_7;
                        break;
                    case 8:
                        await Prompt("fee_add_on_cd_1_8");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_8;
                        break;
                    case 9:
                        await Prompt("fee_add_on_cd_1_9");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_9;
                        break;
                    case 10:
                        await Prompt("fee_add_on_cd_1_10");
                        fee_add_on_cd[year, col] = fee_add_on_cd_1_10;
                        break;
                }
            }
            else if (year == 2)
            {
                switch (col)
                {
                    case 1:
                        await Prompt("fee_add_on_cd_2_1");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_1;
                        break;
                    case 2:
                        await Prompt("fee_add_on_cd_2_2");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_2;
                        break;
                    case 3:
                        await Prompt("fee_add_on_cd_2_3");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_3;
                        break;
                    case 4:
                        await Prompt("fee_add_on_cd_2_4");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_4;
                        break;
                    case 5:
                        await Prompt("fee_add_on_cd_2_5");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_5;
                        break;
                    case 6:
                        await Prompt("fee_add_on_cd_2_6");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_6;
                        break;
                    case 7:
                        await Prompt("fee_add_on_cd_2_7");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_7;
                        break;
                    case 8:
                        await Prompt("fee_add_on_cd_2_8");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_8;
                        break;
                    case 9:
                        await Prompt("fee_add_on_cd_2_9");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_9;
                        break;
                    case 10:
                        await Prompt("fee_add_on_cd_2_10");
                        fee_add_on_cd[year, col] = fee_add_on_cd_2_10;
                        break;
                }
            }
        }

        private async Task display_fee_oma_ind_card_required(int year, int col)
        {
            if (year == 1)
            {
                switch (col)
                {
                    case 1:
                        fee_oma_ind_card_required_1_1 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-1-1");
                        break;
                    case 2:
                        fee_oma_ind_card_required_1_2 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-1-2");
                        break;
                    case 3:
                        fee_oma_ind_card_required_1_3 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-1-3");
                        break;
                }
            }
            else if (year == 2)
            {
                switch (col)
                {
                    case 1:
                        fee_oma_ind_card_required_2_1 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-2-1");
                        break;
                    case 2:
                        fee_oma_ind_card_required_2_2 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-2-2");
                        break;
                    case 3:
                        fee_oma_ind_card_required_2_3 = Util.Str(fee_oma_ind_card_required[year, col]);
                        Display("scr-suffixes.", "scr-suffix-2-3");
                        break;
                }
            }
        }

        private async Task accept_fee_oma_ind_card_required(int year, int col)
        {
            if (year == 1)
            {
                switch (col)
                {
                    case 1:                        
                        await Prompt("fee_oma_ind_card_required_1_1");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_1_1;                        
                        break;
                    case 2:                        
                        await Prompt("fee_oma_ind_card_required_1_2");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_1_2;
                        break;
                    case 3:                        
                        await Prompt("fee_oma_ind_card_required_1_3");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_1_3;
                        break;
                }
            }
            else if (year == 2)
            {
                switch (col)
                {
                    case 1:                        
                        await Prompt("fee_oma_ind_card_required_2_1");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_2_1;
                        break;
                    case 2:                        
                        await Prompt("fee_oma_ind_card_required_2_2");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_2_2;
                        break;
                    case 3:                        
                        await Prompt("fee_oma_ind_card_required_2_3");
                        fee_oma_ind_card_required[year, col] = fee_oma_ind_card_required_2_3;
                        break;
                }
            }
        }

        #endregion

        public async Task destroy_objects()
        {
            objAudit_record = null;
            objFee_mstr_rec = null;
        }

    }
}

