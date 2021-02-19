identification division. 
program-id. m070.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 82/06/21. 
date-compiled. 
security. 
* 
*    files      : f070 - dept master 
 
*    program purpose : dept master maintenance.   
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised feb/98 j. chau  - s149 unix conversion
*  1999/jan/15 B.E.             - y2k
*  2003/jan/20 M.C.             - include department company on screen
* 
* 
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f070_dept_mstr.slr". 

* 2003/01/20 - MC
    copy "f123_company_mstr.slr". 
* 2003/01/20 - end

* 
data division. 
file section. 
* 

 
copy "f070_dept_mstr.fd". 

* 2003/01/20 - MC
copy "f123_company_mstr.fd".
* 2003/01/20 - end
* 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
* 
* 
*  eof flags 
* 
77  eof-dept-mstr				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  status-file				pic x(11). 
*mf 77  status-dept-mstr			pic x(11) value zero. 
* 
77  status-file					pic x(2). 
77  status-cobol-dept-mstr			pic x(2) value zero. 

* 2003/01/20 - MC
77  status-cobol-company-mstr			pic x(2) value zero. 
* 2003/01/20 - end

77  confirm-space				pic x   value space. 
* 
 
01  ws-dept-nbr. 
    05  ws-dept-nbr-1				pic x. 
    05  ws-dept-nbr-2				pic x. 
 
01  entry-type					pic x. 
    88  add-code				value "A". 
    88  change-code				value "C". 
    88  delete-code				value "D". 
    88  inquire-code				value "I". 
 
 
01  read-flag					pic x. 
    88 on-file					value "Y". 
    88 not-on-file     				value "N". 
 
01  flag-status					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  acc-mod-rej					pic x. 
    88  accept-screen				value "Y". 
    88  modify-screen				value "M". 
    88  reject-screen    			value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-dept-mstr-reads			pic 9(7). 
    05  ctr-dept-mstr-writes			pic 9(7). 
    05  ctr-dept-mstr-adds			pic 9(7). 
    05  ctr-dept-mstr-changes			pic 9(7). 
    05  ctr-dept-mstr-deletes			pic 9(7). 
* 2003/01/20 - MC
    05  ctr-company-mstr-reads			pic 9(7). 
 
 
*  feedbacks 
* 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(55)   value 
			"INVALID REPLY". 
	10  filler				pic x(55)   value 
			"DEPT ALREADY EXISTS". 
	10  filler				pic x(55)   value 
			"DEPT NBR NOT ON DEPT MASTER". 
	10  filler				pic x(55)   value 
			"DEPT NUMBER MUST BE NUMERIC". 
	10  filler				pic x(55)   value 
			"INVALID WRITE TO DEPT MASTER". 
	10  filler				pic x(55)   value 
			"INVALID RE-WRITE TO DEPT MASTER". 
	10  filler				pic x(55)   value 
			"INVALID DELETE ON DEPT MASTER". 
* 2003/01/20 - MC
	10  filler				pic x(55)   value 
			"COMPANY  NOT ON COMPANY MASTER". 
* 2003/01/20 - end
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(55) 
* 2003/01/20 - mc
*			occurs 7 times. 
			occurs 8 times. 
* 2003/01/20 - end
 
01  err-msg-comment				pic x(55).  
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-titles. 
    05  blank screen. 
    05  line 01 col 01 value "M070".              
    05  line 01 col 11 value "DEPARTMENT MASTER". 
    05  scr-option-sel line 01 col 29 pic x using entry-type auto required. 
    05  line 01 col 31 value "(ADD/CHANGE/DELETE/INQUIRY) DEPT NBR". 
    05  scr-dept-nbr line 01 col 68 pic xx using ws-dept-nbr auto required. 
* (y2k - auto fix)
*   05  line 01 col 73 pic xx/xx/xx from sys-date-long. 
    05  line 01 col 71 pic xxxx/xx/xx from sys-date-long. 
 
 
01  scr-dept-lit. 
    05  line 03 col 01 value "NAME:". 
    05  line 05 col 01 value "ADDRESS:". 
    05  line 09 col 01 value "CHAIRMAN:". 
    05  line 11 col 01 value "CO-ORDINATOR:". 
    05  line 13 col 01 value "NBR OF DOCTORS:". 
* 2003/01/20 - MC - include company
    05  line 15 col 01 value "COMPANY: ". 
