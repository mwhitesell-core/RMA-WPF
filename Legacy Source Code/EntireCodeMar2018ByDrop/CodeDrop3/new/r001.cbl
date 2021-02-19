identification division. 
program-id. r001. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/01/31. 
date-compiled. 
security. 
* 
*    files      : f001  - batch control file 
*		: f090i - constants master 
*		: f020  - doctor master 
*		: "r001"  - print report file 
* 
*    program purpose : batch summary report.          
* 
*   revised may/87   : - s.b. 
*     		       - conversion from aos to aos/vs. 
*                        change field size for status clause to 2 
*                        and feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised may/02/89: - sms 116 s.f. 
*		       - print the dept code and/or name 
* 
*   revised nov/01/90: - sms 133 bml 
*                      - modified to print adj-cd-sub-type. 
* 
*   revised mar/91   : - sms 133 bml 
*                      - included totals of diskette claims. 
* 
*   revised jul/17/92: - sms 139 
*		       - summarize clinic 60'S TOTAL 
* 
*   revised apr/19/93  - pdr 571 
*                      - remove clinic 80 totals from clinic 60'S 
* 
*   revised jan/96 yb  - change batctrl-batch-status from 1 to 1 or 2 
*                        because, implementation of u010daily program 
*
*   revised jan/98 jc  - s149 unix conversion
*
*   revised mar/99 cm  - y2k conversion
*   revised 1999/May/07	S.B.	- fixed y2k conversion.
*   revised 1999/July/12 S.B.	- fixed report alignment.
*   revised 2000/oct/06  yas.	- added batctrl-adj-cd-sub-type = "W"
*                                 into DISKETTE TOTALS 
*
*   2003/dec/08	M.C.	- alpha doc nbr
*   2003/dec/20	b.e.	- remove confirm to run program
*   2007/apr/19 M.C.    - summarize clinic 70'S TOTAL 
*   2008/mar/26 M.C.    - extend print field for final total AR(t1-detail-6) and 
* 			  revenue(t1-detail-7) for over 9 million
*   2010/mar/09 MC1     - include clinic 66 into clinic 60's TOTAL
*   2012/Feb/15 MC2     - change to print the clinic 60/70 summary page properly for Dave
*   2014/Feb/24 MC3	- summarize clinics 22-25, 31-36, 41-48 Total MTD revenue for payroll balancing
*   2014/OCt/16 MC4	- include new clinic 30 to  clinics 22-25, 30-36, 41-48 Total MTD revenue for payroll balancing
*   2015/Mar/17 MC5     - change l1-loc-2-4 to be character instead of numeric
*   2015/Mar/25 MC6	- include new clinic 26 into  clinics 22-26, 30-36, 41-48 Total MTD revenue for payroll balancing
*   2016/Jul/14 MC7	- change amount print field
*   2017/Jan/26 MC8     - change amount field size for final total

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f001_batch_control_file.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "f020_doctor_mstr.slr". 
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
    copy "f090_constants_mstr.fd". 
* 
    copy "f020_doctor_mstr.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
		value "r001". 
77  option					pic x. 
77  const-mstr-rec-nbr				pic x. 
77  max-nbr-lines				pic 99		value 55. 
77  ctr-page					pic 9(4). 
77  ctr-line					pic 9(3). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  ws-hold-cycle-nbr				pic 99. 
77  hold-clinic-nbr				pic 99. 
77  ws-reply					pic x.    
 
01  ws-date-sv. 
* (y2k)
*    05  ws-date-sv-yy				pic 99. 
    05  ws-date-sv-yy				pic 9999. 
    05  ws-date-sv-mm				pic 99. 
    05  ws-date-sv-dd				pic 99. 
 
* 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-batctrl-file			pic x(11) value zero. 
*mf 77  status-doc-mstr				pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 

77  common-status-file                          pic x(2).
77  status-cobol-batctrl-file			pic x(2) value zero. 
77  status-cobol-doc-mstr			pic x(2) value zero. 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-prt-file				pic x(2) value zero. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-rec					pic x. 
    88 valid-rec				value "Y". 
    88 invalid-rec				value "N". 
 
01  last-page-flag				pic x. 
    88 last-page				value "Y". 
    88 not-last-page				value "N". 
 
*mf copy "f001_key_batctrl_file.ws". 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-doc-file-reads 			pic 9(7). 
 
*   (tested to allow totals line to be surpressed if not detail lines 
*    have been printed) 
77  nbr-lines-to-advance			pic 9. 
77  sw-printed-bat-type				pic x. 
77  sw-printed-adj-type				pic x. 
 
01  tbl-totals. 
    05  tbl-bat-type-and-tots	occurs   8  times. 
	10  tbl-agent-and-sums	occurs  11  times. 
	    15  tbl-item	occurs  10  times. 
		20  tbl-tot		pic s9(9)v99. 

*	(access using tbl-tot (ss-type, ss-agent, ss-item))      
01  tbl-totals-variable-ss. 
*mf  ss-temp1
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
*	       (values 1 thru 5 used for cycle totals) 
*	       (values 6 thru 10 (obtained by adding variable offset) 
*	        are used for month to date totals) 
 
	    05  ss-a-r			pic 9	value  1. 
	    05  ss-rev			pic 9	value  2. 
	    05  ss-cash			pic 9	value  3. 
	    05  ss-nbr-claims		pic 9	value  4. 
	    05  ss-nbr-svcs		pic 9	value  5. 
	    05  ss-offset		pic 9	value  5. 
	    05  ss-cyc-offset		pic 9	value  0. 
	    05  ss-mtd-offset		pic 9	value  5. 
*		( variable offset ) 
	    05  cyc-mtd-offset  	pic 9. 
 
 
 
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
 
