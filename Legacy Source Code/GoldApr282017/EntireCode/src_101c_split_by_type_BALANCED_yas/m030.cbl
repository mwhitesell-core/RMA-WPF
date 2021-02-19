identification division. 
program-id. m030.   
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    program id : m030  
*    files      : location master file 
*		: constants master 
*		: audit file 
*    program purpose : location master maintenance.   
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*              sept/87 (c.e)  - mode changes, old code '**' 
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
*  1999/jan/15 B.E.		- y2k
*  1999/apr/27 B.E.		- added maintenance of new fields added to f030 file
*  2000/mar/21 M.C.		- allow loc-card-colour to have the values 'I'n
*				  or 'O'ut as patient indicator
* 				- reserve loc-card-colour for i/o ind
*  2000/feb/29 M.C.             - change card colour label to Payroll for hsc on
*                                 and edit check on clinic nbr for hsc clinic on
*  2001/Feb/05 A.A              - Change loc-card-colour title to "I/O INDICATOR
*                                 and edit check changed to "I","O" or "B" for t
*                                 and added new item "loc-payroll-flag" that pla
*                                     the old role of "loc-card-colour" item
*
* 2001/may/03 B.E.	- reconcile above changes into common program between
*			  HSC and RMA
*			- added new 'active for entry' field
* 2006/apr/06 M.C.	- add service location indicator for hospital in-patient
*			  diagnostic services 

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
copy "f030_locations_mstr.slr". 
* 
    select audit-file 
          assign to printer print-file-name 
	  file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
copy "f030_locations_mstr.fd". 
fd  audit-file 
    record contains 132 characters. 
 
01  audit-record				pic x(132).					 
working-storage section. 
copy "site_id.ws".
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
			value "rm030". 
77  option					pic x. 
* 
*  eof flags 
* 
77  eof-loc-mstr				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  status-file				pic x(11). 
*mf 77  status-loc-mstr				pic x(11) value zero. 

77  status-file					pic x(2). 
77  status-cobol-loc-mstr			pic x(2) value zero. 
77  status-audit-rpt				pic xx	  value zero. 
* 
77  confirm-space				pic x   value space. 
* 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-loc-mstr-reads			pic 9(7). 
    05  ctr-loc-mstr-writes			pic 9(7). 
    05  ctr-loc-mstr-rewrites			pic 9(7). 
    05  ctr-audit-rpt-writes			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"LOCATION ALREADY EXISTS". 
	10  filler				pic x(60)   value 
			"INVALID Clinic Nbr". 
	10  filler				pic x(60)   value 
			"INVALID HOSPITAL NUMBER". 
	10  filler				pic x(60)   value 
			"LOCATION NAME MUST NOT BE BLANK". 
	10  filler				pic x(60)   value 
*2000/03/21 - MC
*			"CARD COLOUR MUST BE  'B','Y', OR BLANK". 
			"I/O Indicator must be  'I'n or 'O'ut". 
	10  filler				pic x(60)   value 
			"RECORD DOESN'T EXIST". 
	10  filler				pic x(60)   value 
			"'Active for entry' flag must be 'Y'es or 'N'o". 
	10  filler				pic x(60)   value 
			"PAYROLL FLAG must be 'Y'es or 'N'o".
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
     05 line 01 col 01 value is "M030        LOCATION MASTER MAINTENANCE -". 
     05 line 01 col 42 pic x to option auto required. 
     05 line 01 col 44 value is "(ADD/CHANGE/DELETE/INQUIRY)". 
* (y2k - auto fix)
*    05 line 01 col 73 pic 99 from sys-yy. 
     05 line 01 col 71 pic 9(4) from sys-yy. 
     05 line 01 col 75 value is "/". 
     05 line 01 col 76 pic 99 from sys-mm. 
     05 line 01 col 78 value is "/". 
     05 line 01 col 79 pic 99 from sys-dd. 
*                     
01 scr-option-displays. 
05  scr-option-add    	line 1 col 42 "ADD                           ". 
    05  scr-option-chg	line 1 col 42 "CHANGE                        ". 
    05  scr-option-del	line 1 col 42 "DELETE                        ". 
    05  scr-option-inq	line 1 col 42 "INQUIRY                       ". 
* 
01 scr-acpt-loc-nbr. 
     05 line 03 col 10 value is "LOCATION NUMBER:". 
     05 line 03 col 28 pic x999 to loc-nbr auto. 
