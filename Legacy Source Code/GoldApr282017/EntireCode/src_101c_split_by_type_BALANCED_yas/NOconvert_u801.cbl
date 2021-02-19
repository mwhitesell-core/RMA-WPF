identification division. 
program-id. u801. 
installation.   rma. 
date-written. 82/03/29. 
date-compiled. 
security. 
* 
*    files   - input	:              - up to 20 reports, depending on    
*			                 operator'S SELECTION.             
*mf	     - output	: "mtd0:0"     - tape file. 
*	     - output	: "/dev/rmt/1" - tape file. 
*			:  ru801       - audit report. 
* 
*    program purpose: 
*	disk to tape utility for creating sheltec (microfiche) tapes. 
* 
*    note: 
* 
*	-to increase nbr. of options, add new options to "table" & 
*	 increase ws-max-nbr-options 
* 
*	-to increase nbr. of reports, expand "reports-table",    
*	                              increase ws-max-nbr-reports & 
*                                     increase report rec ctr'S (WS-CTR's) 
************************************************************************ 
* 
*	revision  history 
*	 
*       date		programmer	reason for change 
* 
*      	87/03/02	j. lam		to add r130eft report to report 
*					table. 
*       87/06/08        j. lam          add  r004tp to table ; RENAME 
*                                       r130eft to r130ef 
* 
*   march/89 : - sms 115 s.f. 
*	       - make sure file status is pic xx ,feedback is 
*		 pic x(4) and infos status is pic x(11). 
* 
*   july 20/89 - s.f. 
*              - take out option 3 month end clinic 43 
* 
*   nov/89:     - s.f. sms 125 
*		- add reports r210 and r211 for clinic 22 and 60 
* 
*   mar/91:     - bml - pdr 483 & pdr 464 
*               - include ru701 in cycle and moh1 in monthend. 
* 
* 
*   oct/91:	- brad e. - pdr 433, 455, 515 
*		- correct the buffersize and correct the pgm 
*		  to include the last page properly 
* 
*   july/92:   - m.c. - sms 139 
*	       - include r015tp in part clinic 60 monthend 
 
*   apr/93     - agk -pdr 570 
*              - delete stage 30 and create clinic 80 
*              - modify copy book u80x_reports_tbl.ws to include 
*                option number 5 
* 
*   revised jun/94     - pdr 598 
*		       - add a new option for clinic 81 with mohbicu 
* 
*   revised aug/96     - sra 177 
*		       - add a new report for option #4 r119 
* 
*   revised mar/97     - pdr 656 
*		       - change option 10 to 82 monthend instead 81 moh 
*                        compile only 
*
*   revised feb/97 j. chau - s149 unix conversion
*
*   revised apr/98  B.E.-unix conversino
*			 tape device changed from "@MTD0:0" to "/dev/rmt/1".
*
environment division. 
input-output section. 
file-control. 
 
	select input-file 
		assign to	input-file-name
		file  status is input-fstat
		organization is line sequential. 
*mf		infos status is input-istat. 
 
	select output-file 
		assign to	tape-file-name 
		file  status is output-fstat. 
*mf		infos status is output-istat. 
 
	select audit-report 
		assign to	printer	print-file-name 
		file  status is audit-fstat. 
*mf		infos status is audit-istat. 
data division. 
file section. 
 
fd  input-file  
	record contains 9000 characters.
*mf	record contains 1 to 9000 characters. 
*mf	recording mode	is data-sensitive 
*mf	delimiter	is ws-form-feed 
*mf	record length	is ws-rec-length. 
*	record is varying in size
*		from 1 to 9000 characters
*		depending on ws-form-feed.
 
*01  input-rec				pic x(9000). 
01   input-rec. 
     05  input-record			pic x(9000). 
     05  input-record-red redefines input-record. 
	 10  ind-byte	occurs 9000	pic x. 
 
 
fd  output-file 
	block contains  9000  characters 
	record contains 1 to 9000 characters. 
*mf	recording mode	is data-sensitive 
*mf	delimiter	is ws-form-feed. 
 
01  output-rec				pic x(9000). 
*    05  output-rec-first-132		pic x(132). 
*    05  output-rec-133			pic x. 
*    05  output-rec-134			pic x. 
*    05 filler				pic x(378). 
 
fd audit-report 
	record contains 133 characters. 
 
01  audit-rec 				pic x(133). 
working-storage section. 
 
