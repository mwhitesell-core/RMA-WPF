identification division. 
program-id. m095.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 83/11/30. 
date-compiled. 
security. 
* 
*    files      : f094 - message and subdivision master 
* 
*    program purpose : subdivision master maintenance. 
* 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised feb/98 j. chau - s149 unix conversion
*
*  1999/jan/31 B.E.	- y2k
*
*  1999/May/11 S.B.	- changed 75 to 70 for the position of sysdate.
*
environment division. 
input-output section. 
file-control. 
* 
    copy "f094_msg_sub_mstr.slr". 
* 
data division. 
file section. 
* 
copy "f094_msg_sub_mstr.fd". 
* 
working-storage section. 
 
	copy "f094_msg_sub_mstr.fw". 
 
77  err-ind					pic 99 	value zero. 
77  err-rtn					pic x	value spaces. 
* 
77  confirm-space				pic x   value space. 
* 
 
01  ws-msg-sub-key. 
    05  ws-msg-sub-key-1			pic x. 
    05  ws-msg-sub-key-23. 
        10  ws-msg-sub-key-2			pic x. 
 	10  ws-msg-sub-key-3			pic x. 
 
01  entry-type					pic x. 
    88  add-code				value "A". 
    88  change-code				value "C". 
    88  delete-code				value "D". 
    88  inquire-code				value "I". 
 
01  flag-status					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  acc-mod-rej					pic x. 
    88  accept-screen				value "Y". 
    88  modify-screen				value "M". 
    88  reject-screen    			value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-msg-mstr-reads			pic 9(7). 
    05  ctr-msg-mstr-writes			pic 9(7). 
    05  ctr-msg-mstr-adds			pic 9(7). 
    05  ctr-msg-mstr-changes			pic 9(7). 
    05  ctr-msg-mstr-deletes			pic 9(7). 
 
77  cur-line					pic 99. 
 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(45)   value 
			"INVALID REPLY". 
	10  filler				pic x(45)   value 
			"SUBDIVISION ALREADY EXISTS". 
	10  filler				pic x(45)   value 
			"SUBDIVISION NBR NOT ON SUBDIVISION MASTER". 
	10  filler				pic x(45)   value 
			"INVALID RE-WRITE TO SUBDIVISION MASTER". 
	10  filler				pic x(45)   value 
			"INVALID DELETE ON SUBDIVISION MASTER". 
	10  filler				pic x(45)   value 
			"NUMERIC SUBDIVISION NUMBER REQUIRED". 
	10  filler				pic x(45)   value 
			"(H)IGH OR (L)OW FEE COMPLEX REQUIRED". 
	10  filler				pic x(45)   value 
			"(Y)ES OR (N)O AUTO LOGOUT REQUIRED". 
	10  filler				pic x(45)   value 
			"SUBDIVISION NAME DETAIL REQUIRED". 
	10  filler				pic x(45)   value 
			"INVALID WRITE TO SUBDIVISON MASTER". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(45) 
			occurs 10 times. 
 
01  err-msg-comment				pic x(55).  
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(45). 
 
 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-titles. 
    05  blank screen. 
    05  line 01 col 01 value "M095".              
    05  line 01 col 11 value "SUBDIVISION MSTR". 
    05  scr-option-sel line 01 col 29 pic x using entry-type auto required. 
    05  line 01 col 31 value "(ADD/CHANGE/DELETE/INQUIRY) SUB NBR". 
    05  scr-msg-id line 01 col 68 pic x using ws-msg-sub-key-3 auto required. 
* (y2k - auto fix)
*   05  line 01 col 73 pic xx/xx/xx from sys-date-long. 
    05  line 01 col 70 pic xxxx/xx/xx from sys-date-long. 
 
 
01  scr-sub-lit. 
     05  line 03 col 01 blank line. 
     05  line 05 col 01 value "NAME:". 
     05  line 06 col 01 value "FEE COMPLEX:". 
     05  line 07 col 01 value "AUTO LOGOUT:". 
 
