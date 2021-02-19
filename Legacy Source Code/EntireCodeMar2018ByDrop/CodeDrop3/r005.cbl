identification division. 
program-id.  r005. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/01/31. 
date-compiled. 
security. 
* 
*	files	: f020 - doctor master 
*		: f051 - doctor cash master 
*		: f090 - constants master 
*		: r005 - monthly cash applied report 
* 
*	program purpose : print the monthly cash applied report. 
* 
*      	revision history: 
* 
*	may/82 (d.m.)	-changed to access new doctor cash master 
*			 instead of doctor revenue master 
*			-changed to access new constants master 
*			-changd to access new doctor master 
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
*  revised jan/98 j. chau  - s149 unix conversion 
*
*  revised 1999/May/07 S.B.	- y2k changes to headers.
*  2003/dec/09 M.C. 	- alpha doc nbr
 
environment division. 
input-output section. 
file-control. 
* 
    copy "f051_doc_cash_mstr.slr". 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    select print-file 
	assign to printer printer-file-name 
	file status is status-print-file. 
data division. 
file section. 
 
    copy "f051_doc_cash_mstr.fd". 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
 
fd  print-file 
    record contains 132 characters. 
01  prt-line				pic x(132). 
 
working-storage section. 
 
77  ss					pic 99	comp. 
77  ss-agent				pic 99  comp. 
77  ss-const				pic 99	comp. 
77  ws-closing-msg			pic x(30)	value 
		"REPORT IS IN FILE R005". 
77  ss-from				pic 999	comp. 
77  ss-to				pic 999	comp. 
77  agent 				pic 99	comp. 
77  dept				pic 99  comp. 
 
77  eof-docash-mstr			pic x	value "N". 
 
*mf 77  status-file			pic x(11) value zeros. 
*mf 77  status-doc-mstr			pic x(11) value zeros. 
*mf 77  status-docash-mstr		pic x(11) value zeros. 
*mf 77  status-iconst-mstr		pic x(11) value zeros. 

77  status-file				pic xx    value zeros. 
77  status-cobol-doc-mstr		pic xx    value zeros. 
77  status-cobol-docash-mstr		pic xx    value zeros. 
77  status-cobol-iconst-mstr		pic xx	  value zeros. 
77  status-audit-rpt			pic xx    value zeros. 
77  status-print-file			pic xx    value zeros. 
77  feedback-docash-mstr		pic x(4)  value zeros. 
77  feedback-iconst-mstr		pic x(4)  value zero. 
 
77  printer-file-name			pic x(4) value "r005". 
 
77  page-cnt				pic 9(5). 
77  doc-mtd-total			pic s9(10)v99. 
77  doc-ytd-total			pic s9(10)v99. 
77  dept-mtd-total			pic s9(10)v99. 
77  dept-ytd-total			pic s9(10)v99. 
77  final-totals-being-printed		pic x	value "N". 
77  doc-desc-2b-printed			pic x. 
77  docash-agency-type-r		pic 99.   
77  line-cnt				pic 99. 
77  err-ind				pic 9. 
77  ws-reply				pic x. 
77  ws-temp-cash			pic s9(8)v99. 
 
77  docash-read				pic 9(7). 
77  doc-mstr-read			pic 9(7). 
77  loc-mstr-read			pic 9(7). 
 
01  save-docash-key. 
    05  save-clinic-1-2			pic x(2).    
    05  save-dept			pic 99. 
*!    05  save-doc-nbr			pic 999. 
    05  save-doc-nbr			pic xxx. 
    05  save-location			pic x999. 
    05  save-oma-cd			pic x(5). 
 
01  request-clinic			pic xxxx.         
 
01  ws-request-clinic-ident		pic xx. 
 
01  blank-line				pic x(132) value spaces. 
 
77  max-nbr-agents			pic 99	value 10. 
77  ss-level-doc			pic 9	value 1. 
77  ss-level-dept			pic 9	value 2. 
77  ss-level-grand			pic 9	value 3. 
 
01  counters. 
*	(level 1 = doctor     totals 
*	 level 2 = department totals 
*	 level 3 = grand      totals) 
    05  totals	occurs 3 times. 
