identification division. 
program-id. r004cycle. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/12/01. 
date-compiled. 
security. 
* 
*    files      : f001   - batch control file 
*		: f002   - claim master 
*		: f090   - constants master 
*		: r004_cy - print file 
* 
*    program purpose : print the "CYCLE" version of the 'MONTHLY CLAIMS AND ADJUSTMENT 
*		       transaction summary' FOR CYCLE BALANCING PURPOSES. 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
* 
*   revised july/92  : - sms 139 (m.c.) 
*		       - use batctrl-bat-clinic-nbr-1-2 instead of 
*			 batctrl-clinic-nbr-1-2 for message 7 on page 16 
* 
*   revised oct/95   : - sra 151 yas 
*		       - add oma column back in 
*			 
*   rev 17/01/96 yas : - change "batctrl-batch-status" from 1 to 1 or 2 
*		         because, implemantation of u010daily program 
*			 
*   rev 17/01/96 yas : - modify h3-head. column name under claims master 
*		         names are shifted over one column 
*			 
*   rev 30/01/98 jc  : - s149 unix conversion
*   rev 05/03/98 cm  - y2k conversion
*   rev 1999/05/07 S.B.	- Re-checked the Y2K conversion. Fixed screen area.
*   2003/dec/09	   M.C. - alpha doc nbr
*   2004/jan/05    b.e.	- remove confirmation to run job
*   2005/may/18    M.C. - add 1 to clmdtl-orig-batch-number instead of 
*			  clmdtl-orig-complete-batch-nbr and comment out
*			  redundant ring-bell
*   2006/feb/15    M.C. - add 1 to clmdtl-nbr-claims-in-batch instead of 
*			  clmdtl-orig-batch-number	
*   2006/may/03    b.e. - corrected bug where 1 was added to 99 (claim nbr)
*			  when trying to skip over ZZZZ description records
*			  to read the next claim batch - used the same
*			  logic/code as was put into r004a.cbl
*   2012/Dec/10    MC1  - move 1 to clmdtl-nbr-claims-in-batch when reach to claim 99
*   2017/Jan/30    MC2  - change amount field size for final total
*

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
data division. 
file section. 
* 
    copy "f001_batch_control_file.fd". 
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
 
77  err-ind					pic 99		value zero. 
77  print-file-name				pic x(10) 
	value "r004_c". 
77  option					pic x. 
77  max-nbr-lines				pic 99		value 60. 
77  ctr-lines					pic 999		value 90. 
77  nbr-lines-2-advance				pic 99.  
77  page-ctr					pic 9(4). 
77  ws-i-o-pat-ind				pic x. 
77  ws-reply					pic x. 
77  batch-total					pic s9(6)v99	value zero. 
77  batch-diff					pic s9(6)v99	value zero. 
77  ws-fee-ohip					pic 9(5)v99. 
77  ws-nbr-serv					pic 99. 
77  nbr-rec-processed				pic 9(4). 
77  ws-rev-calcd				pic s9(6)v99	value zero. 
77  rev-calcd-total				pic s9(6)v99	value zero. 
77  update-amt-total				pic s9(6)v99	value zero. 
77  diff-total					pic s9(6)v99	value zero. 
*!77  hold-clmhdr-batch-nbr			pic 9(9). 
77  hold-clmhdr-batch-nbr			pic x(8). 
77  hold-clmhdr-claim-nbr			pic 99. 
*!77  ws-doctor-nbr				pic 999. 
77  ws-doctor-nbr				pic xxx. 
77  const-mstr-rec-nbr				pic x. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  blank-line					pic x(132) value spaces. 
* (y2k)
* 77  ws-period-end                               pic 9(6).
77  ws-period-end				pic 9(8). 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
77  eof-claims-dtl				pic x   value "N". 
77  eof-claims-mstr				pic x   value "N". 
77  eof-work-file				pic x	value "N". 
77  new-header					pic x   value "N". 
77  sub1					pic 9	value zero. 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-batctrl-file			pic x(11) value zero. 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 

77  common-status-file				pic x(2). 
77  status-cobol-batctrl-file			pic x(2)  value zero. 
77  status-cobol-claims-mstr			pic x(2)  value zero. 
77  status-cobol-iconst-mstr			pic x(2)  value zero. 
77  status-prt-file				pic xx    value zero. 
77  status-sort-file				pic xx. 
77  hold-clinic-nbr				pic 99. 
77  claims-occur				pic 9(5). 
 
01 tmp-doc-nbr-alpha.
    05 tmp-batch-nbr-index                      pic x(1) occurs 8 times. 

01  flag-request-complete                       pic x.
    88  flag-request-complete-y                 value "Y".
    88  flag-request-complete-n                 value "N".

01  flag-rec					pic x. 
    88  valid-rec				value "Y". 
    88  invalid-rec				value "N". 
 
01  tbl-totals. 
    05  tbl-bat-type-and-tots	occurs   8  times. 
	10  tbl-agent-and-sums	occurs  11  times. 
	    15  tbl-item	occurs   8  times. 
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
*	       (values 1 thru 4 used for batch control file totals) 
*	       (values 5 thru 8 (obtained by adding variable offset) are 
*	        used for claim header totals.) 
 
	    05  ss-a-r-oma		pic 9	value  1. 
	    05  ss-a-r-ohip		pic 9	value  2. 
	    05  ss-cash			pic 9	value  3. 
	    05  ss-nbr			pic 9	value  4. 
	    05  ss-offset		pic 9	value  4. 
	    05  ss-batctrl-offset	pic 9	value  0. 
	    05  ss-clmhdr-offset	pic 9	value  4. 
