identification division. 
program-id. u015tp.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 84/05/14. 
date-compiled. 
security. 
* 
*   files		: f050tp - doctor revenue file 
*			: f051tp - doctor cash file 
*			: f090 - constants master 
* 
*   program purpose : to zero out the month-to-date fields in all 
*			records of the doctor revenue file pertaining 
*			to a particular clinic (i.e. to perform monthly 
*			posting). 
* 
*   revision history: 
* 
* 
*   revised may/87 (s.b.) - conversion from aos to aos/vs. 
*                           change field size for 
*                           status clause to 2 and 
*                           feedback clause to 4. 
* 
*   revised mar/89 (s.f.) - sms 115 
*		     	  - make sure file status is pic xx ,feedback 
*			    is pic x(4) and infos status is pic x(11). 
* 
*   revised jun/92 (m.c.) - sms 139 
*			  - take out the prompt for clinic nbr, should 
*			    read thru all 60 clinics 
*  1999/jan/31 B.E.	  - y2k
*  2007/apr/19 M.C.	  - consider 60 and 70 clincis separately,
*			  - user must now prompt for clinic nbr where
*			    60 entered for clinic 61 to 65  and
*			    70 entered for clinic 71 to 75
*  2010/mar/09 MC1       - include clinic 66 as clinic 60

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f050tp_doc_revenue_mstr.slr". 
* 
    copy "f051tp_doc_cash_mstr.slr". 
* 
*   copy "f090_constants_mstr.slr". 
data division. 
file section. 
* 
    copy "f050tp_doc_revenue_mstr.fd". 
* 
    copy "f051tp_doc_cash_mstr.fd". 
* 
*   copy "f090_constants_mstr.fd". 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
** list file keys    
77  feedback-docrevtp-mstr				pic x(4). 
77  feedback-docashtp-mstr				pic x(4). 
*77  feedback-iconst-mstr				pic x(4). 
 
*   status-file indicators 
 
*mf 77  common-status-file				pic x(11). 
77  common-status-file				pic x(2). 
*mf 77  status-docrevtp-mstr			pic x(11) value zero. 
*mf 77  status-docashtp-mstr			pic x(11) value zero. 
*77  status-iconst-mstr				pic x(11) value zero. 
77  status-cobol-docrevtp-mstr			pic xx	  value zero. 
77  status-cobol-docashtp-mstr			pic xx	value zero. 
77  status-cobol-iconst-mstr			pic xx	value zero. 
 
*   eof indicators 
77  eof-docashtp-mstr				pic x	value "N". 
77  eof-docrevtp-mstr				pic x	value "N". 
77  sel-clinic-nbr				pic 99. 
*77  valid-clinic-nbr				pic 99  value 60. 
 
 
01  cur-docrevtp-doc-nbr. 
    05  filler					pic x. 
    05  cur-doc-nbr. 
	10  cur-doc-dept			pic 9. 
	10  filler				pic 99. 
 
 
 
77  ws-continue					pic x	value spaces. 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-docrevtp-mstr-reads			pic 9(7). 
    05  ctr-docrevtp-mstr-writes		pic 9(7). 
    05  ctr-docashtp-mstr-reads			pic 9(7). 
    05  ctr-docashtp-mstr-writes			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
		 
	10  filler				pic x(60)   value 
		"NO DOCASHTP FILE FOR CLINIC--DOCREVTP ALREADY CLEARED". 
	10  filler				pic x(60)   value 
		"NO DOCREVTP FILE FOR CLINIC-NO RECORDS CLEARED". 
	10  filler				pic x(60)    value 
		"WRITE ERROR ON DOCTOR REVENUE FILE-DOCASHTP NOT CLEARED".       
	10  filler				pic x(60)	value 
		"NO DOCASHTP RECS.FOR CLINIC--DOCREVTP CLEARED". 
	10  filler				pic x(60)	value 
		"WRITE ERROR ON DOCASHTP FILE--DOCREVTP CLEARED". 
	10  filler				pic x(60)	value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)	value 
		"ONLY CLINIC NUMBER 60 ACCEPTED". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 8 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 01 col 01 value "U015TP". 
    05  line 01 col 15 value "MONTHLY ROLLOVER OF DOCTOR REVENUE-TP CASH-TP FILES". 
* 2007/04/11 - MC
*    05  line 10 col 20 value is "FOR CLINIC NUMBER 60 TO 65". 
    05  line 10 col 20 value is "FOR CLINIC NUMBER 60's or 70's". 
*   05  scr-clinic-nbr line 10 col 48 pic zz using sel-clinic-nbr auto required. 
*  reactivate the prompt for clinic because now it can be 60 or 70   
    05  scr-clinic-nbr line 10 col 48 pic zz using sel-clinic-nbr auto required. 
* 2007/04/11 - end
* 
*01  scr-continue-or-not. 
*   05  line 12 col 20 value "CONTINUE (Y/N)". 
*   05  scr-continue line 12 col 49 pic x using ws-continue auto required. 
 
01  program-in-progress. 
    05  line 15 col 30 value "PROGRAM IN PROGRESS". 
 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf 05  line 24 col 70	pic x(11) using common-status-file	bell blink. 
    05  line 24 col 70	pic x(2) using common-status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
 
 
