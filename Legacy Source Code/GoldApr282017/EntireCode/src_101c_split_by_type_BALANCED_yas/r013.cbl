identification division. 
program-id. r013.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/01/14. 
date-compiled. 
security. 
* 
*    files      : f050 - doctor revenue master 
*		: f030 - locations master 
*		: f070 - dept master 
*		: f020 - doctor master 
*               : f013 - sort docrev file 
*		: f090 - isam constants master 
*		: "r013" - revenue analyis by location report 
*    program purpose : revenue analysis by location report. 
* 
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
*    april 26/89  s. fader      - sms 116 
*				- print the dept code and/or name 
*				 
*   revised nov/93  yas.     - changed report title 
*
*   revised jan/98 j. chau   - s149 unix conversion
*
*   revised 1999/05/10 S.B.	- Made Y2K changes.
*   2003/dec/10 	M.C.	- alpha doc nbr
*   2011/sep/15 	MC1     - add check clinic before continue ba0-process-record
*                       	- to be consistent with r012.cbl

environment division. 
input-output section. 
file-control. 
* 
    copy "f050_doc_revenue_mstr.slr". 
* 
    copy "f030_locations_mstr.slr". 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "f070_dept_mstr.slr". 
* 
    select print-file 
	  assign to printer printer-file-name 
	  file status is status-prt-file. 
* 
    select sort-docrev-file 
          assign to "sortwk" 
          organization is sequential 
          file status is status-sort-file. 
 
* 
data division. 
file section. 
* 
    copy "f050_doc_revenue_mstr.fd". 
* 
    copy "f030_locations_mstr.fd". 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f070_dept_mstr.fd". 
 
 
fd  print-file 
    record contains 132 characters. 
01  prt-line					pic x(132). 
 
 
* 
    copy "f013_sort_docrev_file.sd". 
* 
 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  printer-file-name				pic x(5) 
		value "r013".  
77  option					pic x. 
77  display-key-type				pic x(7). 
77  subs-table-addr				pic 99		comp. 
* 
* 
*  status file indicators 
* 
77  feedback-iconst-mstr			pic x(4). 
77  feedback-docrev-mstr			pic x(4)  value zero. 
*mf 77  status-file				pic x(11). 
*mf 77  status-dept-mstr			pic x(11) value zero. 
*mf 77  status-doc-mstr				pic x(11) value zero. 
*mf 77  status-docrev-mstr			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zeros. 
*mf 77  status-loc-mstr				pic x(11) value zero. 
 
77  status-file					pic x(2). 
77  status-cobol-dept-mstr			pic x(2) value zero. 
77  status-cobol-doc-mstr			pic x(2) value zero. 
77  status-cobol-docrev-mstr			pic x(2) value zero. 
77  status-cobol-iconst-mstr			pic x(2) value zeros. 
77  status-cobol-loc-mstr			pic x(2) value zero. 
 
77  status-prt-file				pic xx    value zero. 
77  status-sort-file				pic xx    value zero. 
77  ws-in-progress-lit				pic x(24) value "PROGRAM R013 IN PROGRESS". 
 
77  const-mstr-rec-nbr				pic x. 
77  ws-reply					pic x. 
77  x-to					pic 9 	value zero. 
77  level					pic 9	value zero. 
77  x-from					pic 9   value zero. 
77  line-cnt					pic 999 value zero. 
77  page-cnt					pic 9(4)	value zero. 
 
77  total-svc					pic 9(6).    
77  total-rec					pic s9(10)v99. 
77  total-mtd-svc				pic 9(6). 
77  total-mtd-rec				pic s9(10)v99. 
77  total-ytd-svc				pic 9(6). 
77  total-ytd-rec				pic s9(10)v99. 
 
77  docrev-read					pic 9(7) value zero. 
77  doc-mstr-read				pic 9(7) value zero. 
77  loc-mstr-read				pic 9(7) value zero. 
77  dept-mstr-read				pic 9(7) value zero. 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
 