*mf 77  ws-null				pic x	value "<000>". 
*mf 77  ws-carr-ret			pic x 	value "<015>". 
*mf 77  ws-line-feed			pic x 	value "<012>". 
*mf 77  ws-form-feed			pic x 	value "<014>". 
77  ws-null				pic x	value x"00". 
77  ws-carr-ret				pic x 	value x"15". 
77  ws-line-feed			pic x 	value x"12". 

01  ws-ff-defn.
    05 ws-form-feed-char		pic x 	value x"14". 
    05 ws-form-feed redefines ws-form-feed-char
					pic 9.
77  ws-rec-length			pic 999. 
 
77  err-ind				pic 99	comp. 
77  input-file-name			pic x(7)	value spaces. 
*mf 77  tape-file-name			pic x(7)	value "@MTD0:0". 
77  tape-file-name			pic x(10)	value "r002aa". 
77  print-file-name			pic x(5)	value "ru801". 
77  ws-ack				pic x		value "N". 
77  ws-disp-msg				pic x(50)	value         
		"AUDIT REPORT IS IN FILENAME RU801". 
77  ws-temp-ctr				pic 9(6). 
77  found-flag				pic x		value 'N'. 
 
 
01  variables. 
    05  ws-max-nbr-options		pic 99		value 10. 
    05  ws-max-nbr-reports		pic 99		value 20. 
 
01  subscripts. 
    05  ss				pic 99		comp. 
    05  ss-opt-nbr			pic 99		comp. 
    05  ss-rept-nbr			pic 99		comp. 
    05  sub				pic 9999	comp. 
 
01  ws-closing-info. 
    05  ws-closing-names. 
	10  ws-closing-names1		pic x(70). 
	10  ws-closing-names2		pic x(70). 
    05  ws-closing-names-r redefines ws-closing-names. 
	10  ws-report occurs 20 times		pic x(7) justified right. 
 
01  counters. 
    05  ctrs-by-rept.                               
	10  ws-ctr-1			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-2			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-3			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-4			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-5			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-6			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-7			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-8			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-9			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-10			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-11			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-12			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-13			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-14			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-15			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-16			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-17			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-18			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-19			pic 9(6). 
	10  filler			pic x		value space. 
	10  ws-ctr-20			pic 9(6). 
	10  filler			pic x		value space. 
    05  ctrs-by-rept-r redefines ctrs-by-rept. 
	10  ctr-tbl-tape-rec-writes. 
	    15  ctr-tape-rec-writes occurs 20. 
		20  ctr-tape-writes	pic 9(6). 
		20  filler		pic x. 
	10  ctr-tape-rec-writes-r redefines ctr-tbl-tape-rec-writes. 
	    15  ctr-tape-writes-a	pic x(70). 
	    15  ctr-tape-writes-b	pic x(70). 
 
01  file-status. 
    05  input-fstat			pic xx. 
*mf    05  input-istat			pic x(11). 
    05  output-fstat			pic xx. 
*mf    05  output-istat			pic x(11). 
    05  audit-fstat			pic xx. 
*mf    05  audit-istat			pic x(11). 
    05  common-f-status			pic xx. 
*mf    05  common-i-status		pic x(11). 
 
01  eof-tape-flag			pic x. 
    88  tape-eof			value "Y". 
    88  tape-not-eof			value "N". 
 
01  eof-report-flag 			pic x. 
    88  report-eof			value "Y". 
    88  report-not-eof			value "N". 
 
01  continue-flag			pic x. 
    88  continue-run			value "Y". 
    88  dont-continue			value "N". 
 
* 
* changes made to "U80X_REPORTS_TBL.WS" to allow for sms 125  s.f. 
* 
 
copy "u80x_reports_tbl.ws". 
 
 
01  l1-print-line. 
 
    05  l1-report-id				pic x(7). 
    05  l1-date					pic x(9).   
    05  l1-date-r redefines l1-date		pic z(8)9. 
    05  l1-msg					pic x(80). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"TAPE NOT PROPERLY MOUNTED". 
	10  filler				pic x(60)   value 
		"REPORT NOT AVAILABLE". 
	10  filler				pic x(60)   value 
		"ERROR MESSAGE #4 GOES HERE". 
	10  filler				pic x(60)   value 
		"ERROR MESSAGE #5 GOES HERE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
