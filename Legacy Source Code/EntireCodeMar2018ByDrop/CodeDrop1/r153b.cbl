identification division. 
program-id.  r153b. 
author. dyad computer systems inc. 
installation. rma. 
date-written. 81/07/07. 
date-compiled. 
security. 
* 
*    files      : f020 - doctor master 
*		: f060 - cheque register 
*		: f070 - department master 
*		: f080 - bank master 
*		: f090 - iconstants master 
*		: work file 
*		: "R153A" - doctor statement of earnings 
*		: "R153B" - bank deposit list report 
*		: "R153C" - bank cheques 
* 
*    additional  files for eft development 
*               : "R153EF"  -  eft summary report 
*               : "EFT_CHG"  -  eft file  for changes in eft file
* 
*    program purpose : to print the doctor statement of earnings, 
* 		       bank deposit list and bank cheques  & 
*                      to print eft summary  report  and 
*                      create eft disk file for eft tape generation. 
*       r153a - does the sort phase
*       r153b - creates EFT file/reports
*                                         
*   revision history: 
*     date       programmer      reason 
*   82/05/        d. miller      - changed to access new cheque, constants & 
*			  	   doctor masters 
*   82/09/        d. miller      - programs r153 (dr.statements) & r140 
*				   (bank list & cheques) combined 
*   83/07/07      b. west	 - add printing of department name on physician statement 
* 
*   85/02/14	  i. warsh	 - temporary removal of the error message for 
*				   columns don'T BALANCE 
* 
*    86/06/05	  k. pirani	- include faculty expense for paycode 
*				- 4 in the statement of earnings 
* 
*    86/06/19     k. pirani     - expansion of bank-master-file address 
*				  field. this expanded address field 
*				  is printed on bank deposit list 
*				  report and bank cheques. 
* 
*    86/06/25     k. pirani     - include yearend option. 
* 
*    86/11/22     j. lam        - changes in bank nbr field, bank branch 
*                                 field, and bank account nbr field. 
*                               - modified  input screen. 
*                               - create disk file for "electronic fund 
*                                 transfer". 
*                               - print  eft summary report. 
* 
*    87/04/06	  j. lam	- change r153eft to r153ef (pdr 329) 
* 
*    87/05/27     s. blair      - coversion from aos to aos/vs. 
*                                 change field size for 
*                                 status clause to 2 and 
*                                 feedback clause to 4. 
* 
*    88/06/15     j. lam	- pdr 377 
*				- operator can write comment or date 
*				  on the last label of  statement of 
*				  earnings if it is a yearend statement. 
* 
*    89/03/10     s. fader      - sms 114 
*				- string the doctor name with 2 spaces 
*				  rather than 1 space, so dr. van der 
*				  meulen can be printed properly. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised june 28/89 : - s.f. 
*                        - modify section wa3 to be consistent with wa1 
* 
*   revised july 20/89 : - s.f. 
*                        - print tye report name on the top of all 
*                          reports 
* 
*   revised dec 6/89   : - s.f. 
*                        - comment out edit of date to allow date of 
*                          less than period end date 
* 
*   revised dec 6/90   : - b.m.l. sms 137 
*                        - increase percent sizes by 2 decimal places. 
* 
*   revised jul 7/91   : - b.m.l. pdr 501 
*                        - print of gst # for part time doctors. 
*           jul 16/91  : - b.m.l. add "r" infront of g.s.t. number. 
* 
*   revised nov 22/91    - m.c. pdr 433, 455, 515 
*			 - print the report name at the upper left 
*			   corner of the last page of r153a report 
 
*   93/jun/15   b.e.	- added access to u119_chgeft file.  values 
*			  from this file are then preset into f060 
*			  and programs works from the values in f060 
*			  as it originally did.  the statement generated 
*			  by this program are no longer valid - see 
*			  output of r124x.qzs programs.  bank statements 
*			  are valid. 
*   98/jun/15   B.E.    - unix conversion - sort had to be split from other
*                         processes so r153 split into r153a/b with 
*		  	  r153a performing only the sort. and r153b creating
*			  the EFT file and reports.
*
*   99/aug/19   B.E.    - added multi-payroll option for clinic 22 and 81
*
*   99/nov/15   B.E.    - added copybook so that all unique data for RMA 
*                         clinic 22/80 is not hard coded in pgm
*   00/nov/10   B.E.    - added 'mp' payroll processing - NOTE that clinic 99
*                         is used to run the 'mp' clinic payroll
*   03/nov/18   M.C.    - alpha doc nbr
* 2007/nov/14 be - cosmetic change to variable name  ws-nbr-settlement-account
* 2014/may/13 MC1       - change the field size in u119_chgeft.ps as it was changed from integer*8 to integer*10
*                       - transaction-type to 470 as requested by Helena
* 2014-may-14 be2	- use debit not credit values for this program

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f020_doctor_mstr.slr".          
* 
    copy "f060_cheque_reg_mstr.slr". 
* 
    copy "f070_dept_mstr.slr". 
* 
    copy "f080_bank_mstr.slr".      
* 
    copy "f090_constants_mstr.slr". 
 
* 
    copy "eft_logical_rec_file.slr". 
 
    select r153-work-file 
	assign to "r153_work_file" 
	organization is sequential. 
 
    select sorted-file 
        assign to ws-sorted-file 
        organization is  sequential. 
  
    select output-file 
        assign to ws-output-file 
        organization is  sequential. 
 
    select eft-constant-file 
        assign to "eft_constant" 
        organization is  sequential. 
 
 
 
    select  summary-eft 
        assign to printer  print-summary-eft 
        file status is  status-prt-summary-eft. 
 
 
 
* 
    select print-file-a 
	assign to printer print-file-a-name 
	file status is status-prt-file-a. 
* 
    select print-file-b 
	assign to printer print-file-b-name 
	file status is status-prt-file-b. 
* 
    select print-file-c 
	assign to printer print-file-c-name 
	file status is status-prt-file-c. 
 
* (93/jun/15) 
    select u119-chgeft-file 
	assign to "u119_chgeft.ps" 
	organization is sequential. 
 
data division. 
file section. 
* 

*   (2007/nov/15 b.e. unique MP definition)
*    copy "f020_doctor_mstr.fd".
    copy "f020_doctor_mstr_mp.fd".
 
 
    copy "f060_cheque_reg_mstr.fd". 
 
 
    copy "f070_dept_mstr.fd". 
 
 
    copy "f080_bank_mstr.fd".       
 
 
    copy "f090_constants_mstr.fd". 
 
 
    copy "f090_const_mstr_rec_3.ws". 
 
    copy "eft_logical_rec_file.fd". 
 
 
fd    u119-chgeft-file 
* MC1           record   contains  18  characters. 
                record   contains  22  characters. 
01    u119-chgeft-rec. 
*mf     (MF cobol wouldn't accept the sign in the front of the number
*mf      which PH placed there even though PH had 'unsigned' definition.
*mf      These numbers are always positive so "+" signed ignored.)
*mf          05   w-doc-nbr                        pic s9(4). 
* MC1 	     05   filler-sign1			   pic x(1).
* 2003/11/18 - MC 
*!           05   w-doc-nbr                        pic 9(3). 
             05   w-doc-nbr                        pic x(3). 
* 2003/11/18 - end
*mf          05   w-doc-dept                       pic s9(3). 
	     05   filler-sign2			   pic x(1).
             05   w-doc-dept                       pic 9(2). 
	     05   filler-sign			   pic x(01). 
* MC1        05   w-chgeft-amt-n                   pic 9(8)v99. 
             05   w-chgeft-amt-n                   pic 9(13)v99. 
* MC1 - end
 
sd  r153-work-file 
    block contains 65 characters. 
 
01  work-file-rec. 
    05  wf-bank-cd-branch. 
	10  wf-bank-cd				pic x(4). 
	10  wf-bank-branch			pic x(5). 
    05  wf-bank-acct-nbr			pic x(12). 
* 2003/11/18 - MC 
*!  05  wf-doc-nbr				pic 999. 
    05  wf-doc-nbr				pic xxx. 
* 2003/11/18 - end
    05  wf-pay					pic s9(6)v99. 
    05  wf-doc-inits.			 
	10  wf-init1				pic x. 
	10  wf-init2				pic x. 
	10  wf-init3				pic x. 
    05  wf-period-end. 
* (y2k)
*	10  wf-period-yy			pic 99. 
	10  wf-period-yy			pic 9(4). 
	10  wf-period-mm			pic 99. 
	10  wf-period-dd			pic 99. 
    05  wf-doc-name				pic x(24). 
 
 
 
sd    sorted-file 
                block    contains   1464  characters 
                record   contains   1464  characters. 
 
01    sorted-record. 
             05   s-record-type                   pic x. 
*mf          05   s-record-count                  pic 9(9). 
             05   s-record-count                  pic x(9). 
*            05   s-origin-contl-nbr              pic x(14). 
             05   s-originator-nbr		  pic x(14).
             05   s-mix-1                         pic x(150). 
             05   s-x-ref-nbr			  pic x(3). 
             05   s-mix-2			  pic x(1287). 
 
fd    output-file 
                block    contains   1464  characters 
                record   contains   1464  characters. 
 
01    output-record                               pic x(1464). 
 
 
 
fd  print-file-a 
    record contains 132 characters. 
 
01  prt-line-a					pic x(132). 
 
 
 
 
fd  print-file-b 
    record contains 77 characters. 
 
01  prt-line-b  				pic x(77). 
 
 
 
fd print-file-c 
    record contains 85 characters. 
 
01 prt-line-c    				pic x(85). 
 
 
fd  summary-eft 
    record  contains 132 characters. 
 
01  prt-summary                                 pic x(132). 
 
fd  eft-constant-file 
    record  contains  4 characters. 
01  eft-file-creation-nbr			pic 9(4). 
 
 
 
 
working-storage section. 

copy  "r153_bank_info.ws".
 
77  sel-clinic				pic 99		value zeroes. 
77  sel-ok  				pic x		value spaces. 
77  yearend-option    			pic x           value "N". 
77  err-ind				pic 99 		value zeroes. 
77  max-nbr-lines			pic 99   	value 60. 
77  max-form-lines			pic 99		value 44.    
77  form-cnt				pic 99  	value zeroes. 
77  page-cnt				pic 9999    	value zeroes. 
77  total-earnings                      pic s9(8)v99    value zero. 
77  ws-difference                       pic s9(8)v99    value zero. 
77  ws-inits				pic x(6)	value spaces. 
77  ws-inits-name			pic x(30)	value spaces. 
77  ws-final-total			pic 9(7)v99 	value zeroes. 
77  ws-bank-total			pic 9(6)v99 	value zeroes. 
77  ws-bank-total-1			pic 9(7)v99 	value zeroes. 
77  ws-rounded-total			pic 9(4) 	value zeroes. 
77  cur-bank-cd-branch			pic x(9)	value spaces. 
77  total-flag				pic x    	value "N". 
*  77  ws-print-percent			pic 999		value zeroes. 
77  ws-print-percent			pic 999v99	value zeroes. 
77  ws-print-gross-misc-total		pic s9(6)v99	value zeroes. 
77  ws-print-mtd-misc-total		pic s9(6)v99	value zeroes. 
77  ws-print-ytd-misc-total		pic s9(6)v99	value zeroes. 
* 
77  ws-closing-msg-a			pic x(50)	value 
		"doctor statements are in file r153a". 
77  ws-closing-msg-b			pic x(50)	value 
		"bank deposit list is in file r153b". 
77  ws-closing-msg-c			pic x(50)	value 
		"bank cheques are in file r153c". 
* 
* 
* 2003/11/18 - MC
*!77   n-doc-nbr                        pic s9(3)         value zero. 
77   n-doc-nbr                        pic x(3)         value spaces.
* 2003/11/18 - end

77   n-doc-dept                       pic s9(2)         value zero. 
77   n-chgeft-amt-n                   pic s9(7)v99      value zero. 
 