01  ws-const-period-end-date. 
* (y2k)
*    05  ws-const-yy				pic 99. 
    05  ws-const-yy				pic 9(04).
    05  ws-const-mm				pic 99. 
    05  ws-const-dd				pic 99. 
 
01 request-clinic				pic xxxx.   
 
01  ws-request-clinic-ident			pic xx. 
 
 
01  blank-line					pic x(132) value spaces. 
 
01  save-area. 
    05  save-clinic				pic 9(2). 
    05  save-dept				pic 99.     
*!    05  save-doc-nbr				pic 999. 
    05  save-doc-nbr				pic xxx. 
    05  save-location				pic x999. 
    05  save-oma				pic x(5). 
 
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
 
01  head-line-1. 
    05  filler					pic x(7) value "R013  /". 
    05  h1-clinic-nbr				pic 99. 
    05  filler					pic x	 value spaces. 
    05  h1-month				pic x(9).       
    05  filler					pic x		value spaces. 
    05  h1-day					pic z9. 
*(y2k)    05  filler					pic xxxx	value ", 19".  
    05  filler					pic xx value ", ".
* (y2k)
*    05  h1-year					pic xx.   
    05  h1-year					pic xxxx.   
*   05  filler					pic x(18)	value spaces. 
*(y2k)    05  filler					pic x(5) 	value spaces. 
    05  filler					pic x(3) 	value spaces. 
*   05  filler					pic x(32)	value 
    05  filler					pic x(55)	value 
*		"* REVENUE ANALYSIS BY LOCATION *". 
		"* LOCATION REVENUE ANALYSIS BY PHYSICIAN BY OMA CODE *". 
    05  filler					pic x(08)	value spaces. 
*   05  filler					pic x(25)	value spaces. 
* (y2k)
    05  header-date			 	pic x(8). 
    05  filler					pic x(10)	value spaces. 
    05  filler					pic x(5)	value "PAGE ". 
    05  h1-page					pic z,zzz. 
 
01  head-line-2. 
    05  filler					pic x(49)	value spaces. 
    05  h2-clinic				pic x(20). 
    05  filler					pic x(60)	value spaces. 
 
 
 
01  head-line-4. 
    05  h4-header-title				pic x(10). 
    05  h4-doc-or-loc-nbr			pic xxxxx.  
    05  filler					pic x		value spaces. 
    05  h4-doc-or-loc-name			pic x(25). 
    05  filler					pic x(91)	value spaces. 
 
01  head-line-5. 
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(60)	value 
	"---------------------- MONTH TO DATE ----------------------". 
    05  filler					pic x(64)	value 
	"------------------------- YEAR TO DATE  ------------------------". 
 
 
01  head-line-6. 
    05  filler					pic x(68)	value 
	" OMA    #SV....IN PAT #SV...OUT PAT #SV      MISC  #SV   TOTAL AMT  ". 
    05  filler					pic x(65)	value 
	"#SV.....IN PAT  #SV....OUT PAT  #SV      MISC   #SV   TOTAL AMT". 
 
 
01  detail-line-1. 
 
    05  filler					pic x(14)	value 
        " DEPARTMENT # ". 
    05  d1-dept-nbr				pic 99. 
    05  filler					pic x		value spaces. 
    05  d1-dept-name				pic x(30). 
    05  filler					pic x(10)	value 
 	" DOCTOR # ". 
*   05  d1-doc-nbr				pic 9(5). 
*!    05  d1-doc-nbr				pic 9(3). 
    05  d1-doc-nbr				pic x(3). 
    05  filler					pic xx		value spaces. 
    05  d1-doc-name				pic x(25). 
    05  filler					pic x(43)	value spaces. 
 
 
01  detail-line-2. 
 
    05  filler					pic x		value spaces. 
    05  d2-oma-code				pic x(5). 
    05  filler					pic xx		value spaces. 
* Feb/19/2001 A.A
*   05  d2-mtd-in-svc				pic zz9. 
*   05  filler					pic xx		value spaces. 
    05  d2-mtd-in-svc				pic zzz9. 
    05  filler					pic x 		value spaces. 
    05  d2-mtd-in-rec				pic zzzz9.99-. 