*			occurs  4  times. 
			occurs  5  times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
		"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
copy "sysdatetime.ws". 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05			line 01 col 01 value 	"U801". 
    05			line 01 col 32 value 	"DISK TO TAPE COPY". 
    05			line 01 col 73 pic xx/xx/xx using sys-date-long. 
    05			line 03 col 05 pic x(30) using	sel-option-1. 
    05			line 03 col 44 pic x(30) using	sel-option-2. 
    05			line 05 col 05 pic x(30) using	sel-option-3. 
    05			line 05 col 44 pic x(30) using	sel-option-4. 
    05			line 07 col 05 pic x(30) using	sel-option-5. 
    05			line 07 col 44 pic x(30) using	sel-option-6. 
    05			line 09 col 05 pic x(30) using	sel-option-7. 
    05			line 11 col 05 pic x(30) using	sel-option-8. 
    05			line 13 col 05 pic x(30) using	sel-option-9. 
    05			line 13 col 44 pic x(30) using	sel-option-10. 
    05			line 15 col 33 value	"OPTION". 
    05	scr-option	line 15 col 40 pic zz	 using	ss-opt-nbr auto. 
 
     
01  scr-display-reports. 
    05	scr-disp-msg  	line 14 col 01 pic x(50) from   ws-disp-msg.    
 
    05  scr-reports-1a	line 15 col 05 pic x(70) using	sel-reports-1a. 
    05  scr-reports-1b	line 16 col 05 pic x(70) using	sel-reports-1b. 
 
    05  scr-reports-2a	line 15 col 05 pic x(70) using	sel-reports-2a. 
    05  scr-reports-2b	line 16 col 05 pic x(70) using	sel-reports-2b. 
 
    05  scr-reports-3a	line 15 col 05 pic x(70) using	sel-reports-3a. 
    05  scr-reports-3b	line 16 col 05 pic x(70) using	sel-reports-3b. 
 
    05  scr-reports-4a	line 15 col 05 pic x(70) using	sel-reports-4a. 
    05  scr-reports-4b	line 16 col 05 pic x(70) using	sel-reports-4b. 
 
    05  scr-reports-5a	line 15 col 05 pic x(70) using	sel-reports-5a. 
    05  scr-reports-5b	line 16 col 05 pic x(70) using	sel-reports-5b. 
 
    05  scr-reports-6a	line 15 col 05 pic x(70) using	sel-reports-6a. 
    05  scr-reports-6b	line 16 col 05 pic x(70) using	sel-reports-6b. 
 
    05  scr-reports-7a	line 15 col 05 pic x(70) using	sel-reports-7a. 
    05  scr-reports-7b	line 16 col 05 pic x(70) using	sel-reports-7b. 
 
    05  scr-reports-8a	line 15 col 05 pic x(70) using	sel-reports-8a. 
    05  scr-reports-8b	line 16 col 05 pic x(70) using	sel-reports-8b. 
 
    05  scr-reports-9a	line 15 col 05 pic x(70) using	sel-reports-9a. 
    05  scr-reports-9b	line 16 col 05 pic x(70) using	sel-reports-9b. 
 
    05  scr-reports-10a	line 15 col 05 pic x(70) using	sel-reports-10a. 
    05  scr-reports-10b	line 16 col 05 pic x(70) using	sel-reports-10b. 
  
 
01  scr-continue. 
    05				line 20 col 32 value	"CONTINUE (Y/N)".             
    05  scr-ok-to-continue 	line 20 col 50 pic x using continue-flag auto. 
 
01  confirm. 
    05  line 23 col 01  value " ". 
 
01  program-in-progress. 
    05  			line 22 col 27 value 	"PROGRAM IN PROGRESS". 
 
01  file-status-display. 
    05  line 22 col 01 blank line. 
    05  line 22 col 32 value "COBOL FILE STATUS = ". 
    05  line 22 col 52 pic xx	using common-f-status  bell blink. 
*mf    05  line 23 col 01 blank line. 
*mf    05  line 23 col 32 value "INFOS FILE STATUS = ". 
*mf    05  line 23 col 52 pic x(11) using common-i-status  bell blink. 
 
01  err-msg-line. 
    05  			line 24 col 01 value " ERROR - "  bell blink. 
    05  scr-report-name		line 24 col 09 pic x(7) using	input-file-name. 
    05  			line 24 col 16 pic x(60) from err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1 blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-warning-full-tape. 
    05  line 19 col 20	value " WARNING !" bell blink. 
    05  line 19 col 31	value "ALL REPORTS NOT PROCESSED---TAPE FULL!!". 
 