* 2003/01/20 - end
 
 
01  scr-dept-var. 
    05  scr-dept-name line 03 col 17 pic x(30) using dept-name auto required. 
    05  scr-dept-addr1 line 05 col 17 pic x(30) using dept-addr1 auto. 
    05  scr-dept-addr2 line 06 col 17 pic x(30) using dept-addr2 auto. 
    05  scr-dept-addr3 line 07 col 17 pic x(30) using dept-addr3 auto. 
    05  scr-dept-chairman line 09 col 17 pic x(25) using dept-chairman auto required. 
    05  scr-dept-co-ordinator line 11 col 17 pic x(25) using dept-co-ordinator auto. 
    05  scr-nbr-of-doctors line 13 col 17 pic zz9 using dept-nbr-docs auto required blank when zero. 
* 2003/01/20 - MC - include company
    05  scr-company        line 15 col 17 pic 99  using dept-company  auto required. 
    05  scr-company-name   line 15 col 20 pic x(40) using company-name.    
* 2003/01/20 - end  
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(55)	from err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-verify-add-change.       
    05  line 22 col 50	value "ACCEPT(Y/N/M) ". 
    05  line 22 col 64	pic x	using acc-mod-rej auto required. 
 
01  scr-inquire. 
    05  line 22 col 50	value "CONTINUE(Y/N) ". 
    05  line 22 col 64	pic x	using acc-mod-rej auto required. 
 
01  scr-delete. 
    05  line 22 col 50	value "DELETE(Y/N) ". 
    05  line 22 col 62	pic x	using acc-mod-rej auto required. 
    05  line 22 col 63  value '  '. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS REJECTED" bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 05 col 20  value "NUMBER OF DEPT-MSTR READS:".   
    05  line 05 col 60  pic z(6)9 from ctr-dept-mstr-reads. 
    05  line 06 col 20  value "NUMBER OF DEPT-MSTR WRITES:".     
    05  line 06 col 60  pic z(6)9 from ctr-dept-mstr-writes. 
    05  line 08 col 20  value "NUMBER OF DEPTS ADDED  :". 
    05  line 08 col 60  pic z(6)9 from ctr-dept-mstr-adds. 
    05  line 10 col 20  value "                CHANGED:". 
    05  line 10 col 60  pic z(6)9 from ctr-dept-mstr-changes. 
    05  line 12 col 20  value "                DELETED:". 
    05  line 12 col 60  pic z(6)9 from ctr-dept-mstr-deletes.                  
* 2003/01/20 - MC
    05  line 13 col 20  value "NUMBER OF COMPANY-MSTR READS:".   
    05  line 13 col 60  pic z(6)9 from ctr-company-mstr-reads. 
* 2003/01/20 - end
    05  line 20 col 20	value "PROGRAM M070 ENDING". 
* (y2k - auto fix)
*   05  line 20 col 40  pic xx/xx/xx from sys-date-long. 
    05  line 20 col 40  pic xxxx/xx/xx from sys-date-long. 
    05  line 20 col 50	pic 99	from sys-hrs. 
    05  line 20 col 52	value ":". 
    05  line 20 col 53	pic 99	from sys-min.        
procedure division. 
declaratives. 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr.       
err-dept-mstr. 
*mf    move status-dept-mstr		to status-file. 
    move status-cobol-dept-mstr		to status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DEPT MASTER". 
    stop run. 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
		until entry-type = "*". 
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
 
    open i-o	dept-mstr. 
* 2003/01/20 - MC
    open input company-mstr.
* 2003/01/20 - end
 
    move spaces				to ws-dept-nbr. 
    display scr-titles. 
    display scr-dept-lit. 
 
    move "*"				to ws-dept-nbr-1. 
    move spaces				to dept-mstr-rec. 
 
    perform xd0-acpt-type-dept-read-dept 
					thru xd0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    display blank-screen. 
    display scr-closing-screen. 
    display confirm. 
 
    close dept-mstr. 
 
    call program "menu". 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    if add-code 
    then 
	if ok 
	then 
	    move 2				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to ab0-95-next-dept 
	else 
	    perform ba0-add-change		thru ba0-99-exit 
	    go to ab0-30-disp-verif 
