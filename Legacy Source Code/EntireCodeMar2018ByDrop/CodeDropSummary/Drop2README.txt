NOTES DROP 2
============

*****************************************************************************************
*****************************************************************************************
*****************************************************************************************
******************************* 1 - MOH RA PROCEDURES ***********************************
*****************************************************************************************
*****************************************************************************************
*****************************************************************************************


+ means a command script which is further documented below.

******************************************************************************
$cmd/cleanup_rats
-----------------
- Easy
- Calls a bunch of rm commands to remove data files
******************************************************************************


******************************************************************************
$cmd/delyasr997
---------------
- Calls a number of rm commands to remove data files
******************************************************************************


******************************************************************************
$cmd/rat_copy
-------------
- mv, etc
- cobrun $obj/u030a  << RAT_EXIT
- Called multiple times.
******************************************************************************


******************************************************************************
backup_daily
------------
- Already done Code Drop 1
******************************************************************************


******************************************************************************
$cmd/run_rats
-------------
- batch   << BATCH_EXIT 		
+- calls $cmd/run_rats.com

$cmd/run_rats.com
-----------------
- Calls application_of_rat_xx_part1 (all the same)
+- $cmd/r997_ph_portal_all_clinics
+- $cmd/copy_u030_rec_67 
+- $cmd/r997_clinic_88
+- $cmd/r997_clinic_78
+- $cmd/r997_clinic_69
+- $cmd/rat_dept7 > rat_dept7.log 
+- $cmd/r997_clinic22_84J
+- $cmd/run_after_rat

application_of_rat_xx_part1 					(called by: $cmd/run_rats.com)
---------------------------
+- Calls $cmd/u030 22 1>u030.ls 2>&1 				

$cmd/u030							(called by: application_of_rat_xx_part1)
---------
- qutil 1>/dev/null 2>&1 << QUTIL_EXIT (to create files)
- qtp auto=$obj/u030b_part1.qtc
- qtp auto=$obj/u030b_part2.qtc
- qtp auto=$obj/u030b_60.qtc 
- qtp auto=$obj/u030bb.qtc << QTP_EXIT
- qtp auto=$obj/u030bb_1.qtc << QTP_EXIT2			<<== No Convert?? Check spreadsheet
- cobrun $obj/u030c
+- quiz auto=$obj/r030.qzu
+- $cmd/run_ra_report 1>r997.ls 2>&1
+- $cmd/u030_clinic_dtl_part2
- qtp auto=$obj/unlof002_rat_payment.qtc

quiz auto=$obj/r030.qzu
-----------------------
- Quiz
- exec $obj/r030d1 nogo				(in r030d.qzs)
- select if rat-145-amt-paid ne 0
- go
- exec $obj/r030d2				(in r030d.qzs)
- exec $obj/r030e1				(in r030e.qzs)
- exec $obj/r030e2				(in r030e.qzs)
- exec $obj/r030f1 nogo				(in r030f.qzs)
- heading at part-hdr-claim-id skip
- rep
- footing at part-hdr-claim-id skip
- go
- exec $obj/r030f2				(in r030f.qzs)
- exec $obj/r030h
- exec $obj/r030j


$cmd/run_ra_report						(called by: $cmd/u030)
------------------
- qtp auto=$obj/u997.qtc
+- quiz auto=$obj/r997_35.qzu
- quiz auto=$obj/r997_total.qzc			<<== No convert? Check spreadhseet
- quiz auto=$obj/r997_paid.qzc      

quiz auto=$obj/r997_35.qzu
--------------------------
- exe $obj/r997a
- exe $obj/r997b				(in r997.qzs)
- exe $obj/r997c				(in r997.qzs)
- exe $obj/r997d				(in r997.qzs)
- exe $obj/r997e				(in r997.qzs)
- exe $obj/r997f				(in r997.qzs)
- exe $obj/r997g				(in r997.qzs)
- exe $obj/r997h				(in r997.qzs)
- exe $obj/r997i				(in r997.qzs)
- exe $obj/r997j				(in r997.qzs)
- exe $obj/r997k				(in r997.qzs)


