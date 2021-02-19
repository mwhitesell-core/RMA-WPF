identification division. 
program-id. m090.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/31/01. 
date-compiled. 
security. 
* 
*    PROGRAM ID : M090  
* 
*    FILES      : F090 CONSTANTS MASTER 
*		: AUDIT FILE 
* 
* 
*    PROGRAM PURPOSE : CONSTANTS MASTER MAINTENANCE.   
* 
* 
*	REVISION HISTORY: 
* 
*	MAR/82 (D.M.)	- INCORPORATE REC 1 AND REC 2 FROM RAM CONSTANTS 
*		 	  MASTER INTO ISAM CONSTANTS MASTER 
*			- CHANGES TO RECORD #1: 
*				- ADD MAX.NBR.OF CLINICS 
*			- CHANGES TO RECORD #2: 
*				- ADD EFFECTIVE DATE 
*				- ADD "PREVIOUS" VALUES 
*				- REDUCE GROUPS FROM 25 TO 19 
*				- ADD MAX.NBR. OF RATES 
* 
*	MAY/82 (D.M.)	- RECORD #3 CREATED 
* 
*	JUNE/82 (D.M.)	- RECORD #4 CREATED 
* 
*	FEB/85 (M.S.)   - RECORD #5 CREATED 
* 
*               MAY/87 (S.B.) - COVERSION FROM AOS to AOS/VS. 
*                               CHANGE FIELD SIZE FOR 
*                               STATUS CLAUSE TO 2 AND 
*                               FEEDBACK CLAUSE TO 4. 
* 
*       JUNE/87 (C.E.)  - CHANGE F090_CONSTANTS_MSTR.FD TO INCLUDE 
*			  FIELDS FOR OVERPAYMENT, UNDERPAYMENT 
*			  AMOUNTS AND NEXT AVAILABLE BATCH NUMBER. 
*			- CHANGE SCR-CONST-ISAM-MASK LAYOUT FOR CLINIC 
*			  TO INCLUDE OVERPAYMENT, UNDERPAYMENT 
*			  AND NEXT AVAILABLE BATCH NUMBER FIELDS. 
*			- CHANGE FA0-30 TO INCLUDE ACCEPT STATEMENTS 
*			  FOR THE OVERPAYMENT, UNDERPAYMENT LIMIT 
*			  AMOUNTS AND NEXT AVAILABLE BATCH NUMBER. 
* 
*    REVISED DEC/87 (J.L.) - PDR 356 
*			   - AFTER ERROR MESSAGE IS DISPLAYED, HIT 
*			     SPACE BAR TO RETURN TO KEYING FIELD 
* 
*    REVISED SEP/88 (M.C.) - CHANGE F090_CONSTANTS_MSTR.FD TO INCLUDE 
*			     TWO MORE FIELDS FOR OVERPAYMENT LIMIT 4 AND 
*			     UNDERPAYMENT LIMIT 3 AMOUNTS. 
*			   - CHANGE SCR-CONST-ISAM-MASK LAYOUT FOR 
*			     CLINIC TO INCLUDE THESE TWO EXTRA FIELDS. 
*			   - CHANGE FA0-30 TO INCLUDE ACCEPT STATEMENTS 
*			     FOR THESE TWO EXTRA FIELDS. 
* 
*   REVISED MARCH/89 : - SMS 115 S.F. 
*		       - MAKE SURE FILE STATUS IS PIC XX ,FEEDBACK IS 
*			 PIC X(4) AND INFOS STATUS IS PIC X(11). 
* 
*			 
*   REVISED JAN/94 (M.C.) - SMS 144 
*			  - INCLUDE THE NEW FIELDS 'REDUCTION FACTOR' 
*			    'OVERPAY FACTOR' ON THE SCREEN 
* 
*   REVISED SEP/97 (M.C.) - PDR 663 
*			  - FOR RECORD TYPE 1, CHANGE THE CLINIC NBR 
*			    FROM ZZZ9 TO X(4) IN SCR-MASK1. 
*			  - MOVE SPACES INSTEAD OF ZERO TO CONST-CLINIC-NBR(I) 
*			    IN BA1-ZERO-AREAS SUBROUTINE 
*
*  1999/jan/20 B.E.	  - y2k
*			  - replace 'stop run' with chain to menu pgm
*  1999/may/10 B.E.	  - rec 6 used within Payroll system and not maintained 
*			    by this pgm - pgm changed to not allow access
*			    to this record
*  2000/08/31 B.E.	- minor realignment of display of 'previous' effective
*			  date field.
*  2004/02/26 M.C.  	- change the label from Card Colour to AFP Flag
*  2005/01/04 M.C.  	- allow the max clinic 63 on the screen from 40
*  2006/11/08 M.C.	- include iconst-clinic-pay-batch-nbr on screen
*  2017/03/13 MC1	- change 'Accept (Y/N/M)' to include 'P' for passwd to change 'p'revious amounts for record 2

environment division. 
input-output section. 
file-control. 
* 
    copy "f090_constants_mstr.slr". 
* 
    select audit-file 
          assign to printer print-file-name 
	  file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_1.ws". 
* 
    copy "f090_const_mstr_rec_2.ws". 
* 
    copy "f090_const_mstr_rec_3.ws". 
copy "f090_const_mstr_rec_4.ws". 
copy "f090_const_mstr_rec_5.ws". 
fd  audit-file 
    record contains 132 characters. 
 
01  audit-record				pic x(132).					 
working-storage section. 
 
77  temp					pic 99. 
77  ws-misc-msg-curr				pic x(11)	value 
		"SEE DOC REC". 
77  i						pic 99 value zero. 
77  pline					pic 99 value zero. 
77  pcol1					pic 99 value zero. 
77  pcol2					pic 99 value zero. 
77  err-ind					pic 99 value zero. 
77  ws-class-nbr				pic 99. 
 
77  print-file-name				pic x(5) 
			value "rm090". 
77  option					pic x. 
77  ws-entered-password				pic x(5)	value spaces. 
* 
77  confirm-space				pic x   value space. 
* 
* 
copy "rmapw.ws".        
* 
*  EOF FLAGS 
* 
77  eof-const-mstr				pic x	value "N". 
* 
*  STATUS FILE INDICATORS 
* 
*mf 77  status-file				pic x(11). 
77  status-file					pic x(2). 
77  status-const-mstr				pic x(11)	value zero. 
77  status-audit-rpt				pic xx  	value zero. 
*mf 77  status-iconst-mstr			pic x(11)	value zero. 
77  feedback-iconst-mstr			pic xxxx	value zero. 
77  const-mstr-rec-nbr				pic 99. 
77  ws-const-mstr-rec-ident			pic 99. 
77  ws-save-max-clinics				pic 99. 
77  ws-save-max-rates				pic 99. 
 
01  status-cobol-iconst-mstr. 
	02 status-cobol-iconst-mstr-1		pic 9 		value zero.
	02 status-cobol-iconst-mstr-2		pic 9 		value zero.

*	WS-CONST-MSTR-IDENT BROKEN UP SINCE OPERATOR CAN ENTER 
*	** TO SHUT DOWN, A 1-DIGIT RECORD NUMBER OR A 2-DIGIT 
*	RECORD NUMBER 
 
01  ws-const-mstr-ident. 
    05  ws-const-mstr-ident-1			pic x	value space. 
    05  ws-const-mstr-ident-2			pic x	value space. 
 
01  save-misc-code-values. 
    05  save-misc-codes-curr. 
	10  save-curr-1     			pic 999v99. 
	10  save-curr-2      			pic 999v99. 
	10  save-curr-3     			pic 999v99. 
	10  save-curr-4     			pic 999v99. 
	10  save-curr-5     			pic 999v99. 
	10  save-curr-6     			pic 999v99. 
	10  save-curr-7     			pic 999v99. 
	10  save-curr-8      			pic 999v99. 
	10  save-curr-9     			pic 999v99. 
	10  save-curr-10     			pic 999v99. 
    05  save-misc-codes-curr-r redefines save-misc-codes-curr. 
 	10  save-curr occurs 10 times 		pic 999v99. 
    05  save-misc-codes-prev. 
	10  save-prev-1     			pic 999v99. 
	10  save-prev-2     			pic 999v99. 
	10  save-prev-3     			pic 999v99. 
	10  save-prev-4     			pic 999v99. 
	10  save-prev-5     			pic 999v99. 
	10  save-prev-6     			pic 999v99. 
	10  save-prev-7     			pic 999v99. 
	10  save-prev-8     			pic 999v99. 
	10  save-prev-9     			pic 999v99. 
	10  save-prev-10     			pic 999v99. 
    05  save-misc-codes-prev-r redefines save-misc-codes-prev. 
  	10  save-prev occurs 10 times 		pic 999v99. 
 
01  class-flag					pic x. 
    88  class-ok				value "Y". 
    88  class-not-ok				value "N". 
 
01  password-flag				pic x. 
    88  password-ok				value "Y". 
    88  password-not-ok				value "N". 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-lock					pic x. 
    88 rec-locked				value "Y". 
    88 rec-not-locked				value "N". 
 
*   COUNTERS FOR RECORDS READ/WRITTEN FOR ALL INPUT/OUTPUT FILES 
 
01  counters. 
    05  ctr-const-mstr-reads			pic 9(7). 
    05  ctr-const-mstr-changes 			pic 9(7). 
    05  ctr-audit-rpt-writes			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(55)   value 
			"INVALID REPLY". 
	10  filler				pic x(55)   value 
			"INVALID YEAR". 
	10  filler				pic x(55)   value 
			"INVALID MONTH". 
	10  filler				pic x(55)   value 
			"INVALID DAY". 
	10  filler				pic x(55)   value 
			"NO SUCH RECORD ON THE CONSTANTS MASTER". 
	10  filler				pic x(55)	value 
			"INVALID PASSWORD". 
	10  filler				pic x(55)	value 
			"PREVIOUS DATE NOT LESS THAN CURRENT". 
	10  filler				pic x(55)	value 
			"CLASS LETTER ALREADY IN USE". 
	10  filler				pic x(55)	value 
			"CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(55) 
			occurs  9 times. 
 
01  err-msg-comment				pic x(55). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
  
    copy "mth_desc_max_days.ws". 
 
    copy "sysdatetime.ws". 
screen section. 
 
01 scr-title. 
    05 blank screen. 
    05 line 01 col 01 value is "M090        CONSTANTS MASTER MAINTENANCE -". 
    05 scr-acpt-option line 01 col 42 pic x to option auto required. 
    05 line 01 col 44 value "(CHANGE/INQUIRY)". 
    05 scr-rec-nbr	line 01 col 66 pic xx using ws-const-mstr-ident auto required. 
* (y2k - auto fix)
*   05 line 01 col 73 pic 99 using sys-yy. 
    05 line 01 col 71 pic 9(4) using sys-yy. 
    05 line 01 col 75 value is "/". 
    05 line 01 col 76 pic 99 using sys-mm. 
    05 line 01 col 78 value is "/". 
    05 line 01 col 79 pic 99 using sys-dd. 
 
01  scr-types. 
    05 scr-change-option  line 01 col 42 value "CHANGE - RECORD NUMBER:". 
    05 scr-inquire-option line 01 col 42 value "INQUIRY - RECORD NUMBER:". 
*   05 line 01 col 79 pic 99 using sys-dd.

01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70 pic x(11) using status-file	bell blink. 
    05  line 24 col 70 pic x(2) using status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(55)	from err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01 value " ". 
 
01  blank-line-03. 
    05  line 03 col 1	blank line. 
 
01  blank-line-05. 
    05  line 05 col 1	blank line. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-rest-of-page. 
    05  line 02 col 01 blank line. 
    05  line 03 col 01 blank line. 
    05  line 04 col 01 blank line. 
    05  line 05 col 01 blank line. 
    05  line 06 col 01 blank line. 
    05  line 07 col 01 blank line. 
    05  line 08 col 01 blank line. 
    05  line 09 col 01 blank line. 
    05  line 10 col 01 blank line. 
    05  line 11 col 01 blank line. 
    05  line 12 col 01 blank line. 
    05  line 13 col 01 blank line. 
    05  line 14 col 01 blank line. 
    05  line 15 col 01 blank line. 
    05  line 16 col 01 blank line. 
    05  line 17 col 01 blank line. 
    05  line 18 col 01 blank line. 
    05  line 19 col 01 blank line. 
    05  line 20 col 01 blank line. 
    05  line 21 col 01 blank line. 
    05  line 22 col 01 blank line. 
    05  line 23 col 01 blank line. 
    05  line 24 col 01 blank line. 
 
 
01  blank-screen. 
    05  blank screen. 
 
01  verification-screen-add-chg. 
* MC1
*   05  line 24 col 30	value "ACCEPT (Y/N/M) ". 
*   05  line 24 col 45	pic x	to flag auto. 
    05  line 24 col 30	value "ACCEPT (Y/N/M/P) ". 
    05  line 24 col 47	pic x	to flag auto. 
