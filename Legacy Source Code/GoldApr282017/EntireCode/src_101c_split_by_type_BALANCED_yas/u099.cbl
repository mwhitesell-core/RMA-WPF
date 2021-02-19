identification division. 
program-id. u099.   
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/01/31. 
date-compiled. 
security. 
* 
*    files      : f010 - patient master 
*		: f011 - subscriber master 
*		: f002 - claims master 
* 
*    program purpose :	to purge 'INACTIVE' patients from the patient 
*			master. if all patients for a subscriber 
*			are deleted, then the subscriber is also deleted. 
* 
*	date		programmer	modifications 
*	----		----------	------------- 
*	83/11/07	i.warsh		move zero to occurs variables 
* 
*	84/10/02	m. so   	bypass all the bad acronym keys 
*                                       from patient master file 
* 
*       85/02/28	m. so 		change codes to use invisible 
*					key to access claims-mstr or 
*					pat-mstr 
* 
*       85/11/04       m. so		change for direct-id stored 
*                                       in ohip instead of chart field. 
* 
* 
*       86/11/25       m. so		change report name from "r099" 
*                                       to "ru099". 
* 
*       87/05/28       s. blair       - coversion from aos to aos/vs. 
*                                       change field size for 
*                                       status clause to 2 and 
*                                       feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*  revised march/91  : - sms 138 (b.m.l.) 
*                      - removed access to subscriber file and changed 
*                         access to patient file from acronym to i-key 
* 
*
*  revised feb/98 j. chau - s149 unix conversion
*
*  revised 1999/May/18 S.B. 	- Y2K conversion.
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f010_new_patient_mstr.slr". 
* 
**  copy "F010_NEW_PAT_2CD_MSTR.SLR". 
* 
**  copy "F011_NEW_SUBSCRIBER_MSTR.SLR". 
* 
*mf    copy "F002_CLM_MSTR_P_ACCESS.SLR". 
* 
    copy "f002_claims_mstr.slr".
select audit-file 
       assign to printer print-file-name 
       file status is status-audit-rpt. 
* 
data division. 
file section. 
* 
    copy "f010_patient_mstr.fd". 
* 
**  copy "F010_PATIENT_2CD_MSTR.FD". 
* 
**  copy "F011_SUBSCRIBER_MSTR.FD". 
* 
*mf    copy "F002_CLM_MSTR_P_ACCESS.FD". 
* 
    copy "f002_claims_mstr.fd".
fd audit-file 
   record contains 132 characters. 
 
01  audit-record. 
 
    05  filler				pic x(132). 
* 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  pat-occur					pic 9(12).    
**77  pat-2cd-occur				pic 9(12). 
77  feedback-pat-mstr				pic x(4). 
**77  feedback-pat-2cd-mstr			pic x(4). 
**77  feedback-subscr-mstr 			pic x(4). 
77  claims-pat-access-occur			pic 9(12). 
*mf 77  feedback-claims-mstr-pat-access		pic x(4). 
77  display-key-type				pic x(7). 
77  del-ind					pic x	value "N". 
77  claim-exists-for-this-patient		pic x	value "N". 
*77  print-file-name				pic x(4) value 
*		"r099". 
77  print-file-name				pic x(5) value 
		"ru099". 
 
* 
*  eof flags 
* 
**77  eof-subscr-mstr				pic x	value "N". 
77  eof-pat-mstr				pic x	value "N". 
77  eof-claims-mstr-pat-access                  pic x	value "N". 
 
**77  flag-set    				pic x. 
**  88  bad-acronym-key                         value 'Y'. 
**  88  good-acronym-key                        value 'N'. 
 
 
* 
*  status file indicators 
* 
01  status-indicators. 
*mf    05  status-file				pic x(11). 
**  05  status-subscr-mstr			pic x(11) value zero. 
*mf    05  status-pat-mstr			pic x(11) value zero. 
**  05  status-pat-2cd-mstr			pic x(11) value zero. 
**  05  status-cobol-pat-2cd-mstr		pic xx    value zero. 
**  05  status-cobol-subscr-mstr 		pic xx    value zero. 
*mf    05  status-claims-mstr-pat-access	pic x(11) value zero. 

    05  status-file				pic xx. 
    05  status-cobol-pat-mstr			pic xx    value zero. 
    05  status-cobol-claims-mstr 		pic xx    value zero. 
    05  status-audit-rpt			pic xx    value zero. 
 
