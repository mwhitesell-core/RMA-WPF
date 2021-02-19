identification division. 
program-id. u992. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/04/09. 
date-compiled. 
security. 
* 
*    files      : f002  - claims master 
*		: f001  - batch control file 
*		: "u992" missing claims report.                   
 
*    program purpose : this program reports the missing batch control records in the batch control file. 
*		       when a missing batch ctrl record is encountered a report is generated. 
*		       the batch #, period end date and the cycle # is the information 
*		       information that is shown on the report. 
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
*   1999/May/20    S.B.	- Y2K conversion.
*   2003/Dec/11	   M.C. - alpha doc nbr


environment division. 
input-output section. 
file-control. 
  
    copy "f002_claims_mstr.slr". 
* 
    copy "f001_batch_control_file.slr". 
* 
 
    select print-file 
	  assign to printer print-file-name 
	  file status is status-prt-file. 
data division. 
file section. 
  
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
* 
    copy "f001_batch_control_file.fd". 
* 
fd  print-file 
    record contains 132 characters. 
01  prt-line					pic x(132). 
working-storage section. 
 
* status-file-indicators 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-batctrl-file			pic x(11) value zero. 
*mf 77  status-claims-mstr			pic x(11) value zero. 

77  common-status-file				pic xx. 
77  status-cobol-batctrl-file			pic xx    value zero. 
77  status-cobol-claims-mstr			pic xx    value zero. 
77  status-prt-file				pic xx    value zero. 
 
* counters for all input/output files. 
01  counters. 
    05  ctr-claims-mstr-reads			pic 9(7)	value zero. 
    05  ctr-lines-prt				pic 99		value zero. 
    05  ctr-page				pic 99		value zero. 
    05  ctr-batchctrl-reads			pic 9(7)	value zero. 
    05  ctr-unf-bat-writes			pic 9(7)	value zero. 
 
* variables 
77  print-file-name				pic x(4)	value "u992". 
77  err-ind					pic 9. 
77  eof-claims-mstr				pic x		value "N". 
77  max-nbr-lines				pic 99		value 50. 
77  claims-occur				pic 9(12)	value zero. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  flag-clinic					pic x. 
77  ws-claim-bat-nbr				pic 9(9)	value zero. 
77  flag-print-miss-claim			pic x		value "N". 
77  flag					pic x		value "N". 
77  ws-reply					pic x. 
77  sel-clinic-nbr				pic 99. 
77  sel-cycle-nbr-from				pic 99.            
77  sel-cycle-nbr-to				pic 99. 
77  proper-spacing				pic 9		value zero. 
 
01  ws-from-date. 
* (y2k)
*    05  ws-from-yy				pic 99. 
    05  ws-from-yy				pic 9999. 
    05  ws-from-mm				pic 99. 
    05  ws-from-dd				pic 99. 
* (y2k)
*01  ws-from-date-r redefines ws-from-date       pic 9(6). 
01  ws-from-date-r redefines ws-from-date       pic 9(8). 
 
01  ws-to-date. 
* (y2k)
*    05  ws-to-yy				pic 99. 
    05  ws-to-yy				pic 9999. 
    05  ws-to-mm				pic 99. 
    05  ws-to-dd				pic 99. 
* (y2k)
*01  ws-to-date-r redefines ws-to-date		pic 9(6). 
01  ws-to-date-r redefines ws-to-date		pic 9(8). 
 
 
*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
copy "sysdatetime.ws". 
01  head-line-1. 
 
    05  filler				pic x(11)	value "U992". 
    05  filler				pic x(5)	value spaces. 
    05  head-date. 
* (y2k)
*	10  h1-yy			pic 99. 
	10  h1-yy			pic 9999. 
	10  filler			pic x		value "/". 
	10  h1-mm			pic 99. 
	10  filler			pic x		value "/". 
	10  h1-dd			pic 99. 
*    05  filler				pic x(5)	value spaces. 
    05  filler				pic x(3)	value spaces. 
    05  filler				pic x(56)	value 
        "NO  BATCH  CONTROL  RECORDS  FOR  THE  FOLLOWING  CLAIMS". 
    05  filler				pic x(5)	value spaces. 
    05  filler				pic x(5)	value "PAGE ". 
    05  h1-page				pic 999. 
    05  filler				pic x(34) 	value spaces. 
 
