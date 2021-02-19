identification division. 
program-id. u041.    
author. dyad computer systems inc. 
installation. rma. 
date-written. 82/03/02. 
date-compiled. 
security. 
* 
*    files      : f040 - oma fee master file 
*   		: f090 - constants master    
*		: t040 - ohip schedule of benefits tape 
*               : audit report (ru041a) 
*		: error report (ru041b) 
* 
*    program purpose : update ohip & oma rates on oma fee master from 
*	     	       ohip tape file (d.m.)                   
* 
* 
*    revised nov/83 (a.j.) - print new codes on ru041 if all fees 
*		             zero (including new err message 20 ) 
* 2001/apr/23 B.E. - effective date now moved from OHIP fee schedule
*		     to oma code's f040 record and no verification
*		     is made against the constants master effective
*		     date.
* 
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
* 
*	note #1:  when the chart below indicates that the 'SPECIALIST' (spec) rate 
*		  is to be used, in actual fact either the specialist -or- the 
*		  'GP' rate can be found on the tape.(however if both 
*		   are found then they must be equal (see ##)).  to simplify 
*		  programming, immediately after the read of the tape record 
*		  these two 'SPEC' and 'GP' fields are checked.  if the specialist 
*		  rate = zero and the 'GP' rate is non-zero then the 'GP' 
*		  rate is copied into the specialist field so that all code 
*		  can then deal with the 'SPEC' field only.  
* 
* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
* 
*	correspondence of: ohip tape field  -to- fee master field  -to-  audit report field 
*	                   ---------------       ----------------        ------------------ 
* 
* --------------------------------------------------------------------------- 
* icc type	from ohip tape field	 -to-	fee mstr field & print field 
* --------	--------------------            --------------   ----------- 
*   cp ##     	   3   (spec)			    fee-1	    1 (gp) 
*		   4 # (anae)			    anae	    4 (anae) 
* --------	--------------------		--------------   ----------- 
*   cv ##	   3   (spec)			    fee-1	    2 (spec) 
* --------	--------------------		--------------   ----------- 
*   dr		   2   (asst)		   	    fee-1	    1 (gp) 
*		   4 ! (anae) or 5(non-anae)	    fee-2	    2 (spec) 
* --------	--------------------		--------------   ----------- 
*   dt ##	   3   (spec)		 	 fee-1 & fee-2	    2 (spec) 
*     		   4 # (anae)			    anae	    4 (anae) 
*---------	--------------------		--------------   ----------- 
*  du/nm/pf	   2   (asst)		   	    fee-1	    1 (gp) 
*		   4   (anae)		   	    fee-2	    2 (spec) 
* --------	--------------------		--------------   ----------- 
*   sp ##	   2 # (asst)		   	     asst	    3 (asst) 
*		   3 # (spec)		  	 fee-1 & fee-2	    2 (spec) 
*		   4 # (anae)		   	     anae	    4 (anae) 
*		(must have at least 
*		 1 of the 3 codes) 
* --------	--------------------		--------------   ----------- 
* 
*  note:  #  -- use only if non-zero on ohip tape 
*        ##  -- if "OHIP-FEES (1)" (ie. general practice) and 
*		   "OHIP-FEES (3)" (ie. specialist) are both present 
*	 	on the tape they must be equal! 
*  note:  !  -- use 4 (anae)if non-zero; otherwise use 5 (non-anae) if non-zero
* --------------------------------------------------------------------------- 
* 
*    revision may/87 (s.b.) - coversion from aos to aos/vs. 
*                             change field size for 
*                             status clause to 2 and 
*                             feedback clause to 4. 
* 
*   revised march/89 : - sms 115 s.f. 
*		       - make sure file status is pic xx ,feedback is 
*			 pic x(4) and infos status is pic x(11). 
* 
*   revised 1999/May/18 S.B.	- Altered for Y2K.
*   revised 2012/May/14 MC1     -- uncomment the check on DR codes
*			        -- user would like to include the update for diagnostic radiologist codes as well
*			        -- update DR codes to be the same as du/nm/pf group
*   revised 2012/May/23 MC2     -- update DR codes to be similar as du/nm/pf group EXCEPT when 4(anae) = zero
*			           but 5(non-anae) not = zero, then use 5(non-anae) instead    
*   revised 2016/Sep/14 MC3     -- set OMA amount = OHIP amount x 2.13, this may change in the future

environment division. 
input-output section. 
file-control. 
* 
    copy "f040_oma_fee_mstr.slr". 
* 
    copy "f090_constants_mstr.slr". 
* 
    select ohip-benefit-sched-tape 
	assign to "fee_schedule_ohip_ascii"    
*mf	file status is status-ohip-file. 
	file status is status-cobol-ohip-file. 
 
    select audit-file 
          assign to printer print-file-1-name 
	  file status is status-audit-rpt. 
 
* 
      select error-file 
	  assign to printer print-file-2-name 
	  file status is status-error-rpt. 
 
* 
data division. 
file section. 
* 
copy "f040_oma_fee_mstr.fd". 
* 
copy "f090_constants_mstr.fd". 
 
copy "f090_const_mstr_rec_2.ws". 
 
* 
copy "t040_ohip_sched_tape.fd". 
* 
* 
fd  audit-file 
    record contains 132 characters. 
 
01  audit-rec					pic x(132). 
 
 
 
fd  error-file 
    record contains 132 characters. 
 
01  error-rec					pic x(132). 
 
working-storage section. 
 
77  err-ind					pic 9(02)	value zero. 
77  temp-1					pic 9(02)	value zero. 
* (y2k)
*77  ws-2-yrs-ago				pic 9(02)	value zero. 
77  ws-2-yrs-ago				pic 9(04)	value zero. 
77  ws-anae-asst-bypass-ind			pic 9(7)v9999	value 0.9999. 
77  ws-expected-ohip-reads			pic 9(07)	value zero. 
77  ws-rec-nbr					pic 9(07).    
77  ws-rec-rem					pic 9(07).  
 
 
77  print-file-1-name				pic x(06)	value "ru041a". 
77  print-file-1				pic x(30)	value "AUDIT REPORT IS IN RU041A". 
77  print-file-2-name				pic x(06)	value "ru041b". 
77  print-file-2				pic x(30)	value "ERROR REPORT IS IN RU041B". 
* 
*   subscripts 
* 
01  subscripts. 
    05  ss					pic 9(02)	comp. 
    05  ss-rate-count				pic 9(01) 	comp	value zero. 
    05  ss-bypass-count				pic 9(02)	comp	value zero. 
* 
*   ohip fee schedule tape'S SUBSCRIPTS 
* 
01  ohip-fee-sched-subscripts. 
    05  ss-tape-gp				pic 9(01)	comp	value 1. 
    05  ss-tape-asst				pic 9(01)	comp	value 2. 
    05  ss-tape-spec				pic 9(01)	comp	value 3. 
    05  ss-tape-anae				pic 9(01)	comp	value 4. 
    05  ss-tape-non-anae			pic 9(01)	comp	value 5. 
 
* 
*  file feedback indicators 
* 
77  feedback-oma-fee-mstr			pic x(04)	value space. 
77  feedback-iconst-mstr			pic x(04)	value space. 
* 
*  status file indicators 
* 
77  status-file					pic x(11)	value zero. 
77  status-audit-rpt				pic x(02)	value zero. 
*mf 77  status-oma-mstr				pic x(11)	value zero. 
77  status-cobol-oma-mstr			pic x(2)	value zero. 
*mf 77  status-ohip-file			pic x(02)	value zero. 
77  status-cobol-ohip-file			pic x(02)	value zero. 
77  status-error-rpt				pic x(02)	value zero. 
*mf 77  status-iconst-mstr			pic x(11)	value zero. 
77  status-cobol-iconst-mstr			pic x(02)	value zero. 
 
01  sel-code. 
    05  sel-code-ltr				pic x(01)	value spaces. 
    05  sel-code-nbr				pic x(03)	value spaces. 
 
01  ohip-flag					pic x(01). 
    88  ohip-eof			value "Y". 
    88  ohip-not-eof			value "N". 
 
01  oma-flag					pic x(01). 
    88  oma-eof				value "Y". 
    88  oma-not-eof			value "N". 
 
01  oma-code-type-check                         pic x(01). 
    88  skip-oma			value "Y". 
    88  dont-skip-oma			value "N". 
 
01  verify-flag					pic x(01). 
    88  verify-ok			value "Y". 
    88  verify-not-ok			value "N". 
 
01  reverify-flag				pic x(01). 
    88  reverify-ok			value "Y". 
    88  reverify-not-ok			value "N". 
 
01  fees-valid-flag				pic x(01). 
    88  fees-valid			value "Y". 
    88  fees-not-valid			value "N". 
 
01  bypass-check				pic x(01). 
    88  bypass				value "Y". 
    88  dont-bypass			value "N". 
 
01  bypass-codes-table. 
    05  screen-bypass-codes. 
	10  bypass-code-1			pic x(04)	value " ". 
	10  bypass-code-2			pic x(04)	value " ". 
	10  bypass-code-3			pic x(04)	value " ". 
	10  bypass-code-4			pic x(04)	value " ". 
	10  bypass-code-5			pic x(04)	value " ". 
	10  bypass-code-6			pic x(04)	value " ". 
	10  bypass-code-7			pic x(04)	value " ". 
	10  bypass-code-8			pic x(04)	value " ". 
	10  bypass-code-9			pic x(04)	value " ". 
	10  bypass-code-10			pic x(04)	value " ". 
    05  screen-bypass-codes-r redefines screen-bypass-codes. 
	10  bypass-code occurs 10 times		pic x(04). 
 
 
01  ws-units-table. 
    05  ws-asst-units				pic 9(03)	value 0. 
    05  ws-asst-rem				pic 99v99	value 0. 
    05  ws-anae-units				pic 9(03)	value 0. 
    05  ws-anae-rem				pic 99v99	value 0. 
    05  ws-non-anae-units			pic 9(03)		value 0. 
    05  ws-non-anae-rem				pic 99v99	value 0. 
 
*   counters for records read/written for all input/output files 
 
01  counters. 
    05  ctr-oma-reads				pic 9(07). 
    05  ctr-no-rma-code				pic 9(07). 
    05  ctr-rates-implemented			pic 9(07). 
    05  ctr-nbr-errors           		pic 9(07). 
    05  ctr-zero-fees				pic 9(07). 
    05  ctr-no-ohip-rate			pic 9(07). 
    05  ctr-old-terminations			pic 9(07). 
    05  ctr-h1-page				pic 9(04).    
    05  ctr-h1-lines				pic 9(02).   
    05  ctr-h2-page				pic 9(04).   
    05  ctr-h2-lines				pic 9(02). 
    05  ctr-actual-ohip-reads			pic 9(07). 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(27)   value 
			"invalid entry". 
	10  filler				pic x(27)   value 
			"conmstr read error". 
	10  filler				pic x(27)   value 
			"oma-fee-mstr read error".  
	10  filler				pic x(27)   value 
			"oma-fee-mstr write error".  
	10  filler				pic x(27)   value 
* msg #5 
			"ohip-schedule read error". 
	10  filler				pic x(27)   value 
			"valid code not on rma file". 
	10  filler				pic x(27)   value 
			"effective dates disagree".             
	10  filler				pic x(27)   value 
			"user specified bypass". 
	10  filler				pic x(27)   value 
			"no ohip rate for code". 
	10  filler				pic x(27)   value 
* msg #10 
			"units not integer".            
	10  filler				pic x(27)   value 
			"percentage add-on code".          
	10  filler				pic x(27)   value 
			"diagnostic radiation code".               
	10  filler				pic x(27)   value 
			"anae.,non-anae.units differ". 
	10  filler				pic x(27)   value 
			"terminated code on rma file".    
	10  filler				pic x(27)   value 
* msg #15 
			"gen.& spec.fees differ". 
	10  filler				pic x(27)   value 
			"fee too large for fee mstr". 
	10  filler				pic x(27)   value 
			"too many decimal positions". 
	10  filler				pic x(27)   value 
			"bad icc code on rma file". 
	10  filler				pic x(27)	value 
			"a required fee is zero". 
	10  filler				pic x(27)	value 
		        "new code - all fees zero". 
 
    05  error-messages-r redefines error-messages. 
	10  err-msg				pic x(27) 
			occurs 20 times. 
 
01  err-msg-comment				pic x(60). 
 
01  e1-error-line. 
 
    05  e1-error-word				pic x(13)    value 
			"***  error - ". 
    05  e1-error-msg				pic x(119). 
 
 
 
 
    copy "sysdatetime.ws". 
01  blank-line. 
    05  filler				pic x(132)	value spaces. 
 
01  t1-total-line. 
    05  filler				pic xx		value spaces. 
    05  filler				pic x(30)	value 
		"new rates implemented". 
    05  t1-rates-implemented		pic z(6)9. 
    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(34)	value 
		"nbr.of codes on error report".   
    05  t1-nbr-errors			pic z(6)9. 
    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(30)	value 
		"printed-valid codes not on rma". 
    05  t1-no-rma-code			pic z(6)9. 
  
01  t2-total-line. 
    05  filler				pic xx		value spaces. 
    05  filler				pic x(30)	value 
		"printed-no ohip rate for code". 
    05  t2-no-ohip-rate           	pic z(6)9. 
    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(32)	value 
		"not printed-terminated before 19". 
* (y2k)
*    05  t2-2-yrs-ago			pic 99. 
    05  t2-2-yrs-ago			pic 9999. 
    05  t2-old-terminations		pic z(6)9. 
* (y2k)
*    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(30)	value 
		"not printed-all rates zero". 
    05  t2-zero-fees			pic z(6)9. 
 
01  t3-total-line.              
    05  filler				pic xx		value spaces. 
    05  filler				pic x(28)	value                       
		"nbr.of ohip codes expected:". 
    05  t3-expected-ohip		pic z,zzz,zz9	value zero. 
    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(32)	value 
		"nbr.of ohip codes read:". 
    05  t3-actual-ohip			pic z,zzz,zz9	value zero. 
    05  filler				pic x(10)	value space. 
    05  filler				pic x(28)	value 
		"difference:". 
    05  t3-difference			pic z,zzz,zz9	value zero. 
 
01  t4-total-line.                    
    05  filler				pic xx		value spaces. 
    05  filler				pic x(33)	value 
		"bypassed codes were:". 
    05  t4-code-section occurs 10 times. 
    	10  t4-code			pic x(4). 
	10  filler			pic x(5). 
 
*	ru041a - implemented report (h1) 
*	------------------------------ 
 
01  h1-head. 
    05  filler				pic x(50)	value 
		"ru041a".   
    05  filler				pic x(52)	value 
		"ohip rate changes - implemented". 
    05  filler				pic x(9)	value 
		"run date". 
* (y2k)
    05  h1-run-date			pic x(8). 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(5)	value 
		"page". 
    05  h1-page-nbr			pic zzz9. 
 
01  h1-title-1. 
    05  filler				pic x(28)	value 
		"from constants master:". 
    05  filler				pic x(15)	value 
		"effective date". 
* (y2k - auto fix)
*   05  h1-const-yr			pic 99		value zero. 
    05  h1-const-yr			pic 9(4)		value zero. 
    05  filler				pic x		value "/". 
    05  h1-const-mth			pic 99		value zero. 
    05  filler				pic x		value "/". 
    05  h1-const-day			pic 99		value zero. 
* (y2k)
*    05  filler				pic x(7)	value spaces. 
    05  filler				pic x(5)	value spaces. 
    05  filler				pic x(10)	value 
		"asst. rate". 
    05  h1-asst-rate			pic z9.99	value zero. 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(18)	value 
		"cert.anaesthetist". 
    05  h1-cert-rate			pic z9.99	value zero. 
    05  filler				pic x(8)	value spaces. 
    05  filler				pic x(19)	value 
		"reg.anaesthetist". 
    05  h1-reg-rate			pic z9.99	value zero. 
 
01  h1-title-2. 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(9)	value "code". 
    05  filler				pic x(12)	value     
		"effective". 
    05  filler				pic x(11)	value 
		"icc". 
    05  filler				pic x(22)	value 
		"gen.p/technical".   
    05  filler				pic x(31)	value 
		"special/profess". 
    05  filler				pic x(12)	value 
		"assistant". 
    05  filler				pic x(23)	value 
		"anaesthetist". 
 
01  h1-title-3. 
    05  filler				pic x(15)	value spaces. 
    05  filler				pic x(9)	value "date". 
    05  filler				pic x(12)	value "code". 
    05  filler				pic x(11)	value "curr". 
    05  filler				pic x(11)  	value "tape". 
    05  filler				pic x(11)	value "curr". 
    05  filler				pic x(17)	value "tape". 
    05  filler				pic x(12)	value "curr". 
    05  filler				pic x(20)	value "tape". 
    05  filler				pic x(9)	value "curr". 
    05  filler				pic x(11)	value "tape". 
                
01  h1-detail-line. 
    05  h1-rates-same  			pic x(4)	value "****". 
    05  h1-code-nbr			pic x(9). 
* (y2k - auto fix)
*   05  h1-effective-yr			pic 99		value zero. 
    05  h1-effective-yr			pic 9(4)		value zero. 
    05  h1-slash1			pic x		value "/". 
    05  h1-effective-mth		pic 99		value zero. 
    05  h1-slash2			pic x		value "/". 
    05  h1-effective-day		pic 99		value zero. 
    05  filler				pic x(4) 	value spaces. 
    05  h1-icc-code			pic xx		value spaces. 
    05  filler				pic x(4)	value spaces. 
    05  h1-old-rate-1			pic zz,zz9.99	value zero. 
    05  filler				pic xx		value spaces. 
    05  h1-new-rate-1			pic zz,zz9.99	value zero. 
    05  filler				pic xx		value spaces. 
    05  h1-old-rate-2			pic zz,zz9.99	value zero. 
    05  filler				pic xx   	value spaces. 
    05  h1-new-rate-2			pic zz,zz9.99	value zero. 
    05  filler				pic x(13)	value spaces. 
    05  h1-old-rate-3			pic z9		value zero. 
    05  filler				pic x(11)	value spaces. 
    05  h1-new-rate-3			pic z9		value zero. 
    05  filler				pic x(14)	value spaces. 
    05  h1-old-rate-4			pic z9		value zero. 
    05  filler				pic x(7)	value spaces. 
    05  h1-new-rate-4			pic z9		value zero. 
 
 
 
* 	ru041b - not implemented report (h2) 
*	----------------------------------- 
 
01  h2-head. 
    05  filler				pic x(48)	value 
		"ru041b". 
    05  filler				pic x(54)	value 
		"ohip rate changes - not implemented". 
    05  filler				pic x(9)	value 
		"run date". 
* (y2k)
    05  h2-run-date			pic x(8). 
    05  filler				pic x(4)	value spaces. 
    05  filler				pic x(5)	value "page".
    05  h2-page-nbr			pic zzz9. 
 
01  h2-title-1. 
    05  filler				pic x(7)	value 
		"code". 
    05  filler				pic x(4)	value 
		"icc". 
    05  filler				pic x(13)	value 
		"effective". 
    05  filler				pic x(23)	value 
		"reason". 
    05  filler				pic x(16)	value 
		"termination". 
    05  filler				pic x(10)	value   
     		"g.p./".    
    05  filler				pic x(19)	value 
		"specialist/". 
    05  filler				pic x(17)	value 
		"assistant". 
    05  filler				pic x(15)	value 
		"cert.".             
    05  filler				pic x(4)	value 
		"reg.". 
 
01  h2-title-2. 
    05  filler				pic x(6)	value spaces. 
    05  filler				pic x(7)	value 
		"code". 
    05  filler				pic x(38)	value   
		"date". 
    05	filler				pic x(10)	value 
		"date". 
    05  filler				pic x(12)	value 
		"technical". 
    05  filler				pic x(32)	value 
		"professional". 
    05  filler				pic x(15)	value 
		"anaesthetist". 
    05  filler				pic x(13)	value 
		"anaesthetist". 
 
01  h2-detail-line. 
    05  h2-code				pic x(7). 
    05  h2-icc-code			pic x(4)	value spaces. 
* (y2k - auto fix)
*   05  h2-effective-yr			pic 99		value zero. 
    05  h2-effective-yr			pic 9(4)		value zero. 
    05  h2-slash1			pic x		value "/". 
    05  h2-effective-mth		pic 99		value zero. 
    05  h2-slash2			pic x		value "/". 
    05  h2-effective-day		pic 99		value zero. 
    05  filler				pic x		value spaces.  
    05  h2-reason			pic x(28).      
* (y2k - auto fix)
*   05  h2-termination-yr		pic 99		value zero. 
    05  h2-termination-yr		pic 9(4)		value zero. 
    05  h2-slash3			pic x		value "/". 
    05  h2-termination-mth		pic 99		value zero. 
    05  h2-slash4			pic x		value "/". 
    05  h2-termination-day		pic 99		value zero.  
    05  h2-rates occurs 5 times. 
	10  h2-new-rate			pic z,zzz,zz9.9999. 
	10  h2-err-ind			pic x.   
 
		 
01  h2-stars. 
    05  filler				pic x(132)	value 
	"*****************************************************". 
screen section. 
 
01  scr-title. 
    05  	blank screen. 
    05		line 01 col 01 value is "u041". 
    05  	line 01 col 20 value is "update oma fee master file from ohip tape". 
* (y2k - auto fix)
*   05  	line 01 col 73 pic 99/99/99 from sys-date-long. 
    05  	line 01 col 71 pic 9999/99/99 from sys-date-long. 
             
01  rates-message. 
    05		line 07 col 1 value is "current date and ohip rates are:". 
    05  	line 07 col 40 value is "effective date". 
* (y2k - auto fix)
*   05		line 07 col 70 pic 99 using const-yy-curr.         
    05		line 07 col 68 pic 9(4) using const-yy-curr.         
    05		line 07 col 72 value "/". 
    05 		line 07 col 73 pic 99 using const-mm-curr.        
    05		line 07 col 75 value "/". 
    05		line 07 col 76 pic 99 using const-dd-curr.        
    05		line 08 col 40 value is "assistants". 
    05 		line 08 col 71 pic z9.99 using const-asst-h-curr.    
    05		line 09 col 40 value is "cert.anaesthetists". 
    05		line 09 col 71 pic z9.99 using const-cert-h-curr. 
    05		line 10 col 40 value is "reg. anaesthetists". 
    05		line 10 col 68 pic z(4)9.99 using const-reg-h-curr. 
    05		line 12 col 01 value "number of records on ohip tape:". 
    05  scr-ohip-reads line 12 col 40 pic z(7) using ws-expected-ohip-reads auto required. 
 
 
01  program-in-progress. 
    05		    line 18 col 30 value "program u041 in progress". 
    05		    line 19 col 30 value "currently at record". 
    05  scr-rec-nbr line 19 col 58 pic x999 using ohip-code. 
 
01  file-status-display. 
    05		line 24 col 56 "file status = ". 
*mf 05		line 24 col 70 pic x(11) from status-file bell blink. 
    05		line 24 col 70 pic x(02) from status-file bell blink. 
 
01  err-msg-line. 
    05  	line 24 col 01 value " error -  " bell blink. 
    05  	line 24 col 11 pic x(60) from err-msg-comment. 
 
 
01  enter-bypass-codes. 
    05		line 15 col 01 value is "enter up to 10 codes for which the new ohip rates will be bypassed:". 
    05 scr-code line 15 col 72 pic x(4) using sel-code auto.  
    05		line 16 col 01 value is "(enter '*' to complete input)". 
 
01  bypass-codes-display. 
    05		line 17 col 01 value is "BYPASS CODES ARE:". 
    05		line 17 col 19 pic x(4) using bypass-code-1. 
    05		line 17 col 24 pic x(4) using bypass-code-2. 
    05		line 17 col 29 pic x(4) using bypass-code-3. 
    05  	line 17 col 34 pic x(4) using bypass-code-4. 
    05		line 17 col 39 pic x(4) using bypass-code-5. 
    05		line 17 col 44 pic x(4) using bypass-code-6. 
    05		line 17 col 49 pic x(4) using bypass-code-7. 
    05		line 17 col 54 pic x(4) using bypass-code-8. 
    05		line 17 col 59 pic x(4) using bypass-code-9. 
    05		line 17 col 64 pic x(4) using bypass-code-10. 
 
01  confirm. 
    05		line 23 col 01 value is " ". 
 
01  blank-screen. 
    05  blank screen. 
 
01  blank-line-24. 
    05		line 24 col 01 blank line. 
 
01  closing-screen.                
    05  line 14 col 20  value "NEW OHIP RATES IMPLEMENTED = ". 
    05  line 14 col 55  pic 9(7) from ctr-rates-implemented.   
    05  line 15 col 20  value "NEW OHIP RATES NOT IMPLEMENTED = ". 
    05  line 15 col 55  pic 9(7) from ctr-nbr-errors.            
    05  line 18 col 20 pic x(30) using print-file-1. 
    05  line 19 col 20 pic x(30) using print-file-2.   
    05  line 21 col 20	value "PROGRAM U041 ENDING". 
* (y2k - auto fix)
*   05  line 21 col 40  pic 99/99/99 from sys-date-long. 
    05  line 21 col 40  pic 9999/99/99 from sys-date-long. 
    05  line 21 col 52	pic 99	from sys-hrs. 
    05  line 21 col 54	value ":". 
    05  line 21 col 55	pic 99	from sys-min.        
 
01  verify-display. 
    05  		line 22 col 40 value is "ACCEPT (Y/N) ". 
    05 scr-verify	line 22 col 53 pic x using verify-flag required.  
 
01  reverify-display. 
    05		line 23 col 40 value is "CONTINUE PROCESSING (Y/N)  ". 
    05 scr-reverify	line 23 col 65 pic x using reverify-flag required. 
procedure division. 
 
declaratives. 
 
err-iconst-mstr-file section. 
    use after standard error procedure on iconst-mstr. 
err-iconst-mstr. 
    display blank-line-24. 
    stop "ERROR IN ACCESSING ICONST MASTER". 
*mf    move status-iconst-mstr		to	status-file. 
    move status-cobol-iconst-mstr	to	status-file. 
    display file-status-display. 
    stop run. 
 
err-ohip-tape-file section. 
    use after standard error procedure on ohip-benefit-sched-tape. 
err-ohip-benefit-sched-tape. 
    display blank-line-24. 
    stop "ERROR IN ACCESSING OHIP RATE TAPE FILE". 
*mf    move status-ohip-file		to	status-file. 
    move status-cobol-ohip-file		to	status-file. 
    display file-status-display. 
    stop run. 
 
err-oma-fee-mstr-file section. 
    use after standard error procedure on oma-fee-mstr. 
err-oma-fee-mstr. 
    display blank-line-24. 
    stop "ERROR IN ACCESSING OMA FEE MASTER". 
*mf    move status-oma-mstr		to	status-file. 
    move status-cobol-oma-mstr		to	status-file. 
    display file-status-display. 
    stop run. 
 
end declaratives. 
main-line section. 
mainline. 
 
    perform aa0-initialization		thru aa0-99-exit. 
    perform ab0-processing		thru ab0-99-exit. 
    perform az0-end-of-job		thru az0-99-exit. 
* 
    stop run. 
aa0-initialization. 
   
    accept sys-date			from	date. 
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to	run-mm.                
    move sys-dd				to 	run-dd. 
    move sys-yy				to	run-yy. 
    move run-date			to	h1-run-date 
						h2-run-date. 
     
    accept sys-time			from	time. 
    move sys-hrs			to	run-hrs. 
    move sys-min			to	run-min. 
    move sys-sec			to	run-sec. 
 
    move 0				to	counters  
						ws-units-table. 
    move 90				to	ctr-h1-lines 
						ctr-h2-lines. 
    move spaces				to	t4-code-section (1) 
					  	t4-code-section (2) 
					  	t4-code-section (3) 
					  	t4-code-section (4) 
					  	t4-code-section (5) 
					  	t4-code-section (6) 
					  	t4-code-section (7) 
					  	t4-code-section (8) 
					  	t4-code-section (9) 
					  	t4-code-section (10)  
						h1-detail-line 
						h2-detail-line. 
    subtract 2				from	sys-yy 
					giving	ws-2-yrs-ago. 
 
 
    open input	iconst-mstr. 
    move 2				to	iconst-clinic-nbr-1-2. 
    read iconst-mstr 
	invalid key 
	    move 2			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to az0-end-of-job. 
 
    close iconst-mstr. 
 
    move const-yy-curr     		to	h1-const-yr. 
    move const-mm-curr      		to	h1-const-mth. 
    move const-dd-curr      		to	h1-const-day. 
    move const-asst-h-curr  		to	h1-asst-rate. 
    move const-reg-h-curr        	to	h1-reg-rate. 
    move const-cert-h-curr        	to	h1-cert-rate. 
 
    display scr-title. 
 
aa0-100-nbr-ohip-recs. 
 
    display rates-message. 
    accept scr-ohip-reads. 
    if ws-expected-ohip-reads not > 0 
    then 
	move 0				to	ws-expected-ohip-reads 
	go to aa0-100-nbr-ohip-recs. 
*   (else) 
*   endif 
 
    perform aa1-accept-bypass-codes	thru	aa1-99-exit 
	    varying ss-bypass-count	 
	    from 1 
	    by   1 
	    until   ss-bypass-count > 10 
		 or sel-code-ltr = "*". 
 
    move " "				to	verify-flag 
						reverify-flag. 
 
 
aa0-200-accept-display. 
 
    display verify-display. 
    accept scr-verify. 
    if verify-ok        
    or verify-not-ok   
    then 
	next sentence 
    else 
        move 1			to	err-ind 
	perform za0-common-error thru   za0-99-exit 
	go to aa0-200-accept-display. 
*   endif 
 
aa0-200-reverify-display. 
 
    if verify-not-ok 
    then 
	display reverify-display 
	accept scr-reverify 
	if reverify-not-ok 
	then 
	    stop run       
	else 
	    if reverify-ok    
	    then 
		next sentence 
	    else 
		go to aa0-200-reverify-display. 
*	    endif 
*	endif 
*   endif 
 
 
    move spaces				to	ohip-code. 
    display program-in-progress. 
 
*	delete audit-file 
*    expunge audit-file. 
*    expunge error-file. 
 
    open input  ohip-benefit-sched-tape. 
    open i-o    oma-fee-mstr. 
    open output audit-file. 
    open output error-file. 
 
    move "N"				to	ohip-flag 
						oma-flag. 
    move "Y"				to	fees-valid-flag. 
 
    perform fa0-read-ohip		thru	fa0-99-exit. 
    perform ha0-read-oma		thru	ha0-99-exit. 
 
aa0-99-exit. 
    exit. 
 
 
aa1-accept-bypass-codes. 
 
*   extra paragraph title required since this routine called by 
*   a "PERFORM UNTIL" 
 
 
aa1-100-edit-loop. 
 
    move 0				to	err-ind. 
    move " "				to	sel-code. 
    display enter-bypass-codes. 
    accept scr-code. 
    if sel-code-ltr = "*" 
    then 
	go to aa1-99-exit. 
*   (else) 
*   endif 
 
    if sel-code-ltr numeric 
    or sel-code-ltr = " " 
    then 
	move 1 				to	err-ind 
	perform za0-common-error	thru	za0-99-exit 
	go to aa1-100-edit-loop        
    else 
	if sel-code-nbr = " "       
	or sel-code-nbr not numeric 
	then 
	    move 14			to	err-ind 
	    perform za0-common-error	thru	za0-99-exit 
	    go to aa1-100-edit-loop        
	else 
	    next sentence. 
*	endif 
*   endif 
 
        move sel-code			to	bypass-code (ss-bypass-count). 
        display bypass-codes-display. 
 
aa1-99-exit. 
    exit. 
 
az0-end-of-job. 
 
    display blank-screen. 
    perform az1-end-totals		thru	az1-99-exit. 
    perform zb0-dump-file-rec-cntrs	thru 	zb0-99-exit. 
 
    close oma-fee-mstr 
	  error-file 
	  ohip-benefit-sched-tape 
	  audit-file. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
 
 
az1-end-totals. 
 
    add 4				to	ctr-h1-lines       
						ctr-h2-lines. 
    perform ra0-check-audit-lines	thru	ra0-99-exit. 
    perform da0-check-error-lines	thru	da0-99-exit. 
 
    move ctr-rates-implemented		to	t1-rates-implemented. 
    move ctr-no-rma-code		to	t1-no-rma-code. 
    move ctr-nbr-errors			to	t1-nbr-errors. 
    write audit-rec from t1-total-line	after	2 lines. 
    write error-rec from t1-total-line	after	2 lines. 
    move spaces				to	t1-total-line. 
 
    move ctr-no-ohip-rate           	to	t2-no-ohip-rate. 
    move ws-2-yrs-ago			to	t2-2-yrs-ago. 
    move ctr-old-terminations		to	t2-old-terminations. 
    move ctr-zero-fees			to	t2-zero-fees. 
    write audit-rec from t2-total-line	after	2 lines. 
    write error-rec from t2-total-line	after	2 lines. 
    move spaces				to	t2-total-line. 
 
    move ws-expected-ohip-reads		to	t3-expected-ohip. 
    move ctr-actual-ohip-reads		to	t3-actual-ohip. 
    subtract ctr-actual-ohip-reads	from	ws-expected-ohip-reads. 
    move ws-expected-ohip-reads		to	t3-difference. 
    write audit-rec from t3-total-line	after 	3 lines. 
    write error-rec from t3-total-line  after   3 lines. 
    move spaces				to	t3-total-line. 
 
    perform az2-bypass-codes		thru	az2-99-exit 
	    varying ss-bypass-count 
	    	    from 1 by 1 
	    until   ss-bypass-count > 10. 
    write audit-rec from t4-total-line  after 	2 lines. 
    write error-rec from t4-total-line	after 	2 lines. 
    move spaces				to	t4-total-line. 
 
az1-99-exit. 
    exit. 
 
az2-bypass-codes. 
 
    move bypass-code (ss-bypass-count)	to	t4-code (ss-bypass-count). 
 
az2-99-exit. 
    exit. 
 
ab0-processing. 
 
    if ohip-eof              
    then 
	if oma-eof               
	then 
	    go to ab0-99-exit 
	else	 
	    perform ab1-no-ohip-rate	thru	ab1-99-exit 
	    perform ha0-read-oma	thru	ha0-99-exit 
	    move 0			to	err-ind 
	    go to ab0-processing 
    else 
	if oma-eof                      
	then 
	    perform ab2-new-code	thru	ab2-99-exit 
	    perform fa0-read-ohip	thru	fa0-99-exit 
            move 0			to	err-ind 
	    go to ab0-processing 
	else	 
	    next sentence. 
*	endif 
*   endif 
 
    if ohip-code = fee-oma-cd 
    then 
	next sentence 
    else 
	if ohip-code > fee-oma-cd 
	then 
	    perform ab1-no-ohip-rate	thru	ab1-99-exit 
	    perform ha0-read-oma	thru	ha0-99-exit 
	    go to ab0-processing 
	else 
            perform ab2-new-code	thru	ab2-99-exit 
	    perform fa0-read-ohip	thru	fa0-99-exit 
	    go to ab0-processing. 
*       endif 
*   endif 
 
    move "N"				to	oma-code-type-check. 
    perform va0-skip-rec-types		thru	va0-99-exit. 
    if skip-oma 
    then 
	perform pa0-print-error		thru	pa0-99-exit 
	go to ab0-100-next-code. 
*   (else) 
*   endif 
 
    move "N"				to	bypass-check. 
    perform ta0-check-for-bypass	thru	ta0-99-exit 
	varying	ss-bypass-count 
		from 1	by 1 
	until	ss-bypass-count > 10 
	    or	bypass. 
 
    if bypass 
    then 
	move 8				to	err-ind 
	perform pa0-print-error		thru	pa0-99-exit 
	go to ab0-100-next-code. 
*   (else) 
*   endif 
 
    if ohip-termination-date < sys-date-long-r 
    then 
	if ohip-termination-yr < ws-2-yrs-ago 
	then 
	    add 1			to	ctr-old-terminations 
	    go to ab0-100-next-code 
	else 
	    move 14			to	err-ind 
	    perform pa0-print-error	thru	pa0-99-exit 
	    go to ab0-100-next-code 
*   	endif 
    else 
	next sentence. 
*   endif 
 
 
    if     ohip-fees (ss-tape-gp)       = zero 
       and ohip-fees (ss-tape-asst)     = zero 
       and ohip-fees (ss-tape-spec)     = zero 
       and ohip-fees (ss-tape-anae)     = zero 
       and ohip-fees (ss-tape-non-anae) = zero 
    then 
	add 1				to	ctr-zero-fees 
	go to ab0-100-next-code. 
*   (else) 
*   endif 

*   (2001/apr/23 -B.E. - constants master no longer used as effective
*			 date for fees - this date is stored within the
*			 f040 record 

     move ohip-effective-date	to fee-effective-date.

*    if ohip-effective-date = const-effective-date-curr 
*    then 
*        next sentence 
*    else 
*        move 7				to	err-ind 
*	perform pa0-print-error		thru	pa0-99-exit 
*        go to ab0-100-next-code. 
*   endif 
 
    if fee-icc-sec =    "CP"   
		     or "CV" 
		     or "DT" 
		     or "DU" 
		     or "NM" 
		     or "PF" 
		     or "SP" 
* 2012/05/17 - MC1 - include DR group
		     or "DR"
* 2012/05/17 - end
    then 
        next sentence 
    else 
        move 18				to	err-ind 
	perform pa0-print-error		thru	pa0-99-exit 
        go to ab0-100-next-code. 
*   endif 
 
    if fee-icc-sec = "CP" 
    then 
	perform ja0-validate-cp		thru	ja0-99-exit 
    else 
	if fee-icc-sec = "CV" 
	then 
	    perform jb0-validate-cv	thru	jb0-99-exit 
	else 
	    if fee-icc-sec = "DT" 
	    then 
		perform jc0-validate-dt thru	jc0-99-exit 
	    else 
* 2012/05/17 - MC1 - include DR group
		if fee-icc-sec =  "DR"
		then 
		    perform jd0-validate-dr   thru jd0-99-exit 
* 2012/05/17 - end
		else
		    if fee-icc-sec =   "DU" 
				    or "NM"    
				    or "PF"    
		    then 
			perform je0-validate-du-nm-pf thru je0-99-exit 
		    else 
		  	perform jf0-validate-sp thru jf0-99-exit. 
*		   endif 
*		endif 
*	   endif 
*    endif 
 
    if fees-not-valid 
    then 
	perform pa0-print-error		thru	pa0-99-exit 
	go to ab0-100-next-code. 
*   (else) 
*   endif 
 
    perform ba0-print-audit           	thru	ba0-99-exit. 
 
    perform na0-rewrite-record		thru	na0-99-exit. 
 
 
ab0-100-next-code. 
 
    move "Y"				to	fees-valid-flag. 
    perform fa0-read-ohip		thru	fa0-99-exit. 
    perform ha0-read-oma		thru	ha0-99-exit. 
    go to ab0-processing. 
 
ab0-99-exit. 
    exit. 
ab1-no-ohip-rate. 
 
    add 1				to	ctr-no-ohip-rate. 
    move 9				to	err-ind. 
    perform pa0-print-error		thru	pa0-99-exit. 
 
ab1-99-exit. 
    exit. 
ab2-new-code. 
 
    if ohip-termination-date < sys-date-long-r 
    then 
	add 1				to	ctr-old-terminations 
    else 
	if     ohip-fees (ss-tape-gp)       = zero 
	   and ohip-fees (ss-tape-asst)     = zero 
	   and ohip-fees (ss-tape-spec)     = zero 
	   and ohip-fees (ss-tape-anae)     = zero 
	   and ohip-fees (ss-tape-non-anae) = zero 
	then 
	    add 1			to	ctr-zero-fees 
	    move 20			to	err-ind   
	    perform pa0-print-error	thru	pa0-99-exit  
	else 
	    add 1			to	ctr-no-rma-code 
	    move 6			to	err-ind   
	    perform pa0-print-error	thru	pa0-99-exit. 
*	endif 
*   endif 
 
ab2-99-exit. 
    exit. 
ba0-print-audit.                  
 
    perform ra0-check-audit-lines	thru	ra0-99-exit. 
    move ohip-code			to	h1-code-nbr.    
    move fee-icc-sec			to	h1-icc-code.   
    move ohip-effective-yr		to	h1-effective-yr. 
    move ohip-effective-mth		to	h1-effective-mth. 
    move ohip-effective-day		to	h1-effective-day. 
    move "/"				to	h1-slash1 
						h1-slash2. 
 
*   (print 'STARS' to highlite code for which there is no fee increase) 
    if 	    fee-curr-h-fee-1 = fee-prev-h-fee-1 
	and fee-curr-h-asst  = fee-prev-h-asst 
	and fee-curr-h-fee-2 = fee-prev-h-fee-2 
	and fee-curr-h-anae  = fee-prev-h-anae 
    then 
	move "****"			to	h1-rates-same. 
*   (else) 
*   endif 
 
    write audit-rec from h1-detail-line	after	2 lines. 
    move spaces				to	h1-detail-line. 
 
    add 1				to	ctr-rates-implemented. 
 
ba0-99-exit. 
    exit. 
da0-check-error-lines. 
 
    add 1					to	ctr-h2-lines. 
    if ctr-h2-lines > 27 
    then 
	add 1					to	ctr-h2-page 
 	move ctr-h2-page			to	h2-page-nbr 
	move zero				to	ctr-h2-lines 
	write error-rec from h2-head		after	page     
	write error-rec from h1-title-1		after	1 line 
	write error-rec from h2-title-1		after	2 lines 
	write error-rec from h2-title-2		after	1 line. 
*   (else) 
*   endif 
 
da0-99-exit. 
    exit. 
fa0-read-ohip. 
 
    move zero				to	ws-units-table.  
 
    read ohip-benefit-sched-tape next 
	at end       
	    move "Y"			to	ohip-flag  
	    go to fa0-99-exit. 
 
    add 1				to	ctr-actual-ohip-reads. 
 
*	(see note #1 on first page of program as to correlation of 'GP' vs 'SPECIALIST' rates) 
    if    ohip-fees (ss-tape-gp)   not = zero 
      and ohip-fees (ss-tape-spec)     = zero 
    then 
	move ohip-fees (ss-tape-gp)		to	ohip-fees (ss-tape-spec). 
*   (else) 
*   endif 
 
*   (display every 100th tape rec processed) 
    divide	ctr-actual-ohip-reads	by	100 
					giving	ws-rec-nbr 
					remainder ws-rec-rem. 
    if ws-rec-rem = zero 
    then 
	display scr-rec-nbr. 
*   (else) 
*   endif 
 
fa0-99-exit. 
    exit. 
ha0-read-oma. 
 
    read oma-fee-mstr next 
   	at end 
	    move "Y"			to	oma-flag     
	    go to ha0-99-exit. 
    add 1				to	ctr-oma-reads. 
 
ha0-99-exit. 
    exit. 
ja0-validate-cp. 
 
    perform wb0-check-gp-spec		thru	wb0-99-exit. 
    if fees-not-valid 
    then 
	go to ja0-99-exit. 
*   (else) 
*   endif 
 
    perform wc0-check-anae		thru	wc0-99-exit. 
    if fees-not-valid 
    then 
	go to ja0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-spec			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to ja0-99-exit. 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-spec) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to ja0-99-exit. 
*   (else) 
*   endif 
 
    move zero				to	fee-curr-h-fee-2 
						fee-curr-h-asst. 
 
    move fee-curr-h-fee-1		to	h1-old-rate-1. 
    move ohip-fees (ss-tape-spec)	to	h1-new-rate-1 
						fee-curr-h-fee-1  
 
    if ws-anae-units not = zero 
    then 
	move fee-curr-h-anae		to	h1-old-rate-4 
	move ws-anae-units		to	h1-new-rate-4 
						fee-curr-h-anae  
    else 
	if fee-curr-h-anae = zero 
	then 
	    next sentence 
	else 
	    move fee-curr-h-anae	to	h1-old-rate-4 
	    move zero			to	h1-new-rate-4 
						fee-curr-h-anae. 
*	endif 
*   endif 
 
ja0-99-exit. 
    exit. 
jb0-validate-cv. 
 
    perform wb0-check-gp-spec		thru	wb0-99-exit. 
    if fees-not-valid 
    then 
	go to jb0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-spec			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to jb0-99-exit. 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-spec) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to jb0-99-exit. 
*   (else) 
*   endif 
 
    move zero				to	fee-curr-h-fee-2 
						fee-curr-h-asst 
						fee-curr-h-anae. 
 
    move fee-curr-h-fee-1		to	h1-old-rate-2. 
    move ohip-fees (ss-tape-spec)	to	h1-new-rate-2 
						fee-curr-h-fee-1. 
 
jb0-99-exit. 
    exit. 
jc0-validate-dt. 
 
    perform wb0-check-gp-spec		thru	wb0-99-exit. 
    if fees-not-valid 
    then 
	go to jc0-99-exit. 
*   (else) 
*   endif 
 
    perform wc0-check-anae		thru	wc0-99-exit. 
    if fees-not-valid 
    then 
	go to jc0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-spec			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to jc0-99-exit. 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-spec) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to jc0-99-exit. 
*   (else) 
*   endif 
 
    move zero				to	fee-curr-h-asst. 
 
    move fee-curr-h-fee-1		to	h1-old-rate-2. 
    move ohip-fees (ss-tape-spec)	to	h1-new-rate-2 
						fee-curr-h-fee-1. 
 
    if ws-anae-units not = zero 
    then 
	move fee-curr-h-anae		to	h1-old-rate-4 
	move ws-anae-units		to	h1-new-rate-4 
						fee-curr-h-anae 
    else 
	if fee-curr-h-anae = zero 
 	then 
	    next sentence 
	else 
	    move fee-curr-h-anae	to	h1-old-rate-4 
	    move zero			to	h1-new-rate-4 
						fee-curr-h-anae. 
*	endif 
*   endif 
 
jc0-99-exit. 
    exit. 

* 2012/05/23 - MC2
jd0-validate-dr. 
 
    move ss-tape-asst			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to jd0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-anae			to	ss-rate-count. 
    if  ohip-fees (ss-tape-anae) not = zero
    then 
	next sentence
    else
        if ohip-fees (ss-tape-non-anae) not = zero
        then 
	    move ohip-fees (ss-tape-non-anae) 	to ohip-fees (ss-tape-anae).
*	endif
*   endif
    
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to jd0-99-exit. 
*   endif 
 
    if    ohip-fees (ss-tape-asst) = zero 
      or  ohip-fees (ss-tape-anae) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to jd0-99-exit. 
*   endif 
 
    move zero				to	fee-curr-h-asst 
						fee-curr-h-anae. 
 
    move fee-curr-h-fee-1		to	h1-old-rate-1. 
    move ohip-fees (ss-tape-asst)	to	h1-new-rate-1 
						fee-curr-h-fee-1. 
    move fee-curr-h-fee-2		to	h1-old-rate-2. 
    move ohip-fees (ss-tape-anae)	to	h1-new-rate-2 
						fee-curr-h-fee-2. 
 
jd0-99-exit. 
    exit. 
* 2012/05/23 - end

je0-validate-du-nm-pf. 
 
    move ss-tape-asst			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to je0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-anae			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to je0-99-exit. 
*   (else) 
*   endif 
 
    if   ohip-fees (ss-tape-asst) = zero 
      or ohip-fees (ss-tape-anae) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to je0-99-exit. 
*   (else) 
*   endif 
 
    move zero				to	fee-curr-h-asst 
						fee-curr-h-anae. 
 
    move fee-curr-h-fee-1		to	h1-old-rate-1. 
    move ohip-fees (ss-tape-asst)	to	h1-new-rate-1 
						fee-curr-h-fee-1. 
    move fee-curr-h-fee-2		to	h1-old-rate-2. 
    move ohip-fees (ss-tape-anae)	to	h1-new-rate-2 
						fee-curr-h-fee-2. 
 
je0-99-exit. 
    exit. 
jf0-validate-sp. 
 
    perform wb0-check-gp-spec		thru	wb0-99-exit. 
    if fees-not-valid 
    then 
	go to jf0-99-exit. 
*   (else) 
*   endif 
 
    move ss-tape-spec			to	ss-rate-count. 
    perform wa0-check-range		thru	wa0-99-exit. 
    if fees-not-valid 
    then 
	go to jf0-99-exit. 
*   (else) 
*   endif 
 
    perform wd0-check-asst		thru	wd0-99-exit. 
    if fees-not-valid 
    then 
	go to jf0-99-exit. 
*   (else) 
*   endif 
 
    perform wc0-check-anae		thru	wc0-99-exit. 
    if fees-not-valid 
    then 
	go to jf0-99-exit. 
*   (else) 
*   endif 
 
    if    ws-asst-units            = zero 
      and ws-anae-units            = zero 
      and ohip-fees (ss-tape-spec) = zero 
    then 
	move 19				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to jf0-99-exit. 
*   (else) 
*   endif 
 
    move zero				to	fee-curr-h-fee-2. 
 
    move fee-curr-h-asst		to	h1-old-rate-3. 
    move ws-asst-units			to	h1-new-rate-3 
						fee-curr-h-asst. 
 
    if ohip-fees (ss-tape-spec) not = zero 
    then 
	move fee-curr-h-fee-1		to	h1-old-rate-2 
	move ohip-fees (ss-tape-spec)	to	h1-new-rate-2 
						fee-curr-h-fee-1  
    else 
	if fee-curr-h-fee-1 = zero 
	then 
	    next sentence 
	else 
	    move fee-curr-h-fee-1	to	h1-old-rate-2 
	    move zero			to	h1-new-rate-2 
						fee-curr-h-fee-1. 
*   	endif 
*   endif 
 
    if ws-anae-units not = zero 
    then 
	move fee-curr-h-anae		to	h1-old-rate-4 
	move ws-anae-units		to	h1-new-rate-4 
						fee-curr-h-anae  
   else 
	if fee-curr-h-anae = zero 
	then 
	    next sentence 
	else 
	    move fee-curr-h-anae	to	h1-old-rate-4 
	    move zero			to	h1-new-rate-4 
						fee-curr-h-anae. 
*	endif 
*   endif 
 
jf0-99-exit. 
    exit. 
na0-rewrite-record. 
 
******************************************************************************** 
******************************************************************************** 
* 
****ohip fees & oma fees are always identical as of april/82**** 
* 
******************************************************************************** 
******************************************************************************** 
* MC3
*    move fee-curr-h-fee-1		to	fee-curr-a-fee-1. 
*    move fee-curr-h-fee-2		to	fee-curr-a-fee-2. 
     compute fee-curr-a-fee-1 = fee-curr-h-fee-1 * 2.13.
     compute fee-curr-a-fee-2 = fee-curr-h-fee-2 * 2.13.
* MC3 - end
    move fee-curr-h-asst		to	fee-curr-a-asst. 
    move fee-curr-h-anae		to	fee-curr-a-anae. 
******************************************************************************** 
******************************************************************************** 
* 
****ohip fees & oma fees are always identical as of april/82**** 
* 
******************************************************************************** 
******************************************************************************** 
    rewrite fee-mstr-rec. 
 
na0-99-exit. 
    exit. 
pa0-print-error. 
 
    if err-ind = 6 
    then 
	add 1				to	ctr-h2-lines. 
*   (else) 
*   endif 
 
    perform da0-check-error-lines	thru	da0-99-exit. 
    move err-msg (err-ind)		to	h2-reason. 
 
    if err-ind = 9   
    then 
	move fee-oma-cd			to	h2-code 
	go to pa0-100-print-line. 
*   (else) 
*   endif 
 
    if fees-not-valid 
    then 
	if ss-rate-count = ss-tape-asst 
	then 
	    move "*"			to	h2-err-ind (3) 
	else 
	    if ss-rate-count = ss-tape-spec 
	    then 
		move "*"		to	h2-err-ind (2) 
	    else 
		move "*"		to	h2-err-ind (ss-rate-count). 
*	    endif 
*	endif 
*   (else) 
*   endif 
 
    move ohip-code			to	h2-code. 
 
    if err-ind not = 6 
    then 
	move fee-icc-sec		to	h2-icc-code. 
*   (else) 
*   endif 
 
    move ohip-effective-yr		to	h2-effective-yr. 
    move ohip-effective-mth		to	h2-effective-mth. 
    move ohip-effective-day		to	h2-effective-day. 
    move "/"				to	h2-slash1 
						h2-slash2. 
    move err-msg (err-ind)		to	h2-reason. 
* (y2k)
*    if ohip-termination-date not = 999999 
    if ohip-termination-date not = 99999999 
    then 
	move ohip-termination-yr	to	h2-termination-yr 
	move ohip-termination-mth	to	h2-termination-mth 
	move ohip-termination-day	to	h2-termination-day 
	move "/"			to	h2-slash3 
						h2-slash4. 
*   (else) 
*   endif 
 
     
    if ohip-fees (ss-tape-gp) not = zero 
    then 
	move ohip-fees (ss-tape-gp)	to	h2-new-rate (1). 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-asst) not = zero 
    then 
	move ohip-fees (ss-tape-asst)	to	h2-new-rate (3). 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-spec) not = zero 
    then 
	move ohip-fees (ss-tape-spec)	to	h2-new-rate (2). 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-anae) not = zero 
    then 
	move ohip-fees (ss-tape-anae)	to	h2-new-rate (4). 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-non-anae) not = zero 
    then 
	move ohip-fees (ss-tape-non-anae) 
					to	h2-new-rate (5). 