**01  key-pat-mstr. 
 
**  05  pat-key-type				pic a. 
**  05  pat-key-o-c-a				pic x(15). 
 
**01  ws-key-pat-mstr. 
 
**  05  ws-pat-key-type				pic a. 
**  05  ws-pat-key-nbr				pic x(14). 
 
*mf    copy "F002_KEY_CLMS_MSTR_P_ACC.WS". 
 
    copy "f002_claims_mstr_rec1_2.ws".
 
01  hso-non-hso					pic x. 
    88  hso					value 'Y'. 
    88  non-hso					value 'N'. 
 
01  sel-date. 
* (y2k)
*    05  sel-yy					pic 99. 
    05  sel-yy					pic 9999. 
    05  sel-mm					pic 99. 
    05  sel-dd					pic 99. 
 
    copy "mth_desc_max_days.ws". 
 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-subscr-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-reads			pic 9(7). 
    05  ctr-subscr-mstr-rewrites		pic 9(7). 
    05  ctr-subscr-mstr-del			pic 9(7). 
    05  ctr-pat-mstr-del			pic 9(7). 
    05  ctr-audit-rpt-writes			pic 9(7). 
    05  ctr-pat-mstr-hso-del			pic 9(7). 
    05  ctr-pat-mstr-non-hso-del		pic 9(7). 
    05  ctr-pat-mstr-hso-ret			pic 9(7). 
    05  ctr-pat-mstr-non-hso-ret		pic 9(7). 
    05  ctr-subscr-mstr-hso-del			pic 9(7). 
    05  ctr-subscr-mstr-non-hso-del		pic 9(7). 
 
01  page-line-counters. 
    05  nbr-lines-to-adv    			pic 9(1). 
    05  max-lines-per-page			pic 9(2). 
    05  nbr-lines-this-page			pic 9(2). 
    05  page-nbr				pic 9(4). 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID YEAR". 
	10  filler				pic x(60)   value 
			"INVALID MONTH". 
	10  filler				pic x(60)   value 
			"INVALID DAY". 
	10  filler				pic x(60)   value 
			"PATIENTS MASTER NOT SUPPLIED". 
	10  filler				pic x(60)   value 
			"SPARE                            ". 
	10  filler				pic x(60)   value 
		"ATTEMPT TO DELETE INVALID I-KEY FROM PATIENT MASTER". 
	10  filler				pic x(60)   value 
		"SPARE                                   ". 
	10  filler				pic x(60)   value 
		"SPARE                                   ". 
	10  filler				pic x(60)   value 
		"SPARE                                   ". 
	10  filler				pic x(60)   value 
		"SPARE                                   ". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 10 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
    copy "sysdatetime.ws". 
01 h1-audit-head. 
 
    05  filler				pic x(46)    value 
		"R099". 
    05  filler				pic x(54)    value 
		"PATIENT - SUBSCRIBER PURGE AUDIT REPORT". 
    05  filler				pic x(9)     value 
		"RUN DATE ". 
    05  h1-date. 
* (y2k)
*	10  h1-date-yy			pic xx. 
	10  h1-date-yy			pic xxxx. 
	10  filler			pic x        value "/". 
	10  h1-date-mm			pic xx. 
	10  filler			pic x	     value "/". 
	10  h1-date-dd			pic xx. 
*    05  filler    		        pic x(6).   
    05  filler    		        pic x(4).   
    05  filler    		        pic x(5)     value "PAGE". 
    05  h1-page-nbr			pic zzz9. 
 