01  head-line-2. 
 
    05  filler				pic x(27)	value spaces. 
    05  filler				pic x(19)	value "CC DDD WW D". 
    05  filler				pic x(23)	value "PERIOD END DATE". 
    05  filler				pic x(60)	value "CYCLE NBR". 
 
01  detail-line. 
 
    05  filler				pic x(27)	value spaces. 
    05  l1-clinic  			pic 99b. 
* 2003/dec/11 - Mc
*!    05  l1-doctor			pic 999b. 
    05  l1-doctor			pic xxx.
    05  filler				pic x  value spaces.
* 2003/dec/11 - end 
    05  l1-week				pic 99b. 
    05  l1-day				pic 9b.  
    05  l1-claim-nbr			pic 99. 
    05  filler				pic x(11)	value spaces. 
    05  l1-end-date. 
* (y2k)
*	10  l1-end-yy			pic 99. 
	10  l1-end-yy			pic 9999. 
	10  filler			pic x		value "/". 
        10  l1-end-mm			pic 99. 
	10  filler			pic x		value "/". 
	10  l1-end-dd			pic 99. 
* (y2k)
*    05  filler				pic x(16)	value spaces. 
    05  filler				pic x(14)	value spaces. 
    05  l1-cycle-nbr			pic 99. 
    05  filler				pic x(50)	value spaces. 
 
01  total-line. 
 
    05  filler				pic x(30)	value spaces. 
    05  t1-message			pic x(38). 
    05  t1-batch-tot-nbr		pic zzz9. 
    05  filler				pic x(60)	value spaces. 
 
01  error-message-table. 
 
    05  error-messages. 
        10  filler				pic x(60)    value 
                "INVALID REPLY". 
	10  filler				pic x(60)   value 
		"INVALID READ ON CLAIMS-MASTER-FILE". 
	10  filler				pic x(60)   value 
                "NO CLAIMS MASTER SUPPLIED OR NO CLAIMS FOR THIS CLINIC". 
	10  filler				pic x(60)   value 
		"MESSAGE 4 GOES HERE".            
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 4 times.     
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 06 col 20 value "ENTER CLINIC IDENTIFICATION". 
    05  scr-clinic-nbr line 06 col 48 pic 99 to sel-clinic-nbr  auto required. 
     
01  cycle-number. 
    05  line 10 col 20 value is "ENTER CYCLE NBR FROM ". 
    05  scr-cycle-nbr-from line 10 col 41 pic 99 using  sel-cycle-nbr-from  auto. 
    05  line 11 col 20 value is "ENTER CYCLE NBR TO   ". 
    05  scr-cycle-nbr-to line 11 col 41 pic 99 using  sel-cycle-nbr-to  auto required. 
 
01  enter-from-date. 
    05  line 13 col 20 value is "ENTER PERIOD DATE FROM ". 
* (y2k - auto fix)
*   05  scr-from-yy line 13 col 43 pic 99 using ws-from-yy  auto. 
    05  scr-from-yy line 13 col 43 pic 9(4) using ws-from-yy  auto. 
    05  line 13 col 47 value is "/". 
    05  scr-from-mm line 13 col 48 pic 99 using ws-from-mm  auto. 
    05  line 13 col 50 value is "/". 
    05  scr-from-dd line 13 col 51 pic 99 using ws-from-dd  auto. 
 
01  enter-to-date. 
    05  line 14 col 20 value is "ENTER PERIOD DATE TO   ". 
* (y2k - auto fix)
*   05  scr-to-yy line 14 col 43 pic 99 using ws-to-yy  auto. 
    05  scr-to-yy line 14 col 43 pic 9(4) using ws-to-yy  auto. 
    05  line 14 col 47 value is "/". 
    05  scr-to-mm line 14 col 48 pic 99 using ws-to-mm  auto. 
    05  line 14 col 50 value is "/". 
    05  scr-to-dd line 14 col 51 pic 99 using ws-to-dd  auto. 
 
