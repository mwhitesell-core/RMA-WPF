program-id.     cdiserver. 
author.         dyad infoSys. 
installation.   regional medical associates. 
date-written.   93/sep/20. 
date-compiled. 
security. 
* 
*				PIPEDA
*
*
*  called from cdi.c socket program

*    modification history
*     DATE    WHO      	WHY 
* 2005/jan/03 b.e.	- original (cloned from cpirma5.cbl)
* 2005/jan/17 b.e.	- increase 1st 2 key values passed in 'request'
*			  from 20 to 30 characters each
*			- added f027/f028 files and dummy of f027/f028
*			  data info doctor's 'extneded' area to allow
*			  creation of staff share/database wb without
*			  having to read contact and contact info files
*			  in separate call (this functionality to be 
*			  added later)
* 2005/jan/31 b.e.	- added request type 2 and 3 to read a doctor's
*			  contacts and contact-info respectively
* 2005/mar/18 b.e.	- aded new fields for contact

*

environment division. 
input-output section. 
file-control. 
* 
* 
    copy "f020_doctor_mstr.slr".
*
    copy "f020_doctor_extra_mstr.slr".
*
    copy "f027_contacts_mstr.slr".
*
    copy "f028_contacts_info_mstr.slr".
*
    copy "f070_dept_mstr.slr".

    copy "f123_company_mstr.slr".
*
    select audit-file-a 
        assign to printer print-file-name-a 
	file status is status-audit-rpt-a. 
 
    select audit-file-b 
        assign to printer print-file-name-b 
	file status is status-audit-rpt-b. 
 
    select audit-file-c 
        assign to printer print-file-name-c 
	file status is status-audit-rpt-c. 

    select error-rpt-a 
        assign to printer error-rpt-name-a
	file status is status-error-rpt-a. 

data division. 
file section. 
* 
    copy "f020_doctor_mstr.fd".
*
    copy "f020_doctor_extra_mstr.fd".
*
    copy "f027_contacts_mstr.fd".
*
    copy "f028_contacts_info_mstr.fd".
*
    copy "f070_dept_mstr.fd".
*
    copy "f123_company_mstr.fd".
*
 
fd  audit-file-a 
    record contains 132 characters. 
 
01  rpt-rec-a                   pic x(132). 

*
*
*
 
fd  audit-file-b 
    record contains 132 characters. 
 
01  rpt-rec-b                   pic x(132). 

*
*
*

fd  audit-file-c 
    record contains 132 characters. 
 
01  rpt-rec-c                   pic x(132). 

*
*
*

fd  error-rpt-a 
    record contains 132 characters. 
 
01  err-rpt-rec-a.
    05 err-date				pic  x(10) value " ".
    05 filler				pic  x(02) value " ".
    05 err-time				pic  x(05) value " ".
    05 filler				pic  x(02) value " ".
    05 err-code				pic s9(06) .
    05 err-data-1			pic x(100).
    05 filler	 	                pic  x(07). 

 
working-storage section.
77 brad pic 9(5).

* WARNING - the sizes below must match:
*	1) linkage section of this program (buffer-doctor-records)
*	2) sizes in rma.c
* 	3) and the cpi_rma.dll(web component)'s CONST MAX_LENGTH_RECORD

78  REQUEST-LENGTH	        value 726.

******************************************************************************
*  WARNING - must keep record same length as "doc-mstr-rec" of f010 FD
*  and keep in sync with 'buffer-doctor-records' definition in 'linkage' section
******************************************************************************
*
* NOTE: when set to 10 recs / buffer the process would only return 6 records
*	to the CDI object - not sure what limitation was being reach but only
*	3798 bytes received from socket each time
*	Therefore keep buffer at 5 unless length of record reduced
*

*78  MAX-DOC-RECS-IN-BUFFER 	value 10.
*78  MAX-DOC-RECS-IN-BUFFER 	value 5.
78  MAX-DOC-RECS-IN-BUFFER 	value 1.
78  MAX-CONTACTS-RECS-IN-BUFFER value 10.

*  (return-code error codes)
78  general-processing-error	value 1.
78  invalid-request-type	value 2.
78  invalid-sex			value 3.
78  invalid-action		value 4.
78  invalid-location		value 5.
78  invalid-key-type		value 6.
78  invalid-key-value-1		value 7.
78  invalid-key-value-2		value 8.
78  invalid-dept    		value 9.
78  invalid-no-such-doctor	value 10.

77  length-last-name-search		pic 9(2).
77  length-last-name-found		pic 9(2).
77  length-first-name-search		pic 9(2).
77  length-first-name-found		pic 9(2).

77 hold-doc-rma-nbr			pic x(3).
77 hold-doc-ohip-nbr			pic x(6).
77 hold-doc-name			pic x(30).

01  test-string-1-last-name		pic x(25).
01  test-string-2-last-name		pic x(25).
01  test-string-1-first-name		pic x(15).
01  test-string-2-first-name		pic x(15).
01  const-question-marks			pic x(200) 
	value "????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????".
 77  test-char				pic x(1).

77  print-file-name-a				pic x(13) 
		                                value "rmaDoc_a.log". 
77  print-file-name-b				pic x(13)
		                                value "rmaDoc_b.log". 
77  print-file-name-c				pic x(13) 
		                                value "rmaDoc_c.log". 
77  error-rpt-name-a				pic x(13) 
		                                value "rmaDoc_e.log". 
* 
77  ss   					pic 99 comp. 
77  err-ind					pic 99 value zero. 
77  space-ctr					pic 99 value zero. 