01  h3-audit-head. 
 
    05  filler				pic x(34)    value spaces. 
    05  filler				pic x(57)    value 
		"H S O". 
    05  filler				pic x(41)    value 
		"N O N - H S O". 
 
 
 
01  h4-audit-head. 
 
    05  filler				pic x(23)    value spaces. 
    05  filler				pic x(57)    value 
		"DELETED              RETAINED". 
    05  filler				pic x(29)    value 
		"DELETED". 
    05  filler				pic x(23)    value 
		"RETAINED". 
 
 
 
01  h5-audit-head. 
 
    05  filler				pic x(23)    value spaces. 
    05  filler				pic x(57)    value 
		"-------              --------". 
    05  filler				pic x(29)    value 
		"-------". 
    05  filler				pic x(23)    value 
		"--------".  
 
01  h6-audit-head. 
 
    05  filler                          pic x(9)     value spaces. 
    05  filler                          pic x(30)    value 
		"P A T I E N T". 
    05  filler				pic x(12)    value 
		"O H I P". 
    05  filler				pic x(4)     value 
		"/". 
    05  filler				pic x(15)    value 
		"C H A R T". 
    05  filler				pic x(7)     value 
   		"LAST". 
    05  filler				pic x(9)     value 
		"PATIENT". 
    05  filler				pic x(10)    value 
		"LAST". 
    05  filler				pic x(8)     value 
		"LAST". 
    05  filler				pic x(12)    value 
		"PATIENT". 
    05  filler				pic x(9)     value 
		"OHIP". 
    05  filler				pic x(7)     value 
		"NBR    ". 
 
                 
01  h7-audit-head. 
 
    05  filler				pic x(12)    value spaces. 
    05  filler				pic x(25)    value 
		"N A M E". 
    05  filler				pic x(13)    value 
		"N U M B E R". 
    05  filler				pic x(4)     value 
		"/". 
    05  filler				pic x(17)    value 
		"N U M B E R". 
    05  filler				pic x(7)     value 
		"DOC". 
    05  filler				pic x(8)     value 
		"BIRTH". 
    05  filler				pic x(10)    value 
		"ADMIT". 
    05  filler				pic x(7)     value 
		"MAINT". 
    05  filler				pic x(12)    value 
		"SEX/RELAT". 
    05  filler				pic x(8)     value 
		"STATUS". 
    05  filler				pic x(9)     value 
		"OUTSTND". 
 
01  h8-audit-head. 
 
    05  filler				pic x(70)    value spaces. 
    05  filler				pic x(8)     value 
		"SEEN". 
    05  filler				pic x(8)     value 
		"DATE". 
    05  filler				pic x(10)    value 
		"DATE". 
    05  filler				pic x(28)    value 
		"DATE". 
    05  filler				pic x(8)     value 
		"CLAIMS". 
 
01  print-line. 
 
    05  l1-print-line. 
	10  filler			pic x(29). 
	10  l1-err-msg			pic x(60). 
	10  l1-key			pic x(43). 
    05  l2-print-line redefines l1-print-line. 
	10  l2-pat-subscr		pic x(21). 
	10  l2-hso-del			pic z,zzz,zz9. 
	10  filler			pic x(13). 
	10  l2-hso-ret			pic z,zzz,zz9. 
	10  filler			pic x(26). 
	10  l2-non-hso-del		pic z,zzz,zz9. 
	10  filler			pic x(21). 
	10  l2-non-hso-ret		pic z,zzz,zz9. 
	10  filler			pic x(15). 
    05  l3-print-line redefines l1-print-line. 
	10  filler			pic x(1). 
	10  l3-surname			pic x(15). 
	10  filler			pic x(1). 
	10  l3-given-name		pic x(12). 
	10  filler			pic x(1). 
	10  l3-init			pic x(3). 
	10  filler			pic x(2). 
	10  l3-ohip-nbr   		pic x(15). 
	10  filler			pic x(2). 
	10  l3-chart-nbr		pic x(15). 
	10  filler			pic x(1). 
	10  l3-last-doc			pic zzz999. 
	10  filler			pic x(2). 
