identification division. 
program-id. r014sum. 
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    files      : f001 - batch control file 
*		: f090 - iconstants master 
*		: "r014sm" - agent summary report 
* 
*    program purpose : to print the agent summary report 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised jul/17/92: - sms 139 m.c. 
*		       - summarize all clinic 60'S TOTAL 
* 
*   revised jul/28/92: - pdr 556 y.b. 
*		       - change r014_summ to r014sm  for u801 u802 
*                        purpose. 
* 
*   revised apr/19/93: - pdr 571 a.g.k. 
*                      - remove clinic 80 totals from clinic 60'S 
* 
*   rev. 17/01/96 yas: - change "BATCTRL-BATCH-STATUS" from 1 to 1 or 2 
*                      - because, implementation of u010daily program 
*
*   rev. 30/01/98 jc   - s149 unix conversion
*   rev. 05/03/99 cm   - y2k conversion 
*   2004/jan/05   b.e. - remove confirmation to run job
*   2004/mar/18   MC   - modify in ab0-processing for clinic 60 summarization
*   2007/apr/19   MC   - summarize all clinic 70'S TOTAL 
*   2010/mar/24   MC1  - include clinic 66 in clinic 60's TOTAL
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f001_batch_control_file.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
data division. 
file section. 
* 
    copy "f001_batch_control_file.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record			pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(6) 
		value "r014sm". 
77  const-mstr-rec-nbr				pic x. 
* 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
* 
*  status file indicators 
* 
*mf 77  common-status-file				pic x(11). 
*mf 77  status-batctrl-file				pic x(11) value zero. 
*mf 77  status-const-mstr				pic x(11) value zero. 
*mf 77  status-iconst-mstr				pic x(11) value zero. 

77  common-status-file				pic x(2). 
77  status-cobol-batctrl-file			pic x(2) value zero. 
77  status-cobol-iconst-mstr			pic x(2) value zero. 
77  status-prt-file				pic xx   value zero. 
 
77  ws-temp-sum					pic s9(10)v99	value zero. 
77  ws-total					pic s9(10)v99	value zero. 
77  ws-agent					pic 99. 
77  ss-adj-type					pic 99. 
77  agent					pic 99. 
77  clinic-nbr					pic 9(4). 
77  cycle-nbr					pic 999. 
77  ws-clinic-name				pic x(50). 
77  ws-temp-cash				pic s9(10)v99. 
77  err-ctr					pic 999.        
77  err-ctr-ar-due				pic 9(5)v99. 
77  err-ctr-tot-rev				pic 9(5)v99. 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  sel-clinic-nbr				pic 99. 
77  ws-reply					pic x. 
77  hold-clinic-nbr				pic 99. 
 
*mf    copy "f001_key_batctrl_file.ws". 
*    (table to store the sums by 'AGENT' --  
*	'ROWS' refer to 'AGENT' code, 'COLUMNS' refer to 'ADJ CODE')  
 
01  agent-table-subscripts. 
    05  ss-billing				pic 9	value 1. 
    05  ss-misc					pic 9	value 2. 
    05  ss-ar-and-rev				pic 9	value 3. 
    05  ss-rev-only				pic 9	value 4. 
    05  ss-bad-debts				pic 9	value 5.  
    05  ss-cash					pic 9	value 6. 
 
01  agent-table. 
    05  agent-totals occurs 10 times. 
	10  current-sums occurs 6 times		pic s9(8)v99. 
	10  mtd-sums occurs 6 times		pic s9(8)v99. 
 
01  totals-table. 
    05  current-totals occurs 6 times		pic s9(8)v99. 
    05  mtd-totals occurs 6 times		pic s9(8)v99. 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"INVALID READ ON CONSTANTS MASTER". 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"NO BATCTRL FILE SUPPLIED OR NO CORRESPONDING CLINICS". 
	10  filler				pic x(60)   value 
		"NO BATCHES FOR THIS MONTH IN FILE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs  5  times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  h1-head. 
    05  filler					pic x(8)  value 
		"R014SM /". 
    05  h1-clinic-nbr				pic zz. 
    05  filler					pic x(39)  value spaces. 
    05  filler					pic x(73)  value 
		"** CYCLE AGENT SUMMARY REPORT **". 
    05  filler					pic x(10)  value 
		"PAGE   1". 
 
01  h2-head. 
    05  filler					pic x(3)   value spaces. 
    05  filler					pic x(17)	value 
		"AGENT". 
    05  filler					pic x(16)	value 
		"BILLING". 
    05  filler					pic x(35)	value 
		"MISCELLANEOUS  ADJUSTMENTS". 
    05  filler					pic x(18)	value 
		"REVENUE". 
    05  filler					pic x(26)	value 
		"BAD". 
    05  filler					pic x(17)	value 
		"CASH      PERIOD". 
 
