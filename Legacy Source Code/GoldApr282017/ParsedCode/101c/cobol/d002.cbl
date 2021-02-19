identification division. 
program-id. d002. 
author. dyad computer systems inc. 
installation. rma. 
date-written. february 1980. 
date-compiled. 
security. 
*
* read BACKWARDS M I S S I N G !!!!!
* 
*    files	: f001  - batch control file 
*		: f002  - claims master 
*		: f010  - patient master 
* 
*    program purpose : claims deletion             
* 
* 
*    revision  85/03/05  (ms)	- change codes to use invisible key 
*				  to access pat-mstr and/or claims-mstr. 
* 
*    revision  85/11/27  (ms)   - pdr 283 
*				- invalid numeric digit 
*				- changes made in aa3-display-claim 
* 
*    revision  87/05/27  (sb)   - coversion from aos to aos/vs. 
*                                 change field size for 
*                                 status clause to 2 and 
*                                 feedback clause to 4. 
* 
*    revised dec/87 (j.l.) - pdr 356 
*			   - after error message is displayed, hit 
*			     space bar to return to keying field 
* 
*    revision march/89   (sf)  - sms 115 
*		       	       - make sure file status is pic xx , 
*			         feedback is pic x(4) and infos status 
*				 is pic x(11). 
* 
* 
*    revision 93/02/10   (mc)  - pdr 564 
*			       - check the reply only allow 'y' or 'n 
*   2003/dec/08	M.C.		- alpha doc nbr
*   2004/may/05 M.C.		- disable the numeric check against acpt-claim-id 
*   2004/may/10 M.C.		- the batch nbr on the detail line has displayed wrong
*				  it only display x(7) instead of x(8)
*   2010/jan/22 b.e.		- allow deletion of claims with more than 8 details

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
data division. 
file section. 
* 
    copy "f001_batch_control_file.fd". 
* 
    copy "f002_claims_mstr.fd". 
* 
    copy "f010_patient_mstr.fd". 
* 
working-storage section. 
 
77  option					pic x. 
77  pat-count					pic s999. 
77  pat-occur					pic 9(12). 
77  claims-occur				pic 9(12). 
77  display-key-type				pic x(7). 
77  subs-table-addr				pic 99	  comp. 
77  ss-clmdtl					pic 99  value 0. 
77  ss-nbr-fnd					pic 999. 
77  ss-nbr					pic 999. 
77  temp					pic 999. 
77  end-job					pic x   value "N". 
77  ws-hosp-nbr					pic x(4). 
77  ws-pat-acronym				pic x(9). 
77  ws-pat-id     				pic x(12). 
77  ws-more-msg					pic x(14). 
77  ws-sel-nbr					pic 99. 
77  end-search-index				pic x	value "N". 
77  ws-total-nbr-svc				pic 9(7). 
77  flag-del					pic x. 
* 
*  eof flags 
* 
77  eof-pat-mstr				pic x	value "N". 
77  eof-claims-mstr				pic x	value "N". 
77  eof-batctrl-file				pic x	value "N". 
 
77  confirm-space				pic x   value space. 
 
 
01  acpt-claim-id. 
    05  acpt-claim. 
	10  acpt-claim-clinic			pic 99.      
	10  acpt-claim-clinic-r redefines acpt-claim-clinic. 
	    15  acpt-claim-clinic-1		pic x. 
	    15  filler				pic x. 
*!	10  acpt-claim-doc-nbr			pic 999. 
	10  acpt-claim-doc-nbr			pic xxx. 
	10  acpt-claim-week			pic 99. 
	10  acpt-claim-day			pic 9. 
	10  acpt-claim-claim-nbr		pic 99. 
    05  acpt-acronym redefines acpt-claim	pic x(10). 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
 
01  flag-ohip-vs-chart				pic x. 
    88  ohip					value "O". 
    88  chart					value "C". 
 
01  flag-found-batch				pic x. 
    88  flag-found-batch-y			value "Y". 
    88  flag-found-batch-n			value "N". 
 
01  flag-batch-status				pic x. 
    88  flag-batch-status-ok 			value "Y". 
    88  flag-batch-status-not-ok		value "N". 
 
01  flag-del-clm				pic x. 
    88  flag-del-clm-y				value "Y". 
    88  flag-del-clm-n				value "N". 
 
01  flag-valid-ohip-or-chart			pic x. 
    88  valid-ohip				value "Y". 
    88  valid-chart				value "Y". 
    88  invalid-ohip				value "N". 
    88  invalid-chart				value "N". 
 
01  flag-ohip-mmyy				pic x. 
 
    88  valid-mmyy				value "Y". 
    88  invalid-mmyy				value "N". 
 
 
77  err-ind					pic 99 	value zero. 
77  password-input				pic x(3). 
77  password 					pic x(3)  value "RMA". 
77  reply					pic x. 
77  change-reply				pic x. 
 
77  hold-feedback-clmhdr			pic x(6).   
*!77  hold-key-claims-mstr			pic x(18). 
77  hold-key-claims-mstr			pic x(17). 
77  hold-pat-key-data				pic x(15). 
*!77  hold-batch-nbr				pic 9(9)	value 0. 
77  hold-batch-nbr				pic x(8)	value spaces.
77  hold-claim-nbr				pic 99		value 0. 
77  ws-clmhdr-delete				pic x. 
77  ws-disp-pat-key-type			pic x(7). 
77  ws-disp-pat-err-msg				pic x(42). 
*!77  ws-doc-nbr					pic 9(6). 
77  ws-doc-nbr					pic x(3). 
77  ws-batctrl-amt-diff				pic 9(5)v99. 
77  ws-nbr-clmdtl-recs				pic 99. 
77  ws-batctrl-svc-diff				pic 9(5)v99. 
77  ws-file-err-msg				pic x(42)  value spaces. 
77  ws-i-o-pat-ind				pic x. 
77  ws-oma-cd					pic x999. 
77  ws-oma-suff					pic a. 
77  ws-loc					pic xxxx. 
 
01  ws-date. 
* (y2k)
*    05  ws-yy					pic 99. 
    05  ws-yy					pic 9(04).
    05  ws-mm					pic 99.    
    05  ws-dd					pic 99. 
 
copy "sysdatetime.ws". 
 
* 
*  subscripts 
* 
77  ss						pic 99	comp. 
77  subs-hosp					pic 99  comp. 
77  ss-clmhdr					pic 99	comp. 
77  ss-clmdtl-oma				pic 99	comp. 
77  ss-clmdtl-desc				pic 99	comp. 
77  ss-conseq-dd				pic 99	comp. 
77  ss-det-nbr					pic 99	comp. 
77  ss-ind					pic 99	comp. 
* 
*	(subscripts for hold-oma-records table) 
77  ss-card-colour-ind				pic 99	comp  value 1. 
77  ss-diag-ind					pic 99	comp  value 2. 
77  ss-phy-ind					pic 99	comp  value 3. 
77  ss-hosp-nbr-ind				pic 99	comp  value 4. 
77  ss-i-o-ind					pic 99	comp  value 5. 
77  ss-admit-ind				pic 99	comp  value 6. 
 
* 
*	(maximum values or limits that may have to be changed 
*		if record layouts are altered) 
* 
77  ss-max-nbr-locs-in-doc-rec			pic 99	comp	value  20. 
77  ss-max-nbr-of-desc-rec-allow		pic 99	comp	value  5. 
 
 
* 
*  feedback values for all indexed files 
* 
77  feedback-claims-mstr			pic x(4). 
77  feedback-pat-mstr				pic x(4). 
77  feedback-batctrl-file			pic x(4). 
* 
*  eof flags 
* 
77  eof-filename-here				pic x	value "N". 
* 
*  status file indicators 
* 
77  status-common				pic x(2). 
77  status-claims-mstr				pic x(11)	value zero. 
77  status-cobol-claims-mstr			pic xx. 
77  status-pat-mstr				pic x(11)	value zero. 
77  status-cobol-pat-mstr			pic xx. 
77  status-batctrl-file				pic x(11)	value zero. 
77  status-cobol-batctrl-file			pic xx. 
 
 
* 
*  keys (and/or record layouts) for all indexed files 
* 
 
*mfcopy "f001_key_batctrl_file.ws". 
 
*mfcopy "f002_key_claims_mstr.ws". 
 
copy "f002_claims_mstr_rec1_2.ws". 
 
01  ws-hold-clmdtl-batch-nbr. 
* 2004/05/10 - MC
*    05  ws-clinic-nbr1				pic 9. 
    05  ws-clinic-nbr1				pic 99. 
* 2004/05/10 - end
    05  ws-doc-nbr. 
*!	10  filler				pic 99. 
*!	10  ws-doc-nbr3				pic 999. 
	10  ws-doc-nbr3				pic xxx. 
    05  ws-week-day				pic 999. 
 
** 01  pat-occur					pic 9(3). 
 
 
   
01  option					pic x. 
    88  new-batch				value "1". 
    88  old-batch				value "2". 
    88  stop-option				value "S". 
 
01  flag-err-data				pic x. 
    88  err-data				value "N".    
    88  ok-data					value "Y".     
 
01  flag-done-clmdtl-recs			pic x. 
 
    88  done-clmdtl-recs-yes			value "Y". 
 
01  flag-eoj					pic x. 
    88  eoj-create-new-patient			value "C". 
    88  eoj					value "E". 
 
 
*   counters for records read/written for all input/output files 
 
01  reply-create-pat				pic x. 
 
    88  new-patient				value "Y". 
    88  err-patient				value "N". 
 
01  counters. 
    05  ctr-read-batctrl-mstr			pic 9(7). 
    05  ctr-read-claims-mstr			pic 9(7). 
    05  ctr-read-pat-mstr			pic 9(7). 
 
    05  ctr-writ-batctrl-file			pic 9(7). 
    05  ctr-writ-claims-mstr			pic 9(7). 
 
    05  ctr-rewrit-batctrl-mstr			pic 9(7). 
    05  ctr-rewrit-claims-mstr			pic 9(7). 
 
 
