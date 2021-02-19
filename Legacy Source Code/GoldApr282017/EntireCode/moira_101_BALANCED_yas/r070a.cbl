identification division. 
program-id. r070a.  
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/02/07. 
date-compiled. 
security. 
* 
*    files      : f002  - claims master 
*		: f010  - patient master 
*		: f090i - constants master    
*		: r070_work_mstr_cc  - claims work file (where "CC" = clinic nbr) 
*		: r070_par_file      - parameter file indicating to the programs 
*				       that follow r070a which clinic is being processed. 
*		: r070a	- error report 
* 
*    program purpose: this program is the first in a series of 3 programs 
*			whose purpose is to produce the accounts receivable 
*			trial balance report. this program produces the 
*			claims work file. 
* 
* 
*   revised feb/84 (a.j.) - adjust the work file to carry the clmhdr- 
* 			    sub-nbr and clmhdr-tape-submit-ind 
* 
*   revised nov/84 (m.s.) - add subscriber master, 
*			    modify the program to access subscr mstr 
*			    to get subscr-date-last-statement for 
*			    direct billing. 
* 
*   revised nov/84 (m.s.) - provide two further aging categories, 
*			    replace 'OVER 120' with '120-150', 
*			    add '150-180' and 'OVER 180'. 
* 
*   revised jan 23/85 (iw) - open all files for input only. 
* 
*   revised feb 26/85 (ms) - sms 85.2 
*                          - pat-mstr and subscr-mstr are not used. 
*			     the field "SUBSCR-DATE-LAST-STATEMENT" 
*			     is not used; INSTEAD, THE FIELD 
*			     "CLMHDR-REFERENCE" is used.  all the 
*			     unnecessary codes are being commented 
*			     instead of deleting them. 
* 
*	    mar 12/85 (iw) - added a move of clmhdr-orig-batch-nbr-3 to the 
*			     wk-batch-nbr-3 so it is not null. 
* 
*   revised nov 05/85 (ms) - print patient id instead of ikey. 
*                            lookup on pat-mstr since claims master 
*                            no longer stores the patient id. 
* 
*   revised dec 10/85 (ms) - pdr 294 
*                          - print error message if there is a 
*			     blank ikey in the claims mstr 
* 
*   revised dec 20/85 (ms) - pdr 296 
*			   - print error on the error report if the 
*  			     claim header contains the blank ikey 
* 
*   revised may 27/87 (sb) - coversion from aos to aos/vs. 
*                            change field size for 
*                            status clause to 2 and 
*                            feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised march/91 : - sms 138  (b.m.l.) 
*                      - print health number in place of ohip if it 
*                        is not blank. 
* 
*   revised july/93  : - sra 076  (y.b.) 
*                      - change purge amount to .85 
* 
*   revised feb/98 j. chau  : - s149 unix conversion
* 
*  1999/jan/31 B.E.    - y2k
*
*  1999/Nov/24 M.C.    - y2k
*		       - convert changes into copybook, "r070a_ab1.rtn"
*				  copybook is added
*
*  2001/Sep/25 M.C.    - According to Thelka, balance due should be calculated
*		         based on ohip fee and amount paid for all agents
*  2003/dec/10 M.C.	- alpha doc nbr
*  2004/jun/04 b.e.	- correct alpha doctor number "add to claim number" to
*			  consider adding to alpha number
*  2017/Apr/20 MC1      - balance due should be calculated based on oma fee and amount paid for direct bill agent

environment division. 
input-output section. 
file-control. 
  
    copy "f002_claims_mstr.slr". 
* 
* 
*mf    copy "f002_clm_mstr_p_access.slr". 
* 
    copy "f010_new_patient_mstr.slr". 
* 
*   copy "f011_new_subscriber_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
*                                    
    copy "r070_claims_work_mstr.sls". 
* 
    copy "r070_param_file.sls". 
* 
    select print-file 
	assign to printer prt-file-name 
	file status is status-prt-file. 
 
data division. 
file section. 
  
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
* 
*mf    copy "f002_clm_mstr_p_access.fd". 
* 
    copy "f010_patient_mstr.fd". 
* 
    copy "r070_claims_work_mstr.fd". 
* 
*   copy "f011_subscriber_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
    copy "r070_param_file.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-rec				pic x(132). 
 
working-storage section. 
 
77  prt-file-name				pic x(5) value "r070a". 
 
