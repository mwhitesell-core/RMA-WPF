identification division. 
program-id. u035a. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 85/11. 
date-compiled. 
security. 
* 
*    files	: f002    - claims master 
*               : f002    - claim shadow 
*               : f010    - patient master 
*		: u035wf  - work file 
*		: ru035a  - print file 
* 
* 
*    program purpose : to print the direct billing invoices 
*		       this pgm is the first series of the 3 pgms. 
*		       this pgm accesses claim shadow master and 
*		       claims master before creating a work file. 
* 
*    revision may/87 (s.b.) - coversion from aos to aos/vs. 
*                             change field size for 
*                             status clause to 2 and 
*                             feedback clause to 4. 
* 
*    revision feb/89 (s.f.) - sms 113 
*                           - add the access to the claims master file 
*                             to allow for the addition of the agent 
*                             in the work file so that agent can be 
*                             added to the sort and agent control totals 
*                             can be printed at the break. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   rev. 91/03/06  (b.m.l.) - sms 138 
*                           - remove pat-key-mstr from working storage. 
* 
*   rev. 92/03/23  (m.c.)   - pdr 550 
*			    - do not select agent 4 claims into work 
*			      file 
* 1999/jan/31 B.E.	- y2k
*
* 2003/dec/10 M.C.	- alpha doc nbr


environment division. 
input-output section. 
file-control. 
  
* 
    copy "f002_claims_mstr.slr". 
* 
    copy "f002_claim_shadow.slr". 
* 
    copy "f010_new_patient_mstr.slr". 
* 
    select u035-work-file 
	assign to "u035wf" 
	organization is sequential. 
 
    select print-file 
	assign to printer print-file-name 
	file status is status-prt-file. 
 
data division. 
file section. 
 
    copy "f002_claims_mstr.fd". 
* 
    copy "f002_claim_shadow.fd". 
* 
    copy "f010_patient_mstr.fd". 
* 
    copy "u035_clm_shdw_work_mstr.fd". 
 
 
fd  print-file 
    record contains 132 characters. 
 
01  print-rec   				pic x(132). 
working-storage section. 
 
* 
*  file related working storage 
* 
 
77  claims-occur				pic 9999. 
77  pat-occur					pic 9999. 
77  feedback-claims-mstr			pic x(4). 
77  feedback-pat-mstr				pic x(4). 
 
*  	the print file is created for error purposes. if the ikey from 
*	the claim shadow mstr does not exist in pat mstr, then the 
*	claim shadow record will be printed. 
 
77  print-file-name				pic x(06)   value "ru035a". 
 
01 clms-mstr-flag				pic x. 
   88  clms-mstr-exist	      	                value "Y". 
   88  clms-mstr-not-exist			value "N". 
 
 
01 pat-flag					pic x. 
   88  pat-exist				value "Y". 
   88  pat-not-exist				value "N". 
 
*  status file indicators 
 
01 status-indicators. 
    05  common-status-file			pic x(2). 
*mf    05  common-status-file			pic x(11). 
*mf    05  status-claims-mstr			pic x(11) value zero. 
*mf    05  status-pat-mstr				pic x(11) value zero. 
    05  status-prt-file				pic xx    value zero. 
    05  status-cobol-claims-mstr		pic xx	  value zero. 
    05  status-cobol-clm-shadow			pic xx	  value zero. 
    05  status-cobol-pat-mstr			pic xx	  value zero. 
 
*mf    copy "F002_KEY_CLAIMS_MSTR.WS". 
 
    copy "f002_claim_shadow.fw". 
 
 
**01  key-pat-mstr. 
**  05  pat-key-type				pic a. 
**  05  pat-key-o-c-a				pic x(15). 
 
* 
*    screen related working storage 
* 
 
77  ws-reply					pic x  value "P". 
77  err-ind					pic 99. 
 
 
01  counters. 
    05  ctr-clm-shdw-reads 			pic 9(7). 
    05  ctr-clm-shdw-writes			pic 9(7). 
    05  ctr-invalid-pat-reads			pic 9(7). 
    05  ctr-invalid-clms-mstr-reads             pic 9(7). 
 