* MC1 - end
 
01  verification-screen-del. 
    05  line 24 col 30 value "DELETE (Y/N)". 
    05  line 24 col 45 pic x   to flag auto. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-password-prompt. 
    05			line 24 col 66 value "PASSWORD". 
    05  scr-password	line 24 col 75 pic x(5) using ws-entered-password auto secure. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  5 col 20  value "NUMBER OF CONST-MSTR READS".       
    05  line  5 col 60  pic z(6)9 from ctr-const-mstr-reads. 
    05  line  7 col 20  value "NUMBER OF CONST-MSTR CHANGES".     
    05  line  7 col 60  pic z(6)9 from ctr-const-mstr-changes. 
    05  line  8 col 20  value "NUMBER OF AUDIT RPT WRITES = ". 
    05  line  8 col 60  pic z(6)9 from ctr-audit-rpt-writes. 
    05  line 21 col 18	value "PROGRAM M090 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40	pic 99	from sys-yy. 
    05  line 21 col 42	pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 48	pic 99	from sys-dd. 
    05  line 21 col 52	pic z9	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
    05  line 23 col 20	value "AUDIT REPORT IS IN FILE - ". 
    05  line 23 col 51	pic x(7)	from print-file-name. 
* 97/09/15 - CHANGE ZZZ9 TO X(4). 
*	   - REMOVE BLANK WHEN ZERO FOR CONST-CLINIC-NBR-NN 
 
01  scr-mask1. 
 
    05  			line 02 col 34 value "NBR. OF CLINICS". 
    05  scr-max-nbr-clinics	line 02 col 50 pic z9 
					using const-max-nbr-clinics. 
* 2005/01/04 - MC - relocate the columns and change the column heading 
*		    and add 23 more clinics on the screen
*   05  			line 03 col 04 value "CLINIC IDENT". 
*   05				line 03 col 18 value "CLINIC". 
*   05				line 03 col 34 value "CLINIC IDENT". 
*   05				line 03 col 48 value "CLINIC". 
    05  			line 03 col 04 value "CLINIC".       
    05				line 03 col 12 value "GROUP ". 
    05				line 03 col 24 value "CLINIC".  
    05				line 03 col 32 value "GROUP ". 
    05  			line 03 col 44 value "CLINIC".       
    05				line 03 col 52 value "GROUP ". 
    05				line 03 col 64 value "CLINIC".  
    05				line 03 col 72 value "GROUP ". 
* 2005/01/04 - end
 
    05  scr-clinic-1-2-nbr-1	line 04 col 06 pic z9 highlight using const-clinic-1-2-nbr-1 blank when zero. 
    05  scr-clinic-nbr-1	line 04 col 13 pic x(4) highlight using const-clinic-nbr-1. 
 
    05  scr-clinic-1-2-nbr-2	line 05 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-2 blank when zero. 
    05  scr-clinic-nbr-2	line 05 col 13 pic x(4) highlight 
					using const-clinic-nbr-2. 
 
    05  scr-clinic-1-2-nbr-3	line 06 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-3 blank when zero. 
    05  scr-clinic-nbr-3	line 06 col 13 pic x(4) highlight 
					using const-clinic-nbr-3. 
 
    05  scr-clinic-1-2-nbr-4	line 07 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-4 blank when zero. 
    05  scr-clinic-nbr-4	line 07 col 13 pic x(4) highlight 
					using const-clinic-nbr-4. 
 
    05  scr-clinic-1-2-nbr-5	line 08 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-5 blank when zero. 
    05  scr-clinic-nbr-5	line 08 col 13 pic x(4) highlight 
					using const-clinic-nbr-5. 
 
    05  scr-clinic-1-2-nbr-6	line 09 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-6 blank when zero. 
    05  scr-clinic-nbr-6	line 09 col 13 pic x(4) highlight 
					using const-clinic-nbr-6. 
 
    05  scr-clinic-1-2-nbr-7	line 10 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-7 blank when zero. 
    05  scr-clinic-nbr-7	line 10 col 13 pic x(4) highlight 
					using const-clinic-nbr-7. 
 
    05  scr-clinic-1-2-nbr-8	line 11 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-8 blank when zero. 
    05  scr-clinic-nbr-8	line 11 col 13 pic x(4) highlight 
					using const-clinic-nbr-8. 
 
    05  scr-clinic-1-2-nbr-9	line 12 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-9 blank when zero. 
    05  scr-clinic-nbr-9	line 12 col 13 pic x(4) highlight 
					using const-clinic-nbr-9. 
 
    05  scr-clinic-1-2-nbr-10	line 13 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-10 blank when zero. 
    05  scr-clinic-nbr-10	line 13 col 13 pic x(4) highlight 
					using const-clinic-nbr-10. 
 
    05  scr-clinic-1-2-nbr-11	line 14 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-11 blank when zero. 
    05  scr-clinic-nbr-11	line 14 col 13 pic x(4) highlight 
					using const-clinic-nbr-11. 
 
    05  scr-clinic-1-2-nbr-12	line 15 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-12 blank when zero. 
    05  scr-clinic-nbr-12	line 15 col 13 pic x(4) highlight 
					using const-clinic-nbr-12. 
 
    05  scr-clinic-1-2-nbr-13	line 16 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-13 blank when zero. 
    05  scr-clinic-nbr-13	line 16 col 13 pic x(4) highlight 
					using const-clinic-nbr-13. 
 
    05  scr-clinic-1-2-nbr-14	line 17 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-14 blank when zero. 
    05  scr-clinic-nbr-14	line 17 col 13 pic x(4) highlight 
					using const-clinic-nbr-14. 
 
    05  scr-clinic-1-2-nbr-15	line 18 col 06 pic z9  highlight 
					using const-clinic-1-2-nbr-15 blank when zero. 
    05  scr-clinic-nbr-15	line 18 col 13 pic x(4) highlight 
					using const-clinic-nbr-15. 
 
    05  scr-clinic-1-2-nbr-16	line 19 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-16 blank when zero. 
    05  scr-clinic-nbr-16	line 19 col 13 pic x(4) highlight 
					using const-clinic-nbr-16. 
 
    05  scr-clinic-1-2-nbr-17	line 20 col 06 pic z9 highlight  
					using const-clinic-1-2-nbr-17 blank when zero. 
    05  scr-clinic-nbr-17	line 20 col 13 pic x(4) highlight 
					using const-clinic-nbr-17. 
 
    05  scr-clinic-1-2-nbr-18	line 21 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-18 blank when zero. 
    05  scr-clinic-nbr-18	line 21 col 13 pic x(4) highlight 
					using const-clinic-nbr-18. 
 
    05  scr-clinic-1-2-nbr-19	line 22 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-19 blank when zero. 
    05  scr-clinic-nbr-19	line 22 col 13 pic x(4) highlight 
					using const-clinic-nbr-19. 
 
    05  scr-clinic-1-2-nbr-20	line 23 col 06 pic z9 highlight 
					using const-clinic-1-2-nbr-20 blank when zero. 
    05  scr-clinic-nbr-20	line 23 col 13 pic x(4) highlight 
					using const-clinic-nbr-20. 
 
    05  scr-clinic-1-2-nbr-21	line 04 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-21 blank when zero. 
    05  scr-clinic-nbr-21	line 04 col 33 pic x(4) highlight 
					using const-clinic-nbr-21. 
 
    05  scr-clinic-1-2-nbr-22	line 05 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-22 blank when zero. 
    05  scr-clinic-nbr-22	line 05 col 33 pic x(4) highlight 
					using const-clinic-nbr-22. 
 
    05  scr-clinic-1-2-nbr-23	line 06 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-23 blank when zero. 
    05  scr-clinic-nbr-23	line 06 col 33 pic x(4) highlight 
					using const-clinic-nbr-23. 
 
    05  scr-clinic-1-2-nbr-24	line 07 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-24 blank when zero. 
    05  scr-clinic-nbr-24	line 07 col 33 pic x(4) highlight 
					using const-clinic-nbr-24. 
 
    05  scr-clinic-1-2-nbr-25	line 08 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-25 blank when zero. 
    05  scr-clinic-nbr-25	line 08 col 33 pic x(4) highlight 
					using const-clinic-nbr-25. 
 
    05  scr-clinic-1-2-nbr-26	line 09 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-26 blank when zero. 
    05  scr-clinic-nbr-26	line 09 col 33 pic x(4) highlight 
					using const-clinic-nbr-26. 
 
    05  scr-clinic-1-2-nbr-27	line 10 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-27 blank when zero. 
    05  scr-clinic-nbr-27	line 10 col 33 pic x(4) highlight 
					using const-clinic-nbr-27. 
 
    05  scr-clinic-1-2-nbr-28	line 11 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-28 blank when zero. 
    05  scr-clinic-nbr-28	line 11 col 33 pic x(4) highlight 
					using const-clinic-nbr-28. 
 
    05  scr-clinic-1-2-nbr-29	line 12 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-29 blank when zero. 
    05  scr-clinic-nbr-29	line 12 col 33 pic x(4) highlight 
					using const-clinic-nbr-29. 
 
    05  scr-clinic-1-2-nbr-30	line 13 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-30 blank when zero. 
    05  scr-clinic-nbr-30	line 13 col 33 pic x(4) highlight 
					using const-clinic-nbr-30. 
 
    05  scr-clinic-1-2-nbr-31	line 14 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-31 blank when zero. 
    05  scr-clinic-nbr-31	line 14 col 33 pic x(4) highlight 
					using const-clinic-nbr-31. 
 
    05  scr-clinic-1-2-nbr-32	line 15 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-32 blank when zero. 
    05  scr-clinic-nbr-32	line 15 col 33 pic x(4) highlight 
					using const-clinic-nbr-32. 
 
    05  scr-clinic-1-2-nbr-33	line 16 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-33 blank when zero. 
    05  scr-clinic-nbr-33	line 16 col 33 pic x(4) highlight 
					using const-clinic-nbr-33. 
 
    05  scr-clinic-1-2-nbr-34	line 17 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-34 blank when zero. 
    05  scr-clinic-nbr-34	line 17 col 33 pic x(4) highlight 
					using const-clinic-nbr-34. 
 
    05  scr-clinic-1-2-nbr-35	line 18 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-35 blank when zero. 
    05  scr-clinic-nbr-35	line 18 col 33 pic x(4) highlight 
					using const-clinic-nbr-35. 
 
    05  scr-clinic-1-2-nbr-36	line 19 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-36 blank when zero. 
    05  scr-clinic-nbr-36	line 19 col 33 pic x(4) highlight 
					using const-clinic-nbr-36. 
 
    05  scr-clinic-1-2-nbr-37	line 20 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-37 blank when zero. 
    05  scr-clinic-nbr-37	line 20 col 33 pic x(4) highlight 
					using const-clinic-nbr-37. 
 
    05  scr-clinic-1-2-nbr-38	line 21 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-38 blank when zero. 
    05  scr-clinic-nbr-38	line 21 col 33 pic x(4) highlight 
					using const-clinic-nbr-38. 
 
    05  scr-clinic-1-2-nbr-39	line 22 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-39 blank when zero. 
    05  scr-clinic-nbr-39	line 22 col 33 pic x(4) highlight 
					using const-clinic-nbr-39. 
 
    05  scr-clinic-1-2-nbr-40	line 23 col 26 pic z9 highlight 
					using const-clinic-1-2-nbr-40 blank when zero. 
    05  scr-clinic-nbr-40	line 23 col 33 pic x(4) highlight 
					using const-clinic-nbr-40. 

