identification division. 
program-id. u040. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/12/12. 
date-compiled. 
security. 
* 
*    files      : f040  - oma fee master 
*		: ru040 - oma fee report 
* 
*    program purpose : to move the 'CURR'ent  oma/ohip fee rates 
*			    to the 'PREV'ious oma/ohip fee rates. 
* 
*    revision may/87 (s.b.) - coversion from aos to aos/vs. 
*                             change field size for 
*                             status clause to 2 and 
*                             feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 2001/oct/01 B.E. - added min/max fees into roll over logic
* 
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
* 
 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
* 
data division. 
file section. 
* 
    copy "f040_oma_fee_mstr.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
	value "ru040". 
77  max-nbr-lines-1				pic 99   value 56. 
77  max-nbr-lines-2				pic 99   value 56. 
77  ctr-lines					pic 99	   value 70. 
77  feedback-oma-fee-mstr			pic x(4). 
 
*  eof indicators 
* 
77  eof-oma-mstr				pic x	value "N". 
 
*  status file indicators 
* 
77  status-prt-file				pic xx      value zero. 
*mf 77  common-status-file				pic x(11). 
*mf 77  status-oma-mstr				pic x(11)   value zero. 
77  common-status-file				pic x(2). 
77  status-cobol-oma-mstr			pic x(2)   value zero. 
*	subscripts 
 
*	('CURR'ent and 'PREV'ious used in selecting the appropriate year'S FEES -- 
*	 'OMA' and 'OHIP' used to select the appropriate type of fee) 
77  curr					pic 9	comp	value 1. 
77  prev					pic 9	comp	value 2.   
77  oma						pic 9	comp	value 1. 
77  ohip					pic 9	comp	value 2. 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-oma-fee-mstr-reads			pic 9(7). 
    05  ctr-pages				pic 9999. 
 
    copy "sysdatetime.ws". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"NO OMA-FEE-MASTER SUPPLIED". 
	10  filler				pic x(60)   value 
		"FATAL ERROR !!! - ERROR IN REWRITING RECORD". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 2 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
01  h1-head. 
 
    05  filler					pic x(50)  value 
		"RU040".    
    05  filler					pic x(53)  value  
		"OMA FEE REPORT". 
    05  filler					pic x(9)   value 
		"RUN DATE". 
* (y2k)
    05  h1-date. 
* (y2k)
	10  h1-yy				pic 99. 
	10  h1-slash1				pic x. 
	10  h1-mm				pic 99. 
	10  h1-slash2				pic x. 
	10  h1-dd				pic 99. 
	10  filler				pic xxx   value spaces. 
     05  filler					pic x(5)   value 
		"PAGE". 
    05  h1-page					pic zzz9. 
 
01  h2-head. 
 
    05  filler					pic x(47)  value  
	"OMA   ASSOC      PAGE EFFECT.  BLTRL". 
    05  filler					pic x(48)   value 
	"DESCRIPTION". 
    05  filler					pic x(21)    value 
	"ICC-    REDUC". 
    05  filler					pic x(16)    value 
	"ADD ON CODES". 
 
01  h3-head. 
    05  filler					pic x(12)   value 
	"CODE". 
    05  filler					pic x(10)   value 
	"   ". 
    05  filler					pic x(10)   value 
	"DATE". 
    05  filler					pic x(63)   value 
	"ID". 
    05  filler					pic x(18)   value 
	"CODE    CODE". 
    05  filler					pic x(19)   value 
	"CD-1 CD-2 CD-3 CD-4". 
 
01  h4-head. 
    05  filler					pic x(40)   value 
	" A-FEE-1   H-FEE-1   A-FEE-2   H-FEE-2". 
    05  filler					pic x(53)   value 
	"A-   H-   A-   H-   MAX-GEN   MAX-PRO". 
    05  filler					pic x(39)   value 
	"PRCNT/ DIAG PHY HOSP I-O ADM  SPEC SPEC". 
 
01  h5-head. 
    05  filler					pic x(40) value spaces. 
    05  filler					pic x(53)   value 
	"ANAE ANAE ASST ASST". 
    05  filler					pic x(39)   value 
	"FLAT   IND  IND IND  IND IND   FR   TO". 