copy "hosp_table.ws". 
01  hold-claim-detail. 
 
    05  hold-clm-table-1. 
*!	10  hold-clm-id-1		pic 9(7). 
	10  hold-clm-id-1		pic x(8). 
	10  hold-clm-clm-nbr-1		pic 99. 
	10  hold-clm-cyc-1		pic 999.           
* (y2k)
*	10  hold-clm-per-end-date-1	pic x(6). 
	10  hold-clm-per-end-date-1	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-1		pic x(6). 
	10  hold-clm-svc-date-1		pic x(8). 
	10  hold-clm-oma-cd-1		pic x999. 
	10  hold-clm-oma-suff-1		pic x. 
	10  hold-clm-svc-1		pic 99. 
	10  hold-clm-agent-1		pic 9.      
	10  hold-clm-adj-cd-1		pic x. 
	10  hold-clm-card-col-1		pic x. 
	10  hold-clm-amt-due-1		pic s9(5)v99. 
    05  hold-clm-table-2. 
*!	10  hold-clm-id-2		pic 9(7). 
	10  hold-clm-id-2		pic x(8). 
	10  hold-clm-clm-nbr-2		pic 99. 
	10  hold-clm-cyc-2		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-2	pic x(6). 
	10  hold-clm-per-end-date-2	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-2		pic x(6). 
	10  hold-clm-svc-date-2		pic x(8). 
	10  hold-clm-oma-cd-2		pic x999. 
	10  hold-clm-oma-suff-2		pic x. 
	10  hold-clm-svc-2		pic 99. 
	10  hold-clm-agent-2		pic 9. 
	10  hold-clm-adj-cd-2		pic x. 
	10  hold-clm-card-col-2		pic x. 
	10  hold-clm-amt-due-2		pic s9(5)v99. 
    05  hold-clm-table-3. 
*!	10  hold-clm-id-3		pic 9(7). 
	10  hold-clm-id-3		pic x(8). 
	10  hold-clm-clm-nbr-3		pic 99. 
	10  hold-clm-cyc-3		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-3	pic x(6). 
	10  hold-clm-per-end-date-3	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-3		pic x(6). 
	10  hold-clm-svc-date-3		pic x(8). 
	10  hold-clm-oma-cd-3		pic x999. 
	10  hold-clm-oma-suff-3		pic x. 
	10  hold-clm-svc-3		pic 99. 
	10  hold-clm-agent-3		pic 9. 
	10  hold-clm-adj-cd-3		pic x. 
	10  hold-clm-card-col-3		pic x. 
	10  hold-clm-amt-due-3		pic s9(5)v99. 
    05  hold-clm-table-4. 
*!	10  hold-clm-id-4		pic 9(7). 
	10  hold-clm-id-4		pic x(8). 
	10  hold-clm-clm-nbr-4		pic 99. 
	10  hold-clm-cyc-4		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-4	pic x(6). 
	10  hold-clm-per-end-date-4	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-4		pic x(6). 
	10  hold-clm-svc-date-4		pic x(8). 
	10  hold-clm-oma-cd-4		pic x999. 
	10  hold-clm-oma-suff-4		pic x. 
	10  hold-clm-svc-4		pic 99. 
	10  hold-clm-agent-4		pic 9. 
	10  hold-clm-adj-cd-4		pic x. 
	10  hold-clm-card-col-4		pic x. 
	10  hold-clm-amt-due-4		pic s9(5)v99. 
    05  hold-clm-table-5. 
*!	10  hold-clm-id-5		pic 9(7). 
	10  hold-clm-id-5		pic x(8). 
	10  hold-clm-clm-nbr-5		pic 99. 
	10  hold-clm-cyc-5		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-5	pic x(6). 
	10  hold-clm-per-end-date-5	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-5		pic x(6). 
	10  hold-clm-svc-date-5		pic x(8). 
	10  hold-clm-oma-cd-5		pic x999. 
	10  hold-clm-oma-suff-5		pic x. 
	10  hold-clm-svc-5		pic 99. 
	10  hold-clm-agent-5		pic 9. 
	10  hold-clm-adj-cd-5		pic x. 
	10  hold-clm-card-col-5		pic x. 
	10  hold-clm-amt-due-5		pic s9(5)v99. 
    05  hold-clm-table-6. 
*!	10  hold-clm-id-6		pic 9(7). 
	10  hold-clm-id-6		pic x(8). 
	10  hold-clm-clm-nbr-6		pic 99. 
	10  hold-clm-cyc-6		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-6	pic x(6). 
	10  hold-clm-per-end-date-6	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-6		pic x(6). 
	10  hold-clm-svc-date-6		pic x(8). 
	10  hold-clm-oma-cd-6		pic x999. 
	10  hold-clm-oma-suff-6		pic x. 
	10  hold-clm-svc-6		pic 99. 
	10  hold-clm-agent-6		pic 9. 
	10  hold-clm-adj-cd-6		pic x. 
	10  hold-clm-card-col-6		pic x. 
	10  hold-clm-amt-due-6		pic s9(5)v99. 
    05  hold-clm-table-7. 
*!	10  hold-clm-id-7		pic 9(7). 
	10  hold-clm-id-7		pic x(8). 
	10  hold-clm-clm-nbr-7		pic 99. 
	10  hold-clm-cyc-7		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-7	pic x(6). 
	10  hold-clm-per-end-date-7	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-7		pic x(6). 
	10  hold-clm-svc-date-7		pic x(8). 
	10  hold-clm-oma-cd-7		pic x999.    
	10  hold-clm-oma-suff-7		pic x. 
	10  hold-clm-svc-7		pic 99. 
	10  hold-clm-agent-7		pic 9. 
	10  hold-clm-adj-cd-7		pic x. 
	10  hold-clm-card-col-7		pic x. 
	10  hold-clm-amt-due-7		pic s9(5)v99. 
    05  hold-clm-table-8. 
*!	10  hold-clm-id-8		pic 9(7). 
	10  hold-clm-id-8		pic x(8). 
	10  hold-clm-clm-nbr-8		pic 99. 
	10  hold-clm-cyc-8		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date-8	pic x(6). 
	10  hold-clm-per-end-date-8	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date-8		pic x(6). 
	10  hold-clm-svc-date-8		pic x(8). 
	10  hold-clm-oma-cd-8		pic x999. 
	10  hold-clm-oma-suff-8		pic x. 
	10  hold-clm-svc-8		pic 99. 
	10  hold-clm-agent-8		pic 9. 
	10  hold-clm-adj-cd-8		pic x. 
	10  hold-clm-card-col-8		pic x. 
	10  hold-clm-amt-due-8		pic s9(5)v99. 
 
01  hold-claim-detail-r redefines hold-claim-detail. 

*brad1 - 2010/jan/22 
*    05  hold-detail occurs 8 times. 
    05  hold-detail occurs 100 times. 
*brad1 - 2010/jan/22 
 
	10  hold-clm-id. 
* 2004/05/10 - MC
*	    15  hold-clm-clinic-nbr	pic 9. 
	    15  hold-clm-clinic-nbr	pic 99. 
* 2004/05/10 - end
*!	    15  hold-clm-doc-nbr 	pic 999. 
	    15  hold-clm-doc-nbr 	pic xxx. 
	    15  hold-clm-week-day	pic 999. 
	10  hold-clm-clm-nbr		pic 99. 
	10  hold-clm-cyc		pic 999. 
* (y2k)
*	10  hold-clm-per-end-date	pic x(6). 
	10  hold-clm-per-end-date	pic x(8). 
* (y2k)
*	10  hold-clm-svc-date		pic x(6). 
	10  hold-clm-svc-date		pic x(8). 
	10  hold-clm-oma-cd		pic x999. 
	10  hold-clm-oma-suff		pic x. 
	10  hold-clm-svc		pic 99. 
	10  hold-clm-agent		pic 9. 
	10  hold-clm-adj-cd		pic x. 
	10  hold-clm-card-col		pic x. 
	10  hold-clm-amt-due		pic s9(5)v99. 
 
01  hold-clmhdr-bal			pic s9(5)v99. 
 
01  hold-descriptions. 
	10  hold-desc-1			pic x(22).     
	10  hold-desc-2			pic x(22). 
	10  hold-desc-3			pic x(22). 
	10  hold-desc-4			pic x(22). 
	10  hold-desc-5			pic x(22). 
01  hold-descs-r   redefines   hold-descriptions. 
	10  hold-descs	occurs 5 times. 
	    15  hold-desc		pic x(22). 
 
***********    the following section is commented out dec 5/89 ********* 
***********           it is not used by the program            ********* 
** s.f. 
 
 
*	(subscripts for this table in 'ss-oma-subscripts') 
*01  hold-oma-records. 
*	( 6 detail recs) 
*10  hold-oma-rec-occur	   occurs  6  times. 
*	    (6 indicators for each detail rec) 
*           15  hold-oma-rec-ind	pic x	occurs  6  times. 
*	    15  hold-oma-spec-fr	pic 99. 
*	    15  hold-oma-spec-to	pic 99. 
*	    15  hold-oma-add-on-cd-1	pic x999. 
*	    15  hold-oma-add-on-cd-2	pic x999. 
 
