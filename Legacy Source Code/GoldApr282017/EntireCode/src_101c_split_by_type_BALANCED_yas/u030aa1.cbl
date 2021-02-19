identification division. 
program-id. u030aa1. 
author. dyad systems inc. 
installation. rma. 
date-written. septmber  1993. 
date-compiled. 
security. 
* 
*    files      : u030 -   ohip remittance advice tape 
*		: f090 -   isam constants master 
*		: u030 -   out ohip rat tape 
*		: f071 -   client-rma-claim-nbr 
*		: f072 -   client-mstr 
*		: f073 -   client-doc-mstr 
* 
*    Program Purpose : - monthly processing of ohip Remittance 
*		         Advice (RA)  file. This program is run only for
*		         doctors who submit claims via diskette and wants
*		         their own RA to apply directly against their database. 
*		       - this program is the 1st program in a series of 2
*			 programs. Only on doctor can be processed each time
*			 this series of program runs. The first step is to ask
*			 for the 'client id' which is a 4 character code. This
*			 is verified in f072 as valid. 
*		       - As each record is read from the RA the 3 digit 
*		         'account' number(ie. claim nbr) that was submitted 
*			 is separated into the 3 digit doctor number and the 
*			 remainding batch nbr(3) and claim number(2). The 3
*			 digit doctor is looked up on f073 to find the 
*			 corresponding 5 character Client ID. 
*		      - If it matches the ID of the client being processed then:
*			   for u030aa1.cbl the matching record's $ amounts
*			   are added up and the grand total written to the
*			   u030_parm_file. 
*		   	   - This parm file is then used by u030aa2 to select 
*			     the doctors records from the RA and write them
*			     to the output RA file.
*		           - The new output RA file containing only records for
*			     the selected doctor is then sent to that doctor.
*		       - note that a similar program (u030aa3.qzs) exists
*			 for uploading OHIP payments to Web claims.
* 
*    93/jul/21	  m. chan	- sms 142 
*				- clone from u030.cb 
*				- first pass of u030aa 
*				- modify this program to only read the 
*				  input tape and extract records based 
*				  on certain client/doc/claim # 
*    97/sep/08	  m. chan	- pdr 663 - change the pgm to accept the 
*				  group nbr instead of clinic nbr, make 
*				  the necessary changes for checking 
*				- read constant mstr rec 1 instead of 
*				  clinic record 
*    98/sep/09    B. E. 	- allow user to enter clinic '0000'
*  2000/jan/07    B. E.		- fixed ws-scr-year y2k changed that was missed
*  2005/Jan/04    M.C. 		- check up to 63 clinics instead of 40   

 
*
environment division. 
input-output section. 
file-control. 
* 
    select ohip-rat-tape 
	  assign to "$pb_data/ohip_rat_ascii". 
* 
    select u030aa-parm-file 
	  assign to "u030aa_parm_file". 
* 


* 2003/dec/10 - MC - comment out the following 3 select, use copybook instead

**    select client-rma-claim-nbr 
*mf	  assign index to "f071_claim_nbr_rma" 
*mf	  assign data  to "f071_client_rma_claim_nbr.db" 
**	  assign to disk  "$pb_data/f071_client_rma_claim_nbr" 
**          organization is indexed 
**	  access mode  is dynamic 
*mf added lock mode so that files aren't open exclusively
**        lock mode is manual
**	  record key   is claim-nbr-rma 
*          infos status is status-client-rma-claim-nbr. 
**          status 	is status-cobol-client-rma-nbr. 

copy "f071_client_rma_claim_nbr.slr".
*        
**    select client-mstr 
*mf	  assign index to "F072_CLIENT_ID" 
*mf	  assign data  to "F072_CLIENT_MSTR.DB" 
**	  assign to disk  "$pb_data/f072_client_mstr"    
**          organization is indexed 
**	  access mode  is dynamic 
*mf added lock mode so that files aren't open exclusively
**        lock mode is manual
**	  record key   is client-id of client-mstr-rec 
*          infos status is status-client-mstr. 
**          status 	is status-cobol-client-mstr. 
* 
 
copy "f072_client_mstr.slr".

**   select client-doc-mstr 
*mf	  assign index to "F073_DOC_NBR" 
*mf	  assign data  to "F073_CLIENT_DOC_MSTR.DB" 
**  	  assign to disk  "$pb_data/f073_client_doc_mstr"    
**        organization is indexed 
** access mode  is dynamic 
*mf added lock mode so that files aren't open exclusively
**      lock mode is manual
**      record key   is doc-nbr 
*          infos status is status-client-doc-mstr. 
**        status 	is status-cobol-client-doc-mstr. 
* 

copy "f073_client_doc_mstr.slr".

