identification division. 
program-id. u140a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. february 1991. 
date-compiled. 
security. 
* 
*    FILES      : U140 -   AFP Governance Fixed Payment File
*               : F090 -   ISAM CONSTANTS MASTER 
*               : afp_a1f_file - Governance Fixed Payment Record
*               : afp_a2g_file - Group Conversion Detail Record
*               : afp_a2s_file - Solo Conversion Detail Record
*               : afp_a3c_file - Total Conversion Payment
*               : afp_a4t_file - Governance Total Payment Record
* 
*    PROGRAM PURPOSE : Monthly processing of MOH AFP fixed payment file
*				("governance report")
* 
* 
 
environment division. 
input-output section. 
file-control. 
* 
    select afp-fixed-payments
        assign to "afp_fixed_payments.dat".
* 
    select afp-a1f-file 
    assign to "afp_a1f_file.dat". 
*
    select afp-a2g-file 
    assign to "afp_a2g_file.dat". 
*
    select afp-a2s-file 
    assign to "afp_a2s_file.dat". 
*
    select afp-a3c-file 
    assign to "afp_a3c_file.dat". 
*
    select afp-a4t-file 
    assign to "afp_a4t_file.dat". 
* 
* 
    copy "f090_constants_mstr.slr". 
data division. 
file section. 
* 
    copy "u140_afp_fixed_payments.fd".

fd  afp-a1f-file
    record contains 134 characters.
01  afp-a1f-record					pic x(134).

fd  afp-a2g-file
    record contains 134 characters.
01  afp-a2g-record					pic x(134).

fd  afp-a2s-file
    record contains 134 characters.
01  afp-a2s-record					pic x(134).

fd  afp-a3c-file
    record contains 134 characters.
01  afp-a3c-record					pic x(134).

fd  afp-a4t-file
    record contains 134 characters.
01  afp-a4t-record					pic x(134).

*
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_1.ws". 
working-storage section. 
 
77  err-ind                                      pic 99  value zero. 
77  last-claim-nbr                               pic x(11). 
77  ws-sel-month                                 pic 99.      
77  ws-flag-tape-mth                             pic x. 
77  ws-flag-over-mth                             pic x. 
77  ws-scr-day                                   pic 99. 
* y2k
*77  ws-scr-year                                 pic 99. 
77  ws-scr-year                                  pic 9(4). 
77  ws-scr-month                        	 pic x(9).         
77  ws-doll-amt                                  pic 9(7)v99.  
*77  WS-REQUEST-CLINIC-IDENT                       PIC 99. 
77  ws-request-clinic-ident                      pic x(4). 
77  ws-reply                                     pic x. 
77  ws-confirm-reply                             pic x. 
 
77  ws-afp-67-amt-bill                           pic s9(9)v99. 
77  ws-afp-67-amt-paid                           pic s9(9)v99. 
 
 
* 
*  STATUS FILE INDICATORS 
* 
77  status-file                                 pic x(11). 
77  status-iconst-mstr                                pic x(11) value zero. 
77  status-cobol-iconst-mstr                     pic x(2) value zero. 
77  feedback-iconst-mstr                   pic x(4). 
 
77  i                                          pic 99. 
 
01  group-nbr-flag                               pic x. 
    88  group-nbr-found                           value 'Y'. 
    88  group-nbr-not-found                   value 'N'. 
 
01  afp-eof-flag                               pic x. 
    88  afp-eof                                   value "Y". 
 
* 2004/03/04 - MC
*01  ws-afp-1-group-nbr                           pic x(4).
01  ws-afp-1-group-nbr.
    05  ws-afp-clinic-nbr                        pic 99.
    05  filler                                   pic xx.

01  ws-clinic-nbr                                pic 99.

* 2004/03/04 -  end
 
01  ws-afp-1-moh-off-cd                        pic x. 
01  ws-afp-1-data-seq-nbr                      pic 9. 
* y2k
*01  ws-afp-1-payment-date                            pic 9(6). 
01  ws-afp-1-payment-date                      pic 9(8). 
01  ws-afp-1-last-name                         pic x(25). 
01  ws-afp-1-title                             pic x(3). 
01  ws-afp-1-initials                          pic xx. 
01  ws-afp-1-tot-amt-pay                       pic s9(7)v99. 
01  ws-afp-1-cheq-nbr                          pic x(8). 
 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-afp-file-reads                     pic 9(7). 
    05  ctr-afp-rec1-reads                     pic 9(7). 
    05  ctr-afp-rec2-reads                     pic 9(7). 
    05  ctr-afp-rec3-reads                     pic 9(7). 
    05  ctr-afp-rec4-reads                     pic 9(7). 
    05  ctr-afp-rec5-reads                     pic 9(7). 
    05  ctr-afp-rec6-reads                     pic 9(7). 
    05  ctr-afp-rec7-reads                     pic 9(7). 
    05  ctr-afp-rec8-reads                     pic 9(7). 
 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
     10  filler                              pic x(70)   value  
                      "Incoming AFP file is Empty!". 
      10  filler                              pic x(70)   value 
                       "Invalid Record ID found!". 
 10  filler                              pic x(70)    value 
                      "INVALID GROUP IDENTIFIER". 
        10  filler                           pic x(70)   value 
                       "RAT TAPE MONTH MUST BE NUMERIC ONLY". 
        10  filler                                pic x(70)   value 
                       "GROUP IDENTIFICATION MUST BE NUMERIC". 
        10  filler                               pic x(70)   value 
                       "INVALID REPLY". 
        10  filler                              pic x(70)   value 
                       "CONSTANT MSTR RECORD 1 DOES NOT EXIST". 
    05  error-messages-r redefines error-messages. 
      10  err-msg                             pic x(70) 
                       occurs  7 times. 
 
