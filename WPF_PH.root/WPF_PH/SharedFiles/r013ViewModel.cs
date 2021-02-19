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
    public class R013ViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private ReportPrint objPrt_line = null;
        private ObservableCollection<Prt_line> Prt_line_Collection;

        // FD: docrev_mstr	Copy : f050_doc_revenue_mstr.fd
        private F050_DOC_REVENUE_MSTR objF050_DOC_REVENUE_MSTR = null;
        private ObservableCollection<F050_DOC_REVENUE_MSTR> F050_DOC_REVENUE_MSTR_Collection;

        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private F030_LOCATIONS_MSTR objLoc_mstr_rec = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> Loc_mstr_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f013_sort_docrev_file.sd
        private Sort_docrev_rec objSort_docrev_rec = null;
        private ObservableCollection<Sort_docrev_rec> Sort_docrev_rec_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string printer_file_name = "r013";
        private string option;
        private string display_key_type;
        private int subs_table_addr;
        private string feedback_iconst_mstr;
        private string feedback_docrev_mstr = "0";
        private string status_file;
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_docrev_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_loc_mstr = "0";
        private string status_prt_file = "0";
        private string status_sort_file = "0";
        private string ws_in_progress_lit = "PROGRAM R013 IN PROGRESS";
        private string const_mstr_rec_nbr;
        private string ws_reply;
        private int x_to = 0;
        private int level = 0;
        private int x_from = 0;
        private int line_cnt = 0;
        private int page_cnt = 0;
        private int total_svc;
        private decimal total_rec;
        private int total_mtd_svc;
        private decimal total_mtd_rec;
        private int total_ytd_svc;
        private decimal total_ytd_rec;
        private int docrev_read = 0;
        private int doc_mstr_read = 0;
        private int loc_mstr_read = 0;
        private int dept_mstr_read = 0;

        private string ws_const_period_end_date_grp;
        private int ws_const_yy;
        private int ws_const_mm;
        private int ws_const_dd;
        private string request_clinic;
        private string ws_request_clinic_ident;
        private string blank_line = "";

        private string save_area_grp;
        private int save_clinic;
        private int save_dept;
        private string save_doc_nbr;
        private string save_location;
        private string save_oma;
        private string flag;
        private string ok;
        private string not_ok;
        private string flag_ohip_vs_chart;
        private string ohip;
        private string chart;
        private string flag_valid_ohip_or_chart;
        private string valid_ohip;
        private string valid_chart;
        private string invalid_ohip;
        private string invalid_chart;
        private string flag_ohip_mmyy;
        private string valid_mmyy;
        private string invalid_mmyy;

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

        //private string head_line_1_grp;
        //private string filler = "r013  /";
        private int h1_clinic_nbr;
        // private string filler = "";
        private string h1_month;
        private string filler = "";
        private int h1_day;
        //private string filler = ", ";
        private string h1_year;
        //private string filler = "";
        //private string filler = "* LOCATION REVENUE ANALYSIS BY PHYSICIAN BY OMA CODE *";
        //private string filler = "";
        private string header_date;
        //private string filler = "";
        //private string filler = "page ";
        private int h1_page;

        //private string head_line_2_grp;
        //private string filler = "";
        private string h2_clinic;
        //private string filler = "";

        //private string head_line_4_grp;
        private string h4_header_title;
        private string h4_doc_or_loc_nbr;
        //private string filler = "";
        private string h4_doc_or_loc_name;
        //private string filler = "";

        //private string head_line_5_grp;
        //private string filler = "";
        //private string filler = "---------------------- MONTH TO DATE ----------------------";
        //private string filler = "------------------------- YEAR TO DATE  ------------------------";

        //private string head_line_6_grp;
        //private string filler = " OMA    #SV....IN PAT #SV...OUT PAT #SV      MISC  #SV   TOTAL AMT  ";
        //private string filler = "#SV.....IN PAT  #SV....OUT PAT  #SV      MISC   #SV   TOTAL AMT";

        //private string detail_line_1_grp;
        //private string filler = " DEPARTMENT # ";
        private int d1_dept_nbr;
        //private string filler = "";
        private string d1_dept_name;
        //private string filler = " DOCTOR # ";
        private string d1_doc_nbr;
        //private string filler = "";
        private string d1_doc_name;
        //private string filler = "";

        //private string detail_line_2_grp;
        //private string filler = "";
        private string d2_oma_code;
        //private string filler = "";
        private int d2_mtd_in_svc;
        //private string filler = "";
        private decimal d2_mtd_in_rec;
        private int d2_mtd_out_svc;
        //private string filler = "";
        private decimal d2_mtd_out_rec;
        //private string filler = "";
        private int d2_mtd_misc_svc;
        //private string filler = "";
        private decimal d2_mtd_misc_rec;
        private int d2_mtd_tot_svc;
        //private string filler = "";
        private decimal d2_mtd_tot_rec;
        private int d2_ytd_in_svc;
        //private string filler = "";
        private decimal d2_ytd_in_rec;
        private int d2_ytd_out_svc;
        //private string filler = "";
        private decimal d2_ytd_out_rec;
        private int d2_ytd_misc_svc;
        //private string filler = "";
        private decimal d2_ytd_misc_rec;
        private int d2_ytd_tot_svc;
        //private string filler = "";
        private decimal d2_ytd_tot_rec;

        //private string total_line_1_grp;
        //private string filler = "";
        //private string filler = "**** LOCATION ";
        private string t1_location;
        //private string filler = "";
        //private string filler = "total ****";
        //private string filler = "";

        //private string total_line_1a_grp;
        //private string filler = "";
        //private string filler = "**** LOCATION SUMMARY ****";
        //private string filler = "";

        //private string total_line_2_grp;
        //private string filler = "";
        //private string filler = "#sv....in patient";
        //private string filler = "";
        //private string filler = "#sv...out patient";
        //private string filler = "";
        //private string filler = "#SV.....MISCELLAN";
        //private string filler = "";
        //private string filler = "#sv..total amount";
        //private string filler = "";

        //private string total_line_3_grp;
        //private string filler = "";
        private string t3_title;
        //private string filler = "";
        private int t3_in_svc;
        //private string filler = "";
        private decimal t3_in_rec;
        //private string filler = "";
        private int t3_out_svc;
        //private string filler = "";
        private decimal t3_out_rec;
        //private string filler = "";
        private int t3_misc_svc;
        //private string filler = "";
        private decimal t3_misc_rec;
        //private string filler = "";
        private int t3_tot_svc;
        //private string filler = "";
        private decimal t3_tot_rec;
        //private string filler = "";

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "INVALID CLINIC NUMBER";
        //private string filler = "CONSTANTS MASTER READ ERROR";
        //private string filler = "NO DOCTOR REVENUE RECORD FOR GIVEN CLINIC";
        private string error_messages_r_grp;
        private string[] err_msg = { "", "INVALID CLINIC NUMBER", "CONSTANTS MASTER READ ERROR", "NO DOCTOR REVENUE RECORD FOR GIVEN CLINIC" };
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
        private string filler = '31 december365';*/
        private string mth_desc_max_days_r_grp;
        private string[] mth_desc_max_days_occur = new string[13];
        private int[] max_nbr_days = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private string[] mth_desc = { "", "january", "february", "march", "april", "may", "june", "july", "august", "SEPTEMBER", "october", "november", "december" };
        private int[] nbr_julian_days_ytd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };

        private string prm_ws_request_clinic_ident;
        private string prm_ws_reply;

        private string endOfJob = "End of Job";      
        private int sort_ctr = 0;
        private string doc_nbr;
        private int dept_nbr;

        // added
        private string high_values = "FF";

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
        private void err_loc_mstr_file_section()
        {
            //     use after standard error procedure on loc-mstr.;
        }

        private void err_loc_mstr()
        {
            //     stop "ERROR IN ACCESSING LOCATION MASTER ".;
            status_file = status_cobol_loc_mstr;
            //     display status-file.;
            //     stop run.;
        }
        private void err_doc_mstr_file_section()
        {
            //     use after standard error procedure on doc-mstr.;
        }
        private void err_doc_mstr()
        {
            //     stop "ERROR IN ACCESSING DOCTOR MASTER ".;
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
            //     display status-file;
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

                //     perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_10();
                aa0_99_exit();

                //     sort sort-docrev-file;
                //          on ascending key wk-docrev-clinic-1-2,;
                // 			  wk-docrev-location,;
                // 			  wk-docrev-doc-nbr,;
                // 			  wk-docrev-oma-cd;
                //          input procedure is ab0-create-sort-file thru ab0-99-exit;
                // 	 output procedure is ba0-process-records thru ba0-99-exit.;

                ab0_create_sort_file();
                ab0_10_open_files();
                ab0_20_read_docrev();
                ab0_99_exit();

                ObservableCollection<Sort_docrev_rec> tmpSort_docrev_rec_Collection = null;
                tmpSort_docrev_rec_Collection = new ObservableCollection<Sort_docrev_rec>();

                foreach(var obj in   Sort_docrev_rec_Collection.OrderBy(a => a.Wk_docrev_clinic_1_2).ThenBy(b => b.Wk_docrev_location).ThenBy(c => c.Wk_docrev_doc_nbr).ThenBy(d => d.Wk_docrev_oma_cd))
                {
                    tmpSort_docrev_rec_Collection.Add(obj);
                }
                Sort_docrev_rec_Collection.Clear();
                foreach(var obj in tmpSort_docrev_rec_Collection)
                {
                    Sort_docrev_rec_Collection.Add(obj);
                }

                tmpSort_docrev_rec_Collection.Clear();
                objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                sort_ctr++;

                ba0_process_records();
                ba0_7_read_sort_file();
                ba0_10_process_records();
                ba1_add_to_areas();                
                ba2_oma_line();                
                ba4_location_header();                
                ba5_doctor_total();                
                ba6_doctor_header();                
                ba61_doctor_header();                
                ba7_location_total();                
                ra1_read_loc_mstr();                
                ra2_read_doc_mstr();                
                ra4_read_dept_mstr();                
                xa0_move_totals();                
                xb0_print_line();                
                xc0_bump_totals();                
                xd0_heading_lines();                
                ba0_99_exit();

                //  perform az0-finalization			thru az0-99-exit.;
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
                if (objPrt_line != null) objPrt_line.Close();
            }
        }

        private void aa0_initialization() // _section()
        {
            //     accept sys-date				from date.;
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

            //     perform y2k-default-sysdate		thru y2k-default-sysdate-exit.;
            y2k_default_sysdate();
            y2k_default_sysdate_exit();

            run_mm = sys_mm;
            run_dd = sys_dd;
            run_yy = sys_yy;

            objPrt_line = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + printer_file_name);
            Prt_line_Collection = new ObservableCollection<Prt_line>();

            objLoc_mstr_rec = new F030_LOCATIONS_MSTR();
            objDoc_mstr_rec = new F020_DOCTOR_MSTR();
            objIconst_mstr_rec = new ICONST_MSTR_REC();
            objDept_mstr_rec = new F070_DEPT_MSTR();
            objSort_docrev_rec = new Sort_docrev_rec();

            Sort_docrev_rec_Collection = new ObservableCollection<Sort_docrev_rec>();
        }

        private void aa0_10()
        {
            // accept ws-request-clinic-ident;
            ws_request_clinic_ident = prm_ws_request_clinic_ident;

            // if ws-request-clinic-ident = "**" then;            
            // 	   accept sys-time   from time;
            //     stop run.;

            if (ws_request_clinic_ident == "**")
            {
                throw new Exception(endOfJob);
            }

            //  open input iconst-mstr.;
            //  objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_request_clinic_ident;

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
                // 		perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                //        		go to aa0-10.;
                throw new Exception(endOfJob);
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(ws_request_clinic_ident);
            h1_year = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            h1_day = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h1_month = Util.Str(mth_desc[Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM)]);
            h2_clinic = objIconst_mstr_rec.ICONST_CLINIC_NAME;

            // accept ws-reply;
            ws_reply = prm_ws_reply;

            if (ws_reply.ToUpper() != "Y")
            {
                //          close iconst-mstr;
                //          accept sys-time	from time;
                //          stop run;
                throw new Exception(endOfJob);
            }
            else
            {
                //     open input  docrev-mstr;
                // 		dept-mstr;
                //                 loc-mstr;
                //  	        doc-mstr.;
                //     open output print-file.;
            }

            //     close iconst-mstr.;

            // perform aa1-zero-counters			thru aa1-99-exit;
            //    	varying x-from from 1 by 1;
            // 	    until x-from is greater than 5.;

            x_from = 1;
            do
            {
                aa1_zero_counters();
                aa1_99_exit();
                x_from++;
            } while (x_from <= 5);

            line_cnt = 90;
        }

        private void aa0_99_exit()
        {

        }
        private void aa1_zero_counters()
        {
            mtd_in_rec[x_from] = 0;
            mtd_in_svc[x_from] = 0;
            mtd_out_rec[x_from] = 0;
            mtd_out_svc[x_from] = 0;
            mtd_misc_rec[x_from] = 0;
            mtd_misc_svc[x_from] = 0;
            ytd_in_rec[x_from] = 0;
            ytd_in_svc[x_from] = 0;
            ytd_out_rec[x_from] = 0;
            ytd_out_svc[x_from] = 0;
            ytd_misc_rec[x_from] = 0;
            ytd_misc_svc[x_from] = 0;

        }
        private void aa1_99_exit()
        {
        }
        private void ab0_create_sort_file() //section()
        {

        }
        private void ab0_10_open_files()
        {
            objF050_DOC_REVENUE_MSTR = new F050_DOC_REVENUE_MSTR();
            //objF050_DOC_REVENUE_MSTR.docrev_key = 0;
            objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 = "";   // Todo: This keys are not the save as in dictionary. Verify.....??? 
            objF050_DOC_REVENUE_MSTR.DOCREV_DEPT = 0;
            objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR = "";
            objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION = "";
            objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE = "";
            objF050_DOC_REVENUE_MSTR.DOCREV_OMA_SUFF = "";

            //objF050_DOC_REVENUE_MSTR.docrev_clinic_1_2 = objIconst_mstr_rec.iconst_clinic_nbr_1_2;
            objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 = ws_request_clinic_ident;

            //     perform ra3-read-docrev-approx	thru ra3-99-exit.;
            ra3_read_docrev_approx();
            ra3_99_exit();
        }
        private void ab0_20_read_docrev()
        {

            // if docrev-clinic-1-2 = high-values then;            
            //         go to ab0-99-exit.;

            while (objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 != high_values) {

                if (objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 == high_values)
                {
                    ab0_99_exit();
                    return;
                }

                // objSort_docrev_rec.s sort_docrev_rec = objF050_DOC_REVENUE_MSTR.docrev_master_rec;

                Sort_docrev_rec objSort_docrev_rec = null;
                objSort_docrev_rec = new Sort_docrev_rec();
                objSort_docrev_rec.Wk_docrev_clinic_1_2 = objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2;
                objSort_docrev_rec.Wk_docrev_dept = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_DEPT);
                objSort_docrev_rec.Wk_docrev_doc_nbr = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
                objSort_docrev_rec.Wk_docrev_location = objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION;
                objSort_docrev_rec.Wk_docrev_oma_code = objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE;
                objSort_docrev_rec.Wk_docrev_oma_suff = objF050_DOC_REVENUE_MSTR.DOCREV_OMA_SUFF;
                objSort_docrev_rec.Wk_docrev_mtd_in_rec = Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_REC);
                objSort_docrev_rec.Wk_docrev_mtd_in_svc = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_IN_SVC);
                objSort_docrev_rec.Wk_docrev_mtd_out_rec = Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_REC);
                objSort_docrev_rec.Wk_docrev_mtd_out_svc = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_MTD_OUT_SVC);
                objSort_docrev_rec.Wk_docrev_ytd_in_rec = Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_REC);
                objSort_docrev_rec.Wk_docrev_ytd_in_svc = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_IN_SVC);
                objSort_docrev_rec.Wk_docrev_ytd_out_rec = Util.NumDec(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_REC);
                objSort_docrev_rec.Wk_docrev_ytd_out_svc = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_YTD_OUT_SVC);

                //     release sort-docrev-rec.;
                Sort_docrev_rec_Collection.Add(objSort_docrev_rec);

                //save_area = objF050_DOC_REVENUE_MSTR.docrev_key;
                save_clinic = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2);
                save_dept = Util.NumInt(objF050_DOC_REVENUE_MSTR.DOCREV_DEPT);
                save_doc_nbr = objF050_DOC_REVENUE_MSTR.DOCREV_DOC_NBR;
                save_location = objF050_DOC_REVENUE_MSTR.DOCREV_LOCATION;
                save_oma = objF050_DOC_REVENUE_MSTR.DOCREV_OMA_CODE;

                //     perform ra0-read-next-docrev	thru 	ra0-99-exit.;
                ra0_read_next_docrev();
                ra0_99_exit();
            }
            //     go to ab0-20-read-docrev.;
           // ab0_20_read_docrev();
           // return;
        }

        private void ab0_99_exit()
        {
            //     exit.;
        }
        private void ra0_read_next_docrev()
        {
            //  read docrev-mstr  next;
            //     	at end;
            //         objDocrev_master_rec.docrev_clinic_1_2 = high_values;
            //            go to ra0-99-exit.;

           /* bool isRetrievRecord = false;
            Docrev_master_rec_Collection = new F050_DOC_REVENUE_MSTR
            {
                WhereDocrev_clinic_1_2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2)  // todo: verify this... ?
            }.Collection_UsingStart(ref isRetrievRecord, Docrev_master_rec_Collection); */

            if (F050_DOC_REVENUE_MSTR_Collection.Count() == 0)
            {
                objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 = high_values;
                ra0_99_exit();
                return;
            }
            else
            {
                if (docrev_read >= F050_DOC_REVENUE_MSTR_Collection.Count())
                {
                    objF050_DOC_REVENUE_MSTR = new F050_DOC_REVENUE_MSTR();
                    objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 = high_values;
                    ra0_99_exit();
                    return;
                }
                else
                {
                   //if (isRetrievRecord) docrev_read = 0;
                    objF050_DOC_REVENUE_MSTR = F050_DOC_REVENUE_MSTR_Collection[docrev_read];

                    //     add 1 to docrev-read.;
                    docrev_read++;
                }
            }

            // if docrev-clinic-1-2 < ws-request-clinic-ident then;            
            // 	    go to ra0-read-next-docrev;
            // else if docrev-clinic-1-2 > ws-request-clinic-ident then;            
            //     objF050_DOC_REVENUE_MSTR.docrev_clinic_1_2 = high_values;
            // 	    go to ra0-99-exit;
            // else;
            // 	    next sentence.;

            if (objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2.CompareTo(ws_request_clinic_ident) < 0)
            {
                ra0_read_next_docrev();
                return;
            }
            else if (objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2.CompareTo(ws_request_clinic_ident) > 0)
            {
                objF050_DOC_REVENUE_MSTR.DOCREV_CLINIC_1_2 = high_values;
                ra0_99_exit();
                return;
            }
            else
            {
                // next sentence
            }
        }

        private void ra0_99_exit()
        {
            //     exit.;
        }

        private void ra3_read_docrev_approx()
        {
            // start docrev-mstr key is greater than or equal to docrev-key;
            //   	invalid key;
            //      err_ind = 3;
            // 	    perform za0-common-error	thru za0-99-exit;
            // 	    go to az0-finalization.;

            //     read docrev-mstr next.;

            //     add 1				to docrev-read.;

            bool isRetrievRecord = false;
            F050_DOC_REVENUE_MSTR_Collection = new F050_DOC_REVENUE_MSTR
            {
                WhereDocrev_clinic_1_2 = Util.Str(objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2)  // todo: verify this... ?
            }.Collection_UsingStart(ref isRetrievRecord, F050_DOC_REVENUE_MSTR_Collection);

            if (F050_DOC_REVENUE_MSTR_Collection.Count() == 0)
            {
                err_ind = 3;
                //  perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                // go to az0-finalization.;
                az0_finalization();
                return;
            }
            else
            {
                if (docrev_read >= F050_DOC_REVENUE_MSTR_Collection.Count())
                {
                    objF050_DOC_REVENUE_MSTR = new F050_DOC_REVENUE_MSTR();
                }
                else
                {
                    if (isRetrievRecord) docrev_read = 0;
                    objF050_DOC_REVENUE_MSTR = F050_DOC_REVENUE_MSTR_Collection[docrev_read];

                    //     add 1 to docrev-read.;
                    docrev_read++;
                }
            }
        }

        private void ra3_99_exit()
        {
            //     exit.;
        }

        private void ba0_process_records() //_section()
        {
        }

        private void ba0_7_read_sort_file()
        {

            //     return sort-docrev-file;
            //            at end;
            //                  go to ba0-99-exit.;

           /* if (Sort_docrev_rec_Collection.Count() == 0)
            {
                objSort_docrev_rec = new Sort_docrev_rec();
            }
            else
            {
                if (sort_ctr >= Sort_docrev_rec_Collection.Count())
                {
                    objSort_docrev_rec = new Sort_docrev_rec();
                    ba0_99_exit();
                    return;
                }
                else
                {                    
                    objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                    sort_ctr++;
                }
            } */

            //save_area = objSort_docrev_rec.wk_docrev_key;                 
            objF050_DOC_REVENUE_MSTR.DOCREV_DEPT = 0;
            save_clinic = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
            save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
            save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
            save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
            save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_code);

            save_area_grp = Util.Str(save_clinic) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma);
        }

        private void ba0_10_process_records()
        {
            while (objSort_docrev_rec.Wk_docrev_clinic_1_2 == ws_request_clinic_ident) {

                // if wk-docrev-clinic-1-2 not = ws-request-clinic-ident then;            
                //         go to ba0-99-exit.;

                if (objSort_docrev_rec.Wk_docrev_clinic_1_2 != ws_request_clinic_ident)
                {
                    ba0_99_exit();
                    break;                    
                }

                // if wk-docrev-location = save-location then
                // 	   if wk-docrev-doc-nbr = save-doc-nbr then;            
                //   	       	if wk-docrev-oma-cd = save-oma then;            
                // 		           perform ba1-add-to-areas	thru ba1-99-exit;
                // 		        else;
                // 		           perform ba2-oma-line		thru ba2-99-exit;
                // 		           perform ba1-add-to-areas	thru ba1-99-exit;
                // 	   else;
                // 		   perform ba2-oma-line			thru ba2-99-exit;
                // 		   perform ba5-doctor-total		thru ba5-99-exit;
                // 		   perform ba6-doctor-header		thru ba6-99-exit;
                // 		   perform ba1-add-to-areas		thru ba1-99-exit;
                // else;
                // 	    perform ba2-oma-line			thru ba2-99-exit;
                // 	    perform ba5-doctor-total			thru ba5-99-exit;
                //      level = 3;
                // 	    perform ba7-location-total			thru ba7-99-exit;
                //      save_area = objSort_docrev_rec.wk_docrev_key;
                // 	    perform xd0-heading-lines			thru xd0-99-exit;
                // 	    perform ba1-add-to-areas			thru ba1-99-exit.;

                if (objSort_docrev_rec.Wk_docrev_location == save_location)
                {
                    if (objSort_docrev_rec.Wk_docrev_doc_nbr == save_doc_nbr)
                    {
                        if (objSort_docrev_rec.Wk_docrev_oma_cd == save_oma)
                        {
                            //   perform ba1-add-to-areas	thru ba1-99-exit;
                            ba1_add_to_areas();
                            ba1_99_exit();
                        }
                        else
                        {
                            //  perform ba2-oma-line		thru ba2-99-exit;
                            ba2_oma_line();
                            ba2_99_exit();
                            //  perform ba1-add-to-areas	thru ba1-99-exit;
                            ba1_add_to_areas();
                            ba1_99_exit();
                        }
                    }
                    else
                    {
                        // 		   perform ba2-oma-line			thru ba2-99-exit;\
                        ba2_oma_line();
                        ba2_99_exit();
                        // 		   perform ba5-doctor-total		thru ba5-99-exit;
                        ba5_doctor_total();
                        ba5_99_exit();
                        // 		   perform ba6-doctor-header		thru ba6-99-exit;
                        ba6_doctor_header();
                        ba6_99_exit();
                        // 		   perform ba1-add-to-areas		thru ba1-99-exit;
                        ba1_add_to_areas();
                        ba1_99_exit();
                    }
                }
                else
                {
                    // 	    perform ba2-oma-line			thru ba2-99-exit;
                    ba2_oma_line();
                    ba2_99_exit();
                    // 	    perform ba5-doctor-total			thru ba5-99-exit;
                    ba5_doctor_total();
                    ba5_99_exit();
                    level = 3;
                    //  perform ba7-location-total			thru ba7-99-exit;
                    ba7_location_total();
                    ba7_99_exit();

                    //save_area = objSort_docrev_rec.wk_docrev_key;                 // Todo: 
                    objF050_DOC_REVENUE_MSTR.DOCREV_DEPT = 0;
                    save_clinic = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                    save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                    save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                    save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                    save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_code);

                    save_area_grp = Util.Str(save_clinic) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma);

                    // perform xd0-heading-lines			thru xd0-99-exit;
                    xd0_heading_lines();
                    xd0_99_exit();
                    // perform ba1-add-to-areas			thru ba1-99-exit.;
                    ba1_add_to_areas();
                    ba1_99_exit();
                }

                //save_area = objSort_docrev_rec.wk_docrev_key;                
                objF050_DOC_REVENUE_MSTR.DOCREV_DEPT = 0;
                save_clinic = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_code);

                save_area_grp = Util.Str(save_clinic) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma);

                //     return sort-docrev-file;
                //            at end;
                //                go to ba0-99-exit.;

                if (Sort_docrev_rec_Collection.Count() == 0)
                {
                    objSort_docrev_rec = new Sort_docrev_rec();
                }
                else
                {
                    if (sort_ctr >= Sort_docrev_rec_Collection.Count())
                    {
                        objSort_docrev_rec = new Sort_docrev_rec();
                        ba0_99_exit();
                        return;
                    }
                    else
                    {
                       // List<Sort_docrev_rec> tmp_Sort_docrev_rec_Collection = Sort_docrev_rec_Collection.OrderBy(a => a.Wk_docrev_clinic_1_2).ThenBy(b => b.Wk_docrev_dept).ThenBy(c => c.wk_docrev_class_code).ThenBy(d => d.Wk_docrev_doc_nbr).ToList();
                        objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                        sort_ctr++;
                    }
                }
            }
            //     go to ba0-10-process-records.;
           // ba0_10_process_records();
           // return;
        }

        private void ba1_add_to_areas()
        {

            if (objSort_docrev_rec.Wk_docrev_location  != "MISC") {
                // 	add wk-docrev-mtd-in-rec 		to	mtd-in-rec (1);
                mtd_in_rec[1] += objSort_docrev_rec.Wk_docrev_mtd_in_rec;   // wk - docrev - mtd -in-rec
                // 	add wk-docrev-mtd-in-svc		to	mtd-in-svc (1);
                mtd_in_svc[1] += objSort_docrev_rec.Wk_docrev_mtd_in_svc;
                // 	add wk-docrev-mtd-out-rec		to	mtd-out-rec (1);
                mtd_out_rec[1] += objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                // 	add wk-docrev-mtd-out-svc		to	mtd-out-svc (1);
                mtd_out_svc[1] += objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                // 	add wk-docrev-ytd-in-rec		to	ytd-in-rec (1);
                ytd_in_rec[1] += objSort_docrev_rec.Wk_docrev_ytd_in_rec;
                // 	add wk-docrev-ytd-in-svc		to	ytd-in-svc (1);
                ytd_in_svc[1] += objSort_docrev_rec.Wk_docrev_ytd_in_svc;
                // 	add wk-docrev-ytd-out-rec		to	ytd-out-rec (1);
                ytd_out_rec[1] += objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                // 	add wk-docrev-ytd-out-svc		to	ytd-out-svc (1);
                ytd_out_svc[1] += objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
            else {
                // 	add wk-docrev-mtd-out-rec		to	mtd-misc-rec (1);
                mtd_misc_rec[1] += objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                // 	add wk-docrev-mtd-out-svc		to	mtd-misc-svc (1);
                mtd_misc_svc[1] += objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                // 	add wk-docrev-ytd-out-rec		to	ytd-misc-rec (1);
                ytd_misc_rec[1] += objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                // 	add wk-docrev-ytd-out-svc		to	ytd-misc-svc (1).;
                ytd_misc_svc[1] += objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
        }

        private void ba1_99_exit()
        {

        }
        private void ba2_oma_line()
        {
            d2_oma_code = save_oma;
            x_from = 1;
            //  perform xa0-move-totals		thru	xa0-99-exit.;
            xa0_move_totals();
            xa0_99_exit();
            //  perform xb0-print-line		thru	xb0-99-exit.;
            xb0_print_line();
            xb0_99_exit();

            x_from = 1;
            x_to = 2;
            // perform xc0-bump-totals		thru	xc0-99-exit.;
            xc0_bump_totals();
            xc0_99_exit();
        }
        private void ba2_99_exit()
        {
        }

        private void ba4_location_header()
        {

            objLoc_mstr_rec.LOC_NBR  = save_location;
            // perform ra1-read-loc-mstr		thru	ra1-99-exit.;
            ra1_read_loc_mstr();
            ra1_99_exit();

            h4_header_title = "LOCATION";
            h4_doc_or_loc_nbr = save_location;
            h4_doc_or_loc_name = objLoc_mstr_rec.LOC_NAME;
            //     write prt-line from head-line-4	after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(head_line_4_grp(), 1, true);

            //     add 2 to line-cnt.;
            line_cnt = line_cnt + 2;
        }
        private void ba4_99_exit()
        {
        }

        private void ba5_doctor_total()
        {
            d2_oma_code = "*DOC*";
            x_from = 2;
            // perform xa0-move-totals		thru	xa0-99-exit.;
            xa0_move_totals();
            xa0_99_exit();
            // perform xb0-print-line		thru	xb0-99-exit.;
            xb0_print_line();
            xb0_99_exit();
            x_from = 2;
            x_to = 3;
            //  perform xc0-bump-totals		thru	xc0-99-exit.;
            xc0_bump_totals();
            xc0_99_exit();
        }

        private void ba5_99_exit()
        {
        }

        private void ba6_doctor_header()
        {

            d1_dept_nbr = objSort_docrev_rec.Wk_docrev_dept;
            objDept_mstr_rec.DEPT_NBR = objSort_docrev_rec.Wk_docrev_dept;
            dept_nbr = objSort_docrev_rec.Wk_docrev_dept;

            // perform ra4-read-dept-mstr		thru	ra4-99-exit.;
            ra4_read_dept_mstr();
            ra4_99_exit();

            d1_dept_name = objDept_mstr_rec.DEPT_NAME;
            objDoc_mstr_rec.DOC_NBR = objSort_docrev_rec.Wk_docrev_doc_nbr;
            doc_nbr = objSort_docrev_rec.Wk_docrev_doc_nbr; 

            // perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            d1_doc_nbr = objSort_docrev_rec.Wk_docrev_doc_nbr;
            d1_doc_name = objDoc_mstr_rec.DOC_NAME;

            // write prt-line from detail-line-1   after   advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(detail_line_1_grp(), 1, true);

            // add 2 to line-cnt.;
            line_cnt = line_cnt + 2;
        }

        private void ba6_99_exit()
        {
        }

        private void ba61_doctor_header()
        {
             d1_dept_nbr = save_dept;
             objDept_mstr_rec.DEPT_NBR = save_dept;
            dept_nbr = save_dept;

            // perform ra4-read-dept-mstr		thru	ra4-99-exit.;
            ra4_read_dept_mstr();
            ra4_99_exit();

            d1_dept_name = objDept_mstr_rec.DEPT_NAME;
            objDoc_mstr_rec.DOC_NBR  = save_doc_nbr;
            doc_nbr = save_doc_nbr;

            //  perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            d1_doc_nbr = save_doc_nbr;
            d1_doc_name = objDoc_mstr_rec.DOC_NAME;

            //  write prt-line from detail-line-1   after	advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(detail_line_1_grp(), 1, true);

            // add 2 to line-cnt.;
            line_cnt += 2;
        }
        private void ba61_99_exit()
        {

        }
        private void ba7_location_total()
        {

            if (line_cnt > 52)
            {
                //  perform xd0-heading-lines	thru	xd0-99-exit.;
                xd0_heading_lines();
                xd0_99_exit();
            }

            t1_location = save_location;

            if (level == 3)
            {
                //  write prt-line from total-line-1	after	advancing 3 lines;                
                objPrt_line.print(true);
                objPrt_line.print(true);
                objPrt_line.print(total_line_1_grp(), 1, true);
            }
            else
            {
                //    write prt-line from total-line-1a	after 	advancing 3 lines.;                
                objPrt_line.print(true);
                objPrt_line.print(true);
                objPrt_line.print(total_line_1a_grp(), 1, true);
            }

            // write prt-line from total-line-2	after	advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(total_line_2_grp(), 1, true);

            t3_in_svc = mtd_in_svc[level];
            t3_in_rec = mtd_in_rec[level];
            t3_out_svc = mtd_out_svc[level];
            t3_out_rec = mtd_out_rec[level];

            t3_misc_svc = mtd_misc_svc[level];
            t3_misc_rec = mtd_misc_rec[level];

            //     add mtd-in-svc (level) mtd-out-svc (level) mtd-misc-svc (level);
            // 					giving	total-svc.;

            total_svc = mtd_in_svc[level] + mtd_out_svc[level] + mtd_misc_svc[level];

            //     add mtd-in-rec (level) mtd-out-rec (level) mtd-misc-rec (level);
            // 					giving	total-rec.;

            total_rec = mtd_in_rec[level] + mtd_out_rec[level] + mtd_misc_rec[level];

            t3_tot_svc = total_svc;
            t3_tot_rec = total_rec;
            
            t3_title = "MONTH TO DATE";

            //     write prt-line from total-line-3	after	advancing 2 lines.;
            
            objPrt_line.print(true);
            objPrt_line.print(total_line_3_grp(), 1, true);

            if (line_cnt > 52)
            {
                // 	perform xd0-heading-lines	thru	xd0-99-exit.;
                xd0_heading_lines();
                xd0_99_exit();
            }

            t3_in_svc = ytd_in_svc[level];
            t3_in_rec = ytd_in_rec[level];
            t3_out_svc = ytd_out_svc[level];
            t3_out_rec = ytd_out_rec[level];

            t3_misc_svc = ytd_misc_svc[level];
            t3_misc_rec = ytd_misc_rec[level];

            // add ytd-in-svc (level) ytd-out-svc (level) ytd-misc-svc (level);
            // 					giving	total-svc.;

            total_svc = ytd_in_svc[level] + ytd_out_svc[level] + ytd_misc_svc[level];

            // add ytd-in-rec (level) ytd-out-rec (level) ytd-misc-rec (level);
            // 					giving	total-rec.;

            total_rec = ytd_in_rec[level] + ytd_out_rec[level] + ytd_misc_rec[level];

            t3_tot_svc = total_svc;
            t3_tot_rec = total_rec;
            
            t3_title = "YEAR TO DATE" ;

            //  write prt-line from total-line-3	after	advancing 2 lines.;
            
            objPrt_line.print(true);
            objPrt_line.print(total_line_3_grp(), 1, true);

            if (level == 3)
            {
                 x_from = 3;
                 x_to = 4;
                //  perform xc0-bump-totals		thru	xc0-99-exit.;
                xc0_bump_totals();
                xc0_99_exit();
            }

            line_cnt = 90;
        }
        private void ba7_99_exit()
        {

        }
        private void ra1_read_loc_mstr()
        {

            //     read loc-mstr;
            // 	invalid key move "N" to flag;
            //objLoc_mstr_rec.loc_name = "INVALID LOCATION";
            // 		    go to ra1-99-exit.;
            //     add 1 to loc-mstr-read.;

            objLoc_mstr_rec = new F030_LOCATIONS_MSTR
            {
                WhereLoc_nbr = save_location
            }.Collection().FirstOrDefault();

            loc_mstr_read++;
            if (objLoc_mstr_rec == null)
            {
                flag = "N";
                objLoc_mstr_rec.LOC_NAME = "INVALID LOCATION";
                ra1_99_exit();
                return;
            }
        }
        private void ra1_99_exit()
        {
        }
        private void ra2_read_doc_mstr()
        {

            //     read doc-mstr;
            // 	invalid key move "N" to flag;
            //objDoc_mstr_rec.doc_name = "INVALID DOCTOR";
            // 		    go to ra2-99-exit.;
            //     add 1 to doc-mstr-read.;

            objDoc_mstr_rec = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = doc_nbr
            }.Collection().FirstOrDefault();

            doc_mstr_read++;

            if (objDoc_mstr_rec == null)
            {
                flag = "N";
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                objDoc_mstr_rec.DOC_NAME = "INVALID DOCTOR";
                ra2_99_exit();
                return;
            }
        }
        private void ra2_99_exit()
        {
        }
        private void ra4_read_dept_mstr()
        {

            //     read dept-mstr;
            // 	invalid key;
            flag = "N";
            //objDept_mstr_rec.dept_name = "UNKNOWN DEPT";
            //             go to ra2-99-exit.;
            //     add 1 to dept-mstr-read.;

            objDept_mstr_rec = new F070_DEPT_MSTR
            {
                WhereDept_nbr = dept_nbr
            }.Collection().FirstOrDefault();

            dept_mstr_read++;
            if (objDept_mstr_rec == null)
            {
                flag = "N";
                objDept_mstr_rec = new F070_DEPT_MSTR();
                objDept_mstr_rec.DEPT_NAME = "UNKNOWN DEPT";
                ra2_99_exit();
                return;
            }
        }

        private void ra4_99_exit()
        {
            //     exit.;
        }

        private void xa0_move_totals()
        {

            d2_mtd_in_rec = mtd_in_rec[x_from];
            d2_mtd_in_svc = mtd_in_svc[x_from];
            d2_mtd_out_rec = mtd_out_rec[x_from];
            d2_mtd_out_svc = mtd_out_svc[x_from];
            d2_mtd_misc_rec = mtd_misc_rec[x_from];
            d2_mtd_misc_svc = mtd_misc_svc[x_from];
            d2_ytd_in_rec = ytd_in_rec[x_from];
            d2_ytd_in_svc = ytd_in_svc[x_from];
            d2_ytd_out_rec = ytd_out_rec[x_from];
            d2_ytd_out_svc = ytd_out_svc[x_from];
            d2_ytd_misc_rec = ytd_misc_rec[x_from];
            d2_ytd_misc_svc = ytd_misc_svc[x_from];

            //     add mtd-in-rec (x-from) mtd-out-rec (x-from) mtd-misc-rec (x-from);
            // 					giving	total-mtd-rec.;

            total_mtd_rec = mtd_in_rec[x_from] + mtd_out_rec[x_from] + mtd_misc_rec[x_from];

            //     add mtd-in-svc (x-from) mtd-out-svc (x-from) mtd-misc-svc (x-from);
            // 					giving	total-mtd-svc.;

            total_mtd_svc = mtd_in_svc[x_from] + mtd_out_svc[x_from] + mtd_misc_svc[x_from];

            //     add ytd-in-rec (x-from) ytd-out-rec (x-from) ytd-misc-rec (x-from);
            // 					giving	total-ytd-rec.;

            total_ytd_rec = ytd_in_rec[x_from] + ytd_out_rec[x_from] + ytd_misc_rec[x_from];

            //     add ytd-in-svc (x-from) ytd-out-svc (x-from) ytd-misc-svc (x-from);
            // 					giving	total-ytd-svc.;

            total_ytd_svc = ytd_in_svc[x_from] + ytd_out_svc[x_from] + ytd_misc_svc[x_from];

            d2_mtd_tot_rec = total_mtd_rec;
            d2_mtd_tot_svc = total_mtd_svc;
            d2_ytd_tot_rec = total_ytd_rec;
            d2_ytd_tot_svc = total_ytd_svc;
        }
        private void xa0_99_exit()
        {

        }
        private void xb0_print_line()
        {
            // add 1 to line-cnt.;
            line_cnt++;

            if (line_cnt > 60)
            {
                // perform xd0-heading-lines	thru	xd0-99-exit.;
                xd0_heading_lines();
                xd0_99_exit();
            }

            // write prt-line from detail-line-2	after	advancing 1 line.;
            
            objPrt_line.print(detail_line_2_grp(), 1, true);
        }

        private void xb0_99_exit()
        {

        }
        private void xc0_bump_totals()
        {

            //     add mtd-in-rec (x-from)		to	mtd-in-rec (x-to);
            mtd_in_rec[x_to] += mtd_in_rec[x_from];
            //     add mtd-in-svc (x-from)		to	mtd-in-svc (x-to);
            mtd_in_svc[x_to] += mtd_in_svc[x_from];
            //     add mtd-out-rec (x-from)		to	mtd-out-rec (x-to);
            mtd_out_rec[x_to] += mtd_out_rec[x_from];
            //     add mtd-out-svc (x-from)		to	mtd-out-svc (x-to);
            mtd_out_svc[x_to] += mtd_out_svc[x_from];
            //     add mtd-misc-rec (x-from)		to	mtd-misc-rec (x-to);
            mtd_misc_rec[x_to] += mtd_misc_rec[x_from];
            //     add mtd-misc-svc (x-from)		to	mtd-misc-svc (x-to);
            mtd_misc_svc[x_to] += mtd_misc_svc[x_from];
            //     add ytd-in-rec (x-from)		to	ytd-in-rec (x-to);
            ytd_in_rec[x_to] += ytd_in_rec[x_from];
            //     add ytd-in-svc (x-from)		to	ytd-in-svc (x-to);
            ytd_in_svc[x_to] += ytd_in_svc[x_from];
            //     add ytd-out-rec (x-from)		to	ytd-out-rec (x-to);
            ytd_out_rec[x_to] += ytd_out_rec[x_from];
            //     add ytd-out-svc (x-from)		to	ytd-out-svc (x-to);
            ytd_out_svc[x_to] += ytd_out_svc[x_from];
            //     add ytd-misc-rec (x-from)		to	ytd-misc-rec (x-to);
            ytd_misc_rec[x_to] += ytd_misc_rec[x_from];
            //     add ytd-misc-svc (x-from)		to	ytd-misc-svc (x-to);
            ytd_misc_svc[x_to] += ytd_misc_svc[x_from];

            mtd_in_rec[x_from] = 0;
            mtd_in_svc[x_from] = 0;
            mtd_out_rec[x_from] = 0;
            mtd_out_svc[x_from] = 0;
            mtd_misc_rec[x_from] = 0;
            mtd_misc_svc[x_from] = 0;
            ytd_in_rec[x_from] = 0;
            ytd_in_svc[x_from] = 0;
            ytd_out_rec[x_from] = 0;
            ytd_out_svc[x_from] = 0;
            ytd_misc_rec[x_from] = 0;
            ytd_misc_svc[x_from] = 0;           
        }

        private void xc0_99_exit()
        {
        }
        private void xd0_heading_lines()
        {

            //     add 1 to page-cnt;
            h1_page = page_cnt;

            //     write prt-line from head-line-1 after advancing page.;            
            objPrt_line.PageBreak();
            objPrt_line.print(head_line_1_grp(), 1, true);

            //     write prt-line from head-line-2 after advancing 1 line.;            
            objPrt_line.print(head_line_2_grp(), 1, true);

            //     perform ba4-location-header		thru ba4-99-exit.;
            ba4_location_header();
            ba4_99_exit();

            //     write prt-line from head-line-5 after advancing 2 lines.;            
            objPrt_line.print(true);
            objPrt_line.print(head_line_5_grp(), 1, true);

            //     write prt-line from head-line-6 after advancing 1 line.;            
            objPrt_line.print(head_line_6_grp(), 1, true);

            //     write prt-line from blank-line after advancing 1 line.;
            objPrt_line.print(true);

            line_cnt = 7;

            //     perform ba61-doctor-header		thru ba61-99-exit.;
            ba61_doctor_header();
            ba61_99_exit();
        }

        private void xd0_99_exit()
        {
        }
        private void ba0_99_exit()
        {
        }
        private void az0_finalization() //_section()
        {

            //  perform ba2-oma-line		thru	ba2-99-exit.;
            ba2_oma_line();
            ba2_99_exit();

            //  perform ba5-doctor-total		thru	ba5-99-exit.;
            ba5_doctor_total();
            ba5_99_exit();

            level = 3;
            //  perform ba7-location-total		thru	ba7-99-exit.;
            ba7_location_total();
            ba7_99_exit();

            //     add 1 to page-cnt.;
            page_cnt++;

            h1_page = page_cnt;

            //     write prt-line from head-line-1 after advancing page.;            

            objPrt_line.PageBreak();
            objPrt_line.print(head_line_1_grp(), 1, true);

            //     write prt-line from head-line-2 after advancing 1 line.;            
            objPrt_line.print(head_line_2_grp(), 1, true);

            //     set line-cnt to 3.;
            line_cnt = 3;
            level = 4;

            //  perform ba7-location-total		thru	ba7-99-exit.;
            ba7_location_total();
            ba7_99_exit();

            //     close loc-mstr;
            // 	  docrev-mstr;
            // 	  doc-mstr;
            // 	  print-file.;

            //     accept sys-time			from time.;
        }

        private void az0_99_exit()
        {

        }
        private void za0_common_error()
        {

            err_msg_comment = err_msg[err_ind];
            //     display err-msg-comment.;
            Console.WriteLine(err_msg_comment);
        }

        private void za0_99_exit()
        {
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

        private string head_line_1_grp()
        {
            return  "R013  /".PadRight(7) + 
                    Util.Str(h1_clinic_nbr).PadLeft(2, '0') + 
                    new string(' ', 1) + 
                    Util.Str(h1_month).PadRight(9) + 
                    new string(' ', 1) + 
                    Util.Str(h1_day).PadLeft(2) + 
                    ", ".PadRight(2) + 
                    Util.Str(h1_year).PadRight(4) +
                    new string(' ', 3) + 
                    "* LOCATION REVENUE ANALYSIS BY PHYSICIAN BY OMA CODE *".PadRight(55) + 
                    new string(' ', 8) + 
                    Util.Str(header_date).PadRight(8) + 
                    new string(' ', 10) + 
                    "PAGE ".PadRight(5) + 
                    string.Format("{0:#,#}", h1_page).PadLeft(5);
        }

        private string head_line_2_grp()
        {
            return   new string(' ', 49) + 
                     Util.Str(h2_clinic).PadRight(20) + 
                     new string(' ', 60);
        }

        private string head_line_4_grp()
        {
            return   Util.Str(h4_header_title).PadRight(10) + 
                     Util.Str(h4_doc_or_loc_nbr).PadRight(5) + 
                     new string(' ', 1) + 
                     Util.Str(h4_doc_or_loc_name).PadRight(25) + 
                     new string(' ', 91);
        }

        private string head_line_5_grp()
        {
            return  new string(' ', 8) + 
                    "---------------------- MONTH TO DATE ----------------------".PadRight(60) + 
                    "------------------------- YEAR TO DATE  ------------------------".PadRight(64);
        }

        private string head_line_6_grp()
        {
            return " OMA    #SV....IN PAT #SV...OUT PAT #SV      MISC  #SV   TOTAL AMT  ".PadRight(68) + 
                   "#SV.....IN PAT  #SV....OUT PAT  #SV      MISC   #SV   TOTAL AMT".PadRight(65);
        }

        private string detail_line_1_grp()
        {
            return " DEPARTMENT # ".PadRight(14) + 
                   Util.Str(d1_dept_nbr).PadLeft(2, '0') + 
                   new string(' ', 1) + 
                   Util.Str(d1_dept_name).PadRight(30) + 
                   " DOCTOR # ".PadRight(10) + 
                   Util.Str(d1_doc_nbr).PadRight(3) + 
                   new string(' ', 2) + 
                   Util.Str(d1_doc_name).PadRight(25) + 
                   new string(' ', 43);
        }

        private string detail_line_2_grp()
        {
            return  new string(' ', 1) +
                                Util.Str(d2_oma_code).PadRight(5) +
                                new string(' ', 2) +
                                Util.Str(d2_mtd_in_svc).PadLeft(4) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", d2_mtd_in_rec, 2, 9) +
                                Util.Str(d2_mtd_out_svc).PadLeft(4) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#,0.00", d2_mtd_out_rec, 2, 9) +
                                new string(' ', 1) +
                                Util.Str(d2_mtd_misc_svc).PadLeft(2) +
                                new string(' ', 2) +
                                Util.ImpliedDecimalFormat("#,0.00", d2_mtd_misc_rec, 2, 9) +
                                Util.Str(d2_mtd_tot_svc).PadLeft(4) +
                                new string(' ', 3) +
                                Util.ImpliedDecimalFormat("#,0.00", d2_mtd_tot_rec, 2, 10) +
                                Util.Str(d2_ytd_in_svc).PadLeft(4) +
                                new string(' ', 2) +
                                Util.ImpliedDecimalFormat("#0.00", d2_ytd_in_rec, 2, 10) +
                                Util.Str(d2_ytd_out_svc).PadLeft(4) +
                                new string(' ', 2) +
                                Util.ImpliedDecimalFormat("#0.00", d2_ytd_out_rec, 2, 10) +
                                Util.Str(d2_ytd_misc_svc).PadLeft(4) +
                                new string(' ', 1) +
                                Util.ImpliedDecimalFormat("#0.00", d2_ytd_misc_rec, 2, 10) +
                                Util.Str(d2_ytd_tot_svc).PadLeft(5) +
                                new string(' ', 2) +
                                Util.ImpliedDecimalFormat("#0.00", d2_ytd_tot_rec, 2, 11);
        }

        private string total_line_1_grp()
        {
            return  new string(' ', 34) + 
                    "**** LOCATION ".PadRight(14) +
                    Util.Str(t1_location).PadRight(4) + 
                    new string(' ', 6) + 
                    "TOTAL ****".PadRight(10) + 
                    new string(' ', 64);
        }

        private string total_line_1a_grp()
        {
            return   new string(' ', 34) + 
                     "**** LOCATION SUMMARY ****".PadRight(28) + 
                     new string(' ', 72);
        }

        private string total_line_2_grp()
        {
            return  new string(' ', 25) + 
                    "#SV....IN PATIENT".PadRight(17) + 
                    new string(' ', 6) + 
                    "#SV...OUT PATIENT".PadRight(17) + 
                    new string(' ', 6) + 
                    "#SV.....MISCELLAN".PadRight(17) + 
                    new string(' ', 6) + 
                    "#SV..TOTAL AMOUNT".PadRight(17) + 
                    new string(' ', 21);
        }

        private string total_line_3_grp()
        {
            return  new string(' ', 3) +
                               Util.Str(t3_title).PadRight(13) +
                               new string(' ', 5) +
                               string.Format("{0:#,0}", t3_in_svc).PadLeft(7) +
                               new string(' ', 1) +
                               Util.ImpliedDecimalFormat("#,0.00", t3_in_rec, 2, 13) +
                               new string(' ', 1) +
                               string.Format("{0:#,0}", t3_out_svc).PadLeft(7) +
                               new string(' ', 1) +
                               Util.ImpliedDecimalFormat("#,0.00", t3_out_rec, 2, 13) +
                               new string(' ', 1) +
                               string.Format("{0:#,0}", t3_misc_svc).PadLeft(7) +
                               new string(' ', 1) +
                               Util.ImpliedDecimalFormat("#,0.00", t3_misc_rec, 2, 13) +
                               new string(' ', 1) +
                               string.Format("{0:#,0}", t3_tot_svc).PadLeft(7) +
                               new string(' ', 1) +
                               Util.ImpliedDecimalFormat("#,0.00", t3_tot_rec, 2, 13) +
                               new string(' ', 20);
        }

        #endregion
    }
}