01  l1-print-line. 
    05  l1-oma-code				pic x999. 
    05  filler					pic xx. 
    05  l1-assoc				pic x999. 
    05  filler					pic xxx. 
    05  l1-filler-card-clr			pic xxxx. 
    05  l1-page					pic 999. 
    05  filler					pic xx. 
* (y2k)
    05  l1-effect-date. 
* (y2k)
	10  l1-date-yy				pic 99. 
	10  l1-slash1				pic x. 
* (y2k)
	10  l1-date-mm				pic 99. 
	10  l1-slash2				pic x. 
* (y2k)
	10  l1-date-dd				pic 99. 
    05  filler					pic xx. 
    05  l1-bltrl-id				pic x(6). 
    05  l1-description				pic x(56). 
    05  l1-icc-code				pic xx9999. 
    05  filler					pic xxx. 
    05  l1-reduc-code				pic xx999. 
    05  filler 					pic x(5). 
    05  l1-cd-1					pic x999. 
    05  filler					pic x. 
    05  l1-cd-2					pic x999. 
    05  filler					pic x. 
    05  l1-cd-3					pic x999. 
    05  filler					pic x. 
    05  l1-cd-4					pic x999. 
 
01  l2-print-line. 
    05  l2-a-fee-1				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l2-h-fee-1				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l2-a-fee-2				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l2-h-fee-2				pic zzzz9.99-. 
    05  filler					pic xx. 
    05  l2-a-anae				pic 99. 
    05  filler					pic xxx. 
    05  l2-h-anae				pic 99. 
    05  filler					pic xxx. 
    05  l2-a-asst				pic 99. 
    05  filler					pic xxx. 
    05  l2-h-asst				pic 99. 
    05  filler					pic xxx. 
    05  l2-max-gen				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l2-max-pro				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l2-current				pic x(14). 
    05  l2-prcnt-flat				pic x(7). 
    05  l2-diag-ind				pic x(4). 
    05  l2-phy-ind				pic x(4). 
    05  l2-hosp-ind				pic x(5). 
    05  l2-i-o-ind				pic x(4). 
    05  l2-adm-ind				pic x(5). 
    05  l2-spec-fr				pic 99. 
    05  filler					pic xxx. 
    05  l2-spec-to				pic 99. 
    05  filler					pic x. 
    05  filler					pic xxx. 
 
 
01  l3-print-line. 
    05  l3-a-fee-1				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l3-h-fee-1				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l3-a-fee-2				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l3-h-fee-2				pic zzzz9.99-. 
    05  filler					pic xx. 
    05  l3-a-anae				pic 99. 
    05  filler					pic xxx. 
    05  l3-h-anae				pic 99. 
    05  filler					pic xxx. 
    05  l3-a-asst				pic 99. 
    05  filler					pic xxx. 
    05  l3-h-asst				pic 99. 
    05  filler					pic xxx. 
    05  l3-max-gen				pic zzzz9.99-. 
    05  filler					pic x. 
    05  l3-max-pro				pic zzzz9.99-. 
    05  filler					pic x. 
* (y2k)
    05  l3-prev-yr				pic x(52). 
screen section. 
 
01  file-status-display. 
    05  line 24 col 56 value "FILE STATUS = ". 
*mf 05  line 24 col 70 pic x(11) using common-status-file    bell blink. 
    05  line 24 col 70 pic x(2) using common-status-file    bell blink. 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  confirm. 
    05  line 23 col 01 value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  7 col 20  value "NUMBER OF OMA-FEE-MSTR READS = ". 
    05  line  7 col 60  pic 9(7) from ctr-oma-fee-mstr-reads. 
    05  line 19 col 20	value "PROGRAM S040 ENDING". 
* (y2k - auto fix)
*   05  line 19 col 40  pic 99	from sys-yy. 
    05  line 19 col 40  pic 9(4)	from sys-yy. 
    05  line 19 col 42	value "/". 
    05  line 19 col 43	pic 99	from sys-mm. 
    05  line 19 col 45	value "/". 
    05  line 19 col 46	pic 99	from sys-dd. 
    05  line 19 col 50	pic 99	from sys-hrs. 
    05  line 19 col 52	value ":". 
    05  line 19 col 53	pic 99	from sys-min.        
    05  line 21 col 20	value "PRINT REPORT IS IN FILE - ". 
    05  line 21 col 51	pic x(7) from print-file-name. 
