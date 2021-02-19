identification division. 
program-id. r004c. 
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    files      : f020 - doctor master 
*		: f070 - dept master 
*		: parameter-file 
*		: work file 
*		: "r004" print report file 
* 
*    program purpose : print the monthly claims and adjustment 
*		       transaction summary. 
*			this is the third in a series of 3 programs. 
*			it uses the sorted work file created by r004b 
*			to print the report. 
* 
*    date	programmer	reasons for change 
* 
*    03/16/87   j.l.		pdr 282 
*				to print correct batch nbr for adj and 
*				payment in reports 
* 
*    07/10/87   j.l. 		pdr 335/ sms 97 
*				to indicate the adjustment sub-type, 
*				automatic or manual 
*                               to be able to suppress or to print the 
*				automatic adjustment 
* 
*    11/03/88   m.s.		sms 97 
*				do not print the adj cd sub type if the 
*				value is '0' for agent 0 
* 
*    11/03/88   m.s.		sms 111 
*				do not print the oma fee and oma adj 
*				columns 
* 
*    08/03/89   s.f.		sms 97 
*				split the rev and a/r adjustments into 
*				manual and automatic when printing the 
* 				totals 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*    april 26/89  s. fader      - sms 116 
*				- print the dept code and/or name 
* 
*    oct   09/90  b. langendock - print totals by agents. sms 134 
*  		 
*    may   02/91  m. chan	- pdr 482 
*				- add the message note after each 
*				  doctor total. 
* 
*    dec   18/91  m. chan	- pdr 538 
*				- add the line counters per page 
*				  properly, some pages are page 
*				  overflow. 
* 
*   dec   1/92    y.boccia      - modify agentdesc.ws for agent 9 
* 
*   apr   12/93   y.boccia      - modify agentdesc.ws for agent 8 
* 
*   jun   12/94   m. chan	- modify agentdesc.ws for agent 8 again 
* 
*   oct   04/95   m. chan	- print the additional lines of 12 to 
*				  18 from agentdesc.ws in ke0 subroutine 
* 
*   aug   29/96   y.boccia      - take out agentdesc.ws and from print 
*                                 comment "WRITE-PRINT-RECORD FROM 
*                                 ad-line-1 to ad-line-18 and 
*                                 doc-mess-line. ke0 subroutine 
*                                 lake out page 25 lines 95 to 100 and 
*                                 line 102 and lines 182 to 213 
*                                 page 27 take out 4-5 and 96-102 
* 
*   jan   30/98   j. chau       - s149 unix conversion
*
*   May   07/99   S. Bachmann	- y2k changes to the header.
*   revised 2002/Oct/23 M.C.    - r004_claims_work_mstr_new.fd does not exist,
*				  use r004_claims_work_mstr.fd instead
*   2003/dec/09 M.C.	- alpha doc nbr
*   2006/nov/22 M.C.	- change l1-batch-week and l1-batch-day from numeric to character
*			  so that payment batches display correctly for alpha batches
 
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
* 
    select r004-work-file 
	assign to "r004_sort_work_mstr" 
	organization is sequential. 
* 
* 
* 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
* 
* 
* 
    copy "r004_parm_file.slr". 
* 
* 
* 
    copy "f020_doctor_mstr.slr". 
* 
* 
* 
    copy "f070_dept_mstr.slr". 
data division. 
file section. 
* 
*   copy 'R004_CLAIMS_WORK_MSTR.FD'. 

** 2002/10/23 - MC
**    copy 'r004_claims_work_mstr_new.fd'.  - missing
    copy 'r004_claims_work_mstr.fd'. 
** 2002/10/23 - end

    copy 'f020_doctor_mstr.fd'. 
    copy "f070_dept_mstr.fd". 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
* 
* 
* 
    copy "r004_parm_file.fd". 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
	value "r004". 
77  option					pic x. 
77  max-nbr-lines				pic 99   value 60. 
77  ctr-lines					pic 99	   value 70. 
77  ws-i-o-pat-ind				pic x. 
77  batch-total					pic s9(6)v99   value zero. 
77  batch-diff					pic s9(6)v99 value zero. 
77  ws-fee-ohip					pic 9(5)v99. 
77  ws-nbr-serv					pic 99. 
77  nbr-rec-processed				pic 9(4). 
77  ws-rev-calcd				pic s9(6)v99  value zero. 
77  rev-calcd-total				pic s9(6)v99  value zero. 
77  update-amt-total				pic s9(6)v99  value zero. 
77  diff-total					pic s9(6)v99  value zero. 
77  ws-agent                                    pic 99        value zero. 
77  ss-agent                                    pic 99        value zero. 
77  ss-oma-ohip					pic 99	      value zero. 
77  ss-trans-type                               pic 99	      value zero. 
*!77  hold-clmhdr-batch-nbr			pic 9(9). 
77  hold-clmhdr-batch-nbr			pic x(8). 
77  hold-clmhdr-claim-nbr			pic 99. 
77  sel-month					pic 99. 
*77  ws-doctor-nbr				pic 999. 
77  const-mstr-rec-nbr				pic x. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-docrev-mstr			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  blank-line					pic x(132) value spaces. 
* 
77  ws-print-auto				pic x   value "N". 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
77  eof-claims-dtl				pic x   value "N". 
77  eof-claims-mstr				pic x   value "N". 
77  eof-doctor-mstr				pic x	value "N". 
77  eof-work-file				pic x	value "N". 
77  new-header					pic x    value "N". 
77  sub1					pic 9	value zero. 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic   x(11). 
*mf 77  status-batctrl-file			pic   x(11) value zero. 
*mf 77  status-claims-mstr			pic   x(11) value zero. 
*mf 77  status-dept-mstr			pic   x(11) value zero. 
*mf 77  status-iconst-mstr			pic   x(11) value zero. 
*mf 77  status-doc-mstr				pic   x(11) value zero. 
*mf 77  status-sort-file			pic   x(11). 

77  common-status-file				pic   xx.
77  status-cobol-batctrl-file			pic   xx    value zero. 
77  status-cobol-claims-mstr			pic   xx    value zero. 
77  status-cobol-dept-mstr			pic   xx    value zero. 
77  status-cobol-doc-mstr			pic   xx    value zero. 
77  status-prt-file				pic   xx    value zero. 
77  status-sort-file				pic   xx. 
77  sel-clinic-nbr				pic 99. 
77  claims-occur				pic 9(5). 
 
 
01  flag-rec					pic x. 
    88  valid-rec				value "Y". 
    88  invalid-rec				value "N". 
 
 
01  prev-doc-nbr. 
    05  prev-dept				pic 99. 
*!    05  prev-doctor-nbr				pic 999. 
    05  prev-doctor-nbr				pic xxx. 
 
