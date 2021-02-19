identification division. 
program-id. d050. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 82/04/23.    
date-compiled. 
security. 
* 
*    FILES	: F010 - PATIENT MASTER 
*		: F011 - SUBSCRIBER MASTER 
*		: F020 - DOCTOR MASTER 
*		: F030 - LOCATIONS MASTER 
*		: F050 - DOCTOR REVENUE MASTER 
*		: F090 - CONSTANTS MASTER 
*		: F070 - DEPT MASTER 
*		: R050 - DOCTOR REVENUE INQUIRY REPORT 
* 
*    PROGRAM PURPOSE : DOCTOR REVENUE INQUIRY 
* 
*               MAY/87 (S.B.) - COVERSION FROM AOS to AOS/VS. 
*                               CHANGE FIELD SIZE FOR 
*                               STATUS CLAUSE TO 2 AND 
*                               FEEDBACK CLAUSE TO 4. 
* 
*    REVISED DEC/87 (J.L.) - PDR 356 
*			   - AFTER ERROR MESSAGE IS DISPLAYED, HIT 
*			     SPACE BAR TO RETURN TO KEYING FIELD 
* 
*   REVISED MARCH/89 : - SMS 115 S.F. 
*		       - MAKE SURE FILE STATUS IS PIC XX ,FEEDBACK IS 
*			 PIC X(4) AND INFOS STATUS IS PIC X(11). 
* 
* 
*    MAY 2/89     S. FADER      - SMS 116 
*				- PRINT THE DEPT CODE AND/OR NAME 
* 
*    JULY 25/89   M. CHAN	- PDR 422 
*				- WHENEVER THE USER ASKS TO HAVE HARD 
*				  COPY PRINTED, MODIFY THE PROGRAM TO 
*				  EXECUTE THE CLI 'PRINT_D050_SCREENS'. 
*
* 1999/jan/31 B.E.		- y2k
* 1999/dec/15 B.E.		- mf cobol changes - removed hard copy option
*
* 2003/dec/08 M.C.		- alpha doc nbr
 
environment division. 
 
configuration section. 
special-names. 
*	"D050_SCREEN" is screen-dump-file. 
 
input-output section. 
file-control. 
* 
*   PLACE YOUR FILE SELECT STATEMENTS HERE 
* 
**  COPY "F010_NEW_PATIENT_MSTR.SLR". 
* 
**  COPY "F011_NEW_SUBSCRIBER_MSTR.SLR". 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f030_locations_mstr.slr". 
* 
    copy "f050_doc_revenue_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "f070_dept_mstr.slr". 
* 
data division. 
file section. 
* 
**  COPY "F010_PATIENT_MSTR.FD". 
* 
**  COPY "F011_SUBSCRIBER_MSTR.FD". 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f030_locations_mstr.fd". 
* 
    copy "f050_doc_revenue_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f070_dept_mstr.fd". 
* 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  reply					pic x. 
77  change-reply				pic x. 
77  ws-disp-pat-key-type			pic x(7). 
77  ws-disp-pat-err-msg				pic x(42). 
77  ws-max-nbr-lines				pic 99  value 56. 
77  ws-file-err-msg				pic x(42) value spaces. 
77  ws-max-nbr-loc				pic 9 value 5. 
 
77  option					pic x. 
77  pat-count					pic s999. 
**77  PAT-OCCUR					PIC 9999. 
77  display-key-type				pic x(7). 
77  temp					pic 999. 
77  end-job					pic x   value "N". 
* 
*  EOF FLAGS 
* 
**77  EOF-SUBSCR-MSTR				PIC X	VALUE "N". 
**77  EOF-PAT-MSTR				PIC X	VALUE "N". 
77  eof-docrev-mstr				pic x   value "N". 
* 
77  confirm-space				pic x   value space. 
* 
 
**01  KEY-PAT-MSTR. 
 
**  05  PAT-KEY-TYPE				PIC A. 
**  05  PAT-KEY-O-C-A				PIC X(15). 
 
 
01  macro-cli. 
    05  filler					pic x(25)  value 
		"PRINT_D050_SCREENS.CLI". 
 
01  hard-copy-flag				pic x  value 'N'. 
    88  hard-copy				value 'Y'. 
    88  no-hard-copy				value 'N'. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-user-resp				pic x. 
    88  flag-verif-acc				value "A". 
    88  flag-verif-rej				value "R". 
    88  flag-verif-mod				value "M". 
 
01  flag-valid-ohip-or-chart			pic x. 
    88  valid-ohip				value "Y". 
    88  valid-chart				value "Y". 
    88  invalid-ohip				value "N". 
    88  invalid-chart				value "N". 
 
01  flag-request-complete			pic x. 
    88  flag-request-complete-y			value "Y". 
    88  flag-request-complete-n			value "N". 
 
01  flag-carry-1         			pic x. 
    88  carry-1-yes             		value "Y". 
    88  carry-1-no              		value "N". 

 
 
01  flag-valid-docrev-rec			pic x. 
 
    88  flag-valid-docrev-rec-y			value "Y". 
    88  flag-valid-docrev-rec-n			value "N". 
 
 
01  flag-skip-read-approx			pic x. 
 
    88  flag-skip-read-approx-y			value "Y". 
    88  flag-skip-read-approx-n			value "N". 
 
 
01  ws-date. 
* (y2k)
*   05  ws-yy					pic 99. 
    05  ws-yy					pic 9(4). 
    05  ws-mm					pic 99. 
    05  ws-dd					pic 99. 
 
 
 
copy "sysdatetime.ws". 
 
* 
*  SUBSCRIPTS 
* 
77  ss						pic 99	comp. 
77  ss-loc-ptr					pic 9 comp. 
77  subs					pic 99	comp. 
 
 
* 
*  FEEDBACK VALUES FOR ALL INDEXED FILES 
* 
**77  FEEDBACK-PAT-MSTR				PIC X(4). 
77  feedback-subs-mstr				pic x(4). 
77  feedback-docrev-mstr			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
**77  FEEDBACK-SUBSCR-MSTR			PIC X(4). 
* 
*  EOF FLAGS 
* 
77  eof-filename-here				pic x	value "N". 
* 
*  STATUS FILE INDICATORS 
* 
77  status-common				pic x(11). 
**77  STATUS-COBOL-PAT-MSTR			PIC XX. 
**77  STATUS-COBOL-SUBSCR-MSTR			PIC XX. 
77  status-dept-mstr				pic x(11)  value zero. 
**77  STATUS-SUBSCR-MSTR			PIC X(11)  VALUE ZERO. 
**77  STATUS-PAT-MSTR				PIC X(11)  VALUE ZERO. 
77  status-prt-file				pic xx     value zero. 
77  status-docrev-mstr				pic x(11)  value zero. 
77  status-cobol-docrev-mstr			pic xx. 
77  status-cobol-doc-mstr   			pic xx. 
77  status-cobol-loc-mstr   			pic xx. 
77  status-cobol-iconst-mstr   			pic xx. 
77  status-cobol-dept-mstr   			pic xx. 
77  status-loc-mstr				pic x(11)  value zero. 
77  status-doc-mstr				pic x(11)  value zero. 
 
