identification division. 
program-id. d004.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/01/31. 
date-compiled. 
security. 
* 
*    files      : f001 - batch control file   
*		: f002 - claims master 
*		: f020 - doctor master 
*		: f030 - location master 
*		: f040 - oma fee schedule master 
*		: f090 - constants master 
* 
*    program purpose : 'adjustment'/'payment' batch data entry. 
* 
* 
* 
*	revision history: 
*		oct 23/81 - checks status of batch accessed in 'continue' 
*			    mode. if not 'balanced/unblanced' then requires 
*			    password to continue. (be) 
* 
* 
*		feb 17/81 - removal of forced agent '7' on 'p/m' type batches. (be) 
* 
* 
*		feb/82	  - no force of agent '7' (be) 
* 
* 
*		mar/81    - service date modifications (see sms14 - nov 24/81) 
*			    and update of reference field with reason code (iw) 
* 
*		sep/83    - added clmhdr-tot-claim-ar-ohip to be updated 
*                           for batch of p/c. 
* 
*		may/84 (a.j.) - accept operator input of tech portion of 
*			        payment/adjustment and update related 
*			        claims fields 
* 
*		nov/84 (m.s.) - add "WS-POSTED-OHIP" to 
*				"CLMHDR-CURR-PAYMENT" 
* 
*               may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
* 		sep/87 (m.s.) - sms 97 
*			        default "M" to batctrl-adj-sub-type 
*			        and  clmhdr-adj-sub-type for 'b' 
*			        adjustment only. 
 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*	        jan/88 (m.s.) - pdr 337/343 - sms 105 
*				allow user to override the default 
*				location code when doing revenue 
*				or miscellaneous adjustment. 
* 
*		nov/88 (m.s.) - sms 99 
*				if batctrl-amt-act  > 99999.99, 
*				then display the error message, 
*				re-enter the claim with the new batch. 
* 
*		nov/88 (m.s.) - sms 111 
*				if adjust code = 'R', 'M', 'C' or 'A', 
*				set the oma fee to be the same as ohip, 
*				and also bypass the oma fee field, do 
*				not accept any value on that field 
* 
*	        mar/89 (s.f.) - sms 105 
*				allow user to override the default 
*				location code on the detail screen 
*				for "R" adjustments 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised jan/91   : - sms 137 (b.l) 
*		       - change the percentage field for miscellaneous 
*			 payment with 2 decimal places 
* 
*   revised jan/91   : - pdr 472 (m.c.) 
*		       - do not allow to override the location from 
*			 'MISC' in batch control screen for miscellaneous 
*			 payment 
* 
*   revised jan/91   : - pdr 471 (m.c.) 
*		       - for 'M' payment, prompt for doctor number 
*			 before pay code, so pay code 0 will be 
*			 displayed properly from doctor master, other 
*			 pay code is displaying fine from f090. 
* 
*   revised aug/91   : - pdr 504 (m.c.) 
*		       - initialize ws-doc-nbr to zero in the subroutine 
*			 of initialization 
*		       - reset the occur and feedback in xe0-read-claims 
*			 subroutine 
*		       - change max locations in doctor from 20 to 30. 
* 
*   revised feb/93   : - pdr 560 (m.c.) 
*		       - use doc-dept instead of clmhdr-doc-dept-nbr 
*			 when user enters adjustment or payment 
* 
*   revised sep/93   : - pdr 582 (m.c.) 
*		       - for miscellaneous payment, do not force user 
*			 to reenter the pay code and amount unless they 
*			 do want to overwrite 
*		       - if user enters 'L' and adj-cd is not 'R', allow 
*			 user to enter or change explanation field 
*  01/may/07 B.E. - attempted to reconcile code and error/warnings with the
*		    fact that now ohip/rma amounts may differ yet the technical
*		    amount of adjustment can not be different and must be
*		    taken from both. This means that the professional amount
*		    calculation between oma/ohip may be wrong - code now
*		    shows the appropriate calculation based upon the agent
*		    in the same fashion as d003
*  02/sep/26 M.C. - do not allow user to adjust claims that have not gone
*                    to ohip yet (ie. batch status < 3)
*  03/nov/05 b.e. - alpha doctor number
*  05/mar/01 M.C. - for miscellaneous payment, do not allow user to enter pay code
*		    default pay code to be zero
*
*  11/Nov/16 MC1  - for miscellaneous payment, provide warning if doctor is terminated   
*		  - allow user to put '*' to bypass if they still want to use the terminated doctor
*  12/Nov/14 MC2  - alert user if batch actual amount does not match batch estimated amount     
*  13/Aug/27 MC3  - alert user if doctor nbr has not assigned the selected clinic nbr for Misc Payment               
*  13/Nov/06 MC4  - display doctor name for miscellaneous payment as well as cash payments & A,B,R adjustments 
*  15/Mar/18 MC5  - include f040_dtl.slr/fd and add edit check against f040_dtl with miscellaneous payment
*  15/May/12 MC6  - for miscellaneous payment, provide warning if doctor is terminated within 6 months from current run date;
*		    error if terminated more than 6 months.  Allow user to enter password in order to allow enter payment
*		    for doctor terminated more than 6 months
*  17/Mar/20 MC7  - modify $use/f040_dtl.fd to include doc-nbr, include doc-nbr when edit check against f040_dtl with 
*		    miscellaneous payment

environment division. 
input-output section. 
file-control. 
* 
    copy "f001_batch_control_file.slr". 
* 
    copy "f002_claims_mstr.slr". 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f030_locations_mstr.slr". 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* MC5
    copy "f040_dtl.slr".

data division. 
file section. 
    copy "f001_batch_control_file.fd". 
* 
    copy "f002_claims_mstr.fd". 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f030_locations_mstr.fd". 
* 
    copy "f040_oma_fee_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "f090_const_mstr_rec_3.ws". 
*
* MC5
    copy "f040_dtl.fd".
* 
working-storage section. 
 
77  err-ind					pic 99      value zero. 
77  password-input				pic x(3). 
77  password 					pic x(3)    value "RMA". 
77  password-special-privledges			pic x(3)    value "GCN". 
77  reply					pic x. 
77  change-reply				pic x. 
 
77  ws-batctrl-amt-act				pic s9(6)v99. 
77  ws-svc-posted				pic 99.      
77  ws-hold-posted-oma				pic s9(6)v99. 
77  ws-hold-50-perc				pic s9(6)v99. 
77  ws-posted-oma				pic s9(6)v99. 
77  ws-posted-ohip				pic s9(6)v99. 
77  ws-amt-tech					pic s9(6)v99. 
77  abs-posted-oma				pic 9(6)v99. 
77  abs-posted-ohip				pic 9(6)v99. 
77  abs-amt-tech				pic 9(6)v99. 
77  ws-prof-oma					pic s9(6)v99. 
77  ws-prof-ohip				pic s9(6)v99. 
77  ws-orig-total-svc				pic 99. 
77  ws-orig-oma					pic s9(6)v99. 
77  ws-orig-ohip				pic s9(6)v99. 
77  ws-batctrl-amt-diff				pic s9(5)v99. 
77  ws-batctrl-svc-diff				pic s9(5)v99. 
*!77  ws-doc-nbr					pic 999. 
77  ws-doc-nbr					pic xxx. 
77  ws-doc-nbr-alpha				pic xxx.        
77  ws-file-err-msg				pic x(42)  value spaces. 
77  ws-flag-ok-to-adjust			pic x. 
77  ws-i-o-pat-ind				pic x. 
77  ws-oma-cd					pic x999. 
77  ws-loc					pic xxxx. 
77  ws-misc-code-perc				pic 999v99. 
77  hold-week					pic xx. 
77  hold-day					pic x. 
* (y2k - auto fix)
*77  hold-adjusted-clms-sv-date			pic x(6). 
77  hold-adjusted-clms-sv-date			pic x(8). 
* (y2k - auto fix)
*77  hold-adjusted-clms-de-date			pic x(6). 
77  hold-adjusted-clms-de-date			pic x(8). 
77  temp					pic s9(7)v99. 
* 
77  confirm-space				pic x   value space. 
 
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
*   note !!!! :  the size of this save area must be enlarged if the record 
*		 size of 'f001_batch_control_file' is increased 
77  ws-save-batctrl-rec				pic x(112). 
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

77  feedback-oma-fee-mstr			pic x(4). 
 
77  ws-save-batctrl-key				pic x(9). 
77  ws-save-batctrl-feedback			pic x(4). 
 
*mf77  ws-save-claims-header			pic x(149). 
77  ws-save-claims-header			pic x(216). 
77  ws-save-claims-feedback			pic x(4). 
 
 
01  ws-date. 
* (y2k - auto fix)
*   05  ws-yy					pic 99. 
    05  ws-yy					pic 9(4). 
    05  ws-mm					pic 99.    
    05  ws-dd					pic 99. 
 
copy "def_agents.ws".
 
copy "mth_desc_max_days.ws". 
 
copy "sysdatetime.ws". 
 
* 
*  subscripts 
* 
77  ss						pic 99	comp. 
77  ss-clmhdr					pic 99	comp. 
77  ss-clmdtl-desc				pic 99	comp. 
77  ss-conseq-dd				pic 99	comp. 
77  ss-det-nbr					pic 99	comp. 
77  ss-ind					pic 99	comp. 
* 
 
* 
*	(maximum values or limits that may have to be changed 
*		if record layouts are altered) 
* 
*77  ss-max-nbr-locs-in-doc-rec			pic 99	comp	value  20. 
77  ss-max-nbr-locs-in-doc-rec			pic 99	comp	value  30. 
77  ss-max-nbr-of-desc-rec-allow		pic 99	comp	value  5. 
 
 
* 
*  feedback values for all indexed files 
* 
77  feedback-batctrl-file			pic x(4). 
77  feedback-claims-mstr			pic x(4). 
77  feedback-doc-mstr				pic x(4). 
77  feedback-loc-mstr				pic x(4). 
77  feedback-oma-mstr				pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
* 
*  eof flags 
* 
77  eof-filename-here				pic x	value "N". 
* 
*  status file indicators 
* 
77  status-common				pic x(2). 
77  status-batctrl-file				pic x(11)	value zero. 
77  status-cobol-batctrl-file			pic xx		value zero. 
77  status-claims-mstr				pic x(11)	value zero. 
77  status-cobol-claims-mstr			pic xx		value zero. 
77  status-doc-mstr				pic x(11)     	value zero. 
77  status-cobol-doc-mstr			pic xx		value zero. 
77  status-loc-mstr				pic x(11)  	value zero. 
77  status-cobol-loc-mstr			pic xx		value zero. 
77  status-oma-mstr				pic x(11)  	value zero. 
77  status-cobol-oma-mstr			pic xx		value zero. 
77  status-iconst-mstr				pic x(11)  	value zero. 
77  status-cobol-iconst-mstr			pic xx		value zero. 
* MC5
77  status-cobol-f040-dtl  			pic xx		value zero. 
 
* 
*  keys (and/or record layouts) for all indexed files 
* 
*mf copy "f001_key_batctrl_file.ws". 
 
*mf copy "f002_key_claims_mstr.ws". 
 
01  claims-occur				pic 9(12). 
 
copy "f002_claims_mstr_rec1_2.ws". 
 
 
01  key-loc-mstr. 
    05  key-loc-nbr				pic x(6). 
 
01  key-oma-fee-mstr. 
    05  key-oma-cd				pic x(4). 
 
01 const-mstr-rec-nbr				pic 99. 
 
 
 
 
   
01  option					pic x. 
    88  new-batch				value "1". 
    88  old-batch				value "2". 
    88  stop-option				value "*". 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
    88  invalid-ohip				value "N". 
    88  invalid-chart				value "N". 
 
01  flag-err-data				pic x. 
    88  err-data				value "N".    
    88  ok-data					value "Y".     
 
01  flag-dummy-claim-id				pic x. 
    88  dummy-claim-id-required			value "Y". 
 
01  flag-eoj					pic x. 
    88  eoj					value "E".     
 
01  flag-dup-key-status				pic x(4). 
    88  duplicate-key				value "0100".  
 
 
*   counters for records read/written for all input/output files 
 
 
01  counters. 
    05  ctr-read-batctrl-file			pic 9(7). 
    05  ctr-read-claims-mstr			pic 9(7). 
    05  ctr-read-doc-mstr			pic 9(7). 
    05  ctr-read-loc-mstr			pic 9(7). 
    05  ctr-read-oma-mstr			pic 9(7). 
    05  ctr-read-const-mstr			pic 9(7). 
 
    05  ctr-writ-batctrl-file			pic 9(7). 
    05  ctr-writ-claims-mstr			pic 9(7). 
 
    05  ctr-rewrit-batctrl-file			pic 9(7). 
    05  ctr-rewrit-claims-mstr			pic 9(7). 
    05  ctr-rewrit-const-mstr			pic 9(7). 
    05  ctr-del-batctrl-file			pic 9(7). 
 
 
01  error-message-table. 
 
    05  error-messages. 
