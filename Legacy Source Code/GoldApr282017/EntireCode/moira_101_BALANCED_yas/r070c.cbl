identification division. 
program-id. r070c.  
author. dyad computer systems inc. 
installation. rma. 
date-written. 80/02/07. 
date-compiled. 
security. 
* 
*  	files   : r070_srt_work_file_"CLINIC_NBR" - claims work file sorted 
*		: f070_par_file      - parameter file 
*		: "r070"             - accounts receivable trial balance report 
* 
*      program purpose : this program is the third in a series of 3 programs. 
*			 it uses the sorted work file that is output by 
*			 r070b to print the account receivable trial balance. 
* 
*    revised feb/84 (a.j.) - adjust detail line to include sub nbr and 
*			     tape-submit-ind 
*			   - flag detail lines where srvice date is 
*			     four mths older than calendar date 
*			   - break totals down by subdivision within 
*			     agent code six 
* 
*    revised nov/84 (m.s.) - adjust the detail line to show the whole 
*			     field (action-taken). the day of action- 
*			     taken was truncated. 
* 
*    revised nov/84 (m.s.) - provide two further aging categories, 
*			     replace "OVER 120" with "120-150", 
*			     add "150-180" and "OVER 180". 
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
*    may 2/89     s. fader      - sms 116 
*				- print the dept code and/or name 
* 
*    revised oct/90  (bml)  - change to print totals by agents. 
* 
*    revised feb/98  j.chau - s149 unix conversion
*
* 00/nov/14 B.E. - increased size of some of the temporary variables so that
*		   larger numbers could be carried into the total lines.
* 02/jul/02 B.E. - increased size of claim counters from zz,zzz to zzz,zzz in
*	           total prints
*
* 2003/dec/10 M.C. - alpha doc nbr
* 2013/Aug/19 MC1  - allow negative amount
* 2016/Oct/25 MC2  - show final ohip fee, amt paid and balance due at the end of the report
* 2017/Apr/20 MC3  - include to show oma fee at the end of the report

environment division. 
input-output section. 
file-control. 
  
                                     
    select claims-work-mstr 
         assign to  work-file-name  
          organization sequential  
          status is status-cobol-claims-work-mstr. 
*mf          infos status is status-claims-work-mstr. 
 
 
    select param-file  
         assign to  param-file-name  
	  organization sequential 
	  status is status-cobol-param-file. 
*mf	  infos status is status-param-file. 
 
    select print-file 
	  assign to printer print-file-name 
	  file status is status-prt-file. 
data division. 
file section. 
  
    copy "r070_param_file.fd". 
* 
    copy "r070_claims_work_mstr.fd". 
* 
 
fd  print-file 
    record contains 132 characters. 
01  prt-line				pic x(132). 
working-storage section. 
 
77  pat-occur					pic 9(12).   
 
*   status file indicators 
*mf 77  status-claims-work-mstr			pic x(11) value zero. 
*mf 77  common-status-file			pic x(11) value zero. 
*mf 77  status-param-file 			pic x(11) value zero. 
 
77  common-status-file				pic x(2) value zero. 
77  status-cobol-claims-work-mstr		pic x(2) value zero. 
77  status-cobol-param-file 			pic x(2) value zero. 
77  status-prt-file				pic xx    value zero. 

*   flag indicators 
77  err-ind					pic 99 	value zero. 
77  header-done					pic x 	value "N". 
77  eof-work-mstr				pic x   value "N". 
77  totals-written				pic x	value "N". 
77  display-key-type				pic x(7). 
 
01  flag					pic x. 
    88 ok					value "Y". 
    88 not-ok					value "N". 
*   eof flags 
77  error-flag                                  pic x    value "N". 
 
*   variables 
77  i						pic 999. 
77  record-status				pic 9. 
77  line-cnt					pic 999   value zero. 
77  page-cnt					pic 9(4)  value zero. 
77  ws-reply					pic x. 
77  ws-date-reply				pic x. 
 
*   total variables 
77  dept-tot-amount				pic s9(8)v99. 
77  balance-due					pic s9(6)v99.    
77  write-off-nbr-of-clms  			pic 999. 
77  write-off-totals				pic s9(8)v99. 
 
*   totals 
77  current-tot					pic s9(8)v99.        
77  30-day-tot					pic s9(8)v99.       
77  60-day-tot					pic s9(8)v99.     
77  90-day-tot					pic s9(8)v99.      
77  120-day-tot					pic s9(8)v99.       
77  150-day-tot					pic s9(8)v99.       
77  180-day-tot					pic s9(8)v99.       
 
77  current-nbr-of-clms				pic 9(6).  
77  30-day-nbr-of-clms				pic 9(6).        
77  60-day-nbr-of-clms				pic 9(6).         
77  90-day-nbr-of-clms				pic 9(6).     
77  120-day-nbr-of-clms				pic 9(6).        
77  150-day-nbr-of-clms				pic 9(6).        
77  180-day-nbr-of-clms				pic 9(6).        

* MC3
77  final-oma-fee				pic s9(8)v99. 
* MC3 - end

* MC2
77  final-ohip-fee				pic s9(8)v99. 
77  final-amt-paid				pic s9(8)v99. 
77  final-bal-due				pic s9(8)v99. 
* MC2 - end

* MC3
77  total-oma-fee				pic s9(8)v99. 
* MC3 - end

