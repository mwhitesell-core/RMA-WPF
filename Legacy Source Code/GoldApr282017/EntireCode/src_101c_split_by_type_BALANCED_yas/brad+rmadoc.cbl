program-id.     rmadoc. 
author.         dyad infoSys. 
installation.   regional medical associates. 
date-written.   93/sep/20. 
date-compiled. 
security. 
* 
*    FILES      : called from rma.c socket program
*		: f020   - doctor master

*    modification history
*     DATE    WHO      	WHY 
* 2005/jan/03 b.e.	- original (cloned from cpirma5.cbl)
* 2005/jan/17 b.e.	- increase 1st 2 key values passed in 'request'
*			  from 20 to 30 characters each
*

environment division. 
input-output section. 
file-control. 
* 
* 
    copy "f020_doctor_mstr.slr".
*
    copy "f027_contacts_mstr.slr".
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
    copy "f027_contacts_mstr.fd".
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

* WARNING - the sizes below must match:
*	1) linkage section of this program (buffer-doctor-records)
*	2) sizes in rma.c
* 	3) and the cpi_rma.dll(web component)'s CONST MAX_LENGTH_RECORD

78  REQUEST-LENGTH	        value 726.

******************************************************************************
*  WARNING - must keep record same length as "doc-mstr-rec" of f010 FD
*  and keep in sync with 'buffer-doctor-records' definition in 'linkage' section
******************************************************************************
78  MAX-DOC-RECS-IN-BUFFER 	value 10.

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
*
77  eof-dept-mstr                               pic x   value "N".
77  eof-compnay-mstr                            pic x   value "N".
77  status-cobol-dept-mstr                      pic x(2) value zero.
77  status-cobol-company-mstr                   pic x(2) value zero.
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
01  doc-eof-flag                           	pic x. 
    88  doc-eof                  			value "Y". 
    88  doc-not-eof            				value "N". 
 
*   (COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES.) 
 
01  counters. 
    05  ctr-doctors-read			pic 9(7).
    05  ctr-doc-mstr-exists			pic 9(7).
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
    05  l1-key-value3                           pic 9(7).
 

linkage section.

01  stringLength		pic x(4) comp-5.

* requestType      - '2' Webstar Doctor protocol
* action           - 'f'ind/'a'dd/'u'pdate
* company(location)- 'a'll / 'r'ma  / rma 'i'nc 
* dept             - '00'(all) / 2 digit department number 
* sex              - 'a'll / 'm'ale / 'f'emale
*
*                  NOTE: the contents of keyValues1/2 depend upon key-type
* key-type         - 'r'ma id/'o'hip nbr/'n'ame
* key-value1       - doctor's rma nbr/ohip nbr or optionally
*                           a Surname
* key-value2       - blank or optionally a Firstname
* key-value3       - blank or optionally number of doctors to skip
*			before continuing to read new records

01  request.
    10  request-type		pic x(01).
    10  request-data		pic x(99).
    10  request-r  redefines  request-data.
	20  request-action	pic x(01).
	20  key-type		pic x(01).
	    88 search-by-company 		value "c".
	    88 search-by-dept	 		value "d".
	    88 search-by-name			value "n".
	    88 search-by-ohip-nbr		value "o".
	    88 search-by-rma-id			value "i".
	20  request-company	pic x(02).
	20  request-dept   	pic x(02).
	20  request-sex				pic x(01).
	    88 searching-for-male		value "m".
	    88 searching-for-female		value "f".
	    88 searching-for-both-sex		value "a".
*	    (key length = 24 to match length of surname)
	20  key-value1.
	    30 key-value1-rma-nbr
				pic x(3).
	    30 key-value1-remainder
				pic x(21).
	20  key-value1-r redefines key-value1.
	    30 key-value1-ohip-nbr
				pic x(6).
	    30 filler		pic x(18).
*	    (key length = 24 to match length of given name)
	20  key-value2		pic x(24).
	20  key-value3		pic 9(07).
	20  x-filler		pic x(21).

******************************************************************************
*  WARNING - must keep record same length as "doc-mstr-rec" of f010 FD
*  and keep in sync with 'MAX-DOC-RECS-IN-BUFFER' definition and other 
*  associated fields in 'working storage' section
******************************************************************************
*  formula: 'doc rec size' * MAX-DOC-RECS-IN-BUFFER + 8 bytes (control info)
*                695 * 10 = 6950 + 8 = 6958
 
