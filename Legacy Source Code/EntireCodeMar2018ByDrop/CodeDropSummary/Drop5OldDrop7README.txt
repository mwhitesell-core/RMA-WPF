===================================================================================
===================================================================================
===================================================================================
COBOL
===================================================================================
===================================================================================
===================================================================================

- cobrun r040.cbl
- cobrun u040.cbl
- cobrun u041.cbl

*- quiz exec u041_dump_min_max.qzs

*- qtp exec u041_update_min_max.qts

*- quiz exec webomafee.qzs

+*- $cmd/checkf020diff
---------------------
- quiz exec checkf020a.qzc

*- mary_payeft.qzs 

+*- $cmd/auditdoc     
-----------------
- quiz auto=$obj/auditdoc1.qzc		(source: auditdoc.qzs)
- quiz auto=$obj/auditdoc2.qzc		(source: auditdoc.qzs) 

+*- $cmd/docrev				(Was Drop 4. Moved to Drop 3
---------------
- quiz auto=$obj/docrev.qzc		(Was Drop 4. Moved to Drop 3

+*- $cmd/docrevall 
------------------
- qtp auto=$obj/docrevall.qtc
- quiz auto=$obj/docrevall.qzc

+*- $cmd/copy_f050_f051_f001_f002_to_foxtrot
--------------------------------------------
- copies files to /foxtrot/purge/101c

+*- $cmd/yearend_r011
---------------------
+ -$cmd/yearendr011 1>yearendr011.ls 2>&1

+ -$cmd/yearendr011
-------------------
- cobrun $obj/r011 << R011_EXIT		(calls for all clinics)

- quiz exe $obj/r011a
- quiz exe $obj/r011b
- quiz exe $obj/r011c

- quiz exe $obj/r011a_70
- quiz exe exe $obj/r011b_70
- quiz exe exe $obj/r011c_70


+*- $cmd/doc_rev_cash_yearly_roll
---------------------------------
- qtp exe $obj/purge_f050_f051

+*- $cmd/delete_f001_claims_batches
-----------------------------------
- cobrun $obj/r001b						(Moved from Drop 5 to Drop 3)

- qtp exec $obj/u095.qtc (22000000, 22ZZZ999, 20160630)		(does these for every clinic)
- quiz exe $obj/r095a.qzc
- quiz exe $obj/r095b.qzc
- quiz exe $obj/r095c.qzc


+*- $cmd/delete_f001_adj_pay_batches
------------------------------------
- cobrun $obj/r071  2>&1 << R071_EXIT (20160630, Y)
- cobrun $obj/r001b						(Moved from Drop 5 to Drop 3)

- qtp exec $obj/u093.qtc (22000000, 22ZZZ999, 20160630)		(does next 5 for all clinics)
- qtp exec $obj/r093a.qzc
- qtp exec $obj/r093b.qzc
- qtp exec $obj/r093c.qzc
- qtp exec $obj/r093d.qzc

- cobrun $obj/r071  2>&1 << R071_EXIT

+*- $cmd/purge_f084
-------------------
- qtp auto=$obj/purge_unlof084.qtc << QTP_EXIT 1>> purgef084.log 2>&1		(20000101, 20141231)
- qutil create file f084-claims-inventory  
- qtp auto=$obj/purge_relof084.qtc  1>>  purgef084.log  2>&1
 
+*- $cmd/purge_f087
-------------------
- qtp auto=$obj/purge_unlof087.qtc << QTP_EXIT 1>>$pb_prod/purgef087.log 2>&1
- qutil create file f087-submitted-rejected-claims-hdr
- qutil create file f087-submitted-rejected-claims-dtl
- qtp auto=$obj/purge_relof087.qtc  1>>$pb_prod/purgef087.log  2>&1


+*- $cmd/purge_f088
-------------------
- qtp auto=$obj/purge_unlof088.qtc << QTP_EXIT 1>>$pb_prod/purgef088.log 2>&1
- qutil create file f088-rat-rejected-claims-hist-hdr
- qutil create file f088-rat-rejected-claims-hist-dtl
- qtp auto=$obj/purge_relof088.qtc  1>>$pb_prod/purgef088.log  2>&1


+*- $cmd/createfiles.com			(MISSING!!)
------------------------

*- checkf002_adj_sub_type.qzs
-----------------------------
- just quiz 

*- createf073_costing.qts
-------------------------
- just qtp

+*- $cmd/yearend_payroll_backups  (ran in solo/mp/101c)
-------------------------------------------------------
- just cp and cpio

+*- $cmd/Yearend_payroll_purges    (ran in solo/mp/101c)
--------------------------------------------------------
- qtp auto=$obj/yearend_1.qtc                    1>>$pb_prod/payrollpurge.log 2>&1			(mp and 101C?)

- qutil create file f110-compensation
- qutil create file f112-pycdceilings
- qutil create file f113-default-comp
- qutil create file f119-doctor-ytd
- qutil create file f198-user-defined-totals

- qtp auto=$obj/yearend_2.qtc                    1>>$pb_prod/payrollpurge.log 2>&1			(mp and 101C)	(ALREADY IN DROP 1?)
- quiz auto=$obj/r112_csv.qzc 			1>>$pb_prod/payrollpurge.log 2>&1					(ALREADY IN DROP 1?)
- qtp auto=$obj/purge_f113.qtc                   1>>$pb_prod/payrollpurge.log 2>&1					(ALREADY IN DROP 1?)
- quiz auto=$obj/r113.qzc				 1>>$pb_prod/payrollpurge.log 2>&1				(ALREADY IN DROP 1?)

- qutil create file f020-doctor-audit
- qutil create file f028-audit-file
- qutil create file f110-compensation-audit
- qutil create file f112-pycdceilings-audit
- qutil create file f119-doctor-ytd-audit


+*- $cmd/purge_f020           (same programs, diff scripts and log files)
-------------------------------------------------------------------------
- qtp auto=$obj/purge_unlof020_history.qtc << QTP_EXIT 1>>$pb_prod/purgef020.log 2>&1	(200801,200813)		(MP and 101C?)
- qutil create file f020-doc-mstr-history
- qtp auto=$obj/purge_relof020_history.qtc  1>>$pb_prod/purgef020.log  2>&1


+*- $cmd/purge_f020_mp    (same programs, diff scripts and log files)
---------------------------------------------------------------------
(same a purge_f020, but run against mp)

+*- $cmd/purge_f020_solo   (same programs, diff scripts and log files)
----------------------------------------------------------------------
(same a purge_f020, but run against solo)



+*- $cmd/purge_f110            (same programs, diff scripts and log files)
--------------------------------------------------------------------------
- qtp auto=$obj/purge_unlof110_history.qtc << QTP_EXIT 1>>$pb_prod/purgef110.log 2>&1	(200801,200813)		(MP and 101C?)
- qutil create file f110-compensation-history
- qtp auto=$obj/purge_relof110_history.qtc  1>>$pb_prod/purgef110.log  2>&1

+*- $cmd/purge_f110_mp    (same programs, diff scripts and log files)
---------------------------------------------------------------------
(same as purge_f110, but run against mp)

+*- $cmd/purge_f110_solo   (same programs, diff scripts and log files)
----------------------------------------------------------------------
(same as purge_f110, but run against solo)



+*- $cmd/purge_f112            (same programs, diff scripts and log files)
--------------------------------------------------------------------------
- qtp auto=$obj/purge_unlof112_history.qtc << QTP_EXIT 1>>$pb_prod/purgef112.log 2>&1	(200801,200813)		(MP and 101C?)
- qutil create file f112-pycdceilings-history
- qtp auto=$obj/purge_relof112_history.qtc  1>>$pb_prod/purgef112.log  2>&1

+*- $cmd/purge_f112_mp    (same programs, diff scripts and log files)
---------------------------------------------------------------------
(same as purge_f112, but run against mp)

+*- $cmd/purge_f112_solo   (same programs, diff scripts and log files)
----------------------------------------------------------------------
(same as purge_f112, but run against solo)



+*- $cmd/purge_f113            (same programs, diff scripts and log files)
--------------------------------------------------------------------------
- qtp auto=$obj/purge_unlof113_history.qtc << QTP_EXIT 1>>$pb_prod/purgef113.log 2>&1	(2008, 2008)		(MP and 101C?)
- qutil create file f113-default-comp-history
- qtp auto=$obj/purge_relof113_history.qtc  1>>$pb_prod/purgef113.log  2>&1

+*- $cmd/purge_f113_mp    (same programs, diff scripts and log files)
---------------------------------------------------------------------
(same as purge_f113_mp, but run against mp)

+*- $cmd/purge_f113_solo   (same programs, diff scripts and log files)
----------------------------------------------------------------------
(same as purge_f113_mp, but run against solo)



+*- $cmd/purge_f119            (same programs, diff scripts and log files)
--------------------------------------------------------------------------
- qtp auto=$obj/purge_unlof119_history.qtc << QTP_EXIT 1>>$pb_prod/purgef119.log 2>&1	(200801,200813)		(MP and 101C?)
- qutil create file f119-doctor-ytd-history
- qtp auto=$obj/purge_relof119_history.qtc  1>>$pb_prod/purgef119.log  2>&1

+*- $cmd/purge_f119_mp    (same programs, diff scripts and log files)
---------------------------------------------------------------------
(same as purge_f119, but run against mp)

+*- $cmd/purge_f119_solo   (same programs, diff scripts and log files)
----------------------------------------------------------------------
(same as purge_f119, but run against solo)



+*- $cmd/purge_f050
-------------------
- qtp auto=$obj/purge_unlof050_history.qtc << QTP_EXIT 1>>$pb_prod/purgef050.log 2>&1	(2008, 2008, 2008, 2008)
- qutil create file f050-doc-revenue-mstr-history
- qutil create file f050tp-doc-revenue-mstr-history
- qtp auto=$obj/purge_relof050_history.qtc  1>>$pb_prod/purgef050.log  2>&1


*- qtp exec utl0018a.qts

*- qtp exec utl0018b.qts

*- $cmd/reset_adj_pay_batch_nbr
-------------------------------
- qtp auto=$obj/u090.qtc       > u090.log				(ALREADY DONE IN DROP 1?) 

*- $cmd/utl0017.com
-------------------
- qtp  auto=$obj/utl0017.qtc  >> utl0017.log

*- checkf020_active_doc.qzs

*- $cmd/backup_charly_foxtrot_purge
-----------------------------------
(cpio and cp commands)