*	    (slots 1 thru 9 hold agents 1 thru 9 and agent 0 stored in 10) 
        10  by-agent	occurs 10 times. 
	    15  agent-code		pic x. 
	    15  mtd-total		pic s9(10)v99. 
	    15  ytd-total		pic s9(10)v99. 
 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler			pic x(60)	value 
		"INVALID REPLY". 
	10  filler			pic x(60)	value 
		"INVALID CLINIC NUMBER". 
	10  filler			pic x(60)	value 
	        "NO CASH RECORDS FOR THIS CLINIC". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg			pic x(60) 
		occurs 3 times. 
 
01  err-msg-comment			pic x(60). 
01  l1-detail-line. 
    05  filler				pic x(3)	value spaces. 
    05  l1-dept-nbr			pic 99. 
    05  filler				pic x(11) 	value spaces. 
    05  l1-doctor-nbr			pic x(5). 
    05  filler				pic x(4) 	value spaces. 
    05  l1-doctor-name			pic x(21). 
    05  filler				pic xx  	value spaces. 
    05  l1-agent			pic 9.        
    05  filler				pic xx		value spaces. 
    05  l1-mtd-cash			pic z,zzz,zzz.99-. 
    05  filler				pic x		value spaces. 
    05  l1-ytd-cash			pic zz,zzz,zzz.99-. 
    05  filler				pic x(44)	value spaces. 
 
01  t1-doctor-total. 
    05  filler				pic x(30)	value spaces. 
    05  filler				pic x(12)	value 
		"DOCTOR TOTAL". 
    05  filler				pic x(7)	value spaces. 
    05  t1-mtd				pic zzz,zzz,zzz.99-. 
    05  t1-ytd				pic zzz,zzz,zzz.99-. 
    05  filler				pic x(53)	value spaces. 
 
01  t2-dept-total-title. 
    05  t2-department-or-agent		pic x(18). 
    05  t2-grand-or-agent		pic x(7). 
    05  filler				pic x(12)	value 
		"TOTAL **    ". 
    05  t2-dept-or-agent		pic x(19). 
    05  filler				pic x(5)	value "MONTH". 
    05  filler				pic x(11)	value spaces. 
    05  filler				pic x(7)	value  
		"YEAR TO". 
    05  filler				pic x(53)	value spaces. 
 
01  t2-dept-total-title-2. 
    05  filler				pic x(55)	value spaces. 
    05  filler				pic x(7)	value 
		"TO DATE". 
    05  filler				pic x(13)	value spaces. 
    05  filler				pic x(4)	value "DATE". 
    05  filler				pic x(53)	value spaces. 
 
01  t3-dept-total-detail. 
    05  filler				pic x(39)	value spaces. 
    05  t3-agent			pic 9. 
    05  filler				pic x(8)	value spaces. 
    05  t3-mtd				pic zzz,zzz,zzz.99-. 
    05  filler				pic xx		value spaces. 
    05  t3-ytd				pic zzz,zzz,zzz.99-. 
    05  filler				pic x(53)	value spaces. 
 
01  t4-dept-final-total. 
    05  filler				pic x(12)	value spaces. 
    05  t4-dept-nbr			pic z9.       
    05  filler				pic x(23)	value spaces. 
    05  filler				pic x(5)	value "TOTAL". 
    05  filler				pic x(6)	value spaces. 
    05  t4-mtd				pic zzz,zzz,zzz.99-. 
    05  filler				pic xx		value "*". 
    05  t4-ytd				pic zzz,zzz,zzz.99-. 
    05  filler				pic x(51)	value "*".    
 
01  h1-head-line. 
    05  filler				pic x(7) 	value "R005". 
    05  filler				pic x		value "/". 
    05  h1-clinic-nbr			pic 99. 
    05  filler				pic x		value spaces. 
    05  h1-alpha-month			pic x(9). 
    05  filler				pic x		value spaces. 
    05  h1-num-day			pic z9.   
* (y2k)
*    05  filler				pic xxxx	value ", 19". 
    05  filler				pic xx	 	value spaces.