77  status-iconst-mstr				pic x(11)  value zero. 
 
 
* 
*  KEYS (AND/OR RECORD LAYOUTS) FOR ALL INDEXED FILES 
* 
 
 
*01  PAT-OCCUR					PIC 9(3). 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-read-pat-mstr			pic 9(7). 
    05  ctr-read-subscr-mstr			pic 9(7). 
    05  ctr-read-docrev-mstr			pic 9(7). 
 
 
01  ws-hold-scr-values. 
 
    05  ws-request-clinic-nbr. 
	10  ws-request-clinic-nbr-1		pic x. 
	10  filler				pic x. 
    05  ws-dept					pic xx. 
    05  ws-dept-r redefines ws-dept. 
	10  ws-dept-1				pic x. 
	    88  flag-dept-unknown		value '?'. 
	10  ws-dept-2				pic x. 
    05  ws-dept-num redefines ws-dept-r		pic 99. 
    05  ws-dept-name				pic x(30). 
    05  ws-doc-nbr				pic xxx. 
    05  ws-doc-nbr-r redefines ws-doc-nbr. 
	10  ws-doc-nbr-1			pic x. 
	    88  flag-doc-nbr-all		value '*'. 
	10  filler				pic xx. 
    05  ws-scr-loc. 
	10  ws-loc-1				pic x999. 
	10  ws-loc-1-r redefines ws-loc-1. 
	    15  ws-loc-1-1			pic x. 
		88  flag-loc-all		value '*'. 
	    15  filler				pic x(3). 
	10  ws-loc-2				pic x999. 
	10  ws-loc-3				pic x999. 
	10  ws-loc-4				pic x999. 
	10  ws-loc-5				pic x999. 
    05  ws-loc-r redefines ws-scr-loc. 
	10  ws-loc		occurs 5 times	pic x999. 
    05  ws-hold-scr-oma-cd. 
	10  ws-oma-cd-1				pic x(5). 
	10  ws-oma-cd-1-r redefines ws-oma-cd-1. 
	    15  ws-oma-cd-1-1			pic x. 
		88 flag-oma-cd-all		value '*'. 
	    15  filler				pic x(4). 
	10  ws-oma-cd-2				pic x(5). 
    05  ws-oma-cd-r redefines ws-hold-scr-oma-cd. 
	10  ws-oma-cd	occurs 2 times	pic x(5). 
 
 
01 tmp-doc-nbr-alpha.
   05 tmp-doc-nbr-alpha.
	10 tmp-doc-nbr-pos-1				pic x(1).
	10 tmp-doc-nbr-pos-2-3				pic x(2).
   05 tmp-doc-nbr-apha-r1 redefines tmp-doc-nbr-alpha.
	10 tmp-doc-nbr-pos-1-2				pic x(2).
	10 filler           				pic x(1).
   05 tmp-doc-nbr-apha-r1 redefines tmp-doc-nbr-alpha.
	10 tmp-doc-nbr-pos-1				pic x(1).
	10 tmp-doc-nbr-pos-1				pic x(1).
	10 tmp-doc-nbr-pos-1				pic x(1).
   05 tmp-doc-nbr-apha-r2 redefines tmp-doc-nbr-alpha.
	10 tmp-doc-nbr-pos	occurs 3 times 		pic x(1).

01  hold-doc-key. 
 
    05  hold-clinic-nbr				pic xx. 
    05  hold-dept				pic 99. 
*!    05  hold-doc-nbr				pic 999. 
    05  hold-doc-nbr				pic xxx. 
    05  hold-loc				pic x999. 
    05  hold-oma-cd				pic x(5). 
 
 
01  ws-fees-oma. 
 
  03  ws-fees. 
    05  ws-fees-mtd. 
	10  ws-in-svc-mtd			pic 9(5). 
	10  ws-in-amt-mtd			pic s9(6)v99. 
	10  ws-out-svc-mtd			pic 9(5). 
	10  ws-out-amt-mtd			pic s9(6)v99. 
	10  ws-misc-svc-mtd			pic 9(5). 
	10  ws-misc-amt-mtd			pic s9(6)v99. 
	10  ws-total-svc-mtd			pic 9(7). 
	10  ws-total-amt-mtd			pic s9(7)v99. 
    05  ws-fees-ytd. 
	10  ws-in-svc-ytd			pic 9(5). 
	10  ws-in-amt-ytd			pic s9(6)v99. 
	10  ws-out-svc-ytd			pic 9(5). 
	10  ws-out-amt-ytd			pic s9(6)v99. 
	10  ws-misc-svc-ytd			pic 9(5). 
	10  ws-misc-amt-ytd			pic s9(6)v99. 
	10  ws-total-svc-ytd			pic 9(7). 
	10  ws-total-amt-ytd			pic s9(7)v99. 
  03 ws-fees-r redefines ws-fees. 
    05  ws-fees-mtd-ytd occurs 2 times. 
	10  ws-in-svc				pic 9(5). 
	10  ws-in-amt				pic s9(6)v99. 
	10  ws-out-svc				pic 9(5). 
	10  ws-out-amt				pic s9(6)v99. 
	10  ws-misc-svc				pic 9(5). 
	10  ws-misc-amt				pic s9(6)v99. 
	10  ws-total-svc			pic 9(7). 
	10  ws-total-amt			pic s9(7)v99. 
 
01  error-message-table. 
 
    05  error-messages. 
* MSG #1 
	10  filler				pic x(50)   value 
		"INVALID REPLY". 
	10  filler				pic x(50)   value 
		"NO DOCTORS FOUND IN THIS DEPT.". 
	10  filler				pic x(50)   value 
		"CLINIC NOT FOUND ON CONSTANTS MASTER". 
	10  filler				pic x(50)   value 
		"SPARE                 ". 
	10  filler				pic x(50)   value 
		"LOCATION NOT FOUND ON LOCATIONS MASTER". 
	10  filler				pic x(50)   value 
		"NO DOCTOR REVENUE RECORDS FOUND". 
	10  filler				pic x(50)   value 
		"SPARE                  ". 
	10  filler				pic x(50)   value 
		"FIRST OMA CODE MUST BE <= SECOND ENTERED". 
	10  filler				pic x(50)   value 
		"INVALID DOCTOR NBR". 
