identification division. 
program-id. u021a. 
author. dyad infosys Ltd.   
installation. rma. 
date-written. march 2003.     
date-compiled. 
security. 
* 
*    FILES      : u031a-   OHIP Submittal Error File  
*               : f090 -   ISAM Constants Master 
*               : u031 -   edt- 1ht file
*               : u031 -   edt- rmb file 
* 
*    PROGRAM PURPOSE : process error file returned by MOH from an EDT
*		       submission file
* 
* 
*    MAR 19/03       m. chan  - clone from u030a.cbl
*                             - modify this program to only read the 
*                               input file and extract proper record 
*                               layout based on record type into the 
*                               corresponding files (moh records or rma recs)
*                             - the reporting of these files is performed
*			        in r031b/c.qzs
* 
* 2003/mar/31 b.e. - in xb2 routine added move of 5 error codes to output file
* 2003/may/03 yas  - add new clinics AA5V AA5W AA5X AA5Y 6317 
* 2003/oct/23 b.e. - removed confirmation "Y" before job starts so that this
*		     program can run in batch
* 2004/mar/04 yas  - add new clinics 6072 and H055
* 2004/mar/04 M.C. - instead of hard coding each individual clinic nbr, get the
*		     clinic from record 1 of constants master
* 2005/Jan/04 M.C. - check up to 63 clinics instead of 40   

environment division. 
input-output section. 
file-control. 
* 
    select edt-hx-error-file 
        assign to "u021a".             
* 
    select edt-1ht-file 
    assign to "u021a_edt_1ht_file.dat". 
* 
    select edt-rmb-file 
    assign to "u021a_edt_rmb_file.dat". 
* 
    copy "f090_constants_mstr.slr". 

data division. 
file section. 
* 
    copy "u021_edt_submission_error_hx_file.fd".
* 
    copy "u021_edt_1ht_file.fd". 
* 
    copy "u021_edt_rmb_file.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_1.ws". 

working-storage section. 
 
77  ws-unique-rec-ctr 				 pic 9(6).
77  ws-orig-file-name 				 pic x(12).
77  err-ind                                      pic 99  value zero. 
77  last-account-nbr                             pic x(8).   
77  ws-sel-month                                 pic 99.      
77  ws-flag-tape-mth                             pic x. 
77  ws-flag-over-mth                             pic x. 
77  ws-scr-day                                   pic 99. 
77  ws-scr-year                                  pic 9(4). 
77  ws-scr-month                        	 pic x(9).         
77  ws-doll-amt                                  pic 9(7)v99.  
77  ws-request-clinic-ident                      pic x(4). 
77  ws-reply                                     pic x. 
77  ws-confirm-reply                             pic x. 
 
 
* 
*  STATUS FILE INDICATORS 
* 
77  status-file                                  pic x(11). 
77  status-iconst-mstr                           pic x(11) value zero. 
77  status-cobol-iconst-mstr                     pic x(2) value zero. 
 
77  i                                            pic 99. 
 
01  group-nbr-flag                               pic x. 
    88  group-nbr-found                          value 'Y'. 
    88  group-nbr-not-found                      value 'N'. 
 
01  edt-eof-flag                                 pic x. 
    88  edt-eof                                  value "Y". 
 
01  hcp-rmb-flag                                 pic x. 
    88  rmb-claims                               value 'Y'. 
    88  hcp-claims                               value 'N'. 

01  last-record					 pic x.
    88  last-record-is-item 			 value 'T'.
    88  last-record-is-message			 value '8'.
 
* 2004/03/04 - MC
*01  ws-edt-1-group-nbr                           pic x(4). 
01  ws-edt-1-group-nbr.  
    05  ws-edt-clinic-nbr			 pic 99.
    05  filler					 pic xx.

01  ws-clinic-nbr				 pic 99.

* 2004/03/04 -  end

