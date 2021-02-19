identification division. 
program-id. r002a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/01/31. 
date-compiled. 
security. 
* 
*    files      : f001  - batch control file 
*		: f002  - claim master 
*		: f010  - patient master 
*		: f090i - constants master 
*		: r002a - print report file 
* 
*    program purpose : balanced batch detail report.          
* 
*    rev. 85/02/15  i.w.  - verify the clmdtl-nbr-serv is numeric before 
*                           adding its value to total. 
* 
* 
*    rev. 85/11/11  m.s.  - add the patient mstr, move the pat ohip 
*			    id or chart id for reporting instead of 
*			    invisible key. 
* 
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*    may 2/89     s. fader      - sms 116 
*				- print the dept code and/or name 
* 
*    april/21 91  m. chan	- sms 138 
*				- take out 'F010_KEY_PAT_MSTR.WS' for 
*				  ambiguous reference purpose 
* 
*    nov/12/91	  m. chan	- pdr 433, 455, 515 (u802) 
*				- make sure report name is printed for 
*				  every page heading. modify subroutine 
*				  fa0 
* 
*    nov/17/91    m. chan	- om01 
*				- if pat-i-key does not exist in f010, 
*				  display missing pat-i-key and continue 
*				  the processing. 
* 
*    jan/17/96    yasemin 	- batctrl-batch-status from 1 to 1 or 2 
*	                          because, implementation of u010daily 
*
*    jan/29/98    j. chau       - s149 unix conversion
*
*  1999/jan/28    B. E.		- y2k
*  1999/Mar/19    S.B.		- Fix l2-svc-date-yy for y2k.
*  1999/jun/21    B.E.		- added better error messages in F010 declarative 
*				  section.
*  2003/dec/08    M.C.		- alpha doc nbr
*  2004/jun/01    M.C. 		- open f030-location-mstr, set l1-hosp based on criteria 
*  2011/Dec/12    MC1           - correct and split the error  message 8
*  2015/Dec/07    MC2  		- allow l1-day and l1-week to be alpha
*  2017/Jan/30    MC3  		- change amount field size for final total

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
    copy "f010_new_patient_mstr.slr". 
*
* 2004/06/01 - MC 
    copy "f030_locations_mstr.slr". 
* 2004/06/01 - end
* 
    copy "f090_constants_mstr.slr". 
* 
 
    select print-file-1 
          assign to printer print-file-name-1 
	  file status is status-prt-file-1. 
* 
    select print-file-2 
          assign to printer print-file-name-2 
	  file status is status-prt-file-2. 
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
    copy "f010_patient_mstr.fd". 
* 
* 2004/06/01 - MC
    copy "f030_locations_mstr.fd". 
* 2004/06/01 - end
* 
    copy "f090_constants_mstr.fd". 
* 
fd  print-file-1 
    record contains 132 characters. 
 
01  print1-record				pic x(132). 
 
fd  print-file-2 
    record contains 132 characters. 
 
01  print2-record				pic x(132). 
working-storage section. 
 
* 99/jun/21 B.E.
77  ws-blank-line                               pic x(79) value spaces.

77  ws-reply					pic x. 
77  err-ind					pic 99 	value zero. 
77  print-file-name-1				pic x(6) 
		value "r002aa". 
77  print-file-name-2				pic x(6)  
		value "r002ab". 
77  option					pic x. 
77  const-mstr-rec-nbr				pic x. 
77  difference					pic s9(7).  
77  diff					pic s9(7)v99. 
77  max-nbr-lines				pic 99	value 60. 
77  ctr-page-1					pic 9(4). 
77  ctr-page-2					pic 9(4). 
77  ctr-line					pic 999.       
77  nbr-lines-to-advance				pic 99. 
77  total-lines					pic 99. 
77  first-desc					pic x		value "Y". 
77  claim-nbr					pic 99. 
77  hold-clmhdr-status-ohip			pic xx. 
*!77  hold-clmhdr-batch-nbr			pic 9(9). 
77  hold-clmhdr-batch-nbr			pic x(8). 
77  hold-clmhdr-claim-nbr			pic 99. 
77  hold-clinic-nbr				pic 99. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-pat-mstr   			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  subs					pic 99   comp. 
77  subs-const					pic 99   comp. 
77  subs-hosp					pic 99   comp. 
77  act-sum-nbr-serv				pic 9(4) value 0. 
77  act-sum-fee-oma-ohip			pic s9(7)v99 value 0. 
77  claims-occur				pic 9(12). 
77  pat-occur   				pic 9(12). 
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
*mf 77  status-pat-mstr   			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 
 
77  common-status-file 				pic x(2).
77  status-cobol-batctrl-file			pic xx    value zero.
* 2004/06/01 - MC
77  status-cobol-loc-mstr			pic xx    value zero.
* 2004/06/01 - end
77  status-cobol-iconst-mstr			pic xx    value zero.
77  status-cobol-claims-mstr			pic xx	  value zero. 

* 99/jun/21 B.E.
*77  status-cobol-pat-mstr   			pic xx	  value zero. 
77  status-file                                 pic xx    value zero.
01  file-status-variables.
copy "status_cobol_pat_mstr.ws".
copy "status_cobol_display.ws".

77  status-prt-file-1				pic xx 	  value zero. 
77  status-prt-file-2				pic xx    value zero. 

01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-rec					pic x. 
    88  valid-rec				value "Y". 
    88  invalid-rec				value "N". 
 
01  last-page-flag 				pic x. 
    88  last-page				value "Y". 
    88  not-last-page				value "N". 
 
*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
*copy "F010_KEY_PAT_MSTR.WS". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-reads   			pic 9(7). 
    05  ctr-fee-oma				pic s9(5)v99. 
    05  ctr-fee-ohip				pic s9(5)v99. 
 
 
* 2004/06/01 - MC - comment the following 2 copybooks
*   copy "hospital.dc". 
*   copy "hosp_table.ws". 
* 2004/06/01 - end
 
 
01  tbl-totals. 
    05  tbl-bat-type-and-tots	occurs   8  times. 
	10  tbl-agent-and-sums	occurs  11  times. 
	    15  tbl-item	occurs  10  times. 
		20  tbl-tot		pic s9(9)v99. 
*	(access using tbl-tot (ss-type, ss-agent, ss-item))      
01  tbl-totals-variable-ss. 
*mf   ss-temp1 
    05  ss-temp1			pic 99.
    05  ss-type				pic 99. 
    05  ss-agent			pic 99.   
    05  ss-item				pic 9. 
 
    05  ss-type-from			pic 99. 
    05  ss-type-to			pic 99. 
    05  ss-agent-from			pic 99. 
    05  ss-agent-to			pic 99. 
 
*	(maximums for subscripts) 
    05  max-nbr-types			pic 99	value  6.  
    05  max-nbr-agents			pic 99	value 10. 
*   05  max-nbr-items			pic 99	value 10. 
 
 
***  subscripts for 'TBL-TOTALS'. 
01  ss-tbl-totals. 
*     (subscripts for  'TBL-BAT-TYPE-AND-TOTS') 
    05  ss-claims			pic 99	value  1. 
    05  ss-adj-a			pic 99	value  2. 
    05  ss-adj-b			pic 99	value  3. 
    05  ss-adj-r			pic 99	value  4. 
    05  ss-pay-m			pic 99	value  5. 
    05  ss-pay-c			pic 99	value  6. 
    05  ss-type-tot			pic 99	value  7. 
    05  ss-grand-tot			pic 99	value  8. 
*	  (subscripts for  'TBL-AGENT-AND-SUMS') 
*	 -- values 1 thru 10 are obtained using (agent code + 1) 
	05  ss-agent-tot		pic 99	value 11. 
*	      (subscripts for  'TBL-ITEM') 
*	       (values 1 thru 5 used for batch control file totals) 
*	       (values 6 thru 10 (obtained by adding variable offset) are 
*	        used for claim header totals.) 
 
	    05  ss-net-a-r		pic 9	value  1. 
	    05  ss-net-rev		pic 9	value  2. 
	    05  ss-cash			pic 9	value  3. 
	    05  ss-nbr-claims		pic 9	value  4. 
	    05  ss-nbr-svcs		pic 9	value  5. 
	    05  ss-offset		pic 9	value  5. 
	    05  ss-batctrl-offset	pic 9	value  0. 
	    05  ss-clmhdr-offset	pic 9	value  5. 
*		( variable offset ) 
	    05  batctrl-clm-offset  	pic 9. 
 
 
 
01  tbl-batch-type-desciptions. 
    05  tbl-batch-type-descs. 
        10  filler			pic x(18)  value 
		"CLAIMS          ". 
        10  filler			pic x(18)  value 
		"ADJUSTMENTS- 'A'". 
	10  filler			pic x(18)  value 
		"ADJUSTMENTS- 'B'". 
	10  filler			pic x(18)  value     
		"ADJUSTMENTS- 'R'". 
	10  filler			pic x(18)  value    
		"PAYMENTS   - 'M'". 
	10  filler			pic x(18)  value           
		"PAYMENTS   - 'C'". 
	10  filler			pic x(18)  value           
		"                ". 
	10  filler			pic x(18)  value           
		"GRAND TOTALS    ". 
    05  tbl-batch-type-descs-r	redefines   tbl-batch-type-descs. 
        10  batch-descs		occurs  8  times. 
	    15  desc-bat-type		pic x(13). 
	    15  desc-adj-type		pic x(5). 
 
