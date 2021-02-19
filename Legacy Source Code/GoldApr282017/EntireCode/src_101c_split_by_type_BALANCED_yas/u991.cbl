identification division. 
program-id. u991.       
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/03/10. 
date-compiled. 
security. 
* 
*    files      : f001  - batch control file 
*		: f002  - claim master 
*		: f090i - constants master 
*		: "u991"  - print report file 
*               : audit report 
*    program purpose : this program uses the basic logic of the batch 
*			detail report (r001).  it reads selected batch 
*			control records and then the claims for that 
*			batch, adding up hash totals for the claim records. 
*			at the end of the batch the calculated hash totals 
*			are compared against the hash totals stored in 
*			the control record. if there is a difference  
*			then the old/new values are displayed on the 
*			screen.  operator is asked whether to update 
*			with new values (there is no reason normally 
*			to not update these values).  the batch status 
*			is then recalculated and control record rewritten. 
*			!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
*			note: if batch'S STATUS IS ALREADY > "2" THEN 
*			warning message is printed, values are changed 
*			however no change is made to the status !!!! 
*			!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
* 
*    revision may/87 (s.b.) - conversion from aos to aos/vs. 
*                             change field size for 
*                             status clause to 2 and 
*                             feedback clause to 4. 
* 
*    revision mar/89 (s.f.) - sms 112 
*                           - do not update the status for unbalanced 
*                           - only update computer totals not estimated 
*                           - treat agent 4 as a direct bill the same 
*                             as agent 6 
* 
*    revision mar/89 (s.f.) - sms 115 
*		            - make sure file status is pic xx ,feedback 
*			      is pic x(4) and infos status is pic x(11). 
* 
*    revision nov/91 (m.c.) - pdr 536 
*			    - update the status to '1' if balanced 
*			      on either amount or services 
* 
*    revision jun/92 (m.c.) - sms 139 
*			    - change the logic for the new clinic 60'S 
* 
*    revision feb/98 (j.c.) - s149 unix conversion
*
*    1999/May/20     (S.B.) - Y2K conversion.
*    2003/dec/11     M.C.   - alpha doc nbr
*    2004/oct/05     M.C.   - change the logic for clinic 60's (61-65)
*    2010/mar/09     MC1    - include clinic 66 in clinic 60's
*			    - add the logic for clinic 70's (71-75) which did not consider at all
*    2012/jul/05     MC2    - use ohip amount instead of oma amount for 'C'laim type when checking for difference
*    2012/Dec/13     MC3    - undo MC2 above, according to d001, batctrl-amt-act is same as oma-amt for 'C'laim type


environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f001_batch_control_file.slr". 
* 
    copy "f002_claims_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
 
    select print-file 
          assign to printer print-file-name 
	  file status is status-prt-file. 
* 
data division. 
file section. 
* 
    copy "f001_batch_control_file.fd". 
* 
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
* 
    copy "f090_constants_mstr.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(7) 
		value "u991". 
77  option					pic x. 
77  const-mstr-rec-nbr				pic x. 
77  difference					pic s9(7).  
77  diff					pic s9(7)v99. 
77  max-nbr-lines				pic 99	value 45. 
77  ctr-page					pic 9(4). 
77  ctr-line					pic 99. 
77  ctr-lines-to-print				pic 99. 
77  first-desc					pic x		value "Y". 
77  ws-reply 					pic x. 
77  ws-claim-nbr				pic 99. 
77  claim-nbr					pic 99. 
77  hold-clmhdr-status-ohip			pic xx. 
*!77  hold-clmhdr-batch-nbr			pic 9(9). 
77  hold-clmhdr-batch-nbr			pic x(8). 
77  hold-clmhdr-claim-nbr			pic 99. 
77  flag-error-batch				pic x. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  subs					pic 99   comp. 
77  subs-const					pic 99   comp. 
77  claims-occur				pic 9(16).      
* 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
77  eof-claims-dtl				pic x   value "N". 
77  eof-claims-mstr				pic x   value "N". 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-batctrl-file			pic x(11) value zero. 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 

77  common-status-file				pic x(2). 
77  status-cobol-batctrl-file			pic x(2) value zero. 
77  status-cobol-claims-mstr			pic x(2) value zero. 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-prt-file				pic xx    value zero. 
* 
* 
*  flag from batches > "1" 
77  batch-status-flag				pic x		value "N". 
 
copy "agent_code.ws". 
 
 
01  actual-counters. 
    05  act-sum-nbr-serv			pic 9(4). 
    05  act-manual-pay-tot			pic s9(5)v99. 
    05  act-sum-fee-oma				pic s9(5)v99. 
    05  act-sum-fee-ohip			pic s9(5)v99. 
    05  act-calc-ar-due				pic s9(5)v99.  
    05  act-calc-tot-rev			pic s9(5)v99. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-rec					pic x. 
    88  valid-rec				value "Y". 
    88  invalid-rec				value "N". 
 
01  sel-clinic-nbr				pic xx. 
 
*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-fee-oma				pic s9(5)v99. 
    05  ctr-fee-ohip				pic s9(5)v99. 
    05  ctr-nbr-claims-in-batch			pic 99. 
 
 
    copy "sysdatetime.ws". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"SERIOUS ERROR !! INVALID RE-WRITE ON BATCH CONTROL FILE". 
	10  filler				pic x(60)   value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)   value 
		"NO BATCH CONTROL RECORDS FOR THIS CLINIC". 
	10  filler				pic x(60)   value 
		"NO APPROPRIATE BATCH CONTROL RECS SELECTED FOR THIS CLINIC". 
	10  filler				pic x(60)   value 
		"SERIOUS ERROR!-INVALID BATCH TYPE, AND BATCH ID COMBINATION". 
	10  filler				pic x(60)   value 
		"**** CAN BE RE-USED ****". 
	10  err-msg-8. 
	    15  filler				pic x(51)  value 
		"NO CLAIMS IN CLAIMS MSTR FOR BATCH NUMBER = ". 
	    15  miss-claim-nbr-8		pic 9(9). 
	10  err-msg-9. 
	    15  filler				pic x(51)  value 
		"NO CLAIMS DATED THIS YEAR FOR BATCH NUMBER = ". 
	    15  miss-claim-nbr-9		pic 9(9). 
	10  filler				pic x(60)   value 
		"SERIOUS WARNING !! CORRECTING BATCH ALREADY SENT TO OHIP". 
        10  filler				pic x(60)   value 
		"**** CAN BE RE-USED ****". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 11  times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(67).       