* msg #1 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"NO SUCH ADJUSTMENT BATCH EXISTS IN THE BATCH CONTROL FILE". 
	10  filler				pic x(60)   value 
		"INVALID PASSWORD".         
	10  filler				pic x(60)   value 
		"FATAL ERROR #1 !! -- LAST CLAIM IN BATCH NOT FOUND". 
	10  filler				pic x(60)   value 
		"INVALID DATE". 
	10  filler				pic x(60)   value 
		"FATAL ERROR #2 !! - DETAIL REC FOUND BUT NOT HEADER REC".                                 
	10  filler				pic x(60)   value 
		"'M' AND 'R' TRANSACTIONS REQUIRE A VALID DOCTOR NBR". 
	10  filler				pic x(60)   value 
		"ZERO CLAIM NBR ALLOWED ONLY FOR TRANSACTION CODE 'M' OR 'R'".                                   
	10  filler				pic x(60)   value 
		"FATAL ERROR #3 !! -- BATCH'S DOCTOR NOT FOUND IN DOC MSTR".                        
* msg #10 
	10  filler				pic x(60)   value 
		"NO SUCH CLAIM NBR ON FILE". 
	10  filler				pic x(60)   value 
		"'A'DJUSTMENT BATCH TRANSACTION CODES ARE 'A', 'B', AND 'R'".                     
	10  filler				pic x(60)   value 
		"'P'AYMENT BATCH TRANSACTION CODES ARE 'C', AND 'M'". 
	10  filler				pic x(60)   value 
		"ATTEMPT TO ADJUST CLAIM THAT HASN'T 'GONE TO OHIP' YET". 
	10  filler				pic x(60)   value 
		"BATCH TYPE MUST BE 'P'AYMENT , OR 'A'DJUSTMENT". 
	10  filler				pic x(60)   value 
		"INVALID WEEK NUMBER IN BATCH ID". 
	10  filler				pic x(60)   value 
		"INVALID DAY IN BATCH ID". 
	10  filler				pic x(60)   value 
		"NON-ZERO AMOUNT REQUIRED". 
	10  filler				pic x(60)   value 
		"FATAL ERROR #4 !! - MAX. OF 99 CLAIMS PER BATCH REACHED".  
	10  filler				pic x(60)   value 
		"BATCH ALREADY EXISTS". 
* msg #20 
	10  filler				pic x(60)   value 
		"INVALID 2 DIGIT CLINIC IDENTIFIER". 
	10  filler				pic x(60)   value 
		"SERIOUS ERROR #5 !! - INVALID CLAIMS MSTR INDEX POINTER".   
	10  filler				pic x(60)   value 
		"CLAIM AGENT CODE = 'OHIP' -- BUT PATIENT'S OHIP # IS INVALID". 
	10  filler				pic x(60)   value 
		"NO CLAIMS ALLOWED - PATIENT OHIP STATUS = 'J2','J8', OR 'K1'". 
	10  filler				pic x(60)	value 
		"NO CLAIMS ALLOWED - PATIENT OHIP STATUS = K4,K5,K6,K7, OR K9". 
	10  filler				pic x(60)	value 
		"IN/OUT PATIENT INDICATOR MUST BE 'I' OR 'O'". 
	10  filler				pic x(60)	value 
		"ZERO PERCENTAGE FOUND FOR MISCELLANEOUS PAY CODE". 
	10  filler				pic x(60)	value 
		"SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE". 
	10  filler				pic x(60)	value 
		"INVALID OMA CODE". 
	10  filler				pic x(60)	value 
		"FATAL ERROR #6 !! - INVALID WRITE CLAIMS HEADER WRITE #1".     
* msg #30 
	10  filler				pic x(60)	value 
		"FATAL ERROR #7 !! - INVALID WRITE CLAIMS HEADER WRITE #2".   
	10  filler				pic x(60)	value 
		"FATAL ERROR #8 !! - INVALID WRITE CLAIMS DETAIL INDX #1".            
	10  filler				pic x(60)	value 
		"FATAL ERROR #9 !! -- INVALID WRITE CLAIMS DETAIL INDX #2".             
	10  filler				pic x(60)	value 
		"AGENT OF REC TO BE ADJUSTED DIFFERS FROM BATCH BEING ENTERED". 
	10  filler				pic x(60)	value 
		"FATAL ERROR #10 !! - ERROR RE-WRITING UPDATED CLAIM HEADER". 
	10  filler				pic x(60)	value 
		"FATAL ERROR #11 !! - ERROR IN WRITING TO BATCH CONTROL FILE". 
	10  filler				pic x(60)	value 
		"FATAL ERROR #12 ! - ERROR RE-WRITING ADJ. CLAIM'S BACTRL REC".              
	10  filler				pic x(60)	value 
		"FATAL ERROR #13 !! - ERROR IN DELETING BATCH CONTROL RECORD". 
	10  filler				pic x(60)	value 
		"MAXIMUM OF 99 ENTRIES HAVE BEEN INPUT FOR BATCH - SHUT DOWN". 
	10  filler				pic x(60)	value 
		"NEXT CLAIM NBR ALREADY EXISTS !! -- START NEW BATCH NBR". 
* msg #40 
	10  filler				pic x(60)   value 
		"FATAL ERROR #14!! -- CAN'T READ ADJUSTED CLAIM'S HDR AGAIN". 
	10  filler				pic x(60)	value 
		"UNABLE TO ACCESS BATCH -- STATUS IS NOT UNBALANCED/BALANCED".                
	10  filler				pic x(60)	value 
		"FATAL ERROR !! - ERROR READING CONSTANTS MSTR RECORD 3". 
	10  filler				pic x(60)	value 
		"OMA VALUE SUPPLIED ALTERED BY OVER 50% OF ORIGINAL VALUE". 
	10  filler				pic x(60)	value 
		"OMA VALUE CAN NOT BE ZERO". 
* msg #45 
	10  filler				pic x(60)	value 
		"TECH Portion exceeds both Adjustment/Original $ amount". 
	10  filler				pic x(60)	value 
		"Tech Portion exceeds either OMA/OHIP $ amount". 
	10  filler				pic x(60)	value 
		"Invalid Technical portion entered". 
	10  filler				pic x(60)	value 
		"BATCTRL Amt > 99999.99, Re-enter the adj in a new batch". 
* 2011/11/16 - MC1
	10  filler				pic x(60)	value 
* MC6
*		"Doctor has terminated, please verify".                   
		"Doctor has terminated within 6 months, please verify".                   
* MC6 - end
* 2011/11/16 - end
* 2012/11/14 - MC2
	10  filler				pic x(60)	value 
		"Estimated batch amount not equal to Actual batch amount".
* 2012/11/14 - end
* 2013/08/27 - MC3
	10  filler				pic x(60)	value 
		"Doctor has not assigned to the selected clinic nbr".  
* 2012/11/14 - end
* MC5
	10  filler				pic x(60)	value 
* MC7
*		"Not valid for Miscellaneous Payment for oma/dept  ".  
		"Not valid for Miscellaneous Payment for oma/dept/doc  ".  
* MC7 - end
* MC5 - end
* MC6
	10  filler				pic x(60)	value 
		"Doctor has terminated > 6 months, please verify".                   
* MC6 - end
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 53 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
screen section. 
 
01  scr-title-batch-control-data. 
 
    05  blank screen. 
    05  line 01 col 01 value is "D004A". 
    05  line 01 col 25 value is "ADJUSTMENT/PAYMENT BATCH DATA ENTRY". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 9(2) using sys-yy. 
    05  line 01 col 71 pic 9(4) using sys-yy. 
    05  line 01 col 75 value "/". 
    05  line 01 col 76 pic 99 using sys-mm. 
    05  line 01 col 78 value "/". 
    05  line 01 col 79 pic 99 using sys-dd. 
* 
01  scr-old-or-new-batch-option. 
 
    05  line 03 col 29 value "1 -CREATE NEW BATCH". 
    05  line 04 col 29 value "2 -CONTINUE EXISTING BATCH". 
    05  line 06 col 36 value "OPTION -". 
    05  scr-option	line 06 col 45 pic x to option auto required. 
* 
01  scr-acpt-batch-type. 
 
    05				line 07 col 01 value "BATCH TYPE". 
    05  scr-batctrl-batch-type	line 07 col 14 pic x using batctrl-batch-type auto. 
* 
01  scr-acpt-batch-nbr. 
 
    05				line 08 col 01 value "BATCH NUMBER". 
    05  scr-batctrl-clinic-nbr-1-2 
				line 08 col 14 pic  99	using batctrl-bat-clinic-nbr-1-2                     
									   auto. 
    05  scr-batctrl-doc-nbr 
*!				line 08 col 17 pic 999	using batctrl-bat-doc-nbr  auto blink.             
				line 08 col 17 pic xxx	using batctrl-bat-doc-nbr  auto blink.             
    05  scr-batctrl-week	line 08 col 21 pic  99	using batctrl-bat-week	auto. 
    05  scr-batctrl-day		line 08 col 23 pic   9  using batctrl-bat-day	auto. 
 
01  scr-val-batch-period-cycle. 
 
    05			line 08 col 27 value "PERIOD END DATE". 
    05  scr-period-ends-yy 
* (y2k - auto fix)
*			line 08 col 45 pic 99 using batctrl-date-period-end-yy 
 			line 08 col 43 pic 9(4) using batctrl-date-period-end-yy
						auto. 
    05			line 08 col 47 value "/". 
    05  scr-period-ends-mm 
			line 08 col 48 pic 99 using batctrl-date-period-end-mm 
					auto. 
    05			line 08 col 50 value "/". 
    05  scr-period-ends-dd 
			line 08 col 51 pic 99 using batctrl-date-period-end-dd 
					auto. 
    05			line 08 col 60 value "CYCLE NUMBER". 
    05  scr-cycle-nbr	line 08 col 73 pic 99 using batctrl-cycle-nbr 
					auto. 
* 
01  scr-acpt-mask. 
 
    05				line 13 col 01 value "CLINIC NUMBER". 
    05  scr-batctrl-clinic-nbr	line 13 col 18 pic 9999 using batctrl-clinic-nbr auto. 
    05				line 15 col 01 value "TRANSACTION CODE". 
    05  scr-batctrl-adj-cd	line 15 col 18 pic x using batctrl-adj-cd auto. 
    05				line 17 col 01 value "AGENT CODE". 
    05  scr-batctrl-agent-cd	line 17 col 18 pic 9 using batctrl-agent-cd auto. 
    05				line 19 col 01 value "LOCATION". 
    05  scr-batctrl-loc		line 19 col 18 pic x999 using batctrl-loc auto. 
* 
01  scr-lit-batctrl-data. 
 
    05			line 11 col 41 value "- BATCH CONTROL INFORMATION -". 
    05			line 13 col 31 value "ESTIMATED $ AMOUNT =". 
    05			line 15 col 31 value "ACTUAL    $ AMOUNT =". 
    05			line 15 col 64 value "OUT BY". 
* 
01  scr-val-batctrl-data. 
 
    05  scr-amt-est 
			line 13 col 52 pic zz,zz9.99- using batctrl-amt-est. 
    05  scr-amt-act 
			line 15 col 52 pic zz,zz9.99- using batctrl-amt-act. 
    05  scr-amt-diff 
			line 15 col 71 pic zz,zz9.99- using ws-batctrl-amt-diff.      
* 
01  scr-acpt-change-verification. 
 
    05			line 22 col 25 value "CHANGE BATCH CONTROL". 
    05			line 22 col 46 value "INFORMATION (Y/N)". 
    05			line 22 col 65 pic x to change-reply auto. 
 
01  scr-acpt-change-password. 
    05			line 22 col 69 value "PASSWORD". 
    05			line 22 col 78 pic xxx to password-input  
							auto secure. 
 
 
01  scr-title-claim-rec-data. 
 
    05  blank screen. 
    05  line 01 col 01 value is "D004B". 
    05  line 01 col 31 value is "ADJUSTMENT/PAYMENT BATCH DATA ENTRY". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 99 using sys-yy. 
    05  line 01 col 71 pic 9(4) using sys-yy. 
    05  line 01 col 75 value "/". 
    05  line 01 col 76 pic 99 using sys-mm. 
    05  line 01 col 78 value "/". 
    05  line 01 col 79 pic 99 using sys-dd. 
* 
01  scr-acpt-clmhdr. 
 
    05			  line 03 col 01 value "CLAIM CONTROL -  CLAIM ID :". 
    05			  line 03 col 29 pic  99  using clmhdr-orig-batch-nbr-1-2.                   
* MC7
*   05			  line 03 col 31 pic 9(6) using clmhdr-orig-batch-nbr-4-9. 
    05			  line 03 col 31 pic x(6) using clmhdr-orig-batch-nbr-4-9. 
* MC7 - end
    05			  line 03 col 39 value "-". 
    05			  line 03 col 40 pic 99 using clmhdr-orig-claim-nbr.  
    05			  line 05 col 01	value "TRANSACTION CODE :". 
    05  scr-adj-cd	  line 05 col 19 pic x    using batctrl-adj-cd auto. 
    05			  line 05 col 25	value "LOCATION :". 
    05  scr-clmhdr-loc	  line 05 col 36 pic x999 using clmhdr-loc auto. 
    05			  line 05 col 45		value "EXPLANATION". 
    05  scr-reference	  line 05 col 57 pic x(9) using clmhdr-reference auto. 
 