*   (else) 
*   endif 
 
 
pa0-100-print-line. 
 
    write error-rec from blank-line	after	1 line. 
 
*   (highlight new code) 
    if err-ind = 6 
    then 
	write error-rec from h2-stars	after	1 line 
	write error-rec from h2-detail-line 
					after 1 line 
	write error-rec from h2-stars	after	1 line 
    else 
	write error-rec from h2-detail-line after 1 line. 
*   endif 
 
    move spaces				to	h2-detail-line. 
    move 0				to	err-ind. 
    add 1				to	ctr-nbr-errors. 
 
pa0-99-exit. 
    exit. 
ra0-check-audit-lines. 
 
    add 1				to	ctr-h1-lines. 
    if ctr-h1-lines > 27 
    then 
	add 1				to	ctr-h1-page 
	move ctr-h1-page		to	h1-page-nbr	 
	move zero			to	ctr-h1-lines 
	write audit-rec from h1-head	after	page     
	write audit-rec from h1-title-1 after	1 line 
	write audit-rec from h1-title-2 after	2 lines 
	write audit-rec from h1-title-3	after	1 line. 
*   (else) 
*   endif 
 
ra0-99-exit. 
    exit. 
ta0-check-for-bypass. 
 
    if ohip-code = bypass-code (ss-bypass-count) 
    then 
	move "Y"			to	bypass-check. 