01 totals-table. 
    05  oma-or-ohip occurs 2 times. 
	10  totals occurs 6 times. 
          12  agent-breakdown occurs 11 times. 
	    15  doc-totals			pic s9(7)v99. 
	    15  dept-totals			pic s9(7)v99. 
	    15  grand-totals			pic s9(7)v99. 
 
* at totals level:  1 = a/r - receivable 
*                   2 = a/r - adjustment 
*                   3 = a/r - total 
*                   4 = rev - revenue 
*                   5 = rev - adjustment 
*                   6 = rev - total 
 
* sms #97  split the rev and a/r adjustments into man and auto 
 
01 adj-totals-table. 
   05  adj-totals occurs 4 times. 
     07 adj-agent-breakdown occurs 11 times. 
	10  adj-doc-totals			pic s9(7)v99. 
	10  adj-dept-totals			pic s9(7)v99. 
	10  adj-grand-totals		        pic s9(7)v99. 
 
*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-claims-work-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-work-file-writes			pic 9(7). 
    05  ctr-work-file-reads			pic 9(7). 
    05  ctr-doc-mstr-reads			pic 9(7). 
    05  ctr-pages				pic 9999. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"NO PARAMETER FILE SUPPLIED". 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"NO BATCTRL FILE SUPPLIED".    
	10  filler				pic x(60)   value 
			"NO BATCH CONTROL RECORDS FOR CLINIC NUMBER". 
	10  filler				pic x(60)   value 
			"NO APPROPRIATE RECORDS IN BATCTRL FILE". 
	10  filler				pic x(60)   value 
			"NO CLAIMS FOR THIS BATCH". 
	10  filler				pic x(60)   value 
			"NO HEADER FOR CURRENT BATCH". 
	10  filler				pic x(60)    value 
		"INVALID MONTH". 
	10  filler				pic x(60)    value 
	"ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING". 
	10  filler				pic x(60)     value 
		"INVALID BATCH TYPE". 
	10  filler				pic x(60)	value 
		"WORK FILE EMPTY". 
	10  filler				pic x(60)	value	 
		"INVALID READ ON DOCTOR MASTER FILE". 
	10  filler				pic x(60)	value	 
		"INVALID READ ON CLAIMS WORK FILE". 
	10  filler				pic x(60)	value	 
		"INVALID WF-ADJ-CD-SUB-TYPE IE NOT M OR A". 
	10  filler				pic x(60)	value 
		"DEPARTMENT MASTER READ ERROR". 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 16 times. 
 
01  err-msg-comment. 
    05  err-msg-key-type			pic x(25). 
    05  err-msg-key				pic x(35). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
*   copy "AGENTDESC.WS". 
 
    copy "sysdatetime.ws". 
01  h1-head. 
 
    05  filler					pic x(7)	value 
		"R004  /". 
    05  h1-clinic-nbr				pic 99. 
    05  filler					pic x	value spaces. 
    05  filler					pic x(5) value 
		"DATE". 
    05  h1-date. 
* (y2k)
*	10  h1-yy				pic 99. 
	10  h1-yy				pic 9(04).
	10  filler				pic x value "/". 
	10  h1-mm				pic 99. 
	10  filler				pic x value "/". 
	10  h1-dd				pic 99. 
* (y2k)
*    05  filler					pic x(14) value spaces. 
    05  filler					pic x(12) value spaces. 
    05  filler					pic x(85)	value 
	"* MONTHLY CLAIMS AND ADJUSTMENTS TRANSACTION SUMMARY *". 
    05  filler					pic x(5)	value 
		"PAGE ". 
    05  h1-page-nbr				pic z,zz9. 
 
01  h2-head. 
    05  filler					pic x(54)  value spaces. 
    05  h2-clinic-name				pic x(20). 
    05  filler					pic x(12)  value spaces. 
    05  filler					pic x(13)	value 
	"DEPARTMENT #". 
    05  h2-dept-nbr				pic 99. 
    05  filler					pic x(1)   value spaces. 
    05  h2-dept-name                            pic x(30). 
 
01  h3-head. 
    05  filler					pic x(86) value spaces. 
    05  filler					pic x(7)  value 
	"DOCTOR-". 
*!    05  h3-doc-nbr				pic 999. 
    05  h3-doc-nbr				pic xxx. 
    05  filler					pic x     value spaces. 
    05  h3-doc-name				pic x(24). 
    05  filler 					pic x(11) value spaces. 
 
01  h4-head. 
    05  filler					pic xx value spaces. 
* 99/11/18 - MC
*   05  filler					pic x(41)	value 
    05  filler					pic x(39)	value 
 
	"PATIENT     CLAIM   PATIENT ID/  AGENT". 
*   05  filler					pic x(46)  value 
    05  filler					pic x(48)  value 
*	" ADJ/or    OHIP        ADJUSTMENT SERVICE". 
	" ADJ/or      OHIP    ADJUSTMENT SERVICE". 
    05  filler					pic x(43)  value 
	"CLAIM   DIAG  OMA  #OF  BATCH     FORM#". 
 
01  h5-head. 
    05  filler					pic x(3) value spaces. 
* 99/11/22 - MC
*   05  filler					pic x(40) value 
    05  filler					pic x(38) value 
	"NAME       NUMBER  CHART NUMBER  CODE". 
* 99/11/22 - MC
*   05  filler					pic x(47)  value 
    05  filler					pic x(49)  value 
*	" SOURCE     FEE          AMOUNT     DATE". 
	" SOURCE       FEE      AMOUNT     DATE". 
    05  filler					pic x(42)  value 
	"DATE   CODE  CODE SRV  NUMBER    NOTE". 
 
01  h6-head. 
    05  filler					pic x(8) value 
	" DOCTOR". 
*!    05  h6-doc-nbr				pic 999. 
    05  h6-doc-nbr				pic xxx. 
    05  filler					pic x(121) value spaces. 
 
01  h7-head. 
    05  filler					pic x(30) value 
	"DEPARTMENTAL SUMMARY  DEPT #". 
    05  h7-dept-nbr				pic 99. 
    05  filler					pic x(100) value spaces. 
 
01  h8-head. 
    05  filler					pic x(60) value spaces. 
    05  h8-clinic-name				pic x(72). 
 
01  h9-head. 
 
    05  filler                                  pic x(53)       value 
           "-----------------------------------------------------". 
    05  h9-head-msg                             pic x(26). 
    05  filler                                  pic x(54)       value 
           "-----------------------------------------------------". 
 
 