01  scr-acpt-clmhdr-tit-1. 
    05			line 07 col 08 value "-- B A T C H  N U M B E R --".             
    05			line 07 col 40 value "(ORIGINAL  VALUES  SHOWN  IN  BRACKETS)". 
    05                  line 08 col 01 value "CLINIC DOC# WEEK DAY CLM# ".      
    05			line 08 col 27 value "OMA  SUFF  DOC#        OHIP AMOUNT".     
    05			line 08 col 64 value "OMA AMOUNT". 
 
01  scr-acpt-clmhdr-dtl-1. 
    05  scr-hdr-clinic-nbr-1-2	line 10 col 03 pic  99  using clmhdr-clinic-nbr-1-2 auto.                       
    05  scr-hdr-doc-nbr		line 10 col 08 pic xxx  using ws-doc-nbr-alpha auto.               
    05  scr-hdr-week       	line 10 col 14 pic  99  using clmhdr-week auto. 
    05  scr-hdr-day        	line 10 col 19 pic   9  using clmhdr-day  auto. 
    05                		line 10 col 21 value "-". 
    05  scr-hdr-claim-nbr  	line 10 col 23 pic  99  using clmhdr-claim-nbr auto. 
    05  scr-hdr-oma-cd     	line 10 col 27 pic x999 using clmhdr-adj-oma-cd auto. 
    05  scr-hdr-oma-suff	line 10 col 34 pic x	using clmhdr-adj-oma-suff auto. 
*!  05  scr-ws-doc-nbr 		line 10 col 38 pic 999  using ws-doc-nbr auto blank when zero. 
    05  scr-ws-doc-nbr 		line 10 col 38 pic xxx  using ws-doc-nbr auto.                       
    05				line 10 col 44 value "(". 
    05				line 10 col 45 pic 99	    using ws-orig-total-svc. 
    05				line 10 col 47 value ")". 
    05				line 10 col 50 value "(". 
    05	scr-orig-ohip    	line 10 col 51 pic z(5)9.99- using ws-orig-ohip. 
    05				line 10 col 61 value ")". 
    05				line 10 col 64 value "(". 
    05	scr-orig-oma		line 10 col 65 pic z(5)9.99- using ws-orig-oma. 
    05				line 10 col 75 value ")". 
    05  			line 12 col 31 value "ADJ/PAYMENT ----:". 
    05  			line 14 col 31 value "TECHNICAL ------:". 
    05  			line 15 col 31 value "PROFESSIONAL ---:". 

* 2013/11/06 - MC4 
01  scr-disp-doc-name.
    05  scr-doc-name   		line 11 col 08 pic x(30)     using doc-name.    
* 2013/11/06 - end 
 
01  scr-disp-clmhdr-dtl-2. 
    05  scr-ohip-posted		line 12 col 51 pic z(5)9.99- using ws-posted-ohip auto blank when zero. 
    05  scr-oma-posted		line 12 col 65 pic z(5)9.99- using ws-posted-oma  auto blank when zero. 
 
01  scr-disp-clmhdr-dtl-3. 
    05  scr-amt-tech 		line 14 col 51 pic z(5)9.99- using ws-amt-tech    auto blank when zero. 
*    05                 		line 14 col 65 pic z(5)9.99- using ws-amt-tech    auto blank when zero. 
    05  scr-prof-ohip   	line 15 col 51 pic z(5)9.99- using ws-prof-ohip   auto blank when zero. 
    05  scr-prof-oma     	line 15 col 65 pic z(5)9.99- using ws-prof-oma    auto blank when zero. 
 
01  scr-misc-pay-code-lit. 
    05			line 13 col 09 value "MISCELLANEOUS". 
    05			line 14 col 11 value "PAY CODE". 
 
 
01  scr-misc-pay-code. 
    05			line 15 col 16 pic 9 using clmhdr-adj-cd-sub-type-ss auto. 
 
 
01  scr-misc-pay-code-perc. 
    05			line 17 col 13 pic zz9.99 using ws-misc-code-perc bell blink. 
    05			line 17 col 20 value "%". 
 
 
01  scr-clear-misc-pay-code. 
 
    05			line 13 col 01 value "                        ". 
    05			line 14 col 01 value "                        ". 
    05			line 16 col 01 value "                        ". 
    05			line 17 col 01 value "                        ". 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
* 
01 file-status-display. 
    05  line 24 col 01 pic x(42) from ws-file-err-msg. 
    05  line 24 col 56	"FILE STATUS = ". 
    05  line 24 col 70	pic x(11) using status-common	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
* 
01  wrn-msg-line. 
    05  line 24 col 01	value "WARNING - "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  ring-bell. 
    05 line 23 col 01  value " " bell. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  verification-screen. 
*  sms 105 allow the location code to be updated for "R" adj.  s.f. 
*   05  line 24 col 58	value "ACCEPT (Y/N/M) ". 
    05  line 24 col 58	value "ACCEPT (Y/N/M/L) ". 
    05  line 24 col 75	pic x	to flag. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  7 col 20  value "# OF BATCH CONTROL READS  =". 
    05  line  7 col 55  pic 9(7) from ctr-read-batctrl-file. 
    05  line  8 col 20  value "# OF CLAIMS MASTER READS  =". 
    05  line  8 col 55  pic 9(7) from ctr-read-claims-mstr. 
    05  line  9 col 20  value "# OF DOCTOR MSTR   READS  =". 
    05  line  9 col 55  pic 9(7) from ctr-read-doc-mstr. 
    05  line 10 col 20 value "# OF LOCATION MSTR  READS  =". 
    05  line 10 col 55 pic 9(7) from ctr-read-loc-mstr. 
    05  line 11 col 20 value "# OF CONSTANTS MSTR READS  =".  
    05  line 11 col 55 pic 9(7) from ctr-read-const-mstr. 
    05  line 12 col 20  value "# OF BATCH CONTROL WRITES =". 
    05  line 12 col 55  pic 9(7) from ctr-writ-batctrl-file. 
    05  line 13 col 20  value "# OF CLAIMS MASTER WRITES =". 
    05  line 13 col 55  pic 9(7) from ctr-writ-claims-mstr. 
    05  line 14 col 20  value "# OF CONST. MSTR RE-WRITES =". 
    05  line 14 col 55  pic 9(7) from ctr-rewrit-const-mstr. 
    05  line 15 col 20  value "# OF BATCH CONTROL DELETES =". 
    05  line 15 col 55  pic 9(7) from ctr-del-batctrl-file. 
    05  line 21 col 20	value "PROGRAM D004 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99	from sys-yy. 
    05  line 21 col 40  pic 9(4)	from sys-yy. 
    05  line 21 col 44	value "/". 
    05  line 21 col 45	pic 99	from sys-mm. 
    05  line 21 col 47	value "/". 
    05  line 21 col 46	pic 99	from sys-dd. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
procedure division. 
declaratives. 
 
err-batctrl-mstr-file section. 
    use after standard error procedure on batch-ctrl-file.       
err-batctrl-file. 
    move status-batctrl-file		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING BATCH CONTROL FILE". 
 
err-claims-mstr-file section. 
    use after standard error procedure on claims-mstr.       
err-claims-mstr. 
    move status-claims-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    move status-doc-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
err-locations-mstr-file section. 
    use after standard error procedure on loc-mstr.          
err-loc-mstr. 
    move status-loc-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING LOCATIONS MASTER". 
 
err-oma-fee-mstr-file section. 
    use after standard error procedure on oma-fee-mstr.      
err-oma-fee-mstr. 
    move status-oma-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING OMA FEE MASTER". 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
    move status-iconst-mstr		to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
 
end declaratives. 
main-line section. 
mainline. 
 
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm.                 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
 
    open i-o	batch-ctrl-file 
		claims-mstr. 
    open input	iconst-mstr 
		doc-mstr 
		loc-mstr 
* MC5		
		f040-dtl
* MC5 - end
		oma-fee-mstr. 
 
000-main-line. 
    perform aa0-batch-initialization		thru aa0-99-exit. 
    if not stop-option 
       then 
	   move spaces				to   flag-eoj 
           perform ab0-processing		thru ab0-99-exit 
	        until eoj 
           perform ac0-totals                   thru ac0-99-exit 
           go to 000-main-line. 
 
*   endif 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-batch-initialization. 
 
    move zeros				to counters       
					   batctrl-rec 
					   ws-doc-nbr 
					   ws-doc-nbr-alpha. 
    move spaces				to batctrl-batch-type 
					   batctrl-hosp 
					   batctrl-adj-cd 
					   batctrl-i-o-pat-ind 
					   claim-header-rec 
					   claim-detail-rec. 
    move zeros			to  clmhdr-claim-id
				    clmhdr-adj-cd-sub-type-ss
				    clmhdr-doc-nbr-ohip
				    clmhdr-doc-spec-cd
				    clmhdr-refer-doc-nbr
				    clmhdr-diag-cd
				    clmhdr-agent-cd
				    clmhdr-date-admit
				    clmhdr-doc-dept
				    clmhdr-curr-payment
				    clmhdr-date-period-end
				    clmhdr-cycle-nbr
				    clmhdr-amt-tech-billed
				    clmhdr-amt-tech-paid
				    clmhdr-tot-claim-ar-oma
				    clmhdr-tot-claim-ar-ohip
				    clmhdr-manual-and-tape-paymnts
				    clmhdr-orig-batch-id
				    clmhdr-submit-date
				    clmhdr-serv-date.
    move zeros			to	ws-svc-posted 
					ws-posted-oma 
					ws-posted-ohip 
					ws-orig-total-svc 
					ws-orig-oma 
					ws-orig-ohip. 
    move zeros			to  clmdtl-id
				    clmdtl-agent-cd
				    clmdtl-nbr-serv
				    clmdtl-sv-date
				    clmdtl-consecutive-sv-date(1)
				    clmdtl-consecutive-sv-date(2)
				    clmdtl-consecutive-sv-date(3)
				    clmdtl-amt-tech-billed
				    clmdtl-fee-oma
				    clmdtl-fee-ohip
				    clmdtl-cycle-nbr
				    clmdtl-diag-cd
				    clmdtl-line-no
				    clmdtl-orig-batch-id.
 
aa0-10-acpt-old-new-batch-opt. 
 
    move spaces					to	option. 
    display scr-title-batch-control-data. 
    display scr-old-or-new-batch-option. 
    perform aa1-acpt-old-or-new-batch-opt	thru	aa1-99-exit. 
 
*	(allow operator to shut down) 
    if stop-option 
    then 
	go to aa0-99-exit. 
*   (else) 
*   endif 
 
 
 
    if old-batch 
    then 
	display scr-acpt-batch-nbr 
	accept  scr-acpt-batch-nbr 
	perform aa2-read-batctrl-file		thru	aa2-99-exit 
	if     not-ok 
	   or (     batctrl-batch-type not = "P" 
	        and batctrl-batch-type not = "A") 
	then 
*	    (BATCH NBR NOT FOUND IN CTRL FILE - OR BATCH FOUND WAS NOT A 'P'AYMENT OR 'A'DJUSTMENT BATCH) 
	    move 2				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to aa0-10-acpt-old-new-batch-opt
	else 
*	    (CAN'T ACCESS BATCH WHOSE STATUS INDICATES IT HAS 'GONE TO OHIP' --                
*	    check password for special override privledges -- dyad personnel only) 
	    move "Y"			 to flag       
	    perform aa5-verify-batch-status thru aa5-99-exit 
	    if not-ok 
	    then 
		go to aa0-10-acpt-old-new-batch-opt
	    else 
*	    (allow operator to override old batch ctrl estimates) 
	        perform xa0-disp-batctrl-data  thru	xa0-99-exit 
		move spaces			to	change-reply 
	        perform xb0-allow-change-of-estimates 
					        thru xb0-99-exit 
		              until  change-reply = "N" 
	        display scr-title-batch-control-data 
*  the following move statement is added by m.s. - sms 99 
		move batctrl-amt-act to ws-batctrl-amt-act 
*	    (display last claim in batch if it exists) 
	        if batctrl-last-claim-nbr = zero 
	        then 
		    next sentence 
	        else 
		    perform aa3-disp-last-claim-in-batch 
					thru	aa3-99-exit 
*	        endif 
*	    endif 
*	endif 
    else 
*     new-batch (-- prompt for batch header info) 
	move 0					to	err-ind 
	perform aa4-acpt-new-batch-hdr-info	thru	aa4-99-exit 
