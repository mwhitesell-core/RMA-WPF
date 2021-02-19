identification division. 
program-id. r011. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 82/11/17. 
date-compiled. 
security. 
* 
*    files      : f050 - doctor revenue master 
* 		: f020 - doctor master 
* 		: f070 - dept master 
*		: f090 - isam constants master 
*		: r011_sort_docrev_file - sorted docrev file 
* 		: "r011" - revenue analyis of doctor totals      
* 
*     program purpose : revenue analysis of doctor totals.     
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
* 
* 
*        mar/88 (j.l.)   - recompile program for the change in f050,f051 
*			   doc rev mtd field changed to s9(6)v99 
* 
*    89/03/10     s. fader      - sms 114 
*				- string the doctor name with 2 spaces 
*				  rather than 1 space, so dr. van der 
*				  meulen can be printed properly. 
* 
*   revised march/89 :  - sms 115 s.f. 
*		        - make sure file status is pic xx ,feedback is 
*			  pic x(4) and infos status is pic x(11). 
* 
*   revised nov/93 yas. - change report title 
*
*   revised jan/98 jc   - s149 unix conversion
*
*   revised 1999/05/10 S.B.	- Made Y2K changes to header and detail lines.
*   2003/dec/09	M.C.	- alpha doc nbr
*   2011/sep/15	MC1 	- add check clinic before continue ba0-process-record
* 			- to be consistent with r012.cbl

environment division. 
input-output section. 
file-control. 
* 
    copy "f050_doc_revenue_mstr.slr". 
* 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f070_dept_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    select sort-docrev-file 
	   assign to "r011_sort_work_mstr" 
	   organization is sequential. 
* 
    select print-file 
	  assign to printer printer-file-name 
	  file status is status-prt-file. 
* 
data division. 
file section. 
* 
    copy "f050_doc_revenue_mstr.fd". 
* 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f070_dept_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_4.ws". 
* 
    copy "r011_sort_docrev_file.sd". 
fd  print-file 
    record contains 132 characters. 
01  prt-line					pic x(132). 
 
working-storage section. 
 
77  err-ind					pic 99. 
77  printer-file-name				pic x(5) 
		value "r011".   
77  option					pic x. 
77  display-key-type				pic x(7). 
77  feedback-docrev-mstr			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
 
77  line-cnt					pic 99  value 57. 
77  page-cnt					pic 9(4) value zero. 
77  max-nbr-lines				pic 99  value 57. 
77  const-mstr-rec-nbr				pic x. 
77  ws-reply					pic x. 
77  ws-hold-curr-class-code			pic x. 
77  ws-doc-class-code				pic x. 
*7  ws-doc-name-inits				pic x(28)	value spaces. 
77  ws-doc-name-inits				pic x(30)	value spaces. 
 
*   (subscripts) 
77  subs					pic 99		comp. 
77  subs1					pic 99		comp. 
77  subs-dept					pic 9	comp value 1. 
77  subs-clinic					pic 9	comp value 2. 
77  subs-present-nbr-classes			pic 99	comp value zero. 
77  subs-class-total				pic 99	comp. 
77  subs-class-code				pic 99		comp. 
77  subs-max-nbr-classes			pic 99		comp. 
77  subs-dept-clinic				pic 9		comp. 
77  ss-table-addr				pic 99		comp. 
77  ss-to					pic 9		comp. 
77  level					pic 9		comp. 
77  ss-from					pic 9		comp. 
 
*  eof flags 
* 
77  eof-subscr-mstr				pic x		value "N". 
* 
*  status file indicators 
* 
*mf 77  status-file				pic x(11). 
*mf 77  status-subscr-mstr			pic x(11) value zero. 
*mf 77  status-doc-mstr				pic x(11) value zero. 
*mf 77  status-dept-mstr			pic x(11) value zero. 
*mf 77  status-docrev-mstr			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zeros. 
 
77  status-file					pic xx. 
77  status-cobol-subscr-mstr			pic x(2) value zero. 
77  status-cobol-doc-mstr			pic x(2) value zero. 
77  status-cobol-dept-mstr			pic x(2) value zero. 
77  status-cobol-docrev-mstr			pic x(2) value zero. 
77  status-cobol-iconst-mstr			pic x(2) value zeros. 
77  status-prt-file				pic x(2) value zero. 
 
01  totals. 
    05  total-svc				pic 9(6).       
    05  total-rec				pic s9(10)v99. 
    05  total-mtd-svc				pic 9(6). 
    05  total-mtd-rec				pic s9(10)v99. 
    05  total-ytd-svc				pic 9(6). 
    05  total-ytd-rec				pic s9(10)v99. 
 
01  file-access-counters. 
    05  docrev-read				pic 9(7) value zero. 
    05  doc-mstr-read				pic 9(7) value zero. 
 
77 request-clinic 				pic xxxx. 
77  ws-request-clinic-ident			pic xx. 
 
 
 
copy "sysdatetime.ws". 
 
01  blank-line					pic x(132) value spaces. 
 
01  save-area. 
    05  save-clinic-1-2				pic 9(2). 
    05  save-dept				pic 99. 
*!    05  save-doc-nbr				pic 999.  
    05  save-doc-nbr				pic xxx.  
    05  save-location				pic x999. 
    05  save-oma				pic x(5). 
    05  save-class-code				pic x. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-ohip-vs-chart				pic x. 
    88  ohip					value "O". 
    88  chart					value "C". 
 
01  flag-valid-ohip-or-chart			pic x. 
    88  valid-ohip				value "Y". 
    88  valid-chart				value "Y". 
    88  invalid-ohip				value "N". 
    88  invalid-chart				value "N". 
 
01  flag-ohip-mmyy				pic x. 
 
    88  valid-mmyy				value "Y". 
    88  invalid-mmyy				value "N". 
 
01  subscripts-for-table. 
 
    05  ss-oma-code				pic 9     value 1. 
    05  ss-loc					pic 9     value 2. 
    05  ss-doc					pic 9     value 3. 
    05  ss-dept					pic 9     value 4. 
    05  ss-grand				pic 9     value 5. 
    05  ss-max-nbr-subscripts			pic 9     value 5. 
 
 
 
