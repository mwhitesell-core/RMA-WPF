identification division. 
program-id. r051b. 
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    files	: work file 
*		: sorted work file 
*		: parameter file 
* 
*    program purpose : this is the second in a series of 3 programs 
*		       it will sort the docrev work file produced 
*		       by r051a.  if this is the first run then the 
*		       parameter status will be set to 0 and this will 
*		       sort by dept, doc nbr, and oma code for r051ca. 
*		       if this is the second run (after r041ca) then 
*		       the parameter status will be set to 2 and this 
*		       will sort by dept, and oma code for r051cb. 
*		       when this program is complete the paramter 
*		       status will be either 1 or 3 depending on 
*		       whether this is the first or second run of 
*		       this program. 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised feb/98 j. chau  : - s149 unix conversion
* 			      - changed write to rewrite for parm file
*
*  1999/jan/31 B.E.		- y2k
*
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
* 
    select r051-work-file 
	assign to "r051wf" 
	organization is sequential. 
* 
 
    select r051-sort-work-file 
	assign to work-file-out-name 
	organization is sequential. 
* 
    select r051-sort-work 
	assign to 'r051_sort_work' 
	organization is sequential. 
* 
    copy "r051_parm_file.slr". 
data division. 
file section. 
 
fd  r051-work-file 
    record contains 49 characters. 
 
01  work-in-rec					pic x(49). 
 
fd  r051-sort-work-file 
    record contains 49 characters. 
 
01  work-out-rec				pic x(49).     
 
    copy 'r051_docrev_work_mstr.sd'. 
 
    copy "r051_parm_file.fd". 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
	value "r051". 
77  option					pic x. 
77  parm-rec-nbr				pic 9. 
 
77  work-file-in-name				pic x(6)   value 
		"r051wf". 
77  work-file-out-name				pic x(19)   value 
		"r051_sort_work_mstr". 
*  eof indicators 
* 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-sort-file			pic x(11). 
*mf 77  status-parm-file			pic x(11) value zero. 
 
77  common-status-file				pic x(2). 
77  status-sort-file				pic x(2). 
77  status-parm-file				pic x(2) value zero. 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-work-file-writes			pic 9(7). 
    05  ctr-work-file-reads			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
			"INVALID REPLY". 
	10  filler				pic x(60)   value 
			"INVALID READ ON PARAMETER FILE". 
	10  filler				pic x(60)   value 
			"INVALID WRITE TO PARAMETER FILE". 
	10  filler				pic x(60)   value 
			"INVALID PARAMETER STATUS". 
	10  filler				pic x(60)   value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)   value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)   value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)   value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)    value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)    value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)     value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)	value 
			"*** CAN BE RE-USED ***". 
	10  filler				pic x(60)	value	 
			"*** CAN BE RE-USED ***". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 13 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
procedure division. 
 
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
 
    open i-o	parameter-file. 
 
*   display program-in-progress. 
 
    move 1				to parm-rec-nbr. 
 
    read parameter-file 
	invalid key 
	    move 2			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-10-abend. 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
 
    move "r051b"			to parm-program-nbr. 
    add 1				to parm-status. 
 
    rewrite parm-file-rec 
	invalid key 
	    move 3			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit. 
 
az0-10-abend. 
 
    close	parameter-file. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab0-processing. 
 
    if parm-status = zero 
    then 
*	expunge	r051-sort-work 
*mf		r051-sort-work-file 
*mf	sort r051-sort-work		"COBSORT" save 
	sort r051-sort-work
		on ascending key	wf-sort-key 
		using r051-work-file 
		giving r051-sort-work-file 
    else 
	if parm-status = 2 
	then 
*	    expunge	r051-sort-work 
*mf			r051-sort-work-file 
************************************************************************ 
*	( the doctor nbr is not required for program r051c in the      * 
*	  second run however this will force all required total records* 
*	  to be bunched together, followed by all doctor total records:* 
*                                                                      * 
*			clinic total				       * 
*			dept   total				       * 
*			class  total				       * 
*			doctor total				       * 
*			     .					       * 
*			     .					       * 
*			     .					       * 
************************************************************************ 
*mf	    sort r051-sort-work		"COBSORT" save 
	    sort r051-sort-work
		    on ascending key	wf-dept, 
					wf-class-code 
					wf-oma-cd 
					wf-doc-nbr 
		    using r051-work-file 
		    giving r051-sort-work-file 
	else 
	    move 4			to err-ind 
	    perform za0-common-error	thru za0-99-exit 
	    go to az0-10-abend. 
*	endif 
*   endif 
 
ab0-99-exit. 
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
