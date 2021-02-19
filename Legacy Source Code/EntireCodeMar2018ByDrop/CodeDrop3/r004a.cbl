identification division. 
program-id. r004a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/12/31. 
date-compiled. 
security. 
* 
*    files      : f001   - batch control file 
*		: f002   - claim master 
*		: f010   - patient master 
*		: f090i  - constants master 
*		: r004wf - work file  
* commented out : f020   - doctor master 
*               : r004   - parm file
* 
*    program purpose : print the 'MONTHLY CLAIMS AND ADJUSTMENT 
*		       transaction summary'.   
*		       this program is the first in a series of 3 
*		       programs -- this pgm extracts records from the 
*		       claims master and creates to work file. 
* 
*   revised 85/11/05 : changes for ikey. access the patient master 
*                      to get the patient id since the claims file 
*                      now stores the ikey instead of the patient id. 
* 
* 
*   revised 87/03/16 : to print the correct batch nbr for adj and 
*		       payment in report. 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
* 
*   89/mar/13  m. chan	- sms 97 
*			  use the new fd of 'R004_CLAIMS_WORK_MSTR.FD' 
*			  store the clmhdr-adj-cd-sub-type into the 
*			  work file 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised april/91 : - sms 138 m.c. 
*		       - take out 'F010_KEY_PAT_MSTR.WS' for ambiguous 
*			 reference purpose. 
* 
*   revised june/91  : - if there is no linkage to patient mstr from 
*			 claim by ikey, do not abort the program, 
*			 instead print '** UNKNOWN** ' in ohip field 
* 
*   revised may/95   : - pdr 617 
*		       - use 'CLMDTL-ORIG-CLAIM-NBR-IN-BATCH' instead 
*			 of 'CLMDTL-CLAIM-NBR' when moving to the field 
*			 of 'WF-CLAIM-NBR' 
* 
*   revised jan/98   : - s149 unix conversion
*
*   1999/05/07	S.B.   - y2k checked.	
*   revised 2002/Oct/23 M.C.    - r004_claims_work_mstr_new.fd does not exist,
*				  use r004_claims_work_mstr.fd instead
*   2003/dec/09	M.C.	- alpha doc nbr
*   2011/Dec/14 MC1     - correct and split the error  message 7 
*			- do the same as r002b/r002a as Brad suggested

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f001_batch_control_file.slr". 
* 
    copy "f002_claims_mstr.slr". 
* 
    copy "f010_new_patient_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
*   copy "F020_DOCTOR_MSTR.SLR". 
* 
    select r004-work-file 
	assign to "r004wf" 
	organization is sequential. 
* 
 
copy "r004_parm_file.slr". 
* 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
data division. 
file section. 
* 
    copy "f001_batch_control_file.fd". 
* 
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claims_mstr_rec1_2.ws". 
* 
    copy "f010_patient_mstr.fd". 
* 
    copy "f090_constants_mstr.fd". 
* 
* 
*   copy "F020_DOCTOR_MSTR.FD". 
*   copy 'R004_CLAIMS_WORK_MSTR.FD'. 

** 2002/10/23 - MC
**    copy 'r004_claims_work_mstr_new.fd'.  - missing
    copy 'r004_claims_work_mstr.fd'. 
** 2002/10/23 - end

copy "r004_parm_file.fd". 
* 
fd  print-file 
    record contains 132 characters. 
 
01  print-record				pic x(132). 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
	value "r004". 
