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
    public class R070aViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private ReportPrint objPrint_rec = null;


        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        private Claims_mstr_rec objClaims_mstr_rec = null;
        private ObservableCollection<Claims_mstr_rec> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        //private Claims_mstr_dtl_rec objClaims_mstr_dtl_rec = null;
        //private ObservableCollection<Claims_mstr_dtl_rec> Claims_mstr_dtl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_HDR objClaim_header_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claim_header_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_DTL objClaim_detail_rec = null;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claim_detail_rec_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

        // FD: claims_work_mstr	Copy : r070_claims_work_mstr.fd
        private Claims_work_rec objClaims_work_rec = null;
        private ObservableCollection<Claims_work_rec> Claims_work_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: param_file	Copy : r070_param_file.fd
        private WriteFile objParam_file = null;
        private Param_file_rec objParam_file_rec = null;

        private ObservableCollection<Param_file_rec> Param_file_rec_Collection;

        private WriteFile objClaims_work_rec_file = null;



        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private string prt_file_name = "r070a";
        private int pat_occur;
        private int claims_pat_access_occur;
        private int claims_occur;
        private string common_status_file;
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_work_mstr = "0";
        private string status_cobol_param_file = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_pat_mstr = "0";
        private string status_prt_file = "0";
        private string feedback_pat_mstr;
        private string feedback_claims_mstr;
        private string feedback_iconst_mstr;
        private string const_mstr_rec_nbr;
        private int err_ind = 0;
        private string header_done = "N";
        private string totals_written = "N";
        private string display_key_type;
        private int ss;
        private string flag_request_complete;
        private string flag_request_complete_y = "Y";
        private string flag_request_complete_n = "N";
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string error_flag = "N";
        private string eof_claims_mstr = "N";
        private string end_search_index = "N";
        private int ss_var_err = 14;
        private int age_category;
        private int mth_old;
        private string day_old_r;
        private int i;
        private int dept_nbr;
        private int request_clinic;
        private string sel_clinic_nbr;
        private int age_yy;
        private int age_mm;
        private int age_dd;
        private string ws_reply;
        private string ws_date_reply;
        private decimal dept_tot_amount;
        private decimal balance_due;
        private int write_off_nbr_of_clms;
        private string blank_line = "";

        private string audit_line_grp;
        private string filler = "";
        private string audit_title;
        //private string filler = "";
        private int audit_count;
        //private string filler = "";
        private string hold_batch_nbr = "0";
        private int hold_claim_nbr = 0;

        private string tmp_doc_nbr_alpha_grp;
        private string[] tmp_batch_nbr_index = new string[9];

        private string hold_key_grp;
        private string hold_key_clm_batch_nbr_grp;
        private int hold_key_clinic_nbr1;
        private string hold_key_doc_nbr;
        private int hold_key_week;
        private int hold_key_day;
        private int hold_key_claim_nbr;
        private string hold_key_oma_code;
        private string hold_key_oma_suff;
        private string hold_key_adj_nbr;

        private string hold_pat_key_grp;
        private string hold_pat_key_type;
        private string hold_pat_key_data;

        private string sel_report_date_grp;
        private int report_yy;
        //private string filler = "/";
        private int report_mm;
        //private string filler = "/";
        private int report_dd;
        private int save_agent_cd;

        private string counters_grp;
        private int ctr_claims_mstr_hdr_reads;
        private int ctr_claims_mstr_dtl_reads;
        private int ctr_pat_mstr_reads;
        private int ctr_claims_mstr_writes;
        private int ctr_claims_mstr_del;
        private int ctr_claims_mstr_p_access_reads;
        private int ctr_claims_mstr_p_access_del;
        private int ctr_claims_work_mstr_writes;

        private string work_file_name_grp;
        //private string filler = "r070_work_mstr_";
        private string work_file_clinic_nbr;

        private string par_file_name_grp;
        //private string filler = "r070_par_file";

        private string key_claims_mstr_pat_access_grp;
        private string key_clm_pat_access_type;
        private string key_clm_pat_access_data_grp;
        private string key_clm_pat_access_pat_id;
        //private string filler;

        private string key_gen_claims_mstr_pat_access_grp;
        private string key_gen_clm_pat_access;
        private string key_gen_clm_pat_access_data;

        //private string h1_head_grp;
        //private string filler = "";
        //private string filler = "ERROR REPORT FOR R070A";

        //private string h2_head_grp;
        //private string filler = "";
        //private string filler = "claims nbr";
        //private string filler = "ACRONYM";

        //private string d1_line_grp;
        //private string filler = "";
        private string d1_batch_nbr;
        private int d1_claim_nbr;
        //private string filler = "";
        private string d1_acronym;
        //private string filler = "";

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "invalid reply";
        //private string filler = "NO CLAIMS MASTER SUPPLIED OR NO CLAIMS FOR THIS CLINIC";
        //private string filler = "INVALID DEPARTMENT NUMBER     ";
        //private string filler = "PATIENT INDEX NOT FOUND NO DELETE";
        //private string filler = "INVALID READS ON DOCTOR MASTER";
        //private string filler = "INVALID CLINIC IDENTIFIER";
        //private string filler = "CLAIM DETAIL MISSING - KEY IS = ";
        private string clm_dtl_err_msg = "";
        //private string filler = "INVALID KEY FOUND - WHEN DELETING FROM CLAIMS-MSTR";
        //private string filler = "INVALID READ ON PATIENT MASTER";
        //private string filler = "INVALID REWRITE TO PAT MAST KEY IS ";
        private string pat_key_err_msg = "";
        //private string filler = "INVALID P-KEY READ ON CLM MSTR KEY IS ";
        private string clm_hdr_err_msg = "";
        //private string filler = "INVALID DELETE ON CLAIMS MSTR USING P-KEY";
        //private string filler = "WRONG RECORD ACCESSED USING P-KEY";
        //private string filler = "DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR INFO";
        //private string filler = "BLANK IKEY IN CLAIMS MSTR";
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply", "NO CLAIMS MASTER SUPPLIED OR NO CLAIMS FOR THIS CLINIC", "INVALID DEPARTMENT NUMBER     " , "PATIENT INDEX NOT FOUND NO DELETE", "INVALID READS ON DOCTOR MASTER",
                                  "INVALID CLINIC IDENTIFIER", "CLAIM DETAIL MISSING - KEY IS = ", "INVALID KEY FOUND - WHEN DELETING FROM CLAIMS-MSTR","INVALID READ ON PATIENT MASTER", "INVALID REWRITE TO PAT MAST KEY IS ",
                                  "INVALID P-KEY READ ON CLM MSTR KEY IS ", "INVALID DELETE ON CLAIMS MSTR USING P-KEY", "WRONG RECORD ACCESSED USING P-KEY", "DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR INFO", "BLANK IKEY IN CLAIMS MSTR"};
        private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;

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

        private string prm_sel_clinic_nbr;
        private string prm_ws_reply;
        private string endOfJob = "End of Job";
        private int RowPointer = 0;
        private string tmpBatchNumber;
        private bool BatchNumberIncrement = false;
        private int ctr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_constants_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_constants_mstr()
        {

            //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
            common_status_file = status_cobol_iconst_mstr;
            //     display common-status-file.;
            //     stop run.;
        }

        private void err_claim_header_mstr_file_section()
        {

            //     use after standard error procedure on claims-mstr.;
        }

        private void err_claims_mstr()
        {

            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
            common_status_file = status_cobol_claims_mstr;
            //     display common-status-file.;
            //     stop run.;
            //   err-pat-mstr-file section.;
            //     use after standard error procedure on pat-mstr.;
            //    err-pat-mstr.;
            common_status_file = status_cobol_pat_mstr;
            //     display common-status-file.;
            //     stop " ".;
            //     stop run.;
        }

        private void err_work_mstr_file_section()
        {

            //     use after standard error procedure on claims-work-mstr.;
        }

        private void err_work_mstr()
        {

            common_status_file = status_cobol_work_mstr;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING WORK MSTR".;
        }

        private void err_parameter_file_section()
        {

            //     use after standard error procedure on param-file.;
        }

        private void err_param_file()
        {

            common_status_file = status_cobol_param_file;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING PARAM FILE".;
        }

        private void end_declaratives()
        {

        }

        public void mainline_section(string sel_clinic_nbr, string ws_reply)
        {            
            try
            {
                prm_sel_clinic_nbr = sel_clinic_nbr;
                prm_ws_reply = ws_reply;

                objPrint_rec = new ReportPrint(Directory.GetCurrentDirectory() + "\\r070a");

                objClaims_mstr_rec = new Claims_mstr_rec();
                Claims_mstr_rec_Collection = new ObservableCollection<Claims_mstr_rec>();

                // objClaims_mstr_dtl_rec = new Claims_mstr_dtl_rec();
                // Claims_mstr_dtl_rec_Collection = new ObservableCollection<Claims_mstr_dtl_rec>();

                objClaim_header_rec = new F002_CLAIMS_MSTR_HDR();
                Claim_header_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();

                objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL();
                Claim_detail_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

                objPat_mstr_rec = new F010_PAT_MSTR();
                Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

                objClaims_work_rec = new Claims_work_rec();
                Claims_work_rec_Collection = new ObservableCollection<Claims_work_rec>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objParam_file = new WriteFile(Directory.GetCurrentDirectory() + "\\r070_par_file");

                objClaims_work_rec_file = null;
                objClaims_work_rec_file = new WriteFile(Directory.GetCurrentDirectory() + "\\r070_work_mstr_" + sel_clinic_nbr);



                objParam_file_rec = new Param_file_rec();
                Param_file_rec_Collection = new ObservableCollection<Param_file_rec>();


                //     perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_10_enter_clinic_nbr();
                aa0_11();
                aa0_20_read_claims_mstr();
                aa0_99_exit();

                //     perform ab1-wk-file-creation		thru ab1-99-exit.;
                ab1_wk_file_creation();
                ab1_99_exit();

                //     perform az0-finalization			thru az0-99-exit.;
                az0_finalization();
                az0_99_exit();

                //     stop run.;
            }
            catch (Exception e)
            {
                if (!e.Message.Contains(endOfJob))
                {
                    Console.WriteLine("Error Message : " + e.Message);
                    Console.WriteLine("Error Stack Trace : " + e.StackTrace);
                }
            }
            finally
            {
                if (objParam_file != null)
                    objParam_file.CloseOutputFile();

                if (objPrint_rec != null)
                    objPrint_rec.Close();

                if (objClaims_work_rec_file != null)
                    objClaims_work_rec_file.CloseOutputFile();
            }
        }

        private void aa0_initialization()
        {            

            //     accept sys-date				from date.;
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

            //     open input 	claims-mstr;
            //  		pat-mstr;
            // 		iconst-mstr.;

            day_old_r = "";
            balance_due = 0;
            //hold_key = 0;
            hold_key_clinic_nbr1 = 0;
            hold_key_doc_nbr = "";
            hold_key_week = 0;
            hold_key_day = 0;
            hold_key_claim_nbr = 0;
            hold_key_oma_code = "";
            hold_key_oma_suff = "";
            hold_key_adj_nbr = "";

            save_agent_cd = 0;
            age_category = 0;
            mth_old = 0;
            age_yy = 0;
            age_mm = 0;
            age_dd = 0;
            //counters = 0;
            ctr_claims_mstr_hdr_reads = 0;
            ctr_claims_mstr_dtl_reads = 0;
            ctr_pat_mstr_reads = 0;
            ctr_claims_mstr_writes = 0;
            ctr_claims_mstr_del = 0;
            ctr_claims_mstr_p_access_reads = 0;
            ctr_claims_mstr_p_access_del = 0;
            ctr_claims_work_mstr_writes = 0;
        }

        private void aa0_10_enter_clinic_nbr()
        {            

            //     accept sel-clinic-nbr.;
            sel_clinic_nbr = prm_sel_clinic_nbr;

            // if 	sel-clinic-nbr = "**" then; 
            if (sel_clinic_nbr == "**")
            {
                objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 0;
            }
            else
            {
                //    objIconst_mstr_rec.iconst_clinic_nbr_1_2 = sel_clinic_nbr;
                objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = Util.NumDec(sel_clinic_nbr);
            }

            //     read iconst-mstr;
            //         invalid key;
            //         err_ind = 6;
            // 		perform za0-common-error 	thru za0-99-exit;
            //   		go to aa0-10-enter-clinic-nbr.;

            objIconst_mstr_rec = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(sel_clinic_nbr)
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec == null)
            {
                err_ind = 6;
                // 		perform za0-common-error 	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to aa0-10-enter-clinic-nbr.;
                aa0_10_enter_clinic_nbr();
                return;
            }
        }

        private void aa0_11()
        {            

            //     accept ws-date-reply.;

            //     accept ws-reply.;
            ws_reply = prm_ws_reply;

            //  if ws-reply not = "Y" then;            
            if (ws_reply.ToUpper() != "Y")
            {
                //         go to az0-finalization;
                az0_finalization();
                return;
            }
            else
            {
                work_file_clinic_nbr = sel_clinic_nbr;
            }


            //     open output param-file;
            // 		print-file;
            //  		claims-work-mstr.;

            //objParam_file_rec.param_file_re param_file_rec = "";

            objParam_file_rec.Param_clinic_nbr_1_2 = Util.NumInt(sel_clinic_nbr);
            objParam_file_rec.Param_run_date = sys_date_long_child;
            objParam_file_rec.Param_date_yy = Util.NumInt(DateTime.Now.Year.ToString());
            objParam_file_rec.Param_date_mm = Util.NumInt(DateTime.Now.Month.ToString().PadLeft(2, '0'));
            objParam_file_rec.Param_date_dd = Util.NumInt(DateTime.Now.Day.ToString().PadLeft(2, '0'));
            objParam_file_rec.Param_date_period_end_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            objParam_file_rec.Param_date_period_end_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            objParam_file_rec.Param_date_period_end_mm = mth_desc[Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM)];

            objParam_file_rec.Param_clinic_name = objIconst_mstr_rec.ICONST_CLINIC_NAME;
            objParam_file_rec.Param_clinic_nbr = Util.NumInt(objIconst_mstr_rec.ICONST_CLINIC_NBR);

            string param_Rec = Util.Str(objParam_file_rec.Param_clinic_nbr_1_2).PadLeft(2, '0') +
                             Util.Str(objParam_file_rec.Param_clinic_nbr).PadLeft(4, '0') +
                             Util.Str(objParam_file_rec.Param_clinic_name).PadRight(20) +
                             Util.Str(objParam_file_rec.Param_date_period_end_yy).PadLeft(4, '0') +
                             Util.Str(objParam_file_rec.Param_date_period_end_dd).PadLeft(2, '0') +
                             Util.Str(objParam_file_rec.Param_date_period_end_mm).PadRight(11) +
                             Util.Str(objParam_file_rec.Param_date_yy).PadLeft(4, '0') +
                             Util.Str(objParam_file_rec.Param_date_mm).PadLeft(2, '0') +
                             Util.Str(objParam_file_rec.Param_date_dd).PadLeft(2, '0') +
                             Util.Str(objParam_file_rec.Filler).PadRight(1);

            //     write param-file-rec.;
            objParam_file.AppendOutputFile(param_Rec);
        }

        private void aa0_20_read_claims_mstr()
        {

            //move zero               to clmdtl-b - data.

            objClaim_header_rec.CLMHDR_BATCH_NBR = "0";
            objClaim_header_rec.CLMHDR_CLAIM_NBR = 0;
            objClaim_header_rec.CLMHDR_ADJ_OMA_CD = "0";
            objClaim_header_rec.CLMHDR_ADJ_OMA_SUFF = "0";
            objClaim_header_rec.CLMHDR_ADJ_ADJ_NBR = "0";

            //objClaim_detail_rec.CLMDTL_BATCH_NBR = "0";
            //objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;
            //objClaim_detail_rec.CLMDTL_OMA_CD = "0";
            //objClaim_detail_rec.CLMDTL_OMA_SUFF = "0";
            //objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;

            //move "B"                to clmdtl-b - key - type.     
            objClaim_header_rec.KEY_CLM_TYPE = "B";

            //move sel - clinic - nbr         to clmdtl-b - clinic - nbr - 1 - 2.      //  2 bytes from clmdtl-b-batch-num which has 8 bytes in total
            objClaim_header_rec.KEY_CLM_BATCH_NBR = sel_clinic_nbr;
           
            bool isRetrieving = false;

            Claim_header_rec_Collection = new F002_CLAIMS_MSTR_HDR
            {
                WhereKey_clm_type = "B",
                WhereKey_clm_batch_nbr = prm_sel_clinic_nbr
            }.Collection_HDR_For_Clinic_NBR(ref isRetrieving, Claim_header_rec_Collection);

            //Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            //{
            //    WhereKey_clm_type = "B",
            //    WhereClmdtl_batch_nbr = prm_sel_clinic_nbr                
            //}.Collection_HDR_DTL_For_Clinic_NBR(ref isRetrieving, Claim_detail_rec_Collection);

            //     perform cb0-read-select-claim-apprx	thru	cb0-99-exit.;
            cb0_read_select_claim_apprx();
            cb0_99_exit();

            //  if eof-claims-mstr = "Y" then;            
            if (eof_claims_mstr.ToUpper().Equals("Y"))
            {
                err_ind = 2;
                // 	perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // 	go to az0-finalization.;
                az0_finalization();
                return;
            }

            //   save_agent_cd = objClaim_detail_rec.clmhdr_agent_cd;
            //save_agent_cd = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD);
            save_agent_cd = Util.NumInt(objClaim_header_rec.CLMHDR_AGENT_CD);

            //     write print-rec from h1-head after advancing page.;            
            objPrint_rec.PageBreak();
            objPrint_rec.print(h1_head_grp(), 1, true);


            //     write print-rec from h2-head after advancing 3 lines.;            
            objPrint_rec.print(true);
            objPrint_rec.print(true);
            objPrint_rec.print(h2_head_grp(), 1, true);
        }

        private void aa0_99_exit()
        {            
            //     exit.;          
        }

        private void ab1_wk_file_creation()
        {            

            while (eof_claims_mstr.ToUpper() != "Y")
            {

                // if clmhdr-agent-cd not = save-agent-cd then;            
                //if (objClaim_detail_rec.CLMHDR_AGENT_CD != save_agent_cd)
                if (objClaim_header_rec.CLMHDR_AGENT_CD != save_agent_cd)
                {
                    //save_agent_cd = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD);
                    save_agent_cd = Util.NumInt(objClaim_header_rec.CLMHDR_AGENT_CD);
                }

                // 	   add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-ohip;
                // 						giving balance-due.;
                //balance_due = Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS) + Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
                balance_due = Util.NumDec(objClaim_header_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS) + Util.NumDec(objClaim_header_rec.CLMHDR_TOT_CLAIM_AR_OHIP);


                //  if  balance-due = 0.00 then;            
                if (balance_due == 0)
                {
                    // 	    perform da6-save-clmhdr-info		thru da6-99-exit;
                    da6_save_clmhdr_info();
                    da6_99_exit();
                    // 	    perform cb3-add-to-claim-nbr    	thru cb3-99-exit;
                    cb3_add_to_claim_nbr();
                    cb3_99_exit();
                    // 	    perform cb0-read-select-claim-apprx	thru cb0-99-exit;
                    cb0_read_select_claim_apprx();
                    cb0_99_exit();
                }
                //  else if  balance-due < .86 and balance-due > -.86 then;            
                else if (balance_due < .86M && balance_due > -.86M)
                {
                    // 	    perform da6-save-clmhdr-info	thru da6-99-exit;
                    da6_save_clmhdr_info();
                    da6_99_exit();
                    objClaims_work_rec.Wk_sort_record_status = 9;
                    //   perform ca1-calculate-age-category	thru ca1-99-exit;
                    ca1_calculate_age_category();
                    ca1_99_exit();
                    // 	    perform wa0-write-to-wk-file	thru wa0-99-exit;
                    wa0_write_to_wk_file();
                    wa0_99_exit();
                    // 	    perform cb3-add-to-claim-nbr    	thru cb3-99-exit;
                    cb3_add_to_claim_nbr();
                    cb3_99_exit();
                    // 	    perform cb0-read-select-claim-apprx	thru cb0-99-exit;
                    cb0_read_select_claim_apprx();
                    cb0_99_exit();
                }
                else
                {
                    objClaims_work_rec.Wk_sort_record_status = 0;
                    //  perform ca1-calculate-age-category	thru ca1-99-exit;
                    ca1_calculate_age_category();
                    ca1_99_exit();
                    // 	    perform wa0-write-to-wk-file	thru wa0-99-exit;
                    wa0_write_to_wk_file();
                    wa0_99_exit();
                    // 	    perform cb3-add-to-claim-nbr    	thru cb3-99-exit;
                    cb3_add_to_claim_nbr();
                    cb3_99_exit();
                    // 	    perform cb0-read-select-claim-apprx	thru cb0-99-exit.;
                    cb0_read_select_claim_apprx();
                    cb0_99_exit();
                }

                //  if eof-claims-mstr not = "Y"  then;
                /*if (eof_claims_mstr.ToUpper() != "Y")
                {
                    // 	go to ab1-wk-file-creation.;
                    ab1_wk_file_creation();
                    return;
                } */

                if (eof_claims_mstr.ToUpper() == "Y")
                {
                    //Core: Write the last record
                    balance_due = Util.NumDec(objClaim_header_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS) + Util.NumDec(objClaim_header_rec.CLMHDR_TOT_CLAIM_AR_OHIP);

                    if (balance_due == 0)
                    {
                        da6_save_clmhdr_info();
                        da6_99_exit();
                        cb3_add_to_claim_nbr();
                        cb3_99_exit();
                        cb0_read_select_claim_apprx();
                        cb0_99_exit();
                    }
                    else if (balance_due < .86M && balance_due > -.86M)
                    {
                        da6_save_clmhdr_info();
                        da6_99_exit();
                        objClaims_work_rec.Wk_sort_record_status = 9;
                        ca1_calculate_age_category();
                        ca1_99_exit();
                        wa0_write_to_wk_file();
                        wa0_99_exit();
                        cb3_add_to_claim_nbr();
                        cb3_99_exit();
                        cb0_read_select_claim_apprx();
                        cb0_99_exit();
                    }
                    else
                    {
                        objClaims_work_rec.Wk_sort_record_status = 0;
                        ca1_calculate_age_category();
                        ca1_99_exit();
                        wa0_write_to_wk_file();
                        wa0_99_exit();
                        cb3_add_to_claim_nbr();
                        cb3_99_exit();
                        cb0_read_select_claim_apprx();
                        cb0_99_exit();
                    }

                    break;
                }
            }
        }

        private void ab1_99_exit()
        {            
            //     exit.;           
        }

        private void az0_finalization()
        {            

            //     close claims-mstr;
            //           iconst-mstr;
            //  	  pat-mstr;
            // 	  param-file;
            // 	  print-file;
            // 	  claims-work-mstr.;
            //     accept sys-time				from time.;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {            
            //     exit.;           
        }

        private void ca1_calculate_age_category()
        {            

            //  compute age-yy rounded = iconst-date-period-end-yy - clmhdr-period-end-yy.;            
            //age_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) - Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END).PadRight(8).Substring(0, 4));
            age_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) - Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END).PadRight(8).Substring(0, 4));

            //  compute age-mm rounded = iconst-date-period-end-mm - clmhdr-period-end-mm.;            
            //age_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM) - Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END).PadRight(8).Substring(4, 2));
            age_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM) - Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END).PadRight(8).Substring(4, 2));

            //  compute mth-old rounded = (age-yy * 12) + age-mm.;
            mth_old = (age_yy * 12) + age_mm;

            //  if mth-old < 0 then;            
            if (mth_old < 0)
            {
                mth_old = 0;
            }

            if (mth_old < 1)
            {
                age_category = 0;
                day_old_r = "CUR";
            }
            else if (mth_old < 2)
            {
                age_category = 1;
                day_old_r = "30";
            }
            else if (mth_old < 3)
            {
                age_category = 2;
                day_old_r = "60";
            }
            else if (mth_old < 4)
            {
                age_category = 3;
                day_old_r = "90";
            }
            else if (mth_old < 5)
            {
                age_category = 4;
                day_old_r = "120";
            }
            else if (mth_old < 6)
            {
                age_category = 5;
                day_old_r = "150";
            }
            else
            {
                age_category = 6;
                day_old_r = "180";
            }
        }

        private void ca1_99_exit()
        {            
            //     exit.;           
        }

        private void cb0_read_select_claim_apprx()
        {         

            ReadNext:               

            feedback_claims_mstr = "0";
            claims_occur = 0;

            // start claims-mstr  key is greater than or equal to key-claims-mstr;   
            //       invalid key;
            //       eof_claims_mstr = "Y";
            //           go to cb0-99-exit.;

            //     read claims-mstr next.;

            //   add 1				to	ctr-claims-mstr-reads.;

            bool eof = false;

            //if (ctr_claims_mstr_reads >= Claim_detail_rec_Collection.Count())
            if (ctr_claims_mstr_hdr_reads >= Claim_header_rec_Collection.Count())
            {
                eof_claims_mstr = "Y";
                //           go to cb0-99-exit.;
                cb0_99_exit();
                return;
            }

            objClaim_header_rec = Claim_header_rec_Collection[ctr_claims_mstr_hdr_reads];
            //objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_mstr_reads]; 
            ctr_claims_mstr_hdr_reads++;

            // 23 - record not found  99 - record lock
            // if   status-cobol-claims-mstr = 23 or  status-cobol-claims-mstr = 99  then;            
            //if (Util.NumInt(status_cobol_claims_mstr) == 23 || Util.NumInt(status_cobol_claims_mstr) == 99 || objClaim_detail_rec == null)
            if (Util.NumInt(status_cobol_claims_mstr) == 23 || Util.NumInt(status_cobol_claims_mstr) == 99 || objClaim_header_rec == null)
            {
                eof_claims_mstr = "Y";
                //         go to cb0-99-exit;
                cb0_99_exit();
                return;
            }
            // 10 - end of file
            // else  if status-cobol-claims-mstr = 10  then;            
            //else if (status_cobol_claims_mstr == "10" || ctr_claims_mstr_reads >= Claim_detail_rec_Collection.Count())
            else if (status_cobol_claims_mstr == "10" || ctr_claims_mstr_hdr_reads >= Claim_header_rec_Collection.Count())
            {
                eof_claims_mstr = "Y";
                //        go to cb0-99-exit;
                cb0_99_exit();
                return;
            }
            else
            {
                eof_claims_mstr = "N";
            }

            //  if eof-claims-mstr = "Y" then;      
            if (eof_claims_mstr == "Y")
            {
                cb0_99_exit();
                return;
            }
            else
            {
                // 	     next sentence.;
            }

            //  if ( sel-clinic-nbr  not = clmhdr-clinic-nbr-1-2 ) or ( clmdtl-b-key-type not = 'B' ) then;     
            //if (sel_clinic_nbr != Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2) || Util.Str(objClaim_detail_rec.KEY_CLM_TYPE) != "B")
            if (sel_clinic_nbr != Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2) || Util.Str(objClaim_header_rec.KEY_CLM_TYPE) != "B")
            {
                eof_claims_mstr = "Y";
                cb0_99_exit();
                return;
            }

            // if clmhdr-batch-type not = "C" then;           
            //if (Util.Str(objClaim_detail_rec.CLMHDR_BATCH_TYPE) != "C")
            if (Util.Str(objClaim_header_rec.CLMHDR_BATCH_TYPE) != "C")
            {
                //  perform cb3-add-to-claim-nbr	thru	cb3-99-exit;
                cb3_add_to_claim_nbr();
                cb3_99_exit();
                goto ReadNext;
                //cb0_read_select_claim_apprx();
                //return;
            }
        }

        private void cb0_99_exit()
        {            
            //     exit.;           
        }

        private void cb2_read_claim_next_for_index()  // Note: This is unused procedure.
        {         

            feedback_claims_mstr = "0";
            claims_occur = 0;

            //     read claims-mstr key is clmdtl-p-claims-mstr;
            //         invalid key;
            //end_search_index = "Y";

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                //20  clmdtl-p-key-type                        pic x.
                //                                                           Todo: Note:  f002_claims_mstr.fd .. Not sure of the where clause..?????                   
            }.Collection();


            // if 	hold-pat-key-data not = clmdtl-p-data of k-clmdtl-p-claims-mstr  then;    //todo: not sure of      clmdtl-p-data of k-clmdtl-p-claims-mstr          

            //10  k - clmdtl - p - claims - mstr.
            //    20  clmdtl - p - key - type                        pic x.
            //    20  clmdtl - p - data.
            //        25  clmdtl - p - batch - nbr.
            //            30  clmdtl - p - clinic - nbr - 1 - 2      pic  99.
            //            30  clmdtl - p - doc - nbr             pic x(3).                   ===> this fields does not exist on the table in sql database.
            //            30  clmdtl - p - week                pic 99.
            //            30  clmdtl - p - day                 pic 9.
            //        25  clmdtl - p - claim - nbr               pic 99.
            //        25  clmdtl - p - oma - cd                  pic x999.
            //        25  clmdtl - p - oma - suff                pic x.
            //        25  clmdtl - p - adj - nbr                 pic x.

            end_search_index = "Y";
            //}
        }

        private void cb2_99_exit()
        {         

            //     exit.;           
        }

        private void cb3_add_to_claim_nbr()
        {         

            // if  clmdtl-b-claim-nbr = 99 then;            
            if (Util.NumInt(objClaim_detail_rec.CLMDTL_CLAIM_NBR) == 99)
            {
                //     objClaims_mstr_dtl_rec.clmdtl_b_claim_nbr = 0;
                objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;

                //  perform xx0-increment-batch-nbr	thru	xx0-99-exit;
                xx0_increment_batch_nbr();
                xx0_99_exit();

                //  objClaims_mstr_dtl_rec.clmdtl_b_adj_nbr = "";  
                objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;
            }
            else
            {
                //    add 1 				to clmdtl-b-claim-nbr;  
                objClaim_detail_rec.CLMDTL_CLAIM_NBR++;

                //    objClaims_mstr_dtl_rec.clmdtl_b_adj_nbr = "";
                objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;

                //    objClaims_mstr_dtl_rec.clmdtl_b_oma_cd = "";
                objClaim_detail_rec.CLMDTL_OMA_CD = "";

                //    objClaims_mstr_dtl_rec.clmdtl_b_oma_suff = "";  
                objClaim_detail_rec.CLMDTL_OMA_SUFF = "";
            }
        }

        private void cb3_99_exit()
        {            
            //     exit.;           
        }

        private void xx0_increment_batch_nbr()
        {         

            flag_request_complete = "N";

            // if clmdtl-b-batch-number = 999  then;            
            if (Util.NumInt(Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR).PadRight(8).Substring(4, 3)) == 999)
            {

                //move clmdtl-b - doc - nbr       to tmp-doc - nbr - alpha
                // tmp_doc_nbr_alpha = objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr; 
                tmp_batch_nbr_index[1] = Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR).Substring(2, 1);
                tmp_batch_nbr_index[2] = Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR).Substring(3, 1);
                tmp_batch_nbr_index[3] = Util.Str(objClaim_detail_rec.CLMDTL_BATCH_NBR).Substring(4, 1);
                /*tmp_batch_nbr_index[4] = Util.Str(objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr).Substring(3, 1);
                tmp_batch_nbr_index[5] = Util.Str(objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr).Substring(4, 1);
                tmp_batch_nbr_index[6] = Util.Str(objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr).Substring(5, 1);
                tmp_batch_nbr_index[7] = Util.Str(objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr).Substring(6, 1);
                tmp_batch_nbr_index[8] = Util.Str(objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr).Substring(7, 1); */


                // 	    display "BEFORE: " clmdtl-b-doc-nbr;
                Console.WriteLine("BEFORE: " + objClaim_detail_rec.CLMDTL_BATCH_NBR.Substring(2, 3));

                // 	    perform xx1-process-1-doc-position  thru xx1-99-exit;
                //             varying   ss from 3 by -1;
                //             until     ss = 0;
                //                or      flag-request-complete-y;

                ss = 3;
                do
                {
                    xx1_process_1_doc_position();
                    xx0_90_return();
                    xx1_99_exit();
                    ss--;
                } while (ss != 0 && !flag_request_complete.Equals(flag_request_complete_y));

                //  move tmp-doc - nbr - alpha      to clmdtl-b - doc - nbr

                //objClaims_mstr_dtl_rec.Clmdtl_b_doc_nbr = tmp_batch_nbr_index[1] + tmp_batch_nbr_index[2] + tmp_batch_nbr_index[3] + tmp_batch_nbr_index[4] + tmp_batch_nbr_index[5] + tmp_batch_nbr_index[6] +
                //                                          tmp_batch_nbr_index[7] + tmp_batch_nbr_index[8];

                string tmp1 = objClaim_detail_rec.CLMDTL_BATCH_NBR.Substring(0, 2);
                string tmp2 = objClaim_detail_rec.CLMDTL_BATCH_NBR.PadRight(8, '0').Substring(5, 3);

                objClaim_detail_rec.CLMDTL_BATCH_NBR = tmp1 + tmp_batch_nbr_index[1] + tmp_batch_nbr_index[2] + tmp_batch_nbr_index[3] + tmp2;


                // 	     display "AFTER : " clmdtl-b-doc-nbr;
                Console.WriteLine("AFTER : " + objClaim_detail_rec.CLMDTL_BATCH_NBR.Substring(2, 3));
                //   	 display " ";

                //       objClaims_mstr_dtl_rec.clmdtl_b_batch_number = 000;
                //objClaim_detail_rec.CLMHDR_BATCH_NBR = "0";                  //  todo for  clmdtl_b_batch_number  (last 3 digits)
                objClaim_header_rec.CLMHDR_BATCH_NBR = "0";                  //  todo for  clmdtl_b_batch_number  (last 3 digits)
            }
            else
            {
                // 	     add 1				to	clmdtl-b-batch-number-numeric.; 
                //objClaims_mstr_dtl_rec.Clmdtl_b_batch_number_numeric++;
                string tmp1 = objClaim_detail_rec.CLMDTL_BATCH_NBR.Substring(0, 5);
                int tmp2 = Util.NumInt(objClaim_detail_rec.CLMDTL_BATCH_NBR.PadRight(8, '0').Substring(5, 3));
                tmp2++;
                objClaim_detail_rec.CLMDTL_BATCH_NBR = Util.Str(tmp1) + Util.Str(tmp2);
                BatchNumberIncrement = true;
            }
        }

        private void xx0_99_exit()
        {            
            //    exit.;           
        }

        private void xx1_process_1_doc_position()
        {         

            // if tmp-batch-nbr-index(ss) = "0" then;            
            if (tmp_batch_nbr_index[ss] == "0")
            {
                tmp_batch_nbr_index[ss] = "1";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "1")
            {
                tmp_batch_nbr_index[ss] = "2";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "2")
            {
                tmp_batch_nbr_index[ss] = "3";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "3")
            {
                tmp_batch_nbr_index[ss] = "4";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "4")
            {
                tmp_batch_nbr_index[ss] = "5";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "5")
            {
                tmp_batch_nbr_index[ss] = "6";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "6")
            {
                tmp_batch_nbr_index[ss] = "7";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "7")
            {
                tmp_batch_nbr_index[ss] = "8";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "8")
            {
                tmp_batch_nbr_index[ss] = "9";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "9")
            {
                tmp_batch_nbr_index[ss] = "A";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "A")
            {
                tmp_batch_nbr_index[ss] = "B";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "C";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "C")
            {
                tmp_batch_nbr_index[ss] = "D";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "D")
            {
                tmp_batch_nbr_index[ss] = "E";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "E")
            {
                tmp_batch_nbr_index[ss] = "F";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "F")
            {
                tmp_batch_nbr_index[ss] = "G";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "G")
            {
                tmp_batch_nbr_index[ss] = "H";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "H")
            {
                tmp_batch_nbr_index[ss] = "I";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "I")
            {
                tmp_batch_nbr_index[ss] = "J";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "J")
            {
                tmp_batch_nbr_index[ss] = "K";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "K")
            {
                tmp_batch_nbr_index[ss] = "L";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "L")
            {
                tmp_batch_nbr_index[ss] = "M";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "M")
            {
                tmp_batch_nbr_index[ss] = "N";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "N")
            {
                tmp_batch_nbr_index[ss] = "O";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "O")
            {
                tmp_batch_nbr_index[ss] = "P";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "P")
            {
                tmp_batch_nbr_index[ss] = "Q";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "R";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "R")
            {
                tmp_batch_nbr_index[ss] = "S";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "S")
            {
                tmp_batch_nbr_index[ss] = "T";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "T")
            {
                tmp_batch_nbr_index[ss] = "U";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "U")
            {
                tmp_batch_nbr_index[ss] = "V";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "V")
            {
                tmp_batch_nbr_index[ss] = "W";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "W")
            {
                tmp_batch_nbr_index[ss] = "X";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "X")
            {
                tmp_batch_nbr_index[ss] = "Y";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Y")
            {
                tmp_batch_nbr_index[ss] = "Z";
                xx0_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Z")
            {
                tmp_batch_nbr_index[ss] = "0";
                xx0_90_return();
                return;
            }
        }

        private void xx0_90_return()
        {         

            flag_request_complete = "Y";
        }

        private void xx1_99_exit()
        {         

            //     exit.;           
        }

        private void da4_read_pat()
        {

            // if clmhdr-pat-key-data = spaces then;            
            //if (string.IsNullOrWhiteSpace(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA))
            if (string.IsNullOrWhiteSpace(objClaim_header_rec.CLMHDR_PAT_KEY_DATA))
            {
                //d1_batch_nbr = objClaim_detail_rec.CLMHDR_BATCH_NBR;
                //d1_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
                //d1_acronym = objClaim_detail_rec.CLMHDR_PAT_ACRONYM6 + objClaim_detail_rec.CLMHDR_PAT_ACRONYM3;
                d1_batch_nbr = objClaim_header_rec.CLMHDR_BATCH_NBR;
                d1_claim_nbr = Util.NumInt(objClaim_header_rec.CLMHDR_CLAIM_NBR);
                d1_acronym = objClaim_header_rec.CLMHDR_PAT_ACRONYM6 + objClaim_header_rec.CLMHDR_PAT_ACRONYM3;
                // 	   write print-rec from d1-line after advancing 2 lines;                
                objPrint_rec.print(true);
                objPrint_rec.print(d1_line_grp(), 1, true);

                //     objPat_mstr_rec.pat_ohip_mmyy_r = ""**BLANK IKEY**"";  //todo: pat_ohip_mmyy_r  redefines not in table.

                // 	   go to da4-99-exit.;
                da4_99_exit();
                return;
            }

            //move clmhdr-pat-ohip-id-or-chart   to key-pat-mstr. 
            //string tmp = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_TYPE).PadRight(1) + Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA).PadRight(15);
            string tmp = Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_TYPE).PadRight(1) + Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_DATA).PadRight(15);
            //objPat_mstr_rec.PAT_I_KEY = tmp.Substring(0, 1);
            //objPat_mstr_rec.PAT_CON_NBR = Util.NumDec(tmp.Substring(1, 2));
            //objPat_mstr_rec.PAT_I_NBR = Util.NumDec(tmp.Substring(3, 12));
            //objPat_mstr_rec.FILLER = tmp.Substring(15, 1);


            //     read pat-mstr;
            //  	      invalid key;
            //                d1_batch_nbr = objClaim_header_rec.clmhdr_batch_nbr;
            //                d1_claim_nbr = objClaim_header_rec.clmhdr_claim_nbr;
            //                d1_acronym = objClaim_header_rec.clmhdr_pat_acronym;
            // 	              write print-rec from d1-line after advancing 2 lines;
            //  	          go to da4-99-exit.;

            objPat_mstr_rec = new F010_PAT_MSTR
            {
                WherePat_i_key = tmp.Substring(0, 1),
                WherePat_con_nbr = Util.NumDec(tmp.Substring(1, 2)),
                WherePat_i_nbr = Util.NumDec(tmp.Substring(3, 12)),
                WhereFiller = tmp.Substring(15, 1)
            }.Collection(null).FirstOrDefault();

            if (objPat_mstr_rec == null)
            {
                //d1_batch_nbr = objClaim_detail_rec.CLMHDR_BATCH_NBR;
                //d1_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
                //d1_acronym = objClaim_detail_rec.CLMHDR_PAT_ACRONYM6 + objClaim_detail_rec.CLMHDR_PAT_ACRONYM3;
                d1_batch_nbr = objClaim_header_rec.CLMHDR_BATCH_NBR;
                d1_claim_nbr = Util.NumInt(objClaim_header_rec.CLMHDR_CLAIM_NBR);
                d1_acronym = objClaim_header_rec.CLMHDR_PAT_ACRONYM6 + objClaim_header_rec.CLMHDR_PAT_ACRONYM3;
                // 	              write print-rec from d1-line after advancing 2 lines;                
                objPrint_rec.print(true);
                objPrint_rec.print(d1_line_grp(), 1, true);

                //  go to da4-99-exit.;
                da4_99_exit();
                return;
            }

            //     add 1					to ctr-pat-mstr-reads.;
            ctr_pat_mstr_reads++;
        }

        private void da4_99_exit()
        {            

            //     exit.;          
        }

        private void da6_save_clmhdr_info()
        {         

            //hold_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR);
            //hold_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
            hold_batch_nbr = Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR);
            hold_claim_nbr = Util.NumInt(objClaim_header_rec.CLMHDR_CLAIM_NBR);

            //move clmhdr-pat - ohip - id - or - chart    to hold-pat - key.

            //hold_pat_key_grp = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_TYPE) + objClaim_detail_rec.CLMHDR_PAT_KEY_DATA;
            //hold_pat_key_type = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_TYPE);
            //hold_pat_key_data = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA);
            hold_pat_key_grp = Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_TYPE) + objClaim_header_rec.CLMHDR_PAT_KEY_DATA;
            hold_pat_key_type = Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_TYPE);
            hold_pat_key_data = Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_DATA);
        }

        private void da6_99_exit()
        {         

            //     exit.;          
        }

        private void ma0_move_to_wk_file()
        {         

            //objClaims_work_rec.Wk_dept_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_DOC_DEPT);
            objClaims_work_rec.Wk_dept_nbr = Util.NumInt(objClaim_header_rec.CLMHDR_DOC_DEPT);
            objClaims_work_rec.Wk_age_category = age_category;
            //objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2));   //clmhdr_cli clmhdr_clinic_nbr_1_2;
            //objClaims_work_rec.Wk_doc_nbr = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);    //clmhdr_doc clmhdr_doc_nbr;
            //objClaims_work_rec.Wk_week = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));     // clmhdr_week;
            //objClaims_work_rec.Wk_day = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));    //clmhdr_day;
            //objClaims_work_rec.Wk_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);
            //objClaims_work_rec.Wk_agent_cd = Util.NumInt(objClaim_detail_rec.CLMHDR_AGENT_CD);
            //objClaims_work_rec.Wk_pat_acronym = Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) + Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM3).PadRight(3);  // clmhdr_pat_acronym;
            objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(0, 2));   //clmhdr_cli clmhdr_clinic_nbr_1_2;
            objClaims_work_rec.Wk_doc_nbr = Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);    //clmhdr_doc clmhdr_doc_nbr;
            objClaims_work_rec.Wk_week = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(5, 2));     // clmhdr_week;
            objClaims_work_rec.Wk_day = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(7, 1));    //clmhdr_day;
            objClaims_work_rec.Wk_claim_nbr = Util.NumInt(objClaim_header_rec.CLMHDR_CLAIM_NBR);
            objClaims_work_rec.Wk_agent_cd = Util.NumInt(objClaim_header_rec.CLMHDR_AGENT_CD);
            objClaims_work_rec.Wk_pat_acronym = Util.Str(objClaim_header_rec.CLMHDR_PAT_ACRONYM6).PadRight(6) + Util.Str(objClaim_header_rec.CLMHDR_PAT_ACRONYM3).PadRight(3);  // clmhdr_pat_acronym;

            objClaims_work_rec.Wk_pat_id = "";

            //  perform da4-read-pat			thru da4-99-exit.;
            da4_read_pat();
            da4_99_exit();

            // if pat-health-nbr not = 0 then;            
            if (objPat_mstr_rec != null)
            {
                if (objPat_mstr_rec.PAT_HEALTH_NBR != 0)
                {
                    objClaims_work_rec.Wk_health_nbr = Util.Str(objPat_mstr_rec.PAT_HEALTH_NBR);
                    objClaims_work_rec.Wk_pat_id = Util.Str(objPat_mstr_rec.PAT_HEALTH_NBR) + new string(' ', 5);
                }
                // else if pat-ohip-mmyy-r not = spaces then;            ////todo: pat_ohip_mmyy_r  redefines not in table.   
                else if (string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_DIRECT_ALPHA) && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_YY) == 0 && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_MM) == 0 && Util.NumInt(objPat_mstr_rec.PAT_DIRECT_DD) == 0)
                {
                    objClaims_work_rec.Wk_pat_id = Util.Str(objPat_mstr_rec.PAT_DIRECT_ALPHA).PadRight(3) + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM).PadRight(2) + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD).PadRight(2) + new string(' ', 6);
                }
                else
                {
                    objClaims_work_rec.Wk_pat_id = Util.Str(objPat_mstr_rec.PAT_CHART_NBR);
                }
            }

            //objClaims_work_rec.Wk_ohip_stat = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP);
            //objClaims_work_rec.Wk_ohip_stat_1 = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP).PadRight(2).Substring(0, 1);
            //objClaims_work_rec.Wk_ohip_stat_2 = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP).PadRight(2).Substring(1, 1);
            objClaims_work_rec.Wk_ohip_stat = Util.Str(objClaim_header_rec.CLMHDR_STATUS_OHIP);
            objClaims_work_rec.Wk_ohip_stat_1 = Util.Str(objClaim_header_rec.CLMHDR_STATUS_OHIP).PadRight(2).Substring(0, 1);
            objClaims_work_rec.Wk_ohip_stat_2 = Util.Str(objClaim_header_rec.CLMHDR_STATUS_OHIP).PadRight(2).Substring(1, 1);

            // if clmhdr-agent-cd = 6 then;            
            //if (objClaim_detail_rec.CLMHDR_AGENT_CD == 6)
            if (objClaim_header_rec.CLMHDR_AGENT_CD == 6)
            {
                //objClaims_work_rec.Wk_sub_nbr = Util.Str(objClaim_detail_rec.CLMHDR_SUB_NBR);
                objClaims_work_rec.Wk_sub_nbr = Util.Str(objClaim_header_rec.CLMHDR_SUB_NBR);
            }
            else
            {
                objClaims_work_rec.Wk_sub_nbr = "0";
            }

            //objClaims_work_rec.Wk_oma_fee = Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            //objClaims_work_rec.Wk_ohip_fee = Util.NumDec(objClaim_detail_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            //objClaims_work_rec.Wk_amount_paid = Util.NumDec(objClaim_detail_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            objClaims_work_rec.Wk_oma_fee = Util.NumDec(objClaim_header_rec.CLMHDR_TOT_CLAIM_AR_OMA);
            objClaims_work_rec.Wk_ohip_fee = Util.NumDec(objClaim_header_rec.CLMHDR_TOT_CLAIM_AR_OHIP);
            objClaims_work_rec.Wk_amount_paid = Util.NumDec(objClaim_header_rec.CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
            objClaims_work_rec.Wk_balance_due = balance_due;
            //objClaims_work_rec.Wk_period_end_date = Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END);
            //objClaims_work_rec.Wk_period_end_yy = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(0, 4));
            //objClaims_work_rec.Wk_period_end_mm = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(4, 2));
            //objClaims_work_rec.Wk_period_end_dd = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(6, 2));
            objClaims_work_rec.Wk_period_end_date = Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END);
            objClaims_work_rec.Wk_period_end_yy = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(0, 4));
            objClaims_work_rec.Wk_period_end_mm = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(4, 2));
            objClaims_work_rec.Wk_period_end_dd = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_DATE_PERIOD_END).PadRight(8, '0').Substring(6, 2));
            objClaims_work_rec.Wk_day_old = day_old_r;

            //move clmhdr-orig - batch - nbr - 1 - 2      to wk-batch - nbr - 1 - 2.
            //objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(0, 2));
            objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(Util.Str(objClaim_header_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(0, 2));

            //objClaims_work_rec.Wk_batch_nbr_4_9 = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 6);  //clmhdr_orig_batch_nbr_4_9;
            //objClaims_work_rec.Wk_tape_submit_ind = Util.Str(objClaim_detail_rec.CLMHDR_TAPE_SUBMIT_IND);
            //objClaims_work_rec.Wk_act_taken = Util.Str(objClaim_detail_rec.CLMHDR_REFERENCE);
            //objClaims_work_rec.Wk_act_taken_1 = Util.Str(objClaim_detail_rec.CLMHDR_REFERENCE).PadRight(11).Substring(0, 3);
            //objClaims_work_rec.Wk_act_taken_2 = Util.Str(objClaim_detail_rec.CLMHDR_REFERENCE).PadRight(11).Substring(3, 8);
            objClaims_work_rec.Wk_batch_nbr_4_9 = Util.Str(objClaim_header_rec.CLMHDR_ORIG_BATCH_NBR).PadRight(8).Substring(2, 6);  //clmhdr_orig_batch_nbr_4_9;
            objClaims_work_rec.Wk_tape_submit_ind = Util.Str(objClaim_header_rec.CLMHDR_TAPE_SUBMIT_IND);
            objClaims_work_rec.Wk_act_taken = Util.Str(objClaim_header_rec.CLMHDR_REFERENCE);
            objClaims_work_rec.Wk_act_taken_1 = Util.Str(objClaim_header_rec.CLMHDR_REFERENCE).PadRight(11).Substring(0, 3);
            objClaims_work_rec.Wk_act_taken_2 = Util.Str(objClaim_header_rec.CLMHDR_REFERENCE).PadRight(11).Substring(3, 8);

            //     read claims-mstr next;   
            //         at end;
            //           err_ind = 7;
            //            clm_dtl_err_msg = objClaims_mstr_dtl_rec.key_claims_mstr;
            // 		      perform za0-common-error	thru za0-99-exit;
            //             objClaims_work_rec.wk_ser_date = 0;

            bool isRetrieving = false;
            ctr_claims_mstr_dtl_reads = 0;

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = objClaim_header_rec.KEY_CLM_TYPE,
                WhereKey_clm_batch_nbr = objClaim_header_rec.KEY_CLM_BATCH_NBR,
                WhereKey_clm_claim_nbr = objClaim_header_rec.KEY_CLM_CLAIM_NBR
            }.Collection_DTL_For_Clinic_NBR(ref isRetrieving, Claim_detail_rec_Collection);

            objClaim_detail_rec = Read_Claims_Mstr_Resultset();

            //move clmdtl-sv - date             to wk-ser - date.
            if (objClaim_detail_rec != null)
            {
                objClaims_work_rec.Wk_ser_date = Util.Str(objClaim_detail_rec.CLMDTL_SV_YY) + Util.Str(objClaim_detail_rec.CLMDTL_SV_MM).PadLeft(2, '0') + Util.Str(objClaim_detail_rec.CLMDTL_SV_DD).PadLeft(2, '0');
                objClaims_work_rec.Wk_ser_yy = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_YY);
                objClaims_work_rec.Wk_ser_mm = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_MM);
                objClaims_work_rec.Wk_ser_dd = Util.NumInt(objClaim_detail_rec.CLMDTL_SV_DD);
            }
            else
            {
                err_ind = 7;
                //clm_dtl_err_msg = objClaims_mstr_dtl_rec.key_claims_mstr;
                //perform za0-common - error    thru za0-99 - exit;
                za0_common_error();
                za0_99_exit();
                objClaims_work_rec.Wk_ser_date = "0";
                objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL();
            }
        }

        private void ma0_99_exit()
        {            

            //     exit.;           
        }

        private void wa0_write_to_wk_file()
        {         

            //  perform ma0-move-to-wk-file     		thru ma0-99-exit.;
            ma0_move_to_wk_file();
            ma0_99_exit();

            // objClaims_work_rec.Wk_ohip_nbr

            //  write claims-work-rec.;
            string tempRecord = Util.Str(objClaims_work_rec.Wk_dept_nbr).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_sort_record_status).PadLeft(1, '0') +
                                 Util.Str(objClaims_work_rec.Wk_agent_cd).PadLeft(1, '0') +
                                 Util.Str(objClaims_work_rec.Wk_age_category).PadLeft(1, '0') +
                                 Util.Str(objClaims_work_rec.Wk_pat_acronym).PadRight(9) +
                                 Util.Str(objClaims_work_rec.Wk_pat_id).PadRight(15) +          
                                 Util.Str(objClaims_work_rec.Wk_clinic_nbr).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_doc_nbr).PadRight(3) +
                                 Util.Str(objClaims_work_rec.Wk_week).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_day).PadLeft(1, '0') +
                                 Util.Str(objClaims_work_rec.Wk_claim_nbr).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_ohip_stat_1).PadRight(1) +
                                 Util.Str(objClaims_work_rec.Wk_ohip_stat_2).PadLeft(1, '0') +
                                 Util.Str(objClaims_work_rec.Wk_sub_nbr).PadRight(1) +
                                 Util.ConvertZone(Util.NumInt(objClaims_work_rec.Wk_oma_fee), 9) +
                                 Util.ConvertZone(Util.NumInt(objClaims_work_rec.Wk_ohip_fee), 9) +
                                 Util.ConvertZone(Util.NumInt(objClaims_work_rec.Wk_amount_paid), 9) +
                                 Util.ConvertZone(Util.NumInt(objClaims_work_rec.Wk_balance_due), 9) +
                                 Util.Str(objClaims_work_rec.Wk_period_end_yy).PadLeft(4, '0') +
                                 Util.Str(objClaims_work_rec.Wk_period_end_mm).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_period_end_dd).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_ser_yy).PadLeft(4, '0') +
                                 Util.Str(objClaims_work_rec.Wk_ser_mm).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_ser_dd).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_day_old).PadRight(3) +
                                 Util.Str(objClaims_work_rec.Wk_batch_nbr_1_2).PadLeft(2, '0') +
                                 Util.Str(objClaims_work_rec.Wk_batch_nbr_4_9).PadRight(6) +
                                 Util.Str(objClaims_work_rec.Wk_tape_submit_ind).PadRight(1) +
                                 Util.Str(objClaims_work_rec.Wk_act_taken_1).PadRight(3) +
                                 Util.Str(objClaims_work_rec.Wk_act_taken_2).PadLeft(8, '0');

            objClaims_work_rec_file.AppendOutputFile(tempRecord);

        }

        private void wa0_99_exit()
        {            

            //     exit.;            
        }

        private void za0_common_error()
        {         

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-comment.;
            Console.WriteLine(err_msg_comment);
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
            sys_date_numeric += 20000000;
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {            

            //     exit.;           
        }

        private string d1_line_grp()
        {         

            return new string(' ', 20) + 
                  Util.Str(d1_batch_nbr).PadRight(8) + 
                  Util.Str(d1_claim_nbr).PadLeft(2, '0') + 
                  new string(' ', 11) + 
                  Util.Str(d1_acronym).PadRight(9) + 
                  new string(' ', 81);
        }

        private string h1_head_grp()
        {            

            return new string(' ', 50) + "ERROR REPORT FOR R070A".PadRight(82);
        }

        private string h2_head_grp()
        {         

            return  new string(' ', 20) + 
                    "CLAIMS NBR".PadRight(22) + 
                    "ACRONYM".PadRight(90);
        }

        #endregion

        #region SearchFromResultset       

        public F002_CLAIMS_MSTR_DTL Read_Claims_Mstr_Resultset()
        {
            F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;

            if (ctr_claims_mstr_dtl_reads < Claim_detail_rec_Collection.Count())
            {               
                objF002_CLAIMS_MSTR_DTL = Claim_detail_rec_Collection[ctr_claims_mstr_dtl_reads];
            }
            ctr_claims_mstr_dtl_reads++;

            return objF002_CLAIMS_MSTR_DTL;
        }

       /* public void Filter_ClaimsHdr_Collection()
        {            

            ObservableCollection<F002_CLAIMS_MSTR_DTL> tmpClaim_detail_rec_Collection = null;
            tmpClaim_detail_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            string tmpRowID = string.Empty;
            bool ftf = true;
            foreach (var obj in Claim_detail_rec_Collection)
            {
                if (ftf == false)
                {
                    if (!obj.ROWID_HDR.ToString().Equals(tmpRowID))
                    {
                        ftf = true;
                    }
                }

                if (ftf == true)
                {
                    tmpRowID = obj.ROWID_HDR.ToString();
                    ftf = false;
                    tmpClaim_detail_rec_Collection.Add(obj);
                }
            }

            Claim_detail_rec_Collection.Clear();
            foreach (var obj in tmpClaim_detail_rec_Collection)
            {
                Claim_detail_rec_Collection.Add(obj);
            }
        } */

        #endregion

    }
}