* MSG #10 
	10  filler				pic x(50)   value 
		"INVALID DEPT NBR". 
	10  filler				pic x(50)   value 
		"IF DEPT UNKNOWN, MUST PROVIDE A VALID DOCTOR NBR". 
	10  filler				pic x(50)   value 
		"DOCTOR NOT FOUND ON DOCTOR MSTR". 
	10  filler				pic x(50)   value 
		"NO DEPARTMENT ON FILE IN DEPT MSTR". 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(50) 
			occurs 13 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
screen section. 
 
 
01  scr-title-doc-rev-inq. 
 
    05  blank screen. 
    05  line 01 col 01 value is "D050". 
    05  line 01 col 28 value is "* DOCTOR REVENUE INQUIRY *". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 99 using sys-yy. 
    05  line 01 col 75 pic 9(4) using sys-yy. 
    05  line 01 col 77 value "/". 
    05  line 01 col 78 pic 99 using sys-mm. 
    05  line 01 col 80 value "/". 
    05  line 01 col 81 pic 99 using sys-dd. 
    05  line 03 col 04 value "SEARCH CRITERIA:". 
* 
 
01  scr-blank-line-13-15. 
*   05  LINE 13 COL 01 BLANK LINE. 
    05  line 15 col 01 blank line. 
*   05  LINE 15 COL 01 BLANK LINE. 
    05  line 17 col 01 blank line. 
 
 
01  scr-blank-total-lines. 
 
*   05  LINE 13 COL 01 BLANK LINE. 
*   05  LINE 14 COL 01 BLANK LINE. 
*   05  LINE 15 COL 01 BLANK LINE. 
*   05  LINE 17 COL 01 BLANK LINE. 
    05  line 15 col 01 blank line. 
    05  line 16 col 01 blank line. 
    05  line 17 col 01 blank line. 
    05  line 19 col 01 blank line. 
    05  line 23 col 01 blank line. 
 
 
01  scr-dis-doc-key-lit. 
    05  line 05 col 07 value "CLINIC      :". 
    05  line 07 col 07 value "DEPT        :".  
*   05  LINE 07 COL 28 VALUE "DOCTOR :". 
*   05  LINE 07 COL 46 VALUE "(?  DEPT - IF UNKNOWN       )". 
*   05  LINE 08 COL 46 VALUE "(*  DOC  - FOR ENTIRE DEPT. )". 
*   05  LINE 09 COL 07 VALUE "LOCATION(S) :". 
*   05  LINE 09 COL 46 VALUE "(*  FOR ALL LOCATIONS       )". 
*   05  LINE 11 COL 07 VALUE "OMA CODE(S) :        THRU". 
*   05  LINE 11 COL 46 VALUE "(*  FOR ALL CODES           )". 
    05  line 07 col 54 value "(?  DEPT - IF UNKNOWN     )". 
    05  line 09 col 07 value "DOCTOR      :". 
    05  line 09 col 54 value "(*  DOC  - FOR ENTIRE DEPT)". 
    05  line 11 col 07 value "LOCATION(S) :". 
    05  line 11 col 54 value "(*  FOR ALL LOCATIONS     )". 
    05  line 13 col 07 value "OMA CODE(S) :        THRU". 
    05  line 13 col 54 value "(*  FOR ALL CODES         )". 
 
01  scr-acpt-user-verif. 
 
*   05  LINE 13 COL 11 VALUE 'ACCEPT/REJECT/MODIFY SELECTION CRITERIA (A/R/M)'. 
*   05  LINE 13 COL 59 PIC X USING FLAG-USER-RESP AUTO REQUIRED. 
    05  line 15 col 11 value 'ACCEPT/REJECT/MODIFY SELECTION CRITERIA (A/R/M)'. 
    05  line 15 col 59 pic x using flag-user-resp auto required. 
 
01  scr-dis-search-in-prog. 
 
*   05  LINE 15 COL 11 VALUE "SEARCH IN PROGRESS" BLINK. 
    05  line 17 col 11 value "SEARCH IN PROGRESS" blink. 
 
01  scr-dis-total-lit. 
 
*   05  LINE 13 COL 06 VALUE "---IN PATIENT----  --OUT PATIENT---". 
*   05  LINE 13 COL 43 VALUE "-MISCELLANEOUS--   ------TOTALS------". 
*   05  LINE 14 COL 08 VALUE "SVC         AMT    SVC        AMT   SVC". 
*   05  LINE 14 COL 56 VALUE "AMT      SVC         AMT". 
*   05  LINE 15 COL 01 VALUE "MTD". 
*   05  LINE 17 COL 01 VALUE "YTD". 
    05  line 15 col 06 value "---IN PATIENT----  --OUT PATIENT---". 
    05  line 15 col 43 value "-MISCELLANEOUS--   ------TOTALS------". 
    05  line 16 col 08 value "SVC         AMT    SVC        AMT   SVC". 
    05  line 16 col 56 value "AMT      SVC         AMT". 
    05  line 17 col 01 value "MTD". 
    05  line 19 col 01 value "YTD". 
 
01  scr-acpt-hard-copy. 
 
    05  line 23 col 41 value "HARD COPY (Y/N)". 
    05  line 23 col 57 pic x using flag auto required. 
 
01  scr-acpt-doc-key. 
 
    05  scr-clinic-nbr line 05 col 21 pic xx using ws-request-clinic-nbr 
		auto required. 
    05  scr-dept line 07 col 21 pic xx using ws-dept auto required. 
    05  scr-dept-name  line 07 col 24 pic x(30) using ws-dept-name. 
*   05  SCR-DOC-NBR LINE 07 COL 37 PIC X(3) USING WS-DOC-NBR AUTO REQUIRED. 
*   05  SCR-LOC-1 LINE 09 COL 21 PIC X999 USING WS-LOC-1 AUTO REQUIRED. 
*   05  SCR-LOC-2 LINE 09 COL 26 PIC X999 USING WS-LOC-2 AUTO. 
*   05  SCR-LOC-3 LINE 09 COL 31 PIC X999 USING WS-LOC-3 AUTO. 
*   05  SCR-LOC-4 LINE 09 COL 36 PIC X999 USING WS-LOC-4 AUTO. 
*   05  SCR-LOC-5 LINE 09 COL 41 PIC X999 USING WS-LOC-5 AUTO. 
*   05  SCR-OMA-CD-1 LINE 11 COL 21 PIC X9999 USING WS-OMA-CD-1 AUTO REQUIRED. 
*   05  SCR-OMA-CD-2 LINE 11 COL 33 PIC X9999 USING WS-OMA-CD-2 AUTO. 
    05  scr-doc-nbr line 09 col 21 pic x(3) using ws-doc-nbr auto required. 
    05  scr-loc-1 line 11 col 21 pic x999 using ws-loc-1 auto required. 
    05  scr-loc-2 line 11 col 26 pic x999 using ws-loc-2 auto. 
    05  scr-loc-3 line 11 col 31 pic x999 using ws-loc-3 auto. 
    05  scr-loc-4 line 11 col 36 pic x999 using ws-loc-4 auto. 
    05  scr-loc-5 line 11 col 41 pic x999 using ws-loc-5 auto. 
    05  scr-oma-cd-1 line 13 col 21 pic x9999 using ws-oma-cd-1 auto required. 
    05  scr-oma-cd-2 line 13 col 33 pic x9999 using ws-oma-cd-2 auto. 
 