77  option					pic x. 
77  max-nbr-lines				pic 99   value 60. 
77  ctr-lines					pic 99	   value 70. 
77  ws-reply					pic x. 
77  ws-i-o-pat-ind				pic x. 
77  batch-total					pic s9(6)v99   value zero. 
77  batch-diff					pic s9(6)v99 value zero. 
77  ws-fee-ohip					pic 9(5)v99. 
77  ws-nbr-serv					pic 99. 
77  nbr-rec-processed				pic 9(4). 
77  ws-rev-calcd				pic s9(6)v99  value zero. 
77  rev-calcd-total				pic s9(6)v99  value zero. 
77  update-amt-total				pic s9(6)v99  value zero. 
77  diff-total					pic s9(6)v99  value zero. 
*!77  hold-clmhdr-batch-nbr			pic 9(9). 
77  hold-clmhdr-batch-nbr			pic x(8). 
77  hold-clmhdr-claim-nbr			pic 99. 
*77  ws-doctor-nbr				pic 999. 
77  const-mstr-rec-nbr				pic x. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-pat-mstr				pic x(4). 
77  feedback-docrev-mstr			pic x(4). 
77  feedback-batctrl-file			pic x(4). 
77  feedback-iconst-mstr			pic x(4). 
77  blank-line					pic x(132) value spaces. 
*  eof indicators 
* 
77  eof-batctrl-file				pic x	value "N". 
77  eof-claims-dtl				pic x   value "N". 
77  eof-claims-mstr				pic x   value "N". 
*77  eof-doctor-mstr				pic x	 value "N". 
77  eof-work-file				pic x	value "N". 
77  new-header					pic x    value "N". 
77  sub1					pic 9	value zero. 
77  ss                                          pic 99  comp.
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-batctrl-file			pic x(11) value zero. 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-doc-mstr				pic x(11) value zero. 
*mf 77  status-iconst-mstr			pic x(11) value zero. 
*mf 77  status-sort-file			pic x(11). 

77  common-status-file				pic xx.
77  status-cobol-batctrl-file			pic xx    value zero. 
77  status-cobol-claims-mstr			pic xx	  value zero. 
77  status-cobol-pat-mstr			pic xx	  value zero. 
77  status-cobol-iconst-mstr			pic xx    value zero. 
77  status-prt-file				pic xx    value zero. 
77  status-sort-file				pic xx. 
77  sel-clinic-nbr				pic 99. 
77  claims-occur				pic 9(12). 
77  pat-occur					pic 9(5). 

01 tmp-doc-nbr-alpha.
*01 tmp-batch-nbr-r redefines tmp-doc-nbr-alpha.
    05 tmp-batch-nbr-index                      pic x(1) occurs 8 times. 

01  flag-request-complete                       pic x.
    88  flag-request-complete-y                 value "Y".
    88  flag-request-complete-n                 value "N".
 
01  flag-rec					pic x. 
    88  valid-rec				value "Y". 
    88  invalid-rec				value "N". 
 
* 2003/dec/09 - MC - no reference in pgm 
*01  prev-doc-nbr. 
*    05  prev-dept				pic 9. 
*    05  prev-doctor-nbr			pic 99. 
 
01 totals-table. 
    05  oma-or-ohip occurs 2 times. 
	10  totals occurs 6 times. 
		15  doc-totals			pic s9(7)v99. 
		15  dept-totals			pic s9(7)v99. 
		15  grand-totals		pic s9(7)v99. 

*mf copy "F001_KEY_BATCTRL_FILE.WS". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
 
*copy "F010_KEY_PAT_MSTR.WS". 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-pat-mstr-reads			pic 9(7). 
    05  ctr-work-file-writes			pic 9(7). 
    05  ctr-work-file-reads			pic 9(7). 
    05  ctr-doc-mstr-reads			pic 9(7). 
    05  ctr-invalid-ikey  			pic 9(7). 
    05  ctr-pages				pic 9999. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"INVALID READ ON CONSTANTS MASTER". 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"NO BATCTRL FILE SUPPLIED".    
	10  filler				pic x(60)   value 
		"NO BATCH CONTROL RECORDS FOR CLINIC NUMBER". 
	10  filler				pic x(60)   value 
		"NO APPROPRIATE RECORDS IN BATCTRL FILE". 
	10  err-msg-7. 
* 2011/12/14 - MC1
*	    15  filler				pic x(40)   value 
*		"NO CLAIMS FOR THIS BATCH". 
*	    15  err-msg-7-key			pic x(20). 
            15  filler                          pic x(41)  value
                "NO CLAIM FOR CURRENT BATCH - F001/F002 = ".