*01  hold-fees-oma-ohip. 
*	10  hold-fee-oma-occur. 
*	    15  hold-fee-oma-1		pic s9(5)v99. 
*	    15  hold-fee-oma-2		pic s9(5)v99. 
*	    15  hold-fee-oma-3		pic s9(5)v99. 
* 	    15  hold-fee-oma-4		pic s9(5)v99. 
*	    15  hold-fee-oma-5		pic s9(5)v99. 
*	    15  hold-fee-oma-6		pic s9(5)v99. 
*	10  hold-fee-oma-occur-r  redefines  hold-fee-oma-occur. 
*		20  hold-fee-oma	pic s9(5)v99  occurs 6 times. 
*	10  hold-fee-ohip-occur. 
*	    15  hold-fee-ohip-1		pic s9(5)v99. 
*	    15  hold-fee-ohip-2		pic s9(5)v99. 
*	    15  hold-fee-ohip-3		pic s9(5)v99. 
*	    15  hold-fee-ohip-4		pic s9(5)v99. 
*	    15  hold-fee-ohip-5		pic s9(5)v99. 
*	    15  hold-fee-ohip-6		pic s9(5)v99. 
*	10  hold-fee-ohip-occur-r  redefines  hold-fee-ohip-occur. 
* 	    15  hold-fee-ohip		pic s9(5)v99  occurs  6  times. 
 
 
01  ws-val-err-msg-mask. 
    05  ws-err-diag			pic x. 
    05  ws-err-oma-cd-1			pic x. 
    05  ws-err-oma-cd-2			pic x. 
    05  ws-err-oma-cd-3			pic x. 
    05  ws-err-oma-cd-4			pic x. 
    05  ws-err-oma-cd-5			pic x. 
    05  ws-err-oma-cd-6			pic x. 
    05  ws-err-oma-msg-star		pic x. 
    05  ws-err-oma-msg			pic x(50). 
 
01  error-message-table. 
 
    05  error-messages. 
* msg #1 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"NO SUCH BATCH NUMBER EXISTS IN THE BATCH CONTROL FILE". 
	10  filler				pic x(60)   value 
		"INVALID PASSWORD".         
	10  filler				pic x(60)   value 
		"CLAIM NUMBER NOT FOUND". 
	10  filler				pic x(60)   value 
		"YOU CAN'T DELETE 'P'AYMENT OR 'A'DJUSTMENT ENTRIES". 
	10  filler				pic x(60)   value 
		"ADMIT DATE > CURRENT SYSTEM DATE". 
	10  filler				pic x(60)   value 
		"DOCTOR SPECIFIED IS INVALID". 
	10  filler				pic x(60)   value 
		"OMA CODES INPUT REQUIRE NON-ZERO DIAGNOSTIC CODE". 
	10  filler				pic x(60)   value 
		"SERIOUS CONDITION !! -- BATCH'S DOCTOR NOT FOUND IN DOC MSTR".   
* msg #10 
	10  filler				pic x(60)   value 
		"INVALID LOCATION FOR BATCH'S DOCTOR". 
	10  filler				pic x(60)   value 
		"INVALID HOSPITAL NUMBER". 
	10  filler				pic x(60)   value 
		"IN/OUT PATIENT CODE MUST BE 'I' OR 'O'". 
	10  filler				pic x(60)   value 
		"INVALID OHIP NBR / CHART ID -- PLEASE CORRECT". 
	10  filler				pic x(60)   value 
		"BATCH TYPE MUST BE 'C', 'P', OR 'A'". 
	10  filler				pic x(60)   value 
		"INVALID WEEK NUMBER IN BATCH ID". 
	10  filler				pic x(60)   value 
		"INVALID DAY IN BATCH ID". 
	10  filler				pic x(60)   value 
		"PATIENT OHIP NBR DOESN'T EXIST". 
	10  filler				pic x(60)   value 
		"PATIENT CHART NBR DOESN'T EXIST". 
	10  filler				pic x(60)   value 
		"1ST DIGIT OF CLINIC # MUST = 1ST DIGIT OF BATCH #". 
* msg #20 
	10  filler				pic x(60)   value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)   value 
		"SERIOUS CONDITION !!! - INVALID CLAIMS MSTR INDEX POINTER".   
	10  filler				pic x(60)   value 
		"SUBSCRIBER DOES NOT EXIST ". 
	10  filler				pic x(60)   value 
		"NO CLAIMS ALLOWED - PATIENT OHIP STATUS = 'J2','J8', OR 'K1'". 
	10  filler				pic x(60)	value 
		"NO CLAIMS ALLOWED - PATIENT OHIP STATUS = K4,K5,K6,K7, OR K9". 
	10  filler				pic x(60)	value 
		"SELECTED NBR > NBR OF SELECTIONS AVAILABLE ". 
	10  filler				pic x(60)	value 
		"NO MORE PATIENTS TO DISPLAY ". 
	10  filler				pic x(60)	value 
		"SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE". 
	10  filler				pic x(60)	value 
		"INVALID OMA CODE". 
	10  filler				pic x(60)	value 
		"SERIOUS CONDITION #1 - INVALID WRITE ON CLAIMS HEADER INDX 1". 
* msg #30 
	10  filler				pic x(60)	value 
		"SERIOUS CONDITION #2 - INVALID WRITE ON CLAIMS HEADER INDX 2". 
	10  filler				pic x(60)	value 
		"SERIOUS CONDITION !! -- INVALID WRITE ON CLAIMS DETAIL REC". 
	10  filler				pic x(60)	value 
		"# SERVICES FROM DAY DOES NOT FALL WITHIN # DAYS IN MONTH". 
	10  filler				pic x(60)	value 
		"SERVICE DATE < ADMIT DATE". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES A REFERRING PHYSICAN". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES A HOSPITAL #". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'I'". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'O'". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES AN ADMIT DATE". 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES DOCTOR SPECIALTY CODE BE WITHIN RANGE". 
* msg #40 
	10  filler				pic x(60)	value 
		"'OHIP' AGENT REQUIRES SERVICE WITHIN 6 MTHS OF SYSTEM DATE". 
	10  filler				pic x(60)	value 
		"DAY INPUT FALLS WITHIN PREVIOUS CONSEQUTIVE DAY RANGE". 
	10  filler				pic x(60)	value 
		"BATCH ALREADY EXISTS". 
	10  filler				pic x(60)	value 
		"PATIENT ACRONYM NOT FOUND".       
	10  filler				pic x(60)	value 
		"INVALID DIAGNOSTIC CODE". 
	10  filler				pic x(60)	value 
		"SERVICE DATE > SYSTEM DATE".    
	10  filler				pic x(60)	value 
		"LAST CLAIM FOR ENTERED ACRONYM". 
	10  filler				pic x(60)	value 
		"OMA CODE'S SUFFIX MUST BE 'A','B','C', OR 'M'". 
	10  filler				pic x(60)	value 
		"AT END OF CLAIMS MASTER ". 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR!!! BATCH RECORD DOESN'T EXIST (CAN'T DELETE)". 
 
* msg #50 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR ON BATCH CONTROL RE-WRITE". 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR WHILE ATTEMPTING TO RE-READ CLAIM HEADER". 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR IN ATTEMPTING TO READ A CLAIM WITH A 'P' TYPE".     
	10  filler				pic x(60)	value 
		"INVALID REWRITE TO PATIENT MASTER". 
	10  filler				pic x(60)	value 
		"INVALID DELETE ON CLAIM PATIENT INDEX". 
	10  filler				pic x(60)	value 
		"INVALID DELETE ON CLAIM HEADER OR DETAIL RECORD". 
	10  filler				pic x(60)	value 
*mf		"SERIOUS ERROR! NO DETAIL RECORD FOR HEADER". 
		"NO DETAIL RECORD FOR HEADER OR REACH END OF FILE". 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR! INVALID BATCH DELETION". 
	10  filler				pic x(60)	value 
		"SERIOUS ERROR! INVALID READ ON PATIENT MASTER". 
	10  filler				pic x(60)	value 
		"CLAIM CAN'T BE DELETED -- BATCH ALREADY SENT TO OHIP".  
* msg #60 
	10  filler				pic x(60)	value 
		"CLAIM NUMBER MUST BE NUMERIC". 
	10  filler				pic x(60)	value 
		"VERIFY BATCH ISN'T CURRENTLY ACCESSED ON ANOTHER SCREEN". 
	10  filler				pic x(60)	value 
		"BATCH EXISTS WITH NO CLAIMS, IT MUST BE MANUALLY DELETED". 
	10  filler				pic x(60)	value 
		"CLAIM HDR P.E.D. DOESN'T MATCH BATCHES P.E.D. (CAN'T DELETE)". 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 63 times.   
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
screen section. 
 
 
01  scr-title-claim-rec-data. 
 
    05  blank screen. 
    05  line 01 col 01 value is "D002". 
    05  line 01 col 33 value is "- CLAIM DELETE -". 
* (y2k - auto fix)
*   05  line 01 col 73 pic 99 using sys-yy. 
    05  line 01 col 70 pic 9(4) using sys-yy. 
    05  line 01 col 74 value "/". 
    05  line 01 col 75 pic 99 using sys-mm. 
    05  line 01 col 77 value "/". 
    05  line 01 col 78 pic 99 using sys-dd. 
* 
 
01  scr-acpt-claim-id. 
    05  line 03 col 01 value "CLAIM #-". 
    05  scr-claim-id line 03 col 09 pic x(10)  
				using acpt-claim-id auto required. 
 
01  scr-acpt-clmhdr. 
    05  line 03 col 23 value "PATIENT-". 
    05  line 03 col 32 pic x(15) using pat-surname. 
    05  line 03 col 48 value "FIRST-". 
    05  line 03 col 55 pic x(12) using pat-given-name. 
    05  line 03 col 68 value "INITS-". 
    05  line 03 col 75 pic xxx using pat-init. 
 
    05  line 05 col 01 value "H/C NBR-". 
    05  line 05 col 10 pic x(10) using pat-health-nbr. 
    05  line 05 col 23 value "ID-". 
    05  line 05 col 27 pic x(12) using ws-pat-id. 
    05  line 05 col 43 value "CHART-". 
    05  line 05 col 50 pic x(10) using pat-chart-nbr. 
    05  line 05 col 67 value "DIAGNOSIS-". 
    05  line 05 col 78 pic xxx using clmhdr-diag-cd. 
 
    05  line 07 col 01 value "BATCH #". 
    05  line 07 col 09 pic xx using clmhdr-clinic-nbr-1-2. 
*!    05  line 07 col 11 pic 999 using clmhdr-doc-nbr. 
    05  line 07 col 11 pic xxx using clmhdr-doc-nbr. 
    05  line 07 col 14 pic xx using clmhdr-week. 
    05  line 07 col 16 pic x using clmhdr-day. 
    05  line 07 col 17 value "-". 
    05  line 07 col 18 pic xx using clmhdr-claim-nbr. 
    05  line 07 col 21 value "DOCTOR #-". 
