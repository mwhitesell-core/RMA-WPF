identification division. 
program-id.    u030c. 
author.	       dyad computer systems inc. 
installation.  rma. 
date-written.  91/03/04. 
date-compiled. 
security. 
* 
*mf  remarks. 
 
*  program purpose:  create the claim detail key to the adjusting 
*		     claim detail record 
*		     this is the third pass of u030 
*		 
 
* 91/mar/04 M.C.	- sms 138 
* 98/jul/01 J.C.	- conversion to MF cobol/unix
* 98/nov/12 B.E.	- got run time error 47 on f002. The write invert" write
*			  was leaving the "P" key blank/zero and the max number
*			  of duplicate keys was reached.  Change made to 'dummy"
*			  the P key to "Z" + claim id so no duplicates result.
* 99/mar/5 c.m.		- y2k conversion
* 04/jun/23 M.C.	- alpha doc nbr
 
environment division. 
input-output section. 
file-control. 
  
    copy "f002_claims_mstr.slr". 
 
select claims-keys 
    assign to       "u030_dtl_key.sf" 
    organization is sequential 
    access mode  is sequential 
    status       is status-cobol-claims-keys. 
 
* 
* 
* 
data division. 
file section. 
  
    copy "f002_claims_mstr.fd". 
* 
fd  claims-keys 
*!    record contains 18 characters 
    record contains 17 characters 
    data record is claims-keys-record. 
 
01  claims-keys-record. 
*!    05 b-key	pic x(18). 
    05 b-key	pic x(17).  
 
working-storage section. 
 
77  claims-occur				pic 9(12). 
 
*   status file indicators 
*mf 77  common-status-file			pic x(11). 
77  common-status-file				pic x(2) .
01  status-indicators.
*mf 77  status-cobol-claims-keys		pic xx    value zero. 
    05  status-cobol-claims-keys.
        10  status-cobol-claims-keys1           pic x   value "0".
        10  status-cobol-claims-keys2           pic x   value "0".
    05  status-cobol-claims-keys-bin
                redefines status-cobol-claims-keys pic 9(4) comp.

*mf 77  status-cobol-claims-mstr		pic xx    value zero. 
    05  status-cobol-claims-mstr.
        10  status-cobol-claims-mstr1           pic x   value "0".
        10  status-cobol-claims-mstr2           pic x   value "0".
    05  status-cobol-claims-mstr-bin
                redefines status-cobol-claims-mstr pic 9(4) comp.

    05  status-cobol-display.
        10 status-cobol-display1                pic x.
        10 filler                               pic x(3).
        10 status-cobol-display2                pic 9(4).

77  feedback-claims-mstr			pic x(4). 
 
*   eof flags 
77  error-flag					pic x   value "N". 
77  eof-claims-mstr				pic x	value "N". 
77  eof-claims-keys				pic x	value "N". 
01  blank-line					pic x(132) value spaces. 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-claims-key-reads			pic 9(9). 
    05  ctr-claims-mstr-reads			pic 9(9). 
    05  ctr-nbr-keys-rec-writes			pic 9(9). 
 
copy "sysdatetime.ws". 
 
*mf copy "f002_key_claims_mstr.ws". 
 
copy "f002_claims_mstr_rec1_2.ws". 
 
01  error-message-table. 
 
    05  error-messages. 
	10  filler				pic x(60)   value 
		"CLAIM NOT FOUND". 
procedure division. 
declaratives. 
 
err-claim-header-mstr-file section. 
    use after standard error procedure on claims-mstr. 
 
err-claims-mstr. 
    stop "ERROR IN ACCESSING CLAIMS MASTER". 
*mf move status-cobol-claims-mstr		to common-status-file. 
*mf display common-status-file.
***********************************************************
    move status-cobol-claims-mstr1           to status-cobol-display1.
    if   status-cobol-claims-mstr1 <> 9
    then
        move status-cobol-claims-mstr2       to status-cobol-display2
    else
        move low-values                      to status-cobol-claims-mstr1
        move status-cobol-claims-mstr-bin    to status-cobol-display2.