*		( variable offset ) 
	    05  batctrl-clm-offset  	pic 9. 
 
01  tbl-fin-tot-desc. 
    05  fin-tot-descs. 
	10  filler			pic x(18)	value 
		"CLINIC 'A' ADJUST.".   
	10  filler			pic x(18)	value 
		"CLINIC 'C' PAYMENT".  
    05  fin-tot-desc-r redefines fin-tot-descs. 
	10  fin-total-desc   occurs  2  times. 
	    15  fin-tot-desc		pic x(18). 
 
01  ss-fin-tots. 
*     (subscripts for  'TBL-FIN-TOTS') 
    05  ss-a				pic 9	value  1. 
    05  ss-c				pic 9	value  2. 
*	(variable subscript) 
    05  ss				pic 9. 
 
01  tbl-fin-tots. 
    05  fin-tots		occurs   2  times. 
	10  fin-tot-a-r			pic s9(9)v99. 
	10  fin-tot-rev			pic s9(9)v99. 
	10  fin-tot-cash		pic s9(9)v99. 
	10  fin-tot-nbr			pic 9(9). 
 
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
 
77  sw-printed-bat-type			pic x. 
77  sw-printed-adj-type			pic x. 
 
01  final-totals. 
    05  fin-tot-1			pic s9(9)v99. 
    05  fin-tot-2			pic s9(9)v99. 
    05  fin-tot-3			pic s9(9)v99. 
    05  fin-tot-4			pic s9(9)v99. 
    05  fin-tot-5			pic s9(9)v99. 
    05  fin-tot-6			pic s9(9)v99. 
    05  fin-tot-7			pic s9(9)v99. 
    05  fin-tot-8			pic s9(9)v99. 
    05  fin-tot-a-a-r 			pic s9(9)v99. 
    05  fin-tot-a-rev 			pic s9(9)v99. 
    05  fin-tot-a-cash			pic s9(9)v99. 
    05  fin-tot-a-nbr 			pic s9(9)v99. 
    05  fin-tot-c-a-r 			pic s9(9)v99. 
    05  fin-tot-c-rev 			pic s9(9)v99. 
    05  fin-tot-c-cash			pic s9(9)v99. 
    05  fin-tot-c-nbr 			pic s9(9)v99. 
*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-work-file-writes			pic 9(7). 
    05  ctr-work-file-reads			pic 9(7). 
    05  ctr-pages				pic 9999. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"INVALID READ ON CONSTANTS MASTER". 
	10  filler				pic x(60)   value 
		"****  CAN BE RE-USED  ****".  
	10  filler				pic x(60)   value 
		"NO BATCTRL FILE SUPPLIED".    
	10  filler				pic x(60)   value 
		"NO BATCH CONTROL RECORDS FOR CLINIC NUMBER". 
	10  filler				pic x(60)   value 
		"NO APPROPRIATE RECORDS IN BATCTRL FILE". 
	10  err-msg-7. 
	    15  filler				pic x(40)   value 
		"NO CLAIMS FOR THIS BATCH". 
	    15  err-msg-7-key			pic x(20). 
	10  err-msg-8. 
	    15  filler				pic x(40)   value 
		"CLAIMS READ APPROX ERROR". 
	    15  err-msg-8-key			pic x(20). 
	10  err-msg-9. 
	    15  filler				pic x(40)   value 
		"CLAIMS STATUS ERROR 23 OR 99". 
	    15  err-msg-9-key			pic x(20). 
	10  err-msg-10. 
	    15  filler				pic x(40)   value 
		"CLAIMS INVALID KEY TYPE". 
	    15  err-msg-10-key			pic x(20). 
 
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
 
    05  filler					pic x(7)	value 
		"R004_C/".     
    05  h1-clinic-nbr				pic 99. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(7)	value 
		"P.E.D.". 
* (y2k - auto fix)
*   05  h1-ped-yy				pic 99 		blank when zero. 
    05  h1-ped-yy				pic 9(4) 	blank when zero. 
    05  filler					pic x		value "/". 
    05  h1-ped-mm				pic 99		blank when zero. 
    05  filler					pic x		value "/". 
    
    05  h1-ped-dd				pic 99		blank when zero. 
* (y2k)
*   05  filler					pic x(9)	value spaces. 
    05  filler                                  pic x(7)        value spaces. 

    05  filler					pic x(58)	value 
		"* CYCLE CLAIMS AND ADJUSTMENT TRANSACTION SUMMARY *". 
    05  filler					pic x(9)	value 
		"RUN DATE". 
* (y2k)
*   05  h1-date					pic x(8). 
    05  h1-date                                 pic x(10).
* (y2k)
*   05  filler                                  pic x(8)        value spaces. 
    05  filler					pic x(6)	value spaces. 
    05  filler                                  pic x(5)        value 
		"PAGE". 
    05  h1-page					pic z,zz9. 
 