*!    05  line 07 col 31 pic 999 using clmhdr-doc-nbr. 
    05  line 07 col 31 pic xxx using clmhdr-doc-nbr. 
    05  line 07 col 36 value "LOC -". 
    05  line 07 col 42 pic xxxx using clmhdr-loc. 
    05  line 07 col 48 value "HOSP". 
    05  line 07 col 53 pic x(4) using ws-hosp-nbr. 
    05  line 07 col 58 value "ADMIT". 
* (y2k - auto fix)
*   05  line 07 col 64 pic xx using clmhdr-date-admit-yy. 
    05  line 07 col 64 pic xxxx using clmhdr-date-admit-yy. 
*    05  line 07 col 66 value "/". 
* (y2k - auto fix)
*   05  line 07 col 67 pic xx using clmhdr-date-admit-mm. 
    05  line 07 col 68 pic xx using clmhdr-date-admit-mm. 
*    05  line 07 col 69 value "/". 
    05  line 07 col 70 pic xx using clmhdr-date-admit-dd. 
    05  line 07 col 73 value "AGENT-". 
    05  line 07 col 80 pic x using clmhdr-agent-cd. 
 
    05  line 09 col 01 value "TAPE SUB". 
    05  line 09 col 10 pic x using clmhdr-tape-submit-ind. 
    05  line 09 col 14 value "IN/OUT". 
    05  line 09 col 22 pic x using clmhdr-i-o-pat-ind. 
    05  line 09 col 25 value "REF -". 
    05  update-ref line 09 col 31 pic x(9) using clmhdr-reference. 
    05  line 09 col 42 value "REASON-". 
;    05  line 09 col 50 pic xx using clmhdr-doc-spec-cd. 
    05  line 09 col 50 pic xx using clmhdr-status-ohip. 
    05  line 09 col 57 value "CASH/DATE-". 
* (y2k - auto fix)
*   05  line 09 col 68 pic xx/xx/xx using clmhdr-date-cash-tape-payment. 
    05  line 09 col 68 pic xxxx/xx/xx using clmhdr-date-cash-tape-payment. 
 
    05  line 10 col 21 value 
		"----------------------------------------". 
    05  line 11 col 02 value  
		"BATCH     CYC   PERIOD   SERVICE     OMA  #S AG C". 
    05  line 11 col 53 value 
		"AMOUNT   DESCRIPTION RECORDS". 
    05  line 12 col 01 value 
		"NUMBER     #   END DATE      DATE    CODE". 
    05  line 12 col 50 value "C     DUE". 
 
01  scr-dis-clmdet-1. 
 
* 2004/05/10 - MC
*   05  line 13 col 01 pic x(7) 	using hold-clm-id-1. 
*   05  line 13 col 08      		value "-". 
    05  line 13 col 01 pic x(8)		using hold-clm-id-1. 
* 2004/05/10 - end
    05  line 13 col 09 pic xx		using hold-clm-clm-nbr-1. 
    05  line 13 col 12 pic xxx		using hold-clm-cyc-1. 
* (y2k - auto fix)
*   05  line 13 col 17 pic xx/xx/xx	using hold-clm-per-end-date-1. 
    05  line 13 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-1. 
* (y2k - auto fix)
*   05  line 13 col 27 pic xx/xx/xx	using hold-clm-svc-date-1. 
    05  line 13 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-1. 
    05  line 13 col 38 pic x(4)		using hold-clm-oma-cd-1. 
    05  line 13 col 42 pic x		using hold-clm-oma-suff-1. 
    05  line 13 col 44 pic z9		using hold-clm-svc-1. 
    05  line 13 col 47 pic 9 		using hold-clm-agent-1. 
    05  line 13 col 48 pic x		using hold-clm-adj-cd-1. 
    05  line 13 col 50 pic x		using hold-clm-card-col-1. 
    05  line 13 col 51 pic zzzz9.99-	using hold-clm-amt-due-1. 
 
01  scr-dis-clmdet-2. 
 
* 2004/05/10 - MC
*   05  line 14 col 01 pic x(7)		using hold-clm-id-2. 
*   05  line 14 col 08      		value "-". 
    05  line 14 col 01 pic x(8)		using hold-clm-id-2. 
* 2004/05/10 - end
    05  line 14 col 09 pic xx		using hold-clm-clm-nbr-2. 
    05  line 14 col 12 pic xxx		using hold-clm-cyc-2. 
* (y2k - auto fix)
*   05  line 14 col 17 pic xx/xx/xx	using hold-clm-per-end-date-2. 
    05  line 14 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-2. 
* (y2k - auto fix)
*   05  line 14 col 27 pic xx/xx/xx	using hold-clm-svc-date-2. 
    05  line 14 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-2. 
    05  line 14 col 38 pic x(4)		using hold-clm-oma-cd-2. 
    05  line 14 col 42 pic x		using hold-clm-oma-suff-2. 
    05  line 14 col 44 pic z9		using hold-clm-svc-2. 
    05  line 14 col 47 pic 9 		using hold-clm-agent-2. 
    05  line 14 col 48 pic x		using hold-clm-adj-cd-2. 
    05  line 14 col 50 pic x		using hold-clm-card-col-2. 
    05  line 14 col 51 pic zzzz9.99-	using hold-clm-amt-due-2. 
 
01  scr-dis-clmdet-3. 
 
* 2004/05/10 - MC 
*   05  line 15 col 01 pic x(7)		using hold-clm-id-3. 
*   05  line 15 col 08      		value "-". 
    05  line 15 col 01 pic x(8)		using hold-clm-id-3. 
* 2004/05/10 - end
    05  line 15 col 09 pic xx		using hold-clm-clm-nbr-3. 
    05  line 15 col 12 pic xxx		using hold-clm-cyc-3. 
* (y2k - auto fix)
*   05  line 15 col 17 pic xx/xx/xx	using hold-clm-per-end-date-3. 
    05  line 15 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-3. 
* (y2k - auto fix)
*   05  line 15 col 27 pic xx/xx/xx	using hold-clm-svc-date-3. 
    05  line 15 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-3. 
    05  line 15 col 38 pic x(4)		using hold-clm-oma-cd-3. 
    05  line 15 col 42 pic x		using hold-clm-oma-suff-3. 
    05  line 15 col 44 pic z9		using hold-clm-svc-3. 
    05  line 15 col 47 pic 9 		using hold-clm-agent-3. 
    05  line 15 col 48 pic x		using hold-clm-adj-cd-3. 
    05  line 15 col 50 pic x		using hold-clm-card-col-3. 
    05  line 15 col 51 pic zzzz9.99-	using hold-clm-amt-due-3. 
 
01  scr-dis-clmdet-4. 
 
* 2004/05/10 - MC
*   05  line 16 col 01 pic x(7)		using hold-clm-id-4. 
*   05  line 16 col 08      	 	value "-". 
    05  line 16 col 01 pic x(8)		using hold-clm-id-4. 
* 2004/05/10 - end
    05  line 16 col 09 pic xx		using hold-clm-clm-nbr-4. 
    05  line 16 col 12 pic xxx		using hold-clm-cyc-4. 
* (y2k - auto fix)
*   05  line 16 col 17 pic xx/xx/xx	using hold-clm-per-end-date-4. 
    05  line 16 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-4. 
* (y2k - auto fix)
*   05  line 16 col 27 pic xx/xx/xx	using hold-clm-svc-date-4. 
    05  line 16 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-4. 
    05  line 16 col 38 pic x(4)		using hold-clm-oma-cd-4. 
    05  line 16 col 42 pic x		using hold-clm-oma-suff-4. 
    05  line 16 col 44 pic z9		using hold-clm-svc-4. 
    05  line 16 col 47 pic 9 		using hold-clm-agent-4. 
    05  line 16 col 48 pic x		using hold-clm-adj-cd-4. 
    05  line 16 col 50 pic x		using hold-clm-card-col-4. 
    05  line 16 col 51 pic zzzz9.99-	using hold-clm-amt-due-4. 
 
01  scr-dis-clmdet-5. 

* 2004/05/10 - MC 
*   05  line 17 col 01 pic x(7)		using hold-clm-id-5. 
*   05  line 17 col 08      		value "-". 
    05  line 17 col 01 pic x(8)		using hold-clm-id-5. 
* 2004/05/10 - end
    05  line 17 col 09 pic xx		using hold-clm-clm-nbr-5. 
    05  line 17 col 12 pic xxx		using hold-clm-cyc-5. 
* (y2k - auto fix)
*   05  line 17 col 17 pic xx/xx/xx	using hold-clm-per-end-date-5. 
    05  line 17 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-5. 
* (y2k - auto fix)
*   05  line 17 col 27 pic xx/xx/xx	using hold-clm-svc-date-5. 
    05  line 17 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-5. 
    05  line 17 col 38 pic x(4)		using hold-clm-oma-cd-5. 
    05  line 17 col 42 pic x		using hold-clm-oma-suff-5. 
    05  line 17 col 44 pic z9		using hold-clm-svc-5. 
    05  line 17 col 47 pic 9 		using hold-clm-agent-5. 
    05  line 17 col 48 pic x		using hold-clm-adj-cd-5. 
    05  line 17 col 50 pic x		using hold-clm-card-col-5. 
    05  line 17 col 51 pic zzzz9.99-	using hold-clm-amt-due-5. 
 
01  scr-dis-clmdet-6. 

* 2004/05/10 - MC 
*   05  line 18 col 01 pic x(7)		using hold-clm-id-6. 
*   05  line 18 col 08      		value "-". 
    05  line 18 col 01 pic x(8)		using hold-clm-id-6. 
* 2004/05/10 - end
    05  line 18 col 09 pic xx		using hold-clm-clm-nbr-6. 
    05  line 18 col 12 pic xxx		using hold-clm-cyc-6. 
* (y2k - auto fix)
*   05  line 18 col 17 pic xx/xx/xx	using hold-clm-per-end-date-6. 
    05  line 18 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-6. 