*   (tested to allow totals line to be surpressed if not detail lines 
*    have been printed) 
 
77  sw-printed-bat-type				pic x. 
77  sw-printed-adj-type				pic x. 
01  final-totals. 
 
    05  fin-tot-1			pic s9(9)v99. 
    05  fin-tot-2			pic s9(9)v99. 
    05  fin-tot-3			pic s9(9)v99. 
    05  fin-tot-4			pic s9(9)v99. 
    05  fin-tot-5			pic s9(9)v99. 
    05  fin-tot-6			pic s9(9)v99. 
    05  fin-tot-7			pic s9(9)v99. 
    05  fin-tot-8			pic s9(9)v99. 
    05  fin-tot-9			pic s9(9)v99. 
    05  fin-tot-10			pic s9(9)v99. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"INVALID READ ON CONSTANTS MASTER". 
	10  filler				pic x(60)   value 
			"INVALID CLINIC NBR". 
	10  filler				pic x(60)   value 
			"NO BATCTRL FILE SUPPLIED".    
	10  filler				pic x(60)   value 
			"****   CAN BE RE-USED   ****". 
	10  filler				pic x(60)   value 
			"NO SUITABLE BATCHES IN BATCTRL FILE". 
	10  filler				pic x(60)   value 
			"NO CLAIMS FOR THIS CLINIC". 
        10  batch-miss-err.
            15  filler                          pic x(41)  value
                "NO CLAIM FOR CURRENT BATCH - F001/F002 = ".
* 2011/12/12 - MC1
*           15  miss-claim-nbr                  pic 9(9).
*           15  filler                          pic x(8)  value spaces.
            15  miss-batch-nbr                  pic x(8).
            15  filler                          pic x value '/'.
            15  miss-f002-batch-nbr             pic x(8).
            15  miss-claim-nbr                  pic 99.
* 2011/12/12- end

* 
*       (the following error message is added on 85/11/11 by m.s.) 
* 
	10  filler				pic x(60)   value 
			"INVALID READ ON PATIENT MSTR". 
* 2011/12/12/ - MC1 - add new edit
        10  wrong-claim-err.
            15  filler                          pic x(32)  value
                "DIFFERENT PED - F001/F002 = ".
            15  wrong-batch-nbr                 pic x(8).
            15  wrong-claim-nbr                 pic 99.
            15  filler                          pic x value '/'.
            15  wrong-f001-ped                  pic x(8).
            15  filler                          pic x value '/'.
            15  wrong-f002-ped                  pic x(8).
* 2011/12/12- end
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 10 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  h1-head. 
 
    05  h1-rpt-name				pic x(6). 
    05  filler					pic x		value "/". 
    05  h1-clinic-nbr				pic zz. 
    05  filler					pic x(5)	value spaces. 
    05  filler					pic x(13)	value 
		"BATCH TYPE - ". 
    05  h1-batch-type				pic x(10).     
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(55)	value      
		"  BALANCED  BATCH DETAIL REPORT". 
    05  filler					pic x(9)	value 
		"RUN DATE". 
* (y2k)
*   05  h1-run-yy				pic x(2). 
    05  h1-run-yy				pic x(4). 
    05  filler					pic x		value '/'. 
    05  h1-run-mm				pic xx. 
    05  filler					pic x		value '/'. 
    05  h1-run-dd				pic xx. 
* (y2k)
*   05  filler					pic x(6)	value spaces. 
    05  filler					pic x(4)	value spaces. 
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
    05  h3-cycle				pic zzz. 
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
* (y2k - auto fix)
*   05  h3-period-end-yy			pic 99 	blank when zero. 
    05  h3-period-end-yy			pic 9(4) 	blank when zero. 
    05  filler					pic x		value "/". 
    05  h3-period-end-mm			pic 99 	blank when zero. 
    05  filler					pic x		value "/". 
    05  h3-period-end-dd			pic 99	blank when zero. 
    05  filler					pic x(4)	value spaces. 
 
01  h4-head. 
 
    05  filler					pic x(30)	value 
		"   CLAIM       PATIENT     PAT". 
    05  filler					pic x(30)	value 
		"IENT ID/   DOCTOR  REF DR  HOS". 
    05  filler					pic x(30)	value 
		"P    LOCATION AG  P  DIAG   RE". 
    05  filler					pic x(42)	value 
		"FERENCE  ADM DATE". 
 
 
 
01  h5-head. 
 
    05  filler					pic x(30)	value 
		"  NUMBER    DP ACRONYM     CHA". 
    05  filler					pic x(30)	value 
		"RT NUMBER    NBR  (CONSEC. DAT". 
    05  filler					pic x(30)	value 
		"E)    OMA CD  AJ     CODE   RS". 
    05  filler					pic x(30)	value 
		"N & SRV  SVC DATE     OMA". 
    05  filler					pic x(12)	value 
		" OHIP". 
 
 
 
01  t1-head. 
 
    05  filler					pic x(47)	value spaces. 
    05  filler					pic x(13)	value 
		"NUMBER". 
    05  filler					pic x(72)	value 
		"TOTAL". 
 
 
 
01  t2-head. 
 
    05  filler					pic x(49)	value spaces. 
    05  filler					pic x(12)	value 
		"OF". 
    05  filler					pic x(71)	value 
		"OF $". 
 
 
 
01  t3-head. 
 
    05  filler					pic x(46)	value spaces. 
    05  filler					pic x(14)	value 
		"SERVICES". 
    05  filler					pic x(72)	value 
		"INPUT". 
 
01  t4-head. 
 
    05  filler					pic x(2)	value spaces. 
    05  filler					pic x(8)	value 
		"CLINIC". 
    05  t4-clinic-nbr				pic zz. 
    05  filler					pic x(13)	value spaces. 
    05  filler					pic x(15)	value 
		"---------------". 
    05  filler					pic x(22)	value 
		"BATCH   CONTROL   FILE". 
    05  filler					pic x(19)	value 
		"-------------". 
    05  filler					pic x(18)	value 
		"------------------". 
    05  filler					pic x(33)	value 
		"CLAIMS   MASTER-----------------". 
01  t5-head. 
 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(8)	value 
		"AGENT".  
    05  filler					pic x(13)	value 
		"NET A/R".  
    05  filler					pic x(16)	value 
		" NET REV". 
    05  filler					pic x(8)	value 
		"CASH". 
    05  filler					pic x(8)	value 
		"CLAIMS". 
    05  filler					pic x(11)	value 
		"SVC'S". 
    05  filler					pic x(13)	value 
		"NET A/R". 
    05  filler					pic x(16)	value 
		" NET REV". 
    05  filler					pic x(8)	value 
		"CASH". 
    05  filler					pic x(8) 	value 
		"CLAIMS". 
    05  filler					pic x(6)	value 
		"SVC'S". 
01  print-line. 
 
    05  l1-print-line. 
	10  l1-batch-nbr. 
	    15  l1-clinic1			pic 99. 
*!	    15  l1-doc-nbr			pic 9(3). 
	    15  l1-doc-nbr			pic x(3). 
* MC2	    
*	    15  l1-week				pic 99. 
*    	    15  l1-day				pic 9. 
     	    15  l1-week				pic xx. 
	    15  l1-day				pic x.
* MC2 - end
	10  l1-dash				pic x. 
	10  l1-claim-nbr			pic 9(2). 
	10  l1-slash				pic x. 
	10  l1-doc-dept 			pic 99. 
	10  filler				pic x. 
	10  l1-patient-acronym. 
	    15  l1-patient-acronym6		pic x(7). 
	    15  l1-patient-acronym3		pic x(5). 
	10  l1-pat-id-chart-id			pic x(16). 
*!	10  l1-doc-nbr2				pic 9(3)  blank when zero. 
	10  l1-doc-nbr2				pic x(3).
	10  filler				pic x(3). 
	10  l1-refer-doc-nbr			pic 9(6)  blank when zero. 
	10  filler				pic xx. 
* 2004/06/01 - MC
*	10  l1-hosp				pic 9(4)  blank when zero. 
	10  l1-hosp				pic x(4).                    
* 2004/06/01 - end
	10  filler				pic x(5). 
	10  l1-location				pic x999. 
	10  filler				pic x(5). 
	10  l1-agent-cd				pic 9. 
	10  filler				pic x(2). 
	10  l1-pat-in-out			pic x. 
	10  filler       			pic x(9). 
 
	10  l1-reference			pic x(11). 
	10  l1-admit-date. 
