* file: pricing_variables_hold.ws
* purpose: hold all variables used for pricing calcuations by programs
*	   d001.cbl and newu701.cbl
*    note: newu701 needs more variables and requires a 50 occurs statment
*	   which d001 doesn't need by will work with these larger 
*	   definitions


* 00/aug/03 B.E. - taken from d001.cbl/newu701.cbl
* 00/aug/30 B.E. - removed ss-max-nbr-oma-det-rec-allow from this copybook      
*                  since it must be changed based upon which pgm uses
*                  the copybook.
* 00/aug/10 B.E. - added hold-ss-curr-prev
* 00/aug/31 B.E. - added hold-sv-nbr-serv-incoming
* 00/sep/04 B.E. - rename 'hold-sv-nbr-days-conseq' to 'hold-sv-nbr-days-conseq'
*		   and changed size of 'hold-sv-nbr' from 99 to 9.
* 00/sep/12 B.E. - changed sequence of fields hold-sv-nbr and  hold-sv-day
* 00/sep/25 B.E. - added 'hold-description-tmp' to be used to translate
*		   user entered 'short forms' into longer text 
* 00/oct/25 B.E. - changed occurrences from 40 to 50 to handle web claim details
* 01/apr/23 B.E. - changed fees from 3 to 4 decimals to handle the 4 decimal
*		   percentages
* 01/aug/29 B.E. - added flag-desc-rec 
* 01/sep/25 B.E. - added flag-update-suspense, flag-create-priced-file
* 02/jan/16 B.E. - added flag-payroll to indicate payroll claims being 
*		   paid under
* 06/feb/15 B.E. - increase occurs size of hold-oma-rec from 50 to 60 
*		 - increase hold-grp-tot & hold-grp-nbr from 50 to 60
* 06/jun/30 b.e. - increase feb/15 stuff from 60 to 70
* 11/may/02 M.C. - expand hold-oma-cd-num into digit 1,2,3
* 12/Mar/28 M.C. - increase feb/15 stuff from 70 to 90
*======================================================================
*       (subscripts for this table in 'ss-oma-subscripts')
01  hold-claim-detail-recs.
    05  hold-oma-recs.

        10  hold-accounting-nbr         pic x(8).

*======================================================================
*========================  W A R N I N G  ! ! !  ======================
* WARNING #1 - length of 'hold-oma-rec'
*      if the length of the 'hold-oma-rec' is changed then the field
*     'hold-sort-oma-rec' must also be changed to reflect the new size.
* WARNING #2  - if the value                    '70' below changes then
*		the corresponding occurs must also be changed to match
*			hold-grp-tot
*			hold-grp-nbr 
*========================  W A R N I N G  ! ! !  ======================
* WARNING- keep ss-max-nbr-oma-det-rec-allow in sync with the occurs value
*       10  hold-oma-rec                  occurs  50  times.
*       10  hold-oma-rec                  occurs  60  times.
*       10  hold-oma-rec                  occurs  70  times.
        10  hold-oma-rec                  occurs  90  times.
* WARNING- keep ss-max-nbr-oma-det-rec-allow in sync with the occurs value
            15  hold-oma-cd.
                20  hold-oma-cd-alpha   pic x.
* 2011/05/02 - MC
*               20  hold-oma-cd-num     pic 999.
                20  hold-oma-cd-num. 
                    25  hold-oma-cd-num-1	pic 9.
                    25  hold-oma-cd-num-2	pic 9.
                    25  hold-oma-cd-num-3	pic 9.
* 2011/05/02 - end
            15  hold-oma-suff           pic a.

*               (added incoming svcs 00/aug/31 B.E.)
            15  hold-sv-nbr-serv-incoming pic 99.
            15  hold-sv-nbr-serv          pic 99.

            15  hold-admit-date-icc.
                20  hold-sv-date.
*y2k
*                   25  hold-sv-date-yy pic 99.
                    25  hold-sv-date-yy pic 9(4).
		    25  hold-sv-date-yy-r redefines hold-sv-date-yy.
		        30 hold-sv-date-yy-12     pic 99.
			30 hold-sv-date-yy-34	  pic 99.
                    25  hold-sv-date-mm pic 99.
                    25  hold-sv-date-dd pic 99.
                20  hold-icc-cd.
                    25  hold-icc-sec    pic xx.
                    25  hold-icc-grp    pic 99.
*y2k
            15  hold-key-r  redefines  hold-admit-date-icc.
*               20  filler              pic x(4).
                20  filler              pic x(6).
*               (sort key is service-date-dd + icc code)
                20  hold-sort-key-1     pic x(6).
            15  hold-sv-nbr-days-conseq  occurs  3  times.
*		    (00/sep/12 B.E. changed sequence of day/nbr)
                20  hold-sv-nbr         pic 9.
                20  hold-sv-day         pic xx.
                20  hold-sv-day-num redefines hold-sv-day pic 99.
*	                20  hold-sv-nbr         pic 99.

            15  hold-override-price     pic x(1).
            15  hold-bilateral          pic x(1).
            15  hold-fee-incoming       pic s9(5)v99.

            15  hold-fee-oma            pic s9(5)v99.
            15  hold-fee-oma-r redefines hold-fee-oma  pic s9(7).
            15  hold-fee-ohip           pic s9(5)v99.
            15  hold-fee-ohip-r redefines hold-fee-ohip pic s9(7).
            15  hold-priced-tech        pic s9(5)v99.
            15  hold-basic-tech         pic s9(5)v99.
            15  hold-basic-prof         pic s9(5)v99.
            15  hold-basic-fee          pic s9(5)v99.