01  scr-closing-screen. 
    05  blank screen.               
    05  line 13 col 20  value "NUMBER OF DOCREVTP-MSTR READS      ". 
    05  line 13 col 60  pic z(6)9 using ctr-docrevtp-mstr-reads. 
    05  line 14 col 20  value "NUMBER OF DOCREVTP-MSTR WRITES". 
    05  line 14 col 60  pic z(6)9 using ctr-docrevtp-mstr-writes. 
    05  line 15 col 20  value "NUMBER OF DOCASHTP-MSTR READS". 
    05  line 15 col 60  pic z(6)9 using ctr-docashtp-mstr-reads. 
    05  line 16 col 20  value "NUMBER OF DOCASHTP-MSTR-WRITES". 
    05  line 16 col 60  pic z(6)9 using ctr-docashtp-mstr-writes. 
    05  line 21 col 20	value "PROGRAM U015TP ENDING". 
* (y2k - auto fix)
*   05  line 21 col 42  pic 99	using sys-yy. 
    05  line 21 col 42  pic 9(4)	using sys-yy. 
    05  line 21 col 46	value "/". 
    05  line 21 col 47	pic 99	using sys-mm. 
    05  line 21 col 49	value "/". 
    05  line 21 col 50	pic 99	using sys-dd. 
    05  line 21 col 54	pic z9	using sys-hrs. 
    05  line 21 col 56	value ":". 
    05  line 21 col 57	pic 99	using sys-min. 
procedure division. 
declaratives. 
 
err-docrevtp-file section. 
    use after standard error procedure on docrevtp-mstr.       
err-docrevtp-mstr. 
*mf move status-docrevtp-mstr		to common-status-file. 
    move status-cobol-docrevtp-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCREVTP MASTER". 
 
err-docashtp-file section. 
    use after standard error procedure on docashtp-mstr.       
err-docashtp-mstr. 
*mf move status-docashtp-mstr		to common-status-file. 
    move status-cobol-docashtp-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCASHTP MASTER". 
 
*err-iconst-file section. 
*   use after standard error procedure on iconst-mstr. 
*err-iconst-mstr. 
*   move status-iconst-mstr		to common-status-file. 
*   display file-status-display. 
*   stop "ERROR IN ACCESSING CONSTANTS MASTER". 
 
 
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
 
    move 0				to	counters. 
 
 
 
*   open input iconst-mstr. 
 
*	(display screen title/option) 
    display scr-title. 
 
*aa0-10-enter-clinic-nbr. 
 
*  accept scr-clinic-nbr. 

* 2007/04/19 - MC - reactivate the prompt for clinic
   accept scr-clinic-nbr. 
* 2007/04/19 - end

*   if sel-clinic-nbr not equal valid-clinic-nbr 
*      move 8 to err-ind 
*      perform za0-common-error thru za0-99-exit 
*      display scr-continue-or-not 
*      accept scr-continue 
*      if ws-continue = "Y" 
*         go to aa0-10-enter-clinic-nbr 
*      else 
*         go to az0-100-end-job. 
 
*   move sel-clinic-nbr			to	iconst-clinic-nbr-1-2. 
 
*   read iconst-mstr 
*	invalid key 
*    	    move 7			to	err-ind 
*	    perform za0-common-error	thru	za0-99-exit 
*	    go to aa0-10-enter-clinic-nbr. 
 
*   close iconst-mstr. 
 
    display program-in-progress. 
 
    open i-o docrevtp-mstr. 
    open i-o docashtp-mstr. 
    move spaces				to	docrevtp-key. 
 
*mf    read docrevtp-mstr key is docrevtp-key approximate 
*mf    invalid key 
*mf  	move 3				to	err-ind 
*mf	perform za0-common-error	thru	za0-99-exit 
*mf	go to az0-end-of-job. 

* 2007/04/19 - MC
    move sel-clinic-nbr                 to      docrevtp-clinic-nbr.
* 2007/04/19 - end

    start docrevtp-mstr key is >= docrevtp-key
      invalid key 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    read docrevtp-mstr next                
      at end      
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-docrevtp-mstr-reads. 
 
    if status-cobol-docrevtp-mstr = 23 or 99 
    then 
      move 3				to	err-ind 
      perform za0-common-error		thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 

* 2007/apr/19 - MC
    if   (docrevtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 60
* 201/03/09 - MC1 - include clinic 66
*                and docrevtp-clinic-nbr > 65)
                and docrevtp-clinic-nbr > 66)
* 2010/03/09 - end
      or (docrevtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and docrevtp-clinic-nbr > 75)
    then
      move 3                            to      err-ind
      perform za0-common-error          thru    za0-99-exit
      go to az0-end-of-job.
*   endif
* 2007/apr/19 - end

 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close docashtp-mstr. 
    close docrevtp-mstr. 
 
az0-100-end-job. 
 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    perform ba0-update-docrevtp-rec	thru	ba0-99-exit. 
    perform bc0-write-docrevtp-rec	thru	bc0-99-exit. 
    perform bd0-read-docrevtp-rec	thru	bd0-99-exit. 
    if eof-docrevtp-mstr not = "Y" 
    then 
	go to ab0-processing. 