77  print-file-a-name			pic x(5)	value "r153a". 
77  print-file-b-name			pic x(5)        value "r153b". 
77  print-file-c-name			pic x(5)        value "r153c". 
* 
*77  print-summary-eft                   pic x(8)     value "r153eft". 
77  print-summary-eft                   pic x(8)     value "r153ef". 
* 
*	subscripts 
* 
77  ss-chq  				pic 99		value zeroes. 
77  ss-misc				pic 99		value zeroes. 
77  ss-amt				pic 99		value zeroes. 
77  ss-perc				pic 99		value zeroes. 
77  ss-mtd				pic 9		value 1. 
77  ss-ytd				pic 9		value 2.              
77  ss-mth-nbr				pic 99		value zeroes. 
* 
*  	eof indicators 
* 
77  eof-chq-reg-mstr			pic x		value "N". 
77  eof-doctor-mstr			pic x	 	value "N". 
77  eof-work-file			pic x		value "N". 
77  eof-u119-chgeft-file		pic x		value "N". 
* 
*  	status file indicators 
* 
77  common-status-file			pic x(2)       value zero. 
77  status-prt-file-a			pic xx  	value zero. 
77  status-prt-file-b			pic xx      	value zero. 
77  status-prt-file-c			pic xx      	value zero. 
77  status-prt-file-d                   pic xx          value zero. 
77  status-dept-mstr			pic x(11)       value spaces. 
77  status-bank-mstr			pic x(11)       value spaces. 
77  status-cobol-bank-mstr		pic x(2)        value zero. 
77  status-chq-reg-mstr			pic x(11) 	value spaces. 
77  status-cobol-chq-reg-mstr		pic xx		value zero. 
77  status-iconst-mstr			pic x(11)       value spaces. 
77  status-cobol-iconst-mstr		pic xx		value zero. 
77  status-doc-mstr			pic x(11)       value spaces. 
77  status-cobol-doc-mstr		pic x(2)	value zero.
77  status-cobol-dept-mstr              pic x(2)        value zero.
77  status-sort-file			pic x(11)       value zeroes. 
77  status-u119-chgeft-file		pic x(11)       value zeroes. 
* 
* 
*	feedbacks 
* 
77  feedback-doc-mstr			pic x(4)	value spaces. 
77  feedback-cheque-reg-mstr		pic x(4)	value spaces. 
77  feedback-iconst-mstr		pic x(4)	value spaces. 
*           
* 
* 
* 
 
01  ws-chq-date. 
* (y2k - auto fix)
*   05  ws-chq-yr			pic 99		value zeroes. 
    05  ws-chq-yr			pic 9(4)		value zeroes. 
    05  ws-chq-mth			pic 99		value zeroes. 
    05  ws-chq-day			pic 99		value zeroes. 
* 
01  ws-per-end-date. 
* (y2k - auto fix)
*   05  ws-per-end-yr			pic 99		value zeroes. 
    05  ws-per-end-yr			pic 9(4)		value zeroes. 
    05  ws-per-end-mth			pic 99		value zeroes. 
    05  ws-per-end-day			pic 99		value zeroes. 
* 
01  counters. 
    05  ctr-chq-reads         		pic 9(7)    value zero. 
    05  ctr-u119-chgeft-reads         	pic 9(7)    value zero. 
    05  ctr-wf-reads        		pic 9(7)    value zero. 
    05  ctr-wf-writes      		pic 9(7)    value zero. 
    05  ctr-doc-mstr-reads		pic 9(7)    value zero. 
    05  ctr-bank-mstr-reads		pic 9(7)    value zero. 
    05  ctr-lines			pic 99      value zero. 
    05  ctr-nbr-lines			pic 99      value zero. 
    05  ctr-rpt-writes			pic 9(7)    value zero. 
    05  ctr-cheques			pic 999     value zero. 
    05  ctr-nbr-misc-lines		pic 99      value zero. 
 
01  ws-initials. 
    05  ws-1st-init. 
	10  ws-init1			pic x. 
	10  ws-dot1			pic x. 
    05  ws-2nd-init. 
	10  ws-init2			pic x. 
	10  ws-dot2			pic x. 
    05  ws-3rd-init. 
	10  ws-init3			pic x. 
	10  ws-dot3			pic x. 
             
01  ws-postal-code. 
    05  ws-pc-153			pic xxx. 
    05  ws-pc-456			pic xxx. 
  
01  ws-doctor-totals. 
    05  ws-doc-totals-mtd-ytd occurs 2 times. 
 	10  ws-misc-gross occurs 10 times 	pic s9(6)v99. 
	10  ws-misc-net   occurs 10 times	pic s9(6)v99. 
	10  ws-bill-gross			pic s9(6)v99. 
	10  ws-bill-net				pic s9(6)v99. 
	10  ws-inc  	   	 		pic s9(6)v99. 
	10  ws-net-inc  	 		pic s9(6)v99. 
* 
* following stmt.  added.	  may/86     k.p. 
* 
	10  ws-exp-amt  			pic s9(6)v99. 
	10  ws-ceil-amt  			pic s9(6)v99. 
	10  ws-pay-due				pic s9(6)v99. 
	10  ws-tax 	            		pic s9(6)v99. 
	10  ws-bank-deposit			pic s9(6)v99. 
	10  ws-manual-chqs  			pic s9(6)v99. 
    05  ws-final-totals-mtd-ytd occurs 2 times. 
	10  ws-fin-misc-gross occurs 10 times 	pic s9(8)v99. 
	10  ws-fin-misc-net   occurs 10 times 	pic s9(8)v99. 
	10  ws-fin-bill-gross			pic s9(8)v99. 
	10  ws-fin-bill-net			pic s9(8)v99. 
	10  ws-fin-inc				pic s9(8)v99. 
* 
* following stmt. added 	may/86		k.p.	 
* 
	10  ws-fin-exp-amt			pic s9(8)v99. 
	10  ws-fin-ceil-amt			pic s9(8)v99. 
	10  ws-fin-pay-due			pic s9(8)v99. 
	10  ws-fin-tax				pic s9(8)v99. 
	10  ws-fin-deposit			pic s9(8)v99. 
	10  ws-fin-man-chqs			pic s9(8)v99. 
* 
* 
*-------------------------------------------------------------* 
*       eft tape creation       nov/86          j.l.          * 
*-------------------------------------------------------------* 
* 
77  ws-closing-msg-d                    pic x(50)       value 
                "eft disk files  is in file eft_tape". 
77  ws-closing-msg-e 			pic x(50)       value 
                "eft report summary is in  r153eft". 
* 
77  status-prt-summary-eft              pic xx          value zeros. 
* 
77   datecheck-option                   pic x           value "n". 
* 
77   ws-version-nbr             pic 9(4)	value zeroes. 
77   ws-record-count  		pic 999         value 1. 
* 
* 
* MC1
*77   ws-transaction-type        pic 999         value 200. 
77   ws-transaction-type        pic 999         value 470. 
* MC1 - end
77   ws-payee-acc-nbr 		pic x(12)       value spaces. 
77   ws-stored-trans-type       pic 999         value zeroes. 
*77   ws-payee-name              pic x(30)       value spaces. 
77   ws-sin-nbr     		pic x(19)       value spaces. 
77   ws-sundry                  pic x(15)       value spaces. 
77   ws-invalid-indicator       pic 9(11)       value zeroes. 
77   ws-settlement-indicator    pic 99          value   01. 
77   ws-seg-two-six             pic x(1200)     value spaces. 
77   ws-reserved                pic x(22)       value zeroes. 
77   i                          pic 99          value   01. 
 
 
* 
 
77   ws-total-debit-value       pic 9(12)v99    value zeroes. 
77   ws-total-debit-nbr         pic 9(8)        value zeroes. 
77   ws-total-credit-value      pic 9(12)v99    value zeroes. 
77   ws-total-credit-nbr        pic 9(8)        value zeroes. 
* 
* 
 
 
*77   ws-work-file-a            pic x(11)       value "work_file_a". 
77   ws-work-file-a             pic x(16)       value "work_file_a_r153". 
*77   ws-sorted-file            pic x(11)       value "sorted_file". 
77   ws-sorted-file             pic x(16)       value "sorted_file_r153". 
*77   ws-output-file            pic x(8)        value "eft_tape". 
77   ws-output-file             pic x(13)       value "eft_tape_r153". 
 
01   ws-payee-name. 
     05  ws-payee-last-name	pic x(24)	value spaces. 
     05  ws-payee-initial	pic x(6)	value spaces. 
 
01  ws-fund-avail-date. 
    05  ws-fund-yr 		pic 999 	value zeroes. 
    05  ws-fund-day 		pic 999 	value zeroes. 
 
 
01   ws-tape-creation-date. 
     05  ws-tape-yr		pic 999		value zeroes. 
     05  ws-tape-day		pic 999		value zeroes. 
 
 
01   ws-rec-type. 
     05  ws-rec-a		pic x 		value 'A'. 
*                                                      C = deposit D = Deduction
*    05  ws-rec-c		pic x		value 'C'.
     05  ws-rec-d		pic x		value 'D'.
     05  ws-rec-z   		pic x		value 'Z'. 
 
01   ws-bank-code. 
     05  ws-bank-nbr            pic 9(4). 
     05  ws-bank-branch         pic 9(5). 
 
 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
01   ws-xx 			pic xx		value "  ". 
 
copy "mth_desc_max_days.ws". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID REPLY". 
	10  filler				pic x(60)   value 
		"INVALID YEAR". 
	10  filler				pic x(60)   value 
		"INVALID MONTH". 
	10  filler				pic x(60)   value 
		"INVALID DAY". 
	10  filler				pic x(60)   value 
		"INVALID CLINIC NUMBER". 
	10  filler				pic x(60)   value 
		"NO CHEQUE RECORDS FOR THIS CLINIC". 
	10  filler				pic x(60)   value 
		"CANNOT ACCESS CONMSTR REC 3". 
	10  filler				pic x(60)   value 
		"CHEQUE DATE LESS THAN PERIOD END DATE". 
        10  filler                              pic x(60)   value
                "Invalid PAYROLL Clinic entered.".

    05  error-messages-r redefines error-messages.
        10  err-msg                             pic x(60)
                        occurs 9 times.
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  r153a-head-first. 
    05  filler					pic x(5)	value 
		"R153A". 
    05  filler					pic x(127)      value spaces. 
		 
 
01  r153a-head-1. 
    05  filler					pic x(7)	value 
		"TO:". 
    05  filler					pic xxxx	value 
		"DR.". 
    05  r153a-h1-inits-name			pic x(30)	value spaces. 
    05  filler					pic xxx	value spaces. 
    05  filler					pic x(6)	value 
		"NBR:". 
* 2003/11/18 - MC
*!  05  r153a-h1-doc-nbr			pic 999		value zeroes. 
    05  r153a-h1-doc-nbr			pic x(3)	value spaces. 
* 2003/11/18 - end
 
 
01  r153a-head-1-1. 
    05 filler                                   pic x(7)        value spaces. 
    05 r153a-h1-1-dept-name                     pic x(30). 
    05 filler                                	pic x(7)  	value spaces. 
    05  filler					pic x(6)	value  
		"DEPT:". 
    05  r153a-h1-dept				pic 99		value zeroes. 
 
01  r153a-head-2. 
    05  filler					pic x(7)	value 
		"FROM:". 
    05  filler					pic x(60)	value 
	"MR. JOHN E. MCCUTCHEON, FACMGA, EXECUTIVE DIRECTOR". 
 
01  r153a-head-3. 
    05  filler					pic x(7)	value 
		"DATE:". 
* (y2k - auto fix)
*   05  r153a-h3-yr					pic 99		value zeroes. 
    05  r153a-h3-yr					pic 9(4)		value zeroes. 
    05  filler					pic x		value "/". 
    05  r153a-h3-mth					pic 99		value zeroes. 
    05  filler					pic x		value "/". 
    05  r153a-h3-day					pic 99		value zeroes. 
 
01  r153a-head-4. 
    05  filler					pic x(29)	value spaces. 
    05  filler					pic x(40)	value 
		"REGIONAL MEDICAL ASSOCIATES". 
 
01  r153a-head-5. 
    05  filler					pic x(14)	value spaces. 
    05  filler					pic x(44)	value 
		"STATEMENT OF EARNINGS FOR THE PERIOD ENDING". 