* 2005/01/04 - MC - include 23 more clinics (41 to 63)
 
    05  scr-clinic-1-2-nbr-41	line 04 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-41 blank when zero. 
    05  scr-clinic-nbr-41	line 04 col 53 pic x(4) highlight 
					using const-clinic-nbr-41. 
 
    05  scr-clinic-1-2-nbr-42	line 05 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-42 blank when zero. 
    05  scr-clinic-nbr-42	line 05 col 53 pic x(4) highlight 
					using const-clinic-nbr-42. 
 
    05  scr-clinic-1-2-nbr-43	line 06 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-43 blank when zero. 
    05  scr-clinic-nbr-43	line 06 col 53 pic x(4) highlight 
					using const-clinic-nbr-43. 
 
    05  scr-clinic-1-2-nbr-44	line 07 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-44 blank when zero. 
    05  scr-clinic-nbr-44	line 07 col 53 pic x(4) highlight 
					using const-clinic-nbr-44. 
 
    05  scr-clinic-1-2-nbr-45	line 08 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-45 blank when zero. 
    05  scr-clinic-nbr-45	line 08 col 53 pic x(4) highlight 
					using const-clinic-nbr-45. 
 
    05  scr-clinic-1-2-nbr-46	line 09 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-46 blank when zero. 
    05  scr-clinic-nbr-46	line 09 col 53 pic x(4) highlight 
					using const-clinic-nbr-46. 
 
    05  scr-clinic-1-2-nbr-47	line 10 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-47 blank when zero. 
    05  scr-clinic-nbr-47	line 10 col 53 pic x(4) highlight 
					using const-clinic-nbr-47. 
 
    05  scr-clinic-1-2-nbr-48	line 11 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-48 blank when zero. 
    05  scr-clinic-nbr-48	line 11 col 53 pic x(4) highlight 
					using const-clinic-nbr-48. 
 
    05  scr-clinic-1-2-nbr-49	line 12 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-49 blank when zero. 
    05  scr-clinic-nbr-49	line 12 col 53 pic x(4) highlight 
					using const-clinic-nbr-49. 
 
    05  scr-clinic-1-2-nbr-50	line 13 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-50 blank when zero. 
    05  scr-clinic-nbr-50	line 13 col 53 pic x(4) highlight 
					using const-clinic-nbr-50. 
 
    05  scr-clinic-1-2-nbr-51	line 14 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-51 blank when zero. 
    05  scr-clinic-nbr-51	line 14 col 53 pic x(4) highlight 
					using const-clinic-nbr-51. 
 
    05  scr-clinic-1-2-nbr-52	line 15 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-52 blank when zero. 
    05  scr-clinic-nbr-52	line 15 col 53 pic x(4) highlight 
					using const-clinic-nbr-52. 
 
    05  scr-clinic-1-2-nbr-53	line 16 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-53 blank when zero. 
    05  scr-clinic-nbr-53	line 16 col 53 pic x(4) highlight 
					using const-clinic-nbr-53. 
 
    05  scr-clinic-1-2-nbr-54	line 17 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-54 blank when zero. 
    05  scr-clinic-nbr-54	line 17 col 53 pic x(4) highlight 
					using const-clinic-nbr-54. 
 
    05  scr-clinic-1-2-nbr-55	line 18 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-55 blank when zero. 
    05  scr-clinic-nbr-55	line 18 col 53 pic x(4) highlight 
					using const-clinic-nbr-55. 
 
    05  scr-clinic-1-2-nbr-56	line 19 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-56 blank when zero. 
    05  scr-clinic-nbr-56	line 19 col 53 pic x(4) highlight 
					using const-clinic-nbr-56. 
 
    05  scr-clinic-1-2-nbr-57	line 20 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-57 blank when zero. 
    05  scr-clinic-nbr-57	line 20 col 53 pic x(4) highlight 
					using const-clinic-nbr-57. 
 
    05  scr-clinic-1-2-nbr-58	line 21 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-58 blank when zero. 
    05  scr-clinic-nbr-58	line 21 col 53 pic x(4) highlight 
					using const-clinic-nbr-58. 
 
    05  scr-clinic-1-2-nbr-59	line 22 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-59 blank when zero. 
    05  scr-clinic-nbr-59	line 22 col 53 pic x(4) highlight 
					using const-clinic-nbr-59. 
 
    05  scr-clinic-1-2-nbr-60	line 23 col 46 pic z9 highlight 
					using const-clinic-1-2-nbr-60 blank when zero. 
    05  scr-clinic-nbr-60	line 23 col 53 pic x(4) highlight 
					using const-clinic-nbr-60. 

    05  scr-clinic-1-2-nbr-61	line 04 col 66 pic z9 highlight 
					using const-clinic-1-2-nbr-61 blank when zero. 
    05  scr-clinic-nbr-61	line 04 col 73 pic x(4) highlight 
					using const-clinic-nbr-61. 
 
    05  scr-clinic-1-2-nbr-62	line 05 col 66 pic z9 highlight 
					using const-clinic-1-2-nbr-62 blank when zero. 
    05  scr-clinic-nbr-62	line 05 col 73 pic x(4) highlight 
					using const-clinic-nbr-62. 
 
    05  scr-clinic-1-2-nbr-63	line 06 col 66 pic z9 highlight 
					using const-clinic-1-2-nbr-63 blank when zero. 
    05  scr-clinic-nbr-63	line 06 col 73 pic x(4) highlight 
					using const-clinic-nbr-63. 
 
* 2005/01/04 - end


01  scr-mask2a. 
    05			line 03 col 10 value "IN EFFECT". 
    05  		line 03 col 25 value "WCB". 
    05			line 03 col 35 value "BILATERAL". 
    05			line 03 col 47 value "IND.CONSIDERATION". 
    05			line 03 col 67 value "SECT.REDUCTION". 
    05  		line 04 col 01 value "CURR.". 
* (y2k - auto fix)
*   05  scr-yy-curr	line 04 col 11 pic 99		using const-yy-curr auto required. 
    05  scr-yy-curr	line 04 col 09 pic 9(4)		using const-yy-curr auto required. 
    05			line 04 col 13 value "/". 
    05  scr-mm-curr	line 04 col 14 pic 99		using const-mm-curr auto required. 
*brad
    05			line 04 col 16 value "/". 
    05  scr-dd-curr	line 04 col 17 pic 99		using const-dd-curr auto required. 
    05  scr-wcb-curr	line 04 col 21 pic zz9.9(5) 	using const-wcb-curr auto required. 
    05  scr-bi-curr	line 04 col 36 pic z9.99	using const-bilateral-curr auto required. 
    05  scr-ic-curr	line 04 col 53 pic z9.99	using const-ic-curr auto required. 
    05  scr-sr-curr	line 04 col 71 pic z9.99	using const-sr-curr auto required. 
    05			line 05 col 01 value "PREV.". 
* (y2k - auto fix)
*   05             	line 05 col 11 pic 99		from  const-yy-prev auto required. 
    05             	line 05 col 09 pic 9(4)		from  const-yy-prev auto required. 
    05  		line 05 col 13 value "/". 
    05             	line 05 col 14 pic 99		from  const-mm-prev. 
    05			line 05 col 16 value "/". 
    05             	line 05 col 17 pic 99		from  const-dd-prev. 
    05              	line 05 col 21 pic zz9.9(5)	from  const-wcb-prev. 
    05             	line 05 col 36 pic z9.99	from  const-bilateral-prev. 
    05              	line 05 col 53 pic z9.99	from  const-ic-prev. 
    05             	line 05 col 71 pic z9.99	from  const-sr-prev. 
    05			line 07 col 07 value "-------------OHIP--------------". 
    05			line 07 col 51 value "------------OMA---------------".   
    05			line 08 col 08 value "ASST.". 
    05			line 08 col 17 value "REG.ANAE". 
    05			line 08 col 29 value "CERT.ANAE". 
    05			line 08 col 52 value "ASST.". 
    05			line 08 col 60 value "REG.ANAE". 
    05			line 08 col 72 value "CERT.ANAE". 
    05  		line 09 col 01 value "CURR.". 
    05  scr-asst-h-curr	line 09 col 07 pic z9.99	using const-asst-h-curr auto required. 
    05  scr-reg-h-curr	line 09 col 18 pic z9.99	using const-reg-h-curr auto required. 
    05  scr-cert-h-curr	line 09 col 31 pic z9.99	using const-cert-h-curr auto required. 
    05  scr-asst-a-curr	line 09 col 51 pic z9.99	using const-asst-a-curr auto required. 
    05  scr-reg-a-curr	line 09 col 61 pic z9.99	using const-reg-a-curr auto required. 
    05  scr-cert-a-curr	line 09 col 74 pic z9.99	using const-cert-a-curr auto required. 
    05 			line 10 col 01 value "PREV". 
    05                 	line 10 col 07 pic z9.99	from  const-asst-h-prev. 
    05                 	line 10 col 18 pic z9.99	from  const-reg-h-prev. 
    05                 	line 10 col 31 pic z9.99	from  const-cert-h-prev. 
    05                 	line 10 col 51 pic z9.99	from  const-asst-a-prev. 
    05                	line 10 col 61 pic z9.99	from  const-reg-a-prev. 
    05                 	line 10 col 74 pic z9.99	from  const-cert-a-prev. 
    05			line 12 col 18 value "GROUP REDUCTION RATES (". 
    05  scr-nbr-rates	line 12 col 41 pic z9 		using const-max-nbr-rates. 
    05  		line 12 col 44 value "OUT OF 19 IN USE)". 
    05			line 13 col 01 value "SEC.". 
    05			line 13 col 05 value "GROUP". 
    05			line 13 col 12 value "CURR.". 
    05			line 13 col 19 value "PREV.". 
    05			line 13 col 30 value "SEC.". 
    05			line 13 col 35 value "GROUP". 
    05			line 13 col 42 value "CURR.". 
    05			line 13 col 48 value "PREV.". 
    05			line 13 col 59 value "SEC.". 
    05			line 13 col 64 value "GROUP". 
    05			line 13 col 70 value "CURR.".       
    05			line 13 col 76 value "PREV.". 
01  scr-mask2b. 
    05  scr-sect-1	line 14 col 01 pic xx		using const-sect-1 auto.                             
    05  scr-group-1	line 14 col 07 pic z9		using const-group-1 auto required blank when zero. 
    05  scr-curr-1	line 14 col 11 pic z9.99	using const-curr-1 auto required blank when zero. 
    05			line 14 col 18 pic z9.99	from  const-prev-1 blank when zero. 
    05  scr-sect-2	line 14 col 31 pic xx		using const-sect-2 auto.    
    05  scr-group-2	line 14 col 37 pic z9		using const-group-2 auto blank when zero.             
    05  scr-curr-2	line 14 col 41 pic z9.99	using const-curr-2 auto required blank when zero. 
    05  		line 14 col 47 pic z9.99	from  const-prev-2 blank when zero.    
    05  scr-sect-3	line 14 col 60 pic xx		using const-sect-3 auto.  
    05  scr-group-3	line 14 col 65 pic z9		using const-group-3 auto required blank when zero. 
    05  scr-curr-3	line 14 col 69 pic z9.99	using const-curr-3 auto required blank when zero. 
    05			line 14 col 75 pic z9.99	from  const-prev-3 blank when zero. 
    05  scr-sect-4	line 15 col 01 pic xx		using const-sect-4 auto.                  
    05  scr-group-4	line 15 col 07 pic z9		using const-group-4 auto required blank when zero.   
    05  scr-curr-4	line 15 col 11 pic z9.99	using const-curr-4 auto required blank when zero. 
    05			line 15 col 18 pic z9.99	from  const-prev-4 blank when zero. 
    05  scr-sect-5	line 15 col 31 pic xx		using const-sect-5 auto.             
    05  scr-group-5	line 15 col 37 pic z9		using const-group-5 auto required blank when zero.         
    05  scr-curr-5	line 15 col 41 pic z9.99	using const-curr-5 auto required blank when zero. 
    05			line 15 col 47 pic z9.99	from  const-prev-5 blank when zero. 
    05  scr-sect-6	line 15 col 60 pic xx		using const-sect-6 auto.                   
    05  scr-group-6	line 15 col 65 pic z9		using const-group-6 auto required blank when zero. 
    05  scr-curr-6	line 15 col 69 pic z9.99	using const-curr-6 auto required blank when zero. 
    05			line 15 col 75 pic z9.99	from  const-prev-6 blank when zero.         
    05  scr-sect-7	line 16 col 01 pic xx		using const-sect-7 auto.                             
    05  scr-group-7	line 16 col 07 pic z9		using const-group-7 auto required blank when zero.   
    05  scr-curr-7	line 16 col 11 pic z9.99	using const-curr-7 auto required blank when zero. 
    05			line 16 col 18 pic z9.99	from  const-prev-7 blank when zero. 
    05  scr-sect-8	line 16 col 31 pic xx		using const-sect-8 auto.                      
    05  scr-group-8	line 16 col 37 pic z9		using const-group-8 auto required blank when zero.        
    05  scr-curr-8	line 16 col 41 pic z9.99	using const-curr-8 auto required blank when zero. 
    05            	line 16 col 47 pic z9.99	from  const-prev-8 blank when zero.                     
    05  scr-sect-9	line 16 col 60 pic xx		using const-sect-9 auto.                  
    05  scr-group-9	line 16 col 65 pic z9		using const-group-9 auto required blank when zero. 
    05  scr-curr-9	line 16 col 69 pic z9.99	using const-curr-9 auto required blank when zero. 
    05            	line 16 col 75 pic z9.99	from  const-prev-9 blank when zero.                      
    05  scr-sect-10	line 17 col 01 pic xx		using const-sect-10 auto.                             
    05  scr-group-10	line 17 col 07 pic z9		using const-group-10 auto required blank when zero. 
    05  scr-curr-10	line 17 col 11 pic z9.99	using const-curr-10 auto required blank when zero. 
    05             	line 17 col 18 pic z9.99	from  const-prev-10 blank when zero.                  
    05  scr-sect-11	line 17 col 31 pic xx		using const-sect-11 auto.                   
    05  scr-group-11	line 17 col 37 pic z9		using const-group-11 auto required blank when zero. 
    05  scr-curr-11	line 17 col 41 pic z9.99	using const-curr-11 auto required blank when zero. 
    05             	line 17 col 47 pic z9.99	from  const-prev-11 blank when zero.                       
    05  scr-sect-12	line 17 col 60 pic xx		using const-sect-12 auto.                    
    05  scr-group-12	line 17 col 65 pic z9		using const-group-12 auto required blank when zero. 
    05  scr-curr-12	line 17 col 69 pic z9.99	using const-curr-12 auto required blank when zero. 
    05             	line 17 col 75 pic z9.99	from  const-prev-12 blank when zero.                     
    05  scr-sect-13	line 18 col 01 pic xx		using const-sect-13 auto. 
    05  scr-group-13	line 18 col 07 pic z9		using const-group-13 auto required blank when zero.   
    05  scr-curr-13	line 18 col 11 pic z9.99	using const-curr-13 auto required blank when zero. 
    05             	line 18 col 18 pic z9.99	from  const-prev-13 blank when zero.                  
    05  scr-sect-14	line 18 col 31 pic xx		using const-sect-14 auto.                    
    05  scr-group-14	line 18 col 37 pic z9		using const-group-14 auto required blank when zero.        
    05  scr-curr-14	line 18 col 41 pic z9.99	using const-curr-14 auto required blank when zero. 
    05             	line 18 col 47 pic z9.99	from  const-prev-14 blank when zero.                     
    05  scr-sect-15	line 18 col 60 pic xx		using const-sect-15 auto.                    
    05  scr-group-15	line 18 col 65 pic z9		using const-group-15 auto required blank when zero. 
    05  scr-curr-15	line 18 col 69 pic z9.99	using const-curr-15 auto required blank when zero. 
    05             	line 18 col 75 pic z9.99	from  const-prev-15 blank when zero.                   
    05  scr-sect-16	line 19 col 01 pic xx		using const-sect-16 auto.                             
    05  scr-group-16	line 19 col 07 pic z9		using const-group-16 auto required blank when zero.   
    05  scr-curr-16	line 19 col 11 pic z9.99	using const-curr-16 auto required blank when zero. 
    05             	line 19 col 18 pic z9.99	from  const-prev-16 blank when zero.                      
    05  scr-sect-17	line 19 col 31 pic xx		using const-sect-17 auto.                           
    05  scr-group-17	line 19 col 37 pic z9		using const-group-17 auto required blank when zero.       
    05  scr-curr-17	line 19 col 41 pic z9.99	using const-curr-17 auto required blank when zero. 
    05               	line 19 col 47 pic z9.99	from  const-prev-17 blank when zero.                  
    05  scr-sect-18	line 19 col 60 pic xx		using const-sect-18 auto.                                                                
    05  scr-group-18	line 19 col 65 pic z9		using const-group-18 auto required blank when zero. 
    05  scr-curr-18	line 19 col 69 pic z9.99	using const-curr-18 auto required blank when zero. 
    05             	line 19 col 75 pic z9.99	from  const-prev-18 blank when zero.                         
    05  scr-sect-19	line 20 col 01 pic xx		using const-sect-19 auto.                             
    05  scr-group-19	line 20 col 07 pic z9		using const-group-19 auto required blank when zero.   
    05  scr-curr-19	line 20 col 11 pic z9.99	using const-curr-19 auto required blank when zero. 
    05             	line 20 col 18 pic z9.99	from  const-prev-19 blank when zero.                         
