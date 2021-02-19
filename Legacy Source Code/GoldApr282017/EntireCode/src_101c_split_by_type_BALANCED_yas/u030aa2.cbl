identification division. 
program-id. u030aa2. 
author. dyad systems inc. 
installation. rma. 
date-written. september 1993. 
date-compiled. 
security. 
* 
*    files      : u030 -   ohip remittance advice tape 
*		: f090 -   isam constants master 
*		: u030 -   out ohip rat tape 
*		: u030aa - parameter file 
*		: f071 -   client-rma-claim-nbr 
*		: f072 -   client-mstr 
*		: f073 -   client-doc-mstr 
* 
*    program purpose : - this is the 2nd in a series of 2 programs that
*			 process the RA for doctors who submit claims
*			 to RMA via diskette. For a description of how
*			 u030aa1 and u030aa2 work - refer to the documentation
*			 in u030aa1.cbl
*
* 
*  93/jul/21  m. chan	- sms 142 
*			- clone from u030.cb 
*			- second pass of u030aa 
*			- modify this program to only read the 
*			  input tape and extract records based 
*			  on certain client/doc/claim # 
*  97/sep/08  m. chan	- pdr 663 - change the pgm to accept the 
*			  group nbr instead of clinic nbr, make 
*			  the necessary changes for checking 
*			- read constant mstr rec 1 instead of 
*			  clinic record 
*  98/sep/24  B.E.	- client-mstr and client-doc-mstr .fd and .slr 
*		 	  were hard coded within this program. Now file
*			  definitions in other programs so copylib files
*			  setup and called from this program.
*  98/dec/09  M.C.	- change RU030aa to ru030aa for report name    
*		        - specify the key when reading  client-rma-claim-nbr
*  03/aug/22  M.C.	- change to read client-rma-claim-nbr by the new key
*		          claim-nbr-rma-clinic instead of claim-nbr-rma     
*  03/dec/10  M.C.	- alpha doc nbr
*  05/Jan/04  M.C. 	- check up to 63 clinics instead of 40   

 
*
* 
environment division. 
input-output section. 
file-control. 
* 
    select ohip-rat-tape 
	  assign to "$pb_data/ohip_rat_ascii". 
* 
    select out-ohip-rat-tape 
	  assign to "out_ohip_rat_ascii". 
* 
    select u030aa-parm-file 
	  assign to "u030aa_parm_file". 
* 
copy "f071_client_rma_claim_nbr.slr".
*         
copy "f072_client_mstr.slr".
*
copy "f073_client_doc_mstr.slr".
*
copy "f090_constants_mstr.slr". 
* 
    select error-rpt 
          assign to printer "ru030aa" 
          status is status-report. 
data division. 
file section. 
* 
    copy "u030_ohip_rat_tape.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_1.ws". 
* 
fd  out-ohip-rat-tape 
    record contains 79 characters. 
 
01  out-rat-record 			pic x(79). 
 
* 
 
fd  u030aa-parm-file 
*   record contains 18 characters. 
    record contains 20 characters. 
 
01  u030aa-parm-rec. 
    05  u030aa-client-id		pic x(5). 
    05  u030aa-total-amt-paid		pic s9(7)v99. 
*   05  u030aa-clinic-nbr		pic 99. 
    05  u030aa-clinic-nbr		pic 9(4). 
    05  u030aa-month-id			pic 99. 
 
* 
copy "f071_client_rma_claim_nbr.fd".
* 
copy "f072_client_mstr.fd".
* 
copy "f073_client_doc_mstr.fd".
* 
 
fd  error-rpt 
    record contains 132 characters. 
 