01  clinic-totals. 
 
    05  clinic-tot-1			pic s9(9)v99. 
    05  clinic-tot-2			pic s9(9)v99. 
    05  clinic-tot-3			pic s9(9)v99. 
    05  clinic-tot-4			pic s9(9)v99. 
    05  clinic-tot-5			pic s9(9)v99. 
    05  clinic-tot-6			pic s9(9)v99. 
    05  clinic-tot-7			pic s9(9)v99. 
    05  clinic-tot-8			pic s9(9)v99. 
    05  clinic-tot-9			pic s9(9)v99. 
    05  clinic-tot-10			pic s9(9)v99. 

* 2007/04/19 - MC - add for clinic 70's total
    05  clinic2-tot-1			pic s9(9)v99. 
    05  clinic2-tot-2			pic s9(9)v99. 
    05  clinic2-tot-3			pic s9(9)v99. 
    05  clinic2-tot-4			pic s9(9)v99. 
    05  clinic2-tot-5			pic s9(9)v99. 
    05  clinic2-tot-6			pic s9(9)v99. 
    05  clinic2-tot-7			pic s9(9)v99. 
    05  clinic2-tot-8			pic s9(9)v99. 
    05  clinic2-tot-9			pic s9(9)v99. 
    05  clinic2-tot-10			pic s9(9)v99. 
* 2007/04/19 - end

* MC3                                           
    05  clinic3-tot-1			pic s9(9)v99. 
    05  clinic3-tot-2			pic s9(9)v99. 
    05  clinic3-tot-3			pic s9(9)v99. 
    05  clinic3-tot-4			pic s9(9)v99. 
    05  clinic3-tot-5			pic s9(9)v99. 
    05  clinic3-tot-6			pic s9(9)v99. 
    05  clinic3-tot-7			pic s9(9)v99. 
    05  clinic3-tot-8			pic s9(9)v99. 
    05  clinic3-tot-9			pic s9(9)v99. 
    05  clinic3-tot-10			pic s9(9)v99. 
* MC3 - end

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
 
01  disk-totals. 
    05  disk-tot-tab occurs 10 times    pic s9(9)v99. 
 
01  disk-finals. 
    05  disk-grnd-tab occurs 10 times   pic s9(9)v99. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"NO CONSTANTS MASTER SUPPLIED". 
	10  filler				pic x(60)   value 
			"INVALID CLINIC NBR". 
	10  filler				pic x(60)   value 
			"NO BATCTRL FILE OR NO CORRESP CLINICS OR NO BALANCED BATCHES". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 04 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 copy "sysdatetime.ws". 

01  h1-head. 
 
    05  filler					pic x(7)	value   
		"R001  /". 
    05  h1-clinic-nbr				pic zz. 
    05  filler					pic x(40)	value spaces. 
    05  filler					pic x(75)	value 
		"-  CYCLE BATCH SUMMARY REPORT  -". 
    05  filler					pic x(5)	value 
		"PAGE". 
    05  h1-page					pic zz9. 
 
 
 
01  h2-head. 
 
    05  filler					pic x(10)	value 
		"  CYCLE #". 
    05  h2-cycle				pic zzz. 
    05  filler					pic x(14)	value 
		"  PERIOD END:". 
* (y2k - auto fix)
*   05  h2-period-end-yy			pic 99 	blank when zero. 
    05  h2-period-end-yy			pic 9(4) 	blank when zero. 
    05  filler					pic x		value "/". 
    05  h2-period-end-mm			pic 99  blank when zero. 
    05  filler					pic x		value "/". 
    05  h2-period-end-dd			pic 99  blank when zero. 
* (y2k)
*    05  filler					pic x(16)	value spaces. 
    05  filler					pic x(14)	value spaces. 
    05  h2-clinic-name				pic x(81). 
 
 
 
01  h3-head. 
 
    05  filler					pic x(1)	value spaces. 
*   05  filler					pic x(8)	value 
    05  filler					pic x(10)	value 
		"BATCH". 
    05  filler					pic x(8)	value 
*    05  filler					pic x(6)	value 
		"AGENT". 
    05  filler					pic x(11)	value 
		"BAT /ADJ". 
    05  filler					pic x(6)	value 
		"DOC". 
    05  filler					pic x(5)	value 
		"HOS". 
    05  filler					pic x(5)	value 
		"LOC". 
    05  filler					pic x(6)	value 
		"I/O". 
*    05  filler					pic x(12)	value 
    05  filler					pic x(14)	value 
		"DATE". 
    05  filler					pic x(10)	value 
		"A/R". 
    05  filler					pic x(12)	value 
		"REVENUE". 
    05  filler					pic x(9)	value 
		"CASH". 
    05  filler					pic x(6)	value 
		"NBR". 
    05  filler					pic x(8)	value 
		"CYCLE". 
    05  filler					pic x(9)	value 
		"P.E.D.". 
*    05  filler					pic x(16)	value 
    05  filler					pic x(14)	value 
		"STATUS". 
 
01  h4-head. 
 
    05  filler					pic x(1)	value spaces. 
*    05  filler					pic x(15)	value 
    05  filler					pic x(17)	value 
*		"NUMBER". 
		"NUMBER /DP". 
    05  filler					pic x(12)	value 
		"TYPE/CODE". 
    05  filler					pic x(21)	value 
		"REG". 
*    05  filler					pic x(12)	value 
    05  filler					pic x(14)	value 
		"ENTERED". 
    05  filler					pic x(11)	value 
		"AMOUNT". 
    05  filler					pic x(11)	value 
		"AMOUNT". 
    05  filler					pic x(9)	value 
		"AMOUNT". 
    05  filler					pic x(8)	value 
		"CLAIMS". 
*    05  filler					pic x(32)	value 
    05  filler					pic x(28)	value 
		"NBR". 
 
01  h5-head. 
 
    05  filler					pic x(8)	value 
		"CLINIC". 
    05  h5-clinic-nbr				pic zz. 
    05  filler					pic x(15)	value spaces. 
    05  filler					pic x(15)	value 
		"---------------". 
    05  filler					pic x(23)	value 
		"C Y C L E   T O T A L S". 
    05  filler					pic x(18)	value 
		"------------". 
    05  filler					pic x(16)	value 
		"----------------". 
    05  filler					pic x(35)	value 
		"M. T. D.    T O T A L S-----------". 
 
