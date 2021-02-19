identification division. 
program-id.    r073. 
author.	       Dyad Infosys LTD.
installation.  rma. 
date-written.  81/02/05. 
date-compiled. 
security. 
* 
*    files      : f002	        - claims master ( 'NEW' version output of r072) 
*		: f090          - constants master 
*		: r073          - audit report 
*    program purpose:this program is used in conjunction with r071 and u072. 
*		its purpose is to verify the values in the purged claims 
*		master.  r071 verifies the non-purged claims and u072 purges 
*	        claims with a value of less than .86 and greater than -.86. 
* 
*    revision may 27/87 (s.b.) - coversion from aos to aos/vs. 
*                                change field size for 
*                                status clause to 2 and 
*                                feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*	     feb/89 (s.f.) - pdr 414 
*	                   - allow for agent 4 to be treated as a 
*			     direct bill the same as agent 6 
* 
* 
*   revised nov/91 (m.c.)	- pdr 525 
*				- include agent 8 claims with the cutoff 
*				  dates 
* 
*   revised jul/93 (y.b.)	- sra 076 
*				- change .64 to .85 write off amount 
* 
*   revised jun/94 (m.c.) 	- pdr 592 
*				- do not purge clinic 81 agent 8 claims 
* 
*   29/03/95 	b.m.l		- pdr 613 
*				- changed purge criteria to include a 
* 
*   14/04/97 	yas. 		- pdr 656 
*				- changed purge criteria to include a 
*				  purge of clinic 82 
*   16/04/97 	yas. 		- pdr 659  add mess code "I2" 
*   06/08/97 	yas. 		- pdr 664 
*				- changed purge criteria to include a 
*				  purge of clinic 83 
* 
*    feb/98     j. chau         - s149 unix conversion
*
*   1999/jul/12 B.E.		- cb3 rtn correction due to key corruption
*
*   2000/may/12 B.A.		- y2k
* 
*   2002/jul/05 M.C.		- change purge criteria to delete claims if 
*				  balance is between -.99 and +.99 for non-
*				  clinic 80's
* 
*   2002/jul/08 M.C.		- modify the amount picture size
* 
*   2002/sep/02     yas         - add new clinic 95 
*   2003/jun/03     yas         - add clinic 91,92,93,94,96
*   2003/dec/10	    M.C.      	- alpha doc nbr
*   2004/mar/16     M.C.       - modify select to use afp-flag instead of clinic nbr
*   2004/may/19     M.C.       - modify the value check on afp-flag(iconst-clinic-card-colour)
*			       - value 'O' represents old afp	 
*   2004/jul/10 b.e.     - correct alpha doctor number "add to claim number" to
*                          consider adding to alpha number
*  2008/apr/17      M.C. - hsc had unique logic for this pgm. merged hsc/rma pgms using site-id technique.
*  2011/Sep/13      MC1  - Yasemin  wants to change from < to  <= when comparing with cutoff-date
*  2011/Nov/30 	    MC2  - comment out the display as Yasemin requested
*  2012/Sep/18 	    MC3  - change the condition when calculating balance due to be the same as u072.qts
*  2014/Mar/29      MC4  - calculate balance due to use clmhdr-tot-claim-ar-ohip for all agents, same as r073.cbl & u072.qts
*
* 
environment division. 
input-output section. 
file-control. 

    copy  "f002_claims_mstr.slr".

*mf    select claims-mstr 
*	assign index to "F002_CLAIMS_MSTR_NEW" 
*mf	assign data  to "F002_CLAIMS_MSTR_NEW.DB"    
*mf	organization is indexed 
*mf	access mode  is dynamic 
*mf	record key   is key-claims-mstr     length is 18 
*mf		with  duplicates occurrence is claims-occur 
*mf	record key   is key-gen-claims-mstr length is  2 
*mf	infos status is status-claims-mstr. 
*	eof-flag     is eof-claims-mstr  
*
* 
    copy "f090_constants_mstr.slr". 
* 
* 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
* 
* 
* 
* 
* 
* 
* 
data division. 
file section. 
  
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
* 
    copy "f090_constants_mstr.fd". 
 
fd  print-file 
    record contains 132 characters. 
01  print-record				pic x(132). 
working-storage section. 
 
77  elapsed-hrs					pic 99. 
77  elapsed-min					pic 99. 
77  sys-hrs-pr					pic 99.          
77  sys-min-pr					pic 99. 
77  ctr-line					pic 999.       
77  line-advance				pic 99. 
77  nbr-lines-2-advance				pic 9. 
77  max-nbr-lines-per-page			pic 99	value 64. 
77  page-nbr					pic 999.       
*2000/05/12 - B.A.
*77  save-clinic-ped				pic x(6). 
77  save-clinic-ped				pic x(8). 
 
77  save-clinic-id				pic 99.       
*2000/05/12 - B.A. begin
*77  ws-ped-purge-from				pic 9(6). 
*77  ws-ped-purge-to				pic 9(6). 
*77  w-clmhdr-date-sys				pic x(6). 
*77  w-clmhdr-date-sys-n redefines 
*			w-clmhdr-date-sys	pic 9(6). 
77  ws-ped-purge-from				pic 9(8). 
77  ws-ped-purge-to				pic 9(8). 

* 2002/07/05 - MC
77  cutoff-date    	 			pic 9(8). 
* 2002/07/05 - end

77  w-clmhdr-date-sys				pic x(8). 
77  w-clmhdr-date-sys-n redefines 
			w-clmhdr-date-sys	pic 9(8). 
*2000/05/12 end
 
*   (tested to allow totals line to be surpressed if not detail lines 
*    have been printed) 
 
77  sw-printed-bat-type				pic x. 
77  sw-printed-adj-type				pic x. 
 
01  begin-time. 
    05  begin-hrs				pic 99.      
    05  begin-min				pic 99. 
    05  filler					pic 9(4). 
 
77  claims-occur				pic 9(12). 
77  claims-occur-new				pic 9(12). 
 
*   status file indicators 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-cobol-claims-mstr-new		pic xx    value zero. 
*mf 77  status-claims-mstr-new			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 
77  status-prt-file				pic xx    value zero. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-claims-mstr-new			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  const-mstr-rec-nbr				pic x. 
 
77  common-status-file				pic xx. 
77  status-cobol-claims-mstr			pic xx    value zero. 
77  status-cobol-iconst-mstr			pic xx    value zero. 

