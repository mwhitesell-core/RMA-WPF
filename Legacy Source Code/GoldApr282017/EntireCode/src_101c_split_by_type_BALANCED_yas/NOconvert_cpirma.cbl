identification division. 
program-id.     cpirma. 
author.         dyad infoSys. 
installation.   regional medical associates. 
date-written.   93/sep/20. 
date-compiled. 
security. 
* 
*    FILES      : called from cpi.c socket program
*		: F010   - PATIENT MASTER 
*		: F090   - CONSTANTS MASTER 
*    modification history
* 
*     DATE    WHO      	WHY 
* 2002/mar/08 B.E.	- original (cloned from account.cbl / newu703.cbl)
* 2002/mar/20 B.E.	- added called to az0 to close files "error on
*			  to many files open)
* 2002/may/01 B.E.	- changed access of f010 to use new surname+givenname
*			  index instead of acronym index


environment division. 
input-output section. 
file-control. 
* 
* 
    copy "f010_tp_patient_mstr.slr".
*
*
*
    copy "f010_seq_patient_file.slr".
*
*
*
    copy "f010_new_patient_file.slr".
*
*
*
    copy "f010_new_patient_mstr.slr".
* 
*
*
    copy "f011_pat_mstr_elig_history.slr".
*
*
*
    copy "f085_rejected_claims.slr".
*
*
*
    copy "f086_pat_id.slr".
*
*
*
   copy "f090_constants_mstr.slr".
*
*
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

data division. 
file section. 
* 
    copy "f010_tp_pat_file.fd".
    copy "f010_seq_patient_file.fd".
    copy "f010_new_patient_file.fd".
    copy "f010_patient_mstr.fd".
* 
    copy "f011_pat_mstr_elig_history.fd".
*
    copy "f085_rejected_claims.fd".
*
    copy "f086_pat_id.fd".
*
    copy "f090_constants_mstr.fd".
* 
    copy "f090_const_mstr_rec_5.ws". 
 
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

 
working-storage section.

* WARNING - the sizes below must match cpi.c program definition
78  REQUEST-LENGTH	 value 726.
* BUFFER SIZE = 343 (patient record size) times NBR RECS IN BUFFER
78  MAX-PATS-RECS-IN-BUFFER 	value 10.
78  MAX-PATS-RECS-BUFFERS-SIZE  value 3430.

*  (return-code error codes)
78  GENERAL-PROCESSING-ERROR	value 1.
78  INVALID-REQUEST-TYPE	value 2.
78  INVALID-SEX			value 3.
78  INVALID-KEY-TYPE		value 4.
78  INVALID-KEY-VALUE-1		value 5.
78  INVALID-KEY-VALUE-2		value 6.

77  length-last-name-search		pic 9(2).
77  length-last-name-found		pic 9(2).
77  length-first-name-search		pic 9(2).
77  length-first-name-found		pic 9(2).
01  test-string-1-last-name		pic x(25).
01  test-string-2-last-name		pic x(25).
01  test-string-1-first-name		pic x(15).
01  test-string-2-first-name		pic x(15).

77  test-char				pic x(1).

01  x-key-pat-mstr.
    05  x-key-pat-mstr-dtl.
        10  x-pat-i-key                   pic x.
        10  x-pat-con-nbr                 pic 99.
        10  x-pat-i-nbr                   pic 9(12).
        10  x-filler                      pic x.
01  x-key-pat-mstr-r redefines x-key-pat-mstr.
    05  filler				 pic x(3).
    05  x-key-pat-mstr-test		 pic x(15). 

77  print-file-name-a				pic x(9) 
		                                value "cpi_a". 
77  print-file-name-b				pic x(9) 
		                                value "cpi_b". 
77  print-file-name-c				pic x(9) 
		                                value "cpi_c". 
* 
*   (FEEDBACK AND OCCURRENCE.) 
* 
77  feedback-iconst-mstr 			pic x(4). 
77  feedback-seq-pat-file 			pic x(4). 
77  feedback-new-pat-file 			pic x(4). 
* 
*   (SUBSCRIPTS.) 
* 
77  sub    					pic 99 comp. 
77  err-ind					pic 99 value zero. 
77  space-ctr					pic 99 value zero. 
*
* 
* 
*   (STATUS FILE INDICATORS.) 
* 
01  status-indicators. 
    05  status-file                             pic xx.
    05  status-audit-rpt-a			pic xx    value "0". 
    05  status-audit-rpt-b			pic xx    value "0". 
    05  status-audit-rpt-c			pic xx    value "0". 
    05  status-cobol-iconst-mstr                pic xx    value "0". 
    05  status-cobol-tp-pat-mstr		pic xx    value "0".
    05  status-cobol-seq-pat-file               pic xx    value "0". 
    05  status-cobol-new-pat-file               pic xx    value "0". 
    05  status-cobol-pat-elig-history           pic xx    value "0".
    05  status-cobol-rejected-claims            pic xx    value "0". 
    05  status-corrected-pat			pic xx    value "0". 

    05  status-cobol-pat-mstr.
	10  status-cobol-pat-mstr1		pic x	value "0".
	10  status-cobol-pat-mstr2		pic x	value "0".
    05  status-cobol-pat-mstr-binary 
		redefines status-cobol-pat-mstr pic 9(4) comp.

    05  status-cobol-display.
	10 status-cobol-display1		pic x.
	10 filler				pic x(3).
	10 status-cobol-display2		pic 9(4).

    05  status-cobol-pat-mstr-hc		pic xx    value "0". 
    05  status-cobol-pat-mstr-od		pic xx    value "0". 
    05  status-cobol-pat-mstr-acr		pic xx    value "0". 
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
 
01  ws-phone-no. 
    05  ws-area-code				pic x(3). 
    05  ws-local-phone-no			pic x(7). 
 
01  ws-birth-date. 
* (y2k - auto fix)
*   05  ws-birth-date-yy				pic 99. 
    05  ws-birth-date-yy				pic 9(4). 
    05  ws-birth-date-mm				pic 99. 
    05  ws-birth-date-dd				pic 99. 

    copy "hold_patient_info.ws".
 
01  hold-pat-ikey. 
    05  hold-pat-i-key				pic x. 
    05  hold-iconst-con-nbr			pic 99. 
    05  hold-iconst-nx-ikey			pic 9(12). 
 
***01  HOLD-HEALTH-NO				PIC X(10). 
 
01  matching-pat-flag                           pic x. 
    88  matching-pat-exists                  		value "Y". 
    88  matching-pat-not-exists            		value "N". 
01  pat-eof-flag                           	pic x. 
    88  pat-eof                  			value "Y". 
    88  pat-not-eof            				value "N". 
 
01  pat-change-flag				pic x. 
    88  pat-change					value "Y". 
    88  pat-not-change					value "N". 
* 
01  flag-change-version-cd				pic x. 
    88  version-cd-changed				value "Y". 
    88  version-cd-not-changed				value "N". 
01  flag-old-version-cd				pic x.
    88  old-version-cd-matches				value "Y".
    88  old-version-cd-doesnt-match			value "N".

01 flag-birth-date-change			pic x.
    88  birth-date-changed				value "Y".
    88  birth-date-not-changed				value "N".
01  flag-old-birth-date				pic x.
    88  old-birth-date-matches				value "Y".
    88  old-birth-date-doesnt-match			value "N".

01  flag-1-vs-2-character-ver-cd		pic x.
    88  one-char-ver-cd-vs-2-char   			value "Y".
* 
*   (MISC FLAGS.) 
* 
01  edit-flag                                   pic x. 
    88  valid-record                            value "Y". 
    88  invalid-record                          value "N". 
 
01  province-flag				pic x. 
    88  province-found				value "Y". 
    88  province-not-found  			value "N". 

*   (COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES.) 
 
01  counters. 
    05  ctr-patients-read			pic 9(7).
    05  ctr-seq-pat-file-writes			pic 9(7). 
    05  ctr-new-pat-file-writes			pic 9(7). 
    05  ctr-pat-mstr-writes			pic 9(7). 
    05  ctr-pat-mstr-exists  			pic 9(7). 
    05  ctr-write-corrected-pat			pic 9(7).
    05  ctr-write-pat-elig-hist                 pic 9(7).
    05  ctr-error-rpt-writes			pic 9(7). 
    05  ctr-warnings-rpt-writes			pic 9(7). 
    05  ctr-page-a                              pic 9(3). 
    05  ctr-page-b                              pic 9(3). 
    05  ctr-page-c                              pic 9(3). 
    05  ctr-reject                              pic 9(2). 
    05  ctr-warning				pic 9(2). 
    05  ctr-update				pic 9(2). 
 
