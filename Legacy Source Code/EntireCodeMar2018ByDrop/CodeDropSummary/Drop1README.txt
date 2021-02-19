
========================================================
PROGRAM BREAKDOWN / RELATIONSHIP / OUTPUTS LIST - DROP 1
========================================================

Agenda:

1A. SOLO
2B. MP
3C. 101C

* means a command captured from a word document of Excel file.
+ means a command script which is further documented below.
-> Means an output which can be a subfile or disc file or the console
<- Means a subfile input created OUTSIDE of the program (i,e a QTP, abnother Quiz)

******************************************************************************
******************************************************************************
******************************************************************************
1A. SOLO **
******************************************************************************
******************************************************************************
******************************************************************************

*****************************************
*****************************************
*****************************************
+-$cmd/verify_solo_payroll_ok_to_run
&"$env:cmd/verify_solo_payroll_ok_to_run" > solo_verify.log

*****************************************
*****************************************
*****************************************
- Calls a bunch of rm commands to remove data files
- qtp auto=$obj/u100.qtc
	-> p1. subfile u100_blank_paym_grp keep include			&
	-> p2. subfile u100_blank_f112_rec keep at docrev-doc-nbr include		&

+- quiz auto=$obj/u100.qzu
+- quiz use  $src/u100_b.qzs
	-> set subfile name u100_b keep
	-> access *u100_b
	<- access *u100_b
	-> set subfile name u100_b2 keep at doc-ohip-nbr
	<- access *u100_b2
	-> set subfile name u100_b_3a keep
	<- access *u100_b2
	-> set subfile name u100_b_3b keep
	-> access *u100_b_3a link doc-ohip-nbr to doc-ohip-nbr of f020-doctor-mstr	&
	-> set subfile name u100_b_3b append
	-> access *u100_b_3b
	-> set rep dev disc name u100_b
	

+- quiz use  $src/u100_c.qzs


---------------------------
+- quiz auto=$obj/u100.qzu
--------------------------
- exe $obj/u100_b	-> Write to Console
	<- access *u100_blank_paym_grp                                    
	-> set rep dev disc name u100
- exe $obj/u100_c	-> Write to Console
	<- access *u100_blank_f112_rec                                    
	-> set rep dev disc name u100
- exe $obj/u100_d	-> Write to Console
	-> set rep dev disc name u100
- exe $obj/u100_e	-> Write to Console
	-> set rep dev disc name u100
- exe $obj/u100_f	-> Write to Console
	-> set rep dev disc name u100


---------------------------
quiz use  $src/u100_b.qzs (p=pass)
-------------------------
- Multiple subfiles created
-> p1. set subfile name u100_b keep
-> p2. set subfile name u100_b2 keep at doc-ohip-nbr
-> p3. set subfile name u100_b_3a keep
-> p4. set subfile name u100_b_3b keep
-> p5. set subfile name u100_b_3b append
-> p6. set rep dev disc name u100_b


---------------------------
+- quiz use  $src/u100_c.qzs
----------------------------
-> p1. set rep dev disc name u100_c 


**************************************************
$cmd/backup_earnings_daily_disk YYYYMM
**************************************************
- Copies files to a backup directory.
- Will need to build a solution. 


*****************************************
*****************************************
*****************************************
+-$cmd/batch_teb_11
&"$env:cmd/batch_teb_11"
*****************************************
*****************************************
*****************************************
- Medium
+- $cmd/teb1 201611 201601
+- $cmd/teb2 201611 201601 1>>teb_11.log 2>&1
- qtp auto=$obj/u090f.qtc 1>>teb_11.log 2>&1
+- $cmd/teb3 201611 201601 1>>teb_11b.log 2>&1


--------------------------
--------------------------
--------------------------
+- $cmd/teb1 201611 201601
--------------------------
--------------------------
--------------------------

- qtp use $src/fix_seq_nbrs nolist
	-> p1. output f119-doctor-ytd update
	-> p2. f110-compensation update
- qtp execute $obj/u105
	-> p1. output f119-doctor-ytd update
	-> p2. output f119-doctor-ytd update
	-> p3. subfile savef119 keep append include f119-doctor-ytd, rundate, runtime
	-> p3. output f119-doctor-ytd update on errors report