77  total-ohip-fee				pic s9(8)v99. 
77  total-bal-due				pic s9(8)v99. 
77  total-amt-paid				pic s9(8)v99. 
77  total-amount				pic s9(8)v99.     
77  total-nbr-of-clms				pic 9(6).   
 
77  final-grand-amount        occurs 11 times   pic s9(9)v99. 
77  final-grand-nbr-of-clms   occurs 11 times   pic 9(8). 
77  grand-amount				pic s9(9)v99. 
77  grand-nbr-of-clms				pic 9(8). 
 
77  tp-sub-nbr					pic 99. 
01  sub-total-table. 
    05  sub-tot occurs 99 times			pic s9(9)v99. 
 
01  dept-total-table. 
    05  dept-tot occurs 99 times		pic s9(8)v99.        
 
01  blank-line					pic x(132) value spaces. 
 
 
01  hold-ws-age-category			pic 9. 
01  save-agent-cd				pic 9. 
 
 
01  work-file-name. 
    05  filler			  		pic x(19)	value "r070_srt_work_mstr_". 
    05  work-file-clinic-nbr			pic xx. 
 
01  param-file-name. 
   05  filler					pic x(14)	value	"r070_par_file". 
 
01  print-file-name. 
    05  printer-file-name			pic x(5)	value 
		"r070_". 
    05  print-file-nbr				pic x(2). 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-claims-work-mstr-reads		pic 9(8). 
    05  ctr-detail-lines-writes			pic 9(8). 
    05  ctr-param-file-reads			pic 9(8). 
 
 
copy "sysdatetime.ws". 
 
01 test-date. 
* (y2k)
*   05  test-date-yy				pic 99. 
    05  test-date-yy				pic 9(4). 
    05  test-date-mm				pic 99. 
    05  test-date-dd				pic 99. 
01  head-line-1. 
    05  filler					pic x(7) 	value 			"R070  /". 
    05  h1-clinic-nbr				pic zz. 
    05  filler  				pic x	 	value spaces. 
    05  h1-month           			pic x(9). 
    05  filler					pic x		value space. 
    05  h1-day					pic z9. 
* (y2k)
*   05  filler					pic x(4) 	value ", 19". 
*   05  h1-year					pic z9.   
    05  filler					pic x(2)   	value ", ". 
    05  h1-year					pic 9(4).   

    05  filler					pic x(19)	value spaces. 
    05  filler					pic x(37)	value                   "* ACCOUNTS RECEIVABLE TRIAL BALANCE *". 
    05  filler					pic x(12)	value spaces. 
    05  filler					pic x(9)	value 			"RUN DATE ". 
* (y2k)
*   05  header-date			 	pic x(8). 
    05  header-date			 	pic x(10). 
*   05  filler					pic x(9)	value spaces. 
    05  filler					pic x(7)	value spaces. 

    05  filler					pic x(5)	value 			"PAGE ". 
    05  h1-page					pic z,zz9. 
 
 
01  head-line-2. 
    05  filler					pic x(55)	value spaces. 
    05  h2-clinic 	  			pic x(20). 
    05  filler					pic x(57)	value spaces. 
 
01  head-line-3. 
    05  filler					pic x(7)	value 			" AGENT ". 
    05  h3-agent     				pic x. 
    05  filler 					pic x(5)	value spaces. 
    05  h3-title				pic x(20). 
    05  filler					pic x(119)	value spaces. 
 
 
01  head-line-4. 
    05 filler 					pic x(35) 
	value "  PATIENT   PATIENT ID/    CLAIM   ". 
    05 filler					pic x(35) 
*	value " OH SUB      OMA        OHIP     AM". 
 	value "    OH SUB    OMA        OHIP     A". 
    05 filler					pic x(35) 
*	value "OUNT    BALANCE   PERIOD  SERVICE  ". 
	value "MOUNT    BALANCE   PERIOD   SERVICE". 
    05 filler					pic x(27) 
*	value "DAY  BATCH   TAPE  ACTION  ". 
	value " DAY  BATCH   TAPE ACTION  ". 
 
01  head-line-5. 
    05 filler					pic x(35) 
*	value "  ACRONYM   CHART NUMBER   NUMBER  ". 
	value "  ACRONYM   CHART NUMBER   NUMBER/D". 
    05 filler					pic x(35) 
*	value " IP NBR      FEE        FEE       P". 
	value "EPT IP NBR    FEE        FEE       ". 
    05 filler					pic x(35) 
*	value "AID       DUE      DATE    DATE    ". 
	value "PAID       DUE      DATE     DATE  ". 
    05 filler					pic x(27) 
*	value "OLD  NUMBER  SUB   TAKEN   ". 
	value " OLD  NUMBER  SUB  TAKEN   ". 
 
01 head-line-6. 
    05  filler					pic x(5)	value spaces. 
    05  filler					pic x(42)	value "AGE CATEGORY      AMOUNT        #OF CLAIMS". 
    05  filler 					pic x(85)	value spaces. 
 
 
01 head-line-7. 
    05  filler					pic x(20)	value			"DEPARTMENTAL SUMMARY". 
    05  filler					pic x(112)	value spaces. 
 
01 head-line-8. 
    05  filler					pic x(21)	value			"SUBDIVISIONAL SUMMARY". 
    05  filler					pic x(111)	value spaces. 
 
