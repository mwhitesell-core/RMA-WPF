identification division. 
program-id. u035cnoupd.
author. dyad computer systems inc. 
installation. rma. 
date-written. 85/11. 
date-compiled. 
security. 
* 
*    files	: f002    - claims master 
*		:         - u035_sort_work_file 
*               : f010    - patient master 
*		: f020    - doctor master 
*		: f040    - oma fee mstr 
*		: f094    - msg sub mstr 
*		: ru035   - print file 
* 
* 
*    program purpose : to print the direct billing invoices 
*			this pgm is the third in a series of 3 pgms. 
*			it uses the sorted work file that is output 
*			by u035b to print the direct billing invoices. 
 
* 
*    date       programmer          modification 
*    ----       ----------          ------------ 
* 
*    84/12/19	i.warsh		    activity cs25 to use the 
*				    reference field date for direct 
*				    bills. 
* 
*    85/01	i.warsh		    removed the subscriber last stmnt 
*				    field being updated, now using only 
*				    the clmhdr reference field. cs25 
* 
*    85/04	i.warsh		    added code for the ikey 
* 
*    85/11	m. so		    pdr 285 
*				    use the sort work file that is 
*				    output by u035b as the sorted 
*				    claim shadow file for input. 
* 
*    87/05      s. blair          - conversion from aos to aos/vs. 
*                                   change field size for 
*                                   status clause to 2 and 
*                                   feedback clause to 4. 
* 
*    89/02      s. fader          - sms 113 
*                                 - add agent to sort and print agent 
*                                   control totals at break 
* 
*    89/03	m. chan		  - pdr 303 
*				    modify 'BC1-DETAIL-LOOP' subroutine 
*				    do not include the 'CLMDTL-ADJUST-REPRINT' 
*				    as part of condition for payment or 
*				    adjustment 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised oct/91:    - pdr 530 m.c. 
*		       - do not create statement for agent 4 and clmhdr 
*			 reprint flag = 'N' regardless of 30 days 
* 
*   revised aug/93:    - pdr 567 m.c. 
*		       - print country as part of the address 
* 
* 1999/jan/31 B.E.	- y2k
* 2003/dec/11 M.C.	- alpha doc nbr

environment division. 
input-output section. 
file-control. 
  
    select clm-shdw-work-mstr 
	assign to "u035_sort_work_mstr" 
	organization is sequential 
	file  status is status-cobol-clm-shadow-mstr. 
 
* 
    copy "f002_claims_mstr.slr". 
* 
    copy "f010_new_patient_mstr.slr". 
* 
    copy "f020_doctor_mstr.slr". 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
    copy "f094_msg_sub_mstr.slr". 
* 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
 
data division. 
file section. 
 
    copy "f002_claims_mstr.fd". 
* 
fd  clm-shdw-work-mstr 
*!    block contains 58 characters. 
    block contains 57 characters. 
 
01  wf-shadow-sort-key. 
    05  wf-shadow-agent                 pic 9. 
    05  wf-shadow-rec. 
        10  wf-shadow-key. 
	    15  wf-shadow-clinic		pic 99. 
	    15  wf-shadow-subdivision      	pic x. 
	    15  wf-shadow-pat-surname	pic x(15). 
	    15  wf-shadow-pat-giv-name	pic x(12). 
	    15  wf-shadow-patient. 
	        20  wf-shadow-pat-key-type	pic a. 
	        20  wf-shadow-pat-key-data. 
	    	    25  wf-shadow-pat-key-ohip  pic x(08). 
	    	    25  filler                  pic x(07). 
*!   	    15  wf-shadow-batch-nbr		pic 9(09). 
	    15  wf-shadow-batch-nbr		pic x(08). 
	    15  wf-shadow-claim-nbr		pic 9(02). 

    copy "f010_patient_mstr.fd". 
* 
    copy "f020_doctor_mstr.fd". 
* 
    copy "f040_oma_fee_mstr.fd". 
* 
    copy "f094_msg_sub_mstr.fd". 
fd  print-file 
    record contains 132 characters. 
 
01  prt-line    				pic x(132). 
* 
working-storage section. 
 
* 
*  file related working storage 
* 
 
77  pat-occur					pic 9999. 
77  hold-feedback-clmhdr			pic x(4). 
77  hold-key-claims-mstr			pic x(18). 
77  feedback-pat-mstr				pic x(4). 
77  feedback-claims-mstr			pic x(4). 
77  feedback-claims-mstr-p-access		pic x(4). 
77  feedback-oma-fee-mstr			pic x(4). 
77  claims-pat-access-occur			pic 9(12). 
77  claims-occur				pic 9(12). 
77  ws-pat-subscr-key				pic x(15). 
77  hold-pat-given-name				pic x(12). 
77  hold-pat-surname				pic x(15). 

01  temp-long-date.
    02 filler pic 9(2).
    02 temp-long-date-yymmdd pic 9(6).
 
01  hold-pat-ohip-mmyy-r			pic x(15). 
01  hold-subscr-info. 
    05  hold-subscr-addr1			pic x(21). 
    05  hold-subscr-addr2			pic x(21). 
    05  hold-subscr-addr3			pic x(21). 
    05  hold-subscr-postal-cd			pic x(6). 
    05  hold-subscr-postal-cd-r  redefines  hold-subscr-postal-cd. 
	10  hold-subscr-post-code1. 
	    15  hold-subscr-post-cd1		pic x. 
	    15  hold-subscr-post-cd2		pic 9. 
	    15  hold-subscr-post-cd3		pic x. 
	10  hold-subscr-post-code2. 
	    15  hold-subscr-post-cd4		pic 9. 
	    15  hold-subscr-post-cd5		pic x. 
	    15  hold-subscr-post-cd6		pic 9. 
    05  hold-country				pic x(20). 
    05  hold-subscr-msg-nbr			pic xx. 
* (y2k)
*   05  hold-subscr-date-msg-nbr-eff			pic 9(6). 
    05  hold-subscr-date-msg-nbr-eff		pic 9(8). 
 
*  eof flags 
 
77  eof-claims-mstr				pic x	value "N". 
77  eof-claims-mstr-pat-access			pic x	value "N". 
77  eof-patient-mstr				pic x	value "N". 
77  eof-doctor-mstr				pic x	value "N". 
77  eof-claims-dtl				pic x	value "N". 
 
*  	two print files are created for the printing of two invoice 
*	types using same format: 
*		1)	ru035ca - for clinics 22 and 60 
*		2)	ru035cb - for clinics 43 
 
77  prt-file-name-a			pic x(07)	value "ru035ca". 
77  prt-file-name-b			pic x(07)	value "ru035cb". 
 
01  print-file-name. 
    05  prt-file-name			pic x(07)	value spaces. 
 
 
*mf    copy "F002_KEY_CLAIMS_MSTR.WS". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
 
01  key-claims-mstr-pat-access. 
    05  key-clm-pat-access-type			pic a. 
    05  key-clm-pat-access-data. 
	10  key-clm-pat-access-pat-id		pic x(15). 
	10  filler				pic xx. 
 
01  key-gen-claims-mstr-pat-access. 
    05  key-gen-clm-pat-access			pic a. 
    05  key-gen-clm-pat-access-data		pic x(17). 
 
*  status file indicators 
 
01 status-indicators. 
*mf    05  common-status-file			pic x(11). 
    05  common-status-file			pic x(2). 
*mf    05  status-pat-mstr			pic x(11) value zero. 
*mf    05  status-doc-mstr			pic x(11) value zero. 
    05  status-cobol-doc-mstr			pic x(2) value zero. 
*mf    05  status-claims-mstr			pic x(11) value zero. 
    05  status-prt-file				pic xx    value zero. 
    05  status-cobol-claims-mstr		pic xx    value zero. 
    05  status-cobol-pat-mstr			pic xx	  value zero. 
    05  status-claims-mstr-pat-access		pic x(11) value zero. 
*mf    05  status-oma-mstr			pic x(11) value zero. 
    05  status-cobol-oma-mstr			pic x(2) value zero. 
 
    copy "f002_claim_shadow.fw". 
 
    copy "f094_msg_sub_mstr.fw". 
 
01 save-subscr-id 				pic x(15)	value spaces. 
 
01 save-shadow-key. 
    10  save-shadow-agent               pic 9. 
    10  save-shadow-clinic		pic 99. 
    10  save-shadow-subdivision      	pic x. 
    10  save-shadow-pat-surname      	pic x(15). 
    10  save-shadow-pat-giv-name     	pic x(12). 
    10  save-shadow-patient		pic x(16). 
*!  10  save-shadow-batch-nbr		pic x(09). 
    10  save-shadow-batch-nbr		pic x(08). 
    10  save-shadow-claim-nbr		pic x(02). 
 
* (y2k)
* 77  ws-oldest-stmnt-prt-dt              pic 9(6).
77  ws-oldest-stmnt-prt-dt              pic 9(8). 
* (y2k)
*77  ws-hold-clmref-date      			pic 9(6). 
77  ws-hold-clmref-date      		pic 9(8). 
* 
*    screen related working storage 
* 
 