* (y2k)
*    05  h1-year				pic xx. 
    05  h1-year				pic xxxx. 
    05  filler				pic x  		value spaces. 
    05  filler				pic x(31)	value 
		"* MONTHLY CASH APPLIED REPORT *". 
    05  filler				pic xx  	value spaces. 
* (y2k)
*    05  h1-yy				pic 99. 
    05  h1-yy				pic 9999. 
    05  filler				pic x		value "/". 
    05  h1-mm				pic 99. 
    05  filler				pic x		value "/". 
    05  h1-dd				pic 99. 
    05  filler				pic x(7)	value "  PAGE ". 
    05  h1-page				pic zz9. 
* (y2k)
*    05  filler				pic x(61)	value spaces. 
    05  filler				pic x(59)	value spaces. 
 
01  h1a-clinic-line. 
 
    05  filler				pic x(34)	value spaces. 
    05  h1a-clinic-name			pic x(20). 
    05  filler				pic x(78)	value spaces. 
 
01  h2-head-line. 
    05  filler				pic x(15)	value 
		"DEPARTMENT". 
    05  filler				pic x(10)	value 
		"DOCTOR". 
    05  filler				pic x(20)	value 
		"DOCTOR". 
    05  filler				pic x(12)	value 
		"AGENT". 
    05  filler				pic x(14)	value 
		"MONTH". 
    05  filler				pic x(61)	value 
		"YEAR TO". 
 
01  h3-head-line. 
    05  filler				pic x(15)	value 
		"  NUMBER". 
    05  filler				pic x(11)	value 
		"NUMBER". 
    05  filler				pic x(20)	value 
		"NAME". 
    05  filler				pic x(10)	value 
		"CODE". 
    05  filler				pic x(17)	value 
		"TO DATE". 
    05  filler				pic x(59)	value 
		"DATE". 
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
 
err-docash-mstr-file section. 
    use after standard error procedure on docash-mstr. 
err-docash-mstr. 
    stop "ERROR IN ACCESSING DOCASH MASTER ". 
*mf    move status-docash-mstr		to status-file. 
    move status-cobol-docash-mstr	to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING DOCTOR MSTR ". 
*mf    move status-doc-mstr  		to status-file. 
    move status-cobol-doc-mstr  	to status-file. 
*   display file-status-display. 
    display status-file. 
    stop run. 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru	aa0-99-exit. 
    perform ab0-process-records		thru 	ab0-99-exit 
		until eof-docash-mstr = "Y". 
    perform az0-finalization		thru	az0-99-exit. 
    stop run. 
aa0-initialization. 
 
    accept sys-date			from 	date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-yy				to	run-yy.  
    move sys-mm				to	run-mm. 
    move sys-dd				to	run-dd. 
 
    open input iconst-mstr. 
 
*   display scr-title. 
 
aa0-10. 
*   accept scr-clinic-nbr. 
    accept ws-request-clinic-ident 
 
    move ws-request-clinic-ident	to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 2 				to err-ind      
	    perform za0-common-error		thru za0-99-exit 
	    go to  aa0-10. 
 
    move iconst-clinic-nbr-1-2			to h1-clinic-nbr. 
    move iconst-date-period-end-yy 	  	to h1-year. 
    move iconst-date-period-end-dd 		to h1-num-day. 
    move mth-desc (iconst-date-period-end-mm)	to h1-alpha-month. 
    move iconst-clinic-name			to h1a-clinic-name.     
    move "     ** DEPARTMENT"			to t2-department-or-agent. 
 
*   display msg-month. 
 
*   display msg-continue. 
 
aa0-20. 
 
*   accept reply. 
    accept ws-reply 
 
    if ws-reply = "Y" 
    then 
*	display program-in-progress 
       continue
    else 
	if ws-reply = "N" 
	then 
	    go to az0-100-end-job 
	else 
	    move 1				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to aa0-20. 
*	endif 
*   endif 
 
