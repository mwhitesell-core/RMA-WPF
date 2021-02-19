identification division.  
program-id. d003.  
author. dyad computer systems inc.  
installation. rma.  
date-written. 80/01/31.  
date-compiled.  
security.  
*  
*    files	: f002 - claims master  
*		: f002 - claim shadow master  
*		: f010 - patient master  
*		: f011 - pat mstr eligibility history
*		: f020 - doctor master  
*		: f085 - rejected claims  
*		: f086 - corrected pat id  
*		: f090 - constants master  
*		: f091 - diagnostic master  
*		: f094 - message and subdivision master  
*  
*    program purpose : claim query  
*  
*  
*   revised 83/12 (a.j.) - provide update capability for direct  
*			    bill data carried on claim header and  
*			    for the multiple description detail  
*   revised 84/04 (a.j.) - provide function key mode to display  
*			    tech/prof amounts on detail lines instead  
*			    of service occurences  
*   revised 84/07 (a.j.) - maintain claim shadow file on subdivision  
*			    change  
*  
*   revised 84/08 (a.j.) - provide function key mode to only display  
*                           claims for an operator supplied agent code  
*                           when in sequential display modes  
*  
*   revised 84/11 (m.s.) - ignore the sign for "CURR PAY" on display,  
*			    and add "DATE LAST STMT" for display.  
*  
*   revised 84/12/28 (i.w)  
*			  - add subscriber msg nbr and effective date to  
*			    subscr mstr now opened for i-o.  
*			    smsi 79.1.  
*  
*   revised 85/01/02 (i.w)  
*			  - remove the subscriber last stmnt date from  
*			    screen as the clmhdr ref field is now being  
*			    used.  
*  
*   revised 85/02/08 (m.s.)  
*			  - pdr 253  
*			  - add the hold-desc-feedback-claims and  
*			    hold-desc-claims-occur, so this can  
*			    correct the update and deletion to  
*		     	    the claims-mstr properly.  
*			  - change the desc fields on the screen  
*			    from 20 to 22 characters.  
*  
*   revised 85/02/25 (i.w.) - change code for i-key access.  
*  
*   revised 85/12/13 (m.s.) - pdr 287  
*			    - change the logic in subroutine ga0  
*  
*   revised 85/12/19 (m.s.) - pdr 281  
*			    - change in pa3-read-clm-move-to-tbl  
*			      subroutine for brief mode  
*  
*   revised   may/87 (s.b.) - conversion from aos to aos/vs.  
*                             change field size for  
*                             status clause to 2 and  
*                             feedback clause to 4.  
*  
*   revised 87/09/29 (m.s.) - cosmetic changes on the pat/subscr screen  
*			    - change the screen the same as m010  
*  
*   revised 87/12/23 (j.l.) - pdr 336  
*			      query by ohip nbr, use the same method  
*			      as in query by acronym.  
*  
*   revised dec/87 (j.l.) - pdr 356  
*		          - after error message is displayed, hit  
*			    space bar to return to keying field  
*  
*   revised feb/89 (s.f.) - pdr 400  
*			  - change to allow agent 4 to be treated  
*			    thE same as agent 6  
*  
*   revised mar/89 (s.f.) - sms 115  
*		          - make sure file status is pic xx ,feedback is  
*			    pic x(4) and infos status is pic x(11).  
*  
*   revised jun/89 (s.f.) - sms 116  
*		          - add dept number to show up on the screen  
*			  
*   revised dec/89 (s.f.) - sms 126  
*		          - allow 8 claim details instead of 6  
*			  
*   revised jun/90 (m.c.) - pdr 440  
*			  - correct the ws-tbl-dtl from 5 to 7  
*			    and adjust the necessary reset.  
*  
*   revised oct/90 (m.c.) - sms 133  
*			  - display the clmhdr-adj-cd-sub-type (source  
*			    code) on the screen  
*  
*   revised may/91 (bml)  - sms 138  
*                         - allow changeable fields in claim header  
*                           and claim detail with edit checks as  
*                           per d001.  
*  
*   revised sep/91 (bml)  - add 13 to claim description layout.  
*  
*   revised mar/92 (y.b.) - add new hospital number 1146 (e000)  
*  
*   revised jun/92 (m.c.) - display the technical and professional  
*			    breakdown for adjustments and payments  
*			    as the regular claims.  
*  
*  
*   revised mar/93 (m.c.) - pdr 569  
*			  - show the version code on the screen  
*  
*  
*   revised apr/93 (m.c.) - sms 141  
*			  - change the screen layout  
*			  - allow to change patient info  
*			  - add two new files f085 & f086  
*			  - check for confidentiality claims  
*  
*   revised may/93 (m.c.) - pdr 572  
*			  - when user change birth date and does not  
*			    match with the chart nbr, display warning  
*			    message  
*  
*   revised jun/93 (y.b.) - sra  
*			  - update confidential code listing to include  
*			    a195a, c195a, c193a and c192a  
*			  
*   revised jul/93 (m.c.) - pdr 577/578  
*			  - change the ga1 and ga11 subroutines into  
*			    the copylib "D001_D003_CONFIDENTIALITY_CHECK"  
*			  - if there are any addition or changes, please  
*			    modify the above copylib  
*  
*   revised aug/93 (m.c.) - pdr 575  
*			  - allow user to enter 'a' for automatic  
*			    adjustment for the claim  
*			  - create a new sequential file which will  
*			    store the claim info to be adjusted  
*                         - only allow user rma14/con3, rma19/con10,  
*			    rma/con6 and dyad/con19 for automatic  
*			    adjustment  
*  
*   revised sep/93 (m.c.) - pdr 582  
*			  - display the percent for miscellaneous  
*			    payment  
  
*   revised sep/93 (y.b.) - add 'y' clmhdr-tape-submit-ind  
*  
*  
*   revised feb/93 (m.c.)  - pdr 594  
*			   - change the hold-version-cd to pic xx  
*			     instead of pic x.  
*  
*   revised may/94 (m.c.)  - do not allow user to adjust current month  
*		             claims  
*  
*   revised jun/94 (m.c.)  - pdr 597  
*			   - edit on first char of hosp with first char  
*			     of location  
*  
*   revised sep/94 (bml)   - changed the consoles allowed to create  
*                            adjustment records, added 16 and 25  
*                            removed 06.  
  
