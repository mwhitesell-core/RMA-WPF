identification  division. 
program-id.    r150a. 
author.        Dyad Infosys LTD.
installation.  rma. 
date-written.  82/02/01. 
date-compiled. 
security. 
 
* 
*   files	:  f020 - doctor master 
*		:  f060 - chq-reg master 
*		:  r150a - print file 
*		:  r150_work_file - doc work file 
* 
* 
*   program purpose :  this program is the first in a series of 3 
*		    :  programs whose purpose is produce the t4'S & 
*    		    :  t4 audit report.  this pgm produces a verification 
* 		       report and a work file which is sorted by r150b. 
* 
*   revision history: 
* 
*	may/82 (d.m.& i.w.)	- changed to access new doctor & cheque masters 
*				- work file renamed & doc.# expanded 
*				- program renamed r150a (was r022a) 
* 
*       may/87 (s.b.)           - coversion from aos to aos/vs. 
*                                 change field size for 
*                                 status clause to 2 and 
*                                 feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised jan/96:    - pdr 640 
*		       - allow negative values for earnings and tax 
*
*   revised feb/98 j. chau  - s146 unix conversion
*   2003/dec/10	M.C.	- alpha doc nbr

environment   division. 
input-output  section. 
file-control. 
* 
* 
	copy "f020_doctor_mstr.slr". 
* 
	 
	copy "f060_cheque_reg_mstr.slr". 
 
	select  doc-work-mstr 
	        assign to work-file-name 
		organization sequential 
		status is status-cobol-work-mstr. 
*mf		infos status is status-work-mstr. 
 
	select print-file 
	    assign to printer print-file-name 
	    file status is status-prt-file. 
data  division. 
file  section. 
* 
* 
    copy "f020_doctor_mstr.fd". 
* 
* 
    copy "f060_cheque_reg_mstr.fd". 
* 
* 
    copy "r150_chq_doc_mstr.fd". 
* 
 
    fd  print-file 
	record contains 132 characters. 
 
    01  print-record				pic x(132). 
working-storage section. 
 
77  print-file-name				pic x(5)   value "r150a". 
77  max-nbr-lines				pic 99		value 60. 
77  ctr-lines					pic 9(3) 	value zero. 
77  nbr-lines-to-advance			pic 9 		value zero. 
77  ctr-page					pic 999 	value zero. 
*  flag indicators 
77  eof-chq-mstr				pic x    	value "N". 
 
* status file indic 
*mf 77  common-status-file			pic x(11)  	value zero. 
*mf 77  status-doc-mstr				pic x(11)  	value zero. 
*mf 77  status-work-mstr			pic x(11)  	value zero. 
*mf 77  status-chq-reg-mstr			pic x(11)  	value zero. 
 
77  common-status-file				pic xx  	value zero. 
77  status-cobol-doc-mstr			pic xx  	value zero. 
77  status-cobol-work-mstr			pic xx  	value zero. 
77  status-cobol-chq-reg-mstr			pic xx     	value zero. 
77  status-prt-file 				pic xx     	value zero. 

01  last-page-flag 				pic x. 
 
    88  last-page				value "Y". 
    88  not-last-page				value "N". 
 
*  counters 
01  counters. 
    05  ctr-doc-mstr-reads			pic 9(7). 
    05  ctr-chq-reg-reads			pic 9(7). 
    05  ctr-wk-file-writes			pic 9(7). 
 
77  hold-clinic-nbr				pic 99. 
77  hold-dept-nbr				pic 99.     
 
*  variables 
77  ss						pic 99. 
77  feedback-cheque-reg-mstr			pic x(4). 
77  err-ind					pic 99	  	value zero. 
77  ws-reply					pic x. 
77  ws-perc-tax					pic 9(5)v99  	value zero. 
77  valid-doc-nbr				pic x     	value "Y". 
 
* totals 
01  totals. 
    05  doc-tot-earn				pic s9(6)v99. 
    05  doc-tot-tax 				pic s9(5)v99. 
    05  dept-tot-earn				pic s9(7)v99. 
    05  dept-tot-tax 				pic s9(7)v99. 
    05  clinic-tot-earn				pic s9(8)v99. 
    05  clinic-tot-tax 				pic s9(7)v99. 
    05  final-tot-earn				pic s9(9)v99. 
    05  final-tot-tax 				pic s9(8)v99. 
 
01  work-file-name. 
    05  filler					pic x(14)    value 
		"r150_work_file". 
 
