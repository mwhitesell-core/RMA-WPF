identification division. 
program-id. u993. 
author. dyad technologies inc. 
installation. rma. 
date-written. 86/02/19. 
date-compiled. 
security. 
* 
*    files      : f010 - patient master 
*		: f090 - constants master 
*		: "ru993" - audit report file 
* 
*    program purpose : this program is run to fix "DUPLICATE IKEY" 
*        	       problem from m010, patient master maintenance. 
*		       it reads the patient master for each console 
*		       number to determine the last ikey number used. 
*        	       the constants master is then updated with the 
*		       next available number for each console. 
* 
*    revision may/87 (s.b.) - coversion from aos to aos/vs. 
*                             change field size for 
*                             status clause to 2 and 
*                             feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   rev.  91/03/06 (b.m.l.) - sms 138. 
*                           - remove key-pat-mstr from working storage. 
* 
*   rev.  91/04/21 (m.c.)   - sms 138 
*			    - modify in ab1 subroutine for key-pat-mstr 
*			      related fields. 
* 
*   rev.  94/05/31 (m.c.)   - since no ikey with console 1, start with 
*			      console 2 
* 
*   rev.  98/02/03 (j.c.)   - s149 unix conversion
*
*         98/09/21 (b.e.)   - reversed change from 940531 - when moving to MF cobol
*			      there is now a console 1.
*
*  	1999/May/20 S.B.    - Y2K checked.
*	2002/apr/29 B.E.    - removed extra display statements so that when
*			      begin/end messages don't appear
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f010_new_patient_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    select audit-file 
          assign to printer print-file-name 
	  file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
    copy "f010_patient_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_5.ws". 
 
 
fd  audit-file 
    record contains 132 characters. 
 
01  audit-record 				pic x(132). 
 
 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) value "ru993". 
		 
77  pat-occur					pic 9(12). 
77  feedback-pat-mstr				pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  con-num                			pic 99. 
77  next-con-num				pic 99. 
* 
*  status file indicators 
* 
01  status-indicators. 
*mf    05  status-file				pic x(11). 
*mf    05  status-pat-mstr			pic x(11) value zero. 
*mf    05  status-iconst-mstr			pic x(11) value zero. 

    05  status-file				pic xx. 
    05  status-cobol-pat-mstr			pic xx    value zero. 
    05  status-cobol-iconst-mstr		pic xx    value zero. 
    05  status-audit-rpt			pic xx    value zero. 
 
**01  key-pat-mstr. 
 
**  05  pat-key-type				pic a. 
**  05  pat-key-o-c-a. 
**	10  pat-key-con-nbr			pic 99. 
**	10  pat-key-i-nbr			pic 9(12). 
**	10  filler				pic x. 
 
 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-iconst-ikey-rewrites		pic 9(7). 
    05  ctr-pat-approx-reads			pic 9(7). 
    05  ctr-pat-backward-reads  		pic 9(7). 
    05  ctr-audit-rpt-writes			pic 9(7). 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"FATAL - NO SUCH CONSTANTS MSTR REC 5". 
	10  filler				pic x(60)   value 
			"FATAL - RE-WRITING CONSTANTS MSTR". 
	10  filler				pic x(60)   value 
			"NO OHIP KEYS ON FILE". 
	10  filler				pic x(60)   value 
			"NO KEYS BELOW I KEYS". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs  4 times. 
 
    copy "sysdatetime.ws". 
 
 
 
01  l1-print-line. 
    05  l1-desc   				pic x(60). 
    05  l1-value				pic z(6)9. 
    05  filler					pic x(65). 
 
 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 12 col 16 value "PROGRAM U993 NOW BEING PROCESSED". 
* 
01  file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
 
* 
01  file-pat-status-display. 
    05  line 24 col 01 "ERROR IN ACCESSING PAT MSTR - KEY = ". 
    05  line 24 col 38	pic x(16) from key-pat-mstr. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U993 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
    05  line 23 col 20	value "AUDIT REPORT IS IN FILE - ". 
    05  line 23 col 51	pic x(5) from print-file-name. 
 
procedure division. 
declaratives. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
*mf    move status-iconst-mstr		to status-file. 
    move status-cobol-iconst-mstr	to status-file. 
    display file-status-display. 
    stop run. 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*mf    move status-pat-mstr		to status-file. 
    move status-cobol-pat-mstr		to status-file. 
    display file-pat-status-display. 
    stop run. 
 
err-audit-rpt-file section. 
    use after standard error procedure on audit-file.     
err-audit-rpt. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE". 
    move status-audit-rpt		to status-file. 
    display file-status-display. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
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
 
 
 
*	delete audit-file 
*    expunge audit-file. 
 
    open input	pat-mstr. 
    open i-o    iconst-mstr. 
    open output audit-file. 
 
    move 0				to   counters. 
 