77  ws-reply					pic x  value "P". 
77  err-ind					pic 99. 
77  ws-age-days					pic 99 value 30. 
 
* 
*	miscellaneous flags 
* 
 
01  process-flag      				pic x. 
    88  first-process				value 'Y'. 
 
01  flag-curr-activity				pic x. 
    88  curr-activity				value 'Y'. 
    88  no-curr-activity			value 'N'. 
 
01  flag-new-claim-payment			pic x. 
    88  new-claim-payment			value 'Y'. 
    88  no-new-claim-payment			value 'N'. 
 
01  flag-end-of-claim-details			pic x. 
    88  end-of-claim-details			value 'Y'. 
    88  not-end-of-claim-details		value 'N'. 
 
01  flag-invoice-to-print			pic x. 
    88  invoice-to-print			value 'Y'. 
    88  invoice-not-to-print			value 'N'. 
 
01  flag-claim-bal-due				pic x. 
    88  claim-has-bal-due			value 'Y'. 
    88  claim-has-no-bal-due			value 'N'. 
 
01  flag-claim-to-invoice			pic x. 
    88  claim-to-invoice			value 'Y'. 
    88  claim-not-to-invoice			value 'N'. 
 
01  flag-oma-rec				pic x. 
    88  oma-rec-found				value "Y". 
    88  oma-rec-not-found			value "N". 
 
01  flag-more-claims-to-come			pic x. 
    88  more-claims-to-come			value 'Y'. 
    88  no-more-claims-to-come			value 'N'. 
 
01  flag-invoice-overflow 			pic x. 
    88  invoice-overflow			value 'Y'. 
    88  no-invoice-overflow			value 'N'. 
 
* 
*	constants and literals 
* 
 
77  ws-premium					pic x(08) 
	value "PREMIUM". 
 
77  ws-bal-fwd-lit				pic x(47) 
	value "                              BALANCE FORWARD :". 
77  ws-payment-lit				pic x(47) 
	value "PAYMENT - THANK YOU                            ". 
77  ws-adjustment-lit				pic x(47) 
	value "ADJUSTMENT                                     ". 
77  ws-pay-reversal-lit 			pic x(47) 
	value "PAYMENT REVERSAL - EXPLANATION ENCLOSED        ". 
 
 
77  ws-cntrl-hdr-lit				pic x(15) 
	value "CONTROL TOTALS:". 
77  ws-cntrl-agent-lit				pic x(15) 
	value "AGENT --------:". 
77  ws-cntrl-clinic-lit				pic x(15) 
	value "CLINIC -------:". 
77  ws-cntrl-subdiv-lit				pic x(15) 
	value "SUBDIVISION --:". 
77  ws-cntrl-grand-lit 				pic x(15) 
	value "GRAND --------:". 
 
01  month-lits. 
    05  filler		pic x(03)	value "JAN". 
    05  filler		pic x(03)	value "FEB". 
    05  filler		pic x(03)	value "MAR". 
    05  filler		pic x(03)	value "APR". 
    05  filler		pic x(03)	value "MAY". 
    05  filler		pic x(03)	value "JUN". 
    05  filler		pic x(03)	value "JUL". 
    05  filler		pic x(03)	value "AUG". 
    05  filler		pic x(03)	value "SEP". 
    05  filler		pic x(03)	value "OCT". 
    05  filler		pic x(03)	value "NOV". 
    05  filler		pic x(03)	value "DEC". 
 
01  months redefines month-lits. 
    05  mth        	occurs 12 times	pic x(03). 
 
77  not-to-invoice-msg-nbr			pic xx	value '99'. 
77  ws-lines-per-page				pic 99  value 21. 
 
77  ss-subdiv					pic  9	value 1. 
77  ss-clinic					pic  9	value 2. 
77  ss-agent   		                        pic  9  value 3. 
77  ss-grand					pic  9	value 4. 
 
* 
*	misc working storage 
* 
 
77  ws-space					pic x  value spaces. 
77  ws-spaces                              	pic xx value spaces. 
77  ws-desc					pic x(47). 
01  ws-redefine					pic s9(05)v99. 
01  ws-redefined redefines ws-redefine		pic s9(07). 
77  ws-balance-due				pic 9(5)v99. 
77  ws-bal-fwd					pic s9(5)v99. 
77  ws-claim-bal-due				pic s9(5)v99. 
77  ws-tot-adj					pic s9(5)v99. 
77  ws-tot-pay					pic s9(5)v99. 
77  ws-prev-balance				pic s9(5)v99. 
77  ws-curr-charges				pic s9(5)v99. 
77  ws-cur					pic s9(5)v99. 
77  ws-30					pic s9(5)v99. 
77  ws-60					pic s9(5)v99. 
77  ws-90					pic s9(5)v99. 
77  ws-120					pic s9(5)v99. 
 
77  ws-remainder				pic s9(04). 
77  ws-quotient					pic s9(04). 
 
77  ws-page-cntr				pic 9(03). 
77  ws-line-cntr				pic 9(02). 
77  ws-nbr-lines				pic 9(03). 
77  ws-nbr-desc					pic 9(01). 
77  ws-nbr-pages				pic 9(03). 
77  ws-detail-lines				pic 9(3)v99. 
77  ws-lines-left				pic 99. 
77  ws-skip					pic 99. 
77  ws-msg-lines				pic 99. 
77  ws-msg-nbr					pic xx. 
01  ws-msg-dtls. 
    05  ws-msg1					pic x(47). 
    05  ws-msg2					pic x(47). 
    05  ws-msg3					pic x(47). 
    05  ws-msg4					pic x(47). 
 
*	break control totals 
 
01  break-control-table. 
    05  bc-totals occurs 4 times. 
        10  bc-bal-due		pic 9(06)v99. 
        10  bc-invoices		pic 9(04). 
        10  bc-claims		pic 9(05). 
 
77  inv-bal-due			pic 9(06)v99. 
77  inv-claims			pic 9(05). 
 
01  ws-surname				pic x(15). 
01  ws-surname-r redefines ws-surname. 
    05  ws-surname-char occurs 15 times	pic x. 
 
01  ws-full-name			pic x(21). 
01  ws-full-name-r redefines ws-full-name. 
    05  ws-full-name-char occurs 21 times pic x(01). 
 
01  summary-table. 
    05  summary-table-items occurs 99 times. 
        10  summary-print. 
* (y2k)
*	    15  sum-sv-date					pic 9(6). 
	    15  sum-sv-date				pic 9(8). 
	    15  sum-batch-nbr. 
	        20  filler				pic x(03). 
	        20  sum-btch-nbr			pic x(06). 
	    15  sum-claim-nbr				pic 99.	 
	    15  sum-bal-due				pic s9(5)v99. 
        10  summary-control. 
	    15  sum-reprint				pic x. 
 
*   reprint indicator status - 	(n)ot to reprint 
*                               (p)artial reprint (ie. payments & adjustments) 
*				(y)es reprint 
 
77  ws-summary-items				pic 99. 
 
* 
*	subscripts 
* 
 
77  ss-a   					pic 9(03). 
77  ss-b   					pic 9(03). 
77  ss-c					pic 9(02). 
77  ss-d					pic 9(02). 
 
 
77  ss-break-type				pic 9. 
77  ss-to					pic 9. 
* 
*	print lines 
* 
 
01 prt-name. 
    05  filler				pic x(10)	value spaces. 
    05  p-name 				pic x(28). 
    05  filler				pic x(94)	value spaces. 
   	 
01 prt-addr1. 
    05  filler				pic x(10)	value spaces. 
    05  p-addr1				pic x(21). 
    05  filler				pic x(101)	value spaces. 
   	 
01 prt-addr2. 
    05  filler				pic x(10)	value spaces. 
    05  p-addr2				pic x(21). 
    05  filler				pic x(101)	value spaces. 
   	 
01 prt-addr3. 
    05  filler				pic x(10)	value spaces. 
    05  p-addr3				pic x(21). 
    05  filler				pic x(101)	value spaces. 
   	 
01 prt-country. 
    05  filler				pic x(10)	value spaces. 
    05  p-country			pic x(30). 
    05  filler				pic x(92) 	value spaces. 
   	 
01 prt-hdr. 
    05  filler				pic x(10)	value spaces. 
    05 p-postal-cd. 
        10  p-code1			pic x(03). 
        10  filler			pic x(01). 
        10  p-code2			pic x(03). 
    05 p-postal-usa redefines p-postal-cd. 
        10  p-code-usa			pic x(05). 
        10  filler			pic x(02). 
    05  filler				pic x(51)	value spaces. 
    05  p-dtl-id			pic x(12). 
    05  filler				pic x(03)	value spaces. 
* (y2k)
    05  p-inv-yy				pic 9(02). 
    05  p-inv-yy-r redefines p-inv-yy.
	10 p-inv-yy-1 pic 9(1).
	10 p-inv-yy-2 pic 9(1).