*	    15  err-msg-7-key			pic x(20). 
	    15  err-msg-7-keys.                           
                20  miss-batch-nbr             pic x(8).
                20  filler                      pic x value '/'.
                20  miss-f002-batch-nbr         pic x(8).
                20  miss-claim-nbr              pic 99.
	    15  err-msg-red   redefines  err-msg-7-keys.
		20  err-msg-7-key		pic x(19).
* 2011/12/14 - end

* 2011/12/14 - MC1 
*	10  filler				pic x(60)   value 
*		"NO HEADER FOR CURRENT BATCH". 
        10  wrong-claim-err.
            15  filler                          pic x(32)  value
                "DIFFERENT PED - F001/F002 = ".
            15  wrong-batch-nbr                 pic x(8).
            15  wrong-claim-nbr                 pic 99.
            15  filler                          pic x value '/'.
            15  wrong-f001-ped                  pic x(8).
            15  filler                          pic x value '/'.
            15  wrong-f002-ped                  pic x(8).
* 2011/12/14 - end


	10  filler				pic x(60)    value 
		"INVALID MONTH". 
	10  filler				pic x(60)    value 
		"ORIGINAL CLMHDR RECORD FOR ADJUSTMENT DETAIL IS MISSING". 
	10  filler				pic x(60)     value 
		"INVALID BATCH TYPE". 
	10  filler				pic x(60)	value 
		"WORK FILE EMPTY". 
	10  filler				pic x(60)	value	 
		"INVALID READ ON DOCTOR MASTER FILE". 
	10  filler				pic x(60)	value	 
		"INVALID READ ON PATIENT MASTER FILE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 14 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
 
procedure division. 
declaratives. 
 
err-batctrl-file section. 
    use after standard error procedure on batch-ctrl-file.    
err-batctrl. 
*mf    move status-batctrl-file		to common-status-file. 
    move status-cobol-batctrl-file	to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING BATCH CONTROL FILE". 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
*mf    move status-iconst-mstr		to common-status-file. 
    move status-cobol-iconst-mstr	to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING ICONSTANTS MASTER". 
 
err-claim-header-mstr-file section. 
    use after standard error procedure on claims-mstr. 
err-claims-mstr. 
*mf    move status-claims-mstr		to common-status-file. 
    move status-cobol-claims-mstr	to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
 
*err-doc-mstr-file section. 
*  use after standard error procedure on doc-mstr. 
*err-doc-mstr. 
*   move status-doc-mstr		to common-status-file. 
*   display file-status-display. 
*   stop "ERROR IN ACCESSING DOCTOR MASTER". 
 
err-pat-mstr-file section. 
   use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*mf    move status-pat-mstr		to common-status-file. 
    move status-cobol-pat-mstr		to common-status-file. 
*   display file-pat-status-display. 
    display common-status-file. 
    stop "PROGRAM ABORTED - HIT NEWLINE". 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-create-work-file	thru ab0-99-exit. 
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
 
*    expunge r004-work-file. 
*    expunge parameter-file. 
 
    open input	batch-ctrl-file 
		iconst-mstr 
		pat-mstr 
		claims-mstr. 
 
    open output r004-work-file. 
    open output parameter-file. 
 
    move spaces				to 
					   work-file-rec. 
 
 
*	(display screen title/option) 
*   display scr-title. 
 
aa0-10-enter-clinic-nbr. 
 
*   accept scr-clinic-nbr. 
    accept sel-clinic-nbr. 
 
    move sel-clinic-nbr			to	iconst-clinic-nbr-1-2. 
    read iconst-mstr 
      invalid key 
	move 2				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-enter-clinic-nbr. 
 
*   display scr-clinic-ped. 
 
aa0-20-continue. 
 
    move spaces				to ws-reply. 
*   display scr-acpt-continue. 
 
*   accept reply. 
    accept ws-reply. 
 
    if   ws-reply = 'Y' 
      or ws-reply = 'N' 
    then 
	next sentence 
    else 
	move 1				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa0-20-continue. 