* (y2k - auto fix)
*   05  r153a-h5-yr					pic 99		value zeroes. 
    05  r153a-h5-yr					pic 9(4)		value zeroes. 
    05  filler					pic x		value "/". 
    05  r153a-h5-mth					pic 99		value zeroes. 
    05  filler					pic x		value "/". 
    05  r153a-h5-day					pic 99		value zeroes. 
 
01  r153a-head-6. 
    05  filler					pic x(67)	value spaces. 
    05  filler					pic x(5)	value 
		"SINCE". 
 
01  r153a-head-7. 
    05  filler					pic x(45)	value spaces. 
    05  filler					pic x(10)	value 
		"THIS MONTH". 
    05  filler					pic x(8)	value spaces. 
* (y2k)
*   05  filler					pic x(10)	value 
    05  filler					pic x(08)	value 
*		"JULY 1, 19". 
		"JULY 1, ". 
*   05  r153a-h7-yr					pic 99. 
    05  r153a-h7-yr					pic 9(4). 
 
01  r153a-tot-head. 
    05  filler				pic x(20)	value spaces. 
    05  filler				pic x(60)	value 
		"***** STATEMENT OF EARNINGS FINAL TOTALS *****". 
 
01  underscore-detail. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x(11)	value 
		"-----------".                            
    05  filler					pic x(26)	value spaces. 
    05 filler					pic x(12)	value 
		"------------". 
    05  filler					pic x(7)	value spaces. 
    05  filler					pic x(13)	value 
		"-------------". 
 
01  underscore-total. 
    05  filler					pic x(43)	value spaces. 
    05  filler					pic x(12)	value 
		"------------". 
    05  filler					pic x(7)	value spaces. 
    05  filler					pic x(13)	value 
		"-------------". 
01  r153a-prt-1. 
    05  filler					pic x(6)	value spaces. 
    05  r153a-p1-lit-1				pic x		value "$". 
    05  r153a-p1-gross				pic zzz,zz9.99-	value zeroes. 
*   05  filler					pic xx		value spaces. 
    05  filler					pic x 		value spaces. 
    05  filler					pic x(14)	value 
		"MISC.INCOME @". 
*   05  r153a-p1-percent			pic zz9. 
    05  r153a-p1-percent			pic zz9.99. 
*   05  r153a-p1-percent-r redefines r153a-p1-percent pic xxx. 
    05  r153a-p1-percent-r redefines r153a-p1-percent pic xxxxxx. 
    05  filler					pic x		value "%". 
*   05  filler					pic x(5)	value spaces. 
    05  filler					pic x(3)	value spaces. 
    05  r153a-p1-lit-2				pic x		value "$". 
    05  r153a-p1-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  r153a-p1-lit-3				pic x		value "$".                   
    05  r153a-p1-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-2. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p2-gross				pic zzz,zz9.99-	value zeroes. 
    05  filler					pic xx		value spaces. 
    05  filler					pic x(23)	value 
		"TOTAL MISC. INCOME". 
    05  filler					pic x		value "$". 
    05  r153a-p2-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p2-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-3. 
    05  filler					pic xx 		value spaces. 
    05  r153a-p3-plus-lit					pic x(6).              
    05  r153a-p3-plus-lit-r redefines r153a-p3-plus-lit. 
	10  filler				pic x(5). 
	10  r153a-p3-lit-1			pic x. 
    05  r153a-p3-gross				pic zz,zz9.99-	value zeroes. 
*   05  filler					pic xx		value spaces. 
    05  filler					pic x		value spaces. 
    05  filler					pic x(14)	value 
		"BILLINGS    @ ". 
*   05  r153a-p3-percent			pic zz9. 
*   05  r153a-p3-percent-r redefines r153a-p3-percent pic xxx. 
    05  r153a-p3-percent			pic zz9.99. 
    05  r153a-p3-percent-r redefines r153a-p3-percent pic xxxxxx. 
    05  filler					pic x		value "%". 
*   05  filler					pic x(5)	value spaces. 
    05  filler					pic x(3)	value spaces. 
    05  r153a-p3-lit-2				pic x		value spaces. 
    05  r153a-p3-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  r153a-p3-lit-3				pic x		value spaces. 
    05  r153a-p3-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
* 
* r153a expense detail line added.	may/86	k.p. 
* 
 
01  r153a-prt-3-a. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"LESS FACULTY EXPENSE". 
    05  filler					pic x		value "$". 
    05  r153a-p3-a-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p3-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-4. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"TOTAL INCOME". 
    05  filler					pic x		value "$". 
    05  r153a-p4-mtd				pic zzzz,zz9.99-	value zeros. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p4-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-4-a. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"NET INCOME". 
    05  filler					pic x		value "$". 
    05  r153a-p4-a-mtd				pic zzzz,zz9.99-	value zeros. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p4-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-5. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"CEILING IS". 
    05  filler					pic x		value "$". 
    05  r153a-p5-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p5-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-6. 
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(35)	value 
		"PAYMENT DUE". 
    05  filler					pic x		value "$". 
    05  r153a-p6-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r153a-p6-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-7. 
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(34)	value 
		"LESS INCOME TAX". 
    05  filler					pic xx		value "(". 
    05  r153a-p7-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(05)	value ")". 
    05  filler					pic x(02)	value "(". 
    05  r153a-p7-ytd				pic zzzzz,zz9.99-	value zeroes.      
    05  filler					pic x		value ")". 
 
01  r153a-prt-8. 
    05  filler					pic x(08)	  value spaces. 
    05  filler					pic x(26)	  value     
		"AUTOMATIC BANK DEPOSIT ON ".  
* (y2k)
*   05  r153a-p8-yr				pic 9(02).      
    05  r153a-p8-yr				pic 9(04).      
    05  filler					pic x(01)	  value "/". 
    05  r153a-p8-mth				pic 9(02). 
    05  filler					pic x(01)	  value "/". 
    05  r153a-p8-day				pic 9(02). 
    05  filler                                  pic x(02)	  value " $". 
    05  r153a-p8-mtd				pic zzzz,zz9.99-  value zero. 
* (y2k)
*   05  filler					pic x(06)	  value spaces. 
    05  filler					pic x(04)	  value spaces. 

    05  filler					pic x(01)	  value "$". 
    05  r153a-p8-ytd				pic zzzzz,zz9.99- value zero. 
 
01  r153a-prt-9.       
    05  filler					pic x(08)	value spaces. 
*    05  filler					pic x(35)	value 
*		"PAID BY CHEQUE". 
*( pdr 377 allow operator to put comments or date on the yearend label) 
    05  yearend-label				pic x(35)	value 
		spaces. 
    05  filler					pic x(01)	value "$". 
    05  r153a-p9-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(06)	value spaces. 
    05  filler					pic x(01)	value "$". 
    05  r153a-p9-ytd				pic zzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-9-a. 
    05  filler					pic x(08)	value spaces. 
    05  filler        				pic x(35)	value                     "DEFICIT  ". 
    05  filler					pic x(20)	value spaces. 
    05  r153a-p9-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r153a-prt-10.    
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(68)	value 
		"A DETAILED LIST SHOWING EACH SERVICE FOR THE CURRENT MONTH IS MAILED". 
 
01  r153a-prt-11.     
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(78)	value 
	"TO YOUR OFFICE AT THE END OF EACH MONTH.  IF I CAN BE OF ANY ASSISTANCE,". 
 
01  r153a-prt-12.     
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(68)	value 
		"PLEASE CALL ME AT EXTENSION 2170 OR 525-9766.". 
 
**************************************************************** 
* for yearend only.	 
************************************************************ 
 
01  r153a-prt-13. 
    05  filler					pic x(20) 	value spaces. 
    05  filler 					pic x(112)      value   "FINAL YEAREND STATEMENT". 
 
01  r153a-prt-14. 
    05  filler					pic x(20) 	value spaces. 
    05  filler 					pic x(112)      value              "G.S.T. INCLUDED, G.S.T. REGISTRATION NUMBER R104453774". 
 
01  r153a-prt-err. 
    05  filler					pic x(20)	value 
		"********************". 
    05  filler					pic x(30)	value 
		"ERROR - COLUMNS DO NOT BALANCE". 
    05  filler					pic x(20)	value 
		"********************". 
01  r153b-head-first. 
    05  filler				pic x(5)	value "R153B". 
    05  filler       			pic x(72)	value spaces. 
 
 
01  r153b-head-1. 
    05  filler				pic x		value spaces. 
    05  r153b-h1-page			pic zzz9	value zeroes. 
    05  filler				pic x(12)	value spaces. 
    05  r153b-h1-bank-name		pic x(30)	value spaces. 
    05  filler				pic x(21)  	value spaces. 
 
01  r153b-head-2. 
    05  filler				pic x(17)  	value spaces. 
    05  r153b-h2-bank-addr 		pic x(43)	value spaces. 
    05  r153b-h2-mth			pic 99		value zeroes. 
    05  filler  			pic x 		value spaces. 
    05  r153b-h2-day			pic 99		value zeroes. 
    05  filler   			pic x   	value spaces. 
* (y2k - auto fix)
*   05  r153b-h2-yr			pic 99		value zeroes. 
    05  r153b-h2-yr			pic 9(4)		value zeroes. 
    05  filler 				pic x(9)	value spaces. 
 
01  r153b-head-2a. 
    05  filler				pic x(17)  	value spaces. 
    05  r153b-h2a-bank-addr 		pic x(60)	value spaces. 
 
01  r153b-head-3. 
    05  filler				pic x(17) 	value spaces. 
    05  r153b-h3-pc-153			pic xxx. 
    05  filler				pic x	  	value spaces. 
    05  r153b-h3-pc-456			pic xxx. 
    05  filler				pic x(61) 	value spaces. 
 
01  r153b-prt-1.    
    05  filler         			pic x(9). 
    05  r153b-p1-acct			pic x(12). 
    05  filler				pic x(2). 
    05  r153b-p1-dr-lit			pic x(4). 
    05  r153b-p1-inits      		pic x(6). 
    05  r153b-p1-name			pic x(24). 
    05  filler				pic x.     
    05  r153b-p1-pay			pic $zzzz,zz9vb99. 
01  r153c-head-first. 
    05  filler				pic x(5)  value "R153C". 
    05  filler          		pic x(80) value spaces. 
 
 
01 r153c-head-1. 
    05  filler				pic x(85) value 
		"  RMA MONTH'S EARNINGS". 
 
01  r153c-prt-1. 
    05  filler				pic x(27). 
    05  r153c-p1-chq-amt		pic $$$$,$$9vb99. 
    05  filler				pic x(12). 
    05  r153c-p1-mth			pic x(10). 
    05  r153c-p1-day			pic z9. 
    05  r153c-p1-comma			pic x(2). 
* (y2k)
*   05  r153c-p1-nineteen		pic 99. 
*   05  r153c-p1-yr			pic 99. 
    05  r153c-p1-yr			pic 9(4). 
 
01  r153c-prt-2. 
    05  filler				pic x(8). 
    05  r153c-p2-lit1			pic x(16). 
    05  r153c-p2-hundreds		pic ***9. 
    05  r153c-p2-lit2			pic x(28).    
    05  r153c-p2-chq-amt		pic $$$$,$$9.99. 
 
01  r153c-prt-3. 
    05  filler				pic x(8). 
    05  r153c-p3-pc-153			pic xxx. 
    05  filler				pic x. 
    05  r153c-p3-pc-456			pic xxx. 
 
01  r153c-prt-4. 
    05  filler				pic x(8). 
    05  r153c-p4-bank-name		pic x(77). 
 
01  r153c-prt-5. 
    05  filler				pic x(8). 
    05  r153c-p5-bank-addr1		pic x(77). 
 
01  r153c-prt-5a. 
    05  filler				pic x(8). 
    05  r153c-p5-bank-addr2		pic x(77). 
 
01  r153c-prt-6. 
    05  filler				pic x(8). 
    05  r153c-p6-city-prov		pic x(77). 
 
01 r153c-prt-7.                           
    05  filler				pic x(9). 
    05  r153c-p7-tot-chq		pic x(14). 
    05  r153c-p7-nbr-chqs		pic zzz9. 
    05  r153c-p7-tot-amt		pic x(13). 
    05  r153c-p7-fin-total		pic zzzz,zz9.99. 
 