- qtp execute $obj/u110_1
	-> p1.p9..load global variabl;es
	-> p10. subfile u110 alias u110_misc0   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc1   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc2   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc3   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc4   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc5   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc6   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc7   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc8   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misc9   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micv   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micm   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misj   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_misp   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mohr   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micb   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mibr   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_minh   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mhsc   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_dhsc   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_agep   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mica   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micc   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micd   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mice   append  at docrev-doc-nbr            &
- qtp execute $obj/u110_2
	-> p1.p9..load global variabl;es
	-> p10. subfile u110 alias u110_micf   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micg   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mich   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micj   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mick   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_micl   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mohd   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_macc   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mibd   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mpap   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mslp   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mmdu   append  at docrev-doc-nbr            &
	-> p10. subfile u110 alias u110_mbrt   append  at docrev-doc-nbr            &
- qtp execute $obj/u110b_rma
	-> p2. subfile u110_audit      keep  append                      	&
	-> p2. subfile u110_audit_doc keep  append at docrevtp-doc-nbr 	&
	-> p2. subfile u110             keep  append at docrevtp-doc-nbr	&
- quiz execute $obj/u111a
	<- access *u110
	-> set subfile name u111_sorted keep at comp-code
- quiz execute $obj/r111b
	<- access *u110
	-> set rep dev disc name r111b
- qtp execute $obj/u113
	-> output f110-compensation add alias f110-default			       &
- qtp execute $obj/u111c
	<- access *u111_sorted                                                   &
	-> output f110-compensation add alias f110-add                          &
	-> output f110-compensation update alias f110-update                   &
- qtp execute $obj/u130
	-> p1. output f110-compensation add alias f110-add                   &
	-> p1. output f110-compensation update alias f110-update       &
	-> p1. subfile $pb_data/u130_audit keep include &
	-> p1. output f114-special-payments alias f114-delete delete	&
	-> p2. output f119-doctor-ytd  add alias f119-add                   &
	-> p2. output f119-doctor-ytd   update alias f119-update       &
	-> p2. subfile $pb_data/u130_audit_f119 keep include &
	-> p2. output f114-special-payments alias f114-delete delete	&

--****************************************
--****************************************
-- ONLY CALLED IF $CLINIC_NBR = 22 (101C0). 
-- To Test in 101C 

- qtp execute $obj/u131a
	-> subfile u131a keep include		&		
	
--****************************************
--****************************************

- qtp execute $obj/u112
	-> output f112-pycdceilings add alias f112-output if not record f112-current-ep exists
- qtp execute $obj/u114a
	-> subfile debugu114 keep include                                        &
	-> subfile debugu114-2 keep include                                        &
	-> output f110-compensation alias f110-ceiear add          &
	-> output f110-compensation alias f110-ceiexp add          &
	-> output f110-compensation alias f110-adjcea add                   &
- qtp execute $obj/u114b
	-> access *debugu114					&
	-> output f020-doctor-mstr alias f020-update  update
	-> output f020-doctor-extra update if record f020-doctor-extra exists


---------------------------------------------
+- $cmd/teb2 201611 201601 1>>teb_11.log 2>&1
---------------------------------------------
- qtp execute $obj/u115a_0
	- use $src/u115_common_f119.qts 
	- use $src/u115_debug_f119.qts
		-> subfile debugu115a0_at_comp_code keep include &
		-> subfile debugu115a0_at_doc_nbr keep at doc-nbr include &
	-> subfile f119_tithe_dtl  keep 	                  &
	-> subfile f119_tithe_dtl alias f119_doc_summ  append    &
	-> subfile f119_tithe_dtl  alias f119-totit-doc append     at doc-nbr      &
	-v subfile f119_tithe_dtl  alias f119-totit-summ   append     at doc-nbr      &
- qtp execute $obj/u115a_1
	-> p1. subfile debugu115a_1_at_comp_code keep include &
	-> p1. subfile debugu115a_1_at_doc_nbr keep at doc-nbr include &
	-> p1. subfile f119_tithe_dtl  append                  &
	-> p1. subfile f119_tithe_dtl alias f119_doc_summ  append    &
	-> p1. subfile f110_tithe_dtl  keep                      &
	-> p1. subfile f119_tithe_dtl  alias f119-totit-doc append     at doc-nbr      &
	<- p2. access *f119_tithe_dtl
	-> p1. subfile f119_tithe_dtl  alias f119-totit-summ   append     at doc-nbr      &
	-> p2. subfile f119_tithe_one_comp_code_per_doc_nbr keep at comp-code include  &
	<- p3. access *f110_tithe_dtl
	-> p3. output f119-doctor-ytd update add		&