01  h3-head. 
    05  filler					pic x(4)	value 
			spaces. 
    05  filler					pic x(13)	value 
		"CODE". 
    05  filler					pic x(22)	value 
		"A/R & REVENUE". 
    05  filler					pic x(33)	value 
		"INCOME     A/R & REVENUE". 
    05  filler					pic x(16)	value 
		"ONLY". 
    05  filler					pic x(25)	value 
		"DEBTS". 
    05  filler					pic x(19)	value 
		"RECEIVED". 
 
01  h4-head. 
    05  filler					pic x(52) value spaces. 
    05  h4-clinic-name				pic x(45). 
    05  filler					pic x(13) value  
		"MONTH ENDING". 
* (y2k)
*   05  h4-yy					pic xx. 
    05  h4-yy                                  pic xxxx.
    05  filler					pic x  value "/". 
    05  h4-mm					pic xx. 
    05  filler					pic x  value "/". 
    05  h4-dd					pic xx. 
    05  filler					pic x(14) value spaces. 
 
01  h5-head. 
    05  filler					pic x(52) value spaces. 
    05  filler					pic x(20)  value 
		"GRAND TOTAL CYCLE # ". 
    05  h5-cycle-nbr				pic 999. 
    05  filler					pic x(57) value spaces. 
 
 
 
01  l1-print-line. 
    05  l1-part-1. 
	10  filler				pic x(5). 
	10  l1-agent-cd				pic 9. 
	10  filler				pic x(10). 
    05  l1-totals redefines l1-part-1		pic x(16). 
    05  l1-part-2 occurs 5 times. 
	10  l1-amount				pic zz,zzz,zz9.99-. 
	10  filler				pic xxx. 
    05  filler					pic x(9). 
    05  l1-cash					pic zz,zzz,zz9.99-. 
* (y2k)
*    05  l1-period				pic x(8). 
     05  l1-period                              pic x(10).
 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 12 col 20 value is "CYCLE AGENT SUMMARY REPORT - CONTINUE (Y/N)?".  
    05  scr-reply      line 12 col 65 pic x to ws-reply auto required. 
*                     
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from common-status-file  bell blink. 
    05  line 24 col 70	pic x(2) from common-status-file  bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	from err-msg-comment. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  5 col 20  value "NUMBER OF BATCH-CTRL-MSTR ACCESSES = ". 
    05  line  5 col 60  pic 9(7) from ctr-batctrl-file-reads. 
    05  line 10 col 20  value "PROGRAM R014SUM ENDING". 
* (y2k - auto fix)
*   05  line 10 col 40  pic 99  from sys-yy. 
    05  line 10 col 40  pic 9(4)  from sys-yy. 
    05  line 10 col 44  value "/". 
    05  line 10 col 45  pic 99  from sys-mm. 
    05  line 10 col 47  value "/". 
    05  line 10 col 48  pic 99  from sys-dd. 
    05  line 10 col 52  pic 99  from sys-hrs. 
    05  line 10 col 54  value ":". 
    05  line 10 col 55  pic 99  from sys-min. 
    05  line 12 col 20  value "PRINT REPORT IS IN FILE - ". 
    05  line 12 col 51  pic x(7) from print-file-name. 
              
01  scr-closing-screen-err-display. 
    05  line 16 col 20  value "NBR OF INCORRECT BATCH/ADJUST. CODES = " bell blink. 
    05  line 16 col 70  pic zz9		using err-ctr bell blink. 
    05  line 18 col 20  value "TOTAL REJECTED CALCULATED A/R DUE    = " bell. 
    05  line 18 col 70  pic z(4)9.99	using err-ctr-ar-due bell blink. 
    05  line 20 col 20  value "TOTAL REJECTED CALCULATED REVENUE    = " bell.              
    05  line 20 col 70  pic z(4)9.99	using err-ctr-tot-rev bell blink. 
procedure division. 
declaratives. 
 
err-batctrl-file section. 
    use after standard error procedure on batch-ctrl-file.       
err-batctrl. 
*mf    move status-batctrl-file		to common-status-file. 
    move status-cobol-batctrl-file	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING BATCH CONTROL FILE". 
 
 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
*mf    move status-iconst-mstr		to common-status-file. 
    move status-cobol-iconst-mstr	to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
 
 
end declaratives. 
 
main-line section. 
Mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
		until eof-batctrl-file = 'Y'. 
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
 
 
    open input	batch-ctrl-file 
		iconst-mstr. 
    move zero				to	agent-table 
						totals-table. 
    move spaces				to	l1-print-line. 
 
 
