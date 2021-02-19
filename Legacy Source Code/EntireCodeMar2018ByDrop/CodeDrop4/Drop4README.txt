=================================================================================
===================================================================================
===================================================================================
Brads Video
===================================================================================
===================================================================================
===================================================================================

********************
********************
D001_1_ENTRY-Brad
********************
********************

Main-Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B


***********************
***********************
D001_1_INTRO-Brad
***********************
***********************

Main Menu
Option 5
Option 5	Cobol M040
Option 1	Cobol D001A		


===================================================================================
===================================================================================
===================================================================================
Jillian
===================================================================================
===================================================================================
===================================================================================

*********************************************
*********************************************
Bill Directs-Sub Menu-Message Master E,2
*********************************************
*********************************************
Main Menu
Option E
Option 2		Cobol M094

**************************************
**************************************
2-Bill Directs Sub Menu-Menu E, 3
**************************************
**************************************

Main Menu
Option E
Option 2		Cobol M095

***************************************
***************************************
3-Entering Patient Masters- Menu 5,1
***************************************
***************************************

Main Menu
Option 5
Option 1		Quick M010 (Patient Maintenance)

*************************************
*************************************
4-Keying Agent 1 Claims Menu 1,1
*************************************
*************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B
		

**************************************************************
**************************************************************
5-Keying Agent 6 Claims (OHIP PRICED IFH CLAIMS) Menu 1,1
**************************************************************
**************************************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B

*************************************************************
*************************************************************
6-Keying Agent 6 Claims (OMA PRICED NO INSURANCE) Menu 1,1
*************************************************************
*************************************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B

**********************************************************************
**********************************************************************
7-Keying Agent 6 Claims (OMA PRICED WITH INSURANCE) Menu 1,1 (2)
**********************************************************************
**********************************************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B

*******************************************************
*******************************************************
8-Keying Agent 9 Claims (OHIP PRICED WSIB) Menu 1,1
*******************************************************
*******************************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B

*****************************************************************************************
*****************************************************************************************
9-Reprinting Claim for Resending-Claims Query Menu 3-IFH Claim, Insurance Claims
*****************************************************************************************
*****************************************************************************************

Main Menu
Option 3		Cobol D003 (Claims Query)


***********************************************************************
***********************************************************************
10-Reprinting Claim for Resending-Claims Query Menu 3-Private Claims 
***********************************************************************
***********************************************************************

Main Menu
Option 3		Cobol D003 (Claims Query)


===================================================================================
===================================================================================
===================================================================================
Linda
===================================================================================
===================================================================================
===================================================================================

**************************************************************************************************
**************************************************************************************************
1 Entering a claim menu 1, 1, 2 Entering a claim menu 1, 1.. 42 Entering a claim menu 1, 1
**************************************************************************************************
**************************************************************************************************

Main Menu
Option 1
Option 1		Cobol D001A
			Cobol D001B

******************************************
******************************************
3 Continue existing batch menu 1, 2
******************************************
******************************************

3 Continue existing batch menu 1, 2
Main Menu
Option 1		Cobol D001A
Option 2


***********************************
***********************************
43 Entering a patient menu 5, 1....> 46 Entering a patient menu 5, 1
61 Modifying a patient menu 5, 1
***********************************
***********************************

Main Menu
Option 5 
Option 1 		Quick M010 	(Patient Menu)


**********************************
**********************************
47 Location master menu 5, 4....> 50 Location master menu 5, 4
**********************************
**********************************

Main Menu
Option 5
Option 4		Cobol M030	(Location Master)

**************************************
**************************************
51 OMA OHIP Fee master menu 5, 5...> 54 OMA OHIP Fee master menu 5, 5
**************************************
**************************************

Main Menu
Option 5
Option 5		Cobol M040	(Fee Master Maintenance)

***************************
***************************
55 Claim query menu 3...> 60 Claim query menu 3
63 Claim query menu 3...> 65 Claim query menu 3
***************************
***************************