* (y2k)
*	10  l3-birth-date		pic 99/99/99. 
	10  l3-birth-date		pic 9999/99/99. 
	10  filler			pic x(1). 
* (y2k)
*	10  l3-admit-date		pic 99/99/99. 
	10  l3-admit-date		pic 9999/99/99. 
	10  filler			pic x(1). 
* (y2k)
*	10  l3-maint-date		pic 99/99/99. 
	10  l3-maint-date		pic 9999/99/99. 
* (y2k)
*	10  filler			pic x(4). 
	10  filler			pic x(2). 
	10  l3-sex			pic x(1). 
	10  l3-slash			pic x. 
	10  l3-relat			pic 9. 
* (y2k)
*	10  filler			pic x(8). 
	10  filler			pic x(4). 
	10  l3-status			pic x(2). 
	10  filler			pic x(5). 
	10  l3-outst-claims		pic zzz9. 
	10  filler			pic x(4). 
 
 
screen section. 
 
01  scr-title. 
 
    05  blank screen. 
    05  line 05 col 15 value is "U099  PATIENT/SUBSCR MASTER PURGE". 
    05  line 09 col 10 value is "PURGE ALL PATIENTS WITH NO OUTSTANDING". 
    05  line 10 col 10 value is "CLAIMS AND INACTIVE SINCE ". 
* (y2k - auto fix)
*   05  scr-yy line 10 col 37 pic 99 using sel-yy auto required. 
    05  scr-yy line 10 col 37 pic 9(4) using sel-yy auto required. 
    05  line 10 col 41 value is "/". 
    05  scr-mm line 10 col 42 pic 99 using sel-mm auto required. 
*   05  line 10 col 42 value is "/". 
*   05  scr-dd line 10 col 43 pic 99 using sel-dd auto required. 
 
01 file-status-display. 
    05  line 24 col 01 "ERROR IN ACCESSING PATIENT MASTER - KEY = ". 
    05  line 24 col 44 pic x(7) from display-key-type. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) from status-file	bell blink. 
    05  line 24 col 70	pic x(2) from status-file	bell blink. 
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
 
 
 
01  scr-closing-screen. 
    05  blank screen. 
**  05  line  5 col 20  value "NUMBER OF SUBSCRIBER-MSTR ACCESSES = ". 
**  05  line  5 col 60  pic 9(7) from ctr-subscr-mstr-reads. 
    05  line  6 col 20  value "NUMBER OF PATIENT-MSTR ACCESSES = ". 
    05  line  6 col 60  pic 9(7) from ctr-pat-mstr-reads. 
**  05  line  7 col 20 value "NUMBER OF SUBSCRIBER-MSTR REWRITES =". 
**  05  line  7 col 60 pic 9(7) from ctr-subscr-mstr-rewrites. 
**  05  line  8 col 20  value "NUMBER OF SUBSCRIBER DELETES = ". 
**  05  line  8 col 60  pic 9(7) from ctr-subscr-mstr-del. 
    05  line  9 col 20  value "NUMBER OF PATIENT DELETES = ". 
    05  line  9 col 60  pic 9(7) from ctr-pat-mstr-del. 
    05  line 21 col 20	value "PROGRAM U099 ENDING". 
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
    05  line 23 col 20  value "AUDIT REPORT IS IN FILE - ". 
    05  line 23 col 51  pic x(5) from print-file-name. 
procedure division. 
declaratives. 
 
**err-subscr-mstr-file section. 
**  use after standard error procedure on subscr-mstr. 
**err-subscr-mstr. 
**  stop "ERROR IN ACCESSING SUBSCRIBER MASTER". 
**  move status-subscr-mstr		to status-file. 
**  display file-status-display. 
**  stop run. 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
    move "I KEY  "			to display-key-type 
**  move 'Y'     	                to flag-set 
*mf    move status-pat-mstr		to status-file. 
    move status-cobol-pat-mstr		to status-file. 
    display file-status-display. 
 