01  scr-verif-clinic. 
    05  line 08 col 20 value is "ACCEPT CLINIC #". 
    05  line 08 col 36 pic x using flag-clinic  auto required. 
 
01  continue-line. 
    05  line 20 col 20 value is "CONTINUE?  (ENTER Y OR N )". 
    05  reply line 20 col 50 pic x using ws-reply auto required. 
 
01  program-in-progress. 
    05  line 22 col 20 value "PROGRAM U992 IN PROGRESS". 
 
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from common-status-file  bell blink. 
    05  line 24 col 70 pic x(2) from common-status-file  bell blink. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR - "  bell blink. 
    05  line 24 col 11 pic x(60) from err-msg-comment. 
 
01  verification-screen. 
    05  line 18 col 25  value is "ACCEPT DATE ( Y/N )". 
    05  line 18 col 45  pic x to flag   auto required. 
 
01  blank-line-24. 
    05  line 24 col 1 blank line. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 08 col 20  value is "NUMBER OF CLAIMS MASTER READS   = ". 
    05  line 08 col 60  pic 9(7) from ctr-claims-mstr-reads. 
    05  line 09 col 20  value is "NUMBER OF BATCHCTRL FILE READS  = ". 
    05  line 09 col 60  pic 9(7) from ctr-batchctrl-reads. 
    05  line 10 col 20  value is "NUMBER OF UNFOUND CLAIMS WRITES = ". 
    05  line 10 col 60  pic 9(7) from ctr-unf-bat-writes. 
    05  line 21 col 17	value "PROGRAM U992 ENDING". 
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
    05  line 23 col 20  value "REPORT IS FOUND IN". 
    05  line 23 col 39  pic x(7) from print-file-name blink. 
procedure division. 
declaratives. 
 
err-claims-mstr-file section. 
   use after standard error procedure on claims-mstr. 
err-claims-mstr. 
*mf   move status-claims-mstr	to	common-status-file. 
   move status-cobol-claims-mstr	to	common-status-file. 
   display file-status-display. 
   stop "ERROR IN ACCESSING CLAIMS MASTER". 
   stop run. 
 
err-batchctrl-file section. 
   use after standard error procedure on batch-ctrl-file. 
err-batch-ctrl-file. 
*mf   move status-batctrl-file	to	common-status-file. 
   move status-cobol-batctrl-file	to	common-status-file. 
   display file-status-display. 
   stop "ERROR IN ACCESSING BATCHCTRL FILE". 
   stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
   perform aa0-initialization		thru	aa0-99-exit. 
   perform ba0-process-record		thru	ba0-99-exit. 
   perform za0-end-of-job		thru	za0-99-exit. 
 
   stop run. 
 
aa0-initialization. 
 
*   expunge  print-file. 
 
   open input claims-mstr 
	      batch-ctrl-file. 
   open output print-file. 
 
   move spaces		to	prt-line 
				total-line. 
 
   accept sys-date		from    date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
   move sys-mm			to	run-mm 
					ws-to-mm. 
   move sys-dd			to	run-dd 
					ws-to-dd. 
   move sys-yy			to	run-yy 
					ws-to-yy. 
 
   move 1			to	ws-from-yy 
					ws-from-dd 
					ws-from-mm. 
 
aa0-10. 
*  (display screen title/option) 
   display scr-title. 
 
   accept scr-clinic-nbr. 
   display scr-verif-clinic.    
   accept scr-verif-clinic.    
 
   if flag-clinic  not = "Y" 
   then 
       go to aa0-10. 
*  (else) 
*  endif 
 
 
aa0-20. 
*   ( the cycle,to and from date screen selection have to fall within screen criteria selected by the user) 
   move 1		to	sel-cycle-nbr-from. 
   move 99		to	sel-cycle-nbr-to. 
 
   display cycle-number. 
   accept scr-cycle-nbr-from. 
   accept scr-cycle-nbr-to. 
 
 
aa0-30. 
   display enter-from-date. 
 
   accept scr-from-yy. 
   accept scr-from-mm. 
   accept scr-from-dd. 
 
 
