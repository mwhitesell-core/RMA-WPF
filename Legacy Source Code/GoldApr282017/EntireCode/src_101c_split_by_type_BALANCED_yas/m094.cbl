identification division. 
program-id. m094.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 83/11/30. 
date-compiled. 
security. 
* 
*    files      : f094 - direct bills - message and subdivision master maint.
 
*    program purpose : message master maintenance.   
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
*   revised feb/98 (j.c.) - s149 unix conversion
* 
*  1999/jan/31 B.E.	- y2k
*  1999/dec/13 B.E.	- cosmetic changes
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
			"MESSAGE ALREADY EXISTS". 
	10  filler				pic x(45)   value 
			"MESSAGE NBR NOT ON MESSAGE MASTER". 
	10  filler				pic x(45)   value 
			"SECOND MESSAGE DETAIL REQUIRED". 
	10  filler				pic x(45)   value 
			"INVALID WRITE TO MESSAGE MASTER". 
	10  filler				pic x(45)   value 
			"INVALID RE-WRITE TO MESSAGE MASTER". 
	10  filler				pic x(45)   value 
			"INVALID DELETE ON MESSAGE MASTER". 
	10  filler				pic x(45)   value 
			"NUMERIC MESSAGE NUMBER REQUIRED". 
	10  filler				pic x(45)   value 
			"(Y)ES OR (N)O PRINT INDICATOR REQUIRED". 
	10  filler				pic x(45)   value 
			"THIRD MESSAGE DETAIL REQUIRED". 
	10  filler				pic x(45)   value 
			"FIRST MESSAGE DETAIL REQUIRED". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(45) 
			occurs 11 times. 
 
01  err-msg-comment				pic x(45).  
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(45). 
 
 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-titles. 
    05  blank screen. 
    05  		line 01 col 01 value "M094".              
    05  		line 01 col 20 value "Direct Bills - Message Maintenance". 
    05  scr-option-sel	line 02 col 29 pic x using entry-type auto required. 
    05  		line 02 col 31 value "(Add/Change/Delete/Inquiry) Msg Nbr". 
    05  scr-msg-id	line 02 col 68 pic xx using ws-msg-sub-key-23 auto required. 
* (y2k - auto fix)
*   05  line 01 col 73 pic xx/xx/xx from sys-date-long. 
    05  line 01 col 71 pic xxxx/xx/xx from sys-date-long. 
 
 
01  scr-msg-lit. 
    05  line 03 col 01 blank line. 
    05  line 05 col 01 value "REPRINT FLAG:". 
    05  line 07 col 01 value "MESSAGE 1:". 
    05  line 08 col 01 value "MESSAGE 2:". 
    05  line 09 col 01 value "MESSAGE 3:". 
    05  line 10 col 01 value "MESSAGE 4:". 
 
01  scr-msg-var. 
    05  scr-msg-reprint-flag line 05 col 17 pic x using msg-reprint-flag auto. 
    05  scr-msg-dtl1 line 07 col 17 pic x(47) using msg-dtl1 auto. 
    05  scr-msg-dtl2 line 08 col 17 pic x(47) using msg-dtl2 auto. 
    05  scr-msg-dtl3 line 09 col 17 pic x(47) using msg-dtl3 auto. 
    05  scr-msg-dtl4 line 10 col 17 pic x(47) using msg-dtl4 auto. 
 
01 add-mode. 
	05  line 02 col 31 value "ADD MODE                   ". 
 
01  change-mode. 
	05  line 02 col 31 value "CHANGE MODE                ". 
 
01  delete-mode. 
	05  line 02 col 31 value "DELETE MODE                ". 
 
01  inquire-mode. 
	05  line 02 col 31 value "INQUIRE MODE               ". 
 
01  option-mode. 
	05  line 02 col 31 value "(ADD/CHANGE/DELETE/INQUIRE)". 
        05  line 03 col 01 blank line. 
 
