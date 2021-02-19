identification division. 
program-id. u080. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 85/12/03. 
date-compiled. 
security. 
* 
*    files      : f010 - patient master 
*		: f010 - new patient master 
*		: ru080 - report file 
* 
*    program purpose : copy the patient master to the new patient 
*        	       master, checking keys. 
*                      report run statistics and errors. 
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
*   revised march/91 : - sms 138 (b.m.l.) 
*                      - remove access to subscriber file 
* 
*   revised july/92  : - if health nbr and ohip nbr and chart nbr 
*			 are all blank, print warning but still 
*			 include the record. 
*   revised 1999/May/18 S.B.	- Y2K conversion.
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f010_new_patient_mstr.slr". 
* 
    copy "f010_newest_pat_mstr.slr". 
* 
*mf    copy "f010_newest_pat_mstr_od.slr". 
* 
*mf    copy "f010_newest_pat_mstr_hc.slr". 
* 
*mf    copy "f010_newest_pat_mstr_acr.slr". 
* 
*mf    copy "f010_newest_pat_mstr_chrt.slr". 
* 
* 
    select print-file 
          assign to printer print-file-name 
	  file status is status-print-file. 
* 
data division. 
file section. 
* 
    copy "f010_patient_mstr.fd". 
* 
    copy "f010_patient_mstr_new.fd". 
* 
*mf    copy "f010_patient_mstr_od_new.fd". 
* 
*mf    copy "f010_patient_mstr_hc_new.fd". 
* 
*mf    copy "f010_patient_mstr_acr_new.fd". 
* 
*mf    copy "f010_patient_mstr_chrt_new.fd". 
* 
* 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(12)  
		value "ru080". 
77  pat-occur					pic 9(12). 
77  pat-new-occur				pic 9(12). 
77  feedback-pat-mstr				pic x(4). 
77  feedback-pat-mstr-new			pic x(4). 
77  feedback-pat-mstr-new-od			pic x(4). 
77  feedback-pat-mstr-new-hc			pic x(4). 
77  feedback-pat-mstr-new-acr			pic x(4). 
77  feedback-pat-mstr-new-chrt			pic x(4). 
* 
* 
*  status file indicators 
* 
01  status-indicators. 
*mf    05  status-file				pic x(11). 
    05  status-file				pic x(2). 
*mf    05  status-pat-mstr				pic x(11) value zero. 
*mf    05  status-pat-mstr-new			pic x(11) value zero. 
*mf    05  status-pat-mstr-od-new			pic x(11) value zero. 
*mf    05  status-pat-mstr-hc-new			pic x(11) value zero. 
*mf    05  status-pat-mstr-acr-new			pic x(11) value zero. 
*mf    05  status-pat-mstr-chrt-new		pic x(11) value zero. 
    05  status-print-file			pic xx    value zero. 
    05  status-cobol-pat-mstr			pic xx    value zero. 
    05  status-cobol-pat-mstr-new		pic xx    value zero. 
    05  status-cobol-pat-mstr-od-new		pic xx    value zero. 
    05  status-cobol-pat-mstr-hc-new		pic xx    value zero. 
    05  status-cobol-pat-mstr-acr-new		pic xx    value zero. 
    05  status-cobol-pat-mstr-chrt-new		pic xx    value zero. 
 
*mf 01  duplicate-key-status			pic x(4) value "0200". 
01  duplicate-key-status			pic x(2) value "22". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-pat-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-writes			pic 9(7). 
    05  ctr-pat-ikey-writes			pic 9(7). 
    05  ctr-ohip-key-writes			pic 9(7). 
    05  ctr-chart-key-writes 			pic 9(7). 
    05  ctr-direct-key-writes 			pic 9(7). 
    05  ctr-health-key-writes                   pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"FATAL - NEW PATIENT MSTR NOT EMPTY!!!". 
	10  filler				pic x(60)   value 
			"FATAL - PATIENT OHIP NBR ALREADY EXISTS". 
	10  filler				pic x(60)   value 
			"FATAL - PATIENT CHART NBR ALREADY EXISTS ". 
	10  filler				pic x(60)   value 
			"FATAL - DIRECT ID ALREADY EXISTS  ". 
	10  filler				pic x(60)   value 
			"FATAL - IKEY ALREADY EXISTS      ". 
	10  filler				pic x(60)   value 
			"DIRECT-ID DOES NOT BEGIN 3 LETTERS". 
	10  filler				pic x(60)   value 
			"CHART NBR MUST BEGIN WITH A LETTER". 
	10  filler				pic x(60)   value 
			"INVALID MONTH OHIP PATIENT ID". 
	10  filler				pic x(60)   value 
			"FATAL - HEALTH HEALTH NBR ALREADY EXISTS ". 
	10  filler				pic x(60)   value 
			"HEALTH, OHIP AND CHART NUMBERS = SPACES". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 10 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