*	(err-ind not = 0 implies error or operator rejected # input, then return to option input) 
	if err-ind not = 0 
	then 
	    go to aa0-10-acpt-old-new-batch-opt
	else 
	    perform xb1-input-batctrl-est	thru	xb1-99-exit 
	    move spaces				to	change-reply 
	    perform xb0-allow-change-of-estimates thru	xb0-99-exit 
		      until   change-reply = "N" 
	    move zero				to	batctrl-last-claim-nbr. 
*	endif 
*   endif 
 
aa0-99-exit. 
    exit. 
aa1-acpt-old-or-new-batch-opt. 
 
    accept scr-old-or-new-batch-option. 
    if   old-batch 
      or new-batch 
      or stop-option 
    then 
	next sentence 
    else 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa1-acpt-old-or-new-batch-opt. 
*   endif 
 
aa1-99-exit. 
    exit. 
aa2-read-batctrl-file. 
 
    move batctrl-batch-nbr			to	key-batctrl-file. 
 
    read batch-ctrl-file  key is key-batctrl-file 
	invalid key 
		move "N"			to	flag 
		go to aa2-99-exit. 
 
    move "Y"					to	flag. 
    add  1					to	ctr-read-batctrl-file.          
 
aa2-99-exit. 
    exit. 
aa3-disp-last-claim-in-batch. 
 
*	(read last claim's header rec) 
    move batctrl-batch-nbr		to	clmhdr-batch-nbr. 
    move batctrl-last-claim-nbr		to	clmhdr-claim-nbr. 
    move zeros				to	clmhdr-zeroed-oma-suff-adj. 
 
*mf move clmhdr-claim-id		to	key-clm-data. 
*mf move "B"				to	key-clm-key-type. 
    move clmhdr-claim-id                to	clmdtl-b-data.
    move "B"                            to	clmdtl-b-key-type.
 
    perform xc0-read-claims-mstr	thru	xc0-99-exit. 
    if not-ok 
    then 
*	(serious data base error !!! -- 
*	  -- last claim nbr as stored in header rec can't be found) 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*	(move 4 digit numeric doc nbr to 3 char alpha display) 
    move clmhdr-doc-nbr			to	ws-doc-nbr. 
    move ws-doc-nbr			to	ws-doc-nbr-alpha. 
 
*    (obtained claim hdr -- read the claim detail rec 
*			 -- then display header and detail) 
    perform xd0-read-clmdtl		thru	xd0-99-exit. 
 
    move clmdtl-fee-ohip		to	ws-posted-ohip 
						ws-orig-ohip. 
    move clmdtl-fee-oma			to	ws-posted-oma 
						ws-orig-oma. 
 
    display scr-acpt-clmhdr. 
    display scr-acpt-clmhdr-tit-1. 
    display scr-acpt-clmhdr-dtl-1. 
    display confirm. 
    stop " ". 
 
aa3-99-exit. 
    exit. 
aa4-acpt-new-batch-hdr-info. 
 
    display scr-acpt-batch-type. 
    perform aa41-acpt-batch-type		thru	aa41-99-exit. 
    move zero					to	batctrl-batch-nbr. 
 
aa4-10. 
    display scr-acpt-batch-nbr. 
    perform aa42-acpt-orig-batch-nbr		thru	aa42-99-exit. 
 
    perform la0-acpt-verification		thru	la0-99-exit. 
    if flag = "M" 
    then 
	go to aa4-acpt-new-batch-hdr-info 
    else 
	if flag = "N" 
	then 
*	    (set indicator so mainline will reject batch # input) 
	    move 99				to	err-ind 
	    go to aa4-99-exit 
	else 
	    next sentence. 
*	endif 
*   endif 
 
    move sys-date				to	batctrl-date-batch-entered. 
 
    perform aa43-obtain-period-and-cycle	thru	aa43-99-exit. 
    display scr-val-batch-period-cycle. 
    display scr-acpt-mask. 
 
    perform aa48-acpt-adj-cd			thru	aa48-99-exit. 
    perform aa47-acpt-agent-cd			thru	aa47-99-exit. 
    perform aa46-acpt-loc			thru	aa46-99-exit. 
 
    move zero					to	batctrl-calc-ar-due 
							batctrl-calc-tot-rev 
							batctrl-manual-pay-tot 
							batctrl-amt-est 
							batctrl-amt-act 
							ws-batctrl-amt-act 
							batctrl-svc-est 
							batctrl-svc-act 
							ws-batctrl-amt-diff 
							ws-batctrl-svc-diff. 
 
*	(write batctrl rec now so that another operator can't use same batch #) 
    perform aa9-write-batctrl-file		thru	aa9-99-exit. 
*   (error if duplicate batch #) 
    if ok 
    then 
	move key-batctrl-file			to	ws-save-batctrl-key 
    else 
	move 19					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to aa4-99-exit. 
*   endif 
 
    display scr-lit-batctrl-data. 
    display scr-val-batctrl-data. 
    move zero					to	err-ind. 
 
aa4-99-exit. 
    exit. 
aa41-acpt-batch-type. 
 
    accept scr-batctrl-batch-type. 
 
    if batctrl-batch-type =   "P" 
			   or "A"        
    then 
	next sentence 
    else 
	move 14				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa41-acpt-batch-type. 
*   endif 
 
aa41-99-exit. 
    exit. 
aa42-acpt-orig-batch-nbr. 
 
    accept scr-batctrl-clinic-nbr-1-2. 
 
    move batctrl-bat-clinic-nbr-1-2		to	iconst-clinic-nbr-1-2. 
 
*	(access isam constants master file to determine if valid 2 digit 
*	 clinic idenifier is valid) 
 
    move "Y"					to	flag. 
    perform xj0-read-const-mstr			thru	xj0-99-exit. 
 
    if flag = "N" 
    then 
	move 20					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to aa42-acpt-orig-batch-nbr. 
*   (else) 
*   endif 
 
*	(preset claim header clinic nbr from 1st two digits of batch nbr clinic nbr)                         
    move iconst-clinic-nbr			to	batctrl-clinic-nbr. 
 
 
    accept  scr-batctrl-doc-nbr. 
    display scr-batctrl-doc-nbr. 
    accept  scr-batctrl-week. 
    accept  scr-batctrl-day. 
 
aa42-99-exit. 
    exit. 
aa43-obtain-period-and-cycle. 
 
*	(obtain period and cycle of clinic -- note constants master record 
*	 was obtained in routine 'aa42') 
 
    move iconst-clinic-cycle-nbr		to	batctrl-cycle-nbr. 
    move iconst-date-period-end			to	batctrl-date-period-end. 
 
 
aa43-99-exit. 
    exit. 
aa46-acpt-loc. 
 
    if     batctrl-adj-cd = "R" 
    then 
	   move "X999"				to	batctrl-loc 
	   display scr-batctrl-loc 
	   accept scr-batctrl-loc 
    else 
	if batctrl-adj-cd = "M" 
	then 
	    move "MISC"				to	batctrl-loc 
	    display scr-batctrl-loc 
*	    accept scr-batctrl-loc     - pdr 472 m.c. 91/01/14 
	else 
	    move spaces				to	batctrl-loc. 
*	endif 
*   endif 
 
    display scr-batctrl-loc. 
 
aa46-99-exit. 
    exit. 
aa47-acpt-agent-cd. 
 
    accept  scr-batctrl-agent-cd. 
 
aa47-99-exit. 
    exit. 
aa48-acpt-adj-cd. 
 
*	('A'JUSTMENT BATCHES ALLOW TRANSACTION CODES OF A,B,R -- 
*	 'P'AYMENT      "      "        "        "   "  C,M    ) 
 
    accept scr-batctrl-adj-cd. 
 
    if batctrl-batch-type = "A" 
    then 
	if batctrl-adj-cd =   "A" 
			   or "B" 
			   or "R" 
	then 
	    next sentence 
	else 
	    move 11				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to aa48-acpt-adj-cd 
*	endif 
    else 
*     batctrl-batch-type must = "P" 
	if batctrl-adj-cd =   "C" 
			   or "M" 
	then 
	    next sentence 
	else 
	    move 12				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to aa48-acpt-adj-cd. 
*	endif 
*   endif 
 
    if   batctrl-adj-cd =   "A" 
			 or "B" 
			 or "C" 
			 or "M" 
			 or "R" 
    then 
	next sentence 
    else 
	move 6					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	go to aa48-acpt-adj-cd. 
*   endif 
 
** the following if condition is added on 87/09/23 by m.s. for sms 97. 
 
    if batctrl-batch-type = "A" and batctrl-adj-cd = "B" 
    then 
	move "M"			to batctrl-adj-cd-sub-type. 
*   endif 
 
aa48-99-exit. 
    exit. 
aa5-verify-batch-status. 
 
*	(unless operator supplies special password don't allow access 
*	 to any batch with status 'sent to ohip' or greater)  
 
 
    if batctrl-batch-status > "1" 
    then 
	move 41					to	err-ind 
	perform za0-common-error		thru	za0-99-exit 
	display scr-acpt-change-password 
	accept  scr-acpt-change-password 
	if password-input = password-special-privledges 
	then 
	    move "Y"				to	flag 
	else 
	    move "N"				to	flag 
*	endif 
    else 
	next sentence. 
*   endif 
 
aa5-99-exit. 
    exit. 


aa9-write-batctrl-file. 
 
    move batctrl-batch-nbr			to	key-batctrl-file. 
 
    write  batctrl-rec   
*mf			key is  key-batctrl-file 
	invalid key 
	    move "N"				to	flag 
	    go to aa9-99-exit. 
 
    move "Y"					to	flag. 
    add  1					to	ctr-writ-batctrl-file. 
 
aa9-99-exit. 
    exit. 
ab0-processing. 
 
*	(preset data common between batctrl and clmhdr recs) 
    perform ba0-preset-hdr-data-from-ctrl	thru	ba0-99-exit. 
 
*	(maximum number of entries allowed in any batch is 99) 
 
    move 0 to ws-posted-ohip 
              ws-posted-oma 
              ws-amt-tech 
              ws-prof-ohip 
              ws-prof-oma. 
 
    if batctrl-adj-cd = 'M' 
    then 
	move 0				to clmhdr-adj-cd-sub-type. 
*   endif 
 
 
    if batctrl-last-claim-nbr > 98 
    then 
	display scr-acpt-clmhdr 
	move 38				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	move "E"			to	flag-eoj 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
    add  1 
	 batctrl-last-claim-nbr		giving	batctrl-last-claim-nbr 
						clmhdr-orig-claim-nbr. 
 
*	(read claims master for claim-nbr about to be created -- 
*	 if claim already exists then print error and shut down batch) 
 
    move batctrl-batch-nbr		to	clmhdr-batch-nbr. 
    move batctrl-last-claim-nbr		to	clmhdr-claim-nbr. 
    move zeros				to	clmhdr-zeroed-oma-suff-adj. 
*mf move clmhdr-claim-id		to	key-clm-data. 
*mf move "B"				to	key-clm-key-type. 
    move clmhdr-claim-id                to	clmdtl-b-data.
    move "B"                            to	clmdtl-b-key-type.
 
    perform xe0-read-claims-mstr	thru	xe0-99-exit. 
    if  ok 
    then 
*	(claim # already exists -- shut down batch with message to re-number remaining claims) 
	perform ab4-subtract-1-from-claim-nbr	thru ab4-99-exit 
	perform ab5-ring-bell		thru	ab5-99-exit   5 times 
	move 39				to	err-ind      
	perform za0-common-error	thru	za0-99-exit 
	move "E"			to	flag-eoj 
	go to ab0-99-exit 
    else 
	display scr-title-claim-rec-data 
	display scr-acpt-clmhdr 
	display scr-acpt-clmhdr-tit-1. 
*   endif 
 
ab0-10-input-claim. 
*	(input claim header information) 
 
    perform ab1-acpt-claim-id			thru ab1-99-exit.  
 
*   (check for end of job indicator) 
    if eoj 
    then 
	perform ab4-subtract-1-from-claim-nbr	thru ab4-99-exit 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
*	(if claim id entered find either hdr or dtl rec in claims mstr -- 
*	     -- non-zero doc # indicates that misc 'M' or 'R' adjustment entered --                
*		flag set to force program to create dummy claim # automatically) 
    if clmhdr-doc-nbr not = zero 
    then 
*mf	move "B"				to	key-clm-key-type    
*mf	move clmhdr-claim-id			to	key-clm-data 
	move "B"                            	to      clmdtl-b-key-type
	move clmhdr-claim-id                	to      clmdtl-b-data
	perform xe0-read-claims-mstr		thru	xe0-99-exit 
*	(no such claim found) 
	if not-ok 
	then 
	    move 10				to	err-ind 
	    perform za0-common-error		thru	za0-99-exit 
	    go to ab0-10-input-claim 
 	else 
*	    (if adjust cd = "C" then 'claims-mstr-rec' contains hdr rec - otherwise a dtl rec)                                      
*	    (claim being adjusted must have the same agent as batch being entered) 
	    if   (     batctrl-adj-cd          = "C" 
	           and clmrec-hdr-agent-cd not = batctrl-agent-cd )  
	       or (    batctrl-adj-cd      not = "C" 
	           and clmrec-dtl-agent-cd not = batctrl-agent-cd ) 
	    then 
		move 33				to	err-ind 
		perform za0-common-error	thru	za0-99-exit 
		go to ab0-10-input-claim 
	    else 
* 
*		   -- print "AMOUNT" of old claim) 
		if batctrl-adj-cd = "C" 
		then 
		    move clmrec-hdr-tot-claim-ar-ohip	to	ws-orig-ohip 
		    move clmrec-hdr-tot-claim-ar-oma	to	ws-orig-oma 
* 
*		    (save the adjustments claim header rec for future updating in 'pa0') 
* 
		    move claims-mstr-hdr-rec		to	ws-save-claims-header 
		    move feedback-claims-mstr		to	ws-save-claims-feedback 
		    move key-batctrl-file		to	ws-save-batctrl-key 
		    display scr-orig-ohip scr-orig-oma 
		else 
*		    ( display adjusted claims detail rec ) 
		    move clmrec-dtl-sv-date		to	hold-adjusted-clms-sv-date 
		    move clmrec-dtl-fee-ohip		to	ws-orig-ohip 
		    move clmrec-dtl-fee-oma		to	ws-orig-oma 
		    display scr-orig-ohip scr-orig-oma 
*		endif 
*	    endif 
*	endif 
    else 
	next sentence. 
*   endif 
 
 
*	(if adjustment type not = 'R' or 'M', then determine if operator 
*	 is trying to adjust claim for which a batch control record still exists 
*	 on the batch control file. if such a record is found, then  
*	 disallow any adjustment to claim.) 
 
    if batctrl-adj-cd =   "M" 
		       or "R" 
    then 
	next sentence 
    else 
	perform da0-verify-ok-to-modify-claim 	thru	da0-99-exit 
	if ws-flag-ok-to-adjust = "N" 
	then 
	    go to ab0-10-input-claim 
	else 
*	    (access claim being adjusted's hdr rec to obtain data on doctor's dept nbr 
*	     claim's ohip status, location, patient, service date etc -- ) 
*	     -- if adj = 'C' then claim's hdr rec already in 'claims-mstr-rec' -- 
*	     otherwise the claim's dtl record was read and hdr rec must be read -- 
*	      -- note:  key for detail rec already in key area) 
 
	    perform fa0-obtain-clmhdr-data		thru	fa0-99-exit. 
*	endif 
*   endif 
 
 
*   move zero				to ws-amt-tech 
*					   ws-prof-ohip 
*					   ws-prof-oma. 
 
*	(accept details into claim hdr and dtl recs) 
ab0-50-acpt-details. 
 
    perform ja0-acpt-clmhdr-detail			thru	ja0-99-exit. 
    if err-data 
    then 
	go to ab0-10-input-claim. 
*   (else) 
*   endif 
 
ab0-60-acpt-verification. 
 
    perform la0-acpt-verification		thru	la0-99-exit. 
 
* sms 105 allow update of location on detail screen for "R" adj   s.f. 
 
   if flag = "L" and batctrl-adj-cd = "R" 
    then 
         accept scr-clmhdr-loc 
         go to ab0-60-acpt-verification 
    else 
	if flag = "L" 
	then 
	    accept scr-reference 
	    go to ab0-60-acpt-verification 
	else 
 
 
        if flag = "M" 
        then 
	    go to ab0-10-input-claim 
        else 
	    if flag = "N" 
	    then 
	        display scr-reject-entry 
	        display confirm 
	        stop " " 
	        display blank-line-24 
	        subtract 1				from	batctrl-last-claim-nbr 
						        giving	batctrl-last-claim-nbr 
							clmhdr-orig-claim-nbr. 
    if flag = "Y" 
    then 
**   the following 'add' and 'if-condition' are added by m.s. - sms 99 
  	add ws-posted-ohip 			to ws-batctrl-amt-act 
    	if  ws-batctrl-amt-act > 99999.99 
    	then 
*	(batctrl amt > 99999.99 -- shut down batch with message to 
*	 re-number remaining claims) 
	    perform ab4-subtract-1-from-claim-nbr thru ab4-99-exit 
	    perform ab5-ring-bell	thru	ab5-99-exit   5 times 
	    move 48			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    move "E"			to	flag-eoj 
	    go to ab0-99-exit 
 	else 
*	    (entry accepted -- ) 
	    perform ab3-create-claim-id		thru	ab3-99-exit 
*	    (write out claim -- head rec followed by detail recs) 
	    perform ma0-write-clmhdr		thru	ma0-99-exit 
 
*	    (preset clmdtl rec data which is common to clmhdr rec data) 
	    perform ab2-preset-clmdtl-data	thru	ab2-99-exit 
 
	    perform na0-write-clmdtl		thru	na0-99-exit 
 
*	    (if trans not = 'M' or 'R' then update claim hdr or dtl that is being adjusted) 
	    perform pa0-update-adjusted-claim	thru	pa0-99-exit. 
*	endif 
*   endif 
 
 
ab0-99-exit. 
    exit. 


ab1-acpt-claim-id. 
 
    move "N"					to flag-dummy-claim-id. 
 
    move zeros					to clmhdr-week 
						   clmhdr-day 
						   clmhdr-claim-nbr. 
 
    display scr-acpt-clmhdr-dtl-1. 
 
    accept scr-hdr-doc-nbr. 
 
*	(allow operator to signal end of input) 
    if ws-doc-nbr-alpha = "***" 
    then 
	move "E"				to flag-eoj 
	go to ab1-99-exit 
    else 
	next sentence. 
*   endif 

*!  (alpha doctor number now allowed)
*!*	(op allowed to enter "***" to stop data entry - otherwise entry must be numeric) 
*!    if ws-doc-nbr-alpha  not numeric 
*!    then 
*!	move 1					to err-ind 
*!	perform za0-common-error		thru za0-99-exit 
*!	go to ab1-acpt-claim-id. 
 
    move ws-doc-nbr-alpha			to clmhdr-doc-nbr. 
 
    if clmhdr-doc-nbr not = zero 
    then 
	accept scr-hdr-week 
	accept scr-hdr-day 
	accept scr-hdr-claim-nbr 
*	(payments adjust claim header only - don't need oma cd and suff) 
 
	if batctrl-adj-cd = "C" 
	then 
	    go to ab1-99-exit 
	else 
	    move "XXXX"				to clmhdr-adj-oma-cd 
	    move "A"				to clmhdr-adj-oma-suff 
	    display scr-hdr-oma-cd 
	    display scr-hdr-oma-suff 
	    accept scr-hdr-oma-cd 
	    accept scr-hdr-oma-suff 
	    go to ab1-99-exit 
*	endif 
    else 
	next sentence. 
*   endif 
 
*	(allow zero batch-id only if transaction code is 'M' or 'R'-- 
*		 - if 'M' or 'R' then set oma code = "MISC" 
*		       -- but allow operator to over ride this value)                     
ab1-50. 
    if     clmhdr-doc-nbr = zero 
      and (batctrl-adj-cd = "M" or "R") 
    then 
	move "Y"				to flag-dummy-claim-id 
 
	move "MISC"				to clmhdr-adj-oma-cd 
	move space				to clmhdr-adj-oma-suff 
	display scr-hdr-oma-cd 
	display scr-hdr-oma-suff 
	if batctrl-adj-cd = "M" or "R" 
	then 
	    accept scr-hdr-oma-cd 
*	    (if 'MISC' oma code is over written then verify oma code)  
	    if clmhdr-adj-oma-cd not = "MISC" 
	    then 
		move clmhdr-adj-oma-cd		to fee-oma-cd  
		perform xh0-read-oma-fee-mstr	thru xh0-99-exit 
		if not-ok 
		then 
		    move 28			to err-ind 
		    perform za0-common-error	thru za0-99-exit 
		    move spaces			to clmhdr-adj-oma-cd 
		    go to ab1-50 
		else 
		    next sentence 
*		endif 
	    else 
		next sentence 
*	    endif 
	else 
	    next sentence 
*	endif 
    else 
	move 8					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	go to ab1-acpt-claim-id. 
*   endif 

* MC5
    if batctrl-adj-cd = 'M' 
    then 
	move clmhdr-adj-oma-cd		to fee-oma-cd  
		perform xh0-read-oma-fee-mstr	thru xh0-99-exit 
		if not-ok 
		then 
		    move 28			to err-ind 
		    perform za0-common-error	thru za0-99-exit 
		    move spaces			to clmhdr-adj-oma-cd 
		    go to ab1-50 
		else 
		    next sentence 
    display scr-clear-misc-pay-code. 
 
    if batctrl-adj-cd = "M" 
    then 
	perform ab6-acpt-misc-pay-code		thru ab6-99-exit. 
*   (else) 
*   endif 
 
ab1-99-exit. 
    exit. 
ab2-preset-clmdtl-data. 
 
*	(preset clmdtl rec data which is common to clmhdr rec data) 
 
    move clmhdr-batch-nbr		to	clmdtl-batch-nbr. 
    move clmhdr-claim-nbr		to	clmdtl-claim-nbr. 
    move clmhdr-agent-cd		to	clmdtl-agent-cd. 
    move clmhdr-adj-cd			to	clmdtl-adj-cd. 
 
    move ws-svc-posted			to	clmdtl-nbr-serv. 
 
    if clmhdr-adj-cd =   "A" 
		      or "B" 
    then 
	move hold-adjusted-clms-sv-date	to	clmdtl-sv-date 
    else 
	if clmhdr-adj-cd = "C" 
	then 
	    move hold-adjusted-clms-de-date 
					to	clmdtl-sv-date 
	else 
*	    ( must be "R" or "M" ) 
	    move sys-yy         	to	clmdtl-sv-yy 
	    move sys-mm        		to	clmdtl-sv-mm 
	    move sys-dd			to	clmdtl-sv-dd. 
*	endif 
*   endif 
 
    move zeroes				to	clmdtl-consecutive-dates (1) 
						clmdtl-consecutive-dates (2) 
						clmdtl-consecutive-dates (3). 
 
    move ws-posted-oma			to	clmdtl-fee-oma. 
*   move ws-posted-ohip			to	clmdtl-fee-ohip. 
    move clmhdr-date-period-end		to	clmdtl-date-period-end. 
    move clmhdr-cycle-nbr		to	clmdtl-cycle-nbr. 
    move clmhdr-orig-batch-id		to	clmdtl-orig-batch-id. 
 
ab2-99-exit. 
    exit. 
ab3-create-claim-id. 
 
*	(test if a dummy claim id has to be built and build if necessary 
*	    according to transaction type (adj-cd) ) 
    if dummy-claim-id-required 
    then 
	next sentence 
    else 
	go to ab3-99-exit. 
*   endif 

    move ws-doc-nbr			to	clmhdr-batch-nbr-3-6. 
    move batctrl-bat-doc-nbr		to	clmhdr-batch-nbr-7-9. 
    move 01				to	clmhdr-claim-nbr. 
    go to ab3-99-exit. 
 
*--------------------  code no longer used  ---------------- 
*   (build dummy claim id that will not duplicate existing key) 
    move ws-doc-nbr			to clmhdr-batch-nbr-3-6. 
    if batctrl-adj-cd = "M" 
    then 
	move "156"			to clmhdr-batch-nbr-7-9 
    else 
	move "999"			to clmhdr-batch-nbr-7-9. 
 
*	(find a claim # within batch not already used) 
    move 1				to clmhdr-claim-nbr. 
*mf move "B"				to key-clm-key-type. 
*mf move clmhdr-claim-id		to key-clm-data. 
    move "B"                            to clmdtl-b-key-type.
    move clmhdr-claim-id                to clmdtl-b-data.
 
ab3-10-claim-nbr-loop. 
 
    read    claims-mstr   
*mf			 retain position suppress data record 
	key is  key-claims-mstr 
	invalid key 
*	    (available claim id found -- display it on screen) 
*mf	    move key-clm-claim-nbr	to clmhdr-claim-nbr 
	    move clmdtl-b-data		to clmhdr-claim-nbr 
	    display scr-acpt-clmhdr-dtl-1 
	    display confirm 
	    stop " " 
	    go to ab3-99-exit. 
 
ab3-20-try-again. 
*   (err - this claim # already used) 
*mf if key-clm-claim-nbr  = 99 
    if clmdtl-b-claim-nbr = 99 
    then 
*	(fatal err - more than 99 claims within this batch nbr not allowed) 
	move 18			to err-ind 
	perform za0-common-error thru za0-99-exit 
	go to az0-end-of-job 
    else 
*	(loop to try next possible claim nbr) 
*mf	add  1			to key-clm-claim-nbr 
	add  1			to clmdtl-b-claim-nbr
	go to ab3-10-claim-nbr-loop. 
*   endif 
*--------------------  code no longer used  ---------------- 
 
ab3-99-exit. 
    exit. 
ab4-subtract-1-from-claim-nbr. 
 
    subtract 1				from	batctrl-last-claim-nbr 
					giving	batctrl-last-claim-nbr 
						clmhdr-orig-claim-nbr. 
ab4-99-exit. 
    exit. 
 
 
 
 
 
ab5-ring-bell. 
 
    display ring-bell. 
 
ab5-99-exit. 
    exit. 
ab6-acpt-misc-pay-code. 
 
*  pdr 471 - the following accept on doc nbr is only applied to 'M'isc 
*	     payment, so in case pay code 0 is entered, the percentage 
*	     from doctor master will be displayed on the screen. 
 
    accept scr-ws-doc-nbr. 
 
    if ws-doc-nbr not = zero 
    then 
*	(doc # must exist on doc mstr) 
	move ws-doc-nbr			to doc-nbr 
	perform xf0-read-doc-mstr	thru xf0-99-exit. 

* 2013/11/06 - MC4
    display scr-doc-name.
* 2013/11/06 - end

* 2013/08/27 - MC3 -  Provide error if entered doctor nbr has not assigned the selected clinic nbr
     If       ok
          and (     batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr	
               and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-2
               and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-3
               and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-4
               and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-5
               and  batctrl-bat-clinic-nbr-1-2 not = doc-clinic-nbr-6
	      )
     then
    	move "N"			to flag-err-data 
    	move 51 			to err-ind
       	perform za0-common-error	thru za0-99-exit 
    	go to ab6-acpt-misc-pay-code. 
*   endif
* 2013/08/27 - end


* 2011/11/16 - MC1 -  Provide warning if doctor is terminated for Miscellaneous payment.
     If       ok 
          and doc-date-fac-term not = zeroes 
          and doc-date-fac-term not = spaces
          and doc-date-fac-term < sys-date
     then
    	  move "N"			to flag-err-data 
* MC6  
  	  move doc-date-fac-term 		to ws-date

*         (warning if doctor termination date is 
*          within 6 months of current system date; 
*	   otherwise, it is error)
         if   (   (ws-yy  * 365) + (ws-mm  * 30) + ws-dd )
                > (sys-yy * 365) + (sys-mm * 30) + sys-dd - 180
	 then
* MC6 - end
    	     move 49 			to err-ind
    	     perform za1-common-warning thru za1-99-exit
             if confirm-space = '!'
             then
    	         go to ab6-acpt-misc-pay-code 
* MC6
	     else
		 next sentence
*	     endif
	 else
    	     move 53 			to err-ind
    	     perform za0-common-error   thru za0-99-exit
             if confirm-space = '*'
             then
	     	display scr-acpt-change-password 
	     	accept  scr-acpt-change-password 
	     	if password-input  =  password  or  password-special-privledges 
	     	then 
		    go to ab6-99-exit
	     	else
    	            go to ab6-acpt-misc-pay-code
*		endif
	     else
    	            go to ab6-acpt-misc-pay-code. 
*	     endif
*       endif
* MC6 - end	    
*   endif
* 2011/11/16 - end
 
*    (error -- doc # = 0 or not found on doc mstr) 
    if ws-doc-nbr = zero or not-ok 
    then 
    	move "N"			to flag-err-data 
    	move 7				to err-ind 
       	perform za0-common-error	thru za0-99-exit 
    	go to ab6-acpt-misc-pay-code. 
*   endif 

* MC5 - check against f040-dtl for Miscellaneous payment  only  
    move clmhdr-adj-oma-cd 		to oma-cd. 
    move doc-dept			to dept-no. 
* MC7
    move ws-doc-nbr			to oma-doc-nbr.
* MC7 - end
    perform xi0-read-oma-dtl		thru xi0-99-exit.
    if ok and data-entry-flag not = 'V'
    then	
    	move "N"			to flag-err-data 
    	move 52				to err-ind 
       	perform za0-common-error	thru za0-99-exit 
    	go to ab6-acpt-misc-pay-code. 
*   endif 

* MC5 - end 


*   move zero				to clmhdr-adj-cd-sub-type. 
    display scr-misc-pay-code-lit. 
    display scr-misc-pay-code. 
 
* 2005/03/01 - MC - do not allow user to enter pay code
*    accept scr-misc-pay-code. 
* 2005/03/01 - -end
 
    if clmhdr-adj-cd-sub-type not = zero 
    then 
	perform ab61-access-const-mstr-rec-3 
					thru ab61-99-exit 
	if const-misc-curr(clmhdr-adj-cd-sub-type-ss) = zero 
	then 
	    move 26			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to ab6-acpt-misc-pay-code 
	else 
	    multiply const-misc-curr(clmhdr-adj-cd-sub-type-ss) 
					by 100 
					giving ws-misc-code-perc 
	    display scr-misc-pay-code-perc 
	    move clmhdr-adj-cd-sub-type	to batctrl-adj-cd-sub-type 
*	endif 
    else 
*	next sentence. 
*   pdr 471 - display misc tax from doctor master for pay code 0 
*	multiply doc-misc-percent by 100 giving ws-misc-code-perc 
        move 0 to ws-misc-code-perc 
	display scr-misc-pay-code-perc. 
*   endif 
 
ab6-99-exit. 
    exit. 
 
 
 
ab61-access-const-mstr-rec-3. 
 
    move 3				to const-rec-3-rec-nbr. 
 
    read iconst-mstr 
	invalid key 
	    move 42			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
ab61-99-exit. 
    exit. 
ac0-totals. 
 
*	(if no claims were input then delete batctrl rec -- 
*		-- otherwise allow update of 'HASH' totals and re-write updated batctrl rec) 
    if batctrl-last-claim-nbr < 1 
    then 
	move ws-save-batctrl-key	to key-batctrl-file 
	perform az1-delete-batctrl-rec	thru az1-99-exit 
	if  ok 
	then 
	    go to ac0-99-exit 
        else 
	    move 37			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to ac0-99-exit 
*	endif 
    else 
*	(update 'total nbr of claims in the batch' using nbr of 'last claim in batch' 
	move batctrl-last-claim-nbr 	to batctrl-nbr-claims-in-batch. 
*   endif 
 
 
ac0-50.
 
    perform xa0-disp-batctrl-data	  thru xa0-99-exit 

* 2012/11/14 - MC2 - check amount est & act
    if batctrl-amt-est not = batctrl-amt-act
    then
        move 50				to err-ind 
        perform za1-common-warning	thru za1-99-exit.
*	go to ac0-50.                               
*   endif
* 2012/11/14 -end

    move "Y"				  to change-reply. 

    perform xb0-allow-change-of-estimates thru xb0-99-exit 
			until    change-reply = "N". 

*	(set batch status according to 'estimate' vs 'actual' hash totals) 
    if batctrl-amt-est = batctrl-amt-act 
    then 
*	(balanced) 
	move '1'			to batctrl-batch-status 
    else 
*	(unbalanced) 
	move '0'			to batctrl-batch-status. 
*   endif 
 
    move batctrl-batch-nbr		to key-batctrl-file. 
    perform az2-rewrite-batctrl-rec	thru az2-99-exit. 
    if not-ok 
    then 
	move 35				to err-ind 
	perform za0-common-error	thru za0-99-exit 
    else 
	next sentence. 
*   endif 
 
    accept  sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
 
ac0-99-exit. 
   exit. 
 
az0-end-of-job. 
 
az0-10. 
    display blank-screen. 
 
    close	batch-ctrl-file 
		claims-mstr 
		iconst-mstr 
		doc-mstr 
		loc-mstr 
* MC5
		f040-dtl
* MC5 - end
		oma-fee-mstr. 
 
    call program "$obj/menu". 
    stop run. 
 
az0-99-exit. 
    exit. 
 
az1-delete-batctrl-rec. 
 
    move "Y"				to flag. 
 
*mf delete    batch-ctrl-file  record physical	key is key-batctrl-file 
    delete    batch-ctrl-file
	invalid key 
	    move "N"			to flag. 
 
    add 1				to ctr-del-batctrl-file. 
 
az1-99-exit. 
    exit. 
 
 
 
az2-rewrite-batctrl-rec. 
 
    rewrite    batctrl-rec	
*mf		key is key-batctrl-file 
	invalid key 
	    move "N"			to flag      
	    go to az2-99-exit. 
 
    move "Y"				to flag. 
    add  1				to ctr-rewrit-batctrl-file. 
 
az2-99-exit. 
    exit. 
ba0-preset-hdr-data-from-ctrl. 
 
    move spaces				to claim-detail-rec. 
    move zeros				to clmdtl-id
					   clmdtl-agent-cd
					   clmdtl-nbr-serv
					   clmdtl-sv-date
					   clmdtl-consecutive-sv-date(1)
					   clmdtl-consecutive-sv-date(2)
					   clmdtl-consecutive-sv-date(3)
					   clmdtl-amt-tech-billed
					   clmdtl-fee-oma
					   clmdtl-fee-ohip
					   clmdtl-cycle-nbr
					   clmdtl-diag-cd
					   clmdtl-line-no
					   clmdtl-orig-batch-id.
    move clmhdr-week			to hold-week. 
    move clmhdr-day			to hold-day. 
    move zeros				to claim-header-rec 
					   ws-svc-posted 
					   ws-posted-oma 
					   ws-posted-ohip 
					   ws-orig-total-svc 
					   ws-orig-oma 
					   ws-orig-ohip. 
 
    move spaces				to clmhdr-reference. 
    move hold-week			to clmhdr-week. 
    move hold-day			to clmhdr-day. 
    move batctrl-batch-nbr		to clmhdr-orig-batch-nbr. 
    move zero				to clmhdr-zeroed-oma-suff-adj. 
    move batctrl-batch-type		to clmhdr-batch-type. 
    move batctrl-bat-clinic-nbr-1-2	to clmhdr-clinic-nbr-1-2. 
    move batctrl-loc			to clmhdr-loc. 
    move batctrl-agent-cd		to clmhdr-agent-cd. 
    move batctrl-adj-cd			to clmhdr-adj-cd. 
    move batctrl-date-period-end	to clmhdr-date-period-end. 
    move batctrl-cycle-nbr		to clmhdr-cycle-nbr. 
 
*   the following move statement is added on 87/09/23 by m.s for sms 97. 
 
    move batctrl-adj-cd-sub-type	to clmhdr-adj-cd-sub-type. 
 
 
ba0-99-exit. 
    exit. 


da0-verify-ok-to-modify-claim. 
 
*	(can't adjust if batch's status indicates it hasn't been 'sent to ohip' yet) 
 
*	(place present batch's 'batctrl rec', 'feedback', and 'key' in save area) 
    move batctrl-rec				to ws-save-batctrl-rec. 
    move feedback-batctrl-file			to ws-save-batctrl-feedback. 
    move key-batctrl-file			to ws-save-batctrl-key. 
 
*	(attempt read of batctrl rec of claim being adjusted) 
    move clmhdr-batch-nbr			to key-batctrl-file. 
 
    read  batch-ctrl-file	key is key-batctrl-file 
	invalid key 
*	    (batctl rec not found - ok to adjust claim) 
	    move "Y"					to ws-flag-ok-to-adjust 
	    go to da0-90-reset-batctrl.  
 
*	(batctrl rec found but if status indicates the batch has been processed 
*	 to the 'sent to ohip' stage or further then claim can be adjusted) 
* 2002/09/26 - MC
*    if batctrl-batch-status < 2 
    if batctrl-batch-status < 3
* 2002/09/26 - end
    then 
*	(error -- can't adjust claim) 
	move 13				to err-ind      
	perform za0-common-error	thru za0-99-exit 
	move "N"			to ws-flag-ok-to-adjust 
     else 
	move "Y"			to ws-flag-ok-to-adjust. 
*   endif 
 
da0-90-reset-batctrl. 
*	(restore present batch's 'batctrl rec' and 'feedback' from save area) 
    move ws-save-batctrl-rec			to batctrl-rec. 
    move ws-save-batctrl-feedback		to feedback-batctrl-file. 
    move ws-save-batctrl-key			to key-batctrl-file. 
 
 
da0-99-exit. 
    exit. 


fa0-obtain-clmhdr-data. 
 
*mf move zeroes				to key-clm-oma-cd 
*mf					   key-clm-oma-suff 
*mf                                        key-clm-adj-nbr. 
    move zeroes				to clmdtl-b-oma-cd 
					   clmdtl-b-oma-suff 
                                           clmdtl-b-adj-nbr. 
    if batctrl-adj-cd not = "C" 
    then 
	perform xe0-read-claims-mstr	thru xe0-99-exit 
	if not-ok 
	then 
	    move 6			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job 
	else 
* 
*	    save claim header and feedback for future updating 
*	    of the original header in 'pa0' 
* 
	    move feedback-claims-mstr	to ws-save-claims-feedback 
	    move claims-mstr-hdr-rec	to ws-save-claims-header 
*	endif 
    else 
	move clmrec-hdr-date-claim	to hold-adjusted-clms-de-date. 
*   endif 
 
 
*	(preset claim hdr with values from claim being paid/adjusted) 
    if clmhdr-loc =    zeros 
                    or spaces 
    then 
	move clmrec-hdr-loc		to	clmhdr-loc. 
*   (else) 
*   endif 
 
    move clmrec-hdr-diag-cd		to	clmhdr-diag-cd. 
    move clmrec-hdr-hosp		to	clmhdr-hosp. 
    move clmrec-hdr-i-o-pat-ind		to	clmhdr-i-o-pat-ind. 
*mf move clmrec-hdr-pat-ohip-id-or-chart to	clmhdr-pat-ohip-id-or-chart. 
*mf (bug - commented line contained 'b' key - not 'p' key data. 
*          added next 2 lines to fix problem.)
*   move clmrec-hdr-b-pat-id	 	to	clmhdr-pat-ohip-id-or-chart. 
    move clmdtl-p-claims-mstr	 	to	clmhdr-pat-ohip-id-or-chart. 
    move "I"				to	clmhdr-pat-key-type.

    move clmrec-hdr-pat-acronym		to	clmhdr-pat-acronym. 
*   move clmrec-doc-dept-nbr		to	clmhdr-doc-dept. 
 
*   access to doc-mstr, use the doc-dept instead of clmhdr-doc-dept 
*   of the original claim header record. 93/02/25 by m.c. 
 
    move clmhdr-doc-nbr 		to doc-nbr. 
    perform xf0-read-doc-mstr thru xf0-99-exit. 
    if not-ok 
    then 
	move "N"			to flag-err-data 
	move 7				to err-ind 
	perform za0-common-error thru za0-99-exit 
	move clmrec-doc-dept-nbr	to clmhdr-doc-dept 
    else 
* 2013/11/06 - MC4
	display scr-doc-name
* 2013/11/06 - end
	move doc-dept			to clmhdr-doc-dept. 
*   endif 
 
 
 
    if clmrec-hdr-status-ohip = '00' 
    then 
	move spaces			to	clmhdr-reference 
    else 
	move clmrec-hdr-status-ohip	to	clmhdr-reference. 
*   endif 
 
    display scr-reference. 
 
fa0-99-exit. 
    exit. 
ja0-acpt-clmhdr-detail. 
 
*	(accept details into clm hdr and dtl recs) 
 
    move "Y"				to flag-err-data. 
 
    display scr-clmhdr-loc. 
 
*	(if claim # entered = 0 ,ie. claim id doc # = 0, then doc # required input 
*	   -- else preset using claim id's doc #) 
    if clmhdr-doc-nbr not = zero 
    then 
	move clmhdr-doc-nbr		to ws-doc-nbr 
	display scr-ws-doc-nbr 
	go to ja0-20-input-amt. 
*   (else) 
*   endif 
 
*	(transactions 'M' and 'R' allow blank claim id's -- a dummy claim id must be created --                
*	    using doc #) 
* 
*  pdr 471 - the following accept on doc nbr is only applied to 'R' 
*	     adjustment because 'M' payment is prompted in ab6 subroutine. 
* 
 
    if batctrl-adj-cd = 'M' 
    then 
  	go to ja0-20-input-amt. 
*   endif 
 
    accept scr-ws-doc-nbr. 
    if ws-doc-nbr not = zero 
    then 
*	(doc # must exist on doc mstr) 
	move ws-doc-nbr			to doc-nbr 
	perform xf0-read-doc-mstr	thru xf0-99-exit 
	if ok 
	then 
* 2013/11/06 - MC4
	    display scr-doc-name
* 2013/11/06 - end
	    go to ja0-20-input-amt. 
*	(else) 
*	endif 
*   (else) 
*   endif 
 
*    (error -- doc # = 0 or not found on doc mstr) 
    move "N"				to flag-err-data. 
    move 7				to err-ind. 
    perform za0-common-error		thru za0-99-exit. 
    go to ja0-99-exit. 
 
 
 
ja0-20-input-amt. 
 
    display scr-ohip-posted. 
    accept  scr-ohip-posted. 
  
    if ws-posted-ohip = zero 
    then 
	move 17				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ja0-20-input-amt. 
*   (else) 
*   endif 
 
*	(default 'C' type 'P'ayment is positive data entry but value is to be 
*	 negative on file so sign is reversed) 
    if    batctrl-batch-type = "P" 
      and batctrl-adj-cd     = "C" 
    then 
	subtract ws-posted-ohip		from	zero 
					giving	ws-posted-ohip 
	display scr-ohip-posted. 
*   (else) 
*   endif 
 
*	(update clmdtl fields according to transaction type and agent code) 
    move ws-posted-ohip			to clmdtl-fee-ohip. 
 
*	(if agent is not 'ohip' then oma-amt = ohip-amt  -- otherwise 
*	 -- use a straight 70% unless adjust code = 'B' in which case 
*	    use the % that the ohip-amt is of the oma-amt on the claim being adjusted) 
 
*  if the adjust code = 'R', 'M', 'C', or 'A', set the oma fee to be 
*  the same as ohip fee - sms 111 by m.s. 
 
    if 	    batctrl-agent-cd  not = 0 
        or (batctrl-adj-cd = 'R' or 'M' or 'C' or 'A') 
    then 
	move ws-posted-ohip		to ws-posted-oma 
*					   clmdtl-fee-oma   
    else 
	if batctrl-adj-cd = "B" 
	then 
	    perform ja1-calc-fee-oma-for-adj-b 
					thru ja1-99-exit 
	else 
*	    (use a straight 70%) 
	    multiply ws-posted-ohip	by 100	giving ws-posted-oma 
	    divide ws-posted-oma	by  70	giving ws-posted-oma 
						       clmdtl-fee-oma. 
*	endif 
*   endif 
 
ja0-90-display-oma. 
 
    display scr-oma-posted. 
    move ws-posted-oma			to ws-hold-posted-oma. 
 
*  if the adjust code = 'R', 'M', 'C' or 'A', bypass the oma fee 
*  field - sms  111 by m.s. 
 
    if  batctrl-adj-cd = 'R' or 'M' or 'C' or 'A' 
    then 
	go to ja0-95-acpt-tech-portion. 
*   endif 
 
*	( operator allowed to correct calculated value to make up 
*	  for "SLIGHT" rounding errors.  note: the operator is not 
*	  allowed to change the value more than 50% and not = zero ) 
 
    accept scr-oma-posted. 
 
    if ws-posted-oma = zero 
    then 
	move 44				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move ws-hold-posted-oma		to ws-posted-oma 
	go to ja0-90-display-oma 
    else 
*	( if the original oma amount was zero then bypass the 50% check 
*	  as any change will be greater than 50%.  ths user must however 
*	  enter a valid amount as zero will not be allowed through. ) 
	if ws-hold-posted-oma = zero 
	then 
	    next sentence 
	else 
	    perform ja2-check-for-50-perc 
                                   	thru ja2-99-exit 
	    if ws-hold-50-perc < temp 
	    then 
		move 43			to err-ind 
		perform za0-common-error 
                           		thru za0-99-exit 
		move ws-hold-posted-oma	to ws-posted-oma 
		go to ja0-90-display-oma 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 
 
    move ws-posted-oma			to clmdtl-fee-oma. 
 
ja0-95-acpt-tech-portion. 
 
    display scr-amt-tech. 
    accept  scr-amt-tech. 
 
*	(default 'C' type 'P'ayment is positive data entry but value is to be 
*	 negative on file so sign is reversed) 
    if    batctrl-batch-type = "P" 
      and batctrl-adj-cd     = "C" 
    then 
	subtract ws-amt-tech   		from	zero 
					giving	ws-amt-tech 
	display scr-amt-tech. 
*   (else) 
*   endif 
 
    if   (    ws-posted-ohip > zero 
          and ws-amt-tech    < zero
	 ) 
      or (    ws-posted-ohip < zero 
	  and ws-amt-tech    > zero
	 ) 
    then 
        move 47					to err-ind 
        perform za0-common-error		thru za0-99-exit 
        go to ja0-95-acpt-tech-portion. 
*   endif
 
    move ws-posted-ohip 		to abs-posted-ohip 
    move ws-posted-oma			to abs-posted-oma 
    move ws-amt-tech			to abs-amt-tech. 
 
    if    abs-posted-ohip >= abs-posted-oma 
      and abs-amt-tech    >  abs-posted-ohip
    then 
	move 45				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ja0-95-acpt-tech-portion 
    else 
	if    abs-posted-ohip < abs-posted-oma
	  and abs-amt-tech    > abs-posted-oma
	then 
	    move 45 				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to ja0-95-acpt-tech-portion 
	else 
	    if   abs-amt-tech >   abs-posted-ohip 
	                       or abs-posted-oma 
	    then 
	       	move 46				to err-ind 
		perform za1-common-warning	thru za1-99-exit. 
*	    endif
*	endif
*   endif
 
    subtract ws-amt-tech from ws-posted-ohip giving ws-prof-ohip. 
    subtract ws-amt-tech from ws-posted-oma  giving ws-prof-oma. 

*   (display professional calculations based upon whether this claim
*    uses oma or ohip prices)
*      display scr-disp-clmhdr-dtl-3. 
    move batctrl-agent-cd			to def-agent-code.
    if def-agent-ohip
    then
	display scr-prof-ohip
    else
	display scr-prof-oma.
*   endif

    move ws-amt-tech 			to clmdtl-amt-tech-billed. 
*	(allow input of location if location is zero) 
    if clmhdr-loc = "0000" 
    then 
	accept scr-clmhdr-loc. 
*   (else) 
*   endif 
 
    accept scr-reference. 
 
ja0-99-exit. 
    exit. 
ja1-calc-fee-oma-for-adj-b. 
 
*	for transaction type 'b', calculate oma-fee from ohip-amt entered (ws-posted-ohip)                      
*	    by calculating the percent of ohip-fee vs oma-fee on the claim                                   
*	    that is being adjusted.  set oma-amt (ws-posted-oma) to be this percent of the ohip-fee (amt posted)               
 
    divide ws-orig-oma			by ws-orig-ohip 
					giving clmdtl-fee-oma. 
 
    multiply clmdtl-fee-oma		by     ws-posted-ohip  
					giving clmdtl-fee-oma 
					       ws-posted-oma. 
 
ja1-99-exit. 
    exit. 
ja2-check-for-50-perc. 
 
    subtract ws-posted-oma		from ws-hold-posted-oma 
					giving	temp. 
 
    if temp < zero 
    then 
	multiply temp 			by -1 
					giving temp. 
*   (else) 
*   endif 
 
    divide 2				into ws-hold-posted-oma 
					giving ws-hold-50-perc. 
 
    if ws-hold-50-perc < zero 
    then 
	multiply ws-hold-50-perc	by -1 
					giving ws-hold-50-perc. 
*   (else) 
*   endif 
 
ja2-99-exit. 
    exit. 
la0-acpt-verification. 
 
    display verification-screen. 
    accept  verification-screen. 
 
    if flag =   "Y" 
	     or "N" 
	     or "M" 
	     or "L" 
* sms 105 allow location code to be updated for "R" adjustments  s.f. 
    then 
	next sentence 
    else 
	move 1				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to la0-acpt-verification. 
 
la0-99-exit. 
    exit. 


ma0-write-clmhdr. 
 
*	(move oma cd, suff, and adj nbr from hdr rec to dtl) 
    move clmhdr-adj-oma-cd		to clmdtl-oma-cd. 
    move clmhdr-adj-oma-suff		to clmdtl-oma-suff. 
 
    move zeroes				to clmhdr-zeroed-oma-suff-adj. 
    move sys-date			to clmhdr-date-sys    
					   clmhdr-date-cash-tape-payment. 
*   (m and r transactions do not adjust existing claims - thus default indicator to 'o'ut -- 
*    - also since these adjustments don't adjust existing claims, use accessed 
*	doctor rec to obtain doctor dept nbr) 
 
    if batctrl-adj-cd =    "M" 
			or "R" 
    then 
	move "O"			to clmhdr-i-o-pat-ind 
*	(save adjusted doctor's dept nbr) 
	move doc-dept			to clmhdr-doc-dept. 
*   (else) 
*   endif 
 
*---  clmhdr-adj-cd-sub-type  -----
 
    move "N"				to clmhdr-tape-submit-ind. 
    move zeroes				to clmhdr-status-ohip. 
 
*	(since dummy claim prepared for 'M' and 'R' adjustments there is no patient data) 
    if     batctrl-adj-cd = "M" 
    then 
	move     spaces			to clmhdr-pat-ohip-id-or-chart 
					   clmhdr-pat-acronym 
    else 
	if batctrl-adj-cd = "R" 
	then 
	    move spaces			to clmhdr-pat-ohip-id-or-chart 
					   clmhdr-pat-acronym 
	else 
	    next sentence. 
*	endif 
*   endif 
 
    add ws-posted-ohip			to batctrl-amt-act. 
 
    if batctrl-adj-cd = "A" 
    then 
	add ws-posted-oma		to clmhdr-tot-claim-ar-oma 
	add ws-posted-ohip		to clmhdr-tot-claim-ar-ohip 
					   batctrl-calc-ar-due 
	add ws-amt-tech			to clmhdr-amt-tech-billed 
    else 
	if batctrl-adj-cd = "B" 
	then 
	    add ws-posted-ohip		to batctrl-calc-ar-due 
					   batctrl-calc-tot-rev 
					   clmhdr-tot-claim-ar-ohip 
	    add ws-posted-oma		to clmhdr-tot-claim-ar-oma 
	    add ws-amt-tech		to clmhdr-amt-tech-billed 
	else 
	    if batctrl-adj-cd = "C" 
	    then 
		add ws-posted-ohip	to clmhdr-manual-and-tape-paymnts    
					   batctrl-manual-pay-tot   
		add ws-amt-tech		 to clmhdr-amt-tech-paid 
	    else 
		if batctrl-adj-cd = "M" 
		then 
		    add ws-posted-ohip	to clmhdr-manual-and-tape-paymnts    
*					   clmhdr-tot-claim-ar-ohip 
					   batctrl-manual-pay-tot   
					   batctrl-calc-tot-rev 
		    add ws-amt-tech	to clmhdr-amt-tech-paid 
		else 
		    if batctrl-adj-cd = "R" 
		    then 
			add ws-posted-ohip	to batctrl-calc-tot-rev 
						   clmhdr-tot-claim-ar-ohip 
			add ws-posted-oma	to clmhdr-tot-claim-ar-oma 
			add ws-amt-tech		to   clmhdr-amt-tech-billed 
		    else                
*			(note -- no default for adj-cd) 
			next sentence.    
*		    endif 
*		endif 
*	    endif 
*	endif 
*   endif 
 
*	(write the 'originating-batch-nbr' index -- 
*	  -- so that claim header will appear in input batch's claims) 
 
*mf move "B"				to key-clm-key-type. 
*mf move clmhdr-orig-batch-id		to key-clm-data.
    move "B"                            to clmdtl-b-key-type.
*mff					   clmrec-hdr-b-key-type
*mff					   k-clmdtl-b-key-type.
    move clmhdr-orig-batch-id           to clmdtl-b-data
*mff					   clmrec-hdr-b-data
*mff					   k-clmdtl-b-data.
*mf move zeros				to key-clm-oma-cd 
*mf					   key-clm-oma-suff 
*mf					   key-clm-adj-nbr. 
    move zeros				to clmdtl-b-oma-cd 
					   clmdtl-b-oma-suff 
					   clmdtl-b-adj-nbr.
*mff					   k-clmdtl-b-oma-cd
*mff					   k-clmdtl-b-oma-suff
*mff					   k-clmdtl-b-adj-nbr.
   
*mf (conversion technique - keys are already setup in FD area but data is to be
*mf  written from rec in WS area. Therefore move keys into WS rec)
    move key-claims-mstr		to k-clmhdr-claims-mstr.
*mf (adjustment record's don't need "P"atient key 
    move "Z"				to	clmdtl-p-key-type
					     of claims-mstr-rec.
    move clmdtl-p-claims-mstr		to k-clmhdr-p-claims-mstr.
    write claims-mstr-rec  from  claim-header-rec
*mf						key is key-claims-mstr 
	invalid key 
	    move 29			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add  1				to ctr-writ-claims-mstr. 
 
ma0-99-exit. 
    exit. 


na0-write-clmdtl. 
*	(set adjustment # to non-zero value so that this adjustment rec can be 
*	  distinguished from an original claim rec) 
    move 1				to clmdtl-adj-nbr. 
 
*	(write data record and the index so that the detail record will appear in 
*	   the sequence of the input batch's claim records) 
 
*mf move "B"				to key-clm-key-type. 
*mf move clmdtl-orig-batch-id		to key-clm-data. 
    move "B"                            to clmdtl-b-key-type
					   clmrec-hdr-b-key-type
					   k-clmdtl-b-key-type.
    move clmhdr-orig-batch-id           to clmdtl-b-data
					   clmrec-hdr-b-data
					   k-clmdtl-b-data.
 
*	(if entry didn't require oma code then use "ADJUS" for adjustment batch 
*	 or "PAID" for payment batch) 
    if clmdtl-oma-cd =   spaces 
		      or zeros 
    then 
	if clmhdr-batch-type = "A" 
	then 
	    move 'ADJU'			to clmdtl-oma-cd 
	    move 'S'			to clmdtl-oma-suff 
	else 
	    if clmhdr-batch-type = "P" 
	    then 
		move "PAID"		to clmdtl-oma-cd 
		move spaces		to clmdtl-oma-suff 
	    else 
		next sentence 
*	    endif 
*	endif 
    else 
	next sentence. 
*   endif 
 
*mf move clmdtl-oma-cd			to key-clm-oma-cd. 
*mf move clmdtl-oma-suff		to key-clm-oma-suff. 
*mf move zero				to key-clm-adj-nbr. 
*mf brad debug below lines - needed ???
    move clmdtl-oma-cd			to clmdtl-b-oma-cd.
    move clmdtl-oma-suff		to clmdtl-b-oma-suff. 
    move zero				to clmdtl-b-adj-nbr. 

*mf (conversion technique - keys are already setup in FD area but data is to be
*mf  written from rec in WS area. Therefore move keys into WS rec)
    move key-claims-mstr		to k-clmdtl-claims-mstr
						of claim-detail-rec.
*mf (adjustment record's don't need "P"atient key 
    move "Z"				to	clmdtl-p-key-type
					     of claims-mstr-rec.
    move clmdtl-p-claims-mstr		to k-clmdtl-p-claims-mstr
						of claim-detail-rec.
    write claims-mstr-rec  from  claim-detail-rec	
*mf						key is key-claims-mstr 
	invalid key 
	    move 30			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
    add 1				to ctr-writ-claims-mstr. 
 
*   (all transactions except 'M' and 'R' adjust existing claims and as
*   such must the detail recs must  appear in the claim being adjusted
*   as well as the adjustment claim.  DG cobol used a 2nd write inverted
*   to create the appropriate 2nd key for the detail rec however in
*   MF cobol the only way to get a 2nd "B" key is to do an 2nd write.
*   Therefore the write invert is changed to a simple write with the
*   "B" key setup for the adjusted claim and the "P" or 
*    alternative key is set to "Z" so that it is in a sequence position
*   that all other programs will ignore.)
  
    if batctrl-adj-cd =   "M" 
		       or "R" 
    then 
   	   go to na0-99-exit. 
*   (else) 
*   endif 

*mf move clmdtl-id			to	key-clm-data. 
    move clmdtl-id                      to      clmdtl-b-data.
    move "B"				to	clmdtl-b-key-type.
    move "Z"				to	clmdtl-p-key-type
					     of claims-mstr-rec.

*mf write  inverted  claims-mstr-rec	key is key-claims-mstr 
    write            claims-mstr-rec
	invalid key 
	    move 31			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 add 1				to ctr-writ-claims-mstr. 
 
na0-99-exit. 
    exit. 


pa0-update-adjusted-claim. 
 
*	('M' and 'R' do not adjust an existing claim so no processing needed) 
    if batctrl-adj-cd =   "M" 
		       or "R" 
    then 
	go to pa0-99-exit. 
*   (else) 
*   endif 
 
*mf  (brad - is the below actually working ???)
*   (read in ab0 and store in claim's header rec save area) 
    move ws-save-claims-header  		to claim-header-rec. 
    move ws-save-claims-feedback		to feedback-claims-mstr. 
 
*   (re-read updated header rec) 
*mf move "B"					to key-clm-key-type. 
*mf move clmhdr-claim-id			to key-clm-data. 
    move "B"                            	to clmdtl-b-key-type.
    move clmhdr-claim-id                	to clmdtl-b-data.
 
    move 0					to claims-occur. 
    move zeros					to feedback-claims-mstr. 
 
    perform xc0-read-claims-mstr		thru xc0-99-exit. 
 
    if flag = "N" 
    then 
	move 40					to err-ind 
	perform za0-common-error		thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
 
*	(update header of claim being adjusted) 
    if batctrl-adj-cd = "A" 
    then 
	add ws-posted-oma			to clmhdr-tot-claim-ar-oma 
	add ws-posted-ohip			to clmhdr-tot-claim-ar-ohip 
	add ws-amt-tech 			to clmhdr-amt-tech-billed 
    else 
	if batctrl-adj-cd = "B" 
 	then 
	    add ws-posted-oma			to clmhdr-tot-claim-ar-oma 
	    add ws-posted-ohip			to clmhdr-tot-claim-ar-ohip 
	    add ws-amt-tech			to clmhdr-amt-tech-billed 
	else 
	    if batctrl-adj-cd = "C" 
	    then 
		add ws-posted-ohip		to clmhdr-manual-and-tape-paymnts 
		add ws-posted-ohip		to clmhdr-curr-payment 
		add ws-amt-tech			to clmhdr-amt-tech-paid 
	    else 
		next sentence. 
*	    endif 
*	endif 
*   endif 

*mf (added move statment since 'rewrite' stmnt  with 'from' optino
*mf  kept getting invalid key)
    move claim-header-rec		to	claims-mstr-rec.
    rewrite  claims-mstr-rec
*mf       get invalid key with 'from claim-header-rec' on 'rewrite'
*mf			key is key-claims-mstr 
	invalid key 
	    move 34				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to az0-end-of-job. 
 
 
pa0-99-exit. 
    exit. 
xa0-disp-batctrl-data. 
 
    display scr-title-batch-control-data. 
 
    display scr-acpt-batch-nbr. 
    display scr-acpt-batch-type. 
    display scr-val-batch-period-cycle. 
    display scr-acpt-mask. 
    display scr-lit-batctrl-data. 
 
    subtract batctrl-amt-act			from      batctrl-amt-est 
						giving ws-batctrl-amt-diff. 
    display scr-val-batctrl-data. 
 
xa0-99-exit. 
    exit. 
xb0-allow-change-of-estimates. 
 
    display scr-acpt-change-verification. 
    accept  scr-acpt-change-verification. 
 
    if change-reply = "Y" 
    then 
	display scr-acpt-change-password 
	accept  scr-acpt-change-password 
	if password-input  =  password  or  password-special-privledges 
	then 
	    perform xb1-input-batctrl-est	thru xb1-99-exit 
	    go to xb0-allow-change-of-estimates 
	else 
	    move 3				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to xb0-allow-change-of-estimates. 
*	endif 
*    (else) 
*    endif 
 

xb0-99-exit. 
    exit. 
 
 
 
xb1-input-batctrl-est. 
 
*     (input estimate of total fee amounts in batch) 
 
    accept  scr-amt-est. 
*	(default for 'C' type 'P'ayment is positive data entry but value is to 
*	 be negative on file so sign is reversed) 
    if    batctrl-batch-type = "P" 
      and batctrl-adj-cd     = "C" 
    then 
	subtract batctrl-amt-est		from	zero    
						giving	batctrl-amt-est 
	display scr-amt-est. 
*   (else) 
*    endif 
 
*	(if special password is entered then allow updating of the 
*	 the batch control rec's actual values -- this is to be done 
*	 only by dyad staff to correct the batctrl rec when it  
*	 differs from the actual value of records in the batch. this 
*	 would happen if the adjustment program crashed or if the system 
*	 went down while the adjustment program was running (d004). 
*	 this discrepancy would be shown in reports r002a or r002b) 
 
    if password-input = password-special-privledges 
    then 
	accept scr-amt-act. 
*   (else) 
*   endif 
 
    subtract batctrl-amt-act			from      batctrl-amt-est 
						giving ws-batctrl-amt-diff. 
    display scr-amt-diff. 
 
 
xb1-99-exit. 
    exit. 
xc0-read-claims-mstr. 
 
    read claims-mstr	into claim-header-rec	  key is key-claims-mstr 
	invalid key 
		move "N"		to	flag 
		go to xc0-99-exit. 
 
    move "Y"				to	flag. 
    add  1				to	ctr-read-claims-mstr. 
 
xc0-99-exit. 
    exit. 


xd0-read-clmdtl. 
 
    read    claims-mstr    next   into claim-detail-rec 
*mf	invalid key 
	at end
	    move "N"				to flag          
	    go xd0-99-exit. 
 
    move "Y"					to flag.        
    add	1					to ctr-read-claims-mstr. 
 
xd0-99-exit. 
    exit. 
xe0-read-claims-mstr. 
 
    move zero 			to claims-occur. 
    move spaces			to feedback-claims-mstr. 
 
    read claims-mstr		key is key-claims-mstr 
	invalid key 
	    move "N"			to flag 
	    go to xe0-99-exit. 
 
    move "Y"				to flag. 
    add  1				to ctr-read-claims-mstr. 
 
xe0-99-exit. 
    exit. 
xf0-read-doc-mstr. 
 
    read  doc-mstr 
	invalid key 
		move "N"		to flag 
		go to xf0-99-exit. 
 
    move "Y"				to flag. 
    add  1				to ctr-read-doc-mstr. 
 
xf0-99-exit. 
    exit. 
xh0-read-oma-fee-mstr. 
 
    read  oma-fee-mstr	
*mf	suppress data record 
	invalid key 
		move "N"		to flag 
		go to xh0-99-exit. 
 
    move "Y"				to flag. 
    add  1				to ctr-read-oma-mstr. 
 
xh0-99-exit. 
    exit. 

* MC5
xi0-read-oma-dtl.

   read  f040-dtl
       invalid key	
		move 'N'		to flag
		go to xi0-99-exit.

   move 'Y'				to flag. 

xi0-99-exit.
   exit.
* MC5 - end

xj0-read-const-mstr. 
 
    read    iconst-mstr 
	invalid key 
	    move "N"			to flag 
	    go to xj0-99-exit. 
 
    move "Y"				to flag. 
    add  1				to ctr-read-const-mstr. 
 
 
xj0-99-exit. 
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
 
za1-common-warning. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display wrn-msg-line. 
* 2011/11/16 - MC1 
    move spaces 			to      confirm-space.
* 2011/11/16 - end
    accept scr-confirm. 
* 2011/11/16 - MC1
    if confirm-space  = '!' or '*'
    then
	next sentence
    else
	go to za1-common-warning.
*   endif
*   2011//11/16 - end

*   display confirm. 
*   stop " ". 
    display blank-line-24. 

za1-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