01  h6-head. 
 
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
	    15  l1-batch-nbr-1-2		pic   99.     
*	    15  l1-doc-nbr			pic  999. 
	    15  l1-doc-nbr			pic  xxx. 
	    15  l1-week				pic   99.       
	    15  l1-day				pic    9.    
*	10  filler				pic x(3). 
 	10  l1-slash-1a				pic x. 
	10  l1-dept-code			pic 99. 
	10  filler				pic x(2). 
	10  l1-agent-code			pic 9(1). 
 	10  filler				pic x(6). 
	10  l1-batch-type			pic x(2). 
	10  l1-slash-1				pic x(2). 
	10  l1-adj-code				pic x(1). 
	10  l1-dash				pic x(1).        
	10  l1-adj-cd-sub-type			pic x(2). 
	10  l1-doc-nbr-ohip			pic 9(6) blank when zero. 
	10  filler				pic x(3). 
	10  l1-hos				pic x(1). 
	10  filler				pic x(3). 
	10  l1-loc. 
	    15  l1-loc-1			pic x(1). 
* MC5
*	    15  l1-loc-2-4			pic 9(3). 
	    15  l1-loc-2-4			pic x(3). 
* MC5 - end
	10  filler				pic x(2). 
	10  l1-i-o-pat-ind			pic x(4). 
* (y2k)
*	10  l1-date-yy				pic 9(2). 
	10  l1-date-yy				pic 9(4). 
	10  l1-slash-2				pic x(1).  
	10  l1-date-mm				pic 9(2). 
	10  l1-slash-3				pic x(1).       
	10  l1-date-dd				pic 9(2). 
*MC7 	10  filler				pic x(2). 
 	10  filler				pic x. 
*MC7    10  l1-amt-ar				pic zz,zz9.99-. 
	10  l1-amt-ar				pic zzzz,zz9.99-. 
	10  filler				pic x(1). 
*MC7 	10  l1-amt-rev				pic zz,zz9.99-. 
	10  l1-amt-rev				pic zzzz,zz9.99-. 
	10  filler				pic x(1). 
*MC7 	10  l1-amt-cash				pic zz,zz9.99-. 
	10  l1-amt-cash				pic zzzz,zz9.99-. 
*MC7    10  filler				pic x(3). 
	10  filler				pic x. 
	10  l1-last-claim			pic 9(2). 
*MC7	10  filler				pic x(4). 
	10  filler				pic x. 
	10  l1-cycle				pic zzz. 
	10  filler				pic x(3). 
* (y2k)
*	10  l1-ped-yy				pic 9(2). 
	10  l1-ped-yy				pic 9(4). 
	10  l1-slash-4				pic x(1). 
	10  l1-ped-mm				pic 9(2). 
	10  l1-slash-5				pic x(1). 
	10  l1-ped-dd				pic 9(2). 
	10  filler				pic x(4). 
	10  l1-status				pic x(1).       
* (y2k)	10  filler				pic x(13). 
	10  filler				pic x(9). 
    05  t1-print-line  redefines   l1-print-line. 
        10  t1-desc. 
	    15  t1-desc-a			pic x(13). 
	    15  t1-desc-b			pic x(5). 
        10  t1-dash				pic x. 
        10  filler				pic x. 
        10  t1-agent-cd				pic 9. 
        10  filler				pic x(1).     
* MC8
*       10  t1-detail-1				pic zzzz,zz9.99-. 
        10  t1-detail-1				pic zzzzzzz9.99-. 
* MC8 - end
        10  filler				pic x(1). 
* MC8
*       10  t1-detail-2				pic zzzz,zz9.99-. 
        10  t1-detail-2				pic zzzzzzz9.99-. 
* MC8 - end
        10  filler				pic x(1). 
        10  t1-detail-3				pic zzzz,zz9.99-. 
        10  filler				pic x(1). 
        10  t1-detail-4				pic zzz,zz9. 
        10  filler				pic x(1). 
        10  t1-detail-5				pic zzz,zz9. 
* 2008/03/26 - MC
*       10  filler				pic x(2). 
*       10  t1-detail-6				pic zzzz,zz9.99-. 
        10  filler				pic x. 
        10  t1-detail-6				pic zzzzz,zz9.99-. 
*       10  filler				pic x(1).  
*       10  t1-detail-7				pic zzzz,zz9.99-. 
        10  t1-detail-7				pic zzzzz,zz9.99-. 
* 2008/03/26 - end
        10  filler				pic x(1). 
        10  t1-detail-8				pic zzzz,zz9.99-. 
        10  filler				pic x(1). 
        10  t1-detail-9				pic zzz,zz9. 
        10  filler				pic x(1). 
        10  t1-detail-10			pic zzz,zz9. 
 
 
01  blank-line				pic x(132). 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  		line 12 col 25 value is "BATCH SUMMARY REPORT - CONTINUE (Y/N) ?". 
    05  scr-reply	line 12 col 65 pic x to ws-reply auto required. 
 
01  scr-prog-in-prog. 
 
    05  line 14 col 30 value is "R001 IN PROGRESS". 
 
*                     
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf  05  line 24 col 70 pic x(11) from common-status-file    bell blink. 
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
    05  line  5 col 20  value "NUMBER OF DOCTOR FILE ACCESSES = ". 
    05  line  5 col 60  pic 9(7) from ctr-doc-file-reads. 
    05  line  7 col 20  value "NUMBER OF BATCTRL-FILE ACCESSES = ". 
    05  line  7 col 60  pic 9(7) from ctr-batctrl-file-reads. 
*    05  line  9 col 20  value "NUMBER OF X ACCESSES = ". 
*    05  line  9 col 60  pic 9(7) from ctr-x. 
    05  line 21 col 20	value "PROGRAM R001 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4) from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
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
*mf    move status-iconst-mstr		to common-status-file. 
    move status-cobol-iconst-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING DOC MASTER ". 