* Feb/19/2001 A.A
*   05  d2-mtd-out-svc				pic zz9. 
*   05  filler					pic xx		value spaces. 
    05  d2-mtd-out-svc				pic zzz9. 
    05  filler					pic x 		value spaces. 
    05  d2-mtd-out-rec				pic zzzz9.99-. 
    05  filler					pic x		value spaces. 
    05  d2-mtd-misc-svc				pic z9. 
    05  filler					pic xx		value spaces. 
    05  d2-mtd-misc-rec				pic zzzz9.99-. 
    05  d2-mtd-tot-svc				pic zzz9. 
    05  filler					pic xxx 	value spaces. 
    05  d2-mtd-tot-rec				pic zzzzz9.99-. 
    05  d2-ytd-in-svc				pic zzz9.  
    05  filler					pic xx		value spaces. 
    05  d2-ytd-in-rec				pic zzzzz9.99-. 
    05  d2-ytd-out-svc				pic zzz9. 
    05  filler					pic xx		value spaces. 
    05  d2-ytd-out-rec				pic zzzzz9.99-. 
    05  d2-ytd-misc-svc				pic zzz9. 
    05  filler					pic x		value spaces. 
    05  d2-ytd-misc-rec				pic zzzzz9.99-. 
    05  d2-ytd-tot-svc				pic zzzz9. 
    05  filler					pic xx		value spaces. 
    05  d2-ytd-tot-rec				pic zzzzzz9.99-. 
 
 
01  total-line-1. 
    05  filler					pic x(34)	value spaces. 
    05  filler					pic x(14)	value 
		"**** LOCATION ". 
    05  t1-location  				pic x999. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(10)	value 
		"TOTAL ****". 
    05  filler					pic x(64)	value spaces. 
 
01  total-line-1a. 
    05  filler					pic x(34)	value spaces. 
    05  filler					pic x(28)	value 
		"**** LOCATION SUMMARY ****". 
    05  filler					pic x(72)	value spaces. 
 
01  total-line-2. 
    05  filler					pic x(25)	value spaces. 
    05  filler					pic x(17)	value 
		"#SV....IN PATIENT". 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(17)	value 
		"#SV...OUT PATIENT". 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(17)	value 
		"#SV.....MISCELLAN". 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(17)	value 
		"#SV..TOTAL AMOUNT". 
    05  filler					pic x(21)	value spaces. 
 
01  total-line-3. 
    05  filler					pic xxx		value spaces. 
    05  t3-title				pic x(13). 
    05  filler					pic x(5)	value spaces. 
    05  t3-in-svc				pic zzz,zz9. 
    05  filler					pic x		value spaces. 
    05  t3-in-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x 		value spaces. 
    05  t3-out-svc				pic zzz,zz9.   
    05  filler					pic x		value spaces. 
    05  t3-out-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x 		value spaces. 
    05  t3-misc-svc				pic zzz,zz9. 
    05  filler					pic x		value spaces. 
    05  t3-misc-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x 		value spaces. 
    05  t3-tot-svc				pic zzz,zz9. 
    05  filler					pic x		value spaces. 
    05  t3-tot-rec				pic zzzzz,zz9.99-. 
    05  filler					pic x(20)	value spaces. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)	value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)	value 
		"CONSTANTS MASTER READ ERROR". 
	10  filler				pic x(60)	value 
		"NO DOCTOR REVENUE RECORD FOR GIVEN CLINIC". 
 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
		occurs 3 times. 
 
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
 
err-loc-mstr-file section. 
    use after standard error procedure on loc-mstr. 
err-loc-mstr. 
    stop "ERROR IN ACCESSING LOCATION MASTER ". 
*mf    move status-loc-mstr		to status-file. 
    move status-cobol-loc-mstr		to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING DOCTOR MASTER ". 
*mf    move status-doc-mstr		to status-file. 
    move status-cobol-doc-mstr		to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
    stop "ERROR IN ACCESSING DEPT MASTER ". 
