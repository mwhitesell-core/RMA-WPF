identification division. 
program-id.    u701. 
author.	       dyad technologies. 
installation.  rma. 
date-written.  90/06/15. 
date-compiled. 
security. 
* 
*            ******************************************** 
*	     * COMPILE THIS PROGRAM WITH E_COBCOMP !!!! * 
*            ******************************************** 
* 
*  REMARKS:   - OHIP DISKETTE UPLOAD INTO SUSPENSE FILES 
*             - CREATE SUSPENSE HEADER, DETAIL, AND ADDRESS RECORDS 
*               FROM THE DISKETTES. VALIDATE EACH FIELD. 
* 
* 
*  REV 91/04/23 (M.C.)	- SMS  138 
*			- SET 'CLMHDR-PAT-KEY-DATA' TO HEALTH-NBR IF 
*			  PRESENT;OTHERWISE, USE OHIP NBR. 
* 
*  REV 91/09/11 (B.M.L.) - CHANGED PROGRAM TO IGNORE BLANK OR ZERO OHIP 
*                          EDIT CHECKS NOW WORK ON HEALTH INSTEAD. 
* 
*  REV 91/09/18 (M.C.)  - INVALID DIGIT ON BATCH-SPECIALITY BECAUSE 
*			  MOVE '???' TO NUMERIC FIELD, CORRECTION MADE 
*			  ON PAGE 26 (FB0-BUILD-SUSP-HDR-REC) 
* 
*  REV 92/09/25 (M.C.)  - PDR 558 
*			- SELECT ONLY THE ACTIVE DOCTOR, AND IF THE 
*			  DOCTOR HAS MORE THAN 1 ACTIVE NUMBER, USER 
*			  SHOULD ENTER THE NUMBER THEY WANT 
* 
*  REV 93/11/16 (M.C.)  - PDR 591 
*			- MODIFY THE VALIDATION OF REFERRING DOC NBR. 
* 
*  REV 98/02/04 (J.C.)  - S149 UNIX CONVERSION
*
*  98/10/16  B.E.	- added code to summarize total fees in detail
*			  records into header record of suspense
*  98/oct/26 B.E.	- removed clinic 0000/99 as valid clinic.
*
environment division. 
input-output section. 
file-control. 
 
copy "f002_suspend_hdr.slr". 
 
 
copy "f002_suspend_dtl.slr". 
 
 
copy "f002_suspend_address.slr". 
 
 
*mf copy "f020_doctor_mstr_ohip.slr". 
copy "f020_doctor_mstr.slr". 
 
 
copy "f040_oma_fee_mstr.slr". 
 
copy "f091_diagnostic_codes.slr". 
 
select input-diskette 
    assign to       "submit_disk_susp.in" 
    organization is sequential 
    access mode  is sequential 
*mf    infos status is status-submit-diskette 
    status       is status-cobol-submit-diskette. 
 
 
select report-file 
    assign to        printer audit-file 
    status 	 is  status-report. 
 
 
data division. 
file section. 
 
copy "f002_submit_diskette_common.fd". 
 
copy "f002_suspend_hdr.fd". 
 
copy "f002_suspend_dtl.fd". 
 
copy "f002_suspend_address.fd". 
 
* copy "f020_doctor_mstr_ohip.fd". 
copy "f020_doctor_mstr.fd". 
 
copy "f040_oma_fee_mstr.fd". 
 
copy "f091_diagnostic_codes.fd". 
 
fd  report-file 
    record contains 132 characters. 
 
01  rpt-line			pic x(132). 
working-storage section. 
 
77  audit-file					pic x(9) value "ru701". 
77  suspend-dtl-occur				pic 9(7). 
77  ws-carriage-ctrl				pic 9(02) value 0. 
77  ctr-lines-printed				pic 9(03) value 99. 
77  max-lines-per-page				pic 9(03) value 60. 
77  ws-rpt-page-nbr				pic 9(03) value 0. 
77  ws-agent-default-reply			pic x(01) value spaces. 
*98/Oct/20 B.E.
77  ws-default-clinic-nbr                       pic 9(2)  value 0.
*mf 77  carriage-return				pic x(01) value "<012>". 
77  carriage-return				pic x(01) value x"0D". 
77  ws-doc-nbr					pic 9(3)  value 0. 
 
01  bt-clinic-nbr-1-2				pic 99	value zero. 
01  sub						pic 99	comp. 
01  ss						pic 9(5) comp. 
01  subs-hosp					pic 99	comp. 
 
* (y2k)
01  hold-birth-mmyy. 
    05  hold-birth-mm				pic 99. 
* (y2k)
    05  hold-birth-yy				pic 99. 
 
* (y2k)
01  ws-date-yymmdd. 
* (y2k)
    05 ws-date-yy				pic 99. 
* (y2k)
    05 ws-date-mm				pic 99. 
* (y2k)
    05 ws-date-dd				pic 99. 
 
01  ws-nbr-10					pic x(10). 
 
01  hold-suspend-hdr-rec			pic x(265). 
 
 
01  audit-line. 
    05  filler					pic x(10) value spaces. 
    05  audit-title				pic x(36). 
    05  audit-value				pic zz,zzz. 
    05  filler					pic x(05) value spaces. 
    05  audit-value-2				pic zz,zzz. 
    05  filler					pic x(05) value spaces. 
    05  audit-value-3				pic zz,zzz. 
    05  filler					pic x(05) value spaces. 
    05  audit-value-4				pic zz,zzz. 
    05  filler					pic x(05) value spaces. 
    05  audit-value-5				pic zzz,zzz.99 blank when zero. 
 
01  status-values. 
*mf  02 status-infos. 
*mf    05  status-submit-diskette 		pic x(11)  value zero. 
*mf    05  status-doc-mstr			pic x(11)  value zero. 
*mf    05  status-oma-mstr			pic x(11)  value zero. 
*mf    05  status-suspend-hdr			pic x(11)  value zero. 
*mf    05  status-suspend-dtl			pic x(11)  value zero. 
*mf    05  status-suspend-addr			pic x(11)  value zero. 
*mf    05  status-diag-mstr   			pic x(11)  value zero. 
*mf    05  status-file				pic x(11). 
  02 status-cobol. 
    05  status-cobol-submit-diskette 		pic x(02)  value zero. 
    05  status-cobol-oma-mstr			pic x(02)  value zero. 
    05  status-cobol-doc-mstr			pic x(02)  value zero. 
    05  status-cobol-suspend-hdr		pic x(02)  value zero. 
    05  status-cobol-suspend-dtl		pic x(02)  value zero. 
    05  status-cobol-suspend-addr		pic x(02)  value zero. 
    05  status-cobol-diag-mstr  		pic x(02)  value zero. 
    05  status-report				pic x(02)  value zero. 
    05  status-file				pic x(02). 
 
01  feedback-values. 
    05  feedback-doc-mstr			pic x(04)  value zero. 
    05  feedback-oma-fee-mstr			pic x(04)  value zero. 
    05  feedback-suspend-hdr			pic x(04)  value zero. 
    05  feedback-suspend-dtl			pic x(04)  value zero. 
    05  feedback-suspend-addr			pic x(04)  value zero. 
    05  feedback-diag-mstr  			pic x(04)  value zero. 
 
01  flag					pic x. 
01  eof-input-file-flag				pic x	value "N". 
    88 eof-input-file			value "Y". 
 
01  fatal-error-flag				pic x   value spaces. 
    88 fatal-error			value "Y". 
 
01 skip-processing-acct-id-flag		pic x. 
    88 skip-processing-this-acct-id	value "Y". 
    88 skip-hdr-addr-but-write-dtl 	value "D". 
 
01 record-type-flags				pic x. 
    88 h-record				value "H". 
    88 a-record				value "A". 
    88 t-record				value "T". 
    88 e-record				value "E". 
    88 b-record				value "B". 
 
* (y2k)
01  flag-date					pic x. 
* (y2k)
    88 valid-date					value "Y". 
* (y2k)
    88 invalid-date					value "N". 
 
01  flag-consec					pic x. 
    88 valid-consec					value "Y". 
    88 invalid-consec					value "N". 
 
01  flag-clinic					pic x. 
    88 clinic-found					value "Y". 
    88 clinic-not-found					value "N". 
 
01  flag-hosp-nbr				pic x. 
    88 valid-hosp-nbr					value "Y". 
    88 invalid-hosp-nbr					value "N". 
 
01  flag-agent-cd				pic x. 
    88 valid-agent-cd					value "Y". 
    88 invalid-agent-cd					value "N". 
 
01  flag-in-out-ind					pic x. 
    88 valid-in-out-ind					value "Y". 
    88 invalid-in-out-ind				value "N". 
 
01  flag-doc					pic x. 
    88  doc-found					value "Y". 
    88  doc-not-found					value "N". 
 
01  flag-oma					pic x. 
    88  valid-oma-code					value "Y". 
    88  invalid-oma-code				value "N". 
 
01  flag-agent-code					pic x. 
    88  valid-agent-cd-code				value "Y". 
    88  invalid-agent-cd-code				value "N". 
 
01  flag-refer-phys				pic x. 
    88  valid-refer-phys				value "Y". 
    88  invalid-refer-phys				value "N". 
 
01  flag-location				pic x. 
    88  valid-location  				value "Y". 
    88  invalid-location  				value "N". 
 
01  flag-ohip					pic x. 
    88  valid-ohip					value "Y". 
    88  invalid-ohip					value "N". 
 
01  flag-diag-cd				pic x. 
    88  valid-diag-code					value "Y". 
    88  invalid-diag-code				value "N". 
 
01  ws-chk-ind					pic x(8). 
 
77  ws-val-total				pic s9(7). 
77  dummy					pic 9(3). 
77  rem-even					pic 9v9(4). 
77  max-nbr-digits				pic 99 value 7. 
 
77  max-doc-locations				pic 99 value 30. 
 