*   COPY "MOD_CHECK_DIGIT.WS". 
 
    copy "f010_patient_mstr.ws".

    copy "f010_ws_tp_pat_mstr.ws".
 
 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"FUNCTION CODE MUST BE  AA  (ADD)". 
	10  filler				pic x(60)   value 
			"HEALTH NO AND CHART NO BOTH CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"SURNAME CAN'T BE BLANK ". 
	10  filler				pic x(60)   value 
			"OVERFLOW ON PATIENT'S SURNAME". 
 
*    MSG 05    * 
 
	10  filler				pic x(60)   value 
			"FIRST NAME CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"OVERFLOW ON PATIENT'S FIRST NAME". 
	10  filler				pic x(60)   value 
			"INVALID BIRTH YEAR, MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"INVALID BIRTH MONTH, MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"BIRTH MONTH MUST BE BETWEEN 1 TO 12 INCLUSIVE". 
 
*   MSG 10   * 
 
	10  filler				pic x(60)   value 
			"INVALID DAY, MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"BIRTH DAY MUST BE BETWEEN 1 TO 31 INCLUSIVE". 
	10  filler				pic x(60)   value 
			"FEB. CAN'T HAVE MORE THAN 29 DAYS". 
	10  filler				pic x(60)   value 
			"APR.,JUNE,SEPT.,NOV., ONLY HAVE 30 DAYS". 
	10  filler				pic x(60)   value 
			"SEX MUST BE M-MALE  OR  F-FEMALE". 
 
*   MSG 15   * 
 
	10  filler				pic x(60)   value 
		        "FIRST 8 DIGITS OF ID NO MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
		        "THE 9TH DIGIT OF ID NO MUST BE NUMERIC OR SPACE". 
	10  filler				pic x(60)   value 
			"YY OF ID NO MUST MATCH BIRTH-YY". 
	10  filler				pic x(60)   value 
			"MM OF ID NO MUST MATCH BIRTH-MM". 
	10  filler				pic x(60)   value 
			"SINCE SEX IS F, LAST DIGIT OF ID NO MUST BE EVEN". 
 
*   MSG 20   * 
 
	10  filler				pic x(60)   value 
			"SINCE SEX IS M, LAST DIGIT OF ID NO MUST BE ODD". 
	10  filler				pic x(60)   value 
			"STREET ADDRESS  CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"CITY CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"OVERFLOW ON CITY". 
	10  filler				pic x(60)   value 
			"PROV CAN'T BE BLANK". 
 
*   MSG 25   * 
 
	10  filler				pic x(60)   value 
			"INVALID PROVINCE - NOT FOUND FROM THE TABLE". 
	10  filler				pic x(60)   value 
			"POSTAL CODE 1 OR 3 OR 5 MUST BE ALPHABETIC". 
	10  filler				pic x(60)   value 
			"POSTAL CODE 2 OR 4 OR 6 MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"PHONE NUMBER MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"HEALTH NUMBER MUST BE NUMERIC". 
 
*   MSG 30   * 
 
	10  filler				pic x(60)   value 
			"INVALID OHIP NUMBER". 
	10  filler				pic x(60)   value 
			"SUBSCRIBER SURNAME CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"OVERFLOW ON SUBSCRIBER'S SURNAME". 
	10  filler				pic x(60)   value 
			"RELATIONSHIP MUST BE H-HOLDER  S-SPOUSE  D-DEPENDANT". 
	10  filler				pic x(60)   value 
			"FIRST RECORD IS C2, IT IS NOT ALLOWED". 
 
*   MSG 35   * 
 
	10  filler				pic x(60)   value 
			"C2 RECORD IS IGNORED BECAUSE C1 RECORD IS INVALID". 
	10  filler				pic x(60)   value 
			"OHIP NBR ONLY PATIENT ALREADY EXISTS". 
	10  filler				pic x(60)   value 
			"OHIP/CHART NBR PATIENT ALREADY EXISTS". 
	10  filler				pic x(60)   value 
			"PATIENT CHART NBR ALREADY EXISTS ". 
	10  filler				pic x(60)   value 
			"THERE IS NO 'C2' RECORD FOR THIS 'C1' RECORD". 
 
*   MSG 40   * 
 
	10  filler				pic x(60)   value 
			"OHIP NO ALREADY EXISTS WITH CHART NO, CAN'T ADD NEW CHART NO". 
	10  filler				pic x(60)   value 
			"THE ACRONYM KEY EXISTS, BUT DATABASE CORRUPTED ". 
	10  filler				pic x(60)   value 
			"SUBSCRIBER DOESN'T EXIST". 
	10  filler				pic x(60)   value 
			"SUBSCR-AUTO-UPDATE IS 'N', CAN'T CHANGE PAT/SUBSCR MSTR". 
	10  filler				pic x(60)   value 
			"CHART EXISTS IN SUBSCR-MSTR, BUT NOT IN PAT-MSTR". 
 
*   MSG 45   * 
 
	10  filler				pic x(60)   value 
			"THE CHANGED OHIP NO IS NOT ALLOWED". 
	10  filler				pic x(60)   value 
			"OHIP KEY WITH BIRTH MM OR YY CHANGED IS NOT ALLOWED". 
	10  filler				pic x(60)   value 
			"CHANGE FROM OHIP TO CHART IS NOT ALLOWED". 
	10  filler				pic x(60)   value 
			"CHART NO ALREADY EXISTS WITH OHIP NO, CAN'T ADD NEW OHIP NO". 
	10  filler				pic x(60)   value 
			"THE NEW SUBSCR ID EXISTS, CAN'T CHANGE PAT/SUBSCR MSTR". 
 
*   MSG 50   * 
 
	10  filler				pic x(60)   value 
			"THE ORIG ACRONYM DOES NOT EXIST, DATA BASE CORRUPTED". 
	10  filler				pic x(60)   value 
			"THE NEW ACRONYM KEY EXISTS, CAN'T ADD/CHANGE RECORD". 
	10  filler				pic x(60)   value 
			"C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 OHIP BUT IT EXISTS". 
	10  filler				pic x(60)   value 
			"C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 CHART BUT IT EXISTS". 
	10  filler				pic x(60)   value 
			"** ERROR ** - DUPLICATE IKEY - CONTACT DYAD IMMEDIATELY". 
*   MSG 55   * 
	10  filler				pic x(60)   value 
			"New Patient ADDED to Patient Master".
	10  filler				pic x(60)   value 
			"Patient BIRTH DATE changed".
	10  filler				pic x(60)   value 
			"Patient VERSION CODE changed".
	10  filler				pic x(60)   value 
			"Patient BIRTH DATE and VERSION CODE changed".
	10  filler				pic x(60)   value 
			"Patient OTHER THAN the Birth Date/Version Code changed".

 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 59 times. 
77  max-error-message-table
		pic 9(2) value 59. 
 
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
 
 
 
01  h1-head. 
 
    05  filler                                  pic x(40)  value "ru703a". 
    05  filler                                  pic x(53)  value 
			   "Diskette Submittal - Patient Upload ERROR Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
* (y2k - auto fix)
*   05  h1-run-date                             pic x(8). 
    05  h1-run-date                             pic x(10). 
    05  filler					pic x(5)   value spaces. 
    05  filler                                  pic x(7)   value "  PAGE". 
    05  h1-page-no                              pic zz9. 
 
 
01  h2-head. 
 
    05  filler                                  pic x(17)  value 
                           "* FUNC CD". 
    05  filler                                  pic x(26)  value 
                           "LAST  NAME". 
    05  filler                                  pic x(18)  value 
                           "FIRST  NAME". 
    05  filler                                  pic x(17)  value 
                           "BIRTH DATE  SEX". 
    05  filler                                  pic x(24)  value 
                           "CHART #  HEALTH #". 
    05  filler                                  pic x(22)  value 
                           "SUBSCRIBER SURNAME". 
    05  filler                                  pic x(10)  value 
                           "INITIALS". 
 
 
01  h3-head. 
 
    05  filler                                  pic x(40)  value "ru703b". 
    05  filler                                  pic x(53)  value 
			   "Diskette Submittal - Patient Upload AUDIT Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
