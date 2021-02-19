identification division. 
program-id. m040.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/03/01. 
date-compiled. 
security. 
* 
*    files      : f040 - oma fee master 
*		: "rm040" - audit report file 
*               : audit report 
*    program purpose : oma fee schedule maintenance.   
* 
* 
*	revision history 
*	---------------- 
* 
*	mar/82 (d.m.)	-screen layout re-organized 
*			-previous values added to display 
*			-add/change/delete counters added 
*			-move ohip fees onto oma fees (only 1 set 
*			 of fees as of april/82) 
*	 		-program re-written 
* 
*	feb/84 (a.j.)   -modified to handle file layout changes 
* 
*	sep/84 (m.s.)   -modified to make sure the last four digits 
*			 of fee-icc-code are numeric, and modified 
*                        error message 4 
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised feb/98 j. chau  - s149 unix conversion
*  99/jan/15 B.E.             - y2k
*  00/jul/25 B.E.	- reactivate the oma fee code 'effective date' so
*			  that current/previous  prices are based up effective
*			  date of each code and not sharing a common
*			  effective date in the constants master.
*  00/jul/31 B.E.	- fees increased to 3 decimals - 9(5)v99 to 9(4)v999.
*  00/sep/05 B.E.	- added FEE-GLOBAL-ADDON-CD-EXCLUSION-FLAG which is used
*                         to DISABLE automatic application of "global" 
*		    	  add on codes E400/E1401/E409/E410
* 00/dec/06 B.E. - allowed entry of min/max values for all ICC sections
*		   for both current and previous years.
* 
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
 
    select audit-file 
          assign to printer print-file-name 
	  file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
copy "f040_oma_fee_mstr.fd". 
* 
fd  audit-file 
    record contains 219 characters. 
 
01  audit-record. 
    05  audit-type				pic x(7). 
    05  filler					pic x.          
    05  audit-rec				pic x(217). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
		value "rm040". 
77  audit-report-msg				pic x(40)	value 
		"AUDIT REPORT IS IN FILENAME RM040". 
77  ws-hold-perc-or-flat-ind			pic x. 
77  ws-entered-password				pic x(5)	value spaces. 
* 
copy "rmapw.ws". 
* 
* 
*  eof flags 
* 
77  eof-oma-mstr				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  status-file				pic x(11). 
*mf 77  status-oma-mstr				pic x(11) value zero. 

77  status-file					pic x(2). 
77  status-cobol-oma-mstr			pic x(2) value zero. 
77  status-audit-rpt				pic xx	  value zero. 
 
01  entry-type					pic x. 
    88  add-code				value "A". 
    88  change-code				value "C". 
    88  delete-code				value "D". 
    88  inquire-code				value "I". 
** 
** sept/87 c.e. 
** 
    88  terminate-code				value "*". 
 
77  pc-year					pic 9. 
77  cntr					pic 99 	value zero. 
77  cnum					pic 99	value zero. 
77  lnum					pic 99	value zero. 
* 
77  confirm-space				pic x   value space. 
* 
01  flag-mode					pic x. 
    88  display-mode				value 'D'. 
    88  update-mode				value 'U'. 
 
 
01  read-flag					pic x. 
    88 on-file					value "Y". 
    88 not-on-file     				value "N". 
 
01  status-flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  password-flag 				pic x. 
    88  password-ok				value "Y". 
    88  password-not-ok				value "N". 
01  display-type				pic xxx. 
    88  gen-title				value "GEN". 
    88  tec-title				value "TEC". 
 
01  acc-mod-rej					pic x. 
    88  accept-screen				value "Y". 
    88  prev-yr-modify				value "P". 
    88  modify-screen				value "M". 
    88  reject-screen    			value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-fee-mstr-reads			pic 9(7). 
    05  ctr-fee-mstr-writes			pic 9(7). 
    05  ctr-fee-mstr-adds			pic 9(7). 
    05  ctr-fee-mstr-changes			pic 9(7). 
    05  ctr-fee-mstr-deletes			pic 9(7). 
 
 
*  feedbacks 
* 
77  feedback-oma-fee-mstr			pic x(4). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(55)   value 
			"INVALID REPLY". 
	10  filler				pic x(55)   value 
			"OMA CODE ALREADY EXISTS". 
	10  filler				pic x(55)   value 
			"ASSOCIATE NBR NOT ON OMA MASTER". 
	10  filler				pic x(55)   value 
			"PAGE MUST BE BETWEEN 1 AND 199 INCLUSIVE". 
	10  filler				pic x(55)   value 
*   msg #5
			"M SUFFIX MUST BE 'Y' OR 'N'". 
	10  filler				pic x(55)   value 
			"WARNING ONLY-ZERO FEE".      
	10  filler				pic x(55)   value 
			"ERROR MESSAGE #7 GOES HERE". 
	10  filler				pic x(55)   value 
			"RECORD DOESN'T EXIST". 
	10  filler				pic x(55)   value 
			"INVALID CODE--TYPE MUST BE 'CV,NM,DR,CP,PF,DU,DT,SP'". 
	10  filler				pic x(55)   value 
*   msg #10
			"DIAGNOSTIC IND MUST BE 'Y' OR 'N'". 
	10  filler				pic x(55)   value 
			"REF/PHYSICIAN IND MUST BE 'Y' OR 'N'". 
	10  filler				pic x(55)   value 
			"HOSP # IND MUST BE 'Y' OR 'N'". 
	10  filler				pic x(55)   value 
			"IN/OUT IND MUST BE 'I' 'O' OR 'B'". 
	10  filler				pic x(55)   value 
			"ADMIT/DT IND MUST BE 'Y' OR 'N'". 
	10  filler				pic x(55)   value 
*   msg #15
			"REDUC-WITH MUST BE 'DT,SP' AND NOT 99 IN NBRS 2 & 3". 
	10  filler				pic x(55)   value 
			"BILATERAL MUST BE 'BI' OR BLANK". 
	10  filler				pic x(55)   value 
			"Must be BLANK or if ADD-ON must be 'P'ercent or 'F'lat". 
	10  filler				pic x(55)   value 
			"PASSWORD NOT ACCEPTABLE". 
	10  filler				pic x(55)   value 
			"GEN. MUST BE < 1.01 AND SPEC. MUST BE > 1.00". 
	10  filler				pic x(55)   value 
*   msg #20
			"Value must be 'Y'es or 'N'o". 
	10  filler				pic x(55)   value 
			"'Y','N' OR 'R' SUFFIX REQUIRED". 
	10  filler				pic x(55)   value 
			"THE LAST 4 DIGITS OF ICC-CODE MUST BE NUMERIC". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(55) 
			occurs 22 times. 
 
01  err-msg-comment				pic x(55). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
screen section. 
 
01  scr-titles. 
    05  blank screen. 
    05  line 01 col 01 value "M040".              
    05  line 01 col 17 value "FEE MASTER MAINTENANCE". 
