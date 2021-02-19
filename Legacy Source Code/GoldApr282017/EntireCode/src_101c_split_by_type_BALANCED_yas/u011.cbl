identification division. 
program-id.     u011. 
author.         m.so. 
installation.   dyad computer systems inc. 
date-written.   84/10/03. 
date-compiled. 
security. 
* 
*    files      : f010   - chedoke-mcmaster patient tape 
*		: f010   - patient master 
*		: f011   - pat mstr eligibility history
*		: f086   - corrected pat id
*		: f090   - constants master 
*		: ru011a - ERROR Report
*		: ru011b - AUDIT Report
*               : ru011c - Update EXCEPTIONS Report 
* 
*    PROGRAM PURPOSE : UPDATE PATIENT/SUBSCRIBER MASTER FILES FROM 
*                      CHEDOKE-MCMASTER PATIENT TAPE. 
* 
*__________________________________________________________________ 
* 
* 
*    REVISION HISTORY: 
* 
*  	85/12/06 (M.S.)	-  PDR 292 
*			-  MISSING IKEY VALUE IN THE DATA RECORD 
*			-  THE HOLD-PAT-MSTR-REC WAS DEFINED AS 
*			   127 INSTEAD OF 141 CHARACTERS 
*			-  77 -- ADD THE OHIP KEY WITH EXISTING RECORD 
*			-  88 -- ADD THE CHART KEY WITH EXISTING RECORD 
*			-  99 -- ADD THE NEW RECORD 
* 
*       87/05/28 (S.B.) - COVERSION FROM AOS to AOS/VS. 
*                         CHANGE FIELD SIZE FOR 
*                         STATUS CLAUSE TO 2 AND 
*                         FEEDBACK CLAUSE TO 4. 
* 
*   REVISED MARCH/89 : - SMS 115 S.F. 
*		       - MAKE SURE FILE STATUS IS PIC XX ,FEEDBACK IS 
*			 PIC X(4) AND INFOS STATUS IS PIC X(11). 
* 
* 
*   REVISED FEB/91   : - SMS 138  (B.M.L.) 
*                      - ADD HEALTH NUMBER AND USE IT AS THE PRIMARY 
*                        NUMBER FOR ALL ACTIONS. 
* 
*    REVISED MAY/91  : - SMS 138  (B.M.L.) 
*                      - TAKE STOP STATEMENT OUT OF PATIENT OHIP/DIRECT 
*                        TO AVOID STOPPING ON DUPLICATE DIRECT. 
* 
*    REVISED JUNE/91 : - (B.M.L.) 
*                      - SET HEALTH 65 IND TO "N" IF TAPE IS BLANK 
* 
*    REVISED OCT/91  : - (B.M.L.) 
*                      - REMOVED NON KEY EDIT CHECKS FOR C1 RECORD. 
* 
*    REVISED FEB/92  : - (Y.B.) 
*                      - CHANGED PHONE # FROM CHARACTER TO NUMERIC 
*                      - IN F010-TP-PAT-MSTR.FD 
* 
*    REVISED APR/92  : - PDR 551 (M.C.) 
*		       - CHANGED PHONE # BACK FROM NUMERIC TO 
*			 CHARACTER IN F010-TP-PAT-MSTR.FD 
*		       - IN CHANGE MODE, DO NOT INCLUDE AREA CODE, 
*			 ONLY UPDATE THE LOCAL PHONE NUMBER 
* 
*    REVISED APR/93  : - PDR 568 (AGK) 
*                        TEST VERSION CODE OF RMA AGAINST TAPE 
*                        AND MAKE AN EXCEPTIONS REPORT RU011C 
*                      - ADD VERSION CODE EDIT FOR NUMERIC OR CASE 
* 
*    REVISED JUN/93  : - PDR 574 (BML) 
*                      - ADDED ADDRESS UPDATE IN CHANGE MODE 
* 
*    REVISED AUG/93  : - PDR 574 (M.C.) 
*		       - STRING CITY AND PROVINCE WITH ONE SPACE 
*    98/Sep/10 	B.E.  - converted to unix
*    98/Sep/28  B.E.  - wrong error message being printed when HEALTH CARE
*		        doesn't check digit correctly. New message added.
*    98/Oct/17	B.E   - added temp work around to problem of too many
*			duplicate keys (blanks ohip nbrs / blank chart nbrs)
*			  by defaulting the -Ikey nbr to these fields.
*    98/Oct/20  B.E.  - changed print of error message table to include
*			last new message. Added variable to contain this nbr
*			so that it can be changed if table size increased.
* 99/jan/21 B.E.      - y2k
*                     - don't allow different version cd on tape to
*                       update RMA database, write to error report
* 99/nov/22 B.E.      - y2k change from MUMC - increase size of patient's
*			birth date. also told to removed all edits of the
*			chart number against the patient's birth date.
* 00/jan/24 B.E.      - if the incoming patient birth date or version code 
*			is not blank/zero and differs from RMA database values
*			then update RMA database with these new values.
* 00/mar/08 B.E.      - changed jan/24 change above, so that the incoming
*			version code/birth date is used to update the RMA
*			database UNLESS the incoming value is the same as RMA's
*			old value (in which case we assume that the incoming
*			value is out of date and RMA has updated the local
*			database with newer info). Error codes 26/27 added
*			to record any time RMA database not updated due to 
*			this reason.
*		       - a 1 character incoming version code will not update an
*			 existing RMA two character version code because
*			 OHIP never assigns a 1 character code to patient after
*			 giving them a 2 character code.
* 00/oct/02 B.E.	- added call to copy book code yy0- to process 
*			  changes to patient eligibility information to 
*			  not only update patient, but also to blank out any
*			  eligibility messages on the patient, to update
*			  the f086 corrected patient master and to update
*			  the f011 patient eligibility history file
* 01/mar/08 B.E.	- changed to copybook and shared with newu703.cbl
*			 copybook file - "hold_patient_info.ws"
*  02/mar/28 M.C.	- add edit check against chart nbr with alpha 'M', 'K', 'H' or '0' with 9 digits
*  02/apr/09 M.C.	- General chart nbr must start with '0001' or '0005' follow by 6 digits
*  02/apr/29 B.E.	- blank error message print line so that error values
*			  don't carry over to next print line.
*			- removed some of the 'display' statements so that
*			  when running online it doesn't clear the screen
*  02/apr/29 M.C.	- Although currently not uploading St. Joseph patients 
*			  via u011, but include the 
*		          edit check on St. Joseph chart nbr for the future, 
*			  it should start with 'J' +  10 digits
*			- make the correction in dc0-change subroutine for
*			  birth date and/or version cd
*			- make correction in aa0 & xe0 subroutines for 
*			  rundate and syspage
*  02/May/01 M.C.	- Yas requests to reject record if birth date > system 
*			  date or birth year < 1880
*			- Brad requests to update nbr of changes not 
*			  done - modify in dc0-change-check.
*  02/Dec/06 M.C.	- Modify the program to store the chart nbr accordingly
*			  based on the hospital site
*			- update patients' surname and first name if changes
*  03/feb/14 B.E.	- added open/close statement for pat-elig-history
*  03/feb/26 B.E.	- removed code shared between u011 and cpirma.cbl and
*			  moved into process_mrn_containing_ikey_values.ws/.rtn
*  03/apr/08 M.C.	- moved into set_blank_mrn_with_ikey_values.rtn
*  04/jan/29 M.C.	- change prov from NF to NL according to MOH
*  04/feb/19 M.C.       - move the sequence of calling yy0 subroutine
*  04/feb/25 M.C.       - preset the values in f086-pat-id before determining there
*                         is eligibility change for the patient in dc0-change-check
*                       - add open/close on corrected-pat
*  08/jan/10 M.C.	- only create records in f086 & f011 IF birth date or
*			  version code is different for both current and old values in database
*  08/jan/16 M.C. 	- Brad reqested to change from 'NUMBER OF PATIENTS ON TAPE' to 
*			  'NUMBER OF RECORDS ON TAPE'
*  09/oct/06 b.e.	- started process of creating an output file of all 'accepted' patient records - this file to 
*			  be used to upload these new/updated patients to the web
*  09/oct/20 MC1 	- move to sequence-nbr-num instead of sequence-nbr   
*			- transfer ye0 subroutine either to the end of yb1-write-patient or yc6-rewrite-patient subroutines
*  10/Jan/18 MC2	- add edit-chart-flag, add records as long as with valid health number/RMB number even with
*			  bad chart key (ie blank out bad chart key)
*  14/Feb/10 MC3        - add more edit on the incoming chart nbrs
*			chart-nbr    -  'M' , 'W'
*			chart-nbr-2  -  'K'
*			chart-nbr-3  -  'H002', 'H003'
*			chart-nbr-4  -  '0001', '0005', 'D', 'E', 'F', 'ZB'
*			chart-nbr-5  -  'J'+10, 'J'+8
*
*      		D = Haldimand War Memorial Hospital, Dunnville
*		E = West Haldimand Hospital, Hagersville
*		F = St. Peter's Hospital, Hamilton
*		W = West Lincoln Memorial Hospital - Grimsby
*		ZB = Bay Area Genetics Lab
*
*	W = Store it in the chart-nbr IF no MUMC exists in this slot already
*
*	ZB  - If we receive ZB from u011 - store it in the chart-nbr-2 column IF there is no K in this slot already.  
*	      We should move the ZB's to chart-nbr-2 if no K's
*
*	D, E, F and W = Store it in the chart-nbr-4 IF no "0001" or "0005" exists in this slot already
*
*	IF there is Joseph Brant  (J+8) , store in the chart-nbr 5   if st josephs (J+10) does not exists
*
*	Also, set province = 'ON' if blank from incoming file
*------------------------------------------------------------------------------------------------------------
*  14/May/07 MC4        - do not update address if they are blank or contain '.' for exist patients
*                       - modify individual data field check in dc0 subroutine 
*                       - if incoming province is '.' or '..', set province = 'ON' 
*                       - if incoming province is invalid ,    set province = 'ON' 
*			- if invalid chart, continue to check the remaining fields by 
*			  go to ba0-10-cont-edit-patient.
*------------------------------------------------------------------------------------------------------------
*  15/Sep/24 MC5        - additional check on version cd to make sure it is alpha from 'A ' to 'ZZ';
*                         otherwise provide error  17, modify in dd0 subroutine
*------------------------------------------------------------------------------------------------------------
*  15/Oct/28 MC6	- modify $use/process_mrn_containing_ikey_values.ws, $use/process_mrn_containing_ikey_values.rtn
*			  and $use/set_blank_mrn_with_ikey_values.rtn to set pat-chart-nbr-4 to be '?' + ikey[7:9] if blank
* 
*    GENERAL NOTES: 
* 
*    G.1 - IF THERE IS NO OHIP OR CHART, IT IS AN ERROR. 
*	   (IE. DIRECT BILL NOT CREATED AS PER M010) 
* 
* ?? G.2 - DO NOT ALLOW CHANGES TO OHIP NUMBER. 
* 
* ?? G.3 - DO NOT ALLOW CHANGE TO THE DATE OF BIRTH IF OHIP. 
* 
* ?? G.4 - FOR CHART ONLY, IF THE KEY OF 'C1' RECORD DOES NOT EXIST, 
*	   ADD AS NEW 'C2' RECORD. 
*__________________________________________________________________ 
* 
*   ADD MODE NOTES: 
* 
*      'ADD' RECORDS ARE RECOGNIZED BY 'AA' IN FUNC-CODE FIELD. 
* 
*	THE CHART ON THE NEXT PAGE SHOWS WHAT ARE THE KEYS FROM THE 
*       INCOMING TAPE (D.E.C PATIENT TAPE), ACCESS PAT-MSTR AND 
*	SUBSCR-MSTR TO DETERMINE IF THEY EXIST OR NOT, AND SHOW 
*	THE CORRESPONDING RESULTS. 
* 
*       LEGEND:    O = OHIP 
*		   C = CHART 
*		  IN = KEY(S) FROM THE INCOMING TAPE 
*		 PAT = DETERMINE WHETHER KEY(S) EXIST(S) IN PAT-MSTR 
*	      SUBSCR = DETERMINE WHETHER KEY(S) EXIST(S) IN SUBSCR-MSTR 
*	      RESULT = SHOW THE CORRESPONDING RESPONSE 
* 
* 
*	"*"  -  FOR 'ADD' RECORDS ONLY, IF RELATIONSHIP = 1, NOT ONLY 
*	   	UPDATE "#-OF-PAT" BUT ALSO UPDATE ALL SUBSCR DATA. 
* 
*_______________________________________________________________________ 
environment division. 
input-output section. 
file-control. 
* 
*   PLACE YOUR FILE SELECT STATEMENTS HERE 
* 
    copy "f010_tp_patient_mstr.slr". 
* 
    copy "f010_new_patient_mstr.slr". 
*
*mf copy "F010_NEW_PATIENT_MSTR_OD.SLR". 
*mf copy "F010_NEW_PATIENT_MSTR_HC.SLR". 
*mf copy "F010_NEW_PATIENT_MSTR_ACR.SLR". 
*mf copy "F010_NEW_PATIENT_MSTR_CHRT.SLR". 
*
    copy "f011_pat_mstr_elig_history.slr".
*
* 2004/02/26 - MC - use copybook instead
*select corrected-pat
*        assign        to "$HOME/f086_pat_id.d003"
*        file status   is status-corrected-pat.
    copy "f086_pat_id.slr".
* 2004/02/26 - end
*
*
    copy "f090_constants_mstr.slr". 

*   brad1
    select tp-pat-mstr-out
        assign to tp-patient-file-name-out
        organization is sequential   
        access mode  is sequential   
        status       is status-cobol-tp-pat-mstr-out. 
*       infos status is status-tp-pat-mstr.   
*       eof-flag     is eof-tp-pat-mstr  
 
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
    copy "f010_tp_pat_mstr.fd". 
* 
    copy "f010_patient_mstr.fd". 
*
    copy "f011_pat_mstr_elig_history.fd".
* 
*mf copy "F010_PATIENT_MSTR_OD.FD". 
*mf copy "F010_PATIENT_MSTR_HC.FD". 
*mf copy "F010_PATIENT_MSTR_ACR.FD". 
*mf copy "F010_PATIENT_MSTR_CHRT.FD". 
* 
* brad1
fd tp-pat-mstr-out 
              block  contains 512 characters 
              record contains 210 characters.
01 tp-pat-mstr-rec-out.
   05 sequence-nbr				pic x(6).
   05 sequence-nbr-num redefines sequence-nbr	pic 9(6).
   05 tp-pat-mstr-rec-out-orig			pic x(204).
*
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
 
77  tp-patient-file-name			pic x(26) 
		                            value "meditech_patient_file.u011".
*		                            value "mac_patient_file". 
* brad1
77  tp-patient-file-name-out			pic x(26) 
		                            value "meditech_patient_file.out".
77  print-file-name-a				pic x(9) 
		                                value "ru011a". 
77  print-file-name-b				pic x(9) 
		                                value "ru011b". 
77  print-file-name-c				pic x(9) 
		                                value "ru011c". 

77  feedback-iconst-mstr 			pic x(4). 
77  feedback-tp-pat-mstr 			pic x(4). 

* (indicates the 'site' or hospital for which the MRN/chart nbr applies)
01  mrn-site 	          			pic x(01).
    88 mrn-is-mumc                      		value "m".
    88 mrn-is-chedoke                   		value "c".
    88 mrn-is-henderson                 		value "h".
    88 mrn-is-general                   		value "g".
    88 mrn-is-stjoes                    		value "s".

