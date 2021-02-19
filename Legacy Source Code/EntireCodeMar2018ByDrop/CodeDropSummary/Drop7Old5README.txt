===================================================================================
===================================================================================
===================================================================================
Claims Purge
===================================================================================
===================================================================================
===================================================================================

*$cmd/backup_daily						(Already Done - Drop1)

*+$cmd/claims_mstr_verify_old
-----------------------------
- cobrun $obj/r001						(Already Done - Drop4)
- qtp auto=$obj/u020_shdw.qtc > u020_shdw.log
- cobrun $obj/r071


*+$cmd/create_new_claims_mstr
-----------------------------
- +$cmd/claims_mstr_verify_old  				(Already Done Above)
- qtp exec $obj/u072.qtc	(20150630)
- quiz exec $obj/r072a_all.qzc  (inside r072_all.qzs)
- quiz exec $obj/r072b_all.qzc  (inside r072_all.qzs)
- quiz exec $obj/r072c_all.qzc  (inside r072_all.qzs)
- qtp exec $obj/u072_retain_1.qtc
- qtp exec $obj/u072_retain_2.qtc
- qtp exec $obj/u072_delete_1.qtc
- qtp exec $obj/u072_delete_2.qtc

- quiz quiz exec $obj/r072a.qzc (22)   	(inside r072.qzs)				(r072a, r072b, r072c, r072d, r072e run for every clinic (22 - 99)
- quiz exec $obj/r072b.qzc (22)  	(inside r072.qzs)
- quiz exec $obj/r072c.qzc		(inside r072.qzs)
- quiz exec $obj/r072d.qzc		(inside r072.qzs)
- quiz exec $obj/r072e.qzc		(inside r072.qzs)

- qutil create file f002-outstanding

- qtp auto=$obj/u072a.qtc
- cobrun $obj/r073 (20150630, Y)				
- quiz auto=$obj/unlof002extra.qzc
- quiz auto=$obj/unlof085.qzc
- qtp auto=$obj/relof002extra.qtc
- qtp auto=$obj/relof085.qtc
- quiz auto=$obj/unlof071.qzc 
- quiz auto=$obj/unlof099.qzc
- qutil create file f099-group-claim-mstr
- qtp auto=$obj/relof071.qtc 
- qtp auto=$obj/relof099.qtc


*+$cmd/claims_mstr_verify_new
-----------------------------
- cobrun $obj/r073 (20150630, Y)				(Already Done Above)				


*qtp auto=$obj/u920.qtc  >  u920.log  (4 hours to run)

*+$cmd/backup_charly_foxtrot_purge				(Alrerady done. Code Drop 5)
----------------------------------
(various Unix commands..cpio)

===================================================================================
===================================================================================
===================================================================================
Patient Purge
===================================================================================
===================================================================================
===================================================================================

*+$cmd/update_unprocessed_web_disk_patients
-------------------------------------------
- qtp   auto=$obj/u704a.qtc   >> u704a.log


*$cmd/run_patient_purge
-----------------------
- qtp exec  $obj/u099.qtc (20160101) > u099.log
- quiz auto=$obj/r099a	(inside r099.qzs)
- quiz auto=$obj/r099b	(inside r099.qzs)
- quiz auto=$obj/r099c	(inside r099.qzs)
- quiz auto=$obj/r099d	(inside r099.qzs)
- . ./createfiles.com						(Missing!)
- qtp exec     $obj/u080.qtc  >> u080.log
- quiz auto=$obj/r080.qzc >> r080.log
- quiz auto=$obj/utl0012.qzc  >> utl0012.log			(Missing!)



*+$cmd/purge_f011
-----------------
- qtp auto=$obj/purge_unlof011.qtc      1>>  purgef011.log 2>&1
- qutil  create file f011-pat-mstr-elig-history
- qtp auto=$obj/purge_relof011.qtc  1>>  purgef011.log  2>&1


*quiz auto=$obj/utl0012_a.qzc  (inside utl0012.qzs) 

*quiz auto=$obj/utl0012_b.qzc  (inside utl0012.qzs)

*qutil 	create file tmp-pat-mstr

*qtp auto=$src/utl0012b.qts 

*quiz auto=$src/utl0012c.qzs 

*qtp auto=$src/utl0012d.qts 



<<<<<<<<<<<<<NEW >>>>>>>>>>>>>



************************************
************************************
************************************
Patient purge activity sheet
************************************
************************************
************************************

*+$cmd/backup_daily nv						(Already Done)
--------------------

*+$cmd/update_unprocessed_web_disk_patients			(Already Done above)
-------------------------------------------

*+rma_cron_cancel						(Brad, what is this??)
-----------------

*+$cmd/run_patient_purge > patient_purge.log			(Already Done)
--------------------------------------------

*+$cmd/purge_f011						(Already Done)
-----------------

*+crontab  rma_cron						(Brad, what is this?)
-------------------

*+$cmd/backup_daily						(Already done)
-------------------

*- qutil		charly/purge	create file tmp-pat-mstr

*- qtp auto=$src/utl0012b.qts 			run this step only if utl0012.txt exists		(Already Done)

*- quiz auto=$src/utl0012c.qzs 			run this step only if utl0012.txt exists		(Already Done)

*- qtp auto=$src/utl0012d.qts 			run this step only if utl0012.txt exists		(Already Done)

*+$cmd/backup_charly_foxtrot_purge									(Already Done)
----------------------------------


************************************
************************************
************************************
Activity CLAIM purge 
************************************
************************************
************************************

*+$cmd/backup_daily nv	17J		before Purge							(Already Done)
----------------------------------------------------

crontab  rma_cron_cancel to cancel the auto jobs that will effect the purge				(Brad, what is this?)
------------------------

*+$cmd/create_new_claims_mstr > claims_purge.log	claims purge date 2016/06/30			(Already Done)
------------------------------------------------

*-qtp auto=$obj/u920.qtc > u920.log									(Already Done)

*+crontab  rma_cron											(Brad, what is this?)
-------------------

*+$cmd/backup_daily Backup_daily did not work - bad tape restarted as disk backup  "backup_daily_disk" at 1 am		(Already Done)
-------------------

*+$cmd/backup_daily_disk				saved in E:\aviion2017-afterclaimspurge		(Already Done Drop 3)
------------------------

*+$cmd/backup_charly_foxtrot_purge	17L	charly/purge						(Already Done)
----------------------------------