* (y2k - auto fix)
*   05  line 01 col 73 pic xx/xx/xx from sys-date-long. 
    05  line 01 col 71 pic xxxx/xx/xx from sys-date-long. 
    05  line 03 col 01 value "ICC Code:". 
    05  line 03 col 20 value "Description:". 
    05  line 04 col 01 value "Technical:". 
    05  line 04 col 20 value "Effective  :". 
    05  line 04 col 50 value "Active for data entry?      :". 
    05  line 05 col 50 value "EXCLUDE from Global Add-on's:". 
    05  line 06 col 01 value "-------------OHIP-------------". 
*    05  line 06 col 38 value "Rates". 
    05  line 06 col 51 value "--------------OMA-------------". 
    05  line 07 col 33 value " Min.        Max.".
    05  line 07 col 21 value "Anae". 
    05  line 07 col 26 value "Asst". 
    05  line 07 col 72 value "Anae". 
    05  line 07 col 77 value "Asst". 
*    05  line 09 col 32 value ".... CURRENT ....". 
*    05  line 10 col 32 value ".... PREVIOUS ...". 
   
    05  line 12 col 23 value "* Additional Claim Related Data *". 
    05  line 14 col 01 value "Page:". 
    05  line 14 col 08 value "-". 
    05  line 14 col 12 value "/". 
    05  line 14 col 15 value "-". 
    05  line 14 col 20 value "'M' Suffix Allowed:". 
    05  line 14 col 42 value "Diagnostic:". 
    05  line 14 col 56 value "Ref/Physician:". 
    05  line 16 col 01 value "Hospital Nbr:". 
    05  line 16 col 17 value "In/Out:". 
    05  line 16 col 27 value "Admit/Dt:". 
    05  line 17 col 63 value "--Card Required--". 
    05  line 18 col 01 value "--------------- ADD ON Codes -------------------". 
    05  line 18 col 63 value "Suffix 'A' 'B' 'C'". 
    05  line 19 col 51 value ".. CURRENT .......". 
    05  line 20 col 51 value ".. PREVIOUS ......". 
    05  line 22 col 01 value "ADD ON PERCENTAGE/FLAT RATE:". 
    05  line 22 col 30 value '/'. 
    05  line 22 col 35  value 'Spec:from '. 
    05  line 22 col 48 value 'to '. 
* 
01  scr-general-title. 
    05  line 07 col 01 value " GENERAL ". 
    05  line 07 col 12 value " SPECIAL". 
    05  line 07 col 51 value " GENERAL ". 
    05  line 07 col 62 value " SPECIAL". 
* 
01  scr-technical-title. 
    05  line 07 col 01 value "TECHNICAL". 
    05  line 07 col 12 value "PROFESS.". 
    05  line 07 col 51 value "TECHNICAL". 
    05  line 07 col 62 value "PROFESS.". 
* 
01  scr-option. 
    05  scr-option-sel	line 01 col 40 pic x using entry-type auto required. 
    05  		line 01 col 42 value is "(ADD/CHANGE/DELETE/INQUIRY)". 
* 
01  scr-option-lit-title line 01 col 17  value "             FEE MASTER MAINTENANCE - ". 
01  scr-option-lit. 
    05  scr-option-add	line 01 col 55 value "ADD             ". 
    05  scr-option-chg	line 01 col 55 value "CHANGE          ". 
    05  scr-option-del  line 01 col 55 value "DELETE          ". 
    05  scr-option-inq  line 01 col 55 value "INQUIRY         ". 
* 
01  scr-code. 
    05      		line 01 col 08 value "Oma Code:". 
    05  scr-code-nbr	line 01 col 18 pic x999 using fee-oma-cd auto required. 
* 
01  scr-icc-desc-tech. 
    05  scr-icc-code	line 03 col 12 pic xx9999 using fee-icc-code auto. 
    05  scr-desc	line 03 col 33 pic x(48) using fee-desc auto. 
    05  scr-tech-ind    line 04 col 12 pic x using fee-tech-ind auto. 
    05  scr-eff-yy	line 04 col 33 pic 9999 using fee-date-yy auto.
    05  scr-eff-slash-1 line 04 col 37 value "/".
    05  scr-eff-mm	line 04 col 38 pic 99   using fee-date-mm auto.
    05  scr-eff-slash-2 line 04 col 40 value "/".
    05  scr-eff-dd	line 04 col 41 pic 99   using fee-date-dd auto.
    05  scr-active-flag	line 04 col 80 pic x    using fee-active-for-entry.
    05  scr-exclude-global-addon
			line 05 col 80 pic x    using fee-global-addon-cd-exclusion.
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
01  scr-other-info. 
*   05  scr-curr-page   line 14 col 06 pic 999 using fee-curr-page auto. 
    05  scr-curr-page-alpha
			line 14 col 06 pic xx using fee-curr-page-alpha auto. 
    05  scr-curr-page-numeric
			line 14 col 09 pic 999 using fee-curr-page-numeric auto. 
    05  scr-m-suffix	line 14 col 39 pic x using fee-special-m-suffix-ind auto. 
    05  scr-diag	line 14 col 53 pic x using fee-diag-ind auto. 
    05  scr-ref-phys	line 14 col 70 pic x using fee-phy-ind auto. 
    05  scr-hosp-nbr	line 16 col 14 pic x using fee-hosp-nbr-ind auto. 
    05  scr-in-out	line 16 col 24 pic x using fee-i-o-ind auto. 
    05  scr-admit-dt	line 16 col 36 pic x using fee-admit-ind auto. 
* 
01  scr-rate-info. 
* 
*   ohip current 
*   ------------ 
*   05  scr-curr-h-1  	line 09 col 01 pic z(4)9.99 using fee-curr-h-fee-1. 
    05  scr-curr-h-1  	line 09 col 01 pic z(3)9.999 using fee-curr-h-fee-1. 

*   05  scr-curr-h-oth	line 09 col 12 pic z(4)9.99 using fee-curr-h-fee-1. 
    05  scr-curr-h-oth  line 09 col 12 pic z(3)9.999 using fee-curr-h-fee-1. 

*   	(redefine previous line to display fee-2)
*   05  scr-curr-h-2 	line 09 col 12 pic z(4)9.99 using fee-curr-h-fee-2. 
    05  scr-curr-h-2    line 09 col 12 pic z(3)9.999 using fee-curr-h-fee-2. 

    05  scr-curr-h-anae	line 09 col 23 pic z9 using fee-curr-h-anae auto. 
    05  scr-curr-h-asst line 09 col 27 pic z9 using fee-curr-h-asst auto. 
    05  scr-curr-h-min	line 09 col 29 pic z(3)9.999 using fee-curr-h-min.
* 
*   oma current 
*   ----------- 
    05  scr-curr-h-max	line 09 col 42 pic z(3)9.999 using fee-curr-h-max.