*mf    move status-doc-mstr		to common-status-file. 
    move status-cobol-doc-mstr		to common-status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
 
 
 
 
 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from 	date. 
    move sys-mm				to 	run-mm.                 
    move sys-dd				to 	run-dd. 
    move sys-yy				to 	run-yy. 
 
    accept sys-time			from 	time. 
    move sys-hrs			to 	run-hrs. 
    move sys-min			to 	run-min. 
    move sys-sec			to 	run-sec. 
 
    display scr-title. 
aa0-10-continue-y-n. 
 
    move "Y"				to	ws-reply.
*    accept scr-reply. 
 
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
*    expunge print-file. 
 
    open input	batch-ctrl-file. 
    open input  doc-mstr. 
    open input  iconst-mstr. 
    open output print-file. 
 
    move zero				to 	counters  
					   	tbl-totals 
					   	final-totals 
						disk-totals 
						disk-finals 
					   	ctr-page. 
    move 65				to 	ctr-line. 
    move "N"				to	last-page-flag. 
    move spaces				to 	print-line 
						blank-line. 
 
 
 
*mf move zero				to 	key-batch-nbr. 
*!    move zero				to 	batctrl-batch-nbr. 
    move spaces 			to 	batctrl-batch-nbr. 
 
    perform xf0-select-batctrl-rec	thru	xf0-99-exit 
		until   valid-rec    
		     or eof-batctrl-file = "Y". 
 
    if eof-batctrl-file = "Y" 
    then 
	move 4				to 	err-ind 
	perform za0-common-error	thru 	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    perform xd0-zero-clinic-totals	thru	xd0-99-exit. 
 
*    (save clinic nbr) 
    perform xb0-save-clinic-info	thru	xb0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform zb0-print-clinic-tots-summary 	thru	zb0-99-exit. 
    perform xc0-add-to-fin-totals		thru	xc0-99-exit. 
    perform ze0-move-and-print-fin-tot		thru	ze0-99-exit. 
 
    close batch-ctrl-file 
	  iconst-mstr 
          doc-mstr 
	  print-file. 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
*	(print clinic totals if new clinic) 
    if batctrl-bat-clinic-nbr-1-2	not = hold-clinic-nbr 
    then 
	perform zb0-print-clinic-tots-summary 
					thru	zb0-99-exit  
	perform xc0-add-to-fin-totals	thru 	xc0-99-exit 
	perform xd0-zero-clinic-totals	thru 	xd0-99-exit 
	perform xb0-save-clinic-info	thru 	xb0-99-exit. 