- qtp execute $obj/u122b
	<- access *f119_tithe_one_comp_code_per_doc_nbr		&
	-> p3. subfile brad keep                               &
	-> p3. output f119-doctor-ytd update if 1=1 and record f119-doctor-ytd exists on errors report   
	-> p3. output f119-doctor-ytd alias f119-add add if 1=1 and not record f119-doctor-ytd exists on errors report
	<- p4. access *f119_tithe_one_comp_code_per_doc_nbr            &
	-> p4. subfile u122b_prim_doc_temp keep at doc-ohip-nbr include     	&
	<- access *u122b_prim_doc_temp               &
	-> p5. subfile u122b_prim_doc keep  if doc-date-fac-term = 0	&
	<- p6. access *u122b_prim_doc 						&
	-> p6. subfile brad_tithe1 keep include &
	-> p6. subfile brad_tithe2 keep include &
	-> p6. subfile brad_tithe3 keep include &
	-> p6. subfile f119_tithe_1_2_3_trans  keep   	          &
	-> p6. subfile f119_tithe_1_2_3_trans alias f119tithe2        append  &
	-> p6. subfile f119_tithe_1_2_3_trans alias f119tithe3        append  &
	-> p6. output f110-compensation alias f110-totite-add add   &
	-> p6. output f110-compensation alias f110-tithe1-add add  & 
	-> p6. output f110-compensation alias f110-tithe2-add add   &
	-> p6. output f110-compensation alias f110-tithe3-add add   &
	-> p6. output f119-tithe1 update                               &
	-> p6. output f119-doctor-ytd   alias f119-tithe1-add add    &
	-> p6. output f119-tithe2 update                               &
	-> p6. output f119-doctor-ytd   alias f119-tithe2-add add    &
	-> p6. output f119-tithe3 update                               &
	-> p6. output f119-doctor-ytd   alias f119-tithe3-add add    &
	<- p7. access *f119_tithe_one_comp_code_per_doc_nbr			&
	-> p7. subfile brad2 keep                             include 			&
	-> p7. output f119-totite    update                               &
	-> p7. output f119-doctor-ytd   alias f119-totite-add add    &
- qtp execute $obj/u115a
	-> p3. subfile f119 alias f119-totinc   append     at doc-nbr      &
	-> p3. subfile f119 alias f119-depexr   append     at doc-nbr    &
	-> p3. subfile f119 alias f119-depexm   append     at doc-nbr    &
	-> p3. subfile f119 alias f119-totexp   append     at doc-nbr         &
	-> p3. subfile f119 alias u115-incexp   append     at doc-nbr         &
	-> p3. subfile f119 alias f119-ytdear   append     at doc-nbr          &
	-> p3. subfile brad1 keep  include 	&
	- use u115_debug
		-> subfile debugu115a_at_comp_code keep include &
		-> subfile debugu115a_at_doc_nbr keep at doc-nbr include &
- qtp execute $obj/u115b
	-> p3. subfile bradu115b keep at comp-code include &
	-> p3. output f110-compensation add alias f110-income at doc-nbr
	-> p3. output f110-compensation add alias f110-ep-tot-income at doc-nbr
	-> p3. output f110-compensation add alias f110-rmaexr at doc-nbr
	-> p3. output f110-compensation add alias f110-rmaex
	-> p3. output f110-compensation add alias f110-gst at doc-nbr
	-> p3. output f110-compensation add alias f110-holdback at doc-nbr          &
	-> p3. output f110-compensation add alias f110-depexr at doc-nbr       &
	-> p3. output f110-compensation add alias f110-depexm at doc-nbr       &
	-> p3. output f110-compensation add alias f110-ep-tot-expense at doc-nbr
	-> p3. output f110-compensation add alias f110-ep-incexp      at doc-nbr
	-> p3. output f110-compensation add alias f110-ceiear  at doc-nbr
	-> p3. output f110-compensation add alias f110-ceiexp  at doc-nbr   ;  &
	-> p3. output f110-compensation add alias f110-ytdear  at doc-nbr
	-> p3. output f020-doctor-mstr update if record f020-doctor-mstr exists at doc-nbr
	-> p3. use $src/u115b_debug.qts
		-> subfile debugu115b_at_comp_code keep include 		&
		-> subfile debugu115b_at_doc_nbr keep at doc-nbr include &