*	endif 
    else 
	if change-code 
	then 
	    if not-ok 
	    then 
		move 3				to err-ind 
		perform za0-common-error	thru za0-99-exit 
		go to ab0-95-next-dept 
	    else 
		perform ba0-add-change		thru ba0-99-exit 
		go to ab0-30-disp-verif 
*	    endif 
	else 
*	    ( must be delete or inquire ) 
	    if not-ok 
	    then 
		move 3				to err-ind 
		perform za0-common-error	thru za0-99-exit 
		go to ab0-95-next-dept 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 
 
ab0-10-inquire. 
 
    if   inquire-code 
    then 
	move 'Y'				to acc-mod-rej 
	display scr-inquire 
	accept  scr-inquire 
	if   accept-screen 
	  or reject-screen 
	then 
	    if accept-screen 
	    then 
		go to ab0-90-clear-screen 
	    else 
	        move '*'			to entry-type 
		go to ab0-99-exit 
*	    endif 
	else 
	    move 1				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to ab0-10-inquire 
*	endif 
    else 
	next sentence. 
*   endif 
 
ab0-20-delete. 
 
*	( must be a delete ) 
    move 'Y'					to acc-mod-rej. 
    display scr-delete. 
    accept  scr-delete. 
 
    if   accept-screen 
      or reject-screen 
    then 
	if accept-screen 
	then 
	    go to ab0-80-update-rec 
	else 
	    go to ab0-90-clear-screen 
*	endif 
    else 
	move 1					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	go to ab0-20-delete. 
*   endif 
 
ab0-30-disp-verif. 
 
    move 'Y'					to acc-mod-rej. 
    display scr-verify-add-change. 
 
ab0-40-y-n-m. 
 
    accept scr-verify-add-change. 
 
    if accept-screen 
    then 
	next sentence 
    else 
	if modify-screen 
	then 
	    go to ab0-processing 
	else 
	    if reject-screen 
	    then 
		go to ab0-90-clear-screen 
	    else 
		move 1				to err-ind 
		perform za0-common-error	thru za0-99-exit 
		go to ab0-40-y-n-m. 
*	    endif 
*	endif 
*   endif 
 
ab0-80-update-rec. 
 
    if add-code 
    then 
	perform ia0-write-new-rec		thru ia0-99-exit 
    else 
	if change-code 
	then 
	    perform ka0-re-write-rec		thru ka0-99-exit 
	else 
	    if delete-code 
	    then 
		perform ma0-delete-rec		thru ma0-99-exit 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 
 
ab0-90-clear-screen. 
 
    move spaces					to ws-dept-nbr 
						   dept-mstr-rec. 
 
    move zero					to dept-nbr-docs. 
 
    display scr-dept-nbr. 
    display scr-dept-var. 

* 2003/01/20 - MC
    move spaces					to company-name.
    display scr-company.
    display scr-company-name.
* 2003/01/20 - end
 
ab0-95-next-dept. 
 
    perform xd0-acpt-type-dept-read-dept	thru xd0-99-exit. 
 
ab0-99-exit. 
    exit. 
 
 
 
ba0-add-change. 
 
    perform xf0-acpt-name			thru xf0-99-exit. 
    perform xh0-acpt-addr			thru xh0-99-exit. 
    perform xj0-acpt-chairman			thru xj0-99-exit. 
    perform xl0-acpt-co-ordinator		thru xl0-99-exit. 
    perform xn0-acpt-nbr-of-docs		thru xn0-99-exit. 
* 2003/01/20 - MC
    perform xp0-acpt-company     		thru xp0-99-exit. 
* 2003/01/20 - end
 
ba0-99-exit. 
    exit 
ia0-write-new-rec. 
 
    write dept-mstr-rec 
  	invalid key 
	    move 5			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-dept-mstr-writes 
						ctr-dept-mstr-adds. 
 
ia0-99-exit. 
    exit. 
 
 
 
ka0-re-write-rec. 
 
    rewrite dept-mstr-rec 
	invalid key 
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-dept-mstr-changes 
						ctr-dept-mstr-writes. 
 
ka0-99-exit. 
    exit. 
 
 
 
ma0-delete-rec. 
 
*mf delete dept-mstr record physical 
    delete dept-mstr record
	invalid key 
	    move 7			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-dept-mstr-deletes. 
 
ma0-99-exit. 
    exit. 
 
 
 