01  scr-mask2c. 
* (y2k - auto fix)
*   05  scr-yy-prev	line 05 col 09 pic 99		using const-yy-prev auto. 
    05  scr-yy-prev	line 05 col 09 pic 9(4)		using const-yy-prev auto. 
    05  scr-mm-prev	line 05 col 14 pic 99		using const-mm-prev auto. 
    05  scr-dd-prev	line 05 col 17 pic 99		using const-dd-prev auto. 
    05  scr-wcb-prev	line 05 col 21 pic zz9.9(5)	using const-wcb-prev auto. 
    05  scr-bi-prev	line 05 col 36 pic z9.99	using const-bilateral-prev auto. 
    05  scr-ic-prev	line 05 col 53 pic z9.99	using const-ic-prev auto. 
    05  scr-sr-prev	line 05 col 71 pic z9.99	using const-sr-prev auto. 
    05  scr-asst-h-prev	line 10 col 07 pic z9.99	using const-asst-h-prev auto. 
    05  scr-reg-h-prev	line 10 col 18 pic z9.99	using const-reg-h-prev auto. 
    05  scr-cert-h-prev	line 10 col 31 pic z9.99	using const-cert-h-prev auto. 
    05  scr-asst-a-prev	line 10 col 51 pic z9.99	using const-asst-a-prev auto. 
    05  scr-reg-a-prev	line 10 col 61 pic z9.99	using const-reg-a-prev auto. 
    05  scr-cert-a-prev	line 10 col 74 pic z9.99	using const-cert-a-prev auto. 
    05  scr-prev-1	line 14 col 18 pic z9.99	using const-prev-1 auto. 
    05  scr-prev-2	line 14 col 47 pic z9.99	using const-prev-2 auto. 
    05  scr-prev-3	line 14 col 75 pic z9.99	using const-prev-3 auto. 
    05  scr-prev-4	line 15 col 18 pic z9.99	using const-prev-4 auto. 
    05  scr-prev-5	line 15 col 47 pic z9.99	using const-prev-5 auto. 
    05  scr-prev-6	line 15 col 75 pic z9.99	using const-prev-6 auto. 
    05  scr-prev-7	line 16 col 18 pic z9.99	using const-prev-7 auto. 
    05  scr-prev-8	line 16 col 47 pic z9.99	using const-prev-8 auto. 
    05  scr-prev-9	line 16 col 75 pic z9.99	using const-prev-9 auto. 
    05  scr-prev-10	line 17 col 18 pic z9.99	using const-prev-10 auto. 
    05  scr-prev-11	line 17 col 47 pic z9.99	using const-prev-11 auto. 
    05  scr-prev-12	line 17 col 75 pic z9.99	using const-prev-12 auto. 
    05  scr-prev-13	line 18 col 18 pic z9.99	using const-prev-13 auto. 
    05  scr-prev-14	line 18 col 47 pic z9.99	using const-prev-14 auto. 
    05  scr-prev-15	line 18 col 75 pic z9.99	using const-prev-15 auto. 
    05  scr-prev-16	line 19 col 18 pic z9.99	using const-prev-16 auto. 
    05  scr-prev-17	line 19 col 47 pic z9.99	using const-prev-17 auto. 
    05  scr-prev-18	line 19 col 75 pic z9.99	using const-prev-18 auto. 
    05  scr-prev-19	line 20 col 18 pic z9.99	using const-prev-19 auto. 
01  scr-mask3. 
* 
*	CODE 0 IS THE DEFAULT, WHICH IS STORED ON THE DOCTOR MASTER.   
*	THE MISC.PERCENTAGES ARE DISPLAYED & ACCEPTED AS ZZ9, BUT ARE 
*	STORED ON THE CONSTANTS MASTER AS 9V99 
* 
    05			line 03 col 20 value "MISC.CODE". 
    05			line 03 col 35 value "CURRENT". 
    05			line 03 col 48 value "PREVIOUS". 
    05			line 04 col 33 value "FISCAL YEAR". 
    05			line 04 col 46 value "FISCAL YEAR". 
    05			line 06 col 24 value "0". 
    05			line 06 col 33 pic x(11) using ws-misc-msg-curr. 
    05			line 06 col 51 value "----".                    
    05			line 07 col 24 value "1". 
    05  scr-misc-1	line 07 col 37 pic zz9.99 using save-curr-1 auto. 
    05			line 07 col 43 value "%". 
    05			line 07 col 50 pic zz9.99 from save-prev-1. 
    05			line 07 col 56 value "%". 
    05			line 08 col 24 value "2". 
    05  scr-misc-2	line 08 col 37 pic zz9.99 using save-curr-2 auto. 
    05			line 08 col 43 value "%". 
    05			line 08 col 50 pic zz9.99 from save-prev-2. 
    05			line 08 col 56 value "%". 
    05			line 09 col 24 value "3". 
    05  scr-misc-3	line 09 col 37 pic zz9.99 using save-curr-3 auto. 
    05			line 09 col 43 value "%". 
    05			line 09 col 50 pic zz9.99 from save-prev-3. 
    05			line 09 col 56 value "%". 
    05			line 10 col 24 value "4". 
    05  scr-misc-4	line 10 col 37 pic zz9.99 using save-curr-4 auto. 
    05			line 10 col 43 value "%". 
    05			line 10 col 50 pic zz9.99 from save-prev-4. 
    05			line 10 col 56 value "%". 
    05			line 11 col 24 value "5". 
    05  scr-misc-5	line 11 col 37 pic zz9.99 using save-curr-5 auto. 
    05			line 11 col 43 value "%". 
    05			line 11 col 50 pic zz9.99 from save-prev-5. 
    05			line 11 col 56 value "%". 
    05			line 12 col 24 value "6". 
    05  scr-misc-6	line 12 col 37 pic zz9.99 using save-curr-6 auto. 
    05			line 12 col 43 value "%". 
    05			line 12 col 50 pic zz9.99 from save-prev-6. 
    05			line 12 col 56 value "%". 
    05			line 13 col 24 value "7". 
    05  scr-misc-7	line 13 col 37 pic zz9.99 using save-curr-7 auto. 
    05			line 13 col 43 value "%". 
    05			line 13 col 50 pic zz9.99 from save-prev-7. 
    05			line 13 col 56 value "%". 
    05			line 14 col 24 value "8". 
    05  scr-misc-8	line 14 col 37 pic zz9.99 using save-curr-8 auto. 
    05			line 14 col 43 value "%". 
    05			line 14 col 50 pic zz9.99 from save-prev-8. 
    05			line 14 col 56 value "%". 
    05			line 15 col 24 value "9". 
    05  scr-misc-9	line 15 col 37 pic zz9.99 using save-curr-9 auto. 
    05			line 15 col 43 value "%". 
    05			line 15 col 50 pic zz9.99 from save-prev-9. 
    05			line 15 col 56 value "%". 
 
 
01  scr-rec-3-warning. 
    05			line 18 col 10 value "***WARNING***" bell blink. 
    05			line 18 col 33 value "ONCE ACCEPTED, THESE VALUES CANNOT BE CHANGED".     
01  scr-mask4. 
    05  		line 03 col 25 value "CLASS". 
    05			line 03 col 34 value "DESCRIPTION". 
    05  		line 03 col 57 value "NBR.OF CLASSES:". 
    05  scr-nbr-classes line 03 col 73 pic z9 using const-nbr-classes. 
    05  scr-ltr-1	line 05 col 27 pic a using const-class-ltr-1 auto. 
    05  scr-desc-1	line 05 col 34 pic x(24) using const-class-desc-1. 
    05  scr-ltr-2	line 06 col 27 pic a using const-class-ltr-2 auto.  
    05  scr-desc-2	line 06 col 34 pic x(24) using const-class-desc-2. 
    05  scr-ltr-3	line 07 col 27 pic a using const-class-ltr-3 auto. 
    05  scr-desc-3	line 07 col 34 pic x(24) using const-class-desc-3. 
    05  scr-ltr-4	line 08 col 27 pic a using const-class-ltr-4 auto. 
    05  scr-desc-4	line 08 col 34 pic x(24) using const-class-desc-4.   
    05  scr-ltr-5	line 09 col 27 pic a using const-class-ltr-5 auto. 
    05  scr-desc-5	line 09 col 34 pic x(24) using const-class-desc-5.          
    05  scr-ltr-6	line 10 col 27 pic a using const-class-ltr-6 auto. 
    05  scr-desc-6	line 10 col 34 pic x(24) using const-class-desc-6. 
    05  scr-ltr-7	line 11 col 27 pic a using const-class-ltr-7 auto. 
    05  scr-desc-7	line 11 col 34 pic x(24) using const-class-desc-7.   
    05  scr-ltr-8	line 12 col 27 pic a using const-class-ltr-8 auto. 
    05  scr-desc-8	line 12 col 34 pic x(24) using const-class-desc-8. 
    05  scr-ltr-9	line 13 col 27 pic a using const-class-ltr-9 auto. 
    05  scr-desc-9	line 13 col 34 pic x(24) using const-class-desc-9. 
    05  scr-ltr-10	line 14 col 27 pic a using const-class-ltr-10 auto. 
    05  scr-desc-10	line 14 col 34 pic x(24) using const-class-desc-10.    
    05  scr-ltr-11	line 15 col 27 pic a using const-class-ltr-11 auto.  
    05  scr-desc-11	line 15 col 34 pic x(24) using const-class-desc-11.   
    05  scr-ltr-12	line 16 col 27 pic a using const-class-ltr-12 auto. 
    05  scr-desc-12	line 16 col 34 pic x(24) using const-class-desc-12. 
    05  scr-ltr-13	line 17 col 27 pic a using const-class-ltr-13 auto.  
    05  scr-desc-13	line 17 col 34 pic x(24) using const-class-desc-13.  
    05  scr-ltr-14	line 18 col 27 pic a using const-class-ltr-14 auto. 
    05  scr-desc-14	line 18 col 34 pic x(24) using const-class-desc-14. 
    05  scr-ltr-15	line 19 col 27 pic a using const-class-ltr-15 auto. 
    05  scr-desc-15	line 19 col 34 pic x(24) using const-class-desc-15. 
 