$cmd/u030_clinic_dtl_part2					(called by: $cmd/u030)
--------------------------
- qutil 1>/dev/null 2>&1 << QUTIL_EXIT (create empty file)
- qtp auto=$obj/u030b_autoadj_clinic_dtl.qtc			<<== No convert? Check spreadsheet
- cobrun $obj/u030c
- quiz auto=$obj/r030i_2.qzc
- quiz auto=$obj/r030i_3.qzc

$cmd/r997_ph_portal_all_clinics					(called by: $cmd/run_rats.com)
-------------------------------
- Calls same 2 quizes over and and over for each clinic
- quiz << R997_EXIT  > r997_portal.log
- exec $obj/r997_portal_a					(in r997_portal.qzs)
- exec $obj/r997_portal_b					(in r997_portal.qzs)

$cmd/copy_u030_rec_67 						(called by: $cmd/run_rats.com)
---------------------
- quiz << quiz_exit
- quiz exec $obj/r031a_agep
+- quiz auto=$obj/r031b_agep.qzu

r031b_agep.qzu
--------------
- exec $obj/r031b_agep_1			(in r031b_agep.qzs)
- exec $obj/r031b_agep_2			(in r031b_agep.qzs)

$cmd/r997_clinic_88						(called by: $cmd/run_rats.com)
-------------------
- quiz << quiz_exit
- exec $obj/r997f_summ.qzc			(in r997_summary.qzs)
- exec $obj/r997g_summ.qzc			(in r997_summary.qzs)
- exec $obj/r997k_summ.qzc			(in r997_summary.qzs)
- quiz_exit


$cmd/r997_clinic_78						(called by: $cmd/run_rats.com)
-------------------
- quiz << quiz_exit
- exec $obj/r997f_summ.qzc	<<== same as r997_clinic_88
- exec $obj/r997g_summ.qzc			
- exec $obj/r997k_summ.qzc
- quiz_exit

$cmd/r997_clinic_69						(called by: $cmd/run_rats.com)
-------------------
- quiz << quiz_exit
- exec $obj/r997f_summ.qzc	<<== same as r997_clinic_88
- exec $obj/r997g_summ.qzc
- exec $obj/r997k_summ.qzc
- quiz_exit

$cmd/rat_dept7 > rat_dept7.log 					(called by: $cmd/run_rats.com)
------------------------------
- quiz auto=$obj/r997_portal_ss.qzc  >  r997_portal_ss.log

$cmd/r997_clinic22_84J 						(called by: $cmd/run_rats.com)
----------------------
- quiz << quiz_exit
- exec $obj/r997_clinic22_84J_a			(in r997_clinic22_84J.qzs)
- exec $obj/r997_clinic22_84J_b			(in r997_clinic22_84J.qzs)
- quiz_exit

$cmd/run_after_rat						(called by: $cmd/run_rats.com)
------------------
- qtp auto=$obj/checkf002tech_serv_date.qtc >> checkf002tech_servdate.log
- quiz auto=$src/diffamt.qzs                >> checkf002tech_servdate.log
- quiz auto=$src/diffdate.qzs               >> checkf002tech_servdate.log




******************************************************************************
$cmd/print_rats
---------------
******************************************************************************

+$cmd/application_of_rat_60_part2
+$cmd/application_of_rat_70_part2
+$cmd/appl_of_rat_22_to_48_part2
+$cmd/appl_of_rat_80_to_96_part2

$cmd/application_of_rat_60_part2				(called by:cmd/application_of_rat_60_part2)
--------------------------------
- Lots of mv and lp's


+$cmd/application_of_rat_70_part2
---------------------------------
- Lots of mv and lp's


+$cmd/appl_of_rat_22_to_48_part2
--------------------------------
- Lots of mv and lp's


+$cmd/appl_of_rat_80_to_96_part2
--------------------------------
- Lots of mv and lp's


******************************************************************************
+-$cmd/mohprice
******************************************************************************
- cats commands
- quiz << QUIZ_EXIT
- execute $obj/u030aa3				<<== NoConvert? Check Spreadsheet


******************************************************************************
+-$cmd/backup_rat_files
******************************************************************************
- copies a bunch of files to backup


******************************************************************************
+-$cmd/reload_daily
******************************************************************************
- copies a bunch of files from backup