xa0-acpt-dept-entered. 
 
    accept scr-dept-nbr. 
    if ws-dept-nbr-1 = '*' 
    then 
	go to xa0-99-exit. 
*   (else) 
*   endif 
 
    if ws-dept-nbr-2 = spaces 
    then 
	move ws-dept-nbr-1			to ws-dept-nbr-2 
	move zero				to ws-dept-nbr-1 
	display scr-dept-nbr. 
*   (else) 
*   endif 
 
    if ws-dept-nbr not numeric 
    then 
	move 4					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	go to xa0-acpt-dept-entered. 
*   (else) 
*   endif 
 
xa0-99-exit. 
    exit. 
 
 
 
xc0-read-dept-mstr. 
 
    move 'Y'					to flag-status. 
    read dept-mstr 
	invalid key 
	    move 'N'				to flag-status 
	    go to xc0-99-exit. 
 
    add 1					to ctr-dept-mstr-reads. 
 
xc0-99-exit. 
    exit. 
 
 
 
xd0-acpt-type-dept-read-dept. 
 
    if ws-dept-nbr-1 = '*' 
    then 
	accept scr-option-sel 
    else 
	go to xd0-10-acpt-dept. 
*   endif 
 
    if   add-code 
      or change-code 
      or delete-code 
      or inquire-code 
      or entry-type = '*' 
    then 
	next sentence 
    else 
	move 1					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	go to xd0-acpt-type-dept-read-dept. 
*   endif 
 
    if entry-type = '*' 
    then 
	go to xd0-99-exit. 
*   (else) 
*   endif 
 
xd0-10-acpt-dept. 
 
    perform xa0-acpt-dept-entered		thru xa0-99-exit. 
 
    if ws-dept-nbr-1 = '*' 
    then 
	go to xd0-acpt-type-dept-read-dept. 
*   (else) 
*   endif 
 
    move ws-dept-nbr				to dept-nbr. 
    perform xc0-read-dept-mstr			thru xc0-99-exit. 
 
    if    (   delete-code 
	   or inquire-code 
	   or change-code ) 
      and ok 
    then 
	display scr-dept-var. 
*   (else) 
*   endif 
 
xd0-99-exit. 
    exit. 
 
 
 
xf0-acpt-name. 
 
    accept scr-dept-name. 
 
xf0-99-exit. 
    exit. 
 
 
 
xh0-acpt-addr. 
 
    accept scr-dept-addr1. 
 
    if dept-addr1 not = spaces 
    then 
	accept scr-dept-addr2 
	if dept-addr2 not = spaces 
	then 
	    accept scr-dept-addr3 
	else 
	    move spaces			to dept-addr3 
	    display scr-dept-addr3 
*	endif 
    else 
	move spaces			to dept-addr2 
					   dept-addr3 
	display scr-dept-addr2 
	display scr-dept-addr3. 
*   endif 
 
 
xh0-99-exit. 
    exit. 
 
 
 
xj0-acpt-chairman. 
 
    accept scr-dept-chairman. 
 
xj0-99-exit. 
    exit. 
 
 
 
xl0-acpt-co-ordinator. 
 
    accept scr-dept-co-ordinator. 
 
xl0-99-exit. 
    exit. 
 
 
 
xn0-acpt-nbr-of-docs. 
 
    accept scr-nbr-of-doctors. 
 
xn0-99-exit. 
    exit. 
 
 
* 2003/01/20 - MC - the following two subroutine for accepting company

xp0-acpt-company.        
 
    accept scr-company.  
 
    move dept-company				to company-nbr.   
    perform ya0-read-company-mstr		thru ya0-99-exit. 

    if not-ok
    then go to xp0-acpt-company.
*   endif

    if    (   add-code     
	   or inquire-code 
	   or change-code ) 
      and ok 
    then 
	display scr-company-name.
*   (else) 
*   endif 
 
xp0-99-exit. 
    exit.

 
ya0-read-company-mstr.   
 
    move 'Y'					to flag-status. 
    read company-mstr  
	invalid key 
	    move 'N'				to flag-status 
	    move 8				to err-ind
	    perform za0-common-error		thru za0-99-exit
	    go to ya0-99-exit. 
 
    add 1					to ctr-company-mstr-reads.
 
ya0-99-exit. 
    exit.
* 2003/01/20 - end



za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
 
    accept scr-confirm. 
 
*   display confirm. 
*   stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