01  counters. 
    05  ctr-suspend-hdr-writes			pic 9(7). 
    05  ctr-suspend-dtl-writes			pic 9(7). 
    05  ctr-suspend-addr-writes			pic 9(7). 
    05  ctr-recs-read       			pic 9(7). 
    05  ctr-b-recs-read				pic 9(7). 
    05  ctr-e-recs-read				pic 9(7). 
    05  ctr-h-recs-read				pic 9(7). 
* (y2k)
    05  ctr-h-recs-skipped			pic 9(7). 
* (y2k)
    05  ctr-t-recs-read-skipped			pic 9(7). 
    05  ctr-t-recs-read				pic 9(7). 
* (y2k)
    05  ctr-a-recs-read-skipped			pic 9(7). 
    05  ctr-a-recs-read				pic 9(7). 
    05  ctr-tot-h-recs				pic 9(7). 
    05  ctr-tot-t-recs				pic 9(7). 
    05  ctr-tot-a-recs				pic 9(7). 
    05  ctr-tot-b-recs				pic 9(7). 
    05  ctr-tot-dollars-read			pic 9(7)v99. 
    05  ctr-tot-dollars-claim			pic 9(7)v99. 
    05  ctr-tot-svcs-read			pic 9(7). 
 
01  province-flag				pic x. 
    88  province-found				value "Y". 
    88  province-not-found  			value "N". 
 
 
01  prov-table. 
 
    05  province. 
        10  filler                              pic x(2) value "AB". 
        10  filler				pic x(2) value "NF". 
	10  filler   				pic x(2) value "SA". 
        10  filler                              pic x(2) value "MA". 
        10  filler				pic x(2) value "NW". 
	10  filler   				pic x(2) value "ON". 
        10  filler                              pic x(2) value "PE". 
        10  filler				pic x(2) value "QE". 
	10  filler   				pic x(2) value "YK". 
        10  filler                              pic x(2) value "BC". 
        10  filler				pic x(2) value "NB". 
	10  filler   				pic x(2) value "NS". 
	10  filler   				pic x(2) value "OT". 
 
    05  province-r   		 redefines      province. 
 
	10  prov                 occurs 13 times pic x(2). 
 
copy "def_agents.ws". 
 
copy "sysdatetime.ws". 
 
copy "check_digit.ws". 
 
copy "check_digit_10.ws". 
 
copy "mod_check_digit.ws". 
 
copy "mth_desc_max_days.ws". 
 
copy "hosp_table.ws". 
 
 
01 heading-l1. 
    05  filler					pic x(08)	value 
       "RU701". 
    05  filler					pic x(10)	value 
       "RUN DATE:". 
 
* (y2k)
    05  l1-run-date				pic x(08). 
    05  filler					pic x(08)	value spaces. 
    05  filler					pic x(66)	value 
       "OHIP DISKETTE UPLOAD INTO SUSPENSE FILES - AUDIT REPORT". 
    05  filler					pic x(06)	value 
	"PAGE:". 
    05  rpt-page-nbr				pic zzz9. 
01  tbl-group-nbr-clinic. 
    05  filler					pic x(4) value "2215". 
    05  filler				        pic x(2) value "22". 
    05  filler				        pic x(4) value "6008". 
    05  filler				        pic x(2) value "60". 
* 98/oct/26 B.E.
*   05  filler				        pic x(4) value "0000". 
*   05  filler				        pic x(2) value "99". 
01  tbl-group-nbr-clinic-r redefines tbl-group-nbr-clinic. 
*   05  tbl-group-nbr-clinic-o occurs   3   times. 
    05  tbl-group-nbr-clinic-o occurs   2   times. 
        10  tbl-group-nbr	  		pic x(4). 
        10  tbl-group-clinic 	  		pic x(2). 
01  max-ss-group-clinic-tbl	pic 99  value   2. 
*01 max-ss-group-clinic-tbl	pic 99  value   3. 
 
copy "submit_diskette_batch_rec.ws". 
copy "submit_diskette_hdr_rec.ws". 
01  error-message-vable. 
 
    05  error-messages. 
* #1 
	10  filler. 
	    15  filler				pic x(22)  value 
		"**WARNING** - BATCH = ". 
	    15  err-msg-pract-nbr      		pic x(06). 
	    15  filler				pic x(01)  value "/". 
	    15  err-msg-account-id     		pic x(08). 
	    15  filler				pic x(95)  value spaces. 
* #2 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(43)  value 
		"**ERROR** - NO SUCH DOCTOR FOUND ON FILE - ". 
	    15  err-msg-doc-nbr      		pic x(06). 
	    15  filler				pic x(69)  value spaces. 
* #3 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(61)  value 
		"INVALID LOCATION CODE FOR DOCTOR: BATCH CONTAINED LOCATION - ". 
	    15  err-msg-loc-cd       		pic x(04). 
	    15  filler				pic x(53)  value spaces. 
* #4 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(53)  value 
		"INVALID SPECIALITY CODE: BATCH CONTAINED SPECIALTY - ". 
	    15  err-msg-batch-spec-cd		pic x(04). 
	    15  filler				pic x(61)  value spaces. 
* #5 
	10 filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(53)  value 
		"                         DOCTOR'S        SPECIALTY - ". 
	    15  err-msg-doc-spec-cd		pic x(04). 
	    15  filler				pic x(61)  value spaces. 
* #6 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(56)  value 
		"**ERROR** - INVALID CLINIC ID: BATCH CONTAINED CLINIC - ". 
	    15  err-msg-clinic-id		pic x(10). 
	    15  filler				pic x(52)  value spaces. 
* #7 
	10  filler				pic x(132) value 
		"**ERROR** - FIRST RECORD FOUND IN FILE WAS NOT A 'B'ATCH RECORD ". 
* #8 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
            15  filler				pic x(40)  value 
		"INVALID OMA CODE - ACCOUNTING NBR = ". 
            15  err-accounting-nbr		pic x(10). 
            15  filler				pic x(68). 
* #9 
	10  filler				pic x(132) value 
		"              DUPLICATE ACCOUNT ID FOUND IN SUSPENSE (HEADER) FILE". 
* #10 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(40)  value 
		"INVALID WRITE NEW CLAIMS HDR - 'B' KEY=". 
	    15  bkey-clmhdr-err-msg		pic x(20)  value spaces. 
	    15  filler				pic x(58)  value spaces. 
* #11 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(40)  value 
		"INVALID WRITE NEW CLAIMS HDR -'P' KEY = ". 
	    15  pkey-clm-err-msg		pic x(20)  value spaces. 
	    15  filler				pic x(58)  value spaces. 
* #12 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(54)  value 
		"INVALID REFERRING PHYSICIAN: BATCH CONTAINED CLINIC - ". 
	    15  err-refer-phys-nbr		pic x(6). 
	    15  filler				pic x(58). 
* #13 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(51)  value 
		"INVALID PATIENT OHIP NBR: BATCH CONTAINED CLINIC - ". 
            15  err-ohip-nbr			pic x(08). 
	    15  filler				pic x(59). 
* #14 
	10  filler. 
	    15  filler				pic x(14)  value spaces. 
	    15  filler				pic x(51)  value 
		"INVALID DIAG CODE: ". 
            15  err-diag-code			pic x(03). 
            15  filler				pic x(64). 
* #15 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(51)  value 
	        "INVALID I-O-INDICATOR: ". 
            15  err-i-o-ind			pic x(01). 
            15  filler				pic x(66). 
* #16 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(92)  value 
	        "NBR OF HEADER RECORDS READ IS NOT =  NBR OF HEADER RECORDS FROM TRAILER RECORD. BATCH NBR: ". 
            15  err-ctr-h-count			pic 99999. 
            15  filler				pic x(1)  value "/". 
            15  err-trl-h-count			pic 99999. 
            15  filler				pic x(15). 
* #17 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(92)  value 
	        "NBR OF ITEM RECORDS READ IS NOT =  NBR OF ITEM RECORDS FROM TRAILER RECORD. BATCH NBR: ". 
            15  err-ctr-t-count			pic 99999. 
            15  filler				pic x(1)  value "/". 
            15  err-trl-t-count			pic 99999. 
	    15  filler				pic x(15). 
* #18 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(92)  value 
	        "NBR OF ADDRESS RECORDS IS NOT =  NBR OF ADDRESS RECORDS FROM TRAILER RECORD. BATCH NBR: ". 
            15  err-ctr-a-count			pic 99999. 
            15  filler				pic x(1)  value "/". 
            15  err-trl-a-count			pic 99999. 
	    15  filler				pic x(15). 
* #19 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(92)  value 
	        "NBR OF BATCH RECORDS READ IS NOT =  NBR OF BATCH RECORDS FROM TRAILER RECORD". 
            15  err-ctr-b-count			pic 99999. 
            15  filler				pic x(1)  value "/". 
            15  err-trl-b-count			pic 99999. 
	    15  filler				pic x(15). 
* #20 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(51)  value 
	        "INVALID AGENT CODE:    ". 
            15  err-agent-cd			pic x(01). 
            15  filler				pic x(66). 
* #21 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(20)  value 
	        "DOCTOR SPECIALTY: ". 
            15  err-21-value-1			pic x(02). 
 	    15  filler				pic x(27)  value 
	        "  NOT VALID FOR OHIP CODE: ". 
            15  err-21-value-2  		pic x(04). 
 	    15  filler				pic x(33)  value 
	        " RANGE: ". 
            15  err-21-value-3  		pic x(02). 
 	    15  filler				pic x(06)  value 
	        " THRU ". 
            15  err-21-value-4			pic x(02). 
            15  filler				pic x(22). 
* #22 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
            15  filler				pic x(10) value 
	        "OMA CODE: ". 
	    15  err-22-oma-cd			pic x(04). 
	    15  filler				pic x(14) value 
		"  REQUIRES -  ". 
	    15  err-22-msg			pic x(90). 
* #23 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(51)  value 
	        "INVALID HOSPITAL NBR: ". 
            15  err-hosp-nbr			pic x(04). 
            15  filler				pic x(63). 