01  h1-head. 
 
    05  filler					pic x(27)	value 
		"U991          RUN DATE  ". 
    05  h1-date. 
* (y2k)
*        10  h1-yy				pic 99. 
        10  h1-yy				pic 9999. 
        10  filler				pic x		value "/". 
        10  h1-mm				pic 99. 
        10  filler				pic x		value "/". 
        10  h1-dd				pic 99. 
* (y2k)
*    05  filler					pic x(14)	value spaces. 
    05  filler					pic x(12)	value spaces. 
    05  filler					pic x(34)	value 
		"RECOVER F001". 
    05  h1-batch-type				pic x(30).       
    05  filler					pic x(5)	value 
		"PAGE". 
    05  h1-page					pic z,zz9. 
 
 
 
01  h2-head. 
 
    05  filler					pic x(56)	value spaces. 
    05  h2-clinic-name				pic x(76). 
 
 
 
01  h3-head. 
 
    05  filler					pic x(44)	value spaces.  
    05  filler					pic x(8)	value 
		"CYCLE #". 
    05  h3-cycle				pic zz9. 
    05  filler					pic x(12)	value 
		"  BATCH NO.". 
    05  h3-batch-nbr. 
	10  h3-clinic1				pic 99. 
*!	10  h3-doc-nbr				pic 9(3). 
	10  h3-doc-nbr				pic x(3). 
	10  h3-week				pic 99. 
	10  h3-day				pic 9. 
    05  filler					pic x(21)	value spaces. 
    05  filler					pic x(23)	value 
		"FOR THE PERIOD ENDING:". 
* (y2k)
*    05  h3-period-end-yy			pic xx. 
    05  h3-period-end-yy			pic xxxx. 
    05  filler					pic x		value "/". 
* (y2k)
    05  h3-period-end-mm			pic xx. 
    05  filler					pic x		value "/". 
* (y2k)
    05  h3-period-end-dd			pic xx. 
*    05  filler					pic x(4)	value spaces. 
    05  filler					pic x(2)	value spaces. 
 
 
 
01  h4-head. 
 
    05  filler					pic x(30)	value 
		"   CLAIM    PATIENT    PATIENT". 
    05  filler					pic x(30)	value 
		" ID/   DOCTOR   DIAG   REF DR". 
    05  filler					pic x(30)	value 
		" HOSP       LOCATION AG  P  RE". 
    05  filler					pic x(42)	value 
		"FERENCE  ADM DATE".               
 
 
 
01  h5-head. 
 
    05  filler					pic x(30)	value 
		"  NUMBER    ACRONYM    CHART N". 
    05  filler					pic x(30)	value 
		"UMBER   CODE    CODE   (CONSEC". 
    05  filler					pic x(30)	value 
		". DATE)      OMA CD  AJ     RS". 
    05  filler					pic x(30)	value 
		"N & SRV  SVC DATE     OMA". 
    05  filler					pic x(12)	value 
		" OHIP".       
 
 
 
01  t1-head. 
 
    05  filler					pic x(18)	value spaces. 
    05  filler					pic x(114)	value 
		"DIFFERENCES FOUND". 
 
 
 
01  t2-head. 
 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(11)	value 
		"BATCH NBR: ". 
    05  t1-head-bat-clinic-nbr-1-2		pic 99. 
*!  05  t1-head-bat-doc-nbr			pic 999. 
    05  t1-head-bat-doc-nbr			pic xxx. 
    05  t1-head-bat-week			pic 99. 
    05  t1-head-bat-day				pic  9. 
    05  filler					pic x(96)	value spaces. 
 
01  t2a-head. 
 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(14)	value 
		"BATCH STATUS: ". 
    05  t1-status				pic x. 
    05  filler					pic x(100)	value spaces. 
 
 
01  t3-head. 
 
    05  filler					pic x(28)	value spaces. 
    05  filler					pic x(104)	value 
	"ORIGINAL VALUES           NEW VALUES          ESTIMATED VALUES". 
01  print-line. 
 
    05  l1-print-line. 
	10  l1-batch-nbr. 
	    15  l1-clinic1			pic 99. 
*!   	    15  l1-doc-nbr			pic 9(3). 
	    15  l1-doc-nbr			pic x(3). 
	    15  l1-week				pic 99. 
	    15  l1-day				pic 9. 
	10  l1-dash				pic x.               
	10  l1-claim-nbr			pic 9(2). 
	10  filler				pic x. 
	10  l1-patient-acronym. 
	    15  l1-patient-acronym6		pic x(7). 
	    15  l1-patient-acronym3		pic x(5). 
	10  l1-pat-id-chart-id			pic x(16). 
*!	10  l1-doc-nbr2				pic zz9. 
	10  l1-doc-nbr2				pic xxx. 
	10  filler				pic x(4). 
	10  l1-diag-code			pic zz9. 
	10  filler				pic x(3). 
	10  l1-refer-doc-nbr			pic x(6). 
	10  filler				pic xx. 
	10  l1-hosp				pic zzzz. 
* (y2k)
*	10  filler				pic x(8). 
	10  filler				pic x(6). 
	10  l1-location				pic x999. 
	10  filler				pic x(5). 
	10  l1-agent-cd				pic 9. 
	10  filler				pic x(2). 
	10  l1-pat-in-out			pic x. 
	10  filler       			pic x(2). 
	10  l1-reference			pic x(11). 
	10  l1-admit-date. 