*   endif 
 
    if ws-reply = 'N' 
    then 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*   display program-in-progress. 
 
    move sel-clinic-nbr			to	parm-clinic-nbr. 
    move iconst-clinic-name		to	parm-clinic-name. 
    move iconst-date-period-end		to	parm-date-period-end. 
    write parm-file-rec. 
  
*mf    move sel-clinic-nbr			to key-gen-batctrl-file. 
 
*mf    read batch-ctrl-file key is key-gen-batctrl-file approximate 
*mf	invalid key 
*mf	    move 4			to err-ind 
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-end-of-job. 
 
    
    move sel-clinic-nbr			to batctrl-bat-clinic-nbr-1-2. 
    start batch-ctrl-file key is greater than or equal to key-batctrl-file
	invalid key 
	    move 4			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
    read batch-ctrl-file next.
 
    add 1				to ctr-batctrl-file-reads. 
 
    perform aa1-sel-read-next-batctrl	thru aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = "Y" 
    then 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    perform aa11-read-claim		thru aa11-99-exit. 
 
*	(a claim header has been read) 
    move "Y"				to	new-header. 
 
aa0-99-exit. 
    exit. 
 
 
aa1-sel-read-next-batctrl. 
 
    if batctrl-bat-clinic-nbr-1-2 not = sel-clinic-nbr 
    then 
	move 5				to err-ind 
	move "Y"			to eof-batctrl-file 
	go to aa1-99-exit. 
*   (else) 
*   endif 
 
 
*    (report only batches matching the clinic'S P.E.D.  
*	for -- 
*    --       'C'laim batches 
*    --  and  'A'djustment batches type 'B' and 'R' ( ie 'A/B' and 'A/R') 
*    --  and  'P'ayment batches type 'M' (ie. 'P/M')) 
 
    if    (batctrl-date-period-end = iconst-date-period-end) 
      and (   (batctrl-batch-type     = "C") 
           or (    batctrl-batch-type     = "A" 
               and batctrl-adj-cd         = "B" or "R") 
           or (    batctrl-batch-type     = "P" 
               and batctrl-adj-cd         = "M")  )   
    then 
	move "Y"			to	flag-rec 
	go to aa1-99-exit 
    else 
	move "N"			to	flag-rec.        
*   endif 
 
 
    read batch-ctrl-file next 
	at end 
	    move 6			to err-ind 
	    move "Y"			to eof-batctrl-file 
	    go to aa1-99-exit. 
	 
    add 1				to ctr-batctrl-file-reads. 
 
aa1-99-exit. 
    exit. 
aa11-read-claim. 
 
    perform aa2-read-clmhdr		thru aa2-99-exit. 

* 2011/12/12 - MC1 - split / correct error 7 into error 7 & 8   

*    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)
*      or (clmhdr-date-period-end not = batctrl-date-period-end)
*    then
*       (no claims)
*       move 7                          to      err-ind
*	move batctrl-batch-nbr		to	err-msg-7-key 
*       perform za0-common-error        thru    za0-99-exit
*       go to az0-end-of-job.
*   (else)
*   endif

    if   (clmhdr-orig-batch-nbr  not = batctrl-batch-nbr)
    then
*       (no claims for the batch)
        move 7                          to      err-ind
        move batctrl-batch-nbr          to      miss-batch-nbr
        move clmhdr-orig-batch-nbr      to      miss-f002-batch-nbr
        move clmhdr-orig-claim-nbr      to      miss-claim-nbr
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   (else)
*   endif

    if   (clmhdr-date-period-end not = batctrl-date-period-end)
    then
*       (wrong claim for different ped)
        move 8                          to      err-ind
        move batctrl-batch-nbr          to      wrong-batch-nbr
        move clmhdr-orig-claim-nbr      to      wrong-claim-nbr
        move batctrl-date-period-end    to      wrong-f001-ped
        move clmhdr-date-period-end     to      wrong-f002-ped
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   (else)
*   endif
* 2011/12/14 - end
 
 
aa11-99-exit. 
    exit. 
