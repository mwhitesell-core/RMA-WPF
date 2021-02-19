afp_f119hist.qts:;doc     : afp_f119hist
afp_f119hist.qts:access f119-doctor-ytd-history                        &

afp_f119hist_surplu.qts:;doc     : afp_f119hist
afp_f119hist_surplu.qts:access f119-doctor-ytd-history                        &

afp_payments.qzs:access f119-doctor-ytd-history       &
afp_payments.qzs:  tab  1 "maryf119"                                             &

checkf119.qts:access f119-doctor-ytd                             &
checkf119.qts:build $obj/checkf119   

checkf119_totinc.qzs:access f119-doctor-ytd
checkf119_totinc.qzs:set subfile name savef119_totinc keep

d020a.qks:;				   f119-doctor-ytd
d020a.qks:file f119-doctor-ytd      designer
d020a.qks:	get f119-doctor-ytd optional via doc-nbr, comp-code   &

d112.qks:file f119-doctor-ytd      designer
d112.qks:;  (If expense has changed, change the transactions in f119-doctor-ytd)
d112.qks:;   transactions of 'CEIEXP', 'TOTEXP', 'INCEXP' OF f119-doctor-ytd)
d112.qks:	get f119-doctor-ytd optional via doc-nbr,comp-code   &

d118.qks:file  f119-doctor-ytd    occurs 3
d118.qks:	access viaindex f119-doctor-ytd-seq		&
d118.qks:;select if rec-type  = "B" and comp-code-group of f119-doctor-ytd  = comp-code-group of f190-comp-codes
d118.qks:  for f119-doctor-ytd

d119.qks:; 2014/Sep/15 MC2       - add f119-doctor-ytd-audit to capture before change records
d119.qks:;                       - save f119-doctor-ytd-audit records in f119-doctor-ytd-audit in postfind in case
d119.qks:file  f119-doctor-ytd  primary  occurs 15
d119.qks:file f119-doctor-ytd-audit designer  occurs with f119-doctor-ytd

dept1_payments.qts:access f119-doctor-ytd-history                        &
dept1_payments.qts:doc-nbr             of f119-doctor-ytd-history      ,&

dept1_payments.qzs:set report dev disc name maryf119
dept1_payments.qzs:access f119-doctor-ytd-history       &
dept1_payments.qzs:build $obj/maryf119

dumpf119.qzs:set rep dev disc name dumpf119
dumpf119.qzs:access *f119
dumpf119.qzs:build $pb_obj/dumpf119

dumpf119ytd.qzs:set rep dev disc name dumpf119ytd
dumpf119ytd.qzs:access f119-doctor-ytd
dumpf119ytd.qzs:build $pb_obj/dumpf119ytd

earnings_revenue_mp.qts:access f119-doctor-ytd       &

earnings_revenue_mp_history.qts:access f119-doctor-ytd-history       &
earnings_revenue_mp_history.qts:sel  f119-doctor-ytd-history if ep-nbr = 201006

f119_afpcon.qzs:set report dev disc name f119afpcon
f119_afpcon.qzs:access f119-doctor-ytd                       &

f119_balancing.qts:;doc     : f119_balancing.qts      
f119_balancing.qts:access f119-doctor-ytd   &
f119_balancing.qts:doc-nbr             of  f119-doctor-ytd             ,&

f119_clirep.qzs:access f119-doctor-ytd-history       &

f119_macpen.qzs:;access f119-doctor-ytd       &
f119_macpen.qzs:access f119-doctor-ytd-history       &

f119_overage.qzs:set report dev disc name maryf119
f119_overage.qzs:access f119-doctor-ytd       &
f119_overage.qzs:build $obj/maryf119

f119_penpay.qzs:access f119-doctor-ytd-history       &

f119hist.qzs:set report dev disc name maryf119
f119hist.qzs:access f119-doctor-ytd-history                        &
f119hist.qzs:build $obj/maryf119