* (y2k)
*	    15  l1-admit-date-yy		pic 99. 
	    15  l1-admit-date-yy		pic 9999. 
	    15  l1-slash1			pic x. 
	    15  l1-admit-date-mm		pic 99. 
	    15  l1-slash2			pic x. 
	    15  l1-admit-date-dd		pic 99. 
	10  filler				pic x. 
	10  l1-brace-l1				pic x.   
	10  l1-ar-oma				pic 9(5).99-. 
	10  l1-brace-r1				pic x(2).  
	10  l1-brace-l2				pic x. 
	10  l1-ar-ohip				pic 9(5).99-. 
	10  l1-brace-r2				pic x(2). 
    05  l2-print-line redefines l1-print-line. 
	10  filler				pic x(52). 
	10  l2-consecutive-dates occurs 3 times. 
	    15  l2-sv-nbr			pic z9   blank when zero. 
	    15  filler				pic x. 
	    15  l2-sv-day			pic 99   blank when zero. 
	    15  l2-sv-day-alpha redefines l2-sv-day 
						pic xx. 
	    15  filler				pic x. 
	10  filler				pic x(3). 
	10  l2-oma-cd				pic x999. 
	10  l2-oma-suff				pic x(5). 
	10  l2-adj-cd				pic x(3). 
	10  l2-card-colour			pic x(3). 
	10  l2-rsn				pic x9. 
* (y2k)
*	10  filler				pic x(4). 
	10  filler				pic x(2). 
	10  l2-srv				pic 99. 
	10  filler				pic x(3).    
	10  l2-svc-date. 
* (y2k)
*	    15  l2-svc-date-yy			pic 99. 
	    15  l2-svc-date-yy			pic 9999. 
	    15  l2-slash1			pic x. 
	    15  l2-svc-date-mm			pic 99. 
	    15  l2-slash2			pic x. 
	    15  l2-svc-date-dd			pic 99. 
	10  filler				pic xx. 
	10  l2-fee-oma				pic zzzzz.99-. 
	10  filler				pic x(3). 
	10  l2-fee-ohip				pic zzzzz.99-. 
	10  filler				pic x(2). 
    05  l3-print-line redefines l2-print-line. 
	10  filler				pic x(109). 
	10  l3-fee-total-oma			pic zzzzz.99-. 
	10  filler				pic x(3). 
	10  l3-fee-total-ohip			pic zzzzz.99-. 
	10  filler				pic x(2). 
    05  l4-print-line redefines l3-print-line. 
	10  l4-claim-desc			pic x(45). 
	10  filler				pic x(87). 
    05  t1-print-line redefines l4-print-line. 
	10  filler				pic x(4). 
	10  t1-total-lit			pic x(25). 
	10  t1-orig-value. 
	    15  t1-orig-claim. 
		20  filler			pic x(6). 
	        20  t1-orig-claim-r		pic 99. 
		20  filler			pic x(12). 
	    15  t1-orig-amt redefines t1-orig-claim. 
		20  filler			pic x(3). 
		20  t1-orig-amt-r		pic z(4)9.99-. 
		20  filler			pic x(8). 
	    15  t1-orig-serv redefines t1-orig-amt. 
		20  filler			pic x(4). 
		20  t1-orig-serv-r		pic zzz9. 
		20  filler			pic x(12). 
 	    15  t1-orig-ar-due redefines t1-orig-serv. 
		20  filler			pic x(3). 
		20  t1-orig-ar-due-r		pic z(4)9.99-. 
		20  filler			pic x(8). 
	    15  t1-orig-calc redefines t1-orig-ar-due. 
		20  filler			pic x(3). 
		20  t1-orig-calc-r 		pic z(4)9.99-. 
		20  filler			pic x(8). 
	10  t1-new-value.                         
	    15  t1-new-claim. 
		20  filler			pic x(9). 
	        20  t1-new-claim-r		pic 99. 
		20  filler			pic x(9). 
	    15  t1-new-amt redefines t1-new-claim. 
		20  filler			pic x(6). 
		20  t1-new-amt-r		pic z(4)9.99-. 
		20  filler			pic x(5). 
	    15  t1-new-serv redefines t1-new-amt. 
		20  filler			pic x(7). 
		20  t1-new-serv-r		pic zzz9. 
		20  filler			pic x(9). 
 	    15  t1-new-ar-due redefines t1-new-serv. 
		20 filler			pic x(6). 
		20  t1-new-ar-due-r		pic z(4)9.99-. 
		20  filler			pic x(5). 
	    15  t1-new-calc redefines t1-new-ar-due. 
		20  filler			pic x(6). 
		20  t1-new-calc-r 		pic z(4)9.99-. 
		20  filler			pic x(5). 
	10  t1-est-value. 
	    15  t1-est-amt. 
		20  filler			pic x(8). 
		20  t1-est-amt-r		pic z(4)9.99-. 
	    15  t1-est-serv redefines t1-est-amt. 
		20  filler			pic x(9). 
		20  t1-est-serv-r		pic zzz9. 
		20  filler			pic x(4). 
	10  filler				pic x(46). 
 
 
01  blank-line					pic x(132). 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05			line 12 col 25 value is "ENTER CLINIC IDENTIFICATION".  
    05  scr-clinic-nbr	line 12 col 53 pic x(2) to sel-clinic-nbr auto required. 
 
 
01  scr-batch-status. 
    05  line 22 col 5 value is "DO YOU WANT TO PROCESS BATCH STATUS >  1  ( SENT TO OHIP )". 
    05  scr-rep line 22 col 64 pic x using batch-status-flag  auto required. 
 
01  scr-last-values. 
    05  blank screen. 
    05  line 05 col 19 	value is "DIFFERENCES FOUND". 
    05  line 07 col 18 	value is "BATCH NBR: ". 
    05  line 07 col 29  pic  99 using batctrl-bat-clinic-nbr-1-2. 