* (y2k)
*	    15  l1-admit-date-yy		pic 99. 
	    15  l1-admit-date-yy		pic 9(4). 
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
 	10  filler				pic x(47). 
	10  l2-consecutive-dates occurs 3 times. 
	    15  l2-sv-nbr			pic z9   blank when zero. 
	    15  filler				pic x. 
	    15  l2-sv-day			pic 99   blank when zero. 
	    15  l2-sv-day-alpha redefines l2-sv-day 
						pic xx. 
	    15  filler				pic x. 
 	10  filler				pic x. 
	10  l2-oma-cd				pic x999. 
	10  l2-oma-suff				pic x(5). 
	10  l2-adj-cd				pic x(3). 
	10  l2-card-colour			pic x(3). 
        10  filler                              pic x. 
        10  l2-diag-code                        pic 9(3) blank when zero. 
        10  filler                              pic x(3). 
	10  l2-rsn				pic xx. 
	10  filler				pic x(4). 
	10  l2-srv				pic 99. 
	10  filler				pic x(3). 
	10  l2-svc-date. 
* (y2k)
*	    15  l2-svc-date-yy			pic 99. 
	    15  l2-svc-date-yy			pic 9(4).
	    15  l2-slash1			pic x. 
	    15  l2-svc-date-mm			pic 99. 
	    15  l2-slash2			pic x. 
	    15  l2-svc-date-dd			pic 99. 
	10  filler				pic x. 
	10  l2-fee-oma				pic zz,zzz.99-. 
	10  filler				pic x(2). 
	10  l2-fee-ohip				pic zz,zzz.99-. 
	10  filler				pic x(2). 
    05  l3-print-line redefines l2-print-line. 
	10  filler				pic x(108). 
	10  l3-fee-total-oma			pic zz,zzz.99-. 
	10  filler				pic x(2).   
	10  l3-fee-total-ohip			pic zz,zzz.99-. 
	10  filler				pic x(2). 
    05  l4-print-line redefines l3-print-line. 
	10  l4-claim-desc			pic x(45). 
	10  filler				pic x(87). 
    05  t1-print-line redefines l4-print-line. 
	10  filler				pic x(25). 
	10  t1-total-lit			pic x(22). 
	10  t1-nbr-services			pic zz,zz9-. 
	10  filler				pic x(2). 
	10  t1-amt-input			pic z,zzz,zzz.99-. 
	10  filler				pic x(63). 
    05  t2-print-line  redefines   t1-print-line. 
        10  t2-desc. 
	    15  t2-desc-a			pic x(13). 
	    15  t2-desc-b			pic x(5). 
        10  t2-dash				pic x. 
        10  filler				pic x. 
        10  t2-agent-cd				pic 9. 
* MC3
*        10  filler				pic x(1).     
*        10  t2-detail-1			pic zzzz,zz9.99-. 
*        10  filler				pic x(1). 
*        10  t2-detail-2			pic zzzz,zz9.99-. 
        10  t2-detail-1				pic zzzzz,zz9.99-. 
        10  t2-detail-2				pic zzzzz,zz9.99-. 
* MC3 - end
        10  filler				pic x(1). 
        10  t2-detail-3				pic zzzz,zz9.99-. 
        10  filler				pic x(1). 
        10  t2-detail-4				pic zzz,zz9. 
        10  filler				pic x(1). 
        10  t2-detail-5				pic zzz,zz9. 
* MC3
*        10  filler				pic x(2). 
*        10  t2-detail-6			pic zzzz,zz9.99-. 
*        10  filler				pic x(1).  
*        10  t2-detail-7			pic zzzz,zz9.99-. 
        10  filler				pic x(1). 
        10  t2-detail-6				pic zzzzz,zz9.99-. 
        10  t2-detail-7				pic zzzzz,zz9.99-. 
* MC3 - end
        10  filler				pic x(1). 
        10  t2-detail-8				pic zzzz,zz9.99-. 
        10  filler				pic x(1). 
        10  t2-detail-9				pic zzz,zz9. 
        10  filler				pic x(1). 
        10  t2-detail-10			pic zzz,zz9. 
 
 
 
01  blank-line					pic x(132). 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05			line 12 col 30 value is "CONTINUE (Y/N) ?". 
    05  scr-reply	line 12 col 47 pic x to ws-reply auto required. 
 
01  scr-prog-in-prog. 
 
    05  line 14 col 30 value is "R002A IN PROGRESS". 
 
 
*                     
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from common-status-file    bell blink. 
    05  line 24 col 70 pic x(2) from common-status-file    bell blink. 
* 
01  file-pat-status-display. 
    05  line 24 col 01 "ERROR IN ACCESSING PAT MSTR - KEY = ". 
    05  line 24 col 38 pic x(16) from key-pat-mstr. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from common-status-file    bell blink. 
    05  line 24 col 70 pic x(2) from common-status-file    bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  7 col 20  value "NUMBER OF BATCTRL-FILE ACCESSES = ". 
    05  line  7 col 60  pic 9(7) from ctr-batctrl-file-reads. 
    05  line  9 col 20  value "NUMBER OF CLMHDR ACCESSES = ". 
    05  line  9 col 60  pic 9(7) from ctr-claims-mstr-reads. 
    05  line 11 col 20  value "NUMBER OF PATIENT MSTRACCESSES = ". 
    05  line 11 col 60  pic 9(7) from ctr-pat-mstr-reads. 
    05  line 21 col 20	value "PROGRAM R002A ENDING". 
* (y2k - auto fix)
*   05  line 21 col 41  pic 99	from sys-yy. 
    05  line 21 col 41  pic 9(4)	from sys-yy. 
    05  line 21 col 45	value "/". 
    05  line 21 col 46	pic 99	from sys-mm. 
    05  line 21 col 48	value "/". 
    05  line 21 col 49	pic 99	from sys-dd. 
    05  line 21 col 53	pic 99	from sys-hrs. 
    05  line 21 col 55	value ":". 
    05  line 21 col 56	pic 99	from sys-min.        
    05  line 23 col 20	value "PRINT REPORTS FOUND IN - ". 
    05  line 23 col 45	pic x(6)  from print-file-name-1. 
    05  line 23 col 52	pic x(6)  from print-file-name-2.  
 
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
*mf    move status-iconst-mstr		to common-status-file. 
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
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*mf    move status-pat-mstr             to common-status-file.
*    move status-cobol-pat-mstr                 to common-status-file.
*    display file-pat-status-display.
    move status-cobol-pat-mstr          to status-file.
*   display file-status-display.
    display " " at 0101.

    move status-cobol-pat-mstr1           to status-cobol-display1.
    if   status-cobol-pat-mstr1 <> 9
    then
        move status-cobol-pat-mstr2       to status-cobol-display2
    else
        move low-values                   to status-cobol-pat-mstr1
        move status-cobol-pat-mstr-binary to status-cobol-display2.
*   endif
    display ws-blank-line        at 2201.
    display status-cobol-display at 2201,  "= PATIENT status code".
 
    display ws-blank-line at 2201.
    display key-pat-mstr  at 2201, "=PATIENT KEY".
 
    display ws-blank-line at 2201.
    display clmhdr-orig-batch-id at 2201, "= clmhdr orig batch id".
 
    stop "HIT NEWLINE TO CONTINUE".
 
*   stop "PROGRAM ABORTED - HIT NEWLINE".
*   stop run.
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru 	aa0-99-exit. 
    perform ab0-processing		thru 	ab0-99-exit. 
    perform az0-end-of-job		thru 	az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from 	date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to 	run-mm.                 
    move sys-dd				to 	run-dd. 
    move sys-yy				to 	run-yy. 
 
    accept sys-time			from 	time. 
    move sys-hrs			to 	run-hrs. 
    move sys-min			to 	run-min. 
    move sys-sec			to 	run-sec. 
 
*	(display screen title/option) 
 
    display scr-title. 
aa0-10-continue-y-n. 
 
    move "Y"				to	ws-reply.
*   accept scr-reply. 
 
    if ws-reply =   "Y" 
		 or "N" 
    then 
	if ws-reply = "Y" 
	then 
	    next sentence 
	else 
*	    (shut down) 
	    stop run 
*	endif 
    else 
	move 1				to 	err-ind 
	perform za0-common-error	thru 	za0-99-exit 
	go to aa0-10-continue-y-n.  
*   endif 
 
    display scr-prog-in-prog. 
 
 
*	(delete print file) 
*    expunge print-file-1 
*mf	     print-file-2. 
 
    open input	batch-ctrl-file 
		claims-mstr 
		pat-mstr 
* 2004/06/01 - MC
		loc-mstr
* 2004/06/01 - end
		iconst-mstr. 
    open output print-file-1 
		print-file-2. 
 
    move zero				to 	counters  
					   	claim-nbr 
					   	ctr-page-1 
					   	ctr-page-2 
					   	tbl-totals. 
    move "N"				to 	last-page-flag. 
    perform xb0-reset-batch-totals	thru	xb0-99-exit. 
    move spaces				to 	print-line 
					   	blank-line. 
 
    move run-yy				to 	h1-run-yy. 
    move run-mm				to 	h1-run-mm. 
    move run-dd				to 	h1-run-dd. 
 
 
*mf    move zero				to 	key-batch-nbr.     
 