* MC3
    88 mrn-is-Haldimand-War				value "d".
    88 mrn-is-West-Haldimand				value "e".
    88 mrn-is-Stpeter        		                value "f".
    88 mrn-is-West-Lincoln   		                value "w".
    88 mrn-is-Bay-Area       		                value "z".
    88 mrn-is-Stjoe-Brant    		                value "b".

01  ws-rma-chart-nbr.
    05  ws-rma-chart-site			pic x.
    05  ws-rma-chart-2-4			pic x(3).
    05  ws-rma-chart-5-11.
        10 ws-rma-chart-5-9			pic x(5).
	10 ws-rma-chart-10-11			pic xx.

* MC3 - end

* 
*   (SUBSCRIPTS.) 
* 
77  sub    					pic 99 comp. 
77  err-ind					pic 99 value zero. 
77  space-ctr					pic 99 value zero. 
* 
*   (CHECK OHIP NBR'S VARIABLES.) 
* 
77  ws-val-total				pic 9(4). 
77  dummy					pic 9(3). 
77  rem-even					pic 9v9(4). 
77  max-nbr-digits				pic 99. 
* 
*   (STATUS FILE INDICATORS.) 
* 
01  status-indicators. 
    05  status-file				pic x(11). 
    05  status-pat-mstr				pic x(11) value "0". 
    05  status-tp-pat-mstr			pic x(11) value "0". 
*   brad1
    05  status-tp-pat-mstr-out			pic x(11) value "0". 

    05  status-pat-mstr-od			pic x(11) value "0". 
    05  status-pat-mstr-hc			pic x(11) value "0". 
    05  status-pat-mstr-acr			pic x(11) value "0". 
    05  status-pat-mstr-chrt			pic x(11) value "0". 
    05  status-iconst-mstr			pic x(11) value "0". 
    05  status-audit-rpt-a			pic xx    value "0". 
    05  status-audit-rpt-b			pic xx    value "0". 
    05  status-audit-rpt-c			pic xx    value "0". 
    05  status-cobol-tp-pat-mstr                pic xx    value "0". 
*   brad1
    05  status-cobol-tp-pat-mstr-out            pic xx    value "0". 

    05  status-cobol-pat-mstr.
        10  status-cobol-pat-mstr1              pic x   value "0".
        10  status-cobol-pat-mstr2              pic x   value "0".
    05  status-cobol-pat-mstr-bin
                redefines status-cobol-pat-mstr pic 9(4) comp.
*   brad1
    05  status-cobol-pat-mstr-out.
        10  status-cobol-pat-mstr1-out          pic x   value "0".
        10  status-cobol-pat-mstr2-out          pic x   value "0".
    05  status-cobol-pat-mstr-bin-out
                redefines status-cobol-pat-mstr-out pic 9(4) comp.


    05  status-cobol-display.
        10 status-cobol-display1                pic x.
        10 filler                               pic x(3).
        10 status-cobol-display2                pic 9(4).

    05  status-cobol-pat-elig-history.
        10  status-cobol-pat-elig-history1      pic x   value "0".
        10  status-cobol-pat-elig-history2      pic x   value "0".

    05  status-corrected-pat			pic x(2) value "0".
    
    05  status-cobol-iconst-mstr		pic xx	  value "0".
*mf 05  status-cobol-pat-mstr-od		pic xx    value "0". 
*mf 05  status-cobol-pat-mstr-hc		pic xx    value "0". 
*mf 05  status-cobol-pat-mstr-acr		pic xx    value "0". 
*mf 05  status-cobol-pat-mstr-chrt		pic xx    value "0". 


* 
*   (STRING RELATED.) 
* 
*2002/04/22 - MC
*01  ws-i-last-name				pic x(15). 
01  ws-i-last-name				pic x(24). 
01  ws-i-first-name. 
    05  ws-i-first-name-1			pic x. 
    05  ws-i-first-name-11			pic x(11). 
*2002/04/22 - MC
    05  ws-i-first-name-12		        pic x(12).
*2002/04/12 - end	
 
01  ws-i-street-addr. 
    05  ws-i-street-addr1			pic x(21). 
    05  ws-i-street-addr2			pic x(7). 
 
01  ws-i-city-prov. 
    05  ws-i-city				pic x(16). 
    05  filler      				pic x. 
    05  ws-i-prov				pic x(4). 
 
01  ws-i-detail. 
    05  ws-i-detail-field			pic x(28). 
    05  ws-i-detail-field-r       redefines	ws-i-detail-field. 
	10  ws-i-detail-byte 			pic x 
				occurs 28 times. 
 
01  ws-i-phone-no. 
    05  ws-i-area-code				pic x(3). 
    05  ws-i-local-phone-no			pic x(7). 
    05  phone-filler				pic x(10).

copy "process_mrn_containing_ikey_values.ws".

*  (2001/mar/08 changed to copybook and shared with newu703.cbl)
   copy "hold_patient_info.ws". 
01  hold-pat-ikey.
    05  hold-iconst-con-nbr                     pic 99.
    05  hold-iconst-nx-ikey                     pic 9(12).

*2002/05/01 - MC

01  test-birth-date.
    05  test-birth-yy				pic 9(4).
    05  test-birth-mm				pic 9(2).
    05  test-birth-dd				pic 9(2).

* 2002/12/06 -- MC
*01  ikey				       pic x(12).
01  ikey				       pic x(11).
* 2002/12/06 - end

*2002/05/01 - end
 
* 
*   (FILES' FLAGS.) 
* 
01  eof-tp-pat-mstr                         	pic x. 
    88  eof-tape                                value "Y". 
    88  not-eof-tape                            value "N". 
 
01  pat-flag                            	pic x. 
    88  pat-exist                  		value "Y". 
    88  pat-not-exist            		value "N". 


01  pat-change-flag                             pic x.
    88  pat-change                                      value "Y".
    88  pat-not-change                                  value "N".

01  flag-change-version-cd			pic x.
    88  version-cd-changed			value "Y".
    88  version-cd-not-changed			value "N".
01  flag-old-version-cd                         pic x.
    88  old-version-cd-matches                          value "Y".
    88  old-version-cd-doesnt-match                     value "N".

01  flag-birth-date-change			pic x.
    88  birth-date-changed			value "Y".
    88  birth-date-not-changed			value "N".
01  flag-old-birth-date                         pic x.
    88  old-birth-date-matches                          value "Y".
    88  old-birth-date-doesnt-match                     value "N".

01  flag-1-vs-2-character-ver-cd                pic x.
    88  one-char-ver-cd-vs-2-char                       value "Y".

01  subscr-flag                                 pic x. 
    88  subscr-exist                            value "Y". 
    88  subscr-not-exist                        value "N". 
 
* 
*   (MISC FLAGS.) 
* 
01  edit-flag                                   pic x. 
    88  valid-record                            value "Y". 
    88  invalid-record                          value "N". 
 
* 2010/01/18- MC2
01  edit-chart-flag                             pic x. 
    88  valid-chart-key                         value "Y". 
    88  invalid-chart-key                       value "N". 
* 2010/01/18 - end
 
01  province-flag				pic x. 
    88  province-found				value "Y". 
    88  province-not-found  			value "N". 
 
01  health-flag					pic x. 
    88  valid-health				value "Y". 
    88  invalid-health				value "N". 
 
01  ohip-flag					pic x. 
    88  valid-ohip				value "Y". 
    88  invalid-ohip				value "N". 
 
01  ohip-chart-flag				pic x. 
    88  chart-to-ohip				value "Y". 
    88  ohip-to-chart				value "N". 
 
01  chart-flag 					pic x. 
    88  chart-change 				value "Y". 
    88  chart-not-change 			value "N". 
    88  chart-add    				value "A". 
 
*   (COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES.) 
 
01  counters. 
    05  ctr-pat-mstr-no-update			pic 9(7). 
    05  ctr-tp-pat-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-writes			pic 9(7). 
    05  ctr-pat-mstr-out-writes			pic 9(7). 
    05  ctr-write-corrected-pat			pic 9(7).
    05  ctr-good-c1                      	pic 9(7). 
    05  ctr-pat-mstr-rewrites			pic 9(7). 
    05  ctr-write-pat-elig-hist                 pic 9(7).
    05  ctr-error-rpt-writes			pic 9(7). 
    05  ctr-warnings-rpt-writes			pic 9(7). 
    05  ctr-audit-rpt-writes			pic 9(7). 
    05  ctr-exception-rpt-writes		pic 9(7). 
    05  ctr-page-a                              pic 9(3). 
    05  ctr-page-b                              pic 9(3). 
    05  ctr-page-c                              pic 9(3). 
    05  ctr-reject                              pic 9(2). 
    05  ctr-warning				pic 9(2). 
    05  ctr-exception				pic 9(2). 
    05  ctr-audit  				pic 9(2). 
    05  ctr-update				pic 9(2).
 
    COPY "mod_check_digit.ws". 
 
*   COPY "F010_WS_PAT_MSTR.WS". 

    copy "f010_ws_tp_pat_mstr.ws". 
    copy "f010_patient_mstr.ws". 
 
* 01  HOLD-PAT-MSTR-REC			PIC X(141). 

*2002/11/28 - MC - not used
*01  hold-pat-mstr-rec			pic x(260). 
*2002/11/28 - end
 
01  ws-save-id-no. 
    05  ws-save-id-no-alpha		pic x.
    05  ws-save-id-no-first-8-digits. 
	10  ws-save-id-no-yy		pic 99. 
	10  ws-save-id-no-mm		pic 99. 
	10  ws-save-id-no-5-6-digit	pic 99. 
	10  ws-save-id-no-7-digit  	pic 9. 
	10  ws-save-id-no-8-digit  	pic 9. 
    05 ws-save-id-no-9-digit  		pic x. 

* 2010/01/18 - MC2 
01  ws-stjoe-id-no. 
    05  ws-stjoe-id-no-alpha 		pic x  value 'J'.
    05  ws-stjoe-id-no-pos-1		pic 9.           
    05  ws-stjoe-id-no-pos-2-10		pic x(9).  
* 2010/01/18 - end
 
01  ws-xx				pic xx value "  ". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"FUNC CODE MUST BE AA-ADD OR (C1 OR C2)-CHANGE". 
	10  filler				pic x(60)   value 
			"HEALTH NBR,OHIP NO AND ID NO CAN'T BE ALL BLANK". 
	10  filler				pic x(60)   value 
			"SURNAME CAN'T BE BLANK ". 
	10  filler				pic x(60)   value 
			"Version Code can't be NUMERIC".
 
*    MSG 05    * 
 
	10  filler				pic x(60)   value 
			"FIRST NAME CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"HEALTH NBR,OHIP NO CAN'T BE ALL BLANK". 
	10  filler				pic x(60)   value 
			"INVALID YEAR, MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"INVALID MONTH, MUST BE NUMERIC". 
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
		        "MRN contains characters where numerics expected".
	10  filler				pic x(60)   value 
		        "MRN contains numerics where spaces expected". 
*    MSG 17
	10  filler				pic x(60)   value 
* MC5
*			"can be re-used". 
			"Version Code must be ALPHA".
* MC5 - end
*    MSG 18 
	10  filler				pic x(60)   value 
			"can be re-used". 

	10  filler				pic x(60)   value 
			"can be re-used".

*   MSG 20   * 
	10  filler				pic x(60)   value 
			"can be re-used".
	10  filler				pic x(60)   value 
			"STREET ADDRESS  CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"CITY CAN'T BE BLANK". 
	10  filler				pic x(60)   value 
			"Birth date can't be  >  run date or birth year <  1880".
	10  filler				pic x(60)   value 
			"PROV CAN'T BE BLANK". 
 
*   MSG 25   * 
	10  filler				pic x(60)   value 
			"INVALID PROVINCE - NOT FOUND FROM THE TABLE". 
	10  filler				pic x(60)   value 
			"NOT changing incoming VERSION Code because = OLD RMA value".
	10  filler				pic x(60)   value 
			"NOT changing incoming  Birth Date  because = OLD RMA value".
	10  filler				pic x(60)   value 
			"SPARE                       ". 
	10  filler				pic x(60)   value 
			"OHIP NUMBER MUST BE NUMERIC". 
 
*   MSG 30   * 
	10  filler				pic x(60)   value 
			"INVALID OHIP NUMBER". 
	10  filler				pic x(60)   value 
			"HEALTH NUMBER MUST BE NUMERIC". 
	10  filler				pic x(60)   value 
			"ADDING PATIENT BUT PATIENT HEALTH NBR ALREADY EXISTS". 
	10  filler				pic x(60)   value 
			"INVALID HEALTH CARE NUMBER". 
	10  filler				pic x(60)   value 
			"FIRST RECORD IS C2, IT IS NOT ALLOWED". 
 
*   MSG 35   * 
 
	10  filler				pic x(60)   value 
			"Non St. Joe chart nbr must have 9 digits after the prefix".
	10  filler				pic x(60)   value 
			"PATIENT OHIP KEY ALREADY EXISTS CAN'T ADD PATIENT". 
	10  filler				pic x(60)   value 
			"HEALTH NBR CAN'T EXIST WITH NON-ONTARIO PATIENT". 
	10  filler				pic x(60)   value 
			"PATIENT CHART KEY ALREADY EXISTS CAN'T ADD PATIENT ". 
	10  filler				pic x(60)   value 
			"St. Joe chart nbr must have 10 digits after the prefix 'J'".
 
*   MSG 40   * 
 
	10  filler				pic x(60)   value 
			"Non-Ontario patients MUST have a Registration Number     ". 
	10  filler				pic x(60)   value 
			"The ACRONYM key EXISTS, but database corrupted in AA record". 
	10  filler				pic x(60)   value 
			"Adding a HEALTH CARE Number to existing patient (was #66)".
	10  filler				pic x(60)   value 
			"Adding a new OHIP Nbr to existing patient (previously #77)". 
	10  filler				pic x(60)   value 
			"Adding a new CHART Nbr to existing patient (previously #88)". 
 
*   MSG 45   * 
 
	10  filler				pic x(60)   value 
			"FYI only - new patient added (previously message #99)".
	10  filler				pic x(60)   value 
* 			"chart nbr prefix must be 'M', 'K', 'H' or '0' ".
*			"chart nbr prefix must be 'M', 'K', 'H', '1' or '5' ".
* MC3
* 			"chart nbr prefix must be 'M', 'K', 'H' or '0' or 'J' ".
 			"chart nbr prefix must be M,K,H,0,J,D,E,F,W,ZB".
* MC3 - end
	10  filler				pic x(60)   value 
			"chart nbr must be 9 digits after the prefix".
	10  filler				pic x(60)   value 
			"chart nbr is longer than 11 characters".
	10  filler				pic x(60)   value 
			"Henderson chart nbr must start either H002 or H003".
 
*   MSG 50   * 
 
	10  filler				pic x(60)   value 
			"ATTEMPTING TO CHANGE HEALTH NBR- THIS NUMBER ALREADY ON FILE". 
	10  filler				pic x(60)   value 
			"THE NEW ACRONYM (C2) EXISTS, BUT DATABASE CORRUPTED". 
	10  filler				pic x(60)   value 
			"General chart nbr must start either 0001 or 0005".
	10  filler				pic x(60)   value 
			"C1 KEY NOT EXIST, ATTEMPTING TO ADD C2 CHART BUT IT EXISTS". 
	10  filler				pic x(60)   value 
			"** ERROR ** - DUPLICATE IKEY - CONTACT DYAD IMMEDIATELY". 
*   MSG 55   * 
        10  filler                              pic x(60)   value
                        "New Patient ADDED to Patient Master (previously #99)".
        10  filler                              pic x(60)   value
                        "Patient BIRTH DATE changed".
        10  filler                              pic x(60)   value
                        "Patient VERSION CODE changed".
        10  filler                              pic x(60)   value
                        "Patient BIRTH DATE and VERSION CODE changed".
        10  filler                              pic x(60)   value
                        "Patient OTHER THAN the Birth Date/Version Code changed".
 
    05  error-messages-r redefines error-messages. 

	10  err-msg				pic x(60) 
			occurs 59 times. 
01 ws-max-nbr-messages-in-tbl			pic 99
			value  59.
 
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
 
    05  province-r   		 redefines      province. 
 
	10  prov                 occurs 13 times. 
            15  old-prov			pic x(4). 
	    15  new-prov			pic x(2). 

COPY "sysdatetime.ws". 
 
 
01  h1-head. 
 
* 2002/05/02 - MC
*    05  filler                                  pic x(35)  value "RU011A". 
    05  filler                                  pic x(33)  value "RU011A". 
* 2002/05/02 - end
    05  filler                                  pic x(63)  value 
			   "Patient Transfer File - Upload ERROR Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
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
                           "BIRTH DTE SEX". 
*    05  filler                                  pic x(22)  value 
*                          "ID NO    OHIP  NO". 
    05  filler                                  pic x(27)  value 
                           "ID NO         OHIP  NO". 
*    05  filler                                  pic x(32)  value 
    05  filler                                  pic x(27)  value 
                           " HEALTH NUMBER             ". 
 
 
01  h3-head. 
 
* 2002/05/02 - MC
*    05  filler                                  pic x(35)  value "RU011B". 
    05  filler                                  pic x(33)  value "RU011B". 
* 2002/05/02 - end
    05  filler                                  pic x(63)  value 
*			   "CHEDOKE-MCMASTER WARNING REPORT". 
			   "Patient Transfer File - Upload  AUDIT Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
    05  h3-run-date                             pic x(10). 
    05  filler					pic x(5)   value spaces. 
    05  filler                                  pic x(7)   value "  PAGE". 
    05  h3-page-no                              pic zz9. 
 
01  h4-head. 
 
* 2002/05/02 - MC
*    05  filler                                  pic x(35)  value "RU011C". 
    05  filler                                  pic x(33)  value "RU011C". 
* 2002/05/02 - end
    05  filler                                  pic x(63)  value 
*			   "VERSION CODE EXCEPTIONS REPORT". 
			   "Patient Transfer File -  Update EXCEPTIONS Report". 
 
    05  filler                                  pic x(11)  value 
                           "RUN DATE :". 
    05  h4-run-date                             pic x(10). 
    05  filler					pic x(5)   value spaces. 
    05  filler                                  pic x(7)   value "  PAGE". 
    05  h4-page-no                              pic zz9. 

01  h5-head.

    05  filler                                  pic x(10)  value spaces.
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
        10  l1-yy                               pic 9(4).
        10  l1-slash1                           pic x. 
        10  l1-mm                               pic 99. 
        10  l1-slash2                           pic x. 
        10  l1-dd                               pic 99. 
    05  filler                                  pic x(1). 
    05  l1-sex                                  pic x. 
    05  filler                                  pic x(3). 
*    05  l1-id-no                                pic x(9). 
    05  l1-id-no                                pic x(15).
    05  filler                                  pic x(2). 
    05  l1-ohip-no                              pic x(8). 
    05  filler                                  pic xxxx. 
    05  l1-health-nbr                           pic x(10). 
*    05  filler                                  pic x(23). 
    05  filler                                  pic x(17). 
 
 
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
    05  filler                                  pic x(11) 
                                                value "    PHONE: ". 
    05  l2-phone-no                             pic x(20). 
* 2002/12/06 - MC
*   05  filler                                  pic x(22) 
    05  filler                                  pic x(12) 
* 2002/12/06 - end
                                                value "  VERSION:  ". 
    05  l2-version-cd                           pic xx. 
* 2002/12/06 - MC
*   05  filler                                  pic x(16) 
*                                               value "    MESSAGE ID: ". 
    05  filler                                  pic x(12) 
                                                value "   MESSAGE: ". 
* 2002/12/06 - end
    05  l2-mess-id                              pic x(2). 
 
 
01  l3-line					pic x(132). 
 
 
01  l4-line. 
 
    05  l4-title                                pic x(45). 
* 2003/01/08 - MC
*    05  l4-ctr                                  pic zzz9. 
*    05  filler                                  pic x(83). 
    05  l4-ctr                                  pic zzzz9. 
    05  filler                                  pic x(82). 
* 2003/01/08 - end
 
01  l5-line. 
 
    05  filler                                  pic x(20)      value 
                        "TAPE VERSION CODE:". 
    05  l5-tp-pat-version-cd                    pic xx. 
    05  filler                                  pic x(30)      value 
               "          RMA VERSION CODE:". 
    05  l5-ws-pat-version-cd                    pic xx. 
    05  filler                                  pic x(25)      value 
               "          CHART NUMBER:". 
    05  l5-chart-nbr                            pic x(30). 
    05  filler                                  pic x(16) 
                                                value "    MESSAGE ID: ". 
    05  l5-mess-id                              pic x(2). 


01  prt-det-line1.
    05  prt-lit1                                pic x(10) value spaces.
    05  prt-ohip-health-nbr                     pic x(12).
    05  filler                                  pic x(09) value spaces.
    05  rma-birth-date-yy                       pic 9(4).
    05  filler                                  pic x(1) value "/".
    05  rma-birth-date-mm                       pic 9(2).
    05  filler                                  pic x(1) value "/".
    05  rma-birth-date-dd                       pic 9(2).
    05  filler                                  pic x(09) value spaces.
    05  rma-version-cd                          pic xx.
    05  filler                                  pic x(10) value spaces.
    05  rma-prov-cd                             pic xx.
    05  filler                                  pic x(10) value spaces.
    05  rma-reason-desc                         pic x(60) value spaces.


01  prt-det-line2.
    05  prt-lit2                                pic x(10) value spaces.
    05  disk-doctor-nbr                         pic 9(6).
    05  disk-account-id                         pic x(08) value spaces.
    05  filler                                  pic x(07) value spaces.
    05  disk-birth-date-yy                      pic 9(4).
    05  filler                                  pic x(1) value "/".
    05  disk-birth-date-mm                      pic 9(2).
    05  filler                                  pic x(1) value "/".
    05  disk-birth-date-dd                      pic 9(2).
    05  filler                                  pic x(09) value spaces.
    05  disk-version-cd                         pic xx.
    05  filler                                  pic x(10) value spaces.
    05  disk-prov-cd                            pic xx.
    05  filler                                  pic x(70) value spaces.




screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 12 col 16 value "PATIENT TRANSFER NOW BEING PROCESSED". 
* 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
    05  line 24 col 70	pic x(11) from status-file	bell blink. 
* 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U011 ENDING". 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
    05  line 23 col 10	value "AUDIT REPORTS ARE IN FILES - ". 
    05  line 23 col 43	pic x(8) from print-file-name-a. 
    05  line 23 col 51  value "&". 
    05  line 23 col 54  pic x(8) from print-file-name-b. 
    05  line 23 col 65  value "&". 
    05  line 23 col 68  pic x(8) from print-file-name-c. 
procedure division. 
declaratives. 
 
err-tp-pat-mstr-file section. 
    use after standard error procedure on tp-pat-mstr. 
err-tp-pat-mstr. 
    stop "ERROR IN ACCESSING TP PATIENT MASTER". 
    move status-tp-pat-mstr    		to status-file. 
    display file-status-display. 
    stop " ". 
    move status-cobol-tp-pat-mstr       to status-file. 
    display file-status-display. 
    stop run. 

* brad1
err-tp-pat-mstr-file-out section.
    use after standard error procedure on tp-pat-mstr-out.
err-tp-pat-mstr-out.
    stop "ERROR IN ACCESSING TP PATIENT OUT FILE".
    move status-tp-pat-mstr-out         to status-file.
    display file-status-display.
    stop " ".
    move status-cobol-tp-pat-mstr-out   to status-file.
    display file-status-display.
    stop run.
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
    stop "ERROR IN ACCESSING PATIENT MASTER I-KEY". 
    move status-pat-mstr   		to status-file. 
    display file-status-display. 
    stop " ". 
    move status-cobol-pat-mstr          to status-file. 
    display file-status-display. 
    stop run. 
 
*mf err-pat-mstr-file-od section. 
*mf   use after standard error procedure on od-pat-mstr. 
*mferr-od-pat-mstr. 
*mf   stop "ERROR IN ACCESSING PATIENT MASTER O/D". 
*mf   move status-pat-mstr-od		to status-file. 
*mf   display file-status-display. 
*mf   move status-cobol-pat-mstr-od       to status-file. 
*mf   display file-status-display. 
*mf   stop run. 
 
*mf err-pat-mstr-file-hc section. 
*mf   use after standard error procedure on hc-pat-mstr. 
*mf err-hc-pat-mstr. 
*mf    stop "ERROR IN ACCESSING PATIENT MASTER H/C". 
*mf    move status-pat-mstr-hc		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf    move status-cobol-pat-mstr-hc       to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf    display tp-pat-func-code, tp-pat-health-nbr. 
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
 
*mf err-pat-mstr-file-chrt section. 
*mf    use after standard error procedure on chrt-pat-mstr. 
*mf err-chrt-pat-mstr. 
*mf    stop "ERROR IN ACCESSING PATIENT MASTER CHRT". 
*mf    move status-pat-mstr-chrt		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
*mf    move status-cobol-pat-mstr-chrt     to status-file. 
*mf    display file-status-display. 
*mf    stop run. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    stop "ERROR IN ACCESSING CONSTANT MASTER". 
    move status-iconst-mstr		to status-file. 
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
    perform y2k-default-sysdate         thru y2k-default-sysdate-exit.
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
 
    open input 	tp-pat-mstr. 
    open i-o  	pat-mstr 
	        iconst-mstr
		pat-elig-history.
*mf                od-pat-mstr 
*mf                hc-pat-mstr 
*mf                acr-pat-mstr 
*mf                chrt-pat-mstr 

*   brad1
    open output  tp-pat-mstr-out.

* 2004/02/25 - MC
    open extend corrected-pat.
* 2004/02/25 - end

 open output audit-file-a 
    		audit-file-b 
    		audit-file-c. 
 
    move 0  				to counters. 
 
*   (PRINT OUT THE MESSAGE TABLE ON THE FIRST PAGE OF THE REPORT.) 
 
    add 1 				to ctr-page-a. 
    move run-date			to h1-run-date 
				           h4-run-date
					   h3-run-date. 
    move ctr-page-a			to h1-page-no. 
 
    write rpt-rec-a from h1-head after advancing page. 
    move spaces 			to rpt-rec-a. 
    write rpt-rec-a after advancing 2 lines. 
 
    perform aa1-print-message-table  	thru aa1-99-exit 
            varying sub from 1 by 1 
*           until sub > 54. 
            until sub > ws-max-nbr-messages-in-tbl.
 
    move 5				to const-rec-5-rec-nbr. 
    read iconst-mstr 
	invalid key 
		go to err-iconst-mstr. 
    move const-con-nbr(25)		to hold-iconst-con-nbr. 
    move const-nx-avail-pat(25)		to hold-iconst-nx-ikey. 
 
    move all "-"			to l3-line. 
    move 20				to ctr-reject 
					   ctr-warning 
					   ctr-exception
					   ctr-audit. 
    move "N"				to eof-tp-pat-mstr. 
*	display scr-title. 
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
*   (IF THE FUNC-CODE OF THE RECORD IS "C2", PRINT OUT THE RECORD WITH 
*    ERROR MESSAGE.) 
* 
    if tp-pat-func-code = "C2" 
    then 
	add 1					to ctr-error-rpt-writes 
*	MOVE 34					TO ERR-IND 
*	PERFORM XA0-WRITE-TP-ERROR-REPORT	THRU XA0-99-EXIT 
    else 
* 
*       (EDIT AND TRANSLATE SOME FIELDS FROM EACH RECORD OF TP-PAT-MSTR 
*        REGARDLESS OF THE MODE.   NOTE:  IF RECORD IN ERROR, ERROR # 
*        IS PASSED BACK TO ERR-IND.) 
* 
    	perform ba0-preliminary-edit-patient 	thru ba0-99-exit 
* 
*   	(IF RECORD IS 'C1' AND INVALID, PRINT THE RECORD WITH MESSAGE, 
*     	 AND READ THE NEXT RECORD.  IF THE NEXT RECORD IS 'C2', IGNORE 
*        AND PRINT THE RECORD.  IF THE NEXT RECORD IS 'C1' AGAIN, 
*	 DO THE SAME AS 'CHANGE' MODE.  IF THE NEXT RECORD IS 'AA', 
*        DO THE SAME AS 'ADD' MODE.) 
* 
    	if invalid-record and tp-pat-func-code = "C1" 
    	then 
* 2004/02/25 - MC - comment the next line
*           add 1                               to ctr-error-rpt-writes
* 2004/02/25 - end
*           MOVE TP-PAT-MSTR-REC                TO WS-PAT-MSTR-REC
*           PERFORM XB0-WRITE-WS-ERROR-REPORT   THRU XB0-99-EXIT
* 2004/02/25 - MC -uncomment the last two lines
            move tp-pat-mstr-rec                to ws-tp-pat-mstr-rec
            perform xb0-write-ws-error-report   thru xb0-99-exit
* 2004/02/25 - end
      	    perform ya0-read-next-tape		thru ya0-99-exit 
	    if tp-pat-func-code = "C2" 
	    then 
		add 1				to ctr-error-rpt-writes 
*	    	MOVE 35				TO ERR-IND 
*	    	PERFORM XA0-WRITE-TP-ERROR-REPORT	THRU XA0-99-EXIT 
	    else 
		perform ba0-preliminary-edit-patient thru ba0-99-exit 
		if valid-record 
		then 
	    	    move tp-pat-mstr-rec	to ws-tp-pat-mstr-rec 
		    if tp-pat-func-code = "AA" 
		    then 
		        perform ca0-add-mode-processing thru ca0-99-exit 
*			brad1
* 2009/10/20 - MC1 - move to yb1-write-patient
*			perform ye0-write-out-accepted-pat-rec thru ye0-99-exit
* 2009/10/20 - end  
		    else 
		    	if tp-pat-func-code = "C1" 
		    	then 
*			    MOVE 0		TO ERR-IND 
*			    PERFORM XA0-WRITE-TP-ERROR-REPORT THRU XA0-99-EXIT 
 		    	    perform da0-change-mode-processing thru da0-99-exit 
*			    brad1
* 2009/10/20 - MC1 - move to yc6-rewrite-patient
*			    perform ye0-write-out-accepted-pat-rec thru ye0-99-exit
* 2009/10/20 - end  
			else 
			    next sentence 
*			endif 
*		    endif 
		else 
		    if tp-pat-func-code = "AA" 
		    then 
		    	perform xa0-write-tp-error-report  	thru xa0-99-exit 
		    else 
			add 1			to ctr-error-rpt-writes 
*		    endif 
*		endif 
*	    endif 
    	else 
	    if invalid-record 
	    then 
	    	perform xa0-write-tp-error-report	thru xa0-99-exit 
	    else 
	    	move tp-pat-mstr-rec			to ws-tp-pat-mstr-rec 
            	if tp-pat-func-code = "AA" 
            	then 
                    perform ca0-add-mode-processing	thru ca0-99-exit 
*		    brad1
* 2009/10/20 - MC1  - move to yb1-write-patient
*		    perform ye0-write-out-accepted-pat-rec thru ye0-99-exit
* 2009/10-20 - end
            	else 
                    if tp-pat-func-code = "C1" 
                    then 
*			MOVE 0			TO ERR-IND 
*			PERFORM XA0-WRITE-TP-ERROR-REPORT THRU XA0-99-EXIT. 
*			brad1
*                     	 perform da0-change-mode-processing thru da0-99-exit. 

* 2009/10-20 - MC1 - move to yc6-rewrite-patient
*                    	perform da0-change-mode-processing thru da0-99-exit
*			perform ye0-write-out-accepted-pat-rec thru ye0-99-exit.
                     	perform da0-change-mode-processing thru da0-99-exit.
* 2009/10-20 - end
*		    endif 
*               endif 
*           endif 
*       endif 
*   endif 
 
    perform ya0-read-next-tape			thru ya0-99-exit. 
 
ab0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform az1-totals			thru az1-99-exit. 
 
    move hold-iconst-con-nbr		to const-con-nbr(25). 
    move hold-iconst-nx-ikey		to const-nx-avail-pat(25). 
 
    rewrite iconst-mstr-rec 
	invalid key 
		go to err-iconst-mstr. 
 
    close tp-pat-mstr 
	  pat-mstr 
   	  pat-elig-history	
* 2004/02/25 - MC
          corrected-pat
* 2004/02/25 - end

*	brad1
	tp-pat-mstr-out

*mf	  od-pat-mstr 
*mf	  hc-pat-mstr 
*mf	  acr-pat-mstr 
*mf	  chrt-pat-mstr 
	  iconst-mstr 
	  audit-file-a 
          audit-file-b 
	  audit-file-c. 
*	    display scr-closing-screen. 
 
az0-99-exit. 
    exit. 
 
 
az1-totals. 
 
    add 1			 	to ctr-page-b. 
    move ctr-page-b			to h3-page-no. 
    write rpt-rec-b from h3-head after advancing page. 
 
* 2008/01/16 - MC - Brad requested to change to NUMBER OF RECORDS ON TAPE
*    move "NUMBER OF PATIENTS ON TAPE = " 
    move "NUMBER OF RECORDS  ON TAPE = " 
* 2008/01/16 - end
					to l4-title. 
    move ctr-tp-pat-mstr-reads          to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF PATIENTS ADDED = " 
					to l4-title. 
    move ctr-pat-mstr-writes            to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
**  MOVE "NUMBER OF SUBSCRIBERS ADDED = " 
**					TO L4-TITLE. 
**  MOVE CTR-SUBSCR-MSTR-WRITES         TO L4-CTR. 
**  WRITE RPT-REC-B			FROM L4-LINE AFTER ADVANCING 2 LINES. 
**  MOVE SPACES				TO L4-LINE. 
 
    move "NUMBER OF PATIENTS UPDATED = " 
					to l4-title. 
    move ctr-pat-mstr-rewrites          to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF CHANGES NOT DONE    = " 
  					to l4-title. 
    move ctr-pat-mstr-no-update         to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF REJECTED RECORDS = " 
					to l4-title. 
    move ctr-error-rpt-writes           to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF GOOD C1  RECORDS = " 
					to l4-title. 
    move ctr-good-c1                    to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 2 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF WARNINGS PRINTED = " 
					to l4-title. 
    move ctr-warnings-rpt-writes        to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
 
    move "NUMBER OF AUDITS   PRINTED = " 
					to l4-title. 
    move ctr-audit-rpt-writes           to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 

*2002/04/29 - MC 
    move "NUMBER OF EXCEPTION  PRINTED = " 
					to l4-title. 
    move ctr-exception-rpt-writes       to l4-ctr. 
    write rpt-rec-b			from l4-line after advancing 3 lines. 
    move spaces				to l4-line. 
*2002/04/29 - end
 
az1-99-exit. 
    exit. 



ba0-preliminary-edit-patient. 
 
    move "Y"				to edit-flag. 
 
 
    if tp-pat-func-code = "AA" or "C1" or "C2" 
    then 
        next sentence 
    else 
        move "N" 			to edit-flag 
        move 1				to err-ind 
  	go to ba0-99-exit. 
*   endif 
 
**  IF (TP-PAT-HEALTH-NBR = SPACES OR 
* 2002/04/30 - MC
*    if tp-pat-health-nbr = zero and 
    if (tp-pat-health-nbr = zeroes  or spaces) and 
* 2002/04/30 - end
       tp-pat-id-no = spaces and 
       tp-pat-ohip-no = spaces 
    then 
	move "N"			to edit-flag 
	move 2				to err-ind 
	go to ba0-99-exit. 
*   endif 
 
* 2002/04/25 - MC
    if (tp-pat-health-nbr = zeroes  or spaces) and 
       tp-pat-ohip-no = spaces 
    then 
	move "N"			to edit-flag 
	move 6				to err-ind 
	go to ba0-99-exit. 
*   endif 
* 2002/04/25 - end

 
    if tp-pat-last-name = spaces 
    then 
        move "N" 			to edit-flag 
 	move 3  			to err-ind 
        go to ba0-99-exit 
    else 
	move tp-pat-last-name		to ws-i-last-name. 
*   endif 

    if tp-pat-first-name = spaces 
    then 
        move "N" 			to edit-flag 
 	move 5  			to err-ind 
        go to ba0-99-exit 
    else 
	move tp-pat-first-name		to ws-i-first-name. 
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
	move 10				to err-ind 
	go to ba0-99-exit 
    else 
        if tp-pat-birth-dd  < 1  or > 31 
        then 
            move "N"  			to edit-flag 
  	    move 11			to err-ind 
            go to ba0-99-exit. 
*       endif 
*   endif 
 
 
    if tp-pat-birth-mm = 2 
    then 
 	if tp-pat-birth-dd > 29 
 	then 
 	    move "N"			to edit-flag 
 	    move 12			to err-ind 
            go to ba0-99-exit.	 
*	endif 
*   endif 
 
 
    if tp-pat-birth-mm =   4 or 6 or 9 or 11 
    then 
 	if tp-pat-birth-dd > 30 
 	then 
 	    move "N"			to edit-flag 
 	    move 13			to err-ind 
 	    go to ba0-99-exit. 
*	endif 
*   endif 

* 2002/05/01 - error if birth date is greater than system date or < 1880

    move tp-pat-birth-yy		to	test-birth-yy. 
    move tp-pat-birth-mm		to	test-birth-mm. 
    move tp-pat-birth-dd		to	test-birth-dd. 
    if test-birth-date > sys-date-long or tp-pat-birth-yy < 1880
    then
	move  23			to	err-ind
	move "N"			to	edit-flag
	go to ba0-99-exit.
*   endif
*2002/05/01 - end


 
    if tp-pat-sex = "M" or "F" 
    then 
 	next sentence 
    else 
        if tp-pat-func-code = "AA" or "C2" 
        then 
 	    move "N"			to edit-flag 
 	    move 14			to err-ind 
 	    go to ba0-99-exit. 
*   endif 
 
    if tp-pat-id-no = spaces 
    then 
	go to ba0-10-cont-edit-patient. 
*   endif 
 
 
    move spaces				to ws-save-id-no. 

* MC3
    move spaces				to mrn-site.
* MC3 - end

* 2010/01/18 - MC2 - reset edit-chart-flag to 'Y'
    move 'Y'				to edit-chart-flag.

    if tp-pat-id-no-site = 'J' and tp-pat-id-no-pos-11 = ' '       
    then
	move 0			        to ws-stjoe-id-no-pos-1
	move tp-pat-id-no-pos-2-10	to ws-stjoe-id-no-pos-2-10
	move ws-stjoe-id-no 		to tp-pat-id-no.
*   endif
* 2010/01/18 - end

* 2002/03/28 - MC - edit chart nbr
* (2002/nov/03 B.E. - include logic to determine the site/hospital of mrn
*   if tp-pat-id-no-alpha = 'M' or 'K' or 'H' or '1' or '5'
*   if tp-pat-id-no-alpha = 'M' or 'K' or 'H' or '0'
    if tp-pat-id-no-site  = 'M' or 'K' or 'H' or '0' or 'J'
* MC3 - include more hospital site
                          or'D' or 'E' or 'F' or 'W' or 'Z'
* MC3 - end
    then
	next sentence
    else
* 2010/01/18 - MC2
* 	move "N"			to edit-flag 
 	move "N"			to edit-chart-flag 
* 2010/01/18 - end
 	move 46				to err-ind 
* MC4 - even wrong chart site, check the rest of the fields
* 	go to ba0-99-exit. 
        go to ba0-10-cont-edit-patient.
* MC4 - end
*   endif 

*   CASE
    if   tp-pat-id-no-site = "M"
    then
*	(MUMC)
	move "m"			to mrn-site
    else 
    if   tp-pat-id-no-site = "K"
    then
*	(CHEDOKE)
	move "c"			to mrn-site
    else 
    if   tp-pat-id-no-site = "H"
    then
*	(HENDERSON)
	move "h"			to mrn-site
    else 
    if   tp-pat-id-no-site = "0"
    then
*	(GENERAL)
	move "g"			to mrn-site
    else 

* MC3
    if   tp-pat-id-no-site = "D"
    then
*	(HALDMAND WAR)
	move "d"			to mrn-site
    else 
    if   tp-pat-id-no-site = "E"
    then
*	(WEST HALDIMAND)
	move "e"			to mrn-site
    else 
    if   tp-pat-id-no-site = "F"
    then
*	(ST. PETERS)
	move "f"			to mrn-site
    else 
    if   tp-pat-id-no-site = "W"
    then
*	(WEST LINCOLN)
	move "w"			to mrn-site
    else 
    if   tp-pat-id-no-site = "Z"
    then
*	(BAY AREA)
	move "z"			to mrn-site
    else 
    if   tp-pat-id-no-site = "J" and
	 tp-pat-id-no-reminder = spaces
    then
*	(ST JOES BRANT - J+8)   
        move "b"			to mrn-site
	go to ba0-10-cont-edit-patient
    else 
* MC3 - end              

    if   tp-pat-id-no-site = "J"
    then
*	(ST JOES)
	move "s"			to mrn-site.
*   END CASE

*   (next 9 characters must be numeric)
    if    tp-pat-id-no-pos-2-10 is not numeric 
* MC3 - Bay area only contains 8 digits     
      and tp-pat-id-no-site  not = "Z"
* MC3 - end
    then 
* 2010/01/18 - MC2 
*       move "N"		to edit-flag 
        move "N"		to edit-chart-flag 
* 2010/01/18 - end
        move 47			to err-ind 
* MC4
*        go to ba0-99-exit.
   	 go to ba0-10-cont-edit-patient.
* MC4 - end	 
*   endif

*   (for st joes the next 10 character must be numeric)
    if     mrn-is-stjoes
       and tp-pat-id-no-pos-11 is not numeric
    then
* 2010/01/18 - MC2
*        move "N"		to edit-flag 
        move "N"		to edit-chart-flag 
* 2010/01/18 - end
        move 39			to err-ind 
* MC4
*        go to ba0-99-exit.
	 go to ba0-10-cont-edit-patient.
* MC4 - end
*   endif

*   (remainder of variable must be blank) 
    if   tp-pat-id-no-pos-12-15 not = spaces     
      or (    not mrn-is-stjoes
	  and tp-pat-id-no-pos-11 not = space
	 )
    then 
* 2010/01/18 - MC2
*        move "N"		to edit-flag 
        move "N"		to edit-chart-flag 
* 2010/01/18 - end
        move 48			to err-ind 
* MC4
*       go to ba0-99-exit.
	go to ba0-10-cont-edit-patient.
* MC4 - end
*   endif


   if mrn-is-henderson
   then
       if tp-pat-id-no-pos-2-4 = '002' or '003'
	then
	    next sentence
	else
* 2010/01/18 - MC2
*	    move "N"			to edit-flag
	    move "N"			to edit-chart-flag
* 2010/01/18 - end
	    move 49			to err-ind
* MC4
*	    go to ba0-99-exit.
	    go to ba0-10-cont-edit-patient.
* MC4 - end
*	endif
*  endif

   if mrn-is-general
   then
       if tp-pat-id-no-pos-2-4 = '001' or '005'
	then
	    next sentence
	else
* 2010/01/18 - MC2
*	    move "N"			to edit-flag
	    move "N"			to edit-chart-flag
* 2010/01/18 - end
	    move 52			to err-ind
* MC4
*	    go to ba0-99-exit.
	    go to ba0-10-cont-edit-patient. 
* MC4 - end
*	endif
*  endif

*    if valid-record 
*    then 
*	move spaces			to tp-pat-id-no 
*	move ws-save-id-no		to tp-pat-id-no. 
*   endif 
 
 
ba0-10-cont-edit-patient. 
 
    if tp-pat-street-addr = spaces and  (tp-pat-func-code = "AA" or "C2") 
    then 
        move "N" 			to edit-flag 
	move 21 			to err-ind 
	go to ba0-99-exit 
    else 
        if tp-pat-street-addr not = spaces and  (tp-pat-func-code = "AA" or "C2") 
            then 
	    move spaces			to ws-i-street-addr 
	    move tp-pat-street-addr	to ws-i-street-addr. 
*   endif 
 
    move spaces				to ws-i-city-prov. 
 
 
    if tp-pat-city = spaces  and (tp-pat-func-code = "AA" or "C2") 
    then 
        move "N" 			to edit-flag 
	move 22 			to err-ind 
	go to ba0-99-exit 
    else 
        if tp-pat-city not = spaces  and (tp-pat-func-code = "AA" or "C2") 
        then 
	    move tp-pat-city		to ws-i-city. 
*   endif 

    if tp-pat-prov = spaces and (tp-pat-func-code = "AA" or "C2" ) 
    then 
*	(if province is blank then assume it's ON - B.E.2002/apr/18)
*	        move "N" 			to edit-flag 
*		move 24 			to err-ind 
*		go to ba0-99-exit 
	move "ON"				to tp-pat-prov
    else 
        if tp-pat-prov not = spaces and (tp-pat-func-code = "AA" or "C2" ) 
        then 
	    move "N"			to province-flag 
    	    perform bc0-search-province 	thru bc0-99-exit 
		varying sub from 1 by 1 
		until (province-found or sub > 13) 
	    if province-not-found 
	    then 
* MC4 - if invalid province, set to 'ON'
*	        move "N"	        to edit-flag 
*	        move 25			to err-ind 
*	        go to ba0-99-exit. 
	        move 'ON'		to tp-pat-prov.
* MC4 - end
*	endif 
*   endif 
 
    if    (tp-pat-prov not = 'ON' 
       and tp-pat-health-nbr not = spaces 
       and tp-pat-health-nbr not = zeroes) 
       and (tp-pat-func-code = 'AA' or 'C2') 
    then 
        move "N"                        to edit-flag 
        move 37                         to err-ind 
        go to ba0-99-exit. 
*   endif. 
 
    if    (tp-pat-prov not = 'ON' 
       and tp-pat-ohip-no  = spaces) 
       and (tp-pat-func-code = 'AA' or 'C2') 
    then 
        move "N"                        to edit-flag 
        move 40                         to err-ind 
        go to ba0-99-exit. 
*   endif. 
 
    if tp-pat-health-nbr = spaces or 
       tp-pat-health-nbr = zero 
    then 
	next sentence 
    else 
        if tp-pat-health-nbr is not numeric 
        then 
            move "N"			to edit-flag 
	    move 31			to err-ind 
            go to ba0-99-exit 
	else 
*           (VERIFY THAT HEALTH NUMBER IS VALID , ELSE PRINT MESSAGE.) 
            if tp-pat-prov = "ON" 
            then 
	        perform be0-verify-health-nbr	thru be0-99-exit 
	        if invalid-health 
	        then 
		    move "N"			to edit-flag 
* 98/Sep/28	    move 34			to err-ind 
		    move 33			to err-ind 
		    go to ba0-99-exit. 
*	    	endif 
*	    endif 
*	endif 
*   endif 

    if tp-pat-ohip-no = spaces 
    then 
	next sentence 
    else 
        if tp-pat-ohip-no is not numeric 
        then 
            move "N"			to edit-flag 
	    move 29			to err-ind 
            go to ba0-99-exit 
	else 
*           (VERIFY THAT OHIP NUMBER IS VALID , ELSE PRINT MESSAGE.) 
            if tp-pat-prov = 'ON' 
            then 
	        perform bd0-verify-ohip-nbr	thru bd0-99-exit 
	        if invalid-ohip 
	        then 
		    move "N"			to edit-flag 
		    move 30			to err-ind 
		    go to ba0-99-exit. 
*	    	endif 
*	    endif 
*	endif 
*   endif 

*   (version code can't be numeric)
    move tp-pat-version-cd		to hold-version-cd.

*   (error if version code not all alphabetic characters)
    if    hold-version-cd-1 numeric
       or hold-version-cd-2 numeric
    then 
        move "N"			to edit-flag 
	move 4				to err-ind
    else
        if tp-pat-version-cd not = spaces 
        then 
*	    (upshift version code if lower case)
            perform dd0-check-version-cd     thru dd0-99-exit. 
*       endif 
*   endif 
 
ba0-99-exit. 
    exit. 
 
bb0-search-space-trailing. 
 
    if ws-i-detail-byte(sub) = spaces 
    then 
	add 1 				to space-ctr. 
*   endif 

bb0-99-exit. 
    exit. 
 
bc0-search-province. 
 
**  IF TP-PAT-PROV = OLD-PROV(SUB) 
    if tp-pat-prov = new-prov(sub) 
    then 
        move tp-pat-prov  		to ws-i-prov 
	move "Y"			to province-flag. 
*   endif 
 
bc0-99-exit. 
    exit. 
bd0-verify-ohip-nbr. 
 
*   MOD CHECK DIGIT REQUIRES THE FOLLOWING VARIABLES: 
*		DUMMY		PIC 9(3). 
*		REM-EVEN	PIC 9V9(4). 
*		MAX-NBR-DIGITS  PIC 99		VALUE 7. 
*		SUB		PIC 99 COMP. 
*		WS-VAL-TOTAL	PIC S9(7). 
    move 7                              to max-nbr-digits. 
    move tp-pat-ohip-no			to ws-nbr-to-b-val. 
    move zero				to ws-val-total. 
    perform bd1-odd-even		thru bd1-99-exit 
					varying sub from 1 by 1 
					until sub > max-nbr-digits. 
 
bd0-10-total-loop. 
 
    if ws-val-total = 10 
    then 
	move zero			to ws-val-total 
    else 
	if ws-val-total > 10 
	then 
	    subtract 10			from ws-val-total 
					giving ws-val-total 
	    go to bd0-10-total-loop 
	else 
	    subtract ws-val-total 	from 10 
					giving ws-val-total. 
*   	endif 
*   endif 
 
    if ws-val-total not = ws-nbr-to-b-val-1-8(8) 
    then 
	move "N"			to ohip-flag 
    else 
	move "Y"			to ohip-flag. 
*   endif 
 
bd0-99-exit. 
    exit. 
 
bd1-odd-even. 
 
    divide 2				into sub 
					giving dummy 
					remainder rem-even. 
    if rem-even = zero 
    then 
	move ws-nbr-to-b-val-1-8(sub)	to ws-sum-1-2(sub) 
    else 
	add ws-nbr-to-b-val-1-8(sub) 
	    ws-nbr-to-b-val-1-8(sub)	giving ws-sum-1-2(sub). 
*   endif 
 
    add ws-sum-1(sub,1) 
  	ws-sum-1(sub,2) 
	ws-val-total			giving ws-val-total. 
 
bd1-99-exit. 
    exit. 
be0-verify-health-nbr. 
 
    move 9                              to max-nbr-digits. 
    move tp-pat-health-nbr		to ws-hc-nbr-to-b-val. 
    move zero				to ws-val-total. 
    perform be1-odd-even		thru be1-99-exit 
					varying sub from 1 by 1 
					until sub > max-nbr-digits. 
 
be0-10-total-loop. 
 
    if ws-val-total = 10 
    then 
	move zero			to ws-val-total 
    else 
	if ws-val-total > 10 
	then 
	    subtract 10			from ws-val-total 
					giving ws-val-total 
	    go to be0-10-total-loop 
	else 
	    subtract ws-val-total 	from 10 
					giving ws-val-total. 
*   	endif 
*   endif 
 
    if ws-val-total not = ws-hc-nbr-to-b-val-1-10(10) 
    then 
	move "N"			to health-flag 
    else 
	move "Y"			to health-flag. 
*   endif 
 
be0-99-exit. 
    exit. 
 
 
be1-odd-even. 
 
    divide 2				into sub 
					giving dummy 
					remainder rem-even. 
    if rem-even = zero 
    then 
	move ws-hc-nbr-to-b-val-1-10(sub)	to ws-hc-sum-1-2(sub) 
    else 
	add ws-hc-nbr-to-b-val-1-10(sub) 
	    ws-hc-nbr-to-b-val-1-10(sub)	giving ws-hc-sum-1-2(sub). 
*   endif 
 
    add ws-hc-sum-1(sub,1) 
  	ws-hc-sum-1(sub,2) 
	ws-val-total			giving ws-val-total. 
 
be1-99-exit. 
    exit. 



ca0-add-mode-processing. 
 
    perform fa0-build-key-pat-mstr		thru fa0-99-exit. 
	 
    if pat-exist 
    then 
        move 32                                to err-ind 
        perform  xa0-write-tp-error-report     thru xa0-99-exit 
    else 
	perform cc0-determine-if-acron-exist	thru cc0-99-exit 
	if    (   health
	       or ohip
	       or chart)
	  and pat-not-exist 
	then 
	    perform ga0-build-patient 	        thru ga0-99-exit 
            perform yb1-write-patient           thru yb1-99-exit 
        else 
	    if    all-three
	      and pat-not-exist 
	    then
*mf             move hold-ohip-mmyy             to od-pat-ohip-mmyy 
                move hold-ohip-mmyy             to pat-ohip-mmyy 
                perform yb0-2-read-od-pat-mstr  thru yb0-2-99-exit 
                if pat-exist 
                then 
                    move 36                     to err-ind 
                    perform xa0-write-tp-error-report thru xa0-99-exit 
                else 
*mf	    	    move hold-chart-no              to chrt-pat-chart-nbr 
* 2002/12/06 - MC - redundant
*	    	    move hold-chart-no              to pat-chart-nbr 
* 2002/12/06 -end
            	    perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit 
        	    if pat-exist 
	    	    then 
		        move 38			to err-ind 
		        perform xa0-write-tp-error-report 
 					              thru xa0-99-exit 
  		    else 
                        perform ga0-build-patient      thru ga0-99-exit 
                        perform yb1-write-patient      thru yb1-99-exit 
*                   endif 
*               endif 
	    else 
                if    health-and-chart
		  and pat-not-exist 
                then 
*mf	    	    move hold-chart-no              to chrt-pat-chart-nbr 
* 2002/12/06 - MC - redundant
*	    	    move hold-chart-no              to pat-chart-nbr 
* 2002/12/06 -end
            	    perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit 
        	    if pat-exist 
	    	    then 
		        move 38			to err-ind 
		        perform xa0-write-tp-error-report 
 					              thru xa0-99-exit 
                    else 
                        perform ga0-build-patient      thru ga0-99-exit 
                        perform yb1-write-patient      thru yb1-99-exit 
*                   endif 
	        else 
                    if    ohip-and-chart
		      and pat-not-exist 
                    then 
*mf	    	        move hold-chart-no              to chrt-pat-chart-nbr 
* 2002/12/06 - MC - redundant
*	    	    	move hold-chart-no              to pat-chart-nbr 
* 2002/12/06 -end
            	        perform yb0-5-read-chrt-pat-mstr thru yb0-5-99-exit 
        	        if pat-exist 
	    	        then 
		            move 38			to err-ind 
		            perform xa0-write-tp-error-report 
 					              thru xa0-99-exit 
                        else 
                            perform ga0-build-patient   thru ga0-99-exit 
                            perform yb1-write-patient   thru yb1-99-exit 
*                       endif 
                    else 
                        if    health-and-ohip
			  and pat-not-exist 
                        then 
*mf	        	    move hold-ohip-mmyy         to od-pat-ohip-mmyy 
	        	    move hold-ohip-mmyy         to pat-ohip-mmyy 
            	            perform yb0-2-read-od-pat-mstr thru yb0-2-99-exit 
        	            if pat-exist 
	    	            then 
		                move 36			to err-ind 
		                perform xa0-write-tp-error-report 
 					              thru xa0-99-exit 
                            else 
                                perform ga0-build-patient   thru ga0-99-exit 
                                perform yb1-write-patient   thru yb1-99-exit. 
*	    	            endif 
*	    	        endif 
*	    	    endif 
*		endif 
*	    endif 
*	endif 
*   endif 
 
 
ca0-99-exit. 
    exit. 
cc0-determine-if-acron-exist. 
 
    move tp-pat-last-name			to hold-last-name. 
    move tp-pat-first-name			to hold-first-name. 
*mf move hold-acronym				to acr-pat-acronym. 
    move hold-acronym				to pat-acronym. 
 
    perform yb0-4-read-acr-pat-mstr		thru yb0-4-99-exit. 
    if pat-not-exist 
    then 
	go to cc0-99-exit. 
*   endif 
 
    move "Y"					to pat-flag. 
 
cc0-10-check-acron. 
 
    if   (    hold-health-nbr      = pat-health-nbr of pat-mstr
          and hold-health-nbr  not = spaces
          and hold-health-nbr  not = zeroes )
      or (    hold-ohip-mmyy       = pat-ohip-mmyy-r
          and hold-ohip-mmyy   not = spaces )
      or (    hold-chart-no        = pat-chart-nbr 
          and hold-chart-no    not = spaces ) 
* 2002/12/06 - MC - include pat-chart-nbr-2 to 5
      or (    hold-chart-no        = pat-chart-nbr-2 
          and hold-chart-no    not = spaces ) 
      or (    hold-chart-no        = pat-chart-nbr-3 
          and hold-chart-no    not = spaces ) 
      or (    hold-chart-no        = pat-chart-nbr-4 
          and hold-chart-no    not = spaces ) 
      or (    hold-chart-no        = pat-chart-nbr-5 
          and hold-chart-no    not = spaces ) 
* 2002/12/06 - end
   then 
        if tp-pat-func-code = 'AA' 
        then 
	    move 41				to err-ind 
	    perform xa0-write-tp-error-report	thru xa0-99-exit 
        else 
            if tp-pat-func-code = 'C2' 
            then 
                move 51                         to err-ind 
                perform xa0-write-tp-error-report 
                                                thru xa0-99-exit 
            else 
                next sentence 
*           endif 
*	endif 
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
da0-change-mode-processing. 
*   (READ THE NEXT NEW 'CHANGE' RECORD.) 
 
    perform ya0-read-next-tape     		thru ya0-99-exit. 
    if eof-tape 
    then 
        go to da0-99-exit. 
 
    if tp-pat-func-code = "C1" 
    then 
	add 1 					to ctr-error-rpt-writes 
	move tp-pat-mstr-rec			to ws-tp-pat-mstr-rec 
	go to da0-change-mode-processing 
    else 
	perform ba0-preliminary-edit-patient   	thru ba0-99-exit 
	if invalid-record 
	then 
	    if tp-pat-func-code = "AA" 
	    then 
	    	perform xb0-write-ws-error-report	thru xb0-99-exit 
	    	perform xa0-write-tp-error-report	thru xa0-99-exit 
		go to da0-99-exit 
	    else 
		add 1				to ctr-error-rpt-writes 
	    	perform xa0-write-tp-error-report	thru xa0-99-exit 
		go to da0-99-exit 
*	    endif 
	else 
	    if tp-pat-func-code = "AA" 
	    then 
		add 1				to ctr-error-rpt-writes 
		move tp-pat-mstr-rec		to ws-tp-pat-mstr-rec 
		perform ca0-add-mode-processing thru ca0-99-exit 
	    else 
*		(IF FUNC-CODE = "C2", DETERMINE IF THE 'C1' KEY EXISTS. 
*		 IF IT EXISTS, DETERMINE IF ANY KEY IS CHANGED. THE KEYS 
*		 CAN BE 'OHIP', 'CHART', OR 'ACRONYM'.) 
* 
	    	perform db0-determine-key-exist	thru db0-99-exit. 
*	    endif 
*	endif 
*   endif 
 
da0-99-exit. 
    exit. 
db0-determine-key-exist. 
 
*   (USE THE OLD 'CHANGE' RECORD'S DATA TO ACCESS PAT-MSTR.) 
 
    perform fa0-build-key-pat-mstr		thru fa0-99-exit. 
  
    if pat-not-exist 
    then 
 
*       (IF THE KEY OF 'C1' RECORD DOES NOT EXIST, ADD 'C2' RECORD IF 
*        THE NEW KEY DOES NOT EXIST.) 
 
	add 1					to ctr-error-rpt-writes 
	move spaces				to ws-tp-pat-mstr-rec 
	move tp-pat-mstr-rec			to ws-tp-pat-mstr-rec 
	perform ca0-add-mode-processing		thru ca0-99-exit 
    else 
	add 1					to ctr-good-c1 
        perform dc0-change-check                thru dc0-99-exit. 
*   endif 
 
db0-99-exit. 
    exit. 
 
 
dc0-change-check. 

* 2004/02/25 - MC - store values from patient to f086-pat-id in case
*                   there is eligibility changes of the patient
    move spaces                                 to pat-id-rec.

*   brad1
    move spaces					to tp-pat-mstr-rec-out.

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

*   (reset flag that tracks if RMA database not updated because
*    incoming value is same as RMA's OLD value)
    move "N"                            to flag-change-version-cd
                                           flag-birth-date-change
*   2002/05/06 - MC	
			                   pat-change-flag 
*   2002/05/06 - end
                                           flag-old-version-cd
                                           flag-old-birth-date.
 
*   (2000/mar/13 B.E.)
*   (Test for changed VERSION CODE 
*    ws-pat-version-code = patient's current value on RMA database
*    tp-                 = incoming value
*    ws-pat-last-version-cd = patient's old value on RMA database
*
*    if    incoming value is not blank 
*      and it differs from existing current RMA
*      and it's not equal to the OLD rma value(if RMA corrected MUMC
*	                       value then MUMC's value is in the RMA old value
*	                       and we don't want to change back to it again)
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
        move "Y"                      to flag-1-vs-2-character-ver-cd
    else
        move "N"                      to flag-1-vs-2-character-ver-cd.
*   endif

* 2003/01/29 - MC - redundant
*    move 'N'                          to flag-change-version-cd.
*    move "N"                          to flag-old-version-cd.
* 2003/01/29 - end

    if    tp-pat-version-cd <> ' ' 
      and tp-pat-version-cd <> ws-pat-version-cd 
      and not one-char-ver-cd-vs-2-char
    then 
*       (signal that data changed but don't actually move it until sure
*        it is different from OLD values)
        move 'Y'                        to flag-change-version-cd
        if tp-pat-version-cd <> ws-pat-last-version-cd
        then
            move ws-pat-version-cd      to ws-pat-last-version-cd
*2002/05/01 - MC
*                                           rma-version-cd
*2002/05/02 - end
            move tp-pat-version-cd      to ws-pat-version-cd
       	    move 'Y'		        to pat-change-flag 
*2002/05/01 - MC
*                                           disk-version-cd
*2002/05/02 - end
        else
*           (flag set so that warning report can be written if NOT changing
*            version code even though different from RMA - 'O'ld 'V'ersion)
            move "Y"                    to flag-old-version-cd
            move ws-pat-version-cd      to rma-version-cd
            move tp-pat-version-cd      to disk-version-cd.
*        endif
*   endif

*   (2000/mar/13 B.E.)
*   (Test for changed BIRTH DATE 
*    ws-pat-birth-date = patient's current data on RMA database
*    tp-            = incoming value
*    ws-pat-last-birth-date = patient's old value on RMA database
*
*    if     incoming value is not blank 
*      and  it differs from existing current RMA
*      and it's not equal to the OLD rma value(if RMA corrected MUMC
*	                       value then MUMC's value is in the RMA old value
*	                       and we don't want to change back to it again)
*    then update RMA database)

* 2003/01/29 - MC - redundant
*    move 'N'                          to flag-birth-date-change.
*    move "N"                          to flag-old-birth-date.
* 2003/01/29 - end

    if    tp-pat-birth-yy <> zero
      and tp-pat-birth-mm <> zero
      and tp-pat-birth-dd <> zero
      and (   tp-pat-birth-yy <> ws-pat-birth-date-yy
           or tp-pat-birth-mm <> ws-pat-birth-date-mm
           or tp-pat-birth-dd <> ws-pat-birth-date-dd
	  )
    then
*       (signal that data changed but don't actually move it until sure
*        it is different from OLD values)
        move "Y"                        to flag-birth-date-change
* 2002/04/29 - MC
*        if tp-pat-birth-date not = ws-pat-last-birth-date
*        if     tp-pat-birth-yy <> ws-pat-last-birth-date-yy
*           and tp-pat-birth-mm <> ws-pat-last-birth-date-mm
*           and tp-pat-birth-dd <> ws-pat-last-birth-date-dd
         if     tp-pat-birth-yy <> ws-pat-last-birth-date-yy
            or  tp-pat-birth-mm <> ws-pat-last-birth-date-mm
            or  tp-pat-birth-dd <> ws-pat-last-birth-date-dd
* 2002/04/29 - end
        then
*           (update birth date)
            move ws-pat-birth-date    to ws-pat-last-birth-date
            move tp-pat-birth-yy      to ws-pat-birth-date-yy
            move tp-pat-birth-mm      to ws-pat-birth-date-mm
            move tp-pat-birth-dd      to ws-pat-birth-date-dd
       	    move 'Y'		      to pat-change-flag 
        else
*           (flag set so that warning report can be written if NOT changing
*            version code even though different from RMA- 'O'ld 'V'alue)
            move "Y"                  to flag-old-birth-date
* 2002/04/29 - MC
*        move tp-pat-birth-yy       to rma-birth-date-yy
*        move tp-pat-birth-mm       to rma-birth-date-mm
*        move tp-pat-birth-dd       to rma-birth-date-dd
*        move ws-pat-birth-date-yy           to disk-birth-date-yy
*        move ws-pat-birth-date-mm           to disk-birth-date-mm
*        move ws-pat-birth-date-dd           to disk-birth-date-dd.
            move tp-pat-birth-yy       to disk-birth-date-yy
            move tp-pat-birth-mm       to disk-birth-date-mm
            move tp-pat-birth-dd       to disk-birth-date-dd
            move ws-pat-birth-date-yy  to rma-birth-date-yy
            move ws-pat-birth-date-mm  to rma-birth-date-mm
            move ws-pat-birth-date-dd  to rma-birth-date-dd.
* 2002/04/29 - end
*       endif
*   endif


    if   (    version-cd-changed
          and old-version-cd-matches
         )
      or (     birth-date-changed
          and  old-birth-date-matches
         )
    then
        perform xe0-write-update-exception-rpt    thru xe0-99-exit.
*   endif


* 2002/05/03 - MC - check if Ohip nbr and/chart nbr need to be updated

    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr
	 ) 
* 2002/12/13 - MC
     and  mrn-is-mumc
* 2002/12/13 - end
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr.
*   endif

* 2002/12/13 - MC - check for other 4 chart nbr as well

    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-2
	 ) 
     and  mrn-is-chedoke
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-2.
*   endif

    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-3
	 ) 
     and  mrn-is-henderson
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-3.
*   endif

    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-4
	 ) 
     and  mrn-is-general
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-4.
*   endif

    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-5
	 ) 
     and  mrn-is-stjoes 
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-5.
*   endif

* MC3 - check for West Lincoln, if no mumc chart, then store West Lincoln chart  
    move ws-pat-chart-nbr	to ws-rma-chart-nbr.	
    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr
	  and ws-rma-chart-site not = 'M'              
	 ) 
     and  mrn-is-West-Lincoln
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr.
*   endif

* MC3 - check for Bay Area (ZB),if no Chedoke chart, then store Bay Area chart  
    move ws-pat-chart-nbr-2	to ws-rma-chart-nbr.	
    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-2
	  and ws-rma-chart-site not = 'K' 
	 ) 
     and  mrn-is-Bay-Area     
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-2.
*   endif

* MC3 - check for D,E,F, if no General chart or = ikey, store in chart nbr 4 
    move ws-pat-chart-nbr-4	to ws-rma-chart-nbr.	
    move ws-key-pat-mstr 	to x-key-pat-mstr.
    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-4
	  and (  (     ws-rma-chart-site not = '0' 
                   and ws-rma-chart-2-4  not = '001' and not = '005'
		 )
	       or ws-pat-chart-nbr-4 = x-key-pat-mstr
	      )
	 ) 
     and (    mrn-is-Haldimand-War	
	  or  mrn-is-West-Haldimand
	  or  mrn-is-Stpeter             
         )
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-4.
*   endif

* MC3 - check for St Joe Brant (J+8), if no St Joe (J+10) , then store St Joe Brant
    move ws-pat-chart-nbr-5	to ws-rma-chart-nbr.	
    if   (    tp-pat-id-no      not = spaces 
	  and tp-pat-id-no      not = ws-pat-chart-nbr-5
	  and (   ws-rma-chart-site not = 'J' 
               or  ws-rma-chart-10-11 not numeric  
              )
	 ) 
     and mrn-is-Stjoe-Brant  
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-id-no	to ws-pat-chart-nbr-5.
*   endif
* MC3 - end



    if   (    tp-pat-ohip-no   not = spaces 
* 2002/12/13 - MC
*	  and tp-pat-ohip-no   not = ws-pat-chart-nbr
	  and tp-pat-ohip-no   not = ws-pat-ohip-mmyy
	 ) 
    then 
	move 'Y'		to pat-change-flag 
        move tp-pat-ohip-no	to ws-pat-ohip-mmyy.
*   endif
* 2002/05/03 - end

* 2003/01/08 - MC  - the following section has commented out
*		     because they are not applied
*   if   pat-change
*     or (    version-cd-changed
*         and old-version-cd-doesnt-match
*        )
*     or (    birth-date-changed
*         and old-birth-date-doesnt-match
*        )
*   then
*       go to dc0-80
*   else
*2002/05/01 - MC
*       add 1                        to    ctr-pat-mstr-no-update
*2002/05/01 - end
*       go to dc0-99-exit. 
*   endif
* 2003/01/08 - end

dc0-80.

* 2003/01/29 - MC
     if tp-pat-health-65-ind = " "
     then
	move "N"				to tp-pat-health-65-ind.
*    endif
* 2003/01/29 - MC

* 2002/12/13 - MC - comment out redundant codes with '**' in front
**    move tp-pat-phone-no		to ws-i-phone-no. 
**    move tp-pat-street-addr           to ws-i-street-addr. 
*   (NO LONGER merge city and province with one space - patient now has
*    separate fields for each field. 
**    move spaces			to ws-i-city-prov. 
**    move tp-pat-city			to ws-i-city-prov.
* 2002/12/13 - end

*    string tp-pat-city 		delimited by ws-xx, 
*           " "			delimited by size, 
*           tp-pat-prov          delimited by size, 
*      				into ws-i-city-prov. 

* 2004/02/19 - MC - the following block has moved from below
*
* 2008/01/10 - MC - create records only if incoming values are different for both current and old values in the database
*    If     version-cd-changed
*        or birth-date-changed
     If      (    version-cd-changed  
              and old-version-cd-doesnt-match
             )
        or   (    birth-date-changed
              and old-birth-date-doesnt-match
             )
* 2008/01/10 - end
    then
*       (update f011 patient eligibility history information)
        perform yy0-process-pat-elig-change
                                     thru  yy0-99-exit
        perform wa0-write-audit-rpt-of-update
                                     thru  wa0-99-exit.
*   endif

* 2004/02/19 - end

* MC4 - check individual data field to make sure the incoming data is not BLANK; otherwise ignore 
*   (determine if RMA database update is required) 
    if       tp-pat-sex              not = ws-pat-sex 
* MC4
	and  tp-pat-sex		     not = spaces
    then
	move tp-pat-sex			to ws-pat-sex
	move 'Y' 			to pat-change-flag.
* endif
* MC4 - end
	
* MC3 - do not change back to blank if incoming file contains blank province
*       or   tp-pat-prov             not = ws-pat-prov-cd 
* MC4   or  (    tp-pat-prov             not = ws-pat-prov-cd 
    if  (    tp-pat-prov             not = ws-pat-prov-cd 
         and tp-pat-prov             not = spaces               
         and tp-pat-prov             not = '.'                  
         and tp-pat-prov             not = '..'                  
        )
    then
	move tp-pat-prov		to ws-pat-prov-cd  
					   ws-subscr-prov-cd
	move 'Y'			to pat-change-flag.
*   endif
* MC4 - end
	
* MC3 - end

* MC4   or   tp-pat-postal-code      not = ws-subscr-postal-cd 
    if     tp-pat-postal-code      	not = ws-subscr-postal-cd 
       and tp-pat-postal-code 		not = spaces
       and tp-pat-postal-code 		not = '.'    
    then
	move tp-pat-postal-code 	to ws-subscr-postal-cd
	move 'Y' 			to pat-change-flag.
*   endif
* MC4 - end

*	 (no longer dropping the area code - use all of phone nbr field)
*       or   ws-i-local-phone-no     not = ws-pat-phone-nbr 
* 2002/12/13 - MC - check for address and name as well
*	or   ws-i-phone-no	     not = ws-pat-phone-nbr

* MC4	or   tp-pat-phone-no         not = ws-pat-phone-nbr
    if       tp-pat-phone-no         not = ws-pat-phone-nbr
       and   tp-pat-phone-no	     not = spaces
       and   tp-pat-phone-no	     not = '.' 
    then
	move tp-pat-phone-no		to ws-pat-phone-nbr
	move 'Y'			to pat-change-flag.
*   endif
* MC4 - end

* MC4   or   tp-pat-street-addr      not = ws-subscr-addr1
    if       tp-pat-street-addr      not = ws-subscr-addr1
        and  tp-pat-street-addr      not = spaces              
        and  tp-pat-street-addr      not = '.'                 
    then
	move tp-pat-street-addr		to ws-subscr-addr1
	move 'Y'			to pat-change-flag.
*    endif
* MC4 - end

* MC4   or   tp-pat-street-addr2     not = ws-subscr-addr2
    if       tp-pat-street-addr2     not = ws-subscr-addr2
        and  tp-pat-street-addr2     not = spaces              
        and  tp-pat-street-addr2     not = '.'                 
    then
	move tp-pat-street-addr2	to ws-subscr-addr2
	move 'Y'			to pat-change-flag.
*    endif
* MC4 - end

* MC4   or   tp-pat-city             not = ws-subscr-addr3 
    if       tp-pat-city             not = ws-subscr-addr3 
        and  tp-pat-city             not = spaces
        and  tp-pat-city             not = '.'
    then
	move tp-pat-city		to ws-subscr-addr3
	move 'Y'			to pat-change-flag.
*    endif
* MC4 - end

* MC4   or   tp-pat-last-name	     not = ws-pat-surname
    if       tp-pat-last-name	     not = ws-pat-surname
    then
	move tp-pat-last-name	     to	   ws-pat-surname
					   ws-pat-acronym-first6
	move 'Y'		     to    pat-change-flag.
*   endif
* MC4 - end

* MC4   or   tp-pat-first-name       not = ws-pat-given-name
    if       tp-pat-first-name       not = ws-pat-given-name
    then
	move tp-pat-first-name 	     to    ws-pat-given-name
					   ws-pat-acronym-last3
					   ws-pat-init1
	move 'Y' 		     to    pat-change-flag.
*   endif
* MC4 - end

* MC4   or   tp-pat-health-65-ind    not = ws-pat-health-65-ind 
    if      tp-pat-health-65-ind    not = ws-pat-health-65-ind 
	and tp-pat-health-65-ind    not = spaces
    then
        move tp-pat-health-65-ind     to    ws-pat-health-65-ind 
	move 'Y'		      to    pat-change-flag.
*    endif
* MC4 - end

* MC4   or   tp-pat-expiry-date      not = ws-pat-expiry-date 
    if       tp-pat-expiry-date      not = ws-pat-expiry-date 
       and   tp-pat-expiry-date	     not = spaces
       and   tp-pat-expiry-date      not = '0000'
    then
        move tp-pat-expiry-date      to    ws-pat-expiry-date 
	move 'Y' 		     to    pat-change-flag.
* endif
* MC4 - end


* 2002/12/13 - end

* MC4 - comment out below codes with '***'
*	or   pat-change
    if    pat-change
* 2008/01/10 - MC - comment out, it is redundant because pat-change will be set
*		    if there is a true change in either version code or birth date
* 	or   version-cd-changed
* 	or   birth-date-changed
* 2008/01/08 - end  
    then
***        move tp-pat-sex              to    ws-pat-sex 
* 2002/12/13 - MC
*       move ws-i-street-addr1       to    ws-subscr-addr1 
*       move ws-i-street-addr2       to    ws-subscr-addr2 
*       move ws-i-city-prov          to    ws-subscr-addr3 
***        move tp-pat-street-addr      to    ws-subscr-addr1 
***        move tp-pat-street-addr2     to    ws-subscr-addr2 
***        move tp-pat-city             to    ws-subscr-addr3 
***	move tp-pat-last-name	     to	   ws-pat-surname
***					   ws-pat-acronym-first6
***	move tp-pat-first-name 	     to    ws-pat-given-name
***					   ws-pat-acronym-last3
***					   ws-pat-init1
* 2002/12/13 - end

*	(patient location is set same as health nbr province)
***        move tp-pat-prov             to    ws-pat-prov-cd 
***	                                   ws-subscr-prov-cd

***        move tp-pat-postal-code      to    ws-subscr-postal-cd 
*       move ws-i-local-phone-no     to    ws-pat-phone-nbr 
* 2002/12/13 - MC
*	move ws-i-phone-no	     to	   ws-pat-phone-nbr
***	move tp-pat-phone-no         to	   ws-pat-phone-nbr
* 2002/12/13 - end
***        move tp-pat-health-65-ind    to    ws-pat-health-65-ind 
***        move tp-pat-expiry-date      to    ws-pat-expiry-date 
* MC4 - end

*       (move ws- record to patient master rec)
        move ws-pat-mstr-rec         to    pat-mstr-rec 
        move ws-feedback-pat-mstr    to    feedback-pat-mstr 
        perform yc6-rewrite-patient  thru yc6-99-exit 

*******************************************************************
* 2004/02/19 - MC - transfer the following block to above if statement
*                   before rewriting to patient record

*       (update f011 patient eligibility history information)
**      perform yy0-process-pat-elig-change
**                                   thru  yy0-99-exit
**      perform wa0-write-audit-rpt-of-update
**                                   thru  wa0-99-exit
*
* 2004/02/19 - end
********************************************************************

        add 1                        to    ctr-pat-mstr-rewrites 
    else 
        add 1                        to    ctr-pat-mstr-no-update. 
*   endif. 
 
    if   (    tp-pat-health-nbr not = spaces 
	  and tp-pat-health-nbr not = zero
	 ) 
     and (    ws-tp-pat-health-nbr = spaces 
	  and ws-tp-pat-health-nbr not = zero
	 ) 
    then 
*  VERIFY IF THE NEW HEALTH NBR KEY EXISTS 
       move tp-pat-health-nbr		to pat-health-nbr of pat-mstr

       perform yb0-3-read-hc-pat-mstr   thru yb0-3-99-exit 
       if    (   ws-pat-health-nbr = spaces
	      or ws-pat-health-nbr = zero )
	 and pat-not-exist 
       then 
           move tp-pat-health-nbr        to ws-pat-health-nbr 
*mf        move ws-pat-mstr-rec          to hc-pat-mstr-rec 
	   move ws-pat-mstr-rec		 to pat-mstr-rec 
*mf        move ws-feedback-pat-mstr     to feedback-pat-mstr-hc 
*mf        perform yb7-write-hc-key      thru yb7-99-exit 
*mf        move ws-pat-mstr-rec          to pat-mstr-rec 
*mf        move ws-feedback-pat-mstr     to feedback-pat-mstr 

           perform yc6-rewrite-patient   thru yc6-99-exit 
           move 66                       to err-ind 
           perform xd0-write-tp-warning-report  thru xd0-99-exit 
       else 
           move 50                       to err-ind 
           perform xa0-write-tp-error-report   thru xa0-99-exit 
	   subtract 1			 from ctr-error-rpt-writes. 
*      endif 
*   endif. 
dc0-99-exit. 
    exit. 
 
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

* MC5 -check to make sure version cd is alpha
  if         hold-version-cd = spaces 
* according to Yasemin, do not allow first byte is blank and second byte is alpha as ' R'
*	or  (     hold-version-cd-1 = spaces   
*	     and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z')
*	    )
	or  (     hold-version-cd-2 = spaces   
	     and (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z')
	    )
	or  (    (hold-version-cd-1 >= 'A' and hold-version-cd-1 <= 'Z')
	     and (hold-version-cd-2 >= 'A' and hold-version-cd-2 <= 'Z')
	    )
  then
	next sentence
  else
        move "N"			to edit-flag 
	move 17 			to err-ind.
* endif
* MC5 - end

dd0-99-exit. 
    exit. 



fa0-build-key-pat-mstr. 
*   (this routine using the incoming data to build a key and then tries to 
*   find a matching patient. It first attemps to build a HC - Health Card
*   key. If that data is not provided, then a OD - OHIP number key is 
*   attempted. Finally is that data is not available a MRN/Chart Nbr key
*   is tried)

    move spaces                    	to hold-ohip-mmyy 
	                                   hold-chart-no 
                                           hold-orig-hc-feedback 
                                           hold-orig-od-feedback 
                                           hold-orig-chrt-feedback 
                                           flag-ohip-vs-chart. 
    move zeros				to hold-health-nbr.
 
 
    if ws-tp-pat-health-nbr not = spaces and 
       ws-tp-pat-health-nbr not = zero 
    then 
*   	(CREATE HOLD-HEALTH-NBR.) 
        move ws-tp-pat-health-nbr 		to hold-health-nbr 
	move "H "				to flag-ohip-vs-chart 

	move hold-health-nbr			to pat-health-nbr of pat-mstr

        perform yb0-3-read-hc-pat-mstr  	thru yb0-3-99-exit 
    else 
        if ws-tp-pat-ohip-no not = spaces 
        then 
*   	(CREATE HOLD-OHIP-MMYY.) 
            move ws-tp-pat-ohip-no		to hold-ohip-no 
            move ws-tp-pat-birth-mm		to hold-ohip-mm 
            move ws-tp-pat-birth-yy-last-2	to hold-ohip-yy 
	    move "O "				to flag-ohip-vs-chart 

	    move hold-ohip-mmyy			to pat-ohip-mmyy

            perform yb0-2-read-od-pat-mstr  	thru yb0-2-99-exit 
        else 
*   	(CREATE HOLD-CHART-NO.) 
    	    move ws-tp-pat-id-no		to hold-chart-id-no 
            move "C "				to flag-ohip-vs-chart 
		
* 2002/12/13 - MC - comment reduundant code
*	    move hold-chart-no			to pat-chart-nbr
* 2002/12/13 - end

            perform Yb0-5-read-chrt-pat-mstr 	thru yb0-5-99-exit. 
*       endif 
*   endif 

    if     (   ws-tp-pat-health-nbr not = spaces 	
	   and ws-tp-pat-health-nbr not = zero) 
       and ws-tp-pat-ohip-no        not = spaces 
       and ws-tp-pat-id-no          not = spaces 
    then 
	move "AL"			to flag-ohip-vs-chart 
	move ws-tp-pat-id-no		to hold-chart-id-no 
        move ws-tp-pat-ohip-no		to hold-ohip-no 
* 2002/12/13 - MC - comment redundant codes
*       move ws-tp-pat-birth-mm		to hold-ohip-mm 
*       move ws-tp-pat-birth-yy-last-2	to hold-ohip-yy 
* 2002/12/13 - end
    else 
        if (ws-tp-pat-health-nbr not = spaces and 
           ws-tp-pat-health-nbr not = zero) 
           and ws-tp-pat-ohip-no not = spaces 
        then 
	    move "HO"			to flag-ohip-vs-chart 
            move ws-tp-pat-ohip-no		to hold-ohip-no 
* 2002/12/13 - MC - comment redundant codes
*  	    move ws-tp-pat-birth-mm		to hold-ohip-mm 
*           move ws-tp-pat-birth-yy-last-2	to hold-ohip-yy 
* 2002/12/13 - end
        else 
            if (ws-tp-pat-health-nbr not = spaces and 
               ws-tp-pat-health-nbr not = zero) 
               and ws-tp-pat-id-no not = spaces 
            then 
	        move "HC"			to flag-ohip-vs-chart 
	        move ws-tp-pat-id-no		to hold-chart-id-no 
            else 
                if (ws-tp-pat-ohip-no not = spaces 
                    and ws-tp-pat-id-no not = spaces) 
                then 
	            move "OC"			to flag-ohip-vs-chart 
	            move ws-tp-pat-id-no	to hold-chart-id-no. 
*   	        endif 
*           endif 
*       endif 
*   endif 
 
fa0-99-exit. 
    exit. 


ga0-build-patient. 
 
    move spaces				to ws-pat-mstr-rec. 
 
* 2002/12/13 - MC
*   move ws-i-last-name    		to ws-pat-surname 
    move tp-pat-last-name    		to ws-pat-surname 
					   ws-pat-acronym-first6. 
*   move ws-i-first-name    		to ws-pat-given-name 
    move tp-pat-first-name    		to ws-pat-given-name 
* 2002/12/13 - end
					   ws-pat-init1 
					   ws-pat-acronym-last3. 
    move tp-pat-birth-yy		to ws-pat-birth-date-yy. 
    move tp-pat-birth-mm		to ws-pat-birth-date-mm. 
    move tp-pat-birth-dd		to ws-pat-birth-date-dd. 
    move tp-pat-sex			to ws-pat-sex. 

* 2002/12/13 - MC
**    move tp-pat-phone-no		to ws-i-phone-no. 
*   (no longer dropping area code - now using all of phone nbr field)
*      move ws-i-local-phone-no		  to ws-pat-phone-nbr. 
**    move ws-i-phone-no		to ws-pat-phone-nbr.
      move tp-pat-phone-no		to ws-pat-phone-nbr.
* 2002/12/13 - end

    move "O"				to ws-pat-in-out. 
    move sys-date-long			to ws-pat-date-last-maint. 
    move zero				to ws-pat-nbr-outstanding-claims. 
    move hold-ohip-mmyy			to ws-pat-ohip-mmyy. 
* 2002/12/13 - MC - split into the correct chart nbr
*    move hold-chart-no			to ws-pat-chart-nbr. 

* 2010/01/18 - MC2
  if valid-chart-key
  then
* 2010/01/18 - end
    if mrn-is-mumc
* MC3
    or mrn-is-West-Lincoln 
* MC3 - end
    then    move hold-chart-no		to ws-pat-chart-nbr
    else if mrn-is-chedoke
* MC3
	 or mrn-is-Bay-Area
* MC3 - end
	 then move hold-chart-no	to ws-pat-chart-nbr-2
    else if mrn-is-henderson
	 then move hold-chart-no	to ws-pat-chart-nbr-3
    else if mrn-is-general
* MC3
         or mrn-is-Haldimand-War
         or mrn-is-West-Haldimand
         or mrn-is-Stpeter      
* MC3 - end
	 then move hold-chart-no	to ws-pat-chart-nbr-4
    else if mrn-is-stjoes 
* MC3 
	 or mrn-is-Stjoe-Brant
* MC3 - end
	 then move hold-chart-no	to ws-pat-chart-nbr-5.
*   endif
* 2010/01/18 - MC2
* endif
* 2010/01/18 - end


* 2002/12/13 - end
    move hold-health-nbr		to ws-pat-health-nbr. 
    move "I"                            to ws-pat-i-key 
    move hold-iconst-con-nbr		to ws-pat-con-nbr. 
    move hold-iconst-nx-ikey		to ws-pat-i-nbr. 
* 2002/12/13 - MC
**   move ws-i-street-addr1		to ws-subscr-addr1. 
**   move ws-i-street-addr2		to ws-subscr-addr2. 
**   move ws-i-city-prov		to ws-subscr-addr3. 
    move tp-pat-street-addr		to ws-subscr-addr1. 
    move tp-pat-street-addr2		to ws-subscr-addr2. 
    move tp-pat-city    	 	to ws-subscr-addr3. 
*   (NO LONGER merge city and province with one space - patient now has
*    separate fields for each field. 
**   move spaces			to ws-i-city-prov. 
**   move tp-pat-city			to ws-i-city-prov.
* 2002/12/13 - end
 
*    string tp-pat-city 		delimited by ws-xx, 
*           " "			delimited by size, 
*           tp-pat-prov          delimited by size, 
*      				into ws-i-city-prov. 

* MC3
* MC4
*   if tp-pat-prov = ' ' 
    if tp-pat-prov = ' ' or  '.' or  '..'
* MC4 - end
    then
	move 'ON'			to tp-pat-prov.
*   endif
* MC3

    move tp-pat-prov			to ws-pat-prov-cd
                              		   ws-subscr-prov-cd.
    move tp-pat-postal-code 		to ws-subscr-postal-cd. 
    move "Y"				to ws-subscr-auto-update. 
    move "00"				to ws-subscr-msg-nbr. 
    move tp-pat-version-cd              to ws-pat-version-cd. 
    move tp-pat-expiry-date             to ws-pat-expiry-date. 
    if tp-pat-health-65-ind = " " 
    then 
        move "N"                        to ws-pat-health-65-ind 
    else 
        move tp-pat-health-65-ind       to ws-pat-health-65-ind. 
 
*   PERFORM GE0-INCREMENT-NX-AVAIL-PAT  THRU GE0-99-EXIT. 
 
 
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




wa0-write-audit-rpt-of-update.

*   (write audit that information was updated)
    if    (    birth-date-changed
           and old-birth-date-doesnt-match
          )
      and (    version-cd-changed
           and old-version-cd-doesnt-match
          )
    then
        move 58                         to err-ind
    else
    if   (    birth-date-changed
          and old-birth-date-doesnt-match
         )
    then
        move 56                         to err-ind
    else
    if   (    version-cd-changed
          and old-version-cd-doesnt-match
         )
    then
        move 57                         to err-ind
    else
    if   pat-change
    then
        move 59                         to err-ind.
*   ENDCASE

    perform wa1-write-audit-report      thru wa1-99-exit.

wa0-99-exit.
    exit.



wa1-write-audit-report.

wa1-99-exit.
    exit.



xa0-write-tp-error-report. 
 
    move spaces				 to l1-line 
                   		 	    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-mess-id. 
 
 
    move tp-pat-func-code		 to l1-func-cd. 
    move tp-pat-last-name		 to l1-last-name. 
    move tp-pat-first-name		 to l1-first-name. 
    move tp-pat-birth-date		 to l1-date. 
    move tp-pat-sex			 to l1-sex. 
    move tp-pat-id-no			 to l1-id-no. 
    move tp-pat-ohip-no			 to l1-ohip-no. 
    move tp-pat-health-nbr		 to l1-health-nbr. 
    move tp-pat-version-cd   		 to l2-version-cd. 
    move tp-pat-street-addr		 to l2-street-addr. 
    move tp-pat-city			 to l2-city. 
    move tp-pat-prov			 to l2-prov. 
    move tp-pat-postal-code		 to l2-postal-cd. 
    move tp-pat-phone-no		 to l2-phone-no. 
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
xb0-write-ws-error-report. 
 
    move spaces				 to l1-line 
                   		 	    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-mess-id. 
 
 
    move ws-tp-pat-func-code		 to l1-func-cd. 
    move ws-tp-pat-last-name		 to l1-last-name. 
    move ws-tp-pat-first-name		 to l1-first-name. 
    move ws-tp-pat-birth-date		 to l1-date. 
    move ws-tp-pat-sex			 to l1-sex. 
    move ws-tp-pat-id-no		 to l1-id-no. 
    move ws-tp-pat-ohip-no		 to l1-ohip-no. 
    move ws-tp-pat-health-nbr		 to l1-health-nbr. 
    move ws-tp-pat-version-cd  		 to l2-version-cd. 
    move ws-tp-pat-street-addr		 to l2-street-addr. 
    move ws-tp-pat-city			 to l2-city. 
    move ws-tp-pat-prov			 to l2-prov. 
    move ws-tp-pat-postal-code		 to l2-postal-cd. 
    move ws-tp-pat-phone-no		 to l2-phone-no. 
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
 
    write rpt-rec-a from h2-head after advancing 1 line. 
    write rpt-rec-a from l1-line after advancing 1 line. 
    write rpt-rec-a from l2-line after advancing 2 lines. 
    add 1				  to ctr-reject. 
    add 1				  to ctr-error-rpt-writes. 
 
 
xb0-99-exit. 
    exit. 
xc0-write-ws-warning-report. 
 
    move spaces				 to l1-line 
                   		 	    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-mess-id. 
 
 
    move ws-tp-pat-func-code		 to l1-func-cd. 
    move ws-tp-pat-last-name		 to l1-last-name. 
    move ws-tp-pat-first-name		 to l1-first-name. 
    move ws-tp-pat-birth-date		 to l1-date. 
    move ws-tp-pat-sex			 to l1-sex. 
    move ws-tp-pat-id-no		 to l1-id-no. 
    move ws-tp-pat-ohip-no		 to l1-ohip-no. 
    move ws-tp-pat-health-nbr		 to l1-health-nbr. 
    move ws-tp-pat-version-cd  		 to l2-version-cd. 
    move ws-tp-pat-street-addr		 to l2-street-addr. 
    move ws-tp-pat-city			 to l2-city. 
    move ws-tp-pat-prov			 to l2-prov. 
    move ws-tp-pat-postal-code		 to l2-postal-cd. 
    move ws-tp-pat-phone-no		 to l2-phone-no. 
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
 
    write rpt-rec-b from h2-head after advancing 1 line. 
    write rpt-rec-b from l1-line after advancing 1 line. 
    write rpt-rec-b from l2-line after advancing 2 lines. 
    add 1				  to ctr-warning. 
    add 1				  to ctr-warnings-rpt-writes. 
 
 
xc0-99-exit. 
    exit. 
xd0-write-tp-warning-report. 
 
    move spaces				 to l1-line 
                   		 	    l2-version-cd 
                   		 	    l2-street-addr 
                   		            l2-city 
                   			    l2-prov 
                   			    l2-postal-cd 
                   			    l2-phone-no 
                   			    l2-mess-id. 
 
 
    move tp-pat-func-code		 to l1-func-cd. 
    move tp-pat-last-name		 to l1-last-name. 
    move tp-pat-first-name		 to l1-first-name. 
    move tp-pat-birth-date		 to l1-date. 
    move tp-pat-sex			 to l1-sex. 
    move tp-pat-id-no			 to l1-id-no. 
    move tp-pat-ohip-no			 to l1-ohip-no. 
    move tp-pat-health-nbr		 to l1-health-nbr. 
    move tp-pat-version-cd 		 to l2-version-cd. 
    move tp-pat-street-addr		 to l2-street-addr. 
    move tp-pat-city			 to l2-city. 
    move tp-pat-prov			 to l2-prov. 
    move tp-pat-postal-code		 to l2-postal-cd. 
    move tp-pat-phone-no		 to l2-phone-no. 
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
 
    if ctr-exception > 15
    then 
        move 0				 to ctr-exception
        add 1				 to ctr-page-c 
        move ctr-page-c	 		 to h4-page-no 
        write rpt-rec-c from h4-head after advancing page 
        move spaces			 to rpt-rec-c 
        write rpt-rec-c from h5-head after advancing 1 line 
        move spaces			 to rpt-rec-c 
        write rpt-rec-c after advancing 1 line. 
*   endif 

    move 'RMA'                  to prt-lit1.
    move 'Incoming'             to prt-lit2 .
    move tp-pat-health-nbr	to prt-ohip-health-nbr.

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
        move "VERSION CD = RMA's OLD value"          to rma-reason-desc
    else
    if    birth-date-changed
      and old-birth-date-matches
    then
        move "BIRTH DATE = RMA's OLD value"          to rma-reason-desc
    else
        move "Unknown Update Exception error"        to rma-reason-desc.
*   endcase

    write rpt-rec-c from prt-det-line1 after advancing 2 lines.
    write rpt-rec-c from prt-det-line2 after advancing 1 line.

    add 1				  to ctr-exception. 
    add 1				  to ctr-exception-rpt-writes. 

*  (B.E. 2002/apr/29 - blank variables after printing so they don't reappear
*			on the next error message)
    move spaces				to 	prt-lit1            
						prt-ohip-health-nbr 
						rma-version-cd      
						rma-prov-cd         
						rma-reason-desc     
						prt-lit2            
						disk-account-id     
						disk-version-cd     
						disk-prov-cd.

* 2002/04/30 - MC
    move zeroes				to 	rma-birth-date-yy
						rma-birth-date-mm
						rma-birth-date-dd
						disk-birth-date-yy
						disk-birth-date-mm
						disk-birth-date-dd.
* 2002/04/30 - end 
xe0-99-exit. 
    exit. 



ya0-read-next-tape. 
 
    read tp-pat-mstr 
	at end 
	    move "Y"			to eof-tp-pat-mstr 
	    go to ya0-99-exit. 
    if      tp-pat-last-name-6 = "FINK  "
	and tp-pat-first-name  = "BABYGIRL"
    then add 1 to ctr-tp-pat-mstr-reads.
*  
    add 1				to ctr-tp-pat-mstr-reads. 
 
ya0-99-exit. 
    exit. 
 
 
yb0-read-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur 
					   feedback-pat-mstr. 
    read pat-mstr 
	invalid key 
	    move "N"			to pat-flag 
	    go to yb0-99-exit. 
 
yb0-99-exit. 
    exit. 
 
yb0-2-read-od-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur-od 
					   feedback-pat-mstr-od. 
*mf read od-pat-mstr 
    read pat-mstr
*mf     (added alternative key read)
        key is pat-ohip-mmyy
      invalid key 
	    move "N"			to pat-flag 
	    go to yb0-2-99-exit. 
 
*mf move od-pat-mstr-rec                to ws-pat-mstr-rec. 
    move pat-mstr-rec			to ws-pat-mstr-rec.

    move feedback-pat-mstr-od           to ws-feedback-pat-mstr. 
 
yb0-2-99-exit. 
    exit. 
 
yb0-3-read-hc-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur-hc 
					   feedback-pat-mstr-hc. 
*mf read hc-pat-mstr 
    read pat-mstr
*mf     (added alternative key read)
        key is pat-health-nbr of pat-mstr
      invalid key 
	    move "N"			to pat-flag 
	    go to yb0-3-99-exit. 
 
*mf move hc-pat-mstr-rec                to ws-pat-mstr-rec. 
    move pat-mstr-rec			to ws-pat-mstr-rec.

    move feedback-pat-mstr-hc           to ws-feedback-pat-mstr. 
 
yb0-3-99-exit. 
    exit. 
 
yb0-4-read-acr-pat-mstr. 
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur-acr 
					   feedback-pat-mstr-acr. 
*mf read acr-pat-mstr 
    read pat-mstr
*mf     (added alternative key read)
        key is pat-acronym
      invalid key
	    move "N"			to pat-flag 
	    go to yb0-4-99-exit. 

*brad - check should this line be added ??? . Move wasn't in original
*brad   for acronym does a read next
*mf added next statement
    move pat-mstr-rec                   to ws-pat-mstr-rec. 

yb0-4-99-exit. 
    exit. 


 
yb0-5-read-chrt-pat-mstr. 
*   (this routine builds a patient MRN/chart nbr key and attempts
*   to find a patient with that key. The format of the key data determines
*   which site/hospital key is searched on. This site determination
*   was already made when the key data was editted)

* 2010/01/18 - MC2 - if invalid chart key, blank out chart nbr.
    if invalid-chart-key
    then
	go to yb0-5-99-exit.
*   endif
* 2010/01/18 - end
 
    move "Y"				to pat-flag. 
    move zero				to pat-occur-chrt 
					   feedback-pat-mstr-chrt. 

*   (user 'location' to determine which site the patient's chart nbr matches)
*   CASE
    if mrn-is-mumc
* MC3 
    or mrn-is-West-Lincoln
* MC3 - end
    then
        move hold-chart-no              to pat-chart-nbr
        read pat-mstr
            key is pat-chart-nbr
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit
    else
    if mrn-is-chedoke
* MC3 
    or mrn-is-Bay-Area      
* MC3 - end
    then
        move hold-chart-no              to pat-chart-nbr-2
        read pat-mstr
            key is pat-chart-nbr-2
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit
    else
    if mrn-is-henderson
    then
        move hold-chart-no              to pat-chart-nbr-3
        read pat-mstr
            key is pat-chart-nbr-3
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit
    else
    if mrn-is-general
* MC3
    or mrn-is-Haldimand-War 
    or mrn-is-West-Haldimand
    or mrn-is-Stpeter
* MC3 - end
    then
        move hold-chart-no              to pat-chart-nbr-4
        read pat-mstr
            key is pat-chart-nbr-4
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit
    else
* MC3
    if mrn-is-stjoes
    or mrn-is-Stjoe-Brant
    then  
        move hold-chart-no              to pat-chart-nbr-5
        read pat-mstr
            key is pat-chart-nbr-5
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit
* MC3 - end
    else
        move hold-chart-no              to pat-chart-nbr-5
        read pat-mstr
            key is pat-chart-nbr-5
              invalid key
                move "N"                to pat-flag
                go to yb0-5-99-exit.
*   ENDCASE

*   (chart nbr field was dummied up with the ikey of patient to reduce the
*    duplicate keys on this field because it's often blank - therefore if same
*    value found in both field reset chart to blank)

* 2003/01/08 - MC - the following subroutine is not needed, the logic may transfer
*		    to m010 to suppress display  when ikey is same as chart nbrs
*    perform zz1-process-chart-nbr       thru zz1-99-exit.
* 2003/01/08 - end
 
    move pat-mstr-rec                   to ws-pat-mstr-rec. 
    move feedback-pat-mstr-chrt         to ws-feedback-pat-mstr. 
 
yb0-5-99-exit. 
    exit. 
 
 
yb0-10-read-next-pat-mstr. 
 
    move "Y" 					to pat-flag. 
 
*mf read acr-pat-mstr next 
    read pat-mstr next 
	at end 
	    move "N"				to pat-flag 
	    go to yb0-10-99-exit. 
 
*mf if 	acr-pat-acronym not = hold-acronym 
    if 	pat-acronym not = hold-acronym 
	move "N"				to pat-flag. 
*   endif 
 
yb0-10-99-exit. 
    exit. 
 
 
yb1-write-patient. 

    perform yc5-check-dup-ikey			thru yc5-99-exit. 
    move ws-pat-mstr-rec                        to pat-mstr-rec. 

*   display "chart site  = ",mrn-site, ', hold chart nbr = ' , hold-chart-no, ', acronym= ', pat-acronym.    
*   display "before update chart nbr = ", pat-chart-nbr,',  ',pat-chart-nbr-2,', ',pat-chart-nbr-3, ', ',pat-chart-nbr-4

    perform yb2-write-pat-i-key			thru yb2-99-exit. 
    perform ge0-increment-nx-avail-pat		thru ge0-99-exit. 
 
*    move 99                                     to err-ind. 
    move 55                                     to err-ind. 
    perform xd0-write-tp-warning-report         thru xd0-99-exit. 
 
* 2009/10/20 - MC1
    perform ye0-write-out-accepted-pat-rec	thru ye0-99-exit.
* 2009/10/20 - end

yb1-99-exit. 
    exit. 
 
yb2-write-pat-i-key. 

*   (the following fields may be blank and can cause too many duplicate keys
*    so dummy up the value with the last 10 digits of the i-key)
    if   pat-ohip-mmyy = " "
      or pat-ohip-mmyy = zero
    then
        move ws-pat-i-nbr                       to      pat-ohip-mmyy.
*   endif

* 2003/03/04 - MC
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
        move low-values                   to status-cobol-pat-mstr1
        move status-cobol-pat-mstr-bin    to status-cobol-display2.
*   endif

    if status-cobol-pat-mstr1 <> 0
    then
        display "Patient error = ", status-cobol-display.
*   endif
************************************************************

    add 1				to ctr-pat-mstr-writes. 
 
yb2-99-exit. 
    exit. 
 
 
*mf yb6-write-od-key. 
*mf     write inverted od-pat-mstr-rec 
*mf 	invalid key 
*mf 	    go to err-od-pat-mstr. 
*mf yb6-99-exit. 
*mf     exit. 
*mf yb7-write-hc-key. 
*mf     write inverted hc-pat-mstr-rec 
*mf 	invalid key 
*mf 	    go to err-hc-pat-mstr. 
*mf yb7-99-exit. 
*mf     exit. 
*mf yb8-write-acr-key. 
*mf     write inverted acr-pat-mstr-rec 
*mf 	invalid key 
*mf 	    go to err-acr-pat-mstr. 
*mf yb8-99-exit. 
*mf     exit. 
*mf yb9-write-chrt-key. 
*mf     write inverted chrt-pat-mstr-rec 
*mf 	invalid key 
*mf 	    go to err-chrt-pat-mstr. 
*mf yb9-99-exit. 
*mf     exit. 
 
 
yc5-check-dup-ikey. 
 
    move "I"					to pat-i-key   of pat-mstr.
    move hold-iconst-con-nbr			to pat-con-nbr of pat-mstr.
    move hold-iconst-nx-ikey                    to pat-i-nbr   of pat-mstr.
 
    read pat-mstr 
	invalid key 
	     go to yc5-99-exit. 
 
    move 54					to err-ind. 
    display err-msg(err-ind). 
    display key-pat-mstr of pat-mstr. 
    perform xb0-write-ws-error-report		thru xb0-99-exit. 
    perform err-pat-mstr. 
 
yc5-99-exit. 
    exit. 
 
 
yc6-rewrite-patient. 
 
    move sys-date-long			to pat-date-last-maint of pat-mstr-rec. 
 
    rewrite pat-mstr-rec 
	invalid key 
            go to err-pat-mstr. 
*** ADD 1 				TO CTR-PAT-MSTR-REWRITES. 
 
* 2009/10/20 - MC1 
    perform ye0-write-out-accepted-pat-rec	thru ye0-99-exit.
* 2009/10/20 - end

yc6-99-exit. 
    exit. 



* brad1
ye0-write-out-accepted-pat-rec.
    move tp-pat-mstr-rec		to tp-pat-mstr-rec-out-orig.

*   (give each transaction a unique ascending sequence nbr to keep the transactions in their original sequence)
    add 1				to ctr-pat-mstr-out-writes. 
* 2009/10/20 - MC1
*    move ctr-pat-mstr-out-writes	to sequence-nbr. 
    move ctr-pat-mstr-out-writes	to sequence-nbr-num. 
* 2009/10/20 - end

    write tp-pat-mstr-rec-out
	invalid key 
	    go to err-tp-pat-mstr-out. 
**************************** added for debugging *************
    move status-cobol-pat-mstr1-out       to status-cobol-display1.
    if   status-cobol-pat-mstr1-out <> 9
    then
        move status-cobol-pat-mstr2-out   to status-cobol-display2
    else
        move low-values                   to status-cobol-pat-mstr1
        move status-cobol-pat-mstr-bin-out to status-cobol-display2.
*   endif
    if status-cobol-pat-mstr1-out <> 0
    then
        display "Patient error = ", status-cobol-display.
*   endif
************************************************************

 
ye0-99-exit.
    exit.


zz1-process-chart-nbr.
copy "process_mrn_containing_ikey_values.rtn".

zz1-99-exit.
    exit.


    copy "y2k_default_century_year.rtn".

    copy "y2k_default_sysdate_century.rtn".

    copy "process_pat_eligibility_change.rtn".