**  05  p-inv-yy			pic 9(04). 
    05  filler				pic x(01)	value spaces. 
    05  p-inv-mmm			pic x(03). 
    05  filler				pic x(01)	value spaces. 
    05  p-inv-dd			pic 9(02). 
    05  filler				pic x(01)	value spaces. 
    05  p-page				pic z(02). 
    05  filler				pic x(02)	value spaces. 
    05  p-pages                         pic z(02). 
    05  filler				pic x(03)	value spaces. 
* (y2k)
   05  p-inv-date				pic 9(06). 
   05  p-inv-date-r redefines p-inv-date.
	10 p-inv-date-y1 pic 9(1).
	10 p-inv-date-y2 pic 9(1).
	10 p-inv-date-mm pic 9(2).
	10 p-inv-date-dd pic 9(2).
*** 05  p-inv-date			pic 9(08). 
    05  filler				pic x(03)	value spaces. 
    05  p-sum-id			pic x(12). 
    05  filler				pic x(09)	value spaces. 
   	 
01  prt-dtl. 
    05  filler				pic x(01)	value spaces. 
* (y2k)
*   05  p-dtl-srv-date				pic 9(06) blank when zero. 
*   05  p-dtl-srv-date			pic 9(08) 	blank when zero. 
    05  p-dtl-srv-date			pic 9(06) 	blank when zero. 
    05  p-nbr-srv			pic z(02)	blank when zero. 
    05  filler				pic x(01)	value spaces. 
    05  p-dtl-btch-nbr			pic x(06). 
    05  p-dtl-clm-nbr			pic x(02). 
    05  filler				pic x(01)	value spaces. 
    05  p-ohip-cd			pic x(04). 
    05  p-ohip-suff			pic x(01). 
    05  filler				pic x(01)	value spaces. 
    05  p-doc				pic x(09). 
    05  filler				pic x(01) 	value spaces. 
    05  p-loc				pic x(01). 
    05  filler				pic x(01) 	value spaces. 
    05  p-desc. 
    	10  p-desc-l			pic x(23). 
	10  p-desc-r			pic x(24). 
    05  filler				pic x(01)	value spaces. 
    05  p-dtl-charge			pic z(07)    	blank when zero. 
    05  filler				pic x(01) 	value spaces. 
    05  p-credits			pic z(07)   	blank when zero. 
    05  filler				pic x(02)	value spaces. 
    05  p-summary. 
* (y2k)
        10  p-sum-srv-date		pic 9(06) 	blank when zero.
***     10  p-sum-srv-date		pic 9(08) 	blank when zero. 
        10  filler			pic x(01) 	value spaces. 
        10  p-sum-btch-nbr		pic x(06). 
        10  p-sum-clm-nbr		pic x(02). 
        10  filler			pic x(01)	value spaces. 
        10  p-sum-charge		pic z(05).99. 
        10  filler			pic x(06)	value spaces. 
 
01  prt-tot1. 
    05  filler				pic x(46)	value spaces. 
    05  p-prev-bal			pic z(05).99. 
    05  filler				pic x(01)	value spaces. 
    05  p-curr-char			pic z(05).99. 
    05  filler				pic x(01) 	value spaces. 
    05  p-payments			pic z(05).99. 
    05  filler				pic x(01)	value spaces. 
    05  p-adjustments			pic z(05).99-. 
    05  filler				pic x(05)	value spaces. 
    05  p-dtl-bal-due			pic z(05).99. 
    05  filler				pic x(11)	value spaces. 
    05  p-sum-bal-due			pic z(05).99. 
    05  filler				pic x(18)	value spaces. 
 
01  prt-tot2. 
    05  filler				pic x(37)	value spaces. 
    05  p-curr				pic z(05).99. 
    05  filler				pic x(01)	value spaces. 
    05  p-30  				pic z(05).99. 
    05  filler				pic x(01) 	value spaces. 
    05  p-60   				pic z(05).99. 
    05  filler				pic x(01)	value spaces. 
    05  p-90  				pic z(05).99. 
    05  filler				pic x(01)	value spaces. 
    05  p-120        			pic z(05).99. 
    05  filler				pic x(51)	value spaces. 
 
01  prt-blanks. 
    05  filler				pic x(132)	value spaces. 
 
01  prt-cntrl-hdr. 
    05  filler				pic x(40)	value spaces. 
    05  p-cntrl-lit			pic x(15). 
    05  filler				pic x(01)	value spaces. 
    05  p-cntrl-id			pic x(02). 
    05  filler				pic x(74)	value spaces. 
 
01  prt-cntrl-col. 
    05  filler				pic x(40)	value spaces. 
    05  filler				pic x(40) 
	value "BALANCE DUE       CLAIMS        INVOICES". 
    05  filler				pic x(52)	value spaces. 
 
01  prt-cntrl-dtl. 
    05  filler				pic x(40)	value spaces. 
    05  p-bal-due			pic z(06).99. 
    05  filler				pic x(09)	value spaces. 
    05  p-nbr-claims			pic zzzz9. 
    05  filler				pic x(11)	value spaces. 
    05  p-nbr-invoices			pic zzz9. 
    05  filler				pic x(54)	value spaces. 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		" ". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 01 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
    copy "sysdatetime.ws". 
 
01  age-date. 
* (y2k)
*   05  age-yy					pic 99. 
    05  age-yy					pic 9(4). 
    05  age-mm					pic 99. 
    05  age-dd					pic 99. 
 
01  claim-date. 
* (y2k)
*   05  claim-yy				pic 99. 
    05  claim-yy				pic 9(4). 
    05  claim-mm				pic 99. 
    05  claim-dd				pic 99. 
 
* (y2k)
*01  claim-days					pic 9(7)v99. 
01  claim-days					pic 9(9)v99. 
*01  run-days					pic 9(7)v99. 
01  run-days					pic 9(9)v99. 
 
copy "mth_desc_max_days.ws". 
 
screen section. 
 
01  scr-title. 
    05  blank screen.
    05  line 07 col 29 value "DIRECT BILLS INVOICING". 
    05  line 10 col 22 value "ENTER DAYS AGED FOR RE-INVOICING: ". 
    05  line 10 col 56 pic z9 using ws-age-days auto. 
    05  line 12 col 23 value "C)HANGE DAYS, P)ROCEED OR E)XIT:". 
    05  line 12 col 56 pic x  using ws-reply. 
 
01 file-status-display. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf 05  line 24 col 70	pic x(11) from common-status-file	bell blink. 
    05  line 24 col 70	pic x(2) from common-status-file	bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	from err-msg-comment. 
 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
 
01  program-in-progress. 
    05  line 16 col 28 value "PROGRAM U035C IN PROGRESS". 
 
01  scr-closing-screen. 
    05  line 21 col 20	value "PROGRAM U035C ENDING". 
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
    05  line 23 col 20	value "PRINT REPORTS ARE IN FILES RU035CA & RU035CB". 
 
procedure division. 
declaratives. 
 
err-claims-mstr-file section. 
    use after standard error procedure on claims-mstr. 
 
err-claims-mstr. 
*mf move status-claims-mstr		to	common-status-file. 
    move status-cobol-claims-mstr	to	common-status-file. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
    stop run. 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*mf move status-pat-mstr		to	common-status-file. 
    move status-cobol-pat-mstr		to	common-status-file. 
    stop "ERROR IN ACCESSING PATIENT MASTER". 
 
err-doc-mstr-file section. 
    use after standard error procedure on doc-mstr. 
err-doc-mstr. 
*mf move status-doc-mstr		to common-status-file. 
    move status-cobol-doc-mstr		to common-status-file. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
err-oma-fee-mstr-file section. 
    use after standard error procedure on oma-fee-mstr. 
err-oma-fee-mstr. 
*mf move status-oma-mstr		to common-status-file. 
    move status-cobol-oma-mstr		to common-status-file. 
    stop "ERROR IN ACCESSING OMA FEE MASTER". 
 
err-msg-sub-mstr-file section. 
    use after standard error procedure on msg-sub-mstr. 
err-msg-sub-mstr. 
    move status-cobol-msg-sub-mstr		to common-status-file. 
    stop "ERROR IN ACCESSING MSG SUB MASTER". 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit 
	until eof-clm-shadow-mstr. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm. 
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    multiply run-yy by 365 		giving run-days. 
    add nbr-julian-days-ytd(run-mm) 	to run-days. 
    compute run-days = run-days - 
                       ( max-nbr-days(run-mm) - run-dd ). 
 
    accept sys-time 			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
*   display scr-title. 
 
aa0-input. 
 
*   accept scr-title. 
 
move 'P'                                 to ws-reply 
 
    if ws-reply = 'P' 
    then 
	next sentence 
    else 
	if ws-reply = 'E' 
	then 
	    stop run 
	else 
	    go to aa0-input. 
*   endif 
 
*   calculate date used for re-invoicing inactive unpaid bills 
 
