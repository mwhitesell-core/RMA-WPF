identification division. 
program-id.     newu703. 
author.         dyad technologies. 
installation.   regional medical associates. 
date-written.   93/sep/20. 
date-compiled. 
security. 
* 
*    FILES      : SUBMIT_DISK_PAT_IN  - INCOMING PATIENT RECORDS 
*		: SUBMIT_DISK_PAT_OUT - PROCESSED PATIENT RECORDS 
*		: SUBMIT_NEW_PATS     - NEW PATIENT RECORDS 
*		: F010   - PATIENT MASTER 
*		: F011   - SUBSCRIBER MASTER 
*		: F090   - CONSTANTS MASTER 
*		: RU703A - ERROR Report
*		: RU703B - AUDIT Report
*		: RU703C - Update EXCEPTIONS Report
* 
* 
*    PROGRAM PURPOSE : UPDATE PATIENT/SUBSCRIBER MASTER FILES WITH 
*                      PATIENTS CONTAINED WITHIN OHIP DISKETTE SUBMITTAL AND 
*		       OUTPUT FILE OF PATIENTS PROCESSED ALONG WITH THE 
*		       PATIENT INTERNAL KEY ("I-KEY") ASSIGNED. 
*		       ACCESS PATIENT ONLY BY HEALTH NBR.  IF RECORD FOUND, 
*		       SET I-KEY TO SUSPEND FILE; OTHERWISE, DO A 
*		       SECONDARY EDIT CHECK, AND IF ALL FIELDS 
*		       PASS THE EDIT CHECK, CREATE THE PATIENT. 
*__________________________________________________________________ 
* 
* 
*    REVISION HISTORY: 
* 
*    DATE   WHO      		WHY 
* 90/JUN/01 BRAD ELLIOTT	- ORIGINAL 
* 
* 
* 91/APR/21 M. CHAN		- SMS 138 
*				- TAKE OUT 'KEY-PAT-MSTR' WORKING 
*				  VARIABLE AND SUBSCRIBER MSTR FD 
*				  FOR AMBIGUOUS REFERENCE PURPOSE 
*                               - DEFINE EACH PAT-MSTR FD FOR EACH KEY 
* 
* 91/JUN/18 M. CHAN		- WHEN ADDING PATIENT, INITIALIZE 
*				  EXPIRY DATE TO '0000' AND 65 INDICATOR 
*				  TO 'N' 
* 
* 
* 91/09/11 (B.M.L.)             - CHANGED PROGRAM TO IGNORE BLANK OR 
*                                 ZERO HEALTH NUMBERS, EDIT CHECKS NOW 
*                                 WORK FROM HEALTH NUMBER. 
* 
* 93/JUL/21 M. CHAN		- SMS 142 
*				- MORE EDIT ON FIELDS 
*				- ADD OD-PAT-MSTR-REC AND ASSOCIATED 
*				  FIELDS 
*				- USE EITHER HEALTH NBR OR REGISTRATION 
*				  NUMBER BASED ON PROVINCE 
* 
* 93/SEP/17 M. CHAN		- SMS 142 
*				- IF PATIENT EXISTS, UPDATE THE PATIENT 
*				  INFO IF DOB OR VERSION CD ARE DIFFERENT 
* 
* 97/MAR/18 B.E.		- CHANGED MAINLINE TO ALLOW THE PROCESSING 
*				  OF PATIENTS ON SUBMISSION DISKETTE 
*				  IF THEY ALEADY EXIST ON PATIENT FILE 
*				  WITHOUT BEING PROCESSED THROUGH 
*			  	  THE PRELIMINARY EDITS OF PROGRAM. 
* 98/Sep/21 B.E.		- added re-read of constants master with lock
*				  in AZ0 to ensure that no one has accessed
*				  and changed the values in record #5 before
*				  this program updates the record.
* 99/jan/21 B.E.		- y2k
*				- don't allow different version cd on tape to
*    				  update RMA database, write to error report
* 2000/mar/08 M.C.    - if the incoming patient birth date or version code 
*			is not blank/zero and differs from RMA database values
*			then update RMA database with these new values
*			UNLESS the incoming value is the same as RMA's
*			old value (in which case we assume that the incoming
*			value is out of date and RMA has updated the local
*			database with newer info). 
* 2000/mar/20 B.E.    - slight alteration to above change to write exception
*			report when ever a change is not made to RMA database
*			because incoming value = RMA's OLD value.
* 2000/mar/24 B.E.    - don't allow 1 character incoming version code to update
*			a 2 character RMA version code.
* 2000/may/17 B.E. - added new file f011-pat-mstr-elig-history file to track
*                    changes made to patient eligbility info. In doing so it was
*                    necessary to add qualification of key-pat-mstr and
*                    pat-health-nbr field to say either "of pat-mstr' or
*                    'of f011-pat-elig-history'.
* 00/oct/02 B.E. - newu703 not changed but change to yy0- copybook code
*                  so newu703 recompile and retested
* 01/mar/05 M.C. - include clmhdr-agent-cd in submit_disk_pat_in file, also
*                  if agent = 6 or 9, create pat with direct key
* 02/sep/27 M.C. - comment out the lines where move 'M' to hold-chart-alpha
*		 - copybook hold_patient_info.ws has commented out hold-chart-alpha
* 02/nov/14 M.C. - Yas complained only half got printed on the page for ru703c 
* 
* 02/feb/18 M.C. - Yas complained the program updated the wrong patient record
*		   when the incoming web record contains blank rmb number
* 04/jan/29 M.C. - change prov from NF to NL according to MOH
* 04/feb/25 M.C. - preset the values in f086-pat-id before determining there
*                  is eligibility change for the patient in yg0-check-update-pat
*                - add open/close on corrected-pat
* 08/jan/10 M.C. - only create records in f086 & f011  only if birth date or
*                  version code is different for both current and old values in database
* 
* 10/feb/23 MC1  - Yasemin requests to include doc-ohip-nbr/accounting-nbr in ru703a report
* 10/apr/21 MC2  - Yasemin requests to add extra line after name and before address line in ru703a
* 11/jun/15 MC3  - change ws-last-name & subscr-surname from x(15) to x(25) and ws-first-name from x(12) to x(25)
* 11/Jun/20 MC4  - move phone no to the working storage area before checking for numeric
* 13/Dec/11 MC5  - do not bother to edit phone nbr, should be the same as u011 - no checking on phone nbr
*		 - since relationship is blank from the incoming file (created from r702.qzs), do not bother to show on the
*		   report, but instead extend the phone nbr size from 10 to 20 for the report
* 14/Dec/08 MC6	 - include province 'NU' in the prov-table
* 15/Feb/26 MC7  - update pat-date-last-maint when updating patient record
* 15/Oct/06 MC8  - check on version cd to make sure it is alpha from 'A ' to 'ZZ'; otherwise provide error  28,  
*		   check version cd cannot be numeric; otherwise provide error 60, 
*		 - modify in ba0 & dd0 subroutines
*		 - still edit check on birth date and version cd for existing patient as well
* 15/Oct/28 MC9  - modify $use/process_mrn_containing_ikey_values.ws, $use/process_mrn_containing_ikey_values.rtn
*                and $use/set_blank_mrn_with_ikey_values.rtn to set pat-chart-nbr-4 to be '?' + ikey[7:9] if blank
**
*    GENERAL NOTES: 
* 
*	REFER TO DOCUMENTATION ON PROGRAM U011 (THE PROGRAM USED TO CLONE 
*	THIS PROGRAM) FOR INFORMATION ON ADDING PATIENTS, AND ADDING KEYS 
*	TO EXISTING PATIENTS) 
 