*   endif

    display "Claims Mstr error = ", status-cobol-display.
************************************************************
    stop run. 
 
err-claims-keys-file section. 
    use after standard error procedure on claims-keys. 
 
err-claims-keys. 
    stop "ERROR IN ACCESSING KEYS FILE". 
    move status-cobol-claims-keys		to common-status-file. 
    display common-status-file 
    stop run. 
 
end declaratives. 
 
mainline section.  
 
    perform aa0-initialization			thru aa0-99-exit. 
    perform ab0-processing			thru ab0-99-exit 
		until	eof-claims-keys	= 'Y'. 
    perform az0-finalization			thru az0-99-exit. 
    stop run. 
aa0-initialization. 
 
    open input 	claims-keys. 
    open i-o	claims-mstr. 
 
    perform ya0-read-keys	thru	ya0-99-exit. 
 
aa0-99-exit. 
    exit. 
ab0-processing. 
 
    perform ya1-read-claims-mstr	thru	ya1-99-exit. 
 
    perform xa0-write-inverted-key	thru	xa0-99-exit. 
 
    perform ya0-read-keys		thru	ya0-99-exit. 
 
ab0-99-exit. 
    exit. 
az0-finalization. 
 
    close claims-mstr 
	  claims-keys. 
 
    stop run. 
 
az0-99-exit. 
    exit. 
xa0-write-inverted-key. 

*mf    move 'B'			to 	key-clm-key-type. 
*mf    move clmdtl-id		to 	key-clm-data. 
    move 'B'			to 	k-clmdtl-b-key-type.
    move clmdtl-id		to 	k-clmdtl-b-data.

*mf (write inverted INFOS technique not allowed in MF cobol/cisam. A 2nd
*mf  database record must be written along with the key to  have this
*mf  adjustment details record appear in sequence of the claim being
*mf  adjusted.  The "B" key is required to sequence the record however
*mf  the "P" key is also needed. Similar to technique in D001(pa0-write-clmdtl)
*mf  the value of the "P" alternative key is set to "Z" plus claim-id(not pat id)
*mf  to write it into the file where it won't affect the integrity of 
*mf  "B"/"P" key sequence of the claims/adjustments)

    move "Z"                            to k-clmdtl-p-key-type. 
    move clmdtl-id	                to k-clmdtl-p-data. 

*mf   write  inverted  claims-mstr-rec		key is key-claims-mstr 
    write claims-mstr-rec from claim-detail-rec
	invalid key 
            display "ERROR IN WRITE INVERTED - ", key-claims-mstr 
	    stop run. 
**************************** added for debugging *************
    move status-cobol-claims-mstr1           to status-cobol-display1.
    if   status-cobol-claims-mstr1 <> 9
    then
        move status-cobol-claims-mstr2       to status-cobol-display2
    else
        move low-values                      to status-cobol-claims-mstr1
        move status-cobol-claims-mstr-bin    to status-cobol-display2.
*   endif

    if status-cobol-claims-mstr1 <> 0
    then
        display "Claims Mstr error = ", status-cobol-display.
*   endif
************************************************************
 
    add 1				to ctr-nbr-keys-rec-writes. 
 
xa0-99-exit. 
    exit. 
 
ya0-read-keys. 
 
    read claims-keys 
	at end move "Y" to eof-claims-keys. 
 
    add 1		to 	ctr-claims-key-reads. 
 
ya0-99-exit. 
   exit. 
 
 
ya1-read-claims-mstr. 
 
    move zero		to	claims-occur 
				feedback-claims-mstr. 
    move b-key		to	key-claims-mstr. 
 
    read claims-mstr into claim-detail-rec 
        key is key-claims-mstr 
	invalid key 
            stop run. 
  
    add 1		to 	ctr-claims-mstr-reads. 
 
 
ya1-99-exit. 
    exit. 
 