procedure division. 
declaratives. 
 
err-oma-fee-file section. 
    use after standard error procedure on oma-fee-mstr.    
err-oma-fee-mstr. 
*mf    move status-oma-mstr		to common-status-file. 
    move status-cobol-oma-mstr		to common-status-file. 
    display file-status-display. 
    stop "ERROR IN ACCESSING OMA-FEE MASTER". 
 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-mainline		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
 
* (y2k)
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm. 
    move sys-dd				to run-dd. 
* (y2k)
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
 
*************************************** 
    open i-o	oma-fee-mstr. 
*************************************** 
 
    move spaces				to	l1-print-line 
						l2-print-line 
						l3-print-line. 
    move zero				to	counters. 
 
 
*	delete print-file 
*    expunge print-file. 
 
    open output print-file. 
 
    read oma-fee-mstr next 
      at end 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
*	(move 'CURR'ent rates to 'PREV'ious rates) 
    perform zz0-move-curr-rates-to-prev	thru	zz0-99-exit. 
 
    add 1				to	ctr-oma-fee-mstr-reads. 
 
    move run-mm				to	h1-mm. 
    move run-dd				to	h1-dd. 
* (y2k)
    move run-yy				to	h1-yy. 
    move "/"				to	h1-slash1 
						h1-slash2. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    close oma-fee-mstr. 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
ab0-mainline. 
 
    perform ba0-build-print-line	thru	ba0-99-exit. 
    perform bb0-write-print-line	thru	bb0-99-exit. 
    perform bc0-read-oma-fee-mstr	thru	bc0-99-exit. 
    if eof-oma-mstr not = "Y" 
    then 
	go to ab0-mainline. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
ba0-build-print-line. 
 
    move fee-oma-cd			to	l1-oma-code. 
    move spaces   			to	l1-assoc. 
    move fee-curr-page			to	l1-page. 
* (y2k)
    move fee-date-yy			to	l1-date-yy. 
* (y2k)
    move fee-date-mm			to	l1-date-mm. 
* (y2k)
    move fee-date-dd			to	l1-date-dd. 
    move "/"				to	l1-slash1 
						l1-slash2. 
    move spaces            		to	l1-bltrl-id. 
    move fee-desc			to	l1-description. 
    move fee-icc-code			to	l1-icc-code. 
    move spaces               		to	l1-reduc-code. 
    move fee-curr-add-on-cd(1)		to	l1-cd-1. 
    move fee-curr-add-on-cd(2)		to	l1-cd-2. 
    move fee-curr-add-on-cd(3)		to	l1-cd-3. 
    move fee-curr-add-on-cd(4)		to	l1-cd-4. 
 
    move fee-1 (1,1)			to	l2-a-fee-1. 
    move fee-1 (1,2)			to	l2-h-fee-1.   
    move fee-2 (1,1)			to	l2-a-fee-2.   
    move fee-2 (1,2)			to	l2-h-fee-2.      
    move fee-anae (1,1)			to 	l2-a-anae. 
    move fee-anae (1,2)			to 	l2-h-anae.            
    move fee-asst (1,1)			to 	l2-a-asst. 
    move fee-asst (1,2)			to    	l2-h-asst. 
    move zero            		to	l2-max-gen. 
    move zero            		to	l2-max-pro. 
    move "CURRENT"			to	l2-current. 
    move fee-curr-add-on-perc-flat-ind	to	l2-prcnt-flat. 
    move fee-diag-ind			to	l2-diag-ind. 
    move fee-phy-ind			to	l2-phy-ind. 
    move fee-hosp-nbr-ind		to	l2-hosp-ind. 
    move fee-i-o-ind			to	l2-i-o-ind. 
    move fee-admit-ind			to	l2-adm-ind. 
    move fee-spec-fr			to	l2-spec-fr. 
    move fee-spec-to			to	l2-spec-to. 
 
    move fee-1 (2,1)			to	l3-a-fee-1. 
    move fee-1 (2,2)			to	l3-h-fee-1.   
    move fee-2 (2,1)			to	l3-a-fee-2.   
    move fee-2 (2,2)			to	l3-h-fee-2.      
    move fee-anae (2,1)			to 	l3-a-anae. 
    move fee-anae (2,2)			to 	l3-h-anae.            
    move fee-asst (2,1)			to 	l3-a-asst. 
    move fee-asst (2,2)			to    	l3-h-asst. 
    move zero            		to	l3-max-gen. 
    move zero             		to	l3-max-pro. 