*   (else) 
*   endif 
 
 
*    (batch is considered current if -- 
*       -- the batch is balanced and has not as yet been sent to ohip ("1") 
 
    if   batctrl-batch-status = "1" 
      or batctrl-batch-status = "2" 
    then 
	perform ea0-move-fields		thru 	ea0-99-exit 
	perform ba0-write-detail-line	thru 	ba0-99-exit 
	move ss-cyc-offset		to 	cyc-mtd-offset 
	perform sa0-add-batch-totals	thru 	sa0-99-exit 
	move ss-mtd-offset		to 	cyc-mtd-offset 
	perform sa0-add-batch-totals	thru 	sa0-99-exit 
    else 
	if    batctrl-batch-status = '2' 
	  or  batctrl-batch-status = '3' 
	then 
*	    (include in month-to-date totals as long as p. e. d. matches)        
	    if batctrl-date-period-end = iconst-date-period-end 
	    then 
		move ss-mtd-offset	to 	cyc-mtd-offset 
		perform sa0-add-batch-totals 
					thru 	sa0-99-exit 
	    else 
		next sentence 
*	    endif 
	else 
*	    (only status '1','2' and '3' batches processed) 
     	    next sentence. 
*	endif 
*   endif 
 
    perform xf0-select-batctrl-rec	thru 	xf0-99-exit. 
 
    if eof-batctrl-file = "N" 
    then 
	go to ab0-processing 
    else 
	next sentence. 
*   endif 
 
ab0-99-exit. 
    exit. 
ba0-write-detail-line. 
 
    add 1				to ctr-line. 
    if ctr-line > max-nbr-lines 
    then 
	perform xa0-headings		thru xa0-99-exit. 
*   (else) 
*   endif 
 
    write print-record    from print-line after advancing 1 line. 
    move spaces				to print-line. 
 
ba0-99-exit. 
    exit. 
ea0-move-fields. 
 
    move batctrl-bat-clinic-nbr-1-2	to 	l1-batch-nbr-1-2. 
    move batctrl-bat-doc-nbr		to 	l1-doc-nbr. 
    move batctrl-bat-week		to 	l1-week. 
    move batctrl-bat-day		to 	l1-day. 
    move batctrl-bat-doc-nbr		to	doc-nbr. 
    perform xf1-read-doc-mstr		thru	xf1-99-exit. 
    move "/"				to	l1-slash-1a. 
    move doc-dept			to	l1-dept-code. 
    move batctrl-agent-cd		to 	l1-agent-code. 
    move batctrl-batch-type		to	l1-batch-type. 
    move "/"				to	l1-slash-1. 
*   if batctrl-adj-cd = "0" 
*   then 
*	move spaces 			to	l1-adj-code 
*   else 
*	move batctrl-adj-cd		to	l1-adj-code 
*	if batctrl-adj-cd = "M" 
*	then 
*	    move "-"			to	l1-dash 
*	    move batctrl-adj-cd-sub-type 
*					to	l1-adj-cd-sub-type 
*	else 
*	    move spaces			to	l1-dash 
*						l1-adj-cd-sub-type. 
*	endif 
*   endif 
** 
** the above has been commented out and replace with the following 
**  lines by bml on nov 1/90 . sms 133. 
** 
    move batctrl-adj-cd 		to 	l1-adj-code. 
    if batctrl-adj-cd-sub-type  not = '0' 
       then 
          move batctrl-adj-cd-sub-type 	to 	l1-adj-cd-sub-type 
          move "/"			to	l1-dash. 
*      else. 
*   endif. 
 
    move batctrl-doc-nbr-ohip		to	l1-doc-nbr-ohip. 
    move batctrl-hosp			to	l1-hos. 
    move batctrl-loc1			to	l1-loc-1. 
    move batctrl-loc2-4			to	l1-loc-2-4. 
    move batctrl-i-o-pat-ind		to	l1-i-o-pat-ind. 
    move batctrl-date-batch-entered	to	ws-date-sv. 
    move ws-date-sv-yy			to	l1-date-yy. 
    move "/"				to	l1-slash-2. 
    move ws-date-sv-mm			to	l1-date-mm. 
    move "/"				to	l1-slash-3.  
    move ws-date-sv-dd			to	l1-date-dd. 
    move batctrl-calc-ar-due		to	l1-amt-ar. 
    move batctrl-calc-tot-rev		to	l1-amt-rev. 
    move batctrl-manual-pay-tot		to	l1-amt-cash. 
    move batctrl-nbr-claims-in-batch	to 	l1-last-claim. 
*	(print cycle nbr only if the batch'S CYCLE IS NOT = TO THE CURRENT CYCLE) 
    if batctrl-cycle-nbr = iconst-clinic-cycle-nbr 
    then 
	move zeroes			to 	l1-cycle 
    else 
	move batctrl-cycle-nbr		to 	l1-cycle. 
*   endif 
 
    move batctrl-date-period-end-yy	to	l1-ped-yy. 
    move "/"				to	l1-slash-4. 
    move batctrl-date-period-end-mm	to	l1-ped-mm. 
    move "/"				to	l1-slash-5. 
    move batctrl-date-period-end-dd	to	l1-ped-dd. 
 
    if batctrl-batch-status = "4" 
    then 
	move spaces			to	l1-status 
    else 
	move batctrl-batch-status	to	l1-status. 
*   endif 
 
ea0-99-exit. 
    exit. 
sa0-add-batch-totals. 
 
    perform sa1-find-ss-type 		thru	sa1-99-exit. 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, batctrl-agent-cd		giving	ss-agent. 

*mf add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, cyc-mtd-offset + ss-a-r ).    
*mf add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, cyc-mtd-offset + ss-rev ).   
*mf add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, cyc-mtd-offset + ss-cash  ). 
*mf add batctrl-nbr-claims-in-batch		to	tbl-tot (ss-type, ss-agent, cyc-mtd-offset + ss-nbr-claims ).         
*mf add batctrl-svc-act				to	tbl-tot (ss-type, ss-agent, cyc-mtd-offset + ss-nbr-svcs ).         
 
    add cyc-mtd-offset, ss-a-r			giving	ss-temp1. 
    add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 )
    add cyc-mtd-offset, ss-rev			giving  ss-temp1.
    add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
    add cyc-mtd-offset, ss-cash			giving  ss-temp1.
    add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
    add cyc-mtd-offset, ss-nbr-claims 		giving  ss-temp1.
    add batctrl-nbr-claims-in-batch		to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
    add cyc-mtd-offset, ss-nbr-svcs		giving  ss-temp1.
    add batctrl-svc-act				to	tbl-tot (ss-type, ss-agent, ss-temp1 ).
 
    if batctrl-batch-type = "C" 
       and batctrl-adj-cd-sub-type = "D" 
        or batctrl-adj-cd-sub-type = "W" 
    then 
*mf     add batctrl-calc-ar-due     		to	disk-tot-tab ( cyc-mtd-offset + ss-a-r ) 
*mf     add batctrl-nbr-claims-in-batch		to	disk-tot-tab ( cyc-mtd-offset + ss-nbr-claims ) 
*mf     add batctrl-svc-act			to	disk-tot-tab ( cyc-mtd-offset + ss-nbr-svcs ). 
        add cyc-mtd-offset, ss-a-r 		giving  ss-temp1
        add batctrl-calc-ar-due     		to	disk-tot-tab ( ss-temp1)
        add cyc-mtd-offset, ss-nbr-claims	giving  ss-temp1
        add batctrl-nbr-claims-in-batch		to	disk-tot-tab ( ss-temp1)
        add cyc-mtd-offset, ss-nbr-svcs 	giving  ss-temp1
        add batctrl-svc-act			to	disk-tot-tab ( ss-temp1). 
*   endif. 
  
sa0-99-exit. 
    exit. 
 
 
 
sa1-find-ss-type. 
 
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
 
sa1-99-exit. 
    exit. 
* 
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
 
    move zero   				   to 	tbl-tot (ss-type-from, ss-agent-from, 1 )                   
						       	tbl-tot (ss-type-from, ss-agent-from, 2 ) 
                				        tbl-tot (ss-type-from, ss-agent-from, 3 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 4 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 5 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 6 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 7 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 8 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 9 )             
                				        tbl-tot (ss-type-from, ss-agent-from, 10 ).           
 
te0-99-exit. 
    exit. 
tb0-write-line. 
 
    add  nbr-lines-to-advance				to	ctr-line.     
    if ctr-line > max-nbr-lines 
    then 
 	perform tc0-print-headings			thru	tc0-99-exit. 
*   (else) 
*   endif 
 
    write   print-record  from print-line      after advancing  nbr-lines-to-advance lines. 
 
    move spaces						to	print-line. 
    move 1						to	nbr-lines-to-advance. 
 
tb0-99-exit. 
    exit. 
* 
tc0-print-headings. 
 
    add 1					to	ctr-page.      
    move ctr-page				to	h1-page. 
    write print-record from h1-head after advancing page. 
    write print-record from h2-head after advancing 2 lines. 
     
    if not-last-page 
    then 
 	move hold-clinic-nbr			to	h5-clinic-nbr. 
*   (else) 
*   endif 
 
    write print-record from h5-head after advancing 2 lines. 
    write print-record from h6-head after advancing 1 line. 
    write print-record from blank-line after advancing 1 line. 
    move 6 					to	ctr-line. 
 
 