Main Menu
Option 3		Cobol D003 (Claims Query)


************************************************
************************************************
62 Transfer claim between patients menu 5, O
************************************************
************************************************

Main Menu
Option 5
Option O 		Quick utl1002.qkc

*******************************
*******************************
66 Delete a claim menu 2
*******************************
*******************************

Main Menu
Opton 2 		Cobol: D002

***********************************************
***********************************************
67 Diskette Accounting Number Query menu 7...> 71 Diskette Accounting Number Query menu 7
***********************************************
***********************************************

Main Menu
Option 7		Quick: D713.qkc


===================================================================================
===================================================================================
===================================================================================
Lori
===================================================================================
===================================================================================
===================================================================================

******************************
******************************
1- A Adjustment Bad Debs
2- B Adjusted Claims menu 4,1
3- B Adjusted Claims - Diagnostics menu 4,1
4 - R Revenue Transfer menu 4,1
5 - C Cash Payment  menu 4,1
6 - C Cash Payment menu 4,1
7 - M Miscellaneous Payment  menu 4,1
8 - M Miscellaneous Payment - Show how to continue a batch menu 4,2
******************************
******************************

Main Menu
Option 4		Cobol: 	D004A
				D004B
				
***********************************************************************				
***********************************************************************				
9 - Automatic Adjustments from D003 claims query screen, menu, 3
10 - D003 claims query screen function F8 menu 3
11 - D003 claims query screen to test Brief mode menu 3
***********************************************************************				
***********************************************************************				

Main Menu
Option 3		Cobol: D003


===================================================================================
===================================================================================
===================================================================================
Yasemin
===================================================================================
===================================================================================
===================================================================================

* Means a command entered in the procedure
+ means it can be further broken down


*******************
*******************
*1-check_elig_pat
*******************
*******************

*+$cmd/check_elig_pat 
---------------------
+$cmd/check_elig_corrected_patients  1>check_elig_pat.log 2>&1

$cmd/check_elig_corrected_patients
----------------------------------
qtp auto=$obj/createf086.qtc


*************************************
*************************************
2-D004 - Automated MISC payments
*************************************
*************************************

*upl
----

- Puts user in upload directory

*$cmd/u141.com  d004_NH_20170621.csv
------------------------------------

awk -f $cmd/u141.awk < $1 > $pb_data/misc_payment_file.dat

*$cmd/u141_verify 
-----------------
qtp  auto=$obj/u141a.qtc
quiz auto=$obj/r141b1.qzc (inside r141b.qzs)
quiz auto=$obj/r141b2.qzc (inside r141b.qzs)


*$cmd/u141_create  
-----------------
qtp  auto=$obj/u141c.qtc
quiz auto=$obj/r141d.qzc


**********************
**********************
3-Duplicate IKEY
**********************
**********************

*cobrun $obj/u993
-----------------

*$cmd/recreate_clean_suspense 
------------------------
-> cobrun $obj/createsusp
-> . $cmd/create_susp_links.com

. $cmd/create_susp_links.com
----------------------------
- Creates links (ln)


*************************
*************************
4-Eligibility-Letters
*************************
*************************

*$cmd/run_dates 							(Was in Drop 4. Moved to Drop 3)
---------------
quick auto=$obj/ohip_run_dates.qkc					(Was in Drop 4. Moved to Drop 3)

*$cmd/print_elig_letters
------------------------
-> qutil << qutil_exit		create file tmp-counters
qtp exec $obj/u085.qtc
quiz exec $obj/r085e_1.qzc	(inside r085e.qzs)
quiz exec $obj/r085e_2.qzc	(inside r085e.qzs)
quiz exec $obj/r085e_3.qzc	(inside r085e.qzs)
qtp exec $obj/u085e.qtc


******************
******************
5-Oscar-emr-run
******************
******************

*oscar
------
- Puts user in oscar directory

*copyoscar_xx (01-99) 
---------------------
- (same script different hardcodes). 
- Not in gold code
- Dynamically created. Review with Brad
- Copies a file into an oscar directory

