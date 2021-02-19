using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System.Data.SqlClient;
using System.IO;
using System.Collections.ObjectModel;
using rma.Cobol;
using RmaDAL;
using System.Diagnostics;
using Core.DataAccess.SqlServer;
using System.Data;

namespace rma.Cobol
{
    public   class CommonFunctionScr :CommonFunctionScreens
    {       
        public CommonFunctionScr()
        {

        }

       /* public CommonFunction(Grid layoutRoot)
        {
            _layoutRoot = layoutRoot;
        } */
       
        #region r123_bank_info.ws
        //  77   ws-nbr-settlement-accounts pic 99          value 4.
        protected int ws_nbr_settlement_accounts = 4;


        //77   ws-settlement-account-1      pic x(12)       value "7701918     ".
        protected  string ws_settlement_account_1 = "7701918     ";
        //77   ws-institution-id-1          pic 9(9)        value 001000562.  
        protected  long ws_institution_id_1 = 001000562;
        //77   ws-settlement-account-2      pic x(12)       value "1172611     ".
        protected  string ws_settlement_account_2 = "1172611     ";
        //77   ws-institution-id-2          pic 9(9)        value 001000062.  
        protected  long ws_institution_id_2 = 001000062;

        //77   ws-settlement-account-3      pic x(12)       value "9594213     ".
        protected  string ws_settlement_account_3 = "9594213     ";

        //77   ws-institution-id-3          pic 9(9)        value 001000062.
        protected  long ws_institution_id_3 = 001000062;

        //77   ws-settlement-account-4      pic x(12)       value "9079319     ".
        protected  string ws_settlement_account_4 = "9079319     ";
        //77   ws-institution-id-4          pic 9(9)        value 001000062.
        protected  long ws_institution_id_4 = 001000062;

        //01   ws-settlement-account pic x(12).
        protected  string ws_settlement_account;
        //01   ws-account-return		pic x(12).  
        protected  string ws_account_return;
        //01   ws-institution-id.
        protected  string ws_institution_id_grp;
        //05  ws-bank-nbr-id pic 9(4).
        protected  int ws_bank_nbr_id_child;
        // 05  ws-bank-branch-id pic 9(5).
        protected  int ws_bank_branch_id_child;

        //01   ws-institution-return.  
        protected  string ws_institution_return_grp;
        //05  ws-bank-nbr-return     pic 9(4).
        protected  int ws_bank_nbr_return_child;
        //05  ws-bank-branch-return 	pic 9(5).
        protected  long ws_bank_branch_return_child;


        //77   ws-dest-data-centre pic 9(5)        value 01020.  
        protected  int ws_dest_data_centre = 01020;
        //77   ws-short-name pic x(15)       value "  R. M. A.    ".     
        protected  string ws_short_name = "  R. M. A.    ";
        // 77   ws-long-name pic x(30)       value " Regional Medical Associates  ".
        protected  string ws_long_name = " Regional Medical Associates  ";

        //01   ws-originator-numbers.
        protected  string ws_originator_numbers_grp;
        //05  ws-originator-nbr-clinic-22  pic x(10)       value "0102024944".
        protected  string ws_originator_nbr_clinic_22_child = "0102024944";
        // 05  ws-originator-nbr-clinic-81  pic x(10)       value "0102006210".
        protected  string ws_originator_nbr_clinic_81_child = "0102006210";
        // 05  ws-originator-nbr-clinic-85  pic x(10)       value "0102018480".
        protected  string ws_originator_nbr_clinic_85_child = "0102018480";
        // 05  ws-originator-nbr-clinic-mp pic x(10)       value "0102007764".
        protected  string ws_originator_nbr_clinic_mp_child = "0102007764";

        //01   ws-file-creation-nbr pic 9(4)        value 1.
        protected  int ws_file_creation_nbr = 1;

        #endregion

        #region Sysdatetime.ws
        //01 century-year pic 9(4).
        protected  int century_year;
        // 01 century-date pic 9(8).
        protected  long century_date;
        // 01 default-century-cc pic 9(2) value 19.
        protected  int default_century_cc = 19;
        //01 default-century-cccc pic 9(4) value 1900.
        protected  int default_century_cccc = 1900;


        //01  sys-date.        
        protected  string sys_date_grp;
        //05  sys-date-long pic x(8).    
        protected  string sys_date_long_child;
        // 05  sys-date-long-r redefines  sys-date-long. 
        protected  string sys_date_long_r_child_redefines;
        // 10  sys-yy pic 9999. 
        protected  int sys_yy_child;
        // 10  sys-yy-alpha redefines  sys-yy.
        protected  string sys_yy_alpha_child_redefines;
        // 15  sys-y1 pic 9. 
        protected  int sys_y1_child;
        // 15  sys-y2 pic 9. 
        protected  int sys_y2_child;
        // 15  sys-y3 pic 9. 
        protected  int sys_y3_child;
        // 15  sys-y4 pic 9. 
        protected  int sys_y4_child;
        // 10  sys-mm pic 99. 
        protected  int sys_mm_child;
        // 10  sys-dd pic 99. 
        protected  int sys_dd_child;

        //01  sys-date-numeric redefines sys-date pic 9(8).
        protected  string sys_date_numeric_redefines;
        //01  sys-date-y2kfix redefines sys-date.
        protected  string sys_date_y2kfix_grp_redefines;
        //05 sys-date-left pic x(6).
        protected  string sys_date_left_child;
        // 05 filler pic x(2).
        //protectedstring filler_child;
        //01  sys-date-y2kfixed redefines sys-date.
        protected  string sys_date_y2kfixed_grp_redefines;
        //05 sys-date-blank pic x(2).
        protected  string sys_date_blank_child;
        // 05 sys-date-right pic x(6).
        protected  string sys_date_right_child;
        //01  sys-date-temp pic x(8).
        protected  string sys_date_temp;

        //01  run-date.        
        protected string run_date_grp; // = run_yy_child.ToString() + "/" + run_mm_child.ToString() + "/" + run_dd_child.ToString();
        // 05  run-yy pic 9999. 
        protected  int run_yy_child;
        // 05  filler pic x value "/".         
        //    05  run-mm pic 99. 
        protected  int run_mm_child;
        // 05  filler pic x value "/". 
        //05  run-dd pic 99. 
        protected  int run_dd_child;

        //01  sys-time.
        protected  string sys_time_grp;
        // 05  sys-hrs pic 99. 
        protected  int sys_hrs_child;
        // 05  sys-min pic 99. 
        protected  int sys_min_child;
        // 05  sys-sec pic 99. 
        protected  int sys_sec_child;
        // 05  sys-hdr pic 99. 
        protected  int sys_hdr_child;

        // 01  run-time.
        protected string run_time_grp; // = run_hrs_child.ToString() + ":" + run_min_child.ToString() + ":" + run_sec_child.ToString();
        // 05  run-hrs pic 99. 
        protected  int run_hrs_child;
        // 05  filler pic x value ":". 
        protected  string filler = ":";
        // 05  run-min pic 99. 
        protected  int run_min_child;
        // 05  filler pic x value ":". 
        //  05  run-sec pic 99. 
        protected  int run_sec_child;


        #endregion

        #region SysDate

        protected string Sysdate()
        {
            string sql = "SELECT DATE FROM [INDEXED].[CORE_DEBUG_SYSDATE]";
            string debugDate = null;
            SqlDataReader dr = null;
            dr = SqlHelper.ExecuteReader(Common.GetSqlConnectionString(), CommandType.Text, sql);
            if (dr.Read())
            {
                debugDate = dr[0].ToString();
            }
            dr.Close();

            if (string.IsNullOrWhiteSpace(debugDate) || Util.NumInt(debugDate) == 0)
            {
                debugDate = DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            }

            return debugDate;
        }

        #endregion