* (y2k - auto fix)
*   05  h3-run-date                             pic x(8). 
    05  h3-run-date                             pic x(10). 
    05  filler					pic x(5)   value spaces. 
    05  filler                                  pic x(7)   value "  PAGE". 
    05  h3-page-no                              pic zz9. 
 
 
 
01  h4-head. 
 
    05  filler                                  pic x(28)  value "ru703c". 
    05  filler                                  pic x(65)  value 
*			   "DISKETTE SUBMITTAL PATIENT RECORD UPDATE REPORT". 
			   "Diskette Submittal - Patient Addition UPDATE EXCEPTIONS Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
* (y2k - auto fix)
*   05  h4-run-date                             pic x(8). 
    05  h4-run-date                             pic x(10). 
    05  filler					pic x(5)   value spaces. 
    05  filler                                  pic x(7)   value "  PAGE". 
    05  h4-page-no                              pic zz9. 
 
 
01  h5-head. 
 
    05  filler					pic x(10)  value spaces. 
    05  filler                                  pic x(22)  value 
                           "HEALTH/ACCT'ING #". 
    05  filler                                  pic x(20)  value 
                           "BIRTH DATE". 
    05  filler                                  pic x(20)  value 
                           "VERSION CD". 
    05  filler                                  pic x(50)  value spaces. 
01  l1-line. 
 
    05  filler                                  pic x(4). 
    05  l1-func-cd                              pic xx. 
    05  filler                                  pic x(4). 
    05  l1-last-name                            pic x(24). 
    05  filler                                  pic x(2). 
    05  l1-first-name                           pic x(24). 
    05  filler                                  pic x. 
    05  l1-date. 
* (y2k - auto fix)
*       10  l1-yy                               pic 99. 
        10  l1-yy                               pic 9(4). 
        10  l1-slash1                           pic x	value "/". 
        10  l1-mm                               pic 99. 
        10  l1-slash2                           pic x	value "/". 
        10  l1-dd                               pic 99. 
    05  filler                                  pic x(3). 
    05  l1-sex                                  pic x. 
    05  filler                                  pic x. 
    05  l1-id-no                                pic x(9). 
    05  filler                                  pic x(2). 
    05  l1-health-no                            pic x(12). 
    05  filler                                  pic xx. 
    05  l1-subscr-name                          pic x(24). 
    05  filler                                  pic x(3). 
    05  l1-subscr-init                          pic x(3). 
    05  filler                                  pic x(3). 
 
 
01  l2-line. 
 
    05  filler                                  pic x(11) 
                                                value "  ADDRESS: ". 
    05  l2-street-addr                          pic x(28). 
    05  filler                                  pic x(2)  value ", ". 
    05  l2-city                                 pic x(18). 
    05  filler                                  pic x(2)  value ", ". 
    05  l2-prov                                 pic x(4). 
    05  filler                                  pic x(2)  value ", ". 
    05  l2-postal-cd                            pic x(6). 
    05  filler                                  pic x(8) 
                                                value " PHONE: ". 
    05  l2-phone-no                             pic x(10). 
    05  filler                                  pic x(11) 
                                                value " RELATION: ". 
    05  l2-relationship                         pic x. 
    05  filler                                  pic x(11) 
                                                value "  VERSION: ". 
    05  l2-version-cd                           pic xx. 
    05  filler                                  pic x(13) 
                                                value " MESSAGE ID: ". 
    05  l2-mess-id                              pic x(2). 
 
 
01  l3-line					pic x(132). 
 
 
01  l4-line. 
 
    05  l4-title                                pic x(45). 
    05  l4-ctr                                  pic zzz9. 
    05  filler                                  pic x(83). 
 
 
01  prt-det-line1. 
    05  prt-lit1				pic x(10) value spaces. 
    05  prt-ohip-health-nbr			pic x(12). 
    05  filler					pic x(09) value spaces. 
* (y2k - auto fix)
*   05  rma-birth-date				pic 9(6). 
    05  rma-birth-date-yy			pic 9(4). 
    05  filler					pic x(1) value "/".
    05  rma-birth-date-mm			pic 9(2). 
    05  filler					pic x(1) value "/".
    05  rma-birth-date-dd			pic 9(2). 
    05  filler					pic x(09) value spaces. 
    05  rma-version-cd				pic xx. 
    05  filler					pic x(10) value spaces. 
    05  rma-prov-cd    				pic xx. 
    05  filler					pic x(10) value spaces. 
    05  rma-reason-desc				pic x(60) value spaces. 
 
 
01  prt-det-line2. 
    05  prt-lit2				pic x(10) value spaces. 
    05  disk-doctor-nbr				pic 9(6).  
    05  disk-account-id 			pic x(08) value spaces. 
    05  filler					pic x(07) value spaces. 
* (y2k - auto fix)
*   05  disk-birth-date				pic 9(6). 
    05  disk-birth-date-yy			pic 9(4). 
    05  filler					pic x(1) value "/".
    05  disk-birth-date-mm			pic 9(2). 
    05  filler					pic x(1) value "/".
    05  disk-birth-date-dd			pic 9(2). 
    05  filler					pic x(09) value spaces. 
    05  disk-version-cd				pic xx. 
    05  filler					pic x(10) value spaces. 
    05  disk-prov-cd    			pic xx. 
    05  filler					pic x(70) value spaces. 

linkage section.

01  stringLength		pic x(4) comp-5.
* requestType     - '1' Webstar patient protocol
* action          - 'f'ind/'a'dd/'u'pdate
* location        - 'a'll / 'm'umc / 's'tjoes / 'h'enderson
*                    		              / 'g'eneral
* sex             - 'a'll/'m'ale/'f'emale
*
*                    note the contents of keyValues1/2 depend upon keyType
* keyType         - 'h'ealth_id/'c'hart_nbr/'n'ame
* key-value1       - healthID or Chart Nbr or optionally
*                           a Surname
* key-value2       - blank or optionally a Firstname
* key-value3       - blank or optionally number of matching patients to skip
*			before continuing to read new records


01  request.
    10  request-type		pic x(01).
    10  request-data		pic x(99).
    10  request-cpi  redefines  request-data.
	20  action		pic x(01).
	20  location		pic x(01).
	20  sex			pic x(01).
	20  keyType		pic x(01).
	    88 search-by-name			value 'n'.
	    88 search-by-health-nbr		value 'h'.
	    88 search-by-medical-rec-nbr	value 'm'.
	20  key-value1.
	    30 key-value1-health-nbr
				pic x(10).
	    30 key-value1-remainder
				pic x(15).
	20  key-value2		pic x(20).
	20  key-value3		pic 9(07).
	20  x-filler		pic x(43).

*01  buffer-record-count		pic x(4) comp-5.
*01  max-nbr-records-exceeded	pic x(1).

*  WARNING - must keep record same length as "pat-mstr-rec" of f010 FD
*TODO 3430
01 buffer-patient-records		pic x(3440).
01 buffer-patient-records-r redefines buffer-patient-records.
* (this counter is used both as a 'return' value telling the calling program
*  how many records were returned in the buffer-patient-records but can also
*  be used by the calling program to tell this program to 'skip over' 
*  'buffer-record-record' number of records. This can be used to 'page thru'
*  matching records where the number of records exceeds the maximum buffer
*  size)
   10  buffer-record-count		pic x(7).
   10  max-nbr-records-exceeded	pic x(1).
*
   10  buffer-patient-record occurs MAX-PATS-RECS-IN-BUFFER.
	20  buffer-patient-rec		pic x(343).

01 next-item		pic x(4) comp-5.

procedure division. 
declaratives. 
 
err-tp-pat-mstr-file section. 
    use after standard error procedure on tp-pat-mstr. 
err-tp-pat-mstr. 
    stop "ERROR IN ACCESSING TP PATIENT MASTER". 
    move status-cobol-tp-pat-mstr       to status-file. 
    display status-file. 
    stop run. 
 
err-seq-pat-ikey-file section. 
    use after standard error procedure on seq-pat-ikey-file. 
err-seq-pat-ikey.
    stop "ERROR IN ACCESSING SEQUENTIAL OUTPUT PATIENT I-KEY FILE". 
    move status-cobol-seq-pat-file       to status-file. 
    display status-file. 
    stop run. 
 
err-new-pat-file section. 
    use after standard error procedure on new-pat-file. 