*   05  scr-curr-a-1  	line 09 col 51 pic z(4)9.99 using fee-curr-a-fee-1. 
    05  scr-curr-a-1	line 09 col 51 pic z(3)9.999 using fee-curr-a-fee-1. 

*   05  scr-curr-a-oth	line 09 col 62 pic z(4)9.99 using fee-curr-a-fee-1. 
    05  scr-curr-a-oth  line 09 col 62 pic z(3)9.999 using fee-curr-a-fee-1. 

*   (redefine previous line to display fee-2)
*   05  scr-curr-a-2   line 09 col 62 pic z(4)9.99 using fee-curr-a-fee-2. 
    05  scr-curr-a-2   line 09 col 62 pic z(3)9.999 using fee-curr-a-fee-2. 

    05  scr-curr-a-anae line 09 col 73 pic z9 using fee-curr-a-anae auto. 
    05  scr-curr-a-asst line 09 col 78 pic z9 using fee-curr-a-asst auto. 
* 
*       previous values 
* 
*   ohip previous 
*   ------------- 
*   05  scr-a-prev-h-1    line 10 col 01 pic z(4)9.99 using fee-prev-h-fee-1. 
    05  scr-a-prev-h-1    line 10 col 01 pic z(3)9.999 using fee-prev-h-fee-1. 
*   05  scr-a-prev-h-oth  line 10 col 12 pic z(4)9.99 using fee-prev-h-fee-1. 
    05  scr-a-prev-h-oth  line 10 col 12 pic z(3)9.999 using fee-prev-h-fee-1. 
*   05  scr-a-prev-h-2	  line 10 col 12 pic z(4)9.99 using fee-prev-h-fee-2. 
    05  scr-a-prev-h-2	  line 10 col 12 pic z(3)9.999 using fee-prev-h-fee-2. 
    05  scr-a-prev-h-anae line 10 col 23 pic z9 using fee-prev-h-anae. 
    05  scr-a-prev-h-asst line 10 col 27 pic z9 using fee-prev-h-asst. 
    05  scr-prev-h-min	  line 10 col 29 pic z(3)9.999 using fee-prev-h-min.
* 
*   oma previous 
*   ------------ 
    05  scr-prev-h-max	  line 10 col 42 pic z(3)9.999 using fee-prev-h-max.
*   05	scr-a-prev-a-1	  line 10 col 51 pic z(4)9.99 using fee-prev-a-fee-1. 
    05	scr-a-prev-a-1	  line 10 col 51 pic z(3)9.999 using fee-prev-a-fee-1. 
*   05  scr-a-prev-a-oth  line 10 col 62 pic z(4)9.99 using fee-prev-a-fee-1. 
    05  scr-a-prev-a-oth  line 10 col 62 pic z(3)9.999 using fee-prev-a-fee-1. 
*   05  scr-a-prev-a-2	  line 10 col 62 pic z(4)9.99 using fee-prev-a-fee-2. 
    05  scr-a-prev-a-2	  line 10 col 62 pic z(3)9.999 using fee-prev-a-fee-2. 
    05  scr-a-prev-a-anae line 10 col 73 pic z9 using fee-prev-a-anae. 
    05  scr-a-prev-a-asst line 10 col 78 pic z9 using fee-prev-a-asst. 
01  scr-other-contd. 
    05  scr-curr-perc-flat line 22 col 29 pic x using fee-curr-add-on-perc-flat-ind auto. 
    05  scr-from 	   line 22 col 45 pic z9 using fee-spec-fr auto. 
    05  scr-to		   line 22 col 51 pic z9 using fee-spec-to auto. 
01  scr-prev-misc. 
    05  scr-prev-perc-flat line 22 col 31 pic x using fee-prev-add-on-perc-flat-ind auto. 
 
*   05  scr-prev-page line 14 col 10 pic 999 using fee-prev-page auto. 
    05  scr-prev-page-alpha
	    	      line 14 col 13 pic xx using fee-prev-page-alpha auto. 
    05  scr-prev-page-numeric
	    	      line 14 col 16 pic 999 using fee-prev-page-numeric auto. 
 
01  scr-add-on. 
    05  scr-add-on-cd line lnum col cnum pic x999 using fee-add-on-cd(pc-year,cntr) auto. 
 
01  scr-suffixes. 
     05  scr-suffix   line lnum col cnum pic x using fee-oma-ind-card-required(pc-year,cntr) auto. 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(55)	from err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-rate-lines. 
    05  line 09 col 01  blank line. 
*    05  line 09 col 32  value ".... CURRENT ....". 
    05  line 09 col 38 value "CURR" blink. 
    05  line 10 col 01  blank line. 
*    05  line 10 col 32  value ".... PREVIOUS ...". 
    05  line 10 col 38  value "PREV" blink . 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 

01  scr-clear-option.
    05  line 23 col 50  value "                            ". 
01  scr-verify-add-change. 
    05  line 23 col 50	value "ACCEPT(Y/N/M): ". 
    05  line 23 col 65	pic x	to acc-mod-rej. 
 
01  scr-password-prompt. 
    05			line 24 col 66 value is "PASSWORD". 
    05  scr-password	line 24 col 75 pic x(5)	using ws-entered-password secure auto. 
 
01  scr-verify-del.          
    05  line 23 col 50 value "DELETE (Y/N): ". 
    05  line 23 col 64 pic x   to acc-mod-rej.    

01  scr-verify-continue.          
    05  line 23 col 50 value "Hit ENTER to Continue". 
    05  line 23 col 73 pic x   to acc-mod-rej.      
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS REJECTED" bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 05 col 20  value "NUMBER OF FEE-MSTR READS:".   
    05  line 05 col 60  pic z(6)9 from ctr-fee-mstr-reads. 
    05  line 06 col 20  value "NUMBER OF FEE-MSTR WRITES:".     
    05  line 06 col 60  pic z(6)9 from ctr-fee-mstr-writes. 
    05  line 08 col 20  value "NUMBER OF CODES ADDED  :". 
    05  line 08 col 60  pic z(6)9 from ctr-fee-mstr-adds. 
    05  line 10 col 20  value "                CHANGED:". 
    05  line 10 col 60  pic z(6)9 from ctr-fee-mstr-changes. 
    05  line 12 col 20  value "                DELETED:". 
    05  line 12 col 60  pic z(6)9 from ctr-fee-mstr-deletes.                  
    05  line 20 col 20	value "PROGRAM M040 ENDING". 
* (y2k - auto fix)
*   05  line 20 col 40  pic xx/xx/xx from sys-date-long. 
    05  line 20 col 40  pic xxxx/xx/xx from sys-date-long. 
    05  line 20 col 50	pic 99	from sys-hrs. 
    05  line 20 col 52	value ":". 
    05  line 20 col 53	pic 99	from sys-min.        
    05  line 22 col 20	pic x(40) using audit-report-msg.              
