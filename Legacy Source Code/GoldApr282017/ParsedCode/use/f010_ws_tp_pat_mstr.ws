* 1999/nov/22 B.E. y2k - birth date

*  File: f010_ws_tp_pat_mstr.ws
*  Used by: u011.cbl - patient upload of MAC patient file

*  	note:  make sure both f010_tp_pat_mstr.fd and f010_ws_tp_pat_mstr.ws are in sync


* 1999/mar/25 B.E. - no y2k impact unless HOSPITAL CHANGES format
* 1999/nov/22 B.E. - hospital to change birth year from yy to yyyy
* 1999/dec/20 B.E. -TEMP FIX - DEC FILE APPEARS 1 BYTE LONGER ????
* 2000/mar/24 B.E. - split tp-pat-version-cd into individual characters
* 2001/sep/17 B.E. - expaned 'chart number' field from 9 to 15 digits in 
*		     anticipation of changing the current CPI ftp upload
*		     file to the new Meditech file format
*		   - record length went from 160 to 166
* 2002/mar/25 B.E. - finished 2001/sep/17 modification now that Meditech file
*		     file received.
*		   - added 2nd address line 
*		   - record size increase from 166 to 194 for 2nd address line
*		   - renamed  tp-pat-id-no-9-digit to tp-pat-id-no-last-digit
* 2002/mar/28 M.C. - add tp-pat-id-no-r2 and extend phone no from 10 to 20
*		   - record size increase from 194 to 204 for phone no


01 ws-tp-pat-mstr-rec. 
 
    05  ws-tp-pat-func-code                pic xx. 
    05  ws-tp-pat-last-name. 
	10  ws-tp-pat-last-name-6		pic x(6). 
	10  ws-tp-pat-last-name-18		pic x(18). 
    05  ws-tp-pat-first-name. 
	10  ws-tp-pat-first-name-3		pic x(3). 
	10  ws-tp-pat-first-name-21	pic x(21). 
    05  ws-tp-pat-birth-date               pic x(10). 
    05  ws-tp-pat-birth-date-r   redefines ws-tp-pat-birth-date. 
	10  ws-tp-pat-birth-yy             pic 9(4).
        10  ws-tp-pat-birth-yy-r redefines ws-tp-pat-birth-yy.
	    15 ws-tp-pat-birth-yy-first-2  pic 9(2).
	    15 ws-tp-pat-birth-yy-last-2   pic 9(2).
        10  ws-tp-pat-slash1               pic x. 
	10  ws-tp-pat-birth-mm             pic 99. 
        10  ws-tp-pat-slash2               pic x. 
	10  ws-tp-pat-birth-dd             pic 99. 
    05  ws-tp-pat-sex                      pic x. 

*    05  ws-tp-pat-id-no                    pic x(9). 
    05  ws-tp-pat-id-no                    pic x(15). 
    05  ws-tp-pat-id-no-r        redefines ws-tp-pat-id-no. 
	10  ws-tp-pat-id-no-first-8-digits. 
	    15  ws-tp-pat-id-no-site	pic x.
            15  ws-tp-pat-id-no-yy         pic 99. 
            15  ws-tp-pat-id-no-mm         pic 99. 
	    15  ws-tp-pat-id-no-5-digit	pic x. 
	    15  ws-tp-pat-id-no-6-7-digit	pic 9(2). 
	    15  ws-tp-pat-id-no-8-digit    pic 9. 
	    15  ws-tp-pat-id-no-reminder   pic x(5).
	10  ws-tp-pat-id-no-last-digit	pic x. 
    05  ws-tp-pat-id-no-r2         redefines ws-tp-pat-id-no.
	10  ws-tp-pat-id-no-alpha		pic x.
	10  ws-tp-pat-id-no-9-digits. 
	    15  ws-tp-pat-id-no-1-3-digits      pic 9(3).
	    15  ws-tp-pat-id-no-4-9-digits	pic 9(6).
	10  ws-tp-pat-id-no-10-digit  		pic x.  
	10  ws-tp-pat-id-no-filler		pic x(4).
    05  ws-tp-pat-street-addr              pic x(28). 
    05  ws-tp-pat-street-addr2             pic x(28). 
    05  ws-tp-pat-city                     pic x(18). 
    05  ws-tp-pat-prov                     pic x(2). 
    05  ws-tp-pat-postal-code              pic x(6). 
    05  ws-tp-pat-postal-code-r     redefines ws-tp-pat-postal-code. 
        10  ws-tp-pat-postal-code-1	pic x. 
        10  ws-tp-pat-postal-code-2	pic x. 
        10  ws-tp-pat-postal-code-3	pic x. 
        10  ws-tp-pat-postal-code-4	pic x. 
        10  ws-tp-pat-postal-code-5	pic x. 
        10  ws-tp-pat-postal-code-6	pic x. 
*   05  ws-tp-pat-phone-no                 pic x(10). 
    05  ws-tp-pat-phone-no                 pic x(20). 
    05  ws-tp-pat-ohip-no                  pic x(8). 
    05  ws-tp-pat-health-nbr               pic x(10). 
    05  ws-tp-pat-version-cd.
	10  ws-tp-pat-version-cd-1		pic x.
	10  ws-tp-pat-version-cd-2		pic x.
    05  ws-tp-pat-health-65-ind            pic x. 
    05  ws-tp-pat-expiry-date. 
        10  ws-tp-pat-expiry-mm            pic 99. 
        10  ws-tp-pat-expiry-yy            pic 99. 

* TEMP FIX

    05  filler				pic x.
