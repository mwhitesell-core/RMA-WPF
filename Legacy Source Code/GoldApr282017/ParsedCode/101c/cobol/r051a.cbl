identification division. 
program-id. r051a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 82/11/29.    
date-compiled. 
security. 
* 
*    files	: f050 - doctor revenue master 
*		: f090 - constants master file 
*		: f020 - doctor master 
*		: r051wk - work file 
*		: parameter file 
* 
*    program purpose : this program (r051a) is the first of 3 programs 
*		       to produce 2 productivity analysis reports. 
* 
*		       this program creates a work file which is 
*		       then sorted by r051b for one of two reports 
*		       created by r051c.  the first is by --doctor-- (r051ca) 
*		       and the second is by --department-- (r051cb). 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*        mar/88 (j.l.)   - recompile program for the change in f050,f051 
*			   doc rev mtd field changed to s9(6)v99 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised feb/98 j. chau  : - s149 unix conversion
*
*  1999/jan/31 B.E.		- y2k
*
*  2003/dec/10 M.C.	- alpha doc nbr
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f050_doc_revenue_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "r051_docrev_work_mstr.slr". 
* 
    copy "r051_parm_file.slr". 
* 
data division. 
file section. 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f050_doc_revenue_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "r051_docrev_work_mstr.fd". 
* 
    copy "r051_parm_file.fd". 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  sel-clinic-nbr				pic 99. 
77  hold-dept					pic 99. 
77  hold-class-code				pic x. 
*!77  hold-doc-nbr				pic 999. 
77  hold-doc-nbr				pic xxx. 
77  parm-rec-nbr				pic 9. 
77  ws-file-err-msg				pic x(42) value spaces. 
77  ws-max-nbr-classes				pic 99	value 15. 
77  ws-max-nbr-dept				pic 99	value 99. 
77  reply					pic x. 
77  end-job					pic x   value "N". 
* 
*  eof flags 
* 
77  eof-docrev-mstr				pic x   value "N". 
* 
*  subscripts 
* 
77  ss						pic 99	comp. 
77  subs					pic 999	comp. 
77  subs-class-code				pic 99	comp. 
* 
*  feedback values for all indexed files 
* 
77  feedback-docrev-mstr			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-common				pic x(11). 
*mf 77  status-docrev-mstr			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 
*mf 77  status-doc-mstr				pic x(11) value zero. 
*mf 77  status-parm-file			pic x(11) value zero. 

77  common-status-file				pic xx. 
77  status-common				pic xx. 
77  status-cobol-iconst-mstr			pic xx    value zero. 
77  status-cobol-doc-mstr			pic xx    value zero. 
77  status-cobol-docrev-mstr			pic xx    value zero.
77  status-cobol-parm-file			pic xx    value zero. 
77  status-prt-file				pic xx    value zero. 
 
* 
*  keys (and/or record layouts) for all indexed files 
* 
 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-read-docrev-mstr			pic 9(7). 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-end-docrev				pic x. 
    88 flag-end-docrev-y			value "Y". 
    88 flag-end-docrev-n			value "N". 
 
01  ws-date. 
* (y2k)
*   05  ws-yy					pic 99. 
    05  ws-yy					pic 9(4). 
    05  ws-mm					pic 99.    
    05  ws-dd					pic 99. 
 
01  total-clinic-dept-doc. 
 
    05  total-mtd-ytd occurs 2 times. 
	10  total-clinic-svc			pic s9(8). 
	10  total-dept-svc			pic s9(8). 
	10  total-doc-nbr-svc			pic s9(8). 
	10  total-clinic-amt			pic s9(9)v99. 
	10  total-dept-amt			pic s9(9)v99. 
	10  total-doc-nbr-amt			pic s9(9)v99. 
 
copy "sysdatetime.ws". 
 
01  ws-hold-class-totals. 
 
	10  ws-class-tbl occurs 15 times. 
	    15  ws-hold-class-code		pic x. 
	    15  ws-data. 
		20  ws-month-to-date. 
		    25  ws-mtd-svcs		pic s9(8). 
		    25  ws-mtd-amt		pic s9(9)v99. 
		20  ws-year-to-date. 
		    25  ws-ytd-svcs		pic s9(8). 
		    25  ws-ytd-amt		pic s9(9)v99. 