*   (subscripts for "contact-info-occurs")
77  ss-doc   					pic 99 comp value 1. 
77  ss-secretary 				pic 99 comp value 2. 
77  ss-contact					pic 99 comp.
*   (subscripts for "home-office-contact-info"
77  ss-home  					pic 99 comp value 1. 
77  ss-office					pic 99 comp value 2. 
77  ss-contact-info				pic 99 comp.
*
77  status-cobol-dept-mstr                      pic x(2) value zero.
77  status-cobol-company-mstr                   pic x(2) value zero.
77  status-cobol-contacts-mstr                  pic x(2) value zero.
77  status-cobol-contacts-info                  pic x(2) value zero.
77  status-cobol-doc-extra-mstr			pic x(2) value zero.
* 
* 
*   (STATUS FILE INDICATORS.) 
* 
01 status-indicators. 
    05  status-file                             pic xx.
    05  status-audit-rpt-a			pic xx    value "0". 
    05  status-audit-rpt-b			pic xx    value "0". 
    05  status-audit-rpt-c			pic xx    value "0". 
    05  status-error-rpt-a			pic xx    value "0". 
    05  status-doc-mstr				pic xx    value "0".

    05  status-cobol-doc-mstr.
	10  status-cobol-doc-mstr1		pic x	value "0".
	10  status-cobol-doc-mstr2		pic x	value "0".
    05  status-cobol-doc-mstr-binary 
		redefines status-cobol-doc-mstr pic 9(4) comp.

    05  status-cobol-contact-mstr.
	10  status-cobol-contact-mstr1		pic x	value "0".
	10  status-cobol-contact-mstr2		pic x	value "0".
    05  status-cobol-contact-binary 
		redefines status-cobol-contact-mstr pic 9(4) comp.

    05  status-cobol-display.
	10 status-cobol-display1		pic x.
	10 filler				pic x(3).
	10 status-cobol-display2		pic 9(4).

**   (STRING RELATED.) 
* 
01  ws-last-name				pic x(15). 
01  ws-first-name. 
    05  ws-first-name-1				pic x. 
    05  ws-first-name-11			pic x(11). 
 
01  ws-subscr-surname				pic x(15). 
* 
* 
01  ws-street-addr. 
    05  ws-street-addr1				pic x(21). 
    05  ws-street-addr2				pic x(7). 
 
01  ws-city-prov. 
    05  ws-city					pic x(16). 
    05  filler      				pic x. 
    05  ws-prov					pic x(4). 
 
01  ws-prov-cd					pic xx. 
 
01  ws-detail. 
    05  ws-detail-field				pic x(28). 
    05  ws-detail-field-r       redefines	ws-detail-field. 
	10  ws-detail-byte 			pic x 
				occurs 28 times. 
 
01  flag-status                                 pic x.
    88 ok                                       value "Y".
    88 not-ok                                   value "N".
 
01  matching-doc-flag                           pic x. 
    88  matching-doc-exists                  		value "Y". 
    88  matching-doc-not-exists            		value "N". 
01  matching-contact-flag                       pic x. 
    88  matching-contact-exists                		value "Y". 
    88  matching-contact-not-exists            		value "N". 
01  matching-contact-info-flag                  pic x. 
    88  matching-contact-info-exists           		value "Y". 
    88  matching-contact-info-n-exists       		value "N". 

01  doc-eof-flag                           	pic x. 
    88  doc-eof                  			value "Y". 
    88  doc-not-eof            				value "N". 
01 dept-eof-flag                           	pic x. 
    88  dept-eof 	              			value "Y". 
    88  dept-not-eof           				value "N". 
01 contact-eof-flag                           	pic x. 
    88  contact-eof                  			value "Y". 
    88  contact-not-eof        				value "N". 
01 contact-info-eof-flag                       	pic x. 
    88  contact-info-eof               			value "Y". 
    88  contact-info-not-eof   				value "N". 

 
*   (COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES.) 
01  counters. 
    05  ctr-doctors-read			pic 9(7).
    05  ctr-contacts-read			pic 9(7).
    05  ctr-contacts-info-read			pic 9(7).
    05  ctr-error-rpt-writes			pic 9(7). 
    05  ctr-warnings-rpt-writes			pic 9(7). 
    05  ctr-rpt-a-pages                         pic 9(3). 
    05  ctr-rpt-b-pages                         pic 9(3). 
    05  ctr-rpt-c-pages                         pic 9(3). 
    05  ctr-rpt-a-lines                         pic 9(3). 
    05  ctr-rpt-b-lines                         pic 9(3). 
    05  ctr-rpt-c-lines                         pic 9(3). 
    05  ctr-reject                              pic 9(2). 
    05  ctr-warning				pic 9(2). 
    05  ctr-update				pic 9(2). 
 
*   COPY "MOD_CHECK_DIGIT.WS". 
 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"FUNCTION CODE MUST BE  AA  (ADD)". 
	10  filler				pic x(60)   value 
			"HEALTH NO AND CHART NO BOTH CAN'T BE BLANK". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 2  times. 
77  max-error-message-table
		pic 9(2) value 2. 
 
01  err-msg-table. 
    05  err-no                                  pic x(4). 
    05  err-filler				pic x(3). 
    05  err-msg-comment                         pic x(64). 
 
01  prov-table. 
 
    05  province. 
        10  filler                              pic x(6) value "ALBTAB". 
        10  filler				pic x(6) value "NFLDNF". 
	10  filler   				pic x(6) value "SASKSK". 
        10  filler                              pic x(6) value "MAN MB". 
        10  filler				pic x(6) value "NWT NT". 
	10  filler   				pic x(6) value "ONT ON". 
        10  filler                              pic x(6) value "PEI PE". 
        10  filler				pic x(6) value "QUE PQ". 
	10  filler   				pic x(6) value "YUK YT". 
        10  filler                              pic x(6) value "BC  BC". 
        10  filler				pic x(6) value "NB  NB". 
	10  filler   				pic x(6) value "NS  NS". 
	10  filler   				pic x(6) value "OTH OT". 
 
    05  province-r   		 redefines      province. 
 
	10  prov                 occurs 13 times. 
            15  old-prov			pic x(4). 
	    15  new-prov			pic x(2). 
    copy "sysdatetime.ws".

01  line-error.
    05  le-time-stamp                           pic x(20).
    05  filler                                  pic x(2).
    05  le-error-code                           pic x(10).

01  l0-time-stamp.
    05  l0-date.
        10  l0-yy                               pic 9(4).
        10  l0-slash1                           pic x   value "/".
        10  l0-mm                               pic 99.
        10  l0-slash2                           pic x   value "/".
        10  l0-dd                               pic 99.
    05  filler                                  pic x(2).
    05  l0-time.
        10  l0-hrs                              pic 99.
        10  l0-colon1                           pic x   value ":".
        10  l0-min                              pic 99.
        10  l0-colon2                           pic x   value ":".
        10  l0-sec                              pic 99.
 
01  l1-line. 
    05  l1-time-stamp				pic x(20).
    05  filler					pic x(01).
    05  l1-request-type            		pic x(01).
    05  filler					pic x(01).
    05  l1-action              			pic x(01).
    05  filler					pic x(01).
    05  l1-location				pic x(01).
    05  filler					pic x(01).
    05  l1-sex     				pic x(01).
    05  filler					pic x(01).
    05  l1-dept    				pic x(02).
    05  filler					pic x(01).
    05  l1-key-type				pic x(01).
    05  filler					pic x(01).
    05  l1-key-value1                           pic x(25).
    05  filler                                  pic x(01).
    05  l1-key-value2                           pic x(20).
    05  filler                                  pic x(01).
*    05  l1-key-value3                           pic 9(7).
    05  l1-key-value3                           pic x(3).
 

linkage section.

01  stringLength                pic x(4) comp-5.

01  request.
    10  request-type            pic x(01).
        88 request-doctor               value "2".
        88 request-contact              value "3".
        88 request-contact-info         value "4".
    10  request-data            pic x(99).
    10  request-r  redefines  request-data.
        20  request-action      pic x(01).
        20  key-type            pic x(01).
            88 search-by-company                value "c".
            88 search-by-dept                   value "d".
            88 search-by-name                   value "n".
            88 search-by-ohip-nbr               value "o".
            88 search-by-rma-id                 value "i".
        20  request-company     pic x(02).
        20  request-dept        pic x(02).
        20  request-sex         pic x(01).
            88 searching-for-male               value "m".
            88 searching-for-female             value "f".
            88 searching-for-both-sex           value "a".
*           (key length = 24 to match length of surname)
        20  key-value1.
            30 key-value1-rma-nbr
                                pic x(3).
            30 key-value1-remainder
                                pic x(21).
        20  key-value1-r redefines key-value1.
            30 key-value1-ohip-nbr
                                pic x(6).
            30 filler           pic x(18).
*           (key length = 24 to match length of given name)
        20  key-value2          pic x(24).
*        20  key-value3          pic 9(07).
        20  key-value3          pic x(03).
        20  x-filler            pic x(21).

****************************************************************************
01 buffer-doctor-records.
*						= 7 + 1 + 1696 = 1704
* (this counter is used as a 'return' value telling the calling program
*  how many records were returned in the buffer-doctor-records)
   10  buffer-record-count		pic x(7).
   10  max-nbr-records-exceeded		pic x(1).

   10 buffer-data-records				pic x(1696).
   10 buffer-data-records-r redefines buffer-data-records.
      15 buffer-doctor-records-occurs occurs MAX-DOC-RECS-IN-BUFFER.
         20  buffer-doctor-rec		pic x(695).
*							 	= 695
*        EXTENDED DOCTOR RECORD
         20  buffer-doctor-rec-extra-fields.
	     25  buff-doc-company		pic x( 2).
         20  buffer-doctor-rec-extended.    
	     25  buff-billing-via-paper	pic x( 1).
	     25  buff-billing-via-diskette	pic x( 1). 
	     25  buff-billing-via-web-test	pic x( 1).
	     25  buff-billing-via-web-live	pic x( 1).
	     25  buff-date-start-diskette	pic x( 8).
	     25  buff-date-start-paper	pic x( 8).
	     25  buff-date-start-web-live	pic x( 8).
	     25  buff-date-start-web-test	pic x( 8).
	     25  buff-leave-description	pic x(30).
	     25  buff-leave-date-start	pic x( 8).
	     25  buff-leave-date-end		pic x( 8).
	     25  buff-abe-flag	pic x( 1).
	     25  buff-web-user-revenue-only	pic x( 1).
	     25  buff-doc-med-prof-corp		pic x( 1). 
	     25  buff-manager			pic x( 1).
	     25  buff-chair			pic x( 1).
	     25  buff-cpso-nbr			pic x( 5).
	     25  buff-cmpa-nbr			pic x( 8).
	     25  buff-oma-nbr			pic x( 9).
	     25  buff-cfpc-nbr			pic x( 6).
	     25  buff-rcpsc-nbr			pic x( 6).
*						 	= 123
*		 (use ss-doc and ss-secretary to access 2 contact types)
	     25  contact-info-occurs occurs 2.
                30  buff-surname     		pic x(30).
                30  buff-given-names 		pic x(30).
                30  buff-inits       		pic x( 3).
                30  buff-title       		pic x(30).
	        30  buff-sex			pic x( 1).
                30  buff-billing-entry-flag 	pic x( 1).
		30  buff-username-logon-web	pic x(20).
*								= 95*2
*								= 190  
*		    (use ss-home and ss-office to access 2 contact-info types)
		30  home-office-contact-info occurs 2.
		    35  buff-addr-1		pic x(30).
		    35  buff-addr-2		pic x(30).
		    35  buff-addr-3		pic x(30).
		    35  buff-addr-pc		pic x( 6).

            	    35  buff-email-addr 	pic x(30).
            	    35  buff-phone-nbr 		pic x(10).
            	    35  buff-phone-ext 		pic x( 5).
	    	    35  buff-cell-nbr   	pic x(10).
	    	    35  buff-pager-nbr		pic x(10).
	    	    35  buff-fax-nbr		pic x(10).
	    	    35  buff-newsletter 	pic x( 1).
*								=172*4
*								=688
*								=======
*								  695
*								+ 123
*								+ 190
*								+ 688
*								=====
*							         1696

   10 buffer-doctor-contacts-r redefines buffer-data-records.
       20   buffer-contact-rec occurs MAX-DOC-RECS-IN-BUFFER.
*		f027
            25  buff-contacts-type                 pic x( 1).
            25  buff-contacts-given-names          pic x(30).
            25  buff-contacts-surname              pic x(30).
            25  buff-contacts-inits                pic x( 3).
            25  buff-contacts-title                pic x(30).
            25  buff-contacts-sex                  pic x( 1).
            25  buff-contacts-billing-entry        pic x( 1).

  10 buffer-doctor-contacts-info-r redefines buffer-data-records.
       20   buffer-contact-info-rec occurs MAX-DOC-RECS-IN-BUFFER.
*		f028
            25  buff-contacts-type                 pic x( 1).
            25  buff-contacts-location             pic x( 1).
            25  buff-contacts-addr-1               pic x(30).
            25  buff-contacts-addr-2               pic x(30).
            25  buff-contacts-addr-3               pic x(30).
            25  buff-contacts-addr-pc              pic x( 6).
            25  buff-contacts-email-addr           pic x(30).
            25  buff-contacts-phone-nbr            pic x(10).
            25  buff-contacts-phone-ext            pic x( 5).
            25  buff-contacts-newsletter      	   pic x( 1).

*01 next-item		pic x(4) comp-5.

procedure division. 
declaratives. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING PATIENT MASTER". 
    move status-cobol-doc-mstr          to status-file. 
    display status-file. 

    move status-cobol-doc-mstr1  	  to status-cobol-display1.
    if   status-cobol-doc-mstr1 <> 9
    then
	move status-cobol-doc-mstr2  	  to status-cobol-display2
    else
	move low-values			  to status-cobol-doc-mstr1
	move status-cobol-doc-mstr-binary to status-cobol-display2.
*   endif
    display "Patient error = ", status-cobol-display.
    stop run. 
 
err-audit-rpt-file-a section. 
    use after standard error procedure on audit-file-a. 
err-audit-rpt-a. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-A". 
    move status-audit-rpt-a		to status-file. 
    display status-file. 
    stop run. 
 
err-audit-rpt-file-b section. 
    use after standard error procedure on audit-file-b. 
err-audit-rpt-b. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-B". 
    move status-audit-rpt-b		to status-file. 
    display status-file. 
    stop run. 
 
err-audit-rpt-file-c section. 
    use after standard error procedure on audit-file-c. 
err-audit-rpt-c. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-C". 
    move status-audit-rpt-c		to status-file. 
    display status-file. 
    stop run. 
 
end declaratives. 


main-line section. 
mainline. 
 
exit program.

********************
*  entry VALIDATE  *
********************
* this entry point called when name of the program is called - doesn't
* need a separate entry point
****entry "validate" using 
****			stringLength 
****			request.
ab0-validate.

    perform aa0-initialization          thru aa0-99-exit.

    if   request-doctor
      or request-contact
      or request-contact-info
    then
	next sentence
    then
        move invalid-request-type       to      return-code
        perform za0-error-processing    thru    za0-99-exit
        go to ab0-99-exit.
*   end if

*   (only a 'f'ind action defined at this time)
    if request-action <> "f"
    then
        move invalid-action             to      return-code
        perform za0-error-processing    thru    za0-99-exit
        go to ab0-99-exit.
*   end if

*   (4 types of search protocols)
    if     not search-by-name
       and not search-by-rma-id
       and not search-by-ohip-nbr
       and not search-by-company
    then
        move invalid-key-type           to      return-code
        perform za0-error-processing    thru    za0-99-exit
        go to ab0-99-exit.
*   end if
    
*   (name search: sex must be 'a'll, 'm'ale, or 'f'emale)
    if  search-by-name
    then
	if   searching-for-male
	  or searching-for-female
	  or searching-for-both-sex
	then
	    next sentence
	else
            move invalid-sex                to      return-code
            perform za0-error-processing    thru    za0-99-exit
            go to ab0-99-exit.
*       endif
*   end if

*   (ensure null values are replaced)
    inspect key-value1 replacing all low-values by zeros.
    inspect key-value2 replacing all low-values by zeros.

*   (ensure key-value3 is entirely numeric values)
    inspect key-value3 replacing all low-values by spaces.
    inspect key-value3 replacing all spaces     by zeros.

*   (ensure request-company is entirely numeric values)
    inspect request-company replacing all low-values by zeros.
    inspect request-company replacing all spaces     by zeros.

*   (ensure request-dept is entirely numeric values)
    inspect request-dept replacing all low-values by zeros.
    inspect request-dept replacing all spaces     by zeros.

*   (no errors - set success flag)
    move 0                              to      return-code.

*   (2003/feb/26 BE. added to close files)
    perform az0-end-of-job      thru    az0-99-exit.

ab0-99-exit.
    exit.

****   exit program.


******************
*  entry LOOKUP  *
******************

entry "lookup"	using
			request
			buffer-doctor-records.
ab1-perform-lookup.


*   (setting return code bombs cobol so calling validate code here rather
*   than from C code)

    perform aa0-initialization          thru aa0-99-exit.

**********    move spaces				to buffer-doctor-records.

    perform xa0-write-audit-request	thru xa0-99-exit.

    perform ab0-validate		thru ab0-99-exit.
*   (if the validate routine found an error, then skip the reads)
    if return-code <> 0
    then
        perform xb0-write-audit-err	thru xb0-99-exit
	move return-code		to  buffer-record-count
	move "N"			to  max-nbr-records-exceeded
        move "ERRORSTOP"		to  buffer-doctor-rec(1)
	move 0				to  return-code
        go to ab1-99-exit.
*   endif

    perform aa1-initialization		thru aa1-99-exit. 

*   CASE
    if request-doctor 
    then
        perform ba0-protocol-doctor
					thru	ba0-99-exit
    else
    if request-contact
    then
	perform da0-protocol-contact
					thru	da0-99-exit
    else
    if request-contact-info
    then
	perform ea0-protocol-contact-info
					thru	ea0-99-exit.
*   endif
*   END_CASE

*   (BE. added to close files)
    perform az0-end-of-job	thru	az0-99-exit.

ab1-99-exit.

    inspect buffer-doctor-records replacing all low-values by zeros.

    if doc-nbr of doc-mstr = "667"
    then
	next sentence.
*   endif

*    if doc-nbr of doc-mstr = "020"
*    then
*	move "N" to max-nbr-records-exceeded.
**   endif

**    add 1 to brad.
**    display brad " = " doc-nbr of doc-mstr " : " max-nbr-records-exceeded.
  
    if doc-eof
    then
	move "N" to max-nbr-records-exceeded.
*   endif

    exit program.



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
 
    open output	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		error-rpt-a.
 
* need to initialize individually for c/cobol compile
    move 0				to	ctr-doctors-read
					        ctr-contacts-read
					        ctr-contacts-info-read
						ctr-error-rpt-writes
						ctr-warnings-rpt-writes
						ctr-rpt-a-pages
    						ctr-rpt-b-pages
    						ctr-rpt-c-pages
    						ctr-reject
    						ctr-warning
 						ctr-update.

    perform aa2-init-buffer		thru aa2-99-exit
	varying ss from 1
		   by   1
	  until ss >  MAX-DOC-RECS-IN-BUFFER.

aa0-99-exit. 
    exit. 



aa1-initialization.

    open input  doc-mstr
		doc-extra-mstr
		dept-mstr
		company-mstr
		contacts-mstr
		contacts-info-mstr.

    open i-o	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		error-rpt-a.


    move spaces				to buffer-record-count.
    move spaces				to  max-nbr-records-exceeded.
    move spaces 			to buffer-data-records.
    move spaces                         to buffer-doctor-records.

aa1-99-exit.
    exit.


aa2-init-buffer.
    move spaces 			to buffer-doctor-rec(ss).
aa2-99-exit.
    exit.


az0-end-of-job. 
 
    close 
	  doc-mstr 
	  doc-extra-mstr
	  dept-mstr
	  company-mstr
	  contacts-mstr
	  contacts-info-mstr
	  audit-file-a 
	  audit-file-b 
          audit-file-c
	  error-rpt-a. 
 
az0-99-exit. 
    exit. 


da0-protocol-contact.

    move key-value1			to	doc-nbr of contacts-mstr-rec.
    perform yc0-read-doc-mstr-by-rma-id	thru	yc0-99-exit.	
    if not  matching-doc-exists
    then
        move invalid-no-such-doctor	to      return-code
        perform za0-error-processing    thru    za0-99-exit
	go to da0-99-exit.
*   endif

*   (search for as many matching doctor contacts as can fit into buffer)
 
     perform yp0-read-next-contacts-rec	thru yp0-99-exit
     until    matching-contact-not-exists
     	   or contact-eof
           or ctr-contacts-read = MAX-CONTACTS-RECS-IN-BUFFER.

da0-99-exit.
    exit.



ea0-protocol-contact-info.

    move key-value1			to	doc-nbr of contacts-mstr-rec.
    perform yc0-read-doc-mstr-by-rma-id	thru	yc0-99-exit.	
    if not  matching-doc-exists
    then
        move invalid-no-such-doctor	to      return-code
        perform za0-error-processing    thru    za0-99-exit
	go to da0-99-exit.
*   endif


ea0-99-exit.
    exit.


ba0-protocol-doctor.

    move 0				to  ctr-doctors-read
					    ctr-contacts-read
					    ctr-contacts-info-read.
    perform ha0-doctor-read-first	thru ha0-99-exit.

*   (if not searching on a key that brings back 1 rec, then search for more matches)
    if      matching-doc-exists
	and not doc-eof
	and (   search-by-name
	     or search-by-company
	     or search-by-dept
	    )
    then
*	(search for as many matching doctors as can fit into buffer)
*       CASE
	if search-by-name
	then
	    perform ye0-read-next-doc-mstr thru ye0-99-exit
	        until    matching-doc-not-exists
		      or doc-eof
		      or ctr-doctors-read = MAX-DOC-RECS-IN-BUFFER
	else
	if search-by-company
	then
	    perform yf0-read-doc-mstr-by-cmpy	thru yf0-99-exit
	        until    matching-doc-not-exists
		      or doc-eof
		      or ctr-doctors-read = MAX-DOC-RECS-IN-BUFFER.
*       END CASE
*   endif

*   
* TODO - indicate more records exist matching criteria but a 2nd request
*	must be made for them)

    move ctr-doctors-read	to	buffer-record-count.
    perform xc0-write-audit-nbr-pats	
				thru	xc0-99-exit.

    if ctr-doctors-read = MAX-DOC-RECS-IN-BUFFER 
    then
	move "Y"		to	max-nbr-records-exceeded
    else
	move "N"		to	max-nbr-records-exceeded.