aa2-read-clmhdr. 
 
    move zeros				to 	clmhdr-claim-id 
						claims-occur 
						feedback-claims-mstr. 
 
    move batctrl-batch-nbr		to	clmhdr-batch-nbr. 
    move 1				to	clmhdr-claim-nbr. 
 
*mf    move clmhdr-claim-id		to key-clm-data. 
*mf    move "B"				to key-clm-key-type. 
 
 
*mf    read claims-mstr key is key-claims-mstr approximate 
*mf	invalid key 
*mf	    move 7			to	err-ind 
*mf	    move batctrl-batch-nbr	to	err-msg-7-key 
*mf	    perform za0-common-error	thru	za0-99-exit 
*mf	    go to az0-end-of-job.  
 
    
    move clmhdr-claim-id		to clmdtl-b-data.
    move "B"   				to clmdtl-b-key-type.

    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key 
	    move 7			to	err-ind 
	    move batctrl-batch-nbr	to	err-msg-7-key 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job.  
    read claims-mstr next.
 
    if status-cobol-claims-mstr =  23 
				or 99 
    then 
	move 7				to	err-ind 
	move batctrl-batch-nbr		to	err-msg-7-key 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
*mf    retrieve claims-mstr key fix position 
*mf		into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move 7				to	err-ind 
	move batctrl-batch-nbr		to	err-msg-7-key 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    add 1				to ctr-claims-mstr-reads. 
 
    move clmhdr-orig-batch-nbr		to hold-clmhdr-batch-nbr. 
    move clmhdr-orig-claim-nbr		to hold-clmhdr-claim-nbr. 
 
aa2-99-exit. 
    exit. 
az0-end-of-job. 
 
    close batch-ctrl-file 
	  r004-work-file 
	  parameter-file 
	  iconst-mstr 
	  pat-mstr 
	  claims-mstr. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
ab0-create-work-file. 
 
*    (determine if end of batch) 
    if   clmhdr-orig-batch-nbr  not = batctrl-batch-nbr 
      or clmhdr-date-period-end not = batctrl-date-period-end 
    then 
	perform ga0-read-next-batch	thru	ga0-99-exit. 
*   (else) 
*   endif 
 
    if eof-batctrl-file = "Y" 
    then 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
    move "N"				to	new-header 
						eof-claims-dtl. 
 
    perform ca0-build-wf-rec-from-hdr	thru	ca0-99-exit.   
    perform ba0-process-dtl-recs	thru	ba0-99-exit 
		until eof-claims-dtl = "Y". 
 
    if    eof-claims-mstr     = "N" 
      and new-header      not = "Y" 
    then 
	perform ha0-read-clmhdr-next	thru	ha0-99-exit. 
*   (else) 
*   endif 
 
    if eof-claims-mstr = "N" 
    then 
	go to ab0-create-work-file. 
*   (else) 
*   endif 
 
ab0-99-exit. 
    exit. 
ba0-process-dtl-recs. 
 
    perform da0-read-dtl-next-clm	thru da0-99-exit. 
 
    if eof-claims-dtl = "Y" 
    then 
	go to ba0-99-exit. 
*   (else) 
*   endif 
 
    perform cb0-build-wf-rec-from-dtl	thru	cb0-99-exit. 
    perform cd0-write-to-work-file	thru 	cd0-99-exit. 
 
ba0-99-exit. 
    exit. 
ca0-build-wf-rec-from-hdr. 
 
*    (d e t a i l  rec) 
    move clmhdr-doc-dept		to	wf-dept. 
    move clmhdr-doc-nbr			to	wf-doc-nbr. 
    move clmhdr-pat-acronym6		to 	wf-pat-surname. 
    move clmhdr-pat-acronym3		to 	wf-pat-acronym3. 
 
* the following changed 85/11/05 
*   move clmhdr-pat-key-data		to	wf-pat-id-or-chart. 
    if clmhdr-pat-key-data = spaces or " " 
    then 
        move spaces       		to	wf-pat-id-or-chart 
    else 
        perform ja0-read-pat-mstr	thru	ja0-99-exit. 