01  print-err-rpt			pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  last-claim-nbr  				pic x(11). 
77  ctr-line					pic 99 value 70. 
 
 
* 
*  status file indicators 
* 
*mf 77  status-file					pic x(11). 
*mf 77  status-iconst-mstr				pic x(11) value zero. 
*mf 77  status-client-mstr				pic x(11) value zero. 
*mf 77  status-client-doc-mstr			pic x(11) value zero. 
77  status-file					pic x(2). 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-cobol-client-mstr			pic x(2) value zero. 
77  status-cobol-client-doc-mstr		pic x(2) value zero. 
77  status-report 				pic x(02) value zero. 
*mf 77  status-client-rma-claim-nbr		pic x(11) value zero. 
77  status-cobol-client-rma-nbr			pic x(2) value zero. 
77  feedback-iconst-mstr			pic x(4). 
77  feedback-client-mstr			pic x(4). 
77  feedback-client-doc-mstr			pic x(4). 
77  feedback-client-rma-claim-nbr		pic x(4). 
 
77  i						pic 99. 
 
01  group-nbr-flag				pic x. 
    88  group-nbr-found				value 'Y'. 
    88  group-nbr-not-found			value 'N'. 
 
 
01  rat-eof-flag				pic x. 
    88  rat-eof					value "Y". 
 
01  hcp-rmb-flag				pic x. 
    88  rmb-claims				value 'Y'. 
    88  hcp-claims				value 'N'. 
 
01  doc-flag					pic x. 
    88 doc-found				value 'Y'. 
    88 doc-not-found				value 'N'. 
 
01  client-flag					pic x. 
    88 correct-client				value 'Y'. 
    88 wrong-client				value 'N'. 
 
01  claim-flag					pic x. 
    88 correct-claim				value 'Y'. 
    88 wrong-claim				value 'N'. 
 
01  hold-account-nbr. 
*!    05  hold-doc-nbr				pic 9(3). 
    05  hold-doc-nbr				pic x(3). 
    05  hold-doc-claim				pic 9(5). 
 
01  ws-rat-1-tot-amt-pay			pic s9(7)v99. 
 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-rat-tape-reads			pic 9(7). 
    05  ctr-rat-rec1-reads			pic 9(7). 
    05  ctr-rat-rec2-reads			pic 9(7). 
    05  ctr-rat-rec3-reads			pic 9(7). 
    05  ctr-rat-rec4-reads			pic 9(7). 
    05  ctr-rat-rec5-reads			pic 9(7). 
    05  ctr-rat-rec6-reads			pic 9(7). 
    05  ctr-rat-rec7-reads			pic 9(7). 
    05  ctr-rat-rec8-reads			pic 9(7). 
    05  hcp-records				pic 9(7). 
    05  rmb-records				pic 9(7). 
    05  ctr-rat-write                           pic 9(7). 
    05  ctr-page				pic 9(4). 
 
 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
 
01  head-line. 
    05  filler				pic x(12) value "RU030AA". 
    05  filler				pic x(12) value "RUN DATE: ". 
* (y2k)
    05  l1-run-date			pic x(8). 
    05  filler				pic x(18) value spaces. 
    05  filler				pic x(60) value 
		"RMA CLAIMS DO NOT HAVE CLIENT CLAIM NBRS". 
    05  filler				pic x(6)  value "PAGE: ". 
    05  prt-page			pic zzz9. 
 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(70)   value  
			"NO RAT TAPE HEADER - RECORD #1 ". 
	10  filler				pic x(70)   value 
			"RAT TAPE RECORD #5 DOES NOT BELONG IN SERIES". 
	10  filler				pic x(70)    value 
			"INVALID GROUP IDENTIFIER". 
        10  filler				pic x(70)   value 
			"RAT TAPE MONTH MUST BE NUMERIC ONLY". 
        10  filler				pic x(70)   value 
			"GROUP IDENTIFICATION MUST BE NUMERIC". 
        10  filler				pic x(70)   value 
			"INVALID REPLY". 
	10  filler				pic x(70)    value 
			"INVALID CLIENT". 
        10  filler				pic x(70)   value 
			"CONSTANT MSTR RECORD 1 DOES NOT EXIST". 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(70) 
			occurs  8 times. 
 
01  err-msg-comment				pic x(70).      
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 01 col 01 value is "U030AA2". 
    05  line 01 col 20 value is "RAT TAPE APPLICATION FOR DISKETTE". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 99 from sys-yy. 
    05  line 01 col 73 pic 9(4) from sys-yy. 
    05  line 01 col 75 value is "/". 
    05  line 01 col 76 pic 99 from sys-mm. 
    05  line 01 col 78 value is "/". 
    05  line 01 col 79 pic 99 from sys-dd. 
 