*   endif

    move 0			to	return-code.

ba0-99-exit.
******* TESTING ONLY testing only     move "N"		to	max-nbr-records-exceeded.
    exit.
* max-nbr-records-exceeded



ha0-doctor-read-first.

    move 0                              to ctr-doctors-read.

    move spaces                    	to hold-doc-rma-nbr
					   hold-doc-ohip-nbr
					   hold-doc-name,

*   (if seaching by a key that can return multiple matching records then
*    check for a doctor nbr to 'start after' before trying to find further
*    matching records)
    if     (   search-by-name
*            or search-by-company
	   )
       and key-value3 <> "000"
    then
        move key-value3				to	doc-nbr of doc-mstr
	perform yi0-read-doc-appox		thru	yi0-99-exit
	move "000"				to 	key-value3
	move 0					to 	ctr-doctors-read.
*   endif

*   CASE 
    if search-by-rma-id
    then 
	move key-value1-rma-nbr    		to hold-doc-rma-nbr
	move hold-doc-rma-nbr			to doc-nbr of doc-mstr
        perform yc0-read-doc-mstr-by-rma-id  	thru yc0-99-exit 
    else 
        if search-by-ohip-nbr
        then 
            move key-value1 			to hold-doc-ohip-nbr
 	    move hold-doc-ohip-nbr		to doc-ohip-nbr of doc-mstr
            perform yd0-read-doc-mstr-by-ohip
					 	thru yd0-99-exit
	else
	    if search-by-name
	    then
        	perform xx0-find-length-name-search 
						thru xx0-99-exit
