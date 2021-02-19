identification division. 
program-id.  r123a. 
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
*		: "R123A" - doctor statement of earnings 
*		: "R123B" - bank deposit list report 
*		: "R123C" - bank cheques 
* 
*    additional  files for eft development 
*               : "R123EF"  -  eft summary report 
*               : "EFT_TAPE"  -  eft file   for tape generation 
* 
*    program purpose : to print the doctor statement of earnings, 
* 		       bank deposit list and bank cheques  & 
*                      to print eft summary  report  and 
*                      create eft disk file for eft tape generation. 
*	r123a - does the sort phase
*	r123b - creates EFT file/reports
* 
*   revision history: 
*     date       programmer      reason 
*   82/05/        d. miller      - changed to access new cheque, constants & 
*			  	   doctor masters 
*   82/09/        d. miller      - programs r123 (dr.statements) & r140 
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
*    87/04/06	  j. lam	- change r123eft to r123ef (pdr 329) 
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
*			   corner of the last page of r123a report 
 
*   93/jun/15   b.e.	- added access to u119_payeft file.  values 
*			  from this file are then preset into f060 
*			  and programs works from the values in f060 
*			  as it originally did.  the statement generated 
*			  by this program are no longer valid - see 
*			  output of r124x.qzs programs.  bank statements 
*			  are valid. 
*   98/jun/15   B.E.    - unix conversion - sort had to be split from other
*                         processes so r123 split into r123a/b with
*                         r123a performing only the sort
*			  and updating eft-constants file  while
*			  r123b now creates the EFT file and reports.  
*
*   99/aug/19   B.E.	- added multi-payroll option for clinic 22 and 81
*   99/nov/15   B.E.    - added copybook so that all unique data for RMA
*			  clinic 22/80 is not hard coded in pgm 
*   00/nov/10   B.E.	- added 'mp' payroll processing - NOTE that clinic 99
*			  is used to run the 'mp' clinic payroll
*   01/oct/21   B.E.	- added clinic 85 for 2nd 'new' ICU payroll
*   03/jan/22   M.C.    - open f123-company-mstr to get the bank account info
*			- use the correct account based on company nbr when
*			  withdrawing the fund
*   03/nov/18  M.C.     - alpha doc nbr

* 2007/nov/14 b.e.      - added additional settlement account/institution
*                         for shelter health network
*
* 2009/jan/19 M.C.      - added additional settlement account/institution
*                         for Palliative Care
*                       - also modify $use/r123_bank_info.ws for the new company
* 2014/may/13 MC1	- change the field size in u119_payeft.ps as it was changed from integer*8 to integer*10
* 2016/Aug/29 MC2       - Yasemin requests to show run date in r123ef report

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
* 2003/01/22 - MC
    copy "f123_company_mstr.slr".
* 2003/01/22 - end 
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
 
    select r123-work-file 
	assign to "r123_work_file" 
	organization is sequential. 
 
    select sorted-file 
        assign to ws-sorted-file 
        organization is  sequential. 
  
    select output-file 
        assign to ws-output-file 
        organization is  sequential. 
 
    select eft-constant-file 
        assign to "$pb_data/eft_constant" 
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
    select u119-payeft-file 
	assign to "u119_payeft.ps" 
	organization is sequential. 
 
data division. 
file section. 
* 
* 2003/01/22 - MC
    copy "f123_company_mstr.fd".
* 2003/01/22 - end 

*   (2007/nov/15 b.e. unique MP definition)
*    copy "f020_doctor_mstr.fd".      
    copy "f020_doctor_mstr_mp.fd".
 
 
    copy "f060_cheque_reg_mstr.fd". 
 
 
    copy "f070_dept_mstr.fd". 
 
 
    copy "f080_bank_mstr.fd".       
 
 
    copy "f090_constants_mstr.fd". 
 

 
    copy "f090_const_mstr_rec_3.ws". 
 
    copy "eft_logical_rec_file.fd". 
 
 
fd    u119-payeft-file 
* 2003/11/25 - MC
*                record   contains  18  characters. 
* MC1  
*                record   contains  17  characters. 
                record   contains  22  characters. 
* 2003/11/25 - end

01    u119-payeft-rec. 
*mf     (MF cobol wouldn't accept the sign in the front of the number
*mf      which PH placed there even though PH had 'unsigned' definition.
*mf      These numbers are always positive so "+" signed ignored.)
*mf          05   w-doc-nbr                        pic s9(4). 
* 2003/11/18 - MC 
*!	     05   filler-sign1			   pic x(1).
*!           05   w-doc-nbr                        pic 9(3). 
             05   w-doc-nbr                        pic x(3). 
* 2003/11/18 - end
*mf          05   w-doc-dept                       pic s9(3). 
	     05   filler-sign2			   pic x(1).
             05   w-doc-dept                       pic 9(2). 
	     05   filler-sign			   pic x(01). 
*            05   w-payeft-amt-n                   pic 9(8)v99. 
	     05   w-payeft-amt-n                   pic 9(13)v99. 
* MC1 - end

sd  r123-work-file 
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
             05   s-originator-nbr                pic x(10).
             05   s-file-creation-nbr             pic x(4).

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

copy "r123_bank_info.ws".
 
*77  sel-clinic				pic 99		value zeroes. 
77  sel-clinic				pic xx		value zeroes. 
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
		"Doctor Statements are in file: r123a". 
77  ws-closing-msg-b			pic x(50)	value 
		"Bank Deposit list is in file:  r123b". 
77  ws-closing-msg-c			pic x(50)	value 
		"Bank Cheques are in file:      r123c". 
* 
* 
* 2003/11/18 - MC
*!77   n-doc-nbr                        pic s9(3)         value zero. 
77   n-doc-nbr                        pic x(3)          value spaces.  
* 2003/11/18 - end
77   n-doc-dept                       pic s9(2)         value zero. 
77   n-payeft-amt-n                   pic s9(7)v99      value zero. 
 
77  print-file-a-name			pic x(5)	value "r123a". 
77  print-file-b-name			pic x(5)        value "r123b". 
77  print-file-c-name			pic x(5)        value "r123c". 
* 
*77  print-summary-eft                   pic x(8)     value "r123eft". 
77  print-summary-eft                   pic x(8)     value "r123ef". 
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
77  eof-u119-payeft-file		pic x		value "N". 
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
77  status-cobol-dept-mstr		pic x(2)        value zero. 
77  status-sort-file			pic x(11)       value zeroes. 
77  status-u119-payeft-file		pic x(11)       value zeroes. 
* 2003/01/22 - MC
77  status-cobol-company-mstr   	pic x(2)        value zero. 
* 2003/01/22 - end
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

 01 ws-file-status.
     05 status-key-1        pic x.
     05 status-key-2        pic x.
     05 binary-status redefines status-key-2
                        pic 99 comp-x.

 01 display-ext-status.
     05 filler                pic xx value "9/".
     05 display-key-2         pic 999.
 
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
    05  ctr-u119-payeft-reads         	pic 9(7)    value zero. 
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
    05  ws-pc-123			pic xxx. 
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
                "EFT Disk File is in file: eft_tape". 
77  ws-closing-msg-e 			pic x(50)       value 
                "EFT Report Summary is in: r123eft". 
* 
77  status-prt-summary-eft              pic xx          value zeros. 
* 
77   datecheck-option                   pic x           value "N". 
* 
77   ws-version-nbr             pic 9(4)	value zeroes. 
77   ws-record-count  		pic 999         value 1. 
* 
* 
77   ws-transaction-type        pic 999         value 200. 
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
77   ws-total-credit-value-1    pic 9(12)v99    value zeroes. 
77   ws-total-credit-nbr-1      pic 9(8)        value zeroes. 
77   ws-total-credit-value-2    pic 9(12)v99    value zeroes. 
77   ws-total-credit-nbr-2      pic 9(8)        value zeroes. 
* 2007/11/14 be. shelter health network
77   ws-total-credit-value-3    pic 9(12)v99    value zeroes.
77   ws-total-credit-nbr-3      pic 9(8)        value zeroes.
* 2009/01/19 MC  Palliative Care
77   ws-total-credit-value-4    pic 9(12)v99    value zeroes.
77   ws-total-credit-nbr-4      pic 9(8)        value zeroes.
* 2009/01/19 - end
*
* 
* 
 
 
77   ws-work-file-a             pic x(11)       value "work_file_a". 
77   ws-sorted-file             pic x(11)       value "sorted_file". 
77   ws-output-file             pic x(8)        value "eft_tape". 
 
