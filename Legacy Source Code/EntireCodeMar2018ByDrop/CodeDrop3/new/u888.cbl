identification division. 
program-id. u888. 
installation.   rma. 
date-written. 91/06/07. 
date-compiled. 
security. 
* 
*    FILES   - INPUT	:          - ONE EBCDIC FILE FROM U020 
*	 
*	     - OUTPUT	: "MTD0:0" - TAPE FILE. 
*	 
* 
*    PROGRAM PURPOSE: 
*	DISK TO TAPE UTILITY FOR CREATING TAPE. 
*mf     - program reads in 79 byte records and puts out 2 logical records
*mf         into a one 158 byte physical record
* 
* 
*	REVISION  HISTORY 
*	 
*       DATE		PROGRAMMER	REASON FOR CHANGE 
* 
*     06/07/91         B.M.L.     ORIGINAL 
*     98/08/01         B.E.       unix conversion 
*				  - changed name of input/output files
*     98/jun/23		B.E.	- converted to MF cobol
*				- changed from writing to tape to writing 
*				  to disk. This file then ftp'd to CSU's HP
*				  where it's converted to ebcdic and copied
*				  to tape.
*   1999/May/07		S.B.	- y2k changes to screen section.
*
environment division. 
input-output section. 
file-control. 
 
	select input-file 
		assign to	input-file-name 
		file  status is input-fstat.
*mf		infos status is input-istat. 
 
	select output-file 
		assign to	tape-file-name 
		file  status is output-fstat. 
*mf		infos status is output-istat. 
 
data division. 
file section. 
 
fd  input-file  
	record contains 79  characters. 
 
01  input-rec				pic x(79). 
 
 
fd  output-file 
	record contains 158  characters. 
* 	RECORDING MODE	IS DATA-SENSITIVE 
*	DELIMITER	IS WS-LINE-FEED. 
 
01  output-rec. 
    05  output-rec-1        		pic x(79). 
    05  output-rec-2    		pic x(79). 
 
 
working-storage section. 
 
*mf 77  ws-line-feed    pic x       value "<012>". 
77  err-ind		pic 99	comp. 
*mf 77  input-file-name	pic x(29) value "OHIP_TAPE_CONVERTED_TO_EBCDIC". 
*77  input-file-name	pic x(10)	value "ohiptape79". 
77  input-file-name	pic x(17)	value "u020_tapeout_file". 
*mf 77  tape-file-name	pic x(7)	value "@MTD0:0". 
*77  tape-file-name	pic x(8)	value "ohiptape". 
77  tape-file-name	pic x(18)	value "u020_tapeout_file2". 

77  ws-ack				pic x		value "N". 
 
01  file-status. 
    05  input-fstat			pic xx. 
    05  input-istat			pic x(11). 
    05  output-fstat			pic xx. 
    05  output-istat			pic x(11). 
    05  common-f-status			pic xx. 
    05  common-i-status			pic x(11). 
 
01  eof-tape-flag			pic x. 
    88  tape-eof			value "Y". 
    88  tape-not-eof			value "N". 
 
01  eof-report-flag 			pic x. 
    88  report-eof			value "Y". 
    88  report-not-eof			value "N". 
 
01  continue-flag			pic x. 
    88  do-continue			value "Y". 
    88  dont-continue			value "N". 
  
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
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs  4  times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
		"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
copy "sysdatetime.ws". 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05			line 01 col 01 value 	"U888". 
    05			line 01 col 30 value 	"OHIP TAPE 79 to 158 byte copy".
* (y2k - auto fix)
*   05			line 01 col 73 pic xx/xx/xx using sys-date-long. 
    05			line 01 col 70 pic xxxx/xx/xx using sys-date-long. 
     
 
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
    05  line 23 col 01 blank line. 
    05  line 23 col 32 value "INFOS FILE STATUS = ". 
    05  line 23 col 52 pic x(11) using common-i-status  bell blink. 
 
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
 
procedure division. 
declaratives. 
 
err-input-file  section. 
    use after standard error procedure on  input-file. 
input-file-proc. 
    move input-fstat			to	common-f-status. 
    move input-istat			to	common-i-status. 
    display "ERROR - INPUT FILE". 
    display file-status-display. 
 
    if input-fstat = 91 
    then 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
    else 
	display confirm 
	stop "HIT NEW-LINE TO CONTINUE". 
*   ENDIF 
 
    stop run. 
 
 
 
err-output-file  section. 
    use after standard error procedure on  output-file. 
output-file-proc. 
    move output-fstat			to	common-f-status. 
    move output-istat			to	common-i-status. 
    display "ERROR - OUTPUT FILE". 
    display file-status-display. 
    if output-fstat = 10 or 34 
    then 
	move "Y"			to	eof-tape-flag 
    else 
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
*	ENDIF 
*   ENDIF 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit      
	until	     report-eof. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
 
    accept sys-date			from	date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
*mf
*   display scr-title. 
 
*mf 
*   display scr-continue. 
 
aa0-20-ok-to-continue. 

*mf
    move "Y" to continue-flag.

*mf
*   accept  scr-ok-to-continue.   
    if do-continue 
    then 
*	display program-in-progress 
	next sentence
    else 
	if dont-continue 
	then 
	    stop run 
	else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to aa0-20-ok-to-continue. 
*	ENDIF 
*   ENDIF 
 
    open  input input-file. 
    open output output-file. 
 
    move  "N"				to	eof-tape-flag 
						eof-report-flag 
						continue-flag. 
 
    perform da0-read-input-file         thru da0-99-exit. 
    if     report-eof 
    then 
        next sentence 
    else 
        move input-rec                  to output-rec-1. 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
    perform da0-read-input-file                   thru da0-99-exit. 
    if     report-eof 
    then 
        move spaces                               to output-rec-2 
    else 
        move input-rec                            to output-rec-2. 
 
    write output-rec. 
    move spaces					to output-rec. 
 
    perform da0-read-input-file                   thru da0-99-exit. 
    if     report-eof 
    then 
        next sentence 
    else 
        move input-rec                            to output-rec-1. 
 
 
ab0-99-exit. 
    exit. 
 
da0-read-input-file. 
 
    read input-file 
         at end 
            move "Y"                              to eof-report-flag. 
 
da0-99-exit. 
    exit. 
 
az0-end-of-job. 
 
    close output-file 
           input-file. 
 
 
az0-10-tape-full. 
 
*    (PRINT WARNING IF NOT ALL INPUT FILE PROCESSED) 
    if tape-eof                 
    then 
	display scr-warning-full-tape       
        display scr-acknowledge 
        accept scr-ack 
        if ws-ack not = "Y" 
        then 
    	    go to az0-10-tape-full. 
 
az0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
