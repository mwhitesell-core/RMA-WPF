identification division. 
program-id.     cpirma5. 
author.         dyad infoSys. 
installation.   regional medical associates. 
date-written.   93/sep/20. 
date-compiled. 
security. 
* 
*    FILES      : called from cpi5.c socket program
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
* 2002/jun/25 B.E.      - allow access on 5 chart number keys
* 2002/jul/16 B.E.	- added error report 
* 2003/feb/26 B.E.	- MRNs are dummied up with patient's i-key to reduce
*			  the number of duplicate 'null' keys. Therefore is a
*			  mrn field contains values that match the -ikey then
*			  ignore that value as it's not a real mrn.
* 			- added open of report/audit on entry 'lookukp'
*

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
*   (modified 2002/Jun/20 to have additional chart nbrs)
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
    copy "f010_tp_pat_file.fd".
*
    copy "f010_seq_patient_file.fd".
*
    copy "f010_new_patient_file.fd".

*   (2002/jun/26 added new chart nbrs and changed layout of patient demographics
*    to match HHSC)
    copy "f010_patient_mstr.fd".
*
* 
    copy "f011_pat_mstr_elig_history.fd".
*
    copy "f085_rejected_claims.fd".
*
    copy "f086_pat_id.fd".
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
*	1) linkage section of this program (buffer-patient-records)
*	2) sizes in cpi5.c
* 	3) and the CPI_RMA.dll CONST MAX_LENGTH_PATIENT_RECORD

78  REQUEST-LENGTH	 value 726.

* 2002/jun/30 B.E. patient record changed from 343 to 379
* BUFFER SIZE = 379 (patient record size) times NBR RECS IN BUFFER
*****78  MAX-PATS-RECS-IN-BUFFER 	value 5.
78  MAX-PATS-RECS-IN-BUFFER 	value 10.

*78  MAX-PATS-RECS-BUFFERS-SIZE  value 3430.
*****78  MAX-PATS-RECS-BUFFERS-SIZE  value 1903.
78  MAX-PATS-RECS-BUFFERS-SIZE  value 3798.

*  (return-code error codes)
78  general-processing-error	value 1.
78  invalid-request-type	value 2.
78  invalid-sex			value 3.
78  invalid-action		value 4.
78  invalid-location		value 5.
78  invalid-key-type		value 6.
78  invalid-key-value-1		value 7.
78  invalid-key-value-2		value 8.

77  length-last-name-search		pic 9(2).
77  length-last-name-found		pic 9(2).
77  length-first-name-search		pic 9(2).
77  length-first-name-found		pic 9(2).
01  test-string-1-last-name		pic x(25).
01  test-string-2-last-name		pic x(25).
01  test-string-1-first-name		pic x(15).
01  test-string-2-first-name		pic x(15).

77  test-char				pic x(1).

copy "process_mrn_containing_ikey_values.ws".

77  print-file-name-a				pic x(13) 
		                                value "cpirma5_a.log". 
77  print-file-name-b				pic x(13)
		                                value "cpirma5_b.log". 
77  print-file-name-c				pic x(13) 
		                                value "cpirma5_c.log". 
77  error-rpt-name-a				pic x(13) 
		                                value "cpirma5_e.log". 
* 
*   (FEEDBACK AND OCCURRENCE.) 
* 
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
01 status-indicators. 
    05  status-file                             pic xx.
    05  status-audit-rpt-a			pic xx    value "0". 
    05  status-audit-rpt-b			pic xx    value "0". 
    05  status-audit-rpt-c			pic xx    value "0". 
    05  status-error-rpt-a			pic xx    value "0". 
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

01  l0-time-stamp. 
    05  l0-date. 
        10  l0-yy                               pic 9(4). 
        10  l0-slash1                           pic x	value "/". 
        10  l0-mm                               pic 99. 
        10  l0-slash2                           pic x	value "/". 
        10  l0-dd                               pic 99. 
    05  filler					pic x(2).
    05  l0-time.	
	10  l0-hrs				pic 99.
        10  l0-colon1                           pic x	value ":". 
	10  l0-min				pic 99.
        10  l0-colon2                           pic x	value ":". 
	10  l0-sec				pic 99.

01  line-error.
    05  le-time-stamp				pic x(20).
    05  filler					pic x(2).
    05  le-error-code				pic x(10).