- qtp execute $obj/u115c
	-> p3. subfile f119 alias f119-increq   append                     &
	-> p3. subfile f119 alias f119-inctar   append                   &
	-> p3. output f110-compensation add alias f110-increq if amt-increq <> 0
	-v p3. output f110-compensation add alias f110-inctar if amt-inctar <> 0
- qtp execute $obj/u116
	+- use $use/u116_paycode0.use    nol
		-> output f020-doctor-mstr update
		-> output f110-compensation add alias f110-output-paypot
		-> subfile f119 append                                   include &
	+- use $use/u116_paycode1.use    nol
		-> subfile debugu116cd1 keep include                                     &
		-> output f110-gtype  update                               &
		-> output f110-compensation  add  alias f110-add-gtype                   &
		-> output f110-compensation  add  alias f110-paypot-add
		-> output f110-compensation add alias f110-output-underage          ;    &
		-> output f020-doctor-mstr alias f020-update update at doc-nbr
		-> subfile f119 alias f119-gtype append       at doc-nbr           &
		-> subfile f119 append                        at doc-nbr include &
		-> subfile f119 alias f119-under append       at doc-nbr include &
	+- use $use/u116_paycode2.use     ;nol
		-> subfile debugu116cd2 keep include                         &
		-> output f110-compensation add alias f110-output-paypot
		-> output f020-doctor-mstr alias f020-update update ; AT DOC-NBR
		-> subfile f119 append                                   include &
	+- use $use/u116_paycode346.use    ;nol
		-> output f110-compensation add alias f110-output-paypot
		-> output f110-compensation add alias f110-output-underage         &
		-> output f110-gtype  update                               &
		-> output f110-compensation  add  alias f110-add-gtype     &
		-> subfile debugu116cd346 keep include                                    &
		-> output f020-doctor-mstr alias f020-update update ; AT DOC-NBR
		-> subfile f119 append                                   include &
		-> subfile f119 alias f119-under append                  include &
		-> subfile f119 alias f119-gtype append                            &
	+- use $use/u116_paycode5.use     ;nol
		-> subfile debugu116cd5 keep include                                     &
		-> output f110-compensation add alias f110-output-paypot
		-> output f020-doctor-mstr alias f020-update update ; AT DOC-NBR
		-> subfile f119 append                                   include &
- qtp execute $obj/u117
	-> p2. subfile u117_audit keep                                     include &
	-> p3. output f110-compensation alias f110-update-deduc-transaction update &
	-> p3. subfile f119 keep append                                   include &
- qtp execute $obj/u118
	-> p3. output f110-compensation add alias f110-ep-tot-deduct at doc-nbr      &
	-> p3. output f110-compensation add alias f110-totadv at doc-nbr      &
	-> p3. subfile f119 alias f119-totded append     at doc-nbr  &
	-> p3. subfile f119 alias f119-totadv append   at doc-nbr    &
	-v p3. output f020-doctor-mstr update
- qtp execute $obj/u119
	-> p3. subfile debugu119 keep                              include &
	-> p3. subfile f119 keep append                                   include &
	-> p3. subfile f119 alias f119-advout append     &
	-> p3. subfile u119_payeft portable keep               &
	-> p3. output f020-doctor-mstr update
	-> p3. subfile u119_f110 keep                  &
	-> p3. subfile u119_f110 alias u110_f110_advout keep	&
	-> p3. subfile u119_f110 alias u110_f110_defic  keep	&
- qtp execute $obj/u119b
	<- access *u119_f110
	-> output f110-compensation add on errors report
- qtp execute $obj/u121
	-> p3. output f020-doctor-mstr alias f020-update  update
	-> p3. subfile debugu121 keep include       &
	-> p4. output f020-doctor-extra alias f020-update  update
- qtp execute $obj/u122
	<- access *f119                                     &
	-> p3. output f119-doctor-ytd                   update                 &
	-> p3. output f119-doctor-ytd  alias f119-add  add                     &
