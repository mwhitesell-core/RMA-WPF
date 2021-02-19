identification division. 
program-id. u015.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/05/13. 
date-compiled. 
security. 
* 
*   files		: f050 - doctor revenue file 
*			: f051 - doctor cash file 
*			: f090 - constants master 
* 
*   program purpose : to zero out the month-to-date fields in all 
*			records of the doctor revenue file pertaining 
*			to a particular clinic (i.e. to perform monthly 
*			posting). 
* 
*   revision history: 
* 
*	may/82 (d.m.)	- changed to access new doc rev file 
*			- initialization of new doc cash file added 
* 
*       may/87 (s.b.)   - coversion from aos to aos/vs. 
*                         change field size for 
*                         status clause to 2 and 
*                         feedback clause to 4. 
* 
*       mar/88 (j.l.)   - recompile program for the change in f050,f051 
*		          doc rev mtd field changed to s9(6)v99 
* 
*       mar/89 (s.f.)   - sms 115 
*		        - make sure file status is pic xx ,feedback is 
*			  pic x(4) and infos status is pic x(11). 
* 
*        jun/92 (m.c.)  - sms 139 
*			- change the logic to consider all clinic 60'S 
* 
*	apr/93 (m.c.)	- change the logic to consider new clinic 80 
*
*  1999/jan/31 B.E.	- y2k
*
*  2007/apr/10 M.C.	- change the logic to consider all clinic 70's
*  2010/mar/09 MC1 	- include clinic 66  

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f050_doc_revenue_mstr.slr". 
* 
    copy "f051_doc_cash_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
data division. 
file section. 
* 
    copy "f050_doc_revenue_mstr.fd". 
* 
    copy "f051_doc_cash_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 

working-storage section. 
 
77  err-ind					pic 99 	value zero. 
** list file keys    
77  feedback-docrev-mstr				pic x(4). 
77  feedback-docash-mstr				pic x(4). 
77  feedback-iconst-mstr				pic x(4). 
 
*   status-file indicators 
 
*mf 77  common-status-file				pic x(11). 
*mf 77  status-docrev-mstr				pic x(11) value zero. 
*mf 77  status-docash-mstr				pic x(11) value zero. 
*mf 77  status-iconst-mstr				pic x(11) value zero. 
77  common-status-file				pic x(2). 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-cobol-docrev-mstr			pic xx	  value zero. 
77  status-cobol-docash-mstr			pic xx	  value zero. 
 
*   eof indicators 
77  eof-docash-mstr				pic x	value "n". 
77  eof-docrev-mstr				pic x	value "n". 
77  sel-clinic-nbr				pic 99. 
 
 
01  cur-docrev-doc-nbr. 
    05  filler					pic x. 
    05  cur-doc-nbr. 
	10  cur-doc-dept			pic 9. 
	10  filler				pic 99. 
 
 
 
77  ws-continue					pic x	value spaces. 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-docrev-mstr-reads			pic 9(7). 
    05  ctr-docrev-mstr-writes			pic 9(7). 
    05  ctr-docash-mstr-reads			pic 9(7). 
    05  ctr-docash-mstr-writes			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"invalid reply". 
		 
	10  filler				pic x(60)   value 
		"no docash file for clinic--docrev already cleared". 
	10  filler				pic x(60)   value 
		"no docrev file for clinic-no records cleared". 
	10  filler				pic x(60)    value 
		"write error on doctor revenue file-docash not cleared".       
	10  filler				pic x(60)	value 
		"no docash recs.for clinic--docrev cleared". 
	10  filler				pic x(60)	value 
		"write error on docash file--docrev cleared". 
	10  filler				pic x(60)	value 
		"invalid clinic number". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 7 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  error - ". 
    05  e1-error-msg				pic x(119). 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 01 col 01 value "u015". 
    05  line 01 col 15 value "Monthly Rollover of Doctor Revenue and Cash files". 
    05  line 10 col 20 value is "For Clinic Number".           
    05  scr-clinic-nbr line 10 col 48 pic zz using sel-clinic-nbr auto required. 
*                     
01  scr-continue-or-not. 
    05  line 12 col 20 value "Continue (Y/N)". 
    05  scr-continue line 12 col 49 pic x using ws-continue auto required. 
 
01  program-in-progress. 
    05  line 15 col 30 value "program in progress". 
 
01 file-status-display. 
    05  line 24 col 56	"file status = ". 
*mf 05  line 24 col 70	pic x(11) using common-status-file	bell blink. 
    05  line 24 col 70	pic x(2) using common-status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " error -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
 
 