01  scr-dis-totals. 
 
*   05  LINE 15 COL 05 PIC ZZ,ZZ9 USING WS-IN-SVC-MTD. 
*   05  LINE 15 COL 13 PIC ZZZ,ZZ9.99- USING WS-IN-AMT-MTD. 
*   05  LINE 15 COL 24 PIC ZZ,ZZ9 USING WS-OUT-SVC-MTD. 
*   05  LINE 15 COL 31 PIC ZZZ,ZZ9.99- USING WS-OUT-AMT-MTD. 
*   05  LINE 15 COL 42 PIC ZZ,ZZ9 USING WS-MISC-SVC-MTD. 
*   05  LINE 15 COL 49 PIC ZZZ,ZZ9.99- USING WS-MISC-AMT-MTD. 
*   05  LINE 15 COL 60 PIC ZZZZ,ZZ9 USING WS-TOTAL-SVC-MTD. 
*   05  LINE 15 COL 69 PIC ZZZZ,ZZ9.99- USING WS-TOTAL-AMT-MTD. 
* 
*   05  LINE 17 COL 05 PIC ZZ,ZZ9 USING WS-IN-SVC-YTD. 
*   05  LINE 17 COL 13 PIC ZZZ,ZZ9.99- USING WS-IN-AMT-YTD. 
*   05  LINE 17 COL 24 PIC ZZ,ZZ9 USING WS-OUT-SVC-YTD. 
*   05  LINE 17 COL 31 PIC ZZZ,ZZ9.99- USING WS-OUT-AMT-YTD. 
*   05  LINE 17 COL 42 PIC ZZ,ZZ9 USING WS-MISC-SVC-YTD. 
*   05  LINE 17 COL 49 PIC ZZZ,ZZ9.99- USING WS-MISC-AMT-YTD. 
*   05  LINE 17 COL 60 PIC ZZZZ,ZZ9 USING WS-TOTAL-SVC-YTD. 
*   05  LINE 17 COL 69 PIC ZZZZ,ZZ9.99- USING WS-TOTAL-AMT-YTD. 
 
 
    05  line 17 col 05 pic zz,zz9 using ws-in-svc-mtd. 
    05  line 17 col 13 pic zzz,zz9.99- using ws-in-amt-mtd. 
    05  line 17 col 24 pic zz,zz9 using ws-out-svc-mtd. 
    05  line 17 col 31 pic zzz,zz9.99- using ws-out-amt-mtd. 
    05  line 17 col 42 pic zz,zz9 using ws-misc-svc-mtd. 
    05  line 17 col 49 pic zzz,zz9.99- using ws-misc-amt-mtd. 
    05  line 17 col 60 pic zzzz,zz9 using ws-total-svc-mtd. 
    05  line 17 col 69 pic zzzz,zz9.99- using ws-total-amt-mtd. 
 
    05  line 19 col 05 pic zz,zz9 using ws-in-svc-ytd. 
    05  line 19 col 13 pic zzz,zz9.99- using ws-in-amt-ytd. 
    05  line 19 col 24 pic zz,zz9 using ws-out-svc-ytd. 
    05  line 19 col 31 pic zzz,zz9.99- using ws-out-amt-ytd. 
    05  line 19 col 42 pic zz,zz9 using ws-misc-svc-ytd. 
    05  line 19 col 49 pic zzz,zz9.99- using ws-misc-amt-ytd. 
    05  line 19 col 60 pic zzzz,zz9 using ws-total-svc-ytd. 
    05  line 19 col 69 pic zzzz,zz9.99- using ws-total-amt-ytd. 
 
 
01  err-msg-line. 
 
    05  line 24 col 01 value " ERROR - " bell blink. 
    05  line 24 col 11 pic x(60)   from err-msg-comment. 
 
 
01  blank-line-24. 
 
    05  line 24 col 01 blank line. 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
01 file-status-display. 
    05  line 24 col 01 pic x(42) from ws-file-err-msg. 
    05  line 24 col 44 pic x(7)  from ws-disp-pat-key-type. 
    05  line 24 col 56	"FILE STATUS = ". 
    05  line 24 col 70	pic x(11) using status-common	bell blink. 
* 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  verification-screen. 
    05  line 24 col 58	value "ACCEPT (Y/N/M) ". 
    05  line 24 col 73	pic x	to flag. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  6 col 20  value "# OF DOCREV MASTER READS  =". 
    05  line  6 col 55  pic 9(7) from ctr-read-docrev-mstr. 
*   05  LINE  7 COL 20  VALUE "# OF PATIENT MSTR  READS  =". 
*   05  LINE  7 COL 55  PIC 9(7) FROM CTR-READ-PAT-MSTR. 
*   05  LINE  8 COL 20  VALUE "# OF CLAIMS MASTER RE-WRITES =". 
*   05  LINE  8 COL 55  PIC 9(7) FROM CTR-REWRIT-CLAIMS-MSTR. 
    05  line 21 col 20	value "PROGRAM D050 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
 
procedure division. 
declaratives. 
 
**ERR-SUBSCR-MSTR-FILE SECTION. 
**  USE AFTER STANDARD ERROR PROCEDURE ON SUBSCR-MSTR. 
**ERR-SUBSCR-MSTR. 
**  MOVE STATUS-SUBSCR-MSTR		TO STATUS-COMMON. 
**  DISPLAY FILE-STATUS-DISPLAY. 
**  STOP "ERROR IN ACCESSING SUBSCRIBER MASTER". 
 
err-docrev-mstr-file section. 
    use after standard error procedure on docrev-mstr. 
err-docrev-mstr. 
    move status-docrev-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCREV MASTER". 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    move status-iconst-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
 
err-loc-mstr-file section. 
    use after standard error procedure on loc-mstr. 