77  pat-occur					pic 9(12). 
77  claims-pat-access-occur			pic 9(12). 
77  claims-occur				pic 9(12). 
 
*   status file indicators 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-claims-mstr-pat-access		pic x(11) value zero. 
*mf 77  status-work-mstr			pic x(11) value zero. 
*mf 77  status-param-file			pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 
*mf 77  status-pat-mstr				pic x(11) value zero. 
* 77  status-subscr-mstr			pic x(11) value zero. 

77  common-status-file				pic xx. 
77  status-cobol-claims-mstr			pic xx    value zero. 
77  status-cobol-work-mstr			pic xx    value zero. 
77  status-cobol-param-file			pic xx    value zero. 
77  status-cobol-iconst-mstr			pic xx    value zero. 
77  status-cobol-pat-mstr			pic xx    value zero. 
77  status-prt-file				pic xx    value zero. 
 
77  feedback-pat-mstr				pic x(4). 
77  feedback-claims-mstr			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
*mf 77  feedback-claims-mstr-pat-access		pic x(4). 
 
77  const-mstr-rec-nbr				pic x. 
 
*   flag indicators 
77  err-ind					pic 99 	value zero. 
77  header-done					pic x 	value "N". 
77  totals-written				pic x	value "N". 
77  display-key-type				pic x(7). 
77  ss						pic 99	comp.

* MC1
copy "def_agents.ws".
* MC1 - end

01  flag-request-complete                       pic x.
    88  flag-request-complete-y                 value "Y".
    88  flag-request-complete-n                 value "N".

01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
*   eof flags 
77  error-flag					pic x   value "N". 
77  eof-claims-mstr				pic x	value "N". 
77  end-search-index				pic x   value "N". 
*mf 77  eof-claims-mstr-pat-access		pic x	  value "N". 
 
*   variables 
77  ss-var-err					pic 99  value 14. 
77  age-category				pic 99. 
77  mth-old					pic s9(5).     
77  day-old-r					pic xxx. 
77  i						pic 99. 
77  dept-nbr					pic 9. 
77  request-clinic				pic 9(4). 
77  sel-clinic-nbr				pic xx. 
77  age-yy					pic s9(4). 
77  age-mm					pic s99. 
77  age-dd					pic s99.    
77  ws-reply					pic x. 
77  ws-date-reply				pic x. 
 
*   total variables 
77  dept-tot-amount				pic s9(8)v99. 
77  balance-due					pic s9(6)v99.    
77  write-off-nbr-of-clms  			pic 999. 
 
01  blank-line					pic x(132) value spaces. 
 
01  audit-line. 
     05  filler					pic x(10) value spaces. 
     05  audit-title				pic x(60). 
     05  filler 				pic x(10) value spaces. 
     05  audit-count				pic 9(10). 
     05  filler					pic x(42) value spaces. 
 
*   hold-area. 
*!77  hold-batch-nbr				pic 9(9) value zero. 
77  hold-batch-nbr				pic x(8) value zero. 
77  hold-claim-nbr				pic 9(2) value zero. 

01 tmp-doc-nbr-alpha.
*01 tmp-batch-nbr-r redefines tmp-doc-nbr-alpha.
    05 tmp-batch-nbr-index      		pic x(1) occurs 8 times.
 
01  hold-key. 
    05  hold-key-clm-batch-nbr. 
    	10  hold-key-clinic-nbr1		pic 99. 
*!  	10  hold-key-doc-nbr			pic 9(4). 
  	10  hold-key-doc-nbr			pic x(3). 
	10  hold-key-week    			pic 99. 
	10  hold-key-day			pic 9. 
    05  hold-key-claim-nbr			pic 99. 
    05  hold-key-oma-code			pic x999. 
    05  hold-key-oma-suff			pic x. 
    05  hold-key-adj-nbr			pic x. 
 
01 hold-pat-key. 
    05  hold-pat-key-type			pic a. 
    05  hold-pat-key-data			pic x(15). 
 
01  sel-report-date. 
    05  report-yy				pic 9(4). 
    05  filler					pic x  value "/". 
    05  report-mm				pic 99. 
    05  filler					pic x  value "/". 
    05  report-dd				pic 99. 
 
