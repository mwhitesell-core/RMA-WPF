identification division. 
program-id. m080.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/03/11. 
date-compiled. 
security. 
* 
*    files      f080  : bank master file 
*		rm080 : audit file 
* 
*    program purpose : bank file master maintenance.   
* 
* 
*	revision history: 
* 
*		july/82 (d.m.)	- bank code entry modified to be the 
*				  same as m020 
* 
*		jun/86 (k.p.)   - expand bank-address to two 
*				  bank-address fields. 
*				 
*               nov/86 (j.l.)   - modified input screen  for the change 
*                                 in bank-nbr and bank-branch fields. 
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*               sep/87 (c.e.) - mode change '**' 
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
* 
*   1999/jan/01 B.E.		- y2k
*   1999/May/11 S.B.		- rechecked Y2K and fixed screen section.
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
copy "f080_bank_mstr.slr". 
* 
    select audit-file 
          assign to printer print-file-name 
	  file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
copy "f080_bank_mstr.fd". 
fd  audit-file 
    record contains 132 characters. 
 
01  audit-record.      
    05  option-type				pic x(7). 
    05  bank-rec				pic x(105). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  ws-closing-msg				pic x(40)	value 
		"AUDIT REPORT IS IN FILE RM080". 
77  print-file-name				pic x(5) 
			value "rm080".    
77  option					pic x. 
* 
77  confirm-space				pic x   value space. 
* 
01  hold-bank-nbr  				pic 9(4). 
01  hold-bank-nbr-r redefines hold-bank-nbr. 
    05  hold-bank-nbr1				pic x. 
    05  hold-bank-nbr2				pic x. 
    05  hold-bank-nbr3				pic x. 
    05  hold-bank-nbr4 				pic x. 
 
* 
*  eof flags 
* 
77  eof-bank-mstr				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  status-file				pic x(11). 
77  status-file					pic x(2). 
01  status-cobol-bank-mstr.
    02 status-bank-mstr-1			pic x(1).
    02 status-bank-mstr-2			pic x(1).

77  status-audit-rpt				pic xx	  value zero. 
 
01  ws-bank-cd. 
    05  ws-bank-nbr				pic 9(4) value zeroes. 
    05  ws-branch-nbr 				pic 9(5) value zeroes. 
 
** statment added sep/87 c.e. 
 
01  acpt-inq					pic x. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-bank-mstr-reads			pic 9(7). 
    05  ctr-bank-mstr-adds  			pic 9(7). 
    05  ctr-bank-mstr-changes 			pic 9(7). 
    05  ctr-bank-mstr-deletes			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"ALREADY ON FILE". 
	10  filler				pic x(60)   value 
			"BANK NAME CANNOT BE BLANK". 
	10  filler				pic x(60)   value 
			"ADDRESS CANNOT BE BLANK". 
	10  filler				pic x(60)   value 
			"CITY CANNOT BE BLANK". 
	10  filler				pic x(60)   value 
			"POSTAL CODE CANNOT BE BLANK". 
	10  filler				pic x(60)   value 
			"NOT ON FILE". 
	10  filler				pic x(60)   value 
			"PROVINCE CANNOT BE BLANK". 
	10  filler				pic x(60)   value 
			"INVALID POSTAL CODE".            
	10  filler				pic x(60)   value 
			"ERROR MESSAGE # 10 GOES HERE". 
	10  filler				pic x(60)   value 
			"ERROR MESSAGE # 11 GOES HERE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 11 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
copy "sysdatetime.ws". 

screen section. 
01 scr-title. 
     05  blank screen. 
     05 line 01 col 01 value is "M080      BANK MASTER MAINTENANCE".
* (y2k) - s.b.
*     05 line 01 col 42 pic x to option auto required. 
     05 line 01 col 40 pic x to option auto required. 
*     05 line 01 col 44 value is "(ADD/CHANGE/DELETE/INQUIRY)". 
     05 line 01 col 42 value is "(ADD/CHANGE/DELETE/INQUIRY)". 
* (y2k - auto fix)
*    05 line 01 col 73 pic 99 from sys-yy. 
     05 line 01 col 71 pic 9(4) from sys-yy. 
     05 line 01 col 75 value is "/". 
     05 line 01 col 76 pic 99 from sys-mm. 
     05 line 01 col 78 value is "/". 
     05 line 01 col 79 pic 99 from sys-dd. 
     05 line 05 col 22 value is "BANK NUMBER". 
     05 line 05 col 40 value is "BRANCH NUMBER". 
     05	line 08 col 22 value is "BANK NAME". 
     05	line 10 col 22 value is "ADDRESS". 
     05	line 13 col 22 value is "CITY". 
     05	line 13 col 55 value is "PROVINCE". 
     05	line 15 col 22 value is "POSTAL CODE". 
