identification division. 
program-id. u035b. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 85/11. 
date-compiled. 
security. 
* 
*    files	: work file 
*               : sorted work file 
* 
* 
*    program purpose : to print the direct billing invoices 
*		       this pgm is the second series of the 3 pgms. 
*		       it will sort the claim shadow work file produced 
*		       by u035a. 
* 
* 
* 
*    date       programmer          modification 
*    ----       ----------          ------------ 
* 
* 
*   feb/89      s.fader           -sms 113 
*                                 -increase size of u035-work-file and 
*						    u035-sort-work-file 
*				   to allow for agent to be added to the 
*                                  sort 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*  1999/jan/31 B.E.	- y2k
*  2003/dec/10 M.C.	- alpha doc-nbr - reduce work size
*
environment division. 
input-output section. 
file-control. 
  
* 
    select u035-work-file 
	assign to "u035wf" 
	organization is sequential. 
 
    select u035-sort-work-file 
	assign to work-file-out-name 
	organization is sequential. 
 
    select u035-sort-work 
	assign to "u035_sort_work" 
	organization  is sequential. 
data division. 
file section. 
 
fd  u035-work-file 
*!  record contains 58 characters. 
    record contains 57 characters. 
 
*!01  work-in-rec					pic x(58). 
01  work-in-rec					pic x(57). 
 
 
fd  u035-sort-work-file 
*!  record contains 58 characters. 
    record contains 57 characters. 
 
*!01  work-out-rec			pic x(58). 
01  work-out-rec			pic x(57). 
 
 
    copy "u035_clm_shdw_work_mstr.sd". 
 
working-storage section. 
 
77  work-file-out-name				pic x(19) value 
						"u035_sort_work_mstr". 
* 
77  err-ind					pic 99. 
 
 
01  counters. 
    05  ctr-work-file-reads			pic 9(7). 
    05  ctr-work-file-writes 			pic 9(7). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID READ ON WORK FILE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 01 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
    copy "sysdatetime.ws". 
 
screen section. 
 
 
01  confirm. 
    05 line 23 col 01  value " ". 
 
01  blank-line-24. 
    05  line 24 col 1	blank line. 
 
01  blank-screen. 
    05  blank screen. 
 
 
01  program-in-progress. 
    05  blank screen. 
    05  line 16 col 28 value "PROGRAM U035B IN PROGRESS". 
 
01  scr-closing-screen. 
    05  line 21 col 20	value "PROGRAM U035B ENDING". 
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
    05  line 23 col 20	value "RUN PGM U035C TO PRINT INVOICES". 
 
procedure division. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
 
*mf    sort u035-sort-work        "COBSORT"  save 
    sort u035-sort-work 
	on ascending key  	wf-shadow-sort-key 
		using 		u035-work-file 
		giving 		u035-sort-work-file. 
 
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
 
*    expunge u035-sort-work 
*mf            u035-sort-work-file. 
 
*   display program-in-progress. 
 
 
aa0-99-exit. 
    exit. 
az0-end-of-job. 
 
 
*   display blank-screen. 
*   accept sys-time			from time. 
*   display scr-closing-screen. 
*   display confirm. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 

    copy "y2k_default_sysdate_century.rtn".