01  e2-status-line. 
 
    05  e2-file-name 				pic x(20). 
*mf    05  filler                                  pic x(8)     value 
*mf     "INFOS = ". 
*mf    05  e2-infos-status                         pic x(11). 
    05  filler                                  pic x(10)    value 
        "  COBOL = ". 
    05  e2-cobol-status                         pic x(2). 
    copy "sysdatetime.ws". 
 
 
 
01  print-heading. 
    05  filler					pic x(44) 
        value "RU080            U080 PATIENT MASTER COPY". 
    05  pr-desc					pic x(10). 
* (y2k)
    05  pr-date					pic x(10). 
    05  pr-time					pic x(10). 
 
01  l1-print-line. 
 
    05  l1-desc					pic x(40). 
    05  l1-value				pic zzz,zz9. 
    05  filler					pic x(85). 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 12 col 16 value "COPYING PATIENT MASTER TO NEW FILE...". 
* 
01 file-status-display. 
    05  line 24 col 01 "ERROR IN ACCESSING PAT MSTR - KEY = ". 
*mf    05  line 24 col 39 pic x(16) from key-new-pat-mstr. 
    05  line 24 col 39 pic x(16) from new-key-pat-mstr. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U080 - FINISHED". 
* (y2k - auto fix) - fixed alignment after sys-yy
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min. 
    05  line 23 col 20	value "PRINT REPORT IS IN FILE - ". 
    05  line 23 col 51	pic x(12) from print-file-name. 
 
procedure division. 
declaratives. 
 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
    move "F010-PAT-MSTR" to e2-file-name. 
*mf    move status-pat-mstr to e2-infos-status. 
    move status-cobol-pat-mstr to e2-cobol-status. 
    write print-record from e2-status-line after 2. 
 
*mf    move status-pat-mstr		to status-file. 
    move status-cobol-pat-mstr		to status-file. 
    display file-status-display. 
    stop run. 
 
err-pat-mstr-new-file section. 
    use after standard error procedure on new-pat-mstr. 
err-pat-mstr-new. 
 
    move "F010-PAT-MSTR-NEW" to e2-file-name. 
*mf    move status-pat-mstr-new to e2-infos-status. 
    move status-cobol-pat-mstr-new to e2-cobol-status. 
    write print-record from e2-status-line after 2. 
 
*mf    move status-pat-mstr-new		to status-file. 
    move status-cobol-pat-mstr-new		to status-file. 
    display file-status-display. 
*mf    stop run "REPORT I-KEY - RU080". 
    stop run. 
 
 
err-print-rpt-file section. 
    use after standard error procedure on print-file. 
err-print-rpt. 
    stop "ERROR IN WRITING TO PRINT REPORT FILE". 
    move status-print-file		to status-file. 
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
 
*mf    delete file print-file. 
 
    open input	pat-mstr. 
    open i-o   	new-pat-mstr .
*mf               	new-od-pat-mstr 
*mf               	new-hc-pat-mstr 
*mf               	new-acr-pat-mstr 
*mf               	new-chrt-pat-mstr. 
*    expunge print-file. 
    open output print-file. 
 
    move 0				to	counters. 
*   move spaces				to	key-pat-mstr. 
 
    display scr-title. 
 
    move "START"			to	pr-desc. 
    move run-date			to	pr-date. 
    move run-time			to 	pr-time. 
    write print-record 			from    print-heading. 
 
    read new-pat-mstr next 
        at end go to aa0-99-exit. 
 
    move 1  				to 	err-ind. 
    move err-msg (err-ind)		to	print-record. 
    write print-record			after advancing 1 line. 
    perform err-pat-mstr-new. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform az1-totals			thru az1-99-exit. 
 
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm. 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
    move "STOP" 			to pr-desc. 
    move run-date			to pr-date. 
    move run-time			to pr-time. 
    write print-record			from print-heading after 2. 
 
    close pat-mstr 
	  new-pat-mstr 