        #region InputAndOutputFiles
        public string AppConfigValueGet(string appKey)
        {
            string appValue = System.Configuration.ConfigurationManager.AppSettings[appKey];

            if (!appValue.Substring(appValue.Length - 1).Equals("\\"))
            {
                appValue += "\\";
            }

            return appValue;
        }
        public ObservableCollection<U119_payeft_rec> Read_U119_Payeft_SequentialFile(bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\U119_PAYEFT.ps";
            string line = string.Empty;

            ObservableCollection<U119_payeft_rec> U119_payeft_rec_Collection = new ObservableCollection<U119_payeft_rec>();
            using (StreamReader file = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        U119_payeft_rec objU119_payeft_rec = null;
                        objU119_payeft_rec = new U119_payeft_rec();
                        objU119_payeft_rec.w_doc_nbr = line.Substring(0, 3);
                        objU119_payeft_rec.filler_sign2 = line.Substring(3, 1);
                        objU119_payeft_rec.w_doc_dept = Util.NumInt(line.Substring(4, 2));
                        objU119_payeft_rec.filler_sign = line.Substring(6, 1);
                        objU119_payeft_rec.w_payeft_amt_n = Util.NumDec(line.Substring(7));
                        U119_payeft_rec_Collection.Add(objU119_payeft_rec);
                    }
                }
                else
                {
                    int ctr = 0;

                    line = file.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            ctr++;
                            string tmpLine = line.Substring(0, 22);
                            if (line.Trim().Length > 22)
                            {
                                line = line.Substring(22);
                            }
                            else
                            {
                                eoline = true;
                            }

                            U119_payeft_rec objU119_payeft_rec = null;
                            objU119_payeft_rec = new U119_payeft_rec();
                            objU119_payeft_rec.w_doc_nbr = tmpLine.Substring(0, 3);
                            objU119_payeft_rec.filler_sign2 = tmpLine.Substring(3, 1);
                            objU119_payeft_rec.w_doc_dept = Util.NumInt(tmpLine.Substring(4, 2));
                            objU119_payeft_rec.filler_sign = tmpLine.Substring(6, 1);
                            objU119_payeft_rec.w_payeft_amt_n = Util.NumDec(tmpLine.Substring(7));
                            U119_payeft_rec_Collection.Add(objU119_payeft_rec);
                        }
                    }
                }
            }
            return U119_payeft_rec_Collection;
        }

        public ObservableCollection<U119_chgeft_rec> Read_119_Chgeft_SequentialFile(bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\U119_CHGEFT.ps";
            string line = string.Empty;

            ObservableCollection<U119_chgeft_rec> U119_chgeft_rec_Collection = new ObservableCollection<U119_chgeft_rec>();
            using (StreamReader file = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        U119_chgeft_rec objU119_chgeft_rec = null;
                        objU119_chgeft_rec = new U119_chgeft_rec();
                        objU119_chgeft_rec.w_doc_nbr = line.Substring(0, 3);
                        objU119_chgeft_rec.filler_sign2 = line.Substring(3, 1);
                        objU119_chgeft_rec.w_doc_dept = Util.NumInt(line.Substring(4, 2));
                        objU119_chgeft_rec.filler_sign = line.Substring(6, 1);
                        objU119_chgeft_rec.w_chgeft_amt_n = Util.NumDec(line.Substring(7));
                        U119_chgeft_rec_Collection.Add(objU119_chgeft_rec);
                    }
                }
                else
                {
                    int ctr = 0;
                    line = file.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            ctr++;
                            string tmpLine = line.Substring(0, 22);
                            if (line.Trim().Length > 22)
                            {
                                line = line.Substring(22);
                            }
                            else
                            {
                                eoline = true;
                            }

                            U119_chgeft_rec objU119_chgeft_rec = null;
                            objU119_chgeft_rec = new U119_chgeft_rec();
                            objU119_chgeft_rec.w_doc_nbr = tmpLine.Substring(0, 3);
                            objU119_chgeft_rec.filler_sign2 = tmpLine.Substring(3, 1);
                            objU119_chgeft_rec.w_doc_dept = Util.NumInt(tmpLine.Substring(4, 2));
                            objU119_chgeft_rec.filler_sign = tmpLine.Substring(6, 1);
                            objU119_chgeft_rec.w_chgeft_amt_n = Util.NumDec(tmpLine.Substring(7));
                            U119_chgeft_rec_Collection.Add(objU119_chgeft_rec);
                        }
                    }
                }

            }
            return U119_chgeft_rec_Collection;
        }

        public int Eft_Constant_File_Read()
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\eft_constant";
            #if DEBUG
               filePath = Directory.GetCurrentDirectory() + "\\eft_constant";
            #endif


            int retValue = 0;

            if (!File.Exists(filePath))
            {                
                WriteFile objWriteFile = null;
                objWriteFile = new WriteFile(filePath);
                objWriteFile.AppendOutputFile("0".PadLeft(4));
                objWriteFile.CloseOutputFile();
                objWriteFile = null;
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                retValue = Util.NumInt(sr.ReadLine());
            }
            return retValue;
        }

        public void Eft_Contant_File_Rewrite(int value)
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\eft_constant";
            #if DEBUG
                filePath = Directory.GetCurrentDirectory() + "\\eft_constant";
            #endif

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(value.ToString().PadLeft(4, '0'));
            }
        }

        public ObservableCollection<Rat_record_1> Read_U030_OHIP_RAT_TAPE_SequentialFile()
        {
            //string filePath = Directory.GetCurrentDirectory() + "\\ohip_rat_ascii";

            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("pb_data");
            string filePath = Environment.CurrentDirectory + "\\ohip_rat_ascii";
            string line = string.Empty;

            ObservableCollection<Rat_record_1> U030_OHIP_RAT_TAPE_Collection = null;
            U030_OHIP_RAT_TAPE_Collection = new ObservableCollection<Rat_record_1>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while((line = file.ReadLine()) != null)
                {
                    line =  line.PadRight(80);
                    string transCode = line.Substring(0, 2);
                    string recordType = line.Substring(2, 1);

                    Rat_record_1 objRat_record_1 = null;
                    objRat_record_1 = new Rat_record_1();

                    objRat_record_1.Rat_1_trans_cd = line.Substring(0, 2);
                    objRat_record_1.Rat_1_record_type = line.Substring(2, 1);

                    if (recordType.Equals("1"))
                    {                       
                        objRat_record_1.Rat_1_release_id = line.Substring(3, 3);
                        objRat_record_1.Rat_1_filler_1 = line.Substring(6, 1);
                        objRat_record_1.Rat_1_group_nbr = line.Substring (7,4);
                        objRat_record_1.Rat_1_doc_nbr = Util.NumInt(line.Substring(11, 6));
                        objRat_record_1.Rat_1_specialty_cd = line.Substring(17, 2);
                        objRat_record_1.Rat_1_moh_off_cd = line.Substring(19, 1);
                        objRat_record_1.Rat_1_data_seq_nbr = Util.NumInt(line.Substring(20, 1));
                        //objRat_record_1.Rat_1_payment_date
                        objRat_record_1.Rat_1_payment_date_yy = Util.NumInt(line.Substring(21, 4));
                        objRat_record_1.Rat_1_payment_date_mm = Util.NumInt(line.Substring(25, 2));
                        objRat_record_1.Rat_1_payment_date_dd = Util.NumInt(line.Substring(27, 2));
                        objRat_record_1.Rat_1_last_name = line.Substring(29, 25);
                        objRat_record_1.Rat_1_title = line.Substring(54, 3);
                        objRat_record_1.Rat_1_initials = line.Substring(57, 2);
                        objRat_record_1.Rat_1_tot_amt_pay = Util.NumDec(line.Substring(59, 9));
                        objRat_record_1.Rat_1_tot_amt_pay_sign = line.Substring(68, 1);
                        objRat_record_1.Rat_1_cheq_nbr = line.Substring(69, 8);
                        objRat_record_1.Rat_1_filler_2 = line.Substring(77, 3);

                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("2") || recordType.Equals("3"))
                    {                       
                        Rat_record_2_3 objRat_record_2_3 = null;
                        objRat_record_2_3 = new Rat_record_2_3();

                        objRat_record_2_3.Filler = line.Substring(0, 79);
                        objRat_record_1.RatRecord_Reference = objRat_record_2_3;

                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("4"))
                    {
                        Rat_record_4 objRat_record_4 = null;
                        objRat_record_4 = new Rat_record_4();

                        objRat_record_4.Rat_4_trans_id = line.Substring(0, 2);
                        objRat_record_4.Rat_4_record_type = line.Substring(2, 1);
                        objRat_record_4.Rat_4_claim_nbr = line.Substring(3, 11);
                        objRat_record_4.Rat_4_trans_type = Util.NumInt(line.Substring(14, 1));
                        objRat_record_4.Rat_4_doc_nbr = Util.NumInt(line.Substring(15, 6));
                        objRat_record_4.Rat_4_specialty_cd = Util.NumInt(line.Substring(21, 2));
                        objRat_record_4.Rat_4_account_nbr = line.Substring(23, 8);
                        objRat_record_4.Rat_4_last_name = line.Substring(31, 14);
                        objRat_record_4.Rat_4_first_name = line.Substring(45, 5);
                        objRat_record_4.Rat_4_prov_cd = line.Substring(50, 2);
                        objRat_record_4.Rat_4_health_ohip_nbr = line.Substring(52, 12);
                        objRat_record_4.Rat_4_version_cd = line.Substring(64, 2);
                        objRat_record_4.Rat_4_pay_prog = line.Substring(66, 3);
                        objRat_record_4.Rat_4_ministry_location_cd = line.Substring(69, 4);
                        objRat_record_4.Rat_4_filler = line.Substring(73);

                        objRat_record_1.RatRecord_Reference = objRat_record_4;
                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("5"))
                    {
                        Rat_record_5 objRat_record_5 = null;
                        objRat_record_5 = new Rat_record_5();

                        objRat_record_5.Rat_5_trans_id = line.Substring(0, 2);
                        objRat_record_5.Rat_5_record_type = line.Substring(2, 1);
                        objRat_record_5.Rat_5_claim_nbr = line.Substring(3, 11);
                        objRat_record_5.Rat_5_trans_type = Util.NumInt(line.Substring(14, 1));
                        objRat_record_5.Rat_5_service_date = Util.NumInt(line.Substring(15, 8));
                        objRat_record_5.Rat_5_nbr_of_serv = Util.NumInt(line.Substring(23, 2));
                        objRat_record_5.Rat_5_service_cd = line.Substring(25,5);
                        objRat_record_5.Rat_5_eligibility_ind = line.Substring(30, 1);
                        objRat_record_5.Rat_5_amount_sub = Util.NumDec(line.Substring(31, 6));
                        objRat_record_5.Rat_5_amt_paid = Util.NumDec(line.Substring(37, 6));
                        objRat_record_5.Rat_5_amt_paid_sign = line.Substring(43, 1);
                        objRat_record_5.Rat_5_explan_cd = line.Substring(44, 2);
                        objRat_record_5.Rat_5_filler_2 = line.Substring(46);

                        objRat_record_1.RatRecord_Reference = objRat_record_5;
                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("6"))
                    {
                        Rat_record_6 objRat_record_6 = null;
                        objRat_record_6 = new Rat_record_6();

                        objRat_record_6.Rat_6_trans_id = line.Substring(0, 2);
                        objRat_record_6.Rat_6_record_type = line.Substring(2, 1);
                        objRat_record_6.Rat_6_amt_claims_adj = Util.NumDec(line.Substring(3, 9));
                        objRat_record_6.Rat_6_amt_claims_adj_sgn = line.Substring(12, 1);
                        objRat_record_6.Rat_6_amt_advances = Util.NumDec(line.Substring(13, 9));
                        objRat_record_6.Rat_6_amt_advances_sgn = line.Substring(22, 1);
                        objRat_record_6.Rat_6_amt_reductions = Util.NumDec(line.Substring(23, 9));
                        objRat_record_6.Rat_6_amt_reductions_sgn = line.Substring(32, 1);
                        objRat_record_6.Rat_6_amt_deductions = Util.NumDec(line.Substring(33, 9));
                        objRat_record_6.Rat_6_amt_deductions_sgn = line.Substring(42, 1);
                        objRat_record_6.Rat_6_filler = line.Substring(43);

                        objRat_record_1.RatRecord_Reference = objRat_record_6;
                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("7"))
                    {
                        Rat_record_7 objRat_record_7 = null;
                        objRat_record_7 = new Rat_record_7();

                        objRat_record_7.Rat_7_trans_id = line.Substring(0, 2);
                        objRat_record_7.Rat_7_record_type = line.Substring(2, 1);
                        objRat_record_7.Rat_7_trans_cd = line.Substring(3, 2);
                        objRat_record_7.Rat_7_cheque_ind = line.Substring(5, 1);
                        objRat_record_7.Rat_7_trans_date = Util.NumInt(line.Substring(6, 8));
                        objRat_record_7.Rat_7_trans_amt = Util.NumDec(line.Substring(14, 8));
                        objRat_record_7.Rat_7_trans_amt_sgn = line.Substring(22, 1);
                        objRat_record_7.Rat_7_trans_message = line.Substring(23, 50);
                        objRat_record_7.Rat_7_filler = line.Substring(73,4);

                        objRat_record_1.RatRecord_Reference = objRat_record_7;
                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                    else if (recordType.Equals("8"))
                    {
                        Rat_record_8 objRat_record_8 = null;
                        objRat_record_8 = new Rat_record_8();

                        objRat_record_8.Rat_8_trans_id = line.Substring(0, 2);
                        objRat_record_8.Rat_8_record_type = line.Substring(2, 1);
                        objRat_record_8.Rat_8_mess_text = line.Substring(3, 70);
                        objRat_record_8.Rat_8_filler = line.Substring(73, 4);

                        objRat_record_1.RatRecord_Reference = objRat_record_8;
                        U030_OHIP_RAT_TAPE_Collection.Add(objRat_record_1);
                    }
                }
            }
            return U030_OHIP_RAT_TAPE_Collection;
        }

        public ObservableCollection<Unpriced_claims_record> Read_U701Oscar_Unpriced_Claims_File_SequentialFile()
        {

            string filePath = Directory.GetCurrentDirectory() + "\\" + "submit_disk_susp.in";
            string line = string.Empty;

            ObservableCollection<Unpriced_claims_record> Unpriced_claims_record_Collection = null;
            Unpriced_claims_record_Collection = new ObservableCollection<Unpriced_claims_record>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = line.PadRight(180);
                    string trans_id = line.Substring(0, 2);
                    string input_type_rec = line.Substring(2, 1);

                    Unpriced_claims_record obj = null;
                    obj = new Unpriced_claims_record();

                    obj.Unpriced_trans_id = trans_id;
                    obj.Unpriced_input_rec_type = input_type_rec;
                    obj.unpriced_bathdr_rec_full = line.Substring(3);

                    if (input_type_rec.Equals("B"))   // HEB -
                    {
                        obj.Unpriced_release_id = line.Substring(3, 3);
                        obj.Unpriced_moh_code = line.Substring(6, 1);
                        obj.Unpriced_bathdr_batch_nbr_date = Util.NumInt(line.Substring(7, 8));
                        obj.Unpriced_bathdr_batch_nbr_seq = Util.NumInt(line.Substring(15, 4));
                        obj.Unpriced_bathdr_opr_nbr = line.Substring(19, 6);
                        obj.Unpriced_bathdr_fac_no = line.Substring(25, 4);
                        obj.Unpriced_bathdr_prov_ohip_no = Util.NumInt(line.Substring(29, 6));
                        obj.Unpriced_bathdr_spec_cd = Util.NumInt(line.Substring(35, 2));
                        obj.Filler = line.Substring(37, 42);
                        obj.Unpriced_payroll_flag = line.Substring(79, 1);
                        obj.Unpriced_default_batch_i_o_ind = line.Substring(80, 1);
                        obj.Unpriced_default_batch_loc = line.Substring(81, 4);
                        obj.Unpriced_bathdr_clinic__ignore = Util.NumInt(line.Substring(85, 2));
                        obj.Unpriced_bathdr_oscar_doc_id = line.Substring(87, 10);
                        obj.Unpriced_bathdr_dept = Util.NumInt(line.Substring(97, 2));
                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("H"))   // HEH  -
                    {

                        obj.Unpriced_clmhdr_health_nbr = line.Substring(3, 10);
                        obj.Unpriced_clmhdr_version_cd = line.Substring(13, 2);
                        obj.Unpriced_clmhdr_birth_date_yy = Util.NumInt(line.Substring(15, 4));
                        obj.Unpriced_clmhdr_birth_date_mm = Util.NumInt(line.Substring(19, 2));
                        obj.Unpriced_clmhdr_birth_date_dd = Util.NumInt(line.Substring(21, 2));

                        obj.Unpriced_clmhdr_doc_nbr = line.Substring(23, 3);
                        obj.Unpriced_clmhdr_wk = line.Substring(26, 2);
                        obj.Unpriced_clmhdr_day = line.Substring(28, 1);
                        obj.Unpriced_clmhdr_claim_nbr = line.Substring(29, 2);

                        obj.Unpriced_clmhdr_pay_pgm = line.Substring(31, 3);
                        obj.Unpriced_clmhdr_payee = line.Substring(34, 1);
                        obj.Unpriced_clmhdr_ref_doc_nbr = Util.NumInt(line.Substring(35, 6));
                        obj.Unpriced_clmhdr_hosp_nbr = line.Substring(41, 4);
                        obj.Unpriced_clmhdr_admit_date_yy = line.Substring(45, 4);
                        obj.Unpriced_clmhdr_admit_date_mm = line.Substring(49, 2);
                        obj.Unpriced_clmhdr_admit_date_dd = line.Substring(51, 2);

                        obj.Unpriced_clmhdr_ref_lab_no = Util.NumInt(line.Substring(53, 4));
                        obj.Unpriced_clmhdr_man_review = line.Substring(57, 1);
                        obj.Unpriced_moh_location_code = Util.NumInt(line.Substring(58, 4));
                        obj.Unpriced_reserved_for_ooc = line.Substring(62, 11);
                        obj.Filler = line.Substring(73, 6);
                        obj.Unpriced_confidentiality_flag = line.Substring(79, 1);
                        obj.Unpriced_clmhdr_agent_cd = line.Substring(80, 1);
                        obj.Unpriced_clmhdr_i_o_ind = line.Substring(81, 1);
                        obj.Unpriced_clmhdr_hc_prov_cd = line.Substring(82, 2);
                        obj.Unpriced_clmhdr_hc_ohip_nbr = line.Substring(84, 12);
                        obj.Unpriced_clmhdr_pat_acronym = line.Substring(96, 9);
                        obj.Unpriced_bathdr_clinic_1_2 = Util.NumInt(line.Substring(105, 2));
                        obj.Unpriced_clmhdr_pat_surname2 = line.Substring(107, 30);
                        obj.Unpriced_clmhdr_given_name2 = line.Substring(137, 30);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("R"))  // HER
                    {

                        obj.Unpriced_clmhdr_pat_ohip_nbr = line.Substring(3, 12);
                        obj.Unpriced_clmhdr_pat_surname_2 = line.Substring(15, 9);
                        obj.Unpriced_clmhdr_given_name_2 = line.Substring(24, 5);
                        obj.Unpriced_clmhdr_sex_2 = Util.NumInt(line.Substring(29, 1));

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("T"))  // HET  --
                    {
                        obj.Unpriced_itm1_oma_svc_code = line.Substring(3, 4);
                        obj.Unpriced_itm1_oma_svc_suff = line.Substring(7, 1);

                        obj.Filler = line.Substring(8, 2);
                        obj.Unpriced_itm1_oma_amt_billed = Util.NumDec(line.Substring(10, 6));
                        obj.Unpriced_itm1_nbr_serv = Util.NumInt(line.Substring(16, 2));
                        obj.Unpriced_itm1_svc_date_yy = Util.NumInt(line.Substring(18, 4));
                        obj.Unpriced_itm1_svc_date_mm = Util.NumInt(line.Substring(22, 2));
                        obj.Unpriced_itm1_svc_date_dd = Util.NumInt(line.Substring(24, 2));

                        obj.Unpriced_itm1_diag_cd = line.Substring(26, 3);
                        obj.Filler_diag = line.Substring(29, 1);
                        obj.Unpriced_reserved_for_ooc = line.Substring(30, 9);
                        obj.Filler = line.Substring(39, 11);
                        obj.Unpriced_itm2_oma_svc_code = line.Substring(50, 4);
                        obj.Unpriced_itm2_oma_svc_suff = line.Substring(54, 1);
                        obj.Filler = line.Substring(55, 2);
                        obj.Unpriced_itm2_oma_amt_billed = Util.NumDec(line.Substring(57, 6));
                        obj.Unpriced_itm2_nbr_serv = Util.NumInt(line.Substring(63, 2));
                        obj.Unpriced_itm2_svc_date_yy = Util.NumInt(line.Substring(65, 4));
                        obj.Unpriced_itm2_svc_date_mm = Util.NumInt(line.Substring(69, 2));
                        obj.Unpriced_itm2_svc_date_dd = Util.NumInt(line.Substring(71, 2));
                        obj.Unpriced_itm2_diag_cd = line.Substring(73, 3);
                        obj.Filler = line.Substring(76, 6);
                        obj.Unpriced_itm1_override_price = line.Substring(82, 1);
                        obj.Unpriced_itm1_bilateral = line.Substring(83, 1);
                        obj.Unpriced_itm2_override_price = line.Substring(84, 1);
                        obj.Unpriced_itm2_bilateral = line.Substring(85, 1);
                        obj.Unpriced_itm3_override_price = line.Substring(86, 1);
                        obj.Unpriced_itm4_bilateral = line.Substring(87, 1);
                        obj.Filler = line.Substring(88, 112);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("A") || input_type_rec.Equals("P"))  // HEA/ HEP -
                    {
                        obj.Unpriced_pat_addr_1 = line.Substring(3, 25);
                        obj.Unpriced_pat_addr_2 = line.Substring(28, 25);
                        obj.Unpriced_pat_addr_3 = line.Substring(53, 18);
                        obj.Unpriced_clmhdr_hc_prov_cd_2 = line.Substring(71, 2);
                        obj.Unpriced_pat_addr_post_cd = line.Substring(73, 9);
                        obj.Unpriced_clmhdr_surname_1_6 = line.Substring(82, 6);
                        obj.Unpriced_clmhdr_surname_7_30 = line.Substring(88, 24);
                        obj.Unpriced_clmhdr_given_name1_3 = line.Substring(112, 3);
                        obj.Unpriced_clmhdr_given_name4_30 = line.Substring(115, 27);
                        obj.Unpriced_clmhdr_sex = line.Substring(142, 1);
                        obj.Unpriced_clmhdr_phone_no = line.Substring(143, 20);
                        obj.Unpriced_clmhdr_birth_date_yy2 = Util.NumInt(line.Substring(163, 4));
                        obj.Unpriced_clmhdr_birth_date_mm2 = Util.NumInt(line.Substring(167, 2));
                        obj.Unpriced_clmhdr_birth_date_dd2 = Util.NumInt(line.Substring(169, 2));
                        obj.Filler = line.Substring(171, 5);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("E"))   // HEE --
                    {
                        obj.Unpriced_trailer_clmhdr1_cnt = Util.NumInt(line.Substring(3, 4));
                        obj.Unpriced_trailer_clmhdr2_cnt = Util.NumInt(line.Substring(7, 4));
                        obj.Unpriced_trailer_itm_cnt = Util.NumInt(line.Substring(11, 5));
                        obj.Unpriced_trailer_pat_addr_cnt = Util.NumInt(line.Substring(16, 4));
                        obj.Filler1 = line.Substring(20, 63);
                        obj.Filler2 = line.Substring(83, 99);
                        Unpriced_claims_record_Collection.Add(obj);
                    }
                }
            }

            return Unpriced_claims_record_Collection;

        }

        public ObservableCollection<Unpriced_claims_record> Read_Unpriced_Claims_File_SequentialFile()
        {

            string filePath = Directory.GetCurrentDirectory() + "\\" + "submit_disk_susp.in";
            string line = string.Empty;

            ObservableCollection<Unpriced_claims_record> Unpriced_claims_record_Collection = null;
            Unpriced_claims_record_Collection = new ObservableCollection<Unpriced_claims_record>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = line.PadRight(180);
                    string trans_id = line.Substring(0, 2);
                    string input_type_rec = line.Substring(2, 1);

                    Unpriced_claims_record obj = null;
                    obj = new Unpriced_claims_record();

                    obj.Unpriced_trans_id = trans_id;
                    obj.Unpriced_input_rec_type = input_type_rec;
                    obj.unpriced_bathdr_rec_full = line.Substring(3);

                    if (input_type_rec.Equals("B"))   // HEB
                    {
                        obj.Unpriced_release_id = line.Substring(3, 3);
                        obj.Unpriced_moh_code = line.Substring(6, 1);
                        obj.Unpriced_bathdr_batch_nbr_date = Util.NumInt(line.Substring(7, 8));
                        obj.Unpriced_bathdr_batch_nbr_seq = Util.NumInt(line.Substring(15, 4));
                        obj.Unpriced_bathdr_opr_nbr = line.Substring(19, 6);
                        obj.Unpriced_bathdr_fac_no = line.Substring(25, 4);
                        obj.Unpriced_bathdr_prov_ohip_no = Util.NumInt(line.Substring(29, 6));
                        obj.Unpriced_bathdr_spec_cd = Util.NumInt(line.Substring(35, 2));
                        obj.Filler = line.Substring(37, 29);
                        obj.Unpriced_payroll_flag = line.Substring(66, 1);
                        obj.Unpriced_default_batch_i_o_ind = line.Substring(67, 1);
                        obj.Unpriced_default_batch_loc = line.Substring(68, 4);
                        obj.Unpriced_bathdr_clinic_1_2 = Util.NumInt(line.Substring(72, 2));
                        obj.Unpriced_bathdr_dept = Util.NumInt(line.Substring(74, 2));
                        obj.Unpriced_bathdr_doc_nbr = line.Substring(76, 3);
                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("H"))   // HEH
                    {

                        obj.Unpriced_clmhdr_health_nbr = line.Substring(3, 10);
                        obj.Unpriced_clmhdr_version_cd = line.Substring(13, 2);
                        obj.Unpriced_clmhdr_birth_date_yy = Util.NumInt(line.Substring(15, 4));
                        obj.Unpriced_clmhdr_birth_date_mm = Util.NumInt(line.Substring(19, 2));
                        obj.Unpriced_clmhdr_birth_date_dd = Util.NumInt(line.Substring(21, 2));

                        obj.Unpriced_clmhdr_doc_nbr = line.Substring(23, 3);
                        obj.Unpriced_clmhdr_wk = line.Substring(26, 2);
                        obj.Unpriced_clmhdr_day = line.Substring(28, 1);
                        obj.Unpriced_clmhdr_claim_nbr = line.Substring(29, 2);

                        obj.Unpriced_clmhdr_pay_pgm = line.Substring(31, 3);
                        obj.Unpriced_clmhdr_payee = line.Substring(34, 1);
                        obj.Unpriced_clmhdr_ref_doc_nbr = Util.NumInt(line.Substring(35, 6));
                        obj.Unpriced_clmhdr_hosp_nbr = line.Substring(41, 4);
                        obj.Unpriced_clmhdr_admit_date_yy = line.Substring(45, 4);
                        obj.Unpriced_clmhdr_admit_date_mm = line.Substring(49, 2);
                        obj.Unpriced_clmhdr_admit_date_dd = line.Substring(51, 2);

                        obj.Unpriced_clmhdr_ref_lab_no = Util.NumInt(line.Substring(53, 4));
                        obj.Unpriced_clmhdr_man_review = line.Substring(57, 1);
                        obj.Unpriced_moh_location_code = Util.NumInt(line.Substring(58, 4));
                        obj.Unpriced_reserved_for_ooc = line.Substring(62, 11);
                        obj.Filler = line.Substring(73, 6);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("R"))  // HER
                    {

                        obj.Unpriced_clmhdr_pat_ohip_nbr = line.Substring(3, 12);
                        obj.Unpriced_clmhdr_pat_surname = line.Substring(15, 9);
                        obj.Unpriced_clmhdr_given_name = line.Substring(24, 5);
                        obj.Unpriced_clmhdr_sex = line.Substring(29, 1);
                        obj.Unpriced_clmhdr_prov_cd = line.Substring(30, 2);
                        obj.Filler = line.Substring(32, 30);
                        obj.Unpriced_confidentiality_flag = line.Substring(62, 1);
                        obj.Unpriced_clmhdr_loc_code = line.Substring(63, 4);
                        obj.Unpriced_clmhdr_agent_cd = line.Substring(67, 1);
                        obj.Unpriced_clmhdr_i_o_ind = line.Substring(68, 1);
                        obj.Unpriced_clmhdr_phone_no_1_7 = line.Substring(69, 7);
                        obj.Unpriced_clmhdr_phone_no_8_10 = line.Substring(76, 3);
                        obj.Unpriced_clmhdr_phone_no_1_3 = line.Substring(69, 3);
                        obj.Unpriced_clmhdr_phone_no_4_10 = line.Substring(72, 7);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("T"))  // HET
                    {
                        obj.Unpriced_itm1_oma_svc_code = line.Substring(3, 4);
                        obj.Unpriced_itm1_oma_svc_suff = line.Substring(7, 1);

                        obj.Filler = line.Substring(8, 2);
                        obj.Unpriced_itm1_oma_amt_billed = Util.NumDec(line.Substring(10, 6));
                        obj.Unpriced_itm1_nbr_serv = Util.NumInt(line.Substring(16, 2));
                        obj.Unpriced_itm1_svc_date_yy = Util.NumInt(line.Substring(18, 4));
                        obj.Unpriced_itm1_svc_date_mm = Util.NumInt(line.Substring(22, 2));
                        obj.Unpriced_itm1_svc_date_dd = Util.NumInt(line.Substring(24, 2));

                        obj.Unpriced_itm1_diag_cd = line.Substring(26, 3);
                        obj.Filler_diag = line.Substring(29, 1);
                        obj.Unpriced_reserved_for_ooc = line.Substring(30, 9);
                        obj.Unpriced_itm1_override_price = line.Substring(39, 1);
                        obj.Unpriced_itm1_bilateral = line.Substring(40, 1);
                        obj.Unpriced_itm2_oma_svc_code = line.Substring(41, 4);
                        obj.Unpriced_itm2_oma_svc_suff = line.Substring(45, 1);
                        obj.Filler1 = line.Substring(46, 2);
                        obj.Unpriced_itm2_oma_amt_billed = Util.NumDec(line.Substring(48, 6));
                        obj.Unpriced_itm2_nbr_serv = Util.NumInt(line.Substring(54, 2));
                        obj.Unpriced_itm2_svc_date_yy = Util.NumInt(line.Substring(56, 4));
                        obj.Unpriced_itm2_svc_date_mm = Util.NumInt(line.Substring(60, 2));
                        obj.Unpriced_itm2_svc_date_dd = Util.NumInt(line.Substring(62, 2));
                        obj.Unpriced_itm2_diag_cd = line.Substring(64, 4);
                        obj.Unpriced_reserved_for_ooc = line.Substring(68, 9);
                        obj.Unpriced_itm2_override_price = line.Substring(77, 1);
                        obj.Unpriced_itm2_bilateral = line.Substring(78, 1);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("A") || input_type_rec.Equals("P"))  // HEA/ HEP
                    {
                        obj.Unpriced_pat_addr_1 = line.Substring(3, 25);
                        obj.Unpriced_pat_addr_2 = line.Substring(28, 25);
                        obj.Unpriced_pat_addr_3 = line.Substring(53, 18);
                        obj.Unpriced_pat_addr_post_cd1 = line.Substring(71, 1);
                        obj.Unpriced_pat_addr_post_cd2 = line.Substring(72, 1);
                        obj.Unpriced_pat_addr_post_cd3 = line.Substring(73, 1);
                        obj.Unpriced_pat_addr_post_cd4 = line.Substring(74, 1);
                        obj.Unpriced_pat_addr_post_cd5 = line.Substring(75, 1);
                        obj.Unpriced_pat_addr_post_cd6 = line.Substring(76, 1);
                        obj.Filler = line.Substring(77, 2);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                    else if (input_type_rec.Equals("E"))   // HEE
                    {
                        obj.Unpriced_trailer_clmhdr1_cnt = Util.NumInt(line.Substring(3, 4));
                        obj.Unpriced_trailer_clmhdr2_cnt = Util.NumInt(line.Substring(7, 4));
                        obj.Unpriced_trailer_itm_cnt = Util.NumInt(line.Substring(11, 5));
                        obj.Unpriced_trailer_pat_addr_cnt = Util.NumInt(line.Substring(16, 4));
                        obj.Filler1 = line.Substring(20, 59);

                        Unpriced_claims_record_Collection.Add(obj);
                    }
                }
            }

            return Unpriced_claims_record_Collection;

        }

        public ObservableCollection<Afp_record> Read_U140_afp_fixed_payments_DAT_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\afp_fixed_payments.dat";
            string line = string.Empty;

            ObservableCollection<Afp_record> Afp_record_Collection = null;
            Afp_record_Collection = new ObservableCollection<Afp_record>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = line.PadLeft(134);
                    string recordID = line.Substring(0, 3);

                    Afp_record objAfp_record = null;
                    objAfp_record = new Afp_record();

                    objAfp_record.Afp_record_id = recordID;
                    objAfp_record.Afp_record_data = line.Substring(0, 134);
                    objAfp_record.Afp_cr = line.Substring(132, 1);

                    if (recordID.Equals("A1F"))
                    {
                        Afp_a1f_record objAfp_a1f_record = null;
                        objAfp_a1f_record = new Afp_a1f_record();
                        objAfp_a1f_record.Afp_a1f_record1 = line;

                        objAfp_record.Aft_Record_Reference = objAfp_a1f_record;
                        Afp_record_Collection.Add(objAfp_record);
                    }
                    else if (recordID.Equals("A2G"))
                    {
                        Afp_a2g_record objAfp_a2g_record = null;
                        objAfp_a2g_record = new Afp_a2g_record();
                        objAfp_a2g_record.Afp_a2g_record1 = line;

                        objAfp_record.Aft_Record_Reference = objAfp_a2g_record;
                        Afp_record_Collection.Add(objAfp_record);
                    }
                    else if (recordID.Equals("A2S"))
                    {
                        Afp_a2s_record objAfp_a2s_record = null;
                        objAfp_a2s_record = new Afp_a2s_record();
                        objAfp_a2s_record.Afp_a2s_record1 = line;

                        objAfp_record.Aft_Record_Reference = objAfp_a2s_record;
                        Afp_record_Collection.Add(objAfp_record);
                    }
                    else if (recordID.Equals("A3C"))
                    {
                        Afp_a3c_record objAfp_a3c_record = null;
                        objAfp_a3c_record = new Afp_a3c_record();
                        objAfp_a3c_record.Afp_a3c_record1 = line;

                        objAfp_record.Aft_Record_Reference = objAfp_a3c_record;
                        Afp_record_Collection.Add(objAfp_record);
                    }
                    else if (recordID.Equals("A4T"))
                    {
                        Afp_a4t_record objAfp_a4t_record = null;
                        objAfp_a4t_record = new Afp_a4t_record();
                        objAfp_a4t_record.Afp_a4t_record1 = line;

                        objAfp_record.Aft_Record_Reference = objAfp_a4t_record;
                        Afp_record_Collection.Add(objAfp_record);
                    }
                }
            }
            return Afp_record_Collection;
        }

        public ObservableCollection<Claims_keys_record> Read_Claims_Keys_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\u030_dtl_key.sf";
            string line = string.Empty;

            ObservableCollection<Claims_keys_record> Claims_keys_record_Collection = null;
            Claims_keys_record_Collection = new ObservableCollection<Claims_keys_record>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while((line = file.ReadLine()) != null)
                {
                    Claims_keys_record objClaims_keys_record = null;
                    objClaims_keys_record = new Claims_keys_record();
                    objClaims_keys_record.B_key = line;                     
                    Claims_keys_record_Collection.Add(objClaims_keys_record);
                }
            }
            return Claims_keys_record_Collection;
        }

        public ObservableCollection<R004_Work_file_rec> Read_R004WF_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r004wf";
            string line = string.Empty;

            ObservableCollection<R004_Work_file_rec> R004_Work_file_rec_Collection = null;
            R004_Work_file_rec_Collection = new ObservableCollection<R004_Work_file_rec>();

            using (StreamReader file = new StreamReader(filePath))
            {
                line = file.ReadToEnd();
                if (line != null)
                {
                    bool eoline = false;
                    while (!eoline)
                    {
                        string tmpLine = line.Substring(0, 110);
                        if (line.Trim().Length > 110)
                        {
                            line = line.Substring(110);
                        }
                        else
                        {
                            line = line.PadRight(110);
                            eoline = true;
                        }

                        R004_Work_file_rec objR004_Work_file_rec = null;
                        objR004_Work_file_rec = new R004_Work_file_rec();

                        objR004_Work_file_rec.Wf_dept = Util.NumInt(tmpLine.Substring(0, 2));
                        objR004_Work_file_rec.Wf_doc_nbr = tmpLine.Substring(2, 3);
                        objR004_Work_file_rec.Wf_pat_surname = tmpLine.Substring(5, 6);
                        objR004_Work_file_rec.Wf_pat_acronym3 = tmpLine.Substring(11, 3);
                        objR004_Work_file_rec.Wf_claim_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(14, 2));
                        objR004_Work_file_rec.Wf_claim_doctor_nbr = tmpLine.Substring(16, 3);
                        objR004_Work_file_rec.Wf_claim_week = Util.NumInt(tmpLine.Substring(19, 2));
                        objR004_Work_file_rec.Wf_claim_day = Util.NumInt(tmpLine.Substring(21, 1));
                        objR004_Work_file_rec.Wf_claim_nbr = Util.NumInt(tmpLine.Substring(22, 2));
                        objR004_Work_file_rec.Wf_pat_id_or_chart = tmpLine.Substring(24, 15);
                        objR004_Work_file_rec.Wf_agent_cd = Util.NumInt(tmpLine.Substring(39, 1));
                        objR004_Work_file_rec.Wf_adj_cd = tmpLine.Substring(40, 1);
                        objR004_Work_file_rec.Wf_payroll = tmpLine.Substring(41, 1);
                        objR004_Work_file_rec.Wf_claim_oma = Util.NumDec(tmpLine.Substring(42, 7));    // 05  wf-claim-oma				pic s9(5)v99.  ???                        
                        objR004_Work_file_rec.Wf_claim_ohip = Util.NumDec(tmpLine.Substring(49, 7));   // 05  wf-claim-ohip				pic s9(5)v99.                       
                        objR004_Work_file_rec.Wf_service_date_yy = Util.NumInt(tmpLine.Substring(56, 4));
                        objR004_Work_file_rec.Wf_service_date_mm = Util.NumInt(tmpLine.Substring(60, 2));
                        objR004_Work_file_rec.Wf_service_date_dd = Util.NumInt(tmpLine.Substring(62, 2));
                        objR004_Work_file_rec.Wf_claim_date_sys_yy = Util.NumInt(tmpLine.Substring(64, 4));
                        objR004_Work_file_rec.Wf_claim_date_sys_mm = Util.NumInt(tmpLine.Substring(68, 2));
                        objR004_Work_file_rec.Wf_claim_date_sys_dd = Util.NumInt(tmpLine.Substring(70, 2));
                        objR004_Work_file_rec.Wf_diag_cd = Util.NumInt(tmpLine.Substring(72, 3));
                        objR004_Work_file_rec.Wf_oma_cd = tmpLine.Substring(75, 4);
                        objR004_Work_file_rec.Wf_oma_suff = tmpLine.Substring(79, 1);
                        objR004_Work_file_rec.Wf_nbr_serv = Util.NumInt(tmpLine.Substring(80, 2));
                        objR004_Work_file_rec.Wf_orig_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(82, 2));
                        objR004_Work_file_rec.Wf_orig_doc_nbr = tmpLine.Substring(84, 3);
                        objR004_Work_file_rec.Wf_orig_week = tmpLine.Substring(87, 2);
                        objR004_Work_file_rec.Wf_orig_day = tmpLine.Substring(89, 1);
                        objR004_Work_file_rec.Wf_orig_claim_nbr = Util.NumInt(tmpLine.Substring(90, 2));
                        objR004_Work_file_rec.Wf_ref_field = tmpLine.Substring(92, 9);
                        objR004_Work_file_rec.Wf_trans_cd = tmpLine.Substring(101, 1);
                        objR004_Work_file_rec.Wf_amt_tech_billed = Util.NumDec(tmpLine.Substring(102, 8));        // 05  wf-amt-tech-billed			pic s9(5)v99.                  
                        objR004_Work_file_rec.Wf_adj_cd_sub_type = tmpLine.Substring(110, 1);

                        R004_Work_file_rec_Collection.Add(objR004_Work_file_rec);
                    }
                }
            }
            return R004_Work_file_rec_Collection;
        }

        public ObservableCollection<R004_Work_file_rec> Read_R004WF_After_Sorted_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r004_sort_work_mstr";
            string line = string.Empty;

            ObservableCollection<R004_Work_file_rec> R004_Work_file_rec_Collection = null;
            R004_Work_file_rec_Collection = new ObservableCollection<R004_Work_file_rec>();

            using (StreamReader file = new StreamReader(filePath))
            {
                line = file.ReadToEnd();
                if (line != null)
                {
                    bool eoline = false;
                    while (!eoline)
                    {
                        string tmpLine = line.Substring(0, 110);
                        if (line.Trim().Length > 110)
                        {
                            line = line.Substring(110);
                        }
                        else
                        {
                            line = line.PadRight(110);
                            eoline = true;
                        }

                        R004_Work_file_rec objR004_Work_file_rec = null;
                        objR004_Work_file_rec = new R004_Work_file_rec();

                        objR004_Work_file_rec.Wf_dept = Util.NumInt(tmpLine.Substring(0, 2));
                        objR004_Work_file_rec.Wf_doc_nbr = tmpLine.Substring(2, 3);
                        objR004_Work_file_rec.Wf_pat_surname = tmpLine.Substring(5, 6);
                        objR004_Work_file_rec.Wf_pat_acronym3 = tmpLine.Substring(11, 3);
                        objR004_Work_file_rec.Wf_claim_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(14, 2));
                        objR004_Work_file_rec.Wf_claim_doctor_nbr = tmpLine.Substring(16, 3);
                        objR004_Work_file_rec.Wf_claim_week = Util.NumInt(tmpLine.Substring(19, 2));
                        objR004_Work_file_rec.Wf_claim_day = Util.NumInt(tmpLine.Substring(21, 1));
                        objR004_Work_file_rec.Wf_claim_nbr = Util.NumInt(tmpLine.Substring(22, 2));
                        objR004_Work_file_rec.Wf_pat_id_or_chart = tmpLine.Substring(24, 15);
                        objR004_Work_file_rec.Wf_agent_cd = Util.NumInt(tmpLine.Substring(39, 1));
                        objR004_Work_file_rec.Wf_adj_cd = tmpLine.Substring(40, 1);
                        objR004_Work_file_rec.Wf_payroll = tmpLine.Substring(41, 1);
                        objR004_Work_file_rec.Wf_claim_oma = Util.NumDec(tmpLine.Substring(42, 7));
                        objR004_Work_file_rec.Wf_claim_ohip = Util.NumDec(tmpLine.Substring(49, 7));
                        objR004_Work_file_rec.Wf_service_date_yy = Util.NumInt(tmpLine.Substring(56, 4));
                        objR004_Work_file_rec.Wf_service_date_mm = Util.NumInt(tmpLine.Substring(60, 2));
                        objR004_Work_file_rec.Wf_service_date_dd = Util.NumInt(tmpLine.Substring(62, 2));
                        objR004_Work_file_rec.Wf_claim_date_sys_yy = Util.NumInt(tmpLine.Substring(64, 4));
                        objR004_Work_file_rec.Wf_claim_date_sys_mm = Util.NumInt(tmpLine.Substring(68, 2));
                        objR004_Work_file_rec.Wf_claim_date_sys_dd = Util.NumInt(tmpLine.Substring(70, 2));
                        objR004_Work_file_rec.Wf_diag_cd = Util.NumInt(tmpLine.Substring(72, 3));
                        objR004_Work_file_rec.Wf_oma_cd = tmpLine.Substring(75, 4);
                        objR004_Work_file_rec.Wf_oma_suff = tmpLine.Substring(79, 1);
                        objR004_Work_file_rec.Wf_nbr_serv = Util.NumInt(tmpLine.Substring(80, 2));
                        objR004_Work_file_rec.Wf_orig_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(82, 2));
                        objR004_Work_file_rec.Wf_orig_doc_nbr = tmpLine.Substring(84, 3);
                        objR004_Work_file_rec.Wf_orig_week = tmpLine.Substring(87, 2);
                        objR004_Work_file_rec.Wf_orig_day = tmpLine.Substring(89, 1);
                        objR004_Work_file_rec.Wf_orig_claim_nbr = Util.NumInt(tmpLine.Substring(90, 2));
                        objR004_Work_file_rec.Wf_ref_field = tmpLine.Substring(92, 9);
                        objR004_Work_file_rec.Wf_trans_cd = tmpLine.Substring(101, 1);
                        objR004_Work_file_rec.Wf_amt_tech_billed = Util.NumDec(tmpLine.Substring(102, 8));
                        objR004_Work_file_rec.Wf_adj_cd_sub_type = tmpLine.Substring(110, 1);

                        R004_Work_file_rec_Collection.Add(objR004_Work_file_rec);
                    }
                }
            }
            return R004_Work_file_rec_Collection;
        }

        public ObservableCollection<Parm_file_rec> Read_Parm_File_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r004_parm_file";
            string line = string.Empty;

            ObservableCollection<Parm_file_rec> Parm_file_rec_Collection = null;
            Parm_file_rec_Collection = new ObservableCollection<Parm_file_rec>();

            using (StreamReader file = new StreamReader(filePath))
            {
                line = file.ReadToEnd();
                if (line != null)
                {
                    bool eoline = false;
                    while (!eoline)
                    {
                        string tmpLine = line.Substring(0, 30);
                        if (line.Trim().Length > 30)
                        {
                            line = line.Substring(30);
                        }
                        else
                        {
                            line = line.PadRight(30);
                            eoline = true;
                        }

                        Parm_file_rec objParm_file_rec = null;
                        objParm_file_rec = new Parm_file_rec();

                        objParm_file_rec.Parm_clinic_nbr = tmpLine.Substring(0, 2);
                        objParm_file_rec.Parm_clinic_name = tmpLine.Substring(2, 20);
                        objParm_file_rec.Parm_ped_yy = Util.NumInt(tmpLine.Substring(22, 4));
                        objParm_file_rec.Parm_ped_mm = Util.NumInt(tmpLine.Substring(26, 2));
                        objParm_file_rec.Parm_ped_dd = Util.NumInt(tmpLine.Substring(28, 2));

                        Parm_file_rec_Collection.Add(objParm_file_rec);
                    }
                }
            }
            return Parm_file_rec_Collection;
        }

        public ObservableCollection<Parm_file_rec> Read_R051_parm_file()
        {

            string filePath = Directory.GetCurrentDirectory() + "\\r051_parm_file";
            string line = string.Empty;

            ObservableCollection<Parm_file_rec> Parm_file_Collection = null;
            Parm_file_Collection = new ObservableCollection<Parm_file_rec>();

            using (StreamReader file = new StreamReader(filePath))
            {
                line = file.ReadToEnd();
                if (line != null)
                {
                    bool eoline = false;
                    while (!eoline)
                    {
                        string tmpLine = line.Substring(0, 36);
                        if (line.Trim().Length > 36)
                        {
                            line = line.Substring(36);
                        }
                        else
                        {
                            line = line.PadRight(36);
                            eoline = true;
                        }

                        Parm_file_rec objParm_file_rec = null;
                        objParm_file_rec = new Parm_file_rec();

                        objParm_file_rec.Parm_status = Util.NumInt(tmpLine.Substring(0, 1));
                        objParm_file_rec.Parm_program_nbr = tmpLine.Substring(1, 5);
                        objParm_file_rec.Parm_clinic_nbr = tmpLine.Substring(6, 2);
                        objParm_file_rec.Parm_clinic_name = tmpLine.Substring(8, 20);
                        objParm_file_rec.Parm_ped_yy = Util.NumInt(tmpLine.Substring(28, 4));
                        objParm_file_rec.Parm_ped_mm = Util.NumInt(tmpLine.Substring(32, 2));
                        objParm_file_rec.Parm_ped_dd = Util.NumInt(tmpLine.Substring(34, 2));
                        Parm_file_Collection.Add(objParm_file_rec);
                    }
                }
            }
            return Parm_file_Collection;
        }

        public void Update_R051_Parm_File(ObservableCollection<Parm_file_rec> parm_file_Collection, bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r051_parm_file";

            StringBuilder str = null;
            str = new StringBuilder();

            if (File.Exists(filePath))
            {
                foreach (var obj in parm_file_Collection)
                {
                    if (lineFeed)
                    {
                        str.Append(Util.Str(obj.Parm_status).PadLeft(1, '0') +
                                          Util.Str(obj.Parm_program_nbr).PadRight(5) +
                                          Util.Str(obj.Parm_clinic_nbr).PadRight(2) +
                                          Util.Str(obj.Parm_clinic_name).PadRight(20) +
                                          Util.Str(obj.Parm_ped_yy).PadLeft(4, '0') +
                                          Util.Str(obj.Parm_ped_mm).PadLeft(2, '0') +
                                          Util.Str(obj.Parm_ped_dd).PadLeft(2, '0'));
                        str.Append(Environment.NewLine);
                    }
                    else
                    {
                        str.Append(Util.Str(obj.Parm_status).PadLeft(1, '0') +
                                          Util.Str(obj.Parm_program_nbr).PadRight(5) +
                                          Util.Str(obj.Parm_clinic_nbr).PadRight(2) +
                                          Util.Str(obj.Parm_clinic_name).PadRight(20) +
                                          Util.Str(obj.Parm_ped_yy).PadLeft(4, '0') +
                                          Util.Str(obj.Parm_ped_mm).PadLeft(2, '0') +
                                          Util.Str(obj.Parm_ped_dd).PadLeft(2, '0'));
                    }
                }
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.Write(str.ToString());
                }
            }
        }

        public ObservableCollection<r051_work_rec> Read_R051_Work_Rec_SequentialFile(bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r051wf";
            string line = string.Empty;

            ObservableCollection<r051_work_rec> r051_work_rec_Collection = null;
            r051_work_rec_Collection = new ObservableCollection<r051_work_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        r051_work_rec objr051_work_rec = null;
                        objr051_work_rec = new r051_work_rec();

                        line = line.PadRight(49);
                        objr051_work_rec.wf_dept = Util.NumInt(line.Substring(0, 2));
                        objr051_work_rec.wf_class_code = line.Substring(2, 1);
                        objr051_work_rec.wf_doc_nbr = line.Substring(3, 3);
                        objr051_work_rec.wf_oma_code_ltr = line.Substring(6, 1);
                        objr051_work_rec.filler = line.Substring(7, 4);
                        objr051_work_rec.wf_oma_cd = objr051_work_rec.wf_oma_code_ltr + objr051_work_rec.filler;
                        objr051_work_rec.wf_mtd_svcs = Util.NumInt(line.Substring(11, 8));
                        objr051_work_rec.wf_mtd_amt = Util.Str(line.Substring(19, 11));
                        objr051_work_rec.wf_ytd_svcs = Util.NumInt(line.Substring(30, 8));
                        objr051_work_rec.wf_ytd_amt = Util.Str(line.Substring(38, 11));
                        r051_work_rec_Collection.Add(objr051_work_rec);
                    }
                }
                else
                {
                    line = sr.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            string tmpLine = line.Substring(0, 49);
                            if (line.Trim().Length > 49)
                            {
                                line = line.Substring(49);
                            }
                            else
                            {
                                line = line.PadRight(49);
                                eoline = true;
                            }
                            r051_work_rec objr051_work_rec = null;
                            objr051_work_rec = new r051_work_rec();

                            objr051_work_rec.wf_dept = Util.NumInt(tmpLine.Substring(0, 2));
                            objr051_work_rec.wf_class_code = tmpLine.Substring(2, 1);
                            objr051_work_rec.wf_doc_nbr = tmpLine.Substring(3, 3);
                            objr051_work_rec.wf_oma_code_ltr = tmpLine.Substring(6, 1);
                            objr051_work_rec.filler = tmpLine.Substring(7, 4);
                            objr051_work_rec.wf_oma_cd = objr051_work_rec.wf_oma_code_ltr + objr051_work_rec.filler;
                            objr051_work_rec.wf_mtd_svcs = Util.NumInt(tmpLine.Substring(11, 8));
                            objr051_work_rec.wf_mtd_amt = Util.Str(tmpLine.Substring(19, 11));
                            objr051_work_rec.wf_ytd_svcs = Util.NumInt(tmpLine.Substring(30, 8));
                            objr051_work_rec.wf_ytd_amt = Util.Str(tmpLine.Substring(38, 11));
                            r051_work_rec_Collection.Add(objr051_work_rec);
                        }
                    }
                }
            }

            return r051_work_rec_Collection;
        }

        public ObservableCollection<r051_work_rec> Read_R051_Sort_Work_Mstr(bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r051_sort_work_mstr";
            string line = string.Empty;

            ObservableCollection<r051_work_rec> R051_Sort_Work_Mstr_Collection = null;
            R051_Sort_Work_Mstr_Collection = new ObservableCollection<r051_work_rec>();

            using (StreamReader file = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        r051_work_rec objr051_work_rec = null;
                        objr051_work_rec = new r051_work_rec();

                        line = line.PadRight(49);
                        objr051_work_rec.wf_dept = Util.NumInt(line.Substring(0, 2));
                        objr051_work_rec.wf_class_code = line.Substring(2, 1);
                        objr051_work_rec.wf_doc_nbr = line.Substring(3, 3);
                        objr051_work_rec.wf_oma_code_ltr = line.Substring(6, 1);
                        objr051_work_rec.filler = line.Substring(7, 4);
                        objr051_work_rec.wf_oma_cd = objr051_work_rec.wf_oma_code_ltr + objr051_work_rec.filler;
                        objr051_work_rec.wf_mtd_svcs = Util.NumInt(line.Substring(11, 8));
                        objr051_work_rec.wf_mtd_amt = Util.Str(line.Substring(19, 11));
                        objr051_work_rec.wf_ytd_svcs = Util.NumInt(line.Substring(30, 8));
                        objr051_work_rec.wf_ytd_amt = Util.Str(line.Substring(38, 11));
                        R051_Sort_Work_Mstr_Collection.Add(objr051_work_rec);
                    }
                }
                else
                {
                    line = file.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            string tmpLine = line.Substring(0, 49);
                            if (line.Trim().Length > 49)
                            {
                                line = line.Substring(49);
                            }
                            else
                            {
                                line = line.PadRight(49);
                                eoline = true;
                            }

                            r051_work_rec objr051_work_rec = null;
                            objr051_work_rec = new r051_work_rec();

                            objr051_work_rec.wf_dept = Util.NumInt(tmpLine.Substring(0, 2));
                            objr051_work_rec.wf_class_code = tmpLine.Substring(2, 1);
                            objr051_work_rec.wf_doc_nbr = tmpLine.Substring(3, 3);
                            objr051_work_rec.wf_oma_code_ltr = tmpLine.Substring(6, 1);
                            objr051_work_rec.filler = tmpLine.Substring(7, 4);
                            objr051_work_rec.wf_oma_cd = objr051_work_rec.wf_oma_code_ltr + objr051_work_rec.filler;
                            objr051_work_rec.wf_mtd_svcs = Util.ConvertZoneToNumeric(tmpLine.Substring(11, 8));
                            objr051_work_rec.wf_mtd_amt = Util.Str(tmpLine.Substring(19, 11));
                            objr051_work_rec.wf_ytd_svcs = Util.ConvertZoneToNumeric(tmpLine.Substring(30, 8));
                            objr051_work_rec.wf_ytd_amt = Util.Str(tmpLine.Substring(38, 11));
                            R051_Sort_Work_Mstr_Collection.Add(objr051_work_rec);
                        }
                    }
                }
            }
            return R051_Sort_Work_Mstr_Collection;
        }

        public ObservableCollection<Claims_work_rec> Read_Claims_Work_Rec(string clinic_nbr, bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r070_work_mstr_" + clinic_nbr;
            string line = string.Empty;

            ObservableCollection<Claims_work_rec> claims_work_rec_Collection = null;
            claims_work_rec_Collection = new ObservableCollection<Claims_work_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Claims_work_rec objClaims_work_rec = null;
                        objClaims_work_rec = new Claims_work_rec();

                        line = line.PadRight(114);

                        objClaims_work_rec.Wk_dept_nbr = Util.NumInt(line.Substring(0, 2));
                        objClaims_work_rec.Wk_sort_record_status = Util.NumInt(line.Substring(2, 1));
                        objClaims_work_rec.Wk_agent_cd = Util.NumInt(line.Substring(3, 1));
                        objClaims_work_rec.Wk_age_category = Util.NumInt(line.Substring(4, 1));
                        objClaims_work_rec.Wk_pat_acronym = line.Substring(5, 9);
                        objClaims_work_rec.Wk_pat_id_1 = line.Substring(14, 3);
                        objClaims_work_rec.Wk_pat_id_2 = line.Substring(17, 12);
                        objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(line.Substring(29, 2));
                        objClaims_work_rec.Wk_doc_nbr = line.Substring(31, 3);
                        objClaims_work_rec.Wk_week = Util.NumInt(line.Substring(34, 2));
                        objClaims_work_rec.Wk_day = Util.NumInt(line.Substring(36, 1));
                        objClaims_work_rec.Wk_claim_nbr = Util.NumInt(line.Substring(37, 2));
                        objClaims_work_rec.Wk_ohip_stat_1 = line.Substring(39, 1);
                        objClaims_work_rec.Wk_ohip_stat_2 = line.Substring(40, 1);
                        objClaims_work_rec.Wk_sub_nbr = line.Substring(41, 1);
                        objClaims_work_rec.Wk_oma_fee = Util.ConvertZoneToNumeric(line.Substring(42, 8));
                        objClaims_work_rec.Wk_ohip_fee = Util.ConvertZoneToNumeric(line.Substring(50, 8));
                        objClaims_work_rec.Wk_amount_paid = Util.ConvertZoneToNumeric(line.Substring(58, 8));
                        objClaims_work_rec.Wk_balance_due = Util.ConvertZoneToNumeric(line.Substring(66, 8));
                        objClaims_work_rec.Wk_period_end_yy = Util.NumInt(line.Substring(74, 4));
                        objClaims_work_rec.Wk_period_end_mm = Util.NumInt(line.Substring(78, 2));
                        objClaims_work_rec.Wk_period_end_dd = Util.NumInt(line.Substring(80, 2));
                        objClaims_work_rec.Wk_ser_yy = Util.NumInt(line.Substring(82, 4));   // 4                                                                                            
                        objClaims_work_rec.Wk_ser_mm = Util.NumInt(line.Substring(86, 2));
                        objClaims_work_rec.Wk_ser_dd = Util.NumInt(line.Substring(88, 2));
                        objClaims_work_rec.Wk_day_old = line.Substring(90, 3);
                        objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(line.Substring(93, 2));
                        objClaims_work_rec.Wk_batch_nbr_4_9 = line.Substring(95, 6);
                        objClaims_work_rec.Wk_tape_submit_ind = line.Substring(101, 1);
                        objClaims_work_rec.Wk_act_taken_1 = line.Substring(102, 3);
                        objClaims_work_rec.Wk_act_taken_2 = line.Substring(105, 8);

                        claims_work_rec_Collection.Add(objClaims_work_rec);
                    }
                }
                else
                {
                    line = sr.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            string tmpLine = line.Substring(0, 114);
                            if (line.Trim().Length > 114)
                            {
                                line = line.Substring(114);
                            }
                            else
                            {
                                line = line.PadRight(114);
                                eoline = true;
                            }
                            Claims_work_rec objClaims_work_rec = null;
                            objClaims_work_rec = new Claims_work_rec();

                            objClaims_work_rec.Wk_dept_nbr = Util.NumInt(tmpLine.Substring(0, 2));
                            objClaims_work_rec.Wk_sort_record_status = Util.NumInt(tmpLine.Substring(2, 1));
                            objClaims_work_rec.Wk_agent_cd = Util.NumInt(tmpLine.Substring(3, 1));
                            objClaims_work_rec.Wk_age_category = Util.NumInt(tmpLine.Substring(4, 1));
                            objClaims_work_rec.Wk_pat_acronym = tmpLine.Substring(5, 9);
                            objClaims_work_rec.Wk_pat_id_1 = tmpLine.Substring(14, 3);
                            objClaims_work_rec.Wk_pat_id_2 = tmpLine.Substring(17, 12);
                            objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(tmpLine.Substring(29, 2));
                            objClaims_work_rec.Wk_doc_nbr = tmpLine.Substring(31, 3);
                            objClaims_work_rec.Wk_week = Util.NumInt(tmpLine.Substring(34, 2));
                            objClaims_work_rec.Wk_day = Util.NumInt(tmpLine.Substring(36, 1));
                            objClaims_work_rec.Wk_claim_nbr = Util.NumInt(tmpLine.Substring(37, 2));
                            objClaims_work_rec.Wk_ohip_stat_1 = tmpLine.Substring(39, 1);
                            objClaims_work_rec.Wk_ohip_stat_2 = tmpLine.Substring(40, 1);
                            objClaims_work_rec.Wk_sub_nbr = tmpLine.Substring(41, 1);
                            objClaims_work_rec.Wk_oma_fee = Util.ConvertZoneToNumeric(tmpLine.Substring(42, 8));
                            objClaims_work_rec.Wk_ohip_fee = Util.ConvertZoneToNumeric(tmpLine.Substring(50, 8));
                            objClaims_work_rec.Wk_amount_paid = Util.ConvertZoneToNumeric(tmpLine.Substring(58, 8));
                            objClaims_work_rec.Wk_balance_due = Util.ConvertZoneToNumeric(tmpLine.Substring(66, 8));
                            objClaims_work_rec.Wk_period_end_yy = Util.NumInt(tmpLine.Substring(74, 4));
                            objClaims_work_rec.Wk_period_end_mm = Util.NumInt(tmpLine.Substring(78, 2));
                            objClaims_work_rec.Wk_period_end_dd = Util.NumInt(tmpLine.Substring(80, 2));
                            objClaims_work_rec.Wk_ser_yy = Util.NumInt(tmpLine.Substring(82, 4));   // 4                                                                                                    
                            objClaims_work_rec.Wk_ser_mm = Util.NumInt(tmpLine.Substring(86, 2));
                            objClaims_work_rec.Wk_ser_dd = Util.NumInt(tmpLine.Substring(88, 2));
                            objClaims_work_rec.Wk_day_old = tmpLine.Substring(90, 3);
                            objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(tmpLine.Substring(93, 2));
                            objClaims_work_rec.Wk_batch_nbr_4_9 = tmpLine.Substring(95, 6);
                            objClaims_work_rec.Wk_tape_submit_ind = tmpLine.Substring(101, 1);
                            objClaims_work_rec.Wk_act_taken_1 = tmpLine.Substring(102, 3);
                            objClaims_work_rec.Wk_act_taken_2 = tmpLine.Substring(105, 8);

                            claims_work_rec_Collection.Add(objClaims_work_rec);
                        }
                    }
                }
            }
            return claims_work_rec_Collection;
        }

        public ObservableCollection<Param_file_rec> Read_Param_file_rec_Collection()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r070_par_file";
            string line = string.Empty;

            //52
            ObservableCollection<Param_file_rec> param_file_rec_Collection = null;
            param_file_rec_Collection = new ObservableCollection<Param_file_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                line = sr.ReadToEnd();
                if (line != null)
                {
                    bool eoline = false;
                    while (!eoline)
                    {

                        string tmpLine = line.Substring(0, 52);
                        if (line.Trim().Length > 52)
                        {
                            line = line.Substring(52);
                        }
                        else
                        {
                            line = line.PadRight(52);
                            eoline = true;
                        }

                        Param_file_rec objParam_file_rec = null;
                        objParam_file_rec = new Param_file_rec();


                        // Util.Str(objParam_file_rec.Param_clinic_nbr_1_2).PadLeft(2, '0') +
                        objParam_file_rec.Param_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(0, 2));
                        //Util.Str(objParam_file_rec.Param_clinic_nbr).PadLeft(4, '0') +
                        objParam_file_rec.Param_clinic_nbr = Util.NumInt(tmpLine.Substring(2, 4));
                        //Util.Str(objParam_file_rec.Param_clinic_name).PadRight(20) +
                        objParam_file_rec.Param_clinic_name = tmpLine.Substring(6, 20);
                        //Util.Str(objParam_file_rec.Param_date_period_end_yy).PadLeft(4, '0') +
                        objParam_file_rec.Param_date_period_end_yy = Util.NumInt(tmpLine.Substring(26, 4));
                        //Util.Str(objParam_file_rec.Param_date_period_end_dd).PadLeft(2, '0') +
                        objParam_file_rec.Param_date_period_end_dd = Util.NumInt(tmpLine.Substring(30, 2));
                        //Util.Str(objParam_file_rec.Param_date_period_end_mm).PadRight(11) +
                        objParam_file_rec.Param_date_period_end_mm = tmpLine.Substring(32, 11);
                        //Util.Str(objParam_file_rec.Param_date_yy).PadLeft(4, '0') +
                        objParam_file_rec.Param_date_yy = Util.NumInt(tmpLine.Substring(43, 4));
                        //Util.Str(objParam_file_rec.Param_date_mm).PadLeft(2, '0') +
                        objParam_file_rec.Param_date_mm = Util.NumInt(tmpLine.Substring(47, 2));
                        //Util.Str(objParam_file_rec.Param_date_dd).PadRight(1) +
                        objParam_file_rec.Param_date_dd = Util.NumInt(tmpLine.Substring(49, 1));
                        //Util.Str(objParam_file_rec.Filler).PadRight(1);
                        objParam_file_rec.Filler = tmpLine.Substring(50, 1);

                        param_file_rec_Collection.Add(objParam_file_rec);
                    }
                }
            }
            return param_file_rec_Collection;
        }

        public ObservableCollection<Claims_work_rec> Read_r070_srt_work_mstr(string work_file_clinic_nbr, bool lineFeed = true)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\r070_srt_work_mstr_" + work_file_clinic_nbr;
            string line = string.Empty;

            ObservableCollection<Claims_work_rec> Claims_work_rec_Collection = null;
            Claims_work_rec_Collection = new ObservableCollection<Claims_work_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Claims_work_rec objClaims_work_rec = null;
                        objClaims_work_rec = new Claims_work_rec();

                        line = line.PadRight(114);

                        objClaims_work_rec.Wk_dept_nbr = Util.NumInt(line.Substring(0, 2));
                        objClaims_work_rec.Wk_sort_record_status = Util.NumInt(line.Substring(2, 1));
                        objClaims_work_rec.Wk_agent_cd = Util.NumInt(line.Substring(3, 1));
                        objClaims_work_rec.Wk_age_category = Util.NumInt(line.Substring(4, 1));
                        objClaims_work_rec.Wk_pat_acronym = line.Substring(5, 9);
                        objClaims_work_rec.Wk_pat_id_1 = line.Substring(14, 3);
                        objClaims_work_rec.Wk_pat_id_2 = line.Substring(17, 12);
                        objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(line.Substring(29, 2));
                        objClaims_work_rec.Wk_doc_nbr = line.Substring(31, 3);
                        objClaims_work_rec.Wk_week = Util.NumInt(line.Substring(34, 2));
                        objClaims_work_rec.Wk_day = Util.NumInt(line.Substring(36, 1));
                        objClaims_work_rec.Wk_claim_nbr = Util.NumInt(line.Substring(37, 2));
                        objClaims_work_rec.Wk_ohip_stat_1 = line.Substring(39, 1);
                        objClaims_work_rec.Wk_ohip_stat_2 = line.Substring(40, 1);
                        objClaims_work_rec.Wk_sub_nbr = line.Substring(41, 1);
                        objClaims_work_rec.Wk_oma_fee = Util.ConvertZoneToNumeric(line.Substring(42, 8));
                        objClaims_work_rec.Wk_ohip_fee = Util.ConvertZoneToNumeric(line.Substring(50, 8));
                        objClaims_work_rec.Wk_amount_paid = Util.ConvertZoneToNumeric(line.Substring(58, 8));
                        objClaims_work_rec.Wk_balance_due = Util.ConvertZoneToNumeric(line.Substring(66, 8));
                        objClaims_work_rec.Wk_period_end_yy = Util.NumInt(line.Substring(74, 4));
                        objClaims_work_rec.Wk_period_end_mm = Util.NumInt(line.Substring(78, 2));
                        objClaims_work_rec.Wk_period_end_dd = Util.NumInt(line.Substring(80, 2));
                        objClaims_work_rec.Wk_ser_yy = Util.NumInt(line.Substring(82, 4));
                        objClaims_work_rec.Wk_ser_mm = Util.NumInt(line.Substring(86, 2));
                        objClaims_work_rec.Wk_ser_dd = Util.NumInt(line.Substring(88, 2));
                        objClaims_work_rec.Wk_day_old = line.Substring(90, 3);
                        objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(line.Substring(93, 2));
                        objClaims_work_rec.Wk_batch_nbr_4_9 = line.Substring(95, 6);
                        objClaims_work_rec.Wk_tape_submit_ind = line.Substring(101, 1);
                        objClaims_work_rec.Wk_act_taken_1 = line.Substring(102, 3);
                        objClaims_work_rec.Wk_act_taken_2 = line.Substring(105, 8);
                        Claims_work_rec_Collection.Add(objClaims_work_rec);
                    }
                }
                else
                {
                    line = sr.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while (!eoline)
                        {
                            string tmpLine = line.Substring(0, 114);
                            if (line.Trim().Length > 114)
                            {
                                line = line.Substring(114);
                            }
                            else
                            {
                                line = line.PadRight(114);
                                eoline = true;
                            }

                            Claims_work_rec objClaims_work_rec = null;
                            objClaims_work_rec = new Claims_work_rec();

                            objClaims_work_rec.Wk_dept_nbr = Util.NumInt(tmpLine.Substring(0, 2));
                            objClaims_work_rec.Wk_sort_record_status = Util.NumInt(tmpLine.Substring(2, 1));
                            objClaims_work_rec.Wk_agent_cd = Util.NumInt(tmpLine.Substring(3, 1));
                            objClaims_work_rec.Wk_age_category = Util.NumInt(tmpLine.Substring(4, 1));
                            objClaims_work_rec.Wk_pat_acronym = tmpLine.Substring(5, 9);
                            objClaims_work_rec.Wk_pat_id_1 = tmpLine.Substring(14, 3);
                            objClaims_work_rec.Wk_pat_id_2 = tmpLine.Substring(17, 12);
                            objClaims_work_rec.Wk_clinic_nbr = Util.NumInt(tmpLine.Substring(29, 2));
                            objClaims_work_rec.Wk_doc_nbr = tmpLine.Substring(31, 3);
                            objClaims_work_rec.Wk_week = Util.NumInt(tmpLine.Substring(34, 2));
                            objClaims_work_rec.Wk_day = Util.NumInt(tmpLine.Substring(36, 1));
                            objClaims_work_rec.Wk_claim_nbr = Util.NumInt(tmpLine.Substring(37, 2));
                            objClaims_work_rec.Wk_ohip_stat_1 = tmpLine.Substring(39, 1);
                            objClaims_work_rec.Wk_ohip_stat_2 = tmpLine.Substring(40, 1);
                            objClaims_work_rec.Wk_sub_nbr = tmpLine.Substring(41, 1);
                            objClaims_work_rec.Wk_oma_fee = Util.ConvertZoneToNumeric(tmpLine.Substring(42, 8));
                            objClaims_work_rec.Wk_ohip_fee = Util.ConvertZoneToNumeric(tmpLine.Substring(50, 8));
                            objClaims_work_rec.Wk_amount_paid = Util.ConvertZoneToNumeric(tmpLine.Substring(58, 8));
                            objClaims_work_rec.Wk_balance_due = Util.ConvertZoneToNumeric(tmpLine.Substring(66, 8));
                            objClaims_work_rec.Wk_period_end_yy = Util.NumInt(tmpLine.Substring(74, 4));
                            objClaims_work_rec.Wk_period_end_mm = Util.NumInt(tmpLine.Substring(78, 2));
                            objClaims_work_rec.Wk_period_end_dd = Util.NumInt(tmpLine.Substring(80, 2));
                            objClaims_work_rec.Wk_ser_yy = Util.NumInt(tmpLine.Substring(82, 4));
                            objClaims_work_rec.Wk_ser_mm = Util.NumInt(tmpLine.Substring(86, 2));
                            objClaims_work_rec.Wk_ser_dd = Util.NumInt(tmpLine.Substring(88, 2));
                            objClaims_work_rec.Wk_day_old = tmpLine.Substring(90, 3);
                            objClaims_work_rec.Wk_batch_nbr_1_2 = Util.NumInt(tmpLine.Substring(93, 2));
                            objClaims_work_rec.Wk_batch_nbr_4_9 = tmpLine.Substring(95, 6);
                            objClaims_work_rec.Wk_tape_submit_ind = tmpLine.Substring(101, 1);
                            objClaims_work_rec.Wk_act_taken_1 = tmpLine.Substring(102, 3);
                            objClaims_work_rec.Wk_act_taken_2 = tmpLine.Substring(105, 8);
                            Claims_work_rec_Collection.Add(objClaims_work_rec);
                        }
                    }
                }
            }
            return Claims_work_rec_Collection;
        }

        public ObservableCollection<Edt_1_record> Read_edt_hx_error_file()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\u021a";
            string line = string.Empty;

            ObservableCollection<Edt_1_record> Edt_1_record_Collection = null;
            Edt_1_record_Collection = new ObservableCollection<Edt_1_record>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.PadRight(79);
                    string transCD = line.Substring(0, 2);
                    string recordType = line.Substring(2, 1);

                    Edt_1_record objEdt_1_record = null;
                    objEdt_1_record = new Edt_1_record();

                    objEdt_1_record.Edt_1_trans_cd = transCD;
                    objEdt_1_record.Edt_1_record_type = recordType;

                    if (recordType.Equals("todo1"))  // todo
                    {
                        objEdt_1_record.Edt_1_release_id = line.Substring(3, 3);
                        objEdt_1_record.Edt_1_moh_off_cd = line.Substring(6, 1);
                        objEdt_1_record.Edt_1_filler_1 = line.Substring(7, 10);
                        objEdt_1_record.Edt_1_operator_nbr = line.Substring(17, 6);
                        objEdt_1_record.Edt_1_group_nbr = line.Substring(23, 4);
                        objEdt_1_record.Edt_1_doc_nbr = Util.NumInt(line.Substring(27, 6));
                        objEdt_1_record.Edt_1_specialty_cd = line.Substring(33, 2);
                        objEdt_1_record.Edt_1_station_nbr = line.Substring(35, 3);
                        objEdt_1_record.Edt_1_process_date_yy = Util.NumInt(line.Substring(38, 4));
                        objEdt_1_record.Edt_1_process_date_mm = Util.NumInt(line.Substring(42, 2));
                        objEdt_1_record.Edt_1_process_date_dd = Util.NumInt(line.Substring(44, 2));
                        objEdt_1_record.Edt_1_filler_2 = line.Substring(46, 33);

                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                    else if (recordType.Equals("todo2"))
                    {
                        Edt_h_record objEdt_h_record = null;
                        objEdt_h_record = new Edt_h_record();

                        objEdt_h_record.Edt_h_trans_id = line.Substring(0, 2);
                        objEdt_h_record.Edt_h_record_type = line.Substring(2, 1);
                        objEdt_h_record.Edt_h_health_nbr = line.Substring(3, 10);
                        objEdt_h_record.Edt_h_version_cd = line.Substring(13, 2);
                        objEdt_h_record.Edt_h_birth_date = line.Substring(15, 8);
                        objEdt_h_record.Edt_h_account_nbr = line.Substring(23, 8);
                        objEdt_h_record.Edt_h_pay_prog = line.Substring(31, 3);
                        objEdt_h_record.Edt_h_payee = line.Substring(34, 1);
                        objEdt_h_record.Edt_h_doc_nbr = Util.NumInt(line.Substring(35, 6));
                        objEdt_h_record.Edt_h_facility_nbr = line.Substring(41, 4);
                        objEdt_h_record.Edt_h_patient_admission_date = Util.NumInt(line.Substring(45, 8));
                        objEdt_h_record.Edt_h_refer_licence_nbr = line.Substring(53, 4);
                        objEdt_h_record.Edt_h_location_cd = line.Substring(57, 4);
                        objEdt_h_record.Edt_h_filler = line.Substring(61, 3);
                        objEdt_h_record.Edt_h_error_cd_1 = line.Substring(64, 3);
                        objEdt_h_record.Edt_h_error_cd_2 = line.Substring(67, 3);
                        objEdt_h_record.Edt_h_error_cd_3 = line.Substring(70, 3);
                        objEdt_h_record.Edt_h_error_cd_4 = line.Substring(73, 3);
                        objEdt_h_record.Edt_h_error_cd_5 = line.Substring(76, 3);

                        objEdt_1_record.Edt_Reference = objEdt_h_record;
                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                    else if (recordType.Equals("todo3"))
                    {
                        Edt_r_record objEdt_r_record = null;
                        objEdt_r_record = new Edt_r_record();

                        objEdt_r_record.Edt_r_trans_id = line.Substring(0, 2);
                        objEdt_r_record.Edt_r_record_type = line.Substring(2, 1);
                        objEdt_r_record.Edt_r_registration_nbr = line.Substring(3, 12);
                        objEdt_r_record.Edt_r_last_name = line.Substring(15, 9);
                        objEdt_r_record.Edt_r_first_name = line.Substring(24, 5);
                        objEdt_r_record.Edt_r_sex = line.Substring(29, 1);
                        objEdt_r_record.Edt_r_prov_cd = line.Substring(30, 2);
                        objEdt_r_record.Edt_r_filler = line.Substring(32, 32);
                        objEdt_r_record.Edt_r_error_cd_1 = line.Substring(64, 3);
                        objEdt_r_record.Edt_r_error_cd_2 = line.Substring(67, 3);
                        objEdt_r_record.Edt_r_error_cd_3 = line.Substring(70, 3);
                        objEdt_r_record.Edt_r_error_cd_4 = line.Substring(73, 3);
                        objEdt_r_record.Edt_r_error_cd_5 = line.Substring(76, 3);

                        objEdt_1_record.Edt_Reference = objEdt_r_record;
                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                    else if (recordType.Equals("todo4"))
                    {
                        Edt_t_record objEdt_t_record = null;
                        objEdt_t_record = new Edt_t_record();

                        objEdt_t_record.Edt_t_trans_id = line.Substring(0, 2);
                        objEdt_t_record.Edt_t_record_type = line.Substring(2, 1);
                        objEdt_t_record.Edt_t_service_cd = line.Substring(3, 5);
                        objEdt_t_record.Edt_t_filler_1 = line.Substring(8, 2);
                        objEdt_t_record.Edt_t_amount_sub = Util.NumDec(line.Substring(10, 6));
                        objEdt_t_record.Edt_t_nbr_of_serv = line.Substring(16, 2);
                        objEdt_t_record.Edt_t_service_date = line.Substring(18, 8);
                        objEdt_t_record.Edt_t_diag_cd = line.Substring(26, 4);
                        objEdt_t_record.Edt_t_filler_2 = line.Substring(30, 32);
                        objEdt_t_record.Edt_t_explan_cd = line.Substring(62, 2);
                        objEdt_t_record.Edt_t_error_cd_1 = line.Substring(64, 3);
                        objEdt_t_record.Edt_t_error_cd_2 = line.Substring(67, 3);
                        objEdt_t_record.Edt_t_error_cd_3 = line.Substring(70, 3);
                        objEdt_t_record.Edt_t_error_cd_4 = line.Substring(73, 3);
                        objEdt_t_record.Edt_t_error_cd_5 = line.Substring(76, 3);

                        objEdt_1_record.Edt_Reference = objEdt_t_record;
                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                    else if (recordType.Equals("todo5"))
                    {
                        Edt_8_record objEdt_8_record = null;
                        objEdt_8_record = new Edt_8_record();

                        objEdt_8_record.Edt_8_trans_id = line.Substring(0, 2);
                        objEdt_8_record.Edt_8_record_type = line.Substring(2, 1);
                        objEdt_8_record.Edt_8_explan_cd = line.Substring(3, 2);
                        objEdt_8_record.Edt_8_explan_desc = line.Substring(5, 55);
                        objEdt_8_record.Edt_8_filler = line.Substring(60, 19);

                        objEdt_1_record.Edt_Reference = objEdt_8_record;
                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                    else if (recordType.Equals("todo6"))
                    {
                        Edt_9_record objEdt_9_record = null;
                        objEdt_9_record = new Edt_9_record();

                        objEdt_9_record.Edt_9_trans_id = line.Substring(0, 2);
                        objEdt_9_record.Edt_9_record_type = line.Substring(2, 1);
                        objEdt_9_record.Edt_9_hdr_1_count = Util.NumInt(line.Substring(3, 7));
                        objEdt_9_record.Edt_9_hdr_2_count = Util.NumInt(line.Substring(10, 7));
                        objEdt_9_record.Edt_9_item_count = Util.NumInt(line.Substring(17, 7));
                        objEdt_9_record.Edt_9_message_count = Util.NumInt(line.Substring(24, 7));
                        objEdt_9_record.Edt_9_filler = line.Substring(31, 48);

                        objEdt_1_record.Edt_Reference = objEdt_9_record;
                        Edt_1_record_Collection.Add(objEdt_1_record);
                    }
                }
            }

            return Edt_1_record_Collection;
        }

        public ObservableCollection<Tp_pat_mstr_rec> Read_Submit_Disk_Pat_In_SequentialFile(bool lineFeed = true)
        {

            string filePath = Directory.GetCurrentDirectory() + "\\submit_disk_pat_in.sf";
            string line = string.Empty;

            ObservableCollection<Tp_pat_mstr_rec> Tp_pat_mstr_rec_Collection = new ObservableCollection<Tp_pat_mstr_rec>();

            using(StreamReader file = new StreamReader(filePath) )
            {
                if (lineFeed)
                {
                    while((line = file.ReadLine()) != null)
                    {
                        Tp_pat_mstr_rec objTp_pat_mstr_rec = null;
                        objTp_pat_mstr_rec = new Tp_pat_mstr_rec();

                        objTp_pat_mstr_rec.Tp_pat_func_code = line.Substring(0, 2);
                        objTp_pat_mstr_rec.Tp_pat_doctor_nbr = Util.NumInt(line.Substring(2, 6));
                        objTp_pat_mstr_rec.Tp_pat_account_id = line.Substring(8, 8);

                        objTp_pat_mstr_rec.Tp_pat_subscr_surname = line.Substring(16, 25);
                        objTp_pat_mstr_rec.Tp_pat_subscr_surname_6 = line.Substring(16, 6);
                        objTp_pat_mstr_rec.Tp_pat_subscr_surname_18 = line.Substring(22, 41);

                        objTp_pat_mstr_rec.Tp_pat_first_name = line.Substring(41, 24);
                        objTp_pat_mstr_rec.Tp_pat_first_name_3 = line.Substring(41, 3);
                        objTp_pat_mstr_rec.Tp_pat_first_name_21 = line.Substring(44, 21);

                        objTp_pat_mstr_rec.Tp_pat_birth_date = line.Substring(65, 8);
                        objTp_pat_mstr_rec.Tp_pat_birth_date_r = line.Substring(65, 8);
                        objTp_pat_mstr_rec.Tp_pat_birth_yy = Util.NumInt(line.Substring(65, 4));
                        objTp_pat_mstr_rec.Tp_pat_birth_mm = Util.NumInt(line.Substring(69, 2));
                        objTp_pat_mstr_rec.Tp_pat_birth_dd = Util.NumInt(line.Substring(71, 2));

                        objTp_pat_mstr_rec.Tp_pat_sex = line.Substring(73, 1);
                        objTp_pat_mstr_rec.Tp_pat_id_no = line.Substring(74, 9);

                        objTp_pat_mstr_rec.Tp_pat_id_no_r = line.Substring(74, 9);
                        objTp_pat_mstr_rec.Tp_pat_id_no_first_8_digits = line.Substring(74, 8);
                        objTp_pat_mstr_rec.Tp_pat_id_no_yy = Util.NumInt(line.Substring(74, 2));
                        objTp_pat_mstr_rec.Tp_pat_id_no_mm = Util.NumInt(line.Substring(76, 2));
                        objTp_pat_mstr_rec.Tp_pat_id_no_5_digit = line.Substring(78, 1);
                        objTp_pat_mstr_rec.Tp_pat_id_no_6_7_digit = Util.NumInt(line.Substring(79, 2));
                        objTp_pat_mstr_rec.Tp_pat_id_no_8_digit = Util.NumInt(line.Substring(81, 1));

                        objTp_pat_mstr_rec.Tp_pat_id_no_9_digit = line.Substring(82, 1);

                        objTp_pat_mstr_rec.Tp_pat_street_addr = line.Substring(83, 28);
                        objTp_pat_mstr_rec.Tp_pat_city = line.Substring(111, 18);
                        objTp_pat_mstr_rec.Tp_pat_prov = line.Substring(129, 4);
                        objTp_pat_mstr_rec.Tp_pat_postal_code = line.Substring(133, 9);

                        objTp_pat_mstr_rec.Tp_pat_postal_code_r = line.Substring(133, 9);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_1 = line.Substring(133, 1);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_2 = line.Substring(134, 1);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_3 = line.Substring(135, 1);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_4 = line.Substring(136, 1);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_5 = line.Substring(137, 1);
                        objTp_pat_mstr_rec.Tp_pat_postal_code_6 = line.Substring(138, 1);

                        objTp_pat_mstr_rec.Tp_pat_phone_no = line.Substring(142, 20);

                        objTp_pat_mstr_rec.Tp_pat_ohip_health_no = line.Substring(162, 12);
                        objTp_pat_mstr_rec.Tp_pat_health_no = line.Substring(162, 10);
                        objTp_pat_mstr_rec.Tp_pat_ohip_filler = line.Substring(172, 2);

                        objTp_pat_mstr_rec.Tp_pat_version_cd = line.Substring(174, 2);
                        objTp_pat_mstr_rec.Tp_pat_version_cd_1 = line.Substring(174, 1);
                        objTp_pat_mstr_rec.Tp_pat_version_cd_2 = line.Substring(175, 1);

                        objTp_pat_mstr_rec.Tp_pat_relationship = line.Substring(176, 1);
                        objTp_pat_mstr_rec.Tp_pat_last_name = line.Substring(177, 25);
                        objTp_pat_mstr_rec.Tp_pat_subscr_initials = line.Substring(202, 3);
                        objTp_pat_mstr_rec.Tp_pat_agent_cd = Util.NumInt(line.Substring(205, 1));
                        Tp_pat_mstr_rec_Collection.Add(objTp_pat_mstr_rec);
                    }
                }
                else
                {                    
                    line = file.ReadToEnd();

                    if (line != null)
                    {
                        bool eoline = false;
                        while(!eoline)
                        {
                            string tmpLine = line.Substring(0, 206);
                            if (line.Trim().Length > 206)
                            {
                                line = line.Substring(206);
                            }
                            else
                            {
                                eoline = true;
                            }

                            Tp_pat_mstr_rec objTp_pat_mstr_rec = null;
                            objTp_pat_mstr_rec = new Tp_pat_mstr_rec();

                            objTp_pat_mstr_rec.Tp_pat_func_code = tmpLine.Substring(0, 2);
                            objTp_pat_mstr_rec.Tp_pat_doctor_nbr = Util.NumInt(tmpLine.Substring(2, 6));
                            objTp_pat_mstr_rec.Tp_pat_account_id = tmpLine.Substring(8, 8);

                            objTp_pat_mstr_rec.Tp_pat_subscr_surname = tmpLine.Substring(16, 25);
                            objTp_pat_mstr_rec.Tp_pat_subscr_surname_6 = tmpLine.Substring(16, 6);
                            objTp_pat_mstr_rec.Tp_pat_subscr_surname_18 = tmpLine.Substring(22, 41);

                            objTp_pat_mstr_rec.Tp_pat_first_name = tmpLine.Substring(41, 24);
                            objTp_pat_mstr_rec.Tp_pat_first_name_3 = tmpLine.Substring(41, 3);
                            objTp_pat_mstr_rec.Tp_pat_first_name_21 = tmpLine.Substring(44, 21);

                            objTp_pat_mstr_rec.Tp_pat_birth_date = tmpLine.Substring(65, 8);
                            objTp_pat_mstr_rec.Tp_pat_birth_date_r = tmpLine.Substring(65, 8);
                            objTp_pat_mstr_rec.Tp_pat_birth_yy = Util.NumInt(tmpLine.Substring(65, 4));
                            objTp_pat_mstr_rec.Tp_pat_birth_mm = Util.NumInt(tmpLine.Substring(69, 2));
                            objTp_pat_mstr_rec.Tp_pat_birth_dd = Util.NumInt(tmpLine.Substring(71, 2));

                            objTp_pat_mstr_rec.Tp_pat_sex = tmpLine.Substring(73, 1);
                            objTp_pat_mstr_rec.Tp_pat_id_no = tmpLine.Substring(74, 9);

                            objTp_pat_mstr_rec.Tp_pat_id_no_r = tmpLine.Substring(74, 9);
                            objTp_pat_mstr_rec.Tp_pat_id_no_first_8_digits = tmpLine.Substring(74, 8);
                            objTp_pat_mstr_rec.Tp_pat_id_no_yy = Util.NumInt(tmpLine.Substring(74, 2));
                            objTp_pat_mstr_rec.Tp_pat_id_no_mm = Util.NumInt(tmpLine.Substring(76, 2));
                            objTp_pat_mstr_rec.Tp_pat_id_no_5_digit = tmpLine.Substring(78, 1);
                            objTp_pat_mstr_rec.Tp_pat_id_no_6_7_digit = Util.NumInt(tmpLine.Substring(79, 2));
                            objTp_pat_mstr_rec.Tp_pat_id_no_8_digit = Util.NumInt(tmpLine.Substring(81, 1));

                            objTp_pat_mstr_rec.Tp_pat_id_no_9_digit = tmpLine.Substring(82, 1);

                            objTp_pat_mstr_rec.Tp_pat_street_addr = tmpLine.Substring(83, 28);
                            objTp_pat_mstr_rec.Tp_pat_city = tmpLine.Substring(111, 18);
                            objTp_pat_mstr_rec.Tp_pat_prov = tmpLine.Substring(129, 4);
                            objTp_pat_mstr_rec.Tp_pat_postal_code = tmpLine.Substring(133, 9);

                            objTp_pat_mstr_rec.Tp_pat_postal_code_r = tmpLine.Substring(133, 9);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_1 = tmpLine.Substring(133, 1);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_2 = tmpLine.Substring(134, 1);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_3 = tmpLine.Substring(135, 1);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_4 = tmpLine.Substring(136, 1);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_5 = tmpLine.Substring(137, 1);
                            objTp_pat_mstr_rec.Tp_pat_postal_code_6 = tmpLine.Substring(138, 1);

                            objTp_pat_mstr_rec.Tp_pat_phone_no = tmpLine.Substring(142, 20);

                            objTp_pat_mstr_rec.Tp_pat_ohip_health_no = tmpLine.Substring(162, 12);
                            objTp_pat_mstr_rec.Tp_pat_health_no = tmpLine.Substring(162, 10);
                            objTp_pat_mstr_rec.Tp_pat_ohip_filler = tmpLine.Substring(172, 2);

                            objTp_pat_mstr_rec.Tp_pat_version_cd = tmpLine.Substring(174, 2);
                            objTp_pat_mstr_rec.Tp_pat_version_cd_1 = tmpLine.Substring(174, 1);
                            objTp_pat_mstr_rec.Tp_pat_version_cd_2 = tmpLine.Substring(175, 1);

                            objTp_pat_mstr_rec.Tp_pat_relationship = tmpLine.Substring(176, 1);
                            objTp_pat_mstr_rec.Tp_pat_last_name = tmpLine.Substring(177, 25);
                            objTp_pat_mstr_rec.Tp_pat_subscr_initials = tmpLine.Substring(202, 3);
                            objTp_pat_mstr_rec.Tp_pat_agent_cd = Util.NumInt(tmpLine.Substring(205, 1));
                            Tp_pat_mstr_rec_Collection.Add(objTp_pat_mstr_rec);
                        }
                    }

                }
            }

            return Tp_pat_mstr_rec_Collection;
        }

        #endregion

        #region Logs

          protected void Write_ErrorLog(string fileName, string errorMessage, string errorStackTrace)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\Cobol_Error_Log.txt";
            using (StreamWriter sw = new StreamWriter(filePath,true))
            {
                string errMsg = "COBOL filename  : " + fileName + ",  Error Datetime : " + DateTime.Now.ToString() + ", Error Message :  " + errorMessage;
                sw.WriteLine(errMsg);
                errMsg = "COBOL filename  : " + fileName + ",  Error Datetime : " + DateTime.Now.ToString() + ", Error Stack Trace :  " + errorStackTrace;
                sw.WriteLine(errMsg);
            }
        }

        #endregion

        #region Tools

        public F002_CLAIMS_MSTR_HDR Assign_To_Claims_Mstr_Hdr(F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL)
        {
            if (objF002_CLAIMS_MSTR_DTL == null) return new F002_CLAIMS_MSTR_HDR();

            F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = null;
            objF002_CLAIMS_MSTR_HDR = new F002_CLAIMS_MSTR_HDR();

            objF002_CLAIMS_MSTR_HDR.ROWID = objF002_CLAIMS_MSTR_DTL.ROWID_HDR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_BATCH_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_CLAIM_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_CLAIM_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_CD = objF002_CLAIMS_MSTR_DTL.CLMHDR_ADJ_OMA_CD;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_SUFF = objF002_CLAIMS_MSTR_DTL.CLMHDR_ADJ_OMA_SUFF;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_ADJ_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_ADJ_ADJ_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_BATCH_TYPE = objF002_CLAIMS_MSTR_DTL.CLMHDR_BATCH_TYPE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD_SUB_TYPE = objF002_CLAIMS_MSTR_DTL.CLMHDR_ADJ_CD_SUB_TYPE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_NBR_OHIP = objF002_CLAIMS_MSTR_DTL.CLMHDR_DOC_NBR_OHIP;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_SPEC_CD = objF002_CLAIMS_MSTR_DTL.CLMHDR_DOC_SPEC_CD;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_REFER_DOC_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_REFER_DOC_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DIAG_CD = objF002_CLAIMS_MSTR_DTL.CLMHDR_DIAG_CD;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_LOC = objF002_CLAIMS_MSTR_DTL.CLMHDR_LOC;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_HOSP = objF002_CLAIMS_MSTR_DTL.CLMHDR_HOSP;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_AGENT_CD = objF002_CLAIMS_MSTR_DTL.CLMHDR_AGENT_CD;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_CD = objF002_CLAIMS_MSTR_DTL.CLMHDR_ADJ_CD;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_TAPE_SUBMIT_IND = objF002_CLAIMS_MSTR_DTL.CLMHDR_TAPE_SUBMIT_IND;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_I_O_PAT_IND = objF002_CLAIMS_MSTR_DTL.CLMHDR_I_O_PAT_IND;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_TYPE = objF002_CLAIMS_MSTR_DTL.CLMHDR_PAT_KEY_TYPE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_KEY_DATA = objF002_CLAIMS_MSTR_DTL.CLMHDR_PAT_KEY_DATA;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM6 = objF002_CLAIMS_MSTR_DTL.CLMHDR_PAT_ACRONYM6;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_PAT_ACRONYM3 = objF002_CLAIMS_MSTR_DTL.CLMHDR_PAT_ACRONYM3;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_REFERENCE = objF002_CLAIMS_MSTR_DTL.CLMHDR_REFERENCE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_ADMIT = objF002_CLAIMS_MSTR_DTL.CLMHDR_DATE_ADMIT;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DOC_DEPT = objF002_CLAIMS_MSTR_DTL.CLMHDR_DOC_DEPT;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_MSG_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_MSG_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_REPRINT_FLAG = objF002_CLAIMS_MSTR_DTL.CLMHDR_REPRINT_FLAG;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_SUB_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_SUB_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_AUTO_LOGOUT = objF002_CLAIMS_MSTR_DTL.CLMHDR_AUTO_LOGOUT;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_FEE_COMPLEX = objF002_CLAIMS_MSTR_DTL.CLMHDR_FEE_COMPLEX;
            objF002_CLAIMS_MSTR_HDR.FILLER = objF002_CLAIMS_MSTR_DTL.FILLER;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_CURR_PAYMENT = objF002_CLAIMS_MSTR_DTL.CLMHDR_CURR_PAYMENT;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_PERIOD_END = objF002_CLAIMS_MSTR_DTL.CLMHDR_DATE_PERIOD_END;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_CYCLE_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_CYCLE_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_DATE_SYS = objF002_CLAIMS_MSTR_DTL.CLMHDR_DATE_SYS;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_BILLED = objF002_CLAIMS_MSTR_DTL.CLMHDR_AMT_TECH_BILLED;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_AMT_TECH_PAID = objF002_CLAIMS_MSTR_DTL.CLMHDR_AMT_TECH_PAID;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OMA = objF002_CLAIMS_MSTR_DTL.CLMHDR_TOT_CLAIM_AR_OMA;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_TOT_CLAIM_AR_OHIP = objF002_CLAIMS_MSTR_DTL.CLMHDR_TOT_CLAIM_AR_OHIP;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_AND_TAPE_PAYMENTS = objF002_CLAIMS_MSTR_DTL.CLMHDR_MANUAL_AND_TAPE_PAYMENTS;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_STATUS_OHIP = objF002_CLAIMS_MSTR_DTL.CLMHDR_STATUS_OHIP;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_MANUAL_REVIEW = objF002_CLAIMS_MSTR_DTL.CLMHDR_MANUAL_REVIEW;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_SUBMIT_DATE = objF002_CLAIMS_MSTR_DTL.CLMHDR_SUBMIT_DATE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_CONFIDENTIAL_FLAG = objF002_CLAIMS_MSTR_DTL.CLMHDR_CONFIDENTIAL_FLAG;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_DATE = objF002_CLAIMS_MSTR_DTL.CLMHDR_SERV_DATE;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_ERROR = objF002_CLAIMS_MSTR_DTL.CLMHDR_ELIG_ERROR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ELIG_STATUS = objF002_CLAIMS_MSTR_DTL.CLMHDR_ELIG_STATUS;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_ERROR = objF002_CLAIMS_MSTR_DTL.CLMHDR_SERV_ERROR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_SERV_STATUS = objF002_CLAIMS_MSTR_DTL.CLMHDR_SERV_STATUS;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_BATCH_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_ORIG_BATCH_NBR;
            objF002_CLAIMS_MSTR_HDR.CLMHDR_ORIG_CLAIM_NBR = objF002_CLAIMS_MSTR_DTL.CLMHDR_ORIG_CLAIM_NBR;

            return objF002_CLAIMS_MSTR_HDR;
        }

        public ObservableCollection<D001_batch_in_progress_rec> Read_D001_batch_in_progress_rec(bool lineFeed = true)
        {
            string filePath = Environment.GetEnvironmentVariable("HOMEDIR") + "\\batch_in_progress.d001";    // "$HOME/batch_in_progress.d001"
            string line = string.Empty;

            ObservableCollection<D001_batch_in_progress_rec> D001_batch_in_progress_rec_Collection = null;
            D001_batch_in_progress_rec_Collection = new ObservableCollection<D001_batch_in_progress_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while((line = sr.ReadLine()) != null )
                    {
                        D001_batch_in_progress_rec objD001_batch_in_progress_rec = null;
                        objD001_batch_in_progress_rec = new D001_batch_in_progress_rec();

                        line = line.PadRight(49);
                        objD001_batch_in_progress_rec.D001_command_part_1 = line.Substring(0, 12);
                        objD001_batch_in_progress_rec.D001_space_1 = line.Substring(12, 1);
                        objD001_batch_in_progress_rec.D001_bat_clinic_nbr_1_2 = Util.NumInt(line.Substring(13, 2));
                        objD001_batch_in_progress_rec.D001_bat_doc_nbr = line.Substring(15, 3);
                        objD001_batch_in_progress_rec.D001_bat_week_day = line.Substring(18, 3);
                        objD001_batch_in_progress_rec.D001_space_2 = line.Substring(21, 1);
                        objD001_batch_in_progress_rec.D001_loc = line.Substring(22, 4);
                        objD001_batch_in_progress_rec.D001_space_3 = line.Substring(26, 1);
                        objD001_batch_in_progress_rec.D001_agent_cd = line.Substring(27, 1);
                        objD001_batch_in_progress_rec.D001_space_4 = line.Substring(28, 1);
                        objD001_batch_in_progress_rec.D001_i_o_pat_ind = line.Substring(29, 1);
                        objD001_batch_in_progress_rec.D001_space_5 = line.Substring(30, 1);
                        objD001_batch_in_progress_rec.D001_payroll = line.Substring(31, 1);
                        objD001_batch_in_progress_rec.D001_space_6 = line.Substring(32, 1);
                        objD001_batch_in_progress_rec.D001_f001_exists_ind = line.Substring(33, 1);
                        objD001_batch_in_progress_rec.D001_space_7 = line.Substring(34, 1);
                        objD001_batch_in_progress_rec.D001_command_part_2 = line.Substring(35, 14);
                        D001_batch_in_progress_rec_Collection.Add(objD001_batch_in_progress_rec);
                    }
                }
                else
                {
                    line = sr.ReadToEnd();
                    if (line != null)
                    {
                        bool eoline = false;
                        while(!eoline )
                        {
                            string tmpLine = line.Substring(0, 49);
                            if (line.Trim().Length > 49 )
                            {
                                line = line.Substring(49);
                            } else
                            {
                                line = line.PadRight(49);
                                eoline = true;
                            }

                            D001_batch_in_progress_rec objD001_batch_in_progress_rec = null;
                            objD001_batch_in_progress_rec = new D001_batch_in_progress_rec();

                            objD001_batch_in_progress_rec.D001_command_part_1 = tmpLine.Substring(0, 12);
                            objD001_batch_in_progress_rec.D001_space_1 = tmpLine.Substring(12, 1);
                            objD001_batch_in_progress_rec.D001_bat_clinic_nbr_1_2 = Util.NumInt(tmpLine.Substring(13, 2));
                            objD001_batch_in_progress_rec.D001_bat_doc_nbr = tmpLine.Substring(15, 3);
                            objD001_batch_in_progress_rec.D001_bat_week_day = tmpLine.Substring(18, 3);
                            objD001_batch_in_progress_rec.D001_space_2 = tmpLine.Substring(21, 1);
                            objD001_batch_in_progress_rec.D001_loc = tmpLine.Substring(22, 4);
                            objD001_batch_in_progress_rec.D001_space_3 = tmpLine.Substring(26, 1);
                            objD001_batch_in_progress_rec.D001_agent_cd = tmpLine.Substring(27, 1);
                            objD001_batch_in_progress_rec.D001_space_4 = tmpLine.Substring(28, 1);
                            objD001_batch_in_progress_rec.D001_i_o_pat_ind = tmpLine.Substring(29, 1);
                            objD001_batch_in_progress_rec.D001_space_5 = tmpLine.Substring(30, 1);
                            objD001_batch_in_progress_rec.D001_payroll = tmpLine.Substring(31, 1);
                            objD001_batch_in_progress_rec.D001_space_6 = tmpLine.Substring(32, 1);
                            objD001_batch_in_progress_rec.D001_f001_exists_ind = tmpLine.Substring(33, 1);
                            objD001_batch_in_progress_rec.D001_space_7 = tmpLine.Substring(34, 1);
                            objD001_batch_in_progress_rec.D001_command_part_2 = tmpLine.Substring(35, 14);
                            D001_batch_in_progress_rec_Collection.Add(objD001_batch_in_progress_rec);
                        }
                    }
                }
            }


            return D001_batch_in_progress_rec_Collection;
        }

        public bool Read_D001_batch_in_progress_rec()
        {
            string filePath = Environment.GetEnvironmentVariable("HOMEDIR") + "\\batch_in_progress.d001";    // "$HOME/batch_in_progress.d001"            
            try {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        // todo....
                    }
                     return true;
                }
            } catch (Exception e)
            {
                                
            }
            return false;            
        }

        public bool Write_D001_batch_in_progress_rec(D001_batch_in_progress_rec obj,bool lineFeed = true)
        {
            try {
                string filePath = Environment.GetEnvironmentVariable("HOMEDIR") + "\\batch_in_progress.d001"; // "$HOME/batch_in_progress.d001"    

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    string tempData = Util.Str(obj.D001_command_part_1).PadRight(12, ' ') +
                                  Util.Str(obj.D001_space_1).PadRight(1, ' ') +
                                  Util.Str(obj.D001_batch_nbr) +
                                  Util.Str(obj.D001_space_2).PadRight(1, ' ') +
                                  Util.Str(obj.D001_loc).PadRight(4, ' ') +
                                  Util.Str(obj.D001_space_3).PadRight(1, ' ') +
                                  Util.Str(obj.D001_agent_cd).PadRight(1, ' ') +
                                  Util.Str(obj.D001_space_4).PadRight(1, ' ') +
                                  Util.Str(obj.D001_i_o_pat_ind).PadRight(1, ' ') +
                                  Util.Str(obj.D001_space_5).PadRight(1, ' ') +
                                  Util.Str(obj.D001_payroll).PadRight(1, ' ') +
                                  Util.Str(obj.D001_space_6).PadRight(1, ' ') +
                                  Util.Str(obj.D001_f001_exists_ind).PadRight(1, ' ') +
                                  Util.Str(obj.D001_space_7).PadRight(1, ' ') +
                                  Util.Str(obj.D001_command_part_2).PadRight(14, ' ');

                    if (lineFeed)
                    {
                        sw.WriteLine(tempData);
                    } else
                    {
                        sw.Write(tempData);
                    }
                }
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Write_F086_Pat_Id_d001_rec(Pat_id_rec obj, bool lineFeed = true )
        {
            try
            {
                string filePath = Environment.GetEnvironmentVariable("HOMEDIR") + "\\f086_pat_id.d001";       // "$HOME/f086_pat_id.d001"
                
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    string tempData = Util.Str(obj.Clmhdr_pat_ohip_id_or_chart).PadRight(16, ' ') +
                                      Util.Str(obj.Pat_last_birth_date).PadLeft(8, '0') +
                                      Util.Str(obj.Pat_last_version_cd).PadRight(2, ' ') +
                                      Util.Str(obj.Pat_old_surname).PadRight(25, ' ') +
                                      Util.Str(obj.Pat_old_given_name).PadRight(17, ' ') +
                                      Util.Str(obj.Pat_old_health_nbr).PadLeft(10, '0') +
                                      Util.Str(obj.Pat_old_chart_nbr).PadRight(10, ' ') +
                                      Util.Str(obj.Pat_old_chart_nbr_2).PadRight(10, ' ') +
                                      Util.Str(obj.Pat_old_chart_nbr_3).PadRight(10, ' ') +
                                      Util.Str(obj.Pat_old_chart_nbr_4).PadRight(10, ' ') +
                                      Util.Str(obj.Pat_old_chart_nbr_5).PadRight(11, ' ') +
                                      Util.Str(obj.Pat_old_addr1).PadRight(21, ' ') +
                                      Util.Str(obj.Pat_old_addr2).PadRight(21, ' ') +
                                      Util.Str(obj.Pat_old_addr3).PadRight(21, ' ');

                    if (lineFeed)
                    {
                        sw.WriteLine(tempData);
                    }
                    else
                    {
                        sw.Write(tempData);
                    }
                }

            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public ObservableCollection<Rejected_claims_rec> Read_Rejected_claims_rec(bool lineFeed = true)
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\f085_rejected_claims";
            string line = string.Empty;

            if (Util.DebugUsingLocalMachine())
            {
                filePath = Directory.GetCurrentDirectory() + "\\f085_rejected_claims";
            }

            ObservableCollection<Rejected_claims_rec> Rejected_claims_rec_Collection = null;
            Rejected_claims_rec_Collection = new ObservableCollection<Rejected_claims_rec>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                if (lineFeed)
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        Rejected_claims_rec objRejected_claims_rec = null;
                        objRejected_claims_rec = new Rejected_claims_rec();

                        line = line.PadRight(45, ' ');
                        objRejected_claims_rec.Claim_nbr = line.Substring(0, 10);
                        objRejected_claims_rec.Doc_nbr = line.Substring(10, 3);
                        objRejected_claims_rec.Clmhdr_pat_id = line.Substring(13, 16);
                        objRejected_claims_rec.Rejected_loc = line.Substring(29, 4);
                        objRejected_claims_rec.Mess_code = line.Substring(33, 3);
                        objRejected_claims_rec.Logically_deleted_flag = line.Substring(36, 1);
                        objRejected_claims_rec.Clmhdr_submit_date = Util.NumInt(line.Substring(37, 8));
                        Rejected_claims_rec_Collection.Add(objRejected_claims_rec);
                    }
                }
                else
                {
                    line = sr.ReadToEnd();
                    if (line != null )
                    {
                        bool eoline = false;
                        while(!eoline)
                        {
                            string tmpLine = line.Substring(0, 45);
                            if (line.Trim().Length > 45)
                            {
                                line = line.Substring(45);
                            }
                            else
                            {
                                line = line.PadRight(45);
                                eoline = true;

                                Rejected_claims_rec objRejected_claims_rec = null;
                                objRejected_claims_rec = new Rejected_claims_rec();

                                objRejected_claims_rec.Claim_nbr = tmpLine.Substring(0, 10);
                                objRejected_claims_rec.Doc_nbr = tmpLine.Substring(10, 3);
                                objRejected_claims_rec.Clmhdr_pat_id = tmpLine.Substring(13, 16);
                                objRejected_claims_rec.Rejected_loc = tmpLine.Substring(29, 4);
                                objRejected_claims_rec.Mess_code = tmpLine.Substring(33, 3);
                                objRejected_claims_rec.Logically_deleted_flag = tmpLine.Substring(36, 1);
                                objRejected_claims_rec.Clmhdr_submit_date = Util.NumInt(tmpLine.Substring(37, 8));
                                Rejected_claims_rec_Collection.Add(objRejected_claims_rec);
                            }
                        }

                    }
                }
            }
            return Rejected_claims_rec_Collection;
        }

        public bool Rewrite_Rejected_claims_rec(ObservableCollection<Rejected_claims_rec> objRejected_claims_recCollection, bool lineFeed = true)
        {
            try {
                string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\f085_rejected_claims";
                string line = string.Empty;

                if (Util.DebugUsingLocalMachine())
                {
                    filePath = Directory.GetCurrentDirectory() + "\\f085_rejected_claims";
                }

                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    if (lineFeed)
                    {
                        foreach (var obj in objRejected_claims_recCollection)
                        {
                            string tempData = Util.Str(obj.Claim_nbr).PadRight(10, ' ') +
                                               Util.Str(obj.Doc_nbr).PadRight(3, ' ') +
                                               Util.Str(obj.Clmhdr_pat_id).PadRight(16, ' ') +
                                               Util.Str(obj.Rejected_loc).PadRight(4, ' ') +
                                               Util.Str(obj.Mess_code).PadRight(3, ' ') +
                                               Util.Str(obj.Logically_deleted_flag).PadRight(1, ' ') +
                                               Util.Str(obj.Clmhdr_submit_date).PadLeft(8, '0');
                            sw.WriteLine(tempData);
                        }
                    }
                    else
                    {
                        foreach (var obj in objRejected_claims_recCollection)
                        {
                            string tempData = Util.Str(obj.Claim_nbr).PadRight(10, ' ') +
                                               Util.Str(obj.Doc_nbr).PadRight(3, ' ') +
                                               Util.Str(obj.Clmhdr_pat_id).PadRight(16, ' ') +
                                               Util.Str(obj.Rejected_loc).PadRight(4, ' ') +
                                               Util.Str(obj.Mess_code).PadRight(3, ' ') +
                                               Util.Str(obj.Logically_deleted_flag).PadRight(1, ' ') +
                                               Util.Str(obj.Clmhdr_submit_date).PadLeft(8, '0');
                            sw.Write(tempData);
                        }
                    }
                }
            } catch (Exception e)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Misc CHQ
        // Misc
        public decimal CHQ_REG_MTH_MISC_AMT(F060_CHEQUE_REG_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            switch (Util.NumInt(row.ToString() + col.ToString()))
            {
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_18);
                    break;
                case 19:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_19);
                    break;
                case 110:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_110);
                    break;
                case 111:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_111);
                    break;
                case 112:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_112);
                    break;
                case 113:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_113);
                    break;
                case 114:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_114);
                    break;
                case 115:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_115);
                    break;
                case 116:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_116);
                    break;
                case 117:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_117);
                    break;
                case 118:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_118);
                    break;

                case 21:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_21);
                    break;
                case 22:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_22);
                    break;
                case 23:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_23);
                    break;
                case 24:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_24);
                    break;
                case 25:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_25);
                    break;
                case 26:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_26);
                    break;
                case 27:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_27);
                    break;
                case 28:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_28);
                    break;
                case 29:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_29);
                    break;
                case 210:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_210);
                    break;
                case 211:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_211);
                    break;
                case 212:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_212);
                    break;
                case 213:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_213);
                    break;
                case 214:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_214);
                    break;
                case 215:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_215);
                    break;
                case 216:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_216);
                    break;
                case 217:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_217);
                    break;
                case 218:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_218);
                    break;

                case 31:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_31);
                    break;
                case 32:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_32);
                    break;
                case 33:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_33);
                    break;
                case 34:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_34);
                    break;
                case 35:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_35);
                    break;
                case 36:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_36);
                    break;
                case 37:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_37);
                    break;
                case 38:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_38);
                    break;
                case 39:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_39);
                    break;
                case 310:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_310);
                    break;
                case 311:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_311);
                    break;
                case 312:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_312);
                    break;
                case 313:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_313);
                    break;
                case 314:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_314);
                    break;
                case 315:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_315);
                    break;
                case 316:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_316);
                    break;
                case 317:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_317);
                    break;
                case 318:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_318);
                    break;

                case 41:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_41);
                    break;
                case 42:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_42);
                    break;
                case 43:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_43);
                    break;
                case 44:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_44);
                    break;
                case 45:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_45);
                    break;
                case 46:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_46);
                    break;
                case 47:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_47);
                    break;
                case 48:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_48);
                    break;
                case 49:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_49);
                    break;
                case 410:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_410);
                    break;
                case 411:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_411);
                    break;
                case 412:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_412);
                    break;
                case 413:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_413);
                    break;
                case 414:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_414);
                    break;
                case 415:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_415);
                    break;
                case 416:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_416);
                    break;
                case 417:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_417);
                    break;
                case 418:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_418);
                    break;

                case 51:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_51);
                    break;
                case 52:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_52);
                    break;
                case 53:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_53);
                    break;
                case 54:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_54);
                    break;
                case 55:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_55);
                    break;
                case 56:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_56);
                    break;
                case 57:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_57);
                    break;
                case 58:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_58);
                    break;
                case 59:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_59);
                    break;
                case 510:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_510);
                    break;
                case 511:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_511);
                    break;
                case 512:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_512);
                    break;
                case 513:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_513);
                    break;
                case 514:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_514);
                    break;
                case 515:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_515);
                    break;
                case 516:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_516);
                    break;
                case 517:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_517);
                    break;
                case 518:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_518);
                    break;

                case 61:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_61);
                    break;
                case 62:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_62);
                    break;
                case 63:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_63);
                    break;
                case 64:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_64);
                    break;
                case 65:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_65);
                    break;
                case 66:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_66);
                    break;
                case 67:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_67);
                    break;
                case 68:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_68);
                    break;
                case 69:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_69);
                    break;
                case 610:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_610);
                    break;
                case 611:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_611);
                    break;
                case 612:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_612);
                    break;
                case 613:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_613);
                    break;
                case 614:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_614);
                    break;
                case 615:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_615);
                    break;
                case 616:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_616);
                    break;
                case 617:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_617);
                    break;
                case 618:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_618);
                    break;

                case 71:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_71);
                    break;
                case 72:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_72);
                    break;
                case 73:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_73);
                    break;
                case 74:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_74);
                    break;
                case 75:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_75);
                    break;
                case 76:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_76);
                    break;
                case 77:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_77);
                    break;
                case 78:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_78);
                    break;
                case 79:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_71);
                    break;
                case 710:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_710);
                    break;
                case 711:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_711);
                    break;
                case 712:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_712);
                    break;
                case 713:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_713);
                    break;
                case 714:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_714);
                    break;
                case 715:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_715);
                    break;
                case 716:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_716);
                    break;
                case 717:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_717);
                    break;
                case 718:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_718);
                    break;

                case 81:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_81);
                    break;
                case 82:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_82);
                    break;
                case 83:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_83);
                    break;
                case 84:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_84);
                    break;
                case 85:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_85);
                    break;
                case 86:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_86);
                    break;
                case 87:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_87);
                    break;
                case 88:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_88);
                    break;
                case 89:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_89);
                    break;
                case 810:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_810);
                    break;
                case 811:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_811);
                    break;
                case 812:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_812);
                    break;
                case 813:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_813);
                    break;
                case 814:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_814);
                    break;
                case 815:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_815);
                    break;
                case 816:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_816);
                    break;
                case 817:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_817);
                    break;
                case 818:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_818);
                    break;

                case 91:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_91);
                    break;
                case 92:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_92);
                    break;
                case 93:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_93);
                    break;
                case 94:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_94);
                    break;
                case 95:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_95);
                    break;
                case 96:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_96);
                    break;
                case 97:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_97);
                    break;
                case 98:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_98);
                    break;
                case 99:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_99);
                    break;
                case 910:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_910);
                    break;
                case 911:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_911);
                    break;
                case 912:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_912);
                    break;
                case 913:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_913);
                    break;
                case 914:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_914);
                    break;
                case 915:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_915);
                    break;
                case 916:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_916);
                    break;
                case 917:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_917);
                    break;
                case 918:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_918);
                    break;

                case 101:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_101);
                    break;
                case 102:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_102);
                    break;
                case 103:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_103);
                    break;
                case 104:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_104);
                    break;
                case 105:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_105);
                    break;
                case 106:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_106);
                    break;
                case 107:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_107);
                    break;
                case 108:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_108);
                    break;
                case 109:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_109);
                    break;
                case 1010:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1010);
                    break;
                case 1011:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1011);
                    break;
                case 1012:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1012);
                    break;
                case 1013:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1013);
                    break;
                case 1014:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1014);
                    break;
                case 1015:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1015);
                    break;
                case 1016:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1016);
                    break;
                case 1017:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1017);
                    break;
                case 1018:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_MISC_AMT_1018);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_MTH_BILL_AMT(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_BILL_AMT18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_MAN_PAY_THIS_MTH(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_PAY_THIS_MTH18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_REGULAR_PAY_THIS_MTH(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_PAY_THIS_MTH18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_REGULAR_TAX_THIS_MTH(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_REGULAR_TAX_THIS_MTH18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_PAY_DATE(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_PAY_DATE18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_PERC_MISC(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_MISC18);
                    break;
            }
            return retVal;
        }


        public   decimal CHQ_REG_MTH_EXP_AMT(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_EXP_AMT18);
                    break;
            }
            return retVal;
        }


        public   decimal CHQ_REG_PERC_BILL(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_PERC_BILL18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_MTH_CEIL_AMT(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MTH_CEIL_AMT18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_EARNINGS_THIS_MTH(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_EARNINGS_THIS_MTH18);
                    break;
            }
            return retVal;
        }

        public   decimal CHQ_REG_MAN_TAX_THIS_MTH(F060_CHEQUE_REG_MSTR obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CHQ_REG_MAN_TAX_THIS_MTH18);
                    break;
            }
            return retVal;
        }

        public   void CHQ_REG_REGULAR_TAX_THIS_MTH_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH18 = value;
                    break;
            }
        }

        public   void CHQ_REG_PERC_MISC_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_PERC_MISC1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_PERC_MISC2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_PERC_MISC3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_PERC_MISC4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_PERC_MISC5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_PERC_MISC6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_PERC_MISC7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_PERC_MISC8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_PERC_MISC9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_PERC_MISC10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_PERC_MISC11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_PERC_MISC12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_PERC_MISC13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_PERC_MISC14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_PERC_MISC15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_PERC_MISC16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_PERC_MISC17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_PERC_MISC18 = value;
                    break;
            }
        }

        public   void CHQ_REG_PERC_BILL_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_PERC_BILL1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_PERC_BILL2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_PERC_BILL3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_PERC_BILL4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_PERC_BILL5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_PERC_BILL6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_PERC_BILL7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_PERC_BILL8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_PERC_BILL9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_PERC_BILL10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_PERC_BILL11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_PERC_BILL12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_PERC_BILL13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_PERC_BILL14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_PERC_BILL15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_PERC_BILL16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_PERC_BILL17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_PERC_BILL18 = value;
                    break;
            }
        }

        public   void CHQ_REG_PAY_CODE_SET(F060_CHEQUE_REG_MSTR obj, int col, string value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_PAY_CODE1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_PAY_CODE2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_PAY_CODE3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_PAY_CODE4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_PAY_CODE5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_PAY_CODE6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_PAY_CODE7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_PAY_CODE8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_PAY_CODE9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_PAY_CODE10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_PAY_CODE11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_PAY_CODE12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_PAY_CODE13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_PAY_CODE14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_PAY_CODE15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_PAY_CODE16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_PAY_CODE17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_PAY_CODE18 = value;
                    break;
            }
        }

        public   void CHQ_REG_PERC_TAX_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_PERC_TAX1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_PERC_TAX2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_PERC_TAX3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_PERC_TAX4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_PERC_TAX5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_PERC_TAX6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_PERC_TAX7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_PERC_TAX8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_PERC_TAX9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_PERC_TAX10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_PERC_TAX11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_PERC_TAX12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_PERC_TAX13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_PERC_TAX14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_PERC_TAX15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_PERC_TAX16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_PERC_TAX17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_PERC_TAX18 = value;
                    break;
            }
        }

        public   void CHQ_REG_MTH_BILL_AMT_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_MTH_BILL_AMT1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_MTH_BILL_AMT2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_MTH_BILL_AMT3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_MTH_BILL_AMT4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_MTH_BILL_AMT5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_MTH_BILL_AMT6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_MTH_BILL_AMT7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_MTH_BILL_AMT8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_MTH_BILL_AMT9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_MTH_BILL_AMT10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_MTH_BILL_AMT11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MTH_BILL_AMT12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MTH_BILL_AMT13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MTH_BILL_AMT14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MTH_BILL_AMT15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MTH_BILL_AMT16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MTH_BILL_AMT17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MTH_BILL_AMT18 = value;
                    break;
            }
        }

        public   void CHQ_REG_MTH_MISC_AMT_SET(F060_CHEQUE_REG_MSTR obj, int row, int col, decimal value)
        {
            switch (Util.NumInt(row.ToString() + col.ToString()))
            {
                case 11:
                    obj.CHQ_REG_MTH_MISC_AMT_11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MTH_MISC_AMT_12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MTH_MISC_AMT_13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MTH_MISC_AMT_14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MTH_MISC_AMT_15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MTH_MISC_AMT_16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MTH_MISC_AMT_17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MTH_MISC_AMT_18 = value;
                    break;
                case 19:
                    obj.CHQ_REG_MTH_MISC_AMT_19 = value;
                    break;
                case 110:
                    obj.CHQ_REG_MTH_MISC_AMT_110 = value;
                    break;
                case 111:
                    obj.CHQ_REG_MTH_MISC_AMT_111 = value;
                    break;
                case 112:
                    obj.CHQ_REG_MTH_MISC_AMT_112 = value;
                    break;
                case 113:
                    obj.CHQ_REG_MTH_MISC_AMT_113 = value;
                    break;
                case 114:
                    obj.CHQ_REG_MTH_MISC_AMT_114 = value;
                    break;
                case 115:
                    obj.CHQ_REG_MTH_MISC_AMT_115 = value;
                    break;
                case 116:
                    obj.CHQ_REG_MTH_MISC_AMT_116 = value;
                    break;
                case 117:
                    obj.CHQ_REG_MTH_MISC_AMT_117 = value;
                    break;
                case 118:
                    obj.CHQ_REG_MTH_MISC_AMT_118 = value;
                    break;

                case 21:
                    obj.CHQ_REG_MTH_MISC_AMT_21 = value;
                    break;
                case 22:
                    obj.CHQ_REG_MTH_MISC_AMT_22 = value;
                    break;
                case 23:
                    obj.CHQ_REG_MTH_MISC_AMT_23 = value;
                    break;
                case 24:
                    obj.CHQ_REG_MTH_MISC_AMT_24 = value;
                    break;
                case 25:
                    obj.CHQ_REG_MTH_MISC_AMT_25 = value;
                    break;
                case 26:
                    obj.CHQ_REG_MTH_MISC_AMT_26 = value;
                    break;
                case 27:
                    obj.CHQ_REG_MTH_MISC_AMT_27 = value;
                    break;
                case 28:
                    obj.CHQ_REG_MTH_MISC_AMT_28 = value;
                    break;
                case 29:
                    obj.CHQ_REG_MTH_MISC_AMT_29 = value;
                    break;
                case 210:
                    obj.CHQ_REG_MTH_MISC_AMT_210 = value;
                    break;
                case 211:
                    obj.CHQ_REG_MTH_MISC_AMT_211 = value;
                    break;
                case 212:
                    obj.CHQ_REG_MTH_MISC_AMT_212 = value;
                    break;
                case 213:
                    obj.CHQ_REG_MTH_MISC_AMT_213 = value;
                    break;
                case 214:
                    obj.CHQ_REG_MTH_MISC_AMT_214 = value;
                    break;
                case 215:
                    obj.CHQ_REG_MTH_MISC_AMT_215 = value;
                    break;
                case 216:
                    obj.CHQ_REG_MTH_MISC_AMT_216 = value;
                    break;
                case 217:
                    obj.CHQ_REG_MTH_MISC_AMT_217 = value;
                    break;
                case 218:
                    obj.CHQ_REG_MTH_MISC_AMT_218 = value;
                    break;

                case 31:
                    obj.CHQ_REG_MTH_MISC_AMT_31 = value;
                    break;
                case 32:
                    obj.CHQ_REG_MTH_MISC_AMT_32 = value;
                    break;
                case 33:
                    obj.CHQ_REG_MTH_MISC_AMT_33 = value;
                    break;
                case 34:
                    obj.CHQ_REG_MTH_MISC_AMT_34 = value;
                    break;
                case 35:
                    obj.CHQ_REG_MTH_MISC_AMT_35 = value;
                    break;
                case 36:
                    obj.CHQ_REG_MTH_MISC_AMT_36 = value;
                    break;
                case 37:
                    obj.CHQ_REG_MTH_MISC_AMT_37 = value;
                    break;
                case 38:
                    obj.CHQ_REG_MTH_MISC_AMT_38 = value;
                    break;
                case 39:
                    obj.CHQ_REG_MTH_MISC_AMT_39 = value;
                    break;
                case 310:
                    obj.CHQ_REG_MTH_MISC_AMT_310 = value;
                    break;
                case 311:
                    obj.CHQ_REG_MTH_MISC_AMT_311 = value;
                    break;
                case 312:
                    obj.CHQ_REG_MTH_MISC_AMT_312 = value;
                    break;
                case 313:
                    obj.CHQ_REG_MTH_MISC_AMT_313 = value;
                    break;
                case 314:
                    obj.CHQ_REG_MTH_MISC_AMT_314 = value;
                    break;
                case 315:
                    obj.CHQ_REG_MTH_MISC_AMT_315 = value;
                    break;
                case 316:
                    obj.CHQ_REG_MTH_MISC_AMT_316 = value;
                    break;
                case 317:
                    obj.CHQ_REG_MTH_MISC_AMT_317 = value;
                    break;
                case 318:
                    obj.CHQ_REG_MTH_MISC_AMT_318 = value;
                    break;

                case 41:
                    obj.CHQ_REG_MTH_MISC_AMT_41 = value;
                    break;
                case 42:
                    obj.CHQ_REG_MTH_MISC_AMT_42 = value;
                    break;
                case 43:
                    obj.CHQ_REG_MTH_MISC_AMT_43 = value;
                    break;
                case 44:
                    obj.CHQ_REG_MTH_MISC_AMT_44 = value;
                    break;
                case 45:
                    obj.CHQ_REG_MTH_MISC_AMT_45 = value;
                    break;
                case 46:
                    obj.CHQ_REG_MTH_MISC_AMT_46 = value;
                    break;
                case 47:
                    obj.CHQ_REG_MTH_MISC_AMT_47 = value;
                    break;
                case 48:
                    obj.CHQ_REG_MTH_MISC_AMT_48 = value;
                    break;
                case 49:
                    obj.CHQ_REG_MTH_MISC_AMT_49 = value;
                    break;
                case 410:
                    obj.CHQ_REG_MTH_MISC_AMT_410 = value;
                    break;
                case 411:
                    obj.CHQ_REG_MTH_MISC_AMT_411 = value;
                    break;
                case 412:
                    obj.CHQ_REG_MTH_MISC_AMT_412 = value;
                    break;
                case 413:
                    obj.CHQ_REG_MTH_MISC_AMT_413 = value;
                    break;
                case 414:
                    obj.CHQ_REG_MTH_MISC_AMT_414 = value;
                    break;
                case 415:
                    obj.CHQ_REG_MTH_MISC_AMT_415 = value;
                    break;
                case 416:
                    obj.CHQ_REG_MTH_MISC_AMT_416 = value;
                    break;
                case 417:
                    obj.CHQ_REG_MTH_MISC_AMT_417 = value;
                    break;
                case 418:
                    obj.CHQ_REG_MTH_MISC_AMT_418 = value;
                    break;

                case 51:
                    obj.CHQ_REG_MTH_MISC_AMT_51 = value;
                    break;
                case 52:
                    obj.CHQ_REG_MTH_MISC_AMT_52 = value;
                    break;
                case 53:
                    obj.CHQ_REG_MTH_MISC_AMT_53 = value;
                    break;
                case 54:
                    obj.CHQ_REG_MTH_MISC_AMT_54 = value;
                    break;
                case 55:
                    obj.CHQ_REG_MTH_MISC_AMT_55 = value;
                    break;
                case 56:
                    obj.CHQ_REG_MTH_MISC_AMT_56 = value;
                    break;
                case 57:
                    obj.CHQ_REG_MTH_MISC_AMT_57 = value;
                    break;
                case 58:
                    obj.CHQ_REG_MTH_MISC_AMT_58 = value;
                    break;
                case 59:
                    obj.CHQ_REG_MTH_MISC_AMT_59 = value;
                    break;
                case 510:
                    obj.CHQ_REG_MTH_MISC_AMT_510 = value;
                    break;
                case 511:
                    obj.CHQ_REG_MTH_MISC_AMT_511 = value;
                    break;
                case 512:
                    obj.CHQ_REG_MTH_MISC_AMT_512 = value;
                    break;
                case 513:
                    obj.CHQ_REG_MTH_MISC_AMT_513 = value;
                    break;
                case 514:
                    obj.CHQ_REG_MTH_MISC_AMT_514 = value;
                    break;
                case 515:
                    obj.CHQ_REG_MTH_MISC_AMT_515 = value;
                    break;
                case 516:
                    obj.CHQ_REG_MTH_MISC_AMT_516 = value;
                    break;
                case 517:
                    obj.CHQ_REG_MTH_MISC_AMT_517 = value;
                    break;
                case 518:
                    obj.CHQ_REG_MTH_MISC_AMT_518 = value;
                    break;

                case 61:
                    obj.CHQ_REG_MTH_MISC_AMT_61 = value;
                    break;
                case 62:
                    obj.CHQ_REG_MTH_MISC_AMT_62 = value;
                    break;
                case 63:
                    obj.CHQ_REG_MTH_MISC_AMT_63 = value;
                    break;
                case 64:
                    obj.CHQ_REG_MTH_MISC_AMT_64 = value;
                    break;
                case 65:
                    obj.CHQ_REG_MTH_MISC_AMT_65 = value;
                    break;
                case 66:
                    obj.CHQ_REG_MTH_MISC_AMT_66 = value;
                    break;
                case 67:
                    obj.CHQ_REG_MTH_MISC_AMT_67 = value;
                    break;
                case 68:
                    obj.CHQ_REG_MTH_MISC_AMT_68 = value;
                    break;
                case 69:
                    obj.CHQ_REG_MTH_MISC_AMT_69 = value;
                    break;
                case 610:
                    obj.CHQ_REG_MTH_MISC_AMT_610 = value;
                    break;
                case 611:
                    obj.CHQ_REG_MTH_MISC_AMT_611 = value;
                    break;
                case 612:
                    obj.CHQ_REG_MTH_MISC_AMT_612 = value;
                    break;
                case 613:
                    obj.CHQ_REG_MTH_MISC_AMT_613 = value;
                    break;
                case 614:
                    obj.CHQ_REG_MTH_MISC_AMT_614 = value;
                    break;
                case 615:
                    obj.CHQ_REG_MTH_MISC_AMT_615 = value;
                    break;
                case 616:
                    obj.CHQ_REG_MTH_MISC_AMT_616 = value;
                    break;
                case 617:
                    obj.CHQ_REG_MTH_MISC_AMT_617 = value;
                    break;
                case 618:
                    obj.CHQ_REG_MTH_MISC_AMT_618 = value;
                    break;

                case 71:
                    obj.CHQ_REG_MTH_MISC_AMT_71 = value;
                    break;
                case 72:
                    obj.CHQ_REG_MTH_MISC_AMT_72 = value;
                    break;
                case 73:
                    obj.CHQ_REG_MTH_MISC_AMT_73 = value;
                    break;
                case 74:
                    obj.CHQ_REG_MTH_MISC_AMT_74 = value;
                    break;
                case 75:
                    obj.CHQ_REG_MTH_MISC_AMT_75 = value;
                    break;
                case 76:
                    obj.CHQ_REG_MTH_MISC_AMT_76 = value;
                    break;
                case 77:
                    obj.CHQ_REG_MTH_MISC_AMT_77 = value;
                    break;
                case 78:
                    obj.CHQ_REG_MTH_MISC_AMT_78 = value;
                    break;
                case 79:
                    obj.CHQ_REG_MTH_MISC_AMT_79 = value;
                    break;
                case 710:
                    obj.CHQ_REG_MTH_MISC_AMT_710 = value;
                    break;
                case 711:
                    obj.CHQ_REG_MTH_MISC_AMT_711 = value;
                    break;
                case 712:
                    obj.CHQ_REG_MTH_MISC_AMT_712 = value;
                    break;
                case 713:
                    obj.CHQ_REG_MTH_MISC_AMT_713 = value;
                    break;
                case 714:
                    obj.CHQ_REG_MTH_MISC_AMT_714 = value;
                    break;
                case 715:
                    obj.CHQ_REG_MTH_MISC_AMT_715 = value;
                    break;
                case 716:
                    obj.CHQ_REG_MTH_MISC_AMT_716 = value;
                    break;
                case 717:
                    obj.CHQ_REG_MTH_MISC_AMT_717 = value;
                    break;
                case 718:
                    obj.CHQ_REG_MTH_MISC_AMT_718 = value;
                    break;

                case 81:
                    obj.CHQ_REG_MTH_MISC_AMT_81 = value;
                    break;
                case 82:
                    obj.CHQ_REG_MTH_MISC_AMT_82 = value;
                    break;
                case 83:
                    obj.CHQ_REG_MTH_MISC_AMT_83 = value;
                    break;
                case 84:
                    obj.CHQ_REG_MTH_MISC_AMT_84 = value;
                    break;
                case 85:
                    obj.CHQ_REG_MTH_MISC_AMT_85 = value;
                    break;
                case 86:
                    obj.CHQ_REG_MTH_MISC_AMT_86 = value;
                    break;
                case 87:
                    obj.CHQ_REG_MTH_MISC_AMT_87 = value;
                    break;
                case 88:
                    obj.CHQ_REG_MTH_MISC_AMT_88 = value;
                    break;
                case 89:
                    obj.CHQ_REG_MTH_MISC_AMT_89 = value;
                    break;
                case 810:
                    obj.CHQ_REG_MTH_MISC_AMT_810 = value;
                    break;
                case 811:
                    obj.CHQ_REG_MTH_MISC_AMT_811 = value;
                    break;
                case 812:
                    obj.CHQ_REG_MTH_MISC_AMT_812 = value;
                    break;
                case 813:
                    obj.CHQ_REG_MTH_MISC_AMT_813 = value;
                    break;
                case 814:
                    obj.CHQ_REG_MTH_MISC_AMT_814 = value;
                    break;
                case 815:
                    obj.CHQ_REG_MTH_MISC_AMT_815 = value;
                    break;
                case 816:
                    obj.CHQ_REG_MTH_MISC_AMT_816 = value;
                    break;
                case 817:
                    obj.CHQ_REG_MTH_MISC_AMT_817 = value;
                    break;
                case 818:
                    obj.CHQ_REG_MTH_MISC_AMT_818 = value;
                    break;

                case 91:
                    obj.CHQ_REG_MTH_MISC_AMT_91 = value;
                    break;
                case 92:
                    obj.CHQ_REG_MTH_MISC_AMT_92 = value;
                    break;
                case 93:
                    obj.CHQ_REG_MTH_MISC_AMT_93 = value;
                    break;
                case 94:
                    obj.CHQ_REG_MTH_MISC_AMT_94 = value;
                    break;
                case 95:
                    obj.CHQ_REG_MTH_MISC_AMT_95 = value;
                    break;
                case 96:
                    obj.CHQ_REG_MTH_MISC_AMT_96 = value;
                    break;
                case 97:
                    obj.CHQ_REG_MTH_MISC_AMT_97 = value;
                    break;
                case 98:
                    obj.CHQ_REG_MTH_MISC_AMT_98 = value;
                    break;
                case 99:
                    obj.CHQ_REG_MTH_MISC_AMT_910 = value;
                    break;
                case 911:
                    obj.CHQ_REG_MTH_MISC_AMT_911 = value;
                    break;
                case 912:
                    obj.CHQ_REG_MTH_MISC_AMT_912 = value;
                    break;
                case 913:
                    obj.CHQ_REG_MTH_MISC_AMT_913 = value;
                    break;
                case 914:
                    obj.CHQ_REG_MTH_MISC_AMT_914 = value;
                    break;
                case 915:
                    obj.CHQ_REG_MTH_MISC_AMT_915 = value;
                    break;
                case 916:
                    obj.CHQ_REG_MTH_MISC_AMT_916 = value;
                    break;
                case 917:
                    obj.CHQ_REG_MTH_MISC_AMT_917 = value;
                    break;
                case 918:
                    obj.CHQ_REG_MTH_MISC_AMT_918 = value;
                    break;

                case 101:
                    obj.CHQ_REG_MTH_MISC_AMT_101 = value;
                    break;
                case 102:
                    obj.CHQ_REG_MTH_MISC_AMT_102 = value;
                    break;
                case 103:
                    obj.CHQ_REG_MTH_MISC_AMT_103 = value;
                    break;
                case 104:
                    obj.CHQ_REG_MTH_MISC_AMT_104 = value;
                    break;
                case 105:
                    obj.CHQ_REG_MTH_MISC_AMT_105 = value;
                    break;
                case 106:
                    obj.CHQ_REG_MTH_MISC_AMT_106 = value;
                    break;
                case 107:
                    obj.CHQ_REG_MTH_MISC_AMT_107 = value;
                    break;
                case 108:
                    obj.CHQ_REG_MTH_MISC_AMT_108 = value;
                    break;
                case 109:
                    obj.CHQ_REG_MTH_MISC_AMT_109 = value;
                    break;
                case 1010:
                    obj.CHQ_REG_MTH_MISC_AMT_1010 = value;
                    break;
                case 1011:
                    obj.CHQ_REG_MTH_MISC_AMT_1011 = value;
                    break;
                case 1012:
                    obj.CHQ_REG_MTH_MISC_AMT_1012 = value;
                    break;
                case 1013:
                    obj.CHQ_REG_MTH_MISC_AMT_1013 = value;
                    break;
                case 1014:
                    obj.CHQ_REG_MTH_MISC_AMT_1014 = value;
                    break;
                case 1015:
                    obj.CHQ_REG_MTH_MISC_AMT_1015 = value;
                    break;
                case 1016:
                    obj.CHQ_REG_MTH_MISC_AMT_1016 = value;
                    break;
                case 1017:
                    obj.CHQ_REG_MTH_MISC_AMT_1017 = value;
                    break;
                case 1018:
                    obj.CHQ_REG_MTH_MISC_AMT_1018 = value;
                    break;
            }
        }

        public   void CHQ_REG_MTH_EXP_AMT_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_MTH_EXP_AMT1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_MTH_EXP_AMT2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_MTH_EXP_AMT3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_MTH_EXP_AMT4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_MTH_EXP_AMT5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_MTH_EXP_AMT6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_MTH_EXP_AMT7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_MTH_EXP_AMT8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_MTH_EXP_AMT9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_MTH_EXP_AMT10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_MTH_EXP_AMT11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MTH_EXP_AMT12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MTH_EXP_AMT13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MTH_EXP_AMT14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MTH_EXP_AMT15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MTH_EXP_AMT16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MTH_EXP_AMT17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MTH_EXP_AMT18 = value;
                    break;
            }
        }

        public   void CHQ_REG_COMP_ANN_EXP_THIS_PAY_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_COMP_ANN_EXP_THIS_PAY18 = value;
                    break;
            }
        }

        public   void CHQ_REG_MTH_CEIL_AMT_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_MTH_CEIL_AMT1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_MTH_CEIL_AMT2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_MTH_CEIL_AMT3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_MTH_CEIL_AMT4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_MTH_CEIL_AMT5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_MTH_CEIL_AMT6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_MTH_CEIL_AMT7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_MTH_CEIL_AMT8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_MTH_CEIL_AMT9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_MTH_CEIL_AMT10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_MTH_CEIL_AMT11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MTH_CEIL_AMT12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MTH_CEIL_AMT13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MTH_CEIL_AMT14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MTH_CEIL_AMT15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MTH_CEIL_AMT16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MTH_CEIL_AMT17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MTH_CEIL_AMT18 = value;
                    break;
            }
        }

        public   void CHQ_REG_COMP_ANN_CEIL_THIS_PAY_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_COMP_ANN_CEIL_THIS_PAY18 = value;
                    break;
            }
        }

        public   void CHQ_REG_EARNINGS_THIS_MTH_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_EARNINGS_THIS_MTH1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_EARNINGS_THIS_MTH2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_EARNINGS_THIS_MTH3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_EARNINGS_THIS_MTH4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_EARNINGS_THIS_MTH5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_EARNINGS_THIS_MTH6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_EARNINGS_THIS_MTH7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_EARNINGS_THIS_MTH8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_EARNINGS_THIS_MTH9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_EARNINGS_THIS_MTH10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_EARNINGS_THIS_MTH11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_EARNINGS_THIS_MTH12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_EARNINGS_THIS_MTH13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_EARNINGS_THIS_MTH14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_EARNINGS_THIS_MTH15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_EARNINGS_THIS_MTH16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_EARNINGS_THIS_MTH17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_EARNINGS_THIS_MTH18 = value;
                    break;
            }
        }

        public   void CHQ_REG_REGULAR_PAY_THIS_MTH_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_REGULAR_PAY_THIS_MTH18 = value;
                    break;

            }
        }

        public   void CHQ_REG_MAN_PAY_THIS_MTH_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MAN_PAY_THIS_MTH18 = value;
                    break;
            }
        }

        public   void CHQ_REG_MAN_TAX_THIS_MTH_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_MAN_TAX_THIS_MTH18 = value;
                    break;
            }
        }

        public   void CHQ_REG_PAY_DATE_SET(F060_CHEQUE_REG_MSTR obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CHQ_REG_PAY_DATE1 = value;
                    break;
                case 2:
                    obj.CHQ_REG_PAY_DATE2 = value;
                    break;
                case 3:
                    obj.CHQ_REG_PAY_DATE3 = value;
                    break;
                case 4:
                    obj.CHQ_REG_PAY_DATE4 = value;
                    break;
                case 5:
                    obj.CHQ_REG_PAY_DATE5 = value;
                    break;
                case 6:
                    obj.CHQ_REG_PAY_DATE6 = value;
                    break;
                case 7:
                    obj.CHQ_REG_PAY_DATE7 = value;
                    break;
                case 8:
                    obj.CHQ_REG_PAY_DATE8 = value;
                    break;
                case 9:
                    obj.CHQ_REG_PAY_DATE9 = value;
                    break;
                case 10:
                    obj.CHQ_REG_PAY_DATE10 = value;
                    break;
                case 11:
                    obj.CHQ_REG_PAY_DATE11 = value;
                    break;
                case 12:
                    obj.CHQ_REG_PAY_DATE12 = value;
                    break;
                case 13:
                    obj.CHQ_REG_PAY_DATE13 = value;
                    break;
                case 14:
                    obj.CHQ_REG_PAY_DATE14 = value;
                    break;
                case 15:
                    obj.CHQ_REG_PAY_DATE15 = value;
                    break;
                case 16:
                    obj.CHQ_REG_PAY_DATE16 = value;
                    break;
                case 17:
                    obj.CHQ_REG_PAY_DATE17 = value;
                    break;
                case 18:
                    obj.CHQ_REG_PAY_DATE18 = value;
                    break;
            }
        }
        #endregion

        #region Constant_Mstr

        public string CONST_CLASS_LTR(CONSTANTS_MSTR_REC_4 obj, int col)
        {
            string retVal = string.Empty;
            
            switch(col)
            {
                case 1:
                    retVal = obj.CONST_CLASS_LTR1;
                    break;
                case 2:
                    retVal = obj.CONST_CLASS_LTR2;
                    break;
                case 3:
                    retVal = obj.CONST_CLASS_LTR3;
                    break;
                case 4:
                    retVal = obj.CONST_CLASS_LTR4;
                    break;
                case 5:
                    retVal = obj.CONST_CLASS_LTR5;
                    break;
                case 6:
                    retVal = obj.CONST_CLASS_LTR6;
                    break;
                case 7:
                    retVal = obj.CONST_CLASS_LTR7;
                    break;
                case 8:
                    retVal = obj.CONST_CLASS_LTR8;
                    break;
                case 9:
                    retVal = obj.CONST_CLASS_LTR9;
                    break;
                case 10:
                    retVal = obj.CONST_CLASS_LTR10;
                    break;
                case 11:
                    retVal = obj.CONST_CLASS_LTR11;
                    break;
                case 12:
                    retVal = obj.CONST_CLASS_LTR12;
                    break;
                case 13:
                    retVal = obj.CONST_CLASS_LTR13;
                    break;
                case 14:
                    retVal = obj.CONST_CLASS_LTR14;
                    break;
                case 15:
                    retVal = obj.CONST_CLASS_LTR15;
                    break;
            }
            return retVal;
        }

        public void CONST_CLASS_LTR_SET(CONSTANTS_MSTR_REC_4 obj, int col, string value)
        {
            switch(col)
            {
                case 1:
                    obj.CONST_CLASS_LTR1 = value;
                    break;
                case 2:
                    obj.CONST_CLASS_LTR2 = value;
                    break;
                case 3:
                    obj.CONST_CLASS_LTR3 = value;
                    break;
                case 4:
                    obj.CONST_CLASS_LTR4 = value;
                    break;
                case 5:
                    obj.CONST_CLASS_LTR5 = value;
                    break;
                case 6:
                    obj.CONST_CLASS_LTR6 = value;
                    break;
                case 7:
                    obj.CONST_CLASS_LTR7 = value;
                    break;
                case 8:
                    obj.CONST_CLASS_LTR8 = value;
                    break;
                case 9:
                    obj.CONST_CLASS_LTR9 = value;
                    break;
                case 10:
                    obj.CONST_CLASS_LTR10 = value;
                    break;
                case 11:
                    obj.CONST_CLASS_LTR11 = value;
                    break;
                case 12:
                    obj.CONST_CLASS_LTR12 = value;
                    break;
                case 13:
                    obj.CONST_CLASS_LTR13 = value;
                    break;
                case 14:
                    obj.CONST_CLASS_LTR14 = value;
                    break;
                case 15:
                    obj.CONST_CLASS_LTR15 = value;
                    break;
            }
        }

        public string CONST_CLASS_DESC (CONSTANTS_MSTR_REC_4 obj, int col)
        {
            string retVal = string.Empty;

            switch (col)
            {
                case 1:
                    retVal = obj.CONST_CLASS_DESC1;
                    break;
                case 2:
                    retVal = obj.CONST_CLASS_DESC2;
                    break;
                case 3:
                    retVal = obj.CONST_CLASS_DESC3;
                    break;
                case 4:
                    retVal = obj.CONST_CLASS_DESC4;
                    break;
                case 5:
                    retVal = obj.CONST_CLASS_DESC5;
                    break;
                case 6:
                    retVal = obj.CONST_CLASS_DESC6;
                    break;
                case 7:
                    retVal = obj.CONST_CLASS_DESC7;
                    break;
                case 8:
                    retVal = obj.CONST_CLASS_DESC8;
                    break;
                case 9:
                    retVal = obj.CONST_CLASS_DESC9;
                    break;
                case 10:
                    retVal = obj.CONST_CLASS_DESC10;
                    break;
                case 11:
                    retVal = obj.CONST_CLASS_DESC11;
                    break;
                case 12:
                    retVal = obj.CONST_CLASS_DESC12;
                    break;
                case 13:
                    retVal = obj.CONST_CLASS_DESC13;
                    break;
                case 14:
                    retVal = obj.CONST_CLASS_DESC14;
                    break;
                case 15:
                    retVal = obj.CONST_CLASS_DESC15;
                    break;
            }
            return retVal;
        }

        public void CONST_CLASS_DESC_SET (CONSTANTS_MSTR_REC_4 obj, int col, string value)
        {
            switch(col)
            {
                case 1:
                    obj.CONST_CLASS_DESC1 = value;
                    break;
                case 2:
                    obj.CONST_CLASS_DESC2 = value;
                    break;
                case 3:
                    obj.CONST_CLASS_DESC3 = value;
                    break;
                case 4:
                    obj.CONST_CLASS_DESC4 = value;
                    break;
                case 5:
                    obj.CONST_CLASS_DESC5 = value;
                    break;
                case 6:
                    obj.CONST_CLASS_DESC6 = value;
                    break;
                case 7:
                    obj.CONST_CLASS_DESC7 = value;
                    break;
                case 8:
                    obj.CONST_CLASS_DESC8 = value;
                    break;
                case 9:
                    obj.CONST_CLASS_DESC9 = value;
                    break;
                case 10:
                    obj.CONST_CLASS_DESC10 = value;
                    break;
                case 11:
                    obj.CONST_CLASS_DESC11 = value;
                    break;
                case 12:
                    obj.CONST_CLASS_DESC12 = value;
                    break;
                case 13:
                    obj.CONST_CLASS_DESC13 = value;
                    break;
                case 14:
                    obj.CONST_CLASS_DESC14 = value;
                    break;
                case 15:
                    obj.CONST_CLASS_DESC15 = value;
                    break;
            }
        }

        public int CONST_CLINIC_NBR_1_2(CONSTANTS_MSTR_REC_1 obj, int col)
        {
            int retVal = 0;
            switch(col)
            {
                case 1:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_21);
                    break;
                case 2:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_22);
                    break;
                case 3:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_23);
                    break;
                case 4:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_24);
                    break;
                case 5:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_25);
                    break;
                case 6:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_26);
                    break;
                case 7:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_27);
                    break;
                case 8:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_28);
                    break;
                case 9:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_29);
                    break;
                case 10:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_210);
                    break;
                case 11:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_211);
                    break;
                case 12:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_212);
                    break;
                case 13:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_213);
                    break;
                case 14:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_214);
                    break;
                case 15:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_215);
                    break;
                case 16:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_216);
                    break;
                case 17:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_217);
                    break;
                case 18:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_218);
                    break;
                case 19:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_219);
                    break;
                case 20:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_220);
                    break;
                case 21:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_221);
                    break;
                case 22:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_222);
                    break;
                case 23:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_223);
                    break;
                case 24:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_224);
                    break;
                case 25:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_225);
                    break;
                case 26:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_226);
                    break;
                case 27:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_227);
                    break;
                case 28:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_228);
                    break;
                case 29:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_229);
                    break;
                case 30:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_230);
                    break;
                case 31:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_231);
                    break;
                case 32:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_232);
                    break;
                case 33:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_233);
                    break;
                case 34:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_234);
                    break;
                case 35:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_235);
                    break;
                case 36:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_236);
                    break;
                case 37:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_237);
                    break;
                case 38:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_238);
                    break;
                case 39:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_239);
                    break;
                case 40:
                    retVal = Util.NumInt(obj.CONST_CLINIC_NBR_1_240);
                    break;
            }
            return retVal;
        }

        public void CONST_CLINIC_NBR_1_2_SET(CONSTANTS_MSTR_REC_1 obj, int col, int value)
        {            
            switch (col)
            {
                case 1:
                    obj.CONST_CLINIC_NBR_1_21 = value;
                    break;
                case 2:
                    obj.CONST_CLINIC_NBR_1_22 = value;
                    break;
                case 3:
                    obj.CONST_CLINIC_NBR_1_23 = value;
                    break;
                case 4:
                    obj.CONST_CLINIC_NBR_1_24 = value;
                    break;
                case 5:
                    obj.CONST_CLINIC_NBR_1_25 = value;
                    break;
                case 6:
                    obj.CONST_CLINIC_NBR_1_26 = value;
                    break;
                case 7:
                    obj.CONST_CLINIC_NBR_1_27 = value;
                    break;
                case 8:
                    obj.CONST_CLINIC_NBR_1_28 = value;
                    break;
                case 9:
                    obj.CONST_CLINIC_NBR_1_29 = value;
                    break;
                case 10:
                    obj.CONST_CLINIC_NBR_1_210 = value;
                    break;
                case 11:
                    obj.CONST_CLINIC_NBR_1_211 = value;
                    break;
                case 12:
                    obj.CONST_CLINIC_NBR_1_212 = value;
                    break;
                case 13:
                    obj.CONST_CLINIC_NBR_1_213 = value;
                    break;
                case 14:
                    obj.CONST_CLINIC_NBR_1_214 = value;
                    break;
                case 15:
                    obj.CONST_CLINIC_NBR_1_215 = value;
                    break;
                case 16:
                    obj.CONST_CLINIC_NBR_1_216 = value;
                    break;
                case 17:
                    obj.CONST_CLINIC_NBR_1_217 = value;
                    break;
                case 18:
                    obj.CONST_CLINIC_NBR_1_218 = value;
                    break;
                case 19:
                    obj.CONST_CLINIC_NBR_1_219 = value;
                    break;
                case 20:
                    obj.CONST_CLINIC_NBR_1_220 = value;
                    break;
                case 21:
                    obj.CONST_CLINIC_NBR_1_221 = value;
                    break;
                case 22:
                    obj.CONST_CLINIC_NBR_1_222 = value;
                    break;
                case 23:
                    obj.CONST_CLINIC_NBR_1_223 = value;
                    break;
                case 24:
                    obj.CONST_CLINIC_NBR_1_224 = value;
                    break;
                case 25:
                    obj.CONST_CLINIC_NBR_1_225 = value;
                    break;
                case 26:
                    obj.CONST_CLINIC_NBR_1_226 = value;
                    break;
                case 27:
                    obj.CONST_CLINIC_NBR_1_227 = value;
                    break;
                case 28:
                    obj.CONST_CLINIC_NBR_1_228 = value;
                    break;
                case 29:
                    obj.CONST_CLINIC_NBR_1_229 = value;
                    break;
                case 30:
                    obj.CONST_CLINIC_NBR_1_230 = value;
                    break;
                case 31:
                    obj.CONST_CLINIC_NBR_1_231 = value;
                    break;
                case 32:
                    obj.CONST_CLINIC_NBR_1_232 = value;
                    break;
                case 33:
                    obj.CONST_CLINIC_NBR_1_233 = value;
                    break;
                case 34:
                    obj.CONST_CLINIC_NBR_1_234 = value;
                    break;
                case 35:
                    obj.CONST_CLINIC_NBR_1_235 = value;
                    break;
                case 36:
                    obj.CONST_CLINIC_NBR_1_236 = value;
                    break;
                case 37:
                    obj.CONST_CLINIC_NBR_1_237 = value;
                    break;
                case 38:
                    obj.CONST_CLINIC_NBR_1_238 = value;
                    break;
                case 39:
                    obj.CONST_CLINIC_NBR_1_239 = value;
                    break;
                case 40:
                    obj.CONST_CLINIC_NBR_1_240 = value;
                    break;               
            }            
        }

        public string CONST_CLINIC_NBR(CONSTANTS_MSTR_REC_1 obj, int col)
        {
            string retVal = string.Empty;

            switch(col)
            {
                case 1:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR1);
                    break;
                case 2:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR2);
                    break;
                case 3:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR3);
                    break;
                case 4:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR4);
                    break;
                case 5:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR5);
                    break;
                case 6:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR6);
                    break;
                case 7:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR7);
                    break;
                case 8:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR8);
                    break;
                case 9:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR9);
                    break;
                case 10:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR10);
                    break;
                case 11:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR11);
                    break;
                case 12:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR12);
                    break;
                case 13:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR13);
                    break;
                case 14:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR14);
                    break;
                case 15:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR15);
                    break;
                case 16:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR16);
                    break;
                case 17:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR17);
                    break;
                case 18:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR18);
                    break;
                case 19:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR19);
                    break;
                case 20:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR20);
                    break;
                case 21:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR21);
                    break;
                case 22:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR22);
                    break;
                case 23:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR23);
                    break;
                case 24:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR24);
                    break;
                case 25:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR25);
                    break;
                case 26:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR26);
                    break;
                case 27:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR27);
                    break;
                case 28:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR28);
                    break;
                case 29:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR29);
                    break;
                case 30:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR30);
                    break;
                case 31:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR31);
                    break;
                case 32:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR32);
                    break;
                case 33:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR33);
                    break;
                case 34:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR34);
                    break;
                case 35:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR35);
                    break;
                case 36:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR36);
                    break;
                case 37:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR37);
                    break;
                case 38:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR38);
                    break;
                case 39:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR39);
                    break;
                case 40:
                    retVal = Util.Str(obj.CONST_CLINIC_NBR40);
                    break;
            }
            return retVal;
        }

        public void CONST_CLINIC_NBR_SET(CONSTANTS_MSTR_REC_1 obj, int col, string value)
        {            

            switch (col)
            {
                case 1:
                    obj.CONST_CLINIC_NBR1 = value;
                    break;
                case 2:
                    obj.CONST_CLINIC_NBR2 = value;
                    break;
                case 3:
                    obj.CONST_CLINIC_NBR3 = value;
                    break;
                case 4:
                    obj.CONST_CLINIC_NBR4 = value;
                    break;
                case 5:
                    obj.CONST_CLINIC_NBR5 = value;
                    break;
                case 6:
                    obj.CONST_CLINIC_NBR6 = value;
                    break;
                case 7:
                    obj.CONST_CLINIC_NBR7 = value;
                    break;
                case 8:
                    obj.CONST_CLINIC_NBR8 = value;
                    break;
                case 9:
                    obj.CONST_CLINIC_NBR9 = value;
                    break;
                case 10:
                    obj.CONST_CLINIC_NBR10 = value;
                    break;
                case 11:
                    obj.CONST_CLINIC_NBR11 = value;
                    break;
                case 12:
                    obj.CONST_CLINIC_NBR12 = value;
                    break;
                case 13:
                    obj.CONST_CLINIC_NBR13 = value;
                    break;
                case 14:
                    obj.CONST_CLINIC_NBR14 = value;
                    break;
                case 15:
                    obj.CONST_CLINIC_NBR15 = value;
                    break;
                case 16:
                    obj.CONST_CLINIC_NBR16 = value;
                    break;
                case 17:
                    obj.CONST_CLINIC_NBR17 = value;
                    break;
                case 18:
                    obj.CONST_CLINIC_NBR18 = value;
                    break;
                case 19:
                    obj.CONST_CLINIC_NBR19 = value;
                    break;
                case 20:
                    obj.CONST_CLINIC_NBR20 = value;
                    break;
                case 21:
                    obj.CONST_CLINIC_NBR21 = value;
                    break;
                case 22:
                    obj.CONST_CLINIC_NBR22 = value;
                    break;
                case 23:
                    obj.CONST_CLINIC_NBR23 = value;
                    break;
                case 24:
                    obj.CONST_CLINIC_NBR24 = value;
                    break;
                case 25:
                    obj.CONST_CLINIC_NBR25 = value;
                    break;
                case 26:
                    obj.CONST_CLINIC_NBR26 = value;
                    break;
                case 27:
                    obj.CONST_CLINIC_NBR27 = value;
                    break;
                case 28:
                    obj.CONST_CLINIC_NBR28 = value;
                    break;
                case 29:
                    obj.CONST_CLINIC_NBR29 = value;
                    break;
                case 30:
                    obj.CONST_CLINIC_NBR30 = value;
                    break;
                case 31:
                    obj.CONST_CLINIC_NBR31 = value;
                    break;
                case 32:
                    obj.CONST_CLINIC_NBR32 = value;
                    break;
                case 33:
                    obj.CONST_CLINIC_NBR33 = value;
                    break;
                case 34:
                    obj.CONST_CLINIC_NBR34 = value;
                    break;
                case 35:
                    obj.CONST_CLINIC_NBR35 = value;
                    break;
                case 36:
                    obj.CONST_CLINIC_NBR36 = value;
                    break;
                case 37:
                    obj.CONST_CLINIC_NBR37 = value;
                    break;
                case 38:
                    obj.CONST_CLINIC_NBR38 = value;
                    break;
                case 39:
                    obj.CONST_CLINIC_NBR39 = value;
                    break;
                case 40:
                    obj.CONST_CLINIC_NBR40 = value;
                    break;
            }            
        }

        public   decimal CONST_MISC_CURR(CONSTANTS_MSTR_REC_3 obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_MISC_CURR9);
                    break;
            }
            return retVal;
        }

        public void CONST_MISC_CURR_SET(CONSTANTS_MSTR_REC_3 obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_MISC_CURR1 = value;
                    break;
                case 2:
                    obj.CONST_MISC_CURR2 = value;
                    break;
                case 3:
                    obj.CONST_MISC_CURR3 = value;
                    break;
                case 4:
                    obj.CONST_MISC_CURR4 = value;
                    break;
                case 5:
                    obj.CONST_MISC_CURR5 = value;
                    break;
                case 6:
                    obj.CONST_MISC_CURR6 = value;
                    break;
                case 7:
                    obj.CONST_MISC_CURR7 = value;
                    break;
                case 8:
                    obj.CONST_MISC_CURR8 = value;
                    break;
                case 9:
                    obj.CONST_MISC_CURR9 = value;
                    break;
            }
        }

        public   decimal CONST_MISC_PREV(CONSTANTS_MSTR_REC_3 obj, int col)
        {
            decimal retVal = 0;
            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_MISC_PREV9);
                    break;
            }
            return retVal;
        }

        public void CONST_MISC_PREV_SET(CONSTANTS_MSTR_REC_3 obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_MISC_PREV1 = value;
                    break;
                case 2:
                    obj.CONST_MISC_PREV2 = value;
                    break;
                case 3:
                    obj.CONST_MISC_PREV3 = value;
                    break;
                case 4:
                    obj.CONST_MISC_PREV4 = value;
                    break;
                case 5:
                    obj.CONST_MISC_PREV5 = value;
                    break;
                case 6:
                    obj.CONST_MISC_PREV6 = value;
                    break;
                case 7:
                    obj.CONST_MISC_PREV7 = value;
                    break;
                case 8:
                    obj.CONST_MISC_PREV8 = value;
                    break;
                case 9:
                    obj.CONST_MISC_PREV9 = value;
                    break;
            }
        }

        public void CONST_REG_SET (CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col, decimal value)
        {
            if (currentPrev == 1 && col == 1) // current
            {
                obj.CONST_REG_H_CURR = value;
            }
            else if (currentPrev == 1 && col == 2 ) // current
            {
                obj.CONST_REG_A_CURR = value;
            }
            else if (currentPrev == 2 && col == 1 ) // previous
            {
                obj.CONST_REG_H_PREV = value;
            }
            else if (currentPrev == 2 && col == 2 ) // previous
            {
                obj.CONST_REG_A_PREV = value;
            }
        }

        public void CONST_ASST_SET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col, decimal value)
        {
            if (currentPrev == 1 && col == 1)
            {
                obj.CONST_ASST_H_CURR = value;
            }
            else if (currentPrev == 1 && col == 2)
            {
                obj.CONST_ASST_A_CURR = value;
            }
            else if (currentPrev == 2 && col == 1)
            {
                obj.CONST_ASST_H_PREV = value;
            }
            else if (currentPrev == 2 && col == 2)
            {
                obj.CONST_ASST_A_PREV = value;
            }
        }

        public decimal CONST_ASST_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col)
        {
            decimal retVal = 0;
            if (currentPrev == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.CONST_ASST_H_CURR);
            }
            else if (currentPrev == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.CONST_ASST_A_CURR);
            }
            else if (currentPrev == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.CONST_ASST_H_PREV);
            }
            else if (currentPrev == 2 && col == 2)
            {
                retVal = Util.NumDec(obj.CONST_ASST_A_PREV);
            }
            return retVal;
        }

        public void CONST_BILATERAL_SET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, decimal value)
        {
            if (currentPrev == 1)
            {
                obj.CONST_BILATERAL_CURR = value;
            }
            else if (currentPrev == 2 )
            {
                obj.CONST_BILATERAL_PREV = value;
            }
        }

        public decimal CONST_BILATERAL_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev )
        {
            decimal retVal = 0;
            if (currentPrev == 1)
            {
                retVal = Util.NumDec(obj.CONST_BILATERAL_CURR);
            }
            else if (currentPrev == 2)
            {
                retVal = Util.NumDec(obj.CONST_BILATERAL_PREV);
            }
            return retVal;
        }

        public void CONST_CON_NBR_SET(CONSTANTS_MSTR_REC_5 obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_CON_NBR1 = value;
                    break;
                case 2:
                    obj.CONST_CON_NBR2 = value;
                    break;
                case 3:
                    obj.CONST_CON_NBR3 = value;
                    break;
                case 4:
                    obj.CONST_CON_NBR4 = value;
                    break;
                case 5:
                    obj.CONST_CON_NBR5 = value;
                    break;
                case 6:
                    obj.CONST_CON_NBR6 = value;
                    break;
                case 7:
                    obj.CONST_CON_NBR7 = value;
                    break;
                case 8:
                    obj.CONST_CON_NBR8 = value;
                    break;
                case 9:
                    obj.CONST_CON_NBR9 = value;
                    break;
                case 10:
                    obj.CONST_CON_NBR10 = value;
                    break;
                case 11:
                    obj.CONST_CON_NBR11 = value;
                    break;
                case 12:
                    obj.CONST_CON_NBR12 = value;
                    break;
                case 13:
                    obj.CONST_CON_NBR13 = value;
                    break;
                case 14:
                    obj.CONST_CON_NBR14 = value;
                    break;
                case 15:
                    obj.CONST_CON_NBR15 = value;
                    break;
                case 16:
                    obj.CONST_CON_NBR16 = value;
                    break;
                case 17:
                    obj.CONST_CON_NBR17 = value;
                    break;
                case 18:
                    obj.CONST_CON_NBR18 = value;
                    break;
                case 19:
                    obj.CONST_CON_NBR19 = value;
                    break;
                case 20:
                    obj.CONST_CON_NBR20 = value;
                    break;
                case 21:
                    obj.CONST_CON_NBR21 = value;
                    break;
                case 22:
                    obj.CONST_CON_NBR22 = value;
                    break;
                case 23:
                    obj.CONST_CON_NBR23 = value;
                    break;
                case 24:
                    obj.CONST_CON_NBR24 = value;
                    break;
                case 25:
                    obj.CONST_CON_NBR25 = value;
                    break;                
            }
        }

        public decimal CONST_CON_NBR_GET(CONSTANTS_MSTR_REC_5 obj, int col )
        {
            decimal retVal = 0;

            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_CON_NBR1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_CON_NBR2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_CON_NBR3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_CON_NBR4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_CON_NBR5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_CON_NBR6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_CON_NBR7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_CON_NBR8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_CON_NBR9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CONST_CON_NBR10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CONST_CON_NBR11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CONST_CON_NBR12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CONST_CON_NBR13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CONST_CON_NBR14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CONST_CON_NBR15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CONST_CON_NBR16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CONST_CON_NBR17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CONST_CON_NBR18);
                    break;
                case 19:
                    retVal = Util.NumDec(obj.CONST_CON_NBR19);
                    break;
                case 20:
                    retVal = Util.NumDec(obj.CONST_CON_NBR20);
                    break;
                case 21:
                    retVal = Util.NumDec(obj.CONST_CON_NBR21);
                    break;
                case 22:
                    retVal = Util.NumDec(obj.CONST_CON_NBR22);
                    break;
                case 23:
                    retVal = Util.NumDec(obj.CONST_CON_NBR23);
                    break;
                case 24:
                    retVal = Util.NumDec(obj.CONST_CON_NBR24);
                    break;
                case 25:
                    retVal = Util.NumDec(obj.CONST_CON_NBR25);
                    break;
            }
            return retVal;
        }

        public void CONST_CERT_SET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col, decimal value)
        {
            if (currentPrev == 1 && col == 1 )
            {
                obj.CONST_CERT_H_CURR = value;
            }
            else if (currentPrev == 1 && col == 2 )
            {
                obj.CONST_CERT_A_CURR = value;
            }
            else if (currentPrev == 2 && col == 1)
            {
                obj.CONST_CERT_H_PREV = value;
            }
            else if (currentPrev == 2 && col == 2)
            {
                obj.CONST_CERT_A_PREV = value;
            }
        }

        public decimal CONST_CERT_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col)
        {
            decimal retVal = 0;
            if (currentPrev == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.CONST_CERT_H_CURR);
            }
            else if (currentPrev == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.CONST_CERT_A_CURR);
            }
            else if (currentPrev == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.CONST_CERT_H_PREV);
            }
            else if (currentPrev == 2 && col == 2)
            {
                retVal = Util.NumDec(obj.CONST_CERT_A_PREV);
            }
            return retVal;
        }

        public void CONST_NX_AVAIL_PAT_SET (CONSTANTS_MSTR_REC_5 obj, int col, decimal value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_NX_AVAIL_PAT1 = value;
                    break;
                case 2:
                    obj.CONST_NX_AVAIL_PAT2 = value;
                    break;
                case 3:
                    obj.CONST_NX_AVAIL_PAT3 = value;
                    break;
                case 4:
                    obj.CONST_NX_AVAIL_PAT4 = value;
                    break;
                case 5:
                    obj.CONST_NX_AVAIL_PAT5 = value;
                    break;
                case 6:
                    obj.CONST_NX_AVAIL_PAT6 = value;
                    break;
                case 7:
                    obj.CONST_NX_AVAIL_PAT7 = value;
                    break;
                case 8:
                    obj.CONST_NX_AVAIL_PAT8 = value;
                    break;
                case 9:
                    obj.CONST_NX_AVAIL_PAT9 = value;
                    break;
                case 10:
                    obj.CONST_NX_AVAIL_PAT10 = value;
                    break;
                case 11:
                    obj.CONST_NX_AVAIL_PAT11 = value;
                    break;
                case 12:
                    obj.CONST_NX_AVAIL_PAT12 = value;
                    break;
                case 13:
                    obj.CONST_NX_AVAIL_PAT13 = value;
                    break;
                case 14:
                    obj.CONST_NX_AVAIL_PAT14 = value;
                    break;
                case 15:
                    obj.CONST_NX_AVAIL_PAT15 = value;
                    break;
                case 16:
                    obj.CONST_NX_AVAIL_PAT16 = value;
                    break;
                case 17:
                    obj.CONST_NX_AVAIL_PAT17 = value;
                    break;
                case 18:
                    obj.CONST_NX_AVAIL_PAT18 = value;
                    break;
                case 19:
                    obj.CONST_NX_AVAIL_PAT19 = value;
                    break;
                case 20:
                    obj.CONST_NX_AVAIL_PAT20 = value;
                    break;
                case 21:
                    obj.CONST_NX_AVAIL_PAT21 = value;
                    break;
                case 22:
                    obj.CONST_NX_AVAIL_PAT22 = value;
                    break;
                case 23:
                    obj.CONST_NX_AVAIL_PAT23 = value;
                    break;
                case 24:
                    obj.CONST_NX_AVAIL_PAT24 = value;
                    break;
                case 25:
                    obj.CONST_NX_AVAIL_PAT25 = value;
                    break;
            }
        }

        public decimal CONST_NX_AVAIL_PAT_GET(CONSTANTS_MSTR_REC_5 obj, int col)
        {
            decimal retVal = 0;

            switch (col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT18);
                    break;
                case 19:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT19);
                    break;
                case 20:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT20);
                    break;
                case 21:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT21);
                    break;
                case 22:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT22);
                    break;
                case 23:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT23);
                    break;
                case 24:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT24);
                    break;
                case 25:
                    retVal = Util.NumDec(obj.CONST_NX_AVAIL_PAT25);
                    break;
            }

            return retVal;
        }

        public decimal CONST_REG_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, int col)
        {
            decimal retVal = 0;

            if (currentPrev == 1 && col == 1) // current
            {
                retVal = Util.NumDec(obj.CONST_REG_H_CURR);
            }
            else if (currentPrev == 1 && col == 2) // current
            {
                retVal = Util.NumDec(obj.CONST_REG_A_CURR);
            }
            else if (currentPrev == 2 && col == 1) // previous
            {
                retVal = Util.NumDec(obj.CONST_REG_H_PREV);
            }
            else if (currentPrev == 2 && col == 2) // previous
            {
                retVal = Util.NumDec(obj.CONST_REG_A_PREV);
            }

            return retVal;
        }

        public string CONST_SECTION(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            string retVal = string.Empty;

            switch (col)
            {
                case 1:
                    retVal = Util.Str(obj.CONST_SECTION1);
                    break;
                case 2:
                    retVal = Util.Str(obj.CONST_SECTION2);
                    break;
                case 3:
                    retVal = Util.Str(obj.CONST_SECTION3);
                    break;
                case 4:
                    retVal = Util.Str(obj.CONST_SECTION4);
                    break;
                case 5:
                    retVal = Util.Str(obj.CONST_SECTION5);
                    break;
                case 6:
                    retVal = Util.Str(obj.CONST_SECTION6);
                    break;
                case 7:
                    retVal = Util.Str(obj.CONST_SECTION7);
                    break;
                case 8:
                    retVal = Util.Str(obj.CONST_SECTION8);
                    break;
                case 9:
                    retVal = Util.Str(obj.CONST_SECTION9);
                    break;
                case 10:
                    retVal = Util.Str(obj.CONST_SECTION10);
                    break;
                case 11:
                    retVal = Util.Str(obj.CONST_SECTION11);
                    break;
                case 12:
                    retVal = Util.Str(obj.CONST_SECTION12);
                    break;
                case 13:
                    retVal = Util.Str(obj.CONST_SECTION13);
                    break;
                case 14:
                    retVal = Util.Str(obj.CONST_SECTION14);
                    break;
                case 15:
                    retVal = Util.Str(obj.CONST_SECTION15);
                    break;
                case 16:
                    retVal = Util.Str(obj.CONST_SECTION16);
                    break;
                case 17:
                    retVal = Util.Str(obj.CONST_SECTION17);
                    break;
                case 18:
                    retVal = Util.Str(obj.CONST_SECTION18);
                    break;
                case 19:
                    retVal = Util.Str(obj.CONST_SECTION19);
                    break;
                
            }
            return retVal;
        }

        public void CONST_SECTION_SET(CONSTANTS_MSTR_REC_2 obj, int col,string value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_SECTION1 = value;
                    break;
                case 2:
                    obj.CONST_SECTION2 = value;
                    break;
                case 3:
                    obj.CONST_SECTION3 = value;
                    break;
                case 4:
                    obj.CONST_SECTION4 = value;
                    break;
                case 5:
                    obj.CONST_SECTION5 = value;
                    break;
                case 6:
                    obj.CONST_SECTION6 = value;
                    break;
                case 7:
                    obj.CONST_SECTION7 = value;
                    break;
                case 8:
                    obj.CONST_SECTION8 = value;
                    break;
                case 9:
                    obj.CONST_SECTION9 = value;
                    break;
                case 10:
                    obj.CONST_SECTION10 = value;
                    break;
                case 11:
                    obj.CONST_SECTION11 = value;
                    break;
                case 12:
                    obj.CONST_SECTION12 = value;
                    break;
                case 13:
                    obj.CONST_SECTION13 = value;
                    break;
                case 14:
                    obj.CONST_SECTION14 = value;
                    break;
                case 15:
                    obj.CONST_SECTION15 = value;
                    break;
                case 16:
                    obj.CONST_SECTION16 = value;
                    break;
                case 17:
                    obj.CONST_SECTION17 = value;
                    break;
                case 18:
                    obj.CONST_SECTION18 = value;
                    break;
                case 19:
                    obj.CONST_SECTION19 = value;
                    break;                
            }
        }

        public void CONST_SR_SET(CONSTANTS_MSTR_REC_2 obj, int currentPrev,decimal value)
        {
            if (currentPrev == 1)  // current
            {
                obj.CONST_SR_CURR = value;
            }
            else if (currentPrev == 2)
            {
                obj.CONST_SR_PREV = value;
            }
        }

        public decimal CONST_SR_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev )
        {
            decimal retVal = 0;
            if (currentPrev == 1)  // current
            {
                retVal = Util.NumDec(obj.CONST_SR_CURR);
            }
            else if (currentPrev == 2)
            {
                retVal = Util.NumDec(obj.CONST_SR_PREV);
            }
            return retVal;
        }

        public int CONST_GROUP(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            int retVal = 0;

            switch(col)
            {
                case 1:
                    retVal = Util.NumInt(obj.CONST_GROUP1);
                    break;
                case 2:
                    retVal = Util.NumInt(obj.CONST_GROUP2);
                    break;
                case 3:
                    retVal = Util.NumInt(obj.CONST_GROUP3);
                    break;
                case 4:
                    retVal = Util.NumInt(obj.CONST_GROUP4);
                    break;
                case 5:
                    retVal = Util.NumInt(obj.CONST_GROUP5);
                    break;
                case 6:
                    retVal = Util.NumInt(obj.CONST_GROUP6);
                    break;
                case 7:
                    retVal = Util.NumInt(obj.CONST_GROUP7);
                    break;
                case 8:
                    retVal = Util.NumInt(obj.CONST_GROUP8);
                    break;
                case 9:
                    retVal = Util.NumInt(obj.CONST_GROUP9);
                    break;
                case 10:
                    retVal = Util.NumInt(obj.CONST_GROUP10);
                    break;
                case 11:
                    retVal = Util.NumInt(obj.CONST_GROUP11);
                    break;
                case 12:
                    retVal = Util.NumInt(obj.CONST_GROUP12);
                    break;
                case 13:
                    retVal = Util.NumInt(obj.CONST_GROUP13);
                    break;
                case 14:
                    retVal = Util.NumInt(obj.CONST_GROUP14);
                    break;
                case 15:
                    retVal = Util.NumInt(obj.CONST_GROUP15);
                    break;
                case 16:
                    retVal = Util.NumInt(obj.CONST_GROUP16);
                    break;
                case 17:
                    retVal = Util.NumInt(obj.CONST_GROUP17);
                    break;
                case 18:
                    retVal = Util.NumInt(obj.CONST_GROUP18);
                    break;
                case 19:
                    retVal = Util.NumInt(obj.CONST_GROUP19);
                    break;                
            }
            return retVal;
        }

        public void CONST_GROUP_SET(CONSTANTS_MSTR_REC_2 obj, int col, int value)
        {
            switch (col)
            {
                case 1:
                    obj.CONST_GROUP1 = value;
                    break;
                case 2:
                    obj.CONST_GROUP2 = value;
                    break;
                case 3:
                    obj.CONST_GROUP3 = value;
                    break;
                case 4:
                    obj.CONST_GROUP4 = value;
                    break;
                case 5:
                    obj.CONST_GROUP5 = value;
                    break;
                case 6:
                    obj.CONST_GROUP6 = value;
                    break;
                case 7:
                    obj.CONST_GROUP7 = value;
                    break;
                case 8:
                    obj.CONST_GROUP8 = value;
                    break;
                case 9:
                    obj.CONST_GROUP9 = value;
                    break;
                case 10:
                    obj.CONST_GROUP10 = value;
                    break;
                case 11:
                    obj.CONST_GROUP11 = value;
                    break;
                case 12:
                    obj.CONST_GROUP12 = value;
                    break;
                case 13:
                    obj.CONST_GROUP13 = value;
                    break;
                case 14:
                    obj.CONST_GROUP14 = value;
                    break;
                case 15:
                    obj.CONST_GROUP15 = value;
                    break;
                case 16:
                    obj.CONST_GROUP16 = value;
                    break;
                case 17:
                    obj.CONST_GROUP17 = value;
                    break;
                case 18:
                    obj.CONST_GROUP18 = value;
                    break;
                case 19:
                    obj.CONST_GROUP19 = value;
                    break;                
            }
        }
       
        public decimal CONST_RATE_CURR(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            decimal retVal = 0;

            switch(col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR18);
                    break;
                case 19:
                    retVal = Util.NumDec(obj.CONST_RATE_CURR19);
                    break;                
            }
            return retVal;
        }

        public void CONST_RATE_CURR(CONSTANTS_MSTR_REC_2 obj, int col,int value)
        {
            int retVal = 0;

            switch(col)
            {
                case 1:
                    obj.CONST_RATE_CURR1 = value;
                    break;
                case 2:
                    obj.CONST_RATE_CURR2 = value;
                    break;
                case 3:
                    obj.CONST_RATE_CURR3 = value;
                    break;
                case 4:
                    obj.CONST_RATE_CURR4 = value;
                    break;
                case 5:
                    obj.CONST_RATE_CURR5 = value;
                    break;
                case 6:
                    obj.CONST_RATE_CURR6 = value;
                    break;
                case 7:
                    obj.CONST_RATE_CURR7 = value;
                    break;
                case 8:
                    obj.CONST_RATE_CURR8 = value;
                    break;
                case 9:
                    obj.CONST_RATE_CURR9 = value;
                    break;
                case 10:
                    obj.CONST_RATE_CURR10 = value;
                    break;
                case 11:
                    obj.CONST_RATE_CURR11 = value;
                    break;
                case 12:
                    obj.CONST_RATE_CURR12 = value;
                    break;
                case 13:
                    obj.CONST_RATE_CURR13 = value;
                    break;
                case 14:
                    obj.CONST_RATE_CURR14 = value;
                    break;
                case 15:
                    obj.CONST_RATE_CURR15 = value;
                    break;
                case 16:
                    obj.CONST_RATE_CURR16 = value;
                    break;
                case 17:
                    obj.CONST_RATE_CURR17 = value;
                    break;
                case 18:
                    obj.CONST_RATE_CURR18 = value;
                    break;
                case 19:
                    obj.CONST_RATE_CURR19 = value;
                    break;                
            }
        }

        public decimal CONST_RATE_PREV(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            decimal retVal = 0;

            switch(col)
            {
                case 1:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV1);
                    break;
                case 2:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV2);
                    break;
                case 3:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV3);
                    break;
                case 4:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV4);
                    break;
                case 5:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV5);
                    break;
                case 6:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV6);
                    break;
                case 7:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV7);
                    break;
                case 8:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV8);
                    break;
                case 9:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV9);
                    break;
                case 10:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV10);
                    break;
                case 11:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV11);
                    break;
                case 12:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV12);
                    break;
                case 13:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV13);
                    break;
                case 14:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV14);
                    break;
                case 15:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV15);
                    break;
                case 16:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV16);
                    break;
                case 17:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV17);
                    break;
                case 18:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV18);
                    break;
                case 19:
                    retVal = Util.NumDec(obj.CONST_RATE_PREV19);
                    break;                
            }
            return retVal;
        }

        public void CONST_RATE_PREV(CONSTANTS_MSTR_REC_2 obj, int col, int value)
        {
            switch(col)
            {
                case 1:
                    obj.CONST_RATE_PREV1 = value;
                    break;
                case 2:
                    obj.CONST_RATE_PREV2 = value;
                    break;
                case 3:
                    obj.CONST_RATE_PREV3 = value;
                    break;
                case 4:
                    obj.CONST_RATE_PREV4 = value;
                    break;
                case 5:
                    obj.CONST_RATE_PREV5 = value;
                    break;
                case 6:
                    obj.CONST_RATE_PREV6 = value;
                    break;
                case 7:
                    obj.CONST_RATE_PREV7 = value;
                    break;
                case 8:
                    obj.CONST_RATE_PREV8 = value;
                    break;
                case 9:
                    obj.CONST_RATE_PREV9 = value;
                    break;
                case 10:
                    obj.CONST_RATE_PREV10 = value;
                    break;
                case 11:
                    obj.CONST_RATE_PREV11 = value;
                    break;
                case 12:
                    obj.CONST_RATE_PREV12 = value;
                    break;
                case 13:
                    obj.CONST_RATE_PREV13 = value;
                    break;
                case 14:
                    obj.CONST_RATE_PREV14 = value;
                    break;
                case 15:
                    obj.CONST_RATE_PREV15 = value;
                    break;
                case 16:
                    obj.CONST_RATE_PREV16 = value;
                    break;
                case 17:
                    obj.CONST_RATE_PREV17 = value;
                    break;
                case 18:
                    obj.CONST_RATE_PREV18 = value;
                    break;
                case 19:
                    obj.CONST_RATE_PREV19 = value;
                    break;                
            }
        }
        public void CLMDTL_SV_NBR_Set(F002_CLAIMS_MSTR_DTL obj, int col, string value)
        {
            StringBuilder sb;
            switch (col)
            {
                case 1:
                    //obj.CLMDTL_SV_NBR_1 = value;                    
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[0] = Convert.ToChar(value);
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
                case 2:
                    // obj.CLMDTL_SV_NBR_2 = value;
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[3] = Convert.ToChar(value);
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
                case 3:
                    // obj.CLMDTL_SV_NBR_3 = value;
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[6] = Convert.ToChar(value);
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
            }
        }

        public string CLMDTL_SV_NBR(F002_CLAIMS_MSTR_DTL obj, int col)
        {
            string retVal = "0";
            switch (col)
            {
                case 1:
                    //retVal = Util.NumInt(obj.CLMDTL_SV_NBR_1);  //Util.NumInt(obj.CLMDTL_SV_NBR1);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(0, 1);
                    break;
                case 2:
                    //retVal = Util.NumInt(obj.CLMDTL_SV_NBR_2);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(3, 1);
                    break;
                case 3:
                    //retVal = Util.NumInt(obj.CLMDTL_SV_NBR_3);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(6, 1);
                    break;
            }
            return retVal;
        }

        public void CLMDTL_SV_DAY_Set(F002_CLAIMS_MSTR_DTL obj, int col, string value)
        {
            StringBuilder sb;
            switch (col)
            {
                case 1:
                    //obj.CLMDTL_SV_DAY_1 = value;
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[1] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(0, 1));
                    sb[2] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(1, 1));
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
                case 2:
                    //obj.CLMDTL_SV_DAY_2 = value;
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[3] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(0, 1));
                    sb[4] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(1, 1));
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
                case 3:
                    //obj.CLMDTL_SV_DAY_3 = value;
                    sb = new StringBuilder(Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9));
                    sb[5] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(0, 1));
                    sb[6] = Convert.ToChar(Util.Str(value).PadLeft(2).Substring(1, 1));
                    obj.CLMDTL_CONSEC_DATES_R = sb.ToString();
                    break;
            }
        }

        public string CLMDTL_SV_DAY(F002_CLAIMS_MSTR_DTL obj, int col)
        {
            string retVal = string.Empty;
            switch (col)
            {
                case 1:
                    //retVal = Util.Str(obj.CLMDTL_SV_DAY_1);  //Util.Str(obj.CLMDTL_SV_DAY1);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(1, 2);
                    break;
                case 2:
                    //retVal = Util.Str(obj.CLMDTL_SV_DAY_2);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(4, 2);
                    break;
                case 3:
                    //retVal = Util.Str(obj.CLMDTL_SV_DAY_3);
                    retVal = Util.Str(obj.CLMDTL_CONSEC_DATES_R).PadRight(9).Substring(7, 2);
                    break;
            }
            return retVal;
        }

        public void CONST_WCB_SET(CONSTANTS_MSTR_REC_2 obj, int currentPrev, decimal value)
        {
            if (currentPrev == 1)
            {
                obj.CONST_WCB_CURR = value;
            }
            else if (currentPrev == 2 )
            {
                obj.CONST_WCB_PREV = value;
            }
        }

        public decimal CONST_WCB_GET(CONSTANTS_MSTR_REC_2 obj, int currentPrev)
        {
            decimal retVal = 0;

            if (currentPrev == 1)
            {
                retVal = Util.NumDec(obj.CONST_WCB_CURR);
            }
            else if (currentPrev == 2)
            {
                retVal = Util.NumDec(obj.CONST_WCB_PREV);
            }
            return retVal;
        }

        public void CONST_EFFECTIVE_DATE_YY_SET(CONSTANTS_MSTR_REC_2 obj, int col, int value)
        {
            switch (col)
            {
                case 1:   // current
                    obj.CONST_YY_CURR = value;
                    break;
                case 2:  // previous
                    obj.CONST_YY_PREV = value;
                    break;
            }
        }

        public void CONST_EFFECTIVE_DATE_MM_SET(CONSTANTS_MSTR_REC_2 obj, int col, int value)
        {
            switch (col)
            {
                case 1:   // current
                    obj.CONST_MM_CURR = value;
                    break;
                case 2:  // previous
                    obj.CONST_MM_PREV = value;
                    break;
            }
        }

        public void CONST_EFFECTIVE_DATE_DD_SET(CONSTANTS_MSTR_REC_2 obj, int col, int value)
        {
            switch (col)
            {
                case 1:   // current
                    obj.CONST_DD_CURR = value;
                    break;
                case 2:  // previous
                    obj.CONST_DD_PREV = value;
                    break;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_1_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_FEE_1 = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_FEE_1 = value;
            }
            else if ( row == 2 && col == 1)
            {
                obj.FEE_PREV_A_FEE_1 = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_FEE_1 = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_2_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_FEE_2 = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_FEE_2 = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_A_FEE_2 = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_FEE_2 = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Min_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_MIN = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_MIN = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_A_MIN = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_MIN = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Max_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_MAX = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_MAX = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_A_MAX = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_MAX = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_ANAE = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_ANAE = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_A_ANAE = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_ANAE = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_SET(F040_OMA_FEE_MSTR obj, int row, int col, decimal value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_A_ASST = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_H_ASST = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_A_ASST = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_H_ASST = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_SET(F040_OMA_FEE_MSTR obj, int row, int col, string value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_ADD_ON_CD1 = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_ADD_ON_CD2 = value;
            }
            else if (row == 1 && col == 3)
            {
                obj.FEE_CURR_ADD_ON_CD3 = value;
            }
            else if (row == 1 && col == 4)
            {
                obj.FEE_CURR_ADD_ON_CD4 = value;
            }
            else if (row == 1 && col == 5)
            {
                obj.FEE_CURR_ADD_ON_CD5 = value;
            }
            else if (row == 1 && col == 6)
            {
                obj.FEE_CURR_ADD_ON_CD6 = value;
            }
            else if (row == 1 && col == 7)
            {
                obj.FEE_CURR_ADD_ON_CD7 = value;
            }
            else if (row == 1 && col == 8)
            {
                obj.FEE_CURR_ADD_ON_CD8 = value;
            }
            else if (row == 1 && col == 9)
            {
                obj.FEE_CURR_ADD_ON_CD9 = value;
            }
            else if (row == 1 && col == 10)
            {
                obj.FEE_CURR_ADD_ON_CD10 = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_ADD_ON_CD1 = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_ADD_ON_CD2 = value;
            }
            else if (row == 2 && col == 3)
            {
                obj.FEE_PREV_ADD_ON_CD3 = value;
            }
            else if (row == 2 && col == 4)
            {
                obj.FEE_PREV_ADD_ON_CD4 = value;
            }
            else if (row == 2 && col == 5)
            {
                obj.FEE_PREV_ADD_ON_CD5 = value;
            }
            else if (row == 2 && col == 6)
            {
                obj.FEE_PREV_ADD_ON_CD6 = value;
            }
            else if (row == 2 && col == 7)
            {
                obj.FEE_PREV_ADD_ON_CD7 = value;
            }
            else if (row == 2 && col == 8)
            {
                obj.FEE_PREV_ADD_ON_CD8 = value;
            }
            else if (row == 2 && col == 9)
            {
                obj.FEE_PREV_ADD_ON_CD9 = value;
            }
            else if (row == 2 && col == 10)
            {
                obj.FEE_PREV_ADD_ON_CD10 = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Requireds_SET(F040_OMA_FEE_MSTR obj, int row, int col, string value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED1 = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED2 = value;
            }
            else if (row == 1 && col == 3)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED3 = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED1 = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED2 = value;
            }
            else if (row == 2 && col == 3)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED3 = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Required_SET(F040_OMA_FEE_MSTR obj, int row,  int col, string value)
        {
            if (row == 1 && col == 1)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED1 = value;
            }
            else if (row == 1 && col == 2)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED2 = value;
            }
            else if (row == 1 && col == 3)
            {
                obj.FEE_CURR_OMA_IND_CARD_REQUIRED3 = value;
            }
            else if (row == 2 && col == 1)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED1 = value;
            }
            else if (row == 2 && col == 2)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED2 = value;
            }
            else if (row == 2 && col == 3)
            {
                obj.FEE_PREV_OMA_IND_CARD_REQUIRED3 = value;
            }
        }

        public void FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flag_Ind_SET(F040_OMA_FEE_MSTR obj, int row,  string value)
        {
            
            switch(row)
            {
                case 1:
                    obj.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = value;
                    break;
                case 2:
                    obj.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = value;
                    break;
            }
        }

        public int CONST_EFFECTIVE_DATE_YY_GET(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            int retVal = 0;
            switch (col)
            {
                case 1:   // current
                    retVal = Util.NumInt(obj.CONST_YY_CURR);
                    break;
                case 2:  // previous
                    retVal = Util.NumInt(obj.CONST_YY_PREV);
                    break;
            }
            return retVal;
        }

        public int CONST_EFFECTIVE_DATE_MM_GET(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            int retVal = 0;
            switch (col)
            {
                case 1:   // current
                    retVal = Util.NumInt(obj.CONST_MM_CURR);
                    break;
                case 2:  // previous
                    retVal = Util.NumInt(obj.CONST_MM_PREV);
                    break;
            }
            return retVal;
        }

        public int CONST_EFFECTIVE_DATE_DD_GET(CONSTANTS_MSTR_REC_2 obj, int col)
        {
            int retVal = 0;
            switch (col)
            {
                case 1:   // current
                    retVal = Util.NumInt(obj.CONST_DD_CURR);
                    break;
                case 2:  // previous
                    retVal = Util.NumInt(obj.CONST_DD_PREV);
                    break;
            }
            return retVal;
        }


        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_1_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            // GW2019. Jan 27. Scaling

            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_CURR_A_FEE_1) / 10;  //mw
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_CURR_H_FEE_1) / 10;  //mw
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_PREV_A_FEE_1) / 10;  //mw
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_PREV_H_FEE_1) / 10;  //mw
            }
            return retVal;
        }

        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_2_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_CURR_A_FEE_2) / 10;  //mw
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_CURR_H_FEE_2) / 10;  //mw
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_PREV_A_FEE_2) /10;  //mw
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_PREV_H_FEE_2) /10;  //mw
            }
            return retVal;
        }

        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_Min_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_CURR_A_MIN);
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_CURR_H_MIN);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_PREV_A_MIN);
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_PREV_H_MIN);
            }
            return retVal;
        }

        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_Max_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_CURR_A_MAX);
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_CURR_H_MAX);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_PREV_A_MAX);
            }
            else if (row == 2 && col == 2)
            {
               retVal = Util.NumDec(obj.FEE_PREV_H_MAX);
            }
            return retVal;
        }

        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_Anae_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal =  Util.NumDec(obj.FEE_CURR_A_ANAE);
            }
            else if (row == 1 && col == 2)
            {
                retVal =  Util.NumDec(obj.FEE_CURR_H_ANAE);
            }
            else if (row == 2 && col == 1)
            {
                retVal =  Util.NumDec(obj.FEE_PREV_A_ANAE);
            }
            else if (row == 2 && col == 2)
            {
               retVal =  Util.NumDec(obj.FEE_PREV_H_ANAE);
            }
            return retVal;
        }

        public decimal FEE_CURRENT_PREVIOUS_YEARS_Fee_Asst_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            decimal retVal = 0;
            if (row == 1 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_CURR_A_ASST);
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.NumDec(obj.FEE_CURR_H_ASST);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.NumDec(obj.FEE_PREV_A_ASST);
            }
            else if (row == 2 && col == 2)
            {
                retVal =  Util.NumDec(obj.FEE_PREV_H_ASST);
            }
            return retVal;
        }

        public string FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_GET(F040_OMA_FEE_MSTR obj, int row, int col )
        {
            string retVal = string.Empty;
            if (row == 1 && col == 1)
            {
                retVal =  Util.Str(obj.FEE_CURR_ADD_ON_CD1);
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD2);
            }
            else if (row == 1 && col == 3)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD3);
            }
            else if (row == 1 && col == 4)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD4);
            }
            else if (row == 1 && col == 5)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD5);
            }
            else if (row == 1 && col == 6)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD6);
            }
            else if (row == 1 && col == 7)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD7);
            }
            else if (row == 1 && col == 8)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD8);
            }
            else if (row == 1 && col == 9)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD9);
            }
            else if (row == 1 && col == 10)
            {
                retVal = Util.Str(obj.FEE_CURR_ADD_ON_CD10);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD1);
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD2);
            }
            else if (row == 2 && col == 3)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD3);
            }
            else if (row == 2 && col == 4)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD4);
            }
            else if (row == 2 && col == 5)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD5);
            }
            else if (row == 2 && col == 6)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD6);
            }
            else if (row == 2 && col == 7)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD7);
            }
            else if (row == 2 && col == 8)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD8);
            }
            else if (row == 2 && col == 9)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD9);
            }
            else if (row == 2 && col == 10)
            {
                retVal = Util.Str(obj.FEE_PREV_ADD_ON_CD10);
            }
            return retVal;
        }

        public string FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Requireds_GET(F040_OMA_FEE_MSTR obj, int row, int col )
        {
            string retVal = string.Empty;
            if (row == 1 && col == 1)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED1); 
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            }
            else if (row == 1 && col == 3)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED3);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            }
            else if (row == 2 && col == 3)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED3);
            }
            return retVal;
        }

        public string FEE_CURRENT_PREVIOUS_YEARS_Fee_Add_On_Perc_Or_Flat_Ind_GET(F040_OMA_FEE_MSTR obj, int row )
        {
            string retVal = string.Empty;
            switch (row)
            {
                case 1:
                    retVal =  Util.Str(obj.FEE_CURR_ADD_ON_PERC_OR_FLAT_IND);
                    break;
                case 2:
                    retVal = Util.Str(obj.FEE_PREV_ADD_ON_PERC_OR_FLAT_IND);
                    break;
            }
            return retVal;
        }

        public string FEE_CURRENT_PREVIOUS_YEARS_Fee_Oma_Ind_Card_Required_GET(F040_OMA_FEE_MSTR obj, int row, int col)
        {
            string retVal = string.Empty;

            if (row == 1 && col == 1)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED1);
            }
            else if (row == 1 && col == 2)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED2);
            }
            else if (row == 1 && col == 3)
            {
                retVal = Util.Str(obj.FEE_CURR_OMA_IND_CARD_REQUIRED3);
            }
            else if (row == 2 && col == 1)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED1);
            }
            else if (row == 2 && col == 2)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED2);
            }
            else if (row == 2 && col == 3)
            {
                retVal = Util.Str(obj.FEE_PREV_OMA_IND_CARD_REQUIRED3);
            }

            return retVal;
        }

        #endregion



    }
}