01 buffer-doctor-records	pic x(6958).
01 buffer-doctor-records-r redefines buffer-doctor-records.
* (this counter is used both as a 'return' value telling the calling program
*  how many records were returned in the buffer-doctor-records but can also
*  be used by the calling program to tell this program to 'skip over' 
*  'buffer-record-record' number of records. This can be used to 'page thru'
*  matching records where the number of records exceeds the maximum buffer
*  size)
   10  buffer-record-count		pic x(7).
   10  max-nbr-records-exceeded		pic x(1).
   10  buffer-doctor-records-occurs occurs MAX-DOC-RECS-IN-BUFFER.
	20  buffer-doctor-rec	pic x(695).

01 next-item		pic x(4) comp-5.

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

*   (only one request type ('2') valid at this time)
    if request-type <> "2"
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
    inspect key-value3 replacing all low-values by zeros.
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

    move 0				to  ctr-doctors-read.
    perform ca0-doctor-read-first	thru ca0-99-exit.

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
	    perform yb0-10-read-next-doc-mstr thru yb0-10-99-exit
	        until    matching-doc-not-exists
		      or doc-eof
		      or ctr-doctors-read = MAX-DOC-RECS-IN-BUFFER
	else
	if search-by-company
	then
*	    (previous loop has read all the records that need to be skipped
*	     so set value to zero)
	    perform ye0-read-doc-mstr-by-cmpy	thru ye0-99-exit
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

*   (BE. added to close files)
    perform az0-end-of-job	thru	az0-99-exit.

ab1-99-exit.
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
						ctr-doc-mstr-exists
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
		dept-mstr
		company-mstr.

    open i-o	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		error-rpt-a.
                
    move spaces                         to buffer-doctor-records.

aa1-99-exit.
    exit.

aa2-init-buffer.
    move spaces 			to buffer-doctor-rec(ss).
aa2-99-exit.
    exit.

ca0-doctor-read-first.

    move 0                              to ctr-doctors-read.

    move spaces                    	to hold-doc-rma-nbr
					   hold-doc-ohip-nbr
					   hold-doc-name,

*   (if seaching by name and the user is continuing to scroll through 
*    matching doctors use the key-value3 as the number of matches to 
*    skip by before continuing to read new records)

*   CASE 
    if     search-by-name
       and key-value3 <> 0
    then
*!        perform xx0-find-length-name-search thru xx0-99-exit
*	(currently only the first 6 characters of last name and
*	 first 3 characters of the first name can be searched on)
        move key-value1                 to doc-name
        move key-value2                 to doc-inits 
        perform yb0-read-1st-doc-mstr-by-name   thru yb0-99-exit
*       (skip the number requested - 1st record read in yb0 above)
        perform yb0-10-read-next-doc-mstr thru yb0-10-99-exit
            until    matching-doc-not-exists
		  or doc-eof
                  or ctr-doctors-read = key-value3 - 1
	move 0				to key-value3
				 	   ctr-doctors-read
*       (search for 1st matching name)
        perform yb0-10-read-next-doc-mstr thru yb0-10-99-exit
            until    matching-doc-not-exists
		  or doc-eof
                  or ctr-doctors-read = 1
    else

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
    		    move "000"			to doc-nbr of doc-mstr-rec
		    perform ye0-read-doc-mstr-by-cmpy   
						thru ye0-99-exit.
*		endif
*	    endif
*       endif 
*   endif 
*   END-CASE

ca0-99-exit.
    exit.
 

az0-end-of-job. 
 
    close 
	  doc-mstr 
	  dept-mstr
	  company-mstr
	  audit-file-a 
	  audit-file-b 
          audit-file-c
	  error-rpt-a. 
 
az0-99-exit. 
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
*   (ensure key-value3 is entirely numeric values)
    inspect key-value3 replacing all low-values by zeros.
    inspect key-value3 replacing all spaces     by zeros.
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
 
    move "Y"				to matching-doc-flag. 
    move "N"				to doc-eof-flag. 

    start doc-mstr key is greater than or equal to doc-name-soundex
        invalid key
	    move "N"			to matching-doc-flag 
	    move "Y"			to doc-eof-flag
	    go to yb0-99-exit. 

    read doc-mstr next.