01  h10-head. 
 
    05  filler                                  pic x(16)       value spaces. 
    05  filler                                  pic x(11)       value "0". 
    05  filler                                  pic x(11)       value "1". 
    05  filler                                  pic x(11)       value "2". 
    05  filler                                  pic x(11)       value "3". 
    05  filler                                  pic x(11)       value "4". 
    05  filler                                  pic x(11)       value "5". 
    05  filler                                  pic x(11)       value "6". 
    05  filler                                  pic x(11)       value "7". 
    05  filler                                  pic x(11)       value "8". 
    05  filler                                  pic x(11)       value "9". 
    05  filler                                  pic x(5)        value "TOTAL". 
 
01  print-line. 
 
    05  l1-print-line. 
	10  l1-pat-surname			pic x(7). 
	10  l1-pat-acronym3			pic x(4). 
	10  l1-clmhdr-claim-nbr. 
	    15  l1-claim-clinic1		pic 99. 
*!	    15  l1-claim-doc-nbr		pic 9(3). 
	    15  l1-claim-doc-nbr		pic x(3). 
	    15  l1-claim-week			pic 99. 
	    15  l1-claim-day			pic 9. 
	    15  l1-claim-nbr			pic 99. 
	10  filler				pic x. 
	10  l1-patient-id			pic x(15). 
 	10  filler				pic xx. 
        10  l1-agent-code			pic 9. 
* (y2k) - to allow for century farther down.
* 	10  filler				pic x(5). 
   	10  filler				pic x(3). 
	10  l1-a-m-adj. 
            15 l1-adj-code			pic x. 
	    15 l1-filler-slash			pic x. 
	    15 l1-adj-cd-sub-type		pic x. 
        10  filler				pic x(4) value spaces. 
	10  l1-tot-claim-ohip			pic zzzz9.99-. 
* (y2k) - to allow for century farther down.
*        10  filler				pic x(6) value spaces. 
        10  filler				pic x(4) value spaces. 
	10  l1-tot-claim-ohip-adj		pic zzzz9.99-. 
	10  l1-tot-claim-ohip-adj-r  redefines   l1-tot-claim-ohip-adj 
						pic x(9). 
	10  filler				pic x. 
	10  l1-service-date. 
* (y2k)
*	    15  l1-service-date-yy		pic 99. 
	    15  l1-service-date-yy		pic 9999. 
	    15  l1-slash1			pic x. 
	    15  l1-service-date-mm		pic 99. 
	    15  l1-slash2			pic x. 
	    15  l1-service-date-dd		pic 99. 
	10  filler				pic xx. 
	10  l1-claim-date. 
* (y2k)
*	    15  l1-claim-date-yy		pic 99. 
	    15  l1-claim-date-yy		pic 9999. 
	    15  l1-slash3			pic x. 
	    15  l1-claim-date-mm		pic 99. 
	    15  l1-slash4			pic x. 
	    15  l1-claim-date-dd		pic 99. 
	10  filler				pic xx. 
	10  l1-diag-cd				pic 999   blank when zero. 
	10  filler				pic xx. 
	10  l1-oma-code. 
	    15  l1-oma-cd			pic x(4). 
	    15  l1-oma-suff			pic x. 
	10  filler				pic x. 
	10  l1-nbr-of-services			pic zz9. 
	10  filler				pic xx. 
	10  l1-batch-nbr. 
	    15  l1-batch-clinic1		pic 99. 
*!	    15  l1-batch-doc-nbr		pic 9(3). 
	    15  l1-batch-doc-nbr		pic x(3). 
* 2006/11/22 - MC
*	    15  l1-batch-week			pic 99. 
*	    15  l1-batch-day			pic 9. 
	    15  l1-batch-week			pic xx.
	    15  l1-batch-day			pic x. 
* 2006/11/22 - end
	10  filler				pic xx. 
	10  l1-ref-field			pic x(9). 
    05  l2-print-line redefines l1-print-line. 
        10  l2-type                             pic x(9). 
        10  l2-ohip-totals-r   occurs 10 times. 
	    15  l2-ohip-totals			pic zzzzzz9.99-. 
	10  l2-agent-total			pic zzzzz,zz9.99-. 
 
    05  l3-print-line redefines l2-print-line. 
	10  filler				pic x(62). 
	10  l3-ohip				pic x(70). 
 
    05  l4-print-line redefines l3-print-line. 
	10  filler				pic x(4). 
	10  l4-type                             pic x(116). 
 	10  l4-adj-tot                          pic zzzz,zz9.99-. 
 
 
01  l5-print-line. 
	05  filler				pic x(52)    value 
        "            -------    -------    -------    -------". 
        05  filler                              pic x(55)   value 
	"    -------    -------    -------    -------    -------". 
        05  filler                              pic x(25)   value 
	"    -------    ----------". 
 
 
procedure division. 
declaratives. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
*mf    move status-doc-mstr		to common-status-file. 
    move status-cobol-doc-mstr		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
    stop "ERROR IN ACCESSING DEPT MASTER ". 
*mf    move status-dept-mstr		to common-status-file. 
    move status-cobol-dept-mstr		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab2-create-report		thru ab2-99-exit. 
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
*    ( select printing of automatic adjustment        j.l. 87/07/13) 
 
aa1-scr-reply-edit. 
 
*   display scr-select-print-auto. 
 
*   accept  scr-reply. 
    accept  ws-print-auto 
 
    if   ws-print-auto = "Y" 
      or ws-print-auto = "N" 
    then 
         next sentence 
    else 
         go to aa1-scr-reply-edit. 
*   endif 
 
 
*   display program-in-progress. 
 
*	(delete print file) 
*    expunge print-file. 
 
    open input	r004-work-file 
		dept-mstr 
		parameter-file 
		doc-mstr. 
    open output print-file. 
 
    move 0				to counters. 
 
    move 1				to ctr-pages. 
    move spaces				to print-line 
					   work-file-rec. 
    move 0				to totals-table 
                                           adj-totals-table. 
 
 
    read parameter-file 
*	invalid key 
 	at end 
 	    move 2			to err-ind 
 	    perform za0-common-error	thru za0-99-exit 
 	    go to az0-end-of-job. 
 
*	(obtain clinic name,nbr and period end from parameter file) 
    move parm-clinic-nbr		to	h1-clinic-nbr. 
    move parm-clinic-name 		to	h2-clinic-name 
						h8-clinic-name. 
    move parm-date-period-end-yy	to	h1-yy. 
    move parm-date-period-end-mm	to	h1-mm. 
    move parm-date-period-end-dd	to	h1-dd. 
  
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close r004-work-file 
          dept-mstr 
	  parameter-file 
	  doc-mstr 
	  print-file. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab2-create-report. 
 
    read  r004-work-file 
	at end 
	    move 12			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-work-file-reads. 
 
    move wf-doctor-id			to	prev-doc-nbr. 
 
