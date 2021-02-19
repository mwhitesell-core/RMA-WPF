using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RmaDAL;

namespace rma.Cobol.Reports
{
    public  class CommonFunction
    {
        #region r123_bank_info.ws
        //  77   ws-nbr-settlement-accounts pic 99          value 4.
        public   int ws_nbr_settlement_accounts;


        //77   ws-settlement-account-1      pic x(12)       value "7701918     ".
        public   string ws_settlement_account_1 = "7701918     ";
        //77   ws-institution-id-1          pic 9(9)        value 001000562.  
        public   long ws_institution_id_1 = 001000562;
        //77   ws-settlement-account-2      pic x(12)       value "1172611     ".
        public   string ws_settlement_account_2 = "1172611     ";
        //77   ws-institution-id-2          pic 9(9)        value 001000062.  
        public   long ws_institution_id_2 = 001000062;

        //77   ws-settlement-account-3      pic x(12)       value "9594213     ".
        public   string ws_settlement_account_3 = "9594213     ";

        //77   ws-institution-id-3          pic 9(9)        value 001000062.
        public   long ws_institution_id_3 = 001000062;

        //77   ws-settlement-account-4      pic x(12)       value "9079319     ".
        public   string ws_settlement_account_4 = "9079319     ";
        //77   ws-institution-id-4          pic 9(9)        value 001000062.
        public   long ws_institution_id_4 = 001000062;

        //01   ws-settlement-account pic x(12).
        public   string ws_settlement_account;
        //01   ws-account-return		pic x(12).  
        public   string ws_account_return;
        //01   ws-institution-id.
        public   string ws_institution_id_grp;
        //05  ws-bank-nbr-id pic 9(4).
        public   int ws_bank_nbr_id_child;
        // 05  ws-bank-branch-id pic 9(5).
        public   int ws_bank_branch_id_child;

        //01   ws-institution-return.  
        public   string ws_institution_return_grp;
        //05  ws-bank-nbr-return     pic 9(4).
        public   int ws_bank_nbr_return_child;
        //05  ws-bank-branch-return 	pic 9(5).
        public   long ws_bank_branch_return_child;


        //77   ws-dest-data-centre pic 9(5)        value 01020.  
        public   int ws_dest_data_centre = 01020;
        //77   ws-short-name pic x(15)       value "  R. M. A.    ".     
        public   string ws_short_name = "  R. M. A.    ";
        // 77   ws-long-name pic x(30)       value " Regional Medical Associates  ".
        public   string ws_long_name = " Regional Medical Associates  ";

        //01   ws-originator-numbers.
        public   string ws_originator_numbers_grp;
        //05  ws-originator-nbr-clinic-22  pic x(10)       value "0102024944".
        public   string ws_originator_nbr_clinic_22_child = "0102024944";
        // 05  ws-originator-nbr-clinic-81  pic x(10)       value "0102006210".
        public   string ws_originator_nbr_clinic_81_child = "0102006210";
        // 05  ws-originator-nbr-clinic-85  pic x(10)       value "0102018480".
        public   string ws_originator_nbr_clinic_85_child = "0102018480";
        // 05  ws-originator-nbr-clinic-mp pic x(10)       value "0102007764".
        public   string ws_originator_nbr_clinic_mp_child = "0102007764";

        //01   ws-file-creation-nbr pic 9(4)        value 1.
        public   int ws_file_creation_nbr = 1;

        #endregion

        #region Sysdatetime.ws
        //01 century-year pic 9(4).
        public   int century_year;
        // 01 century-date pic 9(8).
        public   long century_date;
        // 01 default-century-cc pic 9(2) value 19.
        public   int default_century_cc = 19;
        //01 default-century-cccc pic 9(4) value 1900.
        public   int default_century_cccc = 1900;


        //01  sys-date.        
        public   string sys_date_grp;
        //05  sys-date-long pic x(8).    
        public   string sys_date_long_child;
        // 05  sys-date-long-r redefines  sys-date-long. 
        public   string sys_date_long_r_child_redefines;
        // 10  sys-yy pic 9999. 
        public   int sys_yy_child;
        // 10  sys-yy-alpha redefines  sys-yy.
        public   string sys_yy_alpha_child_redefines;
        // 15  sys-y1 pic 9. 
        public   int sys_y1_child;
        // 15  sys-y2 pic 9. 
        public   int sys_y2_child;
        // 15  sys-y3 pic 9. 
        public   int sys_y3_child;
        // 15  sys-y4 pic 9. 
        public   int sys_y4_child;
        // 10  sys-mm pic 99. 
        public   int sys_mm_child;
        // 10  sys-dd pic 99. 
        public   int sys_dd_child;

        //01  sys-date-numeric redefines sys-date pic 9(8).
        public   string sys_date_numeric_redefines;
        //01  sys-date-y2kfix redefines sys-date.
        public   string sys_date_y2kfix_grp_redefines;
        //05 sys-date-left pic x(6).
        public   string sys_date_left_child;
        // 05 filler pic x(2).
        //public string filler_child;
        //01  sys-date-y2kfixed redefines sys-date.
        public   string sys_date_y2kfixed_grp_redefines;
        //05 sys-date-blank pic x(2).
        public   string sys_date_blank_child;
        // 05 sys-date-right pic x(6).
        public   string sys_date_right_child;
        //01  sys-date-temp pic x(8).
        public   string sys_date_temp;

        //01  run-date.        
        public string run_date_grp; // = run_yy_child.ToString() + "/" + run_mm_child.ToString() + "/" + run_dd_child.ToString();
        // 05  run-yy pic 9999. 
        public   int run_yy_child;
        // 05  filler pic x value "/".         
        //    05  run-mm pic 99. 
        public   int run_mm_child;
        // 05  filler pic x value "/". 
        //05  run-dd pic 99. 
        public   int run_dd_child;

        //01  sys-time.
        public   string sys_time_grp;
        // 05  sys-hrs pic 99. 
        public   int sys_hrs_child;
        // 05  sys-min pic 99. 
        public   int sys_min_child;
        // 05  sys-sec pic 99. 
        public   int sys_sec_child;
        // 05  sys-hdr pic 99. 
        public   int sys_hdr_child;

        // 01  run-time.
        public string run_time_grp; // = run_hrs_child.ToString() + ":" + run_min_child.ToString() + ":" + run_sec_child.ToString();
        // 05  run-hrs pic 99. 
        public   int run_hrs_child;
        // 05  filler pic x value ":". 
        public   string filler = ":";
        // 05  run-min pic 99. 
        public   int run_min_child;
        // 05  filler pic x value ":". 
        //  05  run-sec pic 99. 
        public   int run_sec_child;
        #endregion

        #region Misc CHQ
        // Misc
        public   decimal CHQ_REG_MTH_MISC_AMT(F060_CHEQUE_REG_MSTR obj, int row, int col)
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