*mf    read batch-ctrl-file key is key-batctrl-file approximate 
*mf	invalid key 
*mf	    move 4			to 	err-ind 
*mf	    perform za0-common-error	thru 	za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    
*!       move zero			to batctrl-batch-nbr.
       move spaces 			to batctrl-batch-nbr.

       start batch-ctrl-file key is greater than or equal to key-batctrl-file
	invalid key 
	    move 4			to 	err-ind 
	    perform za0-common-error	thru 	za0-99-exit 
	    go to az0-end-of-job. 
 
     read batch-ctrl-file next 
	at end 
	    move 6			to 	err-ind 
	    move "Y"			to 	eof-batctrl-file 
	    go to aa1-99-exit. 
	 
    
    add 1				to 	ctr-batctrl-file-reads. 
 
    perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = "Y" 
    then 
	perform za0-common-error	thru 	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    move ss-batctrl-offset		to   	batctrl-clm-offset. 
    perform sa2-add-batch-totals	thru 	sa2-99-exit. 
 
    perform xd0-hold-clinic-info	thru	xd0-99-exit. 
 
    perform aa11-read-claim		thru 	aa11-99-exit. 
 
aa0-99-exit. 
    exit. 
aa1-sel-read-next-batctrl. 
 
***************************************************************** 
*	(note is the only logic difference from r002a and r002b) 
***************************************************************** 
*	(select balanced batches) 
    if    batctrl-batch-status =    "1" 
       or batctrl-batch-status =    "2" 
    then 
	move "Y"			to 	flag-rec 
	perform xc0-batch-heading-info	thru 	xc0-99-exit 
	go to aa1-99-exit. 
*   (else) 
*   endif 
 
    read batch-ctrl-file next 
	at end 
	    move 6			to 	err-ind 
	    move "Y"			to 	eof-batctrl-file 
	    go to aa1-99-exit. 
	 
    add 1				to 	ctr-batctrl-file-reads. 
 
aa1-99-exit. 
    exit. 
 
 
aa11-read-claim. 
 
    perform aa2-read-clmhdr		thru 	aa2-99-exit. 
 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
 
* 2011/12/12 - MC1 - split / correct error 8 into error 8 & 10

*    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)
*      or (clmhdr-date-period-end not = batctrl-date-period-end)
*    then
*       (no claims)
*       move 8                          to      err-ind
*       move batctrl-batch-nbr          to      miss-claim-nbr
*       perform za0-common-error        thru    za0-99-exit
*       go to az0-end-of-job.
*   (else)
*   endif

    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)
    then
*       (no claims for the batch)
        move 8                          to      err-ind
        move batctrl-batch-nbr          to      miss-batch-nbr
        move clmhdr-orig-batch-nbr      to      miss-f002-batch-nbr
        move clmhdr-orig-claim-nbr      to      miss-claim-nbr
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   (else)
*   endif

    if   (clmhdr-date-period-end not = batctrl-date-period-end)
    then
*       (wrong claim for different ped)
        move 10                         to      err-ind
        move batctrl-batch-nbr          to      wrong-batch-nbr
        move clmhdr-orig-claim-nbr      to      wrong-claim-nbr
        move batctrl-date-period-end    to      wrong-f001-ped
        move clmhdr-date-period-end     to      wrong-f002-ped
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   (else)
*   endif
* 2011/12/12 - end


 
aa11-99-exit. 
    exit. 
 
 
 
aa2-read-clmhdr. 
 
    move 0				to 	clmhdr-claim-id. 
    move batctrl-batch-nbr		to 	clmhdr-batch-nbr. 
    move 1				to 	clmhdr-claim-nbr. 
 
*mf    move "B"				to 	key-clm-key-type. 
*mf    move clmhdr-claim-id		to 	key-clm-data. 
 
*mf    read claims-mstr key is key-claims-mstr approximate 
*mf	invalid key 
*mf	    move 7			to 	err-ind 
*mf	    perform za0-common-error	thru 	za0-99-exit 
*mf	    go to az0-end-of-job.  
    
    move "B"				to 	clmdtl-b-key-type.
    move clmhdr-claim-id		to	clmdtl-b-data.

    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key 
	    move 7			to 	err-ind 
	    display key-claims-mstr
	    stop " "
	    perform za0-common-error	thru 	za0-99-exit 
	    go to az0-end-of-job.  
    
    read claims-mstr next 
	at end 
	    move "Y"			to 	eof-claims-dtl 
	    move "Y"			to 	eof-claims-mstr 
	    go to da0-99-exit. 
 
 

*mf    if status-cobol-claims-mstr =   23 
*mf    				 or 99 
*mf    then 
*mf    	move 7				to 	err-ind 
*mf	perform za0-common-error	thru 	za0-99-exit 
*mf	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*mf    retrieve claims-mstr key fix position into key-claims-mstr.
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B"
    then 
	move 7				to 	err-ind 
	perform za0-common-error	thru 	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    add 1				to 	ctr-claims-mstr-reads. 
 
    move clmhdr-orig-batch-nbr		to 	hold-clmhdr-batch-nbr. 
    move clmhdr-orig-claim-nbr		to 	hold-clmhdr-claim-nbr. 
    move clmhdr-status-ohip		to 	hold-clmhdr-status-ohip. 
 
aa2-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform xc1-add-to-fin-totals 	thru	xc1-99-exit. 
    perform ze0-move-and-print-fin-tot	thru	ze0-99-exit. 
 
    close batch-ctrl-file 
	  claims-mstr 
	  pat-mstr 
* 2004/06/01 - MC
          loc-mstr
* 2004/06/01 - end
	  iconst-mstr 
	  print-file-1 
	  print-file-2. 
 
    display blank-screen. 
    accept sys-time			from 	time. 
    display scr-closing-screen. 
 
*   call program "menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
    if clmhdr-orig-batch-nbr = "220900630"
    then
	next sentence.
 
    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) 
      or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
	perform fa0-print-and-zero-batch-tots 
					thru	fa0-99-exit  
	perform ga0-read-next-batch	thru 	ga0-99-exit 
	if eof-batctrl-file = "Y" 
	then 
	    perform xe0-print-clinic-totals 
					thru	xe0-99-exit 
	    go to ab0-99-exit 
	else 
	    perform xb0-reset-batch-totals 
					thru 	xb0-99-exit   
	    if batctrl-bat-clinic-nbr-1-2  not = hold-clinic-nbr 
	    then 
		perform xe0-print-clinic-totals 
					thru	xe0-99-exit 
		perform xc1-add-to-fin-totals 
					thru	xc1-99-exit 
		perform xf0-zero-clinic-totals 
					thru	xf0-99-exit 
		perform xd0-hold-clinic-info 
					thru    xd0-99-exit 
		perform xc0-batch-heading-info 
					thru	xc0-99-exit 
		move ss-batctrl-offset	to   	batctrl-clm-offset 
		perform sa2-add-batch-totals 
					thru 	sa2-99-exit  
	    else 
		move ss-batctrl-offset	to   	batctrl-clm-offset 
		perform sa2-add-batch-totals 
					thru 	sa2-99-exit  
*	    endif 
    else 
	next sentence. 
*   endif 
 
    perform ca1-move-print-hdr		thru 	ca1-99-exit. 
 
    move "N"				to 	eof-claims-dtl. 
    move "Y"				to 	first-desc. 
 
ab0-10-claim-loop. 
 
    perform da0-read-dtl-next-clm	thru 	da0-99-exit. 
 
    if eof-claims-dtl = "N" 
    then 
	perform da1-move-print-dtl	thru 	da1-99-exit 
	go to ab0-10-claim-loop. 
*   (else) 
*   endif 
 
    if first-desc = "Y" 
    then 
	perform ea0-print-claims-totals	thru 	ea0-99-exit. 
*   (else) 
*   endif 
 
    if eof-claims-mstr = "N" 
    then 
	go to ab0-processing 
    else 
	perform fa0-print-and-zero-batch-tots 
					thru 	fa0-99-exit 
	perform xe0-print-clinic-totals	thru 	xe0-99-exit. 
*   endif 
 
ab0-99-exit. 
    exit. 
ac0-check-nbr-claims-field. 
 
    if    batctrl-nbr-claims-in-batch not numeric 
      or  batctrl-nbr-claims-in-batch = zero 
    then 
	move batctrl-last-claim-nbr	to	batctrl-nbr-claims-in-batch. 
*   (else) 
*   endif 
 
ac0-99-exit. 
    exit. 
ba0-write-detail-line. 
 
    add nbr-lines-to-advance		to 	ctr-line. 
    if ctr-line > max-nbr-lines 
    then 
	perform xa0-headings		thru 	xa0-99-exit. 
*   (else) 
*   endif 
 
    write print1-record    from print-line after advancing nbr-lines-to-advance line. 
    move spaces				to 	print-line. 
    move 0				to	nbr-lines-to-advance. 
 
ba0-99-exit. 
    exit. 
ca0-read-next-batctrl. 
 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
 
    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) 
      or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
	perform fa0-print-and-zero-batch-tots 
					thru 	fa0-99-exit  
	perform ga0-read-next-batch	thru 	ga0-99-exit 
 
	if eof-batctrl-file = "Y" 
	then 
	    go to ca0-99-exit 
	else 
	    perform xb0-reset-batch-totals 
					thru 	xb0-99-exit 
	    perform xa0-headings	thru 	xa0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
    perform ca1-move-print-hdr		thru 	ca1-99-exit. 
 
ca0-99-exit. 
    exit. 