*   flag indicators 
77  err-ind					pic 99 	value zero. 
77  header-done					pic x 	value "N". 
77  totals-written				pic x	value "N". 
77  display-key-type				pic x(7). 
77  ss                                          pic 9(2) comp.

    copy  "site_id.ws".

01 tmp-doc-nbr-alpha.
    05 tmp-batch-nbr-index                      pic x(1) occurs 8 times.

01  flag-request-complete                       pic x.
    88  flag-request-complete-y                 value "Y".
    88  flag-request-complete-n                 value "N".

01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
*   eof flags 
77  error-flag					pic x   value "N". 
77  eof-claims-mstr				pic x	value "N". 
77  eof-claims-dtl				pic x	value "N". 
77  end-search-index				pic x   value "N". 
 
*   variables 
77  ss-var-err					pic 99  value 14. 
77  age-category				pic 99. 
77  day-old					pic s9(5).     
77  day-old-r					pic xxx. 
77  i						pic 99. 
77  dept-nbr					pic 9. 
77  age-yy					pic s99. 
77  age-mm					pic s99. 
77  age-dd					pic s99.    
77  ws-reply					pic x. 
77  ws-date-reply				pic x. 
 
*   total variables 
77  dept-tot-amount				pic s9(8)v99. 
77  balance-due					pic s9(6)v99.    
77  write-off-nbr-of-clms  			pic 999. 
 
*mf
77  ws-sys-date-long				pic 9(8).
*2000/05/12 - B.A.
*77  temp-date					pic 9(6).
77  temp-date					pic 9(8).
 
01  blank-line					pic x(132) value spaces. 
 
01  audit-line. 
     05  filler					pic x(10) value spaces. 
     05  audit-title				pic x(60). 
     05  filler 				pic x(10) value spaces. 
     05  audit-count				pic 9(10). 
     05  filler					pic x(42) value spaces. 
 
*   hold-area. 
*!77  hold-batch-nbr				pic 9(9) value zero. 
77  hold-batch-nbr				pic x(8) value zero. 
77  hold-claim-nbr				pic 9(2) value zero. 
77  hold-period-end				pic x(6). 
 
01  hold-key. 
    05  hold-key-clm-batch-nbr. 
    	10  hold-key-clinic-nbr1		pic 99. 
*!  	10  hold-key-doc-nbr			pic 9(4). 
  	10  hold-key-doc-nbr			pic x(3). 
	10  hold-key-week    			pic 99. 
	10  hold-key-day			pic 9. 
    05  hold-key-claim-nbr			pic 99. 
    05  hold-key-oma-code			pic x999. 
    05  hold-key-oma-suff			pic x. 
    05  hold-key-adj-nbr			pic x. 
 
01  sel-report-date. 
*2000/05/12 - B.A.
*    05  report-yy				pic 99. 
    05  report-yy				pic 9(4). 
    05  filler					pic x  value "/". 
    05  report-mm				pic 99. 
    05  filler					pic x  value "/". 
    05  report-dd				pic 99. 
 
01  counters-per-clinic. 
    05  ctr-clinic-delprev-nbr			pic 9(9). 
    05  ctr-clinic-delcurr-nbr			pic 9(9). 
    05  ctr-clinic-delcurr-amt			pic s9(9)v99. 
    05  ctr-clinic-delprev-amt			pic s9(9)v99. 
    05  ctr-clinic-concurr-nbr			pic 9(9). 
    05  ctr-clinic-conprev-nbr			pic 9(9). 
    05  ctr-clinic-concurr-amt			pic s9(9)v99. 
    05  ctr-clinic-conprev-amt			pic s9(9)v99. 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-claims-mstr-reads			pic 9(9). 
    05  ctr-nbr-hdr-rec-reads			pic 9(9). 
    05  ctr-nbr-hdr-rec-writes			pic 9(9). 
    05  ctr-nbr-dtl-rec-reads			pic 9(9). 
    05  ctr-nbr-dtl-rec-writes			pic 9(9). 
    05  ctr-claims-mstr-in-acctrec		pic 9(9). 
    05  ctr-amt-claims-mstr-in-acctrec		pic s9(9)v99. 
    05  ctr-claims-mstr-write-offs		pic 9(9). 
    05  ctr-amt-claims-mstr-write-offs		pic s9(9)v99. 
 
 
 
 
01  tbl-totals. 
    05  tbl-bat-type-and-tots	occurs   8  times. 
	10  tbl-agent-and-sums	occurs  11  times. 
	    15  tbl-item	occurs   8  times. 
		20  tbl-tot		pic s9(9)v99. 
*	(access using tbl-tot (ss-type, ss-agent, ss-item))      
01  tbl-totals-variable-ss. 
*mf
    05  ss-temp1			pic 9(6).
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
    05  max-nbr-items			pic  9	value  8. 
 
 
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
*	       (values 1 thru 4 used for deleted claims) 
*	       (values 5 thru 8 (obtained by adding variable offset) are 
*	        used for retained claims) 
 
	    05  ss-a-r-oma		pic 9	value  1. 
	    05  ss-a-r-ohip		pic 9	value  2. 
	    05  ss-cash			pic 9	value  3. 
	    05  ss-nbr			pic 9	value  4. 
	    05  ss-offset		pic 9	value  4. 
*		( variable offset ) 
	    05  del-ret-offset  	pic 9. 
 
 
 
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
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
**********    copy "F002_KEY_CLAIMS_MSTR_NEW.WS". 
 
01 print-file-name   				pic x(4)  value "r073". 
 
copy "sysdatetime.ws". 
 
copy "agent_code.ws". 
 
01  header-1.     
    05  filler				pic x(15)	value 
		"R073    P.E.D. ". 
* 2002/07/08 - MC
*    05  h1-ped				pic 99/99/99 	blank when zero. 
*   05  filler				pic x(17)	value spaces. 
    05  h1-ped				pic 9999/99/99 	blank when zero. 
    05  filler				pic x(15)	value spaces. 
* 2002/07/08 - end
    05  filler				pic x(57)	value "CLAIMS MASTER CONVERSION VERIFICATION REPORT".               
    05  filler				pic x(9)	value "RUN DATE". 
* 2002/07/08 - MC
*    05  h1-run-date  		    	pic x(8). 
*    05  filler				pic x(10)	value spaces. 
    05  h1-run-date  		    	pic x(10).
    05  filler				pic x(08)	value spaces. 
* 2002/07/08 - end
    05  filler				pic x(5)	value "PAGE". 
    05  h1-page-nbr			pic zz9. 
 
 