01  scr-mask5-lit. 
 
    05				line 03 col 11 value "CON #". 
    05				line 03 col 20 value "NX AVAIL PATIENT". 
    05 				line 03 col 48 value "CON #". 
    05				line 03 col 57 value "NX AVAIL PATIENT". 
    05				line 05 col 04 value "CON01". 
    05				line 05 col 41 value "CON14". 
    05				line 06 col 04 value "CON02". 
    05				line 06 col 41 value "CON15". 
    05				line 07 col 04 value "CON03". 
    05				line 07 col 41 value "CON16". 
    05				line 08 col 04 value "CON04". 
    05				line 08 col 41 value "CON17". 
    05				line 09 col 04 value "CON05". 
    05				line 09 col 41 value "CON18". 
    05				line 10 col 04 value "CON06". 
    05				line 10 col 41 value "CON19". 
    05				line 11 col 04 value "CON07". 
    05				line 11 col 41 value "CON20". 
    05				line 12 col 04 value "CON08". 
    05				line 12 col 41 value "CON21". 
    05				line 13 col 04 value "CON09". 
    05				line 13 col 41 value "CON22". 
    05				line 14 col 04 value "CON10". 
    05				line 14 col 41 value "CON23". 
    05				line 15 col 04 value "CON11". 
    05				line 15 col 41 value "CON24". 
    05				line 16 col 04 value "CON12". 
    05				line 16 col 41 value "CON25". 
    05                     	line 17 col 04 value "CON13". 
 
 
01  scr-mask5. 
 
    05  scr-con-nbr   	   line pline col pcol1 pic 99 using const-con-nbr(i). 
    05  scr-nx-avail-pat   line pline col pcol2 pic z(11)9 using const-nx-avail-pat(i). 
01  scr-const-isam-mask. 
 
    05				line 05 col 04 value "CLINIC IDENT". 
    05				line 05 col 18 value "CLINIC". 
    05				line 05 col 30 value "CLINIC NAME". 
    05				line 05 col 48 value "CYCLE". 
    05				line 05 col 55 value "PERIOD END DATE". 
* 2004/02/26 - MC - change card colour to afp flag
*   05				line 05 col 74 value "CARD". 
*   05				line 06 col 73 value "COLOUR". 
    05				line 05 col 74 value "AFP".  
    05				line 06 col 73 value "FLAG".  
* 2004/02/26 - end
    05				line 09 col 30 value "CLINIC ADDRESS". 
    05				line 15 col 04 value "OVERPAYMENT WRITEOFF LIMIT  1". 
    05				line 16 col 04 value "UNDERPAYMENT WRITEOFF LIMIT 2 (NOT IN PAYCODE TABLE)". 
    05				line 17 col 04 value "UNDERPAYMENT WRITEOFF LIMIT 3 (IN PAYCODE TABLE)". 
    05				line 18 col 04 value "OVERPAYMENT WRITEOFF LIMIT  4". 
* 2006/11/08 - MC
    05				line 19 col 04 value "NEXT AVAILABLE PAYMENT BATCH NUMBER". 
* 2006/11/08 - end
    05				line 20 col 04 value "NEXT AVAILABLE BATCH NUMBER". 
    05                          line 21 col 04 value "REDUCTION FACTOR". 
    05                          line 22 col 04 value "OVERPAY   FACTOR". 
    05  scr-clinic-ident	line 07 col 09 pic 99 using 
					iconst-clinic-nbr-1-2. 
* (1999/may/17 - B.E. allow alpha character in clinic nbr)
*   05  scr-clinic-nbr		line 07 col 19 pic 9(4) using 
    05  scr-clinic-nbr		line 07 col 19 pic x(4) using 
					iconst-clinic-nbr. 
    05  scr-clinic-name		line 07 col 26 pic x(20) using 
					iconst-clinic-name. 
    05  scr-clinic-cycle	line 07 col 50 pic 99 using 
					iconst-clinic-cycle-nbr auto. 
* (y2k - auto fix)
*   05  scr-date-period-end-yy	line 07 col 58 pic 99 using 
    05  scr-date-period-end-yy	line 07 col 58 pic 9(4) using 
* (y2k)
					iconst-date-period-end-yy auto. 
    05  			line 07 col 62 value "/". 
    05  scr-date-period-end-mm	line 07 col 63 pic 99 using 
					iconst-date-period-end-mm auto. 
    05				line 07 col 65 value "/". 
    05  scr-date-period-end-dd	line 07 col 66 pic 99 using 
					iconst-date-period-end-dd auto. 
    05  scr-clinic-card-colour	line 07 col 76 pic x using 
					iconst-clinic-card-colour auto. 
 
    05  scr-clinic-addr-1	line 11 col 26 pic x(25) using 
					iconst-clinic-addr-l1. 
    05  scr-clinic-addr-2	line 12 col 26 pic x(25) using 
					iconst-clinic-addr-l2. 
    05  scr-clinic-addr-3	line 13 col 26 pic x(25) using 
					iconst-clinic-addr-l3. 
    05  scr-clinic-over-lim1    line 15 col 57 pic z9.99 using 
					iconst-clinic-over-lim1. 
    05  scr-clinic-under-lim2   line 16 col 57 pic z9.99 using 
					iconst-clinic-under-lim2. 
    05  scr-clinic-under-lim3   line 17 col 57 pic z9.99 using 
					iconst-clinic-under-lim3. 
    05  scr-clinic-over-lim4    line 18 col 57 pic z9.99 using 
					iconst-clinic-over-lim4. 
* 2006/11/08 - MC
    05  scr-clinic-pay-batch-nbr   line 19 col 57 pic x(6) using 
					iconst-clinic-pay-batch-nbr. 
* 2006/11/08 - end
    05  scr-clinic-batch-nbr    line 20 col 57 pic 9(6) using 
					iconst-clinic-batch-nbr. 
    05  scr-reduction-factor    line 21 col 57 pic z9.99 using 
					iconst-reduction-factor. 
    05  scr-overpay-factor      line 22 col 57 pic z9.99 using 
					iconst-overpay-factor. 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
procedure division. 
declaratives. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr.       
err-iconst-mstr. 
 
*   IF 'RECORD LOCKED' PRINT WARNING, SET FLAG SO THAT READ WILL LOOP 
*   UNTIL THE RECORD IS UNLOCKED. 
 
*mf    if status-iconst-mstr = "7015" 
*mf    then 
*mf	move 9				to err-ind 
*mf	perform za0-common-error	thru za0-99-exit 
*mf	move 'Y'			to flag-lock 
*mf  else 
*mf	move status-iconst-mstr		to status-file 
*mf	display file-status-display 
*mf	stop "ERROR IN ACCESSING ISAM CONSTANTS MASTER" 
*mf	stop run. 
*   ENDIF 
 
    if status-cobol-iconst-mstr-1 = "9" 
    then 
	move 9				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move 'Y'			to flag-lock 
  else 
	move status-cobol-iconst-mstr		to status-file 
	display file-status-display 
	stop "ERROR IN ACCESSING ISAM CONSTANTS MASTER" 
	stop run. 

err-audit-rpt-file section. 
    use after standard error procedure on audit-file.     
err-audit-rpt. 
    move status-audit-rpt		to status-file. 
    display file-status-display. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE". 
    stop run. 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
*   stop run. 
    chain "$obj/menu".

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
 
 
*	DELETE AUDIT FILE 
*    expunge audit-file. 
 
    open i-o iconst-mstr.   
    open output audit-file. 
 
**  FOLLOWING COMMENTED STATEMENTS MOVE TO AB0-PROCESSING 
**  SEP/87 C.E. 
** 
**AA0-10. 
** 
**  DISPLAY SCR-TITLE. 
**  ACCEPT SCR-ACPT-OPTION. 
** 
**  IF OPTION = "C" 
**  THEN 
**	DISPLAY SCR-CHANGE-OPTION 
**  ELSE 
**	IF OPTION = "I" 
**	THEN 
**	    DISPLAY SCR-INQUIRE-OPTION 
**	ELSE 
**	    MOVE 1			TO ERR-IND 
**	    PERFORM ZA0-COMMON-ERROR 
**					THRU ZA0-99-EXIT 
**	    GO TO AA0-10. 
**	ENDIF 
**  ENDIF 
 
aa0-99-exit. 
    exit. 
ab0-processing.  
 
    move spaces					to option 
              					   ws-const-mstr-ident. 
 
    display scr-title. 
    accept scr-acpt-option. 
 
    if option = "C" 
    then 
	display scr-change-option 
    else 
	if option = "I" 
	then 
	    display scr-inquire-option 
	else 
 
**  FOLLOWING IF-COND ADDED SEP/87 C.E. 
 
	    if option = "*" 
	    then 
		go to ab0-99-exit 
	    else 
	    	move 1			to err-ind 
	    	perform za0-common-error 
					thru za0-99-exit 
**     	        GO TO AA0-10. 
		go to ab0-processing. 
*	    ENDIF 
*	ENDIF 
*   ENDIF 
 
ab0-10-acpt-rec-nbr. 
 
    move spaces				to	ws-const-mstr-ident. 
 
    display scr-rec-nbr. 
    accept scr-rec-nbr. 
 
**  IF WS-CONST-MSTR-IDENT = "**" 
    if ws-const-mstr-ident-1 = "*" 
    then 
**	GO TO AB0-99-EXIT 
	go to ab0-processing 
    else 
	if    ws-const-mstr-ident-1 = spaces 
	  and ws-const-mstr-ident-2   numeric 
	then 
	    move ws-const-mstr-ident-2		to	iconst-clinic-nbr-1-2 
	else 
	    if   ws-const-mstr-ident-1   numeric 
	     and ws-const-mstr-ident-2 = spaces 
	    then 
*		(rec 6 used within Payroll system and not maintained by this pgm)
		if ws-const-mstr-ident-1 <> 6
		then
		    move ws-const-mstr-ident-1	to	iconst-clinic-nbr-1-2 
		else
		    move 1			to	err-ind 
		    perform za0-common-error	thru	za0-99-exit 
	    else 
	    	if    ws-const-mstr-ident numeric 
		  and ws-const-mstr-ident <> "06"
*		      (rec 6 used within Payroll system and not maintained by this pgm)
		then 
		    move ws-const-mstr-ident	to	iconst-clinic-nbr-1-2 
		else 
		    move 1			to	err-ind 
		    perform za0-common-error	thru	za0-99-exit 
**		    GO TO AB0-PROCESSING. 
		    go to ab0-10-acpt-rec-nbr. 
*	   	ENDIF 
*	    ENDIF 
*	ENDIF 
*   ENDIF 
 
    display blank-rest-of-page. 
    move "Y"					to	flag. 
 
    perform ma1-read-iconst-mstr		thru	ma1-99-exit. 
 
    if not-ok 
    then 
	move 5				to err-ind 
	perform za0-common-error	thru za0-99-exit 
**	GO TO AB0-PROCESSING. 
	go to ab0-10-acpt-rec-nbr. 
*   (ELSE) 
*   ENDIF 
 
ab0-100-continue. 
 
    if iconst-clinic-nbr-1-2 = 1 
    then 
	perform ba0-const-mstr-1-routine	thru	ba0-99-exit 
    else 
	if iconst-clinic-nbr-1-2 = 2 
	then 
	    perform ca0-const-mstr-2-curr   	thru	ca0-99-exit 
	else 
	    if iconst-clinic-nbr-1-2 = 3 
	    then 
	 	perform ga0-const-mstr-3-routine thru	ga0-99-exit 
	    else 
		if iconst-clinic-nbr-1-2 = 4 
	 	then 
	 	    perform ha0-const-mstr-4-routine 
						thru	ha0-99-exit 
		else 
		    if iconst-clinic-nbr-1-2 = 5 
		    then 
			perform ia0-const-mstr-5-routine 
						thru 	ia0-99-exit 
		    else 
	            	perform fa0-isam-const-mstr-routine 
						thru	fa0-99-exit. 
*		    ENDIF 
*	        ENDIF 
*	    ENDIF 
*	ENDIF 
*   ENDIF 
 
ab0-200-verify. 
 
    if option = "I" 
    then 
**	GO TO AB0-PROCESSING. 
	go to ab0-10-acpt-rec-nbr. 
