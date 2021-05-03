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
    public class R012ViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: print_file
        private Prt_line objPrt_line = null;
        private ObservableCollection<Prt_line> Prt_line_Collection;

        // FD: docrev_mstr	Copy : f050_doc_revenue_mstr.fd
        private F050_DOC_REVENUE_MSTR objDocrev_master_rec = null;
        private ObservableCollection<F050_DOC_REVENUE_MSTR> Docrev_master_rec_Collection;

        // FD: loc_mstr	Copy : f030_locations_mstr.fd
        private F030_LOCATIONS_MSTR objLoc_mstr_rec = null;
        private ObservableCollection<F030_LOCATIONS_MSTR> Loc_mstr_rec_Collection;

        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: dept_mstr	Copy : f070_dept_mstr.fd
        private F070_DEPT_MSTR objDept_mstr_rec = null;
        private ObservableCollection<F070_DEPT_MSTR> Dept_mstr_rec_Collection;

        // FD: dept_mstr	Copy : r011_sort_docrev_file.sd
        private Sort_docrev_rec objSort_docrev_rec = null;
        private ObservableCollection<Sort_docrev_rec> Sort_docrev_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: iconst_mstr	Copy : f090_const_mstr_rec_4.ws
        private CONSTANTS_MSTR_REC_4 objConstants_mstr_rec_4 = null;
        private ObservableCollection<CONSTANTS_MSTR_REC_4> Constants_mstr_rec_4_Collection;


        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private string printer_file_name = "r012";
        private string option;
        private string display_key_type;
        private int subs_table_addr;
        private int subs;
        private int subs_class_code;
        private int subs_dept_clinic;
        private int subs_max_nbr_classes;
        private int subs_max_nbr_classes_clinic;
        private string feedback_iconst_mstr;
        private string feedback_docrev_mstr;
        private int max_nbr_lines = 57;
        private int ss_max_nbr_subscripts = 5;
        private string ws_hold_curr_class_code;
        private int ws_nbr_classes;
        private string ws_doc_class_code;
        private string ws_doc_name_inits;
        private string eof_subscr_mstr = "N";
        private string status_file;
        private string status_cobol_subscr_mstr = "0";
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_dept_mstr = "0";
        private string status_cobol_docrev_mstr = "0";
        private string status_cobol_loc_mstr = "0";
        private string status_prt_file = "0";
        private string const_mstr_rec_nbr;
        private string ws_reply;
        private string ws_in_progress_lit = "PROGRAM R012 IN PROGRESS";
        private int x_to = 0;
        private int level = 0;
        private int x_from = 0;
        private int line_cnt = 57;
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
        private string blank_line = "";

        private string save_area_grp;
        private int save_clinic_1_2;
        private int save_dept;
        private string save_doc_nbr;
        private string save_location;
        private string save_oma;
        private string save_class_code;
        private string request_clinic;
        private string ws_request_clinic_ident;
        private string flag_new_class;
        private string new_class = "Y";
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
        private string[,] ws_max_class_codes = new string[3, 16];
        private string[,] ws_class_code = new string[3, 16];
        private string[,] ws_class_code_desc = new string[3, 16];
        private decimal[,] ws_mtd_in_rec = new decimal[3, 16];
        private int[,] ws_mtd_in_svc = new int[3, 16];
        private decimal[,] ws_mtd_out_rec = new decimal[3, 16];
        private int[,] ws_mtd_out_svc = new int[3, 16];
        private decimal[,] ws_mtd_misc_rec = new decimal[3, 16];
        private int[,] ws_mtd_misc_svc = new int[3, 16];
        private decimal[,] ws_ytd_in_rec = new decimal[3, 16];
        private int[,] ws_ytd_in_svc = new int[3, 16];
        private decimal[,] ws_ytd_out_rec = new decimal[3, 16];
        private int[,] ws_ytd_out_svc = new int[3, 16];
        private decimal[,] ws_ytd_misc_rec = new decimal[3, 16];
        private int[,] ws_ytd_misc_svc = new int[3, 16];
        private string ws_xx = "  ";

        //private string head_line_1_grp;
        private string filler = "r012  /";
        private int h1_clinic_nbr;
        //private string filler = "";
        //private string filler = 'P.E.D.';
        private int h1_ped_yy;
        //private string filler = '/';
        private int h1_ped_mm;
        //private string filler = '/';
        private int h1_ped_dd;
        //private string filler = "";
        //private string filler = "* PHYSICIAN REVENUE ANALYSIS BY LOCATION(S) BY OMA CODE *";
        //private string filler = 'run date:';
        private int h1_date_yy;
        //private string filler = '/';
        private int h1_date_mm;
        //private string filler = '/';
        private int h1_date_dd;
        //private string filler = "";
        //private string filler = "page ";
        private int h1_page;

        //private string head_line_2_grp;
        //private string filler = "";
        private string h2_clinic;
        //private string filler = "";

        //private string head_line_3_grp;
        //private string filler = "";
        //private string filler = "dept #";
        private int h3_department;
        private string h3_dept_name;

        //private string head_line_4_grp;
        //private string filler = "";
        //private string filler = 'CLASS';
        private string h4_class_code;
        //private string filler = '-';
        private string h4_class_code_desc;

        //private string head_line_5_grp;
        //private string filler = "";
        //private string filler = "--------------------- MONTH TO DATE ---------------------";
        //private string filler = "";
        //private string filler = "--------------------------- YEAR TO DATE -------------------------";

        //private string head_line_6_grp;
        //private string filler = " OMA  #SV____IN-PAT  #SV___OUT-PAT #SV____MISC   #SV__TOTAL-AMT  ";
        //private string filler = "  #SV____IN-PAT    #SV___OUT-PAT    #SV______MISC    #SV__TOTAL-AMT";

        //private string head_line_7_grp;
        private string h7_doc_lit;
        private string h7_doc_nbr;
        //private string filler = "";
        private string h7_doc_name_inits;

        //private string head_line_8_grp;
        private string h8_loc_lit;
        private string h8_loc;
        private string h8_loc_name;

        //private string head_line_9_grp;
        private string h9_dept_clinic_tot;

        //private string detail_line_1_grp;
        private string d1_oma_code_or_lit;
        private int d1_mtd_in_svc;
        //private string filler = "";
        private decimal d1_mtd_in_rec;
        //private string filler = "";
        private int d1_mtd_out_svc;
        //private string filler = "";
        private decimal d1_mtd_out_rec;
        //private string filler = "";
        private int d1_mtd_misc_svc;
        private decimal d1_mtd_misc_rec;
        //private string filler = "";
        private int d1_mtd_tot_svc;
        //private string filler = "";
        private decimal d1_mtd_tot_rec;
        //private string filler = "";
        private int d1_ytd_in_svc;
        //private string filler = "";
        private decimal d1_ytd_in_rec;
        //private string filler = "";
        private int d1_ytd_out_svc;
        //private string filler = "";
        private decimal d1_ytd_out_rec;
        //private string filler = "";
        private int d1_ytd_misc_svc;
        //private string filler = "";
        private decimal d1_ytd_misc_rec;
        //private string filler = "";
        private int d1_ytd_tot_svc;
        //private string filler = "";
        private decimal d1_ytd_tot_rec;
        //private string filler = "";

        //private string total_head_line_1_grp;
        //private string filler = "";
        //private string filler = "# svc____in-patient";
        //private string filler = "# svc___out-patient";
        //private string filler = "# svc__miscellaneous";
        //private string filler = "# svc__total-amount";

        //private string total_line_1_grp;
        private string t1_total_lit_grp;
        private string t1_class_lit;
        private string t1_class;
        private string t1_totals_lit;
        private string t1_total_lit_r_grp;
        private string t1_class_r;
        private string t1_col_lit;
        private string t1_class_code_desc;
        private string t1_mth_yr;
        private int t1_in_svc;
        //private string filler = "";
        private decimal t1_in_rec;
        //private string filler = "";
        private int t1_out_svc;
        //private string filler = "";
        private decimal t1_out_rec;
        //private string filler = "";
        private int t1_misc_svc;
        //private string filler = "";
        private decimal t1_misc_rec;
        //private string filler = "";
        private int t1_tot_svc;
        //private string filler = "";
        private decimal t1_tot_rec;

        private string error_message_table_grp;
        private string error_messages_grp;
        //private string filler = "INVALID CLINIC NUMBER";
        //private string filler = "CONSTANTS MASTER READ ERROR";
        //private string filler = "NO DOCTOR REVENUE RECORD FOR GIVEN CLINIC";
        //private string filler = "DEPARTMENT MSTR READ ERROR";
        //private string filler = "HEADINGS PRINTED ONLY ON DEPT-TOTAL BREAK";
        //private string filler = "TOO MANY CLASS CODES FOUND";
        private string error_messages_r_grp;
        private string[] err_msg = { "", "INVALID CLINIC NUMBER", "CONSTANTS MASTER READ ERROR", "NO DOCTOR REVENUE RECORD FOR GIVEN CLINIC", "DEPARTMENT MSTR READ ERROR", "HEADINGS PRINTED ONLY ON DEPT-TOTAL BREAK", "TOO MANY CLASS CODES FOUND" };
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
        private int ctr;
        private string locationKey = string.Empty;

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

                objPrt_line = new Prt_line();
                Prt_line_Collection = new ObservableCollection<Prt_line>();

                objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                Docrev_master_rec_Collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();

                objLoc_mstr_rec = new F030_LOCATIONS_MSTR();
                Loc_mstr_rec_Collection = new ObservableCollection<F030_LOCATIONS_MSTR>();

                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objDept_mstr_rec = new F070_DEPT_MSTR();
                Dept_mstr_rec_Collection = new ObservableCollection<F070_DEPT_MSTR>();

                objSort_docrev_rec = new Sort_docrev_rec();
                Sort_docrev_rec_Collection = new ObservableCollection<Sort_docrev_rec>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objPrint_File = new ReportPrint(Directory.GetCurrentDirectory() + "\\" + printer_file_name);


                //  perform aa0-initialization			thru aa0-99-exit.;
                aa0_initialization();
                aa0_10();
                aa0_99_exit();

                //     sort sort-docrev-file;
                // 	 on ascending key;
                // 		wk-docrev-clinic-1-2;
                // 		wk-docrev-dept;
                // 		wk-docrev-class-code;
                // 		wk-docrev-doc-nbr;
                // 		wk-docrev-location;
                // 		wk-docrev-oma-cd;
                // 	input procedure is	ab0-create-sort-file	thru ab0-99-exit;

                ab0_create_sort_file();
                ab0_10_open_files();
                ab0_20_read_docrev();
                ab0_99_exit();

                ObservableCollection<Sort_docrev_rec> tmp_Sort_docrev_Collection = null;
                tmp_Sort_docrev_Collection = new ObservableCollection<Sort_docrev_rec>();

                foreach (var obj in Sort_docrev_rec_Collection.OrderBy(a => a.Wk_docrev_clinic_1_2).ThenBy(b => b.Wk_docrev_dept).ThenBy(c => c.wk_docrev_class_code).ThenBy(d => d.Wk_docrev_doc_nbr).ThenBy(e => e.Wk_docrev_location).ThenBy(f => f.Wk_docrev_oma_cd))
                {
                    tmp_Sort_docrev_Collection.Add(obj);
                }

                Sort_docrev_rec_Collection.Clear();
                foreach (var obj in tmp_Sort_docrev_Collection)
                {
                    Sort_docrev_rec_Collection.Add(obj);
                }
               
                // 	output procedure is	ba0-process-records	thru ba0-99-exit.;
                ba0_process_records();
                ba0_10_process_records();
                ba0_99_exit();

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
            h1_date_mm = sys_mm;
            // 						   h1-date-mm.;
            run_dd = sys_dd;
            h1_date_dd = sys_dd;
            // 						   h1-date-dd.;
            run_yy = sys_yy;
            h1_date_yy = sys_yy;
            // 						   h1-date-yy.;
        }

        private void aa0_10()
        {            

            //     accept ws-request-clinic-ident;
            ws_request_clinic_ident = prm_ws_request_clinic_ident;

            // if ws-request-clinic-ident = "**" then;            
            // 	   accept sys-time   from time;
            //         stop run.;

            if (ws_request_clinic_ident == "**")
            {
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

                throw new Exception(endOfJob);
            }

            // open input iconst-mstr.;

            //objIconst_mstr_rec.iconst_clinic_nbr_1_2 = ws_request_clinic_ident;
            this.objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = Util.NumDec(ws_request_clinic_ident);

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

                //aa0_10();
                throw new Exception(endOfJob);
            }

            objIconst_mstr_rec = Iconst_mstr_rec_Collection.FirstOrDefault();

            h1_clinic_nbr = Util.NumInt(ws_request_clinic_ident);

            h1_ped_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);

            h1_ped_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            h1_ped_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            h2_clinic = objIconst_mstr_rec.ICONST_CLINIC_NAME;

            //     accept ws-reply;
            ws_reply = prm_ws_reply;

            // if ws-reply not = "Y" then;            
            //          close iconst-mstr;
            //          accept sys-time	from time;
            //          stop run;
            //  else;
            //     objIconst_mstr_rec.iconst_clinic_nbr_1_2 = 4;
            //     read iconst-mstr;
            // 	        invalid key;
            //           err_ind = 2;
            // 		perform za0-common-error	thru za0-99-exit;
            // 		go to az0-finalization.;

            if (ws_reply.ToUpper() != "Y")
            {
                throw new Exception(endOfJob);
            }
            else
            {
                objIconst_mstr_rec.ICONST_CLINIC_NBR_1_2 = 4;

                Constants_mstr_rec_4_Collection = new CONSTANTS_MSTR_REC_4
                {
                    WhereConst_rec_nbr = 4
                }.Collection();

                if (Constants_mstr_rec_4_Collection.Count() == 0)
                {
                    err_ind = 2;
                    // 		perform za0-common-error	thru za0-99-exit;
                    za0_common_error();
                    za0_99_exit();

                    // 		go to az0-finalization.;
                    az0_finalization();
                    return;
                }
                else
                {
                    objConstants_mstr_rec_4 = Constants_mstr_rec_4_Collection.FirstOrDefault();
                }
            }


            // open input  loc-mstr;
            // 		docrev-mstr;
            // 		dept-mstr;
            // 		doc-mstr.;

            //      open output  print-file.;

            subs_dept_clinic = 1;

            //     perform xg0-clear-class-tbl			thru xg0-99-exit;
            // 	varying subs from 1 by 1;
            // 	until subs > const-nbr-classes.;

            subs = 1;
            do
            {
                xg0_clear_class_tbl();
                xg0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES);

            subs_dept_clinic = 2;

            // perform xg0-clear-class-tbl			thru xg0-99-exit;
            // 	varying subs from 1 by 1;
            // 	until subs > const-nbr-classes.;

            subs = 1;
            do
            {
                xg0_clear_class_tbl();
                xg0_99_exit();
                subs++;
            } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES);

            subs_class_code = 0;
            subs_max_nbr_classes = 0;
            subs_max_nbr_classes_clinic = 0;

            subs_dept_clinic = 1;

            //  perform aa1-zero-counters			thru aa1-99-exit;
            // 	varying x-from from 1 by 1;
            // 	until x-from is greater than ss-max-nbr-subscripts.;

            x_from = 1;
            do
            {
                aa1_zero_counters();
                aa1_99_exit();
                x_from++;
            } while (x_from <= ss_max_nbr_subscripts);

            level = 3;
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
        private void ab0_create_sort_file()  // section
        {         
        }

        private void ab0_10_open_files()
        {         

            //objDocrev_master_rec.docrev_key = 0;
            objDocrev_master_rec.DOCREV_CLINIC_1_2 = "";
            objDocrev_master_rec.DOCREV_DEPT = 0;
            objDocrev_master_rec.DOCREV_DOC_NBR = "";
            objDocrev_master_rec.DOCREV_LOCATION = "";
            objDocrev_master_rec.DOCREV_OMA_CODE = "";
            objDocrev_master_rec.DOCREV_OMA_SUFF = "";

            subs = 0;

            //objDocrev_master_rec.docrev_clinic_1_2 = ws_request_clinic_ident;
            objDocrev_master_rec.DOCREV_CLINIC_1_2 = ws_request_clinic_ident;

            // perform ra3-read-docrev-approx	thru	ra3-99-exit.;
            ra3_read_docrev_approx();
            ra3_99_exit();
        }

        private void ab0_20_read_docrev()
        {            

            while (objDocrev_master_rec.DOCREV_CLINIC_1_2 != high_values)
            {
                // if docrev-clinic-1-2 = high-values then;            
                //         go to ab0-99-exit.;

                if (objDocrev_master_rec.DOCREV_CLINIC_1_2 == high_values)
                {
                    ab0_99_exit();
                    break;
                }

                objSort_docrev_rec = null;
                objSort_docrev_rec = new Sort_docrev_rec();

                //objSort_docrev_rec.wk_docrev_key = objDocrev_master_rec.docrev_key;
                objSort_docrev_rec.Wk_docrev_clinic_1_2 = Util.Str(objDocrev_master_rec.DOCREV_CLINIC_1_2);
                objSort_docrev_rec.Wk_docrev_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);
                objSort_docrev_rec.Wk_docrev_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
                objSort_docrev_rec.Wk_docrev_location = Util.Str(objDocrev_master_rec.DOCREV_LOCATION);
                objSort_docrev_rec.Wk_docrev_oma_cd = Util.Str(objDocrev_master_rec.DOCREV_OMA_CODE);
                objSort_docrev_rec.Wk_docrev_oma_suff = Util.Str(objDocrev_master_rec.DOCREV_OMA_SUFF);

                //objSort_docrev_rec.wk_docrev_month_to_date = objDocrev_master_rec.docrev_month_to_date;            
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

                //     release sort-docrev-rec.;
                Sort_docrev_rec_Collection.Add(objSort_docrev_rec);

                //  perform ra0-read-next-docrev	thru 	ra0-99-exit.;
                ra0_read_next_docrev();
                ra0_10_read_docrev();
                ra0_99_exit();

                //  go to ab0-20-read-docrev.;               
            }
        }

        private void ab0_99_exit()
        {            
            //     exit.;
        }
        private void ca0_doc_class_code()
        {            

            // if save-doc-nbr not = docrev-doc-nbr then            
            // 	  perform ca1-get-class-code	thru	ca1-99-exit.;

            if (save_doc_nbr != objDocrev_master_rec.DOCREV_DOC_NBR)
            {
                ca1_get_class_code();
                ca1_99_exit();
            }

            //objSort_docrev_rec.wk_docrev_class_code = ws_doc_class_code;            
            objSort_docrev_rec.wk_docrev_class_code = ws_doc_class_code;
        }


        private void ca0_99_exit()
        {            

            //     exit.;
        }

        private void ca1_get_class_code()
        {            

            objDoc_mstr_rec.DOC_NBR = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
            doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
            flag = "Y";

            //  perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            // if ok then;            
            //    ws_doc_class_code = objDoc_mstr_rec.doc_class_code;
            // else
            //    ws_doc_class_code = "";

            if (flag.Equals(ok))
            {
                ws_doc_class_code = Util.Str(objDoc_mstr_rec.DOC_FULL_PART_IND);
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

            if (Sort_docrev_rec_Collection.Count() == 0)
            {
                objSort_docrev_rec = new Sort_docrev_rec();
            }
            else
            {
                if (sort_ctr >= Sort_docrev_rec_Collection.Count())
                {
                    ba0_99_exit();
                    return;
                }
                else
                {
                    objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                    sort_ctr++;

                }
            }

            //save_area = objSort_docrev_rec.wk_docrev_key;                
            objDocrev_master_rec.DOCREV_DEPT = 0;
            save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
            save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
            save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
            save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
            save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_cd) + Util.Str(objSort_docrev_rec.Wk_docrev_oma_suff);
            save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);  

            save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);


            //save_class_code = objSort_docrev_rec.wk_docrev_class_code;            
            save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

            //ws_hold_curr_class_code = objSort_docrev_rec.wk_docrev_class_code;            
            ws_hold_curr_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

            //     perform xi0-new-dept-head				thru xi0-99-exit.;
            xi0_new_dept_head();
            xi0_99_exit();

            //     perform xk0-new-class-head				thru xk0-99-exit.;
            xk0_new_class_head();
            xk0_99_exit();
        }

        private void ba0_10_process_records()
        {            

            // if wk-docrev-clinic-1-2 = ws-request-clinic-ident then;            
            // 	    if wk-docrev-dept = save-dept then;            
            // 	          if wk-docrev-class-code = save-class-code then;            
            // 		          if wk-docrev-doc-nbr = save-doc-nbr then;            
            // 		              if wk-docrev-location = save-location then;            
            // 			              if wk-docrev-oma-cd = save-oma then;            
            // 			                 next sentence;
            // 			              else;
            // 			                 perform ba2-oma-line	thru ba2-99-exit;
            // 		              else
            // 			             perform ba2-oma-line		thru ba2-99-exit;
            // 			             perform ba3-location-total	thru ba3-99-exit;
            // 			             perform ba4-location-header	thru ba4-99-exit;
            // 		          else;
            // 		              perform ba2-oma-line		thru ba2-99-exit;
            // 		              perform ba3-location-total		thru ba3-99-exit;
            // 		              perform ba5-doctor-total		thru ba5-99-exit;
            // 		              perform ba6-doctor-header		thru ba6-99-exit;
            // 		              perform ba4-location-header		thru ba4-99-exit;
            // 	        else;
            // 		        perform ba2-oma-line			thru ba2-99-exit;
            // 		        perform ba3-location-total		thru ba3-99-exit;
            // 		        perform ba5-doctor-total		thru ba5-99-exit;
            // 		        perform ba8-class-totals		thru ba8-99-exit;
            // 		        perform xk0-new-class-head		thru xk0-99-exit;
            //              flag_new_class = "Y";
            // 		        perform xd0-heading-lines		thru xd0-99-exit;
            //              flag_new_class = "N";
            // 	  else;
            // 	     perform ba2-oma-line			thru ba2-99-exit;
            // 	     perform ba3-location-total			thru ba3-99-exit;
            // 	     perform ba5-doctor-total			thru ba5-99-exit;
            // 	     perform ba8-class-totals			thru ba8-99-exit;
            //       level = 4;
            //       subs_dept_clinic = 1;
            // 	     perform ba7-dept-total			thru ba7-99-exit;
            // 	     perform xg0-clear-class-tbl			thru xg0-99-exit;
            // 		 varying subs from 1 by 1;
            // 		 until subs > const-nbr-classes;
            //       save_area = objSort_docrev_rec.wk_docrev_key;
            // 	     perform xi0-new-dept-head			thru xi0-99-exit;
            //       subs_class_code = 0;
            //       subs_max_nbr_classes = 0;            
            //       level = 3;
            // 	     perform xk0-new-class-head			thru xk0-99-exit;
            //       flag_new_class = "Y";
            // 	     perform xd0-heading-lines			thru xd0-99-exit;
            //       flag_new_class = "N";
            // else if wk-docrev-clinic-1-2 < ws-request-clinic-ident then;            
            // 	    go to ba0-10-process-records;
            // else;
            // 	    go to ba0-99-exit.;

            while (sort_ctr <= Sort_docrev_rec_Collection.Count())
            {

                if (objSort_docrev_rec.Wk_docrev_clinic_1_2 == ws_request_clinic_ident)
                {
                    if (objSort_docrev_rec.Wk_docrev_dept == save_dept)
                    {
                        if (objSort_docrev_rec.wk_docrev_class_code == save_class_code)
                        {
                            if (objSort_docrev_rec.Wk_docrev_doc_nbr == save_doc_nbr)
                            {
                                if (objSort_docrev_rec.Wk_docrev_location == save_location)
                                {
                                    if (Util.Str(objSort_docrev_rec.Wk_docrev_oma_cd + objSort_docrev_rec.Wk_docrev_oma_suff) == save_oma)
                                    {
                                        // 			                 next sentence;
                                    }
                                    else
                                    {
                                        // 			                 perform ba2-oma-line	thru ba2-99-exit;
                                        ba2_oma_line();
                                        ba2_99_exit();
                                    }
                                }
                                else
                                {
                                    // 			             perform ba2-oma-line		thru ba2-99-exit;
                                    ba2_oma_line();
                                    ba2_99_exit();

                                    // 			             perform ba3-location-total	thru ba3-99-exit;
                                    ba3_location_total();
                                    ba3_99_exit();

                                    // 			             perform ba4-location-header	thru ba4-99-exit;
                                    ba4_location_header();
                                    ba4_99_exit();
                                }
                            }
                            else
                            {
                                // 		              perform ba2-oma-line		thru ba2-99-exit;
                                ba2_oma_line();
                                ba2_99_exit();

                                // 		              perform ba3-location-total		thru ba3-99-exit;
                                ba3_location_total();
                                ba3_99_exit();

                                // 		              perform ba5-doctor-total		thru ba5-99-exit;
                                ba5_doctor_total();
                                ba5_99_exit();

                                // 		              perform ba6-doctor-header		thru ba6-99-exit;
                                ba6_doctor_header();
                                ba6_99_exit();
                                // 		              perform ba4-location-header		thru ba4-99-exit;
                                ba4_location_header();
                                ba4_99_exit();
                            }
                        }
                        else
                        {
                            // 		        perform ba2-oma-line			thru ba2-99-exit;
                            ba2_oma_line();
                            ba2_99_exit();
                            // 		        perform ba3-location-total		thru ba3-99-exit;
                            ba3_location_total();
                            ba3_99_exit();
                            // 		        perform ba5-doctor-total		thru ba5-99-exit;
                            ba5_doctor_total();
                            ba5_99_exit();
                            // 		        perform ba8-class-totals		thru ba8-99-exit;
                            ba8_class_totals();
                            ba8_99_exit();

                            // 		        perform xk0-new-class-head		thru xk0-99-exit;
                            xk0_new_class_head();
                            xk0_99_exit();
                            flag_new_class = "Y";
                            // 		        perform xd0-heading-lines		thru xd0-99-exit;
                            xd0_heading_lines();
                            xd0_99_exit();
                            flag_new_class = "N";
                        }
                    }
                    else
                    {
                        // 	     perform ba2-oma-line			thru ba2-99-exit;
                        ba2_oma_line();
                        ba2_99_exit();
                        // 	     perform ba3-location-total			thru ba3-99-exit;
                        ba3_location_total();
                        ba3_99_exit();

                        // 	     perform ba5-doctor-total			thru ba5-99-exit;
                        ba5_doctor_total();
                        ba5_99_exit();

                        // 	     perform ba8-class-totals			thru ba8-99-exit;
                        ba8_class_totals();
                        ba8_99_exit();

                        level = 4;
                        subs_dept_clinic = 1;
                        //  perform ba7-dept-total			thru ba7-99-exit;
                        ba7_dept_total();
                        ba7_10_check_code();
                        ba7_99_exit();

                        //  perform xg0-clear-class-tbl			thru xg0-99-exit;
                        // 		 varying subs from 1 by 1;
                        // 		 until subs > const-nbr-classes;

                        subs = 1;
                        do
                        {
                            xg0_clear_class_tbl();
                            xg0_99_exit();
                            subs++;
                        } while (subs <= objConstants_mstr_rec_4.CONST_NBR_CLASSES);

                        //save_area = objSort_docrev_rec.wk_docrev_key;                
                        objDocrev_master_rec.DOCREV_DEPT = 0;
                        save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                        save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                        save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                        save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                        save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_cd) + Util.Str(objSort_docrev_rec.Wk_docrev_oma_suff);
                        save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

                        save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);

                        // 	     perform xi0-new-dept-head			thru xi0-99-exit;
                        xi0_new_dept_head();
                        xi0_99_exit();

                        subs_class_code = 0;
                        subs_max_nbr_classes = 0;
                        level = 3;
                        // 	     perform xk0-new-class-head			thru xk0-99-exit;
                        xk0_new_class_head();
                        xk0_99_exit();

                        flag_new_class = "Y";
                        // 	     perform xd0-heading-lines			thru xd0-99-exit;
                        xd0_heading_lines();
                        xd0_99_exit();

                        flag_new_class = "N";
                    }
                }
                else if (objSort_docrev_rec.Wk_docrev_clinic_1_2.CompareTo(ws_request_clinic_ident) < 0)
                {
                    sort_ctr++;
                    continue;
                }
                else
                {
                    // 	    go to ba0-99-exit.;
                    ba0_99_exit();
                    break;
                }


                //  perform ba1-add-to-areas				thru ba1-99-exit.;
                ba1_add_to_areas();
                ba1_99_exit();

                //save_area = objSort_docrev_rec.wk_docrev_key;                
                objDocrev_master_rec.DOCREV_DEPT = 0;
                save_clinic_1_2 = Util.NumInt(objSort_docrev_rec.Wk_docrev_clinic_1_2);
                save_dept = Util.NumInt(objSort_docrev_rec.Wk_docrev_dept);
                save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                save_oma = Util.Str(objSort_docrev_rec.Wk_docrev_oma_cd) + Util.Str(objSort_docrev_rec.Wk_docrev_oma_suff);
                save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

                save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma) + Util.Str(save_class_code);

                //save_class_code = objSort_docrev_rec.wk_docrev_class_code;            
                save_class_code = Util.Str(objSort_docrev_rec.wk_docrev_class_code);

                //   return sort-docrev-file;
                // 	     at end;
                // 	     go to ba0-99-exit.;

                if (Sort_docrev_rec_Collection.Count() == 0)
                {
                    objSort_docrev_rec = new Sort_docrev_rec();
                    break;
                }
                else
                {
                    if (sort_ctr >= Sort_docrev_rec_Collection.Count())
                    {
                        ba0_99_exit();
                        break;
                    }
                    else
                    {

                        objSort_docrev_rec = Sort_docrev_rec_Collection[sort_ctr];
                        sort_ctr++;
                    }
                }

                ws_hold_curr_class_code = objSort_docrev_rec.wk_docrev_class_code;

                //     go to ba0-10-process-records.;
            }
        }
        private void ba0_99_exit()
        {            
        }
        private void ba1_add_to_areas()
        {         

            if (Util.Str(objSort_docrev_rec.Wk_docrev_location).ToUpper() != "MISC")
            {

                // 	add wk-docrev-mtd-in-rec	to	mtd-in-rec	(1);
                // 						ws-mtd-in-rec	(subs-dept-clinic,subs-class-code);

                mtd_in_rec[1] = mtd_in_rec[1] + objSort_docrev_rec.Wk_docrev_mtd_in_rec;
                ws_mtd_in_rec[subs_dept_clinic, subs_class_code] = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_in_rec;

                // 	add wk-docrev-mtd-in-svc	to	mtd-in-svc 	(1);
                // 						ws-mtd-in-svc	(subs-dept-clinic,subs-class-code);

                mtd_in_svc[1] = mtd_in_svc[1] + objSort_docrev_rec.Wk_docrev_mtd_in_svc;
                ws_mtd_in_svc[subs_dept_clinic, subs_class_code] = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_in_svc;

                // 	add wk-docrev-mtd-out-rec	to	mtd-out-rec	(1);
                // 						ws-mtd-out-rec	(subs-dept-clinic,subs-class-code);

                mtd_out_rec[1] = mtd_out_rec[1] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                ws_mtd_out_rec[subs_dept_clinic, subs_class_code] = ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;

                // 	add wk-docrev-mtd-out-svc	to	mtd-out-svc	(1);
                // 						ws-mtd-out-svc	(subs-dept-clinic,subs-class-code);

                mtd_out_svc[1] = mtd_out_svc[1] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                ws_mtd_out_svc[subs_dept_clinic, subs_class_code] = ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;

                // 	add wk-docrev-ytd-in-rec	to	ytd-in-rec	(1);
                // 						ws-ytd-in-rec	(subs-dept-clinic,subs-class-code);

                ytd_in_rec[1] = ytd_in_rec[1] + objSort_docrev_rec.Wk_docrev_ytd_in_rec;
                ws_ytd_in_rec[subs_dept_clinic, subs_class_code] = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_in_rec;

                // 	add wk-docrev-ytd-in-svc	to	ytd-in-svc	(1);
                // 						ws-ytd-in-svc	(subs-dept-clinic,subs-class-code);

                ytd_in_svc[1] = ytd_in_svc[1] + objSort_docrev_rec.Wk_docrev_ytd_in_svc;
                ws_ytd_in_svc[subs_dept_clinic, subs_class_code] = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_in_svc;

                // 	add wk-docrev-ytd-out-rec	to	ytd-out-rec	(1);
                // 						ws-ytd-out-rec	(subs-dept-clinic,subs-class-code);

                ytd_out_rec[1] = ytd_out_rec[1] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                ws_ytd_out_rec[subs_dept_clinic, subs_class_code] = ws_ytd_out_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;

                // 	add wk-docrev-ytd-out-svc	to	ytd-out-svc	(1);
                // 						ws-ytd-out-svc	(subs-dept-clinic,subs-class-code);

                ytd_out_svc[1] = ytd_out_svc[1] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
                ws_ytd_out_svc[subs_dept_clinic, subs_class_code] = ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
            else
            {
                // 	add wk-docrev-mtd-out-rec	to	mtd-misc-rec	(1);
                // 						ws-mtd-misc-rec	(subs-dept-clinic,subs-class-code);

                mtd_misc_rec[1] = mtd_misc_rec[1] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;
                ws_mtd_misc_rec[subs_dept_clinic, subs_class_code] = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_rec;

                // 	add wk-docrev-mtd-out-svc	to	mtd-misc-svc	(1);
                // 						ws-mtd-misc-svc	(subs-dept-clinic,subs-class-code);

                mtd_misc_svc[1] = mtd_misc_svc[1] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;
                ws_mtd_misc_svc[subs_dept_clinic, subs_class_code] = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_mtd_out_svc;

                // 	add wk-docrev-ytd-out-rec	to	ytd-misc-rec	(1);
                // 						ws-ytd-misc-rec	(subs-dept-clinic,subs-class-code);

                ytd_misc_rec[1] = ytd_misc_rec[1] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;
                ws_ytd_misc_rec[subs_dept_clinic, subs_class_code] = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_rec;

                // 	add wk-docrev-ytd-out-svc	to	ytd-misc-svc	(1);
                // 						ws-ytd-misc-svc	(subs-dept-clinic,subs-class-code).;

                ytd_misc_svc[1] = ytd_misc_svc[1] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
                ws_ytd_misc_svc[subs_dept_clinic, subs_class_code] = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code] + objSort_docrev_rec.Wk_docrev_ytd_out_svc;
            }
        }

        private void ba1_99_exit()
        {            
        }
        private void ba2_oma_line()
        {         

            d1_oma_code_or_lit = save_oma;
            x_from = 1;
            //  perform xa0-move-totals		thru	xa0-99-exit.;
            xa0_move_totals();
            xa0_99_exit();

            // perform xb0-print-line		thru	xb0-99-exit.;
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
            //     exit.;
        }

        private void ba3_location_total()
        {            

            d1_oma_code_or_lit = "*LOC*";
            x_from = 2;
            //  perform xa0-move-totals		thru	xa0-99-exit.;
            xa0_move_totals();
            xa0_99_exit();

            //  perform xb0-print-line		thru	xb0-99-exit.;
            xb0_print_line();
            xb0_99_exit();

            x_from = 2;
            x_to = 3;
            // perform xc0-bump-totals		thru	xc0-99-exit.;
            xc0_bump_totals();
            xc0_99_exit();
        }

        private void ba3_99_exit()
        {            
            //     exit.;
        }

        private void ba4_location_header()
        {            

            objLoc_mstr_rec.LOC_NBR = objSort_docrev_rec.Wk_docrev_location;
            h8_loc = objSort_docrev_rec.Wk_docrev_location;
            locationKey = objSort_docrev_rec.Wk_docrev_location;
            //     perform ra1-read-loc-mstr		thru	ra1-99-exit.;
            ra1_read_loc_mstr();
            ra1_99_exit();

            h8_loc_lit = "LOCATION";

            h8_loc_name = objLoc_mstr_rec.LOC_NAME;

            //     add 3				to	line-cnt.;
            line_cnt = line_cnt + 3;

            // if line-cnt > max-nbr-lines then;            
            //    save_doc_nbr = objSort_docrev_rec.wk_docrev_doc_nbr;
            //    save_location = objSort_docrev_rec.wk_docrev_location;
            // 	   perform xd0-heading-lines	thru	xd0-99-exit;
            //  else;
            //    subtract 1			from	line-cnt;
            // 	  write prt-line from head-line-8 after	advancing 2 lines.;

            if (line_cnt > max_nbr_lines)
            {
                save_doc_nbr = objSort_docrev_rec.Wk_docrev_doc_nbr;
                save_location = objSort_docrev_rec.Wk_docrev_location;
                //perform xd0-heading - lines   thru xd0-99 - exit;
                xd0_heading_lines();
                xd0_99_exit();
            }
            else
            {
                line_cnt--;

                //write prt-line from head-line - 8 after advancing 2 lines.;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_8_grp(), 1, true);
            }
        }

        private void ba4_99_exit()
        {            

            //     exit.;
        }
        private void ba5_doctor_total()
        {            

            d1_oma_code_or_lit = "*DOC*";
            x_from = 3;
            //  perform xa0-move-totals		thru	xa0-99-exit.;
            xa0_move_totals();
            xa0_99_exit();

            // perform xb0-print-line		thru	xb0-99-exit.;
            xb0_print_line();
            xb0_99_exit();

            x_from = 3;
            x_to = 4;
            //     perform xc0-bump-totals		thru	xc0-99-exit.;
            xc0_bump_totals();
            xc0_99_exit();
        }

        private void ba5_99_exit()
        {            

            //     exit.;
        }

        private void ba6_doctor_header()
        {            

            objDoc_mstr_rec.DOC_NBR = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
            doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);

            h7_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);

            // perform ra2-read-doc-mstr		thru	ra2-99-exit.;
            ra2_read_doc_mstr();
            ra2_99_exit();

            h7_doc_lit = "DOC #";

            //  perform ba61-doc-name-inits		thru	ba61-99-exit.;
            ba61_doc_name_inits();
            ba61_99_exit();

            h7_doc_name_inits = ws_doc_name_inits;

            //     add 5				to	line-cnt.;
            line_cnt = line_cnt + 5;

            // if line-cnt > max-nbr-lines then;            
            //    save_doc_nbr = objSort_docrev_rec.wk_docrev_doc_nbr;
            //     save_location = objSort_docrev_rec.wk_docrev_location;
            // 	   perform xd0-heading-lines	thru	xd0-99-exit;
            // else;
            //     subtract 2			from	line-cnt;
            // 	   write prt-line from head-line-7	after	advancing 3 lines.;

            if (line_cnt > max_nbr_lines)
            {
                save_doc_nbr = Util.Str(objSort_docrev_rec.Wk_docrev_doc_nbr);
                save_location = Util.Str(objSort_docrev_rec.Wk_docrev_location);
                // 	   perform xd0-heading-lines	thru	xd0-99-exit;
                xd0_heading_lines();
                xd0_99_exit();
            }
            else
            {
                //     subtract 2			from	line-cnt;
                line_cnt = line_cnt - 2;
                // 	   write prt-line from head-line-7	after	advancing 3 lines.;                
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(head_line_7_grp(), 1, true);
            }
        }

        private void ba6_99_exit()
        {            
            //     exit.;
        }

        private void ba61_doc_name_inits()
        {            
            ws_doc_name_inits = "";
            if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT3))
            {
                // 	    string doc-name			delimited by ws-xx,;
                // 	       " "			delimited by size,;
                // 	       doc-init1		delimited by size,;
                // 	       "."			delimited by size,;
                // 	       doc-init2		delimited by size,;
                // 	       "."			delimited by size,;
                // 	       doc-init3		delimited by size,;
                // 	       "."			delimited by size,;
                // 					into	ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + ws_xx + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT2) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT3) + ".";
            }
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT2))
            {
                // 	    string doc-name		delimited by ws-xx,;
                // 	    " "				delimited by size,;
                // 	    doc-init1			delimited by size,;
                // 	    "."				delimited by size,;
                // 	    doc-init2			delimited by size,;
                // 	    "."				delimited by size,;
                // 					into	ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + ws_xx + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + "." + Util.Str(objDoc_mstr_rec.DOC_INIT2) + ".";
            }
            else if (!string.IsNullOrWhiteSpace(objDoc_mstr_rec.DOC_INIT1))
            {
                // 		string doc-name		delimited by ws-xx,;
                // 		" "			delimited by size,;
                // 		doc-init1		delimited by size,;
                // 		"."			delimited by size,;
                // 					into	ws-doc-name-inits;

                ws_doc_name_inits = Util.Str(objDoc_mstr_rec.DOC_NAME) + ws_xx + " " + Util.Str(objDoc_mstr_rec.DOC_INIT1) + ".";
            }
            else
            {
                ws_doc_name_inits = objDoc_mstr_rec.DOC_NAME;
            }
        }

        private void ba61_99_exit()
        {            
            //     exit.;
        }
        private void ba7_dept_total()
        {         

            //     perform xd0-heading-lines		thru	xd0-99-exit.;
            xd0_heading_lines();
            xd0_99_exit();

            subs_class_code = 1;
        }
        private void ba7_10_check_code()
        {         

            if (subs_class_code > subs_max_nbr_classes)
            {
                // 	   next sentence;
            }
            else
            {
                //    	perform xm0-print-totals	thru	xm0-99-exit;
                xm0_print_totals();
                xm0_99_exit();
                // 	    add 1				to	subs-class-code;
                subs_class_code++;
                // 	    go to ba7-10-check-code.;
                ba7_10_check_code();
                return;
            }

            t1_in_svc = mtd_in_svc[level];
            t1_in_rec = mtd_in_rec[level];
            t1_out_svc = mtd_out_svc[level];
            t1_out_rec = mtd_out_rec[level];

            t1_misc_svc = mtd_misc_svc[level];
            t1_misc_rec = mtd_misc_rec[level];

            //     add mtd-in-svc (level) mtd-out-svc (level) mtd-misc-svc (level);
            // 					giving	total-svc.;

            total_svc = mtd_in_svc[level] + mtd_out_svc[level] + mtd_misc_svc[level];

            //     add mtd-in-rec (level) mtd-out-rec (level) mtd-misc-rec (level);
            // 					giving	total-rec.;

            total_rec = mtd_in_rec[level] + mtd_out_rec[level] + mtd_misc_rec[level];

            t1_tot_svc = total_svc;
            t1_tot_rec = total_rec;

            if (level == 4)
            {
                t1_total_lit_grp = "**DEPARTMENT TOTALS**";
            }
            else
            {
                t1_total_lit_grp = "* CLINIC GRAND TOTALS *";
            }

            t1_mth_yr = "MONTH";

            //     write prt-line from total-line-1	after	advancing 2 lines.;

            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);

            t1_in_svc = ytd_in_svc[level];
            t1_in_rec = ytd_in_rec[level];
            t1_out_svc = ytd_out_svc[level];
            t1_out_rec = ytd_out_rec[level];

            t1_misc_svc = ytd_misc_svc[level];
            t1_misc_rec = ytd_misc_rec[level];

            //     add ytd-in-svc (level) ytd-out-svc (level) ytd-misc-svc (level);
            // 					giving	total-svc.;

            total_svc = ytd_in_svc[level] + ytd_out_svc[level] + ytd_misc_svc[level];

            //     add ytd-in-rec (level) ytd-out-rec (level) ytd-misc-rec (level);
            // 					giving	total-rec.;

            total_rec = ytd_in_rec[level] + ytd_out_rec[level] + ytd_misc_rec[level];

            t1_tot_svc = total_svc;
            t1_tot_rec = total_rec;

            t1_total_lit_grp = "";
            t1_class_lit = "";
            t1_class = "";
            t1_totals_lit = "";
            t1_total_lit_grp = string.Empty;

            t1_mth_yr = " YEAR";

            //     write prt-line from total-line-1	after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);

            if (level == 4)
            {
                x_from = 4;
                x_to = 5;
                // 	perform xc0-bump-totals		thru	xc0-99-exit.;
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

            //  perform ba82-display-totals			thru ba82-99-exit.;
            ba82_display_totals();
            ba82_99_exit();

            //  perform ba83-bump-totals			thru ba83-99-exit.;
            ba83_bump_totals();
            ba83_10_check_class();
            ba83_99_exit();
        }
        private void ba8_99_exit()
        {            
            //     exit.;
        }

        private void ba82_display_totals()
        {            

            t1_in_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            t1_in_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            t1_out_svc = ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            t1_out_rec = ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            t1_misc_svc = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_misc_rec = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-in-svc   (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-svc  (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-svc (subs-dept-clinic,subs-class-code);
            // 						giving total-svc.;

            total_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_tot_svc = total_svc;

            //     add ws-mtd-in-rec   (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-rec  (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-rec (subs-dept-clinic,subs-class-code);
            // 						giving total-rec.;

            total_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_tot_rec = total_rec;
            //move '** CLASS -'               to t1-class-lit.
            t1_class_lit = "** CLASS -";

            t1_class = ws_class_code[subs_dept_clinic, subs_class_code];

            //move '- TOTALS **'              to t1-totals - lit.
            t1_totals_lit = "- TOTALS **";
            t1_mth_yr = "MONTH";

            //     write prt-line from total-head-line-1	after	advancing 3 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(true);
            objPrint_File.print(total_head_line_1_grp(), 1, true);

            //     write prt-line from total-line-1		after	advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);

            t1_total_lit_grp = "";
            t1_class_lit = "";
            t1_class = "";
            t1_totals_lit = "";

            t1_total_lit_grp = ws_class_code_desc[subs_dept_clinic, subs_class_code];

            t1_mth_yr = " YEAR";
            t1_in_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            t1_in_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            t1_out_svc = ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            t1_out_rec = ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            t1_misc_svc = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_misc_rec = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-svc(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-svc(subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-svc(subs-dept-clinic,subs-class-code);
            // 						giving total-svc.;

            total_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_tot_svc = total_svc;

            //     add ws-ytd-in-rec  (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-rec (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-rec(subs-dept-clinic,subs-class-code);
            // 						giving total-rec.;

            total_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code]  + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code]  ;

            t1_tot_rec = total_rec;

            //     write prt-line from total-line-1		after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);
        }

        private void ba82_99_exit()
        {            
            //     exit.;
        }
        private void ba83_bump_totals()
        {            
            subs = 1;
        }
        private void ba83_10_check_class()
        {            

            // if ws-class-code(subs-dept-clinic,subs-class-code) = ws-class-code(2,subs) then;            
            // 	   next sentence;
            //  else if ws-class-code(2,subs) = spaces then;            
            // 	    add 1			to	subs-max-nbr-classes-clinic;
            // 	else;
            // 	    add 1			to	subs;
            // 	    if subs > const-nbr-classes then;            
            //          err_ind = 6;
            // 		    perform za0-common-error;
            // 					thru	za0-99-exit;
            // 		     go to az0-finalization;
            // 	    else;
            // 		     go to ba83-10-check-class.;

            if (ws_class_code[subs_dept_clinic, subs_class_code] == ws_class_code[2, subs])
            {
                // next sentence
            }
            else if (string.IsNullOrWhiteSpace(ws_class_code[2, subs]))
            {
                // 	    add 1			to	subs-max-nbr-classes-clinic;
                subs_max_nbr_classes_clinic++;
            }
            else
            {
                subs++;
                if (subs > objConstants_mstr_rec_4.CONST_NBR_CLASSES)
                {
                    err_ind = 6;
                    //    perform za0-common-error thru	za0-99-exit;                    
                    // 		     go to az0-finalization;
                    za0_common_error();
                    za0_99_exit();
                    az0_finalization();
                    return;
                }
                else
                {
                    ba83_10_check_class();
                    return;
                }
            }

            //     add ws-mtd-in-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-in-rec(2,subs).; 
            ws_mtd_in_rec[2, subs] = ws_mtd_in_rec[2, subs] + ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-in-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-in-svc(2,subs).;
            ws_mtd_in_svc[2, subs] = ws_mtd_in_svc[2, subs] + ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-out-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-out-rec(2,subs).;
            ws_mtd_out_rec[2, subs] = ws_mtd_out_rec[2, subs] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-out-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-out-svc(2,subs).;
            ws_mtd_out_svc[2, subs] = ws_mtd_out_svc[2, subs] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-misc-rec(subs-dept-clinic,subs-class-code);
            //   					to	ws-mtd-misc-rec(2,subs).;

            ws_mtd_misc_rec[2, subs] = ws_mtd_misc_rec[2, subs] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-mtd-misc-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-mtd-misc-svc(2,subs).;

            ws_mtd_misc_svc[2, subs] = ws_mtd_misc_svc[2, subs] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-in-rec(2,subs).;

            ws_ytd_in_rec[2, subs] = ws_ytd_in_rec[2, subs] + ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-in-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-in-svc(2,subs).;

            ws_ytd_in_svc[2, subs] = ws_ytd_in_svc[2, subs] + ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-out-rec(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-out-rec(2,subs).;

            ws_ytd_out_rec[2, subs] = ws_ytd_out_rec[2, subs] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-out-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-out-svc(2,subs).;

            ws_ytd_out_svc[2, subs] = ws_ytd_out_svc[2, subs] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-misc-rec(subs-dept-clinic,subs-class-code);
            //   					to	ws-ytd-misc-rec(2,subs).;

            ws_ytd_misc_rec[2, subs] = ws_ytd_misc_rec[2, subs] + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            //     add ws-ytd-misc-svc(subs-dept-clinic,subs-class-code);
            // 					to	ws-ytd-misc-svc(2,subs).;

            ws_ytd_misc_svc[2, subs] = ws_ytd_misc_svc[2, subs] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            ws_class_code[2, subs] = ws_class_code[subs_dept_clinic, subs_class_code];

            ws_class_code_desc[2, subs] = ws_class_code_desc[subs_dept_clinic, subs_class_code];

        }

        private void ba83_99_exit()
        {            
            //     exit.;
        }
        private void ra0_read_next_docrev()
        {            

            //save_area = objDocrev_master_rec.docrev_key;            
            save_clinic_1_2 = Util.NumInt(objDocrev_master_rec.DOCREV_CLINIC_1_2);
            save_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);
            save_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
            save_location = Util.Str(objDocrev_master_rec.DOCREV_LOCATION);
            save_oma = Util.Str(objDocrev_master_rec.DOCREV_OMA_CODE) + Util.Str(objDocrev_master_rec.DOCREV_OMA_SUFF);
            save_class_code = "";

            save_area_grp = Util.Str(save_clinic_1_2) + Util.Str(save_dept) + Util.Str(save_doc_nbr) + Util.Str(save_location) + Util.Str(save_oma); // + Util.Str(save_class_code);

        }

        private void ra0_10_read_docrev()
        {            

            //  read docrev-mstr next;
            //         at end;
            //         objDocrev_master_rec.docrev_clinic_1_2 = high_values;
            // 	        go to ra0-99-exit.;

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

            // if docrev-clinic-1-2 not = ws-request-clinic-ident then;            
            //      objDocrev_master_rec.docrev_clinic_1_2 = high_values;
            //   	go to ra0-99-exit.;

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

        private void ra1_read_loc_mstr()
        {            

            flag = "Y";

            //  read loc-mstr;
            //     	     invalid key;
            //           flag = "N";
            //           objLoc_mstr_rec.loc_name = "INVALID LOCATION";
            // 	         go to ra1-99-exit.;

            Loc_mstr_rec_Collection = new F030_LOCATIONS_MSTR
            {
                WhereLoc_nbr = locationKey
            }.Collection();

            if (Loc_mstr_rec_Collection.Count() == 0)
            {
                flag = "N";
                objLoc_mstr_rec.LOC_NAME = "INVALID LOCATION";
                // 	         go to ra1-99-exit.;
                ra1_99_exit();
                return;
            }
            else
            {
                objLoc_mstr_rec = Loc_mstr_rec_Collection.FirstOrDefault();
            }

            //     add 1				to	loc-mstr-read.;
            loc_mstr_read++;
        }
        private void ra1_99_exit()
        {            
            //     exit.;
        }

        private void ra2_read_doc_mstr()
        {         

            flag = "Y";
            //  read doc-mstr;
            // 	      invalid key;
            //        flag = "N";
            //         objDoc_mstr_rec.doc_name = "INVALID DOCTOR";
            // 	       go to ra2-99-exit.;

            Doc_mstr_rec_Collection = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = objSort_docrev_rec.Wk_docrev_doc_nbr
            }.Collection();

            if (Doc_mstr_rec_Collection.Count() == 0)
            {
                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                flag = "N";
                objDoc_mstr_rec.DOC_NAME = "INVALID DOCTOR";
                ra2_99_exit();
                return;
            }

            objDoc_mstr_rec = Doc_mstr_rec_Collection.FirstOrDefault();

            //     add 1				to	doc-mstr-read.;
            doc_mstr_read++;
        }
        private void ra2_99_exit()
        {            
            //     exit.;
        }

        private void ra3_read_docrev_approx()
        {         

            // start docrev-mstr key is greater than or equal to docrev-key;
            // 	invalid key;
            //      err_ind = 3;
            // 	    perform za0-common-error	thru	za0-99-exit;
            // 	    go to az0-finalization.;

            //      read docrev-mstr next.;

            Docrev_master_rec_Collection = new F050_DOC_REVENUE_MSTR
            {
                WhereDocrev_clinic_1_2 = ws_request_clinic_ident
            }.Collection();

            if (Docrev_master_rec_Collection.Count() == 0)
            {
                objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                err_ind = 3;
                // 	    perform za0-common-error	thru	za0-99-exit;
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
                    objDocrev_master_rec = Docrev_master_rec_Collection[docrev_read];
                    docrev_read++;
                }
            }
        }

        private void ra3_99_exit()
        {            
            //     exit.;
        }

        private void xa0_move_totals()
        {            

            d1_mtd_in_rec = mtd_in_rec[x_from];
            d1_mtd_in_svc = mtd_in_svc[x_from];
            d1_mtd_out_rec = mtd_out_rec[x_from];
            d1_mtd_out_svc = mtd_out_svc[x_from];
            d1_mtd_misc_rec = mtd_misc_rec[x_from];
            d1_mtd_misc_svc = mtd_misc_svc[x_from];
            d1_ytd_in_rec = ytd_in_rec[x_from];
            d1_ytd_in_svc = ytd_in_svc[x_from];
            d1_ytd_out_rec = ytd_out_rec[x_from];
            d1_ytd_out_svc = ytd_out_svc[x_from];
            d1_ytd_misc_rec = ytd_misc_rec[x_from];
            d1_ytd_misc_svc = ytd_misc_svc[x_from];

            //  add mtd-in-rec   (x-from);
            // 	mtd-out-rec  (x-from);
            // 	mtd-misc-rec (x-from)		giving	total-mtd-rec.;

            total_mtd_rec = mtd_in_rec[x_from] + mtd_out_rec[x_from] + mtd_misc_rec[x_from];

            //  add mtd-in-svc   (x-from);
            // 	mtd-out-svc  (x-from);
            // 	mtd-misc-svc (x-from)		giving	total-mtd-svc.;

            total_mtd_svc = mtd_in_svc[x_from] + mtd_out_svc[x_from] + mtd_misc_svc[x_from];

            //  add ytd-in-rec   (x-from);
            // 	ytd-out-rec  (x-from);
            // 	ytd-misc-rec (x-from)		giving	total-ytd-rec.;

            total_ytd_rec = ytd_in_rec[x_from] + ytd_out_rec[x_from] + ytd_misc_rec[x_from];

            //  add ytd-in-svc   (x-from);
            // 	ytd-out-svc  (x-from);
            // 	ytd-misc-svc (x-from)		giving	total-ytd-svc.;

            total_ytd_svc = ytd_in_svc[x_from] + ytd_out_svc[x_from] + ytd_misc_svc[x_from];

            d1_mtd_tot_rec = total_mtd_rec;
            d1_mtd_tot_svc = total_mtd_svc;
            d1_ytd_tot_rec = total_ytd_rec;
            d1_ytd_tot_svc = total_ytd_svc;
        }
        private void xa0_99_exit()
        {            
            //     exit.;
        }
        private void xb0_print_line()
        {         

            //     add 1				to	line-cnt.;
            line_cnt++;

            // if line-cnt > max-nbr-lines then;            
            // 	   perform xd0-heading-lines	thru	xd0-99-exit.;

            if (line_cnt > max_nbr_lines)
            {
                xd0_heading_lines();
                xd0_99_exit();
            }
            //     write prt-line from detail-line-1	after	advancing 1 line.;            
            objPrint_File.print(detail_line_1_grp(), 1, true);

        }
        private void xb0_99_exit()
        {            
            //     exit.;
        }
        private void xc0_bump_totals()
        {         

            //     add mtd-in-rec   (x-from)		to	mtd-in-rec   (x-to);
            mtd_in_rec[x_to] += mtd_in_rec[x_from];
            //     add mtd-in-svc   (x-from)		to	mtd-in-svc   (x-to);
            mtd_in_svc[x_to] += mtd_in_svc[x_from];
            //     add mtd-out-rec  (x-from)		to	mtd-out-rec  (x-to);
            mtd_out_rec[x_to] += mtd_out_rec[x_from];
            //     add mtd-out-svc  (x-from)		to	mtd-out-svc  (x-to);
            mtd_out_svc[x_to] += mtd_out_svc[x_from];
            //     add mtd-misc-rec (x-from)		to	mtd-misc-rec (x-to);
            mtd_misc_rec[x_to] += mtd_misc_rec[x_from];
            //     add mtd-misc-svc (x-from)		to	mtd-misc-svc (x-to);
            mtd_misc_svc[x_to] += mtd_misc_svc[x_from];
            //     add ytd-in-rec   (x-from)		to	ytd-in-rec   (x-to);
            ytd_in_rec[x_to] += ytd_in_rec[x_from];
            //     add ytd-in-svc   (x-from)		to	ytd-in-svc   (x-to);
            ytd_in_svc[x_to] += ytd_in_svc[x_from];
            //     add ytd-out-rec  (x-from)		to	ytd-out-rec  (x-to);
            ytd_out_rec[x_to] += ytd_out_rec[x_from];
            //     add ytd-out-svc  (x-from)		to	ytd-out-svc  (x-to);
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
            //     exit.;
        }
        private void xd0_heading_lines()
        {         

            //  add 1				to	page-cnt.;
            page_cnt++;

            //  h1_page = page_cnt;
            h1_page = page_cnt;

            //  write prt-line from head-line-1	after	advancing page.;            
            objPrint_File.PageBreak();
            objPrint_File.print(head_line_1_grp(), 1, true);

            //  write prt-line from head-line-2	after	advancing 1 line.;            
            objPrint_File.print(head_line_2_grp(), 1, true);

            if (level == 3)
            {
                // 	  write prt-line from head-line-3	after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_3_grp(), 1, true);

                // 	  write prt-line from head-line-4	after	advancing 1 line;                
                objPrint_File.print(head_line_4_grp(), 1, true);

                // 	  write prt-line from head-line-5	after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_5_grp(), 1, true);

                // 	  write prt-line from head-line-6	after	advancing 1 line;                
                objPrint_File.print(head_line_6_grp(), 1, true);

                // 	  perform xd1-select-headings	thru 	xd1-99-exit;
                xd1_select_headings();
                xd1_99_exit();

                // 	  perform ra2-read-doc-mstr	thru	ra2-99-exit;
                ra2_read_doc_mstr();
                ra2_99_exit();

                h7_doc_lit = "DOC #";
                // 	  perform ba61-doc-name-inits	thru	ba61-99-exit;
                ba61_doc_name_inits();
                ba61_99_exit();
                h7_doc_name_inits = ws_doc_name_inits;

                // 	  write prt-line from head-line-7	after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_7_grp(), 1, true);

                locationKey = h8_loc; 
                // 	  perform ra1-read-loc-mstr	thru	ra1-99-exit;
                ra1_read_loc_mstr();
                ra1_99_exit();

                h8_loc_lit = "LOCATION";
                h8_loc_name = objLoc_mstr_rec.LOC_NAME;
                // 	  write prt-line from head-line-8 after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(head_line_8_grp(), 1, true);
            }
            else if (level == 4)
            {
                // 	    write prt-line from head-line-3 after	advancing 2 lines;                    
                objPrint_File.print(true);
                objPrint_File.print(head_line_3_grp(), 1, true);

                // 		move 'DEPARTMENT CLASS TOTALS'	to	h9-dept-clinic-tot;
                h9_dept_clinic_tot = "DEPARTMENT CLASS TOTALS";

                // 	    write prt-line from head-line-9 after	advancing 3 lines;                
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(head_line_9_grp(), 1, true);

                // 	    write prt-line from total-head-line-1 after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(total_head_line_1_grp(), 1, true);
            }
            else if (level == 5)
            {
                // 		move 'CLINIC CLASS TOTALS'	to	h9-dept-clinic-tot;
                h9_dept_clinic_tot = "CLINIC CLASS TOTALS";

                // 		write prt-line from head-line-9 after	advancing 3 lines;                
                objPrint_File.print(true);
                objPrint_File.print(true);
                objPrint_File.print(head_line_9_grp(), 1, true);

                // 		write prt-line from total-head-line-1 after	advancing 2 lines;                
                objPrint_File.print(true);
                objPrint_File.print(total_head_line_1_grp(), 1, true);
            }
            else
            {
                err_ind = 5;
                // perform za0-common-error thru	za0-99-exit.;
                za0_common_error();
                za0_99_exit();
            }

            line_cnt = 13;
        }
        private void xd0_99_exit()
        {            

            //     exit.;
        }
        private void xd1_select_headings()
        {            

            if (Util.Str(flag_new_class).ToUpper() == new_class)
            {
                objDoc_mstr_rec.DOC_NBR = objSort_docrev_rec.Wk_docrev_doc_nbr;
                h7_doc_nbr = objSort_docrev_rec.Wk_docrev_doc_nbr;

                objLoc_mstr_rec.LOC_NBR = objSort_docrev_rec.Wk_docrev_location;
                h8_loc = objSort_docrev_rec.Wk_docrev_location;                
            }
            else
            {
                objDoc_mstr_rec.DOC_NBR = save_doc_nbr;
                h7_doc_nbr = save_doc_nbr;

                objLoc_mstr_rec.LOC_NBR = save_location;
                h8_loc = save_location;
            }
        }
        private void xd1_99_exit()
        {            

            // 	exit.;
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

            h4_class_code = ws_hold_curr_class_code;

            //     perform xe0-access-const-for-desc	thru xe0-99-exit.;
            xe0_access_const_for_desc();
            xe0_10_get_desc();
            xe0_99_exit();
        }
        private void xk0_99_exit()
        {            
            //     exit.;
        }
        private void xe0_access_const_for_desc()
        {            

            subs = 1;
            //     add 1				to subs-class-code;
            // 					   subs-max-nbr-classes.;

            subs_class_code++;
            subs_max_nbr_classes++;
        }

        private void xe0_10_get_desc()
        {            

            // if ws-hold-curr-class-code = const-class-ltr(subs) then;            
            //    h4_class_code_desc = const_class_desc[subs];
            //    ws_class_code_desc[subs_dept_clinic,subs_class_code] = const_class_desc[subs];

            // else if subs < const-nbr-classes then;            
            // 	    add 1			to subs;
            // 	    go to xe0-10-get-desc;
            // 	else;
            //      move 'UNKNOWN DESC'     to h4-class-code-desc
            // 	    ws-class-code-desc(subs-dept-clinic,subs-class-code).;

            if (ws_hold_curr_class_code == CONST_CLASS_LTR(objConstants_mstr_rec_4, subs))
            {
                h4_class_code_desc = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = CONST_CLASS_DESC(objConstants_mstr_rec_4, subs);
            }
            else if (subs < objConstants_mstr_rec_4.CONST_NBR_CLASSES)
            {
                // 	    add 1			to subs;
                subs++;
                // 	    go to xe0-10-get-desc;
                xe0_10_get_desc();
                return;
            }
            else
            {
                //      move 'UNKNOWN DESC'     to h4-class-code-desc
                h4_class_code_desc = "UNKNOWN DESC";
                ws_class_code_desc[subs_dept_clinic, subs_class_code] = "UNKNOWN DESC";
            }
            ws_class_code[subs_dept_clinic, subs_class_code] = ws_hold_curr_class_code;
        }

        private void xe0_99_exit()
        {            

            //     exit.;
        }

        private void xi0_new_dept_head()
        {            

            h3_department = objSort_docrev_rec.Wk_docrev_dept;
            objDept_mstr_rec.DEPT_NBR = objSort_docrev_rec.Wk_docrev_dept;

            // read dept-mstr;
            //      	invalid key;
            //          err_ind = 4;
            // 	        perform za0-common-error	thru za0-99-exit;
            //           objDept_mstr_rec.dept_name = "'UNKNOWN DEPT'";

            Dept_mstr_rec_Collection = new F070_DEPT_MSTR
            {
                WhereDept_nbr = objSort_docrev_rec.Wk_docrev_dept
            }.Collection();

            if (Dept_mstr_rec_Collection.Count() == 0)
            {
                objDept_mstr_rec = new F070_DEPT_MSTR();
                err_ind = 4;
                //  perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                objDept_mstr_rec.DEPT_NAME = "'UNKNOWN DEPT'";
            }
            else
            {
                objDept_mstr_rec = Dept_mstr_rec_Collection.FirstOrDefault();
            }

            h3_dept_name = objDept_mstr_rec.DEPT_NAME;
        }

        private void xi0_99_exit()
        {            

            //     exit.;
        }
        private void xm0_print_totals()
        {            

            t1_in_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code];

            t1_in_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code];

            t1_out_svc = ws_mtd_out_svc[subs_dept_clinic, subs_class_code];

            t1_out_rec = ws_mtd_out_rec[subs_dept_clinic, subs_class_code];

            t1_misc_svc = ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_misc_rec = ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            // add ws-mtd-in-svc (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-svc (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-svc (subs-dept-clinic,subs-class-code);
            // 					giving	total-svc.;

            total_svc = ws_mtd_in_svc[subs_dept_clinic, subs_class_code] + ws_mtd_out_svc[subs_dept_clinic, subs_class_code] + ws_mtd_misc_svc[subs_dept_clinic, subs_class_code];

            //  add ws-mtd-in-rec (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-out-rec (subs-dept-clinic,subs-class-code);
            // 	ws-mtd-misc-rec (subs-dept-clinic,subs-class-code);
            // 					giving	total-rec.;

            total_rec = ws_mtd_in_rec[subs_dept_clinic, subs_class_code] + ws_mtd_out_rec[subs_dept_clinic, subs_class_code] + ws_mtd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_tot_svc = total_svc;
            t1_tot_rec = total_rec;
            t1_total_lit_grp = string.Empty;
            t1_class_r = ws_class_code[subs_dept_clinic, subs_class_code];

            t1_col_lit = ": ";
            t1_class_code_desc = ws_class_code_desc[subs_dept_clinic, subs_class_code];

            t1_mth_yr = "MONTH";

            //     write prt-line from total-line-1	after	advancing 2 lines.;            
            objPrint_File.print(true);
            objPrint_File.print(total_line_1_grp(), 1, true);

            t1_in_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code];

            t1_in_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code];

            t1_out_svc = ws_ytd_out_svc[subs_dept_clinic, subs_class_code];

            t1_out_rec = ws_ytd_out_rec[subs_dept_clinic, subs_class_code];

            t1_misc_svc = ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            t1_misc_rec = ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            // add ws-ytd-in-svc (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-svc (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-svc (subs-dept-clinic,subs-class-code);
            // 					giving	total-svc.;

            total_svc = ws_ytd_in_svc[subs_dept_clinic, subs_class_code] + ws_ytd_out_svc[subs_dept_clinic, subs_class_code] + ws_ytd_misc_svc[subs_dept_clinic, subs_class_code];

            //  add ws-ytd-in-rec (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-out-rec (subs-dept-clinic,subs-class-code);
            // 	ws-ytd-misc-rec (subs-dept-clinic,subs-class-code);
            // 					giving	total-rec.;

            total_rec = ws_ytd_in_rec[subs_dept_clinic, subs_class_code] + ws_ytd_out_rec[subs_dept_clinic, subs_class_code] + ws_ytd_misc_rec[subs_dept_clinic, subs_class_code];

            t1_tot_svc = total_svc;
            t1_tot_rec = total_rec;

            //t1_total_lit = "";
            t1_class_lit = string.Empty;
            t1_class = string.Empty;
            t1_totals_lit = string.Empty;

            t1_class_r = string.Empty;
            t1_col_lit = string.Empty;
            t1_class_code_desc = string.Empty;
            t1_total_lit_grp = string.Empty;

            t1_mth_yr = " YEAR";
            //     write prt-line from total-line-1	after	advancing 1 line.;            
            objPrint_File.print(total_line_1_grp(), 1, true);
        }
        private void xm0_99_exit()
        {            

            //     exit.;
        }

        private void az0_finalization()
        {         

            // perform ba2-oma-line		thru	ba2-99-exit.;

            ba2_oma_line();
            ba2_99_exit();

            // perform ba3-location-total		thru	ba3-99-exit.;
            ba3_location_total();
            ba3_99_exit();

            //  perform ba5-doctor-total		thru	ba5-99-exit.;
            ba5_doctor_total();
            ba5_99_exit();

            subs_dept_clinic = 1;
            // perform ba8-class-totals		thru	ba8-99-exit.;
            ba8_class_totals();
            ba8_99_exit();

            level = 4;
            // perform ba7-dept-total		thru	ba7-99-exit.;
            ba7_dept_total();
            ba7_10_check_code();
            ba7_99_exit();

            subs_dept_clinic = 2;
            level = 5;
            subs_max_nbr_classes = subs_max_nbr_classes_clinic;
            //   perform ba7-dept-total		thru	ba7-99-exit.;
            ba7_dept_total();
            ba7_10_check_code();
            ba7_99_exit();

            //     close loc-mstr;
            // 	  docrev-mstr;
            // 	  dept-mstr;
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

            return "R012  /".PadRight(7) +
                     Util.Str(h1_clinic_nbr).PadLeft(2) +
                     new string(' ', 3) +
                     "P.E.D.".PadRight(7) +
                     Util.Str(h1_ped_yy).PadLeft(4) +
                     "/" +
                     Util.Str(h1_ped_mm).PadLeft(2, '0') +
                     "/" +
                     Util.Str(h1_ped_dd).PadLeft(2, '0') +
                     new string(' ', 2) +
                     "* PHYSICIAN REVENUE ANALYSIS BY LOCATION(S) BY OMA CODE *".PadRight(60) +
                     "RUN DATE:".PadRight(11) +
                     Util.Str(h1_date_yy).PadLeft(4) +
                     "/" +
                     Util.Str(h1_date_mm).PadLeft(2, '0') +
                     "/" +
                     Util.Str(h1_date_dd).PadLeft(2, '0') +
                     new string(' ', 6) +
                     "PAGE ".PadRight(5) +
                     Util.Str(h1_page).PadLeft(4);
        }

        private string head_line_2_grp()
        {            

            return new string(' ', 48) +
                    Util.Str(h2_clinic).PadRight(20) +
                    new string(' ', 56);
        }

        private string head_line_3_grp()
        {            

            return new string(' ', 40) +
                   "DEPT #".PadRight(6) +
                   Util.Str(h3_department).PadLeft(2, '0') +
                   " - " +
                   Util.Str(h3_dept_name).PadRight(73);
        }

        private string head_line_4_grp()
        {            

            return new string(' ', 40) +
                    "CLASS".PadRight(7) +
                    Util.Str(h4_class_code).PadRight(2) +
                    "-".PadRight(2) +
                    Util.Str(h4_class_code_desc).PadRight(73);
        }

        private string head_line_5_grp()
        {            

            return new string(' ', 5) +
                   "--------------------- MONTH TO DATE ---------------------".PadRight(57) +
                   new string(' ', 3) +
                   "--------------------------- YEAR TO DATE -------------------------".PadRight(67);
        }

        private string head_line_6_grp()
        {            

            return " OMA  #SV____IN-PAT  #SV___OUT-PAT #SV____MISC   #SV__TOTAL-AMT  ".PadRight(65) +
                    "  #SV____IN-PAT    #SV___OUT-PAT    #SV______MISC    #SV__TOTAL-AMT".PadRight(67);
        }

        private string head_line_7_grp()
        {            

            return Util.Str(h7_doc_lit).PadRight(6) +
                     Util.Str(h7_doc_nbr).PadRight(3) +
                     new string(' ', 1) + Util.Str(h7_doc_name_inits).PadRight(122);
        }

        private string head_line_8_grp()
        {            

            return Util.Str(h8_loc_lit).PadRight(10) +
                    Util.Str(h8_loc).PadRight(7) +
                    Util.Str(h8_loc_name).PadRight(115);
        }

        private string head_line_9_grp()
        {            

            return Util.Str(h9_dept_clinic_tot).PadRight(132);
        }

        private string detail_line_1_grp()
        {         

            return Util.Str(d1_oma_code_or_lit).PadRight(6) +
                    Util.Str(d1_mtd_in_svc).PadLeft(4) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_mtd_in_rec, 2, 9) +
                    new string(' ', 1) +
                    Util.Str(d1_mtd_out_svc).PadLeft(4) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_mtd_out_rec, 2, 9) +
                    new string(' ', 1) +
                    Util.Str(d1_mtd_misc_svc).PadLeft(2) +
                    Util.ImpliedDecimalFormat("#0.00", d1_mtd_misc_rec, 2, 9) +
                    new string(' ', 1) +
                    Util.Str(d1_mtd_tot_svc).PadLeft(4) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#0.00", d1_mtd_tot_rec, 2, 10) +
                    new string(' ', 2) +
                    Util.Str(d1_ytd_in_svc).PadLeft(4) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_ytd_in_rec, 2, 10) +
                    new string(' ', 1) +
                    Util.Str(d1_ytd_out_svc).PadLeft(5) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_ytd_out_rec, 2, 10) +
                    new string(' ', 1) +
                    Util.Str(d1_ytd_misc_svc).PadLeft(5) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_ytd_misc_rec, 2, 10) +
                    new string(' ', 1) +
                    Util.Str(d1_ytd_tot_svc).PadLeft(5) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#0.00", d1_ytd_tot_rec, 2, 11).Replace("-","") +
                    new string(' ', 1);
        }

        private string total_head_line_1_grp()
        {            

            return new string(' ', 34) +
                     "# SVC____IN-PATIENT".PadRight(26) +
                     "# SVC___OUT-PATIENT".PadRight(26) +
                     "# SVC__MISCELLANEOUS".PadRight(26) +
                     "# SVC__TOTAL-AMOUNT".PadRight(20);
        }

        private string total_line_1_grp()
        {            

            string tmp_t1_total_lit = string.Empty;
            if (!string.IsNullOrWhiteSpace(t1_total_lit_grp))
            {
                tmp_t1_total_lit = Util.Str(t1_total_lit_grp).PadRight(25);
            }
            else if (!string.IsNullOrWhiteSpace(t1_class_code_desc))
            {
                tmp_t1_total_lit = Util.Str(t1_class_r).PadRight(1) + Util.Str(t1_col_lit).PadRight(1) + Util.Str(t1_class_code_desc).PadRight(23);
            }
            else
            {
                tmp_t1_total_lit = Util.Str(t1_class_lit).PadRight(11) + Util.Str(t1_class).PadRight(2) + Util.Str(t1_totals_lit).PadRight(12);
            }

            return
                    tmp_t1_total_lit +
                    Util.Str(t1_mth_yr).PadRight(6) +
                    string.Format("{0:#,0}", t1_in_svc).PadLeft(8) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#,0.00", t1_in_rec, 2, 13) +
                    new string(' ', 3) +
                    string.Format("{0:#,0}", t1_out_svc).PadLeft(8) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#,0.00", t1_out_rec, 2, 13) +
                    new string(' ', 3) +
                    string.Format("{0:#,0}", t1_misc_svc).PadLeft(8) +
                    new string(' ', 2) +
                    Util.ImpliedDecimalFormat("#,0.00", t1_misc_rec, 2, 13) +
                    new string(' ', 2) +
                    string.Format("{0:#,0}", t1_tot_svc).PadLeft(9) +
                    new string(' ', 1) +
                    Util.ImpliedDecimalFormat("#,0.00", t1_tot_rec, 2, 14);
        }

        #endregion
    }
}

