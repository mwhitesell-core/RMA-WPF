*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*  yy/mm/dd  whom          why
*  --------  ----          ---
*
*  90/09/27  b.elliott     - added redefine for clmhdr-claim-source-cd
*  98/01/26  M. Chan       - moved clmhdr-orig-batch-id after clmhdr-reserve-
*			   for-future to be aligned with clmdtl-rec
*  99/jan/14 D.B.	   - y2k
*  01/nov/06 B.E.	   - added clmhdr-payroll as redefine of clmhdr-hosp
*  03/aug/21 M.C.  	   - add 5 new elements to the files              
*  03/nov/05 M.C.	   - alpha doc nbr
*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

* insert this warning message from "f002_duplicate_fd_warning.fd"
*
*================N O T E ====================
*                                           *
* any changes to this fd must also be made  *
* to the other 3 in the following list:     *
*                                           *
*        "f002_claims_hdr_rec.ws            *
*        "f002_claims_dtl_rec.ws            *
*        "f002_claims_mstr_rec1_2.ws        *
*        "f002_clm_mstr_p_access.ws         *
*                                           *
*================N O T E ====================

*
*       note 1: key for this file is the claim-id which is prefaced by a
*               1 character type field -- 'p' = patient id (chart # or ohip id)
*                                         'b' = batch nbr
*       note 2: - the claim detail data recs are written with valid oma
*                   codes, the detail description recs use an oma code of 'zzzz'
*                   and adjustment detail records use and 'adj-cd' of "1")

01  claim-header-rec.

    15  clmhdr-claim-id.
*!      20  clmhdr-batch-nbr                    pic 9(9).
        20  clmhdr-batch-nbr                    pic x(8).
        20  clmhdr-batch-nbr-r1 redefines clmhdr-batch-nbr.
            25  clmhdr-clinic-nbr-1-2           pic 99.
*!          25  clmhdr-doc-nbr                  pic 9(4).
            25  clmhdr-doc-nbr                  pic x(3).
            25  clmhdr-week                     pic 99.
            25  clmhdr-day                      pic 9.
        20  clmhdr-batch-nbr-r2 redefines clmhdr-batch-nbr.
            25  filler                          pic xx.
*!          25  clmhdr-batch-nbr-3-6            pic 9(4).
            25  clmhdr-batch-nbr-3-6            pic x(3).
            25  clmhdr-batch-nbr-7-9            pic 999.
        20  clmhdr-claim-nbr                    pic 9(2).
        20  clmhdr-zeroed-oma-suff-adj.
            25  clmhdr-adj-oma-cd               pic x999.
            25  clmhdr-adj-oma-suff             pic x.
            25  clmhdr-adj-adj-nbr              pic 9.
        20  clmhdr-zeroed-area redefines clmhdr-zeroed-oma-suff-adj
                                                pic 9(6).
*       (valid batch types are 'c' 'a' 'p')
    15  clmhdr-batch-type                       pic x.