err-new-pat.
    stop "ERROR IN ACCESSING SEQENTIAL NEW PATIENT FILE". 
    move status-cobol-new-pat-file       to status-file. 
    display status-file. 
    stop run. 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
    stop "ERROR IN ACCESSING PATIENT MASTER". 
    move status-cobol-pat-mstr          to status-file. 
    display status-file. 

    move status-cobol-pat-mstr1  	  to status-cobol-display1.
    if   status-cobol-pat-mstr1 <> 9
    then
	move status-cobol-pat-mstr2  	  to status-cobol-display2
    else
	move low-values			  to status-cobol-pat-mstr1
	move status-cobol-pat-mstr-binary to status-cobol-display2.
*   endif
    display "Patient error = ", status-cobol-display.
    stop run. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    stop "ERROR IN ACCESSING CONSTANT MASTER". 
    move status-cobol-iconst-mstr       to status-file. 
    display status-file. 
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

**************
*  VALIDATE  *
**************

entry "validate" using 
			stringLength 
			request.
ab0-validate.

    if request-type <> "1" 
    then
	move INVALID-REQUEST-TYPE	to	return-code
	perform za0-error-processing	thru	zz0-99-exit
	go to ab0-99-exit.
*    end if
*   (ensure numeric key-value3)

    inspect key-value3 replacing all low-values by zeros.
    inspect key-value3 replacing all spaces     by zeros.

* TODO - remainder of edits.

*action		pic x(0001).
*location		pic x(0001).
*sex			pic x(0001).
*keyType		pic x(0001).
*key-value1		pic x(0025).
*key-value2		pic x(0020).

* move request(1:stringLength) to account-name.

           move 0				to return-code.

ab0-99-exit.
	exit program.

*****************************
*  PROCESS CPI_RMA REQUEST  *
*****************************

*request_type		pic x(0001).
*request_data		pic x(2055)
*request_cpi  redefines  request_data.
*action		pic x(0001).
*location		pic x(0001).
*sex			pic x(0001).
*keyType		pic x(0001).
*key-value1		pic x(0025).
*key-value2		pic x(0020).

entry "cpi_rma"	using
			request
*******				buffer-record-count
			buffer-patient-records.

*****display "CPI_RMA called" upon crt.

    perform aa0-initialization		thru aa0-99-exit. 

    move 0				to  ctr-patients-read.
    perform ca0-patient-read-first	thru ca0-99-exit.

*   (if reading via patient names, then search for more matches)
    if      matching-pat-exists
	and pat-not-eof
	and search-by-name
    then
*	(search for as many matching patients as can fit into buffer)
	perform yb0-10-read-next-pat-mstr thru yb0-10-99-exit
	    until    matching-pat-not-exists
		  or pat-eof
		  or ctr-patients-read = MAX-PATS-RECS-IN-BUFFER.
*   endif

*   
* TODO - indicate more records exist matching criteria but a 2nd request
*	must be made for them)

    move ctr-patients-read	to	buffer-record-count.

    if ctr-patients-read = MAX-PATS-RECS-IN-BUFFER 
    then
	move "Y"		to	max-nbr-records-exceeded
    else
	move "N"		to	max-nbr-records-exceeded.
*   endif

    move 0			to	return-code.

*   (BE. added to close files)
    perform az0-end-of-job	thru	az0-99-exit.

*****display "CPI_RMA return from!" upon crt.
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
 
*   (DELETE AUDIT FILES.) 
 
*    expunge audit-file-a. 
*    expunge audit-file-b. 
*    expunge audit-file-c. 
*    expunge seq-pat-ikey-file. 
*    expunge new-pat-file. 
 
    open input 	tp-pat-mstr. 
    open i-o  	pat-mstr 
		pat-elig-history
	        iconst-mstr. 
    open i-o	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		seq-pat-ikey-file 
		new-pat-file. 
 
*    move 0  				to counters. 
* need to initialize individually for c/cobol compile
    move 0				to	ctr-patients-read
						ctr-seq-pat-file-writes
						ctr-new-pat-file-writes
						ctr-pat-mstr-writes
						ctr-pat-mstr-exists
						ctr-write-corrected-pat
						ctr-write-pat-elig-hist
						ctr-error-rpt-writes
						ctr-warnings-rpt-writes
						ctr-page-a
    						ctr-page-b
    						ctr-page-c
    						ctr-reject
    						ctr-warning.

    move spaces 			to buffer-patient-records.

*   (PRINT OUT THE MESSAGE TABLE ON THE FIRST PAGE OF THE REPORT.) 
 
    add 1 				to ctr-page-a. 
    move run-date			to h1-run-date 
					   h3-run-date 
					   h4-run-date. 
    move ctr-page-a			to h1-page-no. 
 
    write rpt-rec-a from h1-head after advancing page. 
    move spaces 			to rpt-rec-a. 
    write rpt-rec-a after advancing 2 lines. 
 
 
*    perform aa1-print-message-table  	thru aa1-99-exit 
*            varying sub from 1 by 1 
*            until sub >  max-error-message-table.
 
    move 5				to const-rec-5-rec-nbr. 
    read iconst-mstr 
	invalid key 
		go to err-iconst-mstr. 
    move "I"				to hold-pat-i-key. 
    move const-con-nbr(25)		to hold-iconst-con-nbr. 
    move const-nx-avail-pat(25)		to hold-iconst-nx-ikey. 
 
    move all "-"			to l3-line. 
    move 20				to ctr-reject 
					   ctr-update 
					   ctr-warning. 
 
aa0-99-exit. 
    exit. 
aa1-print-message-table. 
 
    move spaces				to rpt-rec-a. 
    move spaces 			to err-msg-table. 
    move sub    			to err-no. 
    move ":"				to err-filler. 
    move err-msg(sub)     		to err-msg-comment. 
    write rpt-rec-a from err-msg-table after advancing 1 line. 
 
aa1-99-exit. 
    exit. 


ca0-patient-read-first.

    move 0                              to ctr-patients-read.

    move spaces                    	to hold-ohip-mmyy 
	                                   hold-chart-no 
                                           hold-orig-hc-feedback 
                                           hold-orig-od-feedback 
                                           hold-orig-chrt-feedback 
                                           flag-ohip-vs-chart. 
    move 0				to hold-health-nbr.

*   (if seaching by name and the user is continuing to scroll through 
*    matching patients use the key-value3 as the number of matches to 
*    skip by before continuing to read new records)

*   CASE 
    if     search-by-name
       and key-value3 <> 0
    then
        perform xx0-find-length-name-search thru xx0-99-exit
*	(currently only the first 6 characters of last name and
*	 first 3 characters of the first name can be searched on)
        move key-value1                 to pat-acronym-first6
        move key-value2                 to pat-acronym-last3 
        perform yb0-read-1st-acr-pat-mstr   thru yb0-99-exit
*       (skip the number requested - 1st record read in yb0 above)
        perform yb0-10-read-next-pat-mstr thru yb0-10-99-exit
            until    matching-pat-not-exists
		  or pat-eof
                  or ctr-patients-read = key-value3 - 1
	move 0				to key-value3
				 	   ctr-patients-read
*       (search for 1st matching name)
        perform yb0-10-read-next-pat-mstr thru yb0-10-99-exit
            until    matching-pat-not-exists
		  or pat-eof
                  or ctr-patients-read = 1
    else

    if search-by-health-nbr
    then 
	move key-value1-health-nbr		to hold-health-nbr
	move "H "				to flag-ohip-vs-chart 
	move hold-health-nbr			to pat-health-nbr of pat-mstr
        perform yb0-3-read-hc-pat-mstr  	thru yb0-3-99-exit 
    else 
        if search-by-medical-rec-nbr
        then 
            move key-value1 			to hold-chart-no
*    	    move "M"				to hold-chart-alpha 
*    	    move ws-tp-pat-id-no		to hold-chart-id-no 
            move "C "				to flag-ohip-vs-chart 
	    move hold-chart-no			to pat-chart-nbr
            perform yb0-5a-read-chrt-pat-mstr 	thru yb0-5a-99-exit
	else
	    if search-by-name
	    then
        	perform xx0-find-length-name-search thru xx0-99-exit
*		(currently only the first 6 characters of last name and
*		 first 3 characters of the first name can be searched on)
        	move key-value1                 to pat-acronym-first6
        	move key-value2                 to pat-acronym-last3 
		perform yb0-read-1st-acr-pat-mstr   thru yb0-99-exit.
*       endif 
*   endif 
*   END-CASE