*               (8 indicators for each detail rec - 
*		 see definitions below (eg. ss-diag-ind))
            15  hold-oma-rec-ind        pic x           occurs  8  times.
*               (10 possible add on codes for each detail rec)
            15  hold-oma-add-on-cd      pic x999        occurs  10  times.
            15  hold-oma-ind-card-requireds.
                20  hold-oma-ind-card-required pic x    occurs 3 times.

*               (fees are stored as: 1st occur = 'oma'
*                                    2nd occur = 'ohip' )
            15  hold-oma-fees    occurs  2  times.
*		    (oma fees changed from 2 to 3 decimals)
*	               20  hold-oma-fee-1      pic s9(5)v99.
*	               20  hold-oma-fee-2      pic s9(5)v99.
*		    (oma fees changed from 3 to 4 decimals - 2000/apr/23)
*                      20  hold-oma-fee-1      pic s9(4)v999.
*                      20  hold-oma-fee-2      pic s9(4)v999.
                20  hold-oma-fee-1      pic s9(4)v9999.
                20  hold-oma-fee-2      pic s9(4)v9999.
*	 	    (00/aug/03 B.E. - new min/max fields)
	        20  hold-fee-min	pic s9(4)v999.
	        20  hold-fee-max	pic s9(4)v999.
                20  hold-oma-fee-anae   pic 99.
                20  hold-oma-fee-asst   pic 99.

*               (00/aug/10 B.E.
*	         each oma code can have different effective date and therefore
*		 lines may vary between current and previous rates)
	    15  hold-ss-curr-prev	pic 9 comp.

            15  hold-flag-fee-used      pic x.
            15  hold-flag-sec-group.
                20  hold-flag-sec       pic  9.
                20  hold-flag-grp       pic  9.
            15  hold-diag-cd            pic  999.
            15  hold-line-no            pic 99.

*       NOTE:The value below only changes if the length of the above
*	     record is increased - not if the # occurances of it increases
*       (00/aug/03 B.E. from 168 to 200 fold hold-fee-min/max fields)
*       (00/aug/04 B.E. from 200 to 220 when copybook created for d001/newu701
*       (00/aug/08 B.E. from 220 to 234 added 2nd dimension for min/max)
*       (00/aug/10 B.E. from 234 to 274 added hold-ss-curr-prev added)
*     05  hold-sort-oma-rec               pic x(168).
*     05  hold-sort-oma-rec               pic x(200).
*     05  hold-sort-oma-rec               pic x(220).
*     05  hold-sort-oma-rec               pic x(234).
      05  hold-sort-oma-rec               pic x(274).

    05  hold-descriptions.
        10  hold-desc-1                 pic x(22).
        10  hold-desc-2                 pic x(22).
        10  hold-desc-3                 pic x(22).
        10  hold-desc-4                 pic x(22).
        10  hold-desc-5                 pic x(22).

    05  hold-descs-r   redefines   hold-descriptions.
        10  hold-descs  occurs 5 times.
           15  hold-desc               pic x(22).
*            15  orig-desc.
*		20 orig-desc-start	pic x(03).
*		20 orig-desc-end	pic x(19).
    05  hold-desc-tmp.
	10 hold-desc-tmp-start		pic x(03).
	10 hold-desc-tmp-end		pic x(19).

    05  hold-basic-times-desc.
        10  hold-basic-plus-times-desc     occurs  2  times.
            15  hold-basic-units        pic zz9.
            15  hold-basic-b            pic xxx.
            15  hold-times-units        pic zz9.
            15  hold-times-t            pic xxx.

01  hold-grp-totals-tbl.
*   05  hold-grp-tot                    pic s9(5)v99 occurs  60 times.
*   05  hold-grp-nbr                                 occurs  60 times.
*   05  hold-grp-tot                    pic s9(5)v99 occurs  70 times.
*   05  hold-grp-nbr                                 occurs  70 times.
    05  hold-grp-tot                    pic s9(5)v99 occurs  90 times.
    05  hold-grp-nbr                                 occurs  90 times.
        10  hold-grp-nbr-sec            pic 9.
        10  hold-grp-nbr-grp            pic 9.


*
*       (maximum values or limits that may have to be changed
*               if record layouts are altered)
*
77  ss-max-nbr-locs-in-doc-rec                  pic 99  comp    value  30.
77  ss-max-nbr-of-desc-rec-allow                pic 99  comp    value  5.

01  flag-desc-rec				pic xx.
    88 basic-plus-times-entry			value "BT".
    88 adjudication-desc-entry			value "A".

01  flag-update-suspense			pic x.
    88 update-suspense				value "Y".
    88 dont-update-suspense			value "N".

01  flag-create-priced-file			pic x.
    88 create-priced-file			value "Y".
    88 dont-create-priced-file			value "N".

01  flag-claim-source				pic x.
    88 web-claim				value "W".
    88 online-claim				value "O".
    88 diskette-claim				value "D".
    88 price-only-claim				value "P".

01  flag-payroll				pic x.

01  flag-retain-prices				pic x.
    88 retain-incoming-prices			value "Y".
    88 override-with-rma-prices			value "N".

*   (subscripts for the 'hold-oma-rec-ind' occurrence above)
77  ss-diag-ind                                 pic 99  comp  value 1.
77  ss-phy-ind                                  pic 99  comp  value 2.
77  ss-hosp-nbr-ind                             pic 99  comp  value 3.
77  ss-i-o-ind                                  pic 99  comp  value 4.
77  ss-admit-ind                                pic 99  comp  value 5.
77  ss-add-on-perc-or-flat-ind                  pic 99  comp  value 6.
77  ss-special-m-suffix-ind                     pic 99  comp  value 7.
77  ss-tech-ind                                 pic 99  comp  value 8.