01  head-line-9. 
    05  h9-title				pic x(40).             
    05  filler					pic x(15)	value space. 
    05  filler					pic x(8)	value			"$ AMOUNT". 
    05  filler					pic x(5)	value spaces. 
    05  filler					pic x(8)	value			"# CLAIMS". 
    05  filler					pic x(56)	value spaces. 
 
 
01  head-line-10. 
    05  filler					pic x(28)	value "DEPT". 
    05  filler					pic x(104)	value "AMT". 
 
01  head-line-11. 
    05  filler					pic x(28)	value "SUB". 
    05  filler					pic x(104)	value "AMT". 
 
 
 
01  head-line-12. 
 
    05  filler                                  pic x(53)       value 
           "-----------------------------------------------------". 
    05  head-line-12-msg                        pic x(25). 
    05  filler                                  pic x(54)       value 
           "-----------------------------------------------------". 
 
 
01  head-line-13. 
 
    05  filler                                  pic x(8)        value spaces. 
    05  filler                                  pic x(13)       value "0". 
    05  filler                                  pic x(13)       value "1". 
    05  filler                                  pic x(13)       value "2". 
    05  filler                                  pic x(13)       value "3". 
    05  filler                                  pic x(13)       value "4". 
    05  filler                                  pic x(13)       value "5". 
    05  filler                                  pic x(13)       value "6". 
    05  filler                                  pic x(13)       value "7". 
    05  filler                                  pic x(13)       value "8". 
    05  filler                                  pic x           value "9". 
 
 
01  detail-line-1. 
    05  d1-age-ind				pic x.	  
    05  d1-pat-acron 				pic x(6)bxxx. 
    05  filler					pic x. 
    05  d1-pat-id				pic x(12). 
    05  filler					pic x. 
*!    05  d1-clm-nbr				pic 9(8). 
    05  d1-clm-nbr				pic x(8). 
    05  d1-claim-nbr				pic 99. 
    05  d1-slash-1a    				pic x. 
    05  d1-dept-nbr				pic 99. 
    05  filler					pic x. 
    05  d1-ohip-stat. 
	10 d1-ohip-stat-1			pic x. 
	10 d1-ohip-stat-2			pic 9.    
    05  filler					pic x(1). 
    05  d1-sub-nbr				pic 9	blank when zero. 
    05  filler					pic x. 
    05  d1-oma-fee				pic zzzzz9.99-. 
    05  filler					pic x. 
    05  d1-ohip-fee				pic zzzzz9.99-. 
    05  filler					pic x. 
    05  d1-amount-paid				pic zzzzz9.99-. 
    05  filler					pic x. 
    05  d1-balance-due				pic zzzzz9.99-. 
    05  filler					pic x. 
    05  d1-period-end-date.           
* (y2k)
*       10  d1-period-yy			pic 99. 
* 99/11/22 - MC
*       10  d1-period-yy			pic 9(4). 
        10  d1-period-yy			pic 99. 
        10  d1-slash1				pic x. 
        10  d1-period-mm			pic 99. 
        10  d1-slash2				pic x. 
        10  d1-period-dd			pic 99. 
    05  filler  				pic x. 
    05  d1-ser-date.             
* (y2k)
*       10  d1-ser-yy				pic 99. 
* 99/11/22 - MC
*       10  d1-ser-yy				pic 9(4). 
        10  d1-ser-yy				pic 99. 
        10  d1-slash3				pic x. 
        10  d1-ser-mm				pic 99. 
        10  d1-slash4				pic x. 
        10  d1-ser-dd				pic 99. 
    05  filler					pic x. 
    05  d1-day-old				pic x(3). 
    05  filler					pic x. 
    05  d1-batch-nbr-1-2			pic 99.   
*2003/12/10 - MC
*!    05  d1-batch-nbr-3			pic 9. 
*!    05  d1-batch-nbr-4-9			pic 9(6). 
    05  d1-batch-nbr-4-9			pic x(6). 
*2003/12/10 - end
    05  filler					pic x. 
    05  d1-tape-submit-ind			pic x. 
* 99/11/22 - MC
*   05  filler					pic x(2). 
    05  filler					pic x. 
    05  d1-act-taken. 
        10  d1-act-taken-1 			pic xx. 
        10  filler				pic x. 
        10  d1-act-taken-2			pic 9(6). 
* 99/11/22 - MC Y2K
        10  filler				pic xx.
 
 
01  detail-line-2. 
 
    05  filler					pic x(6)	value spaces. 
    05  tot-title				pic x(8). 
    05  filler					pic xxx		value spaces. 
    05  tot-amt    				pic zz,zzz,zz9.99-. 
*    05  tot-nbr-of-clms				pic zz,zz9. 
*    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(7)	value spaces. 
    05  tot-nbr-of-clms				pic zzz,zz9. 
    05  filler					pic x(88)	value spaces. 
 
 
01  detail-line-3. 
    05  filler					pic x(6)	value spaces. 
    05  tot-title-1				pic x(9)	value			"* TOTAL *". 
    05  filler					pic xx		value spaces. 
    05  tot-amt-1		 		pic zz,zzz,zz9.99-. 
*    05  filler					pic x(8)	value spaces. 
*    05  tot-nbr-of-clms-1			pic zz,zz9. 
    05  filler					pic x(7)	value spaces. 
    05  tot-nbr-of-clms-1			pic zzz,zz9. 
    05  filler					pic x(87)	value spaces. 
 