*   revised feb/95 (yas)   - only allow user rma14/con7 and rma19/con8  
*                            rma4/con19 rma/con25 dyad/con19  
*                            for automatic adjustments  
*  
*   revised mar/95 (yas)   - add new loacation v330 "1149"  
*  
*   revised may/95 (m.c.)  - pdr 618  
*			   - do not allow user to adjust current cycle  
*			     claims or claims has not submitted to ohip,  
*			     modify in ha0 subroutine  
*   revised nov/95 (yas)   - add new loacation i300 "3309"  
*  
*   revised dec/95 (yas)   - only allow user con10 and con36 and take  
*                            out con8  
*                            for automatic adjustments  
*  
*   revised jan/96 (yas)   - pdr 641  
*			   - modify ha0 subroutine comment out if  
*			     clmhdr-cycle = constants cycle  
*			     page 31 line 51 55  
*   revised mar/96 (mc)    - pdr 637  
*			   - show ohip reference nbr of the claim  
*			     on the screen  
*  99/jan/14 B.E.          - changed call back to menu.
*                          - initialized 'end-job' before call to ab0 so that
*                            pgm could be called more than once from menu
*  99/jan/15 B.E.	   - y2k
*  99/jul/09 B.E.          - fixed bug whereby claim with repetitive services
*                            would lose these values when the claim details
*                            details where updated.
*  99/oct/10 B.E.          - fixup modification of claim/patient so that entire
*                            claim (header/detail recs) not updated each time
*			     any part of claim is modified.
*  
*  99/nov/26 B.E.	   - fix alignment of bottom of screen (message
*			     effective date, etc. 
*			   - added 8 digit year and edit for entry of date
*			     within refererence field
*			   - pgm not following code sequentially and description
*			     records not being updated - removed 'section'
*			     designations, added 'move 'x' to dummy to eliminate
*			     paragraphs with no code.
*			   - fixed bug in that description records not being
*			     added - filler within hold-desc-rec increased
*			     to match y2k increase in size of record.
*  99/dec/07 B.E.	   - fix update of patient last eligibility maintence
*			     date update so that sys-date is used.
* 1999/dec/16 B.E. - remove input of hospital until clmhdr has room for 4 digit
*                    hospital
* 2000/feb/24 M.C. - change datatype for hold-key-pat-mstr 
* 2000/may/05 B.E. - changed elig-flag into 2 fields -  elig-flag-version-cd 
*		     and elig-flag-birth-date so that it could be determined
*		     which eligibility field was actually changed and 
*		     only that field is then updated into the patient mstr rec.
* 2000/may/01 B.E. - added 'C'ard submitted as valid value for field
*		     clmhdr-tape-submit-ind
* 2000/may/15 B.E. - major rewrite of logic concerning modification of claim.
*		     Several commands were renamed and now if a User is changing
*		     several "sections" of the claim(header,detail,patient,etc.)
*		     after each section the User is asked to confirm the update
*		     of the data with a Y/N/M prompt.
*		     If eligibility info of patient changed and the patient
*		     had a message, the message is blanked and the "R"esubmit
*		     indicator set.
* 2000/may/17 B.E. - added back call to routine ga3 to write corrected-patient
*		     record if eligibility info is changed. Call to this
*		     routine somehow got lost.
* 2000/may/17 B.E. - added new file f011-pat-mstr-elig-history file to track
*		     changes made to patient eligbility info. In doing so it was
*		     necessary to add qualification of key-pat-mstr and
*		     pat-health-nbr field to say either "of pat-mstr' or
*		     'of f011-pat-elig-history'.
* 2000/may/29 B.E, - added new values for 'ohip submit ind' of "C"ard being
*		     manuall submitted to OHIP and "X" which forces a resubmit
*		     of the claim regardless of other conditions that the
*		     the resubmission program might check on. 
* 2000/jun/05 B.E. - when attempting to "A"djust off a claim the system checks
*	    	     the claim has been submitted to OHIP. Code used to 
*		     check that the claim has a 'submission date' but was
*		     changed to see that the claim's PED and CYCLE don't match.
* 2000/jun/09 B.E. - if patient eligibility info changed then "X" moved to 
*		     submit-ind indicator instead of "R" to ensure that claim
*		     is selected for resubmission
* 2000/jun/12 B.E. - If user displayed a series of patient claims and then
*		     tried to do same thing with another patient, the pgm
*		     didn't allowed selection of "CORRECT (Y/N)" claim 
* 		     but just went to the first claim.
*		     Reset 'flag-ref-fld' to blank after pass through one 
*		     display of ab0 mainline.
* 2000/jun/20 B.E. - added parameter-file to contain claim patient's i-key
*                    and call to d003_1 to display f011 patient eligbility
*                    history
* 00/sep/15.B.E. - ensure that valid values are entered for acpt-claim-clinic-1
*
* 00/oct/02 B.E. - d003.cbl not changed but change to yy0- copybook code
*		   so d003 recompile and retested
* 00/oct/23 B.E. - error msg #34 changed to reflect values being editted. 
*
* 01/jan/24 B.E. - warning 15 incorrectly displayed as #14. Code corrected
*		   to display the 15th error message.
* 01/may/07 B.E. - professional $ column in tech/prof breakdown display mode
*		   now calculated using OHIP $ if not direct bill id agent
*		   claim
* 01/jun/18 B.E. - display display alignment of description records 2 and 4
*		   to move them 1 character to the left. This mirrows how
*		   the description records are concatenated and printed
*		   on the direct bill statements and assist in entering
*		   data so that it prints nicely formatted on the statements.
*		   For non-direct bill claims format is not as important
*		   since they are not printed.
* 01/jul/30 B.E. - 'A'utomatic adjustment procedure obtained the 1st claim 
*		   detail and used the OMA code to create the adjustment.
*		   If the first record of the claim was NOT a claim detail
*		   record (adjustment/payment) then a blank value was obtained.
*		   The program changed to search the details until a OMA code
*		   obtained in the detail records.

* 01/jun/19 B.E. - add access of f030-locations master in order to read and
*		   display the hopsital number which is tied directly to
*		   the claim's location
*
* 01/nov/03 B.E  - display new clmhdr-payroll field
*
* 01/dec/07 B.E. - subscript out of range error. changed subscript names
*		   from 'i' and 'subs' to more specific names and changed
*		   Acronym Search screen to skip selection screen if only
*		   1 patient matches search criteria.
* 01/dec/17 B.E. - corrections to change made 01/jul/30 for 'automatic' 
*		   adjustments. The adj-claim-file is now update with the
*		   oma code and service date of the claim detail with the
*		   larges balance due.
* 02/apr/05 M.C. - add the new prefix '$' for chart nbr access, modify in
*	          ab0-10-acpt-clm-id  and  ba0-read-non-acr-pat subroutines.
* 02/jun/17 M.C. - add the logic to determine what hospital chart nbr entered
*		   when user enters claims by chart nbr, access by the correct
*		   chart nbr index since now there is a separate field/index 
*		   for each hospital chart nbr
*		 - add subroutine da61-read-chrt-pat-mstr,modify da0 subroutine
* 02/nov/07 M.C. - to refresh the detail lines (12 - 19) before displaying the
*	           detail on the second screen  
*		 - at the detail, display the clmdtl-fee-ohip for all agent;likewise,
*		   for calculating bal due, use ohip amt and paid amt for all agent
* 02/nov/12 M.C. - allow the user to enter 'O' to call M088.qks 
* 03/nov/05 b.e. - alpha doctor nbr
* 03/oct/27 b.e. - added display/update of service/eligibilty error/status
* 04/jan/05 b.e. - adj-batch-nbr missed in alpha doctor nbr conversion
* 04/feb/25 M.C. - include pat-chart-nbr-2 to 5 in f086-pat-id for eligibility changes
* 04/feb/26 M.C. - add locations-mstr and display ws-hosp-nbr from location-mstr based
*                  on the criteria
* 04/mar/17 M.C. - if user put a status of 'X' and it is a AFP claim with reason code 'I2',
*                  or no outstanding balance, display error on the screen
* 04/may/11 M.C. - correct field size for adj-batch-nbr from 9(8) to x(8)
*		 - change parameter-batch-nbr from 9(9) to x(8) in  "parameter_file.fd".  
* 04/may/19 M.C. - check w-iconst-clinic-card-colour with 'Y' only
* 04/jun/14 M.C. - change the fd for f002-claims-extra from size 22 to size 21
* 05/jun/20 M.C. - allow two more users(rma3-Thekla & rma16-Linda O'Hara) to do
*		   automatic adjustment
* 05/jun/20 M.C. - allow one more users(rma24-Kristin) to do automatic adjustment
* 06/feb/16 M.C. - add site-id and check chart-nbr properly based on site-id
*                - this version of program is applicable to both RMA & HSC
* 07/jan/16 M.C. - change ws-clmhdr-wk/day from numeric to alpha because for 'M'isc
*		   payment claims show alpha batch number 
*		 - also change the same in f002_claims_mstr_rec1_2.ws copybook
*		   for clmhdr-week/day
* 07/jan/30 M.C. - Yas requested to change from 'A' to '~' for automatic
*                  adjustment to avoid users to make mistakes
*                - disable Kristin to do auto adjustment
* 07/jul/03 M.C. - allow one more users(rma7 - Terry Thomson ) to do automatic adjustment
* 07/aug/14 M.C. - Yas requested to change from 'A' to '~' for automatic
*                  adjustment for help messages as well  
* 07/sep/20 M.C. - due to system change (ie different box), the user id is different from /etc/passwd
*		   compare with the old box, user id must change accordingly for users who are doing
*		   auto adjustment
* 07/oct/04 M.C. - due to system change (ie different box - RMABKP), the user id is different from /etc/passwd
*                  compare with the old box, user id must change accordingly for users who are doing
*                   auto adjustment , also add site-id = RMA for B adjustment
* 10/jun/10 brad1- add code to process new logically-deleted-flag field of f085 - rejected claims file .. 
*		   if change is made to patient's eligibility information then
*		   update existing f085 record to put 'Y' into logically deleted field
* 10/jun/21 MC1  - create $use/process_pat_eligibility_change.rtn to update f085 file
* 10/jul/12 MC2  - allow user to enter/change values in payroll field for dept 41 , 42, 43 or 75
* 11/feb/09 MC3  - when user enters 'G' at the acceptance fields, it will update 'Y' in logically-deleted-flag
*		   of f085 files for all claims
* 11/May/25 MC4  - allow users to change location only for batctrl-status = '0' or '1'
*		 - purpose to allow change in location mainly for SLI related
*		 - define f001, allow open/close
* 12/Feb/29 MC5  - edit on location code is a valid one
*		 - change hold-claim-detail-rec from 216 to 228, this may help to fix the problem of price changes
*		   when user tries to change the detail with service date or diagnostic code
* 12/Apr/17      - change the move statement after read in jc0-rewrite-detail
*		 - with above changes, no luck on changing claim detail with duplicate oma code
* 12/apr/30 brad2- fix display of Earliest Service date
* 12/May/10 MC6  - display Earliest Service date from claim header instead of claim detail
*		 - reset clmhdr-serv-date when changes have made from the detail
* 12/Aug/08 MC6  - make more correction for updating clmhdr-serv-date
* 12/Dec/19 MC7  - allow resubmit claim if health nbr = 1111111116 for CME claims
* 13/Jul/31 MC8  - comment out the edit check on error 38  REFERRING Doctor can not be SAME as OHIP Doc.
* 14/Mar/26 MC12 - As per Brad's request, add the edit check of description & reference fields to disallow '~'
* 14/Mar/26 MC13 - include the submit date check when allowing changes in clmhdr-loc (error 50)  
* 16/Mar/30 MC14 - disallow user rma3 to do auto adjustment
* 16/Jun/28 MC15 - Yasemin requests to include rma9 (Shivani) to do auto adjustment like Lori
* 16/Aug/31 MC16 - upshift version cd
* 16/Nov/24 MC17 - Yasemin requests to include rma3 (Jillian) to do auto adjustment like Lori

environment division.  
input-output section.  
file-control.  
*  
*   place your file select statements here  
*  
* 2011/05/25 - MC4 
    copy "f001_batch_control_file.slr".
* 2011/05/25 - end

    copy "f002_claims_mstr.slr".  
*  
    copy "f002_claim_shadow.slr".  
*  
    copy "f010_new_patient_mstr.slr".  
*  
*mf    copy "f010_new_patient_mstr_chrt.slr".  
*  
*mf    copy "f010_new_patient_mstr_acr.slr".  
*  
*mf    copy "f010_new_patient_mstr_hc.slr".  
*  
*mf    copy "f010_new_patient_mstr_od.slr".  
*  
    copy "f011_pat_mstr_elig_history.slr".
*
    copy "f020_doctor_mstr.slr".  
*  
    copy "f030_locations_mstr.slr".
*
    copy "f085_rejected_claims.slr".  
*  
**  copy "F086_PAT_ID.SLR".  
select corrected-pat  
	assign        to "$HOME/f086_pat_id.d003"  
        file status   is status-corrected-pat.  
*  
    copy "f090_constants_mstr.slr".  
*  
    copy "f091_diagnostic_codes.slr".  
*  
    copy "f094_msg_sub_mstr.slr".  
  
    select resubmit-file  
	assign to "$pb_data/resubmit.required"  
	file status is status-resub-file.  
  
    select adj-claim-file  
	assign to "$pb_data/adj_claim_file.dat"  
	file status is status-adj-claim-file.  
  
  
    select claims-extra-mstr  
*	assign index to "F002_CLAIMS_EXTRA.00.IDX"  
*mf	assign data  to "F002_CLAIMS_EXTRA.DB"  
	assign to disk "$pb_data/f002_claims_extra"  
	organization is indexed  
	access mode is dynamic  
	record key is clmhdr-rma-clm-nbr  
	status is status-cobol-claims-extra.  

*
    copy "parameter_file.sls". 
*
data division.  
file section.  
*  
* 2011/05/25 - MC4
    copy "f001_batch_control_file.fd".
* 2011/05/25 - end

copy "f002_claims_mstr.fd".  
*  
    copy "f002_claim_shadow.fd".  
*  
    copy "f010_patient_mstr.fd".  
*  
*mf    copy "f010_patient_mstr_chrt.fd".  
*  
*mf    copy "f010_patient_mstr_acr.fd".  
*  
*mf    copy "f010_patient_mstr_od.fd".  
*  
*mf    copy "f010_patient_mstr_hc.fd".  
*  
    copy "f011_pat_mstr_elig_history.fd".
*
    copy "f020_doctor_mstr.fd".  
*
     copy "f030_locations_mstr.fd".
*  
    copy "f085_rejected_claims.fd".  
*  
    copy "f086_pat_id.fd".  
*  
    copy "f090_constants_mstr.fd".  
*  
    copy "f090_const_mstr_rec_3.ws".  
*  
    copy "f091_diagnostic_codes.fd".  
*  
    copy "f094_msg_sub_mstr.fd".  
  
fd  claims-extra-mstr  
*mf 	index block contains 11 characters  
*mf 	data  block contains 22 characters  
*! 	      block contains 22 characters  
*! 	record      contains 22 characters . 
 	      block contains 21 characters  
 	record      contains 21 characters . 
*mf   	feedback is feedback-claims-extra.  
  
01  claims-extra-mstr-rec.  
    05  clmhdr-rma-clm-nbr.  
*!	10  clmhdr-rma-batch-nbr	pic 9(9).  
	10  clmhdr-rma-batch-nbr	pic x(8).  
	10  clmhdr-rma-claim-nbr	pic 99.  
    05  clmhdr-ohip-clm-nbr		pic x(11).  
  
fd  resubmit-file  
    record contains 5 characters.  
  
01  resubmit-rec                         pic x(5).  
  
  
fd  adj-claim-file  
*!    record contains 44 characters.  
    record contains 43 characters.  
  
  
01  adj-claim-rec.  
*!    05  adj-batch-nbr			pic 9(9).  
* 2004/05/11 - MC
*   05  adj-batch-nbr			pic 9(8).  
    05  adj-batch-nbr			pic x(8).  
* 2004/05/11 - end
    05  adj-claim-nbr			pic 9(2).  
    05  adj-oma-cd-suff			pic x(5).  
    05  adj-serv-date			pic 9(8).  
    05  adj-agent-cd			pic 9.  
    05  adj-pat-acronym			pic x(9).  
    05  adj-amt-bal			pic s9(5)v99.  
    05  adj-diag-cd			pic 9(3).  
    05  adj-line-no			pic 99.  
  
*  
    copy "parameter_file.fd".  
  
working-storage section.  

copy "site_id.ws".

77  dummy					pic x(1).
  
77  pat-count					pic s999.  
77  pat-occur					pic 9(12).  
77  claims-occur				pic 9(12).  
77  hold-claims-occur 				pic 9(12).  
77  rej-clm-occur				pic 9(12).  
77  display-key-type				pic x(7).  
77  ss-clmdtl					pic 99  value 0.  
77  ss-pat					pic 99.  
77  end-job					pic x   value "N".  
77  tape-submit-ind-hold                        pic x.  
77  ws-prtnbr					pic xx.  
77  ws-clm-read-ind				pic xx.  
77  ws-pat-read-ind				pic xx.  
77  pline1					pic 99	value 0.  
77  pline2					pic 99	value 0.  
77  temp					pic 9(9).  
77  temp1					pic 9(9).  
77  ws-pat-ohip   				pic 9(8).  
77  ws-pat-acronym-i				pic x(10).  
77  ws-nbr-outstanding-claims			pic 9(4).  
77  ws-sel-nbr					pic 99.  
77  ws-max-nbr-pat				pic 99  value 20.  
77  ws-max-nbr-dtls-on-scr			pic 99  value 8.  
77  ws-clmhdr-manual-tape-paymnts		pic s9(5)v99.  
77  ws-brief					pic x(6) value " BRIEF".  
77  ws-normal					pic x(6) value "NORMAL".  
77  ws-tech					pic x(2) value "TP".  
77  ws-esc-toggle			pic 99.  
77  ws-max-nbr-claims-per-screen		pic 99	value 9.  
77  ws-selected-claim				pic x.  
77  ws-select-brief-claim			pic 9.  
77  ws-nbr-claims-read				pic 99.  
77  ws-dtl-ctr					pic 9.  
77  ws-hold-clmhdr-claim-id			pic x(17).  
77  confirm-space				pic x   value space.  
*  
*  eof flags  
*  
77  eof-pat-mstr				pic x	value "N".  

01  macro-line.
    02 macro                                    pic x(70) value space.
    02 macro-null-char                          pic x(1) value x"00".
  
01  ws-save-hosp				pic x(4).  
  
01  ws-hosp-nbr.  
    05  ws-hosp-nbr-1				pic x.  
    05  ws-hosp-nbr-2				pic x(3).  
  
01  ws-location.  
    05  ws-loc-1     				pic x.  
    05  ws-loc-2      				pic x(3).  
  
01  acpt-claim-or-acronym.  
    05  acpt-claim.  
	10  acpt-claim-clinic.        
	    15  acpt-claim-clinic-1		pic x.  
	    15  acpt-claim-clinic-2		pic x.  
*!	  10  acpt-claim-doc-nbr			pic 999.  
	10  acpt-claim-doc-nbr			pic xxx.  
	10  acpt-claim-week			pic 99.  
	10  acpt-claim-day			pic 9.  
	10  acpt-claim-claim-nbr		pic 99.  
	10  filler				pic x(6).  
    05  acpt-acronym-r redefines acpt-claim.  
	10  acpt-acronym			pic x(9).  
	10  filler				pic x(7).  
    05  acpt-direct-chart-r redefines acpt-claim.  
	10  acpt-direct-chart-flag		pic x.  
	10  acpt-direct-id-or-chart.  
            15 acpt-d-or-c-alpha1               pic x.  
            15 acpt-d-or-c-alpha2               pic x.  
            15 acpt-d-or-c-alpha3-12            pic x(13).  
    05  acpt-ohip-nbr-r redefines acpt-claim.  
        10  acpt-ohip-nbr-flag			pic x.  
        10  acpt-ohip-nbr			pic 9(12).  
        10  acpt-ohip-filler			pic x(3).  
    05  acpt-health-nbr-r redefines acpt-claim.  
        10  acpt-health-nbr-flag		pic x.  
        10  acpt-health-nbr			pic 9(10).  
        10  acpt-health-filler			pic x(5).  
  
    copy "f002_claim_shadow.fw".  
  
01 flag-claim-shadow				pic x.  
    88  claim-shadow-deleted			value "Y".  
  
01 hold-shadow-rec.  
    05  hold-shadow-key.  
	10  hold-shadow-clinic			pic 99.  
	10  hold-shadow-subdivision      	pic x.  
	10  hold-shadow-patient.  
	    15  hold-shadow-pat-key-type	pic a.  
	    15  hold-shadow-pat-key-data.  
		20  hold-shadow-pat-key-ohip	pic x(08).  
		20  filler			pic x(07).  
*!	  10  hold-shadow-batch-nbr		  pic 9(09).  
	10  hold-shadow-batch-nbr		pic x(08).  
	10  hold-shadow-claim-nbr		pic 9(02).  
  
    copy "f094_msg_sub_mstr.fw".  
  
77  hold-clmhdr-agent-cd			pic 9.  
77  hold-msg-nbr				pic xx.  
77  hold-sub-msg-nbr				pic xx.  
77  hold-clmhdr-reprint-flag			pic x.  
  
01  update-confirmation				pic x.  
    88  update-confirmed			value "Y".  
    88  update-rejected				value "N".  
    88  update-modify   			value "M".  
  
01  flag-msg-sub				pic x.  
    88  msg-sub-missing				value "N".  
    88  msg-sub-exists				value "Y".  
  
01  flag					pic x.  
    88 ok					value "Y".  
    88 not-ok					value "N".  
  
01  flag-pat					pic x.  
    88  flag-pat-ok				value "Y".  
    88  flag-pat-not-ok				value "N".  

01  flag-ref-fld                                pic x.
    88  flag-update-trailer-info                value "T".
    88  flag-update-done                        value "*".
    88  flag-update-done-alternative            value "^".
    88  flag-update-reference-field             value "R".
    88  flag-update-header-rec                  value "H".
    88  flag-update-details                 	value "D".
    88  flag-update-total-claim                 value "M".
    88  flag-update-patient                     value "P".
* 2007/01/30 - MC
*   88  flag-process-claim-adjustment           value "A".  
    88  flag-process-claim-adjustment           value "~".  
* 2007/01/30 - end
    88  flag-update-status-to-card              value "C".  
    88  flag-update-help                        value "?".  
    88  flag-call-elig-history-screen           value "E".  
* 2002/11/12 - MC
    88  flag-call-costing-screen           	value "O".  
* 2002/11/12 - end
* 2011/02/09 - MC3
    88  flag-update-deceased-pat           	value "G".  
* 2011/02/09 - end
  
01  flag-claim-access-type			pic x.  
  
    88  flag-claim-access-claim-nbr		value "C".  
    88  flag-claim-access-non-acr		value "N".  
    88  flag-claim-access-acronym		value "A".  
  
01  flag-found-claim				pic x.  
  
    88  flag-found-claim-y			value "Y".  
    88  flag-found-claim-n			value "N".  
  
01  flag-normal-brief				pic x.  
    88  flag-normal-brief-n			value "N".  
    88  flag-normal-brief-b			value "B".  
  
01  flag-normal-tech				pic x.  
    88  flag-normal-tech-n			value "N".  
    88  flag-normal-tech-t			value "T".  
  
01  flag-agent-code				pic x.  
    88  flag-agent-on				value 'Y'.  
    88  flag-agent-off			        value 'N'.  
  
01  flag-agent-display				pic x.  
    88  no-claims-displayed                     value 'N'.  
  
77  sel-agent-code 				pic 9.  
  
01  ws-check-digit-nbrs.  
    05  ws-temp					pic s999.  
    05  ws-temp-1				pic 99.  
    05  ws-temp-2				pic 99.  
    05  ws-temp-2-r  redefines ws-temp-2.  
	10  ws-temp-2a				pic 9.  
	10  ws-temp-2b				pic 9.  
  
*	(digit #8 is the check digit using modulus 10)  
01  ws-check-nbr.  
    05  ws-chk-nbr				pic 9(8).  
    05  ws-chk-nbr-r redefines ws-chk-nbr.  
	10  ws-chk-nbr-1			pic 9.  
	10  ws-chk-nbr-2			pic 9.  
	10  ws-chk-nbr-3			pic 9.  
	10  ws-chk-nbr-4			pic 9.  
	10  ws-chk-nbr-5			pic 9.  
	10  ws-chk-nbr-6			pic 9.  
	10  ws-chk-nbr-7			pic 9.  
	10  ws-chk-nbr-8			pic 9.  
 
* MC12
01  test-field.
    05  ws-test-field                           pic x(22).
    05  ws-test-field-r redefines ws-test-field.
        10 test-field-occ occurs 22 times       pic x(1).

77  ss-max-field-check                          pic 99 value 22.
* MC12 -end
 
  
copy "mth_desc_max_days.ws".  
  
01  hold-last-elig-mail-date.  
* (y2k - auto fix)
*   05  hold-last-elig-mail-yy			pic 99.  
    05  hold-last-elig-mail-yy			pic 9(4).  
    05  hold-last-elig-mail-yy-r redefines hold-last-elig-mail-yy.
	10  hold-last-elig-mail-yy-12		pic 9(2).
	10  hold-last-elig-mail-yy-34		pic 9(2).
    05  hold-last-elig-mail-mm			pic 99.  
    05  hold-last-elig-mail-dd			pic 99.  
  
01  hold-last-elig-maint-date.  
* (y2k - auto fix)
*   05  hold-last-elig-maint-yy			pic 99.  
    05  hold-last-elig-maint-yy			pic 9(4).  
    05  hold-last-elig-maint-yy-r redefines hold-last-elig-maint-yy.
	10  hold-last-elig-maint-yy-12 		pic 9(2).
	10  hold-last-elig-maint-yy-34		pic 9(2).

    05  hold-last-elig-maint-mm			pic 99.  
    05  hold-last-elig-maint-dd			pic 99.  
  
01  hold-last-birth-date.  
* (y2k - auto fix)
*   05  hold-last-birth-yy    			pic 99.  
    05  hold-last-birth-yy    			pic 9(4).  
    05  hold-last-birth-mm    			pic 99.  
    05  hold-last-birth-dd    			pic 99.  
  
01  hold-ohip-clm-nbr				pic x(11).  
  
* (y2k)
*01  hold-date					pic 9(5).  
*01  rem1   					pic 9(4).  
* (y2k)
*01  special-date				pic s9(9) comp.  
*01  special-date-r redefines special-date.  
*   05  spec-date-1				pic x(2).  
*   05  spec-date-2				pic x(2).  
  
  
01  hold-pat-birth-date.  
* (y2k - auto fix)
*   05  hold-pat-birth-yy			pic 99.  
    05  hold-pat-birth-yy			pic 9(4).  
    05  hold-pat-birth-mm			pic 99.  
    05  hold-pat-birth-dd			pic 99.  
  
01  hold-version-cd				pic xx.  
01  hold-mess-code				pic x(3).  
  
01  hold-claim-nbr.  
    05  hold-clinic-nbr-1-2			pic 99.  
*!    05  hold-doc-nbr				  pic 9(3).  
    05  hold-doc-nbr				pic x(3).  
    05  hold-batch-nbr				pic 9(3).  
    05  hold-claim-no				pic 99.  
  
* (y2k - auto fix)
*1  save-serv-date				pic 9(6).  
01  save-serv-date				pic 9(8).  
01  save-amt-due				pic s9(5)v99.  
01  amt-largest-diff				pic s9(5)v99.
01  ws-bal-dtl					pic s9(5)v99.

01  save-oma-cd-suff.  
    05  save-oma-cd				pic x(4).  
    05  save-oma-suff				pic x.  
  
01  elig-flag-version-cd			pic x.  
01  elig-flag-birth-date			pic x.  
* (y2k - auto fix)
*1  save-adj-serv-date				pic 9(6).  
01  save-adj-serv-date				pic 9(8).  
  
01  save-diag-cd				pic 9(3).  
01  save-line-no				pic 99.  
01  console-id					pic 999.  
01  ws-user-id					pic 999.  
77  err-ind					pic 99 	value zero.  
77  warn-ind					pic 99 	value zero.  
77  roll-lit					pic x(11) value 'Roll Screen'.  
77  roll    					pic x(4) value 'Roll'.  
  
77  hold-feedback-clmhdr			pic x(6).    
77  hold-key-claims-mstr			pic x(18).  
77  ws-clmhdr-reference-change			pic x.  
77  ws-disp-pat-key-type			pic x(7).  
*!77  ws-doc-nbr					pic 9(6).  
77  ws-file-err-msg				pic x(42)  value spaces.  
77  ws-pat-key-data				pic x(15).  
77  w-percent					pic 999v99.  
  
copy "agent_code.ws".  
  
01  ws-clmhdr-batch-nbr.  
    05  ws-clmhdr-clinic			pic 99.  
*!    05  ws-clmhdr-doc-nbr			pic 999.  
    05  ws-clmhdr-doc-nbr			pic xxx.  
* 2007/01/16 - MC - allow alpha batch number for miscellaneous payment
* 	          - change from numeric to alpha will allow to see the display properly
*   05  ws-clmhdr-wk				pic 99.  
*   05  ws-clmhdr-day				pic 9.  
    05  ws-clmhdr-wk				pic xx.  
    05  ws-clmhdr-day				pic x.  
  
  
copy "sysdatetime.ws".  
  
*  
*  subscripts  
*  
77  i 						pic 99	comp.  
77  ss						pic 99	comp.  
77  subs					pic 99	comp.  
77  ctr-nbr-matching-pats-found			pic 99	comp.  
77  subs-hosp					pic 99	comp.  
77  ss-clmdtl-oma				pic 99	comp.  
77  ss-desc					pic 9.  
*  
*	(maximum values or limits that may have to be changed  
*		if record layouts are altered)  
*  
77  ss-max-nbr-of-desc-rec-allow		pic 99	comp	value  5.  
  
  
*  
*  feedback values for all indexed files  
*  
77  feedback-claims-extra			pic x(4).  
77  feedback-claims-mstr			pic x(4).  
77  feedback-pat-mstr				pic x(4).  
77  feedback-pat-mstr-od			pic x(4).  
77  feedback-pat-mstr-hc			pic x(4).  
77  feedback-pat-mstr-acr			pic x(4).  
77  feedback-pat-mstr-chrt			pic x(4).  
77  feedback-rejected-claims			pic x(4).  
77  feedback-iconst-mstr			pic x(4).  
*  
*  eof flags  
*  
77  eof-filename-here				pic x	value "N".  
*  
*  status file indicators  
*  
*mf changed all INFOS status x(11) to CISAM/MF x(02)
77  status-common				pic x(02).  

* 2011/05/25 - MC4
77  status-batctrl-file                         pic x(11)       value zero.
77  status-cobol-batctrl-file                   pic xx          value zero.
* 2011/05/25 - end

77  status-cobol-claims-extra			pic x(2)        value zero.  
77  status-cobol-claims-mstr			pic x(2)        value zero.  
77  status-cobol-pat-mstr-chrt			pic x(2)	value zero.  
77  status-cobol-pat-mstr   			pic x(2)	value zero.  
77  status-cobol-pat-elig-history		pic x(2)	value zero.  
77  status-cobol-pat-mstr-od			pic x(2)	value zero.  
77  status-cobol-pat-mstr-acr			pic x(2)	value zero.  
77  status-cobol-pat-mstr-hc			pic x(2)	value zero.  
77  status-cobol-rejected-claims		pic x(2)       	value zero.  
77  status-cobol-doc-mstr			pic x(2)	value zero.
77  status-cobol-iconst-mstr			pic x(2)	value zero.
77  status-cobol-clm-shadow			pic x(2)	value zero.
77  status-info-rejected-claims			pic x(02)	value zero.  
77  status-claims-extra				pic x(02)	value zero.  
77  status-claims-mstr				pic x(02)	value zero.  
77  status-pat-mstr     			pic x(02)	value zero.  
77  status-pat-mstr-chrt			pic x(02)	value zero.  
77  status-pat-mstr-od				pic x(02)	value zero.  
77  status-pat-mstr-acr				pic x(02)	value zero.  
77  status-pat-mstr-hc				pic x(02)	value zero.  
77  status-doc-mstr				pic x(02)	value zero.  
* 2004/02/26 - MC
77  status-cobol-loc-mstr                       pic x(2)        value zero.
* 2004/02/26 - end
77  status-resub-file				pic x(2) 	value zero.  
77  status-corrected-pat			pic x(2)	value zero.  
77  status-adj-claim-file			pic x(2)	value zero.  
77  status-iconst-mstr                          pic x(02)       value zero.  
77  status-diag-mstr                            pic x(02)       value zero.  
77  status-cobol-diag-mstr			pic x(2)        value zero.  
  
*  
*  keys (and/or record layouts) for all indexed files  
*  
  
  
*mf copy "f002_key_claims_mstr.ws".  
  
copy "f002_claims_mstr_rec1_2.ws".  
  
*!01  ws-hold-clmdtl-batch-nbr.  
*!    05  ws-clinic-nbr-1-2			pic 99.  
*!    05  ws-doc-nbr.  
*!	10  filler				pic 9.  
*!	  10  ws-doc-nbr3			  pic 999.  
*!	10  ws-doc-nbr3				pic xxx.  
*!    05  ws-week-day				pic 999.  
  
  
*   counters for records read/written for all input/output files  
  
01  counters.  
    05  ctr-read-claims-mstr			pic 9(7).  
    05  ctr-read-pat-mstr			pic 9(7).  
    05  ctr-write-rejected-claims		pic 9(7).  

*   brad1
    05  ctr-read-rejected-claims		pic 9(7).  
    05  ctr-updated-rejected-claims		pic 9(7).  

    05  ctr-write-corrected-pat			pic 9(7).  
    05  ctr-write-pat-elig-hist			pic 9(7).
    05  ctr-rewrite-claims-mstr			pic 9(7).  
    05  ctr-nbr-claims-displayed		pic 99.  
    05  ctr-write-claims-mstr			pic 9(7).  
    05  ctr-delete-claims-mstr			pic 9(7).  
  
copy "f010_patient_mstr.ws".  
  
copy "hosp_table.ws".  
01  hold-clmhdr-bal			pic s9(5)v99.  
  
01  hold-descriptions occurs 5 times.  
    03  hold-desc-rec.  
	05  hold-desc-id.  
*!	    10  hold-desc-batch-id      pic x(11).  
	    10  hold-desc-batch-id	pic x(10).  
	    10  filler			pic x(06).  
        05  hold-desc.  
	    10  filler			pic x(4).  
	    10  hold-desc-test1		pic x.  
	    10  filler			pic x(5).  
	    10  hold-desc-test2		pic x.  
	    10  filler			pic x(11).  
* 2003/09/22 - MC
*	05  filler			pic x(138). 
	05  filler			pic x(146). 
* 2003/09/22 - end

*!	05  hold-orig-batch-id		pic x(11).  
	05  hold-orig-batch-id		pic x(10).  

*!	05  hold-b-key        		pic x(18).  
	05  hold-b-key        		pic x(17).  
	05  hold-p-key. 
	    10  hold-p-key-type		pic x.
*!	    10  hold-p-data		  pic x(17).
	    10  hold-p-data		pic x(16).

    03  hold-desc-cntrl.  
	05  hold-desc-before		pic x.  
	05  hold-desc-after		pic x.  
	05  hold-desc-change		pic x.  
    03  hold-desc-feedback-claims	pic x(6).  
    03  hold-desc-claims-occur		pic 9(12).  
  
01  orig-descriptions occurs 5 times.  
    03  orig-desc.
	05 orig-desc-1-2		pic x(02).
	05 orig-desc-3-22		pic x(20).
	
  
01  ws-hold-scr-values.  
  03  ws-tbl-values.  
    05  hold-pat-occ		occurs 21 times	pic 9(2).  
    05  hold-given-name		occurs 21 times	pic x(12).  
    05  hold-surname		occurs 21 times pic x(15).  
* (y2k)
*   05  hold-birth-date 	occurs 21 times pic 9(6).
    05  hold-birth-date		occurs 21 times pic 9(8).
    05  hold-pat-id		occurs 21 times pic x(15).  
* 2000/02/24 - MC change datatype from numeric to character
*   05  hold-key-pat-mstr	occurs 21 times pic 9(16).  
    05  hold-key-pat-mstr	occurs 21 times pic x(16).  

  03  ws-tbl-brief-claims redefines ws-tbl-values.  
    05  ws-total-nbr-brief-claims occurs 10 times.  
	10  ws-tbl-agent  		pic 9.  
	10  ws-tbl-claim-batch-nbr.  
	    15  ws-tbl-claim-clinic	pic 99.  
*!	      15  ws-tbl-claim-doc-nbr	  pic 999.  
	    15  ws-tbl-claim-doc-nbr	pic xxx.  
	    15  ws-tbl-claim-batch	pic 999.  
	10  ws-tbl-claim-claim-nbr	pic 99.  
	10  ws-tbl-re-cap.  
	    15  ws-tbl-re-cap-mm	pic 99.  
	    15  ws-tbl-re-cap-dd	pic 99.  
	10  ws-tbl-ped			pic x(8).
	10  ws-tbl-ped-r redefines ws-tbl-ped.
	    15  ws-tbl-ped-12		pic x(2).
	    15  ws-tbl-ped-38		pic x(6).
	10  ws-tbl-doc-name		pic x(17).  
	10  ws-tbl-payments		pic s9(5)v99.  
	10  ws-tbl-orig-amt		pic s9(5)v99.  
	10  ws-tbl-bal-due		pic s9(5)v99.  
* (y2k - auto fix)
*	10  ws-tbl-dtl1-svc-date	pic 9(6).  
	10  ws-tbl-dtl1-svc-date	pic x(8).  
	10  ws-tbl-dtl1-svc-date-r redefines ws-tbl-dtl1-svc-date.
	    15  ws-tbl-dtl1-svc-date-12	pic x(2).
	    15  ws-tbl-dtl1-svc-date-38	pic x(6).
	10  ws-tbl-dtl1-oma-cd		pic x(4).  
	10  ws-tbl-dtl1-oma-suff	pic x.  
	10  ws-tbl-dtls-2-8 occurs 7 times.  
	    15  ws-tbl-dtl-dd		pic 99.  
	    15  ws-tbl-dtl-oma-cd	pic x(4).  
	    15  ws-tbl-dtl-oma-suff	pic x.  
	10  ws-tbl-dtl-star		pic x.  
    05  filler				pic x(186).  
* br0d
01    hold-claim-detail.  
  
    05  hold-detail occurs 9 times.  
  
	10  hold-clm-id.  
*	    15  hold-clm-oma-cd		pic x999.  
*	    15  hold-clm-oma-suff	pic x.  
	    15  hold-oma-cd		pic x999.  
	    15  hold-oma-suff		pic x.  
* 		(y2k - auto fix)
*	    15  hold-clm-per-end-date	pic 9(6).  
	    15  hold-clm-per-end-date	pic 9(8).  
	    15  hold-clm-per-end-date-r redefines hold-clm-per-end-date.
		20  hold-clm-per-end-date-12 pic 9(2).
		20  hold-clm-per-end-date-38 pic 9(6).
	    15  hold-clm-svc-date.  
* 		(y2k - auto fix)
*	        20  hold-clm-svc-date-yy	pic 99.  
	        20  hold-clm-svc-date-yy	pic 9(4).  
		20  hold-clm-svc-date-yy-r redefines hold-clm-svc-date-yy.
		    25  hold-clm-svc-date-yy-12	pic 9(2).
		    25  hold-clm-svc-date-yy-34	pic 9(2).
	        20  hold-clm-svc-date-mm	pic 99.  
	        20  hold-clm-svc-date-dd	pic 99.  
	    15  hold-clm-amt-due	pic s9(5)v99.  
	    15  hold-clm-svc		pic 99.  
	    15  hold-clm-svcs-day-svcs occurs 3 times.  
		20  hold-clm-svcs-day	pic xx.  
		20  hold-clm-svcs-svc	pic x.  
	    15  hold-clm-tech-billed    pic s9(4)v99.  
	    15  hold-clm-prof-billed	pic s9(4)v99.  
            15  hold-diag-cd            pic 999.  
            15  hold-line-no            pic 99.  
            15  hold-feedback-clmdtl    pic x(4).  
            15  hold-occurs-clmdtl      pic 9(12).  
*mf         15  hold-claim-detail-rec   pic x(180).  
* 2012/03/05 - MC5 - increase the record size from 216 to 228
*           15  hold-claim-detail-rec   pic x(216).  
            15  hold-claim-detail-rec   pic x(228).  
* 2012/03/05 - end

01  hold-claim-detail-adj.  
  
    05  hold-detail-adj occurs 9 times.  
  
	10  hold-clmadj-adj-cd		pic x.  
* (y2k - auto fix)
*	10  hold-clmadj-per-end-date 	pic 9(6).  
	10  hold-clmadj-per-end-date 	pic 9(8).  
* (y2k - auto fix)
*	10  hold-clmadj-svc-date	pic 9(6).  
	10  hold-clmadj-svc-date	pic 9(8).  
	10  hold-clmadj-due		pic s9(5)v99.  
	10  hold-clmadj-cyc		pic 999.  
	10  hold-clmadj-tech-billed     pic s9(4)v99.  
	10  hold-clmadj-prof-billed     pic s9(4)v99.  
	10  hold-clmadj-batch-id-1-2	pic 99.  
*!	  10  hold-clmadj-batch-id-4-9	  pic 9(6).  
	10  hold-clmadj-batch-id-4-9	pic x(6).  
	10  hold-clmadj-orig-claim-nbr	pic 99.  
  
  
01  tbl-nbrs.  
    05  tbl-elements.  
	10  filler			pic x(1)	value "1".  
	10  filler			pic x(1)	value "2".  
	10  filler			pic x(1)	value "3".  
	10  filler			pic x(1)	value "4".  
	10  filler			pic x(1)	value "5".  
	10  filler			pic x(1)	value "6".  
	10  filler			pic x(1)	value "7".  
	10  filler			pic x(1)	value "8".  
	10  filler			pic x(1)	value "9".  
    05  tbl-elements-nbr redefines tbl-elements occurs 9 times  
					pic x.  
  
01  error-message-table.  
  
    05  error-messages.  
* msg #1  
	10  filler				pic x(68)   value  
		"Invalid Reply".  
	10  filler				pic x(68)   value  
		"CLAIM Number NOT Found".  
	10  filler				pic x(68)   value  
		"SERIOUS CONDITION!- INVALID CLAIMS MSTR INDX PTR".  
	10  filler				pic x(68)   value  
		"BIRTH DATE cannot be greater than TODAY's Date".  
* msg #5  
	10  filler				pic x(68)   value  
		"SELECTED NBR > NBR OF SELECTIONS AVAILABLE ".  
	10  filler				pic x(68)   value  
		"No more Patients to display ".  
	10  filler				pic x(68)   value  
		"PATIENT Acronym not found".  
	10  filler				pic x(68)   value  
		"No more Claims for entered Patient".  
	10  filler				pic x(68)   value  
		"END of CLAIMS MASTER reached".  
* msg #10  
	10  filler				pic x(68)   value  
		"No Claim DETAILS found".  
	10  filler				pic x(68)   value  
		"PATIENT NOT FOUND in patients master".  
	10  filler				pic x(68)   value  
		"SERIOUS CONDITION!!- NO CLAIMS PATIENT KEY FOUND".  
	10  filler				pic x(68)   value  
		"Invalid Selected Patient Number".  
	10  filler				pic x(68)   value  
		"SERIOUS CONDITION!!- ACCESSING CHOSEN PATIENT".  
* msg #15  
	10  filler				pic x(68)   value  
		"Only PF1(BRIEF), PF4(AGENT) or PF8(TECH) options".  
	10  filler				pic x(68)   value  
		"NO Claims found with Identifier Supplied".  
	10  filler				pic x(68)   value  
		"Existing or Zero MESSAGE Number required".  
	10  filler				pic x(68)   value  
		"Existing SUBDIVISION Number required".  
	10  filler				pic x(68)   value  
		"'Y'es or 'N'o REPRINT Flag required".  
* msg #20  
	10  filler				pic x(68)   value  
		"'Y'es or 'N'o AUTO LOGOUT Flag required".  
	10  filler				pic x(68)   value  
		"'H'igh or 'L'ow FEE COMPLEXITY flag required".  
	10  filler				pic x(68)   value  
		"DESCRIPTION Field required".  
	10  filler				pic x(68)   value  
		"Invalid WRITE to CLAIMS Master".  
	10  filler				pic x(68)   value  
		"Invalid DELETE on CLAIMS Master".  
* msg #25  
	10  filler				pic x(68)   value  
		"Invalid REWRITE to CLAIMS Master".  
	10  filler				pic x(68)   value  
		"NO CLAIMS for this AGENT".  
	10  filler				pic x(68)   value  
		"Invalid DATE: re-enter".  
	10  filler				pic x(68)   value  
		"Invalid DAY:  re-enter".  
	10  filler				pic x(68)   value  
		"Invalid-MONTH: re-enter".  
* msg #30
	10  filler				pic x(68)   value  
		"Invalid HOSPITAL Code: re-enter".  
	10  filler				pic x(68)   value  
		"Invalid YEAR: re-enter".  
	10  filler				pic x(68)   value  
		"ADMIT Date cannot be GREATER than TODAY".  
	10  filler				pic x(68)   value  
		"Valid entries are 'SPACE' and 'Y':re-enter".  
	10  filler				pic x(68)   value  
*		"Valid Entries are 'H'old, 'R'esubmit, or 'C'ard: re-enter".  
		"Valid entries are 'H'old, 'S'ubmitted, 'C'ard, or 'X'-resubmit!".
* msg #35
	10  filler				pic x(68)   value  
		"Invalid DOCTOR Number: re-enter".  
	10  filler				pic x(68)   value  
		"Invalid DIAGNOSTIC Code: re-enter".  
	10  filler				pic x(68)   value  
		"AGENT must be 0 or 2 for Resubmit: re-enter".  
	10  filler				pic x(68)   value  
		"REFERRING Doctor can not be SAME as OHIP Doc.".  
	10  filler				pic x(68)   value  
		"Invalid DOCTOR Number: re-enter".
* msg # 40  
	10  filler				pic x(68)   value  
		"DOCTOR Nbr does not MATCH Nbr on Claims: re-enter".  
	10  filler				pic x(68)   value  
		"CONFIDENTIAL Flag must be 'Y'es, 'N'o, 'R' or ' '".  
	10  filler				pic x(68)   value  
		"Can't find Claim's CLINIC Nbr in Clinic Mstr".
	10  filler				pic x(68)   value  
		"This action is NOT valid for a CURRENT CYCLE'S claim".  
	10  filler				pic x(68)   value  
		"1st char of HOSP does not match 1st char of LOC".  
* msg # 45  
	10  filler				pic x(68)   value  
		"DOCTOR Nbr fails MOD 10 CHECK digit edit hit * to continue".  
	10  filler				pic x(68)   value  
                "You cannot resubmit this claim with I2 or no balance".
	10  filler				pic x(68)   value  
		"ADMIT DATE can't be greater than SERVICE DATE".
	10  filler				pic x(68)   value  
		"You are NOT AUTHORIZED to perform this function".
* 2010/07/12 - MC2
	10  filler				pic x(68)   value  
	"Value must be 1 to 5 for dept 41, 42, 43 or 75". 
* 2010/07/12 - end
* 2011/05/25 - MC4
* msg # 50  
	10  filler				pic x(68)   value  
	"You are not allowed to change location - gone to MOH".
* 2011/05/25 - end

* 2012/02/23 - MC5
	10  filler				pic x(68)   value  
		"Invalid LOCATION Code: re-enter".  
* 2012/02/23 - end
* MC12
        10  filler                              pic x(68)   value
                "Disallow '~' in the field : re-enter".
* MC12 - end
* MC16
        10  filler                              pic x(60)   value
                "Invalid version cd:  re-enter".
* MC16 - end

    05  error-messages-r redefines error-messages.  
	10  err-msg				pic x(68)  
			occurs 53 times.  
  
01  err-msg-comment				pic x(60).  
  
01  warning-message-table.  
    05  warning-messages.  
* msg #1  
	10  filler				pic x(68)   value  
	"'Eligiblity' info updated - blanking 'Message'/ setting 'R'e-submit".
	10  filler				pic x(68)   value  
	"Preseting OHIP status to 'C'ard sent".                 
	10  filler				pic x(68)   value  
	"Discarding your changes- no update of claim will occur".
	10  filler				pic x(68)   value  
	" BIRTH Date does not match YYMM of CHART Nbr".  
* msg #5
	10  filler				pic x(68)   value  
	"HELP SUBSYSTEM - the following values are permitted".
	10  filler				pic x(68)   value  
* 2007/08/14 - MC
*	"'A'utomatic adjustment will be created next cycle".
	"'~' - Automatic adjustment will be created next cycle".
* 2007/08/14 - end
	10  filler				pic x(68)   value  
	"manual 'C'ard being submitted to OHIP".
	10  filler				pic x(68)   value  
	"update claim 'D'etails".
	10  filler				pic x(68)   value  
	"display patient's 'E'ligibility history".
* msg #10
	10  filler				pic x(68)   value  
	"update claim 'H'eader information".
	10  filler				pic x(68)   value  
	"'M'odify all parts of the claim including patient info".
	10  filler				pic x(68)   value  
	"update 'P'atient information".
	10  filler				pic x(68)   value  
	"update 'R'eference field".
	10  filler				pic x(68)   value  
	"update claim 'T'railer information".
* msg #15
	10  filler				pic x(68)   value  
	"'*' or '^' - return to top of screen to enter next claim number".
	10  filler				pic x(68)   value  
	"This claim already in rejected claim file(f085)".
    05  warning-messages-r redefines warning-messages.  
	10  warn-msg				pic x(68)  
			occurs 16 times.  
01  warn-msg-comment				pic x(68).  

screen section.  
  
01  scr-title-brief-normal.  
  
    05  blank screen.  
    05  line 01 col 01 value is "D003".  
    05  line 01 col 07 value is "ID:".  
    05  scr-acpt-clm-id  
                      line 01 col 11 pic x(13) using acpt-claim-or-acronym required.  
    05  line 01 col 27 value is "Claim Query / Update".  
*       (y2k - auto fix)
*   05  line 01 col 73 pic 99   using sys-yy.
    05  line 01 col 71 pic 9(4) using sys-yy.
    05  line 01 col 75 value "/".  
    05  line 01 col 76 pic 99 using sys-mm.  
    05  line 01 col 78 value "/".  
    05  line 01 col 79 pic 99 using sys-dd.  
  
*  
01  scr-brief.  
    05  line 01 col 51 pic x(6) using ws-brief.  
    05  line 01 col 57 value "*".  
  
*  
01  scr-normal.  
    05  line 01 col 51 pic x(6) using ws-normal.  
    05  line 01 col 57 value "*".  
  
*  
01  scr-tech.  
    05  line 01 col 58 pic x(2) using ws-tech.  
  
*  
01  scr-not-tech.  
    05  line 01 col 58 value "   ".  
  
*  
01  scr-agent.  
    05  line 01 col 63 value 'Agent '.  
    05  line 01 col 69 pic 9     using sel-agent-code.  
  
*  
01  scr-not-agent.  
    05  line 01 col 63 value '       '.  
  
*  
01  scr-claim-lit.  
    05  line 03 col 01 value is " AGNT CLAIM NBR  RE-CAP  P.E.D. DOCTOR NAME".  
    05  line 03 col 51 value is "ORIGINAL  PAYMENTS   BAL.DUE".  
  
  
*mf 01  scr-claim-var virtual.  
01  scr-claim-var.  
    05  line pline1 col 01 pic x 	from ws-prtnbr.  
    05  line pline1 col 02 value "-".  
    05  line pline1 col 04 pic 9	using ws-tbl-agent(i).  
    05  line pline1 col 06 pic x(8)	using ws-tbl-claim-batch-nbr(i).  
    05  line pline1 col 14 value '-'.  
    05  line pline1 col 15 pic 99	using ws-tbl-claim-claim-nbr(i).  
    05  line pline1 col 18 pic xx/xx	using ws-tbl-re-cap(i).  
    05  line pline1 col 24 pic x(6) using ws-tbl-ped-38(i).
    05  line pline1 col 33 pic x(17)	using ws-tbl-doc-name(i).  
    05  line pline1 col 50 pic zz,zz9.99- using ws-tbl-orig-amt(i).  
    05  line pline1 col 60 pic zz,zz9.99- using ws-tbl-payments(i).  
    05  line pline1 col 71 pic zz,zz9.99- using ws-tbl-bal-due(i).  
    05  line pline2 col 06 pic x(6) using ws-tbl-dtl1-svc-date(i).
    05  line pline2 col 14 value ":".  
    05  line pline2 col 15 pic xxxxx	using ws-tbl-dtl1-oma-cd(i).  
    05  line pline2 col 24 pic 99	using ws-tbl-dtl-dd(i,1) blank when zero.  
    05  line pline2 col 26 value ':'.  
    05  line pline2 col 27 pic xxxxx	using ws-tbl-dtl-oma-cd(i,1).  
    05  line pline2 col 33 pic 99	using ws-tbl-dtl-dd(i,2) blank when zero.  
    05  line pline2 col 35 value ':'.  
    05  line pline2 col 36 pic xxxxx	using ws-tbl-dtl-oma-cd(i,2).  
    05  line pline2 col 51 pic 99	using ws-tbl-dtl-dd(i,3) blank when zero.  
    05  line pline2 col 53 value ':'.  
    05  line pline2 col 54 pic xxxxx	using ws-tbl-dtl-oma-cd(i,3).  
    05  line pline2 col 61 pic 99	using ws-tbl-dtl-dd(i,4) blank when zero.  
    05  line pline2 col 63 value ':'.  
    05  line pline2 col 64 pic xxxxx	using ws-tbl-dtl-oma-cd(i,4).  
    05  line pline2 col 72 pic 99	using ws-tbl-dtl-dd(i,5) blank when zero.  
    05  line pline2 col 74 value ':'.  
    05  line pline2 col 75 pic xxxxx	using ws-tbl-dtl-oma-cd(i,5).  
    05  line pline2 col 80 pic x	using ws-tbl-dtl-star(i) blink.  
  
  
01  scr-select-nbr-roll.  
    05  line 23 col 31 value is "** ROLL SCREEN **    ENTER 'R'OLL / 'S'TOP / '#'".  
    05  line 23 col 80 pic x using ws-selected-claim auto required.  
  
01  scr-select-claim-nbr.  
    05  line 23 col 31 value is "                     ENTER 'S'TOP / '#'".  
    05  line 23 col 80 pic x using ws-selected-claim auto required.  
  
  
01  scr-dis-claim-id.  
    05  line 02 col 01 value "Claim :".  
    05  line 02 col 08 pic x(8) using ws-clmhdr-batch-nbr.  
    05  line 02 col 16 value "-".  
    05  line 02 col 17 pic 99 using clmhdr-claim-nbr.  
  
01  blank-id line 03 col 08	value '              '.  
  
01  scr-dis-blank-line-12-19.  
  
    05  line 12 col 01 blank line.  
    05  scr-dis-blank-line-13 line 13 col 01 blank line.  
    05  scr-dis-blank-line-14 line 14 col 01 blank line.  
    05  scr-dis-blank-line-15 line 15 col 01 blank line.  
    05  scr-dis-blank-line-16 line 16 col 01 blank line.  
    05  scr-dis-blank-line-17 line 17 col 01 blank line.  
    05  scr-dis-blank-line-18 line 18 col 01 blank line.  
    05  scr-dis-blank-line-19 line 19 col 01 blank line.  
  
01  scr-blank-line-3 line 3 col 01 blank line.  
  
01  scr-blank-lines.  
    05  scr-blank-line line pline1 col 01 blank line.  
    05                 line pline2 col 01 blank line.  
*  
01   scr-confirm       	line 23 col 1 pic x using confirm-space auto.  
  
01  scr-dis-clmhdr-lit.  
    05  line 03 col 01 value "H/C   :".  
    05  line 03 col 21 value "Last :".  
    05  line 03 col 43 value "Dob(cur/old)".  
    05  line 03 col 63 value "/".  
    05  line 03 col 72 value "VER:".  
    05  line 03 col 78 value "/".  
  
    05  line 04 col 01 value "Pat id:".  
    05  line 04 col 21 value "First:".  
    05  line 04 col 43 value "Elig(Chg/Mail)".  
    05  line 04 col 63 value "/".  
    05  line 04 col 72 value "Exp:".  
  
    05  line 05 col 01 value "Mess  :".  
    05  line 05 col 12 value "Addr:".  
    05  line 05 col 76 value "mmyy".
    05  line 06 col 01 value "EligEr:___".  
    05  line 06 col 11 value "/_".  
    05  line 06 col 46 value "Ohip Ref#".  
    05  line 06 col 69 value "Svc Er:___".  
    05  line 06 col 79 value "/_".  
  
    05  line 07 col 01 value "Dept  :".  
    05  line 07 col 12 value "Loc:".  
    05  line 07 col 22 value "Entry :".  
    05  line 07 col 38 value "Hosp:".  
    05  line 07 col 48 value "Admit :".  
    05  line 07 col 65 value "ManRev: ".  
    05  line 07 col 75 value "Stat:".  
  
    05  line 08 col 01 value "Source:".  
    05  line 08 col 12 value "I/O:".  
    05  line 08 col 22 value "Submit:".  
    05  line 08 col 38 value "Spec:".  
    05  line 08 col 48 value "Doc Ohip:".  
    05  line 08 col 65 value "Refer Doc:".  
  
    05  line 09 col 01 value "Agent :".  
    05  line 09 col 12 value "Rea:".  
    05  line 09 col 22 value "Paymt :".  
    05  line 09 col 38 value "Conf:".  
    05  line 09 col 48 value "Payroll :".  
    05  line 09 col 65 value "EarlySv:".  
  
    05  line 20 col 01 value "Sub Msg:".  
    05  line 20 col 12 value "Until:".  
    05  line 20 col 29 value "Clm Msg:".  
    05  line 20 col 40 value "Rprnt:".  
    05  line 20 col 48 value "SubDiv:".  
    05  line 20 col 57 value "AutoLog:".  
    05  line 20 col 67 value "Fee Lev:".  

01  scr-acpt-clmhdr-values.  
    05  line 03 col 08 pic x(10) using ws-pat-health-nbr.  
    05  line 03 col 27 pic x(15) using ws-pat-surname.  
    05  line 03 col 55 pic 9(4) using ws-pat-birth-date-yy.
    05  line 03 col 59 pic 9(2) using ws-pat-birth-date-mm.
    05  line 03 col 61 pic 9(2) using ws-pat-birth-date-dd.
    05  line 03 col 64 pic 9(2) using hold-last-birth-yy.
    05  line 03 col 66 pic xx using hold-last-birth-mm.  
    05  line 03 col 68 pic xx using hold-last-birth-dd.  
    05  line 03 col 76 pic xx using ws-pat-version-cd.  
    05  line 03 col 79 pic xx using ws-pat-last-version-cd.  
  
    05  line 04 col 08 pic x(12) using ws-pat-key-data.  
    05  line 04 col 27 pic x(12) using ws-pat-given-name.  
    05  line 04 col 57 pic 9(2) using hold-last-elig-maint-yy-34.
    05  line 04 col 59 pic xx using hold-last-elig-maint-mm.  
    05  line 04 col 61 pic xx using hold-last-elig-maint-dd.  
    05  line 04 col 64 pic 9(2) using hold-last-elig-mail-yy-34.
    05  line 04 col 66 pic xx using hold-last-elig-mail-mm.  
    05  line 04 col 68 pic xx using hold-last-elig-mail-dd.  
    05  line 04 col 76 pic 9(4) using ws-pat-expiry-date.
  
    05  line 05 col 08 pic x(3) using ws-pat-mess-code.  

    05  line 05 col 17 pic x(21) using ws-subscr-addr1.  
    05  line 05 col 38 pic x(21) using ws-subscr-addr2.  
    05  line 05 col 60 pic x(21) using ws-subscr-addr3.  
    05  line 06 col 08 pic x(3) using clmhdr-elig-error.
    05  line 06 col 12 pic x(1) using clmhdr-elig-status. 
    05  line 06 col 17 pic x(6)  using ws-subscr-postal-cd.  
* 2002/06/17 - MC
*    05  line 06 col 24 pic x(20) using ws-pat-country.  
* 2002/06/17 - end
    05  line 06 col 58 pic x(11) using hold-ohip-clm-nbr.  
    05  line 06 col 76 pic x(3) using clmhdr-serv-error.
    05  line 06 col 80 pic x(1) using clmhdr-serv-status.

    05  line 07 col 08 pic xx using clmhdr-doc-dept.  
    05  line 07 col 17 pic x(4) using clmhdr-loc.
    05  line 07 col 29 pic x(8) using clmhdr-date-sys.
    05  line 07 col 43 pic x(4) using ws-hosp-nbr.  
    05  line 07 col 55 pic 9(8) using clmhdr-date-admit.
    05  line 07 col 73 pic x using clmhdr-manual-review.  
    05  line 07 col 80 pic x using clmhdr-tape-submit-ind.  
  
    05  line 08 col 08 pic x    using clmhdr-adj-cd-sub-type.  
    05  line 08 col 17 pic x using clmhdr-i-o-pat-ind.  
* MC1
*    05  line 08 col 29 pic x(8) using clmhdr-submit-date.
    05  line 08 col 29 pic x(8) using clmhdr-submit-date of claim-header-rec. 
    05  line 08 col 43 pic xx using clmhdr-doc-spec-cd.  
    05  line 08 col 58 pic x(6) using clmhdr-doc-nbr-ohip.  
    05  line 08 col 75 pic x(6) using clmhdr-refer-doc-nbr.

01  scr-acpt-clmhdr-values-l9. 
    05  line 09 col 08 pic x  using clmhdr-agent-cd.  
    05  line 09 col 17 pic xx using clmhdr-status-ohip.  
    05  line 09 col 29 pic 9(8) using clmhdr-date-cash-tape-payment 
						blank when zero.
    05  line 09 col 43 pic x  using clmhdr-confidential-flag.  
    05  line 09 col 58 pic x(1) using clmhdr-payroll.
*   05  line 09 col 57 pic x(6) using clmhdr-serv-date.
    05  line 09 col 73 pic x(8) using clmhdr-serv-date.
  
01  scr-disp-misc-perc.  
    05  line 09 col 65 value "PERCENT".  
    05  line 09 col 73 pic zz9.99 using w-percent.  
  
* the following lines are added to allow changes to patient info  
* m. c.  93/04/26    sms 141  
*  
01  scr-acpt-changes-to-pat.  
* (y2k)
*   05  scr-acpt-birth-yy   line 03 col 57 pic 99 using ws-pat-birth-date-yy auto.
    05  scr-acpt-birth-yy   line 03 col 55 pic 9(4) using ws-pat-birth-date-yy auto.
    05  scr-acpt-birth-mm   line 03 col 59 pic 99 using ws-pat-birth-date-mm auto.  
    05  scr-acpt-birth-dd   line 03 col 61 pic 99 using ws-pat-birth-date-dd auto.  
    05  scr-acpt-version-cd line 03 col 76 pic xx using ws-pat-version-cd  auto.  
 
* (y2k - switched from mmyy to yymm as per user request) 
    05  scr-acpt-expiry-yy   line 04 col 78 pic 9(2) using ws-pat-expiry-yy auto.  
    05  scr-acpt-expiry-mm   line 04 col 76 pic 9(2) using ws-pat-expiry-mm auto.  
  
    05  scr-acpt-mess-code    line 05 col 08 pic x(3)  using ws-pat-mess-code.  
    05  scr-acpt-subscr-addr1 line 05 col 17 pic x(21) using ws-subscr-addr1.  
    05  scr-acpt-subscr-addr2 line 05 col 38 pic x(21) using ws-subscr-addr2.  
    05  scr-acpt-subscr-addr3 line 05 col 60 pic x(21) using ws-subscr-addr3.  
  
    05  scr-acpt-postal-code line 06 col 17 pic x(6)  using ws-subscr-postal-cd.  
* 2002/06/17 - MC
*   05  scr-acpt-country     line 06 col 24 pic x(20) using ws-pat-country.  
* 2002/06/17 - end
  
* the following lines are added to allow changes to claim header  
* -b.m.l. 91/05/10   sms 138  
*  
01 scr-acpt-changes-to-clmhdr.  
* 2011/05/25 - MC4
    05  scr-acpt-loc    line 07 col 17 pic x(4)  using clmhdr-loc.
* 2011/05/25 - end
    05  scr-acpt-hosp   line 07 col 43 pic x(4)  using ws-hosp-nbr.  
* (y2k)
*   05  scr-acpt-admit-yy line 07 col 57 pic 9(2)     using clmhdr-date-admit-yy auto.  
    05  scr-acpt-admit-yy line 07 col 55 pic 9(4)     using clmhdr-date-admit-yy auto.  
    05  scr-acpt-admit-mm line 07 col 59 pic 99       using clmhdr-date-admit-mm auto.  
    05  scr-acpt-admit-dd line 07 col 61 pic 99       using clmhdr-date-admit-dd auto.  
  
    05  scr-acpt-review line 07 col 73 pic x using clmhdr-manual-review auto.  
    05  scr-acpt-submit line 07 col 80 pic x using clmhdr-tape-submit-ind auto.  
    05  scr-acpt-doc-spec line 08 col 43 pic 99 using clmhdr-doc-spec-cd auto.  
    05  scr-acpt-doc-nbr line 08 col 57 pic x(6) using clmhdr-doc-nbr-ohip auto.  
    05  scr-acpt-ref-doc line 08 col 75 pic 9(6) using clmhdr-refer-doc-nbr blank when zero auto.  
    05  scr-acpt-confidential-flag line 09 col 43 pic x  using clmhdr-confidential-flag.  
* 2010/07/12 - MC2
    05  scr-acpt-payroll line 09 col 58 pic x(1) using clmhdr-payroll.
* 2010/07/12 - end
  
01 scr-acpt-other.  
* 	(y2k - auto fix)
*   05  line 09 col 30 pic 9(6) using clmhdr-date-cash-tape-payment.
    05  line 09 col 30 pic 9(6) using clmhdr-date-cash-tape-paymt-38 blank when zero.
  
01 scr-acpt-direct-bill-agent.  
    05  scr-subscr-msg-nbr line 20 col 09 pic xx using ws-subscr-msg-nbr auto.  
* (y2k)
*   05  scr-subscr-date-eff-to-yy line 20 col 18 pic 9(2) using ws-subscr-dt-msg-no-eff-to-yy auto.  
    05  scr-subscr-date-eff-to-yy line 20 col 18 pic 9(4) using ws-subscr-dt-msg-no-eff-to-yy auto.  
    05                            line 20 col 22 value "/".  
    05  scr-subscr-date-eff-to-mm line 20 col 23 pic 99 using ws-subscr-dt-msg-no-eff-to-mm auto.  
    05                            line 20 col 25 value "/".  
    05  scr-subscr-date-eff-to-dd line 20 col 26 pic 99 using ws-subscr-dt-msg-no-eff-to-dd auto.  
    05  scr-msg-nbr line 20 col 37 pic xx using clmhdr-msg-nbr auto.  
  
    05  scr-reprint-flag line 20 col 46 pic x  using clmhdr-reprint-flag auto.  
    05  scr-sub-nbr line 20 col 55 pic x using clmhdr-sub-nbr auto.  
    05  scr-auto-logout line 20 col 65 pic x using clmhdr-auto-logout auto.  
    05  scr-fee-complex line 20 col 75 pic x using clmhdr-fee-complex auto.  
  
  
01  scr-dis-clmdtl-lit.  
    05  line 11 col 01 value  
		"OMA SF  P.E.D.   SERVICE        AMT  SV DIAG DD/#".  
    05  line 11 col 51 value  
		"DD/# DD/# (CYC   ADJUST.-NBR)".  
  
01  scr-dis-clmdtl-lit-t.  
    05  line 11 col 01 value  
		"OMA SF  P.E.D.   SERVICE       AMT   SV DIAG    TECH".  
    05  line 11 col 56 value  
		"PROF (CYC   ADJUST.-NBR)".  
  
01  scr-dis-clmdet.  
  
*   05  line pline1 col 01 pic x(4)	using hold-clm-oma-cd(i).  
*   05  line pline1 col 06 pic x	using hold-clm-oma-suff(i).  
    05  line pline1 col 01 pic x(4)	using hold-oma-cd(i).  
    05  line pline1 col 06 pic x	using hold-oma-suff(i).  
* 	(y2k)
*   05  line pline1 col 08 pic 99/99/99 using hold-clm-per-end-date(i).
    05  line pline1 col 08 pic 99/99/99 using hold-clm-per-end-date-38(i).
*   05  line pline1 col 17 pic 9(2) using hold-clm-svc-date-yy(i).
    05  line pline1 col 17 pic 9(4) using hold-clm-svc-date-yy(i).
    05  line pline1 col 21 value "/".  
    05  line pline1 col 22 pic 9(2) using hold-clm-svc-date-mm(i).
    05  line pline1 col 24 value "/".  
    05  line pline1 col 25 pic 9(2) using hold-clm-svc-date-dd(i).
    05  line pline1 col 28 pic zzzz9.99- using hold-clm-amt-due(i).  
    05  line pline1 col 38 pic zz	using hold-clm-svc(i).  
    05  line pline1 col 42 pic 999      using hold-diag-cd(i).  
  
*  (the following fields are now changeable - b.m.l. 91/05/10 sms 138)
* (y2k)
*01 scr-acpt-svc-date-yy line pline1 col 16 pic 9(2) using hold-clm-svc-date-yy(i) auto.  
01  scr-acpt-svc-date-yy line pline1 col 17 pic 9(4) using hold-clm-svc-date-yy(i) auto.  
01  scr-acpt-svc-date-mm line pline1 col 22 pic 99  using hold-clm-svc-date-mm(i) auto.  
01  scr-acpt-svc-date-dd line pline1 col 25 pic 99  using hold-clm-svc-date-dd(i) auto.  
01  scr-acpt-diag-cd line pline1 col 42 pic 999      using hold-diag-cd(i) auto.  
  
01  scr-dis-clmdet-a.  
  
    05  scr-clm-day1     line pline1 col 46 pic 99  	using hold-clm-svcs-day(i,1) blank when zero.  
    05                   line pline1 col 48          	value "/".  
    05  scr-clm-svc1     line pline1 col 49 pic 9   	using hold-clm-svcs-svc(i,1) blank when zero.  
    05  scr-clm-day-2	 line pline1 col 51 pic 99  	using hold-clm-svcs-day(i,2) blank when zero.  
    05                   line pline1 col 53          	value "/".  
    05  scr-clm-svc2     line pline1 col 54 pic 9   	using hold-clm-svcs-svc(i,2) blank when zero.  
    05  scr-clm-day-3	 line pline1 col 56 pic 99  	using hold-clm-svcs-day(i,3) blank when zero.  
    05                   line pline1 col 58          	value "/".  
    05  scr-clm-svc3     line pline1 col 59 pic 9   	using hold-clm-svcs-svc(i,3) blank when zero.  
  
01  scr-dis-clmdet-b.  
  
    05  scr-clm-day-1	 line pline1 col 46 pic xx	using hold-clm-svcs-day(i,1).  
    05  scr-clm-day-2	 line pline1 col 51 pic xx  	using hold-clm-svcs-day(i,2) .
    05               	 line pline1 col 53         	value "/".  
    05  scr-clm-svc-2	 line pline1 col 54 pic x   	using hold-clm-svcs-svc(i,2) .
    05  scr-clm-day-3	 line pline1 col 56 pic xx  	using hold-clm-svcs-day(i,3).
    05               	 line pline1 col 58         	value "/".  
    05  scr-clm-svc-3	 line pline1 col 59 pic x   	using hold-clm-svcs-svc(i,3) .
  
01  scr-dis-clmdet-c.  
    05  line pline1 col 45 pic zzzz.99- using hold-clm-tech-billed (i).  
    05  line pline1 col 53 pic zzzz.99- using hold-clm-prof-billed (i).  
  
01  scr-msg-reset.  
    05  line 24 col 01 value " ATTENTION:" bell blink.  
    05  line 24 col 12 value "  REPRINT FLAG HAS BEEN RESET".  
01  scr-sub-reset.  
    05  line 24 col 01 value " ATTENTION:" bell blink.  
    05  line 24 col 12 value "  FEE DESC LEVEL AND AUTO LOGOUT HAVE BEEN RESET".  
01  scr-dis-clmdet-adj.  
  
    05  line pline1 col 01		value "  ".  
    05  line pline1 col 03 pic x	using hold-clmadj-adj-cd(i).  
    05  line pline1 col 04 		value "  ".  
* 	(y2k - not  modified - year is obvious)
    05  line pline1 col 08 pic   99/99/99 using hold-clmadj-per-end-date(i).
*    	(y2k)
*   05  line pline1 col 18 pic   99/99/99 using hold-clmadj-svc-date(i).
    05  line pline1 col 17 pic 9999/99/99 using hold-clmadj-svc-date(i).
    05  line pline1 col 28 pic zzzz9.99- using hold-clmadj-due(i).  
    05  line pline1 col 38 		value "......................".  
    05  line pline1 col 61		value "(".  
    05  line pline1 col 62 pic 999	using hold-clmadj-cyc(i).  
    05  line pline1 col 67 pic 99	using hold-clmadj-batch-id-1-2(i).  
*!    05  line pline1 col 69 pic 9(6)	  using hold-clmadj-batch-id-4-9(i).  
    05  line pline1 col 69 pic x(6)	using hold-clmadj-batch-id-4-9(i).  
    05  line pline1 col 75		value "-".  
    05  line pline1 col 76 pic 99	using hold-clmadj-orig-claim-nbr(i).  
    05  line pline1 col 78		value ")".  
  
01 scr-dis-clmdet-adj-b.  
    05  line pline1 col 45 pic zzzz.99- using hold-clmadj-tech-billed (i).  
    05  line pline1 col 53 pic zzzz.99- using hold-clmadj-prof-billed (i).  
  
  
01 scr-dis-desc.  
  
    05  scr-hold-desc-1 line 21 col 01 pic x(22) using hold-desc(1) auto.  
*    05  scr-hold-desc-2 line 21 col 24 pic x(22) using hold-desc(2).  
    05  scr-hold-desc-2 line 21 col 23 pic x(22) using hold-desc(2) auto.  
* 99/11/22 MC
*   05  line 21 col 48			value "REFER".  
*   05   scr-reference line 21 col 54 pic x(9)  
    05  line 21 col 46			value "Refer:".  
    05   scr-reference line 21 col 52 pic x(11)   
				 using clmhdr-reference.  
    05  scr-hold-desc-3 line 22 col 01 pic x(22) using hold-desc(3) auto.  
*    05  scr-hold-desc-4 line 22 col 24 pic x(22) using hold-desc(4).  
    05  scr-hold-desc-4 line 22 col 23 pic x(22) using hold-desc(4) auto.  
    05  scr-hold-desc-5 line 22 col 47 pic x(22) using hold-desc(5) auto.  
  
01 scr-dis-ref.  
  
    05  line 21 col 43 value "REF DATE:".  
* (y2k)
*   05  scr-ref-date    line 21 col 52 pic x(6) using clmhdr-ref-date1 auto.  

    05  scr-ref-date-yy line 21 col 52 pic 9(4) using clmhdr-ref-date-yy auto.  
    05  scr-ref-date-mm line 21 col 56 pic 9(2) using clmhdr-ref-date-mm auto.  
    05  scr-ref-date-dd line 21 col 58 pic 9(2) using clmhdr-ref-date-dd auto.  

    05                  line 21 col 60     	value " ".  
    05  scr-ref-inits   line 21 col 61 pic x(3) using clmhdr-ref-inits auto.  
    05                  line 21 col 64 value "  ".  
  
01  scr-confirm-update.  
    03  line 21 col 64 value "OK to Update     ".  
    03  line 22 col 64 value "  (Y/N/M)?       ".  
    03  line 22 col 78 pic x using update-confirmation auto.  
  
01  scr-dis-footing.  
  
    05  line 23 col 01 value "Orig Bal:".  
    05  line 23 col 12 pic zzzz9.99- using clmhdr-tot-claim-ar-ohip.  
    05  line 23 col 23 value "Amt Pd:".  
    05  line 23 col 32 pic zzzz9.99- using   
				ws-clmhdr-manual-tape-paymnts.  
    05  line 23 col 43 value "Curr Pd:".  
    05  line 23 col 52 pic zzzz9.99  using clmhdr-curr-payment.  
    05  line 23 col 63 value "Bal Due:".  
    05  line 23 col 72 pic zzzz9.99- using hold-clmhdr-bal.  
  
01  scr-acpt-correct-claim-y-n.  
  
    05  line 24 col 30 value "CORRECT CLAIM? (Y/N)".  
    05  line 24 col 55 pic x using flag auto.  
  
01  scr-acpt-roll-update.  
  
    05  line 20 col 76 pic x(4) using roll bell blink.  
    05  line 21 col 65 value "Update (Y/N/*)".  
    05  scr-acpt-ref-fld line 21 col 80 pic x using flag-ref-fld auto.  
  
01  scr-clr-clm-roll.  
  
    05  line 20 col 76 value "    ".  
  
  
01  scr-acpt-update.  
  
* 2007/01/30 - MC
*   05  line 21 col 65 value "Update A/C/D/E/H".  
* 2011/02/09 - MC3
*   05  line 21 col 65 value "Update ~/C/D/E/H".  
    05  line 21 col 65 value "Upd  ~/C/D/E/G/H".  
* 2011/02/09 - end
* 2007/01/30 - end

* 2002/11/13 - MC
*   05  line 22 col 70 value       "M/P/R/T/* ".  
    05  line 22 col 68 value       "M/O/P/R/T/*".  
* 2002/11/13 - end
    05  line 22 col 80 pic x using flag-ref-fld auto.  
  
01  scr-acpt-roll-pat-found.  
  
    05  line 23 col 55 pic x(15) using roll-lit bell blink.  
    05  line 24 col 55 value "PATIENT FOUND (Y/N/*)".  
    05  scr-acpt-pat-found-flag line 24 col 77 pic x using flag auto.  
  
01  scr-acpt-pat-found.  
   
    05  line 24 col 55 value "PATIENT FOUND (Y/N) ".  
    05  line 24 col 75 pic x using flag auto.  
    05  line 24 col 76 value "  ".  
  
01  scr-clr-pat-roll.  
    05  line 23 col 55 value "               ".  

*  (patient and subscriber screen optimization.  
*   screen layout is similar to m010. aug/85 k.p.)
01  scr-acpt-mask1.  
  
    05  scr-pat-prov-cd line 03 col 21 pic xx using ws-pat-prov-cd auto.  
    05  scr-health-nbr  line 04 col 21 pic 9(10) using ws-pat-health-nbr blank when zero auto.  
    05  scr-ohip-direct line 05 col 21 pic x(15) using ws-pat-ohip-mmyy-r auto.  
    05  scr-pat-chart-nbr  
			line 06 col 21 pic x999999999  
					using ws-pat-chart-nbr auto.  
    05  scr-acronym-fir line 07 col 21 pic x(6)  
                                        using ws-pat-acronym-first6 auto.  
    05  scr-acronym-las line 07 col 28 pic xxx  
                                        using ws-pat-acronym-last3 auto.  
    05  scr-pat-surname line 08 col 21 pic x(15) using ws-pat-surname auto.  
    05  scr-pat-given-name  
			line 09 col 21 pic x(12) using ws-pat-given-name auto.  
    05  scr-pat-init	line 10 col 21 pic xxx using ws-pat-init auto.  
    05  scr-pat-birth-date-yy  
			line 11 col 21 pic 9(4) using ws-pat-birth-date-yy auto.
    05  scr-pat-birth-date-mm  
			line 11 col 26 pic 99 using ws-pat-birth-date-mm auto.
    05  scr-pat-birth-date-dd  
			line 11 col 29 pic 99 using ws-pat-birth-date-dd auto.
    05  scr-last-birth-date-yy  
			line 11 col 33 pic 9(4) using hold-last-birth-yy auto.
    05  scr-last-birth-date-mm  
			line 11 col 36 pic 99 using hold-last-birth-mm auto.  
    05  scr-last-birth-date-dd  
			line 11 col 39 pic 99 using hold-last-birth-dd auto.  
    05  scr-pat-sex	line 12 col 21 pic x using ws-pat-sex auto.  
    05  scr-pat-65-ind  line 13 col 21 pic x using ws-pat-health-65-ind auto.  
    05  scr-pat-ver-cd  line 14 col 21 pic xx using ws-pat-version-cd auto.  
    05  scr-last-ver-cd line 14 col 25 pic xx using ws-pat-last-version-cd auto.  
    05  scr-pat-exp-mm  line 15 col 21 pic 9(2) using ws-pat-expiry-mm   blank when zero auto.  
    05  scr-pat-exp-yy  line 15 col 23 pic 9(2) using ws-pat-expiry-yy   blank when zero auto.  
    05  scr-pat-phone-nbr  
		       line 16 col 21 pic 999 using ws-pat-phone-nbr-first3  
					auto blank when zero.  
    05  scr-pat-phone-nbr2  
		       line 16 col 25 pic 9999 using ws-pat-phone-nbr-last4  
					auto blank when zero.  
    05  scr-pat-location-field  
			line 17 col 21 pic x(4) using  
					ws-pat-location-field auto.  
    05  scr-pat-last-elig-mail-yy  
* (y2k)
*			line 19 col 25 pic 9(2) using hold-last-elig-mail-yy
			line 19 col 23 pic 9(4) using hold-last-elig-mail-yy
					auto blank when zero.  
    05  scr-pat-last-elig-mail-mm  
			line 19 col 27 pic 99 using hold-last-elig-mail-mm  
					auto blank when zero.  
    05  scr-pat-last-elig-mail-dd  
			line 19 col 29 pic 99 using hold-last-elig-mail-dd  
					auto blank when zero.  
    05  scr-pat-last-elig-maint-yy  
* (y2k)
*			line 20 col 25 pic 9(2) using hold-last-elig-maint-yy
			line 20 col 23 pic 9(4) using hold-last-elig-maint-yy
					auto blank when zero.  
    05  scr-pat-last-elig-maint-mm  
			line 20 col 27 pic 99 using hold-last-elig-maint-mm  
					auto blank when zero.  
    05  scr-pat-last-elig-maint-dd  
			line 20 col 29 pic 99 using hold-last-elig-maint-dd  
					auto blank when zero.  
    05  scr-pat-mess-code line 21 col 21 pic xxx using ws-pat-mess-code auto.  
    05  scr-pat-no-letter-sent line 22 col 21 pic 99 using ws-pat-no-of-letter-sent auto blank when zero.  
  
*  
01  scr-acpt-mask2.  
    05  scr-subscr-addr1 line 03 col 57 pic x(21) using ws-subscr-addr1  
								auto.  
    05  scr-subscr-addr2 line 04 col 57 pic x(21) using ws-subscr-addr2 auto.  
    05  scr-subscr-addr3 line 05 col 57 pic x(21) using ws-subscr-addr3  
							auto.  
    05  scr-subscr-post-cd1  
			line 06 col 57 pic x using ws-subscr-post-cd1 auto.  
    05  scr-subscr-post-cd2  
			line 06 col 58 pic 9 using ws-subscr-post-cd2 auto.  
    05  scr-subscr-post-cd3  
			line 06 col 59 pic x using ws-subscr-post-cd3 auto.  
    05  scr-subscr-post-cd4  
			line 06 col 61 pic 9 using ws-subscr-post-cd4 auto.  
    05  scr-subscr-post-cd5  
			line 06 col 62 pic x using ws-subscr-post-cd5 auto.  
    05  scr-subscr-post-cd6  
			line 06 col 63 pic 9 using ws-subscr-post-cd6 auto.  
* 2002/06/17 - MC
*   05  scr-pat-country  
*			line 07 col 57 pic x(20) using pat-country auto.  
* 2002/06/17 - end
    05  scr-subscr-mess-nbr  
			line 08 col 57 pic xx using ws-subscr-msg-nbr auto.  
    05  scr-date-msg-nbr-effective-to  
* 			(y2k)
*			line 09 col 57 pic 9(2) using ws-subscr-dt-msg-no-eff-to auto blank when zero.
			line 09 col 55 pic 9(4) using ws-subscr-dt-msg-no-eff-to auto blank when zero.
    05 	scr-subscr-auto-update  
			line 10 col 57 pic x using ws-subscr-auto-update.  
    05  scr-pat-last-doc-nbr-seen  
*!			line 12 col 61 pic z(6) using  
			line 12 col 61 pic x(6) using  
					ws-pat-last-doc-nbr-seen auto.  
    05  scr-pat-date-last-maint  
			line 13 col 59 pic 9(8) using  
			ws-pat-date-last-maint blank when zero auto.  
    05  scr-pat-date-last-visit  
			line 14 col 59 pic 9(8) using  
			ws-pat-date-last-visit blank when zero auto.  
    05  scr-pat-date-last-admit  
			line 15 col 59 pic 9(8) using  
			ws-pat-date-last-admit blank when zero auto.  
    05  scr-pat-in-out  
			line 16 col 59 pic x using  
					ws-pat-in-out auto.  
**  
**  the following three fields are spaces when zero.  
**  
    05  scr-pat-total-nbr-visits  
			line 17 col 59 pic zzzz9 using  
					ws-pat-total-nbr-visits auto  
					blank when zero.  
    05  scr-pat-total-nbr-claims  
			line 18 col 59 pic zzzz9 using  
					ws-pat-total-nbr-claims auto  
					blank when zero.  
    05  scr-pat-nbr-outstanding-claims  
			line 19 col 60 pic zzz9 using  
					ws-pat-nbr-outstanding-claims auto  
 					blank when zero.  
*    05  scr-pat-inv-key line 20 col 59 pic x(16) using  
*                                        ws-key-pat-mstr auto.  
*  
01  scr-pat-lit.  
  
    05                  line 03 col 03 value "PROVINCE CODE   :".  
    05                  line 04 col 03 value "HEALTH NBR      :".  
    05                  line 05 col 03 value "OHIP/DIRECT NBR :".  
    05  		line 06 col 03 value "CHART NBR       :".  
    05                  line 07 col 03 value "ACRONYM         :".  
    05			line 08 col 03 value "SURNAME         :".  
    05			line 09 col 03 value "GIVEN NAME      :".  
    05  		line 10 col 03 value "INITIALS        :".  
  
    05  		line 11 col 03 value "BIRTH DATE      :".  
    05			line 11 col 23 value "/".  
    05			line 11 col 26 value "/".  
    05			line 11 col 33 value "/".  
    05			line 11 col 36 value "/".  
    05  		line 12 col 03 value "SEX             :".  
    05                  line 13 col 03 value "HEALTH 65 IND   :".  
    05                  line 14 col 03 value "VERSION CODE    :".  
    05                  line 15 col 03 value "EXPIRY DATE     :".  
    05			line 16 col 03 value "PHONE NUMBER    :".  
    05			line 16 col 24 value "-".  
    05			line 17 col 03 value "LAST LOCATION   :".  
    05			line 19 col 03 value "LAST ELIG MAIL  :".  
    05			line 20 col 03 value "LAST ELIG MAINT :".  
    05			line 21 col 03 value "MESSAGE CODE    :".  
    05			line 22 col 03 value "# LETTERS SENT  :".  
  
*  
01  scr-subscr-lit.  
    05  		line 03 col 41 value "ADDRESS 1     :".  
    05  		line 04 col 41 value "        2     :".  
    05  		line 05 col 41 value "CITY/PROV     :".  
    05  		line 06 col 41 value "POSTAL CODE   :".  
    05  		line 07 col 41 value "COUNTRY       :".  
    05  		line 08 col 41 value "MSG NBR       :".  
    05            	line 09 col 41 value "MSG EFFECT TO :".  
    05  		line 10 col 41 value "AUTO UPDATE   :".  
    05			line 12 col 41 value "LAST DOCTOR SEEN:".  
    05			line 13 col 41 value "LAST MAINT DATE :".  
    05			line 14 col 41 value "LAST VISIT DATE :".  
    05			line 15 col 41 value "LAST ADMIT DATE :".  
    05			line 16 col 41 value "LAST I/O IND.   :".  
    05			line 17 col 41 value "TOTAL NBR VISITS:".  
    05			line 18 col 41 value "TOTAL NBR CLAIMS:".  
    05			line 19 col 41 value "OUTSTAND. CLAIMS:".  
*    05                  line 20 col 41 value "INVISIBLE KEY   :".  
*  
01  scr-sel-pat-title.  
  
    05  blank screen.  
    05  line 01 col 01 value "REC #".  
    05  line 01 col 10 value "GIVEN NAME".  
    05  line 01 col 25 value "SURNAME".  
    05  line 01 col 45 value "BIRTH DATE".  
    05  line 01 col 60 value "PATIENT ID".  
*  
01  scr-select-nbr.  
  
    05			line 24 col 20 value "SELECTED #".  
    05			line 24 col 31 pic 99 to ws-sel-nbr auto  
					required blank when zero.  
*  
01  scr-sel-pat-mask.  
  
    05	line pline1 col 01 value "#".  
    05  line pline1 col 03 pic 99 using hold-pat-occ(i) blank when zero.  
    05  line pline1 col 10 pic x(12) using hold-given-name(i).  
    05  line pline1 col 25 pic x(15) using hold-surname(i).  
* 	(y2k)
*   05  line pline1 col 45 pic 9(6) using hold-birth-date(i).
    05  line pline1 col 43 pic 9(8) using hold-birth-date(i).
    05  line pline1 col 60 pic x(15) using hold-pat-id(i).  
*  
01  scr-disp-column-titles.  
  
    05  blank screen.  
    05	line 01 col 20 value "* Confirm this is the correct patient *".  
*  
*  
01  err-msg-line.  
    05  line 24 col 01	value " ERROR -  "	bell blink.  
    05  line 24 col 11	pic x(60)	from err-msg-comment.  
  
01  warn-msg-line.  
    05  line 24 col 01	value " WARNING - "	bell .
    05  line 24 col 12	pic x(68)	from warn-msg-comment.  
  
01  blank-line-24.  
    05  line 24 col 1	blank line.  
  
01  scr-verification-screen.  
    05  line 24 col 30 value "CORRECT PATIENT? (Y/N)".  
    05  line 24 col 55 pic x	using flag auto.  
  
01 file-status-display.  
    05  line 24 col 01 pic x(42) from ws-file-err-msg.  
    05  line 24 col 44 pic x(7)  from ws-disp-pat-key-type.  
    05  line 24 col 56	"FILE STATUS = ".  
    05  line 24 col 70	pic x(11) using status-common	bell blink.  
*  
01  confirm.  
    05 line 23 col 01  value " ".  
  
01  blank-screen.  
    05  blank screen.  
  
01  scr-reject-entry.  
    05  line 24 col 50	value "ENTRY IS ".  
    05  line 24 col 59	value "REJECTED"	bell blink.  
  
01  scr-closing-screen.  
    05  blank screen.  
    05  line  6 col 20  value "# OF CLAIMS MASTER READS  =".  
    05  line  6 col 55  pic 9(7) from ctr-read-claims-mstr.  
    05  line  7 col 20  value "# OF PATIENT MSTR  READS  =".  
    05  line  7 col 55  pic 9(7) from ctr-read-pat-mstr.  
    05  line  8 col 20  value "# OF CLAIMS MASTER RE-WRITES =".  
    05  line  8 col 55  pic 9(7) from ctr-rewrite-claims-mstr.  
    05  line  9 col 20  value "# OF CLAIMS MASTER WRITES =".  
    05  line  9 col 55  pic 9(7) from ctr-write-claims-mstr.  
    05  line 10 col 20  value "# OF CLAIMS MASTER DELETES =".  
    05  line 10 col 55  pic 9(7) from ctr-delete-claims-mstr.  
    05  line 11 col 20  value "# OF REJECTED CLAIMS WRITES=".  
    05  line 11 col 55  pic 9(7) from ctr-write-rejected-claims.  
    05  line 12 col 20  value "# OF CORRECTED PAT WRITES  =".  
    05  line 12 col 55  pic 9(7) from ctr-write-corrected-pat.  
    05  line 21 col 20	value "PROGRAM D003 ENDING".  
* 	(y2k)
*   05  line 21 col 40  pic 9(2) from sys-yy.
    05  line 21 col 40  pic 9(4) from sys-yy.
    05  line 21 col 42	value "/".  
    05  line 21 col 43	pic 99	from sys-mm.  
    05  line 21 col 45	value "/".  
    05  line 21 col 46	pic 99	from sys-dd.  
    05  line 21 col 50	pic 99	from sys-hrs.  
    05  line 21 col 52	value ":".  
    05  line 21 col 53	pic 99	from sys-min.         

01  load-message.
    05  line 24 col 5 value "PROGRAM NOW BEING LOADED".
  
procedure division.  
declaratives.  
  
err-rejected-claims-file section.  
   use after standard error procedure on rejected-claims.  
err-rejected-claims.  
*mfmove status-info-rejected-claims		to status-common.  
   move status-cobol-rejected-claims		to status-common.
   display file-status-display.  
   stop "ERROR IN ACCESSING REJECTED CLAIMS".  
  
err-claims-mstr-file section.  
    use after standard error procedure on claims-mstr.  
err-claims-mstr.  
    move status-cobol-claims-mstr		to status-common.  
    display file-status-display.  
    stop "ERROR IN ACCESSING CLAIMS MASTER".  
  
    copy "f002_claim_shadow.ds".  
  
err-pat-mstr-file section.  
    use after standard error procedure on pat-mstr.  
err-pat-mstr.  
    move "I-KEY"			to ws-disp-pat-key-type.  
    move "PATIENT ACCESS ERROR CALL SYSTEMS -- KEY =" to ws-file-err-msg.  
    move status-cobol-pat-mstr    		to status-common.  
    display file-status-display.  
    stop " ".  
    move spaces				to ws-file-err-msg  
					   ws-disp-pat-key-type.  
  
*mferr-pat-mstr-file-acr section.  
*mf    use after standard error procedure on acr-pat-mstr.  
*mferr-pat-mstr-acr.  
*mf    move "ACRONYM"			to ws-disp-pat-key-type.  
*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.  
*mf    move status-cobol-pat-mstr-acr		to status-common.  
*mf    display file-status-display.  
*mf    stop " ".  
*mf    move spaces				to ws-file-err-msg  
*mf					   ws-disp-pat-key-type.  
  
*mferr-pat-mstr-file-od section.  
*mf    use after standard error procedure on od-pat-mstr.  
*mferr-pat-mstr-od.  
*mf    move "OHIP"				to ws-disp-pat-key-type.  
*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.  
*mf    move status-cobol-pat-mstr-od		to status-common.  
*mf    display file-status-display.  
*mf    stop " ".  
*mf    move spaces				to ws-file-err-msg  
*mf					   ws-disp-pat-key-type.  
  
*mferr-pat-mstr-file-hc section.  
*mf    use after standard error procedure on hc-pat-mstr.  
*mferr-pat-mstr-hc.  
*mf    move "HEALTH"			to ws-disp-pat-key-type.  
*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.  
*mf    move status-cobol-pat-mstr-hc 		to status-common.  
*mf    display file-status-display.  
*mf    stop " ".  
*mf    move spaces				to ws-file-err-msg  
*mf					   ws-disp-pat-key-type.  
  
*mferr-pat-mstr-file-chrt section.  
*mf    use after standard error procedure on chrt-pat-mstr.  
*mferr-pat-mstr-chrt.  
*mf    move "CHART"			to ws-disp-pat-key-type.  
*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.  
*mf    move status-cobol-pat-mstr-chrt		to status-common.  
*mf    display file-status-display.  
*mf    stop " ".  
*mf    move spaces				to ws-file-err-msg  
*mf					   ws-disp-pat-key-type.  
  
err-doc-mstr-file section.  
    use after standard error procedure on doc-mstr.  
err-doc-mstr.  
    move status-cobol-doc-mstr		to status-common.  
    display file-status-display.  
    stop "ERROR IN ACCESSING DOCTOR MASTER".  
  
err-constants-mstr-file section.  
    use after standard error procedure on iconst-mstr.  
err-iconst-mstr.  
    move status-cobol-iconst-mstr		to status-common.  
    display file-status-display.  
    stop "ERROR IN ACCESSING CONSTANTS MASTER".  
  
	copy "f094_msg_sub_mstr.ds".  
  
end declaratives.  
main-line section.  
mainline.  

    perform aa0-initialization		thru aa0-99-exit.  

    move "N"				to   end-job.
    perform ab0-processing		thru ab0-99-exit   
 	until end-job = "Y".  

    perform az0-end-of-job		thru az0-99-exit.  
*  
    chain "$obj/menu". 
    stop run.  

aa0-initialization.  
  
    accept sys-date			from date.  
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm				to run-mm.  
    move sys-dd				to run-dd.  
    move sys-yy				to run-yy.  
  
    accept sys-time			from time.  
    move sys-hrs			to run-hrs.  
    move sys-min			to run-min.  
    move sys-sec			to run-sec.  
  
*mf accept console-id 			from line number.  
    accept ws-user-id 			from user name.  
   
    open input  claims-extra-mstr.  
  
    open i-o    claims-mstr  
                claim-shadow-mstr  
             	pat-mstr
		pat-elig-history.

    open input	msg-sub-mstr  
		doc-mstr  
* 2004/02/26 - MC
                loc-mstr
* 2004/02/26 - end
		iconst-mstr  
* 2011/05/25 - MC4
		batch-ctrl-file
* 2011/05/25 - end
                diag-mstr.  
  
*mf open extend rejected-claims  
    open i-o    rejected-claims.
    open extend	corrected-pat  
               	adj-claim-file.  
*   open output parameter-file.
  
    move zeros			to counters.  
    move spaces			to claim-header-rec     
				   claim-detail-rec.  
*mf
    move zeros			to clmhdr-claim-id
				   clmhdr-adj-cd-sub-type-ss
				   clmhdr-doc-nbr-ohip
				   clmhdr-doc-spec-cd
				   clmhdr-refer-doc-nbr
				   clmhdr-diag-cd
				   clmhdr-agent-cd
				   clmhdr-date-admit
				   clmhdr-doc-dept
				   clmhdr-curr-payment
				   clmhdr-date-period-end
				   clmhdr-cycle-nbr
				   clmhdr-amt-tech-billed
				   clmhdr-amt-tech-paid
				   clmhdr-tot-claim-ar-oma
				   clmhdr-tot-claim-ar-ohip
				   clmhdr-manual-and-tape-paymnts
				   clmhdr-orig-batch-id
* MC1
*				   clmhdr-submit-date
				   clmhdr-submit-date of claim-header-rec
				   clmhdr-serv-date.
    move zeros			to clmdtl-id
				   clmdtl-agent-cd
				   clmdtl-nbr-serv
				   clmdtl-sv-date
				   clmdtl-consecutive-sv-date(1)
				   clmdtl-consecutive-sv-date(2)
				   clmdtl-consecutive-sv-date(3)
				   clmdtl-amt-tech-billed
				   clmdtl-fee-oma
				   clmdtl-fee-ohip
				   clmdtl-cycle-nbr
				   clmdtl-diag-cd
				   clmdtl-line-no
				   clmdtl-orig-batch-id.
    move 'N'			to flag-normal-brief   
    				   flag-normal-tech.  
  
aa0-99-exit.  
    exit.  
az0-end-of-job.  
  
    display blank-screen.  
    accept sys-time			from time.  
    display scr-closing-screen.  
    display confirm.  
*mf stop " ".
  
    close pat-mstr  
	  pat-elig-history
*mf          od-pat-mstr  
*mf          hc-pat-mstr  
*mf          acr-pat-mstr  
*mf          chrt-pat-mstr  
	  msg-sub-mstr  
* 2011/05/25 - MC4
	  batch-ctrl-file
* 2011/05/25 - end
	  claims-mstr  
	  claims-extra-mstr  
          claim-shadow-mstr  
* 2004/02/26 - MC
          loc-mstr
* 2004/02/26 - end
	  rejected-claims  
	  corrected-pat  
	  adj-claim-file  
	  iconst-mstr  
          diag-mstr  
	  doc-mstr.
*	  parameter-file.
  
*   call program "$obj/menu".
*   chain "$obj/menu".
  
az0-99-exit.  
    exit.  
ab0-processing.  
  
    move zeroes			to hold-pat-birth-date  
				   hold-last-elig-maint-date
				   hold-last-elig-mail-date
				   hold-last-birth-date  
				   save-serv-date.  
  
    move spaces			to hold-version-cd, hold-mess-code.  
  
    move 'N'			to elig-flag-version-cd.
    move 'N'			to elig-flag-birth-date.
  
    perform xn0-disp-title-brief-norm	thru	xn0-99-exit.  
  
ab0-10-acpt-clm-id.  
    accept scr-acpt-clm-id  
	on escape  
		accept ws-esc-toggle  
					from	escape key  
		if ws-esc-toggle = 2  
		then  
		    if flag-normal-brief-n  
		    then  
			move 'B'	to	flag-normal-brief  
		    else  
			move 'N'	to	flag-normal-brief   
*		    endif  
		else  
		    if ws-esc-toggle = 9  
		    then  
		        if flag-normal-tech-n  
		        then  
			    move 'T'	to	flag-normal-tech  
		        else  
			    move 'N'	to	flag-normal-tech  
*                       endif  
		    else  
		        if ws-esc-toggle = 5  
		        then  
                            if flag-agent-on  
                            then  
                                move 'N' to flag-agent-code  
                            else  
                                move 'Y' to flag-agent-code  
                                move  6  to sel-agent-code  
                                 display scr-agent  
                                 accept  scr-agent  
                         else  
		             move 15		to	err-ind  
		             perform za0-common-error  
					        thru	za0-99-exit  
		             go to ab0-10-acpt-clm-id.  
*		        endif  
*		    endif  
*		endif  
  
*   ( if normal request )  
    if flag-normal-brief-n  
    then  
	display scr-normal  
    else  
	display scr-brief.  
*   endif  
  
*   ( if tech request)  
    if flag-normal-tech-t  
    then  
	display scr-tech  
    else  
	display scr-not-tech.  
*   endif  
  
*   ( if agent request )  
    if flag-agent-on  
    then  
	display scr-agent  
    else  
	display scr-not-agent.  
*   endif  
  
*	(allow operator to stop inquiry)  
    if   acpt-claim-clinic-1 = "*"  
      or acpt-claim-clinic-1 = "^"  
    then  
	move "Y"			to end-job  
	go to ab0-99-exit.  
*   (else)  
*   endif  
  
*  ( access single claim by claim nbr )
*    ++++++++++++++++++++++++++++++++  
    if acpt-claim-clinic-1 numeric  
    then  
	move "C"			to flag-claim-access-type  
  
        move spaces			to claims-mstr-rec
*mf     (MF cobol doesn't like spaces in numeric fields)
	move zeros			to clmdtl-id
					   clmdtl-agent-cd
					   clmdtl-nbr-serv
					   clmdtl-sv-date
					   clmdtl-consecutive-sv-date(1)
					   clmdtl-consecutive-sv-date(2)
					   clmdtl-consecutive-sv-date(3)
					   clmdtl-amt-tech-billed
					   clmdtl-fee-oma
					   clmdtl-fee-ohip
					   clmdtl-cycle-nbr
					   clmdtl-diag-cd
					   clmdtl-line-no
					   clmdtl-orig-batch-id
	move zero			to clmdtl-b-data
	move "B"			to clmdtl-b-key-type   
	move acpt-claim-clinic		to clmdtl-b-clinic-nbr-1-2  
*!	move zero			to clmdtl-b-doc-nbr-1  
	move acpt-claim-doc-nbr		to clmdtl-b-doc-nbr-2-4  
	move acpt-claim-week		to clmdtl-b-week  
	move acpt-claim-day		to clmdtl-b-day  
	move acpt-claim-claim-nbr	to clmdtl-b-claim-nbr  
	move zeros			to clmdtl-b-oma-cd  
					   clmdtl-b-oma-suff  
					   clmdtl-b-adj-nbr              
	perform ea0-read-display-a-claim  
					thru ea0-99-exit  
	go to ab0-99-exit.  
*   (else)  
*   endif  
  
    move -1				to pat-count.  
  
*   ( access all claims selecting patient by acronym )
*     ++++++++++++++++++++++++++++++++++++++++++++++
* ( access all claims selecting patient also by ohip nbr  j.l. pdr 336)  
* (  put "?" before ohip nbr and approximate ohip nbr will be pick up )  
  
    if     acpt-direct-chart-flag not = '!'  
       and acpt-direct-chart-flag not = '#'  
* 2002/04/05 - MC - put '$' before chart nbr when user access claims by chart nbr
       and acpt-direct-chart-flag not = '$'
*2002/04/05 - end
    then  
        if acpt-ohip-nbr-flag = "?"  
        then  
            move "O"			to flag-claim-access-type  
        else  
	    move "A"			to flag-claim-access-type.  
*       endif  
*   else  
*   endif  
  
    if     acpt-direct-chart-flag not = '!'  
       and acpt-direct-chart-flag not = '#'  
* 2002/04/05 - MC - put '$' before chart nbr when user access claims by chart nbr
       and acpt-direct-chart-flag not = '$'
*2002/04/05 - end
    then  
	perform ka0-select-patient  	thru ka0-99-exit  
	if   flag-pat-not-ok  
	  or not-ok  
	then  
	    go to ab0-99-exit  
	else  
	    perform ma0-display-selected-pat  
					thru ma0-99-exit  
	    perform ca0-user-verif-of-sel-pat  
					thru ca0-99-exit  
	    if not-ok  
	    then  
		go to ab0-99-exit  
	    else  
                perform xn0-disp-title-brief-norm	thru xn0-99-exit  
*	    endif  
*	endif  
    else  
	move 'N'			to flag-claim-access-type  
*	( if brief )  
	if flag-normal-brief-b  
	then  
	    perform ab1-read-pat-subscr	thru ab1-99-exit  
	    if flag-pat-not-ok  
	    then  
		go to ab0-99-exit  
	    else  
		next sentence  
*	    endif  
	else  
	    next sentence.  
*	endif  
*   endif  
  
*   ( if screen requested is brief )  
    if flag-normal-brief-b  
    then  
	move zero			to ws-nbr-claims-read  
	perform pa0-display-brief-screen  
					thru pa0-99-exit  
	if flag-found-claim-y  
	then  
	    go to ab0-99-exit  
	else  
	    move 16			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to ab0-99-exit  
*	endif  
    else  
*	( screen request is normal )  
*       ( access all claims selecting patient by non-acronym )
*	  ++++++++++++++++++++++++++++++++++++++++++++++++++
	if    acpt-direct-chart-flag = "!"  
           or acpt-direct-chart-flag = '#'  
* 2002/04/05 - MC - put '$' before chart nbr when user access claims by chart nbr
          or  acpt-direct-chart-flag = '$'
*2002/04/05 - end
	then  
	    perform ab1-read-pat-subscr	thru ab1-99-exit  
	    if flag-pat-not-ok  
	    then  
		go to ab0-99-exit  
	    else  
		next sentence.  
*	    endif  
*	(else)  
*	endif  
*   endif  
  
    move 'N'				to flag-agent-display.  
    move 0				to ctr-nbr-claims-displayed.  
  
    perform ia0-display-all-claims-for-pat  
					thru ia0-99-exit.  
*  (2000/jun/12 B.E.)
*  (reset flag for next loop)
   move " "				to flag-ref-fld.  
ab0-99-exit.  
    exit.  
  
  
ab1-read-pat-subscr.  
  
    move "Y"				to flag.  
    perform ba0-read-non-acr-pat	thru ba0-99-exit.  
  
    if flag-pat-not-ok  
    then  
	move 11				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ab1-99-exit  
    else  
  
*	(*  access by direct id or chart nbr  or ohip nbr *)  
	move spaces			to key-claims-mstr  
*mf	move ws-key-pat-mstr		to key-claims-mstr  
	move ws-key-pat-mstr		to clmdtl-p-claims-mstr
*mf	move "P"			to key-clm-key-type.
        move "P"                        to clmdtl-b-key-type.
*   endif  
  
ab1-99-exit.  
    exit.  


ba0-read-non-acr-pat.  
  
    if acpt-direct-chart-flag = '#'  
    then  
       perform xf2-access-patient-hc          thru xf2-99-exit  
    else    
*2002/04/05 - MC - access by chart nbr
       if acpt-direct-chart-flag = '$'
       then 
           perform xf4-access-patient-chrt  thru xf4-99-exit  
       else
*2002/04/05 - end	

*      if acpt-DIREct-id-or-chart numeric  
       if acpt-ohip-nbr           numeric  
       then  
*mf       move acpt-ohip-nbr                  to od-pat-ohip-mmyy  
	  move acpt-ohip-nbr		      to pat-ohip-mmyy
          perform xf0-access-patient-od       thru xf0-99-exit  
       else  
*2002/04/05 - MC - comment out
*          if acpt-d-or-c-alpha2 numeric  
*          then  
*             perform xf4-access-patient-chrt  thru xf4-99-exit  
*          else  
*2002/04/05 - end
*mf          move acpt-direct-id-or-chart     to od-pat-ohip-mmyy-r  
             move acpt-direct-id-or-chart     to pat-ohip-mmyy-r  
             perform xf0-access-patient-od    thru xf0-99-exit.  
*         endif.  
*      endif.  
*   endif.  
  
ba0-99-exit.  
    exit.  
ca0-user-verif-of-sel-pat.  
  
    perform ca1-acpt-verification	thru ca1-99-exit.  
  
    if not-ok  
    then  
	display scr-reject-entry  
	display confirm  
	stop " "  
	display blank-line-24.  
*   (else)  
*   endif  
  
ca0-99-exit.  
    exit.  
  
  
  
ca1-acpt-verification.  
    move "Y" to flag.

ca1-acpt-verification-00.  
  
    display scr-verification-screen.  
    accept  scr-verification-screen.  
  
    if flag =   "Y"  
	     or "N"  
    then  
	next sentence  
    else  
	move 1				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ca1-acpt-verification-00.  
*   endif  

ca1-99-exit.  
    exit.  
  
copy "db0_mod10_check_digit.rtn".  
  
dc0-mod10-check-digit-for-1-2.  
  
    move 0				to ws-temp  
					   ws-temp-1  
					   ws-temp-2.  
  
    add  ws-chk-nbr-2  
	 ws-chk-nbr-4  
  	 ws-chk-nbr-6			giving ws-temp.  
  
    add  ws-chk-nbr-1  
	 ws-chk-nbr-1			giving ws-temp-2.  
    add  ws-temp-2a			to ws-temp-1.  
    add  ws-temp-2b			to ws-temp.  
  
    add  ws-chk-nbr-3  
	 ws-chk-nbr-3			giving ws-temp-2.  
    add  ws-temp-2a			to ws-temp-1.  
    add	 ws-temp-2b			to ws-temp.  
  
    add  ws-chk-nbr-5  
	 ws-chk-nbr-5			giving ws-temp-2.  
    add  ws-temp-2a			to ws-temp-1.  
    add	 ws-temp-2b			to ws-temp.  
  
    add  ws-chk-nbr-7  
  	 ws-chk-nbr-7			giving ws-temp-2.  
    add  ws-temp-2a			to ws-temp-1.  
    add	 ws-temp-2b			to ws-temp.  
  
    move ws-temp 			to ws-temp-2.  
    add  ws-temp-2b			to ws-temp-1.  
  
    subtract ws-temp-1			from 10  
					giving ws-temp.  
  
    if ws-temp < 0  
    then  
        multiply ws-temp                by -1  
                                        giving ws-temp.  
  
    if        ws-temp      = ws-chk-nbr-8  
    then  
	move "Y"			to flag  
    else  
	move "N"			to flag.  
  
dc0-99-exit.  
    exit.  

* MC16

dd0-check-version-cd.

  if ws-pat-version-cd-1 = ' ' then next sentence                 else
  if ws-pat-version-cd-1 = 'a' then move 'A' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'b' then move 'B' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'c' then move 'C' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'd' then move 'D' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'e' then move 'E' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'f' then move 'F' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'g' then move 'G' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'h' then move 'H' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'i' then move 'I' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'j' then move 'J' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'k' then move 'K' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'l' then move 'L' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'm' then move 'M' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'n' then move 'N' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'o' then move 'O' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'p' then move 'P' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'q' then move 'Q' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'r' then move 'R' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 's' then move 'S' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 't' then move 'T' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'u' then move 'U' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'v' then move 'V' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'w' then move 'W' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'x' then move 'X' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'y' then move 'Y' to ws-pat-version-cd-1 else
  if ws-pat-version-cd-1 = 'z' then move 'Z' to ws-pat-version-cd-1.

  if ws-pat-version-cd-2 = ' ' then next sentence                 else
  if ws-pat-version-cd-2 = 'a' then move 'A' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'b' then move 'B' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'c' then move 'C' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'd' then move 'D' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'e' then move 'E' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'f' then move 'F' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'g' then move 'G' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'h' then move 'H' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'i' then move 'I' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'j' then move 'J' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'k' then move 'K' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'l' then move 'L' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'm' then move 'M' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'n' then move 'N' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'o' then move 'O' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'p' then move 'P' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'q' then move 'Q' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'r' then move 'R' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 's' then move 'S' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 't' then move 'T' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'u' then move 'U' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'v' then move 'V' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'w' then move 'W' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'x' then move 'X' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'y' then move 'Y' to ws-pat-version-cd-2 else
  if ws-pat-version-cd-2 = 'z' then move 'Z' to ws-pat-version-cd-2.

* check to make sure version cd is alpha
  if         ws-pat-version-cd = spaces
        or  (     ws-pat-version-cd-2 = spaces
             and (ws-pat-version-cd-1 >= 'A' and ws-pat-version-cd-1 <= 'Z')
            )
        or  (    (ws-pat-version-cd-1 >= 'A' and ws-pat-version-cd-1 <= 'Z')
             and (ws-pat-version-cd-2 >= 'A' and ws-pat-version-cd-2 <= 'Z')
            )
  then
        next sentence
  else
        move 53                        to err-ind.
* endif

dd0-99-exit.
    exit.

*MC16 - end
  
ea0-read-display-a-claim.  

*mf
    move "B"				to ws-clm-read-ind
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
  
    if not-ok  
    then  
	move 2				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ea0-99-exit.  
*   (else)  
*   endif  
  
    move clmhdr-pat-ohip-id-or-chart of claim-header-rec  
					to key-pat-mstr of pat-mstr.  
    move 'N'				to flag-pat.  
    perform xf5-access-patient		thru xf5-99-exit.  
  
    display blank-id.  
  
    perform xl0-setup-claim-nbr-disp	thru xl0-99-exit.  
  
    display scr-dis-claim-id.  
    display scr-dis-clmhdr-lit.  
    if flag-normal-tech-n  
    then  
	display scr-dis-clmdtl-lit  
    else  
	display scr-dis-clmdtl-lit-t.  
*   endif  
  
    perform xd0-display-claim		thru xd0-99-exit.  

*   CASE
    if   flag-update-trailer-info
      or flag-update-reference-field
    then
        perform xg0-update-claim        thru xg0-99-exit.
*   endif
    if flag-update-header-rec
    then
        perform ja0-update-head         thru ja0-99-exit.
*   endif
    if flag-update-details
    then
        perform ja1-update-detail       thru ja1-99-exit
             varying i
             from    1
             by      1
* 2012/05/30 - MC6 - update claim header if serv date from the detail is < clmhdr-serv-date
*            until i > ss-clmdtl.
             until i > ss-clmdtl
*       if save-serv-date < clmhdr-serv-date of claim-header-rec
        if save-serv-date not = clmhdr-serv-date of claim-header-rec
        then
            move save-serv-date 	to clmhdr-serv-date of claim-header-rec
	    perform xe0-rewrite-clmhdr thru xe0-99-exit.
*  	endif 
* 2012/05/30 - end

*   endif

    if flag-update-patient
    then
        perform ga0-update-pat          thru ga0-99-exit.
*   endif

* 2007/10/04 - MC - this user-id check only for RMA
*   if    flag-process-claim-adjustment
    if    flag-process-claim-adjustment and site-id = 'RMA'
* 2007/10/04 - end
    then
* 2005/06/20 - MC - include Thekla & O'Hara & exclude Johnson
*        if  (ws-user-id = 101 or 103 or 104 or  105 or 119 or 124)
* 	                  |      |      |       |      |      |
*		  	  v      v      v       v      v      v
*		          brad   moira  johnson yas    rma14  rma19
*						       lori   susan
* 2007/01/30 - MC - exclude Kristin  
**      if  (ws-user-id = 101 or 103 or 105 or  108 or 119 or 121 or  124   or  129)
* 	                  |      |      |       |      |      |	      |	         |
*		  	  v      v      v       v      v      v       v          v
*		          brad   moira  yas    rma3    rma14  rma16   rma19    rma24
*					       Thekla  lori   Linda O  susan   Kristin
* 2007/07/03 - MC - include Terry Thomson
*       if  (ws-user-id = 101 or 103 or 105 or  108 or 119 or 121 or  124 )
* 	                  |      |      |       |      |      |	      |	  
*		  	  v      v      v       v      v      v       v  
*		          brad   moira  yas    rma3    rma14  rma16   rma19   
*					       Thekla  lori   Linda O  susan  
* 2007/09/20 - MC - change vbalue of ws-user-id
*       if  (ws-user-id = 101 or 103 or 105 or  108 or 119 or 121 or  124 or 112 )

*        if  (ws-user-id = 100 or 101 or 105 or  135 or 147 or 149 or  152 or 139 )
* 2007/09/26 - BRAD added RMA by emergency use due to crash on use to different box - comment by MC
*        if  (ws-user-id = 100 or 101 or 105 or  135 or 147 or 149 or  152 or 139 )
* 2007/10/04 - change again because for RMABKP box 
*        if  (ws-user-id = 143 or 100 or 101 or 105 or 135 or 147 or 149 or 152 or 139 )
* MC14 - disable rma3 which has reassigned to Tanya
*        if  (ws-user-id = 130 or 133 or 134 or 137 or 102 or 113 or 115 or 118 or 106 )
* 	                  |      |      |      |       |      |      |	     |	    | 
*		  	  v      v      v      v       v      v      v       v      v 
*		          rma    brad   moira  yas    rma3    rma14  rma16   rma19  rma7 
*					              Thekla  lori   Linda O  susan Terry 
*        if  (ws-user-id = 130 or 133 or 134 or 137 or 113 or 115 or 118 or 106 )
* MC15 - include rma9 (Shivani) to do the auto adjustment
*        if  (ws-user-id = 130 or 133 or 134 or 137 or 108 or 113 or 115 or 118 or 106 )
* 	                  |      |      |      |       |      |      |	     |	    | 
*		  	  v      v      v      v       v      v      v       v      v 
*		          rma    brad   moira  yas    rma9    rma14  rma16   rma19  rma7 
*					              Shivani Lori   Linda O  Susan Terry 
* MC17 - include rma3 (Jillian) to do the auto adjustment 
*        if  (ws-user-id = 130 or 133 or 134 or 137 or 102 or 108 or 113 or 115 or 118 or 106 )
* 	                  |      |      |      |       |      |      |      |	   |	  | 
*		  	  v      v      v      v       v      v      v      v      v      v
*		          rma    brad   moira  yas    rma3   rma9    rma14  rma16  rma19  rma7 
*					            Jillian  Shivani Lori   Linda O  Susan Terry 
*       if  (ws-user-id = 130 or 133 or 134 or 137 or 108 or 113 or 115 or 118 or 106 )
        if  (ws-user-id = 130 or 133 or 134 or 137 or 102 or 108 or 113 or 115 or 118 or 106 )
* MC17 - end
* MC15 - end
* MC14 - end
* 2007/10/04 - end

* 2007/09/20  - end
* 2007/07/03 - end
* 2007/01/30 - end
* 2005/06/20 - end
	then
            perform ha0-create-adj-rec      thru ha0-99-exit
	else
	    move 48                 	to err-ind
	    perform za0-common-error 	thru za0-99-exit
*	endif
    else
	next sentence.
*   endif

    if flag-update-total-claim
    then
        perform ga0-update-pat          thru ga0-99-exit
        perform ja0-update-head         thru ja0-99-exit
        perform ja1-update-detail       thru ja1-99-exit
             varying i
             from    1
             by      1
             until i > ss-clmdtl
* 2012/08/08 - MC6
        move save-serv-date 	to clmhdr-serv-date of claim-header-rec
* 2012/05/30 - end
        perform xg0-update-claim        thru xg0-99-exit.
*   endif

    if flag-update-status-to-card
    then
	perform la0-preset-card-status  thru la0-99-exit.
*   endif

    if flag-call-elig-history-screen
    then
	perform na0-call-elig-history-disp-pgm
					thru na0-99-exit.
*   endif

* 2002/11/23 - MC  
    if flag-call-costing-screen
    then
	perform na1-call-costing-disp-pgm
					thru na1-99-exit.
*   endif
* 2002/11/12 - end

* 2011/02/09 - MC3 
    if flag-update-deceased-pat
    then
       perform yy3-update-rejected-claim   thru    yy3-99-exit.
*   endif
* 2011/02/09 - end


*   ENDCASE
ea0-80-end-case.

ea0-99-exit.  
    exit.  



ga0-update-pat. 
   move " " to dummy.
  
ga0-verify-birth-date.  
  
    display scr-acpt-birth-yy.  
    accept  scr-acpt-birth-yy.  
  
*   (validate yy entered)  
*   if   ws-pat-birth-date-yy > sys-yy  
*   then  
*	move 31		to err-ind  
*	perform za0-common-error	thru za0-99-exit  
*	go to ga0-verify-birth-date.  
*   (else)  
*   endif  
  
    display scr-acpt-birth-mm.  
    accept  scr-acpt-birth-mm.  
    display scr-acpt-birth-dd.  
    accept  scr-acpt-birth-dd.  
  
    move "Y"				to flag.  
    if   ws-pat-birth-date-mm < 01  
      or ws-pat-birth-date-mm > 12  
    then  
	move "N"			to flag  
    else  
	if   ws-pat-birth-date-dd < 01  
	  or ws-pat-birth-date-dd > max-nbr-days (ws-pat-birth-date-mm)  
	then  
	    move "N"			to flag.  
*   endif  
  
    if not-ok  
    then  
	move 27				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ga0-verify-birth-date.  
*   (else)  
*   endif  

*	(invalid if birth-date > current system date)  
    if ws-pat-birth-date > sys-date  
    then  
 	move 4 				to err-ind  
 	perform za0-common-error	thru za0-99-exit  
 	go to ga0-verify-birth-date.  
*   (else)  
*   endif  
  
* (y2k - note checking last 2 digits of 4 digit year against 2 character year!)
*   if   ws-pat-birth-date-yy    not = ws-pat-chart-yy  

* 2002/06/17 - MC - no longer needed to check birth date with chart nbr    
*   if   ws-pat-birth-date-yy-34 not = ws-pat-chart-yy
*     or ws-pat-birth-date-mm not = ws-pat-chart-mm  
*   then  
*	move 4				to warn-ind  
*	perform zd0-common-warning	thru zd0-99-exit.  
*   endif  
* 2002/06/17 - end  

ga0-acpt-version-cd.  
  
    display scr-acpt-version-cd.  
    accept  scr-acpt-version-cd.  

* MC16
    if ws-pat-version-cd not = spaces
    then
        move 0                          to  err-ind
*       (upshift version code if lower case)
        perform dd0-check-version-cd     thru dd0-99-exit
        display scr-acpt-version-cd
        if err-ind not = 0
        then
            perform za0-common-error    thru za0-99-exit
            go to ga0-acpt-version-cd.
*       endif
* MC16 - end

ga0-acpt-expiry-date.  
  
    display scr-acpt-expiry-mm.  
    accept  scr-acpt-expiry-mm.  
  
    display scr-acpt-expiry-yy.  
    accept  scr-acpt-expiry-yy.  
  
    if ws-pat-expiry-date = '0000'  
    then  
	next sentence  
    else  
	if ws-pat-expiry-mm < 1  
        or ws-pat-expiry-mm > 12  
	then  
	    move 29			to err-ind  
	    perform za0-common-error 	thru za0-99-exit  
	    go to ga0-acpt-expiry-date.  
*	endif  
*   endif  
  
ga0-acpt-mess-code.  

*   (if eligibility data has been updated AND a message was on file for patient,
*    the systems assumes that the new patient data corrects the error signified
*    by message and automatically blanks out the message and set the 'R'e-submit
*    claim indicator. Note that later in the logic the full processing of the
*    change to eligibility info is made including updating f086)
    if    (   ws-pat-version-cd not = hold-version-cd
           or ws-pat-birth-date not = hold-pat-birth-date
	  )
      and (
           ws-pat-mess-code <> spaces
	  )
    then
	move spaces			to ws-pat-mess-code
 	move "X"			to clmhdr-tape-submit-ind
	display scr-acpt-clmhdr-values
        display scr-acpt-mess-code  
	move 1				to warn-ind
	perform zd0-common-warning	thru zd0-99-exit
    else
        display scr-acpt-mess-code  
        accept  scr-acpt-mess-code.  
*   endif
  
ga0-acpt-subscr-addr.  
  
    display scr-acpt-subscr-addr1.  
    accept  scr-acpt-subscr-addr1.  
  
    display scr-acpt-subscr-addr2.  
    accept  scr-acpt-subscr-addr2.  
  
    display scr-acpt-subscr-addr3.  
    accept  scr-acpt-subscr-addr3.  
  
    display scr-acpt-postal-code.  
    accept  scr-acpt-postal-code.  

* 2002/06/17 - MC 
*copy "test_patient_province_for_out_of_prov.rnt".
*   then  
*   	display scr-acpt-country  
*   	accept  scr-acpt-country.  
*   endif  
* 2002/06/17 - end
  
*   (if adding new message, then place claim on "H"old)
    if   (    ws-pat-mess-code not = ' '
	  and hold-mess-code       = ' '
	 )  
      or (ws-pat-mess-code not = hold-mess-code)  
    then  
        move 'H'			 to clmhdr-tape-submit-ind  
	perform ga1-check-for-confidentiality thru ga1-99-exit  
	display scr-acpt-confidential-flag.  
*   endif  
  
*   (determine if user has changed eligibility data - birth date)
    if ws-pat-birth-date not = hold-pat-birth-date  
    then  
	move 'Y'			 to elig-flag-birth-date
	move hold-pat-birth-date	 to ws-pat-last-birth-date.
*   endif  
  
*   (determine if user has changed eligibility data - version cd)
    if ws-pat-version-cd not = hold-version-cd  
    then  
	move 'Y'		to elig-flag-version-cd
	move hold-version-cd	to ws-pat-last-version-cd.  
*   endif  
  
    move spaces 			to update-confirmation.  
    perform zb0-accept-confirm-update 	thru zb0-99-exit.
  
*   CASE
    if update-rejected  
    then  
	go to ga0-99-exit
    else
    if update-modify
    then
	go to ga0-update-pat.
*   ENDCASE
  
*   (if OHIP eligibility data changed then update last maintenance date,
*    and write corrected-patient record so that any on-hold claims can 
*    be resubmitted. Note that previous logic will have blanked out any 
*    existing message for patient if eligibility info was changed)

    if   elig-flag-version-cd = "Y"  
      or elig-flag-birth-date = "Y"
    then  
*	(force resubmit process to run next cycle)
        open output resubmit-file
        close       resubmit-file

* 2010/06/21 - MC1
*      perform yy0-process-pat-elig-change thru yy0-99-exit.
       perform yy0-process-pat-elig-change thru yy0-99-exit
       perform yy3-update-rejected-claim   thru    yy3-99-exit.
* 2010/06/21 - end

*   endif

* 2000/may/17 B.E. - not sure why flag reset to "N" so removed this logic
*	if clmhdr-confidential-flag = 'Y'  
*	then  
*	    move 'N'			 to clmhdr-confidential-flag.  
*       endif  
*   endif  

*   (if adding new message, the claim would have been put on "H"old" in above
*    logic. Update of database has been confirmed, so now write a record of
*    patient into the 'rejected-claims-rec' file. Program u086.qts will use
*    this record as a "driver" record to search for all other claims for this
*    patient and place then also on Hold)
    if    ws-pat-mess-code not = ' '
      and hold-mess-code       = ' '
    then 
        perform ga2-create-rejected-claim thru ga2-99-exit.
*   endif

   perform xe0-rewrite-clmhdr			thru xe0-99-exit.

   if ws-pat-read-ind = "IK"  
    then  
       perform xe1-re-write-patient     	thru xe1-99-exit  
    else  
       if ws-pat-read-ind = "OD"  
       then  
          perform xe2-re-write-patient-od  	thru xe2-99-exit  
       else  
          if ws-pat-read-ind = "HC"  
          then  
             perform xe3-re-write-patient-hc    thru xe3-99-exit  
          else  
             if ws-pat-read-ind = "AC"  
             then  
                perform xe4-re-write-patient-acr   thru xe4-99-exit  
             else  
                perform xe5-re-write-patient-chrt  thru xe5-99-exit.  
*            endif.  
*         endif.  
*      endif.  
*   endif.  
* brad999 
    display scr-dis-clmhdr-lit. 
    display scr-acpt-clmhdr-values.  
  
  
ga0-99-exit.  
    exit.  
  
copy "d001_d003_confidentiality_check.rtn".
  
ga2-create-rejected-claim.  
  
    move zero				to hold-claim-nbr.  
    move clmhdr-clinic-nbr-1-2		to hold-clinic-nbr-1-2.  
    move clmhdr-doc-nbr			to hold-doc-nbr.  
    move clmhdr-batch-nbr-7-9		to hold-batch-nbr.  
    move clmhdr-claim-nbr		to hold-claim-no.  
    move hold-claim-nbr			to claim-nbr.  
    move clmhdr-pat-ohip-id-or-chart of claim-header-rec  
	to clmhdr-pat-id of rejected-claims-rec.  
    move clmhdr-doc-nbr			to doc-nbr of rejected-claims-rec.  
    move ws-pat-mess-code		to mess-code of rejected-claims-rec.  
    move clmhdr-loc of claim-header-rec to rejected-loc of rejected-claims-rec.  
    
*   brad1
    move " " 				to logically-deleted-flag.
 
*mf    write rejected-claims-rec.  
    write rejected-claims-rec
	invalid key
           move 16                         to warn-ind
           perform zd0-common-warning      thru zd0-99-exit.
           go to ga2-99-exit.
  
    add 1				to ctr-write-rejected-claims.  
  
ga2-99-exit.  



*
* MOVED TO process_pat_eligibility_change.rtn 
*  
*ga3-create-corrected-pat.  
* 
*    move clmhdr-pat-ohip-id-or-chart of claim-header-rec  
*	to clmhdr-pat-ohip-id-or-chart of pat-id-rec.  
*    move ws-pat-last-birth-date  
*	to pat-last-birth-date of pat-id-rec.  
*    move ws-pat-last-version-cd  
*	to pat-last-version-cd of pat-id-rec.  
*  
*    write pat-id-rec.  
*  
*    add 1			to ctr-write-corrected-pat.  
*  
*ga3-99-exit.  
*    exit.  
  
  
ha0-create-adj-rec.  
*   (write driver record that will force automatic adjustment of claim)

*   (read claim's clinic record to determine current PED for that clinic)  
    move clmhdr-clinic-nbr-1-2	to iconst-clinic-nbr-1-2.  
    read iconst-mstr  
	invalid key  
		move 42 	to err-ind  
		perform za0-common-error thru za0-99-exit  
		go to ha0-99-exit.  
  
*   (verify that claim being adjusted is not part of the current cycle -- 
*    note that clinci's cycle/PED is tested rather than zero submit date
*    since held claims can end up with a zero submit date and are NOT part
*    of current cycle and can be adjusted)
    if    clmhdr-date-period-end = iconst-date-period-end
      and clmhdr-cycle-nbr       = iconst-clinic-cycle-nbr  
    then  
	move 43  		 to	err-ind  
	perform za0-common-error thru	za0-99-exit  
 	go to ha0-99-exit.  
*   endif  
*    if clmhdr-submit-date = spaces or zero  
*    then  
*	move 43  		to err-ind  
*	perform za0-common-error thru za0-99-exit  
*	go to ha0-99-exit.  
*   endif  

*   (all edits have been passed so claim can be automatically update - allow
*    update of reference field and confirm process before performing update)
    perform ze0-accept-reference-field	thru ze0-99-exit.

*   (obtain confirmation that 'A'djustment is to be made)
    move spaces                         to update-confirmation.
    perform zb0-accept-confirm-update   thru zb0-99-exit.
*   CASE
    if     update-modify
    then
	go to ha0-create-adj-rec
    else
    if     update-rejected
    then
        move 3                          to warn-ind
        perform zd0-common-warning      thru zd0-99-exit
	go to ha0-99-exit
    else
*       (fall through and perform the update)
	next sentence.
*   endif

*   (update header rec since reference field may have been altered)
    perform xe0-rewrite-clmhdr          thru xe0-99-exit. 

*   (write driver record that will force automatic adjustment of claim)
*mf move spaces			to adj-claim-rec.  
    move zeros			to adj-claim-rec.  
    move clmhdr-pat-acronym	to adj-pat-acronym.  
    move clmhdr-batch-nbr	to adj-batch-nbr.  
    move clmhdr-claim-nbr	to adj-claim-nbr.  

*   (adjustment of entire claim is applied against the detail with the 
*    largest difference between paid/billed. This routine loops through 
*    claim details to find that detail - note if it's important to the 
*    doctor to write off the correct oma code then use d004 to create
*    specific adjustments)
*    perform ha1-find-non-blank-oma-cd-rec
*				thru ha1-99-exit
*        varying i 	
*	   from 1 
*	     by 1 
*	until i > ctr-nbr-claims-displayed.
    move spaces			to save-oma-cd-suff.
    move zero			to amt-largest-diff
				   save-adj-serv-date.
    perform ha1-detail-with-largest-diff thru ha1-99-exit
        varying i
           from 1
             by 1
          until i >   ss-clmdtl.
    move save-oma-cd-suff	to adj-oma-cd-suff.  
    move save-adj-serv-date	to adj-serv-date.  
    move clmhdr-agent-cd	to adj-agent-cd.  
    compute adj-amt-bal = hold-clmhdr-bal * -1.  
    move save-diag-cd		to adj-diag-cd.  
    move save-line-no		to adj-line-no.  
  
    write adj-claim-rec.  
  
ha0-99-exit.  
    exit.  



ha1-detail-with-largest-diff.
*   (save oma code of detail with largest difference between billed/paid)

*   (use absolute value of balance due for each dtl)
    if hold-clm-amt-due(i) < 0	
    then
	compute ws-bal-dtl	=   0 
				  - hold-clm-amt-due(i)
    else	
	move hold-clm-amt-due(i)	to ws-bal-dtl.
*   endif

    if ws-bal-dtl > amt-largest-diff
    then
	move ws-bal-dtl			to amt-largest-diff
        move hold-oma-cd      (i)	to save-oma-cd
        move hold-oma-suff    (i)	to save-oma-suff
	move hold-clm-svc-date(i)	to save-adj-serv-date.
*   endif
        
ha1-99-exit.
    exit.


 
ia0-display-all-claims-for-pat.  
  
*	(read claim's header rec)  
*mf
    move "P"				to      ws-clm-read-ind. 

ia0-10-read-claim.

    perform xc0-read-claims-mstr	thru	xc0-99-exit.  
    if not-ok  
    then  
	move 2				to	err-ind  
	perform za0-common-error	thru	za0-99-exit  
	go to ia0-99-exit.  
*   (else)  
*   endif  
  
    if ws-key-pat-mstr = clmhdr-pat-ohip-id-or-chart of claim-header-rec  
    then  
	next sentence  
    else  
	if ctr-nbr-claims-displayed > 0  
	then  
            if    flag-agent-on 
	      and no-claims-displayed  
	    then  
		move 26			to err-ind  
		perform za0-common-error 	thru za0-99-exit  
		go to ia0-99-exit  
	    else  
	        move 8			to err-ind  
	        perform za0-common-error	thru za0-99-exit  
	        go to ia0-99-exit  
	else  
	    move 12			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to ia0-99-exit.  
*	endif  
*   endif  
  
    move clmhdr-batch-nbr		to clmdtl-b-batch-num.  
    move clmhdr-claim-nbr		to clmdtl-b-claim-nbr.  
    move "B"				to clmdtl-b-key-type.       
    move zeros				to clmdtl-b-oma-cd  
				   	   clmdtl-b-oma-suff  
				   	   clmdtl-b-adj-nbr.  
  
ia0-90-disp-claim.  
  
    move "B"				to   ws-clm-read-ind. 
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
    
    if ctr-nbr-claims-displayed = 0  
    then  
	display blank-id  
	display scr-dis-clmhdr-lit  
	if flag-normal-tech-n  
	then  
	    display scr-dis-clmdtl-lit  
	else  
	    display scr-dis-clmdtl-lit-t.  
*   (else)  
*   endif  
  
    if flag-agent-on  
        and clmhdr-agent-cd not = sel-agent-code  
    then  
        add 1			to ctr-nbr-claims-displayed  
	move 'N'		to flag		  
    else  
        perform xl0-setup-claim-nbr-disp	thru xl0-99-exit  
        display scr-dis-claim-id  
        perform xd0-display-claim		thru xd0-99-exit  
	if flag-agent-on  
	then  
	    move 'Y'		to flag-agent-display.  
*   endif  
  
    if not-ok  
    then  
	perform ia7-get-next-claim-by-patient thru ia7-99-exit  
	if ok  
	then  
*mf	    go to ia0-display-all-claims-for-pat  
	    go to ia0-10-read-claim 
	else  
	    move 8			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to ia0-99-exit.  
*	endif  
*   (else)  
*   endif  

*   CASE
    if flag-update-trailer-info
    then
        perform xg0-update-claim        thru xg0-99-exit.
*   endif
    if flag-update-header-rec
    then
        perform ja0-update-head         thru ja0-99-exit.
*   endif
    if flag-update-details
    then
        perform ja1-update-detail       thru ja1-99-exit
              varying i
              from    1
              by      1
* 2012/08/08 - MC6
*             until i > ss-clmdtl.
              until i > ss-clmdtl
        if save-serv-date not = clmhdr-serv-date of claim-header-rec
        then
            move save-serv-date 	to clmhdr-serv-date of claim-header-rec
	    perform xe0-rewrite-clmhdr thru xe0-99-exit.
*  	endif 
* 2012/08/08 - end

* 2012/05/30 - end
*   endif 
    if flag-update-patient
    then
        perform ga0-update-pat          thru ga0-99-exit.
*   endif
    if flag-process-claim-adjustment
    then
        perform ha0-create-adj-rec      thru ha0-99-exit.
*   endif
    if flag-update-total-claim
    then
        perform ga0-update-pat          thru ga0-99-exit
        perform ja0-update-head         thru ja0-99-exit
        perform ja1-update-detail       thru ja1-99-exit
             varying i
             from    1
             by      1
             until i > ss-clmdtl
* 2012/08/08 - MC6
        move save-serv-date 	to clmhdr-serv-date of claim-header-rec
* 2012/08/08 - end
        perform xg0-update-claim        thru xg0-99-exit.
*   endif
*   ENDCASE

ia0-80-end-case.
    if    not flag-update-done
      and not flag-update-done-alternative
      and not flag-update-header-rec
      and not flag-update-patient
      and not flag-update-details
      and not flag-process-claim-adjustment
      and not flag-update-trailer-info
      and not flag-call-elig-history-screen
* 2002/11/12 - MC
      and not flag-call-costing-screen
* 2002/11/12 - end
* 2011/02/09 - MC3
      and not flag-update-deceased-pat
* 2011/02/09 - end
    then
	move spaces                           to   update-confirmation
	perform zb0-accept-confirm-update     thru zb0-99-exit
*	CASE
	if update-confirmed
	then
            perform ia2-update-all      thru ia2-99-exit
	else
	if update-modify
	then
	    go to ia0-display-all-claims-for-pat. 
*       ENDCASE
*	endif
*   endif
*   ENDCASE
  
ia0-99-exit.  
    exit.  
  
ia2-update-all.  

    perform xe0-rewrite-clmhdr		thru xe0-99-exit.  
  
    perform jc0-rewrite-detail     thru jc0-99-exit  
                    varying i  
                    from    1  
                    by      1  
                    until i > ss-clmdtl  
  
    if ws-pat-read-ind = "IK"  
    then  
       perform xe1-re-write-patient     	thru xe1-99-exit  
    else  
       if ws-pat-read-ind = "OD"  
       then  
          perform xe2-re-write-patient-od  	thru xe2-99-exit  
       else  
          if ws-pat-read-ind = "HC"  
          then  
             perform xe3-re-write-patient-hc    thru xe3-99-exit  
          else  
             if ws-pat-read-ind = "AC"  
             then  
                perform xe4-re-write-patient-acr   thru xe4-99-exit  
             else  
                perform xe5-re-write-patient-chrt  thru xe5-99-exit.  
*            endif.  
*         endif.  
*      endif.  
*   endif.  
  
    perform xg2-desc-dtl-update 	thru xg2-99-exit  
    	varying ss-desc from 1 by 1  
	until ss-desc > 5.  
  
ia2-99-exit.  
    exit.  
  
ia7-get-next-claim-by-patient.  
  
    add 1				to pat-count.  

*mf move "P"				to key-clm-key-type.  
*mf move clmhdr-pat-key-data		to key-clm-data-r  
    move clmhdr-pat-key-data  		to clmdtl-p-data of clmdtl-p-claims-mstr.   
    move "P"				to ws-clm-read-ind. 
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
  
    if not-ok  
    then  
	move 3				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ia7-99-exit.  
*   (else)  
*   endif  
  
    perform xc1-read-claims-mstr-suppress thru xc1-99-exit  
		pat-count times.  
  
    if not-ok  
    then  
	move 3				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ia7-99-exit.  
*   (else)  
*   endif  
  
    perform xc2-read-claims-mstr-next	thru xc2-99-exit.  
  
*mf move clmhdr-claim-id 		to key-clm-data.  
*mf move "B"				to key-clm-key-type.  
    move clmhdr-claim-id 		to clmdtl-b-data.  
    move "B"				to clmdtl-b-key-type.  
    move "B"				to ws-clm-read-ind.     
  
ia7-99-exit.  
    exit.  
 


 
ja0-update-head.  
    move " " to dummy.
  
ja01-verify-hosp.  
  
    move ws-hosp-nbr		    to ws-save-hosp.  
    move clmhdr-loc of claim-header-rec to ws-location.  

* 2011/05/25 - MC4
    accept scr-acpt-loc.
    if clmhdr-loc of claim-header-rec not = ws-location
    then
	perform ja00-check-batch-status	thru ja00-99-exit.
*   endif
* 2011/05/25 - end

  
* 2004/02/26 - MC - new call to location mstr for hospital nbr
*   (read claim's clinic record to determine current PED for that clinic)
    move clmhdr-clinic-nbr-1-2  to iconst-clinic-nbr-1-2.
    read iconst-mstr
        invalid key
                move 42         to err-ind
                perform za0-common-error thru za0-99-exit.

    perform xb0-verify-location         thru xb0-99-exit.
* 2004/02/26 - end

    display scr-acpt-hosp.  
* 99/dec/16 B.E. - remove input of hospital until clmhdr has room for 4 digit
*                  hospital
*    accept  scr-acpt-hosp.  

* 2004/02/26 - MC - the following if condition is no longer needed for checking
*    if ws-hosp-nbr not = ws-save-hosp
*   then
*       if ws-hosp-nbr-1 not = ws-loc-1
*       then
*           move 44                 to err-ind
*           perform za0-common-error    thru za0-99-exit
*           go to ja01-verify-hosp.
*       endif
*   endif
* 2004/02/26 - end
  
    move "Y"                        to  flag.  
  
    if ws-hosp-nbr-1 = spaces  
    then  
        move spaces                 to ws-hosp-nbr  
        display scr-acpt-hosp  
        go to ja02-verify-admit-date.  
*   endif
  
* 2004/02/26 - MC - no longer required to translation hospital
*                 - hospital nbr should be picked up from locations-mstr

*    perform jb0-trans-hosp      thru jb0-99-exit.

*    if not-ok
*    then
*        move 30                    to err-ind
*        perform za0-common-error   thru za0-99-exit
*       go to ja01-verify-hosp.
*   endif

*   display scr-acpt-hosp.

* 2004/02/26 - end

  
ja02-verify-admit-date.  
    display scr-acpt-admit-yy.  
    accept  scr-acpt-admit-yy.  

*   (y2k)  
*   if clmhdr-date-admit-yy = '00'
    if clmhdr-date-admit-yy = zeros
    then  
        move '00'               to clmhdr-date-admit-mm  
        move '00'               to clmhdr-date-admit-dd  
        display scr-acpt-admit-yy  
        display scr-acpt-admit-mm  
        display scr-acpt-admit-dd  
        go to ja03-verify-review.  
*   endif
  
*   (validate yy entered)  
*   (y2k)
*   if   clmhdr-date-admit-yy < 32  
*     or clmhdr-date-admit-yy > sys-yy  
    if   clmhdr-date-admit-yy > sys-yy  
    then  
	move 31		to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja02-verify-admit-date.  
*   (else)  
*   endif  
  
    display scr-acpt-admit-mm.  
    accept  scr-acpt-admit-mm.  
    display scr-acpt-admit-dd.  
    accept  scr-acpt-admit-dd.  
  
    move "Y"				to flag.  
    if   clmhdr-date-admit-mm < 01  
      or clmhdr-date-admit-mm > 12  
    then  
	move "N"			to flag  
    else  
	if   clmhdr-date-admit-dd < 01  
	  or clmhdr-date-admit-dd > max-nbr-days (clmhdr-date-admit-mm)  
	then  
	    move "N"			to flag.  
*       endif
*   endif  
  
    if not-ok  
    then  
	move 27				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja02-verify-admit-date.  
*   (else)  
*   endif  
  
*   (invalid if admit-date > current system date)  
    if clmhdr-date-admit > sys-date  
    then  
	move 32			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja02-verify-admit-date.  
*   (else)  
*   endif  

*   (invalid if admit-date > any of the service date's of claim)
    move "Y"					to   flag.
    perform ja3-check-admit-vs-svc-date	thru ja3-99-exit
		varying ss
		from     1
		by       1
		until   ss > ss-clmdtl.
    if not-ok
    then  
	move 47				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja02-verify-admit-date.  
*   (else)  
*   endif  
  
ja03-verify-review.  
    display scr-acpt-review.  
    accept  scr-acpt-review.  
  
    if clmhdr-manual-review = ' ' or 'Y'  
    then  
	next sentence  
    else  
	move  33			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja03-verify-review.  
*   endif  
  
    move clmhdr-tape-submit-ind        to tape-submit-ind-hold.  
ja04-verify-submit.  
 
    display scr-acpt-submit.  
    accept  scr-acpt-submit.  
 
*    NOTE: the below lines gives compile warning on check for null. current
*	   bug in d001 sometimes puts no space in this field so check
*	   works even though compile give warning!
* 2000/05/01 B.E. added 'C'ard submitted / "X" force resubmit regardless of
*		  other resubmit selection criteria
* 2000/06/13 B.E. don't allow "R" - to be used in the background updates
*   if clmhdr-tape-submit-ind = 'H' or 'R' or 'S' or 'Y' or ' ' or 'C' or 'X'
    if clmhdr-tape-submit-ind = 'H'        or 'S' or 'Y' or ' ' or 'C' or 'X'
    then  
	next sentence  
    else  
	move 34				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja04-verify-submit.  
*   endif  

* 2004/03/17 - MC
*   (read claim's clinic record to determine afp-flag)
    move clmhdr-clinic-nbr-1-2  to iconst-clinic-nbr-1-2.
    read iconst-mstr
        invalid key
                move 42         to err-ind
                perform za0-common-error thru za0-99-exit
                go to ja04-verify-submit.

    if     (   (iconst-clinic-card-colour = 'Y'  and
                clmhdr-status-ohip = 'I2')
            or (hold-clmhdr-bal <= 0)
           )
       and (   clmhdr-tape-submit-ind = 'R'
            or clmhdr-tape-submit-ind = 'X'
           )
*  2012/12/19 - MC7 - allow resubmit if health nbr = 1111111116 for CME claims
       and     ws-pat-health-nbr <> 1111111116 
*  2012/12/19 - end 
    then
        move 46                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ja04-verify-submit.
*   endif

* 2004/03/17 - end

    if    clmhdr-tape-submit-ind = "R"
* MC1
*      and (clmhdr-submit-date     =   spaces 
      and (clmhdr-submit-date of claim-header-rec     =   spaces 
				  or zero
	  )
    then

* brad2 make warning ??!!!
        move 46                 to err-ind
        perform za0-common-error thru za0-99-exit
        go to ja04-verify-submit.
*   endif

    if     (   clmhdr-tape-submit-ind = 'R'  
	    or clmhdr-tape-submit-ind = 'X')
       and (    clmhdr-agent-cd not = "0" 
            and clmhdr-agent-cd not = "2"
            and clmhdr-agent-cd not = "5")  
    then  
	move 37                         to err-ind  
        perform za0-common-error        thru za0-99-exit  
        go to ja04-verify-submit.  
*   endif.  
  
    if     clmhdr-tape-submit-ind    = ' '  
       and tape-submit-ind-hold   not = ' '  
    then  
	move 34                         to err-ind  
        perform za0-common-error        thru za0-99-exit  
        go to ja04-verify-submit.  
*   endif.  
  
    if     clmhdr-tape-submit-ind   = 'S'  
       and tape-submit-ind-hold not = 'S'  
    then  
	move 34                         to err-ind  
        perform za0-common-error        thru za0-99-exit  
        go to ja04-verify-submit.  
*   endif.  
 
 
    if    (    clmhdr-tape-submit-ind   = 'R'  
           and tape-submit-ind-hold not = 'R'
 	  )
       or (    clmhdr-tape-submit-ind   = 'X'  
           and tape-submit-ind-hold not = 'X'
 	  )
    then  
	open output resubmit-file  
        close       resubmit-file.  
*   endif.  
  
ja05-verify-doc-spec.  
    display scr-acpt-doc-spec.  
    accept  scr-acpt-doc-spec.  
  
ja06-verify-doc-nbr.  
**  display scr-acpt-doc-nbr.  
**  accept  scr-acpt-doc-nbr.  
  
**  move clmhdr-doc-nbr-ohip            to ws-chk-nbr.  
**  perform db0-mod10-check-digit	thru db0-99-exit.  
  
**  if not-ok  
**  then  
**      perform dc0-mod10-check-digit-for-1-2   thru dc0-99-exit.  
  
**  if not-ok  
**  then  
**	move 45			to err-ind  
**	perform za0-common-error	thru za0-99-exit  
**	if confirm-space not = "*"  
**	then  
**		go to ja06-verify-doc-nbr.  
*   endif  
  
**  move clmhdr-doc-nbr                 to doc-nbr of doc-mstr-rec.  
**  read doc-mstr  
**     invalid key  
**	move 39      			to err-ind  
**	perform za0-common-error	thru za0-99-exit  
**	go to ja06-verify-doc-nbr.  
  
**  if clmhdr-doc-nbr-ohip not = doc-ohip-nbr  
**  then  
**	move 40      			to err-ind  
**	perform za0-common-error	thru za0-99-exit  
**	go to ja06-verify-doc-nbr.  
* endif	  
  
ja07-verify-ref-doc.  
    display scr-acpt-ref-doc.  
    accept  scr-acpt-ref-doc.  
  
*	(if referring doc # not 0 then validate it according to a mod 10  
*	 check digit routine.  
  
    if    clmhdr-clinic-nbr-1-2 > "59" and clmhdr-clinic-nbr-1-2 < "66"  
      and clmhdr-refer-doc-nbr = 0  
    then  
	move  35		to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja07-verify-ref-doc.  
*   (else)  
*   endif  
  
    move clmhdr-refer-doc-nbr	to ws-chk-nbr  
  
    perform db0-mod10-check-digit	thru db0-99-exit.  
    if not-ok  
    then  
	perform dc0-mod10-check-digit-for-1-2  thru dc0-99-exit.  
  
    if not-ok  
    then  
	move 45				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	if   confirm-space not = "*"  
	  or confirm-space not = "^"  
	then  
		go to ja07-verify-ref-doc.  
*   (else)  
*   endif  
 
* 2013/07/31 - MC8 - comment out the below edit check 
*    if    clmhdr-clinic-nbr-1-2 = '22'  
*      and clmhdr-refer-doc-nbr = clmhdr-doc-nbr-ohip  
*    then  
*	move  38			to err-ind  
*	perform za0-common-error	thru za0-99-exit  
*	go to ja07-verify-ref-doc.  
*   endif  
* 2013/07/31 - end
  
ja08-acpt-conf-flag.  
  
    display scr-acpt-confidential-flag.  
    accept  scr-acpt-confidential-flag.  
  
    if clmhdr-confidential-flag = ' ' or 'Y' or 'N' or 'R'
    then  
	next sentence  
    else  
	move 41			to err-ind  
 	perform za0-common-error thru za0-99-exit  
	go to ja08-acpt-conf-flag.  
*   endif  
  
* 2010/07/12 - MC2 - allow to change payroll field for RMA & doc-dept = 41 or 42 or 43 or 75  
ja09-acpt-payroll.    

    if site-id = 'RMA' and clmhdr-doc-dept = 41 or 42 or 43 or 75
    then
        accept  scr-acpt-payroll 
* 2010/jul/19 - MC2 - cannot force user to enter value for older claims
*		- users should have started to enter after 2010/jun/10 or 2010/Jul/15 
*        if clmhdr-payroll >= '1' and <= '5' 
        if     (clmhdr-payroll >= '1' and <= '5' )  or clmhdr-date-sys <= 20100715
* 2010/jul/19 - end
    	then  
       	    next sentence  
    	else  
	    move 49			to err-ind  
 	    perform za0-common-error thru za0-99-exit  
	    go to ja09-acpt-payroll.
*       endif
*   endif  
* 2010/07/12 - end

*   if flag-ref-fld not = "M"  
*   then  
        move spaces to update-confirmation.  
	perform zb0-accept-confirm-update thru zb0-99-exit. 

*   else  
*       go to ja0-99-exit.  

*   CASE  
    if update-confirmed  
    then  
	perform xe0-rewrite-clmhdr	thru xe0-99-exit
    else
    if update-modify
    then
	go to ja0-update-head.
*   ENDCASE
  
ja0-99-exit.  
    exit.  

* 2011/05/25 - MC4

ja00-check-batch-status.

    move clmhdr-batch-nbr                      to key-batctrl-file.
    read batch-ctrl-file  key is key-batctrl-file
            invalid key
* MC13 - batch may be deleted at yearend
*               go to ja00-99-exit.
                next sentence. 
* MC13 - end

*  MC13 - include submit date check
*   if batctrl-batch-status = '0' or '1'
    if     (batctrl-batch-status = '0' or '1')
	and clmhdr-submit-date of claim-header-rec = zeroes or spaces
* MC13 - end
    then
* 2012/02/29 - MC5
*	next sentence
	perform xb0-verify-location	thru xb0-99-exit
    else
	move 50 			to err-ind
	perform za0-common-error 	thru za0-99-exit
        move ws-location 		to clmhdr-loc
        display scr-acpt-loc.
*   endif

ja00-99-exit.
    exit.

* 2011/05/25 - end


  
ja1-update-detail.  
  
    move 11                     to pline1.  
    add   i                     to pline1.  
  
  
ja12-verify-svc-date.  
    display scr-acpt-svc-date-yy.  
    accept  scr-acpt-svc-date-yy.  
* service date is entered as 4 digits no default allowed
**   (y2k - default century of year, if not entered)
*   move hold-clm-svc-date-yy(i)        to      century-year.
*   perform y2k-add-century-to-year     thru    y2k-99-exit.
*   move century-year                   to      hold-clm-svc-date-yy(i).
  
*   (validate yy entered)  
*   (y2k)
*   if   hold-clm-svc-date-yy (i) < 32  
*     or hold-clm-svc-date-yy (i) > sys-yy  
    if   hold-clm-svc-date-yy (i) > sys-yy  
    then  
	move 31				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja12-verify-svc-date.  
*   (else)  
*   endif  
  
    display scr-acpt-svc-date-mm.  
    accept  scr-acpt-svc-date-mm.  
    display scr-acpt-svc-date-dd.  
    accept  scr-acpt-svc-date-dd.  
  
    move "Y"				to flag.  
    if   hold-clm-svc-date-mm (i) < '01'  
      or hold-clm-svc-date-mm (i) > '12'  
    then  
	move "N"			to flag  
    else  
	move hold-clm-svc-date-mm (i)   to temp
	if   hold-clm-svc-date-dd (i) < '01'  
	  or hold-clm-svc-date-dd (i)> max-nbr-days ( temp )  
	then  
	    move "N"			to flag.  
*   endif  
  
    if not-ok  
    then  
	move 27				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja12-verify-svc-date.  
*   (else)  
*   endif  
  
*	(invalid if   svc-date (i) > current system date)  
    if hold-clm-svc-date (i) > sys-date  
    then  
	move 27				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to ja12-verify-svc-date.  
*   (else)  
*   endif  

* 2012/05/30 - MC6
    if i = 1                                  
    then 
	move hold-clm-svc-date (i) to save-serv-date.
*   endif
    if hold-clm-svc-date (i) < save-serv-date
    then 
	move hold-clm-svc-date (i) to save-serv-date.
*   endif
* 2012/05/30 - end

  
ja19-finish-acpt-date.  
  
ja11-verify-diag-code.  
  
    display scr-acpt-diag-cd.  
    accept  scr-acpt-diag-cd.  
  
    move "Y"                     to flag.  
  
*	(if blank or zero code entered accept as valid --  
*	-- if code entered then existance of key in diag mstr is validity check)  
    if hold-diag-cd(i) = spaces  
    then  
	move zero			to hold-diag-cd(i)  
	go to ja22-end-diag  
    else  
	if hold-diag-cd(i)             = zero  
	then  
	    go to ja22-end-diag.  
*	(else)  
*	endif  
*   endif  
  
    move hold-diag-cd(i)            	to diag-cd.  
  
    read  diag-mstr	
*mf	suppress data record  
	invalid key  
	    move 36			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
            move "N"                    to flag.  
  
    if not-ok  
    then  
        go to ja11-verify-diag-code.  
*   endif.  
  
ja22-end-diag.  
  
    if     ss-clmdtl = i  
* 2012/08/08 - MC6
*       and flag-ref-fld not = "M"  
* 2012/08/08 - end
    then  
        move spaces to update-confirmation  
	perform zb0-accept-confirm-update thru zb0-99-exit

*       CASE
        if update-confirmed  
        then  
            perform jc0-rewrite-detail     thru jc0-99-exit  
                    varying i  
                    from    1  
                    by      1  
                    until i > ss-clmdtl  
        else  
	if update-modify
*	    (return to detail that was just modified and allow updates)
            move 1                to i  
	    go to ja1-update-detail
 	else
*	    (if 'no' then fall through to exit and return to calling rtn with
*	     no update of claim)
	    move 3                          to warn-ind
	    perform zd0-common-warning      thru zd0-99-exit.
*	ENDASE 
  
ja1-99-exit.  
    exit.  
 


 
ja3-check-admit-vs-svc-date.

    if clmhdr-date-admit > hold-clm-svc-date (ss)
    then
	move "N"			to flag.
*   endif

ja3-99-exit.
    exit.

jb0-trans-hosp.  
  
*	(translate hospital code into the corresponding hospital number)  
  
    move zero			to	subs-hosp.  
jb11-10-hosp-loop.  
  
    add 1			to	subs-hosp.  
  
    if ws-hosp-nbr-1   is not numeric  
    then  
        if ws-hosp-nbr-1   = hosp-code (subs-hosp)  
        then  
            move ws-hosp-nbr-1          to clmhdr-hosp  
	    move hosp-nbr (subs-hosp)  	to ws-hosp-nbr  
	    go to jb0-99-exit  
        else  
            next sentence  
*       endif  
    else  
        if ws-hosp-nbr     = hosp-nbr (subs-hosp)  
        then  
	    move hosp-code (subs-hosp)  to clmhdr-hosp  
	    go to jb0-99-exit.  
*       endif  
*   endif  
  
*   if subs-hosp < 33  
    if subs-hosp < 35  
    then  
	go to jb11-10-hosp-loop  
    else  
	move "N"   		to	flag.  
*   endif  
  
jb0-99-exit.  
    exit.  
  
jc0-rewrite-detail.  
  
    move hold-claim-detail-rec (i)  to claim-detail-rec.  
    move hold-feedback-clmdtl (i)   to feedback-claims-mstr.  
    move hold-occurs-clmdtl (i)     to claims-occur.  

* 2012/04/17 - MC5 - transfer to below after read statement
*    move hold-clm-svc-date (i)      to clmdtl-sv-date.  
*    move hold-diag-cd (i)           to clmdtl-diag-cd.  

*   (1999/jul/09 B.E. -  repetitive services written back to database)
*    move hold-clm-svcs-day(i,1)     to clmdtl-sv-day(1).
*    move hold-clm-svcs-svc(i,1)     to clmdtl-sv-nbr(1).
*    move hold-clm-svcs-day(i,2)     to clmdtl-sv-day(2).
*    move hold-clm-svcs-svc(i,2)     to clmdtl-sv-nbr(2).
*    move hold-clm-svcs-day(i,3)     to clmdtl-sv-day(3).
*    move hold-clm-svcs-svc(i,3)     to clmdtl-sv-nbr(3).
* 2012/04/17 - end

*mf move clmdtl-id                  to key-clm-data.  
*mf move "B"                        to key-clm-key-type.  
 
* 2012/04/17 - MC5 - move hold-key-claim-mstr from below 
    move hold-key-claims-mstr       to key-claims-mstr.
    move clmdtl-id                  to clmdtl-b-data.  
    move "B"                        to clmdtl-b-key-type.  
*   move hold-key-claims-mstr        to key-claims-mstr.
* 2012/04/17 - end


*    move k-clmdtl-b-key-type to clmdtl-b-key-type.
*     move k-clmdtl-b-data to clmdtl-b-data.
*display clmdtl-b-data.
*stop  " ".
    read claims-mstr   
           key is key-claims-mstr
          invalid key  
                move 2              to  err-ind  
                perform za0-common-error   thru  za0-99-exit  
                go to az0-end-of-job.  

*display key-claims-mstr.
*stop " ".

* 2012/04/17 - MC5 - transfer from above
    move hold-clm-svc-date (i)      to clmdtl-sv-date.  
    move hold-diag-cd (i)           to clmdtl-diag-cd.  
    move hold-clm-svcs-day(i,1)     to clmdtl-sv-day(1).
    move hold-clm-svcs-svc(i,1)     to clmdtl-sv-nbr(1).
    move hold-clm-svcs-day(i,2)     to clmdtl-sv-day(2).
    move hold-clm-svcs-svc(i,2)     to clmdtl-sv-nbr(2).
    move hold-clm-svcs-day(i,3)     to clmdtl-sv-day(3).
    move hold-clm-svcs-svc(i,3)     to clmdtl-sv-nbr(3).
* 2012/04/17 - end

     rewrite claims-mstr-rec  from claim-detail-rec  
*mf      key is  key-claims-mstr  
               invalid key  
               move 25               to err-ind  
               perform    za0-common-error    thru za0-99-exit  
               go to   az0-end-of-job.  
  
jc0-99-exit.  
    exit.  


ka0-select-patient.  
  
*	(this routine accesses the patient master and displays all  
*	 patients with acronyms matching the one input -- the operator then  
*	 selects one patient and the pat's subscr is displayed -- the selected patient"s  
*	 ohip or chart number is placed in the variable "KEY-CLM-DATA-R"  
*	 and a "P" in "key-clm-key-type" so that the claims master can  
*	 be accessed by using the "P" key)  
  
  
    perform ka8-clear-pat-tbl		thru ka8-99-exit  
		varying		subs  
		from		1  
		by		1  
		until	subs	>	ws-max-nbr-pat + 1.  
  
    move zeroes				to ws-pat-ohip.  
    move spaces				to ws-pat-acronym-i  
					   ws-tbl-values.  
    move 0   				to ss-pat.  
  
    if flag-claim-access-type = "O"  
    then  
*	move "O"			to pat-key-type  
*	move acpt-ohip-nbr          	to key-pat-mstr  
	move acpt-ohip-nbr		to ws-pat-ohip  
    else  
*       move "A"			to pat-key-type  
*       move acpt-acronym 		to key-pat-mstr  
        move acpt-acronym   		to ws-pat-acronym-i.  
*   endif  
  
    move "Y"				to flag  
					   flag-pat.  
  
    perform ka1-read-first-pat		thru ka1-99-exit.  
  
    if flag-pat-not-ok  
    then  
 	go to ka0-99-exit
    else
	move 1 				to ctr-nbr-matching-pats-found.
*   endif  
  
ka0-10-read-up-to-max-pat.  
  
    move "Y"				to flag  
					   flag-pat.  
*   (this routine counts the matching patients in 'ctr-nbr-matching-pats-found')
    perform ka3-read-up-to-next-max-pats thru ka3-99-exit  
		varying	 subs 
		from	 2       
		by	 1    
		   until   subs > ws-max-nbr-pat + 1  
		        or flag-pat-not-ok.       

*   (if only 1 matching patient found, go right to the display of that patient)
    if ctr-nbr-matching-pats-found = 1
    then
	move 1 				to ws-sel-nbr
	go to ka0-50-display-selected-pat.
*   (else)
*   endif

*   (more than 1 patient matches selection criteria - allow user to 
*    select which patient that they want)
    move "Y"				to flag-pat.  
    display scr-sel-pat-title.  
    perform ka5-display-patients	thru ka5-99-exit  
	varying i from 1 by 1  
	until i > ws-max-nbr-pat.  
  
ka0-20-check-pat.  
  
    if ss-pat > ws-max-nbr-pat  
    then  
	move '*'			to flag  
	display scr-acpt-roll-pat-found  
	accept  scr-acpt-pat-found-flag  
	if   flag = "*"  
	  or flag = "^"  
	then  
	    perform ka8-clear-pat-tbl	thru ka8-99-exit  
		varying subs  
		from	1   
		by	1  
		until	subs	>	ws-max-nbr-pat  
  
	    perform ka9-move-last-element-to-first  
					thru ka9-99-exit  
  
	    add 1	, ws-max-nbr-pat  
					giving subs  
  
*	    ( clear overflow element after moved to first pos. )  
	    perform ka8-clear-pat-tbl	thru ka8-99-exit  
  
	    move 1			to ss-pat  
  
	    go to ka0-10-read-up-to-max-pat  
	else  
	    next sentence  
*	endif  
    else  
	display scr-clr-pat-roll  
	display scr-acpt-pat-found  
	accept  scr-acpt-pat-found.  
*   endif  
  
    if ok  
    then  
	next sentence  
    else  
	if not-ok  
	then  
	    go to ka0-99-exit  
	else  
	    move 1			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to ka0-20-check-pat.  
*	endif  
*   endif  
  
    move "N"				to flag.  
  
    perform ka7-accept-nbr		thru ka7-99-exit  
	until	ok.  

ka0-50-display-selected-pat.

    move hold-key-pat-mstr (ws-sel-nbr)	to key-pat-mstr of pat-mstr.  
  
    perform xf5-access-patient		thru xf5-99-exit.  
  
    if flag-pat-not-ok  
    then   
	move 14				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to az0-end-of-job.  
*   (else)  
*   endif  
  
*mf move "P"				to key-clm-key-type.  
    move "P"				to clmdtl-b-key-type.  
*mf move hold-key-pat-mstr (ws-sel-nbr)	to key-claims-mstr.  
    move hold-key-pat-mstr (ws-sel-nbr)	to clmdtl-p-claims-mstr. 
  
ka0-99-exit.  
    exit.  
ka1-read-first-pat.  
  
    if flag-claim-access-type = "O"  
    then  
	perform xf1-access-patient-approx-od  
					thru xf1-99-exit  
    else  
*mf     move acpt-acronym                to acr-pat-acronym  
        move acpt-acronym                to pat-acronym  
        perform xf3-access-patient-acr  thru xf3-99-exit.  
*   endif  
  
    if flag-pat-ok  
    then  
	perform xj0-move-pat-data-to-tbl  
					thru xj0-99-exit  
    else  
	move 7				to err-ind  
	perform za0-common-error	thru za0-99-exit.  
*   endif  
  
ka1-99-exit.  
    exit.  


ka3-read-up-to-next-max-pats.  
 
    move spaces                         to ws-pat-mstr-rec.  
    if flag-claim-access-type = "O"  
    then  
        move "OD"                       to ws-pat-read-ind  
        read pat-mstr 
	  next into ws-pat-mstr-rec  
	  at end  
	    move "N"			to flag-pat  
	    go to ka3-99-exit.  
  
    if flag-claim-access-type = "A"  
    then  
        move "AC"                       to ws-pat-read-ind  
        read pat-mstr next into ws-pat-mstr-rec  
	  at end  
	    move "N"			to flag-pat  
	    go to ka3-99-exit.  
  
    if flag-claim-access-type = "O"  
    then  
	perform xj0-move-pat-data-to-tbl thru xj0-99-exit  
    else  
        if   ws-pat-acronym = ws-pat-acronym-i  
        then  
	    perform xj0-move-pat-data-to-tbl thru xj0-99-exit  
        else  
	    move "N"			to flag-pat
	    go to ka3-99-exit.  
*       endif  
*   endif  

    add 1				to ctr-read-pat-mstr.  
*   (count number of patients matching search criteria)
    add 1				to ctr-nbr-matching-pats-found.
  
ka3-99-exit.  
    exit.  
  
ka5-display-patients.  
  
    subtract 1			from	i  
				giving	temp1.  
  
    if ss-pat > temp1  
    then  
	add	i  
		2		giving	temp  
	move	temp		to	pline1  
	display scr-sel-pat-mask.  
*   (else)  
*   endif  
  
ka5-99-exit.  
    exit.  
ka7-accept-nbr.  
  
    move zero				to ws-sel-nbr.  
    display scr-select-nbr.  
    accept scr-select-nbr.  
  
    if ws-sel-nbr = 0  
    then  
	move 13				to err-ind  
    else  
	if   ws-sel-nbr > ss-pat  
	  or ws-sel-nbr > ws-max-nbr-pat  
	then  
	    move 5			to err-ind  
	else  
	    move "Y"			to flag  
	    go to ka7-99-exit.  
*	endif  
*   endif  
  
    perform za0-common-error		thru za0-99-exit.  
    move 0				to ws-sel-nbr.  
    display scr-select-nbr.                     
  
ka7-99-exit.  
    exit.  
ka8-clear-pat-tbl.  
  
    move spaces				to hold-given-name(subs)  
					   hold-surname(subs)  
*mf					   hold-birth-date(subs)  
					   hold-pat-id(subs)      
*2000/02/24 - MC
					   hold-key-pat-mstr(subs).  
  
    move zero				to hold-pat-occ(subs)  
					   hold-birth-date(subs)  .
*2000/02/24 - MC
* 					   hold-key-pat-mstr(subs).  
  
ka8-99-exit.  
    exit.  
ka9-move-last-element-to-first.  
  
    move 1				to hold-pat-occ(1).  
    move hold-given-name(21)		to HOLD-given-name(1).  
    move hold-surname(21)		to hold-surname(1).  
    move hold-birth-date(21)		to hold-birth-date(1).  
    move hold-pat-id(21)		to hold-pat-id(1).  
    move hold-key-pat-mstr(21)		to hold-key-pat-mstr(1).  
  
ka9-99-exit.  
    exit.  
 

la0-preset-card-status.

    move "C"			 	to clmhdr-status-ohip.
    move 2				to warn-ind.
    perform zd0-common-warning		thru	zd0-99-exit.

la0-99-exit.
    exit.

 
ma0-display-selected-pat.  
  
    display scr-disp-column-titles.  
  
    display scr-pat-lit.  
    display scr-subscr-lit.  
  
    display scr-acpt-mask1.  
  
    display scr-acpt-mask2.  
  
ma0-99-exit.  
    exit.  

na0-call-elig-history-disp-pgm.

*   (write claim number to parameter file for passing to d003_1.qks)
*    move ws-clmhdr-batch-nbr		to parameter-batch-nbr.
*    move clmhdr-claim-nbr		to parameter-claim-nbr.
    open output   parameter-file.
    move clmhdr-pat-key-type		to parameter-pat-key-type.
    move clmhdr-pat-key-data		to parameter-pat-key-data.
    write parameter-rec.
    close   parameter-file.

    display load-message.
    move "quick term=vt220 auto=$pb_obj/d003_1.qkc debug=source" to macro.
    call  "SYSTEM" using macro.

na0-99-exit.
    exit.


* 2002/11/13 - MC
na1-call-costing-disp-pgm.

*   (write claim number to parameter file for passing to m088_1.qks)
    open output   parameter-file.
    move spaces             		to parameter-pat-key-data.
    move clmhdr-batch-nbr		to parameter-batch-nbr.
    move clmhdr-claim-nbr		to parameter-claim-nbr.
    move "C"                	 	to parameter-type.
    write parameter-rec.
    close   parameter-file.

    display load-message.
    move "quick term=vt220 auto=$pb_obj/m088_1.qkc debug=source" to macro.
    call  "SYSTEM" using macro.

na1-99-exit.
    exit.

* 2002/11/13 - end
pa0-display-brief-screen.  
  
    display scr-claim-lit.  
  
    perform pa9-clear-ws-tbl		thru pa9-99-exit  
	varying subs from 1 by 1  
	until   subs > ws-max-nbr-claims-per-screen + 1.  
  
    move 'Y'				to flag-found-claim.  
  
*	( read 'P' key hdr )  
*mf
    move "P"				to   ws-clm-read-ind.
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
    if not-ok  
    then  
	move 'N'			to flag-found-claim  
	go to pa0-99-exit.  
*   (else)  
*   endif  
  
    if ws-key-pat-mstr = clmhdr-pat-ohip-id-or-chart of claim-header-rec  
    then  
	next sentence  
    else  
	move 'N'			to flag-found-claim  
	go to pa0-99-exit.  
*   endif  
  
*mf move clmhdr-claim-id		to key-clm-data.  
    move clmhdr-claim-id		to clmdtl-b-data.  
  
    move zero				to ws-hold-clmhdr-claim-id  
					   subs  
					   ws-nbr-claims-read.  
  
*mf move "B"				to key-clm-key-type.  
    move "B"				to clmdtl-b-key-type.  
  
*	( read 'B' key hdr )  
*mf
    move "B"				to   ws-clm-read-ind.
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
  
    if flag-agent-on and  
        clmhdr-agent-cd not = sel-agent-code  
    then  
	next sentence  
    else  
        move clmhdr-claim-id		to ws-hold-clmhdr-claim-id  
        move 1				to ws-nbr-claims-read  
        move 1				to subs  
        perform pa1-move-clmhdr-to-brief-tbl  
					thru pa1-99-exit  
        move 1				to ws-dtl-ctr  
        perform pa4-process-dtls	thru pa4-99-exit.  
*   endif  
  
pa0-10-read-next-claims.  
  
    move "Y"				to flag.  
    perform pa3-read-clm-move-to-tbl	thru pa3-99-exit  
	until   subs =   ws-max-nbr-claims-per-screen  
	              or not-ok  
  
    if ws-nbr-claims-read = zero  
    then  
	move 26 			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to pa0-99-exit.  
*   endif  
  
    if ws-nbr-claims-read = 1  
    then  
*mf	move ws-hold-clmhdr-claim-id	to key-clm-data  
*mf	move "B"			to key-clm-key-type  
	move ws-hold-clmhdr-claim-id	to clmdtl-b-data  
	move "B"			to clmdtl-b-key-type  
	display scr-blank-line-3  
	perform ea0-read-display-a-claim  
 					thru ea0-99-exit  
	go to pa0-99-exit.  
*   (else)  
*   endif  
  
pa0-20-display-claims.  
  
    perform pa7-display-claims		thru pa7-99-exit.  
    if ws-selected-claim = 'S'  
    then  
	go to pa0-99-exit  
    else  
	if ws-selected-claim = 'R'  
	then  
	    move ws-total-nbr-brief-claims(9)	to ws-total-nbr-brief-claims(1)  
 	    perform pa9-clear-ws-tbl	thru pa9-99-exit  
		varying subs from 2 by 1  
		until   subs > ws-max-nbr-claims-per-screen + 1  
	    move 1			to ws-nbr-claims-read  
	                                   subs  
	    move clmhdr-claim-id	to ws-hold-clmhdr-claim-id  
	    display blank-screen  
	    perform xn0-disp-title-brief-norm  
					thru xn0-99-exit  
	    display scr-claim-lit  
	    go to pa0-10-read-next-claims  
	else  
	    display blank-screen  
	    perform xn0-disp-title-brief-norm  
					thru xn0-99-exit  
	    display scr-claim-lit  
 	    go to pa0-20-display-claims.  
*	endif  
*    endif  
  
pa0-99-exit.  
    exit.  
  
  
  
pa1-move-clmhdr-to-brief-tbl.  
  
    move clmhdr-agent-cd		to ws-tbl-agent		(subs).  
    move clmhdr-clinic-nbr-1-2		to ws-tbl-claim-clinic	(subs).  
    move clmhdr-doc-nbr			to ws-tbl-claim-doc-nbr	(subs).  
    move clmhdr-batch-nbr-7-9		to ws-tbl-claim-batch	(subs).  
    move clmhdr-claim-nbr		to ws-tbl-claim-claim-nbr (subs).  
    move spaces 			to ws-tbl-re-cap 	(subs).  
    move clmhdr-date-period-end		to ws-tbl-ped		(subs).  
  
    perform pa11-access-doc		thru pa11-99-exit.  
  
    move doc-name			to ws-tbl-doc-name	(subs).  
    move clmhdr-tot-claim-ar-ohip	to ws-tbl-orig-amt	(subs).  
  
    perform xm0-calc-claim-bal		thru xm0-99-exit.  
  
    move ws-clmhdr-manual-tape-paymnts	to ws-tbl-payments	(subs).  
    move hold-clmhdr-bal		to ws-tbl-bal-due	(subs).  
  
pa1-99-exit.  
   exit.  
  
  
  
pa11-access-doc.  
  
    move clmhdr-doc-nbr			to doc-nbr of doc-mstr-rec.  
  
    read doc-mstr  
	invalid key  
	    move 'UNKNOWN Doctor'	to doc-name.  
  
pa11-99-exit.  
    exit.  
  
  
  
pa2-move-dtl-to-brief-tbl.  
  
    if ws-dtl-ctr = 1  
    then  
	move clmdtl-sv-date		to ws-tbl-dtl1-svc-date	(subs)  
	move clmdtl-oma-cd		to ws-tbl-dtl1-oma-cd	(subs)  
	move clmdtl-oma-suff		to ws-tbl-dtl1-oma-suff	(subs)  
    else  
	move clmdtl-sv-dd		to ws-tbl-dtl-dd	(subs,ws-dtl-ctr - 1 )    
	move clmdtl-oma-cd		to ws-tbl-dtl-oma-cd	(subs,ws-dtl-ctr - 1 )  
	move clmdtl-oma-suff		to ws-tbl-dtl-oma-suff	(subs,ws-dtl-ctr - 1 ).  
*   endif  
  
pa2-99-exit.  
    exit.  
pa3-read-clm-move-to-tbl.  
  
    perform ia7-get-next-claim-by-patient  
					thru ia7-99-exit.  
  
*   ( if there aren't anymore claims then exit and display only the  
*     1 claim found. )  
    if not-ok  
    then  
	go to pa3-99-exit.  
*   (else)  
*   endif  
  
*   ( read the claim header by 'b' key )  
*mf
    move "B"				to    ws-clm-read-ind.
    perform xc0-read-claims-mstr	thru xc0-99-exit.  
    if not-ok  
    then  
	go to pa3-99-exit.  
*   (else)  
*   endif  
  
  
*   (the following if-statement is commented and replaced by the  
*    following line on 85/12/18 by m.s. - pdr 281)  
  
    if ws-key-pat-mstr = clmhdr-pat-ohip-id-or-chart of claim-header-rec  
    then  
	next sentence  
    else  
	move 'N'			to flag  
	go to pa3-99-exit.  
*   endif  
  
    if flag-agent-on and  
        clmhdr-agent-cd not = sel-agent-code  
    then  
	next sentence  
    else  
        add 1					to subs  
          			           	   ws-nbr-claims-read  
        perform pa1-move-clmhdr-to-brief-tbl 	thru pa1-99-exit  
        move 1					to ws-dtl-ctr  
        perform pa4-process-dtls		thru pa4-99-exit  
        if ws-hold-clmhdr-claim-id = zero  
	then  
	    move clmhdr-claim-id 		to ws-hold-clmhdr-claim-id.  
*   endif  
  
pa3-99-exit.  
    exit.  
  
  
  
pa4-process-dtls.  
  
    move 'Y'				to flag.  
    perform xd4-read-nxt-dtl		thru xd4-99-exit.  
  
    if   (      (    clmdtl-batch-nbr	= clmhdr-batch-nbr  
                  and clmdtl-claim-nbr	= clmhdr-claim-nbr)  
             or (   clmdtl-batch-nbr	= clmhdr-orig-batch-nbr  
                  and clmdtl-claim-nbr	= clmhdr-orig-claim-nbr)    )     
      and clmdtl-oma-cd not 	= "0000"  
      and clmdtl-oma-cd not 	= "ZZZZ"  
      and ok  
* sms 126 allow for 8 claim details instead of 6. s.f.  
      and ws-dtl-ctr not > 9  
    then  
* sms 126 allow for 8 claim details instead of 6. s.f.  
	if ws-dtl-ctr = 9  
	then  
	    move '*'			to ws-tbl-dtl-star (subs)  
	else  
	    perform pa2-move-dtl-to-brief-tbl  
					thru pa2-99-exit  
	    add 1			to ws-dtl-ctr  
	    go to pa4-process-dtls.  
*	endif  
*   (else)  
*   endif  
  
pa4-99-exit.  
   exit.  
  
pa7-display-claims.  
  
    perform pa71-disp-clm	thru	pa71-99-exit  
				varying	i  
				from	1  
				by	1  
				until	i not < ws-max-nbr-claims-per-screen.  
  
pa7-10-acpt-claim-nbr.  
  
    move spaces				to ws-selected-claim.  
  
    if ws-tbl-claim-batch-nbr(9) not = zero  
    then  
	display scr-select-nbr-roll  
	accept  scr-select-nbr-roll  
	if ws-selected-claim =    'R'  
			       or 'S'  
	then  
	    go to pa7-99-exit  
	else  
	    next sentence  
*	endif  
    else  
	display scr-select-claim-nbr  
	accept  scr-select-claim-nbr  
	if   ws-selected-claim = 'S'  
	then  
	    go to pa7-99-exit  
	else  
	    if ws-selected-claim = 'R'  
	    then  
		move 8			to err-ind  
		perform za0-common-error  
					thru za0-99-exit  
		go to pa7-10-acpt-claim-nbr  
	    else  
		next sentence.  
*	    endif  
*	endif  
*   endif  
  
    if ws-selected-claim not numeric  
    then  
	move 1				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to pa7-10-acpt-claim-nbr  
    else  
	move ws-selected-claim		to ws-select-brief-claim.  
*   endif  
  
    if    ws-select-brief-claim		> zero  
      and ws-select-brief-claim     not > ws-nbr-claims-read  
    then  
	next sentence  
    else  
	move 1				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to pa7-10-acpt-claim-nbr.  
*   endif  
  
    move zero				to key-claims-mstr.  
  
    move ws-tbl-claim-clinic		( ws-select-brief-claim )  
*mf					to key-clm-clinic-nbr-1-2.  
					to clmdtl-b-clinic-nbr-1-2.  
    move ws-tbl-claim-doc-nbr		( ws-select-brief-claim )  
*mf					to key-clm-doc-nbr.  
					to clmdtl-b-doc-nbr.  
    move ws-tbl-claim-batch		( ws-select-brief-claim )  
*mf					to key-clm-batch-number.  
					to clmdtl-b-batch-number.  
    move ws-tbl-claim-claim-nbr		( ws-select-brief-claim )  
*mf					to key-clm-claim-nbr.  
					to clmdtl-b-claim-nbr.  
*mf move "B"				to key-clm-key-type.  
    move "B"				to clmdtl-b-key-type.  
  
    display blank-screen.  
    perform xn0-disp-title-brief-norm	thru xn0-99-exit.  
    perform ea0-read-display-a-claim	thru ea0-99-exit.  
  
pa7-99-exit.  
    exit.  
  
  
  
pa71-disp-clm.  
  
    multiply i			by	2  
				giving	temp.  
    add 3			to	temp.  
    move temp			to	pline1.  
    add 1  
	pline1			giving	pline2.  
  
  
    if ws-tbl-claim-batch-nbr(i) not = zero  
    then  
	move tbl-elements-nbr(i) to	ws-prtnbr  
	display scr-claim-var  
    else  
	display scr-blank-lines.  
*   endif  
  
pa71-99-exit.  
    exit.  
  
pa9-clear-ws-tbl.  
  
    move zero				to ws-tbl-agent			(subs)  
					   ws-tbl-claim-batch-nbr	(subs)  
					   ws-tbl-re-cap		(subs)  
					   ws-tbl-ped			(subs)  
					   ws-tbl-payments		(subs)  
					   ws-tbl-orig-amt		(subs)  
					   ws-tbl-bal-due		(subs)  
					   ws-tbl-dtl1-svc-date		(subs)  
					   ws-tbl-dtl-dd		(subs,1)  
					   ws-tbl-dtl-dd		(subs,2)  
					   ws-tbl-dtl-dd		(subs,3)  
					   ws-tbl-dtl-dd		(subs,4)  
					   ws-tbl-dtl-dd		(subs,5)  
*  subscript 6 & 7 are added by m.c. on 90/06/26.  
					   ws-tbl-dtl-dd		(subs,6)  
					   ws-tbl-dtl-dd		(subs,7).  
  
  
    move spaces				to ws-tbl-doc-name		(subs)  
					   ws-tbl-dtl1-oma-cd		(subs)  
					   ws-tbl-dtl1-oma-suff		(subs)  
					   ws-tbl-dtl-oma-cd		(subs,1)  
					   ws-tbl-dtl-oma-suff		(subs,1)  
					   ws-tbl-dtl-oma-cd		(subs,2)  
					   ws-tbl-dtl-oma-suff		(subs,2)  
					   ws-tbl-dtl-oma-cd		(subs,3)  
					   ws-tbl-dtl-oma-suff		(subs,3)  
					   ws-tbl-dtl-oma-cd		(subs,4)  
					   ws-tbl-dtl-oma-suff		(subs,4)  
					   ws-tbl-dtl-oma-cd		(subs,5)  
					   ws-tbl-dtl-oma-suff		(subs,5)  
*  subscript 6 & 7 are added by m.c. on 90/06/26.  
					   ws-tbl-dtl-oma-cd		(subs,6)  
					   ws-tbl-dtl-oma-suff		(subs,6)  
					   ws-tbl-dtl-oma-cd		(subs,7)  
					   ws-tbl-dtl-oma-suff		(subs,7)  
					   ws-tbl-dtl-star		(subs).  
  
pa9-99-exit.  
    exit.  


xc0-read-claims-mstr.  
  
    move zero 				to feedback-claims-mstr.  
    move zero 				to claims-occur.  

*mf (read key depending upon flag)  
    if ws-clm-read-ind = "B"
    then
        read claims-mstr  into claim-header-rec
         key is key-claims-mstr  
	    invalid key  
		    move "N"		to   flag  
		    go to xc0-99-exit
    else
*mf     (ws-clm-read-ind = "P")
*mf
	move "P"	  		to   clmdtl-p-key-type
					of   clmdtl-p-claims-mstr
        read claims-mstr  into claim-header-rec
         key is clmdtl-p-claims-mstr
	    invalid key 
		    move "N"		to flag  
		    go to xc0-99-exit.
*   endif
  
    move feedback-claims-mstr		to hold-feedback-clmhdr.  
    move claims-occur			to hold-claims-occur.  
    move clmhdr-agent-cd		to hold-clmhdr-agent-cd.  
*mf brad save key based upon flag??
    move key-claims-mstr		to hold-key-claims-mstr.  
    move "Y"				to flag.  
    add  1				to ctr-read-claims-mstr.  
  
*mf move key-clm-batch-num		to clmhdr-rma-batch-nbr.  
*mf move key-clm-claim-nbr		to clmhdr-rma-claim-nbr.  
    move clmdtl-b-batch-num		to clmhdr-rma-batch-nbr.  
    move clmdtl-b-claim-nbr		to clmhdr-rma-claim-nbr.  
    move zero 				to feedback-claims-extra.  
  
    read claims-extra-mstr   
*mf	key is clmhdr-rma-clm-nbr  
	invalid key  
	    move spaces                 to hold-ohip-clm-nbr  
	    go to xc0-99-exit.  
  
    move clmhdr-ohip-clm-nbr		to hold-ohip-clm-nbr.  
  
xc0-99-exit.  
    exit.  
xc1-read-claims-mstr-suppress.  
  
    read claims-mstr next
*mf	suppress data record  
*mf	invalid key   
	at end
	    move "N"			to flag  
	    go to xc1-99-exit.  
    move "Y"				to flag.  
    add 1				to ctr-read-claims-mstr.  
  
xc1-99-exit.  
    exit.  
xc2-read-claims-mstr-next.  
  
    read claims-mstr next into claim-header-rec   
*mf	invalid key  
	at end
	    move "N"			to flag  
	    go to xc2-99-exit.  
  
*mf retrieve claims-mstr key fix position  
*mf	into key-claims-mstr.  
  
    move feedback-claims-mstr		to hold-feedback-clmhdr.  
    move claims-occur        		to hold-claims-occur.  
    move key-claims-mstr		to hold-key-claims-mstr.  
    move "Y"				to flag.  
    add 1 				to ctr-read-claims-mstr.  
  
xc2-99-exit.  
    exit.  



xd0-display-claim.  
  
    add 1				to ctr-nbr-claims-displayed.  

* 2004/04/26 - MC -comment if condition and call xb0 subroutine instead

*    if clmhdr-hosp not = spaces
*    then
*       perform xd2-move-hosp-nbr       thru xd2-99-exit
*    else
*       move spaces                     to ws-hosp-nbr.
*   endif
*   (read claim's clinic record to determine current PED for that clinic)
    move clmhdr-clinic-nbr-1-2  to iconst-clinic-nbr-1-2.
    read iconst-mstr
        invalid key
                move 42         to err-ind
                perform za0-common-error thru za0-99-exit.

    perform xb0-verify-location         thru xb0-99-exit.
* 2004/04/26 - end
 
  
*   if   pat-ohip-nbr is numeric  
    if   ws-pat-ohip-mmyy-r not = spaces  
    then  
	move ws-pat-ohip-mmyy		to ws-pat-key-data  
    else  
	move ws-pat-chart-nbr		to ws-pat-key-data.  
*   endif  
 
    display scr-dis-clmhdr-lit. 
    display scr-acpt-clmhdr-values.  
  
    if clmhdr-batch-type = 'P' and clmhdr-adj-cd = 'M'  
    then  
	if clmhdr-adj-cd-sub-type-ss = 0  
	then  
	    perform xd10-get-doc-perc thru xd10-99-exit  
	else  
	    perform xd11-get-const-perc thru xd11-99-exit.  
*	endif  
*   endif  
  
*   (pdr #403 - treat agent 4 as direct bill)  
    move clmhdr-agent-cd			to ws-agent-flag.  
    if direct-bill-agent  
    then  
	display scr-acpt-direct-bill-agent  
    else  
  	display scr-acpt-other.  
  
*	(note - payments are stored as negative amounts, therefore  
*		add payments to original amt owing to obtain  
*		balance due (hold-clmhdr-bal)  
  
    perform xm0-calc-claim-bal		thru xm0-99-exit.  
  
    perform xd7-clear-hold-clm-tbl	thru xd7-99-exit  
			varying	subs  
			from	1  
			by	1  
			until	subs > ws-max-nbr-dtls-on-scr + 1.  
  
    display scr-dis-blank-line-12-19.  
  
    perform xd8-clear-desc-tables 	thru xd8-99-exit  
	varying ss-desc from 1 by 1  
	until ss-desc = 6.  
  
    move 0				to ss-clmdtl  
					   ss-desc  
					   ss-clmdtl-oma.  
    perform xd1-read-nxt-dtl-record	thru xd1-99-exit.  
  
    if ok  
    then  
	move 1				to ss-clmdtl  
	perform xd3-display-first-dtl	thru xd3-99-exit  
     else  
 	move 10				to err-ind  
 	perform za0-common-error	thru za0-99-exit  
	go to az0-end-of-job.  
*   endif  
  
xd0-10-read-up-to-max-dtls.  
  
    move "Y"				to flag.  
  
    perform xd1-read-nxt-dtl-record 	thru xd1-99-exit  
		varying		subs  
		from		1     
		by		1  
		until   ss-clmdtl > ws-max-nbr-dtls-on-scr  
		     or not-ok  
		     or ss-desc not < ss-max-nbr-of-desc-rec-allow.  
  
    move "Y"				to flag.  
  
    perform xd5-display-details		thru xd5-99-exit  
		varying		i  
		from		2  
		by		1  
		until		i > ws-max-nbr-dtls-on-scr.  
  
*   (determine the earliest service date/highest valued detail)
    move hold-clm-svc-date(1)       to save-serv-date.
    move hold-oma-cd(1)             to save-oma-cd.
    move hold-oma-suff(1)           to save-oma-suff.
    move hold-clm-amt-due(1)        to save-amt-due.
    move hold-diag-cd(1)            to save-diag-cd.
    move hold-line-no(1)            to save-line-no.
    perform xx1-obtain-claim-dtl-info thru xx1-99-exit  
      	varying i 
	   from 1 
	     by 1 
*	  		until i >    ws-max-nbr-dtls-on-scr  
*			until i >   ctr-nbr-claims-displayed.
	  until i >   ss-clmdtl.
  
*  2012/05/10 - MC6 - do not display earliest serv date based on clmdtl detail records - display the one stored from claim header  
*   move save-serv-date		to clmhdr-serv-date.  
    display scr-acpt-clmhdr-values-l9.
    display scr-dis-desc.  
    display scr-dis-footing.  

*   (00/sep/15 B.E. - ensure valid values entered) 
xd0-15-accept-y-n.
    move "N"			to flag.
    if    acpt-claim-clinic-1 not numeric  
      and not flag-update-done
      and not flag-update-done-alternative
    then  
	display scr-acpt-correct-claim-y-n  
	accept  scr-acpt-correct-claim-y-n  
	if not-ok  
	then  
	    go to xd0-99-exit  
	else  
	    if ok
	    then
	        next sentence  
	    else
*		(incorrect input - loop for re-input)
		go to xd0-15-accept-y-n
*	    endif
*	endif  
    else  
	next sentence.  
*   endif  
  
xd0-20-check-dtl.  
  
    if ss-clmdtl > ws-max-nbr-dtls-on-scr  
    then  
	move "*"			to flag-ref-fld  
	display scr-acpt-roll-update  
	accept scr-acpt-ref-fld  
        if    flag-update-done  
           or flag-update-done-alternative
	then  
* 2002/11/07 - MC - refresh detail line before display the second screen
	    display scr-dis-blank-line-12-19
* 2002/11/07 - end
	    perform xd7-clear-hold-clm-tbl  
					thru xd7-99-exit          
			varying	subs  
			from	1  
			by	1  
			until	subs > ws-max-nbr-dtls-on-scr  
  
	    perform xd9-move-last-element-to-first  
					thru xd9-99-exit  
  
	    add 1	, ws-max-nbr-dtls-on-scr  
					giving subs  
  
*	   ( clear overflow element after moving to first pos. )  
	    perform xd7-clear-hold-clm-tbl  
					thru xd7-99-exit  
	    perform xd3-display-first-dtl  
					thru xd3-99-exit  
  
	    move 1			to ss-clmdtl  
	    go to xd0-10-read-up-to-max-dtls  
	else  
	    next sentence  
*	endif  
    else  
	display scr-clr-clm-roll  
*	move "N"			to flag-ref-fld  
	move "*"			to flag-ref-fld
	perform zc0-obtain-valid-selection thru zc0-99-exit.
*	  display scr-acpt-update  
*	  accept scr-acpt-update.  
*   endif  
  
    if   flag-update-trailer-info  
      or flag-update-done  
      or flag-update-done-alternative
      or flag-update-reference-field  
      or flag-update-header-rec  
      or flag-update-details  
      or flag-update-total-claim  
      or flag-update-patient  
      or flag-process-claim-adjustment  
      or flag-call-elig-history-screen
* 2002/11/12 - MC
      or flag-call-costing-screen
* 2002/11/12 - end
* 2011/02/09 - MC3
      or flag-update-deceased-pat
* 2011/02/09 - end
    then  
	next sentence  
    else  
	move 1				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	move space			to flag-ref-fld  
	go to xd0-20-check-dtl.  
*   endif  
  
xd0-99-exit.  
    exit.  
xd1-read-nxt-dtl-record.  
  
    perform xd4-read-nxt-dtl		thru xd4-99-exit.  
    if not-ok  
    then  
	go to xd1-99-exit.  
*   (else)  
*   endif  
  
*	(check if this record belongs to the claim)  
*	if the detail batch number equals the header batch number  
*		or the header original batch number  
*		then it is to be shown on the screen   
  
    if   (      (    clmdtl-batch-nbr	= clmhdr-batch-nbr  
                  and clmdtl-claim-nbr	= clmhdr-claim-nbr)  
             or (   clmdtl-batch-nbr	= clmhdr-orig-batch-nbr  
                  and clmdtl-claim-nbr	= clmhdr-orig-claim-nbr)    )     
      and (clmdtl-oma-cd not 	= "0000")  
    then  
	move "Y"				to flag  
	perform xh0-move-clmdtl-to-hold-area	thru xh0-99-exit  
    else  
	move "N"				to flag.  
*   endif  
  
xd1-99-exit.  
    exit.  
copy "hospital.dc".  
  
copy "hosp_nbr_code_to_nbr.rtn"  
	replacing ==ca11-move-hosp==	by	==xd2-move-hosp-nbr==  
		  ==ca11-10-hosp-loop==	by	==xd2-10-hosp-loop==  
		  ==ca11-99-exit==	by	==xd2-99-exit==  
		  ==l1-hosp==		by	==ws-hosp-nbr==  
		  ==spaces==		by	==clmhdr-hosp==.  

xd3-display-first-dtl.  
  
    move 12		to	pline1.  
    move 1		to	i.  
  
    if clmdtl-adj-nbr not = 0  
    then  
	display scr-dis-clmdet-adj  
* the following if stmt is added by m.c. on 92/06/19  
        if flag-normal-tech-n  
	then  
	    next sentence  
	else  
	    display scr-dis-clmdet-adj-b  
*  	endif  
    else  
	display scr-dis-clmdet  
	if flag-normal-tech-n  
 	then  
            if hold-clm-svcs-day(1,1) numeric  
	    then  
	        display scr-dis-clmdet-a  
	    else  
	        display scr-dis-clmdet-b   
*	    endif  
	else  
	    display scr-dis-clmdet-c.  
*	endif  
*   endif  
  
xd3-99-exit.  
    exit.  
xd4-read-nxt-dtl.  
  
    read    claims-mstr    next   into claim-detail-rec  
*mf	invalid key  
	at end
	    move "N"				to flag.  
  
*mf retrieve claims-mstr key fix position  
*mf      into key-claims-mstr.  
  
xd4-99-exit.  
    exit.  
  
xd5-display-details.  
  
    add i  
	11			giving	pline1.  
  
*   if hold-clm-oma-cd(i) > spaces  
    if hold-oma-cd(i) > spaces  
    then  
	display scr-dis-clmdet  
	if flag-normal-tech-n  
	then  
	    if hold-clm-svcs-day(i,1) numeric  
	    then  
	        display scr-dis-clmdet-a  
	    else  
	         display scr-dis-clmdet-b  
*           endif  
	else  
	    display scr-dis-clmdet-c  
*	endif  
    else  
	if hold-clmadj-adj-cd(i) > spaces  
	then  
	    display scr-dis-clmdet-adj  
* the following if stmt is added by m.c. on 92/06/19  
            if flag-normal-tech-n  
	    then  
	    	next sentence  
	    else  
	    	display scr-dis-clmdet-adj-b  
*  	    endif  
	else  
	    display scr-blank-line.  
*	endif  
*   endif  
  
xd5-99-exit.  
    exit.  
  
xd7-clear-hold-clm-tbl.  
  
    move 0      	 		to hold-detail(subs)  
               				   hold-detail-adj(subs).  


*   move spaces				to hold-clm-oma-cd(subs)  
*					   hold-clm-oma-suff(subs)  
    move spaces				to hold-oma-cd(subs)  
					   hold-oma-suff(subs)  
					   hold-clm-svcs-day(subs,1)  
					   hold-clm-svcs-day(subs,2)  
					   hold-clm-svcs-day(subs,3)  
					   hold-clm-svcs-svc(subs,1)  
					   hold-clm-svcs-svc(subs,2)  
					   hold-clm-svcs-svc(subs,3)  
					   hold-clmadj-adj-cd(subs).  
  
xd7-99-exit.  
    exit.  
  
  
xd8-clear-desc-tables.  
  
    move spaces 			to hold-descriptions(ss-desc).  
    move spaces				to orig-descriptions(ss-desc).  
  
xd8-99-exit.  
  
    exit.  
  
xd9-move-last-element-to-first.  
  
*   if hold-clm-oma-cd(9) > spaces  
    if hold-oma-cd(9) > spaces  
    then  
	move hold-clm-id(9)		to hold-clm-id(1)  
    else  
	move hold-detail-adj(9)		to hold-detail-adj(1).  
*   endif  
  
xd9-99-exit.  
    exit.  
  
  
xd10-get-doc-perc.  
  
    move clmhdr-doc-nbr			to doc-nbr of doc-mstr-rec.  
  
    read doc-mstr  
	invalid key  
	    move 39			to err-ind  
	    perform za0-common-error	thru za0-99-exit.  
  
*   multiply doc-misc-percent by 100 giving w-percent.  
    move 0 to w-percent.  
    display scr-disp-misc-perc.  
  
xd10-99-exit.  
    exit.  
  
  
xd11-get-const-perc.  
  
    move 3				to const-rec-3-rec-nbr.  
  
    read iconst-mstr  
	invalid key  
	    move 42			to err-ind  
	    perform za0-common-error    thru za0-99-exit.  
  
    multiply const-misc-curr(clmhdr-adj-cd-sub-type-ss) by 100  
				giving w-percent.  
  
    display scr-disp-misc-perc.  
  
xd11-99-exit.  
    exit.  
   
  
  
xe0-rewrite-clmhdr.  
  
    move hold-key-claims-mstr		to key-claims-mstr.  
    move hold-feedback-clmhdr		to feedback-claims-mstr.  
    move hold-claims-occur     		to claims-occur.  
  
    read claims-mstr 
           key is key-claims-mstr
           invalid key  
                move 2              to  err-ind  
                perform za0-common-error   thru  za0-99-exit  
                go to az0-end-of-job.  

    rewrite claims-mstr-rec		from claim-header-rec  
	invalid key  
	    move 25			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  
  
    add 1				 to ctr-rewrite-claims-mstr.
 
    move " " 				to dummy.
 
xe0-99-exit.  
    exit.  
  
  
  
xe1-re-write-patient.  
   
    move ws-pat-mstr-rec                to pat-mstr-rec.  
    rewrite pat-mstr-rec  
 	invalid key  
 	    move 29			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to az0-end-of-job.  
  
xe1-99-exit.  
    exit  
  
xe2-re-write-patient-od.  
  
*mf move ws-pat-mstr-rec                to od-pat-mstr-rec.  
    move ws-pat-mstr-rec                to pat-mstr-rec.  
*mf rewrite od-pat-mstr-rec  
    rewrite pat-mstr-rec  
 	invalid key  
 	    move 29			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to az0-end-of-job.  
  
xe2-99-exit.  
    exit  
  
xe3-re-write-patient-hc.  
  
*mf move ws-pat-mstr-rec                to hc-pat-mstr-rec.  
    move ws-pat-mstr-rec                to pat-mstr-rec.  
*mf rewrite hc-pat-mstr-rec  
    rewrite pat-mstr-rec  
 	invalid key  
 	    move 29			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to az0-end-of-job.  
   
xe3-99-exit.  
    exit  
  
xe4-re-write-patient-acr.  
   
*mf move ws-pat-mstr-rec                to acr-pat-mstr-rec.  
    move ws-pat-mstr-rec                to pat-mstr-rec.  
*mf rewrite acr-pat-mstr-rec  
    rewrite pat-mstr-rec  
 	invalid key  
 	    move 29			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to az0-end-of-job.  
   
xe4-99-exit.  
    exit  
  
xe5-re-write-patient-chrt.  
   
*mf move ws-pat-mstr-rec                to chrt-pat-mstr-rec.  
    move ws-pat-mstr-rec                to pat-mstr-rec.  
*mf rewrite chrt-pat-mstr-rec  
    rewrite pat-mstr-rec  
 	invalid key  
 	    move 29			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to az0-end-of-job.  
   
xe5-99-exit.  
    exit  
xf0-access-patient-od.  
  
    move spaces                         to ws-pat-mstr-rec.  
    move "OD"                           to ws-pat-read-ind.  
*mf read od-pat-mstr  
    read pat-mstr  
*mf added alternative key read
	key is pat-ohip-mmyy
	invalid key  
	    move 'N'			to flag-pat  
	    go to xf0-99-exit.  
    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
*mf move od-pat-mstr-rec                to ws-pat-mstr-rec.  
    move pat-mstr-rec                	to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf0-99-exit.  
    exit.  
  
xf1-access-patient-approx-od.  
  
    move spaces                         to ws-pat-mstr-rec.  
*mf move acpt-ohip-nbr                  to od-pat-ohip-mmyy.  
    move acpt-ohip-nbr                  to pat-ohip-mmyy.  
    move "OD"                           to ws-pat-read-ind.  

*mf read od-pat-mstr  
*mf     key is od-pat-ohip-mmyy 
*mf		  approximate  

    start pat-mstr key is greater than or equal to pat-ohip-mmyy
	invalid key
	    move 'N'			to flag-pat  
	    go to xf1-99-exit.  

    read pat-mstr next 
	at end
	    go to xf1-99-exit.  
    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
*mf move od-pat-mstr-rec                to ws-pat-mstr-rec.  
    move pat-mstr-rec                to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf1-99-exit.  
    exit.  
  
xf2-access-patient-hc.  
  
    move spaces                         to ws-pat-mstr-rec.  
*mf move acpt-health-nbr                to hc-pat-health-nbr.  
    move acpt-health-nbr                to pat-health-nbr of pat-mstr.  
    move "HC"                           to ws-pat-read-ind.  

*mf read hc-pat-mstr  
    read pat-mstr  
*mf added alternative key read
	key is pat-health-nbr of pat-mstr
	invalid key  
	    move 'N'			to flag-pat  
	    go to xf2-99-exit.  
    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
*mf move hc-pat-mstr-rec                to ws-pat-mstr-rec.  
    move pat-mstr-rec                to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf2-99-exit.  
    exit.  
  
xf3-access-patient-acr.  
  
    move spaces                         to ws-pat-mstr-rec.  
    move "AC"                           to ws-pat-read-ind.  

*mf read acr-pat-mstr  
    read pat-mstr  
*mf added alternative key read
	key is pat-acronym
	invalid key  
	    move 'N'			to flag-pat  
	    go to xf3-99-exit.  
    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
*mf move acr-pat-mstr-rec               to ws-pat-mstr-rec.  
    move pat-mstr-rec                   to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf3-99-exit.  
    exit.  
  
xf4-access-patient-chrt.  
  
    move spaces                         to ws-pat-mstr-rec.  
*mf move acpt-direct-id-or-chart        to chrt-pat-chart-nbr.  

* 2002/06/17 - MC - comment out
*    move acpt-direct-id-or-chart        to pat-chart-nbr.  
* 2002/06/17 - end

    move "CH"                           to ws-pat-read-ind.  

*------------------------------------------------------------
* 2006/02/16 - MC
*    access by the proper chart key based on site id

     if site-id = 'HSC'
     then
	 move acpt-direct-id-or-chart        to pat-chart-nbr
         read pat-mstr
        	key is pat-chart-nbr
        	   invalid key
                	move 'N'                    to flag-pat
            		go to xf4-99-exit.
*    endif

     if site-id = 'HSC'
     then
         go to xf4-10.
*    endif

*---------------------------------------------------------------


* 2002/06/17 - MC
    if acpt-d-or-c-alpha1 = 'M'
    then
       move acpt-direct-id-or-chart            to pat-chart-nbr
* 2002/06/17 - end
*mf read chrt-pat-mstr  
    read pat-mstr  
*mf added alternative key read
	key is pat-chart-nbr
	invalid key  
	    move 'N'			to flag-pat  
* 2002/06/17 - MC
***	    go to xf4-99-exit.  
	    go to xf4-99-exit  
* 2002/06/17 - end

* 2002/06/17 - MC
    else
    if acpt-d-or-c-alpha1 = 'K'
    then
       move acpt-direct-id-or-chart            to pat-chart-nbr-2
       read      pat-mstr 
        key is pat-chart-nbr-2
        invalid key
            move "N"                    to flag-pat
            go to xf4-99-exit
     else
    if acpt-d-or-c-alpha1 = 'H'
    then
       move acpt-direct-id-or-chart            to pat-chart-nbr-3
       read      pat-mstr 
        key is pat-chart-nbr-3
        invalid key
            move "N"                    to flag-pat
            go to xf4-99-exit
    else
    if acpt-d-or-c-alpha1 = 'J'
    then
       move acpt-direct-id-or-chart            to pat-chart-nbr-5
       read      pat-mstr 
        key is pat-chart-nbr-5
        invalid key
            move "N"                    to flag-pat
            go to xf4-99-exit
    else
       move acpt-direct-id-or-chart            to pat-chart-nbr-4
       read      pat-mstr 
        key is pat-chart-nbr-4
        invalid key
            move "N"                    to flag-pat
            go to xf4-99-exit.
*   endif
* 2002/06/17 - end

xf4-10.

    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
*mf move chrt-pat-mstr-rec              to ws-pat-mstr-rec.  
    move pat-mstr-rec                   to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf4-99-exit.  
    exit.  
  
xf5-access-patient.  
  
    move spaces                         to ws-pat-mstr-rec.  
    move "IK"                           to ws-pat-read-ind.  

    read pat-mstr record into pat-mstr-rec 
*mf added specification of primary key
	key is key-pat-mstr of pat-mstr
	invalid key  
	    move 'N'			to flag-pat  
	    go to xf5-99-exit.  
    move "Y"				to flag-pat.  
    add 1				to ctr-read-pat-mstr.  
    move pat-mstr-rec                   to ws-pat-mstr-rec.  
  
    perform xx0-convert-phdate-display  thru xx0-99-exit.  
  
xf5-99-exit.  
    exit.  
  
xg0-update-claim.  
    move " " to dummy.
xg0-update-claim-00.  
  
    if flag-update-reference-field  
    then  
* MC12
*       accept scr-reference
        perform ze0-accept-reference-field      thru ze0-99-exit
* MC12 - end
    else  
*   (pdr #403 - treat agent 4 as direct bill)  
        move hold-clmhdr-agent-cd	to ws-agent-flag  
        if direct-bill-agent  
        then  
	    perform xg1-direct-bill-acpt	thru xg1-99-exit  
	    perform xg4-accept-verify-ref-date	thru xg4-99-exit  
	    perform xg5-accept-ref-inits	thru xg5-99-exit  
        else  
	    perform xg1-acpt-desc-1		thru xg1-99-exit  
* MC12
*           accept scr-reference.
            perform ze0-accept-reference-field  thru ze0-99-exit.
* MC12
*	endif  
*   endif  
  
*    if flag-ref-fld not = "M"  
*    then  


    move spaces 			  to   update-confirmation.
    perform zb0-accept-confirm-update thru zb0-99-exit.
*   CASE
    if update-confirmed  
    then  
	go to xg0-50-update-header
    else  
    if update-modify
    then
*	(allow user to modify their changes)
	go to xg0-update-claim-00
    else
*	(ignore changes - return to claim nbr entry)
        move 3                          to warn-ind
        perform zd0-common-warning      thru zd0-99-exit
	go to xg0-99-exit.
*    ENDCASE

*    else  
*        go to xg0-99-exit.  
*   endif
 
xg0-50-update-header. 
    perform xe0-rewrite-clmhdr		thru xe0-99-exit.  

    if ws-pat-read-ind = "IK"  
    then  
       perform xe1-re-write-patient     	thru xe1-99-exit  
    else  
       if ws-pat-read-ind = "OD"  
       then  
          perform xe2-re-write-patient-od  	thru xe2-99-exit  
       else  
          if ws-pat-read-ind = "HC"  
          then  
             perform xe3-re-write-patient-hc    thru xe3-99-exit  
          else  
             if ws-pat-read-ind = "AC"  
             then  
                perform xe4-re-write-patient-acr   thru xe4-99-exit  
             else  
                perform xe5-re-write-patient-chrt  thru xe5-99-exit.  
*            endif
*         endif
*      endif 
*   endif
  
    perform xg2-desc-dtl-update 	thru xg2-99-exit  
    	varying ss-desc from 1 by 1  
	until ss-desc > 5.  
  
xg0-99-exit.  
    exit.  
  
xg1-direct-bill-acpt.  
  
    move ws-subscr-msg-nbr		to hold-sub-msg-nbr.  
  
xg1-acpt-sub-msg-cont.  
  
    accept scr-subscr-msg-nbr.  
  
    if ws-subscr-msg-nbr not = zero  
    then  
    	move msg-indexer		to msg-sub-key-1  
    	move ws-subscr-msg-nbr		to msg-sub-key-23  
        perform xp0-read-msg-sub-mstr	thru xp0-99-exit  
        if msg-sub-missing  
        then  
 	    move 17			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
 	    go to xg1-acpt-sub-msg-cont.  
*	(else)  
*	endif  
*   (else)  
*   endif  
  
xg1-acpt-sub-eff-date.  
 
    accept scr-subscr-date-eff-to-yy.  
*   (y2k - default century of year, if not entered)
    move ws-subscr-dt-msg-no-eff-to-yy  to      century-year.
    perform y2k-add-century-to-year     thru    y2k-99-exit.
    move century-year                   to      ws-subscr-dt-msg-no-eff-to-yy.

    accept scr-subscr-date-eff-to-mm.  
*   (if zero month entered then zero out year that add century added to it)
    if ws-subscr-dt-msg-no-eff-to-mm  = 0
    then
	move 0 to ws-subscr-dt-msg-no-eff-to-yy.
*   endif

    accept scr-subscr-date-eff-to-dd.  

    if    ws-subscr-dt-msg-no-eff-to-r1 is numeric  
*         (y2k)
*     and ws-subscr-dt-msg-no-eff-to-r1 not = "000000"  
      and ws-subscr-dt-msg-no-eff-to-r1 not = zeros
    then  
	if    ws-subscr-dt-msg-no-eff-to-mm     > 00  
				            and < 13  
	  and ws-subscr-dt-msg-no-eff-to-dd     > 00  
					    and < 32  
	then  
	    if    ws-subscr-dt-msg-no-eff-to-mm = 2  
	      and ws-subscr-dt-msg-no-eff-to-dd > 29  
	    then  
 		move 28			to err-ind  
 		perform za0-common-error	thru za0-99-exit  
		go to xg1-acpt-sub-eff-date  
	    else  
		if    (  ws-subscr-dt-msg-no-eff-to-mm  = 4  
						     or = 6  
						     or = 9  
						     or = 11 )  
		  and ws-subscr-dt-msg-no-eff-to-dd > 30  
		then  
 		    move 28			to err-ind  
 		    perform za0-common-error	thru za0-99-exit  
		    go to xg1-acpt-sub-eff-date  
 		else  
		    next sentence  
*		endif  
*	    endif  
	else  
 	    move 27			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
	    go to xg1-acpt-sub-eff-date  
*	endif  
    else  
	if  (   ws-subscr-dt-msg-no-eff-to-r1 = spaces  
* (y2k)
*	      or ws-subscr-dt-msg-no-eff-to-r1 = "000000" )  
	      or ws-subscr-dt-msg-no-eff-to-r1 = zeros    )  
	  and ws-subscr-msg-nbr = "00"  
	then  
	    next sentence  
	else  
	    move 27			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to xg1-acpt-sub-eff-date.  
*	endif  
*   endif  
  
    move clmhdr-msg-nbr			to hold-msg-nbr.  
  
xg1-acpt-msg-cont.  
  
    accept scr-msg-nbr.  
*   if clmhdr-msg-nbr = hold-msg-nbr  
*   then  
*	go to xg1-acpt-reprint.  
*   endif  
  
    if clmhdr-msg-nbr not = zero  
    then  
    	move msg-indexer		to msg-sub-key-1  
    	move clmhdr-msg-nbr		to msg-sub-key-23  
        perform xp0-read-msg-sub-mstr	thru xp0-99-exit  
        if msg-sub-missing  
        then  
	    move 17			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to xg1-acpt-msg-cont  
	else  
	    move clmhdr-reprint-flag	to hold-clmhdr-reprint-flag  
	    move msg-reprint-flag	to clmhdr-reprint-flag   
	    display scr-reprint-flag  
	    if hold-clmhdr-reprint-flag not = msg-reprint-flag  
	    then  
	        display scr-msg-reset.  
*	    (else)  
*	    endif  
*	endif  
*   endif  
  
xg1-acpt-reprint.  
  
    accept scr-reprint-flag.  
  
    if clmhdr-reprint-flag not = "Y" and  
       clmhdr-reprint-flag not = "N"  
    then  
	move 19				to err-ind  
	perform za0-common-error	thru za0-99-exit  
  	go to xg1-acpt-reprint.  
  
xg1-acpt-sub.  
  
    move clmhdr-sub-nbr			to hold-shadow-subdivision.  
  
xg1-acpt-sub-cont.  
  
    accept scr-sub-nbr.  
    if clmhdr-sub-nbr = hold-shadow-subdivision  
    then  
	go to xg1-acpt-auto-logout.  
*   endif  
  
    move sub-indexer 			to msg-sub-key-1.  
    move space				to msg-sub-key-2.  
    move clmhdr-sub-nbr			to msg-sub-key-3.  
    perform xp0-read-msg-sub-mstr	thru xp0-99-exit.  
    if msg-sub-missing  
    then  
	move 18 			to err-ind  
    	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-sub-cont  
    else  
	move sub-auto-logout		to clmhdr-auto-logout  
	move sub-fee-complex		to clmhdr-fee-complex  
	perform xg3-shadow-maintenance	thru xg3-99-exit  
 	display scr-auto-logout scr-fee-complex  
	display scr-sub-reset.  
*   endif  
  
xg1-acpt-auto-logout.  
  
    accept scr-auto-logout.  
  
    if clmhdr-auto-logout not = "Y" and  
       clmhdr-auto-logout not = "N"  
    then  
	move 20				to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-auto-logout.  
  
xg1-acpt-fee.  
  
    accept scr-fee-complex.  
   
    if clmhdr-fee-complex not = "H" and  
       clmhdr-fee-complex not = "L"  
    then  
	move 21				to err-ind  
  	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-fee.  
  
xg1-acpt-desc-1.  
  
    if hold-desc-test1(1) = "+" and  
       hold-desc-test2(1) = "/"  
    then  
       go to xg1-acpt-desc-2.  
  
    accept scr-hold-desc-1.  

* MC12
    move hold-desc(1)                   to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to xg1-acpt-desc-1.
*   endif

* MC12 - end
 
xg1-acpt-desc-2.  
  
    if hold-desc-test1(2) = "+" and  
       hold-desc-test2(2) = "/"  
    then  
       go to xg1-acpt-desc-3.  
  
    accept scr-hold-desc-2.  

    if hold-desc(1) = spaces and  
       hold-desc(2) not = spaces  
    then  
	move 22 			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-desc-1.  

* MC12
    move hold-desc(2)                   to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to xg1-acpt-desc-2.
*   endif

* MC12 - end
  
xg1-acpt-desc-3.  
  
    if hold-desc-test1(3) = "+" and  
       hold-desc-test2(3) = "/"  
    then  
       go to xg1-acpt-desc-4.  
  
    accept scr-hold-desc-3.  
  
    if hold-desc(2) = spaces and  
       hold-desc(3) not = spaces  
    then  
	move 22 			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-desc-2.  

* MC12
    move hold-desc(3)                   to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to xg1-acpt-desc-3.
*   endif

* MC12 - end
  
xg1-acpt-desc-4.  
  
    if hold-desc-test1(4) = "+" and  
       hold-desc-test2(4) = "/"  
    then  
       go to xg1-acpt-desc-5.  
  
    accept scr-hold-desc-4.  
  
    if hold-desc(3) = spaces and  
       hold-desc(4) not = spaces  
    then  
	move 22 			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-desc-3.  

* MC12
    move hold-desc(4)                   to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to xg1-acpt-desc-4.
*   endif

* MC12 - end  

xg1-acpt-desc-5.  
  
    if hold-desc-test1(5) = "+" and  
       hold-desc-test2(5) = "/"  
    then  
       go to xg1-99-exit.  
  
    accept scr-hold-desc-5.  
  
    if hold-desc(4) = spaces and  
       hold-desc(5) not = spaces  
    then  
	move 22 			to err-ind  
	perform za0-common-error	thru za0-99-exit  
	go to xg1-acpt-desc-4.  
 
* MC12
    move hold-desc(5)                   to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to xg1-acpt-desc-5.
*   endif

* MC12 - end 

xg1-99-exit.  
  
    exit.  
xg2-desc-dtl-update.  
  
    if hold-desc(ss-desc) not = orig-desc(ss-desc)  
    then  
	move "Y" to hold-desc-change(ss-desc).  
  
    if hold-desc(ss-desc) not = spaces  
    then  
	move "Y" to hold-desc-after(ss-desc).  
  
    if hold-desc-before(ss-desc) = "Y" and  
       hold-desc-after(ss-desc)  = "Y" and  
       hold-desc-change(ss-desc) = space  
    then  
	next sentence  
    else  
	if hold-desc-before(ss-desc) = "Y" and  
	   hold-desc-after(ss-desc)  = "Y" and  
	   hold-desc-change(ss-desc) = "Y"  
	then  
	    perform xr0-rewrite-clmdtl     	thru xr0-99-exit  
	else  
	    if hold-desc-before(ss-desc) = "Y" and  
	       hold-desc-after(ss-desc)  = space  
	    then  
		perform xs0-delete-clmdtl     	    thru xs0-99-exit  
	    else  
		if hold-desc-before(ss-desc) = space and  
		   hold-desc-after(ss-desc)  = "Y"  
		then  
 		    perform xq0-write-clmdtl		thru xq0-99-exit  
		else  
		    if hold-desc-before(ss-desc) = space and  
		       hold-desc-after(ss-desc)  = space  
		    then  
			move 6 to ss-desc.  
*    (endif)  
  
xg2-99-exit.  
  
    exit.  
  
  
xg3-shadow-maintenance.  
  
    move clmhdr-clinic-nbr-1-2		to hold-shadow-clinic.  
    move clmhdr-pat-ohip-id-or-chart	of claim-header-rec  
					to hold-shadow-patient.  
    move clmhdr-batch-nbr		to hold-shadow-batch-nbr.  
    move clmhdr-claim-nbr		to hold-shadow-claim-nbr.  
  
    move hold-shadow-rec		to clm-shadow-rec.  
  
    perform ya0-delete-claim-shadow	thru ya0-99-exit.  
  
    if claim-shadow-deleted  
    then  
	move clmhdr-sub-nbr		to hold-shadow-subdivision  
	move hold-shadow-rec		to clm-shadow-rec  
	perform ya1-write-claim-shadow	thru ya1-99-exit.  
*   endif  
  
xg3-99-exit.  
    exit.  
  
  
xg4-accept-verify-ref-date.  
  
    display scr-dis-ref.  
*   accept  scr-ref-date. 

    accept  scr-ref-date-yy. 
*   (y2k - default century of year, if not entered)
    if clmhdr-ref-date-yy is numeric
    then
	move clmhdr-ref-date-yy             to      century-year
	perform y2k-add-century-to-year     thru    y2k-99-exit
	move century-year                   to      clmhdr-ref-date-yy.
*   endif
   
    display scr-ref-date-mm. 
    accept  scr-ref-date-mm. 
*   (is month entered is zero, then zero out year which had century added to it)
    if clmhdr-ref-date-mm is numeric  
    then  
        if clmhdr-ref-date-mm  = 0
        then
	   move 0			    to	clmhdr-ref-date-yy.
*       endif
*   endif

    display scr-ref-date-dd. 
    accept  scr-ref-date-dd. 
    if     clmhdr-ref-date-mm is numeric  
       and clmhdr-ref-date-dd is numeric  
    then  
	if    clmhdr-ref-date-mm > 00  
	  and clmhdr-ref-date-mm < 13  
	  and clmhdr-ref-date-dd > 00  
	  and clmhdr-ref-date-dd < 32  
	then  
	    if    clmhdr-ref-date-mm = 2  
	      and clmhdr-ref-date-dd > 29  
	    then  
 		move 28			to err-ind  
 		perform za0-common-error	thru za0-99-exit  
		go to xg4-accept-verify-ref-date  
	    else  
		if    (   clmhdr-ref-date-mm = 4  
		      or  clmhdr-ref-date-mm = 6  
		      or  clmhdr-ref-date-mm = 9  
		      or  clmhdr-ref-date-mm = 11 )  
		  and clmhdr-ref-date-dd > 30  
		then  
 		    move 28			to err-ind  
 		    perform za0-common-error	thru za0-99-exit  
		    go to xg4-accept-verify-ref-date  
 		else  
		    next sentence  
*		endif  
*	    endif  
	else  
 	    move 27			to err-ind  
 	    perform za0-common-error	thru za0-99-exit  
	    go to xg4-accept-verify-ref-date  
*	endif  
    else  
 	move 27			to err-ind  
 	perform za0-common-error	thru za0-99-exit  
	go to xg4-accept-verify-ref-date.  
*   endif  
  
xg4-99-exit.  
    exit.  
  
  
xg5-accept-ref-inits.  
  
    accept scr-ref-inits.  
  
xg5-99-exit.  
    exit.  
xh0-move-clmdtl-to-hold-area.  
  
    if clmdtl-oma-cd = "ZZZZ"  
    then  
*	(description rec)  
*mf   	retrieve claims-mstr key fix position  
*mf	 	into key-claims-mstr  
	add 1				to ss-desc  
	move claim-detail-rec		to hold-desc-rec(ss-desc)  
	move clmdtl-desc		to orig-desc(ss-desc)  
	move "Y"			to hold-desc-before(ss-desc)  
	move feedback-claims-mstr	to hold-desc-feedback-claims(ss-desc)  
	move claims-occur		to hold-desc-claims-occur(ss-desc)  
     else  
	add 1				to ss-clmdtl  
  
	if clmdtl-adj-nbr not = zero  
	then  
*	    ( adjustment detail record )  
	    move clmdtl-adj-cd		to hold-clmadj-adj-cd	 (ss-clmdtl)  
	    move clmdtl-date-period-end	to hold-clmadj-per-end-date  
								 (ss-clmdtl)  
	    move clmdtl-sv-date		to hold-clmadj-svc-date	 (ss-clmdtl)  
	    move clmdtl-cycle-nbr	to hold-clmadj-cyc       (ss-clmdtl)  
	    move clmdtl-orig-batch-nbr-1-2 to hold-clmadj-batch-id-1-2
								 (ss-clmdtl)  
*brad999
	    move clmdtl-orig-batch-nbr-4-9 to hold-clmadj-batch-id-4-9
								 (ss-clmdtl)  
	    move clmdtl-orig-claim-nbr-in-batch  
 					to hold-clmadj-orig-claim-nbr  
								 (ss-clmdtl)  
	    move clmdtl-amt-tech-billed to hold-clmadj-tech-billed
								 (ss-clmdtl)  
*	    subtract   clmdtl-amt-tech-billed 
*		from   clmdtl-fee-oma  
*		giving hold-clmadj-prof-billed (ss-clmdtl)  
  
*   (pdr #403)  
            move clmhdr-agent-cd	to ws-agent-flag  
* 2002/11/07 - MC - use clmdtl-fee-ohip when displaying detail for any agent     
*       if not direct-bill-agent  
*	    then  
		move clmdtl-fee-ohip	to hold-clmadj-due       (ss-clmdtl)  
	        subtract   clmdtl-amt-tech-billed 
		    from   clmdtl-fee-ohip 
		    giving hold-clmadj-prof-billed (ss-clmdtl)  
*	    else  
*		move clmdtl-fee-oma	to hold-clmadj-due       (ss-clmdtl)  
*	        subtract   clmdtl-amt-tech-billed 
*		    from   clmdtl-fee-oma  
*		    giving hold-clmadj-prof-billed (ss-clmdtl)  
* 2002/11/07 - end

*	    endif  
	else  
*	    (claim detail rec)  
*	    move clmdtl-oma-cd		to hold-clm-oma-cd       (ss-clmdtl)  
*	    move clmdtl-oma-suff	to hold-clm-oma-suff     (ss-clmdtl)  
	    move clmdtl-oma-cd		to hold-oma-cd           (ss-clmdtl)  
	    move clmdtl-oma-suff	to hold-oma-suff         (ss-clmdtl)  
	    move clmdtl-date-period-end	to hold-clm-per-end-date (ss-clmdtl)  
	    move clmdtl-sv-date		to hold-clm-svc-date     (ss-clmdtl)  
	    move clmdtl-diag-cd		to hold-diag-cd          (ss-clmdtl)  
	    move clmdtl-line-no		to hold-line-no          (ss-clmdtl)  
	    move clmdtl-nbr-serv	to hold-clm-svc		 (ss-clmdtl)  
	    move clmdtl-amt-tech-billed to hold-clm-tech-billed	 (ss-clmdtl)  
            move feedback-claims-mstr   to hold-feedback-clmdtl  (ss-clmdtl)  
            move claims-occur           to hold-occurs-clmdtl    (ss-clmdtl)  
            move claim-detail-rec       to hold-claim-detail-rec (ss-clmdtl)  
*	        subtract clmdtl-amt-tech-billed from clmdtl-fee-oma  
*			giving hold-clm-prof-billed  (ss-clmdtl)  
	    perform xh1-move-svc-dates	thru xh1-99-exit  
			varying		ss  
			from		1  
			by		1  
			until		ss > 3  
  
*   (pdr #403)  
            move clmhdr-agent-cd	to ws-agent-flag  
* 2002/11/07 - MC - display clmdtl-fee-ohip for any agent
*           if not direct-bill-agent  
*	    then  
		move clmdtl-fee-ohip	to hold-clm-amt-due      (ss-clmdtl)  
	        subtract   clmdtl-amt-tech-billed 
		    from   clmdtl-fee-ohip 
*		    giving hold-clm-prof-billed (ss-clmdtl)  
*	    else  
*		move clmdtl-fee-oma	to hold-clm-amt-due      (ss-clmdtl)
*	        subtract   clmdtl-amt-tech-billed 
*		    from   clmdtl-fee-oma  
		    giving hold-clm-prof-billed (ss-clmdtl).
* 2002/11/07 - end

*	    endif  
  
xh0-99-exit.  
    exit.  
  
xh1-move-svc-dates.  
  
    move clmdtl-sv-day(ss)		to hold-clm-svcs-day(ss-clmdtl,ss).  
    move clmdtl-sv-nbr(ss)		to hold-clm-svcs-svc(ss-clmdtl,ss).  
  
xh1-99-exit.  
    exit.  
xj0-move-pat-data-to-tbl.  
  
    add 1				to ss-pat.  
  
    move ss-pat				to hold-pat-occ(ss-pat).  
    move ws-pat-given-name		to hold-given-name (ss-pat).  
    move ws-pat-surname			to hold-surname (ss-pat).  
    move ws-pat-birth-date		to hold-birth-date (ss-pat).  
    if ws-pat-health-nbr not = 0  
    then  
        move ws-pat-health-nbr          to hold-pat-id (ss-pat)  
    else  
        if ws-pat-ohip-mmyy-r not = spaces  
        then  
	    move ws-pat-ohip-mmyy 	to hold-pat-id (ss-pat)  
        else  
	    move ws-pat-chart-nbr	to hold-pat-id (ss-pat).  
*       endif.  
*   endif  
  
    move ws-key-pat-mstr		to hold-key-pat-mstr (ss-pat).  
  
xj0-99-exit.  
    exit.  
xl0-setup-claim-nbr-disp.  
  
    move clmhdr-clinic-nbr-1-2		to ws-clmhdr-clinic.  
    move clmhdr-doc-nbr			to ws-clmhdr-doc-nbr.  
    move clmhdr-week			to ws-clmhdr-wk.  
    move clmhdr-day			to ws-clmhdr-day.  
  
xl0-99-exit.  
    exit.  
xm0-calc-claim-bal.  
  
    subtract clmhdr-manual-and-tape-paymnts  
					from zero  
					giving ws-clmhdr-manual-tape-paymnts.  
  
*   (pdr #403)  
    move clmhdr-agent-cd			to ws-agent-flag.  

* 2002/11/07 - MC - use ohip amt and paid amt when calculating balance due
*		     for any agent
*    if not direct-bill-agent  
*    then  
	add clmhdr-tot-claim-ar-ohip  
	    clmhdr-manual-and-tape-paymnts  
*					giving hold-clmhdr-bal  
*    else  
*	add clmhdr-tot-claim-ar-oma  
*	    clmhdr-manual-and-tape-paymnts  
					giving hold-clmhdr-bal.  
* 2002/11/07 - end

*   endif  
  
xm0-99-exit.  
    exit.  
xn0-disp-title-brief-norm.  
  
    display scr-title-brief-normal.  
  
*   ( if normal request )  
    if flag-normal-brief-n  
    then  
	display scr-normal  
    else  
	display scr-brief.  
*   endif  
  
*   ( if tech request )  
    if flag-normal-tech-n  
    then  
	display scr-not-tech  
    else  
	display scr-tech.  
*   endif  
  
*   ( if agent request )  
    if flag-agent-on  
    then  
    	display scr-agent  
    else  
	display scr-not-agent.  
*   endif  
  
xn0-99-exit.  
    exit.  
  
xp0-read-msg-sub-mstr.  
  
    read msg-sub-mstr  
	invalid key  
		move "N" 		to flag-msg-sub  
		go to xp0-99-exit.  
  
    move "Y" to flag-msg-sub.  
  
xp0-99-exit.  
  
    exit.  
  
xq0-write-clmdtl.  
  
    move hold-key-claims-mstr		to key-claims-mstr.

*mf move "ZZZZ" 			to key-clm-oma-cd.  
*mf move zero   			to key-clm-oma-suff.  
*mf move zero				to key-clm-adj-nbr.  
*mf move key-clm-data			to hold-desc-id(ss-desc).  
    move "ZZZZ" 			to clmdtl-b-oma-cd.  
*mf move zero   			to clmdtl-b-oma-suff.  
    move ss-desc			to clmdtl-b-oma-suff.  
    move zero				to clmdtl-b-adj-nbr.  
    move clmdtl-b-data			to hold-desc-id(ss-desc).  
  
    move hold-desc-batch-id(ss-desc)	to hold-orig-batch-id(ss-desc).  
  
    move 'Z'				to hold-p-key-type(ss-desc). 
    move clmhdr-pat-key-data		to hold-p-data(ss-desc). 
    move key-claims-mstr       		to hold-b-key(ss-desc).

* y2k   write claims-mstr-dtl-rec	    from hold-desc-rec(ss-desc)  
    move hold-desc-rec(ss-desc)  	to claims-mstr-dtl-rec.
    write claims-mstr-dtl-rec
	invalid key  
	    move 23			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  
  
    add 1				to ctr-write-claims-mstr.  
  
xq0-99-exit.  
    exit.  
  
xr0-rewrite-clmdtl.  
  
*mf move hold-desc-id(ss-desc)		to key-clm-data.  
*mf move "B"				to key-clm-key-type.  
    move hold-desc-id(ss-desc)		to clmdtl-b-data.  
    move "B"				to clmdtl-b-key-type.  

    move hold-desc-feedback-claims(ss-desc) to feedback-claims-mstr.  
    move hold-desc-claims-occur(ss-desc)    to claims-occur.  
    
    read claims-mstr key is key-claims-mstr  
	invalid key  
	    move 2 			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  


    rewrite claims-mstr-dtl-rec		from hold-desc-rec(ss-desc)  
	invalid key  
	    move 25			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  
  
    add 1				to ctr-rewrite-claims-mstr.  
  
xr0-99-exit.  
    exit.  
  
xs0-delete-clmdtl.  
  
*mf move hold-desc-id(ss-desc)		to key-clm-data.  
*mf move "B" 				to key-clm-key-type.  
    move hold-desc-id(ss-desc)		to clmdtl-b-data.  
    move "B" 				to clmdtl-b-key-type.  

    move hold-desc-feedback-claims(ss-desc) to feedback-claims-mstr.  
    move hold-desc-claims-occur(ss-desc)    to claims-occur.  
  
    start claims-mstr key is greater than or equal to key-claims-mstr
	invalid key  
	    move 2 			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  

    read claims-mstr next 
	at end       
	    move 2 			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  

*mf delete claims-mstr record physical  
    delete claims-mstr record  
	invalid key  
	    move 24 			to err-ind  
	    perform za0-common-error	thru za0-99-exit  
	    go to az0-end-of-job.  
  
    add 1				to ctr-delete-claims-mstr.  
  
xs0-99-exit.  
  
    exit.  
  
xx0-convert-phdate-display.  
  
    move spaces 				to pat-id-rec.  
    move ws-pat-surname				to pat-old-surname.  
    move ws-pat-given-name			to pat-old-given-name.  
    move ws-pat-health-nbr			to pat-old-health-nbr.  
    move ws-pat-chart-nbr			to pat-old-chart-nbr.  
    move ws-subscr-addr1			to pat-old-addr1.  
    move ws-subscr-addr2			to pat-old-addr2.  
    move ws-subscr-addr3			to pat-old-addr3.  
 
* 2004/02/25 - MC - include chart-nbr-2 to 5 as well
    move ws-pat-chart-nbr-2                       to pat-old-chart-nbr-2.
    move ws-pat-chart-nbr-3                       to pat-old-chart-nbr-3.
    move ws-pat-chart-nbr-4                       to pat-old-chart-nbr-4.
    move ws-pat-chart-nbr-5                       to pat-old-chart-nbr-5.
* 2004/02/25 - end
 
    move ws-pat-birth-date			to hold-pat-birth-date.  
    move ws-pat-version-cd			to hold-version-cd.  
  
    if ws-pat-last-birth-date not = 0  
    then  
*       (y2k - date now stored in normal 9(8) format)
	move ws-pat-last-birth-date		to hold-last-birth-date.

*	move ws-pat-last-birth-date		to hold-date  
*	if ws-pat-last-birth-date < 0  
*	then  
*	    subtract hold-date from 65536 giving hold-date  
*	end-if  
*	divide hold-date by 512 giving hold-last-birth-yy  
*		  	remainder rem1  
*	divide rem1 by 32 giving hold-last-birth-mm  
*			remainder hold-last-birth-dd.  
*   endif  
  
    if ws-pat-date-last-elig-maint not = 0  
    then  
*       (y2k - date now stored in normal 9(8) format)
	move ws-pat-date-last-elig-maint	to hold-last-elig-maint-date.

*	move ws-pat-date-last-elig-maint	to hold-date  
*	if   ws-pat-date-last-elig-maint < 0  
*	then  
*	    subtract hold-date from 65536 giving hold-date  
*	end-if  
*	divide hold-date by 512 giving hold-last-elig-maint-yy  
*		  	remainder rem1  
*	divide rem1 by 32 giving  hold-last-elig-maint-mm  
*			remainder hold-last-elig-maint-dd.  
*   endif  
  
    if ws-pat-date-last-elig-mailing not = 0  
    then  
*       (y2k - date now stored in normal 9(8) format)
        move ws-pat-date-last-elig-mailing      to hold-last-elig-mail-date.

*	move ws-pat-date-last-elig-mailing	to hold-date  
*	if   ws-pat-date-last-elig-mailing  < 0  
*	then  
*	    subtract hold-date from 65536 giving hold-date  
*	end-if  
*	divide hold-date by 512 giving hold-last-elig-mail-yy  
*		  	remainder rem1  
*	divide rem1 by 32 giving  hold-last-elig-mail-mm  
*			remainder hold-last-elig-mail-dd.  
*   endif  
  
  
xx0-99-exit.  
    exit.  
  
  
  
  
xx1-obtain-claim-dtl-info.
  
*   (determine the earliest service date)
*    if i = 1  
*    then  
*	move hold-clm-svc-date(i) 	to save-serv-date  
*    else  

*   (claim details only)
    if clmhdr-adj-adj-nbr = 0
    then
*	(brad2)
*	if hold-clm-svc-date(i) < save-serv-date  
	if hold-clm-svc-date(i) <> " "  and hold-clm-svc-date(i) <> "00000000"
     	then
	    if hold-clm-svc-date(i) < save-serv-date  
            then  
	        move hold-clm-svc-date(i)	to save-serv-date.  
*           endif  
*       endif  
*   endif  
  
*   (determine the fields of the highest $-valued detail)
*    if i = 1  
*    then  
*	move hold-clm-svc-date(i)   	to save-adj-serv-date  
*	move hold-oma-cd(i)       	to save-oma-cd  
*	move hold-oma-suff(i)		to save-oma-suff  
*	move hold-clm-amt-due(i)	to save-amt-due  
*	move hold-diag-cd(i)		to save-diag-cd  
*	move hold-line-no(i)		to save-line-no  
*    else  
    if clmhdr-adj-adj-nbr = 0
    then
	if hold-clm-amt-due(i) > save-amt-due  
        then  
	    move hold-diag-cd(i)	to save-diag-cd  
	    move hold-line-no(i)	to save-line-no  
	    move hold-clm-amt-due(i) 	to save-amt-due  
	    move hold-clm-svc-date(i)   to save-adj-serv-date  
	    move hold-oma-cd(i)		to save-oma-cd  
	    move hold-oma-suff(i)	to save-oma-suff.  
*       endif  
*   endif  
  
xx1-99-exit.  
    exit.  
  
  
  
  
ya0-delete-claim-shadow.  
  
    move 'Y'				to flag-claim-shadow.  
  
    move zero 				to claims-mstr-shadow-occur.  
    delete claim-shadow-mstr record  
	invalid key  
	    move 'N'			to flag-claim-shadow.  
  
ya0-99-exit.  
  
    exit.  
  
ya1-write-claim-shadow.  
  
    write clm-shadow-rec.  
  
ya1-99-exit.  
    exit.  


*(yy0-process-pat-eligibility-change thru yy0-99-exit)
    copy "process_pat_eligibility_change.rtn".

* 2010/06/22 - MC1
    copy "process_rejected_claims_change.rtn".
* 2010/06/22 - end

za0-common-error.  
  
    move " " 				to 	confirm-space.  
    move err-msg (err-ind)		to	err-msg-comment.  
    display err-msg-line.  
*   display confirm.  
    accept scr-confirm.  
*   stop " ".  
    display blank-line-24.  
  
za0-99-exit.  
    exit.  


zb0-accept-confirm-update.
    display scr-confirm-update.
    accept  scr-confirm-update.

    if   update-confirmed
      or update-rejected
      or update-modify
    then
        next sentence
    else
	move 1 			  to	err-ind  
	perform za0-common-error  thru	za0-99-exit  
        go to zb0-accept-confirm-update.
*   endif

zb0-99-exit.
    exit.

zc0-obtain-valid-selection.
    display scr-acpt-update.
    accept  scr-acpt-update.

*   (display help)
    if  flag-update-help
    then
	perform zc1-display-help	thru zc1-99-exit
		varying i
		from    5
		by      1
	        until i > 15
	go to zc0-obtain-valid-selection
    else
	next sentence.
*   endif

    if   flag-update-trailer-info
      or flag-update-done
      or flag-update-done-alternative
      or flag-update-reference-field
      or flag-update-header-rec
      or flag-update-details
      or flag-update-total-claim
      or flag-update-patient
      or flag-process-claim-adjustment
      or flag-call-elig-history-screen
* 2002/11/12 - MC
      or flag-call-costing-screen
* 2002/11/12 - end
* 2011/02/09 - MC3
      or flag-update-deceased-pat
* 2011/02/09 - end
    then
        next sentence
    else
	move 1 			  to	err-ind  
	perform za0-common-error  thru	za0-99-exit  
        go to zc0-obtain-valid-selection.
*   endif

zc0-99-exit.
    exit.

zc1-display-help.
    move i                    	to    warn-ind.
    perform zd0-common-warning  thru  zd0-99-exit.
zc1-99-exit.
    exit.



zd0-common-warning.  
  
    move " " 				to 	confirm-space.  
    move warn-msg (warn-ind)		to	warn-msg-comment.  
    display warn-msg-line.  
*   display confirm.  
    accept scr-confirm.  
*   stop " ".  
    display scr-dis-footing.
    display blank-line-24.  
  
zd0-99-exit.  
    exit.  



ze0-accept-reference-field.

    accept scr-reference.

* MC12
    move clmhdr-reference               to test-field.
    move 'Y'                            to flag.

    perform zf0-test-field              thru zf0-99-exit
        varying i
        from 1
        by 1
        until i > ss-max-field-check or not-ok.

    if not-ok
    then
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ze0-accept-reference-field.
*   endif

* MC12 - end

ze0-99-exit.
    exit.
 
* MC12
zf0-test-field.

    if test-field-occ(i)  = '~'
    then
        move 'N'                        to flag
        go to zf0-99-exit.
* endif

zf0-99-exit.
exit.
* MC12 - end

* 2004/02/26 - MC - preset the value for ws-hosp-nbr

xb0-verify-location.

    move spaces                         to ws-hosp-nbr.

    move clmhdr-loc of claim-header-rec to loc-nbr.

    read loc-mstr
        invalid key
* 2012/02/29 - MC5
            move 51 			to err-ind
	    perform za0-common-error 	thru za0-99-exit
            move ws-location 		to clmhdr-loc
            display scr-acpt-loc
* 2012/02/29 - end
            go to xb0-99-exit.

* 2004/05/19 - MC - cannot recall what is 'S' stand for - ignore this value
*    if iconst-clinic-card-colour = 'Y' or 'S'
    if iconst-clinic-card-colour = 'Y' 
* 2004/05/19 - end
    then
        move loc-hospital-code          to ws-hosp-nbr
    else
        move loc-hospital-nbr           to ws-hosp-nbr.
*   endif

xb0-99-exit.
    exit.

* 2004/02/26 - end


    copy "y2k_default_century_year.rtn". 

    copy "y2k_default_sysdate_century.rtn".
