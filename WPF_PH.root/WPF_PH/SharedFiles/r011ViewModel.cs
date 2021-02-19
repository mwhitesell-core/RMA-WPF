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
    public class R011ViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private Prt_line objPrt_line = null;
        private ObservableCollection<Prt_line> Prt_line_Collection;

        // FD: docrev_mstr	Copy : f050_doc_revenue_mstr.fd
        private F050_DOC_REVENUE_MSTR objDocrev_master_rec = null;
        private ObservableCollection<F050_DOC_REVENUE_MSTR> Docrev_master_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_4.ws
        private CONSTANTS_MSTR_REC_4 objConstants_mstr_rec_4 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_4> Constants_mstr_rec_4_Collection;

        // FD: iconst_mstr	Copy : r011_sort_docrev_file.sd
        private Sort_docrev_rec objSort_docrev_rec = null;
        private ObservableCollection<Sort_docrev_rec> Sort_docrev_rec_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind;
        private string printer_file_name = "r011";
        private string option;
        private string display_key_type;
        private string feedback_docrev_mstr;
        private string feedback_iconst_mstr;
        private int line_cnt = 57;
        private int page_cnt = 0;
        private int max_nbr_lines = 57;
        private string const_mstr_rec_nbr;
        private string ws_reply;
        private string ws_hold_curr_class_code;
        private string ws_doc_class_code;
        private string ws_doc_name_inits = "";
        private int subs;
        private int subs1;
        private int subs_dept = 1;
        private int subs_clinic = 2;
        private int subs_present_nbr_classes;
        private int subs_class_total;
        private int subs_class_code;
        private int subs_max_nbr_classes;
        private int subs_dept_clinic;
        private int ss_table_addr;
        private int ss_to;
        private int level;
        private int ss_from;
        private string eof_subscr_mstr = "N";
        private string status_file;
        private string status_cobol_subscr_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_docrev_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_prt_file = "0";

        private string totals_grp;
        private int total_svc;
        private decimal total_rec;
        private int total_mtd_svc;
        private decimal total_mtd_rec;
        private int total_ytd_svc;
        private decimal total_ytd_rec;

        private string file_access_counters_grp;
        private int docrev_read = 0;
        private int doc_mstr_read = 0;
        private string request_clinic;
        private string ws_request_clinic_ident;
        private string blank_line = "";

        private string save_area_grp;
        private int save_clinic_1_2;
        private int save_dept;
        private string save_doc_nbr;
        private string save_location;
        private string save_oma;
        private string save_class_code;
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_ohip_vs_chart;
        private string ohip = "O";
        private string chart = "C";
        private string flag_valid_ohip_or_chart;
        private string valid_ohip = "Y";
        private string valid_chart = "Y";
        private string invalid_ohip = "N";
        private string invalid_chart = "N";
        private string flag_ohip_mmyy;
        private string valid_mmyy = "Y";
        private string invalid_mmyy = "N";

        private string subscripts_for_table_grp;
        private int ss_oma_code = 1;
        private int ss_loc = 2;
        private int ss_doc = 3;
        private int ss_dept = 4;
        private int ss_grand = 5;
        private int ss_max_nbr_subscripts = 5;

        private string total_counters_grp;
        private string[] line_totals = new string[6];
        private decimal[] mtd_in_rec = new decimal[6];
        private int[] mtd_in_svc = new int[6];
        private decimal[] mtd_out_rec = new decimal[6];
        private int[] mtd_out_svc = new int[6];
        private decimal[] mtd_misc_rec = new decimal[6];
        private int[] mtd_misc_svc = new int[6];
        private decimal[] ytd_in_rec = new decimal[6];
        private int[] ytd_in_svc = new int[6];
        private decimal[] ytd_out_rec = new decimal[6];
        private int[] ytd_out_svc = new int[6];
        private decimal[] ytd_misc_rec = new decimal[6];
        private int[] ytd_misc_svc = new int[6];

        private string ws_class_codes_grp;
        private string[] ws_total_by_dept_clinic = new string[3];
        private string[,] ws_max_class_codes = new string[3, 17];
        private string[,] ws_class_code = new string[3, 17];
        private string[,] ws_class_code_desc = new string[3, 17];
        private decimal[,] ws_mtd_in_rec = new decimal[3, 17];
        private int[,] ws_mtd_in_svc = new int[3, 17];
        private decimal[,] ws_mtd_out_rec = new decimal[3, 17];
        private int[,] ws_mtd_out_svc = new int[3, 17];
        private decimal[,] ws_mtd_misc_rec = new decimal[3, 17];
        private int[,] ws_mtd_misc_svc = new int[3, 17];
        private decimal[,] ws_ytd_in_rec = new decimal[3, 17];
        private int[,] ws_ytd_in_svc = new int[3, 17];
        private decimal[,] ws_ytd_out_rec = new decimal[3, 17];
        private int[,] ws_ytd_out_svc = new int[3, 17];
        private decimal[,] ws_ytd_misc_rec = new decimal[3, 17];
        private int[,] ws_ytd_misc_svc = new int[3, 17];
        private string ws_xx = " ";

        //private string head_line_1_grp;
        //private string filler = "r011  /";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = "P.E.D.";
        private int h1_ped_yy;
        //private string filler = "/";
        private int h1_ped_mm;
        //private string filler = "/";
        private int h1_ped_dd;
        //private string filler = "";
        //private string filler = "* DEPARTMENT REVENUE ANALYSIS BY CLASS BY DOCTOR *";
        //private string filler = "run date:";
        private int h1_year;
        //private string filler = "/";
        private int h1_month;
        //private string filler = "/";
        private int h1_day;
        //private string filler = "";
        //private string filler = "page ";
        private int h1_page;

        //private string head_line_2_grp;
        //private string filler = "";
        private string h2_clinic;
        private string filler = "";

        //private string head_line_3_grp;
        //private string filler = "";
        //private string filler = "dept #";
        private int h3_dept;
        //private string filler = " - ";
        private string h3_dept_name;

        //private string head_line_4_grp;
        //private string filler = "";
        //private string filler = "CLASS";
        private string h4_class_code;
        //private string filler = "-";
        private string h4_class_code_desc;

        //private string head_line_5_grp;
        //private string filler = "";
        //private string filler = "# svc___in-patient";
        //private string filler = "# svc__out-patient";
        //private string filler = "# svc__miscellaneous";
        //private string filler = "# svc__total-amount";

        //private string head_line_6_grp;
        private string h6_dept_clinic_tot;

        //private string detail_line_1_grp;
        private string d1_nbr_name_grp;
        private string d1_nbr_lit;
        private string d1_doc_nbr;
        //private string filler;
        private string d1_mth_yr;
        private int d1_mtd_in_svc;
        //private string filler = "";
        private decimal d1_mtd_in_rec;
        //private string filler = "";
        private int d1_mtd_out_svc;
        //private string filler = "";
        private decimal d1_mtd_out_rec;
        //private string filler = "";
        private int d1_mtd_misc_svc;
        //private string filler = "";
        private decimal d1_mtd_misc_rec;
        //private string filler = "";
        private int d1_mtd_tot_svc;
        //private string filler = "";
        private decimal d1_mtd_tot_rec;

        //private string total_line_1_grp;
        private string t1_dept_clinic_grp;
        private string t1_class;
        private string t1_col_dash_lit;
        private string t1_class_lit;
        private string t1_dept_clinic_r_grp;
        //private string filler;
        private string t1_col_lit;
        private string t1_class_code_desc;
        private string t1_mth_yr;
        private int t1_mtd_in_svc;
        //private string filler = "";
        private decimal t1_mtd_in_rec;
        //private string filler = "";
        private int t1_mtd_out_svc;
        //private string filler = "";
        private decimal t1_mtd_out_rec;
        //private string filler = "";
        private int t1_mtd_misc_svc;
        //private string filler = "";
        private decimal t1_mtd_misc_rec;
        //private string filler = "";
        private int t1_mtd_tot_svc;
        //private string filler = "";
        private decimal t1_mtd_tot_rec;

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "INVALID CLINIC NUMBER";
        private string filler = "CONSTANTS MASTER READ ERROR";
        private string filler = "NO DOCTOR REVENUE RECORDS FOR GIVEN CLINIC";
        private string filler = "DEPARTMENT MASTER READ ERROR";
        private string filler = "HEADINGS ONLY PRINTED ON DOC-DEPT-TOTAL BREAK";
        private string filler = "TOO MANY CLASS CODES FOUND"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "INVALID CLINIC NUMBER", "CONSTANTS MASTER READ ERROR", "NO DOCTOR REVENUE RECORDS FOR GIVEN CLINIC", "DEPARTMENT MASTER READ ERROR", "HEADINGS ONLY PRINTED ON DOC-DEPT-TOTAL BREAK", "TOO MANY CLASS CODES FOUND" };
        private string err_msg_comment;
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

        private string prm_ws_request_clinic_ident;
        private string prm_ws_reply;

        private string endOfJob = "End of Job";

        private ReportPrint objPrint_File = null;

        private int sort_ctr = 0;
        private string doc_nbr;
        private string high_values = "FF";
        private int debug_ctr;
        private int ctr;       

        #endregion

        #region Screen Section

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

            //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
            status_file = status_cobol_iconst_mstr;
            //     display status-file.;
            //     stop run.;
        }

        private void err_docrev_mstr_file_section()
        {

            //     use after standard error procedure on docrev-mstr.;
        }

        private void err_docrev_mstr()
        {

            //     stop "ERROR IN ACCESSING DOCREV MASTER ".;
            status_file = status_cobol_docrev_mstr;
            //     display status-file.;
            //     stop run.;
        }

        private void err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private void err_doc_mstr()
        {

            //     stop "ERROR IN ACCESSING DOC MASTER ".;
            status_file = status_cobol_doc_mstr;
            //     display status-file.;
            //     stop run.;
        }

        private void err_dept_mstr_file_section()
        {

            //     use after standard error procedure on dept-mstr.;
        }

        private void err_dept_mstr()
        {

            //     stop "ERROR IN ACCESSING DEPT MASTER ".;
            status_file = status_cobol_dept_mstr;
            //     display status-file.;
            //     stop run.;
        }

        private void end_declaratives()
        {

        }

        public void mainline_section(string ws_request_clinic_ident, string ws_reply)
        {            
            try
            {
                prm_ws_request_clinic_ident = ws_request_clinic_ident;
                prm_ws_reply = ws_reply;

                objPrt_line = null;
                objPrt_line = new Prt_line();

                Prt_line_Collection = null;
                Prt_line_Collection = new ObservableCollection<Prt_line>();

                objDocrev_master_rec = null;
                objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();

                Docrev_master_rec_Collection = null;
                Docrev_master_rec_Collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();

                objDoc_mstr_rec = null;
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();

                Doc_mstr_rec_Collection = null;
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objDept_mstr_rec = null;
                objDept_mstr_rec = new F070_DEPT_MSTR();

                Dept_mstr_rec_Collection = null;
                Dept_mstr_rec_Collection = new ObservableCollection<F070_DEPT_MSTR>();

                objIconst_mstr_rec = null;
                objIconst_mstr_rec = new ICONST_MSTR_REC();

                Iconst_mstr_rec_Collection = null;
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objConstants_mstr_rec_4 = null;
                objConstants_mstr_rec_4 = new CONSTANTS_MSTR_REC_4();

                Constants_mstr_rec_4_Collection = null;
                Constants_mstr_rec_4_Collection = new ObservableCollection<CONSTANTS_MSTR_REC_4>();

                objSort_docrev_rec = null;
                objSort_docrev_rec = new Sort_docrev_rec();

                Sort_docrev_rec_Collection = null;
                Sort_docrev_rec_Collection = new ObservableCollection<Sort_docrev_rec>();

                objPrint_File = null;
                objPrint_File = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + printer_file_name);


                // perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_10();
                aa0_99_exit();

                // sort sort-docrev-file;
                // 	 on ascending key;
                // 			wk-docrev-clinic-1-2;
                // 			wk-docrev-dept;
                // 			wk-docrev-class-code;
                // 			wk-docrev-doc-nbr;
                // 	input procedure is ab0-create-sort-file	thru ab0-99-exit;
                // 	output procedure is ba0-process-records	thru ba0-99-exit.;

                ab0_10_open_files();
                ab0_20_read_docrev();
                ab0_99_exit();

                ObservableCollection<Sort_docrev_rec> tmp_Sort_docrev_rec_Collection = null;
                tmp_Sort_docrev_rec_Collection = new ObservableCollection<Sort_docrev_rec>();

                foreach (var obj in Sort_docrev_rec_Collection.OrderBy(a => a.Wk_docrev_clinic_1_2).ThenBy(b => b.Wk_docrev_dept).ThenBy(c => c.wk_docrev_class_code).ThenBy(d => d.Wk_docrev_doc_nbr))
                {
                    tmp_Sort_docrev_rec_Collection.Add(obj);
                }
                Sort_docrev_rec_Collection.Clear();
                foreach (var obj in tmp_Sort_docrev_rec_Collection)
                {
                    Sort_docrev_rec_Collection.Add(obj);
                }
                tmp_Sort_docrev_rec_Collection.Clear();
                
                objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                sort_ctr++;

                if (objSort_docrev_rec != null)
                {
                    ba0_process_records();
                    ba0_10_process_records();
                    ba0_99_exit();

                    az0_finalization();
                    az0_99_exit();
                }              

                // perform az0-finalization			thru az0-99-exit.;
                // az0_finalization();
                // az0_99_exit();

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
                if (objPrint_File != null) objPrint_File.Close();
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

            run_mm = sys_mm;
            h1_month = sys_mm;

            run_dd = sys_dd;
            h1_day = sys_dd;

            run_yy = sys_yy;
            h1_year = sys_yy;

        }

        private void aa0_10()
        {            

            //     accept ws-request-clinic-ident;
            ws_request_clinic_ident = prm_ws_request_clinic_ident;

            // if ws-request-clinic-ident = "**" then;            
            //    	accept sys-time   from time;
            //         stop run.;

            if (ws_request_clinic_ident == "**")
            {
                throw new Exception(endOfJob);
            }

            //     open input   iconst-mstr.;

            // objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_request_clinic_ident;

            //  read iconst-mstr;
            //     	invalid key;
            //       err_ind = 2;
            // 		perform za0-common-error	thru za0-99-exit;
            //        		go to aa0-10.;

            Iconst_mstr_rec_Collection = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = Util.NumDec(ws_request_clinic_ident)
            }.Collection();

            if (Iconst_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 2;
                za0_common_error();
                za0_99_exit();
                throw new Exception(endOfJob);
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(ws_request_clinic_ident);

            h1_ped_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);

            h1_ped_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h1_ped_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NAME);

            //     accept ws-reply;
            ws_reply = prm_ws_reply;

            //  if ws-reply not = "Y" then;            
            //          close iconst-mstr;
            //          accept sys-time	from time;
            //          stop run;
            //  else;
            //      objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 4;

            if (ws_reply.ToUpper() != "Y")
            {
                throw new Exception(endOfJob);
            }
            else
            {
                objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 4;
            }

            //  read iconst-mstr;
            // 	invalid key;
            //         err_ind = 2;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-finalization.;

            Constants_mstr_rec_4_Collection = new CONSTANTS_MSTR_REC_4
            {
                //WhereIconst_clinic_nbr_1_2 = 4
                WhereConst_rec_nbr = 4
            }.Collection();

            if (Constants_mstr_rec_4_Collection.Count() == 0)
            {
                err_ind = 2;
                za0_common_error();
                za0_99_exit();
                //az0_finalization(); 
                // return;
                throw new Exception(endOfJob);
            }
            else
            {
                objConstants_mstr_rec_4 = Constants_mstr_rec_4_Collection.FirstOrDefault();
            }

            //  open input  docrev-mstr;
            // 		        dept-mstr;
            //              doc-mstr.;

            //  open output  print-file.;

            subs_dept_clinic = 1;

            //  perform xg0-clear-class-tbl		thru	xg0-99-exit;
            // 	   varying subs from 1 by 1;
            // 	   until subs > const-nbr-classes + 1.;

            subs = 1;

            do
            {
                xg0_clear_class_tbl();
                xg0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1);


            subs_dept_clinic = 2;

            //     perform xg0-clear-class-tbl		thru	xg0-99-exit;
            // 	varying subs from 1 by 1;
            // 	until subs > const-nbr-classes + 1.;

            subs = 1;

            do
            {
                xg0_clear_class_tbl();
                xg0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1);

            subs_dept_clinic = 1;
            subs_class_code = 1;
            subs_max_nbr_classes = 1;

            //     perform aa1-zero-counters			thru aa1-99-exit;
            // 	varying ss-from;
            // 	from    1 by 1;
            // 	until   ss-from > ss-max-nbr-subscripts.;

            ss_from = 1;
            do
            {
                aa1_zero_counters();
                aa1_99_exit();
                ss_from++;
            } while (ss_from <= ss_max_nbr_subscripts);

            level = ss_doc;
        }

        private void aa0_99_exit()
        {            
            //     exit.;
        }

        private void aa1_zero_counters()
        {            

            mtd_in_rec[ss_from] = 0;
            mtd_in_svc[ss_from] = 0;
            mtd_out_rec[ss_from] = 0;
            mtd_out_svc[ss_from] = 0;
            mtd_misc_rec[ss_from] = 0;
            mtd_misc_svc[ss_from] = 0;
            ytd_in_rec[ss_from] = 0;
            ytd_in_svc[ss_from] = 0;
            ytd_out_rec[ss_from] = 0;
            ytd_out_svc[ss_from] = 0;
            ytd_misc_rec[ss_from] = 0;
            ytd_misc_svc[ss_from] = 0;
        }

        private void aa1_99_exit()
        {            
            //     exit.;
        }

        private void ab0_create_sort_file_section()
        {            
        }

        private void ab0_10_open_files()
        {            

            //objDocrev_master_rec.docrev_key = 0;

            objDocrev_master_rec.DOCREV_CLINIC_1_2 = "";   // Todo: This keys are not the save as in dictionary. Verify.....??? 
            objDocrev_master_rec.DOCREV_DEPT = 0;
            objDocrev_master_rec.DOCREV_DOC_NBR = "";
            objDocrev_master_rec.DOCREV_LOCATION = "";
            objDocrev_master_rec.DOCREV_OMA_CODE = "";
            // objDocrev_master_rec.DOCREV_OMA_SUFF = "";            

            subs = 0;

            objDocrev_master_rec.DOCREV_CLINIC_1_2 = ws_request_clinic_ident;

            //     perform ra1-read-docrev-approx	thru	ra1-99-exit.;
            ra1_read_docrev_approx();
            ra1_99_exit();
        }

        private void ab0_20_read_docrev()
        {            

            // if docrev-clinic-1-2 = high-values then;            
            //         go to ab0-99-exit.;

            while (docrev_read <= Docrev_master_rec_Collection.Count())  
            {               
                if (objDocrev_master_rec.DOCREV_CLINIC_1_2 == high_values )                
                {
                    ab0_99_exit();
                    return;
                }

                objSort_docrev_rec = null;
                objSort_docrev_rec = new Sort_docrev_rec();

                //objSort_docrev_rec.Wk_docrev_key  = objDocrev_master_rec.docrev_key;
                objSort_docrev_rec.Wk_docrev_clinic_1_2 = objDocrev_master_rec.DOCREV_CLINIC_1_2;
                objSort_docrev_rec.Wk_docrev_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);
                objSort_docrev_rec.Wk_docrev_doc_nbr = objDocrev_master_rec.DOCREV_DOC_NBR;
                objSort_docrev_rec.Wk_docrev_location = objDocrev_master_rec.DOCREV_LOCATION;
                objSort_docrev_rec.Wk_docrev_oma_cd = objDocrev_master_rec.DOCREV_OMA_CODE;
                objSort_docrev_rec.Wk_docrev_oma_suff = objDocrev_master_rec.DOCREV_OMA_SUFF;

                //objSort_docrev_rec.Wk_docrev_month_to_date = objDocrev_master_rec.docrev_month_to_date;
                objSort_docrev_rec.Wk_docrev_month_to_date = Util.Str(objDocrev_master_rec.DOCREV_MTD_IN_REC) + Util.Str(objDocrev_master_rec.DOCREV_MTD_IN_SVC) + Util.Str(objDocrev_master_rec.DOCREV_MTD_OUT_REC) + Util.Str(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);

                objSort_docrev_rec.Wk_docrev_mtd_in_rec = Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC);
                objSort_docrev_rec.Wk_docrev_mtd_in_svc = Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC);
                objSort_docrev_rec.Wk_docrev_mtd_out_rec = Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC);
                objSort_docrev_rec.Wk_docrev_mtd_out_svc = Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);



                //objSort_docrev_rec.Wk_docrev_year_to_date = objDocrev_master_rec.docrev_year_to_date;
                objSort_docrev_rec.Wk_docrev_year_to_date = Util.Str(objDocrev_master_rec.DOCREV_YTD_IN_REC) + Util.Str(objDocrev_master_rec.DOCREV_YTD_IN_SVC) + Util.Str(objDocrev_master_rec.DOCREV_YTD_OUT_REC) + Util.Str(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);

                objSort_docrev_rec.Wk_docrev_ytd_in_rec = Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC);
                objSort_docrev_rec.Wk_docrev_ytd_in_svc = Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC);
                objSort_docrev_rec.Wk_docrev_ytd_out_rec = Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC);
                objSort_docrev_rec.Wk_docrev_ytd_out_svc = Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);

                //  perform ca0-doc-class-code		thru	ca0-99-exit.;
                ca0_doc_class_code();
                ca0_99_exit();               

                //  release sort-docrev-rec.;
                Sort_docrev_rec_Collection.Add(objSort_docrev_rec);

                //  perform ra0-read-next-docrev	thru 	ra0-99-exit.;
                ra0_read_next_docrev();
                ra0_10_read_next_doc();
                ra0_99_exit();
            }

            //  go to ab0-20-read-docrev.;
            //ab0_20_read_docrev();   // Recursive.....!!!!
            //return;
        }

        private void ab0_99_exit()
        {            
            //     exit.;
        }

        private void ca0_doc_class_code()
        {            

            // if save-doc-nbr not = docrev-doc-nbr then;            
            // 	perform ca1-get-class-code	thru	ca1-99-exit.;

            if (save_doc_nbr != objDocrev_master_rec.DOCREV_DOC_NBR)
            {
                ca1_get_class_code();
                ca1_99_exit();
            }

            // objSort_docrev_rec.wk_docrev_class_code = ws_doc_class_code;
            objSort_docrev_rec.wk_docrev_class_code = ws_doc_class_code;
        }

        private void ca0_99_exit()
        {            
            //     exit.;
        }

        private void ca1_get_class_code()
        {            

            objDoc_mstr_rec.DOC_NBR = objDocrev_master_rec.DOCREV_DOC_NBR;
            doc_nbr = objDocrev_master_rec.DOCREV_DOC_NBR;
            flag = "Y";

            //     perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            // if ok then;            
            //     ws_doc_class_code = objDoc_mstr_rec.doc_class_code;
            //  else;
            //     ws_doc_class_code = "";

            if (flag.ToUpper().Equals(ok))
            {
                ws_doc_class_code = objDoc_mstr_rec. DOC_FULL_PART_IND;
            }
            else
            {
                ws_doc_class_code = "";
            }
        }

        private void ca1_99_exit()
        {            
            //     exit.;
        }

        private void ba0_process_records()
        {            

            //     return sort-docrev-file;
            // 	at end;
            // 	    go to ba0-99-exit.;          

            //save_area = objSort_docrev_rec.wk_docrev_key;               
            objDocrev_master_rec.DOCREV_DEPT = 0;
            save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
            save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
            save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
            save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
            save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_cd);
            save_class_code = Util.Str(objSort_docrev_rec.Wk_docrev_oma_suff); 

            save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);

            //ws_hold_curr_class_code = objSort_docrev_rec.wk_docrev_class_code;
            ws_hold_curr_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

            //save_class_code = objSort_docrev_rec.wk_docrev_class_code;
            save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

            // perform xi0-new-dept-head				thru xi0-99-exit.;
            xi0_new_dept_head();
            xi0_99_exit();

            // perform xk0-new-class-head				thru xk0-99-exit.;
            xk0_new_class_head();
            xk0_10_access_const_for_desc();
            xk0_99_exit();
        }

        private void ba0_10_process_records()
        {            

            //  if wk-docrev-clinic-1-2 not = ws-request-clinic-ident then;            
            //         go to ba0-99-exit.;

            while (objSort_docrev_rec.Wk_docrev_clinic_1_2 == ws_request_clinic_ident) {

                if (objSort_docrev_rec.Wk_docrev_clinic_1_2 != ws_request_clinic_ident)
                {
                    ba0_99_exit();
                    return;
                }


                // if wk-docrev-dept = save-dept then;            
                // 	   if wk-docrev-class-code = save-class-code then;
                // 	         if wk-docrev-doc-nbr = save-doc-nbr then;            
                //  		      next sentence;
                // 	          else;
                //  		      perform ba2-doctor-line			thru ba2-99-exit;
                // 	    else;
                // 	        perform ba2-doctor-line			thru ba2-99-exit;
                // 	        perform ba8-class-totals			thru ba8-99-exit;
                // 	        add 1					to subs-class-code;
                // 							   subs-max-nbr-classes;
                // 	        perform xk0-new-class-head			thru xk0-99-exit;
                // 	        perform xd0-heading-lines			thru xd0-99-exit;
                // else;
                // 	   perform ba2-doctor-line				thru ba2-99-exit;
                // 	   perform ba8-class-totals			thru ba8-99-exit;
                //     level = ss_dept;
                //     subs_dept_clinic = 1;
                // 	   perform ba7-dept-totals				thru ba7-99-exit;
                // 	   perform xg0-clear-class-tbl			thru xg0-99-exit;
                // 		       varying subs from 1 by 1;
                // 		       until subs > const-nbr-classes + 1;
                //     save_area = objSort_docrev_rec.wk_docrev_key;
                // 	   perform xi0-new-dept-head			thru xi0-99-exit;
                //     subs_class_code = 1;
                //     subs_max_nbr_classes = 1;
                //               						   
                //     level = ss_doc;
                // 	   perform xk0-new-class-head			thru xk0-99-exit;
                // 	   perform xd0-heading-lines			thru xd0-99-exit.;

                if (objSort_docrev_rec.Wk_docrev_dept == save_dept)
                {
                    if (objSort_docrev_rec.wk_docrev_class_code == save_class_code)
                    {
                        if (objSort_docrev_rec.Wk_docrev_doc_nbr == save_doc_nbr)
                        {
                            // next sentence
                        }
                        else
                        {
                            ba2_doctor_line();
                            ba2_99_exit();
                        }
                    }
                    else
                    {
                        //  perform ba2-doctor-line			thru ba2-99-exit;
                        ba2_doctor_line();
                        ba2_99_exit();

                        //  perform ba8-class-totals			thru ba8-99-exit;
                        ba8_class_totals();
                        ba8_99_exit();

                        //  add 1					to subs-class-code;
                        // 							   subs-max-nbr-classes;
                        subs_class_code++;
                        subs_max_nbr_classes++;

                        //  perform xk0-new-class-head			thru xk0-99-exit;
                        xk0_new_class_head();
                        xk0_10_access_const_for_desc();
                        xk0_99_exit();

                        // perform xd0-heading-lines			thru xd0-99-exit;
                        xd0_heading_lines();
                        xd0_99_exit();
                    }
                }
                else
                {
                    //  perform ba2-doctor-line				thru ba2-99-exit;
                    ba2_doctor_line();
                    ba2_99_exit();

                    //  perform ba8-class-totals			thru ba8-99-exit;
                    ba8_class_totals();
                    ba8_99_exit();

                    level = ss_dept;
                    subs_dept_clinic = 1;

                    //perform ba7-dept-totals				thru ba7-99-exit;
                    ba7_dept_totals();
                    ba7_10_check_code();
                    ba7_99_exit();

                    //  perform xg0-clear-class-tbl			thru xg0-99-exit;
                    // 		       varying subs from 1 by 1;
                    // 		       until subs > const-nbr-classes + 1;

                    subs = 1;
                    do
                    {
                        xg0_clear_class_tbl();
                        xg0_99_exit();
                        subs++;
                    } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1);


                    //save_area = objSort_docrev_rec.wk_docrev_key;                 // Todo: This keys are not the save as in dictionary. Verify.....??? 
                    objDocrev_master_rec.DOCREV_DEPT = 0;
                    save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                    save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                    save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                    save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                    save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_code);
                    save_class_code = objSort_docrev_rec.Wk_docrev_oma_suff;  // todo: verify save_class_code.... ?? 

                    save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);

                    //  perform xi0-new-dept-head			thru xi0-99-exit;
                    xi0_new_dept_head();
                    xi0_99_exit();

                    subs_class_code = 1;
                    subs_max_nbr_classes = 1;

                    level = ss_doc;
                    //  perform xk0-new-class-head			thru xk0-99-exit;
                    xk0_new_class_head();
                    xk0_10_access_const_for_desc();
                    xk0_99_exit();

                    //  perform xd0-heading-lines			thru xd0-99-exit.;
                    xd0_heading_lines();
                    xd0_99_exit();
                }


                //  perform ba1-add-to-areas				thru ba1-99-exit.;
                ba1_add_to_areas();
                ba1_99_exit();

                //save_area = objSort_docrev_rec.wk_docrev_key;                 // Todo: This keys are not the save as in dictionary. Verify.....??? 
                objDocrev_master_rec.DOCREV_DEPT = 0;
                save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_code);
                save_class_code = objSort_docrev_rec.Wk_docrev_oma_suff;  // todo: verify save_class_code.... ?? 

                save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);

                //    save_class_code = objSort_docrev_rec.wk_docrev_class_code;
                save_class_code = objSort_docrev_rec.wk_docrev_class_code;

                //   return sort-docrev-file;
                // 	      at end;
                // 	       go to ba0-99-exit.;
               
                if (sort_ctr >= Sort_docrev_rec_Collection.Count())
                {
                    objSort_docrev_rec = new Sort_docrev_rec();
                }
                else
                {
                    objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                    sort_ctr++;
                }
                                                   
                ws_hold_curr_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);
            }

            //     go to ba0-10-process-records.;
            //ba0_10_process_records();
            //return;
        }

        private void ba0_99_exit()
        {            
            //     exit.;
        }

        private void ba1_add_to_areas()
        {            

            // if wk-docrev-location not = "MISC" then;
            //     
            // 	     add wk-docrev-mtd-in-rec	to	mtd-in-rec	(ss-doc);
            // 						ws-mtd-in-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-mtd-in-svc	to	mtd-in-svc	(ss-doc);
            // 						ws-mtd-in-svc	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-mtd-out-rec	to	mtd-out-rec	(ss-doc);
            // 						ws-mtd-out-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-mtd-out-svc	to	mtd-out-svc	(ss-doc);
            // 						ws-mtd-out-svc	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-in-rec	to	ytd-in-rec	(ss-doc);
            // 						ws-ytd-in-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-in-svc	to	ytd-in-svc	(ss-doc);
            // 						ws-ytd-in-svc	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-out-rec	to	ytd-out-rec	(ss-doc);
            // 						ws-ytd-out-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-out-svc	to	ytd-out-svc	(ss-doc);
            // 						ws-ytd-out-svc	(subs-dept-clinic,subs-class-code);
            // else;
            // 	     add wk-docrev-mtd-out-rec	to	mtd-misc-rec	(ss-doc);
            // 						ws-mtd-misc-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-mtd-out-svc	to	mtd-misc-svc	(ss-doc);
            // 						ws-mtd-misc-svc	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-out-rec	to	ytd-misc-rec	(ss-doc);
            // 						ws-ytd-misc-rec	(subs-dept-clinic,subs-class-code);
            // 	     add wk-docrev-ytd-out-svc	to	ytd-misc-svc	(ss-doc);
            // 						ws-ytd-misc-svc	(subs-dept-clinic,subs-class-code).;

            if (objSort_docrev_rec.Wk_docrev_location != "MISC")
            {
                // 	     add wk-docrev-mtd-in-rec	to	mtd-in-rec	(ss-doc);
                // 						ws-mtd-in-rec	(subs-dept-clinic,subs-class-code);
                mtd_in_rec[ss_doc] = mtd_in_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_in_rec;
                ws_mtd_in_rec[subs_dept_clinic, subs_class_code] = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_in_rec;                

                    // 	     add wk-docrev-mtd-in-svc	to	mtd-in-svc	(ss-doc);
                    // 						ws-mtd-in-svc	(subs-dept-clinic,subs-class-code);
                    mtd_in_svc[ss_doc] = mtd_in_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_in_svc;
                ws_mtd_in_svc[subs_dept_clinic, subs_class_code] = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_in_svc;

                // 	     add wk-docrev-mtd-out-rec	to	mtd-out-rec	(ss-doc);
                // 						ws-mtd-out-rec	(subs-dept-clinic,subs-class-code);

                mtd_out_rec[ss_doc] = mtd_out_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                ws_mtd_out_rec[subs_dept_clinic, subs_class_code] = ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;

                // 	     add wk-docrev-mtd-out-svc	to	mtd-out-svc	(ss-doc);
                // 						ws-mtd-out-svc	(subs-dept-clinic,subs-class-code);

                mtd_out_svc[ss_doc] = mtd_out_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                ws_mtd_out_svc[subs_dept_clinic, subs_class_code] = ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;

                // 	     add wk-docrev-ytd-in-rec	to	ytd-in-rec	(ss-doc);
                // 						ws-ytd-in-rec	(subs-dept-clinic,subs-class-code);

                ytd_in_rec[ss_doc] = ytd_in_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_in_rec;
                ws_ytd_in_rec[subs_dept_clinic, subs_class_code] = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_in_rec;

                // 	     add wk-docrev-ytd-in-svc	to	ytd-in-svc	(ss-doc);
                // 						ws-ytd-in-svc	(subs-dept-clinic,subs-class-code);

                ytd_in_svc[ss_doc] = ytd_in_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_in_svc;
                ws_ytd_in_svc[subs_dept_clinic, subs_class_code] = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_in_svc;

                // 	     add wk-docrev-ytd-out-rec	to	ytd-out-rec	(ss-doc);
                // 						ws-ytd-out-rec	(subs-dept-clinic,subs-class-code);

                ytd_out_rec[ss_doc] = ytd_out_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                ws_ytd_out_rec[subs_dept_clinic, subs_class_code] = ws_ytd_out_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;

                // 	     add wk-docrev-ytd-out-svc	to	ytd-out-svc	(ss-doc);
                // 						ws-ytd-out-svc	(subs-dept-clinic,subs-class-code);

                ytd_out_svc[ss_doc] = ytd_out_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
                ws_ytd_out_svc[subs_dept_clinic, subs_class_code] = ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
            else
            {
                // 	     add wk-docrev-mtd-out-rec	to	mtd-misc-rec	(ss-doc);
                // 						ws-mtd-misc-rec	(subs-dept-clinic,subs-class-code);

                mtd_misc_rec[ss_doc] = mtd_misc_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                ws_mtd_misc_rec[subs_dept_clinic, subs_class_code] = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_rec; ;

                // 	     add wk-docrev-mtd-out-svc	to	mtd-misc-svc	(ss-doc);
                // 						ws-mtd-misc-svc	(subs-dept-clinic,subs-class-code);

                mtd_misc_svc[ss_doc] = mtd_misc_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                ws_mtd_misc_svc[subs_dept_clinic, subs_class_code] = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;

                // 	     add wk-docrev-ytd-out-rec	to	ytd-misc-rec	(ss-doc);
                // 						ws-ytd-misc-rec	(subs-dept-clinic,subs-class-code);

                ytd_misc_rec[ss_doc] = ytd_misc_rec[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                ws_ytd_misc_rec[subs_dept_clinic, subs_class_code] = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;

                // 	     add wk-docrev-ytd-out-svc	to	ytd-misc-svc	(ss-doc);
                // 						ws-ytd-misc-svc	(subs-dept-clinic,subs-class-code).;

                ytd_misc_svc[ss_doc] = ytd_misc_svc[ss_doc] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
                ws_ytd_misc_svc[subs_dept_clinic, subs_class_code] = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
        }

        private void ba1_99_exit()
        {            
            //     exit.;
        }

        private void ba2_doctor_line()
        {            

            //d1_nbr_name = "";
            d1_nbr_lit = string.Empty;
            d1_doc_nbr = string.Empty;
            d1_nbr_name_grp = string.Empty;

            d1_doc_nbr = save_doc_nbr;
            objDoc_mstr_rec.DOC_NBR = save_doc_nbr;
            doc_nbr = save_doc_nbr;

            // perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            ss_from = ss_doc;
            //     perform xa0-move-mtd-totals		thru	xa0-99-exit.;
            xa0_move_mtd_totals();
            xa0_99_exit();

            //     perform xb0-print-line		thru	xb0-99-exit.;
            xb0_print_line();
            xb0_99_exit();

            ss_from = ss_doc;
            ss_to = ss_dept;

            // perform xc0-bump-totals		thru	xc0-99-exit.;
            xc0_bump_totals();
            xc0_99_exit();
        }

        private void ba2_99_exit()
        {            
            //     exit.;
        }

        private void ba7_dept_totals()
        {            

            //  perform xd0-heading-lines		thru	xd0-99-exit.;
            xd0_heading_lines();
            xd0_99_exit();

            subs_class_code = 1;
        }

        private void ba7_10_check_code()
        {            

            // if subs-class-code > subs-max-nbr-classes then;            
            // 	    next sentence;
            //  else;
            //    	perform xm0-print-totals	thru	xm0-99-exit;
            // 	    add 1				to	subs-class-code;
            // 	    go to ba7-10-check-code.;

            if (subs_class_code > subs_max_nbr_classes)
            {
                // next sentence
            }
            else
            {
                // perform xm0-print-totals	thru	xm0-99-exit;
                xm0_print_totals();
                xm0_99_exit();

                //  add 1				to	subs-class-code;
                subs_class_code++;

                //  go to ba7-10-check-code.;
                ba7_10_check_code();
                return;
            }


            t1_mtd_in_svc = mtd_in_svc[level];
            t1_mtd_in_rec = mtd_in_rec[level];
            t1_mtd_out_svc = mtd_out_svc[level];
            t1_mtd_out_rec = mtd_out_rec[level];
            t1_mtd_misc_svc = mtd_misc_svc[level];
            t1_mtd_misc_rec = mtd_misc_rec[level];

            //     add mtd-in-svc (level) mtd-out-svc (level) mtd-misc-svc (level);
            // 					giving	total-svc.;
            total_svc = mtd_in_svc[level] + mtd_out_svc[level] + mtd_misc_svc[level];


            //     add mtd-in-rec (level) mtd-out-rec (level) mtd-misc-rec (level);
            // 					giving	total-rec.;
            total_rec = mtd_in_rec[level] + mtd_out_rec[level] + mtd_misc_rec[level];


            t1_mtd_tot_svc = total_svc;
            t1_mtd_tot_rec = total_rec;

            // if level = ss-dept then;            
            //     t1_dept_clinic = "**DEPARTMENTTOTALS**";
            // else;
            //     move '* CLINIC GRAND TOTALS *'   to t1-dept - clinic.

            if (level == ss_dept)
            {
                t1_dept_clinic_grp = "** DEPARTMENT TOTALS **";
            }
            else
            {
                t1_dept_clinic_grp = "* CLINIC GRAND TOTALS *";
            }

            t1_mth_yr = "MONTH";
            //     write prt-line from total-line-1	after	advancing 2 lines.;
            
            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);
            objPrint_File.print(true);

            t1_mtd_in_svc = ytd_in_svc[level];
            t1_mtd_in_rec = ytd_in_rec[level];
            t1_mtd_out_svc = ytd_out_svc[level];
            t1_mtd_out_rec = ytd_out_rec[level];
            t1_mtd_misc_svc = ytd_misc_svc[level];
            t1_mtd_misc_rec = ytd_misc_rec[level];

            //     add ytd-in-svc (level) ytd-out-svc (level) ytd-misc-svc (level);
            // 					giving	total-svc.;

            total_svc = ytd_in_svc[level] + ytd_out_svc[level] + ytd_misc_svc[level];

            //     add ytd-in-rec (level) ytd-out-rec (level) ytd-misc-rec (level);
            // 					giving	total-rec.;

            total_rec = ytd_in_rec[level] + ytd_out_rec[level] + ytd_misc_rec[level];

            t1_mtd_tot_svc = total_svc;
            t1_mtd_tot_rec = total_rec;

            // t1_dept_clinic = "";
            t1_class = string.Empty;
            t1_col_dash_lit = string.Empty;
            t1_class_lit = string.Empty;
            t1_dept_clinic_grp = string.Empty;

            t1_mth_yr = " YEAR";
            //     write prt-line from total-line-1	after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);


            // if level = ss-dept then;            
            //    ss_from = ss_dept;
            //    ss_to = ss_grand;
            //    perform xc0-bump-totals		thru	xc0-99-exit.;

            if (level == ss_dept)
            {
                ss_from = ss_dept;
                ss_to = ss_grand;
                //    perform xc0-bump-totals		thru	xc0-99-exit.;
                xc0_bump_totals();
                xc0_99_exit();
            }
        }

        private void ba7_99_exit()
        {            
            //     exit.;
        }

        private void ba8_class_totals()
        {            

            // perform ba82-display-totals			thru ba82-99-exit.;
            ba82_display_totals();
            ba82_99_exit();

            // perform ba83-bump-totals			thru ba83-99-exit.;
            ba83_bump_totals();
            ba83_99_exit();
        }

        private void ba8_99_exit()
        {            
            //     exit.;
        }

        private void ba82_display_totals()
        {            

            t1_mtd_in_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_in_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_svc = ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_rec = ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_svc = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_rec = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-in-svc(subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-svc(subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-svc(subs-dept-clinic,subs-class-code);
            // 						giving total-svc.;

            total_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_svc = total_svc;

            //     add ws-mtd-in-rec(subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-rec(subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-rec(subs-dept-clinic,subs-class-code);
            // 						giving total-rec.;

            total_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_rec = total_rec;
            t1_class = ws_class_code[subs_dept_clinic, subs_class_code];

            t1_col_dash_lit = ": - ";
            t1_class_lit = "CLASS TOTALS";
            t1_mth_yr = "MONTH";
            //     write prt-line from total-line-1		after	advancing 3 lines.;
            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);
            objPrint_File.print(true);

            //t1_dept_clinic = "";
            t1_class = string.Empty;
            t1_col_dash_lit = string.Empty;
            t1_class_lit = string.Empty;

            t1_mth_yr = " YEAR";
            t1_mtd_in_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_in_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_svc = ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_rec = ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_svc = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_rec = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-svc(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-svc(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-svc(subs-dept-clinic,subs-class-code);
            // 						giving total-svc.;

            total_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_svc = total_svc;

            //     add ws-ytd-in-rec(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-rec(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-rec(subs-dept-clinic,subs-class-code);
            // 						giving total-rec.;

            total_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code] + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_rec = total_rec;

            //     write prt-line from total-line-1		after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);
        }

        private void ba82_99_exit()
        {            
            //     exit.;
        }

        private void ba83_bump_totals()
        {            

            flag = "N";
            subs_class_total = 1;

            // if subs-present-nbr-classes not = zero then;            
            // 	   perform ba84-search-class-tbl	thru	ba84-99-exit;
            // 		varying subs1 from 1 by 1;
            // 		until   subs1 > subs-present-nbr-classes;
            // 		     or ok.;

            if (subs_present_nbr_classes != 0)
            {
                subs1 = 1;
                do
                {
                    ba84_search_class_tbl();
                    ba84_99_exit();
                    subs1++;
                } while (subs1 <= subs_present_nbr_classes && !flag.ToUpper().Equals(ok));
            }


            // if ok then;            
            // 	  next sentence;
            // else;
            //    	add 1				to	subs-present-nbr-classes;
            // 	    if subs-present-nbr-classes > const-nbr-classes + 1 then;            
            //          err_ind = 6;
            // 	        perform za0-common-error	thru	za0-99-exit;
            // 	        go to az0-finalization;
            // 	     else;
            //             ws_class_code[subs_clinic,subs_class_total] = ws_class_code[subs_dept_clinic,subs_class_code];		 
            // 		   ws-class-code-desc(subs-clinic,subs-class-total) = ws_class_code[subs_dept_clinic,subs_class_code];		

            if (flag.ToUpper().Equals(ok))
            {
                // next sentence
            }
            else
            {
                //    	add 1				to	subs-present-nbr-classes;
                subs_present_nbr_classes++;

                if (subs_present_nbr_classes > objConstants_mstr_rec_4.CONST_NBR_CLASSES + 1)
                {
                    err_ind = 6;
                    za0_common_error();
                    za0_99_exit();
                    az0_finalization();
                    return;
                }
                else
                {
                    ws_class_code[subs_clinic, subs_class_total] = ws_class_code[subs_dept_clinic, subs_class_code];
                    ws_class_code_desc[subs_clinic, subs_class_total] = ws_class_code_desc[subs_dept_clinic, subs_class_code];
                }
            }

            //     add ws-mtd-in-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-in-rec(subs-clinic,subs-class-total).;

            ws_mtd_in_rec[subs_clinic, subs_class_total] = ws_mtd_in_rec[subs_clinic, subs_class_total] + ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-in-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-in-svc(subs-clinic,subs-class-total).;

            ws_mtd_in_svc[subs_clinic, subs_class_total] = ws_mtd_in_svc[subs_clinic, subs_class_total] + ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-out-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-out-rec(subs-clinic,subs-class-total).;

            ws_mtd_out_rec[subs_clinic, subs_class_total] = ws_mtd_out_rec[subs_clinic, subs_class_total] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-out-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-out-svc(subs-clinic,subs-class-total).;

            ws_mtd_out_svc[subs_clinic, subs_class_total] = ws_mtd_out_svc[subs_clinic, subs_class_total] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-misc-rec(subs-dept-clinic,subs-class-code);
            //   					to	ws-mtd-misc-rec(subs-clinic,subs-class-total).;

            ws_mtd_misc_rec[subs_clinic, subs_class_total] = ws_mtd_misc_rec[subs_clinic, subs_class_total] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-misc-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-misc-svc(subs-clinic,subs-class-total).;

            ws_mtd_misc_svc[subs_clinic, subs_class_total] = ws_mtd_misc_svc[subs_clinic, subs_class_total] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-in-rec(subs-clinic,subs-class-total).;

            ws_ytd_in_rec[subs_clinic, subs_class_total] = ws_ytd_in_rec[subs_clinic, subs_class_total] + ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-in-svc(subs-clinic,subs-class-total).;

            ws_ytd_in_svc[subs_clinic, subs_class_total] = ws_ytd_in_svc[subs_clinic, subs_class_total] + ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-out-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-out-rec(subs-clinic,subs-class-total).;

            ws_ytd_out_rec[subs_clinic, subs_class_total] = ws_ytd_out_rec[subs_clinic, subs_class_total] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-out-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-out-svc(subs-clinic,subs-class-total).;

            ws_ytd_out_svc[subs_clinic, subs_class_total] = ws_ytd_out_svc[subs_clinic, subs_class_total] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-misc-rec(subs-dept-clinic,subs-class-code);
            //   					to	ws-ytd-misc-rec(subs-clinic,subs-class-total).;

            ws_ytd_misc_rec[subs_clinic, subs_class_total] = ws_ytd_misc_rec[subs_clinic, subs_class_total] + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-misc-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-misc-svc(subs-clinic,subs-class-total).;

            ws_ytd_misc_svc[subs_clinic, subs_class_total] = ws_ytd_misc_svc[subs_clinic, subs_class_total] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];
        }

        private void ba83_99_exit()
        {            
            //     exit.;
        }

        private void ba84_search_class_tbl()
        {            

            // if ws-class-code(subs-dept-clinic,subs-class-code) = ws-class-code(subs-clinic,subs-class-total) then;            
            //     flag = "Y";
            // else;
            //    	add 1				to	subs-class-total.;

            if (ws_class_code[subs_dept_clinic, subs_class_code] == ws_class_code[subs_clinic, subs_class_total])
            {
                flag = "Y";
            }
            else
            {
                subs_class_total++;
            }
        }

        private void ba84_99_exit()
        {            
            //     exit.;
        }

        private void ra0_read_next_docrev()
        {            

            //move docrev-key         to save-area.

            save_clinic_1_2 = Convert.ToInt32(objDocrev_master_rec.DOCREV_CLINIC_1_2);   
            save_dept = Convert.ToInt32(objDocrev_master_rec.DOCREV_DEPT);  
            save_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
            save_location = Util.Str(objDocrev_master_rec.DOCREV_LOCATION);
            save_oma = objDocrev_master_rec.DOCREV_OMA_CODE; // + objDocrev_master_rec.DOCREV_OMA_SUFF;
            //save_class_code = // todo: verify save_class_code.... ?? 
            save_class_code = objDocrev_master_rec.DOCREV_OMA_SUFF;

            save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);
        }

        private void ra0_10_read_next_doc()
        {            

            // read  docrev-mstr  next;
            // 	at end;
            //         objDocrev_master_rec.docrev_clinic_1_2 = high_values;
            // 	    go to ra0-99-exit.;
            

            if (Docrev_master_rec_Collection.Count() == 0)
            {
                //         objDocrev_master_rec.docrev_clinic_1_2 = high_values;
                objDocrev_master_rec.DOCREV_CLINIC_1_2 = high_values;

                // go to ra0-99-exit.;
                ra0_99_exit();
                return;
            }
            else
            {
                if (docrev_read >= Docrev_master_rec_Collection.Count())
                {
                    objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                }
                else
                {
                    // if (isRetreiveRecord) docrev_read = 0;
                    objDocrev_master_rec = Docrev_master_rec_Collection[docrev_read];
                    docrev_read++;
                }
            }

            //  if docrev-clinic-1-2 not = ws-request-clinic-ident then;            
            //      objDocrev_master_rec.docrev_clinic_1_2 = high_values;
            // 	    go to ra0-99-exit;
            // 	else;
            // 	    next sentence.;

            if (objDocrev_master_rec.DOCREV_CLINIC_1_2 != ws_request_clinic_ident)
            {
                objDocrev_master_rec.DOCREV_CLINIC_1_2 = high_values;
                ra0_99_exit();
                return;
            }
        }

        private void ra0_99_exit()
        {            
            //     exit.;
        }

        private void ra1_read_docrev_approx()
        {            

            //  start docrev-mstr key is greater than or equal to docrev-key;
            //  	invalid key;
            //     err_ind = 3;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    go to az0-finalization.;

            //     read docrev-mstr next.;
            //     add 1				to	docrev-read.;
            
            Docrev_master_rec_Collection = new F050_DOC_REVENUE_MSTR
            {
                WhereDocrev_clinic_1_2 = ws_request_clinic_ident
            }.Collection();

            if (Docrev_master_rec_Collection.Count() == 0)
            {
                err_ind = 3;
                // perform za0-common-error	thru	za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // 	    go to az0-finalization.;
                az0_finalization();
                return;
            }
            else
            {
                if (docrev_read >= Docrev_master_rec_Collection.Count())
                {
                    objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                }
                else
                {
                    //if (isRetreiveRecord) docrev_read = 0;
                    objDocrev_master_rec = Docrev_master_rec_Collection[docrev_read];
                    docrev_read++;
                }
            }

        }

        private void ra1_99_exit()
        {            
            //     exit.;
        }

        private void ra2_read_doc_mstr()
        {            

            // read doc-mstr;
            // 	invalid key;
            //         flag = "N";
            //          objDoc_mstr_rec.doc_name = "INVALID DOCTOR";
            // 	    go to ra2-99-exit.;

            Doc_mstr_rec_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = doc_nbr
            }.Collection();

            if (Doc_mstr_rec_Collection.Count() == 0)
            {
                flag = "N";
                objDoc_mstr_rec.DOC_NAME = "INVALID DOCTOR";
                // 	    go to ra2-99-exit.;
                ra2_99_exit();
                return;
            }
            else
            {
                objDoc_mstr_rec = Doc_mstr_rec_Collection.FirstOrDefault();               
            }
        }

        private void ra2_99_exit()
        {            
            //     exit.;
        }

        private void xa0_move_mtd_totals()
        {            

            d1_mtd_in_rec = mtd_in_rec[ss_from];
            d1_mtd_in_svc = mtd_in_svc[ss_from];
            d1_mtd_out_rec = mtd_out_rec[ss_from];
            d1_mtd_out_svc = mtd_out_svc[ss_from];
            d1_mtd_misc_rec = mtd_misc_rec[ss_from];
            d1_mtd_misc_svc = mtd_misc_svc[ss_from];

            //     add mtd-in-rec (ss-from) mtd-out-rec (ss-from) mtd-misc-rec (ss-from);
            // 					giving	total-mtd-rec.;

            total_mtd_rec = mtd_in_rec[ss_from] + mtd_out_rec[ss_from] + mtd_misc_rec[ss_from];

            //     add mtd-in-svc (ss-from) mtd-out-svc (ss-from) mtd-misc-svc (ss-from);
            // 					giving	total-mtd-svc.;

            total_mtd_svc = mtd_in_svc[ss_from] + mtd_out_svc[ss_from] + mtd_misc_svc[ss_from];

            d1_mtd_tot_rec = total_mtd_rec;
            d1_mtd_tot_svc = total_mtd_svc;
            d1_mth_yr = "MONTH";
        }

        private void xa0_99_exit()
        {            
            //     exit.;
        }

        private void xa1_move_ytd_totals()
        {            

            d1_mtd_in_rec = ytd_in_rec[ss_from];
            d1_mtd_in_svc = ytd_in_svc[ss_from];
            d1_mtd_out_rec = ytd_out_rec[ss_from];
            d1_mtd_out_svc = ytd_out_svc[ss_from];
            d1_mtd_misc_rec = ytd_misc_rec[ss_from];
            d1_mtd_misc_svc = ytd_misc_svc[ss_from];

            // add ytd-in-rec (ss-from) ytd-out-rec (ss-from) ytd-misc-rec (ss-from);
            // 					giving	total-ytd-rec.;

            total_ytd_rec = ytd_in_rec[ss_from] + ytd_out_rec[ss_from] + ytd_misc_rec[ss_from];

            //  add ytd-in-svc (ss-from) ytd-out-svc (ss-from) ytd-misc-svc (ss-from);
            // 					giving	total-ytd-svc.;

            total_ytd_svc = ytd_in_svc[ss_from] + ytd_out_svc[ss_from] + ytd_misc_svc[ss_from];

            d1_mtd_tot_rec = total_ytd_rec;
            d1_mtd_tot_svc = total_ytd_svc;
            d1_mth_yr = " YEAR";
        }

        private void xa1_99_exit()
        {            
            //     exit.;
        }

        private void xb0_print_line()
        {            

            //     add 3				to	line-cnt.;
            line_cnt = line_cnt + 3;

            // if line-cnt > max-nbr-lines then;            
            // 	   perform xd0-heading-lines	thru	xd0-99-exit.;

            if (line_cnt > max_nbr_lines)
            {
                xd0_heading_lines();
                xd0_99_exit();
            }

            d1_nbr_lit = "NBR :";

            //     write prt-line from detail-line-1   after   advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(detail_line_1_grp(), 1, true);
            objPrint_File.print(true);

            // perform xb1-doc-name-inits		thru	xb1-99-exit.;
            xb1_doc_name_inits();
            xb1_99_exit();

            // d1_nbr_name = ws_doc_name_inits;
            d1_nbr_name_grp = string.Empty;
            d1_nbr_name_grp = ws_doc_name_inits;
            d1_nbr_lit = Util.Str(ws_doc_name_inits).PadRight(28).Substring(0, 6);
            d1_doc_nbr = Util.Str(ws_doc_name_inits).PadRight(28).Substring(6, 3);

            //     perform xa1-move-ytd-totals		thru	xa1-99-exit.;
            xa1_move_ytd_totals();
            xa1_99_exit();

            //     write prt-line from detail-line-1	after	advancing 1 line.;
            objPrint_File.print(detail_line_1_grp(), 1, true);
            objPrint_File.print(true);
        }

        private void xb0_99_exit()
        {            
            //     exit.;
        }

        private void xb1_doc_name_inits()
        {            

            ws_doc_name_inits = "";

            // if doc-init3 not = spaces then;            
            // 	    string doc-name	delimited by ws-xx,;
            // 	       " "			delimited by size,;
            // 	       doc-init1		delimited by size,;
            // 	       "."			delimited by size,;
            // 	       doc-init2		delimited by size,;
            // 	       "."			delimited by size,;
            // 	       doc-init3		delimited by size,;
            // 	       "."			delimited by size,;
            // 					into	ws-doc-name-inits;
            // else if doc-init2 not = spaces then;            
            // 	    string doc-name		delimited by ws-xx,;
            // 	    " "				delimited by size,;
            // 	    doc-init1			delimited by size,;
            // 	    "."				delimited by size,;
            // 	    doc-init2			delimited by size,;
            // 	    "."				delimited by size,;
            // 					into	ws-doc-name-inits;
            // 	else if doc-init1 not = spaces then;            
            // 		string doc-name		delimited by ws-xx,;
            // 		" "			delimited by size,;
            // 		doc-init1		delimited by size,;
            // 		"."			delimited by size,;
            // 					into	ws-doc-name-inits;
            // 	else;
            //     ws_doc_name_inits = objDoc_mstr_rec.doc_name;

            if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT3))
            {
                ws_doc_name_inits = QDesign.Substring(objDoc_mstr_rec.DOC_NAME + ws_xx + objDoc_mstr_rec.DOC_INIT1 + "." + objDoc_mstr_rec.DOC_INIT2 + "." + objDoc_mstr_rec.DOC_INIT3 + ".", 1, 28);
            }
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT2))
            {
                ws_doc_name_inits = QDesign.Substring(objDoc_mstr_rec.DOC_NAME + ws_xx + objDoc_mstr_rec.DOC_INIT1 + "." + objDoc_mstr_rec.DOC_INIT2 + ".", 1, 28);
            }
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT1))
            {
                ws_doc_name_inits = QDesign.Substring(objDoc_mstr_rec.DOC_NAME + ws_xx + objDoc_mstr_rec.DOC_INIT1 + ".", 1, 28);
            }
            else
            {
                ws_doc_name_inits = QDesign.Substring(objDoc_mstr_rec.DOC_NAME, 1, 28);
            }
        }

        private void xb1_99_exit()
        {            
            //     exit.;
        }

        private void xd0_heading_lines()
        {            

            //   add 1				to	page-cnt.;
            //  h1_page = page_cnt;

            page_cnt++;
            h1_page = page_cnt;

            //     write prt-line from head-line-1	after	advancing page.;
            
            objPrint_File.PageBreak();
            objPrint_File.print(head_line_1_grp(), 1, true);
            objPrint_File.print(true);

            //     write prt-line from head-line-2	after	advancing 1 line.;            
            objPrint_File.print(head_line_2_grp(), 1, true);
            objPrint_File.print(true);

            //  if level = ss-doc then;            
            // 	    write prt-line from head-line-3	after	advancing 2 lines;
            // 	    write prt-line from head-line-4	after	advancing 1 line;
            //  else if level = ss-dept then;            
            // 	    write prt-line from head-line-3 after advancing 2 lines;
            // 					to	h6-dept-clinic-tot;
            // 	    write prt-line from head-line-6 after advancing 3 lines;
            // 	else if level = ss-grand  then;            head_line_1_grp
            // 			move 'CLINIC CLASS TOTALS'	to	h6-dept-clinic-tot;
            // 		     write prt-line from head-line-6;
            // 					after	advancing 3 lines;
            // 	else;
            //      err_ind = 5;
            // 		perform za0-common-error;
            // 					thru	za0-99-exit.;

            if (level == ss_doc)
            {
                // 	    write prt-line from head-line-3	after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_3_grp(), 1, true);
                objPrint_File.print(true);

                // 	    write prt-line from head-line-4	after	advancing 1 line;                
                objPrint_File.print(head_line_4_grp(), 1, true);
                objPrint_File.print(true);
            }
            else if (level == ss_dept)
            {
                // 	    write prt-line from head-line-3 after advancing 2 lines;
                // 					to	h6-dept-clinic-tot;
                
                //h6_dept_clinic_tot = head_line_3_grp();
                objPrint_File.print(true);
                objPrint_File.print(head_line_3_grp(), 1, true);

                //move 'DEPARTMENT CLASS TOTALS' to h6-dept - clinic - tot
                h6_dept_clinic_tot = "DEPARTMENT CLASS TOTALS";

                // 	    write prt-line from head-line-6 after advancing 3 lines;                
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(head_line_6_grp(), 1, true);
                objPrint_File.print(true);
            }
            else if (level == ss_grand)
            {
                // 			move 'CLINIC CLASS TOTALS'	to	h6-dept-clinic-tot;
                h6_dept_clinic_tot = "CLINIC CLASS TOTALS";

                // 		     write prt-line from head-line-6;
                // 					after	advancing 3 lines;
                
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(head_line_6_grp(), 1, true);
            }
            else
            {
                err_ind = 5;
                // 		perform za0-common-error;
                // 					thru	za0-99-exit.;

                za0_common_error();
                za0_99_exit();
            }

            //      write prt-line from head-line-5	after	advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(head_line_5_grp(), 1, true);
            objPrint_File.print(true);

            line_cnt = 8;
        }

        private void xd0_99_exit()
        {            
            //     exit.;
        }

        private void xg0_clear_class_tbl()
        {            

            ws_class_code[subs_dept_clinic, subs] = "";
            ws_class_code_desc[subs_dept_clinic, subs] = "";

            ws_mtd_in_rec[subs_dept_clinic, subs] = 0;
            ws_mtd_in_svc[subs_dept_clinic, subs] = 0;
            ws_mtd_out_rec[subs_dept_clinic, subs] = 0;
            ws_mtd_out_svc[subs_dept_clinic, subs] = 0;
            ws_mtd_misc_rec[subs_dept_clinic, subs] = 0;
            ws_mtd_misc_svc[subs_dept_clinic, subs] = 0;
            ws_ytd_in_rec[subs_dept_clinic, subs] = 0;
            ws_ytd_in_svc[subs_dept_clinic, subs] = 0;
            ws_ytd_out_rec[subs_dept_clinic, subs] = 0;
            ws_ytd_out_svc[subs_dept_clinic, subs] = 0;
            ws_ytd_misc_rec[subs_dept_clinic, subs] = 0;
            ws_ytd_misc_svc[subs_dept_clinic, subs] = 0;
        }

        private void xg0_99_exit()
        {            
            //     exit.;
        }

        private void xk0_new_class_head()
        {            

            subs = 1;
        }

        private void xk0_10_access_const_for_desc()
        {            

            // if ws-hold-curr-class-code = const-class-ltr(subs) then;            
            //    h4_class_code_desc = const_class_desc[subs];
            //    ws_class_code_desc[subs_dept_clinic,subs_class_code] = const_class_desc[subs];
            // 					  
            // else if subs < const-nbr-classes then;            
            // 	    add 1			to subs;
            // 	    go to xk0-10-access-const-for-desc;
            // 	else;
            //      move 'UNKNOWN DESC'		to h4-class-code-desc 
            // 	    ws-class-code-desc(subs-dept-clinic,subs-class-code) = 'UNKNOWN DESC';

            if (ws_hold_curr_class_code == CONST_CLASS_LTR(objConstants_mstr_rec_4, subs))
            {
                h4_class_code_desc = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
            }
            else if (subs < objConstants_mstr_rec_4.CONST_NBR_CLASSES)
            {
                subs++;
                xk0_10_access_const_for_desc();
                return;
            }
            else
            {
                h4_class_code_desc = "UNKNOWN DESC";
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = "UNKNOWN DESC";
            }

            ws_class_code[subs_dept_clinic, subs_class_code] = ws_hold_curr_class_code;
            h4_class_code = ws_hold_curr_class_code;

        }

        private void xk0_99_exit()
        {            
            //     exit.;
        }

        private void xi0_new_dept_head()
        {            

            //h3_dept = objSort_docrev_rec.wk_docrev_dept;
            h3_dept = objSort_docrev_rec.Wk_docrev_dept;

            objDept_mstr_rec.DEPT_NBR = objSort_docrev_rec.Wk_docrev_dept;

            // read dept-mstr;
            // 	 invalid key;
            //          err_ind = 4;
            // 	    perform za0-common-error	thru za0-99-exit;
            //objDept_mstr_rec.dept_name = "'UNKNOWN DEPT'";

            Dept_mstr_rec_Collection = new F070_DEPT_MSTR
            {
                WhereDept_nbr = Util.NumDec(objSort_docrev_rec.Wk_docrev_dept)
            }.Collection();

            if (Dept_mstr_rec_Collection.Count() == 0)
            {
                err_ind = 4;
                za0_common_error();
                za0_99_exit();
                objDept_mstr_rec.DEPT_NAME = "UNKNOWN DEPT";
            }
            else
            {
                objDept_mstr_rec = Dept_mstr_rec_Collection.FirstOrDefault();
            }
            h3_dept_name = Util.Str(objDept_mstr_rec.DEPT_NAME);
        }

        private void xi0_99_exit()
        {            
            //     exit.;
        }

        private void xm0_print_totals()
        {            

            t1_mtd_in_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_in_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_out_svc = ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_rec = ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_svc = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_rec = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            // add ws-mtd-in-svc (subs-dept-clinic,subs-class-code);
            // ws-mtd-out-svc (subs-dept-clinic,subs-class-code);
            // ws-mtd-misc-svc (subs-dept-clinic,subs-class-code);
            // 					giving	total-svc.;

            total_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            // add ws-mtd-in-rec (subs-dept-clinic,subs-class-code);
            // ws-mtd-out-rec (subs-dept-clinic,subs-class-code);
            // ws-mtd-misc-rec (subs-dept-clinic,subs-class-code);
            // 					giving	total-rec.;

            total_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_svc = total_svc;
            t1_mtd_tot_rec = total_rec;
            t1_class = ws_class_code[subs_dept_clinic, subs_class_code];

            t1_col_lit = ": ";
            t1_class_code_desc = ws_class_code_desc[subs_dept_clinic, subs_class_code];

            t1_mth_yr = "MONTH";
            //     write prt-line from total-line-1	after	advancing 2 lines.;
            
            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);
            objPrint_File.print(true);

            t1_mtd_in_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_in_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_out_svc = ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_out_rec = ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_svc = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_mtd_misc_rec = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];


            //     add ws-ytd-in-svc (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-svc (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-svc (subs-dept-clinic,subs-class-code);
            // 					giving	total-svc.;

            total_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-rec (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-rec (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-rec (subs-dept-clinic,subs-class-code);
            // 					giving	total-rec.;

            total_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code] + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_mtd_tot_svc = total_svc;
            t1_mtd_tot_rec = total_rec;
            // t1_dept_clinic = "";
            t1_class = string.Empty;
            t1_col_dash_lit = string.Empty;
            t1_class_lit = string.Empty;
            t1_col_lit = string.Empty;
            t1_class_code_desc = string.Empty;

            t1_mth_yr = " YEAR";

            //     write prt-line from total-line-1	after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);
            objPrint_File.print(true);
        }

        private void xm0_99_exit()
        {            
            //     exit.;
        }

        private void xc0_bump_totals()
        {         

            //  add mtd-in-rec (ss-from)		to	mtd-in-rec (ss-to);
            mtd_in_rec[ss_to] = mtd_in_rec[ss_to] + mtd_in_rec[ss_from];

            //   add mtd-in-svc (ss-from)		to	mtd-in-svc (ss-to);
            mtd_in_svc[ss_to] = mtd_in_svc[ss_to] + mtd_in_svc[ss_from];

            //     add mtd-out-rec (ss-from)		to	mtd-out-rec (ss-to);
            mtd_out_rec[ss_to] = mtd_out_rec[ss_to] + mtd_out_rec[ss_from];

            //     add mtd-out-svc (ss-from)		to	mtd-out-svc (ss-to);
            mtd_out_svc[ss_to] = mtd_out_svc[ss_to] + mtd_out_svc[ss_from];

            //     add mtd-misc-rec (ss-from)		to	mtd-misc-rec (ss-to);
            mtd_misc_rec[ss_to] = mtd_misc_rec[ss_to] + mtd_misc_rec[ss_from];

            //     add mtd-misc-svc (ss-from)		to	mtd-misc-svc (ss-to);
            mtd_misc_svc[ss_to] = mtd_misc_svc[ss_to] + mtd_misc_svc[ss_from];

            //     add ytd-in-rec (ss-from)		to	ytd-in-rec (ss-to);
            ytd_in_rec[ss_to] = ytd_in_rec[ss_to] + ytd_in_rec[ss_from];

            //     add ytd-in-svc (ss-from)		to	ytd-in-svc (ss-to);
            ytd_in_svc[ss_to] = ytd_in_svc[ss_to] + ytd_in_svc[ss_from];

            //     add ytd-out-rec (ss-from)		to	ytd-out-rec (ss-to);
            ytd_out_rec[ss_to] = ytd_out_rec[ss_to] + ytd_out_rec[ss_from];

            //     add ytd-out-svc (ss-from)		to	ytd-out-svc (ss-to);
            ytd_out_svc[ss_to] = ytd_out_svc[ss_to] + ytd_out_svc[ss_from];

            //     add ytd-misc-rec (ss-from)		to	ytd-misc-rec (ss-to);
            ytd_misc_rec[ss_to] = ytd_misc_rec[ss_to] + ytd_misc_rec[ss_from];

            //     add ytd-misc-svc (ss-from)		to	ytd-misc-svc (ss-to);
            ytd_misc_svc[ss_to] = ytd_misc_svc[ss_to] + ytd_misc_svc[ss_from];

            mtd_in_rec[ss_from] = 0;
            mtd_in_svc[ss_from] = 0;
            mtd_out_rec[ss_from] = 0;
            mtd_out_svc[ss_from] = 0;
            mtd_misc_rec[ss_from] = 0;
            mtd_misc_svc[ss_from] = 0;
            ytd_in_rec[ss_from] = 0;
            ytd_in_svc[ss_from] = 0;
            ytd_out_rec[ss_from] = 0;
            ytd_out_svc[ss_from] = 0;
            ytd_misc_rec[ss_from] = 0;
            ytd_misc_svc[ss_from] = 0;
        }

        private void xc0_99_exit()
        {            
            //     exit.;
        }

        private void az0_finalization()
        {            

            // perform ba2-doctor-line		thru	ba2-99-exit.;
            ba2_doctor_line();
            ba2_99_exit();

            subs_dept_clinic = 1;
            //  perform ba8-class-totals		thru	ba8-99-exit.;
            ba8_class_totals();
            ba8_99_exit();

            level = ss_dept;
            //  perform ba7-dept-totals		thru	ba7-99-exit.;
            ba7_dept_totals();
            ba7_10_check_code();
            ba7_99_exit();

            subs_dept_clinic = 2;
            level = ss_grand;
            subs_max_nbr_classes = subs_present_nbr_classes;

            //     perform ba7-dept-totals		thru	ba7-99-exit.;
            ba7_dept_totals();
            ba7_10_check_code();
            ba7_99_exit();

            //     close docrev-mstr;
            // 	  doc-mstr;
            // 	  dept-mstr;
            // 	  iconst-mstr;
            // 	  print-file.;
            //     accept sys-time			from time.;
        }

        private void az0_99_exit()
        {            
            //     exit.;
        }

        private void za0_common_error()
        {            
            err_msg_comment = err_msg[err_ind];
            //     display err-msg-comment.;
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

        private string head_line_1_grp()
        {            

            return  "R011  /".PadRight(7) + 
                    Util.Str(h1_clinic_nbr).PadLeft(2) + 
                    new string(' ', 3) + 
                    "P.E.D.".PadRight(7) + 
                    Util.Str(h1_ped_yy).PadLeft(4) + 
                    "/" + 
                    Util.Str(h1_ped_mm).PadLeft(2,'0') + 
                    "/" + 
                    Util.Str(h1_ped_dd).PadLeft(2,'0') + 
                    new string(' ', 3) +
                    "* DEPARTMENT REVENUE ANALYSIS BY CLASS BY DOCTOR *".PadRight(55) + 
                    "RUN DATE:".PadRight(11) + 
                    Util.Str(h1_year).PadLeft(4) + 
                    "/" + 
                    Util.Str(h1_month).PadLeft(2,'0') + 
                    "/" + 
                    Util.Str(h1_day).PadLeft(2,'0') + 
                    new string(' ', 7) +
                    "PAGE ".PadRight(6) + 
                    Util.Str(h1_page).PadLeft(4);
        }

        private string head_line_2_grp()
        {            

            return  new string(' ', 47) +
                    Util.Str(h2_clinic).PadRight(20) + 
                    new string(' ', 56);
        }

        private string head_line_3_grp()
        {            

            return  new string(' ', 40) + 
                    "DEPT #".PadRight(6) +
                    Util.Str(h3_dept).PadLeft(2,'0') + 
                    " - " + 
                    Util.Str(h3_dept_name).PadRight(73);
        }

        private string head_line_4_grp()
        {            

            return  new string(' ', 40) +
                    "CLASS".PadRight(7) + 
                    Util.Str(h4_class_code).PadRight(2) + 
                    "-".PadRight(2) + 
                    Util.Str(h4_class_code_desc).PadRight(73);
        }

        private string head_line_5_grp()
        {            
            return new string(' ', 38) + 
                   "# SVC___IN-PATIENT".PadRight(25) + 
                   "# SVC__OUT-PATIENT".PadRight(23) + 
                   "# SVC__MISCELLANEOUS".PadRight(26) + 
                   "# SVC__TOTAL-AMOUNT".PadRight(20);
        }

        private string head_line_6_grp()
        {            

            return  Util.Str(h6_dept_clinic_tot).PadRight(132);
        }

        private string detail_line_1_grp()
        {            
            string tmpd1_nbr_name_grp = string.Empty;
            if (!string.IsNullOrWhiteSpace(d1_nbr_name_grp))
            {
                tmpd1_nbr_name_grp = d1_nbr_name_grp.PadRight(28);
            } else
            {
                tmpd1_nbr_name_grp = Util.Str(d1_nbr_lit).PadRight(6) + Util.Str(d1_doc_nbr).PadRight(3) + new string(' ', 19);
            }

            return  tmpd1_nbr_name_grp + 
                     Util.Str(d1_mth_yr).PadRight(7) + 
                     string.Format("{0:#,0}", d1_mtd_in_svc).PadLeft(8) + 
                     new string(' ', 1) + 
                     Util.ImpliedDecimalFormat("#,0.00", d1_mtd_in_rec, 2, 13) + 
                     new string(' ', 3) + 
                     string.Format("{0:#,0}", d1_mtd_out_svc).PadLeft(8) +
                     new string(' ', 1) + 
                     Util.ImpliedDecimalFormat("#,0.00", d1_mtd_out_rec, 2, 13) + 
                     new string(' ', 1) + 
                     string.Format("{0:#,0}", d1_mtd_misc_svc).PadLeft(8) + 
                     new string(' ', 3) + 
                     Util.ImpliedDecimalFormat("#,0.00", d1_mtd_misc_rec, 2, 13) + 
                     new string(' ', 1) + 
                     string.Format("{0:#,0}", d1_mtd_tot_svc).PadLeft(9) + 
                     new string(' ', 1) +
                     Util.ImpliedDecimalFormat("#,0.00", d1_mtd_tot_rec, 2, 14);
        }

        private string total_line_1_grp()
        {            
            string tmpClassCode = string.Empty;

            if (!string.IsNullOrWhiteSpace(t1_dept_clinic_grp))
            {
                tmpClassCode = Util.Str(t1_dept_clinic_grp).PadRight(27);
            }
            else if (string.IsNullOrWhiteSpace(t1_class_lit))
            {
                tmpClassCode = Util.Str(t1_col_lit).PadRight(2) + Util.Str(t1_class_code_desc).PadRight(25);
            }           
            else
            {
                tmpClassCode = Util.Str(t1_col_dash_lit).PadRight(4) + Util.Str(t1_class_lit).PadRight(23);
            }

            return  Util.Str(t1_class).PadRight(1) +                    
                   tmpClassCode + 
                    Util.Str(t1_mth_yr).PadRight(7) + 
                    string.Format("{0:#,0}", t1_mtd_in_svc).PadLeft(8) + 
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#,0.00", t1_mtd_in_rec, 2, 13) + 
                    new string(' ', 3) + 
                    string.Format("{0:#,0}", t1_mtd_out_svc).PadLeft(8) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", t1_mtd_out_rec, 2, 13) + 
                    new string(' ', 1) +
                    string.Format("{0:#,0}", t1_mtd_misc_svc).PadLeft(8) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", t1_mtd_misc_rec, 2, 14) + 
                    new string(' ', 3) + 
                    string.Format("{0:#,0}", t1_mtd_tot_svc).PadLeft(9) + 
                    new string(' ', 1) + 
                    Util.ImpliedDecimalFormat("#,0.00", t1_mtd_tot_rec, 2, 15);
        }

        #endregion
    }
}