01  save-agent-cd				pic 9. 
 
 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-reads			pic 9(7). 
    05  ctr-claims-mstr-writes			pic 9(7). 
    05  ctr-claims-mstr-del			pic 9(7). 
    05  ctr-claims-mstr-p-access-reads		pic 9(7). 
    05  ctr-claims-mstr-p-access-del		pic 9(7). 
    05  ctr-claims-work-mstr-writes		pic 9(7). 
 
* copy "F010_KEY_PAT_MSTR.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
01  work-file-name. 
    05  filler					pic x(15) value 
	"r070_work_mstr_". 
    05  work-file-clinic-nbr			pic x(2). 
 
01  par-file-name. 
    05  filler					pic x(14) value 
	"r070_par_file". 
 
copy "mth_desc_max_days.ws". 
 
copy "sysdatetime.ws". 
 
01  key-claims-mstr-pat-access. 
    05  key-clm-pat-access-type			pic a. 
    05  key-clm-pat-access-data. 
	10  key-clm-pat-access-pat-id		pic x(15). 
	10  filler				pic xx. 
 
01  key-gen-claims-mstr-pat-access. 
    05  key-gen-clm-pat-access			pic a. 
    05  key-gen-clm-pat-access-data		pic x(17). 
 
 
01  h1-head. 
 
    05  filler 					pic x(50) value spaces. 
    05  filler 					pic x(82) value 
				"ERROR REPORT FOR R070A". 
 
 
01  h2-head. 
 
    05  filler					pic x(20) value spaces. 
    05  filler					pic x(22) value 
				"CLAIMS NBR". 
    05  filler					pic x(90) value 
				"ACRONYM". 
 
 
01  d1-line. 
 
    05  filler					pic x(20) value spaces. 
*!    05  d1-batch-nbr				pic 9(9). 
    05  d1-batch-nbr				pic x(8). 
    05  d1-claim-nbr				pic 9(2). 
    05  filler					pic x(11) value spaces. 
    05  d1-acronym				pic x(9). 
    05  filler					pic x(81) value spaces. 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
    	"NO CLAIMS MASTER SUPPLIED OR NO CLAIMS FOR THIS CLINIC". 
	10  filler				pic x(60)   value 
			"INVALID DEPARTMENT NUMBER     ". 
	10  filler				pic x(60)   value 
			"PATIENT INDEX NOT FOUND NO DELETE". 
	10  filler				pic x(60)   value 
			"INVALID READS ON DOCTOR MASTER". 
	10  filler				pic x(60)	value 
    			"INVALID CLINIC IDENTIFIER". 
	10  filler				pic x(40)	value 
			"CLAIM DETAIL MISSING - KEY IS = ". 
	10  clm-dtl-err-msg			pic x(20) value spaces. 
	10  filler				pic x(60)   value 
			"INVALID KEY FOUND - WHEN DELETING FROM CLAIMS-MSTR". 
	10  filler				pic x(60)    value 
			"INVALID READ ON PATIENT MASTER". 
	10  filler				pic x(40)    value 
			"INVALID REWRITE TO PAT MAST KEY IS ". 
	10  pat-key-err-msg			pic x(20) value spaces. 
	10  filler				pic x(40)	value 
			"INVALID P-KEY READ ON CLM MSTR KEY IS ". 
	10  clm-hdr-err-msg			pic x(20) value spaces. 
	10  filler				pic x(60)	value 
			"INVALID DELETE ON CLAIMS MSTR USING P-KEY". 
	10  filler				pic x(60)	value 
			"WRONG RECORD ACCESSED USING P-KEY". 
	10  filler				pic x(60)    value 
		"DO NOT DELETE-THIS SLOT USED FOR VARIABLE ERROR INFO". 
	10  filler				pic x(60)    value 
		"BLANK IKEY IN CLAIMS MSTR". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 15 times.     
 
01  err-msg-comment				pic x(60).      
 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
procedure division. 
declaratives. 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
*mf    move status-iconst-mstr			to common-status-file. 
    move status-cobol-iconst-mstr		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop run. 
 
* err-subscr-mstr-file section. 
*   use after standard error procedure on subscr-mstr. 
* err-subscr-mstr. 
*   stop "ERROR IN ACCESSING SUBSCRIBER MASTER". 
*   move status-subscr-mstr			to common-status-file. 
*   display file-status-display. 
*   stop run. 
 
err-claim-header-mstr-file section. 
    use after standard error procedure on claims-mstr. 
err-claims-mstr. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
*mf    move status-claims-mstr			to common-status-file. 
    move status-cobol-claims-mstr		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop run. 
 
  err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
   err-pat-mstr. 