01  error-message-table. 
 
    05  error-messages. 
* msg #1 
	10  filler				pic x(50)   value 
		"INVALID REPLY". 
	10  filler				pic x(50)   value 
		"WRITING TO PARAMETER FILE". 
	10  filler				pic x(50)   value 
		"CLINIC NOT FOUND ON CONSTANTS MASTER". 
	10  filler				pic x(50)   value 
		"NO DOCREV RECORDS SUPPLIED". 
	10  filler				pic x(50)   value 
		"TOO MANY DEPARTMENTS FOUND". 
	10  filler				pic x(50)   value 
		"TOO MANY CLASS CODES FOUND". 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(50) 
			occurs 6 times.   
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 

procedure division. 
declaratives. 
 
err-docrev-mstr-file section. 
    use after standard error procedure on docrev-mstr.       
err-docrev-mstr. 
*mf    move status-docrev-mstr		to status-common. 
    move status-cobol-docrev-mstr	to status-common. 
*   display file-status-display. 
    display status-common. 
    stop "ERROR IN ACCESSING DOCREV MASTER". 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
*mf    move status-doc-mstr		to status-common. 
    move status-cobol-doc-mstr		to status-common. 
*   display file-status-display. 
    display status-common. 
    stop "ERROR IN ACCESSING DOC MASTER". 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
*mf    move status-iconst-mstr		to status-common. 
    move status-cobol-iconst-mstr	to status-common. 
*   display file-status-display. 
    display status-common. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
 
err-parm-mstr-file section. 
    use after standard error procedure on parameter-file. 
err-parm-file. 
*mf    move status-parm-file		to status-common. 
    move status-cobol-parm-file		to status-common. 
*   display file-status-display. 
    display status-common. 
    stop "ERROR IN ACCESSING PARAMETER FILE". 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit  
	until flag-end-docrev-y. 
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
 
*   display scr-title. 
*   display scr-clinic. 
 
    open input	iconst-mstr 
		doc-mstr 
		docrev-mstr. 
 
    open i-o	parameter-file. 
 
    perform aa1-acpt-clinic-nbr		thru aa1-99-exit. 
 
*   display scr-continue. 
 
aa0-10-acpt-continue. 
 
*   accept scr-continue. 
    accept reply 
 
    if   reply = 'Y' 
      or reply = 'N' 
    then 
	if reply = 'Y' 
	then 
	    next sentence 
	else 
	    go to az0-end-of-job 
*	endif 
    else 
	move 1				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to aa0-10-acpt-continue. 
*   endif 
 
*   display scr-dis-r051a-in-prog. 
 
*    expunge r051-work-file. 
 
    open output r051-work-file. 
 
    move zero				to counters 
					   docrev-key 
					   total-clinic-dept-doc  
					   ws-hold-class-totals 
					   hold-dept 
					   hold-doc-nbr. 
 
    move zero				to hold-class-code. 
 
    move 1				to subs-class-code. 
 
    move 'N'				to flag-end-docrev. 
    move sel-clinic-nbr			to docrev-clinic-1-2. 

* 99/11/17 - add a read to parameter file
*---------------------------------------------------------------- 
    move 1				to parm-rec-nbr. 
    read  parameter-file 
	invalid key 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit. 
 
*---------------------------------------------------------------- 

    perform aa2-read-docrev-approx	thru aa2-99-exit. 
 
    if flag-end-docrev-y 
    then 
	move 4				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to az0-10-end-of-job 
    else 
	move docrev-dept		to hold-dept 
	perform xe0-clear-wk-file-rec	thru xe0-99-exit 
	perform ha1-get-class-code	thru ha1-99-exit 
	move wf-class-code		to hold-class-code 
					   ws-hold-class-code(subs-class-code) 
	move docrev-doc-nbr		to hold-doc-nbr. 
*   endif 
 
aa0-99-exit. 
    exit. 
 
 
 
aa1-acpt-clinic-nbr. 
 