*	    display scr-title. 
 
    move 5				to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
		move 1 			to	err-ind 
		perform za0-common-error thru	za0-99-exit 
		go to az0-10-end-of-job. 
 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    rewrite iconst-mstr-rec 
	invalid key 
		move 2  		to	err-ind 
		perform za0-common-error thru	za0-99-exit. 
 
    add 1				to ctr-iconst-ikey-rewrites. 
 
    perform az1-totals			thru az1-99-exit. 
 
		 
 
az0-10-end-of-job. 
 
*	    display scr-closing-screen. 
 
 
    close pat-mstr 
	  iconst-mstr 
	  audit-file. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
 
az1-totals. 
 
    move spaces				to l1-print-line. 
    move "NUMBER OF PAT MSTR APPROX READS = " 
					to l1-desc. 
    move ctr-pat-approx-reads  		to l1-value. 
    write audit-record			from l1-print-line after advancing page. 
 
    move spaces				to l1-print-line. 
    move "NUMBER OF PAT MSTR BACKWARDS READS = " 
					to l1-desc. 
    move ctr-pat-backward-reads		to l1-value. 
    write audit-record			from l1-print-line after advancing 2 lines. 
 
    move spaces				to l1-print-line. 
    move "NUMBER OF ICONST IKEY REWRITE = " 
					to l1-desc. 
    move ctr-iconst-ikey-rewrites	to l1-value. 
    write audit-record			from l1-print-line after advancing 2 lines. 
 
    move spaces				to l1-print-line. 
    move "NUMBER OF AUDIT REPORT WRITES = " 
					to l1-desc. 
    move ctr-audit-rpt-writes  		to l1-value. 
    write audit-record			from l1-print-line after advancing 2 lines. 
 
az1-99-exit. 
    exit. 
ab0-processing. 
 
    perform ab1-update-con-ikey		thru ab1-99-exit 
*	varying con-num from 1 by 1 
	varying con-num from 2 by 1 
		until con-num > 25. 
*mf (special read for 25th position)
    perform ab2-update-lastcon-ikey	thru ab2-99-exit.
    
 
ab0-99-exit. 
    exit. 
 
ab1-update-con-ikey. 
    move spaces				to pat-mstr-rec.
 
*   move "I"				to pat-key-type. 
    move "I"				to pat-i-key. 
*   move zero				to pat-key-o-c-a. 
  
    compute     next-con-num  =  con-num  +  1. 
*   move next-con-num			to pat-key-con-nbr. 
    move next-con-num			to pat-con-nbr. 
    move zero				to pat-i-nbr. 
 
*    (read patient master file) 
 
    move zero 				to 	pat-occur. 
 
*mf    read pat-mstr  key is key-pat-mstr approximate 
*mf      at end 
*mf	move 3	  			to	err-ind 
*mf	perform za0-common-error	thru    za0-99-exit 
*mf	go to az0-end-of-job. 
 
    start pat-mstr  key is greater than or equal to key-pat-mstr.
    read pat-mstr next
      at end 
	move 3	  			to	err-ind 
	perform za0-common-error	thru    za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-pat-approx-reads. 
 
*mf    read pat-mstr backward 
    read pat-mstr previous
	at end 
	move 4   			to	err-ind 
	perform za0-common-error	thru    za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-pat-backward-reads. 
 
*mf    retrieve pat-mstr key fix position 
*mf	into key-pat-mstr. 
 
*   if pat-key-type not = "I" 
*   then 
*	go to ab1-99-exit. 
*   endif 
 
    if    pat-con-nbr not = con-num 
    then 
	go to ab1-99-exit. 
*   endif 
 
    compute const-nx-avail-pat(con-num)  =  pat-i-nbr  +  1. 
 
ab1-99-exit. 
    exit. 
ab2-update-lastcon-ikey.

*mf (for the last console the start command must be different that
*mf  what was valid for the lower consoles because no record exists
*mf  to start at. This is a difference in converting from the read
*mf  approximate)

    move 25				to con-num.
    move spaces                         to pat-mstr-rec.
    move "I"                            to pat-i-key.
    compute     next-con-num  =  con-num  +  1.
    move next-con-num                   to pat-con-nbr.
    move zero                           to pat-i-nbr.

*    (read patient master file)
    move zero                           to      pat-occur.              
    start pat-mstr  key is LESS than or equal to key-pat-mstr.
    read pat-mstr next
      at end
        move 3                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
    add 1                               to      ctr-pat-approx-reads.

    if    pat-con-nbr not = con-num
    then
        go to ab2-99-exit.
*   endif

    compute const-nx-avail-pat(con-num)  =  pat-i-nbr  +  1.

ab2-99-exit.
    exit.                      
za0-common-error. 
 
    move err-msg (err-ind)		to	audit-record. 
    write audit-record			after advancing 2 lines. 
    add 1				to ctr-audit-rpt-writes. 
 
za0-99-exit. 
    exit. 
 
 
 

    copy "y2k_default_sysdate_century.rtn".
