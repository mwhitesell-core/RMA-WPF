identification division. 
program-id. u030a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. february 1991. 
date-compiled. 
security. 
* 
*    FILES      : U030 -   OHIP REMITTANCE ADVICE TAPE 
*               : F090 -   ISAM CONSTANTS MASTER 
*               : U030 -   TAPE-145-FILE 
*               : U030 -   TAPE-67-FILE 
*                : U030 -   TAPE-8-FILE 
*         : U030 -   TAPE-RMB-FILE 
* 
*    PROGRAM PURPOSE : MONTHLY PROCESSING OF OHIP RAT TAPE 
* 
* 
*    FEB 18/91       M. CHAN       - SMS 138 
*                              - CLONE FROM U030.CB 
*                           - MODIFY THIS PROGRAM TO ONLY READ THE 
*                           INPUT TAPE AND EXTRACT PROPER RECORD 
*                           LAYOUT BASED ON RECORD TYPE INTO THE 
*                           CORRESPONDING FILES 
*                          - THE MAIN FUNCTION OF THE PROGRAM WILL 
*                                  BE CONVERTED INTO POWERHOUSE PROGRAMS 
* 
*    AUG/20/91    M. CHAN       - PDR 514 
*                              - CORRECT THE RECORD COUNTS 
* 
*    AUG/13/92    M. CHAN       - CHANGE THE GROUP NBR FOR CLINIC 61 TO 
*                              65 IN AA1-RECORD-1-PROCESS SUBROUTINE. 
* 
* 
*    AUG/17/92    M. CHAN     - DETERMINE THE CLAIM IS 'HCP' OR 'RMB' 
*                                  FROM EACH OF RECORD 4 
* 
*    MAR/14/97    YAS           - ADD NEW CLINIC AA21 CLINIC 82 
* 
*    AUG/06/97    YAS           - ADD NEW CLINIC AA25 CLINIC 83 
* 
*    SEP/08/97    M. CHAN       - PDR 663 - CHANGE THE PGM TO ACCEPT THE 
*                                 GROUP NBR INSTEAD OF CLINIC NBR, MAKE 
*                                  THE NECESSARY CHANGES FOR CHECKING 
*                           - READ CONSTANT MSTR REC 1 INSTEAD OF 
*                            CLINIC RECORD 
* 
*    MAR/25/98    YAS           - ADD NEW CLINIC AA32 CLINIC 80 
* 1999/dec/08 B.E.	- recompiled to removed the y2k kludge
*			  that read 8 digit date but used only
*			  6 digits - now entire system y2k ready.
*			- blanked out health nbr no longer defined.
* 
*    AUG/12/02    YAS           - ADD NEW CLINIC AA2K CLINIC 95
*    jun/02/03    yas   - add new clinics AA5V AA5W AA5X AA5Y 6317
*    feb/02/04    yas   - add new clinics 6072 and H055
*    mar/04/04    M.C. - instead of hard coding each individual clinic nbr, get the
*                        clinic from record 1 of constants master
*
* 2005/Jan/04     M.C. - check up to 63 clinics instead of 40   
*			 included in $cmd/rat_copy
* 2006/feb/28     b.e. - change input accept to working storage variables 
*			 instead of screen section variables so that program
*			 can run in batch mode.
 
environment division. 
input-output section. 
file-control. 
* 
    select ohip-rat-tape 
        assign to "$pb_data/ohip_rat_ascii". 
* 
    select tape-145-file 
    assign to "u030_tape_145_file.dat". 
* 
    select tape-rmb-file 
    assign to "u030_tape_rmb_file.dat". 
* 
    select tape-67-file 
     assign to "u030_tape_67_file.dat". 
* 
    select tape-8-file 
       assign to "u030_tape_8_file.dat". 
* 
    copy "f090_constants_mstr.slr". 
data division. 
file section. 
* 
    copy "u030_ohip_rat_tape.fd". 
* 
    copy "u030_tape_145_file.fd". 
* 
    copy "u030_tape_rmb_file.fd". 
* 
    copy "u030_tape_67_file.fd". 
* 
    copy "u030_tape_8_file.fd". 
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
 
77  ws-rat-67-amt-bill                           pic s9(9)v99. 
77  ws-rat-67-amt-paid                           pic s9(9)v99. 
 
 
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
 
01  rat-eof-flag                               pic x. 
    88  rat-eof                                   value "Y". 
 
