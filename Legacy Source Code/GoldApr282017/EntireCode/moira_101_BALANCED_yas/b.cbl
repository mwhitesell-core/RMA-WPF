identification division. 
program-id.    u701oscar. 
author.        dyad technologies. 
installation.  rma. 
date-written.  90/06/15. 
date-compiled. 
security. 
* 
* 
*  REMARKS:   - OHIP DISKETTE UPLOAD INTO SUSPENSE FILES 
*             - CREATE SUSPENSE HEADER, DETAIL, AND ADDRESS RECORDS 
*               FROM THE DISKETTES. VALIDATE EACH FIELD. 
* 
* 
*  REV 91/04/23 (M.C.)  - SMS  138 
*                       - SET 'CLMHDR-PAT-KEY-DATA' TO HEALTH-NBR IF 
*                         PRESENT;OTHERWISE, USE OHIP NBR. 
* 
*  REV 91/09/11 (B.M.L.) - CHANGED PROGRAM TO IGNORE BLANK OR ZERO OHIP 
*                          EDIT CHECKS NOW WORK ON HEALTH INSTEAD. 
* 
*  REV 91/09/18 (M.C.)  - INVALID DIGIT ON BATCH-SPECIALTY BECAUSE 
*                         MOVE '???' TO NUMERIC FIELD, CORRECTION MADE 
*                         ON PAGE 26 (FB0-BUILD-SUSP-HDR-REC) 
* 
*  REV 92/09/25 (M.C.)  - PDR 558 
*                       - SELECT ONLY THE ACTIVE DOCTOR, AND IF THE 
*                         DOCTOR HAS MORE THAN 1 ACTIVE NUMBER, USER 
*                         SHOULD ENTER THE NUMBER THEY WANT 
* 
*  REV 93/06/16 (A.G.K.) - MODIFY THE INPUT FILE DEFINITION FOR THE NEW 
*                          OHIP LAYOUT 
* 
*  REV 93/07/13 (M.C.)  - SMS 142 
*                       - MODIFY THE INPUT FILE TO THE SAME AS CURRENT 
*                         OHIP LAYOUT (79 CHARS) 
*                       - MODIFY THE NECESSARY CHANGES TO THE FILES 
*                       - EXTEND 12 CHARS IN F002-SUSPEND-ADDRESS FILE 
* 
*  REV 93/11/16 (M.C.)  - PDR 591 
*                       - MODIFY THE VALIDATION ON REFERRING DOC NBR 
* 
*  REV 96/07/30 (M.C.)  - PDR 649 
*                       - INCLUDE 'I' AND 'O' AS PART OF HDR-I-O-IND 
*                         WHEN EDITING 
*###  CHECK OUT SETTING OF DETAIL-WRITTEN 
*###  CHECK THAT FEE- VARIABLES ARE IN THE HOLD AREA 
*  REV 97/09/10 (B.E.)  - EDIT SERVICE DATE NOT LESS THAN ADMIT DATE 
*			  ENSURE THAT IF 'OP'/'MR' (OVERRIDE PRICE) IS SPECIFIED 
*			 OR INCOMING FEES ARE ALREADY PRICED THEN SKIP 
*			 RMA PRICING (INCLUDING ADD ONS) 
*  REV 97/10/01 (B.E.)  - ADD ABILITY TO PROCESS MULTIPLE CLINICS WITHIN 
*			  A SINGLE BATCH. 
*  REV 97/11/01 (B.E.)  - ADD USER SELECTION PARAMETER TO ALLOW 
*			  DEFAULTING OF CLINIC NBR IF NOT SPECIFIED 
*			  WITHIN THE BATCH 
* 
*  REV 97/11/11 (B.E.)  - CLINIC DEFAULT WAS 2215 WHICH THEN OVERRODE 
*			  WHAT WAS IN BATCH. CHANGE LOGIC TO USE USER 
*			  SELECTION CLINIC NBR ONLY IF INCOMING BATCH'S 
*			  CLINIC NBR IS ZERO OR BLANK. 
*  REV 97/11/14 (B.E.)  - PROGRAM LOGIC TAKEN FROM D001 ALLOWED ONLY 8 
*			  DETAIL RECORDS. 'OCCURS' CHANGED FROM 8 TO 40. 
*			  TO ALLOW WEB INPUT OF UP TO 40 LINES 
*			  (ARBRITRARY DECISION TO THIS NUMBER) 
*	97/12/10 (B.E.)	- BUG FIXED. LENGTH OF HOLD-OMA-REC CHANGED AND 
*			  ASSOCIATED SORT-REC NOT INCREASED TO LARGE 
*			  ENOUGH VALUE - CHANGED TO LENGTH OF 250. 
* 
*	98/03/18 (B.E.)	- ADDED DEFAULTING OF BATCH LOCATION AND I/O INDIATOR 
*			  SO THAT RMA OPERATORS CAN INPUT THESE FILES 
*			  INTO THE 'HEB' RECORD IF PROCESSING A NON- 
*			  RMA-ALTERED SUBMISSION DISKETTE. 
 
*	98/03/31 (M.C.) - SOME DOCTOR DISKETTES DO NOT HAVE 'HER' RECORD 
*			  (HEADER 2), IF OPERATOR WANTS TO DEFAULT TO 
*			  AGENT 0 AND TAPE-SUBMIT-IND = 'Y', SET IN 
*			  HEADER 1 SUBROUTINE.  FOR OTHER DISKETTES 
*			  THAT HAVE HEADER 2 RECORD, SET AGENT AND 
*			  TAPE-SUBMIT-IND FROM HEADER 2 RECORD. 
* 
*	98/04/06 (M.C.) - MOVE SPACES TO HEADER-REC IN FB0 SUBROUTINE 
*			- FIX MINOR PROBLEM (2 DIGITS TO CLINIC NBR) 
*			- CHANGE PGM NAME U701 TO NEWU701 IN SCREEN 
*			  SECTION 
*       1999/mar/2 B.E. - added logic at 2nd test section of code to only require
*                         diagnosic code if oma-suffix is "A" or "M"  
*     1999/May/06 S.B.  - Marked by 'S.B.' (brought from 102)
*                       - Put in check against the Referring physician
*                       being the same sas the Billing doctor.
*                       - Put in check for missing Referring physician.
*                       - Added a check to insure that Service dates are
*                       after Run dates.
*                       - Added a check to make sure that the correct
*                       specialty for the doctor is used.
*                       - Added a check to make sure that each claim
*                       has a detail record.
*                       - Changed the err-msg to occur 50 times to
*                       reflect the new error messages possible.
*                       - Changed the claim value being put out on
*                       error 50 from unpriced-clmhdr-claim to
*                       clmhdr-accounting-nbr to show the correct
*                       claim for the error.
*                       - Added a reset for the ctr-hdr2-rec and
*                       ctr-addr-rec counters to prevent a missing
*                       detail from appearing on the first
*                       batch record after a previous batch that
*                       had any detail records in it.
* 2000/feb/08 B.A. - added 'confidentiality flag' field to tape in file in
*		     anticipation of this value being passed from Web site
*		   - code to process this field to be added later
* 2000/feb/29 B.A. - added logic to only allow a 'Y' or ' ' in the confid 
*		     flag field 
* 2000/mar/02 B.E. - pricing algorithm (ye0) used hard coded '7' for original
*		     restriction of 8 detail lines.  Changed code to have
*		     maximun allowed detail lines (40) set into variable
*		     "ss-max-nbr-oma-det-rec-allow" and use this
*		     variable in pricing algorthim.
* 2000/mar/13 B.E. - if incoming patient's phone number is only 7 digits long
*		     then default the area code stored in copy book code.
*
* 2000/mar/20 M.C. - open f030-location-mstr, retrieve hospital nbr and i/o ind
*		     from locations mstr by loc-code.
*		     If the original doctor ohip nbr is the same as referring 
*		     doctor ohip nbr, print error.
*		     If diskette price is different than the way rma prices, 
*		     print error
* 2000/mar/29 M.C. - If the incoming I/O ind is different than RMA i/o ind, 
*		     print error
* 2000/apr/05 M.C. - If the input file comes with amount and the oma code 
*		     suffix is either 'B' or 'C' (ie anesthesia), do not change
*                    nbr of svc (ie basic + time), but do for web
* 2000/apr/10 M.C. - Change the pricing algorithm correctly for add on codes
*		     (ie suffix = 'B' or 'C')
*		     suffix is either 'B' or 'C' (ie anesthesia), do not change
* 2000/apr/14 M.C. - Yas requested this verion not to check price difference 
* 2000/apr/28 B.A. - Added additional checks for confidential flag at dtl level
* 2000/jun/05 B.E. - correct pricing of tech portion of fee
* 2000/jun/30 B.E. - keep BI and OP flags by moving them into consecutives 
*		     services area
* 2000/jul/31 B.E. - when determining current vs previous rates use the 
*		     effective date in the oma code's f040 record rather
*		     than effective date in constants master
* 2000/aug/03 B.E. - pricing modified to take into consideration that
*                    oma fees now 9(4).999 rather than 9(5).99
* 00/sep/08 B.E. - modified to keep original sequence details when writing
*		   claim details to suspend dtl file
* 00/sep/10 B.E. - rtn yz0-reset-verify-prices that resets prices to incoming
*		   values moved from this pgm into ya0- copybook so that
*		   that calcuation of 'tech' amounts can be made on 
*		   new priced amounts or the incoming amounts depending
*		   upon whether they are reset or not
*		 - set clmhdr-nbr-suspend-desc-recs to zero
* 00/sep/14 B.E. - comment out error message is hospital number is missing.
*		   Since the location code is now used to derive the hospital
*		   number it is no longer a problem of the incoming 
*		   hospital number is missing/wrong
* 00/oct/02 B.E. - ctr-tot-dollars-claim was used to sum OHIP detail amts
*		   and update header's oma/ohip $ amounts. Pgm changed to 
*		   reprice diskette uploads and save 'rma' prices in oma
*		   amt and diskette's original price in ohip amt. Therefore
*		   setup 2 separate ctr-tot.. fields to keep oma / ohip
*		   running claim totals to update header
*		 - renamed 'override' flag as 'retain incoming' price
*		   flag to make it easier to distinguish between OP override
*		   price logic
* 00/oct/26 B.E. - allow operator to override the current system date. This
*		   options is only used in test when running the "master 
*		   test claims batch" which are "old" dates that will
*		   be greater than 6 months from the real system date
*		   and will thus give errors (state dates). We want the
*		   'master test claims" to price the same time after time
*		   so allow operator to set system back (this date is 
*		   usually set based upon the current pricing old/new
*		   date of 2000/04/01)
*		 - if any dates wrong move 8 "?" rather than 6 to date field
*			    	
* 00/nov/27 M.C. - for clinic 61-65 only, if referring doc nbr is same as orig
*		   doc nbr, do not print error 47; if referring doc nbr is blank
*		   set the same as orig doc nbr.  Yas requested the changes.
* 01/feb/06 B.E. - change to pricing routine to price loc G420 / oma code
*                  G259 at 85%
* 01/feb/07 M.C. - save RMB ohip nbr if exists  
* 01/feb/12 M.C. - when edit RMB registration nbr, the size has changed;
*		   please refer to MOH technical specification book.
* 01/feb/28 M.C. - if agent cd = 6 or 9, set clmhdr-status and clmdtl-status
*		   equal to 'I'gnore  
* 01/mar/08 M.C. - if service date is greater than the admit date, instead of
*		   putting ????/??/?? in the service date field, put ????/??/??
*		   in the admit date
* 01/mar/27 B.E. - tech/prof rules of DU/PF icc codes changed to
*                  substitute "B" or "C" suffix for "A" if tech/prof
*                  only pricing, or to split into two separate lines
*                  if tech and prof fees involved.
* 01/apr/23 B.E. - 'fee' amount for PERCENTAGE addon's now divided by 100 as
*	  	   read in from f040 into hold variables that allow a 
*		   4 decimal percentage
* 01/sep/28 B.E. - added create-error-file (an 88 flag) that controls the output
*		   of files and the errors that are generated. If the program
*		   is run 'print only' then the defaults are set to NOT upload
*		   the claims into the SUSPENSE files but to write them to
*		   the output 'priced' file. Also ALL errors are surpressed
*		   so that although the edits are performed the error message
*		   is bypassed and the claim is priced regardless. Subsequent
*		   changes should allow the program to be called and ONLY edit
*		   applied. The output file would then be a collection of
*		   errors. 
* 01/oct/03 B.E. - added clinic-nbr to diskout (priced) file
* 02/mar/25 B.E. - added PAYROLL-FLAG to HEB record (unpriced-bathdr-rec)
* 02/apr/23 M.C. - move  PAYROLL-FLAG to clmhdr-hosp, according to Brad, they
*		   are no longer used the hospital code  
* 02/may/03 M.C. - temporary edit check against staled svc date (< 20010901)
*	         - Yas want to set payroll-flag to 'B' if incoming clinic from HEB is 85
*		   otherwise set to 'A'		
* 02/may/27 M.C. - reinstate the staled svc date check
* 02/jun/12 M.C. - if billing special premiums K994 to K997 and facility number is blank or zero,
*		   error needs facility number
* 02/aug/12 M.C. - if billing special premiums K990 to K997 and facility number is blank or zero,
*		   error needs facility number
* 02/aug/21 M.C. - if clinic = 80 or 95, bypass the edit check against svc date within 6 months
* 03/jun/11 M.C. - if billing special premiums K990 to K997 and location code does not end with 112
*		   error wrong location needs to end with 112
* 03/oct/22 M.C. - error if clinic nbr is not valid for the doctor
* 03/dec/08 M.C. - alpha doc nbr
* 04/jan/20 M.C. - add location code 153 or 400 or 250 or 422 when checking OMA cd K990 to K997
*                  with location code 112
* 04/apr/07 M.C. - error if admit date is prior to birth date
* 04/sep/27 M.C. - add location code 401 when checking OMA cd K990 to K997
*                  with location code 112
* 05/mar/03 M.C. - error if doctor specialty = 07 and patient age < 60  
*		   or doctor specialty = 07 and oma codes = A775 or W775 or C775
*		   and patient age < 75
* 05/may/04 M.C. - edit check to make sure birth date < service date
*		 - if clinic 61 to 65, must be certain location code; otherwise errors
* 05/may/09 M.C. - If location = G420 and oma code = G259 and R761, add manual review
*		   "REFER TO ADJUDICATION" on description record
* 		   add open/close of f002-suspend-desc file
* 05/jun/23 M.C. - manitoba should have 9 digits instead of 6
*                  change province from NF to NL
* 05/aug/09 M.C. - set clmhdr-tape-submit-ind to blank for all conditions before writing
*		   suspend header record
* 05/aug/17 M.C. - change description from "REFER TO ADJUDICATION"  to
*		   "G259 BILLED AT 85%"
*		 - xx3-write-susp-desc subroutine is created
* 05/oct/31 M.C. - If oma code = 'E420', then error - check pricing               
*		   if doc nbr = '049' and oma cd = 'Z425', then error - take out manual review
*		   if oma code is A073 or A074..etc (45 codes altogether) and diag code is 042 or 043..etc
*		   (26 altogether) and E078 is not on the same claim , error - check for E078 premium
*		   if oma code is A073 or A074..etc (45 codes altogether) and diag code is NOT 042 or 043..etc
*		   (26 altogether) and E078 is on the same claim , error - check for E078 premium
* 05/dec/14 M.C. - add oma code 'A340', 'A341', 'A343' and 'A348' to the list above  done on 05/oct/31       
* 06/feb/15 M.C. - YAS requested to change from 40 to 60 detail record allowance
*                  change  maximun allowed detail lines (60) set into variable
*                    "ss-max-nbr-oma-det-rec-allow" and use this
*                    variable in pricing algorthim.

* 06/dec/12 M.C. - Yas requested to more edit checks in the program
*                - If billing code is C122 and the admit date is 1 day or more from the  service date,
*                  then report on ru701 (newu701) with message "Check C122".
*                - If billing code is C123 and the admit date is 2 days or more from the service date,
*                  then report on ru701 (newu701) with message "Check C123".
*                - If billing code is C124 and the admit date is less than 3 days from service date,
*                  then report on ru701 (newu701) with message "Check C124".

* 07/jan/25 M.C. - Yas requested to fine tuned the recent edit checks
*                - If billing code is C122 and the service date < 1 or >= 2 days from the admit date,
*          	   then report on ru701 (newu701) with message "Check C122".
*                - If billing code is C123 and the service date < 2 or >= 3 days from the admit date,
*                  then report on ru701 (newu701) with message "Check C123".
*                - If billing code is C124 and the service date <= 1 day from the admit date,
*                  then report on ru701 (newu701) with message "Check C124".
* 07/aug/16 M.C. - for clinic 71-75 only, if referring doc nbr is same as orig
*		   doc nbr, do not print error 47; if referring doc nbr is blank
*		   set the same as orig doc nbr.  Yas requested the changes.
* 07/oct/24 M.C. - add location code 055 when checking OMA cd K990 to K997
*                  with location code 112
* 07/oct/24 M.C. - add location code 326 when checking OMA cd K990 to K997
*                  with location code 112
* 07/nov/27 M.C. - do the same check for clinic 71 to 75 as 
*		    if clinic 61 to 65, must be certain location code; otherwise errors
* 08/jan/03 Y.B. - add location code 122 when checking OMA cd K990 to K997
*                  with location code 112
* 08/jan/09 M.C. - allow diagnostic 299, 313, 315, 765 & 902 with oma code E078A
* 08/jan/17 M.C. - include oma cd A262 to check with E078 premium
* 08/feb/19 M.C. - add location code 344 when checking OMA cd K990 to K997
*                  with location code 112
* 08/feb/28 M.C. - add location code 111 & 354  when checking OMA cd K990 to K997
*                  with location code 112
* 08/mar/18 M.C. - add location code 333 when checking OMA cd K990 to K997
*                  with location code 112
* 08/Apr/23 M.C. - add more edit check for messages 69 to 84
* 08/Apr/29 M.C. - if claims have 'A---A' code and 'G---A' code and one of the following
*		   K991A, K993A, K995A, K997A, U991A, U993A, u995A, U997A, then
*		   create  'Pay visit premium based on "A---A" code' to 2 description records
*		   and set clmhdr-manual-review  to 'Y'
* 08/Jul/23 Yas  - mod mess "If the code is E021 and the services is not equal to 9" to 4
* 08/mar/18 M.C. - add location code 777 when checking OMA cd K990 to K997
*                  with location code 112
* 09/may/06 MC1  - do the same addition edit checks as d001.cbl
*		 - add 6 new edits and modify one existing edit for E021C in hb0-build-susp-dtl-rec-dtl
*                - modify to include in $use/d001_newu701_oma_code_edit.rtn
* 09/may/27 MC3  - modify the edit with exception of C101 when oma code is C990 to C997
*	           in  $use/d001_newu701_oma_code_edit.rtn
* 10/mar/31 MC4	 - more edit checks as requested by Yasemin for message 91 to 103 
* 10/may/18 MC5	 - more edit checks as requested by Yasemin for message 97 & 98        
* 10/may/19 MC6  - add a new sequential work file ru701-work-file, add message 104
* 10/aug/12 MC7  - add a new index to f002-suspend-hdr, set values to suspend-hdr-acr
* 10/sep/21 MC8  - modify for error 97 to include agent 9  
* 10/sep/23 MC9 - for error 89 - include the check for same service date
* 10/Oct/04 MC10 - Linda OHara requested to disable the edit check if
*                  AxxxA is billed plus GxxxA plus one of the follwing :U991, U993, U995, U997, K991,
*                  K993, K995 & K997. IF condition is true, claim is flagged or manual review with description
*                  'Pay visit premium based on AxxxA code'
* 10/dec/08 MC11 - modify for error 97 to check H1xx or H055 or H065
* 11/jan/26 MC12 - change the stale date to be 6 months plus 20 days per Yasemin
* 11/Mar/31 MC13 - modify edits for error 69, 80, 81, 85, 93, 97, 103, 65, 88 and add new edits for error 105 to 117
* 11/May/02 MC14 - modify edits for error 115 in copybook  pricing_variables_hold.ws & d001_newu701_oma_code_edit.rtn
* 11/May/18 MC15 - modify edits for error 80, 103 & remove the edit for error 108
*                - transfer all oma codes variables to copybook "d001_newu701_oma_code_variables.ws".
*                - transfer all oma codes variables reset to copybook "d001_newu701_oma_code_variables_reset.rtn".
*                - add the new subroutine xx1a-reset-oma-flag to call "d001_newu701_oma_code_variables_reset.rtn"
*                  in xx0-process-hold-dtls.
*                - include f201*slr/fd , open & close file to check against SLI OMA CODE SUFF
*                - add subroutine ha12-check-for-sli-oma to be called in ha0-proc-rec-type-detail
*                - add error 118 & 119 for sli edit check
* brad2 ? 
* brad3 - make the oscar file run as a WEB file rather than DISKETTE
* brad4 - ignore blank health care nbr for direct bill patients
* 2011/may/16 brad5     - extended HEP postal code from 6 to 9 characters to match oscar's demographic postal code field
*
* 11/Jun/13 MC16 - transfer the two subroutines ha12-check-for-sli-oma & hb0-build-susp-dtl-rec-dtl
*                  into new copybook $use/newu701_oscar_dtl_edit_check.rtn so that
*                  it can be called in both newu701.cbl & u701oscar.cbl
*                - transfer all error-messages into copybook $use/newu701_oscar_error_messages.ws
* 11/Jul/07 MC17 - include clinic 66 as part of clinic 60's check where is applied
* 11/Aug/22 MC18 - modify error 84 from 'A007 only allowed for specialty 00' to 'A007 not allowed for specialty 26'
*                  in $use/newu701_oscar_error_messages.ws & $use/newu701_oscar_dtl_edit_check.rtn
*                  and recompile newu701.cbl & u701oscar.cbl
* 2011/oct/14 be1 - WCB test with or without patient health nbr used "HCP" insetead of WCB - corrected
* 2011/oct/17 be2 - clmhdr agent doesn't appear to be set right - moved move of agent to suspend hdr to later in code
*	      	     AND fixed where ws-agent-default-reply flag was set to "Y" which was wiping out the incoming agent
* 2011/oct/17 be3 - reactive logic lost in conversion to this oscar version of program that set the suspend hdr/dtl status
*		    to 'I'gnore if agent is 6 or 9(done by moira originally in 2001 feb 28)
* 2011/oct/17 be4 - undo logic that was defaulting referring physician for certain clinics
*		  - default payroll to "A"
* 2011/oct/20 be5 - if Diskette then the pricing assumes that the B and C codes have 'basic' included with 'times' 
*		    and this code removes the basic so that the pricing can work (and add them back).. so changed this
*		    run from D to "W"eb so that is assume only 'times' coming in which matches what we expect oscar users to do
* 2011/oct/20 be6 - adjust how the province codes are processed - health card prov vs patient's address prov
* 2011/oct/24 be7 - the clinic comes in on HEH now and code checked it when HEB record read. moved location of code that checked
*		    clinic to HEH record processing.
* 11/nov/22 be8  - fix pricing with respect to min-fee pricing of OMA amount
* 11/Nov/23 MC22 - modify edit 1, 5, 12, 13, 21, 29, 32, 34, 40, 45, 49, 50 plus add new edits 52 to 65
* 12/Mar/06 MC23 - default back to 'D'iskette as requested by Brad/Yasemin
* 12/Apr/23 MC24 - reset field value when processing a new batch, change from speciality to specialty for spelling
* 12/Jul/04 MC25 - modify edit for error 69 to remove E022C check temporary
*                  in  $use/newu701_oscar_dtl_edit_check.rtn
* 12/Jul/12 MC26 - modify $use/pricing_logic.rtn to process yio before yf0 subroutine for pricing correctly
* 12/Oct/22 MC27 - since pricing for E676B is now correct, user requested to remove the error 123(edit 64) -'Check Fee for E676B'
*                  in  $use/newu701_oscar_dtl_edit_check.rtn & $use/d001_newu701_oma_code_edit.rtn
*-----
* 12/Nov/05 MC28 - allow to process agent 6, correct codes accordingly, only verify health care nbr if agent <> 6
* 13/Apr/11 MC29 - modify edit 1, 5, 12, 17 plus add new edits 66 to 69 for error 124 to 127
*                - add edits 66 - 69 in $use/newu701_oscar_dtl_edit_check.rtn,  add error message 124 to 127
*                - modify  in  $use/d001_newu701_oma_code_edit.rtn & la5-oma-code-edit subroutine
*                - modify  in  $use/d001_newu701_oma_code_variables.ws, $use/d001_newu701_oma_code_variables_reset.rtn,
*                  $use/newu701_oscar_error_messages.ws, $use/newu701_oscar_dtl_edit_check.rtn
* 13/Jun/17 MC30 - set referring doctor nbr to be the same as billing doctor nbr if referring doctor nbr = 0 if
*                  oma code = 'GnnnA' with fee-phy-ind = 'Y' in  $use/newu701_oscar_dtl_edit_check.rtn
*                - remove/comment out edit 69 which is same as edit 39 which was done on 2011/May/18
* 13/Jul/03 MC31 - in fb0-susp-hdr-rec, move the location of accounting closed to the beginning of the subroutine before
*		   any edit check so that it will not pick the previous accounting nbr
* 13/Jul/09 MC32 - Brad requested to add an edit check to make sure the service date > doctor start date
*                - Linda O requested to allow 7 mth for svc date billing instead of 6 mth & 20 days before staled date
*                - make changes in the copybook in $use/newu701_oscar_dtl_edit_check.rtn
*                  and add new error in $use/newu701_oscar_error_messages.ws
* 13/Jul/30      - UNDO MC32 -  to add an edit check to make sure the service date > doctor start date
*                - make changes in the copybook in $use/newu701_oscar_dtl_edit_check.rtn
*                  and remove new error in $use/newu701_oscar_error_messages.ws


environment division. 
input-output section. 
file-control. 
 
copy "f002_suspend_hdr.slr".
 
copy "f002_suspend_dtl.slr".
 
copy "f002_suspend_address.slr".
 
* 2005/05/09 - add description file
copy "f002_suspend_desc.slr".
* 2005/05/09 - end  
 
copy "f020_doctor_mstr.slr".
copy "f030_locations_mstr.slr".
copy "f040_oma_fee_mstr.slr".
copy "f090_constants_mstr.slr".
copy "f091_diagnostic_codes.slr". 
copy "f200_oscar_provider.slr".

* 2011/05/18 - MC15
copy "f201_sli_oma_code_suff.slr".
* 2011/05/18 - end

 
select unpriced-claims-file 
    assign to       "submit_disk_susp.in"
    organization is sequential 
    access mode  is sequential 
    status       is status-cobol-unpriced-claims. 
 