* (y2k)
    move sys-date		to age-date. 
    perform aa1-calc-age-date	thru aa1-99-exit 
				until ws-age-days = zero. 
 
    open	input	clm-shdw-work-mstr 
			pat-mstr 
			doc-mstr 
			oma-fee-mstr 
			msg-sub-mstr. 
    open 	i-o	claims-mstr. 
 
    move prt-file-name-b   		to print-file-name. 
*    expunge print-file. 
    move prt-file-name-a		to print-file-name. 
*    expunge print-file. 
    open output print-file. 
 
    move zero				to break-control-table 
					   doc-nbr. 
    move 'N'				to flag-eof-clm-shadow-mstr. 
    move 'Y'                            to process-flag. 
 
    perform ga0-get-next-claim		thru ga0-99-exit. 
 
    if not-eof-clm-shadow-mstr 
    then 
	perform ca0-init-subscr		thru ca0-99-exit. 
*    endif 
 
aa0-99-exit. 
    exit. 
aa1-calc-age-date. 
 
    if ws-age-days not < age-dd 
    then 
	subtract age-dd 		from ws-age-days 
	perform aa11-reduc-mm		thru aa11-99-exit 
	if age-mm = 9 or 4 or 6 or 11 
	then 
	    move 30			to age-dd 
	else 
	    if age-mm = 2 
	    then 
		move 28			to age-dd 
	    else 
		move 31			to age-dd 
    else 
    	subtract ws-age-days 		from age-dd 
	move zero			to ws-age-days. 
*   endif 
 
aa1-99-exit. 
 
    exit. 
 
aa11-reduc-mm. 
 
    if age-mm = 1 
    then 
	move 12 			to age-mm 
	subtract 1			from age-yy 
    else 
	subtract 1			from age-mm. 
*   endif 
 
aa11-99-exit. 
 
    exit. 
 
az0-end-of-job. 
 
    perform gc0-patient-processing	thru gc0-99-exit. 
    perform ba0-print-invoice		thru ba0-99-exit. 
    perform da0-subdiv-break		thru da0-99-exit. 
    perform ea0-clinic-break. 
    perform ha0-agent-break             thru ha0-99-exit. 
 
    move ss-grand			to ss-break-type. 
    perform xb0-print-controls		thru xb0-99-exit. 
 
    close claims-mstr 
	  clm-shdw-work-mstr 
	  pat-mstr 
	  doc-mstr 
	  oma-fee-mstr 
	  msg-sub-mstr 
	  print-file. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
ab0-processing. 
 
*   	read current claim to process 
 
*mf    move 'B'				to key-clm-key-type. 
*mf    move zero			to key-clm-data. 
*mf    move wf-shadow-batch-nbr		to key-clm-batch-num. 
*mf    move wf-shadow-claim-nbr		to key-clm-claim-nbr. 
    move 'B'				to clmdtl-b-key-type. 
    move zero				to clmdtl-b-data. 
    move wf-shadow-batch-nbr		to clmdtl-b-batch-num. 
    move wf-shadow-claim-nbr		to clmdtl-b-claim-nbr. 
 
    perform ya0-read-claim-header		thru ya0-99-exit. 
 
* 	calculate claims balance due 
 
    add clmhdr-tot-claim-ar-oma,clmhdr-manual-and-tape-paymnts 
	giving ws-claim-bal-due. 
 
    if ws-claim-bal-due > .64 
    then 
	move 'Y' 				to flag-claim-bal-due 
    else 
	move 'N'				to flag-claim-bal-due. 
*   endif 
 
*   	process control breaks 
 
    if wf-shadow-agent not = save-shadow-agent 
    then 
	perform ba0-print-invoice    		thru ba0-99-exit 
	perform da0-subdiv-break		thru da0-99-exit 
	perform ea0-clinic-break		thru ea0-99-exit 
        perform ha0-agent-break                 thru ha0-99-exit 
	perform ca0-init-subscr			thru ca0-99-exit 
    else 
        if wf-shadow-clinic not = save-shadow-clinic 
        then 
	    perform ba0-print-invoice           thru ba0-99-exit 
	    perform da0-subdiv-break		thru da0-99-exit 
	    perform ea0-clinic-break		thru ea0-99-exit 
	    perform ca0-init-subscr		thru ca0-99-exit 
        else 
	    if wf-shadow-subdivision not = save-shadow-subdivision 
	    then 
	        perform ba0-print-invoice	thru ba0-99-exit 
	        perform da0-subdiv-break	thru da0-99-exit 
	        perform ca0-init-subscr		thru ca0-99-exit 
	    else 
	        if wf-shadow-patient not = save-shadow-patient 
	           or invoice-overflow 
	        then 
		    perform ba0-print-invoice	thru ba0-99-exit 
		   perform ca0-init-subscr	thru ca0-99-exit. 
*   endif 
 
    perform fa0-process-claim			thru fa0-99-exit. 
 
    perform ga0-get-next-claim			thru ga0-99-exit. 
 
ab0-99-exit. 
 
    exit. 
ba0-print-invoice. 
 
*	don'T PRINT INVOICES IF THERE WERE NO CURRENT CLAIMS 
*   	with balance due or aged 
 
    if invoice-not-to-print 
    then 
 	go to ba0-99-exit. 
*   endif 
 
    subtract 1 					from ss-a. 
    add 1 				to bc-invoices(ss-subdiv). 
 
*	calculate nbr pages required to print invoice 
 
    if ss-a > ws-detail-lines 
    then 
	move ss-a				to ws-nbr-lines 
    else 
	move ws-detail-lines			to ws-nbr-lines. 
*   endif 
 
    divide ws-nbr-lines by ws-lines-per-page 
	giving ws-nbr-pages remainder ws-remainder. 
 
    if ws-remainder not = zero 
    then 
	add ws-nbr-pages, 1			giving ws-nbr-pages. 
*   endif 
 
    move ws-nbr-pages			to p-pages. 
 
*	calculations 
 
    add ws-prev-balance, 
        ws-curr-charges			giving ws-balance-due. 
 
    compute ws-bal-fwd = ws-balance-due - ws-curr-charges 
                         - ws-tot-pay - ws-tot-adj. 
 
*	print heading lines 
 
    move zero 				to ws-page-cntr. 
 
    perform bb0-inv-header		thru bb0-99-exit. 
 
* 
*	the following pointers will be used to track the printing 
*	of the left (detail) and right (summary) sides of the 
*	invoice from the summary table. 
* 
*	ss-a	- left 
*	ss-b	- right 
* 
 
    move ss-a 				to ws-summary-items. 
    move 1 				to ss-a 
					   ss-b. 
 
    perform bc0-print-detail		thru bc0-99-exit 
	until ss-a > ws-summary-items. 
 
*	print subscr message 
 
    move spaces				to prt-dtl. 
    if ws-msg1 not = spaces 
    then 
	move ws-msg1			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if ws-msg2 not = spaces 
    then 
	move ws-msg2			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if ws-msg3 not = spaces 
    then 
	move ws-msg3			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if ws-msg4 not = spaces 
    then 
	move ws-msg4			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
 
*	print any remaining right side summary lines 
 
    move spaces				to prt-dtl. 
 
    perform bd0-summary-and-print	thru bd0-99-exit 
	until ss-b > ws-summary-items. 
 
*	print total lines 
 
    add ws-line-cntr,2			giving ws-line-cntr. 
 
    move ws-bal-fwd     		to p-prev-bal. 
    move ws-curr-charges		to p-curr-char. 
    move ws-tot-pay			to p-payments. 
    move ws-tot-adj			to p-adjustments. 
 
    move ws-balance-due			to p-dtl-bal-due 
					   p-sum-bal-due. 
 
    write prt-line from prt-tot1 after advancing ws-line-cntr. 
 
    move ws-cur				to p-curr. 
    move ws-30				to p-30. 
    move ws-60				to p-60. 
    move ws-90				to p-90. 
    move ws-120				to p-120. 
 
    write prt-line from prt-tot2 after 2. 
 
    add inv-claims			to bc-claims(ss-subdiv). 
    add inv-bal-due			to bc-bal-due(ss-subdiv). 
 
ba0-99-exit. 
 
    exit. 
 
bb0-inv-header. 
 
    move 7				to ws-skip. 
 
    if p-addr1 = spaces 
    then 
    	add 1				to ws-skip. 
*   endif 
    if p-addr2 = spaces 
    then 
	add 1				to ws-skip. 
*   endif 
    if p-addr3 = spaces 
    then 
	add 1 				to ws-skip. 
*   endif 
 
    write prt-line from prt-blanks after page. 
    write prt-line from prt-name after ws-skip lines. 
    if p-addr1 not = spaces 
    then 
	write prt-line from prt-addr1. 
*   endif 
    if p-addr2 not = spaces 
    then 
	write prt-line from prt-addr2. 
*   endif 
    if p-addr3 not = spaces 
    then 
	write prt-line from prt-addr3. 
*   endif 
 
    add 1			to ws-page-cntr. 
    move ws-page-cntr		to p-page. 
    write prt-line from prt-hdr. 
 
    write prt-line from prt-country. 
 