*    expunge print-file. 
    open input  doc-mstr 
                docash-mstr. 
 
    open output print-file. 
 
    perform aa1-zero-counters		thru aa1-99-exit 
	varying ss-from 
	from    1 by 1 
	until   ss-from > ss-level-grand. 
 
    move run-yy				to h1-yy. 
    move run-mm				to h1-mm.                    
    move run-dd				to h1-dd. 
 
    move zeros				to docash-key. 
    move iconst-clinic-nbr-1-2 		to docash-clinic-1-2. 
 
    perform rb0-read-docash-approx	thru	rb0-99-exit. 
    if   eof-docash-mstr = "Y" 
      or docash-clinic-1-2 not = ws-request-clinic-ident 
    then              
        move  3     			to	err-ind         
	perform za0-common-error	thru	za0-99-exit 
        go to az0-10-error-shutdown. 
*   (else) 
*   endif 
 
    move docash-key 			to save-docash-key. 
    move 90 				to line-cnt. 
 
aa0-99-exit. 
    exit. 

aa1-zero-counters. 
 
    perform aa10-zero-cntrs		thru aa10-99-exit 
	varying ss-to 
	from    1 by 1  
	until   ss-to > max-nbr-agents. 
 
aa1-99-exit. 
    exit. 
 
 
 
aa10-zero-cntrs. 
 
    move spaces				to agent-code (ss-from, ss-to). 
 
    move zero				to mtd-total  (ss-from, ss-to) 
					   ytd-total  (ss-from, ss-to). 
 
aa10-99-exit. 
    exit. 
ab0-process-records. 
 
    perform ba0-cash-record		thru	ba0-99-exit. 
 
    perform ra0-read-next-docash	thru	ra0-99-exit. 
    if eof-docash-mstr = "Y" 
    then 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
    if docash-dept = save-dept 
    then 
	if docash-doc-nbr   = save-doc-nbr   
	then 
	    next sentence 
	else 
	    perform ca0-doctor-break	thru	ca0-99-exit 
	    move docash-key		to	save-docash-key 
*	endif 
    else 
	perform ca0-doctor-break	thru	ca0-99-exit 
	perform ea0-dept-break		thru	ea0-99-exit      
	move docash-key			to	save-docash-key. 
*   endif 
 
ab0-99-exit. 
    exit. 
az0-finalization. 
 
*    (print doctor and dept totals for last doctor processed in mainline) 
    perform ca0-doctor-break		thru	ca0-99-exit. 
    perform ea0-dept-break		thru	ea0-99-exit. 
 
 
    perform az1-print-grand-totals	thru	az1-99-exit. 
 
az0-10-error-shutdown. 
    close doc-mstr 
	  docash-mstr 
	  print-file. 
 
az0-100-end-job. 
 
    accept sys-time			from time. 
*   display scr-counters. 
*   display scr-closing-screen. 
*   display scr-report-location. 
*   display confirm. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
 
az1-print-grand-totals. 
 
    move spaces				to 	t2-department-or-agent. 
    move "          ** AGENT"		to	t2-department-or-agent. 
    move " GRAND"			to	t2-grand-or-agent. 
    move "AGENT"			to	t2-dept-or-agent. 
    perform wa1-heading-routine		thru	wa1-99-exit. 
 
    write prt-line from t2-dept-total-title	after advancing 3 lines. 
    write prt-line from t2-dept-total-title-2	after advancing 1 line. 
 
    move "Y"				to	final-totals-being-printed. 
    move ss-level-grand			to	ss-from 
						ss-to. 
    perform eb0-prt-and-roll-tots	thru	eb0-99-exit. 
 
az1-99-exit. 
    exit. 
ba0-cash-record. 
 
*    (agent 0 is 'OHIP' cash from r.a.t. tape application u030 - use subscript 10 for 0)       
 
    if docash-agency-type = 0 
    then  
	move 10				to 	ss-agent 
    else 
	move docash-agency-type 	to 	ss-agent. 
*   endif 
 
*	('X' flag indicates that non-zero values stored in this level of 
*	 array and used later to determine if level should be printed in report) 
 
    move "X"				to	agent-code (ss-level-doc, ss-agent).         
 
    add docash-mtd-in-rec		to	mtd-total (ss-level-doc, ss-agent). 
    add docash-ytd-in-rec		to	ytd-total (ss-level-doc, ss-agent). 
 
ba0-99-exit. 
    exit. 