*	(display screen title/option) 
    display scr-title. 
 
aa0-10-continue-y-n. 
 
    move "Y"				to	ws-reply.
*    accept scr-reply. 
 
    if ws-reply =   "Y" 
		 or "N" 
    then 
	if ws-reply = "Y" 
	then 
	    next sentence 
	else 
	    go to az0-10-end-of-job 
*	endif 
    else 
	move 1				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to aa0-10-continue-y-n. 
*   endif 
 
*   (delete print file) 
*    expunge     print-file. 
    open output print-file. 
 
    move zero				to	key-batctrl-file. 
 
*mf    read batch-ctrl-file key is key-gen-batctrl-file approximate 
*mf      invalid key 
*mf	move 4				to	err-ind 
*mf	perform za0-common-error	thru	za0-99-exit 
*mf	go to az0-end-of-job. 
 
    start batch-ctrl-file key is greater than or equal to key-batctrl-file 
      invalid key 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
    read batch-ctrl-file next.
    
    add 1				to	ctr-batctrl-file-reads. 
 
    perform xc0-read-const-mstr		thru	xc0-99-exit. 
 
    perform xa0-save-clinic-info	thru	xa0-99-exit. 
 
    perform ad0-sel-read-batch-ctrl-file thru	ad0-99-exit. 
 
    if eof-batctrl-file = "Y" 
    then 
	move 5				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close batch-ctrl-file 
	  iconst-mstr. 
 
az0-10-end-of-job. 
 
    close print-file. 
 
    display blank-screen. 
    accept sys-time			from time. 
 
    display scr-closing-screen. 
    if err-ctr > zero 
    then 
	display scr-closing-screen-err-display. 
*   (else) 
*   endif 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
*   (if break in clinic then print clinic totals) 
 
    if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr 
*   and hold-clinic-nbr = 22 
* 2004/03/18 - MC
*    and (hold-clinic-nbr = 22 or 
     and (hold-clinic-nbr < 60   or
* 2004/03/18 - end
* 2007/04/19 - MC - consider 60's & 70's clinic
*         batctrl-bat-clinic-nbr-1-2 > 65) 
          batctrl-bat-clinic-nbr-1-2 > 75   or
* 2010/03/24 - MC1 - include clinic 66
*         (hold-clinic-nbr >= 60 and hold-clinic-nbr <= 70 and batctrl-bat-clinic-nbr-1-2 > 65) or
         (hold-clinic-nbr >= 60 and hold-clinic-nbr <= 70 and batctrl-bat-clinic-nbr-1-2 > 66) or
* 2010/03/24 - end
         (hold-clinic-nbr >= 70 and batctrl-bat-clinic-nbr-1-2 > 75)
	) 
* 2007/04/19 - end
    then 
	perform ab1-print-clinic-totals	thru	ab1-99-exit 
	perform ac0-build-sums		thru	ac0-99-exit 
    else 
	perform ac0-build-sums		thru	ac0-99-exit. 
*   endif 
 
    perform xb0-read-next-batch		thru	xb0-99-exit. 
 
    perform ad0-sel-read-batch-ctrl-file 
					thru	ad0-99-exit. 
 
    if eof-batctrl-file = "Y" 
    then 
	perform ab1-print-clinic-totals	thru	ab1-99-exit 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
ab1-print-clinic-totals. 
 
    perform ag0-sum-agent-totals 		thru	ag0-99-exit 
	varying agent 
	from 1 by 1 
	until   agent > 10. 
 
    perform af0-print-headings			thru	af0-99-exit. 
 
    perform ah0-print-detail-lines		thru	ah0-99-exit 
	varying agent 
	from 1 by 1 
	until agent > 10. 
 
    perform ai0-print-totals			thru	ai0-99-exit. 
 
    move zero					to	agent-table 
							totals-table. 
 
    if eof-batctrl-file not = 'Y' 
    then 
	perform xa0-save-clinic-info		thru	xa0-99-exit. 
*   (else) 
*   endif 
 
ab1-99-exit. 
    exit. 
 
ac0-build-sums. 
 
    move batctrl-agent-cd			to	agent. 
 
*    (ohip is agent '0' so use agent+1 as subscript to table) 
    add 1					to	agent. 
 
    move zero					to	ss-adj-type. 
*     (claim batch or 'BILLINGS' if adjustment code blank or zero) 
    if batctrl-adj-cd =    " " 
			or "0" 
    then 
	move 1					to	ss-adj-type 
    else 
	perform ac1-determine-adj-pay-category	thru	ac1-99-exit 
	if ss-adj-type = zero 
	then 