01  ws-edt-1-moh-off-cd                          pic x. 
01  ws-edt-1-station-nbr                         pic x(3). 
01  ws-edt-1-process-date                        pic 9(8). 
01  ws-edt-1-doc-nbr                             pic 9(6).  
01  ws-edt-1-specialty-cd                        pic x(2). 
 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-edt-tape-reads                     pic 9(7). 
    05  ctr-edt-rec1-reads                     pic 9(7). 
    05  ctr-edt-rech-reads                     pic 9(7). 
    05  ctr-edt-recr-reads                     pic 9(7). 
    05  ctr-edt-rect-reads                     pic 9(7). 
    05  ctr-edt-rec8-reads                     pic 9(7). 
    05  ctr-edt-rec9-reads                     pic 9(7). 
    05  ctr-hcp-dtl-writes                     pic 9(7). 
    05  ctr-rmb-dtl-writes                     pic 9(7). 
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
    05  line 01 col 01 value is "U031A". 
    05  line 01 col 20 value is "RAT ERROR FILE APPLICATION". 
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
 
    05  line 21 col 20 value "PROGRAM U031A IN PROGRESS". 
 
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
 
    05  line 12 col 20  value is "NOW SEARCHING FOR RAT ERROR RECORD TYPE 1".    
 
01  scr-date. 
 
    05  line 14 col 20  value is "Process date is". 
    05  line 14 col 36  pic 99    using ws-scr-day           auto. 
    05  line 14 col 39  pic x(9)  using ws-scr-month         auto. 
    05  line 14 col 49  pic 9(4)  using ws-scr-year          auto. 
 
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
    perform ab0-processing             	    thru ab0-99-exit  
       until edt-eof. 
   
    perform az0-end-of-job                  thru az0-99-exit. 
* 
    stop run. 


aa0-initialization. 
   
    accept sys-date                           from date. 
    perform y2k-default-sysdate               thru y2k-default-sysdate-exit.

    move sys-mm                               to run-mm.                 
    move sys-dd                               to run-dd. 
    move sys-yy                               to run-yy. 
 
    accept sys-time                   	      from time. 
    move sys-hrs                              to run-hrs. 
    move sys-min                              to run-min. 
    move sys-sec                              to run-sec. 
 
    move zeros                                to counters. 
                                     
    move "N"                                  to edt-eof-flag. 
    move "N"                                  to hcp-rmb-flag. 
    move "N"                                  to group-nbr-flag. 
                                       
    open input iconst-mstr. 
 
    move 01                          	      to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	 invalid key 
             move 7 to err-ind 
             perform za0-common-error         thru za0-99-exit 
             perform zb0-abend                thru zb0-99-exit. 
 
*    display scr-title. 
 
aa0-10-accept-clinic. 
 
*     accept scr-clinic-nbr. 
     accept ws-request-clinic-ident.
 
     perform aa3-verify-group-nbr    thru aa3-99-exit 
        varying i from 1 by 1 
* 2005/01/04 - MC
*   	until   group-nbr-found or i > 40. 
   	until   group-nbr-found or i > 63. 
* 2005/01/04 - end
 
     if group-nbr-not-found 
     then 
         move 3                      to err-ind 
         perform za0-common-error    thru za0-99-exit 
         go to aa0-10-accept-clinic. 
*    endif 
 
*    display scr-month-id.

aa0-15-accept-month.

*    accept scr-month-id.
    accept ws-sel-month.

    if ws-sel-month  is not numeric
    then
        move  4                                  to  err-ind
        perform za0-common-error             thru za0-99-exit
        move zero                               to  ws-sel-month
        move zero                               to err-ind
      go to aa0-15-accept-month.
*   ENDIF
 
   accept ws-orig-file-name. 

*    display scr-search-rec-type-1. 
 
    open input     edt-hx-error-file. 
 
 
*    open output edt-rmb-file 
    open extend edt-rmb-file 
                edt-1ht-file .
 
aa0-20-continue-reading. 
 
    perform xa0-read-edt-tape              thru xa0-99-exit 
        until edt-1-record-type = "1" 
     	 or   edt-eof. 
 
    if not edt-eof 
    then 
        if ws-request-clinic-ident = edt-1-group-nbr 
        then 
     	    if edt-1-record-type = "1" 
            then 
          	add 1                           to ctr-edt-rec1-reads 
                perform aa1-record-1-process    thru    aa1-99-exit 
             	perform aa2-certify-month       thru    aa2-99-exit 
            else 
                go to aa0-20-continue-reading 
*           endif
   	else 
            perform xa0-read-edt-tape           thru    xa0-99-exit 
	    go to aa0-20-continue-reading 
*       endif 
    else 
  	move 1                                  to      err-ind 
 	perform za0-common-error                thru    za0-99-exit 
    	perform zb0-abend                       thru    zb0-99-exit. 