01  print-line-1. 
    05  l1-msg				pic x(55). 
*2000/05/12 - B.A.
*    05  l1-yy				pic 99.       
    05  l1-yy				pic 9(4).
    05  l1-slash-1			pic x. 
    05  l1-mm				pic 99. 
    05  l1-slash-2			pic x. 
    05  l1-dd				pic 99. 
    05  filler				pic x. 
    05  l1-hrs				pic 99. 
    05  l1-colon			pic x. 
    05  l1-min				pic 99. 
    05  filler				pic x(63).  
 
01  print-line-2   redefines	print-line-1. 
 
    05  l2-msg				pic x(55).     
    05  l2-ctr				pic zzz,zzz,zz9.     
    05  filler				pic x(66). 
 
01  print-line-3   redefines	print-line-1. 
 
    05  l3-msg				pic x(55). 
    05  l3-amt				pic zzz,zzz,zz9.99-. 
    05  filler				pic x(62).       
 
01  t2-print-line  redefines   print-line-1.   
    05  t2-desc. 
	10  t2-desc-a		pic x(13). 
	10  t2-desc-b		pic x(5). 
    05  t2-dash			pic x. 
    05  filler			pic x. 
    05  t2-agent-cd		pic 9. 
* 2002/07/08 - MC
*    05  filler			pic x(3).     
*    05  t2-detail-1		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-2		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-3		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-4		pic zzz,zz9. 
*   05  filler			pic x(2). 
*   05  t2-detail-5		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-6		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-7		pic z,zzz,zz9.99-. 
*   05  filler			pic x(2). 
*   05  t2-detail-8		pic zzz,zz9. 
    05  filler			pic x(2).     
    05  t2-detail-1		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-2		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-3		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-4		pic zzzz,zz9. 
    05  filler			pic x. 
    05  t2-detail-5		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-6		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-7		pic zzzzzz,zz9.99-. 
    05  filler			pic x. 
    05  t2-detail-8		pic zzzz,zz9. 
* 2002/07/08 - end
    05  filler			pic x(4). 
 
01  h5-head. 
 
    05  filler					pic x(2)	value spaces. 
    05  filler					pic x(8)	value 
		"CLINIC".   
    05  h5-clinic-nbr				pic 99. 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(11)	value 
		"-----------". 
    05  filler					pic x(23)	value 
		"WITHIN - WRITEOFF RANGE". 
    05  filler					pic x(20)	value 
		"-------------". 
    05  filler					pic x(14)	value 
		"--------------". 
    05  filler					pic x(35)	value 
		"OUTSIDE - WRITEOFF RANGE---------". 
 
01  h6-head. 
 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(12)	value 
		"AGENT".  
    05  filler					pic x(14)	value 
		"OMA AMT".  
    05  filler					pic x(15)	value 
		"OHIP AMT". 
    05  filler					pic x(15)	value 
		"CASH AMT". 
    05  filler					pic x(10)	value 
		"NBR". 
    05  filler					pic x(14)	value 
		"OMA AMT". 
    05  filler					pic x(15)	value 
		"OHIP AMT". 
    05  filler					pic x(15)	value 
		"CASH AMT". 
    05  filler					pic x(5) 	value 
		"NBR". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR MSGS". 
	10  filler				pic x(60)   value 
		"INVALID READ CLAIMS MSTR - INVALID KEY ON APPROX". 
	10  filler				pic x(60)   value 
		"INVALID READ CLAIMS MSTR - STATUS = 23 OR 99". 
	10  err-msg-5. 
* #5 
	    15  filler				pic x(50)   value 
		"INVALID READ ON CONSTANTS MASTER - CLINIC ID = ". 
	    15  err-msg-clinic-id		pic x(10). 
	10  filler				pic x(60)	value 
		"FATAL ERROR - NO CLAIMS IN CLAIMS MASTER". 
	10  filler				pic x(60)	value  
		"**** CAN BE RE-USED ****". 
	10  filler				pic x(60)   value 
		"**** CAN BE RE-USED ****". 
	10  err-msg-9. 
	    15  filler				pic x(40)    value 
		"INVALID WRITE NEW CLAIMS DTL - 'B' KEY=". 
	    15  bkey-clmdtl-err-msg		pic x(20) value spaces. 
	10  err-msg-10. 
* #10 
	    15  filler				pic x(40)    value 
		"INVALID WRITE NEW CLAIMS HDR - 'B' KEY=". 
	    15  bkey-clmhdr-err-msg		pic x(20) value spaces. 
	10  err-msg-11. 
	    15  filler				pic x(40)    value 
		"INVALID WRITE NEW CLAIMS HDR -'P' KEY = ". 
	    15  pkey-clm-err-msg		pic x(20) value spaces. 
	10  filler				pic x(60)	value 
		"**** CAN BE RE-USED ****". 
	10  filler				pic x(60)	value 
		"**** CAN BE RE-USED ****". 
	10  filler				pic x(60)    value 
		"**** CAN BE RE-USED ****". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 14 times.     
 
01  err-msg-comment				pic x(60).      
 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(67). 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 01 col 01 value is "R073". 
    05  line 01 col 29 value is "CLAIMS MASTER VERIFICATION". 
*2000/05/12 - B.A.
*    05  line 01 col 73 pic 99 from sys-yy. 
*    05  line 01 col 75 value is "/". 
*    05  line 01 col 76 pic 99 from sys-mm. 
*    05  line 01 col 78 value is "/". 
*    05  line 01 col 79 pic 99 from sys-dd. 
    05  line 01 col 71 pic 9(4) from sys-yy.
    05  line 01 col 75 value is "/".
    05  line 01 col 76 pic 99 from sys-mm.
    05  line 01 col 78 value is "/".
    05  line 01 col 79 pic 99 from sys-dd.
*2000/05/12 end
 
01  msg-continue. 
    05  line 16 col 10 value is "CONTINUE?  (ENTER Y OR N )". 
    05  reply line 16 col 40 pic x using ws-reply auto required. 
 
 
 
01  scr-purge-ped. 
* 2002/07/05 - MC
*    05  line 16 col 10 value is "ENTER PED TO PURGE FROM YYMMDD :". 
    05  line 16 col 10 value is "ENTER PED CUTOFF DATE YYYYMM01: " . 
    05  scr-ped-date  line 16 col 44 pic 9(8) using cutoff-date       auto required. 