01   ws-payee-name. 
     05  ws-payee-last-name	pic x(24)	value spaces. 
     05  ws-payee-initial	pic x(6)	value spaces. 
 
01  ws-fund-avail-date.
* (y2k - no change - the CIBC format is '0yy'  for year + julian date 'jjj' )
    05  ws-fund-yr 		pic 999 	value zeroes. 
    05  ws-fund-day 		pic 999 	value zeroes. 
 
 
01   ws-tape-creation-date. 
* (y2k - no change - the CIBC format is '0yy' for year + julian day 'jjj' )
     05  ws-tape-yr		pic 999		value zeroes. 
     05  ws-tape-day		pic 999		value zeroes. 
 
 
01   ws-rec-type. 
     05  ws-rec-a		pic x 		value 'A'. 
     05  ws-rec-c		pic x		value 'C'. 
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
		"Invalid REPLY". 
	10  filler				pic x(60)   value 
		"Invalid YEAR". 
	10  filler				pic x(60)   value 
		"Invalid MONTH". 
	10  filler				pic x(60)   value 
		"Invalid DAY". 
	10  filler				pic x(60)   value 
		"Invalid CLINIC Number". 
	10  filler				pic x(60)   value 
		"No CHEQUE Records for this Clinic". 
	10  filler				pic x(60)   value 
		"CANNOT access conmstr Rec 3". 
	10  filler				pic x(60)   value 
		"CHEQUE DATE less than PERIOD END DATE". 
	10  filler				pic x(60)   value 
		"Invalid PAYROLL Clinic entered".
* 2003/01/22 - MC
	10  filler				pic x(60)   value 
		"Invalid COMPANY NBR ".
* 2003/01/22 - end
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(60) 
* 2003/01/22 - MC
*			occurs 9 times. 
			occurs 10 times. 
* 2003/01/22 - end
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  ERROR - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  r123a-head-first. 
    05  filler					pic x(5)	value 
		"R123A". 
    05  filler					pic x(127)      value spaces. 
		 
 
01  r123a-head-1. 
    05  filler					pic x(7)	value 
		"TO:". 
    05  filler					pic xxxx	value 
		"DR.". 
    05  r123a-h1-inits-name			pic x(30)	value spaces. 
    05  filler					pic xxx	value spaces. 
    05  filler					pic x(6)	value 
		"NBR:". 
* 2003/11/18 - MC
*!    05  r123a-h1-doc-nbr			pic 999		value zeroes. 
    05  r123a-h1-doc-nbr			pic xxx		value spaces. 
* 2003/11/18 - end
 
 
01  r123a-head-1-1. 
    05 filler                                   pic x(7)        value spaces. 
    05 r123a-h1-1-dept-name                     pic x(30). 
    05 filler                                	pic x(7)  	value spaces. 
    05  filler					pic x(6)	value  
		"DEPT:". 
    05  r123a-h1-dept				pic 99		value zeroes. 
 
01  r123a-head-2. 
    05  filler					pic x(7)	value 
		"FROM:". 
    05  filler					pic x(60)	value 
* 2003/01/22 - MC
*	"MR. JOHN E. MCCUTCHEON, FACMGA, EXECUTIVE DIRECTOR". 
	"MS LEENA JAANIMAGI, CA, MBA,  EXECUTIVE DIRECTOR". 
* 2003/01/22 - end
 
01  r123a-head-3. 
    05  filler					pic x(7)	value 
		"DATE:". 
* (y2k - auto fix)
*   05  r123a-h3-yr					pic 99		value zeroes. 
    05  r123a-h3-yr					pic 9(4)		value zeroes. 
    05  filler					pic x		value "/". 
    05  r123a-h3-mth					pic 99		value zeroes. 
    05  filler					pic x		value "/". 
    05  r123a-h3-day					pic 99		value zeroes. 
 
01  r123a-head-4. 
    05  filler					pic x(29)	value spaces. 
    05  filler					pic x(40)	value 
		"REGIONAL MEDICAL ASSOCIATES". 
 
01  r123a-head-5. 
    05  filler					pic x(14)	value spaces. 
    05  filler					pic x(44)	value 
		"STATEMENT OF EARNINGS FOR THE PERIOD ENDING". 
* (y2k - auto fix)
*   05  r123a-h5-yr					pic 99		value zeroes. 
    05  r123a-h5-yr					pic 9(4)		value zeroes. 
    05  filler					pic x		value "/". 
    05  r123a-h5-mth					pic 99		value zeroes. 
    05  filler					pic x		value "/". 
    05  r123a-h5-day					pic 99		value zeroes. 
 
01  r123a-head-6. 
    05  filler					pic x(67)	value spaces. 
    05  filler					pic x(5)	value 
		"SINCE". 
 
01  r123a-head-7. 
    05  filler					pic x(45)	value spaces. 
    05  filler					pic x(10)	value 
		"THIS MONTH". 
    05  filler					pic x(8)	value spaces. 
* 2003/11/25 - MC
*   05  filler					pic x(10)	value 
*		"JULY 1, 19". 
    05  filler					pic x(8)	value 
		"JULY 1, ". 
* (y2k)
*    05  r123a-h7-yr					pic 99. 
    05  r123a-h7-yr					pic 9(4). 
 
01  r123a-tot-head. 
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
01  r123a-prt-1. 
    05  filler					pic x(6)	value spaces. 
    05  r123a-p1-lit-1				pic x		value "$". 
    05  r123a-p1-gross				pic zzz,zz9.99-	value zeroes. 
*   05  filler					pic xx		value spaces. 
    05  filler					pic x 		value spaces. 
    05  filler					pic x(14)	value 
		"MISC.INCOME @". 
*   05  r123a-p1-percent			pic zz9. 
    05  r123a-p1-percent			pic zz9.99. 
*   05  r123a-p1-percent-r redefines r123a-p1-percent pic xxx. 
    05  r123a-p1-percent-r redefines r123a-p1-percent pic xxxxxx. 
    05  filler					pic x		value "%". 
*   05  filler					pic x(5)	value spaces. 
    05  filler					pic x(3)	value spaces. 
    05  r123a-p1-lit-2				pic x		value "$". 
    05  r123a-p1-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  r123a-p1-lit-3				pic x		value "$".                   
    05  r123a-p1-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-2. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p2-gross				pic zzz,zz9.99-	value zeroes. 
    05  filler					pic xx		value spaces. 
    05  filler					pic x(23)	value 
		"TOTAL MISC. INCOME". 
    05  filler					pic x		value "$". 
    05  r123a-p2-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p2-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-3. 
    05  filler					pic xx 		value spaces. 
    05  r123a-p3-plus-lit					pic x(6).              
    05  r123a-p3-plus-lit-r redefines r123a-p3-plus-lit. 
	10  filler				pic x(5). 
	10  r123a-p3-lit-1			pic x. 
    05  r123a-p3-gross				pic zz,zz9.99-	value zeroes. 
*   05  filler					pic xx		value spaces. 
    05  filler					pic x		value spaces. 
    05  filler					pic x(14)	value 
		"BILLINGS    @ ". 
*   05  r123a-p3-percent			pic zz9. 
*   05  r123a-p3-percent-r redefines r123a-p3-percent pic xxx. 
    05  r123a-p3-percent			pic zz9.99. 
    05  r123a-p3-percent-r redefines r123a-p3-percent pic xxxxxx. 
    05  filler					pic x		value "%". 
*   05  filler					pic x(5)	value spaces. 
    05  filler					pic x(3)	value spaces. 
    05  r123a-p3-lit-2				pic x		value spaces. 
    05  r123a-p3-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  r123a-p3-lit-3				pic x		value spaces. 
    05  r123a-p3-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
* 
* r123a expense detail line added.	may/86	k.p. 
* 
 