01  blank-line. 
    05  filler				pic x(132)	value spaces. 
01  month-table. 
    05  months-list. 
	10  filler				pic x(9) value 
		"JANUARY". 
	10  filler				pic x(9) value 
		"FEBRUARY". 
	10  filler				pic x(9)  value 
		"MARCH". 
	10  filler				pic x(9)  value 
		"APRIL". 
	10  filler				pic x(9)  value 
		"MAY". 
	10  filler				pic x(9)  value 
		"JUNE". 
	10  filler				pic x(9)  value 
		"JULY". 
	10  filler				pic x(9)  value 
		"AUGUST". 
	10  filler				pic x(9)  value 
		"SEPTEMBER". 
	10  filler				pic x(9)  value 
		"OCTOBER". 
	10  filler				pic x(9)  value 
		"NOVEMBER". 
	10  filler				pic x(9)  value 
		"DECEMBER". 
 
    05  months-list-1 redefines months-list. 
	10  t-month				pic x(9) occurs 12 times. 
 
01  eft-prt-head. 
    05  filler		pic x(6)   value "R153EF". 
    05  filler          pic x(126) value spaces. 
 
 
01  eft-prt-1. 
    05  filler      				pic x(80)  value 
    "               SUMMARY REPORT FOR E.F.T. TAPE CREATION  ". 
 
 
01  eft-prt-2. 
    05  filler		pic x(20)  value spaces. 
    05  filler          pic x(30)  value "FILE CREATION NUMBER : ". 
    05  eft-creation    pic zzz9. 
 
01  eft-prt-3. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(30)  value "VERSION NUMBER       :". 
    05  eft-version     pic zzz9. 
 
01  eft-prt-4. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(30)  value "DATE FUND TO BE AVAILABLE : ". 
    05  eft-f-yr        pic z99. 
    05  filler          pic x      value "/". 
    05  eft-f-day       pic zz9. 
    05  filler          pic x(20)  value "   JULIAN DATE". 
 
01  eft-prt-5. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL NUMBER OF RECORDS      : ". 
    05  eft-record      pic zzzzzzzz9. 
 
01  eft-prt-6. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL NUMBER OF TRANSACTIONS : ". 
    05  eft-tran        pic zzzzzzzz9. 
 
01  eft-prt-7. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL VALUE  OF TRANSACTIONS : ". 
    05  eft-value       pic $$$,$$$,$$$,$$9.99. 
 
01  eft-prt-8. 
    05  filler          pic x(20)  value  spaces. 
    05  filler          pic x(30)  value "TAPE CREATION DATE :". 
* (y2k)
    05  eft-sy-yr       pic z99. 
    05  filler          pic x      value "/". 
    05  eft-sy-day      pic zz9. 
    05  filler          pic x(20)  value "   JULIAN DATE". 
procedure division. 
declaratives. 
 
err-chq-reg-file section. 
    use after standard error procedure on cheque-reg-mstr.    
err-chq-reg-mstr. 
    move status-chq-reg-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING CHEQUE-REG MASTER". 
    stop run. 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
    move status-iconst-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
    stop run. 
 
err-bank-mstr-file section. 
    use after standard error procedure on bank-mstr. 
err-bank-mstr. 
    move status-bank-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING BANK MASTER". 
    stop run. 
 
err-doc-mstr-file section. 
   use after standard error procedure on doc-mstr. 
err-doc-mstr. 
    move status-doc-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING DOCTOR MASTER". 
    stop run. 
 
err-dept-mstr-file section. 
    use after standard error procedure on dept-mstr. 
err-dept-mstr. 
    move status-dept-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING DEPT MASTER". 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization			thru 	aa0-99-exit. 
 
 
*------------------------------------------------------------------* 
*      eft diskfile is created while deposit-listing is created    * 
*------------------------------------------------------------------* 
 
*test      sort r153-work-file
*test      on ascending key 	wf-bank-cd-branch, 
*test		       	wf-bank-acct-nbr, 
*test			wf-doc-nbr 
*test      input procedure is ab1-wf-stmnts       	thru 	ab1-99-exit 
*test      output procedure is ab2-bank-list-chqs 	thru 	ab2-99-exit. 

    perform ab3-sort-eft-record			thru    ab3-99-exit. 
 
    perform az0-end-of-job			thru 	az0-99-exit. 
* 
    stop run. 
 
 
 
sec-51 section 51. 
 
 
aa0-initialization. 

* (y2) 
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-dd				to run-dd. 
* (y2k)
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
    move spaces				to	r153b-prt-1 
						r153c-prt-1 
						r153c-prt-2 
						r153c-prt-3 
						r153c-prt-4 
						r153c-prt-5 
						r153c-prt-5a 
						r153c-prt-6 
						r153c-prt-7. 
    move zero				to	counters 
						ws-bank-total   
						ws-final-totals-mtd-ytd (ss-mtd) 
						ws-final-totals-mtd-ytd (ss-ytd). 
 
    open input iconst-mstr. 
 
*   display scr-title. 
 
 
 
aa0-10-clinic.
 
    accept sel-clinic. 
    move sel-clinic			to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
      invalid key 
	move 5				to	err-ind 
 	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-clinic. 
 
* (y2k)
    move iconst-date-period-end-yy  	to	ws-per-end-yr. 
* (y2k)
    move iconst-date-period-end-mm 	to	ws-per-end-mth. 
* (y2k)
    move iconst-date-period-end-dd 	to	ws-per-end-day. 
 
* (y2k)
    if iconst-date-period-end-mm < 7 
    then 
* (y2k)
	subtract 1			from	iconst-date-period-end-yy. 
*   (else) 
*   endif 
 
* (y2k)
    move iconst-date-period-end-yy	to	r153a-h7-yr. 
****************************************************************
*   move iconst-date-period-end-mm      to      ss-chq.
*   (u119-chgeft-file values moved into 1st occurence of fiscal yr of f060
*    record and therefore hardcode subscript to 7)
    move 7                              to      ss-chq.
****************************************************************

    if ss-chq < 7
    then
        add 12                          to      ss-chq.
*   (else)
*   endif
 
    move 3				to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
	invalid key 
	    move 7			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    close iconst-mstr 
	    go to az0-100-end-job. 
 
    close iconst-mstr. 
* (y2k)
    move sys-yy				to	ws-chq-yr. 
    move sys-mm				to	ws-chq-mth. 
    move sys-dd				to	ws-chq-day. 
 
*   display msg-month. 
 
 
*    expunge print-file-a. 
*    expunge print-file-b. 
*    expunge print-file-c. 
 
*    expunge r153-work-file. 
*    expunge sorted-file. 
*    expunge output-file. 
*    expunge summary-eft. 
 
*    expunge eft-logical-rec-file. 
 
*test    open i-o    eft-constant-file. 
 
*mf open output output-file. 
*test    open output summary-eft. 
 
    perform  aa1-initialize-rec-a 	thru	aa1-99-exit 
                  varying     i         from    1   by   1 
                  until       i         greater  than    10. 
 
 
 
    move   ws-rec-a                  to    a-01-record-type. 
    move   ws-record-count           to    a-02-record-count. 

*   (verify that valid payroll clinic was entered)
*   CASE
    if sel-clinic = 22
    then
        move ws-originator-nbr-clinic-22  to    a-03-originator-number
    else
    if sel-clinic = 81
    then
        move ws-originator-nbr-clinic-81  to    a-03-originator-number
    else
    if sel-clinic = 85
    then
        move ws-originator-nbr-clinic-85  to    a-03-originator-number
    else
    if sel-clinic = 99
    then
        move ws-originator-nbr-clinic-mp  to    a-03-originator-number
    else
        move 9                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   ENDCASE

    move   ws-file-creation-nbr      to    a-04-file-creation-number. 

* y2k
    move   ws-tape-creation-date     to    a-05-creation-date. 
    move   ws-dest-data-centre       to    a-06-destination-data-centre. 
    move   spaces                    to    a-07-filler. 
    move   ws-version-nbr            to    a-08-version-number. 
*   (2007/11/14 be - cosmetic change to variable name)
*    move   ws-nbr-settlement-account to    a-09-settlement-account.
    move   ws-nbr-settlement-accounts to    a-09-settlement-account.

    move   ws-settlement-account     to    settlement-account(1).
    move   ws-institution-id         to    institution-id(1).
    
*mfbrad    write  eft-record-type-a. 
 
*------------------------------------------------------------------* 
 
 
* (y2k)
    move sys-yy				to	r153a-h3-yr. 
    move sys-mm				to	r153a-h3-mth. 
    move sys-dd				to	r153a-h3-day. 
* (y2k)
    move ws-per-end-yr			to	r153a-h5-yr. 
    move ws-per-end-mth			to	r153a-h5-mth. 
    move ws-per-end-day			to	r153a-h5-day. 
 
* (y2k)
    move ws-chq-yr			to	r153a-p8-yr. 
    move ws-chq-mth			to	r153a-p8-mth. 
    move ws-chq-day			to	r153a-p8-day. 
 
    move 1				to	r153b-h1-page. 
    move ws-chq-mth			to	r153b-h2-mth. 
    move ws-chq-day			to	r153b-h2-day. 
* (y2k)
    move ws-chq-yr			to	r153b-h2-yr. 
 
    move 999999.99			to	r153c-p1-chq-amt. 
    move t-month (ws-chq-mth)		to 	r153c-p1-mth. 
    move ws-chq-day			to 	r153c-p1-day. 
* (y2k)
    move ws-chq-yr			to 	r153c-p1-yr. 
    move ","				to 	r153c-p1-comma. 
* (y2k)
*   move 19				to 	r153c-p1-nineteen. 
 
    move zeroes				to	chq-reg-key. 
    move sel-clinic			to	chq-reg-clinic-nbr-1-2. 
 
********************************************************************* 
*mf    perform xa0-read-u119-build-f060	thru	xa0-99-exit. 
********************************************************************* 
*   read cheque-reg-mstr key is chq-reg-key approximate 
*     invalid key 
*	move 6				to	err-ind 
*	perform za0-common-error	thru	za0-99-exit 
*	go to az0-end-of-job. 
    add 1				to	ctr-chq-reads. 
 
    if chq-reg-clinic-nbr-1-2 not = sel-clinic 
    then 
	move 6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to az0-end-of-job. 
 
    if eof-chq-reg-mstr = "Y" 
    then 
	move 6				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
  	go to az0-end-of-job. 
*  (else) 
*   endif 
 
aa0-99-exit. 
    exit. 
 
 
aa1-initialize-rec-a. 
 
        move      zeroes		to 	institution-id(i). 
	move      spaces		to	settlement-account(i). 
 
aa1-99-exit. 
    exit. 
 
 
 
 
 
az0-end-of-job. 
 
*test    close summary-eft.
 
*    expunge r153-work-file. 
az0-100-end-job. 
 
*   display blank-screen. 
    accept sys-time			from time. 
*   display scr-closing-screen. 
 
*   call program "MENU". 
 
    stop run. 
 
az0-99-exit. 
    exit. 
ab1-wf-stmnts. 
 
    perform da0-read-doc-mstr   	thru 	da0-99-exit. 
 
    perform db0-read-dept-mstr     	thru	db0-99-exit. 
 
    perform ua1-add-to-totals		thru 	ua1-99-exit 
	varying	ss-mth-nbr 
	from    7 
	by      1 
	until	ss-mth-nbr > ss-chq.      
 
