*file: f010_patient_mstr.ws
*
* modification history
* --------------------
* 98/oct/26 B.E.	- MB numbers are only 6 digits long. MF cobol (d001)
*			  gives not-numeric err if testing 6 digits in 8 digit
*			  field with blanks in last 2 digits. Therefore a
*			  6 digit field redefine created. 
*			- NT must begin with N/D/M or T
* 99/jan/14 B.E.	- y2k conversion
*			- note some dates with "9(4) comp" changed to "9(8)".
*			  and record now 21 bytes longer
* 99/jan/20 B.E.	- switch expiry date from mmyy to yymm.
* 99/jan/21 M.C.	- the record should be 315 instead of 330 long 
*			- change ws-pat-reserve-for-future from 21 to 1, add
*			  ws-pat-last-mod-by (this is from HSC)
* 99/mar/16 B.E.        - added pat-health-nbr-unvalidated,
*                         pat-version-cd-unvalidated, and
*                         pat-ohip-validiation-status for additional 13 bytes
*                         plus increase given name from 12 to 17 and surname
*                         from 15 to 25 characters for an addition 15 bytes for
*                         a total increase in sisze 13+15 = 28 bytes.
* 00/mar/08 B.E.	- redefined ws-pat-last-birth-date so that the 
*			  individual yy/mm/dd values can be referenced
* 2002/may/10 B.E.      - phone-nbr from 7 to 20
*                       - added 4 addition hospital chart nbrs:
*                               pat-chart-nbr   = MUMC
*                               pat-chart-nbr-2 = CHEDOKE
*                               pat-chart-nbr-3 = HENDERSON
*                               pat-chart-nbr-4 = GENERAL
*                               pat-chart-nbr-5 = ST JOES
*                       - changed subscr-addr, subscr-addr-unvalidated and 
*                         pat-old-addr elements to:
*                               addr1/2/3 from 21 to 30
*                        - country changed from x(20 to x(1)
*                        - added an 'address' prov-cd x(2) as compared to the
*                          health insurance card prov-cd
* 2002/sep/13 B.E.	- postal code from 6 to 10
* 2003/apr/09 M.C.	- substitute ws-pat-reserve-for-future with ws-pat-obec-status
* 2003/nov/24 M.C.	- change ws-pat-last-doc-nbr-seen from 9(6) to x(3).
* 2016/Aug/31 MC1 	- extend version-cd into 1 and 2  
* 
* Note: The following files must be kept in sync:
*		f010_patient_mstr.fd
*		f010_patient_mstr_new.fd
*		f010_patient_mstr.ws

01 ws-pat-mstr-rec.  
  
    05  ws-pat-acronym.  
	10  ws-pat-acronym-first6		pic x(6).  
	10  ws-pat-acronym-last3		pic xxx.  
  
    05  ws-pat-ohip-mmyy.  
    	10  ws-pat-ohip-out-prov.  
	    15  ws-pat-ohip-nbr			pic 9(8).  
  	    15  ws-pat-ohip-nbr-r-alpha redefines ws-pat-ohip-nbr  
						pic x(8).  
* (98/oct/26)
	    15  ws-pat-ohip-nbr-MB-def redefines ws-pat-ohip-nbr.
		20  ws-pat-ohip-nbr-MB		pic 9(6).
	 	20  filler			pic x(2).
	    15  ws-pat-ohip-nbr-NT-def redefines ws-pat-ohip-nbr.
	 	20  ws-pat-ohip-nbr-NT-1-char	pic x(1).
		20  ws-pat-ohip-nbr-NT		pic 9(7).
	    15  ws-pat-mm			pic 99.  
	    15  ws-pat-yy			pic 99.  
	10  filler				pic x(3).  
    05  ws-pat-ohip-mmyy-r  redefines ws-pat-ohip-mmyy.  
        10  ws-pat-direct-alpha.  
	    15  ws-pat-alpha1			pic x.  
	    15  ws-pat-alpha2-3		pic xx.  
	10  ws-pat-direct-yy			pic xx.  
	10  ws-pat-direct-mm			pic xx.  
	10  ws-pat-direct-dd			pic xx.  
        10  ws-pat-direct-filler       	pic x(6).  
  
    05  ws-pat-chart-nbr.  
        10  pat-chart-1st-char          pic x.   
        10  pat-chart-remainder         pic x(9).
    05  ws-pat-chart-nbr-2.   
        10  pat-chart-1st-char          pic x.   
        10  pat-chart-remainder         pic x(9).
    05  ws-pat-chart-nbr-3.   
        10  pat-chart-1st-char          pic x.   
        10  pat-chart-remainder         pic x(9).
    05  ws-pat-chart-nbr-4.   
        10  pat-chart-1st-char          pic x.   
        10  pat-chart-remainder         pic x(9).
    05  ws-pat-chart-nbr-5.   
        10  pat-chart-1st-char          pic x.   
        10  pat-chart-remainder         pic x(10).

    05  ws-pat-surname				pic x(25).  
    05  ws-pat-surname-r  redefines  ws-pat-surname.  
	10  ws-pat-surname-first6 		pic x(6).  
* MC	10  ws-pat-surname-last14		pic x(14).  
	10  ws-pat-surname-last19		pic x(19).  
    05  ws-pat-surname-rr  redefines  ws-pat-surname.  
	10  ws-pat-surname-first3		pic x(3).  
	10  ws-pat-surname-last22		pic x(22).  
  
    05  ws-pat-given-name			pic x(17).  
    05  ws-pat-given-name-r  redefines  ws-pat-given-name.  
	10  ws-pat-given-name-first3		pic xxx.  
	10  ws-pat-given-name-last14		pic x(14).  
    05  ws-pat-given-name-rr redefines ws-pat-given-name-r.  
	10  ws-pat-given-name-first1		pic x.  
	10  filler				pic x(16).  
  
    05  ws-pat-init.  
	10  ws-pat-init1			pic x.  
	10  ws-pat-init2			pic x.  
	10  ws-pat-init3			pic x.  
    05  ws-pat-location-field.  
	10  ws-pat-location-field-1-3		pic x(3).  
	10  filler				pic x(1).  
* 2003/11/24 - MC
*    05  ws-pat-last-doc-nbr-seen		pic 9(6).  
    05  ws-pat-last-doc-nbr-seen		pic x(3).
* 2003/11/24 - end  
  
    05  ws-pat-birth-date			pic 9(8).  
    05  ws-pat-birth-date-r  redefines  ws-pat-birth-date.  
	10  ws-pat-birth-date-yy		pic 9(4).  
	10  ws-pat-birth-date-yy-r redefines ws-pat-birth-date-yy.
		15 ws-pat-birth-date-yy-12	pic 99.
		15 ws-pat-birth-date-yy-34	pic 99.
	10  ws-pat-birth-date-mm		pic 99.  
	10  ws-pat-birth-date-dd		pic 99.  
  
    05  ws-pat-date-last-maint             	pic 9(8).  
    05  ws-pat-date-last-maint-r redefines ws-pat-date-last-maint.  
	10  ws-pat-date-last-maint-yy		pic 9(4).  
	10  ws-pat-date-last-maint-mm		pic 99.  
	10  ws-pat-date-last-maint-dd		pic 99.  
  
    05  ws-pat-date-last-visit 		pic 9(8).  
    05  ws-pat-date-last-visit-r redefines ws-pat-date-last-visit.  
	10  ws-pat-date-last-visit-yy		pic 9(4).  
	10  ws-pat-date-last-visit-mm		pic 99.  
	10  ws-pat-date-last-visit-dd		pic 99.  
  
    05  ws-pat-date-last-admit 		pic 9(8).  
    05  ws-pat-date-last-admit-r redefines ws-pat-date-last-admit.  
	10  ws-pat-date-last-admit-yy		pic 9(4).  
	10  ws-pat-date-last-admit-mm		pic 99.  
	10  ws-pat-date-last-admit-dd		pic 99.  
  
    05  ws-pat-phone-nbr.  
	10  ws-pat-phone-nbr-first3		pic 999.  
	10  ws-pat-phone-nbr-last4		pic 9(4).  
	10  ws-pat-phone-nbr-remainder     	pic x(13).

    05  ws-pat-total-nbr-visits			pic 9(5).  
    05  ws-pat-total-nbr-claims			pic 9(5).  
    05  ws-pat-sex				pic x.  
    05  ws-pat-in-out				pic x.  

*2002/08/15 - MC - f010_patient_mstr.fd contains 9(4).
*    05  ws-pat-nbr-outstanding-claims		pic 9(5).  
    05  ws-pat-nbr-outstanding-claims		pic 9(4).  
*2002/08/15 - end

    05  ws-key-pat-mstr.  
        10  ws-pat-i-key    			pic x.  
	10  ws-pat-con-nbr			pic 99.  
	10  ws-pat-i-nbr			pic 9(12).  
	10  filler				pic x.  
    05  ws-pat-health-nbr                  	pic 9(10).  
* MC1
*   05  ws-pat-version-cd                  	pic xx.  
    05  ws-pat-version-cd. 
        10  ws-pat-version-cd-1			pic x.
        10  ws-pat-version-cd-2			pic x.
* MC1 - end
05  ws-pat-health-65-ind               		pic x.  
    05  ws-pat-expiry-date.  
        10  ws-pat-expiry-yy               	pic 99.  
        10  ws-pat-expiry-mm               	pic 99.  
    05  ws-pat-prov-cd                     	pic xx.  
  
    05  ws-subscr-addr1				pic x(30).  
    05  ws-subscr-addr2				pic x(30).  
    05  ws-subscr-addr3				pic x(30).  
    05  ws-subscr-prov-cd			pic x(2).  
 
* 2002/sep/13 
*    05  ws-subscr-postal-cd			pic x(6).  
    05  ws-subscr-postal-cd			pic x(10).  
    05  ws-subscr-postal-cd-r  redefines  ws-subscr-postal-cd.  
	10  ws-subscr-post-code1.  
	    15  ws-subscr-post-cd1			pic x.  
	    15  ws-subscr-post-cd2			pic 9.  
	    15  ws-subscr-post-cd3			pic x.  
	10  ws-subscr-post-code2.  
	    15  ws-subscr-post-cd4			pic 9.  
	    15  ws-subscr-post-cd5			pic x.  
	    15  ws-subscr-post-cd6			pic 9.  
	10  filler					pic x(4).

    05  ws-subscr-msg-data.  
        10  ws-subscr-msg-nbr				pic xx.  
        10  ws-subscr-dt-msg-no-eff-to			pic 9(8).  
        10  ws-subscr-dt-msg-no-eff-to-r  
              redefines ws-subscr-dt-msg-no-eff-to.  
	    15  ws-subscr-dt-msg-no-eff-to-yy 	pic 9(4).  
	    15  ws-subscr-dt-msg-no-eff-to-mm 	pic 99.  
    	    15  ws-subscr-dt-msg-no-eff-to-dd 	pic 99.  
        10  ws-subscr-dt-msg-no-eff-to-r1  
              redefines ws-subscr-dt-msg-no-eff-to-r  
							pic x(8).  
        10  ws-subscr-date-last-statement		pic 9(8).  
        10  ws-subscr-date-last-stmnt-r  
	      redefines ws-subscr-date-last-statement.  
	    15  ws-subscr-date-last-stmnt-yy	pic 9(4).  
	    15  ws-subscr-date-last-stmnt-mm	pic 99.  
	    15  ws-subscr-date-last-stmnt-dd	pic 99.  
    05  ws-subscr-auto-update				pic x.  
    05  ws-pat-last-mod-by       			pic x(5).  
    05  ws-pat-date-last-elig-mailing                   pic 9(8).
    05  ws-pat-date-last-elig-maint                     pic 9(8).
    05  ws-pat-last-birth-date                          pic 9(8).
    05  ws-pat-last-birth-date-r redefines ws-pat-last-birth-date.
	10 ws-pat-last-birth-date-yy			pic 9(4).
	10 ws-pat-last-birth-date-mm			pic 9(2).
	10 ws-pat-last-birth-date-dd			pic 9(2).
    05  ws-pat-last-version-cd                          pic x(2).  
    05  ws-pat-mess-code                                pic x(3).  

***    05  ws-pat-country                                  pic x(20).  
    05  ws-pat-country                                  pic x(1).  

    05  ws-pat-no-of-letter-sent                        pic 99.  
    05  ws-pat-dialysis          			pic x(1).  
    05  ws-pat-ohip-validiation-status                  pic x.

* 2003/04/09 - MC
*    05  ws-pat-reserve-for-future                      pic x(1).
    05  ws-pat-obec-status                              pic x(1).
* 2004/04/09 - end