* 2002/07/05 - END
*2000/05/12 - B.A begin
*    05  scr-ped-from line 16 col 44 pic 9(6) using ws-ped-purge-from auto required. 
*2002/07/05 - MC - comment out with **
**    05  scr-ped-from line 16 col 44 pic 9(8) using ws-ped-purge-from auto required. 
**    05  line 17 col 10 value is "ENTER PED TO PURGE TO   YYMMDD :". 
*    05  scr-ped-to   line 17 col 44 pic 9(6) using ws-ped-purge-to auto required. 
**    05  scr-ped-to   line 17 col 44 pic 9(8) using ws-ped-purge-to auto required. 
*2002/07/05 - end
*2000/05/12 end
    05  line 18 col 10 value is "CONTINUE?  (ENTER Y OR N )". 
    05  scr-reply line 18 col 40 pic x using ws-reply auto required. 
 
01  program-in-progress. 
    05  line 20 col 10 value "PROGRAM R073 IN PROGRESS". 
 
01  test-key-display. 
    05  line 22 col 05 pic x(17) using key-claims-mstr. 
    05  line 22 col 30 pic 9(7)  using ctr-claims-mstr-reads. 
 
01  confirm. 
    05  line 23 col 01  value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) using common-status-file  bell blink. 
    05  line 24 col 70 pic x(2) using common-status-file  bell blink. 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR - "  bell blink. 
    05  line 24 col 11 pic x(60) from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1 blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 11 col 20  value "NUMBER OF CLAIM MSTR READS = ". 
    05  line 11 col 60  pic zzz,zzz,zz9  using ctr-claims-mstr-reads. 
    05  line 12 col 20  value "NUMBER OF HEADER RECS READ =". 
    05  line 12 col 60  pic zzz,zzz,zz9  using ctr-nbr-hdr-rec-reads. 
    05  line 13 col 20  value "NUMBER OF DETAIL RECS READ =". 
    05  line 13 col 60  pic zzz,zzz,zz9  using ctr-nbr-dtl-rec-reads. 
    05  line 20 col 20  value "PROGRAM R073 BEGAN". 
*2000/05/12 - B.A.
*    05  line 20 col 55  pic 99  from run-yy. 
*    05  line 20 col 57 value "/". 
*    05  line 20 col 58  pic 99  from run-mm. 
*    05  line 20 col 60  value "/". 
*    05  line 20 col 61  pic 99  from run-dd. 
*    05  line 20 col 64  pic 99  from begin-hrs.
*    05  line 20 col 66  value ":".
*    05  line 20 col 67  pic 99  from begin-min.
    05  line 20 col 55  pic 9(4) from run-yy. 
    05  line 20 col 59 value "/".
    05  line 20 col 60  pic 99  from run-mm.
    05  line 20 col 62 value "/".
    05  line 20 col 63  pic 99  from run-dd.
    05  line 20 col 66  pic 99  from begin-hrs. 
    05  line 20 col 68  value ":". 
    05  line 20 col 69  pic 99  from begin-min. 
*2000/05/12 end
    05  line 21 col 20	value "PROGRAM R073 ENDING". 
*2000/05/12 - B.A. begin
*    05  line 21 col 55  pic 99  from sys-yy. 
*    05  line 21 col 57	value "/". 
*    05  line 21 col 58	pic 99  from sys-mm. 
*    05  line 21 col 60	value "/". 
*    05  line 21 col 61	pic 99	from sys-dd. 
*    05  line 21 col 64  pic 99  from sys-hrs-pr.
*    05  line 21 col 66  value ":".
*    05  line 21 col 67  pic 99  from sys-min-pr.
    05  line 21 col 55 pic 9(4)  from sys-yy.
    05  line 21 col 59  value "/".
    05  line 21 col 60  pic 99  from sys-mm.
    05  line 21 col 62  value "/".
    05  line 21 col 63  pic 99  from sys-dd.
    05  line 21 col 66	pic 99	from sys-hrs-pr. 
    05  line 21 col 68	value ":". 
    05  line 21 col 69	pic 99	from sys-min-pr.        
*2000/05/12 end
    05  line 22 col 20  value "TOTAL ELAPSED TIME (HH:MM) -". 
    05  line 22 col 64  pic 99  using elapsed-hrs. 
    05  line 22 col 66  value ":". 
    05  line 22 col 67  pic 99  using elapsed-min. 
    05  line 23 col 20  value "REPORT FOUND IN". 
    05  line 23 col 36 pic x(4) using print-file-name. 
procedure division. 
declaratives. 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
 
err-constants-mstr. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
*mf    move status-iconst-mstr			to common-status-file. 
    move status-cobol-iconst-mstr		to common-status-file. 
    display file-status-display. 
    stop run. 
 
err-claim-header-mstr-file section. 
    use after standard error procedure on claims-mstr. 
 
err-claims-mstr. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
*mf    move status-claims-mstr			to common-status-file. 
    move status-cobol-claims-mstr		to common-status-file. 
    display file-status-display. 
 
end declaratives. 
 
mainline section.  
 
    perform aa0-initialization			thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
    accept sys-date			from	date.    
*2000/05/12 - B.a.
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.

    move sys-yy				to	run-yy. 
    move sys-mm				to	run-mm.    
    move sys-dd				to	run-dd. 
 
    accept begin-time			from	time. 
 
    open input 	claims-mstr 
    		iconst-mstr. 
*********    open i-o   	claims-mstr-new. 
 
*   delete existing print file 
 
*    expunge print-file. 
 
    open output print-file. 
 
    move spaces				to	day-old-r 
						print-line-1. 
    move zeros				to	balance-due 
						hold-key 
						page-nbr 
						tbl-totals 
						counters. 
 
    move 98				to	ctr-line. 
    move run-date			to	h1-run-date. 
 
*    (display screen title) 
    display scr-title. 
 
*   display msg-continue. 
 
*   accept reply. 
 
 
    display scr-purge-ped. 

*2002/07/05 - MC
*   accept scr-ped-from. 
*   accept scr-ped-to. 
    accept scr-ped-date.
*2002/07/05 - end

    accept scr-reply. 
 
    if 	ws-reply not = "Y" 
    then 
        go to az0-finalization 
    else 
        display program-in-progress. 
*   endif 
 
 
*	(zero clinic audit ctrs) 
    perform xc0-zero-clinic-ctrs	thru	xc0-99-exit. 
 
aa0-20-read-claims-mstr. 
 
*mf    move "B"				to	key-clm-key-type. 
    move "B"				to	clmdtl-b-key-type. 