f119histafpcon.qts:access f119-doctor-ytd-history                        &
f119histafpcon.qts:doc-nbr             of f119-doctor-ytd-history      ,&

f119histpsycap.qts:access f119-doctor-ytd-history                        &
f119histpsycap.qts:doc-nbr             of f119-doctor-ytd-history      ,&

fix_seq_nbrs.qts:access f119-doctor-ytd link comp-code to comp-code of f190-comp-codes
fix_seq_nbrs.qts:output f119-doctor-ytd update
fix_seq_nbrs.qts:item process-seq     of f119-doctor-ytd = reporting-seq   of f190-comp-codes
fix_seq_nbrs.qts:item comp-code-group of f119-doctor-ytd = comp-code-group of f190-comp-codes

fixf110f119hist.qts:; 2013/Dec/18	MC	- original (fixf110f119hist.qts) - this version is for MP only
fixf110f119hist.qts:output f119-doctor-ytd update on errors report 
fixf110f119hist.qts:output f119-doctor-ytd-history update on errors report 

h119.qks:file  f119-doctor-ytd-history  primary  occurs 14
h119.qks:        access  viaindex f119-doctor-ytd-history 	&
h119.qks:     access viaindex comp-code using comp-code of f119-doctor-ytd-history

leena_afp_f119hist_mp.qts:;doc     : afp_f119hist
leena_afp_f119hist_mp.qts:access f119-doctor-ytd-history                        &
leena_afp_f119hist_mp.qts:build $obj/afp_f119hist

leenaf119hist.qzs:set report dev disc name leenaf119
leenaf119hist.qzs:access f119-doctor-ytd-history                        &
leenaf119hist.qzs:build $obj/maryf119

mary_surplu.qzs:set report dev disc name maryf119
mary_surplu.qzs:access f119-doctor-ytd       &
mary_surplu.qzs:build $obj/maryf119

maryf119.qzs:set report dev disc name maryf119
maryf119.qzs:access f119-doctor-ytd       &
maryf119.qzs:  tab  1 "maryf119"                                             &
maryf119.qzs:build $obj/maryf119

maryf119_paypot.qzs:set report dev disc name maryf119
maryf119_paypot.qzs:access f119-doctor-ytd       &
maryf119_paypot.qzs:  tab  1 "maryf119"                                             &
maryf119_paypot.qzs:build $obj/maryf119

maryf119hist-surp.qzs:set report dev disc name maryf119
maryf119hist-surp.qzs:access f119-doctor-ytd-history                        &
maryf119hist-surp.qzs:build $obj/maryf119

mp_payments.qzs:access f119-doctor-ytd       &
mp_payments.qzs:  tab  1 "maryf119"                                             &

purge_relof119_history.qts:; 2006/jun/15 - MC - reload f119  history file
purge_relof119_history.qts:access *savef119hist_retain 
purge_relof119_history.qts:output f119-doctor-ytd-history add on errors report

purge_unlof119_history.qts:; 2006/jun/15 - MC - delete f119  history file
purge_unlof119_history.qts:build $obj/purge_unlof119_history 

quizsave.qzs:set report dev disc name maryf119
quizsave.qzs:access f119-doctor-ytd       &
quizsave.qzs:build $obj/maryf119

r119a.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd                    &
r119a.qzs:        doc-nbr of f119-doctor-ytd                              &
r119a.qzs:        tab  52 comp-code of f119-doctor-ytd                          &

r119b.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd                    &
r119b.qzs:        doc-nbr of f119-doctor-ytd                              &
r119b.qzs:        tab  52 comp-code of f119-doctor-ytd                          &

r119c.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd opt                &
r119c.qzs:        doc-nbr of f119-doctor-ytd                              &
r119c.qzs:        tab  52 comp-code of f119-doctor-ytd                          &

r121a.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd                    &
r121a.qzs:        doc-nbr of f119-doctor-ytd                       	&

