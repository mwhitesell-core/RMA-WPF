identification 	division. 
program-id. 	r150b.  
author. 	dyad computer systems inc. 
installation. 	rma. 
date-written. 	80/10/28. 
date-compiled. 
security. 
* 
*      files	         : r150_work_file     - doctor work file 
*			 : r150_srt_work_file - doctor work file sorted 
* 
*  program purpose :  this program sorts the work file produced by r150a. 
*  		      the program sorts on 1) doc-last-name 
*					   2) doc-initials  
*					   3) doc-nbr 
*					   4) clinic-nbr 
* 
*   revision history: 
* 
*	may/82 (d.m. & i.w.)	- changed to access new work file 
*				- program renamed (was r022b) 
* 
*       may/87 (s.b.)           - coversion from aos to aos/vs. 
*                                 change field size for 
*                                 status clause to 2 and 
*                                 feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
* 
*   revised feb/98 j. chau  - s149 unix conversion
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
 
data division. 
file section. 
  
fd  work-file-in 
    record contains 56  characters 
    block contains  56 characters. 
 
01  work-in-rec			pic x(56).       
 
fd  work-file-out 
    record contains  56 characters 
    block contains  56 characters. 
 
01  work-out-rec		pic x(56).   
 
* 
    copy "r150_chq_doc_mstr.sd". 
 
 
                               
working-storage section. 
 
* file names 
77  work-sort-name			pic x(14) value "r150_work_sort". 
 
* files status 
*mf 77  common-status-file		pic x(11) value zero. 
*mf 77  stat-work-in			pic x(11) value zero. 
*mf 77  stat-work-out			pic x(11) value zero. 
77  stat-claims-work-mstr		pic x(11) value zero. 
 
77  common-status-file			pic x(2) value zero. 
77  stat-work-in			pic x(2) value zero. 
77  stat-work-out			pic x(2) value zero. 
77  stat-work-sort			pic x(2) value zero. 
77  err-ind				pic 99	 value zero. 

01  counters. 
    05  ctr-work-file-reads		pic 9(7). 
    05  ctr-sorted-work-file-reads	pic 9(7). 
 
01  work-file-in-name. 
    05  filler				pic x(14)  value 
	"r150_work_file". 
 
01  work-file-out-name. 
    05  filler				pic x(18)  value 
	"r150_srt_work_mstr". 
 
 
 
copy "sysdatetime.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler			pic x(60)	value 
		"ERR - MESS # 1 GOES HERE  ". 
	10  filler			pic x(60)	value 
		"NO WORK MASTER SUPPLIED".         
    05  error-messages-r redefines error-messages. 
	10  err-msg			pic x(60)  
		occurs 2 times. 
 
 
 
01  err-msg-comment			pic x(60). 
 
01  e1-error-line. 
    05  e1-error-word			pic x(13)	value 
	"***  ERROR - ". 
    05  e1-error-msg			pic x(119). 
screen section. 
 
01  program-in-progress. 
    05  blank screen. 
    05  line 01 col 01  value is "R150B". 
    05  line 01 col 25  value is "T4 AND AUDIT STATEMENTS REPORT". 
    05  line 01 col 73  pic 99 from sys-yy. 
    05  line 01 col 75  value is "/". 
    05  line 01 col 76  pic 99 from sys-mm. 
    05  line 01 col 78  value is "/". 
    05  line 01 col 79  pic 99 from sys-dd. 
    05  line 10 col 25  value is "PART 2- SORT WORK-FILE". 
    05  line 13 col 30  value "PROGRAM R150B IN PROGRESS". 
 
01  blank-screen. 
    05  blank screen. 
 
 
01  err-msg-line. 
    05  line 24 col 01 value " ERROR - "  bell blink. 
    05  line 24 col 11 pic x(60) using err-msg-comment. 
 
01  file-status-display. 
    05  line 24 col 56  value "FILE STATUS = ". 
*mf    05  line 24 col 70  pic x(11) using common-status-file bell blink. 
    05  line 24 col 70  pic x(2) using common-status-file bell blink. 
 
01  blank-line-24. 
    05  line 24 col 1 blank line. 
 
01  confirm. 
    05  line 23 col 01  value " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  scr-closing-screen. 
    05  blank screen. 
    05  line 21 col 20	value "PROGRAM R150B ENDING". 
    05  line 21 col 41  pic 99	from sys-yy. 
    05  line 21 col 43	value "/". 
    05  line 21 col 44	pic 99	from sys-mm. 
    05  line 21 col 46	value "/". 
    05  line 21 col 47	pic 99	from sys-dd. 
    05  line 21 col 50	pic z9	from sys-hrs. 
    05  line 21 col 52	value ":". 
    05  line 21 col 53	pic 99	from sys-min.        
    05  line 23 col 20  value "RUN PROGRAM R150C TO PRINT THE T4'S". 
procedure division. 
declaratives. 
 
err-work-sort-file section. 
	use after error procedure on work-sort. 
err-work-sort. 
	stop "ERROR ACCESSING SORT WORK FILE". 
	move stat-work-sort		to common-status-file. 
	display file-status-display. 
	stop run. 
 
err-work-file-in section. 
	use after error procedure on work-file-in. 
err-work-in. 
	stop "ERROR ACCESSING WORK FILE". 
	move stat-work-in	to common-status-file. 
	display file-status-display. 
	stop run. 
 
err-work-file-out section. 
	use after error procedure on work-file-out. 
err-work-out. 
	stop "ERROR IN ACCESSING SORTED WORK FILE". 
	move stat-work-out	to common-status-file. 
	display file-status-display. 
	stop run. 
 
end declaratives. 
mainline section.  
 
    perform aa0-initialization			thru aa0-99-exit. 
 
*mf     sort  work-sort	"COBSORT" save 
    sort  work-sort
      on ascending key 	wk-doc-name            
			wk-doc-inits       
                        wk-doc-nbr       
                        wk-doc-clinic-nbr 
      using work-file-in 
      giving work-file-out. 
 
 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
*    expunge  work-sort   
*mf             work-file-out. 
 
    accept sys-date				from date. 
    display program-in-progress. 
 
 
aa0-99-exit. 
    exit. 
az0-finalization   section. 
 
    accept sys-time				from time. 
    display scr-closing-screen. 
*    expunge work-file-in 
*mf	    work-sort. 
    display confirm. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
za0-common-error. 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
za0-99-exit. 
    exit. 
 