err-audit-rpt-file section. 
    use after standard error procedure on audit-file.       
err-audit-rpt. 
    stop "ERROR IN WRITING TO AUDIT REPORT FILE". 
    move status-audit-rpt		to status-file. 
    display file-status-display. 
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
 
*    expunge audit-file. 
 
 
 
**  open i-o	subscr-mstr. 
    open i-o	pat-mstr. 
**		pat-2cd-mstr. 
*mf    open input  claims-mstr-pat-access. 
    open input  claims-mstr. 
    open output audit-file. 
 
    move 0				to	counters.      
    move 0 				to      page-line-counters. 
    move 60				to	max-lines-per-page. 
    move spaces				to	print-line. 
**  move 'N'   				to	flag-set. 
 
 
    move sys-yy				to	h1-date-yy. 
    move sys-mm				to	h1-date-mm. 
    move sys-dd				to	h1-date-dd. 
 
    perform xa0-print-hdr		thru    xa0-99-exit. 
 
    move zero				to	sel-dd. 
    move sys-mm				to	sel-mm.    
    subtract 1				from	sys-yy 
					giving	sel-yy. 
 
 
*	(display screen title/option) 
    display scr-title. 
aa0-10-enter-year. 
 
    accept scr-yy. 
* (y2k)
*    if sel-yy < 32 or sel-yy > run-yy 
    if sel-yy < 1932 or sel-yy > run-yy 
    then 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-enter-year. 
*   (else) 
*   endif 
 
aa0-10-enter-month. 
    accept scr-mm. 
    if sel-mm < 1 or sel-mm > 12 
    then 
	move 2				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-enter-month. 
*   (else) 
*   endif 
 
aa0-10-enter-day. 
*    accept scr-dd. 
*    if sel-dd < 1 or sel-dd > max-nbr-days (sel-mm) 
*    then 
*	move 3				to	err-ind 
*	perform za0-common-error	thru	za0-99-exit 
*	go to aa0-10-enter-day. 
*   (else) 
*   endif 
 
    move spaces				to	key-pat-mstr 
						feedback-pat-mstr. 
 
    move zero				to	pat-occur. 
 
*mf    read pat-mstr key is key-pat-mstr approximate 
*mf	invalid key 
*mf	    move 'Y'			to	eof-pat-mstr 
*mf	    move 4			to	err-ind 
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    start pat-mstr key is greater than or equal to key-pat-mstr
	invalid key 
	    move 'Y'			to	eof-pat-mstr 
	    move 4			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
    read pat-mstr next.
 
**  retrieve pat-mstr key fix position 
**	into key-pat-mstr. 
 
**  if pat-key-type not = 'A' 
**  then 
**	move 'Y'			to	eof-pat-mstr 
**	go to aa0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to	ctr-pat-mstr-reads. 
 
    copy 'verify_hso.rtn'. 
	move 'Y'			to	hso-non-hso 
    else 
	move 'N'			to	hso-non-hso. 
*   endif 
 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
    perform az1-print-audit-totals	thru	az1-99-exit. 
 
**  close subscr-mstr 
    close pat-mstr 
**	  pat-2cd-mstr 
*mf	  claims-mstr-pat-access 
	  claims-mstr
	  audit-file. 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
 
*   call program "MENU". 
 
az0-10-stop. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
az1-print-audit-totals. 
 
    add 1				to	page-nbr. 
    move page-nbr			to	h1-page-nbr. 
    write audit-record			from	h1-audit-head after advancing page. 
    write audit-record			from	h3-audit-head after advancing 2 lines. 
    write audit-record			from	h4-audit-head after advancing 1 line. 
    write audit-record			from	h5-audit-head after advancing 1 line. 
 
    move 'PATIENTS'			to	l2-pat-subscr. 
    move ctr-pat-mstr-hso-del		to	l2-hso-del. 
    move ctr-pat-mstr-hso-ret		to	l2-hso-ret. 
    move ctr-pat-mstr-non-hso-del	to	l2-non-hso-del. 
    move ctr-pat-mstr-non-hso-ret	to	l2-non-hso-ret. 
 
    move 2				to	nbr-lines-to-adv. 
    perform xb0-write-audit-record      thru	xb0-99-exit. 
 