ca0-doctor-break. 
 
    move save-dept		to	l1-dept-nbr. 
    move save-doc-nbr  		to	l1-doctor-nbr 
					doc-nbr. 
 
    move zero			to 	err-ind. 
    perform sa0-read-docmstr	thru	sa0-99-exit. 
 
    if err-ind = zero 
    then 
	move doc-name		to	l1-doctor-name 
    else 
	move spaces          	to	l1-doctor-name. 
*   endif 
 
    move "Y"			to	doc-desc-2b-printed. 
 
    perform cb0-prt-doc-agent-tots	thru	bb1-99-exit  
	varying agent 
	from 1 by 1 
	until   agent > max-nbr-agents. 
 
*   (print total for all agents of doc (even if only 1 agent for doc)) 
    move doc-mtd-total		to 	t1-mtd. 
    move doc-ytd-total		to	t1-ytd. 
    write prt-line from t1-doctor-total after advancing 1 lines. 
    add 1			to	line-cnt. 
 
    move 0			to	doc-mtd-total 
					doc-ytd-total. 
 
    move ss-level-doc		to	ss-from. 
    move ss-level-dept		to 	ss-to. 
 
    perform cd0-clr-doc-agent-tots-and-sum 
					thru	cd0-99-exit        
	varying agent 
	from 1 by 1 
	until   agent > max-nbr-agents. 
 
ca0-99-exit. 
    exit. 
cb0-prt-doc-agent-tots. 
 
*	('X' flag indicates that there are values to be printed in that level of the array) 
 
    if agent-code (ss-level-doc, agent) = "X" 
    then 
	move agent				to	l1-agent 
	move mtd-total (ss-level-doc, agent)	to	l1-mtd-cash 
	move ytd-total (ss-level-doc, agent)	to	l1-ytd-cash 
	add  mtd-total (ss-level-doc, agent)	to	doc-mtd-total 
	add  ytd-total (ss-level-doc, agent)	to	doc-ytd-total 
	perform wa0-write-doc-line		thru	wa0-99-exit. 
*    (else) 
*   endif 
 
bb1-99-exit. 
    exit. 
cd0-clr-doc-agent-tots-and-sum. 
 
    if agent-code (ss-from, agent) = "X" 
    then 
	move agent-code (ss-from, agent)	to agent-code (ss-to, agent) 
	add  mtd-total  (ss-from, agent)	to mtd-total  (ss-to, agent) 
	add  ytd-total  (ss-from, agent)	to ytd-total  (ss-to, agent). 
*   (else) 
*   endif 
 
    move spaces					to agent-code (ss-from, agent). 
    move zero					to mtd-total  (ss-from, agent) 
						   ytd-total  (ss-from, agent). 
 
cd0-99-exit. 
    exit. 
ea0-dept-break. 
 
    move "/AGENT"                	to	t2-grand-or-agent. 
    move "AGENT"			to	t2-dept-or-agent. 
 
    perform wa1-heading-routine		thru	wa1-99-exit.      
 
    write prt-line from t2-dept-total-title after advancing 3 lines. 
    write prt-line from t2-dept-total-title-2 after advancing 1 lines. 
 
    move ss-level-dept			to	ss-from. 
    move ss-level-grand			to	ss-to. 
    perform eb0-prt-and-roll-tots	thru	eb0-99-exit. 
 
ea0-99-exit. 
    exit. 
eb0-prt-and-roll-tots. 
 
    move save-dept			to 	dept. 
 
    perform eb1-prt-agent-tots		thru 	eb1-99-exit 
	varying agent 
	from    1 by 1 
	until   agent > max-nbr-agents. 
  
    perform eb2-roll-agent-tots		thru 	eb2-99-exit 
	varying agent 
	from    1 by 1 
	until   agent > max-nbr-agents. 
 
    if final-totals-being-printed = "Y" 
    then 
*mf	move spaces			to	t4-dept-nbr 
	move zero 			to	t4-dept-nbr 
    else 
	move save-dept			to	t4-dept-nbr. 
*   endif 
  
    move dept-mtd-total			to	t4-mtd.      
    move dept-ytd-total			to	t4-ytd. 
 
    write prt-line			from t4-dept-final-total  
					     after advancing 2 lines. 
 
    move 70				to	line-cnt.   
    move zero				to	dept-mtd-total 
						dept-ytd-total. 
 