* 
01 scr-option-displays. 
    05  scr-option-add  line 1 col 42 " ADD                          ". 
    05  scr-option-chg	line 1 col 42 " CHANGE                       ". 
    05  scr-option-del	line 1 col 42 " DELETE                       ". 
    05  scr-option-inq	line 1 col 42 " INQUIRY                      ". 
* 
01 scr-acpt-bank-cd. 
     05 scr-bank     line 05 col 35 pic x(4) using hold-bank-nbr-r auto required. 
     05 scr-branch   line 05 col 55 pic z(4)9 using ws-branch-nbr auto required. 
* 
01 scr-mask1. 
     05 scr-bank-name		line 08 col 35 pic x(30) using 
						bank-name auto. 
     05 scr-bank-address1       line 10 col 35 pic x(30) using 
 						bank-address1 auto. 
     05 scr-bank-address2       line 11 col 35 pic x(30) using 
						bank-address2 auto. 
     05 scr-bank-city		line 13 col 35 pic x(15) using 
						bank-city auto. 
     05  scr-bank-prov		line 13 col 65 pic x(15) using 
					bank-prov auto. 
     05 scr-bank-postal-cd. 
	10  scr-bank-pc123	line 15 col 35 pic x9x using bank-pc-123 auto. 
	10  scr-bank-pc456	line 15 col 39 pic 9x9 using bank-pc-456 auto. 
* 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	from err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01 value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  verification-screen-add-chg. 
    05  line 20 col 30	value "ACCEPT (Y/N/M) ". 
    05  line 20 col 45 pic x using flag auto required. 
 
01  verification-screen-del. 
    05  line 20 col 30 value "DELETE (Y/N)". 
    05  line 20 col 45 pic x using flag auto required. 
 
**  verification statement added for inquire mode. 
**  sep/87 c.e. 
 
01  verification-screen-inq. 
    05 line 20 col 30 value "ENTER NEWLINE TO CONTINUE". 
    05 line 20 col 57 pic x using acpt-inq secure. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  5 col 20  value "NUMBER OF BANK-MSTR READS". 
    05  line  5 col 60  pic z(6)9 from ctr-bank-mstr-reads. 
    05  line  6 col 20  value "                    ADDS". 
    05  line  6 col 60  pic z(6)9 from ctr-bank-mstr-adds. 
    05  line  7 col 20  value "                    CHANGES". 
    05  line  7 col 60  pic z(6)9 from ctr-bank-mstr-changes. 
    05  line  8 col 20  value "                    DELETES". 
    05  line  8 col 60  pic z(6)9 from ctr-bank-mstr-deletes. 
    05  line 21 col 20	value "PROGRAM M080 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40	pic 99	from sys-yy. 
    05  line 21 col 40	pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic z9	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min. 
    05  line 23 col 30 pic x(40) using ws-closing-msg. 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
procedure division. 
declaratives. 
err-bank-mstr-file section. 
    use after standard error procedure on bank-mstr.       
err-bank-mstr. 
    stop "ERROR IN ACCESSING BANK MASTER". 
*mf    move status-bank-mstr		to status-file. 
    move status-cobol-bank-mstr		to status-file. 
    display file-status-display. 
    stop run. 
 
err-audit-rpt-file section. 
    use after standard error procedure on audit-file.     
err-audit-rpt. 
    stop "ERROR IN WRITING AUDIT REPORT FILE". 
    move status-audit-rpt		to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
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
 
**  the below commented statments have been moved to ab0-processing. 
**  sep/87 c.e. 
** 
**  display scr-title. 
** 
** 
** 
** aa0-10. 
** 
**  accept scr-title. 
** 
**  if option = "*" 
**  then 
**	go to az0-100-end-job. 
**  (else) 
**  (endif) 
 
*    expunge 	audit-file. 
    open i-o	bank-mstr. 
    open output audit-file. 
 
**  if option = "A" 
**  then 
**	display scr-option-add 
**	display verification-screen-add-chg 
**	move "ADD"			to	option-type 
**  else 
**	if option = "C" 
**	then 
**	    display scr-option-chg 
**	    display verification-screen-add-chg 
**	    move "CHANGE"		to	option-type 
**	else 
**	    if option = "D" 
**	    then 
**		display scr-option-del 
**		display verification-screen-del 
**  		move "DELETE"		to	option-type 
**	    else 
**		if option = "I" 
**		then 
**		    display scr-option-inq 
**		else 
**		    move 1		to err-ind 
**		    perform za0-common-error 
**					thru za0-99-exit 
**		    go to aa0-10. 
**		endif 
**	    endif 
**	endif 
**   endif 
** 
**  move spaces				to	ws-bank-cd. 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
    display scr-title. 
 
    accept scr-title. 
 
    if option = "*" 
    then  