01  hcp-rmb-flag                               pic x. 
    88  rmb-claims                                value 'Y'. 
    88  hcp-claims                            value 'N'. 

* 2004/03/04 - MC
*01  ws-rat-1-group-nbr                           pic x(4).
01  ws-rat-1-group-nbr.
    05  ws-rat-clinic-nbr                        pic 99.
    05  filler                                   pic xx.

01  ws-clinic-nbr                                pic 99.

* 2004/03/04 -  end
 
01  ws-rat-1-moh-off-cd                        pic x. 
01  ws-rat-1-data-seq-nbr                      pic 9. 
* y2k
*01  ws-rat-1-payment-date                            pic 9(6). 
01  ws-rat-1-payment-date                      pic 9(8). 
01  ws-rat-1-last-name                         pic x(25). 
01  ws-rat-1-title                             pic x(3). 
01  ws-rat-1-initials                          pic xx. 
01  ws-rat-1-tot-amt-pay                       pic s9(7)v99. 
01  ws-rat-1-cheq-nbr                          pic x(8). 
 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-rat-tape-reads                        pic 9(7). 
    05  ctr-rat-rec1-reads                     pic 9(7). 
    05  ctr-rat-rec2-reads                     pic 9(7). 
    05  ctr-rat-rec3-reads                     pic 9(7). 
    05  ctr-rat-rec4-reads                     pic 9(7). 
    05  ctr-rat-rec5-reads                     pic 9(7). 
    05  ctr-rat-rec6-reads                     pic 9(7). 
    05  ctr-rat-rec7-reads                     pic 9(7). 
    05  ctr-rat-rec8-reads                     pic 9(7). 
    05  hcp-records                            pic 9(7). 
    05  rmb-records                            pic 9(7). 
 
 
 
 
 
    copy "sysdatetime.ws". 
 
    copy "mth_desc_max_days.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
     10  filler                              pic x(70)   value  
                      "NO RAT TAPE HEADER - RECORD #1 ". 
      10  filler                              pic x(70)   value 
                       "RAT TAPE RECORD #5 DOES NOT BELONG IN SERIES". 
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
    05  line 01 col 01 value is "U030A". 
    05  line 01 col 20 value is "RAT TAPE APPLICATION". 
* y2k
*   05  line 01 col 73 pic 99 from sys-yy. 
    05  line 01 col 71 pic 9(4) from sys-yy. 
    05  line 01 col 75 value is "/". 
    05  line 01 col 76 pic 99 from sys-mm. 
    05  line 01 col 78 value is "/". 
    05  line 01 col 79 pic 99 from sys-dd. 
    05  line 06 col 20 value is "ENTER CLINIC IDENT". 
    05  scr-clinic-nbr line 06 col 40 pic x(4) using ws-request-clinic-ident auto required. 
 
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
* 2006/02/28 - MC
*   05  line 10 col 41  pic 99    using ws-sel-month   auto. 
    05  line 10 col 41  pic xx    using ws-sel-month   auto. 
* 2006/02/28 - end
 
 
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
 
    perform aa0-initialization              thru aa0-99-exit. 
    perform ab0-processing             thru ab0-99-exit  
       until rat-eof. 
   
    perform az0-end-of-job              thru az0-99-exit. 
* 
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
                                     
    move "N"                            to rat-eof-flag. 
    move "N"                            to hcp-rmb-flag. 
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

*    (2006/feb/28 b.e.)
*    accept scr-clinic-nbr. 
    accept ws-request-clinic-ident.
    display scr-clinic-nbr. 
 
*   IF WS-REQUEST-CLINIC-IDENT NOT NUMERIC 
*   THEN 
*       MOVE  5                         TO      ERR-IND 
*       PERFORM ZA0-COMMON-ERROR THRU    ZA0-99-EXIT 
*       MOVE SPACES                  TO      WS-REQUEST-CLINIC-IDENT 
*        MOVE ZERO                       TO      ERR-IND 
*        GO TO AA0-10-ACCEPT-CLINIC 
*   ELSE 
      perform aa3-verify-group-nbr    thru aa3-99-exit 
        varying i from 1 by 1 
* 2005/01/04 - MC
*   until   group-nbr-found or i > 40. 
   until   group-nbr-found or i > 63. 
* 2005/01/04 - end
 
      if group-nbr-not-found 
  then 
        move 3                      to err-ind 
          perform za0-common-error    thru za0-99-exit 
            go to aa0-10-accept-clinic. 