01  detail-line-8. 
    05  filler					pic x(6)	value spaces. 
    05  filler  				pic x(7)	value			"AMT W/O". 
    05  filler					pic x(4)	value spaces. 
    05  w-o-tot-amount				pic zz,zzz,zz9.99-. 
    05  filler					pic x(10)	value spaces. 
    05  w-o-tot-nbr-of-clms			pic zz9. 
    05  filler					pic x(88)  	value spaces. 
 
 
01  detail-line-9. 
    05  filler					pic x(50)	value spaces. 
    05  d9-amount      				pic zz,zzz,zz9.99-. 
    05  filler					pic x(5)    	value spaces. 
    05  d9-nbr-of-clms				pic zzz,zz9.    
    05  filler					pic x(56)	value spaces. 
 
01  detail-line-10. 
*   05  d10-dept-nbr				pic z9. 
    05  d10-dept-nbr				pic 99. 
    05  filler					pic x(16)  	value spaces. 
    05  dept-tot-amt				pic zz,zzz,zz9.99-. 
    05  filler					pic x(100) 	value spaces. 
 
01  detail-line-11. 
    05  filler					pic x	value space. 
    05  d11-sub-nbr				pic 9. 
    05  filler					pic x(16)  	value spaces. 
    05  sub-tot-amt				pic zz,zzz,zz9.99-. 
    05  filler					pic x(100) 	value spaces. 
 
01  detail-line-12. 
	10  d12-msg				pic x(7). 
	10  d12-ctr-r. 
	    15  d12-ctr				pic 9(9). 
* 2013/08/19 - MC1 - allow negative amount
*	    15  filler				pic x(5)       value spaces. 
	    15  filler				pic x(6)       value spaces. 
*	10  d12-ctr-total redefines d12-ctr-r	pic zzz,zzz,zz9.99. 
	10  d12-ctr-total redefines d12-ctr-r	pic zzz,zzz,zz9.99-. 
*	10  filler				pic x(108)     value spaces. 
	10  filler				pic x(107)     value spaces. 
* 2013/08/19 - end
 
01 detail-line-13. 
        10  d13-nbr-amt-var-r occurs 10 times. 
            15  d13-nbr-var-r. 
                20  d13-blanks                  pic xxxx. 
                20  d13-nbr-var                 pic 9(9). 
            15  d13-amt-var-r  redefines d13-nbr-var-r. 
                20  d13-amt-var                 pic z,zzz,zz9.99-. 
 
* MC2 
01  head-line-final. 
* MC3
    05  filler					pic x(15)	value space. 
    05  filler					pic x(15)	value			"TOTAL OMA FEE".
* MC3 - end
    05  filler					pic x(15)	value space. 
    05  filler					pic x(15)	value			"TOTAL OHIP FEE".
    05  filler					pic x(5)	value spaces. 
    05  filler					pic x(15)	value			"TOTAL AMT PAID".
    05  filler					pic x(5) 	value spaces. 
    05  filler					pic x(20)	value			"TOTAL BALANCE DUE".
* MC3
*   05  filler					pic x(57)	value spaces. 
    05  filler					pic x(27)	value spaces. 
* MC3 - end 
 
01  detail-line-final.
* MC3
    05  filler					pic x(15)	value spaces. 
    05  d-final-oma-fee				pic zzz,zzz,zz9.99-. 
* MC3 - end
    05  filler					pic x(15)	value spaces. 
    05  d-final-ohip-fee			pic zzz,zzz,zz9.99-. 
    05  filler					pic x(5)    	value spaces. 
    05  d-final-amt-paid			pic zzz,zzz,zz9.99-. 
    05  filler					pic x(08)   	value spaces. 
    05  d-final-bal-due 			pic zzz,zzz,zz9.99-. 
    05  filler					pic x(59)	value spaces. 
* MC2 - end
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID READ ON PARAMETER FILE". 
	10  filler				pic x(60)   value 
    	"CLINIC # FROM PARAM-FILE & CLAIM-MSTR ARE NOT EQUAL". 
	10  filler				pic x(60)   value 
		"INVALID READ ON CLAIMS WORK MSTR". 
	10  filler				pic x(60)   value 
		"INVALID DEPT NUMBER ON WORK FILE ( <1 OR >99 )". 
	10  filler				pic x(60)   value 
		"INVALID SUBDIVISION NBR ON WORK FILE". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
			occurs 5 times.     
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
procedure division. 
declaratives. 
 
err-parameter-file section. 
    use after standard error procedure on param-file. 
err-param-file. 
    stop "ERROR IN ACCESSING PARAMETER FILE". 
*mf    move status-param-file			to common-status-file. 
    move status-cobol-param-file		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop run. 
 
err-claim-work-mstr-file section. 
    use after standard error procedure on claims-work-mstr. 
err-claims-work-mstr. 
    stop "ERROR IN ACCESSING CLAIMS WORK MASTER". 
*mf    move status-claims-work-mstr		to common-status-file. 
    move status-cobol-claims-work-mstr		to common-status-file. 
*   display file-status-display. 
    display common-status-file. 
    stop run. 
 