*   (suppress print if zero) 
 
    if    chq-reg-mth-misc-amt (ss-chq, 1)	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 2)	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 3)	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 4)  	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 5)  	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 6)  	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 7)  	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 8)	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 9)	= zero 
      and chq-reg-mth-misc-amt (ss-chq, 10)	= zero 
      and chq-reg-mth-bill-amt (ss-chq)         = zero 
      and ws-misc-gross (ss-ytd, 1)             = zero 
      and ws-misc-gross (ss-ytd, 2)		= zero 
      and ws-misc-gross (ss-ytd, 3)		= zero 
      and ws-misc-gross (ss-ytd, 4)		= zero 
      and ws-misc-gross (ss-ytd, 5)		= zero 
      and ws-misc-gross (ss-ytd, 6)		= zero 
      and ws-misc-gross (ss-ytd, 7)		= zero 
      and ws-misc-gross (ss-ytd, 8)		= zero 
      and ws-misc-gross (ss-ytd, 9)		= zero 
      and ws-misc-gross (ss-ytd,10)		= zero 
      and ws-bill-gross (ss-ytd)		= zero 
      and ws-inc        (ss-ytd)		= zero 
      and ws-pay-due    (ss-ytd)		= zero 
      and ws-tax        (ss-ytd)		= zero 
      and ws-bank-deposit(ss-ytd)		= zero 
      and ws-manual-chqs (ss-ytd)		= zero 
    then 
	go to ab1-10-next-record.  
*   (else) 
*   endif 
 
    perform wa0-write-headings			thru 	wa0-99-exit. 
               
    perform wa1-write-report			thru 	wa1-99-exit. 
 
 
    if chq-reg-regular-pay-this-mth (ss-chq) not = 0 
    then 
        perform wb0-write-c-record              thru    wb0-99-exit 
	perform ba0-write-wf			thru	ba0-99-exit. 
*   (else) 
*   endif 
 
 
 
 
 
ab1-10-next-record.   
 
    perform bb0-read-next-chq            	thru 	bb0-99-exit. 
 
    if eof-chq-reg-mstr not = "Y" 
    then 
    	go to ab1-wf-stmnts. 
*   (else) 
*   endif 
 
    perform wa3-print-totals			thru	wa3-99-exit. 
 
    perform wb1-write-z-record 			thru	wb1-99-exit. 
 
ab1-99-exit. 
    exit. 
 
 
wb0-write-c-record. 
 
    add    1   to  ws-record-count. 

*   be2
*    add    1   to  ws-total-credit-nbr. 
    add    1   to  ws-total-debit-nbr. 

*  be2
*    add    ws-bank-deposit (ss-mtd)       to  ws-total-credit-value. 
    add    ws-bank-deposit (ss-mtd)       to  ws-total-debit-value. 
 
    move   doc-bank-nbr			  to  ws-bank-nbr. 
    move   doc-bank-branch                to  ws-bank-branch. 
    move   doc-bank-acct                  to  ws-payee-acc-nbr. 
    move   doc-nbr                        to  ws-sin-nbr. 
*   move   doc-name                       to  ws-payee-name. 
    move   doc-name			  to  ws-payee-last-name. 
    move   doc-inits			  to  ws-payee-initial. 
 
*   display  screen-traces. 
 
    move   ws-rec-d                       to  c-01-record-type. 
    move   ws-record-count                to  c-02-record-count. 

*   move   ws-origin-contl-nbr            to  c-03-origin-contl-nbr. 

*   CASE
    if sel-clinic = 22
    then
        move ws-originator-nbr-clinic-22  to    c-03-originator-nbr
    else
    if sel-clinic = 81
    then
        move ws-originator-nbr-clinic-81  to    c-03-originator-nbr
    else
    if sel-clinic = 85
    then
        move ws-originator-nbr-clinic-85  to    c-03-originator-nbr
    else
    if sel-clinic = 99
    then
        move ws-originator-nbr-clinic-mp  to    c-03-originator-nbr
    else
        move 9                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   ENDCASE

    move   ws-file-creation-nbr      to    a-04-file-creation-number. 


    move   ws-transaction-type            to  c-04-transaction-type. 
    move   ws-bank-deposit (ss-mtd)       to  c-05-amount. 
* (y2k)
    move   ws-fund-avail-date             to  c-06-fund-available-date. 
    move   ws-bank-code                   to  c-07-bank-nbr. 
    move   ws-payee-acc-nbr               to  c-08-payee-acc-nbr. 
    move   ws-reserved                    to  c-09-reserved. 
    move   ws-stored-trans-type           to  c-10-stored-trans-type. 
    move   ws-short-name                  to  c-11-short-name. 
    move   ws-payee-name		  to  c-12-payee-name. 
    move   ws-long-name                   to  c-13-long-name. 

*   (verify that valid payroll clinic was entered)
*   CASE
    if sel-clinic = 22
    then
        move ws-originator-nbr-clinic-22  to    c-14-originator-nbr
    else
    if sel-clinic = 81
    then
        move ws-originator-nbr-clinic-81  to    c-14-originator-nbr
    else
    if sel-clinic = 85
    then
        move ws-originator-nbr-clinic-85  to    c-14-originator-nbr
    else
    if sel-clinic = 99
    then
        move ws-originator-nbr-clinic-mp  to    c-14-originator-nbr
    else
        move 9                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to az0-end-of-job.
*   ENDCASE

    move   ws-sin-nbr                     to  c-15-cross-ref-nbr. 
    move   ws-institution-return          to  c-16-institution-return. 
    move   ws-account-return              to  c-17-account-return. 
    move   ws-sundry                      to  c-18-sundry. 
    move   spaces                         to  c-19-filler. 
    move   ws-settlement-indicator        to  c-20-settlement-indicator. 
    move   ws-invalid-indicator           to  c-21-invalid-indicator. 
    move   ws-seg-two-six                 to  c-seg-two-six. 
 
*mf brad    write  eft-record-type-c. 
 
wb0-99-exit. 
 
 
sec-60  section 60. 
 
 
wb1-write-z-record. 
 
    add    1				  to  ws-record-count. 
    move   ws-rec-z                       to  z-01-record-type. 
    move   ws-record-count		  to  z-02-record-count. 

*   move   ws-origin-contl-nbr            to  z-03-origin-contl-nbr. 
*   CASE
    if sel-clinic = 22
    then
        move ws-originator-nbr-clinic-22  to    z-03-originator-nbr
    else
    if sel-clinic = 81
    then
        move ws-originator-nbr-clinic-81  to    z-03-originator-nbr
    else
    if sel-clinic = 85
    then
        move ws-originator-nbr-clinic-85  to    z-03-originator-nbr
    else
    if sel-clinic = 99
    then
        move ws-originator-nbr-clinic-mp  to    z-03-originator-nbr
    else
        move 9                            to    err-ind
        perform za0-common-error          thru  za0-99-exit
        go to az0-end-of-job.
*   ENDCASE

    move   ws-file-creation-nbr           to    z-03-file-creation-number.

    move   ws-total-debit-value           to  z-04-total-debit-value. 
    move   ws-total-debit-nbr             to  z-05-total-debit-nbr. 
    move   ws-total-credit-value          to  z-06-total-credit-value. 
    move   ws-total-credit-nbr            to  z-07-total-credit-nbr. 
    move   spaces                         to  z-08-filler. 
 
*   display  screen-traces-1. 
 
    write  eft-record-type-z. 
 
wb1-99-exit. 
    exit. 
 
 
fa0-eft-summary. 
 
     move spaces        to    prt-summary. 
     write   prt-summary   from   eft-prt-head  after page. 
     move spaces        to    prt-summary. 
     move eft-prt-1     to    prt-summary. 
*    write   prt-summary   after  advancing 6 lines. 
     write   prt-summary   after  advancing 5 lines. 
 
     move ws-file-creation-nbr    to    eft-creation. 
     move ws-version-nbr          to    eft-version. 
* (y2k)
     move ws-fund-yr              to    eft-f-yr. 
     move ws-fund-day             to    eft-f-day. 
     move ws-record-count         to    eft-record. 

*    be2 use debit not credit values for this program
*     move ws-total-credit-nbr     to    eft-tran. 
     move ws-total-debit-nbr     to    eft-tran. 
*     move ws-total-credit-value   to    eft-value. 
     move ws-total-debit-value   to    eft-value. 
* (y2k)
     move ws-tape-yr              to    eft-sy-yr. 
     move ws-tape-day             to    eft-sy-day. 
 
     write    prt-summary  from   eft-prt-2  after  2  lines. 
     write    prt-summary  from   eft-prt-3  after  2  lines. 
     write    prt-summary  from   eft-prt-4  after  2  lines. 
     write    prt-summary  from   eft-prt-5  after  2  lines. 
     write    prt-summary  from   eft-prt-6  after  2  lines. 
     write    prt-summary  from   eft-prt-7  after  2  lines. 
     write    prt-summary  from   eft-prt-8  after  2  lines. 
 
 
fa0-99-exit. 
 
ab2-bank-list-chqs. 
 
    perform cc2-read-work-file		thru	cc2-99-exit. 
    move 0				to	cur-bank-cd-branch. 
 
ab2-10-next-record. 
 
    if wf-bank-cd-branch not = cur-bank-cd-branch 
    then 
      move wf-bank-cd-branch		to	cur-bank-cd-branch 
      perform ca0-get-address-bank-mstr	thru	ca0-99-exit 
      perform cb0-print-headings	thru	cb0-99-exit 
      perform ea0-bank-info-to-chq   	thru	ea0-99-exit. 
*   (else) 
*   endif 
 
    perform cc0-process-docs-by-branch	thru	cc0-99-exit 
	until 	wf-bank-cd-branch not = cur-bank-cd-branch 
	     or eof-work-file = "Y". 
 
    if ws-bank-total not = zeroes 
    then 
        perform cd0-write-bank-total	thru	cd0-99-exit  
    	perform eb0-write-chq		thru	eb0-99-exit. 
*   (else) 
*   endif 
 
    if eof-work-file not = "Y" 
    then 
	go to ab2-10-next-record. 
*   (else) 
*   endif 
 
    perform ed0-print-totals		thru	ed0-99-exit. 
 
ab2-99-exit. 
    exit. 
 
 
 
ab3-sort-eft-record. 
 
*test	close            eft-logical-rec-file. 
*test	open    input    eft-logical-rec-file. 
 
        sort    sorted-file 
                on   ascending key    s-record-type, 
                                      s-record-count, 
                                      s-x-ref-nbr 
                using    eft-logical-rec-file 
                giving   output-file. 

*test perform  fa0-eft-summary     	thru	fa0-99-exit. 
 
ab3-99-exit. 
   exit.
 
 
ba0-write-wf.           
 
    if sel-clinic not = doc-clinic-nbr 
    then 
	go to ba0-99-exit. 
*   (else) 
*   endif 
 
    move doc-bank-nbr			to	wf-bank-cd. 
    move doc-bank-branch		to	wf-bank-branch. 
    move doc-bank-acct			to	wf-bank-acct-nbr. 
    move doc-nbr			to	wf-doc-nbr. 
    move doc-inits			to	wf-doc-inits. 
    move doc-name			to	wf-doc-name. 
    move chq-reg-regular-pay-this-mth (ss-chq) 
					to	wf-pay. 
* (y2k)
    move chq-reg-pay-date (ss-chq)	to 	wf-period-end. 
 
    release work-file-rec. 
    add 1				to 	ctr-wf-writes.        
 
ba0-99-exit. 
    exit. 
 
 
 
 
bb0-read-next-chq.  
 
*   read cheque-reg-mstr next 
*     at end 
*	move "Y"			to 	eof-chq-reg-mstr 
*	go to bb0-99-exit. 
    add 1				to	ctr-chq-reads. 
*********************************************************************** 
    perform xa0-read-u119-build-f060	thru	xa0-99-exit. 
*********************************************************************** 
 
*   if chq-reg-clinic-nbr-1-2 not = sel-clinic 
*   then 
*	move "Y"			to 	eof-chq-reg-mstr. 
*   (else) 
*   endif 
 
bb0-99-exit. 
  exit. 
ca0-get-address-bank-mstr. 
 
    move cur-bank-cd-branch		to	bank-cd. 
    read bank-mstr 
      invalid key 
	move "ADDRESS UNKNOWN"		to	bank-name 
	move spaces 			to	bank-address1 
						bank-address2 
						bank-city-prov 
						bank-postal-cd 
	go to ca0-99-exit. 
 
    add 1				to	ctr-bank-mstr-reads. 
 
ca0-99-exit. 
    exit. 
 
 
cb0-print-headings. 
  
    write prt-line-b from r153b-head-first	after 	page. 
    add 1 				to 	page-cnt. 
    move page-cnt			to 	r153b-h1-page. 
    move bank-name			to	r153b-h1-bank-name. 