- qtp auto=$obj/u122_paycode7.qtc
	-> p2. subfile u122_paycode7_payeft keep     include &
	-> p2. subfile u119_chgeft portable keep          &
	-> p2. output f020-doctor-mstr update  on errors report
	-> p2. output f119-payeft                       update                 &
	-> p2. output f119-doctor-ytd  alias f119-add  add                     &

- qtp use $src/utl0100.qts
	-v subfile f119_duplicates keep   				&
	-> output f119-doctor-ytd	delete 	&

- quiz auto=$obj/utl0101.qzc
	<- access *f119_duplicates
	-> set rep dev disc name utl0101

- $cmd/r123 (COBOL)
	-> Cobol r123 runs

- quiz auto=$obj/r123d1.qzc
	<- access *u119_payeft			       			&
	-> set rep dev disc name r123d1
- quiz auto=$obj/r123d1a.qzc
	<- access *u119_payeft			       			&
	-> set rep dev disc name r123d1a

+- $cmd/generate_r120 $1

- quiz auto=$obj/r124a_mp.qzc
	-> set subfile name r124a keep
- quiz auto=$obj/r124a.qzc
	-> set subfile name r124a keep

- quiz << QUIZ_EXIT
- ;  MC7  execute $obj/r124b_rma		
- execute $obj/r124b_rma nogo
	<- access *r124a                                                   &
	-> set report dev disc name r124b
- and sel if doc-dept <> 80			
- go

- quiz execute $obj/r124b_rma
	<- access *r124a                                                   &
	-> set report dev disc name r124b
- quiz execute $obj/r124b_rma
	-> set report dev disc name r124b	

- quiz << QUIZ_EXIT
- ; MC7 execute $obj/r124b_mp
	- execute $obj/r124b_mp nogo
	<- access *r124a                                                   &
	-> set report dev disc name r124b
- and select if       x-new-parm = "DOC"  &	
-                 and doc-dept <>  80       
- go

- execute $obj/r124b_mp
	-> set report dev disc name r124b

- quiz execute $obj/r124b_mp
	-> set report dev disc name r124b

- quiz execute $obj/r124b_mp nogo 
	- and sel if x-new-parm = 'DOC' and doc-dept = 31	
	-> set rep dev disc name r124b_mp_31			<< disc file name
	- go

- qtp execute $obj/u126
	-> p3. output f198-user-defined-totals alias f198-output-add-rec-1 add	&
	-> p3. output f198-user-defined-totals alias f198-output-add-rec-2 add	&
	-> p4. output f198-user-defined-totals   alias f198-output-update-rec-1  update
	-> p5. output f198-user-defined-totals   alias f198-output-update-rec-2  update

- qtp execute $obj/u127
	-> p1. output f020-doc-mstr-history alias f020-add add      		&
	-> p2. output f119-doctor-ytd-history          add on errors report

- quiz execute $obj/r125
	-> set rep device disc name r125

- quiz execute $obj/debugu114
	<- access *debugu114
	-> set report dev disc name debugu114

- quiz execute $obj/debugu116cd1 (build within debugu116.qzs)
	-> p1. set report dev disc name debugu116cd1
- quiz execute $obj/debugu116cd2 (build within debugu116.qzs)
	-> p2. set report dev disc name debugu116cd2	
- quiz execute $obj/debugu116cd34 (build within debugu116.qzs)
	<- access *debugu116cd1	
	-> p3. set report dev disc name debugu116cd34

- quiz execute $obj/dumpf119
	<- access *f119
	-> set rep dev disc name dumpf119

- quiz execute $obj/dumpf119ytd
	-> set rep dev disc name dumpf119ytd

- quiz execute $obj/r124a_paycode7
	-> set subfile name r124a_paycode7 keep
- quiz execute $obj/r124b_paycode7
	<- access *r124a_paycode7						&
	-> set report dev disc name r124b_paycode7

+- quiz use $obj/r124c.qzu

- quiz execute $obj/r124b_paycode7
	<- access *r124a_paycode7						&
	-> set report dev disc name r124b_paycode7

+$cmd/r153

- quiz auto=$obj/payeft.qzc
	-> set rep dev disc name payeft

- quiz auto=$obj/paycode1A_ceilings.qzc
	-> set rep dev disc name paycode1A_ceilings 