ca1-move-print-hdr. 
 
*   (this routine is enetered only if the claim read belongs to the 
*    batch read--ie  the batch # and p.e.d. are the same for both the 
*    batctrl record and the claim header record.) 
 
    move ss-clmhdr-offset		to	batctrl-clm-offset. 
    perform sa0-add-clmhdr-totals	thru	sa0-99-exit. 
 
*	(if not enough lines to print average size claim then print headings) 
    if ctr-line + 7  > max-nbr-lines 
    then 
        perform xa0-headings		thru 	xa0-99-exit.  
*   (else) 
*   endif 
 
*	(if adjustment batch, then extra line is printed before normal clmhdr data is printed 
*	  -- 1st line shows the adjustment'S ORIGINATING BATCH NBR , LINE 2 SHOWS THE  
*	     batch number of claim being adjusted) 
    if batctrl-batch-type =    "P" 
			    or "A" 
    then 
	move clmhdr-orig-batch-nbr-1-2	to 	l1-clinic1 
	move clmhdr-orig-batch-nbr-4-6	to 	l1-doc-nbr 
	move clmhdr-orig-batch-nbr-7-8	to 	l1-week 
	move clmhdr-orig-batch-nbr-9	to 	l1-day 
	move "-"			to 	l1-dash 
	move clmhdr-orig-claim-nbr	to 	l1-claim-nbr 
	move 2				to 	nbr-lines-to-advance 
	perform ba0-write-detail-line	thru 	ba0-99-exit 
 
	move 1				to 	nbr-lines-to-advance 
    else 
	move 2				to 	nbr-lines-to-advance. 
*   endif 
 
    move clmhdr-clinic-nbr-1-2		to 	l1-clinic1. 
    move clmhdr-doc-nbr			to 	l1-doc-nbr. 
    move clmhdr-day			to 	l1-day. 
    move clmhdr-week			to 	l1-week. 
    move "-"				to 	l1-dash. 
    move clmhdr-claim-nbr		to 	l1-claim-nbr. 
    move "/"  				to	l1-slash. 
    move clmhdr-doc-dept		to	l1-doc-dept. 
    move clmhdr-pat-acronym6		to 	l1-patient-acronym6. 
    move clmhdr-pat-acronym3		to 	l1-patient-acronym3. 
* 
*   (the following statement is commented on 85/11/11 by m.s. , 
*    and it is replaced by the next two statements.) 
* 
*   move clmhdr-pat-key-data		to 	l1-pat-id-chart-id. 
    if clmhdr-pat-key-data = spaces or " " 
    then 
	move spaces         		to 	l1-pat-id-chart-id 
    else 
	perform ya0-read-pat		thru  	ya0-99-exit. 
*   endif 
 
    move clmhdr-doc-nbr			to 	l1-doc-nbr2. 
    move clmhdr-refer-doc-nbr		to 	l1-refer-doc-nbr. 
    perform ca11-move-hosp		thru 	ca11-99-exit. 
    move clmhdr-loc			to 	l1-location. 
    move clmhdr-agent-cd		to 	l1-agent-cd. 
    move clmhdr-i-o-pat-ind		to 	l1-pat-in-out. 
    move clmhdr-reference		to 	l1-reference. 
 
    move clmhdr-date-admit-yy		to 	l1-admit-date-yy. 
    move "/"				to 	l1-slash1 
					   	l1-slash2. 
    move clmhdr-date-admit-mm		to 	l1-admit-date-mm. 
    move clmhdr-date-admit-dd		to 	l1-admit-date-dd. 
    move "("				to 	l1-brace-l1. 
    move clmhdr-tot-claim-ar-oma	to 	l1-ar-oma. 
    move ")"				to 	l1-brace-r1. 
    move "("				to 	l1-brace-l2. 
    move clmhdr-tot-claim-ar-ohip	to 	l1-ar-ohip. 
    move ")"				to 	l1-brace-r2. 
 
*	( for 'C'laim batches the 'OMA' value is reported 
*	  while for 'P'ayment and 'A'djustment batches the 
*	  'OHIP' amount is reported ) 
    if batctrl-batch-type = 'C' 
    then 
	add clmhdr-tot-claim-ar-oma	to 	act-sum-fee-oma-ohip 
    else 
	add clmhdr-tot-claim-ar-ohip	to 	act-sum-fee-oma-ohip. 
*   endif 
 
    perform ba0-write-detail-line	thru 	ba0-99-exit. 
 
ca1-99-exit. 
    exit. 
 
 
* 2004/06/01 - MC 
*   copy "hosp_nbr_code_to_nbr.rtn". 

ca11-move-hosp.      

    move clmhdr-loc  			to loc-nbr.  

    read loc-mstr
        invalid key
            move spaces                 to l1-hosp      
            go to ca11-99-exit.

    if iconst-clinic-card-colour = 'Y'
    then
        move loc-hospital-code          to l1-hosp
    else
        move loc-hospital-nbr           to l1-hosp.
*   endif

ca11-99-exit.
    exit.
* 2004/06/01- end 

da0-read-dtl-next-clm. 
 
    read claims-mstr next 
	at end 
	    move "Y"			to 	eof-claims-dtl 
	    move "Y"			to 	eof-claims-mstr 
	    go to da0-99-exit. 
 
*mf    retrieve claims-mstr key fix position into key-claims-mstr.
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B"
    then 
	move "Y"			to 	eof-claims-dtl 
	move "Y"			to 	eof-claims-mstr 
	go to da0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to 	ctr-claims-mstr-reads. 
 
*	skip adjustment detail records 
    if    clmdtl-adj-nbr not = 0 
      and batctrl-batch-type = "C" 
    then 
	go to da0-read-dtl-next-clm. 
*   (else) 
*   endif 
 
    if clmhdr-zeroed-area is numeric 
    then 
	if clmhdr-zeroed-area = zero 
	then 
	    move clmhdr-orig-batch-nbr	to 	hold-clmhdr-batch-nbr 
	    move clmhdr-orig-claim-nbr	to 	hold-clmhdr-claim-nbr 
	    move clmhdr-status-ohip	to 	hold-clmhdr-status-ohip  
	    move "Y"			to 	eof-claims-dtl  
	    go to da0-99-exit 
	else 
	    next sentence 
*	endif 
    else 
	next sentence. 
*   endif 
 
    if   clmdtl-orig-batch-nbr          not = hold-clmhdr-batch-nbr 
      or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr 
    then 
	move "Y"			to 	eof-claims-dtl. 
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
					thru 	ea0-99-exit 
	    move "N"			to 	first-desc 
	else 
	    next sentence                
*	endif 
    else 
	perform da12-move-print-dtl	thru 	da12-99-exit 
	perform da13-add-to-claim-totals  
					thru 	da13-99-exit 
	go to da1-99-exit. 
*   endif 
 
    perform da11-move-print-desc	thru 	da11-99-exit. 
 
da1-99-exit. 
    exit. 
da11-move-print-desc. 
 
    move clmdtl-desc			to	l4-claim-desc. 
    move 1				to	nbr-lines-to-advance. 
    perform ba0-write-detail-line	thru 	ba0-99-exit. 
 
da11-99-exit. 
    exit. 
da12-move-print-dtl. 
 
    move 1				to 	subs. 
 
da12-10-date-loop. 
 
***	compute nbr of services for batch 
    add clmdtl-sv-nbr (subs)		to 	act-sum-nbr-serv. 
 
    move clmdtl-sv-nbr (subs)		to 	l2-sv-nbr (subs). 
    if clmdtl-sv-day (subs) numeric 
    then 
	move clmdtl-sv-day (subs)	to 	l2-sv-day (subs) 
    else 
	move clmdtl-sv-day (subs)	to 	l2-sv-day-alpha (subs). 
*   endif. 
    add 1				to 	subs. 
 
    if subs < 4 
    then 
	go to da12-10-date-loop. 
*   (else) 
*   endif 
 
    move clmdtl-oma-cd			to 	l2-oma-cd. 
    move clmdtl-oma-suff		to 	l2-oma-suff. 
    move clmdtl-adj-cd			to 	l2-adj-cd. 
    move clmdtl-diag-cd                 to      l2-diag-code. 
    move hold-clmhdr-status-ohip	to 	l2-rsn. 
 
    move clmdtl-sv-yy			to 	l2-svc-date-yy. 
    move clmdtl-sv-mm			to 	l2-svc-date-mm. 
    move clmdtl-sv-dd			to 	l2-svc-date-dd. 
    move "/"				to 	l2-slash1 
					   	l2-slash2. 
    move clmdtl-fee-oma			to 	l2-fee-oma. 
    move clmdtl-fee-ohip		to 	l2-fee-ohip. 
 
****  compute nbr of services and sum of oma fee per batch 
    if clmdtl-nbr-serv is numeric 
    then 
	move clmdtl-nbr-serv		to 	l2-srv 
	add clmdtl-nbr-serv		to 	act-sum-nbr-serv. 
*   (else) 
*   endif 
 
    move 1				to 	nbr-lines-to-advance. 
    perform ba0-write-detail-line	thru 	ba0-99-exit. 
 
da12-99-exit. 
    exit. 