*       ('clmhdr-card-colour' replaced by 'adjust-sub-type' --
    15  clmhdr-adj-cd-sub-type                  pic x.
    15  clmhdr-adj-cd-sub-type-ss redefines clmhdr-adj-cd-sub-type
                                                pic 9.
    15  clmhdr-claim-source-cd    redefines clmhdr-adj-cd-sub-type
                                                pic x.
    15  clmhdr-doc-nbr-ohip                     pic 9(6).
    15  clmhdr-doc-spec-cd                      pic 99.
    15  clmhdr-refer-doc-nbr                    pic 9(6).
    15  clmhdr-diag-cd                          pic 999.
    15  clmhdr-loc                              pic x999.

    15  clmhdr-hosp                             pic x.
    15  clmhdr-payroll redefines clmhdr-hosp    pic x.

    15  clmhdr-agent-cd                         pic 9.
    15  clmhdr-adj-cd                           pic x.
    15  clmhdr-tape-submit-ind                  pic x.
*       (tape ind = "y" for tape, "n" for card, or "r" for card with operator re
    15  clmhdr-i-o-pat-ind                      pic x.
    15  clmhdr-pat-ohip-id-or-chart.
        20  clmhdr-pat-key-type                 pic a.
        20  clmhdr-pat-key-data.
            25  clmhdr-pat-key-ohip             pic x(8).
            25  filler                          pic x(7).
    15  clmhdr-pat-acronym.
        20  clmhdr-pat-acronym6                 pic x(6).
        20  clmhdr-pat-acronym3                 pic x(3).
* y2k
*   15  clmhdr-reference                        pic x(9).
    15  clmhdr-reference                        pic x(11).
    15  clmhdr-date-admit.
* y2k  
*           (note - admit-yy must be left alpha-numeric)
*       20  clmhdr-date-admit-yy                pic xx.
        20  clmhdr-date-admit-yy                pic xxxx.
	20  clmhdr-date-admit-yy-r redefines
	    clmhdr-date-admit-yy.
	    25  clmhdr-date-admit-yy-12		pic 99.
	    25  clmhdr-date-admit-yy-34		pic 99.
        20  clmhdr-date-admit-mm                pic 99.
        20  clmhdr-date-admit-mm-r redefines clmhdr-date-admit-mm
                                                pic xx.
        20  clmhdr-date-admit-dd                pic 99.
        20  clmhdr-date-admit-dd-r redefines clmhdr-date-admit-dd
                                                pic xx.
    15  clmhdr-date-admit-r redefines clmhdr-date-admit
* y2k                                                pic 9(6).
                                                pic 9(8).
*       ('clmhdr-date-claim' replaced by 'doc dept' )
    15  clmhdr-doc-dept                         pic 99.

*y2k    15  clmhdr-date-cash-tape-payment           pic x(6).
    15  clmhdr-date-cash-tape-payment           pic x(8).
    15  clmhdr-direct-bills-clm-info  redefines clmhdr-date-cash-tape-payment.
        20  clmhdr-msg-nbr                      pic xx.
        20  clmhdr-reprint-flag                 pic x.
        20  clmhdr-sub-nbr                      pic x.
        20  clmhdr-auto-logout                  pic x.
        20  clmhdr-fee-complex                  pic x.
	20  filler				pic xx.
    15  clmhdr-curr-payment                     pic s9(5)v99.
    15  clmhdr-date-period-end.
* y2k        20  clmhdr-period-end-yy                pic 99.
        20  clmhdr-period-end-yy                pic 9(4).
        20  clmhdr-period-end-mm                pic 99.
        20  clmhdr-period-end-dd                pic 99.
    15  clmhdr-cycle-nbr                        pic 99.
* y2k    15  clmhdr-date-sys                         pic x(6).
    15  clmhdr-date-sys                         pic x(8).
    15  clmhdr-amt-tech-billed                  pic s9(4)v99.
    15  clmhdr-amt-tech-paid                    pic s9(4)v99.
    15  clmhdr-tot-claim-ar-oma                 pic s9(5)v99.
    15  clmhdr-tot-claim-ar-ohip                pic s9(5)v99.
    15  clmhdr-manual-and-tape-paymnts          pic s9(5)v99.
    15  clmhdr-status-ohip                      pic xx.
    15  clmhdr-manual-review                    pic x.
    15  clmhdr-submit-date.
* y2k        20  clmhdr-submit-yy                    pic 99.
        20  clmhdr-submit-yy                    pic 9999.
        20  clmhdr-submit-mm                    pic 99.
        20  clmhdr-submit-dd                    pic 99.
    15  clmhdr-confidential-flag                pic x.
* y2k    15  clmhdr-serv-date                        pic 9(6).
    15  clmhdr-serv-date                        pic 9(8).
*   15  clmhdr-reserve-for-future               pic x(6).
* 2003/08/21 - add 4 new items
    15  clmhdr-elig-error			pic x(3).
    15  clmhdr-elig-status			pic x.
    15  clmhdr-serv-error			pic x(3).
    15  clmhdr-serv-status			pic x.
* 2003/08/21 - end
 
       15  clmhdr-orig-batch-id.
        20  clmhdr-orig-batch-nbr.
            25  clmhdr-orig-batch-nbr-1-2       pic  99.
*!          25  clmhdr-orig-batch-nbr-3         pic   9.
*!          25  clmhdr-orig-batch-nbr-4-9       pic 9(6).
            25  clmhdr-orig-batch-nbr-4-9       pic x(6).
        20  clmhdr-orig-batch-nbr-next-def      redefines clmhdr-orig-batch-nbr.
            25  filler                          pic  99.
*!          25  filler                          pic   9.
*!          25  clmhdr-orig-batch-nbr-4-6       pic 9(3).
            25  clmhdr-orig-batch-nbr-4-6       pic x(3).
            25  clmhdr-orig-batch-nbr-7-8       pic  99.
            25  clmhdr-orig-batch-nbr-9         pic   9.
        20  clmhdr-orig-claim-nbr               pic  99.
    15  clmhdr-orig-batch-id-r  redefines clmhdr-orig-batch-id.
*!      20  clmhdr-orig-complete-batch-nbr      pic 9(11).
        20  clmhdr-orig-complete-batch-nbr      pic x(10).
*mf moved external keys into data record
*brad copy "f002_key_claims_mstr_mf.ws"
*        replacing ==(key-clm)==         by ==clmhdr-b==
*                  ==(key-gen)==         by ==clmhdr-p==
*                  ==key-claims-mstr== by ==clmhdr-key-claims-mstr==.
15  clmhdr-key-claims-mstr.
*        key type: 'b' = batch id
*                  'p' = patient id (i key)
    20  clmhdr-b-key-type                        pic a.
    20  clmhdr-b-data.
*!      25  clmhdr-b-batch-num                   pic 9(9).
        25  clmhdr-b-batch-num                   pic x(8).
        25  clmhdr-b-batch-nbr redefines clmhdr-b-batch-num.
            30  clmhdr-b-clinic-nbr-1-2          pic 99.
*!          30  clmhdr-b-doc-nbr                 pic 9(4).
            30  clmhdr-b-doc-nbr                 pic x(3).
            30  clmhdr-b-doc-nbr-r redefines clmhdr-b-doc-nbr.
*!              35  clmhdr-b-doc-nbr-1           pic 9.
*!              35  clmhdr-b-doc-nbr-2-4         pic 999.
                35  clmhdr-b-doc-nbr-2-4         pic xxx.
*           ( added so that the new batch number can be accessed
*             rather than the old  week-day combination )
            30  clmhdr-b-batch-number.
                35  clmhdr-b-week                pic 99.
                35  clmhdr-b-day                 pic 9.
        25  clmhdr-b-claim-nbr                   pic 99.
        25  clmhdr-b-oma-cd                      pic x999.
        25  clmhdr-b-oma-suff                    pic x.
        25  clmhdr-b-adj-nbr                     pic x.
    20  clmhdr-b-data-r  redefines  clmhdr-b-data.
        25  clmhdr-b-pat-id                      pic x(15).
*!      25  filler                              pic xx.
        25  filler                              pic x.

15  clmhdr-p-claims-mstr.
    20  clmhdr-p-key-type                    pic a.
    20  clmhdr-p-data.
        25  clmhdr-p-batch-nbr.
            30  clmhdr-p-clinic-nbr-1-2      pic  99.
*!          30  clmhdr-p-doc-nbr             pic 9(4).
            30  clmhdr-p-doc-nbr             pic x(3).
            30  clmhdr-p-week                pic 99.
            30  clmhdr-p-day                 pic 9.
        25  clmhdr-p-claim-nbr               pic 99.
        25  clmhdr-p-oma-cd                  pic x999.
        25  clmhdr-p-oma-suff                pic x.
        25  clmhdr-p-adj-nbr                 pic x.

*----------------------------------------