copy "sysdatetime.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)     value 
		"INVALID CLINIC IDENTIFIER". 
	10  doc-miss-err. 
	    15  filler				pic x(43)      value 
		"DOCTOR NOT FOUND IN DOC-MSTR - DOC NBR = ". 
	    15  err-doc-nbr			pic zz9.  
	    15  filler				pic x(14). 
	10  filler				pic x(60)     value 
		"INVALID READ ON CHEQUE-REG-MSTR". 
	10  filler				pic x(60)     value 
		"INVALID ENTRY".          
	10  filler				pic x(60)     value 
		"ERR MESS # 5 GOES HERE". 
 
    05  error-messages-r  redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 5 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)     value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
01  head-audit-1. 
    05  filler					pic x(6)	value "R150A". 
    05  filler					pic x		value "/". 
    05  h1-clinic-nbr				pic 99. 
    05  filler					pic x(35)	value spaces. 
    05  filler					pic x(52)	value "T4  VERIFICATION REPORT". 
    05  filler					pic x(12)	value "RUN  DATE   ". 
    05  head-aud-date. 
	10  head-aud-yy				pic 99. 
        10  filler        			pic x		value "/". 
	10  head-aud-mm				pic 99. 
	10  filler          			pic x		value "/". 
	10  head-aud-dd				pic 99bbbbb.  
    05  filler					pic x(5)	value "PAGE ". 
    05  h1-page      				pic zzz9. 
 
 
01  head-audit-2. 
    05  filler					pic x(8)	value "CLINIC". 
    05  h2-clinic-nbr				pic 99 		blank when zero. 
    05  filler					pic x(19)	value spaces. 
    05  filler					pic x(24)	value "DOCTOR". 
    05  filler					pic x(25)	value "DOCTOR". 
    05  filler					pic x(14)	value "TOTAL".  
    05  filler					pic x(40)	value "INCOME TAX". 
 
 
01  head-audit-3. 
    05  filler					pic x(31)	value spaces. 
    05  filler					pic x(23)	value "#". 
    05  filler					pic x(23)	value "NAME". 
    05  filler					pic x(16)	value "EARNINGS". 
    05  filler					pic x(39)	value "DEDUCTED". 
 
01  print-line. 
 
 03  d1-detail-line. 
 
    05  filler					pic x(30). 
*   05  d1-doc-nbr				pic zz9. 
*!    05  d1-doc-nbr				pic 999. 
    05  d1-doc-nbr				pic xxx. 
    05  filler					pic x(16). 
    05  d1-doc-init				pic xxx. 
    05  filler					pic x. 
    05  d1-doc-name				pic x(16).  
    05  filler					pic x(7). 
    05  d1-earn					pic zzz,zz9.99-. 
    05  filler					pic x(6). 
    05  d1-tax					pic zz,zz9.99-. 
    05  filler					pic x(29). 
 
 
 03  t1-total-line redefines d1-detail-line. 
 
    05  filler					pic x(10). 
    05  t1-msg-1    				pic x(7). 
    05  t1-nbr					pic z9. 
    05  filler					pic x(2). 
    05  t1-msg-2				pic x(5). 
    05  filler					pic x(46). 
    05  t1-earn					pic zzz,zzz,zz9.99bb. 
    05  t1-tax					pic zz,zzz,zz9.99b. 
    05  t1-stars				pic x(30). 
 
screen  section. 
 
01  scr-title. 
    05                  blank screen. 
    05                  line 01 col 01  value is "R150A". 
    05  		line 01 col 25  value is "T4 AND AUDIT STATEMENTS REPORT". 
    05			line 01 col 73 pic 99 from run-yy. 
    05			line 01 col 75 value "/". 
    05			line 01 col 76 pic 99 from run-mm. 
    05			line 01 col 78 value "/". 
    05			line 01 col 79 pic 99 from run-dd. 
    05  		line 10 col 25  value is "PART 1 - WORK FILE CREATION". 
 
01  msg-continue. 
    05                  line 12 col 25  value is "CONTINUE (Y/N)".    
    05   reply          line 12 col 55  pic x  using  ws-reply auto required. 
 
01  program-in-progress. 
    05                  line 14 col 35  value is "PROGRAM R150A IN PROGRESS". 
 
01  confirm. 
    05                  line 23 col 01  value is " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  file-status-display. 
    05 	line 24 col 56  value is "FILE STATUS = ". 
*mf  05	line 24 col 70  pic x(11)  using common-status-file  bell blink. 
    05	line 24 col 70  pic x(2)  using common-status-file  bell blink. 
 
01  err-msg-line. 
    05			line 24 col 01  value is " ERROR - "  bell blink. 
    05			line 24 col 11  pic x(60)  from err-msg-comment. 
 
 