*	print balance forward on top of first page 
 
    if ws-page-cntr not = 1 
    then 
	write prt-line from prt-blanks after 2 
	move 21 			to ws-line-cntr 
    else 
	move 19 			to ws-line-cntr 
	if ws-bal-fwd = zero 
	then 
*	    write prt-line from prt-blanks after 4 
	    write prt-line from prt-blanks after 3 
	else 
  	    move spaces			to prt-dtl 
	    move ws-bal-fwd-lit 	to p-desc 
	    move ws-bal-fwd		to ws-redefine 
	    move ws-redefined		to p-dtl-charge 
*    	    write prt-line from prt-dtl after 3 
	    write prt-line from prt-dtl after 2 
	    write prt-line from prt-blanks. 
*   endif 
 
bb0-99-exit. 
 
    exit. 
 
bc0-print-detail. 
 
*mf    move 'B' 			to key-clm-key-type. 
*mf    move zero			to key-clm-data. 
*mf    move sum-batch-nbr(ss-a)		to key-clm-batch-num. 
*mf    move sum-claim-nbr(ss-a)		to key-clm-claim-nbr 
    move 'B' 				to clmdtl-b-key-type. 
    move zero				to clmdtl-b-data. 
    move sum-batch-nbr(ss-a)		to clmdtl-b-batch-num. 
    move sum-claim-nbr(ss-a)		to clmdtl-b-claim-nbr 
 
    perform ya0-read-claim-header	thru ya0-99-exit. 
 
*	update claim header 
 
    if (clmhdr-reprint-flag = 'Y') or 
       (clmhdr-auto-logout  = 'Y') or 
       (new-claim-payment) 
    then 
       perform fe0-claim-header-update 	thru fe0-99-exit. 
*   endif 
 
*	skip claims not to reprint in detail 
    if sum-reprint(ss-a) = 'N' 
    then 
	go to bc0-90-exit. 
*   endif 
 
    move 'N'				to flag-end-of-claim-details 
					   flag-new-claim-payment. 
 
    move zero				to ws-nbr-desc. 
 
    perform ya1-read-claim-detail-next	thru ya1-99-exit. 
 
*	print claim details 
 
    perform bc1-detail-loop		thru bc1-99-exit 
	until end-of-claim-details. 
 
*	print odd desc record 
 
    if sum-reprint(ss-a) = 'Y' 
    then 
        divide ws-nbr-desc by 2 giving ws-quotient remainder ws-remainder 
        if ws-remainder not = zero 
        then 
	    perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
 
*	print claim message 
 
    if clmhdr-msg-nbr not = zero 
       and sum-reprint(ss-a) = 'Y' 
    then 
	perform bc2-print-clm-msg	thru bc2-99-exit. 
*   endif 
 
bc0-90-exit. 
 
    add 1				to ss-a. 
 
bc0-99-exit. 
 
    exit. 
 
bc1-detail-loop. 
 
*	print according to record type 
 
*       if payment or adjustment and claim detail record has never 
*       been printed yet. 
 
    if ( clmdtl-adj-cd = 'A' or 'B' or 'C' ) 
*       and ( clmdtl-adjust-reprint not = 'Y' ) - 89/03/10 by m.c 
	and clmdtl-oma-cd not = 'ZZZZ' 
    then 
	perform bc10-payment-adjustment	thru bc10-99-exit 
    else 
 
*       if clmjdr-report-flag = "Y" then sum-reprint (ss-a) will also be 
*       set to "Y", these flags are set in 'FCO' subroutine 
 
	if sum-reprint(ss-a) = 'Y' 
	then 
	    if clmdtl-oma-cd = 'ZZZZ' 
	    then 
		perform bc11-description	thru bc11-99-exit 
	    else 
		perform bc12-detail		thru bc12-99-exit. 
*	    endif 
*	endif 
*   endif 
 
    perform ya1-read-claim-detail-next		thru ya1-99-exit. 
 
bc1-99-exit. 
 
    exit. 
 
bc10-payment-adjustment. 
 
    move spaces 			to prt-dtl. 
    perform be0-build-common		thru be0-99-exit. 
*** move clmhdr-date-sys 		to p-dtl-srv-date. 
    move clmhdr-date-sys to temp-long-date.
    move temp-long-date-yymmdd          to p-dtl-srv-date.


 
    if clmdtl-adj-cd = 'C' and clmdtl-fee-oma < zero 
    then 
	move ws-payment-lit		to p-desc 
	move clmdtl-fee-oma		to ws-redefine 
    	move ws-redefined    		to p-credits 
	move 'Y'			to flag-new-claim-payment 
    else 
        if clmdtl-adj-cd = 'C' 
        then 
	    move ws-pay-reversal-lit	to p-desc 
	    move clmdtl-fee-oma		to ws-redefine 
    	    move ws-redefined    	to p-dtl-charge 
	    move 'Y'			to flag-new-claim-payment 
        else 
	    move ws-adjustment-lit	to p-desc 
	    if clmdtl-fee-oma  < zero 
	    then 
	        move clmdtl-fee-oma 	to ws-redefine 
	        move ws-redefined   	to p-credits 
	    else 
	        move clmdtl-fee-oma 	to ws-redefine 
	        move ws-redefined		to p-dtl-charge. 
*   endif 
 
    perform bd0-summary-and-print	thru bd0-99-exit. 
 
*	flag payment and adjustments that have been printed in detail 
 
    if clmdtl-adjust-reprint not = 'Y' 
    then 
    	move 'Y'			to clmdtl-adjust-reprint 
    	perform ya3-rewrite-clmdtl	thru ya3-99-exit. 
*   endif 
 
 
bc10-99-exit. 
 
    exit. 
 
bc11-description. 
 
*	print two desc per detail line 
 
    add 1				to ws-nbr-desc. 
    divide ws-nbr-desc by 2 giving ws-quotient remainder ws-remainder. 
 
    if ws-remainder = 0 
    then 
	move clmdtl-desc		to  p-desc-r 
	perform bd0-summary-and-print thru bd0-99-exit 
    else 
	move spaces			to prt-dtl 
	move clmdtl-desc		to p-desc-l. 
*   endif 
 
bc11-99-exit. 
 
    exit. 
 
bc12-detail. 
 
    move spaces				to prt-dtl. 
    perform be0-build-common		thru be0-99-exit. 
 
    move clmdtl-oma-cd			to fee-oma-cd. 
    perform yf0-read-oma-fee-mstr	thru yf0-99-exit. 
  
* 	full desc or ( generic based on oma icc code ) 
 
    if clmhdr-fee-complex = 'H' 
    then 
	move fee-desc			to p-desc 
    else 
	perform bc120-icc-desc		thru bc120-99-exit. 
*   endif 
 
    move clmdtl-fee-oma 		to ws-redefine. 
    move ws-redefined    		to p-dtl-charge. 
 
    perform bd0-summary-and-print	thru bd0-99-exit. 
 
bc12-99-exit. 
 
    exit. 
 
bc120-icc-desc. 
 
*	the following hard coded low level descriptions should not 
*	exceed 39 characters to allow room for appending the 
*	literal " PREMIUM"  to add on code occurences 
 
    move clmdtl-oma-cd			to fee-oma-cd. 
    perform yf0-read-oma-fee-mstr	thru yf0-99-exit. 
 
    if oma-rec-not-found 
    then 
	move spaces 			to p-desc 
    else 
	if (fee-icc-sec = 'NM' 
		       or 'PF' 
		       or 'DR' 
		       or 'DU') 
	or ((clmdtl-oma-suff = 'A') 
	     and (fee-icc-sec = 'CP' or 'DT')) 
	then 
	    move 'PROCEDURE'		to p-desc 
	else 
	    if (clmdtl-oma-suff = 'C') 
	    and (fee-icc-sec = 'CP'	 
			    or 'DT' 
			    or 'SP') 
            then 
		move 'ANAESTHESIA'	to p-desc 
	    else 
		if (clmdtl-oma-suff = 'B') 
		and (fee-icc-sec = 'SP') 
		then 
		    move 'ASSISTING' 		to p-desc 
		else 
		    if (fee-icc-code = 'SP0440') 
		    and (clmdtl-oma-suff = 'A') 
		    then 
			move 'OBSTETRICS'	to p-desc 
		    else 
			if (fee-icc-sec = 'SP') 
		        and (clmdtl-oma-suff = 'A') 
			then 
			    move 'SURGICAL PROCEDURE'	to p-desc 
			else 
			    if fee-icc-sec = 'LM' 
			    then 
				move 'LAB WORK'		to p-desc 
			    else	 
				if fee-icc-sec = 'CV' 
				then 
				    move 'VISITS'	to p-desc 
				else 
				    move spaces		to p-desc. 
*   endif 
 
* 	modify descriptions for add on codes 
 
*	(this code cannot be implemented until d001 has been modified 
*	to allow add on codes based on icc group in the pricing 
*	procedure, it must be tested before going into production, 
* 	the temporary fix for low level descriptions should be 
*	removed) 
 