procedure division. 
declaratives. 
 
err-oma-mstr-file section. 
    use after standard error procedure on oma-fee-mstr.       
err-oma-fee-mstr. 
*mf    move status-oma-mstr		to status-file. 
    move status-cobol-oma-mstr		to status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING OMA FEE MASTER". 
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
 
 
 
*	delete audit-file 
*    expunge audit-file. 
 
    open i-o	oma-fee-mstr. 
    open output audit-file. 
 
** move commented statements to ab0-processing. 
** sept/87 c.e. 
** 
**  display scr-titles. 
**  display scr-general-title. 
**  move "GEN"				to	display-type. 
**  display scr-option. 
**  move spaces				to	fee-mstr-rec. 
** 
**aa0-100-entry-type. 
** 
**  accept scr-option-sel. 
**  if add-code 
**  then 
**	display scr-option-add 
**  else 
**	if change-code 
**	then 
**	    display scr-option-chg 
**	else 
**	    if delete-code 
**  	    then 
**		display scr-option-del 
**	    else 
**		if inquire-code 
**	 	then 
**		    display scr-option-inq 
**		else 
**		    move 1			to	err-ind 
**		    perform za0-common-error	thru	za0-99-exit 
**		    go to aa0-100-entry-type. 
**		endif 
**	    endif 
**	endif 
**   endif 
** 
**  display scr-code. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    display blank-screen. 
    display scr-closing-screen. 
    display confirm. 
 
    close oma-fee-mstr 
	  audit-file. 
 
    call program "menu". 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    display scr-titles. 
    display scr-general-title. 
    move "GEN"				to	display-type. 
    move space				to      entry-type. 
    display scr-option. 
    move spaces				to	fee-mstr-rec. 
 
** aa0-100-entry-type. 
 
    accept scr-option-sel. 
    display scr-option-lit-title.
    if add-code 
    then 
	display scr-option-add 
    else 
	if change-code 
	then 
	    display scr-option-chg 
	else 
	    if delete-code 
	    then 
		display scr-option-del 
	    else 
		if inquire-code 
	 	then 
		    display scr-option-inq 
		else 
		    if terminate-code 
		    then 
			go to ab0-99-exit 
		    else 
			move 1			to	err-ind 
		    	perform za0-common-error	thru	za0-99-exit 
**			go to aa0-100-entry-type. 
			go to ab0-processing. 
*		    endif 
*		endif 
*	    endif 
*	endif 
*    endif 
 
    display scr-code. 
 
ab0-150-acpt-code-display-info. 
 
    move spaces				to	fee-mstr-rec. 
 
    accept scr-code-nbr. 
 
** commented statements and replaced 
** sept/87 c.e. 
** 
**  if fee-oma-cd = "****" 
    if fee-oma-cd-ltr1 = "*" 
    then 
**	go to ab0-99-exit. 
	go to ab0-processing. 
*   (else) 
*   endif 
 
    perform ba0-read-fee-mstr			thru	ba0-99-exit. 
    if not-ok 
    then 
**	go to ab0-processing. 
	go to ab0-150-acpt-code-display-info. 
*   (else) 
*   endif 
 
    display scr-icc-desc-tech. 
    perform fa0-display-rates		thru	fa0-99-exit. 
    display scr-other-info. 
    perform ga0-display-add-ons		thru 	ga0-99-exit 
	varying pc-year from 1 by 1 until pc-year > 2. 
    perform ia0-display-suffixes	thru 	ia0-99-exit 
	varying pc-year from 1 by 1 until pc-year > 2. 
    display scr-other-contd. 
    display scr-prev-misc.
 
ab0-200-modify. 
 
    if 	  add-code                   
       or change-code 
    then 
	perform da0-enter-icc-code		thru	da0-99-exit    
	perform fa0-display-rates		thru	fa0-99-exit. 
*   (else) 
*   endif 
 
    if    add-code 
       or change-code 
    then 
	perform ha0-add-change-rates		thru	ha0-99-exit 
	perform ja0-add-change-other-info	thru	ja0-99-exit  
    	move 19 				to lnum 
	move 1 					to pc-year 
  	move 'U'				to flag-mode 
	perform ga1-i-o-add-ons     		thru ga1-99-exit 
	    varying cnum from 1 by 5 until cnum > 46 
	perform ia1-i-o-suffixes  		thru ia1-99-exit 
	    varying cnum from 71 by 4 until cnum > 79 
	perform ka0-add-change-contd-info	thru ka0-99-exit. 
*   (else) 
*   endif 
 
ab0-300-verify. 
 
    if    add-code 
       or change-code 
    then 
	display scr-verify-add-change 
	accept  scr-verify-add-change 
    else 
	if delete-code 
	then 
	    display scr-verify-del 
	    accept  scr-verify-del 
	else
	    if inquire-code
	    then
		display scr-verify-continue 
		accept  scr-verify-continue
		go to ab0-400-next.
*	    endif
*	endif 
*   endif
 
    if accept-screen 
    then 
	next sentence 
    else 
	if reject-screen 
	then 
	    display scr-reject-entry 
	    display confirm 
	    stop " " 
	    display blank-line-24 
	    go to ab0-400-next 
	else 
	    if      modify-screen       
	      and (add-code or change-code) 
	    then 
	 	go to ab0-200-modify 
	    else 
		if     prev-yr-modify 
		  and (add-code or change-code) 
	 	then 
		    move spaces			to	acc-mod-rej 
		    display scr-verify-add-change 
		    perform sa0-password	thru	sa0-99-exit 
		    if password-ok 
		    then 
			perform ta0-prev-yr-modify thru	ta0-99-exit 
			accept scr-prev-page-alpha
			accept scr-prev-page-numeric
			move 20				to lnum 
			move 'U' 			to flag-mode 
			move 2				to pc-year 
			perform ga1-i-o-add-ons		thru ga1-99-exit 
			    varying cnum from 1 by 5 until cnum > 46 
			perform ia1-i-o-suffixes	thru ia1-99-exit 
			    varying cnum from 71 by 4 until cnum > 79 
			accept scr-prev-perc-flat 
			go to ab0-300-verify 
		    else 
			move 18			to	err-ind 
		 	perform za0-common-error thru	za0-99-exit 
			go to ab0-300-verify 
*		    endif 
		else 
		    move 1			to	err-ind 
		    perform za0-common-error	thru	za0-99-exit 
		    go to ab0-300-verify. 
*		endif 
*	    endif 
*	endif 
*   endif 
 
 
    display blank-line-24. 
    if add-code 
    then 
	perform la0-write-new-rec		thru	la0-99-exit 
    else 
	if change-code 
	then 
	    perform na0-re-write-rec		thru	na0-99-exit 
	else 
	    if delete-code 
	    then 
		perform pa0-delete-rec		thru	pa0-99-exit 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 
 
    if not inquire-code 
    then 
        perform ra0-print-audit			thru	ra0-99-exit. 