01  err-msg-comment                             pic x(70).      
 
01  e1-error-line. 
 
    05  e1-error-word                          pic x(13)    value 
                      "***  ERROR - ". 
    05  e1-error-msg                            pic x(119). 
 
 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 01 col 01 value is "u130". 
    05  line 01 col 20 value is "AFP Conversion Payment". 
* y2k
*   05  line 01 col 73 pic 99 from sys-yy. 
    05  line 01 col 71 pic 9(4) from sys-yy. 
    05  line 01 col 75 value is "/". 
    05  line 01 col 76 pic 99 from sys-mm. 
    05  line 01 col 78 value is "/". 
    05  line 01 col 79 pic 99 from sys-dd. 
*    05  line 06 col 20 value is "ENTER CLINIC IDENT". 
*    05  scr-clinic-nbr line 06 col 40 pic x(4) using ws-request-clinic-ident auto required. 
 
01  msg-continue. 
 
    05  line 08 col 10 value is "CONTINUE?  (ENTER Y OR N)". 
    05  reply line 08 col 40 pic x using ws-reply auto required. 
 
01  program-in-progress. 
 
    05  line 21 col 20 value "PROGRAM U030 IN PROGRESS". 
 
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
 
    05  line 10 col 20  value is "ENTER RAT TAPE MONTH". 
    05  line 10 col 41  pic 99    using ws-sel-month   auto. 
 
 
01  scr-search-rec-type-1. 
 
    05  line 12 col 20  value is "NOW SEARCHING FOR RAT TAPE RECORD TYPE 1".    
 
01  scr-date-and-dol-amount. 
 
    05  line 14 col 20  value is "DATE OF TAPE IS". 
    05  line 14 col 36  pic 99    using ws-scr-day           auto. 
    05  line 14 col 39  pic x(9)  using ws-scr-month         auto. 
* y2k
*   05  line 14 col 49  pic 99    using ws-scr-year          auto. 
    05  line 14 col 49  pic 9(4)  using ws-scr-year          auto. 
    05  line 15 col 20  value is "RAT TAPE CLINIC AMOUNT $". 
    05  line 15 col 45  pic z,zzz,zz9.99  using ws-doll-amt      auto. 
 
01  scr-accept-mth. 
 
    05                line 17  col 20  value is "ACCEPT THIS TAPE MONTH (Y/N)". 
    05  scr-tape-mth  line 17  col 51  pic x using ws-flag-tape-mth   auto. 
 
01  scr-override-mth. 
 
    05                line 19 col 20 value is "MONTH ENTERED AND MONTH FOUND ON TAPE DON'T MATCH". 
    05                    line 20 col 20 value is "DO YOU STILL WANT TO CONTINUE (Y OR N)".     
    05  scr-over-mth  line 20 col 60 pic x using ws-flag-over-mth   auto. 
 
01  scr-confirm-neg-response. 
 
    05  line 22 col 20 value is "* WARNING * YOU HAVE ENTERED 'N' ! RE-ENTER TO CONFIRM". 
    05                      line 23 col 20 value is "DO YOU STILL WANT TO CONTINUE (Y OR N)".     
    05  confirm-reply line 23 col 60 pic x using ws-confirm-reply  auto. 
 
01  ring-bell. 
    05  line 23 col 01 value " " bell. 
 
procedure division. 
 
mainline. 
 
    perform aa0-initialization        	thru aa0-99-exit. 
    perform ab0-processing             	thru ab0-99-exit  
       until afp-eof. 
   
    perform az0-end-of-job              thru az0-99-exit. 
 
    stop run. 


aa0-initialization. 
   
    accept sys-date                        from date. 
    perform y2k-default-sysdate         thru y2k-default-sysdate-exit.

    move sys-mm                               to run-mm.                 
    move sys-dd                               to run-dd. 
    move sys-yy                               to run-yy. 
 
    accept sys-time                   from time. 
    move sys-hrs                      to run-hrs. 
    move sys-min                     to run-min. 
    move sys-sec                     to run-sec. 
 
    move zeros                               to counters. 
                                     
    move "N"                            to afp-eof-flag. 
    move "N"                            to group-nbr-flag. 
                                       
    open input iconst-mstr. 
 
    move 01                          to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
    invalid key 
             move 7 to err-ind 
               perform za0-common-error        thru za0-99-exit 
                perform zb0-abend               thru zb0-99-exit. 
 
    display scr-title. 
 