*    if (fee-icc-grp = '99'  or 
*        fee-icc-grp = '98') and 
*       (p-desc not = spaces) 
*    then 
*	perform bf0-premium-desc		thru bf0-99-exit. 
*   endif 
 
*   	temporary fix for low level descriptions 
 
    if fee-oma-cd = "H110" or "H106" 
    then 
 	move "OFF HOUR VISIT PREMIUM" 		to p-desc. 
*   endif 
 
bc120-99-exit. 
 
    exit. 
 
bc2-print-clm-msg. 
 
    move spaces 			to prt-dtl. 
 
    move msg-indexer			to msg-sub-key-1. 
    move clmhdr-msg-nbr			to msg-sub-key-23. 
 
    perform yg0-read-msg-sub-mstr	thru yg0-99-exit. 
 
    if msg-dtl1 not = spaces 
    then 
	move msg-dtl1			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if msg-dtl2 not = spaces 
    then 
	move msg-dtl2			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if msg-dtl3 not = spaces 
    then 
	move msg-dtl3			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
    if msg-dtl4 not = spaces 
    then 
	move msg-dtl4			to p-desc 
	perform bd0-summary-and-print	thru bd0-99-exit. 
*   endif 
 
bc2-99-exit. 
 
    exit. 
 
bd0-summary-and-print. 
 
*	set up summary side if items still to be printed 
*	skipping partial reprints 
 
    if ss-b not > ws-summary-items 
    then 
        if sum-reprint(ss-b) not = 'P' 
	then 

*	    move sum-sv-date(ss-b)		to p-sum-srv-date 
	    move sum-sv-date(ss-b)		to temp-long-date
	    move temp-long-date-yymmdd		to p-sum-srv-date

	    move sum-btch-nbr(ss-b)		to p-sum-btch-nbr 
            move sum-claim-nbr(ss-b)		to p-sum-clm-nbr 
	    move sum-bal-due(ss-b)		to p-sum-charge 
	    add 1				to ss-b 
	else 
	    add 1				to ss-b 
	    go to bd0-summary-and-print 
    else 
	move spaces 				to p-summary. 
*   endif 
 
    write prt-line from prt-dtl. 
    subtract 1 from ws-line-cntr. 
    if ws-line-cntr = 0 
    then 
	perform bb0-inv-header		thru bb0-99-exit. 
*   endif 
 
bd0-99-exit. 
 
   exit. 
 
be0-build-common. 
 
*** move clmdtl-sv-date			to p-dtl-srv-date. 
    move clmdtl-sv-date  to temp-long-date.
    move temp-long-date-yymmdd          to p-dtl-srv-date.
 
    if clmdtl-adj-cd = 'A' or 'B' or 'C' 
    then 
	next sentence 
    else 
	move clmdtl-nbr-serv		to p-nbr-srv. 
*   endif 
 
    move sum-btch-nbr(ss-a)		to p-dtl-btch-nbr. 
    move sum-claim-nbr(ss-a)		to p-dtl-clm-nbr. 
    move clmdtl-oma-cd			to p-ohip-cd. 
    move clmdtl-oma-suff		to p-ohip-suff. 
 
    if clmhdr-doc-nbr not = doc-nbr 
    then 
	move clmhdr-doc-nbr		to doc-nbr 
	perform ye0-read-doc-mstr	thru ye0-99-exit. 
*   endif 
 
    move doc-name			to p-doc. 
    move clmhdr-hosp			to p-loc. 
 
be0-99-exit. 
 
    exit. 
 
 
bf0-premium-desc. 
 
    move spaces				to ws-desc. 
 
    string p-desc	delimited by ws-spaces, 
 	   ws-space	delimited by size, 
	   ws-premium	delimited by size 
	   into ws-desc. 
 
    move ws-desc			to p-desc. 
 
bf0-99-exit. 
 
    exit. 
ca0-init-subscr. 
 
   move spaces 				to summary-table. 
 
   move zeros				to ws-prev-balance 
					   ws-curr-charges 
					   inv-claims 
					   inv-bal-due 
					   ws-cur 
		    			   ws-30 
					   ws-60 
					   ws-90 
					   ws-120 
					   ws-tot-adj 
					   ws-tot-pay. 
 
    move 'N'				to flag-invoice-to-print 
                                           flag-curr-activity 
				           flag-invoice-overflow. 
* (y2k)
*    move 999999				to ws-oldest-stmnt-prt-dt. 
    move 99999999			to ws-oldest-stmnt-prt-dt. 
 
    move 1				to ss-a. 
    move 2				to ws-detail-lines. 
 
    move wf-shadow-sort-key		to save-shadow-key. 
 
*	restore claim header read before break 
 
*mf    move 'B'				to key-clm-key-type. 
*mf    move zero			to key-clm-data. 
*mf    move wf-shadow-batch-nbr		to key-clm-batch-nbr. 
*mf    move wf-shadow-claim-nbr		to key-clm-claim-nbr. 
    move 'B'				to clmdtl-b-key-type. 
    move zero				to clmdtl-b-data. 
    move wf-shadow-batch-nbr		to clmdtl-b-batch-nbr. 
    move wf-shadow-claim-nbr		to clmdtl-b-claim-nbr. 
 
    perform ya0-read-claim-header	thru ya0-99-exit. 
 
ca0-99-exit. 
 
    exit. 
 
da0-subdiv-break. 
 
    move ss-subdiv			to ss-break-type. 
    move ss-clinic			to ss-to. 
 
    perform xb0-print-controls		thru xb0-99-exit. 
    perform xc0-bump-and-zero		thru xc0-99-exit. 
 
da0-99-exit. 
 
    exit. 
 
ea0-clinic-break. 
 
    move ss-clinic			to ss-break-type. 
*   move ss-grand			to ss-to. 
    move ss-agent			to ss-to. 
 
    perform xb0-print-controls		thru xb0-99-exit. 
    perform xc0-bump-and-zero		thru xc0-99-exit. 
 
    if wf-shadow-clinic = 43 
    then 
	close print-file 
	move prt-file-name-b		to print-file-name 
	open output print-file 
    else 
    	if save-shadow-clinic = 43 
	then 
	    close print-file 
	    move prt-file-name-a	to print-file-name 
	    open extend print-file. 
*   endif 
 
ea0-90-exit. 
 
*    move clm-shadow-clinic		to iconst-clinic-nbr-1-2. 
*    perform yh0-read-const-mstr	thru yh0-99-exit. 
 
ea0-99-exit. 
 
    exit. 
ha0-agent-break. 
 
    move ss-agent 			to ss-break-type. 
    move ss-grand			to ss-to. 
 
    perform xb0-print-controls		thru xb0-99-exit. 
    perform xc0-bump-and-zero		thru xc0-99-exit. 
 
ha0-99-exit. 
 
    exit. 
 
fa0-process-claim. 
 
    if claim-has-bal-due 
    then 
	perform fa1-check-clmref-date	thru fa1-99-exit 
 
	if ws-hold-clmref-date < ws-oldest-stmnt-prt-dt 
	then 
	    move ws-hold-clmref-date	to ws-oldest-stmnt-prt-dt. 
*	(else) 
*	endif 
*   (else) 
*   endif 
 
    move 'N'				to flag-end-of-claim-details. 
 
    move zeros				to sum-sv-date(ss-a). 
    move 'N'				to sum-reprint(ss-a). 
 
    perform ya1-read-claim-detail-next	thru ya1-99-exit. 
 
    perform fb0-process-claim-details	thru fb0-99-exit 
	until end-of-claim-details. 
 
*	round up detail lines for odd descriptions 
 
    divide ws-detail-lines by 1 giving ws-quotient remainder ws-remainder. 
    if ws-remainder not = zero 
    then 
        add .5					to ws-detail-lines. 
*   endif 
 
    if claim-has-bal-due 
    then 
	perform fc0-invoice-housekeeping	thru fc0-99-exit 
    else 
	if sum-reprint(ss-a) = 'P' 
	then 
	    perform fc0-90-build-summary	thru fc0-99-exit. 
*   endif 
 
fa0-99-exit. 
    exit. 
 
 
 
fa1-check-clmref-date. 
 
    if clmhdr-ref-date1 is numeric 
    then 
	move clmhdr-ref-date1		to ws-hold-clmref-date 
    else 
	if    clmhdr-ref2 is numeric 
	  and clmhdr-ref3 is numeric 
	  and clmhdr-ref4 is numeric 
	  and clmhdr-ref5 is numeric 
	  and clmhdr-ref6 is numeric 
	  and clmhdr-ref7 is numeric 
	then 
	    move clmhdr-ref-date2	to ws-hold-clmref-date 
	else 
	    if    clmhdr-ref3 is numeric 
	      and clmhdr-ref4 is numeric 
	      and clmhdr-ref5 is numeric 
	      and clmhdr-ref6 is numeric 
	      and clmhdr-ref7 is numeric 
	      and clmhdr-ref8 is numeric 
	    then 
		move clmhdr-ref-date3	to ws-hold-clmref-date 
	    else 
		if    clmhdr-ref4 is numeric 
		  and clmhdr-ref5 is numeric 
	          and clmhdr-ref6 is numeric 
	          and clmhdr-ref7 is numeric 
	          and clmhdr-ref8 is numeric 
	          and clmhdr-ref9 is numeric 
		then 
		    move clmhdr-ref-date4 to ws-hold-clmref-date 
 		else 
