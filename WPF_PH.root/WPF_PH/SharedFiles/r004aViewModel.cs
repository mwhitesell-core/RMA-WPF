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
using System.Data.SqlClient;


namespace rma.Views
{
    public class R004aViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private Print_record objPrint_record = null;
        // private ObservableCollection<Print_record> Print_record_Collection;

        // FD: batch_ctrl_file	Copy : f001_batch_control_file.fd
        private F001_BATCH_CONTROL_FILE objBatctrl_rec = null;
        private ObservableCollection<F001_BATCH_CONTROL_FILE> Batctrl_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd 
        //private Claims_mstr_rec objClaims_mstr_rec = null;   // Claims_mstr_rec
        //    private ObservableCollection<Claims_mstr_rec> Claims_mstr_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr.fd
        // private Claims_mstr_dtl_rec objClaims_mstr_dtl_rec = null;     // Claims_mstr_dtl_rec
        //    private ObservableCollection<Claims_mstr_dtl_rec> Claims_mstr_dtl_rec_Collection;


        // Added
        private F002_CLAIMS_MSTR_DTL_DESC objClaim_detail_description_rec;
        private ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC> Claim_detail_description_rec_Collection;


        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_HDR objClaim_header_rec = null;      // Claim_header_rec
        private ObservableCollection<F002_CLAIMS_MSTR_HDR> Claim_header_rec_Collection;

        // FD: claims_mstr	Copy : f002_claims_mstr_rec1_2.ws
        private F002_CLAIMS_MSTR_DTL objClaim_detail_rec = null;        // Claim_detail_rec
        private ObservableCollection<F002_CLAIMS_MSTR_DTL> Claim_detail_rec_Collection;

        // FD: pat_mstr	Copy : f010_patient_mstr.fd
        private F010_PAT_MSTR objPat_mstr_rec = null;
        private ObservableCollection<F010_PAT_MSTR> Pat_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: r004_work_file	Copy : r004_claims_work_mstr.fd
        private R004_Work_file_rec objWork_file_rec = null;
        private ObservableCollection<R004_Work_file_rec> Work_file_rec_Collection;

        // FD: parameter_file	Copy : r004_parm_file.fd
        private Parm_file_rec objParm_file_rec = null;
        private ObservableCollection<Parm_file_rec> Parm_file_rec_Collection;

        private WriteFile objr004_work_file = null;
        private WriteFile objParameter_file = null;

        private ReportPrint objPrintFile = null;

        private SqlConnection objConn;

        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string print_file_name = "r004";
        private string option;
        private int max_nbr_lines = 60;
        private int ctr_lines = 70;
        private string ws_reply;
        private string ws_i_o_pat_ind;
        private decimal batch_total = 0;
        private decimal batch_diff = 0;
        private decimal ws_fee_ohip;
        private int ws_nbr_serv;
        private int nbr_rec_processed;
        private decimal ws_rev_calcd = 0;
        private decimal rev_calcd_total = 0;
        private decimal update_amt_total = 0;
        private decimal diff_total = 0;
        private string hold_clmhdr_batch_nbr;
        private int hold_clmhdr_claim_nbr;
        private string const_mstr_rec_nbr;
        private string feedback_claims_mstr;
        private string feedback_pat_mstr;
        private string feedback_docrev_mstr;
        private string feedback_batctrl_file;
        private string feedback_iconst_mstr;
        private string blank_line = "";
        private string eof_batctrl_file = "N";
        private string eof_claims_dtl = "N";
        private string eof_claims_mstr = "N";
        private string eof_work_file = "N";
        private string new_header = "N";
        private int sub1 = 0;
        private int ss;
        private string common_status_file;
        private string status_cobol_batctrl_file = "0";
        private string status_cobol_claims_mstr = "0";
        private string status_cobol_pat_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_prt_file = "0";
        private string status_sort_file;
        private int sel_clinic_nbr;
        private int claims_occur;
        private int pat_occur;

        private string tmp_doc_nbr_alpha_grp;
        private string[] tmp_batch_nbr_index = new string[9];
        private string flag_request_complete;
        private string flag_request_complete_y = "Y";
        private string flag_request_complete_n = "N";
        private string flag_rec;
        private string valid_rec = "Y";
        private string invalid_rec = "N";

        private string totals_table_grp;
        private string[] oma_or_ohip = new string[3];
        private string[,] totals = new string[3, 7];
        private decimal[,] doc_totals = new decimal[3, 7];
        private decimal[,] dept_totals = new decimal[3, 7];
        private decimal[,] grand_totals = new decimal[3, 7];