01  h2-head. 
 
    05  filler					pic x(8)	value 
		"CLINIC".   
    05  h2-clinic-nbr				pic 99		blank when zero. 
    05  filler					pic x(2)	value spaces. 
    05  filler					pic x(6)	value 
		"CYCLE".   
    05  h2-cycle-nbr				pic zzz. 
    05  filler					pic x(9)	value spaces. 
    05  filler					pic x(11)	value 
		"-----------". 
    05  filler					pic x(23)	value 
		" BATCH   CONTROL  FILE-".   
    05  filler					pic x(20)	value 
		"-------------". 
    05  filler					pic x(14)	value 
		"--------------". 
    05  filler					pic x(35)	value 
		"----CLAIMS  MASTER---------------". 
01  h3-head. 
 
    05  filler					pic x(17)	value spaces. 
    05  filler					pic x(12)	value 
		"AGENT". 
    05  filler					pic x(14)	value 
		"NET A/R". 
    05  filler					pic x(15)	value 
		" NET REV". 
    05  filler					pic x(15)	value 
		"CASH AMT". 
    05  filler					pic x(10)	value 
		"NBR". 
********************************************************************** 
*	code left, incase oma amt used at a later date		     * 
*   05  filler					pic x(14)  value     * 
*		"OMA AMT".					     * 
********************************************************************** 
    05  filler					pic x(14)      value 
 		"OMA AMT".					 
    05  filler					pic x(15)	value 
		"OHIP AMT". 
    05  filler					pic x(15)	value 
		"CASH AMT". 
    05  filler					pic x(5) 	value 
		"NBR". 
01  t1-print-line. 
    05  t1-desc. 
	10  t1-desc-a				pic x(13). 
	10  t1-desc-b				pic x(5). 
    05  t1-dash					pic x. 
    05  filler					pic x. 
    05  t1-agent-cd				pic 9. 
* MC2
*    05  filler					pic x(3).     
*    05  t1-detail-1				pic z,zzz,zz9.99-. 
*    05  filler					pic x(2). 
*    05  t1-detail-2				pic z,zzz,zz9.99-. 
    05  filler					pic x(2).     
    05  t1-detail-1				pic zz,zzz,zz9.99-. 
    05  filler					pic x(1). 
    05  t1-detail-2				pic zz,zzz,zz9.99-. 
* MC2 - end
    05  filler					pic x(2). 
    05  t1-detail-3				pic z,zzz,zz9.99-. 
    05  filler					pic x(2). 
    05  t1-detail-4				pic zzz,zz9. 
* MC2
*    05  filler					pic x(2). 
*    05  t1-detail-5				pic z,zzz,zz9.99-. 
*    05  filler					pic x(2). 
*    05  t1-detail-6				pic z,zzz,zz9.99-. 
    05  filler					pic x(1). 
    05  t1-detail-5				pic zz,zzz,zz9.99-. 
    05  filler					pic x(1). 
    05  t1-detail-6				pic zz,zzz,zz9.99-. 
* MC2 - end
    05  filler					pic x(2). 
    05  t1-detail-7				pic z,zzz,zz9.99-. 
    05  filler					pic x(2). 
    05  t1-detail-8				pic zzz,zz9. 
    05  filler					pic x(2). 
 
01 blank-line					pic x(132). 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05	line 01 col 01 value is "R004_CYCLE              CYCLE TRANSACTION SUMMARY". 
* (y2k - auto fix)
*   05	line 01 col 73 pic 99 using sys-yy. 
    05	line 01 col 70 pic 9(4) using sys-yy. 
    05	line 01 col 74 value is "/". 
    05	line 01 col 75 pic 99 using sys-mm. 
    05	line 01 col 77 value is "/". 
    05	line 01 col 78 pic 99 using sys-dd. 
 
01  scr-clinic-ped-cycle. 
    05  line 10 col 10 value "CLINIC ID      :". 
    05  line 10 col 27 pic xx using iconst-clinic-nbr-1-2. 
    05  line 12 col 10 value "CLINIC NAME    :". 
    05  line 12 col 27 pic x(20) using iconst-clinic-name. 
    05  line 14 col 10 value "PERIOD END DATE:". 
* (y2k - auto fix)
*   05  line 14 col 30 pic xx using iconst-date-period-end-yy. 
    05  line 14 col 30 pic xxxx using iconst-date-period-end-yy. 
    05  line 14 col 34 value is "/". 
    05  line 14 col 35 pic xx using iconst-date-period-end-mm. 
    05  line 14 col 37 value is "/". 
    05  line 14 col 38 pic xx using iconst-date-period-end-dd. 
    05  line 16 col 29 value is "CYCLE =" blink. 
    05  line 16 col 37 pic z9 using iconst-clinic-cycle-nbr blink. 
 
 
01  msg-continue. 
    05			line 20 col 10 value is "CONTINUE?  (ENTER Y OR N )". 
    05  scr-reply	line 20 col 40 pic x using ws-reply auto required. 
*                     
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) using common-status-file    bell blink. 
    05  line 24 col 70 pic x(2) using common-status-file    bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  ring-bell. 
    05  line 24 col 1	value " " bell. 
    05  line 24 col 1	value " " bell. 
    05  line 24 col 1	value " " bell. 
    05  line 24 col 1	value " " bell. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  program-in-progress. 
    05  line 24 col 22 value is "PROGRAM R004_CYCLE IN PROGRESS". 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  7 col 20  value "NUMBER OF BATCTRL-FILE ACCESSES = ". 
    05  line  7 col 60  pic 9(7) from ctr-batctrl-file-reads. 
    05  line  9 col 20  value "NUMBER OF CLAIM MSTR ACCESSES = ". 
    05  line  9 col 60  pic 9(7) from ctr-claims-mstr-reads. 
    05  line 21 col 20	value "PROGRAM R004_CYCLE ENDING". 
