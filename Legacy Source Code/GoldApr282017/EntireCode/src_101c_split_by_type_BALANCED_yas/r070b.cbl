identification division. 
program-id. r070b.  
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/02/07. 
date-compiled. 
security. 
* 
*      files      : r070_work_file_"CLINIC_NBR"     - claims work file 
*		    r070_srt_work_file_"CLINIC_NBR" - claims work file sorted 
*		    r070_par_file      - parameter file 
* 
*  program purpose :  this program sorts the claims work file produced 
*		      by r070a. 
*  			the program sorts on 1- status ( 0=in a/r, 9=write off) 
*					     2- agent code    
*					     3- age category  
*						  0 = current (less than 30 days) 
*						  1 =  30 to  59 days old 
*						  2 =  60 to  89 days old 
*						  3 =  90 to 119 days old 
*						  4 = 120 to 149 days old 
*						  5 = 150 to 179 days old 
*						  6 = 180 days old or over 
*					     4- claim number. 
* 
*    revised feb/84 (a.j.) - adjust hard coded fd'S TO CARRY EXTRA 
*			     bytes for sub-nbr and tape-submit-ind 
* 
*    revised nov/84 (m.s.) - provide two further aging categories, 
*			     replace "4 = 120 days old or over" with 
*				     "4 = 120 to 149 days old", 
*			     add "5 = 150 to 179 days old" and 
*			 "6 = 180 days old or over". 
* 
*    revised may/87 (s.b.) - coversion from aos to aos/vs. 
*                            change field size for 
*                            status clause to 2 and 
*                            feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised feb/98 j. chau  : - s149 unix conversion 
*
* 1999/jan/31 B.E.	- y2k
* 1999/Nov/19 M.C.	- y2k - extend in & out records from 108 to 114
* 
environment division. 
input-output section. 
file-control. 
  
                                     
    select work-file-in     
	  assign to  work-file-in-name 
          organization sequential  
	  status is stat-work-in.
*mf	  infos status is stat-work-in. 
 
    select work-file-out 
	  assign to work-file-out-name 
          organization sequential  
	  status is stat-work-out.
*mf	  infos status is stat-work-out. 
 
    select work-sort 
          assign to work-sort-name 
	  organization sequential 
	  file  status is stat-work-sort. 
 
    select param-file 
	assign to par-file-name 
	organization is sequential 
	status is status-cobol-param-file.
*mf	infos status is status-param-file. 
data division. 
file section. 
  
fd  work-file-in 
* 99/11/19 - MC
*   record contains 108 characters 
*   block contains  108 characters. 
    record contains 114 characters 
    block contains  114 characters. 
 
* 99/11/19 - MC
*01  work-in-rec		pic x(108).     
01  work-in-rec			pic x(114).     
 
fd  work-file-out 
* 99/11/19 - MC
*   record contains 108 characters 
*   block contains  108 characters. 
    record contains 114 characters 
    block contains  114 characters. 
 
* 99/11/19 - MC
*01  work-out-rec		pic x(108). 
01  work-out-rec		pic x(114). 
 
* 
    copy "r070_claims_work_mstr.sd". 
 
 
    copy "r070_param_file.fd". 
working-storage section. 
 
* file names 
77  work-sort-name			pic x(14) value "r070_work_sort". 
77  par-file-name			pic x(14) value 
	"r070_par_file". 
 
* files status 
*mf 77  stat-work-in			pic x(11) value zero. 
*mf 77  common-status-file		pic x(11) value zero. 
*mf 77  stat-work-out			pic x(11) value zero. 
*mf 77  status-param-file		pic x(11) value zero. 
*mf 77  stat-claims-work-mstr		pic x(11) value zero. 
77  err-ind				pic 99	  value zero. 
77  stat-work-sort			pic xx    value zero. 
 
77  common-status-file			pic x(2) value zero. 
77  stat-work-in			pic x(2) value zero. 
77  stat-work-out			pic x(2) value zero. 
77  status-cobol-param-file		pic x(2) value zero. 
77  stat-cobol-claims-work-mstr		pic x(2) value zero. 

01  counters. 
    05  ctr-work-file-reads		pic 9(7). 
    05  ctr-sorted-work-file-reads	pic 9(7). 
 
01  work-file-in-name. 
    05  filler				pic x(15)  value 
	"r070_work_mstr_". 
    05  work-file-in-clinic-nbr		pic xx. 
 
01  work-file-out-name. 
    05  filler				pic x(19)  value 
	"r070_srt_work_mstr_". 
    05  work-file-out-clinic-nbr	pic xx. 
 
copy "sysdatetime.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler			pic x(60)	value 
		"NO PARAMETER FILE SUPPLIED". 
	10  filler			pic x(60)	value 
		"NO WORK MASTER FOR THIS CLINIC". 
    05  error-messages-r redefines error-messages. 
	10  err-msg			pic x(60)  
		occurs 2 times. 
01  err-msg-comment			pic x(60). 
 
01  e1-error-line. 
    05  e1-error-word			pic x(13)	value 
	"***  ERROR - ". 
    05  e1-error-msg			pic x(119). 
procedure division. 
declaratives. 
 
err-work-sort-file section. 
	use after error procedure on work-sort. 
err-work-sort. 
	stop "ERROR ACCESSING SORT WORK FILE". 
	move stat-work-sort		to common-status-file. 
*	display file-status-display. 
	display common-status-file. 
	stop run. 
 
err-work-file-in section. 
	use after error procedure on work-file-in. 
err-work-in. 
	stop "ERROR ACCESSING WORK FILE". 
	move stat-work-in	to common-status-file. 
*	display file-status-display. 
	display common-status-file. 
	stop run. 
 
err-work-file-out section. 
	use after error procedure on work-file-out. 
err-work-out. 
	stop "ERROR IN ACCESSING SORTED WORK FILE". 
	move stat-work-out	to common-status-file. 
*	display file-status-display. 
	display common-status-file. 
	stop run. 
 
end declaratives. 
 
mainline section. 
 
    perform aa0-initialization			thru aa0-99-exit. 
 
*mf    sort  work-sort	"COBSORT" save 
    sort  work-sort
      on ascending key 	wk-sort-record-status, 
			wk-agent-cd, 
      on descending key wk-age-category, 
      on ascending key 	wk-clm-nbr 
      using work-file-in 
      giving work-file-out. 
 
 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
    open input param-file. 
    read param-file 
      at end 
	move 1				to err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-finalization. 
    move param-clinic-nbr-1-2		to	work-file-in-clinic-nbr 
						work-file-out-clinic-nbr. 
 
*    expunge  work-sort   
*mf             work-file-out. 
 
    accept sys-date				from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
*   display program-in-progress. 
 
 
aa0-99-exit. 
    exit. 
 
az0-finalization   section. 
 
    accept sys-time				from time. 
*   display scr-closing-screen. 
*   display confirm. 
     close  param-file. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
za0-common-error. 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