*        ENDIF 
*    ENDIF 
 
 
    display scr-month-id. 
 
aa0-15-accept-month. 

*   (2006/feb/28 b.e.)
*    accept scr-month-id. 
    accept ws-sel-month.
    display scr-month-id. 
 
   if ws-sel-month  is not numeric 
    then 
        move  4                                  to  err-ind 
        perform za0-common-error             thru za0-99-exit 
*mf     move spaces                             to  ws-sel-month 
          move zero				to  ws-sel-month 
        move zero                               to err-ind 
      go to aa0-15-accept-month. 
*   ENDIF 
 
    display scr-search-rec-type-1. 
 
    open input     ohip-rat-tape. 
 
*    expunge tape-rmb-file 
*mf     tape-8-file 
*mf     tape-145-file 
*mf     tape-67-file. 
 
    open output tape-rmb-file 
          tape-8-file 
             tape-145-file 
           tape-67-file. 
 
aa0-20-continue-reading. 
 
    perform xa0-read-rat-tape              thru xa0-99-exit 
        until rat-1-record-type = "1" 
      or rat-eof. 
 
    if not rat-eof 
    then 
*        IF ICONST-CLINIC-NBR = RAT-1-GROUP-NBR 
        if ws-request-clinic-ident = rat-1-group-nbr 
        then 
     if rat-1-record-type = "1" 
            then 
          add 1                           to ctr-rat-rec1-reads 
                perform aa1-record-1-process       thru    aa1-99-exit 
             perform aa2-certify-month       thru    aa2-99-exit 
         else 
                go to aa0-20-continue-reading 
*          ENDIF 
   else 
            perform xa0-read-rat-tape           thru    xa0-99-exit 
     go to aa0-20-continue-reading 
*       ENDIF 
    else 
  move 1                                  to      err-ind 
 perform za0-common-error                thru    za0-99-exit 
     perform zb0-abend                       thru    zb0-99-exit. 
*   ENDIF 
 
 
    perform xa0-read-rat-tape                      thru    xa0-99-exit. 
 
 
aa0-99-exit. 
    exit. 
 
aa1-record-1-process. 
 
* 2004/03/04 - MC - comment out the following translation
*                 - move const-clinic-nbr-1-2 to ws-rat-1-group-nbr instead

*   move rat-1-group-nbr         to ws-rat-1-group-nbr. 
 
*   if rat-1-group-nbr = 'AA32' 
*   then 
*   move '8000'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = 'AA03' 
*   then 
*   move '8100'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = 'AA21' 
*   then 
*   move '8200'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = 'AA25' 
*   then 
*   move '8300'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = 'AA2K' 
*   then 
*   move '9500'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = '9595' 
*   then 
*   move '6195'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = '9598' 
*   then 
*   move '6298'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = '9607' 
*   then 
*   move '6307'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = '9619' 
*   then 
*   move '6419'                     to ws-rat-1-group-nbr 
*   else 
*   if rat-1-group-nbr = '9632' 
*   then 
*   move '6532'                     to ws-rat-1-group-nbr 
*   else
*   if rat-1-group-nbr = 'AA5V'
*   then
*   move '9100'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = 'AA5W'
*   then
*   move '9200'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = 'AA5X'
*   then
*   move '9300'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = 'AA5Y'
*   then
*   move '9400'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = '6317'
*   then
*   move '9600'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = '6072'
*   then
*   move '8400'                     to ws-rat-1-group-nbr
*   else
*   if rat-1-group-nbr = 'H055'
*   then
*   move '4300'                     to ws-rat-1-group-nbr.
*   ENDIF 

    move '0000'                          to ws-rat-1-group-nbr.
    move ws-clinic-nbr                   to ws-rat-clinic-nbr.

* 2004/03/04 - end
 
    move rat-1-moh-off-cd                to ws-rat-1-moh-off-cd. 
    move rat-1-data-seq-nbr              to ws-rat-1-data-seq-nbr. 
    move rat-1-payment-date            to ws-rat-1-payment-date. 
    move rat-1-last-name                       to ws-rat-1-last-name. 
    move rat-1-title              to ws-rat-1-title. 
    move rat-1-initials                 to ws-rat-1-initials. 
    move rat-1-cheq-nbr                  to ws-rat-1-cheq-nbr. 
    if   rat-1-tot-amt-pay-sign = ' ' 
    then 
      add  rat-1-tot-amt-pay  to ws-rat-1-tot-amt-pay 
    else 
 compute ws-rat-1-tot-amt-pay = ws-rat-1-tot-amt-pay 
             + (rat-1-tot-amt-pay * -1). 