*   if key-pat-key-type = 'A' 
*   then 
*	move 'ACRONYM'				to display-key-type 
*   else 
*	if key-pat-key-type = 'O' 
*	then 
*	    move 'OHIP'				to display-key-type 
*	else 
*	    if key-pat-key-type = 'C' 
*	    then 
*		move 'CHART'			to display-key-type 
*	    else 
*		move 'UNKNOWN'			to display-key-type. 
*	    endif 
*	endif 
*   endif 
 
*mf    move status-pat-mstr			to common-status-file. 
    move status-cobol-pat-mstr			to common-status-file. 
*   display file-pat-status-display. 
    display common-status-file. 
    stop " ". 
    stop run. 
 
*mf err-claims-mstr-pat-access-file section. 
*mf    use after standard error procedure on claims-mstr-pat-access. 
 
*mf err-claims-mstr-pat-access. 
*mf    move status-claims-mstr-pat-access	to	common-status-file. 
*   display file-status-display. 
*mf    display common-status-file. 
*mf    stop "ERROR IN ACCESSING CLAIMS MSTR PAT ACCESS". 
 
err-work-mstr-file section. 
    use after standard error procedure on claims-work-mstr. 
 
err-work-mstr. 
*mf    move status-work-mstr		to	common-status-file. 
    move status-cobol-work-mstr		to	common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING WORK MSTR". 
 
err-parameter-file section. 
    use after standard error procedure on param-file. 
 
err-param-file. 
*mf    move status-param-file		to	common-status-file. 
    move status-cobol-param-file	to	common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING PARAM FILE". 
 
end declaratives. 
 
 
mainline section. 
 
    perform aa0-initialization			thru aa0-99-exit. 
    perform ab1-wk-file-creation		thru ab1-99-exit. 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
    accept sys-date				from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
 
    open input 	claims-mstr 
*mf		claims-mstr-pat-access 
 		pat-mstr 
		iconst-mstr. 
*               subscr-mstr. 
 
 
    move spaces				to	day-old-r. 
    move zeros				to	   balance-due 
						   hold-key 
						   save-agent-cd 
						   age-category 
	            				   mth-old 
						   age-yy 
						   age-mm   
						   age-dd      
						   counters. 
 
*    (display screen title) 
*   display scr-title. 
 
aa0-10-enter-clinic-nbr. 
 
*   accept scr-clinic-nbr. 
    accept sel-clinic-nbr. 
 
    if 	sel-clinic-nbr = "**" 
    then 
        move  0  			to iconst-clinic-nbr-1-2 
    else 
        move sel-clinic-nbr 		to iconst-clinic-nbr-1-2. 
*   endif  
 
    read iconst-mstr 
        invalid key 
		move 6 				to err-ind 
		perform za0-common-error 	thru za0-99-exit 
  		go to aa0-10-enter-clinic-nbr. 
 
*   display msg-month. 
 
*   display scr-accept-date. 
 
aa0-11. 
 
*   accept date-reply. 
    accept ws-date-reply. 
 
*   if 	ws-date-reply not = "Y" 
*   then 
*       accept scr-year 
*	accept scr-month 
*	accept scr-day 
*	go to aa0-11. 
*   (else) 
*   endif 
 
*   display msg-continue. 
 
*   accept reply. 
    accept ws-reply. 
 
    if 	ws-reply not = "Y" 
    then 
        go to az0-finalization 
    else 
*       display program-in-progress. 
*  (endif) 
 
    move sel-clinic-nbr			to	work-file-clinic-nbr. 
*    expunge param-file. 
*    expunge claims-work-mstr. 
*    expunge print-file. 
 
    open output param-file 
		print-file 
 		claims-work-mstr. 
 
    move spaces				to	param-file-rec. 
    move sel-clinic-nbr			to	param-clinic-nbr-1-2. 
    move sys-date-long			to	param-run-date. 
    move iconst-date-period-end-yy 	to  param-date-period-end-yy. 
    move iconst-date-period-end-dd 	to  param-date-period-end-dd. 
    move mth-desc (iconst-date-period-end-mm)	to 
					    param-date-period-end-mm. 
    move iconst-clinic-name		to  param-clinic-name. 
    move iconst-clinic-nbr		to	param-clinic-nbr. 
    write param-file-rec. 
 
aa0-20-read-claims-mstr. 
 