*mf	  new-od-pat-mstr 
*mf	  new-hc-pat-mstr 
*mf	  new-acr-pat-mstr 
*mf	  new-chrt-pat-mstr 
	  print-file. 
 
    display scr-closing-screen. 
 
az0-99-exit. 
    exit. 
 
 
 
az1-totals. 
 
    move "PATIENT I-KEY READS    = "    to l1-desc. 
    move ctr-pat-mstr-reads             to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
    move "PATIENT I-KEY WRITES   = "    to l1-desc. 
    move ctr-pat-ikey-writes            to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
    move "ACRONYM KEY WRITES     = "    to l1-desc. 
    move ctr-pat-mstr-writes            to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
    move "OHIP/DIRECT KEY WRITES = "    to l1-desc. 
    move ctr-ohip-key-writes            to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
    move "CHART    KEY WRITES    = "    to l1-desc. 
    move ctr-chart-key-writes           to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
    move "HEALTH   KEY WRITES    = "    to l1-desc. 
    move ctr-health-key-writes          to l1-value. 
    write print-record                  from l1-print-line after 2. 
    move spaces				to l1-print-line. 
 
**  move "DIRECT   KEY WRITES     = "   to l1-desc. 
**  move ctr-direct-key-writes          to l1-value. 
**  write print-record                  from l1-print-line after 2. 
**  move spaces				to l1-print-line. 
 
 
az1-99-exit. 
*   exit. 
ab0-processing. 
 
    move spaces				to new-pat-mstr-rec. 
    move zero 				to pat-occur. 
 
    read pat-mstr next at end go to ab0-99-exit. 
 
**  retrieve pat-mstr key static into key-pat-mstr. 
 
*   read 'A'cronym keys only since each patient has an acronym key 
 
**  if pat-key-type not = "A" 
**	go to ab0-99-exit. 
 
    add 1				to ctr-pat-mstr-reads. 
 
    if    pat-health-nbr  = 0 
      and pat-ohip-mmyy-r = spaces 
      and pat-chart-nbr   = spaces 
    then 
	move 10				to err-ind 
	perform za0-common-error	thru za0-99-exit. 
*	go to ab0-processing. 
*   endif 
 
    perform ab1-write-new-file     	thru ab1-99-exit. 
 
    go to ab0-processing. 
 
ab0-99-exit. 
    exit. 


ab1-write-new-file. 
 
    perform ha0-write-pat-i-key-and-data 
					thru ha0-99-exit. 
 
*mf    if pat-health-nbr not = 0 
*mf       and pat-health-nbr not = " " 
*mf       and pat-health-nbr not = " " 
*mf    then 
*mf        perform ha5-write-pat-health-nbr-key        thru ha5-99-exit. 
*    endif. 
 
*mf    if pat-ohip-mmyy-r not = spaces 
*mf    then 
*mf        perform ha1-write-pat-ohip-key	thru ha1-99-exit. 
*   endif 
 
*mf    if pat-chart-nbr  not = spaces 
*mf    then 
*mf       perform ha3-write-pat-chart-key	thru ha3-99-exit. 
*   endif 
 
*mf    perform ha4-write-pat-acronym-key            thru ha4-99-exit. 
 
ab1-99-exit. 
    exit. 
 
 
ha0-write-pat-i-key-and-data. 
 
    move spaces 			to feedback-pat-mstr-new. 
    move pat-mstr-rec			to new-pat-mstr-rec. 
 
    write new-pat-mstr-rec 
*mf	key is key-new-pat-mstr 
	invalid key 
	    perform err-pat-mstr-new. 
 
    add 1				to ctr-pat-mstr-writes. 
 
ha0-99-exit. 
    exit.

 
*mf ha1-write-pat-ohip-key. 
 
*  check the ohip month 
 
*mf    if pat-prov-cd = "ON" 
*mf    and pat-ohip-nbr is numeric 
*mf    then 
*mf        if pat-mm < 1 
*mf        or pat-mm > 12 
*mf        then 
*mf            move 8		 		to err-ind 
*mf            perform za0-common-error	thru za0-99-exit. 
*       endif 
*   endif 
 
*mf    move feedback-pat-mstr-new          to feedback-pat-mstr-new-od. 
*mf    move pat-mstr-rec                   to new-od-pat-mstr-rec. 
 