*mf    move status-dept-mstr		to status-file. 
    move status-cobol-dept-mstr		to status-file. 
*   display file-status-display. 
    display status-file 
    stop run. 
 
end declaratives. 
 
 
mainline section. 
 
    perform aa0-initialization			thru aa0-99-exit. 
    sort sort-docrev-file      
         on ascending key wk-docrev-clinic-1-2, 
			  wk-docrev-location, 
			  wk-docrev-doc-nbr, 
			  wk-docrev-oma-cd  
         input procedure is ab0-create-sort-file thru ab0-99-exit 
	 output procedure is ba0-process-records thru ba0-99-exit. 
 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
 
 
aa0-initialization section. 
 
*    expunge sort-docrev-file. 
 
*    expunge  print-file. 
 
 
    accept sys-date				from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm					to run-mm. 
    move sys-dd					to run-dd. 
    move sys-yy					to run-yy. 
 
 
 
******************************* 
*   display scr-title. 
 
aa0-10. 
 
*   accept scr-clinic-nbr. 
    accept ws-request-clinic-ident 
 
    if ws-request-clinic-ident = "**" 
    then 
	accept sys-time   from time 
*       display scr-closing-screen 
        stop run. 
*   else 
*   endif 
 
 
    open input iconst-mstr. 
    move ws-request-clinic-ident		to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
    	invalid key 
 		move 2 				to err-ind 
		perform za0-common-error	thru za0-99-exit 
       		go to aa0-10. 
 
 
    move ws-request-clinic-ident		to h1-clinic-nbr. 
    move iconst-date-period-end-yy 	  	to h1-year  
    move iconst-date-period-end-dd 		to h1-day. 
    move mth-desc (iconst-date-period-end-mm)	to h1-month. 
    move iconst-clinic-name			to h2-clinic.     
 
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
 
 
 
************************************** 
 
 
    open input  docrev-mstr 
		dept-mstr 
                loc-mstr 
 	        doc-mstr. 
    open output print-file. 
 
    close iconst-mstr. 
 
 
 
    perform aa1-zero-counters			thru aa1-99-exit 
	varying x-from from 1 by 1 
	until x-from is greater than 5. 
   
    move 90 to line-cnt. 
 
aa0-99-exit.  exit. 
 
aa1-zero-counters. 
 
    move 0		to	mtd-in-rec (x-from) 
				mtd-in-svc (x-from) 
				mtd-out-rec (x-from) 
				mtd-out-svc (x-from) 
				mtd-misc-rec (x-from) 
				mtd-misc-svc (x-from) 
 
				ytd-in-rec (x-from) 
				ytd-in-svc (x-from) 
				ytd-out-rec (x-from) 
				ytd-out-svc (x-from) 
				ytd-misc-rec (x-from) 
				ytd-misc-svc (x-from). 
 
aa1-99-exit.  exit. 
 
ab0-create-sort-file section. 
 
ab0-10-open-files. 
 
    move zeros				to docrev-key. 
    move iconst-clinic-nbr-1-2		to docrev-clinic-1-2. 
 
    perform ra3-read-docrev-approx	thru ra3-99-exit. 
 
ab0-20-read-docrev. 
 
    if docrev-clinic-1-2 = high-values 
    then 
        go to ab0-99-exit.  
*   (else) 
*   endif 
 
    move docrev-master-rec		to	sort-docrev-rec. 
    release sort-docrev-rec. 
    move docrev-key			to save-area. 
    perform ra0-read-next-docrev	thru 	ra0-99-exit. 
    go to ab0-20-read-docrev. 
 
ab0-99-exit. 
    exit. 
ra0-read-next-docrev. 
 
*mf    read docrev-mstr  next 
*mf	invalid key 
*mf          move high-values to docrev-clinic-1-2 
*mf            go to ra0-99-exit. 
 
    read docrev-mstr  next 
	at end
	move high-values to docrev-clinic-1-2 
           go to ra0-99-exit. 
 
    
    if docrev-clinic-1-2 < ws-request-clinic-ident 
    then 
	go to ra0-read-next-docrev 
    else 
	if docrev-clinic-1-2 > ws-request-clinic-ident 
	then 
	    move high-values to docrev-clinic-1-2 
	    go to ra0-99-exit 
 	else 
	    next sentence. 