ca0-99-exit.
    exit.
 

az0-end-of-job. 
 
    perform az1-totals			thru az1-99-exit. 

*   (B.E. 98/Sep/21: re-read the constants master with lock to ensure
*    that any changes made by others aren't lost when this program
*    updates it)
    move 5                              to const-rec-5-rec-nbr.
    read iconst-mstr with lock
        invalid key
                go to err-iconst-mstr. 

    move hold-iconst-con-nbr		to const-con-nbr(25). 
    move hold-iconst-nx-ikey		to const-nx-avail-pat(25). 
 
******    rewrite iconst-mstr-rec 
******	invalid key 
******		go to err-iconst-mstr. 
 
    close tp-pat-mstr 
	  seq-pat-ikey-file 
	  new-pat-file 
	  pat-mstr 
	  pat-elig-history
	  iconst-mstr 
	  audit-file-a 
	  audit-file-b 
          audit-file-c. 
 
az0-99-exit. 
    exit. 
 
 
az1-totals. 
 
    add 1			 	to ctr-page-b. 
    move ctr-page-b			to h3-page-no. 
    write rpt-rec-b from h3-head after advancing page. 
 
    move "NUMBER OF PATS OUTPUT W/ I-KEYS= " 
					to l4-title. 
    move ctr-seq-pat-file-writes	to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF NEW PATS FOR REPORT" 
					to l4-title. 
    move ctr-new-pat-file-writes	to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF PATIENTS ADDED F010= " 
					to l4-title. 
    move ctr-pat-mstr-writes            to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF PATIENTS EXIST F010= " 
					to l4-title. 
    move ctr-pat-mstr-exists            to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
 
    move "NUMBER OF WARNINGS PRINTED = " 
					to l4-title. 
    move ctr-warnings-rpt-writes        to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF REJECTED RECORDS = " 
					to l4-title. 
    move ctr-error-rpt-writes           to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF PAT UPDATED RECORDS = " 
					to l4-title. 
    move ctr-update                     to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
az1-99-exit. 
    exit. 
ba0-preliminary-edit-patient. 
 
    move "Y"				to edit-flag. 
 
    if     (tp-pat-id-no   = spaces) 
*      AND (TP-PAT-OHIP-NO = SPACES) 
       and (tp-pat-ohip-health-no = spaces or tp-pat-ohip-health-no = zeroes) 
    then 
	move "N"			to edit-flag 
	move 2				to err-ind 
	go to ba0-99-exit. 
*   endif 
 
    if tp-pat-last-name = spaces 
    then 
        move "N" 			to edit-flag 
 	move 3  			to err-ind 
        go to ba0-99-exit 
    else 
	move tp-pat-last-name		to ws-last-name. 
*   endif 
 
 
    if tp-pat-first-name = spaces 
    then 
        move "N" 			to edit-flag 
 	move 5  			to err-ind 
        go to ba0-99-exit 
    else 
	move tp-pat-first-name		to ws-first-name. 
*   endif 
 
    if tp-pat-birth-yy is not numeric 
    then 
        move "N"			to edit-flag 
        move 7				to err-ind 
	go to ba0-99-exit. 
*   endif 
 
    if tp-pat-birth-mm is not numeric 
    then 
        move "N"			to edit-flag 
	move 8				to err-ind 
	go to ba0-99-exit 
    else 
	if tp-pat-birth-mm < 1 or > 12 
	then 
            move "N"			to edit-flag 
	    move 9 			to err-ind 
            go to ba0-99-exit. 
*       endif 
*   endif 
 
     if tp-pat-birth-dd is not numeric 
     then 
         move "N"			to edit-flag 
 	 move 10			to err-ind 
 	 go to ba0-99-exit 
     else 
         if tp-pat-birth-dd  < 1  or > 31 
         then 
             move "N"  			to edit-flag 
   	    move 11			to err-ind 
             go to ba0-99-exit. 
**       endif 
**   endif 
  
     if tp-pat-birth-mm = 2 
     then 
  	if tp-pat-birth-dd > 29 
  	then 
  	    move "N"			to edit-flag 
  	    move 12			to err-ind 
             go to ba0-99-exit.	 
**	endif 
*    endif 
* 
* 
     if tp-pat-birth-mm =   4 or 6 or 9 or 11 
     then 
  	if tp-pat-birth-dd > 30 
  	then 
  	    move "N"			to edit-flag 
  	    move 13			to err-ind 
  	    go to ba0-99-exit. 
**	endif 
**   endif 
 
    if tp-pat-ohip-health-no = spaces 
    then 
	next sentence 
    else 
        if tp-pat-health-no is not numeric   and 
	  (tp-pat-prov = 'ON' or 'ONT')      and
*2001/03/05 - MC
	  (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9)
        then 
            move "N"			to edit-flag 
	    move 29			to err-ind 
            go to ba0-99-exit. 
*	ELSE 
*           (VERIFY THAT OHIP NUMBER IS VALID , ELSE PRINT MESSAGE.) 
 
*	    PERFORM BD0-VERIFY-OHIP-NBR	THRU BD0-99-EXIT 
*	    IF INVALID-OHIP 
*	    THEN 
*		MOVE "N"		TO EDIT-FLAG 
*		MOVE 30			TO ERR-IND 
*		GO TO BA0-99-EXIT. 
*	    endif 
*	endif 
*   endif 
 
ba0-99-exit. 
    exit. 
 
bb0-search-space-trailing. 
 
    if ws-detail-byte(sub) = spaces 
    then 
	add 1 				to space-ctr. 
*   endif 
 
bb0-99-exit. 
    exit. 
 
 
bc0-search-province. 
 
    if tp-pat-prov = old-prov(sub) 
    then 
        move tp-pat-prov  		to ws-prov 
	move new-prov(sub)		to ws-prov-cd 
	move "Y"			to province-flag. 
*   endif 
 
bc0-99-exit. 
    exit. 
 
 
bd0-search-new-province. 
 
    if tp-pat-prov = new-prov(sub) 
    then 
        move tp-pat-prov  		to ws-prov 
	                  		   ws-prov-cd 
	move "Y"			to province-flag. 
*   endif 
 
bd0-99-exit. 
    exit. 
 
 
be0-secondary-edit-patient. 
 
    move "Y"				to edit-flag. 
 
    if tp-pat-sex = "M" or "F" 
    then 
 	next sentence 
    else 
 	move "N"			to edit-flag 
 	move 14				to err-ind 
 	go to be0-99-exit. 
*   endif 
 
 
 
    if tp-pat-street-addr = spaces 
    then 
        move "N" 			to edit-flag 
	move 21 			to err-ind 
 	go to be0-99-exit 
    else 
	move spaces			to ws-street-addr 
	move tp-pat-street-addr		to ws-street-addr. 
*   endif 
 
    move spaces				to ws-city-prov. 
    move spaces				to ws-prov-cd. 
 
    if tp-pat-city = spaces 
    then 
        move "N" 			to edit-flag 
	move 22 			to err-ind 
*       (WARNING ONLY - CONTINUE EDIT OF PATIENT INFORMATION) 
*	GO TO BE0-99-EXIT 
    else 
	move tp-pat-city		to ws-city. 
*	MOVE ZERO			TO SPACE-CTR 
*	MOVE SPACES 			TO WS-CITY-PROV 
*					   WS-DETAIL-FIELD 
*       MOVE TP-PAT-CITY		TO WS-DETAIL-FIELD 
*	PERFORM BB0-SEARCH-SPACE-TRAILING  THRU BB0-99-EXIT 
*		VARYING SUB FROM 24 BY -1 
*		UNTIL WS-DETAIL-BYTE(SUB) NOT = SPACES 
*	IF SPACE-CTR < 7 
*	THEN 
*	    MOVE "N"			TO EDIT-FLAG 
*	    MOVE 23			TO ERR-IND 
*	    GO TO BE0-99-EXIT 
*	ELSE 
*	    MOVE TP-PAT-CITY		TO WS-CITY. 
*	endif 
*   endif 
 
    if tp-pat-prov = spaces 
    then 
*       MOVE "N" 			TO EDIT-FLAG 
	move 24 			to err-ind 