* (y2k - auto fix)
*   05  line 21 col 46  pic 99	from sys-yy. 
    05  line 21 col 46  pic 9(4)	from sys-yy. 
    05  line 21 col 50	value "/". 
    05  line 21 col 51 	pic 99	from sys-mm. 
    05  line 21 col 53	value "/". 
    05  line 21 col 54	pic 99	from sys-dd. 
    05  line 21 col 58	pic 99	from sys-hrs. 
    05  line 21 col 60	value ":". 
    05  line 21 col 61	pic 99	from sys-min.        
    05  line 23 col 20	value "REPORT IS IN FILE: ". 
    05  line 23 col 40 pic x(20) using print-file-name. 
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
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing      	thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    move zeros				to counters.
    accept sys-date			from 	date. 
    perform y2k-default-sysdate         thru y2k-default-sysdate-exit.    
    move sys-mm				to 	run-mm.                 
    move sys-dd				to 	run-dd. 
    move sys-yy				to 	run-yy. 
 
    accept sys-time			from 	time. 
    move sys-hrs			to 	run-hrs. 
    move sys-min			to 	run-min. 
    move sys-sec			to 	run-sec. 
 
 
 
    display scr-title. 
 
 
aa0-20-continue-y-n. 
 
*    display msg-continue. 
    move "Y"				to	ws-reply.
*    accept scr-reply. 
    if ws-reply =   "Y" 
		 or "N" 
    then 
	next sentence 
    else 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-20-continue-y-n. 
*   endif 
 
    if ws-reply = "N" 
    then  
         accept sys-time		from 	time    
         display scr-closing-screen  
         display confirm  
         stop run 
    else  
	display program-in-progress   
*	expunge		print-file 
	open output	print-file 
	open input	batch-ctrl-file 
			iconst-mstr 
			claims-mstr.    
*   endif 
 
    move zero				to	tbl-totals  
						tbl-fin-tots 
						final-totals 
						page-ctr. 
    move spaces				to	t1-print-line. 
    move run-date			to	h1-date. 
 
*mf    move zero			to 	key-gen-batctrl-file. 
*mf    read batch-ctrl-file key is key-gen-batctrl-file approximate 
*mf 	invalid key 
*mf	    move 4			to 	err-ind 
*mf	    perform za0-common-error	thru 	za0-99-exit 
*mf	    go to az0-end-of-job. 
    
*!    move zero				to 	key-batctrl-file.
    move spaces       		to 	key-batctrl-file.
    start batch-ctrl-file key is greater than or equal to key-batctrl-file
	invalid key 
	    move 4			to 	err-ind 
	    perform za0-common-error	thru 	za0-99-exit 
	    go to az0-end-of-job. 
    read batch-ctrl-file next.
 
    add 1				to 	ctr-batctrl-file-reads. 
 
*mf    perform xa0-read-display-save-clinic-info 
    perform xa0-read-disp-save-clinic-info 
					thru	xa0-99-exit. 
 
    perform aa1-sel-read-next-batctrl	thru 	aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = "Y" 
    then 
	perform za0-common-error	thru 	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    perform aa11-read-claim		thru 	aa11-99-exit. 
 
*	(a claim header has been read) 
    move "Y"				to	new-header. 
 
aa0-99-exit. 
    exit. 
aa1-sel-read-next-batctrl. 
 
    if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr 
    then 
	perform xa1-end-of-clinic	thru	xa1-99-exit   
*mf	perform xa0-read-display-save-clinic-info 
	perform xa0-read-disp-save-clinic-info 
					thru	xa0-99-exit. 
*   (else) 
*   endif 
 
 
*    (report only batches matching the clinic'S P.E.D. AND WITH CORRECT STATUS) 
*	for -- 
*    --       'C'laim batches 
*    --  and  'A'djustment batches type 'B' and 'R' ( ie 'A/B' and 'A/R') 
*    --  and  'P'ayment batches type 'M' (ie. 'P/M')) 
 
    if    (     batctrl-date-period-end = iconst-date-period-end )
      and (    batctrl-batch-status    = "1" 
                or batctrl-batch-status    = "2")  
      and (   (batctrl-batch-type     = "C") 
           or (    batctrl-batch-type     = "A" 
               and batctrl-adj-cd         = "B" or "R") 
           or (    batctrl-batch-type     = "P" 
               and batctrl-adj-cd         = "M")  )   
    then 
	move ss-batctrl-offset		to	batctrl-clm-offset 
	perform sa2-add-batch-totals	thru	sa2-99-exit 
	move "Y"			to	flag-rec 
	go to aa1-99-exit 
    else 
	move "N"			to	flag-rec 
*	(total non-processed 'A/A' and 'P/C' for this cycle) 
       if    (    batctrl-date-period-end = iconst-date-period-end 
               and (   batctrl-batch-status    = "1" 
                    or batctrl-batch-status    = "2") ) 
	then 
	    perform sa4-tot-non-processed-batches 
					thru sa4-99-exit 
	else 
	    next sentence. 