01  program-in-progress. 
 
    05  line 21 col 20 value "PROGRAM U030AA2 IN PROGRESS". 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-line-24. 
 
    05  line 24 col 01 blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR -   " bell blink. 
    05  line 24 col 11 pic x(60) from err-msg-comment. 
 
 
01  ring-bell. 
    05  line 23 col 01 value " " bell. 
 
procedure division. 
 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit  
 	until rat-eof. 
 	 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
* (y2k)
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm.                 
    move sys-dd				to run-dd. 
* (y2k)
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
* (y2k)
    move run-date			to l1-run-date. 
 
    move zeros 				to counters. 
					 
    move "N" 				to rat-eof-flag. 
    move "N" 				to hcp-rmb-flag. 
    move "N" 				to group-nbr-flag. 
					 
    display scr-title. 
    display program-in-progress. 
 
    open input u030aa-parm-file. 
 
    read u030aa-parm-file 
  	at end 
	    go to zb1-close-files. 
 
    open input iconst-mstr. 
 
*   move u030aa-clinic-nbr      	to iconst-clinic-nbr-1-2. 
    move 01                     	to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
		move 8 to err-ind 
		perform za0-common-error	thru za0-99-exit 
		go to zb1-close-files. 
 
    perform aa2-verify-group-nbr 	thru aa2-99-exit 
	varying i from 1 by 1 
* 2005/01/04 - MC
*	until	group-nbr-found or i > 40. 
	until	group-nbr-found or i > 63. 
* 2005/01/04 - end
 
    if group-nbr-not-found 
    then 
	move 3				to err-ind 
    	perform za0-common-error	thru za0-99-exit 
	perform zb0-abend		thru zb0-99-exit. 
*    endif 
 
 
    open input client-mstr. 
 
    move u030aa-client-id 		to client-id of client-mstr-rec. 
    read client-mstr 
	invalid key 
	    move 7			to err-ind 
	    perform za0-common-error    thru za0-99-exit 
	    go to zb1-close-files. 
 
 
    open input	ohip-rat-tape 
		client-doc-mstr 
                client-rma-claim-nbr. 
	 
*    expunge out-ohip-rat-tape. 
 
    open output out-ohip-rat-tape. 
 
*    expunge error-rpt. 
 
    open output error-rpt. 
 
aa0-20-continue-reading. 
 
    perform xa0-read-rat-tape		thru xa0-99-exit 
	until rat-1-record-type = "1" 
	   or rat-eof. 
 
    if not rat-eof 
    then 
*       if iconst-clinic-nbr = rat-1-group-nbr 
        if u030aa-clinic-nbr = rat-1-group-nbr 
        then 
	    if rat-1-record-type = "1" 
            then 
		add 1				to ctr-rat-rec1-reads 
		perform aa1-record-1-process	thru aa1-99-exit 
	    else 
	        go to aa0-20-continue-reading 
*		endif 
	else 
            perform xa0-read-rat-tape           thru    xa0-99-exit 
	    go to aa0-20-continue-reading 
*       endif 
    else 
	move 1        			        to	err-ind 
	perform za0-common-error	        thru	za0-99-exit 
	perform zb0-abend		        thru	zb0-99-exit. 
*   endif 
 
 
    move client-desc				to rat-1-payee-name. 
 
    write out-rat-record from rat-record-1. 
    add 1 					to ctr-rat-write. 
 
    perform xa0-read-rat-tape			thru 	xa0-99-exit. 
 
 
aa0-99-exit. 
    exit. 
 
aa1-record-1-process. 
 
    if  u030aa-total-amt-paid not less than 0 
    then 
    	move u030aa-total-amt-paid to  rat-1-tot-amt-pay 
	move spaces		   to  rat-1-tot-amt-pay-sign 
    else 
	multiply u030aa-total-amt-paid  by -1 giving 
					   rat-1-tot-amt-pay 
	move '-'			to rat-1-tot-amt-pay-sign. 