tc0-99-exit. 
    exit. 
 
tg0-move-vals-to-line. 
  
    move tbl-tot (ss-type-from, ss-agent, 1 )	to	t1-detail-1 . 
    move tbl-tot (ss-type-from, ss-agent, 2 )	to	t1-detail-2 . 
    move tbl-tot (ss-type-from, ss-agent, 3 )	to	t1-detail-3 . 
    move tbl-tot (ss-type-from, ss-agent, 4 )	to	t1-detail-4 . 
    move tbl-tot (ss-type-from, ss-agent, 5 )	to	t1-detail-5 . 
    move tbl-tot (ss-type-from, ss-agent, 6 )	to	t1-detail-6 . 
    move tbl-tot (ss-type-from, ss-agent, 7 )	to	t1-detail-7 . 
    move tbl-tot (ss-type-from, ss-agent, 8 )	to	t1-detail-8 . 
    move tbl-tot (ss-type-from, ss-agent, 9 )	to	t1-detail-9 . 
    move tbl-tot (ss-type-from, ss-agent, 10 )	to	t1-detail-10 .  
 
tg0-99-exit. 
    exit. 
xa0-headings. 
 
    add 1				to ctr-page. 
    move ctr-page			to h1-page. 
    write print-record from h1-head after advancing page. 
    write print-record from h2-head after advancing 1 line. 
    write print-record from h3-head after advancing 2 lines. 
    write print-record from h4-head after advancing 1 line. 
    write print-record from blank-line after advancing 1 line. 
    move 6				to ctr-line. 
 
xa0-99-exit. 
    exit. 
xb0-save-clinic-info. 
 
    move batctrl-bat-clinic-nbr-1-2	to hold-clinic-nbr. 
*	(obtain cycle nbr & period end from constants mstr) 
 
    move hold-clinic-nbr		to iconst-clinic-nbr-1-2. 
    read iconst-mstr 
 	invalid key 
 	    move 2			to err-ind 
 	    perform za0-common-error	thru za0-99-exit 
 	    go to az0-end-of-job. 
 
    move iconst-clinic-nbr-1-2		to h1-clinic-nbr. 
    move iconst-clinic-cycle-nbr	to h2-cycle   
					   ws-hold-cycle-nbr. 
    move iconst-date-period-end-yy	to h2-period-end-yy. 
    move iconst-date-period-end-mm	to h2-period-end-mm. 
    move iconst-date-period-end-dd	to h2-period-end-dd. 
    move iconst-clinic-name		to h2-clinic-name. 
 
xb0-99-exit. 
    exit. 
 
 
xc0-add-to-fin-totals. 
 
* 2010/03/09 - MC1 - include clinic 66
*   if hold-clinic-nbr > 59 and hold-clinic-nbr < 66 
   if hold-clinic-nbr > 59 and hold-clinic-nbr < 67 
* 2010/03/09 - end
   then 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	clinic-tot-1  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	clinic-tot-2  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	clinic-tot-3  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	clinic-tot-4  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	clinic-tot-5  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	clinic-tot-6  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	clinic-tot-7  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	clinic-tot-8  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	clinic-tot-9  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	clinic-tot-10. 
*  endif 
 
* 2007/04/19 - MC - add for clinic 70's total
   if hold-clinic-nbr > 70 and hold-clinic-nbr < 76 
   then 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	clinic2-tot-1  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	clinic2-tot-2  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	clinic2-tot-3  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	clinic2-tot-4  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	clinic2-tot-5  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	clinic2-tot-6  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	clinic2-tot-7  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	clinic2-tot-8  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	clinic2-tot-9  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	clinic2-tot-10. 
*  endif 
* 2007/04/19 - end

* MC3 
* MC6 - include clinic 26
*   if    (hold-clinic-nbr >= 22 and hold-clinic-nbr <= 25)
   if    (hold-clinic-nbr >= 22 and hold-clinic-nbr <= 26)
* MC6 - end
* MC4 - include clinic 30
*     or (hold-clinic-nbr >= 31 and hold-clinic-nbr <= 36)
      or (hold-clinic-nbr >= 30 and hold-clinic-nbr <= 36)
* MC4 - end
      or (hold-clinic-nbr >= 41 and hold-clinic-nbr <= 48)
   then
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	clinic3-tot-1  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	clinic3-tot-2  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	clinic3-tot-3  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	clinic3-tot-4  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	clinic3-tot-5  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	clinic3-tot-6  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	clinic3-tot-7  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	clinic3-tot-8  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	clinic3-tot-9  
    add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	clinic3-tot-10. 
*  endif 
* MC3 - end 
 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 )	to	fin-tot-1. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 )	to	fin-tot-2. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 )	to	fin-tot-3. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 )	to	fin-tot-4. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 )	to	fin-tot-5. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 )	to	fin-tot-6. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 )	to	fin-tot-7. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 )	to	fin-tot-8. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 9 )	to	fin-tot-9. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 10 ) 	to	fin-tot-10.  
 
    add disk-tot-tab ( 1 )                              to      disk-grnd-tab (1). 
    add disk-tot-tab ( 4 )                              to      disk-grnd-tab (4). 
    add disk-tot-tab ( 5 )                              to      disk-grnd-tab (5). 
    add disk-tot-tab ( 6 )                              to      disk-grnd-tab (6). 
    add disk-tot-tab ( 9 )                              to      disk-grnd-tab (9). 
    add disk-tot-tab ( 10 )                             to      disk-grnd-tab (10). 
 
xc0-99-exit. 
    exit. 
 
 
xd0-zero-clinic-totals. 
 
    move zero				to	tbl-totals. 
    move zero                           to      disk-totals. 
 
xd0-99-exit. 
    exit. 
xf0-select-batctrl-rec. 
 
    read batch-ctrl-file next 
	at end 
	    move "Y"			to eof-batctrl-file 
	    move "N"			to flag-rec 
	    go to xf0-99-exit. 
 