*	endif 
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
 
    if   batctrl-batch-nbr	 not = clmhdr-orig-batch-nbr 
*     or batctrl-clinic-nbr-1-2	 not = clmhdr-clinic-nbr-1-2 
      or batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2 
      or batctrl-date-period-end not = clmhdr-date-period-end 
    then 
* 	(no claims) 
	move  7				to	err-ind 
	move batctrl-batch-nbr		to	err-msg-7-key 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
aa11-99-exit. 
    exit. 
aa2-read-clmhdr. 
 
    move zeros				to 	clmhdr-claim-id. 
    move batctrl-batch-nbr		to	clmhdr-batch-nbr. 
    move 1				to	clmhdr-claim-nbr. 
 
*mf    move clmhdr-claim-id		to 	key-clm-data. 
*mf    move "B"				to 	key-clm-key-type. 
*mf    read claims-mstr key is key-claims-mstr approximate 
*mf 	invalid key 
*mf	    move  8			to	err-ind 
*mf	    move batctrl-batch-nbr	to	err-msg-8-key 
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    
    move spaces				to      key-claims-mstr.
    move spaces				to      clmdtl-b-oma-cd.
    move spaces				to      clmdtl-b-oma-suff.
    move clmhdr-claim-id		to 	clmdtl-b-data. 
    move "B"				to 	clmdtl-b-key-type. 
    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key 
	    move  8			to	err-ind 
	    move batctrl-batch-nbr	to	err-msg-8-key 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
    read claims-mstr next.
 
    if status-cobol-claims-mstr =  23 
				or 99 
    then 
	move 9				to	err-ind 
	move batctrl-batch-nbr		to	err-msg-9-key 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*mf    retrieve claims-mstr key fix position 
*mf	into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move 10				to	err-ind 
	move batctrl-batch-nbr		to	err-msg-10-key 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    add 1				to 	ctr-claims-mstr-reads. 
 
    move clmhdr-orig-batch-nbr		to 	hold-clmhdr-batch-nbr. 
    move clmhdr-orig-claim-nbr		to 	hold-clmhdr-claim-nbr. 
 
aa2-99-exit. 
    exit. 
ab0-processing. 
 
*    (determine if end of batch) 
    if   clmhdr-orig-batch-nbr  not = batctrl-batch-nbr 
      or clmhdr-date-period-end not = batctrl-date-period-end 
    then 
	perform ga0-read-next-batch	thru	ga0-99-exit. 
*   (else) 
*   endif 
 
    if eof-batctrl-file = "Y" 
    then 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
    move ss-clmhdr-offset		to	batctrl-clm-offset. 
    perform sa0-add-claim-totals	thru	sa0-99-exit. 
 
    move "N"				to	new-header 
						eof-claims-dtl. 
    perform ba0-process-dtl-recs	thru	ba0-99-exit 
		until eof-claims-dtl = "Y". 
 
    if    eof-claims-mstr     = "N" 
      and new-header      not = "Y" 
    then 
	perform ha0-read-clmhdr-next	thru	ha0-99-exit. 
*   (else) 
*   endif 
 
    if eof-claims-mstr = "N" 
    then 
	go to ab0-processing. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform xa1-end-of-clinic		thru	xa1-99-exit. 
 
    perform yb1-print-final-totals	thru	yb1-99-exit. 
 
    close batch-ctrl-file 
	  print-file 
	  iconst-mstr 
	  claims-mstr. 
 
    display blank-screen. 
    accept sys-time			from 	time. 
    display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ba0-process-dtl-recs. 
 
    read claims-mstr next 
	at end 
	    move "Y"			to eof-claims-dtl 
	    move "Y"			to eof-claims-mstr 
	    go to ba0-99-exit. 
 
*mf    retrieve claims-mstr key fix position 
*mf	into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move "Y"			to	eof-claims-dtl 
	move "Y"			to	eof-claims-mstr 
	go to ba0-99-exit. 
*   (else) 
*   endif 
 
*    (if 'C'laim is being processed then skip adjustment detail recs within claim) 
    if    batctrl-batch-type     = "C" 
      and clmdtl-adj-nbr     not = 0  
    then 
	go to ba0-process-dtl-recs. 
*   (else) 
*   endif 
 
    add 1				to	ctr-claims-mstr-reads. 
 
    if clmdtl-oma-cd = "ZZZZ" 
    then 
	move "Y"			to eof-claims-dtl 
	go to  ba0-99-exit. 
*   (else) 
*   endif 
 
    if clmhdr-zeroed-area is numeric 
    then 
	if clmhdr-zeroed-area = zero 
	then 
*	    (header has been read) 
	    move clmhdr-orig-batch-nbr	to	hold-clmhdr-batch-nbr 
	    move clmhdr-orig-claim-nbr	to	hold-clmhdr-claim-nbr 
	    move "Y"			to	new-header 
	    move "Y"			to	eof-claims-dtl 
	    go to ba0-99-exit 
	else 
	    next sentence 
*	endif 
    else 
	next sentence.   
*   endif 
 
    if   clmdtl-orig-batch-nbr          not = hold-clmhdr-batch-nbr 
      or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr 
    then 
	move "Y"			to new-header 
					   eof-claims-dtl. 
*   (else) 
*   endif 
 
ba0-99-exit. 
    exit. 