*   (else) 
*   endif 
 
ta0-99-exit. 
    exit. 
va0-skip-rec-types. 
 
*   (skip if percentage add-on code or diagnostic radiation code) 
 
    if fee-curr-add-on-perc-flat-ind =   "P" 
				    	 or "B" 
    then 
	move "Y"			to	oma-code-type-check 
	move 11				to	err-ind 
    else 
* 2012/05/14 - MC1  - do not skip for diagnostic radiation code 
*   if fee-icc-sec = "DR" 
*	then 
*  	    move "Y"			to	oma-code-type-check 
*	    move 12			to	err-ind 
*	else 
* 2012/05/14 - end
	    next sentence. 
*	endif 
*   endif 
 
va0-99-exit. 
    exit. 
wa0-check-range. 
 
    if ohip-fees (ss-rate-count) =   zero 
                                  or ws-anae-asst-bypass-ind 
    then 
	go to wa0-99-exit. 
*   (else) 
*   endif 
 
*   ohip tape has 4 decimal places, fee master has 2;VERIFY THAT 
*   3rd & 4th decimals = 0 and that ohip rate not > fee master max. 
 
    multiply ohip-fees (ss-rate-count) 	by 	10000 
					giving	temp-1.               
    if temp-1 not = zero 
    then 
	move 17				to	err-ind 
	move "N" 	 		to	fees-valid-flag.        