* (y2k - auto fix)
*   05  line 18 col 27 pic xx/xx/xx	using hold-clm-svc-date-6. 
    05  line 18 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-6. 
    05  line 18 col 38 pic x(4)		using hold-clm-oma-cd-6. 
    05  line 18 col 42 pic x		using hold-clm-oma-suff-6. 
    05  line 18 col 44 pic z9		using hold-clm-svc-6. 
    05  line 18 col 47 pic 9 		using hold-clm-agent-6. 
    05  line 18 col 48 pic x		using hold-clm-adj-cd-6. 
    05  line 18 col 50 pic x		using hold-clm-card-col-6. 
    05  line 18 col 51 pic zzzz9.99-	using hold-clm-amt-due-6. 
 
01  scr-dis-clmdet-7. 

* 2004/05/10 - MC
*   05  line 19 col 01 pic x(7)		using hold-clm-id-7. 
*   05  line 19 col 08      		value "-". 
    05  line 19 col 01 pic x(8)		using hold-clm-id-7. 
* 2004/05/10 - end
    05  line 19 col 09 pic xx		using hold-clm-clm-nbr-7. 
    05  line 19 col 12 pic xxx		using hold-clm-cyc-7. 
* (y2k - auto fix)
*   05  line 19 col 17 pic xx/xx/xx	using hold-clm-per-end-date-7. 
    05  line 19 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-7. 
* (y2k - auto fix)
*   05  line 19 col 27 pic xx/xx/xx	using hold-clm-svc-date-7. 
    05  line 19 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-7. 
    05  line 19 col 38 pic x(4)		using hold-clm-oma-cd-7. 
    05  line 19 col 42 pic x		using hold-clm-oma-suff-7. 
    05  line 19 col 44 pic z9		using hold-clm-svc-7. 
    05  line 19 col 47 pic 9 		using hold-clm-agent-7. 
    05  line 19 col 48 pic x		using hold-clm-adj-cd-7. 
    05  line 19 col 50 pic x		using hold-clm-card-col-7. 
    05  line 19 col 51 pic zzzz9.99-	using hold-clm-amt-due-7. 
 
01  scr-dis-clmdet-8. 

* 2004/05/10 - MC 
*   05  line 20 col 01 pic x(7)		using hold-clm-id-8. 
*   05  line 20 col 08      		value "-". 
    05  line 20 col 01 pic x(8)		using hold-clm-id-8. 
* 2004/05/10 - MC 
    05  line 20 col 09 pic xx		using hold-clm-clm-nbr-8. 
    05  line 20 col 12 pic xxx		using hold-clm-cyc-8. 
* (y2k - auto fix)
*   05  line 20 col 17 pic xx/xx/xx	using hold-clm-per-end-date-8. 
    05  line 20 col 16 pic xxxx/xx/xx	using hold-clm-per-end-date-8. 
* (y2k - auto fix)
*   05  line 20 col 27 pic xx/xx/xx	using hold-clm-svc-date-8. 
    05  line 20 col 27 pic xxxx/xx/xx	using hold-clm-svc-date-8. 
    05  line 20 col 38 pic x(4)		using hold-clm-oma-cd-8. 
    05  line 20 col 42 pic x		using hold-clm-oma-suff-8. 
    05  line 20 col 44 pic z9		using hold-clm-svc-8. 
    05  line 20 col 47 pic 9 		using hold-clm-agent-8. 
    05  line 20 col 48 pic x		using hold-clm-adj-cd-8. 
    05  line 20 col 50 pic x		using hold-clm-card-col-8. 
    05  line 20 col 51 pic zzzz9.99-	using hold-clm-amt-due-8. 
 
01  scr-clr-dtls. 
    05  line 13 col 01 blank line. 
    05  line 14 col 01 blank line. 
    05  line 15 col 01 blank line. 
    05  line 16 col 01 blank line. 
    05  line 17 col 01 blank line. 
    05  line 18 col 01 blank line. 
    05  line 19 col 01 blank line. 
    05  line 20 col 01 blank line. 
 
 
01  scr-dis-desc. 
 
    05  line 13 col 59 pic x(21) using hold-desc-1. 
    05  line 14 col 59 pic x(21) using hold-desc-2. 
    05  line 15 col 59 pic x(21) using hold-desc-3. 
    05  line 16 col 59 pic x(21) using hold-desc-4. 
    05  line 17 col 59 pic x(21) using hold-desc-5. 
 
01  scr-dis-footing. 
 
    05  line 21 col 01 value "ORIGINAL BALANCE-". 
    05  line 21 col 19 pic zzzz9.99- using clmhdr-tot-claim-ar-ohip. 
    05  line 21 col 31 value "AMOUNT PAID-". 
    05  line 21 col 44 pic zzzz9.99- using  
				clmhdr-manual-and-tape-paymnts. 
    05  line 21 col 58 value "BALANCE DUE-". 
    05  line 21 col 71 pic zzzz9.99- using hold-clmhdr-bal. 
 
01  scr-acpt-continue. 
 
    05  line 24 col 30 value "CORRECT CLAIM? (Y/N)". 
    05  line 24 col 55 pic x to flag. 
 
* 
01  scr-acpt-id-chart. 
 
    05			line 11 col 18 value "OHIP-ID/CHART:". 
    05  scr-clmhdr-ohip-chart	line 11 col 36 pic xxx9(9) using 
				pat-ohip-mmyy auto required. 
* 
01  scr-acpt-patient-verif. 
 
    05			line 11 col 53 value "CREATE NEW PATIENT (Y/N)". 
    05  scr-clmhdr-pat-verif 
			line 11 col 78 pic x to reply-create-pat auto. 
 
01  scr-acpt-pat-surname. 
 
    05			line 11 col 53 value "PATIENT SURNAME:". 
    05  scr-clmhdr-pat-surname 
			line 11 col 70 pic x(6) using 
			clmhdr-pat-acronym6 auto. 
* 
01  scr-clear-pat-verif. 
 
    05			  line 11 col 53 blank line. 
 
* 
01  scr-acpt-delete-claim. 
    05  line 22 col 25 value "DELETE CLAIM AND ALL DETAILS (Y/N)??". 
    05  line 22 col 62 pic x using ws-clmhdr-delete. 
 
01  scr-acpt-re-try-del-batch. 
    05  line 24 col 01 blank line. 
    05  line 24 col 30 value "TRY TO DELETE BATCH AGAIN (Y/N)". 
    05  line 24 col 62 pic x using flag. 
 
01  blank-line-22. 
    05  line 22 col 1 blank line. 
 
* 
01  scr-error-mask. 
 
    05  scr-err-diag	line 05 col 79 pic x using ws-err-diag. 
    05  scr-err-oma-cd-1 
			line 15 col 01 pic x using ws-err-oma-cd-1. 
    05  scr-err-oma-cd-2 
* just thought it should be 16 s.f. dec 5/89 
*			line 15 col 01 pic x using ws-err-oma-cd-2 
			line 16 col 01 pic x using ws-err-oma-cd-2 
			bell blink. 
    05  scr-err-oma-cd-3 
			line 17 col 01 pic x using ws-err-oma-cd-3 
			bell blink. 
    05  scr-err-oma-cd-4 
			line 18 col 01 pic x using ws-err-oma-cd-4 
			bell blink. 
    05  scr-err-oma-cd-5 
			line 19 col 01 pic x using ws-err-oma-cd-5 
			bell blink. 
    05  scr-err-oma-cd-6 
			line 20 col 01 pic x using ws-err-oma-cd-6 
			bell blink. 
    05  scr-err-oma-msg-star 
			line 21 col 01 pic x using ws-err-oma-msg-star 
			bell blink. 
    05  scr-err-oma-msg	line 21 col 03 pic x(50) using ws-err-oma-msg. 
* 
01  scr-acpt-det-desc. 
 
    05  		line 22 col 01 value "DESC #1:". 
    05  scr-hold-desc-1 
			line 22 col 09 pic x(22) using hold-desc-1 auto. 
    05			line 22 col 31 value      "#2:". 
    05  scr-hold-desc-2 
			line 22 col 34 pic x(22) using hold-desc-2 auto. 
    05			line 22 col 56 value      "#3:". 
    05  scr-hold-desc-3 
			line 22 col 59 pic x(22) using hold-desc-3 auto. 
    05			line 23 col 01 value "DESC #4:". 
    05  scr-hold-desc-4 
			line 23 col 09 pic x(22) using hold-desc-4 auto. 
    05			line 23 col 31 value      "#5:". 
    05  scr-hold-desc-5 
			line 23 col 34 pic x(22) using hold-desc-5 auto. 
* 
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto. 
 
 
01  scr-disp-column-titles. 
 
    05  blank screen. 
    05	scr-disp-pat-title  line 02 col 08 value "* PATIENT DATA *". 
    05		      	    line 02 col 49 value "* SUBSCRIBER DATA *". 
* 
01  scr-acpt-ident-chart. 
 
    05 			line 04 col 01 value "IDENT/CHART     -". 
    05 scr-acpt-ohip-mmyy 
* (y2k - auto fix)
*			line 04 col 18 pic x(12) using pat-ohip-mmyy-r 
			line 04 col 18 pic x(12) using pat-ohip-mmyy-r 
						auto. 
* 
* 
01  err-msg-line. 
    05  line 24 col 01	value " ERROR -  "	bell blink. 
    05  line 24 col 11	pic x(60)	using err-msg-comment. 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  scr-verification-screen. 
    05  line 24 col 30 value "CORRECT PATIENT? (Y/N)". 
    05  line 24 col 55 pic x	to flag. 
 
01 file-status-display. 
    05  line 24 col 01 pic x(42) from ws-file-err-msg. 
    05  line 24 col 44 pic x(7)  from ws-disp-pat-key-type. 
    05  line 24 col 56	"FILE STATUS = ". 
*mf    05  line 24 col 70	pic x(11) using status-common	bell blink. 
    05  line 24 col 70	pic x(2) using status-common	bell blink. 
* 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  verification-screen. 
    05  line 24 col 58	value "ACCEPT (Y/N/M) ". 
    05  line 24 col 73	pic x	to flag. 
 