*   accept scr-clinic-nbr. 
    accept sel-clinic-nbr 
 
    move sel-clinic-nbr			to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 3			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    move zero			to sel-clinic-nbr 
*	    display scr-clinic-nbr 
	    go to aa1-acpt-clinic-nbr. 
 
aa1-99-exit. 
    exit. 
 
 
 
aa2-read-docrev-approx. 
 
*mf    read docrev-mstr key is docrev-key approximate 
*mf	invalid key 
*mf	    move 'Y'			to flag-end-docrev 
*mf	    go to aa2-99-exit. 
 
    start docrev-mstr key is greater than or equal to docrev-key
	invalid key 
	    move 'Y'			to flag-end-docrev 
	    go to aa2-99-exit. 
    read docrev-mstr next.

    if docrev-clinic-1-2 not = sel-clinic-nbr 
    then 
	move 'Y'			to flag-end-docrev 
	go to aa2-99-exit. 
*   (else) 
*   endif 
 
    add 1				to ctr-read-docrev-mstr. 
 
aa2-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform da0-write-doc-total		thru da0-99-exit. 
    perform la0-write-class-totals	thru la0-99-exit 
	varying subs-class-code from 1 by 1 
	until   subs-class-code > ws-max-nbr-classes 
	     or ws-hold-class-code(subs-class-code) = zero. 
    perform ba0-write-dept-total	thru ba0-99-exit. 
    perform az1-write-clinic-total-to-wk 
					thru az1-99-exit. 
 
    perform az3-create-parm-file	thru az3-99-exit. 
 
az0-10-end-of-job. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
*   display confirm. 
 
    close docrev-mstr 
	  doc-mstr 
	  r051-work-file 
	  parameter-file. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
 
az1-write-clinic-total-to-wk. 
 
    perform xe0-clear-wk-file-rec	thru xe0-99-exit. 
 
    move zero				to wf-dept 
					   wf-class-code 
					   wf-doc-nbr 
					   wf-oma-cd. 
 
    move total-clinic-svc(1)		to wf-mtd-svcs. 
    move total-clinic-svc(2)		to wf-ytd-svcs. 
    move total-clinic-amt(1)		to wf-mtd-amt. 
    move total-clinic-amt(2)		to wf-ytd-amt. 
 
    perform xa0-write-wk-rec		thru xa0-99-exit. 
 
az1-99-exit. 
    exit. 
 
 
 
az3-create-parm-file. 
 
    move "r051a"			to parm-program-nbr. 
    move zero				to parm-status. 
    move sel-clinic-nbr			to parm-clinic-nbr. 
    move iconst-clinic-name		to parm-clinic-name. 
    move iconst-date-period-end		to parm-ped. 

* 99/11/17 - replace write with rewrite
 
*   move 1				to parm-rec-nbr. 
*   write parm-file-rec 
    rewrite parm-file-rec 
	invalid key 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit. 
 
az3-99-exit. 
    exit. 
 
 
 
la0-write-class-totals. 
 
    perform xe0-clear-wk-file-rec	thru xe0-99-exit. 
 
    move hold-dept			to wf-dept. 
 
    move ws-hold-class-code(subs-class-code) 
					to wf-class-code. 
    move zero				to wf-doc-nbr 
					   wf-oma-cd. 
 
    move ws-mtd-svcs(subs-class-code)	to wf-mtd-svcs. 
 
    move ws-ytd-svcs(subs-class-code)	to wf-ytd-svcs. 
 
    move ws-mtd-amt(subs-class-code)	to wf-mtd-amt. 
 
    move ws-ytd-amt(subs-class-code)	to wf-ytd-amt. 
 
    perform xa0-write-wk-rec		thru xa0-99-exit. 
 
la0-99-exit. 
    exit. 
ab0-processing. 
 
    if hold-dept not = docrev-dept 
    then 
	perform da0-write-doc-total	thru da0-99-exit 
	perform la0-write-class-totals	thru la0-99-exit 
		varying subs-class-code from 1 by 1 
		until   subs-class-code > ws-max-nbr-classes 
		     or ws-hold-class-code(subs-class-code) = zero 
	perform ba0-write-dept-total	thru ba0-99-exit 
	move zero			to ws-hold-class-totals 
	perform xe0-clear-wk-file-rec	thru xe0-99-exit 
	perform ha1-get-class-code	thru ha1-99-exit 
	perform ja0-set-up-class-tbl	thru ja0-99-exit 
	go to ab0-10-process-rec. 