01   total-counters. 
* 
*	subscript	total level 
*       ---------	----------- 
*	    1		oma code 
*	    2		location 
*	    3		doctor 
*	    4		department 
*	    5		grand total 
* 
     05  line-totals	occurs 5 times. 
	10  mtd-in-rec				pic s9(10)v99. 
	10  mtd-in-svc				pic 9(6). 
	10  mtd-out-rec				pic s9(10)v99. 
	10  mtd-out-svc				pic 9(6). 
	10  mtd-misc-rec			pic s9(10)v99. 
	10  mtd-misc-svc			pic 9(6). 
	10  ytd-in-rec				pic s9(10)v99. 
	10  ytd-in-svc				pic 9(6). 
	10  ytd-out-rec				pic s9(10)v99. 
	10  ytd-out-svc				pic 9(6). 
	10  ytd-misc-rec			pic s9(10)v99. 
	10  ytd-misc-svc			pic 9(6). 
 
 
01  ws-class-codes. 
 
    05  ws-total-by-dept-clinic occurs 2 times. 
	10  ws-max-class-codes occurs 16 times. 
	    15  ws-class-code			pic x. 
	    15  ws-class-code-desc		pic x(24). 
	    15  ws-mtd-in-rec			pic s9(10)v99. 
	    15  ws-mtd-in-svc			pic 9(6). 
	    15  ws-mtd-out-rec			pic s9(10)v99. 
	    15  ws-mtd-out-svc			pic 9(6).       
	    15  ws-mtd-misc-rec			pic s9(10)v99. 
	    15  ws-mtd-misc-svc			pic 9(6). 
	    15  ws-ytd-in-rec			pic s9(10)v99. 
	    15  ws-ytd-in-svc			pic 9(6).  
	    15  ws-ytd-out-rec			pic s9(10)v99. 
	    15  ws-ytd-out-svc			pic 9(6). 
	    15  ws-ytd-misc-rec			pic s9(10)v99. 
	    15  ws-ytd-misc-svc			pic 9(6). 
 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
01  ws-xx					pic xx 	value "  ". 
01  head-line-1. 
    05  filler					pic x(7) value "R011  /". 
    05  h1-clinic-nbr				pic 99. 
    05  filler					pic x(3) value spaces. 
    05  filler					pic x(7) value "P.E.D.". 
* (y2k)
*    05  h1-ped-yy				pic 99. 
    05  h1-ped-yy				pic 9(04).
    05  filler					pic x	value "/". 
    05  h1-ped-mm				pic 99. 
    05  filler					pic x	value "/". 
    05  h1-ped-dd				pic 99. 
*   05  filler					pic x(17) value spaces. 
*   05  filler					pic x(50)	value 
*(y2k)    05  filler					pic x(5)  value spaces. 
    05  filler					pic x(3)  value spaces. 
    05  filler					pic x(55)	value 
*	"* PHYSICIAN REVENUE ANALYSIS - BY DOCTOR *". 
 	"* DEPARTMENT REVENUE ANALYSIS BY CLASS BY DOCTOR *". 
    05  filler					pic x(11)	value "RUN DATE:". 
* (y2k)
*    05  h1-year					pic 99. 
    05  h1-year					pic 9(04).
    05  filler					pic x		value "/". 
    05  h1-month				pic 99. 
    05  filler					pic x		value "/". 
    05  h1-day					pic 99. 
*(y2k)    05  filler					pic x(9)	value spaces. 
    05  filler					pic x(7)	value spaces. 
    05  filler					pic x(6)	value "PAGE ". 
    05  h1-page					pic zzz9. 
 
01  head-line-2. 
    05  filler					pic x(47)	value spaces. 
    05  h2-clinic				pic x(20). 
    05  filler					pic x(56)	value spaces. 
 
01  head-line-3. 
    05  filler					pic x(40)	value spaces. 
    05  filler					pic x(6)	value 
		"DEPT #". 
    05  h3-dept					pic 99. 
    05  filler					pic x(3)	value " - ". 
    05  h3-dept-name				pic x(73). 
 
 
 
01  head-line-4. 
    05  filler					pic x(40)	value spaces. 
    05  filler					pic x(7)	value "CLASS". 
    05  h4-class-code				pic x(2). 
    05  filler					pic x(2)	value "-". 
    05  h4-class-code-desc			pic x(73). 
 
 
01  head-line-5. 
    05  filler					pic x(38)	value spaces. 
    05  filler					pic x(25)	value 
		"# SVC___IN-PATIENT". 
    05  filler					pic x(23)	value 
		"# SVC__OUT-PATIENT". 
    05  filler					pic x(26)	value 
		"# SVC__MISCELLANEOUS". 
    05  filler					pic x(20)	value 
		"# SVC__TOTAL-AMOUNT". 
 
01  head-line-6. 
    05  h6-dept-clinic-tot			pic x(132). 
 
 
01  detail-line-1. 
 
    05  d1-nbr-name. 
	10  d1-nbr-lit				pic x(6). 
*!	10  d1-doc-nbr				pic 999. 
	10  d1-doc-nbr				pic xxx. 
	10  filler				pic x(19). 
    05  d1-mth-yr				pic x(7). 
    05  d1-mtd-in-svc				pic zzzz,zz9.  
    05  filler					pic x		value spaces. 
    05  d1-mtd-in-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x(3)	value spaces. 
    05  d1-mtd-out-svc				pic zzzz,zz9. 
    05  filler					pic x		value spaces. 
    05  d1-mtd-out-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x		value spaces. 
    05  d1-mtd-misc-svc				pic zzzz,zz9. 
    05  filler					pic x(3)	value spaces. 
    05  d1-mtd-misc-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x		value spaces. 
    05  d1-mtd-tot-svc				pic zzzzz,zz9. 
    05  filler					pic x	 	value spaces. 
    05  d1-mtd-tot-rec				pic zzzzzz,zz9.99-. 
 
 
