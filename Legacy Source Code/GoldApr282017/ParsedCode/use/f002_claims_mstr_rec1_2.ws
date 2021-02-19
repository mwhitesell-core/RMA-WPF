*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*  yy/mm/dd  whom          why
*  --------  ----          ---
*
*  84/12/19  i.warsh       broke down the reference field so that
*                          each individual character could be looked at
*                          for direct bills.
*  90/09/27  b.elliott     added redefine for clmhdr-claim-source-cd
*
*  91/02/13  m. chan       clmhdr-tape-submit-ind is related to manual
*                          review flag.  if 'n' means manual review is
*                          on; ohterwise, if 'y' means manual review is
*                          off
*
*  91/04/17  m. chan       clmhdr-tape-submit-ind is related to claim
*                          status - 's'ubmit, 'r'esubmit or 'h'old
*  98/01/26  m. chan       moved clmhdr-orig-batch-id after clmhdr-reserve-
*                          for-future                                
*  98/06/02  d. balmer     y2K date change 
*  99/jan/21 B.E.  - added clmhdr-date-sys breakdown of -12 and -38 fields.
*  99/jan/25 B.E.  - added clmhdr-date-admit breakdown of -12 and -38 fields.
*  99/jan/25 B.E.  - added clmhdr-payroll redefine of clmhdr-hosp
*  03/aug/21 M.C.  - add 5 new elements to the files              
*  03/nov/05 M.C.  - alpha doc nbr
*  04/jul/07 b.e.  - added  clmdtl-orig-doc-number 
*			    clmdtl-orig-batch-number
*		            clmdtl-orig-claim-number
*  04/nov/18 M.C. - correct the redefinition of clmdtl-orig-complete-batch-n-r
*		    by including clmdtl-orig-clinic-number
*  07/jan/16 M.C. - change the definition of clmhdr-week/day from numeric to alpha
*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

* insert this warning message from "f002_duplicate_fd_warning.fd"

*+++++++++++++++W A R N I N G +++++++++++++++
*                                           *
* any changes to this fd must also be made  *
* to the other 3 in the following list:     *
*                                           *
*        "f002_claims_hdr_rec.ws            *
*        "f002_claims_dtl_rec.ws            *
*        "f002_claims_mstr_rec1_2.ws        *
*        "f002_clm_mstr_p_access.ws         *
*                                           *
*+++++++++++++++W A R N I N G +++++++++++++++

*
*       note 1: key for this file is the claim-id which is prefaced by a
*               1 character type field -- 'p' = patient id (i key)
*                                         'b' = batch nbr
*       note 2: - the claim detail data recs are written with valid oma
*                   codes, the detail description recs use an oma code of 'zzzz'
*                   and adjustment detail records use and 'adj-cd' of "1")

01  claim-header-rec.

    05  clmhdr-claim-id.
*!      10  clmhdr-batch-nbr                    pic 9(9).
        10  clmhdr-batch-nbr                    pic x(8).
        10  clmhdr-batch-nbr-r1 redefines clmhdr-batch-nbr.
            15  clmhdr-clinic-nbr-1-2           pic 99.
*!          15  clmhdr-doc-nbr                  pic 9(4).
            15  clmhdr-doc-nbr                  pic x(3).
*           15  clmhdr-week                     pic 99.
*           15  clmhdr-day                      pic 9.
            15  clmhdr-week                     pic xx.
            15  clmhdr-day                      pic x.
        10  clmhdr-batch-nbr-r2 redefines clmhdr-batch-nbr.
            15  filler                          pic xx.
*!          15  clmhdr-batch-nbr-3-6            pic 9(4).
            15  clmhdr-batch-nbr-3-6            pic x(3).
            15  clmhdr-batch-nbr-7-9            pic 999.
        10  clmhdr-claim-nbr                    pic 9(2).
        10  clmhdr-zeroed-oma-suff-adj.
            15  clmhdr-adj-oma-cd               pic x999.
            15  clmhdr-adj-oma-suff             pic x.
            15  clmhdr-adj-adj-nbr              pic 9.
        10  clmhdr-zeroed-area redefines clmhdr-zeroed-oma-suff-adj
                                                pic 9(6).
*       (valid batch types are 'c' 'a' 'p')
    05  clmhdr-batch-type                       pic x.