*                       
01 scr-mask1. 
     05				line 06 col 01 value is 
						"Location Name          -". 
     05 scr-loc-name 		line 06 col 28 pic x(24) using 
						loc-name auto. 
     05				line 08 col 01 value is 
						"Clinic Number          -". 
     05 scr-clinic-nbr 		line 08 col 28 pic 9(4) 
						using loc-clinic-nbr auto. 
     05				line 10 col 01 value is 
						"Hospital Number        -". 
     05 scr-hospital-nbr	line 10 col 28 pic z(4) using 
						loc-hospital-nbr auto. 
     05				line 11 col 01 value is 
						"   ''    Code          -". 
     05 scr-hospital-code	line 11 col 28 pic x(4) using 
						loc-hospital-code auto. 
     05				line 13 col 01 value is
						"Ministry Location      -".
     05 scr-loc-ministry-loc	line 13 col 28 pic 9(4) using 
						loc-ministry-loc-code auto. 

     05				line 15 col 01 value is 
*2000/03/21 - MC substitute card colour as i/o ind
*		              			"CARD COLOUR       -". 
						"I/O Indicator          -". 
     05 scr-in-out-ind		line 15 col 28 pic x using 
					loc-in-out-ind auto.
*					     loc-card-colour auto. 

     05				line 17 col 01 value is
						"Payroll Flag           -".
     05 scr-payroll-flag    	line 17 col 28 pic x using 
				        loc-payroll-flag.
     05				line 19 col 01 value is
						"Active for Data Entry? -".
     05 scr-active-for-entry	line 19 col 28 pic x using 
				        loc-active-for-entry auto.
* 2006/04/06 - MC
     05				line 21 col 01 value is
						"service Location Indicator".
     05 scr-serv-loc-ind        line 21 col 28 pic x(4) using 
				        loc-service-location-indicator auto.
* 2006/04/06 - end
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
    05  line 24 col 30	value "ACCEPT (Y/N/M) ". 
    05  line 24 col 45	pic x	to flag. 
 
01  verification-screen-inq. 
    05  line 24 col 30 value "CONTINUE X". 
    05  line 24 col 45 pic x   to flag. 
 
01  verification-screen-del. 
    05  line 24 col 30 value "DELETE (Y/N)". 
    05  line 24 col 45 pic x   to flag. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  5 col 20  value "NUMBER OF LOC-MSTR ACCESSES = ". 
    05  line  5 col 60  pic 9(7) from ctr-loc-mstr-reads. 
*    05  line  9 col 20  value "NUMBER OF X ACCESSES = ". 
*    05  line  9 col 60  pic 9(7) from ctr-x. 
*    05  line  9 col 20  value "NUMBER OF X ACCESSES = ". 
*    05  line  9 col 60  pic 9(7) from ctr-x. 
*    05  line  9 col 20  value "NUMBER OF X ACCESSES = ". 
*    05  line  9 col 60  pic 9(7) from ctr-x. 
    05  line  6 col 20  value "NUMBER OF LOC-MSTR WRITES = ". 
    05  line  6 col 60  pic 9(7) from ctr-loc-mstr-writes. 
    05  line  7 col 20  value "NUMBER OF LOC-MSTR REWRITES = ". 
    05  line  7 col 60  pic 9(7) from ctr-loc-mstr-rewrites. 
    05  line  8 col 20  value "NUMBER OF AUDIT RPT WRITES = ". 
    05  line  8 col 60  pic 9(7) from ctr-audit-rpt-writes. 
*    05  line  9 col 20  value "NUMBER OF X WRITES = ". 
*    05  line  9 col 60  pic 9(7) from ctr-x. 
    05  line 21 col 20	value "PROGRAM M030 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40	pic 99	from sys-yy. 
    05  line 21 col 40	pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
    05  line 23 col 20	value "AUDIT REPORT IS IN FILE - ". 
    05  line 23 col 51	pic x(7)	from print-file-name. 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
 
procedure division. 
declaratives. 
err-loc-mstr-file section. 
    use after standard error procedure on loc-mstr.       
err-loc-mstr. 
    stop "ERROR IN ACCESSING LOCATION MASTER". 
*mf    move status-loc-mstr		to status-file. 
    move status-cobol-loc-mstr		to status-file. 
    display file-status-display. 
    stop run. 
 
err-audit-rpt-file section. 
    use after standard error procedure on audit-file.     
err-audit-rpt. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE". 
    move status-audit-rpt		to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru	ab0-99-exit. 
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
 
 
*	delete audit file 
*    expunge audit-file. 
 
*    open input constants-master. 
    open i-o loc-mstr. 
    open output audit-file. 
 