da13-add-to-claim-totals. 
 
    add clmdtl-fee-oma			to 	ctr-fee-oma. 
    add clmdtl-fee-ohip			to 	ctr-fee-ohip. 

*mf    add clmdtl-nbr-serv 
*mf 	clmdtl-sv-nbr (1) 
*mf	clmdtl-sv-nbr (2) 
*mf 	clmdtl-sv-nbr (3)		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr-svcs ). 
 
    add batctrl-clm-offset, ss-nbr-svcs	giving ss-temp1. 
    add clmdtl-nbr-serv 
	clmdtl-sv-nbr (1) 
	clmdtl-sv-nbr (2) 
	clmdtl-sv-nbr (3)		to tbl-tot (ss-type, ss-agent, ss-temp1 ). 

da13-99-exit. 
    exit. 
ea0-print-claims-totals. 
 
    move ctr-fee-oma			to 	l3-fee-total-oma. 
    move ctr-fee-ohip			to 	l3-fee-total-ohip. 
 
    add 1				to 	ctr-line. 
    write print1-record from print-line after 	advancing 1 line. 
    move spaces				to 	print-line. 
 
    move 0				to 	ctr-fee-oma  
					   	ctr-fee-ohip. 
 
ea0-99-exit. 
    exit. 
fa0-print-and-zero-batch-tots. 
 
    add 11					ctr-line 
					giving 	total-lines. 
 
* 
*  print the heading - 91/11/12 by m.c. 
* 
    if total-lines > max-nbr-lines 
    then 
*	write print1-record from t1-head after advancing page 
 	perform xa0-headings 		thru xa0-99-exit. 
*   else 
    write print1-record from t1-head after advancing 2 lines. 
*   endif 
 
    write print1-record from t2-head after advancing 1 line. 
    write print1-record from t3-head after advancing 1 line. 
 
    move "(AUDIT TOTALS)"		to 	t1-total-lit. 
    move act-sum-nbr-serv		to 	t1-nbr-services. 
    move act-sum-fee-oma-ohip		to 	t1-amt-input. 
    write print1-record from t1-print-line after 2 lines. 
    move spaces				to 	print-line. 
 
    move "COMPUTER TOTALS"		to 	t1-total-lit. 
    move batctrl-svc-act		to 	t1-nbr-services. 
    move batctrl-amt-act		to 	t1-amt-input. 
    write print1-record from t1-print-line after 1 line. 
    move spaces				to 	print-line. 
 
    move "BATCHING TOTALS"		to 	t1-total-lit. 
    move batctrl-svc-est		to 	t1-nbr-services. 
    move batctrl-amt-est    		to 	t1-amt-input. 
    write print1-record from t1-print-line after 2 lines. 
    move spaces				to 	print-line. 
 
*   subtract batctrl-svc-est		from 	batctrl-svc-act 
    subtract act-sum-nbr-serv		from 	batctrl-svc-act 
					giving 	difference. 
    move difference			to 	t1-nbr-services. 
*   subtract batctrl-amt-est		from 	batctrl-amt-act 
    subtract act-sum-fee-oma-ohip	from 	batctrl-amt-act 
					giving 	diff. 
    move diff				to 	t1-amt-input. 
    if    difference <> 0
      or  diff <> 0
    then
        move "DIFFERENCE"		to 	t1-total-lit
    else
        move "no difference"		to 	t1-total-lit. 
*   endif

    write print1-record			from 	t1-print-line after  
					     	advancing 2 lines. 
    move spaces				to 	print-line. 
 
    perform xb0-reset-batch-totals	thru	xb0-99-exit. 
 
fa0-99-exit. 
    exit. 
ga0-read-next-batch. 
 
    read batch-ctrl-file next 
	at end 
	    move "Y"			to 	eof-batctrl-file 
	    go to ga0-99-exit. 
 
    add 1				to 	ctr-batctrl-file-reads. 
 
    move "N"				to 	flag-rec. 
 
    perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = 'Y' 
    then 
	go to ga0-99-exit. 
*   (else) 
*   endif 
 
*	if the current claim header that was read is not the correct 
*	batch number then read the header with the new batch number. 
 
    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr) 
      or (clmhdr-date-period-end not = batctrl-date-period-end) 
    then 
*	(claim read doesn'T BELONG TO BATCH IF IT HAS A DIFFERENT 
*	 batch # or the same batch # but different period end date -- eg 
*	 a claim from previous year with same # but different period date) 
	perform aa11-read-claim		thru 	aa11-99-exit. 
*   (else) 
*   endif 
 
 
ga0-99-exit. 
    exit. 
sa0-add-clmhdr-totals. 
 
*   ( 'C' type payments are stored in claims mstr as a negative 
*     amount but appear on the report as a positive amount) 
 
    if clmhdr-adj-cd = "C" 
    then 
	subtract clmhdr-manual-and-tape-paymnts 
					from	zero 
					giving	clmhdr-manual-and-tape-paymnts.  
*   (else) 
*   endif 
 
*   	ss-type '1'(ss-claims) = claims 
*   	ss-type '2'(ss-adj-a)  = 'A' type adjustments 
*   	ss-type '3'(ss-adj-b)  = 'B' type adjustments 
*   	ss-type '4'(ss-adj-r)  = 'R' type adjustments 
*   	ss-type '5'(ss-pay-m)  = 'M' type payments 
*   	ss-type '6'(ss-pay-c)  = 'C' type payments 
 
    perform sa1-find-ss-type 		thru	sa1-99-exit. 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, clmhdr-agent-cd		giving	ss-agent. 
 
    if ss-type not = ss-adj-r 
    then 
	add batctrl-clm-offset, ss-net-a-r	giving ss-temp1
        add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).    
*mf        add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-net-a-r ).    
*   (else) 
*   endif 
    if ss-type not = ss-adj-a 
    then 
	add batctrl-clm-offset, ss-net-rev	giving ss-temp1
        add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
*mf        add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-net-rev ).   
*   (else) 
*   endif 
    add batctrl-clm-offset, ss-cash	giving ss-temp1.
    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
*mf    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-cash  ). 
    if ss-type = ss-pay-m 
    then 
	add batctrl-clm-offset, ss-net-rev	giving ss-temp1
        add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
*mf        add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-net-rev  ).   
*   (else) 
*   endif 
    add batctrl-clm-offset, ss-nbr-claims	giving ss-temp1.
    add 1                  		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).                     
*mf    add 1                  		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr-claims ).                     
 
sa0-99-exit. 
    exit. 
 
 
 
sa1-find-ss-type. 
 
    if clmhdr-batch-type = "C" 
    then 
	move ss-claims			to	ss-type 
    else 
	if clmhdr-batch-type = "A" 
	then 
	    if clmhdr-adj-cd = "A" 
	    then 
		move ss-adj-a		to	ss-type 
	    else 
	        if clmhdr-adj-cd = "B" 
		then 
		    move ss-adj-b	to	ss-type 
		else 
***			 clmhdr-adj-cd = "R" 
		    move ss-adj-r	to	ss-type 
*               endif 
*           endif 
	else 
***			(clmhdr-batch-type = "P") 
	    if clmhdr-adj-cd = "M" 
	    then 
		move ss-pay-m		to	ss-type 
	    else 
***			(clmhdr-adj-cd = "C") 
		move ss-pay-c		to	ss-type. 
*           endif 
*       endif 
*    endif 
 
sa1-99-exit. 
    exit. 
sa2-add-batch-totals. 
 
***************************************************************** 
* 'AC0-CHECK-NBR-CLAIMS-FIELD' is a temporary patch needed only * 
*  as long as there are batch control records without the field *       
* "BATCTRL-NBR-CLAIMS-IN-BATCH" added.  this routine may be re- * 
*  moved after it is no longer needed.  81-dec-21.              * 
 
    perform ac0-check-nbr-claims-field	thru	ac0-99-exit. 
 
***************************************************************** 
    perform sa3-find-ss-type 		thru	sa3-99-exit. 
 
*    ('C' type 'P'ayments are stored in batch control file 
*      as a negative amount but appear on the report as positive) 
 
    if     batctrl-batch-type = "P" 
      and  batctrl-adj-cd     = "C" 
    then 
	subtract batctrl-manual-pay-tot		from	zero 
						giving	batctrl-manual-pay-tot. 
*   (else) 
*   endif 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, batctrl-agent-cd		giving	ss-agent. 
 
    add batctrl-clm-offset, ss-net-a-r		giving ss-temp1.
    add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).    
    add batctrl-clm-offset, ss-net-rev		giving ss-temp1.
    add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
    add batctrl-clm-offset, ss-cash		giving ss-temp1.
    add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
    add batctrl-clm-offset, ss-nbr-claims	giving ss-temp1.
    add batctrl-nbr-claims-in-batch             to	tbl-tot (ss-type, ss-agent, ss-temp1 ).         
    add batctrl-clm-offset, ss-nbr-svcs		giving ss-temp1.
    add batctrl-svc-act              		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).         

*mf    add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-net-a-r ).    
*mf    add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-net-rev ).   
*mf    add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-cash  ). 
*mf    add batctrl-nbr-claims-in-batch             to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr-claims ).         
*mf    add batctrl-svc-act              		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr-svcs ).         
 