01  r123a-prt-3-a. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"LESS FACULTY EXPENSE". 
    05  filler					pic x		value "$". 
    05  r123a-p3-a-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p3-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-4. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"TOTAL INCOME". 
    05  filler					pic x		value "$". 
    05  r123a-p4-mtd				pic zzzz,zz9.99-	value zeros. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p4-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-4-a. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"NET INCOME". 
    05  filler					pic x		value "$". 
    05  r123a-p4-a-mtd				pic zzzz,zz9.99-	value zeros. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p4-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-5. 
    05  filler					pic x(20)	value spaces. 
    05  filler					pic x(23)	value 
		"CEILING IS". 
    05  filler					pic x		value "$". 
    05  r123a-p5-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p5-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-6. 
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(35)	value 
		"PAYMENT DUE". 
    05  filler					pic x		value "$". 
    05  r123a-p6-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(6)	value spaces. 
    05  filler					pic x		value "$". 
    05  r123a-p6-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-7. 
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(34)	value 
		"LESS INCOME TAX". 
    05  filler					pic xx		value "(". 
    05  r123a-p7-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(05)	value ")". 
    05  filler					pic x(02)	value "(". 
    05  r123a-p7-ytd				pic zzzzz,zz9.99-	value zeroes.      
    05  filler					pic x		value ")". 
 
01  r123a-prt-8. 
    05  filler					pic x(08)	  value spaces. 
    05  filler					pic x(26)	  value     
		"AUTOMATIC BANK DEPOSIT ON ".  
* (y2k)
*   05  r123a-p8-yr				pic 9(02).      
    05  r123a-p8-yr				pic 9(04).      
    05  filler					pic x(01)	  value "/". 
    05  r123a-p8-mth				pic 9(02). 
    05  filler					pic x(01)	  value "/". 
    05  r123a-p8-day				pic 9(02). 
    05  filler                                  pic x(02)	  value " $". 
    05  r123a-p8-mtd				pic zzzz,zz9.99-  value zero. 
    05  filler					pic x(06)	  value spaces. 
    05  filler					pic x(01)	  value "$". 
    05  r123a-p8-ytd				pic zzzzz,zz9.99- value zero. 
 
01  r123a-prt-9.       
    05  filler					pic x(08)	value spaces. 
*    05  filler					pic x(35)	value 
*		"PAID BY CHEQUE". 
*( pdr 377 allow operator to put comments or date on the yearend label) 
    05  yearend-label				pic x(35)	value 
		spaces. 
    05  filler					pic x(01)	value "$". 
    05  r123a-p9-mtd				pic zzzz,zz9.99-	value zeroes. 
    05  filler					pic x(06)	value spaces. 
    05  filler					pic x(01)	value "$". 
    05  r123a-p9-ytd				pic zzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-9-a. 
    05  filler					pic x(08)	value spaces. 
    05  filler        				pic x(35)	value                     "DEFICIT  ". 
    05  filler					pic x(20)	value spaces. 
    05  r123a-p9-a-ytd				pic zzzzz,zz9.99-	value zeroes. 
 
01  r123a-prt-10.    
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(68)	value 
		"A DETAILED LIST SHOWING EACH SERVICE FOR THE CURRENT MONTH IS MAILED". 
 
01  r123a-prt-11.     
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(78)	value 
	"TO YOUR OFFICE AT THE END OF EACH MONTH.  IF I CAN BE OF ANY ASSISTANCE,". 
 
01  r123a-prt-12.     
    05  filler					pic x(8)	value spaces. 
    05  filler					pic x(68)	value 
		"PLEASE CALL ME AT EXTENSION 2170 OR 525-9766.". 
 
**************************************************************** 
* for yearend only.	 
************************************************************ 
 
01  r123a-prt-13. 
    05  filler					pic x(20) 	value spaces. 
    05  filler 					pic x(112)      value   "FINAL YEAREND STATEMENT". 
 
01  r123a-prt-14. 
    05  filler					pic x(20) 	value spaces. 
    05  filler 					pic x(112)      value              "G.S.T. INCLUDED, G.S.T. REGISTRATION NUMBER R104453774". 
 
01  r123a-prt-err. 
    05  filler					pic x(20)	value 
		"********************". 
    05  filler					pic x(30)	value 
		"ERROR - COLUMNS DO NOT BALANCE". 
    05  filler					pic x(20)	value 
		"********************". 
01  r123b-head-first. 
    05  filler				pic x(5)	value "R123B". 
    05  filler       			pic x(72)	value spaces. 
 
 
01  r123b-head-1. 
    05  filler				pic x		value spaces. 
    05  r123b-h1-page			pic zzz9	value zeroes. 
    05  filler				pic x(12)	value spaces. 
    05  r123b-h1-bank-name		pic x(30)	value spaces. 
    05  filler				pic x(21)  	value spaces. 
 
01  r123b-head-2. 
    05  filler				pic x(17)  	value spaces. 
    05  r123b-h2-bank-addr 		pic x(43)	value spaces. 
    05  r123b-h2-mth			pic 99		value zeroes. 
    05  filler  			pic x 		value spaces. 
    05  r123b-h2-day			pic 99		value zeroes. 
    05  filler   			pic x   	value spaces. 
* (y2k - auto fix)
*   05  r123b-h2-yr			pic 99		value zeroes. 
    05  r123b-h2-yr			pic 9(4)		value zeroes. 
    05  filler 				pic x(9)	value spaces. 
 
01  r123b-head-2a. 
    05  filler				pic x(17)  	value spaces. 
    05  r123b-h2a-bank-addr 		pic x(60)	value spaces. 
 
01  r123b-head-3. 
    05  filler				pic x(17) 	value spaces. 
    05  r123b-h3-pc-123			pic xxx. 
    05  filler				pic x	  	value spaces. 
    05  r123b-h3-pc-456			pic xxx. 
    05  filler				pic x(61) 	value spaces. 
 
01  r123b-prt-1.    
    05  filler         			pic x(9). 
    05  r123b-p1-acct			pic x(12). 
    05  filler				pic x(2). 
    05  r123b-p1-dr-lit			pic x(4). 
    05  r123b-p1-inits      		pic x(6). 
    05  r123b-p1-name			pic x(24). 
    05  filler				pic x.     
    05  r123b-p1-pay			pic $zzzz,zz9vb99. 
01  r123c-head-first. 
    05  filler				pic x(5)  value "R123C". 
    05  filler          		pic x(80) value spaces. 
 
 
01 r123c-head-1. 
    05  filler				pic x(85) value 
		"  RMA MONTH'S EARNINGS". 
 
01  r123c-prt-1. 
    05  filler				pic x(27). 
    05  r123c-p1-chq-amt		pic $$$$,$$9vb99. 
    05  filler				pic x(12). 
    05  r123c-p1-mth			pic x(10). 
    05  r123c-p1-day			pic z9. 
    05  r123c-p1-comma			pic x(2). 
* (y2k)
*   05  r123c-p1-nineteen		pic 99. 
*   05  r123c-p1-yr			pic 99. 
    05  r123c-p1-yr			pic 9(4). 
 
01  r123c-prt-2. 
    05  filler				pic x(8). 
    05  r123c-p2-lit1			pic x(16). 
    05  r123c-p2-hundreds		pic ***9. 
    05  r123c-p2-lit2			pic x(28).    
    05  r123c-p2-chq-amt		pic $$$$,$$9.99. 
 
01  r123c-prt-3. 
    05  filler				pic x(8). 
    05  r123c-p3-pc-123			pic xxx. 
    05  filler				pic x. 
    05  r123c-p3-pc-456			pic xxx. 
 
01  r123c-prt-4. 
    05  filler				pic x(8). 
    05  r123c-p4-bank-name		pic x(77). 
 
01  r123c-prt-5. 
    05  filler				pic x(8). 
    05  r123c-p5-bank-addr1		pic x(77). 
 
01  r123c-prt-5a. 
    05  filler				pic x(8). 
    05  r123c-p5-bank-addr2		pic x(77). 
 
01  r123c-prt-6. 
    05  filler				pic x(8). 
    05  r123c-p6-city-prov		pic x(77). 
 
01 r123c-prt-7.                           
    05  filler				pic x(9). 
    05  r123c-p7-tot-chq		pic x(14). 
    05  r123c-p7-nbr-chqs		pic zzz9. 
    05  r123c-p7-tot-amt		pic x(13). 
    05  r123c-p7-fin-total		pic zzzz,zz9.99. 
 
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
    05  filler		pic x(6)   value "R123EF". 
* MC2
*   05  filler          pic x(126) value spaces.
    05  filler          pic x(66)  value spaces.
    05  filler          pic x(10)  value "RUN DATE:".
    05  eft-run-yr      pic 9(4)   value zeroes.
    05  filler          pic x      value "/".
    05  eft-run-mth     pic 99     value zeroes.
    05  filler          pic x      value "/".
    05  eft-run-day     pic 99     value zeroes.
    05  filler          pic x(40)  value spaces.
* MC2 - end
 
 
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
* (y2k - no change -left as CIBC format '0yy' + julian date)
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
 