*   write prt-line-b from r153b-head-1 	after 	page. 
    write prt-line-b from r153b-head-1 	after 	1 line. 
    move spaces				to	r153b-h1-bank-name. 
 
    move bank-address1			to	r153b-h2-bank-addr. 
    move ws-chq-mth			to	r153b-h2-mth. 
    move ws-chq-day			to	r153b-h2-day. 
* (y2k)
    move ws-chq-yr 			to	r153b-h2-yr. 
    write prt-line-b from r153b-head-2 	after 	1 line. 
    move spaces 			to	r153b-head-2. 
 
    move bank-address2			to	r153b-h2a-bank-addr. 
    write prt-line-b from r153b-head-2a after 	1 line. 
    move spaces 			to	r153b-head-2a. 
 
    move bank-city-prov			to	r153b-h2a-bank-addr. 
    write prt-line-b from r153b-head-2a	after 	1 line. 
    move spaces 			to	r153b-head-2a. 
 
    move bank-postal-cd			to	ws-postal-code. 
    move ws-pc-153		to	r153b-h3-pc-153. 
    move ws-pc-456		to	r153b-h3-pc-456. 
    write prt-line-b from r153b-head-3 	after 	1 line.                 
    move spaces				to	r153b-head-3.       
                                          
    write prt-line-b from r153b-head-2 	after 	5 lines. 
    move 19				to	ctr-lines. 
    move zeros				to 	form-cnt. 
 
 
cb0-99-exit. 
    exit. 
 
cc0-process-docs-by-branch. 
 
    move wf-bank-acct-nbr			to	r153b-p1-acct. 
    move "DR."				to	r153b-p1-dr-lit. 
 
    move spaces				to	ws-inits 
						ws-initials. 
 
    if wf-init1 not = spaces 
    then 
	move wf-init1			to	ws-init1 
	move "."			to	ws-dot1.   
*   (else) 
*   endif 
 
    if wf-init2 not = spaces 
    then 
	move wf-init2			to	ws-init2 
	move "."			to	ws-dot2. 
*   (else) 
*   endif 
 
    if wf-init3 not = spaces 
    then 
	move wf-init3			to	ws-init3 
	move "."			to	ws-dot3. 
*   (else) 
*   endif 
 
    string ws-1st-init delimited by spaces, 
	   ws-2nd-init delimited by spaces, 
	   ws-3rd-init delimited by spaces, 
					into	ws-inits.          
    move ws-inits     		to	r153b-p1-inits. 
    move wf-doc-name		to	r153b-p1-name. 
 
    move wf-pay				to	r153b-p1-pay. 
    perform cc1-write-detail-line	thru	cc1-99-exit. 
    add wf-pay				to	ws-bank-total. 
    perform cc2-read-work-file		thru	cc2-99-exit. 
 
cc0-99-exit. 
    exit. 
cc1-write-detail-line. 
 
    if ctr-lines > max-nbr-lines 
    then 
	perform cb0-print-headings	thru	cb0-99-exit. 
*   (else) 
*   endif 
 
    if total-flag = "Y" 
    then 
        write prt-line-b from r153b-prt-1 after advancing ctr-nbr-lines lines 
        move "N" to total-flag 
    else 
        write prt-line-b from r153b-prt-1 after advancing 2 lines. 
*    endif. 
 
    move spaces				to	r153b-prt-1. 
    add 2				to	ctr-lines  
						form-cnt. 
 
cc1-99-exit. 
    exit. 
 
 
 
 
cc2-read-work-file. 
 
    return r153-work-file 
      at end 
	move "Y"			to	eof-work-file 
	go to cc2-99-exit. 
 
    add 1				to	ctr-wf-reads.         
 
cc2-99-exit. 
    exit. 
 
 
 
cd0-write-bank-total. 
 
    move "BANK TOTAL"			to	r153b-p1-name. 
    move ws-bank-total			to	r153b-p1-pay. 
 
    subtract form-cnt from max-form-lines giving ctr-nbr-lines. 
 
    move "Y" 				to	total-flag. 
 
    perform cc1-write-detail-line	thru	cc1-99-exit. 
 
cd0-99-exit. 
    exit. 
 
 
 
da0-read-doc-mstr. 
 
    move chq-reg-doc-nbr		to	doc-nbr. 
    move zeroes				to	ws-doc-totals-mtd-ytd (ss-mtd) 
						ws-doc-totals-mtd-ytd (ss-ytd). 
 
    read doc-mstr 
      invalid key 
	move spaces			to	doc-mstr-rec 
	move chq-reg-doc-nbr		to	doc-nbr 
	move "***UNKNOWN***"		to	doc-name 
	move zeros			to	doc-bank-nbr 
						doc-bank-branch 
						doc-bank-acct 
	move chq-reg-clinic-nbr-1-2	to	doc-clinic-nbr 
	go to da0-99-exit. 
 
    add 1				to	ctr-doc-mstr-reads. 
 
da0-99-exit. 
    exit. 
 
 
 
 
db0-read-dept-mstr. 
 
    move doc-dept to dept-nbr. 
    read dept-mstr 
	 invalid key 
	 move "***INVALID DEPT NUMBER***" to dept-name. 
 
db0-99-exit. 
    exit. 
 
 
ea0-bank-info-to-chq. 
 
    move bank-name			to	r153c-p4-bank-name. 
    move bank-address1			to	r153c-p5-bank-addr1. 
    move bank-address2			to	r153c-p5-bank-addr2. 
    move bank-city-prov			to	r153c-p6-city-prov. 
    move bank-postal-cd			to	ws-postal-code. 
    move ws-pc-153			to	r153c-p3-pc-153. 
    move ws-pc-456			to	r153c-p3-pc-456.  
 
ea0-99-exit. 
    exit. 
 
eb0-write-chq.        
 
    move ws-bank-total			to	r153c-p1-chq-amt 
						r153c-p2-chq-amt.  
***  rounded off total to nearest hundred 
    add 99.99, ws-bank-total		giving	ws-bank-total-1. 
    divide 100				into	ws-bank-total-1 
					giving	ws-rounded-total. 
    move ws-rounded-total		to	r153c-p2-hundreds. 
 
 
*   write prt-line-c from blank-line  	after 	page. 
    write prt-line-c from r153c-head-first 	after page. 
    write prt-line-c from r153c-head-1 	after	5 lines. 
    write prt-line-c from r153c-prt-1 	after 	1 line. 
    move "NOT TO EXCEED***"		to	r153c-p2-lit1. 
    move "****HUNDRED DOLLARS"		to	r153c-p2-lit2. 
    write prt-line-c from r153c-prt-2 	after 	6 lines.              
    write prt-line-c from r153c-prt-4 	after 	4 lines.           
    write prt-line-c from r153c-prt-5 	after 	1 line.           
    write prt-line-c from r153c-prt-5a 	after 	1 line. 
    write prt-line-c from r153c-prt-6 	after 	1 line.              
    write prt-line-c from r153c-prt-3 	after 	1 line.                
    move spaces				to	r153c-prt-2  
						r153c-prt-3 
						r153c-prt-4             
						r153c-prt-5        
						r153c-prt-5a 
						r153c-prt-6. 
 
    add 1				to	ctr-cheques. 
    add ws-bank-total			to	ws-final-total. 
    move 0				to	ws-bank-total. 
 
eb0-99-exit. 
    exit. 
 
 
 
ed0-print-totals. 
 
    add 1 				to	page-cnt. 
    move page-cnt			to	r153b-h1-page. 
                                                               
*   write prt-line-b from blank-line	after	page. 
    write prt-line-b from r153b-head-first 	after page. 
 
    move "FINAL TOTAL"			to	r153b-p1-name. 
    move ws-final-total			to	r153b-p1-pay. 
    write prt-line-b from r153b-prt-1 	after 	19 lines. 
 
    write prt-line-c from r153c-head-first       after page. 
    move "TOTAL CHEQUES-"		to	r153c-p7-tot-chq. 
    move "  TOTAL AMT-"			to	r153c-p7-tot-amt. 
    move ctr-cheques			to	r153c-p7-nbr-chqs. 
    move ws-final-total			to	r153c-p7-fin-total. 
    write prt-line-c from r153c-prt-7 	after 	18 lines.            
 
ed0-99-exit. 
    exit. 
ua1-add-to-totals. 
 
*	calculate net mtd 
 
    if chq-reg-mth-misc-amt (ss-mth-nbr, 1) not = zeroes 
    then 
	add chq-reg-mth-misc-amt (ss-mth-nbr, 1) 
					to	ws-misc-gross (ss-mtd,1) 
	multiply chq-reg-mth-misc-amt (ss-mth-nbr, 1) 
					by	chq-reg-perc-misc (ss-mth-nbr) 
					giving	ws-misc-net (ss-mtd,1) rounded 
	add ws-misc-net (ss-mtd,1)		to	ws-inc (ss-mtd). 
*   (else) 
*   endif 
 
    perform ua2-remaining-misc		thru	ua2-99-exit 
	varying	ss-misc 
		from 2 by 1 
	until	ss-misc > 10. 
 
    if chq-reg-mth-bill-amt (ss-mth-nbr) not = zeroes 
    then 
	add chq-reg-mth-bill-amt (ss-mth-nbr) to	ws-bill-gross (ss-mtd) 
	multiply chq-reg-mth-bill-amt (ss-mth-nbr) 
					by	chq-reg-perc-bill (ss-mth-nbr) 
					giving	ws-bill-net (ss-mtd) rounded 
	add ws-bill-net (ss-mtd)			to	ws-inc (ss-mtd). 
*   (else) 
*   endif 
 
* 
*  stmt. added 		may/86		k.p. 
* 
    move chq-reg-mth-exp-amt (ss-mth-nbr)	to	ws-exp-amt (ss-mtd). 
 
    move chq-reg-mth-ceil-amt (ss-mth-nbr)	to	ws-ceil-amt (ss-mtd). 
 
    add	chq-reg-earnings-this-mth (ss-mth-nbr) 
	chq-reg-man-tax-this-mth  (ss-mth-nbr) 
	chq-reg-man-pay-this-mth  (ss-mth-nbr) 
					giving	ws-pay-due (ss-mtd). 
 
    add chq-reg-regular-tax-this-mth (ss-mth-nbr) 
	chq-reg-man-tax-this-mth     (ss-mth-nbr) 
					giving	ws-tax (ss-mtd). 
 
    move chq-reg-regular-pay-this-mth (ss-mth-nbr) 
					to    	ws-bank-deposit (ss-mtd). 
    move chq-reg-man-pay-this-mth     (ss-mth-nbr) 
					to      ws-manual-chqs   (ss-mtd). 
 
*	update ytd 
 
    perform ua3-add-misc-to-ytd		thru	ua3-99-exit 
	varying	ss-misc 
		from 1 by 1 
	until	ss-misc > 10. 
 
    add ws-bill-gross   (ss-mtd)	to	ws-bill-gross   (ss-ytd). 
    add ws-bill-net     (ss-mtd)	to	ws-bill-net     (ss-ytd). 
    add ws-inc          (ss-mtd)	to	ws-inc          (ss-ytd). 
* 
*  stmt.  added.		jun/86		k.p. 
* 
    add ws-exp-amt      (ss-mtd)	to	ws-exp-amt      (ss-ytd). 
    add ws-ceil-amt     (ss-mtd)	to	ws-ceil-amt     (ss-ytd). 
    add ws-pay-due      (ss-mtd)	to	ws-pay-due      (ss-ytd). 
    add ws-tax          (ss-mtd)	to	ws-tax          (ss-ytd). 
    add ws-bank-deposit (ss-mtd)	to    	ws-bank-deposit (ss-ytd). 
    add ws-manual-chqs  (ss-mtd)	to      ws-manual-chqs  (ss-ytd). 
 
    if ss-mth-nbr not = ss-chq 
    then 
	move zeroes			to	ws-doc-totals-mtd-ytd (ss-mtd). 
 
ua1-99-exit. 
    exit. 