*   (else) 
*   endif 
 
    if ohip-fees (ss-rate-count) > 99999.99 
    then 
	move 16				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to ja0-99-exit. 
*   (else) 
*   endif 
 
wa0-99-exit. 
    exit. 
wb0-check-gp-spec. 
 
*	(this rtn checks that if both 'GP' and 'SPECIALIST' rates are given 
*	 that they are equal to each other or equal to 'BYPASS VALUE') 
 
    move 1				to	ss-rate-count. 
 
    if ohip-fees (ss-tape-gp)   = zero 
			    or = ws-anae-asst-bypass-ind 
    then 
	next sentence 
    else 
	if ohip-fees (ss-tape-spec)   = zero 
				   or = ws-anae-asst-bypass-ind 
	then 
	    next sentence 
	else 
	    if ohip-fees (ss-tape-gp) not = ohip-fees (ss-tape-spec) 
	    then 
		move 15			to	err-ind          
		move "N"		to	fees-valid-flag. 
*	    endif 
*	endif 
*    endif 
 
wb0-99-exit. 
    exit. 
wc0-check-anae. 
 
    move ss-tape-anae			to	ss-rate-count. 
 
    if    ohip-fees (ss-tape-anae    ) = zero 
      and ohip-fees (ss-tape-non-anae) = zero 
    then 
	go to wc0-99-exit. 