01  scr-closing-screen. 
    05  blank screen.               
    05  line 13 col 20  value "number of docrev-mstr reads      ". 
    05  line 13 col 60  pic z(6)9 using ctr-docrev-mstr-reads. 
    05  line 14 col 20  value "number of docrev-mstr writes". 
    05  line 14 col 60  pic z(6)9 using ctr-docrev-mstr-writes. 
    05  line 15 col 20  value "number of docash-mstr reads". 
    05  line 15 col 60  pic z(6)9 using ctr-docash-mstr-reads. 
    05  line 16 col 20  value "number of docash-mstr-writes". 
    05  line 16 col 60  pic z(6)9 using ctr-docash-mstr-writes. 
    05  line 21 col 20	value "program u015 ending". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	using sys-yy. 
    05  line 21 col 40  pic 9(4)	using sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	using sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	using sys-dd. 
    05  line 21 col 52	pic z9	using sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	using sys-min.        
procedure division. 
declaratives. 
 
err-docrev-file section. 
    use after standard error procedure on docrev-mstr.       
err-docrev-mstr. 
*mf    move status-docrev-mstr		to common-status-file. 
    move status-cobol-docrev-mstr	to common-status-file. 
    display file-status-display. 
    stop "error in accessing docrevenue master". 
 
err-docash-file section. 
    use after standard error procedure on docash-mstr.       
err-docash-mstr. 
*mf    move status-docash-mstr		to common-status-file. 
    move status-cobol-docash-mstr	to common-status-file. 
    display file-status-display. 
    stop "error in accessing docash master". 
 
err-iconst-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
*mf    move status-iconst-mstr		to common-status-file. 
    move status-cobol-iconst-mstr	to common-status-file. 
    display file-status-display. 
    stop "error in accessing constants master". 
 
 
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
 
 
 
    open input iconst-mstr. 
 
*	(display screen title/option) 
    display scr-title. 
aa0-10-enter-clinic-nbr. 
 
    accept scr-clinic-nbr. 
 
    move sel-clinic-nbr			to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 7			to	err-ind  
	    perform za0-common-error	thru	za0-99-exit 
	    go to aa0-10-enter-clinic-nbr. 
 
    close iconst-mstr. 
 
    display scr-continue-or-not. 
 
aa0-20-continue. 
 
    accept scr-continue. 
 
    if   ws-continue = "y" 
      or ws-continue = "Y" 
    then 
	display program-in-progress 
    else 
	if   ws-continue = "n" 
	  or ws-continue = "N" 
	then 
	    go to az0-100-end-job 
	else	 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to aa0-20-continue. 
*	endif 
*   endif 
 
    open i-o docrev-mstr. 
    open i-o docash-mstr. 
    move spaces				to	docrev-key. 
 
    move sel-clinic-nbr			to	docrev-clinic-1-2. 
*mf    read docrev-mstr key is docrev-key approximate 
*mf      invalid key 
*mf	move 3				to	err-ind 
*mf	perform za0-common-error	thru	za0-99-exit 
*mf	go to az0-end-of-job. 
 
    start docrev-mstr key is >= docrev-key 
      invalid key 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 

    read docrev-mstr next
      at end      
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-docrev-mstr-reads. 
 
    if status-cobol-docrev-mstr = 23 or 99 
    then 
      move 3				to	err-ind 
      perform za0-common-error		thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    if   (docrev-clinic-1-2 not = sel-clinic-nbr 
      		and sel-clinic-nbr < 60) 
      or (docrev-clinic-1-2 not = sel-clinic-nbr 
* 2007/apr/10 - MC
*		and docrev-clinic-1-2 > 65) 
 		and docrev-clinic-1-2 > 75) 
      or (docrev-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 60
* 2010/03/09- MC1 - include clinic 66
*		and docrev-clinic-1-2 > 65) 
		and docrev-clinic-1-2 > 66) 
* 2010/03/09 - end
      or (docrev-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 70
		and docrev-clinic-1-2 > 75) 
* 2007/apr/10 - end
    then 
      move 3				to	err-ind 
      perform za0-common-error		thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close docash-mstr. 
    close docrev-mstr. 
 
az0-100-end-job. 
 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
*   call program "menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    perform ba0-update-docrev-rec	thru	ba0-99-exit. 
    perform bc0-write-docrev-rec	thru	bc0-99-exit. 
    perform bd0-read-docrev-rec		thru	bd0-99-exit. 
    if eof-docrev-mstr not = "y" 
    then 
	go to ab0-processing. 
*   (else) 
*   endif 
 
    perform cd0-read-1st-docash-rec	thru	cd0-99-exit. 
 
