identification division. 
program-id.  r123b. 
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
*       r123a - does the sort phase
*       r123b - creates EFT file/reports
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
*		  	  r123a performing only the sort. and r123b creating
*			  the EFT file and reports.
*
*   99/aug/19   B.E.    - added multi-payroll option for clinic 22 and 81
*
*   99/nov/15   B.E.    - added copybook so that all unique data for RMA 
*                         clinic 22/80 is not hard coded in pgm
*   00/nov/10   B.E.    - added 'mp' payroll processing - NOTE that clinic 99
*                         is used to run the 'mp' clinic payroll
*   03/nov/18   M.C.    - alpha doc nbr
* 2006/may/10 be      - $1M payroll changes to size of calculated fields
* 2007/nov/14 be - cosmetic change to variable name  ws-nbr-settlement-account 
* 2010/Oct/26 MC - extend the field size to 9(8)v99 for r123c-p7-fin-total and r123-p1-pay
*		   so that user can balance
* 2016/Apr/27 MC1 - delete the codes that are not needed as they are very confusing  and this program 
*                   r123b creates the EFT file (eft_tape) from work_file_a.

environment division. 
input-output section. 
file-control. 
* 
*   place your file select statements here 
* 
    copy "f090_constants_mstr.slr". 
* 
    copy "eft_logical_rec_file.slr". 
 
    select sorted-file 
        assign to ws-sorted-file 
        organization is  sequential. 
  
    select output-file 
        assign to ws-output-file 
        organization is  sequential. 
 
data division. 
file section. 
* 
    copy "f090_constants_mstr.fd". 
 
    copy "f090_const_mstr_rec_3.ws". 
 
    copy "eft_logical_rec_file.fd". 
 
sd    sorted-file
                block    contains   1464  characters
                record   contains   1464  characters.

01    sorted-record.
             05   s-record-type                   pic x.
             05   s-record-count                  pic x(9).
             05   s-originator-nbr                pic x(14).
             05   s-mix-1                         pic x(150).
             05   s-x-ref-nbr                     pic x(3).
             05   s-mix-2                         pic x(1287).

 
fd    output-file 
                block    contains   1464  characters 
                record   contains   1464  characters. 
 
01    output-record                               pic x(1464). 
 
working-storage section. 

 
77  sel-clinic				pic 99		value zeroes. 
77  err-ind				pic 99 		value zeroes. 

*  	status file indicators 
* 
77  common-status-file			pic x(2)       value zero. 
77  status-iconst-mstr			pic x(11)       value spaces. 
77  status-cobol-iconst-mstr		pic xx		value zero. 
* 
 
 
77   ws-work-file-a             pic x(11)       value "work_file_a". 
77   ws-sorted-file             pic x(11)       value "sorted_file". 
77   ws-output-file             pic x(8)        value "eft_tape". 
 
 
copy "mth_desc_max_days.ws". 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"INVALID CLINIC NUMBER". 

    05  error-messages-r redefines error-messages.
        10  err-msg                             pic x(60)
                        occurs 1 times.
 
01  err-msg-comment				pic x(60). 
 
 
 
    copy "sysdatetime.ws". 
 
 
procedure division. 
declaratives. 
 
err-constants-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-constants-mstr. 
    move status-iconst-mstr		to common-status-file. 
    display common-status-file. 
    stop "ERROR IN ACCESSING CONSTANTS MASTER". 
    stop run. 
 
end declaratives. 
 
main-line section. 
mainline. 
 
    perform aa0-initialization			thru 	aa0-99-exit. 
 
    perform ab3-sort-eft-record			thru    ab3-99-exit. 
 
    perform az0-end-of-job			thru 	az0-99-exit. 
    
    stop run. 
 
 
 
sec-51 section 51. 
 
 
aa0-initialization. 

    accept sys-date			from date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
 
    open input iconst-mstr. 
 
 
aa0-10-clinic.
 
    accept sel-clinic. 
    move sel-clinic			to	iconst-clinic-nbr-1-2. 
 
    read iconst-mstr 
      invalid key 
	move 1				to	err-ind 
 	perform za0-common-error	thru	za0-99-exit 
	go to aa0-10-clinic. 
 
    close iconst-mstr. 
 
 
*------------------------------------------------------------------* 
 
aa0-99-exit. 
    exit. 
 
ab3-sort-eft-record.


        sort    sorted-file
                on   ascending key    s-record-type,
                                      s-record-count,
                                      s-x-ref-nbr
                using    eft-logical-rec-file
                giving   output-file.


ab3-99-exit.
   exit.
 
 
az0-end-of-job. 
 
    accept sys-time			from time. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
 
 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-comment. 
 
za0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