end declaratives. 
 
 
mainline section. 
 
    perform aa0-initialization			thru aa0-99-exit. 
    perform  ab2-create-report			thru ab2-99-exit. 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
   move	zeros				to record-status 
					   balance-due 
					   grand-amount 
 					   grand-nbr-of-clms 
					   save-agent-cd 
					   counters 
                                           final-grand-nbr-of-clms(1) 
                                           final-grand-nbr-of-clms(2) 
                                           final-grand-nbr-of-clms(3) 
                                           final-grand-nbr-of-clms(4) 
                                           final-grand-nbr-of-clms(5) 
                                           final-grand-nbr-of-clms(6) 
                                           final-grand-nbr-of-clms(7) 
                                           final-grand-nbr-of-clms(8) 
                                           final-grand-nbr-of-clms(9) 
                                           final-grand-nbr-of-clms(10) 
                                           final-grand-nbr-of-clms(11) 
                                           final-grand-amount(1) 
                                           final-grand-amount(2) 
                                           final-grand-amount(3) 
                                           final-grand-amount(4) 
                                           final-grand-amount(5) 
                                           final-grand-amount(6) 
                                           final-grand-amount(7) 
                                           final-grand-amount(8) 
                                           final-grand-amount(9) 
                                           final-grand-amount(10) 
                                           final-grand-amount(11). 
 
    open input param-file. 
 
    read param-file 
	at end 
	      move 1				to  err-ind 
	      perform za0-common-error		thru za0-99-exit 
	      go to az0-10-end-of-job. 
    add 1					to  ctr-param-file-reads. 
 
    move param-date-mm				to run-mm. 
    move param-date-dd				to run-dd. 
    move param-date-yy				to run-yy. 
 
    move param-clinic-nbr-1-2			to  work-file-clinic-nbr 
						    print-file-nbr. 
 
*    expunge    print-file. 
 
    open  input  claims-work-mstr. 
    open  output print-file. 
 
    move run-date				to header-date. 
 
    move spaces					to prt-line   
                         			   h3-title 
                                                   detail-line-12 
                                                   detail-line-13. 
 
    move 90 					to line-cnt. 
 
 
    read claims-work-mstr 
        at end 
	      move 3				to err-ind 
	      perform za0-common-error		thru za0-99-exit 
	      go to az0-10-end-of-job. 
     
    add 1					to ctr-claims-work-mstr-reads. 
 
    if param-clinic-nbr-1-2 not = wk-clinic-nbr 
    then 
        move 2					to err-ind 
	perform za0-common-error		thru za0-99-exit 
        go to az0-10-end-of-job. 
*   (else) 
*   endif 
 
    accept sys-date		from	 date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-date		to	 test-date. 
    perform  aa1-set-test-date	thru	 aa1-99-exit	4 times. 
 
*   display program-in-progress. 
 
    move param-clinic-nbr-1-2				to h1-clinic-nbr. 
    move param-date-period-end-yy 		   	to  h1-year. 
    move param-date-period-end-dd 		        to  h1-day. 
    move param-date-period-end-mm			to  h1-month. 
    move param-clinic-name				to  h2-clinic. 
 
aa0-99-exit. 
    exit. 
aa1-set-test-date. 
 
    subtract 1 from test-date-mm. 
    if test-date-mm = zero 
    then 
	move 12					to test-date-mm 
	subtract 1 				from test-date-yy. 
*   endif 
 
aa1-99-exit. 
 
    exit. 
 
ab2-create-report   section. 
 
    perform ca3-clear-totals			thru ca3-99-exit. 
    move wk-age-category			to hold-ws-age-category. 
    move wk-agent-cd				to save-agent-cd. 
 
ab2-10-building-report. 
 
    if wk-sort-record-status not = 9 
    then 
	perform ba0-process-report 		thru ba0-99-exit 
	    until wk-sort-record-status = 9 or 
	    eof-work-mstr = "Y" 
	perform ba1-process-totals		thru ba1-99-exit 
	move "FINAL TOTALS **EXCLUDING** WRITE OFFS" 
						to   h9-title 
	perform wa6-write-final-totals		thru wa6-99-exit 
    else 
	move "WRITE OFF REPORT"			to   h3-title 
	move wk-agent-cd			to   save-agent-cd 
	perform ba0-process-report		thru ba0-99-exit 
	    until eof-work-mstr = "Y" 
	perform ba1-process-totals		thru ba1-99-exit 
	move "FINAL WRITE OFF TOTALS"		to    h9-title 
	perform wa6-write-final-totals		thru wa6-99-exit. 
*   endif 
 
    if eof-work-mstr not = "Y" 
    then 
	go to ab2-10-building-report. 
*   (else) 
*   endif 
 
ab2-99-exit. 
    exit. 
 
ba0-process-report. 
 
    if wk-agent-cd = save-agent-cd 
    then 
        perform ta0-add-to-totals		thru ta0-99-exit 
        perform ta1-add-to-dept-totals		thru ta1-99-exit 
	perform ta2-add-to-sub-totals		thru ta2-99-exit 
        perform wa1-write-detail-line  		thru wa1-99-exit 
    else 
	perform ba1-process-totals		thru ba1-99-exit 
        go to ba0-process-report. 
*   endif 
 
    read claims-work-mstr     
  	at end 
		move "Y"			to   eof-work-mstr 
		go to ba0-99-exit. 
    add 1					to ctr-claims-work-mstr-reads. 
 
ba0-99-exit. 
    exit. 
 
ba1-process-totals. 
 
    perform ta3-add-to-final-totals		thru ta3-99-exit. 
    perform wa2-write-total-detail-lines	thru wa2-99-exit. 
    perform wa5-write-dept-summary-lines	thru wa5-99-exit. 
    if save-agent-cd = 6 
    then 
	perform wa8-write-sub-summary-lines	thru wa8-99-exit. 