select priced-claims-file 
    assign to       "submit_disk_susp.out"
    organization is sequential 
    access mode  is sequential 
    status       is status-cobol-priced-claims. 

* 2010/05/19 - MC6
select ru701-oscar-work-file
    assign to       "ru701_work_file"       
    organization is sequential 
    access mode  is sequential 
    status       is status-cobol-ru701-work-file.
* 2010/05/19 - end

*2002/04/22 - MC - comment out 
*select error-claims-file 
*    assign to       "submit_disk_susp.err"
*    organization is sequential 
*    access mode  is sequential 
*    status       is status-cobol-error-claims. 
*2002/04/22 - end

 
select report-file 
    assign to        printer audit-file 
    Status       is  status-report. 
 
 
data division. 
file section. 
 
*COPY "F002_SUBMIT_DISKETTE_COMMON.FD". 
 
* MODIFICATION HISTORY 
*  97/JUN/21 B.E.	-ADDED OP_OVERRIDE_PRICE_IND 
*			 AND   BI_BILATERAL_IND 
*  97/SEP/25 B.E.	-ADDED CLINIC-NBR-1-2 
*  98/MAR/18 B.E.	-ADDED TAPEOUT-DEFAULT-BATCH-LOCATION. IF PROCESSING 
*		         AN 'UNALTERED' OHIP SUBMISSION DISKETTE 
*			 THEN NO RMA LOCATION HAS BEEN INCLUDED 
*			 ON EACH DETAIL RECORD. ALLOW RMA OPERATOR 
*			 TO EDIT DISKETTE FILE AND MANUALLY ADD 
*			 LOCATION TO 'HEB' BATCH HEADER RECORD. 
* 2002/mar/25 B.E.	- added PAYROLL-FLAG to HEB record (unpriced-bathdr-rec)
*
* 2011/apr/03 - brad1  - 
* 2011/apr/05 - brad2  - ensure that susp-hdr-acronym is updated and not left blank
*
* 
fd  unpriced-claims-file 
*mf    recording mode is data-sensitive 
    data records are unpriced-claims-record. 

***************************
******  HEB 
***************************
01  unpriced-claims-record. 
    05  unpriced-trans-id                        pic xx.   
    05  unpriced-input-rec-type                  pic x. 
    05  unpriced-bathdr-rec-full		pic x(177). 
    05  unpriced-bathdr-rec redefines unpriced-bathdr-rec-full. 
*    05  unpriced-bathdr-rec. 
        10  unpriced-release-id                  pic x(3).

        10  unpriced-moh-code                    pic x. 
        10  unpriced-bathdr-batch-nbr. 
            15  unpriced-bathdr-batch-nbr-date   pic 9(8).
            15  unpriced-bathdr-batch-nbr-seq    pic 9(4).
        10  unpriced-bathdr-opr-nbr              pic x(6). 
        10  unpriced-bathdr-fac-no               pic x(4). 
        10  unpriced-bathdr-prov-ohip-no         pic 9(6). 
        10  unpriced-bathdr-spec-cd              pic 9(2). 
        10  filler                              pic x(42). 

**** RMA EXTENSION
*       (2002/mar/25 added payroll flag - "A" regular 22 payroll
*					- "B" ICU payroll)
        10  unpriced-payroll-flag               pic x(1). 
        10  unpriced-default-batch-i-o-ind      pic x(1). 
        10  unpriced-default-batch-loc      	pic x(4). 
*        10  unpriced-bathdr-clinic-1-2           pic 99. 		
        10  unpriced-bathdr-clinic--ignore    pic 99. 		

        10  unpriced-bathdr-oscar-doc-id         pic x(10). 