+- quiz auto=$obj/r137.qzu

- quiz auto=$obj/r124a_xls.qzc
	-> set subfile name r124a_xls keep
- quiz auto=$obj/r124b_xls.qzc
	<- access *r124a_xls                                               &
	-> set report dev disc name r124b_csv

- quiz auto=$obj/r127.qzc
	-> set report dev disc name r127

-------------------
- $cmd/r123 (COBOL)
-------------------
- cobrun r123a

---------------------------
+- $cmd/generate_r120 $1
---------------------------
- qtp execute $obj/r120
	-> p1. output  f190-comp-codes						&
	-> p1. output  f020-doctor-mstr 					&
	-> p1. output  constants-mstr-rec-6					&
	-> p1. subfile r120aa							&
	<- p2. access *r120aa
	-> p2. subfile r120aa alias dept append					&
	<- p3. access *r120aa
	-> p3. subfile r120aa alias full-part append				&
	<- p4. access *r120aa
	-> p4. subfile r120aa	alias grand_f_p append				&
	<- p5. access *r120aa
	-> p5. subfile r120aa	alias grand append				&

- quiz execute $obj/r120
	<- access *r120aa
	-> set report dev disc name r120

- quiz execute $obj/r119a
	-> set report dev disc name r119a

- quiz execute $obj/r119b
	-> set report dev disc name r119b

- quiz execute $obj/r119c
	-> set report dev disc name r119c

- quiz execute $obj/r121a
	-> set report dev disc name r121a

- quiz execute $obj/r121b
	-> set report dev disc name r121b

- quiz execute $obj/r121b_company
	-> set report dev disc name r121b_company

- quiz execute $obj/r121c
	-> set report dev disc name r121c

- QUIZ
- quiz exec $obj/r121c nogo
	-> set rep dev disc name r121d				<<=======
	- set formfeed
	- sel if dept-company = 2				
	- go
- exec $obj/r121c nogo
	-> set rep dev disc name r121e				<<======= 
	- set formfeed
	- sel if dept-company = 3				
	- go
- exec $obj/r121c nogo		
	-> set rep dev disc name r121f				<<=======
	- set formfeed
	- sel if dept-company = 4				
	- go

--------------------------
+- quiz use $obj/r124c.qzu
--------------------------
-> set rep device disc name r124c
-> build $obj/r124c_1 				
	<- access *u116_paycode_7_a				&
-> build $obj/r124c_2
	<- access *u116_paycode_7_b				&
-> build $obj/r124c_3
	<- access *debugu116cd7					&
-> build $obj/r124c_4

----------
+$cmd/r153
----------
cobrun $obj/r153a

--------------------------
+- quiz auto=$obj/r137.qzu
--------------------------
-> set report dev disc name r137a
-> build $obj/r137a				
	-> set report dev disc name r137a
-> build $obj/r137b
	-> set report dev disc name r137b


----------------------------------------------
----------------------------------------------
----------------------------------------------
+- $cmd/teb3 201611 201601 1>>teb_11b.log 2>&1
----------------------------------------------
----------------------------------------------
----------------------------------------------
- qtp execute $obj/utl0201_f119 (for 101c)
	-> subfile utl0201_f119 portable keep include	&

- qtp execute $obj/utl0201_f119 (for MP)
	-> subfile utl0201_f119 portable keep include	&
- qtp execute $obj/utl0201_f119 (for Solo)
	-> subfile utl0201_f119 portable keep include	&

+- quiz auto=$obj/utl0201.qzu

qutil  create file tmp-counters-alpha

qtp auto=$obj/r128a.qtc
	-> p2. subfile r128a            keep at doc-nbr include	&
	<- p3. access *r128a          		
	-> p3. subfile r128a_inactive   keep  		include	&
	-> p4. output tmp-counters-alpha add at doc-nbr on errors report
	-> p4. subfile r128a_claim_doc keep at doc-nbr	&
	<- p5. access *r128a_inactive 			&
	-> p5. subfile r128a_inactive_doc_with_clm keep 	&

quiz auto=$obj/r128b.qzc 
	<- access *r128a_inactive_doc_with_clm
	-> set report dev disc name r128

quiz auto=$obj/r128b_csv.qzc 
	<- access *r128a_inactive_doc_with_clm			&
	-> set report dev disc name r128_csv