aa0-40. 
   display enter-to-date. 
 
   accept scr-to-yy. 
   accept scr-to-mm. 
   accept scr-to-dd. 
 
   display verification-screen. 
   accept verification-screen. 
 
   if flag not = "Y" 
   then 
	go to aa0-30. 
*  (else) 
*   endif 
 
   display continue-line. 
aa0-50. 
 
   accept reply. 
 
  if ws-reply =   "Y" 
              or  "N" 
  then 
      next sentence 
  else 
      move 1			to      err-ind    
      perform zb0-common-error  thru	zb0-99-exit        
      go to aa0-50. 
* endif 
 
   if ws-reply not = "Y" 
   then 
	stop run. 
*  (else) 
*   endif 
 
*   expunge  print-file. 
   open output print-file. 
 
   display program-in-progress. 
 
   accept sys-time		from	time. 
   move sys-hrs			to	run-hrs. 
   move sys-min			to	run-min. 
   move sys-sec			to	run-sec. 
 
 
   move run-yy			to	h1-yy. 
   move run-mm			to	h1-mm. 
   move run-dd			to	h1-dd. 
 
   move 98                      to 	ctr-lines-prt. 
 
*mf   move "B"			to	key-clm-key-type. 
*mf   move zero			to	key-clm-data. 
*mf   move sel-clinic-nbr	to	key-clm-clinic-nbr-1-2. 
 
   move "B"			to	clmdtl-b-key-type. 
   move zero			to	clmdtl-b-data. 
   move sel-clinic-nbr		to	clmdtl-b-clinic-nbr-1-2. 

*mf    read claims-mstr key is key-claims-mstr approximate 
*mf	invalid key 
*mf	    move 3		to 	err-ind 
*mf	    perform zb0-common-error 
*mf				thru	zb0-99-exit 
*mf	    go to za0-end-of-job. 
 
    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key 
	    move 3		to 	err-ind 
	    perform zb0-common-error 
				thru	zb0-99-exit 
	    go to za0-end-of-job. 
    read claims-mstr next.

    add 1			to	ctr-claims-mstr-reads. 
 
    perform cb0-10-check-for-clmdr  thru  cb0-99-exit. 
 
    if eof-claims-mstr = "Y" 
    then 
        go to za0-end-of-job. 
*   (else) 
*   endif 
 
aa0-99-exit.   exit. 
ba0-process-record. 
 
*  with the claims-mstr key you read the batch-ctrl-file to check if there are any missing claims in the file. 
*  if it encounters any missing claims a report is generated. 
 
   move zeros			to	key-batctrl-file. 
   move clmhdr-batch-nbr  	to 	key-batctrl-file. 
 
   read batch-ctrl-file   key is key-batctrl-file 
	invalid key 
		perform cc0-move-to-print-line 
				thru	cc0-99-exit 
		perform cd0-write-detail-line 
				thru	cd0-99-exit. 
 
   add 1			to	ctr-batchctrl-reads. 
    
*mf   add 1			to	key-clm-batch-num. 
*mf   move zeros		to	key-clm-claim-nbr. 
*! add 1			to	clmdtl-b-batch-num. 
   add 1			to	clmdtl-b-day. 
   move zeros			to	clmdtl-b-claim-nbr. 
   perform cb0-read-claims-approx 
				thru	cb0-99-exit. 
 
   if eof-claims-mstr = "Y" 
   then 
       next sentence 
   else 
       go to ba0-process-record. 
*  endif 
 
ba0-99-exit.  exit. 
cb0-read-claims-approx. 
 
*     (read the 1st claim in the next batch found in the claims master - 
*      - continue until eof on claims master file) 
 
*mf    read claims-mstr  key is key-claims-mstr approximate 
*mf        at end    
*mf           move "Y"			to	eof-claims-mstr 
*mf           go to   cb0-99-exit. 
 
    start claims-mstr  key is greater than or equal to key-claims-mstr.
    read claims-mstr next
        at end    
           move "Y"			to	eof-claims-mstr 
           go to   cb0-99-exit. 

    if status-cobol-claims-mstr = 23 or  
       status-cobol-claims-mstr = 99 
    then  
        move 2				to 	err-ind 
        perform zb0-common-error	thru zb0-99-exit 
        go to za0-end-of-job    
    else 
        if status-cobol-claims-mstr = 10 
        then  
            move "Y"			to	eof-claims-mstr 
            go to cb0-99-exit    
        else 
            move "N" 			to 	eof-claims-mstr. 