01  l1-line. 
    05  l1-time-stamp				pic x(20).
    05  filler					pic x(01).
    05  l1-request-type            		pic x(01).
    05  filler					pic x(01).
    05  l1-action              			pic x(01).
    05  filler					pic x(01).
    05  l1-location				pic x(01).
    05  filler					pic x(01).
    05  l1-sex					pic x(01).
    05  filler					pic x(01).
    05  l1-key-type				pic x(01). 
    05  filler					pic x(01).
    05  l1-key-value1				pic x(25).
    05  filler					pic x(01).
    05  l1-key-value2				pic x(20).
    05  filler					pic x(01).
    05  l1-key-value3				pic 9(7).
    
 

linkage section.

01  stringLength		pic x(4) comp-5.
* requestType     - '1' Webstar patient protocol
* action          - 'f'ind/'a'dd/'u'pdate
* location        - 'a'll / 'm'umc / 's'tjoes / 'h'enderson
*                    		              / 'g'eneral
* sex             - 'a'll/'m'ale/'f'emale
*
*                    note the contents of keyValues1/2 depend upon key-type
* key-type         - 'h'ealth_id/'c'hart_nbr/'n'ame
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
	    88 mrn-is-mumc			value "m".
	    88 mrn-is-chedoke			value "c".
	    88 mrn-is-henderson			value "h".
	    88 mrn-is-general			value "g".
	    88 mrn-is-stjoes			value "s".
	20  sex			pic x(01).
	    88 searching-for-male		value 'm'.
	    88 searching-for-female		value 'f'.
	    88 searching-for-both-sex		value 'a'.
	20  key-type		pic x(01).
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
* general formula: 'pat rec size' * '# recs' + 8 bytes

*   343 * 10 = 2430 + 8 = 3438
*01 buffer-patient-records		pic x(3438).
*   379 *  5 = 1895 + 8 = 1903
*01 buffer-patient-records		pic x(1903). 

*  379 * 10 = 3790 + 8 = 3798
01 buffer-patient-records		pic x(3798).

01 buffer-patient-records-r redefines buffer-patient-records.
* (this counter is used both as a 'return' value telling the calling program
*  how many records were returned in the buffer-patient-records but can also
*  be used by the calling program to tell this program to 'skip over' 
*  'buffer-record-record' number of records. This can be used to 'page thru'
*  matching records where the number of records exceeds the maximum buffer
*  size)
10  buffer-record-count		pic x(7).
10  max-nbr-records-exceeded	pic x(1).

10  buffer-patient-record occurs MAX-PATS-RECS-IN-BUFFER.
*	20  buffer-patient-rec		pic x(343).
	20  buffer-patient-rec		pic x(379).

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

****entry "validate" using 
****			stringLength 
****			request.
ab0-validate.

    perform aa0-initialization          thru aa0-99-exit.

*   (only 1 request type at this time)
    if request-type <> "1"
    then
        move invalid-request-type       to      return-code
        perform za0-error-processing    thru    za0-99-exit
        go to ab0-99-exit.
*   end if

*   (only a 'f'ind action defined at this time)
    if action <> "f"
    then
        move invalid-action             to      return-code
        perform za0-error-processing    thru    za0-99-exit
        go to ab0-99-exit.
*   end if

*   (3 types of search protocols)
    if     not search-by-name
       and not search-by-health-nbr
       and not search-by-medical-rec-nbr
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

*   (verify medical record nbrs site value)
    if search-by-medical-rec-nbr
    then
	if   mrn-is-mumc
	  or mrn-is-chedoke
	  or mrn-is-general
	  or mrn-is-henderson
	  or mrn-is-stjoes
	then
	    next sentence
	else
            move invalid-location           to      return-code
            perform za0-error-processing    thru    za0-99-exit
            go to ab0-99-exit.
*	endif
*   endif

*   (ensure null values are replaced)
    inspect key-value1 replacing all low-values by zeros.
    inspect key-value2 replacing all low-values by zeros.

*   (ensure key-value3 is entirely numeric values)
    inspect key-value3 replacing all low-values by zeros.
    inspect key-value3 replacing all spaces     by zeros.

*   (no errors - set success flag)
    move 0                              to      return-code.

*   (2003/feb/26 BE. added to close files)
    perform az0-end-of-job      thru    az0-99-exit.

ab0-99-exit.
    exit.

****   exit program.


*****************************
*  PROCESS CPI_RMA REQUEST  *
*****************************

entry "lookup"	using
			request
			buffer-patient-records.

*****display "LOOKUP called" upon crt.

ab1-perform-lookup.
*   (setting return code bombs cobol so calling validate code here rather
*   than from C code)

    perform aa0-initialization          thru aa0-99-exit.
    perform xa0-write-audit-request	thru xa0-99-exit.

    perform ab0-validate		thru ab0-99-exit.