*    (ignore all but this months balanced batches) 
*     -------------- 
    if   (batctrl-batch-status = "1") 
      or (batctrl-batch-status = "2") 
      or (batctrl-batch-status = "3") 
    then 
	next sentence 
    else 
	go to xf0-select-batctrl-rec. 
*   endif 
 
    move "Y"				to flag-rec.   
 
    add 1				to ctr-batctrl-file-reads. 
 
*    ('P'ayments are stored as negative amounts in f001 file but are to 
*     appear as positive in the report so sign is reversed) 
 
    if    batctrl-batch-type = "P" 
      and batctrl-adj-cd     = "C" 
    then 
	subtract batctrl-calc-ar-due	from zero 
					giving batctrl-calc-ar-due 
	subtract batctrl-calc-tot-rev	from zero 
					giving batctrl-calc-tot-rev 
	subtract batctrl-manual-pay-tot	from zero 
					giving	batctrl-manual-pay-tot. 
*   (else) 
*   endif 
 
xf0-99-exit. 
    exit. 
 
  
xf1-read-doc-mstr. 
 
    read doc-mstr 
	invalid key 
	    move "INVALID DOCTOR" 	to	doc-name 
	    go to xf1-99-exit. 
 
 
    add 1				to	ctr-doc-file-reads. 
 
 
 
xf1-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
zb0-print-clinic-tots-summary. 
  
*   (start totals on new page) 
    move 98				to	ctr-line. 
 
*   (flags will determine if batch type and adjustment type desciptions are to be printed) 
    move "N"				to	sw-printed-bat-type 
						sw-printed-adj-type. 
 
    perform zc0-process-batch-totals	thru	zc0-99-exit 
	    varying ss-type 
	    from  1 
	    by    1 
	    until   ss-type > max-nbr-types. 
 
*    (print 'GRAND' totals - ss-grand-tot moved to ss-type) 
 
    move ss-grand-tot			to	ss-type.    
    perform zc0-process-batch-totals	thru	zc0-99-exit. 
 
    move 2                              to nbr-lines-to-advance. 
    move "DISKETTE TOTALS"              to t1-desc. 
    move disk-tot-tab (1)               to t1-detail-1. 
    move disk-tot-tab (1)               to t1-detail-2. 
    move disk-tot-tab (4)               to t1-detail-4. 
    move disk-tot-tab (5)               to t1-detail-5. 
    move disk-tot-tab (6)               to t1-detail-6. 
    move disk-tot-tab (6)               to t1-detail-7. 
    move disk-tot-tab (9)               to t1-detail-9. 
    move disk-tot-tab (10)              to t1-detail-10. 
    perform tb0-write-line              thru tb0-99-exit. 
 
*   (start next clinic printout on new page) 
    move 98				to	ctr-line. 
 
zb0-99-exit. 
    exit. 
zc0-process-batch-totals. 
 
*	(this rtn called varying 'SS-TYPE' except for grand totals 
*        where ss-type = ss-grand-tot) 
 
    perform zd0-prt-agent-vals-and-sum	thru	zd0-99-exit 
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
	    move "             TOTAL"		to	t1-desc 
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
	    move "    TOTALS"			to	t1-desc 
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
 
zc0-99-exit. 
    exit. 


zd0-prt-agent-vals-and-sum. 
*    (this routine called varying 'SS-AGENT') 
 
*    (print line only if non-zero values for 'AGENT') 
*    ( note:  'NBR-CLAIMS + OFFSET' gives m.t.d. values) 
 
    add ss-nbr-claims, ss-offset	giving	ss-temp1.
    if     tbl-tot (ss-type, ss-agent, ss-nbr-claims) 	           = zero 
*mf    and tbl-tot (ss-type, ss-agent, ss-nbr-claims + ss-offset ) = zero 
       and tbl-tot (ss-type, ss-agent, ss-temp1			 ) = zero 
    then 
	go to zd0-99-exit. 
*   (else) 
*   endif 
 
    move spaces				to	t1-desc. 
 
*    (if printing 1st detail line for this batch type then include 
*     batch type description) 
    if sw-printed-bat-type = "N" 
    then 
	move "Y"			to	sw-printed-bat-type 
	move desc-bat-type (ss-type)	to	t1-desc-a 
	move 3				to	nbr-lines-to-advance. 
*   (else) 
*   endif 
 
*    (if printing 1st detail line for this adjustment type then include 
*     adjustment type description) 
    if sw-printed-adj-type = "N" 
    then 
	move "Y"			to	sw-printed-adj-type 
	move desc-adj-type (ss-type)	to	t1-desc-b. 
*   (else) 
*   endif 
 
    move "-"				to	t1-dash. 
    subtract 1				from	ss-agent 
					giving	t1-agent-cd. 
    move ss-type			to	ss-type-from. 
    perform tg0-move-vals-to-line	thru	tg0-99-exit. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