eb0-99-exit. 
    exit. 
eb1-prt-agent-tots. 
 
    if agent-code (ss-from, agent) = "X" 
    then 
*	(print 'FROM' level) 
	move agent			to	t3-agent   
	move mtd-total (ss-from, agent)	to	t3-mtd 
	move ytd-total (ss-from, agent)	to	t3-ytd 
	write prt-line			from	t3-dept-total-detail  
						after advancing 2 lines. 
*   (else) 
*   endif 
 
eb1-99-exit. 
    exit. 
 
 
eb2-roll-agent-tots. 
 
    if agent-code (ss-from, agent) = "X" 
    then 
*	(roll tots up a level) 
	add  mtd-total (ss-from, agent)	to	dept-mtd-total rounded 
	add  ytd-total (ss-from, agent)	to	dept-ytd-total rounded 
	if final-totals-being-printed = "N" 
	then 
	    move "X"			to	agent-code (ss-to, agent) 
	    add  mtd-total (ss-from, agent) 
					to	mtd-total  (ss-to, agent)rounded 
	    add  ytd-total (ss-from, agent) 
					to	ytd-total  (ss-to, agent)rounded 
	    move spaces			to	agent-code (ss-from, agent) 
	    move zero			to	mtd-total  (ss-from, agent) 
						ytd-total  (ss-from, agent). 
*   (else) 
*   endif 
 
eb2-99-exit. 
    exit. 
ra0-read-next-docash. 
 
    read  docash-mstr   next 
	at end 
	    move "Y"			to	eof-docash-mstr 
	    go to ra0-99-exit. 
 
    if docash-clinic-1-2 not = ws-request-clinic-ident 
    then 
	move "Y"			to	eof-docash-mstr 
	go to ra0-99-exit. 
*   (else) 
*   endif  
 
 
    add 1				to docash-read. 
 
ra0-99-exit. 
    exit. 
 
 
 
rb0-read-docash-approx. 
 
*mf    read docash-mstr key is docash-key approximate 
*mf	invalid key 
*mf	    move "Y"			to eof-docash-mstr 
*mf	    go to rb0-99-exit. 

    start docash-mstr key is greater than or equal to docash-key
	invalid key 
	    move "Y"			to eof-docash-mstr 
	    go to rb0-99-exit. 
    read docash-mstr next.
    
    add 1				to docash-read. 
 
 
rb0-99-exit. 
    exit. 
sa0-read-docmstr. 
 
    move zero				to err-ind. 
 
    read doc-mstr 
	invalid key 
	    move 4			to err-ind  
	    go to sa0-99-exit. 
 
    add 1				to doc-mstr-read. 
 
sa0-99-exit. 
    exit. 
wa0-write-doc-line. 
 
    if line-cnt > 60 
    then 
	perform wa1-heading-routine	thru wa1-99-exit. 
*   (else) 
*   endif 
 
    if doc-desc-2b-printed = "N" 
    then 
*mf	move spaces		to l1-dept-nbr 
	move zero		to l1-dept-nbr 
	move space		to  l1-doctor-nbr 
				   l1-doctor-name 
	write prt-line from l1-detail-line after advancing 1 lines 
	add 1			to line-cnt 
    else 
	move "N"		to doc-desc-2b-printed  
	write prt-line from l1-detail-line after advancing 2 line  
	add 2			to line-cnt. 
*   endif 
 
wa0-99-exit. 
    exit. 
 
 
 
wa1-heading-routine. 
 
    add 1				to page-cnt. 
    move page-cnt			to h1-page. 
 
    write prt-line from h1-head-line	after advancing page. 
    write prt-line from h1a-clinic-line	after advancing 1 lines. 
 
wa1-49-exit. 
 
    write prt-line from h2-head-line	after advancing 3 lines. 
    write prt-line from h3-head-line	after advancing 1 lines. 
 
    write prt-line from blank-line	after advancing 1 lines. 
 
    move 7				to line-cnt. 
 
wa1-99-exit. 
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