*   (else) 
*   endif 
 
ab0-400-next. 
    display scr-clear-option.
 
**  go to ab0-processing. 
    go to ab0-150-acpt-code-display-info. 
 
ab0-99-exit. 
    exit. 
 
ba0-read-fee-mstr. 
 
    move "Y"				to	read-flag    
            				  	status-flag. 
    read oma-fee-mstr 
     	invalid key 
	    move "N"			to	read-flag.   
 
    if not-on-file 
    then 
	if add-code 
	then 
	    go to ba0-99-exit 
	else 
	    move "N"			to	status-flag 
	    move 8			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ba0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
    add 1				to	ctr-fee-mstr-reads. 
    if add-code 
    then 
	move "N"			to	status-flag 
	move 2				to	err-ind 
	perform za0-common-error	thru	za0-99-exit. 
*   (else) 
*   endif 
 
ba0-99-exit. 
    exit. 
 
da0-enter-icc-code. 
 
    accept scr-icc-code. 
    if fee-icc-sec =  "CP" 
	  	   or "CV" 
		   or "DR" 
		   or "DT" 
		   or "DU" 
		   or "NM" 
		   or "PF" 
		   or "SP"	 
    then 
	next sentence 
    else 
	move 9				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to da0-enter-icc-code. 
*   endif 
 
    if     (fee-icc-cat is numeric and fee-icc-cat not = space) 
       and (fee-icc-grp is numeric and fee-icc-grp not = space) 
       and (fee-icc-reduc-ind is numeric and fee-icc-reduc-ind not = space) 
    then 
	next sentence 
    else 
	move 22				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to da0-enter-icc-code. 
*   endif 
 
    accept scr-desc. 
 
da0-10-enter-tech. 
 
    accept scr-tech-ind. 
    if fee-tech-ind not = 'Y' and 
       fee-tech-ind not = 'N' 
    then 
	move 20				to err-ind 
  	perform za0-common-error	thru za0-99-exit 
	go to da0-10-enter-tech. 
*   endif 

da0-20-enter-eff-date.
    accept scr-eff-yy.
    accept scr-eff-mm.
    accept scr-eff-dd.

da0-30-enter-active-flag.
    accept scr-active-flag.
    if     fee-active-for-entry not = 'Y'
       and fee-active-for-entry not = 'N' 
    then 
	move 20				to err-ind 
  	perform za0-common-error	thru za0-99-exit 
	go to da0-30-enter-active-flag.
*   endif

da0-40-enter-global-exclusion.
    accept scr-exclude-global-addon.
    if     fee-global-addon-cd-exclusion not = 'Y'
       and fee-global-addon-cd-exclusion not = 'N' 
    then 
	move 20				to err-ind 
  	perform za0-common-error	thru za0-99-exit 
	go to da0-40-enter-global-exclusion.
*    endif

 
da0-99-exit. 
    exit. 
 
 
 
fa0-display-rates.      
 
*  icc codes   		titles  	contents	screen name 
*  ---------   		------  	--------	----------- 
*     cp		general		not applicable	not applicable   
*			special		fee-1		scr-curr-?-oth 
*			anae		anae   		scr-curr-?-anae 
*			asst		not applicable  not applicable 
*  ---------  		------  	--------	----------- 
*     cv		general		not applicable	not applicable 
*			special		fee-1         	scr-curr-?-oth 
*			anae		not applicable 	not applicable 
*			asst		not applicable 	not applicable 
*  ---------  		------  	-------- 	----------- 
*     dr &		technical	fee-1      	scr-curr-?-1 
*     du &		profess.	fee-2  		scr-curr-?-2 
*     nm &		anae		not applicable	not applicable 
*     pf                asst		not applicable 	not applicable 
*  ---------  		------  	--------    	----------- 
*     dt		general		not applicable 	not applicable 
*       		special		fee-1 & fee-2  	scr-curr-?-oth 
*			anae		anae          	scr-curr-?-anae 
*			asst		not applicable 	not applicable 
*  ---------  		------  	--------  	----------- 
*     sp &		general		not applicable  not applicable 
*     flat rate/perc	special		fee-1 & fee-2  	scr-curr-?-oth 
*     ind not = b	anae		anae 		scr-curr-?-anae 
*			asst		asst  		scr-curr-?-asst 
*  ---------  		------  	--------  	----------- 
*     sp &		general		fee-1           scr-curr-?-1    
*     flat rate/perc	special		fee-2          	scr-curr-?-2    
*     ind = b     	anae		anae 		scr-curr-?-anae 
*			asst		asst  		scr-curr-?-asst 
*                                           
 
    if fee-icc-sec =  "DR" 
  		   or "DU" 
		   or "NM" 
		   or "PF" 
    then 
	if tec-title 
	then 
	    next sentence 
	else 
	    display scr-technical-title 
	    move "TEC"				to	display-type                       
    else 
	if gen-title 
	then 
	    next sentence 
	else 
	    display scr-general-title 
	    move "GEN"				to	display-type. 
*	endif 
*   endif 
 
    display blank-rate-lines. 
    if fee-icc-sec = "CP" 
    then 
	display	scr-curr-h-oth 
		scr-curr-h-anae 
		scr-curr-a-oth 
		scr-curr-a-anae 
		scr-curr-h-min
		scr-curr-h-max
		scr-prev-h-min
		scr-prev-h-max
	        scr-a-prev-h-oth 
		scr-a-prev-h-anae 
		scr-a-prev-a-oth 
		scr-a-prev-a-anae 
		go to fa0-99-exit. 
*   (else) 
*   endif 
 
    if fee-icc-sec = "CV" 
    then 
	display scr-curr-h-oth 
		scr-curr-a-oth 
		scr-a-prev-h-oth 
		scr-a-prev-a-oth 
		scr-curr-h-min
		scr-prev-h-min
		scr-curr-h-max
		scr-prev-h-max
	go to fa0-99-exit. 
 
    if fee-icc-sec =  "DR"	 
                   or "DU" 
                   or "NM" 
                   or "PF" 
    then 
	display scr-curr-h-1 
		scr-curr-h-2 
		scr-curr-a-1 
		scr-curr-a-2 
		scr-curr-h-min
		scr-prev-h-min
		scr-curr-h-max
		scr-prev-h-max
		scr-a-prev-h-1 
		scr-a-prev-h-2 
		scr-a-prev-a-1 
		scr-a-prev-a-2 
	go to fa0-99-exit. 
