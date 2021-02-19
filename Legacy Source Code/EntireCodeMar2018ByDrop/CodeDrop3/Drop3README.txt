
********************************
********************************
2 - 1st  MONTHEND procedures ***
********************************
********************************

* Means a command entered in the procedure manually by operator
+ means it can be durther broken down

*$cmd/cleanup_80_91to96_monthends
--------------------------------
+$cmd/cleanup_37_monthend (removes files from specific directories)
+$cmd/cleanup_68_monthend (removes files from specific directories)
+$cmd/cleanup_69_monthend (removes files from specific directories)
+$cmd/cleanup_78_monthend (removes files from specific directories)
+$cmd/cleanup_79_monthend (removes files from specific directories)
+$cmd/cleanup_80_monthend (removes files from specific directories)
+$cmd/cleanup_84_monthend (removes files from specific directories)
+$cmd/cleanup_87_monthend (removes files from specific directories)
+$cmd/cleanup_88_monthend (removes files from specific directories)
+$cmd/cleanup_89_monthend (removes files from specific directories)
+$cmd/cleanup_91_monthend (removes files from specific directories)
+$cmd/cleanup_92_monthend (removes files from specific directories)
+$cmd/cleanup_93_monthend (removes files from specific directories)
+$cmd/cleanup_94_monthend (removes files from specific directories)
+$cmd/cleanup_95_monthend (removes files from specific directories)
+$cmd/cleanup_96_monthend (removes files from specific directories)


*$cmd/batch_run_first_monthend_reports
-------------------------------------
+$cmd/run_monthends_80_91to96
+$cmd/reports_first_monthend