01  scr-acknowledge. 
    05			line 20 col 01 blank line. 
    05			line 20 col 20 value " ACKNOWLEDGE ERROR BY PRESSING 'Y'". 
    05  scr-ack		line 20 col 50 pic x using ws-ack. 
 
01  scr-closing-ctrs. 
    05				line 15 col  5 pic x(70) using ws-closing-names1. 
    05  scr-ctr-1		line 16 col  1 pic z(6)9 using ws-ctr-1 blank when zero. 
    05  scr-ctr-2		line 16 col  8 pic z(6)9 using ws-ctr-2 blank when zero. 
    05  scr-ctr-3		line 16 col 15 pic z(6)9 using ws-ctr-3 blank when zero. 
    05  scr-ctr-4		line 16 col 22 pic z(6)9 using ws-ctr-4 blank when zero. 
    05  scr-ctr-5		line 16 col 29 pic z(6)9 using ws-ctr-5 blank when zero. 
    05  scr-ctr-6		line 16 col 36 pic z(6)9 using ws-ctr-6 blank when zero. 
    05  scr-ctr-7		line 16 col 43 pic z(6)9 using ws-ctr-7 blank when zero. 
    05  scr-ctr-8		line 16 col 50 pic z(6)9 using ws-ctr-8 blank when zero. 
    05  scr-ctr-9		line 16 col 57 pic z(6)9 using ws-ctr-9 blank when zero. 
    05  scr-ctr-10		line 16 col 64 pic z(6)9 using ws-ctr-10 blank when zero. 
    05				line 18 col  5 pic x(70) using ws-closing-names2. 
    05  scr-ctr-11		line 19 col  1 pic z(6)9 using ws-ctr-11 blank when zero. 
    05  scr-ctr-12		line 19 col  8 pic z(6)9 using ws-ctr-12 blank when zero. 
    05  scr-ctr-13		line 19 col 15 pic z(6)9 using ws-ctr-13 blank when zero. 
    05  scr-ctr-14		line 19 col 22 pic z(6)9 using ws-ctr-14 blank when zero. 
    05  scr-ctr-15		line 19 col 29 pic z(6)9 using ws-ctr-15 blank when zero. 
    05  scr-ctr-16		line 19 col 36 pic z(6)9 using ws-ctr-16 blank when zero. 
    05  scr-ctr-17		line 19 col 43 pic z(6)9 using ws-ctr-17 blank when zero. 
    05  scr-ctr-18		line 19 col 50 pic z(6)9 using ws-ctr-18 blank when zero. 
    05  scr-ctr-19		line 19 col 57 pic z(6)9 using ws-ctr-19 blank when zero. 
    05  scr-ctr-20		line 19 col 64 pic z(6)9 using ws-ctr-20 blank when zero. 
    05				line 21 col 10 pic x(50) using ws-disp-msg. 
procedure division. 
declaratives. 
 
err-input-file  section. 
    use after standard error procedure on  input-file. 
input-file-proc. 
    move input-fstat			to	common-f-status. 
*mf    move input-istat			to	common-i-status. 
    display "ERROR - INPUT FILE". 
    display file-status-display. 
 
    if input-fstat = 91 
    then 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
    else 
	display confirm 
	stop "HIT NEW-LINE TO CONTINUE". 
*   endif 
 
    display scr-closing-ctrs. 
    display confirm. 
    stop run. 
 
 
 
err-output-file  section. 
    use after standard error procedure on  output-file. 
output-file-proc. 
    move output-fstat			to	common-f-status. 
*mf    move output-istat			to	common-i-status. 
    display "ERROR - OUTPUT FILE". 
    display file-status-display. 
    if output-fstat = 10 or 34 
    then 
	move "Y"			to	eof-tape-flag 
    else 
	display scr-closing-ctrs 
	if output-fstat = 91 
	then 
	    move 2			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    display confirm 
	    stop "HIT NEW-LINE TO CONTINUE" 
	    stop run 
	else 
	    display confirm 
	    stop "HIT NEW-LINE TO CONTINUE" 
	    stop run. 