*   (else) 
*   endif 
 
    if fee-icc-sec = "DT" 
    then 
	display scr-curr-h-oth 
		scr-curr-h-anae 
		scr-curr-a-oth 
		scr-curr-a-anae 
		scr-curr-h-min
		scr-prev-h-min
		scr-curr-h-max
		scr-prev-h-max
		scr-a-prev-h-oth 
		scr-a-prev-h-anae 
		scr-a-prev-a-oth 
		scr-a-prev-a-anae 
	go to fa0-99-exit. 
*   (else) 
*   endif 
 
*   fee-icc-sec = "SP" 
 
    if fee-curr-add-on-perc-flat-ind = "B" 
    then 
	display scr-curr-h-1 
		scr-curr-h-2 
		scr-curr-a-1 
		scr-curr-h-min
		scr-prev-h-min
		scr-curr-h-max
		scr-prev-h-max
		scr-curr-a-2 
		scr-a-prev-h-1 
		scr-a-prev-h-2 
		scr-a-prev-a-1 
		scr-a-prev-a-2 
    else 
	display	scr-curr-h-oth 
		scr-curr-a-oth 
		scr-curr-h-min
		scr-prev-h-min
		scr-curr-h-max
		scr-prev-h-max
		scr-a-prev-h-oth 
		scr-a-prev-a-oth. 
*   endif 
 
    display	scr-curr-h-anae 
    display       	scr-curr-h-asst 
  		display scr-curr-a-anae         
display		scr-curr-a-asst 
	display	scr-curr-h-min
	display	scr-curr-h-max
	display	scr-prev-h-min
display		scr-prev-h-max
display		scr-a-prev-h-anae 
display		scr-a-prev-h-asst 
display		scr-a-prev-a-anae 
display		scr-a-prev-a-asst. 
 
fa0-99-exit. 
    exit. 
 
 
ga0-display-add-ons. 
 
    move 'D'				to flag-mode. 
 
    if pc-year = 1	 
    then 
	move 19				to lnum 
    else 
	move 20				to lnum. 
*   endif 
 
    perform ga1-i-o-add-ons		thru ga1-99-exit 
	varying cnum from 1 by 5 until cnum > 46. 
 
ga0-99-exit. 
 
    exit. 
 
ga1-i-o-add-ons. 
 
    add 4,cnum giving cntr. 
    divide 5 into cntr. 
 
    if display-mode 
    then 
	display scr-add-on-cd 
    else 
        if update-mode 
	then 
	    display scr-add-on-cd 
	    accept scr-add-on-cd 
	    if fee-add-on-cd(pc-year,cntr) = spaces 
	    then 
		move 50 to cnum. 
*	    endif
*	endif
*   endif 
 
ga1-99-exit. 
 
    exit. 
ha0-add-change-rates. 
 
*   re-display of fields entered is required so that current & previous 
*   fields remain lined up. 
 
    if add-code 
    then 
	move 0				to	fee-prev-h-fee-1 
						fee-prev-h-fee-2 
						fee-prev-h-anae 
						fee-prev-h-asst 
						fee-prev-h-min
						fee-prev-h-max
						fee-prev-a-fee-1     
						fee-prev-a-fee-2 
						fee-prev-a-anae 
						fee-prev-a-asst. 
*   (else) 
*   endif 
 
    if fee-icc-sec = "CP" 
    then 
	accept	scr-curr-h-oth 
	display scr-curr-h-oth 
	accept	scr-curr-h-anae 
	display scr-curr-h-anae 
	move 0				to	fee-curr-h-fee-2 
						fee-curr-h-asst 
						fee-curr-a-fee-2 
						fee-curr-a-asst         
	move fee-curr-h-fee-1		to	fee-curr-a-fee-1 
	move fee-curr-h-anae		to	fee-curr-a-anae 
	display scr-curr-a-oth 
	display scr-curr-a-anae 

	display scr-curr-h-min
	accept  scr-curr-h-min
	display scr-prev-h-min
	accept  scr-prev-h-min

	display scr-curr-h-max
	accept  scr-curr-h-max
	display scr-prev-h-max
	accept  scr-prev-h-max

	if    fee-curr-h-fee-1 = 0 
	   or fee-curr-h-anae  = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ha0-99-exit           
	else 
	    go to ha0-99-exit. 
*       endif 
*   (else) 
*   endif 
 
ha0-10-add-change-cv. 
 
    if fee-icc-sec = "CV" 
    then 
	accept 	scr-curr-h-oth 
	display scr-curr-h-oth 
	move 0				to	fee-curr-h-fee-2 
						fee-curr-h-anae       
						fee-curr-h-asst 
						fee-curr-a-fee-2 
						fee-curr-a-anae 
						fee-curr-a-asst  
	move fee-curr-h-fee-1		to	fee-curr-a-fee-1 
	display scr-curr-a-oth 

	display scr-curr-h-min
	accept  scr-curr-h-min
	display scr-prev-h-min
	accept  scr-prev-h-min

	display scr-curr-h-max
	accept  scr-curr-h-max
	display scr-prev-h-max
	accept  scr-prev-h-max

	if    fee-curr-h-fee-1 = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ha0-99-exit   
	else 
	    go to ha0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ha0-20-add-change-dr-etc. 
 
    if    fee-icc-sec =  "DR" 
                      or "DU" 
                      or "NM" 
                      or "PF" 
    then 
	accept  scr-curr-h-1 
	display scr-curr-h-1 
	accept	scr-curr-h-2 
	display scr-curr-h-2 
	move 0				to	fee-curr-h-anae 
						fee-curr-h-asst 
						fee-curr-a-anae 
						fee-curr-a-asst  
	move fee-curr-h-fee-1		to	fee-curr-a-fee-1 
	move fee-curr-h-fee-2		to	fee-curr-a-fee-2 
	display scr-curr-a-1 
	display scr-curr-a-2 

	display scr-curr-h-min
	accept  scr-curr-h-min
	display scr-prev-h-min
	accept  scr-prev-h-min

	display scr-curr-h-max
	accept  scr-curr-h-max
	display scr-prev-h-max
	accept  scr-prev-h-max

	if    fee-curr-h-fee-1 = 0 
	   or fee-curr-h-fee-2 = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ha0-99-exit                   
	else 
	    go to ha0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ha0-30-add-change-dt. 
 
    if fee-icc-sec = "DT" 
    then 
	accept	scr-curr-h-oth   
	display scr-curr-h-oth 
	accept	scr-curr-h-anae    
	display scr-curr-h-anae 
	move fee-curr-h-fee-1		to	fee-curr-h-fee-2 
						fee-curr-a-fee-1 
						fee-curr-a-fee-2 
	move fee-curr-h-anae		to	fee-curr-a-anae 
	move 0				to	fee-curr-h-asst    
						fee-curr-a-asst   
	display scr-curr-a-oth 
	display scr-curr-a-anae 

	display scr-curr-h-min
	accept  scr-curr-h-min
	display scr-prev-h-min
	accept  scr-prev-h-min

	display scr-curr-h-max
	accept  scr-curr-h-max
	display scr-prev-h-max
	accept  scr-prev-h-max

	if    fee-curr-h-fee-1 = 0 
	   or fee-curr-h-anae  = 0     
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ha0-99-exit      
	else 
	    go to ha0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ha0-40-add-change-sp. 
 
    if fee-curr-add-on-perc-flat-ind = "B" 
    then 
	accept  scr-curr-h-1 
	display scr-curr-h-1 
	accept  scr-curr-h-2 
	display scr-curr-h-2 
    else 
	accept  scr-curr-h-oth 
	display scr-curr-h-oth. 