*!  05  line 07 col 31  pic 999 using batctrl-bat-doc-nbr. 
    05  line 07 col 31  pic xxx using batctrl-bat-doc-nbr. 
    05  line 07 col 34  pic  99 using batctrl-bat-week. 
    05  line 07 col 36  pic   9 using batctrl-bat-day. 
    05  line 10 col 26 	value is "ORIGINAL VALUES". 
    05  line 10 col 51 	value is "NEW VALUES".      
    05  line 12 col 05  value is "LAST CLAIM NBR". 
    05  line 12 col 36  pic 99 using batctrl-last-claim-nbr. 
    05  line 12 col 56  pic 99 using ws-claim-nbr. 
    05  line 14 col 05  value is "NBR CLAIMS IN BATCH". 
    05  line 14 col 36  pic 99 using batctrl-nbr-claims-in-batch. 
    05  line 14 col 56  pic 99 using ctr-nbr-claims-in-batch. 
    05  line 16 col 05  value is "NBR OF SERVICES". 
    05  line 16 col 34  pic zzz9 using batctrl-svc-act. 
    05  line 16 col 54  pic zzz9 using act-sum-nbr-serv. 
    05  line 18 col 05  value is "CALC A/R DUE".               
    05  line 18 col 30  pic z(4)9.99- using batctrl-calc-ar-due. 
    05  line 18 col 50  pic z(4)9.99- using act-calc-ar-due. 
    05  line 20 col 05  value is "CALC TOT REV". 
    05  line 20 col 30  pic z(4)9.99- using batctrl-calc-tot-rev. 
    05  line 20 col 50  pic z(4)9.99- using act-calc-tot-rev. 
    05  line 22 col 05  value is "MANUAL PAY TOT". 
    05  line 22 col 30  pic z(4)9.99- using batctrl-manual-pay-tot. 
    05  line 22 col 50  pic z(4)9.99- using act-manual-pay-tot. 
 
 
 
01  program-in-progress. 
    05  line 24 col 20 value is "PROGRAM U991 IN PROGRESS". 
 
01  scr-test-batctrl-nbr. 
*!  05			line 23 col 06  pic 9(9) using batctrl-batch-nbr. 
    05			line 23 col 06  pic x(8) using batctrl-batch-nbr. 
    05			line 23 col 56	pic x    using batctrl-batch-type. 
 
01  scr-accept-last-values. 
    05			line 23 col 06  value is "DO YOU WANT TO UPDATE BATCH WITH NEW VALUES (Y/N) ". 
    05  scr-reply	line 23 col 56 pic x using ws-reply required. 
*                     
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from common-status-file    bell blink. 
    05  line 24 col 70 pic x(2) from common-status-file    bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  ring-bell. 
    05  line 24 col 1	blank line bell. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
    05  line 23 col 02 pic x using ws-reply auto. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  7 col 20  value "NUMBER OF BATCTRL-FILE ACCESSES = ". 
    05  line  7 col 60  pic 9(7) from ctr-batctrl-file-reads. 
    05  line  9 col 20  value "NUMBER OF CLMHDR ACCESSES = ". 
    05  line  9 col 60  pic 9(7) from ctr-claims-mstr-reads. 
    05  line 21 col 17	value "PROGRAM U991 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 41  pic 99	from sys-yy. 
    05  line 21 col 39  pic 9(4)	from sys-yy. 
    05  line 21 col 43	value "/". 
    05  line 21 col 44	pic 99	from sys-mm. 
    05  line 21 col 46	value "/". 
    05  line 21 col 47	pic 99	from sys-dd. 
    05  line 21 col 51	pic 99	from sys-hrs. 
    05  line 21 col 53	value ":". 
    05  line 21 col 54	pic 99	from sys-min.        
    05  line 23 col 20	value "PRINT REPORT IS IN FILE - ". 
    05  line 23 col 51	pic x(7) from print-file-name. 
procedure division. 
declaratives. 
 
err-batctrl-file section. 
    use after standard error procedure on batch-ctrl-file.    
err-batctrl. 
*mf    move status-batctrl-file		to common-status-file. 
    move status-cobol-batctrl-file	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING BATCH CONTROL FILE". 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
*mf     move status-iconst-mstr		to common-status-file. 
    move status-cobol-iconst-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
 
err-claim-header-mstr-file section. 
    use after standard error procedure on claims-mstr. 
err-claims-mstr. 
*mf    move status-claims-mstr		to common-status-file. 
    move status-cobol-claims-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm.                 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
*	(delete print file) 
*    expunge print-file. 
 
    open i-o  	batch-ctrl-file. 
    open input  claims-mstr 
		iconst-mstr. 
    open output print-file. 
 
    move run-date			to  h1-date.     
    move zero				to counters  
					   claim-nbr 
					   ctr-page   
					   actual-counters. 
    move 65				to ctr-line. 
    move spaces				to print-line 
					   blank-line. 
 
*	(display screen title/option) 
    display scr-title. 
 
aa0-10-enter-clinic-nbr. 
 
    accept scr-clinic-nbr. 
 
    if sel-clinic-nbr  not numeric 
    then 
	move 1				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to aa0-10-enter-clinic-nbr. 
*   (else) 
*   endif 
 
*	(obtain cycle nbr & period end from constants mstr) 
    move sel-clinic-nbr			to iconst-clinic-nbr-1-2. 
    read iconst-mstr 
 	invalid key 
 	    move 3			to err-ind 
 	    perform za0-common-error	thru za0-99-exit 
 	    go to az0-end-of-job. 
 
    move iconst-clinic-cycle-nbr	to h3-cycle. 
    move iconst-date-period-end-yy	to h3-period-end-yy. 
    move iconst-date-period-end-mm	to h3-period-end-mm. 
    move iconst-date-period-end-dd	to h3-period-end-dd. 
    move iconst-clinic-name		to h2-clinic-name. 
 
*	(the user is given the option of processing claims with 
*	 batch status = "2" (ie sent to ohip) or just balanced/unbalanced)                             
 
    move "N"				to  batch-status-flag. 
    display scr-batch-status. 
    accept  scr-batch-status. 
 
    display program-in-progress.  
 
*    (set up key for read of 1st batctrl rec for selected clinic) 
*mf    move zero				to key-batch-nbr. 
*mf    move sel-clinic-nbr			to key-bat-clinic-nbr-1-2. 
 
*mf    read batch-ctrl-file key is key-batctrl-file approximate 
*mf	invalid key 
*mf	    move 4			to err-ind 
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    move zero				to batctrl-batch-nbr. 
    move sel-clinic-nbr			to batctrl-bat-clinic-nbr-1-2. 
    start batch-ctrl-file key is greater than or equal key-batctrl-file
	invalid key 
	    move 4			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
    read batch-ctrl-file next.

*mf    retrieve  batch-ctrl-file  key  fix position 
*mf	into key-batctrl-file. 
 
    add 1				to ctr-batctrl-file-reads. 
 
    move "N"				to flag-rec. 
    perform xe1-select-batctrl-rec	thru xe1-99-exit. 
 
    if invalid-rec 
    then 
	perform xe0-sel-read-next-batctrl thru xe0-99-exit. 