*   endif 
 
    perform xa0-read-edt-tape                   thru    xa0-99-exit. 
 
 
aa0-99-exit. 
    exit. 
 

aa1-record-1-process. 
 

* 2004/03/04 - MC - comment out the following translation
*		  - move const-clinic-nbr-1-2 to ws-edt-1-group-nbr instead

*   move edt-1-group-nbr         	to ws-edt-1-group-nbr. 
 
*   if edt-1-group-nbr = 'AA32' 
*   then 
*   	move '8000'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = 'AA03' 
*   then 
*	move '8100'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = 'AA21' 
*   then 
*	move '8200'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = 'AA25' 
*   then 
*	move '8300'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = 'AA2K' 
*   then 
*	move '9500'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = '9595' 
*   then 
*	move '6195'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = '9598' 
*   then 
*	move '6298'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = '9607' 
*   then 
*	move '6307'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = '9619' 
*   then 
*	move '6419'                     to ws-edt-1-group-nbr 
*   else 
*   if edt-1-group-nbr = '9632' 
*   then 
*	move '6532'                     to ws-edt-1-group-nbr 
*   else
*   if edt-1-group-nbr = 'AA5V'
*   then
*        move '9100'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = 'AA5W'
*   then
*        move '9200'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = 'AA5X'
*   then
*        move '9300'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = 'AA5Y'
*   then
*        move '9400'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = '6317'
*   then
*        move '9600'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = '6072'
*   then
*        move '8400'                     to ws-edt-1-group-nbr
*   else
*   if edt-1-group-nbr = 'H055'
*   then
*        move '4300'                     to ws-edt-1-group-nbr.
*   endif 

    move '0000'				 to ws-edt-1-group-nbr.
    move ws-clinic-nbr			 to ws-edt-clinic-nbr.  

* 2004/03/04 - end
 
    move edt-1-moh-off-cd               to ws-edt-1-moh-off-cd. 
    move edt-1-station-nbr              to ws-edt-1-station-nbr. 
    move edt-1-process-date             to ws-edt-1-process-date. 
    move edt-1-doc-nbr                  to ws-edt-1-doc-nbr. 
    move edt-1-specialty-cd             to ws-edt-1-specialty-cd. 
 
aa1-99-exit. 
    exit. 
 
 
aa2-certify-month. 
 
    move edt-1-process-date-dd               to      ws-scr-day. 
    move edt-1-process-date-yy               to      ws-scr-year. 
    move mth-desc ( edt-1-process-date-mm )  to      ws-scr-month. 

*    display scr-date.
 
*    display scr-accept-mth. 
*   accept  scr-tape-mth. 
*   (running in batch - the month should be right or shutdown)
    move "Y"					to	ws-flag-tape-mth.
 
    if ws-sel-month  not = edt-1-process-date-mm 
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
*            display program-in-progress 
     	    go to aa2-99-exit 
   	else 
            go to  zb1-close-files.             
*       endif 
*   endif 

*  (b.e. - running in batch - preset all responses) 
*    display scr-override-mth. 
*    accept  scr-override-mth. 
    move "Y"		to ws-flag-over-mth 
    if ws-flag-over-mth  = "Y" 
    then 
*        display program-in-progress 
        go to aa2-99-exit. 
*   endif 
 
aa2-10-confirm-neg-response. 
 
*    display scr-confirm-neg-response. 
*    accept confirm-reply. 
 
    if ws-confirm-reply =    "Y" 
         	          or "N" 
    then 
	 next sentence 
    else 
   	 move  6                         to      err-ind 
 	 perform za0-common-error        thru    za0-99-exit 
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
* 2004/03/04 - MC - save clinic-nbr
	move const-clinic-nbr-1-2(i)	to ws-clinic-nbr
* 2004/03/04 - end
        move 'Y'                to group-nbr-flag. 
*   endif 
 
aa3-99-exit. 
    exit. 
 

ab0-processing. 
 
    if edt-1-record-type = "1" 
    then 
      	if ws-request-clinic-ident not = edt-1-group-nbr 
      	then 
      	     move "Y"                    to edt-eof-flag 
     	     go to ab0-99-exit. 
*       endif
*   endif 
 
    perform xa1-create-tape-files thru xa1-99-exit. 
 
 
ab0-10-read-next-rat. 
 
    perform xa0-read-edt-tape             thru xa0-99-exit. 
 
 