**	go to az0-100-end-job. 
	go to ab0-99-exit. 
*   (else) 
*   (endif) 
 
    if option = "A" 
    then 
	display scr-option-add 
**	display verification-screen-add-chg 
	move "ADD"			to	option-type 
    else 
	if option = "C" 
	then 
	    display scr-option-chg 
**	    display verification-screen-add-chg 
	    move "CHANGE"		to	option-type 
	else 
	    if option = "D" 
	    then 
		display scr-option-del 
**		display verification-screen-del 
		move "DELETE"		to	option-type 
	    else 
		if option = "I" 
		then 
		    display scr-option-inq 
		else 
		    move 1		to err-ind 
		    perform za0-common-error 
					thru za0-99-exit 
**		    go to aa0-10. 
		    go to ab0-processing. 
*		endif 
*	    endif 
*	endif 
*   endif 
 
    move spaces				to	ws-bank-cd. 
 
ab0-01. 
 
**  move spaces 			to  	hold-bank-nbr-r. 
 
**  below two statemnets added 
**  sep/87 c.e. 
 
    move zeros				to	hold-bank-nbr 
						ws-branch-nbr. 
 
    display scr-acpt-bank-cd. 
    accept scr-bank. 
 
**  if hold-bank-nbr-r  = "****" 
    if hold-bank-nbr1 = "*" 
    then 
**      go to ab0-99-exit 
	go to ab0-processing 
    else 
	if    hold-bank-nbr1 numeric 
	  and hold-bank-nbr2 numeric 
	  and hold-bank-nbr3 numeric 
  	  and hold-bank-nbr4 numeric 
	then 
	    move hold-bank-nbr  	to	ws-bank-nbr 
	else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
**	    go to ab0-processing. 
	    go to ab0-01. 
*	endif 
*   endif 
 
**  display scr-bank. 
 
    accept scr-branch. 
**  display scr-branch. 
    perform ma0-read-bank-mstr		thru ma0-99-exit. 
 
    if    ok 
     and option = "A" 
    then 
*	(error - rec already exists) 
	move 2				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move spaces			to	bank-mstr-rec 
**	go to ab0-processing. 
	go to ab0-01. 
*   (else) 
*   endif 
 
    if not-ok 
    then 
	if option =    "I" 
		    or "C" 
		    or "D" 
	then 