* (y2k)
    move "PREV. YR"			to	l3-prev-yr. 
 
ba0-99-exit. 
    exit. 
 
bb0-write-print-line. 
 
    if ctr-lines > max-nbr-lines-1 
    then 
	perform ca0-write-headings	thru	ca0-99-exit. 
*   (else) 
*   endif 
 
    write print-record from h2-head after advancing 3 lines. 
    write print-record from h3-head after advancing 1 line. 
    write print-record from l1-print-line after advancing 1 line. 
 
    add 5				to	ctr-lines. 
 
    if ctr-lines > max-nbr-lines-1 
    then 
	perform ca0-write-headings	thru	ca0-99-exit. 
*  (else) 
*  endif 
    write print-record from h4-head after advancing 2 line. 
    write print-record from h5-head after advancing 1 line. 
    write print-record from l2-print-line after advancing 1 line. 
    write print-record from l3-print-line after advancing 1 line. 
    add 5				to	ctr-lines. 
    move spaces				to	l1-print-line 
						l2-print-line 
						l3-print-line. 
 
bb0-99-exit. 
    exit. 
bc0-read-oma-fee-mstr. 
 
    read oma-fee-mstr next 
      at end 
	move "Y"			to eof-oma-mstr 
	go to bc0-99-exit. 
    add 1				to ctr-oma-fee-mstr-reads. 
 
*	(move 'CURR'ent rates to 'PREV'ious rates) 
    perform zz0-move-curr-rates-to-prev	thru	zz0-99-exit. 
 
*mf    retrieve	oma-fee-mstr	key  fix position 
*mf	into fee-oma-cd. 
 
*	(re-write updated record) 
*mf    rewrite	fee-mstr-rec	key is fee-oma-cd 
    rewrite	fee-mstr-rec	
	invalid key 
		move 2				to err-ind 
		perform za0-common-error	thru za0-99-exit 
		stop run. 
 
 
bc0-99-exit. 
  exit. 
ca0-write-headings. 
 
    add 1				to	ctr-pages. 
    move ctr-pages			to	h1-page. 
    write print-record from h1-head after advancing page. 
    move 1				to	ctr-lines. 
 
ca0-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
zz0-move-curr-rates-to-prev. 
 
    move fee-curr-a-fee-1			to fee-prev-a-fee-1. 
    move fee-curr-h-fee-1			to fee-prev-h-fee-1. 
    move fee-curr-a-fee-2			to fee-prev-a-fee-2. 
    move fee-curr-h-fee-2			to fee-prev-h-fee-2. 
    move fee-curr-a-anae			to fee-prev-a-anae. 
    move fee-curr-h-anae			to fee-prev-h-anae. 
    move fee-curr-a-asst			to fee-prev-a-asst. 
    move fee-curr-h-asst			to fee-prev-h-asst. 
 
    move fee-curr-add-on-codes			to fee-prev-add-on-codes. 
    move fee-curr-oma-ind-card-reqs	to fee-prev-oma-ind-card-reqs. 
    move fee-curr-page				to fee-prev-page. 
    move fee-curr-add-on-perc-flat-ind	to fee-prev-add-on-perc-flat-ind. 

*   (2001/oct/01 - roll over min/max rates)
    move fee-curr-a-min              		to fee-prev-a-min.
    move fee-curr-h-min              		to fee-prev-h-min.
    move fee-curr-a-max              		to fee-prev-a-max.
    move fee-curr-h-max              		to fee-prev-h-max.
 
zz0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