err-loc-mstr. 
    move status-loc-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING LOCATIONS MASTER". 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    move status-doc-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
**ERR-PAT-MSTR-FILE SECTION. 
**  USE AFTER STANDARD ERROR PROCEDURE ON PAT-MSTR. 
**ERR-PAT-MSTR. 
**  IF PAT-KEY-TYPE = "A" 
**  THEN 
**	MOVE "ACRONYM"			TO WS-DISP-PAT-KEY-TYPE 
**  ELSE 
**	IF PAT-KEY-TYPE = "O" 
**	THEN 
**	   MOVE "OHIP"			TO WS-DISP-PAT-KEY-TYPE 
**	ELSE 
**	   IF PAT-KEY-TYPE = "C" 
**	   THEN 
**		MOVE "CHART"		TO WS-DISP-PAT-KEY-TYPE 
**	   ELSE 
**		MOVE "UNKNOWN"		TO WS-DISP-PAT-KEY-TYPE. 
*	    ENDIF 
*	ENDIF 
*   ENDIF 
 
**  MOVE "ERROR IN ACCESSING PATIENT MASTER -- KEY =" TO WS-FILE-ERR-MSG. 
**  MOVE STATUS-PAT-MSTR			      TO STATUS-COMMON. 
**  DISPLAY FILE-STATUS-DISPLAY. 
**  STOP " ". 
**  MOVE SPACES					      TO WS-FILE-ERR-MSG 
**						         WS-DISP-PAT-KEY-TYPE. 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
    stop "ERROR IN ACCESSING DEPT MASTER ". 
    move status-dept-mstr			      to status-common. 
    display file-status-display. 
    stop run. 
 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
	until end-job = "Y". 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
 
 
aa0-initialization. 
 
   
    accept sys-date			from date. 
    move sys-mm				to run-mm.                 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
**  OPEN INPUT	PAT-MSTR 
**		SUBSCR-MSTR 
    open input  iconst-mstr 
		loc-mstr 
		dept-mstr 
		doc-mstr 
		docrev-mstr. 
 
    display scr-title-doc-rev-inq. 
    display scr-dis-doc-key-lit. 
 
    move zero				to counters. 
    perform xa0-clear-values		thru xa0-99-exit. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    if hard-copy 
    then 
	call 'CLI' using macro-cli. 
*   ENDIF 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
**  CLOSE SUBSCR-MSTR 
**	  PAT-MSTR 
    close iconst-mstr 
	  loc-mstr 
	  dept-mstr 
	  doc-mstr 
	  docrev-mstr. 
 
    call program "menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
****************************************************************** 
*		ACCEPT SEARCH CRITERIA				 * 
****************************************************************** 
 
    perform ba0-acpt-clinic		thru ba0-99-exit. 
    if end-job = 'Y' 
    then 
	go to ab0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    perform da0-acpt-dept-doc		thru da0-99-exit. 
    move 'Y'				to flag. 
    perform fa0-acpt-loc		thru fa0-99-exit   
	varying subs from 1 by 1 
	until   subs > 5 
	     or not-ok. 
 
    if flag-loc-all 
    then 
	move spaces			to hold-loc 
    else 
	move ws-loc(1)			to hold-loc. 
*   ENDIF 
 
    perform ha0-acpt-oma-code		thru ha0-99-exit. 
 
****************************************************************** 
*		ACCEPT USER VERIFICATION			 * 
****************************************************************** 
 
    move 'A'				to flag-user-resp. 
    perform ja0-acpt-user-verif		thru ja0-99-exit. 
 
    if flag-verif-rej 
    then 
	move 'Y'			to end-job 
	go to ab0-99-exit 
    else 
	if flag-verif-mod 
	then 
	    go to ab0-99-exit 
	else 
	    next sentence. 
*	ENDIF 
*   ENDIF 
 
*	USER HAS ACCEPTED ENTRY FIELDS 
 
****************************************************************** 
*		PERFORM DOCTOR SEARCH				 * 
****************************************************************** 
 
    display scr-dis-search-in-prog. 
 
    move 'N'				to flag-request-complete 
					   flag-valid-docrev-rec. 
 
    move 1				to ss-loc-ptr. 
 
    move hold-doc-key			to docrev-key. 
    move 'Y'				to flag. 
    perform xe0-read-docrev-approx	thru xe0-99-exit. 
 
*	VERIFY THAT DOCREV RECORD READ SATISFIES THE USER SELECT 
*	CRITERIA, AND CONTINUE READING RECORDS UNTIL YOU HAVE 
*	READ PAST THE LAST VALID RECORD FOR THE USERS REQUEST. 
 
    perform la0-select-proc-rd-nxt-docrev 
					thru la0-99-exit 
	until flag-request-complete-y. 
 
    display scr-blank-line-13-15. 
    display scr-dis-total-lit. 
    display scr-dis-totals. 
    move 'N'				to flag. 
    perform pa0-print-copy		thru pa0-99-exit. 
    perform xa0-clear-values		thru xa0-99-exit. 
    display scr-blank-total-lines. 
 
    if flag-oma-cd-all 
    then 
	display scr-oma-cd-1 
	display scr-oma-cd-2. 
*   (ELSE) 
*   ENDIF 
 
ab0-99-exit. 
    exit. 
ba0-acpt-clinic. 
 
    accept scr-clinic-nbr. 
 
    if ws-request-clinic-nbr-1 = '*' 
    then 
	move 'Y'			to end-job 
	go to ba0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    move ws-request-clinic-nbr		to iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 3			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to ba0-acpt-clinic. 
 
    move ws-request-clinic-nbr		to hold-clinic-nbr. 
 
ba0-99-exit. 
    exit. 
da0-acpt-dept-doc. 
 
    accept scr-dept. 
 
 
    if   ws-dept-r = '1 ' 
      or ws-dept-r = '2 ' 
      or ws-dept-r = '3 ' 
      or ws-dept-r = '4 ' 
      or ws-dept-r = '5 ' 
      or ws-dept-r = '6 ' 
      or ws-dept-r = '7 ' 
      or ws-dept-r = '8 ' 
      or ws-dept-r = '9 ' 
    then 
	move ws-dept-1			to ws-dept-2 
	move zero			to ws-dept-1 
	display scr-dept. 
*   (ELSE) 
*   ENDIF 
 
 
    if			not flag-dept-unknown 
      and   ws-dept-num not numeric 
    then 
	move 10				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move spaces			to ws-dept 
	move spaces			to ws-dept-name 
	display scr-dept 
	display scr-dept-name	 
	go to da0-acpt-dept-doc. 