*   (if the validate routine found an error, then skip the cpi reads)
    if return-code <> 0
    then
        perform xb0-write-audit-err	thru xb0-99-exit
	move return-code		to  buffer-record-count
	move "N"			to  max-nbr-records-exceeded
        move "ERRORSTOP"		to  buffer-patient-rec(1)
	move 0				to  return-code
        go to ab1-99-exit.
*   endif

    perform aa1-initialization		thru aa1-99-exit. 

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
    perform xc0-write-audit-nbr-pats	
				thru	xc0-99-exit.

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
 
*   (DELETE AUDIT FILES.) 
 
*    expunge audit-file-a. 
*    expunge audit-file-b. 
*    expunge audit-file-c. 
*    expunge seq-pat-ikey-file. 
*    expunge new-pat-file. 

*    open i-o	audit-file-a 
    open output	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		error-rpt-a.
 
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
						ctr-rpt-a-pages
    						ctr-rpt-b-pages
    						ctr-rpt-c-pages
    						ctr-reject
    						ctr-warning
 						ctr-update.

aa0-99-exit. 
    exit. 


aa1-initialization.

    open input  tp-pat-mstr.
    open i-o	audit-file-a 
    		audit-file-b 
    		audit-file-c 
		error-rpt-a
		seq-pat-ikey-file 
		new-pat-file
    		pat-mstr
                pat-elig-history.
                
    move spaces                         to buffer-patient-records.

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
            move "C "				to flag-ohip-vs-chart 
*	    move hold-chart-no			to pat-chart-nbr
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
 
    close tp-pat-mstr 
	  seq-pat-ikey-file 
	  new-pat-file 
	  pat-mstr 
	  pat-elig-history
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
    move action					to	l1-action.
    move location				to	l1-location.
    move sex					to	l1-sex.
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

    write rpt-rec-a from  ctr-patients-read after advancing 1 line.

xc0-99-exit.
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

*   (having started with only the surname, skip patients until first name
*    matches and then continue regular logic) 
    if    length-last-name-search < 6
       or key-value3 <> 0 
    then
	perform yz0-skip-patients thru yz0-99-exit.
*   endif

*   (chart nbr fields were dummied up with the ikey of patient to reduce the
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
    then
        move "N"                        to matching-pat-flag
    else
       if  test-string-1-first-name =  test-string-2-first-name
       then
*	   (if key-value3 is not zero then we are skipping records so
*	   don't save them in buffer)
    	   add 1			       to ctr-patients-read
	   if key-value3 = 0 
	   then
	       move pat-mstr-rec       to buffer-patient-rec(ctr-patients-read).
*	   endif
*      else
*   	   (last name matches but first doesn't - skip this patient but 
*	    continue reading patient master until surname changes)
*      endif
*   endif
 
yb0-10-99-exit. 
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
*   (user 'location' to determine which site the patient's chart nbr matches)
*   CASE
    if mrn-is-mumc 
    then
	move hold-chart-no		to pat-chart-nbr
        read pat-mstr
            key is pat-chart-nbr
              invalid key
                move "N"                to matching-pat-flag
                go to yb0-5a-99-exit
    else
    if mrn-is-chedoke
    then
	move hold-chart-no		to pat-chart-nbr-2
        read pat-mstr
            key is pat-chart-nbr-2
              invalid key
                move "N"                to matching-pat-flag
                go to yb0-5a-99-exit
    else
    if mrn-is-henderson
    then
	move hold-chart-no		to pat-chart-nbr-3
        read pat-mstr
            key is pat-chart-nbr-3
              invalid key
                move "N"                to matching-pat-flag
                go to yb0-5a-99-exit
    else
    if mrn-is-general
    then
	move hold-chart-no		to pat-chart-nbr-4
        read pat-mstr
            key is pat-chart-nbr-4
              invalid key
                move "N"                to matching-pat-flag
                go to yb0-5a-99-exit
    else
	move hold-chart-no		to pat-chart-nbr-5
        read pat-mstr
            key is pat-chart-nbr-5
              invalid key
                move "N"                to matching-pat-flag
                go to yb0-5a-99-exit.
*   ENDCASE


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

   move spaces					to err-rpt-rec-a.
   move run-date				to err-date.
   move run-time				to err-time.
   move return-code				to err-code.

   move request					to err-data-1.

   write err-rpt-rec-a.

za0-99-exit.
    exit.


zz1-process-chart-nbr.

copy "process_mrn_containing_ikey_values.rtn".

zz1-99-exit.
    exit.