*oscarxx (01-99) 
----------------
- puts user in oscar directory). 
- Not in gold code

*vs or view_suspense
--------------------
quick auto=$obj/d705.qkc

*runoscar_xx (01-99 scripts) 
----------------------------
- not in Gold code
- Dynamically created. Review with Brad
+ $cmd/u701oscar 254482
- quiz auto=$obj/suspend_dtl_emr
+ $cmd/suspend_dtl


+ $cmd/u701oscar 254482
-----------------------
cobrun $obj/u701oscar
qtp auto=$obj/newu701.qtc
+ $cmd/check_for_resubmits
quiz auto=$obj/r712.qzc
quiz auto=$obj/r702.qzc
cobrun $obj/u703oscar
qtp auto=$obj/u704.qtc
quiz auto=$obj/r707.qzc
qtp auto=$obj/u705.qtc
quiz auto=$obj/r710.qzc
quiz auto=$obj/ru701_acr.qzc

+ $cmd/check_for_resubmits
--------------------------
qtp auto=$obj/u714.qtc
quiz auto=$obj/r715.qzc


+ $cmd/suspend_dtl
------------------
qtp execute $obj/suspdtl			(Missing!)
qtp execute $obj/suspdtl_2  			(Missing!)
+quiz use $obj/suspend_dtl.qzu
qtp auto=$obj/suspend_agent_detail.qtc
quiz auto=$obj/suspend_agent.qzc
quiz auto=$obj/suspend_agent_detail.qzc
+quiz auto=$obj/dump_tech.qzu
quiz auto=$obj/suspend_desc.qzc
quiz auto=$obj/suspend_suffix.qzc


+ quiz use $obj/suspend_dtl.qzu
-------------------------------
quiz exe $obj/suspend_dtl1			(Missing!)
quiz exe $obj/suspend_dtl2			(Missing!)

+ quiz auto=$obj/dump_tech.qzu
------------------------------
quiz exec $obj/dump_tech1			(Missing!)
quiz exec $obj/dump_tech2			(Missing!)

*$cmd/print_diskettes
---------------------
+ $cmd/fix_dump_tech

+ $cmd/fix_dump_tech
--------------------
qtp exe $obj/fix_dump_tech.qtc


*$cmd/suspend_total 
-------------------
qtp execute $obj/suspdtl			(Missing!)
qtp execute $obj/suspdtl_2 (2)			(Missing!)
qtp execute $obj/web_before_after

quiz execute $obj/suspend_total1		(Missing!)
quiz execute $obj/suspend_total2		(Missing!)
quiz execute $obj/check_susp_dtl
quiz execute $obj/suspend_status 
quiz execute $obj/suspend_suffix		(Already Done)
quiz execute $obj/web_before_after		(Already Done)

+ $cmd/resubmits

+ $cmd/resubmits
----------------
qtp auto=$obj/u714.qtc
quiz auto=$obj/r715.qzc


*cobrun $obj/r001						(Moved to Drop 3)
-----------------

*$cmd/batch_disk_create_claims 					(Moved to Drop 3)
------------------------------
+$cmd/disk_create_claims    > claims.ls				(Moved to  Drop 3)

+$cmd/disk_create_claims    > claims.ls				(Moved to Drop 3)
---------------------------------------
+ $cmd/maintain_backup_copies_of_suspend_files			(Moved to Drop 3)
qtp auto=$obj/u708.qtc						(Moved to Drop 3)
qtp auto=$obj/newu706a.qtc					(Moved to Drop 3)
quiz auto=$obj/r709a.qzc					(Moved to Drop 3)
quiz auto=$obj/r709b.qzc					(Moved to Drop 3)