*   endif 
 
aa1-99-exit. 
    exit. 
 
 
 
aa2-verify-group-nbr. 
 
    if u030aa-clinic-nbr  = const-clinic-nbr(i) 
    then 
	move 'Y'		to group-nbr-flag. 
*   endif 
 
aa2-99-exit. 
    exit. 
 
ab0-processing. 
 
    if rat-1-record-type = "1" 
    then 
*	if iconst-clinic-nbr not = rat-1-group-nbr 
	if u030aa-clinic-nbr not = rat-1-group-nbr 
	then 
	    move "Y"			to rat-eof-flag 
	    go to ab0-99-exit. 
*	endif 
*   endif 
 
    perform xa1-create-tape-files	thru xa1-99-exit. 
 
    if rat-1-record-type = "4" 
    then 
    	move rat-4-claim-nbr		to last-claim-nbr. 
*   endif 
 
    if rat-1-record-type = "5" 
    then 
	if rat-5-claim-nbr = last-claim-nbr 
	then 
	    next sentence 
	else 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    display "RAT 5 CLAIM NBR=", rat-5-claim-nbr 
 	    display "LAST CLAIM NBR =", last-claim-nbr 
	    stop "HIT NEW-LINE TO CONTINUE" 
	    move zero			to err-ind 
	    go to ab0-10-read-next-rat. 
*	endif 
*   endif 
 
    if rat-1-record-type = '7' 
    then 
	move 'Y'			to hcp-rmb-flag. 
*   endif 
 
 
ab0-10-read-next-rat. 
 
    perform xa0-read-rat-tape		thru xa0-99-exit. 
 
 
ab0-99-exit. 
    exit. 
 
az0-end-of-job. 
 
 
    display blank-screen. 
    display " ". 
    display "OHIP RATS READ          "	ctr-rat-tape-reads. 
    display "OHIP RATS REC 1 READ    "	ctr-rat-rec1-reads. 
    display "OHIP RATS REC 2 READ    "	ctr-rat-rec2-reads. 
    display "OHIP RATS REC 3 READ    "	ctr-rat-rec3-reads. 
    display "OHIP RATS REC 4 READ    "	ctr-rat-rec4-reads. 
    display "OHIP RATS REC 5 READ    "	ctr-rat-rec5-reads. 
    display "OHIP RATS REC 6 READ    "	ctr-rat-rec6-reads. 
    display "OHIP RATS REC 7 READ    "	ctr-rat-rec7-reads. 
    display "OHIP RATS REC 8 READ    "	ctr-rat-rec8-reads. 
    display "HCP HEADER REC READ     "  hcp-records. 
    display "RMB HEADER REC READ     "  rmb-records. 
    display "OUT OHIP RAT TAPE WRITE "  ctr-rat-write. 
 
    close iconst-mstr 
	  ohip-rat-tape 
	  out-ohip-rat-tape 
 	  u030aa-parm-file 
	  client-rma-claim-nbr 
	  client-mstr 
	  client-doc-mstr 
	  error-rpt. 
 
    display " ". 
    display "NORMAL END OF JOB - U030AA2". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
xa0-read-rat-tape. 
 
    read ohip-rat-tape 
	at end 
	    move "Y" to rat-eof-flag 
	    go to xa0-99-exit. 
 
    add 1 to ctr-rat-tape-reads. 
 
 
xa0-99-exit. 
    exit. 
 
xa1-create-tape-files. 
 
    if rat-1-record-type = '1' 
    then 
	add 1					to ctr-rat-rec1-reads 
    else 
    if rat-1-record-type = '2' 
    then 
	write out-rat-record from rat-record-2-3 
	add 1					to ctr-rat-rec2-reads 
						   ctr-rat-write 
    else 
    if rat-1-record-type = '3' 
    then 
	write out-rat-record from rat-record-2-3 
	add 1					to ctr-rat-rec3-reads 
						   ctr-rat-write 
    else 
    if rat-1-record-type = '4' 
    then 
	add 1					to ctr-rat-rec4-reads 
	perform xb0-process-rec-4		thru xb0-99-exit 
    else 
    if rat-1-record-type = '5' 
    then 
	add 1					to ctr-rat-rec5-reads 
	perform xb1-process-rec-5		thru xb1-99-exit 
    else 
    if rat-1-record-type = '6' 
    then 
	add 1					to ctr-rat-rec6-reads 
    else 
    if rat-1-record-type = '7' 
    then 
	add 1					to ctr-rat-rec7-reads 
    else 
    if rat-1-record-type = '8' 
    then	 
	add 1					to ctr-rat-rec8-reads. 