*   (else) 
*   endif 
 
    if hold-doc-nbr not = docrev-doc-nbr 
    then 
	perform da0-write-doc-total	thru da0-99-exit 
	perform xe0-clear-wk-file-rec	thru xe0-99-exit 
	perform ha1-get-class-code	thru ha1-99-exit 
	perform ja0-set-up-class-tbl	thru ja0-99-exit. 
*   (else) 
*   endif 
 
ab0-10-process-rec. 
 
    perform fa0-add-to-totals		thru fa0-99-exit. 
 
    perform ha0-move-docrev-data-to-wk	thru ha0-99-exit. 
 
    perform xa0-write-wk-rec		thru xa0-99-exit. 
 
    move docrev-dept			to hold-dept. 
    move wf-class-code			to hold-class-code. 
    move docrev-doc-nbr			to hold-doc-nbr. 
 
    perform xc0-read-next-docrev	thru xc0-99-exit. 
 
ab0-99-exit. 
    exit. 
ba0-write-dept-total. 
 
    perform xe0-clear-wk-file-rec	thru xe0-99-exit. 
    perform ba1-move-dept-data-to-wk-rec 
					thru ba1-99-exit. 
    perform xa0-write-wk-rec		thru xa0-99-exit. 
    move zero				to total-dept-svc(1) 
				 	   total-dept-svc(2) 
					   total-dept-amt(1) 
				 	   total-dept-amt(2). 
 
ba0-99-exit. 
   exit. 
 
 
 
ba1-move-dept-data-to-wk-rec. 
 
    perform xe0-clear-wk-file-rec	thru xe0-99-exit. 
 
    move hold-dept			to wf-dept. 
    move zero				to wf-doc-nbr 
					   wf-class-code 
					   wf-oma-cd. 
 
    move total-dept-svc(1)		to wf-mtd-svcs. 
    move total-dept-svc(2)		to wf-ytd-svcs. 
    move total-dept-amt(1)		to wf-mtd-amt. 
    move total-dept-amt(2)		to wf-ytd-amt. 
 
ba1-99-exit. 
    exit. 
da0-write-doc-total. 
 
    perform da1-move-doc-data-to-wk-rec 
					thru da1-99-exit. 
    perform xa0-write-wk-rec		thru xa0-99-exit. 
    move zero				to total-doc-nbr-svc(1) 
				 	   total-doc-nbr-svc(2) 
					   total-doc-nbr-amt(1) 
				 	   total-doc-nbr-amt(2). 
 
da0-99-exit. 
    exit. 
 
 
da1-move-doc-data-to-wk-rec. 
 
    perform xe0-clear-wk-file-rec	thru xe0-99-exit. 
 
    move hold-dept			to wf-dept. 
    move hold-class-code		to wf-class-code. 
    move hold-doc-nbr			to wf-doc-nbr. 
    move zero				to wf-oma-cd. 
 
    move total-doc-nbr-svc(1)		to wf-mtd-svcs. 
    move total-doc-nbr-svc(2)		to wf-ytd-svcs. 
    move total-doc-nbr-amt(1)		to wf-mtd-amt. 
    move total-doc-nbr-amt(2)		to wf-ytd-amt. 
 
da1-99-exit. 
    exit. 