*****************************************************************************************
*****************************************************************************************
*****************************************************************************************
************************** 2 - MOH GOVENANCE FILE PROCEDURES ****************************
*****************************************************************************************
*****************************************************************************************
*****************************************************************************************

upl - Unix command required.

******************************************************************************
+-$cmd/copy_f114
******************************************************************************
- Already in drop 1


******************************************************************************
+-$cmd/cleanup_governance
******************************************************************************
- Removes files


******************************************************************************
+$cmd/u140_stage1   govmmmyy  
******************************************************************************
+$cmd/u140_stage1.com $1 > u140_stage1.log


+$cmd/u140_stage1.com $1 > u140_stage1.log
------------------------------------------
- qutil << QUTIL_EXIT
-   create file f075-afp-doc-mstr
-   create file tmp-doctor-alpha  
- QUTIL_EXIT
- cobrun $obj/u140
- qtp << QTP_EXIT
-   exec $obj/u140_a.qtc				<<== No Convert? Check spreadsheet
-   A
- QTP_EXIT
- qutil << QUTIL_EXIT
-   create file f075-afp-doc-mstr
-   create file tmp-doctor-alpha  
- QUTIL_EXIT
-   qtp << QTP_EXIT
-   exec $obj/u140_a.qtc
-   C
- QTP_EXIT



******************************************************************************
+$cmd/u140_stage2
******************************************************************************
$cmd/u140_stage2.com $1 > u140_stage2.log


+$cmd/u140_stage2.com
---------------------
+- $cmd/consolidate_u030_paid_amt_subfile
- qtp auto=$obj/u030b_1.qtc


+- $cmd/consolidate_u030_paid_amt_subfile
----------------------------------------
- Appends a bunch of sf files togerther


******************************************************************************
+$cmd/u140_stage3
******************************************************************************
- $cmd/u140_stage3.com $1 > u140_stage3.log

+$cmd/u140_stage3.com
---------------------
- qutil << QUTIL_EXIT
  create file tmp-doctor-alpha
  QUTIL_EXIT
-   qtp  auto=$obj/u140_b.qtc	' determine percentage RA payments '
-   qtp  auto=$obj/u140_c.qtc	' update f075 with a1f payment amt	'
-   qtp  auto=$obj/u140_d.qtc	' divy up AFP payment based upon RA percentage'
- quiz << QUIZ_EXIT
-   exec $obj/r140_a1f.qzc
-   exec $obj/r140_a2g.qzc
-   exec $obj/r140_a2s.qzc
-   exec $obj/r140_a3c.qzc
-   exec $obj/r140_a4t.qzc
- QUIZ_EXIT
- . /macros/setup_rmabill.com solo 
- qutil << QUTIL_EXIT
-   create file tmp-doctor-alpha
- QUTIL_EXIT
-   qtp  auto=$obj/u140_b.qtc	' determine percentage RA payments '
-   qtp  auto=$obj/u140_c.qtc	' update f075 with a1f payment amt	'
-   qtp  auto=$obj/u140_d.qtc	' divy up AFP payment based upon RA percentage'
- . /macros/setup_rmabill.com 101c
- quiz auto=$obj/u140_k.qzc
- qtp auto=$obj/u140_d1_remove_dups.qtc
- qtp auto=$obj/u140_f.qtc

******************************************************************************
+$cmd/u140_stage4
******************************************************************************
- $cmd/u140_stage4.com > u140_stage4.log

u140_stage4.com
---------------
- . /macros/setup_rmabill.com 101c
- qtp  << QTP_EXIT
-   exec $obj/u140_e.qtc
-   A
-   A
- QTP_EXIT
- . /macros/setup_rmabill.com solo
- qtp  << QTP_EXIT
-   exec $obj/u140_e.qtc
-   C
-   C
- QTP_EXIT
- . /macros/setup_rmabill.com 101c
- quiz << QUIZ_EXIT
-   exec $obj/r140_e.qzc
- QUIZ_EXIT
+- $cmd/r140_verify

$cmd/r140_verify
----------------
+- $cmd/r140_verify.com > r140_verify.log