sa2-99-exit. 
    exit. 
 
 
 
sa3-find-ss-type. 
 
    if batctrl-batch-type = "C" 
    then 
	move ss-claims			to	ss-type 
    else 
	if batctrl-batch-type = "A" 
	then 
	    if batctrl-adj-cd = "A" 
	    then 
		move ss-adj-a		to	ss-type 
	    else 
	        if batctrl-adj-cd = "B" 
		then 
		    move ss-adj-b	to	ss-type 
		else 
***			 batctrl-adj-cd = "R" 
		    move ss-adj-r	to	ss-type 
*               endif 
*           endif 
	else 
***			(batctrl-batch-type = "P") 
	    if batctrl-adj-cd = "M" 
	    then 
		move ss-pay-m		to	ss-type 
	    else 
***			(batctrl-adj-cd = "C") 
		move ss-pay-c		to	ss-type. 
*           endif 
*       endif 
*    endif 
 
sa3-99-exit. 
    exit. 
tc1-roll-type-tot-to-grand. 
 
*    (roll 'TYPE' totals to 'GRAND' total level and zero 'TYPE' -- 
*	-- note: "+ 1" limit in 'UNTIL' statement allows agent totals level 
*		 to be rolled and zeroed) 
    move ss-type-tot			to	ss-type-from. 
    move ss-grand-tot			to	ss-type-to. 
    perform te0-roll-and-zero-totals	thru	te0-99-exit 
	varying  ss-agent-from 
	from  1 
	by    1 
	until    ss-agent-from > max-nbr-agents + 1. 
 
 
tc1-99-exit. 
    exit. 
te0-roll-and-zero-totals. 
*	(rtn called varying 'SS-AGENT-FROM' after setting 'SS-TYPE-FROM' and 'SS-TYPE-TO') 
*        ( hard coded values 1 thru 8 give every item for each agent and type) 
 
    add tbl-tot (ss-type-from, ss-agent-from, 1 )  to tbl-tot (ss-type-to, ss-agent-from, 1 ). 
    add tbl-tot (ss-type-from, ss-agent-from, 2 )  to tbl-tot (ss-type-to, ss-agent-from, 2 ).   
    add tbl-tot (ss-type-from, ss-agent-from, 3 )  to tbl-tot (ss-type-to, ss-agent-from, 3 ). 
    add tbl-tot (ss-type-from, ss-agent-from, 4 )  to tbl-tot (ss-type-to, ss-agent-from, 4 ).  
    add tbl-tot (ss-type-from, ss-agent-from, 5 )  to tbl-tot (ss-type-to, ss-agent-from, 5 ).  
    add tbl-tot (ss-type-from, ss-agent-from, 6 )  to tbl-tot (ss-type-to, ss-agent-from, 6 ).      
    add tbl-tot (ss-type-from, ss-agent-from, 7 )  to tbl-tot (ss-type-to, ss-agent-from, 7 ). 
    add tbl-tot (ss-type-from, ss-agent-from, 8 )  to tbl-tot (ss-type-to, ss-agent-from, 8 ). 
    add tbl-tot (ss-type-from, ss-agent-from, 9 )  to tbl-tot (ss-type-to, ss-agent-from, 9 ).           
    add tbl-tot (ss-type-from, ss-agent-from, 10 ) to tbl-tot (ss-type-to, ss-agent-from, 10 ).               
 
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 1 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 2 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 3 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 4 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 5 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 6 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 7 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 8 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 9 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 10 ).                        
 
te0-99-exit. 
    exit. 
tg0-move-vals-to-line. 
  
    move tbl-tot (ss-type-from, ss-agent, 1 )	to	t2-detail-1 . 
    move tbl-tot (ss-type-from, ss-agent, 2 )	to	t2-detail-2 . 
    move tbl-tot (ss-type-from, ss-agent, 3 )	to	t2-detail-3 . 
    move tbl-tot (ss-type-from, ss-agent, 4 )	to	t2-detail-4 . 
    move tbl-tot (ss-type-from, ss-agent, 5 )	to	t2-detail-5 . 
    move tbl-tot (ss-type-from, ss-agent, 6 )	to	t2-detail-6 . 
    move tbl-tot (ss-type-from, ss-agent, 7 )	to	t2-detail-7 . 
    move tbl-tot (ss-type-from, ss-agent, 8 )	to	t2-detail-8 . 
    move tbl-tot (ss-type-from, ss-agent, 9 )	to	t2-detail-9 . 
    move tbl-tot (ss-type-from, ss-agent, 10 )	to	t2-detail-10. 
 
tg0-99-exit. 
    exit. 
 
 
 
tb0-write-line. 
 
    add  nbr-lines-to-advance				to	ctr-line.     
    if ctr-line > max-nbr-lines 
    then 
 	perform tc0-print-headings			thru	tc0-99-exit. 
*   (else) 
*   endif 
 
    write   print1-record  from l1-print-line   after advancing  nbr-lines-to-advance lines. 
    write   print2-record  from l1-print-line   after advancing  nbr-lines-to-advance lines. 
 
    move spaces						to	print-line. 
    move 1						to	nbr-lines-to-advance. 
 
tb0-99-exit. 
    exit. 
tc0-print-headings. 
 
    add 1				to	ctr-page-2.      
 
    if not-last-page 
    then 
	move hold-clinic-nbr		to	h1-clinic-nbr. 
*   (else) 
*   endif 
 
    move ctr-page-2			to	h1-page. 
    move print-file-name-2		to	h1-rpt-name. 
    move spaces				to	h1-batch-type. 
    write print2-record from h1-head 	after 	advancing page. 
    write print2-record from h2-head 	after 	advancing 1 line. 
    move spaces				to	h3-batch-nbr. 
    write print2-record from h3-head 	after 	advancing 1 line. 
 
    if not-last-page 
    then 
        move hold-clinic-nbr		to	t4-clinic-nbr. 
*   (else) 
*   endif 
 
    write print2-record from t4-head 	after 	advancing 2 lines. 
    write print2-record from t5-head 	after 	advancing 1 line. 
    write print2-record from blank-line after 	advancing 1 line. 
 
    add 1				to	ctr-page-1.            
 
    if not-last-page 
    then 
	move hold-clinic-nbr		to	h1-clinic-nbr. 
*   (else) 
*   endif 
 
    move ctr-page-1			to	h1-page. 
    move print-file-name-1		to	h1-rpt-name. 
    move spaces				to	h1-batch-type. 
    write print1-record from h1-head 	after 	advancing page. 
    write print1-record from h2-head 	after 	advancing 1 line. 
    move spaces				to	h3-batch-nbr. 
    write print1-record from h3-head 	after 	advancing 1 line. 
    if not-last-page 
    then 
        move hold-clinic-nbr		to	t4-clinic-nbr. 
*   (else) 
*   endif 
 
    write print1-record from t4-head 	after 	advancing 2 lines. 
    write print1-record from t5-head 	after 	advancing 1 line. 
    write print1-record from blank-line after 	advancing 1 line. 
    move 6 				to	ctr-line. 
 
*   (move report-name-1 back to first heading line for next call 
*    of xa0-headings) 
 
    move print-file-name-1		to	h1-rpt-name. 
 
tc0-99-exit. 
    exit. 
xa0-headings. 
 
    add 1				to 	ctr-page-1. 
    move print-file-name-1		to	h1-rpt-name. 
    move hold-clinic-nbr		to	h1-clinic-nbr. 
    move ctr-page-1			to 	h1-page. 
    write print1-record from h1-head 	after 	advancing page. 
    write print1-record from h2-head 	after 	advancing 1 line. 
    write print1-record from h3-head 	after 	advancing 1 line. 
    write print1-record from h4-head 	after 	advancing 2 lines. 
    write print1-record from h5-head 	after 	advancing 1 line. 
    move 6				to 	ctr-line. 
  
xa0-99-exit. 
    exit. 
xb0-reset-batch-totals. 
 
    move zero				to	act-sum-nbr-serv 
						act-sum-fee-oma-ohip. 
    move 98				to 	ctr-line. 
 
xb0-99-exit. 
    exit. 
xc0-batch-heading-info. 
 
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
 
xc0-99-exit. 
    exit. 
xc1-add-to-fin-totals. 
 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	fin-tot-1. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	fin-tot-2. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	fin-tot-3. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	fin-tot-4. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	fin-tot-5. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	fin-tot-6. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	fin-tot-7. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	fin-tot-8. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	fin-tot-9. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) to	fin-tot-10.  
 
xc1-99-exit. 
    exit. 
xd0-hold-clinic-info. 
 
    move batctrl-bat-clinic-nbr-1-2	to hold-clinic-nbr. 
 
*	(obtain cycle nbr & period end from constants mstr) 
 
    move hold-clinic-nbr		to iconst-clinic-nbr-1-2. 
    read iconst-mstr 
 	invalid key 
 	    move 2			to err-ind 
 	    perform za0-common-error	thru za0-99-exit 
 	    go to az0-end-of-job. 
 
    move iconst-clinic-nbr-1-2		to h1-clinic-nbr. 
    move iconst-clinic-cycle-nbr	to h3-cycle. 
    move iconst-date-period-end-yy	to h3-period-end-yy. 
    move iconst-date-period-end-mm	to h3-period-end-mm. 
    move iconst-date-period-end-dd	to h3-period-end-dd. 
    move iconst-clinic-name		to h2-clinic-name. 
 