*   ENDIF 
 
    if  not flag-dept-unknown 
    then 
      	move ws-dept  			to dept-nbr 
      	perform da2-read-dept-mstr	thru da2-99-exit 
      	move dept-name			to ws-dept-name 
        display scr-dept-name. 
*   ENDIF 
 
da0-10-acpt-doc-nbr. 
 
    accept scr-doc-nbr. 
 
* 2003/12/08 - MC/BE
*!  if			not flag-doc-nbr-all 
*!      and ws-doc-nbr	not numeric 
*!  then 

    if	     flag-doc-nbr-all 
        or  (    (    ws-doc-nbr >= "000"	
		  and ws-doc-nbr <= "999"
		 )
	      or (    ws-doc-nbr >= "A00"
		  and ws-doc-nbr <= "ZZZ"
		 )
	    )
* 2003/12/08 - end
    then 
	next sentence
    else
	move spaces			to ws-doc-nbr 
	move 9				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	display scr-doc-nbr 
	if flag-dept-unknown 
	then 
	    go to da0-acpt-dept-doc 
	else 
	    go to da0-10-acpt-doc-nbr .
*	ENDIF 
*   ENDIF 
 
    if    flag-dept-unknown 
      and flag-doc-nbr-all 
    then 
	move 11				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to da0-acpt-dept-doc. 
*   (ELSE) 
*   ENDIF 
 
    if flag-dept-unknown 
    then 
	move 'Y'			to flag 
	perform da1-access-doc-for-dept	thru da1-99-exit 
	if ok 
	then 
	    display scr-dept 
	    move ws-dept-num			to dept-nbr 
     	    perform da2-read-dept-mstr		thru da2-99-exit 
      	    move dept-name			to ws-dept-name 
            display scr-dept-name 
	else 
	    go to da0-10-acpt-doc-nbr 
*	ENDIF 
    else 
        next sentence. 
*   ENDIF 
 
    move ws-dept-num			to hold-dept. 
 
    if flag-doc-nbr-all 
    then 
*!	move zeros			to hold-doc-nbr 
	move spaces			to hold-doc-nbr 
    else 
	move ws-doc-nbr			to hold-doc-nbr. 
*   ENDIF 
 
da0-99-exit. 
    exit. 
 
 
 
da1-access-doc-for-dept. 
 
    move ws-doc-nbr			to doc-nbr. 
 
    read doc-mstr 
	invalid key 
	    move 'N'			to flag 
	    move 12			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to da1-99-exit. 
 
   move doc-dept			to ws-dept-num. 
 
da1-99-exit. 
    exit. 
 
 
da2-read-dept-mstr. 
 
    read dept-mstr 
	invalid key 
	    move 13			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    move 'UNKNOWN DEPT'		to dept-name. 
 
da2-99-exit. 
    exit. 
 
fa0-acpt-loc. 
 
    if subs = 1 
    then 
	accept scr-loc-1 
	if flag-loc-all  
	then 
	    move 'N'			to flag 
	    move spaces			to ws-loc-2 
					   ws-loc-3 
					   ws-loc-4 
					   ws-loc-5 
	    display scr-loc-2 
	    display scr-loc-3 
	    display scr-loc-4 
	    display scr-loc-5 
	    go to fa0-99-exit 
	else 
	    next sentence 
*	ENDIF 
    else 
	if subs = 2 
	then 
	    accept scr-loc-2 
	else 
	    if subs = 3 
	    then 
		accept scr-loc-3 
	    else 
		if subs = 4   
		then 
		    accept scr-loc-4 
		else 
		    accept scr-loc-5. 
*		ENDIF 
*	    ENDIF 
*	ENDIF 
*   ENDIF 
 
    if ws-loc(subs) = spaces 
    then 
	move 'N'			to flag 
	if subs = 2 
	then 
	    move spaces			to ws-loc-3 
					   ws-loc-4 
					   ws-loc-5 
	    display scr-loc-3 
	    display scr-loc-4 
	    display scr-loc-5 
	    go to fa0-99-exit 
	else 
	    if subs = 3 
	    then 
		move spaces		to ws-loc-4 
					   ws-loc-5 
		display scr-loc-4 
		display scr-loc-5 
		go to fa0-99-exit 
	    else 
		if subs = 4 
		then 
		    move spaces		to ws-loc-5 
		    display scr-loc-5 
		    go to fa0-99-exit 
		else 
		    go to fa0-99-exit 
*		ENDIF 
*	    ENDIF 
*	ENDIF 
     else 
	next sentence. 
*   ENDIF 
 
    move 'Y'				to flag. 
    perform fa1-read-loc-mstr		thru fa1-99-exit. 
 
    if not-ok 
    then 
	go to fa0-acpt-loc. 
*   (ELSE) 
*   ENDIF 
 
fa0-99-exit. 
    exit. 
 
 
 
fa1-read-loc-mstr. 
 
    move ws-loc(subs)			to loc-nbr. 
 
    read loc-mstr 
	invalid key 
	    move 5			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    move 'N'			to flag. 
 
fa1-99-exit. 
    exit. 
ha0-acpt-oma-code. 
 
    accept scr-oma-cd-1. 
    if flag-oma-cd-all 
    then 
	move spaces			to ws-oma-cd-2 
	display scr-oma-cd-2 
	move zeros			to hold-oma-cd 
	move zeros			to ws-oma-cd-1 
	move "ZZZZZ"			to ws-oma-cd-2  
	go to ha0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    move ws-oma-cd-1			to hold-oma-cd. 
 
ha0-10-acpt-cd-2. 
 
    accept scr-oma-cd-2. 
    if ws-oma-cd-2 = spaces 
    then 
	move ws-oma-cd-1		to ws-oma-cd-2 
	go to ha0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    if ws-oma-cd-2 < ws-oma-cd-1 
    then 
	move 8				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ha0-acpt-oma-code. 
*   (ELSE) 
*   ENDIF 
 
ha0-99-exit. 
    exit. 
ja0-acpt-user-verif. 
 
    display scr-acpt-user-verif. 
    accept scr-acpt-user-verif. 
 
    if   flag-user-resp = 'A' 
      or flag-user-resp = 'R' 
      or flag-user-resp = 'M' 
    then 
	next sentence 
    else 
	move 1				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move ' '			to flag-user-resp 
	go to ja0-acpt-user-verif. 
*   ENDIF 
 
ja0-99-exit. 
    exit. 
la0-select-proc-rd-nxt-docrev. 
 
    move 'N'				to flag-valid-docrev-rec. 
 