*   (else) 
*   endif 
 
*	(if bypass required, then set new 'UNITS' = current 'UNITS' so 
*	 they won'T CHANGE FILE's values) 
    if   ( ohip-fees (ss-tape-anae    ) = ws-anae-asst-bypass-ind ) 
      or ( ohip-fees (ss-tape-non-anae) = ws-anae-asst-bypass-ind ) 
    then 
	move fee-curr-h-anae		to	ws-anae-units 
	go to wc0-99-exit. 
*   (else) 
*   endif 
 
    divide ohip-fees (ss-tape-anae    )	by	const-cert-h-curr 
					giving	ws-anae-units 
					remainder ws-anae-rem. 
 
    divide ohip-fees (ss-tape-non-anae)	by	const-reg-h-curr 
					giving	ws-non-anae-units 
					remainder ws-non-anae-rem. 
 
    if    ws-anae-units   = ws-non-anae-units 
      and ws-anae-rem     = zero 
      and ws-non-anae-rem = zero 
    then 
	go to wc0-99-exit. 
*   (else) 
*   endif 
 
    if ohip-fees (ss-tape-anae) = ohip-fees (ss-tape-non-anae) 
    then 
	if ws-anae-rem = zero 
	then 
	    next sentence 
	else 
	    if ws-non-anae-rem = zero  
	    then 
		move ws-non-anae-units	to	ws-anae-units 
	    else 
	 	move 10			to	err-ind 
	  	move "N"		to	fees-valid-flag 
		go to wc0-99-exit 
    else 
	move 13				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to wc0-99-exit. 