************************************************************************* 
*mf    move zero				to	key-clm-data. 
       move zero				to	clmdtl-b-data. 
****    move "60"				to	key-clm-data. 
************************************************************************* 
 
    perform cb0-read-claims-approx 	thru	cb0-99-exit. 
    if eof-claims-mstr = "Y" 
    then 
	move 6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-finalization 
    else 
	next sentence. 
*   endif 
 
    move clmhdr-clinic-nbr-1-2		to	save-clinic-id. 
 
    perform xe0-obtain-clinic-ped	thru	xe0-99-exit. 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
 
    if clmhdr-clinic-nbr-1-2 not = save-clinic-id 
    then  
	perform zb0-print-totals-summary	thru	zb0-99-exit 
	move zero				to	tbl-totals 
	perform la0-print-clinic-totals		thru	la0-99-exit 
	perform xc0-zero-clinic-ctrs		thru	xc0-99-exit 
        move clmhdr-clinic-nbr-1-2		to	save-clinic-id 
	perform xe0-obtain-clinic-ped		thru	xe0-99-exit. 
*   (else) 
*   endif 
 
*	(note - 'PAYMENTS' field is stored as negative amt so  
*	        amt owing = original bal - payments 
*		can be calculated by *adding* payment field 
 
*	(if    agent = 'OHIP' 
*	   or agent not = 'OHIP' but claim was one that was retained from old system) 
*	then   use 'OHIP' amt as value of claims rather than 'OMA' amt) 
*   (pdr #414 - treat agent 4 as direct bill) 
    move clmhdr-agent-cd			to ws-agent-flag. 
*  2012/09/18 - MC3 - if agent not = 6, use ohip amt ;otherwise, use oma amt to calculate balance due
*   if   ohip-agent

** MC4
**   if   clmhdr-agent-cd not = 6
* 2012/09/18 -end
**    then
        add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-ohip
**                                           giving balance-due
**    else
**        add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-oma
                                            giving balance-due.
*   endif
** MC4 -end
 
 
 
*	  note: 'A'djustment and 'P'ayment entries as well as any 
*                claim with it'S CURRENT CLINIC's ped are not deleted. 
* 
*  delete(ie. bypass) a claim if no balance owing or balance 
*  owing within write-off range. 
* 
*  delete(ie bypass) an alternative funding claim (agent 8)  if claim'S 
*  p.e.d. is between the cut off dates 
* 
*  delete(ie bypass) a clinic 81 claim if the claim has no cash date 
*  and is older than 1 year 
* 
*  delete(ie bypass) a clinic 81 claim if the claim has a cash date and 
*  the claim has a message code of ev, ea, ef, 48 or blank 
* 
 
   move clmhdr-date-sys			to w-clmhdr-date-sys. 
*mf
   move sys-date-long-r			to ws-sys-date-long.
   subtract w-clmhdr-date-sys-n from ws-sys-date-long giving temp-date.
    

* 2008/04/17 - MC
    if   (    site-id = "RMA"
          and clmhdr-batch-type          = "C"
* 2011/09/13 - MC1 - Yasemin wants to change from < to <= (ie inclusive of the cutoff date)
*        and clmhdr-date-period-end     < cutoff-date
         and clmhdr-date-period-end     <=  cutoff-date
* 2011/09/13 - end
          and (     (     (balance-due > -1.00 and balance-due <  1.00)
*                         2004/05/19 - MC - check value 'O' - represents old AFP
*                     and (iconst-clinic-card-colour = 'N')
                      and (iconst-clinic-card-colour <> 'O')
                    )
                or  (    iconst-clinic-card-colour = 'O'
                    )
               )
          )
        or
          (     site-id = "HSC"
           and clmhdr-batch-type          = "C"
           and clmhdr-date-period-end not greater than cutoff-date
           and (   clmhdr-agent-cd = 1
*                   2001/04/17 - MC - shelley requested to purge if zero balance only
*                or (balance-due > -.65 and balance-due <  .65))
                 or (balance-due = 0)
               )
          )
* 2008/04/17 - end
    then 
*	(delete) 
	perform ab1-ctr-del		thru	ab1-99-exit 
	move zero			to	del-ret-offset 
	perform sa0-add-batch-totals	thru	sa0-99-exit 
	perform cb3-add-to-claim-nbr	thru	cb3-99-exit 
	perform cb0-read-claims-approx	thru	cb0-99-exit 
    else 
*	(retain) 
	perform ab2-ctr-con		thru	ab2-99-exit 
	move 4				to	del-ret-offset 
	perform sa0-add-batch-totals	thru	sa0-99-exit 
	perform da6-save-clmhdr-info	thru	da6-99-exit 
******   perform fa0-write-new-clmhdr	thru	fa0-99-exit 
	move "N"			to	eof-claims-dtl 
	perform ha0-read-dtl-recs	thru    ha0-99-exit 
		    until eof-claims-dtl = "Y". 
*   endif 
 
 
    if eof-claims-mstr not = "Y" 
    then 
	go to ab0-processing.      
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
ab1-ctr-del. 
 
    add balance-due			to	ctr-amt-claims-mstr-write-offs.      
    add 1				to	ctr-claims-mstr-write-offs.           
 
*	(if claims ped is < present ped then consider as 'PREV' 
*	 months' VALUES -- ELSE CONSIDER AS 'curr' CURRENT MONTH's values) 
    if clmhdr-date-period-end < save-clinic-ped 
    then 
	add 1				to	ctr-clinic-delprev-nbr   
	add balance-due			to	ctr-clinic-delprev-amt   
    else 
	add 1				to	ctr-clinic-delcurr-nbr  
	add balance-due			to	ctr-clinic-delcurr-amt. 
*   endif 
 
ab1-99-exit. 
    exit. 
 
 
 
ab2-ctr-con. 
 
    add 1				to	ctr-claims-mstr-in-acctrec.             
    add balance-due			to	ctr-amt-claims-mstr-in-acctrec.             
 
*	(if claims ped is < present ped then consider as 'PREV' 
*	 months' VALUES -- ELSE CONSIDER AS 'curr' CURRENT MONTH's values)         
    if clmhdr-date-period-end < save-clinic-ped 
    then 
	add 1				to	ctr-clinic-conprev-nbr   
	add balance-due			to	ctr-clinic-conprev-amt  
    else 
	add 1				to	ctr-clinic-concurr-nbr  
	add balance-due			to	ctr-clinic-concurr-amt. 
*   endif 
 