*		(currently only the first 6 characters of last name and
*		 first 3 characters of the first name can be searched on)
        	move key-value1                 to doc-name
        	move key-value2                 to doc-inits
		perform yb0-read-1st-doc-mstr-by-name   
						thru yb0-99-exit
	    else
*		assume search-by-company
    		    move key-value3 		to   doc-nbr of doc-mstr-rec
		    perform yf0-read-doc-mstr-by-cmpy   
						thru yf0-99-exit.
*		endif
*	    endif
*       endif 
*   endif 
*   END-CASE

ha0-99-exit.
    exit.
 



xa0-write-audit-request.
    perform xz0-build-time-stamp-fields		thru xz0-99-exit.
    move l0-time-stamp				to	l1-time-stamp.

    move request-type				to	l1-request-type.
    move request-action				to	l1-action.
    move request-company			to	l1-location.
    move request-sex				to	l1-sex.
    move request-dept				to	l1-dept.
    move key-type				to	l1-key-type.
    move key-value1				to	l1-key-value1.
    move key-value2				to	l1-key-value2.
    move key-value3				to	l1-key-value3.

    write rpt-rec-a from l1-line after advancing 1 line.
    
xa0-99-exit. 
    exit. 
 
xb0-write-audit-err.
    move spaces					to	line-error.
    perform xz0-build-time-stamp-fields		thru	xz0-99-exit.

    move l0-time-stamp				to	le-time-stamp.
    move return-code				to	le-error-code.
    
    write rpt-rec-a from line-error after advancing 1 line.