r121b.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd                    &
r121b.qzs:        doc-nbr of f119-doctor-ytd                              &

r121c.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd opt                &
r121c.qzs:        doc-nbr of f119-doctor-ytd                              &

r121d.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd opt                &
r121d.qzs:        tab  52 comp-code of f119-doctor-ytd                          &

r121e.qzs:  link doc-nbr to doc-nbr of f119-doctor-ytd opt                &
r121e.qzs:        tab  52 comp-code of f119-doctor-ytd                          &

r123e.qzs:access f119-doctor-ytd link to f020-doctor-mstr

r124a_mp.qzs:access f119-doctor-ytd                                          &
r124a_mp.qzs:	link current-ep-nbr, doc-nbr of f119-doctor-ytd		&
r124a_mp.qzs:use $pb_src/f119_doctor_ytd.def nol

r124a_paycode7.qzs:access f119-doctor-ytd                                          &
r124a_paycode7.qzs:        link comp-code of f119-doctor-ytd                       &
r124a_paycode7.qzs:               doc-nbr of f119-doctor-ytd                       &
r124a_paycode7.qzs:use $pb_src/f119_doctor_ytd.def ;  nol

r124c.qzs:; TODO - access f119 and get final value to ensure it matches one from subfile above
r124c.qzs:access f119-doctor-ytd                                          &