qtp  auto=$obj/r138_csv.qtc 
	-> p1. subfile r138_csv keep include		&
	-> p2. subfile r138_csv append include		&
	<- p3. access *r138_csv      
	-> p3. subfile r138_csv_doc keep at doc-nbr include		&

quiz auto=$obj/r138_csv.qzc 
	<- access *r138_csv_doc
	-> set rep device disc name r138_csv

qtp  auto=$obj/r139_csv.qtc  
	-> subfile r139_csv keep at doc-nbr include	&

quiz auto=$obj/r139_csv.qzc 
	<- access *r139_csv  
	-> set rep device disc name r139_csv
	

$cmd/utl0020.com				


-----------------------------
+- quiz auto=$obj/utl0201.qzu
-----------------------------
- quiz exec $obj/utl0201_1
	<- access *utl0201_f119				&
	-> set subfile name utl0201 keep

- quiz exec $obj/utl0201_2
	<- access *utl0201
	-> set rep dev disc name utl0201_a

- quiz exec $obj/utl0201_3
	<- access *utl0201     					&
	-> set rep dev disc name utl0201_b


***************************
***************************
***************************
Payroll Purges Procedures
***************************
***************************
***************************

---------------------------------------
+- $cmd/bckup_earnings_daily_disk YYYMM
---------------------------------------
- copies files from disk to a new directory.
- Needs to look at this more

------------------------------
+- $cmd/yearend_payroll_purges
------------------------------

- echo "--- create files ---"
- qutil << QUTIL_EXIT
- create file f110-compensation
- create file f112-pycdceilings
- create file f113-default-comp
- create file f119-doctor-ytd
- create file f198-user-defined-totals
- ;##create file f020-doctor-extra
- QUTIL_EXIT

- qtp auto=$obj/yearend_2.qtc                    1>>$pb_prod/payrollpurge.log 2>&1
	<- p1. access *f113_yearend_old
	-> p1. output f113-default-comp-history	add				&
	<- p2. access *f113_yearend_new
	-> p2. output f113-default-comp	add				&
	<- p3. access *f112_yearend_old
	-> p3. output f112-pycdceilings-history	add				&
	<- p4. access *f112_yearend_new
	-> p4. output f112-pycdceilings	add				&
	-> p5. output f020-doctor-extra update on errors report 
	
- quiz auto=$obj/r112_csv.qzc 			1>>$pb_prod/payrollpurge.log 2>&1
	-> set rep dev disc name r112_csv

- qtp auto=$obj/purge_f113.qtc                   1>>$pb_prod/payrollpurge.log 2>&1
	-> output f113-default-comp delete	

- quiz auto=$obj/r113.qzc				 1>>$pb_prod/payrollpurge.log 2>&1
	-> set rep dev disc name r113

echo "--- create files ---"
qutil << QUTIL_EXIT
create file f020-doctor-audit
create file f028-audit-file
create file f110-compensation-audit
create file f112-pycdceilings-audit
create file f119-doctor-ytd-audit
QUTIL_EXIT
 

----------------------------
+- $cmd/backup_earnings_solo
----------------------------
- All Unit commands.


***************************
***************************
***************************
Payroll Purges Procedures
***************************
***************************
***************************

$cmd/reload_earnings_daily


******************************************************************************
******************************************************************************
******************************************************************************
2B. MP **
******************************************************************************
******************************************************************************
******************************************************************************

<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< NEW STEPS >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

- qtp leena_claims.qts

- qtp costing_f119hist.qts

- quiz r126.qzs

*+$cmd/mp_earnings.sh
---------------------
- qtp auto=$obj/earnings_mp.qtc

*+$cmd/mp_payments.sh
---------------------
- quiz auto=$obj/mp_payments.qzc

*+$cmd/backup_earnings_mp.sh
----------------------------
- Multiple CPIO's and cat's

*+$cmd/rename_copy_r124.sh
--------------------------
- Multiple mv and cp's

*+$cmd/rename_copy_r124_solo.sh
-------------------------------
- Multiple mv and cp's

*+$cmd/solo_tithe.sh
--------------------
- qtp auto=$obj/solotithe.qtc

*+$cmd/chg_dump.sh
------------------
- awk -f $cmd/pad_to_1464_bytes.awk
- awk -f           $cmd/fix_eft.awk