ga0-read-next-batch. 
 
    read batch-ctrl-file next 
	at end 
	    move "Y"			to eof-batctrl-file 
	    go to ga0-99-exit. 
 
    add 1				to ctr-batctrl-file-reads. 
 
    move "N"				to	flag-rec. 
    perform aa1-sel-read-next-batctrl	thru aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = "Y" 
    then 
	go to ga0-99-exit. 
*   (else) 
*   endif 
*	(if the current claim header that was read is not the correct 
*	 batch number then read the header with the new batch number) 
 
    if   clmhdr-orig-batch-nbr  not = batctrl-batch-nbr 
      or clmhdr-date-period-end not = batctrl-date-period-end    
    then 
	perform aa11-read-claim		thru	aa11-99-exit. 
*   (else) 
*   endif 
 
ga0-99-exit. 
    exit. 
ha0-read-clmhdr-next. 
 
*mf    move zero			to	key-clm-data. 
    move zero				to	clmdtl-b-data. 
 
* 2005/05/18 - MC - this is invalid since batch nbr is alpha instead of numeric
*    add 1				to	clmdtl-orig-complete-batch-nbr. 
* 2006/02/15- MC
*     add 1				to      clmdtl-orig-batch-number.	
* 2006/may/03 b.e. - handle 99 claims in alpha doc nbr batch  
*   add 1                           to      clmdtl-orig-claim-nbr-in-batch. 
    if clmdtl-orig-claim-nbr-in-batch = 99 
    then
	perform xx0-increment-batch-nbr thru    xx0-99-exit
* 2012/12/10 - MC1 - add move 1 to clmdtl-nbr-claims-in-batch
	move 1				to      clmdtl-orig-claim-nbr-in-batch 
* 2012/12/10 - end
    else
	add 1				to      clmdtl-orig-claim-nbr-in-batch. 
*   endif 

* 2006/02/15 - end
* 2005/05/18 - end

*mf    move clmdtl-orig-batch-nbr		to	key-clm-batch-nbr. 
*mf    move clmdtl-orig-claim-nbr-in-batch	to	key-clm-claim-nbr. 

*mf    read claims-mstr key is key-claims-mstr approximate 
*mf      at end 
*mf	move "Y"			to	eof-claims-mstr 
*mf	go to ha0-99-exit. 
    

    move clmdtl-orig-batch-nbr		to	clmdtl-b-batch-nbr. 
    move clmdtl-orig-claim-nbr-in-batch	to	clmdtl-b-claim-nbr. 
    start claims-mstr key is greater than or equal to key-claims-mstr.
    read claims-mstr next 
      at end 
	move "Y"			to	eof-claims-mstr 
	go to ha0-99-exit. 
 
*mf    retrieve claims-mstr key fix position 
*mf	into key-claims-mstr. 
 
*mf    if   key-clm-key-type      not = "B" 
    if   clmdtl-b-key-type      not = "B" 
    then 
	move "Y"			to	eof-claims-mstr 
	go to ha0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to	ctr-claims-mstr-reads. 
    move clmhdr-orig-batch-nbr		to	hold-clmhdr-batch-nbr.   
    move clmhdr-orig-claim-nbr		to	hold-clmhdr-claim-nbr. 
 
ha0-99-exit. 
    exit. 
sa0-add-claim-totals. 
 
    perform sa1-find-ss-type 		thru	sa1-99-exit. 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, clmhdr-agent-cd		giving	ss-agent. 
 
    add batctrl-clm-offset, ss-a-r-oma	giving ss-temp1.
    add clmhdr-tot-claim-ar-oma		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).    
    add batctrl-clm-offset, ss-a-r-ohip	giving ss-temp1.
    add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
    add batctrl-clm-offset, ss-cash	giving ss-temp1.
    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 
    add batctrl-clm-offset, ss-nbr	giving ss-temp1.
    add 1                  		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).         

*mf    add clmhdr-tot-claim-ar-oma		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-a-r-oma ).    
*mf    add clmhdr-tot-claim-ar-ohip	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-a-r-ohip ).   
*mf    add clmhdr-manual-and-tape-paymnts	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-cash  ). 
*mf    add 1                  		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr ).         
 
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
 
    perform sa3-find-ss-type 		thru	sa3-99-exit. 
 
*	(calculate ss-agent from batch'S AGENT CODE) 
    add  1, batctrl-agent-cd		giving	ss-agent. 
 
    add batctrl-clm-offset, ss-a-r-oma	giving ss-temp1.
    add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).    
    add batctrl-clm-offset, ss-a-r-ohip	giving ss-temp1.
    add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, ss-temp1 ).   
    add batctrl-clm-offset, ss-cash	giving ss-temp1.
    add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, ss-temp1 ). 

*mf    add batctrl-calc-ar-due     		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-a-r-oma ).    
*mf    add batctrl-calc-tot-rev     		to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-a-r-ohip ).   
*mf    add batctrl-manual-pay-tot          	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-cash  ). 
***************************************************************** 
* 'SA21-CHECK-NBR-CLAIMS-FIELD' is a temporary patch needed only * 
*  as long as there are batch control records without the field *       
* "BATCTRL-NBR-CLAIMS-IN-BATCH" added.  this routine may be re- * 
*  moved after it is no longer needed.  81-jan-19.              * 
 
    perform sa21-check-nbr-claims-field	thru	sa21-99-exit. 
 