* 2003/01/22 - MC
01  eft-prt-6a. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL # of TRANS(R.M.A.)     : ". 
    05  eft-tran-1      pic zzzzzzzz9. 
 
01  eft-prt-7a. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL $ of TRANS(R.M.A.)     : ". 
    05  eft-value-1     pic $$$,$$$,$$$,$$9.99. 
 
01  eft-prt-6b. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL # of TRANS(RMA Inc.)   : ". 
    05  eft-tran-2      pic zzzzzzzz9. 
 
01  eft-prt-7b. 
    05  filler          pic x(20)  value spaces. 
    05  filler          pic x(34)  value "TOTAL $ of TRANS(RMA Inc.)   : ". 
    05  eft-value-2     pic $$$,$$$,$$$,$$9.99. 

01  eft-prt-6c.
    05  filler          pic x(20)  value spaces.
    05  filler          pic x(34)  value "TOTAL # of TRANS(Shelter Hth): ".
    05  eft-tran-3      pic zzzzzzzz9.

01  eft-prt-7c.
    05  filler          pic x(20)  value spaces.
    05  filler          pic x(34)  value "TOTAL $ of TRANS(Shelter Hth): ".
    05  eft-value-3     pic $$$,$$$,$$$,$$9.99.

* 2009/01/19 - MC - Palliative Care
01  eft-prt-6d.
    05  filler          pic x(20)  value spaces.
    05  filler          pic x(40)  value "TOTAL # of TRANS(Palliative Care): ".
    05  eft-tran-4      pic zzzzzzzz9.

01  eft-prt-7d.
    05  filler          pic x(20)  value spaces.
    05  filler          pic x(40)  value "TOTAL $ of TRANS(Palliative Care): ".
    05  eft-value-4     pic $$$,$$$,$$$,$$9.99.
* 2009/01/19 - end

 
01  eft-prt-8. 
    05  filler          pic x(20)  value  spaces. 
    05  filler          pic x(30)  value "TAPE CREATION DATE :". 
* (y2k - no change - left as CIBC format ' 0yy' + julian date)
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
 
*mf sort r123-work-file		"COBSORT" save 
    sort r123-work-file
      on ascending key 	wf-bank-cd-branch, 
		       	wf-bank-acct-nbr, 
			wf-doc-nbr 
      input procedure is ab1-wf-stmnts       	thru 	ab1-99-exit 
      output procedure is ab2-bank-list-chqs 	thru 	ab2-99-exit. 

*mf (moved to r123b.cbl)
    perform ab3-sort-eft-record			thru    ab3-99-exit. 
 
    perform az0-end-of-job			thru 	az0-99-exit. 
* 
    stop run. 
 
 
 
sec-51 section 51. 
 
 
aa0-initialization. 
 
* (y2k)
    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-dd				to run-dd. 
    move sys-yy				to run-yy. 
 
    accept sys-time			from time. 
    move sys-hrs			to run-hrs. 
    move sys-min			to run-min. 
    move sys-sec			to run-sec. 
 
    move spaces				to	r123b-prt-1 
						r123c-prt-1 
						r123c-prt-2 
						r123c-prt-3 
						r123c-prt-4 
						r123c-prt-5 
						r123c-prt-5a 
						r123c-prt-6 
						r123c-prt-7. 
    move zero				to	counters 
						ws-bank-total   
						ws-final-totals-mtd-ytd (ss-mtd) 
						ws-final-totals-mtd-ytd (ss-ytd). 
 
    open input iconst-mstr. 
 
*   display scr-title. 
 
 
 
aa0-05-eft-input. 
 
 
    accept ws-sundry. 
 
    accept ws-version-nbr. 
 
    if  ws-version-nbr  <  1   		then 
    go  to   aa0-05-eft-input. 
 
aa0-06-eft-date-validation. 
 
    accept ws-tape-yr. 
    accept ws-tape-day. 
 
    if     ws-tape-day  >   366 
       or  ws-tape-day  =     0 
    then				 
       go  to     aa0-06-eft-date-validation. 
 
* (y2k - note this is a '0yy' format year)
    accept ws-fund-yr. 
    accept ws-fund-day. 

   if    ws-fund-day  >   366 
      or ws-fund-day  =     0 
    then				 
       go  to     aa0-06-eft-date-validation. 
 
 
aa0-07-eft-date-check. 
 
    accept datecheck-option. 
 
    if   datecheck-option   =  "N" 
                       or   =  "Y" 
    then 
          next sentence 
    else 
       go  to     aa0-07-eft-date-check. 
 
    if   datecheck-option   =  "N" 
    then 
       go  to     aa0-06-eft-date-validation. 
 
 
aa0-10-clinic. 
 
 
    accept yearend-option. 
    if yearend-option   = "N" 
                     or = "Y" 
    then 
       next sentence 
    else 
       go to aa0-10-clinic. 
*   endif 
 
    if yearend-option = "Y" 
    then 
*      display yearend-label-display 
       accept yearend-label. 
*   endif 
 
    accept sel-clinic. 
    move sel-clinic			to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
      invalid key 
	move 5				to	err-ind 
 	perform za0-common-error	thru	za0-99-exit 
        go to az0-end-of-job.
*	go to aa0-10-clinic. 
 
    move iconst-date-period-end-yy  	to	ws-per-end-yr. 
    move iconst-date-period-end-mm 	to	ws-per-end-mth. 
    move iconst-date-period-end-dd 	to	ws-per-end-day. 
 
    if iconst-date-period-end-mm < 7 
    then 
	subtract 1			from	iconst-date-period-end-yy. 
*   (else) 
*   endif 
 
    move iconst-date-period-end-yy	to	r123a-h7-yr. 
 
**************************************************************** 
*   move iconst-date-period-end-mm 	to	ss-chq. 
*   (u119-payeft-file values moved into 1st occurence of fiscal yr of f060 
*    record and therefore hardcode subscript to 7) 
    move 7				to	ss-chq. 
**************************************************************** 
 
    if ss-chq < 7 
    then 
	add 12				to	ss-chq. 
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
    move sys-yy				to	ws-chq-yr. 
    move sys-mm				to	ws-chq-mth. 
    move sys-dd				to	ws-chq-day. 
 
*   display msg-month. 
 
aa0-20-chq-yr.  
 
    accept ws-chq-yr. 
 
    if ws-chq-yr < sys-yy 
    then 
	move 2				to 	err-ind 
	perform za0-common-error	thru 	za0-99-exit 
        go to az0-end-of-job.
*	go to aa0-20-chq-yr. 
*  (else) 
*   endif 
 
aa0-30-chq-mth. 
 
    accept ws-chq-mth. 
 
    if ws-chq-mth   <  1 
		 or > 12 
    then 
	move 3				to 	err-ind 
	perform za0-common-error	thru 	za0-99-exit 
        go to az0-end-of-job.
*	go to aa0-30-chq-mth. 
*   (else) 
*   endif 
 
aa0-40-chq-day. 
 
    accept ws-chq-day. 
 
    if   ws-chq-day < 1 
      or ws-chq-day > max-nbr-days (ws-chq-mth) 
    then 
	move 4				to 	err-ind   
	perform za0-common-error	thru 	za0-99-exit 
        go to az0-end-of-job.
*	go to aa0-40-chq-day. 
*   (else) 
*   endif 
 
*comment -to allow date of less than period end date s.f. 
*   if ws-chq-date < ws-per-end-date 
*   then 
*	move 8				to	err-ind 
*	perform za0-common-error	thru	za0-99-exit 
*	go to aa0-20-chq-yr. 
*   (else) 
*   endif 
 
*   display continue-line. 
 
aa0-50-continue. 
 
    accept sel-ok. 
 
    if sel-ok = "Y" 
    then 
*	display program-in-progress 
	next sentence 
    else 
	if sel-ok = "N" 
	then 
	    move spaces			to	ws-closing-msg-a 
						ws-closing-msg-b        
						ws-closing-msg-c 
						ws-closing-msg-d 
						ws-closing-msg-e 
	    go to az0-100-end-job                     
	else 
	    move 1			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job.
*	endif
*   endif
    open input  company-mstr.

*    	    move spaces			to	sel-ok 
*	    go to aa0-50-continue. 
*	endif 
*   endif 

    open i-o    eft-constant-file. 
 
    open input	cheque-reg-mstr. 
    open input	u119-payeft-file. 
    open input	doc-mstr. 
    open input	bank-mstr. 
    open input  dept-mstr. 
