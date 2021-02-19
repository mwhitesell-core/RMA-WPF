*  1999/May/20  S.B.	- Y2K checked.
*
identification division. 
program-id.     u999. 
author.         m.so. 
installation.   dyad computer systems inc. 
date-written.   85/01/15. 
date-compiled. 
security. 
* 
* 	program purpose:	this program processes a data sensitive 
*				file wherein individual records are 
*				delimited by "<012>" characters and 
*				creates a fixed length record output 
*				file. 
* 
*				"<012>" - newline 
*				"<000>" - null character 
* 
*		for example:	if an input file contains a record 
*				which is 171 characters long including 
*				one byte of "<012>", then the output 
*				record will be converted to 170 characters 
*				excluding the last byte of "<012>". 
* 
*				if the same input file contains a record 
*				which is 31 characters long including one 
*				byte of "<012>", then the output record will 
*				contain 30 characters and the last 140 
*				characters will be replaced by blanks. 
* 
*				i.e. "<012>" and "<000>" will be replaced 
*				     by blanks. 
* 
***************************************************************************** 
* 
*		note:	whenever this program is used, just change the followings: 
*			1).  the record size of the input file 
*			2).  the record size of the output file 
*			3).  "INPUT-FILE-NAME" 
*			4).  "OUTPUT-FILE-NAME" 
* 
***************************************************************************** 
* 
*		attention:  this program must be compiled using 
*				"E_COBCOMP U999 B" 
* 
**************************************************************************** 
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
*   revised feb/98 j. chau  - s149 unix conversion
* 
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    select input-file 
    assign to input-file-name 
    organization  is  sequential 
    access mode   is  sequential 
    status        is  status-cobol-input-file. 
*mf    infos status  is  status-input-file. 
 
    select output-file 
    assign to output-file-name 
    organization  is  sequential 
    access mode   is  sequential 
    status        is  status-cobol-output-file. 
*mf    infos status  is  status-output-file. 
 
data division. 
file section. 
fd  input-file 
	block		contains 512 characters 
	record		contains 171 characters. 
*mf	recording mode is data-sensitive 
*mf	feedback is	feedback-input-file. 
 
*       delimiter is ws-line-feed. 
 
01  input-rec       				pic x(171). 
 
fd  output-file 
	block		contains 512 characters 
	record		contains 170 characters. 
*mf	feedback is	feedback-output-file. 
 
01  output-rec         				pic x(170). 
 
working-storage section. 
 
77  input-file-name      			pic x(14) 
						value "u011_test_tape". 
77  output-file-name        			pic x(18) 
						value "u011_new_test_tape". 
77  feedback-input-file				pic x(4). 
77  feedback-output-file			pic x(4). 
 
*mf 01  ws-line-feed				pic x     value "<012>". 
*mf 01  ws-null-char				pic x     value "<000>". 
01  ws-line-feed				pic x     value x"12". 
01  ws-null-char				pic x     value x"00". 
01  ws-blank					pic x     value " ". 
 
01  flag-file					pic x. 
    88  end-of-file				value "Y". 
    88  not-end-of-file				value "N". 
* 
*   (status file indicators.) 
* 
01  status-indicators. 
*mf    05  status-file				pic x(11). 
*mf    05  status-input-file			pic x(11) value "0". 
*mf    05  status-output-file  			pic x(11) value "0". 
    05  status-file				pic xx.
    05  status-cobol-input-file                	pic xx    value "0". 
    05  status-cobol-output-file		pic xx    value "0". 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 12 col 16 value "INPUT FILE NOW BEING PROCESSED". 
* 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U999 ENDING". 
procedure division. 
declaratives. 
 
err-input-file-file section. 
    use after standard error procedure on input-file. 
err-input-file. 
    stop "ERROR IN ACCESSING INPUT FILE". 
*mf    move status-input-file    		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-input-file       to status-file. 
    display file-status-display. 
    stop run. 
 
err-output-file-file section. 
    use after standard error procedure on output-file. 
err-output-file. 
    stop "ERROR IN ACCESSING OUTPUT FILE". 
*mf    move status-output-file		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-output-file	to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization			thru aa0-99-exit. 
    perform ab0-processing 			thru ab0-99-exit 
	    until end-of-file. 
    perform az0-end-of-job			thru az0-99-exit. 
 
aa0-initialization. 
 
*    expunge output-file. 
    open input 	input-file. 
    open output output-file. 
    display scr-title. 
    move "N"			to flag-file. 
 
aa0-99-exit. 
    exit. 
 
 
ab0-processing. 
 
    move spaces			to input-rec. 
    read input-file 
   	at end 
      	    move "Y"		to flag-file 
	    go to ab0-99-exit. 
 
    move spaces        		to output-rec. 
    move input-rec     		to output-rec. 
    inspect output-rec replacing 
	all ws-line-feed by ws-blank, 
        all ws-null-char by ws-blank. 
    write output-rec. 
 
ab0-99-exit. 
    exit. 
 
 
az0-end-of-job. 
 
    close input-file 
	  output-file. 
    display scr-closing-screen. 
    stop run. 
 
az0-99-exit. 
    exit. 
 