01  blank-line-24. 
    05			line 24 col 01  blank line. 
 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  		line 08 col 20  value is "NUMBER OF CHQ-REG-MSTR READS =".   
    05			line 08 col 60  pic z(6)9  from ctr-chq-reg-reads. 
    05  		line 10 col 20  value is "NUMBER OF DOCTOR MSTR READS  =". 
    05 			line 10 col 60  pic z(6)9  from ctr-doc-mstr-reads. 
    05			line 12 col 20	value is "NUMBER OF WORK-FILE WRITES   =". 
    05			line 12 col 60	pic z(6)9  from ctr-wk-file-writes. 
    05			line 18 col 20  value is "REPORT FOUND IN - ". 
    05			line 18 col 39 pic x(5) from print-file-name. 
    05			line 20 col 20  value is "RUN R150B AND R150C TO PRODUCE T4 AND AUDIT REPORT". 
    05			line 21 col 20  value is "PROGRAM R150A ENDING". 
    05			line 21 col 41  pic 99    from sys-yy. 
    05			line 21 col 43  value is "/". 
    05			line 21 col 44  pic 99    from sys-mm. 
    05			line 21 col 46  value is "/". 
    05			line 21 col 47  pic 99    from sys-dd. 
    05			line 21 col 51  pic z9    from sys-hrs. 
    05			line 21 col 53  value is ":". 
    05			line 21 col 54  pic 99    from sys-min. 
procedure  division. 
declaratives. 
 
err-work-mstr-file section. 
    use after standard error procedure on doc-work-mstr. 
 
err-work-mstr. 
*mf    move status-work-mstr			to	common-status-file. 
    move status-cobol-work-mstr			to	common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING WORK MSTR". 
    stop run. 
 
 
err-chq-reg-mstr-file section. 
    use after standard error procedure on cheque-reg-mstr. 
 
err-chq-reg-mstr. 
*mf    move status-chq-reg-mstr			to	common-status-file. 
    move status-cobol-chq-reg-mstr		to	common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CHEQUE REGISTER MASTER". 
    stop run.   
 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
 
err-doc-mstr. 
*mf    move status-doc-mstr			to	common-status-file. 
    move status-cobol-doc-mstr			to	common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
    stop run. 
 
end declaratives. 
main-line section. 
mainline. 
 
     perform aa0-initialization		thru	aa0-99-exit. 
     perform ab0-processing       thru	ab0-99-exit 
					until eof-chq-mstr = "Y". 
     perform az0-end-of-job		thru	az0-99-exit. 
     stop run. 
 
aa0-initialization. 
 
    accept  sys-date			from	date. 
    accept  sys-time			from	time. 
    move sys-yy				to	run-yy. 
    move sys-mm				to	run-mm. 
    move sys-dd				to	run-dd. 
 
 
    display scr-title. 
    display msg-continue. 
     
aa10-continue. 
    accept reply.        
 
    if    ws-reply not = "Y"        
      and ws-reply not = "N" 
    then 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa10-continue. 
*   (else) 
*   endif 
 
 
    if ws-reply   = "Y" 
    then 
	display program-in-progress 
    else 
	go to az0-end-of-job.         
*   endif 
 
*    expunge  doc-work-mstr  
*mf	     print-file. 
 
    move zero				to	totals   
						counters. 
 
    open input   doc-mstr 
		 cheque-reg-mstr.   
 
    open output  doc-work-mstr 
		 print-file. 
 
    move sys-yy				to	head-aud-yy. 
    move sys-mm				to	head-aud-mm. 
    move sys-dd				to	head-aud-dd. 
 
    move "N"				to	last-page-flag. 
    move 98				to	ctr-lines. 
    move zero				to	ctr-page 
						nbr-lines-to-advance. 
    move spaces				to	print-line. 
 
 
aa10-read-chq-reg. 
   
    move  zero				to	chq-reg-key. 
 
*mf    read  cheque-reg-mstr   key is  chq-reg-key  approximate 
*mf	   invalid key 
*mf		move  2			to	err-ind 
*mf		perform za0-common-error 
*mf					thru	za0-99-exit 
*mf		go to az0-end-of-job. 
 
    start cheque-reg-mstr   key is greater than or equal to chq-reg-key 
	   invalid key 
		move  2			to	err-ind 
		perform za0-common-error 
					thru	za0-99-exit 
		go to az0-end-of-job. 
    read  cheque-reg-mstr next.


    add 1				to	ctr-chq-reg-reads. 
 
    move chq-reg-clinic-nbr-1-2		to	hold-clinic-nbr. 
    move chq-reg-dept			to	hold-dept-nbr. 
 