*       (WARNING ONLY - CONTINUE EDIT OF PATIENT INFORMATION) 
*	GO TO BE0-99-EXIT 
    else 
	move "N"			to province-flag 
	move spaces			to ws-prov-cd, ws-prov 
    	perform bc0-search-province 	thru bc0-99-exit 
		varying sub from 1 by 1 
		until (province-found or sub > 13) 
	if province-not-found 
	then 
	    perform bd0-search-new-province thru bd0-99-exit 
		    varying sub from 1 by 1 
		    until (province-found or sub > 13) 
	    if province-not-found 
	    then 
*	    	MOVE "N"		TO EDIT-FLAG 
	    	move 25			to err-ind 
*           (WARNING ONLY - CONTINUE EDIT OF PATIENT INFORMATION) 
*	    GO TO BE0-99-EXIT 
	    else 
	    	next sentence. 
*	    endif 
*	endif 
*   endif 
 
*   IF TP-PAT-POSTAL-CODE = SPACES 
*   THEN 
*	NEXT SENTENCE 
*   ELSE 
*	IF TP-PAT-POSTAL-CODE-1 IS NOT ALPHABETIC OR 
*          TP-PAT-POSTAL-CODE-3 IS NOT ALPHABETIC OR 
*          TP-PAT-POSTAL-CODE-5 IS NOT ALPHABETIC 
*	THEN 
*	    MOVE "N"			TO EDIT-FLAG 
*	    MOVE 26			TO ERR-IND 
* 	    GO TO BE0-99-EXIT 
*       ELSE 
*	    IF TP-PAT-POSTAL-CODE-2 IS NOT NUMERIC OR 
*	       TP-PAT-POSTAL-CODE-4 IS NOT NUMERIC OR 
*	       TP-PAT-POSTAL-CODE-6 IS NOT NUMERIC 
*	    THEN 
*		MOVE "N"		TO EDIT-FLAG 
*		MOVE 27			TO ERR-IND 
*		GO TO BE0-99-EXIT. 
*	    endif 
*	endif 
*   endif 
 
 
    if tp-pat-phone-no = spaces 
    then 
 	next sentence 
    else 
        if tp-pat-phone-no is not numeric 
        then 
            move "N"			to edit-flag 
            move 28			to err-ind 
            go to be0-99-exit. 
*       endif 
*   endif 
 
 
    if tp-pat-subscr-surname = spaces 
    then 
	move tp-pat-last-name		to ws-subscr-surname 
*	MOVE "N"			TO EDIT-FLAG 
*	MOVE 31				TO ERR-IND 
*	GO TO BE0-99-EXIT 
    else 
	move tp-pat-subscr-surname	to ws-subscr-surname. 
*   endif 
 
    if tp-pat-subscr-initials = spaces 
    then 
	move ws-first-name-1  		to tp-pat-subscr-initials. 
*   endif 
 
 
*   IF WS-PAT-RELATIONSHIP = "1" OR "2" OR "3" 
*   THEN 
*	MOVE WS-PAT-RELATIONSHIP	TO TP-PAT-RELATIONSHIP 
*   ELSE 
*	MOVE "0"			TO TP-PAT-RELATIONSHIP. 
*   endif 
 
 
be0-99-exit. 
    exit. 



xa0-write-tp-error-report. 
 
    move spaces				 to l1-line 
					    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-relationship 
                   			    l2-mess-id. 
 
    move tp-pat-func-code		 to l1-func-cd. 
    move tp-pat-last-name		 to l1-last-name. 
    move tp-pat-first-name		 to l1-first-name. 
* y2k
*   move tp-pat-birth-date		 to l1-date. 
    move tp-pat-birth-yy		 to l1-yy.
    move tp-pat-birth-mm		 to l1-mm.
    move tp-pat-birth-dd		 to l1-dd.
    move "/"				 to l1-slash1
					    l1-slash2.

    move tp-pat-sex			 to l1-sex. 
    move tp-pat-id-no			 to l1-id-no. 
    move tp-pat-ohip-health-no		 to l1-health-no. 
    move tp-pat-version-cd               to l2-version-cd. 
    move tp-pat-subscr-surname		 to l1-subscr-name. 
    move tp-pat-subscr-initials		 to l1-subscr-init. 
    move tp-pat-street-addr		 to l2-street-addr. 
    move tp-pat-city			 to l2-city. 
    move tp-pat-prov			 to l2-prov. 
    move tp-pat-postal-code		 to l2-postal-cd. 
    move tp-pat-phone-no		 to l2-phone-no. 
    move tp-pat-relationship		 to l2-relationship. 
    move err-ind         		 to l2-mess-id. 
 
    if ctr-reject > 9 
    then 
        move 0				 to ctr-reject 
        add 1				 to ctr-page-a 
        move ctr-page-a			 to h1-page-no 
        write rpt-rec-a from h1-head after advancing page 
        move spaces			 to rpt-rec-a 
        write rpt-rec-a after advancing 1 line. 
*   endif 
 
    write rpt-rec-a from h2-head after advancing 2 lines. 
    write rpt-rec-a from l1-line after advancing 1 line. 
    write rpt-rec-a from l2-line after advancing 2 lines. 
    write rpt-rec-a from l3-line after advancing 1 line. 
    add 1				  to ctr-reject. 
    add 1				  to ctr-error-rpt-writes. 
 
 
xa0-99-exit. 
    exit. 
xd0-write-audit-report. 
 
    move spaces				 to l1-line 
                   		 	    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-relationship 
                   			    l2-mess-id. 
 
 
    move tp-pat-func-code		 to l1-func-cd. 
    move tp-pat-last-name		 to l1-last-name. 
    move tp-pat-first-name		 to l1-first-name. 
* y2k
*  move tp-pat-birth-date		 to l1-date. 
    move tp-pat-birth-yy                 to l1-yy.
    move tp-pat-birth-mm                 to l1-mm.
    move tp-pat-birth-dd                 to l1-dd.
    move "/"				 to l1-slash1
					    l1-slash2.

    move tp-pat-sex			 to l1-sex. 
    move tp-pat-id-no			 to l1-id-no. 
    move tp-pat-ohip-health-no		 to l1-health-no. 
    move tp-pat-version-cd		 to l2-version-cd. 
    move tp-pat-subscr-surname		 to l1-subscr-name. 
    move tp-pat-subscr-initials		 to l1-subscr-init. 
    move tp-pat-street-addr		 to l2-street-addr. 
    move tp-pat-city			 to l2-city. 
    move tp-pat-prov			 to l2-prov. 
    move tp-pat-postal-code		 to l2-postal-cd. 
    move tp-pat-phone-no		 to l2-phone-no. 
    move tp-pat-relationship		 to l2-relationship. 
    move err-ind         		 to l2-mess-id. 
 
    if ctr-warning > 9 
    then 
        move 0				 to ctr-warning 
        add 1				 to ctr-page-b 
        move ctr-page-b	 		 to h3-page-no 
        write rpt-rec-b from h3-head after advancing page 
        move spaces			 to rpt-rec-b 
        write rpt-rec-b after advancing 1 line. 
*   endif 
 
    write rpt-rec-b from h2-head after advancing 2 lines. 
    write rpt-rec-b from l1-line after advancing 1 line. 
    write rpt-rec-b from l2-line after advancing 2 lines. 
    write rpt-rec-b from l3-line after advancing 1 line. 
    add 1				  to ctr-warning. 
    add 1				  to ctr-warnings-rpt-writes. 
 
 
xd0-99-exit. 
    exit. 
 
 
xe0-write-update-exception-rpt. 
 
    if ctr-update  > 9 
    then 
        move 0				 to ctr-update 
        add 1				 to ctr-page-c 
        move ctr-page-c	 		 to h4-page-no 
        write rpt-rec-c from h4-head after advancing page 
        move spaces			 to rpt-rec-c 
        write rpt-rec-c after advancing 1 line 
        write rpt-rec-c from h5-head after 1 line 
        move spaces			 to rpt-rec-c 
        write rpt-rec-c after advancing 1 line. 
*   endif 