** 
** aa0-10 has been transfered to ab0-processing. 
** sept 24/87 c.e. 
** 
** 
** aa0-10. 
** 
**  display scr-title. 
**  accept scr-title. 
** 
**  if option = "A" 
**  then 
**	display scr-option-add 
**  else 
**	if option = "C" 
**	then 
**	    display scr-option-chg 
**	else 
**	    if option = "D" 
**	    then 
**		display scr-option-del 
**	    else 
** 		if option = "I" 
**		then 
**		    display scr-option-inq 
**		else 
**		    move 1		to err-ind 
**		    perform za0-common-error 
**					thru za0-99-exit 
**		    go to aa0-10. 
**		endif 
** 	    endif 
**	endif 
**  endif 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
** aa0-10. 
 
    display scr-title. 
    accept scr-title. 
 
    if option = "A" 
    then 
  	display scr-option-add 
    else 
  	if option = "C" 
  	then 
  	    display scr-option-chg 
  	else 
  	    if option = "D" 
  	    then 
  		display scr-option-del 
  	    else 
   		if option = "I" 
  		then 
  		    display scr-option-inq 
  		else 
		    if option = "*"
		    then 
			go to ab0-99-exit 
		    else 
  			move 1		to err-ind 
  			perform za0-common-error 
  					thru za0-99-exit 
  			go to ab0-processing. 
*		    endif 
* 		endif 
*  	    endif 
* 	endif 
*   endif 
 
ab0-01. 
 
    move spaces				to loc-mstr-rec. 
* 
*  (display location nbr prompt) 
    display scr-acpt-loc-nbr. 
 
    accept scr-acpt-loc-nbr. 
    if   loc-nbr = "*" 
      or loc-nbr = "**" 
      or loc-nbr = "***" 
      or loc-nbr = "****" 
    then 
**         go to ab0-99-exit. 
	   go to ab0-processing. 
*   (else) 
*   endif 
 
    move "N"				to flag. 
    perform ma0-read-loc-mstr		thru ma0-99-exit. 
 
    if    ok 
     and option = "A" 
    then 
*	(error - rec already exists) 
	move 2				to err-ind 
	perform za0-common-error	thru za0-99-exit 
**	go to ab0-processing. 
	go to ab0-01. 
*   (else) 
*   endif 
 
    if not-ok 
    then 
	if  option = "I" 
	 or option = "C" 
	 or option = "D" 
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
 
ab0-05. 
 
    display scr-mask1. 
 
    if  option = "A" 
     or option = "C" 
    then 
*	validate data for record 
	perform ka0-acpt-loc-name	thru	ka0-99-exit 
	perform ia0-acpt-clinic-nbr	thru	ia0-99-exit 
	perform ja0-acpt-hospital-nbr	thru	ja0-99-exit 
	perform sa0-acpt-hospital-code	thru	sa0-99-exit 
	perform ta0-acpt-ministry-loc	thru	ta0-99-exit
	perform la0-acpt-in-out-ind	thru	la0-99-exit
        perform va0-acpt-payroll-flag   thru    va0-99-exit
	perform ua0-acpt-active-flag	thru	ua0-99-exit.
*   (else) 
*   endif 
 
ab0-10. 
 
    if  option = "A" 
     or option = "C" 
    then 
	display verification-screen-add-chg 
	accept verification-screen-add-chg 
    else 
	if option = "D" 
	then 
	    display verification-screen-del 
	    accept verification-screen-del 
	else 
	    display verification-screen-inq 
	    accept verification-screen-inq. 
*	endif 
*   endif 
 
    if option not = "I" 
    then 
	if flag = "Y" 
	then 
	    if option = "A" 
	    then 
		perform na0-write-loc-mstr 
					thru	na0-99-exit 
		perform ra0-write-audit-rpt 
					thru	ra0-99-exit 
		move spaces		to flag 
		display verification-screen-add-chg 
	    else 
		if option = "C" 
		then 
		    perform pa0-re-write-loc-mstr 
					thru	pa0-99-exit 
		    perform ra0-write-audit-rpt 
					thru	ra0-99-exit 
		    move spaces		to	flag 
		    display verification-screen-add-chg 
 		else 
		    perform qa0-delete-loc-mstr 
					thru	qa0-99-exit 
		    perform ra0-write-audit-rpt 
					thru	ra0-99-exit 
		    move spaces		to	flag 
		    display verification-screen-del 
*		endif 
*	    endif 
	else 
	    if flag = "N" 
	    then 
		display scr-reject-entry 
		display confirm 
		stop " " 
		display blank-line-24 
	    else 
		if flag = "M" 
		then 
		    go to ab0-05 
		else 
		    move 1		to err-ind 
		    perform za0-common-error 
					thru za0-99-exit 
		    go to ab0-05 
*	endif 
    else 
	display verification-screen-inq. 
*   endif 
 
    move spaces				to	loc-mstr-rec. 
    display scr-mask1. 
 
**    go to ab0-processing. 
      go to ab0-01. 
 