aa0-99-exit. 
   exit. 
 
ab0-processing. 
 
    if chq-reg-clinic-nbr-1-2 not = hold-clinic-nbr 
    then 
	perform ca0-prt-dept-tots-and-roll 
					thru	ca0-99-exit 
	perform da0-prt-clinic-tots-and-roll 
					thru	da0-99-exit 
	move chq-reg-clinic-nbr-1-2	to	hold-clinic-nbr 
	move chq-reg-dept		to	hold-dept-nbr. 
*   (else) 
*   endif 
 
    if chq-reg-dept not = hold-dept-nbr 
    then 
	perform ca0-prt-dept-tots-and-roll 
					thru	ca0-99-exit 
	move chq-reg-dept		to	hold-dept-nbr. 
*   (else) 
*   endif 
 
    move zero				to	doc-tot-earn 
						doc-tot-tax. 
 
    perform bd0-add-mthly-earn-and-tax	thru	bd0-99-exit 
	varying ss  from 1 by 1 
	until   ss > 12. 
 
    if     doc-tot-earn = zero 
      and  doc-tot-tax  = zero 
    then 
	go to ab0-10-read-chq-reg. 
*   (else) 
*   endif 
 
    perform bb0-read-doc-mstr		thru	bb0-99-exit. 
 
    perform bf0-move-wk-file		thru	bf0-99-exit. 
    perform bg0-write-wk-file		thru	bg0-99-exit. 
 
    perform ea0-write-report-line	thru	ea0-99-exit. 
 
    perform ea1-add-to-dept-tots	thru	ea1-99-exit. 
 
ab0-10-read-chq-reg. 
 
    perform bc0-read-chq-reg-next	thru	bc0-99-exit. 
 
ab0-99-exit. 
   exit. 
 
bb0-read-doc-mstr. 
 
    move "Y"				to	valid-doc-nbr. 
    move chq-reg-doc-nbr		to	doc-nbr. 
 
    read  doc-mstr 
	  invalid key 
		move "N"		to	valid-doc-nbr  
		move  2			to	err-ind 
		move chq-reg-doc-nbr	to	err-doc-nbr 
		perform za0-common-error 
					thru	za0-99-exit 
		go to bb0-99-exit. 
 
    add 1				to	ctr-doc-mstr-reads. 
 
bb0-99-exit. 
    exit. 
 
 
 
bc0-read-chq-reg-next. 
 
    read cheque-reg-mstr next 
	     at end 
		move "Y"		to	eof-chq-mstr       
		go to bc0-99-exit. 
 
    add 1				to	ctr-chq-reg-reads. 
 
bc0-99-exit. 
   exit. 
bd0-add-mthly-earn-and-tax. 
 
    add chq-reg-regular-pay-this-mth (ss) 
        chq-reg-man-pay-this-mth     (ss)	to	doc-tot-earn. 
 
    add chq-reg-regular-tax-this-mth (ss) 
        chq-reg-man-tax-this-mth     (ss)	to	doc-tot-tax. 
 
bd0-99-exit. 
   exit. 
bf0-move-wk-file. 
 
    if valid-doc-nbr = "N" 
    then 
	move spaces			to	wk-doc-inits-1 
						wk-doc-inits-2   
						wk-doc-inits-3 
						wk-doc-name 
						wk-sin 
    else 
	move doc-name			to	wk-doc-name 
        move doc-init1			to	wk-doc-inits-1 
        move doc-init2			to	wk-doc-inits-2    
        move doc-init3			to	wk-doc-inits-3   
	move doc-sin-nbr		to	wk-sin. 
*   endif 
 
    move  chq-reg-doc-nbr	        to	wk-doc-nbr. 
    move  chq-reg-clinic-nbr-1-2	to	wk-doc-clinic-nbr. 
    move  doc-tot-tax			to	wk-doc-tax-ded.   
    move  doc-tot-earn			to	wk-doc-earnings. 
 
bf0-99-exit. 
  exit. 
 
 
bg0-write-wk-file. 
 
    write doc-work-rec. 
    add 1				to	ctr-wk-file-writes. 
 
bg0-99-exit. 
   exit. 
 
ca0-prt-dept-tots-and-roll. 
 
    move "DEPT"				to	t1-msg-1. 
    move hold-dept-nbr			to	t1-nbr. 
    move "TOTAL"			to	t1-msg-2. 
    move dept-tot-earn			to	t1-earn. 
    move dept-tot-tax			to	t1-tax. 
    move "*"				to	t1-stars. 
 
    move 2				to	nbr-lines-to-advance. 
 
    perform fa0-print-line		thru	fa0-99-exit. 
 
    add dept-tot-earn			to	clinic-tot-earn. 
    add dept-tot-tax			to	clinic-tot-tax. 
 
    move zero				to	dept-tot-earn 
						dept-tot-tax. 
    move 98				to	ctr-lines. 
 