*	endif 
*   endif 
 
    add 1 to docrev-read. 
 
ra0-99-exit. 
    exit. 
 
 
 
ra3-read-docrev-approx. 
 
*mf    read docrev-mstr key is docrev-key approximate 
*mf	invalid key 
*mf	    move 3			to err-ind     
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-finalization. 

    start docrev-mstr key is greater than or equal to docrev-key
	invalid key 
	    move 3			to err-ind     
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-finalization. 
    read docrev-mstr next.
 
    
    add 1				to docrev-read. 
 
ra3-99-exit. 
    exit. 
ba0-process-records section. 
 
 
ba0-7-read-sort-file. 
 
    return sort-docrev-file 
           at end  
                 go to ba0-99-exit. 
 
    move wk-docrev-key		to save-area. 
 
ba0-10-process-records. 
 
* 2011/09/15 - MC1 - check the clinic is the same before continue
    if wk-docrev-clinic-1-2 not = ws-request-clinic-ident
    then
        go to ba0-99-exit.
*   endif
* 2011/09/15

 
	if wk-docrev-location = save-location 
	then 
	    if wk-docrev-doc-nbr = save-doc-nbr      
	    then 
  	       	if wk-docrev-oma-cd = save-oma 
		then 
		    perform ba1-add-to-areas	thru ba1-99-exit 
		else 
		    perform ba2-oma-line		thru ba2-99-exit 
		    perform ba1-add-to-areas	thru ba1-99-exit 
*		endif       
	    else 
		perform ba2-oma-line			thru ba2-99-exit 
		perform ba5-doctor-total		thru ba5-99-exit 
		perform ba6-doctor-header		thru ba6-99-exit 
		perform ba1-add-to-areas		thru ba1-99-exit 
*	    endif 
	else 
	    perform ba2-oma-line			thru ba2-99-exit 
	    perform ba5-doctor-total			thru ba5-99-exit 
	    move 3 to level 
	    perform ba7-location-total			thru ba7-99-exit 
	    move wk-docrev-key				to save-area 
	    perform xd0-heading-lines			thru xd0-99-exit 
	    perform ba1-add-to-areas			thru ba1-99-exit. 
*	endif 
 
    move wk-docrev-key					to save-area. 
 
    return sort-docrev-file 
           at end 
               go to ba0-99-exit. 
 
    go to ba0-10-process-records. 
 
ba1-add-to-areas. 
 
    if wk-docrev-location not = "MISC" 
    then 
	add wk-docrev-mtd-in-rec 		to	mtd-in-rec (1) 
	add wk-docrev-mtd-in-svc		to	mtd-in-svc (1) 
	add wk-docrev-mtd-out-rec		to	mtd-out-rec (1) 
	add wk-docrev-mtd-out-svc		to	mtd-out-svc (1) 
	add wk-docrev-ytd-in-rec		to	ytd-in-rec (1) 
	add wk-docrev-ytd-in-svc		to	ytd-in-svc (1) 
	add wk-docrev-ytd-out-rec		to	ytd-out-rec (1) 
	add wk-docrev-ytd-out-svc		to	ytd-out-svc (1) 
    else 
	add wk-docrev-mtd-out-rec		to	mtd-misc-rec (1) 
	add wk-docrev-mtd-out-svc		to	mtd-misc-svc (1) 
	add wk-docrev-ytd-out-rec		to	ytd-misc-rec (1) 
	add wk-docrev-ytd-out-svc		to	ytd-misc-svc (1). 
*   endif 
 
ba1-99-exit.  exit. 
 
 
ba2-oma-line. 
 
    move save-oma			to	d2-oma-code. 
    move 1 to x-from. 
    perform xa0-move-totals		thru	xa0-99-exit. 
    perform xb0-print-line		thru	xb0-99-exit. 
 
    move 1 to x-from. 
    move 2 to x-to. 
 
    perform xc0-bump-totals		thru	xc0-99-exit. 
 