environment division. 
input-output section. 
file-control. 
* 
*   PLACE YOUR FILE SELECT STATEMENTS HERE 
* 
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
*mf    copy "f010_new_patient_mstr_od.slr".
* 
*mf    copy "f010_new_patient_mstr_hc.slr".
* 
*mf    copy "f010_new_patient_mstr_acr.slr".
* 
* 
    copy "f011_pat_mstr_elig_history.slr".

    copy "f085_rejected_claims.slr".
*
    copy "f086_pat_id.slr".

    copy "f090_constants_mstr.slr".
 
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
*mf    copy "f010_patient_mstr_od.fd".
* 
*mf    copy "f010_patient_mstr_hc.fd".
* 
*mf    copy "f010_patient_mstr_acr.fd".
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
 
fd  audit-file-b 
    record contains 132 characters. 
 
01  rpt-rec-b                   pic x(132). 
 
fd  audit-file-c 
    record contains 132 characters. 
 
01  rpt-rec-c                   pic x(132). 


working-storage section. 
 
77  tp-patient-file-name			pic x(21) 
	                                  value "submit_disk_pat_in.sf".
77  seq-patient-file-name			pic x(19) 
		                          value "submit_disk_pat_out".
77  new-patient-file-name			pic x(19) 
		                          value "submit_disk_pat_new".
77  print-file-name-a				pic x(9) 
		                                value "ru703a". 
77  print-file-name-b				pic x(9) 
		                                value "ru703b". 
77  print-file-name-c				pic x(9) 
		                                value "ru703c". 
* 
*   (FEEDBACK AND OCCURRENCE.) 
* 
77  feedback-iconst-mstr 			pic x(4). 
77  feedback-tp-pat-mstr 			pic x(4). 
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
*   (STATUS FILE INDICATORS.) 
* 
01  status-indicators. 
*mf    05  status-file				pic x(11). 
*mf    05  status-tp-pat-mstr			pic x(11) value "0". 
*mf    05  status-seq-pat-file			pic x(11) value "0". 
*mf    05  status-new-pat-file			pic x(11) value "0". 
*mf    05  status-iconst-mstr			pic x(11) value "0". 
*mf    05  status-pat-mstr 			pic x(11) value "0". 
*mf    05  status-pat-mstr-hc			pic x(11) value "0". 
*mf    05  status-pat-mstr-od			pic x(11) value "0". 
*mf    05  status-pat-mstr-acr			pic x(11) value "0". 
    05  status-file                             pic xx.
    05  status-audit-rpt-a			pic xx    value "0". 
    05  status-audit-rpt-b			pic xx    value "0". 
    05  status-audit-rpt-c			pic xx    value "0". 
    05  status-cobol-iconst-mstr                pic xx    value "0". 
    05  status-cobol-tp-pat-mstr                pic xx    value "0". 
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

* 2011/06/15 - MC3
*01  ws-last-name                               pic x(15).
01  ws-last-name                                pic x(25).
* 2011/06/15 - end

01  ws-first-name.
    05  ws-first-name-1                         pic x.
    05  ws-first-name-11                        pic x(11).
* 2011/06/15 - MC3 - increase first name from x(12)  to x(25)
    05  filler                                  pic x(13).
* 2011/06/15 - end

* 2011/06/15 - MC3
*01  ws-subscr-surname                          pic x(15).
01  ws-subscr-surname                           pic x(25).
* 2011/06/15 - end

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

* 2003/03/04 - MC
copy "process_mrn_containing_ikey_values.ws".
* 2003/03/04 - end
 
01  hold-pat-ikey. 
    05  hold-pat-i-key				pic x. 
    05  hold-iconst-con-nbr			pic 99. 
    05  hold-iconst-nx-ikey			pic 9(12). 
 
***01  HOLD-HEALTH-NO				PIC X(10). 
 
01  eof-tp-pat-mstr                         	pic x. 
    88  eof-tape                                	value "Y". 
    88  not-eof-tape                      	 	value "N". 
 
01  pat-flag                            	pic x. 
    88  pat-exist                  			value "Y". 
    88  pat-not-exist            			value "N". 
 
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

***01  FLAG-OHIP-VS-CHART                          PIC X. 
*** 88  OHIP                                    VALUE "O". 
*** 88  HEALTH                                  VALUE "H". 
 