*mf    move "B"				to key-clm-key-type. 
*mf    move zero			to key-clm-data. 
*mf    move sel-clinic-nbr 		to key-clm-clinic-nbr-1-2. 

    move zero				to clmdtl-b-data. 
    move "B"				to clmdtl-b-key-type. 
    move sel-clinic-nbr 		to clmdtl-b-clinic-nbr-1-2. 
 
    perform cb0-read-select-claim-apprx	thru	cb0-99-exit. 
 
    if eof-claims-mstr = "Y" 
    then 
	move 2				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-finalization. 
*   (else) 
*   endif 
 
    move clmhdr-agent-cd		to save-agent-cd. 
 
    write print-rec from h1-head after advancing page. 
 
    write print-rec from h2-head after advancing 3 lines. 
 
aa0-99-exit. 
    exit. 
ab1-wk-file-creation. 
 
    if clmhdr-agent-cd not = save-agent-cd 
    then  
        move clmhdr-agent-cd			to save-agent-cd. 
*   (else) 
*   endif 
 
*	(note - 'PAYMENTS' field is stored as negative amt so  
*	        amt owing = original bal - payments 
*		can be calculated by *adding* payment field 
 
*	(if    agent = 'OHIP' 
*	   or agent not = 'OHIP' but claim was one that was converted from old system) 
*	then   use 'OHIP' amt as value of claims rather than 'OMA' amt) 

** 2001/09/25 - MC - determine balance due based on ohip feee regardless of agent

**  if clmhdr-agent-cd = "0"	or 
**     clmhdr-date-sys = "19800730" 
**  then 
* MC1 
    move clmhdr-agent-cd		to def-agent-code.
    if not def-agent-bill-direct
    then
	add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-ohip 
*						giving balance-due.
						giving balance-due
**  else 
**	add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-oma 
**				giving balance-due. 
*   endif 
    else 
  	add clmhdr-manual-and-tape-paymnts, clmhdr-tot-claim-ar-oma 
  				giving balance-due. 
*   endif 
* MC1 - end

** 2001/09/25 - end

*************************
*
* 99/11/24 - MC
*
    copy "r070a_ab1.rtn".


*************************

    if eof-claims-mstr not = "Y" 
    then 
	go to ab1-wk-file-creation.       
*   (else) 
*   endif 
 
ab1-99-exit. 
    exit. 
az0-finalization. 
 
    close claims-mstr 
          iconst-mstr 
 	  pat-mstr 
*	  subscr-mstr 
*mf	  claims-mstr-pat-access 
	  param-file 
	  print-file 
	  claims-work-mstr. 
 
    accept sys-time				from time. 
*   display scr-closing-screen. 
*   display confirm. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ca1-calculate-age-category. 
 
    compute age-yy rounded = iconst-date-period-end-yy - clmhdr-period-end-yy. 
    compute age-mm rounded = iconst-date-period-end-mm - clmhdr-period-end-mm. 
**    compute age-dd rounded = iconst-date-period-end-dd - clmhdr-period-end-dd.     
 
    compute mth-old rounded = (age-yy * 12) + age-mm. 
    
    if 	mth-old < 0 
    then  
        move 0 to mth-old. 
*   (else) 
*   endif 
 
    if 	mth-old < 1 
    then 
        move 0				to age-category 
	move "CUR"			to day-old-r 
    else  
        if  mth-old < 2 
        then 
            move 1			to age-category  
	    move "30"			to day-old-r 
	else 
	    if  mth-old < 3 
            then  
		move 2			to age-category 
		move "60"		to day-old-r 
	    else 
		if  mth-old < 4    
                then 
                    move 3		to age-category 
		    move "90"		to day-old-r 
 		else      
		    if mth-old < 5 
		    then 
		    	move 4		to age-category 
		    	move "120"	to day-old-r 
		    else 
			if mth-old < 6 
			then 
			    move 5	to age-category 
			    move "150"  to day-old-r 
			else 
			    move 6	to age-category 
			    move "180"	to day-old-r. 
*			endif 
*		    endif 
*		endif 
*	    endif 
*	endif 
*   endif 
 
ca1-99-exit. 
    exit. 
cb0-read-select-claim-apprx. 
 
    move zero				to	feedback-claims-mstr 
						claims-occur. 
 