*   (else) 
*   endif 
 
*	(error if no appropriate batches found for clinic) 
    if eof-batctrl-file = "Y" 
    then 
	move 5				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*    (read header record for 1st claim in batch) 
    perform xg0-read-claim		thru xg0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close batch-ctrl-file 
	  claims-mstr 
	  iconst-mstr 
	  print-file. 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
 
*   call program "menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    perform ca0-read-bat-move-print-hdr	thru ca0-99-exit. 
 
    if eof-batctrl-file = "Y" 
    then 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
    move "N"				to eof-claims-dtl. 
    move "Y"				to first-desc. 
 
ab0-10-claim-loop. 
 
    perform da0-read-dtl-next-clm	thru da0-99-exit. 
 
    if 	eof-claims-dtl = "N" 
    then 
	perform da1-move-print-dtl	thru da1-99-exit 
	go to ab0-10-claim-loop. 
*   (else) 
*   endif 
 
    if 	first-desc = "Y" 
    then 
	perform ea0-print-claims-totals	thru ea0-99-exit. 
*   (else) 
*   endif 
 
 
    if 	eof-claims-mstr = "N" 
    then 
	go to ab0-processing 
    else 
        perform fa0-print-batch-totals	thru fa0-99-exit. 
*   endif 
 
ab0-99-exit. 
    exit. 
ca0-read-bat-move-print-hdr. 
 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
 
    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) 
      or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
	perform fa0-print-batch-totals	thru fa0-99-exit  
	perform ga0-read-next-batch	thru ga0-99-exit 
 
	if eof-batctrl-file = "Y" 
	then 
	    go to ca0-99-exit 
	else 
	    perform xb0-reset-values	thru xb0-99-exit 
*	endif 
    else 
	next sentence. 
*   endif 
 
    perform ca1-move-print-hdr		thru ca1-99-exit. 
 
ca0-99-exit. 
    exit. 
ca1-move-print-hdr. 
 
*	(store claim-nbr in case this is the last claim in batch) 
*	(use the orig claim nbr because of adjustment batches) 
    move clmhdr-orig-claim-nbr		to ws-claim-nbr. 
 
    add 1				to ctr-nbr-claims-in-batch. 
 
*	(sum the actual-oma-amt for testing against amt in batctrl-rec) 
    if    batctrl-batch-type = 'P' 
      and batctrl-adj-cd     = 'C' 
    then 
	add clmhdr-manual-and-tape-paymnts 
					to act-sum-fee-oma 
				   	   act-sum-fee-ohip 
    else 
	add clmhdr-tot-claim-ar-oma	to act-sum-fee-oma 
	add clmhdr-tot-claim-ar-ohip	to act-sum-fee-ohip. 
*   endif 
 
    if   batctrl-batch-type = 'C' 
      or (    batctrl-batch-type = 'A' 
	  and batctrl-adj-cd	 = 'B' ) 
    then 
	add clmhdr-tot-claim-ar-ohip	to act-calc-ar-due 
	add clmhdr-tot-claim-ar-ohip	to act-calc-tot-rev 
    else 
	if    batctrl-batch-type = 'A' 
	  and batctrl-adj-cd	 = 'A' 
	then 
	    add clmhdr-tot-claim-ar-ohip 
					to act-calc-ar-due 
	else 
	    if batctrl-batch-type = 'A' 
	      and batctrl-adj-cd  = 'R' 
	    then 
		add clmhdr-tot-claim-ar-ohip 
					to act-calc-tot-rev 
	    else 
		if    batctrl-batch-type = 'P' 
		  and batctrl-adj-cd	 = 'C' 
		then 
		    add clmhdr-manual-and-tape-paymnts 
					to act-manual-pay-tot 
		else 
		    if    batctrl-batch-type = 'P' 
		      and batctrl-adj-cd     = 'M' 
		    then 
			add clmhdr-manual-and-tape-paymnts 
					to act-manual-pay-tot 
					   act-calc-tot-rev 
		    else 
			move 6		to err-ind 
			perform za0-common-error 
					thru za0-99-exit 
			go to az0-end-of-job. 
*		    endif 
*		endif 
*	    endif 
*	endif 
*   endif 
 
ca1-99-exit. 
    exit. 
da0-read-dtl-next-clm. 
 
    read claims-mstr next 
	at end 
	    move "Y"			to eof-claims-dtl 
	    move "Y"			to eof-claims-mstr 
	    go to da0-99-exit. 
 
*mf    retrieve claims-mstr key fix position 
*mf	into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move "Y"			to eof-claims-dtl 
	move "Y"			to eof-claims-mstr 
	go to da0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to ctr-claims-mstr-reads. 
 
*	skip adjustment detail records 
    if    clmdtl-adj-nbr     not = 0 
      and batctrl-batch-type     = "C" 
    then 
	go to da0-read-dtl-next-clm. 
*   (else) 
*   endif 
 
    if clmhdr-zeroed-area is numeric 
    then 
	if clmhdr-zeroed-area = zero 
	then 
	    move clmhdr-orig-batch-nbr	to hold-clmhdr-batch-nbr 
	    move clmhdr-orig-claim-nbr	to hold-clmhdr-claim-nbr 
	    move clmhdr-status-ohip	to hold-clmhdr-status-ohip  
	    move "Y"			to eof-claims-dtl  
	    go to da0-10-check-clinic 
	else 
	    next sentence 
*	endif 
    else 
	next sentence. 
*   endif 
 
    if   clmdtl-orig-batch-nbr          not = hold-clmhdr-batch-nbr 
      or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr 
    then 
	move "Y"			to eof-claims-dtl. 
*   (else) 
*   endif 
 
da0-10-check-clinic. 

* 2010/03/09 - MC1 - rewrite logic to include clinic 66 as well as clinic 70's 

**    if batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2 
* 2004/10/05 - MC
*      and sel-clinic-nbr < 60 
**      and (sel-clinic-nbr < 60  or sel-clinic-nbr > 65)
* 2004/10/05 - end
  
   if    batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2 
     and (    (     clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr < 60
	      )
           or (     clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr
                and clmhdr-clinic-nbr-1-2 > 75
	      )
           or (     clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr = 60
                and clmhdr-clinic-nbr-1-2 > 66
	      )
           or (     clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and clmhdr-clinic-nbr-1-2 > 75
	      )
         )