*   endif 
    perform ca3-clear-totals			thru ca3-99-exit. 
    move wk-agent-cd 				to save-agent-cd. 
 
ba1-99-exit. 
    exit. 
 
 
az0-finalization   section. 
 
    perform wa7-write-final-gr-totals		thru   wa7-99-exit. 
 
az0-10-end-of-job. 
 
    close claims-work-mstr 
          param-file  
          print-file. 
 
    accept sys-date				from     date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    accept sys-time				from time. 
*   display scr-closing-screen. 
*   display confirm. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
ca3-clear-totals. 
 
    move zeros				to  	current-tot 
						30-day-tot 
						60-day-tot  
						90-day-tot 
						120-day-tot 
						150-day-tot 
						180-day-tot 
						dept-total-table 
						sub-total-table 
						current-nbr-of-clms 
						30-day-nbr-of-clms 
						60-day-nbr-of-clms  
						90-day-nbr-of-clms 
						120-day-nbr-of-clms 
						150-day-nbr-of-clms 
						180-day-nbr-of-clms 
						total-amount 
						total-nbr-of-clms. 
 
    move 90				to	line-cnt. 
 
ca3-99-exit. 
    exit. 
 
 
ma1-move-to-print-rpt. 
 
    move spaces					to detail-line-1. 
    if test-date > wk-ser-date 
    then 
	move '*'				to d1-age-ind. 
*   endif 
 
    move wk-pat-acronym				to d1-pat-acron.   
    move wk-pat-id				to d1-pat-id. 
    move wk-clm-nbr				to d1-clm-nbr. 
    move wk-claim-nbr				to d1-claim-nbr. 
    move "/"					to d1-slash-1a. 
    move wk-dept-nbr				to d1-dept-nbr. 
    move wk-ohip-stat				to d1-ohip-stat. 
    move wk-sub-nbr				to d1-sub-nbr. 
    move wk-oma-fee				to d1-oma-fee. 
    move wk-ohip-fee				to d1-ohip-fee. 
    move wk-amount-paid				to d1-amount-paid. 
    move wk-balance-due				to d1-balance-due. 
    move wk-period-end-yy			to d1-period-yy. 
    move wk-period-end-mm			to d1-period-mm. 
    move wk-period-end-dd			to d1-period-dd. 
    move wk-ser-yy				to d1-ser-yy. 
    move wk-ser-mm				to d1-ser-mm. 
    move wk-ser-dd				to d1-ser-dd. 
 
    move '/'					to d1-slash1 
						   d1-slash2 
						   d1-slash3 
						   d1-slash4. 
 
    move wk-day-old				to d1-day-old. 
    move wk-batch-nbr-1-2			to d1-batch-nbr-1-2. 
*2003/12/10 MC
*    move wk-batch-nbr-3			to d1-batch-nbr-3. 
*2003/12/10 - end
    move wk-batch-nbr-4-9			to d1-batch-nbr-4-9. 
    move wk-act-taken				to d1-act-taken. 
    move wk-tape-submit-ind			to d1-tape-submit-ind. 
    move wk-agent-cd				to h3-agent. 
 
ma1-99-exit. 
    exit. 
ta0-add-to-totals.   
 
    if  wk-age-category =  0 
    then 
        add wk-balance-due		to current-tot        
        add 1				to current-nbr-of-clms  
    else  
  	if  wk-age-category = 1 
	then  
            add wk-balance-due		to 30-day-tot        
    	    add 1			to 30-day-nbr-of-clms    
	else 
            if  wk-age-category = 2 
	    then  
	   	add wk-balance-due	to 60-day-tot       
		add 1			to 60-day-nbr-of-clms     
	    else 
		if  wk-age-category = 3 
		then 
		    add wk-balance-due	to 90-day-tot            
		    add 1		to 90-day-nbr-of-clms  
		else 
		    if  wk-age-category = 4 
 
		    then  
			add wk-balance-due      to 120-day-tot      
			add 1			to 120-day-nbr-of-clms 
		    else 
			if wk-age-category = 5 
			then 
			    add wk-balance-due	to 150-day-tot 
			    add 1		to 150-day-nbr-of-clms 
			else 
			    if wk-age-category = 6 
			    then 
				add wk-balance-due to 180-day-tot 
				add 1	      	   to 180-day-nbr-of-clms. 
*			    endif 
*			endif 
*		    endif 
*		endif 
*	    endif 
*	endif 
*    endif 
 
ta0-99-exit. 
    exit. 
 
 
ta1-add-to-dept-totals. 
 
     if wk-dept-nbr < 1 or wk-dept-nbr > 99 
     then  
        move 4 				to err-ind 
        perform za0-common-error	thru za0-99-exit 
        go to az0-finalization		                 
    else 
        add wk-balance-due 		to  dept-tot(wk-dept-nbr) 
					    total-bal-due 

* MC2					
					    final-bal-due
	add wk-ohip-fee			to  total-ohip-fee 
* MC2					  
					    final-ohip-fee
* MC3 
        add wk-oma-fee			to  total-oma-fee
					    final-oma-fee
* MC3 - end
* MC2
*	add wk-amount-paid		to  total-amt-paid. 
	add wk-amount-paid		to  total-amt-paid 
					    final-amt-paid.