*   endif 
 
    move clmhdr-date-sys		to	wf-claim-date-sys. 
    move clmhdr-diag-cd			to	wf-diag-cd. 
    move clmhdr-batch-nbr		to	wf-orig-claim-id. 
    move clmhdr-claim-nbr		to	wf-orig-claim-nbr. 
    move clmhdr-reference		to	wf-ref-field. 
    move clmhdr-adj-cd-sub-type		to	wf-adj-cd-sub-type. 
 
 
ca0-99-exit. 
    exit. 
 
 
 
cb0-build-wf-rec-from-dtl. 
 
*    (d e t a i l  rec) 
*   move clmdtl-batch-nbr		to	wf-claim-batch-nbr. 
    move clmdtl-orig-batch-nbr 		to 	wf-claim-batch-nbr. 
*   move clmdtl-claim-nbr		to	wf-claim-nbr. 
    move clmdtl-orig-claim-nbr-in-batch to	wf-claim-nbr. 
    move clmdtl-fee-oma			to	wf-claim-oma. 
    move clmdtl-fee-ohip		to	wf-claim-ohip. 
    move clmdtl-sv-date			to	wf-service-date. 
    move clmdtl-oma-cd			to	wf-oma-cd. 
    move clmdtl-oma-suff		to	wf-oma-suff. 
 
    add clmdtl-nbr-serv 
	clmdtl-sv-nbr(1) 
	clmdtl-sv-nbr(2) 
	clmdtl-sv-nbr(3)		giving	wf-nbr-serv. 
 
    move clmdtl-adj-cd			to	wf-trans-cd. 
    move clmdtl-agent-cd		to	wf-agent-cd. 
    move clmdtl-adj-cd			to	wf-adj-cd. 
 
cb0-99-exit. 
    exit. 
cd0-write-to-work-file. 
 
    write work-file-rec. 
    add 1				to	ctr-work-file-writes. 
 
cd0-99-exit. 
    exit. 
da0-read-dtl-next-clm. 
 
    move zero				to	claims-occur 
						feedback-claims-mstr. 
 
    read claims-mstr next 
	at end 
	    move "Y"			to eof-claims-dtl 
	    move "Y"			to eof-claims-mstr 
	    go to da0-99-exit. 
 
*mf    retrieve claims-mstr key fix position 
*mf		into key-claims-mstr. 
 
*mf    if key-clm-key-type not = "B" 
    if clmdtl-b-key-type not = "B" 
    then 
	move "Y"			to	eof-claims-dtl 
	move "Y"			to	eof-claims-mstr 
	go to da0-99-exit. 
*   (else) 
*   endif 
    add 1				to	ctr-claims-mstr-reads. 
 
*    (if 'C'laim is being processed then skip adjustment detail recs within claim) 
    if    batctrl-batch-type     = "C" 
      and clmdtl-adj-nbr     not = 0  
    then 
	go to da0-read-dtl-next-clm. 
*   (else) 
*   endif 
 
    if clmdtl-oma-cd = "ZZZZ" 
    then 
	move "Y"			to eof-claims-dtl 
	go to  da0-99-exit. 
*   (else) 
*   endif 
 
    if clmhdr-zeroed-area is numeric 
    then 
	if clmhdr-zeroed-area = zero 
	then 
*	    (header has been read) 
	    move clmhdr-orig-batch-nbr	to	hold-clmhdr-batch-nbr 
	    move clmhdr-orig-claim-nbr	to	hold-clmhdr-claim-nbr 
	    move "Y"			to	new-header 
	    move "Y"			to	eof-claims-dtl 
	    go to da0-10-check-clinic 
	else 
	    next sentence 
*	endif 
    else 
	next sentence.   
*   endif 
 
    if   clmdtl-orig-batch-nbr          not = hold-clmhdr-batch-nbr 
      or clmdtl-orig-claim-nbr-in-batch not = hold-clmhdr-claim-nbr 
    then 
	move "Y"			to new-header 
					   eof-claims-dtl. 