*	(set up heading for first dept and doctor)  
    perform kb0-read-doc-mstr		thru	kb0-99-exit. 
 
    perform ki0-read-dept-mstr          thru    ki0-99-exit. 
 
    move wf-doc-nbr			to	h3-doc-nbr. 
    move doc-name			to	h3-doc-name. 
    move wf-dept			to	h2-dept-nbr. 
    move dept-name			to	h2-dept-name. 
 
    perform ja0-build-write-report	thru	ja0-99-exit 
		until eof-work-file = "Y". 
 
    perform kh0-write-grand-totals	thru	kh0-99-exit. 
 
ab2-99-exit. 
    exit. 
ja0-build-write-report. 
 
    perform jb0-build-write-dept-rprt	thru	jb0-99-exit 
	until   wf-dept   not = prev-dept 
	     or eof-work-file = "Y". 
 
    perform jc0-write-doc-totals	thru	jc0-99-exit. 
 
    perform kf0-obtain-dept-ttls	thru	kf0-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 2. 
 
 
* sms #97  split the rev and a/r adjustments into man and auto 
    perform kf1-obtain-adj-dept-ttls	thru	kf1-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 4. 
 
    perform kg0-write-dept-totals	thru	kg0-99-exit. 
 
    perform la0-zero-to-dept-ttls	thru	la0-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 6. 
 
* sms #97  split the rev and a/r adjustments into man and auto 
    perform lc0-zero-to-adj-dept-ttls	thru	lc0-99-exit 
	varying ss-agent 
	from    1 by 1 
	until   ss-agent > 11. 
 
    if eof-work-file not = "Y" 
	move wf-dept			to 	h2-dept-nbr 
	move wf-doctor-id		to	prev-doc-nbr 
	perform kb0-read-doc-mstr	thru	kb0-99-exit 
	move wf-doc-nbr			to	h3-doc-nbr 
	move doc-name			to	h3-doc-name 
        perform ki0-read-dept-mstr      thru    ki0-99-exit 
        move dept-name			to	h2-dept-name. 
*   (else) 
*   endif 
 
ja0-99-exit. 
    exit. 
jb0-build-write-dept-rprt. 
 
    if wf-doctor-id not = prev-doc-nbr 
    then 
	perform jc0-write-doc-totals	thru	jc0-99-exit 
	move wf-doc-nbr			to	prev-doctor-nbr 
  	move wf-doc-nbr			to	h3-doc-nbr 
	perform kb0-read-doc-mstr	thru	kb0-99-exit 
	move doc-name			to	h3-doc-name. 
*   (else) 
*   endif 
 
    perform ka0-build-prt-line-and-ttls	thru	ka0-99-exit. 
* 
*  ( if input is not to print auto-adj then do not print detail; 
*    otherwise, print the details. m.s. 0n 87/09/25) 
 
     if     ws-print-auto = "N" 
	and wf-adj-cd = "B" 
	and wf-adj-cd-sub-type = "A" 
     then 
	move spaces                     to      print-line 
     else 
    	perform kc0-write-print-line	thru	kc0-99-exit. 
*    endif 
 
 
 
    read  r004-work-file 
	at end 
	    move "Y"			to	eof-work-file 
	    go to jb0-99-exit. 
 
    add 1				to	ctr-work-file-reads. 
 
jb0-99-exit. 
   exit. 
jc0-write-doc-totals. 
 
    perform kd0-obtain-doc-totals	thru	kd0-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 2. 
 
 
* sms #97  split the rev and a/r adjustments into man and auto 
    perform kd1-obtain-adj-doc-totals	thru	kd1-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 4. 
 
    perform ke0-print-doc-totals	thru	ke0-99-exit. 
 
    perform lb0-zero-to-doc-ttls	thru	lb0-99-exit 
	varying sub1 
	from    1 by 1 
	until   sub1 > 6. 
 
* sms #97  split the rev and a/r adjustments into man and auto 
    perform ld0-zero-to-adj-doc-ttls	thru	ld0-99-exit 
	varying ss-agent 
	from    1 by 1 
	until   ss-agent > 11. 
 
jc0-99-exit. 
    exit. 
ka0-build-prt-line-and-ttls. 
 
    move wf-pat-surname			to	l1-pat-surname. 
    move wf-pat-acronym3		to	l1-pat-acronym3. 
 
 
***  print the adjustment or payment batch nbr on both sides of output 
    if wf-trans-cd not  = " " 
    then 
	move wf-claim-clinic-nbr-1-2	to	l1-claim-clinic1 
	move wf-claim-doctor-nbr	to	l1-claim-doc-nbr 
	move wf-claim-week		to	l1-claim-week 
	move wf-claim-day		to	l1-claim-day 
	move wf-claim-nbr		to	l1-claim-nbr 
    else 
	move wf-orig-clinic-nbr-1-2	to	l1-claim-clinic1 
	move wf-orig-doc-nbr		to	l1-claim-doc-nbr 
	move wf-orig-week		to	l1-claim-week 
	move wf-orig-day		to	l1-claim-day 
	move wf-orig-claim-nbr		to	l1-claim-nbr. 
*   endif 
 
    if wf-pat-id-or-chart = zeros 
    then 
	move spaces			to	l1-patient-id 
    else 
	move wf-pat-id-or-chart		to	l1-patient-id. 
*   endif 
 
*   move wf-agent-cd-adj		to	l1-agent-adj. 
    move wf-agent-cd-adj		to	l1-agent-code. 
    move wf-service-date-yy		to	l1-service-date-yy. 
    move wf-service-date-mm		to	l1-service-date-mm. 
    move wf-service-date-dd		to	l1-service-date-dd. 
    move wf-claim-date-sys-yy		to	l1-claim-date-yy. 
    move wf-claim-date-sys-mm		to	l1-claim-date-mm. 
    move wf-claim-date-sys-dd		to	l1-claim-date-dd. 
    move "/"				to	l1-slash1 
						l1-slash2 
						l1-slash3 
						l1-slash4. 
    move wf-diag-cd			to	l1-diag-cd. 
    move wf-oma-code			to	l1-oma-code. 
    move wf-nbr-serv			to	l1-nbr-of-services. 
    move wf-orig-clinic-nbr-1-2		to	l1-batch-clinic1. 
    move wf-orig-doc-nbr		to	l1-batch-doc-nbr. 
    move wf-orig-week			to	l1-batch-week. 
    move wf-orig-day			to	l1-batch-day. 
    move wf-ref-field			to	l1-ref-field. 
 
*   (print under appropriate column) 
    if wf-trans-cd =   " " 
		    or "M" 
    then 
	move wf-claim-ohip		to	l1-tot-claim-ohip 
    else 
	move wf-claim-ohip		to	l1-tot-claim-ohip-adj. 
*   endif 
* 
    move wf-adj-cd			to	l1-adj-code. 
    if wf-adj-cd-sub-type not = '0' 
        and wf-adj-cd-sub-type not = 'S' 
        and wf-adj-cd-sub-type not = ' ' 
    then 
    	move wf-adj-cd-sub-type		to	l1-adj-cd-sub-type 
    	move "/"			to      l1-filler-slash. 