*mf    write inverted new-od-pat-mstr-rec 
*mf	key is new-od-pat-ohip-mmyy 
*mf	invalid key 
*mf	    perform err-pat-mstr-od-new. 
 
*mf    if status-cobol-pat-mstr-od-new = duplicate-key-status 
*mf    then 
*mf        move 2 				to err-ind 
*mf        perform za0-common-error	thru za0-99-exit 
*mf        perform err-pat-mstr-od-new. 
 
*mf    add 1				to ctr-ohip-key-writes. 
 
*mf ha1-99-exit. 
*mf exit. 
**ha2-write-pat-direct-key. 
 
**  if pat-ohip-nbr-alpha not alphabetic 
**  then 
**      move 6 				to err-ind 
**      perform za0-common-error	thru za0-99-exit. 
 
 
**  write inverted pat-mstr-new-rec 
**	key is key-pat-mstr-new 
**	invalid key 
**	   perform err-pat-mstr-new. 
 
 
**  if status-cobol-pat-mstr-new = duplicate-key-status 
**  then 
**      move 4 				to err-ind 
**      perform za0-common-error	thru za0-99-exit 
**      perform err-pat-mstr-new. 
 
**  add 1				to ctr-direct-key-writes. 
 
**ha2-99-exit. 
**  exit. 
 
*mf ha3-write-pat-chart-key. 
 
**  if pat-chart-ltrs not alphabetic 
**  then 
**      move 7 				to err-ind 
**      perform za0-common-error	thru za0-99-exit. 
 
*mf    move feedback-pat-mstr-new          to feedback-pat-mstr-new-chrt. 
*mf    move pat-mstr-rec                   to new-chrt-pat-mstr-rec. 
 
*mf    write inverted new-chrt-pat-mstr-rec 
*mf	key is new-chrt-pat-chart-nbr 
*mf	invalid key 
*mf	    perform err-pat-mstr-chrt-new. 
 
*mf    if status-cobol-pat-mstr-chrt-new = duplicate-key-status 
*mf    then 
*mf        move 3 				to err-ind 
*mf        perform za0-common-error	thru za0-99-exit 
*mf        perform err-pat-mstr-chrt-new. 
 
*mf    add 1				to ctr-chart-key-writes. 
 
*mf ha3-99-exit. 
*mf    exit. 
 
 
 
*mf ha4-write-pat-acronym-key. 
 
*mf     move feedback-pat-mstr-new        to feedback-pat-mstr-new-acr. 
*mf    move pat-mstr-rec                 to new-acr-pat-mstr-rec. 
 
*mf    write inverted new-acr-pat-mstr-rec key is new-acr-pat-acronym 
*mf 	invalid key 
*mf		perform err-pat-mstr-acr-new. 
 
**  if status-cobol-pat-mstr-acr-new = duplicate-key-status 
**  then 
**      move 5 				to err-ind 
**      perform za0-common-error	thru za0-99-exit 
**      perform err-pat-mstr-acr-new. 
 
*mf    add 1			to	ctr-pat-ikey-writes. 
 
*mf ha4-99-exit. 
*mf    exit. 
 
*mf ha5-write-pat-health-nbr-key. 
 
*mf    move feedback-pat-mstr-new        to feedback-pat-mstr-new-hc. 
*mf    move pat-mstr-rec                 to new-hc-pat-mstr-rec. 
 
*mf    write inverted new-hc-pat-mstr-rec key is new-hc-pat-health-nbr 
*mf	invalid key 
*mf		perform err-pat-mstr-hc-new. 
 
*mf    if status-cobol-pat-mstr-hc-new = duplicate-key-status 
*mf    then 
*mf        move 9 				to err-ind 
*mf        perform za0-common-error	thru za0-99-exit 
*mf        perform err-pat-mstr-hc-new. 
 
*mf    add 1			to	ctr-health-key-writes. 
  
*mf ha5-99-exit. 
*mf    exit. 
 
za0-common-error. 
 
    move "**ERROR -- AT RECORD "	to	l1-desc. 
    move ctr-pat-mstr-reads		to	l1-value. 
    write print-record 			from    l1-print-line after 2. 
    move err-msg (err-ind)		to	print-record. 
    write print-record			after advancing 1 line. 
    move pat-mstr-rec			to	print-record. 
    write print-record			after advancing 1 line. 
    move spaces				to	print-record. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