* 2010/03/09 - end 
  
    then 
	move "Y"			to eof-claims-mstr 
	go to da0-99-exit. 
*   (else) 
*   endif 
 
da0-99-exit. 
    exit. 
da1-move-print-dtl. 
 
    if clmdtl-oma-cd = "ZZZZ" 
    then 
	if first-desc = "Y" 
	then 
	    perform ea0-print-claims-totals 
					thru ea0-99-exit 
	    move "N"			to first-desc 
	else 
	    next sentence                
*	endif 
    else 
	perform da12-move-print-dtl	thru da12-99-exit 
*	(add to claim totals) 
	add clmdtl-fee-oma		to ctr-fee-oma 
	add clmdtl-fee-ohip		to ctr-fee-ohip 
	go to da1-99-exit. 
*   endif 
 
    move clmdtl-desc			to l4-claim-desc. 
    move 1				to ctr-lines-to-print. 
 
da1-99-exit. 
    exit. 
da12-move-print-dtl. 
 
    move 1				to subs. 
 
da12-10-date-loop. 
 
*	(compute nbr of services for batch) 
    add clmdtl-sv-nbr (subs)		to act-sum-nbr-serv. 
 
    move clmdtl-sv-nbr (subs)		to l2-sv-nbr (subs). 
 
    if clmdtl-sv-day (subs) numeric 
    then 
	move clmdtl-sv-day (subs)	to l2-sv-day (subs) 
    else 
	move clmdtl-sv-day (subs)	to l2-sv-day-alpha (subs). 
*   endif 
 
    add 1				to subs. 
 
    if subs < 4 
    then 
	go to da12-10-date-loop. 
*   (else) 
*   endif 
 
    move clmdtl-oma-cd			to l2-oma-cd. 
    move clmdtl-oma-suff		to l2-oma-suff. 
    move clmdtl-adj-cd			to l2-adj-cd. 
    move hold-clmhdr-status-ohip	to l2-rsn. 
    move clmdtl-nbr-serv		to l2-srv. 
 
    move clmdtl-sv-yy			to l2-svc-date-yy. 
    move clmdtl-sv-mm			to l2-svc-date-mm. 
    move clmdtl-sv-dd			to l2-svc-date-dd. 
    move "/"				to l2-slash1 
					   l2-slash2. 
    move clmdtl-fee-oma			to l2-fee-oma. 
    move clmdtl-fee-ohip		to l2-fee-ohip. 
 
*	(compute nbr of services and sum of oma fee per batch)   
    if clmdtl-nbr-serv is numeric 
    then 
	add clmdtl-nbr-serv		to act-sum-nbr-serv. 
*   (else) 
*   endif 
 
    move 1				to ctr-lines-to-print. 
 
da12-99-exit. 
    exit. 
ea0-print-claims-totals. 
 
    move ctr-fee-oma			to l3-fee-total-oma. 
    move ctr-fee-ohip			to l3-fee-total-ohip. 
 
    move 0				to ctr-fee-oma  
					   ctr-fee-ohip. 
 
ea0-99-exit. 
    exit. 
fa0-print-batch-totals. 
 