*   endif 
 
    if ws-anae-units > 99 
    then 
	move 16				to	err-ind 
	move "N"			to	fees-valid-flag. 
 
wc0-99-exit. 
    exit. 
wd0-check-asst. 
 
    move ss-tape-asst			to	ss-rate-count. 
 
    if ohip-fees (ss-tape-asst) = zero 
    then 
	go to wd0-99-exit. 
*   (else) 
*   endif 
 
*	(if bypass required, then set new 'UNITS' = current 'UNITS' so 
*	 they won'T CHANGE FILE's values) 
    if ohip-fees (ss-tape-asst) = ws-anae-asst-bypass-ind 
    then 
	move fee-curr-h-asst		to	ws-asst-units 
	go to wd0-99-exit. 
*   (else) 
*   endif 
 
*   (verify that assistant units are integer) 
 
    divide ohip-fees (ss-tape-asst)	by	const-asst-h-curr   
					giving	ws-asst-units       
					remainder ws-asst-rem.   
 
    if ws-asst-units > 99 
    then 
	move 16				to	err-ind 
	move "N"			to	fees-valid-flag 
	go to wd0-99-exit. 
*   (else) 
*   endif 
 
    if ws-asst-rem not = zero 
    then 
	move 10				to	err-ind 
	move "N"			to	fees-valid-flag. 
*   (else) 
*   endif 
 
wd0-99-exit. 
    exit. 
za0-common-error. 
 
    move err-msg (err-ind)		to	err-msg-comment. 
    display err-msg-line. 
    display confirm. 
    stop " ". 
    display blank-line-24. 
 
za0-99-exit. 
    exit. 
zb0-dump-file-rec-cntrs. 
 
    display closing-screen. 
 
zb0-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".