*       ('clmhdr-card-colour' replaced by 'adjust-sub-type' --
    05  clmhdr-adj-cd-sub-type                  pic x.
    05  clmhdr-adj-cd-sub-type-ss redefines clmhdr-adj-cd-sub-type
                                                pic 9.
    05  clmhdr-claim-source-cd    redefines clmhdr-adj-cd-sub-type
                                                pic x.
    05  clmhdr-doc-nbr-ohip                     pic 9(6).
    05  clmhdr-doc-spec-cd                      pic 99.
    05  clmhdr-refer-doc-nbr                    pic 9(6).
    05  clmhdr-diag-cd                          pic 999.
    05  clmhdr-loc                              pic x999.

    05  clmhdr-hosp                             pic x.
    05  clmhdr-payroll redefines clmhdr-hosp    pic x.

    05  clmhdr-agent-cd                         pic 9.
    05  clmhdr-adj-cd                           pic x.
    05  clmhdr-tape-submit-ind                  pic x.
    05  clmhdr-i-o-pat-ind                      pic x.
    05  clmhdr-pat-ohip-id-or-chart.
        10  clmhdr-pat-key-type                 pic a.
        10  clmhdr-pat-key-data.
            15  clmhdr-pat-key-ohip             pic x(8).
            15  filler                          pic x(7).
    05  clmhdr-pat-acronym.
        10  clmhdr-pat-acronym6                 pic x(6).
        10  clmhdr-pat-acronym3                 pic x(3).
    05  clmhdr-reference.
        10  clmhdr-ref1                         pic x.
        10  clmhdr-ref2                         pic x.
        10  clmhdr-ref3                         pic x.
        10  clmhdr-ref4                         pic x.
        10  clmhdr-ref5                         pic x.
        10  clmhdr-ref6                         pic x.
        10  clmhdr-ref7                         pic x.
        10  clmhdr-ref8                         pic x.
        10  clmhdr-ref9                         pic x.
* y2k
        10  clmhdr-ref10                        pic x.
        10  clmhdr-ref11                        pic x.
    05  clmhdr-reference-r redefines clmhdr-reference.
        10  clmhdr-ref-date1.
* y2k 
*           15  clmhdr-ref-date-yy              	pic 9(2).
            15  clmhdr-ref-date-yy              pic 9(4).
            15  clmhdr-ref-date-mm              pic 9(2).
            15  clmhdr-ref-date-dd              pic 9(2).
        10  clmhdr-ref-inits                    pic x(3).
    05  clmhdr-reference-r1 redefines clmhdr-reference-r.
        10  filler                              pic x.
* y2k
*       10  clmhdr-ref-date2                    	pic x(6).
        10  clmhdr-ref-date2                    pic x(8).
        10  filler                              pic x(2).
    05  clmhdr-reference-r2 redefines clmhdr-reference-r1.
        10  filler                              pic x(2).
* y2k
*       10  clmhdr-ref-date3                    	pic x(6).
        10  clmhdr-ref-date3                    pic x(8).
        10  filler                              pic x(1).
    05  clmhdr-reference-r3 redefines clmhdr-reference-r2.
        10  filler                              pic x(3).
* y2k
*       10  clmhdr-ref-date4                    	pic x(6).
        10  clmhdr-ref-date4                    pic x(8).
    05  clmhdr-date-admit.
*           (note - admit-yy must be left alpha-numeric)
* y2k
*       10  clmhdr-date-admit-yy                	pic xx.
        10  clmhdr-date-admit-yy                pic x(4).
	10  clmhdr-date-admit-yy-r redefines
	    clmhdr-date-admit-yy.
	    15  clmhdr-date-admit-yy-12		pic xx.
	    15  clmhdr-date-admit-yy-34		pic xx.
        10  clmhdr-date-admit-mm                pic 99.
        10  clmhdr-date-admit-mm-r redefines clmhdr-date-admit-mm
                                                pic xx.
        10  clmhdr-date-admit-dd                pic 99.
        10  clmhdr-date-admit-dd-r redefines clmhdr-date-admit-dd
                                                pic xx.
    05  clmhdr-date-admit-r redefines clmhdr-date-admit
* y2k                                                pic 9(6).
                                                pic 9(8).
    05  clmhdr-date-admit-r2 redefines clmhdr-date-admit-r.
	10 clmhdr-date-admit-12			pic 9(2).
	10 clmhdr-date-admit-38			pic 9(6).
    05  clmhdr-doc-dept                         pic 99.
* y2k    05  clmhdr-date-cash-tape-payment           pic x(6).
    05  clmhdr-date-cash-tape-payment           pic x(8).
    05  clmhdr-date-cash-tape-paymt-r redefines 
	clmhdr-date-cash-tape-payment.
	10  clmhdr-date-cash-tape-paymt-12	pic 9(2).
	10  clmhdr-date-cash-tape-paymt-38	pic 9(6).
    05  clmhdr-direct-bills-clm-info  redefines clmhdr-date-cash-tape-payment.
        10  clmhdr-msg-nbr                      pic xx.
        10  clmhdr-reprint-flag                 pic x.
        10  clmhdr-sub-nbr                      pic x.
        10  clmhdr-auto-logout                  pic x.
        10  clmhdr-fee-complex                  pic x.
	10  filler				pic xx.
    05  clmhdr-curr-payment                     pic s9(5)v99.

    05  clmhdr-date-period-end.
* y2k
*       10  clmhdr-period-end-yy                	pic 99.
        10  clmhdr-period-end-yy                pic 9(4).
        10  clmhdr-period-end-mm                pic 99.
        10  clmhdr-period-end-dd                pic 99.
    05  clmhdr-cycle-nbr                        pic 99.
* y2k
*   05  clmhdr-date-sys                         	pic x(6).
    05  clmhdr-date-sys                         pic x(8).
    05  clmhdr-date-sys-r redefines clmhdr-date-sys.
	10  clmhdr-date-sys-12			pic 9(2).
	10  clmhdr-date-sys-38			pic 9(6).
    05  clmhdr-amt-tech-billed                  pic s9(4)v99.
    05  clmhdr-amt-tech-paid                    pic s9(4)v99.
    05  clmhdr-tot-claim-ar-oma                 pic s9(5)v99.
    05  clmhdr-tot-claim-ar-ohip                pic s9(5)v99.
    05  clmhdr-manual-and-tape-paymnts          pic s9(5)v99.
    05  clmhdr-status-ohip                      pic xx.

    05  clmhdr-manual-review                    pic x.
    05  clmhdr-submit-date.
* y2k
*       10  clmhdr-submit-yy                    	pic 99.
        10  clmhdr-submit-yy                    pic 9(4).
        10  clmhdr-submit-mm                    pic 99.
        10  clmhdr-submit-dd                    pic 99.
    05  clmhdr-confidential-flag                pic x.
* y2k 
*   05  clmhdr-serv-date                        	pic 9(6).
    05  clmhdr-serv-date                        pic 9(8).
*
* (y2k removed)
*	    05  clmhdr-reserve-for-future               pic x(6).
   
* 2003/08/21 - add 4 new items
    05  clmhdr-elig-error			pic x(3).
    05  clmhdr-elig-status			pic x.
    05  clmhdr-serv-error			pic x(3).
    05  clmhdr-serv-status			pic x.
* 2003/08/21 - end
 
    05  clmhdr-orig-batch-id.
        10  clmhdr-orig-batch-nbr.
            15  clmhdr-orig-batch-nbr-1-2       pic  99.
*!          15  clmhdr-orig-batch-nbr-3         pic   9.
*!          15  clmhdr-orig-batch-nbr-4-9       pic 9(6).
            15  clmhdr-orig-batch-nbr-4-9       pic x(6).
        10  clmhdr-orig-batch-nbr-next-def      redefines clmhdr-orig-batch-nbr.
            15  filler                          pic  99.
*!          15  filler                          pic   9.
*!          15  clmhdr-orig-batch-nbr-4-6       pic 9(3).
            15  clmhdr-orig-batch-nbr-4-6       pic x(3).
            15  clmhdr-orig-batch-nbr-7-8       pic  99.
            15  clmhdr-orig-batch-nbr-9         pic   9.
        10  clmhdr-orig-claim-nbr               pic  99.
    05  clmhdr-orig-batch-id-r  redefines clmhdr-orig-batch-id.
*!      10  clmhdr-orig-complete-batch-nbr      pic 9(11).
        10  clmhdr-orig-complete-batch-nbr      pic x(10).
*mf moved external keys into data record
*mfcopy "f002_key_claims_mstr_mf.ws" replacing "key-clm-" by "clmhdr-b-".
*-------------------
05  k-clmhdr-claims-mstr.
*        key type: 'b' = batch id
*                  'p' = patient id (i key)
    20  k-clmhdr-b-key-type                        pic x.
    20  k-clmhdr-b-data.
*!      25  k-clmhdr-b-batch-num                   pic 9(9).
        25  k-clmhdr-b-batch-num                   pic x(8).
        25  k-clmhdr-b-batch-nbr redefines k-clmhdr-b-batch-num.
            30  k-clmhdr-b-clinic-nbr-1-2          pic 99.
*!          30  k-clmhdr-b-doc-nbr                 pic 9(4).
            30  k-clmhdr-b-doc-nbr                 pic x(3).
            30  k-clmhdr-b-doc-nbr-r redefines k-clmhdr-b-doc-nbr.
*!              35  k-clmhdr-b-doc-nbr-1           pic 9.
*!              35  k-clmhdr-b-doc-nbr-2-4         pic 999.
                35  k-clmhdr-b-doc-nbr-2-4         pic xxx.
*           ( added so that the new batch number can be accessed
*             rather than the old  week-day combination )
            30  k-clmhdr-b-batch-number.
                35  k-clmhdr-b-week                pic 99.
                35  k-clmhdr-b-day                 pic 9.
        25  k-clmhdr-b-claim-nbr                   pic 99.
        25  k-clmhdr-b-oma-cd                      pic x999.
        25  k-clmhdr-b-oma-suff                    pic x.
        25  k-clmhdr-b-adj-nbr                     pic x.
    20  k-clmhdr-b-data-r  redefines  k-clmhdr-b-data.
        25  k-clmhdr-b-pat-id                      pic x(15).
*!      25  filler                                 pic xx.
        25  filler                                 pic x.

*mf10  k-clmhdr-p-claims-mstr.
05  k-clmhdr-p-claims-mstr.
    20  k-clmhdr-p-key-type                        pic x.
    20  k-clmhdr-p-data.
        25  k-clmhdr-p-batch-nbr.
            30  k-clmhdr-p-clinic-nbr-1-2      pic  99.
*!          30  k-clmhdr-p-doc-nbr             pic 9(4).
            30  k-clmhdr-p-doc-nbr             pic x(3).
            30  k-clmhdr-p-week                pic 99.
            30  k-clmhdr-p-day                 pic 9.
        25  k-clmhdr-p-claim-nbr               pic 99.
        25  k-clmhdr-p-oma-cd                  pic x999.
        25  k-clmhdr-p-oma-suff                pic x.
        25  k-clmhdr-p-adj-nbr                 pic x.
*-------------------------

01  claim-detail-rec.

    05  clmdtl-id.
*!      10  clmdtl-batch-nbr                    pic 9(9).
        10  clmdtl-batch-nbr                    pic x(8).
        10  clmdtl-claim-nbr                    pic 9(2).
        10  clmdtl-oma-cd                       pic xxxx.
        10  clmdtl-oma-suff                     pic x.
        10  clmdtl-adj-nbr                      pic 9.

    05  clmdtl-det-rec.
        10  clmdtl-rev-group-cd                 pic xxx.
        10  clmdtl-agent-cd                     pic 9.
        10  clmdtl-adj-cd                       pic x.
        10  clmdtl-nbr-serv                     pic 99.
        10  clmdtl-nbr-serv-r redefines clmdtl-nbr-serv.
            15  clmdtl-adjust-reprint           pic x.
            15  filler                          pic x.
        10  clmdtl-sv-date.
* y2k            15  clmdtl-sv-yy                    pic 99.
            15  clmdtl-sv-yy                    pic 9999.
            15  clmdtl-sv-mm                    pic 99.
            15  clmdtl-sv-dd                    pic 99.

        10  clmdtl-consec-dates.
            15  clmdtl-consecutive-sv-date  occurs 3 times
                                                pic 999.
        10  clmdtl-consec-dates-r  redefines  clmdtl-consec-dates.
            15  clmdtl-consecutive-dates    occurs 3 times.
                20  clmdtl-sv-nbr               pic  9.
                20  clmdtl-sv-day               pic xx.

        10  clmdtl-amt-tech-billed              pic s9(4)v99.
        10  clmdtl-fee-oma                      pic s9(5)v99.
        10  clmdtl-fee-ohip                     pic s9(5)v99.
* y2k        10  clmdtl-date-period-end              pic x(6).
        10  clmdtl-date-period-end              pic x(8).
        10  clmdtl-cycle-nbr                    pic 999.

        10  clmdtl-diag-cd                      pic 999.
        10  clmdtl-line-no                      pic 99.
* (y2k)
*       10  clmdtl-reserve-for-future           	pic x(8).
* 2003/08/21 - MC
*      10  clmdtl-reserve-for-future           pic x(4).
       10  clmdtl-resubmit-flag                pic x.
       10  clmdtl-reserve-for-future           pic x(3).
* 2003/08/21 - end

    05  clmdtl-desc-rec redefines clmdtl-det-rec.
        10  clmdtl-desc                         pic x(22).
        10  filler                              pic x(42).
*mf
*   05  clmdtl-filler                           	pic x(88).
* 2003/08/21 - MC
*   05  clmdtl-filler                           pic x(96).
    05  clmdtl-filler                           pic x(104).  
* 2003/08/21 - end

    05  clmdtl-orig-batch-id.
*!      10  clmdtl-orig-batch-nbr               pic 9(9).
        10  clmdtl-orig-batch-nbr               pic x(8).
        10  clmdtl-orig-batch-nbr-r redefines clmdtl-orig-batch-nbr.
            15  clmdtl-orig-batch-nbr-1-2       pic 99.
*!          15  clmdtl-orig-batch-nbr-3         pic 9.
*!          15  clmdtl-orig-batch-nbr-4-9       pic 9(6).
            15  clmdtl-orig-batch-nbr-4-9       pic x(6).
        10  clmdtl-orig-claim-nbr-in-batch      pic 99.
    05  clmdtl-orig-batch-id-r  redefines clmdtl-orig-batch-id.
*!      10  clmdtl-orig-complete-batch-nbr      pic 9(11).
        10  clmdtl-orig-complete-batch-nbr      pic 9(10).
	10  clmdtl-orig-complete-batch-n-r redefines clmdtl-orig-complete-batch-nbr.
* 2004/11/18 - MC - include clinic nbr
	    15  clmdtl-orig-clinic-number       pic 99.
* 2004/11/18 - end
	    15  clmdtl-orig-doc-number 		pic x(3).
	    15  clmdtl-orig-batch-number 	pic 9(3).
	    15  clmdtl-orig-claim-number 	pic 9(2).

*mf moved external keys into data record
*mfcopy "f002_key_claims_mstr_mf.ws" replacing "key-clm-" by "clmdtl-b-".
*-------------------
05  k-clmdtl-claims-mstr.
*        key type: 'b' = batch id
*                  'p' = patient id (i key)
    20  k-clmdtl-b-key-type                        pic x.
    20  k-clmdtl-b-data.
*!      25  k-clmdtl-b-batch-num                   pic 9(9).
        25  k-clmdtl-b-batch-num                   pic x(8).
        25  k-clmdtl-b-batch-nbr redefines k-clmdtl-b-batch-num.
            30  k-clmdtl-b-clinic-nbr-1-2          pic 99.
*!          30  k-clmdtl-b-doc-nbr                 pic 9(4).
            30  k-clmdtl-b-doc-nbr                 pic x(3).
            30  k-clmdtl-b-doc-nbr-r redefines k-clmdtl-b-doc-nbr.
*!              35  k-clmdtl-b-doc-nbr-1           pic 9.
*!              35  k-clmdtl-b-doc-nbr-2-4         pic 999.
                35  k-clmdtl-b-doc-nbr-2-4         pic xxx.
*           ( added so that the new batch number can be accessed
*             rather than the old  week-day combination )
            30  k-clmdtl-b-batch-number.
                35  k-clmdtl-b-week                pic 99.
                35  k-clmdtl-b-day                 pic 9.
        25  k-clmdtl-b-claim-nbr                   pic 99.
        25  k-clmdtl-b-oma-cd                      pic x999.
        25  k-clmdtl-b-oma-suff                    pic x.
        25  k-clmdtl-b-adj-nbr                     pic x.
    20  k-clmdtl-b-data-r  redefines  k-clmdtl-b-data.
        25  k-clmdtl-b-pat-id                      pic x(15).
*!      25  filler                                 pic xx.
        25  filler                                 pic x.

*mf10  k-clmdtl-p-claims-mstr.
05  k-clmdtl-p-claims-mstr.
    20  k-clmdtl-p-key-type                        pic x.
    20  k-clmdtl-p-data.
        25  k-clmdtl-p-batch-nbr.
            30  k-clmdtl-p-clinic-nbr-1-2      pic  99.
*!          30  k-clmdtl-p-doc-nbr             pic 9(4).
            30  k-clmdtl-p-doc-nbr             pic x(3).
            30  k-clmdtl-p-week                pic 99.
            30  k-clmdtl-p-day                 pic 9.
        25  k-clmdtl-p-claim-nbr               pic 99.
        25  k-clmdtl-p-oma-cd                  pic x999.
        25  k-clmdtl-p-oma-suff                pic x.
        25  k-clmdtl-p-adj-nbr                 pic x.
*-------------------------