01  total-line-1. 
    05  t1-dept-clinic. 
	10  t1-class				pic x. 
	10  t1-col-dash-lit			pic x(4). 
	10  t1-class-lit			pic x(23). 
    05  t1-dept-clinic-r redefines t1-dept-clinic. 
	10  filler				pic x. 
	10  t1-col-lit				pic x(2). 
	10  t1-class-code-desc			pic x(25). 
* (y2k)
    05  t1-mth-yr				pic x(7). 
    05  t1-mtd-in-svc				pic zzzz,zz9. 
    05  filler					pic x		value spaces. 
    05  t1-mtd-in-rec				pic  zzzzz,zz9.99-.  
    05  filler					pic x(3)	value spaces. 
    05  t1-mtd-out-svc				pic zzzz,zz9.  
    05  filler					pic x		value spaces. 
    05  t1-mtd-out-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x		value spaces. 
    05  t1-mtd-misc-svc				pic zzzz,zz9.  
    05  filler					pic x(2)	value spaces. 
    05  t1-mtd-misc-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x(2)	value spaces. 
    05  t1-mtd-tot-svc				pic zzzzz,zz9.    
    05  filler					pic x 	 	value spaces. 
    05  t1-mtd-tot-rec				pic zzzzzz,zz9.99-. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)	value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)	value 
		"CONSTANTS MASTER READ ERROR". 
	10  filler				pic x(60)	value 
		"NO DOCTOR REVENUE RECORDS FOR GIVEN CLINIC". 
	10  filler				pic x(60)	value 
		"DEPARTMENT MASTER READ ERROR". 
	10  filler				pic x(60)	value 
		"HEADINGS ONLY PRINTED ON DOC-DEPT-TOTAL BREAK". 
	10  filler				pic x(60)	value 
		"TOO MANY CLASS CODES FOUND". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
		occurs 6 times. 
 
01  err-msg-comment				pic x(60). 
procedure division. 
declaratives. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
*mf    move status-iconst-mstr		to status-file. 
    move status-cobol-iconst-mstr	to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-docrev-mstr-file section. 
    use after standard error procedure on docrev-mstr. 
err-docrev-mstr. 
    stop "ERROR IN ACCESSING DOCREV MASTER ". 
*mf    move status-docrev-mstr		to status-file. 
    move status-cobol-docrev-mstr	to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING DOC MASTER ". 
*mf    move status-doc-mstr		to status-file. 
    move status-cobol-doc-mstr		to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
    stop "ERROR IN ACCESSING DEPT MASTER ". 
*mf   move status-dept-mstr		to status-file. 
    move status-cobol-dept-mstr		to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
end declaratives. 
mainline section. 
 
    perform aa0-initialization			thru aa0-99-exit. 
 
    sort sort-docrev-file 
	 on ascending key 
			wk-docrev-clinic-1-2 
			wk-docrev-dept 
			wk-docrev-class-code 
			wk-docrev-doc-nbr 
	input procedure is ab0-create-sort-file	thru ab0-99-exit 
	output procedure is ba0-process-records	thru ba0-99-exit. 
 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
* (y2k)
    accept sys-date				from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm					to run-mm 
						   h1-month. 
    move sys-dd					to run-dd 
						   h1-day. 
* (y2k)
    move sys-yy					to run-yy 
						   h1-year. 
 
*   display scr-title. 
 
aa0-10. 
 
*   accept scr-clinic-nbr. 
    accept ws-request-clinic-ident 
 
    if ws-request-clinic-ident = "**" 
    then 
   	accept sys-time   from time 
*       display scr-closing-screen 
        stop run. 
*   (else) 
*    endif 
 
    open input   iconst-mstr. 
 
    move ws-request-clinic-ident		to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
    	invalid key 
 		move 2 				to err-ind 
		perform za0-common-error	thru za0-99-exit 
       		go to aa0-10. 
 
    move ws-request-clinic-ident		to h1-clinic-nbr. 
* (y2k)
    move iconst-date-period-end-yy 	   	to  h1-ped-yy. 
* (y2k)
    move iconst-date-period-end-mm 	   	to  h1-ped-mm. 
* (y2k)
    move iconst-date-period-end-dd		to  h1-ped-dd. 
    move iconst-clinic-name 			to  h2-clinic. 
 
*   display msg-month. 
 
*   display msg-continue. 
 
*   accept reply. 
    accept ws-reply 
 
    if ws-reply not = "Y" 
    then  
         close iconst-mstr      
         accept sys-time	from time    
*        display scr-closing-screen 
*        display confirm 
         stop run 
    else 
*        display program-in-progress. 
*   endif 
 
    move 4				to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-finalization. 
 
*    expunge sort-docrev-file. 
 
    open input   docrev-mstr 
		 dept-mstr 
                 doc-mstr. 
*    expunge	 print-file. 
    open output  print-file. 
 
    move 1				to	subs-dept-clinic. 
 
    perform xg0-clear-class-tbl		thru	xg0-99-exit 
	varying subs from 1 by 1 
	until subs > const-nbr-classes + 1. 
 
    move 2				to	subs-dept-clinic. 
 
    perform xg0-clear-class-tbl		thru	xg0-99-exit 
	varying subs from 1 by 1 
	until subs > const-nbr-classes + 1. 
 
    move 1				to	subs-dept-clinic 
						subs-class-code 
						subs-max-nbr-classes. 
 
    perform aa1-zero-counters			thru aa1-99-exit 
	varying ss-from  
	from    1 by 1 
	until   ss-from > ss-max-nbr-subscripts. 
 
    move ss-doc					to	level. 
   
aa0-99-exit.  
    exit. 
aa1-zero-counters. 
 
    move zero			to	mtd-in-rec (ss-from) 
					mtd-in-svc (ss-from) 
					mtd-out-rec (ss-from) 
					mtd-out-svc (ss-from) 
					mtd-misc-rec (ss-from) 
					mtd-misc-svc (ss-from) 
					ytd-in-rec (ss-from) 
					ytd-in-svc (ss-from) 
					ytd-out-rec (ss-from) 
					ytd-out-svc (ss-from) 
					ytd-misc-rec (ss-from) 
					ytd-misc-svc (ss-from). 
 