01  scr-reject-entry. 
    05  line 24 col 50	value "ENTRY IS ". 
    05  line 24 col 59	value "REJECTED"	bell blink. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line  5 col 20  value "# OF BATCH CONTROL READS  =". 
    05  line  5 col 55  pic 9(7) from ctr-read-batctrl-mstr. 
    05  line  6 col 20  value "# OF CLAIMS MASTER READS  =". 
    05  line  6 col 55  pic 9(7) from ctr-read-claims-mstr. 
    05  line  7 col 20  value "# OF PATIENT MSTR  READS  =". 
    05  line  7 col 55  pic 9(7) from ctr-read-pat-mstr. 
    05  line 12 col 20  value "# OF BATCH CONTROL WRITES =". 
    05  line 12 col 55  pic 9(7) from ctr-writ-batctrl-file. 
    05  line 13 col 20  value "# OF CLAIMS MASTER WRITES =". 
    05  line 13 col 55  pic 9(7) from ctr-writ-claims-mstr. 
    05  line 21 col 20	value "PROGRAM D002 ENDING". 
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
 
procedure division. 
declaratives. 
 
err-claims-mstr-file section. 
    use after standard error procedure on claims-mstr.       
err-claims-mstr. 
*mf    move status-claims-mstr		to status-common. 
    move status-cobol-claims-mstr	to status-common. 
    display file-status-display. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
 
err-batctrl-mstr-file section. 
    use after standard error procedure on batch-ctrl-file.       
err-batctrl-file. 
 
    if status-batctrl-file = '7012' 
    then 
	move 'Y'			to flag-del 
    else 
*mf	move status-batctrl-file	to status-common 
	move status-cobol-batctrl-file	to status-common 
	display file-status-display 
	stop "ERROR IN ACCESSING BATCH CONTROL FILE". 
*   endif 
 
err-pat-mstr-file section. 
    use after standard error procedure on pat-mstr. 
err-pat-mstr. 
*   if pat-key-type = "A" 
*   then 
*	move "ACRONYM"			to ws-disp-pat-key-type 
*   else 
*	if pat-key-type = "O" 
*	then 
*	    move "OHIP"			to ws-disp-pat-key-type 
*	else 
*	    if pat-key-type = "C" 
*	    then 
*		move "CHART"		to ws-disp-pat-key-type 
*	    else 
*		move "UNKNOWN"		to ws-disp-pat-key-type. 
*	    endif 
*	endif 
*   endif 
 
    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg. 
*mf    move status-pat-mstr			      to status-common. 
    move status-cobol-pat-mstr			      to status-common. 
    display file-status-display. 
    stop " ". 
    move spaces					      to ws-file-err-msg 
						         ws-disp-pat-key-type. 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit  
	until end-job = "Y". 
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
 
    display scr-title-claim-rec-data. 
 
    open i-o    claims-mstr    
		batch-ctrl-file 
		pat-mstr. 
 
    move zeros			to counters. 
    move spaces			to                        
				   batctrl-rec 
				   ws-val-err-msg-mask 
				   claim-header-rec 
				   claim-detail-rec. 
 
aa0-99-exit. 
    exit. 
aa3-disp-claim. 
 