*   ENDIF 
 
aa1-99-exit. 
    exit. 
 
 
aa2-certify-month. 
 
    move rat-1-payment-date-dd               to      ws-scr-day. 
    move rat-1-payment-date-yy               to      ws-scr-year. 
    move mth-desc ( rat-1-payment-date-mm ) 
                                 to      ws-scr-month. 
    move ws-rat-1-tot-amt-pay              to      ws-doll-amt. 
 
    display scr-date-and-dol-amount. 
 
    display scr-accept-mth. 

*   (2006/feb/28 b.e.)
*    accept  scr-tape-mth. 
    accept  ws-flag-tape-mth.
    display  scr-tape-mth. 
 
    if ws-sel-month  not = rat-1-payment-date-mm 
    then 
        if ws-flag-tape-mth = "Y" 
   then 
                                                                  
*       IF SELECTED MONTH AND MONTH FOUND ON TAPE DON'T MATCH AND THE 
*       USER WISHES TO CONTINUE WITH THE PROGRAM A WARNING APPEARS ON 
*       THE SCREEN TELLING THE USER SO. IT ALSO GIVES THE USER THE  
*       OPTION OF CONTINUING WITH THE PROGRAM OR REJECTING IT. 
 
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
*        ENDIF 
*   ENDIF 
 
    display scr-override-mth. 

*   (2006/feb/28 b.e.)
*    accept  scr-override-mth. 
    accept ws-flag-over-mth.
    display  scr-override-mth. 
 
    if ws-flag-over-mth  = "Y" 
    then 
  display program-in-progress 
     go to aa2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
aa2-10-confirm-neg-response. 
 
    display scr-confirm-neg-response. 

*   (2006/feb/28 b.e.)
*    accept confirm-reply. 
    accept ws-confirm-reply.
    display confirm-reply. 
 
    if ws-confirm-reply =   "Y" 
                   or "N" 
    then 
 next sentence 
    else 
   move  6                         to      err-ind 
 perform za0-common-error        thru    za0-99-exit 
     go to aa2-10-confirm-neg-response. 
*   ENDIF 
 
    if ws-confirm-reply = "Y" 
    then 
        next sentence 
    else 
   go to zb1-close-files. 
*   ENDIF 
 
 
aa2-99-exit. 
    exit. 
 
 
aa3-verify-group-nbr. 
 
    if ws-request-clinic-ident = const-clinic-nbr(i) 
    then 
* 2004/03/04 - MC - save clinic-nbr
        move const-clinic-nbr-1-2(i)    to ws-clinic-nbr
* 2004/03/04 - end
   	move 'Y'                to group-nbr-flag. 
*   ENDIF 
 
aa3-99-exit. 
    exit. 
 
ab0-processing. 
 
    if rat-1-record-type = "1" 
    then 
* IF ICONST-CLINIC-NBR NOT = RAT-1-GROUP-NBR 
      if ws-request-clinic-ident not = rat-1-group-nbr 
        then 
        move "Y"                    to rat-eof-flag 
     go to ab0-99-exit. 
* ENDIF 
*   ENDIF 
 
    perform xa1-create-tape-files thru xa1-99-exit. 
 
    if rat-1-record-type = "4" 
    then 
         move rat-4-claim-nbr            to last-claim-nbr. 
*   ENDIF 
 
    if rat-1-record-type = "5" 
    then 
       if rat-5-claim-nbr = last-claim-nbr 
     then 
        next sentence 
       else 
        move 2                      to err-ind 
          perform za0-common-error    thru za0-99-exit 
            display "RAT 5 CLAIM NBR=", rat-5-claim-nbr 
             display "LAST CLAIM NBR =", last-claim-nbr 
      stop "HIT NEW-LINE TO CONTINUE" 
         move zero                   to err-ind 
          go to ab0-10-read-next-rat. 
*        ENDIF 
*   ENDIF 
 
    if rat-1-record-type = '7' 
    then 
    move 'Y'                        to hcp-rmb-flag. 
*   ENDIF 
 
 
ab0-10-read-next-rat. 
 
    perform xa0-read-rat-tape             thru xa0-99-exit. 
 
 