* 2003/01/22 - MC
*    move status-cobol-company-mstr 	to ws-file-status.
*    perform check-status.
* 2003/01/22 - end
    open output print-file-a. 
    open output print-file-b. 
    open output print-file-c. 
    open output summary-eft. 
    open output eft-logical-rec-file. 
 
*    read  eft-constant-file next. 
* 
* SPECIAL CHECK -- DOES THIS WORK ???
    read  eft-constant-file.
    add   1				to      eft-file-creation-nbr. 
    rewrite eft-file-creation-nbr. 
 


    move  eft-file-creation-nbr		to      ws-file-creation-nbr. 
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
*   ENCASE


    move   ws-file-creation-nbr      to    a-04-file-creation-number. 
    move   ws-tape-creation-date     to    a-05-creation-date. 
    move   ws-dest-data-centre       to    a-06-destination-data-centre. 
    move   spaces                    to    a-07-filler. 
    move   ws-version-nbr            to    a-08-version-number. 
*   (2007/11/14 be - cosmetic change to variable name)
*    move   ws-nbr-settlement-account to    a-09-settlement-account.
    move   ws-nbr-settlement-accounts to    a-09-settlement-account.


* 2003/01/22 - MC
*   move   ws-settlement-account     to    settlement-account(1). 
*   move   ws-institution-id         to    institution-id(1). 
    move   ws-settlement-account-1   to    settlement-account(1). 
    move   ws-institution-id-1       to    institution-id(1). 
    move   ws-settlement-account-2   to    settlement-account(2). 
    move   ws-institution-id-2       to    institution-id(2). 
* 2007/11/14 - be
    move   ws-settlement-account-3   to    settlement-account(3).
    move   ws-institution-id-3       to    institution-id(3).
* 2009/01/19 - MC
    move   ws-settlement-account-4   to    settlement-account(4).
    move   ws-institution-id-4       to    institution-id(4).
* 2009/01/19 - end

    write  eft-record-type-a. 
 
*------------------------------------------------------------------* 
 
 
    move sys-yy				to	r123a-h3-yr. 
    move sys-mm				to	r123a-h3-mth. 
    move sys-dd				to	r123a-h3-day. 
    move ws-per-end-yr			to	r123a-h5-yr. 
    move ws-per-end-mth			to	r123a-h5-mth. 
    move ws-per-end-day			to	r123a-h5-day. 
 
    move ws-chq-yr			to	r123a-p8-yr. 
    move ws-chq-mth			to	r123a-p8-mth. 
    move ws-chq-day			to	r123a-p8-day. 
 
    move 1				to	r123b-h1-page. 
    move ws-chq-mth			to	r123b-h2-mth. 
    move ws-chq-day			to	r123b-h2-day. 
    move ws-chq-yr			to	r123b-h2-yr. 
 
    move 999999.99			to	r123c-p1-chq-amt. 
    move t-month (ws-chq-mth)		to 	r123c-p1-mth. 
    move ws-chq-day			to 	r123c-p1-day. 
    move ws-chq-yr			to 	r123c-p1-yr. 
    move ","				to 	r123c-p1-comma. 
* (y2k)
*   move 19				to 	r123c-p1-nineteen. 
 
    move zeroes				to	chq-reg-key. 
    move sel-clinic			to	chq-reg-clinic-nbr-1-2. 
 
********************************************************************* 
    perform xa0-read-u119-build-f060	thru	xa0-99-exit. 
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
 
    close cheque-reg-mstr 
	  u119-payeft-file 
	  bank-mstr 
	  print-file-a 
	  print-file-b 
	  print-file-c 
*mf       output-file 
          summary-eft 
	  doc-mstr  
* 2003/01/22 - MC
	  company-mstr
* 2003/01/22 - end
          dept-mstr. 
 
*    expunge r123-work-file. 
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
 
* 2003/01/22 - MC
    perform dc0-read-company-mstr  	thru	dc0-99-exit. 
* 2003/01/22 - end
 
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
    add    1   to  ws-total-credit-nbr. 
 
    add    ws-bank-deposit (ss-mtd)       to  ws-total-credit-value. 

    move   doc-bank-nbr			  to  ws-bank-nbr. 
    move   doc-bank-branch                to  ws-bank-branch. 
    move   doc-bank-acct                  to  ws-payee-acc-nbr. 
    move   doc-nbr                        to  ws-sin-nbr. 
*   move   doc-name                       to  ws-payee-name. 
    move   doc-name			  to  ws-payee-last-name. 
    move   doc-inits			  to  ws-payee-initial. 
 
*   display  screen-traces. 
 
    move   ws-rec-c                       to  c-01-record-type. 
    move   ws-record-count                to  c-02-record-count. 

*   move   ws-origin-contl-nbr            to  c-03-origin-contl-nbr.

*   CASE
    if sel-clinic = 22
    then
        move ws-originator-nbr-clinic-22      to    c-03-originator-nbr
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
        move 9                            to    err-ind
        perform za0-common-error          thru  za0-99-exit
        go to az0-end-of-job.
*   ENDCASE

    move   ws-transaction-type            to  c-04-transaction-type. 
    move   ws-bank-deposit (ss-mtd)       to  c-05-amount. 
    move   ws-fund-avail-date             to  c-06-fund-available-date. 
    move   ws-bank-code                   to  c-07-bank-nbr. 
    move   ws-payee-acc-nbr               to  c-08-payee-acc-nbr. 
    move   ws-reserved                    to  c-09-reserved. 
    move   ws-stored-trans-type           to  c-10-stored-trans-type. 
    move   ws-payee-name		  to  c-12-payee-name. 

* 2003/01/22 -MC
*    move   ws-short-name                  to  c-11-short-name.
*    move   ws-long-name                   to  c-13-long-name.
     if  dept-company = 1
        then
            move ws-short-name             to  c-11-short-name
            move ws-long-name              to  c-13-long-name
            add 1                          to  ws-total-credit-nbr-1
            add ws-bank-deposit (ss-mtd)   to  ws-total-credit-value-1
        else
            if  dept-company = 2
*               (2007/11/14 be - added Shelter Health Network)
                move 'RMA Inc.'               to  c-11-short-name
                                                  c-13-long-name
                add 1                         to  ws-total-credit-nbr-2
                add ws-bank-deposit (ss-mtd)  to  ws-total-credit-value-2
            else
                if dept-company = 3
		then
               	    move 'Shelter Health Network' to  c-11-short-name
                                                      c-13-long-name
                    add 1                         to  ws-total-credit-nbr-3
                    add ws-bank-deposit (ss-mtd)  to  ws-total-credit-value-3
* 2009/01/19 - MC - add Palliative CAre
                else
                    if dept-company = 4
                    then
                        move 'Palliative Care'        to  c-11-short-name
                                                          c-13-long-name
                        add 1                         to  ws-total-credit-nbr-4
                        add ws-bank-deposit (ss-mtd)  to  ws-total-credit-value-4.
*               endif
* 2009/01/19 - end

*           endif
*       endif
*   endif


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
 
    write  eft-record-type-c. 
 
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
        move ws-originator-nbr-clinic-22      to    z-03-originator-nbr
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
* MC2
     move sys-yy        to    eft-run-yr.
     move sys-mm        to    eft-run-mth.
     move sys-dd        to    eft-run-day.
* MC2 - end
     write   prt-summary   from   eft-prt-head  after page. 
     move spaces        to    prt-summary. 
     move eft-prt-1     to    prt-summary. 
*    write   prt-summary   after  advancing 6 lines. 
     write   prt-summary   after  advancing 5 lines. 
 
     move ws-file-creation-nbr    to    eft-creation. 
     move ws-version-nbr          to    eft-version. 
     move ws-fund-yr              to    eft-f-yr. 
     move ws-fund-day             to    eft-f-day. 
     move ws-record-count         to    eft-record. 
     move ws-total-credit-nbr     to    eft-tran. 
     move ws-total-credit-value   to    eft-value. 
* 2003/01/22 - MC
     move ws-total-credit-nbr-1   to    eft-tran-1. 
     move ws-total-credit-value-1 to    eft-value-1. 
     move ws-total-credit-nbr-2   to    eft-tran-2. 
     move ws-total-credit-value-2 to    eft-value-2. 
*    (2007/11/15 - be - shelter health network)
     move ws-total-credit-nbr-3   to    eft-tran-3.
     move ws-total-credit-value-3 to    eft-value-3.