**  move 'SUBSCRIBERS'			to	l2-pat-subscr. 
**  move ctr-subscr-mstr-hso-del	to	l2-hso-del. 
**  move ctr-subscr-mstr-non-hso-del	to	l2-non-hso-del. 
 
    move 2				to	nbr-lines-to-adv. 
    perform xb0-write-audit-record	thru	xb0-99-exit. 
 
 
az1-99-exit. 
    exit. 
ab0-processing. 
 
    move 'N'				to	del-ind. 
 
    perform ca0-sel-read-pat-rec	thru	ca0-99-exit 
	until del-ind = "Y" or eof-pat-mstr = "Y". 
    if del-ind = "Y" 
    then 
	perform da0-del-pat-rec		thru	da0-99-exit 
*   endif 
 
    if eof-pat-mstr  = "N" 
    then 
	move "N"			to	del-ind 
	perform cb0-read-pat-mstr	thru	cb0-99-exit 
	go to ab0-processing 
    else 
	next sentence. 
*   endif 
 
ab0-99-exit. 
    exit. 
 
ca0-sel-read-pat-rec. 
 
    if non-hso 
    then 
        perform cc0-sel-pat-rec		thru	cc0-99-exit. 
*   (else) 
*   (endif) 
    if del-ind = "N" 
    then 
	if hso 
	then 
	    add 1			to	ctr-pat-mstr-hso-ret 
	    perform cb0-read-pat-mstr	thru	cb0-99-exit 
	else 
	    add 1			to	ctr-pat-mstr-non-hso-ret 
	    perform cb0-read-pat-mstr	thru	cb0-99-exit 
*	endif 
    else 
	next sentence. 
*   endif 
 
ca0-99-exit. 
    exit. 
 
cb0-read-pat-mstr. 
 
    move zero			to	pat-occur 
					feedback-pat-mstr. 
 
    read pat-mstr next 
      at end 
	move "Y"			to	eof-pat-mstr 
	go to cb0-99-exit. 
 
**  if bad-acronym-key 
**     move 'N'                         to      flag-set 
**     go to cb0-read-pat-mstr. 
 
**  retrieve pat-mstr key fix position 
**	into key-pat-mstr. 
*	(read 'A'cronym keys only) 
**  if pat-key-type not = "A" 
**	move "Y"			to	eof-pat-mstr 
**	go to cb0-99-exit 
**  else 
**	next sentence. 
*   endif 
 
    add 1				to	ctr-pat-mstr-reads. 
 
    copy 'verify_hso.rtn'. 
    then 
	move 'Y'			to	hso-non-hso 
    else 
	move 'N'			to	hso-non-hso. 
*   endif 
 
cb0-99-exit. 
    exit. 
 
cc0-sel-pat-rec. 
 
*	(determine if there is a claim for patient in claims master 
*	   and if so, set delete flag if pat rec prior to sel-date) 
 
    if    sel-date > pat-date-last-maint-r 
      and 
	  sel-date > pat-date-last-visit-r 
      and 
	  sel-date > pat-date-last-admit-r 
    then 
	next sentence 
    else 
	move 'N'			to	del-ind 
	go to cc0-99-exit. 
*   endif 
 
    perform cc1-read-claim-p-access	thru	cc1-99-exit. 
 
    if claim-exists-for-this-patient = 'Y' 
    then 
	move 'N'			to	del-ind 
    else 
	move 'Y'			to	del-ind. 
*   endif 
 
cc0-99-exit. 
    exit. 
 
 
cc1-read-claim-p-access. 
 
    move 'N'				to claim-exists-for-this-patient. 