fa0-add-to-totals. 
 
    add docrev-mtd-in-svc		to total-clinic-svc(1) 
					   total-dept-svc(1) 
					   total-doc-nbr-svc(1) 
					   ws-mtd-svcs(subs-class-code). 
 
    add docrev-mtd-out-svc		to total-clinic-svc(1) 
					   total-dept-svc(1) 
					   total-doc-nbr-svc(1) 
					   ws-mtd-svcs(subs-class-code). 
 
    add docrev-ytd-in-svc		to total-clinic-svc(2) 
					   total-dept-svc(2) 
					   total-doc-nbr-svc(2) 
					   ws-ytd-svcs(subs-class-code). 
 
    add docrev-ytd-out-svc		to total-clinic-svc(2) 
					   total-dept-svc(2) 
					   total-doc-nbr-svc(2) 
					   ws-ytd-svcs(subs-class-code). 
 
    add docrev-mtd-in-rec		to total-clinic-amt(1) 
					   total-dept-amt(1) 
					   total-doc-nbr-amt(1) 
					   ws-mtd-amt(subs-class-code). 
 
    add docrev-mtd-out-rec		to total-clinic-amt(1) 
					   total-dept-amt(1) 
					   total-doc-nbr-amt(1) 
					   ws-mtd-amt(subs-class-code). 
 
    add docrev-ytd-in-rec		to total-clinic-amt(2) 
					   total-dept-amt(2) 
					   total-doc-nbr-amt(2) 
					   ws-ytd-amt(subs-class-code). 
 
    add docrev-ytd-out-rec		to total-clinic-amt(2) 
					   total-dept-amt(2) 
					   total-doc-nbr-amt(2) 
					   ws-ytd-amt(subs-class-code). 
 
fa0-99-exit. 
    exit. 
ha0-move-docrev-data-to-wk. 
 
    move docrev-dept			to wf-dept. 
    move docrev-doc-nbr			to wf-doc-nbr. 
    move docrev-oma-cd			to wf-oma-cd. 
 
    add docrev-mtd-in-svc, docrev-mtd-out-svc 
					giving wf-mtd-svcs. 
    add docrev-ytd-in-svc, docrev-ytd-out-svc 
					giving wf-ytd-svcs. 
 
    add docrev-mtd-in-rec, docrev-mtd-out-rec 
					giving wf-mtd-amt. 
    add docrev-ytd-in-rec, docrev-ytd-out-rec 
					giving wf-ytd-amt. 
 
ha0-99-exit. 
    exit. 
 
 
ha1-get-class-code. 
 
    move 'Y'				to flag. 
 
    if docrev-doc-nbr = hold-doc-nbr 
    then 
	next sentence 
    else 
	perform xg0-access-doc-mstr	thru xg0-99-exit. 
*   endif 
 
    if ok 
    then 
	move doc-class-code		to wf-class-code 
    else 
	move high-value			to wf-class-code. 
*   endif 
 
ha1-99-exit. 
    exit. 
ja0-set-up-class-tbl. 
 
    move 1				to subs-class-code. 
 
ja0-10-check-class-code. 
 
    if wf-class-code = ws-hold-class-code(subs-class-code) 
    then 
	next sentence 
    else 
	if subs-class-code > ws-max-nbr-classes 
	then 
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job 
	else 
	    if ws-hold-class-code(subs-class-code) = zero 
	    then 
		move wf-class-code	to ws-hold-class-code(subs-class-code) 
	    else 
		add 1			to subs-class-code 
		go to ja0-10-check-class-code. 
*	    endif 
*	endif 
*   endif 
 
ja0-99-exit. 
    exit. 
xa0-write-wk-rec. 
 
    write work-file-rec. 
 
xa0-99-exit. 
    exit. 
 
 
 
xc0-read-next-docrev. 
 
    read docrev-mstr next 
	at end 
	    move 'Y'			to flag-end-docrev 
	    go to xc0-99-exit. 
 
    if docrev-clinic-1-2 not = sel-clinic-nbr 
    then 
	move 'Y'			to flag-end-docrev 
	go to xc0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to ctr-read-docrev-mstr. 
 
xc0-99-exit. 
    exit. 
 
 
 
xe0-clear-wk-file-rec. 
 
    move zero				to work-file-rec. 
    move spaces				to wf-oma-cd. 
 
xe0-99-exit. 
    exit. 
 
 
 
xg0-access-doc-mstr. 
 
    move docrev-doc-nbr			to doc-nbr. 
 
    read doc-mstr 
	invalid key 
	    move 'N'			to flag 
	    go to xg0-99-exit. 
 
xg0-99-exit. 
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