*	(error - record doesn't exist) 
	    move 7			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
**	    go to ab0-processing. 
	    go to ab0-01. 
*	(else) 
*	endif 
*   (else) 
*   endif 
 
**  display scr-mask1. 
    if    ok 
      and option = "I" or "C" or "D" 
    then 
	display scr-mask1. 
*   endif 
 
ab0-05. 
 
    if option = "I" 
    then 
 
**  prompt user to continue 
**  sep/87 c.e. 
 
	display verification-screen-inq 
	accept verification-screen-inq 
	go to ab0-100-next-record. 
*   (else) 
*   endif 
 
    if option =    "A" 
		or "C" 
    then 
*	validate data for record 
	perform ia0-acpt-bank-name	thru	ia0-99-exit 
	perform ja0-acpt-bank-address	thru	ja0-99-exit 
        perform ka0-acpt-bank-city	thru	ka0-99-exit 
        perform ka1-acpt-bank-prov	thru	ka1-99-exit 
	perform la0-acpt-bank-postal-cd	thru	la0-99-exit. 
*   (else) 
*   endif 
 
ab0-10. 
 
**  following statements added  sep/87 c.e. 
 
    move spaces					to flag. 
 
    if option = "A" or "C" 
    then 
**  following statment added  sep/87 c.e. 
	display verification-screen-add-chg 
	accept verification-screen-add-chg 
    else 
	if option = "D" 
	then 
**  following statment added  sep/87 c.e. 
	    display verification-screen-del 
	    accept verification-screen-del. 
*	(else) 
*	endif 
*   endif 
 
    if flag = "Y" or "N" or "M" 
    then 
	next sentence 
    else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ab0-10. 
*	endif 
*   endif 
 
    if flag = "M" 
    then 
	if option = "A" or "C" 
	then 
*	    next sentence 
	    go to ab0-05 
	else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ab0-10. 
*	endif 
*   (else) 
*   endif 
 
	if flag = "Y" 
	then 
	    perform ra0-write-audit-rpt thru	ra0-99-exit 
	    if option = "A" 
	    then 
		perform na0-write-bank-mstr 
					thru	na0-99-exit 
	    else 
		if option = "C" 
		then 
		    perform pa0-re-write-bank-mstr 
					thru	pa0-99-exit 
 		else 
		    if option = "D" 
		    then 
		    perform qa0-delete-bank-mstr 
					thru	qa0-99-exit. 
*		endif 
*	    endif 
 
	    if flag = "N" 
	    then 
		display scr-reject-entry 
		display confirm 
		stop " " 
*		display blank-line-24. 
*	    (else) 
*	    endif 
 
    display blank-line-24. 
 
** the following statements have been commented on  sep/87 by c.e. 
 
**		if     flag = "M" 
**		  and (option =   "A" 
**		               or "C") 
**		then 
**		    go to ab0-05 
** 
**  move spaces				to	flag. 
**  if option = "A" or "C" 
**  then 
**	display verification-screen-add-chg 
**  else 
**	if option = "D" 
**	then 
**	    display verification-screen-del. 
**  	(else) 
**	endif 
**   endif 
 
ab0-100-next-record. 
 
    move spaces				to	bank-mstr-rec 
						flag. 
    move zeroes				to	ws-bank-cd
						hold-bank-nbr. 
 
**  blank the screen added on sep/87 by c.e. 
 
    display scr-acpt-bank-cd. 
    display scr-mask1. 
**  go to ab0-processing. 
    go to ab0-01. 
 
ab0-99-exit. 
    exit. 
ia0-acpt-bank-name.  
    accept scr-bank-name.  
 
    if bank-name = spaces          
    then 
	move 3				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ia0-acpt-bank-name.  
*    else 
*    endif 
ia0-99-exit. 
    exit. 
 
 
ja0-acpt-bank-address. 
    accept scr-bank-address1. 
    accept scr-bank-address2. 
 
    if bank-address1 = spaces and bank-address2 = spaces 
 
    then 
	move 4				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ja0-acpt-bank-address. 
*   (else) 
*   endif 
 
ja0-99-exit. 
    exit. 
 
ka0-acpt-bank-city. 
    accept scr-bank-city. 
 
    if bank-city = spaces 
    then 
	move 5				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ka0-acpt-bank-city. 
*   (else) 
*   endif 
 
 
ka0-99-exit. 
 
ka1-acpt-bank-prov. 
    accept scr-bank-prov. 
 
    if bank-prov = spaces 
    then  
        move 8				to err-ind 
        perform za0-common-error	thru za0-99-exit 
        go to ka1-acpt-bank-prov. 
*   (else) 
*    endif 
 
ka1-99-exit. 
 
    exit. 
 
 
la0-acpt-bank-postal-cd. 
 
    accept scr-bank-pc123. 
 
    if bank-pc-123 = spaces 
    then 
	move 6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to la0-acpt-bank-postal-cd. 
*   (else) 
*   endif 
 
    if    bank-pc1  not numeric 
      and bank-pc2  numeric 
      and bank-pc3  not numeric 
    then 
	next sentence 
    else 
	move 9				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to la0-acpt-bank-postal-cd. 
*   endif 
 
la0-10-second-half. 
 
    accept scr-bank-pc456. 
 
    if bank-pc-456 = spaces 
    then 
	move 6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to la0-10-second-half. 
*   (else) 
*   endif 
 
    if    bank-pc4 numeric 
      and bank-pc5 not numeric 
      and bank-pc6 numeric 
    then 
	next sentence 
    else 
	move 9				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to la0-10-second-half. 
*  endif 
 
la0-99-exit. 
    exit. 
 
 
 
 
 
ma0-read-bank-mstr. 
 
    move "N"				to	flag. 
    move ws-bank-cd			to	bank-cd. 
 
   read bank-mstr 
	invalid key 
		go to ma0-99-exit. 
 
    move "Y"				to flag. 
    move bank-cd			to	ws-bank-cd. 
 
    add 1				to ctr-bank-mstr-reads. 
 
ma0-99-exit. 
    exit. 
 
 
 
 
 
na0-write-bank-mstr. 
 
    write bank-mstr-rec 
	invalid key 
	    perform err-bank-mstr. 
 
    add 1				to ctr-bank-mstr-adds.   
 
na0-99-exit. 
    exit. 
 
 
 
 
pa0-re-write-bank-mstr. 
 
    rewrite bank-mstr-rec. 
    add 1				to ctr-bank-mstr-changes.  
 
pa0-99-exit. 
    exit. 
 
 
 
 
 
qa0-delete-bank-mstr. 
 
    delete bank-mstr record.
    add 1				to	ctr-bank-mstr-deletes. 
 
qa0-99-exit. 
    exit. 
 
 
 
 
 
ra0-write-audit-rpt. 
 
    move bank-mstr-rec			to bank-rec.      
    write audit-record. 
 
ra0-99-exit. 
    exit. 
az0-end-of-job. 
    
    close bank-mstr. 
    close  audit-file. 
 
az0-100-end-job. 
 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
    call program "menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
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