*mf    read claims-mstr  key is key-claims-mstr approximate 
*mf      invalid key 
*mf          move "Y"			to	eof-claims-mstr 
*mf        go to cb0-99-exit. 
 
    start claims-mstr  key is greater than or equal to key-claims-mstr
      invalid key 
          move "Y"			to	eof-claims-mstr 
          go to cb0-99-exit. 

    read claims-mstr next.
 
    if   status-cobol-claims-mstr = 23 
      or 
	 status-cobol-claims-mstr = 99 
    then  
        move "Y"			to	eof-claims-mstr 
        go to cb0-99-exit 
    else 
        if status-cobol-claims-mstr = 10 
        then  
            move "Y"			to	eof-claims-mstr 
            go to cb0-99-exit  
        else 
            move "N" 			to 	eof-claims-mstr. 
*       endif 
*   endif 
 
*mf    retrieve claims-mstr key fix position 
*mf    into key-claims-mstr. 
 
    if eof-claims-mstr = "Y" 
    then 
	go to cb0-99-exit 
    else 
	next sentence. 
*   endif 

*brad 
*  display test-key-display. 
*  display key-claims-mstr.
*  if  clmdtl-b-doc-nbr = "029" and clmdtl-b-claim-nbr = 99 then
*	next sentence.
* endif
 
*	(check for end of 'B'atch type keys) 
    if   ( sel-clinic-nbr  not = clmhdr-clinic-nbr-1-2 ) 
*mf      or ( key-clm-key-type not = 'B' ) 
      or ( clmdtl-b-key-type not = 'B' ) 
    then 
	move "Y"			to	eof-claims-mstr 
	go to cb0-99-exit.   
*   (else) 
*   endif   


 
*	(only 'C'laim batch type claim header records are to be processed -- 
*	    --   'C' type 'P'ayments (p/c) 
*	       and 'A' and 'B' type 'A'djustments (a/a and a/b) 
*	          adjust existing claims and their adjustment is reflected 
*		  in the adjusted claim'S CLMHDR-REC. THEREFORE THE 
*		  adjustment'S CLMHDR-REC CAN BE IGNORED. 
*	    --   'R' and 'M' types adjust 'REVENUE' only and do not adjust 
*	         the accounts receivable -- thus their clmhdr recs are ignored as well)    
 
    if clmhdr-batch-type not = "C" 
    then 
	perform cb3-add-to-claim-nbr	thru	cb3-99-exit 
	go to cb0-read-select-claim-apprx. 
*   (else) 
*   endif   
 
    add 1				to	ctr-claims-mstr-reads. 
 
 
cb0-99-exit. 
    exit. 
cb2-read-claim-next-for-index. 
 
    move zero				to	feedback-claims-mstr 
						claims-occur. 
 
*mf    read claims-mstr-pat-access next 
*mf        at end  
*mf            move "Y" to end-search-index. 
 
*mf    if 	hold-pat-key-data not = pat-access-pat-key-data 
*mf    then 
*mf        move "Y" to end-search-index. 
*  (else) 
*       endif 
 
    read claims-mstr key is clmdtl-p-claims-mstr 
        invalid key
            move "Y" to end-search-index. 
 
    if 	hold-pat-key-data not = clmdtl-p-data of k-clmdtl-p-claims-mstr 
    then 
        move "Y" to end-search-index. 

*mf    retrieve claims-mstr-pat-access key fix position 
*mf    into key-claims-mstr-pat-access. 
 
 
cb2-99-exit. 
    exit. 
cb3-add-to-claim-nbr. 
 
*mf    if  key-clm-claim-nbr = 99 
    if  clmdtl-b-claim-nbr = 99 
    then  
*mf	move zeros 			to key-clm-claim-nbr 
	move zeros 			to clmdtl-b-claim-nbr 
*mf	add 1 				to key-clm-batch-num 

* b.e. 2004/jun/01 fix bug
*!	add 1 				to clmdtl-b-batch-num 
***	add 1 				to clmdtl-b-day              
*	add 1				to clmdtl-b-batch-number-numeric
	perform xx0-increment-batch-nbr	thru	xx0-99-exit

*mf	move spaces			to key-clm-adj-nbr 
	move spaces			to clmdtl-b-adj-nbr 
    else 
*mf	add 1 				to key-clm-claim-nbr 
	add 1 				to clmdtl-b-claim-nbr 

*mf	move spaces			to key-clm-adj-nbr. 
	move spaces			to clmdtl-b-adj-nbr. 

