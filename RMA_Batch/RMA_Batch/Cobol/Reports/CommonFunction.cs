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
using System.ComponentModel;
using System.Collections.ObjectModel;
using rma.Cobol;
using RmaDAL;


namespace rma.Cobol
{
    public  class CommonFunction: BaseClassControl 
    {
        protected bool isBatchProcess;
        public CommonFunction(string Name, int Level) : base(Name,Level)
        {
            this.ScreenType = ScreenTypes.QTP;
        }

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

        #region InputAndOutputFiles
        public  string AppConfigValueGet(string appKey)
        {
            string appValue = System.Configuration.ConfigurationManager.AppSettings[appKey];

            if (!appValue.Substring(appValue.Length - 1).Equals("\\"))
            {
                appValue += "\\";
            }

            return appValue;
        }
        public ObservableCollection<U119_payeft_rec> Read_U119_Payeft_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\U119_PAYEFT.ps";            
            string line = string.Empty;

            ObservableCollection<U119_payeft_rec> U119_payeft_rec_Collection = new ObservableCollection<U119_payeft_rec>();
            using (StreamReader file = new StreamReader(filePath))
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
               /* int ctr = 0;

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
                } */
            }
            return U119_payeft_rec_Collection;
        }

        public ObservableCollection<U119_chgeft_rec>Read_119_Chgeft_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\U119_CHGEFT.ps";
            string line = string.Empty;

            ObservableCollection<U119_chgeft_rec> U119_chgeft_rec_Collection = new ObservableCollection<U119_chgeft_rec>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null) {
                    U119_chgeft_rec objU119_chgeft_rec = null;
                    objU119_chgeft_rec = new U119_chgeft_rec();
                    objU119_chgeft_rec.w_doc_nbr = line.Substring(0, 3);
                    objU119_chgeft_rec.filler_sign2 = line.Substring(3, 1);                    
                    objU119_chgeft_rec.w_doc_dept = Util.NumInt(line.Substring(4, 2));
                    objU119_chgeft_rec.filler_sign = line.Substring(6, 1);
                    objU119_chgeft_rec.w_chgeft_amt_n = Util.NumDec(line.Substring(7));
                    U119_chgeft_rec_Collection.Add(objU119_chgeft_rec);
                 } 

               /* int ctr = 0;
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
                } */ 

            }
            return U119_chgeft_rec_Collection;
        } 

        public int Eft_Constant_File_Read()
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\eft_constant";
            if (Util.DebugUsingLocalMachine())
            {
                filePath = Directory.GetCurrentDirectory() + "\\eft_constant";
            }
            
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
            if (Util.DebugUsingLocalMachine())
            {
                filePath = Directory.GetCurrentDirectory() + "\\eft_constant";
            }

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(value.ToString().PadLeft(4, '0'));
            }
        }

        public int Eft_Constant_Debit_File_Read()
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\eft_constant_debit";
            if (Util.DebugUsingLocalMachine())
            {
                filePath = Directory.GetCurrentDirectory() + "\\eft_constant_debit";
            }

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

        public void Eft_Contant_Debit_File_Rewrite(int value)
        {
            string filePath = Environment.GetEnvironmentVariable("pb_data") + "\\eft_constant_debit";
            if (Util.DebugUsingLocalMachine())
            {
                filePath = Directory.GetCurrentDirectory() + "\\eft_constant_debit";
            }

            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(value.ToString().PadLeft(4, '0'));
            }
        }


        public ObservableCollection<Rat_record_1> Read_U030_OHIP_RAT_TAPE_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\ohip_rat_ascii";
            string line = string.Empty;

            ObservableCollection<Rat_record_1> U030_OHIP_RAT_TAPE_Collection = null;
            U030_OHIP_RAT_TAPE_Collection = new ObservableCollection<Rat_record_1>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    line = line.PadRight(80);
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
                        objRat_record_1.Rat_1_group_nbr = line.Substring(7, 4);
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
                        objRat_record_5.Rat_5_service_cd = line.Substring(25, 5);
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
                        objRat_record_7.Rat_7_filler = line.Substring(73, 4);

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
                    objAfp_record.Afp_record_data = line.Substring(0, 132);  // todo ???
                    objAfp_record.Afp_cr = line.Substring(132, 1);    // todo ?? 

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

        public ObservableCollection<Eft_record_type_a> Read_Workfile_a_SequentialFile()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\work_file_a.txt";
            string line = string.Empty;

            ObservableCollection<Eft_record_type_a> Eft_record_type_a_Collection = null;
            Eft_record_type_a_Collection = new ObservableCollection<Eft_record_type_a>();

            using (StreamReader file = new StreamReader(filePath))
            {
                while((line = file.ReadLine()) != null)
                {
                  if (line.Substring(0,1).ToUpper().Equals("A"))
                  {                        
                        Eft_record_type_a objEft_record_type_a = null;
                        objEft_record_type_a = new Eft_record_type_a();

                        //Util.Str(objEft_record_type_a.a_01_record_type).PadRight(1, ' ') 
                        objEft_record_type_a.a_01_record_type = line.Substring(0, 1);
                        //objEft_record_type_a.a_02_record_count.ToString().PadLeft(9, '0') 
                        objEft_record_type_a.a_02_record_count = Util.NumLongInt(line.Substring(1, 9));
                        //Util.Str(objEft_record_type_a.a_03_originator_number).PadRight(10, ' ') 
                        objEft_record_type_a.a_03_originator_number = line.Substring(10, 10);
                        //objEft_record_type_a.a_04_file_creation_number.ToString().PadLeft(4, '0') 
                        objEft_record_type_a.a_04_file_creation_number = Util.NumInt(line.Substring(20, 4));
                        //objEft_record_type_a.a_05_creation_date.ToString().PadLeft(6, '0') +
                        objEft_record_type_a.a_05_creation_date = Util.NumLongInt(line.Substring(24, 6));
                        //objEft_record_type_a.a_06_destination_data_centre.ToString().PadLeft(5, '0') +
                        objEft_record_type_a.a_06_destination_data_centre = Util.NumLongInt(line.Substring(30, 5));
                        //Util.Str(objEft_record_type_a.a_07_filler).PadRight(1213, ' ') +
                        objEft_record_type_a.a_07_filler = line.Substring(35, 1213);
                        //objEft_record_type_a.a_08_version_number.ToString().PadLeft(4, '0') +
                        objEft_record_type_a.a_08_version_number = Util.NumInt(line.Substring(1248, 4));
                        //objEft_record_type_a.a_09_settlement_account.ToString().PadLeft(2, '0') +
                        objEft_record_type_a.a_09_settlement_account = Util.NumInt(line.Substring(1252, 2));
                        //objEft_record_type_a.institution_id_child[1].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[1] = Util.NumLongInt(line.Substring(1254, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[1]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[1] = line.Substring(1263,12);
                        //objEft_record_type_a.institution_id_child[2].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[2] = Util.NumLongInt(line.Substring(1275, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[2]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[2] = line.Substring(1284, 12);
                        //objEft_record_type_a.institution_id_child[3].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[3] = Util.NumLongInt(line.Substring(1296, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[3]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[3] = line.Substring(1305, 12);
                        //objEft_record_type_a.institution_id_child[4].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[4] = Util.NumLongInt(line.Substring(1317, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[4]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[4] = line.Substring(1326, 12);
                        //objEft_record_type_a.institution_id_child[5].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[5] = Util.NumLongInt(line.Substring(1338, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[5]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[5] = line.Substring(1347, 12);
                        //objEft_record_type_a.institution_id_child[6].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[6] = Util.NumLongInt(line.Substring(1359, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[6]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[6] = line.Substring(1368, 12);
                        //objEft_record_type_a.institution_id_child[7].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[7] = Util.NumLongInt(line.Substring(1380, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[7]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[7] = line.Substring(1389, 12);
                        //objEft_record_type_a.institution_id_child[8].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[8] = Util.NumLongInt(line.Substring(1401, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[8]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[8] = line.Substring(1410, 12);
                        //objEft_record_type_a.institution_id_child[9].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[9] = Util.NumLongInt(line.Substring(1422, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[9]).PadRight(12, ' ') +
                        objEft_record_type_a.settlement_account_child[9] = line.Substring(1431, 12);
                        //objEft_record_type_a.institution_id_child[10].ToString().PadLeft(9, '0') +
                        objEft_record_type_a.institution_id_child[10] = Util.NumLongInt(line.Substring(1443, 9));
                        //Util.Str(objEft_record_type_a.settlement_account_child[10]).PadRight(12, ' ');
                        objEft_record_type_a.settlement_account_child[10] = line.Substring(1452, 12);

                        Eft_record_type_a_Collection.Add(objEft_record_type_a);
                    }    
                  else if (line.Substring(0,1).ToUpper().Equals("C"))
                  {
                        Eft_record_type_a objEft_record_type_a = null;
                        objEft_record_type_a = new Eft_record_type_a();
                        // Util.Str(objEft_record_type_c.c_01_record_type).PadRight(1, ' ') +
                        objEft_record_type_a.a_01_record_type = line.Substring(0, 1);
                        //objEft_record_type_c.c_02_record_count.ToString().PadLeft(9, '0') +
                        objEft_record_type_a.a_02_record_count = Util.NumLongInt(line.Substring(1, 9));
                        //Util.Str(objEft_record_type_c.c_03_originator_nbr).PadRight(10, ' ') +
                        objEft_record_type_a.a_03_originator_number = line.Substring(10, 10);

                        Eft_record_type_c objEft_record_type_c = null;
                        objEft_record_type_c = new Eft_record_type_c();

                        // Util.Str(objEft_record_type_c.c_01_record_type).PadRight(1, ' ') +
                        objEft_record_type_c.c_01_record_type = line.Substring(0, 1);
                        //objEft_record_type_c.c_02_record_count.ToString().PadLeft(9, '0') +
                        objEft_record_type_c.c_02_record_count = Util.NumLongInt(line.Substring(1, 9));
                        //Util.Str(objEft_record_type_c.c_03_originator_nbr).PadRight(10, ' ') +
                        objEft_record_type_c.c_03_originator_nbr = line.Substring(10, 10);
                        //objEft_record_type_c.c_03_file_creation_nbr.ToString().PadLeft(4, '0') +
                        objEft_record_type_c.c_03_file_creation_nbr = Util.NumInt(line.Substring(20, 4));
                        //objEft_record_type_c.c_04_transaction_type.ToString().PadLeft(3, '0') +
                        objEft_record_type_c.c_04_transaction_type = Util.NumInt(line.Substring(24, 3));
                        //objEft_record_type_c.c_05_amount.ToString().PadLeft(10, '0') +   // 9(8)v99
                        objEft_record_type_c.c_05_amount = Util.NumDec(line.Substring(27, 10));
                        //objEft_record_type_c.c_06_fund_available_date.ToString().PadLeft(6, '0') +
                        objEft_record_type_c.c_06_fund_available_date =  Util.NumLongInt(line.Substring(37, 6));
                        //objEft_record_type_c.c_07_bank_nbr.ToString().PadLeft(9, '0') +
                        objEft_record_type_c.c_07_bank_nbr = Util.NumLongInt(line.Substring(43, 9));
                        //Util.Str(objEft_record_type_c.c_08_payee_acc_nbr).PadRight(12, ' ') +
                        objEft_record_type_c.c_08_payee_acc_nbr = line.Substring(52, 12);
                        //Util.Str(objEft_record_type_c.c_09_reserved).PadRight(22, ' ') +
                        objEft_record_type_c.c_09_reserved = line.Substring(64, 22);
                        //objEft_record_type_c.c_10_stored_trans_type.ToString().PadLeft(3, '0') +
                        objEft_record_type_c.c_10_stored_trans_type = Util.NumInt(line.Substring(86, 3));
                        //Util.Str(objEft_record_type_c.c_11_short_name).PadRight(15, ' ') +
                        objEft_record_type_c.c_11_short_name = line.Substring(89, 15);
                        //Util.Str(objEft_record_type_c.c_12_payee_name).PadRight(30, ' ') +
                        objEft_record_type_c.c_12_payee_name = line.Substring(104, 30);
                        //Util.Str(objEft_record_type_c.c_13_long_name).PadRight(30, ' ') +
                        objEft_record_type_c.c_13_long_name = line.Substring(134, 30);
                        //Util.Str(objEft_record_type_c.c_14_originator_nbr).PadRight(10, ' ') +
                        objEft_record_type_c.c_14_originator_nbr = line.Substring(164, 10);
                        //Util.Str(objEft_record_type_c.c_15_cross_ref_nbr).PadRight(19, ' ') +
                        objEft_record_type_c.c_15_cross_ref_nbr = line.Substring(174, 19);
                        //objEft_record_type_c.c_16_institution_return.ToString().PadLeft(9, '0') +
                        objEft_record_type_c.c_16_institution_return = Util.NumLongInt(line.Substring(193, 9));
                        //Util.Str(objEft_record_type_c.c_17_account_return).PadRight(12, ' ') +
                        objEft_record_type_c.c_17_account_return = line.Substring(202, 12);
                        //Util.Str(objEft_record_type_c.c_18_sundry).PadRight(15, ' ') +
                        objEft_record_type_c.c_18_sundry = line.Substring(214, 15);
                        //Util.Str(objEft_record_type_c.c_19_filler).PadRight(22, ' ') +
                        objEft_record_type_c.c_19_filler = line.Substring(229, 22);
                        //objEft_record_type_c.c_20_settlement_indicator.ToString().PadLeft(2, '0') +
                        objEft_record_type_c.c_20_settlement_indicator = Util.NumInt(line.Substring(251, 2));
                        //objEft_record_type_c.c_21_invalid_indicator.ToString().PadLeft(11, '0') +
                        objEft_record_type_c.c_21_invalid_indicator = Util.NumLongInt(line.Substring(253, 11));
                        //Util.Str(objEft_record_type_c.c_seg_two_six).PadRight(1200, ' '); 
                        objEft_record_type_c.c_seg_two_six = line.Substring(264, 1200);

                        objEft_record_type_a.eft_record_type_c_Reference = objEft_record_type_c;
                        Eft_record_type_a_Collection.Add(objEft_record_type_a);

                    }
                    else if (line.Substring(0,1).ToUpper().Equals("Z"))
                  {
                        Eft_record_type_a objEft_record_type_a = null;
                        objEft_record_type_a = new Eft_record_type_a();

                        //Util.Str(objEft_record_type_z.z_01_record_type).PadRight(1, ' ') +
                        objEft_record_type_a.a_01_record_type = line.Substring(0, 1);
                        //objEft_record_type_z.z_02_record_count.ToString().PadLeft(9, '0') +
                        objEft_record_type_a.a_02_record_count = Util.NumLongInt(line.Substring(1, 9));
                        //Util.Str(objEft_record_type_z.z_03_originator_nbr).PadRight(10, ' ') +
                        objEft_record_type_a.a_03_originator_number = line.Substring(10, 10);

                        Eft_record_type_z objEft_record_type_z = null;
                        objEft_record_type_z = new Eft_record_type_z();

                        //Util.Str(objEft_record_type_z.z_01_record_type).PadRight(1, ' ') +
                        objEft_record_type_z.z_01_record_type = line.Substring(0, 1);
                        //objEft_record_type_z.z_02_record_count.ToString().PadLeft(9, '0') +
                        objEft_record_type_z.z_02_record_count = Util.NumLongInt(line.Substring(1, 9));
                        //Util.Str(objEft_record_type_z.z_03_originator_nbr).PadRight(10, ' ') +
                        objEft_record_type_z.z_03_originator_nbr = line.Substring(10, 10);
                        //objEft_record_type_z.z_03_file_creation_number.ToString().PadLeft(4, '0') +
                        objEft_record_type_z.z_03_file_creation_number = Util.NumInt(line.Substring(20, 4));
                        //objEft_record_type_z.z_04_total_debit_value.ToString().PadLeft(14, '0') +  // 9(12)v99
                        objEft_record_type_z.z_04_total_debit_value = Util.NumDec(line.Substring(24, 14));
                        //objEft_record_type_z.z_05_total_debit_nbr.ToString().PadLeft(8, '0') +
                        objEft_record_type_z.z_05_total_debit_nbr = Util.NumLongInt(line.Substring(38, 8));
                        //objEft_record_type_z.z_06_total_credit_value.ToString().PadLeft(14, '0') + // 9(12)v99
                        objEft_record_type_z.z_06_total_credit_value = Util.NumDec(line.Substring(46, 14));
                        //objEft_record_type_z.z_07_total_credit_nbr.ToString().PadLeft(8, '0') +
                        objEft_record_type_z.z_07_total_credit_nbr = Util.NumLongInt(line.Substring(60, 8));
                        //Util.Str(objEft_record_type_z.z_08_filler).PadRight(1396, ' ');
                        objEft_record_type_z.z_08_filler = line.Substring(68, 1396);

                        objEft_record_type_a.eft_record_type_z_Reference = objEft_record_type_z;
                        Eft_record_type_a_Collection.Add(objEft_record_type_a);
                    }
                }
            }

            return Eft_record_type_a_Collection;
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
        #endregion       
       
    }
}