        private string counters_grp;
        private int ctr_batctrl_file_reads;
        private int ctr_claims_mstr_reads;
        private int ctr_pat_mstr_reads;
        private int ctr_work_file_writes;
        private int ctr_work_file_reads;
        private int ctr_doc_mstr_reads;
        private int ctr_invalid_ikey;
        private int ctr_pages;

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "INVALID READ ON CONSTANTS MASTER";
        private string filler = "invalid reply";
        private string filler = "NO BATCTRL FILE SUPPLIED";
        private string filler = "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER";
        private string filler = "NO APPROPRIATE RECORDS IN BATCTRL FILE"; */  // todo...
        private string err_msg_7_grp;
        //private string filler = "NO CLAIM FOR CURRENT BATCH - F001/F002 = ";
        private string err_msg_7_keys_grp;
        private string miss_batch_nbr;
        //private string filler = '/';
        private string miss_f002_batch_nbr;
        private int miss_claim_nbr;
        private string err_msg_red_grp;
        private string err_msg_7_key;
        private string wrong_claim_err_grp;
        //private string filler = "DIFFERENT PED - F001/F002 = ";      // todo
        private string wrong_batch_nbr;
        private int wrong_claim_nbr;
        //private string filler = '/';
        private string wrong_f001_ped;
        //private string filler = '/';
        private string wrong_f002_ped;
        /* private string filler = "invalid month";
         private string filler = "ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING";
         private string filler = "INVALID BATCH TYPE";
         private string filler = "WORK FILE EMPTY";
         private string filler = "INVALID READ ON DOCTOR MASTER FILE";
         private string filler = "INVALID READ ON PATIENT MASTER FILE"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply", "INVALID READ ON CONSTANTS MASTER", "invalid reply" , "NO BATCTRL FILE SUPPLIED" , "NO BATCH CONTROL RECORDS FOR CLINIC NUMBER" , "NO APPROPRIATE RECORDS IN BATCTRL FILE" ,
                                     "NO CLAIM FOR CURRENT BATCH - F001/F002 = ", "DIFFERENT PED - F001/F002 = ", "invalid month", "ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING", "INVALID BATCH TYPE",
                                      "WORK FILE EMPTY", "INVALID READ ON DOCTOR MASTER FILE", "INVALID READ ON PATIENT MASTER FILE" };
        private string err_msg_comment;

        private string e1_error_line_grp;
        private string e1_error_word = "***  ERROR - ";
        private string e1_error_msg;
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

        private int prm_sel_clinic_nbr;
        private string prm_ws_replay;
        private string endOfJob = "End of Job";
        private bool isRetrieving = false;
        private bool isBypass = false;
        private int ctr;
        private int NotReadsCtr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_batctrl_file_section()
        {
            //     use after standard error procedure on batch-ctrl-file.;
        }

        private void err_batctrl()
        {

            common_status_file = status_cobol_batctrl_file;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING BATCH CONTROL FILE".;
        }

        private void err_constants_mstr_file_section()
        {
            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_constants_mstr()
        {

            common_status_file = status_cobol_iconst_mstr;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING ICONSTANTS MASTER".;
        }

        private void err_claim_header_mstr_file_section()
        {
            //     use after standard error procedure on claims-mstr.;
        }

        private void err_claims_mstr()
        {

            common_status_file = status_cobol_claims_mstr;
            //     display common-status-file.;
            //     stop "ERROR IN ACCESSING CLAIMS MASTER".;
        }

        private void err_pat_mstr_file_section()
        {

            //    use after standard error procedure on pat-mstr.;
        }

        private void err_pat_mstr()
        {

            common_status_file = status_cobol_pat_mstr;
            //     display common-status-file.;
            //     stop "PROGRAM ABORTED - HIT NEWLINE".;
            //     stop run.;
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {

        }

        public async void mainline(int sel_clinic_nbr, string ws_reply)
        {

            try
            {

                prm_sel_clinic_nbr = sel_clinic_nbr;
                prm_ws_replay = ws_reply;

                objPrint_record = null;
                objPrint_record = new Print_record();

                objPrintFile = null;
                objPrintFile = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + print_file_name);

                // "$pb_data/f001_batch_control_file" .. it's in database..!
                objBatctrl_rec = null;
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                Batctrl_rec_Collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

                objClaim_detail_description_rec = new F002_CLAIMS_MSTR_DTL_DESC(); // 
                Claim_detail_description_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();

                objClaim_header_rec = new F002_CLAIMS_MSTR_HDR();      // Claim_header_rec
                Claim_header_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();

                objClaim_detail_rec = new F002_CLAIMS_MSTR_DTL();        // Claim_detail_rec
                Claim_detail_rec_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

                // $pb_data/f010_pat_mstr  ..it's in database..!
                objPat_mstr_rec = new F010_PAT_MSTR();
                Pat_mstr_rec_Collection = new ObservableCollection<F010_PAT_MSTR>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objWork_file_rec = new R004_Work_file_rec();
                Work_file_rec_Collection = new ObservableCollection<R004_Work_file_rec>();

                objr004_work_file = null;
                objr004_work_file = new WriteFile(Directory.GetCurrentDirectory() + "\\r004wf");

                objParameter_file = null;
                objParameter_file = new WriteFile(Directory.GetCurrentDirectory() + "\\r004_parm_file");

                objConn = objClaim_detail_rec.Connection();

                //     perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();

                isBypass = false;
                while (Util.Str(eof_batctrl_file).ToUpper() != "Y")
                {
                    if (isBypass == false)
                    {
                        aa0_10_enter_clinic_nbr();
                    }
                    eof_claims_mstr = "N";
                    eof_claims_dtl = "N";
                    while (Util.Str(eof_claims_mstr).ToUpper() != "Y" && Util.Str(eof_claims_dtl).ToUpper() != "Y" && Util.Str(eof_batctrl_file).ToUpper() != "Y")
                    {
                        aa0_20_continue();
                        aa0_99_exit();

                        //     perform ab0-create-work-file	thru ab0-99-exit.;
                        ab0_create_work_file();
                        ab0_99_exit();
                    }
                }

                //     perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_99_exit();
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
                if (objr004_work_file != null)
                    objr004_work_file.CloseOutputFile();
                if (objParameter_file != null)
                    objParameter_file.CloseOutputFile();
                if (objPrintFile != null)
                    objPrintFile.Close();
            }

            //     stop run.;
        }

        private void aa0_initialization()
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
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

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

            //     open input	batch-ctrl-file;    // "$pb_data/f001_batch_control_file" 
            // 		iconst-mstr;                    
            // 		pat-mstr;                       // $pb_data/f010_pat_mstr  
            // 		claims-mstr.;            // master header/ detail / desc 3 tables

            //     open output r004-work-file.;
            //     open output parameter-file.;

            //objWork_file_rec.work_file_rec = "";            
        }

        private void aa0_10_enter_clinic_nbr()
        {

            //     accept sel-clinic-nbr.;
            sel_clinic_nbr = prm_sel_clinic_nbr;

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = sel_clinic_nbr;
            //     read iconst-mstr;
            //       invalid key;
            //       err_ind = 2;
            // 	perform za0-common-error	thru	za0-99-exit;
            // 	go to aa0-10-enter-clinic-nbr.;

            objIconst_mstr_rec = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = sel_clinic_nbr
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec == null)
            {
                err_ind = 2;
                za0_common_error();
                za0_99_exit();
                aa0_10_enter_clinic_nbr();
                return;
            }

        }

        private void aa0_20_continue()
        {

            if (isBypass == false)
            {
                ws_reply = "";
                //     accept ws-reply.;
                ws_reply = prm_ws_replay;

                // if ws-reply = 'Y'  or ws-reply = 'N'  then;            
                //     	next sentence;
                // else;
                //     err_ind = 1;
                // 	   perform za0-common-error	thru	za0-99-exit;
                // 	   go to aa0-20-continue.;

                if (ws_reply.ToUpper().Equals("Y") || ws_reply.ToUpper().Equals("N"))
                {
                    // next sentence
                }
                else
                {
                    err_ind = 1;
                    za0_common_error();
                    za0_99_exit();
                    aa0_20_continue();
                    return;
                }

                // if ws-reply = 'N' then;            
                // 	  go to az0-end-of-job.;

                if (ws_reply.ToUpper().Equals("N"))
                {
                    az0_end_of_job();
                }

                objParm_file_rec = new Parm_file_rec();
                objParm_file_rec.Parm_clinic_nbr = Util.Str(sel_clinic_nbr);
                objParm_file_rec.Parm_clinic_name = objIconst_mstr_rec.ICONST_CLINIC_NAME;
                // objParm_file_rec.par //parm_date_period_end = objIconst_mstr_rec.iconst_date_period_end;
                objParm_file_rec.Parm_ped_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
                objParm_file_rec.Parm_ped_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
                objParm_file_rec.Parm_ped_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);

                string temp = objParm_file_rec.Parm_clinic_nbr.PadLeft(2, '0') + objParm_file_rec.Parm_clinic_name.PadRight(20, ' ') + Util.Str(objParm_file_rec.Parm_ped_yy).PadLeft(4, '0') + Util.Str(objParm_file_rec.Parm_ped_mm).PadLeft(2, '0') + Util.Str(objParm_file_rec.Parm_ped_dd).PadLeft(2, '0');

                //     write parm-file-rec.;
                objParameter_file.AppendOutputFile(temp, true);
            }

            isBypass = true;

            //objBatctrl_rec.batctrl_bat_clinic_nbr_1_2 = sel_clinic_nbr;
            //     start batch-ctrl-file key is greater than or equal to key-batctrl-file;
            // 	invalid key;
            //  err_ind = 4;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-end-of-job.;
            //     read batch-ctrl-file next.;

            // objBatctrl_rec.Batctrl_bat_clinic_nbr_1_2 = sel_clinic_nbr;

            isRetrieving = false;
            Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
            {
                WhereBatctrl_batch_nbr = Util.Str(sel_clinic_nbr)  // todo: 8 digits in table. verify this???
            }.Collection_Using_Start_Batctrl_bat_clinic_nbr_1_2(ref isRetrieving, Batctrl_rec_Collection);

            if (Batctrl_rec_Collection.Count() == 0)
            {
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                eof_batctrl_file = "Y";
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                    eof_batctrl_file = "Y";
                    return;
                }
                else
                {
                    if (isRetrieving) ctr_batctrl_file_reads = 0;
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];

                    //     add 1				to ctr-batctrl-file-reads.;
                    ctr_batctrl_file_reads++;
                }
            }

            //     perform aa1-sel-read-next-batctrl	thru aa1-99-exit;
            // 	until   eof-batctrl-file = "Y";
            // 	     or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (!eof_batctrl_file.ToUpper().Equals("Y") && !flag_rec.Equals(valid_rec));

            // if eof-batctrl-file = "Y" then;            
            //   perform za0-common-error	thru za0-99-exit;
            // 	 go to az0-end-of-job.;

            if (eof_batctrl_file.ToUpper().Equals("Y"))
            {
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }

            //     perform aa11-read-claim		thru aa11-99-exit.;
            aa11_read_claim();
            aa11_99_exit();

            new_header = "Y";
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void aa1_sel_read_next_batctrl()
        {

            // if batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr then;            
            //    err_ind = 5;
            //    eof_batctrl_file = "Y";
            // 	  go to aa1-99-exit.;

            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).Substring(0, 2) != Util.Str(sel_clinic_nbr))
            {
                err_ind = 5;
                eof_batctrl_file = "Y";
                aa1_99_exit();
                return;
            }

            //  if  (batctrl-date-period-end = iconst-date-period-end)
            //       and ( (batctrl-batch-type = "C") or (    batctrl-batch-type  = "A"  and batctrl-adj-cd = "B" or "R") or (  batctrl-batch-type = "P"  and batctrl-adj-cd = "M"))  then                       
            //            flag_rec = "Y";
            // 	          go to aa1-99-exit;
            //  else;
            //         flag_rec = "N";

            if (Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END) == (Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY.ToString()) + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM.ToString()).PadLeft(2, '0') + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD.ToString()).PadLeft(2, '0'))
                    && ((objBatctrl_rec.BATCTRL_BATCH_TYPE.ToUpper().Equals("C")) || (objBatctrl_rec.BATCTRL_BATCH_TYPE.ToUpper().Equals("A") && objBatctrl_rec.BATCTRL_ADJ_CD.ToUpper().Equals("B") || objBatctrl_rec.BATCTRL_ADJ_CD.ToUpper().Equals("R"))
                    || (objBatctrl_rec.BATCTRL_BATCH_TYPE.ToUpper().Equals("P") && objBatctrl_rec.BATCTRL_ADJ_CD.ToUpper().Equals("M"))))
            {
                flag_rec = "Y";
                aa1_99_exit();
                return;
            }
            else
            {
                flag_rec = "N";
            }

            //  read batch-ctrl-file next at end
            //      err_ind = 6;
            //      eof_batctrl_file = "Y";
            // 	    go to aa1-99-exit.;

            /* isRetrieving = false;
             Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
             {
                 WhereBatctrl_batch_nbr = Util.Str(sel_clinic_nbr)  
             }.Collection_Using_Start_Batctrl_bat_clinic_nbr_1_2(ref isRetrieving, Batctrl_rec_Collection); */