*   endif 
 
move wf-agent-cd                        to      ws-agent. 
*   (add to appropriate column of report and to totals) 
    if wf-trans-cd = " " 
    then 
*	add wf-claim-oma		to	doc-totals (1,1,ws-agent + 1) 
*						doc-totals (1,4,ws-agent + 1) 
	add wf-claim-ohip		to	doc-totals (2,1,ws-agent + 1) 
						doc-totals (2,4,ws-agent + 1) 
    else 
*  r004a eliminates wf-trans-cd = "A" 
*       if wf-trans-cd = "A" 
*       then 
*           add wf-claim-oma		to	doc-totals (1,2) 
*           add wf-claim-ohip		to	doc-totals (2,2) 
*       else 
	    if wf-trans-cd = "B" 
	    then 
*		add wf-claim-oma	to	doc-totals (1,2,ws-agent + 1) 
*						doc-totals (1,5,ws-agent + 1) 
		add wf-claim-ohip	to	doc-totals (2,2,ws-agent + 1) 
						doc-totals (2,5,ws-agent + 1) 
		perform ka1-determine-man-or-auto thru ka1-99-exit 
	    else 
		if wf-trans-cd = "M" 
		then 
*		    add wf-claim-oma	to	doc-totals (1,4,ws-agent + 1) 
		    add wf-claim-ohip	to	doc-totals (2,4,ws-agent + 1) 
		else 
*    wf-trans-cd = "R" 
*	             add wf-claim-oma	to	doc-totals (1,5,ws-agent + 1) 
 	             add wf-claim-ohip	to	doc-totals (2,5,ws-agent + 1) 
          	                                adj-doc-totals (3,ws-agent + 1). 
*		endif 
*	    endif 
*	endif 
*   endif 
 
ka0-99-exit. 
    exit. 
*sms 97 s.f. added to allow the separation of the revenue and a/r 
*            into manual and automatic. mar/89 
 
ka1-determine-man-or-auto. 
 
    if wf-adj-cd-sub-type = "A" 
    then 
        add wf-claim-ohip      to       adj-doc-totals (2,ws-agent + 1) 
                                        adj-doc-totals (4,ws-agent + 1) 
    else 
        if wf-adj-cd-sub-type = "M" 
        then 
            add wf-claim-ohip  to       adj-doc-totals (1,ws-agent + 1) 
                                        adj-doc-totals (3,ws-agent + 1) 
        else 
*           display "WF-TRANS-CD          = " wf-trans-cd 
*           display "WF-ADJ-CD-SUB-TYPE   = " wf-adj-cd-sub-type 
   	    move 15            to       err-ind 
   	    perform za0-common-error 
            go to az0-end-of-job. 
*       endif 
*   endif 
 
ka1-99-exit. 
    exit. 
kb0-read-doc-mstr. 
 
*   move wf-claim-doctor-nbr		to	doc-nbr. 
    move wf-doc-nbr         		to	doc-nbr. 
 
    read doc-mstr 
	invalid key 
	    move 13			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    move "DOCTOR NUMBER"	to	err-msg-key-type 
	    move doc-nbr		to	err-msg-key 
            perform za0-common-error	thru	za0-99-exit 
	    move "CLAIM NUMBER"		to	err-msg-key-type 
	    move wf-claim-id		to	err-msg-key 
       	    perform za0-common-error    thru    za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-doc-mstr-reads. 
 
kb0-99-exit. 
    exit. 
kc0-write-print-line. 
 
    if ctr-lines > max-nbr-lines 
    then 
	perform xa0-headings		thru	xa0-99-exit. 
*   (else) 
*   endif 
 
    write print-record	from print-line after advancing 1 line. 
    move spaces				to	print-line. 
 
    add 1				to	ctr-lines. 
 
kc0-99-exit. 
    exit. 
kd0-obtain-doc-totals. 
 
    perform le0-obtain-doc-agent-totals   thru le0-99-exit 
           varying ss-agent 
           from 1  by 1 
           until   ss-agent > 10. 
 
kd0-99-exit. 
    exit. 
 
kd1-obtain-adj-doc-totals. 
 
*mf    perform kd2-obtain-adj-doc-agent-totals   thru kd2-99-exit 
    perform kd2-obtain-adj-doc-agent-tot   thru kd2-99-exit 
           varying ss-agent 
           from 1  by 1 
           until   ss-agent > 10. 
 
kd1-99-exit. 
    exit. 
 
*mf kd2-obtain-adj-doc-agent-totals. 
kd2-obtain-adj-doc-agent-tot. 
 
    add adj-doc-totals (sub1,ss-agent)	to adj-dept-totals (sub1,ss-agent). 
kd2-99-exit. 
    exit. 
 
ke0-print-doc-totals. 
 
*    if ctr-lines > (max-nbr-lines - 16) 
     if ctr-lines > (max-nbr-lines - 14) 
     then 
	move ctr-pages			to	h1-page-nbr 
	write print-record from h1-head after advancing page 
	write print-record from h2-head after advancing 1 line 
	write print-record from h3-head after advancing 1 line 
	add 3				to 	ctr-lines 
	add 1				to	ctr-pages. 