*mf    move spaces 			to key-claims-mstr-pat-access. 
*mf    move key-pat-mstr		to key-claims-mstr-pat-access. 
*mf    move "P"				to key-clm-pat-access-type. 
 
    perform cc2-read-claims-mstr-p-access	thru 	cc2-99-exit. 
 
cc1-99-exit. 
    exit. 
 
cc2-read-claims-mstr-p-access.  
 
*mf    move zero			to claims-pat-access-occur 
*mf					   feedback-claims-mstr-pat-access. 
 
*mf    read claims-mstr-pat-access 
*mf	invalid key 
*mf	    move "N"	to	claim-exists-for-this-patient 
*mf	    go to cc2-99-exit. 

    move "Y"		to	claim-exists-for-this-patient. 
 
cc2-99-exit. 
    exit. 
 
da0-del-pat-rec. 
 
    move zero				to	err-ind. 
*mf    delete pat-mstr record physical 
    delete pat-mstr record
	invalid key 
	  move 6  			to	err-ind 
	  perform za0-common-error	thru	za0-99-exit. 
 
    if err-ind = 0 
    then 
        if hso 
        then 
  	    add 1			to ctr-pat-mstr-hso-del 
        else 
	    add 1			to ctr-pat-mstr-non-hso-del 
*	endif 
    else 
	next sentence. 
*   endif 
 
    move 0				to	pat-occur 
						feedback-pat-mstr. 
 
    add 1				to	ctr-pat-mstr-del. 
 
da0-99-exit. 
    exit. 
xa0-print-hdr. 
 
    add 1				to	page-nbr. 
    move page-nbr			to	h1-page-nbr. 
    write audit-record			from	h1-audit-head after advancing page. 
    write audit-record			from	h6-audit-head after advancing 2 lines. 
    write audit-record			from	h7-audit-head after advancing 1 line. 
    write audit-record			from	h8-audit-head after advancing 1 line.                 
    move 2				to 	nbr-lines-to-adv. 
    move 6				to	nbr-lines-this-page. 
 
xa0-99-exit. 
    exit. 
 
xb0-write-audit-record. 
 
    if nbr-lines-this-page + nbr-lines-to-adv > max-lines-per-page 
    then 
	perform xa0-print-hdr		thru	xa0-99-exit  
    else 
	next sentence. 
*   endif 
    write audit-record			from	print-line after advancing nbr-lines-to-adv lines. 
    add nbr-lines-to-adv		to	nbr-lines-this-page. 
    move spaces				to	print-line. 
    move 1				to	nbr-lines-to-adv. 
 
xb0-99-exit. 
    exit. 
 
xc0-build-detail-line. 
 
    move pat-surname			to	l3-surname. 
    move pat-given-name			to	l3-given-name. 
    move pat-init			to	l3-init. 
    move pat-ohip-mmyy-r		to	l3-ohip-nbr. 
    move pat-chart-nbr  		to	l3-chart-nbr. 
    move pat-last-doc-nbr-seen		to	l3-last-doc. 
    move pat-birth-date			to	l3-birth-date. 
    move pat-date-last-admit		to	l3-admit-date. 
    move pat-date-last-maint		to	l3-maint-date. 
    move pat-sex			to	l3-sex.  
    move "/"				to	l3-slash. 
**  move pat-relationship		to	l3-relat. 
    move spaces            		to	l3-status. 
    move pat-nbr-outstanding-claims	to	l3-outst-claims. 
 
xc0-99-exit. 
    exit. 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment 
						l1-err-msg. 
    display err-msg-line. 
    display confirm. 
    display blank-line-24. 
 
    if err-ind =   6 
		or 7 
		or 8 
    then 
	move key-pat-mstr		to	l1-key. 
**  else 
**	if err-ind =   5 
**		    or 9 
**		    or 10 
**	then 
**	   move subscr-id		to	l1-key 
**	else 
**	   next sentence. 
*	endif 
*   endif 
 
*   move 2				to	nbr-lines-to-adv. 
    perform xb0-write-audit-record	thru	xb0-99-exit. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