* 2003/dec/10 - end

    copy "f090_constants_mstr.slr". 
* 
data division. 
file section. 
* 
    copy "u030_ohip_rat_tape.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_1.ws". 
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
* 2003/dec/10 - MC - comment out the following 3 fd, use copybook instead
 
**fd  client-rma-claim-nbr 
*    index block contains  8 characters 
*    data  block contains 22 characters 
**  block  contains      22 characters 
**  record contains      22 characters .
*    feedback is feedback-client-rma-claim-nbr. 
 
**01  client-rma-claim-nbr-rec. 
**  05  claim-nbr-client. 
**      10  doc-ohip-nbr		pic x(6). 
** 	10  doc-account-nbr		pic x(8). 
**  05  claim-nbr-rma			pic 9(8). 

copy "f071_client_rma_claim_nbr.fd".
 
* 
 
**fd  client-mstr 
*    index block contains  5 characters 
*    data  block contains 38 characters 
**   block  contains      38 characters 
**  record contains      38 characters .
*    feedback is feedback-client-mstr. 
 
**01  client-mstr-rec. 
**  05  client-id        		pic x(5). 
**  05  client-operator-nbr		pic 9(3). 
**  05  client-desc			pic x(30). 

copy "f072_client_mstr.fd".
 
* 
 
**fd  client-doc-mstr 
*    index block contains  3 characters 
*    data  block contains  8 characters 
**  block  contains       8 characters 
**  record contains       8 characters .
*    feedback is feedback-client-doc-mstr. 
 
**01  client-doc-rec. 
**  05  doc-nbr          		pic 9(3). 
**  05  client-id           		pic x(5). 

copy "f073_client_doc_mstr.fd".

* 2003/dec/10 - end
 
* 
 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  last-claim-nbr  				pic x(11). 
*77  ws-request-clinic-ident			pic 99. 
77  ws-request-clinic-ident			pic 9(4). 
77  ws-sel-client				pic x(5). 
77  ws-sel-month				pic 99.      
77  ws-flag-tape-mth				pic x. 
77  ws-flag-over-mth				pic x. 
77  ws-scr-day					pic 99. 
* (y2k)
*77  ws-scr-year					pic 99. 
77  ws-scr-year					pic 9(4). 
77  ws-scr-month				pic x(9).         
77  ws-doll-amt					pic 9(7)v99.  
77  ws-reply					pic x. 
77  ws-confirm-reply				pic x. 
 
 
* 
*  status file indicators 
* 
*mf 77  status-file					pic x(11). 
*mf 77  status-iconst-mstr				pic x(11) value zero. 
*mf 77  status-client-mstr				pic x(11) value zero. 
*mf 77  status-client-doc-mstr			pic x(11) value zero. 
*mf 77  status-client-rma-claim-nbr			pic x(11) value zero. 
77  status-file					pic x(2). 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-cobol-client-mstr			pic x(2) value zero. 
77  status-cobol-client-doc-mstr		pic x(2) value zero. 
77  status-cobol-client-rma-nbr			pic x(2) value zero. 
77  feedback-iconst-mstr			pic x(4). 
77  feedback-client-mstr			pic x(4). 
77  feedback-client-doc-mstr		pic x(4). 
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
 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
 
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
    05  line 01 col 01 value is "U030AA1". 
    05  line 01 col 20 value is "RAT TAPE APPLICATION FOR DISKETTE". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 99 from sys-yy. 
    05  line 01 col 73 pic 9(4) from sys-yy. 
    05  line 01 col 75 value is "/". 
    05  line 01 col 76 pic 99 from sys-mm. 
    05  line 01 col 78 value is "/". 
    05  line 01 col 79 pic 99 from sys-dd. 
    05  line 06 col 20 value is "ENTER CLINIC IDENT". 
* 98/sep/09: clinic '0000' now valid
*   05  scr-clinic-nbr line 06 col 40 pic 9(4) using ws-request-clinic-ident auto required. 
    05  scr-clinic-nbr line 06 col 40 pic 9(4) using ws-request-clinic-ident auto. 
    05  line 08 col 20 value is "ENTER CLIENT ID". 
    05  scr-client-id  line 08 col 40 pic x(5)  using ws-sel-client auto required. 
 
01  msg-continue. 
 
    05  line 10 col 10 value is "CONTINUE?  (ENTER Y OR N)". 
    05  reply line 10 col 40 pic x using ws-reply auto required. 
 
01  program-in-progress. 
 
    05  line 21 col 20 value "PROGRAM U030AA1 IN PROGRESS". 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-line-24. 
 
    05  line 24 col 01 blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR -   " bell blink. 
    05  line 24 col 11 pic x(60) from err-msg-comment. 
 
 
