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
    public class R051aViewModel : CommonFunctionScr
    {

        #region FD Section
        // FD: doc_mstr	Copy : f020_doctor_mstr.fd
        private F020_DOCTOR_MSTR objDoc_mstr_rec = null;
        private ObservableCollection<F020_DOCTOR_MSTR> Doc_mstr_rec_Collection;

        // FD: docrev_mstr	Copy : f050_doc_revenue_mstr.fd
        private F050_DOC_REVENUE_MSTR objDocrev_master_rec = null;
        private ObservableCollection<F050_DOC_REVENUE_MSTR> Docrev_master_rec_Collection;

        // FD: iconst_mstr	Copy : f090_constants_mstr.fd
        private ICONST_MSTR_REC objIconst_mstr_rec = null;
        private ObservableCollection<ICONST_MSTR_REC> Iconst_mstr_rec_Collection;

        // FD: r051_work_file	Copy : r051_docrev_work_mstr.fd
        private r051_work_rec objWork_file_rec = null;
        private ObservableCollection<r051_work_rec> Work_file_rec_Collection;

        // FD: r051_work_file	Copy : r051_parm_file.fd
        private Parm_file_rec objParm_file_rec = null;
        private ObservableCollection<Parm_file_rec> Parm_file_rec_Collection;

        private WriteFile objR051Work_File;
        private WriteFile objParm_File;

        private SqlConnection objConn;

        #endregion

        #region Properties

        #endregion

        #region Working Storage Section
        private int err_ind = 0;
        private int sel_clinic_nbr;
        private int hold_dept;
        private string hold_class_code;
        private string hold_doc_nbr;
        private int parm_rec_nbr;
        private string ws_file_err_msg = "";
        private int ws_max_nbr_classes = 15;
        private int ws_max_nbr_dept = 99;
        private string reply;
        private string end_job = "N";
        private string eof_docrev_mstr = "N";
        private int ss;
        private int subs;
        private int subs_class_code;
        private string feedback_docrev_mstr;
        private string feedback_iconst_mstr;
        private string common_status_file;
        private string status_common;
        private string status_cobol_iconst_mstr = "0";
        private string status_cobol_doc_mstr = "0";
        private string status_cobol_docrev_mstr = "0";
        private string status_cobol_parm_file = "0";
        private string status_prt_file = "0";

        private string counters_grp;
        private int ctr_read_docrev_mstr;
        private string flag;
        private string ok = "Y";
        private string not_ok = "N";
        private string flag_end_docrev;
        private string flag_end_docrev_y = "Y";
        private string flag_end_docrev_n = "N";

        private string ws_date_grp;
        private int ws_yy;
        private int ws_mm;
        private int ws_dd;

        private string total_clinic_dept_doc_grp;
        private string[] total_mtd_ytd = new string[3];
        private int[] total_clinic_svc = new int[3];
        private int[] total_dept_svc = new int[3];
        private int[] total_doc_nbr_svc = new int[3];
        private decimal[] total_clinic_amt = new decimal[3];
        private decimal[] total_dept_amt = new decimal[3];
        private decimal[] total_doc_nbr_amt = new decimal[3];

        private string ws_hold_class_totals_grp;
        private string[] ws_class_tbl = new string[16];
        private string[] ws_hold_class_code = new string[16];
        private string[] ws_data = new string[16];
        private string[] ws_month_to_date = new string[16];
        private int[] ws_mtd_svcs = new int[16];
        private decimal[] ws_mtd_amt = new decimal[16];
        private string[] ws_year_to_date = new string[16];
        private int[] ws_ytd_svcs = new int[16];
        private decimal[] ws_ytd_amt = new decimal[16];

        private string error_message_table_grp;
        private string error_messages_grp;
        /*private string filler = "invalid reply";
        private string filler = "WRITING TO PARAMETER FILE";
        private string filler = "CLINIC NOT FOUND ON CONSTANTS MASTER";
        private string filler = "NO DOCREV RECORDS SUPPLIED";
        private string filler = "TOO MANY DEPARTMENTS FOUND";
        private string filler = "TOO MANY CLASS CODES FOUND"; */
        private string error_messages_r_grp;
        private string[] err_msg = { "", "invalid reply", "WRITING TO PARAMETER FILE", "CLINIC NOT FOUND ON CONSTANTS MASTER", "NO DOCREV RECORDS SUPPLIED", "TOO MANY DEPARTMENTS FOUND", "TOO MANY CLASS CODES FOUND" };
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

        private string prm_sel_clinic_nbr;
        private string prm_reply;
        private string endOfJob = "End of Job";
        private string high_value = "FF";
        private int ctr;

        #endregion

        #region Screen Section

        #endregion

        #region Procedure Divsion
        private void declaratives()
        {

        }

        private void err_docrev_mstr_file_section()
        {

            //     use after standard error procedure on docrev-mstr.;
        }

        private void err_docrev_mstr()
        {

            status_common = status_cobol_docrev_mstr;
            //     display status-common.;
            //     stop "ERROR IN ACCESSING DOCREV MASTER".;
        }

        private void err_doc_mstr_file_section()
        {

            //     use after standard error procedure on doc-mstr.;
        }

        private void err_doc_mstr()
        {

            status_common = status_cobol_doc_mstr;
            //     display status-common.;
            //     stop "ERROR IN ACCESSING DOC MASTER".;
        }

        private void err_iconst_mstr_file_section()
        {

            //     use after standard error procedure on iconst-mstr.;
        }

        private void err_iconst_mstr()
        {

            status_common = status_cobol_iconst_mstr;
            //     display status-common.;
            //     stop "ERROR IN ACCESSING CONSTANTS MASTER".;
        }

        private void err_parm_mstr_file_section()
        {

            //     use after standard error procedure on parameter-file.;
        }

        private void err_parm_file()
        {

            status_common = status_cobol_parm_file;
            //     display status-common.;
            //     stop "ERROR IN ACCESSING PARAMETER FILE".;
        }

        private void end_declaratives()
        {

        }

        private void main_line_section()
        {

        }

        public void mainline(string sel_clinic_nbr, string reply)
        {
            try
            {
                prm_sel_clinic_nbr = sel_clinic_nbr;
                prm_reply = reply;

                objDoc_mstr_rec = new F020_DOCTOR_MSTR();
                Doc_mstr_rec_Collection = new ObservableCollection<F020_DOCTOR_MSTR>();

                objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                Docrev_master_rec_Collection = new ObservableCollection<F050_DOC_REVENUE_MSTR>();

                objIconst_mstr_rec = new ICONST_MSTR_REC();
                Iconst_mstr_rec_Collection = new ObservableCollection<ICONST_MSTR_REC>();

                objWork_file_rec = new r051_work_rec();
                Work_file_rec_Collection = new ObservableCollection<r051_work_rec>();

                objParm_file_rec = new Parm_file_rec();
                Parm_file_rec_Collection = Read_R051_parm_file();

                objR051Work_File = null;
                objR051Work_File = new WriteFile(Directory.GetCurrentDirectory() + "\\" + "r051wf");
               
                objConn = objDoc_mstr_rec.Connection();

                //     perform aa0-initialization		thru aa0-99-exit.;
                aa0_initialization();
                aa0_10_acpt_continue();
                aa0_99_exit();

                //  perform ab0-processing		thru ab0-99-exit;
                // 	until flag-end-docrev-y.;

                do
                {
                    ab0_processing();
                    ab0_10_process_rec();
                    ab0_99_exit();
                } while (!flag_end_docrev.ToUpper().Equals(flag_end_docrev_y));


                // perform az0-end-of-job		thru az0-99-exit.;
                az0_end_of_job();
                az0_10_end_of_job();
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
                if (objR051Work_File != null)
                    objR051Work_File.CloseOutputFile();
                if (objParm_File != null)
                    objParm_File.CloseOutputFile();
            }
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
            run_hrs = Convert.ToInt32(DateTime.Now.ToString("HH"));
            //move sys - min            to run-min.
            run_min = Convert.ToInt32(DateTime.Now.ToString("mm"));
            //move sys - sec            to run-sec.
            run_sec = Convert.ToInt32(DateTime.Now.ToString("ss"));

            run_hrs = sys_hrs;
            run_min = sys_min;
            run_sec = sys_sec;
            //     open input	iconst-mstr;
            // 		doc-mstr;
            // 		docrev-mstr.;
            //     open i-o	parameter-file.;

            // perform aa1-acpt-clinic-nbr		thru aa1-99-exit.;
            aa1_acpt_clinic_nbr();
            aa1_99_exit();
        }

        private void aa0_10_acpt_continue()
        {

            //     accept reply;
            reply = prm_reply;

            // if reply = 'Y'  or reply = 'N'  then;        
            if (reply.ToUpper().Equals("Y") || reply.ToUpper().Equals("N"))
            {
                // 	   if reply = 'Y' then;            
                if (reply.ToUpper().Equals("Y"))
                {
                    // 	      next sentence;
                }
                else
                {
                    // 	      go to az0-end-of-job;
                    throw new Exception(endOfJob);
                }
            }
            else
            {
                err_ind = 1;
                // 	   perform za0-common-error	thru za0-99-exit;
                // 	   go to aa0-10-acpt-continue.;
                throw new Exception(endOfJob);
            }

            // open output r051-work-file.;

            //counters = 0;
            ctr_read_docrev_mstr = 0;

            // objDocrev_master_rec.docrev_key = 0;
            objDocrev_master_rec.DOCREV_CLINIC_1_2 = "0";
            objDocrev_master_rec.DOCREV_DEPT = 0;
            objDocrev_master_rec.DOCREV_DOC_NBR = "0";
            objDocrev_master_rec.DOCREV_LOCATION = "0";
            objDocrev_master_rec.DOCREV_OMA_CODE = "0";
            objDocrev_master_rec.DOCREV_OMA_SUFF = "0";

            //total_clinic_dept_doc = 0;
            total_mtd_ytd = new string[3];
            total_clinic_svc = new int[3];
            total_dept_svc = new int[3];
            total_doc_nbr_svc = new int[3];
            total_clinic_amt = new decimal[3];
            total_dept_amt = new decimal[3];
            total_doc_nbr_amt = new decimal[3];


            //ws_hold_class_totals = 0;
            ws_class_tbl = new string[16];
            ws_hold_class_code = new string[16];
            ws_data = new string[16];
            ws_month_to_date = new string[16];
            ws_mtd_svcs = new int[16];
            ws_mtd_amt = new decimal[16];
            ws_year_to_date = new string[16];
            ws_ytd_svcs = new int[16];
            ws_ytd_amt = new decimal[16];

            for (int i = 0; i < 16; i++)
            {
                ws_class_tbl[i] = "0";
                ws_hold_class_code[i] = "0";
                ws_data[i] = "0";
                ws_month_to_date[i] = "0";
                ws_year_to_date[i] = "0";
            }

            hold_dept = 0;
            hold_doc_nbr = "0";

            hold_class_code = "0";
            subs_class_code = 1;
            flag_end_docrev = "N";

            //objDocrev_master_rec.docrev_clinic_1_2 = sel_clinic_nbr;

            // move 1              to subs-class-code.
            parm_rec_nbr = 1;

            // read  parameter-file;          // TODO:....  Parameter file is not in the database. It's from the other program as input file...???
            // 	invalid key;
            //     err_ind = 2;
            // 	    perform za0-common-error	thru za0-99-exit.;

            if (Parm_file_rec_Collection.Count() > 0)
            {
                objParm_file_rec = Parm_file_rec_Collection[0];
            }
            else
            {
                err_ind = 2;
                //  perform za0-common-error	thru za0-99-exit.;
                za0_common_error();
                za0_99_exit();
            }

            // perform aa2-read-docrev-approx	thru aa2-99-exit.;
            aa2_read_docrev_approx();
            aa2_99_exit();

            if (flag_end_docrev.ToUpper().Equals(flag_end_docrev_y))
            {
                err_ind = 4;
                //  perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                //  go to az0-10-end-of-job;
                az0_10_end_of_job();
                return;
            }
            else
            {
                hold_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);
                // perform xe0-clear-wk-file-rec	thru xe0-99-exit;
                xe0_clear_wk_file_rec();
                xe0_99_exit();

                //  perform ha1-get-class-code	thru ha1-99-exit;
                ha1_get_class_code();
                ha1_99_exit();

                hold_class_code = Util.Str(objWork_file_rec.wf_class_code);
                ws_hold_class_code[subs_class_code] = Util.Str(objWork_file_rec.wf_class_code);
                hold_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);
            }
        }

        private void aa0_99_exit()
        {
            //     exit.;
        }

        private void aa1_acpt_clinic_nbr()
        {

            //     accept sel-clinic-nbr;
            sel_clinic_nbr = Util.NumInt(prm_sel_clinic_nbr);

            // objIconst_mstr_rec.iconst_clinic_nbr_1_2 = sel_clinic_nbr;

            // read iconst-mstr;
            // 	 invalid key;
            //      err_ind = 3;
            // 	 perform za0-common-error	thru za0-99-exit;
            //      sel_clinic_nbr = 0;
            // 	 go to aa1-acpt-clinic-nbr.;

            objIconst_mstr_rec = new ICONST_MSTR_REC
            {
                WhereIconst_clinic_nbr_1_2 = sel_clinic_nbr
            }.Collection().FirstOrDefault();

            if (objIconst_mstr_rec == null)
            {
                err_ind = 3;
                // perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();

                sel_clinic_nbr = 0;
                // 	 go to aa1-acpt-clinic-nbr.;
                new Exception(endOfJob);
            }
        }

        private void aa1_99_exit()
        {
            //     exit.;
        }

        private void aa2_read_docrev_approx()
        {

            //  start docrev-mstr key is greater than or equal to docrev-key;
            // 	invalid key;
            //         flag_end_docrev = "Y";
            // 	    go to aa2-99-exit.;

            //  read docrev-mstr next.;

            bool isRetrieved = false;
            Docrev_master_rec_Collection = new F050_DOC_REVENUE_MSTR
            {
                WhereDocrev_clinic_1_2 = prm_sel_clinic_nbr
            }.Collection_UsingTop(20000);

            // Debugging....  
           /* Docrev_master_rec_Collection.Clear();
                   ObservableCollection<F050_DOC_REVENUE_MSTR> tmpCollection = new F050_DOC_REVENUE_MSTR
                  {
                      WhereDocrev_clinic_1_2 = prm_sel_clinic_nbr
                  }.Collection_UsingTop(20000);

            //foreach (var obj in tmpCollection.Where(x => x.DOCREV_DEPT == 54 && x.DOCREV_DOC_NBR == "75N" && x.DOCREV_LOCATION == "MISC" && x.DOCREV_OMA_CODE == "MOHD" )) { // debugging only
            foreach (var obj in tmpCollection.Where(x =>  x.DOCREV_DOC_NBR == "75N"))
            { // debugging only
                Docrev_master_rec_Collection.Add(obj);
            } */
            // end debuggin...

            if (Docrev_master_rec_Collection.Count() == 0)
            {
                flag_end_docrev = "Y";
                aa2_99_exit();
                return;
            }
            else
            {
                if (ctr_read_docrev_mstr >= Docrev_master_rec_Collection.Count())
                {
                    objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                }
                else
                {
                    if (isRetrieved) ctr_read_docrev_mstr = 0;
                    objDocrev_master_rec = Docrev_master_rec_Collection[ctr_read_docrev_mstr];

                    //   add 1				to ctr-read-docrev-mstr.;
                    ctr_read_docrev_mstr++;
                }
            }

            //  if docrev-clinic-1-2 not = sel-clinic-nbr then;            
            //     flag_end_docrev = "Y";
            // 	   go to aa2-99-exit.;

            if (Util.NumInt(objDocrev_master_rec.DOCREV_CLINIC_1_2) != sel_clinic_nbr)
            {
                flag_end_docrev = "Y";
                aa2_99_exit();
                return;
            }
        }

        private void aa2_99_exit()
        {
            //     exit.;
        }

        private void az0_end_of_job()
        {

            //  perform da0-write-doc-total		thru da0-99-exit.;
            da0_write_doc_total();
            da0_99_exit();

            //  perform la0-write-class-totals	thru la0-99-exit;            
            // 	  varying subs-class-code from 1 by 1;
            // 	     until   subs-class-code > ws-max-nbr-classes;
            // 	     or ws-hold-class-code(subs-class-code) = zero.;

            subs_class_code = 1;
            do
            {
                la0_write_class_totals();
                la0_99_exit();
                subs_class_code++;
            } while (subs_class_code <= ws_max_nbr_classes && ws_hold_class_code[subs_class_code] != "0");

            //  perform ba0-write-dept-total	thru ba0-99-exit.;
            ba0_write_dept_total();
            ba0_99_exit();

            //  perform az1-write-clinic-total-to-wk;
            // 					thru az1-99-exit.;

            az1_write_clinic_total_to_wk();
            az1_99_exit();

            // perform az3-create-parm-file	thru az3-99-exit.;
            az3_create_parm_file();
            az3_99_exit();

        }

        private void az0_10_end_of_job()
        {

            //     accept sys-time			from time.;
            //     close docrev-mstr;
            // 	  doc-mstr;
            // 	  r051-work-file;
            // 	  parameter-file.;
            //     stop run.;
            throw new Exception(endOfJob);
        }

        private void az0_99_exit()
        {
            //     exit.;
        }

        private void az1_write_clinic_total_to_wk()
        {

            // perform xe0-clear-wk-file-rec	thru xe0-99-exit.;
            xe0_clear_wk_file_rec();
            xe0_99_exit();

            objWork_file_rec.wf_dept = 0;
            objWork_file_rec.wf_class_code = "0";
            objWork_file_rec.wf_doc_nbr = "0";
            objWork_file_rec.wf_oma_cd = "0";

            objWork_file_rec.wf_mtd_svcs = total_clinic_svc[1];
            objWork_file_rec.wf_ytd_svcs = total_clinic_svc[2];

            objWork_file_rec.wf_mtd_amt = Util.Str(total_clinic_amt[1]);
            objWork_file_rec.wf_ytd_amt = Util.Str(total_clinic_amt[2]);

            // perform xa0-write-wk-rec		thru xa0-99-exit.;
            xa0_write_wk_rec();
            xa0_99_exit();
        }

        private void az1_99_exit()
        {
            //     exit.;
        }

        private void az3_create_parm_file()
        {
            objParm_file_rec.Parm_program_nbr = "R051A";
            objParm_file_rec.Parm_status = 0;
            objParm_file_rec.Parm_clinic_nbr = Util.Str(sel_clinic_nbr);
            objParm_file_rec.Parm_clinic_name = objIconst_mstr_rec.ICONST_CLINIC_NAME;

            //objParm_file_rec.Parm_ped = objIconst_mstr_rec.iconst_date_period_end iconst_date_period_end;
            objParm_file_rec.Parm_ped = Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY) + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM) + Util.Str(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);
            objParm_file_rec.Parm_ped_yy = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_YY);
            objParm_file_rec.Parm_ped_mm = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_MM);
            objParm_file_rec.Parm_ped_dd = Util.NumInt(objIconst_mstr_rec.ICONST_DATE_PERIOD_END_DD);

            // rewrite parm-file-rec;   // TODO: Watch out for this rewrite....??? 
            // 	invalid key;
            //      err_ind = 2;
            // 	    perform za0-common-error	thru za0-99-exit.;

            Parm_file_rec_Collection.Clear();
            Parm_file_rec_Collection.Add(objParm_file_rec);

            string tempRec = Util.Str(objParm_file_rec.Parm_status).PadLeft(1, '0') + Util.Str(objParm_file_rec.Parm_program_nbr).PadRight(5) + Util.Str(objParm_file_rec.Parm_clinic_nbr).PadRight(2) + Util.Str(objParm_file_rec.Parm_clinic_name).PadRight(20) +
                            Util.Str(objParm_file_rec.Parm_ped_yy).PadLeft(4, '0') + Util.Str(objParm_file_rec.Parm_ped_mm).PadLeft(2, '0') + Util.Str(objParm_file_rec.Parm_ped_dd).PadLeft(2, '0');

            //todo: Verify the legacy if it's a linefeed or continious record.  And this should update the TEXT FILE : r051_parm_file NOT APPENDING A RECORD.
            Update_R051_Parm_File(Parm_file_rec_Collection);  //Todo Verify the values after updating the objParm_file_rec.
        }

        private void az3_99_exit()
        {
            //     exit.;
        }

        private void la0_write_class_totals()
        {

            // perform xe0-clear-wk-file-rec	thru xe0-99-exit.;
            xe0_clear_wk_file_rec();
            xe0_99_exit();

            objWork_file_rec.wf_dept = hold_dept;
            objWork_file_rec.wf_class_code = ws_hold_class_code[subs_class_code];
            objWork_file_rec.wf_doc_nbr = "0";
            objWork_file_rec.wf_oma_cd = "0";

            objWork_file_rec.wf_mtd_svcs = ws_mtd_svcs[subs_class_code];
            objWork_file_rec.wf_ytd_svcs = ws_ytd_svcs[subs_class_code];
            objWork_file_rec.wf_mtd_amt = Util.Str(ws_mtd_amt[subs_class_code]);
            objWork_file_rec.wf_ytd_amt = Util.Str(ws_ytd_amt[subs_class_code]);

            //  perform xa0-write-wk-rec		thru xa0-99-exit.;
            xa0_write_wk_rec();
            xa0_99_exit();
        }

        private void la0_99_exit()
        {
            //     exit.;
        }

        private void ab0_processing()
        {

            // if hold-dept not = docrev-dept then;            
            if (hold_dept != objDocrev_master_rec.DOCREV_DEPT)
            {
                // 	   perform da0-write-doc-total	thru da0-99-exit;
                da0_write_doc_total();
                da0_99_exit();

                // 	   perform la0-write-class-totals	thru la0-99-exit;
                // 		varying subs-class-code from 1 by 1;
                // 		until   subs-class-code > ws-max-nbr-classes;
                // 		     or ws-hold-class-code(subs-class-code) = zero;

                subs_class_code = 1;
                do
                {
                    la0_write_class_totals();
                    la0_99_exit();
                    subs_class_code++;
                } while (subs_class_code <= ws_max_nbr_classes && ws_hold_class_code[subs_class_code] != "0");


                // 	   perform ba0-write-dept-total	thru ba0-99-exit;
                ba0_write_dept_total();
                ba0_99_exit();

                ws_hold_class_totals_grp = "0";

                ws_class_tbl = new string[16];
                ws_hold_class_code = new string[16];
                ws_data = new string[16];
                ws_month_to_date = new string[16];
                ws_mtd_svcs = new int[16];
                ws_mtd_amt = new decimal[16];
                ws_year_to_date = new string[16];
                ws_ytd_svcs = new int[16];
                ws_ytd_amt = new decimal[16];

                for (int i = 0; i < 16; i++)
                {
                    ws_class_tbl[i] = "0";
                    ws_hold_class_code[i] = "0";
                    ws_data[i] = "0";
                    ws_month_to_date[i] = "0";
                    ws_year_to_date[i] = "0";
                }

                // 	   perform xe0-clear-wk-file-rec	thru xe0-99-exit;
                xe0_clear_wk_file_rec();
                xe0_99_exit();

                //  perform ha1-get-class-code	thru ha1-99-exit;
                ha1_get_class_code();
                ha1_99_exit();

                //  perform ja0-set-up-class-tbl	thru ja0-99-exit;
                ja0_set_up_class_tbl();
                ja0_10_check_class_code();
                ja0_99_exit();

                //  go to ab0-10-process-rec.;
                ab0_10_process_rec();
                return;
            }


            // if hold-doc-nbr not = docrev-doc-nbr then;            
            if (hold_doc_nbr != objDocrev_master_rec.DOCREV_DOC_NBR)
            {
                // 	  perform da0-write-doc-total	thru da0-99-exit;
                da0_write_doc_total();
                da0_99_exit();

                // 	  perform xe0-clear-wk-file-rec	thru xe0-99-exit;
                xe0_clear_wk_file_rec();
                xe0_99_exit();

                // 	  perform ha1-get-class-code	thru ha1-99-exit;
                ha1_get_class_code();
                ha1_99_exit();

                //  perform ja0-set-up-class-tbl	thru ja0-99-exit.;
                ja0_set_up_class_tbl();
                ja0_10_check_class_code();
                ja0_99_exit();
            }
        }

        private void ab0_10_process_rec()
        {
            // perform fa0-add-to-totals		thru fa0-99-exit.;
            fa0_add_to_totals();
            fa0_99_exit();

            // perform ha0-move-docrev-data-to-wk	thru ha0-99-exit.;
            ha0_move_docrev_data_to_wk();
            ha0_99_exit();

            // perform xa0-write-wk-rec		thru xa0-99-exit.;
            xa0_write_wk_rec();
            xa0_99_exit();

            hold_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);

            hold_class_code = Util.Str(objWork_file_rec.wf_class_code);
            hold_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);

            // perform xc0-read-next-docrev	thru xc0-99-exit.;
            xc0_read_next_docrev();
            xc0_99_exit();
        }
        private void ab0_99_exit()
        {
            //     exit.;
        }

        private void ba0_write_dept_total()
        {

            //  perform xe0-clear-wk-file-rec	thru xe0-99-exit.;
            xe0_clear_wk_file_rec();
            xe0_99_exit();

            // perform ba1-move-dept-data-to-wk-rec;
            // 					thru ba1-99-exit.;

            ba1_move_dept_data_to_wk_rec();
            ba1_99_exit();

            // perform xa0-write-wk-rec		thru xa0-99-exit.;
            xa0_write_wk_rec();
            xa0_99_exit();

            total_dept_svc[1] = 0;
            total_dept_svc[2] = 0;
            total_dept_amt[1] = 0;
            total_dept_amt[2] = 0;
        }

        private void ba0_99_exit()
        {

            //    exit.;
        }

        private void ba1_move_dept_data_to_wk_rec()
        {

            //  perform xe0-clear-wk-file-rec	thru xe0-99-exit.;
            xe0_clear_wk_file_rec();
            xe0_99_exit();

            objWork_file_rec.wf_dept = hold_dept;
            objWork_file_rec.wf_doc_nbr = "0";
            objWork_file_rec.wf_class_code = "0";
            objWork_file_rec.wf_oma_cd = "0";

            objWork_file_rec.wf_mtd_svcs = total_dept_svc[1];
            objWork_file_rec.wf_ytd_svcs = total_dept_svc[2];
            objWork_file_rec.wf_mtd_amt = Util.Str(total_dept_amt[1]);
            objWork_file_rec.wf_ytd_amt = Util.Str(total_dept_amt[2]);
        }

        private void ba1_99_exit()
        {

            //     exit.;
        }

        private void da0_write_doc_total()
        {

            // perform da1-move-doc-data-to-wk-rec;
            // 					thru da1-99-exit.;

            da1_move_doc_data_to_wk_rec();
            da1_99_exit();

            // perform xa0-write-wk-rec		thru xa0-99-exit.;
            xa0_write_wk_rec();
            xa0_99_exit();

            total_doc_nbr_svc[1] = 0;
            total_doc_nbr_svc[2] = 0;
            total_doc_nbr_amt[1] = 0;
            total_doc_nbr_amt[2] = 0;
        }
        private void da0_99_exit()
        {
            //     exit.;
        }

        private void da1_move_doc_data_to_wk_rec()
        {

            //  perform xe0-clear-wk-file-rec	thru xe0-99-exit.;
            xe0_clear_wk_file_rec();
            xe0_99_exit();

            objWork_file_rec.wf_dept = hold_dept;
            objWork_file_rec.wf_class_code = hold_class_code;
            objWork_file_rec.wf_doc_nbr = hold_doc_nbr;
            objWork_file_rec.wf_oma_cd = "0";

            objWork_file_rec.wf_mtd_svcs = total_doc_nbr_svc[1];
            objWork_file_rec.wf_ytd_svcs = total_doc_nbr_svc[2];
            objWork_file_rec.wf_mtd_amt = Util.Str(total_doc_nbr_amt[1]);
            objWork_file_rec.wf_ytd_amt = Util.Str(total_doc_nbr_amt[2]);
        }

        private void da1_99_exit()
        {
            //     exit.;
        }

        private void fa0_add_to_totals()
        {

            //     add docrev-mtd-in-svc		to total-clinic-svc(1);
            // 					   total-dept-svc(1);
            // 					   total-doc-nbr-svc(1);
            // 					   ws-mtd-svcs(subs-class-code).;

            total_clinic_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC);
            total_dept_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC);
            total_doc_nbr_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC);
            ws_mtd_svcs[subs_class_code] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC);


            //     add docrev-mtd-out-svc		to total-clinic-svc(1);
            // 					   total-dept-svc(1);
            // 					   total-doc-nbr-svc(1);
            // 					   ws-mtd-svcs(subs-class-code).;

            total_clinic_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);
            total_dept_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);
            total_doc_nbr_svc[1] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);
            ws_mtd_svcs[subs_class_code] += Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);

            //     add docrev-ytd-in-svc		to total-clinic-svc(2);
            // 					   total-dept-svc(2);
            // 					   total-doc-nbr-svc(2);
            // 					   ws-ytd-svcs(subs-class-code).;

            total_clinic_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC);
            total_dept_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC);
            total_doc_nbr_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC);
            ws_ytd_svcs[subs_class_code] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC);

            //     add docrev-ytd-out-svc		to total-clinic-svc(2);
            // 					   total-dept-svc(2);
            // 					   total-doc-nbr-svc(2);
            // 					   ws-ytd-svcs(subs-class-code).;

            total_clinic_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);
            total_dept_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);
            total_doc_nbr_svc[2] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);
            ws_ytd_svcs[subs_class_code] += Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);

            //     add docrev-mtd-in-rec		to total-clinic-amt(1);
            // 					   total-dept-amt(1);
            // 					   total-doc-nbr-amt(1);
            // 					   ws-mtd-amt(subs-class-code).;

            total_clinic_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC);
            total_dept_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC);
            total_doc_nbr_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC);
            ws_mtd_amt[subs_class_code] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC);

            //     add docrev-mtd-out-rec		to total-clinic-amt(1);
            // 					   total-dept-amt(1);
            // 					   total-doc-nbr-amt(1);
            // 					   ws-mtd-amt(subs-class-code).;

            total_clinic_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC);
            total_dept_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC);
            total_doc_nbr_amt[1] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC);
            ws_mtd_amt[subs_class_code] += Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC);

            //     add docrev-ytd-in-rec		to total-clinic-amt(2);
            // 					   total-dept-amt(2);
            // 					   total-doc-nbr-amt(2);
            // 					   ws-ytd-amt(subs-class-code).;

            total_clinic_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC);
            total_dept_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC);
            total_doc_nbr_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC);
            ws_ytd_amt[subs_class_code] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC);

            //     add docrev-ytd-out-rec		to total-clinic-amt(2);
            // 					   total-dept-amt(2);
            // 					   total-doc-nbr-amt(2);
            // 					   ws-ytd-amt(subs-class-code).;

            total_clinic_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC);
            total_dept_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC);
            total_doc_nbr_amt[2] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC);
            ws_ytd_amt[subs_class_code] += Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC);
        }

        private void fa0_99_exit()
        {
            //     exit.;
        }

        private void ha0_move_docrev_data_to_wk()
        {

            objWork_file_rec.wf_dept = Util.NumInt(objDocrev_master_rec.DOCREV_DEPT);
            objWork_file_rec.wf_doc_nbr = Util.Str(objDocrev_master_rec.DOCREV_DOC_NBR);

            //move docrev-oma - cd          to wf-oma - cd.
            objWork_file_rec.wf_oma_cd = Util.Str(objDocrev_master_rec.DOCREV_OMA_CODE) + Util.Str(objDocrev_master_rec.DOCREV_OMA_SUFF);

            //     add docrev-mtd-in-svc, docrev-mtd-out-svc;
            // 					giving wf-mtd-svcs.;

            objWork_file_rec.wf_mtd_svcs = Util.NumInt(objDocrev_master_rec.DOCREV_MTD_IN_SVC) + Util.NumInt(objDocrev_master_rec.DOCREV_MTD_OUT_SVC);

            //     add docrev-ytd-in-svc, docrev-ytd-out-svc;
            // 					giving wf-ytd-svcs.;

            objWork_file_rec.wf_ytd_svcs = Util.NumInt(objDocrev_master_rec.DOCREV_YTD_IN_SVC) + Util.NumInt(objDocrev_master_rec.DOCREV_YTD_OUT_SVC);

            //     add docrev-mtd-in-rec, docrev-mtd-out-rec;
            // 					giving wf-mtd-amt.;

            objWork_file_rec.wf_mtd_amt = Util.Str(Util.NumDec(objDocrev_master_rec.DOCREV_MTD_IN_REC) + Util.NumDec(objDocrev_master_rec.DOCREV_MTD_OUT_REC));

            //     add docrev-ytd-in-rec, docrev-ytd-out-rec;
            // 					giving wf-ytd-amt.;

            objWork_file_rec.wf_ytd_amt = Util.Str(Util.NumDec(objDocrev_master_rec.DOCREV_YTD_IN_REC) + Util.NumDec(objDocrev_master_rec.DOCREV_YTD_OUT_REC));
        }

        private void ha0_99_exit()
        {
            //     exit.;
        }

        private void ha1_get_class_code()
        {

            flag = "Y";
            // if docrev-doc-nbr = hold-doc-nbr then;            
            if (objDocrev_master_rec.DOCREV_DOC_NBR == hold_doc_nbr)
            {
                // 	   next sentence;
            }
            else
            {
                //   perform xg0-access-doc-mstr	thru xg0-99-exit.;
                xg0_access_doc_mstr();
                xg0_99_exit();
            }

            // if ok  then;        
            if (flag.ToUpper().Equals(ok))
            {

                //move doc-class-code to wf-class-code
                objWork_file_rec.wf_class_code = objDoc_mstr_rec.DOC_FULL_PART_IND;
            }
            else
            {
                objWork_file_rec.wf_class_code = high_value;  // Todo. Verify the high code... ???                
            }
        }

        private void ha1_99_exit()
        {
            //     exit.;
        }

        private void ja0_set_up_class_tbl()
        {
            subs_class_code = 1;
        }

        private void ja0_10_check_class_code()
        {

            // if wf-class-code = ws-hold-class-code(subs-class-code) then;        
            if (subs_class_code <= ws_max_nbr_classes && objWork_file_rec.wf_class_code == ws_hold_class_code[subs_class_code])
            {
                // 	   next sentence;
            }
            // else if subs-class-code > ws-max-nbr-classes then;                        
            else if (subs_class_code > ws_max_nbr_classes)
            {
                err_ind = 6;
                // perform za0-common-error	thru za0-99-exit;
                za0_common_error();
                za0_99_exit();
                // 	    go to az0-end-of-job;
                az0_end_of_job();
                return;
            }
            // else if ws-hold-class-code(subs-class-code) = zero then;            
            else if (ws_hold_class_code[subs_class_code] == "0")
            {
                ws_hold_class_code[subs_class_code] = objWork_file_rec.wf_class_code;
            }
            else
            {
                // 		add 1			to subs-class-code;
                subs_class_code++;
                // 		go to ja0-10-check-class-code.;
                ja0_10_check_class_code();
                return;
            }
        }

        private void ja0_99_exit()
        {
            //     exit.;
        }

        private void xa0_write_wk_rec()
        {

            //     write work-file-rec.;  // todo:   r051_work_rec... Check the existing data for verification.. pic s9(9)v99..???

            // 05  wf-month-to-date. 
            //     10  wf - mtd - svcs             pic s9(8).
            //     10  wf - mtd - amt              pic s9(9)v99.
            // 05  wf - year - to - date.
            //    10  wf - ytd - svcs             pic s9(8).
            //    10  wf - ytd - amt              pic s9(9)v99.

            /* string tempRec = Util.Str(objWork_file_rec.wf_dept).PadLeft(2, '0') +
                              Util.Str(objWork_file_rec.wf_class_code).PadRight(1) +
                              Util.Str(objWork_file_rec.wf_doc_nbr).PadRight(3) +
                              Util.Str(objWork_file_rec.wf_oma_code_ltr).PadRight(1) +
                              new string(' ', 4) +
                              Util.ConvertZone(objWork_file_rec.wf_mtd_svcs, 8,true) +
                              Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.wf_mtd_amt), 12) +
                              Util.ConvertZone(objWork_file_rec.wf_ytd_svcs, 8,true) +
                              Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.wf_ytd_amt), 12); */
            ++ctr;
            string tempRec = Util.Str(objWork_file_rec.wf_dept).PadLeft(2, '0') +
                                 Util.Str(objWork_file_rec.wf_class_code).PadRight(1) +
                                 Util.Str(objWork_file_rec.wf_doc_nbr).PadRight(3, '0') +
                                 Util.Str(objWork_file_rec.wf_oma_cd).PadRight(5, '0') +
                                 Util.ConvertZone(objWork_file_rec.wf_mtd_svcs, 9, true) +
                                  Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.wf_mtd_amt), 12, true) +
                                Util.ConvertZone(objWork_file_rec.wf_ytd_svcs, 9, true) +
                                 Util.ConvertZoneLong(Util.NumLongInt(objWork_file_rec.wf_ytd_amt), 12, true); // + " --- " + ctr.ToString();
           
            objR051Work_File.AppendOutputFile(tempRec);  // Todo: verify the existing if it's linefeed or not...??? 
            Work_file_rec_Collection.Add(objWork_file_rec);
        }

        private void xa0_99_exit()
        {

            //     exit.;
        }

        private void xc0_read_next_docrev()
        {

            //  read docrev-mstr next;
            // 	at end;
            //        flag_end_docrev = "Y";
            // 	    go to xc0-99-exit.;

            /* bool isRetrieved = false;
             Docrev_master_rec_Collection = new F050_DOC_REVENUE_MSTR
             {
                 WhereDocrev_clinic_1_2 = prm_sel_clinic_nbr           // todo: Verify the  criteria....?
             }.Collection_UsingStart(ref isRetrieved, Docrev_master_rec_Collection); */

            if (Docrev_master_rec_Collection.Count() == 0)
            {
                flag_end_docrev = "Y";
                aa2_99_exit();
                return;
            }
            else
            {
                if (ctr_read_docrev_mstr >= Docrev_master_rec_Collection.Count())
                {
                    objDocrev_master_rec = new F050_DOC_REVENUE_MSTR();
                }
                else
                {
                    // if (isRetrieved) ctr_read_docrev_mstr = 0;
                    objDocrev_master_rec = Docrev_master_rec_Collection[ctr_read_docrev_mstr];

                    //   add 1				to ctr-read-docrev-mstr.;
                    ctr_read_docrev_mstr++;
                }
            }

            //  if docrev-clinic-1-2 not = sel-clinic-nbr then;            
            //     flag_end_docrev = "Y";
            // 	go to xc0-99-exit.;

            if (Util.NumInt(objDocrev_master_rec.DOCREV_CLINIC_1_2) != sel_clinic_nbr)
            {
                flag_end_docrev = "Y";
                xc0_99_exit();
                return;
            }

        }

        private void xc0_99_exit()
        {
            //     exit.;
        }

        private void xe0_clear_wk_file_rec()
        {
            objWork_file_rec = new r051_work_rec();

            //move zero              to work-file - rec.
            //move spaces to wf - oma - cd.

            objWork_file_rec.wf_dept = 0;
            objWork_file_rec.wf_class_code = "0";
            objWork_file_rec.wf_oma_code_ltr = "";
            objWork_file_rec.wf_mtd_svcs = 0;
            objWork_file_rec.wf_mtd_amt = "0";
            objWork_file_rec.wf_ytd_svcs = 0;
            objWork_file_rec.wf_ytd_amt = "0";
        }

        private void xe0_99_exit()
        {
            //     exit.;
        }

        private void xg0_access_doc_mstr()
        {

            //objDoc_mstr_rec.DOC_NBR = objDocrev_master_rec.DOCREV_DOC_NBR;

            //     read doc-mstr;
            // 	invalid key;
            //        flag = "N";
            // 	    go to xg0-99-exit.;

            objDoc_mstr_rec = new F020_DOCTOR_MSTR
            {
                WhereDoc_nbr = objDocrev_master_rec.DOCREV_DOC_NBR
            }.Collection().FirstOrDefault();

            if (objDoc_mstr_rec == null)
            {
                flag = "N";
                // 	    go to xg0-99-exit.;
                xg0_99_exit();
                return;
            }
        }
        private void xg0_99_exit()
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

        #endregion
    }
}