*   endif 
 
    accept  scr-curr-h-anae. 
    display scr-curr-h-anae. 
    accept  scr-curr-h-asst. 
    display scr-curr-h-asst. 
 
    if fee-curr-add-on-perc-flat-ind not = "B" 
    then 
	move fee-curr-h-fee-1		to	fee-curr-h-fee-2. 
*   (else) 
*   endif 
 
    move fee-curr-h-fee-1		to	fee-curr-a-fee-1. 
    move fee-curr-h-fee-2		to	fee-curr-a-fee-2. 
    move fee-curr-h-anae		to	fee-curr-a-anae.    
    move fee-curr-h-asst		to	fee-curr-a-asst. 
 
    if fee-curr-add-on-perc-flat-ind = "B" 
    then 
	display scr-curr-a-1 
	display scr-curr-a-2 
    else 
	display scr-curr-a-oth. 
*   endif 
 
    display scr-curr-a-asst. 
    display scr-curr-a-anae. 
 
    display scr-curr-h-min.
    accept  scr-curr-h-min.
    display scr-prev-h-min.
    accept  scr-prev-h-min.

    display scr-curr-h-max.
    accept  scr-curr-h-max.
    display scr-prev-h-max.
    accept  scr-prev-h-max.

    if        fee-curr-h-fee-1 = zero 
      or      fee-curr-h-anae  = zero 
      or      fee-curr-h-asst  = zero 
      or (    fee-curr-h-fee-2 = zero 
	  and fee-curr-add-on-perc-flat-ind = "B") 
    then 
    	move 6				to	err-ind 
	perform za0-common-error 	thru	za0-99-exit. 
*   (else) 
*   endif 
 
ha0-99-exit. 
    exit. 
 
ia0-display-suffixes. 
 
    move 'D'				to flag-mode. 
 
    if pc-year = 1 
    then 
	move 19				to lnum 
    else 
	move 20 			to lnum. 
*   endif 
 
    perform ia1-i-o-suffixes		thru ia1-99-exit 
        varying cnum from 71 by 4 until cnum > 79. 
 
ia0-99-exit. 
 
    exit. 
 
ia1-i-o-suffixes. 
 
    subtract 67 from cnum giving cntr. 
    divide 4 into cntr. 
 
    if display-mode 
    then 
	display scr-suffix 
    else 
	if update-mode 
	then 
	    display scr-suffix 
  	    accept scr-suffix 
	    if fee-oma-ind-card-required(pc-year,cntr) = spaces 
 	    then 
		move 80 to cnum 
	    else 
		if fee-oma-ind-card-required(pc-year,cntr) not = 'Y' and 
	 				                   not = 'N' and 
					                   not = 'R' 
		then 
		    move 21			to err-ind 
		    perform za0-common-error	thru za0-99-exit 
		    go to ia1-i-o-suffixes. 
*   endif 
 
ia1-99-exit. 
 
    exit. 
ja0-add-change-other-info. 
 
ja0-05-page. 

    accept scr-curr-page-alpha. 
    accept scr-curr-page-numeric. 
    if     fee-curr-page-numeric > 0 
       and fee-curr-page-numeric < 200 
    then 
	next sentence 
    else 
	move 4				to	err-ind       
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-05-page. 
*   (else) 
*   endif 
 
ja0-10-m-suffix. 
 
    accept scr-m-suffix. 
    if fee-special-m-suffix-ind =  "Y" 
                                or "N" 
    then 
	next sentence 
    else 
	move 5				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-10-m-suffix. 
*   endif 
 
ja0-15-diag. 
 
    accept scr-diag. 
    if fee-diag-ind =  "Y" 
                    or "N" 
    then 
	next sentence 
    else 
	move 10				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-15-diag. 
*   endif 
 
ja0-20-ref-phys. 
 
    accept scr-ref-phys. 
    if fee-phy-ind =  "Y" 
                   or "N" 
    then 
	next sentence 
    else 
	move 11				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-20-ref-phys. 
*   endif 
 
ja0-25-hosp-nbr. 
 
    accept scr-hosp-nbr. 
    if fee-hosp-nbr-ind =  "Y" 
                        or "N" 
    then 
	next sentence 
    else 
	move 12				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-25-hosp-nbr. 
*   endif 
 
ja0-30-in-out. 
 
    accept scr-in-out. 
    if fee-i-o-ind =  "B" 
                   or "I" 
                   or "O" 
    then 
	next sentence 
    else 
	move 13				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-30-in-out. 
*   endif 
 
 
ja0-35-admit-dt. 
 
    accept scr-admit-dt. 
    if fee-admit-ind =  "Y" 
                     or "N" 
    then 
	next sentence 
    else 
	move 14				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to ja0-35-admit-dt. 
*   endif 
 
ja0-99-exit. 
 
    exit. 
ka0-add-change-contd-info. 
 
    if add-code 
    then 
	move spaces				to	fee-curr-add-on-perc-flat-ind.  
*   (else) 
*   endif 
 
    move fee-curr-add-on-perc-flat-ind		to	ws-hold-perc-or-flat-ind. 
 
ka0-50-perc-flat. 
 
*    if      fee-icc-sec = "SP" 
*       and (fee-icc-grp =  98    
*	                or 99) 
*    then 

*       (00/aug/.08 B.E.
*        allow any code to be add on code)
	accept scr-curr-perc-flat 
	if fee-curr-add-on-perc-flat-ind =    " "
					   or "F" 
                                           or "P" 
				           or "B" 
	then 
	    next sentence 
	else 
	    move 17				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to ka0-50-perc-flat. 


**	endif 
**   endif 
 
ka0-60-both-perc-and-flat. 
 
    if    fee-curr-add-on-perc-flat-ind = "B" 
      and fee-curr-add-on-perc-flat-ind not = ws-hold-perc-or-flat-ind 
    then 
	display	scr-curr-h-1 
		scr-curr-h-2  
		scr-curr-a-1 
		scr-curr-a-2 
		scr-a-prev-h-1 
		scr-a-prev-h-2   
		scr-a-prev-a-1     
		scr-a-prev-a-2 
		accept  scr-curr-h-1 
		display scr-curr-h-1   
		move fee-curr-h-fee-1		to fee-curr-a-fee-1 
		accept  scr-curr-h-2 
		display scr-curr-h-2 
		move fee-curr-h-fee-2		to fee-curr-a-fee-2 
		display	scr-curr-a-1 
		display scr-curr-a-2 
	if   fee-curr-h-fee-1 > 1.01 
	  or fee-curr-h-fee-2 < 1.00 
	then   
	    move 19			to 	err-ind 
	    perform za0-common-error	thru 	za0-99-exit 
	    go to ka0-60-both-perc-and-flat. 