            if (Batctrl_rec_Collection.Count() == 0)
            {
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                eof_batctrl_file = "Y";
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                    eof_batctrl_file = "Y";
                    return;
                }
                else
                {
                    //if (isRetrieving) ctr_batctrl_file_reads = 0;
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];

                    //     add 1				to ctr-batctrl-file-reads.;
                    ctr_batctrl_file_reads++;
                }
            }
        }

        private void aa1_99_exit()
        {
            //     exit.;
        }

        private void aa11_read_claim()
        {

            //  perform aa2-read-clmhdr		thru aa2-99-exit.;
            aa2_read_clmhdr();
            aa2_99_exit();

            //  if  (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) then;            
            //      err_ind = 7;
            //      miss_batch_nbr = objBatctrl_rec.batctrl_batch_nbr;
            //      miss_f002_batch_nbr = objClaim_header_rec.clmhdr_orig_batch_nbr;
            //      miss_claim_nbr = objClaim_header_rec.clmhdr_orig_claim_nbr;
            //       perform za0-common-error        thru    za0-99-exit;
            //         go to az0-end-of-job.;

            if (objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR != objBatctrl_rec.BATCTRL_BATCH_NBR)
            {
                err_ind = 7;
                miss_batch_nbr = objBatctrl_rec.BATCTRL_BATCH_NBR;
                miss_f002_batch_nbr = objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR;
                miss_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }


            //  if (clmhdr-date-period-end not = batctrl-date-period-end) then;            
            //      err_ind = 8;
            //      wrong_batch_nbr = objBatctrl_rec.batctrl_batch_nbr;
            //      wrong_claim_nbr = objClaim_header_rec.clmhdr_orig_claim_nbr;
            //      wrong_f001_ped = objBatctrl_rec.batctrl_date_period_end;
            //      wrong_f002_ped = objClaim_header_rec.clmhdr_date_period_end;
            //      perform za0-common-error        thru    za0-99-exit;
            //         go to az0-end-of-job.;

            if (Util.NumInt(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.NumInt(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                err_ind = 8;
                wrong_batch_nbr = Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR);
                wrong_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);
                wrong_f001_ped = Util.Str(objBatctrl_rec.BATCTRL_DATE_PERIOD_END);
                wrong_f002_ped = Util.Str(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END);
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }
        }

        private void aa11_99_exit()
        {
            //     exit.;
        }

        private void aa2_read_clmhdr()
        {

            //objClaim_header_rec.clmhdr_claim_id = 0;
            objClaim_header_rec.CLMHDR_BATCH_NBR = "0";
            objClaim_header_rec.CLMHDR_CLAIM_NBR = 0;
            objClaim_header_rec.CLMHDR_ADJ_OMA_CD = "";
            objClaim_header_rec.CLMHDR_ADJ_OMA_SUFF = "";
            objClaim_header_rec.CLMHDR_ADJ_ADJ_NBR = "";

            claims_occur = 0;
            feedback_claims_mstr = "0";

            objClaim_header_rec.CLMHDR_BATCH_NBR = objBatctrl_rec.BATCTRL_BATCH_NBR;
            objClaim_header_rec.CLMHDR_CLAIM_NBR = 1;


            //move clmhdr-claim - id        to clmdtl-b - data.
            //move "B"                to clmdtl-b - key - type.

            // objClaims_mstr_dtl_rec.Clmdtl_b_data = Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR) + Util.Str(objClaim_header_rec.CLMHDR_CLAIM_NBR) + Util.Str(objClaim_header_rec.CLMHDR_ADJ_OMA_CD) + Util.Str(objClaim_header_rec.CLMHDR_ADJ_OMA_SUFF) + Util.Str(objClaim_header_rec.CLMHDR_ADJ_ADJ_NBR);
            objClaim_detail_rec.CLMDTL_BATCH_NBR = Util.Str(objClaim_header_rec.CLMHDR_BATCH_NBR);
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = Util.NumDec(objClaim_header_rec.CLMHDR_CLAIM_NBR);
            objClaim_detail_rec.CLMDTL_OMA_CD = Util.Str(objClaim_header_rec.CLMHDR_ADJ_OMA_CD);
            objClaim_detail_rec.CLMDTL_OMA_SUFF = Util.Str(objClaim_header_rec.CLMHDR_ADJ_OMA_SUFF);
            objClaim_detail_rec.CLMDTL_ADJ_NBR = Util.NumDec(objClaim_header_rec.CLMHDR_ADJ_ADJ_NBR);

            //objClaims_mstr_dtl_rec.Clmdtl_b_key_type = "B";   // ??? 
            objClaim_detail_rec.KEY_CLM_TYPE = "B";

            //  start claims-mstr key is greater than or equal to key-claims-mstr;
            // 	invalid key;
            //         err_ind = 7;
            //         err_msg_7_key = objBatctrl_rec.batctrl_batch_nbr;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    go to az0-end-of-job.;

            //     read claims-mstr next.;

            ctr_claims_mstr_reads = 0;

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
                WhereKey_clm_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,   //"73800038", 
                WhereKey_clm_claim_nbr = objClaim_detail_rec.CLMDTL_CLAIM_NBR
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(20000, false, objConn);

            //if (objClaim_header_rec == null)
            if (Claim_detail_rec_Collection.Count() == 0)
            {
                err_ind = 7;
                err_msg_7_key = objBatctrl_rec.BATCTRL_BATCH_NBR;
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }

            objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_mstr_reads];
            ctr_claims_mstr_reads++;

            //  if status-cobol-claims-mstr =  23 or 99 then;            
            //     err_ind = 7;
            //      err_msg_7_key = objBatctrl_rec.batctrl_batch_nbr;
            // 	   perform za0-common-error	thru	za0-99-exit;
            // 	   go to az0-end-of-job.;

            if (status_cobol_claims_mstr == "23" || status_cobol_claims_mstr == "99")
            {
                err_ind = 7;
                err_msg_7_key = objBatctrl_rec.BATCTRL_BATCH_NBR;
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }

            //  if clmdtl-b-key-type not = "B" then;            
            //      err_ind = 7;
            //      err_msg_7_key = objBatctrl_rec.batctrl_batch_nbr;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    go to az0-end-of-job.;

            if (!objClaim_detail_rec.KEY_CLM_TYPE.ToUpper().Equals("B"))
            {
                err_ind = 7;
                err_msg_7_key = objBatctrl_rec.BATCTRL_BATCH_NBR;
                za0_common_error();
                za0_99_exit();
                az0_end_of_job();
                return;
            }

            //   hold_clmhdr_batch_nbr = objClaim_header_rec.clmhdr_orig_batch_nbr;
            //   hold_clmhdr_claim_nbr = objClaim_header_rec.clmhdr_orig_claim_nbr;

            hold_clmhdr_batch_nbr = Util.Str(objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR);
            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);
        }

        private void aa2_99_exit()
        {

            //     exit.;
        }

        private void az0_end_of_job()
        {

            //     close batch-ctrl-file;
            // 	  r004-work-file;
            // 	  parameter-file;
            // 	  iconst-mstr;
            // 	  pat-mstr;
            // 	  claims-mstr.;
            //     accept sys-time			from time.;
            //     stop run.;

            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {

            //     exit.;
        }

        private void ab0_create_work_file()
        {

            bool readnext = false;
            while (eof_claims_mstr.ToUpper().Equals("N"))
            {

                // if  clmhdr-orig-batch-nbr  not = batctrl-batch-nbr or clmhdr-date-period-end not = batctrl-date-period-end  then;            
                // 	   perform ga0-read-next-batch	thru	ga0-99-exit.;

                if (objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR != objBatctrl_rec.BATCTRL_BATCH_NBR || Util.NumDec(objClaim_detail_rec.CLMHDR_DATE_PERIOD_END) != Util.NumDec(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
                {
                    ga0_read_next_batch();
                    ga0_99_exit();
                }

                // if eof-batctrl-file = "Y" then;            
                // 	  go to ab0-99-exit.;

                if (eof_batctrl_file.ToUpper().Equals("Y"))
                {
                    ab0_99_exit();
                    break;
                    return;
                }

                readnext = false;
                if (Util.Str(new_header).ToUpper() == "Y" && Util.Str(eof_claims_dtl).ToUpper() == "Y")
                {
                    if (NotReadsCtr > 6)
                    {
                        readnext = true;
                    }
                }

                new_header = "N";
                eof_claims_dtl = "N";

                //  perform ca0-build-wf-rec-from-hdr	thru	ca0-99-exit.;
                ca0_build_wf_rec_from_hdr();
                ca0_99_exit();

                //  perform ba0-process-dtl-recs	thru	ba0-99-exit;
                // 		until eof-claims-dtl = "Y".;


                do
                {
                    ba0_process_dtl_recs(readnext);
                    ba0_99_exit();
                    readnext = true;
                } while (!eof_claims_dtl.ToUpper().Equals("Y"));

                //  if eof-claims-mstr     = "N" and new-header      not = "Y"  then            
                // 	    perform ha0-read-clmhdr-next	thru	ha0-99-exit.;

                if (eof_claims_mstr.ToUpper().Equals("N") && !new_header.ToUpper().Equals("Y"))
                {
                    ha0_read_clmhdr_next();
                    ha0_99_exit();
                }

                //  if eof-claims-mstr = "N" then;            
                // 	   go to ab0-create-work-file.;

                /* if (eof_claims_mstr.ToUpper().Equals("N"))
                 {
                     ab0_create_work_file();
                     return;
                 } */
            }

        }

        private void ab0_99_exit()
        {
            //     exit.;
        }

        private void ba0_process_dtl_recs(bool isReadNext = false)
        {

            // perform da0-read-dtl-next-clm	thru da0-99-exit.;
            da0_read_dtl_next_clm(isReadNext);
            da0_10_check_clinic();
            da0_99_exit();

            // if eof-claims-dtl = "Y" then;            
            // 	go to ba0-99-exit.;

            if (eof_claims_dtl.ToUpper().Equals("Y"))
            {
                ba0_99_exit();
                return;
            }

            // perform cb0-build-wf-rec-from-dtl	thru	cb0-99-exit.;
            cb0_build_wf_rec_from_dtl();
            cb0_99_exit();

            // perform cd0-write-to-work-file	thru 	cd0-99-exit.;
            cd0_write_to_work_file();
            cd0_99_exit();
        }

        private void ba0_99_exit()
        {

            //     exit.;
        }

        private void ca0_build_wf_rec_from_hdr()
        {

            //   *(d e t a i l rec) 

            objWork_file_rec.Wf_dept = Util.NumInt(objClaim_detail_rec.CLMHDR_DOC_DEPT);

            //objWork_file_rec.wf_doc_nbr = objClaim_header_rec.clmhdr_doc_nbr;
            objWork_file_rec.Wf_doc_nbr = Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).PadRight(8).Substring(2, 3);

            //objWork_file_rec.wf_pat_surname = objClaim_header_rec.clmhdr_pat_acronym6;
            objWork_file_rec.Wf_pat_surname = Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM6);

            //objWork_file_rec.wf_pat_acronym3 = objClaim_header_rec.clmhdr_pat_acronym3;
            objWork_file_rec.Wf_pat_acronym3 = Util.Str(objClaim_detail_rec.CLMHDR_PAT_ACRONYM3);

            // if clmhdr-pat-key-data = spaces or " " then;            
            //     objWork_file_rec.wf_pat_id_or_chart = "";
            // else;
            //         perform ja0-read-pat-mstr	thru	ja0-99-exit.;

            if (string.IsNullOrWhiteSpace(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA))
            {
                objWork_file_rec.Wf_pat_id_or_chart = string.Empty;
            }
            else
            {
                ja0_read_pat_mstr();
                ja0_99_exit();
            }

            //objWork_file_rec.wf_claim_date_sys = objClaim_header_rec.clmhdr_date_sys;
            objWork_file_rec.Wf_claim_date_sys = objClaim_detail_rec.CLMHDR_DATE_SYS;

            //objWork_file_rec.wf_diag_cd = objClaim_header_rec.clmhdr_diag_cd;
            objWork_file_rec.Wf_diag_cd = Util.NumInt(objClaim_detail_rec.CLMHDR_DIAG_CD);

            //objWork_file_rec.wf_orig_claim_id = objClaim_header_rec.clmhdr_batch_nbr;
            objWork_file_rec.Wf_orig_claim_id = objClaim_detail_rec.CLMHDR_BATCH_NBR;

            //objWork_file_rec.wf_orig_claim_nbr = objClaim_header_rec.clmhdr_claim_nbr;
            objWork_file_rec.Wf_orig_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_CLAIM_NBR);

            //objWork_file_rec.wf_ref_field = objClaim_header_rec.clmhdr_reference;
            objWork_file_rec.Wf_ref_field = objClaim_detail_rec.CLMHDR_REFERENCE;

            //objWork_file_rec.wf_adj_cd_sub_type = objClaim_header_rec.clmhdr_adj_cd_sub_type;
            objWork_file_rec.Wf_adj_cd_sub_type = objClaim_detail_rec.CLMHDR_ADJ_CD_SUB_TYPE;
        }

        private void ca0_99_exit()
        {
            //     exit.;
        }

        private void cb0_build_wf_rec_from_dtl()
        {

            objWork_file_rec.Wf_claim_batch_nbr = objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR;
            objWork_file_rec.Wf_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH);
            objWork_file_rec.Wf_claim_oma = Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OMA);
            objWork_file_rec.Wf_claim_ohip = Util.NumDec(objClaim_detail_rec.CLMDTL_FEE_OHIP);
            objWork_file_rec.Wf_service_date = Util.Str(objClaim_detail_rec.CLMDTL_SV_YY + Util.Str(objClaim_detail_rec.CLMDTL_SV_MM.ToString()).PadLeft(2, '0') + Util.Str(objClaim_detail_rec.CLMDTL_SV_DD.ToString()).PadLeft(2, '0'));
            objWork_file_rec.Wf_oma_cd = objClaim_detail_rec.CLMDTL_OMA_CD;
            objWork_file_rec.Wf_oma_suff = objClaim_detail_rec.CLMDTL_OMA_SUFF;

            //     add clmdtl-nbr-serv;
            // 	clmdtl-sv-nbr(1);
            // 	clmdtl-sv-nbr(2);
            // 	clmdtl-sv-nbr(3)		giving	wf-nbr-serv.;

            // objWork_file_rec.Wf_nbr_serv = Util.NumInt(objClaim_detail_rec.CLMDTL_NBR_SERV) + Util.NumInt(objClaim_detail_rec.CLMDTL_SV_NBR1) + Util.NumInt(objClaim_detail_rec.CLMDTL_SV_NBR2) + Util.NumInt(objClaim_detail_rec.CLMDTL_SV_NBR3);
            objWork_file_rec.Wf_nbr_serv = Util.NumInt(objClaim_detail_rec.CLMDTL_NBR_SERV) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 1)) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 2)) + Util.NumInt(CLMDTL_SV_NBR(objClaim_detail_rec, 3));

            //objWork_file_rec.wf_trans_cd = objClaim_detail_rec.clmdtl_adj_cd;
            objWork_file_rec.Wf_trans_cd = objClaim_detail_rec.CLMDTL_ADJ_CD;

            //objWork_file_rec.wf_agent_cd = objClaim_detail_rec.clmdtl_agent_cd;
            objWork_file_rec.Wf_agent_cd = Util.NumInt(objClaim_detail_rec.CLMDTL_AGENT_CD);

            //objWork_file_rec.wf_adj_cd = objClaim_detail_rec.clmdtl_adj_cd;
            objWork_file_rec.Wf_adj_cd = objClaim_detail_rec.CLMDTL_ADJ_CD;
        }

        private void cb0_99_exit()
        {
            //     exit.;
        }

        private void cd0_write_to_work_file()
        {
           
            //Util.Trakker(++ctr, "cd0_write_to_work_file");

            string tmpVal = Util.Str(objWork_file_rec.Wf_doc_nbr).PadRight(3, ' ');

            string tmpRecord = Util.Str(objWork_file_rec.Wf_dept.ToString()).PadLeft(2, '0') +
           Util.Str(objWork_file_rec.Wf_doc_nbr.ToString()).PadRight(3, ' ') +
           Util.Str(objWork_file_rec.Wf_pat_surname.ToString()).PadRight(6, ' ') +
           Util.Str(objWork_file_rec.Wf_pat_acronym3.ToString()).PadRight(3, ' ') +
           Util.Str(objWork_file_rec.Wf_claim_batch_nbr).PadRight(8) +
           Util.Str(objWork_file_rec.Wf_claim_nbr.ToString()).PadLeft(2, '0') +
           Util.Str(objWork_file_rec.Wf_pat_id_or_chart).PadRight(15, ' ') +
           Util.Str(objWork_file_rec.Wf_agent_cd.ToString()).PadLeft(1, '0') +
           Util.Str(objWork_file_rec.Wf_adj_cd).PadRight(1, ' ') +
           Util.Str(objWork_file_rec.Wf_payroll).PadRight(1, ' ') +
           Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.Wf_claim_oma), 8, true).PadLeft(7, '0') +                   // 05  wf-claim-oma				pic s9(5)v99.  ???
           Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.Wf_claim_ohip), 8, true).PadLeft(7, '0') +                  // 05  wf-claim-ohip				pic s9(5)v99. 
           Util.Str(objWork_file_rec.Wf_service_date).PadLeft(8, '0') +
           Util.Str(objWork_file_rec.Wf_claim_date_sys).PadLeft(8, '0') +
           Util.Str(objWork_file_rec.Wf_diag_cd.ToString()).PadLeft(3, '0') +
           Util.Str(objWork_file_rec.Wf_oma_cd).PadRight(4, ' ') +
           Util.Str(objWork_file_rec.Wf_oma_suff).PadRight(1, ' ') +
           Util.Str(objWork_file_rec.Wf_nbr_serv.ToString()).PadLeft(2, '0') +
           Util.Str(objWork_file_rec.Wf_orig_claim_id).PadRight(8) +
           Util.Str(objWork_file_rec.Wf_orig_claim_nbr.ToString()).PadLeft(2, '0') +
           Util.Str(objWork_file_rec.Wf_ref_field).PadRight(9, ' ').Substring(0, 9) +
           Util.Str(objWork_file_rec.Wf_trans_cd).PadRight(1, ' ') +
           Util.BlankWhenZero(Util.NumInt(Util.ConvertZone(Util.NumInt(objWork_file_rec.Wf_amt_tech_billed), 8, true)), 7) +            // 05  wf-amt-tech-billed			pic s9(5)v99. 
           Util.Str(objWork_file_rec.Wf_adj_cd_sub_type).PadRight(1, ' ');

            //     write work-file-rec.;
            objr004_work_file.AppendOutputFile(tmpRecord, true);

            //  add 1 to	ctr-work-file-writes.;
            ctr_work_file_writes++;
        }

        private void cd0_99_exit()
        {

            //     exit.;
        }

        private void da0_read_dtl_next_clm(bool isReadNext = false)
        {

            ContinueChecking:

            claims_occur = 0;
            feedback_claims_mstr = "0";

            // read claims-mstr next 	at end;            
            //       eof_claims_dtl = "Y";
            //       eof_claims_mstr = "Y";
            // 	     go to da0-99-exit.;

            // This is the same as r002a.

            if (!isReadNext)
            {
                NotReadsCtr++;
            }
            else
            {
                NotReadsCtr = 0;
            }


            if (isReadNext)
            {
                if (ctr_claims_mstr_reads >= Claim_detail_rec_Collection.Count() || Claim_detail_rec_Collection.Count() == 0)
                {
                    eof_claims_dtl = "Y";
                    eof_claims_mstr = "Y";
                    da0_99_exit();
                    return;
                }

                objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_mstr_reads];
                ctr_claims_mstr_reads++;
            }


            // if clmdtl-b-key-type not = "B" then;            
            //    eof_claims_dtl = "Y";
            //    eof_claims_mstr = "Y";
            // 	  go to da0-99-exit.;

            if (objClaim_detail_rec.KEY_CLM_TYPE.ToUpper() != "B")
            {
                eof_claims_dtl = "Y";
                eof_claims_mstr = "Y";
                da0_99_exit();
                return;
            }

            // if batctrl-batch-type     = "C" and clmdtl-adj-nbr     not = 0 then;            
            //    	go to da0-read-dtl-next-clm.;

            if (objBatctrl_rec.BATCTRL_BATCH_TYPE == "C" && objClaim_detail_rec.CLMDTL_ADJ_NBR != 0)
            {
                //da0_read_dtl_next_clm();
                isReadNext = true;
                goto ContinueChecking;
                return;
            }

            //  if clmdtl-oma-cd = "ZZZZ" then;
            //      eof_claims_dtl = "Y";
            //   	go to  da0-99-exit.;

            if (Util.Str(objClaim_detail_rec.CLMDTL_OMA_CD).ToUpper() == "ZZZZ")
            {
                eof_claims_dtl = "Y";
                da0_99_exit();
            }

            // if clmhdr-zeroed-area is numeric then;            
            // 	  if clmhdr-zeroed-area = zero then;            
            //       hold_clmhdr_batch_nbr = objClaim_header_rec.clmhdr_orig_batch_nbr;
            //       hold_clmhdr_claim_nbr = objClaim_header_rec.clmhdr_orig_claim_nbr;
            //       new_header = "Y";
            //       eof_claims_dtl = "Y";
            // 	     go to da0-10-check-clinic;
            // 	  else;
            // 	     next sentence;
            //   else;
            // 	next sentence.;

            if (Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) && Util.IsNumeric(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR))
            {
                //if (Util.NumInt (objClaim_detail_rec.CLMHDR_ADJ_OMA_CD) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF) == 0 && Util.NumInt(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR) == 0)  // Todo: This always be TRUE.  INDEXED].[F002_CLAIMS_MSTR_HDR] the values are 0.
                if (Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_CD).CompareTo("0") == 0 && Util.Str(objClaim_detail_rec.CLMHDR_ADJ_OMA_SUFF).CompareTo("0") == 0 && Util.Str(objClaim_detail_rec.CLMHDR_ADJ_ADJ_NBR).CompareTo("0") == 0)  // Todo: This always be TRUE.  INDEXED].[F002_CLAIMS_MSTR_HDR] the values are 0.
                {
                    hold_clmhdr_batch_nbr = objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR;
                    hold_clmhdr_claim_nbr = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR).PadLeft(2, '0').Substring(0, 2));
                    new_header = "Y";
                    eof_claims_dtl = "Y";
                    da0_10_check_clinic();
                    return;
                }
            }

            //  if clmdtl-orig-batch-nbr not = hold-clmhdr-batch-nbr or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr then;            
            //     new_header = "Y";
            //     eof_claims_dtl = "Y";		   


            // if (objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR != hold_clmhdr_batch_nbr || objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH != hold_clmhdr_claim_nbr)
            if (objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR != hold_clmhdr_batch_nbr || objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH != hold_clmhdr_claim_nbr)
            {
                new_header = "Y";
                eof_claims_dtl = "Y";
                hold_clmhdr_batch_nbr = objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR;   // added
                hold_clmhdr_claim_nbr = Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR).PadLeft(2, '0').Substring(0, 2)); // added                                                                                                                                         // hold_clmhdr_status_ohip = Util.Str(objClaim_detail_rec.CLMHDR_STATUS_OHIP);  // added                      
            }
        }

        private void da0_10_check_clinic()
        {

            // if batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2 then;            
            //    eof_claims_mstr = "Y";
            // 	  go to da0-99-exit.;

            if (Util.Str(objBatctrl_rec.BATCTRL_BATCH_NBR).Substring(0, 2) != Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).Substring(0, 2))
            {
                eof_claims_mstr = "Y";
                da0_99_exit();
                return;
            }
        }

        private void da0_99_exit()
        {
            //     exit.;
        }

        private void ga0_read_next_batch()
        {

            // read batch-ctrl-file next at end;            
            //      eof_batctrl_file = "Y";
            // 	    go to ga0-99-exit.;

            /* isRetrieving = false;
             Batctrl_rec_Collection = new F001_BATCH_CONTROL_FILE
             {
                 WhereBatctrl_clinic_nbr = Util.Str(sel_clinic_nbr)  // todo: 4 digits in table. verify this???
             }.Collection_UsingStart(ref isRetrieving, Batctrl_rec_Collection); */

            if (Batctrl_rec_Collection.Count() == 0)
            {
                objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                eof_batctrl_file = "Y";
                return;
            }
            else
            {
                if (ctr_batctrl_file_reads >= Batctrl_rec_Collection.Count())
                {
                    objBatctrl_rec = new F001_BATCH_CONTROL_FILE();
                    eof_batctrl_file = "Y";
                    return;
                }
                else
                {
                    //if (isRetrieving) ctr_batctrl_file_reads = 0;
                    objBatctrl_rec = Batctrl_rec_Collection[ctr_batctrl_file_reads];

                    //     add 1				to ctr-batctrl-file-reads.;
                    ctr_batctrl_file_reads++;
                }
            }

            flag_rec = "N";

            //  perform aa1-sel-read-next-batctrl	thru aa1-99-exit;
            // 	until   eof-batctrl-file = "Y";
            // 	     or valid-rec.;

            do
            {
                aa1_sel_read_next_batctrl();
                aa1_99_exit();
            } while (!eof_batctrl_file.ToUpper().Equals("Y") && !flag_rec.ToUpper().Equals(valid_rec));

            //  if eof-batctrl-file = 'Y'  then;            
            //   	go to ga0-99-exit.;

            if (eof_batctrl_file.ToUpper().Equals("Y"))
            {
                ga0_99_exit();
                return;
            }

            // if  clmhdr-orig-batch-nbr  not = batctrl-batch-nbr or clmhdr-date-period-end not = batctrl-date-period-end  then;            
            // 	perform aa11-read-claim		thru	aa11-99-exit.;

            if (objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR != objBatctrl_rec.BATCTRL_BATCH_NBR || objClaim_detail_rec.CLMHDR_DATE_PERIOD_END != Util.NumDec(objBatctrl_rec.BATCTRL_DATE_PERIOD_END))
            {
                aa11_read_claim();
                aa11_99_exit();
            }
        }

        private void ga0_99_exit()
        {

            //     exit.;
        }

        private void ha0_read_clmhdr_next()
        {

            //objClaims_mstr_dtl_rec.clmdtl_b_data = 0;
            objClaim_detail_rec.CLMDTL_BATCH_NBR = "0";
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = 0;
            objClaim_detail_rec.CLMDTL_OMA_CD = "0";
            objClaim_detail_rec.CLMDTL_OMA_SUFF = "0";
            objClaim_detail_rec.CLMDTL_ADJ_NBR = 0;

            claims_occur = 0;
            feedback_claims_mstr = "0";

            // if clmdtl-orig-batch-id = spaces then;            
            //     objClaim_detail_rec.clmdtl_orig_batch_nbr = objClaim_detail_rec.clmdtl_batch_nbr;
            //     objClaim_detail_rec.clmdtl_orig_claim_nbr_in_batch = objClaim_detail_rec.clmdtl_claim_nbr;

            if (string.IsNullOrWhiteSpace(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) && string.IsNullOrWhiteSpace(Util.Str(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH)))
            {
                objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR = objClaim_detail_rec.CLMDTL_BATCH_NBR;
                objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = objClaim_detail_rec.CLMDTL_CLAIM_NBR;
            }

            // if  clmdtl-orig-claim-nbr-in-batch = 99 then;            
            //     objClaim_detail_rec.clmdtl_orig_claim_nbr_in_batch = 0;
            //     perform xx0-increment-batch-nbr thru    xx0-99-exit;
            // else;
            //         add 1                           to	clmdtl-orig-claim-nbr-in-batch.;

            if (Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH) == 99)
            {
                objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = 0;
                //  perform xx0-increment-batch-nbr thru    xx0-99-exit;
                xx0_increment_batch_nbr();
                xx0_99_exit();
            }
            else
            {
                //clmdtl_orig_claim_nbr_in_batch++;
                objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH++;
            }


            //move clmdtl-orig - batch - nbr     to clmdtl-b - batch - nbr.       // todo...???
            //move clmdtl - orig - claim - nbr -in-batch to clmdtl-b - claim - nbr.

            objClaim_detail_rec.CLMDTL_BATCH_NBR = objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR;
            objClaim_detail_rec.CLMDTL_CLAIM_NBR = objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH;

            //  start claims-mstr key is greater than or equal to key-claims-mstr.;
            //     read claims-mstr next;
            //       at end;
            //    eof_claims_mstr = "Y";
            // 	go to ha0-99-exit.;

            /* objClaim_header_rec = new F002_CLAIMS_MSTR_HDR
             {
                 //WhereKey_clm_type = "B", // todo
                 //WhereClmhdr_batch_nbr = objClaim_detail_rec.CLMDTL_BATCH_NBR,
                 //WhereClmhdr_claim_nbr = objClaim_detail_rec.CLMDTL_CLAIM_NBR,
                 //WhereClmhdr_adj_oma_cd = objClaim_detail_rec.CLMDTL_OMA_CD,
                 //WhereClmhdr_adj_oma_suff = objClaim_detail_rec.CLMDTL_OMA_SUFF,
                 //WhereClmhdr_adj_adj_nbr = objClaim_header_rec.CLMHDR_ADJ_ADJ_NBR
             }.Collection_ReadNext(objClaim_header_rec); */

            ctr_claims_mstr_reads = 0;

            Claim_detail_rec_Collection = new F002_CLAIMS_MSTR_DTL
            {
                WhereKey_clm_type = objClaim_detail_rec.KEY_CLM_TYPE,
                WhereKey_clm_batch_nbr = objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR,   // Check the where clause....? 
                WhereKey_clm_claim_nbr = objClaim_detail_rec.CLMDTL_ORIG_CLAIM_NBR_IN_BATCH
            }.Collection_HDR_DTL_INNERJOIN_UsingTop(20000, false, objConn);

            //if (objClaim_header_rec == null)
            if (Claim_detail_rec_Collection.Count() == 0)
            {
                eof_claims_mstr = "Y";
                ha0_99_exit();
                return;
            }

            objClaim_detail_rec = Claim_detail_rec_Collection[ctr_claims_mstr_reads];
            ctr_claims_mstr_reads++;

            // if clmdtl-b-key-type      not = "B" or clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr then;            
            //     eof_claims_mstr = "Y";
            // 	   go to ha0-99-exit.;

            if (!objClaim_detail_rec.KEY_CLM_TYPE.ToUpper().Equals("B") || Util.NumInt(Util.Str(objClaim_detail_rec.CLMHDR_BATCH_NBR).Substring(0, 2)) != sel_clinic_nbr)
            {
                eof_claims_mstr = "Y";
                ha0_99_exit();
                return;
            }

            hold_clmhdr_batch_nbr = objClaim_detail_rec.CLMHDR_ORIG_BATCH_NBR;
            hold_clmhdr_claim_nbr = Util.NumInt(objClaim_detail_rec.CLMHDR_ORIG_CLAIM_NBR);
        }

        private void ha0_99_exit()
        {
            //     exit.;
        }

        private void xx0_increment_batch_nbr()
        {

            flag_request_complete = "N";

            // if clmdtl-orig-batch-number = 999 then;            
            //      tmp_doc_nbr_alpha = objClaim_detail_rec.clmdtl_orig_doc_number;
            //      display "BEFORE: " clmdtl-orig-doc-number;
            //      perform xx1-process-1-doc-position  thru xx1-99-exit;
            //            varying   ss from 3 by -1;
            //             until     ss = 0;
            //                or      flag-request-complete-y;

            //       objClaim_detail_rec.clmdtl_orig_doc_number = tmp_doc_nbr_alpha;
            //        display "AFTER : " clmdtl-orig-doc-number;
            //        display " ";
            //       objClaim_detail_rec.clmdtl_orig_batch_number = 000;
            // else;
            //         add 1                           to       clmdtl-orig-batch-number.;

            if (Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) == 999)
            {
                this.tmp_doc_nbr_alpha_grp = Util.Str(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR).Substring(2, 3); //  clmdtl_orig_doc_number;  verify this ???
                char[] temp = tmp_doc_nbr_alpha_grp.ToCharArray();

                for (var i = 0; i < temp.Length; i++)
                {
                    tmp_batch_nbr_index[i] = Util.Str(temp[i]);
                }
                Console.WriteLine("BEFORE: " + Util.Str(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR).Substring(2, 3));

                ss = 3;
                do
                {
                    xx1_process_1_doc_position();
                    xx1_90_return();
                    xx1_99_exit();
                    ss--;
                } while (ss > 0 && !flag_request_complete.ToUpper().Equals(flag_request_complete_y));

                //       objClaim_detail_rec.clmdtl_orig_doc_number = tmp_doc_nbr_alpha;
                //        display "AFTER : " clmdtl-orig-doc-number;
                //        display " ";
                //       objClaim_detail_rec.clmdtl_orig_batch_number = 000;
            }
            else
            {
                //         add 1                           to       clmdtl-orig-batch-number.;
                objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR = Util.Str(Util.NumInt(objClaim_detail_rec.CLMDTL_ORIG_BATCH_NBR) + 1);
            }
        }

        private void xx0_99_exit()
        {

            //    exit.;
        }

        private void xx1_process_1_doc_position()
        {

            if (tmp_batch_nbr_index[ss] == "0")
            {
                tmp_batch_nbr_index[ss] = "1";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "1")
            {
                tmp_batch_nbr_index[ss] = "2";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "2")
            {
                tmp_batch_nbr_index[ss] = "3";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "3")
            {
                tmp_batch_nbr_index[ss] = "4";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "4")
            {
                tmp_batch_nbr_index[ss] = "5";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "5")
            {
                tmp_batch_nbr_index[ss] = "6";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "6")
            {
                tmp_batch_nbr_index[ss] = "7";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "7")
            {
                tmp_batch_nbr_index[ss] = "8";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "8")
            {
                tmp_batch_nbr_index[ss] = "9";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "9")
            {
                tmp_batch_nbr_index[ss] = "A";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "A")
            {
                tmp_batch_nbr_index[ss] = "B";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "B")
            {
                tmp_batch_nbr_index[ss] = "C";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "C")
            {
                tmp_batch_nbr_index[ss] = "D";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "D")
            {
                tmp_batch_nbr_index[ss] = "E";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "E")
            {
                tmp_batch_nbr_index[ss] = "F";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "F")
            {
                tmp_batch_nbr_index[ss] = "G";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "G")
            {
                tmp_batch_nbr_index[ss] = "H";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "H")
            {
                tmp_batch_nbr_index[ss] = "I";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "I")
            {
                tmp_batch_nbr_index[ss] = "J";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "J")
            {
                tmp_batch_nbr_index[ss] = "K";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "K")
            {
                tmp_batch_nbr_index[ss] = "L";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "L")
            {
                tmp_batch_nbr_index[ss] = "M";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "M")
            {
                tmp_batch_nbr_index[ss] = "N";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "N")
            {
                tmp_batch_nbr_index[ss] = "O";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "O")
            {
                tmp_batch_nbr_index[ss] = "P";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "P")
            {
                tmp_batch_nbr_index[ss] = "Q";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Q")
            {
                tmp_batch_nbr_index[ss] = "R";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "R")
            {
                tmp_batch_nbr_index[ss] = "S";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "S")
            {
                tmp_batch_nbr_index[ss] = "T";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "T")
            {
                tmp_batch_nbr_index[ss] = "U";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "U")
            {
                tmp_batch_nbr_index[ss] = "V";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "V")
            {
                tmp_batch_nbr_index[ss] = "W";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "W")
            {
                tmp_batch_nbr_index[ss] = "X";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "X")
            {
                tmp_batch_nbr_index[ss] = "Y";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Y")
            {
                tmp_batch_nbr_index[ss] = "Z";
                xx1_90_return();
                return;
            }
            else if (tmp_batch_nbr_index[ss] == "Z")
            {
                tmp_batch_nbr_index[ss] = "0";
                xx1_90_return();
                return;
            }
        }

        private void xx1_90_return()
        {

            flag_request_complete = "Y";
        }

        private void xx1_99_exit()
        {

            //     exit.;
        }

        private void ja0_read_pat_mstr()
        {
            //objPat_mstr_rec.key_pat_mstr = objClaim_header_rec.clmhdr_pat_ohip_id_or_chart;

            //objPat_mstr_rec.  Key_pat_mstr = Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_TYPE) + Util.Str(objClaim_header_rec.CLMHDR_PAT_KEY_DATA);

            //     read pat-mstr;
            //          invalid key;
            //pat_ohip_mmyy_r = "*** UNKNOWN ***";

            Pat_mstr_rec_Collection = new F010_PAT_MSTR
            {
                WherePat_i_key = Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_TYPE),
                WherePat_con_nbr = Util.NumDec(Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA).PadRight(2).Substring(0, 2)),
                WherePat_i_nbr = Util.NumDec(Util.Str(objClaim_detail_rec.CLMHDR_PAT_KEY_DATA).PadRight(14).Substring(2))
            }.Collection(Pat_mstr_rec_Collection);

            //     add 1				to ctr-pat-mstr-reads.;

            ctr_pat_mstr_reads++;

            objPat_mstr_rec = Pat_mstr_rec_Collection.FirstOrDefault();

            if (objPat_mstr_rec != null)
            {
                // if pat-health-nbr not = 0 then;            
                //      objWork_file_rec.wf_pat_id_or_chart = objPat_mstr_rec.pat_health_nbr;
                // else if pat-ohip-mmyy-r not = spaces then;            
                //     objWork_file_rec.wf_pat_id_or_chart = objPat_mstr_rec.pat_ohip_mmyy_r;
                // else;
                //     objWork_file_rec.wf_pat_id_or_chart = objPat_mstr_rec.pat_chart_nbr;

                if (Util.NumLongInt(objPat_mstr_rec.PAT_HEALTH_NBR) != 0)
                {
                    objWork_file_rec.Wf_pat_id_or_chart = Util.Str(objPat_mstr_rec.PAT_HEALTH_NBR);
                }
                else if (!string.IsNullOrWhiteSpace(objPat_mstr_rec.PAT_DIRECT_ALPHA) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_YY.ToString())) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_MM.ToString())) && !string.IsNullOrWhiteSpace(Util.Str(objPat_mstr_rec.PAT_DIRECT_DD.ToString())))
                {
                    objWork_file_rec.Wf_pat_id_or_chart = objPat_mstr_rec.PAT_DIRECT_ALPHA + Util.Str(objPat_mstr_rec.PAT_DIRECT_YY.ToString()).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_MM.ToString()).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_DD.ToString()).PadLeft(2, '0') + Util.Str(objPat_mstr_rec.PAT_DIRECT_LAST_6); 
                }
                else
                {
                    objWork_file_rec.Wf_pat_id_or_chart = objPat_mstr_rec.PAT_CHART_NBR;
                }

            }
        }

        private void ja0_99_exit()
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
        }

        // y2k_default_sysdate_century.rtn
        private void y2k_default_sysdate_exit()
        {
            //     exit.;
        }

        #endregion
    }
}