*   (else) 
*   endif 
 
da0-10-check-clinic. 
    if batctrl-bat-clinic-nbr-1-2 not = clmhdr-clinic-nbr-1-2 
    then 
	move "Y"			to	eof-claims-mstr 
	go to da0-99-exit. 
*   (else) 
*   endif 
 
da0-99-exit. 
    exit. 
ga0-read-next-batch. 
 
    read batch-ctrl-file next 
	at end 
	    move "Y"			to eof-batctrl-file 
	    go to ga0-99-exit. 
 
    add 1				to ctr-batctrl-file-reads. 
 
    move "N"				to	flag-rec. 
    perform aa1-sel-read-next-batctrl	thru aa1-99-exit 
	until   eof-batctrl-file = "Y" 
	     or valid-rec. 
 
    if eof-batctrl-file = 'Y' 
    then 
	go to ga0-99-exit. 
*   (else) 
*   endif 
 
*	(if the current claim header that was read is not the correct 
*	 batch number then read the header with the new batch number) 
 
    if   clmhdr-orig-batch-nbr  not = batctrl-batch-nbr 
      or clmhdr-date-period-end not = batctrl-date-period-end    
    then 
	perform aa11-read-claim		thru	aa11-99-exit. 
*   (else) 
*   endif 
 
ga0-99-exit. 
    exit. 
ha0-read-clmhdr-next. 
 
*mf    move zero				to	key-clm-data 
    move zero				to	clmdtl-b-data 
						claims-occur 
						feedback-claims-mstr. 
 
*	temporary fix to catch desc records incorrectly created 
*	without original batch and claim numbers   84/06/27 
 
    if clmdtl-orig-batch-id = spaces 
    then 
	move clmdtl-batch-nbr 		to clmdtl-orig-batch-nbr 
	move clmdtl-claim-nbr		to clmdtl-orig-claim-nbr-in-batch. 
*   endif 
* 

* 2003/dec/09 - MC - below has defined as 9(10) but it will cause problem
*!    add 1				to	clmdtl-orig-complete-batch-nbr. 
*    add 1				to 	clmdtl-orig-claim-nbr-in-batch.
* 2003/dec/09 - end
    if  clmdtl-orig-claim-nbr-in-batch = 99
    then
        move zeros                      to	clmdtl-orig-claim-nbr-in-batch 
        perform xx0-increment-batch-nbr thru    xx0-99-exit
*?        move sces                   to	clmdtl-b-adj-nbr
    else
        add 1                           to	clmdtl-orig-claim-nbr-in-batch.
*?        move spaces                   to clmdtl-b-oma-cd
*?                                         clmdtl-b-oma-suff.
*   endif


*mf    move clmdtl-orig-batch-nbr		to	key-clm-batch-nbr. 
*mf    move clmdtl-orig-claim-nbr-in-batch	to	key-clm-claim-nbr. 
 
*mf    read claims-mstr key is key-claims-mstr approximate 
*mf      at end 
*mf	move "Y"			to	eof-claims-mstr 
*mf	go to ha0-99-exit. 
 
    move clmdtl-orig-batch-nbr		to	clmdtl-b-batch-nbr. 
    move clmdtl-orig-claim-nbr-in-batch	to	clmdtl-b-claim-nbr. 
    start claims-mstr key is greater than or equal to key-claims-mstr.
    read claims-mstr next
      at end 
	move "Y"			to	eof-claims-mstr 
	go to ha0-99-exit. 
 
*mf    retrieve claims-mstr key fix position 
*mf		into key-claims-mstr. 
 
*mf    if   key-clm-key-type      not = "B" 
    if   clmdtl-b-key-type      not = "B" 
      or clmhdr-clinic-nbr-1-2 not = sel-clinic-nbr 
    then 
	move "Y"			to	eof-claims-mstr 
	go to ha0-99-exit. 
*   (else) 
*   endif 
 
    add 1				to	ctr-claims-mstr-reads. 
    move clmhdr-orig-batch-nbr		to	hold-clmhdr-batch-nbr.   
    move clmhdr-orig-claim-nbr		to	hold-clmhdr-claim-nbr. 
 
