===================================================================================
===================================================================================
===================================================================================
Costing
===================================================================================
===================================================================================
===================================================================================

*+$cmd/costing.com
------------------
- qtp exe $obj/costing1.qtc
- qtp exe $obj/costing2.qtc

- qutil create file doc-totals-tmp 
- qutil create file tmp-counters
- qutil create file tmp-counters-alpha

- qtp exe $obj/costing3.qtc
- qtp exe $obj/costing4.qtc
- qtp exe $obj/costing5.qtc
- qtp exe $obj/costing6.qtc		(source: costing6_man_rej_dtl.qts)
- qtp exe $obj/costing7.qtc

- quiz execute $obj/costing1.qzc
- quiz execute $obj/costing6a.qzc	(source; costing6a_man_rej_dtl.qzs)
- quiz execute $obj/costing10.qzc
- quiz execute $obj/costing11.qzc

*+$cmd/earnings_revenue_mp  								(Moved to Drop 1)
--------------------------
- qtp auto=$obj/earnings_mp.qtc		(source: earnings_revenue_mp.qts)		(Moved to Drop 1)


*earnings_revenue_mp_history.qts
-------------------------------
- qtp exec earnings_revenue_mp_history.qts

*r150_payeft_check.qzs 
----------------------
- quiz exe r150_payeft_check.qzs 

*solo_income_summary.qts
------------------------
- qtp exe solo_income_summary.qts


*+$cmd/r121_summary_reports.com
-------------------------------
+$cmd/r121_summary_reports 2014

$cmd/r121_summary_reports
-------------------------

- qtp execute $obj/r121_summ
201306
201312
201406
2014

- quiz execute $obj/r121a_summ
- quiz execute $obj/r121b_summ
- quiz execute $obj/r121c_summ
- quiz exec $obj/r121c_summ nogo
set rep dev disc name r121d_summ
set formfeed
sel if dept-company = 2
go
- quiz exec $obj/r121c_summ nogo
set rep dev disc name r121e_summ
set formfeed
sel if dept-company = 3
go
- quiz exec $obj/r121c_summ nogo
set rep dev disc name r121f_summ
set formfeed
sel if dept-company = 4
go


*+$cmd/doc_t4_detail
--------------------

- qtp exec $obj/r150a_detail	(mp version?)
201601
201606
201507
201513

- quiz use  $src/r150d_detail   (mp version?)



===================================================================================
===================================================================================
===================================================================================
New From Activity Sheet
===================================================================================
===================================================================================
===================================================================================

*+$cmd/activate_6pm_backup
------------------------

*+$cmd/backup_daily nv 						(Already done. Code Drop 1)
--------------------

*+$cmd/backup_daily_disk					(Already done. Code Drop 3)
----------------------

*+$cmd/batch_portal_reports
-------------------------
+ $cmd/portal_reports    > batch_portal_reports.log

+ $cmd/portal_reports    > batch_portal_reports.log
---------------------------------------------------
+$cmd/peds_billings
+$cmd/clinic26
+$cmd/dept54

qtp auto=$obj/emergency_urgent_clmhdrid_44.qtc
qtp auto=$obj/emergency_payroll_clmhdrid.qtc

## (emergency_payroll_clmhdrid.qzs for all 3)
quiz auto=$obj/emergency_payroll_clmhdrid_1.qzc   					(Inside emergency_payroll_clmhdrid.qzs)
quiz auto=$obj/emergency_payroll_clmhdrid_2.qzc						(Inside emergency_payroll_clmhdrid.qzs)
quiz auto=$obj/emergency_payroll_clmhdrid_3.qzc						(Inside emergency_payroll_clmhdrid.qzs)

qtp auto=$obj/yasclare.qtc                         ## run it december and yearend	
quiz auto=$obj/yasclare_1.qzc                      ## (yasclare.qzs for all 3)		(Inside yasclare.qzs)
quiz auto=$obj/yasclare_2.qzc								(Inside yasclare.qzs)
quiz auto=$obj/yasclare_3.qzc								(Inside yasclare.qzs)

qtp auto=$obj/g271_code.qtc
quiz auto=$obj/g271_code.qzc
qtp auto=$obj/dept4_average.qtc     
quiz auto=$obj/advout.qzc    

quiz auto=$obj/drchaudhary_rejects.qzc

+$cmd/peds_billings
-------------------
- qtp exec $obj/detail_peds_billings_ped.qtc
- quiz auto=$obj/f087_peds_rejects_by_errcode.qzc
= qtp auto=$obj/f088_peds_rejects.qtc

+$cmd/clinic26
--------------
- qtp Exec $obj/clinic26.qtc	(201704)

+$cmd/dept54
------------
- qtp Exec $obj/dept54_billings.qtc (201704)













*+qtp auto=$obj/f119histtithe.qtc				(Already done. Code Drop 1)
===============================

*qtp auto=$obj/costing_f119hist.qtc				(Moved to Drop 1)
----------------------------------