ab0-99-exit. 
    exit. 
 
az0-end-of-job. 
 
 
*    display blank-screen. 
    display " ". 
    display "OHIP RATS READ          "       ctr-edt-tape-reads. 
    display "OHIP RATS REC 1 READ    "       ctr-edt-rec1-reads. 
    display "OHIP RATS REC H READ    "       ctr-edt-rech-reads. 
    display "OHIP RATS REC R READ    "       ctr-edt-recr-reads. 
    display "OHIP RATS REC T READ    "       ctr-edt-rect-reads. 
    display "OHIP RATS REC 8 READ    "       ctr-edt-rec8-reads. 
    display "OHIP RATS REC 9 READ    "       ctr-edt-rec9-reads. 
    display "HCP HEADER REC READ     "       hcp-records. 
    display "RMB HEADER REC READ     "       rmb-records. 
    display "HCP DTL REC WRITE       "       ctr-hcp-dtl-writes. 
    display "RMB DTL REC WRITE       "       ctr-rmb-dtl-writes. 
 
    close iconst-mstr 
          edt-hx-error-file 
   	  edt-1ht-file 
   	  edt-rmb-file .
 
 
    display " ". 
    display "NORMAL END OF JOB - U031A ". 
 
    stop run. 
 
az0-99-exit. 
    exit. 


xa0-read-edt-tape. 
 
    read edt-hx-error-file 
         at end 
	      move "Y" to edt-eof-flag 
              go to xa0-99-exit. 
 
    add 1 to ctr-edt-tape-reads. 
 
xa0-99-exit. 
    exit. 
 

xa1-create-tape-files. 
 
    if edt-1-record-type = '1' 
    then 
        add 1                              to ctr-edt-rec1-reads 
        perform aa1-record-1-process 
    else
    if edt-1-record-type = 'H' 
    then 
    	add 1                              to ctr-edt-rech-reads 
   	perform xb0-process-rec-h          thru xb0-99-exit 
    else 
    if edt-1-record-type = 'R' 
    then 
    	add 1                              to ctr-edt-recr-reads 
   	perform xb1-process-rec-r          thru xb1-99-exit 
    else 
        if edt-1-record-type = 'T' 
        then 
             add 1                         to ctr-edt-rect-reads 
       	     perform xb2-process-rec-t     thru xb2-99-exit 
        else 
             if edt-1-record-type = '8' 
             then         
                   add 1                   to ctr-edt-rec8-reads 
                   perform xb3-process-rec-8  thru xb3-99-exit 
        else 
             if edt-1-record-type = '9' 
             then         
                   add 1                   to ctr-edt-rec9-reads 
                   perform xb4-process-rec-9  thru xb4-99-exit. 
*            endif 
*       endif 
*   endif 
 
xa1-99-exit. 
    exit. 
 

xb0-process-rec-h. 
 
    if last-record-is-item
    then
	if hcp-claims	
	then
	    perform xc1-write-1ht-record 	thru xc1-99-exit
	else
	    perform xc2-write-rmb-record 	thru xc2-99-exit.
*	endif
*   endif

	
    if edt-h-pay-prog =  'HCP'
    then 
       	move "N"                        to hcp-rmb-flag 
    else 
 	move "Y"                        to hcp-rmb-flag. 