ba2-99-exit.  exit. 
 
ba4-location-header. 
 
    move save-location			to 	loc-nbr. 
    perform ra1-read-loc-mstr		thru	ra1-99-exit. 
    move "LOCATION"			to 	h4-header-title. 
    move save-location			to	h4-doc-or-loc-nbr. 
    move loc-name			to  	h4-doc-or-loc-name. 
    write prt-line from head-line-4	after advancing 2 lines. 
    add 2 to line-cnt. 
 
ba4-99-exit. exit. 
 
 
 
ba5-doctor-total. 
 
    move "*DOC*"			to	d2-oma-code. 
    move 2 to x-from. 
    perform xa0-move-totals		thru	xa0-99-exit. 
    perform xb0-print-line		thru	xb0-99-exit. 
    move 2 to x-from. 
    move 3 to x-to. 
    perform xc0-bump-totals		thru	xc0-99-exit. 
 
ba5-99-exit.  exit. 
 
ba6-doctor-header. 
 
    move wk-docrev-dept 		to 	d1-dept-nbr 
						dept-nbr. 
    perform ra4-read-dept-mstr		thru	ra4-99-exit. 
    move dept-name 			to	d1-dept-name. 
    move wk-docrev-doc-nbr		to	doc-nbr. 
    perform ra2-read-doc-mstr		thru	ra2-99-exit. 
*   move "DOCTOR #"			to 	h4-header-title. 
*   move wk-docrev-doc-nbr		to	h4-doc-or-loc-nbr. 
*   move doc-name			to	h4-doc-or-loc-name. 
*   write prt-line from head-line-4	after	advancing 2 lines. 
    move wk-docrev-doc-nbr		to	d1-doc-nbr. 
    move doc-name			to	d1-doc-name. 
    write prt-line from detail-line-1   after   advancing 2 lines. 
    add 2 to line-cnt. 
 
ba6-99-exit.  exit. 
 
 
ba61-doctor-header. 
 
    move save-dept			to	d1-dept-nbr 
                                                dept-nbr. 
    perform ra4-read-dept-mstr		thru	ra4-99-exit. 
    move dept-name 			to	d1-dept-name. 
    move save-doc-nbr 			to	doc-nbr. 
    perform ra2-read-doc-mstr		thru	ra2-99-exit. 
*   move "DOCTOR #"			to 	h4-header-title. 
*   move save-doc-nbr			to	h4-doc-or-loc-nbr. 
*   move doc-name			to	h4-doc-or-loc-name. 
*   write prt-line from head-line-4	after	advancing 2 lines. 
    move save-doc-nbr			to	d1-doc-nbr. 
    move doc-name			to	d1-doc-name. 
    write prt-line from detail-line-1   after	advancing 2 lines. 
    add 2 to line-cnt. 
 
ba61-99-exit.  exit. 
 
ba7-location-total. 
 
    if line-cnt > 52 
    then 
	perform xd0-heading-lines	thru	xd0-99-exit. 
 
 
    move save-location			to	t1-location.   
 
    if level = 3 
    then  
        write prt-line from total-line-1	after	advancing 3 lines    
    else 
        write prt-line from total-line-1a	after 	advancing 3 lines. 