*	    (error in code found) 
	    go to ac0-99-exit 
	else 
	    next sentence. 
*	endif 
*   endif 
 
 
*	 (note: 1-- 'M' is to appear under 'CASH' column as well as 'MISC') 
*	 (note: 2 --'M' and 'C' are stored as negative amts but are to print as positive) 
 
*	(add to current totals if batch is 'BALANCED') 
    if   batctrl-batch-status = "1" 
      or batctrl-batch-status = "2" 
    then 
	if   batctrl-adj-cd = "R" 
	then 
	    add     batctrl-calc-tot-rev	to	current-sums (agent,ss-adj-type) 
	else 
	    if batctrl-adj-cd = "M" 
	    then 
		add batctrl-calc-tot-rev			to	current-sums (agent,ss-adj-type) 
								current-sums (agent,ss-cash)          
	    else 
		if batctrl-adj-cd = "C" 
		then 
		    subtract batctrl-manual-pay-tot	from	zero 
							giving	ws-temp-sum 
		    add ws-temp-sum			to	current-sums (agent,ss-adj-type) 
		else 
		    add batctrl-calc-ar-due		to	current-sums (agent,ss-adj-type) 
*		endif 
*	    endif 
*	endif 
    else 
	next sentence. 
*   endif 
 
*	(add to m.t.d. totals if batch is not "UNBALANCED) 
    if batctrl-batch-status not = "0"  
    then 
	if batctrl-adj-cd = "R" 
	then 
	    add     batctrl-calc-tot-rev	to	mtd-sums (agent,ss-adj-type) 
	else 
	    if batctrl-adj-cd = "M" 
	    then 
		add batctrl-calc-tot-rev		to	mtd-sums (agent,ss-adj-type) 
							mtd-sums (agent,ss-cash)          
	    else 
		if batctrl-adj-cd = "C" 
		then 
		    subtract batctrl-manual-pay-tot	from	zero 
							giving	ws-temp-sum 
		    add ws-temp-sum			to	mtd-sums (agent,ss-adj-type) 
		else 
		    add batctrl-calc-ar-due		to	mtd-sums (agent,ss-adj-type)                          
*	        endif             
*	    endif 
*	endif 
    else 
	next sentence. 
*   endif 
 
ac0-99-exit. 
    exit. 
ac1-determine-adj-pay-category. 
 
    if batctrl-adj-cd = "M" 
    then 
	move 2						to	ss-adj-type 
    else 
	if batctrl-adj-cd = "B" 
	then 
	    move 3					to	ss-adj-type 
	else 
	    if batctrl-adj-cd = "R" 
	    then 
		move 4					to	ss-adj-type 
	    else 
		if batctrl-adj-cd = "A" 
		then 
		    move 5				to	ss-adj-type 
		else 
		    if batctrl-adj-cd = "C" 
		    then 
			move 6				to	ss-adj-type 
		    else 
* 			(error: non existant transaction code) 
			move zero			to	ss-adj-type 
			add 1				to	err-ctr 
			add batctrl-calc-ar-due		to	err-ctr-ar-due 
			add batctrl-calc-tot-rev	to	err-ctr-tot-rev. 
*		    endif 
*		endif 
*	    endif 
*	endif 
*    endif 
 
ac1-99-exit. 
    exit. 
ad0-sel-read-batch-ctrl-file. 
 
    if eof-batctrl-file = 'Y' 
    then 
	go to ad0-99-exit. 
*   (else) 
*   endif 
 
    if batctrl-bat-clinic-nbr-1-2 not = hold-clinic-nbr 
    then 
	perform xc0-read-const-mstr	thru xc0-99-exit. 
*   (else) 
*   endif 
 
*	(report only "THIS MONTH'S" batches whose status is "AT LEAST 'BALANCED'") 
    if    batctrl-batch-status	> "0" 
      and batctrl-date-period-end = iconst-date-period-end 
    then 
	next sentence 
    else 
	perform xb0-read-next-batch	thru	xb0-99-exit 
	if eof-batctrl-file = 'Y' 
	then 
	    go to ad0-99-exit 
	else 
	    go to ad0-sel-read-batch-ctrl-file. 
*	endif 
*   endif 
 
ad0-99-exit. 
    exit. 
af0-print-headings. 
 
    write print-record			from	h1-head after advancing page. 
    write print-record from h4-head after advancing 1 line. 
    write print-record from h5-head after advancing 2 lines. 
    write print-record from h2-head after advancing 2 lines. 
    write print-record from h3-head after advancing 1 line. 
 
af0-99-exit. 
    exit. 
ag0-sum-agent-totals. 
    perform ag1-add-totals		thru ag1-99-exit 
	varying ss-adj-type 
	from 1 by 1 
	until ss-adj-type > 6. 
 
ag0-99-exit. 
    exit. 
 
 
 
ag1-add-totals. 
 
    add current-sums (agent, ss-adj-type)	to	current-totals (ss-adj-type). 
    add mtd-sums (agent, ss-adj-type)		to	mtd-totals (ss-adj-type). 
 
ag1-99-exit. 
    exit. 
ah0-print-detail-lines. 
 
*    (are there any entries for agent?) 
    move 0				to	ws-total. 
    add mtd-sums (agent,1) 
	mtd-sums (agent,2) 
	mtd-sums (agent,3) 
	mtd-sums (agent,4) 
	mtd-sums (agent,5) 
	mtd-sums (agent,6)		to	ws-total. 
 
    if ws-total not = 0 
    then 
*	(there are non zero entries for agent) 
	compute ws-agent = agent - 1 
	move ws-agent			to 	l1-agent-cd 
    	perform ah1-cur-sums-to-prt-line thru ah1-99-exit 
	    varying ss-adj-type 
	    from 1 by 1 
	    until ss-adj-type > 5 
	move current-sums (agent,6)	to	l1-cash 
	move " CURRENT"			to	l1-period 
	write print-record		from	l1-print-line after advancing 2 lines 
	move spaces			to	l1-print-line 
	perform ah2-mtd-sums-to-prt-line thru ah2-99-exit 
	    varying ss-adj-type 
	    from 1 by 1 
	    until ss-adj-type > 5 
	move mtd-sums (agent,6)		to	l1-cash 
	move " M.T.D"			to	l1-period 
	write print-record from l1-print-line after advancing 1 line 
	move spaces			to	l1-print-line. 
 
ah0-99-exit. 
    exit. 
 
 
 
ah1-cur-sums-to-prt-line. 
 
    move current-sums (agent,ss-adj-type)	to	l1-amount (ss-adj-type). 
 
ah1-99-exit. 
    exit. 
 
 
 
ah2-mtd-sums-to-prt-line. 
 
    move mtd-sums (agent,ss-adj-type)		to	l1-amount (ss-adj-type). 
 
ah2-99-exit. 
    exit. 
ai0-print-totals. 
    move " TOTALS *"			to	l1-totals. 
    perform ai1-cur-ttl-to-prt-line	thru ai1-99-exit 
	varying ss-adj-type 
	from 1 by 1 
	until ss-adj-type > 5. 
    move current-totals (6)		to	l1-cash. 
    move " CURRENT"			to	l1-period. 
    write print-record 			from	l1-print-line after advancing 3 lines. 
    move spaces 			to	l1-print-line. 
 
    perform ai2-mtd-ttl-to-prt-line	thru ai2-99-exit 
	varying ss-adj-type 
	from 1 by 1 
	until ss-adj-type > 5. 
    move mtd-totals (6)			to	l1-cash. 
    move " M.T.D."			to	l1-period. 
    write print-record from l1-print-line after advancing 1 line. 
    move spaces				to	l1-print-line. 
 
ai0-99-exit. 
    exit. 
 
ai1-cur-ttl-to-prt-line. 
 
    move current-totals (ss-adj-type)		to	l1-amount (ss-adj-type). 
 
ai1-99-exit. 
    exit. 
 
ai2-mtd-ttl-to-prt-line. 
 
    move mtd-totals (ss-adj-type)		to	l1-amount (ss-adj-type). 
 
ai2-99-exit. 
    exit. 
xa0-save-clinic-info. 
 
    move batctrl-bat-clinic-nbr-1-2	to	hold-clinic-nbr. 
 
    move iconst-clinic-nbr-1-2		to	h1-clinic-nbr. 
    move iconst-clinic-name		to	h4-clinic-name. 
    move iconst-date-period-end-yy	to	h4-yy. 
    move iconst-date-period-end-mm	to	h4-mm. 
    move iconst-date-period-end-dd	to	h4-dd. 
    move iconst-clinic-cycle-nbr	to	h5-cycle-nbr. 
 
xa0-99-exit. 
    exit. 
xb0-read-next-batch. 
 
    read batch-ctrl-file next 
	at end 
	    move 'Y'			to	eof-batctrl-file 
	    go to xb0-99-exit. 
 
    add 1				to ctr-batctrl-file-reads. 
 
xb0-99-exit. 
    exit. 
xc0-read-const-mstr. 
 
    move batctrl-bat-clinic-nbr-1-2	to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 2			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
xc0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 