*2000/03/10 - MC - add the following 5 move statements
 
    move 'RMA'			to prt-lit1.
    move 'Incoming'		to prt-lit2 .
    move tp-pat-ohip-health-no	to prt-ohip-health-nbr .
    move tp-pat-doctor-nbr    	to disk-doctor-nbr. 
    move tp-pat-account-id    	to disk-account-id. 

    if    old-version-cd-matches
      and old-birth-date-matches
    then
	move "VERSION CD and BIRTH DATE = RMA's OLD value" to rma-reason-desc
    else
    if    old-version-cd-matches
      and birth-date-changed
      and old-birth-date-doesnt-match
    then
	move "VERSION CD = RMA's OLD value (BIRTH DATE Updated)" to rma-reason-desc
    else
    if    old-birth-date-matches
      and version-cd-changed
      and old-version-cd-doesnt-match
    then
	move "BIRTH DATE = RMA's OLD value (VERSION CD Updated)" to rma-reason-desc
    else
    if    version-cd-changed
      and old-version-cd-matches
    then
        move "VERSION CD = RMA's OLD value"	     to rma-reason-desc
    else
    if    birth-date-changed
      and old-birth-date-matches
    then
	move "BIRTH DATE = RMA's OLD value"	     to rma-reason-desc
    else
	move "Unknown Update Exception error"	     to rma-reason-desc.
*   endcase

    write rpt-rec-c from prt-det-line1 after advancing 2 lines. 
    write rpt-rec-c from prt-det-line2 after advancing 1 line. 

    add 1				  to ctr-update. 
 
xe0-99-exit. 
    exit. 

yb0-read-1st-acr-pat-mstr. 
 
    move "Y"				to matching-pat-flag. 
    move "N"				to pat-eof-flag. 
    move zero				to pat-occur 
					   feedback-pat-mstr-acr. 
* NEW
*   (if less than the 'full' last name is searched on then you can't
*    use the first name in the start command - after starting you have
*    read and skip all records up to the first patient that matches
*    search criteria)

*   (currently searching on acronym so 'full' last name is 6 characters)
    if length-last-name-search < 6 then
	move spaces			to pat-acronym-last3.
*   endif

    start pat-mstr key is greater than or equal to pat-acronym
        invalid key
	    move "N"			to matching-pat-flag 
	    move "Y"			to pat-eof-flag
	    go to yb0-99-exit. 

    read pat-mstr next.

*bradbrad
* NEW
*   (having started with only the surname, skip patients until first name
*    matches and then continue regular logic) 
    if    length-last-name-search < 6
       or key-value3 <> 0 
    then
	perform yz0-skip-patients thru yz0-99-exit.
*   endif

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)
    perform zz1-process-chart-nbr	thru zz1-99-exit.