***01  OHIP-FLAG					PIC X. 
*** 88  VALID-OHIP				VALUE "Y". 
*** 88  INVALID-OHIP				VALUE "N". 
 
 
 
*   (COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES.) 
 
01  counters. 
    05  ctr-tp-pat-mstr-reads			pic 9(7). 
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

* 2003/04/03 - MC - not applicable
*   copy "f010_ws_tp_pat_mstr.ws".
* 2003/04/03 - end 
 
 
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
* 2013/12/11 - MC5
*			"PHONE NUMBER MUST BE NUMERIC". 
* MC8
*			"SPARE".                           
			"VERSION CODE MUST BE ALPHA".                           
* MC8 - end
* 2013/12/11 - end
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
*   MSG 60   * 
* MC8
	10  filler				pic x(60)   value 
			"VERSION CODE CANNOT BE NUMERIC".
* MC8 - end

 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 60 times. 
77  max-error-message-table
		pic 9(2) value 60. 
 
01  err-msg-table. 
    05  err-no                                  pic x(4). 
    05  err-filler				pic x(3). 
    05  err-msg-comment                         pic x(64). 
 
01  prov-table. 
 
    05  province. 
        10  filler                              pic x(6) value "ALBTAB". 
* 2004/01/29 - MC
*       10  filler				pic x(6) value "NFLDNF". 
        10  filler				pic x(6) value "NFLDNL". 
* 2004/01/29 - end
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
* MC6
	10  filler   				pic x(6) value "NU  NU". 
* MC6 - end
 
    05  province-r   		 redefines      province. 
 
	10  prov                 occurs 14 times. 
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
* 2013/12/11 - MC5 - change size from to 20 & comment out relationship
*   05  l2-phone-no                             pic x(10). 
    05  l2-phone-no                             pic x(20). 
*   05  filler                                  pic x(11) 
*                                               value " RELATION: ". 
*   05  l2-relationship                         pic x. 
    05  filler                                  pic x(2) value spaces.
* 2013/12/11 - end 
    05  filler                                  pic x(11) 
                                                value "  VERSION: ". 
    05  l2-version-cd                           pic xx. 
    05  filler                                  pic x(13) 
                                                value " MESSAGE ID: ". 
    05  l2-mess-id                              pic x(2). 
 
 
* 2010/02/23 - MC1
*01  l3-line					pic x(132). 
01  l3-line. 
    05  l3-doc-ohip-nbr			        pic 9(6).
    05  filler					pic x.
    05  l3-doc-accounting-nbr			pic x(8). 
    05  filler					pic x(117).
* 2010/02/23 - end
 
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
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 12 col 10 value "DISKETTE SUBMITTAL PATIENT UPLOAD BEING PROCESSED". 
* 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
       05  line 24 col 70        pic x(2) from status-file       bell blink.
* 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U703 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 46	value "/". 
    05  line 21 col 47	pic 99	from sys-mm. 
    05  line 21 col 48	value "/". 
    05  line 21 col 50	pic 99	from sys-dd. 
    05  line 21 col 54	pic 99	from sys-hrs. 
    05  line 21 col 56	value ":". 
    05  line 21 col 57	pic 99	from sys-min.        
    05  line 23 col 10	value "AUDIT REPORTS ARE IN FILES - ". 
    05  line 23 col 43	pic x(8) from print-file-name-a. 
    05  line 23 col 51  value "&". 
    05  line 23 col 54  pic x(8) from print-file-name-b. 
    05  line 23 col 62  value "&". 
    05  line 23 col 65  pic x(8) from print-file-name-c. 
procedure division. 
declaratives. 
 
err-tp-pat-mstr-file section. 
    use after standard error procedure on tp-pat-mstr. 
err-tp-pat-mstr. 
    stop "ERROR IN ACCESSING TP PATIENT MASTER". 
*mf    move status-tp-pat-mstr    		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-tp-pat-mstr       to status-file. 
    display file-status-display. 
    stop run. 
 
err-seq-pat-ikey-file section. 
    use after standard error procedure on seq-pat-ikey-file. 
*mf err-seq-pat-ikey-file. 
err-seq-pat-ikey.
    stop "ERROR IN ACCESSING SEQUENTIAL OUTPUT PATIENT I-KEY FILE". 
*mf    move status-seq-pat-file    		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-seq-pat-file       to status-file. 
    display file-status-display. 
    stop run. 
 
err-new-pat-file section. 
    use after standard error procedure on new-pat-file. 
*mf err-new-pat-file. 
err-new-pat.
    stop "ERROR IN ACCESSING SEQENTIAL NEW PATIENT FILE". 
*mf    move status-new-pat-file    		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-new-pat-file       to status-file. 
    display file-status-display. 
    stop run. 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
    stop "ERROR IN ACCESSING PATIENT MASTER". 
*mf    move status-pat-mstr		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-pat-mstr          to status-file. 
    display file-status-display. 

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
 
*mf err-pat-mstr-file-hc section. 
*mf    use after standard error procedure on hc-pat-mstr. 
*mf err-hc-pat-mstr. 
*mf    stop "ERROR IN ACCESSING PATIENT MASTER H/C". 
*mf    move status-pat-mstr-hc		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf    move status-cobol-pat-mstr-hc       to status-file. 
*mf    display file-status-display. 
*mf    stop run. 
 
*mf err-pat-mstr-file-od section. 
*mf    use after standard error procedure on od-pat-mstr. 
*mf err-od-pat-mstr. 
*mf    stop "ERROR IN ACCESSING PATIENT MASTER OD ". 
*mf    move status-pat-mstr-od		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf   	 move status-cobol-pat-mstr-od       to status-file. 
*mf    display file-status-display. 
*mf    stop run. 
 
*mf err-pat-mstr-file-acr section. 
*mf    use after standard error procedure on acr-pat-mstr. 
*mf err-acr-pat-mstr. 
*mf    stop "ERROR IN ACCESSING PATIENT MASTER ACR". 
*mf    move status-pat-mstr-acr		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf    move status-cobol-pat-mstr-acr      to status-file. 
*mf    display file-status-display. 
*mf    stop run. 
 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    stop "ERROR IN ACCESSING CONSTANT MASTER". 