*    (2009/01/19 - MC - Palliative Care)
     move ws-total-credit-nbr-4   to    eft-tran-4.
     move ws-total-credit-value-4 to    eft-value-4.
*    2009/01/19 - end

     move ws-tape-yr              to    eft-sy-yr. 
     move ws-tape-day             to    eft-sy-day. 
 
     write    prt-summary  from   eft-prt-2  after  2  lines. 
     write    prt-summary  from   eft-prt-3  after  2  lines. 
     write    prt-summary  from   eft-prt-4  after  2  lines. 
     write    prt-summary  from   eft-prt-5  after  2  lines. 
     write    prt-summary  from   eft-prt-6  after  2  lines. 
     write    prt-summary  from   eft-prt-7  after  2  lines. 
* 2003/01/22 - MC
     write    prt-summary  from   eft-prt-6a after  2  lines. 
     write    prt-summary  from   eft-prt-7a after  2  lines. 
     write    prt-summary  from   eft-prt-6b after  2  lines. 
     write    prt-summary  from   eft-prt-7b after  2  lines. 
*    (2007/11/14 - be - shelter health network)
     write    prt-summary  from   eft-prt-6c after  2  lines.
     write    prt-summary  from   eft-prt-7c after  2  lines.
*    (2009/01/19 - MC - Palliative Care)
     write    prt-summary  from   eft-prt-6d after  2  lines.
     write    prt-summary  from   eft-prt-7d after  2  lines.
*    2009/01/19 - end

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
 
*mf	close            eft-logical-rec-file. 
*mf     open    input    eft-logical-rec-file. 
 
*mf     sort    sorted-file 
*mf             on   ascending key    s-record-type, 
*mf                                   s-record-count, 
*mf                                   s-x-ref-nbr 
*mf             using    eft-logical-rec-file 
*mf             giving   output-file. 
 
        perform  fa0-eft-summary     	thru	fa0-99-exit. 
 
 
ab3-99-exit. 
 
 
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
  
    write prt-line-b from r123b-head-first	after 	page. 
    add 1 				to 	page-cnt. 
    move page-cnt			to 	r123b-h1-page. 
    move bank-name			to	r123b-h1-bank-name. 
*   write prt-line-b from r123b-head-1 	after 	page. 
    write prt-line-b from r123b-head-1 	after 	1 line. 
    move spaces				to	r123b-h1-bank-name. 
 
    move bank-address1			to	r123b-h2-bank-addr. 
    move ws-chq-mth			to	r123b-h2-mth. 
    move ws-chq-day			to	r123b-h2-day. 
    move ws-chq-yr 			to	r123b-h2-yr. 
    write prt-line-b from r123b-head-2 	after 	1 line. 
    move spaces 			to	r123b-head-2. 
 
    move bank-address2			to	r123b-h2a-bank-addr. 
    write prt-line-b from r123b-head-2a after 	1 line. 
    move spaces 			to	r123b-head-2a. 
 
    move bank-city-prov			to	r123b-h2a-bank-addr. 
    write prt-line-b from r123b-head-2a	after 	1 line. 
    move spaces 			to	r123b-head-2a. 
 
    move bank-postal-cd			to	ws-postal-code. 
    move ws-pc-123		to	r123b-h3-pc-123. 
    move ws-pc-456		to	r123b-h3-pc-456. 
    write prt-line-b from r123b-head-3 	after 	1 line.                 
    move spaces				to	r123b-head-3.       
                                          
    write prt-line-b from r123b-head-2 	after 	5 lines. 
    move 19				to	ctr-lines. 
    move zeros				to 	form-cnt. 
 
 
cb0-99-exit. 
    exit. 
 
cc0-process-docs-by-branch. 
 
    move wf-bank-acct-nbr			to	r123b-p1-acct. 
    move "DR."				to	r123b-p1-dr-lit. 
 
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
    move ws-inits     		to	r123b-p1-inits. 
    move wf-doc-name		to	r123b-p1-name. 
 
    move wf-pay				to	r123b-p1-pay. 
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
        write prt-line-b from r123b-prt-1 after advancing ctr-nbr-lines lines 
        move "N" to total-flag 
    else 
        write prt-line-b from r123b-prt-1 after advancing 2 lines. 
*    endif. 
 
    move spaces				to	r123b-prt-1. 
    add 2				to	ctr-lines  
						form-cnt. 
 
cc1-99-exit. 
    exit. 
 
 
 
 
cc2-read-work-file. 
 
    return r123-work-file 
      at end 
	move "Y"			to	eof-work-file 
	go to cc2-99-exit. 
 
    add 1				to	ctr-wf-reads.         
 
cc2-99-exit. 
    exit. 
 
 
 
cd0-write-bank-total. 
 
    move "BANK TOTAL"			to	r123b-p1-name. 
    move ws-bank-total			to	r123b-p1-pay. 
 
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
 
* 2003/01/22 - MC
dc0-read-company-mstr.
 
    move dept-company 	to company-nbr.
    read company-mstr
	 invalid key 
*		(since payments may be made for terminated doctors there is
*		 no selection criteria - all doctors on file are read and
*		 for some doctors the department/company may not be valid in
*		 which case just assume they belong to "RMA" ie company 1)
		move 1				to	company-nbr.
*		move 10				to	err-ind 
*		perform za0-common-error	thru	za0-99-exit 
*		go to az0-end-of-job. 

    move company-nbr			to ws-settlement-indicator.

    move bank-account-nbr		to ws-settlement-account
				  	   ws-account-return.
    move bank-nbr			to ws-bank-nbr-id
					   ws-bank-nbr-return. 
    move bank-branch			to ws-bank-branch-id
					   ws-bank-branch-return.

* 2009/01/19 - MC - repeat second time - redundant - comment out
*   move bank-account-nbr               to ws-settlement-account
*                                          ws-account-return.
* 2009/01/19 - end


dc0-99-exit. 
    exit. 
* 2003/01/22 - end 


ea0-bank-info-to-chq. 
 
    move bank-name			to	r123c-p4-bank-name. 
    move bank-address1			to	r123c-p5-bank-addr1. 
    move bank-address2			to	r123c-p5-bank-addr2. 
    move bank-city-prov			to	r123c-p6-city-prov. 
    move bank-postal-cd			to	ws-postal-code. 
    move ws-pc-123			to	r123c-p3-pc-123. 
    move ws-pc-456			to	r123c-p3-pc-456.  
 
ea0-99-exit. 
    exit. 
 
eb0-write-chq.        
 
    move ws-bank-total			to	r123c-p1-chq-amt 
						r123c-p2-chq-amt.  
***  rounded off total to nearest hundred 
    add 99.99, ws-bank-total		giving	ws-bank-total-1. 
    divide 100				into	ws-bank-total-1 
					giving	ws-rounded-total. 
    move ws-rounded-total		to	r123c-p2-hundreds. 
 
 
*   write prt-line-c from blank-line  	after 	page. 
    write prt-line-c from r123c-head-first 	after page. 
    write prt-line-c from r123c-head-1 	after	5 lines. 
    write prt-line-c from r123c-prt-1 	after 	1 line. 
    move "NOT TO EXCEED***"		to	r123c-p2-lit1. 
    move "****HUNDRED DOLLARS"		to	r123c-p2-lit2. 
    write prt-line-c from r123c-prt-2 	after 	6 lines.              
    write prt-line-c from r123c-prt-4 	after 	4 lines.           
    write prt-line-c from r123c-prt-5 	after 	1 line.           
    write prt-line-c from r123c-prt-5a 	after 	1 line. 
    write prt-line-c from r123c-prt-6 	after 	1 line.              
    write prt-line-c from r123c-prt-3 	after 	1 line.                
    move spaces				to	r123c-prt-2  
						r123c-prt-3 
						r123c-prt-4             
						r123c-prt-5        
						r123c-prt-5a 
						r123c-prt-6. 
 
    add 1				to	ctr-cheques. 
    add ws-bank-total			to	ws-final-total. 
    move 0				to	ws-bank-total. 
 
eb0-99-exit. 
    exit. 
 
 
 
ed0-print-totals. 
 
    add 1 				to	page-cnt. 
    move page-cnt			to	r123b-h1-page. 
                                                               