01  scr-sub-var. 
     05  scr-sub-name		line 05 col 17 pic x(25) using sub-name auto. 
     05  scr-sub-fee-complex	line 06 col 17 pic x(01) using sub-fee-complex auto. 
     05  scr-sub-auto-logout	line 07 col 17 pic x(01) using sub-auto-logout auto. 
 
01 add-mode. 
	05  line 01 col 31 value "ADD MODE                   ". 
 
01  change-mode. 
	05  line 01 col 31 value "CHANGE MODE                ". 
 
01  delete-mode. 
	05  line 01 col 31 value "DELETE MODE                ". 
 
01  inquire-mode. 
	05  line 01 col 31 value "INQUIRE MODE               ". 
 
01  option-mode. 
	05  line 01 col 31 value "(ADD/CHANGE/DELETE/INQUIRE)". 
        05  line 03 col 01 blank line. 
 
01  inquire-screen. 
	05  line 03 col 03 value "        NBR        FEE        AUTO-LOG        NAME". 
 
01  inquire-detail. 
	05  line cur-line col 10 pic x	   using msg-sub-key-3. 
        05  line cur-line col 21 pic x     using sub-fee-complex. 
        05  line cur-line col 34 pic x     using sub-auto-logout. 
	05  line cur-line col 47 pic x(25) using sub-name. 
 
01  clear-inquire-screen. 
	03  line cur-line col 01 blank line. 
 
01  end-of-file. 
	05  line 24 col 64 value "END OF FILE ". 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR - "	bell blink. 
    05  line 24 col 10	pic x(45)	from err-msg-comment. 
    05  line 24 col 77  pic x		using err-rtn auto. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-verify-add-change.       
    05  line 24 col 62	value "ACCEPT(Y/N/M) ". 
    05  line 24 col 77	pic x	using acc-mod-rej auto required. 
 
01  scr-inquire. 
    05  line 24 col 62	value "CONTINUE(Y/N) ". 
    05  line 24 col 77	pic x	using acc-mod-rej auto required. 
 
01  scr-delete. 
    05  line 24 col 64	value "DELETE(Y/N) ". 
    05  line 24 col 77	pic x	using acc-mod-rej auto required. 
 
01  scr-reject-entry. 
    05  line 24 col 58	value "ENTRY IS REJECTED " bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 05 col 20  value "NUMBER OF SUB-MSTR READS:".   
    05  line 05 col 60  pic z(6)9 from ctr-msg-mstr-reads. 
    05  line 06 col 20  value "NUMBER OF SUB-MSTR WRITES:".     
    05  line 06 col 60  pic z(6)9 from ctr-msg-mstr-writes. 
    05  line 08 col 20  value "NUMBER OF SUBS ADDED  :". 
    05  line 08 col 60  pic z(6)9 from ctr-msg-mstr-adds. 
    05  line 10 col 20  value "               CHANGED:". 
    05  line 10 col 60  pic z(6)9 from ctr-msg-mstr-changes. 
    05  line 12 col 20  value "               DELETED:". 
    05  line 12 col 60  pic z(6)9 from ctr-msg-mstr-deletes.                  
    05  line 20 col 20	value "PROGRAM M095 ENDING". 
* (y2k - auto fix)
*   05  line 20 col 40  pic xx/xx/xx from sys-date-long. 
    05  line 20 col 40  pic xxxx/xx/xx from sys-date-long. 
    05  line 20 col 52	pic 99	from sys-hrs. 
    05  line 20 col 54	value ":". 
    05  line 20 col 55	pic 99	from sys-min.        