ha0-99-exit. 
    exit. 

xx0-increment-batch-nbr.
*0 - 9 A - Z
    move "N"                            to      flag-request-complete.

    if clmdtl-orig-batch-number = 999
    then
        move clmdtl-orig-doc-number     to      tmp-doc-nbr-alpha
        display "BEFORE: " clmdtl-orig-doc-number
        perform xx1-process-1-doc-position  thru xx1-99-exit
            varying   ss from 3 by -1
            until     ss = 0
               or      flag-request-complete-y
        move tmp-doc-nbr-alpha          to       clmdtl-orig-doc-number
        display "AFTER : " clmdtl-orig-doc-number 
        display " "
        move 000                        to       clmdtl-orig-batch-number
    else
        add 1                           to       clmdtl-orig-batch-number.
*   endif


xx0-99-exit.
   exit.

xx1-process-1-doc-position.
*if pos(1) = 0 then 1 , if 1 then 2 if 9 then A, if A then B if Z then 0 and!

    if tmp-batch-nbr-index(ss) = "0"
    then
        move "1"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "1"
    then
        move "2"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "2"
    then
        move "3"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "3"
    then
        move "4"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "4"
    then
        move "5"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "5"
    then
        move "6"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "6"
    then
        move "7"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "7"
    then
        move "8"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "8"
    then
        move "9"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "9"
    then
        move "A"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "A"
    then
        move "B"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "B"
    then
        move "C"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "C"
    then
        move "D"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "D"
    then
        move "E"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "E"
    then
        move "F"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "F"
    then
        move "G"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "G"
    then
        move "H"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "H"
    then
        move "I"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "I"
    then
        move "J"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "J"
    then
        move "K"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "K"
    then
        move "L"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "L"
    then
        move "M"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "M"
    then
        move "N"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "N"
    then
        move "O"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "O"
    then
        move "P"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "P"
    then
        move "Q"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
* 2004/11/18 -- it should check 'Q' instead of 'B'
*    if tmp-batch-nbr-index(ss) = "B"
    if tmp-batch-nbr-index(ss) = "Q"
* 2004/11/18 - end
    then
        move "R"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "R"
    then
        move "S"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "S"
    then
        move "T"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "T"
    then
        move "U"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "U"
    then
        move "V"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "V"
    then
        move "W"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "W"
    then
        move "X"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "X"
    then
        move "Y"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "Y"
    then
        move "Z"                        to      tmp-batch-nbr-index(ss)
        go to xx1-90-return
    else
    if tmp-batch-nbr-index(ss) = "Z"
    then
        move "0"                        to      tmp-batch-nbr-index(ss)
        go to xx0-99-exit.
*   endif

xx1-90-return.
    move "Y"                            to      flag-request-complete.

xx1-99-exit.
    exit. 
ja0-read-pat-mstr. 
 
*  this section added 85/11/05 
 
    move clmhdr-pat-ohip-id-or-chart	to	key-pat-mstr. 
 
    read pat-mstr 
         invalid key 
 
* 
*   the following three lines are commented and replaced by the next 
*   1 line  by mc on 91/06/20 
 
*            move 14			to	err-ind 
*            perform za0-common-error	thru	za0-99-exit 
*            perform err-pat-mstr. 
 
	     move "*** UNKNOWN ***"	to pat-ohip-mmyy-r. 
 
*            add 1			to ctr-invalid-ikey 
*            go to ja0-99-exit. 
 
    add 1				to ctr-pat-mstr-reads. 
 
    if pat-health-nbr not = 0 
    then 
        move pat-health-nbr             to      wf-pat-id-or-chart 
    else 
    	if pat-ohip-mmyy-r not = spaces 
    	then 
            move pat-ohip-mmyy-r	to	wf-pat-id-or-chart 
    	else 
            move pat-chart-nbr 		to	wf-pat-id-or-chart. 
*   endif 
 
ja0-99-exit. 
    exit. 
 
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