* #24 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(45)  value 
	        "SERVICE NOT WITHIN 6 MONTHS OF SYSTEM DATE:". 
* (y2k)
            15  err-24-service-date		pic x(06). 
            15  filler				pic x(67). 
* #25 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(118)  value 
	        "DIRECT BILL CLAIM MISSING - MSG / AUTO LOGOUT / FEE COMPLEXITY / ... INFO". 
* #26 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(22)  value 
	        "INVALID -ADMIT- DATE: ". 
* (y2k)
            15  err-admit-date			pic x(06). 
            15  filler				pic x(90). 
* #27 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(32)  value 
	        "INVALID INITIAL SERVICE DATE:". 
* (y2k)
            15  err-27-service-date		pic x(06). 
            15  filler				pic x(80). 
* #28 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(42)  value 
	        "INVALID CONSECUTIVE SERVICES DATES/SVC'S:". 
            15  err-additional-servs		pic x(09). 
            15  filler				pic x(67). 
* 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(25)  value 
	        "INVALID HEALTH CARE NBR:". 
            15  err-health-care-nbr		pic x(10). 
            15  filler				pic x(83). 
* #30 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(18)  value 
	        "INVALID PROVINCE:". 
            15  err-province			pic x(02). 
            15  filler				pic x(98). 
* #31 
 	10  filler. 
	    15  filler				pic x(14)  value spaces. 
 	    15  filler				pic x(22)  value 
	        "INVALID RELATIONSHIP: ". 
            15  err-relationship		pic x(06). 
            15  filler				pic x(90). 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(132) 
			occurs 31 times. 
 
01  err-ind					pic 99 	value zero. 
01  err-msg-comment				pic x(132). 
01  save-prt-line				pic x(132). 
 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(11)   value 
			"*** ERROR- ". 
    05  e1-error-msg				pic x(52). 
    05  e1-error-key				pic x(17). 
screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 05 col 15 value "O.H.I.P. DISKETTE UPLOAD INTO SUSPENSE FILES". 
 
01 scr-agent-default-reply. 
    05  line 10 col 05 value "DO YOU WANT TO DEFAULT 'BLANK' AGENT CODES TO 'OHIP' (IE. '0') ?". 
    05  line 10 col 70 pic x(01) using ws-agent-default-reply. 

*98/Oct/20 B.E.
01  scr-clinic-nbr.
    05  line 13 col 05 value "Enter the CLINIC NBR or press 'newline' to default to 22(15):".
    05  line 13 col 68 pic 9(2) using ws-default-clinic-nbr.
 
01  scr-doc-nbr. 
    05  line 12 col 05 value "ENTER THE DOCTOR NBR OR PRESS 'NEWLINE' TO DEFAULT TO 0 : ". 
    05  line 12 col 65 pic 9(3) using ws-doc-nbr. 
 
01  scr-in-progress-message. 
    05  line 15 col 20 value "PROGRAM  U701  NOW IN PROGRESS". 
 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01	value "PROGRAM U701 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 42	value "/". 
    05  line 21 col 43	pic 99	from sys-mm. 
    05  line 21 col 45	value "/". 
    05  line 21 col 46	pic 99	from sys-dd. 
    05  line 21 col 50	pic 99	from sys-hrs. 
    05  line 21 col 52	value ":". 
    05  line 21 col 53	pic 99	from sys-min. 
    05  line 23 col 10	value "AUDIT REPORT IS IN FILE - RU701". 
 
procedure division. 
declaratives. 
 
err-input-diskette-file section. 
    use after standard error procedure on input-diskette. 
err-input-diskette. 
    stop "ERROR IN ACCESSING: DISKETTE INPUT FILE". 
*mf    move status-submit-diskette   	to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-submit-diskette   to status-file. 
    display file-status-display. 
    stop run. 
 
err-suspend-hdr-file section. 
    use after standard error procedure on suspend-hdr. 
err-suspend-hdr. 
*   (if duplicate key error, then set flag to skip processing of this header) 
*   (note: 90/01/14 b.e. logic will bypass writing of header but has been modified 
*          so that the details for this header will be processed and therefore 
*          will become details for the header already on file. message on warning 
*          report should alert staff to review claim to confirm that these 
*          headers are for same patient.  the original claim header on file will 
*	   have it'S CLAIM STATUS SET TO "CANCEL (IE.'y') SO THAT IT WON't 
*	   be processed unless uncancelled.  it will also appear on the cancelled 
*	   suspended claims reports) 
 
*mf    if   status-suspend-hdr       = "7013" 
      if status-cobol-suspend-hdr = "22" 
    then 
	go to err-suspend-hdr-50. 
*   endif 
 
    stop "ERROR IN ACCESSING: SUSPEND-HEADER" 
*mf    move status-suspend-hdr   	to status-file 
*mf    display file-status-display 
*mf    stop " " 
    move status-cobol-suspend-hdr  	to status-file 
    display file-status-display 
    stop run. 
 
err-suspend-hdr-50. 
*   (set flag to indicate that header is being skipped due to duplicate 
*    key but that details are to be written to disk) 
    move "D"				to	skip-processing-acct-id-flag. 
    move suspend-hdr-rec		to	hold-suspend-hdr-rec. 
*   (read original hdr rec) 
    read suspend-hdr 
	invalid key 
	  display  "SERIOUS IMPOSSIBLE ERROR #1 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id 
	  stop run. 
 