$cmd/run_monthends_80_91to96
----------------------------
+$cmd/run_monthend_ar_37 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_68 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_69 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_78 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_79 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_80 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_84 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_87 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_88 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_89 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_91 (these all do the same thing but call COBOL programs with different parameters) (see label:f for patterrn
+$cmd/run_monthend_ar_92 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_93 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_94 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_95 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/run_monthend_ar_96 (these all do the same thing but call COBOL programs with different parameters) (see label:run_monthend_ar for patterrn
+$cmd/r004_ph_portal_80_84_91to96
+$cmd/r051_portal_80_84_87_91to96

(run_monthend_ar)
-----------------
cd $application_production/37
cobrun $obj/r004a << R004A_EXIT
cobrun $obj/r004b
cobrun $obj/r004c << R004C_EXIT
cobrun $obj/r005 << R005_EXIT
cobrun $obj/r011 << R011_EXIT
cobrun $obj/r012 << R012_EXIT
cobrun $obj/r013 << R013_EXIT
cobrun $obj/r051a << R051A_EXIT
cobrun $obj/r051b
cobrun $obj/r051c
cobrun $obj/r070a << R070A_EXIT
cobrun $obj/r070b
cobrun $obj/r070c << R070C_EXIT


r004_ph_portal_80_84_91to96
---------------------------
cd $application_production/37
$cmd/r004_portal 37@  37			(Script does same things for 37...96)

$cmd/r004_portal
----------------
quiz exec $obj/r004a
quiz exec $obj/r004b
quiz exec $obj/r004c
quiz exec $obj/r004d
quiz exec $obj/r004c_portal
quiz exec $obj/r004c_portal_ss


r051_portal_80_84_87_91to96
---------------------------
quiz exec $obj/r051ca_portal			(called repetively for clinics 37...96)
quiz exec $obj/r051cb_portal			(called repetively for clinics 37...96)


$cmd/reports_first_monthend
---------------------------
+$cmd/r070_csv_first_monthend
+$cmd/r005_csv_first_monthend
+$cmd/*file_first_monthend


$cmd/r070_csv_first_monthend
----------------------------
+$cmd/r070_csv.com  1          > r070_csv_first_monthend.log

+$cmd/r070_csv.com
-----------------
quiz auto=$obj/r070a_csv.qzc  << E_O_F		(all a, b and c in r050_csv.qzs)
quiz auto=$obj/r070b_csv.qzc  
quiz auto=$obj/r070c_csv.qzc  


$cmd/r005_csv_first_monthend
----------------------------
+$cmd/r005_csv.com  1          > r005_csv_first_monthend.log


$cmd/r005_csv.com
-----------------
qtp auto=$obj/r005_csv.qtc  << E_O_F


*$cmd/claims_subfile_first_monthend
----------------------------------
+$cmd/claims_subfile_monthend.com  1  > claims_subfile_first_monthend.log


$cmd/claims_subfile_monthend.com
------------------------------
qtp exec $obj/unlof002_me_claim.qtc


*$cmd/batch_claims_subfile_80_91to96
------------------------------------
+$cmd/claims_subfile_80_91to96    > batch_claims_subfile_80_91to96.log

$cmd/claims_subfile_80_91to96
-----------------------------
+$cmd/create_claims_subfile 37 20170411 201704			(does this for 37 to 96)

+$cmd/create_claims_subfile
---------------------------
quiz exe $obj/create_claims_suba
quiz exe $obj/create_claims_subb
quiz exe $obj/create_claims_subc


*$cmd/backup_f001_f050
----------------------
(just does a bunch of cpio's, eyc)


*$cmd/doc_rev_monthly_roll_80_91to96
------------------------------------
+$cmd/doc_rev_monthly_roll_37			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_68			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_69			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_78			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_79			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_80			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_84			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_87			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_88			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_89			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_91			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_92			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_93			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_94			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_95			(all do the same thing for different clinics. See doc_rev_monthly_roll below)
+$cmd/doc_rev_monthly_roll_96			(all do the same thing for different clinics. See doc_rev_monthly_roll below)

(doc_rev_monthly_roll)
----------------------
qtp auto=$obj/u014_f050.qtc << E_O_F
qtp auto=$obj/u015.qtc 2>&1  1>u015_37.log << u015_EXIT


*$cmd/r011_80_91to96
--------------------
- cobrun $obj/r011 << R011_EXIT			(calls cobrun $obj/r011 over for each cliniic 37..96) (already called above too)

*$cmd/update_batch_status_80_91to96
-----------------------------------
$cmd/update_batch_status_37			(all do the same thing. See (update_batch_status) below
$cmd/update_batch_status_68
$cmd/update_batch_status_69
$cmd/update_batch_status_78
$cmd/update_batch_status_79
$cmd/update_batch_status_80
$cmd/update_batch_status_84
$cmd/update_batch_status_87
$cmd/update_batch_status_88
$cmd/update_batch_status_89
$cmd/update_batch_status_91
$cmd/update_batch_status_92
$cmd/update_batch_status_93
$cmd/update_batch_status_94
$cmd/update_batch_status_95
$cmd/update_batch_status_96

(update_batch_status)
---------------------
$update_batch_status_37 calls $cmd/status37 1>status.ls 2>&1				(all the statusXX files does the same thing. See (statusXX below)
$cmd/update_batch_status_68 calls $cmd/status37 1>status.ls 2>&1
$cmd/update_batch_status_69 calls $cmd/status69 1>status.ls 2>&1
$cmd/update_batch_status_78 calls $cmd/status78 1>status.ls 2>&1
$cmd/update_batch_status_79 calls $cmd/status79 1>status.ls 2>&1
$cmd/update_batch_status_80 calls $cmd/status80 1>status.ls 2>&1
$cmd/update_batch_status_84 calls $cmd/status84 1>status.ls 2>&1
$cmd/update_batch_status_87 calls $cmd/status87 1>status.ls 2>&1
$cmd/update_batch_status_88 calls $cmd/status88 1>status.ls 2>&1
$cmd/update_batch_status_89 calls $cmd/status89 1>status.ls 2>&1
$cmd/update_batch_status_91 calls $cmd/status91 1>status.ls 2>&1
$cmd/update_batch_status_92 calls $cmd/status92 1>status.ls 2>&1
$cmd/update_batch_status_93 calls $cmd/status93 1>status.ls 2>&1
$cmd/update_batch_status_94 calls $cmd/status94 1>status.ls 2>&1
$cmd/update_batch_status_95 calls $cmd/status95 1>status.ls 2>&1
$cmd/update_batch_status_96 calls $cmd/status96 1>status.ls 2>&1

(statusXX)
----------
qtp auto=$obj/u210.qtc << QTP_EXIT
quiz auto=$obj/r211.qzc << QUIZ_EXIT


*$cmd/f050hist
--------------
- quiz auto=$obj/audit_f050hist.qzc


*$cmd/afp_pedsurgery
--------------------
- qtp auto=$obj/pedsurgery.qtc							


*$cmd/change_ped_first_monthend
-------------------------------
+ $cmd/change_ped_monthend.com  1 ${1}  > change_ped_first_monthend.log		(already in drop 1)


*$cmd/backup_80_91to96_reports
------------------------------
cpio's a bunch of files to backup


*$cmd/copy_subfiles_first_monthend
----------------------------------
- copies a bunch of files


*$cmd/backup_subfile
--------------------
- backups files


*$cmd/kathyf001status
---------------------
- quiz auto=$obj/kathyf001status.qzc


*$cmd/run_hold_mess_nopayment
-----------------------------
+ $cmd/no_ohip_payment_claims 1>>hold.ls  2>&1

$cmd/no_ohip_payment_claims
---------------------------
+ quiz auto=$obj/utl00013.qzu << QUIZ_EXIT

$obj/utl00013.qzu
-----------------
quiz exe $obj/utl00013a						(inside utl00013.qzs)
quiz exe $obj/utl00013b						(inside utl00013.qzs)


*$cmd/stale_dates_lori
----------------------
+ quiz auto=$obj/r022g.qzu     


$obj/r022g.qzu
--------------
quiz exec $obj/r022g_1						(inside r022g.qzs)
quiz exec $obj/r022g_2 						(inside r022g.qzs)


*$cmd/stale_dates_melissa
-------------------------
+ quiz auto=$obj/r022f.qzu     

$obj/r022f.qzu
--------------
quiz exec $obj/r022f_1
quiz exec $obj/r022f_2    



********************************
********************************
3 - 2nd MONTHEND procedures ****
********************************
********************************

*$cmd/cleanup_60_82_83_86_monthends
-----------------------------------
$cmd/cleanup_82_monthend						(these scripts delete files)
$cmd/cleanup_86_monthend						(these scripts delete files)
$cmd/cleanup_60_monthend						(these scripts delete files)
$cmd/cleanup_70_monthend						(these scripts delete files)


*$cmd/batch_run_second_monthend_reports
---------------------------------------
+ $cmd/run_monthends_60_82_83_86    > batch_run_monthends_60_82_83_86.log
+ $cmd/reports_second_monthend	  > batch_report_second_monthend.log


$cmd/run_monthends_60_82_83_86
------------------------------
+ $cmd/run_monthend_ar_82
+ $cmd/monthly_stage40_and_ar_tp
+ $cmd/run_monthend_ar_86
+ $cmd/run_monthend_ar_70
+ $cmd/r004_ph_portal_60_82_83_86
+ $cmd/r051_portal_60_70_82_86


$cmd/run_monthend_ar_82 (same as AR stuff above)
-----------------------
cobrun $obj/r004a << R004A_EXIT					(Already called above)
cobrun $obj/r004b						(Already called above)
cobrun $obj/r004c << R004C_EXIT					(Already called above)
cobrun $obj/r005 << R005_EXIT					(Already called above)
cobrun $obj/r011 << R011_EXIT					(Already called above)
cobrun $obj/r012 << R012_EXIT					(Already called above)
cobrun $obj/r013 << R013_EXIT					(Already called above)
cobrun $obj/r051a << R051A_EXIT					(Already called above)
cobrun $obj/r051b						(Already called above)
cobrun $obj/r051c						(Already called above)
cobrun $obj/r070a << R070A_EXIT					(Already called above)
cobrun $obj/r070b						(Already called above)
cobrun $obj/r070c << R070C_EXIT					


$cmd/monthly_stage40_and_ar_tp
--------------------------------
- $cmd/stage40tp 1>40tp.ls 2>&1

$cmd/stage40tp
--------------
+ quiz auto=$obj/stage40tp.qzu

$obj/stage40tp.qzu
------------------
quiz exe $obj/utl0006
quiz exe $obj/utl0006a
quiz exe $obj/utl0007
quiz exe $obj/r004atp
quiz exe $obj/r004btp
quiz exe $obj/r004ctp
quiz exe $obj/r004dtp
quiz exe $obj/r005atp
quiz exe $obj/r005btp
quiz exe $obj/r005ctp
quiz exe $obj/r005dtp
quiz exe $obj/r006atp
quiz exe $obj/r006btp
quiz exe $obj/r006ctp
quiz exe $obj/r006dtp
quiz exe $obj/r011a
quiz exe $obj/r011b
quiz exe $obj/r011c
quiz exe $obj/r012atp
quiz exe $obj/r012btp
quiz exe $obj/r012ctp
quiz exe $obj/r013atp
quiz exe $obj/r013btp
quiz exe $obj/r013ctp
quiz exe $obj/r015atp
quiz exe $obj/r015btp
quiz exe $obj/r015ctp
quiz exe $obj/r051caatp
quiz exe $obj/r051cabtp
quiz exe $obj/r051cactp
quiz exe $obj/r051cbatp
quiz exe $obj/r051cbbtp
quiz exe $obj/r051cbctp
quiz exe $obj/r070atp
quiz exe $obj/r070btp
quiz exe $obj/r070ctp
quiz exe $obj/r070dtp
quiz exe $obj/r051a_tp_per
quiz exe $obj/r051b_tp_per

$cmd/run_monthend_ar_86
-----------------------
cobrun $obj/r004a << R004A_EXIT					(Already called above)
cobrun $obj/r004b						(Already called above)
cobrun $obj/r004c << R004C_EXIT					(Already called above)
cobrun $obj/r005 << R005_EXIT					(Already called above)
cobrun $obj/r011 << R011_EXIT					(Already called above)
cobrun $obj/r012 << R012_EXIT					(Already called above)
cobrun $obj/r013 << R013_EXIT					(Already called above)
cobrun $obj/r051a << R051A_EXIT					(Already called above)
cobrun $obj/r051b						(Already called above)
cobrun $obj/r051c						(Already called above)
cobrun $obj/r070a << R070A_EXIT					(Already called above)
cobrun $obj/r070b						(Already called above)
cobrun $obj/r070c << R070C_EXIT					

$cmd/run_monthend_ar_70
-----------------------
+ quiz auto=$obj/stage40tp_70.qzu

$obj/stage40tp_70.qzu
---------------------
quiz exe $obj/utl0006_70
quiz exe $obj/utl0006a_70
quiz exe $obj/utl0007_70
quiz exe $obj/utl0007a_70
quiz exe $obj/r004atp_70
quiz exe $obj/r004btp_70
quiz exe $obj/r004ctp_70
quiz exe $obj/r004dtp_70
quiz exe $obj/r005atp_70
quiz exe $obj/r005btp_70
quiz exe $obj/r005ctp_70
quiz exe $obj/r005dtp_70
quiz exe $obj/r006atp_70
quiz exe $obj/r006btp_70
quiz exe $obj/r006ctp_70
quiz exe $obj/r006dtp_70
quiz exe $obj/r011a_70
quiz exe $obj/r011b_70
quiz exe $obj/r011c_70
quiz exe $obj/r012atp_70
quiz exe $obj/r012btp_70
quiz exe $obj/r012ctp_70
quiz exe $obj/r013atp_70
quiz exe $obj/r013btp_70
quiz exe $obj/r013ctp_70
quiz exe $obj/r015atp_70
quiz exe $obj/r015btp_70
quiz exe $obj/r015ctp_70
quiz exe $obj/r051caatp_70
quiz exe $obj/r051cabtp_70
quiz exe $obj/r051cactp_70
quiz exe $obj/r051cbatp_70
quiz exe $obj/r051cbbtp_70
quiz exe $obj/r051cbctp_70
quiz exe $obj/r070atp_70
quiz exe $obj/r070btp_70
quiz exe $obj/r070ctp_70
quiz exe $obj/r070dtp_70
quiz exe $obj/r051a_tp_per_70
quiz exe $obj/r051b_tp_per_70

$cmd/r004_ph_portal_60_82_83_86
-------------------------------
(Does the following repeatedly for various clinics)
- quiz exec $obj/r004atp nogo							(already called above)
- choose batctrl-batch-nbr '61000000' to '61ZZZ999'
- go
- quiz exec $obj/r004btp_portal


$cmd/r051_portal_60_70_82_86
----------------------------
(calls the follopwing repeatedly for various clinics)
- quiz exec $obj/r051ca_portal
- quiz exec $obj/r051cb_portal
- quiz exec $obj/r051catp_portal     
- quiz exec $obj/r051cbtp_portal     



$cmd/reports_second_monthend
----------------------------
+ $cmd/r070_csv_second_monthend
+ $cmd/r005_csv_second_monthend
+ $cmd/claims_subfile_second_monthend

$cmd/r070_csv_second_monthend
-----------------------------
+ $cmd/r070_csv.com  2          > r070_csv_second_monthend.log		(already done above)


$cmd/r005_csv_second_monthend
-----------------------------
$cmd/r005_csv.com  2          > r005_csv_second_monthend.log		(already done above)


$cmd/claims_subfile_second_monthend
-----------------------------------
$cmd/claims_subfile_monthend.com  2  > claims_subfile_second_monthend.log	(already done above)


*$cmd/batch_claims_subfile_60_82_83_86
--------------------------------------
$cmd/claims_subfile_60_82_83_86    > batch_claims_subfile_60_82_83_86.log


$cmd/claims_subfile_60_82_83_86
-------------------------------
$cmd/create_claims_subfile 61 20170417 201704					(already done above)
$cmd/create_claims_subfile 62 20170417 201704					(already done above)
$cmd/create_claims_subfile 63 20170417 201704					(already done above)
$cmd/create_claims_subfile 64 20170417 201704					(already done above)
$cmd/create_claims_subfile 65 20170417 201704					(already done above)
$cmd/create_claims_subfile 66 20170417 201704					(already done above)
$cmd/create_claims_subfile 71 20170417 201704					(already done above)
$cmd/create_claims_subfile 72 20170417 201704					(already done above)
$cmd/create_claims_subfile 73 20170417 201704					(already done above)
$cmd/create_claims_subfile 74 20170417 201704					(already done above)
$cmd/create_claims_subfile 75 20170417 201704					(already done above)
$cmd/create_claims_subfile 82 20170417 201704					(already done above)
$cmd/create_claims_subfile 86 20170417 201704					(already done above)


xxx quick auto=$obj/ikeyscreen.qkc (Missing!)
							*$cmd/backup_f001_f050 (already done above)
*$cmd/doc_rev_monthly_roll_60_82_83_86
--------------------------------------
$cmd/doc_rev_monthly_roll_82				(all do the same thing. See (doc_rev_monthly_roll (a) ) below)
$cmd/doc_rev_monthly_roll_86				(all do the same thing. See (doc_rev_monthly_roll (a) ) below)
$cmd/doc_rev_monthly_roll_60				(all do the same thing. See (doc_rev_monthly_roll (b) ) below)
$cmd/doc_rev_monthly_roll_70				(all do the same thing. See (doc_rev_monthly_roll (b) ) below)

(doc_rev_monthly_roll (a))
--------------------------
qtp auto=$obj/u014_f050.qtc 2>&1 1>u014_f050_82.log << E_O_F			(already done above)
qtp auto=$obj/u015.qtc 2>&1  1>u015_82.log << u015_EXIT				(already done above)

(doc_rev_monthly_roll (b))
--------------------------
qtp auto=$obj/u014_f050.qtc 2>&1 1>u014_f050_60.log << E_O_F			(already done above)
qtp auto=$obj/u014_f050tp.qtc 2>&1 1>u014_f050tp_60.log << E_O_F2
qtp auto=$obj/u015.qtc  2>&1 1>u015_60.log  << u015_EXIT			(already done above)
qtp auto=$obj/u015tp.qtc 2>&1  1>u015tp_60.log  << u015tp_EXIT


*$cmd/r011_60_82_83_86
----------------------
cobrun $obj/r011 << R011_EXIT							(already done above)
+ $cmd/r011_60
+ $cmd/r011_70


$cmd/r011_60
------------
quiz execute $obj/r011a								(already done above)
quiz execute $obj/r011b								(already done above)
quiz execute $obj/r011c								(already done above)

$cmd/r011_70
--------------
quiz execute $obj/r011a_70							(already done above)
quiz execute $obj/r011b_70							(already done above)
quiz execute $obj/r011c_70v

*$cmd/update_batch_status_60_82_83_86
-------------------------------------
$cmd/update_batch_status_60 calls $cmd/status60					(all do the same thing. see (statusXX) above
$cmd/update_batch_status_82 calls $cmd/status82
$cmd/update_batch_status_86 calls $cmd/status86
$cmd/update_batch_status_70 calls $cmd/status70

*$cmd/f050tphist
----------------
quiz auto=$obj/audit_f050tphist.qzc

										*$cmd/f050hist (aleady done above)
*$cmd/change_ped_second_monthend
--------------------------------
$cmd/change_ped_monthend.com  2  ${1}  > change_ped_second_monthend.log		(already sone above)


										*$cmd/kathyf001status (already done above)
*$cmd/backup_60_82_83_86_reports
--------------------------------
backs up files.

*$cmd/copy_subfiles_second_monthend
-----------------------------------
copies files

										*$cmd/backup_subfile (already done above)

********************************
********************************
5 - 3rd MONTHEND procedures ****
********************************
********************************

*$cmd/batch_run_third_monthend_reports
--------------------------------------
$cmd/run_monthend_stage40    > batch_run_monthend_stage40.log
$cmd/run_monthend_ar         > batch_run_monthend_ar.log
*$cmd/run_monthends_31to48    > batch_run_monthends_31to48.log
*$cmd/reports_third_monthend  > batch_reports_third_monthend.log          

$cmd/run_monthend_stage40
-------------------------
$cmd/run_stage_40 1>stage40.ls 2>&1

$cmd/run_stage_40 
-----------------
cobrun $obj/r004a << R004A_EXIT						(already done above)
cobrun $obj/r004b							(already done above)
cobrun $obj/r004c << R004C_EXIT						(already done above)
cobrun $obj/r005 << R005_EXIT						(already done above)
cobrun $obj/r011 << R011_EXIT						(already done above)
cobrun $obj/r012 << R012_EXIT						(already done above)
cobrun $obj/r013 << R013_EXIT						(already done above)
cobrun $obj/r051a << R051A_EXIT						(already done above)
cobrun $obj/r051b							(already done above)
cobrun $obj/r051c							(already done above)
cobrun $obj/r051b							(already done above)
cobrun $obj/r051c							(already done above)

$cmd/run_monthend_ar
--------------------
$cmd/accounts_receivable  22  1>ar.ls 2>&1

$cmd/accounts_receivable
------------------------
cobrun $obj/r070a << R070A_EXIT						(already done above)
cobrun $obj/r070b							(already done above)
cobrun $obj/r070c << R070C_EXIT						(already done above)

xxx quick auto=$obj/ikeyscreen.qkc (Missing!)

*$cmd/claims_subfile_22to48
---------------------------
$cmd/create_claims_subfile 22 20170421 201704				(already done above)
$cmd/create_claims_subfile 23 20170421 201704				(already done above)
$cmd/create_claims_subfile 24 20170421 201704				(already done above)
$cmd/create_claims_subfile 25 20170421 201704				(already done above)
$cmd/create_claims_subfile 26 20170421 201704				(already done above)
$cmd/create_claims_subfile 30 20170421 201704				(already done above)
$cmd/create_claims_subfile 31 20170421 201704				(already done above)
$cmd/create_claims_subfile 32 20170421 201704				(already done above)
$cmd/create_claims_subfile 33 20170421 201704				(already done above)
$cmd/create_claims_subfile 34 20170421 201704				(already done above)
$cmd/create_claims_subfile 35 20170421 201704				(already done above)
$cmd/create_claims_subfile 36 20170421 201704				(already done above)
$cmd/create_claims_subfile 41 20170421 201704				(already done above)
$cmd/create_claims_subfile 42 20170421 201704				(already done above)
$cmd/create_claims_subfile 43 20170421 201704				(already done above)
$cmd/create_claims_subfile 44 20170421 201704				(already done above)
$cmd/create_claims_subfile 45 20170421 201704				(already done above)
$cmd/create_claims_subfile 46 20170421 201704				(already done above)
$cmd/create_claims_subfile 98 20170421 201704				(already done above)


*$cmd/batch_claims_subfile_22to48
---------------------------------
$cmd/claims_subfile_22to48    > batch_claims_subfile_22to48.log		(see aboce)


*$cmd/copy_subfiles_third_monthend
----------------------------------
- moves files 

							CLNIC 22 PAYROLL (ALREADY DONE DROP 1)
							======================================
							$cmd/verify_101c_payroll_ok_to_run (already done drop 1)
							$cmd/r123 (already done drop 1)
							$cmd/eft_dump  (already done drop 1)
							$cmd/backup_eft (already done drop 1)
				
							RUN THE FOLLOWING PROGRAM ONLY FOR FEB/APR/JUNE/YEAREND/AUG/OCT/DEC
							===================================================================
							$cmd/print_quarterly_tax_rpt (already done drop 1) 


DO NOT CONTINUE UNTIL BACK UP IS DONE
=====================================

*$cmd/doc_rev_monthly_roll_22to48
---------------------------------
$cmd/doc_rev_monthly_roll_22				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_23				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_24				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_25				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_26				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_30				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_31				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_32				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_33				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_34				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_35				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_36				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_41				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_42				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_43				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_44				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_45				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_46				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )
$cmd/doc_rev_monthly_roll_98				(all do the same thing with diff parameters. See (doc_rev_nonthly_roll) )

(doc_rev_monthly_roll)
----------------------
- qtp auto=$obj/u014_f050.qtc << E_O_F				(already done, see above)
- qtp auto=$obj/u015.qtc 2>&1  1>u015_22.log << u015_EXIT	(already done, see above)


*$cmd/r011_22_31to48
--------------------
(runs r011 many times for each clinic)
cobrun $obj/r011 << R011_EXIT					(already done above)


*$cmd/update_batch_status_22to48
--------------------------------
$cmd/update_batch_status_22 calls $cmd/status22			(already done. See statusXX above) 
$cmd/update_batch_status_23 calls $cmd/status23			(already done. See statusXX above)  
$cmd/update_batch_status_24 calls $cmd/status24			(already done. See statusXX above)  
$cmd/update_batch_status_25 calls $cmd/status25			(already done. See statusXX above)  
$cmd/update_batch_status_26 calls $cmd/status26			(already done. See statusXX above)  
$cmd/update_batch_status_30 calls $cmd/status30			(already done. See statusXX above)  
$cmd/update_batch_status_31 calls $cmd/status31			(already done. See statusXX above)  
$cmd/update_batch_status_32 calls $cmd/status32			(already done. See statusXX above)  
$cmd/update_batch_status_33 calls $cmd/status33			(already done. See statusXX above)  
$cmd/update_batch_status_34 calls $cmd/status34			(already done. See statusXX above)  
$cmd/update_batch_status_35 calls $cmd/status35			(already done. See statusXX above)  
$cmd/update_batch_status_36 calls $cmd/status36			(already done. See statusXX above)  
$cmd/update_batch_status_41 calls $cmd/status41			(already done. See statusXX above)  
$cmd/update_batch_status_42 calls $cmd/status42			(already done. See statusXX above)  
$cmd/update_batch_status_43 calls $cmd/status43			(already done. See statusXX above)  
$cmd/update_batch_status_44 calls $cmd/status44			(already done. See statusXX above)  
$cmd/update_batch_status_45 calls $cmd/status45			(already done. See statusXX above)  
$cmd/update_batch_status_46 calls $cmd/status46			(already done. See statusXX above)  
$cmd/update_batch_status_98 calls $cmd/status98			(already done. See statusXX above)  


							*$cmd/f050hist (already done above)
							*$cmd/change_ped_third_monthend (already done drop 1)

IF YOU HAVE JUST FINISHED RUNNING JUNE MONTHEND CHANGE P.E.D. "YY.06.30" ***
============================================================================

							*$cmd/kathyf001status (already done above)
							*$cmd/drchurchill (already done drop 1)
xxx *$cmd/prodtithe (MISSING!!)

*$cmd/geriatric
---------------
qtp auto=$obj/geriatric.qtc
quiz auto=$obj/geriatric.qzc


*$cmd/backup_22to48_reports
---------------------------
- backs up a bunch of files

							*$cmd/copy_r124_mp_solo (already done drop 1)
							*$cmd/backup_portal_reports (already done drop 1) 
							*$cmd/backup_daily (already done drop 1)

*qtp auto=$obj/leenaclaims.qtc				(Moved to Drop 1)

							*$cmd/backup_subfile (already done above)
							*$cmd/backup_r124 (already done drop 1)

*************************************
*************************************
*************************************
6 - MOH Error Rejects  Procedures ***
*************************************
*************************************
*************************************


*$cmd/copy_error_files
----------------------
- copies a bunch of files

*$cmd/u021
---------
- - Very complex. Calls awk
- created a dynamic shell script at run time
- calls $cmd/u021.awk
- calls u021.tmp.com after awk script done

$cmd/u021.awk
-------------
- Generates a command sceript dynamically
- cobrun $obj/u021a 

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>New<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

*******************************************************************************************
********************************batch_disk_create_claims***********************************
*******************************************************************************************

*$cmd/batch_disk_create_claims 					(Already Done Drop 3)
------------------------------
+$cmd/disk_create_claims    > claims.ls

+$cmd/disk_create_claims    > claims.ls
---------------------------------------
+ $cmd/maintain_backup_copies_of_suspend_files
qtp auto=$obj/u708.qtc
qtp auto=$obj/newu706a.qtc
quiz auto=$obj/r709a.qzc
quiz auto=$obj/r709b.qzc


+ $cmd/maintain_backup_copies_of_suspend_files
----------------------------------------------
!!!(copies idx files around. Will need to rethink with RELATIONAL!!!


*******************************************************************************************
******************************batch_web_create_claims**************************************
*******************************************************************************************

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

*******************************************************************************************
******************************batch_web_create_claims**************************************
*******************************************************************************************

+*- $cmd/docrev				(Was Drop 5. Moved to Drop 3
---------------
- quiz auto=$obj/docrev.qzc		(Was Drop 5. Moved to Drop 3


*******************************************************************************************
******************************batch_web_create_claims**************************************
*******************************************************************************************

*cobrun $obj/r001						(Moved from Drop 4 to to Drop 3)
-----------------

*******************************************************************************************
********************************************run_dates**************************************
*******************************************************************************************

*$cmd/run_dates 							(Was in Drop 4. Moved to Drop 3)
---------------
quick auto=$obj/ohip_run_dates.qkc					(Was in Drop 4. Moved to Drop 3)