01  scr-month-id. 
 
    05  line 12 col 20  value is "ENTER RAT TAPE MONTH". 
    05  line 12 col 41  pic 99    using ws-sel-month   auto. 
 
 
01  scr-search-rec-type-1. 
 
    05  line 14 col 20  value is "NOW SEARCHING FOR RAT TAPE RECORD TYPE 1". 
 
01  scr-date-and-dol-amount. 
 
    05  line 16 col 20  value is "DATE OF TAPE IS". 
    05  line 16 col 36  pic 99    using ws-scr-day           auto. 
    05  line 16 col 39  pic x(9)  using ws-scr-month         auto. 
* (y2k - auto fix)
*   05  line 16 col 49  pic 99    using ws-scr-year          auto. 
    05  line 16 col 49  pic 9(4)    using ws-scr-year          auto. 
    05  line 17 col 20  value is "RAT TAPE CLINIC AMOUNT $". 
    05  line 17 col 45  pic z,zzz,zz9.99  using ws-doll-amt      auto. 
 
01  scr-accept-mth. 
 
    05                line 18  col 20  value is "ACCEPT THIS TAPE MONTH (Y/N)". 
    05  scr-tape-mth  line 18  col 51  pic x using ws-flag-tape-mth   auto. 
 
01  scr-override-mth. 
 
    05                line 19 col 20 value is "MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH". 
    05		      line 20 col 20 value is "DO YOU STILL WANT TO CONTINUE (Y OR N)".     
    05  scr-over-mth  line 20 col 60 pic x using ws-flag-over-mth   auto. 
 
01  scr-confirm-neg-response. 
 
    05  line 22 col 20 value is "* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM". 
    05		      line 23 col 20 value is "DO YOU STILL WANT TO CONTINUE (Y OR N)".     
    05  confirm-reply line 23 col 60 pic x using ws-confirm-reply  auto. 
 
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
 
    move zeros 				to counters. 
					 
    move "N" 				to rat-eof-flag. 
    move "N" 				to hcp-rmb-flag. 
    move "N" 				to group-nbr-flag. 
					 
    open input iconst-mstr. 
 
    move 01                     	to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
		move 8 to err-ind 
		perform za0-common-error	thru za0-99-exit 
		perform zb0-abend		thru zb0-99-exit. 
 
    display scr-title. 
 
aa0-10-accept-clinic. 
 
    accept scr-clinic-nbr. 
 
*   if ws-request-clinic-ident not numeric 
*   then 
*       move  5				to	err-ind 
*       perform za0-common-error	thru	za0-99-exit 
*       move spaces			to 	ws-request-clinic-ident 
*	move zero			to	err-ind 
*	go to aa0-10-accept-clinic 
*   else 
	perform aa3-verify-group-nbr 	thru aa3-99-exit 
	varying i from 1 by 1 
* 2005/01/04 - MC
*	until	group-nbr-found or i > 40. 
	until	group-nbr-found or i > 63. 
* 2005/01/04 - end
 
	if group-nbr-not-found 
	then 
	    move 3			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to aa0-10-accept-clinic. 
*	endif 
*    endif 
 
 
 
    open input client-mstr. 
 
    display scr-client-id. 
 
aa0-12-accept-client-id. 
 
    accept scr-client-id. 
 
    move ws-sel-client to client-id of client-mstr-rec. 
 
    read client-mstr 
    	invalid key 
		move 7			to err-ind 
		perform za0-common-error thru za0-99-exit 
		go to aa0-12-accept-client-id. 
 
    display scr-month-id. 
     
aa0-15-accept-month. 
 
    accept scr-month-id. 
 
    if ws-sel-month  is not numeric 
    then 
        move  4					to  err-ind 
        perform za0-common-error		thru za0-99-exit 
*        move spaces 				to  ws-sel-month 
        move zero   				to  ws-sel-month 
	move zero				to err-ind 
	go to aa0-15-accept-month. 
*   endif 
 
    display scr-search-rec-type-1. 
 
    open input	ohip-rat-tape 
		client-doc-mstr 
                client-rma-claim-nbr. 
	 
*    expunge u030aa-parm-file. 
 
    open output u030aa-parm-file. 
 
aa0-20-continue-reading. 
 
    perform xa0-read-rat-tape		thru xa0-99-exit 
	until rat-1-record-type = "1" 
	   or rat-eof. 
 
    if not rat-eof 
    then 
*       if iconst-clinic-nbr = rat-1-group-nbr 
        if ws-request-clinic-ident = rat-1-group-nbr 
        then 
	    if rat-1-record-type = "1" 
            then 
		add 1				to ctr-rat-rec1-reads 
		perform aa1-record-1-process    thru    aa1-99-exit 
	        perform aa2-certify-month	thru	aa2-99-exit 
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
 
 
    move ws-sel-client				to u030aa-client-id. 
    move ws-sel-month				to u030aa-month-id. 
    move ws-request-clinic-ident		to u030aa-clinic-nbr. 
 
    move zero					to ws-rat-1-tot-amt-pay. 
 
    perform xa0-read-rat-tape			thru 	xa0-99-exit. 
 
 