*   (ELSE) 
*   ENDIF 
 
    display verification-screen-add-chg. 
    accept verification-screen-add-chg. 
 
    if flag = "Y" 
    then 
	if const-rec-1-rec-nbr = 3 
	then 
	    perform ga2-convert-for-conmstr	thru	ga2-99-exit 
		varying	temp 
			from 1 by 1 
		until	temp > 9 
	    perform pa1-re-write-iconst-mstr	thru	pa1-99-exit 
	    perform ra0-write-audit-rpt	thru	ra0-99-exit 
**	    GO TO AB0-PROCESSING 
	    go to ab0-10-acpt-rec-nbr 
   	else 
	    perform pa1-re-write-iconst-mstr	thru	pa1-99-exit 
	    perform ra0-write-audit-rpt		thru	ra0-99-exit 
** 	    GO TO AB0-PROCESSING. 
	    go to ab0-10-acpt-rec-nbr. 
*	ENDIF 
*   (ELSE) 
*   ENDIF 
 
    if flag = "N" 
    then 
	display scr-reject-entry 
	display confirm 
	stop " " 
	display blank-line-24 
**	GO TO AB0-PROCESSING. 
	go to ab0-10-acpt-rec-nbr. 
*   (ELSE) 
*   ENDIF 
 
    if flag = "M" 
    then 
	go to ab0-100-continue 
    else 
	if    flag = "P" 
	  and iconst-clinic-nbr-1-2 = 2    
	then 
	    move spaces				to	flag 
	    perform da0-password		thru	da0-99-exit 
	    if password-ok 
	    then 
		perform da1-const-mstr-2-prev	thru	da1-99-exit 
	    	go to ab0-200-verify 
	    else 
	 	move 6				to	err-ind 
	  	perform za0-common-error	thru	za0-99-exit 
	 	go to ab0-200-verify 
*	    ENDIF 
	else 
	    move 1				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to ab0-200-verify. 
*	ENDIF 
*   ENDIF 
 
ab0-99-exit. 
    exit. 
ba0-const-mstr-1-routine. 
 
    if flag not = "M"  
    then 
	display scr-mask1. 
*   (ELSE) 
*   ENDIF 
 
    if option = "I" 
    then 
	go to ba0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    accept scr-clinic-1-2-nbr-1. 
    if const-clinic-1-2-nbr-1 = zero 
    then 
	move 0			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-1. 
 
    accept scr-clinic-1-2-nbr-2. 
    if const-clinic-1-2-nbr-2 = zero 
    then 
	move 1			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-2. 
 
    accept scr-clinic-1-2-nbr-3. 
    if const-clinic-1-2-nbr-3 = zero 
    then 
	move 2			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-3. 
               
    accept scr-clinic-1-2-nbr-4. 
    if const-clinic-1-2-nbr-4 = zero 
    then 
	move 3			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-4. 
 
    accept scr-clinic-1-2-nbr-5. 
    if const-clinic-1-2-nbr-5 = zero 
    then 
	move 4	 		to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-5. 
 
    accept scr-clinic-1-2-nbr-6. 
    if const-clinic-1-2-nbr-6 = zero 
    then 
	move 5			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-6. 
 
    accept scr-clinic-1-2-nbr-7. 
    if const-clinic-1-2-nbr-7 = zero 
    then 
	move 6			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-7. 
               
    accept scr-clinic-1-2-nbr-8. 
    if const-clinic-1-2-nbr-8 = zero 
    then 
	move 7			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-8. 
 
    accept scr-clinic-1-2-nbr-9. 
    if const-clinic-1-2-nbr-9 = zero 
    then 
	move 8 			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-9. 
 
    accept scr-clinic-1-2-nbr-10. 
    if const-clinic-1-2-nbr-10 = zero 
    then 
	move 9 			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-10. 
 
    accept scr-clinic-1-2-nbr-11. 
    if const-clinic-1-2-nbr-11 = zero 
    then 
	move 10			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-11. 
               
    accept scr-clinic-1-2-nbr-12. 
    if const-clinic-1-2-nbr-12 = zero 
    then 
	move 11			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-12. 
 
    accept scr-clinic-1-2-nbr-13. 
    if const-clinic-1-2-nbr-13 = zero 
    then 
	move 12			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-13. 
 
    accept scr-clinic-1-2-nbr-14. 
    if const-clinic-1-2-nbr-14 = zero 
    then 
	move 13			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-14. 
 
    accept scr-clinic-1-2-nbr-15. 
    if const-clinic-1-2-nbr-15 = zero 
    then 
	move 14			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-15. 
               
    accept scr-clinic-1-2-nbr-16. 
    if const-clinic-1-2-nbr-16 = zero 
    then 
	move 15			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-16. 
 
    accept scr-clinic-1-2-nbr-17. 
    if const-clinic-1-2-nbr-17 = zero 
    then 
	move 16			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-17. 
 
    accept scr-clinic-1-2-nbr-18. 
    if const-clinic-1-2-nbr-18 = zero 
    then 
	move 17			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-18. 
 
    accept scr-clinic-1-2-nbr-19. 
    if const-clinic-1-2-nbr-19 = zero 
    then 
	move 18			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-19. 
               
    accept scr-clinic-1-2-nbr-20. 
    if const-clinic-1-2-nbr-20 = zero 
    then 
	move 19			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-20. 
 
    accept scr-clinic-1-2-nbr-21. 
    if const-clinic-1-2-nbr-21 = zero 
    then 
	move 20			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-21. 
 
    accept scr-clinic-1-2-nbr-22. 
    if const-clinic-1-2-nbr-22 = zero 
    then 
	move 21			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-22. 
 
    accept scr-clinic-1-2-nbr-23. 
    if const-clinic-1-2-nbr-23 = zero 
    then 
	move 22			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-23. 
               
    accept scr-clinic-1-2-nbr-24. 
    if const-clinic-1-2-nbr-24 = zero 
    then 
	move 23			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-24. 
 
    accept scr-clinic-1-2-nbr-25. 
    if const-clinic-1-2-nbr-25 = zero 
    then 
	move 24			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-25. 
 
    accept scr-clinic-1-2-nbr-26. 
    if const-clinic-1-2-nbr-26 = zero 
    then 
	move 25			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-26. 
               
    accept scr-clinic-1-2-nbr-27. 
    if const-clinic-1-2-nbr-27 = zero 
    then 
	move 26			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-27. 
 
    accept scr-clinic-1-2-nbr-28. 
    if const-clinic-1-2-nbr-28 = zero 
    then 
	move 27			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-28. 
 
    accept scr-clinic-1-2-nbr-29. 
    if const-clinic-1-2-nbr-29 = zero 
    then 
	move 28			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-29. 
 
    accept scr-clinic-1-2-nbr-30. 
    if const-clinic-1-2-nbr-30 = zero 
    then 
	move 29			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-30. 
 
    accept scr-clinic-1-2-nbr-31. 
    if const-clinic-1-2-nbr-31 = zero 
    then 
	move 30			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-31. 
               
    accept scr-clinic-1-2-nbr-32. 
    if const-clinic-1-2-nbr-32 = zero 
    then 
	move 31			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-32. 
 
    accept scr-clinic-1-2-nbr-33. 
    if const-clinic-1-2-nbr-33 = zero 
    then 
	move 32			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-33. 
 
    accept scr-clinic-1-2-nbr-34. 
    if const-clinic-1-2-nbr-34 = zero 
    then 
	move 33			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-34. 
 
    accept scr-clinic-1-2-nbr-35. 
    if const-clinic-1-2-nbr-35 = zero 
    then 
	move 34			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-35. 
               
    accept scr-clinic-1-2-nbr-36. 
    if const-clinic-1-2-nbr-36 = zero 
    then 
	move 35			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-36. 
 
    accept scr-clinic-1-2-nbr-37. 
    if const-clinic-1-2-nbr-37 = zero 
    then 
	move 36			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-37. 
 
    accept scr-clinic-1-2-nbr-38. 
    if const-clinic-1-2-nbr-38 = zero 
    then 
	move 37			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-38. 
 
    accept scr-clinic-1-2-nbr-39. 
    if const-clinic-1-2-nbr-39 = zero 
    then 
	move 38			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-39. 
               
    accept scr-clinic-1-2-nbr-40. 
    if const-clinic-1-2-nbr-40 = zero 
    then 
	move 39			to	const-max-nbr-clinics  
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-40. 
 
* 2005/01/04 - MC - include 23 more clinics from 41 to 63
*    move 40			to	const-max-nbr-clinics. 
 
    accept scr-clinic-1-2-nbr-41. 
    if const-clinic-1-2-nbr-41 = zero 
    then 
	move 40			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-41. 
 
    accept scr-clinic-1-2-nbr-42. 
    if const-clinic-1-2-nbr-42 = zero 
    then 
	move 41			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-42. 
 
    accept scr-clinic-1-2-nbr-43. 
    if const-clinic-1-2-nbr-43 = zero 
    then 
	move 42			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-43. 
               
    accept scr-clinic-1-2-nbr-44. 
    if const-clinic-1-2-nbr-44 = zero 
    then 
	move 43			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-44. 
 
    accept scr-clinic-1-2-nbr-45. 
    if const-clinic-1-2-nbr-45 = zero 
    then 
	move 44			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-45. 
 
    accept scr-clinic-1-2-nbr-46. 
    if const-clinic-1-2-nbr-46 = zero 
    then 
	move 45			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-46. 
               
    accept scr-clinic-1-2-nbr-47. 
    if const-clinic-1-2-nbr-47 = zero 
    then 
	move 46			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-47. 
 
    accept scr-clinic-1-2-nbr-48. 
    if const-clinic-1-2-nbr-48 = zero 
    then 
	move 47			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-48. 
 
    accept scr-clinic-1-2-nbr-49. 
    if const-clinic-1-2-nbr-49 = zero 
    then 
	move 48			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-49. 
 
    accept scr-clinic-1-2-nbr-50. 
    if const-clinic-1-2-nbr-50 = zero 
    then 
	move 49			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-50. 
 
    accept scr-clinic-1-2-nbr-51. 
    if const-clinic-1-2-nbr-51 = zero 
    then 
	move 50			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-51. 
               
    accept scr-clinic-1-2-nbr-52. 
    if const-clinic-1-2-nbr-52 = zero 
    then 
	move 51			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-52. 
 
    accept scr-clinic-1-2-nbr-53. 
    if const-clinic-1-2-nbr-53 = zero 
    then 
	move 52			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-53. 
 
    accept scr-clinic-1-2-nbr-54. 
    if const-clinic-1-2-nbr-54 = zero 
    then 
	move 53			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-54. 
 
    accept scr-clinic-1-2-nbr-55. 
    if const-clinic-1-2-nbr-55 = zero 
    then 
	move 54			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-55. 
               
    accept scr-clinic-1-2-nbr-56. 
    if const-clinic-1-2-nbr-56 = zero 
    then 
	move 55			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-56. 
 
    accept scr-clinic-1-2-nbr-57. 
    if const-clinic-1-2-nbr-57 = zero 
    then 
	move 56			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-57. 
 
    accept scr-clinic-1-2-nbr-58. 
    if const-clinic-1-2-nbr-58 = zero 
    then 
	move 57			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-58. 
 
    accept scr-clinic-1-2-nbr-59. 
    if const-clinic-1-2-nbr-59 = zero 
    then 
	move 58			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-59. 
               
    accept scr-clinic-1-2-nbr-60. 
    if const-clinic-1-2-nbr-60 = zero 
    then 
	move 59			to	const-max-nbr-clinics  
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-60. 

    accept scr-clinic-1-2-nbr-61. 
    if const-clinic-1-2-nbr-61 = zero 
    then 
	move 60			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-61. 
               
    accept scr-clinic-1-2-nbr-62. 
    if const-clinic-1-2-nbr-62 = zero 
    then 
	move 61			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-62. 
 
    accept scr-clinic-1-2-nbr-63. 
    if const-clinic-1-2-nbr-63 = zero 
    then 
	move 62			to	const-max-nbr-clinics 
	go to ba0-10-clear-clinics. 
*   (ELSE) 
*   ENDIF 
    accept scr-clinic-nbr-63. 
    move 63			to	const-max-nbr-clinics.

* 2005/01/04 - end

*	ZERO OUT ALL CLINICS AFTER THE MAX. NBR STATED. 
 
ba0-10-clear-clinics. 
 
    add 1    const-max-nbr-clinics 	giving ws-save-max-clinics. 
 
    perform ba1-zero-areas		thru ba1-99-exit 
	varying i from ws-save-max-clinics by 1 
* 2005/01/04 - MC
*	until   i > 40. 
	until   i > 63. 
* 2005/01/04 - end
 
    display scr-mask1. 
 
ba0-99-exit. 
    exit. 
 
ba1-zero-areas. 
 
    move zeros				to const-clinic-nbr-1-2 (i). 
    move spaces				to const-clinic-nbr (i). 
 
ba1-99-exit. 
    exit. 
ca0-const-mstr-2-curr.    
 
    if flag not = "M" 
    then 
	display scr-mask2a   
	display scr-mask2b. 