ab0-100-docash-records. 
 
    perform cb0-update-docash-rec	thru	cb0-99-exit. 
    perform cc0-write-docash-rec	thru	cc0-99-exit. 
    perform ca0-read-next-docash-rec	thru	ca0-99-exit. 
 
    if eof-docash-mstr not = "y" 
    then 
	go to ab0-100-docash-records. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 

ba0-update-docrev-rec. 
 
    move zeros				to	docrev-mtd-in-rec 
						docrev-mtd-in-svc 
						docrev-mtd-out-rec 
						docrev-mtd-out-svc. 
 
ba0-99-exit. 
    exit. 
 
bc0-write-docrev-rec. 
 
    rewrite docrev-master-rec 
      invalid key 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    add 1				to	ctr-docrev-mstr-writes. 
 
bc0-99-exit. 
    exit. 
bd0-read-docrev-rec. 
 
    read docrev-mstr next 
      at end 
	move "y"			to	eof-docrev-mstr  
	go to bd0-99-exit. 
 
    add 1				to	ctr-docrev-mstr-reads. 
 
    if    (docrev-clinic-1-2 not = sel-clinic-nbr 
      		and sel-clinic-nbr < 60) 
       or  (docrev-clinic-1-2 not = sel-clinic-nbr 
* 2007/04/10 - MC
*		and docrev-clinic-1-2 > 65) 
 		and docrev-clinic-1-2 > 75) 
      or (docrev-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*		and docrev-clinic-1-2 > 65) 
		and docrev-clinic-1-2 > 66) 
* 2010/03/09 - end
      or (docrev-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 70
		and docrev-clinic-1-2 > 75) 
* 2007/04/10 - end
    then 
 	move "y"			to	eof-docrev-mstr. 
*   (else) 
*   endif 
 
bd0-99-exit. 
    exit. 
ca0-read-next-docash-rec. 
 
    read docash-mstr next 
	at end 
	    move "y"			to	eof-docash-mstr 
	    go to ca0-99-exit. 
 
    add 1				to	ctr-docash-mstr-reads. 
 
    if    (docash-clinic-1-2 not = sel-clinic-nbr 
      		and sel-clinic-nbr < 60) 
       or  (docash-clinic-1-2 not = sel-clinic-nbr 
* 2007/04/10 - MC
*		and docash-clinic-1-2 > 65) 
 		and docash-clinic-1-2 > 75) 
      or (docash-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*		and docash-clinic-1-2 > 65) 
		and docash-clinic-1-2 > 66) 
* 2010/03/09 - end
      or (docash-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 70
		and docash-clinic-1-2 > 75) 
* 2007/04/10 - end
    then 
	move "y"			to	eof-docash-mstr. 
*   (else) 
*   endif 
 
ca0-99-exit. 
    exit. 
 
 
 
cb0-update-docash-rec. 
 
    move zeroes				to	docash-mtd-in-rec 
						docash-mtd-in-svc.     
 
cb0-99-exit. 
    exit. 
 
 
 
 
cc0-write-docash-rec. 
 
    rewrite docash-master-rec 
	invalid key 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-docash-mstr-writes. 
 
cc0-99-exit. 
    exit. 
 
 
 
 
cd0-read-1st-docash-rec. 
 
    move spaces				to	docash-key. 
    move sel-clinic-nbr			to	docash-clinic-1-2. 
 
*mf    read docash-mstr key is docash-key approximate 
*mf	invalid key 
*mf	    move 5			to	err-ind 
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    start docash-mstr key is >= docash-key      
	invalid key 
	    move 5			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    read docash-mstr next
	at end      
	    move 5			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to	ctr-docash-mstr-reads. 
 
    if status-cobol-docash-mstr =   23 
				 or 99 
    then 
	move 5				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    if    (docash-clinic-1-2 not = sel-clinic-nbr 
      		and sel-clinic-nbr < 60) 
       or  (docash-clinic-1-2 not = sel-clinic-nbr 
* 2007/04/10 - MC
*		and docash-clinic-1-2 > 65)
 		and docash-clinic-1-2 > 75)
      or (docash-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 60
* 2010/03/09 - MC1 - include clinic 66
*		and docash-clinic-1-2 > 65) 
		and docash-clinic-1-2 > 66) 
* 2010/03/09 - end
      or (docash-clinic-1-2 not = sel-clinic-nbr 
		and sel-clinic-nbr = 70
		and docash-clinic-1-2 > 75) 
* 2007/04/10 - end
    then 
	move 2				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
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