procedure division. 
declaratives. 
 
	copy "f094_msg_sub_mstr.ds". 
 
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
 
    open i-o	msg-sub-mstr. 
 
    move spaces				to ws-msg-sub-key. 
    move sub-indexer			to ws-msg-sub-key-1. 
 
    display scr-titles. 
    display option-mode. 
 
    move "*"				to ws-msg-sub-key-3. 
    move spaces				to sub-rec. 
 
    perform xd0-acpt-type-sub-read-sub 
					thru xd0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    display blank-screen. 
    display scr-closing-screen. 
    move space 			to	err-rtn. 
    accept err-msg-line. 
 
    close msg-sub-mstr. 
 
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
	    go to ab0-95-next-sub 
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
		go to ab0-95-next-sub 
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
		go to ab0-95-next-sub 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 
 
ab0-10-inquire. 
 
    if   inquire-code 
    then 
	move 'Y'				to acc-mod-rej 
	move "N"				to flag-eof-msg-sub-mstr 
        perform ca0-display-records		thru	ca0-99-exit 
 	        until reject-screen 
    	go to ab0-90-clear-screen. 
*   endif 
 
ab0-20-delete. 
 
*	( must be a delete ) 
    move 'Y'					to acc-mod-rej. 
    display scr-delete. 
    accept  scr-delete. 
    display blank-line-24. 
 
    if   accept-screen 
      or reject-screen 
    then 
	if accept-screen 
	then 
	    go to ab0-80-update-rec 
	else 
            display scr-reject-entry   
	    move space				to 	err-rtn 
	    accept err-msg-line 
	    display blank-line-24 
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
    display blank-line-24. 
 
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
	        display scr-reject-entry   
		move space			to	err-rtn 
		accept err-msg-line 
		display blank-line-24 
		go to ab0-90-clear-screen 
	    else 
		move 1				to err-ind 
		perform za0-common-error	thru za0-99-exit 
		go to ab0-30-disp-verif. 
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
 
    move spaces					to ws-msg-sub-key-3 
						   sub-rec. 
 
    display scr-msg-id. 
    if not inquire-code 
    then display scr-sub-var. 
 
ab0-95-next-sub. 
 
    perform xd0-acpt-type-sub-read-sub	thru xd0-99-exit. 
 
ab0-99-exit. 
    exit. 
 
ba0-add-change. 
 
    move spaces to sub-rec. 
 
ba0-acpt-name. 
 
    accept scr-sub-name. 
    if sub-name = spaces 
    then 
	move 9				to 	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ba0-acpt-name. 
 
ba0-acpt-fee-complex. 
 
    accept scr-sub-fee-complex. 
    if sub-fee-complex not = "H" and 
       sub-fee-complex not = "L" 
    then 
  	move 7 				to 	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ba0-acpt-fee-complex. 
 
ba0-acpt-auto-logout. 
 
    accept scr-sub-auto-logout. 
    if sub-auto-logout not = "Y" and 
       sub-auto-logout not = "N" 
    then 
	move 8				to 	err-ind 
 	perform za0-common-error	thru	za0-99-exit 
	go to ba0-acpt-auto-logout. 
 
ba0-99-exit. 
    exit. 
 
ca0-display-records. 
 
    move 5					to	cur-line. 
 
    perform ca2-load-inquire			thru	ca2-99-exit 
	    until (cur-line > 22) 
	       or eof-msg-sub-mstr 
	       or (msg-sub-key-1 not = sub-indexer). 
 
    if eof-msg-sub-mstr 
    	or (msg-sub-key-1 not = sub-indexer) 
    then 
 	display end-of-file 
	move "N" to acc-mod-rej 
  	move space				to 	err-rtn 
	accept err-msg-line 
	display blank-line-24 
    else 
	display scr-inquire 
	accept scr-inquire 
	display blank-line-24. 
 
    perform ca1-clear-inquire			thru	ca1-99-exit 
            varying cur-line from 5 by 1 until cur-line = 23. 
 
ca0-99-exit. 
 
	exit. 
 
ca1-clear-inquire. 
 
    display clear-inquire-screen. 
 
ca1-99-exit. 
 
    exit. 
 
 
ca2-load-inquire. 
 
    display inquire-detail. 
    add 1 to cur-line. 
 
    if cur-line < 23 
    then perform ya0-read-msg-sub-mstr-next	thru	ya0-99-exit. 
 