*   (ELSE) 
*   ENDIF 
 
    if option = "I" 
    then 
	go to ca0-99-exit.        
*   (ELSE) 
*   ENDIF 
 
    perform ca2-acpt-effective-date-curr	thru	ca2-99-exit.       
    accept  scr-wcb-curr. 
    display scr-wcb-curr. 
    accept  scr-bi-curr. 
    display scr-bi-curr. 
    accept  scr-ic-curr. 
    display scr-ic-curr. 
    accept  scr-sr-curr. 
    display scr-sr-curr. 
    accept  scr-asst-h-curr. 
    display scr-asst-h-curr. 
    accept  scr-reg-h-curr. 
    display scr-reg-h-curr. 
    accept  scr-cert-h-curr. 
    display scr-cert-h-curr. 
    accept  scr-asst-a-curr. 
    display scr-asst-a-curr. 
    accept  scr-reg-a-curr. 
    display scr-reg-a-curr. 
    accept  scr-cert-a-curr. 
    display scr-cert-a-curr. 
    perform ca1-acpt-group-rates-curr		thru	ca1-99-exit. 
 
ca0-99-exit.       
    exit. 
ca1-acpt-group-rates-curr. 
 
    accept  scr-sect-1. 
    display scr-sect-1. 
 
    if const-sect-1 = spaces 
    then 
	move 0			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-1. 
    display scr-group-1. 
    accept  scr-curr-1. 
    display scr-curr-1. 
 
    accept  scr-sect-2. 
    display scr-sect-2. 
 
    if const-sect-2 = spaces 
    then 
	move 1			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-2. 
    display scr-group-2. 
    accept  scr-curr-2. 
    display scr-curr-2. 
 
    accept  scr-sect-3. 
    display scr-sect-3. 
 
    if const-sect-3 = spaces 
    then 
	move 2			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-3. 
    display scr-group-3. 
    accept  scr-curr-3. 
    display scr-curr-3. 
 
    accept  scr-sect-4. 
    display scr-sect-4. 
 
    if const-sect-4 = spaces 
    then 
	move 3			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-4. 
    display scr-group-4. 
    accept  scr-curr-4. 
    display scr-curr-4. 
 
    accept  scr-sect-5. 
    display scr-sect-5. 
 
    if const-sect-5 = spaces 
    then 
	move 4			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-5. 
    display scr-group-5. 
    accept  scr-curr-5. 
    display scr-curr-5. 
 
    accept  scr-sect-6.  
    display scr-sect-6. 
 
    if const-sect-6 = spaces 
    then 
	move 5			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-6. 
    display scr-group-6. 
    accept  scr-curr-6. 
    display scr-curr-6. 
 
    accept  scr-sect-7. 
    display scr-sect-7. 
 
    if const-sect-7 = spaces 
    then 
	move 6			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-7. 
    display scr-group-7. 
    accept  scr-curr-7. 
    display scr-curr-7. 
 
    accept  scr-sect-8. 
    display scr-sect-8. 
 
    if const-sect-8 = spaces 
    then 
	move 7 			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-8. 
    display scr-group-8. 
    accept  scr-curr-8. 
    display scr-curr-8. 
 
    accept  scr-sect-9. 
    display scr-sect-9. 
 
    if const-sect-9 = spaces 
    then 
	move 8 			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-9. 
    display scr-group-9. 
    accept  scr-curr-9. 
    display scr-curr-9. 
 
    accept  scr-sect-10. 
    display scr-sect-10. 
 
    if const-sect-10 = spaces 
    then      
	move 9 			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-10. 
    display scr-group-10. 
    accept  scr-curr-10. 
    display scr-curr-10. 
 
    accept  scr-sect-11. 
    display scr-sect-11. 
               
    if const-sect-11 = spaces 
    then 
	move 10			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-11. 
    display scr-group-11. 
    accept  scr-curr-11. 
    display scr-curr-11. 
 
    accept  scr-sect-12. 
    display scr-sect-12. 
             
    if const-sect-12 = spaces 
    then 
	move 11			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-12. 
    display scr-group-12. 
    accept  scr-curr-12. 
    display scr-curr-12. 
 
    accept  scr-sect-13. 
    display scr-sect-13. 
        
    if const-sect-13 = spaces 
    then 
	move 12			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-13. 
    display scr-group-13. 
    accept  scr-curr-13. 
    display scr-curr-13. 
 
    accept  scr-sect-14.  
    display scr-sect-14. 
 
    if const-sect-14 = spaces 
    then 
	move 13			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-14. 
    display scr-group-14. 
    accept  scr-curr-14. 
    display scr-curr-14. 
 
    accept  scr-sect-15. 
    display scr-sect-15. 
 
    if const-sect-15 = spaces 
    then 
 	move 14			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-15. 
    display scr-group-15. 
    accept  scr-curr-15. 
    display scr-curr-15. 
 
    accept  scr-sect-16. 
    display scr-sect-16. 
 
    if const-sect-16 = spaces 
    then 
	move 15			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-16. 
    display scr-group-16. 
    accept  scr-curr-16. 
    display scr-curr-16. 
 
    accept  scr-sect-17. 
    display scr-sect-17. 
 
    if const-sect-17 = spaces 
    then      
	move 16			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-17. 
    display scr-group-17. 
    display scr-group-17. 
    display scr-curr-17. 
    accept  scr-curr-17. 
    display scr-curr-17. 
 
    accept  scr-sect-18. 
    display scr-sect-18. 
               
    if const-sect-18 = spaces 
    then 
	move 17			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-18. 
    display scr-group-18. 
    accept  scr-curr-18. 
    display scr-curr-18. 
 
    accept  scr-sect-19. 
    display scr-sect-19. 
             
    if const-sect-19 = spaces 
    then 
	move 18			to	const-max-nbr-rates 
	go to ca1-100-nbr-rates. 
*   (ELSE) 
*   ENDIF 
 
    accept  scr-group-19. 
    display scr-group-19. 
    accept  scr-curr-19. 
    display scr-curr-19. 
 
    move 19			to	const-max-nbr-rates. 
 
ca1-100-nbr-rates. 
 
    add 1, const-max-nbr-rates	giving	ws-save-max-rates. 
 
    perform ca3-zero-areas	thru	ca3-99-exit 
	varying	i 
	from	ws-save-max-rates 
	by  	1   
	until	i > 19.  
     
    display scr-mask2b.     
    display scr-nbr-rates. 
 
ca1-99-exit. 
    exit. 
ca2-acpt-effective-date-curr. 
 
* (y2k)
    accept  scr-yy-curr.           
* (y2k)
    display scr-yy-curr. 
 
* (y2k)
    if const-yy-curr < 32 
    then 
	move 2				to	err-ind 
	perform za0-common-error 	thru	za0-99-exit       
	go to ca2-acpt-effective-date-curr. 
*   (ELSE) 
*   ENDIF 
 
 
ca2-100-mth. 
 
    accept  scr-mm-curr.         
    display scr-mm-curr. 
 
    if   const-mm-curr < 1 
      or const-mm-curr > 12 
    then 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit       
	go to ca2-100-mth. 
*   (ELSE) 
*   ENDIF 
 
ca2-200-day. 
 
    accept  scr-dd-curr.       
    display scr-dd-curr. 
 
    if   const-dd-curr < 1 
      or const-dd-curr > max-nbr-days (const-mm-curr) 
    then 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit        
	go to ca2-200-day. 
*   (ELSE) 
*   ENDIF 
 
ca2-99-exit.       
    exit. 
ca3-zero-areas. 
 
    move zeros			to	const-group-rates (i) 
					const-group-rates (i). 
    move spaces			to	const-section (i) 
					const-section (i). 
 
ca3-99-exit. 
    exit. 
da0-password. 
 
    move "N"			to	password-flag. 
    move spaces			to	ws-entered-password. 
    display scr-password-prompt. 
    accept  scr-password. 
 
    if ws-entered-password = ws-valid-password 
    then 
	move "Y"			to	password-flag. 
*   (ELSE) 
*   ENDIF 
 
da0-99-exit. 
    exit. 
da1-const-mstr-2-prev. 
 
    perform da3-acpt-effective-date-prev	thru	da3-99-exit. 
 
    display scr-wcb-prev. 
    accept  scr-wcb-prev. 
    display scr-wcb-prev. 
 
    display scr-bi-prev. 
    accept  scr-bi-prev. 
    display scr-bi-prev. 
 
    display scr-ic-prev. 
    accept  scr-ic-prev. 
    display scr-ic-prev. 
 
    display scr-sr-prev. 
    accept  scr-sr-prev. 
    display scr-sr-prev. 
 
    display scr-asst-h-prev. 
    accept  scr-asst-h-prev. 
    display scr-asst-h-prev. 
 
    display scr-reg-h-prev. 
    accept  scr-reg-h-prev. 
    display scr-reg-h-prev. 
 
    display scr-cert-h-prev. 
    accept  scr-cert-h-prev. 
    display scr-cert-h-prev. 
 
    display scr-asst-a-prev. 
    accept  scr-asst-a-prev. 
    display scr-asst-a-prev. 
 
    display scr-reg-a-prev. 
    accept  scr-reg-a-prev. 
    display scr-reg-a-prev. 
 
    display scr-cert-a-prev. 
    accept  scr-cert-a-prev. 
    display scr-cert-a-prev. 
 
    perform da2-acpt-group-rates-prev	thru da2-99-exit.       
 
da1-99-exit.       
    exit. 
da2-acpt-group-rates-prev. 
 
    if const-sect-1 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-1. 
    accept  scr-prev-1. 
    display scr-prev-1. 
 
    if const-sect-2 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-2. 
    accept  scr-prev-2. 
    display scr-prev-2. 
 
    if const-sect-3 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-3. 
    accept  scr-prev-3. 
    display scr-prev-3. 
 
    if const-sect-4 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-4. 
    accept  scr-prev-4. 
    display scr-prev-4. 
 
    if const-sect-5 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-5. 
    accept  scr-prev-5. 
    display scr-prev-5. 
 
    if const-sect-6 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-6. 
    accept  scr-prev-6. 
    display scr-prev-6. 
 
    if const-sect-7 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-7. 
    accept  scr-prev-7. 
    display scr-prev-7. 
 
    if const-sect-8 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-8. 
    accept  scr-prev-8. 
    display scr-prev-8. 
 
    if const-sect-9 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-9. 
    accept  scr-prev-9. 
    display scr-prev-9. 
 
    if const-sect-10 = spaces 
    then      
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-10. 
    accept  scr-prev-10. 
    display scr-prev-10. 
               
    if const-sect-11 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-11. 
    accept  scr-prev-11. 
    display scr-prev-11. 
             
    if const-sect-12 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-12. 
    accept  scr-prev-12. 
    display scr-prev-12. 
        
    if const-sect-13 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-13. 
    accept  scr-prev-13. 
    display scr-prev-13. 
 
    if const-sect-14 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-14. 
    accept  scr-prev-14. 
    display scr-prev-14. 
 
    if const-sect-15 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-15. 
    accept  scr-prev-15. 
    display scr-prev-15. 
 
    if const-sect-16 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-16. 
    accept  scr-prev-16. 
    display scr-prev-16. 
 
    if const-sect-17 = spaces 
    then      
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-17. 
    accept  scr-prev-17. 
    display scr-prev-17. 
               
    if const-sect-18 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-18. 
    accept  scr-prev-18. 
    display scr-prev-18. 
             
    if const-sect-19 = spaces 
    then 
	go to da2-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    display scr-prev-19. 
    accept  scr-prev-19. 
    display scr-prev-19. 
 
da2-99-exit. 
    exit. 
da3-acpt-effective-date-prev. 
 
* (y2k)
    display scr-yy-prev. 
* (y2k)
    accept  scr-yy-prev.      
* (y2k)
    display scr-yy-prev. 
 
* (y2k)
    if const-yy-prev < 32 
    then 
	move 2				to	err-ind 
	perform za0-common-error 	thru	za0-99-exit       
	go to da3-acpt-effective-date-prev. 
*   (ELSE) 
*   ENDIF 
 
 
da3-100-mth. 
 
    display scr-mm-prev. 
    accept  scr-mm-prev.        
    display scr-mm-prev. 
 
    if   const-mm-prev < 1 
      or const-mm-prev > 12 
    then 
	move 3				to	err-ind 
	perform za0-common-error	thru	za0-99-exit       
	go to da3-100-mth. 
*   (ELSE) 
*   ENDIF 
 
da3-200-day. 
 
    display scr-dd-prev. 
    accept  scr-dd-prev.             
    display scr-dd-prev. 
 
    if   const-dd-prev < 1 
      or const-dd-prev > max-nbr-days (const-mm-prev) 
    then 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit        
	go to da3-200-day. 
*   (ELSE) 
*   ENDIF 
 