*mf    move status-iconst-mstr		to status-file. 
    move status-cobol-iconst-mstr       to status-file. 
    display file-status-display. 
    stop run. 
 
err-audit-rpt-file-a section. 
    use after standard error procedure on audit-file-a. 
err-audit-rpt-a. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-A". 
    move status-audit-rpt-a		to status-file. 
    display file-status-display. 
    stop run. 
 
err-audit-rpt-file-b section. 
    use after standard error procedure on audit-file-b. 
err-audit-rpt-b. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-B". 
    move status-audit-rpt-b		to status-file. 
    display file-status-display. 
    stop run. 
 
err-audit-rpt-file-c section. 
    use after standard error procedure on audit-file-c. 
err-audit-rpt-c. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE-C". 
    move status-audit-rpt-c		to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
            until eof-tape. 
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

* 2004/02/25 - MC
    open extend corrected-pat.
* 2004/02/25 - end

    open output audit-file-a 
    		audit-file-b 
    		audit-file-c 
		seq-pat-ikey-file 
		new-pat-file. 
 
    move 0  				to counters. 
*   (PRINT OUT THE MESSAGE TABLE ON THE FIRST PAGE OF THE REPORT.) 
 
    add 1 				to ctr-page-a. 
    move run-date			to h1-run-date 
					   h3-run-date 
					   h4-run-date. 
    move ctr-page-a			to h1-page-no. 
 
    write rpt-rec-a from h1-head after advancing page. 
    move spaces 			to rpt-rec-a. 
    write rpt-rec-a after advancing 2 lines. 
 
 
    perform aa1-print-message-table  	thru aa1-99-exit 
            varying sub from 1 by 1 
            until sub >  max-error-message-table.
 
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
    move "N"				to eof-tp-pat-mstr. 
    display scr-title. 
    perform ya0-read-next-tape          thru ya0-99-exit. 
 
 
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



ab0-processing. 
* 
*   (ASSUME THAT PATIENT IS FROM ONTARIO AND MAY ALREADY BE ON PATIENT 
*    FILE - IF SO PROCESS OUTPUT WITH PATIENT'S INFO -- OTHERWISE 
*    EDIT THE 'KEY' ACCESS FIELDS FROM EACH RECORD OF TP-PAT-MSTR 
*    REGARDLESS OF THE MODE.   NOTE:  IF RECORD IN ERROR, ERROR # 
*    IS PASSED BACK VIA ERR-IND) 
* 

* 2003/02/18 - MC - initialize pat-flag
    move 'N'				to pat-flag.
* 2003/02/18 - end

    if    (tp-pat-prov = 'ON' or 'ONT')
      and tp-pat-agent-cd not = 6 
      and tp-pat-agent-cd not = 9
*     (ensure value is numeric - otherwise consider as direct bill id format) 
      and tp-pat-ohip-health-no is numeric
    then
        move tp-pat-ohip-health-no              to pat-health-nbr of pat-mstr
        perform yb0-3-read-hc-pat-mstr          thru yb0-3-99-exit
    else
* 2003/02/18 - MC - read only if the field is not blank
    	if tp-pat-ohip-health-no not = spaces
	then
* 2003/02/18 - end
        move tp-pat-ohip-health-no              to pat-ohip-mmyy of pat-mstr
        perform yb0-5-read-od-pat-mstr          thru yb0-5-99-exit.
*   endif
 
*    move tp-pat-ohip-health-no         to	pat-health-nbr of pat-mstr. 
*    perform yb0-3-read-hc-pat-mstr    	thru 	yb0-3-99-exit. 

    if  pat-exist 
    then 
	perform yd0-build-seq-pat-rec		thru yd0-99-exit 
	perform ye0-write-seq-pat-rec		thru ye0-99-exit 
	add 1					to ctr-pat-mstr-exists 
*       (check if patient info needs to be updated)
	perform yg0-check-update-pat		thru yg0-99-exit 
	go to ab0-80-read-next-rec. 
*   endif 
 
    perform ba0-preliminary-edit-patient 	thru	ba0-99-exit. 
 
    if valid-record 
    then 
	perform ca0-add-mode-processing		thru	ca0-99-exit 
    else 
*       (INVALID-RECORD) 
	 perform xa0-write-tp-error-report	thru	xa0-99-exit. 
*   endif 
 
ab0-80-read-next-rec. 
    perform ya0-read-next-tape			thru	ya0-99-exit. 
 
ab0-99-exit. 
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
 
    rewrite iconst-mstr-rec 
	invalid key 
		go to err-iconst-mstr. 
 
    close tp-pat-mstr 
	  seq-pat-ikey-file 
	  new-pat-file 
	  pat-mstr 
	  pat-elig-history
* 2004/02/25 - MC
          corrected-pat
* 2004/02/25 - end

	  iconst-mstr 
	  audit-file-a 
	  audit-file-b 
          audit-file-c. 
 
    display scr-closing-screen. 
 
az0-99-exit. 
    exit. 
 
 
az1-totals. 
 
    add 1			 	to ctr-page-b. 
    move ctr-page-b			to h3-page-no. 
    write rpt-rec-b from h3-head after advancing page. 
 
    move "NUMBER OF PATIENTS ON TAPE = " 
					to l4-title. 
    move ctr-tp-pat-mstr-reads          to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
 
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

* MC8

ba0-edit-birth-date-version-cd.
 
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
 