aa1-99-exit. 
    exit. 
ab0-create-sort-file section. 
 
ab0-10-open-files. 
 
    move zeros				to	docrev-key 
						subs. 
 
    move ws-request-clinic-ident	to	docrev-clinic-1-2. 
 
    perform ra1-read-docrev-approx	thru	ra1-99-exit. 
 
ab0-20-read-docrev. 
 
    if docrev-clinic-1-2 = high-values 
    then 
        go to ab0-99-exit.  
*   (else) 
*   endif 
 
    move docrev-key			to	wk-docrev-key. 
* (y2k)
    move docrev-month-to-date		to	wk-docrev-month-to-date. 
* (y2k)
    move docrev-year-to-date		to	wk-docrev-year-to-date. 
 
    perform ca0-doc-class-code		thru	ca0-99-exit. 
 
    release sort-docrev-rec. 
 
    perform ra0-read-next-docrev	thru 	ra0-99-exit. 
    go to ab0-20-read-docrev. 
 
ab0-99-exit. 
    exit. 
 
 
 
ca0-doc-class-code. 
 
    if save-doc-nbr not = docrev-doc-nbr 
    then 
	perform ca1-get-class-code	thru	ca1-99-exit. 
*   (else) 
*   endif 
 
    move ws-doc-class-code		to	wk-docrev-class-code. 
 
ca0-99-exit. 
    exit. 
 
 
 
ca1-get-class-code. 
 
    move docrev-doc-nbr			to	doc-nbr. 
 
    move 'Y'				to	flag. 
    perform ra2-read-doc-mstr		thru	ra2-99-exit. 
 
    if ok 
    then 
	move doc-class-code		to	ws-doc-class-code 
    else 
	move spaces			to	ws-doc-class-code. 
*   endif 
 
ca1-99-exit. 
    exit. 
ba0-process-records. 
 
    return sort-docrev-file 
	at end 
	    go to ba0-99-exit. 
 
    move wk-docrev-key					to save-area. 
    move wk-docrev-class-code				to ws-hold-curr-class-code 
							   save-class-code. 
 
    perform xi0-new-dept-head				thru xi0-99-exit. 
    perform xk0-new-class-head				thru xk0-99-exit. 
 
ba0-10-process-records. 

* 2011/09/15 - MC1 - check the clinic is the same before continue
    if wk-docrev-clinic-1-2 not = ws-request-clinic-ident 
    then 
        go to ba0-99-exit.
*   endif
* 2011/09/15

    if wk-docrev-dept = save-dept 
    then  
	if wk-docrev-class-code = save-class-code 
	then 
	    if wk-docrev-doc-nbr = save-doc-nbr 
	    then 
 		next sentence 
	    else 
 		perform ba2-doctor-line			thru ba2-99-exit 
*	    endif 
	else 
	    perform ba2-doctor-line			thru ba2-99-exit 
	    perform ba8-class-totals			thru ba8-99-exit 
	    add 1					to subs-class-code 
							   subs-max-nbr-classes 
	    perform xk0-new-class-head			thru xk0-99-exit 
	    perform xd0-heading-lines			thru xd0-99-exit 
*	endif 
    else 
	perform ba2-doctor-line				thru ba2-99-exit 
	perform ba8-class-totals			thru ba8-99-exit 
	move ss-dept 					to   level 
	move 1						to subs-dept-clinic 
	perform ba7-dept-totals				thru ba7-99-exit 
 
	perform xg0-clear-class-tbl			thru xg0-99-exit 
		varying subs from 1 by 1 
		until subs > const-nbr-classes + 1 
	move wk-docrev-key				to save-area 
	perform xi0-new-dept-head			thru xi0-99-exit 
	move 1						to subs-class-code 
              						   subs-max-nbr-classes 
	move ss-doc					to level 
	perform xk0-new-class-head			thru xk0-99-exit 
	perform xd0-heading-lines			thru xd0-99-exit. 
*  endif 
 
    perform ba1-add-to-areas				thru ba1-99-exit. 
 
    move wk-docrev-key					to save-area. 
    move wk-docrev-class-code				to save-class-code. 
 
    return sort-docrev-file 
	at end 
	    go to ba0-99-exit. 
 
    move wk-docrev-class-code				to ws-hold-curr-class-code. 
 
    go to ba0-10-process-records. 
 
ba0-99-exit. 
    exit. 
ba1-add-to-areas. 
 
    if wk-docrev-location not = "MISC" 
    then 
	add wk-docrev-mtd-in-rec	to	mtd-in-rec	(ss-doc) 
						ws-mtd-in-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-mtd-in-svc	to	mtd-in-svc	(ss-doc) 
						ws-mtd-in-svc	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-mtd-out-rec	to	mtd-out-rec	(ss-doc) 
						ws-mtd-out-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-mtd-out-svc	to	mtd-out-svc	(ss-doc) 
						ws-mtd-out-svc	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-in-rec	to	ytd-in-rec	(ss-doc) 
						ws-ytd-in-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-in-svc	to	ytd-in-svc	(ss-doc) 
						ws-ytd-in-svc	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-out-rec	to	ytd-out-rec	(ss-doc) 
						ws-ytd-out-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-out-svc	to	ytd-out-svc	(ss-doc) 
						ws-ytd-out-svc	(subs-dept-clinic,subs-class-code) 
    else 
	add wk-docrev-mtd-out-rec	to	mtd-misc-rec	(ss-doc) 
						ws-mtd-misc-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-mtd-out-svc	to	mtd-misc-svc	(ss-doc) 
						ws-mtd-misc-svc	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-out-rec	to	ytd-misc-rec	(ss-doc) 
						ws-ytd-misc-rec	(subs-dept-clinic,subs-class-code) 
	add wk-docrev-ytd-out-svc	to	ytd-misc-svc	(ss-doc) 
						ws-ytd-misc-svc	(subs-dept-clinic,subs-class-code). 
*   endif 
 
ba1-99-exit. 
    exit. 