* (y2k)
*		    move 999999		to ws-hold-clmref-date. 
		    move 99999999	to ws-hold-clmref-date. 
*		endif 
*	    endif 
*	endif 
*   endif 
 
fa1-99-exit. 
    exit. 
 
 
 
fb0-process-claim-details. 
 
*	obtain service date from first detail record 
 
    if sum-sv-date(ss-a) = zeros 
    then 
	move clmdtl-sv-date 		to sum-sv-date(ss-a). 
*   endif 
 
    if     ( clmdtl-adj-cd = 'A' or 'B' ) 
*      and ( clmdtl-adjust-reprint not = 'Y' ) 
       and ( clmdtl-adjust-reprint     = 'N' ) 
       and ( clmdtl-oma-cd not = 'ZZZZ' ) 
    then 
*	adjustment 
	move 'P' 			to sum-reprint(ss-a) 
  	add clmdtl-fee-oma 		to ws-tot-adj 
	add 1				to ws-detail-lines 
    else 
	if     ( clmdtl-adj-cd = 'C' ) 
*	   and ( clmdtl-adjust-reprint not = 'Y' ) 
	   and ( clmdtl-adjust-reprint     = 'N' ) 
	   and ( clmdtl-oma-cd not = 'ZZZZ' ) 
	then 
*	    payment 
	    move 'P'			to sum-reprint(ss-a) 
	    add clmdtl-fee-oma 		to ws-tot-pay 
	    add 1			to ws-detail-lines 
	else 
	    if clmhdr-reprint-flag = 'Y' 
	       and claim-has-bal-due 
	    then 
		if clmdtl-oma-cd = 'ZZZZ' 
		then 
*		    description 
		    add .5		to ws-detail-lines 
		else 
*		    detail 
		    add 1		to ws-detail-lines. 
*   endif 
 
    perform ya1-read-claim-detail-next 	thru ya1-99-exit. 
 
fb0-99-exit. 
 
    exit. 
 
fc0-invoice-housekeeping. 
 
*    age balance due and accumulate 
 
    move clmhdr-date-sys			to claim-date. 
 
    multiply claim-yy by 365			giving claim-days. 
    add nbr-julian-days-ytd(claim-mm)		to claim-days. 
    compute claim-days = claim-days - 
                         ( max-nbr-days(claim-mm) - claim-dd ). 
 
    compute claim-days = ( run-days - claim-days ) / 30. 
 
    if claim-days not > 1 
    then 
	add ws-claim-bal-due			to ws-cur 
    else 
	if claim-days not > 2 
	then 
	    add ws-claim-bal-due		to ws-30 
	else 
	    if claim-days not > 3 
	    then 
		add ws-claim-bal-due		to ws-60 
	    else 
		if claim-days not > 4 
		then 
		    add ws-claim-bal-due 	to ws-90 
		else 
		    add ws-claim-bal-due	to ws-120. 
*   endif 
 
    move 'Y' 					to flag-invoice-to-print. 
 
    if clmhdr-reprint-flag = 'N' 
    then 
	add ws-claim-bal-due			to ws-prev-balance 
    else 
	add ws-claim-bal-due			to ws-curr-charges 
	move 'Y'				to sum-reprint(ss-a) 
						   flag-curr-activity 
	if clmhdr-msg-nbr not = zero 
	then 
	    move clmhdr-msg-nbr			to ws-msg-nbr 
	    perform xa0-count-msg-lines		thru xa0-99-exit. 
*   endif 
 
    add 1					to inv-claims. 
    add ws-claim-bal-due			to inv-bal-due. 
 
fc0-90-build-summary. 
 
*	build summary table - increment pointer 
 
    move clmhdr-batch-nbr			to sum-batch-nbr(ss-a). 
    move clmhdr-claim-nbr			to sum-claim-nbr(ss-a). 
    move ws-claim-bal-due			to sum-bal-due(ss-a). 
 
    if ss-a = 99 
    then 
	move 'Y'				to flag-invoice-overflow 
    else 
        add 1					to ss-a. 
 
fc0-99-exit. 
 
    exit. 
 
fe0-claim-header-update. 
 
    if clmhdr-auto-logout = 'Y' 
    then 
	move sys-date				to clmhdr-reference. 
*   endif 
 
    if clmhdr-reprint-flag = 'Y' 
    then 
	move 'N' 				to clmhdr-reprint-flag. 
*   endif 
 
    if new-claim-payment 
    then 
	move zero				to clmhdr-curr-payment. 
*   endif 
 
    perform ya2-rewrite-clmhdr			thru ya2-99-exit. 
 
fe0-99-exit. 
 
    exit. 
ga0-get-next-claim. 
 
*  	work through shadow master until a subscriber for 
*	which an invoice may be printed is found 
 
    move 'N' 				to flag-claim-to-invoice. 
 
    perform yb0-read-claim-shadow-next	thru yb0-99-exit. 
 
    perform gb0-check-and-read      	thru gb0-99-exit 
	until eof-clm-shadow-mstr or claim-to-invoice. 
 
ga0-99-exit. 
 
    exit. 
 
gb0-check-and-read. 
 
    if ws-pat-subscr-key  not = save-subscr-id 
    then 
	perform gc0-patient-processing		thru gc0-99-exit 
        if subscr-msg-nbr = not-to-invoice-msg-nbr and 
	   subscr-date-msg-nbr-eff-to > sys-date 
	then 
	    perform yb0-read-claim-shadow-next	thru yb0-99-exit 
	else 
	    move ws-pat-subscr-key 	to save-subscr-id 
	    move 'Y'			to flag-claim-to-invoice 
*       endif 
    else 
	move 'Y'			to flag-claim-to-invoice. 
*   endif 
 
gb0-99-exit. 
 
    exit. 
 
gc0-patient-processing. 
 
    if invoice-not-to-print 
    then 
	go to gc0-99-exit. 
*   endif 
 
    if clmhdr-agent-cd = 4 and clmhdr-reprint-flag = 'N' 
    then 
 	move 'N'			to flag-invoice-to-print 
	go to gc0-99-exit. 
*   endif 
 
*	only print invoices if there is new detail or the date of last 
*	statement is <= the calculated aged date 
*	or if there is no claim reference date 
 
    if   curr-activity 
      or ws-hold-clmref-date not > age-date 
* (y2k)
*     or ws-hold-clmref-date     = 999999 
      or ws-hold-clmref-date     = 99999999
    then 
	next sentence 
    else 
	move 'N'				to flag-invoice-to-print 
	go to gc0-99-exit. 
*   endif 
 
    move spaces					to ws-msg-dtls. 
    if hold-subscr-msg-nbr not = zero 
	and hold-subscr-date-msg-nbr-eff > sys-date 
    then 
	move hold-subscr-msg-nbr		to ws-msg-nbr 
	perform xa0-count-msg-lines		thru xa0-99-exit 
	move msg-dtl1				to ws-msg1 
	move msg-dtl2				to ws-msg2 
	move msg-dtl3				to ws-msg3 
	move msg-dtl4				to ws-msg4. 
*   endif 
 
    move spaces					to p-name. 
 
    string hold-pat-given-name	delimited by spaces, 
	   ws-space		delimited by size, 
	   hold-pat-surname 	delimited by spaces 
	   into p-name. 
 
    move hold-subscr-addr1			to p-addr1. 
    move hold-subscr-addr2			to p-addr2. 
    move hold-subscr-addr3			to p-addr3. 
    move hold-country				to p-country. 
 
    move spaces 				to p-postal-cd. 
 
    if spaces = hold-subscr-post-cd1 or 
                hold-subscr-post-cd3 or 
                hold-subscr-post-cd5 
    then 
	next sentence 
    else 
        if hold-subscr-postal-cd is numeric 
        then 
            move hold-subscr-postal-cd		to p-code-usa 
        else 
	    move hold-subscr-post-code1		to p-code1 
            move hold-subscr-post-code2		to p-code2. 
*   endif 
 
    move hold-pat-ohip-mmyy-r  			to p-dtl-id 
						   p-sum-id. 
* kludge
*** move sys-yy					to p-inv-yy. 
    move sys-y3					to p-inv-yy-1.
    move sys-y4					to p-inv-yy-2.
    
    move mth(sys-mm)				to p-inv-mmm. 
    move sys-dd					to p-inv-dd. 
* kludge
*** move sys-date				to p-inv-date. 
    move sys-y3 to p-inv-date-y1.
    move sys-y4 to p-inv-date-y2.
    move sys-mm to p-inv-date-mm.
    move sys-dd to p-inv-date-dd.
 
gc0-99-exit. 
    exit. 