*	DETERMINE IF THE RECORD LAST READ SATISFIES THE USER SELECTED 
*	CRITERIA. IF NOT THEN READ UNTIL ONE IS FOUND OR THERE ARE 
*	NONE AVAILABLE. 
 
    perform lb0-select-docrev		thru lb0-99-exit 
		until   flag-valid-docrev-rec-y 
		     or flag-request-complete-y. 
 
    if flag-request-complete-n 
    then 
*	( ADD THE REQUIRED VALUES TO THE FINAL COUNTERS AND READ 
*	  THE NEXT DOCREV RECORD ) 
	perform ld0-process-dept-rd-nxt	thru ld0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
la0-99-exit. 
    exit. 
lb0-select-docrev. 
 
*	( IF THE DEPT HAS CHANGED THEN NO MORE DATA IS AVALIABLE 
*	  AND THE REQUEST IS COMPLETE ) 
    if docrev-dept not = hold-dept 
    then 
	move 'Y'			to flag-request-complete 
	go to lb0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
*	( IF ALL DOCTORS AND ALL LOCATIONS REQUESTED ) 
    if    flag-doc-nbr-all 
      and flag-loc-all 
    then 
	perform lb3-check-oma-cd	thru lb3-99-exit 
	if ok 
	then 
	    move 'Y'			to flag-valid-docrev-rec 
	    go to lb0-99-exit 
	else 
	    if flag-skip-read-approx-y 
	    then 
		go to lb0-99-exit 
	    else 
		go to lb0-90-read-docrev-approx 
*	    ENDIF 
*	ENDIF 
    else 
	next sentence. 
*   ENDIF 
 
*	( IF ALL DOCTORS AND NOT ALL LOCATIONS REQUESTED ) 
   if        flag-doc-nbr-all 
     and not flag-loc-all 
   then 
	if docrev-location = ws-loc(ss-loc-ptr) 
	then 
	    perform lb3-check-oma-cd	thru lb3-99-exit 
	    if ok 
	    then 
		move 'Y'		to flag-valid-docrev-rec 
		go to lb0-99-exit 
	    else 
		if flag-skip-read-approx-y 
		then 
		    go to lb0-99-exit 
		else 
		    go to lb0-90-read-docrev-approx 
*		ENDIF 
*	    ENDIF 
	else 
	    if docrev-location < ws-loc(ss-loc-ptr) 
	    then 
		move docrev-doc-nbr	to hold-doc-nbr 
		move ws-loc(ss-loc-ptr)	to hold-loc 
		go to lb0-90-read-docrev-approx 
	    else 
		perform lb1-obtain-nxt-loc thru lb1-99-exit 
		if ok 
		then 
*		    add 1, docrev-doc-nbr 
*					giving hold-doc-nbr 
		    perform xx0-increment-doc-nbr
					thru xx0-99-exit
		    move docrev-doc-nbr to hold-doc-nbr

		    move 1		to ss-loc-ptr 
		    move ws-loc(ss-loc-ptr) to hold-loc 
		    go to lb0-90-read-docrev-approx 
		else 
		    go to lb0-90-read-docrev-approx 
*		ENDIF 
*	    ENDIF 
*	ENDIF 
    else 
	next sentence. 
*   ENDIF 
 
*	( IF NOT ALL DOCTORS AND NOT ALL LOCATIONS REQUESTED ) 
    if    not flag-doc-nbr-all 
      and not flag-loc-all 
    then 
	if docrev-doc-nbr not = hold-doc-nbr 
	then 
	    move 'Y'			to flag-request-complete 
	    go to lb0-99-exit 
	else 
	    if docrev-location not = hold-loc 
	    then 
		perform lb1-obtain-nxt-loc 
					thru lb1-99-exit 
		if ok 
		then             
		    move 'Y'		to flag-request-complete 
		    go to lb0-99-exit 
		else 
		    go to lb0-90-read-docrev-approx 
*		ENDIF 
	    else 
		perform lb3-check-oma-cd 
					thru lb3-99-exit 
		if ok 
		then 
		    move 'Y'		to flag-valid-docrev-rec 
		    go to lb0-99-exit 
		else 
		    if flag-skip-read-approx-y 
		    then 
			go to lb0-99-exit 
		    else 
			perform lb1-obtain-nxt-loc 
					thru lb1-99-exit 
			if ok 
			then             
			    move 'Y'	to flag-request-complete 
			    go to lb0-99-exit 
			else 
			    go to lb0-90-read-docrev-approx 
*			ENDIF 
*		    ENDIF 
*		ENDIF 
*	    ENDIF 
*	ENDIF 
    else 
	next sentence. 
*   ENDIF 
 
*	( IF NOT ALL DOCTORS AND ALL LOCATIONS REQUESTED ) 
    if    not flag-doc-nbr-all 
      and     flag-loc-all 
    then 
	if docrev-doc-nbr not = hold-doc-nbr 
	then 
	    move 'Y'			to flag-request-complete 
	    go to lb0-99-exit 
	else 
	    perform lb3-check-oma-cd	thru lb3-99-exit 
	    if ok 
	    then 
		move 'Y'		to flag-valid-docrev-rec 
		go to lb0-99-exit 
	    else 
		if flag-skip-read-approx-y 
		then 
		    go to lb0-99-exit 
		else 
		    next sentence 
*		ENDIF 
*	    ENDIF 
*	ENDIF 
    else 
	next sentence. 
*   ENDIF 
 
lb0-90-read-docrev-approx. 
 
    move hold-doc-key			to docrev-key. 
    move 'Y'				to flag. 
    perform xe0-read-docrev-approx	thru xe0-99-exit. 
 
lb0-99-exit. 
   exit. 
 
 
 
 
lb1-obtain-nxt-loc. 
 
    if    ss-loc-ptr		     < ws-max-nbr-loc 
      and ws-loc(ss-loc-ptr + 1) not = spaces 
    then 
	add 1				to ss-loc-ptr 
	move ws-loc(ss-loc-ptr)		to hold-loc 
	move 'N'			to flag 
    else 
	move 'Y'			to flag. 
*   ENDIF 
 
    if flag-oma-cd-all 
    then 
	move zero			to hold-oma-cd 
    else 
	move ws-oma-cd-1		to hold-oma-cd. 
*   ENDIF 
 
lb1-99-exit. 
    exit. 
 
 
 
lb3-check-oma-cd. 
 
    if    docrev-oma-cd not < ws-oma-cd-1 
      and docrev-oma-cd not > ws-oma-cd-2 
    then 
	move 'Y'			to flag 
	go to lb3-99-exit 
    else 
	move 'N'			to flag-skip-read-approx 
					   flag 
	if docrev-oma-cd < ws-oma-cd-1 
	then 
	    perform xc0-read-next-docrev 
					thru xc0-99-exit 
	    move 'Y'			to flag-skip-read-approx 
	    go to lb3-99-exit 
	else 
	    next sentence. 