ab0-99-exit. 
    exit. 
 
az0-end-of-job. 
 
 
    display blank-screen. 
    display " ". 
    display "OHIP RATS READ          "   ctr-rat-tape-reads. 
    display "OHIP RATS REC 1 READ    "       ctr-rat-rec1-reads. 
    display "OHIP RATS REC 2 READ    "       ctr-rat-rec2-reads. 
    display "OHIP RATS REC 3 READ    "       ctr-rat-rec3-reads. 
    display "OHIP RATS REC 4 READ    "       ctr-rat-rec4-reads. 
    display "OHIP RATS REC 5 READ    "       ctr-rat-rec5-reads. 
    display "OHIP RATS REC 6 READ    "       ctr-rat-rec6-reads. 
    display "OHIP RATS REC 7 READ    "       ctr-rat-rec7-reads. 
    display "OHIP RATS REC 8 READ    "       ctr-rat-rec8-reads. 
    display "HCP HEADER REC READ     "  hcp-records. 
    display "RMB HEADER REC READ     "  rmb-records. 
 
    close iconst-mstr 
          ohip-rat-tape 
   tape-145-file 
   tape-rmb-file 
   tape-67-file 
    tape-8-file. 
 
 
    display " ". 
    display "NORMAL END OF JOB - U030 ". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
xa0-read-rat-tape. 
 
    read ohip-rat-tape 
       at end 
      move "Y" to rat-eof-flag 
        go to xa0-99-exit. 
 
    add 1 to ctr-rat-tape-reads. 
 
*  97/09/08 - THE FOLLOWING GROUP NBR TRANSLATION IS NOT NEEDED 
 
*   IF RAT-1-GROUP-NBR = 'AA03' 
*   THEN 
*       MOVE '8100' TO RAT-1-GROUP-NBR 
*   ELSE 
*   IF RAT-1-GROUP-NBR = 'AA21' 
*   THEN 
*       MOVE '8200' TO RAT-1-GROUP-NBR 
*   ELSE 
*   IF RAT-1-GROUP-NBR = 'AA25' 
*   THEN 
*       MOVE '8300' TO RAT-1-GROUP-NBR. 
*   ENDIF 
xa0-99-exit. 
    exit. 
 
xa1-create-tape-files. 
 
    if rat-1-record-type = '1' 
    then 
 add 1                           to ctr-rat-rec1-reads 
   perform aa1-record-1-process. 
*   ENDIF 
 
           
    if rat-1-record-type = '2' 
    then 
  add 1                           to ctr-rat-rec2-reads 
    else 
   if rat-1-record-type = '3' 
      then 
        add 1                       to ctr-rat-rec3-reads. 
* ENDIF 
*   ENDIF 
 
    if rat-1-record-type = '4' 
    then 
    add 1                                   to ctr-rat-rec4-reads 
   perform xb0-process-rec-4               thru xb0-99-exit 
    else 
        if rat-1-record-type = '5' 
      then 
        add 1                               to ctr-rat-rec5-reads 
       perform xb1-process-rec-5           thru xb1-99-exit 
        else 
                if rat-1-record-type = '6' 
              then 
                add 1                           to ctr-rat-rec6-reads 
           perform xb2-process-rec-6       thru xb2-99-exit 
            else 
                if rat-1-record-type = '7' 
              then 
                add 1                       to ctr-rat-rec7-reads 
               perform xb3-process-rec-7   thru xb3-99-exit 
                else 
                if rat-1-record-type = '8' 
              then         
                        add 1                   to ctr-rat-rec8-reads 
                   perform xb4-process-rec-8  thru xb4-99-exit. 
*               ENDIF 
*              ENDIF 
*      ENDIF 
*      ENDIF 
*   ENDIF 
 
xa1-99-exit. 
    exit. 
 
xb0-process-rec-4. 
 
    if rat-4-prov-cd = 'ON' 
    then 
       move "N"                        to hcp-rmb-flag 
    else 
 move "Y"                        to hcp-rmb-flag. 