***************************************************************** 
*mf    add batctrl-nbr-claims-in-batch	to	tbl-tot (ss-type, ss-agent, batctrl-clm-offset + ss-nbr ).         

    add batctrl-clm-offset, ss-nbr	giving ss-temp1.
    add batctrl-nbr-claims-in-batch	to	tbl-tot (ss-type, ss-agent, ss-temp1 ).         
 
sa2-99-exit. 
    exit. 
 
 
 
sa21-check-nbr-claims-field. 
 
    if    batctrl-nbr-claims-in-batch not numeric 
      or  batctrl-nbr-claims-in-batch = zero 
    then 
	move batctrl-last-claim-nbr	to	batctrl-nbr-claims-in-batch. 
*   (else) 
*   endif 
 
sa21-99-exit. 
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
sa4-tot-non-processed-batches. 
 
    if    batctrl-batch-type = "A" 
      and batctrl-adj-cd     = "A" 
    then 
	move ss-a				to	ss 
	add batctrl-manual-pay-tot          	to	fin-tot-cash( ss ) 
    else 
	if    batctrl-batch-type = "P" 
	  and batctrl-adj-cd     = "C" 
	then 
	    move ss-c				to	ss             
	    subtract batctrl-manual-pay-tot     from	fin-tot-cash( ss ) 
	else 
*	    (invalid option) 
	    go to sa4-99-exit. 
*	endif 
*   endif 
 
    add batctrl-calc-ar-due     		to	fin-tot-a-r ( ss ). 
    add batctrl-calc-tot-rev     		to	fin-tot-rev ( ss ). 
***************************************************************** 
* 'SA21-CHECK-NBR-CLAIMS-FIELD' is a temporary patch needed only * 
*  as long as there are batch control records without the field *       
* "BATCTRL-NBR-CLAIMS-IN-BATCH" added.  this routine may be re- * 
*  moved after it is no longer needed.  81-jan-19.              * 
 
    perform sa21-check-nbr-claims-field	thru	sa21-99-exit. 
 
***************************************************************** 
    add batctrl-nbr-claims-in-batch		to	fin-tot-nbr ( ss ). 
 
sa4-99-exit. 
    exit. 
tb0-write-line. 
 
    add  nbr-lines-2-advance 				to	ctr-lines.     
    if ctr-lines > max-nbr-lines          
    then 
 	perform tc0-print-headings			thru	tc0-99-exit. 
*   (else) 
*   endif 
 
    write   print-record  from t1-print-line   after advancing  nbr-lines-2-advance. 
 
    move spaces						to	t1-print-line.                  
    move 1						to	nbr-lines-2-advance. 
 
tb0-99-exit. 
    exit. 
tc0-print-headings. 
 
    add 1					to	page-ctr. 
    move page-ctr				to	h1-page. 
    write print-record from h1-head after advancing page. 
    write print-record from h2-head after advancing 2 lines. 
    write print-record from h3-head after advancing 2 lines. 
    move 2 					to	nbr-lines-2-advance. 
    move 6 					to	ctr-lines. 
 
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
  
    move tbl-tot (ss-type-from, ss-agent, 1 )	to	t1-detail-1 . 
    move tbl-tot (ss-type-from, ss-agent, 2 )	to	t1-detail-2 . 
    move tbl-tot (ss-type-from, ss-agent, 3 )	to	t1-detail-3 . 
    move tbl-tot (ss-type-from, ss-agent, 4 )	to	t1-detail-4 . 
    move tbl-tot (ss-type-from, ss-agent, 5 )	to	t1-detail-5 . 
    move tbl-tot (ss-type-from, ss-agent, 6 )	to	t1-detail-6 . 
    move tbl-tot (ss-type-from, ss-agent, 7 )	to	t1-detail-7 . 
    move tbl-tot (ss-type-from, ss-agent, 8 )	to	t1-detail-8 . 
 
tg0-99-exit. 
    exit. 
*mf xa0-read-display-save-clinic-info. 
xa0-read-disp-save-clinic-info. 
 
    move batctrl-bat-clinic-nbr-1-2	to	iconst-clinic-nbr-1-2  
						hold-clinic-nbr. 
 
    read iconst-mstr 
    	invalid key 
 		move 2 				to err-ind 
		perform za0-common-error	thru za0-99-exit 
       		go to xa0-99-exit. 
 
*    (ring bell indicating processing has moved on to new clinic) 
    display ring-bell. 
* 2005/05/18 - MC - comment out the redundant ring bell
*    display ring-bell. 
*    display ring-bell. 
*    display ring-bell. 
*    display ring-bell. 
 
    display scr-clinic-ped-cycle. 
 
    move iconst-date-period-end-yy	to	h1-ped-yy. 
    move iconst-date-period-end-mm	to	h1-ped-mm. 
    move iconst-date-period-end-dd	to	h1-ped-dd. 
    move iconst-clinic-cycle-nbr	to	h2-cycle-nbr. 
    move iconst-clinic-nbr-1-2		to	h2-clinic-nbr 
						h1-clinic-nbr. 
 
xa0-99-exit. 
    exit. 
xa1-end-of-clinic. 
 
    perform zb0-print-totals-summary	thru	zb0-99-exit. 
 
    perform zf0-print-non-proc-tots	thru	zf0-99-exit 
	    varying ss 
	    from 1 
	    by   1  
	    until  ss > 2. 
 
    perform ya1-add-to-fin-tots		thru	ya1-99-exit. 
 
    move zero				to	tbl-totals 
						tbl-fin-tots. 
 