*   (check if doctor name found matches search criteria - note that
*	the user name have entered only part of the acronym)
    move key-value1    (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2    (1:length-first-name-search) to test-string-1-first-name.
    move doc-name      (1:length-last-name-search)  to test-string-2-last-name.
    move doc-inits     (1:length-first-name-search) to test-string-2-first-name.

    if   test-string-1-last-name  <> test-string-2-last-name
      or test-string-1-first-name <  test-string-2-first-name
    then
	move "N"			to matching-doc-flag
    else
*	(if key-value3 is not zero then we are skipping records so
*	 don't count save them in buffer)
	if key-value3 = 0 
	then
	    add 1			to ctr-doctors-read
	    move doc-mstr-rec		to buffer-doctor-rec(ctr-doctors-read).
*	endif
*   endif
 
yb0-99-exit. 
    exit. 


yc0-read-doc-mstr-by-rma-id. 
 
    move "Y"				to matching-doc-flag. 
 
    read doc-mstr key is doc-nbr of doc-mstr
	invalid key 
	    move "N"			to matching-doc-flag 
	    go to yc0-99-exit. 

*    (if key-value3 is not zero then we are skipping records so
*     don't save them in buffer)
    add 1			       to ctr-doctors-read
    if key-value3 = 0 
    then
	move doc-mstr-rec       to buffer-doctor-rec(ctr-doctors-read).
*    endif
 
yc0-99-exit. 
    exit. 
 
 
yd0-read-doc-mstr-by-ohip.
 
    move "Y"				to matching-doc-flag. 

    read doc-mstr key is doc-ohip-nbr of doc-mstr
	invalid key 
	    move "N"			to matching-doc-flag 
	    go to yd0-99-exit. 

*    (if key-value3 is not zero then we are skipping records so
*     don't save them in buffer)
    add 1			       to ctr-doctors-read
    if key-value3 = 0 
    then
	move doc-mstr-rec       to buffer-doctor-rec(ctr-doctors-read).
*    endif
 
yd0-99-exit. 
    exit. 
 
 
yb0-10-read-next-doc-mstr. 
 
    move "Y" 					to matching-doc-flag. 
 
    read doc-mstr next
	at end 
	    move "N"				to matching-doc-flag 
	    go to yb0-10-99-exit. 

*   (check if acronym of doctor found matches search criteria)
    move key-value1        (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2        (1:length-first-name-search) to test-string-1-first-name.
    move doc-name   (1:length-last-name-search)  to test-string-2-last-name.
    move doc-inits  (1:length-first-name-search) to test-string-2-first-name.

    if   test-string-1-last-name  <> test-string-2-last-name
    then
        move "N"                        to matching-doc-flag
    else
       if  test-string-1-first-name =  test-string-2-first-name
       then
*	   (if key-value3 is not zero then we are skipping records so
*	   don't save them in buffer)
    	   add 1			       to ctr-doctors-read
	   if key-value3 = 0 
	   then
	       move doc-mstr-rec       to buffer-doctor-rec(ctr-doctors-read).
*	   endif
*      else
*   	   (last name matches but first doesn't - skip this patient but 
*	    continue reading doctor master until surname changes)
*      endif
*   endif
 
yb0-10-99-exit. 
    exit. 

ye0-read-doc-mstr-by-cmpy.

    move "Y"                            to matching-doc-flag.

*    start doc-mstr key is greater than or equal to doc-nbr of doc-mstr
    start doc-mstr key is greater than             doc-nbr of doc-mstr
        invalid key
            move "N"                    to matching-doc-flag
            move "Y"                    to doc-eof-flag
            go to yb0-99-exit.

    read doc-mstr next.

    perform yy0-apply-company-search-parms
					thru yy0-99-exit.
    if matching-doc-exists 
    then
	next sentence
    else
	go to ye0-read-doc-mstr-by-cmpy.
*   endif


*    (if key-value3 is not zero then we are skipping records so
*     don't save them in buffer)
    if key-value3 = 0
    then
        add 1				to ctr-doctors-read
        move doc-mstr-rec		to buffer-doctor-rec(ctr-doctors-read)
    else
 	subtract 1 from key-value3	giving key-value3.
*   endif

ye0-99-exit.
    exit.


yf0-read-dept-mstr.

    move 'Y'                                    to flag-status.
    read dept-mstr
        invalid key
            move 'N'                            to flag-status
            go to yf0-99-exit.

*   add 1                                       to ctr-dept-mstr-reads.

yf0-99-exit.
    exit.


yg0-read-company-mstr.

    move 'Y'                                    to flag-status.
    read company-mstr
        invalid key
            move 'N'                            to flag-status
            go to xc0-99-exit.

*    add 1                                       to ctr-dept-mstr-reads.

yg0-99-exit.
    exit.

yy0-apply-company-search-parms.

    move doc-dept			to   dept-nbr of dept-mstr-rec.
    perform yf0-read-dept-mstr		thru yf0-99-exit.
    if ok 
    then
	move dept-company		to   company-nbr
	perform yg0-read-company-mstr	thru yg0-99-exit
	if ok 
 	then
	    if     (   request-company = company-nbr
		    or request-company = "a"
		    or request-company = "a0"
		    or request-company = " a"
		    or request-company = "0a"
		   )
	       and (   request-dept = dept-nbr
		    or request-dept = "a"
		    or request-dept = "a0"
		    or request-dept = " a"
		    or request-dept = "0a"
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