* MC2 - end
  
ta1-99-exit. 
    exit. 
 
 
ta2-add-to-sub-totals. 
 
    if wk-agent-cd = 6 
    then 
	move wk-sub-nbr 		to tp-sub-nbr 
	add 1				to tp-sub-nbr 
	add wk-balance-due 		to sub-tot(tp-sub-nbr). 
*   endif 
  
ta2-99-exit. 
    exit. 
 
 
ta3-add-to-final-totals. 
 
    compute total-amount = (current-tot  
			 	+ 30-day-tot 
				+ 60-day-tot 
				+ 90-day-tot 
				+ 120-day-tot 
				+ 150-day-tot 
				+ 180-day-tot). 
 
    compute total-nbr-of-clms = (current-nbr-of-clms 
				+ 30-day-nbr-of-clms 
				+ 60-day-nbr-of-clms 
				+ 90-day-nbr-of-clms 
				+ 120-day-nbr-of-clms 
				+ 150-day-nbr-of-clms 
				+ 180-day-nbr-of-clms). 
 
    add total-amount 		to grand-amount     
				   final-grand-amount(save-agent-cd + 1). 
    add total-nbr-of-clms	to grand-nbr-of-clms 
 				   final-grand-nbr-of-clms(save-agent-cd + 1). 
ta3-99-exit. 
    exit. 
 
wa1-write-detail-line.   
 
    if wk-age-category not = hold-ws-age-category 
    then 
        move 98				to 	line-cnt. 
*  (else) 
*   endif 
 
    add 1				to	line-cnt. 
 
    if line-cnt > 60 
    then 
        perform wa3-write-heading-for-rpt	thru wa3-99-exit. 
*   else 
*   endif 
 
    perform ma1-move-to-print-rpt           	thru ma1-99-exit. 
    write prt-line from detail-line-1 after advancing 1 line. 
    add 1				to 	ctr-detail-lines-writes. 
    move wk-age-category		to	hold-ws-age-category. 
 
wa1-99-exit. 
    exit. 
 
 
wa2-write-total-detail-lines. 
 
    move spaces				to detail-line-1. 
 
* MC3
    move total-oma-fee			to d1-oma-fee. 
* MC3 - end
    move total-ohip-fee			to d1-ohip-fee. 
    move total-amt-paid			to d1-amount-paid. 
    move total-bal-due			to d1-balance-due. 
 
    write prt-line from detail-line-1 
					after advancing 2 lines. 
 
    move zero				to total-ohip-fee 
* MC3
					   total-oma-fee
* MC3 - end
					   total-amt-paid 
					   total-bal-due. 
 
    if line-cnt > 24 
    then 
        add 1				to page-cnt 
        move page-cnt			to h1-page 
        write prt-line from head-line-1 after advancing  page 
        move save-agent-cd		to h3-agent 
        write prt-line from blank-line 	after advancing 1 line 
        write prt-line from head-line-3 after advancing 1 line. 
*  (else). 
*  (endif). 
 
    write prt-line from head-line-6 	after advancing 3 lines. 
    write prt-line from blank-line. 
    move " CURRENT"			to tot-title. 
    move current-tot			to tot-amt.   
    move current-nbr-of-clms		to tot-nbr-of-clms.   
    write prt-line from detail-line-2. 
    move " 30-DAYS"			to tot-title. 
    move 30-day-tot			to tot-amt. 
    move 30-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move " 60-DAYS"			to tot-title. 
    move 60-day-tot			to tot-amt. 
    move 60-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move " 90-DAYS"			to tot-title. 
    move 90-day-tot			to tot-amt. 
    move 90-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move "120-DAYS"			to tot-title. 
    move 120-day-tot			to tot-amt. 
    move 120-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move "150-DAYS"			to tot-title. 
    move 150-day-tot			to tot-amt. 
    move 150-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move "180-DAYS"			to tot-title. 
    move 180-day-tot			to tot-amt. 
    move 180-day-nbr-of-clms		to tot-nbr-of-clms. 
    write prt-line from detail-line-2. 
    move total-amount			to tot-amt-1. 
    move total-nbr-of-clms		to tot-nbr-of-clms-1. 
    write prt-line from detail-line-3. 
 
wa2-99-exit. 
    exit. 
 
 
wa3-write-heading-for-rpt. 
 
    add 1 				to page-cnt. 
    move page-cnt 			to h1-page. 
    move 0 				to line-cnt. 
    write prt-line from head-line-1 	after advancing page. 
    write prt-line from head-line-2. 
    move save-agent-cd 			to h3-agent. 
    write prt-line from head-line-3. 
    write prt-line from head-line-4 	after advancing 2 line. 
    write prt-line from head-line-5. 
    write prt-line from blank-line. 
    move 7				to line-cnt. 
 
wa3-99-exit. 
    exit. 
 
 
wa5-write-dept-summary-lines. 
 
    write prt-line from head-line-7 after advancing 5 lines. 
    write prt-line from head-line-10 after advancing 2 lines. 
    write prt-line from blank-line. 
    perform xa0-write-dept-totals	thru xa0-99-exit  
        varying i from 1 by 1 until i > 99. 
 
wa5-99-exit. 
    exit. 
 
 
wa6-write-final-totals. 
 
    add 4				to line-cnt.  
 
    if line-cnt > 60 
    then 
	add 1				to page-cnt 
	move page-cnt			to h1-page 
	write prt-line from head-line-1 after advancing page 
	write prt-line from head-line-2. 