*   (sms #112 - treat agent 4 as direct bill) s.f. 
    move batctrl-agent-cd			to ws-agent-flag. 
 
*    if not ohip-agent - comment out because every claim should be checked - 90/nov/09 m.c. 
 
    if    ( batctrl-last-claim-nbr	= ws-claim-nbr ) 
      and ( batctrl-nbr-claims-in-batch	= ctr-nbr-claims-in-batch ) 
 
*	  only do this check for claim batches..not adjustments or payments 
      and ( (    batctrl-amt-act	= act-sum-fee-oma ) 
	      or batctrl-batch-type not = 'C' ) 
 
      and (    batctrl-svc-act	= act-sum-nbr-serv 
*   (sms #112 - treat agent 4 as direct bill) s.f. 
*           or batctrl-agent-cd = '6' ) 
            or direct-bill-agent ) 
 
      and ( batctrl-manual-pay-tot	= act-manual-pay-tot )     
      and ( batctrl-calc-ar-due		= act-calc-ar-due )     
      and ( batctrl-calc-tot-rev	= act-calc-tot-rev ) 
    then 
*	(determine that batch status is correct) 
	if   batctrl-amt-est = batctrl-amt-act 
	  or batctrl-svc-est = batctrl-svc-act 
	then 
	    if batctrl-batch-status = "0" 
	    then 
*		(batch status should not indicate unbalanced - update the batctrl rec)             
		next sentence 
	    else 
		go to fa0-98-reset-vals 
*	    endif 
	else 
	    if batctrl-batch-status = "1"   
	    then 
*		(batch status should not indicate balanced - update the batctrl rec)             
		next sentence 
	    else 
		go to fa0-98-reset-vals  
*	    endif 
*	endif 
    else 
	next sentence. 
*   endif 
 
 
fa0-05-error. 
 
    display ring-bell. 
    display ring-bell. 
    display ring-bell. 
    display ring-bell. 
    display ring-bell. 
    display ring-bell. 
 
    display scr-last-values. 
 
fa0-10-verification. 
     
    if batctrl-batch-status > "1" 
    then 
        move 10				to err-ind 
        perform za0-common-error	thru za0-99-exit. 
*   (else) 
*   endif 
 
    move spaces				to ws-reply. 
    display scr-accept-last-values. 
 
    accept scr-reply. 
    display blank-line-24. 
 
    if ws-reply =    "Y" 
		  or "N" 
    then 
	next sentence 
    else 
	move 1			 	to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to fa0-10-verification. 
*   endif 
 
 
    if 	ws-reply not = "Y" 
    then  
	go to fa0-98-reset-vals. 
*   (else) 
*   endif 
 
 
    perform xa0-headings		thru	xa0-99-exit. 
    move spaces				to print-line. 
 
    write print-record from t1-head after advancing 3 lines. 
    move batctrl-bat-clinic-nbr-1-2  to  t1-head-bat-clinic-nbr-1-2. 
    move batctrl-bat-doc-nbr	     to  t1-head-bat-doc-nbr. 
    move batctrl-bat-week	     to  t1-head-bat-week. 
    move batctrl-bat-day	     to  t1-head-bat-day. 
    write print-record from t2-head after advancing 1 line. 
    move batctrl-batch-status		to t1-status. 
    write print-record from t2a-head after 1 line. 
    write print-record from t3-head after advancing 2 lines. 
 
    move "LAST CLAIM NBR"		to t1-total-lit. 
    move batctrl-last-claim-nbr		to t1-orig-claim-r. 
    move ws-claim-nbr			to t1-new-claim-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces				to print-line. 
 
    move "NBR OF CLAIMS IN BATCH"	to t1-total-lit. 
    move batctrl-nbr-claims-in-batch	to t1-orig-claim-r. 
    move ctr-nbr-claims-in-batch	to t1-new-claim-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces				to print-line. 
 
    move "NBR OF SERVICES"		to t1-total-lit. 
    move batctrl-svc-act 		to t1-orig-serv-r. 
    move batctrl-svc-est		to t1-est-serv-r. 
    move act-sum-nbr-serv		to t1-new-serv-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces 			to print-line. 
 
    if   ( batctrl-batch-type	 = 'C' ) 
      or (    batctrl-batch-type = 'A' 
	  and batctrl-adj-cd	 = 'A' ) 
      or (    batctrl-batch-type = 'A' 
	  and batctrl-adj-cd	 = 'B' ) 
    then 
	move batctrl-amt-est		to t1-est-amt-r. 
*   (else) 
*   endif 
 
    move "CALC A/R DUE"			to t1-total-lit. 
    move batctrl-calc-ar-due		to t1-orig-ar-due-r. 
    move act-calc-ar-due		to t1-new-ar-due-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces 			to print-line. 
 
    if    batctrl-batch-type = 'A' 
      and batctrl-adj-cd     = 'R' 
    then 
	move batctrl-amt-est		to t1-est-amt-r. 
*   (else) 
*   endif 
 
    move "CALC TOT REV"			to t1-total-lit. 
    move batctrl-calc-tot-rev		to t1-orig-calc-r. 
    move act-calc-tot-rev		to t1-new-calc-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces				to print-line. 
 
    if   (    batctrl-batch-type = 'P' 
	  and batctrl-adj-cd	 = 'M' ) 
      or (    batctrl-batch-type = 'P' 
	  and batctrl-adj-cd	 = 'C' ) 
    then 
	move batctrl-amt-est		to t1-est-amt-r. 
*   (else) 
*   endif 
 
    move "MANUAL PAY TOT"		to t1-total-lit. 
    move batctrl-manual-pay-tot		to t1-orig-calc-r. 
    move act-manual-pay-tot		to t1-new-calc-r. 
    write print-record from t1-print-line after 2 lines. 
    move spaces				to print-line. 
 
    add 17 				to ctr-line. 
 
    move act-manual-pay-tot		to batctrl-manual-pay-tot. 
 
    if    batctrl-batch-type = "P" 
      and batctrl-adj-cd     = "M" 
    then 
	move act-calc-tot-rev		to batctrl-calc-tot-rev 
    else 
	if    batctrl-batch-type = "P" 
	  and batctrl-adj-cd     = "C" 
	then 
	    next sentence 
	else 
	    move act-calc-tot-rev	to batctrl-calc-tot-rev 
	    move act-calc-ar-due	to batctrl-calc-ar-due. 
*	endif 
*   endif 
 
    if   batctrl-batch-type = "P" 
      or batctrl-batch-type = "A" 
    then 
        move act-sum-fee-ohip		to batctrl-amt-act 
 
*  sms 112 do not update the estimated amounts s.f. 
*	    			        batctrl-amt-est 
    else 
* 2012/07/05 - MC2 - use fee-ohip instead for 'C'laim type
*	move act-sum-fee-oma		to batctrl-amt-act. 
* 2012/12/13 - MC3 - unod MC2             for 'C'laim type
*	move act-sum-fee-ohip 		to batctrl-amt-act. 
	move act-sum-fee-oma		to batctrl-amt-act. 
* 2012/12/13 - end
* 2012/07/05 - end
 
*  sms 112 do not update the estimated amounts s.f. 
*				        batctrl-amt-est. 
 
*   endif 
 
    move act-sum-nbr-serv		to batctrl-svc-act. 
    move ws-claim-nbr   		to batctrl-last-claim-nbr. 
    move ctr-nbr-claims-in-batch	to batctrl-nbr-claims-in-batch. 
 
*	(determine the new correct batch status -- 
*	 note: status not changed if its already 2 or greater) 
    if batctrl-batch-status  > "1" 
    then 
        next sentence 
    else 
*	(note: adjustment/payment batches balanced only on $ amount) 
 
        if   (   batctrl-batch-type = "C" 
              and (   batctrl-svc-est = batctrl-svc-act 
                   or batctrl-amt-est = batctrl-amt-act )) 
          or (    batctrl-batch-type not = "C" 
              and batctrl-amt-est = batctrl-amt-act) 
        then 
            move "1"			to batctrl-batch-status 
        else 
	    move "0"			to batctrl-batch-status. 
*       endif 
*   endif 
 
    perform ha0-rewrite-batctrl-file   	thru ha0-99-exit. 
 
fa0-98-reset-vals. 
 
    move zero				to actual-counters. 
 
fa0-99-exit. 
    exit. 
ga0-read-next-batch. 
 
    move "N"				to flag-rec. 
 
    perform xe0-sel-read-next-batctrl	thru xe0-99-exit 
		until   eof-batctrl-file = "Y" 
		     or valid-rec. 
 
*   (display batch # currently being processed) 
    display scr-test-batctrl-nbr. 
 
*	(if the current claim header that was read into the 'FD' area is not the correct 
*	batch number then read the header with the new batch number) 
 
    if    (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr      ) 
       or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
	perform xg0-read-claim		thru xg0-99-exit. 
*   (else) 
*   endif 
 
ga0-99-exit. 
    exit. 
ha0-rewrite-batctrl-file. 
 
*mf    rewrite batctrl-rec		key is key-batctrl-file 
*mf	invalid key 
*mf	    move 2			to err-ind 
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    rewrite batctrl-rec
	invalid key 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
ha0-99-exit. 
    exit. 
xa0-headings. 
 
    add 1				to ctr-page. 
    move ctr-page			to h1-page. 
 
    write print-record from h1-head after advancing page.    
 
    move 1				to ctr-line. 
  
xa0-99-exit. 
    exit. 
xb0-reset-values. 
 
    move "N"				to eof-claims-dtl. 
 
*********  allow don'T FORCE NEW PAGE FOR EVERY PRINTOUT -- 
*   move 65				to ctr-line. 
    move  1				to ctr-line. 
 
    move "Y"				to first-desc. 
 
xb0-99-exit. 
    exit. 
xe0-sel-read-next-batctrl. 
 
    move zero				to ctr-nbr-claims-in-batch. 
 
    read   batch-ctrl-file   next 
	at end 
	    move "Y"			to eof-batctrl-file 
	    go to xe0-99-exit. 
 
*mf    retrieve  batch-ctrl-file  key  fix position 
*mf	into key-batctrl-file. 
	 
* 2010/03/09 - MC1 - rewrite logic to include clinic 66 as well as clinic 70's 

**    if batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr 
* 2004/10/05 - MC
*      and sel-clinic-nbr < 60 
**      and (sel-clinic-nbr < 60 or sel-clinic-nbr > 65)
* 2004/10/05 - end

      if      (     batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr < 60
	      )
           or (     batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr
                and batctrl-bat-clinic-nbr-1-2 > 75
	      )
           or (     batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr = 60
                and batctrl-bat-clinic-nbr-1-2 > 66
	      )
           or (     batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and batctrl-bat-clinic-nbr-1-2 > 75
	      )
* 2010/03/09 - end 
    then 
	move "Y"			to eof-batctrl-file 
	move "N"			to flag-rec  
	go to xe0-99-exit. 
*   (else) 
*   endif 
 
    move "N"				to flag-rec. 
    perform xe1-select-batctrl-rec	thru xe1-99-exit. 
 
    if flag-rec = "N" 
    then 
	go to xe0-sel-read-next-batctrl. 
*    (else) 
*   endif 
 
*    (found appropriate batch to process) 
    perform xe2-batch-heading-info	thru xe2-99-exit. 
 
    add 1				to ctr-batctrl-file-reads. 
 
xe0-99-exit. 
    exit. 
xe1-select-batctrl-rec. 
 
    move "N"				to flag-rec. 
 
********************************************************************* 
*	(the batch is not verified  if --- 
 
*           1) the batch has been 'SENT TO OHIP' (status = 2) and the flag indicates 
*	       ohip sent batches are not to be processed) 
*	 or 2) batch status is 3 or greater 
*	 or 3) batch'S PERIOD END DATE DOESN't = constants master'S PERIOD END DATE )                     
********************************************************************* 
 
 
    if    batctrl-batch-status > "1" 
       and 
          batch-status-flag  = "N" 
    then 
	go to xe1-99-exit 
    else  