*	endif 
*   endif 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit      
	varying	 ss-rept-nbr 
		 from 1 by 1 
	until	 tape-eof 
	      or ss-rept-nbr > ws-max-nbr-reports 
	      or report-name (ss-opt-nbr, ss-rept-nbr) = spaces. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
 
    move spaces				to	input-file-name  
						ws-closing-info. 
    accept sys-date			from	date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    display scr-title. 
 
aa0-10-option.       
*mf (initial option to 0)
    move zero				to	ss-opt-nbr. 
    accept scr-option.          
    if    ss-opt-nbr < 1 
       or ss-opt-nbr > ws-max-nbr-options 
    then 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-option.          
*   (else) 
*   endif 
 
    move "REPORTS TO BE COPIED"		to	ws-disp-msg. 
    display scr-disp-msg.    
    if ss-opt-nbr = 1 
    then 
	display scr-reports-1a 
	display scr-reports-1b 
    else 
	if ss-opt-nbr = 2 
	then 
	    display scr-reports-2a 
	    display scr-reports-2b 
	else 
	    if ss-opt-nbr = 3 
	    then 
		display scr-reports-3a 
		display scr-reports-3b 
	    else 
 	        if ss-opt-nbr = 4 
 	        then 
                    display scr-reports-4a 
                    display scr-reports-4b 
 	        else 
 	            if ss-opt-nbr = 5 
 	            then 
                    	display scr-reports-5a 
                    	display scr-reports-5b 
 	            else 
 	                if ss-opt-nbr = 6 
 	                then 
                    	    display scr-reports-6a 
                    	    display scr-reports-6b 
 	                else 
 	                    if ss-opt-nbr = 7 
 	                    then 
                    		display scr-reports-7a 
                    		display scr-reports-7b 
 	            	    else 
 	            		if ss-opt-nbr = 8 
 	            		then 
                    		    display scr-reports-8a 
                    		    display scr-reports-8b 
 	            		else 
 	            		    if ss-opt-nbr = 9 
 	            		    then 
                    			display scr-reports-9a 
                    			display scr-reports-9b 
 	            		    else 
                    			display scr-reports-10a 
                    			display scr-reports-10b. 
*				    endif 
*               		endif 
*	    		    endif 
*			endif 
*		    endif 
*               endif 
*	    endif 
*	endif 
*   endif 
 
    display scr-continue. 
 
aa0-20-ok-to-continue. 
 
    accept  scr-ok-to-continue.   
    if continue-run 
    then 
	display program-in-progress 
    else 
	if dont-continue 
	then 
	    stop run 
	else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to aa0-20-ok-to-continue. 
*	endif 
*   endif 
 
    open output output-file. 
 
    move  "N"				to	eof-tape-flag 
						eof-report-flag 
						continue-flag. 
    perform aa1-zero-ctrs		thru	aa1-99-exit 
	    varying ss 
	    from 1 
	    by   1 
	    until   ss > ws-max-nbr-reports. 
 
    move spaces				to	ws-disp-msg. 
    move 1				to	ss-rept-nbr. 
 
*    expunge     audit-report. 
    open output audit-report. 
 
    move spaces				to	l1-print-line. 
    move "RU801"			to	l1-report-id. 
    move "DISK TO TAPE COPY STARTED"	to	l1-msg. 
    move sys-dd				to	run-dd. 
    move sys-mm				to	run-mm. 
    move sys-yy				to	run-yy. 
    move run-date			to	l1-date. 
    write audit-rec 			from 	l1-print-line after advancing page. 
    move spaces				to	l1-print-line. 
 
    move option-type (ss-opt-nbr)	to 	l1-msg.   
    write audit-rec 			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
 
aa0-99-exit. 
    exit. 
 
 
 
aa1-zero-ctrs. 
 
    move zero				to	ctr-tape-writes (ss). 
 
aa1-99-exit. 
    exit. 
ab0-processing. 
 
    move report-name (ss-opt-nbr, ss-rept-nbr) to	input-file-name  
							ws-report (ss-rept-nbr). 
    open input input-file. 
 
    perform ba0-process-report			thru	ba0-99-exit 
	until	   report-eof 
		or tape-eof. 
 
    close input-file. 
    move "N"					to	eof-report-flag. 
 