xa1-99-exit. 
    exit. 


xx0-increment-batch-nbr.
*0 - 9 A - Z
    move "N"                            to      flag-request-complete.

    if clmdtl-orig-batch-number = 999
    then
        move clmdtl-orig-doc-number     to      tmp-doc-nbr-alpha
        display "BEFORE: " clmdtl-orig-doc-number
        perform xx1-process-1-doc-position  thru xx1-99-exit
            varying   ss from 3 by -1
            until     ss = 0
               or      flag-request-complete-y
        move tmp-doc-nbr-alpha          to       clmdtl-orig-doc-number
        display "AFTER : " clmdtl-orig-doc-number
        display " "
        move 000                        to       clmdtl-orig-batch-number
    else
        add 1                           to       clmdtl-orig-batch-number.
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
    if tmp-batch-nbr-index(ss) = "Q"
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


ya1-add-to-fin-tots. 
 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 1 ) to	fin-tot-1. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 2 ) to	fin-tot-2. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 3 ) to	fin-tot-3. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 4 ) to	fin-tot-4. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 5 ) to	fin-tot-5. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 6 ) to	fin-tot-6. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 7 ) to	fin-tot-7. 
    add tbl-tot (ss-grand-tot, ss-agent-tot, 8 ) to	fin-tot-8. 
 
    add fin-tot-a-r  (ss-a)			to	fin-tot-a-a-r. 
    add fin-tot-rev  (ss-a)			to	fin-tot-a-rev. 
    add fin-tot-cash (ss-a)			to	fin-tot-a-cash. 
    add fin-tot-nbr  (ss-a)			to	fin-tot-a-nbr. 
    add fin-tot-a-r  (ss-c)			to	fin-tot-c-a-r. 
    add fin-tot-rev  (ss-c)			to	fin-tot-c-rev. 
    add fin-tot-cash (ss-c)			to	fin-tot-c-cash. 
    add fin-tot-nbr  (ss-c)			to	fin-tot-c-nbr. 
 
ya1-99-exit. 
    exit. 
yb1-print-final-totals. 
 
    move zero			to	h1-ped-yy 
					h1-ped-mm 
					h1-ped-dd 
					h2-cycle-nbr 
					h2-clinic-nbr. 
    move 90			to	ctr-lines. 
 
    move "FINAL TOTALS"		to	t1-desc. 
 
    move fin-tot-1		to	t1-detail-1. 
    move fin-tot-2		to	t1-detail-2. 
    move fin-tot-3		to	t1-detail-3. 
    move fin-tot-4		to	t1-detail-4. 
    move fin-tot-5		to	t1-detail-5. 
    move fin-tot-6		to	t1-detail-6. 
    move fin-tot-7		to	t1-detail-7. 
    move fin-tot-8		to	t1-detail-8. 
 
    move 3			to	nbr-lines-2-advance. 
 
    perform tb0-write-line	thru	tb0-99-exit. 
 
    move "FINAL 'A' ADJUST."	to	t1-desc. 
 
    move fin-tot-a-a-r		to	t1-detail-1. 
    move fin-tot-a-rev		to	t1-detail-2. 
    move fin-tot-a-cash		to	t1-detail-3. 
    move fin-tot-a-nbr		to	t1-detail-4. 
 
    move 2			to	nbr-lines-2-advance. 
 
    perform tb0-write-line	thru	tb0-99-exit. 
 
    move "FINAL 'C' PAYMENTS"	to	t1-desc. 
 
    move fin-tot-c-a-r		to	t1-detail-1. 
    move fin-tot-c-rev		to	t1-detail-2. 
    move fin-tot-c-cash		to	t1-detail-3. 
    move fin-tot-c-nbr		to	t1-detail-4. 
 
    move 2			to	nbr-lines-2-advance. 
 
    perform tb0-write-line	thru	tb0-99-exit. 
 
yb1-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
zb0-print-totals-summary. 
 
*	(start totals on new page) 
    move 98				to	ctr-lines. 
*   (flags will determine if batch type and adjustment type descriptions are to be printed) 
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
	    move 2				to	nbr-lines-2-advance 
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
*    ( 'NBR + OFFSET' gives retained types. 'OFFSET' = 4) 
    add ss-nbr, ss-offset 		giving ss-temp1.
    if     tbl-tot (ss-type, ss-agent, ss-nbr) 		    = zero 
*mf       and tbl-tot (ss-type, ss-agent, ss-nbr + ss-offset ) = zero 
       and tbl-tot (ss-type, ss-agent, ss-temp1 ) = zero 
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
	move 3				to	nbr-lines-2-advance. 
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
zf0-print-non-proc-tots. 
 
    move fin-tot-desc( ss )			to	t1-desc. 
 
    move fin-tot-a-r ( ss )            		to	t1-detail-1. 
    move fin-tot-rev ( ss )           		to	t1-detail-2. 
    move fin-tot-cash( ss )   		     	to	t1-detail-3. 
    move fin-tot-nbr ( ss ) 			to	t1-detail-4. 
 
    move 2					to	nbr-lines-2-advance. 
    perform tb0-write-line			thru	tb0-99-exit. 
 
zf0-99-exit. 
    exit. 
 
    copy "y2k_default_sysdate_century.rtn".