ab0-99-exit. 
    exit. 


ia0-acpt-clinic-nbr. 

*   NOTE below edits should look at constants master instead of hard coded
*	DO IT SOMEDAY

    accept scr-clinic-nbr. 
    if  (    site-id = "RMA"
         and ( loc-clinic-nbr =    2215 
			       or  6008 
			       or  4308 
	     )
	)
      or
	(    site-id = "HSC"
         and ( loc-clinic-nbr =    2215 
			       or  9999
	     )
	)
    then 
	next sentence 
    else 
	move 3				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ia0-acpt-clinic-nbr. 
ia0-99-exit. 
    exit. 
 
 
 
 
 
ja0-acpt-hospital-nbr. 
    accept scr-hospital-nbr. 
 
* 
*	read cm and verify if hospital number is valid. 
* 
 
    perform ja1-read-conmstr		thru ja1-99-exit. 
 
*    if not-ok 
*    then 
*	move 4				to err-ind 
*	perform za0-common-error	thru za0-99-exit 
*	go to ja0-acpt-hospital-nbr. 
*   (else) 
*   endif 
 
ja0-99-exit. 
    exit. 
 
 
 
 
 
ja1-read-conmstr. 
 
*instr 
 
ja1-99-exit. 
    exit. 
 
 
ka0-acpt-loc-name. 
    accept scr-loc-name. 
 
    if loc-name = spaces 
    then 
	move 5				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ka0-acpt-loc-name. 
*   (else) 
*   endif 
 
 
ka0-99-exit. 
    exit. 
 
 
la0-acpt-in-out-ind. 
    accept scr-in-out-ind. 

*2000/03/21 - MC 
*   if loc-card-colour			=   "B" 
*				         or "Y" 
*				         or spaces 
* 2001/may/03 B.E. - in/out indicators MUST be set - "B"oth not allowed
    if loc-in-out-ind			=   "I" 
				         or "O" 
*					         or "B"    
    then 
	next sentence 
    else 
	move 6				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to la0-acpt-in-out-ind. 
*   endif 
 
la0-99-exit. 
    exit. 
 
 
ua0-acpt-active-flag.
    accept scr-active-for-entry.

    if loc-active-for-entry		=   "Y" 
				         or "N" 
    then 
	next sentence 
    else 
	move 8				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ua0-acpt-active-flag. 
*   endif
    
ua0-99-exit.
    exit. 
 
 
ma0-read-loc-mstr. 
 
   read loc-mstr 
	invalid key 
		move "N"		to flag 
		go to ma0-99-exit. 
 
    move "Y"				to flag. 
    add 1				to ctr-loc-mstr-reads. 
 
ma0-99-exit. 
    exit. 
 
 
 
 
 
na0-write-loc-mstr. 
 
    write loc-mstr-rec 
	invalid key 
	    perform err-loc-mstr. 
 
    add 1				to ctr-loc-mstr-writes. 
 
na0-99-exit. 
    exit. 
 
 
 
 
pa0-re-write-loc-mstr. 
 
    rewrite loc-mstr-rec. 
    add 1				to ctr-loc-mstr-rewrites. 
 
pa0-99-exit. 
    exit. 
 
 
 
 
 
qa0-delete-loc-mstr. 
 
*   delete loc-mstr record physical. 
    delete loc-mstr record. 
 
qa0-99-exit. 
    exit. 
 
 
ra0-write-audit-rpt. 
 
    move loc-mstr-rec			to audit-record. 
    write audit-record. 
 
    add 1				to ctr-audit-rpt-writes. 
 
ra0-99-exit. 
    exit. 


sa0-acpt-hospital-code.
    accept scr-hospital-code.
sa0-99-exit.
    exit. 


ta0-acpt-ministry-loc.
    accept scr-loc-ministry-loc.
* 2006/04/06 - MC
    accept scr-serv-loc-ind.
* 2006/04/06 - end
ta0-99-exit.
    exit.


va0-acpt-payroll-flag.

*   (payroll flag valid only at HSC)
    if site-id <> "HSC" 
    then 
	go to va0-99-exit.
*   endif

    accept scr-payroll-flag.

    if loc-payroll-flag                 =   "Y"
                                         or "N"
    then
        next sentence
    else
        move 8                          to err-ind
        perform za0-common-error        thru za0-99-exit
        go to va0-acpt-payroll-flag.
*   endif

va0-99-exit.
    exit.



az0-end-of-job. 
    
    display blank-screen. 
 
    close  loc-mstr 
           audit-file. 
 
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
zb0-dump-file-rec-cntrs. 
 
*instr 
 
zb0-99-exit. 
    exit. 

    copy "y2k_default_sysdate_century.rtn".