* 
*	print lines 
* 
 
   	 
01  prt-head. 
    05  filler				pic x(8)	value spaces. 
    05  filler				pic x(5)	value "AGENT". 
    05  filler				pic x(8)	value spaces. 
    05  filler				pic x(6)	value "CLINIC". 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(3)	value "SUB". 
    05  filler				pic x(8)	value spaces. 
    05  filler				pic x(12)	value "PATIENT KEY". 
    05  filler				pic x(5) 	value spaces. 
    05  filler				pic x(8) 	value "BATCH #". 
    05  filler				pic x(2) 	value spaces. 
    05  filler				pic x(7) 	value "CLAIM #". 
    05  filler				pic x(56)	value spaces. 
 
 
01 prt-line. 
    05  filler				pic x(10)	value spaces. 
    05  p-agent 			pic 9. 
    05  filler				pic x(12)	value spaces. 
    05  p-clinic			pic 99. 
    05  filler				pic x(7)	value spaces. 
    05  p-subdivision			pic x. 
    05  filler				pic x(6)	value spaces. 
    05  p-pat-key			pic x(16). 
    05  filler				pic x(02)	value spaces. 
*!    05  p-batch-no			pic 9(09). 
    05  p-batch-no			pic x(08). 
    05  filler				pic x(04)	value spaces. 
    05  p-claim-no			pic 9(02). 
    05  filler				pic x(63)	value spaces. 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID READ ON CLAIMS MSTR". 
	10  filler				pic x(60)   value 
		"INVALID READ ON PAT MSTR". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 02 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
    copy "sysdatetime.ws". 
 
screen section. 
 
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
    05  blank screen. 
    05  line 16 col 28 value "PROGRAM U035A IN PROGRESS". 
 
01  scr-closing-screen. 
    05  line 07 col 20  value "# OF CLM SHADOW READS". 
    05  line 07 col 50 pic 9(7)  from ctr-clm-shdw-reads. 
    05  line 09 col 20  value "# OF CLM SHADOW WRITES". 
    05  line 09 col 50 pic 9(7)  from ctr-clm-shdw-writes. 
    05  line 11 col 20  value "# OF INVALID CLM MSTR READS". 
    05  line 11 col 50 pic 9(7)  from ctr-invalid-clms-mstr-reads. 
    05  line 13 col 20  value "# OF INVALID PAT READS". 
    05  line 11 col 50 pic 9(7)  from ctr-invalid-pat-reads. 
    05  line 21 col 20	value "PROGRAM U035A ENDING". 
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
    05  line 23 col 20	value "PRINT REPORT IS IN FILE RU035A". 
    05  line 23 col 55  value " -- RUN U035B FOR SORT". 
procedure division. 
declaratives. 
 
copy "f002_claim_shadow.ds". 
 
err-claims-mstr-file section. 
    use after standard error procedure on claims-mstr. 
err-claims-mstr. 
*mf move status-claims-mstr             to	common-status-file. 
    move status-cobol-claims-mstr       to	common-status-file. 
*   display file-status-display. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*mf move status-pat-mstr		to	common-status-file. 
    move status-cobol-pat-mstr		to	common-status-file. 
*   display file-status-display. 
    stop "ERROR IN ACCESSING PATIENT MASTER". 
 
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
 
    accept sys-time 			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
*   display program-in-progress. 
 
    open	input	claims-mstr 
                        claim-shadow-mstr 
			pat-mstr. 
 
*    expunge u035-work-file. 
    open output u035-work-file. 
*    expunge print-file. 
    open output print-file. 
 
    move 'N'				to flag-eof-clm-shadow-mstr. 
    move zero				to counters. 
 
    write print-rec from prt-head after advancing page. 
    move spaces				to print-rec. 
    write print-rec after advancing 2 lines. 
 
    perform ya0-read-claim-shadow-next	thru ya0-99-exit. 
 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
