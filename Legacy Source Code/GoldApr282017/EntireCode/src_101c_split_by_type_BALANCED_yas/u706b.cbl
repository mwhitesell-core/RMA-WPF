identification division. 
program-id.    u706b. 
author.	       dyad computer systems inc. 
installation.  rma. 
date-written.  90/09/04. 
date-compiled. 
security. 

*  2003/dec/11	M.C.	- alpha doc nbr
* 
environment division. 
input-output section. 
file-control. 
  
    copy "f002_claims_mstr.slr". 
 
select claims-keys 
    assign to       "u706a_claims_keys.sf" 
    organization is sequential 
    access mode  is sequential 
*mf    infos status is status-claims-keys 
    status       is status-cobol-claims-keys. 
 
* 
* 
* 
* 
* 
* 
* 
* 
data division. 
file section. 
  
    copy "f002_claims_mstr.fd". 
* 
fd  claims-keys 
    record contains 36 characters 
    data record is claims-keys-record. 
 
01  claims-keys-record. 
*!  05 b-key	pic x(18). 
*!  05 p-key	pic x(18). 
    05 b-key	pic x(17). 
    05 p-key	pic x(17). 
 
working-storage section. 
 
77  claims-occur				pic 9(12). 
 
*   status file indicators 
*mf 77  common-status-file			pic x(11). 
*mf 77  status-claims-mstr			pic x(11) value zero. 
*mf 77  status-claims-keys			pic x(11) value zero. 
77  feedback-claims-mstr			pic x(4). 
 
77  common-status-file				pic xx. 
77  status-cobol-claims-mstr			pic xx    value zero. 
77  status-cobol-claims-keys			pic xx    value zero. 

*   eof flags 
77  error-flag					pic x   value "N". 
77  eof-claims-mstr				pic x	value "N". 
77  eof-claims-keys				pic x	value "N". 
01  blank-line					pic x(132) value spaces. 
 
*   counters for records read/written for all input/output files 
01  counters. 
    05  ctr-claims-mstr-reads			pic 9(9). 
    05  ctr-nbr-keys-rec-writes			pic 9(9). 
 
copy "sysdatetime.ws". 
 
*mf copy "F002_KEY_CLAIMS_MSTR.WS". 
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
*mf    move status-claims-mstr			to common-status-file. 
    move status-cobol-claims-mstr		to common-status-file. 
    display common-status-file 
    stop run. 
 
err-claims-keys-file section. 
    use after standard error procedure on claims-keys. 
 
err-claims-keys. 
    stop "ERROR IN ACCESSING KEYS FILE". 
*mf    move status-claims-keys			to common-status-file. 
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
 
* (c.e.) write  inverted  claims-mstr-hdr-rec	key is key-claims-mstr 
    move p-key	to	key-claims-mstr. 
 
*mf    write  inverted  claims-mstr-rec		key is key-claims-mstr 
    write  claims-mstr-rec
	invalid key 
            display "ERROR IN WRITE INVERTED - ", key-claims-mstr 
	    stop run. 
 
    add 1				to ctr-nbr-keys-rec-writes. 
 
xa0-99-exit. 
    exit. 
 
ya0-read-keys. 
 
    read claims-keys 
	at end move "Y" to eof-claims-keys. 
 
ya0-99-exit. 
exit. 
 
 
ya1-read-claims-mstr. 
 
    move zero		to	claims-occur 
				feedback-claims-mstr. 
    move b-key		to	key-claims-mstr. 
    read claims-mstr key is key-claims-mstr 
	invalid key 
            stop run. 
 
ya1-99-exit. 
    exit. 
 

    copy "y2k_default_sysdate_century.rtn".