*   (else) 
*   endif 
 
    write prt-line from head-line-9 after advancing 2 lines. 
    move grand-amount			to d9-amount. 
    move grand-nbr-of-clms		to d9-nbr-of-clms. 
    write prt-line from detail-line-9 	after advancing 2 lines. 
    move 0 				to line-cnt. 
    move zero				to grand-amount 
					   grand-nbr-of-clms. 
    move 60				to line-cnt. 
   
wa6-99-exit. 
    exit. 
 
wa7-write-final-gr-totals. 
 
    add 1				to	page-cnt. 
    move page-cnt			to	h1-page. 
    write prt-line from head-line-1 after advancing page. 
    write prt-line from head-line-2. 
    move "FINAL TOTALS **INCLUDING** WRITE OFFS" 
					to	h9-title. 
    write prt-line from head-line-9 after advancing 2 lines. 
*   move final-grand-amount		to	d9-amount. 
*   move final-grand-nbr-of-clms	to	d9-nbr-of-clms. 
*   write prt-line from detail-line-9 after advancing 2 lines. 
 
 
    move "NUMBER OF CLAIMS BY AGENT" 
					to	head-line-12-msg. 
    write prt-line from head-line-12 after advancing 3 lines. 
    write prt-line from head-line-13 after advancing 1 line. 
    perform wa7a-build-prt-line thru wa7a-99-exit 
              varying i 
              from 1 by 1 
              until i > 10. 
    write prt-line from detail-line-13 after advancing 1 line. 
    move "TOTAL:"                     to       d12-msg. 
    move final-grand-nbr-of-clms(11)  to	d12-ctr. 
    write prt-line from detail-line-12 after advancing 2 line. 
 
    move "-AMOUNT CLAIMED BY AGENT-" 
					to head-line-12-msg. 
    write prt-line from head-line-12 after advancing 3 lines. 
    write prt-line from head-line-13 after advancing 1 line. 
    perform wa7b-build-prt-line thru wa7b-99-exit 
              varying i 
              from 1 by 1 
              until i > 10. 
    write prt-line from detail-line-13 after advancing 1 line. 
    move final-grand-amount(11)         to	d12-ctr-total. 
    write prt-line from detail-line-12 after advancing 2 line. 
 
    write prt-line from blank-line. 

* MC2 
    write prt-line from head-line-final  after advancing 3 line. 
* MC3
    move final-oma-fee                to	d-final-oma-fee.
* MC3 - end
    move final-ohip-fee               to	d-final-ohip-fee.
    move final-amt-paid               to	d-final-amt-paid.
    move final-bal-due                to	d-final-bal-due.  
    write prt-line from detail-line-final after advancing 2 line. 
* MC2 - end
 
wa7-99-exit. 
    exit. 
 
wa8-write-sub-summary-lines. 
 
    write prt-line from head-line-8 after advancing 5 lines. 
    write prt-line from head-line-11 after advancing 2 lines. 
    write prt-line from blank-line. 
    perform xa1-write-sub-totals 	thru xa1-99-exit 
	varying i from 1 by 1 until i > 10. 
 
wa8-99-exit. 
    exit. 
 
 
wa7a-build-prt-line. 
    move final-grand-nbr-of-clms(i) to  d13-nbr-var(i). 
    add  final-grand-nbr-of-clms(i) to  final-grand-nbr-of-clms(11). 
wa7a-99-exit. 
    exit. 
 
wa7b-build-prt-line. 
    move final-grand-amount(i)      to  d13-amt-var(i). 
    add  final-grand-amount(i)      to  final-grand-amount(11). 
wa7b-99-exit. 
    exit. 
xa0-write-dept-totals. 
 
    if dept-tot(i) not > zero 
    then 
	go to xa0-99-exit. 
*   (else) 
*   endif 
 
    move i 			to d10-dept-nbr. 
    move dept-tot(i)		to dept-tot-amt. 
    write prt-line from detail-line-10. 
 
xa0-99-exit. 
    exit. 
 
 
xa1-write-sub-totals. 
 
    if sub-tot(i) not > zero 
    then 
	go to xa1-99-exit. 
*   (else) 
*   endif 
 
    subtract 1		from i			giving d11-sub-nbr. 
    move sub-tot(i)				to sub-tot-amt. 
    write prt-line from detail-line-11. 
 
xa1-99-exit. 
    exit. 
 
*xa2-check-header-done. 
 
*    if header-done = "N" 
*    then 
*        move "WRITE OFF REPORT" 		to h3-title 
*        move "Y" 				to header-done. 
*   (else) 
*   endif 
 
*xa2-99-exit. 
*    exit. 
 
 
*xa3-check-totals-written. 
 
*    if totals-written = "N" 
*    then 
*	move "FINAL TOTALS"			to    h9-title 
*	perform wa6-write-final-totals		thru wa6-99-exit 
*	move zero				to grand-amount 
*						   grand-nbr-of-clms 
*	move 60					to line-cnt 
*	move "Y"				to totals-written. 
*   (else) 
*   endif 
 
*xa3-99-exit. 
*    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment.      
*   display err-msg-line. 
    display err-msg-comment. 
*   display confirm. 
*   stop " ". 
*   display blank-line-24. 
 
    move "Y" 				to error-flag. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