*   endif 

    add 1 			 	to ws-unique-rec-ctr.

    if hcp-claims 
    then 
        add 1                           to hcp-records 
        move spaces                     to edt-1ht-record 
        move ws-unique-rec-ctr		to edt-1ht-orig-seq-nbr
        move ws-orig-file-name		to edt-1ht-file-name

        move ws-edt-1-group-nbr         to edt-1ht-group-nbr 
        move ws-edt-1-moh-off-cd        to edt-1ht-moh-off-cd 
        move ws-edt-1-station-nbr       to edt-1ht-station-nbr 
        move ws-edt-1-process-date      to edt-1ht-process-date 
        move ws-edt-1-doc-nbr           to edt-1ht-doc-nbr  
        move ws-edt-1-specialty-cd      to edt-1ht-specialty-cd

        move edt-h-health-nbr           to edt-1ht-health-nbr
        move edt-h-version-cd           to edt-1ht-version-cd 
        move edt-h-birth-date           to edt-1ht-birth-date 
        move edt-h-account-nbr          to edt-1ht-account-nbr 
	move edt-h-pay-prog             to edt-1ht-pay-prog 
        move edt-h-payee                to edt-1ht-payee      
        move edt-h-doc-nbr              to edt-1ht-refer-doc-nbr
        move edt-h-facility-nbr         to edt-1ht-facility-nbr   
        move edt-h-patient-admission-date to edt-1ht-admit-date  
        move edt-h-location-cd          to edt-1ht-loc-cd    
        move edt-h-error-cd-1           to edt-1ht-error-h-cd-1
        move edt-h-error-cd-2           to edt-1ht-error-h-cd-2
        move edt-h-error-cd-3           to edt-1ht-error-h-cd-3
        move edt-h-error-cd-4           to edt-1ht-error-h-cd-4
        move edt-h-error-cd-5           to edt-1ht-error-h-cd-5
    else 
    if rmb-claims 
    then
        add 1                           to rmb-records 
        move spaces                     to edt-rmb-record 
        move ws-unique-rec-ctr		to edt-rmb-orig-seq-nbr
        move ws-orig-file-name		to edt-rmb-file-name

        move ws-edt-1-group-nbr         to edt-rmb-group-nbr 
        move ws-edt-1-moh-off-cd        to edt-rmb-moh-off-cd 
        move ws-edt-1-station-nbr       to edt-rmb-station-nbr 
        move ws-edt-1-process-date      to edt-rmb-process-date 
        move ws-edt-1-doc-nbr           to edt-rmb-doc-nbr  
        move ws-edt-1-specialty-cd      to edt-rmb-specialty-cd

        move edt-h-health-nbr           to edt-rmb-health-nbr
        move edt-h-version-cd           to edt-rmb-version-cd 
        move edt-h-birth-date           to edt-rmb-birth-date 
        move edt-h-account-nbr          to edt-rmb-account-nbr 
        move edt-h-pay-prog             to edt-rmb-pay-prog 
        move edt-h-payee                to edt-rmb-payee      
        move edt-h-doc-nbr              to edt-rmb-refer-doc-nbr
        move edt-h-facility-nbr         to edt-rmb-facility-nbr   
        move edt-h-patient-admission-date to edt-rmb-admit-date  
        move edt-h-location-cd          to edt-rmb-loc-cd    
        move edt-h-error-cd-1           to edt-rmb-error-h-cd-1
        move edt-h-error-cd-2           to edt-rmb-error-h-cd-2
        move edt-h-error-cd-3           to edt-rmb-error-h-cd-3
        move edt-h-error-cd-4           to edt-rmb-error-h-cd-4
        move edt-h-error-cd-5           to edt-rmb-error-h-cd-5.
*   endif 
 
    move 'H'				to last-record.
 
xb0-99-exit. 
    exit. 
 
 
xb1-process-rec-r. 
 
    add 1 			 	to ws-unique-rec-ctr.

    if rmb-claims 
    then 
        move ws-unique-rec-ctr		to edt-rmb-orig-seq-nbr
        move ws-orig-file-name		to edt-rmb-file-name.
        move edt-r-registration-nbr     to edt-rmb-registration-nbr
        move edt-r-last-name            to edt-rmb-last-name 
        move edt-r-first-name           to edt-rmb-first-name 
        move edt-r-sex                  to edt-rmb-sex     
        move edt-r-prov-cd              to edt-rmb-prov-cd 
        move edt-r-error-cd-1           to edt-rmb-error-r-cd-1
        move edt-r-error-cd-2           to edt-rmb-error-r-cd-2
        move edt-r-error-cd-3           to edt-rmb-error-r-cd-3
        move edt-r-error-cd-4           to edt-rmb-error-r-cd-4
        move edt-r-error-cd-5           to edt-rmb-error-r-cd-5.
*   endif 

xb1-99-exit.
   exit.

 
 
xb2-process-rec-t. 

    if last-record-is-item
    then
	if hcp-claims	
	then
	    perform xc1-write-1ht-record 	thru xc1-99-exit
	else
	    perform xc2-write-rmb-record 	thru xc2-99-exit.