aa0-10-accept-clinic. 
 
*    accept scr-clinic-nbr. 
 
*    perform aa3-verify-group-nbr    thru aa3-99-exit 
*        varying i from 1 by 1 
*   		until   group-nbr-found or i > 40. 
* 
*    if group-nbr-not-found 
*    then 
*        move 3                      to err-ind 
*        perform za0-common-error    thru za0-99-exit 
*        go to aa0-10-accept-clinic. 
**       endif 
**    endif 
 
*    display scr-month-id. 
 
aa0-15-accept-month. 
 
*    accept scr-month-id. 
 
*    if ws-sel-month  is not numeric 
*    then 
*        move  4                                  to  err-ind 
*        perform za0-common-error             thru za0-99-exit 
*        move zero				to  ws-sel-month 
*        move zero                               to err-ind 
*        go to aa0-15-accept-month. 
**   endif 
 
*    display scr-search-rec-type-1. 
 
    open input  afp-fixed-payments. 
    open output afp-a1f-file
		afp-a2g-file
		afp-a2s-file
		afp-a3c-file
		afp-a4t-file.

aa0-20-continue-reading. 
 
    perform xa0-read-afp-file              thru xa0-99-exit 
 
    if afp-eof 
    then 
	move 1                                  to      err-ind 
	perform za0-common-error                thru    za0-99-exit 
     	perform zb0-abend                       thru    zb0-99-exit. 
*   endif 
 
aa0-99-exit. 
    exit. 
 
 
ab0-processing. 

*   CASE
    if afp-record-id = "A1F"
    then
    	move afp-record				to	afp-a1f-record
 	write afp-a1f-record
    else
    if afp-record-id = "A2G"
    then
    	move afp-record				to	afp-a2g-record
 	write afp-a2g-record
    else
    if afp-record-id = "A2S"
    then
    	move afp-record				to	afp-a2s-record
 	write afp-a2s-record
    else
    if afp-record-id = "A3C"
    then
    	move afp-record				to	afp-a3c-record
 	write afp-a3c-record
    else
    if afp-record-id = "A4T"
    then
    	move afp-record				to	afp-a4t-record
 	write afp-a4t-record
    else
        move 2                      to err-ind 
        perform za0-common-error    thru za0-99-exit 
	display ctr-afp-file-reads
	stop "Error at above record number "
	stop run.
*   END CASE
 
ab0-10-read-next-afp. 
 
    perform xa0-read-afp-file             thru xa0-99-exit. 
 
ab0-99-exit. 
    exit. 


 
az0-end-of-job. 
 
 
    display blank-screen. 
    display " ". 
    display "OHIP RATS READ          "   ctr-afp-file-reads. 
    display "OHIP RATS REC 1 READ    "       ctr-afp-rec1-reads. 
    display "OHIP RATS REC 2 READ    "       ctr-afp-rec2-reads. 
    display "OHIP RATS REC 3 READ    "       ctr-afp-rec3-reads. 
    display "OHIP RATS REC 4 READ    "       ctr-afp-rec4-reads. 
    display "OHIP RATS REC 5 READ    "       ctr-afp-rec5-reads. 
    display "OHIP RATS REC 6 READ    "       ctr-afp-rec6-reads. 
    display "OHIP RATS REC 7 READ    "       ctr-afp-rec7-reads. 
    display "OHIP RATS REC 8 READ    "       ctr-afp-rec8-reads. 
 
    close 	iconst-mstr 
          	afp-fixed-payments 
    		afp-a1f-file
		afp-a2g-file
		afp-a2s-file
		afp-a3c-file
		afp-a4t-file.

    display " ". 
    display "NORMAL END OF JOB - u140 ". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
xa0-read-afp-file. 
 
    read afp-fixed-payments 
       at end 
      		move "Y" to afp-eof-flag 
        	go to xa0-99-exit. 
 
    add 1 to ctr-afp-file-reads. 
 
xa0-99-exit. 
    exit. 


 
za0-common-error. 
 
    move err-msg (err-ind)           to      e1-error-msg. 
    display confirm. 
    display e1-error-line. 
 
za0-99-exit. 
    exit. 
 
zb0-abend. 
 
    display "u140 ABENDING" 
    display " ". 
 
 
zb1-close-files. 
    close 	iconst-mstr 
          	afp-fixed-payments 
    		afp-a1f-file
		afp-a2g-file
		afp-a2s-file
		afp-a3c-file
		afp-a4t-file.
    stop run. 
 
zb0-99-exit. 
    exit. 

    copy "y2k_default_century_year.rtn".

    copy "y2k_default_sysdate_century.rtn". 