ab2-99-exit. 
    exit. 
az0-finalization. 
 
*	(print last clinic'S TOTALS) 
    perform zb0-print-totals-summary		thru	zb0-99-exit. 
    perform la0-print-clinic-totals		thru	la0-99-exit. 
 
    accept sys-date				from	date. 
    accept sys-time				from	time.      
    move sys-hrs				to	sys-hrs-pr. 
    move sys-min				to	sys-min-pr. 
 
    perform az1-determine-elapsed-time		thru	az1-99-exit. 
 
    perform az2-print-audit-report-tots		thru	az2-99-exit. 
 
    display scr-closing-screen. 
    display confirm. 
 
    close iconst-mstr 
	  claims-mstr 
	  print-file. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
az1-determine-elapsed-time. 
 
    if sys-min < begin-min 
    then 
	add 60					to	sys-min      
	subtract 1				from	sys-hrs    
    else 
	next sentence. 
*   endif 
 
    move sys-min				to	elapsed-min.  
    move sys-hrs				to	elapsed-hrs. 
    subtract begin-min				from	elapsed-min. 
    subtract begin-hrs				from	elapsed-hrs. 
 
az1-99-exit. 
    exit. 
az2-print-audit-report-tots. 
 
    move 98					to	ctr-line. 
    move "G R A N D   T O T A L S"		to	l1-msg. 
    move 3					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
*2002/07/05 - MC
*    move "CLAIMS BETWEEN -.85 +.85 - NUMBER"	to	l2-msg. 
    move "CLAIMS BETWEEN -.99 +.99 - NUMBER"	to	l2-msg. 
*2002/07/05 - end
    move ctr-claims-mstr-write-offs		to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
*2002/07/05 - MC
*   move "CLAIMS BETWEEN -.85 +.85 - AMOUNT"	to	l3-msg. 
    move "CLAIMS BETWEEN -.99 +.99 - AMOUNT"	to	l3-msg. 
*2002/07/05 - end
    move ctr-amt-claims-mstr-write-offs		to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            - NUMBER"	to	l2-msg. 
    move ctr-claims-mstr-in-acctrec		to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            - AMOUNT"	to	l3-msg. 
    move ctr-amt-claims-mstr-in-acctrec		to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "(TOTAL CLAIMS RECORDS READ - NUMBER)"	to	l2-msg. 
    move ctr-claims-mstr-reads			to	l2-ctr. 
    move 2					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "(HEADERS READ              - NUMBER)"	to	l2-msg. 
    move ctr-nbr-hdr-rec-reads			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
 
 
 
 
 
    move "(DETAILS READ              - NUMBER)"	to	l2-msg. 
    move ctr-nbr-dtl-rec-reads			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
 
 
 
 
 
    move "PROGRAM STATISTICS"			to	l1-msg. 
    move 98					to	ctr-line. 
    move 4					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "PROGRAM R073 BEGAN"			to	l1-msg. 
    move run-yy					to	l1-yy. 
    move "/"					to	l1-slash-1. 
    move run-mm					to	l1-mm. 
    move "/"					to	l1-slash-2. 
    move run-dd					to	l1-dd. 
    move begin-hrs				to	l1-hrs. 
    move begin-min				to	l1-min. 
    move ":"					to	l1-colon. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "PROGRAM R073 ENDED"			to	l1-msg. 
    move sys-yy					to	l1-yy. 
    move "/"					to	l1-slash-1. 
    move sys-mm					to	l1-mm. 
    move "/"					to	l1-slash-2. 
    move sys-dd					to	l1-dd. 
    move sys-hrs-pr				to	l1-hrs. 
    move sys-min-pr				to	l1-min. 
    move ":"					to	l1-colon. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
    move "ELAPSED TIME"				to	l1-msg. 
    move elapsed-hrs				to	l1-hrs. 
    move elapsed-min				to	l1-min. 
    move ":"					to	l1-colon. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line		thru	xa0-99-exit. 
 
az2-99-exit. 
    exit. 
cb0-read-claims-approx. 
 
    move zero					to	claims-occur 
							feedback-claims-mstr. 
 
*mf    read claims-mstr  key is key-claims-mstr approximate 
*mf      invalid key 
*mf          move 3 			to	err-ind 
*mf          perform za0-common-error	thru	za0-99-exit 
*mf          go to az0-finalization. 
 
    start claims-mstr  key is greater than or equal to key-claims-mstr
      invalid key 
          move 3 			to	err-ind 
          perform za0-common-error	thru	za0-99-exit 
          go to az0-finalization. 
    read claims-mstr next.
 
    if status-cobol-claims-mstr = 23 or  
       status-cobol-claims-mstr = 99 
    then  
        move 4				to 	err-ind 
        perform za0-common-error	thru za0-99-exit 
        go to az0-finalization 
    else 
        if status-cobol-claims-mstr = 10 
        then  
            move "Y"			to	eof-claims-mstr 
            go to cb0-99-exit  
        else 
            move "N" 			to 	eof-claims-mstr. 
*       endif 
*   endif 
 
*mf    retrieve claims-mstr key fix position 
*mf    into key-claims-mstr. 
 
* 2011/11/30 - MC2
*    display test-key-display. 
* 2011/11/30 - end
 
cb0-10-check-for-clmhdr. 
 
*mf    if key-clm-key-type not = 'B' 
    if clmdtl-b-key-type not = 'B' 
    then 
	move "Y"			to	eof-claims-mstr 
	go to cb0-99-exit 
    else 
	next sentence. 
*   endif   
 
    add 1				to	ctr-claims-mstr-reads 
						ctr-nbr-hdr-rec-reads. 
 
 
cb0-99-exit. 
    exit. 
cb3-add-to-claim-nbr. 
 
    if  clmdtl-b-claim-nbr = 99 
    then  
	move zeros 			to clmdtl-b-claim-nbr 
*!	add 1 				to clmdtl-b-batch-num 
*!	add 1 				to clmdtl-b-day 
	perform xx0-increment-batch-nbr thru    xx0-99-exit
    else 
* 2003/12/10 - MC - I believe that the following condition is obseleted
*        if    clmdtl-b-batch-num = 220441756
*          and clmdtl-b-claim-nbr = 03
*        then
*            move 220441757              to clmdtl-b-batch-num
*            move 01                     to clmdtl-b-claim-nbr
*        else
* 2003/12/10 - end
            add 1                       to clmdtl-b-claim-nbr
            move spaces                 to clmdtl-b-adj-nbr.
*       endif
*   endif 
 
cb3-99-exit. 
    exit. 


da6-save-clmhdr-info. 
 
    if clmhdr-batch-type = "C" 
    then 
	move clmhdr-batch-nbr		to 	hold-batch-nbr 
	move clmhdr-claim-nbr		to 	hold-claim-nbr         
    else 
	move clmhdr-orig-batch-nbr	to 	hold-batch-nbr 
	move clmhdr-orig-claim-nbr	to 	hold-claim-nbr.        
*   endif 
 
da6-99-exit. 
    exit. 
ha0-read-dtl-recs. 
 
*	(read the detail records for the claim being processed and write 
*	 to the new claims mstr) 
 
    perform ja0-read-claims-next	thru	ja0-99-exit. 
 
*	(if not end of claim, then write to new file) 
    if eof-claims-dtl = "N" 
    then 
	go to ha0-99-exit 
    else 
	next sentence. 
*   endif 
 
ha0-99-exit. 
    exit. 
 
 
 
ja0-read-claims-next. 
 
    move zero				to	claims-occur 
						feedback-claims-mstr. 
 
    read claims-mstr	next 
	    at end 
		move "Y"		to	eof-claims-mstr 
						eof-claims-dtl 
		go to ja0-99-exit. 
 
*mf    retrieve  claims-mstr	key  fix position 
*mf		into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move "Y"			to	eof-claims-mstr 
						eof-claims-dtl 
	go to ja0-99-exit 
    else 
	next sentence. 
*   endif 
 
*	(determine if claim rec read belongs to claim being processed) 
*mf    if    key-clm-batch-num = hold-batch-nbr 
*mf      and key-clm-claim-nbr = hold-claim-nbr 
    if    clmdtl-b-batch-num = hold-batch-nbr 
      and clmdtl-b-claim-nbr = hold-claim-nbr 
    then 
	move "N"			to	eof-claims-dtl 
	add 1 				to 	ctr-nbr-dtl-rec-reads 
    else 
	move "Y"			to	eof-claims-dtl 
	add 1 				to 	ctr-nbr-hdr-rec-reads. 
*   endif 
 
    add 1				to	ctr-claims-mstr-reads. 
 
ja0-99-exit. 
    exit. 
la0-print-clinic-totals. 
 
    move "CLINIC NUMBER"			to	l1-msg.    
    move save-clinic-id				to	l1-yy. 
    move 3					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
*2002/07/05 - MC
*    move "CLAIMS BETWEEN -.85 +.85 CURRENT  PED - NUMBER"	to	l2-msg. 
    move "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - NUMBER"	to	l2-msg. 
*2002/07/05 - end
    move ctr-clinic-delcurr-nbr			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
*2002/07/05 - MC
*    move "CLAIMS BETWEEN -.85 +.85 PREVIOUS PED - NUMBER"	to 	l2-msg. 
    move "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - NUMBER"	to 	l2-msg. 
*2002/07/05 - end
    move ctr-clinic-delprev-nbr			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
*2002/07/05 - MC 
*   move "CLAIMS BETWEEN -.85 +.85 CURRENT  PED - AMOUNT"	to	l3-msg. 
    move "CLAIMS BETWEEN -.99 +.99 CURRENT  PED - AMOUNT"	to	l3-msg. 
*2002/07/05 - end
    move ctr-clinic-delcurr-amt			to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
*2002/07/05 - MC 
*   move "CLAIMS BETWEEN -.85 +.85 PREVIOUS PED - AMOUNT"	to	l3-msg. 
    move "CLAIMS BETWEEN -.99 +.99 PREVIOUS PED - AMOUNT"	to	l3-msg. 
*2002/07/05 - end
    move ctr-clinic-delprev-amt			to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            CURRENT  PED - NUMBER"	to	l2-msg. 
    move ctr-clinic-concurr-nbr			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            PREVIOUS PED - NUMBER"	to	l2-msg. 
    move ctr-clinic-conprev-nbr			to	l2-ctr. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            CURRENT  PED - AMOUNT"	to	l3-msg. 
    move ctr-clinic-concurr-amt			to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
    move "CLAIMS IN A/R            PREVIOUS PED - AMOUNT"	to	l3-msg. 
    move ctr-clinic-conprev-amt			to	l3-amt. 
    move 1					to	line-advance. 
    perform xa0-write-audit-rpt-line			thru	xa0-99-exit. 
 
la0-99-exit. 
    exit. 
sa0-add-batch-totals. 
 
    perform sa1-find-ss-type 		thru	sa1-99-exit. 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, clmhdr-agent-cd		giving	ss-agent. 
 
    add del-ret-offset, ss-a-r-oma	giving ss-temp1.
    add clmhdr-tot-claim-ar-oma		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).    
    add del-ret-offset, ss-a-r-ohip	giving ss-temp1.
    add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
    add del-ret-offset, ss-cash		giving ss-temp1.
    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
    add del-ret-offset, ss-nbr		giving ss-temp1.
    add 1                  		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).         