*quiz auto=$obj/costing_f119hist.qzc
-----------------------------------

*qtp auto=$obj/leenaclaims.qtc					(Already done. Code Drop 3)
------------------------------

*******************************************************************
*******************************************************************
*******************************************************************
ABOVE steps should have been completed with the 3rd monthend
*******************************************************************
*******************************************************************
*******************************************************************

*+$cmd/delay_6pm_backup						(Already done. Code Drop 3)
-----------------------

*+$cmd/auditdoc							(Already done. Code Drop 5)
---------------

*+$cmd/docrev							(Already done. Code Drop 5)
-------------

*$cmd/docrevall							(Already done. Code Drop 5)
---------------

*r001.cbl							(Already done. Code Drop 3)
----------

*+$cmd/kathyf001status						(Already done. Code Drop 3)
----------------------

*+$cmd/copy_f050_f051_f001_f002_to_foxtrot			(Already done. Code Drop 5)
------------------------------------------

*+$cmd/yearend_r011						(Already done. Code Drop 5)
-------------------

*+$cmd/doc_rev_cash_yearly_roll					(Already done. Code Drop 5)
-------------------------------

*+$cmd/yearend_r011						(Already done. Code Drop 5)
-------------------

*+$cmd/delete_f001_claims_batches				(Already done. Code Drop 5)
---------------------------------

*+$cmd/delete_f001_adj_pay_batches				(Already done. Code Drop 5)
--------------------------------

*+$cmd/purge_f084						(Already done. Code Drop 5)
-----------------

*+$cmd/purge_f087						(Already done. Code Drop 5)
-----------------

*+$cmd/purge_f088						(Already done. Code Drop 5)
-----------------

*+./createfiles.com						(Missing!)
-------------------

*quiz auto=checkf002_adj_sub_type.qzs				(Already done. Code Drop 5)

*qtp auto=createf073_costing.qts				(Already done. Code Drop 5)

*+$cmd/costing.com						(Already done. Code Drop 6)
------------------

*+$cmd/yearend_payroll_backups					(Already done. Code Drop 5)
------------------------------

*+$cmd/Yearend_payroll_purges					(Already done. Code Drop 5)
-----------------------------

*+$cmd/purge_f020_mp         (modify macro for new ep dates)	(Already done. Code Drop 5)
------------------------------------------------------------

*+$cmd/purge_f110_mp         (modify macro for new ep dates)	(Already done. Code Drop 5)
------------------------------------------------------------

+$cmd/purge_f112_mp         (modify macro for new ep dates)	(Already done. Code Drop 5)
-----------------------------------------------------------

*+$cmd/purge_f113_mp         (modify macro for new ep dates)	(Already done. Code Drop 5)
------------------------------------------------------------

*+$cmd/purge_f119_mp         (modify macro for new ep dates)	(Already done. Code Drop 5)
------------------------------------------------------------

*+$cmd/purge_f020_solo      (modify macro for new ep dates)	(Already done. Code Drop 5)
-----------------------------------------------------------

*+$cmd/purge_f110_solo      (modify macro for new ep dates)	(Already done. Code Drop 5)
-----------------------------------------------------------

*+$cmd/purge_f112_solo      (modify macro for new ep dates)	(Already done. Code Drop 5)
-----------------------------------------------------------

*+$cmd/purge_f113_solo     (modify macro for new ep dates)	(Already done. Code Drop 5)
----------------------------------------------------------

*+$cmd/purge_f119_solo     (modify macro for new ep dates)	(Already done. Code Drop 5)
----------------------------------------------------------

*+$cmd/purge_f020     (modify macro for new ep dates)		(Already done. Code Drop 5)
-----------------------------------------------------

*+$cmd/purge_f110     (modify macro for new ep dates)		(Already done. Code Drop 5)
-----------------------------------------------------

*+$cmd/purge_f112     (modify macro for new ep dates)		(Already done. Code Drop 5)
-----------------------------------------------------

*+$cmd/purge_f113     (modify macro for new ep dates)		(Already done. Code Drop 5)
-----------------------------------------------------

*+$cmd/purge_f119     (modify macro for new ep dates)		(Already done. Code Drop 5)
-----------------------------------------------------

*+$cmd/purge_f050      (modify macro for new ep dates)		(Already done. Code Drop 5)
------------------------------------------------------

*qtp auto=$obj/utl0018a.qtc					(Already done. Code Drop 5)

*qtp auto=$obj/utl0018b.qtc					(Already done. Code Drop 5)

*+$cmd/reset_adj_pay_batch_nbr					(Already done. Code Drop 5)
------------------------------

*+$cmd/utl0017.com    (Give r113.txt to Helena to check)	(Already done. Code Drop 5)
--------------------------------------------------------

*+$cmd/backup_daily						(Already done. Code Drop 1)
-------------------

*+$cmd/backup_charly_foxtrot_purge				(Already done. Code Drop 5)
----------------------------------