ca0-99-exit. 
    exit. 
da0-prt-clinic-tots-and-roll. 
 
    move "CLINIC"			to	t1-msg-1. 
    move hold-clinic-nbr		to	t1-nbr. 
    move "TOTAL"			to	t1-msg-2. 
    move clinic-tot-earn		to	t1-earn. 
    move clinic-tot-tax			to	t1-tax. 
    move "**"				to	t1-stars. 
 
    move 3				to	nbr-lines-to-advance. 
 
    perform fa0-print-line		thru	fa0-99-exit. 
 
    add clinic-tot-earn			to	final-tot-earn. 
    add clinic-tot-tax			to	final-tot-tax. 
 
    move zero				to	clinic-tot-earn 
						clinic-tot-tax. 
    move 98				to	ctr-lines. 
 
da0-99-exit. 
    exit. 
da1-prt-final-tots. 
 
    move "FINAL"			to	t1-msg-1. 
    move "TOTAL"			to	t1-msg-2. 
    move final-tot-earn			to	t1-earn. 
    move final-tot-tax			to	t1-tax. 
    move "***"				to	t1-stars. 
 
    move 4				to	nbr-lines-to-advance. 
 
    perform fa0-print-line		thru	fa0-99-exit. 
 
da1-99-exit. 
    exit. 
ea0-write-report-line. 
 
    move chq-reg-doc-nbr		to	d1-doc-nbr. 
 
    if valid-doc-nbr = "N" 
    then 
	move "***"			to	d1-doc-init 
	move "DOCTOR UNKNOWN"		to	d1-doc-name 
    else 
	move doc-inits			to	d1-doc-init 
	move doc-name			to	d1-doc-name.        
*   (else) 
*   endif 
 
    move doc-tot-tax			to	d1-tax. 
 
*   (for the purposes of the report net earnings are added 
*    to tax to obtain gross earnings.) 
 
    add doc-tot-earn, doc-tot-tax       giving	d1-earn. 
 
    perform fa0-print-line		thru	fa0-99-exit. 
 
ea0-99-exit. 
    exit. 
ea1-add-to-dept-tots. 
 
    add doc-tot-tax			to	dept-tot-tax. 
 
*   (for the purposes of the report net earnings are added to 
*    tax to obtain gross earnings.) 
 
    add doc-tot-earn			to	dept-tot-earn. 
    add doc-tot-tax			to	dept-tot-earn. 
 
ea1-99-exit. 
    exit. 
fa0-print-line. 
 
    add nbr-lines-to-advance		to	ctr-lines. 
 
    if ctr-lines > max-nbr-lines 
    then 
	perform fa1-print-headings	thru	fa1-99-exit. 
*   (else) 
*   endif 
 
    write print-record from print-line after advancing nbr-lines-to-advance. 
    move 1				to	nbr-lines-to-advance. 
    move spaces				to	print-line. 
 
fa0-99-exit. 
    exit. 
 
fa1-print-headings. 
 
    add 1				to	ctr-page. 
    move ctr-page			to	h1-page. 
 
    write print-record from head-audit-1 after advancing page. 
 
    if not-last-page 
    then 
	move hold-clinic-nbr		to	h1-clinic-nbr  
						h2-clinic-nbr. 
*   (else) 
*   endif 
 
    write print-record from head-audit-2 after advancing 2 lines. 
 
    write print-record from head-audit-3 after advancing 1 line. 
 
    move 5				to	ctr-lines.  
    move 2				to	nbr-lines-to-advance. 
 
fa1-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
   exit. 
 
 
az0-end-of-job. 
 
    perform ca0-prt-dept-tots-and-roll	thru	ca0-99-exit. 
 
    perform da0-prt-clinic-tots-and-roll 
					thru	da0-99-exit. 
 
    move "Y"				to	last-page-flag. 
    move 98				to	ctr-lines. 
*mf    move spaces				to	h2-clinic-nbr. 
    move zero				to	h2-clinic-nbr. 
 
    perform da1-prt-final-tots		thru	da1-99-exit. 
 
    close   cheque-reg-mstr 
	    doc-mstr 
	    print-file 
	    doc-work-mstr. 
 
    accept sys-time			from 	time. 
    display scr-closing-screen. 
    display confirm. 
    stop run. 
 
az0-99-exit. 
  exit. 
 
 