* 99/11/25 - MC - initialize oma-cd-suff

	move spaces			to clmdtl-b-oma-cd
					   clmdtl-b-oma-suff.
*  (endif) 
 
cb3-99-exit. 
    exit. 

xx0-increment-batch-nbr.
*0 - 9 A - Z
    move "N"                            to      flag-request-complete.

    if clmdtl-b-batch-number = 999
    then
	move clmdtl-b-doc-nbr		to	tmp-doc-nbr-alpha
	display "BEFORE: " clmdtl-b-doc-nbr
	perform xx1-process-1-doc-position  thru xx1-99-exit
            varying   ss from 3 by -1
            until     ss = 0
               or      flag-request-complete-y
	move tmp-doc-nbr-alpha		to	clmdtl-b-doc-nbr
	display "AFTER : " clmdtl-b-doc-nbr
  	display " " 
        move 000			to	clmdtl-b-batch-number 
    else
	add 1				to	clmdtl-b-batch-number-numeric.
*   endif


xx0-99-exit.
   exit.

xx1-process-1-doc-position.
*if pos(1) = 0 then 1 , if 1 then 2 if 9 then A, if A then B if Z then 0 and!

    if tmp-batch-nbr-index(ss) = "0"
    then
        move "1"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "1"
    then
        move "2"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "2"
    then
        move "3"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "3"
    then
        move "4"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "4"
    then
        move "5"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "5"
    then
        move "6"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "6"
    then
        move "7"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "7"
    then
        move "8"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "8"
    then
        move "9"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "9"
    then
        move "A"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "A"
    then
        move "B"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "B"
    then
        move "C"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "C"
    then
        move "D"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "D"
    then
        move "E"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "E"
    then
        move "F"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "F"
    then
        move "G"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "G"
    then
        move "H"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "H"
    then
        move "I"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "I"
    then
        move "J"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "J"
    then
        move "K"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "K"
    then
        move "L"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "L"
    then
        move "M"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "M"
    then
        move "N"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "N"
    then
        move "O"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "O"
    then
        move "P"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "P"
    then
        move "Q"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "B"
    then
        move "R"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "R"
    then
        move "S"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "S"
    then
        move "T"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "T"
    then
        move "U"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "U"
    then
        move "V"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "V"
    then
        move "W"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "W"
    then
        move "X"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "X"
    then
        move "Y"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "Y"
    then
        move "Z"                        to      tmp-batch-nbr-index(ss)
        go to xx0-90-return
    else
    if tmp-batch-nbr-index(ss) = "Z"
    then
        move "0"                        to      tmp-batch-nbr-index(ss)
        go to xx0-99-exit.
*   endif

xx0-90-return.
    move "Y"                            to      flag-request-complete.

xx1-99-exit.
    exit.




* da4-update-pat. 
da4-read-pat. 
 
*   (check for blank ikey). 
 
    if clmhdr-pat-key-data = spaces 
    then 
 
*       (the two lines below are commented on 85/12/20 by m.s. - pdr 296, 
*	 and replaced by the next four lines (print the error report).) 
 
*	move 15					to err-ind 
*	perform za0-common-error		thru za0-99-exit 
	move clmhdr-batch-nbr			to d1-batch-nbr 
	move clmhdr-claim-nbr			to d1-claim-nbr 
	move clmhdr-pat-acronym			to d1-acronym 
	write print-rec from d1-line after advancing 2 lines 
 
	move "**BLANK IKEY**"			to pat-ohip-mmyy-r 
	go to da4-99-exit. 
*   endif 
 
    move clmhdr-pat-ohip-id-or-chart		to key-pat-mstr. 
 
    read pat-mstr 
 	invalid key 
*	    move 9				to err-ind 
*	    perform za0-common-error		thru za0-99-exit 
*           perform err-pat-mstr. 
* 
*  above three lines are commented and replaced by the following 
*  5 lines by mc on 91/jun/20 
 
	     move clmhdr-batch-nbr		to d1-batch-nbr 
	     move clmhdr-claim-nbr		to d1-claim-nbr 
	     move clmhdr-pat-acronym		to d1-acronym 
	    write print-rec from d1-line after advancing 2 lines 
     	    move "*** UNKNOWN ***"		to pat-ohip-mmyy-r 
 	    go to da4-99-exit. 
 
*   retrieve pat-mstr key fix position 
*	into key-pat-mstr. 
 
    add 1					to ctr-pat-mstr-reads. 
 