r127.qzs:;    PURPOSE: totinc record in f119 exists and mtd amt  not equal  0
r127.qzs:access f119-doctor-ytd                                          &
r127.qzs:        link doc-nbr of f119-doctor-ytd                         &
r127.qzs:	link (doc-nbr of f119-doctor-ytd,                        &

r128a.qts:;             STAGE 1 - create subfile of values from f119-doctor-ytd-history
r128a.qts:request access_f119_hist                     		&
r128a.qts:access f119-doctor-ytd-history				&
r128a.qts:sel f119-doctor-ytd-history if                    	&                   
r128a.qts:     doc-nbr of f119-doctor-ytd-history, 		&
r128a.qts:     ep-nbr of f119-doctor-ytd-history, 		&

u105.qts:access f119-doctor-ytd
u105.qts:output f119-doctor-ytd update
u105.qts:access f119-doctor-ytd link doc-nbr to doc-nbr of f020-doctor-mstr
u105.qts:output f119-doctor-ytd update

u106.qts:request u106_delete_deficit_f119_recs   &
u106.qts:access f119-doctor-ytd
u106.qts:output f119-doctor-ytd delete

u115a.qts:;		        particular the one used in f119 subfile
u115a.qts:subfile f119 keep                                                     &
u115a.qts:subfile f119 alias f119-rmaexr   append     at doc-nbr          &
u115a.qts:subfile f119 alias f119-rmaexm   append     at doc-nbr      &

u115c.qts:;   2014/may/13		MC1	 - change field size from integer*8 to integer*10 for subfile f119
u115c.qts:subfile f119 alias f119-increq   append                     &
u115c.qts:subfile f119 alias f119-inctar   append                   &

u117.qts:; 2001/may/22 B.E. subfile f119 made permanent for icu payroll
u117.qts:;		     amount' deductions from being copied into the f119.sf
u117.qts:;		     and therefore there never appeared in f119-ytd so
u117.qts:; 2014/may/13  MC1 - change field size from integer*8 to integer*10 for subfile f119
u117.qts:subfile f119 keep append                                   include &

u118.qts:;	      - also places deduction type transactions into the f119 subfile
u118.qts:;	  	for eventual upload into the f119-doctor-ytd EXCEPT 'percentage
u118.qts:;				   f119 subfile contained variables that
u118.qts:;				   within f119 - changed to use x-tmp-amt instead
u118.qts:;			  placed into f119 subfile. At the time TAX was the
u118.qts:;			  deductions - logic on output to f119 should have
u118.qts:; 2010/dec/14 MC1       - comment out write record in subfile f119
u118.qts:; 2014/may/13 MC2       - change field size from integer*8 to integer*10 for subfile f119
u118.qts:;subfile f119 append                        at comp-code 	      &
u118.qts:subfile f119 alias f119-totded append     at doc-nbr  &
u118.qts:subfile f119 alias f119-totadv append   at doc-nbr    &

u118_icu.qts:;               for eventual upload into the f119-doctor-ytd EXCEPT 'percentage
u118_icu.qts:;				   f119 subfile contained variables that
u118_icu.qts:;				   within f119 - changed to use x-tmp-amt instead
u118_icu.qts:;                    placed into f119 subfile. At the time TAX was the
u118_icu.qts:;                         deductions - logic on output to f119 should have
u118_icu.qts:subfile f119 append                        at comp-code               &
u118_icu.qts:subfile f119 alias f119-totded append     at doc-nbr  &
u118_icu.qts:;subfile f119 alias f119-totadv append   at doc-nbr    &

u119.qts:;		     subfile f119 so that no compile error in u122 because the pgm is
u119.qts:; 2014/may/13 MC2  - change field size from integer*8 to integer*10 for subfile f119
u119.qts:subfile f119 keep append                                   include &
u119.qts:;  create only 1 transaction in f119 to show on statement
u119.qts:;	therefore is written to f119 now
u119.qts:subfile f119 alias f119-advout append     &
u119.qts:;subfile f119 alias f119-defic  append     &

u119_before_split_u119b.qts:subfile f119 append                                   include &
u119_before_split_u119b.qts:subfile f119 alias f119-advout append     &

u119_chgeft.qts:;		     subfile f119 so that no compile error in u122 because the pgm is
u119_chgeft.qts:subfile f119 keep append                                   include &
u119_chgeft.qts:;  create only 1 transaction in f119 to show on statement
u119_chgeft.qts:;	therefore is written to f119 now
u119_chgeft.qts:subfile f119 alias f119-advout append     &
u119_chgeft.qts:;subfile f119 alias f119-defic  append     &

u122.qts:request u122_run_0_update_f119          &
u122.qts:access *f119                                     &
u122.qts: output f119-doctor-ytd                   update                 &

u127.qts:access f119-doctor-ytd			&
u127.qts:output f119-doctor-ytd-history          add
u127.qts:  item doc-nbr         = doc-nbr          of f119-doctor-ytd
u127.qts:  item comp-code       = comp-code        of f119-doctor-ytd

u132_sp.qts:; 2008/sep/26 brad1   - added rec-type = "A" in f114 update so that upload into f119 goes into '94' screen

u132_sp_mp.qts:; 2008/sep/26 brad1   - added rec-type = "A" in f114 update so that upload into f119 goes into '94' screen

u140_e.qts:; 08/may/09 brad 	- upload goverance transactions (AFPCON) to f119 "C" 
u140_e.qts:;			  instead of f119 subfile for AFPCON, NONRB & NONRBP
u140_e.qts:; output to f114 special payments for upload f119
u140_e.qts:;brad2 - 'hide' AFPCON transaction in "C" type record of f119-doctor-ytd
u140_e.qts:;		to f110-compensation for rec-type = 'A' and to f119-doctor-ytd for rec-type = 'C'

unlof119.qzs:access f119-doctor-ytd
unlof119.qzs:;set subfile name unlof119_rec_type_a keep portable
unlof119.qzs:set subfile name unlof119_rec_type_a keep 
unlof119.qzs:build $obj/unlof119a

unlof119hst.qzs:access f119-doctor-ytd-history
unlof119hst.qzs:set subfile name unlof119hst keep 
unlof119hst.qzs:build $obj/unlof119hst

utl0100.qts:; purpose: search f119-doctor-ytd for duplicate entries.
utl0100.qts:run f119_duplicate_checking
utl0100.qts:request f119_check_for_duplicates
utl0100.qts:access f119-doctor-ytd	