*   write prt-line-b from blank-line	after	page. 
    write prt-line-b from r123b-head-first 	after page. 
 
    move "FINAL TOTAL"			to	r123b-p1-name. 
    move ws-final-total			to	r123b-p1-pay. 
    write prt-line-b from r123b-prt-1 	after 	19 lines. 
 
    write prt-line-c from r123c-head-first       after page. 
    move "TOTAL CHEQUES-"		to	r123c-p7-tot-chq. 
    move "  TOTAL AMT-"			to	r123c-p7-tot-amt. 
    move ctr-cheques			to	r123c-p7-nbr-chqs. 
    move ws-final-total			to	r123c-p7-fin-total. 
    write prt-line-c from r123c-prt-7 	after 	18 lines.            
 
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
 
    move ws-inits-name			to	r123a-h1-inits-name. 
    move doc-nbr			to	r123a-h1-doc-nbr. 
    move doc-dept			to	r123a-h1-dept. 
    move dept-name 			to	r123a-h1-1-dept-name. 
    write prt-line-a from r123a-head-first 	after page. 
*   write prt-line-a from r123a-head-1	after	page. 
    write prt-line-a from r123a-head-1	after	1 line. 
    write prt-line-a from r123a-head-1-1  after  1 line. 
    write prt-line-a from r123a-head-2	after	2 lines. 
    write prt-line-a from r123a-head-3	after	2 lines. 
    write prt-line-a from r123a-head-4	after	5 lines. 
    write prt-line-a from r123a-head-5	after	2 lines. 
    write prt-line-a from r123a-head-6	after	3 lines. 
    write prt-line-a from r123a-head-7	after	1 line.  
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
	move ws-print-gross-misc-total	to	r123a-p2-gross 
	move ws-print-mtd-misc-total	to	r123a-p2-mtd 
	move ws-print-ytd-misc-total	to	r123a-p2-ytd 
	write prt-line-a from r123a-prt-2	after	1 line. 
*   (else) 
*   endif 
 
    move spaces				to	r123a-p3-plus-lit. 
 
    if ctr-nbr-misc-lines = zero 
    then 
	move "$"			to	r123a-p3-lit-1 
						r123a-p3-lit-2 
						r123a-p3-lit-3 
    else 
	move "PLUS"			to	r123a-p3-plus-lit 
	move spaces			to	r123a-p3-lit-2 
						r123a-p3-lit-3. 
*   endif 
 
    move chq-reg-mth-bill-amt (ss-chq) 
					to	r123a-p3-gross. 
    multiply chq-reg-perc-bill (ss-chq) 
					by	100 
					giving	ws-print-percent. 
    move ws-print-percent		to	r123a-p3-percent. 
    move ws-bill-net (ss-mtd)			to	r123a-p3-mtd. 
    move ws-bill-net (ss-ytd)			to	r123a-p3-ytd. 
    write prt-line-a from r123a-prt-3	after	1 line. 
* 
* 'IF' stmt. added for faculty expense detail line 
* 
 
    if ctr-nbr-misc-lines > zero   or  ws-exp-amt (ss-ytd) > zero 
    then 
	write prt-line-a from underscore-total after 1 line 
	move ws-inc (ss-mtd)			to	r123a-p4-mtd 
	move ws-inc (ss-ytd)			to	r123a-p4-ytd 
	write prt-line-a from r123a-prt-4 after 1 line. 
*   (else) 
*   endif 

*mf brad - what happending to doc-pay-code ????? 
*mf  if  doc-pay-code    not = "4" 
     if  doc-ep-pay-code not = "4" 
     then 
          next sentence 
     else 
          move 	ws-exp-amt (ss-mtd) 		to  r123a-p3-a-mtd 
	  move  ws-exp-amt (ss-ytd) 		to  r123a-p3-a-ytd 
	  write prt-line-a from r123a-prt-3-a after 1 line. 
*    (endif) 
* 
    write prt-line-a from underscore-total after 1 line. 
 
    subtract ws-exp-amt (ss-mtd)             from     ws-inc (ss-mtd) 
                                        giving   ws-net-inc (ss-mtd). 
    subtract ws-exp-amt (ss-ytd)             from     ws-inc (ss-ytd) 
                                        giving   ws-net-inc (ss-ytd). 
 
    move ws-net-inc (ss-mtd)            to r123a-p4-a-mtd. 
    move ws-net-inc (ss-ytd)            to r123a-p4-a-ytd. 
    write prt-line-a from r123a-prt-4-a after 1 line. 
 
 
    move ws-ceil-amt (ss-mtd)		to	r123a-p5-mtd. 
    move ws-ceil-amt (ss-ytd)		to	r123a-p5-ytd. 
    write prt-line-a from r123a-prt-5	after	2 lines. 
 
    move ws-pay-due (ss-mtd)			to	r123a-p6-mtd. 
    move ws-pay-due (ss-ytd)			to	r123a-p6-ytd. 
    write prt-line-a from r123a-prt-6	after	5 lines. 
 
    move ws-tax (ss-mtd)			to	r123a-p7-mtd. 
    move ws-tax (ss-ytd)			to	r123a-p7-ytd. 
    write prt-line-a from r123a-prt-7	after	1 line. 
 
    write prt-line-a from underscore-total after	1 line. 
 
*   (print deposit only if non-zer0 m.t.d. or y.t.d. amounts) 
    if   ws-bank-deposit (ss-mtd) = zero 
     and ws-bank-deposit (ss-ytd) = zero 
    then 
	next sentence 
    else 
	move ws-bank-deposit (ss-mtd)		to	r123a-p8-mtd 
	move ws-bank-deposit (ss-ytd)		to	r123a-p8-ytd 
	write prt-line-a from r123a-prt-8	after	1 line. 
*   endif 
 
*   (print manual payments only if non-zero m.t.d. or y.t.d. amounts) 
    if    ws-manual-chqs (ss-mtd) = zero 
      and ws-manual-chqs (ss-ytd) = zero 
    then 
	next sentence 
    else 
	move ws-manual-chqs (ss-mtd)		to	r123a-p9-mtd 
	move ws-manual-chqs (ss-ytd)		to	r123a-p9-ytd 
	write prt-line-a from r123a-prt-9	after	1 line. 
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
        move ws-difference                 to r123a-p9-a-ytd 
        write prt-line-a      from r123a-prt-9-a  after 2 lines. 
* endif. 
 
    write prt-line-a from r123a-prt-10	after 	2 lines. 
    write prt-line-a from r123a-prt-11	after 	1 line.  
    write prt-line-a from r123a-prt-12	after 	1 line.  
    if doc-full-part-ind = "P" 
    then 
        write prt-line-a from r123a-prt-14   after    2 lines 
    else 
        next sentence. 
*   endif 
    if yearend-option = "Y" 
    then 
        write prt-line-a from r123a-prt-13   after    2 lines 
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
*	write prt-line-a from r123a-prt-err after 3 lines 
*	go to wa1-99-exit. 
*   (else) 
*   endif 
 
    subtract ws-tax (ss-mtd)			from	ws-pay-due (ss-mtd). 
    subtract ws-tax (ss-ytd)			from	ws-pay-due (ss-ytd). 
 
*   if   ws-pay-due(ss-mtd) not = (ws-bank-deposit(ss-mtd) + ws-manual-chqs(ss-mtd)) 
*     or ws-pay-due(ss-ytd) not = (ws-bank-deposit(ss-ytd) + ws-manual-chqs(ss-ytd)) 
*   then 
*	write prt-line-a from r123a-prt-err after 3 lines. 
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
	move "$"			to	r123a-p1-lit-1 
						r123a-p1-lit-2 
						r123a-p1-lit-3 
    else 
	move spaces			to	r123a-p1-lit-1 
						r123a-p1-lit-2 
						r123a-p1-lit-3. 
*   endif 
 
    move chq-reg-mth-misc-amt (ss-chq, ss-misc) 
					to	r123a-p1-gross. 
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
 
    move ws-print-percent		to	r123a-p1-percent. 
 
    move ws-misc-net (ss-mtd, ss-misc)		to	r123a-p1-mtd. 
    add  ws-misc-net (ss-mtd, ss-misc)		to	ws-print-mtd-misc-total. 
    move ws-misc-net (ss-ytd, ss-misc)		to	r123a-p1-ytd.  
    add  ws-misc-net (ss-ytd, ss-misc)		to	ws-print-ytd-misc-total. 
 
    write prt-line-a from r123a-prt-1	after	1 line. 
    add 1				to	ctr-nbr-misc-lines. 
    move spaces				to	r123a-p1-lit-1 
						r123a-p1-lit-2 
						r123a-p1-lit-3. 
 
wa2-99-exit. 
    exit. 
wa3-print-totals. 
 