**********************************	if    (batctrl-batch-status > "2") 
	if    (batctrl-date-period-end not = iconst-date-period-end) 
	then 
	    go to xe1-99-exit 
	else 
	    next sentence. 
*	endif 
*   endif 
 
    move "Y"				to flag-rec. 
 
xe1-99-exit. 
    exit. 
xe2-batch-heading-info. 
 
    if batctrl-batch-type = "C" 
    then 
	move "CLAIMS"			to h1-batch-type 
    else 
	if batctrl-batch-type = "P" 
	then 
	    move "PAYMENT"		to h1-batch-type 
	else 
	    move "ADJUSTMENT"		to h1-batch-type. 
*	endif 
*   endif 
 
    move batctrl-bat-clinic-nbr-1-2	to h3-clinic1. 
    move batctrl-bat-doc-nbr		to h3-doc-nbr. 
    move batctrl-bat-week		to h3-week. 
    move batctrl-bat-day		to h3-day. 
 
xe2-99-exit. 
    exit. 
xg0-read-claim. 
 
    perform xg1-read-clmhdr		thru xg1-99-exit. 
 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
 
    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) 
      or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
* 	(no claims this year for batch) 
	move 9				to err-ind 
	move batctrl-batch-nbr		to miss-claim-nbr-9 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
xg0-99-exit. 
    exit. 
xg1-read-clmhdr. 
 
    move zero				to clmhdr-claim-id. 
    move batctrl-batch-nbr		to clmhdr-batch-nbr. 
    move zero				to clmhdr-claim-nbr. 
 
*mf    move "B"				to key-clm-key-type. 
*mf    move clmhdr-claim-id		to key-clm-data. 
    move "B"				to clmdtl-b-key-type. 
    move clmhdr-claim-id		to clmdtl-b-data. 
*************************************************************** 
*mf    move spaces				to key-clm-adj-nbr. 
    move spaces				to clmdtl-b-adj-nbr. 
*************************************************************** 
 
*mf    read claims-mstr key is key-claims-mstr approximate 
*mf	invalid key 
*mf	    move 8			to err-ind 
*mf	    move key-clm-data		to miss-claim-nbr-8 
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-end-of-job.  
 
    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key 
	    move 8			to err-ind 
	    move clmdtl-b-data		to miss-claim-nbr-8 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job.  
    read claims-mstr next.
 
    if status-cobol-claims-mstr =   23 
				 or 99 
    then 
	move 8				to err-ind 
*mf	move key-clm-data		to miss-claim-nbr-8 
	move clmdtl-b-data		to miss-claim-nbr-8 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*mf    retrieve claims-mstr key fix position 
*mf	into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move 8				to err-ind 
*mf	move key-clm-data		to miss-claim-nbr-8 
	move clmdtl-b-data		to miss-claim-nbr-8 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    add 1				to ctr-claims-mstr-reads. 
 
    move clmhdr-orig-batch-nbr		to hold-clmhdr-batch-nbr. 
    move clmhdr-orig-claim-nbr		to hold-clmhdr-claim-nbr. 
    move clmhdr-status-ohip		to hold-clmhdr-status-ohip. 
 
xg1-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    accept confirm. 
 
    if ws-reply = '!' 
    then 
	next sentence 
    else 
	go to za0-common-error. 
*   endif 
 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".