*  (endif) 
 
    write prt-line from total-line-2	after	advancing 2 lines. 
 
    move mtd-in-svc (level)		to	t3-in-svc. 
    move mtd-in-rec (level)		to	t3-in-rec. 
    move mtd-out-svc (level)		to	t3-out-svc. 
    move mtd-out-rec (level)		to	t3-out-rec. 
 
    move mtd-misc-svc (level)		to	t3-misc-svc. 
    move mtd-misc-rec (level)		to	t3-misc-rec. 
 
    add mtd-in-svc (level) mtd-out-svc (level) mtd-misc-svc (level)  
					giving	total-svc. 
    add mtd-in-rec (level) mtd-out-rec (level) mtd-misc-rec (level) 
					giving	total-rec. 
    move total-svc			to	t3-tot-svc. 
    move total-rec			to	t3-tot-rec. 
 
    move "MONTH TO DATE"		to	t3-title. 
 
    write prt-line from total-line-3	after	advancing 2 lines. 
 
    if line-cnt > 52 
    then 
	perform xd0-heading-lines	thru	xd0-99-exit. 
 
 
 
    move ytd-in-svc (level)		to	t3-in-svc. 
    move ytd-in-rec (level)		to	t3-in-rec. 
    move ytd-out-svc (level)		to	t3-out-svc. 
    move ytd-out-rec (level)		to	t3-out-rec. 
 
    move ytd-misc-svc (level)		to	t3-misc-svc. 
    move ytd-misc-rec (level)		to	t3-misc-rec. 
 
    add ytd-in-svc (level) ytd-out-svc (level) ytd-misc-svc (level)  
					giving	total-svc. 
    add ytd-in-rec (level) ytd-out-rec (level) ytd-misc-rec (level) 
					giving	total-rec. 
    move total-svc			to	t3-tot-svc. 
    move total-rec			to	t3-tot-rec. 
 
    move "YEAR TO DATE" 		to	t3-title. 
 
    write prt-line from total-line-3	after	advancing 2 lines. 
 
    if level = 3 
    then 
	move 3 to x-from  
	move 4 to x-to  
	perform xc0-bump-totals		thru	xc0-99-exit. 
*   (else) 
*   endif 
 
    move 90 to line-cnt. 
 
ba7-99-exit.  exit. 
 
ra1-read-loc-mstr. 
 
    read loc-mstr 
	invalid key move "N" to flag  
       		    move "INVALID LOCATION" 	to 	loc-name  
		    go to ra1-99-exit. 
 
 
    add 1 to loc-mstr-read. 
 
 
 
ra1-99-exit.  exit. 
 
ra2-read-doc-mstr. 
 
    read doc-mstr 
	invalid key move "N" to flag  
                    move "INVALID DOCTOR"	to doc-name  
		    go to ra2-99-exit. 
 
    add 1 to doc-mstr-read. 
 
ra2-99-exit.  exit. 
 
 
ra4-read-dept-mstr. 
 
    read dept-mstr 
	invalid key 
	    move "N" to flag 
	    move "UNKNOWN DEPT"		to dept-name 
            go to ra2-99-exit. 
 
    add 1 to dept-mstr-read. 
 
ra4-99-exit. 
    exit. 
 
 
 
xa0-move-totals. 
 
    move mtd-in-rec (x-from)		to	d2-mtd-in-rec. 
    move mtd-in-svc (x-from)		to	d2-mtd-in-svc. 
    move mtd-out-rec (x-from)		to	d2-mtd-out-rec. 
    move mtd-out-svc (x-from) 		to	d2-mtd-out-svc. 
    move mtd-misc-rec (x-from)		to	d2-mtd-misc-rec. 
    move mtd-misc-svc (x-from)		to	d2-mtd-misc-svc.  
    move ytd-in-rec (x-from)		to	d2-ytd-in-rec. 
    move ytd-in-svc (x-from)		to	d2-ytd-in-svc. 
    move ytd-out-rec (x-from)		to	d2-ytd-out-rec. 
    move ytd-out-svc (x-from)		to	d2-ytd-out-svc. 
    move ytd-misc-rec (x-from)		to	d2-ytd-misc-rec. 
    move ytd-misc-svc (x-from)		to	d2-ytd-misc-svc. 
 
    add mtd-in-rec (x-from) mtd-out-rec (x-from) mtd-misc-rec (x-from) 
					giving	total-mtd-rec. 
    add mtd-in-svc (x-from) mtd-out-svc (x-from) mtd-misc-svc (x-from) 
					giving	total-mtd-svc. 
 
    add ytd-in-rec (x-from) ytd-out-rec (x-from) ytd-misc-rec (x-from) 
					giving	total-ytd-rec. 
    add ytd-in-svc (x-from) ytd-out-svc (x-from) ytd-misc-svc (x-from) 
					giving	total-ytd-svc. 
 
    move total-mtd-rec			to	d2-mtd-tot-rec. 
    move total-mtd-svc			to	d2-mtd-tot-svc. 
    move total-ytd-rec			to	d2-ytd-tot-rec. 
    move total-ytd-svc			to	d2-ytd-tot-svc. 
 