*   subtract 1					from pat-nbr-outstanding-claims. 
 
*   rewrite pat-mstr-rec 
*	invalid key 
*	    move 10				to err-ind 
*	    move key-pat-mstr			to pat-key-err-msg 
*	    perform za0-common-error		thru za0-99-exit. 
 
da4-99-exit. 
    exit. 
 
 
da6-save-clmhdr-info. 
 
    move clmhdr-batch-nbr		to 	hold-batch-nbr. 
    move clmhdr-claim-nbr		to 	hold-claim-nbr. 
    move clmhdr-pat-ohip-id-or-chart	to 	hold-pat-key. 
 
da6-99-exit. 
    exit. 
ma0-move-to-wk-file. 
 
    move clmhdr-doc-dept			to wk-dept-nbr. 
    move age-category				to wk-age-category. 
    move clmhdr-clinic-nbr-1-2			to wk-clinic-nbr. 
    move clmhdr-doc-nbr				to wk-doc-nbr. 
    move clmhdr-week   				to wk-week. 
    move clmhdr-day     			to wk-day.   
    move clmhdr-claim-nbr			to wk-claim-nbr. 
    move clmhdr-agent-cd			to wk-agent-cd.   
    move clmhdr-pat-acronym			to wk-pat-acronym. 
 
    move spaces                                 to wk-pat-id. 
* the following changed 85/11 
*   move clmhdr-pat-key-data			to wk-pat-id. 
    perform da4-read-pat			thru da4-99-exit. 
    if pat-health-nbr not = 0 
    then 
        move pat-health-nbr                     to wk-health-nbr 
    else 
        if pat-ohip-mmyy-r not = spaces 
        then 
            move pat-ohip-mmyy-r		to wk-pat-id 
        else 
            move pat-chart-nbr			to wk-pat-id. 
*       endif 
*   endif 
 
    move clmhdr-status-ohip			to wk-ohip-stat. 
    if clmhdr-agent-cd = 6 
    then 
	move clmhdr-sub-nbr 			to wk-sub-nbr 
    else 
	move zero				to wk-sub-nbr. 
    move clmhdr-tot-claim-ar-oma		to wk-oma-fee. 
    move clmhdr-tot-claim-ar-ohip       	to wk-ohip-fee. 
    move clmhdr-manual-and-tape-paymnts  	to wk-amount-paid.     
    move balance-due                     	to wk-balance-due. 
    move clmhdr-date-period-end			to wk-period-end-date. 
    move day-old-r				to wk-day-old. 
    move clmhdr-orig-batch-nbr-1-2		to wk-batch-nbr-1-2. 
*2003/12/10 - MC
*   move clmhdr-orig-batch-nbr-3		to wk-batch-nbr-3. 
*2003/12/10 - end
    move clmhdr-orig-batch-nbr-4-9		to wk-batch-nbr-4-9. 
    move clmhdr-tape-submit-ind			to wk-tape-submit-ind. 
*   if (clmhdr-agent-cd = 6) and (clmhdr-auto-logout = "Y") 
*   then 
*	perform ya0-read-subscr			thru ya0-99-exit 
*	move spaces 				to wk-act-taken 
*	move subscr-date-last-statement		to wk-act-taken-2 
*   else 
*       move clmhdr-reference			to wk-act-taken. 
 
 
* 
*   (the following statement is added for sms85.2) 
* 
    move clmhdr-reference			to wk-act-taken. 
 
*   ( read claim detail to obtain service date ). 
 
*mf    read claims-mstr  retain position next 
*       invalid key 
    read claims-mstr next
        at end      
		move 7 to err-ind 
		move key-claims-mstr		to clm-dtl-err-msg 
		perform za0-common-error	thru za0-99-exit 
		move 0				to wk-ser-date. 
 
    move clmdtl-sv-date				to wk-ser-date. 
 
ma0-99-exit. 
    exit. 
wa0-write-to-wk-file. 
 
    perform ma0-move-to-wk-file     		thru ma0-99-exit. 
    write claims-work-rec.     
 
wa0-99-exit. 
    exit. 
 
 
* ya0-read-subscr. 
 
*   move clmhdr-pat-key-data			to subscr-id. 
 
*   read subscr-mstr 
*	invalid key 
*		move spaces			to subscr-date-last-statement. 
 
* ya0-99-exit. 
*   exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment.      
*   display err-msg-line. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