*   (else) 
*   endif 
 
 
    move prev-doctor-nbr		to	h6-doc-nbr. 
    write print-record from h6-head after advancing 3 lines. 
    move "--EFFECT ON A/R BY AGENT--"    to	h9-head-msg. 
    write print-record from h9-head after advancing 2 lines. 
    write print-record from h10-head after advancing 1 line. 
    move spaces				to 	print-line. 
    move "RECV'D"			to	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 1				to	ss-trans-type. 
    perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move doc-totals (2,1,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 2 lines. 
    move spaces				to 	print-line. 
    move "A/R ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 1				to	ss-trans-type 
       perform ke2-doc-adj-print-setup 	thru	ke2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-doc-totals (1,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 2   			to	ss-trans-type 
       perform ke2-doc-adj-print-setup 	thru	ke2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-doc-totals (2,11)		to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move "  TOTAL"	  		to      l2-type 
 
       move 2                           to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move doc-totals (2,2,11)	        to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces 			to      print-line 
    else 
       move 2                           to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move doc-totals (2,2,11)	        to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces				to	print-line. 
*   endif 
    move "TOT A/R"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 3				to	ss-trans-type. 
    perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move doc-totals (2,3,11)	        to	l2-agent-total. 
    write print-record from print-line after advancing 1 line. 
    move spaces				to	print-line. 
    add 14				to 	ctr-lines. 
* yas comment 94 to 102 print rev and a/r totals on one page 
*   if ctr-lines > (max-nbr-lines - 12) 
*   then 
*	move ctr-pages			to	h1-page-nbr 
*	write print-record from h1-head after advancing page 
*	write print-record from h2-head after advancing 1 line 
*	write print-record from h3-head after advancing 1 line 
 	add 3				to 	ctr-lines 
*	add 1				to	ctr-pages. 
*   endif 
 
    move "EFFECT ON REVENUE BY AGENT"	to	h9-head-msg. 
    write print-record from h9-head    after advancing 3 line. 
    write print-record from h10-head   after advancing 1 line. 
    move spaces				to	print-line. 
    move "REVENU" 			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 4				to	ss-trans-type. 
    perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
 	until 	ss-agent > 10. 
    move doc-totals (2,4,11)	        to	l2-agent-total. 
    write print-record from print-line after advancing 2 line. 
    move spaces				to	print-line. 
    move "REV ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 3   			to	ss-trans-type 
       perform ke2-doc-adj-print-setup 	thru	ke2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-doc-totals (3,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 4   			to	ss-trans-type 
       perform ke2-doc-adj-print-setup 	thru	ke2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-doc-totals (4,11)		to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move "  TOTAL"   		to      l2-type 
       move 2                           to      ss-oma-ohip 
       move 5				to	ss-trans-type 
       perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move doc-totals (2,5,11)		to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces 			to      print-line 
   else 
       move 2                           to      ss-oma-ohip 
       move 5				to	ss-trans-type 
       perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move doc-totals (2,5,11)		to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line. 
*   endif 
    move "TOT REV"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 6				to	ss-trans-type. 
    perform ke1-doc-print-setup 	thru	ke1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move doc-totals (2,6,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 1 line. 
    move spaces				to	print-line. 
    add 12				to 	ctr-lines. 
 
*   if ctr-lines > (max-nbr-lines - 17) 
*  yas take out dont print h1,h2 and h3 for description 
*   if ctr-lines > (max-nbr-lines - 24) 
*   then 
*	move ctr-pages			to	h1-page-nbr 
*	write print-record from h1-head after advancing page 
*	write print-record from h2-head after advancing 1 line 
*	write print-record from h3-head after advancing 1 line 
*	add 3				to 	ctr-lines 
*	add 1				to	ctr-pages. 
*   endif 
 
* take out yas don'T PRINT AGENT DESCRIPTION AFTER EACH DOCTOR TOTALS 
*   write print-record		from 	ad-line-1 after advancing 3 lines. 
*   write print-record		from 	ad-line-2 after advancing 2 lines. 
*   write print-record		from 	ad-line-3. 
*   write print-record		from 	ad-line-4. 
*   write print-record		from 	ad-line-5. 
*   write print-record		from 	ad-line-6. 
*   write print-record		from 	ad-line-7. 
*   write print-record		from 	ad-line-8. 
*   write print-record		from 	ad-line-9. 
*   write print-record		from 	ad-line-10. 
*   write print-record		from 	ad-line-11. 
*   write print-record		from 	ad-line-12. 
*   write print-record		from 	ad-line-13. 
*   write print-record		from 	ad-line-14. 
*   write print-record		from 	ad-line-15. 
*   write print-record		from 	ad-line-16. 
*   write print-record		from 	ad-line-17. 
*   write print-record		from 	ad-line-18. 
 
*   write print-record 		from 	doc-mess-line after advancing 3 lines. 
    move 70				to	ctr-lines. 
 
ke0-99-exit. 
    exit. 
 
ke1-doc-print-setup. 
 
    move doc-totals(ss-oma-ohip,ss-trans-type,ss-agent)     to 
                    l2-ohip-totals(ss-agent). 
    add  doc-totals(ss-oma-ohip,ss-trans-type,ss-agent)     to 
         doc-totals(ss-oma-ohip,ss-trans-type,11). 
 
ke1-99-exit. 
    exit. 
 
ke2-doc-adj-print-setup. 
 
    move adj-doc-totals(ss-trans-type,ss-agent)     to 
                    l2-ohip-totals(ss-agent). 
    add  adj-doc-totals(ss-trans-type,ss-agent)     to 
         adj-doc-totals(ss-trans-type,11). 
 
ke2-99-exit. 
    exit. 
 
kf0-obtain-dept-ttls. 
 
    perform lf0-obtain-dept-agent-totals       thru  lf0-99-exit 
          varying ss-agent 
          from 1  by 1 
          until   ss-agent > 10. 
 
kf0-99-exit. 
    exit. 
 
kf1-obtain-adj-dept-ttls. 
 
*mf    perform kf2-obtain-adj-dept-agent-totals    thru  kf2-99-exit 
    perform kf2-obtain-adj-dept-agent-tot    thru  kf2-99-exit 
          varying ss-agent 
          from 1  by 1 
          until   ss-agent > 10. 
 
kf1-99-exit. 
    exit. 
 
*mf kf2-obtain-adj-dept-agent-totals. 
kf2-obtain-adj-dept-agent-tot. 
 
    add adj-dept-totals (sub1,ss-agent)  to adj-grand-totals (sub1,ss-agent). 
 
kf2-99-exit. 
    exit. 
kg0-write-dept-totals. 
 
*    if ctr-lines > (max-nbr-lines - 18) 
*    if ctr-lines > (max-nbr-lines - 17) 
*    then 
	move ctr-pages			to	h1-page-nbr 
	write print-record from h1-head after advancing page 
 	write print-record from h2-head after advancing 1 line 
	add 2				to	ctr-lines 
	add 1				to 	ctr-pages. 
*   (else) 
*   endif 
 
    move prev-dept			to	h7-dept-nbr. 
    write print-record from h7-head after advancing 5 lines. 
*   move "OHIP"				to	l3-ohip. 
*   write print-record from print-line after advancing 1 line. 
    move spaces				to	print-line. 
    move "--EFFECT ON A/R BY AGENT--"	to	h9-head-msg. 
    write print-record from h9-head    after advancing 2 lines. 
    write print-record from h10-head   after advancing 2 lines. 
    move spaces				to	print-line. 
    move "RECV'D"			TO	L2-TYPE. 
    move 2                              to      ss-oma-ohip. 
    move 1				to	ss-trans-type. 
    perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move dept-totals (2,1,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 2 lines. 
    move spaces				to 	print-line. 
    move "A/R ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 1   			to	ss-trans-type 
       perform kg2-dept-adj-print-setup 	thru	kg2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-dept-totals (1,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 2   			to	ss-trans-type 
       perform kg2-dept-adj-print-setup 	thru	kg2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-dept-totals (2,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move "  TOTAL"	  		to      l2-type 
       move 2				to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move dept-totals (2,2,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces 			to      print-line 
    else 
       move 2				to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move dept-totals (2,2,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces				to	print-line. 
*   endif 
 
    move "TOT A/R"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 3				to	ss-trans-type. 
    perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move dept-totals (2,3,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 1 line. 
    move spaces				to	print-line. 
    add 17				to 	ctr-lines. 
 
*   if ctr-lines > (max-nbr-lines - 12) 
*   then 
*	move ctr-pages			to	h1-page-nbr 
*	write print-record from h1-head after advancing page 
*	write print-record from h2-head after advancing 1 line 
*	add 2				to	ctr-lines 
*	add 1				to 	ctr-pages. 
*   endif 
 
    move "EFFECT ON REVENUE BY AGENT"	to	h9-head-msg. 
    write print-record from h9-head    after advancing 3 line. 
    write print-record from h10-head   after advancing 1 line. 
 
    move spaces				to	print-line. 
    move "REVENU"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 4				to	ss-trans-type. 
    perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move dept-totals (2,4,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 2 line. 
    move spaces				to	print-line. 
    move "REV ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 2   			to	ss-trans-type 
       perform kg2-dept-adj-print-setup 	thru	kg2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-dept-totals (3,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 4   			to	ss-trans-type 
       perform kg2-dept-adj-print-setup 	thru	kg2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-dept-totals (4,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move " TOTAL"	  		to      l2-type 
       move 2                           to      ss-oma-ohip 
       move 5				to	ss-trans-type 
       perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move dept-totals (2,5,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces 			to      print-line 
    else 
       move 2                           to      ss-oma-ohip 
       move 5				to	ss-trans-type 
       perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move dept-totals (2,5,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line. 
*   endif 
    move "TOT REV"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 6				to	ss-trans-type. 
    perform kg1-dept-print-setup 	thru	kg1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10. 
    move dept-totals (2,6,11)		to	l2-agent-total. 
    write print-record from print-line after advancing 1 line. 
    move spaces				to	print-line. 
    move 70				to	ctr-lines. 
 
kg0-99-exit. 
    exit. 
 
kg1-dept-print-setup. 
 
    move dept-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to 
                     l2-ohip-totals(ss-agent). 
    add  dept-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to 
         dept-totals(ss-oma-ohip,ss-trans-type,11). 
 
kg1-99-exit. 
    exit. 
 
kg2-dept-adj-print-setup. 
 
    move adj-dept-totals(ss-trans-type,ss-agent)    to 
                     l2-ohip-totals(ss-agent). 
    add  adj-dept-totals(ss-trans-type,ss-agent)    to 
         adj-dept-totals(ss-trans-type,11). 
 
kg2-99-exit. 
    exit. 
 
kh0-write-grand-totals. 
 
    move ctr-pages			to	h1-page-nbr. 
    write print-record from h1-head after advancing page. 
    write print-record from h8-head after advancing 1 line. 
    perform lg0-obtain-grand-agent-totals    thru   lg0-99-exit 
       		varying 	ss-agent 
		from 1		by 1 
		until		ss-agent > 10. 
 
    move "GRAND TOTALS"			to	h8-clinic-name. 
    write print-record from h8-head    after advancing  5 lines. 
    move spaces				to	print-line. 
 
 
 
    move "--EFFECT ON A/R BY AGENT--"	to	h9-head-msg. 
    write print-record from h9-head    after advancing 2 lines. 
    write print-record from h10-head   after advancing 1 line. 
    move spaces				to	print-line. 
    move "RECV'D"				TO	L2-TYPE. 
    move 2                              to      ss-oma-ohip. 
    move 1				to	ss-trans-type. 
    perform kh1-grand-print-setup 	thru	kh1-99-exit 
             varying ss-agent 
             from 1	by 1 
	     until 	ss-agent > 10. 
    move grand-totals (2,1,11)		to	l2-agent-total. 
 
    write print-record from print-line after advancing 1 lines. 
    move spaces				to 	print-line. 
    move "A/R ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 1   			to	ss-trans-type 
       perform kh2-grand-adj-print-setup 	thru	kh2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-grand-totals (1,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 2   			to	ss-trans-type 
       perform kh2-grand-adj-print-setup 	thru	kh2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-grand-totals (2,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move "  TOTAL"	  		to      l2-type 
       move 2                           to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform kh1-grand-print-setup 	thru	kh1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move grand-totals (2,2,11)	to	l2-agent-total 
 
       write print-record from print-line after advancing 1 lines 
       move spaces 			to      print-line 
    else 
       move 2                           to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform kh1-grand-print-setup 	thru	kh1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move grand-totals (2,2,11)	to	l2-agent-total 
 
       write print-record from print-line after advancing 1 lines 
       move spaces				to	print-line. 
*    endif 
    move "TOT A/R"			to 	l2-type. 
    move 2                           to      ss-oma-ohip. 
    move 3				to	ss-trans-type. 
    perform kh1-grand-print-setup 	thru	kh1-99-exit 
             varying ss-agent 
	     from 1	by 1 
	     until 	ss-agent > 10. 
    move grand-totals (2,3,11)	to	l2-agent-total. 
 
    write print-record from print-line after advancing 1 lines. 
    move spaces				to	print-line. 
    move "EFFECT ON REVENUE BY AGENT"	to	h9-head-msg. 
    write print-record from h9-head    after advancing 3 line. 
    write print-record from h10-head   after advancing 1 line. 
    move spaces				to	print-line. 
    move "REVENU"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 4				to	ss-trans-type. 
    perform kh1-grand-print-setup 	thru	kh1-99-exit 
             varying ss-agent 
	     from 1	by 1 
	     until 	ss-agent > 10. 
    move grand-totals (2,4,11)	 	to	l2-agent-total. 
 
    write print-record from print-line after advancing 1 lines. 
    move spaces				to	print-line. 
    move "REV ADJ"			to 	l2-type. 
 
* sms #97  split the a/r adjustments into manual and automatic if the 
*          user does not wnat to print the detail of adjustments. 
 
    if ws-print-auto = "N" 
    then 
       write print-record from print-line after advancing 1 line 
       move spaces			to	print-line 
       move "  MANUAL"                  to      l2-type 
       move 3   			to	ss-trans-type 
       perform kh2-grand-adj-print-setup 	thru	kh2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-grand-totals (1,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       move "  COMPUTE"                 to      l2-type 
       move 4   			to	ss-trans-type 
       perform kh2-grand-adj-print-setup 	thru	kh2-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move adj-grand-totals (2,11)	to	l2-agent-total 
       write print-record from print-line after advancing 1 line 
       move spaces         		to      print-line 
       write print-record from l5-print-line after advancing 1 line 
       move spaces 			to      print-line 
       move "  TOTAL" 	 		to      l2-type 
       move 2                           to      ss-oma-ohip 
       move 2				to	ss-trans-type 
       perform kh1-grand-print-setup 	thru	kh1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move grand-totals (2,2,11)	to	l2-agent-total 
 
       write print-record from print-line after advancing 1 lines 
       move spaces 			to      print-line 
    else 
       move 2                           to      ss-oma-ohip 
       move 5				to	ss-trans-type 
       perform kh1-grand-print-setup 	thru	kh1-99-exit 
               	varying ss-agent 
		from 1	by 1 
		until 	ss-agent > 10 
       move grand-totals (2,5,11)	to	l2-agent-total 
 
       write print-record from print-line after advancing 1 lines 
       move spaces			to	print-line. 
*  endif 
    move "TOT REV"			to 	l2-type. 
    move 2                              to      ss-oma-ohip. 
    move 6				to	ss-trans-type. 
    perform kh1-grand-print-setup 	thru	kh1-99-exit 
             varying ss-agent 
	     from 1	by 1 
	     until 	ss-agent > 10. 
    move grand-totals (2,6,11)		to	l2-agent-total. 
 
    write print-record from print-line after advancing 1 lines. 
    move spaces				to	print-line. 
 
kh0-99-exit. 
    exit. 
 
kh1-grand-print-setup. 
 
    move grand-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to 
                     l2-ohip-totals(ss-agent). 
    add grand-totals(ss-oma-ohip,ss-trans-type,ss-agent)    to 
        grand-totals(ss-oma-ohip,ss-trans-type,11). 
 
kh1-99-exit. 
    exit. 
 
kh2-grand-adj-print-setup. 
 
    move adj-grand-totals(ss-trans-type,ss-agent)    to 
                     l2-ohip-totals(ss-agent). 
    add adj-grand-totals(ss-trans-type,ss-agent)    to 
        adj-grand-totals(ss-trans-type,11). 
 
kh2-99-exit. 
    exit. 
la0-zero-to-dept-ttls. 
 
*   move 0				to	dept-totals (1,sub1). 
    move 0				to	dept-totals (2,sub1,1). 
    move 0				to	dept-totals (2,sub1,2). 
    move 0				to	dept-totals (2,sub1,3). 
    move 0				to	dept-totals (2,sub1,4). 
    move 0				to	dept-totals (2,sub1,5). 
    move 0				to	dept-totals (2,sub1,6). 
    move 0				to	dept-totals (2,sub1,7). 
    move 0				to	dept-totals (2,sub1,8). 
    move 0				to	dept-totals (2,sub1,9). 
    move 0				to	dept-totals (2,sub1,10). 
    move 0				to	dept-totals (2,sub1,11). 
 
la0-99-exit. 
    exit. 
 
 
lb0-zero-to-doc-ttls. 
 
*   move 0				to	doc-totals (1,sub1). 
    move 0				to	doc-totals (2,sub1,1). 
    move 0				to	doc-totals (2,sub1,2). 
    move 0				to	doc-totals (2,sub1,3). 
    move 0				to	doc-totals (2,sub1,4). 
    move 0				to	doc-totals (2,sub1,5). 
    move 0				to	doc-totals (2,sub1,6). 
    move 0				to	doc-totals (2,sub1,7). 
    move 0				to	doc-totals (2,sub1,8). 
    move 0				to	doc-totals (2,sub1,9). 
    move 0				to	doc-totals (2,sub1,10). 
    move 0				to	doc-totals (2,sub1,11). 
 
lb0-99-exit. 
    exit. 
 
 
lc0-zero-to-adj-dept-ttls. 
 
    move 0				to	adj-dept-totals (1,ss-agent). 
    move 0				to	adj-dept-totals (2,ss-agent). 
    move 0				to	adj-dept-totals (3,ss-agent). 
    move 0				to	adj-dept-totals (4,ss-agent). 
 
lc0-99-exit. 
    exit. 
 
 
ld0-zero-to-adj-doc-ttls. 
 
    move 0				to	adj-doc-totals (1,ss-agent). 
    move 0				to	adj-doc-totals (2,ss-agent). 
    move 0				to	adj-doc-totals (3,ss-agent). 
    move 0				to	adj-doc-totals (4,ss-agent). 
 
ld0-99-exit. 
    exit. 
 
 
le0-obtain-doc-agent-totals. 
 
    add doc-totals (sub1,1,ss-agent)	to	dept-totals (sub1,1,ss-agent) 
						doc-totals (sub1,3,ss-agent). 
    add doc-totals (sub1,2,ss-agent)	to	dept-totals (sub1,2,ss-agent) 
						doc-totals (sub1,3,ss-agent). 
    add doc-totals (sub1,4,ss-agent)	to	dept-totals (sub1,4,ss-agent) 
						doc-totals (sub1,6,ss-agent). 
    add doc-totals (sub1,5,ss-agent)	to	dept-totals (sub1,5,ss-agent) 
						doc-totals (sub1,6,ss-agent). 
le0-99-exit. 
    exit. 
 
 
lf0-obtain-dept-agent-totals. 
 
    add dept-totals (sub1,1,ss-agent)	to	grand-totals (sub1,1,ss-agent) 
						dept-totals (sub1,3,ss-agent). 
    add dept-totals (sub1,2,ss-agent)	to	grand-totals (sub1,2,ss-agent) 
						dept-totals (sub1,3,ss-agent). 
    add dept-totals (sub1,4,ss-agent)	to	grand-totals (sub1,4,ss-agent) 
						dept-totals (sub1,6,ss-agent). 
    add dept-totals (sub1,5,ss-agent)	to	grand-totals (sub1,5,ss-agent) 
						dept-totals (sub1,6,ss-agent). 
 
lf0-99-exit. 
    exit. 
 
lg0-obtain-grand-agent-totals. 
 
    compute grand-totals (2,3,ss-agent) = grand-totals (2,1,ss-agent) + 
				 grand-totals (2,2,ss-agent). 
    compute grand-totals (2,6,ss-agent) = grand-totals (2,4,ss-agent) + 
				 grand-totals (2,5,ss-agent). 
 
lg0-99-exit. 
    exit 
 
 
ki0-read-dept-mstr. 
 
    move wf-dept       			to dept-nbr. 
 
    read dept-mstr 
	invalid key 
	    move 16		        to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    move 'UNKNOWN DEPT'		to dept-name. 
 
 
ki0-99-exit. 
    exit. 
 
 
 
xa0-headings. 
 
    move ctr-pages			to	h1-page-nbr. 
    write print-record from h1-head after advancing page. 
    write print-record from h2-head after advancing 1 line. 
    write print-record from h3-head after advancing 1 line. 
    write print-record from h4-head after advancing 2 line. 
    write print-record from h5-head after advancing 1 line. 
    write print-record from blank-line after advancing 1 line. 
    move 7				to ctr-lines. 
    add 1				to	ctr-pages. 
 
xa0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
*   display err-msg-line. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