*   ENDIF 
 
    if hcp-claims 
    then 
      add 1                           to hcp-records 
        move spaces                       to tape-145-record 
        move ws-rat-1-group-nbr       to rat-145-group-nbr 
        move ws-rat-1-moh-off-cd    to rat-145-moh-off-cd 
        move ws-rat-1-data-seq-nbr      to rat-145-data-seq-nbr 
        move ws-rat-1-payment-date  to rat-145-payment-date 
        move ws-rat-1-last-name          to rat-145-pay-last-name 
        move ws-rat-1-title             to rat-145-pay-title 
        move ws-rat-1-initials              to rat-145-pay-initials 
        move ws-rat-1-tot-amt-pay        to rat-145-tot-amt-pay 
        move ws-rat-1-cheq-nbr            to rat-145-cheq-nbr 
        move rat-4-claim-nbr         to rat-145-claim-nbr 
        move rat-4-trans-type               to rat-145-trans-type 
        move rat-4-doc-nbr                 to rat-145-doc-nbr 
        move rat-4-specialty-cd               to rat-145-specialty-cd 
        move rat-4-account-nbr           to rat-145-account-nbr 
        move rat-4-last-name              to rat-145-last-name 
        move rat-4-first-name               to rat-145-first-name 
        move rat-4-prov-cd                 to rat-145-prov-cd 
        move rat-4-health-ohip-nbr      to rat-145-health-ohip-nbr 
        move rat-4-version-cd           to rat-145-version-cd 
        move rat-4-pay-prog             to rat-145-pay-prog 
* 99/dec/08 B.E.
*       move rat-4-conv-health-nbr      to rat-145-conv-health-nbr 
        move spaces                     to rat-145-conv-health-nbr 
    else 
    if rmb-claims 
    then 
     add 1                           to rmb-records 
        move spaces                       to tape-rmb-record 
        move ws-rat-1-group-nbr       to rat-rmb-group-nbr 
        move ws-rat-1-moh-off-cd    to rat-rmb-moh-off-cd 
        move ws-rat-1-data-seq-nbr      to rat-rmb-data-seq-nbr 
        move ws-rat-1-payment-date  to rat-rmb-payment-date 
        move ws-rat-1-last-name          to rat-rmb-pay-last-name 
        move ws-rat-1-title             to rat-rmb-pay-title 
        move ws-rat-1-initials              to rat-rmb-pay-initials 
        move ws-rat-1-tot-amt-pay        to rat-rmb-tot-amt-pay 
        move ws-rat-1-cheq-nbr            to rat-rmb-cheq-nbr 
        move rat-4-claim-nbr         to rat-rmb-claim-nbr 
        move rat-4-trans-type               to rat-rmb-trans-type 
        move rat-4-doc-nbr                 to rat-rmb-doc-nbr 
        move rat-4-specialty-cd               to rat-rmb-specialty-cd 
        move rat-4-account-nbr           to rat-rmb-account-nbr 
        move rat-4-last-name              to rat-rmb-last-name 
        move rat-4-first-name               to rat-rmb-first-name 
        move rat-4-prov-cd                 to rat-rmb-prov-cd 
        move rat-4-health-ohip-nbr      to rat-rmb-health-ohip-nbr 
        move rat-4-version-cd           to rat-rmb-version-cd 
        move rat-4-pay-prog             to rat-rmb-pay-prog 
*  99/dec/08 B.E.
*       move rat-4-conv-health-nbr      to rat-rmb-conv-health-nbr. 
        move spaces                     to rat-rmb-conv-health-nbr. 
*   ENDIF 
 
xb0-99-exit. 
    exit. 
 
 
xb1-process-rec-5. 
 
    if hcp-claims 
    then 
    move rat-5-service-date         to rat-145-service-date 
 move rat-5-nbr-of-serv          to rat-145-nbr-of-serv 
  move rat-5-service-cd           to rat-145-service-cd 
   move rat-5-eligibility-ind      to rat-145-eligibility-ind 
      move rat-5-amount-sub           to rat-145-amount-sub 
   if   rat-5-amt-paid-sign = ' ' 
  then 
        move rat-5-amt-paid         to rat-145-amt-paid 
     else 
        multiply rat-5-amt-paid by -1 giving 
                                           rat-145-amt-paid 
     end-if 
  move rat-5-explan-cd            to rat-145-explan-cd 
    add  rat-5-amount-sub           to ws-rat-67-amt-bill 
   add  rat-145-amt-paid           to ws-rat-67-amt-paid 
   perform xc1-write-145-record thru xc1-99-exit 
    else 
    if rmb-claims 
    then 
  move rat-5-service-date         to rat-rmb-service-date 
 move rat-5-nbr-of-serv          to rat-rmb-nbr-of-serv 
  move rat-5-service-cd           to rat-rmb-service-cd 
   move rat-5-eligibility-ind      to rat-rmb-eligibility-ind 
      move rat-5-amount-sub           to rat-rmb-amount-sub 
   if   rat-5-amt-paid-sign = ' ' 
  then 
        move rat-5-amt-paid         to rat-rmb-amt-paid 
     else 
        multiply rat-5-amt-paid by -1 giving 
                                           rat-rmb-amt-paid 
     end-if 
  move rat-5-explan-cd            to rat-rmb-explan-cd 