ba2-doctor-line. 
 
    move spaces				to	d1-nbr-name. 
    move save-doc-nbr			to	d1-doc-nbr 
						doc-nbr. 
    perform ra2-read-doc-mstr		thru	ra2-99-exit. 
 
    move ss-doc			   	to	ss-from. 
    perform xa0-move-mtd-totals		thru	xa0-99-exit. 
    perform xb0-print-line		thru	xb0-99-exit. 
 
    move ss-doc 			to	ss-from. 
    move ss-dept			to	ss-to.   
    perform xc0-bump-totals		thru	xc0-99-exit. 
 
ba2-99-exit. 
    exit. 
ba7-dept-totals. 
 
    perform xd0-heading-lines		thru	xd0-99-exit. 
 
    move 1				to	subs-class-code. 
 
ba7-10-check-code. 
 
    if subs-class-code > subs-max-nbr-classes 
    then 
	next sentence 
    else 
	perform xm0-print-totals	thru	xm0-99-exit 
	add 1				to	subs-class-code 
	go to ba7-10-check-code. 
*   endif 
 
    move mtd-in-svc (level)		to	t1-mtd-in-svc. 
    move mtd-in-rec (level)		to	t1-mtd-in-rec. 
    move mtd-out-svc (level)		to	t1-mtd-out-svc.        
    move mtd-out-rec (level)		to	t1-mtd-out-rec. 
 
    move mtd-misc-svc (level)		to	t1-mtd-misc-svc. 
    move mtd-misc-rec (level)		to	t1-mtd-misc-rec. 
 
    add mtd-in-svc (level) mtd-out-svc (level) mtd-misc-svc (level)  
					giving	total-svc. 
    add mtd-in-rec (level) mtd-out-rec (level) mtd-misc-rec (level) 
					giving	total-rec. 
    move total-svc			to	t1-mtd-tot-svc. 
    move total-rec			to	t1-mtd-tot-rec. 
 
    if level = ss-dept 
    then 
	move '** DEPARTMENT TOTALS **'	to	t1-dept-clinic 
    else 
	move '* CLINIC GRAND TOTALS *'	to	t1-dept-clinic. 
*   endif 
 
    move 'MONTH'			to	t1-mth-yr. 
    write prt-line from total-line-1	after	advancing 2 lines. 
 
    move ytd-in-svc (level)		to	t1-mtd-in-svc. 
    move ytd-in-rec (level)		to	t1-mtd-in-rec. 
    move ytd-out-svc (level)		to	t1-mtd-out-svc. 
    move ytd-out-rec (level)		to	t1-mtd-out-rec. 
 
    move ytd-misc-svc (level)		to	t1-mtd-misc-svc. 
    move ytd-misc-rec (level)		to	t1-mtd-misc-rec. 
 
    add ytd-in-svc (level) ytd-out-svc (level) ytd-misc-svc (level)  
					giving	total-svc. 
    add ytd-in-rec (level) ytd-out-rec (level) ytd-misc-rec (level) 
					giving	total-rec. 
    move total-svc			to	t1-mtd-tot-svc. 
    move total-rec			to	t1-mtd-tot-rec. 
 
    move spaces				to	t1-dept-clinic. 
    move ' YEAR'			to	t1-mth-yr. 
    write prt-line from total-line-1	after	advancing 1 line.  
 
    if level = ss-dept 
    then 
	move ss-dept			to	ss-from 
        move ss-grand			to	ss-to 
        perform xc0-bump-totals		thru	xc0-99-exit. 
*   (else) 
*   endif 
 
ba7-99-exit. 
    exit. 
ba8-class-totals. 
 
    perform ba82-display-totals			thru ba82-99-exit. 
    perform ba83-bump-totals			thru ba83-99-exit. 
 
ba8-99-exit. 
    exit. 
 
 
 
ba82-display-totals. 
 
    move ws-mtd-in-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-in-rec. 
    move ws-mtd-in-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-in-svc. 
    move ws-mtd-out-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-out-svc. 
    move ws-mtd-out-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-out-rec. 
    move ws-mtd-misc-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-misc-svc. 
    move ws-mtd-misc-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-misc-rec. 
 
    add ws-mtd-in-svc(subs-dept-clinic,subs-class-code) 
	ws-mtd-out-svc(subs-dept-clinic,subs-class-code) 
	ws-mtd-misc-svc(subs-dept-clinic,subs-class-code) 
						giving total-svc. 
 
    move total-svc				to t1-mtd-tot-svc. 
 
    add ws-mtd-in-rec(subs-dept-clinic,subs-class-code) 
	ws-mtd-out-rec(subs-dept-clinic,subs-class-code) 
	ws-mtd-misc-rec(subs-dept-clinic,subs-class-code) 
						giving total-rec. 
 
    move total-rec				to t1-mtd-tot-rec. 
 
    move ws-class-code(subs-dept-clinic,subs-class-code) 
						to t1-class. 
    move ': - '					to t1-col-dash-lit. 
    move 'CLASS TOTALS'				to t1-class-lit. 
    move 'MONTH'				to t1-mth-yr. 
 
    write prt-line from total-line-1		after	advancing 3 lines. 
 
    move spaces					to t1-dept-clinic. 
    move ' YEAR'				to t1-mth-yr. 
    move ws-ytd-in-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-in-rec. 
    move ws-ytd-in-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-in-svc. 
    move ws-ytd-out-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-out-svc. 
    move ws-ytd-out-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-out-rec. 
    move ws-ytd-misc-svc(subs-dept-clinic,subs-class-code) 
						to t1-mtd-misc-svc. 
    move ws-ytd-misc-rec(subs-dept-clinic,subs-class-code) 
						to t1-mtd-misc-rec. 
 
    add ws-ytd-in-svc(subs-dept-clinic,subs-class-code) 
	ws-ytd-out-svc(subs-dept-clinic,subs-class-code) 
	ws-ytd-misc-svc(subs-dept-clinic,subs-class-code) 
						giving total-svc. 
 
    move total-svc				to t1-mtd-tot-svc. 
 
    add ws-ytd-in-rec(subs-dept-clinic,subs-class-code) 
	ws-ytd-out-rec(subs-dept-clinic,subs-class-code) 
	ws-ytd-misc-rec(subs-dept-clinic,subs-class-code) 
						giving total-rec. 
 
    move total-rec				to t1-mtd-tot-rec. 
  
    write prt-line from total-line-1		after	advancing 1 line. 
 