*	(else) 
*	endif 
*   (else) 
*   endif 
 
    accept scr-from. 
    accept scr-to. 
 
ka0-99-exit. 
    exit. 
 
la0-write-new-rec. 
 
    write fee-mstr-rec 
  	invalid key 
	    perform err-oma-fee-mstr. 
 
    add 1				to	ctr-fee-mstr-writes 
						ctr-fee-mstr-adds. 
 
la0-99-exit. 
    exit. 
 
 
 
na0-re-write-rec. 
 
    rewrite fee-mstr-rec. 
 
    add 1				to	ctr-fee-mstr-writes 
						ctr-fee-mstr-changes. 
 
na0-99-exit. 
    exit. 
 
 
 
pa0-delete-rec. 
 
*mf delete oma-fee-mstr record physical. 
    delete oma-fee-mstr record. 
 
    add 1				to	ctr-fee-mstr-deletes. 
 
pa0-99-exit. 
    exit. 
 
 
 
 
ra0-print-audit. 
 
    move entry-type			to	audit-type. 
    move fee-mstr-rec			to	audit-rec.     
    write audit-record. 
 
ra0-99-exit. 
    exit. 
sa0-password. 
 
    move "N"				to	password-flag. 
    move spaces				to	ws-entered-password. 
    display scr-password-prompt. 
    accept scr-password. 
    
    if ws-entered-password = ws-valid-password 
    then 
	move "Y"			to	password-flag. 
*   (else) 
*   endif 
 
sa0-99-exit. 
    exit. 
 
 
 
 
ta0-prev-yr-modify.     
    perform fa0-display-rates thru fa0-99-exit. 
 
    if fee-icc-sec = "CP" 
    then 
	accept	scr-a-prev-h-oth 
	display scr-a-prev-h-oth 
	accept	scr-a-prev-h-anae 
	display scr-a-prev-h-anae 
        move 0                          to      fee-prev-h-fee-2 
                                 		fee-prev-h-asst 
						fee-prev-a-fee-2 
						fee-prev-a-asst 
	move fee-prev-h-fee-1		to	fee-prev-a-fee-1 
	move fee-prev-h-anae		to	fee-prev-a-anae 
	display scr-a-prev-a-oth 
	display scr-a-prev-a-anae 
	if    fee-prev-h-fee-1 = 0 
	   or fee-prev-h-anae  = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ta0-99-exit           
	else 
	    go to ta0-99-exit. 
*       endif 
*   (else) 
*   endif 
 
ta0-10-add-change-cv. 
 
    if fee-icc-sec = "CV" 
    then 
	accept 	scr-a-prev-h-oth 
	display scr-a-prev-h-oth 
	move 0				to	fee-prev-h-fee-2 
						fee-prev-h-anae       
						fee-prev-h-asst 
						fee-prev-a-fee-2 
						fee-prev-a-anae 
						fee-prev-a-asst  
	move fee-prev-h-fee-1		to	fee-prev-a-fee-1 
	display scr-a-prev-a-oth 
	if    fee-prev-h-fee-1 = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ta0-99-exit  
	else     
	    go to ta0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ta0-20-add-change-dr-etc. 
 
    if    fee-icc-sec =  "DR" 
                      or "DU" 
                      or "NM" 
                      or "PF" 
    then 
	accept  scr-a-prev-h-1 
	display scr-a-prev-h-1 
	accept	scr-a-prev-h-2 
	display scr-a-prev-h-2 
	move 0				to	fee-prev-h-anae 
						fee-prev-h-asst 
						fee-prev-a-anae 
						fee-prev-a-asst  
	move fee-prev-h-fee-1		to	fee-prev-a-fee-1 
	move fee-prev-h-fee-2		to	fee-prev-a-fee-2 
	display scr-a-prev-a-1 
	display scr-a-prev-a-2 
	if    fee-prev-h-fee-1 = 0 
	   or fee-prev-h-fee-2 = 0 
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ta0-99-exit                   
	else 
	    go to ta0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ta0-30-add-change-dt. 
 
    if fee-icc-sec = "DT" 
    then 
	accept	scr-a-prev-h-oth   
	display scr-a-prev-h-oth 
	accept	scr-a-prev-h-anae    
	display scr-a-prev-h-anae 
	move fee-prev-h-fee-1		to	fee-prev-h-fee-2 
						fee-prev-a-fee-1 
						fee-prev-a-fee-2 
	move fee-prev-h-anae		to	fee-prev-a-anae 
	move 0				to	fee-prev-h-asst    
						fee-prev-a-asst   
	display scr-a-prev-a-oth 
	display scr-a-prev-a-anae 
	if    fee-prev-h-fee-1 = 0 
	   or fee-prev-h-anae  = 0     
	then 
	    move 6			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to ta0-99-exit  
	else 
	    go to ta0-99-exit. 
*	endif 
*   (else) 
*   endif 
 
ta0-40-add-change-sp. 
 
    if fee-curr-add-on-perc-flat-ind = "B" 
    then 
	accept  scr-a-prev-h-1 
	display scr-a-prev-h-1 
	accept  scr-a-prev-h-2 
  	display scr-a-prev-h-2 
    else 
	accept  scr-a-prev-h-oth 
	display scr-a-prev-h-oth 
	move fee-curr-h-fee-1		to	fee-curr-h-fee-2. 
*   endif 
 
    accept  scr-a-prev-h-anae. 
    display scr-a-prev-h-anae. 
    accept  scr-a-prev-h-asst. 
    display scr-a-prev-h-asst. 
 
    move fee-prev-h-fee-1		to	fee-prev-a-fee-1. 
    move fee-prev-h-fee-2		to	fee-prev-a-fee-2. 
    move fee-prev-h-anae		to	fee-prev-a-anae.    
    move fee-prev-h-asst		to	fee-prev-a-asst. 
    display scr-a-prev-a-oth. 
    display scr-a-prev-a-asst. 
    display scr-a-prev-a-anae. 
 
    if   fee-prev-h-fee-1 = zero 
      or fee-prev-h-fee-2 = zero 
      or fee-prev-h-anae  = zero 
      or fee-prev-h-asst  = zero 
    then 
    	move 6				to	err-ind 
	perform za0-common-error 	thru	za0-99-exit. 
*   (else) 
*   endif 
 
ta0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
 
    accept scr-confirm. 
 
*   display confirm. 
*   stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
zb0-dump-file-rec-cntrs. 
*     instructions. 
zb0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