ab0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close output-file. 
 
    display blank-screen. 
    move "AUDIT REPORT IS IN RU801"		to	ws-disp-msg. 
    display scr-disp-msg. 
    display scr-closing-ctrs. 
    display confirm. 
                         
    move zero					to	ws-temp-ctr. 
    perform az1-total-rpt-ctrs			thru	az1-99-exit 
	    varying ss 
	    from 1 
	    by   1 
	    until   ss > ws-max-nbr-reports. 
 
    perform az2-dump-rpt-names-ctrs		thru	az2-99-exit. 
 
    move ws-temp-ctr				to	l1-date-r. 
    move " RECORDS WRITTEN TO TAPE (TOTAL)"	to	l1-msg. 
    write audit-rec 				from 	l1-print-line after advancing 2 lines. 
    move spaces					to	l1-print-line. 
 
az0-10-tape-full. 
 
*    (print warning if not all input file processed) 
    if tape-eof                 
    then 
	display scr-warning-full-tape       
        display scr-acknowledge 
        accept scr-ack 
        if ws-ack not = "Y" 
        then 
    	    go to az0-10-tape-full  
	else 
	    move "*****WARNING - NOT ALL INPUT PROCESSED-END OF TAPE REACHED" 
						to	l1-msg 
	    write audit-rec			from	l1-print-line after advancing 2 lines 
	    move spaces				to	l1-print-line   
*       endif 
    else 
	move "PROGRAM SUCCESSFULLY COMPLETED" 
						to	l1-msg 
	write audit-rec				from	l1-print-line after advancing 2 lines 
    	move spaces				to	l1-print-line. 
*   endif 
               
    close audit-report. 
    stop run. 
 
az0-99-exit. 
    exit. 
az1-total-rpt-ctrs. 
 
    add ctr-tape-writes (ss)			to	ws-temp-ctr.      
 
az1-99-exit. 
    exit. 
 
 
 
az2-dump-rpt-names-ctrs. 
 
    move ws-closing-names1		to 	l1-msg.   
    write audit-rec 			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
    move ctr-tape-writes-a		to 	l1-msg.   
    write audit-rec 			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
 
    move ws-closing-names2		to 	l1-msg.   
    write audit-rec 			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
    move ctr-tape-writes-b		to 	l1-msg.   
    write audit-rec 			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
 
az2-99-exit. 
    exit. 
ba0-process-report. 
 
    move spaces				to	output-rec 
						input-rec. 
 
    read  input-file 
	at end 
	    move "Y"			to 	eof-report-flag. 
 
*   move  input-rec			to	output-rec. 
*   write output-rec. 
 
*   if tape-not-eof 
*   then 
*	add 1				to	ctr-tape-writes (ss-rept-nbr). 
*   (else) 
*   endif 
 
*   (if 'END OF REPORT' is turned on then  last buffer read may not have ended with form-feed. 
*    in which case there may be valid data in input buffer. the following code 
*    writes this last buffer out, unless it is blank, add form-feed as last character) 
 
    if report-eof 
    then 
	if input-rec not = spaces 
	then 
	    move 'N'			to found-flag 
	    move 9000		        to sub 
	    perform ca0-check-noblank-char thru ca0-99-exit 
		varying ss from 1 by 1 
		until found-flag = 'Y' or ss > 9000 
	    move input-rec		to	output-rec 
 	    move spaces			to	input-rec 
	    write output-rec 
	    add 1			to	ctr-tape-writes (ss-rept-nbr) 
	else 
	    next sentence 
*	endif 
    else 
	move input-rec			to	output-rec 
 	move spaces			to	input-rec 
	write output-rec 
	add 1				to	ctr-tape-writes (ss-rept-nbr). 
*   endif 
 
ba0-99-exit. 
    exit. 
 
 
 
ca0-check-noblank-char. 
 
*   try to find the first non-blank characters from the end of the record 
 
    if    ind-byte(sub) not = ws-null 
      and ind-byte(sub) not = space 
    then 
	move 'Y'		to found-flag 
	move ws-form-feed	to ind-byte(sub + 1) 
    else 
	subtract 1		from sub. 
*   endif 
 
ca0-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment  
						e1-error-msg. 
    display err-msg-line. 
    write audit-rec			from	e1-error-line after advancing 2 lines. 
    move spaces				to	e1-error-line. 
    move input-file-name		to	l1-date. 
    move "*****PROGRAM NOT SUCCESSFUL****" to	l1-msg. 
    write audit-rec			from	l1-print-line after advancing 2 lines. 
    move spaces				to	l1-print-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