*   endif 
*   endif 
*   endif 
*   endif 
*   endif 
*   endif 
*   endif 
 
xa1-99-exit. 
    exit. 
 
xb0-process-rec-4. 
 

    if rat-4-prov-cd = 'ON' 
    then 
	move "N" 			to hcp-rmb-flag 
    else 
	move "Y"			to hcp-rmb-flag. 
*   endif 
 
    move rat-4-account-nbr		to hold-account-nbr. 
    move hold-doc-nbr			to doc-nbr. 
    move 'Y'				to doc-flag 
					   client-flag 
					   claim-flag. 
    read client-doc-mstr 
	invalid key 
		move 'N'		to doc-flag 
		go to xb0-99-exit. 
 
    if client-id of client-doc-rec not = u030aa-client-id 
    then 
	move 'N'			to client-flag 
	go to xb0-99-exit. 
*   endif 
 
* 2003/dec/10 - MC
    move const-clinic-nbr-1-2(i) 	to clinic-nbr.
* 2003/dec/10 - end

    move rat-4-account-nbr		to claim-nbr-rma. 
*mf    read client-rma-claim-nbr 
* 2003/08/22 - MC
*   read client-rma-claim-nbr  key is claim-nbr-rma
    read client-rma-claim-nbr  key is claim-nbr-rma-clinic
* 2003/08/22 - end
       invalid key 
	   move 'N'			to claim-flag 
	   perform zc0-print-err-rpt	thru zc0-99-exit. 
 
 
    move spaces				to out-rat-record. 
 
    if claim-flag = 'N' 
    then 
	move spaces			to rat-4-account-nbr 
    else 
    	move doc-account-nbr		to rat-4-account-nbr. 
*   endif 
 
    write out-rat-record from rat-record-4. 
    add 1				to ctr-rat-write. 
	 
    if hcp-claims 
    then 
	add 1			   	to hcp-records 
    else 
    if rmb-claims 
    then 
	add 1				to rmb-records. 
*   endif 
 
xb0-99-exit. 
    exit. 
 
 
xb1-process-rec-5. 
 
    if doc-not-found or wrong-client 
    then 
	go to xb1-99-exit 
    else 
	move spaces                 	to out-rat-record 
	write out-rat-record from rat-record-5 
	add 1                       	to ctr-rat-write. 
*   endif 
 
xb1-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	e1-error-msg. 
    display confirm. 
    display e1-error-line. 
 
za0-99-exit. 
    exit. 
 
zb0-abend. 
 
    display "U030AA2 ABENDING" 
    display " ". 
 
 
zb1-close-files. 
    close iconst-mstr 
	  ohip-rat-tape 
	  out-ohip-rat-tape 
	  u030aa-parm-file 
	  client-rma-claim-nbr 
	  client-mstr 
	  client-doc-mstr 
          error-rpt. 
 
    stop run. 
 
zb0-99-exit. 
    exit. 
 
 
zc0-print-err-rpt. 
 
    if ctr-line > 60 
    then 
    	add 1				to ctr-page 
    	move ctr-page			to prt-page 
    	write print-err-rpt from head-line after advancing page 
    	move spaces			to print-err-rpt 
    	write print-err-rpt after advancing 3 lines 
    	move 4				to ctr-line. 
*   endif 
 
    move spaces to print-err-rpt. 
 
    write print-err-rpt from rat-4-account-nbr after advancing 2 lines. 
 
    add 1 				to ctr-line. 
 
 
zc0-99-exit. 
    exit. 
 
 
 

    copy "y2k_default_sysdate_century.rtn".