01  inquire-screen. 
    	05  line 03 col  3 value "NBR   REPRINT              MESSAGES". 
 
01  msg-one. 
	05  line cur-line col  3 pic xx    using msg-sub-key-23. 
	05  line cur-line col 12 pic x     using msg-reprint-flag. 
	05  line cur-line col 30 pic x(47) using msg-dtl1. 
 
01  msg-two. 
	05  line cur-line col 30 pic x(47) using msg-dtl2. 
 
01  msg-three. 
	05  line cur-line col 30 pic x(47) using msg-dtl3. 
 
01  msg-four. 
	05  line cur-line col 30 pic x(47) using msg-dtl4. 
 
01  end-of-file. 
	03  line 24 col 64 value "END OF FILE ". 
 
01  clear-inquire-screen. 
	03  line cur-line col 01 blank line. 
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
    05  line 05 col 20  value "NUMBER OF MSG-MSTR READS:".   
    05  line 05 col 60  pic z(6)9 from ctr-msg-mstr-reads. 
    05  line 06 col 20  value "NUMBER OF MSG-MSTR WRITES:".     
    05  line 06 col 60  pic z(6)9 from ctr-msg-mstr-writes. 
    05  line 08 col 20  value "NUMBER OF MSGS ADDED  :". 
    05  line 08 col 60  pic z(6)9 from ctr-msg-mstr-adds. 
    05  line 10 col 20  value "               CHANGED:". 
    05  line 10 col 60  pic z(6)9 from ctr-msg-mstr-changes. 
    05  line 12 col 20  value "               DELETED:". 
    05  line 12 col 60  pic z(6)9 from ctr-msg-mstr-deletes.                  
    05  line 20 col 20	value "PROGRAM M094 ENDING". 
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
    move msg-indexer			to ws-msg-sub-key-1. 
 
    display scr-titles. 
    display option-mode. 
 
    move "*"				to ws-msg-sub-key-2. 
    move spaces				to msg-rec. 
 
    perform xd0-acpt-type-msg-read-msg 
					thru xd0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    display blank-screen. 
    display scr-closing-screen. 
 
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
	    go to ab0-95-next-msg 
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
		go to ab0-95-next-msg 
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
		go to ab0-95-next-msg 
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
	    move space 				to err-rtn 
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
		move space			to err-rtn 
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
 
    move spaces					to ws-msg-sub-key-23 
						   msg-rec. 
 
    display scr-msg-id. 
    if not inquire-code 
    then display scr-msg-var. 
 
ab0-95-next-msg. 
 
    perform xd0-acpt-type-msg-read-msg	thru xd0-99-exit. 
 
ab0-99-exit. 
    exit. 
 
ba0-add-change. 
 
*mf    move spaces to msg-rec. 
 
ba0-acpt-reprint. 
 
    accept scr-msg-reprint-flag. 
    if msg-reprint-flag not = "Y" and 
       msg-reprint-flag not = "N" 
    then 
	move 9					to	err-ind 
	perform za0-common-error		thru 	za0-99-exit 
  	go to ba0-acpt-reprint. 
 
ba0-acpt-dtl1. 
 
    accept scr-msg-dtl1. 
    if msg-dtl1 equal spaces 
    then 
	move 11					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba0-acpt-dtl1. 
 
ba0-acpt-dtl2. 
 
    accept scr-msg-dtl2. 
 
ba0-acpt-dtl3. 
 
    accept scr-msg-dtl3. 
    if msg-dtl3 not = spaces and 
       msg-dtl2 = spaces 
    then 
	move 4					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba0-acpt-dtl2. 
 
ba0-acpt-dtl4. 
 
    accept scr-msg-dtl4. 
    if msg-dtl4 not equal spaces and 
       msg-dtl3 equal spaces 
    then 
	move 10					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to ba0-acpt-dtl3. 
 
ba0-99-exit. 
    exit. 
 