*mf    add clmhdr-tot-claim-ar-oma		to	tbl-tot (ss-type, ss-agent, del-ret-offset + ss-a-r-oma ).    
*mf    add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, del-ret-offset + ss-a-r-ohip ).   
*mf    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, del-ret-offset + ss-cash  ). 
*mf    add 1                  		to	tbl-tot (ss-type, ss-agent, del-ret-offset + ss-nbr ).         
 
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
tb0-write-line. 
 
    add  nbr-lines-2-advance				to	ctr-line.     
    if ctr-line > max-nbr-lines-per-page 
    then 
 	perform tc0-print-headings			thru	tc0-99-exit. 
*   (else) 
*   endif 
 
    write   print-record  from print-line-1    after advancing  nbr-lines-2-advance lines. 
 
    move spaces						to	print-line-1.                   
    move 1						to	nbr-lines-2-advance. 
 
tb0-99-exit. 
    exit. 
 
tc0-print-headings. 
 
    add 1					to	page-nbr.      
    move save-clinic-ped			to	h1-ped. 
    move page-nbr				to	h1-page-nbr. 
    write print-record from header-1 after advancing page. 
    move save-clinic-id				to	h5-clinic-nbr. 
    write print-record from h5-head after advancing 2 lines. 
    write print-record from h6-head after advancing 1 line. 
    write print-record from blank-line after advancing 1 line. 
    move 6 					to	ctr-line. 
 
 