aa0-99-exit. 
    exit. 
 
aa1-record-1-process. 
  
    if rat-1-tot-amt-pay-sign = ' ' 
    then 
	move rat-1-tot-amt-pay		to ws-rat-1-tot-amt-pay 
    else 
	multiply rat-1-tot-amt-pay by -1 giving 
					   ws-rat-1-tot-amt-pay. 
*   endif 
 
aa1-99-exit. 
    exit. 
 
 
aa2-certify-month. 
 
    move rat-1-payment-date-dd		to	ws-scr-day. 
    move rat-1-payment-date-yy		to	ws-scr-year. 
    move mth-desc ( rat-1-payment-date-mm ) 
					to	ws-scr-month. 
    move ws-rat-1-tot-amt-pay  		to	ws-doll-amt. 
 
    display scr-date-and-dol-amount. 
 
    display scr-accept-mth. 
    accept  scr-tape-mth. 
 
    if ws-sel-month  not = rat-1-payment-date-mm 
    then 
        if ws-flag-tape-mth = "Y" 
	then 
                                                                  
*       if selected month and month found on tape don'T MATCH AND THE 
*       user wishes to continue with the program a warning appears on 
*       the screen telling the user so. it also gives the user the  
*       option of continuing with the program or rejecting it. 
 
	    next sentence 
	else 
	    go to  zb1-close-files                          
    else 
	if ws-flag-tape-mth = "Y" 
	then 
	    display program-in-progress 
	    go to aa2-99-exit 
	else 
	    go to  zb1-close-files.             
*	endif 
*   endif 
 
    display scr-override-mth. 
    accept  scr-override-mth. 
 
    if ws-flag-over-mth  = "Y" 
    then 
	display program-in-progress 
	go to aa2-99-exit. 
*   (else) 
*   endif 
 
aa2-10-confirm-neg-response. 
 
    display scr-confirm-neg-response. 
    accept confirm-reply. 
 
    if ws-confirm-reply =   "Y" 
			 or "N" 
    then 
	next sentence 
    else 
	move  6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa2-10-confirm-neg-response. 
*   endif 
 
    if ws-confirm-reply = "Y" 
    then 
	next sentence 
    else 
	go to zb1-close-files. 
*   endif 
 
 
aa2-99-exit. 
    exit. 
 
aa3-verify-group-nbr. 
 
    if ws-request-clinic-ident = const-clinic-nbr(i) 
    then 
	move 'Y'		to group-nbr-flag. 
*   endif 
 
aa3-99-exit. 
    exit. 
 
ab0-processing. 
 
    if rat-1-record-type = "1" 
    then 
*	if iconst-clinic-nbr not = rat-1-group-nbr 
	if ws-request-clinic-ident not = rat-1-group-nbr 
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
 
 
    move ws-rat-1-tot-amt-pay		to u030aa-total-amt-paid. 
    write u030aa-parm-rec. 
 
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
 
    close iconst-mstr 
	  ohip-rat-tape 
	  u030aa-parm-file 
	  client-rma-claim-nbr 
	  client-mstr 
	  client-doc-mstr. 
 
    display " ". 
    display "NORMAL END OF JOB - U030AA1". 
 
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
	add 1					to ctr-rat-rec2-reads 
    else 
    if rat-1-record-type = '3' 
    then 
	add 1					to ctr-rat-rec3-reads 
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
					   client-flag. 
    if doc-nbr = 204 
    then
	next sentence.
					 
    read client-doc-mstr 
	invalid key 
		move 'N'		to doc-flag 
		go to xb0-99-exit. 
 
    if client-id of client-doc-rec not = ws-sel-client 
    then 
	move 'N'			to client-flag 
	go to xb0-99-exit. 
*   endif 
 
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
	if rat-5-amt-paid-sign = ' ' 
	then 
	    add rat-5-amt-paid      	to ws-rat-1-tot-amt-pay 
	else 
	    compute ws-rat-1-tot-amt-pay = ws-rat-1-tot-amt-pay + 
			(rat-5-amt-paid * -1). 
*	endif 
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
 
    display "U030AA1 ABENDING" 
    display " ". 
 
 
zb1-close-files. 
    close iconst-mstr 
	  ohip-rat-tape 
	  u030aa-parm-file 
	  client-rma-claim-nbr 
	  client-mstr 
	  client-doc-mstr. 
 
 
    stop run. 
 
zb0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".