* 97/DEC/05 - COMMENT OUT THE NEXT TWO ADD STATEMENT - MC 
*  ADD  RAT-5-AMOUNT-SUB           TO WS-RAT-67-AMT-BILL 
*  ADD  RAT-RMB-AMT-PAID           TO WS-RAT-67-AMT-PAID 
   perform xc2-write-rmb-record    thru xc2-99-exit. 
*   ENDIF 
 
xb1-99-exit. 
    exit. 
 
 
xb2-process-rec-6. 
 
    if rat-6-amt-claims-adj-sgn = ' ' 
    then 
  move rat-6-amt-claims-adj   to rat-67-amt-claims-adj 
    else 
    multiply rat-6-amt-claims-adj by -1 giving 
                                     rat-67-amt-claims-adj. 
*   ENDIF 
 
    if rat-6-amt-advances-sgn = ' ' 
    then 
       move rat-6-amt-advances     to rat-67-amt-advances 
    else 
      multiply rat-6-amt-advances by -1 giving 
                                       rat-67-amt-advances. 
*   ENDIF 
 
    if rat-6-amt-reductions-sgn = ' ' 
    then 
       move rat-6-amt-reductions   to rat-67-amt-reductions 
    else 
    multiply rat-6-amt-reductions by -1 giving 
                                     rat-67-amt-reductions. 
*   ENDIF 
 
    if rat-6-amt-deductions-sgn = ' ' 
    then 
     move rat-6-amt-deductions   to rat-67-amt-deductions 
    else 
    multiply rat-6-amt-deductions by -1 giving 
                                     rat-67-amt-deductions. 
*   ENDIF 
 
 
xb2-99-exit. 
    exit. 
 
 
xb3-process-rec-7. 
 
    move rat-7-trans-cd                    to rat-67-trans-cd. 
    move rat-7-cheque-ind            to rat-67-cheque-ind. 
    move rat-7-trans-date          to rat-67-trans-date. 
    move rat-7-trans-message               to rat-67-trans-message. 
    if   rat-7-trans-amt-sgn = ' ' 
    then 
      move rat-7-trans-amt            to rat-67-trans-amt 
    else 
     multiply rat-7-trans-amt by -1 giving 
                                      rat-67-trans-amt. 
*   ENDIF 
 
    move ws-rat-1-tot-amt-pay              to rat-67-total-clinic-amt. 
    move ws-rat-67-amt-bill          to rat-67-amt-bill. 
    move ws-rat-67-amt-paid          to rat-67-amt-paid. 
    perform xc3-write-67-record              thru xc3-99-exit. 
 
xb3-99-exit. 
    exit. 
 
 
xb4-process-rec-8. 
 
    move rat-8-mess-text                to rat-8-message-text. 
    perform xc4-write-8-record            thru xc4-99-exit. 
 
xb4-99-exit. 
    exit. 
xc1-write-145-record. 
 
    write tape-145-record. 
 
xc1-99-exit. 
    exit. 
 
 
xc2-write-rmb-record. 
 
    write tape-rmb-record. 
 
xc2-99-exit. 
    exit. 
 
 
xc3-write-67-record. 
 
    write tape-67-record. 
 
xc3-99-exit. 
    exit. 
 
 
xc4-write-8-record. 
 
    write tape-8-record. 
 
xc4-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)           to      e1-error-msg. 
    display confirm. 
    display e1-error-line. 
 
za0-99-exit. 
    exit. 
 
zb0-abend. 
 
    display "U030 ABENDING" 
    display " ". 
 
 
zb1-close-files. 
    close iconst-mstr 
        ohip-rat-tape 
   tape-145-file 
   tape-rmb-file 
   tape-67-file 
    tape-8-file. 
 
 
    stop run. 
 
zb0-99-exit. 
    exit. 

    copy "y2k_default_century_year.rtn".

    copy "y2k_default_sysdate_century.rtn". 