*       endif 
*   endif 
 
    add 1				to	ctr-claims-mstr-reads. 
 
*mf    retrieve claims-mstr key fix position 
*mf    into key-claims-mstr. 
 
 
cb0-10-check-for-clmdr. 
 
*	(eof if clinic # doesn'T MATCH CLINIC SELECTED) 
    if (sel-clinic-nbr not = clmhdr-clinic-nbr-1-2) 
    then 
	move "Y"			to	eof-claims-mstr 
	go to cb0-99-exit    
    else 
*	(ignore clmhdr-rec if not claim rec or if it doesnt'T FALL WITHIN THE SELECTION CRITERIA) 
****        if    (clmhdr-batch-type not = "C") 
****           or (    clmhdr-cycle-nbr < sel-cycle-nbr-from   
        if    (    clmhdr-cycle-nbr < sel-cycle-nbr-from   
                or clmhdr-cycle-nbr  > sel-cycle-nbr-to  ) 
           or (    clmhdr-date-period-end < ws-from-date-r 
                or clmhdr-date-period-end > ws-to-date-r )  
        then  
*mf            add 1			to	key-clm-batch-num 
*mf            move zeros		to	key-clm-claim-nbr 
*!          add 1			to	clmdtl-b-batch-num 
            add 1			to	clmdtl-b-day 
            move zeros			to	clmdtl-b-claim-nbr 
            go to cb0-read-claims-approx. 
*       (else) 
*       endif 
*   endif 
 
cb0-99-exit.  exit. 
cc0-move-to-print-line. 
 
    move clmhdr-clinic-nbr-1-2		to	l1-clinic.    
    move clmhdr-doc-nbr			to	l1-doctor. 
    move clmhdr-week   			to	l1-week.    
    move clmhdr-day   			to	l1-day.     
    move clmhdr-claim-nbr		to	l1-claim-nbr. 
    move clmhdr-cycle-nbr		to	l1-cycle-nbr. 
    move clmhdr-period-end-yy		to	l1-end-yy. 
    move clmhdr-period-end-mm		to	l1-end-mm. 
    move clmhdr-period-end-dd		to	l1-end-dd. 
 
cc0-99-exit. 
    exit. 
 
 
 
cd0-write-detail-line. 
 
    add  proper-spacing			to	ctr-lines-prt.      
    if ctr-lines-prt     > max-nbr-lines 
    then 
	perform ce0-heading-routine	thru	ce0-99-exit. 
*   (else) 
*   endif 
 
    write prt-line from detail-line after proper-spacing. 
    add  1				to	ctr-unf-bat-writes. 
    move "Y"				to	flag-print-miss-claim. 
 
cd0-99-exit. 
    exit. 
ce0-heading-routine. 
     
    add 1				to	ctr-page. 
    move ctr-page			to	h1-page.   
    write prt-line from head-line-1 after advancing page. 
    move 2				to	proper-spacing. 
    write prt-line from head-line-2 after proper-spacing. 
    move 3				to	ctr-lines-prt. 
ce0-99-exit.   exit. 
 
 
cf0-total-routine. 
     
    move ctr-unf-bat-writes		to	t1-batch-tot-nbr. 
    move "TOTAL MISSING BATCH CONTROL RECORDS = " 
					to	t1-message. 
    write prt-line  from total-line after 3 lines. 
 
cf0-99-exit. 
    exit. 
zb0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment.      
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
zb0-99-exit. 
    exit. 
 
za0-end-of-job. 
 
    if flag-print-miss-claim = "Y" 
    then 
        perform cf0-total-routine	thru	cf0-99-exit. 
*   (else) 
*   endif 
 
 
    close claims-mstr 
          batch-ctrl-file 
          print-file. 
 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
    stop run. 
 
za0-99-exit.  exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
