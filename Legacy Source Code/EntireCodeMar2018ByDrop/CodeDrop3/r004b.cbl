identification division. 
program-id. r004b.  
author. dyad computer systems inc. 
installation. rma. 
date-written. yy/mm/dd. 
date-compiled. 
security. 
* 
*    files	: work file 
*		: sorted work file 
*    program purpose : print the monthly claims and adjustment 
*		       transaction summary. 
*			this is the second of three programs, it will 
*			sort the claims work file produced by r004a. 
* 
*         rev.  may/87 (s.b.) - coversion from aos to aos/vs. 
*                               change field size for 
*                               status clause to 2 and 
*                               feedback clause to 4. 
 
*       89/mar/13	m. chan	- sms 97 
*				- change the size of the file from 
*				  106 to 107 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised may/91	m. chan	- pdr 482 
*				- modify the sort sequence by 
*				  dept, doctor, pat surname, service date 
*
*   revised jan/98      j. chau - s149 unix conversion
*
*   revised 1999/May/07 S.B.	- y2k checked.
*   revised 1999/Nov/19 M.C.	- y2k - extend the in and out file from 107
*				        to 111, extend record length in 
*        				r004_claims_work_mstr_new.sd 
*   revised 2002/Oct/23 M.C.    - extend the in and out file from 111 to 112,
*				  r004_claims_work_mstr_new.sd does not exist,
*				  use r004_claims_work_mstr.sd instead
*   2003/dec/09 M.C.	- alpha doc nbr
 
environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
* 
    select r004-work-file 
	assign to "r004wf" 
	organization is sequential. 
* 
 
    select r004-sort-work-file 
	assign to work-file-out-name 
	organization is sequential. 
* 
    select r004-sort-work 
	assign to 'r004_sort_work' 
	organization is sequential. 
data division. 
file section. 
 
fd  r004-work-file 
*   record contains 106 characters. 
* 99/11/19 - MC Y2K
*   record contains 107 characters. 
** 2002/10/23 - MC
*    record contains 111 characters. 
* 2003/dec/09 - MC
*    record contains 112 characters. 
    record contains 110 characters. 
* 2003/dec/09 - end
** 2002/10/23 - end
 
* 99/11/19 - MC 
*01  work-in-rec				pic x(107). 

** 2002/10/23 - MC
*01  work-in-rec				pic x(111). 

* 2004/apr/26 - MC
*01  work-in-rec				pic x(112). 
01  work-in-rec					pic x(110). 
* 2004/apr/26 - end

** 2002/10/23 - end
 
fd  r004-sort-work-file 
*   record contains 106 characters. 
* 99/11/19 - MC Y2K
*   record contains 107 characters. 
** 2002/10/23 - MC
*    record contains 111 characters. 

* 2004/apr/26 - MC
*    record contains 112 characters. 
    record contains 110 characters. 
* 2004/apr/26 - end

** 2002/10/23 - end
 
* 99/11/19 - MC 
*01  work-out-rec				pic x(107). 

** 2002/10/23 - MC
*01  work-out-rec				pic x(111). 

* 2003/dec/09 - MC
*01  work-out-rec				pic x(112). 
01  work-out-rec				pic x(110). 
* 2003/dec/09 - end

** 2002/10/23 - end
 
 
*   copy 'R004_CLAIMS_WORK_MSTR.SD'. 

** 2002/10/23 - MC
*    copy 'r004_claims_work_mstr_new.sd'.  - missing
    copy 'r004_claims_work_mstr.sd'. 
** 2002/10/23 - end
 
working-storage section. 
 
77  err-ind					pic 99 	value zero. 
77  print-file-name				pic x(5) 
	value "r004". 
77  option					pic x. 
77  sel-month					pic 99. 
 
77  work-file-in-name				pic x(6)   value 
		"r004wf". 
77  work-file-out-name				pic x(19)   value 
		"r004_sort_work_mstr". 
*  eof indicators 
* 
* 
*  status file indicators 
* 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-sort-file			pic x(11). 

77  common-status-file				pic x(2). 
77  status-sort-file				pic x(2). 

77  sel-clinic-nbr				pic 99. 
 
 
 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-batctrl-file-reads			pic 9(7). 
    05  ctr-claims-mstr-reads			pic 9(7). 
    05  ctr-work-file-writes			pic 9(7). 
    05  ctr-work-file-reads			pic 9(7). 
    05  ctr-doc-mstr-reads			pic 9(7). 
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
	10  filler				pic x(60)   value 
			"NO CLAIMS FOR THIS BATCH". 
	10  filler				pic x(60)   value 
			"NO HEADER FOR CURRENT BATCH". 
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
 
*mf    sort r004-sort-work		"COBSORT" save 
    sort r004-sort-work
      on ascending key wf-doctor-id, 
		       wf-patient-name, 
		       wf-service-date, 
			wf-claim-id, 
			wf-oma-cd 
      using r004-work-file 
      giving r004-sort-work-file. 
 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
 
*    expunge r004-sort-work 
*mf	     r004-sort-work-file. 
 
*   display program-in-progress. 
 
aa0-99-exit. 
    exit. 
 
 
az0-end-of-job. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
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