*   (check if acronym of patient found matches search criteria - note that
*	the user name have entered only part of the acronym)
    move key-value1    (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2    (1:length-first-name-search) to test-string-1-first-name.
    move pat-surname   (1:length-last-name-search)  to test-string-2-last-name.
    move pat-given-name(1:length-first-name-search) to test-string-2-first-name.

*   (since the system is reading sequentially through patients keyed on 
*    patient acronym (last6 + first3) only check the last name for setting
*   'end of matching patients' flag)

    if   test-string-1-last-name  <> test-string-2-last-name
      or test-string-1-first-name <  test-string-2-first-name
    then
	move "N"			to matching-pat-flag
    else
	add 1			       to ctr-patients-read
*	(if key-value3 is not zero then we are skipping records so
*	 don't count save them in buffer)
	if key-value3 = 0 
	then
	    move pat-mstr-rec       to buffer-patient-rec(ctr-patients-read).
*	endif
*   endif
 
yb0-99-exit. 
    exit. 

yz0-skip-patients.

*  (don't immediately skip records unless one in buffer indicates to do so)

*   (check if acronym of patient could match search criteria)
    move key-value1    (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2    (1:length-first-name-search) to test-string-1-first-name.
    move pat-surname   (1:length-last-name-search)  to test-string-2-last-name.
    move pat-given-name(1:length-first-name-search) to test-string-2-first-name.

*   (since the system is reading sequentially through patients keyed on 
*    patient acronym (last6 + first3) only check the last name for setting
*   'end of matching patients' flag)

    if   test-string-1-last-name  <  test-string-2-last-name
      or test-string-1-first-name <= test-string-2-first-name
      or pat-eof
    then
	go to yz0-99-exit.
*   endif

    read pat-mstr next
      	at end
            move "N"                         to matching-pat-flag
						pat-eof-flag 
	    go to yz0-99-exit.

    go to  yz0-skip-patients.

yz0-99-exit.
    exit.
 
yb0-3-read-hc-pat-mstr. 
 
    move "Y"				to matching-pat-flag. 
    move zero				to feedback-pat-mstr-hc. 
 
    read pat-mstr into ws-pat-mstr-rec     
       key is pat-health-nbr of pat-mstr
	invalid key 
	    move "N"			to matching-pat-flag 
	    go to yb0-3-99-exit. 

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)
    perform zz1-process-chart-nbr	thru zz1-99-exit.

*    (if key-value3 is not zero then we are skipping records so
*     don't save them in buffer)
    add 1			       to ctr-patients-read
    if key-value3 = 0 
    then
	move pat-mstr-rec       to buffer-patient-rec(ctr-patients-read).
*    endif
 
yb0-3-99-exit. 
    exit. 
 
 
yb0-5-read-od-pat-mstr. 
 
    move "Y"				to matching-pat-flag. 
    move zero				to feedback-pat-mstr-od. 
 
    read pat-mstr into ws-pat-mstr-rec     
       key is pat-ohip-mmyy of pat-mstr
	invalid key 
	    move "N"			to matching-pat-flag 
	    go to yb0-5-99-exit. 

*    (if key-value3 is not zero then we are skipping records so
*     don't save them in buffer)
    add 1			       to ctr-patients-read
    if key-value3 = 0 
    then
	move pat-mstr-rec       to buffer-patient-rec(ctr-patients-read).
*    endif
 
yb0-5-99-exit. 
    exit. 
 
 
yb0-10-read-next-pat-mstr. 
 
    move "Y" 					to matching-pat-flag. 
 
    read pat-mstr next
	at end 
	    move "N"				to matching-pat-flag 
	    go to yb0-10-99-exit. 

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)
    perform zz1-process-chart-nbr	thru zz1-99-exit.

*   (check if acronym of patient found matches search criteria)
    move key-value1        (1:length-last-name-search)  to test-string-1-last-name.
    move key-value2        (1:length-first-name-search) to test-string-1-first-name.
    move pat-surname   (1:length-last-name-search)  to test-string-2-last-name.
    move pat-given-name(1:length-first-name-search) to test-string-2-first-name.

    if   test-string-1-last-name  <> test-string-2-last-name
      or test-string-1-first-name <  test-string-2-first-name
    then
        move "N"                        to matching-pat-flag
    else
*	(if key-value3 is not zero then we are skipping records so
*	 don't save them in buffer)
    	add 1			       to ctr-patients-read
	if key-value3 = 0 
	then
	    move pat-mstr-rec       to buffer-patient-rec(ctr-patients-read).
*	endif
*   endif
 
yb0-10-99-exit. 
    exit. 
 
 
yc5-check-dup-ikey. 
 
    move hold-pat-ikey				to key-pat-mstr of pat-mstr. 
 
    read pat-mstr 
	invalid key 
	     go to yc5-99-exit. 
 
    move 54					to err-ind. 
    display err-msg(err-ind). 
    display key-pat-mstr of pat-mstr. 
    perform xa0-write-tp-error-report		thru xa0-99-exit. 
    perform err-pat-mstr. 
 
yc5-99-exit. 
    exit. 
 
 
 
yd0-build-seq-pat-rec. 
 
    move tp-pat-doctor-nbr		to	seq-pat-doctor-nbr. 
    move tp-pat-account-id		to	seq-pat-account-id. 
*   MOVE WS-PAT-I-KEY			TO	SEQ-PAT-I-KEY. 
    move ws-pat-con-nbr			to 	save-con-nbr. 
    move ws-pat-i-nbr  			to 	save-i-nbr. 
    move save-pat-ikey			to 	seq-pat-i-key. 
    move ws-pat-acronym			to	seq-pat-acronym. 
    move ws-pat-prov-cd			to	seq-pat-province. 
 
 
yd0-99-exit. 
    exit. 
 
 
 
 
ye0-write-seq-pat-rec. 
 
    write seq-pat-ikey-file-rec. 
 
    add 1				to	ctr-seq-pat-file-writes. 
 
ye0-99-exit. 
    exit. 
 
 
yf0-write-new-patient. 
 
    write new-pat-file-rec. 
 
    add 1				to	ctr-new-pat-file-writes. 
 
yf0-99-exit. 
    exit. 
 
 
yg0-check-update-pat. 
 
    move spaces				to prt-det-line1 
					   prt-det-line2. 
 
    move 'N'				to pat-change-flag. 
 
    move tp-pat-birth-yy		to ws-birth-date-yy. 
    move tp-pat-birth-mm		to ws-birth-date-mm. 
    move tp-pat-birth-dd		to ws-birth-date-dd. 

*   (reset flag that tracks if RMA database not updated because
*    incoming value is same as RMA's OLD value)
    move "N"				to flag-change-version-cd
           	  			   flag-birth-date-change
            				   flag-old-version-cd
            				   flag-old-birth-date.

* 2000/03/08 - MC Test for changed BIRTH DATE 
*    ws-pat-birth-date = patient's current data on RMA database
*    tp-            = incoming value
*    ws-pat-last-birth-date = patient's old value on RMA database
*
*    if     incoming value is not blank/zero
*      and  it differs from existing current RMA
*      and it's not equal to the OLD rma value(if RMA corrected the value
*	                       then the old value is in the RMA old value
*	                       and we don't want to change back to it again)
*    then update RMA database)
    if    ws-birth-date <> 0
      and ws-birth-date not = ws-pat-birth-date 
    then
*	(signal that data changed but don't actually move it until sure
*	 it is different from OLD values)
	move "Y"			to flag-birth-date-change
	if ws-birth-date not = ws-pat-last-birth-date
	then
*	    (update birth date)
	    move ws-pat-birth-date	to ws-pat-last-birth-date
            move ws-birth-date		to ws-pat-birth-date 
	else
*           (flag set so that warning report can be written if NOT changing 
*	     version code even though different from RMA- 'O'ld 'V'alue)
	move "Y"			to flag-old-birth-date
        move ws-pat-birth-date-yy	to rma-birth-date-yy
        move ws-pat-birth-date-mm	to rma-birth-date-mm
    	move ws-pat-birth-date-dd	to rma-birth-date-dd
	move ws-birth-date-yy		to disk-birth-date-yy
	move ws-birth-date-mm		to disk-birth-date-mm
	move ws-birth-date-dd		to disk-birth-date-dd.
*	endif
*   endif 
 
    if tp-pat-prov    not = ws-pat-prov-cd 
    then 
	move ws-pat-prov-cd   		to rma-prov-cd 
	move tp-pat-prov   		to ws-pat-prov-cd 
					   disk-prov-cd 
	move 'Y'			to pat-change-flag. 
*   endif 
*brad phone number etc..???

*   (Test for changed VERSION CODE
*    ws-pat-version-code = patient's current value on RMA database
*    tp-                 = incoming value
*    ws-pat-last-version-cd = patient's old value on RMA database
*
*    if    incoming value is not blank
*      and it differs from existing current RMA
*      and it's not equal to the OLD rma value(if RMA corrected MUMC
*                              value then MUMC's value is in the RMA old value
*                              and we don't want to change back to it again)
*    then update RMA database)
* (2000/03/24 B.E.- don't allow 1 character version code to update a 2 char one)
    if (    (    tp-pat-version-cd-1 = " "
              or tp-pat-version-cd-2 = " "
	    )
        and (    pat-version-cd-1 of pat-mstr <> " "
	     and pat-version-cd-2 of pat-mstr <> " "
	    )
       )
    then
	move "Y"		      to flag-1-vs-2-character-ver-cd
    else
	move "M"		      to flag-1-vs-2-character-ver-cd.
*   endif

    move "N"                          to flag-change-version-cd.
    move "N"			      to flag-old-version-cd.
    if    tp-pat-version-cd <> ' '
      and tp-pat-version-cd <> ws-pat-version-cd
      and not one-char-ver-cd-vs-2-char
    then 
*	(signal that data changed but don't actually move it until sure
*	 it is different from OLD values)
	move 'Y'			to flag-change-version-cd
	if tp-pat-version-cd <> ws-pat-last-version-cd
	then
	    move ws-pat-version-cd	to ws-pat-last-version-cd
	                              	   rma-version-cd 
	    move tp-pat-version-cd	to ws-pat-version-cd 
	                                   disk-version-cd
	else
*           (flag set so that warning report can be written if NOT changing 
*	     version code even though different from RMA - 'O'ld 'V'ersion)
	    move "Y"			to flag-old-version-cd
	    move ws-pat-version-cd	to rma-version-cd 
	    move tp-pat-version-cd	to disk-version-cd.
*        endif
*   endif 

*    if     (     version-cd-changed
*	     and (   old-version-cd-matches
*	          or (    birth-date-changed
*		      and old-birth-date-matches
*		     )
*		 )
*	   )
*       or  (     birth-date-changed
*	    and (    old-birth-date-matches
*	          or (    version-cd-changed
*		      and old-version-cd-matches
*		     )
*	  	)
*	   )

    if   (    version-cd-changed
          and old-version-cd-matches
	 )
      or (     birth-date-changed
	  and  old-birth-date-matches
	 )
    then 
	perform xe0-write-update-exception-rpt    thru xe0-99-exit.
*   endif


    if   pat-change 
      or (    version-cd-changed 
	  and old-version-cd-doesnt-match
	 )
      or (    birth-date-changed
	  and old-birth-date-doesnt-match
	 )
    then 
	go to yg0-80
    else
	go to yg0-99-exit.
*   endif

yg0-80.

*   (write audit that information was updated)
    if    (    birth-date-changed
	   and old-birth-date-doesnt-match
	  )
      and (    version-cd-changed 
	   and old-version-cd-doesnt-match
	  )
    then
	move 58				to err-ind
    else
    if   (    birth-date-changed
	  and old-birth-date-doesnt-match
	 )
    then
	move 56				to err-ind
    else
    if   (    version-cd-changed 
	  and old-version-cd-doesnt-match
	 )
    then
	move 57				to err-ind
    else
    if   pat-change 
    then
	move 59				to err-ind.
*   ENDCASE

    perform xd0-write-audit-report      thru xd0-99-exit.

*   (OHIP eligibility data was changed so call routine to:
*	- update patient's date last eligibility maintenace
*	- blank patient message if not blank and eligibility related
*	- write to f086 corrected patient file (allows system to resubmit held 
*						claims of patient)
*	- write to f011 patient eligibility history file)

    perform yy0-process-pat-elig-change	thru yy0-99-exit.

    rewrite pat-mstr-rec 		from ws-pat-mstr-rec.

 
yg0-99-exit. 
    exit. 
 
*(yy0-process-pat-eligibility-change thru yy0-99-exit)
    copy "process_pat_eligibility_change.rtn"
	replacing ==clmhdr-pat-ohip-id-or-chart of claim-header-rec==
	       by ==tp-pat-ohip-health-no==.
 

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




yb0-2-read-od-pat-mstr. 
 
    move "Y"				to matching-pat-flag. 
    move zero				to pat-occur-od 
					   feedback-pat-mstr-od. 
    read pat-mstr
        key is pat-ohip-mmyy
          invalid key 
	    move "N"			to matching-pat-flag 
	    go to yb0-2-99-exit. 

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)
    perform zz1-process-chart-nbr	thru zz1-99-exit.
 
    move pat-mstr-rec			to ws-pat-mstr-rec.
    move feedback-pat-mstr-od           to ws-feedback-pat-mstr. 

    add 1                          to ctr-patients-read
    move pat-mstr-rec              to buffer-patient-rec(ctr-patients-read).
 
yb0-2-99-exit. 
    exit. 

yb0-5a-read-chrt-pat-mstr.

    move "Y"                            to matching-pat-flag.
    move zero                           to pat-occur-chrt
                                           feedback-pat-mstr-chrt.
    read pat-mstr
        key is pat-chart-nbr
          invalid key
            move "N"                    to matching-pat-flag
            go to yb0-5a-99-exit.

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)
    perform zz1-process-chart-nbr	thru zz1-99-exit.

    move pat-mstr-rec                   to ws-pat-mstr-rec.
    move feedback-pat-mstr-chrt         to ws-feedback-pat-mstr.

    add 1                          to ctr-patients-read
    move pat-mstr-rec              to buffer-patient-rec(ctr-patients-read).

yb0-5a-99-exit. 
    exit.
 
za0-error-processing.

zz0-99-exit.
    exit.


zz1-process-chart-nbr.

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)

    move key-pat-mstr of pat-mstr	to x-key-pat-mstr.
    if pat-chart-nbr = x-key-pat-mstr-test
    then
	move spaces			to pat-chart-nbr.
*   endif

zz1-99-exit.
    exit.