*   (sum the batch "TYPE'S" totals for all agents - unless printing 'GRAND TOTALS) 
    if ss-type = ss-grand-tot 
    then 
	go to zd0-99-exit. 
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
  
zd0-99-exit. 
    exit. 
ze0-move-and-print-fin-tot. 

* 2012/02/15 - MC2 - retrieve cycle & ped for clinic 60
    move 60                             to hold-clinic-nbr
					   iconst-clinic-nbr-1-2.
    read iconst-mstr
        invalid key
            move 2                      to err-ind
            perform za0-common-error    thru za0-99-exit
            go to az0-end-of-job.

    move iconst-clinic-nbr-1-2          to h1-clinic-nbr
					   h5-clinic-nbr.
    move iconst-clinic-cycle-nbr        to h2-cycle.    
    move iconst-date-period-end-yy      to h2-period-end-yy.
    move iconst-date-period-end-mm      to h2-period-end-mm.
    move iconst-date-period-end-dd      to h2-period-end-dd.
    move iconst-clinic-name             to h2-clinic-name.
* 2012/02/15 - end 
 
    move "CLINIC 60 TOTALS "  		to	t1-desc. 
 
    move clinic-tot-1			to	t1-detail-1. 
    move clinic-tot-2			to	t1-detail-2. 
    move clinic-tot-3			to	t1-detail-3. 
    move clinic-tot-4			to	t1-detail-4. 
    move clinic-tot-5			to	t1-detail-5. 
    move clinic-tot-6			to	t1-detail-6. 
    move clinic-tot-7			to	t1-detail-7. 
    move clinic-tot-8			to	t1-detail-8. 
    move clinic-tot-9			to	t1-detail-9. 
    move clinic-tot-10			to	t1-detail-10.  
 

* 2012/02/15 - MC2 - comment out
*    move zero				to	h1-clinic-nbr 
*                    				h2-cycle  
*						h2-period-end-yy  
*						h2-period-end-mm 
*						h2-period-end-dd 
*						h5-clinic-nbr. 
*    move spaces			to	h2-clinic-name. 
* 2012/02/15 - end
 
    move 3				to	nbr-lines-to-advance. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
    move 98				to	ctr-line. 
 
* 2007/04/19 - MC - add for clinic 70's total 

* 2012/02/15 - MC2 - retrieve cycle & ped for clinic 70
    move 70                             to hold-clinic-nbr
					   iconst-clinic-nbr-1-2.
    read iconst-mstr
        invalid key
            move 2                      to err-ind
            perform za0-common-error    thru za0-99-exit
            go to az0-end-of-job.

    move iconst-clinic-nbr-1-2          to h1-clinic-nbr
					   h5-clinic-nbr.
    move iconst-clinic-cycle-nbr        to h2-cycle.    
    move iconst-date-period-end-yy      to h2-period-end-yy.
    move iconst-date-period-end-mm      to h2-period-end-mm.
    move iconst-date-period-end-dd      to h2-period-end-dd.
    move iconst-clinic-name             to h2-clinic-name.
* 2012/02/15 - end 
 
    move "CLINIC 70 TOTALS "  		to	t1-desc. 
 
    move clinic2-tot-1			to	t1-detail-1. 
    move clinic2-tot-2			to	t1-detail-2. 
    move clinic2-tot-3			to	t1-detail-3. 
    move clinic2-tot-4			to	t1-detail-4. 
    move clinic2-tot-5			to	t1-detail-5. 
    move clinic2-tot-6			to	t1-detail-6. 
    move clinic2-tot-7			to	t1-detail-7. 
    move clinic2-tot-8			to	t1-detail-8. 
    move clinic2-tot-9			to	t1-detail-9. 
    move clinic2-tot-10			to	t1-detail-10.  
 
    move 3				to	nbr-lines-to-advance. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
    move 98				to	ctr-line. 
* 2007/04/19 - end    
 
* MC3
    move "22 - 48  TOTALS"  		to	t1-desc. 
 
    move clinic3-tot-1			to	t1-detail-1. 
    move clinic3-tot-2			to	t1-detail-2. 
    move clinic3-tot-3			to	t1-detail-3. 
    move clinic3-tot-4			to	t1-detail-4. 
    move clinic3-tot-5			to	t1-detail-5. 
    move clinic3-tot-6			to	t1-detail-6. 
    move clinic3-tot-7			to	t1-detail-7. 
    move clinic3-tot-8			to	t1-detail-8. 
    move clinic3-tot-9			to	t1-detail-9. 
    move clinic3-tot-10			to	t1-detail-10.  
 
    move zero                          to       h1-clinic-nbr
                                                h2-cycle
                                                h2-period-end-yy
                                                h2-period-end-mm
                                                h2-period-end-dd
                                                h5-clinic-nbr.
* MC4
*   move 'Total for clinic 22-25, 31-36, 41-48 for payroll balancing' 
* MC6 - include clinic 26
*    move 'Total for clinic 22-25, 30-36, 41-48 for payroll balancing' 
    move 'Total for clinic 22-26, 30-36, 41-48 for payroll balancing' 
* MC6 - end
* MC4 - end
                                       to       h2-clinic-name.
 
    move "Y"				to	last-page-flag. 
    move 3				to	nbr-lines-to-advance. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
    move 98				to	ctr-line. 
* MC3  - end

    move " FINAL TOTALS  "  		to	t1-desc. 
 
    move fin-tot-1			to	t1-detail-1. 
    move fin-tot-2			to	t1-detail-2. 
    move fin-tot-3			to	t1-detail-3. 
    move fin-tot-4			to	t1-detail-4. 
    move fin-tot-5			to	t1-detail-5. 
    move fin-tot-6			to	t1-detail-6. 
    move fin-tot-7			to	t1-detail-7. 
    move fin-tot-8			to	t1-detail-8. 
    move fin-tot-9			to	t1-detail-9. 
    move fin-tot-10			to	t1-detail-10.  
 
    move zero				to	h1-clinic-nbr 
                    				h2-cycle  
						h2-period-end-yy  
						h2-period-end-mm 
						h2-period-end-dd 
						h5-clinic-nbr. 
    move spaces				to	h2-clinic-name. 
 
    move "Y"				to	last-page-flag. 
    move 3				to	nbr-lines-to-advance. 
    perform tb0-write-line		thru	tb0-99-exit. 
 
    move 2                              to nbr-lines-to-advance. 
    move "DISKETTE TOTALS"              to t1-desc. 
    move disk-grnd-tab (1)              to t1-detail-1. 
    move disk-grnd-tab (1)              to t1-detail-2. 
    move disk-grnd-tab (4)              to t1-detail-4. 
    move disk-grnd-tab (5)              to t1-detail-5. 
    move disk-grnd-tab (6)              to t1-detail-6. 
    move disk-grnd-tab (6)              to t1-detail-7. 
    move disk-grnd-tab (9)              to t1-detail-9. 
    move disk-grnd-tab (10)             to t1-detail-10. 
    perform tb0-write-line              thru tb0-99-exit. 
 
ze0-99-exit. 
    exit. 