*   (update original header'S STATUS TO "CANCELLED" 
    move "Y"				to	clmhdr-status. 
 
*   (rewrite updated record) 
    rewrite suspend-hdr-rec 
	invalid key 
	   display "serious impossible error #2 suspend hdr file - key is = ",suspend-hdr-id 
	   stop run. 
 
*   (restore the suspend hdr record data) 
    move hold-suspend-hdr-rec		to	suspend-hdr-rec. 
 
err-suspend-hdr-99-exit. 
    exit. 
 
 
 
err-suspend-dtl-file section. 
    use after standard error procedure on suspend-dtl. 
err-suspend-dtl. 
    stop "error in accessing: suspend-detail". 
*mf    move status-suspend-dtl	   	to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-suspend-dtl  	to status-file. 
    display file-status-display. 
    stop run. 
 
err-suspend-addr-file section. 
    use after standard error procedure on suspend-address. 
err-suspend-addr. 
    stop "error in accessing: suspend-address". 
*mf    move status-suspend-addr   		to status-file. 
*mf    display file-status-display. 
*mf    stop " ". 
    move status-cobol-suspend-addr  	to status-file. 
    display file-status-display. 
    stop run. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "error in accessing: doctor master". 
*mf    move status-doc-mstr   		to status-file. 
    move status-cobol-doc-mstr   	to status-file. 
    display file-status-display. 
    stop run. 
 
 
err-diagnistics-mstr-file section. 
    use after standard error procedure on diag-mstr. 
err-diagnostics-mstr. 
    stop "error in accessing: diagnostic codes master". 
*mf    move status-diag-mstr   		to status-file. 
    move status-cobol-diag-mstr   	to status-file. 
    display file-status-display. 
    stop run. 
 
 
err-report-file section. 
    use after standard error procedure on report-file. 
err-report. 
    stop "error in writing to audit report: ru701". 
    move status-report			to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
mainline section. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
	    until   eof-input-file 
                 or fatal-error. 
    perform az0-finalization		thru az0-99-exit. 
    stop run. 
 
aa0-initialization. 
 
* (y2k)
    accept sys-date		from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm    		to   run-mm. 
    move sys-dd    		to   run-dd. 
* (y2k)
    move sys-yy    		to   run-yy. 
* (y2k)
    move run-date		to   l1-run-date. 
 
    accept sys-time		from time. 
    move sys-hrs   		to   run-hrs. 
    move sys-min   		to   run-min. 
    move sys-sec   		to   run-sec. 

* 98/oct/20
    move 0                      to   ws-doc-nbr.
    move 22                     to   ws-default-clinic-nbr.
 
aa0-10-default-agent. 
    display scr-title. 
 
    display scr-agent-default-reply. 
    accept  scr-agent-default-reply 
    if ws-agent-default-reply = "Y" or "N" 
    then 
        next sentence
    else 
	go to aa0-10-default-agent. 
*   endif 
 
    display scr-doc-nbr. 
    accept  scr-doc-nbr. 

*98/oct/20 B.E.
    display scr-clinic-nbr.
    accept  scr-clinic-nbr.
 
    display scr-in-progress-message 

    move spaces to suspend-hdr-rec 
                   suspend-dtl-rec 
                   suspend-address-rec. 
    move zero   to suspend-dtl-occur 
		   ws-temp 
		   counters. 
 
    open input  input-diskette 
 		doc-mstr 
		diag-mstr 
		oma-fee-mstr. 
    open i-o    suspend-hdr 
                suspend-dtl 
                suspend-address. 
*    expunge     report-file. 
    open output report-file. 
 
    perform ya0-read-diskette			thru ya0-99-exit. 
 
*   (FIRST RECORD MUST BE "B"ATCH RECORD) 
    if b-record 
    then 
  	add 1 				to	ctr-b-recs-read 
	move diskette-input-rec-data	to	batch-rec 
        perform ea0-proc-rec-type-batch	thru	ea0-99-exit 
*       (CHECK FOR ERRORS - SHUT DOWN) 
	if fatal-error 
	then 
	   go to aa0-99-exit 
	else 
*	    (READ RECORD AFTER 'B' RECORD) 
    	    perform ya0-read-diskette	thru	ya0-99-exit 
*	endif 
    else 
*	(ERROR - FIRST RECORD NOT "B"ATCH RECORD) 
	move "Y"			to	fatal-error-flag 
	move 2				to	ws-carriage-ctrl 
	move 7				to	err-ind 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	go to aa0-99-exit. 
*   endif 
 
aa0-99-exit. 
    exit. 
 
ab0-processing. 
 
    if h-record 
    then 
        add 1		     			to	ctr-h-recs-read 
	perform fa0-proc-rec-type-header	thru	fa0-99-exit 
    else 
    if t-record 
    then 
	add 1		    			to	ctr-t-recs-read 
	perform ga0-proc-rec-type-detail	thru	ga0-99-exit 
    else 
    if a-record 
    then 
	add 1	  				to	ctr-a-recs-read 
	perform ia0-proc-rec-type-address	thru	ia0-99-exit 
    else 
    if b-record 
    then 
  	add 1 					to	ctr-b-recs-read 
        perform ea0-proc-rec-type-batch		thru	ea0-99-exit 
    else 
    if e-record 
    then 
	add 1	  				to	ctr-e-recs-read 
	perform ka0-proc-rec-type-trailer	thru	ka0-99-exit. 
*   endcase 
 
*   (IF ERROR FOUND PROCESSING THIS RECORD, SKIP PROCESSING ANY DTL/ADDR RECS THAT 
*    BELONG TO SAME ACCOUNT ID: 
*    -- SKIP ALL INTERVEENING DETAIL AND ADDRESS RECORDS UNTIL ANOTHER HEADER (H) 
*    RECORD OR TRAILER (E) RECORD IS FOUND OR END OF INPUT FILE) 
    if skip-processing-this-acct-id 
    then 
	move spaces				to	diskette-input-record 
	perform ya0-read-diskette		thru	ya0-99-exit 
	    until (diskette-input-rec-type =   "H" 
					    or "E") 
	         or eof-input-file 
*       move "N"				to	skip-processing-acct-id-flag 
	go to ab0-99-exit 
    else 
	perform ya0-read-diskette		thru	ya0-99-exit. 
*   endif 
 
ab0-99-exit. 
    exit. 
az0-finalization. 
 
   close input-diskette 
         suspend-hdr 
         suspend-dtl 
         suspend-address 
 	 doc-mstr 
	 oma-fee-mstr 
	 diag-mstr 
	 report-file. 
 
az0-99-exit. 
    exit. 
copy "db0_mod10_check_digit.rtn". 
 
copy "db0a_mod10_check_digit_10.rtn". 
 
copy "dc0_mod10_check_digit_alt.rtn". 
 
ea0-proc-rec-type-batch. 
 
*   (re-set totals for this batch - note that this zeroing will also 
*    wipe out the counter of the "B"atch record read that is being 
*    processed - thus set appropriate counters to 1) 
    move zero				to	counters. 
    move 1				to	ctr-b-recs-read 
						ctr-recs-read. 
 
    move diskette-input-rec-data	to	batch-rec. 
 
    perform ea10-determine-clinic-nbr	thru	ea10-99-exit. 
*   (check if error - shut down) 
    if fatal-error 
    then 
	go to ea0-99-exit. 
*   endif 
 
    move batch-provider-nbr		to	doc-ohip-nbr. 
    perform yb0-read-doc		thru	yb0-99-exit. 
    if doc-found 
    then 
	perform ea11-check-doctor-speciality	thru	ea11-99-exit 
    else 
*	(error - write report and skip batch) 
	move "Y"			to	fatal-error-flag 
	move 2				to	ws-carriage-ctrl 
	move 2				to	err-ind 
	move batch-provider-nbr		to	err-msg-doc-nbr 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	go to ea0-99-exit. 
*   endif 
 
ea0-99-exit. 
    exit. 
 
 
ea10-determine-clinic-nbr. 
 
    move "N"				to flag-clinic. 
  
    perform ea10a-search-clinic-tbl	thru ea10a-99-exit 
	varying sub 
	from   1 
	by     1 
	until   sub > max-ss-group-clinic-tbl 
  	     or clinic-found. 

*   (DISKETTES FROM NON-WEB SITES DON'T ALL HAVE THE CLINIC IN
*    THE SUBMISSION FILE - THEREFORE IF THE CLINIC IS ZERO
*    DON'T GIVE AN ERROR BUT ALLOW THE OPERATOR TO HAVE SPECIFIED
*    A CLINIC) 
* 98/oct/20 B.E.
    if    clinic-not-found
      and ws-default-clinic-nbr         = 0000
    then 
*       (ERROR - CLINIC ON DISKETTE IS BAD AND NO OVERRIDE
*        DEFAULT CLINIC WAS SPECIFIED BY THE OPERATOR - skip batch)
	move "Y"			to	fatal-error-flag 
	move 2				to	ws-carriage-ctrl 
	move 6				to	err-ind 
	move batch-group-nbr		to	err-msg-clinic-id 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit 
    else
        if    clinic-not-found
          and ws-default-clinic-nbr     not = 0000
        then
*           (CLINIC IS BAD BUT OVERRIDE DEFAULT CLINIC WAS SPECIFIED)
            move ws-default-clinic-nbr  to      bt-clinic-nbr-1-2
            move ws-default-clinic-nbr  to      batch-group-nbr.
*        endif
*   endif 
 
ea10-99-exit. 
    exit. 
 
 
 
ea10a-search-clinic-tbl. 
 
    if batch-group-nbr = tbl-group-nbr(sub) 
    then 
         move tbl-group-clinic(sub)	to bt-clinic-nbr-1-2
         move 'Y'			to flag-clinic. 
*   endif 
 
ea10a-99-exit. 
    exit. 
 
ea11-check-doctor-speciality. 
 
    if batch-speciality not = doc-spec-cd 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 4				to	err-ind 
	move batch-speciality		to	err-msg-batch-spec-cd 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 5				to	err-ind 
	move doc-spec-cd		to	err-msg-doc-spec-cd 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit. 
*   endif 
 
ea11-99-exit. 
    exit. 
fa0-proc-rec-type-header. 
 
    move "N"			to skip-processing-acct-id-flag. 
 
    perform fb0-build-susp-hdr-rec	thru	fb0-99-exit. 
*   (if error found processing this record, skip processing dtl/addr part of record) 
    if skip-processing-this-acct-id 
    then 
	go to fa0-99-exit. 
*   endif 
 
    perform fc0-build-susp-dtl-from-hdr 
					thru	fc0-99-exit. 
 
    perform fd0-build-susp-addr-1st-half 
					thru	fd0-99-exit. 
 
*   (sum total fee $ processed)
    add hdr-fee-billed			to	ctr-tot-dollars-read
*   						(98/oct/16 B.E. 
*						 - also keep sum of claim total)
						ctr-tot-dollars-claim.
 
    perform yc0-write-hdr-rec		thru	yc0-99-exit. 
*   (if error processing this record, skip writing out detail record) 
    if skip-processing-this-acct-id 
    then 
	go to fa0-99-exit. 
*   endif 
 
    perform yd0-write-dtl-rec		thru	yd0-99-exit. 
 
fa0-99-exit. 
    exit. 
fb0-build-susp-hdr-rec. 
 
    move diskette-input-rec-data	to	header-rec. 
 
    move spaces				to	suspend-hdr-rec. 
 
    move zeros				to	clmhdr-zeroed-oma-suff-adj. 
    move "C"           			to	clmhdr-batch-type. 
    move "D"				to	clmhdr-adj-cd-sub-type. 
 
*   (set field to indicate that these claims were received via "D"iskette) 
    move "D"           			to	clmhdr-claim-source-cd. 
    move bt-clinic-nbr-1-2		to	clmhdr-clinic-nbr-1-2. 
    move doc-nbr			to	clmhdr-doc-nbr. 
 
*   (verify oma code contained in header is valid - note that values within 
*    oma code'S RECORD ARE USED TO VERIFY OTHER SUSPENDED HEADER REC VALUES) 
*   (determine if valid oma fee code) 
    move hdr-oma-cd			to	fee-oma-cd. 
    perform xc0-check-oma-code		thru	xc0-99-exit. 
 
*   (verify specialty against ohip code in header rec) 
    if    (   fee-spec-fr < batch-speciality 
           or fee-spec-fr = batch-speciality) 
      and (   fee-spec-to = batch-speciality 
           or fee-spec-to > batch-speciality) 
    then 
        move batch-speciality		to	clmhdr-doc-spec-cd 
    else 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 21				to	err-ind 
	move batch-speciality    	to	err-21-value-1 
	move hdr-oma-cd          	to	err-21-value-2 
	move fee-spec-fr         	to	err-21-value-3 
	move fee-spec-to         	to	err-21-value-4 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
*  the following move statement cause invalid digit because it 
*  tried to move character into numeric field - 91/09/18 by m.c. 
*   	move "???"			to	batch-speciality 
    	move "??"			to      clmhdr-doc-spec-cd-alpha 
 
	move "????"			to	hdr-oma-cd. 
*   endif 
 
*   (determine if referring phy. nbr required, and if so that the nbr is valid) 
    if hdr-refer-pract-nbr =   spaces 
			    or zeros 
    then 
        if fee-phy-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move hdr-oma-cd		to	err-22-oma-cd 
	    move "referring physician"	to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	    move "??????"		to	clmhdr-refer-doc-nbr-alpha 
	else 
*	    (no referring phy. specified but none was required) 
	    move zero			to	clmhdr-refer-doc-nbr 
*	endif 
    else 
*	(referring phy. specified - ensure that nbr is valid) 
	perform fb02-verify-referring-phys-nbr 
					thru	fb02-99-exit 
    	if invalid-refer-phys 
    	then 
	    move "??????"		to	clmhdr-refer-doc-nbr-alpha 
	else 
	    move hdr-refer-pract-nbr 	to	clmhdr-refer-doc-nbr. 
*	endif 
*   endif 
 
*   (determine if diagnostic code is required, and if so that the code is valid) 
    if hdr-diag-code =   spaces 
		    or zeros 
    then 
        if fee-diag-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move hdr-oma-cd		to	err-22-oma-cd 
	    move "diagnostic code"	to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	    move "???"		to	clmhdr-diag-cd-alpha 
	else 
*	    (no diag. code specified but none was required) 
	    move zero			to	clmhdr-diag-cd 
*	endif 
    else 
*	(diag. code specified - ensure that code is valid) 
        move hdr-diag-code		to	diag-cd 
	perform fb03-verify-diag-code	thru	fb03-99-exit 
    	if invalid-diag-code 
    	then 
	    move "???"			to	clmhdr-diag-cd-alpha 
	else 
	    move hdr-diag-code	 	to	clmhdr-diag-cd. 
*	endif 
*   endif 
 
*   (determine if valid location for doctor) 
    perform fb04-verify-doc-location	thru	fb04-99-exit. 
    if invalid-location 
    then 
	move "????"              	to	clmhdr-loc 
    else 
	move hdr-loc-code	 	to	clmhdr-loc. 
*   endif 
 
*   (determine if hosptital nbr is required, and if so that the code is valid - 
*    - if valid, replace 4 digit hospital number with 1 character code) 
    if hdr-hosp-nbr =   spaces 
		     or zeros 
    then 
        if fee-hosp-nbr-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move hdr-oma-cd		to	err-22-oma-cd 
	    move "hospital number"	to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	    move "?"			to	clmhdr-hosp 
	else 
*	    (no hospital nbr specified but none was required) 
	    move space			to	clmhdr-hosp 
*	endif 
    else 
*	(hospital nbr specified - ensure that nbr is valid and translate to hosp code) 
        perform fb05-verify-hospital	thru	fb05-99-exit 
    	if clmhdr-hosp = "?" 
    	then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 23			to	err-ind 
	    move hdr-hosp-nbr		to	err-hosp-nbr 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	else 
	    next sentence. 
*	endif 
*   endif 
 
*   (if requested by operator, set all blank agent codes to 'OHIP') 
    if ws-agent-default-reply = "Y" 
    then 
	move "0"			to	hdr-agent-cd. 
*   endif 
 
*   (determine if valid agent) 
    perform fb06-verify-agent		thru	fb06-99-exit 
    if invalid-agent-cd 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 20				to	err-ind 
	move hdr-agent-cd        	to	err-agent-cd 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "?"			to	clmhdr-agent-cd 
    else 
	move hdr-agent-cd		to	clmhdr-agent-cd. 
*   endif 
 
    if def-agent-ohip 
    then 
* (y2k)
	move zero			to	clmhdr-date-cash-tape-payment 
    else 
*      (print warning that direct bill agent entered and all direct 
*       bill info is missing) 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 25				to	err-ind 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "??"			to	clmhdr-msg-nbr 
	move "?"			to	clmhdr-reprint-flag 
	move "?"			to	clmhdr-sub-nbr 
	move "?"			to	clmhdr-auto-logout 
	move "?"			to	clmhdr-fee-complex. 
*   endif 
 
*   move zeros				to	clmhdr-adj-cd. 
    move spaces				to	clmhdr-adj-cd. 
 
 
*   (set indicator to assume that claim can be submitted on tape - when 
*    actual claim is built the details were be checked to ensure that 
*    this indicator is set correclty) 
    if clmhdr-agent-cd = 0 
    then 
        move "Y"			to	clmhdr-tape-submit-ind 
    else 
	move "N"			to	clmhdr-tape-submit-ind. 
*   endif 
 
*   (determine if in/out indicator is required, and if so that it is valid) 
    if hdr-i-o-ind =   spaces 
		    or zeros 
    then 
        if fee-i-o-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move hdr-oma-cd		to	err-22-oma-cd 
	    move "IN/OUT PATIENT INDICATOR" 
					to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	    move "?"			to	clmhdr-i-o-pat-ind. 
*	endif 
*   endif 
 
    perform fb07-verify-in-out-ind	thru	fb07-99-exit 
    if invalid-in-out-ind 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 15				to	err-ind 
	move hdr-i-o-ind         	to	err-i-o-ind 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "?"	              	to	clmhdr-i-o-pat-ind 
    else 
	if hdr-i-o-ind = 1 
	then 
	    move "I"			to	clmhdr-i-o-pat-ind 
	else 
	    if hdr-i-o-ind = 2 
	    then 
	        move "O"		to	clmhdr-i-o-pat-ind 
	    else 
*		(if indicator is blank - consider as 'OUT' patient) 
 	        move "O"		to	clmhdr-i-o-pat-ind. 
*	    endif 
*	endif 
*   endif 
 
*   (determine if valid ohip nbr) 
**  if hdr-ohip-nbr not = zeros and not = spaces 
**  then 
**      perform fb08-verify-ohip-nbr	thru	fb08-99-exit 
**      if valid-ohip 
**      then 
**	   move "O"			to	clmhdr-pat-key-type 
**	   move hdr-ohip-nbr		to	clmhdr-pat-key-data 
**      else 
**	   move "?"			to	clmhdr-pat-key-type 
**	   move "????????"		to	clmhdr-pat-key-data. 
*       endif 
*   else 
*   endif 
 
    move zero				to 	clmhdr-status-ohip. 
 
    move hdr-surname			to	clmhdr-pat-acronym6. 
    move hdr-first-name			to	clmhdr-pat-acronym3. 
    move spaces				to	clmhdr-reference. 
 
*   (check if admit date is required, and if so verify that date is valid) 
* (y2k)
    if hdr-admit-date =   spaces 
		       or zeros 
    then 
        if fee-admit-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move hdr-oma-cd		to	err-22-oma-cd 
	    move "ADMIT DATE"		to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
* (y2k)
	    move "??????"		to	clmhdr-date-admit 
	else 
*	    (no admit date  specified but none was required) 
* (y2k)
	    move zero			to	clmhdr-date-admit 
*	endif 
    else 
*	(admit date specified - ensure that date is valid) 
* (y2k)
        move hdr-admit-yy   		to	ws-date-yy 
* (y2k)
        move hdr-admit-mm   		to	ws-date-mm 
* (y2k)
        move hdr-admit-dd   		to	ws-date-dd 
	perform xd0-verify-date	thru	xd0-99-exit 
* (y2k)
    	if invalid-date 
    	then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 26			to	err-ind 
* (y2k)
	    move hdr-admit-date		to	err-admit-date 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
* (y2k)
	    move "??????"		to	clmhdr-date-admit 
	else 
* (y2k)
	    move hdr-admit-yy		to	clmhdr-date-admit-yy 
* (y2k)
	    move hdr-admit-mm  		to	clmhdr-date-admit-mm 
* (y2k)
	    move hdr-admit-dd  		to	clmhdr-date-admit-dd. 
*	endif 
*   endif 
 
 
* (y2k)
    move sys-date			to	clmhdr-date-sys. 
    move doc-dept      			to	clmhdr-doc-dept. 
    move zero				to	clmhdr-curr-payment 
						clmhdr-amt-tech-billed 
						clmhdr-amt-tech-paid. 
 
*   (if province is blank assume it'S ONTARIO) 
    if hdr-health-care-prov = spaces 
    then 
        move "ON"			to	hdr-health-care-prov. 
*   endif 
 
    if hdr-health-care-nbr = spaces 
    then 
	perform xb0-print-warning-line 
					thru	xb0-99-exit 
	move 1 				to	ws-carriage-ctrl 
	move 29				to	err-ind 
	move hdr-health-care-nbr		 
					to	err-health-care-nbr 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "??????????"		to	clmhdr-health-care-nbr 
    else 
        move hdr-health-care-nbr	to	clmhdr-health-care-nbr 
*       (the following two move stmt added on 91/04/23 by m.c. - moved to 
*	 new lines number by b.l. 91/sep/05) 
	move hdr-health-care-nbr	to	clmhdr-pat-key-data 
	move "O"			to 	clmhdr-pat-key-type 
        if hdr-health-care-prov = 'ON' 
        then 
            move hdr-health-care-nbr	to	ws-nbr-10 
            if   ws-nbr-10 not numeric 
	      or ws-nbr-10 = zero 
	    then 
	        perform xb0-print-warning-line 
					thru	xb0-99-exit 
	        move 1 			to	ws-carriage-ctrl 
	        move 29			to	err-ind 
	        move hdr-health-care-nbr		 
					to	err-health-care-nbr 
	        perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	        move "??????????"	to	clmhdr-health-care-nbr 
	    else 
                move hdr-health-care-nbr	 
					to	ws-check-nbr-10 
                perform db0a-mod10-check-digit-10	thru	db0a-99-exit 
                if flag = 'N' 
		then 
	            perform xb0-print-warning-line 
					thru	xb0-99-exit 
	            move 1		to	ws-carriage-ctrl 
	            move 29		to	err-ind 
	            move hdr-health-care-nbr to	err-health-care-nbr 
	            perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	            move "??????????"	to	clmhdr-health-care-nbr 
                else 
*		(data is ok - has already been moved into clmhdr fields 
		    next sentence. 
*		endif 
*	    endif 
*       endif 
*    endif 
    move hdr-health-care-ver	  	to	clmhdr-health-care-ver 
*  ??????????????? field below requires verification ?????????????????? 
 
    if hdr-health-care-prov = spaces 
    then 
        move 'Y'			to	province-flag 
    else 
        move 'N'			to	province-flag 
        perform fb0a-search-province	thru	fb0a-99-exit 
	    varying sub from 1 by 1 
	    until (province-found or sub > 13). 
*endif 
    if province-not-found 
    then 
	perform xb0-print-warning-line 
					thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 30				to	err-ind 
	move hdr-health-care-prov	to	err-province 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "??"			to	clmhdr-health-care-prov 
    else 
        move hdr-health-care-prov	to	clmhdr-health-care-prov. 
 
*  ??????????????? field below requires verification ?????????????????? 
    if hdr-relationship =  spaces 
			or '1' 
			or '2' 
			or '3' 
    then 
        move hdr-relationship		to	clmhdr-relationship 
    else 
	perform xb0-print-warning-line 
					thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 31				to	err-ind 
	move hdr-relationship		to	err-relationship 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	move "?"			to	clmhdr-relationship. 
*endif 
*  ?????????????????????????????????????????????????????????????????????? 
    move hdr-patient-surname		to	clmhdr-patient-surname. 
    move hdr-subscr-initials		to	clmhdr-subscr-initials. 
    move hdr-wcb-claim-nbr		to	clmhdr-wcb-claim-nbr. 
* (y2k)
    move hdr-wcb-accident-date		to	clmhdr-wcb-accident-date. 
    move hdr-wcb-employer-name-addr 
					to	clmhdr-wcb-employer-name-addr. 
    move hdr-wcb-employer-postal-code 
*mf					to	clmhdr-wcb-employer-postal-code.
					to	clmhdr-wcb-employer-postal-cd. 
 
    move doc-pract-nbr			to	clmhdr-doc-nbr-ohip 
					clmhdr-doc-pract-nbr. 
    move hdr-accounting-nbr 		to	clmhdr-accounting-nbr. 
 
fb0-99-exit. 
    exit. 
 
fb0a-search-province. 
 
    if hdr-health-care-prov = prov(sub) 
    then 
	move "Y"			to province-flag. 
*   endif 
 
fb0a-99-exit. 
    exit. 
 
fb02-verify-referring-phys-nbr. 
 
*   move hdr-refer-pract-nbr		to	ws-chk-ind. 
*   move "Y"				to	flag-refer-phys. 
 
    move hdr-refer-pract-nbr		to	ws-chk-nbr. 
*   if      ws-chk-nbr     = zeroes 
	if  ws-chk-nbr-8   = 1 
	or  ws-chk-nbr-8   = 2 
    then 
	perform dc0-mod10-check-digit-for-1-2 thru dc0-99-exit 
    else perform db0-mod10-check-digit	thru	db0-99-exit. 
*   endif 
 
    move flag				to	flag-refer-phys. 
 
    if invalid-refer-phys 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 12				to	err-ind 
	move hdr-refer-pract-nbr	to	err-refer-phys-nbr 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit. 
*   endif 
 
fb02-99-exit. 
exit. 
 
fb03-verify-diag-code. 
 
    move "Y"				to	flag-diag-cd. 
*mf    read diag-mstr	suppress data record 
    read diag-mstr
	invalid key 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 14				to	err-ind 
*   	move hdr-diag-code      	to	err-diag-code 
	move diag-cd            	to	err-diag-code 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit 
	move		'N'		to	flag-diag-cd. 
 
fb03-99-exit. 
    exit. 
 
 
 
fb04-verify-doc-location. 
 
    move 'N'				to	flag-location. 
    if hdr-loc-code not = spaces 
    then 
        perform fb04a-search-doc-location	thru	fb04a-99-exit 
	    varying sub 
	    from 1 
	    by   1 
	    until   sub > max-doc-locations 
	         or valid-location. 
*   endif 
 
    if invalid-location 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 3				to	err-ind 
	move hdr-loc-code  		to	err-msg-loc-cd 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit. 
*   endif 
 
 
fb04-99-exit. 
    exit. 
 
fb04a-search-doc-location. 
 
    if hdr-loc-code = doc-loc(sub) 
    then 
	move 'Y'			to flag-location. 
*   endif 
 
fb04a-99-exit. 
    exit. 
 
copy "verify_agent_code.rtn" 
     replacing	==xx00-verify-agent==	by ==fb06-verify-agent== 
		==xx00-99-exit==	by ==fb06-99-exit== 
		==agent-2b-tested==	by ==hdr-agent-cd==. 
copy "hospital.dc". 
 
copy "hosp_nbr_code_to_nbr.rtn" 
     replacing	==ca11-move-hosp==	by ==fb05-verify-hospital== 
		==ca11-10-hosp-loop==	by ==fb05-10-hosp-loop== 
		==ca11-99-exit==	by ==fb05-99-exit== 
		==clmhdr-hosp==		by ==hdr-hosp-nbr== 
		==hosp-nbr==		by ==hosp-code== 
		==hosp-code==		by ==hosp-nbr== 
		==spaces==		by =="?"== 
		==l1-hosp==		by ==clmhdr-hosp==. 
fb07-verify-in-out-ind. 
 
    if hdr-i-o-ind = "1" or "2" or spaces 
    then 
	move "Y"			to	flag-in-out-ind 
    else 
	move "N"			to	flag-in-out-ind. 
*   endif 
 
fb07-99-exit. 
    exit. 
fb08-verify-ohip-nbr. 
 
*   mod check digit requires the following variables: 
*		dummy		pic 9(3). 
*		rem-even	pic 9v9(4). 
*		max-nbr-digits  pic 99		value 7. 
*		sub		pic 99 comp. 
*		ws-val-total	pic s9(7). 
    move hdr-ohip-nbr			to ws-nbr-to-b-val. 
    move zero				to ws-val-total. 
    perform fb08a-odd-even		thru fb08a-99-exit 
					varying sub from 1 by 1 
					until sub > max-nbr-digits. 
 
fb08-10-total-loop. 
 
    if ws-val-total = 10 
    then 
	move zero			to ws-val-total 
    else 
	if ws-val-total > 10 
	then 
	    subtract 10			from ws-val-total 
					giving ws-val-total 
	    go to fb08-10-total-loop 
	else 
	    subtract ws-val-total 	from 10 
					giving ws-val-total. 
*   	endif 
*   endif 
 
    if ws-val-total not = ws-nbr-to-b-val-1-8(8) 
    then 
	move "N"			to flag-ohip 
    else 
	move "Y"			to flag-ohip. 
*   endif 
 
    if invalid-ohip 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 13				to	err-ind 
	move hdr-ohip-nbr		to	err-ohip-nbr 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit. 
*   endif 
 
fb08-99-exit. 
    exit. 
 
 
fb08a-odd-even. 
 
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
 
fb08a-99-exit. 
    exit. 
 
fc0-build-susp-dtl-from-hdr. 
 
    move spaces		        to suspend-dtl-rec. 
 
    move clmhdr-batch-nbr	to clmdtl-batch-nbr. 
 
*   (determine if valid oma fee code) 
*   perform xc0-check-oma-code	thru	xc0-99-exit. 
    move hdr-oma-cd          to clmdtl-oma-cd. 
 
    move hdr-oma-suff        to clmdtl-oma-suff. 
    move zero                to clmdtl-adj-nbr. 
    move spaces              to clmdtl-rev-group-cd. 
    move clmhdr-agent-cd     to clmdtl-agent-cd. 
 
    move clmhdr-diag-cd	     to clmdtl-diag-cd. 
 
*   move zeroes              to clmdtl-adj-cd. 
    move clmhdr-adj-cd       to clmdtl-adj-cd. 
 
*   (91/mar/13 b.e.) 
*   (sum nbr services for audit totals) 
    add  hdr-nbr-of-serv     to	ctr-tot-svcs-read. 
    move hdr-nbr-of-serv     to clmdtl-nbr-serv. 
 
*   (verify service date is valid) 
* (y2k)
    move hdr-serv-date-dd    to ws-date-dd. 
* (y2k)
    move hdr-serv-date-mm    to ws-date-mm. 
* (y2k)
    move hdr-serv-date-yy    to ws-date-yy. 
    perform xd0-verify-date  thru xd0-99-exit. 
* (y2k)
    if invalid-date 
    then 
        perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 27				to	err-ind 
* (y2k)
	move hdr-serv-date       	to	err-27-service-date 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
* (y2k)
	move "??????"			to	clmdtl-sv-date 
    else 
*	(service is valid - ensure it is not stale-dated ie. not within 6 months of current system date) 
* (y2k)
         if   (hdr-serv-date-yy * 365) 
* (y2k)
            + (hdr-serv-date-mm *  30) 
*	      (+ 6 months times 30 days = 180) 
            + 180 
* (y2k)
            + hdr-serv-date-dd 
* (y2k)
            < (sys-yy * 365) + (sys-mm * 30) + sys-dd 
	then 
            perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 24			to	err-ind 
* (y2k)
	    move hdr-serv-date       	to	err-24-service-date 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
* (y2k)
	    move "??????"		to	clmdtl-sv-date 
	else 
*	   (initial service date is valid and within 6 months of current date) 
* (y2k)
    	    move hdr-serv-date-dd	to	clmdtl-sv-dd 
* (y2k)
    	    move hdr-serv-date-mm	to	clmdtl-sv-mm 
* (y2k)
    	    move hdr-serv-date-yy	to	clmdtl-sv-yy 
*	    (verify "ADDITIONAL SERVICES" if specified) 
	    if hdr-add-serv not = spaces 
	    then 
*	        (verify valid date and that services fall within month) 
		move "Y"		to	flag-consec 
		move 1			to	ss 
		perform fc1-verify-consec-servs 
					thru	fc1-99-exit 
		move 2			to	ss 
		perform fc1-verify-consec-servs 
					thru	fc1-99-exit 
		move 3			to	ss 
		perform fc1-verify-consec-servs 
					thru	fc1-99-exit 
	    else 
* (y2k)
		move zeros		to	clmdtl-consec-dates. 
*	    endif 
*	endif 
*   endif 
 
*   ?????????? no edit on fee billed pgmmed as yet ?????????? 
    move hdr-fee-billed      to clmdtl-fee-oma. 
    move hdr-fee-billed      to clmdtl-fee-ohip. 
*   ????????????????????????????????????????????????????????? 
*   ?????????? no edit on tech/prof component of fee ????????? 
    move zero		      to clmdtl-amt-tech-billed. 
*   ????????????????????????????????????????????????????????? 
    move clmhdr-doc-pract-nbr to clmdtl-doc-pract-nbr. 
    move clmhdr-accounting-nbr to clmdtl-accounting-nbr. 
 
fc0-99-exit. 
    exit. 
 
fc1-verify-consec-servs. 
 
    if hdr-add-servs(ss) not = spaces 
    then 
	 add hdr-add-serv-nbr(ss)	to	ctr-tot-svcs-read 
	if   hdr-add-serv-day(ss) not numeric 
	  or hdr-add-serv-day(ss) < 01 
* (y2k)
	  or hdr-add-serv-nbr(ss) + hdr-add-serv-day(ss) - 1 > max-nbr-days(hdr-serv-date-mm) 
	then 
            perform xb0-print-warning-line 
				thru	xb0-99-exit 
	    move 1		to	ws-carriage-ctrl 
	    move 28		to	err-ind 
	    move hdr-add-serv	to	err-additional-servs 
	    perform zb0-build-write-err-rpt-line 
				thru	zb0-99-exit 
* (y2k)
	    move "???"		to	clmdtl-consecutive-sv-date(ss) 
	else 
* (y2k)
 	    move hdr-add-servs(ss)	to	clmdtl-consecutive-sv-date(ss) 
*	move "N"			to	flag-consec 
*       endif 
    else 
	next sentence. 
*   endif 
fc1-99-exit. 
    exit. 
fd0-build-susp-addr-1st-half. 
 
    move spaces		    to suspend-address-rec. 
 
    move hdr-surname         to addr-surname. 
    move hdr-first-name      to addr-first-name. 
*   move hdr-birth-date      to addr-birth-date. 
* (y2k)
    move hdr-birth-date	     to hold-birth-mmyy. 
* (y2k)
    move hold-birth-yy       to addr-birth-yy. 
    move hold-birth-mm       to addr-birth-mm. 
    move 01		     to addr-birth-dd. 
 
 
    if hdr-sex = '1' 
    then 
	move 'M'    to addr-sex 
    else 
    if hdr-sex = '2' 
    then 
	move 'F'    to addr-sex. 
*   endcase 
 
    move clmhdr-doc-pract-nbr to addr-doc-pract-nbr. 
    move clmhdr-accounting-nbr to addr-accounting-nbr. 
 
fd0-99-exit. 
    exit. 
ga0-proc-rec-type-detail. 
 
*   (sum total fee $ processed) 
    add dtl-fee-billed			to	ctr-tot-dollars-read. 
 
    perform gb0-build-susp-dtl-from-dtl 
					thru gb0-99-exit. 
 
    perform yd0-write-dtl-rec thru yd0-99-exit. 
 
ga0-99-exit. 
    exit. 
 
 
 
gb0-build-susp-dtl-from-dtl. 
 
*   ???????????????????????????????????????????????????????????????????????????? 
    move spaces          	to suspend-dtl-rec. 
    move clmhdr-batch-nbr	to clmdtl-batch-nbr. 
 
*   (determine if valid oma code) 
 
    move dtl-oma-cd		to fee-oma-cd. 
    perform xc0-check-oma-code		thru xc0-99-exit. 
 
    move dtl-oma-cd         to clmdtl-oma-cd. 
*   ???????????????????????????????????????????????????????????????????????????? 
 
    move dtl-oma-suff       to clmdtl-oma-suff. 
    move 0                  to clmdtl-adj-nbr. 
    move 0                  to clmdtl-rev-group-cd. 
    move clmhdr-agent-cd    to clmdtl-agent-cd. 
    move clmhdr-adj-cd      to clmdtl-adj-cd. 
 
    perform gb1-verify-dtl-diag-cd thru gb1-99-exit. 
 
*   (91/mar/13 b.e.) 
*   (sum nbr services for audit totals) 
    add  dtl-nbr-of-serv    to ctr-tot-svcs-read. 
    move dtl-nbr-of-serv    to clmdtl-nbr-serv. 
 
*   (verify date ??????) 
* (y2k)
    move dtl-serv-date-dd   to clmdtl-sv-dd. 
* (y2k)
    move dtl-serv-date-mm   to clmdtl-sv-mm. 
* (y2k)
    move dtl-serv-date-yy   to clmdtl-sv-yy. 
 
*	    (verify "ADDITIONAL SERVICES" if specified) 
	    if dtl-add-serv not = spaces 
	    then 
*	        (verify valid date and that services fall within month) 
		move "Y"		to	flag-consec 
		move 1			to	ss 
		perform gb2-verify-consec-servs 
					thru	gb2-99-exit 
		move 2			to	ss 
		perform gb2-verify-consec-servs 
					thru	gb2-99-exit 
		move 3			to	ss 
		perform gb2-verify-consec-servs 
					thru	gb2-99-exit 
	    else 
* (y2k)
		move zeros		to	clmdtl-consec-dates. 
*	    endif 
*	endif 
*   endif 
 
    move dtl-fee-billed     to clmdtl-amt-tech-billed. 
    move dtl-fee-billed     to clmdtl-fee-oma. 
    move dtl-fee-billed     to clmdtl-fee-ohip. 
    move clmhdr-doc-pract-nbr to clmdtl-doc-pract-nbr. 
    move clmhdr-accounting-nbr to clmdtl-accounting-nbr. 
 
gb0-99-exit. 
    exit. 
gb2-verify-consec-servs. 
 
    if dtl-add-servs(ss) not = spaces 
    then 
	add dtl-add-serv-nbr(ss)	to	ctr-tot-svcs-read 
	if   dtl-add-serv-day(ss) not numeric 
	  or dtl-add-serv-day(ss) < 01 
* (y2k)
	  or dtl-add-serv-nbr(ss) + dtl-add-serv-day(ss) - 1 > max-nbr-days(dtl-serv-date-mm) 
	then 
            perform xb0-print-warning-line 
				thru	xb0-99-exit 
	    move 1		to	ws-carriage-ctrl 
	    move 28		to	err-ind 
	    move dtl-add-serv	to	err-additional-servs 
	    perform zb0-build-write-err-rpt-line 
				thru	zb0-99-exit 
* (y2k)
	    move "???"		to	clmdtl-consecutive-sv-date(ss) 
	else 
* (y2k)
	    move dtl-add-servs(ss)	to	clmdtl-consecutive-sv-date(ss) 
*	        endif 
*    move "N"			to	flag-consec 
*	else 
*       endif 
    else 
	next sentence. 
*   endif 
gb2-99-exit. 
    exit. 
gb1-verify-dtl-diag-cd. 
 
    if dtl-diag-code =   spaces 
		      or zeros 
    then 
        if fee-diag-ind = "Y" 
        then 
	    perform xb0-print-warning-line 
					thru	xb0-99-exit 
	    move 1			to	ws-carriage-ctrl 
	    move 22			to	err-ind 
	    move dtl-oma-cd		to	err-22-oma-cd 
	    move "DIAGNOSTIC CODE"	to	err-22-msg 
	    perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
	    move "???"			to	clmdtl-diag-cd-alpha 
	else 
*	    (no diag. code specified but none was required) 
	    move zero			to	clmdtl-diag-cd 
*	endif 
    else 
*	(diag. code specified - ensure that code is valid) 
        move dtl-diag-code		to	diag-cd 
	perform fb03-verify-diag-code	thru	fb03-99-exit 
    	if invalid-diag-code 
    	then 
	    move "???"			to	clmdtl-diag-cd-alpha 
	else 
	    move dtl-diag-code	 	to	clmdtl-diag-cd. 
*	endif 
*   endif 
 
gb1-99-exit. 
    exit. 
 
ia0-proc-rec-type-address. 
 
    perform ib0-build-susp-addr-2nd-half 
				thru	ib0-99-exit. 
 
    perform ye0-write-addr-rec	thru	ye0-99-exit. 
 
 
ia0-99-exit. 
    exit. 
 
 
 
 
ib0-build-susp-addr-2nd-half. 
 
    move addr-ln-1 		to addr-address-line-1. 
    move addr-ln-2 		to addr-address-line-2. 
    move addr-ln-3 		to addr-address-line-3. 
    move addr-pc   		to addr-postal-code. 
 
ib0-99-exit. 
    exit. 
ka0-proc-rec-type-trailer. 
 
* ??????????????????????????????????????????????????????????????????????? 
*	check if audit totals match trailer rec total - warning message 
 
    add ctr-h-recs-read 
* (y2k)
        ctr-h-recs-skipped	giving ctr-tot-h-recs. 
 
    add ctr-t-recs-read 
* (y2k)
        ctr-t-recs-read-skipped	giving ctr-tot-t-recs. 
 
    add ctr-a-recs-read 
* (y2k)
        ctr-a-recs-read-skipped	giving ctr-tot-a-recs. 
 
    if trl-h-count not = ctr-tot-h-recs 
    then 
	perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 16				to	err-ind 
	move ctr-tot-h-recs		to	err-ctr-h-count 
	move trl-h-count		to	err-trl-h-count 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit. 
*   endif 
    if trl-t-count not = ctr-tot-t-recs 
    then 
	perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 17				to	err-ind 
	move ctr-tot-t-recs		to	err-ctr-t-count 
	move trl-t-count		to	err-trl-t-count 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit. 
*   endif 
    if trl-a-count not = ctr-tot-a-recs 
    then 
	perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 18				to	err-ind 
	move ctr-tot-a-recs		to	err-ctr-a-count 
	move trl-a-count		to	err-trl-a-count 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit. 
*   endif 
    if    trl-b-count not = zero 
      and trl-b-count not = ctr-b-recs-read 
    then 
	perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 19				to	err-ind 
	move ctr-b-recs-read		to	err-ctr-b-count 
	move trl-b-count		to	err-trl-b-count 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit. 
*   endif 
 
    perform ka1-print-batch-audit-tots	thru	ka1-99-exit. 
 
ka0-99-exit. 
    exit. 
ka1-print-batch-audit-tots. 
 
*  (print batch audit counters on new page) 
    move 99					to ctr-lines-printed. 
    move 2 					to ws-carriage-ctrl. 
 
    move "********** AUDIT COUNTERS **********"	to audit-title. 
    move zero					to audit-value 
						   audit-value-2 
						   audit-value-3. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
  
    move 3 					to ws-carriage-ctrl. 
    move "TOTAL NBR INPUT RECORDS READ= "	to audit-title. 
    move ctr-recs-read				to audit-value 
						   audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move 2 					to ws-carriage-ctrl. 
    move "NBR OF BATCH   RECORDS READ = "	to audit-title. 
    move ctr-b-recs-read			to audit-value 
						   audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF TRAILER RECORDS READ = "	to audit-title. 
    move ctr-e-recs-read			to audit-value 
						   audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF HEADER  RECORDS READ = "	to audit-title. 
    move ctr-h-recs-read			to audit-value 
						   audit-value-3 
						   audit-value-4. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECORDS READ = "	to audit-title. 
    move ctr-t-recs-read			to audit-value 
						   audit-value-3. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECS SKIPPED = "	to audit-title. 
* (y2k)
    move ctr-t-recs-read-skipped		to audit-value 
						   audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF ADDRESS RECORDS READ = "	to audit-title. 
    move ctr-a-recs-read			to audit-value 
						   audit-value-4. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "TOTAL SVCS HDRS/DETAILS READ= "	to audit-title. 
    move ctr-tot-svcs-read			to audit-value-5. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "TOTAL $$$  HDRS/DETAILS READ= "	to audit-title. 
    move ctr-tot-dollars-read			to audit-value-5. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF ADDRESS RECS SKIPPED = "	to audit-title. 
* (y2k)
    move ctr-a-recs-read-skipped		to audit-value 
						   audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move 3 					to ws-carriage-ctrl. 
    move "NBR OF HEADER  RECORDS WRITTEN = "	to audit-title. 
    move ctr-suspend-hdr-writes			to audit-value-2 
						   audit-value-4. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move 2 					to ws-carriage-ctrl. 
    move "NBR OF HEADER  RECORDS SKIPPED = "	to audit-title. 
* (y2k)
    move ctr-h-recs-skipped			to audit-value-2. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECORDS WRITTEN = "	to audit-title. 
    move ctr-suspend-dtl-writes			to audit-value-2 
						   audit-value-3. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
    move "NBR OF ADDRESS RECORDS WRITTEN = "	to audit-title. 
    move ctr-suspend-addr-writes		to audit-value-4. 
    move audit-line				to rpt-line. 
    move spaces					to audit-line. 
    perform zz0-write-err-rpt-line		thru zz0-99-exit. 
 
*  (force new page after totals) 
    move 99					to ctr-lines-printed. 
 
ka1-99-exit. 
    exit. 
xb0-print-warning-line. 
 
    move 2			to	ws-carriage-ctrl. 
    move 1			to	err-ind. 
    move batch-provider-nbr	to	err-msg-pract-nbr. 
    move hdr-accounting-nbr	to	err-msg-account-id. 
    perform zb0-build-write-err-rpt-line 
				thru	zb0-99-exit. 
 
xb0-99-exit. 
    exit. 
 
xc0-check-oma-code. 
 
*   move hdr-oma-cd		to	fee-oma-cd. 
 
    perform yf0-read-oma-fee-mstr	thru yf0-99-exit. 
 
    if not valid-oma-code 
    then 
*	move "Y"			to	fatal-error-flag 
	move 2				to	ws-carriage-ctrl 
	move 8				to	err-ind 
	move clmhdr-accounting-nbr      to	err-accounting-nbr 
	perform zb0-build-write-err-rpt-line	thru	zb0-99-exit 
*       (blank out oma fee record since it was invalid) 
	move spaces			to	fee-mstr-rec. 
*   endif 
 
xc0-99-exit. 
    exit. 
xd0-verify-date. 
 
* (y2k)
    move "Y"				to flag-date. 
 
* (y2k)
    if ws-date-yy < 89 
    then 
* (y2k)
	move "N"			to flag-date 
	go to xd0-99-exit. 
*   endif 
 
* (y2k)
    if   ws-date-mm < 1 
* (y2k)
      or ws-date-mm > 12 
    then 
* (y2k)
	move "N"			to flag-date 
    else 
* (y2k)
	if   ws-date-dd < 1 
* (y2k)
	  or ws-date-dd > max-nbr-days (ws-date-mm) 
	then 
* (y2k)
	    move "N"			to flag-date. 
*	endif 
*   endif 
 
xd0-99-exit. 
    exit. 
ya0-read-diskette. 
 
    move low-values			to	diskette-input-record. 
 
    read input-diskette 
	at end 
	    move "Y" to eof-input-file-flag 
	    go to ya0-99-exit. 
 
*  (replace any nulls in record with blanks) 
    inspect diskette-input-record replacing all low-values by spaces. 
*  (replace any carriage-returns in record with blanks) 
    inspect diskette-input-record replacing all carriage-return by spaces. 
 
*   (set flag to test record type) 
    move diskette-input-rec-type to	record-type-flags. 
 
*   (check whether this record will be processed or skipped) 
    if    skip-processing-this-acct-id 
      and t-record 
    then 
* (y2k)
	add 1			to	ctr-t-recs-read-skipped 
    else 
        if   (skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl) 
          and a-record 
        then 
* (y2k)
	    add 1		to	ctr-a-recs-read-skipped 
	else 
	    next sentence. 
*	endif 
*   endif 
 
    add 1			to	ctr-recs-read. 
 
ya0-99-exit. 
    exit. 
 
 
 
 
yb0-read-doc. 
 
    move "Y"			to flag-doc. 
    read doc-mstr 
	key is doc-ohip-nbr
	invalid key move "N"	to flag-doc 
		    go to yb0-99-exit. 
 
    if ws-doc-nbr not equal to 0 and 
       ws-doc-nbr not equal to doc-nbr 
    then 
	perform yb1-read-next-doc   thru yb1-99-exit 
    else 
* (y2k)
    	if doc-date-fac-term greater than '000000' 
    	then 
	    perform yb1-read-next-doc   thru yb1-99-exit. 
*   	endif 
*   endif 
 
 
yb0-99-exit. 
    exit. 
 
 
 
 
yb1-read-next-doc. 
 
    read doc-mstr next 
  	at end 
	     move "N"		to flag-doc 
	     go to yb1-99-exit. 
 
    if doc-pract-nbr not equal to batch-provider-nbr 
    then 
	move "N"		to flag-doc 
    else 
* (y2k)
	if doc-date-fac-term greater than '000000' 
	then 
	    go to yb1-read-next-doc 
	else 
	    if     ws-doc-nbr not equal to 0 
	       and ws-doc-nbr not equal to doc-nbr 
	    then 
		go to yb1-read-next-doc. 
*	    endif 
*	endif 
*   endif 
 
yb1-99-exit. 
    exit. 
 
yc0-write-hdr-rec. 

*   (98/oct/16 B.E. cloned logic from newu701 to summarize $ into header)
    move ctr-tot-dollars-claim  to clmhdr-tot-claim-ar-oma
                                  clmhdr-tot-claim-ar-ohip.
 
*mf    write suspend-hdr-rec	key is suspend-hdr-id. 
    write suspend-hdr-rec.
 
*   (check for error flag set by declaratives on previous write stmnt) 
    if skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl 
    then 
*         (note: 90/01/14 b.e. logic will allow writing of header to fail but flag has been 
*          set so that the detail recs  for this header will be processed and therefore 
*          will become details for the header already on file. message on warning 
*          report should alert staff to review claim to confirm that these 
*          headers are for same patient) 
 
	perform xb0-print-warning-line	thru	xb0-99-exit 
	move 1				to	ws-carriage-ctrl 
	move 9				to	err-ind 
	perform zb0-build-write-err-rpt-line 
					thru	zb0-99-exit 
* (y2k)
        add 1				to	ctr-h-recs-skipped 
	go to yc0-99-exit. 
*   endif 
 
*   (98/oct/16 B.E. - reset counter)
    move zero				to	ctr-tot-dollars-claim. 

    add 1				to	ctr-suspend-hdr-writes. 
 
yc0-99-exit. 
    exit. 
 
 
 
yd0-write-dtl-rec. 
 
*mf    write suspend-dtl-rec	key is suspend-dtl-id. 
    write suspend-dtl-rec.
 
    add 1			to ctr-suspend-dtl-writes. 
 
yd0-99-exit. 
    exit. 
 
 
 
ye0-write-addr-rec. 
 
*mf    write suspend-address-rec	key is suspend-addr-id 
    write suspend-address-rec
	invalid key 
	    move "D"		to skip-processing-acct-id-flag 
	    go to ye0-99-exit. 
 
 
    add 1			to ctr-suspend-addr-writes. 
 
ye0-99-exit. 
    exit. 
 
 
yf0-read-oma-fee-mstr. 
 
    move "Y"			to flag-oma. 
    read oma-fee-mstr 
	invalid key move "N"	to flag-oma. 
 
yf0-99-exit. 
    exit. 
zb0-build-write-err-rpt-line. 
 
    move err-msg (err-ind)		to	rpt-line. 
    perform zz0-write-err-rpt-line	thru	zz0-99-exit. 
 
zb0-99-exit. 
    exit. 
 
 
zz0-write-err-rpt-line. 
 
     add ws-carriage-ctrl		to	ctr-lines-printed. 
     if ctr-lines-printed > max-lines-per-page 
     then 
 	perform zz1-print-headings	thru	zz1-99-exit 
	move 1				to	ws-carriage-ctrl. 
*    endif 
 
    write rpt-line 	after advancing ws-carriage-ctrl lines. 
 
zz0-99-exit. 
    exit. 
 
 
 
zz1-print-headings. 
 
*   (save line that was to be printed, restore after headings printed) 
    move rpt-line		   to	save-prt-line. 
 
    add 1			   to	ws-rpt-page-nbr. 
    move ws-rpt-page-nbr	   to	rpt-page-nbr. 
    write rpt-line from heading-l1 after advancing page. 
 
    move spaces			   to	rpt-line 
    write rpt-line                 after advancing 2 lines. 
    move 2			   to	ctr-lines-printed. 
 
    move save-prt-line		   to	rpt-line. 
 
zz1-99-exit. 
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