ba82-99-exit. 
    exit. 
 
 
 
ba83-bump-totals. 
 
    move 'N'				to	flag. 
    move 1				to	subs-class-total. 
 
    if subs-present-nbr-classes not = zero 
    then 
	perform ba84-search-class-tbl	thru	ba84-99-exit 
		varying subs1 from 1 by 1 
		until   subs1 > subs-present-nbr-classes 
		     or ok. 
*   (else) 
*   endif 
 
    if ok 
    then 
	next sentence 
    else 
	add 1				to	subs-present-nbr-classes 
	if subs-present-nbr-classes > const-nbr-classes + 1 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-finalization 
	else 
	    move ws-class-code(subs-dept-clinic,subs-class-code) 
					to	ws-class-code(subs-clinic,subs-class-total) 
	    move ws-class-code-desc(subs-dept-clinic,subs-class-code) 
					to	ws-class-code-desc(subs-clinic,subs-class-total). 
*	endif 
*   endif 
 
    add ws-mtd-in-rec(subs-dept-clinic,subs-class-code) 
					to	ws-mtd-in-rec(subs-clinic,subs-class-total). 
    add ws-mtd-in-svc(subs-dept-clinic,subs-class-code) 
					to	ws-mtd-in-svc(subs-clinic,subs-class-total). 
    add ws-mtd-out-rec(subs-dept-clinic,subs-class-code) 
					to	ws-mtd-out-rec(subs-clinic,subs-class-total). 
    add ws-mtd-out-svc(subs-dept-clinic,subs-class-code) 
					to	ws-mtd-out-svc(subs-clinic,subs-class-total). 
    add ws-mtd-misc-rec(subs-dept-clinic,subs-class-code) 
  					to	ws-mtd-misc-rec(subs-clinic,subs-class-total). 
    add ws-mtd-misc-svc(subs-dept-clinic,subs-class-code) 
					to	ws-mtd-misc-svc(subs-clinic,subs-class-total). 
 
    add ws-ytd-in-rec(subs-dept-clinic,subs-class-code) 
					to	ws-ytd-in-rec(subs-clinic,subs-class-total). 
    add ws-ytd-in-svc(subs-dept-clinic,subs-class-code) 
					to	ws-ytd-in-svc(subs-clinic,subs-class-total). 
    add ws-ytd-out-rec(subs-dept-clinic,subs-class-code) 
					to	ws-ytd-out-rec(subs-clinic,subs-class-total). 
    add ws-ytd-out-svc(subs-dept-clinic,subs-class-code) 
					to	ws-ytd-out-svc(subs-clinic,subs-class-total). 
    add ws-ytd-misc-rec(subs-dept-clinic,subs-class-code) 
  					to	ws-ytd-misc-rec(subs-clinic,subs-class-total). 
    add ws-ytd-misc-svc(subs-dept-clinic,subs-class-code) 
					to	ws-ytd-misc-svc(subs-clinic,subs-class-total). 
 
ba83-99-exit. 
    exit. 
 
 
ba84-search-class-tbl. 
 
    if ws-class-code(subs-dept-clinic,subs-class-code) = ws-class-code(subs-clinic,subs-class-total) 
    then 
	move 'Y'			to	flag 
    else 
	add 1				to	subs-class-total. 
*   endif 
 
ba84-99-exit. 
    exit. 
ra0-read-next-docrev. 
 
    move docrev-key			to	save-area. 
 
ra0-10-read-next-doc. 
 
    read  docrev-mstr  next 
	at end      
	    move high-values		to	docrev-clinic-1-2 
	    go to ra0-99-exit. 
 
    if docrev-clinic-1-2 not = ws-request-clinic-ident 
    then 
*	go to ra0-10-read-next-doc 
*   else 
*	if docrev-clinic-1-2 > ws-request-clinic-ident   
*	then  
	    move high-values	to	docrev-clinic-1-2 
	    go to ra0-99-exit 
	else 
	    next sentence. 
*	endif     
*   endif 
 
    add 1				to	docrev-read. 
 
ra0-99-exit. 
    exit. 
ra1-read-docrev-approx. 
 
*mf    read docrev-mstr key is docrev-key approximate 
*mf	invalid key 
*mf	    move 3			to	err-ind    
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-finalization. 

    start docrev-mstr key is greater than or equal to docrev-key
 	invalid key 
	    move 3			to	err-ind    
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-finalization. 
    read docrev-mstr next.
    
    add 1				to	docrev-read. 
 
ra1-99-exit. 
    exit. 
ra2-read-doc-mstr. 
 
    read doc-mstr 
	invalid key 
	    move "N"			to	flag      
	    move "INVALID DOCTOR" 	to	doc-name  
	    go to ra2-99-exit. 
 
 
    add 1				to	doc-mstr-read. 
 
 
 
ra2-99-exit. 
    exit. 
xa0-move-mtd-totals. 
 
    move mtd-in-rec (ss-from)		to	d1-mtd-in-rec. 
    move mtd-in-svc (ss-from)		to	d1-mtd-in-svc. 
    move mtd-out-rec (ss-from)		to	d1-mtd-out-rec. 
    move mtd-out-svc (ss-from) 		to	d1-mtd-out-svc. 
    move mtd-misc-rec (ss-from)		to	d1-mtd-misc-rec. 
    move mtd-misc-svc (ss-from)		to	d1-mtd-misc-svc.  
    add mtd-in-rec (ss-from) mtd-out-rec (ss-from) mtd-misc-rec (ss-from) 
					giving	total-mtd-rec. 
    add mtd-in-svc (ss-from) mtd-out-svc (ss-from) mtd-misc-svc (ss-from) 
					giving	total-mtd-svc. 
    move total-mtd-rec			to	d1-mtd-tot-rec. 
    move total-mtd-svc			to	d1-mtd-tot-svc. 
 
    move 'MONTH'			to	d1-mth-yr. 
 