ca0-display-records. 
 
    move 5					to	cur-line. 
 
    perform ca2-load-inquire			thru	ca2-99-exit 
	    until (cur-line > 19) 
	       or eof-msg-sub-mstr 
	       or (msg-sub-key-1 not = msg-indexer). 
 
    if eof-msg-sub-mstr 
    	or (msg-sub-key-1 not = msg-indexer) 
    then 
 	display end-of-file 
	move "N" to acc-mod-rej 
	move space to err-rtn 
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
 
    display msg-one. 
    add 1 to cur-line. 
 
    if msg-dtl2 not = spaces 
    then display msg-two 
         add 1 to cur-line. 
 
    if msg-dtl3 not = spaces 
    then display msg-three 
         add 1 to cur-line. 
 
    if msg-dtl4 not = spaces 
    then display msg-four 
         add 1 to cur-line. 
 
    if cur-line < 20 
    then perform ya0-read-msg-sub-mstr-next	thru	ya0-99-exit. 
 
ca2-99-exit. 
 
    exit. 
ia0-write-new-rec. 
 
    write msg-sub-mstr-rec 
  	invalid key 
	    move 5			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-writes 
						ctr-msg-mstr-adds. 
 
ia0-99-exit. 
    exit. 
 
 
 
ka0-re-write-rec. 
 
    rewrite msg-sub-mstr-rec 
	invalid key 
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-changes 
						ctr-msg-mstr-writes. 
 
ka0-99-exit. 
    exit. 
 
 
 
ma0-delete-rec. 
 
*mf    delete msg-sub-mstr record physical 
    delete msg-sub-mstr record 
	invalid key 
	    move 7			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-msg-mstr-deletes. 
 
ma0-99-exit. 
    exit. 
 
 
 
xa0-acpt-msg-entered. 
 
    accept scr-msg-id. 
    if ws-msg-sub-key-2 = '*' 
    then 
	go to xa0-99-exit. 
*   (else) 
*   endif 
 
xa0-99-exit. 
    exit. 
 
 
 
xc0-read-msg-mstr. 
 
    move 'Y'					to flag-status. 
    read msg-sub-mstr 
	invalid key 
	    move 'N'				to flag-status 
	    go to xc0-99-exit. 
 
    add 1					to ctr-msg-mstr-reads. 
 
xc0-99-exit. 
    exit. 
 
 
 
xd0-acpt-type-msg-read-msg. 
 
    if ws-msg-sub-key-2 = '*' 
    then 
	display option-mode 
	move spaces to entry-type ws-msg-sub-key-23 
	display scr-option-sel scr-msg-id 
	accept scr-option-sel 
    else 
	go to xd0-10-acpt-msg. 
*   endif 
 
    if add-code 
    then display add-mode 
         display scr-msg-lit 
    else 
	if change-code 
	then display change-mode 
	     display scr-msg-lit 
	else 
	    if delete-code 
	    then display delete-mode 
	         display scr-msg-lit 
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
	move "*" to ws-msg-sub-key-2 
	go to xd0-acpt-type-msg-read-msg. 
*   endif 
 
    if entry-type = '*' 
    then 
	go to xd0-99-exit. 
*   (else) 
*   endif 
 
xd0-10-acpt-msg. 
 
    move space to ws-msg-sub-key-23. 
    display scr-msg-id. 
    perform xa0-acpt-msg-entered		thru xa0-99-exit. 
 
    if ws-msg-sub-key-2 = '*' 
    then 
	go to xd0-acpt-type-msg-read-msg. 
*   (else) 
*   endif 
 
    if add-code and 
       ws-msg-sub-key-23 not numeric 
    then 
	move 8					to 	err-ind 
        perform za0-common-error		thru	za0-99-exit 
	go to xd0-10-acpt-msg. 
 
     move ws-msg-sub-key			to	msg-sub-key. 
     perform xc0-read-msg-mstr			thru xc0-99-exit. 
 
    if ok 
    then 
	if delete-code or change-code 
	then 
	    display scr-msg-var. 
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