ua2-remaining-misc. 
 
    if chq-reg-mth-misc-amt (ss-mth-nbr, ss-misc) not = zeroes 
    then 
	add chq-reg-mth-misc-amt (ss-mth-nbr, ss-misc) 
					to	ws-misc-gross (ss-mtd,ss-misc) 
	subtract 1			from	ss-misc 
					giving	ss-perc 
	multiply chq-reg-mth-misc-amt (ss-mth-nbr, ss-misc) 
					by	const-misc-curr (ss-perc) 
					giving	ws-misc-net (ss-mtd, ss-misc) rounded    
	add ws-misc-net (ss-mtd, ss-misc)	to	ws-inc (ss-mtd). 
*   (else) 
*   endif 
 
ua2-99-exit. 
    exit. 
 
 
 
 
ua3-add-misc-to-ytd. 
 
    add ws-misc-net (ss-mtd, ss-misc)	to	ws-misc-net (ss-ytd, ss-misc). 
    add ws-misc-gross (ss-mtd, ss-misc)	to	ws-misc-gross (ss-ytd, ss-misc). 
 
ua3-99-exit. 
    exit. 
wa0-write-headings. 
    move spaces				to	ws-initials 
						ws-inits-name. 
 
    if doc-init1 not = spaces 
    then 
	move doc-init1			to	ws-init1 
	move "."			to	ws-dot1. 
*   (else) 
*   endif 
 
    if doc-init2 not = spaces  
    then 
	move doc-init2			to	ws-init2 
	move "."			to	ws-dot2. 
*   (else) 
*   endif 
 
    if doc-init3 not = spaces 
    then 
	move doc-init3			to	ws-init3 
	move "."			to	ws-dot3. 
*   (else) 
*   endif 
 
    string ws-1st-init delimited by spaces,  
	   ws-2nd-init delimited by spaces, 
	   ws-3rd-init delimited by spaces, 
*    sms 114 s.f.   string the doctor name with 2 spaces rather than 1. 
*          doc-name delimited by spaces, 
	   doc-name delimited by ws-xx, 
					into	ws-inits-name. 
 
    move ws-inits-name			to	r153a-h1-inits-name. 
    move doc-nbr			to	r153a-h1-doc-nbr. 
    move doc-dept			to	r153a-h1-dept. 
    move dept-name 			to	r153a-h1-1-dept-name. 
    write prt-line-a from r153a-head-first 	after page. 
*   write prt-line-a from r153a-head-1	after	page. 
    write prt-line-a from r153a-head-1	after	1 line. 
    write prt-line-a from r153a-head-1-1  after  1 line. 
    write prt-line-a from r153a-head-2	after	2 lines. 
    write prt-line-a from r153a-head-3	after	2 lines. 
    write prt-line-a from r153a-head-4	after	5 lines. 
    write prt-line-a from r153a-head-5	after	2 lines. 
    write prt-line-a from r153a-head-6	after	3 lines. 
    write prt-line-a from r153a-head-7	after	1 line.  
    write prt-line-a from blank-line	after	1 line. 
 
wa0-99-exit. 
    exit. 
wa1-write-report. 
 
    move zeroes				to	ctr-nbr-misc-lines  
						ws-print-gross-misc-total 
						ws-print-mtd-misc-total 
						ws-print-ytd-misc-total. 
    perform wa2-print-misc		thru	wa2-99-exit 
	varying ss-misc 
		from 1 by 1 
	until	ss-misc > 10. 
 
    if ctr-nbr-misc-lines > 1 
    then 
	write prt-line-a from underscore-detail after 1 line 
	move ws-print-gross-misc-total	to	r153a-p2-gross 
	move ws-print-mtd-misc-total	to	r153a-p2-mtd 
	move ws-print-ytd-misc-total	to	r153a-p2-ytd 
	write prt-line-a from r153a-prt-2	after	1 line. 
*   (else) 
*   endif 
 
    move spaces				to	r153a-p3-plus-lit. 
 
    if ctr-nbr-misc-lines = zero 
    then 
	move "$"			to	r153a-p3-lit-1 
						r153a-p3-lit-2 
						r153a-p3-lit-3 
    else 
	move "PLUS"			to	r153a-p3-plus-lit 
	move spaces			to	r153a-p3-lit-2 
						r153a-p3-lit-3. 
*   endif 
 
    move chq-reg-mth-bill-amt (ss-chq) 
					to	r153a-p3-gross. 
    multiply chq-reg-perc-bill (ss-chq) 
					by	100 
					giving	ws-print-percent. 
    move ws-print-percent		to	r153a-p3-percent. 
    move ws-bill-net (ss-mtd)			to	r153a-p3-mtd. 
    move ws-bill-net (ss-ytd)			to	r153a-p3-ytd. 
    write prt-line-a from r153a-prt-3	after	1 line. 
* 
* 'IF' stmt. added for faculty expense detail line 
* 
 
    if ctr-nbr-misc-lines > zero   or  ws-exp-amt (ss-ytd) > zero 
    then 
	write prt-line-a from underscore-total after 1 line 
	move ws-inc (ss-mtd)			to	r153a-p4-mtd 
	move ws-inc (ss-ytd)			to	r153a-p4-ytd 
	write prt-line-a from r153a-prt-4 after 1 line. 
*   (else) 
*   endif 

*mf brad - what happending to doc-pay-code ????? 
*mf  if  doc-pay-code    not = "4" 
     if  doc-ep-pay-code not = "4" 
     then 
          next sentence 
     else 
          move 	ws-exp-amt (ss-mtd) 		to  r153a-p3-a-mtd 
	  move  ws-exp-amt (ss-ytd) 		to  r153a-p3-a-ytd 
	  write prt-line-a from r153a-prt-3-a after 1 line. 
*    (endif) 
* 
    write prt-line-a from underscore-total after 1 line. 
 
    subtract ws-exp-amt (ss-mtd)             from     ws-inc (ss-mtd) 
                                        giving   ws-net-inc (ss-mtd). 
    subtract ws-exp-amt (ss-ytd)             from     ws-inc (ss-ytd) 
                                        giving   ws-net-inc (ss-ytd). 
 
    move ws-net-inc (ss-mtd)            to r153a-p4-a-mtd. 
    move ws-net-inc (ss-ytd)            to r153a-p4-a-ytd. 
    write prt-line-a from r153a-prt-4-a after 1 line. 
 
 
    move ws-ceil-amt (ss-mtd)		to	r153a-p5-mtd. 
    move ws-ceil-amt (ss-ytd)		to	r153a-p5-ytd. 
    write prt-line-a from r153a-prt-5	after	2 lines. 
 
    move ws-pay-due (ss-mtd)			to	r153a-p6-mtd. 
    move ws-pay-due (ss-ytd)			to	r153a-p6-ytd. 
    write prt-line-a from r153a-prt-6	after	5 lines. 
 
    move ws-tax (ss-mtd)			to	r153a-p7-mtd. 
    move ws-tax (ss-ytd)			to	r153a-p7-ytd. 
    write prt-line-a from r153a-prt-7	after	1 line. 
 
    write prt-line-a from underscore-total after	1 line. 
 
*   (print deposit only if non-zer0 m.t.d. or y.t.d. amounts) 
    if   ws-bank-deposit (ss-mtd) = zero 
     and ws-bank-deposit (ss-ytd) = zero 
    then 
	next sentence 
    else 
	move ws-bank-deposit (ss-mtd)		to	r153a-p8-mtd 
	move ws-bank-deposit (ss-ytd)		to	r153a-p8-ytd 
	write prt-line-a from r153a-prt-8	after	1 line. 
*   endif 
 
*   (print manual payments only if non-zero m.t.d. or y.t.d. amounts) 
    if    ws-manual-chqs (ss-mtd) = zero 
      and ws-manual-chqs (ss-ytd) = zero 
    then 
	next sentence 
    else 
	move ws-manual-chqs (ss-mtd)		to	r153a-p9-mtd 
	move ws-manual-chqs (ss-ytd)		to	r153a-p9-ytd 
	write prt-line-a from r153a-prt-9	after	1 line. 
*   endif 
 
    write prt-line-a from underscore-total after	1 line. 
    write prt-line-a from underscore-total after	1 line. 
 
    move zero                              to total-earnings. 
    add ws-tax (ss-ytd)                    to total-earnings. 
    add ws-bank-deposit (ss-ytd)           to total-earnings. 
    add ws-manual-chqs (ss-ytd)            to total-earnings. 
    subtract ws-inc (ss-ytd)             from total-earnings 
                               giving ws-difference. 
    if ws-difference > 0 
    then 
        move ws-difference                 to r153a-p9-a-ytd 
        write prt-line-a      from r153a-prt-9-a  after 2 lines. 
* endif. 
 
    write prt-line-a from r153a-prt-10	after 	2 lines. 
    write prt-line-a from r153a-prt-11	after 	1 line.  
    write prt-line-a from r153a-prt-12	after 	1 line.  
    if doc-full-part-ind = "P" 
    then 
        write prt-line-a from r153a-prt-14   after    2 lines 
    else 
        next sentence. 
*   endif 
* (y2k)
    if yearend-option = "Y" 
    then 
        write prt-line-a from r153a-prt-13   after    2 lines 
    else 
        next sentence. 
*   endif 
 
                     
    add 1				to	ctr-rpt-writes. 
 
*	update final statement totals 
 
    perform wa1a-add-misc		thru	wa1a-99-exit 
	varying	ss-misc 
		from 1 by 1 
	until	ss-misc > 10. 
 
    add ws-bill-gross (ss-mtd)		to	ws-fin-bill-gross (ss-mtd). 
    add ws-bill-gross (ss-ytd)		to	ws-fin-bill-gross (ss-ytd). 
    add ws-bill-net (ss-mtd)		to	ws-fin-bill-net (ss-mtd). 
    add ws-bill-net (ss-ytd)		to	ws-fin-bill-net (ss-ytd). 
    add ws-inc (ss-mtd)			to	ws-fin-inc (ss-mtd). 
    add ws-inc (ss-ytd)			to	ws-fin-inc (ss-ytd). 
* 
* following two stmts. added. 		may/86	k.p. 
* 
    add ws-exp-amt (ss-mtd)		to	ws-fin-exp-amt (ss-mtd). 
    add ws-exp-amt (ss-ytd)		to	ws-fin-exp-amt (ss-ytd). 
    add ws-ceil-amt (ss-mtd)		to	ws-fin-ceil-amt (ss-mtd). 
    add ws-ceil-amt (ss-ytd)		to	ws-fin-ceil-amt (ss-ytd). 
    add ws-pay-due (ss-mtd)		to	ws-fin-pay-due (ss-mtd). 
    add ws-pay-due (ss-ytd)		to	ws-fin-pay-due (ss-ytd). 
    add ws-tax (ss-mtd)			to	ws-fin-tax (ss-mtd). 
    add ws-tax (ss-ytd)			to	ws-fin-tax (ss-ytd). 
    add ws-bank-deposit (ss-mtd)	to	ws-fin-deposit (ss-mtd). 
    add ws-bank-deposit (ss-ytd)	to	ws-fin-deposit (ss-ytd). 
    add ws-manual-chqs  (ss-mtd)	to	ws-fin-man-chqs (ss-mtd). 
    add ws-manual-chqs  (ss-ytd)	to	ws-fin-man-chqs (ss-ytd). 
 
*	verify that statement totals agree 
 
    add ws-print-mtd-misc-total		to	ws-bill-net (ss-mtd). 
    add ws-print-ytd-misc-total		to	ws-bill-net (ss-ytd). 
 
*   if   ws-bill-net (ss-mtd) not = ws-inc (ss-mtd) 
*     or ws-bill-net (ss-ytd) not = ws-inc (ss-ytd) 
*   then 
*	write prt-line-a from r153a-prt-err after 3 lines 
*	go to wa1-99-exit. 
*   (else) 
*   endif 
 
    subtract ws-tax (ss-mtd)			from	ws-pay-due (ss-mtd). 
    subtract ws-tax (ss-ytd)			from	ws-pay-due (ss-ytd). 
 
*   if   ws-pay-due(ss-mtd) not = (ws-bank-deposit(ss-mtd) + ws-manual-chqs(ss-mtd)) 
*     or ws-pay-due(ss-ytd) not = (ws-bank-deposit(ss-ytd) + ws-manual-chqs(ss-ytd)) 
*   then 
*	write prt-line-a from r153a-prt-err after 3 lines. 
*   (else) 
*   endif 
 