ya0-read-claim-header. 
 
    move zero 				to feedback-claims-mstr 
					   claims-occur. 
    read claims-mstr into claim-header-rec key is key-claims-mstr 
        invalid key 
        display "claim header" key-claims-mstr
        display "pat id"       key-pat-mstr
        stop " ". 
 
    move feedback-claims-mstr		to hold-feedback-clmhdr. 
    move key-claims-mstr		to hold-key-claims-mstr. 
 
ya0-99-exit. 
 
    exit. 
 
ya1-read-claim-detail-next. 
 
    move zero 				to claims-occur 
					   feedback-claims-mstr. 
 
    read claims-mstr next 
	into claim-detail-rec 
*mf	    invalid key 
	    at end      
		move 'Y'		to flag-end-of-claim-details 
		go to ya1-99-exit. 
 
*mf    retrieve claims-mstr key 
*mf	fix position into key-claims-mstr. 
 
*mf    if key-clm-key-type not = 'B' 
    if k-clmdtl-b-key-type not = 'B' 
    then 
	move 'Y'			to flag-end-of-claim-details 
	go to ya1-99-exit. 
*   endif 
 
    if (( clmdtl-batch-nbr 	= clmhdr-batch-nbr  and 
	  clmdtl-claim-nbr	= clmhdr-claim-nbr ) 
          or 
	( clmdtl-batch-nbr	= clmhdr-orig-batch-nbr  and 
	  clmdtl-claim-nbr	= clmhdr-orig-claim-nbr )) 
          and 
	( clmdtl-oma-cd	    not = '0000' ) 
    then 
	next sentence 
    else 
	move 'Y'			to flag-end-of-claim-details. 
*   endif 
 
ya1-99-exit. 
 
    exit. 
 
ya2-rewrite-clmhdr. 
 
    move hold-feedback-clmhdr		to feedback-claims-mstr. 
    move hold-key-claims-mstr		to key-claims-mstr. 
    move zero				to claims-occur. 
 
* brad - update ????
*****     rewrite claims-mstr-rec from claim-header-rec. 
 
ya2-99-exit. 
 
    exit. 
 
ya3-rewrite-clmdtl. 

* brad - update ??? 
***  rewrite claims-mstr-dtl-rec from claim-detail-rec. 
 
ya3-99-exit. 
 
    exit. 
 
yb0-read-claim-shadow-next. 
 
*   move zero 				to claims-mstr-shadow-occur. 
 
    read clm-shdw-work-mstr next 
	at end 
		move pat-given-name	to hold-pat-given-name 
		move pat-surname	to hold-pat-surname 
		move 'Y' 		to flag-eof-clm-shadow-mstr 
		go to yb0-99-exit. 
 
    move  wf-shadow-patient		to key-pat-mstr. 
    perform yc0-read-patient		thru yc0-99-exit. 
 
**  move key-pat-mstr                   to ws-pat-subscr-key. 
    if  pat-ohip-mmyy-r is not = spaces 
    then 
  	move pat-ohip-mmyy-r		to ws-pat-subscr-key 
    else 
  	move pat-chart-nbr		to ws-pat-subscr-key. 
*   endif 
 
yb0-99-exit. 
 
    exit. 
 
yc0-read-patient. 
 
    move pat-given-name			to hold-pat-given-name. 
    move pat-surname			to hold-pat-surname. 
    move pat-ohip-mmyy-r                to hold-pat-ohip-mmyy-r. 
    move subscr-msg-nbr                 to hold-subscr-msg-nbr. 
    move subscr-date-msg-nbr-eff-to 	to hold-subscr-date-msg-nbr-eff. 
    move subscr-addr1                   to hold-subscr-addr1. 
    move subscr-addr2                   to hold-subscr-addr2. 
    move subscr-addr3                   to hold-subscr-addr3. 
    move subscr-postal-cd               to hold-subscr-postal-cd. 
    move pat-country			to hold-country. 
 
    read pat-mstr 
	invalid key 
	    move spaces 			to pat-given-name 
						   pat-surname. 
 
yc0-99-exit. 
 
    exit. 
 
 
ye0-read-doc-mstr. 
 
    read doc-mstr 
	invalid key 
	    move spaces 		to doc-name 
*!          move zeros                  to doc-nbr. 
            move spaces                 to doc-nbr. 
 
ye0-99-exit. 
 
    exit. 
 
yf0-read-oma-fee-mstr. 
 
    read oma-fee-mstr 
	invalid key 
	    move 'N'   			to flag-oma-rec 
	    go to yf0-99-exit. 
 
    move 'Y'				to flag-oma-rec. 
 
yf0-99-exit. 
 
    exit. 
 
yg0-read-msg-sub-mstr. 
 
    read msg-sub-mstr 
	invalid key 
	    move spaces 			to msg-dtl1 
						   msg-dtl2 
						   msg-dtl3 
						   msg-dtl4. 
 
yg0-99-exit. 
 
    exit. 
 
*yh0-read-const-mstr. 
 
*    read iconst-mstr. 
 
*yh0-99-exit. 
 
*   exit. 
 
xa0-count-msg-lines. 
 
    move msg-indexer				to msg-sub-key-1. 
    move ws-msg-nbr				to msg-sub-key-23. 
 
    perform yg0-read-msg-sub-mstr		thru yg0-99-exit. 
 
    if msg-dtl4 not = spaces 
    then 
	move 4					to ws-msg-lines 
    else 
   	if msg-dtl3 not = spaces 
	then 
	    move 3				to ws-msg-lines 
	else 
	    if msg-dtl2 not = spaces 
	    then 
	        move 2 				to ws-msg-lines 
	    else 
		if msg-dtl1 not = spaces 
		then		 
		    move 1			to ws-msg-lines 
		else 
		    move zero			to ws-msg-lines. 
*   endif 
 
*	count extra lines for skip if not room on current page for msg 
 
    divide ws-detail-lines by ws-lines-per-page	 
	giving ws-quotient remainder ws-remainder. 
 
    subtract ws-remainder from ws-lines-per-page 
	giving ws-lines-left. 
 
    if ws-lines-left < ws-msg-lines 
    then 
	add ws-lines-left to ws-detail-lines. 
*   endif 
 
    add ws-msg-lines to ws-detail-lines. 
 
xa0-99-exit. 
 
    exit. 
 
xb0-print-controls. 
 
    if bc-bal-due(ss-break-type)  = zero and 
       bc-claims(ss-break-type)   = zero and 
       bc-invoices(ss-break-type) = zero 
    then 
	go to xb0-99-exit. 
*   endif 
 
    move spaces 			to p-cntrl-id. 
    move ws-cntrl-hdr-lit 		to p-cntrl-lit 
 
    write prt-line 	from prt-blanks 	after page. 
    write prt-line 	from prt-cntrl-hdr	after 17. 
 
    if ss-break-type = ss-grand 
    then 
	move ws-cntrl-grand-lit		to p-cntrl-lit 
	move spaces			to p-cntrl-id 
	write prt-line	from prt-cntrl-hdr	after 3 
    else 
	move ws-cntrl-agent-lit	        to p-cntrl-lit 
    	move save-shadow-agent 		to p-cntrl-id 
	write prt-line 	from prt-cntrl-hdr	after 3 
        if ss-break-type = ss-clinic 
        then 
	    move ws-cntrl-clinic-lit	to p-cntrl-lit 
    	    move save-shadow-clinic	to p-cntrl-id 
	    write prt-line 	from prt-cntrl-hdr	after 3 
        else 
	    if ss-break-type = ss-subdiv 
	    then 
	        move ws-cntrl-clinic-lit	to p-cntrl-lit 
    	        move save-shadow-clinic	to p-cntrl-id 
	        write prt-line 	from prt-cntrl-hdr	after 3 
	        move ws-cntrl-subdiv-lit        to p-cntrl-lit 
	        move save-shadow-subdivision 	to p-cntrl-id 
	        write prt-line 	from prt-cntrl-hdr. 
*   endif 
 
    write prt-line 	from prt-cntrl-col	after 2. 
 
    move bc-bal-due(ss-break-type)	to p-bal-due. 
    move bc-claims(ss-break-type) 	to p-nbr-claims. 
    move bc-invoices(ss-break-type)	to p-nbr-invoices. 
 
    write prt-line 	from prt-cntrl-dtl	after 2. 
 
xb0-99-exit. 
 
    exit. 
 
xc0-bump-and-zero. 
 
 
    add bc-bal-due(ss-break-type)	to bc-bal-due(ss-to). 
    add bc-invoices(ss-break-type)	to bc-invoices(ss-to). 
    add bc-claims(ss-break-type)	to bc-claims(ss-to). 
 
    move zero				to bc-bal-due(ss-break-type) 
					   bc-invoices(ss-break-type) 
					   bc-claims(ss-break-type). 
 
xc0-99-exit. 
 
    exit. 
za0-common-error. 
 
    move err-msg(err-ind)			to err-msg-comment. 
    stop " ". 
 
za0-99-exit. 
  
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