* (y2k)
    if const-effective-date-prev not < const-effective-date-curr 
    then 
	move 7			to	err-ind 
	perform za0-common-error thru	za0-99-exit 
	go to da3-acpt-effective-date-prev. 
*   (ELSE) 
*   ENDIF 
 
da3-99-exit.       
    exit. 
fa0-isam-const-mstr-routine. 
 
    if flag not = "M" 
    then 
	display scr-const-isam-mask. 
*   (ELSE) 
*   ENDIF 
 
 
    if option = "I" 
    then 
	go to fa0-99-exit 
    else 
	next sentence. 
*   ENDIF 
 
    accept scr-clinic-nbr. 
    accept scr-clinic-name. 
    accept scr-clinic-cycle. 
 
fa0-10. 
 
* (y2k)
    accept scr-date-period-end-yy. 
 
* (y2k)
    if iconst-date-period-end-yy < 32   
    then 
	move 2				to err-ind 
	perform za0-common-error	thru za0-99-exit  
	go to fa0-10. 
*   (ELSE) 
*   ENDIF 
 
fa0-20. 
 
* (y2k)
    accept scr-date-period-end-mm. 
 
* (y2k)
    if   iconst-date-period-end-mm < 1 
* (y2k)
      or iconst-date-period-end-mm > 12 
    then 
	move 3				to err-ind 
	perform za0-common-error	thru za0-99-exit  
	go to fa0-20. 
*   (ELSE) 
*   ENDIF 
 
fa0-30. 
 
* (y2k)
    accept scr-date-period-end-dd. 
 
* (y2k)
    if   iconst-date-period-end-dd < 1 
* (y2k)
      or iconst-date-period-end-dd > max-nbr-days (iconst-date-period-end-mm) 
    then 
	move 4				to err-ind 
	perform za0-common-error	thru za0-99-exit  
	go to fa0-30. 
*   (ELSE) 
*   ENDIF 
 
    accept scr-clinic-card-colour. 
 
    accept scr-clinic-addr-1. 
    accept scr-clinic-addr-2. 
    accept scr-clinic-addr-3. 
 
    accept scr-clinic-over-lim1. 
    accept scr-clinic-under-lim2. 
    accept scr-clinic-under-lim3. 
    accept scr-clinic-over-lim4. 
 
* 2006/11/08 - MC
    accept scr-clinic-pay-batch-nbr. 
* 2006/11/08 - end
    accept scr-clinic-batch-nbr. 
    accept scr-reduction-factor. 
    accept scr-overpay-factor. 
 
fa0-99-exit. 
    exit. 
 
ga0-const-mstr-3-routine. 
 
    move zeros				to	save-misc-code-values. 
 
* 
*	VALUES ARE STORED ON CONMSTR AS 9V99 BUT ARE DISPLAYED AS ZZ9 
* 
    perform ga1-convert-for-screen	thru	ga1-99-exit 
	varying	temp 
		from 1 by 1   
	until	temp > 9. 
 
* 
*	REDISPLAY EVEN IF A MODIFY, OTHERWISE CORRECTION CAN NEVER 
*	BE ENTERED (CAN'T CHANGE A NON-ZERO FIELD) 
 
    display scr-mask3. 
 
    if option = "I" 
    then 
	go to ga0-99-exit  
    else 
	display scr-rec-3-warning. 
*   ENDIF 
 
* 
*	WARNING--DO NOT ALLOW CHANGES TO PREVIOUS FISCAL YEAR OR 
*		 TO CURRENT VALUES THAT ARE NOT ZERO, OTHERWISE THE 
*		 AUDIT TRAIL FOR MISCELLANEOUS EARNINGS WILL BE 
*		 LOST. 
* 
    if save-curr-1 = zero 
    then  
	accept  scr-misc-1  
	display scr-misc-1. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-2 = zero 
    then 
	accept  scr-misc-2  
	display scr-misc-2. 
*   (ELSE)   
*   ENDIF 
 
    if save-curr-3 = zero 
    then    
	accept  scr-misc-3   
	display scr-misc-3. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-4 = zero 
    then 
	accept  scr-misc-4  
	display scr-misc-4. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-5 = zero 
    then 
	accept  scr-misc-5  
	display scr-misc-5. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-6 = zero 
    then 
	accept  scr-misc-6  
	display scr-misc-6. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-7 = zero 
    then 
	accept  scr-misc-7  
	display scr-misc-7. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-8 = zero 
    then 
	accept  scr-misc-8  
	display scr-misc-8. 
*   (ELSE) 
*   ENDIF 
 
    if save-curr-9 = zero 
    then 
	accept  scr-misc-9  
	display scr-misc-9. 
*   (ELSE) 
*   ENDIF 
 
ga0-99-exit. 
    exit. 
 
 
 
ga1-convert-for-screen. 
 
    multiply const-misc-curr (temp)	by	100 
					giving	save-curr (temp). 
    multiply const-misc-prev (temp)	by	100 
					giving	save-prev (temp). 
 
ga1-99-exit. 
    exit. 
 
 
 
ga2-convert-for-conmstr. 
 
    divide save-curr (temp)      	by	100 
					giving	const-misc-curr (temp). 
 
ga2-99-exit. 
    exit. 
ha0-const-mstr-4-routine. 
 
    if flag not = "M" 
    then 
	display scr-mask4. 
*   (ELSE) 
*   ENDIF 
 
    if option = "I" 
    then 
	go to ha0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
	accept scr-ltr-1. 
	if const-class-ltr-1 = spaces 
	then 
	    move 0			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 1				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-const-mstr-4-routine. 
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-1. 
 
ha0-class-2. 
 
	accept scr-ltr-2 . 
	if const-class-ltr-2 = spaces 
	then 
	    move 1			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 2				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-2.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-2. 
 
ha0-class-3. 
 
	accept scr-ltr-3.      
	if const-class-ltr-3 = spaces 
	then 
	    move 2			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 3				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-3.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-3. 
 
ha0-class-4. 
 
	accept scr-ltr-4. 
	if const-class-ltr-4 = spaces 
	then 
	    move 3			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 4				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-4.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-4. 
 
ha0-class-5. 
 
	accept scr-ltr-5.   
	if const-class-ltr-5 = spaces 
	then 
	    move 4			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 5				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-5.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-5. 
ha0-class-6. 
 
	accept scr-ltr-6. 
	if const-class-ltr-6 = spaces 
	then 
	    move 5			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 6				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-6.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-6. 
 
ha0-class-7. 
 
	accept scr-ltr-7. 
	if const-class-ltr-7 = spaces 
	then 
	    move 6			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 7				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-7.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-7. 
 
ha0-class-8. 
 
	accept scr-ltr-8.  
	if const-class-ltr-8 = spaces 
	then 
	    move 7			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 8				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-8.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-8. 
 
ha0-class-9. 
 
	accept scr-ltr-9. 
	if const-class-ltr-9 = spaces 
	then 
	    move 8			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 9				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-9.                
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-9. 
 
ha0-class-10. 
 
	accept scr-ltr-10. 
	if const-class-ltr-10 = spaces 
	then 
	    move 9			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 10				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-10.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-10. 
 
ha0-class-11. 
 
	accept scr-ltr-11. 
	if const-class-ltr-11 = spaces 
	then 
	    move 10			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 11				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-11.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-11. 
 
ha0-class-12. 
 
	accept scr-ltr-12. 
	if const-class-ltr-12 = spaces 
	then 
	    move 11			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 12				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-12.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-12. 
 
ha0-class-13. 
 
	accept scr-ltr-13. 
	if const-class-ltr-13 = spaces 
	then 
	    move 12			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 13				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-13.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-13. 
 
ha0-class-14. 
 
	accept scr-ltr-14. 
	if const-class-ltr-14 = spaces 
	then 
	    move 13			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 14				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-14.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-14. 
 
ha0-class-15. 
 
	accept scr-ltr-15. 
	if const-class-ltr-15 = spaces 
	then 
	    move 14			to	const-nbr-classes 
	    go to ha0-100-continue 
	else 
	    move 15				to	ws-class-nbr 
	    perform ha2-check-other-classes thru ha2-99-exit 
	    if class-ok 
	    then 
	 	next sentence 
	    else 
	 	go to ha0-class-15.               
*	    ENDIF 
*   	ENDIF 
 
    accept scr-desc-15. 
    move 15				to	const-nbr-classes. 
ha0-100-continue. 
 
    add 1, const-nbr-classes		giving	ws-class-nbr.        
 
    perform ha1-clear-remaining		thru	ha1-99-exit 
	varying temp 
	from    ws-class-nbr 
	by      1 
	until	temp > 15.   
 
    display scr-mask4. 
 
ha0-99-exit.  
    exit. 
 
 
 
ha1-clear-remaining. 
 
    move spaces				to	const-class-ltr  (temp) 
 						const-class-desc (temp). 
 
ha1-99-exit. 
    exit. 
 
 
 
ha2-check-other-classes. 
 
    move "Y"				to	class-flag. 
 
 
    perform ha21-compare-ltrs		thru	ha21-99-exit 
	varying temp	 
	from    1 
	by      1 
	until	temp > const-nbr-classes    
	     or class-not-ok. 
 
ha2-99-exit. 
    exit. 
 
 
 
ha21-compare-ltrs. 
 
    if    const-class-ltr (temp)     = const-class-ltr (ws-class-nbr) 
      and temp                   not = ws-class-nbr 
    then 
	move "N"			to	class-flag    
	move 8				to	err-ind 
	perform za0-common-error	thru	za0-99-exit. 
*   (ELSE) 
*   ENDIF 
 
ha21-99-exit. 
    exit. 
ia0-const-mstr-5-routine. 
 
    if flag not = "M" 
    then 
	perform ia1-display-screen5   		thru ia1-99-exit. 
*   ENDIF 
 
    if option = "I" 
    then 
	go to ia0-99-exit. 
*   ENDIF 
 
    move 5					to pline. 
    move 13 					to pcol1. 
    move 20					to pcol2. 
    perform ia2-accept-nx-avail-pat		thru ia2-99-exit 
		varying i from 1 by 1 
		until   i > 13. 
    move 5					to pline. 
    move 50					to pcol1. 
    move 57					to pcol2. 
    perform ia2-accept-nx-avail-pat		thru ia2-99-exit 
		varying i from 14 by 1 
		until   i > 24. 
    move 16					to pline. 
    move 25					to i. 
    display scr-con-nbr. 
    accept scr-con-nbr. 
    display scr-nx-avail-pat. 
    accept scr-nx-avail-pat. 
 
 
ia0-99-exit. 
    exit. 
 
 
ia1-display-screen5. 
 
    display scr-mask5-lit. 
 
    move 5				to pline. 
    move 13				to pcol1. 
    move 20				to pcol2. 
    perform ia11-display-scr-mask5	thru ia11-99-exit 
		varying i from 1 by 1 
		until   i > 13. 
    move 5				to pline. 
    move 50				to pcol1. 
    move 57				to pcol2. 
    perform ia11-display-scr-mask5	thru ia11-99-exit 
		varying i from 14 by 1 
		until   i > 25. 
 
 
ia1-99-exit. 
    exit. 
 
 
ia11-display-scr-mask5. 
 
    display scr-mask5. 
    add 1					to pline. 
 
ia11-99-exit. 
    exit. 
 
 
 
ia2-accept-nx-avail-pat. 
 
    display scr-nx-avail-pat. 
    accept scr-nx-avail-pat. 
    add 1					to pline. 
 
ia2-99-exit. 
    exit. 
ma1-read-iconst-mstr. 
 
    move 'N'				to	flag-lock. 
 
    if option = "I" 
    then 
	read   iconst-mstr       
	    invalid key 
	        move "N"		to	flag 
	        go to ma1-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    if option not = "I" 
    then 
	read   iconst-mstr    lock 
	    invalid key 
	        move "N"		to	flag 
	        go to ma1-99-exit. 
*   (ELSE) 
*   ENDIF 
 
    if rec-locked 
    then 
	go to ma1-read-iconst-mstr. 
*   (ELSE) 
*   ENDIF 
 
    add 1				to ctr-const-mstr-reads. 
 
ma1-99-exit. 
    exit. 
 
 
 
 
 
pa1-re-write-iconst-mstr. 
 
*mf    rewrite iconst-mstr-rec unlock. 
	rewrite iconst-mstr-rec.
	unlock iconst-mstr  record.
    add 1				to ctr-const-mstr-changes.  
 
pa1-99-exit. 
    exit. 
ra0-write-audit-rpt. 
 
    move constants-mstr-rec-1		to audit-record. 
    write audit-record. 
 
    add 1				to ctr-audit-rpt-writes. 
 
ra0-99-exit. 
    exit. 
az0-end-of-job. 
    
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
*   stop " "
 
    close iconst-mstr. 
    close  audit-file. 
 
*   call program "menu". 
    chain "$obj/menu".
 
    stop run. 
 
az0-99-exit. 
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

    copy "y2k_default_sysdate_century.rtn".