*	(read claim's header rec) 
 
    perform xc0-read-claims-mstr	thru	xc0-99-exit. 
    if not-ok 
    then 
*	(serious data base error !!! -- 
*	  -- last claim nbr as stored in header rec can't be found) 
	move 4				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	move 'N'			to	ws-clmhdr-delete 
	go to aa3-99-exit. 
 
    if pat-count > -1 
    then 
	if key-pat-mstr = clmhdr-pat-ohip-id-or-chart 
	then 
	    next sentence 
	else 
	    move 46 to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to aa3-99-exit. 
*	endif 
*   (else) 
*   endif 
 
 
    move clmhdr-pat-ohip-id-or-chart	to key-pat-mstr. 
    perform ka0-access-patient		thru	ka0-99-exit. 
 
    if clmhdr-hosp not = spaces
    then 
	perform xf0-move-hosp-nbr	thru xf0-99-exit 
    else 
	move spaces			to ws-hosp-nbr. 
*   endif 
 
* 
*   (the following if-statement is added on 85/03/05.) 
* 
    if pat-ohip-mmyy-r not = spaces 
    then 
	move pat-ohip-mmyy-r		to ws-pat-id 
    else 
	move pat-chart-nbr		to ws-pat-id. 
 
    display scr-acpt-clmhdr. 
 
*	(note - payments are stored as negative amounts, therefore 
*		add payments to original amt owing to obtain 
*		balance due (hold-clmhdr-bal) 
    add clmhdr-tot-claim-ar-ohip , clmhdr-manual-and-tape-paymnts  
					giving hold-clmhdr-bal. 
 
    perform xd0-read-all-clmdtl		thru	xd0-99-exit. 
 
    if ss-clmdtl > 0 
    then 
	display scr-dis-clmdet-1 
	if ss-clmdtl > 1 
	then 
	    display scr-dis-clmdet-2 
	    if ss-clmdtl > 2 
	    then 
		display scr-dis-clmdet-3 
		if ss-clmdtl > 3 
		then 
		    display scr-dis-clmdet-4 
		    if ss-clmdtl > 4 
		    then 
			display scr-dis-clmdet-5 
			if ss-clmdtl > 5 
			then 
			    display scr-dis-clmdet-6 
			    if ss-clmdtl > 6 
			    then 
				display scr-dis-clmdet-7 
				if ss-clmdtl > 7 
				then 
				    display scr-dis-clmdet-8 
				else 
				    next sentence 
*				endif 
			    else 
				next sentence 
*			    endif 
			else 
			    next sentence 
*			endif 
		    else 
			next sentence 
*		    endif 
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
	next sentence. 
*   endif 
 
    display scr-dis-desc. 
    display scr-dis-footing. 
 
 
*	(can't delete 'p'ayment and 'a'djustment entries) 
    if clmhdr-batch-type =    "P" 
			   or "A"  
    then 
	move 5				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move 'N'			to flag-del-clm 
	go to aa3-99-exit 
    else 
	move 'Y'			to flag-del-clm. 
*   endif 
 
aa3-90-reply. 
 
    move "N"				to ws-clmhdr-delete. 
    display scr-acpt-delete-claim. 
    accept  scr-acpt-delete-claim. 
 
*   pdr 561 - check the reply value - 93/02/10 by mc 
 
    if ws-clmhdr-delete = 'Y' or  'N' 
    then 
	next sentence 
    else 
	move 1			to err-ind 
	perform za0-common-error thru za0-99-exit 
	go to aa3-90-reply. 
*   endif 
 
aa3-99-exit. 
    exit. 
az0-end-of-job. 
 
******************************************************************* 
*								  * 
*	if a batch record is presently accessed on another screen * 
*	then the last claim nbr and nbr of claims will be zero.   * 
*	in this case the batch record would not have been deleted * 
*	the following will check for this condition.		  * 
*								  * 
******************************************************************* 
 
    if    ws-clmhdr-delete		= 'Y' 
      and batctrl-last-claim-nbr	= zero 
      and batctrl-nbr-claims-in-batch	= zero 
    then 
	perform ma41-del-phys-batch	thru ma41-99-exit. 
*   (else) 
*   endif 
 
az0-10-end-of-job. 
 
    display blank-screen. 
    accept sys-time			from time. 
    display scr-closing-screen. 
    display confirm. 
    stop " ".
 
    close pat-mstr 
	  batch-ctrl-file 
	  claims-mstr. 
 
    call program "$obj/menu". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    move -1 to pat-count. 
 
ab0-10-acpt-claim-id. 
 
    display scr-acpt-claim-id. 
    accept scr-claim-id. 
 
*	(allow operator to shut down) 
    if acpt-claim-clinic-1 = "*" 
    then 
	move "Y"			to end-job 
	go to ab0-99-exit. 
*   (else) 
*   endif 
 
* 2004/05/05 - MC - disable the edit check
**    if acpt-claim-id not numeric 
**    then 
**	move spaces			to acpt-claim-id 
**	move 60				to err-ind 
**	perform za0-common-error	thru za0-99-exit 
**	go to ab0-10-acpt-claim-id. 
* 2004/05/05 - end

*   (else) 
*   endif 
 
*mf    move "B"				to key-clm-key-type. 
*mf move acpt-claim-clinic		to key-clm-clinic-nbr-1-2. 
*mf move acpt-claim-doc-nbr		to key-clm-doc-nbr. 
*mf move acpt-claim-week		to key-clm-week. 
*mf move acpt-claim-day			to key-clm-day. 
*mf move acpt-claim-claim-nbr		to key-clm-claim-nbr. 
*mf move zeros				to key-clm-oma-cd 
*mf					   key-clm-oma-suff 
*mf					   key-clm-adj-nbr. 
    move "B"				to clmdtl-b-key-type. 
    move acpt-claim-clinic		to clmdtl-b-clinic-nbr-1-2. 
    move acpt-claim-doc-nbr		to clmdtl-b-doc-nbr. 
    move acpt-claim-week		to clmdtl-b-week. 
    move acpt-claim-day			to clmdtl-b-day. 
    move acpt-claim-claim-nbr		to clmdtl-b-claim-nbr. 
    move zeros				to clmdtl-b-oma-cd 
					   clmdtl-b-oma-suff 
					   clmdtl-b-adj-nbr. 
 
    perform ma2-access-batctrl		thru ma2-99-exit. 
 
    perform aa3-disp-claim		thru aa3-99-exit. 
 
    if   flag-del-clm-n 
      or ws-clmhdr-delete = 'N' 
    then 
	go to ab0-90-clr-dtls. 
*   (else) 
*   endif 
 
    if flag-found-batch-n 
 
    then 
	move 49				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to ab0-90-clr-dtls. 
*   (else) 
*   endif 
 
    perform ba1-verify-batch-for-del	thru ba1-99-exit. 
 
 
    if flag-batch-status-not-ok 
    then 
	go to ab0-90-clr-dtls. 
*   (else) 
*   endif 
 
    perform ba3-verify-clm-for-del	thru ba3-99-exit. 
 
    if flag-del-clm-y 
    then 
	perform ma0-clmhdr-detail-phys-del 
					thru ma0-99-exit. 
*   (else) 
*   endif 
 
ab0-90-clr-dtls. 
 
    display scr-clr-dtls. 
 
ab0-99-exit. 
    exit. 
 
 
 
ba1-verify-batch-for-del. 
 
    if batctrl-batch-status =    '0' 
			      or '1' 
    then 
	move 'Y'			to flag-batch-status 
    else 
	move 59				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move 'N'			to flag-batch-status. 
*   endif 
 
ba1-99-exit. 
    exit. 
 
 
 
ba3-verify-clm-for-del. 
 
    if clmhdr-date-period-end not = batctrl-date-period-end 
    then 
	move 63				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	move 'N'			to flag-del-clm. 
*   (else) 
*   endif 
 
ba3-99-exit. 
    exit. 
ka0-access-patient. 
 
    move "N"				to flag. 
    read pat-mstr 
	invalid key 
	    move "N"			to flag 
	    go to ka0-99-exit. 
    move "Y"				to flag. 
    add 1				to ctr-read-pat-mstr. 
 
ka0-99-exit. 
    exit. 
 
 
 
ma0-clmhdr-detail-phys-del. 
 
*   at this point the key contains the correct value for the required 
*   header, but the next data record has been read.  therefore a keyed 
*   read is needed to bring back the required header record. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
*mf restore the claim hdr key before re-read the claim hdr record;
*mf otherwise, the hdr record will not be deleted.

    move hold-key-claims-mstr		to key-claims-mstr.
    
*mf    read claims-mstr into claim-header-rec key is key-claims-mstr 
*mf	invalid key 
*mf	    move 51			to err-ind 
*mf	    perform za0-common-error	thru za0-99-exit 
*mf	    go to az0-end-of-job. 

*mf because it cannot delete the claim header record, instead of read with
*mf specified key, do a approximate read
 
    start claims-mstr key is equal to key-claims-mstr 
	invalid key 
	    move 51			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    read claims-mstr next  into claim-header-rec
	at end        
	    move 56			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
 
    move clmhdr-orig-batch-nbr		to hold-batch-nbr. 
    move clmhdr-orig-claim-nbr		to hold-claim-nbr. 
    move clmhdr-pat-key-data		to hold-pat-key-data. 
    move 0				to ws-total-nbr-svc. 
 
    perform ma5-update-batch-values	thru ma5-99-exit. 
 
 
ma0-10-delete-records. 

    delete claims-mstr record   
*mf			record   physical 
	invalid key 
	    move 55			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
    read claims-mstr next into claim-detail-rec 
	at end 
	    perform zz0-end-of-job	thru zz0-99-exit.

*mf    retrieve claims-mstr key fix position into key-claims-mstr. 
 
*mf if    key-clm-batch-nbr = hold-batch-nbr 
*mf   and key-clm-claim-nbr = hold-claim-nbr 
    if    clmdtl-b-batch-nbr = hold-batch-nbr 
      and clmdtl-b-claim-nbr = hold-claim-nbr 
    then 
	if clmdtl-oma-cd not = "ZZZZ" 
	then 
	    perform ma3-add-nbr-svc-to-ctr 
					thru ma3-99-exit 
	    go to ma0-10-delete-records 
	else 
	    go to ma0-10-delete-records. 
*	endif 
*   else 
*   endif 
 
    perform ma4-check-for-last-claim	thru ma4-99-exit. 
 
    if batctrl-batch-type not = "C" 
    then 
	go to ma0-99-exit. 
*   (else) 
*   endif 

*mf since we do not have to delete 'P' key separately, decrement the nbr of
*mf claim from patient record

*brad1 2010/jan/22 0 bypass since patient fields not used any longer
*    perform ma6-update-patient	thru ma6-99-exit.
*brad1

** mc do not require to read 'P'atient key any more
 
*mf    move zeros				to feedback-claims-mstr 
*mf					   claims-occur. 
 
*mf move spaces				to key-claims-mstr. 
*mf move "P"                 		to key-clm-key-type. 
*mf move hold-pat-key-data		to key-clm-pat-id. 
 
ma0-20-read-claims-mstr. 
 
*mf    read claims-mstr  into claim-header-rec  key is key-claims-mstr  
*mf        invalid key 
*mf  		move 52			to err-ind  
*mf		perform za0-common-error	thru za0-99-exit 
*mf		go to az0-end-of-job. 
 
*mf    retrieve claims-mstr key fix position into key-claims-mstr. 
 
*mf    move "N"				to	end-search-index. 
 
*mf ma0-30-check-for-index. 
 
*mf    if clmhdr-orig-batch-nbr = hold-batch-nbr 
*mf       and clmhdr-orig-claim-nbr = hold-claim-nbr 
*mf    then  
*mf     perform ma7-delete-claim-patient-key 
*mf					thru ma7-99-exit 
*mf	perform ma6-update-patient	thru ma6-99-exit 
*mf    else 
*mf        perform ma1-read-claim-next-for-index 
*mf					thru ma1-99-exit 
*mf        if end-search-index = "N" 
*mf        then  
*mf            go to ma0-30-check-for-index. 
*       (else) 
*       endif 
*   endif 
 
*  (index deleted at this point). 
 
ma0-99-exit. 
    exit. 
 
 
 
ma1-read-claim-next-for-index. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
    read claims-mstr next into claim-header-rec 
        at end  
            move "Y" to end-search-index 
	    go to ma1-99-exit. 
 
*mf    retrieve claims-mstr key fix position into key-claims-mstr. 
 
    if hold-pat-key-data not = clmhdr-pat-key-data 
    then 
	move "Y"			to end-search-index. 
*   (else) 
*   endif 
 
ma1-99-exit. 
    exit. 
 
 
 
ma2-access-batctrl. 
 
*mf move key-clm-clinic-nbr-1-2		to key-bat-clinic-nbr-1-2. 
*mf move key-clm-doc-nbr		to key-bat-doc-nbr. 
*mf move key-clm-week			to key-bat-week. 
*mf move key-clm-day			to key-bat-day. 
    move clmdtl-b-clinic-nbr-1-2	to batctrl-bat-clinic-nbr-1-2. 
    move clmdtl-b-doc-nbr		to batctrl-bat-doc-nbr. 
    move clmdtl-b-week			to batctrl-bat-week. 
    move clmdtl-b-day			to batctrl-bat-day. 
    move 'Y'				to flag-found-batch. 
 
    read batch-ctrl-file key is key-batctrl-file 
	invalid key 
	    move 'N'			to flag-found-batch 
	    go to ma2-99-exit. 
 
    add 1				to ctr-read-batctrl-mstr. 
 
*mf    retrieve batch-ctrl-file key fix position into key-batctrl-file. 
 
ma2-99-exit. 
    exit. 
 
 
 
ma3-add-nbr-svc-to-ctr. 
 
    add clmdtl-nbr-serv                                  
        clmdtl-sv-nbr (1) 
        clmdtl-sv-nbr (2) 
        clmdtl-sv-nbr (3)		to ws-total-nbr-svc. 
 
 
ma3-99-exit. 
    exit. 
 
 
 
ma4-check-for-last-claim. 
 
*	if the last claim in the batch was just deleted then 
*	update the batches ptr to the last claim.  if this is the  
*	only claim in the batch then the entire batch must be deleted. 
 
    if hold-claim-nbr = batctrl-last-claim-nbr 
    then 
	if hold-claim-nbr = 1 
	then 
*	    (this was the only claim in the batch, delete batch) 
	    perform ma41-del-phys-batch	thru ma41-99-exit 
	    go to ma4-99-exit 
	else 
*	    (find the previous key in the index and set this key 
*	     in the batch control record as the new last claim) 
	    perform ma42-read-claim-backwards 
					thru ma42-99-exit 
*mf	    if key-clm-batch-nbr not = batctrl-batch-nbr 
	    if clmdtl-b-batch-nbr not = batctrl-batch-nbr 
	    then 
*		(only claim in batch deleted, delete batch) 
		perform ma41-del-phys-batch 
					thru ma41-99-exit 
		go to ma4-99-exit 
	    else 
*mf		move key-clm-claim-nbr	to batctrl-last-claim-nbr. 
		move clmdtl-b-claim-nbr	to batctrl-last-claim-nbr. 
*	    endif 
*	endif 
*   (else) 
*   endif 
 
    if   batctrl-nbr-claims-in-batch not numeric 
      or batctrl-nbr-claims-in-batch = zero 
    then 
	move batctrl-last-claim-nbr	to	batctrl-nbr-claims-in-batch            
    else  
	subtract 1			from	batctrl-nbr-claims-in-batch. 
*   endif 
 
    subtract ws-total-nbr-svc		from batctrl-svc-act. 
 
    if   batctrl-amt-est = batctrl-amt-act 
      or batctrl-svc-est = batctrl-svc-act 
    then 
	move 1				to batctrl-batch-status 
    else 
	move 0				to batctrl-batch-status. 
*   endif 
 
    perform ma43-re-write-batctrl	thru ma43-99-exit. 
 
ma4-99-exit. 
    exit. 
 
 
 
ma41-del-phys-batch. 
 
    move zeros				to feedback-batctrl-file. 
 
    read batch-ctrl-file key is key-batctrl-file 
	invalid key 
	    move 49			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
*mf    retrieve batch-ctrl-file key fix position into key-batctrl-file. 
 
    move 'N'				to flag 
					   flag-del. 
 
    delete batch-ctrl-file	record 
*mf			physical key is key-batctrl-file 
	invalid key 
	    move 57			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    perform ma41a-check-batch-not-accessed 
					thru ma41a-99-exit. 
 
*   ( will only execute if invalid key was found and user responds 
*     with attempt to re-try at deleting batch record, which the 
*     user should do ) 
    if ok 
    then 
	go to ma41-del-phys-batch 
    else 
*	( will only execute if declarative executed due to delete 
*	  positioning error caused by batch record being accessed 
*	  not allowing this program to delete it.  the user will 
*	  be given a second chance to delete the record, by releasing 
*	  whatever is accessing the record, and then re-executing 
*	  this delete. ) 
	if flag-del = 'Y' 
	then 
	    perform ma41a-check-batch-not-accessed 
					thru ma41a-99-exit 
	    if ok 
	    then 
		go to ma41-del-phys-batch 
	    else 
		next sentence 
*	    endif 
	else 
	    next sentence. 
*	endif 
*   endif 
 
ma41-99-exit. 
    exit. 
 
 
 
ma41a-check-batch-not-accessed. 
 
    move 61				to err-ind. 
    perform za0-common-error		thru za0-99-exit. 
    move 'Y'				to flag. 
 
    display scr-acpt-re-try-del-batch. 
    accept  scr-acpt-re-try-del-batch. 
 
    if not-ok 
    then 
	move 62				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to az0-10-end-of-job. 
*    (else) 
*   endif 
 
ma41a-99-exit. 
    exit. 
 
 
ma42-read-claim-backwards. 
*mf brad backwares !!! 
    read claims-mstr previous
*mf		backward 
*mf	invalid key 
	at end
	    move zero			to key-claims-mstr 
	    go to ma42-99-exit. 
 
*mf    retrieve claims-mstr key fix position into key-claims-mstr. 
 
ma42-99-exit. 
    exit. 
 
 
 
ma43-re-write-batctrl. 
 
    rewrite batctrl-rec 
*mf		key is key-batctrl-file 
	invalid key 
	    move 50			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
ma43-99-exit. 
    exit. 
 
 
 
ma5-update-batch-values. 
 
    if batctrl-adj-cd = "A" 
    then 
	subtract clmhdr-tot-claim-ar-ohip 
					from batctrl-calc-ar-due 
    else 
	if batctrl-adj-cd = "B" 
	then 
	    subtract clmhdr-tot-claim-ar-ohip 
					from batctrl-calc-ar-due 
					     batctrl-calc-tot-rev 
	else 
	    if batctrl-adj-cd = "C" 
	    then 
		subtract clmhdr-manual-and-tape-paymnts 
					from batctrl-manual-pay-tot 
	    else 
		if batctrl-batch-type = 'C' 
		then 
		    subtract clmhdr-tot-claim-ar-ohip 
					from batctrl-calc-ar-due 
					     batctrl-calc-tot-rev 
		    subtract clmhdr-tot-claim-ar-oma 
					from batctrl-amt-act 
		else 
*		    (for others) 
		    subtract clmhdr-tot-claim-ar-oma 
					from batctrl-amt-act. 
*		endif 
*	    endif 
*	endif 
*   endif 
 
ma5-99-exit. 
    exit. 
 
 
 
ma6-update-patient. 
 
    move spaces				to key-pat-mstr. 
    move clmhdr-pat-ohip-id-or-chart	to key-pat-mstr. 
 
    perform ka0-access-patient		thru ka0-99-exit. 
    if not-ok 
    then 
	move 58				to err-ind 
	perform za0-common-error	thru za0-99-exit 
	go to az0-end-of-job. 
*   (else) 
*   endif 
 
    subtract 1				from pat-nbr-outstanding-claims 
					     pat-total-nbr-claims. 
 
    subtract ws-total-nbr-svc		from pat-total-nbr-visits. 
 
    rewrite pat-mstr-rec 
*mf		key is key-pat-mstr 
	invalid key 
	    move 53			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
ma6-99-exit. 
    exit. 
 
 
 
ma7-delete-claim-patient-key. 
 
    delete claims-mstr 
*mf		record physical 
	invalid key 
	    move 54			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-end-of-job. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
ma7-99-exit. 
    exit. 
xc0-read-claims-mstr. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
    read claims-mstr	into claim-header-rec	  key is key-claims-mstr 
	invalid key 
		move "N"		to	flag 
		go to xc0-99-exit. 
 
    move feedback-claims-mstr		to hold-feedback-clmhdr. 
    move key-claims-mstr		to hold-key-claims-mstr. 
    move "Y"				to	flag. 
    add  1				to	ctr-read-claims-mstr. 
 
xc0-99-exit. 
    exit. 
 
*xc1-read-claims-mstr-suppress. 
 
*  read claims-mstr next
*mf		 suppress data record 
*mf	invalid key  
*	at end
*	    move "N"			to flag 
*	    go to xc1-99-exit. 
*    move "Y"				to flag. 
*    add 1				to ctr-read-claims-mstr. 
 
*xc1-99-exit. 
*   exit. 
 
xc2-read-claims-mstr-next. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
    read claims-mstr next into claim-header-rec  
*mf invalid key 
	at end
	    move "N"			to flag 
	    go to xc2-99-exit. 
 
    move feedback-claims-mstr		to hold-feedback-clmhdr. 
    move key-claims-mstr		to hold-key-claims-mstr. 
    move "Y"				to flag. 
    add 1 				to ctr-read-claims-mstr. 
 
xc2-99-exit.  exit. 
 
xd0-read-all-clmdtl. 
 
    move zero				to ss-clmdtl-oma   
					   ss-clmdtl-desc  
					   ss-clmdtl. 
    move spaces				to hold-descriptions. 
 
xd0-10-read-index-rec. 
    perform xd00-read-clmdtl-rec	thru xd00-99-exit. 
 
*    (if index key read represents a detail rec within the same claim -- 
*	- then read the corresponding data rec) 
    if  ok 
    then 
	perform xd02-move-clmdtl-to-hold-area	thru xd02-99-exit 
*	(stop data entry if max # of entries have been made) 
	if ss-clmdtl-desc < ss-max-nbr-of-desc-rec-allow 
	then 
	    go to xd0-10-read-index-rec.  
 
xd0-99-exit. 
    exit. 
 
 
xd00-read-clmdtl-rec. 
 
    move zero				to feedback-claims-mstr 
					   claims-occur. 
 
    read    claims-mstr    next   into claim-detail-rec 
*mf	invalid key 
	at end
	    move "N"				to flag 
	    go to xd00-99-exit. 
 
*	(check if this record belongs to the claim) 
*	if the detail batch number equals the header batch number 
*		or the header original batch number 
*		then it is to be shown on the screen  
 
    if   ((clmdtl-batch-nbr	= clmhdr-batch-nbr 
      and clmdtl-claim-nbr	= clmhdr-claim-nbr)   or 
	 (clmdtl-batch-nbr	= clmhdr-orig-batch-nbr 
      and clmdtl-claim-nbr	= clmhdr-orig-claim-nbr)) and 
          clmdtl-oma-cd not 	= "0000" 
    then 
	move "Y"				to flag 
    else 
	move "N"				to flag. 
 
xd00-99-exit. 
    exit. 
 
 
 
xd01-read-clmdtl-data-rec. 
 
*mf read   claims-mstr static into claim-detail-rec	key is key-claims-mstr 
    read   claims-mstr        into claim-detail-rec	key is key-claims-mstr 
	invalid key 
	    move 21				to err-ind 
	    perform za0-common-error		thru za0-99-exit 
	    go to az0-end-of-job. 
 
    add 1					to ctr-read-claims-mstr. 
 
xd01-99-exit. 
    exit. 
 
 
 
xd02-move-clmdtl-to-hold-area. 
 
    if clmdtl-oma-cd = "ZZZZ" 
    then 
*	(description rec) 
	add 1				to           ss-clmdtl-desc 
	move clmdtl-desc		to hold-desc (ss-clmdtl-desc) 
    else 
*	(claim detail rec) 
	add 1				to ss-clmdtl       
	move clmdtl-orig-batch-nbr	to ws-hold-clmdtl-batch-nbr 
	move ws-clinic-nbr1		to hold-clm-clinic-nbr (ss-clmdtl) 
	move ws-doc-nbr3		to hold-clm-doc-nbr (ss-clmdtl) 
	move ws-week-day		to hold-clm-week-day (ss-clmdtl) 
	move clmdtl-claim-nbr		to hold-clm-clm-nbr (ss-clmdtl) 
	move clmdtl-cycle-nbr		to hold-clm-cyc (ss-clmdtl) 
	move clmdtl-date-period-end	to hold-clm-per-end-date (ss-clmdtl) 
	move clmdtl-sv-date		to hold-clm-svc-date (ss-clmdtl) 
	move clmdtl-oma-cd		to hold-clm-oma-cd (ss-clmdtl) 
	move clmdtl-oma-suff		to hold-clm-oma-suff (ss-clmdtl) 
	add clmdtl-nbr-serv clmdtl-sv-nbr (1)  
			    clmdtl-sv-nbr (2) clmdtl-sv-nbr (3) 
				giving hold-clm-svc (ss-clmdtl) 
	move clmdtl-agent-cd		to hold-clm-agent (ss-clmdtl) 
	move clmdtl-adj-cd		to hold-clm-adj-cd (ss-clmdtl) 
	move clmdtl-fee-ohip		to hold-clm-amt-due (ss-clmdtl). 
*    endif 
 
xd02-99-exit. 
    exit. 
 
copy "hospital.dc". 
 
copy "hosp_nbr_code_to_nbr.rtn" 
	replacing ==ca11-move-hosp==	by	==xf0-move-hosp-nbr== 
		  ==ca11-10-hosp-loop==	by	==xf0-10-hosp-loop== 
		  ==ca11-99-exit==	by	==xf0-99-exit== 
		  ==l1-hosp==		by	==ws-hosp-nbr== 
		  ==spaces==		by	==clmhdr-hosp==. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
*   display confirm. 
    accept scr-confirm. 
*   stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
 
zz0-end-of-job.

   if batctrl-batch-type = "C" 
   then
      perform ma6-update-patient	thru ma6-99-exit.
   perform ma4-check-for-last-claim	thru ma4-99-exit.
   move 56			to err-ind.
   perform za0-common-error	thru za0-99-exit.
   go to az0-10-end-of-job.   

zz0-99-exit.
   exit.

 

    copy "y2k_default_sysdate_century.rtn".