xa0-99-exit.  exit. 
 
xb0-print-line. 
    
    add 1 to line-cnt. 
    if line-cnt > 60 
    then 
	perform xd0-heading-lines	thru	xd0-99-exit. 
*   (else) 
*   endif 
 
    write prt-line from detail-line-2	after	advancing 1 line. 
 
xb0-99-exit.  exit. 
 
xc0-bump-totals. 
 
    add mtd-in-rec (x-from)		to	mtd-in-rec (x-to) 
    add mtd-in-svc (x-from)		to	mtd-in-svc (x-to) 
    add mtd-out-rec (x-from)		to	mtd-out-rec (x-to) 
    add mtd-out-svc (x-from)		to	mtd-out-svc (x-to) 
    add mtd-misc-rec (x-from)		to	mtd-misc-rec (x-to) 
    add mtd-misc-svc (x-from)		to	mtd-misc-svc (x-to) 
 
    add ytd-in-rec (x-from)		to	ytd-in-rec (x-to) 
    add ytd-in-svc (x-from)		to	ytd-in-svc (x-to) 
    add ytd-out-rec (x-from)		to	ytd-out-rec (x-to) 
    add ytd-out-svc (x-from)		to	ytd-out-svc (x-to) 
    add ytd-misc-rec (x-from)		to	ytd-misc-rec (x-to) 
    add ytd-misc-svc (x-from)		to	ytd-misc-svc (x-to) 
 
    move 0				to	mtd-in-rec (x-from) 
                                                mtd-in-svc (x-from) 
                                                mtd-out-rec (x-from) 
                                                mtd-out-svc (x-from) 
                                                mtd-misc-rec (x-from) 
                                                mtd-misc-svc (x-from) 
                                                ytd-in-rec (x-from) 
                                                ytd-in-svc (x-from) 
                                                ytd-out-rec (x-from) 
                                                ytd-out-svc (x-from) 
                                                ytd-misc-rec (x-from) 
                                                ytd-misc-svc (x-from). 
 
xc0-99-exit.  exit. 
 
xd0-heading-lines. 
 
    add 1 to page-cnt 
    move page-cnt to h1-page. 
    write prt-line from head-line-1 after advancing page.    
    write prt-line from head-line-2 after advancing 1 line. 
 
    perform ba4-location-header		thru ba4-99-exit. 
 
    write prt-line from head-line-5 after advancing 2 lines. 
    write prt-line from head-line-6 after advancing 1 line. 
    write prt-line from blank-line after advancing 1 line. 
 
    move 7 to line-cnt. 
 
    perform ba61-doctor-header		thru ba61-99-exit. 
 
xd0-99-exit.  exit. 
 
 
ba0-99-exit.  exit. 
 
 
az0-finalization section. 
 
    perform ba2-oma-line		thru	ba2-99-exit. 
    perform ba5-doctor-total		thru	ba5-99-exit. 
    move 3 to level 
    perform ba7-location-total		thru	ba7-99-exit. 
 
    add 1 to page-cnt. 
    move page-cnt to h1-page. 
    write prt-line from head-line-1 after advancing page.     
    write prt-line from head-line-2 after advancing 1 line. 
    set line-cnt to 3. 
    move 4 to level. 
    perform ba7-location-total		thru	ba7-99-exit. 
 
    close loc-mstr 
	  docrev-mstr 
	  doc-mstr 
	  print-file. 
 
    accept sys-time			from time. 
*   display scr-counters. 
*   display scr-closing-screen. 
*   display scr-report-location. 
*   display confirm. 
 
az0-99-exit.  exit. 
 
 
za0-common-error. 
 
    move err-msg (err-ind)		to err-msg-comment. 
*   display err-msg-line. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
 
za0-99-exit.  exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