xb0-99-exit.
    exit.

 
xc0-write-audit-nbr-pats.

    write rpt-rec-a from  ctr-doctors-read after advancing 1 line.

xc0-99-exit.
    exit.


yb0-read-1st-doc-mstr-by-name.

    move "Y"                            to matching-doc-flag.
    move "N"                            to doc-eof-flag.

    start doc-mstr key is greater than or equal to doc-name-soundex
        invalid key
            move "N"                    to matching-doc-flag
            move "Y"                    to doc-eof-flag
            go to yb0-99-exit.

    read doc-mstr next.


*   (check if doctor name found matches search criteria - note that
*       the user name have entered only part of the acronym)
    move key-value1    (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2    (1:length-first-name-search) to test-string-1-first-name.
    move doc-name      (1:length-last-name-search)  to test-string-2-last-name.
    move doc-inits     (1:length-first-name-search) to test-string-2-first-name.

    if   test-string-1-last-name  <> test-string-2-last-name
      or test-string-1-first-name <  test-string-2-first-name
    then
        move "N"                        to matching-doc-flag
    else
* b.e. 2005/jan/26
        move "Y"                        to matching-doc-flag
	add 1                       	to ctr-doctors-read
	perform yj0-move-doc-rec-to-buffer
					thru yj0-99-exit.
*   endif

yb0-99-exit.
    exit.


yc0-read-doc-mstr-by-rma-id. 
 
    move "Y"				to matching-doc-flag. 
 
    read doc-mstr key is doc-nbr of doc-mstr
	invalid key 
	    move "N"			to matching-doc-flag 
	    go to yc0-99-exit. 

    add 1			       to ctr-doctors-read
    perform yj0-move-doc-rec-to-buffer
					thru yj0-99-exit.
yc0-99-exit. 
    exit. 
 
 
yd0-read-doc-mstr-by-ohip.
 
    move "Y"				to matching-doc-flag. 

    read doc-mstr key is doc-ohip-nbr of doc-mstr
	invalid key 
	    move "N"			to matching-doc-flag 
	    go to yd0-99-exit. 

    add 1			       	to ctr-doctors-read
    perform yj0-move-doc-rec-to-buffer
					thru yj0-99-exit.
 
yd0-99-exit. 
    exit. 
 
 
ye0-read-next-doc-mstr. 
 
    move "Y" 					to matching-doc-flag. 
 
    read doc-mstr next
	at end 
	    move "N"				to matching-doc-flag 
	    go to ye0-99-exit. 

*   (check if acronym of doctor found matches search criteria)
    move key-value1 (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2 (1:length-first-name-search) to test-string-1-first-name.
    move doc-name   (1:length-last-name-search)  to test-string-2-last-name.
    move doc-inits  (1:length-first-name-search) to test-string-2-first-name.

    if   test-string-1-last-name  <> test-string-2-last-name
    then
        move "N"                        to matching-doc-flag
    else
       if  test-string-1-first-name =  test-string-2-first-name
       then
    	   add 1		  	to ctr-doctors-read
	   perform yj0-move-doc-rec-to-buffer
					thru yj0-99-exit.
*      else
*   	   (last name matches but first doesn't - skip this patient but 
*	    continue reading doctor master until surname changes)
*      endif
*   endif
 
ye0-99-exit. 
    exit. 


yf0-read-doc-mstr-by-cmpy.

    move "Y"                            to matching-doc-flag.

*    start doc-mstr key is greater than or equal to doc-nbr of doc-mstr
    start doc-mstr key is greater than             doc-nbr of doc-mstr
        invalid key
            move "N"                    to matching-doc-flag
            move "Y"                    to doc-eof-flag
            go to yf0-99-exit.

    read doc-mstr next.

    perform yy0-apply-company-search-parms
					thru yy0-99-exit.
    if  matching-doc-exists 
    then
        add 1				to ctr-doctors-read
        perform yj0-move-doc-rec-to-buffer
					thru yj0-99-exit
	if     not ctr-doctors-read = MAX-DOC-RECS-IN-BUFFER
	   and not doc-eof
        then
	    go to yf0-read-doc-mstr-by-cmpy
	else
	    go to yf0-99-exit
    else
	if not doc-eof
	    go to yf0-read-doc-mstr-by-cmpy
	else
	    go to yf0-99-exit.
*	endif
*   endif

yf0-99-exit.
    exit.


yg0-read-dept-mstr.

    move 'Y'                                    to flag-status.
    read dept-mstr
        invalid key
            move 'N'                            to flag-status
            go to yg0-99-exit.

*   add 1                                       to ctr-dept-mstr-reads.

yg0-99-exit.
    exit.


yh0-read-company-mstr.

    move 'Y'                                    to flag-status.
    read company-mstr
        invalid key
            move 'N'                            to flag-status
            go to yh0-99-exit.

*    add 1                                       to ctr-dept-mstr-reads.

yh0-99-exit.
    exit.


yi0-read-doc-appox.
 
    move "Y"				to matching-doc-flag. 
    move "N"				to doc-eof-flag. 

    start doc-mstr key is greater than             doc-nbr of doc-mstr
        invalid key
            move "N"                    to matching-doc-flag
            move "Y"                    to doc-eof-flag
            go to yi0-99-exit.

    read doc-mstr next.

yi0-99-exit.
    exit.



yj0-move-doc-rec-to-buffer.

    move doc-mstr-rec           	to buffer-doctor-rec(ctr-doctors-read).
    move company-nbr of company-mstr	to buff-doc-company(ctr-doctors-read).

*   (as temp measure get basic doctor contact and their info and add
*    to buffer while reading doctor)

    move doc-nbr of doc-mstr		to doc-nbr of doc-extra-mstr-rec.
    perform yr0-read-doc-extra-mstr	thru yr0-99-exit.
    if not-ok
    then
	move const-question-marks	to buffer-doctor-rec-extended
							     (ctr-doctors-read)
    else
 	perform yj1-move-doc-extra-data	thru yj1-99-exit.
*   endif

    move doc-nbr of doc-mstr		to doc-nbr of contacts-mstr-rec.
    move "D"				to contacts-type of contacts-mstr-rec.
    perform yk0-read-contact-rec	thru yk0-99-exit.
    add 1 				to ctr-contacts-read.
    if matching-contact-exists 
    then
	move ss-doc			to ss-contact
	perform yj2-move-contact-data	thru yj2-99-exit
    else
	move const-question-marks	to contact-info-occurs(
							ctr-doctors-read,
							ss-doc).
*   endif

    move doc-nbr of doc-mstr		to doc-nbr of contacts-info-mstr-rec.
    move "D"				to contacts-type 
						   of contacts-info-mstr-rec.
    move "H"				to contacts-location
						   of contacts-info-mstr-rec.
    perform yl0-read-contact-info-rec	thru yl0-99-exit.
    add 1                               to ctr-contacts-info-read.
    if matching-contact-info-exists 
    then
	move ss-doc			to	ss-contact
	move ss-home			to	ss-contact-info
	perform yj3-move-contact-info-data	
					thru yj3-99-exit
    else
	move const-question-marks	to home-office-contact-info(
							ctr-doctors-read,
							ss-doc,
							ss-home).
*   endif

    move "O"				to contacts-location
						   of contacts-info-mstr-rec.
    perform yl0-read-contact-info-rec	thru yl0-99-exit.
    add 1 				to ctr-contacts-read
    if matching-contact-info-exists 
    then
	move ss-doc			to	ss-contact
	move ss-office			to	ss-contact-info
	perform yj3-move-contact-info-data	
					thru yj3-99-exit
    else
	move const-question-marks	to home-office-contact-info(
							ctr-doctors-read,
							ss-doc,
							ss-office).
*   endif

*   TODO
*   GET SECRETARY DATA - may need to get someone else other than "S"ecrtary
    move "S"				to contacts-type of contacts-mstr-rec.
    perform yk0-read-contact-rec	thru yk0-99-exit.
    if matching-contact-exists
    then
	move ss-secretary		to ss-contact
	perform yj2-move-contact-data	thru yj2-99-exit
    else
	move const-question-marks	to contact-info-occurs(
							ctr-doctors-read,
							ss-secretary).
*   endif

    move "S"				to contacts-type 
						   of contacts-info-mstr-rec.
    move "H"				to contacts-location
						   of contacts-info-mstr-rec.
    perform yl0-read-contact-info-rec	thru yl0-99-exit.
    if matching-contact-info-exists 
    then
	move ss-secretary		to	ss-contact
	move ss-home			to	ss-contact-info
	perform yj3-move-contact-info-data	
					thru yj3-99-exit
    else
	move const-question-marks	to home-office-contact-info(
							ctr-doctors-read,
							ss-secretary,
							ss-home).
*   endif

    move "O"				to contacts-location
						   of contacts-info-mstr-rec.
    perform yl0-read-contact-info-rec	thru yl0-99-exit.
    if matching-contact-info-exists 
    then
	move ss-secretary		to	ss-contact
	move ss-office			to	ss-contact-info
	perform yj3-move-contact-info-data	
					thru yj3-99-exit
     else
	move const-question-marks	to home-office-contact-info(
							ctr-doctors-read,
							ss-secretary,
							ss-office).
*   endif

yj0-99-exit.
    exit


yj1-move-doc-extra-data.

    move billing-via-paper-flag    	to	buff-billing-via-paper
							     (ctr-doctors-read).
    move billing-via-diskette-flag 	to	buff-billing-via-diskette
							     (ctr-doctors-read).
    move billing-via-web-test-flag 	to	buff-billing-via-web-test
							     (ctr-doctors-read).
    move billing-via-web-live-flag 	to	buff-billing-via-web-live
							     (ctr-doctors-read).
    move date-start-diskette       	to	buff-date-start-diskette
							     (ctr-doctors-read).
    move date-start-paper          	to	buff-date-start-paper
							     (ctr-doctors-read).
    move date-start-web-live       	to	buff-date-start-web-live
							     (ctr-doctors-read).
    move date-start-web-test       	to	buff-date-start-web-test
							     (ctr-doctors-read).
    move leave-description         	to	buff-leave-description
							     (ctr-doctors-read).
    move leave-date-start          	to	buff-leave-date-start
							     (ctr-doctors-read).
    move leave-date-end            	to	buff-leave-date-end
							     (ctr-doctors-read).
    move web-user-revenue-only-flag	to	buff-web-user-revenue-only
							     (ctr-doctors-read).
    move manager-flag              	to	buff-manager (ctr-doctors-read).
    move chair-flag                	to	buff-chair   (ctr-doctors-read).
    move abe-flag    			to	buff-abe-flag
							     (ctr-doctors-read).
    move cpso-nbr                  	to	buff-cpso-nbr(ctr-doctors-read).
    move cmpa-nbr                  	to	buff-cmpa-nbr(ctr-doctors-read).
    move oma-nbr                   	to	buff-oma-nbr (ctr-doctors-read).
    move cfpc-nbr                  	to	buff-cfpc-nbr(ctr-doctors-read).
    move rcpsc-nbr                 	to	buff-rcpsc-nbr
							     (ctr-doctors-read).
    move doc-med-prof-corp         	to	buff-doc-med-prof-corp
							     (ctr-doctors-read).

yj1-99-exit.
    exit.


yj2-move-contact-data.

    move contacts-surname		to buff-surname (ctr-doctors-read,
							 ss-contact).
    move contacts-given-names		to buff-given-names
							(ctr-doctors-read,
							 ss-contact).
    move contacts-inits  		to buff-inits   (ctr-doctors-read,
							 ss-contact).
    move contacts-title			to buff-title   (ctr-doctors-read,
							 ss-contact).
    move contacts-sex 			to buff-sex 	(ctr-doctors-read,
							 ss-contact).
    move contacts-billing-entry-flag	to buff-billing-entry-flag
							(ctr-doctors-read,
							 ss-contact).
    move username-logon-web		to buff-username-logon-web
							(ctr-doctors-read,
							 ss-contact).
yj2-99-exit.
    exit.

yj3-move-contact-info-data.

    move contacts-addr-1		to buff-addr-1
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-addr-2		to buff-addr-2
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-addr-3		to buff-addr-3 
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-addr-pc		to buff-addr-pc 
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-email-addr		to buff-email-addr
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-phone-nbr		to buff-phone-nbr
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-phone-ext		to buff-phone-ext
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-pager-nbr	 	to buff-pager-nbr
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-cell-nbr 		to buff-cell-nbr
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-fax-nbr  		to buff-fax-nbr
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
    move contacts-newsletter-flag	to buff-newsletter
						(ctr-contacts-info-read,
						 ss-contact,
						 ss-contact-info).
yj3-99-exit.
    exit.


yk0-read-contact-rec.
 
    move "Y"				to matching-contact-flag. 
    move "N"				to contact-eof-flag. 

    move " "				to filler-must-be-blank
						 of contacts-mstr-rec.

    read contacts-mstr key is  contacts-key of contacts-mstr
        invalid key
            move "N"                    to matching-contact-flag
            move "Y"                    to contact-eof-flag
            go to yk0-99-exit.

yk0-99-exit.
    exit.


yl0-read-contact-info-rec.
 
    move "Y"				to matching-contact-info-flag. 
    move "N"				to contact-info-eof-flag. 

    move " "				to filler-must-be-blank
						 of contacts-info-mstr-rec.

    read contacts-info-mstr key is  contacts-info-key of contacts-info-mstr
        invalid key
            move "N"                    to matching-contact-info-flag
            move "Y"                    to contact-info-eof-flag
            go to yl0-99-exit.

yl0-99-exit.
    exit.

ym0-move-contact-2-buffer.
    move contacts-mstr-rec	to buffer-contact-rec(ctr-contacts-read).
ym0-99-exit.
    exit

yn0-move-contact-info-2-buffer.
    move contacts-info-mstr-rec	to buffer-contact-info-rec(ctr-contacts-info-read).
yn0-99-exit.
    exit

yp0-read-next-contacts-rec.
 
    read contacts-mstr next
        at end
            move "N"                    to matching-contact-flag
            move "Y"                    to contact-eof-flag
            go to yp0-99-exit.

    add 1 				to ctr-contacts-read.

yp0-99-exit.
    exit.

yr0-read-doc-extra-mstr.

    move 'Y'                             to flag-status.
    read doc-extra-mstr
        invalid key
            move 'N'                     to flag-status
            go to yr0-99-exit.

*   add 1                                 to ctr-doc-extra-mstr-reads.

yr0-99-exit.
    exit.


yy0-apply-company-search-parms.

    move doc-dept			to   dept-nbr of dept-mstr-rec.
    perform yg0-read-dept-mstr		thru yg0-99-exit.
    if ok 
    then
	move dept-company		to   company-nbr
	perform yh0-read-company-mstr	thru yh0-99-exit
	if ok 
 	then
	    if     (   request-company = company-nbr
		    or request-company = "a"
		    or request-company = " a"
		    or request-company = "a0"
		    or request-company = "0a"
		    or request-company = "00"
		   )
	       and (   request-dept = dept-nbr
		    or request-dept = "a"
		    or request-dept = " a"
		    or request-dept = "a0"
		    or request-dept = "0a"
		    or request-dept = "00"
		   )
	    then
	        move "Y"			to	matching-doc-flag
	    else
	        move "N"			to	matching-doc-flag
	else
*	    (corrupt dept has invalid company)
	    move "N"			to	matching-doc-flag
    else
*	(corrupt doctor has invalid dept)	
	move "N"			to	matching-doc-flag.
*   endif

yy0-99-exit.
    exit.


yz0-skip-doctors.

*  (don't immediately skip records unless one in buffer indicates to do so)

*   (check if acronym of patient could match search criteria)
    move key-value1    (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2    (1:length-first-name-search) to test-string-1-first-name.
    move doc-name      (1:length-last-name-search)  to test-string-2-last-name.
    move doc-inits     (1:length-first-name-search) to test-string-2-first-name.

*   (since the system is reading sequentially through patients keyed on
*    patient acronym (last6 + first3) only check the last name for setting
*   'end of matching patients' flag)

    if   test-string-1-last-name  <  test-string-2-last-name
      or test-string-1-first-name <= test-string-2-first-name
      or doc-eof
    then
        go to yz0-99-exit.
*   endif

    read doc-mstr next
        at end
            move "N"                         to matching-doc-flag
                                                doc-eof-flag
            go to yz0-99-exit.

    go to  yz0-skip-doctors.

yz0-99-exit.
    exit.
 
 
 
    copy "y2k_default_sysdate_century.rtn".

 
xx0-find-length-name-search.

* NOTE NOTE NOTE NOTE
* currently the data is sorted on patient acronym which is 6 chars of last
* name plus 3 of first name. Therefore we can only be certain of the
* sort sequence within this range of characters. The code below
* thus never makes length of last name / first name greater than
* 6 / 3 respectively THIS CAN BE CHANGED WHEN FULL NAME IS INDEXED
*
*   (check length of submitted names to determine length of acronym to 
*    be tested for match)

*   CASE
    if key-value1(25:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(24:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(23:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(22:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(21:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(20:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(19:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(18:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(17:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(16:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(15:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(14:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(13:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(12:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(11:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1(10:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1( 9:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1( 8:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1( 7:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1( 6:1) <> " "
    then
	move  6			to length-last-name-search 
    else
    if key-value1( 5:1) <> " "
    then
	move  5			to length-last-name-search 
    else
    if key-value1( 4:1) <> " "
    then
	move  4			to length-last-name-search 
    else
    if key-value1( 3:1) <> " "
    then
	move  3			to length-last-name-search 
    else
    if key-value1( 2:1) <> " "
    then
	move  2			to length-last-name-search 
    else
    if key-value1( 1:1) <> " "
    then
	move  1			to length-last-name-search 
    else
	move  0			to length-last-name-search.
*   ENDCASE


*   CASE
    if key-value2(15:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2(14:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2(13:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2(12:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2(11:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2(10:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 9:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 8:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 7:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 6:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 5:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 4:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 3:1) <> " "
    then
	move  3			to length-first-name-search 
    else
    if key-value2( 2:1) <> " "
    then
	move  2			to length-first-name-search 
    else
    if key-value2( 1:1) <> " "
    then
	move  1			to length-first-name-search 
    else
	move  0			to length-first-name-search.
*   ENDCASE


xx0-99-exit.
    exit.

xz0-build-time-stamp-fields.
    move  spaces 				to	l0-time-stamp. 
    move run-yy					to	l0-yy.
    move run-mm					to	l0-mm.
    move run-dd					to	l0-dd.
    move "/"					to	l0-slash1
						  	l0-slash2.

    move ":"					to	l0-colon1
							l0-colon2.
    move run-hrs				to	l0-hrs.
    move run-min				to	l0-min.
    move run-sec				to	l0-sec.  
xz0-99-exit.
    exit.


za0-error-processing.

   move spaces					to err-rpt-rec-a.
   move run-date				to err-date.
   move run-time				to err-time.
   move return-code				to err-code.

   move request					to err-data-1.

   write err-rpt-rec-a.

za0-99-exit.
    exit.