*  print the pgm name at the upper left corner for the last page 
*  of the report r123a 
 
    write prt-line-a from r123a-head-first after page. 
 
*   write prt-line-a from r123a-head-3	 after	page. 
    write prt-line-a from r123a-head-3	 after	2 lines. 
    write prt-line-a from r123a-head-4   after	2 lines. 
    write prt-line-a from r123a-tot-head after	2 lines. 
    write prt-line-a from r123a-head-6   after	3 lines. 
    write prt-line-a from r123a-head-7   after	1 line. 
    write prt-line-a from blank-line     after	1 line. 
 
    move "$"				to	r123a-p1-lit-1 
						r123a-p1-lit-2 
						r123a-p1-lit-3. 
 
    move 0				to	ws-print-gross-misc-total 
						ws-print-mtd-misc-total 
						ws-print-ytd-misc-total. 
 
    perform wa3a-print-misc		thru	wa3a-99-exit 
	varying	ss-misc 
		from 1 by 1 
	until	ss-misc > 10. 
 
    write prt-line-a from underscore-detail after 1 line. 
    move ws-print-gross-misc-total	to	r123a-p2-gross. 
    move ws-print-mtd-misc-total	to	r123a-p2-mtd. 
    move ws-print-ytd-misc-total	to	r123a-p2-ytd. 
    write prt-line-a from r123a-prt-2	after	1 line. 
     
    move "PLUS"				to	r123a-p3-plus-lit. 
    move spaces				to	r123a-p3-lit-2 
						r123a-p3-lit-3. 
    move ws-fin-bill-gross (ss-mtd)		to	r123a-p3-gross. 
    move spaces				to	r123a-p3-percent-r. 
    move ws-fin-bill-net (ss-mtd)		to	r123a-p3-mtd. 
    move ws-fin-bill-net (ss-ytd)		to	r123a-p3-ytd. 
    write prt-line-a from r123a-prt-3	after	1 line. 
* 
*  following two stmts. added 		may/85  k.p. 
* 
    move ws-fin-exp-amt (ss-mtd)	to 	r123a-p3-a-mtd. 
    move ws-fin-exp-amt (ss-ytd) 	to 	r123a-p3-a-ytd. 
    write prt-line-a from r123a-prt-3-a after 	1 line. 
 
    write prt-line-a from underscore-total  
					after	1 line. 
    move ws-fin-inc (ss-mtd)		to	r123a-p4-mtd. 
    move ws-fin-inc (ss-ytd)		to	r123a-p4-ytd. 
    write prt-line-a from r123a-prt-4	after	1 line. 
 
    move ws-fin-ceil-amt (ss-mtd)	to	r123a-p5-mtd. 
    move ws-fin-ceil-amt (ss-ytd)	to	r123a-p5-ytd. 
    write prt-line-a from r123a-prt-5	after	2 lines. 
 
    move ws-fin-pay-due (ss-mtd)	to	r123a-p6-mtd. 
    move ws-fin-pay-due (ss-ytd)	to	r123a-p6-ytd. 
    write prt-line-a from r123a-prt-6	after	5 lines. 
 
    move ws-fin-tax (ss-mtd)		to	r123a-p7-mtd. 
    move ws-fin-tax (ss-ytd)		to	r123a-p7-ytd. 
    write prt-line-a from r123a-prt-7   after	1 line. 
 
    write prt-line-a from underscore-total 
					after	1 line. 
 
    move ws-fin-deposit (ss-mtd)	to	r123a-p8-mtd. 
    move ws-fin-deposit (ss-ytd)	to	r123a-p8-ytd. 
    write prt-line-a from r123a-prt-8	after	1 line. 
 
    move ws-fin-man-chqs(ss-mtd)	to	r123a-p9-mtd. 
    move ws-fin-man-chqs(ss-ytd)	to	r123a-p9-ytd. 
    write prt-line-a from r123a-prt-9	after	1 line. 
    write prt-line-a from underscore-total 
					after	1 line. 
 
    add ws-print-mtd-misc-total		to	ws-fin-bill-net (ss-mtd). 
    add ws-print-ytd-misc-total		to	ws-fin-bill-net (ss-ytd). 
 
*   if   ws-fin-bill-net (ss-mtd) not = ws-fin-inc (ss-mtd) 
*     or ws-fin-bill-net (ss-ytd) not = ws-fin-inc (ss-ytd) 
*   then 
*	write prt-line-a from r123a-prt-err after 3 lines 
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
*	write prt-line-a from r123a-prt-err after 3 lines. 
*   (else) 
*   endif 
 
wa3-99-exit. 
    exit. 
wa3a-print-misc. 
 
    move ws-fin-misc-gross (ss-mtd,ss-misc)	to	r123a-p1-gross. 
    if ss-misc = 1 
    then 
	move spaces			to	r123a-p1-percent-r 
    else 
	subtract 1 			from	ss-misc 
					giving	ss-perc 
	multiply const-misc-curr (ss-perc) by	100 
					giving	ws-print-percent 
	move ws-print-percent          to	r123a-p1-percent. 
*   endif 
 
    move ws-fin-misc-net (ss-mtd, ss-misc)	to	r123a-p1-mtd. 
    move ws-fin-misc-net (ss-ytd, ss-misc)	to	r123a-p1-ytd. 
    write prt-line-a from r123a-prt-1	after	1 line. 
    move spaces				to	r123a-p1-lit-1 
						r123a-p1-lit-2 
						r123a-p1-lit-3. 
    add ws-fin-misc-gross (ss-mtd, ss-misc)	to	ws-print-gross-misc-total. 
    add ws-fin-misc-net (ss-mtd, ss-misc)	to	ws-print-mtd-misc-total. 
    add ws-fin-misc-net (ss-ytd, ss-misc)	to	ws-print-ytd-misc-total. 
 
wa3a-99-exit. 
    exit. 
xa0-read-u119-build-f060. 
 
*   (zero f060 cheque reg before moving in u119 values) 
    move zeros				to	cheque-reg-rec. 
    perform xb1-zero-chq		thru	xb1-99-exit.
 
    read u119-payeft-file 
	at end 
	   move "Y"			to	eof-u119-payeft-file 
	   move "Y"			to	eof-chq-reg-mstr 
	   go to xa0-99-exit. 
 
    move 0				to	n-doc-dept.
    move w-doc-dept			to	n-doc-dept. 
* 2003/11/18 - MC
*!  move 0                              to      n-doc-nbr.
    move w-doc-nbr                      to      n-doc-nbr.
* 2003/11/18 - end

    move 0				to	n-payeft-amt-n. 
    move w-payeft-amt-n			to	n-payeft-amt-n. 

*   (99/aug/18 B.E. removed hard coded clinic 22)
*   move 22				to	chq-reg-clinic-nbr-1-2. 
    move sel-clinic			to      chq-reg-clinic-nbr-1-2. 

    move n-doc-dept                     to	chq-reg-dept. 
    move n-doc-nbr                     	to	chq-reg-doc-nbr. 
    move n-payeft-amt-n 
					to	chq-reg-regular-pay-this-mth(ss-chq). 
 
    add 1				to	ctr-u119-payeft-reads. 
 
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

 check-status.
     evaluate status-key-1
      when "0" next sentence
      when "1" display "end of file reached"
         perform check-eof-status
      when "2" display "invalid key"
         perform check-inv-key-status
      when "3" display "permanent error"
         perform check-perm-err-status
      when "4" display "logic error"
      when "9" display "run-time-system error"
         perform check-mf-error-message
     end-evaluate.

check-eof-status.
     if status-key-2 = "0"
         display "no next logical record"
     end-if.

check-inv-key-status.
     evaluate status-key-2
      when "2" display "attempt to write dup key"
      when "3" display "no record found"
     end-evaluate.

check-perm-err-status.
     move binary-status to  display-ext-status
     display display-ext-status.
	display display-key-2.
     if status-key-2 = "5"
         display "file not found"
     end-if.

check-mf-error-message.
     evaluate binary-status
      when 002 display "file not open"
      when 007 display "disk space exhausted"
      when 013 display "file not found"
      when 024 display "disk error    "
      when 065 display "file locked      "
      when 068 display "record locked    "
      when 039 display "record inconsistent"
      when 146 display "no current record  "
      when 180 display "file malformed     "
      when 208 display "network error      "
      when 213 display "too many locks     "
      when other display "not error status "
         display binary-status
     end-evaluate. 

    copy "y2k_default_sysdate_century.rtn".