*   (else) 
*   endif 
 
    perform cd0-read-1st-docashtp-rec	thru	cd0-99-exit. 
 
ab0-100-docashtp-records. 
 
    perform cb0-update-docashtp-rec	thru	cb0-99-exit. 
    perform cc0-write-docashtp-rec	thru	cc0-99-exit. 
    perform ca0-read-next-docashtp-rec	thru	ca0-99-exit. 
 
    if eof-docashtp-mstr not = "Y" 
    then 
	go to ab0-100-docashtp-records. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
 
ba0-update-docrevtp-rec. 
 
    move zeros				to	docrevtp-amt-billed ( 1, 1, 1) 
						docrevtp-amt-billed ( 1, 1, 2) 
						docrevtp-amt-billed ( 1, 2, 1) 
						docrevtp-amt-billed ( 1, 2, 2) 
                                               docrevtp-amt-adjusts ( 1, 1, 1) 
                                               docrevtp-amt-adjusts ( 1, 1, 2) 
                                               docrevtp-amt-adjusts ( 1, 2, 1) 
                                               docrevtp-amt-adjusts ( 1, 2, 2) 
                                               docrevtp-nbr-svc ( 1, 1, 1) 
                                               docrevtp-nbr-svc ( 1, 1, 2) 
                                               docrevtp-nbr-svc ( 1, 2, 1) 
                                               docrevtp-nbr-svc ( 1, 2, 2) .
 
ba0-99-exit. 
    exit. 
 
bc0-write-docrevtp-rec. 
 
    rewrite docrevtp-master-rec 
      invalid key 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-docrevtp-mstr-writes. 
 
bc0-99-exit. 
    exit. 
bd0-read-docrevtp-rec. 
 
    read docrevtp-mstr next 
      at end 
	move "Y"			to	eof-docrevtp-mstr  
	go to bd0-99-exit. 
 
    add 1				to	ctr-docrevtp-mstr-reads. 


* 2007/04/19 - MC
    if     (docrevtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*                and docrevtp-clinic-nbr > 65)
                and docrevtp-clinic-nbr > 66)
* 2010/03/09 - end
        or (docrevtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and docrevtp-clinic-nbr > 75)
    then
* 2007/05/15 - MC
*        move "y"                        to      eof-docrevtp-mstr.
        move "Y"                        to      eof-docrevtp-mstr.
* 2007/05/15 - end
*   (else)
*   endif
* 2007/04/19 - end

 

bd0-99-exit. 
    exit. 
ca0-read-next-docashtp-rec. 
 
    read docashtp-mstr next 
	at end 
	    move "Y"			to	eof-docashtp-mstr 
	    go to ca0-99-exit. 
 
    add 1				to	ctr-docashtp-mstr-reads. 
 
* 2007/04/19 - MC
    if   (docashtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*                and docashtp-clinic-nbr > 65)
                and docashtp-clinic-nbr > 66)
* 2010/03/09 - end
      or (docashtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and docashtp-clinic-nbr > 75)
    then
* 2007/05/15 - MC
*        move "y"                        to      eof-docashtp-mstr.
        move "Y"                        to      eof-docashtp-mstr.
* 2007/05/15 - end
*   endif 
* 2007/04/19 - end
 
ca0-99-exit. 
    exit. 
 
 
 
cb0-update-docashtp-rec. 
 
    move zeroes				to	docashtp-amt-paid ( 1, 1, 1) 
						docashtp-amt-paid ( 1, 1, 2) 
						docashtp-amt-paid ( 1, 2, 1) 
						docashtp-amt-paid ( 1, 2, 2) .
 
cb0-99-exit. 
    exit. 
 
 
 
 
cc0-write-docashtp-rec. 
 
    rewrite docashtp-master-rec 
	invalid key 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-docashtp-mstr-writes. 
 
cc0-99-exit. 
    exit. 
 
 
 
 
cd0-read-1st-docashtp-rec. 
 
    move spaces				to	docashtp-key. 

* 2007/04/19 - MC
    move sel-clinic-nbr                 to      docashtp-clinic-nbr.
* 2007/04/19 - end
 
*mf    read docashtp-mstr key is docashtp-key approximate 
*mf	invalid key 
*mf	    move 5			to	err-ind 
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    start  docashtp-mstr key is >= docashtp-key 
	invalid key 
	    move 5			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    read docashtp-mstr  next
        at end      
	    move 5			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-docashtp-mstr-reads. 
 
    if status-cobol-docashtp-mstr =   23 
				 or 99 
    then 
	move 5				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
* 2007/04/19 - MC
    if   (docashtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*                and docashtp-clinic-nbr > 65)
                and docashtp-clinic-nbr > 66)
* 2010/03/09 - end
      or (docashtp-clinic-nbr not = sel-clinic-nbr
                and sel-clinic-nbr = 70
                and docashtp-clinic-nbr > 75)
    then
        move 2                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   endif
* 2007/04/19 - end
 
cd0-99-exit. 
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