*   (read pat-mstr to extract pat-surname, pat-given-name.) 
*   (read claims-mstr to extract clmrec-hdr-agent-cd.) 
 
    perform yb0-read-patient		thru yb0-99-exit. 
    perform yc0-read-claims-mstr        thru yc0-99-exit. 
 
    if pat-exist 
    then 
         if clms-mstr-exist 
         then 
	     perform ba0-create-work-file	thru ba0-99-exit 
         else 
	     perform xa0-write-error-report	thru xa0-99-exit 
*        endif 
    else 
        perform xa0-write-error-report	thru xa0-99-exit. 
*   endif 
 
 
    perform ya0-read-claim-shadow-next	thru ya0-99-exit. 
 
ab0-99-exit. 
 
    exit. 
az0-end-of-job. 
 
    close claims-mstr 
          claim-shadow-mstr 
	  pat-mstr 
	  u035-work-file 
	  print-file. 
 
*   display blank-screen. 
*   accept sys-time			from time. 
*   display scr-closing-screen. 
*   display confirm. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
ba0-create-work-file. 
 
    if clmrec-hdr-agent-cd = 4 
    then 
	go to ba0-99-exit. 
*   endif 
 
    move clmrec-hdr-agent-cd            to wf-shadow-agent. 
    move clm-shadow-clinic		to wf-shadow-clinic. 
    move clm-shadow-subdivision 	to wf-shadow-subdivision. 
    move pat-surname            	to wf-shadow-pat-surname. 
    move pat-given-name            	to wf-shadow-pat-giv-name. 
    move clm-shadow-patient        	to wf-shadow-patient. 
    move clm-shadow-batch-nbr        	to wf-shadow-batch-nbr. 
    move clm-shadow-claim-nbr        	to wf-shadow-claim-nbr. 
 
*   write wf-shadow-rec. 
    write wf-shadow-sort-key. 
 
    add 1				to ctr-clm-shdw-writes. 
 
ba0-99-exit. 
    exit. 
 
 
ya0-read-claim-shadow-next. 
 
    move zero 				to claims-mstr-shadow-occur. 
 
    read claim-shadow-mstr next 
	at end 
		move 'Y' 		to flag-eof-clm-shadow-mstr 
		go to ya0-99-exit. 
 
    add 1                  		to ctr-clm-shdw-reads. 
 
 
ya0-99-exit. 
 
    exit. 
 
 
yb0-read-patient. 
 
    move zero                 		to pat-occur. 
    move clm-shadow-patient	 	to key-pat-mstr. 
 
    read pat-mstr 
	invalid key 
	    move "N"    		to pat-flag 
	    add 1			to ctr-invalid-pat-reads. 
 
    move "Y"				to pat-flag. 
 
yb0-99-exit. 
    exit. 
 
 
yc0-read-claims-mstr. 
 
    move zero                 		to claims-occur. 
*mf    move "B"			        to key-clm-key-type. 
*mf    move zero			to key-clm-data. 
*mf    move clm-shadow-batch-nbr	to key-clm-batch-num. 
*mc    move clm-shadow-claim-nbr	to key-clm-claim-nbr. 
    move "B"			        to clmdtl-b-key-type.
    move zero				to clmdtl-b-data.
    move clm-shadow-batch-nbr		to clmdtl-b-batch-num. 
    move clm-shadow-claim-nbr		to clmdtl-b-claim-nbr. 
 
*mf    read claims-mstr 
    read claims-mstr key is key-claims-mstr
	invalid key 
	    move "N"    		to clms-mstr-flag 
	    add 1			to ctr-invalid-clms-mstr-reads. 
 
    move "Y"				to clms-mstr-flag. 
 
yc0-99-exit. 
    exit. 
xa0-write-error-report. 
 
    move clmrec-hdr-agent-cd            to p-agent. 
    move clm-shadow-clinic		to p-clinic. 
    move clm-shadow-subdivision		to p-subdivision. 
    move clm-shadow-patient   		to p-pat-key. 
    move clm-shadow-batch-nbr 		to p-batch-no. 
    move clm-shadow-claim-nbr 		to p-claim-no. 
 
    write print-rec from prt-line after advancing 2 lines. 
 
xa0-99-exit. 
 
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".