tc0-99-exit. 
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
 
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 1 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 2 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 3 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 4 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 5 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 6 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 7 ).            
    move zero   				   to  tbl-tot (ss-type-from, ss-agent-from, 8 ).            
 
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
 
tg0-99-exit. 
    exit. 
xa0-write-audit-rpt-line. 
 
*	(variables that must be set before calling curr routine are: 
*	 'LINE-ADVANCE', 'CTR-LINE' if new page is to be forced, and 
*	 detail line must be built up in 'PRINT-LINE-1' or any line 
*	 that redefines it) 
 
    add line-advance				to	ctr-line. 
 
    if ctr-line > max-nbr-lines-per-page 
    then 
	perform xb0-print-headings		thru	xb0-99-exit 
	add line-advance			to	ctr-line. 
*   (else) 
*   endif 
 
    write print-record		from	print-line-1 
	    after advancing  line-advance  lines. 
 
    move spaces					to	print-line-1. 
 
xa0-99-exit. 
    exit. 
 
 
 
xb0-print-headings. 
 
    add 1					to	page-nbr. 
*mf    move spaces          			to	h1-ped. 
    move zero					to	h1-ped. 
    move page-nbr				to	h1-page-nbr. 
 
    write  print-record		from	header-1 
	    after advancing page. 
 
    move 1					to	ctr-line. 
 
xb0-99-exit. 
    exit. 
xc0-zero-clinic-ctrs. 
 
    move zero				to	ctr-clinic-delcurr-nbr 
						ctr-clinic-delprev-nbr 
						ctr-clinic-delcurr-amt 
						ctr-clinic-delprev-amt 
						ctr-clinic-concurr-nbr 
						ctr-clinic-conprev-nbr 
						ctr-clinic-concurr-amt 
						ctr-clinic-conprev-amt. 
 
xc0-99-exit. 
    exit. 
xe0-obtain-clinic-ped. 
 
    move save-clinic-id			to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move iconst-clinic-nbr-1-2	to err-msg-clinic-id 
	    move 5			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-finalization. 
 
    move iconst-date-period-end		to save-clinic-ped. 
 
xe0-99-exit. 
    exit. 

xx0-increment-batch-nbr.
*0 - 9 A - Z
    move "N"                            to      flag-request-complete.

    if clmdtl-b-batch-number = 999
    then
        move clmdtl-b-doc-nbr           to      tmp-doc-nbr-alpha
* 2011/11/30 - MC2
*        display "BEFORE: " clmdtl-b-doc-nbr
* 2011/11/30 - end
        perform xx1-process-1-doc-position  thru xx1-99-exit
            varying   ss from 3 by -1
            until     ss = 0
               or      flag-request-complete-y
        move tmp-doc-nbr-alpha          to      clmdtl-b-doc-nbr
* 2011/11/30 - MC2
*       display "AFTER : " clmdtl-b-doc-nbr
*       display " "
* 2011/11/30 - end
        move 000                        to      clmdtl-b-batch-number
    else
        add 1                           to      clmdtl-b-batch-number-numeric.
*   endif


xx0-99-exit.
   exit.

xx1-process-1-doc-position.
*if pos(1) = 0 then 1 , if 1 then 2 if 9 then A, if A then B if Z then 0 and!

    if tmp-batch-nbr-index(ss) = "0"
    then
        move "1"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "1"
    then
        move "2"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "2"
    then
        move "3"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "3"
    then
        move "4"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "4"
    then
        move "5"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "5"
    then
        move "6"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "6"
    then
        move "7"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "7"
    then
        move "8"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "8"
    then
        move "9"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "9"
    then
        move "A"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "A"
    then
        move "B"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "B"
    then
        move "C"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "C"
    then
        move "D"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "D"
    then
        move "E"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "E"
    then
        move "F"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "F"
    then
        move "G"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "G"
    then
        move "H"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "H"
    then
        move "I"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "I"
    then
        move "J"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "J"
    then
        move "K"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "K"
    then
        move "L"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "L"
    then
        move "M"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "M"
    then
        move "N"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "N"
    then
        move "O"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "O"
    then
        move "P"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "P"
    then
        move "Q"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "B"
    then
        move "R"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "R"
    then
        move "S"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "S"
    then
        move "T"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "T"
    then
        move "U"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "U"
    then
        move "V"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "V"
    then
        move "W"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "W"
    then
        move "X"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "X"
    then
        move "Y"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "Y"
    then
        move "Z"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "Z"
    then
        move "0"                        to      tmp-batch-nbr-index(ss)
        go to xx0-99-exit.
*   endif

xx1-90-return.
    move "Y"                            to      flag-request-complete.

xx1-99-exit.
    exit.



za0-common-error. 
 
    move err-msg (err-ind)		to	e1-error-msg. 
    display e1-error-line. 
 
    perform za1-print-err-in-rpt	thru	za1-99-exit. 
 
    display confirm. 
****    stop " ". 
 
****    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
 
za1-print-err-in-rpt. 
 
    move e1-error-line			to	print-line-1. 
 
    move 4				to	line-advance. 
    perform xa0-write-audit-rpt-line	thru	xa0-99-exit. 
 
za1-99-exit. 
    exit. 
zb0-print-totals-summary. 
 
*	(start totals on new page) 
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
	    move 2				to	nbr-lines-2-advance 
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
 
zc0-99-exit. 
    exit. 
zd0-prt-agent-vals-and-sum. 
*    (this routine called varying 'SS-AGENT') 
 
*    (print line only if non-zero values for 'AGENT') 
*    ( 'NBR + OFFSET' gives retained types. 'OFFSET' = 4) 

    add ss-nbr, ss-offset		giving ss-temp1.
    if     tbl-tot (ss-type, ss-agent, ss-nbr) 		    = zero 
*mf       and tbl-tot (ss-type, ss-agent, ss-nbr + ss-offset ) = zero 
       and tbl-tot (ss-type, ss-agent, ss-temp1 ) = zero 
    then 
	go to zd0-99-exit. 
*   (else) 
*   endif 
 
    move spaces				to	t2-desc. 
 
*    (if printing 1st detail line for this batch type then include 
*     batch type description) 
    if sw-printed-bat-type = "N" 
    then 
	move "Y"			to	sw-printed-bat-type 
	move desc-bat-type (ss-type)	to	t2-desc-a 
	move 3				to	nbr-lines-2-advance. 
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
  
zd0-99-exit. 
    exit. 

*2000/05/12 - B.A. begin
   copy "y2k_default_sysdate_century.rtn".