* MC8
*   (version code can't be numeric)
    move tp-pat-version-cd              to hold-version-cd.

*   (error if version code not all alphabetic characters)
    if    hold-version-cd-1 numeric
       or hold-version-cd-2 numeric
    then
        move "N"                        to edit-flag
        move 60                         to err-ind
    else
        if tp-pat-version-cd not = spaces
        then
*           (upshift version code if lower case)
            perform dd0-check-version-cd     thru dd0-99-exit.
*       endif
*   endif
* MC8 - end 
 
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
* MC6
*		until (province-found or sub > 13) 
		until (province-found or sub > 14) 
* MC6 - end
	if province-not-found 
	then 
	    perform bd0-search-new-province thru bd0-99-exit 
		    varying sub from 1 by 1 
* MC6 
*		    until (province-found or sub > 13) 
		    until (province-found or sub > 14) 
* MC6 - end
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
 
* 2013/12/11 - MC5 - no longer needed to edit hone nbr 

*   if tp-pat-phone-no = spaces 
*   then 
*	next sentence 
*   else 
* 2011/06/20 - MC4 - move to working storage area before checking for numeric
*	move tp-pat-phone-no 		to ws-phone-no
**      if tp-pat-phone-no is not numeric 
*       if ws-phone-no is not numeric 
* 2011/06/20 - end
*       then 
*           move "N"			to edit-flag 
*           move 28			to err-ind 
*           go to be0-99-exit. 
*       endif 
*   endif 
 
* 2013/12/11 - end 

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
 
ca0-add-mode-processing. 
 
*    MUST READ BY HEALTH / REGISTRATION NBR ONLY 
 
    if tp-pat-prov = 'ON' or 'ONT' 
* 2001/03/05 - check agent cd as well
	and (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9)
    then 
*mf    	move tp-pat-ohip-health-no              to hc-pat-health-nbr 
        move tp-pat-ohip-health-no              to pat-health-nbr of pat-mstr
    	perform yb0-3-read-hc-pat-mstr    	thru yb0-3-99-exit 
    else 
*mf    	move tp-pat-ohip-health-no              to od-pat-ohip-mmyy 
        move tp-pat-ohip-health-no              to pat-ohip-mmyy of pat-mstr
    	perform yb0-5-read-od-pat-mstr    	thru yb0-5-99-exit. 
*   endif 
 
    if     pat-exist 
    then 
	perform yd0-build-seq-pat-rec		thru yd0-99-exit 
	perform ye0-write-seq-pat-rec		thru ye0-99-exit 
	add 1					to ctr-pat-mstr-exists 
	perform yg0-check-update-pat		thru yg0-99-exit 
	go to ca0-99-exit. 
*   endif 
 
 
*  (PATIENT DIDN'T EXIST) 
 
    perform cc0-determine-if-acron-exist	thru cc0-99-exit. 
    if  pat-not-exist 
    then 
	perform be0-secondary-edit-patient	thru be0-99-exit 
  	if invalid-record 
	then 
	    perform xa0-write-tp-error-report  thru xa0-99-exit 
	else 
	    perform cb0-add-pat	        thru cb0-99-exit. 
*	endif 
*   endif 
 
 
ca0-99-exit. 
    exit. 


cb0-add-pat. 
 
 
    perform ga0-build-patient	  		thru ga0-99-exit. 
    perform yb1-write-patient   		thru yb1-99-exit. 
 
    perform yd0-build-seq-pat-rec		thru yd0-99-exit. 
    perform ye0-write-seq-pat-rec		thru ye0-99-exit. 
 
    perform gf0-build-new-patient  		thru gf0-99-exit. 
    perform yf0-write-new-patient   		thru yf0-99-exit. 
 
    move 55					to err-ind. 
    perform xd0-write-audit-report		thru xd0-99-exit. 
 
 
cb0-99-exit. 
    exit. 
 
 
cc0-determine-if-acron-exist. 
 
    move tp-pat-last-name			to hold-last-name. 
    move tp-pat-first-name			to hold-first-name. 
*mf move hold-acronym				to acr-pat-acronym. 
    move hold-acronym                           to pat-acronym.
 
    perform yb0-read-acr-pat-mstr		thru yb0-99-exit. 
    if pat-not-exist 
    then 
	go to cc0-99-exit. 
*   endif 
 
    move "Y"					to pat-flag. 
 
cc0-10-check-acron. 
 
*   AT THIS POINT HEALTH NBR MUST BE NON-ZERO. 
*mf    if (tp-pat-ohip-health-no   = acr-pat-health-nbr )   or 
*mf       (tp-pat-ohip-health-no   = acr-pat-ohip-mmyy  ) 
       if   (tp-pat-ohip-health-no   = pat-health-nbr of pat-mstr)
         or 
            (tp-pat-ohip-health-no   = pat-ohip-mmyy  of pat-mstr)
    then 
	move 41					to err-ind 
	perform xa0-write-tp-error-report	thru xa0-99-exit 
    else 
	perform yb0-10-read-next-pat-mstr	thru yb0-10-99-exit 
	if pat-not-exist 
	then 
	    go to cc0-99-exit 
	else 
	    if pat-exist 
	    then 
		go to cc0-10-check-acron. 
*	    endif 
*       endif 
*   endif 
 
cc0-99-exit. 
    exit. 
 

*MC8

dd0-check-version-cd.

  if hold-version-cd-1 = ' ' then next sentence                 else
  if hold-version-cd-1 = 'a' then move 'A' to hold-version-cd-1 else
  if hold-version-cd-1 = 'b' then move 'B' to hold-version-cd-1 else
  if hold-version-cd-1 = 'c' then move 'C' to hold-version-cd-1 else
  if hold-version-cd-1 = 'd' then move 'D' to hold-version-cd-1 else
  if hold-version-cd-1 = 'e' then move 'E' to hold-version-cd-1 else
  if hold-version-cd-1 = 'f' then move 'F' to hold-version-cd-1 else
  if hold-version-cd-1 = 'g' then move 'G' to hold-version-cd-1 else
  if hold-version-cd-1 = 'h' then move 'H' to hold-version-cd-1 else
  if hold-version-cd-1 = 'i' then move 'I' to hold-version-cd-1 else
  if hold-version-cd-1 = 'j' then move 'J' to hold-version-cd-1 else
  if hold-version-cd-1 = 'k' then move 'K' to hold-version-cd-1 else
  if hold-version-cd-1 = 'l' then move 'L' to hold-version-cd-1 else
  if hold-version-cd-1 = 'm' then move 'M' to hold-version-cd-1 else
  if hold-version-cd-1 = 'n' then move 'N' to hold-version-cd-1 else
  if hold-version-cd-1 = 'o' then move 'O' to hold-version-cd-1 else
  if hold-version-cd-1 = 'p' then move 'P' to hold-version-cd-1 else
  if hold-version-cd-1 = 'q' then move 'Q' to hold-version-cd-1 else
  if hold-version-cd-1 = 'r' then move 'R' to hold-version-cd-1 else
  if hold-version-cd-1 = 's' then move 'S' to hold-version-cd-1 else
  if hold-version-cd-1 = 't' then move 'T' to hold-version-cd-1 else
  if hold-version-cd-1 = 'u' then move 'U' to hold-version-cd-1 else
  if hold-version-cd-1 = 'v' then move 'V' to hold-version-cd-1 else
  if hold-version-cd-1 = 'w' then move 'W' to hold-version-cd-1 else
  if hold-version-cd-1 = 'x' then move 'X' to hold-version-cd-1 else
  if hold-version-cd-1 = 'y' then move 'Y' to hold-version-cd-1 else
  if hold-version-cd-1 = 'z' then move 'Z' to hold-version-cd-1.

  if hold-version-cd-2 = ' ' then next sentence                 else
  if hold-version-cd-2 = 'a' then move 'A' to hold-version-cd-2 else
  if hold-version-cd-2 = 'b' then move 'B' to hold-version-cd-2 else
  if hold-version-cd-2 = 'c' then move 'C' to hold-version-cd-2 else
  if hold-version-cd-2 = 'd' then move 'D' to hold-version-cd-2 else
  if hold-version-cd-2 = 'e' then move 'E' to hold-version-cd-2 else
  if hold-version-cd-2 = 'f' then move 'F' to hold-version-cd-2 else
  if hold-version-cd-2 = 'g' then move 'G' to hold-version-cd-2 else
  if hold-version-cd-2 = 'h' then move 'H' to hold-version-cd-2 else
  if hold-version-cd-2 = 'i' then move 'I' to hold-version-cd-2 else
  if hold-version-cd-2 = 'j' then move 'J' to hold-version-cd-2 else
  if hold-version-cd-2 = 'k' then move 'K' to hold-version-cd-2 else
  if hold-version-cd-2 = 'l' then move 'L' to hold-version-cd-2 else
  if hold-version-cd-2 = 'm' then move 'M' to hold-version-cd-2 else
  if hold-version-cd-2 = 'n' then move 'N' to hold-version-cd-2 else
  if hold-version-cd-2 = 'o' then move 'O' to hold-version-cd-2 else
  if hold-version-cd-2 = 'p' then move 'P' to hold-version-cd-2 else
  if hold-version-cd-2 = 'q' then move 'Q' to hold-version-cd-2 else
  if hold-version-cd-2 = 'r' then move 'R' to hold-version-cd-2 else
  if hold-version-cd-2 = 's' then move 'S' to hold-version-cd-2 else
  if hold-version-cd-2 = 't' then move 'T' to hold-version-cd-2 else
  if hold-version-cd-2 = 'u' then move 'U' to hold-version-cd-2 else
  if hold-version-cd-2 = 'v' then move 'V' to hold-version-cd-2 else
  if hold-version-cd-2 = 'w' then move 'W' to hold-version-cd-2 else
  if hold-version-cd-2 = 'x' then move 'X' to hold-version-cd-2 else
  if hold-version-cd-2 = 'y' then move 'Y' to hold-version-cd-2 else
  if hold-version-cd-2 = 'z' then move 'Z' to hold-version-cd-2.

    move hold-version-cd to tp-pat-version-cd.

* check to make sure version cd is alpha
  if         hold-version-cd = spaces
* according to Yasemin, do not allow first byte is blank and second byte is alpha as ' R'
*       or  (     hold-version-cd-1 = spaces
*            and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z')
*           )
        or  (     hold-version-cd-2 = spaces
             and (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z')
            )
        or  (    (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z')
             and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z')
            )
  then
        next sentence
  else
        move "N"                        to edit-flag
        move 28                         to err-ind.
* endif

dd0-99-exit.
    exit.

* MC8 - end





ga0-build-patient. 
 
    move spaces				to ws-pat-mstr-rec. 
 
    move ws-last-name    		to ws-pat-surname 
					   ws-pat-acronym-first6. 
    move ws-first-name    		to ws-pat-given-name 
					   ws-pat-init1 
					   ws-pat-acronym-last3. 
    move tp-pat-birth-yy		to ws-pat-birth-date-yy. 

    move tp-pat-birth-mm		to ws-pat-birth-date-mm. 
    move tp-pat-birth-dd		to ws-pat-birth-date-dd. 
    move tp-pat-sex			to ws-pat-sex. 
* 2003/04/03 - MC  
*   move tp-pat-phone-no		to ws-phone-no. 
*   move ws-local-phone-no		to ws-pat-phone-nbr. 
    move tp-pat-phone-no		to ws-pat-phone-nbr.
* 2003/04/03 - end

    move "O"				to ws-pat-in-out. 
    move sys-date-long			to ws-pat-date-last-maint. 
    move zero				to ws-pat-nbr-outstanding-claims. 
*   MOVE HOLD-OHIP-MMYY			TO WS-PAT-OHIP-MMYY. 
*   MOVE HOLD-CHART-NO			TO WS-PAT-CHART-NBR. 
    move hold-pat-i-key			to ws-pat-i-key. 
    move hold-iconst-con-nbr		to ws-pat-con-nbr. 
    move hold-iconst-nx-ikey		to ws-pat-i-nbr. 
    if ws-prov-cd = 'ON' 
*2001/03/06 - MC
	and (tp-pat-agent-cd not = 6 and tp-pat-agent-cd not = 9)
**
    then 
    	move tp-pat-ohip-health-no      to  ws-pat-health-nbr 
    else 
    	move tp-pat-ohip-health-no      to  ws-pat-ohip-mmyy 
    	move zeros                      to  ws-pat-health-nbr. 
*   endif 
 
    move "N"				to ws-pat-health-65-ind. 
    move "0000"				to ws-pat-expiry-date. 
    move tp-pat-version-cd              to ws-pat-version-cd. 

* 2003/04/03 - MC 
*   move ws-street-addr1		to ws-subscr-addr1. 
*   move ws-street-addr2		to ws-subscr-addr2. 
*   move ws-city-prov			to ws-subscr-addr3. 
*   move ws-prov-cd			to ws-pat-prov-cd. 
    move tp-pat-street-addr		to ws-subscr-addr1. 
    move tp-pat-city 			to ws-subscr-addr3. 
    move ws-prov-cd			to ws-pat-prov-cd, ws-subscr-prov-cd.
* 2003/04/03 - end

 
    move tp-pat-postal-code 		to ws-subscr-postal-cd. 
    move "Y"				to ws-subscr-auto-update. 
    move "00"				to ws-subscr-msg-nbr. 
 
 
ga0-99-exit. 
    exit. 
 
ge0-increment-nx-avail-pat. 
 
    add 1				to hold-iconst-nx-ikey 
	on size error 
		move 1			to hold-iconst-nx-ikey 
		add 1			to hold-iconst-con-nbr 
		    on size error 
			move 25		to hold-iconst-con-nbr. 
 
ge0-99-exit. 
    exit. 
 
gf0-build-new-patient. 
 
    move tp-pat-ohip-health-no		to new-pat-ohip. 
    move ws-last-name  			to new-pat-surname. 
    move ws-first-name  		to new-pat-first-name. 
    move ws-subscr-surname		to new-pat-subscr-surname. 
    move tp-pat-street-addr		to new-pat-address-line-1. 
    move ws-city       			to new-pat-address-line-2. 
    move ws-prov       			to new-pat-address-line-3. 
    move tp-pat-postal-code		to new-pat-postal-code. 
    move tp-pat-birth-date		to new-pat-birth-date. 
    move tp-pat-sex    			to new-pat-sex. 
 
gf0-99-exit. 
    exit. 
 
xa0-write-tp-error-report. 
 
    move spaces				 to l1-line 
					    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
* 2013/12/11 - MC5 - not require
*                   			    l2-relationship 
* 2013/12/11 - end
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
* 2013/12/11 - MC5 - not require 
*    move tp-pat-relationship		 to l2-relationship. 
* 2013/12/11 - end
    move err-ind         		 to l2-mess-id. 
 
* 2010/04/21 - MC2 - since Yasemin requested to add extra line before address, 
*		     only 8 rejects to be printed per page
*    if ctr-reject > 9 
    if ctr-reject > 8 
* 2010/04/21 - end
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
* 2010/04/21 - MC2 - Yasemin requested to put extra line before address line
*    write rpt-rec-a from l2-line after advancing 2 lines. 
    write rpt-rec-a from l2-line after advancing 3 lines. 
* 2010/04/21 - end
* 2010/02/23 - MC1 - print doc-ohip-nbr/accounting-nbr
    move all "-"			  to l3-line. 
    move tp-pat-doctor-nbr  		  to l3-doc-ohip-nbr.
    move tp-pat-account-id     	  	  to l3-doc-accounting-nbr.
* 2010/02/23 - end
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
* 2013/12/11 - MC5 - not require
*                  			    l2-relationship 
* 2013/12/11 - end 
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
* 2013/12/11 - MC5 - not require
*    move tp-pat-relationship		 to l2-relationship. 
* 2013/12/11 - end 
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
* 2010/02/23 - MC1
    move all "-"			  to l3-line. 
* 2010/02/23 - end
    write rpt-rec-b from l3-line after advancing 1 line. 
    add 1				  to ctr-warning. 
    add 1				  to ctr-warnings-rpt-writes. 
 
 
xd0-99-exit. 
    exit. 
 
 
xe0-write-update-exception-rpt. 
 
* 2002/11/14 - MC - Yas complained it only printed half on the page
*    if ctr-update  > 9 
    if ctr-update  > 18
* 2002/11/14 - end
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
ya0-read-next-tape. 
 
    read tp-pat-mstr 
	at end 
	    move "Y"			to eof-tp-pat-mstr 
	    go to ya0-99-exit. 
    add 1				to ctr-tp-pat-mstr-reads. 
 
ya0-99-exit. 
    exit. 
 
 
yb0-read-acr-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur 
					   feedback-pat-mstr-acr. 
 
*mf    read acr-pat-mstr 
       read pat-mstr      
        key is pat-acronym
	invalid key 
	    move "N"			to pat-flag 
	    go to yb0-99-exit. 
 
yb0-99-exit. 
    exit. 
 
yb0-3-read-hc-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to feedback-pat-mstr-hc. 
 
*mf    read hc-pat-mstr into ws-pat-mstr-rec 
 read pat-mstr into ws-pat-mstr-rec     
       key is pat-health-nbr of pat-mstr
	invalid key 
	    move "N"			to pat-flag 
	    go to yb0-3-99-exit. 
 
yb0-3-99-exit. 
    exit. 
 
 
yb0-5-read-od-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to feedback-pat-mstr-od. 
 
*mf    read od-pat-mstr into ws-pat-mstr-rec 
       read pat-mstr into ws-pat-mstr-rec     
       key is pat-ohip-mmyy of pat-mstr
	invalid key 
	    move "N"			to pat-flag 
	    go to yb0-5-99-exit. 
 
yb0-5-99-exit. 
    exit. 
 
 
yb0-10-read-next-pat-mstr. 
 
    move "Y" 					to pat-flag. 
 
*mf    read acr-pat-mstr next 
       read pat-mstr next
	at end 
	    move "N"				to pat-flag 
	    go to yb0-10-99-exit. 
 
 
*mf    if acr-pat-acronym not = hold-acronym 
       if pat-acronym not = hold-acronym
    then 
	move "N"				to pat-flag. 
*   endif 
 
yb0-10-99-exit. 
    exit. 
 
 
yb1-write-patient. 
 
    perform yc5-check-dup-ikey			thru yc5-99-exit. 
    move ws-pat-mstr-rec			to pat-mstr-rec. 
    perform yb2-write-pat-i-key			thru yb2-99-exit. 
    perform ge0-increment-nx-avail-pat		thru ge0-99-exit. 
 
*mf    move feedback-pat-mstr                      to feedback-pat-mstr-acr. 
*mf    move ws-pat-mstr-rec                        to acr-pat-mstr-rec. 
*mf    perform yb8-write-acr-key                   thru yb8-99-exit. 
 
**  IF (WS-PAT-HEALTH-NBR NOT = SPACES AND 
*mf    if ws-pat-health-nbr not = zero 
*mf    then 
*mf    	move feedback-pat-mstr                  to feedback-pat-mstr-hc 
*mf	move ws-pat-mstr-rec 			to hc-pat-mstr-rec 
*mf     perform yb7-write-hc-key           	thru yb7-99-exit 
*mf    else 
*mf	if ws-pat-ohip-mmyy not = spaces 
*mf		then 
*mf	    move feedback-pat-mstr 		to feedback-pat-mstr-od 
*mf	    move ws-pat-mstr-rec		to od-pat-mstr-rec 
*mf	    perform yb9-write-od-key		thru yb9-99-exit. 
*	endif 
*   endif 
 
 
yb1-99-exit. 
    exit. 
 
yb2-write-pat-i-key. 
 
*   (the following fields may be blank and can cause too many duplicate keys
*    so dummy up the value with the last 10/11 digits of the i-key)
    if   pat-ohip-mmyy = " "
      or pat-ohip-mmyy = zero
    then
        move ws-pat-i-nbr                       to      pat-ohip-mmyy.
*   endif

* 2003/03/04 - MC - set ikey if chart nbr is blank
copy "set_blank_mrn_with_ikey_values.rtn".  
* 2003/03/04 - end  

    write pat-mstr-rec 
	invalid key 
	    go to err-pat-mstr. 
**************************** added for debugging *************
    move status-cobol-pat-mstr1           to status-cobol-display1.
    if   status-cobol-pat-mstr1 <> 9
    then
        move status-cobol-pat-mstr2       to status-cobol-display2
    else
	move low-values			  to status-cobol-pat-mstr1
        move status-cobol-pat-mstr-binary to status-cobol-display2.
*   endif

    if status-cobol-pat-mstr1 <> 0
    then
	display "Patient error = ", status-cobol-display.
*   endif
************************************************************

    add 1				to ctr-pat-mstr-writes. 
 
yb2-99-exit. 
    exit. 
 
yb7-write-hc-key. 
 
*mf    write inverted hc-pat-mstr-rec 
*mf	invalid key 
*mf	    go to err-hc-pat-mstr. 
 
yb7-99-exit. 
    exit. 
 
yb8-write-acr-key. 
 
*mf    write inverted acr-pat-mstr-rec 
*mf invalid key 
*mf	    go to err-acr-pat-mstr. 
 
yb8-99-exit. 
    exit. 
 
yb9-write-od-key. 
 
*mf    write inverted od-pat-mstr-rec 
*mf	invalid key 
*mf	    go to err-od-pat-mstr. 
 
yb9-99-exit. 
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

* MC8 - check to make sure birth date and version cd is valid before update for existing patients
    move 'Y'					to edit-flag.
    perform ba0-edit-birth-date-version-cd 	thru ba0-99-exit.
    if invalid-record
    then
	perform xa0-write-tp-error-report	thru xa0-99-exit
	go to yg0-99-exit.
*   endif

* MC8 - end
    

* 2004/02/25 - MC - store values from patient to f086-pat-id in case
*                   there is eligibility changes of the patient
    move spaces                                 to pat-id-rec.
    move ws-pat-surname                         to pat-old-surname.
    move ws-pat-given-name                      to pat-old-given-name.
    move ws-pat-health-nbr                      to pat-old-health-nbr.
    move ws-pat-chart-nbr                       to pat-old-chart-nbr.
    move ws-pat-chart-nbr-2                     to pat-old-chart-nbr-2.
    move ws-pat-chart-nbr-3                     to pat-old-chart-nbr-3.
    move ws-pat-chart-nbr-4                     to pat-old-chart-nbr-4.
    move ws-pat-chart-nbr-5                     to pat-old-chart-nbr-5.
    move ws-subscr-addr1                        to pat-old-addr1.
    move ws-subscr-addr2                        to pat-old-addr2.
    move ws-subscr-addr3                        to pat-old-addr3.

* 2004/02/25 - end
 
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
	move "N"		      to flag-1-vs-2-character-ver-cd.
*   endif

* 2008/01/10 - MC - comment redundant codes
*    move "N"                          to flag-change-version-cd.
*    move "N"			      to flag-old-version-cd.
* 2008/01/10 - end

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

* 2008/01/10 - MC - add the if condition before creating records in f086 & f011
    if   (    version-cd-changed 
	  and old-version-cd-doesnt-match
	 )
      or (    birth-date-changed
	  and old-birth-date-doesnt-match
	 )
    then
* 2008/01/10 - end
    perform yy0-process-pat-elig-change	thru yy0-99-exit.

* MC7
    move sys-date-long                  to ws-pat-date-last-maint.
* MC7 - end

    rewrite pat-mstr-rec 		from ws-pat-mstr-rec.

 
yg0-99-exit. 
    exit. 
 
*(yy0-process-pat-eligibility-change thru yy0-99-exit)
    copy "process_pat_eligibility_change.rtn"
	replacing ==clmhdr-pat-ohip-id-or-chart of claim-header-rec==
	       by ==tp-pat-ohip-health-no==.
 

    copy "y2k_default_sysdate_century.rtn".

 