r140_verify.com
---------------
- . /macros/setup_rmabill.com  101c
- qutil << EOP_QUTIL
-   create file tmp-governance-payments-file
- EOP_QUTIL
- qtp auto=$obj/r140w1.qtc
- qtp auto=$obj/r140w2.qtc
- . /macros/setup_rmabill.com  solo
- qtp auto=$obj/r140w2.qtc
- . /macros/setup_rmabill.com  101c
- quiz auto=$obj/r140w3.qzc


*****************************************************************************************
*****************************************************************************************
*****************************************************************************************
************************** 3 - MOH AGEP PAYMENTS PROCEDURES *****************************
*****************************************************************************************
*****************************************************************************************
*****************************************************************************************


******************************************************************************
$cmd/u031.com
******************************************************************************
- Calls following quiz repeatably
- quiz auto=$obj/r031a.qzc


******************************************************************************
$cmd/utl0013.com
******************************************************************************
- qtp  auto=$obj/utl0013.qtc  >> utl0013.log
- quiz auto=$obj/utl0013.qzc  >> utl0013.log


******************************************************************************
$cmd/verify_doctor_premiums 
******************************************************************************
- quiz auto=$obj/r031_before_update_3.qzc		(inside r031_before_update.qzs)


******************************************************************************
$cmd/print_r031b_before_update 
******************************************************************************
- quiz auto=$obj/r031_before_update.qzu


******************************************************************************
$cmd/agep_part2 
******************************************************************************
- qtp auto=$obj/u030b_part3_b.qtc
- quiz auto=$obj/r030k.qzc
- quiz auto=$obj/r030k_csv.qzc
- quiz auto=$obj/r030l.qzc
- quiz auto=$obj/r030m.qzc
- quiz auto=$obj/r030q.qzc
+- quiz auto=$obj/r030r.qzu

quiz auto=$obj/r030r.qzu
------------------------
- exec $obj/r030r1			(inside r030r.qzs)
- exec $obj/r030r2 			(inside r030r.qzs)
- exec $obj/r030r3			(inside r030r.qzs)

******************************************************************************
$cmd/agep_part3
******************************************************************************
qtp auto=$obj/u031.qtc


*****************************************************************************************
*****************************************************************************************
*****************************************************************************************
**************************** 4 - MOHD PAYMENTS PROCEDURES *******************************
*****************************************************************************************
*****************************************************************************************
*****************************************************************************************

******************************************************************************
$cmd/print_r031b_mohd_before_update 
******************************************************************************
- quiz auto=$obj/r031_before_update.qzu

quiz auto=$obj/r031_before_update.qzu
-------------------------------------
exec $obj/r031_before_update_1				(inside r031_before_update.qzs)
exec $obj/r031_before_update_2				(inside r031_before_update.qzs)
exec $obj/r031_before_update_3				(inside r031_before_update.qzs)

******************************************************************************
$cmd/mohd_part1
******************************************************************************
- qutil << eof_qutil
-   create file tmp-counters-alpha
-   create file tmp-doctor-alpha
- eof_qutil
- qtp auto=$obj/u030b_part3_a.qtc
- quiz  auto=$obj/r031c.qzu           
- quiz  auto=$obj/r030n.qzc
- quiz auto=$obj/r031_part3_before_update.qzc


quiz  auto=$obj/r031c.qzu           
-------------------------
exec $obj/r031c_1.qzc
exec $obj/r031c_2.qzc

******************************************************************************
$cmd/mohd_part2
******************************************************************************
- qtp auto=$obj/u030b_part3_b.qtc
- quiz auto=$obj/r030k.qzc
- quiz auto=$obj/r030k_csv.qzc
- quiz auto=$obj/r030l.qzc
- quiz auto=$obj/r030m.qzc
- quiz auto=$obj/r030q.qzc
- quiz auto=$obj/r030r.qzu


>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< New >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

*+$cmd/agep_part1 > agep_part1.log			(Adding)
----------------------------------

- qutil << eof_qutil
	create file tmp-counters-alpha
	create file tmp-doctor-alpha
	
- qtp auto=$obj/u030b_part3_a.qtc
- quiz  auto=$obj/r031c.qzu           
- quiz  auto=$obj/r030n.qzc          
