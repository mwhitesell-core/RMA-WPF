


   THIS DEFINITION NO LONGER USED !!!!!!





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
*
*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

* insert this warning message from "f002_duplicate_fd_warning.fd"
***************** warning *********************
**                                           **
** any changes to this fd must also be made  **
** to the other 3 in the following list:     **
**                                           **
**        "f002_claims_hdr_rec.ws            **
**        "f002_claims_dtl_rec.ws            **
**        "f002_claims_mstr_rec1_2.ws        **
**        "f002_clm_mstr_p_access.ws         **
**                                           **
***************** warning *********************

*
*       note 1: key for this file is the claim-id which is prefaced by a
*               1 character type field -- 'p' = patient id (i key)
*                                         'b' = batch nbr
*       note 2: - the claim detail data recs are written with valid oma
*                   codes, the detail description recs use an oma code of 'zzzz'
*                   and adjustment detail records use and 'adj-cd' of "1")

01  claim-header-rec.

    05  clmhdr-claim-id.
        10  clmhdr-batch-nbr                    pic 9(9).
        10  clmhdr-batch-nbr-r1 redefines clmhdr-batch-nbr.
            15  clmhdr-clinic-nbr-1-2           pic 99.
            15  clmhdr-doc-nbr                  pic 9(4).
            15  clmhdr-week                     pic 99.
            15  clmhdr-day                      pic 9.
        10  clmhdr-batch-nbr-r2 redefines clmhdr-batch-nbr.
            15  filler                          pic xx.
            15  clmhdr-batch-nbr-3-6            pic 9(4).
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
*****   ('clmhdr-card-colour' replaced by 'adjust-sub-type' --
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
    05  clmhdr-reference-r redefines clmhdr-reference.
        10  clmhdr-ref-date1.
            15  clmhdr-ref-date-yy              pic 9(2).
            15  clmhdr-ref-date-mm              pic 9(2).
            15  clmhdr-ref-date-dd              pic 9(2).
        10  clmhdr-ref-inits                    pic x(3).
    05  clmhdr-reference-r1 redefines clmhdr-reference-r.
        10  filler                              pic x.
        10  clmhdr-ref-date2                    pic x(6).
        10  filler                              pic x(2).
    05  clmhdr-reference-r2 redefines clmhdr-reference-r1.
        10  filler                              pic x(2).
        10  clmhdr-ref-date3                    pic x(6).
        10  filler                              pic x(1).
    05  clmhdr-reference-r3 redefines clmhdr-reference-r2.
        10  filler                              pic x(3).
        10  clmhdr-ref-date4                    pic x(6).
    05  clmhdr-date-admit.
*           (note - admit-yy must be left alpha-numeric)
        10  clmhdr-date-admit-yy                pic xx.
        10  clmhdr-date-admit-mm                pic 99.
        10  clmhdr-date-admit-mm-r redefines clmhdr-date-admit-mm
                                                pic xx.
        10  clmhdr-date-admit-dd                pic 99.
        10  clmhdr-date-admit-dd-r redefines clmhdr-date-admit-dd
                                                pic xx.
    05  clmhdr-date-admit-r redefines clmhdr-date-admit
                                                pic 9(6).
    05  clmhdr-doc-dept                         pic 99.
    05  clmhdr-date-cash-tape-payment           pic x(6).
    05  clmhdr-direct-bills-clm-info  redefines clmhdr-date-cash-tape-payment.
        10  clmhdr-msg-nbr                      pic xx.
        10  clmhdr-reprint-flag                 pic x.
        10  clmhdr-sub-nbr                      pic x.
        10  clmhdr-auto-logout                  pic x.
        10  clmhdr-fee-complex                  pic x.
    05  clmhdr-curr-payment                     pic s9(5)v99.

    05  clmhdr-date-period-end.
        10  clmhdr-period-end-yy                pic 99.
        10  clmhdr-period-end-mm                pic 99.
        10  clmhdr-period-end-dd                pic 99.
    05  clmhdr-cycle-nbr                        pic 99.
    05  clmhdr-date-sys                         pic x(6).
    05  clmhdr-amt-tech-billed                  pic s9(4)v99.
    05  clmhdr-amt-tech-paid                    pic s9(4)v99.
    05  clmhdr-tot-claim-ar-oma                 pic s9(5)v99.
    05  clmhdr-tot-claim-ar-ohip                pic s9(5)v99.
    05  clmhdr-manual-and-tape-paymnts          pic s9(5)v99.
    05  clmhdr-status-ohip                      pic xx.

    05  clmhdr-orig-batch-id.
        10  clmhdr-orig-batch-nbr.
            15  clmhdr-orig-batch-nbr-1-2       pic  99.
            15  clmhdr-orig-batch-nbr-3         pic   9.
            15  clmhdr-orig-batch-nbr-4-9       pic 9(6).
        10  clmhdr-orig-batch-nbr-next-def      redefines clmhdr-orig-batch-nbr.
            15  filler                          pic  99.
            15  filler                          pic   9.
            15  clmhdr-orig-batch-nbr-4-6       pic 9(3).
            15  clmhdr-orig-batch-nbr-7-8       pic  99.
            15  clmhdr-orig-batch-nbr-9         pic   9.
        10  clmhdr-orig-claim-nbr               pic  99.
    05  clmhdr-orig-batch-id-r  redefines clmhdr-orig-batch-id.
        10  clmhdr-orig-complete-batch-nbr      pic 9(11).
    05  clmhdr-manual-review                    pic x.
    05  clmhdr-submit-date.
        10  clmhdr-submit-yy                    pic 99.
        10  clmhdr-submit-mm                    pic 99.
        10  clmhdr-submit-dd                    pic 99.
    05  clmhdr-confidential-flag                pic x.
    05  clmhdr-serv-date                        pic 9(6).
    05  clmhdr-reserve-for-future               pic x(6).
*mf moved external keys into data record
*mfcopy "f002_key_claims_mstr_mf.ws" replacing "key-clm-" by "clmhdr-b-".

01  claim-detail-rec.

    05  clmdtl-id.
        10  clmdtl-batch-nbr                    pic 9(9).
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
            15  clmdtl-sv-yy                    pic 99.
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
        10  clmdtl-date-period-end              pic x(6).
        10  clmdtl-cycle-nbr                    pic 999.

        10  clmdtl-diag-cd                      pic 999.
        10  clmdtl-line-no                      pic 99.
        10  clmdtl-reserve-for-future           pic x(8).

    05  clmdtl-desc-rec redefines clmdtl-det-rec.
        10  clmdtl-desc                         pic x(22).
        10  filler                              pic x(42).

    05  clmdtl-orig-batch-id.
        10  clmdtl-orig-batch-nbr               pic 9(9).
        10  clmdtl-orig-batch-nbr-r redefines clmdtl-orig-batch-nbr.
            15  clmdtl-orig-batch-nbr-1-2       pic 99.
            15  clmdtl-orig-batch-nbr-3         pic 9.
            15  clmdtl-orig-batch-nbr-4-9       pic 9(6).
        10  clmdtl-orig-claim-nbr-in-batch      pic 99.
    05  clmdtl-orig-batch-id-r  redefines clmdtl-orig-batch-id.
        10  clmdtl-orig-complete-batch-nbr      pic 9(11).

*mf moved external keys into data record
*mfcopy "f002_key_claims_mstr_mf.ws" replacing "key-clm-" by "clmdtl-b-".
*-------------------
05  k-clmdtl-claims-mstr.
*        key type: 'b' = batch id
*                  'p' = patient id (i key)
    20  k-clmdtl-b-key-type                        pic x.
    20  k-clmdtl-b-data.
        25  k-clmdtl-b-batch-num                   pic 9(9).
        25  k-clmdtl-b-batch-nbr redefines k-clmdtl-b-batch-num.
            30  k-clmdtl-b-clinic-nbr-1-2          pic 99.
            30  k-clmdtl-b-doc-nbr                 pic 9(4).
            30  k-clmdtl-b-doc-nbr-r redefines k-clmdtl-b-doc-nbr.
                35  k-clmdtl-b-doc-nbr-1           pic 9.
                35  k-clmdtl-b-doc-nbr-2-4         pic 999.
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
        25  filler                                 pic xx.

10  k-clmdtl-p-claims-mstr.
    20  k-clmdtl-p-key-type                        pic x.
    20  k-clmdtl-p-data.
        25  k-clmdtl-p-batch-nbr.
            30  k-clmdtl-p-clinic-nbr-1-2      pic  99.
            30  k-clmdtl-p-doc-nbr             pic 9(4).
            30  k-clmdtl-p-week                pic 99.
            30  k-clmdtl-p-day                 pic 9.
        25  k-clmdtl-p-claim-nbr               pic 99.
        25  k-clmdtl-p-oma-cd                  pic x999.
        25  k-clmdtl-p-oma-suff                pic x.
        25  k-clmdtl-p-adj-nbr                 pic x.
*-------------------------