xa0-99-exit. 
    exit. 
 
 
xa1-move-ytd-totals. 
 
    move ytd-in-rec (ss-from)		to	d1-mtd-in-rec. 
    move ytd-in-svc (ss-from)		to	d1-mtd-in-svc. 
    move ytd-out-rec (ss-from)		to	d1-mtd-out-rec. 
    move ytd-out-svc (ss-from)		to	d1-mtd-out-svc. 
    move ytd-misc-rec (ss-from)		to	d1-mtd-misc-rec. 
    move ytd-misc-svc (ss-from)		to	d1-mtd-misc-svc. 
 
    add ytd-in-rec (ss-from) ytd-out-rec (ss-from) ytd-misc-rec (ss-from) 
					giving	total-ytd-rec. 
    add ytd-in-svc (ss-from) ytd-out-svc (ss-from) ytd-misc-svc (ss-from) 
					giving	total-ytd-svc. 
 
    move total-ytd-rec			to	d1-mtd-tot-rec. 
    move total-ytd-svc			to	d1-mtd-tot-svc. 
 
    move ' YEAR'			to	d1-mth-yr. 
 
xa1-99-exit. 
    exit. 
xb0-print-line. 
    
    add 3				to	line-cnt. 
 
    if line-cnt > max-nbr-lines 
    then 
	perform xd0-heading-lines	thru	xd0-99-exit. 
*   (else) 
*   endif 
 
    move 'NBR :'			to	d1-nbr-lit. 
    write prt-line from detail-line-1   after   advancing 2 lines. 
 
    perform xb1-doc-name-inits		thru	xb1-99-exit. 
 
    move ws-doc-name-inits		to	d1-nbr-name. 
    perform xa1-move-ytd-totals		thru	xa1-99-exit. 
    write prt-line from detail-line-1	after	advancing 1 line. 
 
xb0-99-exit. 
    exit. 
 
 
 
xb1-doc-name-inits. 
 
    move spaces				to	ws-doc-name-inits. 
 
    if doc-init3 not = spaces 
    then 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
*       string doc-name			delimited by spaces, 
	string doc-name			delimited by ws-xx, 
	       " "			delimited by size, 
	       doc-init1		delimited by size, 
	       "."			delimited by size, 
	       doc-init2		delimited by size, 
	       "."			delimited by size, 
	       doc-init3		delimited by size, 
	       "."			delimited by size, 
					into	ws-doc-name-inits 
    else 
	if doc-init2 not = spaces 
	then 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
*           string doc-name		delimited by spaces, 
	    string doc-name		delimited by ws-xx, 
	    " "				delimited by size, 
	    doc-init1			delimited by size, 
	    "."				delimited by size, 
	    doc-init2			delimited by size, 
	    "."				delimited by size, 
					into	ws-doc-name-inits 
	else 
	    if doc-init1 not = spaces 
	    then 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
*        	string doc-name		delimited by spaces, 
		string doc-name		delimited by ws-xx, 
		" "			delimited by size, 
		doc-init1		delimited by size, 
		"."			delimited by size, 
					into	ws-doc-name-inits 
	    else 
		move doc-name		to	ws-doc-name-inits. 
*	    endif 
*	endif 
*   endif 
 
xb1-99-exit. 
    exit. 
xd0-heading-lines. 
 
    add 1				to	page-cnt.  
    move page-cnt			to	h1-page. 
    write prt-line from head-line-1	after	advancing page.    
    write prt-line from head-line-2	after	advancing 1 line. 
    if level = ss-doc 
    then 
	write prt-line from head-line-3	after	advancing 2 lines 
	write prt-line from head-line-4	after	advancing 1 line 
    else 
	if level = ss-dept 
	then 
	    write prt-line from head-line-3 after advancing 2 lines 
	    move 'DEPARTMENT CLASS TOTALS' 
					to	h6-dept-clinic-tot 
	    write prt-line from head-line-6 after advancing 3 lines 
	else 
	    if level = ss-grand 
	    then 
		move 'CLINIC CLASS TOTALS' 
					to	h6-dept-clinic-tot 
		write prt-line from head-line-6 
					after	advancing 3 lines 
	    else 
		move 5			to	err-ind 
		perform za0-common-error 
					thru	za0-99-exit. 
*	    endif 
*	endif 
*   endif 
 
    write prt-line from head-line-5	after	advancing 2 lines. 
 
    move 8				to	line-cnt. 
 
xd0-99-exit. 
    exit. 
xg0-clear-class-tbl. 
 
    move spaces				to ws-class-code(subs-dept-clinic,subs) 
					   ws-class-code-desc(subs-dept-clinic,subs) 
 
    move zero				to ws-mtd-in-rec(subs-dept-clinic,subs) 
					   ws-mtd-in-svc(subs-dept-clinic,subs) 
					   ws-mtd-out-rec(subs-dept-clinic,subs) 
					   ws-mtd-out-svc(subs-dept-clinic,subs) 
					   ws-mtd-misc-rec(subs-dept-clinic,subs) 
					   ws-mtd-misc-svc(subs-dept-clinic,subs) 
					   ws-ytd-in-rec(subs-dept-clinic,subs) 
					   ws-ytd-in-svc(subs-dept-clinic,subs) 
					   ws-ytd-out-rec(subs-dept-clinic,subs) 
					   ws-ytd-out-svc(subs-dept-clinic,subs) 
					   ws-ytd-misc-rec(subs-dept-clinic,subs) 
					   ws-ytd-misc-svc(subs-dept-clinic,subs). 
 
xg0-99-exit. 
    exit. 
 
 
 
 
xk0-new-class-head. 
 
    move 1				to subs. 
 
xk0-10-access-const-for-desc. 
 
    if ws-hold-curr-class-code = const-class-ltr(subs) 
    then 
	move const-class-desc(subs)	to h4-class-code-desc 
					   ws-class-code-desc(subs-dept-clinic,subs-class-code) 
    else 
	if subs < const-nbr-classes 
	then 
	    add 1			to subs 
	    go to xk0-10-access-const-for-desc 
	else 
	    move 'UNKNOWN DESC'		to h4-class-code-desc 
					   ws-class-code-desc(subs-dept-clinic,subs-class-code). 