*	(note: this field comes in from oscar blank and is then defaulted by reading f200-oscar-provider 
        10  unpriced-bathdr-dept                pic 99. 

*	10  unpriced-bathdr-filler		pic x(100).
*	10  unpriced-bathdr-filler		pic x(97).
*	10  unpriced-bathdr-filler		pic x(96).
*	10  unpriced-bathdr-filler		pic x(93).
* 2 ex	10  unpriced-bathdr-filler		pic x(90).
*	10  unpriced-bathdr-filler		pic x(88).
*brad 	10  unpriced-bathdr-filler		pic x(86).
 
***************************
******  HEH
***************************
    05  unpriced-clmhdr1-rec redefines unpriced-bathdr-rec. 
 
        10  unpriced-clmhdr-health-nbr           pic x(10). 
        10  unpriced-clmhdr-version-cd           pic x(2). 
        10  unpriced-clmhdr-birth-date. 
            15  unpriced-clmhdr-birth-date-yy    pic 9(4). 
            15  unpriced-clmhdr-birth-date-mm    pic 99. 
            15  unpriced-clmhdr-birth-date-dd    pic 99. 
        10  unpriced-clmhdr-claim. 
            15  unpriced-clmhdr-doc-nbr          pic x(3). 
            15  unpriced-clmhdr-wk               pic xx. 
            15  unpriced-clmhdr-day              pic x. 
            15  unpriced-clmhdr-claim-nbr        pic xx. 
        10  unpriced-clmhdr-pay-pgm              pic x(3). 
        10  unpriced-clmhdr-payee                pic x. 
        10  unpriced-clmhdr-ref-doc-nbr          pic 9(6). 
        10  unpriced-clmhdr-hosp-nbr             pic x(4). 
        10  unpriced-clmhdr-admit-date. 
            15  unpriced-clmhdr-admit-date-yy    pic x(4). 
            15  unpriced-clmhdr-admit-date-mm    pic xx. 
            15  unpriced-clmhdr-admit-date-dd    pic xx. 
        10  unpriced-clmhdr-ref-lab-no           pic 9(4). 
        10  unpriced-clmhdr-man-review           pic x. 
* brad use other name
*	10  unpriced-moh-location-code		pic 9(4).
        10  unpriced-clmhdr-loc-code             pic x(4). 

	10  unpriced-reserved-for-ooc		pic x(11).
        10  filler                              pic x(06). 
**** RMA EXTENSION - moved from HER
        10  unpriced-confidentiality-flag        pic x(1). 
*         (this field, if not specified, is calculated based upon value in "unpriced-clmhdr-pay-pgm" in HEH record above)
        10  unpriced-clmhdr-agent-cd             pic x. 
        10  unpriced-clmhdr-i-o-ind              pic x. 
*brad
*brad 10  unpriced-clmhdr-prov-cd              pic x(2). 
        10  unpriced-clmhdr-hc-prov-cd           pic x(2). 
        10  unpriced-clmhdr-hc-ohip-nbr          pic x(12). 

        10 unpriced-clmhdr-pat-acronym          pic x(9).
*	   (comes in from oscar's VISIT TYPE field)
        10  unpriced-bathdr-clinic-1-2           pic 99. 		
* brad
        10  unpriced-clmhdr-pat-surname2         pic x(30). 
        10  unpriced-clmhdr-given-name2          pic x(30). 
*  brad

*brad phone nbr now on HEP
*        10  unpriced-clmhdr-phone-no.
*            15 unpriced-clmhdr-phone-no-1-7	pic x(07).
*            15 unpriced-clmhdr-phone-no-8-10	pic x(03).
*        10  unpriced-clmhdr-phone-no-r redefines unpriced-clmhdr-phone-no.
*            15 unpriced-clmhdr-phone-no-1-3	pic x(03).
*            15 unpriced-clmhdr-phone-no-4-10	pic x(07).
**        10  filler                              pic x(98). 
*brad      10  filler                              pic x(79). 


***************************
******  HER
***************************

*brad
    05  unpriced-clmhdr2-rec redefines unpriced-bathdr-rec. 
* TODO where to get???
        10  unpriced-clmhdr-pat-ohip-nbr         pic x(12). 

        10  unpriced-clmhdr-pat-surname-2         pic x(9). 
        10  unpriced-clmhdr-given-name-2          pic x(5). 
        10  unpriced-clmhdr-sex-2                 pic 9. 


*        10  filler                              pic x(50). 
*brad


**** RMA EXTENSION - moved to HEH
*        10  unpriced-confidentiality-flag        pic x(1). 
*        10  unpriced-clmhdr-loc-code             pic x(4). 
*        10  unpriced-clmhdr-agent-cd             pic x. 
*        10  unpriced-clmhdr-i-o-ind              pic x. 
*        10  unpriced-clmhdr-phone-no.
*            15 unpriced-clmhdr-phone-no-1-7	pic x(07).
*            15 unpriced-clmhdr-phone-no-8-10	pic x(03).
*        10  unpriced-clmhdr-phone-no-r redefines unpriced-clmhdr-phone-no.
*            15 unpriced-clmhdr-phone-no-1-3	pic x(03).
*            15 unpriced-clmhdr-phone-no-4-10	pic x(07).
*brad        10  filler                              pic x(83). 

***************************
******  HET
***************************
    05  unpriced-item-rec redefines unpriced-bathdr-rec. 
        10  unpriced-itm1-oma-svc-cd. 
            15  unpriced-itm1-oma-svc-code       pic x(4). 
            15  unpriced-itm1-oma-svc-suff       pic x. 
        10  filler                              pic x(2). 
        10  unpriced-itm1-oma-amt-billed         pic 9(4)v99. 
        10  unpriced-itm1-nbr-serv               pic 99. 
        10  unpriced-itm1-svc-date. 
            15  unpriced-itm1-svc-date-yy        pic 9(4).
            15  unpriced-itm1-svc-date-mm        pic 99. 
            15  unpriced-itm1-svc-date-dd        pic 99. 
        10  unpriced-itm1-diag-cd                pic x(3). 
        10  filler-diag                         pic x(1). 
	10  unpriced-reserved-for-ooc		pic x(09).
        10  filler                              pic x(11). 
        10  unpriced-itm2-oma-svc-cd. 
            15  unpriced-itm2-oma-svc-code       pic x(4). 
            15  unpriced-itm2-oma-svc-suff       pic x. 
        10  filler                              pic x(2). 
        10  unpriced-itm2-oma-amt-billed         pic 9(4)v99. 
        10  unpriced-itm2-nbr-serv               pic 99. 
        10  unpriced-itm2-svc-date. 
            15  unpriced-itm2-svc-date-yy        pic 9(4).
            15  unpriced-itm2-svc-date-mm        pic 99. 
            15  unpriced-itm2-svc-date-dd        pic 99. 
        10  unpriced-itm2-diag-cd                pic x(3). 
	10  filler				 pic x(6).
**** RMA EXTENSION
        10  unpriced-itm1-override-price         pic x(1). 
        10  unpriced-itm1-bilateral              pic x(1). 
        10  unpriced-itm2-override-price         pic x(1). 
        10  unpriced-itm2-bilateral              pic x(1). 
        10  unpriced-itm3-override-price         pic x(1). 
        10  unpriced-itm4-bilateral              pic x(1). 
*	10  filler				 pic x(115).
*brad	10  filler				 pic x(113).
	10  filler				 pic x(112).
 
***************************
******  HEA/HEP
***************************
    05  unpriced-pat-addr-rec redefines unpriced-bathdr-rec. 
        10  unpriced-pat-addr-1                  pic x(25). 
        10  unpriced-pat-addr-2                  pic x(25). 
        10  unpriced-pat-addr-3                  pic x(18). 
        10  unpriced-clmhdr-hc-prov-cd-2         pic x(2). 
* brad
* brad putback 
* brad5 extend from 6 to 9
*       10  unpriced-pat-addr-post-cd		pic x(6). 
        10  unpriced-pat-addr-post-cd		pic x(9). 

*        10  unpriced-pat-addr-post-cd. 
*           15  unpriced-pat-addr-post-cd1       pic x. 
*           15  unpriced-pat-addr-post-cd2       pic 9. 
*           15  unpriced-pat-addr-post-cd3       pic x. 
*           15  unpriced-pat-addr-post-cd4       pic 9. 
*           15  unpriced-pat-addr-post-cd5       pic x. 
*           15  unpriced-pat-addr-post-cd6       pic 9. 
*brad
*brad1
*        10  unpriced-clmhdr-pat-surname          pic x(30). 
        10  unpriced-clmhdr-pat-surname.
            15  unpriced-clmhdr-surname-1-6   pic x(06). 
            15  unpriced-clmhdr-surname-7-30  pic x(24). 
*brad2
*        10  unpriced-clmhdr-given-name           pic x(30). 
        10  unpriced-clmhdr-given-name.
            15  unpriced-clmhdr-given-name1-3   pic x(03). 
            15  unpriced-clmhdr-given-name4-30  pic x(27). 

        10  unpriced-clmhdr-sex                  pic x. 
*be4
*        10  unpriced-clmhdr-phone-no 		 pic x(12) .
        10  unpriced-clmhdr-phone-no 		 pic x(20) .

*be4 - birthdate repeated here
        10  unpriced-clmhdr-birth-date2. 
            15  unpriced-clmhdr-birth-date-yy2   pic 9(4). 
            15  unpriced-clmhdr-birth-date-mm2   pic 99. 
            15  unpriced-clmhdr-birth-date-dd2   pic 99. 
*        10  unpriced-unknown-1			 pic x(1) .
*        10  unpriced-unknown-2			 pic x(1) .
*brad        10  unpriced-pat-addr-post-cd		pic x(6). 
*brad
*brad	10  filler                              pic x(5). 
*be4
*        10  filler                              pic x(11). 
        10  filler                              pic x(05). 
**** RMA EXTENSION
*      10  filler                              pic x(101). 
*       brad10remove when extended above to include surname, etc  filler                              pic x(98). 
 
***************************
******  HEE
***************************
    05  unpriced-trailer-rec redefines unpriced-bathdr-rec. 
        10  unpriced-trailer-clmhdr1-cnt         pic 9(4). 
        10  unpriced-trailer-clmhdr2-cnt         pic 9(4). 
        10  unpriced-trailer-itm-cnt             pic 9(5). 
        10  unpriced-trailer-pat-addr-cnt        pic 9(4). 
        10  filler                              pic x(63). 
**** RMA EXTENSION
*        10  filler                              pic x(101). 
        10  filler                              pic x(99). 
 
    05  unpriced-cr                              pic x. 


fd  priced-claims-file 
*   RECORDING MODE IS DATA-SENSITIVE 
*     (2001/oct/03 B.E. added new clinic-nbr field)
**    record contains 59  characters 
    record contains 61  characters 
    data records are diskout-output-rec. 
 
01  diskout-output-rec. 
*	    (2001/oct/03 B.E. added new clinic-nbr field)
	10  diskout-clmhdr-clinic-nbr		pic x(2).

        10  diskout-clmhdr-claim		pic x(8). 
        10  diskout-oma-svc-cd. 
            15  diskout-oma-svc-code	        pic x(4). 
            15  diskout-oma-svc-suff	        pic x. 
        10  diskout-ohip-amt-billed	        pic 9(4)v99. 
 
        10  diskout-svc-date. 
            15  diskout-svc-date-yy	        pic 9(4). 
            15  diskout-svc-date-mm	        pic 99. 
            15  diskout-svc-date-dd	        pic 99. 
        10  diskout-nbr-serv	                pic 99. 
        10  diskout-oma-amt-billed	        pic 9(4)v99. 
        10  diskout-priced-tech   	        pic 9(4)v99. 
        10  diskout-basic-tech    	        pic 9(4)v99. 
        10  diskout-basic-prof     	        pic 9(4)v99. 
        10  diskout-basic-fee      	        pic 9(4)v99. 
        10  diskout-cr                          pic x. 
        10  diskout-lf                          pic x. 

* 2010/05/19 - MC6
fd  ru701-oscar-work-file  
    record contains 174 characters 
    data records are diskout-output-rec. 
 
01  ru701-work-rec.       
    05  ru701-sort-key.
	10  ru701-doc-nbr      		      	pic x(3).
        10  ru701-clinic-nbr     		pic x(2). 
        10  ru701-doc-spec-cd			pic 9(2).
        10  ru701-pat-acronym      	        pic x(9).
        10  ru701-accounting-nbr		pic x(8).
        10  ru701-orig-rec-no	                pic 9(5). 
        10  ru701-acronym-flag       	        pic x.
        10  ru701-page-area          	        pic x.
	10  ru701-acronym			pic x(9).
	10  ru701-line-no			pic 99.
    05  ru701-print-line			pic x(132).
* 2010/05/19 - end

copy "f002_suspend_hdr.fd".
 
copy "f002_suspend_dtl.fd".

copy "f002_suspend_address.fd".

* 2005/05/09 - add description file
copy "f002_suspend_desc.fd".
* 2005/05/09 - end  

copy "f020_doctor_mstr.fd".
copy "f030_locations_mstr.fd". 
copy "f040_oma_fee_mstr.fd".
copy "f090_constants_mstr.fd".
copy "f090_const_mstr_rec_2.ws".
copy "f091_diagnostic_codes.fd".
copy "f200_oscar_provider.fd".
* 2011/05/18 - MC15

copy "f201_sli_oma_code_suff.fd".
* 2011/05/18 - end
 
fd  report-file 
    record contains 132 characters. 
 
01  rpt-line                    pic x(132). 
working-storage section. 

* 2010/03/31 - MC4 - include site_id.ws
copy "site_id.ws".
* 2010/03/31 - end

************************************************************************
*   (variables below are needed by ya0- pricing copybook logic but 
*    are only referenced within d001 so they are dummied up here so that
*    this pgm will compile)
77  password-input                              pic x(3).
77  password-special-privledges                 pic x(3)  value "xxx".
77  confirm                               	pic x   value space.
77  scr-hold-oma-cd				pic x	value space.
77  scr-hold-oma-suff				pic x	value space.
77  scr-hold-sv-date-yy-12			pic x	value space.
77  scr-hold-sv-date-yy-34			pic x	value space.
77  scr-hold-sv-date-mm				pic x	value space.
77  scr-hold-sv-date-dd				pic x	value space.
77  scr-hold-sv-nbr-0				pic x   value space.
77  scr-hold-fee-oma				pic x   value space.
77  scr-hold-fee-ohip				pic x   value space.
77  scr-acpt-det-desc				pic x   value space.
77  scr-last-claim      			pic x   value space.
77  pline					pic 9   value zero.
************************************************************************
* brad
77 hold-hc-prov					pic xx   value space.

 
*mf 77 ws-1-null				pic x(1) value "<000>". 
*mf 77 ws-4-nulls				pic x(4) value "<000><000><000><000>". 
77 ws-1-null					pic x(1) value x"00".   
77 ws-4-nulls					pic x(4) value x"00000000".

77  ws-warning-literal				pic x(14) value "* Warning * -".
77  ws-error-literal				pic x(14) value "**ERROR** - ".

01  temp-phone-nbr.
   05 temp-phone-nbr-justified-left.
      10 temp-phone-nbr-1-7			pic 9(7).
      10 temp-phone-nbr-8-10			pic 9(3).
   05 temp-phone-nbr-justified-right redefines temp-phone-nbr-justified-left.
      10 temp-phone-nbr-1-3			pic 9(3).
      10 temp-phone-nbr-4-10			pic 9(7).

01  batch-rec. 
  05  batch-dist-cd                             pic x. 
  05  batch-identifier                          pic x(10). 
  05  batch-group-nbr                           pic x(4). 
  05  batch-provider-nbr                        pic 9(6). 
  05  batch-specialty                          pic 9(2). 
  05  batch-pay-type                            pic 9. 

* ('dummy' field added to allow compile of common code shared between
*  this pgm and d001)
01 nbr-of-services 				pic 99. 
 
01  header-rec. 
  05  hdr-ohip-nbr. 
      10  nf-ohip-nbr                           pic x(12). 
*2001/02/12 - MC - change the size of the ohip nbr for various provinces
*     10  ab-ns-ohip-nbr redefines nf-ohip-nbr. 
*         15  ab-ns-11-digits                   pic x(11). 
*         15  ab-ns-last-digits                 pic x. 
*     10  bc-ohip-nbr redefines nf-ohip-nbr. 
*         15  bc-10-digits                      pic x(10). 
*         15  bc-last-digits                    pic xx. 
      10  bc-ns-ohip-nbr redefines nf-ohip-nbr. 
          15  bc-ns-10-digits                   pic x(10). 
          15  bc-ns-last-digits                 pic xx. 
*     10  nb-pe-sk-yt-ohip-nbr  redefines nf-ohip-nbr. 
*         15  nb-pe-sk-yt-9-digits              pic x(9). 
*         15  nb-pe-sk-yt-last-digits           pic xxx. 
      10  ab-nb-sk-yt-ohip-nbr  redefines nf-ohip-nbr. 
          15  ab-nb-sk-yt-9-digits              pic x(9). 
          15  ab-nb-sk-yt-last-digits           pic xxx. 
      10  pe-ohip-nbr redefines	nf-ohip-nbr.
	  15  pe-8-digits			pic x(8).
	  15  pe-last-digits			pic x(4).
*** end
      10  nt-ohip-nbr redefines nf-ohip-nbr. 
          15  nt-first-digit                    pic x. 
          15  nt-7-digits                       pic x(7). 
          15  nt-last-digits                    pic x(4). 
      10  mb-ohip-nbr redefines nf-ohip-nbr. 
* 2005/06/23 - MC - Manitoba should have 9 digits
*         15  mb-6-digits                       pic x(6).
*         15  mb-last-digits                    pic x(6).
          15  mb-9-digits                       pic x(9).
          15  mb-last-digits                    pic x(3).
* 2005/06/23 - end

  05  hdr-surname                               pic x(9). 
  05  hdr-first-name                            pic x(5). 

  05  hdr-birth-date-long. 
*  Birth Date split up into yymm and dd 
* (y2k)
*   10  hdr-birth-date                          pic 9(4). 
    10  hdr-birth-date                          pic 9(6). 
    10  hdr-birth-date-dd                       pic 9(2). 
  05  hdr-sex                                   pic x. 
  05  hdr-accounting-nbr                        pic x(8). 
  05  hdr-refer-pract-nbr                       pic 9(6). 
  05  hdr-hosp-nbr                              pic x(4). 
  05  hdr-i-o-ind                               pic x. 
  05  hdr-admit-date. 
* (y2k)
*   15  hdr-admit-yy                            pic xx. 
    15  hdr-admit-yy                            pic x(4).
    15  hdr-admit-mm                            pic 99. 
    15  hdr-admit-dd                            pic 99. 
  05  hdr-manual-review                         pic x(1). 
  05  hdr-health-care-nbr                       pic x(12). 
  05  hdr-health-care-ver                       pic x(02). 
  05  hdr-health-care-prov                      pic x(02). 
  05  hdr-relationship                          pic x(01). 
  05  hdr-patient-surname                       pic x(09). 
  05  hdr-subscr-initials                       pic x(03). 
  05  hdr-agent-cd                              pic x(01). 

* 2003/06/11 - MC
*  05  hdr-loc-code                              pic x(04). 
  05  hdr-loc-code.  
      10 hdr-loc-alpha                           pic x. 
      10 hdr-loc-nbr                             pic x(03). 
* 2003/06/11 - end

* 2013/04/17 - MC28
  05  hdr-direct-key.
      10 hdr-surname-3                          pic x(3).
      10 hdr-birthdate-yymm                     pic 9(4).
      10 hdr-birthdate-dd                       pic 9(2).
* 2013/04/17 - end

 
*     DATA STORED IN WORKING-STORAGE FROM FILES THAT SHARE I-O BUFFER AREAS. 
 
*   (THE FOLLOWING 'DOC' FIELDS WERE CLONED FROM D001 WHEN THE D001 PRICING 
*    CODE WAS MERGED INTO U701. THESE VALUES ARE *NOT* USED IN THIS PGM 
*    AND THE PRICING CODE HAS BEEN CHANGED WERE APPROPRIATE) 
01  ws-doc-mstr-rec-data. 
    05  ws-doc-nx-batch-nbr                     pic  999. 
    05  ws-doc-dept                             pic   99. 
    05  ws-doc-ohip-nbr                         pic 9(6). 
    05  ws-doc-spec-cd                          pic   99. 
    05  ws-doc-locations. 
        10  ws-doc-loc  occurs 30               pic x999. 
 
01    detail-rec. 
  05  dtl-oma-cd                                pic x(4). 
  05  dtl-oma-suff                              pic x(1). 
  05  dtl-fee-billed                            pic 9999v99. 
  05  dtl-nbr-of-serv                           pic 99. 
  05  dtl-serv-date. 
* (y2k)
*       10  dtl-serv-date-yy                    pic 99. 
        10  dtl-serv-date-yy                    pic 9(4).
        10  dtl-serv-date-mm                    pic 99. 
        10  dtl-serv-date-dd                    pic 99. 
  05  dtl-diag-code                             pic x(3). 
 
01  trailer-rec. 
  05  trl-h-count                               pic 9(4). 
  05  trl-r-count                               pic 9(4). 
  05  trl-t-count                               pic 9(4). 
  05  trl-a-count                               pic 9(4). 
  05  trl-b-count                               pic 9(4). 
 
77  audit-file                                  pic x(11) value "ru701_oscar". 
77  suspend-dtl-occur                           pic 9(7). 
77  ws-carriage-ctrl                            pic 9(02) value 0. 
77  ctr-lines-printed                           pic 9(03) value 99. 
77  max-lines-per-page                          pic 9(03) value 60. 
77  ws-rpt-page-nbr                             pic 9(03) value 0. 
77  ws-agent-default-reply                      pic x(01) value spaces. 
*!77  ws-doc-nbr                                  pic 9(3)  value 0. 
77  ws-doc-nbr                                  pic x(3)  value spaces.
*77  WS-DEFAULT-CLINIC-NBR                       PIC 9(4)  VALUE 0. 
77  ws-default-clinic-nbr                       pic 9(2)  value 0. 
77  ws-default-batch-location                   pic x(4)  value " ". 
77  ws-default-batch-i-o-ind                    pic x(1)  value " ". 

*2002/04/24 -  MC
77  ws-default-payroll-flag			pic x.
*20002/04/24 - end

77  flag-zero-fee                               pic x. 
77  feedback-iconst-mstr                        pic x(4). 
77  ws-tot-serv                                 pic 999   value 0.
77  ws-special-add-on-cd-entered                pic x. 

* 2011/05/18 - MC15
copy "d001_newu701_oma_code_variables.ws".

77  ws-pricing-nbr-serv                         pic 999. 
77  ws-highest-grp-tot                          pic s9(5)v99. 
77  ws-highest-grp-nbr                          pic 99. 
77  flag-new-sec                                pic x. 
77  flag-z-highest-grp                          pic x. 
* 
*  SUBSCRIPTS 
* 
77  rate-found-ss                               pic 99  comp  value 0. 
77  subs                                        pic 99  comp  value 0. 
77  ss                                          pic 99  comp  value 0. 
77  sub                                         pic 99  comp  value 0. 
77  ss1                                         pic 99  comp  value 0. 
77  ss2                                         pic 99  comp  value 0. 
77  ss-basic-times                              pic 99  comp  value 0. 
77  ss-basic-times-desc-rec                     pic 99  comp  value 0. 
77  ss-from-plus-one                            pic 99  comp  value 0. 
77  ss-const                                    pic 99  comp  value 0. 
77  subs-table-addr                             pic 99  comp  value 0. 
77  i                                           pic 99  comp  value 0. 
77  ss-from                                     pic 99  comp  value 0. 
77  ss-to                                       pic 99  comp  value 0. 
77  ss-sec                                      pic 99  comp  value 0. 
77  ss-grp                                      pic 99  comp  value 0. 
77  ss-grp-tot                                  pic 99  comp  value 0. 
77  ss-clmhdr                                   pic 99  comp  value 0. 
77  ss-tech-prof-suff                           pic 99  comp  value 0. 
77  ss-clmdtl-oma                               pic 99  comp  value 0. 
77  ss-clmdtl-next-avail-dtl                    pic 99  comp  value 0. 
77  ss-clmdtl-new-dtl                           pic 99  comp  value 0. 
77  ss-clmdtl-tech-prof-suff                    pic 99  comp  value 0. 
77  ss-hold-clmdtl-oma                          pic 99  comp  value 0. 
77  ss-price                                    pic 99  comp  value 0. 
77  ss-write-dtl                                pic 99  comp  value 0. 
77  ss-clmdtl-desc                              pic 99  comp  value 0. 
77  ss-conseq-dd                                pic 99  comp  value 0. 
77  ss-ind                                      pic 99  comp  value 0. 
77  ss-plus-one                                 pic 99  comp  value 0. 
77  ss-x                                        pic 99  comp  value 0. 
77  ss-suffix                                   pic 99  comp  value 0. 
*       (SUBSCRIPTS FOR HOLD-OMA-RECORDS TABLE) 
*       (moved to pricing hold.ws copybook)
 
77  ws-hold-wcb-rate                            pic 999v9(5). 
77  ws-reduc-rate98                             pic 99v99. 
77  ws-reduc-rate99                             pic 99v99. 
77  ws-reduc-rate                               pic 99v99. 
77  ws-search-clinic-nbr-1-2                    pic 99  comp  value 0. 
*   ('CURR'ENT AND 'PREV'IOUS USED IN SELECTING THE APPROPRIATE OMA YEAR'S FEES -- 
*    'OMA' AND 'OHIP' TO SELECT THE APPROPRIATE FEE TYPE) 
77  curr                                        pic 9   comp    value 1. 
77  prev                                        pic 9   comp    value 2. 
77  oma                                         pic 9   comp    value 1. 
77  ohip                                        pic 9   comp    value 2. 
77  ss-curr-prev                                pic 99  comp  value 0. 
 
77  space-char                                  pic x(01) value " ".   
77  carriage-return                             pic x(01) value x"0D". 
77  line-feed                                   pic x(01) value x"0A". 
77  ws-hold-temp-1                              pic s9(7)v99. 
77  ws-hold-temp-2                              pic 99. 
77  ws-hold-temp-3                              pic s9(9). 
 
01  bt-clinic-nbr-1-2                           pic 99  value zero. 
01  subs-hosp                                   pic 99  comp  value 0. 
 
01  ws-date-yymmdd. 
* (y2k)
*   05 ws-date-yy                               pic 99. 
    05 ws-date-yy                               pic 9(4).
    05 ws-date-mm                               pic 99. 
    05 ws-date-dd                               pic 99. 
 
01  ws-nbr-10                                   pic x(10). 

* 2005/03/03 - MC
01  ws-birth-date				pic 9(8).
01  ws-sv-date					pic 9(8).
* 2005/03/03 - end 

* 2010/09/23 - MC9
01  ws-sv-date-c1                               pic 9(8).
01  ws-sv-date-c2                               pic 9(8).
* 2010/09/23 - end
 
*01  hold-suspend-hdr-rec                        pic x(265). 
01  hold-suspend-hdr-rec                        pic x(278). 
 
*     DATA STORED IN WORKING-STORAGE FOR CONSTANTS MASTER CLINIC REC SINCE 
*     FD AREA IS RE-USED FOR CONSTANTS MASTER PRICING RECS. 
 
01  ws-iconst-mstr-rec-data. 
    05  ws-iconst-clinic-nbr-1-2                pic   99. 
    05  ws-iconst-clinic-nbr                    pic 9(4). 
    05  ws-iconst-clinic-cycle-nbr              pic   99. 
* (y2k)
*   05  ws-iconst-date-period-end               pic 9(6). 
    05  ws-iconst-date-period-end               pic 9(8). 
    05  ws-iconst-clinic-card-colour            pic    x. 
 
01  audit-line. 
    05  filler                                  pic x(10) value spaces. 
    05  audit-title                             pic x(36). 
    05  audit-value                             pic zz,zzz. 
    05  filler                                  pic x(05) value spaces. 
    05  audit-value-2                           pic zz,zzz. 
    05  filler                                  pic x(05) value spaces. 
    05  audit-value-3                           pic zz,zzz. 
    05  filler                                  pic x(05) value spaces. 
    05  audit-value-4                           pic zz,zzz. 
    05  filler                                  pic x(05) value spaces. 
    05  audit-value-5                           pic zzz,zzz.99 blank when zero. 
 
01  status-values. 
  02 status-infos. 
    05  status-unpriced-claims                  pic x(11)  value zero. 
    05  status-priced-claims-file               pic x(11)  value zero. 
    05  status-iconst-mstr                      pic x(11)  value zero. 
    05  status-doc-mstr                         pic x(11)  value zero. 
    05  status-oma-mstr                         pic x(11)  value zero. 
    05  status-suspend-hdr                      pic x(11)  value zero. 
    05  status-suspend-dtl                      pic x(11)  value zero. 
    05  status-suspend-desc                     pic x(11)  value zero. 
    05  status-suspend-addr                     pic x(11)  value zero. 
    05  status-diag-mstr                        pic x(11)  value zero. 
    05  status-file                             pic x(11). 
* brad
    05 status-oscar-provider			pic x(11)  value zero.

  02 status-cobol. 
    05  status-cobol-unpriced-claims            pic x(02)  value zero. 
    05  status-cobol-priced-claims              pic x(02)  value zero. 
    05  status-cobol-doc-mstr                   pic x(02)  value zero. 
    05  status-cobol-oma-mstr                   pic x(02)  value zero. 
    05  status-cobol-iconst-mstr 		pic x(02)  value zero. 
    05  status-cobol-suspend-hdr                pic x(02)  value zero. 
    05  status-cobol-suspend-dtl                pic x(02)  value zero. 
    05  status-cobol-suspend-desc               pic x(02)  value zero. 
    05  status-cobol-suspend-addr               pic x(02)  value zero. 
    05  status-cobol-diag-mstr                  pic x(02)  value zero. 
    05  status-report                           pic x(02)  value zero. 
    05  status-cobol-loc-mstr                   pic x(02)  value zero. 
    05  status-cobol-error-claims               pic x(02)  value zero. 
    05  status-cobol-ru701-work-file            pic x(02)  value zero. 
*	brad
    05  status-cobol-oscar-provider             pic x(02)  value zero. 
* 2011/05/18 - MC15
    05  status-cobol-sli-oma-mstr               pic x(02)  value zero.
* 2011/05/18 - end

 
01  feedback-values. 
    05  feedback-doc-mstr                       pic x(04)  value zero. 
    05  feedback-oma-fee-mstr                   pic x(04)  value zero. 
    05  feedback-suspend-hdr                    pic x(04)  value zero. 
    05  feedback-suspend-dtl                    pic x(04)  value zero. 
    05  feedback-suspend-addr                   pic x(04)  value zero. 
    05  feedback-diag-mstr                      pic x(04)  value zero. 

01  flag-adjudication-required                  pic x.
    88 adjudication-desc-required               value "Y".
 
01  ic-flag                                     pic x  value "N". 
    88  ic-entered                              value "Y". 
    88  ic-not-entered                          value "N". 
 
01  flag                                        pic x. 
    88 ok                                       value "Y". 
    88 not-ok                                   value "N". 
 
01  eof-input-file-flag                         pic x   value "N". 
    88 eof-input-file                   	value "Y". 
 
01  fatal-error-flag                            pic x   value spaces. 
    88 fatal-error                      	value "Y". 
 
01  flag-lock                                   pic x. 
    88 rec-locked                               value "Y". 
    88 rec-not-locked                           value "N". 
 
01  flag-ohip-vs-chart                          pic x. 
    88  qhip                                    value "O". 
    88  chart                                   value "C". 
    88  direct                                  value "D". 
 
01  flag-valid-ohip-or-chart                    pic x. 
    88  valid-ohip                              value "Y". 
    88  valid-chart                             value "Y". 
    88  invalid-ohip                            value "N". 
    88  invalid-chart                           value "N". 
 
01  flag-ohip-mmyy                              pic x. 
    88  valid-mmyy                              value "Y". 
    88  invalid-mmyy                            value "N". 
 
01  flag-err-data                               pic x. 
    88  err-data                                value "N". 
    88  ok-data                                 value "Y". 
 
01  flag-done-clmdtl-recs                       pic x. 
    88  done-clmdtl-recs-yes                    value "Y". 
 
01  flag-eoj                                    pic x. 
    88  eoj-create-new-patient                  value "C". 
    88  eoj                                     value "E". 

01  flag-tech-prof-suffix-rule			pic x.
    88  tech-prof-suff-rule-applied		value "Y".
 
01  flag-sec-reduction-needed                   pic x. 
 
01  flag-report-desc                            pic x. 
    88 report-desc-required                     value "Y". 
 
01  ws-oma-cd. 
    05  ws-oma-cd-1                             pic x. 
    05  ws-oma-cd-2-4                           pic 999. 
 
*mf 01 skip-processing-this-acct-id-flag            pic x. 
01 skip-process-this-acct-id-flag            pic x.
    88 skip-processing-this-acct-id     value "Y". 
    88 skip-hdr-addr-but-write-dtl      value "D". 
 
01  record-type-flags                   pic x. 
    88 b-record                         value "B". 
    88 h-record                         value "H". 
    88 r-record                         value "R". 
    88 t-record                         value "T". 
    88 a-record                         value "A". 
*     brad 
*     (RMA's Patient record layout a P instead of the MOH's reciprocole records 'A" designation
    88 p-record                         value "P". 
    88 e-record                         value "E". 
 
01 last-record-type-flag                        pic x. 
    88 last-record-is-b                 value "B". 
    88 last-record-is-h                 value "H". 
    88 last-record-is-r                 value "R". 
    88 last-record-is-t                 value "T". 
    88 last-record-is-a                 value "A". 
    88 last-record-is-e                 value "E". 
 
01  counters. 
    05  ctr-read-const-mstr                     pic 9(7). 
    05  ctr-diskout-writes			pic 9(7). 
    05  ctr-suspend-hdr-writes                  pic 9(7). 
    05  ctr-suspend-dtl-writes                  pic 9(7). 
* 2005/08/17 - MC
    05  ctr-suspend-desc-writes                 pic 9(7). 
* 2005/08/17 - end
    05  ctr-suspend-addr-writes                 pic 9(7). 
    05  ctr-recs-read                           pic 9(7). 
    05  ctr-b-recs-read-skipped                 pic 9(7). 
    05  ctr-h-recs-read-skipped                 pic 9(7). 
    05  ctr-r-recs-read-skipped                 pic 9(7). 
    05  ctr-t-recs-read-skipped                 pic 9(7). 
    05  ctr-a-recs-read-skipped                 pic 9(7). 
    05  ctr-e-recs-read-skipped         	pic 9(7). 
    05  ctr-p-recs-read-skipped         	pic 9(7). 
    05  ctr-b-recs-read                         pic 9(7). 
    05  ctr-h-recs-read                         pic 9(7). 
    05  ctr-r-recs-read                         pic 9(7). 
    05  ctr-t-recs-read                         pic 9(7). 
    05  ctr-a-recs-read                         pic 9(7). 
    05  ctr-p-recs-read                         pic 9(7). 
    05  ctr-e-recs-read                         pic 9(7). 
    05  ctr-h-recs-skipped                      pic 9(7). 
    05  ctr-r-recs-skipped                      pic 9(7). 
    05  ctr-t-recs-skipped                      pic 9(7). 
    05  ctr-a-recs-skipped                      pic 9(7). 
    05  ctr-p-recs-skipped                      pic 9(7). 
    05  ctr-tot-b-recs                          pic 9(7). 
    05  ctr-tot-h-recs                          pic 9(7). 
    05  ctr-tot-r-recs                          pic 9(7). 
    05  ctr-tot-t-recs                          pic 9(7). 
    05  ctr-tot-a-recs                          pic 9(7). 
    05  ctr-tot-p-recs                          pic 9(7). 
    05  ctr-tot-dollars-read                    pic 9(7)v99. 

*    05  ctr-tot-dollars-claim                   pic 9(7)v99. 
    05  ctr-tot-dollars-oma			pic 9(7)v99. 
    05  ctr-tot-dollars-ohip			pic 9(7)v99. 

    05  ctr-tot-tech-claim			pic 9(7)v99.
    05  ctr-tot-svcs-read                       pic 9(7). 
*** S.B. - start.
    05  ctr-hdr2-rec                            pic 9(02).
    05  ctr-addr-rec                            pic 9(02).
*** S.B. - end.

01  flag-date                                   pic x. 
    88 valid-date                                       value "Y". 
    88 invalid-date                                     value "N". 
 
01  flag-consec                                 pic x. 
    88 valid-consec                                     value "Y". 
    88 invalid-consec                                   value "N". 
 
01  flag-clinic                                 pic x. 
    88 clinic-found                                     value "Y". 
    88 clinic-not-found                                 value "N". 
 
01  flag-hosp-nbr                               pic x. 
    88 valid-hosp-nbr                                   value "Y". 
    88 invalid-hosp-nbr                                 value "N". 
 
01  flag-agent-cd                               pic x. 
    88 valid-agent-cd                                   value "Y". 
    88 invalid-agent-cd                                 value "N". 
 
01  flag-in-out-ind                                     pic x. 
    88 valid-in-out-ind                                 value "Y". 
    88 invalid-in-out-ind                               value "N". 
 
01  flag-doc                                    pic x. 
    88  doc-found                                       value "Y". 
    88  doc-not-found                                   value "N". 

* brad
01  flag-oscar-provider                         pic x. 
    88  oscar-provider-found                            value "Y". 
    88  oscar-provider-not-found                        value "N". 
 
01  flag-oma                                    pic x. 
    88  valid-oma-code                                  value "Y". 
    88  invalid-oma-code                                value "N". 
 
01  flag-agent-code                                     pic x. 
    88  valid-agent-cd-code                             value "Y". 
    88  invalid-agent-cd-code                           value "N". 
 
01  flag-refer-phys                             pic x. 
    88  valid-refer-phys                                value "Y". 
    88  invalid-refer-phys                              value "N". 
 
01  flag-location                               pic x. 
    88  valid-location                                  value "Y". 
    88  invalid-location                                value "N". 
 
01  flag-ohip                                   pic x. 
    88  valid-ohip                                      value "Y". 
    88  invalid-ohip                                    value "N". 
 
01  flag-diag-cd                                pic x. 
    88  valid-diag-code                                 value "Y". 
    88  invalid-diag-code                               value "N". 
 
01  detail-written-flag                         pic x. 
    88  detail-written                          value 'Y'. 
    88  detail-not-written                      value 'N'. 
 
01  ws-chk-ind                                  pic x(8). 
 
77  ws-val-total                                pic s9(7). 
77  date-difference-in-days                     pic 9(3). 
77  rem-even                                    pic 9v9(4). 
77  max-nbr-digits                              pic 99 value 7. 
 
77  max-doc-locations                           pic 99 value 30. 

*   (include the pricing algorith's hold variables)
* 2006/02/15 - MC


* WARNING - keep the 'ss-max-nbr-oma-det-rec-allow' value in sync with
*           the definition of 'hold-oma-rec' in 'pricing_variables_hold.ws'

*77  ss-max-nbr-oma-det-rec-allow                pic 99  comp    value  40.
*77  ss-max-nbr-oma-det-rec-allow                pic 99  comp    value  60.
77  ss-max-nbr-oma-det-rec-allow                pic 99  comp    value  70.

* WARNING - keep the 'ss-max-nbr-oma-det-rec-allow' value in sync with
*           the definition of 'hold-oma-rec' in 'pricing_variables_hold.ws'


* 2006/02/15 - end

    copy "pricing_variables_hold.ws". 
 
01  province-flag                              pic x. 
    88  province-found                          value "Y". 
    88  province-not-found                      value "N". 
 
01  prov-table. 
 
    05  province. 
        10  filler                              pic x(2) value "ON". 
        10  filler                              pic x(2) value "AB". 
* 2005/06/23 - MC - change NF to NL
*       10  filler                              pic x(2) value "NF".
        10  filler                              pic x(2) value "NL".
* 2005/06/23 - end
        10  filler                              pic x(2) value "SK". 
        10  filler                              pic x(2) value "MB". 
        10  filler                              pic x(2) value "NT". 
        10  filler                              pic x(2) value "PE". 
*       10  FILLER                              PIC X(2) VALUE "QE". 
        10  filler                              pic x(2) value "YT". 
        10  filler                              pic x(2) value "BC". 
        10  filler                              pic x(2) value "NB". 
        10  filler                              pic x(2) value "NS". 
*       10  FILLER                              PIC X(2) VALUE "OT". 
 
    05  province-r               redefines      province. 
 
        10  prov                 occurs 11 times pic x(2). 
 
copy "def_agents.ws".

copy "default_phone_area_code.ws".
 
copy "sysdatetime.ws".
 
copy "check_digit.ws".
 
copy "check_digit_10.ws".
 
copy "mod_check_digit.ws".
 
copy "mth_desc_max_days.ws".
 
copy "hosp_table.ws".
 
 
01 heading-l1. 
    05  filler                                  pic x(12)       value 
       "ru701_oscar". 
    05  filler                                  pic x(10)       value 
       "Run Date:". 
 
* (y2k)
*   05  l1-run-date                             pic x(08). 
    05  l1-run-date                             pic x(10). 
*   05  filler                                  pic x(08)       value spaces. 
    05  filler                                  pic x(06)       value spaces. 
    05  filler                                  pic x(73)       value 
       "OSCAR OHIP Submittion Upload into Suspense - ERROR/WARNING/AUDIT Report". 
    05  filler                                  pic x(06)       value 
        "Page:". 
    05  rpt-page-nbr                            pic zzz9. 
 
01 heading-l2. 
    05  filler                                  pic x(08)       value 
	"DOCTOR: ". 
*!    05  h-l2-doctor-nbr                         pic 999. 
    05  h-l2-doctor-nbr                         pic xxx. 
    05  filler                                  pic x(03)       value 
	" / ". 
    05  h-l2-doctor-initials                    pic x(03). 
    05  filler                                  pic x(01)       value 
	" ". 
    05  h-l2-doctor-name                        pic x(24). 
    05  filler                                  pic x(20)       value 
	" CLINIC/SPECIALTY: ". 
    05  h-l2-clinic                             pic x(4). 
    05  filler                                  pic x(03)       value 
	" / ". 
    05  h-l2-specialty                          pic x(3). 
 
copy "f090_const_mstr_rec_1.ws".

* 2011/06/13 - MC16 - error messages have tranferred into the copy book $use/newu701_oscar_error_messages.ws

copy "newu701_oscar_error_messages.ws".

* 2011/06/13 - end

* 2010/03/31 - MC4
*01  err-ind                                     pic 99  value zero. 
01  err-ind                                     pic 999  value zero. 
* 2010/03/31 - end

01  err-msg-comment                             pic x(132). 
01  save-prt-line                               pic x(132). 
 
 
01  e1-error-line. 
 
    05  e1-error-word                           pic x(11)   value 
                        "*** ERROR- ". 
    05  e1-error-msg                            pic x(52). 
    05  e1-error-key                            pic x(17). 



screen section. 
 
01  scr-title. 
    05  blank screen. 
    05  line 03 col 10 value "Price claims/create Priced File/Upload to Suspense".
 
01 scr-current-system-date.
    05  line 05 col 05 value "Current System Date".
    05  line 05 col 70 pic 99999999 using sys-date.

01 scr-claim-source-default-reply. 
    05  line 07 col 05 value "Enter Claim SOURCE - 'W'eb / 'D'iskette / 'P'rice only [ ]".
    05  line 07 col 70 pic x(01) using flag-claim-source auto.

01 scr-update-suspense-reply. 
    05  line 11 col 05 value "Do you want to upload claims to Suspense- [Y]/N ?".
    05  line 11 col 70 pic x(01) using flag-update-suspense auto.

01 scr-create-priced-file-reply. 
    05  line 12 col 05 value "Do you want to create Priced File         [Y]/N ?".
    05  line 12 col 70 pic x(01) using flag-create-priced-file auto.

01 scr-retain-prices-reply.
    05  line 14 col 05 value "Do you want to RETAIN Incoming prices- [Y]/N ?".
    05  line 14 col 70 pic x(01) using flag-retain-prices auto.
 
01 scr-agent-default-reply. 
    05  line 16 col 05 value "Do you want to default 'BLANK' AGENT Codes to 'OHIP' (ie. '0') ?". 
    05  line 16 col 70 pic x(01) using ws-agent-default-reply auto. 
 
01  scr-doc-nbr. 
    05  line 15 col 05 value "Enter the DOCTOR NBR or press 'newline' to default to 0    :". 
*!    05  line 15 col 66 pic 9(3) using ws-doc-nbr auto. 
    05  line 15 col 66 pic x(3) using ws-doc-nbr auto. 
 
01  scr-clinic-nbr. 
    05  line 17 col 05 value "Enter the CLINIC NBR or press 'newline' to default to 22(15):". 
    05  line 17 col 68 pic 9(2) using ws-default-clinic-nbr auto. 

* ('dummy' field added to allow compile of common code shared between
*  this pgm and d001)
01  scr-last-claim-lit.
    05                          line 03 col 65 value 'Nbr of Svc'.

01  scr-in-progress-message. 
    05  line 19 col 20 value "PROGRAM  U701oscar  NOW IN PROGRESS". 
 
01 file-status-display. 
    05  line 24 col 56  "FILE STATUS = ". 
    05  line 24 col 70  pic x(11) from status-file      bell blink. 
* 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 01  value "PROGRAM U701oscar  ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99  from sys-yy.
    05  line 21 col 40  pic 9(4)  from sys-yy. 
    05  line 21 col 44  value "/". 
    05  line 21 col 45  pic 99  from sys-mm. 
    05  line 21 col 47  value "/". 
    05  line 21 col 48  pic 99  from sys-dd. 
    05  line 21 col 52  pic 99  from sys-hrs. 
    05  line 21 col 54  value ":". 
    05  line 21 col 55  pic 99  from sys-min. 
    05  line 23 col 10  value "AUDIT REPORT IS IN FILE - RU701". 
 
procedure division. 
declaratives. 
 
err-input-diskette-file section. 
    use after standard error procedure on unpriced-claims-file. 
err-input-diskette. 
    stop "ERROR IN ACCESSING: dISKETTE INPUT FILE". 
    move status-unpriced-claims         to status-file. 
    display file-status-display. 
*    stop " ". 
    move status-cobol-unpriced-claims   to status-file. 
    display file-status-display. 
    stop run. 
 
err-suspend-hdr-file section. 
    use after standard error procedure on suspend-hdr. 
err-suspend-hdr. 
*   (IF DUPLICATE KEY ERROR, THEN SET FLAG TO SKIP PROCESSING OF THIS HEADER) 
*   (NOTE: 90/01/14 B.E. LOGIC WILL BYPASS WRITING OF HEADER BUT HAS BEEN MODIFIED 
*          SO THAT THE DETAILS FOR THIS HEADER WILL BE PROCESSED AND THEREFORE 
*          WILL BECOME DETAILS FOR THE HEADER ALREADY ON FILE. MESSAGE ON WARNING 
*          REPORT SHOULD ALERT STAFF TO REVIEW CLAIM TO CONFIRM THAT THESE 
*          HEADERS ARE FOR SAME PATIENT.  THE ORIGINAL CLAIM HEADER ON FILE WILL 
*          HAVE IT'S CLAIM STATUS SET TO "CANCEL (IE.'Y') SO THAT IT WON'T 
*          BE PROCESSED UNLESS UNCANCELLED.  IT WILL ALSO APPEAR ON THE CANCELLED 
*          SUSPENDED CLAIMS REPORTS) 
 
    if   status-suspend-hdr       = "7013" 
      or status-cobol-suspend-hdr = "22" 
    then 
        go to err-suspend-hdr-50. 
*   endif 
 
    stop "ERROR IN ACCESSING: SUSPEND-HEADER" 
    move status-suspend-hdr     to status-file 
    display file-status-display 
*    stop " " 
    move status-cobol-suspend-hdr       to status-file 
    display file-status-display 
    stop run. 
 
err-suspend-hdr-50. 
*   (SET FLAG TO INDICATE THAT HEADER IS BEING SKIPPED DUE TO DUPLICATE 
*    KEY BUT THAT DETAILS ARE TO BE WRITTEN TO DISK) 
*mf    move "D"                            to      skip-processing-this-acct-id-flag. 
    move "D"                            to      skip-process-this-acct-id-flag. 
    move suspend-hdr-rec                to      hold-suspend-hdr-rec. 
*   (READ ORIGINAL HDR REC) 
    read suspend-hdr 
        invalid key 
          display  "SERIOUS IMPOSSIBLE ERROR #1 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id           stop run. 
 
*   (UPDATE ORIGINAL HEADER'S STATUS TO "CANCELLED" 
    move "Y"                            to      clmhdr-status. 
 
*   (REWRITE UPDATED RECORD) 
    rewrite suspend-hdr-rec 
        invalid key 
           display "SERIOUS IMPOSSIBLE ERROR #2 SUSPEND HDR FILE - KEY IS = ",suspend-hdr-id 
           stop run. 
 
*   (RESTORE THE SUSPEND HDR RECORD DATA) 
    move hold-suspend-hdr-rec           to      suspend-hdr-rec. 
 
err-suspend-hdr-99-exit. 
    exit. 
 
 
 
err-suspend-dtl-file section. 
    use after standard error procedure on suspend-dtl. 
err-suspend-dtl. 
    stop "ERROR IN ACCESSING: SUSPEND-DETAIL". 
    move status-suspend-dtl             to status-file. 
    display file-status-display. 
*    stop " ". 
    move status-cobol-suspend-dtl       to status-file. 
    display file-status-display. 
    stop run. 
 
* 2005/08/17 - MC - add suspend-desc 
err-suspend-desc-file section. 
    use after standard error procedure on suspend-desc. 
err-suspend-desc. 
    stop "ERROR IN ACCESSING: SUSPEND-DETAIL". 
    move status-suspend-desc             to status-file. 
    display file-status-display. 
*    stop " ". 
    move status-cobol-suspend-desc       to status-file. 
    display file-status-display. 
    stop run. 
* 2005/08/17 - end

 
err-suspend-addr-file section. 
    use after standard error procedure on suspend-address. 
err-suspend-addr. 
    stop "ERROR IN ACCESSING: SUSPEND-ADDRESS". 
    move status-suspend-addr            to status-file. 
    display file-status-display. 
*    stop " ". 
    move status-cobol-suspend-addr      to status-file. 
    display file-status-display. 
    stop run. 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    stop "ERROR IN ACCESSING: DOCTOR MASTER". 
    move status-doc-mstr                to status-file. 
    display file-status-display. 
    stop run. 
 
 
err-diagnostics-mstr-file section. 
    use after standard error procedure on diag-mstr. 
err-diagnostics-mstr. 
    stop "ERROR IN ACCESSING: DIAGNOSTIC CODES MASTER". 
    move status-diag-mstr               to status-file. 
    display file-status-display. 
    stop run. 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
 
err-constants-mstr. 
*   (IF 'RECORD LOCKED' PRINT WARNING, SET FLAG SO THAT 'READ' WILL LOOP UNTIL RECORD UNLOCKED) 
    if status-iconst-mstr = "7015" 
    then 
*       (ERROR - WRITE REPORT AND SKIP BATCH) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 41                         to      err-ind 
	move ws-error-literal           to 	err-warn-msg
        move batch-group-nbr            to      err-msg-clinic-id 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
    else 
        move status-iconst-mstr         to      status-file 
        display  file-status-display 
        display "ERROR IN ACCESSING CONSTANTS MASTER" 
        stop run. 
*   endif. 
 
 
err-report-file section. 
    use after standard error procedure on report-file. 
err-report. 
    stop "ERROR IN WRITING TO AUDIT REPORT: RU701". 
    move status-report                  to status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
 
mainline section. 
 
    perform aa0-initialization          thru aa0-99-exit. 
    perform ab0-processing              thru ab0-99-exit 
            until   eof-input-file 
                 or fatal-error. 
    perform az0-finalization            thru az0-99-exit. 
    stop run. 
 
aa0-initialization. 
 
    display scr-title. 

    accept sys-date             from date. 
    perform y2k-default-sysdate         thru y2k-default-sysdate-exit. 

*   (when testing the 'master claims batch' allow operator to override
*    system date)
    display scr-current-system-date.

*  (TESTING ONLY)
*    accept  scr-current-system-date.

    move sys-mm                 to   run-mm. 
    move sys-dd                 to   run-dd. 
    move sys-yy                 to   run-yy. 
    move run-date               to   l1-run-date. 
 
    accept sys-time             from time. 
    move sys-hrs                to   run-hrs. 
    move sys-min                to   run-min. 
    move sys-sec                to   run-sec. 
 
*!    move 0			to   ws-doc-nbr. 
    move spaces			to   ws-doc-nbr. 
*   MOVE 2215			TO   WS-DEFAULT-CLINIC-NBR. 

    move 22  			to   ws-default-clinic-nbr. 

*   (predisplay all options on screen)
*  brad3 - consider this as a Web Star claim rather than "D"iskette even though coming from oscar
*    move "D"			to flag-claim-source.
* 2011/06/22 - MC - Yasemin said it should be 'D'iskette not 'W'eb
*   move "W"			to flag-claim-source.
*be5 if Diskette then the pricing assumes that the B and C codes have basic included with times and take then out .. for
*    Oscar this is not true - so change back to Web 
*    move "D"			to flag-claim-source.

* 2012/03/06 - MC23 - Brad/Yas requested to change to 'D'
*   move "W"			to flag-claim-source.
    move "D"			to flag-claim-source.
* 2012/03/06 - end

* 2011/06/22 - end
    display scr-claim-source-default-reply.
    display scr-retain-prices-reply.
    display scr-update-suspense-reply.
    display scr-create-priced-file-reply.
    display scr-agent-default-reply.

aa0-05-default-claim-source. 
*   display scr-claim-source-default-reply.
*   accept  scr-claim-source-default-reply.

    if   web-claim
      or diskette-claim
      or price-only-claim
    then
	next sentence
    else
	go to aa0-05-default-claim-source.
*   endif

aa0-07-retain-prices.
*   (prices are normally overridden, even for diskettes, however some
*    diskettes don't send a "complete" claim under 1 accounting number
*    (eg. PNP allows only 4 details per accounting number) and therefore
*   this program can't reprice the claim. This flag allows the operator
*   to turn on/off the repricing option. Web claim are automatically
*   "repriced")

*   CASE 
    if web-claim
    then
	move "N"			to flag-retain-prices
	go to aa0-09-update-suspense
    else
    if price-only-claim 
    then
	move "N"			to flag-retain-prices
	go to aa0-09-update-suspense.
*   ENDCASE

*   (default for oscar is to IGNORE incoming prices)
    move "N"				to flag-retain-prices.


*  (TESTING ONLY)
*    accept  scr-retain-prices-reply.



    if    retain-incoming-prices
       or override-with-rma-prices
    then
	next sentence
    else
	go to aa0-07-retain-prices.
*   endif
    
aa0-09-update-suspense.
    display scr-retain-prices-reply.

*   CASE
    if web-claim
    then
	move "Y"			to flag-update-suspense
	go to aa0-10-create-priced-file
    else 
    if price-only-claim
    then
	move "N"			to flag-update-suspense
	go to aa0-10-create-priced-file.
*   ENDCASE

*   (default for diskettes is to retain prices)
    move "Y"				to flag-update-suspense.


*  (TESTING ONLY)
*   accept  scr-update-suspense-reply.


    if    update-suspense
       or dont-update-suspense
    then
	next sentence
    else
	go to aa0-09-update-suspense.
*   endif

aa0-10-create-priced-file.
    display scr-update-suspense-reply.

*   CASE
    if web-claim
    then
	move "Y"			to flag-create-priced-file
	go to aa0-20-default-agent
    else 
    if price-only-claim
    then
	move "Y"			to flag-create-priced-file
	go to aa0-20-default-agent.
*   ENDCASE

*   (default for diskettes is to retain prices)
    move "Y"				to flag-create-priced-file 


*  (TESTING ONLY)
*    accept  scr-create-priced-file-reply.


    if    create-priced-file
       or dont-create-priced-file
    then
	next sentence
    else
	go to aa0-10-create-priced-file.
*   endif
    

aa0-20-default-agent. 
    display scr-create-priced-file-reply.

*   (00/mar/27 B.E. removed option - no longer required) 
*   (be2 - default to NO)
*   move "Y"			to  ws-agent-default-reply.
    move "N"			to  ws-agent-default-reply.

    display scr-agent-default-reply. 
*    accept  scr-agent-default-reply. 
 
    if ws-agent-default-reply = "Y" or "N" 
    then 
	next sentence 
    else 
        go to aa0-20-default-agent. 
*   endif 
 
*   (00/mar/27 B.E. removed option - no longer required) 
    display scr-doc-nbr. 
*    accept  scr-doc-nbr. 

*   (00/mar/27 B.E. removed option - no longer required) 
    display scr-clinic-nbr. 
*    accept  scr-clinic-nbr. 
 
    display scr-in-progress-message. 
 
    move spaces to suspend-hdr-rec 
                   suspend-dtl-rec 
                   suspend-address-rec. 
 
    move zero   to suspend-dtl-occur 
                   ws-temp 
                   counters. 
 
    open input  unpriced-claims-file 
                loc-mstr 
                doc-mstr 
                diag-mstr 
                oma-fee-mstr 
* 2011/05/18 - MC15
                sli-oma-code-suff-mstr
* 2011/05/18 - end
                iconst-mstr. 
 
    open i-o    suspend-hdr 
                suspend-dtl 
  		suspend-desc
                suspend-address
		oscar-provider. 
 
*    expunge     report-file 
*                priced-claims-file. 
    open output report-file 
* 2010/05/19 - MC6
	  	ru701-oscar-work-file
* 2010/05/19 - end
                priced-claims-file. 

* ( TESTING ONLY )
*    perform ta0-read-diskette thru ta0-99-exit.
*    perform ta0-read-diskette thru ta0-99-exit.

    move spaces				to	hold-oma-recs. 
    perform aa1-init-hold-oma-rec      thru    aa1-99-exit
		varying i
   		from    1 
   		by      1 
		until   i  > ss-max-nbr-oma-det-rec-allow.
*		until   i  > 40.

*   (OBTAIN CONSTANT'S MSTR RECORD THAT CONTAINS LIST OF VALID CLINIC NBR) 
    move 1                          to      iconst-clinic-nbr-1-2. 
    perform uj1-read-isam-const-mstr thru   uj1-99-exit. 
 
*   (CHECK FOR ERRORS - SHUT DOWN) 
    if fatal-error 
    then 
*       (ERROR - WRITE REPORT AND SKIP BATCH) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 45                         to      err-ind 
	move ws-error-literal           to	err-warn-msg
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
        go to aa0-99-exit 
    else 
*	(MOVE CONSTANT'S MSTR VALUES INTO HOLD AREA TO BE USED LATER TO VERIFY CLINICS) 
        move constants-mstr-rec-2       to	constants-mstr-rec-1. 
*   endif 
 
*   (OBTAIN PRICING CONSTANT'S VALUES FROM REC 2 OF CONSTANTS MASTER) 
    move 2                          to      iconst-clinic-nbr-1-2. 
    perform uj1-read-isam-const-mstr thru   uj1-99-exit. 
 
*   (CHECK FOR ERRORS - SHUT DOWN) 
    if fatal-error 
    then 
*       (ERROR - WRITE REPORT AND SKIP BATCH) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 42                         to      err-ind 
	move ws-error-literal           to	err-warn-msg
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
        go to aa0-99-exit. 
*   endif 
 
    perform ta0-read-diskette                   thru ta0-99-exit. 
 
*   (FIRST RECORD MUST BE "B"ATCH RECORD) 
    if b-record 
    then 
        add 1                           to      ctr-b-recs-read 
*       MOVE DISKETTE-INPUT-REC-DATA    TO      BATCH-REC 
        perform ea0-proc-rec-type-batch thru    ea0-99-exit 
*       (CHECK FOR ERRORS - SHUT DOWN) 
        if fatal-error 
        then 
           go to aa0-99-exit 
        else 
*           (READ RECORD AFTER 'B' RECORD) 
            perform ta0-read-diskette   thru    ta0-99-exit 
*       endif 
    else 
*       (ERROR - FIRST RECORD NOT "B"ATCH RECORD) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 7                          to      err-ind 
	move ws-error-literal		to	err-warn-msg
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*       GO TO AA0-99-EXIT. 
*   endif 
*   (INITIALIZE SUBSCRIPT FOR PRICING HOLD AREA) 
    move 0                              to      ss-clmdtl-oma. 
*   (00/aug/13 B.E. - reset special add-on code flag)
    move "N"				to	ws-special-add-on-cd-entered.	

*2011/05/18 - MC15
copy "d001_newu701_oma_code_variables_reset.rtn".

* 2010/09/23 - MC9
   move 0   	         to ws-sv-date-c1
                            ws-sv-date-c2.
* 2010/09/23 - end
 
    move carriage-return		to	diskout-cr. 
    move line-feed      		to	diskout-lf. 

aa0-99-exit. 
    exit. 

aa1-init-hold-oma-rec.

    move zeros		to  hold-sv-nbr-serv(i).
    move zeros		to  hold-sv-date-yy(i).
    move zeros		to  hold-sv-date-mm(i).
    move zeros		to  hold-sv-date-dd(i).
    move zeros		to  hold-icc-grp(i). 
    move zeros		to  hold-fee-incoming(i).  

*   (00/aug/31 B.E.)
    move zeros		to  hold-sv-nbr-serv-incoming(i).

*   (00/aug/10 B.E.)
    move zeros		to  hold-ss-curr-prev(i).

    move zeros		to  hold-fee-oma(i).    
    move zeros		to  hold-fee-ohip(i).    
    move zeros		to  hold-priced-tech(i).  
    move zeros		to  hold-basic-tech(i).    
    move zeros		to  hold-basic-prof(i). 
    move zeros		to  hold-basic-fee(i).   
    move zeroes		to  hold-flag-sec(i).     
    move zeroes		to  hold-flag-grp(i).      
    move zeros		to  hold-diag-cd(i).      
    move zeros		to  hold-line-no(i).       
           
    perform aa2-init-oma-fees 	thru aa2-99-exit
	varying ss1 
	from    1
         by	1
	until   ss1 > 2.
		
    perform aa3-init-sv-nbr  thru aa3-99-exit
	varying ss1 
	from    1
	 by	1
	until   ss1 > 3.
		
aa1-99-exit.
    exit.


aa2-init-oma-fees.

    move zeroes	to  hold-oma-fee-1(i,ss1).   
    move zeroes	to  hold-oma-fee-2(i,ss1).    
    move zeroes	to  hold-oma-fee-anae(i,ss1).  
    move zeroes	to  hold-oma-fee-asst(i,ss1).

aa2-99-exit. 
    exit.

aa3-init-sv-nbr.
 
    move zeroes 	to hold-sv-nbr(i,ss1).

aa3-99-exit.
    exit.




 
ab0-processing. 

    if unpriced-clmhdr-claim = "00000020"  or "00000022" or "00000015" 
    then
        move ctr-b-recs-read 			to      ctr-b-recs-read.
*   endif 

    if b-record 
    then 
        add 1                                   to      ctr-b-recs-read 
        perform ea0-proc-rec-type-batch         thru    ea0-99-exit 
    else 
    if h-record 
    then 
        add 1                                   to      ctr-h-recs-read 
        perform fa0-proc-rec-type-header1       thru    fa0-99-exit 
    else 
    if r-record 
    then 
        add 1                                   to      ctr-r-recs-read 
        move 1                                  to      ctr-hdr2-rec
*        perform ga0-proc-rec-type-header2       thru    ga0-99-exit 
    else 
    if t-record 
    then 
        add 1                                   to      ctr-t-recs-read 
        perform ha0-proc-rec-type-detail        thru    ha0-99-exit 
    else 
    if a-record  
    then 
        add 1                                   to      ctr-a-recs-read 
        move 1                                  to      ctr-addr-rec
        perform ia0-proc-rec-type-address       thru    ia0-99-exit 
    else 
    if p-record  
    then 
        add 1                                   to      ctr-p-recs-read 
        move 1                                  to      ctr-addr-rec
        perform pa0-proc-rec-type-address       thru    pa0-99-exit 
    else 
    if e-record 
    then 
        add 1                                   to      ctr-e-recs-read 
        perform ka0-proc-rec-type-trailer       thru    ka0-99-exit. 
*   endif 
 
*   (IF ERROR FOUND PROCESSING THIS RECORD, SKIP PROCESSING ANY DTL/ADDR RECS THAT 
*    BELONG TO SAME ACCOUNT ID: 
*    -- SKIP ALL INTERVEENING DETAIL AND ADDRESS RECORDS UNTIL ANOTHER HEADER (H) 
*    RECORD OR TRAILER (E) RECORD IS FOUND OR END OF INPUT FILE) 
    if skip-processing-this-acct-id 
    then 
        move spaces                             to      unpriced-claims-record 
        perform ta0-read-diskette               thru    ta0-99-exit 
            until  b-record 
*                                           OR "E") 
                 or eof-input-file 
*       MOVE "N"                                TO      SKIP-PROCESSING-THIS-ACCT-ID-FLAG 
*       GO TO AB0-99-EXIT 
    else 
        if not eof-input-file 
             perform ta0-read-diskette               thru    ta0-99-exit. 
*       endif 
*   endif 
 
ab0-99-exit. 
    exit. 
az0-finalization. 
 
   close unpriced-claims-file 
         priced-claims-file 
         suspend-hdr 
         suspend-dtl 
         suspend-address 
  	 suspend-desc
         doc-mstr 
         loc-mstr 
         oma-fee-mstr 
         diag-mstr 
         iconst-mstr 
	 ru701-oscar-work-file
	 oscar-provider
* 2011/05/18 - MC15
         sli-oma-code-suff-mstr
* 2011/05/18 - end
         report-file. 
 
az0-99-exit. 
    exit. 
 
copy "db0_mod10_check_digit.rtn".
 
copy "db0a_mod10_check_digit_10.rtn".
 
copy "dc0_mod10_check_digit_alt.rtn".


ea0-proc-rec-type-batch. 
 
*   (processing a new BATCH. If there were detail records in hold area 
*    from the previous claim header rec then area process them - ie. price 
*    them and write them out) 
    perform xx0-process-hold-dtls	thru xx0-99-exit. 

* 2012/04/23 - MC24  - reset  field value
    move spaces				to clmhdr-pat-acronym
					   hdr-accounting-nbr
					   hold-accounting-nbr.
* 2012/04/23 - end
 
*   (RE-SET TOTALS FOR THIS BATCH - NOTE THAT THIS ZEROING WILL ALSO 
*    WIPE OUT THE COUNTER OF THE "B"ATCH RECORD READ THAT IS BEING 
*    PROCESSED - THUS SET APPROPRIATE COUNTERS TO 1) 
    move zero                           to      counters. 
    move 1                              to      ctr-b-recs-read 
                                                ctr-recs-read. 
*    MOVE DISKETTE-INPUT-REC-DATA       TO      BATCH-REC. 
    move unpriced-moh-code               to batch-dist-cd. 
    move unpriced-bathdr-batch-nbr       to batch-identifier. 
    move unpriced-bathdr-fac-no          to batch-group-nbr. 
    move unpriced-bathdr-prov-ohip-no    to batch-provider-nbr. 

    move zero                           to batch-pay-type. 

*   (read docter master by doc nbr) 
*   MOVE BATCH-PROVIDER-NBR             TO      DOC-PRACT-NBR. 
    move unpriced-bathdr-oscar-doc-id   to      oscar-provider-no of oscar-provider-rec. 
    perform th0-read-oscar-provider     thru    th0-99-exit. 
    if oscar-provider-found 
    then 
*	(pickup the translated RMA doctor nbr and clinic)
	move doc-nbr 	of oscar-provider-rec 		to doc-nbr of doc-mstr-rec
*	(clinic now translated via oscar's 'visit type')
*	move doc-clinic-nbr of oscar-provider-rec	to bt-clinic-nbr-1-2
*							   ws-default-clinic-nbr
    else
*       (error - write report and skip batch) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 2                          to      err-ind 
	move ws-error-literal		to	err-warn-msg
        move unpriced-bathdr-oscar-doc-id     to      err-msg-doc-nbr 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit.
*   endif

*  brad - get specialty from translation table
    move doc-specialty-code of oscar-provider-rec    to batch-specialty. 

*   (this code moved from alter in the code to here as doctor data is needed to verify below info)
    perform tb0-read-doc                thru    tb0-99-exit. 
    if doc-found 
    then 
        perform ea11-check-doctor-specialty    thru    ea11-99-exit 
* 	(oscar dept is picked up from f200 so can't be wrong)
        move doc-dept				to	unpriced-bathdr-dept
        perform ea12-check-dept-no              thru    ea12-99-exit 

*       brad - provider nbr not needed to be checked? TODO
*	*perform ea13-check-provider-nbr         thru    ea13-99-exit 
*brad1 - don't do at this point - it's using the batch clinicnbr rather than the HEH clinic
*       perform ea14-check-doctor-clinic        thru    ea14-99-exit
    else 
*       (error - write report and skip batch) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 2                          to      err-ind 
	move ws-error-literal		to	err-warn-msg
        move unpriced-bathdr-oscar-doc-id     to      err-msg-doc-nbr 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*       go to ea0-99-exit. 



*    (use the incoming value as the subscript to grab clinic from doctor's record)
*    ONLY for batch to read payroll - see HEH for actual claim by claim clinic
*be7 moved this check to HEH record processing
*     perform fa9-get-clinic			thru fa9-get-clinic.

* be4 - the clinic nbr in batch header record ignore - clinic/payroll check done on each record now so code moved to new location
* if unpriced-bathdr-clinic-1-2 = 85  
*     then
*	move "B"			to ws-default-payroll-flag
*     else
*	move "A"			to ws-default-payroll-flag.
*   endif

* brad - doesn't work - no batch -loc in file as yet???
*   brad3 - processing header location - IGNORE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11
    if unpriced-default-batch-loc not = " " 
    then 
       move unpriced-default-batch-loc	to ws-default-batch-location 
    else 
       move spaces                        	to ws-default-batch-location. 
*   endif 
 
    if unpriced-default-batch-i-o-ind not = " " 
    then 
       move unpriced-default-batch-i-o-ind	to ws-default-batch-i-o-ind 
    else 
       move spaces                        	to ws-default-batch-i-o-ind. 
*   endif 
 
*be7 moved this check to HEH record processing
*    perform ea10-determine-clinic-nbr   thru    ea10-99-exit. 
**   (check if error - shut down) 
*    if fatal-error 
*    then 
*        go to ea0-99-exit. 
**   endif 

*   (move this read earlier in the code as doctor data is needed to verify above info)
*    perform tb0-read-doc                thru    tb0-99-exit. 
*    if doc-found 
*    then 
*        perform ea11-check-doctor-specialty    thru    ea11-99-exit 
** 	(oscar dept is picked up from f200 so can't be wrong)
*        move doc-dept				to	unpriced-bathdr-dept
*        perform ea12-check-dept-no              thru    ea12-99-exit 
*
*        perform ea13-check-provider-nbr         thru    ea13-99-exit 
*        perform ea14-check-doctor-clinic        thru    ea14-99-exit
*    else 
**       (error - write report and skip batch) 
*        move "Y"                        to      fatal-error-flag 
*        move 2                          to      ws-carriage-ctrl 
*        move 2                          to      err-ind 
*	move ws-error-literal		to	err-warn-msg
*        move unpriced-bathdr-oscar-doc-id     to      err-msg-doc-nbr 
*        perform zb0-build-write-err-rpt-line 
*                                        thru    zb0-99-exit. 
**       GO TO EA0-99-EXIT. 
**   endif 
 
ea0-99-exit. 
    exit. 

*brad
fa9-get-clinic.
     if unpriced-bathdr-clinic-1-2 = 00
     then
	move doc-clinic-nbr of oscar-provider-rec	to 	unpriced-bathdr-clinic-1-2
     else
     if unpriced-bathdr-clinic-1-2 = 01
     then
	move doc-clinic-nbr-2 of oscar-provider-rec	to 	unpriced-bathdr-clinic-1-2
     else
     if unpriced-bathdr-clinic-1-2 = 02
     then
	move doc-clinic-nbr-3 of oscar-provider-rec	to 	unpriced-bathdr-clinic-1-2
     else
     if unpriced-bathdr-clinic-1-2 = 03
     then
	move doc-clinic-nbr-4 of oscar-provider-rec	to 	unpriced-bathdr-clinic-1-2
     else
     if unpriced-bathdr-clinic-1-2 = 04
     then
	move doc-clinic-nbr-5 of oscar-provider-rec	to 	unpriced-bathdr-clinic-1-2
     else
     if unpriced-bathdr-clinic-1-2 = 05
     then
	move doc-clinic-nbr-6 of oscar-provider-rec 	to 	unpriced-bathdr-clinic-1-2.
*    end case
*brad
*     move unpriced-bathdr-clinic-1-2			to	bt-clinic-nbr-1-2
*							   	ws-default-clinic-nbr.
*brad1 uncomment above
     move unpriced-bathdr-clinic-1-2			to	bt-clinic-nbr-1-2
							   	ws-default-clinic-nbr.

fa9-99-exit.
  exit

 
ea10-determine-clinic-nbr. 
 
    move "N"                            to flag-clinic. 
 
    perform ea10a-search-clinic-tbl     thru ea10a-99-exit 
        varying sub 
        from   1 
        by     1 
        until   sub > const-max-nbr-clinics 
             or clinic-found. 
 
*   (diskettes from non-web sites don't all have the clinic in 
*    the submission file - therefore if the clinic is zero 
*    don't give an error but allow the operator to have specified 
*    a clinic) 
    if    clinic-not-found 
* 2003/10/22 - MC - the size has changed from 4 to 2
*      and ws-default-clinic-nbr         = 0000
      and ws-default-clinic-nbr         = 00
* 2003/10/22 - end
    then 
*       (error - clinic on diskette is bad and no override 
*	 default clinic was specified by the operator) 
        move "Y"                        to      fatal-error-flag 
        move 2                          to      ws-carriage-ctrl 
        move 6                          to      err-ind 
	move ws-error-literal		to	err-warn-msg
        move batch-group-nbr            to      err-msg-clinic-id 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
    else 
        if    clinic-not-found 
* 2003/10/22 - MC - the size has changed from 4 to 2
*          and ws-default-clinic-nbr     not = 0000
          and ws-default-clinic-nbr     not = 00
* 2003/10/22 - end
  	then 
*	    (clinic is bad but override default clinic was specified) 
            move ws-default-clinic-nbr	to      unpriced-bathdr-clinic-1-2 
            move ws-default-clinic-nbr	to	bt-clinic-nbr-1-2 
            move ws-default-clinic-nbr	to 	batch-group-nbr. 
*        endif 
*   endif 
 
ea10-99-exit. 
    exit. 
 
 
 
ea10a-search-clinic-tbl. 
*   (97/sep/25 b.e. logic changed for web site file) 
*   IF BATCH-GROUP-NBR           = CONST-CLINIC-NBR-1-2 (SUB) 
    if unpriced-bathdr-clinic-1-2 = const-clinic-nbr-1-2 (sub) 
    then 
         move const-clinic-nbr-1-2 (sub) to bt-clinic-nbr-1-2 
         move const-clinic-nbr     (sub) to batch-group-nbr 
         move 'Y'                        to flag-clinic. 
*   endif 
 
ea10a-99-exit. 
    exit. 
 
 
ea11-check-doctor-specialty. 
 
    if    batch-specialty not = doc-spec-cd 
      and batch-specialty not = doc-spec-cd-2 
      and batch-specialty not = doc-spec-cd-3 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 4                          to      err-ind 
        move batch-specialty           to      err-msg-batch-spec-cd 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 5                          to      err-ind 
        move doc-spec-cd                to      err-msg-doc-spec-cd 
        move doc-spec-cd-2              to      err-msg-doc-spec-cd-2 
        move doc-spec-cd-3              to      err-msg-doc-spec-cd-3 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit. 
*   endif 
 
 
ea11-99-exit. 
    exit. 
 
 
ea12-check-dept-no. 
 
    if    unpriced-bathdr-dept  not = doc-dept 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 32                         to      err-ind 
        move unpriced-bathdr-dept        to      err-msg-batch-dept-no 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 33                         to      err-ind 
        move doc-dept                   to      err-msg-doc-dept-no 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit. 
*   endif 
 
ea12-99-exit. 
    exit. 
 
 
ea13-check-provider-nbr. 

*   brad below 
*      debug display  unpriced-clmhdr-hc-ohip-nbr.
    if    unpriced-bathdr-prov-ohip-no   not = doc-pract-nbr 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 35                         to      err-ind 
        move unpriced-bathdr-prov-ohip-no to     err-msg-batch-prov-nbr 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 36                         to      err-ind 
        move doc-pract-nbr              to      err-msg-doc-prov-nbr 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit. 
*   endif 
 
ea13-99-exit. 
    exit. 

* 2003/10/22 - MC - add this new subroutine
ea14-check-doctor-clinic.

    if    bt-clinic-nbr-1-2 not = doc-clinic-nbr   of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr   of oscar-provider-rec 
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-2 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-2 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-3 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-3 of oscar-provider-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-4 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-4 of oscar-provider-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-5 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-5 of oscar-provider-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-6 of doc-mstr-rec
      and bt-clinic-nbr-1-2 not = doc-clinic-nbr-6 of oscar-provider-rec
      and not price-only-claim
    then
        move ws-error-literal           to      err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit
        move 1                          to      ws-carriage-ctrl
        move 57                         to      err-ind
        move bt-clinic-nbr-1-2          to      err-msg-doc-clinic
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.
*   endif

ea14-99-exit.
    exit.

* 2003/10/22 - end

 
fa0-proc-rec-type-header1. 
 
*   (processing a new HEADER rec. If there were detail records in hold area 
*    from the previous claim header rec then area process them - ie. price 
*    them and write them out) 
    perform xx0-process-hold-dtls	thru xx0-99-exit. 
 
    move "N"                          to   skip-process-this-acct-id-flag.

*be7
*brad
*    perform fa9-get-clinic			thru fa9-99-exit.
*    (use the incoming value as the subscript to grab clinic from doctor's record)
*    ONLY for batch to read payroll - see HEH for actual claim by claim clinic
*be7 moved this check to here so that gets clinic from HEH record  not HEB record
     perform fa9-get-clinic                    thru fa9-get-clinic.
     perform ea10-determine-clinic-nbr   thru    ea10-99-exit.
*   (check if error - shut down)
    if fatal-error
    then
	go to ea0-99-exit.
*   endif

    perform fb0-build-susp-hdr-rec      thru fb0-99-exit. 

*   (if error found processing this record, skip processing dtl/addr part of record) 
    if skip-processing-this-acct-id 
    then 
        go to fa0-99-exit. 
*   endif 
 
*mf    perform fd0-build-susp-addr-rec-from-hdr1 
    perform fd0-build-susp-addr-rec-hdr1
                                        thru    fd0-99-exit. 
 
*   (moved to just before all details are written out so that total 
*    amount of priced claim can be updated into header) 
*   perform tc0-write-hdr-rec           thru    tc0-99-exit. 
 
    move 0                              to      ctr-hdr2-rec
                                                ctr-addr-rec.
fa0-99-exit. 
    exit. 



fb0-build-susp-hdr-rec. 
 
*  (if 'RMB' claim output header/address records) 
    if   last-record-is-h 
      or detail-written
    then 
        move 'N'                        to   detail-written-flag 
*       (header written out with details in xx0) 
*         perform tc0-write-hdr-rec       thru tc0-99-exit 
        perform tf0-write-addr-rec      thru tf0-99-exit. 
*   endif 
 
*   move diskette-input-rec-data        to      header-rec. 
*   98/04/06 mc - initialize header-rec 
    move spaces				to	header-rec. 
    move zeroes				to	hdr-birth-date
						hdr-birth-date-dd
						hdr-refer-pract-nbr
						hdr-admit-yy
						hdr-admit-mm
						hdr-admit-dd.

*   (incoming claim/accounting nbr moved to hold area so it can 
*    be written back out to the unpriced(diskette-out) files 
 
    move spaces                          to      suspend-hdr-rec. 

* 2013/07/03 - MC31 - transfer from below 
     move unpriced-clmhdr-claim           to      hold-accounting-nbr. 
     move unpriced-clmhdr-claim           to      hdr-accounting-nbr. 
     move doc-nbr of doc-mstr-rec         to      clmhdr-doc-nbr. 
* 2013/07/03 - end

*brad
*debug     display  unpriced-clmhdr-hc-ohip-nbr. 
* brad OK - below two are VALID - surname is NOT --------- FOR HEP
* brad OK - below two are VALID - surname is NOT - REVERSD FOR HEH
    move unpriced-clmhdr-health-nbr     to      hdr-health-care-nbr.
    move unpriced-clmhdr-pat-ohip-nbr	to 	hdr-ohip-nbr.
*be6
    move  unpriced-clmhdr-hc-prov-cd    to 	hdr-health-care-prov
    move unpriced-clmhdr-hc-ohip-nbr    to	hdr-ohip-nbr.

*    move unpriced-clmhdr-pat-surname     to clmhdr-patient-surname. 
*   brad
    move unpriced-clmhdr-pat-surname2   to clmhdr-patient-surname. 
* brad - moved  here since ga0- not longed called !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
* TODO MOVE
* brad     move unpriced-clmhdr-pat-surname     to clmhdr-pat-acronym6 
*brad     move unpriced-clmhdr-pat-surname     to clmhdr-patient-surname. 
     move unpriced-clmhdr-pat-surname2    to clmhdr-pat-acronym6 
     move unpriced-clmhdr-pat-surname2    to clmhdr-patient-surname. 
*brad      move unpriced-clmhdr-given-name2     to clmhdr-pat-given-name.
*brad surname 2 OK!!
     move unpriced-clmhdr-given-name2     to clmhdr-pat-acronym3 

*    move unpriced-clmhdr-given-name      to clmhdr-pat-acronym3 
*    move unpriced-clmhdr-given-name      to clmhdr-pat-acronym3 
*                                           clmhdr-subscr-initials. 
*    move clmhdr-pat-acronym		to susp-hdr-acronym.
*brad
* TODO MOVE?????
*brad 
*brad    move unpriced-clmhdr-health-nbr     to      hdr-health-care-nbr.
*brad    move unpriced-clmhdr-pat-ohip-nbr	to 	hdr-ohip-nbr.
*brad     move unpriced-clmhdr-pat-surname     to clmhdr-patient-surname. 

*brad - use hosp-nbr field instead of batch lcation
    if unpriced-clmhdr-hosp-nbr not = " " 
    then 
	move unpriced-clmhdr-hosp-nbr   to ws-default-batch-location 
					   clmhdr-loc
    else 
       move spaces                      to ws-default-batch-location
				           clmhdr-loc. 
*   endif 

* below moved elsewhere since header rec not longer processed 
*brad
*    if unpriced-clmhdr-hc-prov-cd = spaces 
*    then 
*        move 'ON'                       to      hdr-health-care-prov 
*    else 
*        move unpriced-clmhdr-hc-prov-cd     to      hdr-health-care-prov. 
**   endif 
 
    move 'N'                            to      province-flag. 
    perform fb0a-search-province        thru    fb0a-99-exit 
            varying sub from 1 by 1 
            until (province-found or sub > 11). 
 
 
    if    province-not-found 
      and not price-only-claim
*        brad1
      and not unpriced-clmhdr-pay-pgm  = "PAT"
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 30                         to      err-ind 
        move hdr-health-care-prov       to      err-province 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*       MOVE "??"                       TO      CLMHDR-HEALTH-CARE-PROV 
*   ELSE 
*       brad1
*       move hdr-health-care-prov       to      clmhdr-health-care-prov. 
	if hdr-health-care-prov	= " " 
	then
	    move "ON"			to	clmhdr-health-care-prov
  	else
*be6
            move hdr-health-care-prov       to      clmhdr-health-care-prov. 
*	endif 

******************   


* 2001/02/07 - MC - save RMB registration nbr 
* ///////////////// TODO - not ohip-nbr at this point for RMB patients !!!!!!!!!!

    if hdr-health-care-prov not = 'ON'  and
       unpriced-clmhdr-pat-ohip-nbr not = spaces and
       unpriced-clmhdr-pat-ohip-nbr not = zeroes
    then
	move unpriced-clmhdr-pat-ohip-nbr	to hdr-ohip-nbr.
*   endif

******************   
* brad4 - test only for HCP and RMB claims
    if hdr-health-care-prov = 'ON' 
        and (   unpriced-clmhdr-pay-pgm = "HCP"
             or unpriced-clmhdr-pay-pgm = "RMB"
	    )
    then 
        if    hdr-health-care-nbr = spaces 
          and not price-only-claim
        then 
	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
            move 1                      to      ws-carriage-ctrl 
            move 29                     to      err-ind 
            move hdr-health-care-nbr 
                                        to      err-health-care-nbr 
            perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
            move "??????????"           to      clmhdr-health-care-nbr 
        else 
            move hdr-health-care-nbr    to      ws-nbr-10 
            if   (   ws-nbr-10 not numeric 
                  or ws-nbr-10 = zero 
		 )
              and not price-only-claim
            then 
		move ws-error-literal	to	err-warn-msg
                perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
                move 1                  to      ws-carriage-ctrl 
                move 29                 to      err-ind 
                move hdr-health-care-nbr 
                                        to      err-health-care-nbr 
                perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
                move "??????????"       to      clmhdr-health-care-nbr 
            else 
                move hdr-health-care-nbr 
                                        to      ws-check-nbr-10 
                perform db0a-mod10-check-digit-10 thru  db0a-99-exit 
                if    flag = 'N' 
                  and not price-only-claim
                then 
		    move ws-error-literal	to	err-warn-msg
                    move hold-accounting-nbr    to      hdr-accounting-nbr
                    perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
                    move 1              to      ws-carriage-ctrl 
                    move 29             to      err-ind 
                    move hdr-health-care-nbr to err-health-care-nbr 
                    perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
                    move "??????????"   to      clmhdr-health-care-nbr 
                else 
*               (DATA IS OK - HAS ALREADY BEEN MOVED INTO CLMHDR FIELDS 
                    next sentence. 
*               endif 
*           endif 
*       endif 
*   endif 
 
*   (DETERMINE IF VALID SIZE OF OHIP NBR FOR OUT OF PROVINCE PATIENT) 
 
* 2005/06/23 - MC - change from NF to NL
* if hdr-health-care-prov = 'NF' 
    if hdr-health-care-prov = 'NL' 
* 2005/06/23 - end
    then 
        if   (    nf-ohip-nbr is not numeric 
              or (nf-ohip-nbr = spaces or zeros) 
	     )
          and not price-only-claim
        then 
	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
***
*       endif 
    else 
* 2001/02/12 - MC - ohip nbr size has changed
*   if hdr-health-care-prov = 'AB' or 'NS' 
    if hdr-health-care-prov = 'BC' or 'NS' 
    then 
*       if      (ab-ns-11-digits is not numeric) 
*           or  (ab-ns-11-digits =  spaces or zeros) 
*           or  (ab-ns-last-digits not = spaces) 
        if   (    (bc-ns-10-digits is not numeric) 
              or  (bc-ns-10-digits =  spaces or zeros) 
              or  (bc-ns-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
*   if hdr-health-care-prov = 'BC' 
    if hdr-health-care-prov = 'PE' 
    then 
*       if      (bc-10-digits is not numeric) 
*           or  (bc-10-digits =  spaces or zeros) 
*           or  (bc-last-digits not = spaces) 
        if   (    (pe-8-digits is not numeric) 
              or  (pe-8-digits =  spaces or zeros) 
              or  (pe-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
*   if hdr-health-care-prov = 'NB' or 'PE' or 'SK' or 'YT' 
    if hdr-health-care-prov = 'AB' or 'NB' or 'SK' or 'YT' 
    then 
*       if      (nb-pe-sk-yt-9-digits is not numeric) 
*           or  (nb-pe-sk-yt-9-digits =  spaces or zeros) 
*           or  (nb-pe-sk-yt-last-digits not = spaces) 
        if   (    (ab-nb-sk-yt-9-digits is not numeric) 
              or  (ab-nb-sk-yt-9-digits =  spaces or zeros) 
              or  (ab-nb-sk-yt-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
    if hdr-health-care-prov = 'NT' 
    then 
        if   (    (nt-first-digit is not alphabetic) 
              or  (nt-first-digit =  spaces) 
              or  (nt-7-digits is not numeric) 
              or  (nt-7-digits =  spaces or zeros) 
              or  (nt-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
    if hdr-health-care-prov = 'MB' 
    then 
* 2005/06/23 - MC - Manitoba should be 9 digits
*        if   (    (mb-6-digits is not numeric)
*             or  (mb-6-digits =  spaces or zeros)
        if   (    (mb-9-digits is not numeric)
              or  (mb-9-digits =  spaces or zeros)
* 2005/06/23 - end
              or  (mb-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr.
*       endif 
*   endif 
* brad end 

* 2013/Oct/01 - MC31 - must comment out; otherwise clmhdr-doc-nbr will always get '000' because
*			clmhdr-doc-nbr is overlay from clmhdr-batch-nbr

*    move zeroes				 to 	clmhdr-batch-nbr. 

*  MC31 - not sure why Brad is checking below???
*  brad 
**    if unpriced-clmhdr-claim = "00000039" or unpriced-clmhdr-claim = "00000042"
**    then
**        move unpriced-clmhdr-claim           to      hold-accounting-nbr. 
*   endif
* 2013/Oct/01 -end

* 2013/07/03 - MC31 - transfer to above before edit check
*    move unpriced-clmhdr-claim           to      hold-accounting-nbr. 
*    move unpriced-clmhdr-claim           to      hdr-accounting-nbr. 
*    move doc-nbr of doc-mstr-rec     	 to      clmhdr-doc-nbr. 
* 2013/07/03 - end

*brad
*be2 moved this assignment to later in the rtn
*   move unpriced-clmhdr-agent-cd	to	clmhdr-agent-cd
*					        hdr-agent-cd.

*   move unpriced-confidentiality-flag       

* brad
*    move unpriced-clmhdr-loc-code	to	hdr-loc-code.
* TODO BUG in incoming file - hosp-nbr and location revsersed.
    move unpriced-clmhdr-hosp-nbr	to	hdr-loc-code.
    perform fb04b-read-loc-mstr		thru	fb04b-99-exit.

    move loc-in-out-ind 		to	unpriced-clmhdr-i-o-ind
						clmhdr-i-o-pat-ind
			         		hdr-i-o-ind. 
   if unpriced-clmhdr-agent-cd = " " or unpriced-clmhdr-agent-cd = "0" 
*
*  (if agent not on incoming record then calculate based upon pay_pgm0
   then
	if unpriced-clmhdr-pay-pgm = "HCP" 
	then
	    move "0"			to unpriced-clmhdr-agent-cd
	else
*				     (reciprocol)
	if unpriced-clmhdr-pay-pgm = "RMB" 
	then
	    move "0"			to unpriced-clmhdr-agent-cd
	else
*				      (direct bill to patient/insurance)
	if unpriced-clmhdr-pay-pgm  = "PAT" 
	then
	    move "6"			to unpriced-clmhdr-agent-cd
	else
*				   (Workman comp - with health nbr)
*be1	if      unpriced-clmhdr-pay-pgm = "HCP" 
	if      unpriced-clmhdr-pay-pgm = "WCB" 
	    and unpriced-clmhdr-health-nbr <> "          " 
	    and unpriced-clmhdr-health-nbr <> "0000000000" 
	then
	    move "2"			to unpriced-clmhdr-agent-cd
	else
*				   (Workman comp - no health nbr)
	if      unpriced-clmhdr-pay-pgm  = "WCB" 
* brad
*	    and (    unpriced-clmhdr-health-nbr =  "          "
*		  or unpriced-clmhdr-health-nbr <> "0000000000"
*		) 
	then
	    move "9"			to unpriced-clmhdr-agent-cd
	else
*			          (DON'T BILL PATIENT)
	if unpriced-clmhdr-pay-pgm  = "NOT" 
	then
	    move "5"			to unpriced-clmhdr-agent-cd
	else
	    move "?"			to unpriced-clmhdr-agent-cd.
*	end if

* be2
   move unpriced-clmhdr-agent-cd	to	clmhdr-agent-cd
					        hdr-agent-cd.

*be3 below checks moved to this location so that alter agent-cd can be tested
*   (SET INDICATOR TO ASSUME THAT CLAIM CAN BE SUBMITTED ON TAPE - WHEN 
*    ACTUAL CLAIM IS BUILT THE DETAILS WERE BE CHECKED TO ENSURE THAT 
*    THIS INDICATOR IS SET CORRECLTY) 
    if clmhdr-agent-cd = 0 or 2 
    then 
        move "Y"                        to      clmhdr-tape-submit-ind 
    else 
        move "N"                        to      clmhdr-tape-submit-ind. 
*   endif 

*2001/02/28 - MC- if agent = 6 or 9, set clmhdr-status = 'I'gnore
    if clmhdr-agent-cd = 6 or 9
    then 
	move "I"			to 	clmhdr-status.
*   endif
* be3 - end

* be4 - moved from elsewhere to here where default can be made
* be4 - the clinic nbr in batch header record ignore - clinic/payroll check done on each record now so code moved to new location
    if unpriced-bathdr-clinic-1-2 = 85  
      then
 	move "B"			to ws-default-payroll-flag
      else
 	move "A"			to ws-default-payroll-flag.
*   endif

*be6 - below move blanks - changed to valid data
*    move unpriced-clmhdr-health-nbr      to      hdr-health-care-nbr.
* this code didn't help!
*    if unpriced-clmhdr-health-nbr = spaces 
*     then
* 	move unpriced-clmhdr-hc-prov-cd 	to hdr-health-care-prov
*   	move unpriced-clmhdr-hc-ohip-nbr        to hdr-health-care-nbr.
**   endif

    if unpriced-clmhdr-birth-date = spaces
    then
	move zeroes			to 	hdr-birth-date-long
    else
    	move unpriced-clmhdr-birth-date  to      hdr-birth-date-long.
*   endif

    inspect unpriced-clmhdr-ref-doc-nbr replacing all space-char by zeros.
    if unpriced-clmhdr-ref-doc-nbr = spaces       
    then
	move zeroes			to	hdr-refer-pract-nbr
    else
	move unpriced-clmhdr-ref-doc-nbr to      hdr-refer-pract-nbr. 
    move unpriced-clmhdr-hosp-nbr        to      hdr-hosp-nbr. 
    move unpriced-clmhdr-man-review      to      hdr-manual-review. 
    if unpriced-clmhdr-admit-date = spaces
    then
	move zeroes			to 	hdr-admit-date
    else
    	move unpriced-clmhdr-admit-date  to      hdr-admit-date. 
*   endif
    move unpriced-clmhdr-version-cd      to      hdr-health-care-ver. 
 
    move zeros                          to      clmhdr-zeroed-oma-suff-adj. 
    move "C"                            to      clmhdr-batch-type. 

*   (00/sep/21 B.E. distinguish between "D"iskette and "W"eb claims")
    move flag-claim-source		to	clmhdr-claim-source-cd.

*brad
*   move bt-clinic-nbr-1-2              to      clmhdr-clinic-nbr-1-2. 
    move unpriced-bathdr-clinic-1-2	to 	bt-clinic-nbr-1-2
						clmhdr-clinic-nbr-1-2. 
 
    move batch-provider-nbr         to      clmhdr-doc-nbr-ohip. 
 
    move batch-specialty           to      clmhdr-doc-spec-cd. 
 
*   (REFERRING PHY. SPECIFIED - ENSURE THAT NBR IS VALID) 
    if hdr-refer-pract-nbr not = spaces and not = zeros 
    then 
        perform fb02-verify-referring-phys-nbr 
                                        thru    fb02-99-exit 
        move hdr-refer-pract-nbr    to      clmhdr-refer-doc-nbr. 
*       endif 
*   endif 
 
*2000/11/27 - MC - if referring doc nbr is blank for clinic 60's, set
*		   referring doc-nbr to be the same as original doc-nbr
    if     hdr-refer-pract-nbr = 0	
      and (    bt-clinic-nbr-1-2 >= 61 
* 2011/07/07 - MC17 - include clinic 66
*          and bt-clinic-nbr-1-2 <= 65
           and bt-clinic-nbr-1-2 <= 66
* 2011/07/07 - end
	  )
	then  
	    move batch-provider-nbr     to clmhdr-refer-doc-nbr.
*	    endif

*2007/08/16 - MC - if referring doc nbr is blank for clinic 70's, set
*		   referring doc-nbr to be the same as original doc-nbr
    if     hdr-refer-pract-nbr = 0	
      and (    bt-clinic-nbr-1-2 >= 71 
	   and bt-clinic-nbr-1-2 <= 75
	  )
	then  
	    move batch-provider-nbr     to clmhdr-refer-doc-nbr.
*	    endif
* 2007/08/16 - end
 
*   (determine if hospital nbr is required, and if so that the code is valid - 
*    - if valid, replace 4 digit hospital number with 1 character code) 
*       (hospital nbr specified - ensure that nbr is valid and translate to hosp code) 


*2000/03/20 - MC - comment out the following if condition
*    if    hdr-hosp-nbr not = spaces and not = zeros 
*      and not price-only-claim
*    then 
*       perform fb05-verify-hospital    thru    fb05-99-exit 
*       if clmhdr-hosp = "?" 
*       then 
*           perform xb0-print-warning-line 
*                                       thru    xb0-99-exit 
*           move 1                      to      ws-carriage-ctrl 
*           move 23                     to      err-ind 
*           move hdr-hosp-nbr           to      err-hosp-nbr, clmhdr-hosp 
*           perform zb0-build-write-err-rpt-line 
*                                       thru    zb0-99-exit. 
*       endif 
*   endif 
 
*   (if requested by operator, set all blank agent codes to 'OHIP') 
*   98/03/31 mc - also set clmhdr-tape-submit-ind to 'Y' and 
*		  clmhdr-agent-cd = '0' 
    if ws-agent-default-reply = "Y" 
    then 
 	move "Y"			to	clmhdr-tape-submit-ind 
        move "0"                        to      clmhdr-agent-cd 
        move "0"                        to      hdr-agent-cd. 
*   endif 
 
*   MOVE ZEROS                          TO      CLMHDR-ADJ-CD. 
    move spaces                         to      clmhdr-adj-cd. 
 
 
    move zero                           to      clmhdr-status-ohip. 
 
    move spaces                         to      clmhdr-reference. 
 
*   (non-rma-enhanced submissions don't have a location in the header 
*    records.  check the 'HEB' batch header record to see if rma has 
*    input a default value to use for all claims in the batch and 
*    override if required) 

*   brad  - location picked up in HEH recordn other code 
*  if    (   hdr-loc-code = ws-4-nulls 
*           or hdr-loc-code = spaces) 
*      and ws-default-batch-location not = spaces 
*    then 
*	move ws-default-batch-location	to clmhdr-loc. 
**   endif 
 
*   (non-rma-enhanced submissions don't have a patient i/o indicator in the 
*    hdr records.  check the 'HEB' batch header record to see if rma has 
*    input a default value to use for all claims in the batch and 
*    override if required) 
 
    if    (   hdr-i-o-ind = ws-1-null 
           or hdr-i-o-ind = spaces) 
      and ws-default-batch-i-o-ind not = spaces 
    then 
	move ws-default-batch-i-o-ind	to clmhdr-i-o-pat-ind. 
*   endif 

*   brad
    move unpriced-clmhdr-pat-acronym 	to clmhdr-pat-acronym. 
 
    if hdr-admit-date not = spaces and not = zeros 
    then 
*       (ADMIT DATE SPECIFIED - ENSURE THAT DATE IS VALID) 
        move hdr-admit-yy               to      ws-date-yy 
        move hdr-admit-mm               to      ws-date-mm 
        move hdr-admit-dd               to      ws-date-dd 
        perform xd0-verify-date thru    xd0-99-exit 
        if     invalid-date 
	   and not price-only-claim
        then 
	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
            move 1                      to      ws-carriage-ctrl 
            move 26                     to      err-ind 
            move hdr-admit-date         to      err-admit-date 
            perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*           MOVE "??????"               TO      CLMHDR-DATE-ADMIT 
*       ELSE 
            move hdr-admit-yy           to      clmhdr-date-admit-yy
            move hdr-admit-mm           to      clmhdr-date-admit-mm
            move hdr-admit-dd           to      clmhdr-date-admit-dd. 
*       endif 
*   endif 
 

* 2004/04/07 - MC
    if hdr-admit-date not = spaces and not = zeros
    then
*       (ADMIT DATE SPECIFIED - ENSURE THAT DATE IS greater than birth date)
        if     hdr-admit-date < hdr-birth-date-long
           and not price-only-claim
        then
            move ws-error-literal       to      err-warn-msg
            perform xb0-print-warning-line
                                        thru    xb0-99-exit
            move 1                      to      ws-carriage-ctrl
            move 58                     to      err-ind
            move hdr-admit-date         to      err-58-admit-date
            move hdr-birth-date-long    to      err-58-birth-date
            perform zb0-build-write-err-rpt-line
                                        thru    zb0-99-exit
            move "????????"             to      clmhdr-date-admit.
*       endif
*   endif
* 2004/04/07 - end

 
    move sys-date                       to      clmhdr-date-sys. 
    move doc-dept                       to      clmhdr-doc-dept. 
    move zero                           to      clmhdr-curr-payment 
*mf                                             clmhdr-manual-and-tape-paymnts 
                                                clmhdr-amt-tech-billed 
                                                clmhdr-amt-tech-paid. 
 
    if hdr-health-care-nbr not = spaces and not = zeros 
    then 
        move hdr-health-care-nbr        to      clmhdr-health-care-nbr 
*       (THE FOLLOWING TWO MOVE STMT ADDED ON 91/04/23 BY M.C. - MOVED TO 
*        NEW LINES NUMBER BY B.L. 91/SEP/05) 
        move hdr-health-care-nbr        to      clmhdr-pat-key-data 
        move "O"                        to      clmhdr-pat-key-type. 
*   endif 
 
    move hdr-health-care-ver            to      clmhdr-health-care-ver. 
 
*   (CHECK THE RELATIONSHIP FIELD) 
*   IF HDR-RELATIONSHIP =  SPACES 
*                        OR 'Y' 
*                        OR 'N' 
*    THEN 
*        MOVE HDR-RELATIONSHIP           TO      CLMHDR-RELATIONSHIP 
*    ELSE 
*        PERFORM XB0-PRINT-WARNING-LINE 
*                                       THRU    XB0-99-EXIT 
*        MOVE 1                          TO      WS-CARRIAGE-CTRL 
*        MOVE 46                         TO      ERR-IND 
*        MOVE HDR-RELATIONSHIP           TO      ERR-RELATIONSHIP 
*        PERFORM ZB0-BUILD-WRITE-ERR-RPT-LINE 
*                                        THRU    ZB0-99-EXIT 
*        MOVE HDR-RELATIONSHIP           TO      CLMHDR-RELATIONSHIP. 
**       MOVE "?"                        TO      CLMHDR-RELATIONSHIP. 
**   endif 
 
*   (CHECK THE MANUAL REVIEW INDICATOR) 
    if  hdr-manual-review =  spaces 
                          or 'Y' 
                          or 'N' 
    then 
        move hdr-manual-review              to      clmhdr-manual-review 
    else 
        if not price-only-claim
	then
	    move ws-warning-literal	    to      err-warn-msg
            perform xb0-print-warning-line  thru    xb0-99-exit 
            move 1                          to      ws-carriage-ctrl 
            move 31                         to      err-ind 
            move hdr-manual-review          to      err-manual-review 
            perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
            move hdr-manual-review          to      clmhdr-manual-review. 
*	endif
*   endif 

*   (00/sep/14 B.E.)
*   (number of description records set to zero here and updated by
*    program that processes the description record upload file)
*    move 0				to clmhdr-nbr-suspend-desc-recs.
 
    move doc-pract-nbr                  to      clmhdr-doc-pract-nbr. 
    move hdr-accounting-nbr             to      clmhdr-accounting-nbr. 
    if hdr-accounting-nbr = "00000020" then
 	move hdr-accounting-nbr             to      clmhdr-accounting-nbr. 
*   endif 
 
* 2010/08/12 - MC7 
    move clmhdr-doc-nbr 		to 	susp-hdr-doc-nbr. 
    move bt-clinic-nbr-1-2              to      susp-hdr-clinic-nbr.
    move hold-accounting-nbr		to 	susp-hdr-accounting-nbr.
* 2010/08/12 - end

fb0-99-exit. 
    exit. 
 
fb0a-search-province. 
 
    if hdr-health-care-prov = prov(sub) 
    then 
        move "Y"                        to province-flag. 
*   endif 
 
fb0a-99-exit. 
    exit. 
 
 
fb02-verify-referring-phys-nbr. 
 
*   MOVE HDR-REFER-PRACT-NBR            TO      WS-CHK-IND. 
*   MOVE "Y"                            TO      FLAG-REFER-PHYS. 
 
    move hdr-refer-pract-nbr            to      ws-chk-nbr. 
*   IF      WS-CHK-NBR     = ZEROES 
        if  ws-chk-nbr-8   = 1 
        or  ws-chk-nbr-8   = 2 
    then 
        perform dc0-mod10-check-digit-for-1-2 thru dc0-99-exit 
    else perform db0-mod10-check-digit  thru    db0-99-exit. 
*   endif 
 
    move flag                           to      flag-refer-phys. 
 
    if    invalid-refer-phys 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 12                         to      err-ind 
        move hdr-refer-pract-nbr        to      err-refer-phys-nbr 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit. 
*   endif 

    if    hdr-refer-pract-nbr = batch-provider-nbr
* 2007/08/16 - MC - include 70's check
*      and (   bt-clinic-nbr-1-2 < 60 
*	   or bt-clinic-nbr-1-2 > 65
      and (   bt-clinic-nbr-1-2 < 60 
	   or bt-clinic-nbr-1-2 > 75
* 2007/08/16 - end
	  )
      and not price-only-claim
    then
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit
        move 1                          to      ws-carriage-ctrl
        move 47                         to      err-ind
*2000/03/20 - MC
*       move unpriced-clmhdr-ref-doc-nbr to      err-msg-referring-doc
*       move unpriced-bathdr-prov-ohip-no to     err-msg-provider-doc
*
        move hdr-refer-pract-nbr        to      err-msg-referring-doc
        move batch-provider-nbr          to     err-msg-provider-doc
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit.

*** S.B. - end.

fb02-99-exit. 
    exit. 
 
fb03-verify-diag-code. 
 
    move "Y"                            to      flag-diag-cd. 
*mf    read diag-mstr      suppress data record 
       read diag-mstr
        invalid key 
            if not price-only-claim
	    then
		move ws-error-literal		to	err-warn-msg
	        perform xb0-print-warning-line  thru    xb0-99-exit 
	        move 1                          to      ws-carriage-ctrl 
	        move 14                         to      err-ind 
	        move diag-cd                    to      err-diag-code 
	        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
	        move            'N'             to      flag-diag-cd. 
*	    endif
 
fb03-99-exit. 
    exit. 


fb04-verify-doc-location. 
 
*   (NON-RMA-ENHANCED SUBMISSIONS DON'T HAVE A LOCATION IN THE HEADER 
*    RECORDS.  CHECK THE 'HEB' BATCH HEADER RECORD TO SEE IF RMA HAS 
*    INPUT A DEFAULT VALUE TO USE FOR ALL CLAIMS IN THE BATCH AND 
*    OVERRIDE IF REQUIRED) 
 
    if    Hdr-loc-code = spaces 
      and ws-default-batch-location not = spaces 
      and not price-only-claim
    then 
	move ws-default-batch-location	to hdr-loc-code. 
*   endif 
 
    move 'N'                            to      flag-location. 
    if hdr-loc-code not = spaces 
    then 
        perform fb04a-search-doc-location       thru    fb04a-99-exit 
            varying sub 
            from 1 
            by   1 
            until   sub > max-doc-locations 
                 or valid-location. 
*   endif 
 
    if    invalid-location 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 3                          to      err-ind 
        move hdr-loc-code               to      err-msg-loc-cd 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit. 
*   endif 
 
fb04-99-exit. 
    exit. 
 
 
fb04a-search-doc-location. 
 
    if hdr-loc-code = doc-loc(sub) 
    then 
        move 'Y'                        to flag-location. 
*   endif 
 
fb04a-99-exit. 
    exit. 
 
*2000/03/20 - MC  add the new subroutine fb04b-read-loc-mstr
fb04b-read-loc-mstr. 

    move hdr-loc-code			to loc-nbr.
 
    read loc-mstr
      invalid key 
        if not price-only-claim
	then
	    move zeroes			    to 	loc-hospital-nbr
	    move spaces			    to 	loc-card-colour
	    move ws-error-literal	    to	err-warn-msg
            perform xb0-print-warning-line  thru    xb0-99-exit 
            move 1                          to      ws-carriage-ctrl 
            move 51                         to      err-ind 
            move hdr-loc-code               to      err-51-loc-cd
            perform zb0-build-write-err-rpt-line
					    thru    zb0-99-exit.
*	endif

fb04b-99-exit.
    exit.


 
copy "hospital.dc".
 
copy "hosp_nbr_code_to_nbr.rtn"
     replacing  ==ca11-move-hosp==      by ==fb05-verify-hospital== 
                ==ca11-10-hosp-loop==   by ==fb05-10-hosp-loop== 
                ==ca11-99-exit==        by ==fb05-99-exit== 
                ==clmhdr-hosp==         by ==hdr-hosp-nbr== 
                ==hosp-nbr==            by ==hosp-code== 
                ==hosp-code==           by ==hosp-nbr== 
                ==spaces==              by =="?"== 
                ==l1-hosp==             by ==clmhdr-hosp==. 
copy "verify_agent_code.rtn"
     replacing  ==xx00-verify-agent==   by ==fb06-verify-agent== 
                ==xx00-99-exit==        by ==fb06-99-exit== 
                ==agent-2b-tested==     by ==hdr-agent-cd==. 
fb07-verify-in-out-ind. 
 
*   (NON-RMA-ENHANCED SUBMISSIONS DON'T HAVE A PATIENT I/O INDICATOR IN THE 
*    HDR RECORDS.  CHECK THE 'HEB' BATCH HEADER RECORD TO SEE IF RMA HAS 
*    INPUT A DEFAULT VALUE TO USE FOR ALL CLAIMS IN THE BATCH AND 
*    OVERRIDE IF REQUIRED) 
 
    if    hdr-i-o-ind = spaces 
      and ws-default-batch-i-o-ind not = spaces 
    then 
	move ws-default-batch-i-o-ind	to hdr-i-o-ind. 
*   endif 
 
*   IF HDR-I-O-IND = "1" OR "2" OR SPACES 
    if hdr-i-o-ind = "1" or "2" or "I" or "O" or spaces 
    then 
        move "Y"                        to      flag-in-out-ind 
    else 
        move "N"                        to      flag-in-out-ind. 
*   endif 
 
fb07-99-exit. 
    exit. 


*mf fd0-build-susp-addr-rec-from-hdr1. 
fd0-build-susp-addr-rec-hdr1.
 
    move spaces                 to suspend-address-rec. 
 
*   VALIDATE THE BIRTH DATE 
 
    move hdr-birth-date-long    to addr-birth-date. 
 
    if    hdr-birth-date-long = spaces or zeros 
      and not price-only-claim
    then 
	move ws-warning-literal	to err-warn-msg
        perform xb0-print-warning-line thru xb0-99-exit 
        move 1                  to ws-carriage-ctrl 
        move 37                 to err-ind 
        move hdr-birth-date-long to err-birth-date 
        perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*       MOVE '??????'           TO ADDR-BIRTH-DATE 
    else 
        move addr-birth-yy      to ws-date-yy 
        move addr-birth-mm      to ws-date-mm 
        move addr-birth-dd      to ws-date-dd 
        perform xd0-verify-date thru xd0-99-exit 
        if    invalid-date 
          and not price-only-claim
        then 
	    move ws-error-literal	to err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 37                     to err-ind 
            move hdr-birth-date-long    to err-birth-date 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit. 
*           MOVE '??????'               TO ADDR-BIRTH-DATE. 
*       endif 
*   endif 
 
    move clmhdr-doc-pract-nbr   to addr-doc-pract-nbr. 
    move clmhdr-accounting-nbr  to addr-accounting-nbr. 

*   brad
    move unpriced-clmhdr-pat-surname2	to addr-surname.
    move unpriced-clmhdr-given-name2 	to addr-first-name.

fd0-99-exit. 
    exit. 
 
 
ga0-proc-rec-type-header2. 

    if unpriced-clmhdr-claim = 00523321
    then
	next sentence.
*   endif

* brad - moved elsewhere
*    move unpriced-clmhdr-pat-surname     to clmhdr-pat-acronym6 
*                                           clmhdr-patient-surname. 
 
*    move unpriced-clmhdr-given-name      to clmhdr-pat-acronym3 
*                                           clmhdr-subscr-initials. 

* 2010/08/12 - MC7  
*   move clmhdr-pat-acronym		to susp-hdr-acronym.
* 2010/08/12 - end

 
* 2000/jun/09 -BA/BE begin
*  (if either 'confidentiality' or 'manual review' flags have been
*   set then update 'manual review' to  "Y"es in the suspend header rec)
*    move unpriced-confidentiality-flag to    clmhdr-confidential-flag.
    if   unpriced-confidentiality-flag = "Y"
      or hdr-manual-review            = "Y"
    then
	move "Y"			  to    hdr-manual-review
    else
        move ' '			  to	hdr-manual-review.
*   endif
    if   unpriced-confidentiality-flag = "Y"
    then
        move "Y"			  to    clmhdr-confidential-flag
    else
        move ' '			  to 	clmhdr-confidential-flag.
* 2000/jun/09 -BA end

    move unpriced-clmhdr-loc-code        to hdr-loc-code. 
*   (DETERMINE IF VALID LOCATION FOR DOCTOR) 
    perform fb04-verify-doc-location    thru    fb04-99-exit. 
*   IF INVALID-LOCATION 
*   THEN 
*       MOVE "????"                     TO      CLMHDR-LOC 
*   ELSE 
        move hdr-loc-code               to      clmhdr-loc. 
*   endif 


* 2005/05/05 - MC - check certain location code if clinic 61 - 65
*    if  bt-clinic-nbr-1-2 >= 61 and bt-clinic-nbr-1-2  <= 65
* 2011/07/07 - MC17 - include clinic 66
*    if     (     (bt-clinic-nbr-1-2 >= 61 and bt-clinic-nbr-1-2  <= 65)
    if     (     (bt-clinic-nbr-1-2 >= 61 and bt-clinic-nbr-1-2  <= 66)
* 2011/07/07 - end
* 2007/11/27 - MC - include check for clinic 71 - 75 as well
            or   (bt-clinic-nbr-1-2 >= 71 and bt-clinic-nbr-1-2  <= 75)
	   )
* 2007/11/27 - end
        and  not price-only-claim
    then
	if    hdr-loc-code not = 'M233'		 
	  and hdr-loc-code not = 'M521'		 
	  and hdr-loc-code not = 'M525'		 
	  and hdr-loc-code not = 'M526'		 
	  and hdr-loc-code not = 'M527'		 
	  and hdr-loc-code not = 'M540'		 
	  and hdr-loc-code not = 'M541'		 
	  and hdr-loc-code not = 'M542'		 
	  and hdr-loc-code not = 'M544'		 
	  and hdr-loc-code not = 'M545'		 
	  and hdr-loc-code not = 'M546'		 
	  and hdr-loc-code not = 'M547'		 
	  and hdr-loc-code not = 'M555'		 
	  and hdr-loc-code not = 'M556'	
        then 
	    move ws-warning-literal	    to      err-warn-msg
            perform xb0-print-warning-line  thru    xb0-99-exit 
            move 1                          to      ws-carriage-ctrl 
            move 62                         to      err-ind 
            move bt-clinic-nbr-1-2          to      err-62-clinic-nbr 
            move hdr-loc-code               to      err-62-loc-code   
            move "????"                     to      clmhdr-loc
            perform zb0-build-write-err-rpt-line 
                                        	thru    zb0-99-exit. 
*	endif 
*   endif

* 2005/05/05 - end

*2000/03/20 - MC -get the hosp nbr and i/o ind from f030-locations-mstr
*		  by loc-code
    perform fb04b-read-loc-mstr		thru	fb04b-99-exit.
    move loc-hospital-nbr		to	clmhdr-hosp.
*

*2002/04/24 - substitute hosp with payroll-flag
    move ws-default-payroll-flag	to 	clmhdr-hosp.
*2002/04/24  - end
 
*  brad    move unpriced-clmhdr-agent-cd        to      hdr-agent-cd. 
*   (DETERMINE IF VALID AGENT) 
    perform fb06-verify-agent           thru    fb06-99-exit. 
    if    invalid-agent-cd 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 20                         to      err-ind 
        move hdr-agent-cd               to      err-agent-cd 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*       MOVE "?"                        TO      CLMHDR-AGENT-CD 
*   ELSE 
        move hdr-agent-cd               to      clmhdr-agent-cd. 
*   endif 
 
    if     def-agent-ohip 
	or def-agent-ohip-wcb 
    then 
        move zero                       to      clmhdr-date-cash-tape-payment 
    else 
        if not price-only-claim
	then
* 2012/11/05 - MC28 - set default values for agent 6
          if clmhdr-agent-cd = 6
          then
            move "00"                       to      clmhdr-msg-nbr
            move "N"                        to      clmhdr-reprint-flag
            move "0"                        to      clmhdr-sub-nbr
            move "N"                        to      clmhdr-auto-logout
            move "0"                        to      clmhdr-fee-complex
          else
* 2012/11/05 - end

*	    (PRINT WARNING THAT DIRECT BILL AGENT ENTERED AND ALL DIRECT 
*      	     BILL INFO IS MISSING) 
	    move ws-warning-literal	    to	    err-warn-msg
            perform xb0-print-warning-line  thru    xb0-99-exit 
            move 1                          to      ws-carriage-ctrl 
            move 25                         to      err-ind 
            perform zb0-build-write-err-rpt-line 
                                            thru    zb0-99-exit 
            move "??"                       to      clmhdr-msg-nbr 
            move "?"                        to      clmhdr-reprint-flag 
            move "?"                        to      clmhdr-sub-nbr 
            move "?"                        to      clmhdr-auto-logout 
            move "?"                        to      clmhdr-fee-complex. 
*	endif
*   endif 

*be2 move the 2 below checks on clmhdr-agent-cd to later in code 
*   (SET INDICATOR TO ASSUME THAT CLAIM CAN BE SUBMITTED ON TAPE - WHEN 
*    ACTUAL CLAIM IS BUILT THE DETAILS WERE BE CHECKED TO ENSURE THAT 
*    THIS INDICATOR IS SET CORRECLTY) 
    if clmhdr-agent-cd = 0 or 2 
    then 
        move "Y"                        to      clmhdr-tape-submit-ind 
    else 
        move "N"                        to      clmhdr-tape-submit-ind. 
*   endif 

*2001/02/28 - MC- if agent = 6 or 9, set clmhdr-status = 'I'gnore

* 2012/11/05 - MC28 - allow to process agent 6
*   if clmhdr-agent-cd = 6 or 9
    if clmhdr-agent-cd =  9
* 2012/11/05 - end
    then 
	move "I"			to 	clmhdr-status.
*   endif


*2000/03/20 - MC - use loc-card-colour instead
*brad change back
*brad     move unpriced-clmhdr-i-o-ind         to      hdr-i-o-ind. 
*    move loc-card-colour                to      hdr-i-o-ind. 

*2000/03/29 - MC - check the incoming i-o ind with loc-card-colour 
* brad - ignore incoming oscar io flag (based upon admit date and use f030)
* brad   duplicate read  of f030
*2000/03/20 - MC -get the hosp nbr and i/o ind from f030-locations-mstr
*		  by loc-code
    perform fb04b-read-loc-mstr		thru	fb04b-99-exit.
    move  loc-in-out-ind	 	to 	unpriced-clmhdr-i-o-ind
						hdr-i-o-ind.

    if    unpriced-clmhdr-i-o-ind  not =   hdr-i-o-ind
      and not price-only-claim
    then 
  	move ws-warning-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 53                         to      err-ind 
        move unpriced-clmhdr-i-o-ind     to      err-53-incoming-i-o-ind 
        move hdr-i-o-ind                to      err-53-i-o-ind 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit .
*   endif
*   


    perform fb07-verify-in-out-ind      thru    fb07-99-exit. 
    if    invalid-in-out-ind 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 15                         to      err-ind 
        move hdr-i-o-ind                to      err-i-o-ind 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
*       MOVE "?"                        TO      CLMHDR-I-O-PAT-IND 
        move hdr-i-o-ind                to      clmhdr-i-o-pat-ind 
    else 
*       IF HDR-I-O-IND = 1 - 96/07/30 
        if hdr-i-o-ind = "1" or "I" 
        then 
            move "I"                    to      clmhdr-i-o-pat-ind 
        else 
*           IF HDR-I-O-IND = 2 - 96/07/30 
            if hdr-i-o-ind = "2" or "O" 
            then 
                move "O"                to      clmhdr-i-o-pat-ind 
            else 
*               (IF INDICATOR IS BLANK - CONSIDER AS 'OUT' PATIENT) 
                move "O"                to      clmhdr-i-o-pat-ind. 
*           endif 
*       endif 
*   endif 

* 2010/08/12 - MC7  

*brad
* below moved elsewhere since header rec not longer processed 
    if unpriced-clmhdr-hc-prov-cd = spaces 
    then 
        move 'ON'                       to      hdr-health-care-prov 
    else 
        move unpriced-clmhdr-hc-prov-cd     to      hdr-health-care-prov. 
*   endif 
 
    move 'N'                            to      province-flag. 
    perform fb0a-search-province        thru    fb0a-99-exit 
            varying sub from 1 by 1 
            until (province-found or sub > 11). 
 
 
    if    province-not-found 
      and not price-only-claim
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 30                         to      err-ind 
        move hdr-health-care-prov       to      err-province 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*       MOVE "??"                       TO      CLMHDR-HEALTH-CARE-PROV 
*   ELSE 
*be6
        move hdr-health-care-prov       to      clmhdr-health-care-prov. 
*   endif 


******************   

* 2013/04/10 - MC28 - if agent = 6, bypass health nbr/RMB nbr edit check
    if hdr-agent-cd = 6
    then
        move unpriced-clmhdr-pat-surname        to hdr-surname-3
        move hdr-birth-date                     to hdr-birthdate-yymm
        move hdr-birth-date-dd                  to hdr-birthdate-dd
        move 'O'                                to clmhdr-pat-key-type
        move hdr-direct-key                     to clmhdr-pat-key-data
        go to ga0-90.
*    endif
* 2013/04/17 - end

* 2001/02/07 - MC - save RMB registration nbr 
    if hdr-health-care-prov not = 'ON'  and
       unpriced-clmhdr-pat-ohip-nbr not = spaces and
       unpriced-clmhdr-pat-ohip-nbr not = zeroes
    then
	move unpriced-clmhdr-pat-ohip-nbr	to hdr-ohip-nbr.
*   endif

******************   
    if hdr-health-care-prov = 'ON' 
    then 
        if    hdr-health-care-nbr = spaces 
          and not price-only-claim
        then 
	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
            move 1                      to      ws-carriage-ctrl 
            move 29                     to      err-ind 
            move hdr-health-care-nbr 
                                        to      err-health-care-nbr 
            perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
            move "??????????"           to      clmhdr-health-care-nbr 
        else 
            move hdr-health-care-nbr    to      ws-nbr-10 
            if   (   ws-nbr-10 not numeric 
                  or ws-nbr-10 = zero 
		 )
              and not price-only-claim
            then 
		move ws-error-literal	to	err-warn-msg
                perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
                move 1                  to      ws-carriage-ctrl 
                move 29                 to      err-ind 
                move hdr-health-care-nbr 
                                        to      err-health-care-nbr 
                perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
                move "??????????"       to      clmhdr-health-care-nbr 
            else 
                move hdr-health-care-nbr 
                                        to      ws-check-nbr-10 
                perform db0a-mod10-check-digit-10 thru  db0a-99-exit 
                if    flag = 'N' 
                  and not price-only-claim
                then 
		    move ws-error-literal	to	err-warn-msg
                    perform xb0-print-warning-line 
                                        thru    xb0-99-exit 
                    move 1              to      ws-carriage-ctrl 
                    move 29             to      err-ind 
                    move hdr-health-care-nbr to err-health-care-nbr 
                    perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
                    move "??????????"   to      clmhdr-health-care-nbr 
                else 
*               (DATA IS OK - HAS ALREADY BEEN MOVED INTO CLMHDR FIELDS 
                    next sentence. 
*               endif 
*           endif 
*       endif 
*   endif 
 
*   (DETERMINE IF VALID SIZE OF OHIP NBR FOR OUT OF PROVINCE PATIENT) 
 
* 2005/06/23 - MC - change from NF to NL
* if hdr-health-care-prov = 'NF' 
    if hdr-health-care-prov = 'NL' 
* 2005/06/23 - end
    then 
        if   (    nf-ohip-nbr is not numeric 
              or (nf-ohip-nbr = spaces or zeros) 
	     )
          and not price-only-claim
        then 
	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
***
*       endif 
    else 
* 2001/02/12 - MC - ohip nbr size has changed
*   if hdr-health-care-prov = 'AB' or 'NS' 
    if hdr-health-care-prov = 'BC' or 'NS' 
    then 
*       if      (ab-ns-11-digits is not numeric) 
*           or  (ab-ns-11-digits =  spaces or zeros) 
*           or  (ab-ns-last-digits not = spaces) 
        if   (    (bc-ns-10-digits is not numeric) 
              or  (bc-ns-10-digits =  spaces or zeros) 
              or  (bc-ns-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
*   if hdr-health-care-prov = 'BC' 
    if hdr-health-care-prov = 'PE' 
    then 
*       if      (bc-10-digits is not numeric) 
*           or  (bc-10-digits =  spaces or zeros) 
*           or  (bc-last-digits not = spaces) 
        if   (    (pe-8-digits is not numeric) 
              or  (pe-8-digits =  spaces or zeros) 
              or  (pe-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
*   if hdr-health-care-prov = 'NB' or 'PE' or 'SK' or 'YT' 
    if hdr-health-care-prov = 'AB' or 'NB' or 'SK' or 'YT' 
    then 
*       if      (nb-pe-sk-yt-9-digits is not numeric) 
*           or  (nb-pe-sk-yt-9-digits =  spaces or zeros) 
*           or  (nb-pe-sk-yt-last-digits not = spaces) 
        if   (    (ab-nb-sk-yt-9-digits is not numeric) 
              or  (ab-nb-sk-yt-9-digits =  spaces or zeros) 
              or  (ab-nb-sk-yt-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
    if hdr-health-care-prov = 'NT' 
    then 
        if   (    (nt-first-digit is not alphabetic) 
              or  (nt-first-digit =  spaces) 
              or  (nt-7-digits is not numeric) 
              or  (nt-7-digits =  spaces or zeros) 
              or  (nt-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr
*       endif 
    else 
    if hdr-health-care-prov = 'MB' 
    then 
* 2005/06/23 - MC - Manitoba should be 9 digits
*        if   (    (mb-6-digits is not numeric)
*             or  (mb-6-digits =  spaces or zeros)
        if   (    (mb-9-digits is not numeric)
              or  (mb-9-digits =  spaces or zeros)
* 2005/06/23 - end
              or  (mb-last-digits not = spaces) 
	     )
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line thru xb0-99-exit 
            move 1                      to ws-carriage-ctrl 
            move 40                     to err-ind 
	    move hdr-health-care-prov	to err-prov
            move hdr-ohip-nbr           to err-ohip-nbr 
            perform zb0-build-write-err-rpt-line thru zb0-99-exit 
*           MOVE "?"                    TO      CLMHDR-PAT-KEY-TYPE 
*           MOVE "????????"             TO      CLMHDR-PAT-KEY-DATA 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
        else 
            move "O"                    to      clmhdr-pat-key-type 
            move hdr-ohip-nbr           to      clmhdr-pat-key-data 
* 2001/02/07 - MC - move hdr-ohip-nbr to clmhdr-health-care-nbr
						clmhdr-health-care-nbr.
*       endif 
*   endif 

* 2013/04/17 - MC28
ga0-90.
* 2013/04/17 - end
 
*brad TODO - blank??
    perform ga1-build-addr-rec-from-hdr2    thru ga1-99-exit. 
 
ga0-99-exit. 
   exit. 
 
 
ga1-build-addr-rec-from-hdr2. 
 
*brad    move unpriced-clmhdr-pat-surname     to      addr-surname. 
*brad    move unpriced-clmhdr-given-name      to      addr-first-name. 
    if   unpriced-clmhdr-sex-2 = "1" 
    then 
         move "M"                       to      addr-sex 
    else 
    if   unpriced-clmhdr-sex-2 = "2" 
    then 
         move "F"                       to      addr-sex 
    else 
         move unpriced-clmhdr-sex-2       to      addr-sex. 
*   endif 

    move unpriced-clmhdr-phone-no         to      addr-phone-no. 
 
 
ga1-99-exit. 
    exit. 
 
gb1-verify-dtl-diag-cd. 
 
    if hold-diag-cd(ss-write-dtl) =   spaces 
                                   or zeros 
    then 
*       (CHECK IF CODE REQUIRES A DIAGNOSIS CODE) 
        if    hold-oma-rec-ind (ss-write-dtl, ss-diag-ind) = "Y" 
          and hold-oma-suff    (ss-write-dtl)              = "A" or "M" 
          and not price-only-claim
        then 
   	    move ws-error-literal	to	err-warn-msg
            perform xb0-print-warning-line 
                                          thru    xb0-99-exit 
            move 1                        to      ws-carriage-ctrl 
            move 22                       to      err-ind 
            move hold-oma-cd(ss-write-dtl) to     err-22-oma-cd 
            move "DIAGNOSTIC CODE"        to      err-22-msg 
            perform zb0-build-write-err-rpt-line 
                                          thru    zb0-99-exit 
*           MOVE "???"                    TO      CLMDTL-DIAG-CD-ALPHA 
            move zero                     to      clmdtl-diag-cd 
        else 
*           (NO DIAG. CODE SPECIFIED BUT NONE WAS REQUIRED) 
            move zero                     to      clmdtl-diag-cd 
*       endif 
    else 
*       (DIAG. CODE SPECIFIED - ENSURE THAT CODE IS VALID) 
        move hold-diag-cd(ss-write-dtl) to      diag-cd 
*##     CHCE3DCK ROUTINE TO SEE IF USING HOLD 
        perform fb03-verify-diag-code     thru    fb03-99-exit 
*       IF INVALID-DIAG-CODE 
*       THEN 
*           MOVE "???"                    TO      CLMDTL-DIAG-CD-ALPHA 
*       ELSE 
            move hold-diag-cd(ss-write-dtl) 
                                          to      clmdtl-diag-cd 
*           (### ENSURE THAT CLMHDR STILL AVAILLE AND NOT NEW REC) 
*mf            if clmhdr-diag-cd = spaces or zeros 
            if clmhdr-diag-cd-alpha = spaces or zeros 
            then 
                move hold-diag-cd(ss-write-dtl) 
                                          to      clmhdr-diag-cd. 
*           endif 
*       endif 
*   endif 
 
gb1-99-exit. 
    exit. 
 
*2000/04/28 - B.A. begin
copy "d001_d003_newu701_confidentiality_check.rtn".

ha0-proc-rec-type-detail. 
 
*   (move the 2 service details from the 'unpriced' rec to pricing hold area) 
    add 1                               to                   ss-clmdtl-oma. 
 
    move unpriced-itm1-oma-svc-code      to hold-oma-cd      (ss-clmdtl-oma). 
    move unpriced-itm1-oma-svc-suff      to hold-oma-suff    (ss-clmdtl-oma). 

*  2008/04/29 - MC - transfer oma code edit check to the copybook 'd001_newu701_oma_code_edit.rtn
    perform la4-oma-code-edit   	thru la4-99-exit.
* 2008/04/29 - end

copy "pricing_logic_check_for_special_addon_codes.rtn"
	replacing  ==ws-oma-cd== by ==hold-oma-cd(ss-clmdtl-oma)==.
**   (00/aug/31 B.E. set flag is special addin code found)
**   (set flag if special add on oma codes of e409 or e400
**    or e401 or e410 entered)
*    if hold-oma-cd(ss-clmdtl-oma) =  "E400"
**				   or "E409"
*				   or "E401"
*				   or "E410"
*    then
*        move "Y"                               to ws-special-add-on-cd-entered.
**   endif

*   MOVE TAPEOUT-ITM1-OMA-AMT-BILLED    TO HOLD-FEE-BILLED  (SS-CLMDTL-OMA). 

*   (save incoming $ and #-svcs so that if RMA pricing alters these
*    values they can be recovered if needed)
    move unpriced-itm1-oma-amt-billed    to hold-fee-incoming(ss-clmdtl-oma). 
    move unpriced-itm1-nbr-serv	 	to hold-sv-nbr-serv-incoming
							    (ss-clmdtl-oma).
*
    move unpriced-itm1-override-price    to hold-override-price 
							    (ss-clmdtl-oma). 
    move unpriced-itm1-bilateral         to hold-bilateral   (ss-clmdtl-oma). 
*   (IF PRICE OVERRIDE IS REQUESTED THEN MOVE THE ENTERED FEE INTO FEE-OMA/OHIP) 
*  (NOTE: PRICE OVERRIDE FLAG ASSUMED TO BE SET IF THE INCOMING RECORD 
*         HAS PRICES. THIS HANDLES PC BASED BILLING PACKAGES THAT PRICE 
*         CLAIMS BUT DON'T SET THE PRICE OVERRIDE FLAG. 
*         THIS CODE SHOULD EVENTUALLY BE CHANGED TO USE THE INCOMING 
*         PRICE BUT REPORT IF THE RMA PRICING SOFTWARE CALCULATES 
*         A DIFFERENT PRICE) 

    inspect unpriced-itm1-oma-amt-billed replacing all space-char by zeros. 

*    if unpriced-itm1-oma-amt-billed not = 0 
*    then 
*        move "Y" 		to	unpriced-itm1-override-price. 
**   endif 
 
*    if   unpriced-itm1-override-price = "Y" 

    if unpriced-itm1-oma-amt-billed not = 0 
    then 
        move unpriced-itm1-oma-amt-billed to hold-fee-incoming(ss-clmdtl-oma) 
    else 
	move 0                            to hold-fee-oma     (ss-clmdtl-oma) 
                                             hold-basic-prof  (ss-clmdtl-oma) 
                                             hold-fee-ohip    (ss-clmdtl-oma). 
*   endif 
 
    move unpriced-itm1-nbr-serv          to hold-sv-nbr-serv (ss-clmdtl-oma). 
*   (REPEATING SERVICES NOT ALLOWED IN OHIP SUBMITTAL TAPE SPECIFICATION) 
    move 0                              to hold-sv-nbr      (ss-clmdtl-oma,1) 
                                           hold-sv-nbr      (Ss-clmdtl-oma,2) 
                                           hold-sv-nbr      (ss-clmdtl-oma,3) 
                                           hold-sv-day-num  (ss-clmdtl-oma,1) 
                                           hold-sv-day-num  (ss-clmdtl-oma,2) 
                                           hold-sv-day-num  (ss-clmdtl-oma,3). 
*  (if Override Price or Bilateral flags set, then default the first 
*   repetitive day field as per the way D001 works) 
 
    if unpriced-itm1-override-price = "Y" 
    then 
	move "OP" 			to hold-sv-day      (ss-clmdtl-oma,1) 
    else 
    if unpriced-itm1-bilateral = "Y" 
    then 
	move "BI" 			to hold-sv-day      (ss-clmdtl-oma,1). 
*   ENDCASE 
 
    move unpriced-itm1-svc-date          to hold-sv-date     (ss-clmdtl-oma). 
    move unpriced-itm1-diag-cd           to hold-diag-cd     (ss-clmdtl-oma). 
    move hold-oma-cd (ss-clmdtl-oma)    to fee-oma-cd. 
    perform xc0-check-oma-code          thru xc0-99-exit. 
*   (00/04/28 - B.A. begin)
*   (The check for oma and diag code is to set the confidentiality flag
*    at the detail level)
    perform ga11-check-for-confidentially thru ga11-99-exit.
*   (00/04/28 end)

* 2011/05/18 - MC15
    perform ha12-check-for-sli-oma thru ha12-99-exit.
* 2011/05/18 - end

    perform ha1-move-pricing-to-hold	thru ha1-99-exit. 
 
* ## BELOW FLAG MOVED - WHAT IMPACT ON RESET OF PGM) 
*   MOVE 'Y'                            TO DETAIL-WRITTEN-FLAG. 
 
    if unpriced-itm2-oma-svc-code = spaces 
    then 
*       (MOVE DETAIL REC TO PRICING HOLD AREA) 
	go to ha0-90-after-2nd-detail. 
*   endif 
 
    add 1                               to                   ss-clmdtl-oma. 

    move unpriced-itm2-oma-svc-code      to hold-oma-cd      (ss-clmdtl-oma). 
    move unpriced-itm2-oma-svc-suff      to hold-oma-suff    (ss-clmdtl-oma). 

*  2008/04/29 - MC - transfer oma code edit check to the copybook 'd001_newu701_oma_code_edit.rtn
    perform la4-oma-code-edit   	thru la4-99-exit.
* 2008/04/29 - end


copy "pricing_logic_check_for_special_addon_codes.rtn"
	replacing  ==ws-oma-cd== by ==hold-oma-cd(ss-clmdtl-oma)==.
*   (00/aug/31 B.E. set flag is special addin code found)
*   (set flag if special add on oma codes of e409 or e400
*    or e401 or e410 entered)
*    if hold-oma-cd(ss-clmdtl-oma) =  "E400"
*				   or "E409"
* 				   or "E401"
*				   or "E410"
*    then
*        move "Y"                                to ws-special-add-on-cd-entered.
*   endif

*   MOVE TAPEOUT-ITM2-OMA-AMT-BILLED    TO HOLD-FEE-BILLED  (SS-CLMDTL-OMA). 

*   (save incoming $ and #-svcs so that if RMA pricing alters these
*    values they can be recovered if needed)
    move unpriced-itm2-oma-amt-billed    to hold-fee-incoming(ss-clmdtl-oma). 
    move unpriced-itm2-nbr-serv	 	to hold-sv-nbr-serv-incoming
							    (ss-clmdtl-oma).

    move unpriced-itm2-override-price    to hold-override-price 
							    (ss-clmdtl-oma). 
    move unpriced-itm2-bilateral         to hold-bilateral   (ss-clmdtl-oma). 
 
*    if unpriced-itm2-oma-amt-billed not = 0 
*    then 
*        move "Y" 		to	unpriced-itm2-override-price. 
**   endif 
 
*    if unpriced-itm2-override-price = "Y" 

    if unpriced-itm2-oma-amt-billed not = 0 
    then 
        move unpriced-itm2-oma-amt-billed to hold-fee-incoming(ss-clmdtl-oma) 
    else 
	move 0                            to hold-fee-oma     (ss-clmdtl-oma) 
                                             hold-basic-prof  (ss-clmdtl-oma) 
                                             hold-fee-ohip    (ss-clmdtl-oma). 
*   endif 
 
    move unpriced-itm2-nbr-serv          to hold-sv-nbr-serv (ss-clmdtl-oma). 
    move 0                              to hold-sv-nbr      (ss-clmdtl-oma,1) 
                                           hold-sv-nbr      (ss-clmdtl-oma,2) 
                                           hold-sv-nbr      (ss-clmdtl-oma,3) 
                                           hold-sv-day-num  (ss-clmdtl-oma,1) 
                                           hold-sv-day-num  (ss-clmdtl-oma,2) 
                                           hold-sv-day-num  (ss-clmdtl-oma,3). 
    move unpriced-itm2-svc-date          to hold-sv-date   (ss-clmdtl-oma). 
    move unpriced-itm2-diag-cd           to hold-diag-cd   (ss-clmdtl-oma). 
*  (if Override Price or Bilateral flags set, then default the first 
*   repetitive day field as per the way D001 works) 
 
    if unpriced-itm2-override-price = "Y" 
    then 
	move "OP" 			to hold-sv-day      (ss-clmdtl-oma,1) 
    else 
    if unpriced-itm2-bilateral = "Y" 
    then 
	move "BI" 			to hold-sv-day      (ss-clmdtl-oma,1). 
*   ENDCASE 
 
*   (CALL TO THESE 2 ROUTINES MOVED TO OUTPUT OF SUSPENSE RECORDS) 
*    EXCEPT FOR READ OF OMA-FEE-MSTR SINCE VALUES NEEDED NOW TO 
*    PUT INTO HOLD AREA FOR LATER PRICING CACULATIONS) 
*    PERFORM HB0-BUILD-SUSP-DTL-REC-FROM-DTL THRU HB0-99-EXIT 
*    PERFORM YD0-WRITE-DTL-REC THRU YD0-99-EXIT. 
 
    move hold-oma-cd(ss-clmdtl-oma)     to   fee-oma-cd. 
    perform xc0-check-oma-code          thru xc0-99-exit. 
*   (00/04/28 - B.A. begin)
*   (The check for oma and diag code is to set the confidentiality flag
*    at the detail level)
    perform ga11-check-for-confidentially thru ga11-99-exit.
*   (00/04/28 end)

* 2011/05/18 - MC15
    perform ha12-check-for-sli-oma thru ha12-99-exit.
* 2011/05/18 - end

    perform ha1-move-pricing-to-hold	thru ha1-99-exit. 
 
ha0-90-after-2nd-detail. 
 
ha0-99-exit. 
    exit. 
 
 
 
ha1-move-pricing-to-hold. 
*WC0-MOVE-OMA-DATA-TO-HOLD. (TAKEN FROM D001.CB) 

*   (save the nbr of the incoming detail record so that if the pricing
*    module re-sorts the claim details within the hold area, the program
*    can use the hold-line-no field to re-sort the records back into
*    the original sequence)
    move  ss-clmdtl-oma	     to hold-line-no   	     (ss-clmdtl-oma).
 
*	 (MOVE OMA REC'S DATA TO THE DETAIL ENTRY'S HOLD AREA) 
 
    move fee-tech-ind	     to hold-oma-rec-ind(ss-clmdtl-oma,ss-tech-ind). 
    move fee-diag-ind	     to hold-oma-rec-ind(ss-clmdtl-oma,ss-diag-ind). 
    move fee-phy-ind	     to hold-oma-rec-ind(ss-clmdtl-oma,ss-phy-ind). 
    move fee-hosp-nbr-ind    to hold-oma-rec-ind(ss-clmdtl-oma,ss-hosp-nbr-ind).
    move fee-i-o-ind	     to hold-oma-rec-ind(ss-clmdtl-oma,ss-i-o-ind). 
    move fee-admit-ind	     to hold-oma-rec-ind(ss-clmdtl-oma,ss-admit-ind). 
    move fee-special-m-suffix-ind 
			     to hold-oma-rec-ind(ss-clmdtl-oma,ss-special-m-suffix-ind).                   
 
    move fee-icc-sec	     to hold-icc-sec	(ss-clmdtl-oma). 
    move fee-icc-grp	     to hold-icc-grp    (ss-clmdtl-oma). 
 
*   (move oma rec's fees according to whether service is current or
*    previous fees
*    -- if service date is < constants mstr "CURRENT PRICES EFFECT DATE"
*       then use previous rates)
*   (change to use f040 oma fee code's effective date rather than
*    constants master's date)
*     if hold-sv-date (ss-clmdtl-oma) < const-effective-date (curr)
    if hold-sv-date (ss-clmdtl-oma) < fee-effective-date
    then
        move prev                       to hold-ss-curr-prev(ss-clmdtl-oma)
    else
        move curr                       to hold-ss-curr-prev(ss-clmdtl-oma).
*   endif

    move hold-ss-curr-prev(ss-clmdtl-oma)
                                        to ss-curr-prev. 
    move fee-1    (ss-curr-prev, oma)  to hold-oma-fee-1   (ss-clmdtl-oma, oma).
    move fee-2    (ss-curr-prev, oma)  to hold-oma-fee-2   (ss-clmdtl-oma, oma).
    move fee-anae (ss-curr-prev, oma)  to hold-oma-fee-anae(ss-clmdtl-oma, oma).
    move fee-asst (ss-curr-prev, oma)  to hold-oma-fee-asst(ss-clmdtl-oma, oma).
    move fee-1    (ss-curr-prev,ohip)  to hold-oma-fee-1   (ss-clmdtl-oma,ohip).
    move fee-2    (ss-curr-prev,ohip)  to hold-oma-fee-2   (ss-clmdtl-oma,ohip).
    move fee-anae (ss-curr-prev,ohip)  to hold-oma-fee-anae(ss-clmdtl-oma,ohip).
    move fee-asst (ss-curr-prev,ohip)  to hold-oma-fee-asst(ss-clmdtl-oma,ohip).
    move fee-min  (ss-curr-prev,ohip)  to hold-fee-min     (ss-clmdtl-oma,ohip).
    move fee-max  (ss-curr-prev,ohip)  to hold-fee-max     (ss-clmdtl-oma,ohip).
*   (be8)
    move fee-min  (ss-curr-prev,ohip) to hold-fee-min      (ss-clmdtl-oma,oma ).
    move fee-max  (ss-curr-prev,ohip) to hold-fee-max      (ss-clmdtl-oma,oma ).

    move fee-add-on-cd(ss-curr-prev,1) to hold-oma-add-on-cd(ss-clmdtl-oma, 1).
    move fee-add-on-cd(ss-curr-prev,2) to hold-oma-add-on-cd(ss-clmdtl-oma, 2).
    move fee-add-on-cd(ss-curr-prev,3) to hold-oma-add-on-cd(ss-clmdtl-oma, 3).
    move fee-add-on-cd(ss-curr-prev,4) to hold-oma-add-on-cd(ss-clmdtl-oma, 4).
    move fee-add-on-cd(ss-curr-prev,5) to hold-oma-add-on-cd(ss-clmdtl-oma, 5).
    move fee-add-on-cd(ss-curr-prev,6) to hold-oma-add-on-cd(ss-clmdtl-oma, 6).
    move fee-add-on-cd(ss-curr-prev,7) to hold-oma-add-on-cd(ss-clmdtl-oma, 7).
    move fee-add-on-cd(ss-curr-prev,8) to hold-oma-add-on-cd(ss-clmdtl-oma, 8).
    move fee-add-on-cd(ss-curr-prev,9) to hold-oma-add-on-cd(ss-clmdtl-oma, 9).
    move fee-add-on-cd(ss-curr-prev,10) to hold-oma-add-on-cd(ss-clmdtl-oma,10).
    move fee-oma-ind-card-requireds(ss-curr-prev) 
				to hold-oma-ind-card-requireds(ss-clmdtl-oma). 
 
*   (oma fee mstr records for sp add-ons should have data duplicated
*    in fee-1 and fee-2 for 'f'lat or 'p'erc rates. Some do not and
*    therefore require this logic patch)
*   (00/aug/08 B.E.
*    recognize 'add on' codes by "P"ercent/"F"lat designation rather
*    than having to have a specific ICC code)
*   if hold-icc-cd (ss-clmdtl-oma) = 'SP98'
*                                 or 'SP99'
    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
                                                  or "F"
    then
        perform ha1a-addon-fee-fix	thru ha1a-99-exit.
*   endif

    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
                                                  or "F"
    then
        move fee-add-on-perc-or-flat-ind(ss-curr-prev)
                 to hold-oma-rec-ind (ss-clmdtl-oma,ss-add-on-perc-or-flat-ind)
    else
        move " " to hold-oma-rec-ind (ss-clmdtl-oma,ss-add-on-perc-or-flat-ind).
*   endif

*   (if indicator for flat vs percent not set then use fee > 1.00 as flat
*                                                      and < 1.01 as percent
*   (00/aug/08 B.E. - removed below code - the "F"lat or "P"ercentage
*                     MUST be set in order to identify code as an 'add on',
*                     so no defaulting of flag can now be performed.)
*    else
*        if hold-oma-fee-1 (ss-clmdtl-oma,  oma) > 1.00
*        then
*            move "F"    to hold-oma-rec-ind     (ss-clmdtl-oma, ss-add-on-perc-or-flat-ind )
*        else
*            move "P"    to hold-oma-rec-ind     (ss-clmdtl-oma, ss-add-on-perc-or-flat-ind ).
**       endif
**   endif
 
ha1-99-exit. 
    exit. 
 
ha1a-addon-fee-fix.

*   (format of f040 file fees is: 99.999 allowing only 3 decimals. 2001/apr/23
*    requirement was for 4 decimal positions only for PERCENTAGE based addons.
*    Percentages were originally stored using only the numbers after the
*    decimal place. Conversion run to multiply by 100 and now percentages
*    that were stored as .605 were stored as 60.500 . This means that
*    when pricing claims the Percentage rates must be divided by 100 before
*    moving into pricing hold variables.
    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
    then
        compute hold-oma-fee-1 (ss-clmdtl-oma,  oma) =
                hold-oma-fee-1 (ss-clmdtl-oma,  oma) / 100
        compute hold-oma-fee-2 (ss-clmdtl-oma,  oma) =
                hold-oma-fee-2 (ss-clmdtl-oma,  oma) / 100
        compute hold-oma-fee-1 (ss-clmdtl-oma, ohip) =
                hold-oma-fee-1 (ss-clmdtl-oma, ohip) / 100
        compute hold-oma-fee-2 (ss-clmdtl-oma, ohip) =
                hold-oma-fee-2 (ss-clmdtl-oma, ohip) / 100.
*   endif

*	(IF 'OMA' FEE-1  RATE IS ZERO, THEN USE FEE-2 AND VISA VERSA) 
    if        hold-oma-fee-1 (ss-clmdtl-oma,  oma) = 0 
    then 
       move  hold-oma-fee-2 (ss-clmdtl-oma,  oma)	to hold-oma-fee-1(ss-clmdtl-oma,  oma) 
    else 
        if        hold-oma-fee-2 (ss-clmdtl-oma,  oma) = 0 
 	then 
            move  hold-oma-fee-1 (ss-clmdtl-oma,  oma)	to hold-oma-fee-2(ss-clmdtl-oma,  oma) 
        else 
            next sentence. 
*	endif 
*   endif 
 
*	(IF 'OHIP' FEE-1  RATE IS ZERO, THEN USE FEE-2 AND VISA VERSA) 
    if        hold-oma-fee-1 (ss-clmdtl-oma, ohip) = 0 
    then 
        move  hold-oma-fee-2 (ss-clmdtl-oma, ohip)	to hold-oma-fee-1(ss-clmdtl-oma, ohip) 
    else 
        if        hold-oma-fee-2 (ss-clmdtl-oma, ohip) = 0 
        then 
            move  hold-oma-fee-1 (ss-clmdtl-oma, ohip)	to hold-oma-fee-2(ss-clmdtl-oma, ohip) 
    	else 
            next sentence. 
*	endif 
*   endif 
* 
 
ha1a-99-exit. 
    exit. 

* 2011/06/13 - MC16 - ha12-check-for-sli-oma & hb0-build-susp-dtl-rec-dtl subroutines in defined in the
*                   copybook $use/newu701_oscar_dtl_edit_check.rtn

copy "newu701_oscar_dtl_edit_check.rtn".

* 2011/06/13 - end

ia0-proc-rec-type-address. 
    move unpriced-pat-addr-1             to addr-address-line-1. 
    move unpriced-pat-addr-2             to addr-address-line-2. 
    move unpriced-pat-addr-3             to addr-address-line-3. 
    move unpriced-pat-addr-post-cd       to addr-postal-code. 
ia0-99-exit. 
    exit. 


 
pa0-proc-rec-type-address. 
 
    move unpriced-pat-addr-1             to addr-address-line-1. 
    move unpriced-pat-addr-2             to addr-address-line-2. 

*   brad (suspend address record's addr-3 used later in r702/u703.cbl 
*	  and need to be hin's province not the living address)
*    move unpriced-clmhdr-hc-prov-cd	 to addr-address-line-3.
* be5 comment this out -go back to original province and see if ok???
*    move unpriced-clmhdr-hc-prov-cd-2	 to addr-address-line-3.
*    move unpriced-pat-addr-3             to addr-address-line-3. 
     move unpriced-pat-addr-3             to addr-address-line-3. 
    
    move unpriced-pat-addr-post-cd       to addr-postal-code. 

*   brad
*   (new fields picked up on this record)
*   PATIENT NAMES
*brad OK 
    move unpriced-clmhdr-pat-surname     to clmhdr-pat-acronym6 
                                            clmhdr-patient-surname. 
*brad2
     move unpriced-clmhdr-surname-1-6    to susp-hdr-acronym-1-6.
     move unpriced-clmhdr-given-name1-3  to susp-hdr-acronym-7-9.

*brad    move unpriced-clmhdr-pat-surname     to addr-surname.
*brad    move unpriced-clmhdr-given-name      to addr-first-name.
    move unpriced-clmhdr-phone-no 	 to addr-phone-no.

*   SEX
    if   unpriced-clmhdr-sex = "1" 
    then 
         move "M"                       to      addr-sex 
    else 
    if   unpriced-clmhdr-sex = "2" 
    then 
         move "F"                       to      addr-sex 
    else 
         move unpriced-clmhdr-sex        to      addr-sex. 
*   endif
*   PHONE NBR
*   (if phone nbr is only 7 digits long then default to local area code)
    move unpriced-clmhdr-phone-no	to	temp-phone-nbr.
*    if    (    temp-phone-nbr-1-3  =  0
*           and temp-phone-nbr-4-10 <> 0
*  	   )
*       or (    temp-phone-nbr-1-7  <> 0
*           and temp-phone-nbr-8-10 =  0
*	  )
*    then
*	(default area-code)
*	move default-area-code		 to     unpriced-clmhdr-phone-no-1-3
*        if temp-phone-nbr-8-10 = 0
*	then
*	    move temp-phone-nbr-1-7	 to	unpriced-clmhdr-phone-no-4-10
* 	else
*	    move temp-phone-nbr-4-10	 to	unpriced-clmhdr-phone-no-4-10.
**	endif
**   endif
*  brad
pa0-99-exit. 
    exit. 
ka0-proc-rec-type-trailer. 
 
*   (processing a TRAILER rec)
*   (ensure that all numeric fields are zero filled in trailer rec)
    inspect unpriced-trailer-clmhdr1-cnt  replacing all space-char by zeros.
    inspect unpriced-trailer-clmhdr2-cnt  replacing all space-char by zeros.
    inspect unpriced-trailer-itm-cnt      replacing all space-char by zeros.
    inspect unpriced-trailer-pat-addr-cnt replacing all space-char by zeros.

*    (if there were detail records in hold area from the previous claim
*      header rec then area process them - ie. price them and write them out) 
    perform xx0-process-hold-dtls	thru xx0-99-exit. 
 
    if (last-record-is-h) or (detail-written) 
    then 
        move 'N'                   to   detail-written-flag 
*	(HEADER WRITTEN OUT IN XX0 ROUTINE) 
*       PERFORM TC0-WRITE-HDR-REC  THRU TC0-99-EXIT 
        perform tf0-write-addr-rec thru tf0-99-exit. 
*   endif 
 
*       CHECK IF AUDIT TOTALS MATCH TRAILER REC TOTAL - WARNING MESSAGE 
    move unpriced-trailer-clmhdr1-cnt    to trl-h-count. 
    move unpriced-trailer-clmhdr2-cnt    to trl-r-count. 
    move unpriced-trailer-itm-cnt        to trl-t-count. 
    move unpriced-trailer-pat-addr-cnt   to trl-a-count. 
 
    add ctr-h-recs-read 
        ctr-h-recs-skipped      giving ctr-tot-h-recs. 
 
    add ctr-r-recs-read 
        ctr-r-recs-skipped      giving ctr-tot-r-recs. 
 
    add ctr-t-recs-read 
        ctr-t-recs-read-skipped giving ctr-tot-t-recs. 
 
    add ctr-a-recs-read 
        ctr-a-recs-read-skipped giving ctr-tot-a-recs. 
 
    if trl-h-count not = ctr-tot-h-recs 
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 16                         to      err-ind 
        move ctr-tot-h-recs             to      err-ctr-h-count 
        move trl-h-count                to      err-trl-h-count 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*   endif 
    if trl-r-count not = ctr-tot-r-recs 
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 34                         to      err-ind 
        move ctr-tot-r-recs             to      err-ctr-r-count 
        move trl-r-count                to      err-trl-r-count 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*   endif 
    if trl-t-count not = ctr-tot-t-recs 
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 17                         to      err-ind 
        move ctr-tot-t-recs             to      err-ctr-t-count 
        move trl-t-count                to      err-trl-t-count 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*   endif 
    if trl-a-count not = ctr-tot-a-recs 
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 18                         to      err-ind 
        move ctr-tot-a-recs             to      err-ctr-a-count 
        move trl-a-count                to      err-trl-a-count 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*   endif 
    if    trl-b-count not = zero 
      and trl-b-count not = ctr-b-recs-read 
    then 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 19                         to      err-ind 
        move ctr-b-recs-read            to      err-ctr-b-count 
        move trl-b-count                to      err-trl-b-count 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit. 
*   endif 
 
    perform ka1-print-batch-audit-tots  thru    ka1-99-exit. 
 
*** S.B. - start.
*** Added the following to prevent a missing detail error
*** from appearing on the first batch record after a previous
*** batch that had any detail records in it.
    move 0                              to      ctr-hdr2-rec
                                                ctr-addr-rec.
*** S.B. - end.

ka0-99-exit. 
    exit. 



ka1-print-batch-audit-tots. 
 
*  (PRINT BATCH AUDIT COUNTERS ON NEW PAGE) 
    move 99                                     to ctr-lines-printed. 
    move 2                                      to ws-carriage-ctrl. 

* 2010/05/19 - MC6
    move '9'					to ru701-page-area.
* 2010/05/19 - end
 
    move "********** AUDIT COUNTERS **********" to audit-title. 
    move zero                                   to audit-value 
                                                   audit-value-2 
                                                   audit-value-3. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move 3                                      to ws-carriage-ctrl. 
    move "TOTAL NBR INPUT RECORDS READ= "       to audit-title. 
    move ctr-recs-read                          to audit-value 
                                                   audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move 2                                      to ws-carriage-ctrl. 
    move "NBR OF BATCH   RECORDS READ = "       to audit-title. 
    move ctr-b-recs-read                        to audit-value 
                                                   audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF TRAILER RECORDS READ = "       to audit-title. 
    move ctr-e-recs-read                        to audit-value 
                                                   audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF HEADER1 RECORDS READ = "       to audit-title. 
    move ctr-h-recs-read                        to audit-value 
                                                   audit-value-3 
                                                   audit-value-4. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF HEADER2 RECORDS READ = "       to audit-title. 
    move ctr-r-recs-read                        to audit-value 
                                                   audit-value-3 
                                                   audit-value-4. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECORDS READ = "       to audit-title. 
    move ctr-t-recs-read                        to audit-value 
                                                   audit-value-3. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECS SKIPPED = "       to audit-title. 
    move ctr-t-recs-read-skipped                to audit-value 
                                                   audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF ADDRESS RECORDS READ = "       to audit-title. 
    move ctr-a-recs-read                        to audit-value 
                                                   audit-value-4. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "TOTAL SVCS HDRS/DETAILS READ= "       to audit-title. 
    move ctr-tot-svcs-read                      to audit-value-5. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "TOTAL $$$  HDRS/DETAILS READ= "       to audit-title. 
    move ctr-tot-dollars-read                   to audit-value-5. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF ADDRESS RECS SKIPPED = "       to audit-title. 
    move ctr-a-recs-read-skipped                to audit-value 
                                                   audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move 3                                      to ws-carriage-ctrl. 
    move "NBR OF HEADER  RECORDS WRITTEN = "    to audit-title. 
    move ctr-suspend-hdr-writes                 to audit-value-2 
                                                   audit-value-4. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move 2                                      to ws-carriage-ctrl. 
    move "NBR OF HEADER1 RECORDS SKIPPED = "    to audit-title. 
    move ctr-h-recs-skipped                     to audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move 2                                      to ws-carriage-ctrl. 
    move "NBR OF HEADER2 RECORDS SKIPPED = "    to audit-title. 
    move ctr-r-recs-skipped                     to audit-value-2. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
    move "NBR OF DETAIL  RECORDS WRITTEN = "    to audit-title. 
    move ctr-suspend-dtl-writes                 to audit-value-2 
                                                   audit-value-3. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
* 2005/08/17 - MC
    move "NBR OF DESCRIPTION RECORDS WRITTEN = "    to audit-title. 
    move ctr-suspend-desc-writes                 to audit-value-2 
                                                   audit-value-3. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
* 2005/08/17 - end
 
    move "NBR OF ADDRESS RECORDS WRITTEN = "    to audit-title. 
    move ctr-suspend-addr-writes                to audit-value-4. 
    move audit-line                             to rpt-line. 
    move spaces                                 to audit-line. 
    perform zz0-write-err-rpt-line              thru zz0-99-exit. 
 
*  (FORCE NEW PAGE AFTER TOTALS) 
    move 99                                     to ctr-lines-printed. 
 
ka1-99-exit. 
    exit. 
xb0-print-warning-line. 
 
    move 2                      to      ws-carriage-ctrl. 
    move 1                      to      err-ind. 
    move batch-provider-nbr     to      err-msg-pract-nbr. 
*   brad1
    if hdr-accounting-nbr = " " 
    then
	move hold-accounting-nbr    to      hdr-accounting-nbr.
*  endif


    move hdr-accounting-nbr     to      err-msg-account-id. 
    perform zb0-build-write-err-rpt-line 
                                thru    zb0-99-exit. 
 
xb0-99-exit. 
    exit. 
 
xd0-verify-date. 
 
    move "Y"                            to flag-date. 
 
    if   ws-date-mm < 1 
      or ws-date-mm > 12 
    then 
        move "N"                        to flag-date 
    else 
        if   ws-date-dd < 1 
          or ws-date-dd > max-nbr-days (ws-date-mm) 
        then 
            move "N"                    to flag-date. 
*       endif 
*   endif 
 
xd0-99-exit. 
    exit. 
ta0-read-diskette. 
 
    move unpriced-input-rec-type         to      last-record-type-flag. 
 
    move low-values                     to      unpriced-Claims-record. 
 
    read unpriced-claims-file 
        at end 
            move "Y" to eof-input-file-flag 
            go to ta0-99-exit. 
 
*  (REPLACE ANY NULLS IN RECORD WITH BLANKS) 
    inspect unpriced-claims-record replacing all low-values by spaces. 
 
*  (REPLACE ANY CARRIAGE-RETURNS IN RECORD WITH BLANKS) 
    inspect unpriced-claims-record replacing all carriage-return by spaces. 
 
*   (SET FLAG TO TEST RECORD TYPE) 
    move unpriced-input-rec-type to      record-type-flags. 
 
*   (CHECK WHETHER THIS RECORD WILL BE PROCESSED OR SKIPPED) 
    if    skip-processing-this-acct-id 
      and t-record 
    then 
        add 1                   to      ctr-t-recs-read-skipped 
    else 
        if   (skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl) 
          and a-record 
        then 
            add 1               to      ctr-a-recs-read-skipped 
        else 
            next sentence. 
*       endif 
*   endif 
 
    add 1                       to      ctr-recs-read. 
 
ta0-99-exit. 
    exit. 
 
 
 
 
tb0-read-doc. 
 
    move "Y"                    to flag-doc. 
    read doc-mstr 
        invalid key move "N"    to flag-doc 
                    go to tb0-99-exit. 
 
*   IF WS-DOC-NBR NOT EQUAL TO 0 AND 
*      WS-DOC-NBR NOT EQUAL TO DOC-NBR 
*   THEN 
*       PERFORM YB1-READ-NEXT-DOC   THRU YB1-99-EXIT 
*   ELSE 
*       IF DOC-DATE-FAC-TERM GREATER THAN '000000' 
*       THEN 
*           PERFORM YB1-READ-NEXT-DOC   THRU YB1-99-EXIT. 
*       endif 
*   endif 
 
 
tb0-99-exit. 
    exit. 
 

 
tc0-write-hdr-rec. 

*   (00/oct/02 B.E. - oma/ohip prices summed separately)
*      move ctr-tot-dollars-claim  to clmhdr-tot-claim-ar-oma 
    move ctr-tot-dollars-oma	to clmhdr-tot-claim-ar-oma.
    move ctr-tot-dollars-ohip	to clmhdr-tot-claim-ar-ohip. 

*   (00/jun/05 B.E. added summation into header amt for tech fee)
    move ctr-tot-tech-claim	to clmhdr-amt-tech-billed.

*   2005/08/09 - MC - override clmhdr-tape-submit-ind to blank before
*			writing to suspend hdr. The value should be blank instead of 'Y' or 'N'.

    move space 			to clmhdr-tape-submit-ind.
*   2005/08/09 - end

 
    if update-suspense
    then
        add 1                           to      ctr-suspend-hdr-writes
* be6
*       move " " 			to	clmhdr-health-care-prov
* 	move hdr-health-care-prov	to	clmhdr-health-care-prov
*   	move hdr-health-care-nbr

* be4
*	(prior move of this field not going to suspend hdr so default here)
        move "A"			to	clmhdr-hosp
	write suspend-hdr-rec.
*   endif
 
*   (CHECK FOR ERROR FLAG SET BY DECLARATIVES ON PREVIOUS WRITE STMNT) 
    if skip-processing-this-acct-id or skip-hdr-addr-but-write-dtl 
    then 
*     (NOTE: 90/01/14 B.E. LOGIC WILL ALLOW WRITING OF HEADER TO FAIL BUT FLAG HAS BEEN 
*      SET SO THAT THE DETAIL RECS  FOR THIS HEADER WILL BE PROCESSED AND THEREFORE 
*      WILL BECOME DETAILS FOR THE HEADER ALREADY ON FILE. MESSAGE ON WARNING 
*      REPORT SHOULD ALERT STAFF TO REVIEW CLAIM TO CONFIRM THAT THESE 
*      HEADERS ARE FOR SAME PATIENT) 
 
	move ws-error-literal		to	err-warn-msg
        perform xb0-print-warning-line  thru    xb0-99-exit 
        move 1                          to      ws-carriage-ctrl 
        move 9                          to      err-ind 
        perform zb0-build-write-err-rpt-line 
                                        thru    zb0-99-exit 
        add 1                           to      ctr-h-recs-skipped 
        go to tc0-99-exit. 
*   endif 
 
    move zero                           to      ctr-tot-dollars-oma
						ctr-tot-dollars-ohip
						ctr-tot-tech-claim. 
 
tc0-99-exit. 
    exit. 
 
 
 
td0-write-susp-dtl. 
 
    if update-suspense
    then
	add 1                       to ctr-suspend-dtl-writes
	write suspend-dtl-rec.
*    endif
 
td0-99-exit. 
    exit. 
 
 
 
te0-write-disk-out. 
 
    if create-priced-file
    then
	add 1                       to ctr-diskout-writes
	write diskout-output-rec. 
*   endif
 
te0-99-exit. 
    exit. 
 
 
 
tf0-write-addr-rec. 
 
    if update-suspense
    then
	add 1                      to ctr-suspend-addr-writes
	write suspend-address-rec
        invalid key 
               move "D"            to skip-process-this-acct-id-flag
               go to tf0-99-exit. 
 
tf0-99-exit. 
    exit. 
 
 
tg0-read-oma-fee-mstr. 
 
    move "Y"                    to flag-oma. 
    read oma-fee-mstr 
        invalid key move "N"    to flag-oma. 
 
tg0-99-exit. 
    exit. 


* brad
th0-read-oscar-provider. 
 
    move "Y"                    to flag-oscar-provider. 
    read oscar-provider
        invalid key move "N"    to flag-oscar-provider
                    go to th0-99-exit. 
th0-99-exit.
    exit

 
uj1-read-isam-const-mstr. 
 
    move 'N'                            to flag-lock. 
 
    read    iconst-mstr 
        invalid key 
            move "Y"                    to      fatal-error-flag 
            go to uj1-99-exit. 
 
    move "N"                            to      fatal-error-flag 
 
    add  1                              to ctr-read-const-mstr. 
 
uj1-99-exit. 
    exit. 


xc0-check-oma-code. 
 
    perform tg0-read-oma-fee-mstr        thru tg0-99-exit. 
 
    if     not valid-oma-code 
       and not price-only-claim
    then 
        move 2                          to      ws-carriage-ctrl 
        move 8                          to      err-ind 
        move clmhdr-accounting-nbr      to      err-accounting-nbr 
        perform zb0-build-write-err-rpt-line    thru    zb0-99-exit 
*       (BLANK OUT OMA FEE RECORD SINCE IT WAS INVALID) 
        move spaces                     to      fee-mstr-rec. 
*   endif 
 
xc0-99-exit.
    exit. 


xx0-process-hold-dtls. 
 
*   (process the detail records in the hold area  - ie. price 
*    them, write them out, and reset counters/subscripts) 
    if batch-provider-nbr = "264978"
    then 
	if hold-accounting-nbr = "00000004"
        then
	    next sentence
	else
	    next sentence
    else
	next sentence.
*   endif
 
    if ss-clmdtl-oma > 0 
    then 
*	(initialize next available dtl subscript)
	move ss-clmdtl-oma 		       to     ss-clmdtl-next-avail-dtl
        move "N"			       to     flag-tech-prof-suffix-rule
        perform zz3-apply-tech-prof-suff-rules thru   zz3-99-exit
		varying ss-tech-prof-suff
   		from    1 
   		by      1 
		until ss-tech-prof-suff > ss-clmdtl-oma 
*       (if new details added, then increase max dtl subscript)
	perform xx1-test-for-new-dtls	thru	xx1-99-exit
	move 1				to	ss-basic-times-desc-rec
	move 0				to	ss-basic-times
        perform ya0-price-claim         thru    ya0-99-exit 

* 2005/08/17 - MC
	perform xx3-write-susp-desc	thru xx3-99-exit
	move spaces			to flag-desc-rec

* 2005/08/17 - end

	perform xx2-write-susp-diskout-dtl      thru    xx2-99-exit
		varying ss-write-dtl 
   		from    1 
   		by      1 
		until ss-write-dtl > ss-clmdtl-oma 
        move 'Y'                        to   detail-written-flag 
*  	(reset subscripts for detail recs) 
	move 0				to   ss-clmdtl-oma 
					     ss-price 
					     ss-write-dtl 
*   	(00/aug/13 B.E. - reset special add-on code flag)
	move "N"			to   ws-special-add-on-cd-entered

* 2011/05/18 - MC15
        perform xx1a-reset-oma-flag     thru xx1a-99-exit
* 2011/05/18 - end

 
*       (b.e. - 2000/jun/28 zero out hold area)
        perform aa1-init-hold-oma-rec      thru    aa1-99-exit
		varying i
   		from    1 
   		by      1 
* 2006/02/15 - MC
*		until   i  > 40
		until   i  > ss-max-nbr-oma-det-rec-allow
*	(WRITE OUT HEADER NOW THAT PRICES ARE KNOWN) 
        perform tc0-write-hdr-rec       thru tc0-99-exit 
   else
**      (This is to ensure that each claim has a detail record.  If not,
**       then an error is generated)
        if     ss-clmdtl-oma = 0 			
           and ctr-hdr2-rec = 1
           and ctr-addr-rec = 1
           and not price-only-claim
        then
	   move ws-error-literal		to	err-warn-msg
	   perform xb0-print-warning-line thru xb0-99-exit
	   move 1                          to   ws-carriage-ctrl
	   move 50                         to   err-ind
	   move clmhdr-accounting-nbr      to   err-no-detail-claim
	   perform zb0-build-write-err-rpt-line thru zb0-99-exit.
*	endif
*   endif

xx0-99-exit. 
    exit. 
 
 
xx1-test-for-new-dtls.

*   (if next available detail record number is greater than original
*    max number of details, then new records were created so update
*    new maximum)

    if ss-clmdtl-next-avail-dtl > ss-clmdtl-oma
    then
	move ss-clmdtl-next-avail-dtl 	to	ss-clmdtl-oma.
*   endif

xx1-99-exit.
    exit.

* 2011/05/18 - MC15
xx1a-reset-oma-flag.

copy  "d001_newu701_oma_code_variables_reset.rtn".

xx1a-99-exit.
exit.

* 2011/05/18 - end

 
xx2-write-susp-diskout-dtl.
*   (write detail rec from data in the priced hold area to the suspend file) 

*   (sum total priced detail into audit total of run
*    using whichever price is to be used)

*   (pricing algorithm may have overriden prices but for total
*   dollars 'read' use the incoming amounts)

    add hold-fee-incoming(ss-write-dtl) to   ctr-tot-dollars-read.

    add hold-fee-ohip(ss-write-dtl)	to   ctr-tot-dollars-ohip.
    add hold-fee-oma (ss-write-dtl)	to   ctr-tot-dollars-oma.

*   (2000/jun/05 B.E. - keep running counter of tech fee to sum into hdr rec)
    add  hold-priced-tech(ss-write-dtl)	to   ctr-tot-tech-claim.

    perform hb0-build-susp-dtl-rec-dtl	thru hb0-99-exit. 
 
    perform td0-write-susp-dtl           thru td0-99-exit. 
 
*   (BUILD DISKOUT DISKETTE RECORD) 
    perform xx2a-build-diskout-rec	 thru xx2a-99-exit. 
    perform te0-write-disk-out           thru te0-99-exit. 
 
xx2-99-exit. 
    exit. 
 
 
xx2a-build-diskout-rec. 
 
    move hold-accounting-nbr                to  diskout-clmhdr-claim. 

*   (2001/oct/03 B.E. added new clinic-nbr to output file)
    move bt-clinic-nbr-1-2		    to  diskout-clmhdr-clinic-nbr.

    move hold-oma-cd	    (ss-write-dtl)  to  diskout-oma-svc-code. 
    move hold-oma-suff      (ss-write-dtl)  to  diskout-oma-svc-suff. 
    move hold-sv-nbr-serv   (ss-write-dtl)  to  diskout-nbr-serv. 
    move hold-sv-date	    (ss-write-dtl)  to  diskout-svc-date. 
    move hold-fee-oma 	    (ss-write-dtl)  to  diskout-oma-amt-billed. 
    move hold-fee-ohip      (ss-write-dtl)  to  diskout-ohip-amt-billed. 
    move hold-priced-tech   (ss-write-dtl)  to  diskout-priced-tech. 
    move hold-basic-tech    (ss-write-dtl)  to  diskout-basic-tech. 
    move hold-basic-prof    (ss-write-dtl)  to  diskout-basic-prof. 
    move hold-basic-fee     (ss-write-dtl)  to  diskout-basic-fee. 
    move carriage-return                    to  diskout-cr. 
 
xx2a-99-exit. 
    exit. 

* 2005/08/17 - MC - if adjudication-desc-entry, create description record
*		    and set manual review to 'Y'
xx3-write-susp-desc.

* 2008/04/29 - MC - initialize line no
    move 0					to clmdtl-line-no of suspend-desc-rec.
* 2008/04/29 - end

    if adjudication-desc-entry
    then
	move 'Y'				to clmhdr-manual-review
	move "G259 BILLED AT 85%"		to clmdtl-suspend-desc of suspend-desc-rec
        move 1					to clmdtl-line-no of suspend-desc-rec
	move clmhdr-doc-pract-nbr		to clmdtl-doc-pract-nbr of suspend-desc-rec
	move clmhdr-accounting-nbr		to clmdtl-accounting-nbr of suspend-desc-rec
        move clmhdr-status			to clmdtl-status of suspend-desc-rec
        if update-suspense
    	then
	    add 1                       	to ctr-suspend-desc-writes
            write suspend-desc-rec.
*	endif
*    endif

* 2008/04/29 - MC  - percentage visit preimium

* 2010/10/04 - MC10 - disable the edit check below

*     if        ws-annna = 'Y'
*        and    ws-gnnna = 'Y'
*        and    ws-k991-u997 = 'Y'
*     then	
*	move 'Y'				to clmhdr-manual-review
*	move "Pay visit premium"  		to clmdtl-suspend-desc of suspend-desc-rec
*       add  1					to clmdtl-line-no of suspend-desc-rec
*	move clmhdr-doc-pract-nbr		to clmdtl-doc-pract-nbr of suspend-desc-rec
*	move clmhdr-accounting-nbr		to clmdtl-accounting-nbr of suspend-desc-rec
*       move clmhdr-status			to clmdtl-status of suspend-desc-rec
*       if update-suspense
*   	then
*	    add 1                       	to ctr-suspend-desc-writes
*           write suspend-desc-rec
*	    move "based on 'A---A' code"        to clmdtl-suspend-desc of suspend-desc-rec
*           add  1				to clmdtl-line-no of suspend-desc-rec
*  	    move clmhdr-doc-pract-nbr		to clmdtl-doc-pract-nbr of suspend-desc-rec
*	    move clmhdr-accounting-nbr		to clmdtl-accounting-nbr of suspend-desc-rec
*           move clmhdr-status			to clmdtl-status of suspend-desc-rec
*	    add 1                       	to ctr-suspend-desc-writes
*           write suspend-desc-rec.
*       endif 
*    endif

* 2010/10/04 - end


* 2008/04/29 - end
	 
xx3-99-exit.
    exit.

* 2005/08/17 - end

        

copy "pricing_logic.rtn".

xa0-display-details .
*   (this is dummy routine called from pricing copybook logic that
*    is used by d001 to display priced claims on screen. 
*   
*    IF EVER WE NEED TO DUMP PRICED CLAIMS INTO REPORT OR DO OTHER CHECKING
*    THEN HERE IS THE IDEAL AREA TO PLACE THIS CODE
*

xa0-99-exit.
    exit.
za0-common-error.
*   (this is dummy routine called from pricing copybook logic that
*    is used by d001 to display errors
za0-99-exit.
    exit.


zb0-build-write-err-rpt-line. 
 
    move err-msg (err-ind)              to      rpt-line. 

* 2010/05/19 - MC6
    move '5'	                         to      ru701-page-area.
* 201/05/19 - end

    perform zz0-write-err-rpt-line      thru    zz0-99-exit. 
 
zb0-99-exit. 
    exit. 
 
 
zz0-write-err-rpt-line. 
 
     add ws-carriage-ctrl               to      ctr-lines-printed. 
     if ctr-lines-printed > max-lines-per-page 
     then 
        perform zz1-print-headings      thru    zz1-99-exit 
        move 1                          to      ws-carriage-ctrl. 
*    endif 
 
    write rpt-line      after advancing ws-carriage-ctrl lines. 

* 2010/05/19 - MC6
 
    move doc-nbr of doc-mstr-rec to ru701-doc-nbr. 
    move bt-clinic-nbr-1-2	     to ru701-clinic-nbr.
    move batch-specialty 	     to ru701-doc-spec-cd.
    move clmhdr-pat-acronym	     to ru701-pat-acronym.
    move hold-accounting-nbr	     to ru701-accounting-nbr.
    move rpt-line		     to ru701-print-line.
    move ctr-recs-read		     to ru701-orig-rec-no.
    move 'N'			     to ru701-acronym-flag.
    move clmhdr-pat-acronym	     to ru701-acronym.
    move ctr-lines-printed	     to ru701-line-no.
    write ru701-work-rec. 
* 2010/05/19 - end 
zz0-99-exit. 
    exit. 
 
 
 
zz1-print-headings. 
 
*   (SAVE LINE THAT WAS TO BE PRINTED, RESTORE AFTER HEADINGS PRINTED) 
    move rpt-line                  to   save-prt-line. 
 
    add 1                          to   ws-rpt-page-nbr. 
    move ws-rpt-page-nbr           to   rpt-page-nbr. 
    write rpt-line from heading-l1 after advancing page. 
 
*   (97/09/25 B.E. - ADD DOCTOR INFO INTO AUDIT REPORT) 
    move doc-nbr of doc-mstr-rec   to h-l2-doctor-nbr. 
    move doc-inits		   to h-l2-doctor-initials. 
    move doc-name		   to h-l2-doctor-name. 
    move batch-group-nbr  	   to h-l2-clinic. 
    move batch-specialty 	   to h-l2-specialty. 
    write rpt-line from heading-l2 after advancing 1 line. 
 
    move spaces                    to   rpt-line 
    write rpt-line                 after advancing 2 lines. 
    move 2                         to   ctr-lines-printed. 
 
    move save-prt-line             to   rpt-line. 
 
zz1-99-exit. 
    exit. 


zz3-apply-tech-prof-suff-rules.

copy "tech_prof_suff_split_part1.rtn"
     replacing  ==ss-clmdtl-oma== by ==ss-tech-prof-suff==.

zz3-99-exit.
    exit.


copy "tech_prof_suff_split_part2.rtn"
     replacing  ==ss-clmdtl-oma== by ==ss-tech-prof-suff==.
 
copy "y2k_default_sysdate_century.rtn". 

copy "pricing_test_min_max_limits.rtn".

copy "d001_newu701_oma_code_edit.rtn".