+ $cmd/maintain_backup_copies_of_suspend_files			(Moved to Drop 3)
----------------------------------------------
!!!(copies idx files around. Will need to rethink with RELATIONAL!!!

*****************
*****************
6-Diskette-run
*****************
*****************


*diskxx: disk1..disk10 
----------------------
(script to change directory to disk1...disk10

*$cmd/cleanup_diskettes
-----------------------
- removes a number of files

*$cmd/recreate_clean_suspense 				(Already Done)
-----------------------------
- removes a bunch of files

*u700
------
- reformats data. No PH

*newu701
--------
- cobrun $obj/newu701
- qtp auto=$obj/newu701.qtc
+ $cmd/check_for_resubmits				(Already Done)
- quiz auto=$obj/r712.qzc				(Already Done)
- quiz auto=$obj/r702.qzc				(Already Done)
- cobrun $obj/newu703
- qtp auto=$obj/u704.qtc				(Already Done)
- quiz auto=$obj/r707.qzc				(Already Done)
- qtp auto=$obj/u705.qtc				(Already Done)
- quiz auto=$obj/r710.qzc				(Already Done)
- quiz auto=$obj/ru701_acr.qzc				(Already Done)
- qtp auto=$obj/temp_ignore_agent6_susp_hdr.qtc
- quiz auto=$src/r717.qzs


*$cmd/suspend_dtl  					(Already Done)
-----------------

*$cmd/print_diskettes   				(Already Done)
---------------------

*$cmd/suspend_total   					(Already Done)
-------------------

*cobrun $obj/r001					(Already Done)
-----------------

*$cmd/batch_disk_create_claims				(Already Done)
------------------------------

*$cmd/reverse_backup_copies_of_suspend_files
--------------------------------------------
( moves and removes files)

*$cmd/recreate_clean_suspense 				(Already Done)
-----------------------------



***************
***************
7-web-run
***************
***************


*webxx: web1...web10 
----------------------
- (script to change direectory to web1..web10)

*vs or view_suspense
--------------------

*recreate_clean_suspense				(Already Done)
-=----------------------

*u700							(Already Done)
-----

*newu701						(Already Done)
--------

*suspend_dtl  						(Already Done)
------------

*print_diskettes  					(Already Done)
----------------

*cobrun $obj/r001					(Already Done)
-----------------

*$cmd/suspend_total   					(Already Done)
-------------------

*+$cmd/batch_web_create_claims 20171025  		(Moved to Drop 3)
--------------------------------------
+ $cmd/web_create_claims  $1      > web.ls		(Moved to Drop 3)

+ $cmd/web_create_claims  $1      > web.ls		(Moved to Drop 3)
------------------------------------------
- quiz auto=$obj/rmaprice.qzc				(Moved to Drop 3) 
- qtp  auto=$obj/u716a.qtc				(Moved to Drop 3)
- quiz auto=$obj/r716a.qzc				(Moved to Drop 3)
- quiz auto=$obj/r716b.qzc				(Moved to Drop 3)
- qtp  auto=$obj/u716c.qtc				(Moved to Drop 3)
- quiz auto=$obj/r716c1.qzc	(inside r716c.qzs)	(Moved to Drop 3)
- quiz auto=$obj/r716c2.qzc	(inside r716c.qzs)	(Moved to Drop 3)
- $cmd/disk_create_claims					(Already Done)

===================================================================================
===================================================================================
===================================================================================
Added from Yas's email Feb 08, 2018
===================================================================================
===================================================================================
===================================================================================

*+$cmd/final_check
------------------
+$cmd/dump_tech
+$cmd/resubmits 					(Already Done)
+$cmd/suffix    
+$cmd/check_suspend_dtl
+$cmd/check_suspend_amounts

+$cmd/dump_tech
---------------
+quiz dump_tech.qzu

quiz dump_tech.qzu
------------------
- quiz exec $obj/dump_tech1
- quiz exec $obj/dump_tech2


+$cmd/suffix    
------------
- quiz auto=$obj/suspend_suffix.qzc

+$cmd/check_suspend_dtl
-----------------------
- quiz execute $obj/check_susp_dtl


+$cmd/check_suspend_amounts
---------------------------
- quiz auto=$src/r717.qzs