wa1-99-exit. 
    exit. 
 
 
 
 
wa1a-add-misc. 
 
    add ws-misc-gross (ss-mtd,ss-misc)	to	ws-fin-misc-gross (ss-mtd,ss-misc). 
    add ws-misc-gross (ss-ytd,ss-misc)	to	ws-fin-misc-gross (ss-ytd,ss-misc). 
    add ws-misc-net (ss-mtd,ss-misc)		to	ws-fin-misc-net (ss-mtd,ss-misc). 
    add ws-misc-net (ss-ytd,ss-misc)		to	ws-fin-misc-net (ss-ytd,ss-misc). 
 
wa1a-99-exit. 
    exit. 
wa2-print-misc. 
 
    if ws-misc-net (ss-ytd, ss-misc) = zeroes 
    then 
	go to wa2-99-exit. 
*   (else) 
*   endif 
 
    if ctr-nbr-misc-lines = zeroes 
    then 
	move "$"			to	r153a-p1-lit-1 
						r153a-p1-lit-2 
						r153a-p1-lit-3 
    else 
	move spaces			to	r153a-p1-lit-1 
						r153a-p1-lit-2 
						r153a-p1-lit-3. 
*   endif 
 
    move chq-reg-mth-misc-amt (ss-chq, ss-misc) 
					to	r153a-p1-gross. 
    add chq-reg-mth-misc-amt (ss-chq, ss-misc) 
					to	ws-print-gross-misc-total. 
 
    if ss-misc = 1 
    then 
	multiply chq-reg-perc-misc (ss-chq)	by 100 
					giving	ws-print-percent 
    else 
	subtract 1			from	ss-misc 
					giving	ss-perc  
	multiply const-misc-curr (ss-perc) by	100 
					giving	ws-print-percent. 
*   endif 
 
    move ws-print-percent		to	r153a-p1-percent. 
 
    move ws-misc-net (ss-mtd, ss-misc)		to	r153a-p1-mtd. 
    add  ws-misc-net (ss-mtd, ss-misc)		to	ws-print-mtd-misc-total. 
    move ws-misc-net (ss-ytd, ss-misc)		to	r153a-p1-ytd.  
    add  ws-misc-net (ss-ytd, ss-misc)		to	ws-print-ytd-misc-total. 
 
    write prt-line-a from r153a-prt-1	after	1 line. 
    add 1				to	ctr-nbr-misc-lines. 
    move spaces				to	r153a-p1-lit-1 
						r153a-p1-lit-2 
						r153a-p1-lit-3. 
 
wa2-99-exit. 
    exit. 
wa3-print-totals. 
 
*  print the pgm name at the upper left corner for the last page 
*  of the report r153a 
 
    write prt-line-a from r153a-head-first after page. 
 
*   write prt-line-a from r153a-head-3	 after	page. 
    write prt-line-a from r153a-head-3	 after	2 lines. 
    write prt-line-a from r153a-head-4   after	2 lines. 
    write prt-line-a from r153a-tot-head after	2 lines. 
    write prt-line-a from r153a-head-6   after	3 lines. 
    write prt-line-a from r153a-head-7   after	1 line. 
    write prt-line-a from blank-line     after	1 line. 
 
    move "$"				to	r153a-p1-lit-1 
						r153a-p1-lit-2 
						r153a-p1-lit-3. 
 
    move 0				to	ws-print-gross-misc-total 
						ws-print-mtd-misc-total 
						ws-print-ytd-misc-total. 
 
    perform wa3a-print-misc		thru	wa3a-99-exit 
	varying	ss-misc 
		from 1 by 1 
	until	ss-misc > 10. 
 
    write prt-line-a from underscore-detail after 1 line. 
    move ws-print-gross-misc-total	to	r153a-p2-gross. 
    move ws-print-mtd-misc-total	to	r153a-p2-mtd. 
    move ws-print-ytd-misc-total	to	r153a-p2-ytd. 
    write prt-line-a from r153a-prt-2	after	1 line. 
     
    move "PLUS"				to	r153a-p3-plus-lit. 
    move spaces				to	r153a-p3-lit-2 
						r153a-p3-lit-3. 
    move ws-fin-bill-gross (ss-mtd)		to	r153a-p3-gross. 
    move spaces				to	r153a-p3-percent-r. 
    move ws-fin-bill-net (ss-mtd)		to	r153a-p3-mtd. 
    move ws-fin-bill-net (ss-ytd)		to	r153a-p3-ytd. 
    write prt-line-a from r153a-prt-3	after	1 line. 
* 
*  following two stmts. added 		may/85  k.p. 
* 
    move ws-fin-exp-amt (ss-mtd)	to 	r153a-p3-a-mtd. 
    move ws-fin-exp-amt (ss-ytd) 	to 	r153a-p3-a-ytd. 
    write prt-line-a from r153a-prt-3-a after 	1 line. 
 
    write prt-line-a from underscore-total  
					after	1 line. 
    move ws-fin-inc (ss-mtd)		to	r153a-p4-mtd. 
    move ws-fin-inc (ss-ytd)		to	r153a-p4-ytd. 
    write prt-line-a from r153a-prt-4	after	1 line. 
 
    move ws-fin-ceil-amt (ss-mtd)	to	r153a-p5-mtd. 
    move ws-fin-ceil-amt (ss-ytd)	to	r153a-p5-ytd. 
    write prt-line-a from r153a-prt-5	after	2 lines. 
 
    move ws-fin-pay-due (ss-mtd)	to	r153a-p6-mtd. 
    move ws-fin-pay-due (ss-ytd)	to	r153a-p6-ytd. 
    write prt-line-a from r153a-prt-6	after	5 lines. 
 
    move ws-fin-tax (ss-mtd)		to	r153a-p7-mtd. 
    move ws-fin-tax (ss-ytd)		to	r153a-p7-ytd. 
    write prt-line-a from r153a-prt-7   after	1 line. 
 
    write prt-line-a from underscore-total 
					after	1 line. 
 
    move ws-fin-deposit (ss-mtd)	to	r153a-p8-mtd. 
    move ws-fin-deposit (ss-ytd)	to	r153a-p8-ytd. 
    write prt-line-a from r153a-prt-8	after	1 line. 
 
    move ws-fin-man-chqs(ss-mtd)	to	r153a-p9-mtd. 
    move ws-fin-man-chqs(ss-ytd)	to	r153a-p9-ytd. 
    write prt-line-a from r153a-prt-9	after	1 line. 
    write prt-line-a from underscore-total 
					after	1 line. 
 
    add ws-print-mtd-misc-total		to	ws-fin-bill-net (ss-mtd). 
    add ws-print-ytd-misc-total		to	ws-fin-bill-net (ss-ytd). 
 
*   if   ws-fin-bill-net (ss-mtd) not = ws-fin-inc (ss-mtd) 
*     or ws-fin-bill-net (ss-ytd) not = ws-fin-inc (ss-ytd) 
*   then 
*	write prt-line-a from r153a-prt-err after 3 lines 
*	go to wa3-99-exit. 
*   (else) 
*   endif 
    subtract ws-fin-tax (ss-mtd)	from	ws-fin-pay-due (ss-mtd). 
    subtract ws-fin-tax (ss-ytd)	from	ws-fin-pay-due (ss-ytd). 
 
* modified if statement to make wa3 section compatible to wa1. s.f. june/89 
*   if   ws-fin-pay-due (ss-mtd) not = ws-fin-deposit (ss-mtd) 
*     or ws-fin-pay-due (ss-ytd) not = ws-fin-deposit (ss-ytd) 
*   if   ws-fin-pay-due (ss-mtd) not = (ws-fin-deposit (ss-mtd) + ws-fin-man-chqs(ss-mtd)) 
*     or ws-fin-pay-due (ss-ytd) not = (ws-fin-deposit (ss-ytd) + ws-fin-man-chqs(ss-ytd)) 
*   then 
*	write prt-line-a from r153a-prt-err after 3 lines. 
*   (else) 
*   endif 
 
wa3-99-exit. 
    exit. 
wa3a-print-misc. 
 
    move ws-fin-misc-gross (ss-mtd,ss-misc)	to	r153a-p1-gross. 
    if ss-misc = 1 
    then 
	move spaces			to	r153a-p1-percent-r 
    else 
	subtract 1 			from	ss-misc 
					giving	ss-perc 
	multiply const-misc-curr (ss-perc) by	100 
					giving	ws-print-percent 
	move ws-print-percent          to	r153a-p1-percent. 
*   endif 
 
    move ws-fin-misc-net (ss-mtd, ss-misc)	to	r153a-p1-mtd. 
    move ws-fin-misc-net (ss-ytd, ss-misc)	to	r153a-p1-ytd. 
    write prt-line-a from r153a-prt-1	after	1 line. 
    move spaces				to	r153a-p1-lit-1 
						r153a-p1-lit-2 
						r153a-p1-lit-3. 
    add ws-fin-misc-gross (ss-mtd, ss-misc)	to	ws-print-gross-misc-total. 
    add ws-fin-misc-net (ss-mtd, ss-misc)	to	ws-print-mtd-misc-total. 
    add ws-fin-misc-net (ss-ytd, ss-misc)	to	ws-print-ytd-misc-total. 
 
wa3a-99-exit. 
    exit. 
xa0-read-u119-build-f060. 
 
*   (zero f060 cheque reg before moving in u119 values) 
    move zeros				to	cheque-reg-rec. 
    perform xb1-zero-chq		thru	xb1-99-exit.
 
    read u119-chgeft-file 
	at end 
	   move "Y"			to	eof-u119-chgeft-file 
	   move "Y"			to	eof-chq-reg-mstr 
	   go to xa0-99-exit. 
 
    move 0				to	n-doc-dept.
    move w-doc-dept			to	n-doc-dept. 
* 2003/11/18 - MC
*!  move 0				to	n-doc-nbr.
    move spaces				to	n-doc-nbr.
* 2003/11/18 - end

    move w-doc-nbr 			to	n-doc-nbr. 
    move 0					to	n-chgeft-amt-n. 
    move w-chgeft-amt-n			to	n-chgeft-amt-n. 

*   (don't hard code payroll clinic)
*   move 22				to	chq-reg-clinic-nbr-1-2. 
    move sel-clinic			to      chq-reg-clinic-nbr-1-2.

    move n-doc-dept                     to	chq-reg-dept. 
    move n-doc-nbr                     	to	chq-reg-doc-nbr. 
    move n-chgeft-amt-n 
					to	chq-reg-regular-pay-this-mth(ss-chq). 
 
    add 1				to	ctr-u119-chgeft-reads. 
 
xa0-99-exit. 
    exit. 
 
 
xb1-zero-chq. 
 
	move 0  to  chq-reg-perc-bill              (ss-chq). 
	move 0  to  chq-reg-perc-misc              (ss-chq). 
	move 0  to  chq-reg-pay-code               (ss-chq). 
	move 0  to  chq-reg-perc-tax               (ss-chq). 
	move 0  to  chq-reg-mth-bill-amt           (ss-chq). 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,1) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,2) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,3) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,4) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,5) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,6) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,7) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,8) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,9) 
	move 0  to  chq-reg-mth-misc-amt (ss-chq,10) 
        move 0  to  chq-reg-mth-exp-amt	          (ss-chq). 
	move 0  to  chq-reg-comp-ann-exp-this-pay  (ss-chq). 
	move 0  to  chq-reg-mth-ceil-amt           (ss-chq). 
	move 0  to  chq-reg-comp-ann-ceil-this-pay (ss-chq). 
	move 0  to  chq-reg-earnings-this-mth      (ss-chq). 
	move 0  to  chq-reg-regular-pay-this-mth   (ss-chq). 
	move 0  to  chq-reg-regular-tax-this-mth   (ss-chq). 
	move 0  to  chq-reg-man-pay-this-mth       (ss-chq). 
	move 0  to  chq-reg-man-tax-this-mth       (ss-chq). 
* (y2k)
	move 0  to  chq-reg-pay-date		  (ss-chq). 
 
xb1-99-exit. 
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