*	endif 
*   endif 
 
    move ws-hold-curr-class-code	to ws-class-code(subs-dept-clinic,subs-class-code) 
					   h4-class-code. 
 
xk0-99-exit. 
    exit. 
 
 
xi0-new-dept-head. 
 
    move wk-docrev-dept			to h3-dept 
					   dept-nbr. 
 
    read dept-mstr 
	invalid key 
	    move 4			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    move 'UNKNOWN DEPT'		to dept-name. 
 
    move dept-name			to h3-dept-name. 
 
xi0-99-exit. 
    exit. 
 
 
 
xm0-print-totals. 
 
    move ws-mtd-in-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-in-svc. 
    move ws-mtd-in-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-in-rec. 
    move ws-mtd-out-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-out-svc.        
    move ws-mtd-out-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-out-rec. 
 
    move ws-mtd-misc-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-misc-svc. 
    move ws-mtd-misc-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-misc-rec. 
 
    add ws-mtd-in-svc (subs-dept-clinic,subs-class-code) 
	ws-mtd-out-svc (subs-dept-clinic,subs-class-code) 
	ws-mtd-misc-svc (subs-dept-clinic,subs-class-code) 
					giving	total-svc. 
    add ws-mtd-in-rec (subs-dept-clinic,subs-class-code) 
	ws-mtd-out-rec (subs-dept-clinic,subs-class-code) 
	ws-mtd-misc-rec (subs-dept-clinic,subs-class-code) 
					giving	total-rec. 
 
    move total-svc			to	t1-mtd-tot-svc. 
    move total-rec			to	t1-mtd-tot-rec. 
 
    move ws-class-code(subs-dept-clinic,subs-class-code) 
					to	t1-class. 
    move ': '				to	t1-col-lit. 
    move ws-class-code-desc(subs-dept-clinic,subs-class-code) 
					to	t1-class-code-desc. 
    move 'MONTH'			to	t1-mth-yr. 
 
    write prt-line from total-line-1	after	advancing 2 lines. 
 
    move ws-ytd-in-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-in-svc. 
    move ws-ytd-in-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-in-rec. 
    move ws-ytd-out-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-out-svc. 
    move ws-ytd-out-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-out-rec. 
 
    move ws-ytd-misc-svc (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-misc-svc. 
    move ws-ytd-misc-rec (subs-dept-clinic,subs-class-code) 
					to	t1-mtd-misc-rec. 
 
    add ws-ytd-in-svc (subs-dept-clinic,subs-class-code) 
	ws-ytd-out-svc (subs-dept-clinic,subs-class-code) 
	ws-ytd-misc-svc (subs-dept-clinic,subs-class-code) 
					giving	total-svc. 
 
    add ws-ytd-in-rec (subs-dept-clinic,subs-class-code) 
	ws-ytd-out-rec (subs-dept-clinic,subs-class-code) 
	ws-ytd-misc-rec (subs-dept-clinic,subs-class-code) 
					giving	total-rec. 
 
    move total-svc			to	t1-mtd-tot-svc. 
    move total-rec			to	t1-mtd-tot-rec. 
 
    move spaces				to	t1-dept-clinic. 
    move ' YEAR'			to	t1-mth-yr. 
 
    write prt-line from total-line-1	after	advancing 1 line.  
 
xm0-99-exit. 
    exit. 
xc0-bump-totals. 
 
    add mtd-in-rec (ss-from)		to	mtd-in-rec (ss-to) 
    add mtd-in-svc (ss-from)		to	mtd-in-svc (ss-to) 
    add mtd-out-rec (ss-from)		to	mtd-out-rec (ss-to) 
    add mtd-out-svc (ss-from)		to	mtd-out-svc (ss-to) 
    add mtd-misc-rec (ss-from)		to	mtd-misc-rec (ss-to) 
    add mtd-misc-svc (ss-from)		to	mtd-misc-svc (ss-to) 
 
    add ytd-in-rec (ss-from)		to	ytd-in-rec (ss-to) 
    add ytd-in-svc (ss-from)		to	ytd-in-svc (ss-to) 
    add ytd-out-rec (ss-from)		to	ytd-out-rec (ss-to) 
    add ytd-out-svc (ss-from)		to	ytd-out-svc (ss-to) 
    add ytd-misc-rec (ss-from)		to	ytd-misc-rec (ss-to) 
    add ytd-misc-svc (ss-from)		to	ytd-misc-svc (ss-to) 
 
    move zero				to	mtd-in-rec (ss-from) 
                                                mtd-in-svc (ss-from) 
                                                mtd-out-rec (ss-from) 
                                                mtd-out-svc (ss-from) 
                                                mtd-misc-rec (ss-from) 
                                                mtd-misc-svc (ss-from) 
                                                ytd-in-rec (ss-from) 
                                                ytd-in-svc (ss-from) 
                                                ytd-out-rec (ss-from) 
                                                ytd-out-svc (ss-from) 
                                                ytd-misc-rec (ss-from) 
                                                ytd-misc-svc (ss-from). 
 
xc0-99-exit. 
    exit. 
az0-finalization. 
 
    perform ba2-doctor-line		thru	ba2-99-exit. 
    move 1				to	subs-dept-clinic. 
    perform ba8-class-totals		thru	ba8-99-exit. 
    move ss-dept			to	level. 
    perform ba7-dept-totals		thru	ba7-99-exit. 
 
*	( print clinic totals ) 
    move 2				to	subs-dept-clinic. 
    move ss-grand			to	level. 
    move subs-present-nbr-classes	to	subs-max-nbr-classes. 
    perform ba7-dept-totals		thru	ba7-99-exit. 
 
    close docrev-mstr 
	  doc-mstr 
	  dept-mstr 
	  iconst-mstr 
	  print-file. 
 
    accept sys-time			from time. 
*   display scr-counters. 
*   display scr-closing-screen. 
*   display scr-report-location. 
*   display confirm. 
 
az0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to err-msg-comment. 
*   display err-msg-line. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