ca2-99-exit. 
 
    exit. 
ia0-write-new-rec. 
 
    write msg-sub-mstr-rec 
  	invalid key 
	    move 10			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-writes 
						ctr-msg-mstr-adds. 
 
ia0-99-exit. 
    exit. 
 
 
 
ka0-re-write-rec. 
 
    rewrite msg-sub-mstr-rec 
	invalid key 
	    move 4			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-changes 
						ctr-msg-mstr-writes. 
 
ka0-99-exit. 
    exit. 
 
 
 
ma0-delete-rec. 
 
*mf delete msg-sub-mstr record physical 
    delete msg-sub-mstr record 
	invalid key 
	    move 5			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-deletes. 
 
ma0-99-exit. 
    exit. 
 
 
 
xa0-acpt-sub-entered. 
 
    accept scr-msg-id. 
    if ws-msg-sub-key-3 = '*' 
    then 
	go to xa0-99-exit. 
*   (else) 
*   endif 
 
xa0-99-exit. 
    exit. 
 
 
 
xc0-read-msg-sub-mstr. 
 
    move 'Y'					to flag-status. 
    read msg-sub-mstr 
	invalid key 
	    move 'N'				to flag-status 
	    go to xc0-99-exit. 
 
    add 1					to ctr-msg-mstr-reads. 
 
xc0-99-exit. 
    exit. 
 
 
 
xd0-acpt-type-sub-read-sub. 
 
    if ws-msg-sub-key-3 = '*' 
    then 
	display option-mode 
	move spaces to entry-type ws-msg-sub-key-3 
	display scr-option-sel scr-msg-id 
	accept scr-option-sel 
    else 
	go to xd0-10-acpt-sub. 
*   endif 
 
    if add-code 
    then display add-mode 
         display scr-sub-lit 
    else 
	if change-code 
	then display change-mode 
	     display scr-sub-lit 
	else 
	    if delete-code 
	    then display delete-mode 
	         display scr-sub-lit 
	    else 
		if inquire-code 
		then display inquire-mode 
		     display inquire-screen 
		     perform ca1-clear-inquire	thru 	ca1-99-exit 
			varying cur-line from 5 by 1 until cur-line = 23 
		else 
		    if entry-type = "*" 
		    then next sentence 
		    else 
	move 1					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	move "*" to ws-msg-sub-key-3 
	go to xd0-acpt-type-sub-read-sub. 
*   endif 
 
    if entry-type = '*' 
    then 
	go to xd0-99-exit. 
*   (else) 
*   endif 
 
xd0-10-acpt-sub. 
 
    move space to ws-msg-sub-key-3. 
    display scr-msg-id. 
    perform xa0-acpt-sub-entered		thru xa0-99-exit. 
 
    if ws-msg-sub-key-3 = '*' 
    then 
	go to xd0-acpt-type-sub-read-sub. 
*   (else) 
*   endif 
 
    if add-code and 
       ws-msg-sub-key-3 not numeric 
    then 
	move 6					to 	err-ind 
        perform za0-common-error		thru	za0-99-exit 
	go to xd0-10-acpt-sub. 
 
     move ws-msg-sub-key			to	msg-sub-key. 
     perform xc0-read-msg-sub-mstr			thru xc0-99-exit. 
 
    if ok 
    then 
	if delete-code or change-code 
	then 
	    display scr-sub-var. 
*   endif 
 
xd0-99-exit. 
    exit. 
 
ya0-read-msg-sub-mstr-next. 
 
    read msg-sub-mstr next record 
        at end move "Y" to flag-eof-msg-sub-mstr 
       	       go to ya0-99-exit. 
 
    add 1 				to 	ctr-msg-mstr-reads. 
 
ya0-99-exit. 
 
    exit. 
 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    move spaces to err-rtn. 
 
 
    display err-msg-line. 
    accept err-msg-line. 
    accept scr-confirm. 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".