*	endif
*   endif

    add 1 			 	to ws-unique-rec-ctr.

    if hcp-claims 
    then 
        move ws-unique-rec-ctr		to edt-1ht-orig-seq-nbr
        move ws-orig-file-name		to edt-1ht-file-name
        move edt-t-service-cd           to edt-1ht-service-cd 
        move edt-t-amount-sub           to edt-1ht-amount-sub  
        move edt-t-nbr-of-serv          to edt-1ht-nbr-of-serv 
        move edt-t-service-date         to edt-1ht-service-date 
        move edt-t-diag-cd              to edt-1ht-diag-cd         
        move edt-t-explan-cd            to edt-1ht-t-explan-cd 
	move edt-t-error-cd-1		to edt-1ht-error-t-cd-1
	move edt-t-error-cd-2		to edt-1ht-error-t-cd-2
	move edt-t-error-cd-3		to edt-1ht-error-t-cd-3
	move edt-t-error-cd-4		to edt-1ht-error-t-cd-4
	move edt-t-error-cd-5		to edt-1ht-error-t-cd-5
 	move spaces			to edt-1ht-8-explan-cd
					   edt-1ht-8-explan-desc
    else 
    if rmb-claims 
    then 
        move ws-unique-rec-ctr		to edt-rmb-orig-seq-nbr
        move ws-orig-file-name		to edt-rmb-file-name
        move edt-t-service-cd           to edt-rmb-service-cd 
        move edt-t-amount-sub           to edt-rmb-amount-sub  
        move edt-t-nbr-of-serv          to edt-rmb-nbr-of-serv 
        move edt-t-service-date         to edt-rmb-service-date 
        move edt-t-diag-cd              to edt-rmb-diag-cd         
  	move edt-t-explan-cd            to edt-rmb-t-explan-cd
	move edt-t-error-cd-1		to edt-rmb-error-t-cd-1
	move edt-t-error-cd-2		to edt-rmb-error-t-cd-2
	move edt-t-error-cd-3		to edt-rmb-error-t-cd-3
	move edt-t-error-cd-4		to edt-rmb-error-t-cd-4
	move edt-t-error-cd-5		to edt-rmb-error-t-cd-5
 	move spaces			to edt-rmb-8-explan-cd
					   edt-rmb-8-explan-desc.
*   endif 
    move 'T'				to last-record.
 
xb2-99-exit. 
    exit. 
 
 
 
xb3-process-rec-8. 

    add 1 			 	to ws-unique-rec-ctr.

    if hcp-claims
    then
        move ws-unique-rec-ctr		to edt-1ht-orig-seq-nbr
        move ws-orig-file-name		to edt-1ht-file-name
    	move edt-8-explan-cd		to edt-1ht-8-explan-cd 
    	move edt-8-explan-desc          to edt-1ht-8-explan-desc 
    	perform xc1-write-1ht-record    thru xc1-99-exit 
    else
    if rmb-claims
    then
        move ws-unique-rec-ctr		to edt-rmb-orig-seq-nbr
        move ws-orig-file-name		to edt-rmb-file-name
    	move edt-8-explan-cd		to edt-rmb-8-explan-cd 
    	move edt-8-explan-desc          to edt-rmb-8-explan-desc 
    	perform xc2-write-rmb-record    thru xc2-99-exit.
*   endif 
 
    move '8'				to last-record.

xb3-99-exit. 
    exit. 


xb4-process-rec-9. 

    if last-record-is-item
    then
	if hcp-claims	
	then
	    perform xc1-write-1ht-record 	thru xc1-99-exit
	else
	    perform xc2-write-rmb-record 	thru xc2-99-exit.
*	endif
*   endif


    move '9'				to last-record.

xb4-99-exit.
    exit.

xc1-write-1ht-record. 
 
    write edt-1ht-record. 
    add 1				to ctr-hcp-dtl-writes.
 
xc1-99-exit. 
    exit. 
 
 
xc2-write-rmb-record. 
 
    write edt-rmb-record. 
    add 1				to ctr-rmb-dtl-writes.
 
xc2-99-exit. 
    exit. 
 
 
 
za0-common-error. 
 
    move err-msg (err-ind)           to      e1-error-msg. 
    display confirm. 
    display e1-error-line. 
 
za0-99-exit. 
    exit. 
 
zb0-abend. 
 
    display "U021A ABENDING" 
    display " ". 
 
 
zb1-close-files. 
    close iconst-mstr 
          edt-hx-error-file 
          edt-1ht-file 
          edt-rmb-file.
 
 
    stop run. 
 
zb0-99-exit. 
    exit. 

    copy "y2k_default_century_year.rtn".

    copy "y2k_default_sysdate_century.rtn". 