*	ENDIF 
*   ENDIF 
 
    move 'ZZZZZ'			to hold-oma-cd. 
 
    if flag-loc-all 
    then 
	move docrev-location 		to hold-loc. 
*   (ELSE) 
*   ENDIF 
 
    if flag-doc-nbr-all 
    then 
	move docrev-doc-nbr		to hold-doc-nbr. 
*   (ELSE) 
*   ENDIF 
 
lb3-99-exit. 
    exit. 
ld0-process-dept-rd-nxt. 
 
    perform ld1-update-cntrs		thru ld1-99-exit. 
 
    perform xc0-read-next-docrev	thru xc0-99-exit. 
 
ld0-99-exit. 
    exit. 
 
 
ld1-update-cntrs. 
 
    if docrev-location = 'MISC' 
    then 
	add docrev-mtd-out-svc		to ws-misc-svc-mtd 
					   ws-total-svc-mtd 
 
	add docrev-mtd-out-rec		to ws-misc-amt-mtd 
					   ws-total-amt-mtd  
 
	add docrev-ytd-out-svc		to ws-misc-svc-ytd 
					   ws-total-svc-ytd      
 
	add docrev-ytd-out-rec		to ws-misc-amt-ytd 
					   ws-total-amt-ytd  
    else 
	add docrev-mtd-in-svc		to ws-in-svc-mtd 
					   ws-total-svc-mtd 
 
	add docrev-mtd-in-rec		to ws-in-amt-mtd 
					   ws-total-amt-mtd   
 
	add docrev-mtd-out-svc		to ws-out-svc-mtd 
					   ws-total-svc-mtd  
 
	add docrev-mtd-out-rec		to ws-out-amt-mtd 
					   ws-total-amt-mtd   
 
	add docrev-ytd-in-svc		to ws-in-svc-ytd    
					   ws-total-svc-ytd 
 
	add docrev-ytd-in-rec		to ws-in-amt-ytd 
					   ws-total-amt-ytd    
 
	add docrev-ytd-out-svc		to ws-out-svc-ytd 
					   ws-total-svc-ytd   
 
	add docrev-ytd-out-rec		to ws-out-amt-ytd 
					   ws-total-amt-ytd. 
*   ENDIF 
 
ld1-99-exit. 
    exit. 
pa0-print-copy. 
 
    display scr-acpt-hard-copy. 
    accept  scr-acpt-hard-copy. 
 
    if ok 
    then 
	perform pa1-print-hard-copy	thru pa1-99-exit. 
*   (ELSE) 
*   ENDIF 
 
pa0-99-exit. 
    exit. 
 
 
pa1-print-hard-copy. 
 
*    display scr-title-doc-rev-inq	upon screen-dump-file. 
*    display scr-dis-doc-key-lit		upon screen-dump-file. 
*    display scr-acpt-doc-key		upon screen-dump-file. 
*    display scr-dis-total-lit		upon screen-dump-file. 
*    display scr-dis-totals		upon screen-dump-file. 
    move 'Y'				to hard-copy-flag. 
 
 
pa1-99-exit. 
    exit. 
xa0-clear-values. 
 
    move spaces				to ws-hold-scr-values 
					   hold-doc-key 
					   ws-request-clinic-nbr 
                                           ws-dept-name. 
 
    if    ws-oma-cd-1 = zeros 
      and ws-oma-cd-2 = "ZZZZZ" 
    then 
	move "*"			to ws-oma-cd-1 
	move spaces			to ws-oma-cd-2. 
*   (ELSE) 
*   ENDIF 
 
    move zero				to ws-fees-oma            
					   ws-dept 
					   hold-dept 
					   hold-doc-nbr. 
 
xa0-99-exit. 
    exit. 
xc0-read-next-docrev. 
 
    read docrev-mstr next 
	at end 
	    move 'Y'			to flag-request-complete 
	    go to xc0-99-exit. 
 
    add 1				to ctr-read-docrev-mstr. 
 
xc0-99-exit. 
    exit. 
xe0-read-docrev-approx. 

*mf
    start docrev-mstr key is greater than or equal to docrev-key
	invalid key 
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 

*mf   read docrev-mstr key is docrev-key approximate 
*	invalid key 
    read docrev-mstr next
	at end
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1				to ctr-read-docrev-mstr. 
 
xe0-99-exit. 
    exit. 

xx0-increment-doc-nbr.
*0 - 9 A - Z 
    move "N"				to	flag-request-complete.


    display "BEFORE: " docrev-doc-nbr.
    perform xx1-process-1-doc-position	thru xx1-99-exit	
	varying   ss from 1 by 1
	until     ss > 3
           or      flag-request-complete-y.

    display "AFTER : " docrev-doc-nbr.

xx0-99-exit.
   exit.

xx1-process-1-doc-position.
*if pos(1) = 0 then 1 , if 1 then 2 if 9 then A, if A then B if Z then 0 and!

    if tmp-doc-nbr-pos(ss) = "0"
    then
	move "1"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "1"
    then
	move "2"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "2"
    then
	move "3"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "3"
    then
	move "4"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "4"
    then
	move "5"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "5"
    then
	move "6"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "6"
    then
	move "7"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "7"
    then
	move "8"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "8"
    then
	move "9"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "9"
    then
	move "A"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "A"
    then
	move "B"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "B"
    then
	move "C"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "C"
    then
	move "D"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "D"
    then
	move "E"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "E"
    then
	move "F"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "F"
    then
	move "G"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "G"
    then
	move "H"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "H"
    then
	move "I"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "I"
    then
	move "J"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "J"
    then
	move "K"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "K"
    then
	move "L"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "L"
    then
	move "M"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "M"
    then
	move "N"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "N"
    then
	move "O"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "O"
    then
	move "P"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "P"
    then
	move "Q"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "B"
    then
	move "R"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "R"
    then
	move "S"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "S"
    then
	move "T"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "T"
    then
	move "U"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "U"
    then
	move "V"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "V"
    then
	move "W"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "W"
    then
	move "X"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "X"
    then
	move "Y"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "Y"
    then
	move "Z"			to	tmp-doc-nbr-pos(ss)
	go to xx0-90-return
    else
    if tmp-doc-nbr-pos(ss) = "Z"
    then
	move "0"			to	tmp-doc-nbr-pos(ss)
	go to xx0-99-exit.
*   endif

xx0-90-return.
    move "Y"				to	flag-request-complete.

xx1-99-exit.
    exit.




za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
 
    accept scr-confirm. 
 
*   DISPLAY CONFIRM. 
*   STOP " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 