xd0-99-exit. 
    exit. 
xe0-print-clinic-totals. 
 
*   (start totals on new page) 
    move 98				to	ctr-line. 
 
*   (flags will determine if batch type and adjustment type desciptions are to be printed) 
    move "N"				to	sw-printed-bat-type 
						sw-printed-adj-type. 
 
    perform xe1-process-batch-totals	thru	xe1-99-exit 
	    varying ss-type 
	    from  1 
	    by    1 
	    until   ss-type > max-nbr-types. 
 
*    (print 'GRAND' totals - ss-grand-tot moved to ss-type) 
 
    move ss-grand-tot			to	ss-type.    
    perform xe1-process-batch-totals	thru	xe1-99-exit. 
 
*   (start next clinic printouts on new page) 
    move 98				to	ctr-line. 
 
xe0-99-exit. 
    exit. 
xe1-process-batch-totals. 
*	(this rtn called varying 'SS-TYPE' except for grand totals 
*        where ss-type = ss-grand-tot) 
 
 
    perform xe11-prt-agent-vals-and-sum	thru	xe11-99-exit 
	    varying ss-agent 
	    from  1 
	    by    1 
	    until    ss-agent > max-nbr-agents. 
 
*    (print totals for all agents except for 'CLAIMS' and 'GRAND TOTALS) 
    if ss-type not =     ss-claims 
	             and ss-grand-tot 
    then 
*	(only print totals if a detail line has been printed) 
	if sw-printed-adj-type = "Y" 
	then 
	    move "             TOTAL"		to	t2-desc 
	    move ss-type			to	ss-type-from 
	    move ss-agent-tot			to	ss-agent 
	    perform tg0-move-vals-to-line	thru	tg0-99-exit 
	    perform tb0-write-line		thru	tb0-99-exit 
	else 
	    next sentence 
    else 
	next sentence. 
*   endif 
 
    move "N"					to	sw-printed-adj-type.         
*    (roll this type'S TOTALS INTO 'batch type totals') 
    if ss-type not = ss-grand-tot 
    then 
        move ss-type				to	ss-type-from 
        move ss-type-tot				to	ss-type-to 
        perform te0-roll-and-zero-totals		thru	te0-99-exit 
    	        varying ss-agent-from 
	        from  1 
	        by    1 
	        until   ss-agent-from > max-nbr-agents + 1. 
*   (else) 
*   endif 
 
 
*   (if necessary print 'BATCH TYPE TOTALS' for batch types after appropriate types)  
    if ss-type =    ss-claims 
		 or ss-adj-r 
		 or ss-pay-c 
		 or ss-grand-tot 
    then 
	if sw-printed-bat-type = "Y" 
	then 
	    move "N"				to	sw-printed-bat-type 
	    move 2				to	nbr-lines-to-advance 
	    move "    TOTALS"			to	t2-desc 
	    if ss-type = ss-grand-tot 
	    then 
	        move ss-grand-tot		to	ss-type-from 
	    	move ss-agent-tot		to	ss-agent 
	        perform tg0-move-vals-to-line	thru	tg0-99-exit 
	        perform tb0-write-line		thru	tb0-99-exit 
	    else 
		move ss-type-tot		to	ss-type-from 
		move ss-agent-tot		to	ss-agent 
	        perform tg0-move-vals-to-line	thru	tg0-99-exit 
	        perform tb0-write-line		thru	tb0-99-exit 
		perform tc1-roll-type-tot-to-grand 
						thru	tc1-99-exit 
*  	    endif 
	else 
	    if ss-type not = ss-grand-tot 
	    then 
	        perform tc1-roll-type-tot-to-grand 
	                                      	thru	tc1-99-exit. 
*	    (else) 
*	    endif 
*	endif 
*   (else) 
*   endif 
 
xe1-99-exit. 
    exit. 
xe11-prt-agent-vals-and-sum. 
*    (this routine called varying 'SS-AGENT') 
 
*    (print line only if non-zero values for 'AGENT') 
*    ( 'NBR + OFFSET' gives retained types. 'OFFSET' = 4) 
    add ss-nbr-claims, ss-offset		giving ss-temp1.
    if     tbl-tot (ss-type, ss-agent, ss-nbr-claims) 	    = zero 
       and tbl-tot (ss-type, ss-agent, ss-temp1 )  	    = zero 
*mf      and tbl-tot (ss-type, ss-agent, ss-nbr-claims + ss-offset )  = zero 
    then 
	go to xe11-99-exit. 
*   (else) 
*   endif 
 
    move spaces				to	t2-desc. 
 
*    (if printing 1st detail line for this batch type then include 
*     batch type description) 
    if sw-printed-bat-type = "N" 
    then 
	move "Y"			to	sw-printed-bat-type 
	move desc-bat-type (ss-type)	to	t2-desc-a 
	move 3				to	nbr-lines-to-advance. 
*   (else) 
*   endif 
 
*    (if printing 1st detail line for this adjustment type then include 
*     adjustment type description) 
    if sw-printed-adj-type = "N" 
    then 
	move "Y"			to	sw-printed-adj-type 
	move desc-adj-type (ss-type)	to	t2-desc-b. 
*   (else) 
*   endif 
 
    move "-"				to	t2-dash. 
    subtract 1				from	ss-agent 
					giving	t2-agent-cd. 
    move ss-type			to	ss-type-from. 
    perform tg0-move-vals-to-line	thru	tg0-99-exit. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
*   (sum the batch "TYPE'S" totals for all agents) 
*   (bypass if grand totals) 
 
    if ss-type = ss-grand-tot 
    then 
	go to xe11-99-exit. 
*   (else) 
*   endif 
 
    add tbl-tot (ss-type, ss-agent, 1 )		to tbl-tot (ss-type    ,ss-agent-tot, 1 ).  
    add tbl-tot (ss-type, ss-agent, 2 )		to tbl-tot (ss-type    ,ss-agent-tot, 2 ).  
    add tbl-tot (ss-type, ss-agent, 3 )		to tbl-tot (ss-type    ,ss-agent-tot, 3 ).  
    add tbl-tot (ss-type, ss-agent, 4 )		to tbl-tot (ss-type    ,ss-agent-tot, 4 ).  
    add tbl-tot (ss-type, ss-agent, 5 )		to tbl-tot (ss-type    ,ss-agent-tot, 5 ).  
    add tbl-tot (ss-type, ss-agent, 6 )		to tbl-tot (ss-type    ,ss-agent-tot, 6 ).  
    add tbl-tot (ss-type, ss-agent, 7 )		to tbl-tot (ss-type    ,ss-agent-tot, 7 ).  
    add tbl-tot (ss-type, ss-agent, 8 )		to tbl-tot (ss-type    ,ss-agent-tot, 8 ).     
    add tbl-tot (ss-type, ss-agent, 9 )		to tbl-tot (ss-type    ,ss-agent-tot, 9 ).     
    add tbl-tot (ss-type, ss-agent, 10 )	to tbl-tot (ss-type    ,ss-agent-tot, 10 ).                 
  
xe11-99-exit. 
    exit. 
xf0-zero-clinic-totals. 
 
    move zero			to	tbl-totals. 
 
xf0-99-exit. 
ya0-read-pat. 
 
    move clmhdr-pat-ohip-id-or-chart	to	key-pat-mstr. 
 
    read pat-mstr 
	invalid key 
	    move   9			to   	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    perform err-pat-mstr. 
 
    add   1				to 	ctr-pat-mstr-reads. 
 
    if pat-health-nbr not = 0 
    then 
        move pat-health-nbr             to      l1-pat-id-chart-id 
    else 
    	if pat-ohip-mmyy-r not = spaces 
    	then 
	    move pat-ohip-mmyy-r	to 	l1-pat-id-chart-id 
    	else 
	    move pat-chart-nbr		to 	l1-pat-id-chart-id. 
*   endif 
 
ya0-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
ze0-move-and-print-fin-tot. 
 
    move " FINAL TOTALS  "  		to	t2-desc. 
 
    move fin-tot-1			to	t2-detail-1. 
    move fin-tot-2			to	t2-detail-2. 
    move fin-tot-3			to	t2-detail-3. 
    move fin-tot-4			to	t2-detail-4. 
    move fin-tot-5			to	t2-detail-5. 
    move fin-tot-6			to	t2-detail-6. 
    move fin-tot-7			to	t2-detail-7. 
    move fin-tot-8			to	t2-detail-8. 
    move fin-tot-9			to	t2-detail-9. 
    move fin-tot-10			to	t2-detail-10.  
 
    move spaces				to	h2-clinic-name. 
    move zero				to	h3-cycle 
						h3-period-end-yy 
						h3-period-end-mm 
						h3-period-end-dd 
						h1-clinic-nbr 
						t4-clinic-nbr. 
    move 'Y' 				to	last-page-flag. 
 
    move 3 				to	nbr-lines-to-advance. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
ze0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
